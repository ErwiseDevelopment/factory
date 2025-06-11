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
   public class carteiradecobranca : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A1069CarteiraDeCobrancaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "carteiradecobranca")), "carteiradecobranca") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "carteiradecobranca")))) ;
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
                  AV7CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV7CarteiraDeCobrancaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Carteira De Cobranca", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public carteiradecobranca( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiradecobranca( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CarteiraDeCobrancaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CarteiraDeCobrancaId = aP1_CarteiraDeCobrancaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCarteiraDeCobrancaStatus = new GXCombobox();
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
         if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
         {
            A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.getValidValue(StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
            n1074CarteiraDeCobrancaStatus = false;
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
            AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Values", cmbCarteiraDeCobrancaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaNome_Internalname, A1071CarteiraDeCobrancaNome, StringUtil.RTrim( context.localUtil.Format( A1071CarteiraDeCobrancaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraDeCobranca.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaConvenio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaConvenio_Internalname, "Convênio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaConvenio_Internalname, A1073CarteiraDeCobrancaConvenio, StringUtil.RTrim( context.localUtil.Format( A1073CarteiraDeCobrancaConvenio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaConvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaConvenio_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraDeCobranca.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCarteiraDeCobrancaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCarteiraDeCobrancaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCarteiraDeCobrancaStatus, cmbCarteiraDeCobrancaStatus_Internalname, StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus), 1, cmbCarteiraDeCobrancaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbCarteiraDeCobrancaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_CarteiraDeCobranca.htm");
         cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Values", (string)(cmbCarteiraDeCobrancaStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarteiraDeCobranca.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarteiraDeCobranca.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarteiraDeCobranca.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaId_Jsonclick, 0, "Attribute", "", "", "", "", edtCarteiraDeCobrancaId_Visible, edtCarteiraDeCobrancaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CarteiraDeCobranca.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaCodigo_Internalname, A1070CarteiraDeCobrancaCodigo, StringUtil.RTrim( context.localUtil.Format( A1070CarteiraDeCobrancaCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaCodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtCarteiraDeCobrancaCodigo_Visible, edtCarteiraDeCobrancaCodigo_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraDeCobranca.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaWorkspaceId_Internalname, A1072CarteiraDeCobrancaWorkspaceId.ToString(), A1072CarteiraDeCobrancaWorkspaceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaWorkspaceId_Jsonclick, 0, "Attribute", "", "", "", "", edtCarteiraDeCobrancaWorkspaceId_Visible, edtCarteiraDeCobrancaWorkspaceId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_CarteiraDeCobranca.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCarteiraDeCobrancaCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaCreatedAt_Internalname, context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1075CarteiraDeCobrancaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtCarteiraDeCobrancaCreatedAt_Visible, edtCarteiraDeCobrancaCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraDeCobranca.htm");
         GxWebStd.gx_bitmap( context, edtCarteiraDeCobrancaCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCarteiraDeCobrancaCreatedAt_Visible==0)||(edtCarteiraDeCobrancaCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarteiraDeCobranca.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCarteiraDeCobrancaUpdatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaUpdatedAt_Internalname, context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1076CarteiraDeCobrancaUpdatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaUpdatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtCarteiraDeCobrancaUpdatedAt_Visible, edtCarteiraDeCobrancaUpdatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraDeCobranca.htm");
         GxWebStd.gx_bitmap( context, edtCarteiraDeCobrancaUpdatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCarteiraDeCobrancaUpdatedAt_Visible==0)||(edtCarteiraDeCobrancaUpdatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarteiraDeCobranca.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         E11362 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1069CarteiraDeCobrancaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z1075CarteiraDeCobrancaCreatedAt = context.localUtil.CToT( cgiGet( "Z1075CarteiraDeCobrancaCreatedAt"), 0);
               n1075CarteiraDeCobrancaCreatedAt = ((DateTime.MinValue==A1075CarteiraDeCobrancaCreatedAt) ? true : false);
               Z1076CarteiraDeCobrancaUpdatedAt = context.localUtil.CToT( cgiGet( "Z1076CarteiraDeCobrancaUpdatedAt"), 0);
               n1076CarteiraDeCobrancaUpdatedAt = ((DateTime.MinValue==A1076CarteiraDeCobrancaUpdatedAt) ? true : false);
               Z1070CarteiraDeCobrancaCodigo = cgiGet( "Z1070CarteiraDeCobrancaCodigo");
               n1070CarteiraDeCobrancaCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A1070CarteiraDeCobrancaCodigo)) ? true : false);
               Z1071CarteiraDeCobrancaNome = cgiGet( "Z1071CarteiraDeCobrancaNome");
               n1071CarteiraDeCobrancaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1071CarteiraDeCobrancaNome)) ? true : false);
               Z1072CarteiraDeCobrancaWorkspaceId = StringUtil.StrToGuid( cgiGet( "Z1072CarteiraDeCobrancaWorkspaceId"));
               n1072CarteiraDeCobrancaWorkspaceId = ((Guid.Empty==A1072CarteiraDeCobrancaWorkspaceId) ? true : false);
               Z1073CarteiraDeCobrancaConvenio = cgiGet( "Z1073CarteiraDeCobrancaConvenio");
               n1073CarteiraDeCobrancaConvenio = (String.IsNullOrEmpty(StringUtil.RTrim( A1073CarteiraDeCobrancaConvenio)) ? true : false);
               Z1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cgiGet( "Z1074CarteiraDeCobrancaStatus"));
               n1074CarteiraDeCobrancaStatus = ((false==A1074CarteiraDeCobrancaStatus) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCARTEIRADECOBRANCAID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A1111CarteiraDeCobrancaValorTotal = context.localUtil.CToN( cgiGet( "CARTEIRADECOBRANCAVALORTOTAL"), ",", ".");
               A1112CarteiraDeCobrancaValorRecebido = context.localUtil.CToN( cgiGet( "CARTEIRADECOBRANCAVALORRECEBIDO"), ",", ".");
               A1113CarteiraDeCobrancaTotalBoletos = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARTEIRADECOBRANCATOTALBOLETOS"), ",", "."), 18, MidpointRounding.ToEven));
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS"), ",", "."), 18, MidpointRounding.ToEven));
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
               A1115CarteiraDeCobrancaTotalBoletosExpirados = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS"), ",", "."), 18, MidpointRounding.ToEven));
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
               A1116CarteiraDeCobrancaTotalBoletosCancelados = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS"), ",", "."), 18, MidpointRounding.ToEven));
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
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
               A1071CarteiraDeCobrancaNome = cgiGet( edtCarteiraDeCobrancaNome_Internalname);
               n1071CarteiraDeCobrancaNome = false;
               AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
               n1071CarteiraDeCobrancaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1071CarteiraDeCobrancaNome)) ? true : false);
               A1073CarteiraDeCobrancaConvenio = cgiGet( edtCarteiraDeCobrancaConvenio_Internalname);
               n1073CarteiraDeCobrancaConvenio = false;
               AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
               n1073CarteiraDeCobrancaConvenio = (String.IsNullOrEmpty(StringUtil.RTrim( A1073CarteiraDeCobrancaConvenio)) ? true : false);
               cmbCarteiraDeCobrancaStatus.CurrentValue = cgiGet( cmbCarteiraDeCobrancaStatus_Internalname);
               A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cgiGet( cmbCarteiraDeCobrancaStatus_Internalname));
               n1074CarteiraDeCobrancaStatus = false;
               AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
               n1074CarteiraDeCobrancaStatus = ((false==A1074CarteiraDeCobrancaStatus) ? true : false);
               A1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1069CarteiraDeCobrancaId = false;
               AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
               A1070CarteiraDeCobrancaCodigo = cgiGet( edtCarteiraDeCobrancaCodigo_Internalname);
               n1070CarteiraDeCobrancaCodigo = false;
               AssignAttri("", false, "A1070CarteiraDeCobrancaCodigo", A1070CarteiraDeCobrancaCodigo);
               n1070CarteiraDeCobrancaCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A1070CarteiraDeCobrancaCodigo)) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtCarteiraDeCobrancaWorkspaceId_Internalname), "") == 0 )
               {
                  A1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
                  n1072CarteiraDeCobrancaWorkspaceId = true;
                  AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
               }
               else
               {
                  try
                  {
                     A1072CarteiraDeCobrancaWorkspaceId = StringUtil.StrToGuid( cgiGet( edtCarteiraDeCobrancaWorkspaceId_Internalname));
                     n1072CarteiraDeCobrancaWorkspaceId = false;
                     AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "CARTEIRADECOBRANCAWORKSPACEID");
                     AnyError = 1;
                     GX_FocusControl = edtCarteiraDeCobrancaWorkspaceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n1072CarteiraDeCobrancaWorkspaceId = ((Guid.Empty==A1072CarteiraDeCobrancaWorkspaceId) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtCarteiraDeCobrancaCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Carteira De Cobranca Created At"}), 1, "CARTEIRADECOBRANCACREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtCarteiraDeCobrancaCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
                  n1075CarteiraDeCobrancaCreatedAt = false;
                  AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1075CarteiraDeCobrancaCreatedAt = context.localUtil.CToT( cgiGet( edtCarteiraDeCobrancaCreatedAt_Internalname));
                  n1075CarteiraDeCobrancaCreatedAt = false;
                  AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n1075CarteiraDeCobrancaCreatedAt = ((DateTime.MinValue==A1075CarteiraDeCobrancaCreatedAt) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtCarteiraDeCobrancaUpdatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Carteira De Cobranca Updated At"}), 1, "CARTEIRADECOBRANCAUPDATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtCarteiraDeCobrancaUpdatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
                  n1076CarteiraDeCobrancaUpdatedAt = false;
                  AssignAttri("", false, "A1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1076CarteiraDeCobrancaUpdatedAt = context.localUtil.CToT( cgiGet( edtCarteiraDeCobrancaUpdatedAt_Internalname));
                  n1076CarteiraDeCobrancaUpdatedAt = false;
                  AssignAttri("", false, "A1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n1076CarteiraDeCobrancaUpdatedAt = ((DateTime.MinValue==A1076CarteiraDeCobrancaUpdatedAt) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CarteiraDeCobranca");
               A1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1069CarteiraDeCobrancaId = false;
               AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
               forbiddenHiddens.Add("CarteiraDeCobrancaId", context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("carteiradecobranca:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               forbiddenHiddens2 = new GXProperties();
               if ( IsIns( )  )
               {
                  A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cgiGet( cmbCarteiraDeCobrancaStatus_Internalname));
                  n1074CarteiraDeCobrancaStatus = false;
                  AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
                  forbiddenHiddens2.Add("CarteiraDeCobrancaStatus", StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus));
               }
               hsh2 = cgiGet( "hsh2");
               if ( ( ! ( ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens2.ToString(), hsh2, GXKey) )
               {
                  GXUtil.WriteLogError("carteiradecobranca:[ CondSecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens2.ToJSonString());
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
                  A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
                  n1069CarteiraDeCobrancaId = false;
                  AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
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
                     sMode110 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode110;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound110 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_360( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CARTEIRADECOBRANCAID");
                        AnyError = 1;
                        GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
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
                           E11362 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12362 ();
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
            E12362 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll36110( ) ;
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
            DisableAttributes36110( ) ;
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

      protected void CONFIRM_360( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls36110( ) ;
            }
            else
            {
               CheckExtendedTable36110( ) ;
               CloseExtendedTableCursors36110( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption360( )
      {
      }

      protected void E11362( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtCarteiraDeCobrancaId_Visible = 0;
         AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Visible), 5, 0), true);
         edtCarteiraDeCobrancaCodigo_Visible = 0;
         AssignProp("", false, edtCarteiraDeCobrancaCodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaCodigo_Visible), 5, 0), true);
         edtCarteiraDeCobrancaWorkspaceId_Visible = 0;
         AssignProp("", false, edtCarteiraDeCobrancaWorkspaceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaWorkspaceId_Visible), 5, 0), true);
         edtCarteiraDeCobrancaCreatedAt_Visible = 0;
         AssignProp("", false, edtCarteiraDeCobrancaCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaCreatedAt_Visible), 5, 0), true);
         edtCarteiraDeCobrancaUpdatedAt_Visible = 0;
         AssignProp("", false, edtCarteiraDeCobrancaUpdatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaUpdatedAt_Visible), 5, 0), true);
      }

      protected void E12362( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("carteiradecobrancaww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM36110( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1075CarteiraDeCobrancaCreatedAt = T00363_A1075CarteiraDeCobrancaCreatedAt[0];
               Z1076CarteiraDeCobrancaUpdatedAt = T00363_A1076CarteiraDeCobrancaUpdatedAt[0];
               Z1070CarteiraDeCobrancaCodigo = T00363_A1070CarteiraDeCobrancaCodigo[0];
               Z1071CarteiraDeCobrancaNome = T00363_A1071CarteiraDeCobrancaNome[0];
               Z1072CarteiraDeCobrancaWorkspaceId = T00363_A1072CarteiraDeCobrancaWorkspaceId[0];
               Z1073CarteiraDeCobrancaConvenio = T00363_A1073CarteiraDeCobrancaConvenio[0];
               Z1074CarteiraDeCobrancaStatus = T00363_A1074CarteiraDeCobrancaStatus[0];
            }
            else
            {
               Z1075CarteiraDeCobrancaCreatedAt = A1075CarteiraDeCobrancaCreatedAt;
               Z1076CarteiraDeCobrancaUpdatedAt = A1076CarteiraDeCobrancaUpdatedAt;
               Z1070CarteiraDeCobrancaCodigo = A1070CarteiraDeCobrancaCodigo;
               Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
               Z1072CarteiraDeCobrancaWorkspaceId = A1072CarteiraDeCobrancaWorkspaceId;
               Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
               Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            }
         }
         if ( GX_JID == -12 )
         {
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            Z1075CarteiraDeCobrancaCreatedAt = A1075CarteiraDeCobrancaCreatedAt;
            Z1076CarteiraDeCobrancaUpdatedAt = A1076CarteiraDeCobrancaUpdatedAt;
            Z1070CarteiraDeCobrancaCodigo = A1070CarteiraDeCobrancaCodigo;
            Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
            Z1072CarteiraDeCobrancaWorkspaceId = A1072CarteiraDeCobrancaWorkspaceId;
            Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
            Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCarteiraDeCobrancaId_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCarteiraDeCobrancaId_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CarteiraDeCobrancaId) )
         {
            A1069CarteiraDeCobrancaId = AV7CarteiraDeCobrancaId;
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1075CarteiraDeCobrancaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1075CarteiraDeCobrancaCreatedAt = false;
            AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A1076CarteiraDeCobrancaUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1076CarteiraDeCobrancaUpdatedAt = false;
            AssignAttri("", false, "A1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
         {
            cmbCarteiraDeCobrancaStatus.Enabled = 0;
            AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCarteiraDeCobrancaStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbCarteiraDeCobrancaStatus.Enabled = 1;
            AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCarteiraDeCobrancaStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbCarteiraDeCobrancaStatus.Enabled = 0;
            AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCarteiraDeCobrancaStatus.Enabled), 5, 0), true);
         }
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
         if ( IsIns( )  && (Guid.Empty==A1072CarteiraDeCobrancaWorkspaceId) && ( Gx_BScreen == 0 ) )
         {
            A1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
            n1072CarteiraDeCobrancaWorkspaceId = false;
            AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
         }
         if ( IsIns( )  && (false==A1074CarteiraDeCobrancaStatus) && ( Gx_BScreen == 0 ) )
         {
            A1074CarteiraDeCobrancaStatus = true;
            n1074CarteiraDeCobrancaStatus = false;
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00365 */
            pr_default.execute(2, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A1111CarteiraDeCobrancaValorTotal = T00365_A1111CarteiraDeCobrancaValorTotal[0];
               A1112CarteiraDeCobrancaValorRecebido = T00365_A1112CarteiraDeCobrancaValorRecebido[0];
               A1113CarteiraDeCobrancaTotalBoletos = T00365_A1113CarteiraDeCobrancaTotalBoletos[0];
            }
            else
            {
               A1111CarteiraDeCobrancaValorTotal = 0;
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1112CarteiraDeCobrancaValorRecebido = 0;
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = 0;
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            pr_default.close(2);
            /* Using cursor T00367 */
            pr_default.execute(3, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(3) != 101) )
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = T00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = T00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            }
            else
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            pr_default.close(3);
            /* Using cursor T00369 */
            pr_default.execute(4, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = T00369_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               n1115CarteiraDeCobrancaTotalBoletosExpirados = T00369_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            }
            else
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            pr_default.close(4);
            /* Using cursor T003611 */
            pr_default.execute(5, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = T003611_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               n1116CarteiraDeCobrancaTotalBoletosCancelados = T003611_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            }
            else
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            pr_default.close(5);
         }
      }

      protected void Load36110( )
      {
         /* Using cursor T003616 */
         pr_default.execute(6, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound110 = 1;
            A1075CarteiraDeCobrancaCreatedAt = T003616_A1075CarteiraDeCobrancaCreatedAt[0];
            n1075CarteiraDeCobrancaCreatedAt = T003616_n1075CarteiraDeCobrancaCreatedAt[0];
            AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1076CarteiraDeCobrancaUpdatedAt = T003616_A1076CarteiraDeCobrancaUpdatedAt[0];
            n1076CarteiraDeCobrancaUpdatedAt = T003616_n1076CarteiraDeCobrancaUpdatedAt[0];
            AssignAttri("", false, "A1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1070CarteiraDeCobrancaCodigo = T003616_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = T003616_n1070CarteiraDeCobrancaCodigo[0];
            AssignAttri("", false, "A1070CarteiraDeCobrancaCodigo", A1070CarteiraDeCobrancaCodigo);
            A1071CarteiraDeCobrancaNome = T003616_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = T003616_n1071CarteiraDeCobrancaNome[0];
            AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
            A1072CarteiraDeCobrancaWorkspaceId = T003616_A1072CarteiraDeCobrancaWorkspaceId[0];
            n1072CarteiraDeCobrancaWorkspaceId = T003616_n1072CarteiraDeCobrancaWorkspaceId[0];
            AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
            A1073CarteiraDeCobrancaConvenio = T003616_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = T003616_n1073CarteiraDeCobrancaConvenio[0];
            AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
            A1074CarteiraDeCobrancaStatus = T003616_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = T003616_n1074CarteiraDeCobrancaStatus[0];
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
            A1111CarteiraDeCobrancaValorTotal = T003616_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = T003616_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = T003616_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003616_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003616_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003616_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003616_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            ZM36110( -12) ;
         }
         pr_default.close(6);
         OnLoadActions36110( ) ;
      }

      protected void OnLoadActions36110( )
      {
      }

      protected void CheckExtendedTable36110( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00365 */
         pr_default.execute(2, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A1111CarteiraDeCobrancaValorTotal = T00365_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = T00365_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = T00365_A1113CarteiraDeCobrancaTotalBoletos[0];
         }
         else
         {
            A1111CarteiraDeCobrancaValorTotal = 0;
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1112CarteiraDeCobrancaValorRecebido = 0;
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = 0;
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         }
         pr_default.close(2);
         if ( ( A1111CarteiraDeCobrancaValorTotal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1112CarteiraDeCobrancaValorRecebido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T00367 */
         pr_default.execute(3, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         }
         pr_default.close(3);
         /* Using cursor T00369 */
         pr_default.execute(4, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T00369_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T00369_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         }
         pr_default.close(4);
         /* Using cursor T003611 */
         pr_default.execute(5, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003611_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003611_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors36110( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003618 */
         pr_default.execute(7, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A1111CarteiraDeCobrancaValorTotal = T003618_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = T003618_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = T003618_A1113CarteiraDeCobrancaTotalBoletos[0];
         }
         else
         {
            A1111CarteiraDeCobrancaValorTotal = 0;
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1112CarteiraDeCobrancaValorRecebido = 0;
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = 0;
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1111CarteiraDeCobrancaValorTotal, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1112CarteiraDeCobrancaValorRecebido, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_14( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003620 */
         pr_default.execute(8, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003620_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003620_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_15( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003622 */
         pr_default.execute(9, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003622_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003622_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_16( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003624 */
         pr_default.execute(10, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003624_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003624_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey36110( )
      {
         /* Using cursor T003625 */
         pr_default.execute(11, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound110 = 1;
         }
         else
         {
            RcdFound110 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00363 */
         pr_default.execute(1, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM36110( 12) ;
            RcdFound110 = 1;
            A1069CarteiraDeCobrancaId = T00363_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = T00363_n1069CarteiraDeCobrancaId[0];
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
            A1075CarteiraDeCobrancaCreatedAt = T00363_A1075CarteiraDeCobrancaCreatedAt[0];
            n1075CarteiraDeCobrancaCreatedAt = T00363_n1075CarteiraDeCobrancaCreatedAt[0];
            AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1076CarteiraDeCobrancaUpdatedAt = T00363_A1076CarteiraDeCobrancaUpdatedAt[0];
            n1076CarteiraDeCobrancaUpdatedAt = T00363_n1076CarteiraDeCobrancaUpdatedAt[0];
            AssignAttri("", false, "A1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1070CarteiraDeCobrancaCodigo = T00363_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = T00363_n1070CarteiraDeCobrancaCodigo[0];
            AssignAttri("", false, "A1070CarteiraDeCobrancaCodigo", A1070CarteiraDeCobrancaCodigo);
            A1071CarteiraDeCobrancaNome = T00363_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = T00363_n1071CarteiraDeCobrancaNome[0];
            AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
            A1072CarteiraDeCobrancaWorkspaceId = T00363_A1072CarteiraDeCobrancaWorkspaceId[0];
            n1072CarteiraDeCobrancaWorkspaceId = T00363_n1072CarteiraDeCobrancaWorkspaceId[0];
            AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
            A1073CarteiraDeCobrancaConvenio = T00363_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = T00363_n1073CarteiraDeCobrancaConvenio[0];
            AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
            A1074CarteiraDeCobrancaStatus = T00363_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = T00363_n1074CarteiraDeCobrancaStatus[0];
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load36110( ) ;
            if ( AnyError == 1 )
            {
               RcdFound110 = 0;
               InitializeNonKey36110( ) ;
            }
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound110 = 0;
            InitializeNonKey36110( ) ;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey36110( ) ;
         if ( RcdFound110 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound110 = 0;
         /* Using cursor T003626 */
         pr_default.execute(12, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T003626_A1069CarteiraDeCobrancaId[0] < A1069CarteiraDeCobrancaId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T003626_A1069CarteiraDeCobrancaId[0] > A1069CarteiraDeCobrancaId ) ) )
            {
               A1069CarteiraDeCobrancaId = T003626_A1069CarteiraDeCobrancaId[0];
               n1069CarteiraDeCobrancaId = T003626_n1069CarteiraDeCobrancaId[0];
               AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
               RcdFound110 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound110 = 0;
         /* Using cursor T003627 */
         pr_default.execute(13, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T003627_A1069CarteiraDeCobrancaId[0] > A1069CarteiraDeCobrancaId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T003627_A1069CarteiraDeCobrancaId[0] < A1069CarteiraDeCobrancaId ) ) )
            {
               A1069CarteiraDeCobrancaId = T003627_A1069CarteiraDeCobrancaId[0];
               n1069CarteiraDeCobrancaId = T003627_n1069CarteiraDeCobrancaId[0];
               AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
               RcdFound110 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey36110( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert36110( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound110 == 1 )
            {
               if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
               {
                  A1069CarteiraDeCobrancaId = Z1069CarteiraDeCobrancaId;
                  n1069CarteiraDeCobrancaId = false;
                  AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CARTEIRADECOBRANCAID");
                  AnyError = 1;
                  GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update36110( ) ;
                  GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert36110( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CARTEIRADECOBRANCAID");
                     AnyError = 1;
                     GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert36110( ) ;
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
         if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
         {
            A1069CarteiraDeCobrancaId = Z1069CarteiraDeCobrancaId;
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CARTEIRADECOBRANCAID");
            AnyError = 1;
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCarteiraDeCobrancaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency36110( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00362 */
            pr_default.execute(0, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarteiraDeCobranca"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1075CarteiraDeCobrancaCreatedAt != T00362_A1075CarteiraDeCobrancaCreatedAt[0] ) || ( Z1076CarteiraDeCobrancaUpdatedAt != T00362_A1076CarteiraDeCobrancaUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1070CarteiraDeCobrancaCodigo, T00362_A1070CarteiraDeCobrancaCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z1071CarteiraDeCobrancaNome, T00362_A1071CarteiraDeCobrancaNome[0]) != 0 ) || ( Z1072CarteiraDeCobrancaWorkspaceId != T00362_A1072CarteiraDeCobrancaWorkspaceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1073CarteiraDeCobrancaConvenio, T00362_A1073CarteiraDeCobrancaConvenio[0]) != 0 ) || ( Z1074CarteiraDeCobrancaStatus != T00362_A1074CarteiraDeCobrancaStatus[0] ) )
            {
               if ( Z1075CarteiraDeCobrancaCreatedAt != T00362_A1075CarteiraDeCobrancaCreatedAt[0] )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1075CarteiraDeCobrancaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1075CarteiraDeCobrancaCreatedAt[0]);
               }
               if ( Z1076CarteiraDeCobrancaUpdatedAt != T00362_A1076CarteiraDeCobrancaUpdatedAt[0] )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1076CarteiraDeCobrancaUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1076CarteiraDeCobrancaUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z1070CarteiraDeCobrancaCodigo, T00362_A1070CarteiraDeCobrancaCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z1070CarteiraDeCobrancaCodigo);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1070CarteiraDeCobrancaCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z1071CarteiraDeCobrancaNome, T00362_A1071CarteiraDeCobrancaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaNome");
                  GXUtil.WriteLogRaw("Old: ",Z1071CarteiraDeCobrancaNome);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1071CarteiraDeCobrancaNome[0]);
               }
               if ( Z1072CarteiraDeCobrancaWorkspaceId != T00362_A1072CarteiraDeCobrancaWorkspaceId[0] )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaWorkspaceId");
                  GXUtil.WriteLogRaw("Old: ",Z1072CarteiraDeCobrancaWorkspaceId);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1072CarteiraDeCobrancaWorkspaceId[0]);
               }
               if ( StringUtil.StrCmp(Z1073CarteiraDeCobrancaConvenio, T00362_A1073CarteiraDeCobrancaConvenio[0]) != 0 )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaConvenio");
                  GXUtil.WriteLogRaw("Old: ",Z1073CarteiraDeCobrancaConvenio);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1073CarteiraDeCobrancaConvenio[0]);
               }
               if ( Z1074CarteiraDeCobrancaStatus != T00362_A1074CarteiraDeCobrancaStatus[0] )
               {
                  GXUtil.WriteLog("carteiradecobranca:[seudo value changed for attri]"+"CarteiraDeCobrancaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z1074CarteiraDeCobrancaStatus);
                  GXUtil.WriteLogRaw("Current: ",T00362_A1074CarteiraDeCobrancaStatus[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarteiraDeCobranca"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert36110( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable36110( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM36110( 0) ;
            CheckOptimisticConcurrency36110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm36110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert36110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003628 */
                     pr_default.execute(14, new Object[] {n1075CarteiraDeCobrancaCreatedAt, A1075CarteiraDeCobrancaCreatedAt, n1076CarteiraDeCobrancaUpdatedAt, A1076CarteiraDeCobrancaUpdatedAt, n1070CarteiraDeCobrancaCodigo, A1070CarteiraDeCobrancaCodigo, n1071CarteiraDeCobrancaNome, A1071CarteiraDeCobrancaNome, n1072CarteiraDeCobrancaWorkspaceId, A1072CarteiraDeCobrancaWorkspaceId, n1073CarteiraDeCobrancaConvenio, A1073CarteiraDeCobrancaConvenio, n1074CarteiraDeCobrancaStatus, A1074CarteiraDeCobrancaStatus});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003629 */
                     pr_default.execute(15);
                     A1069CarteiraDeCobrancaId = T003629_A1069CarteiraDeCobrancaId[0];
                     n1069CarteiraDeCobrancaId = T003629_n1069CarteiraDeCobrancaId[0];
                     AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("CarteiraDeCobranca");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption360( ) ;
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
               Load36110( ) ;
            }
            EndLevel36110( ) ;
         }
         CloseExtendedTableCursors36110( ) ;
      }

      protected void Update36110( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable36110( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency36110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm36110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate36110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003630 */
                     pr_default.execute(16, new Object[] {n1075CarteiraDeCobrancaCreatedAt, A1075CarteiraDeCobrancaCreatedAt, n1076CarteiraDeCobrancaUpdatedAt, A1076CarteiraDeCobrancaUpdatedAt, n1070CarteiraDeCobrancaCodigo, A1070CarteiraDeCobrancaCodigo, n1071CarteiraDeCobrancaNome, A1071CarteiraDeCobrancaNome, n1072CarteiraDeCobrancaWorkspaceId, A1072CarteiraDeCobrancaWorkspaceId, n1073CarteiraDeCobrancaConvenio, A1073CarteiraDeCobrancaConvenio, n1074CarteiraDeCobrancaStatus, A1074CarteiraDeCobrancaStatus, n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("CarteiraDeCobranca");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarteiraDeCobranca"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate36110( ) ;
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
            EndLevel36110( ) ;
         }
         CloseExtendedTableCursors36110( ) ;
      }

      protected void DeferredUpdate36110( )
      {
      }

      protected void delete( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency36110( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls36110( ) ;
            AfterConfirm36110( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete36110( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003631 */
                  pr_default.execute(17, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("CarteiraDeCobranca");
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
         sMode110 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel36110( ) ;
         Gx_mode = sMode110;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls36110( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003633 */
            pr_default.execute(18, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A1111CarteiraDeCobrancaValorTotal = T003633_A1111CarteiraDeCobrancaValorTotal[0];
               A1112CarteiraDeCobrancaValorRecebido = T003633_A1112CarteiraDeCobrancaValorRecebido[0];
               A1113CarteiraDeCobrancaTotalBoletos = T003633_A1113CarteiraDeCobrancaTotalBoletos[0];
            }
            else
            {
               A1111CarteiraDeCobrancaValorTotal = 0;
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1112CarteiraDeCobrancaValorRecebido = 0;
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = 0;
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            pr_default.close(18);
            /* Using cursor T003635 */
            pr_default.execute(19, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            }
            else
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            pr_default.close(19);
            /* Using cursor T003637 */
            pr_default.execute(20, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = T003637_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               n1115CarteiraDeCobrancaTotalBoletosExpirados = T003637_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            }
            else
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            pr_default.close(20);
            /* Using cursor T003639 */
            pr_default.execute(21, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = T003639_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               n1116CarteiraDeCobrancaTotalBoletosCancelados = T003639_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            }
            else
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003640 */
            pr_default.execute(22, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Boleto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel36110( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete36110( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("carteiradecobranca",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues360( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("carteiradecobranca",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart36110( )
      {
         /* Scan By routine */
         /* Using cursor T003641 */
         pr_default.execute(23);
         RcdFound110 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound110 = 1;
            A1069CarteiraDeCobrancaId = T003641_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = T003641_n1069CarteiraDeCobrancaId[0];
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext36110( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound110 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound110 = 1;
            A1069CarteiraDeCobrancaId = T003641_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = T003641_n1069CarteiraDeCobrancaId[0];
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
         }
      }

      protected void ScanEnd36110( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm36110( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert36110( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate36110( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete36110( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete36110( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate36110( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes36110( )
      {
         edtCarteiraDeCobrancaNome_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaNome_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaConvenio_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaConvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaConvenio_Enabled), 5, 0), true);
         cmbCarteiraDeCobrancaStatus.Enabled = 0;
         AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCarteiraDeCobrancaStatus.Enabled), 5, 0), true);
         edtCarteiraDeCobrancaId_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaCodigo_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaCodigo_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaWorkspaceId_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaWorkspaceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaWorkspaceId_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaCreatedAt_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaCreatedAt_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaUpdatedAt_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaUpdatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaUpdatedAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes36110( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues360( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
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
         GXEncryptionTmp = "carteiradecobranca"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CarteiraDeCobrancaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("carteiradecobranca") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CarteiraDeCobranca");
         forbiddenHiddens.Add("CarteiraDeCobrancaId", context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("carteiradecobranca:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         forbiddenHiddens2 = new GXProperties();
         if ( IsIns( )  )
         {
            forbiddenHiddens2.Add("CarteiraDeCobrancaStatus", StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus));
         }
         GxWebStd.gx_hidden_field( context, "hsh2", GetEncryptedHash( forbiddenHiddens2.ToString(), GXKey));
         GXUtil.WriteLogInfo("carteiradecobranca:[ SendCondSecurityCheck value for]"+forbiddenHiddens2.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1069CarteiraDeCobrancaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1069CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( Z1075CarteiraDeCobrancaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( Z1076CarteiraDeCobrancaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1070CarteiraDeCobrancaCodigo", Z1070CarteiraDeCobrancaCodigo);
         GxWebStd.gx_hidden_field( context, "Z1071CarteiraDeCobrancaNome", Z1071CarteiraDeCobrancaNome);
         GxWebStd.gx_hidden_field( context, "Z1072CarteiraDeCobrancaWorkspaceId", Z1072CarteiraDeCobrancaWorkspaceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z1073CarteiraDeCobrancaConvenio", Z1073CarteiraDeCobrancaConvenio);
         GxWebStd.gx_boolean_hidden_field( context, "Z1074CarteiraDeCobrancaStatus", Z1074CarteiraDeCobrancaStatus);
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
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCAVALORTOTAL", StringUtil.LTrim( StringUtil.NToC( A1111CarteiraDeCobrancaValorTotal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCAVALORRECEBIDO", StringUtil.LTrim( StringUtil.NToC( A1112CarteiraDeCobrancaValorRecebido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCATOTALBOLETOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ",", "")));
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
         GXEncryptionTmp = "carteiradecobranca"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CarteiraDeCobrancaId,9,0));
         return formatLink("carteiradecobranca") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "CarteiraDeCobranca" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carteira De Cobranca" ;
      }

      protected void InitializeNonKey36110( )
      {
         A1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         n1075CarteiraDeCobrancaCreatedAt = false;
         AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n1075CarteiraDeCobrancaCreatedAt = ((DateTime.MinValue==A1075CarteiraDeCobrancaCreatedAt) ? true : false);
         A1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         n1076CarteiraDeCobrancaUpdatedAt = false;
         AssignAttri("", false, "A1076CarteiraDeCobrancaUpdatedAt", context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         n1076CarteiraDeCobrancaUpdatedAt = ((DateTime.MinValue==A1076CarteiraDeCobrancaUpdatedAt) ? true : false);
         A1070CarteiraDeCobrancaCodigo = "";
         n1070CarteiraDeCobrancaCodigo = false;
         AssignAttri("", false, "A1070CarteiraDeCobrancaCodigo", A1070CarteiraDeCobrancaCodigo);
         n1070CarteiraDeCobrancaCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A1070CarteiraDeCobrancaCodigo)) ? true : false);
         A1071CarteiraDeCobrancaNome = "";
         n1071CarteiraDeCobrancaNome = false;
         AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
         n1071CarteiraDeCobrancaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1071CarteiraDeCobrancaNome)) ? true : false);
         A1073CarteiraDeCobrancaConvenio = "";
         n1073CarteiraDeCobrancaConvenio = false;
         AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
         n1073CarteiraDeCobrancaConvenio = (String.IsNullOrEmpty(StringUtil.RTrim( A1073CarteiraDeCobrancaConvenio)) ? true : false);
         A1111CarteiraDeCobrancaValorTotal = 0;
         AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
         A1112CarteiraDeCobrancaValorRecebido = 0;
         AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
         A1113CarteiraDeCobrancaTotalBoletos = 0;
         AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         A1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
         A1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         Z1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         Z1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1070CarteiraDeCobrancaCodigo = "";
         Z1071CarteiraDeCobrancaNome = "";
         Z1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         Z1073CarteiraDeCobrancaConvenio = "";
         Z1074CarteiraDeCobrancaStatus = false;
      }

      protected void InitAll36110( )
      {
         A1069CarteiraDeCobrancaId = 0;
         n1069CarteiraDeCobrancaId = false;
         AssignAttri("", false, "A1069CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
         InitializeNonKey36110( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1075CarteiraDeCobrancaCreatedAt = i1075CarteiraDeCobrancaCreatedAt;
         n1075CarteiraDeCobrancaCreatedAt = false;
         AssignAttri("", false, "A1075CarteiraDeCobrancaCreatedAt", context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1072CarteiraDeCobrancaWorkspaceId = i1072CarteiraDeCobrancaWorkspaceId;
         n1072CarteiraDeCobrancaWorkspaceId = false;
         AssignAttri("", false, "A1072CarteiraDeCobrancaWorkspaceId", A1072CarteiraDeCobrancaWorkspaceId.ToString());
         A1074CarteiraDeCobrancaStatus = i1074CarteiraDeCobrancaStatus;
         n1074CarteiraDeCobrancaStatus = false;
         AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101922186", true, true);
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
         context.AddJavascriptSource("carteiradecobranca.js", "?20256101922186", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCarteiraDeCobrancaNome_Internalname = "CARTEIRADECOBRANCANOME";
         edtCarteiraDeCobrancaConvenio_Internalname = "CARTEIRADECOBRANCACONVENIO";
         cmbCarteiraDeCobrancaStatus_Internalname = "CARTEIRADECOBRANCASTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID";
         edtCarteiraDeCobrancaCodigo_Internalname = "CARTEIRADECOBRANCACODIGO";
         edtCarteiraDeCobrancaWorkspaceId_Internalname = "CARTEIRADECOBRANCAWORKSPACEID";
         edtCarteiraDeCobrancaCreatedAt_Internalname = "CARTEIRADECOBRANCACREATEDAT";
         edtCarteiraDeCobrancaUpdatedAt_Internalname = "CARTEIRADECOBRANCAUPDATEDAT";
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
         Form.Caption = "Carteira De Cobranca";
         edtCarteiraDeCobrancaUpdatedAt_Jsonclick = "";
         edtCarteiraDeCobrancaUpdatedAt_Enabled = 1;
         edtCarteiraDeCobrancaUpdatedAt_Visible = 1;
         edtCarteiraDeCobrancaCreatedAt_Jsonclick = "";
         edtCarteiraDeCobrancaCreatedAt_Enabled = 1;
         edtCarteiraDeCobrancaCreatedAt_Visible = 1;
         edtCarteiraDeCobrancaWorkspaceId_Jsonclick = "";
         edtCarteiraDeCobrancaWorkspaceId_Enabled = 1;
         edtCarteiraDeCobrancaWorkspaceId_Visible = 1;
         edtCarteiraDeCobrancaCodigo_Jsonclick = "";
         edtCarteiraDeCobrancaCodigo_Enabled = 1;
         edtCarteiraDeCobrancaCodigo_Visible = 1;
         edtCarteiraDeCobrancaId_Jsonclick = "";
         edtCarteiraDeCobrancaId_Enabled = 0;
         edtCarteiraDeCobrancaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCarteiraDeCobrancaStatus_Jsonclick = "";
         cmbCarteiraDeCobrancaStatus.Enabled = 1;
         edtCarteiraDeCobrancaConvenio_Jsonclick = "";
         edtCarteiraDeCobrancaConvenio_Enabled = 1;
         edtCarteiraDeCobrancaNome_Jsonclick = "";
         edtCarteiraDeCobrancaNome_Enabled = 1;
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

      protected void init_web_controls( )
      {
         cmbCarteiraDeCobrancaStatus.Name = "CARTEIRADECOBRANCASTATUS";
         cmbCarteiraDeCobrancaStatus.WebTags = "";
         cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A1074CarteiraDeCobrancaStatus) )
            {
               A1074CarteiraDeCobrancaStatus = true;
               n1074CarteiraDeCobrancaStatus = false;
               AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
            }
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

      public void Valid_Carteiradecobrancaid( )
      {
         n1069CarteiraDeCobrancaId = false;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         /* Using cursor T003633 */
         pr_default.execute(18, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A1111CarteiraDeCobrancaValorTotal = T003633_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = T003633_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = T003633_A1113CarteiraDeCobrancaTotalBoletos[0];
         }
         else
         {
            A1111CarteiraDeCobrancaValorTotal = 0;
            A1112CarteiraDeCobrancaValorRecebido = 0;
            A1113CarteiraDeCobrancaTotalBoletos = 0;
         }
         pr_default.close(18);
         if ( ( A1111CarteiraDeCobrancaValorTotal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CARTEIRADECOBRANCAID");
            AnyError = 1;
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
         }
         if ( ( A1112CarteiraDeCobrancaValorRecebido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CARTEIRADECOBRANCAID");
            AnyError = 1;
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
         }
         /* Using cursor T003635 */
         pr_default.execute(19, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         }
         pr_default.close(19);
         /* Using cursor T003637 */
         pr_default.execute(20, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003637_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003637_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         }
         pr_default.close(20);
         /* Using cursor T003639 */
         pr_default.execute(21, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003639_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003639_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrim( StringUtil.NToC( A1111CarteiraDeCobrancaValorTotal, 18, 2, ".", "")));
         AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrim( StringUtil.NToC( A1112CarteiraDeCobrancaValorRecebido, 18, 2, ".", "")));
         AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0, ".", "")));
         AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ".", "")));
         AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ".", "")));
         AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1069CarteiraDeCobrancaId","fld":"CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12362","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAID","""{"handler":"Valid_Carteiradecobrancaid","iparms":[{"av":"A1069CarteiraDeCobrancaId","fld":"CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A1111CarteiraDeCobrancaValorTotal","fld":"CARTEIRADECOBRANCAVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1112CarteiraDeCobrancaValorRecebido","fld":"CARTEIRADECOBRANCAVALORRECEBIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1113CarteiraDeCobrancaTotalBoletos","fld":"CARTEIRADECOBRANCATOTALBOLETOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1114CarteiraDeCobrancaTotalBoletosRegistrados","fld":"CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1115CarteiraDeCobrancaTotalBoletosExpirados","fld":"CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1116CarteiraDeCobrancaTotalBoletosCancelados","fld":"CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS","pic":"ZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAID",""","oparms":[{"av":"A1111CarteiraDeCobrancaValorTotal","fld":"CARTEIRADECOBRANCAVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1112CarteiraDeCobrancaValorRecebido","fld":"CARTEIRADECOBRANCAVALORRECEBIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1113CarteiraDeCobrancaTotalBoletos","fld":"CARTEIRADECOBRANCATOTALBOLETOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1114CarteiraDeCobrancaTotalBoletosRegistrados","fld":"CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1115CarteiraDeCobrancaTotalBoletosExpirados","fld":"CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1116CarteiraDeCobrancaTotalBoletosCancelados","fld":"CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS","pic":"ZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAWORKSPACEID","""{"handler":"Valid_Carteiradecobrancaworkspaceid","iparms":[]}""");
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         Z1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1070CarteiraDeCobrancaCodigo = "";
         Z1071CarteiraDeCobrancaNome = "";
         Z1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         Z1073CarteiraDeCobrancaConvenio = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A1071CarteiraDeCobrancaNome = "";
         A1073CarteiraDeCobrancaConvenio = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1070CarteiraDeCobrancaCodigo = "";
         A1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         A1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         A1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         forbiddenHiddens2 = new GXProperties();
         hsh2 = "";
         sMode110 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00365_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T00365_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T00365_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T00369_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T00369_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003611_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003611_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003616_A1069CarteiraDeCobrancaId = new int[1] ;
         T003616_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T003616_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T003616_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         T003616_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T003616_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         T003616_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         T003616_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         T003616_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T003616_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T003616_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         T003616_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         T003616_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T003616_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T003616_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003616_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003616_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T003616_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T003616_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003616_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003616_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003616_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003616_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003618_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T003618_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T003618_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T003620_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T003620_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003622_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003622_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003624_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003624_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003625_A1069CarteiraDeCobrancaId = new int[1] ;
         T003625_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T00363_A1069CarteiraDeCobrancaId = new int[1] ;
         T00363_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T00363_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00363_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         T00363_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00363_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         T00363_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         T00363_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         T00363_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T00363_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T00363_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         T00363_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         T00363_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T00363_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T00363_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T00363_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003626_A1069CarteiraDeCobrancaId = new int[1] ;
         T003626_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T003627_A1069CarteiraDeCobrancaId = new int[1] ;
         T003627_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T00362_A1069CarteiraDeCobrancaId = new int[1] ;
         T00362_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T00362_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00362_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         T00362_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00362_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         T00362_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         T00362_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         T00362_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T00362_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T00362_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         T00362_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         T00362_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T00362_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T00362_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T00362_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003629_A1069CarteiraDeCobrancaId = new int[1] ;
         T003629_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T003633_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T003633_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T003633_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003637_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003637_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003639_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003639_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003640_A1077BoletosId = new int[1] ;
         T003641_A1069CarteiraDeCobrancaId = new int[1] ;
         T003641_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         i1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carteiradecobranca__default(),
            new Object[][] {
                new Object[] {
               T00362_A1069CarteiraDeCobrancaId, T00362_A1075CarteiraDeCobrancaCreatedAt, T00362_n1075CarteiraDeCobrancaCreatedAt, T00362_A1076CarteiraDeCobrancaUpdatedAt, T00362_n1076CarteiraDeCobrancaUpdatedAt, T00362_A1070CarteiraDeCobrancaCodigo, T00362_n1070CarteiraDeCobrancaCodigo, T00362_A1071CarteiraDeCobrancaNome, T00362_n1071CarteiraDeCobrancaNome, T00362_A1072CarteiraDeCobrancaWorkspaceId,
               T00362_n1072CarteiraDeCobrancaWorkspaceId, T00362_A1073CarteiraDeCobrancaConvenio, T00362_n1073CarteiraDeCobrancaConvenio, T00362_A1074CarteiraDeCobrancaStatus, T00362_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               T00363_A1069CarteiraDeCobrancaId, T00363_A1075CarteiraDeCobrancaCreatedAt, T00363_n1075CarteiraDeCobrancaCreatedAt, T00363_A1076CarteiraDeCobrancaUpdatedAt, T00363_n1076CarteiraDeCobrancaUpdatedAt, T00363_A1070CarteiraDeCobrancaCodigo, T00363_n1070CarteiraDeCobrancaCodigo, T00363_A1071CarteiraDeCobrancaNome, T00363_n1071CarteiraDeCobrancaNome, T00363_A1072CarteiraDeCobrancaWorkspaceId,
               T00363_n1072CarteiraDeCobrancaWorkspaceId, T00363_A1073CarteiraDeCobrancaConvenio, T00363_n1073CarteiraDeCobrancaConvenio, T00363_A1074CarteiraDeCobrancaStatus, T00363_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               T00365_A1111CarteiraDeCobrancaValorTotal, T00365_A1112CarteiraDeCobrancaValorRecebido, T00365_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               T00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               T00369_A1115CarteiraDeCobrancaTotalBoletosExpirados, T00369_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               T003611_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003611_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003616_A1069CarteiraDeCobrancaId, T003616_A1075CarteiraDeCobrancaCreatedAt, T003616_n1075CarteiraDeCobrancaCreatedAt, T003616_A1076CarteiraDeCobrancaUpdatedAt, T003616_n1076CarteiraDeCobrancaUpdatedAt, T003616_A1070CarteiraDeCobrancaCodigo, T003616_n1070CarteiraDeCobrancaCodigo, T003616_A1071CarteiraDeCobrancaNome, T003616_n1071CarteiraDeCobrancaNome, T003616_A1072CarteiraDeCobrancaWorkspaceId,
               T003616_n1072CarteiraDeCobrancaWorkspaceId, T003616_A1073CarteiraDeCobrancaConvenio, T003616_n1073CarteiraDeCobrancaConvenio, T003616_A1074CarteiraDeCobrancaStatus, T003616_n1074CarteiraDeCobrancaStatus, T003616_A1111CarteiraDeCobrancaValorTotal, T003616_A1112CarteiraDeCobrancaValorRecebido, T003616_A1113CarteiraDeCobrancaTotalBoletos, T003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados,
               T003616_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003616_n1115CarteiraDeCobrancaTotalBoletosExpirados, T003616_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003616_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003618_A1111CarteiraDeCobrancaValorTotal, T003618_A1112CarteiraDeCobrancaValorRecebido, T003618_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               T003620_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T003620_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               T003622_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003622_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               T003624_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003624_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003625_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               T003626_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               T003627_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               }
               , new Object[] {
               T003629_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003633_A1111CarteiraDeCobrancaValorTotal, T003633_A1112CarteiraDeCobrancaValorRecebido, T003633_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               T003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               T003637_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003637_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               T003639_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003639_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003640_A1077BoletosId
               }
               , new Object[] {
               T003641_A1069CarteiraDeCobrancaId
               }
            }
         );
         Z1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         A1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         i1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         Z1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         A1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         i1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound110 ;
      private short gxajaxcallmode ;
      private int wcpOAV7CarteiraDeCobrancaId ;
      private int Z1069CarteiraDeCobrancaId ;
      private int A1069CarteiraDeCobrancaId ;
      private int AV7CarteiraDeCobrancaId ;
      private int trnEnded ;
      private int edtCarteiraDeCobrancaNome_Enabled ;
      private int edtCarteiraDeCobrancaConvenio_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCarteiraDeCobrancaId_Enabled ;
      private int edtCarteiraDeCobrancaId_Visible ;
      private int edtCarteiraDeCobrancaCodigo_Visible ;
      private int edtCarteiraDeCobrancaCodigo_Enabled ;
      private int edtCarteiraDeCobrancaWorkspaceId_Visible ;
      private int edtCarteiraDeCobrancaWorkspaceId_Enabled ;
      private int edtCarteiraDeCobrancaCreatedAt_Visible ;
      private int edtCarteiraDeCobrancaCreatedAt_Enabled ;
      private int edtCarteiraDeCobrancaUpdatedAt_Visible ;
      private int edtCarteiraDeCobrancaUpdatedAt_Enabled ;
      private int A1113CarteiraDeCobrancaTotalBoletos ;
      private int A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Z1113CarteiraDeCobrancaTotalBoletos ;
      private int Z1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int Z1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int Z1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int idxLst ;
      private decimal A1111CarteiraDeCobrancaValorTotal ;
      private decimal A1112CarteiraDeCobrancaValorRecebido ;
      private decimal Z1111CarteiraDeCobrancaValorTotal ;
      private decimal Z1112CarteiraDeCobrancaValorRecebido ;
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
      private string edtCarteiraDeCobrancaNome_Internalname ;
      private string cmbCarteiraDeCobrancaStatus_Internalname ;
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
      private string edtCarteiraDeCobrancaNome_Jsonclick ;
      private string edtCarteiraDeCobrancaConvenio_Internalname ;
      private string edtCarteiraDeCobrancaConvenio_Jsonclick ;
      private string cmbCarteiraDeCobrancaStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCarteiraDeCobrancaId_Internalname ;
      private string edtCarteiraDeCobrancaId_Jsonclick ;
      private string edtCarteiraDeCobrancaCodigo_Internalname ;
      private string edtCarteiraDeCobrancaCodigo_Jsonclick ;
      private string edtCarteiraDeCobrancaWorkspaceId_Internalname ;
      private string edtCarteiraDeCobrancaWorkspaceId_Jsonclick ;
      private string edtCarteiraDeCobrancaCreatedAt_Internalname ;
      private string edtCarteiraDeCobrancaCreatedAt_Jsonclick ;
      private string edtCarteiraDeCobrancaUpdatedAt_Internalname ;
      private string edtCarteiraDeCobrancaUpdatedAt_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string hsh2 ;
      private string sMode110 ;
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
      private DateTime Z1075CarteiraDeCobrancaCreatedAt ;
      private DateTime Z1076CarteiraDeCobrancaUpdatedAt ;
      private DateTime A1075CarteiraDeCobrancaCreatedAt ;
      private DateTime A1076CarteiraDeCobrancaUpdatedAt ;
      private DateTime i1075CarteiraDeCobrancaCreatedAt ;
      private bool Z1074CarteiraDeCobrancaStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1069CarteiraDeCobrancaId ;
      private bool wbErr ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n1075CarteiraDeCobrancaCreatedAt ;
      private bool n1076CarteiraDeCobrancaUpdatedAt ;
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1071CarteiraDeCobrancaNome ;
      private bool n1072CarteiraDeCobrancaWorkspaceId ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i1074CarteiraDeCobrancaStatus ;
      private string Z1070CarteiraDeCobrancaCodigo ;
      private string Z1071CarteiraDeCobrancaNome ;
      private string Z1073CarteiraDeCobrancaConvenio ;
      private string A1071CarteiraDeCobrancaNome ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private Guid Z1072CarteiraDeCobrancaWorkspaceId ;
      private Guid A1072CarteiraDeCobrancaWorkspaceId ;
      private Guid i1072CarteiraDeCobrancaWorkspaceId ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXProperties forbiddenHiddens2 ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCarteiraDeCobrancaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private decimal[] T00365_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] T00365_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] T00365_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T00369_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T00369_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003611_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003611_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T003616_A1069CarteiraDeCobrancaId ;
      private bool[] T003616_n1069CarteiraDeCobrancaId ;
      private DateTime[] T003616_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] T003616_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] T003616_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] T003616_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] T003616_A1070CarteiraDeCobrancaCodigo ;
      private bool[] T003616_n1070CarteiraDeCobrancaCodigo ;
      private string[] T003616_A1071CarteiraDeCobrancaNome ;
      private bool[] T003616_n1071CarteiraDeCobrancaNome ;
      private Guid[] T003616_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] T003616_n1072CarteiraDeCobrancaWorkspaceId ;
      private string[] T003616_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T003616_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T003616_A1074CarteiraDeCobrancaStatus ;
      private bool[] T003616_n1074CarteiraDeCobrancaStatus ;
      private decimal[] T003616_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] T003616_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] T003616_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003616_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003616_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003616_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003616_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private decimal[] T003618_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] T003618_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] T003618_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T003620_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T003620_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003622_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003622_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003624_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003624_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T003625_A1069CarteiraDeCobrancaId ;
      private bool[] T003625_n1069CarteiraDeCobrancaId ;
      private int[] T00363_A1069CarteiraDeCobrancaId ;
      private bool[] T00363_n1069CarteiraDeCobrancaId ;
      private DateTime[] T00363_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] T00363_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] T00363_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] T00363_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] T00363_A1070CarteiraDeCobrancaCodigo ;
      private bool[] T00363_n1070CarteiraDeCobrancaCodigo ;
      private string[] T00363_A1071CarteiraDeCobrancaNome ;
      private bool[] T00363_n1071CarteiraDeCobrancaNome ;
      private Guid[] T00363_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] T00363_n1072CarteiraDeCobrancaWorkspaceId ;
      private string[] T00363_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T00363_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T00363_A1074CarteiraDeCobrancaStatus ;
      private bool[] T00363_n1074CarteiraDeCobrancaStatus ;
      private int[] T003626_A1069CarteiraDeCobrancaId ;
      private bool[] T003626_n1069CarteiraDeCobrancaId ;
      private int[] T003627_A1069CarteiraDeCobrancaId ;
      private bool[] T003627_n1069CarteiraDeCobrancaId ;
      private int[] T00362_A1069CarteiraDeCobrancaId ;
      private bool[] T00362_n1069CarteiraDeCobrancaId ;
      private DateTime[] T00362_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] T00362_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] T00362_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] T00362_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] T00362_A1070CarteiraDeCobrancaCodigo ;
      private bool[] T00362_n1070CarteiraDeCobrancaCodigo ;
      private string[] T00362_A1071CarteiraDeCobrancaNome ;
      private bool[] T00362_n1071CarteiraDeCobrancaNome ;
      private Guid[] T00362_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] T00362_n1072CarteiraDeCobrancaWorkspaceId ;
      private string[] T00362_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T00362_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T00362_A1074CarteiraDeCobrancaStatus ;
      private bool[] T00362_n1074CarteiraDeCobrancaStatus ;
      private int[] T003629_A1069CarteiraDeCobrancaId ;
      private bool[] T003629_n1069CarteiraDeCobrancaId ;
      private decimal[] T003633_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] T003633_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] T003633_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003637_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003637_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003639_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003639_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T003640_A1077BoletosId ;
      private int[] T003641_A1069CarteiraDeCobrancaId ;
      private bool[] T003641_n1069CarteiraDeCobrancaId ;
   }

   public class carteiradecobranca__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00362;
          prmT00362 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00363;
          prmT00363 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00365;
          prmT00365 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00367;
          prmT00367 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00369;
          prmT00369 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003611;
          prmT003611 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003616;
          prmT003616 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT003616;
          cmdBufferT003616=" SELECT TM1.CarteiraDeCobrancaId, TM1.CarteiraDeCobrancaCreatedAt, TM1.CarteiraDeCobrancaUpdatedAt, TM1.CarteiraDeCobrancaCodigo, TM1.CarteiraDeCobrancaNome, TM1.CarteiraDeCobrancaWorkspaceId, TM1.CarteiraDeCobrancaConvenio, TM1.CarteiraDeCobrancaStatus, COALESCE( T2.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T2.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T2.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos, COALESCE( T3.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados, COALESCE( T4.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados, COALESCE( T5.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM ((((CarteiraDeCobranca TM1 LEFT JOIN LATERAL (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto WHERE TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId GROUP BY CarteiraDeCobrancaId ) T2 ON T2.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'REGISTRADO')) GROUP BY CarteiraDeCobrancaId ) T3 ON T3.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'VENCIDO')) GROUP BY CarteiraDeCobrancaId ) T4 ON T4.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, "
          + " CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'BAIXADO')) GROUP BY CarteiraDeCobrancaId ) T5 ON T5.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) WHERE TM1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ORDER BY TM1.CarteiraDeCobrancaId" ;
          Object[] prmT003618;
          prmT003618 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003620;
          prmT003620 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003622;
          prmT003622 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003624;
          prmT003624 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003625;
          prmT003625 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003626;
          prmT003626 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003627;
          prmT003627 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003628;
          prmT003628 = new Object[] {
          new ParDef("CarteiraDeCobrancaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaCodigo",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaWorkspaceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaConvenio",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaStatus",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmT003629;
          prmT003629 = new Object[] {
          };
          Object[] prmT003630;
          prmT003630 = new Object[] {
          new ParDef("CarteiraDeCobrancaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaCodigo",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaWorkspaceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaConvenio",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003631;
          prmT003631 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003633;
          prmT003633 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003635;
          prmT003635 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003637;
          prmT003637 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003639;
          prmT003639 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003640;
          prmT003640 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003641;
          prmT003641 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00362", "SELECT CarteiraDeCobrancaId, CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome, CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId  FOR UPDATE OF CarteiraDeCobranca NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00362,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00363", "SELECT CarteiraDeCobrancaId, CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome, CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00363,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00365", "SELECT COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00365,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00367", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00367,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00369", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00369,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003611", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003616", cmdBufferT003616,true, GxErrorMask.GX_NOMASK, false, this,prmT003616,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003618", "SELECT COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003620", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003620,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003622", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003622,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003624", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003624,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003625", "SELECT CarteiraDeCobrancaId FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003626", "SELECT CarteiraDeCobrancaId FROM CarteiraDeCobranca WHERE ( CarteiraDeCobrancaId > :CarteiraDeCobrancaId) ORDER BY CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003626,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003627", "SELECT CarteiraDeCobrancaId FROM CarteiraDeCobranca WHERE ( CarteiraDeCobrancaId < :CarteiraDeCobrancaId) ORDER BY CarteiraDeCobrancaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT003627,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003628", "SAVEPOINT gxupdate;INSERT INTO CarteiraDeCobranca(CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome, CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus) VALUES(:CarteiraDeCobrancaCreatedAt, :CarteiraDeCobrancaUpdatedAt, :CarteiraDeCobrancaCodigo, :CarteiraDeCobrancaNome, :CarteiraDeCobrancaWorkspaceId, :CarteiraDeCobrancaConvenio, :CarteiraDeCobrancaStatus);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT003628)
             ,new CursorDef("T003629", "SELECT currval('CarteiraDeCobrancaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003629,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003630", "SAVEPOINT gxupdate;UPDATE CarteiraDeCobranca SET CarteiraDeCobrancaCreatedAt=:CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt=:CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo=:CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome=:CarteiraDeCobrancaNome, CarteiraDeCobrancaWorkspaceId=:CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaConvenio=:CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus=:CarteiraDeCobrancaStatus  WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003630)
             ,new CursorDef("T003631", "SAVEPOINT gxupdate;DELETE FROM CarteiraDeCobranca  WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003631)
             ,new CursorDef("T003633", "SELECT COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003633,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003635", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003635,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003637", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003637,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003639", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003639,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003640", "SELECT BoletosId FROM Boleto WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003640,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003641", "SELECT CarteiraDeCobrancaId FROM CarteiraDeCobranca ORDER BY CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003641,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((Guid[]) buf[9])[0] = rslt.getGuid(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((Guid[]) buf[9])[0] = rslt.getGuid(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((Guid[]) buf[9])[0] = rslt.getGuid(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((int[]) buf[20])[0] = rslt.getInt(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((int[]) buf[22])[0] = rslt.getInt(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                return;
             case 7 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
