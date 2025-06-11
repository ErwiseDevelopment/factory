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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class webservice : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel2"+"_"+"WEBSERVICEENDPOINTDECRYPTED") == 0 )
         {
            A658WebServiceEndPoint = GetPar( "WebServiceEndPoint");
            n658WebServiceEndPoint = false;
            AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX2ASAWEBSERVICEENDPOINTDECRYPTED2D83( A658WebServiceEndPoint) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WEBSERVICEAUTHTIPODECRYPTED") == 0 )
         {
            A659WebServiceAuthTipo = GetPar( "WebServiceAuthTipo");
            n659WebServiceAuthTipo = false;
            AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAWEBSERVICEAUTHTIPODECRYPTED2D83( A659WebServiceAuthTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"WEBSERVICEUSUARIODECRYPTED") == 0 )
         {
            A660WebServiceUsuario = GetPar( "WebServiceUsuario");
            n660WebServiceUsuario = false;
            AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAWEBSERVICEUSUARIODECRYPTED2D83( A660WebServiceUsuario) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"WEBSERVICESENHADECRYPTED") == 0 )
         {
            A661WebServiceSenha = GetPar( "WebServiceSenha");
            n661WebServiceSenha = false;
            AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASAWEBSERVICESENHADECRYPTED2D83( A661WebServiceSenha) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"WEBSERVICECERTIFICADOBASE64DECRYPTED") == 0 )
         {
            A1055WebServiceCertificadoBase64 = GetPar( "WebServiceCertificadoBase64");
            n1055WebServiceCertificadoBase64 = false;
            AssignAttri("", false, "A1055WebServiceCertificadoBase64", A1055WebServiceCertificadoBase64);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX6ASAWEBSERVICECERTIFICADOBASE64DECRYPTED2D83( A1055WebServiceCertificadoBase64) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"WEBSERVICECERTIFICADOPASSDECRYPTED") == 0 )
         {
            A1056WebServiceCertificadoPass = GetPar( "WebServiceCertificadoPass");
            n1056WebServiceCertificadoPass = false;
            AssignAttri("", false, "A1056WebServiceCertificadoPass", A1056WebServiceCertificadoPass);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAWEBSERVICECERTIFICADOPASSDECRYPTED2D83( A1056WebServiceCertificadoPass) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"WEBSERVICECLIENTIDDECRYPTED") == 0 )
         {
            A1059WebServiceClientid = GetPar( "WebServiceClientid");
            n1059WebServiceClientid = false;
            AssignAttri("", false, "A1059WebServiceClientid", A1059WebServiceClientid);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASAWEBSERVICECLIENTIDDECRYPTED2D83( A1059WebServiceClientid) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel9"+"_"+"WEBSERVICECLIENTSECRETDECRYPTED") == 0 )
         {
            A1060WebServiceClientSecret = GetPar( "WebServiceClientSecret");
            n1060WebServiceClientSecret = false;
            AssignAttri("", false, "A1060WebServiceClientSecret", A1060WebServiceClientSecret);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX9ASAWEBSERVICECLIENTSECRETDECRYPTED2D83( A1060WebServiceClientSecret) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "webservice")), "webservice") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "webservice")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7WebServiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WebServiceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7WebServiceId", StringUtil.LTrimStr( (decimal)(AV7WebServiceId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vWEBSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WebServiceId), "ZZZZZZZZ9"), context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "Web Service", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public webservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_WebServiceId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WebServiceId = aP1_WebServiceId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbWebServiceTipoDmWS = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
         {
            A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = false;
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
            AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Values", cmbWebServiceTipoDmWS.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWebServiceTipoDmWS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWebServiceTipoDmWS_Internalname, "Tipo WS", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWebServiceTipoDmWS, cmbWebServiceTipoDmWS_Internalname, StringUtil.RTrim( A657WebServiceTipoDmWS), 1, cmbWebServiceTipoDmWS_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbWebServiceTipoDmWS.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_WebService.htm");
         cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
         AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Values", (string)(cmbWebServiceTipoDmWS.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWebServiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A656WebServiceId), 9, 0, ",", "")), StringUtil.LTrim( ((edtWebServiceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWebServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtWebServiceId_Visible, edtWebServiceId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z656WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z656WebServiceId"), ",", "."), 18, MidpointRounding.ToEven));
               Z657WebServiceTipoDmWS = cgiGet( "Z657WebServiceTipoDmWS");
               n657WebServiceTipoDmWS = (String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               A658WebServiceEndPoint = cgiGet( "WEBSERVICEENDPOINT");
               n658WebServiceEndPoint = (String.IsNullOrEmpty(StringUtil.RTrim( A658WebServiceEndPoint)) ? true : false);
               A1061WebServiceEndPointDecrypted = cgiGet( "WEBSERVICEENDPOINTDECRYPTED");
               A659WebServiceAuthTipo = cgiGet( "WEBSERVICEAUTHTIPO");
               n659WebServiceAuthTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A659WebServiceAuthTipo)) ? true : false);
               A1062WebServiceAuthTipoDecrypted = cgiGet( "WEBSERVICEAUTHTIPODECRYPTED");
               A660WebServiceUsuario = cgiGet( "WEBSERVICEUSUARIO");
               n660WebServiceUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A660WebServiceUsuario)) ? true : false);
               A1063WebServiceUsuarioDecrypted = cgiGet( "WEBSERVICEUSUARIODECRYPTED");
               A661WebServiceSenha = cgiGet( "WEBSERVICESENHA");
               n661WebServiceSenha = (String.IsNullOrEmpty(StringUtil.RTrim( A661WebServiceSenha)) ? true : false);
               A1064WebServiceSenhaDecrypted = cgiGet( "WEBSERVICESENHADECRYPTED");
               A1055WebServiceCertificadoBase64 = cgiGet( "WEBSERVICECERTIFICADOBASE64");
               n1055WebServiceCertificadoBase64 = (String.IsNullOrEmpty(StringUtil.RTrim( A1055WebServiceCertificadoBase64)) ? true : false);
               A1065WebServiceCertificadoBase64Decrypted = cgiGet( "WEBSERVICECERTIFICADOBASE64DECRYPTED");
               A1056WebServiceCertificadoPass = cgiGet( "WEBSERVICECERTIFICADOPASS");
               n1056WebServiceCertificadoPass = (String.IsNullOrEmpty(StringUtil.RTrim( A1056WebServiceCertificadoPass)) ? true : false);
               A1066WebServiceCertificadoPassDecrypted = cgiGet( "WEBSERVICECERTIFICADOPASSDECRYPTED");
               A1059WebServiceClientid = cgiGet( "WEBSERVICECLIENTID");
               n1059WebServiceClientid = (String.IsNullOrEmpty(StringUtil.RTrim( A1059WebServiceClientid)) ? true : false);
               A1067WebServiceClientidDecrypted = cgiGet( "WEBSERVICECLIENTIDDECRYPTED");
               A1060WebServiceClientSecret = cgiGet( "WEBSERVICECLIENTSECRET");
               n1060WebServiceClientSecret = (String.IsNullOrEmpty(StringUtil.RTrim( A1060WebServiceClientSecret)) ? true : false);
               A1068WebServiceClientSecretDecrypted = cgiGet( "WEBSERVICECLIENTSECRETDECRYPTED");
               AV7WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vWEBSERVICEID"), ",", "."), 18, MidpointRounding.ToEven));
               A1054WebServiceSalt = cgiGet( "WEBSERVICESALT");
               n1054WebServiceSalt = false;
               n1054WebServiceSalt = (String.IsNullOrEmpty(StringUtil.RTrim( A1054WebServiceSalt)) ? true : false);
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               cmbWebServiceTipoDmWS.CurrentValue = cgiGet( cmbWebServiceTipoDmWS_Internalname);
               A657WebServiceTipoDmWS = cgiGet( cmbWebServiceTipoDmWS_Internalname);
               n657WebServiceTipoDmWS = false;
               AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
               n657WebServiceTipoDmWS = (String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ? true : false);
               A656WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWebServiceId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"WebService");
               A656WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWebServiceId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               forbiddenHiddens.Add("WebServiceId", context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A656WebServiceId != Z656WebServiceId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("webservice:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A656WebServiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WebServiceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode83 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode83;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound83 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WEBSERVICEID");
                        AnyError = 1;
                        GX_FocusControl = edtWebServiceId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E122D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2D83( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes2D83( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_2D0( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2D83( ) ;
            }
            else
            {
               CheckExtendedTable2D83( ) ;
               CloseExtendedTableCursors2D83( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2D0( )
      {
      }

      protected void E112D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtWebServiceId_Visible = 0;
         AssignProp("", false, edtWebServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWebServiceId_Visible), 5, 0), true);
      }

      protected void E122D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("webserviceww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2D83( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z657WebServiceTipoDmWS = T002D3_A657WebServiceTipoDmWS[0];
            }
            else
            {
               Z657WebServiceTipoDmWS = A657WebServiceTipoDmWS;
            }
         }
         if ( GX_JID == -12 )
         {
            Z656WebServiceId = A656WebServiceId;
            Z657WebServiceTipoDmWS = A657WebServiceTipoDmWS;
            Z658WebServiceEndPoint = A658WebServiceEndPoint;
            Z659WebServiceAuthTipo = A659WebServiceAuthTipo;
            Z660WebServiceUsuario = A660WebServiceUsuario;
            Z661WebServiceSenha = A661WebServiceSenha;
            Z1054WebServiceSalt = A1054WebServiceSalt;
            Z1055WebServiceCertificadoBase64 = A1055WebServiceCertificadoBase64;
            Z1056WebServiceCertificadoPass = A1056WebServiceCertificadoPass;
            Z1059WebServiceClientid = A1059WebServiceClientid;
            Z1060WebServiceClientSecret = A1060WebServiceClientSecret;
         }
      }

      protected void standaloneNotModal( )
      {
         edtWebServiceId_Enabled = 0;
         AssignProp("", false, edtWebServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceId_Enabled), 5, 0), true);
         edtWebServiceId_Enabled = 0;
         AssignProp("", false, edtWebServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WebServiceId) )
         {
            A656WebServiceId = AV7WebServiceId;
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load2D83( )
      {
         /* Using cursor T002D4 */
         pr_default.execute(2, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound83 = 1;
            A657WebServiceTipoDmWS = T002D4_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = T002D4_n657WebServiceTipoDmWS[0];
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
            A658WebServiceEndPoint = T002D4_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = T002D4_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = T002D4_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = T002D4_n659WebServiceAuthTipo[0];
            A660WebServiceUsuario = T002D4_A660WebServiceUsuario[0];
            n660WebServiceUsuario = T002D4_n660WebServiceUsuario[0];
            A661WebServiceSenha = T002D4_A661WebServiceSenha[0];
            n661WebServiceSenha = T002D4_n661WebServiceSenha[0];
            A1054WebServiceSalt = T002D4_A1054WebServiceSalt[0];
            n1054WebServiceSalt = T002D4_n1054WebServiceSalt[0];
            A1055WebServiceCertificadoBase64 = T002D4_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = T002D4_n1055WebServiceCertificadoBase64[0];
            A1056WebServiceCertificadoPass = T002D4_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = T002D4_n1056WebServiceCertificadoPass[0];
            A1059WebServiceClientid = T002D4_A1059WebServiceClientid[0];
            n1059WebServiceClientid = T002D4_n1059WebServiceClientid[0];
            A1060WebServiceClientSecret = T002D4_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = T002D4_n1060WebServiceClientSecret[0];
            ZM2D83( -12) ;
         }
         pr_default.close(2);
         OnLoadActions2D83( ) ;
      }

      protected void OnLoadActions2D83( )
      {
         GXt_char1 = A1061WebServiceEndPointDecrypted;
         new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
         A1061WebServiceEndPointDecrypted = GXt_char1;
         AssignAttri("", false, "A1061WebServiceEndPointDecrypted", A1061WebServiceEndPointDecrypted);
         GXt_char1 = A1062WebServiceAuthTipoDecrypted;
         new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
         A1062WebServiceAuthTipoDecrypted = GXt_char1;
         AssignAttri("", false, "A1062WebServiceAuthTipoDecrypted", A1062WebServiceAuthTipoDecrypted);
         GXt_char1 = A1063WebServiceUsuarioDecrypted;
         new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
         A1063WebServiceUsuarioDecrypted = GXt_char1;
         AssignAttri("", false, "A1063WebServiceUsuarioDecrypted", A1063WebServiceUsuarioDecrypted);
         GXt_char1 = A1064WebServiceSenhaDecrypted;
         new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
         A1064WebServiceSenhaDecrypted = GXt_char1;
         AssignAttri("", false, "A1064WebServiceSenhaDecrypted", A1064WebServiceSenhaDecrypted);
         GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
         new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
         A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
         AssignAttri("", false, "A1065WebServiceCertificadoBase64Decrypted", A1065WebServiceCertificadoBase64Decrypted);
         GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
         new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
         A1066WebServiceCertificadoPassDecrypted = GXt_char1;
         AssignAttri("", false, "A1066WebServiceCertificadoPassDecrypted", A1066WebServiceCertificadoPassDecrypted);
         GXt_char1 = A1067WebServiceClientidDecrypted;
         new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
         A1067WebServiceClientidDecrypted = GXt_char1;
         AssignAttri("", false, "A1067WebServiceClientidDecrypted", A1067WebServiceClientidDecrypted);
         GXt_char1 = A1068WebServiceClientSecretDecrypted;
         new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
         A1068WebServiceClientSecretDecrypted = GXt_char1;
         AssignAttri("", false, "A1068WebServiceClientSecretDecrypted", A1068WebServiceClientSecretDecrypted);
      }

      protected void CheckExtendedTable2D83( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) || ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) || ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Santander") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ) )
         {
            GX_msglist.addItem("Campo Tipo WS fora do intervalo", "OutOfRange", 1, "WEBSERVICETIPODMWS");
            AnyError = 1;
            GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char1 = A1061WebServiceEndPointDecrypted;
         new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
         A1061WebServiceEndPointDecrypted = GXt_char1;
         AssignAttri("", false, "A1061WebServiceEndPointDecrypted", A1061WebServiceEndPointDecrypted);
         GXt_char1 = A1062WebServiceAuthTipoDecrypted;
         new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
         A1062WebServiceAuthTipoDecrypted = GXt_char1;
         AssignAttri("", false, "A1062WebServiceAuthTipoDecrypted", A1062WebServiceAuthTipoDecrypted);
         GXt_char1 = A1063WebServiceUsuarioDecrypted;
         new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
         A1063WebServiceUsuarioDecrypted = GXt_char1;
         AssignAttri("", false, "A1063WebServiceUsuarioDecrypted", A1063WebServiceUsuarioDecrypted);
         GXt_char1 = A1064WebServiceSenhaDecrypted;
         new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
         A1064WebServiceSenhaDecrypted = GXt_char1;
         AssignAttri("", false, "A1064WebServiceSenhaDecrypted", A1064WebServiceSenhaDecrypted);
         GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
         new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
         A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
         AssignAttri("", false, "A1065WebServiceCertificadoBase64Decrypted", A1065WebServiceCertificadoBase64Decrypted);
         GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
         new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
         A1066WebServiceCertificadoPassDecrypted = GXt_char1;
         AssignAttri("", false, "A1066WebServiceCertificadoPassDecrypted", A1066WebServiceCertificadoPassDecrypted);
         GXt_char1 = A1067WebServiceClientidDecrypted;
         new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
         A1067WebServiceClientidDecrypted = GXt_char1;
         AssignAttri("", false, "A1067WebServiceClientidDecrypted", A1067WebServiceClientidDecrypted);
         GXt_char1 = A1068WebServiceClientSecretDecrypted;
         new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
         A1068WebServiceClientSecretDecrypted = GXt_char1;
         AssignAttri("", false, "A1068WebServiceClientSecretDecrypted", A1068WebServiceClientSecretDecrypted);
      }

      protected void CloseExtendedTableCursors2D83( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2D83( )
      {
         /* Using cursor T002D5 */
         pr_default.execute(3, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002D3 */
         pr_default.execute(1, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2D83( 12) ;
            RcdFound83 = 1;
            A656WebServiceId = T002D3_A656WebServiceId[0];
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
            A657WebServiceTipoDmWS = T002D3_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = T002D3_n657WebServiceTipoDmWS[0];
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
            A658WebServiceEndPoint = T002D3_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = T002D3_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = T002D3_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = T002D3_n659WebServiceAuthTipo[0];
            A660WebServiceUsuario = T002D3_A660WebServiceUsuario[0];
            n660WebServiceUsuario = T002D3_n660WebServiceUsuario[0];
            A661WebServiceSenha = T002D3_A661WebServiceSenha[0];
            n661WebServiceSenha = T002D3_n661WebServiceSenha[0];
            A1054WebServiceSalt = T002D3_A1054WebServiceSalt[0];
            n1054WebServiceSalt = T002D3_n1054WebServiceSalt[0];
            A1055WebServiceCertificadoBase64 = T002D3_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = T002D3_n1055WebServiceCertificadoBase64[0];
            A1056WebServiceCertificadoPass = T002D3_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = T002D3_n1056WebServiceCertificadoPass[0];
            A1059WebServiceClientid = T002D3_A1059WebServiceClientid[0];
            n1059WebServiceClientid = T002D3_n1059WebServiceClientid[0];
            A1060WebServiceClientSecret = T002D3_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = T002D3_n1060WebServiceClientSecret[0];
            Z656WebServiceId = A656WebServiceId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2D83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey2D83( ) ;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey2D83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2D83( ) ;
         if ( RcdFound83 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound83 = 0;
         /* Using cursor T002D6 */
         pr_default.execute(4, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002D6_A656WebServiceId[0] < A656WebServiceId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002D6_A656WebServiceId[0] > A656WebServiceId ) ) )
            {
               A656WebServiceId = T002D6_A656WebServiceId[0];
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound83 = 0;
         /* Using cursor T002D7 */
         pr_default.execute(5, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002D7_A656WebServiceId[0] > A656WebServiceId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002D7_A656WebServiceId[0] < A656WebServiceId ) ) )
            {
               A656WebServiceId = T002D7_A656WebServiceId[0];
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2D83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2D83( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( A656WebServiceId != Z656WebServiceId )
               {
                  A656WebServiceId = Z656WebServiceId;
                  AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WEBSERVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtWebServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2D83( ) ;
                  GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A656WebServiceId != Z656WebServiceId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2D83( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WEBSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtWebServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2D83( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A656WebServiceId != Z656WebServiceId )
         {
            A656WebServiceId = Z656WebServiceId;
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WEBSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtWebServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2D83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002D2 */
            pr_default.execute(0, new Object[] {A656WebServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WebService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z657WebServiceTipoDmWS, T002D2_A657WebServiceTipoDmWS[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z657WebServiceTipoDmWS, T002D2_A657WebServiceTipoDmWS[0]) != 0 )
               {
                  GXUtil.WriteLog("webservice:[seudo value changed for attri]"+"WebServiceTipoDmWS");
                  GXUtil.WriteLogRaw("Old: ",Z657WebServiceTipoDmWS);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A657WebServiceTipoDmWS[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WebService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2D83( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2D83( 0) ;
            CheckOptimisticConcurrency2D83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2D83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D8 */
                     pr_default.execute(6, new Object[] {n657WebServiceTipoDmWS, A657WebServiceTipoDmWS, n658WebServiceEndPoint, A658WebServiceEndPoint, n659WebServiceAuthTipo, A659WebServiceAuthTipo, n660WebServiceUsuario, A660WebServiceUsuario, n661WebServiceSenha, A661WebServiceSenha, n1054WebServiceSalt, A1054WebServiceSalt, n1055WebServiceCertificadoBase64, A1055WebServiceCertificadoBase64, n1056WebServiceCertificadoPass, A1056WebServiceCertificadoPass, n1059WebServiceClientid, A1059WebServiceClientid, n1060WebServiceClientSecret, A1060WebServiceClientSecret});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002D9 */
                     pr_default.execute(7);
                     A656WebServiceId = T002D9_A656WebServiceId[0];
                     AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WebService");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2D0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load2D83( ) ;
            }
            EndLevel2D83( ) ;
         }
         CloseExtendedTableCursors2D83( ) ;
      }

      protected void Update2D83( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2D83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D10 */
                     pr_default.execute(8, new Object[] {n657WebServiceTipoDmWS, A657WebServiceTipoDmWS, n658WebServiceEndPoint, A658WebServiceEndPoint, n659WebServiceAuthTipo, A659WebServiceAuthTipo, n660WebServiceUsuario, A660WebServiceUsuario, n661WebServiceSenha, A661WebServiceSenha, n1054WebServiceSalt, A1054WebServiceSalt, n1055WebServiceCertificadoBase64, A1055WebServiceCertificadoBase64, n1056WebServiceCertificadoPass, A1056WebServiceCertificadoPass, n1059WebServiceClientid, A1059WebServiceClientid, n1060WebServiceClientSecret, A1060WebServiceClientSecret, A656WebServiceId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WebService");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WebService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2D83( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel2D83( ) ;
         }
         CloseExtendedTableCursors2D83( ) ;
      }

      protected void DeferredUpdate2D83( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2D83( ) ;
            AfterConfirm2D83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2D83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002D11 */
                  pr_default.execute(9, new Object[] {A656WebServiceId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WebService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2D83( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2D83( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_char1 = A1061WebServiceEndPointDecrypted;
            new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
            A1061WebServiceEndPointDecrypted = GXt_char1;
            AssignAttri("", false, "A1061WebServiceEndPointDecrypted", A1061WebServiceEndPointDecrypted);
            GXt_char1 = A1062WebServiceAuthTipoDecrypted;
            new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
            A1062WebServiceAuthTipoDecrypted = GXt_char1;
            AssignAttri("", false, "A1062WebServiceAuthTipoDecrypted", A1062WebServiceAuthTipoDecrypted);
            GXt_char1 = A1063WebServiceUsuarioDecrypted;
            new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
            A1063WebServiceUsuarioDecrypted = GXt_char1;
            AssignAttri("", false, "A1063WebServiceUsuarioDecrypted", A1063WebServiceUsuarioDecrypted);
            GXt_char1 = A1064WebServiceSenhaDecrypted;
            new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
            A1064WebServiceSenhaDecrypted = GXt_char1;
            AssignAttri("", false, "A1064WebServiceSenhaDecrypted", A1064WebServiceSenhaDecrypted);
            GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
            new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
            A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
            AssignAttri("", false, "A1065WebServiceCertificadoBase64Decrypted", A1065WebServiceCertificadoBase64Decrypted);
            GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
            new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
            A1066WebServiceCertificadoPassDecrypted = GXt_char1;
            AssignAttri("", false, "A1066WebServiceCertificadoPassDecrypted", A1066WebServiceCertificadoPassDecrypted);
            GXt_char1 = A1067WebServiceClientidDecrypted;
            new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
            A1067WebServiceClientidDecrypted = GXt_char1;
            AssignAttri("", false, "A1067WebServiceClientidDecrypted", A1067WebServiceClientidDecrypted);
            GXt_char1 = A1068WebServiceClientSecretDecrypted;
            new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
            A1068WebServiceClientSecretDecrypted = GXt_char1;
            AssignAttri("", false, "A1068WebServiceClientSecretDecrypted", A1068WebServiceClientSecretDecrypted);
         }
      }

      protected void EndLevel2D83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("webservice",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("webservice",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2D83( )
      {
         /* Scan By routine */
         /* Using cursor T002D12 */
         pr_default.execute(10);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound83 = 1;
            A656WebServiceId = T002D12_A656WebServiceId[0];
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2D83( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound83 = 1;
            A656WebServiceId = T002D12_A656WebServiceId[0];
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         }
      }

      protected void ScanEnd2D83( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2D83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2D83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2D83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2D83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2D83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2D83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2D83( )
      {
         cmbWebServiceTipoDmWS.Enabled = 0;
         AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWebServiceTipoDmWS.Enabled), 5, 0), true);
         edtWebServiceId_Enabled = 0;
         AssignProp("", false, edtWebServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2D83( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2D0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "webservice"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WebServiceId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("webservice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WebService");
         forbiddenHiddens.Add("WebServiceId", context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("webservice:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z656WebServiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z656WebServiceId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z657WebServiceTipoDmWS", Z657WebServiceTipoDmWS);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "WEBSERVICEENDPOINT", A658WebServiceEndPoint);
         GxWebStd.gx_hidden_field( context, "WEBSERVICEENDPOINTDECRYPTED", A1061WebServiceEndPointDecrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICEAUTHTIPO", A659WebServiceAuthTipo);
         GxWebStd.gx_hidden_field( context, "WEBSERVICEAUTHTIPODECRYPTED", A1062WebServiceAuthTipoDecrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICEUSUARIO", A660WebServiceUsuario);
         GxWebStd.gx_hidden_field( context, "WEBSERVICEUSUARIODECRYPTED", A1063WebServiceUsuarioDecrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICESENHA", A661WebServiceSenha);
         GxWebStd.gx_hidden_field( context, "WEBSERVICESENHADECRYPTED", A1064WebServiceSenhaDecrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECERTIFICADOBASE64", A1055WebServiceCertificadoBase64);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECERTIFICADOBASE64DECRYPTED", A1065WebServiceCertificadoBase64Decrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECERTIFICADOPASS", A1056WebServiceCertificadoPass);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECERTIFICADOPASSDECRYPTED", A1066WebServiceCertificadoPassDecrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECLIENTID", A1059WebServiceClientid);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECLIENTIDDECRYPTED", A1067WebServiceClientidDecrypted);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECLIENTSECRET", A1060WebServiceClientSecret);
         GxWebStd.gx_hidden_field( context, "WEBSERVICECLIENTSECRETDECRYPTED", A1068WebServiceClientSecretDecrypted);
         GxWebStd.gx_hidden_field( context, "vWEBSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WebServiceId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWEBSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WebServiceId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WEBSERVICESALT", A1054WebServiceSalt);
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "webservice"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WebServiceId,9,0));
         return formatLink("webservice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WebService" ;
      }

      public override string GetPgmdesc( )
      {
         return "Web Service" ;
      }

      protected void InitializeNonKey2D83( )
      {
         A1068WebServiceClientSecretDecrypted = "";
         AssignAttri("", false, "A1068WebServiceClientSecretDecrypted", A1068WebServiceClientSecretDecrypted);
         A1067WebServiceClientidDecrypted = "";
         AssignAttri("", false, "A1067WebServiceClientidDecrypted", A1067WebServiceClientidDecrypted);
         A1066WebServiceCertificadoPassDecrypted = "";
         AssignAttri("", false, "A1066WebServiceCertificadoPassDecrypted", A1066WebServiceCertificadoPassDecrypted);
         A1065WebServiceCertificadoBase64Decrypted = "";
         AssignAttri("", false, "A1065WebServiceCertificadoBase64Decrypted", A1065WebServiceCertificadoBase64Decrypted);
         A1064WebServiceSenhaDecrypted = "";
         AssignAttri("", false, "A1064WebServiceSenhaDecrypted", A1064WebServiceSenhaDecrypted);
         A1063WebServiceUsuarioDecrypted = "";
         AssignAttri("", false, "A1063WebServiceUsuarioDecrypted", A1063WebServiceUsuarioDecrypted);
         A1062WebServiceAuthTipoDecrypted = "";
         AssignAttri("", false, "A1062WebServiceAuthTipoDecrypted", A1062WebServiceAuthTipoDecrypted);
         A1061WebServiceEndPointDecrypted = "";
         AssignAttri("", false, "A1061WebServiceEndPointDecrypted", A1061WebServiceEndPointDecrypted);
         A657WebServiceTipoDmWS = "";
         n657WebServiceTipoDmWS = false;
         AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         n657WebServiceTipoDmWS = (String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ? true : false);
         A658WebServiceEndPoint = "";
         n658WebServiceEndPoint = false;
         AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
         A659WebServiceAuthTipo = "";
         n659WebServiceAuthTipo = false;
         AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
         A660WebServiceUsuario = "";
         n660WebServiceUsuario = false;
         AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
         A661WebServiceSenha = "";
         n661WebServiceSenha = false;
         AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
         A1054WebServiceSalt = "";
         n1054WebServiceSalt = false;
         AssignAttri("", false, "A1054WebServiceSalt", A1054WebServiceSalt);
         A1055WebServiceCertificadoBase64 = "";
         n1055WebServiceCertificadoBase64 = false;
         AssignAttri("", false, "A1055WebServiceCertificadoBase64", A1055WebServiceCertificadoBase64);
         A1056WebServiceCertificadoPass = "";
         n1056WebServiceCertificadoPass = false;
         AssignAttri("", false, "A1056WebServiceCertificadoPass", A1056WebServiceCertificadoPass);
         A1059WebServiceClientid = "";
         n1059WebServiceClientid = false;
         AssignAttri("", false, "A1059WebServiceClientid", A1059WebServiceClientid);
         A1060WebServiceClientSecret = "";
         n1060WebServiceClientSecret = false;
         AssignAttri("", false, "A1060WebServiceClientSecret", A1060WebServiceClientSecret);
         Z657WebServiceTipoDmWS = "";
      }

      protected void InitAll2D83( )
      {
         A656WebServiceId = 0;
         AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         InitializeNonKey2D83( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019194526", true, true);
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
         context.AddJavascriptSource("webservice.js", "?202561019194527", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbWebServiceTipoDmWS_Internalname = "WEBSERVICETIPODMWS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtWebServiceId_Internalname = "WEBSERVICEID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Web Service";
         edtWebServiceId_Jsonclick = "";
         edtWebServiceId_Enabled = 0;
         edtWebServiceId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbWebServiceTipoDmWS_Jsonclick = "";
         cmbWebServiceTipoDmWS.Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX2ASAWEBSERVICEENDPOINTDECRYPTED2D83( string A658WebServiceEndPoint )
      {
         GXt_char1 = A1061WebServiceEndPointDecrypted;
         new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
         A1061WebServiceEndPointDecrypted = GXt_char1;
         AssignAttri("", false, "A1061WebServiceEndPointDecrypted", A1061WebServiceEndPointDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1061WebServiceEndPointDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX3ASAWEBSERVICEAUTHTIPODECRYPTED2D83( string A659WebServiceAuthTipo )
      {
         GXt_char1 = A1062WebServiceAuthTipoDecrypted;
         new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
         A1062WebServiceAuthTipoDecrypted = GXt_char1;
         AssignAttri("", false, "A1062WebServiceAuthTipoDecrypted", A1062WebServiceAuthTipoDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1062WebServiceAuthTipoDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX4ASAWEBSERVICEUSUARIODECRYPTED2D83( string A660WebServiceUsuario )
      {
         GXt_char1 = A1063WebServiceUsuarioDecrypted;
         new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
         A1063WebServiceUsuarioDecrypted = GXt_char1;
         AssignAttri("", false, "A1063WebServiceUsuarioDecrypted", A1063WebServiceUsuarioDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1063WebServiceUsuarioDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX5ASAWEBSERVICESENHADECRYPTED2D83( string A661WebServiceSenha )
      {
         GXt_char1 = A1064WebServiceSenhaDecrypted;
         new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
         A1064WebServiceSenhaDecrypted = GXt_char1;
         AssignAttri("", false, "A1064WebServiceSenhaDecrypted", A1064WebServiceSenhaDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1064WebServiceSenhaDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX6ASAWEBSERVICECERTIFICADOBASE64DECRYPTED2D83( string A1055WebServiceCertificadoBase64 )
      {
         GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
         new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
         A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
         AssignAttri("", false, "A1065WebServiceCertificadoBase64Decrypted", A1065WebServiceCertificadoBase64Decrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1065WebServiceCertificadoBase64Decrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX7ASAWEBSERVICECERTIFICADOPASSDECRYPTED2D83( string A1056WebServiceCertificadoPass )
      {
         GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
         new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
         A1066WebServiceCertificadoPassDecrypted = GXt_char1;
         AssignAttri("", false, "A1066WebServiceCertificadoPassDecrypted", A1066WebServiceCertificadoPassDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1066WebServiceCertificadoPassDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX8ASAWEBSERVICECLIENTIDDECRYPTED2D83( string A1059WebServiceClientid )
      {
         GXt_char1 = A1067WebServiceClientidDecrypted;
         new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
         A1067WebServiceClientidDecrypted = GXt_char1;
         AssignAttri("", false, "A1067WebServiceClientidDecrypted", A1067WebServiceClientidDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1067WebServiceClientidDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX9ASAWEBSERVICECLIENTSECRETDECRYPTED2D83( string A1060WebServiceClientSecret )
      {
         GXt_char1 = A1068WebServiceClientSecretDecrypted;
         new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
         A1068WebServiceClientSecretDecrypted = GXt_char1;
         AssignAttri("", false, "A1068WebServiceClientSecretDecrypted", A1068WebServiceClientSecretDecrypted);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1068WebServiceClientSecretDecrypted)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbWebServiceTipoDmWS.Name = "WEBSERVICETIPODMWS";
         cmbWebServiceTipoDmWS.WebTags = "";
         cmbWebServiceTipoDmWS.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
         cmbWebServiceTipoDmWS.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
         cmbWebServiceTipoDmWS.addItem("Santander", "Santander", 0);
         if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
         {
            A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = false;
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7WebServiceId","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7WebServiceId","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A656WebServiceId","fld":"WEBSERVICEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122D2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_WEBSERVICETIPODMWS","""{"handler":"Valid_Webservicetipodmws","iparms":[]}""");
         setEventMetadata("VALID_WEBSERVICEID","""{"handler":"Valid_Webserviceid","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z657WebServiceTipoDmWS = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A658WebServiceEndPoint = "";
         A659WebServiceAuthTipo = "";
         A660WebServiceUsuario = "";
         A661WebServiceSenha = "";
         A1055WebServiceCertificadoBase64 = "";
         A1056WebServiceCertificadoPass = "";
         A1059WebServiceClientid = "";
         A1060WebServiceClientSecret = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A657WebServiceTipoDmWS = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1061WebServiceEndPointDecrypted = "";
         A1062WebServiceAuthTipoDecrypted = "";
         A1063WebServiceUsuarioDecrypted = "";
         A1064WebServiceSenhaDecrypted = "";
         A1065WebServiceCertificadoBase64Decrypted = "";
         A1066WebServiceCertificadoPassDecrypted = "";
         A1067WebServiceClientidDecrypted = "";
         A1068WebServiceClientSecretDecrypted = "";
         A1054WebServiceSalt = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode83 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z658WebServiceEndPoint = "";
         Z659WebServiceAuthTipo = "";
         Z660WebServiceUsuario = "";
         Z661WebServiceSenha = "";
         Z1054WebServiceSalt = "";
         Z1055WebServiceCertificadoBase64 = "";
         Z1056WebServiceCertificadoPass = "";
         Z1059WebServiceClientid = "";
         Z1060WebServiceClientSecret = "";
         T002D4_A656WebServiceId = new int[1] ;
         T002D4_A657WebServiceTipoDmWS = new string[] {""} ;
         T002D4_n657WebServiceTipoDmWS = new bool[] {false} ;
         T002D4_A658WebServiceEndPoint = new string[] {""} ;
         T002D4_n658WebServiceEndPoint = new bool[] {false} ;
         T002D4_A659WebServiceAuthTipo = new string[] {""} ;
         T002D4_n659WebServiceAuthTipo = new bool[] {false} ;
         T002D4_A660WebServiceUsuario = new string[] {""} ;
         T002D4_n660WebServiceUsuario = new bool[] {false} ;
         T002D4_A661WebServiceSenha = new string[] {""} ;
         T002D4_n661WebServiceSenha = new bool[] {false} ;
         T002D4_A1054WebServiceSalt = new string[] {""} ;
         T002D4_n1054WebServiceSalt = new bool[] {false} ;
         T002D4_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         T002D4_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         T002D4_A1056WebServiceCertificadoPass = new string[] {""} ;
         T002D4_n1056WebServiceCertificadoPass = new bool[] {false} ;
         T002D4_A1059WebServiceClientid = new string[] {""} ;
         T002D4_n1059WebServiceClientid = new bool[] {false} ;
         T002D4_A1060WebServiceClientSecret = new string[] {""} ;
         T002D4_n1060WebServiceClientSecret = new bool[] {false} ;
         T002D5_A656WebServiceId = new int[1] ;
         T002D3_A656WebServiceId = new int[1] ;
         T002D3_A657WebServiceTipoDmWS = new string[] {""} ;
         T002D3_n657WebServiceTipoDmWS = new bool[] {false} ;
         T002D3_A658WebServiceEndPoint = new string[] {""} ;
         T002D3_n658WebServiceEndPoint = new bool[] {false} ;
         T002D3_A659WebServiceAuthTipo = new string[] {""} ;
         T002D3_n659WebServiceAuthTipo = new bool[] {false} ;
         T002D3_A660WebServiceUsuario = new string[] {""} ;
         T002D3_n660WebServiceUsuario = new bool[] {false} ;
         T002D3_A661WebServiceSenha = new string[] {""} ;
         T002D3_n661WebServiceSenha = new bool[] {false} ;
         T002D3_A1054WebServiceSalt = new string[] {""} ;
         T002D3_n1054WebServiceSalt = new bool[] {false} ;
         T002D3_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         T002D3_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         T002D3_A1056WebServiceCertificadoPass = new string[] {""} ;
         T002D3_n1056WebServiceCertificadoPass = new bool[] {false} ;
         T002D3_A1059WebServiceClientid = new string[] {""} ;
         T002D3_n1059WebServiceClientid = new bool[] {false} ;
         T002D3_A1060WebServiceClientSecret = new string[] {""} ;
         T002D3_n1060WebServiceClientSecret = new bool[] {false} ;
         T002D6_A656WebServiceId = new int[1] ;
         T002D7_A656WebServiceId = new int[1] ;
         T002D2_A656WebServiceId = new int[1] ;
         T002D2_A657WebServiceTipoDmWS = new string[] {""} ;
         T002D2_n657WebServiceTipoDmWS = new bool[] {false} ;
         T002D2_A658WebServiceEndPoint = new string[] {""} ;
         T002D2_n658WebServiceEndPoint = new bool[] {false} ;
         T002D2_A659WebServiceAuthTipo = new string[] {""} ;
         T002D2_n659WebServiceAuthTipo = new bool[] {false} ;
         T002D2_A660WebServiceUsuario = new string[] {""} ;
         T002D2_n660WebServiceUsuario = new bool[] {false} ;
         T002D2_A661WebServiceSenha = new string[] {""} ;
         T002D2_n661WebServiceSenha = new bool[] {false} ;
         T002D2_A1054WebServiceSalt = new string[] {""} ;
         T002D2_n1054WebServiceSalt = new bool[] {false} ;
         T002D2_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         T002D2_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         T002D2_A1056WebServiceCertificadoPass = new string[] {""} ;
         T002D2_n1056WebServiceCertificadoPass = new bool[] {false} ;
         T002D2_A1059WebServiceClientid = new string[] {""} ;
         T002D2_n1059WebServiceClientid = new bool[] {false} ;
         T002D2_A1060WebServiceClientSecret = new string[] {""} ;
         T002D2_n1060WebServiceClientSecret = new bool[] {false} ;
         T002D9_A656WebServiceId = new int[1] ;
         T002D12_A656WebServiceId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webservice__default(),
            new Object[][] {
                new Object[] {
               T002D2_A656WebServiceId, T002D2_A657WebServiceTipoDmWS, T002D2_n657WebServiceTipoDmWS, T002D2_A658WebServiceEndPoint, T002D2_n658WebServiceEndPoint, T002D2_A659WebServiceAuthTipo, T002D2_n659WebServiceAuthTipo, T002D2_A660WebServiceUsuario, T002D2_n660WebServiceUsuario, T002D2_A661WebServiceSenha,
               T002D2_n661WebServiceSenha, T002D2_A1054WebServiceSalt, T002D2_n1054WebServiceSalt, T002D2_A1055WebServiceCertificadoBase64, T002D2_n1055WebServiceCertificadoBase64, T002D2_A1056WebServiceCertificadoPass, T002D2_n1056WebServiceCertificadoPass, T002D2_A1059WebServiceClientid, T002D2_n1059WebServiceClientid, T002D2_A1060WebServiceClientSecret,
               T002D2_n1060WebServiceClientSecret
               }
               , new Object[] {
               T002D3_A656WebServiceId, T002D3_A657WebServiceTipoDmWS, T002D3_n657WebServiceTipoDmWS, T002D3_A658WebServiceEndPoint, T002D3_n658WebServiceEndPoint, T002D3_A659WebServiceAuthTipo, T002D3_n659WebServiceAuthTipo, T002D3_A660WebServiceUsuario, T002D3_n660WebServiceUsuario, T002D3_A661WebServiceSenha,
               T002D3_n661WebServiceSenha, T002D3_A1054WebServiceSalt, T002D3_n1054WebServiceSalt, T002D3_A1055WebServiceCertificadoBase64, T002D3_n1055WebServiceCertificadoBase64, T002D3_A1056WebServiceCertificadoPass, T002D3_n1056WebServiceCertificadoPass, T002D3_A1059WebServiceClientid, T002D3_n1059WebServiceClientid, T002D3_A1060WebServiceClientSecret,
               T002D3_n1060WebServiceClientSecret
               }
               , new Object[] {
               T002D4_A656WebServiceId, T002D4_A657WebServiceTipoDmWS, T002D4_n657WebServiceTipoDmWS, T002D4_A658WebServiceEndPoint, T002D4_n658WebServiceEndPoint, T002D4_A659WebServiceAuthTipo, T002D4_n659WebServiceAuthTipo, T002D4_A660WebServiceUsuario, T002D4_n660WebServiceUsuario, T002D4_A661WebServiceSenha,
               T002D4_n661WebServiceSenha, T002D4_A1054WebServiceSalt, T002D4_n1054WebServiceSalt, T002D4_A1055WebServiceCertificadoBase64, T002D4_n1055WebServiceCertificadoBase64, T002D4_A1056WebServiceCertificadoPass, T002D4_n1056WebServiceCertificadoPass, T002D4_A1059WebServiceClientid, T002D4_n1059WebServiceClientid, T002D4_A1060WebServiceClientSecret,
               T002D4_n1060WebServiceClientSecret
               }
               , new Object[] {
               T002D5_A656WebServiceId
               }
               , new Object[] {
               T002D6_A656WebServiceId
               }
               , new Object[] {
               T002D7_A656WebServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               T002D9_A656WebServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002D12_A656WebServiceId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound83 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7WebServiceId ;
      private int Z656WebServiceId ;
      private int AV7WebServiceId ;
      private int trnEnded ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A656WebServiceId ;
      private int edtWebServiceId_Enabled ;
      private int edtWebServiceId_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbWebServiceTipoDmWS_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string cmbWebServiceTipoDmWS_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtWebServiceId_Internalname ;
      private string edtWebServiceId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode83 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n658WebServiceEndPoint ;
      private bool n659WebServiceAuthTipo ;
      private bool n660WebServiceUsuario ;
      private bool n661WebServiceSenha ;
      private bool n1055WebServiceCertificadoBase64 ;
      private bool n1056WebServiceCertificadoPass ;
      private bool n1059WebServiceClientid ;
      private bool n1060WebServiceClientSecret ;
      private bool wbErr ;
      private bool n657WebServiceTipoDmWS ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n1054WebServiceSalt ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string A658WebServiceEndPoint ;
      private string A659WebServiceAuthTipo ;
      private string A660WebServiceUsuario ;
      private string A661WebServiceSenha ;
      private string A1055WebServiceCertificadoBase64 ;
      private string A1056WebServiceCertificadoPass ;
      private string A1059WebServiceClientid ;
      private string A1060WebServiceClientSecret ;
      private string A1061WebServiceEndPointDecrypted ;
      private string A1062WebServiceAuthTipoDecrypted ;
      private string A1063WebServiceUsuarioDecrypted ;
      private string A1064WebServiceSenhaDecrypted ;
      private string A1065WebServiceCertificadoBase64Decrypted ;
      private string A1066WebServiceCertificadoPassDecrypted ;
      private string A1067WebServiceClientidDecrypted ;
      private string A1068WebServiceClientSecretDecrypted ;
      private string A1054WebServiceSalt ;
      private string Z658WebServiceEndPoint ;
      private string Z659WebServiceAuthTipo ;
      private string Z660WebServiceUsuario ;
      private string Z661WebServiceSenha ;
      private string Z1054WebServiceSalt ;
      private string Z1055WebServiceCertificadoBase64 ;
      private string Z1056WebServiceCertificadoPass ;
      private string Z1059WebServiceClientid ;
      private string Z1060WebServiceClientSecret ;
      private string Z657WebServiceTipoDmWS ;
      private string A657WebServiceTipoDmWS ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWebServiceTipoDmWS ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T002D4_A656WebServiceId ;
      private string[] T002D4_A657WebServiceTipoDmWS ;
      private bool[] T002D4_n657WebServiceTipoDmWS ;
      private string[] T002D4_A658WebServiceEndPoint ;
      private bool[] T002D4_n658WebServiceEndPoint ;
      private string[] T002D4_A659WebServiceAuthTipo ;
      private bool[] T002D4_n659WebServiceAuthTipo ;
      private string[] T002D4_A660WebServiceUsuario ;
      private bool[] T002D4_n660WebServiceUsuario ;
      private string[] T002D4_A661WebServiceSenha ;
      private bool[] T002D4_n661WebServiceSenha ;
      private string[] T002D4_A1054WebServiceSalt ;
      private bool[] T002D4_n1054WebServiceSalt ;
      private string[] T002D4_A1055WebServiceCertificadoBase64 ;
      private bool[] T002D4_n1055WebServiceCertificadoBase64 ;
      private string[] T002D4_A1056WebServiceCertificadoPass ;
      private bool[] T002D4_n1056WebServiceCertificadoPass ;
      private string[] T002D4_A1059WebServiceClientid ;
      private bool[] T002D4_n1059WebServiceClientid ;
      private string[] T002D4_A1060WebServiceClientSecret ;
      private bool[] T002D4_n1060WebServiceClientSecret ;
      private int[] T002D5_A656WebServiceId ;
      private int[] T002D3_A656WebServiceId ;
      private string[] T002D3_A657WebServiceTipoDmWS ;
      private bool[] T002D3_n657WebServiceTipoDmWS ;
      private string[] T002D3_A658WebServiceEndPoint ;
      private bool[] T002D3_n658WebServiceEndPoint ;
      private string[] T002D3_A659WebServiceAuthTipo ;
      private bool[] T002D3_n659WebServiceAuthTipo ;
      private string[] T002D3_A660WebServiceUsuario ;
      private bool[] T002D3_n660WebServiceUsuario ;
      private string[] T002D3_A661WebServiceSenha ;
      private bool[] T002D3_n661WebServiceSenha ;
      private string[] T002D3_A1054WebServiceSalt ;
      private bool[] T002D3_n1054WebServiceSalt ;
      private string[] T002D3_A1055WebServiceCertificadoBase64 ;
      private bool[] T002D3_n1055WebServiceCertificadoBase64 ;
      private string[] T002D3_A1056WebServiceCertificadoPass ;
      private bool[] T002D3_n1056WebServiceCertificadoPass ;
      private string[] T002D3_A1059WebServiceClientid ;
      private bool[] T002D3_n1059WebServiceClientid ;
      private string[] T002D3_A1060WebServiceClientSecret ;
      private bool[] T002D3_n1060WebServiceClientSecret ;
      private int[] T002D6_A656WebServiceId ;
      private int[] T002D7_A656WebServiceId ;
      private int[] T002D2_A656WebServiceId ;
      private string[] T002D2_A657WebServiceTipoDmWS ;
      private bool[] T002D2_n657WebServiceTipoDmWS ;
      private string[] T002D2_A658WebServiceEndPoint ;
      private bool[] T002D2_n658WebServiceEndPoint ;
      private string[] T002D2_A659WebServiceAuthTipo ;
      private bool[] T002D2_n659WebServiceAuthTipo ;
      private string[] T002D2_A660WebServiceUsuario ;
      private bool[] T002D2_n660WebServiceUsuario ;
      private string[] T002D2_A661WebServiceSenha ;
      private bool[] T002D2_n661WebServiceSenha ;
      private string[] T002D2_A1054WebServiceSalt ;
      private bool[] T002D2_n1054WebServiceSalt ;
      private string[] T002D2_A1055WebServiceCertificadoBase64 ;
      private bool[] T002D2_n1055WebServiceCertificadoBase64 ;
      private string[] T002D2_A1056WebServiceCertificadoPass ;
      private bool[] T002D2_n1056WebServiceCertificadoPass ;
      private string[] T002D2_A1059WebServiceClientid ;
      private bool[] T002D2_n1059WebServiceClientid ;
      private string[] T002D2_A1060WebServiceClientSecret ;
      private bool[] T002D2_n1060WebServiceClientSecret ;
      private int[] T002D9_A656WebServiceId ;
      private int[] T002D12_A656WebServiceId ;
   }

   public class webservice__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002D2;
          prmT002D2 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D3;
          prmT002D3 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D4;
          prmT002D4 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D5;
          prmT002D5 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D6;
          prmT002D6 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D7;
          prmT002D7 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D8;
          prmT002D8 = new Object[] {
          new ParDef("WebServiceTipoDmWS",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceEndPoint",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceAuthTipo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceUsuario",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSenha",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSalt",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoBase64",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoPass",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientid",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientSecret",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          Object[] prmT002D9;
          prmT002D9 = new Object[] {
          };
          Object[] prmT002D10;
          prmT002D10 = new Object[] {
          new ParDef("WebServiceTipoDmWS",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceEndPoint",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceAuthTipo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceUsuario",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSenha",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSalt",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoBase64",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoPass",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientid",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientSecret",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D11;
          prmT002D11 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D12;
          prmT002D12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002D2", "SELECT WebServiceId, WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha, WebServiceSalt, WebServiceCertificadoBase64, WebServiceCertificadoPass, WebServiceClientid, WebServiceClientSecret FROM WebService WHERE WebServiceId = :WebServiceId  FOR UPDATE OF WebService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D3", "SELECT WebServiceId, WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha, WebServiceSalt, WebServiceCertificadoBase64, WebServiceCertificadoPass, WebServiceClientid, WebServiceClientSecret FROM WebService WHERE WebServiceId = :WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D4", "SELECT TM1.WebServiceId, TM1.WebServiceTipoDmWS, TM1.WebServiceEndPoint, TM1.WebServiceAuthTipo, TM1.WebServiceUsuario, TM1.WebServiceSenha, TM1.WebServiceSalt, TM1.WebServiceCertificadoBase64, TM1.WebServiceCertificadoPass, TM1.WebServiceClientid, TM1.WebServiceClientSecret FROM WebService TM1 WHERE TM1.WebServiceId = :WebServiceId ORDER BY TM1.WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D5", "SELECT WebServiceId FROM WebService WHERE WebServiceId = :WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D6", "SELECT WebServiceId FROM WebService WHERE ( WebServiceId > :WebServiceId) ORDER BY WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002D7", "SELECT WebServiceId FROM WebService WHERE ( WebServiceId < :WebServiceId) ORDER BY WebServiceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002D8", "SAVEPOINT gxupdate;INSERT INTO WebService(WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha, WebServiceSalt, WebServiceCertificadoBase64, WebServiceCertificadoPass, WebServiceClientid, WebServiceClientSecret) VALUES(:WebServiceTipoDmWS, :WebServiceEndPoint, :WebServiceAuthTipo, :WebServiceUsuario, :WebServiceSenha, :WebServiceSalt, :WebServiceCertificadoBase64, :WebServiceCertificadoPass, :WebServiceClientid, :WebServiceClientSecret);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002D8)
             ,new CursorDef("T002D9", "SELECT currval('WebServiceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D10", "SAVEPOINT gxupdate;UPDATE WebService SET WebServiceTipoDmWS=:WebServiceTipoDmWS, WebServiceEndPoint=:WebServiceEndPoint, WebServiceAuthTipo=:WebServiceAuthTipo, WebServiceUsuario=:WebServiceUsuario, WebServiceSenha=:WebServiceSenha, WebServiceSalt=:WebServiceSalt, WebServiceCertificadoBase64=:WebServiceCertificadoBase64, WebServiceCertificadoPass=:WebServiceCertificadoPass, WebServiceClientid=:WebServiceClientid, WebServiceClientSecret=:WebServiceClientSecret  WHERE WebServiceId = :WebServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002D10)
             ,new CursorDef("T002D11", "SAVEPOINT gxupdate;DELETE FROM WebService  WHERE WebServiceId = :WebServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002D11)
             ,new CursorDef("T002D12", "SELECT WebServiceId FROM WebService ORDER BY WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
