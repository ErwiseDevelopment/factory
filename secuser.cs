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
   public class secuser : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A226SecUserOwnerId = (int)(Math.Round(NumberUtil.Val( GetPar( "SecUserOwnerId"), "."), 18, MidpointRounding.ToEven));
            n226SecUserOwnerId = false;
            AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A226SecUserOwnerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A192TipoClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoClienteId"), "."), 18, MidpointRounding.ToEven));
            n192TipoClienteId = false;
            AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A192TipoClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A147SecUserUserMan = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserUserMan"), "."), 18, MidpointRounding.ToEven));
            n147SecUserUserMan = false;
            AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A147SecUserUserMan) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A210SecUserClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserClienteId"), "."), 18, MidpointRounding.ToEven));
            n210SecUserClienteId = false;
            AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A210SecUserClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "secuser")), "secuser") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "secuser")))) ;
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
                  AV7SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SecUserId", StringUtil.LTrimStr( (decimal)(AV7SecUserId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Usuário", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_SecUserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SecUserId = aP1_SecUserId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbSecUserStatus = new GXCombobox();
         cmbSecUserAnalista = new GXCombobox();
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
         if ( cmbSecUserStatus.ItemCount > 0 )
         {
            A150SecUserStatus = StringUtil.StrToBool( cmbSecUserStatus.getValidValue(StringUtil.BoolToStr( A150SecUserStatus)));
            n150SecUserStatus = false;
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecUserStatus.CurrentValue = StringUtil.BoolToStr( A150SecUserStatus);
            AssignProp("", false, cmbSecUserStatus_Internalname, "Values", cmbSecUserStatus.ToJavascriptSource(), true);
         }
         if ( cmbSecUserAnalista.ItemCount > 0 )
         {
            A791SecUserAnalista = StringUtil.StrToBool( cmbSecUserAnalista.getValidValue(StringUtil.BoolToStr( A791SecUserAnalista)));
            n791SecUserAnalista = false;
            AssignAttri("", false, "A791SecUserAnalista", A791SecUserAnalista);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecUserAnalista.CurrentValue = StringUtil.BoolToStr( A791SecUserAnalista);
            AssignProp("", false, cmbSecUserAnalista_Internalname, "Values", cmbSecUserAnalista.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserName_Internalname, "Usuário", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserName_Internalname, A141SecUserName, StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserFullName_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserFullName_Internalname, A143SecUserFullName, StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserFullName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserEmail_Internalname, A144SecUserEmail, StringUtil.RTrim( context.localUtil.Format( A144SecUserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A144SecUserEmail, "", "", "", edtSecUserEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSecUserStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSecUserStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecUserStatus, cmbSecUserStatus_Internalname, StringUtil.BoolToStr( A150SecUserStatus), 1, cmbSecUserStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSecUserStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_SecUser.htm");
         cmbSecUserStatus.CurrentValue = StringUtil.BoolToStr( A150SecUserStatus);
         AssignProp("", false, cmbSecUserStatus_Internalname, "Values", (string)(cmbSecUserStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsecuseranalista_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksecuseranalista_Internalname, "Usuário análista de propostas", "", "", lblTextblocksecuseranalista_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedsecuseranalista_Internalname, tblTablemergedsecuseranalista_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSecUserAnalista_Internalname, "Sec User Analista", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecUserAnalista, cmbSecUserAnalista_Internalname, StringUtil.BoolToStr( A791SecUserAnalista), 1, cmbSecUserAnalista_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSecUserAnalista.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_SecUser.htm");
         cmbSecUserAnalista.CurrentValue = StringUtil.BoolToStr( A791SecUserAnalista);
         AssignProp("", false, cmbSecUserAnalista_Internalname, "Values", (string)(cmbSecUserAnalista.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblSecuseranalista_righttext_Internalname, "O usuário com essa opção tem a capacidade de finalizar a análise de uma proposta, podendo aprová-la ou rejeitá-la.", "", "", lblSecuseranalista_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_SecUser.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserId_Visible, edtSecUserId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SecUser.htm");
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
         E110I2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
               Z145SecUserCreatedAt = context.localUtil.CToT( cgiGet( "Z145SecUserCreatedAt"), 0);
               n145SecUserCreatedAt = ((DateTime.MinValue==A145SecUserCreatedAt) ? true : false);
               Z141SecUserName = cgiGet( "Z141SecUserName");
               n141SecUserName = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? true : false);
               Z143SecUserFullName = cgiGet( "Z143SecUserFullName");
               n143SecUserFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? true : false);
               Z144SecUserEmail = cgiGet( "Z144SecUserEmail");
               n144SecUserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? true : false);
               Z150SecUserStatus = StringUtil.StrToBool( cgiGet( "Z150SecUserStatus"));
               n150SecUserStatus = ((false==A150SecUserStatus) ? true : false);
               Z142SecUserPassword = cgiGet( "Z142SecUserPassword");
               n142SecUserPassword = (String.IsNullOrEmpty(StringUtil.RTrim( A142SecUserPassword)) ? true : false);
               Z791SecUserAnalista = StringUtil.StrToBool( cgiGet( "Z791SecUserAnalista"));
               n791SecUserAnalista = ((false==A791SecUserAnalista) ? true : false);
               Z146SecUserUpdateAt = context.localUtil.CToT( cgiGet( "Z146SecUserUpdateAt"), 0);
               n146SecUserUpdateAt = ((DateTime.MinValue==A146SecUserUpdateAt) ? true : false);
               Z208SecUserTemp = StringUtil.StrToBool( cgiGet( "Z208SecUserTemp"));
               n208SecUserTemp = ((false==A208SecUserTemp) ? true : false);
               Z209SecUserClienteAcesso = StringUtil.StrToBool( cgiGet( "Z209SecUserClienteAcesso"));
               n209SecUserClienteAcesso = ((false==A209SecUserClienteAcesso) ? true : false);
               Z226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z226SecUserOwnerId"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               Z147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z147SecUserUserMan"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               Z210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z210SecUserClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
               A145SecUserCreatedAt = context.localUtil.CToT( cgiGet( "Z145SecUserCreatedAt"), 0);
               n145SecUserCreatedAt = false;
               n145SecUserCreatedAt = ((DateTime.MinValue==A145SecUserCreatedAt) ? true : false);
               A142SecUserPassword = cgiGet( "Z142SecUserPassword");
               n142SecUserPassword = false;
               n142SecUserPassword = (String.IsNullOrEmpty(StringUtil.RTrim( A142SecUserPassword)) ? true : false);
               A146SecUserUpdateAt = context.localUtil.CToT( cgiGet( "Z146SecUserUpdateAt"), 0);
               n146SecUserUpdateAt = false;
               n146SecUserUpdateAt = ((DateTime.MinValue==A146SecUserUpdateAt) ? true : false);
               A208SecUserTemp = StringUtil.StrToBool( cgiGet( "Z208SecUserTemp"));
               n208SecUserTemp = false;
               n208SecUserTemp = ((false==A208SecUserTemp) ? true : false);
               A209SecUserClienteAcesso = StringUtil.StrToBool( cgiGet( "Z209SecUserClienteAcesso"));
               n209SecUserClienteAcesso = false;
               n209SecUserClienteAcesso = ((false==A209SecUserClienteAcesso) ? true : false);
               A226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z226SecUserOwnerId"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = false;
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               A147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z147SecUserUserMan"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = false;
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               A210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z210SecUserClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = false;
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N147SecUserUserMan"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               N210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N210SecUserClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
               N226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N226SecUserOwnerId"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               AV7SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSECUSERID"), ",", "."), 18, MidpointRounding.ToEven));
               AV20Insert_SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSERUSERMAN"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20Insert_SecUserUserMan", StringUtil.LTrimStr( (decimal)(AV20Insert_SecUserUserMan), 4, 0));
               A147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSERUSERMAN"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               AV22Insert_SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSERCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22Insert_SecUserClienteId", StringUtil.LTrimStr( (decimal)(AV22Insert_SecUserClienteId), 4, 0));
               A210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSERCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
               AV23Insert_SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSEROWNERID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23Insert_SecUserOwnerId", StringUtil.LTrimStr( (decimal)(AV23Insert_SecUserOwnerId), 9, 0));
               A226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSEROWNERID"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               A145SecUserCreatedAt = context.localUtil.CToT( cgiGet( "SECUSERCREATEDAT"), 0);
               n145SecUserCreatedAt = ((DateTime.MinValue==A145SecUserCreatedAt) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A142SecUserPassword = cgiGet( "SECUSERPASSWORD");
               n142SecUserPassword = (String.IsNullOrEmpty(StringUtil.RTrim( A142SecUserPassword)) ? true : false);
               A146SecUserUpdateAt = context.localUtil.CToT( cgiGet( "SECUSERUPDATEAT"), 0);
               n146SecUserUpdateAt = ((DateTime.MinValue==A146SecUserUpdateAt) ? true : false);
               A208SecUserTemp = StringUtil.StrToBool( cgiGet( "SECUSERTEMP"));
               n208SecUserTemp = ((false==A208SecUserTemp) ? true : false);
               A209SecUserClienteAcesso = StringUtil.StrToBool( cgiGet( "SECUSERCLIENTEACESSO"));
               n209SecUserClienteAcesso = ((false==A209SecUserClienteAcesso) ? true : false);
               A153SecUserTeste = cgiGet( "SECUSERTESTE");
               n153SecUserTeste = false;
               n153SecUserTeste = (String.IsNullOrEmpty(StringUtil.RTrim( A153SecUserTeste)) ? true : false);
               A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "TIPOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               A148SecUserManName = cgiGet( "SECUSERMANNAME");
               n148SecUserManName = false;
               A149SecUserManFullName = cgiGet( "SECUSERMANFULLNAME");
               n149SecUserManFullName = false;
               A211SecUserClienteFullName = cgiGet( "SECUSERCLIENTEFULLNAME");
               n211SecUserClienteFullName = false;
               A212SecUserClienteStatus = StringUtil.StrToBool( cgiGet( "SECUSERCLIENTESTATUS"));
               n212SecUserClienteStatus = false;
               A213SecUserCliClienteAcesso = StringUtil.StrToBool( cgiGet( "SECUSERCLICLIENTEACESSO"));
               n213SecUserCliClienteAcesso = false;
               A793TipoClientePortalPjPf = StringUtil.StrToBool( cgiGet( "TIPOCLIENTEPORTALPJPF"));
               n793TipoClientePortalPjPf = false;
               AV25Pgmname = cgiGet( "vPGMNAME");
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
               A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
               n141SecUserName = false;
               AssignAttri("", false, "A141SecUserName", A141SecUserName);
               n141SecUserName = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? true : false);
               A143SecUserFullName = StringUtil.Upper( cgiGet( edtSecUserFullName_Internalname));
               n143SecUserFullName = false;
               AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
               n143SecUserFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? true : false);
               A144SecUserEmail = cgiGet( edtSecUserEmail_Internalname);
               n144SecUserEmail = false;
               AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
               n144SecUserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? true : false);
               cmbSecUserStatus.CurrentValue = cgiGet( cmbSecUserStatus_Internalname);
               A150SecUserStatus = StringUtil.StrToBool( cgiGet( cmbSecUserStatus_Internalname));
               n150SecUserStatus = false;
               AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
               n150SecUserStatus = ((false==A150SecUserStatus) ? true : false);
               cmbSecUserAnalista.CurrentValue = cgiGet( cmbSecUserAnalista_Internalname);
               A791SecUserAnalista = StringUtil.StrToBool( cgiGet( cmbSecUserAnalista_Internalname));
               n791SecUserAnalista = false;
               AssignAttri("", false, "A791SecUserAnalista", A791SecUserAnalista);
               n791SecUserAnalista = ((false==A791SecUserAnalista) ? true : false);
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SecUser");
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               forbiddenHiddens.Add("SecUserId", context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserUserMan", context.localUtil.Format( (decimal)(AV20Insert_SecUserUserMan), "ZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserClienteId", context.localUtil.Format( (decimal)(AV22Insert_SecUserClienteId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserOwnerId", context.localUtil.Format( (decimal)(AV23Insert_SecUserOwnerId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("SecUserCreatedAt", context.localUtil.Format( A145SecUserCreatedAt, "99/99/9999 99:99"));
               forbiddenHiddens.Add("SecUserPassword", StringUtil.RTrim( context.localUtil.Format( A142SecUserPassword, "")));
               forbiddenHiddens.Add("SecUserUpdateAt", context.localUtil.Format( A146SecUserUpdateAt, "99/99/9999 99:99"));
               forbiddenHiddens.Add("SecUserTemp", StringUtil.BoolToStr( A208SecUserTemp));
               forbiddenHiddens.Add("SecUserClienteAcesso", StringUtil.BoolToStr( A209SecUserClienteAcesso));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A133SecUserId != Z133SecUserId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("secuser:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A133SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
                  n133SecUserId = false;
                  AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
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
                     sMode22 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode22;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound22 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SECUSERID");
                        AnyError = 1;
                        GX_FocusControl = edtSecUserId_Internalname;
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
                           E110I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120I2 ();
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
            E120I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I22( ) ;
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
            DisableAttributes0I22( ) ;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I22( ) ;
            }
            else
            {
               CheckExtendedTable0I22( ) ;
               CloseExtendedTableCursors0I22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0I0( )
      {
      }

      protected void E110I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SecUserUserMan") == 0 )
               {
                  AV20Insert_SecUserUserMan = (short)(Math.Round(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20Insert_SecUserUserMan", StringUtil.LTrimStr( (decimal)(AV20Insert_SecUserUserMan), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SecUserClienteId") == 0 )
               {
                  AV22Insert_SecUserClienteId = (short)(Math.Round(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22Insert_SecUserClienteId", StringUtil.LTrimStr( (decimal)(AV22Insert_SecUserClienteId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SecUserOwnerId") == 0 )
               {
                  AV23Insert_SecUserOwnerId = (int)(Math.Round(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV23Insert_SecUserOwnerId", StringUtil.LTrimStr( (decimal)(AV23Insert_SecUserOwnerId), 9, 0));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtSecUserId_Visible = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserId_Visible), 5, 0), true);
      }

      protected void E120I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("secuserww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0I22( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z145SecUserCreatedAt = T000I3_A145SecUserCreatedAt[0];
               Z141SecUserName = T000I3_A141SecUserName[0];
               Z143SecUserFullName = T000I3_A143SecUserFullName[0];
               Z144SecUserEmail = T000I3_A144SecUserEmail[0];
               Z150SecUserStatus = T000I3_A150SecUserStatus[0];
               Z142SecUserPassword = T000I3_A142SecUserPassword[0];
               Z791SecUserAnalista = T000I3_A791SecUserAnalista[0];
               Z146SecUserUpdateAt = T000I3_A146SecUserUpdateAt[0];
               Z208SecUserTemp = T000I3_A208SecUserTemp[0];
               Z209SecUserClienteAcesso = T000I3_A209SecUserClienteAcesso[0];
               Z226SecUserOwnerId = T000I3_A226SecUserOwnerId[0];
               Z147SecUserUserMan = T000I3_A147SecUserUserMan[0];
               Z210SecUserClienteId = T000I3_A210SecUserClienteId[0];
            }
            else
            {
               Z145SecUserCreatedAt = A145SecUserCreatedAt;
               Z141SecUserName = A141SecUserName;
               Z143SecUserFullName = A143SecUserFullName;
               Z144SecUserEmail = A144SecUserEmail;
               Z150SecUserStatus = A150SecUserStatus;
               Z142SecUserPassword = A142SecUserPassword;
               Z791SecUserAnalista = A791SecUserAnalista;
               Z146SecUserUpdateAt = A146SecUserUpdateAt;
               Z208SecUserTemp = A208SecUserTemp;
               Z209SecUserClienteAcesso = A209SecUserClienteAcesso;
               Z226SecUserOwnerId = A226SecUserOwnerId;
               Z147SecUserUserMan = A147SecUserUserMan;
               Z210SecUserClienteId = A210SecUserClienteId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z133SecUserId = A133SecUserId;
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z142SecUserPassword = A142SecUserPassword;
            Z791SecUserAnalista = A791SecUserAnalista;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z208SecUserTemp = A208SecUserTemp;
            Z209SecUserClienteAcesso = A209SecUserClienteAcesso;
            Z153SecUserTeste = A153SecUserTeste;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
            Z192TipoClienteId = A192TipoClienteId;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z148SecUserManName = A148SecUserManName;
            Z149SecUserManFullName = A149SecUserManFullName;
            Z211SecUserClienteFullName = A211SecUserClienteFullName;
            Z212SecUserClienteStatus = A212SecUserClienteStatus;
            Z213SecUserCliClienteAcesso = A213SecUserCliClienteAcesso;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbSecUserStatus.Enabled = 0;
            AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbSecUserStatus.Enabled = 1;
            AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
         }
         AV25Pgmname = "SecUser";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SecUserId) )
         {
            A133SecUserId = AV7SecUserId;
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n145SecUserCreatedAt = false;
            AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbSecUserStatus.Enabled = 0;
            AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A150SecUserStatus) && ( Gx_BScreen == 0 ) )
         {
            A150SecUserStatus = true;
            n150SecUserStatus = false;
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
         }
      }

      protected void Load0I22( )
      {
         /* Using cursor T000I8 */
         pr_default.execute(6, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound22 = 1;
            A192TipoClienteId = T000I8_A192TipoClienteId[0];
            n192TipoClienteId = T000I8_n192TipoClienteId[0];
            A145SecUserCreatedAt = T000I8_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = T000I8_n145SecUserCreatedAt[0];
            A141SecUserName = T000I8_A141SecUserName[0];
            n141SecUserName = T000I8_n141SecUserName[0];
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            A143SecUserFullName = T000I8_A143SecUserFullName[0];
            n143SecUserFullName = T000I8_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            A144SecUserEmail = T000I8_A144SecUserEmail[0];
            n144SecUserEmail = T000I8_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            A150SecUserStatus = T000I8_A150SecUserStatus[0];
            n150SecUserStatus = T000I8_n150SecUserStatus[0];
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
            A142SecUserPassword = T000I8_A142SecUserPassword[0];
            n142SecUserPassword = T000I8_n142SecUserPassword[0];
            A791SecUserAnalista = T000I8_A791SecUserAnalista[0];
            n791SecUserAnalista = T000I8_n791SecUserAnalista[0];
            AssignAttri("", false, "A791SecUserAnalista", A791SecUserAnalista);
            A146SecUserUpdateAt = T000I8_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = T000I8_n146SecUserUpdateAt[0];
            A148SecUserManName = T000I8_A148SecUserManName[0];
            n148SecUserManName = T000I8_n148SecUserManName[0];
            A149SecUserManFullName = T000I8_A149SecUserManFullName[0];
            n149SecUserManFullName = T000I8_n149SecUserManFullName[0];
            A208SecUserTemp = T000I8_A208SecUserTemp[0];
            n208SecUserTemp = T000I8_n208SecUserTemp[0];
            A209SecUserClienteAcesso = T000I8_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = T000I8_n209SecUserClienteAcesso[0];
            A153SecUserTeste = T000I8_A153SecUserTeste[0];
            n153SecUserTeste = T000I8_n153SecUserTeste[0];
            A211SecUserClienteFullName = T000I8_A211SecUserClienteFullName[0];
            n211SecUserClienteFullName = T000I8_n211SecUserClienteFullName[0];
            A212SecUserClienteStatus = T000I8_A212SecUserClienteStatus[0];
            n212SecUserClienteStatus = T000I8_n212SecUserClienteStatus[0];
            A213SecUserCliClienteAcesso = T000I8_A213SecUserCliClienteAcesso[0];
            n213SecUserCliClienteAcesso = T000I8_n213SecUserCliClienteAcesso[0];
            A793TipoClientePortalPjPf = T000I8_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = T000I8_n793TipoClientePortalPjPf[0];
            A226SecUserOwnerId = T000I8_A226SecUserOwnerId[0];
            n226SecUserOwnerId = T000I8_n226SecUserOwnerId[0];
            A147SecUserUserMan = T000I8_A147SecUserUserMan[0];
            n147SecUserUserMan = T000I8_n147SecUserUserMan[0];
            A210SecUserClienteId = T000I8_A210SecUserClienteId[0];
            n210SecUserClienteId = T000I8_n210SecUserClienteId[0];
            ZM0I22( -20) ;
         }
         pr_default.close(6);
         OnLoadActions0I22( ) ;
      }

      protected void OnLoadActions0I22( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_SecUserUserMan) )
         {
            A147SecUserUserMan = AV20Insert_SecUserUserMan;
            n147SecUserUserMan = false;
            AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A147SecUserUserMan) )
            {
               A147SecUserUserMan = 0;
               n147SecUserUserMan = false;
               AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
               n147SecUserUserMan = true;
               n147SecUserUserMan = true;
               AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_SecUserClienteId) )
         {
            A210SecUserClienteId = AV22Insert_SecUserClienteId;
            n210SecUserClienteId = false;
            AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A210SecUserClienteId) )
            {
               A210SecUserClienteId = 0;
               n210SecUserClienteId = false;
               AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
               n210SecUserClienteId = true;
               n210SecUserClienteId = true;
               AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_SecUserOwnerId) )
         {
            A226SecUserOwnerId = AV23Insert_SecUserOwnerId;
            n226SecUserOwnerId = false;
            AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A226SecUserOwnerId) )
            {
               A226SecUserOwnerId = 0;
               n226SecUserOwnerId = false;
               AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
               n226SecUserOwnerId = true;
               n226SecUserOwnerId = true;
               AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
            }
         }
      }

      protected void CheckExtendedTable0I22( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_SecUserUserMan) )
         {
            A147SecUserUserMan = AV20Insert_SecUserUserMan;
            n147SecUserUserMan = false;
            AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A147SecUserUserMan) )
            {
               A147SecUserUserMan = 0;
               n147SecUserUserMan = false;
               AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
               n147SecUserUserMan = true;
               n147SecUserUserMan = true;
               AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_SecUserClienteId) )
         {
            A210SecUserClienteId = AV22Insert_SecUserClienteId;
            n210SecUserClienteId = false;
            AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A210SecUserClienteId) )
            {
               A210SecUserClienteId = 0;
               n210SecUserClienteId = false;
               AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
               n210SecUserClienteId = true;
               n210SecUserClienteId = true;
               AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_SecUserOwnerId) )
         {
            A226SecUserOwnerId = AV23Insert_SecUserOwnerId;
            n226SecUserOwnerId = false;
            AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A226SecUserOwnerId) )
            {
               A226SecUserOwnerId = 0;
               n226SecUserOwnerId = false;
               AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
               n226SecUserOwnerId = true;
               n226SecUserOwnerId = true;
               AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Usuário", "", "", "", "", "", "", "", ""), 1, "SECUSERNAME");
            AnyError = 1;
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "SECUSERFULLNAME");
            AnyError = 1;
            GX_FocusControl = edtSecUserFullName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A144SecUserEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ) )
         {
            GX_msglist.addItem("O valor de E-mail não coincide com o padrão especificado", "OutOfRange", 1, "SECUSEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtSecUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""), 1, "SECUSEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtSecUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000I4 */
         pr_default.execute(2, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A226SecUserOwnerId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sec User Owner'.", "ForeignKeyNotFound", 1, "SECUSEROWNERID");
               AnyError = 1;
            }
         }
         A192TipoClienteId = T000I4_A192TipoClienteId[0];
         n192TipoClienteId = T000I4_n192TipoClienteId[0];
         pr_default.close(2);
         /* Using cursor T000I7 */
         pr_default.execute(5, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A192TipoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Cliente'.", "ForeignKeyNotFound", 1, "TIPOCLIENTEID");
               AnyError = 1;
            }
         }
         A793TipoClientePortalPjPf = T000I7_A793TipoClientePortalPjPf[0];
         n793TipoClientePortalPjPf = T000I7_n793TipoClientePortalPjPf[0];
         pr_default.close(5);
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A147SecUserUserMan) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Manuten'.", "ForeignKeyNotFound", 1, "SECUSERUSERMAN");
               AnyError = 1;
            }
         }
         A148SecUserManName = T000I5_A148SecUserManName[0];
         n148SecUserManName = T000I5_n148SecUserManName[0];
         A149SecUserManFullName = T000I5_A149SecUserManFullName[0];
         n149SecUserManFullName = T000I5_n149SecUserManFullName[0];
         pr_default.close(3);
         /* Using cursor T000I6 */
         pr_default.execute(4, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A210SecUserClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Cliente User'.", "ForeignKeyNotFound", 1, "SECUSERCLIENTEID");
               AnyError = 1;
            }
         }
         A211SecUserClienteFullName = T000I6_A211SecUserClienteFullName[0];
         n211SecUserClienteFullName = T000I6_n211SecUserClienteFullName[0];
         A212SecUserClienteStatus = T000I6_A212SecUserClienteStatus[0];
         n212SecUserClienteStatus = T000I6_n212SecUserClienteStatus[0];
         A213SecUserCliClienteAcesso = T000I6_A213SecUserCliClienteAcesso[0];
         n213SecUserCliClienteAcesso = T000I6_n213SecUserCliClienteAcesso[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0I22( )
      {
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( int A226SecUserOwnerId )
      {
         /* Using cursor T000I9 */
         pr_default.execute(7, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A226SecUserOwnerId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sec User Owner'.", "ForeignKeyNotFound", 1, "SECUSEROWNERID");
               AnyError = 1;
            }
         }
         A192TipoClienteId = T000I9_A192TipoClienteId[0];
         n192TipoClienteId = T000I9_n192TipoClienteId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_24( short A192TipoClienteId )
      {
         /* Using cursor T000I10 */
         pr_default.execute(8, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A192TipoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Cliente'.", "ForeignKeyNotFound", 1, "TIPOCLIENTEID");
               AnyError = 1;
            }
         }
         A793TipoClientePortalPjPf = T000I10_A793TipoClientePortalPjPf[0];
         n793TipoClientePortalPjPf = T000I10_n793TipoClientePortalPjPf[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A793TipoClientePortalPjPf))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_22( short A147SecUserUserMan )
      {
         /* Using cursor T000I11 */
         pr_default.execute(9, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A147SecUserUserMan) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Manuten'.", "ForeignKeyNotFound", 1, "SECUSERUSERMAN");
               AnyError = 1;
            }
         }
         A148SecUserManName = T000I11_A148SecUserManName[0];
         n148SecUserManName = T000I11_n148SecUserManName[0];
         A149SecUserManFullName = T000I11_A149SecUserManFullName[0];
         n149SecUserManFullName = T000I11_n149SecUserManFullName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A148SecUserManName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A149SecUserManFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_23( short A210SecUserClienteId )
      {
         /* Using cursor T000I12 */
         pr_default.execute(10, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A210SecUserClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Cliente User'.", "ForeignKeyNotFound", 1, "SECUSERCLIENTEID");
               AnyError = 1;
            }
         }
         A211SecUserClienteFullName = T000I12_A211SecUserClienteFullName[0];
         n211SecUserClienteFullName = T000I12_n211SecUserClienteFullName[0];
         A212SecUserClienteStatus = T000I12_A212SecUserClienteStatus[0];
         n212SecUserClienteStatus = T000I12_n212SecUserClienteStatus[0];
         A213SecUserCliClienteAcesso = T000I12_A213SecUserCliClienteAcesso[0];
         n213SecUserCliClienteAcesso = T000I12_n213SecUserCliClienteAcesso[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A211SecUserClienteFullName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A212SecUserClienteStatus))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A213SecUserCliClienteAcesso))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0I22( )
      {
         /* Using cursor T000I13 */
         pr_default.execute(11, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I22( 20) ;
            RcdFound22 = 1;
            A133SecUserId = T000I3_A133SecUserId[0];
            n133SecUserId = T000I3_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            A145SecUserCreatedAt = T000I3_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = T000I3_n145SecUserCreatedAt[0];
            A141SecUserName = T000I3_A141SecUserName[0];
            n141SecUserName = T000I3_n141SecUserName[0];
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            A143SecUserFullName = T000I3_A143SecUserFullName[0];
            n143SecUserFullName = T000I3_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            A144SecUserEmail = T000I3_A144SecUserEmail[0];
            n144SecUserEmail = T000I3_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            A150SecUserStatus = T000I3_A150SecUserStatus[0];
            n150SecUserStatus = T000I3_n150SecUserStatus[0];
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
            A142SecUserPassword = T000I3_A142SecUserPassword[0];
            n142SecUserPassword = T000I3_n142SecUserPassword[0];
            A791SecUserAnalista = T000I3_A791SecUserAnalista[0];
            n791SecUserAnalista = T000I3_n791SecUserAnalista[0];
            AssignAttri("", false, "A791SecUserAnalista", A791SecUserAnalista);
            A146SecUserUpdateAt = T000I3_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = T000I3_n146SecUserUpdateAt[0];
            A208SecUserTemp = T000I3_A208SecUserTemp[0];
            n208SecUserTemp = T000I3_n208SecUserTemp[0];
            A209SecUserClienteAcesso = T000I3_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = T000I3_n209SecUserClienteAcesso[0];
            A153SecUserTeste = T000I3_A153SecUserTeste[0];
            n153SecUserTeste = T000I3_n153SecUserTeste[0];
            A226SecUserOwnerId = T000I3_A226SecUserOwnerId[0];
            n226SecUserOwnerId = T000I3_n226SecUserOwnerId[0];
            A147SecUserUserMan = T000I3_A147SecUserUserMan[0];
            n147SecUserUserMan = T000I3_n147SecUserUserMan[0];
            A210SecUserClienteId = T000I3_A210SecUserClienteId[0];
            n210SecUserClienteId = T000I3_n210SecUserClienteId[0];
            Z133SecUserId = A133SecUserId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0I22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0I22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0I22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I22( ) ;
         if ( RcdFound22 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound22 = 0;
         /* Using cursor T000I14 */
         pr_default.execute(12, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000I14_A133SecUserId[0] < A133SecUserId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000I14_A133SecUserId[0] > A133SecUserId ) ) )
            {
               A133SecUserId = T000I14_A133SecUserId[0];
               n133SecUserId = T000I14_n133SecUserId[0];
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000I15 */
         pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000I15_A133SecUserId[0] > A133SecUserId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000I15_A133SecUserId[0] < A133SecUserId ) ) )
            {
               A133SecUserId = T000I15_A133SecUserId[0];
               n133SecUserId = T000I15_n133SecUserId[0];
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A133SecUserId != Z133SecUserId )
               {
                  A133SecUserId = Z133SecUserId;
                  n133SecUserId = false;
                  AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0I22( ) ;
                  GX_FocusControl = edtSecUserName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A133SecUserId != Z133SecUserId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSecUserName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECUSERID");
                     AnyError = 1;
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSecUserName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I22( ) ;
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
         if ( A133SecUserId != Z133SecUserId )
         {
            A133SecUserId = Z133SecUserId;
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0I22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z145SecUserCreatedAt != T000I2_A145SecUserCreatedAt[0] ) || ( StringUtil.StrCmp(Z141SecUserName, T000I2_A141SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z143SecUserFullName, T000I2_A143SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z144SecUserEmail, T000I2_A144SecUserEmail[0]) != 0 ) || ( Z150SecUserStatus != T000I2_A150SecUserStatus[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z142SecUserPassword, T000I2_A142SecUserPassword[0]) != 0 ) || ( Z791SecUserAnalista != T000I2_A791SecUserAnalista[0] ) || ( Z146SecUserUpdateAt != T000I2_A146SecUserUpdateAt[0] ) || ( Z208SecUserTemp != T000I2_A208SecUserTemp[0] ) || ( Z209SecUserClienteAcesso != T000I2_A209SecUserClienteAcesso[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z226SecUserOwnerId != T000I2_A226SecUserOwnerId[0] ) || ( Z147SecUserUserMan != T000I2_A147SecUserUserMan[0] ) || ( Z210SecUserClienteId != T000I2_A210SecUserClienteId[0] ) )
            {
               if ( Z145SecUserCreatedAt != T000I2_A145SecUserCreatedAt[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z145SecUserCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A145SecUserCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z141SecUserName, T000I2_A141SecUserName[0]) != 0 )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserName");
                  GXUtil.WriteLogRaw("Old: ",Z141SecUserName);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A141SecUserName[0]);
               }
               if ( StringUtil.StrCmp(Z143SecUserFullName, T000I2_A143SecUserFullName[0]) != 0 )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserFullName");
                  GXUtil.WriteLogRaw("Old: ",Z143SecUserFullName);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A143SecUserFullName[0]);
               }
               if ( StringUtil.StrCmp(Z144SecUserEmail, T000I2_A144SecUserEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserEmail");
                  GXUtil.WriteLogRaw("Old: ",Z144SecUserEmail);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A144SecUserEmail[0]);
               }
               if ( Z150SecUserStatus != T000I2_A150SecUserStatus[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserStatus");
                  GXUtil.WriteLogRaw("Old: ",Z150SecUserStatus);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A150SecUserStatus[0]);
               }
               if ( StringUtil.StrCmp(Z142SecUserPassword, T000I2_A142SecUserPassword[0]) != 0 )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserPassword");
                  GXUtil.WriteLogRaw("Old: ",Z142SecUserPassword);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A142SecUserPassword[0]);
               }
               if ( Z791SecUserAnalista != T000I2_A791SecUserAnalista[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserAnalista");
                  GXUtil.WriteLogRaw("Old: ",Z791SecUserAnalista);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A791SecUserAnalista[0]);
               }
               if ( Z146SecUserUpdateAt != T000I2_A146SecUserUpdateAt[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserUpdateAt");
                  GXUtil.WriteLogRaw("Old: ",Z146SecUserUpdateAt);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A146SecUserUpdateAt[0]);
               }
               if ( Z208SecUserTemp != T000I2_A208SecUserTemp[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserTemp");
                  GXUtil.WriteLogRaw("Old: ",Z208SecUserTemp);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A208SecUserTemp[0]);
               }
               if ( Z209SecUserClienteAcesso != T000I2_A209SecUserClienteAcesso[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserClienteAcesso");
                  GXUtil.WriteLogRaw("Old: ",Z209SecUserClienteAcesso);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A209SecUserClienteAcesso[0]);
               }
               if ( Z226SecUserOwnerId != T000I2_A226SecUserOwnerId[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserOwnerId");
                  GXUtil.WriteLogRaw("Old: ",Z226SecUserOwnerId);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A226SecUserOwnerId[0]);
               }
               if ( Z147SecUserUserMan != T000I2_A147SecUserUserMan[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserUserMan");
                  GXUtil.WriteLogRaw("Old: ",Z147SecUserUserMan);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A147SecUserUserMan[0]);
               }
               if ( Z210SecUserClienteId != T000I2_A210SecUserClienteId[0] )
               {
                  GXUtil.WriteLog("secuser:[seudo value changed for attri]"+"SecUserClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z210SecUserClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A210SecUserClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I22( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I22( 0) ;
            CheckOptimisticConcurrency0I22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I16 */
                     pr_default.execute(14, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n142SecUserPassword, A142SecUserPassword, n791SecUserAnalista, A791SecUserAnalista, n146SecUserUpdateAt, A146SecUserUpdateAt, n208SecUserTemp, A208SecUserTemp, n209SecUserClienteAcesso, A209SecUserClienteAcesso, n153SecUserTeste, A153SecUserTeste, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000I17 */
                     pr_default.execute(15);
                     A133SecUserId = T000I17_A133SecUserId[0];
                     n133SecUserId = T000I17_n133SecUserId[0];
                     AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0I0( ) ;
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
               Load0I22( ) ;
            }
            EndLevel0I22( ) ;
         }
         CloseExtendedTableCursors0I22( ) ;
      }

      protected void Update0I22( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I18 */
                     pr_default.execute(16, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n142SecUserPassword, A142SecUserPassword, n791SecUserAnalista, A791SecUserAnalista, n146SecUserUpdateAt, A146SecUserUpdateAt, n208SecUserTemp, A208SecUserTemp, n209SecUserClienteAcesso, A209SecUserClienteAcesso, n153SecUserTeste, A153SecUserTeste, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId, n133SecUserId, A133SecUserId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I22( ) ;
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
            EndLevel0I22( ) ;
         }
         CloseExtendedTableCursors0I22( ) ;
      }

      protected void DeferredUpdate0I22( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I22( ) ;
            AfterConfirm0I22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I19 */
                  pr_default.execute(17, new Object[] {n133SecUserId, A133SecUserId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("SecUser");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I22( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000I20 */
            pr_default.execute(18, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
            A192TipoClienteId = T000I20_A192TipoClienteId[0];
            n192TipoClienteId = T000I20_n192TipoClienteId[0];
            pr_default.close(18);
            /* Using cursor T000I21 */
            pr_default.execute(19, new Object[] {n192TipoClienteId, A192TipoClienteId});
            A793TipoClientePortalPjPf = T000I21_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = T000I21_n793TipoClientePortalPjPf[0];
            pr_default.close(19);
            /* Using cursor T000I22 */
            pr_default.execute(20, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
            A148SecUserManName = T000I22_A148SecUserManName[0];
            n148SecUserManName = T000I22_n148SecUserManName[0];
            A149SecUserManFullName = T000I22_A149SecUserManFullName[0];
            n149SecUserManFullName = T000I22_n149SecUserManFullName[0];
            pr_default.close(20);
            /* Using cursor T000I23 */
            pr_default.execute(21, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
            A211SecUserClienteFullName = T000I23_A211SecUserClienteFullName[0];
            n211SecUserClienteFullName = T000I23_n211SecUserClienteFullName[0];
            A212SecUserClienteStatus = T000I23_A212SecUserClienteStatus[0];
            n212SecUserClienteStatus = T000I23_n212SecUserClienteStatus[0];
            A213SecUserCliClienteAcesso = T000I23_A213SecUserCliClienteAcesso[0];
            n213SecUserCliClienteAcesso = T000I23_n213SecUserCliClienteAcesso[0];
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000I24 */
            pr_default.execute(22, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000I25 */
            pr_default.execute(23, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000I26 */
            pr_default.execute(24, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXUpdated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000I27 */
            pr_default.execute(25, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXCreated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000I28 */
            pr_default.execute(26, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000I29 */
            pr_default.execute(27, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000I30 */
            pr_default.execute(28, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000I31 */
            pr_default.execute(29, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000I32 */
            pr_default.execute(30, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000I33 */
            pr_default.execute(31, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000I34 */
            pr_default.execute(32, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sb Updated By Credito"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T000I35 */
            pr_default.execute(33, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sdb Credito Usuario"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T000I36 */
            pr_default.execute(34, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T000I37 */
            pr_default.execute(35, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T000I38 */
            pr_default.execute(36, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Especialidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T000I39 */
            pr_default.execute(37, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T000I40 */
            pr_default.execute(38, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T000I41 */
            pr_default.execute(39, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T000I42 */
            pr_default.execute(40, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SecUserLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T000I43 */
            pr_default.execute(41, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConfiguracoesTestemunhas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T000I44 */
            pr_default.execute(42, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T000I45 */
            pr_default.execute(43, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T000I46 */
            pr_default.execute(44, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User UID"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T000I47 */
            pr_default.execute(45, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
         }
      }

      protected void EndLevel0I22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("secuser",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            if ( (0==A210SecUserClienteId) || n210SecUserClienteId )
            {
               A210SecUserClienteId = A133SecUserId;
               n210SecUserClienteId = false;
               AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
            }
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("secuser",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I22( )
      {
         /* Scan By routine */
         /* Using cursor T000I48 */
         pr_default.execute(46);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = T000I48_A133SecUserId[0];
            n133SecUserId = T000I48_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I22( )
      {
         /* Scan next routine */
         pr_default.readNext(46);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = T000I48_A133SecUserId[0];
            n133SecUserId = T000I48_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         }
      }

      protected void ScanEnd0I22( )
      {
         pr_default.close(46);
      }

      protected void AfterConfirm0I22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I22( )
      {
         edtSecUserName_Enabled = 0;
         AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
         edtSecUserFullName_Enabled = 0;
         AssignProp("", false, edtSecUserFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserFullName_Enabled), 5, 0), true);
         edtSecUserEmail_Enabled = 0;
         AssignProp("", false, edtSecUserEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserEmail_Enabled), 5, 0), true);
         cmbSecUserStatus.Enabled = 0;
         AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
         cmbSecUserAnalista.Enabled = 0;
         AssignProp("", false, cmbSecUserAnalista_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserAnalista.Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SecUser");
         forbiddenHiddens.Add("SecUserId", context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserUserMan", context.localUtil.Format( (decimal)(AV20Insert_SecUserUserMan), "ZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserClienteId", context.localUtil.Format( (decimal)(AV22Insert_SecUserClienteId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserOwnerId", context.localUtil.Format( (decimal)(AV23Insert_SecUserOwnerId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("SecUserCreatedAt", context.localUtil.Format( A145SecUserCreatedAt, "99/99/9999 99:99"));
         forbiddenHiddens.Add("SecUserPassword", StringUtil.RTrim( context.localUtil.Format( A142SecUserPassword, "")));
         forbiddenHiddens.Add("SecUserUpdateAt", context.localUtil.Format( A146SecUserUpdateAt, "99/99/9999 99:99"));
         forbiddenHiddens.Add("SecUserTemp", StringUtil.BoolToStr( A208SecUserTemp));
         forbiddenHiddens.Add("SecUserClienteAcesso", StringUtil.BoolToStr( A209SecUserClienteAcesso));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("secuser:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z145SecUserCreatedAt", context.localUtil.TToC( Z145SecUserCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z141SecUserName", Z141SecUserName);
         GxWebStd.gx_hidden_field( context, "Z143SecUserFullName", Z143SecUserFullName);
         GxWebStd.gx_hidden_field( context, "Z144SecUserEmail", Z144SecUserEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z150SecUserStatus", Z150SecUserStatus);
         GxWebStd.gx_hidden_field( context, "Z142SecUserPassword", Z142SecUserPassword);
         GxWebStd.gx_boolean_hidden_field( context, "Z791SecUserAnalista", Z791SecUserAnalista);
         GxWebStd.gx_hidden_field( context, "Z146SecUserUpdateAt", context.localUtil.TToC( Z146SecUserUpdateAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z208SecUserTemp", Z208SecUserTemp);
         GxWebStd.gx_boolean_hidden_field( context, "Z209SecUserClienteAcesso", Z209SecUserClienteAcesso);
         GxWebStd.gx_hidden_field( context, "Z226SecUserOwnerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z226SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z147SecUserUserMan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z210SecUserClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N147SecUserUserMan", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N210SecUserClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N226SecUserOwnerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSERUSERMAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERUSERMAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSERCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSEROWNERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Insert_SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSEROWNERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERCREATEDAT", context.localUtil.TToC( A145SecUserCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERPASSWORD", A142SecUserPassword);
         GxWebStd.gx_hidden_field( context, "SECUSERUPDATEAT", context.localUtil.TToC( A146SecUserUpdateAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "SECUSERTEMP", A208SecUserTemp);
         GxWebStd.gx_boolean_hidden_field( context, "SECUSERCLIENTEACESSO", A209SecUserClienteAcesso);
         GxWebStd.gx_hidden_field( context, "SECUSERTESTE", A153SecUserTeste);
         GxWebStd.gx_hidden_field( context, "TIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERMANNAME", A148SecUserManName);
         GxWebStd.gx_hidden_field( context, "SECUSERMANFULLNAME", A149SecUserManFullName);
         GxWebStd.gx_hidden_field( context, "SECUSERCLIENTEFULLNAME", A211SecUserClienteFullName);
         GxWebStd.gx_boolean_hidden_field( context, "SECUSERCLIENTESTATUS", A212SecUserClienteStatus);
         GxWebStd.gx_boolean_hidden_field( context, "SECUSERCLICLIENTEACESSO", A213SecUserCliClienteAcesso);
         GxWebStd.gx_boolean_hidden_field( context, "TIPOCLIENTEPORTALPJPF", A793TipoClientePortalPjPf);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
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
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserId,4,0));
         return formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SecUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuário" ;
      }

      protected void InitializeNonKey0I22( )
      {
         A192TipoClienteId = 0;
         n192TipoClienteId = false;
         AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
         A147SecUserUserMan = 0;
         n147SecUserUserMan = false;
         AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
         A210SecUserClienteId = 0;
         n210SecUserClienteId = false;
         AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
         A226SecUserOwnerId = 0;
         n226SecUserOwnerId = false;
         AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         n145SecUserCreatedAt = false;
         AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
         A141SecUserName = "";
         n141SecUserName = false;
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         n141SecUserName = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? true : false);
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
         n143SecUserFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? true : false);
         A144SecUserEmail = "";
         n144SecUserEmail = false;
         AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
         n144SecUserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? true : false);
         A142SecUserPassword = "";
         n142SecUserPassword = false;
         AssignAttri("", false, "A142SecUserPassword", A142SecUserPassword);
         A791SecUserAnalista = false;
         n791SecUserAnalista = false;
         AssignAttri("", false, "A791SecUserAnalista", A791SecUserAnalista);
         n791SecUserAnalista = ((false==A791SecUserAnalista) ? true : false);
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         n146SecUserUpdateAt = false;
         AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
         A148SecUserManName = "";
         n148SecUserManName = false;
         AssignAttri("", false, "A148SecUserManName", A148SecUserManName);
         A149SecUserManFullName = "";
         n149SecUserManFullName = false;
         AssignAttri("", false, "A149SecUserManFullName", A149SecUserManFullName);
         A208SecUserTemp = false;
         n208SecUserTemp = false;
         AssignAttri("", false, "A208SecUserTemp", A208SecUserTemp);
         A209SecUserClienteAcesso = false;
         n209SecUserClienteAcesso = false;
         AssignAttri("", false, "A209SecUserClienteAcesso", A209SecUserClienteAcesso);
         A153SecUserTeste = "";
         n153SecUserTeste = false;
         AssignAttri("", false, "A153SecUserTeste", A153SecUserTeste);
         A211SecUserClienteFullName = "";
         n211SecUserClienteFullName = false;
         AssignAttri("", false, "A211SecUserClienteFullName", A211SecUserClienteFullName);
         A212SecUserClienteStatus = false;
         n212SecUserClienteStatus = false;
         AssignAttri("", false, "A212SecUserClienteStatus", A212SecUserClienteStatus);
         A213SecUserCliClienteAcesso = false;
         n213SecUserCliClienteAcesso = false;
         AssignAttri("", false, "A213SecUserCliClienteAcesso", A213SecUserCliClienteAcesso);
         A793TipoClientePortalPjPf = false;
         n793TipoClientePortalPjPf = false;
         AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         Z144SecUserEmail = "";
         Z150SecUserStatus = false;
         Z142SecUserPassword = "";
         Z791SecUserAnalista = false;
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z208SecUserTemp = false;
         Z209SecUserClienteAcesso = false;
         Z226SecUserOwnerId = 0;
         Z147SecUserUserMan = 0;
         Z210SecUserClienteId = 0;
      }

      protected void InitAll0I22( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         InitializeNonKey0I22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A145SecUserCreatedAt = i145SecUserCreatedAt;
         n145SecUserCreatedAt = false;
         AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
         A150SecUserStatus = i150SecUserStatus;
         n150SecUserStatus = false;
         AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101913723", true, true);
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
         context.AddJavascriptSource("secuser.js", "?20256101913724", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtSecUserEmail_Internalname = "SECUSEREMAIL";
         cmbSecUserStatus_Internalname = "SECUSERSTATUS";
         lblTextblocksecuseranalista_Internalname = "TEXTBLOCKSECUSERANALISTA";
         cmbSecUserAnalista_Internalname = "SECUSERANALISTA";
         lblSecuseranalista_righttext_Internalname = "SECUSERANALISTA_RIGHTTEXT";
         tblTablemergedsecuseranalista_Internalname = "TABLEMERGEDSECUSERANALISTA";
         divTablesplittedsecuseranalista_Internalname = "TABLESPLITTEDSECUSERANALISTA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtSecUserId_Internalname = "SECUSERID";
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
         Form.Caption = "Usuário";
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 0;
         edtSecUserId_Visible = 1;
         cmbSecUserAnalista_Jsonclick = "";
         cmbSecUserAnalista.Enabled = 1;
         cmbSecUserStatus_Jsonclick = "";
         cmbSecUserStatus.Enabled = 1;
         edtSecUserEmail_Jsonclick = "";
         edtSecUserEmail_Enabled = 1;
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Enabled = 1;
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
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
         cmbSecUserStatus.Name = "SECUSERSTATUS";
         cmbSecUserStatus.WebTags = "";
         cmbSecUserStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbSecUserStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbSecUserStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A150SecUserStatus) )
            {
               A150SecUserStatus = true;
               n150SecUserStatus = false;
               AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
            }
         }
         cmbSecUserAnalista.Name = "SECUSERANALISTA";
         cmbSecUserAnalista.WebTags = "";
         cmbSecUserAnalista.addItem(StringUtil.BoolToStr( false), "Não", 0);
         cmbSecUserAnalista.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         if ( cmbSecUserAnalista.ItemCount > 0 )
         {
            A791SecUserAnalista = StringUtil.StrToBool( cmbSecUserAnalista.getValidValue(StringUtil.BoolToStr( A791SecUserAnalista)));
            n791SecUserAnalista = false;
            AssignAttri("", false, "A791SecUserAnalista", A791SecUserAnalista);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SecUserId","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7SecUserId","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV20Insert_SecUserUserMan","fld":"vINSERT_SECUSERUSERMAN","pic":"ZZZ9","type":"int"},{"av":"AV22Insert_SecUserClienteId","fld":"vINSERT_SECUSERCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV23Insert_SecUserOwnerId","fld":"vINSERT_SECUSEROWNERID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A145SecUserCreatedAt","fld":"SECUSERCREATEDAT","pic":"99/99/9999 99:99","type":"dtime"},{"av":"A142SecUserPassword","fld":"SECUSERPASSWORD","type":"svchar"},{"av":"A146SecUserUpdateAt","fld":"SECUSERUPDATEAT","pic":"99/99/9999 99:99","type":"dtime"},{"av":"A208SecUserTemp","fld":"SECUSERTEMP","type":"boolean"},{"av":"A209SecUserClienteAcesso","fld":"SECUSERCLIENTEACESSO","type":"boolean"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120I2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_SECUSERNAME","""{"handler":"Valid_Secusername","iparms":[]}""");
         setEventMetadata("VALID_SECUSERFULLNAME","""{"handler":"Valid_Secuserfullname","iparms":[]}""");
         setEventMetadata("VALID_SECUSEREMAIL","""{"handler":"Valid_Secuseremail","iparms":[]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[]}""");
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         Z144SecUserEmail = "";
         Z142SecUserPassword = "";
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
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
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         lblTextblocksecuseranalista_Jsonclick = "";
         sStyleString = "";
         lblSecuseranalista_righttext_Jsonclick = "";
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         A142SecUserPassword = "";
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         A153SecUserTeste = "";
         A148SecUserManName = "";
         A149SecUserManFullName = "";
         A211SecUserClienteFullName = "";
         AV25Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode22 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV21TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z153SecUserTeste = "";
         Z148SecUserManName = "";
         Z149SecUserManFullName = "";
         Z211SecUserClienteFullName = "";
         T000I8_A192TipoClienteId = new short[1] ;
         T000I8_n192TipoClienteId = new bool[] {false} ;
         T000I8_A133SecUserId = new short[1] ;
         T000I8_n133SecUserId = new bool[] {false} ;
         T000I8_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000I8_n145SecUserCreatedAt = new bool[] {false} ;
         T000I8_A141SecUserName = new string[] {""} ;
         T000I8_n141SecUserName = new bool[] {false} ;
         T000I8_A143SecUserFullName = new string[] {""} ;
         T000I8_n143SecUserFullName = new bool[] {false} ;
         T000I8_A144SecUserEmail = new string[] {""} ;
         T000I8_n144SecUserEmail = new bool[] {false} ;
         T000I8_A150SecUserStatus = new bool[] {false} ;
         T000I8_n150SecUserStatus = new bool[] {false} ;
         T000I8_A142SecUserPassword = new string[] {""} ;
         T000I8_n142SecUserPassword = new bool[] {false} ;
         T000I8_A791SecUserAnalista = new bool[] {false} ;
         T000I8_n791SecUserAnalista = new bool[] {false} ;
         T000I8_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T000I8_n146SecUserUpdateAt = new bool[] {false} ;
         T000I8_A148SecUserManName = new string[] {""} ;
         T000I8_n148SecUserManName = new bool[] {false} ;
         T000I8_A149SecUserManFullName = new string[] {""} ;
         T000I8_n149SecUserManFullName = new bool[] {false} ;
         T000I8_A208SecUserTemp = new bool[] {false} ;
         T000I8_n208SecUserTemp = new bool[] {false} ;
         T000I8_A209SecUserClienteAcesso = new bool[] {false} ;
         T000I8_n209SecUserClienteAcesso = new bool[] {false} ;
         T000I8_A153SecUserTeste = new string[] {""} ;
         T000I8_n153SecUserTeste = new bool[] {false} ;
         T000I8_A211SecUserClienteFullName = new string[] {""} ;
         T000I8_n211SecUserClienteFullName = new bool[] {false} ;
         T000I8_A212SecUserClienteStatus = new bool[] {false} ;
         T000I8_n212SecUserClienteStatus = new bool[] {false} ;
         T000I8_A213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I8_n213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I8_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000I8_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000I8_A226SecUserOwnerId = new int[1] ;
         T000I8_n226SecUserOwnerId = new bool[] {false} ;
         T000I8_A147SecUserUserMan = new short[1] ;
         T000I8_n147SecUserUserMan = new bool[] {false} ;
         T000I8_A210SecUserClienteId = new short[1] ;
         T000I8_n210SecUserClienteId = new bool[] {false} ;
         T000I4_A192TipoClienteId = new short[1] ;
         T000I4_n192TipoClienteId = new bool[] {false} ;
         T000I7_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000I7_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000I5_A148SecUserManName = new string[] {""} ;
         T000I5_n148SecUserManName = new bool[] {false} ;
         T000I5_A149SecUserManFullName = new string[] {""} ;
         T000I5_n149SecUserManFullName = new bool[] {false} ;
         T000I6_A211SecUserClienteFullName = new string[] {""} ;
         T000I6_n211SecUserClienteFullName = new bool[] {false} ;
         T000I6_A212SecUserClienteStatus = new bool[] {false} ;
         T000I6_n212SecUserClienteStatus = new bool[] {false} ;
         T000I6_A213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I6_n213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I9_A192TipoClienteId = new short[1] ;
         T000I9_n192TipoClienteId = new bool[] {false} ;
         T000I10_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000I10_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000I11_A148SecUserManName = new string[] {""} ;
         T000I11_n148SecUserManName = new bool[] {false} ;
         T000I11_A149SecUserManFullName = new string[] {""} ;
         T000I11_n149SecUserManFullName = new bool[] {false} ;
         T000I12_A211SecUserClienteFullName = new string[] {""} ;
         T000I12_n211SecUserClienteFullName = new bool[] {false} ;
         T000I12_A212SecUserClienteStatus = new bool[] {false} ;
         T000I12_n212SecUserClienteStatus = new bool[] {false} ;
         T000I12_A213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I12_n213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I13_A133SecUserId = new short[1] ;
         T000I13_n133SecUserId = new bool[] {false} ;
         T000I3_A133SecUserId = new short[1] ;
         T000I3_n133SecUserId = new bool[] {false} ;
         T000I3_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000I3_n145SecUserCreatedAt = new bool[] {false} ;
         T000I3_A141SecUserName = new string[] {""} ;
         T000I3_n141SecUserName = new bool[] {false} ;
         T000I3_A143SecUserFullName = new string[] {""} ;
         T000I3_n143SecUserFullName = new bool[] {false} ;
         T000I3_A144SecUserEmail = new string[] {""} ;
         T000I3_n144SecUserEmail = new bool[] {false} ;
         T000I3_A150SecUserStatus = new bool[] {false} ;
         T000I3_n150SecUserStatus = new bool[] {false} ;
         T000I3_A142SecUserPassword = new string[] {""} ;
         T000I3_n142SecUserPassword = new bool[] {false} ;
         T000I3_A791SecUserAnalista = new bool[] {false} ;
         T000I3_n791SecUserAnalista = new bool[] {false} ;
         T000I3_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T000I3_n146SecUserUpdateAt = new bool[] {false} ;
         T000I3_A208SecUserTemp = new bool[] {false} ;
         T000I3_n208SecUserTemp = new bool[] {false} ;
         T000I3_A209SecUserClienteAcesso = new bool[] {false} ;
         T000I3_n209SecUserClienteAcesso = new bool[] {false} ;
         T000I3_A153SecUserTeste = new string[] {""} ;
         T000I3_n153SecUserTeste = new bool[] {false} ;
         T000I3_A226SecUserOwnerId = new int[1] ;
         T000I3_n226SecUserOwnerId = new bool[] {false} ;
         T000I3_A147SecUserUserMan = new short[1] ;
         T000I3_n147SecUserUserMan = new bool[] {false} ;
         T000I3_A210SecUserClienteId = new short[1] ;
         T000I3_n210SecUserClienteId = new bool[] {false} ;
         T000I14_A133SecUserId = new short[1] ;
         T000I14_n133SecUserId = new bool[] {false} ;
         T000I15_A133SecUserId = new short[1] ;
         T000I15_n133SecUserId = new bool[] {false} ;
         T000I2_A133SecUserId = new short[1] ;
         T000I2_n133SecUserId = new bool[] {false} ;
         T000I2_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000I2_n145SecUserCreatedAt = new bool[] {false} ;
         T000I2_A141SecUserName = new string[] {""} ;
         T000I2_n141SecUserName = new bool[] {false} ;
         T000I2_A143SecUserFullName = new string[] {""} ;
         T000I2_n143SecUserFullName = new bool[] {false} ;
         T000I2_A144SecUserEmail = new string[] {""} ;
         T000I2_n144SecUserEmail = new bool[] {false} ;
         T000I2_A150SecUserStatus = new bool[] {false} ;
         T000I2_n150SecUserStatus = new bool[] {false} ;
         T000I2_A142SecUserPassword = new string[] {""} ;
         T000I2_n142SecUserPassword = new bool[] {false} ;
         T000I2_A791SecUserAnalista = new bool[] {false} ;
         T000I2_n791SecUserAnalista = new bool[] {false} ;
         T000I2_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T000I2_n146SecUserUpdateAt = new bool[] {false} ;
         T000I2_A208SecUserTemp = new bool[] {false} ;
         T000I2_n208SecUserTemp = new bool[] {false} ;
         T000I2_A209SecUserClienteAcesso = new bool[] {false} ;
         T000I2_n209SecUserClienteAcesso = new bool[] {false} ;
         T000I2_A153SecUserTeste = new string[] {""} ;
         T000I2_n153SecUserTeste = new bool[] {false} ;
         T000I2_A226SecUserOwnerId = new int[1] ;
         T000I2_n226SecUserOwnerId = new bool[] {false} ;
         T000I2_A147SecUserUserMan = new short[1] ;
         T000I2_n147SecUserUserMan = new bool[] {false} ;
         T000I2_A210SecUserClienteId = new short[1] ;
         T000I2_n210SecUserClienteId = new bool[] {false} ;
         T000I17_A133SecUserId = new short[1] ;
         T000I17_n133SecUserId = new bool[] {false} ;
         T000I20_A192TipoClienteId = new short[1] ;
         T000I20_n192TipoClienteId = new bool[] {false} ;
         T000I21_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000I21_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000I22_A148SecUserManName = new string[] {""} ;
         T000I22_n148SecUserManName = new bool[] {false} ;
         T000I22_A149SecUserManFullName = new string[] {""} ;
         T000I22_n149SecUserManFullName = new bool[] {false} ;
         T000I23_A211SecUserClienteFullName = new string[] {""} ;
         T000I23_n211SecUserClienteFullName = new bool[] {false} ;
         T000I23_A212SecUserClienteStatus = new bool[] {false} ;
         T000I23_n212SecUserClienteStatus = new bool[] {false} ;
         T000I23_A213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I23_n213SecUserCliClienteAcesso = new bool[] {false} ;
         T000I24_A210SecUserClienteId = new short[1] ;
         T000I24_n210SecUserClienteId = new bool[] {false} ;
         T000I25_A147SecUserUserMan = new short[1] ;
         T000I25_n147SecUserUserMan = new bool[] {false} ;
         T000I26_A961ChavePIXId = new int[1] ;
         T000I27_A961ChavePIXId = new int[1] ;
         T000I28_A951ContaBancariaId = new int[1] ;
         T000I29_A951ContaBancariaId = new int[1] ;
         T000I30_A938AgenciaId = new int[1] ;
         T000I31_A938AgenciaId = new int[1] ;
         T000I32_A863TaxasId = new int[1] ;
         T000I33_A863TaxasId = new int[1] ;
         T000I34_A856CreditoId = new int[1] ;
         T000I35_A856CreditoId = new int[1] ;
         T000I36_A746ReembolsoFlowLogId = new int[1] ;
         T000I37_A599ClienteDocumentoId = new int[1] ;
         T000I38_A457EspecialidadeId = new int[1] ;
         T000I39_A518ReembolsoId = new int[1] ;
         T000I40_A387UserNotificationId = new int[1] ;
         T000I41_A323PropostaId = new int[1] ;
         T000I42_A559SecUserLogId = new int[1] ;
         T000I43_A478ConfiguracoesTestemunhasId = new int[1] ;
         T000I44_A381NotificationId = new int[1] ;
         T000I45_A375AprovadoresId = new int[1] ;
         T000I46_A164SecUserTokenID = new short[1] ;
         T000I47_A133SecUserId = new short[1] ;
         T000I47_n133SecUserId = new bool[] {false} ;
         T000I47_A131SecRoleId = new short[1] ;
         T000I48_A133SecUserId = new short[1] ;
         T000I48_n133SecUserId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuser__default(),
            new Object[][] {
                new Object[] {
               T000I2_A133SecUserId, T000I2_A145SecUserCreatedAt, T000I2_n145SecUserCreatedAt, T000I2_A141SecUserName, T000I2_n141SecUserName, T000I2_A143SecUserFullName, T000I2_n143SecUserFullName, T000I2_A144SecUserEmail, T000I2_n144SecUserEmail, T000I2_A150SecUserStatus,
               T000I2_n150SecUserStatus, T000I2_A142SecUserPassword, T000I2_n142SecUserPassword, T000I2_A791SecUserAnalista, T000I2_n791SecUserAnalista, T000I2_A146SecUserUpdateAt, T000I2_n146SecUserUpdateAt, T000I2_A208SecUserTemp, T000I2_n208SecUserTemp, T000I2_A209SecUserClienteAcesso,
               T000I2_n209SecUserClienteAcesso, T000I2_A153SecUserTeste, T000I2_n153SecUserTeste, T000I2_A226SecUserOwnerId, T000I2_n226SecUserOwnerId, T000I2_A147SecUserUserMan, T000I2_n147SecUserUserMan, T000I2_A210SecUserClienteId, T000I2_n210SecUserClienteId
               }
               , new Object[] {
               T000I3_A133SecUserId, T000I3_A145SecUserCreatedAt, T000I3_n145SecUserCreatedAt, T000I3_A141SecUserName, T000I3_n141SecUserName, T000I3_A143SecUserFullName, T000I3_n143SecUserFullName, T000I3_A144SecUserEmail, T000I3_n144SecUserEmail, T000I3_A150SecUserStatus,
               T000I3_n150SecUserStatus, T000I3_A142SecUserPassword, T000I3_n142SecUserPassword, T000I3_A791SecUserAnalista, T000I3_n791SecUserAnalista, T000I3_A146SecUserUpdateAt, T000I3_n146SecUserUpdateAt, T000I3_A208SecUserTemp, T000I3_n208SecUserTemp, T000I3_A209SecUserClienteAcesso,
               T000I3_n209SecUserClienteAcesso, T000I3_A153SecUserTeste, T000I3_n153SecUserTeste, T000I3_A226SecUserOwnerId, T000I3_n226SecUserOwnerId, T000I3_A147SecUserUserMan, T000I3_n147SecUserUserMan, T000I3_A210SecUserClienteId, T000I3_n210SecUserClienteId
               }
               , new Object[] {
               T000I4_A192TipoClienteId, T000I4_n192TipoClienteId
               }
               , new Object[] {
               T000I5_A148SecUserManName, T000I5_n148SecUserManName, T000I5_A149SecUserManFullName, T000I5_n149SecUserManFullName
               }
               , new Object[] {
               T000I6_A211SecUserClienteFullName, T000I6_n211SecUserClienteFullName, T000I6_A212SecUserClienteStatus, T000I6_n212SecUserClienteStatus, T000I6_A213SecUserCliClienteAcesso, T000I6_n213SecUserCliClienteAcesso
               }
               , new Object[] {
               T000I7_A793TipoClientePortalPjPf, T000I7_n793TipoClientePortalPjPf
               }
               , new Object[] {
               T000I8_A192TipoClienteId, T000I8_n192TipoClienteId, T000I8_A133SecUserId, T000I8_A145SecUserCreatedAt, T000I8_n145SecUserCreatedAt, T000I8_A141SecUserName, T000I8_n141SecUserName, T000I8_A143SecUserFullName, T000I8_n143SecUserFullName, T000I8_A144SecUserEmail,
               T000I8_n144SecUserEmail, T000I8_A150SecUserStatus, T000I8_n150SecUserStatus, T000I8_A142SecUserPassword, T000I8_n142SecUserPassword, T000I8_A791SecUserAnalista, T000I8_n791SecUserAnalista, T000I8_A146SecUserUpdateAt, T000I8_n146SecUserUpdateAt, T000I8_A148SecUserManName,
               T000I8_n148SecUserManName, T000I8_A149SecUserManFullName, T000I8_n149SecUserManFullName, T000I8_A208SecUserTemp, T000I8_n208SecUserTemp, T000I8_A209SecUserClienteAcesso, T000I8_n209SecUserClienteAcesso, T000I8_A153SecUserTeste, T000I8_n153SecUserTeste, T000I8_A211SecUserClienteFullName,
               T000I8_n211SecUserClienteFullName, T000I8_A212SecUserClienteStatus, T000I8_n212SecUserClienteStatus, T000I8_A213SecUserCliClienteAcesso, T000I8_n213SecUserCliClienteAcesso, T000I8_A793TipoClientePortalPjPf, T000I8_n793TipoClientePortalPjPf, T000I8_A226SecUserOwnerId, T000I8_n226SecUserOwnerId, T000I8_A147SecUserUserMan,
               T000I8_n147SecUserUserMan, T000I8_A210SecUserClienteId, T000I8_n210SecUserClienteId
               }
               , new Object[] {
               T000I9_A192TipoClienteId, T000I9_n192TipoClienteId
               }
               , new Object[] {
               T000I10_A793TipoClientePortalPjPf, T000I10_n793TipoClientePortalPjPf
               }
               , new Object[] {
               T000I11_A148SecUserManName, T000I11_n148SecUserManName, T000I11_A149SecUserManFullName, T000I11_n149SecUserManFullName
               }
               , new Object[] {
               T000I12_A211SecUserClienteFullName, T000I12_n211SecUserClienteFullName, T000I12_A212SecUserClienteStatus, T000I12_n212SecUserClienteStatus, T000I12_A213SecUserCliClienteAcesso, T000I12_n213SecUserCliClienteAcesso
               }
               , new Object[] {
               T000I13_A133SecUserId
               }
               , new Object[] {
               T000I14_A133SecUserId
               }
               , new Object[] {
               T000I15_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               T000I17_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I20_A192TipoClienteId, T000I20_n192TipoClienteId
               }
               , new Object[] {
               T000I21_A793TipoClientePortalPjPf, T000I21_n793TipoClientePortalPjPf
               }
               , new Object[] {
               T000I22_A148SecUserManName, T000I22_n148SecUserManName, T000I22_A149SecUserManFullName, T000I22_n149SecUserManFullName
               }
               , new Object[] {
               T000I23_A211SecUserClienteFullName, T000I23_n211SecUserClienteFullName, T000I23_A212SecUserClienteStatus, T000I23_n212SecUserClienteStatus, T000I23_A213SecUserCliClienteAcesso, T000I23_n213SecUserCliClienteAcesso
               }
               , new Object[] {
               T000I24_A210SecUserClienteId
               }
               , new Object[] {
               T000I25_A147SecUserUserMan
               }
               , new Object[] {
               T000I26_A961ChavePIXId
               }
               , new Object[] {
               T000I27_A961ChavePIXId
               }
               , new Object[] {
               T000I28_A951ContaBancariaId
               }
               , new Object[] {
               T000I29_A951ContaBancariaId
               }
               , new Object[] {
               T000I30_A938AgenciaId
               }
               , new Object[] {
               T000I31_A938AgenciaId
               }
               , new Object[] {
               T000I32_A863TaxasId
               }
               , new Object[] {
               T000I33_A863TaxasId
               }
               , new Object[] {
               T000I34_A856CreditoId
               }
               , new Object[] {
               T000I35_A856CreditoId
               }
               , new Object[] {
               T000I36_A746ReembolsoFlowLogId
               }
               , new Object[] {
               T000I37_A599ClienteDocumentoId
               }
               , new Object[] {
               T000I38_A457EspecialidadeId
               }
               , new Object[] {
               T000I39_A518ReembolsoId
               }
               , new Object[] {
               T000I40_A387UserNotificationId
               }
               , new Object[] {
               T000I41_A323PropostaId
               }
               , new Object[] {
               T000I42_A559SecUserLogId
               }
               , new Object[] {
               T000I43_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               T000I44_A381NotificationId
               }
               , new Object[] {
               T000I45_A375AprovadoresId
               }
               , new Object[] {
               T000I46_A164SecUserTokenID
               }
               , new Object[] {
               T000I47_A133SecUserId, T000I47_A131SecRoleId
               }
               , new Object[] {
               T000I48_A133SecUserId
               }
            }
         );
         AV25Pgmname = "SecUser";
         Z150SecUserStatus = true;
         n150SecUserStatus = false;
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         i150SecUserStatus = true;
         n150SecUserStatus = false;
      }

      private short wcpOAV7SecUserId ;
      private short Z133SecUserId ;
      private short Z147SecUserUserMan ;
      private short Z210SecUserClienteId ;
      private short N147SecUserUserMan ;
      private short N210SecUserClienteId ;
      private short GxWebError ;
      private short A192TipoClienteId ;
      private short A147SecUserUserMan ;
      private short A210SecUserClienteId ;
      private short AV7SecUserId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A133SecUserId ;
      private short AV20Insert_SecUserUserMan ;
      private short AV22Insert_SecUserClienteId ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short Z192TipoClienteId ;
      private short gxajaxcallmode ;
      private int Z226SecUserOwnerId ;
      private int N226SecUserOwnerId ;
      private int A226SecUserOwnerId ;
      private int trnEnded ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtSecUserEmail_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserId_Visible ;
      private int AV23Insert_SecUserOwnerId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
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
      private string edtSecUserName_Internalname ;
      private string cmbSecUserStatus_Internalname ;
      private string cmbSecUserAnalista_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtSecUserEmail_Internalname ;
      private string edtSecUserEmail_Jsonclick ;
      private string cmbSecUserStatus_Jsonclick ;
      private string divTablesplittedsecuseranalista_Internalname ;
      private string lblTextblocksecuseranalista_Internalname ;
      private string lblTextblocksecuseranalista_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedsecuseranalista_Internalname ;
      private string cmbSecUserAnalista_Jsonclick ;
      private string lblSecuseranalista_righttext_Internalname ;
      private string lblSecuseranalista_righttext_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserId_Jsonclick ;
      private string AV25Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode22 ;
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
      private DateTime Z145SecUserCreatedAt ;
      private DateTime Z146SecUserUpdateAt ;
      private DateTime A145SecUserCreatedAt ;
      private DateTime A146SecUserUpdateAt ;
      private DateTime i145SecUserCreatedAt ;
      private bool Z150SecUserStatus ;
      private bool Z791SecUserAnalista ;
      private bool Z208SecUserTemp ;
      private bool Z209SecUserClienteAcesso ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n226SecUserOwnerId ;
      private bool n192TipoClienteId ;
      private bool n147SecUserUserMan ;
      private bool n210SecUserClienteId ;
      private bool wbErr ;
      private bool A150SecUserStatus ;
      private bool n150SecUserStatus ;
      private bool A791SecUserAnalista ;
      private bool n791SecUserAnalista ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n145SecUserCreatedAt ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n144SecUserEmail ;
      private bool n142SecUserPassword ;
      private bool n146SecUserUpdateAt ;
      private bool n208SecUserTemp ;
      private bool A208SecUserTemp ;
      private bool n209SecUserClienteAcesso ;
      private bool A209SecUserClienteAcesso ;
      private bool n153SecUserTeste ;
      private bool n148SecUserManName ;
      private bool n149SecUserManFullName ;
      private bool n211SecUserClienteFullName ;
      private bool A212SecUserClienteStatus ;
      private bool n212SecUserClienteStatus ;
      private bool A213SecUserCliClienteAcesso ;
      private bool n213SecUserCliClienteAcesso ;
      private bool A793TipoClientePortalPjPf ;
      private bool n793TipoClientePortalPjPf ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n133SecUserId ;
      private bool returnInSub ;
      private bool Z793TipoClientePortalPjPf ;
      private bool Z212SecUserClienteStatus ;
      private bool Z213SecUserCliClienteAcesso ;
      private bool Gx_longc ;
      private bool i150SecUserStatus ;
      private string A153SecUserTeste ;
      private string Z153SecUserTeste ;
      private string Z141SecUserName ;
      private string Z143SecUserFullName ;
      private string Z144SecUserEmail ;
      private string Z142SecUserPassword ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string A142SecUserPassword ;
      private string A148SecUserManName ;
      private string A149SecUserManFullName ;
      private string A211SecUserClienteFullName ;
      private string Z148SecUserManName ;
      private string Z149SecUserManFullName ;
      private string Z211SecUserClienteFullName ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSecUserStatus ;
      private GXCombobox cmbSecUserAnalista ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T000I8_A192TipoClienteId ;
      private bool[] T000I8_n192TipoClienteId ;
      private short[] T000I8_A133SecUserId ;
      private bool[] T000I8_n133SecUserId ;
      private DateTime[] T000I8_A145SecUserCreatedAt ;
      private bool[] T000I8_n145SecUserCreatedAt ;
      private string[] T000I8_A141SecUserName ;
      private bool[] T000I8_n141SecUserName ;
      private string[] T000I8_A143SecUserFullName ;
      private bool[] T000I8_n143SecUserFullName ;
      private string[] T000I8_A144SecUserEmail ;
      private bool[] T000I8_n144SecUserEmail ;
      private bool[] T000I8_A150SecUserStatus ;
      private bool[] T000I8_n150SecUserStatus ;
      private string[] T000I8_A142SecUserPassword ;
      private bool[] T000I8_n142SecUserPassword ;
      private bool[] T000I8_A791SecUserAnalista ;
      private bool[] T000I8_n791SecUserAnalista ;
      private DateTime[] T000I8_A146SecUserUpdateAt ;
      private bool[] T000I8_n146SecUserUpdateAt ;
      private string[] T000I8_A148SecUserManName ;
      private bool[] T000I8_n148SecUserManName ;
      private string[] T000I8_A149SecUserManFullName ;
      private bool[] T000I8_n149SecUserManFullName ;
      private bool[] T000I8_A208SecUserTemp ;
      private bool[] T000I8_n208SecUserTemp ;
      private bool[] T000I8_A209SecUserClienteAcesso ;
      private bool[] T000I8_n209SecUserClienteAcesso ;
      private string[] T000I8_A153SecUserTeste ;
      private bool[] T000I8_n153SecUserTeste ;
      private string[] T000I8_A211SecUserClienteFullName ;
      private bool[] T000I8_n211SecUserClienteFullName ;
      private bool[] T000I8_A212SecUserClienteStatus ;
      private bool[] T000I8_n212SecUserClienteStatus ;
      private bool[] T000I8_A213SecUserCliClienteAcesso ;
      private bool[] T000I8_n213SecUserCliClienteAcesso ;
      private bool[] T000I8_A793TipoClientePortalPjPf ;
      private bool[] T000I8_n793TipoClientePortalPjPf ;
      private int[] T000I8_A226SecUserOwnerId ;
      private bool[] T000I8_n226SecUserOwnerId ;
      private short[] T000I8_A147SecUserUserMan ;
      private bool[] T000I8_n147SecUserUserMan ;
      private short[] T000I8_A210SecUserClienteId ;
      private bool[] T000I8_n210SecUserClienteId ;
      private short[] T000I4_A192TipoClienteId ;
      private bool[] T000I4_n192TipoClienteId ;
      private bool[] T000I7_A793TipoClientePortalPjPf ;
      private bool[] T000I7_n793TipoClientePortalPjPf ;
      private string[] T000I5_A148SecUserManName ;
      private bool[] T000I5_n148SecUserManName ;
      private string[] T000I5_A149SecUserManFullName ;
      private bool[] T000I5_n149SecUserManFullName ;
      private string[] T000I6_A211SecUserClienteFullName ;
      private bool[] T000I6_n211SecUserClienteFullName ;
      private bool[] T000I6_A212SecUserClienteStatus ;
      private bool[] T000I6_n212SecUserClienteStatus ;
      private bool[] T000I6_A213SecUserCliClienteAcesso ;
      private bool[] T000I6_n213SecUserCliClienteAcesso ;
      private short[] T000I9_A192TipoClienteId ;
      private bool[] T000I9_n192TipoClienteId ;
      private bool[] T000I10_A793TipoClientePortalPjPf ;
      private bool[] T000I10_n793TipoClientePortalPjPf ;
      private string[] T000I11_A148SecUserManName ;
      private bool[] T000I11_n148SecUserManName ;
      private string[] T000I11_A149SecUserManFullName ;
      private bool[] T000I11_n149SecUserManFullName ;
      private string[] T000I12_A211SecUserClienteFullName ;
      private bool[] T000I12_n211SecUserClienteFullName ;
      private bool[] T000I12_A212SecUserClienteStatus ;
      private bool[] T000I12_n212SecUserClienteStatus ;
      private bool[] T000I12_A213SecUserCliClienteAcesso ;
      private bool[] T000I12_n213SecUserCliClienteAcesso ;
      private short[] T000I13_A133SecUserId ;
      private bool[] T000I13_n133SecUserId ;
      private short[] T000I3_A133SecUserId ;
      private bool[] T000I3_n133SecUserId ;
      private DateTime[] T000I3_A145SecUserCreatedAt ;
      private bool[] T000I3_n145SecUserCreatedAt ;
      private string[] T000I3_A141SecUserName ;
      private bool[] T000I3_n141SecUserName ;
      private string[] T000I3_A143SecUserFullName ;
      private bool[] T000I3_n143SecUserFullName ;
      private string[] T000I3_A144SecUserEmail ;
      private bool[] T000I3_n144SecUserEmail ;
      private bool[] T000I3_A150SecUserStatus ;
      private bool[] T000I3_n150SecUserStatus ;
      private string[] T000I3_A142SecUserPassword ;
      private bool[] T000I3_n142SecUserPassword ;
      private bool[] T000I3_A791SecUserAnalista ;
      private bool[] T000I3_n791SecUserAnalista ;
      private DateTime[] T000I3_A146SecUserUpdateAt ;
      private bool[] T000I3_n146SecUserUpdateAt ;
      private bool[] T000I3_A208SecUserTemp ;
      private bool[] T000I3_n208SecUserTemp ;
      private bool[] T000I3_A209SecUserClienteAcesso ;
      private bool[] T000I3_n209SecUserClienteAcesso ;
      private string[] T000I3_A153SecUserTeste ;
      private bool[] T000I3_n153SecUserTeste ;
      private int[] T000I3_A226SecUserOwnerId ;
      private bool[] T000I3_n226SecUserOwnerId ;
      private short[] T000I3_A147SecUserUserMan ;
      private bool[] T000I3_n147SecUserUserMan ;
      private short[] T000I3_A210SecUserClienteId ;
      private bool[] T000I3_n210SecUserClienteId ;
      private short[] T000I14_A133SecUserId ;
      private bool[] T000I14_n133SecUserId ;
      private short[] T000I15_A133SecUserId ;
      private bool[] T000I15_n133SecUserId ;
      private short[] T000I2_A133SecUserId ;
      private bool[] T000I2_n133SecUserId ;
      private DateTime[] T000I2_A145SecUserCreatedAt ;
      private bool[] T000I2_n145SecUserCreatedAt ;
      private string[] T000I2_A141SecUserName ;
      private bool[] T000I2_n141SecUserName ;
      private string[] T000I2_A143SecUserFullName ;
      private bool[] T000I2_n143SecUserFullName ;
      private string[] T000I2_A144SecUserEmail ;
      private bool[] T000I2_n144SecUserEmail ;
      private bool[] T000I2_A150SecUserStatus ;
      private bool[] T000I2_n150SecUserStatus ;
      private string[] T000I2_A142SecUserPassword ;
      private bool[] T000I2_n142SecUserPassword ;
      private bool[] T000I2_A791SecUserAnalista ;
      private bool[] T000I2_n791SecUserAnalista ;
      private DateTime[] T000I2_A146SecUserUpdateAt ;
      private bool[] T000I2_n146SecUserUpdateAt ;
      private bool[] T000I2_A208SecUserTemp ;
      private bool[] T000I2_n208SecUserTemp ;
      private bool[] T000I2_A209SecUserClienteAcesso ;
      private bool[] T000I2_n209SecUserClienteAcesso ;
      private string[] T000I2_A153SecUserTeste ;
      private bool[] T000I2_n153SecUserTeste ;
      private int[] T000I2_A226SecUserOwnerId ;
      private bool[] T000I2_n226SecUserOwnerId ;
      private short[] T000I2_A147SecUserUserMan ;
      private bool[] T000I2_n147SecUserUserMan ;
      private short[] T000I2_A210SecUserClienteId ;
      private bool[] T000I2_n210SecUserClienteId ;
      private short[] T000I17_A133SecUserId ;
      private bool[] T000I17_n133SecUserId ;
      private short[] T000I20_A192TipoClienteId ;
      private bool[] T000I20_n192TipoClienteId ;
      private bool[] T000I21_A793TipoClientePortalPjPf ;
      private bool[] T000I21_n793TipoClientePortalPjPf ;
      private string[] T000I22_A148SecUserManName ;
      private bool[] T000I22_n148SecUserManName ;
      private string[] T000I22_A149SecUserManFullName ;
      private bool[] T000I22_n149SecUserManFullName ;
      private string[] T000I23_A211SecUserClienteFullName ;
      private bool[] T000I23_n211SecUserClienteFullName ;
      private bool[] T000I23_A212SecUserClienteStatus ;
      private bool[] T000I23_n212SecUserClienteStatus ;
      private bool[] T000I23_A213SecUserCliClienteAcesso ;
      private bool[] T000I23_n213SecUserCliClienteAcesso ;
      private short[] T000I24_A210SecUserClienteId ;
      private bool[] T000I24_n210SecUserClienteId ;
      private short[] T000I25_A147SecUserUserMan ;
      private bool[] T000I25_n147SecUserUserMan ;
      private int[] T000I26_A961ChavePIXId ;
      private int[] T000I27_A961ChavePIXId ;
      private int[] T000I28_A951ContaBancariaId ;
      private int[] T000I29_A951ContaBancariaId ;
      private int[] T000I30_A938AgenciaId ;
      private int[] T000I31_A938AgenciaId ;
      private int[] T000I32_A863TaxasId ;
      private int[] T000I33_A863TaxasId ;
      private int[] T000I34_A856CreditoId ;
      private int[] T000I35_A856CreditoId ;
      private int[] T000I36_A746ReembolsoFlowLogId ;
      private int[] T000I37_A599ClienteDocumentoId ;
      private int[] T000I38_A457EspecialidadeId ;
      private int[] T000I39_A518ReembolsoId ;
      private int[] T000I40_A387UserNotificationId ;
      private int[] T000I41_A323PropostaId ;
      private int[] T000I42_A559SecUserLogId ;
      private int[] T000I43_A478ConfiguracoesTestemunhasId ;
      private int[] T000I44_A381NotificationId ;
      private int[] T000I45_A375AprovadoresId ;
      private short[] T000I46_A164SecUserTokenID ;
      private short[] T000I47_A133SecUserId ;
      private bool[] T000I47_n133SecUserId ;
      private short[] T000I47_A131SecRoleId ;
      private short[] T000I48_A133SecUserId ;
      private bool[] T000I48_n133SecUserId ;
   }

   public class secuser__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
         ,new ForEachCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new ForEachCursor(def[46])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000I2;
          prmT000I2 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I3;
          prmT000I3 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I4;
          prmT000I4 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000I5;
          prmT000I5 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I6;
          prmT000I6 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I7;
          prmT000I7 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I8;
          prmT000I8 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I9;
          prmT000I9 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000I10;
          prmT000I10 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I11;
          prmT000I11 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I12;
          prmT000I12 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I13;
          prmT000I13 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I14;
          prmT000I14 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I15;
          prmT000I15 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I16;
          prmT000I16 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserPassword",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserAnalista",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserTemp",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserClienteAcesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserTeste",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I17;
          prmT000I17 = new Object[] {
          };
          Object[] prmT000I18;
          prmT000I18 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserPassword",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserAnalista",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserTemp",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserClienteAcesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserTeste",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I19;
          prmT000I19 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I20;
          prmT000I20 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000I21;
          prmT000I21 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I22;
          prmT000I22 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I23;
          prmT000I23 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I24;
          prmT000I24 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I25;
          prmT000I25 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I26;
          prmT000I26 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I27;
          prmT000I27 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I28;
          prmT000I28 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I29;
          prmT000I29 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I30;
          prmT000I30 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I31;
          prmT000I31 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I32;
          prmT000I32 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I33;
          prmT000I33 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I34;
          prmT000I34 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I35;
          prmT000I35 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I36;
          prmT000I36 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I37;
          prmT000I37 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I38;
          prmT000I38 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I39;
          prmT000I39 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I40;
          prmT000I40 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I41;
          prmT000I41 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I42;
          prmT000I42 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I43;
          prmT000I43 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I44;
          prmT000I44 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I45;
          prmT000I45 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I46;
          prmT000I46 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I47;
          prmT000I47 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000I48;
          prmT000I48 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000I2", "SELECT SecUserId, SecUserCreatedAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserAnalista, SecUserUpdateAt, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId  FOR UPDATE OF SecUser NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I3", "SELECT SecUserId, SecUserCreatedAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserAnalista, SecUserUpdateAt, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I4", "SELECT TipoClienteId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I5", "SELECT SecUserName AS SecUserManName, SecUserFullName AS SecUserManFullName FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I6", "SELECT SecUserFullName AS SecUserClienteFullName, SecUserStatus AS SecUserClienteStatus, SecUserClienteAcesso AS SecUserCliClienteAcesso FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I7", "SELECT TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I8", "SELECT T2.TipoClienteId, TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserName, TM1.SecUserFullName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserPassword, TM1.SecUserAnalista, TM1.SecUserUpdateAt, T4.SecUserName AS SecUserManName, T4.SecUserFullName AS SecUserManFullName, TM1.SecUserTemp, TM1.SecUserClienteAcesso, TM1.SecUserTeste, T5.SecUserFullName AS SecUserClienteFullName, T5.SecUserStatus AS SecUserClienteStatus, T5.SecUserClienteAcesso AS SecUserCliClienteAcesso, T3.TipoClientePortalPjPf, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM ((((SecUser TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.SecUserOwnerId) LEFT JOIN TipoCliente T3 ON T3.TipoClienteId = T2.TipoClienteId) LEFT JOIN SecUser T4 ON T4.SecUserId = TM1.SecUserUserMan) LEFT JOIN SecUser T5 ON T5.SecUserId = TM1.SecUserClienteId) WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I9", "SELECT TipoClienteId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I10", "SELECT TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I11", "SELECT SecUserName AS SecUserManName, SecUserFullName AS SecUserManFullName FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I12", "SELECT SecUserFullName AS SecUserClienteFullName, SecUserStatus AS SecUserClienteStatus, SecUserClienteAcesso AS SecUserCliClienteAcesso FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I13", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I14", "SELECT SecUserId FROM SecUser WHERE ( SecUserId > :SecUserId) ORDER BY SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I15", "SELECT SecUserId FROM SecUser WHERE ( SecUserId < :SecUserId) ORDER BY SecUserId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I16", "SAVEPOINT gxupdate;INSERT INTO SecUser(SecUserCreatedAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserAnalista, SecUserUpdateAt, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId) VALUES(:SecUserCreatedAt, :SecUserName, :SecUserFullName, :SecUserEmail, :SecUserStatus, :SecUserPassword, :SecUserAnalista, :SecUserUpdateAt, :SecUserTemp, :SecUserClienteAcesso, :SecUserTeste, :SecUserOwnerId, :SecUserUserMan, :SecUserClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000I16)
             ,new CursorDef("T000I17", "SELECT currval('SecUserId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I18", "SAVEPOINT gxupdate;UPDATE SecUser SET SecUserCreatedAt=:SecUserCreatedAt, SecUserName=:SecUserName, SecUserFullName=:SecUserFullName, SecUserEmail=:SecUserEmail, SecUserStatus=:SecUserStatus, SecUserPassword=:SecUserPassword, SecUserAnalista=:SecUserAnalista, SecUserUpdateAt=:SecUserUpdateAt, SecUserTemp=:SecUserTemp, SecUserClienteAcesso=:SecUserClienteAcesso, SecUserTeste=:SecUserTeste, SecUserOwnerId=:SecUserOwnerId, SecUserUserMan=:SecUserUserMan, SecUserClienteId=:SecUserClienteId  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I18)
             ,new CursorDef("T000I19", "SAVEPOINT gxupdate;DELETE FROM SecUser  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I19)
             ,new CursorDef("T000I20", "SELECT TipoClienteId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I21", "SELECT TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I22", "SELECT SecUserName AS SecUserManName, SecUserFullName AS SecUserManFullName FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I23", "SELECT SecUserFullName AS SecUserClienteFullName, SecUserStatus AS SecUserClienteStatus, SecUserClienteAcesso AS SecUserCliClienteAcesso FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I24", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserClienteId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I25", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserUserMan = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I26", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I27", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I28", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I29", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I30", "SELECT AgenciaId FROM Agencia WHERE AgenciaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I31", "SELECT AgenciaId FROM Agencia WHERE AgenciaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I32", "SELECT TaxasId FROM Taxas WHERE TaxasUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I33", "SELECT TaxasId FROM Taxas WHERE TaxasCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I34", "SELECT CreditoId FROM Credito WHERE CreditoUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I35", "SELECT CreditoId FROM Credito WHERE CreditoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I36", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogUser = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I37", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I37,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I38", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I38,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I39", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I39,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I40", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I40,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I41", "SELECT PropostaId FROM Proposta WHERE PropostaCratedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I41,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I42", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I42,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I43", "SELECT ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I43,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I44", "SELECT NotificationId FROM Notification WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I44,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I45", "SELECT AprovadoresId FROM Aprovadores WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I45,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I46", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I46,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I47", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I47,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I48", "SELECT SecUserId FROM SecUser ORDER BY SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I48,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getLongVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 34 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 35 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 36 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 37 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 38 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 39 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 40 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 41 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 42 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 43 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 44 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 45 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 46 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
