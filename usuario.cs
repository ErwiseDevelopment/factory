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
   public class usuario : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "usuario")), "usuario") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "usuario")))) ;
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
         Form.Meta.addItem("description", "Usuario", 0) ;
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

      public usuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuario( IGxContext context )
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserName_Internalname, "Usuário", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserName_Internalname, A141SecUserName, StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserFullName_Internalname, A143SecUserFullName, StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserFullName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserEmail_Internalname, A144SecUserEmail, StringUtil.RTrim( context.localUtil.Format( A144SecUserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A144SecUserEmail, "", "", "", edtSecUserEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Usuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecUserStatus, cmbSecUserStatus_Internalname, StringUtil.BoolToStr( A150SecUserStatus), 1, cmbSecUserStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSecUserStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_Usuario.htm");
         cmbSecUserStatus.CurrentValue = StringUtil.BoolToStr( A150SecUserStatus);
         AssignProp("", false, cmbSecUserStatus_Internalname, "Values", (string)(cmbSecUserStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserId_Visible, edtSecUserId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSecUserCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSecUserCreatedAt_Internalname, context.localUtil.TToC( A145SecUserCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A145SecUserCreatedAt, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserCreatedAt_Visible, edtSecUserCreatedAt_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_bitmap( context, edtSecUserCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtSecUserCreatedAt_Visible==0)||(edtSecUserCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuario.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSecUserUpdateAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSecUserUpdateAt_Internalname, context.localUtil.TToC( A146SecUserUpdateAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A146SecUserUpdateAt, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserUpdateAt_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserUpdateAt_Visible, edtSecUserUpdateAt_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_bitmap( context, edtSecUserUpdateAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtSecUserUpdateAt_Visible==0)||(edtSecUserUpdateAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuario.htm");
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
         E11262 ();
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
               Z146SecUserUpdateAt = context.localUtil.CToT( cgiGet( "Z146SecUserUpdateAt"), 0);
               n146SecUserUpdateAt = ((DateTime.MinValue==A146SecUserUpdateAt) ? true : false);
               Z141SecUserName = cgiGet( "Z141SecUserName");
               n141SecUserName = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? true : false);
               Z143SecUserFullName = cgiGet( "Z143SecUserFullName");
               n143SecUserFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? true : false);
               Z144SecUserEmail = cgiGet( "Z144SecUserEmail");
               n144SecUserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? true : false);
               Z150SecUserStatus = StringUtil.StrToBool( cgiGet( "Z150SecUserStatus"));
               n150SecUserStatus = ((false==A150SecUserStatus) ? true : false);
               Z226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z226SecUserOwnerId"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               Z147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z147SecUserUserMan"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               Z210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z210SecUserClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
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
               N210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N210SecUserClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
               N226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N226SecUserOwnerId"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               N147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N147SecUserUserMan"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               AV7SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSECUSERID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSERCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_SecUserClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_SecUserClienteId), 4, 0));
               A210SecUserClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSERCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n210SecUserClienteId = ((0==A210SecUserClienteId) ? true : false);
               AV12Insert_SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSEROWNERID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_SecUserOwnerId", StringUtil.LTrimStr( (decimal)(AV12Insert_SecUserOwnerId), 9, 0));
               A226SecUserOwnerId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSEROWNERID"), ",", "."), 18, MidpointRounding.ToEven));
               n226SecUserOwnerId = ((0==A226SecUserOwnerId) ? true : false);
               AV13Insert_SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSERUSERMAN"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_SecUserUserMan", StringUtil.LTrimStr( (decimal)(AV13Insert_SecUserUserMan), 4, 0));
               A147SecUserUserMan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSERUSERMAN"), ",", "."), 18, MidpointRounding.ToEven));
               n147SecUserUserMan = ((0==A147SecUserUserMan) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV16Pgmname = cgiGet( "vPGMNAME");
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
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               if ( context.localUtil.VCDateTime( cgiGet( edtSecUserCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Sec User Created At"}), 1, "SECUSERCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
                  n145SecUserCreatedAt = false;
                  AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A145SecUserCreatedAt = context.localUtil.CToT( cgiGet( edtSecUserCreatedAt_Internalname));
                  n145SecUserCreatedAt = false;
                  AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
               }
               n145SecUserCreatedAt = ((DateTime.MinValue==A145SecUserCreatedAt) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtSecUserUpdateAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Sec User Update At"}), 1, "SECUSERUPDATEAT");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserUpdateAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
                  n146SecUserUpdateAt = false;
                  AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A146SecUserUpdateAt = context.localUtil.CToT( cgiGet( edtSecUserUpdateAt_Internalname));
                  n146SecUserUpdateAt = false;
                  AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
               }
               n146SecUserUpdateAt = ((DateTime.MinValue==A146SecUserUpdateAt) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Usuario");
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               forbiddenHiddens.Add("SecUserId", context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserClienteId", context.localUtil.Format( (decimal)(AV11Insert_SecUserClienteId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserOwnerId", context.localUtil.Format( (decimal)(AV12Insert_SecUserOwnerId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserUserMan", context.localUtil.Format( (decimal)(AV13Insert_SecUserUserMan), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A133SecUserId != Z133SecUserId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("usuario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                           CONFIRM_260( ) ;
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
                           E11262 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12262 ();
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
            E12262 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2622( ) ;
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
            DisableAttributes2622( ) ;
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

      protected void CONFIRM_260( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2622( ) ;
            }
            else
            {
               CheckExtendedTable2622( ) ;
               CloseExtendedTableCursors2622( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption260( )
      {
      }

      protected void E11262( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SecUserClienteId") == 0 )
               {
                  AV11Insert_SecUserClienteId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SecUserClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_SecUserClienteId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SecUserOwnerId") == 0 )
               {
                  AV12Insert_SecUserOwnerId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SecUserOwnerId", StringUtil.LTrimStr( (decimal)(AV12Insert_SecUserOwnerId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SecUserUserMan") == 0 )
               {
                  AV13Insert_SecUserUserMan = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_SecUserUserMan", StringUtil.LTrimStr( (decimal)(AV13Insert_SecUserUserMan), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
         edtSecUserId_Visible = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserId_Visible), 5, 0), true);
         edtSecUserCreatedAt_Visible = 0;
         AssignProp("", false, edtSecUserCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserCreatedAt_Visible), 5, 0), true);
         edtSecUserUpdateAt_Visible = 0;
         AssignProp("", false, edtSecUserUpdateAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserUpdateAt_Visible), 5, 0), true);
      }

      protected void E12262( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("usuarioww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2622( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z145SecUserCreatedAt = T00263_A145SecUserCreatedAt[0];
               Z146SecUserUpdateAt = T00263_A146SecUserUpdateAt[0];
               Z141SecUserName = T00263_A141SecUserName[0];
               Z143SecUserFullName = T00263_A143SecUserFullName[0];
               Z144SecUserEmail = T00263_A144SecUserEmail[0];
               Z150SecUserStatus = T00263_A150SecUserStatus[0];
               Z226SecUserOwnerId = T00263_A226SecUserOwnerId[0];
               Z147SecUserUserMan = T00263_A147SecUserUserMan[0];
               Z210SecUserClienteId = T00263_A210SecUserClienteId[0];
            }
            else
            {
               Z145SecUserCreatedAt = A145SecUserCreatedAt;
               Z146SecUserUpdateAt = A146SecUserUpdateAt;
               Z141SecUserName = A141SecUserName;
               Z143SecUserFullName = A143SecUserFullName;
               Z144SecUserEmail = A144SecUserEmail;
               Z150SecUserStatus = A150SecUserStatus;
               Z226SecUserOwnerId = A226SecUserOwnerId;
               Z147SecUserUserMan = A147SecUserUserMan;
               Z210SecUserClienteId = A210SecUserClienteId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z133SecUserId = A133SecUserId;
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         AV16Pgmname = "Usuario";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
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
            cmbSecUserStatus.Enabled = 0;
            AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbSecUserStatus.Enabled = 1;
            AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
         }
         if ( IsUpd( )  )
         {
            A146SecUserUpdateAt = DateTimeUtil.ServerNow( context, pr_default);
            n146SecUserUpdateAt = false;
            AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
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
         if ( IsIns( )  )
         {
            A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n145SecUserCreatedAt = false;
            AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A145SecUserCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n145SecUserCreatedAt = false;
               AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
            }
         }
         if ( IsIns( )  && (false==A150SecUserStatus) && ( Gx_BScreen == 0 ) )
         {
            A150SecUserStatus = true;
            n150SecUserStatus = false;
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
         }
      }

      protected void Load2622( )
      {
         /* Using cursor T00267 */
         pr_default.execute(5, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound22 = 1;
            A145SecUserCreatedAt = T00267_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = T00267_n145SecUserCreatedAt[0];
            AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
            A146SecUserUpdateAt = T00267_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = T00267_n146SecUserUpdateAt[0];
            AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
            A141SecUserName = T00267_A141SecUserName[0];
            n141SecUserName = T00267_n141SecUserName[0];
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            A143SecUserFullName = T00267_A143SecUserFullName[0];
            n143SecUserFullName = T00267_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            A144SecUserEmail = T00267_A144SecUserEmail[0];
            n144SecUserEmail = T00267_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            A150SecUserStatus = T00267_A150SecUserStatus[0];
            n150SecUserStatus = T00267_n150SecUserStatus[0];
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
            A226SecUserOwnerId = T00267_A226SecUserOwnerId[0];
            n226SecUserOwnerId = T00267_n226SecUserOwnerId[0];
            A147SecUserUserMan = T00267_A147SecUserUserMan[0];
            n147SecUserUserMan = T00267_n147SecUserUserMan[0];
            A210SecUserClienteId = T00267_A210SecUserClienteId[0];
            n210SecUserClienteId = T00267_n210SecUserClienteId[0];
            ZM2622( -20) ;
         }
         pr_default.close(5);
         OnLoadActions2622( ) ;
      }

      protected void OnLoadActions2622( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SecUserClienteId) )
         {
            A210SecUserClienteId = AV11Insert_SecUserClienteId;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecUserOwnerId) )
         {
            A226SecUserOwnerId = AV12Insert_SecUserOwnerId;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SecUserUserMan) )
         {
            A147SecUserUserMan = AV13Insert_SecUserUserMan;
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
      }

      protected void CheckExtendedTable2622( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SecUserClienteId) )
         {
            A210SecUserClienteId = AV11Insert_SecUserClienteId;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecUserOwnerId) )
         {
            A226SecUserOwnerId = AV12Insert_SecUserOwnerId;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SecUserUserMan) )
         {
            A147SecUserUserMan = AV13Insert_SecUserUserMan;
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
         /* Using cursor T00264 */
         pr_default.execute(2, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A226SecUserOwnerId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sec User Owner'.", "ForeignKeyNotFound", 1, "SECUSEROWNERID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor T00265 */
         pr_default.execute(3, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A147SecUserUserMan) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Manuten'.", "ForeignKeyNotFound", 1, "SECUSERUSERMAN");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor T00266 */
         pr_default.execute(4, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A210SecUserClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Cliente User'.", "ForeignKeyNotFound", 1, "SECUSERCLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2622( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( int A226SecUserOwnerId )
      {
         /* Using cursor T00268 */
         pr_default.execute(6, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A226SecUserOwnerId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sec User Owner'.", "ForeignKeyNotFound", 1, "SECUSEROWNERID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_22( short A147SecUserUserMan )
      {
         /* Using cursor T00269 */
         pr_default.execute(7, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A147SecUserUserMan) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Manuten'.", "ForeignKeyNotFound", 1, "SECUSERUSERMAN");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_23( short A210SecUserClienteId )
      {
         /* Using cursor T002610 */
         pr_default.execute(8, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A210SecUserClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Cliente User'.", "ForeignKeyNotFound", 1, "SECUSERCLIENTEID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey2622( )
      {
         /* Using cursor T002611 */
         pr_default.execute(9, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00263 */
         pr_default.execute(1, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2622( 20) ;
            RcdFound22 = 1;
            A133SecUserId = T00263_A133SecUserId[0];
            n133SecUserId = T00263_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            A145SecUserCreatedAt = T00263_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = T00263_n145SecUserCreatedAt[0];
            AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
            A146SecUserUpdateAt = T00263_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = T00263_n146SecUserUpdateAt[0];
            AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
            A141SecUserName = T00263_A141SecUserName[0];
            n141SecUserName = T00263_n141SecUserName[0];
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            A143SecUserFullName = T00263_A143SecUserFullName[0];
            n143SecUserFullName = T00263_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            A144SecUserEmail = T00263_A144SecUserEmail[0];
            n144SecUserEmail = T00263_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            A150SecUserStatus = T00263_A150SecUserStatus[0];
            n150SecUserStatus = T00263_n150SecUserStatus[0];
            AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
            A226SecUserOwnerId = T00263_A226SecUserOwnerId[0];
            n226SecUserOwnerId = T00263_n226SecUserOwnerId[0];
            A147SecUserUserMan = T00263_A147SecUserUserMan[0];
            n147SecUserUserMan = T00263_n147SecUserUserMan[0];
            A210SecUserClienteId = T00263_A210SecUserClienteId[0];
            n210SecUserClienteId = T00263_n210SecUserClienteId[0];
            Z133SecUserId = A133SecUserId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2622( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey2622( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey2622( ) ;
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
         GetKey2622( ) ;
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
         /* Using cursor T002612 */
         pr_default.execute(10, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002612_A133SecUserId[0] < A133SecUserId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002612_A133SecUserId[0] > A133SecUserId ) ) )
            {
               A133SecUserId = T002612_A133SecUserId[0];
               n133SecUserId = T002612_n133SecUserId[0];
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T002613 */
         pr_default.execute(11, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002613_A133SecUserId[0] > A133SecUserId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002613_A133SecUserId[0] < A133SecUserId ) ) )
            {
               A133SecUserId = T002613_A133SecUserId[0];
               n133SecUserId = T002613_n133SecUserId[0];
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2622( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2622( ) ;
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
                  Update2622( ) ;
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
                  Insert2622( ) ;
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
                     Insert2622( ) ;
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

      protected void CheckOptimisticConcurrency2622( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00262 */
            pr_default.execute(0, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z145SecUserCreatedAt != T00262_A145SecUserCreatedAt[0] ) || ( Z146SecUserUpdateAt != T00262_A146SecUserUpdateAt[0] ) || ( StringUtil.StrCmp(Z141SecUserName, T00262_A141SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z143SecUserFullName, T00262_A143SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z144SecUserEmail, T00262_A144SecUserEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z150SecUserStatus != T00262_A150SecUserStatus[0] ) || ( Z226SecUserOwnerId != T00262_A226SecUserOwnerId[0] ) || ( Z147SecUserUserMan != T00262_A147SecUserUserMan[0] ) || ( Z210SecUserClienteId != T00262_A210SecUserClienteId[0] ) )
            {
               if ( Z145SecUserCreatedAt != T00262_A145SecUserCreatedAt[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z145SecUserCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00262_A145SecUserCreatedAt[0]);
               }
               if ( Z146SecUserUpdateAt != T00262_A146SecUserUpdateAt[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserUpdateAt");
                  GXUtil.WriteLogRaw("Old: ",Z146SecUserUpdateAt);
                  GXUtil.WriteLogRaw("Current: ",T00262_A146SecUserUpdateAt[0]);
               }
               if ( StringUtil.StrCmp(Z141SecUserName, T00262_A141SecUserName[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserName");
                  GXUtil.WriteLogRaw("Old: ",Z141SecUserName);
                  GXUtil.WriteLogRaw("Current: ",T00262_A141SecUserName[0]);
               }
               if ( StringUtil.StrCmp(Z143SecUserFullName, T00262_A143SecUserFullName[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserFullName");
                  GXUtil.WriteLogRaw("Old: ",Z143SecUserFullName);
                  GXUtil.WriteLogRaw("Current: ",T00262_A143SecUserFullName[0]);
               }
               if ( StringUtil.StrCmp(Z144SecUserEmail, T00262_A144SecUserEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserEmail");
                  GXUtil.WriteLogRaw("Old: ",Z144SecUserEmail);
                  GXUtil.WriteLogRaw("Current: ",T00262_A144SecUserEmail[0]);
               }
               if ( Z150SecUserStatus != T00262_A150SecUserStatus[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserStatus");
                  GXUtil.WriteLogRaw("Old: ",Z150SecUserStatus);
                  GXUtil.WriteLogRaw("Current: ",T00262_A150SecUserStatus[0]);
               }
               if ( Z226SecUserOwnerId != T00262_A226SecUserOwnerId[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserOwnerId");
                  GXUtil.WriteLogRaw("Old: ",Z226SecUserOwnerId);
                  GXUtil.WriteLogRaw("Current: ",T00262_A226SecUserOwnerId[0]);
               }
               if ( Z147SecUserUserMan != T00262_A147SecUserUserMan[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserUserMan");
                  GXUtil.WriteLogRaw("Old: ",Z147SecUserUserMan);
                  GXUtil.WriteLogRaw("Current: ",T00262_A147SecUserUserMan[0]);
               }
               if ( Z210SecUserClienteId != T00262_A210SecUserClienteId[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"SecUserClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z210SecUserClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00262_A210SecUserClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2622( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2622( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2622( 0) ;
            CheckOptimisticConcurrency2622( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2622( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2622( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002614 */
                     pr_default.execute(12, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n146SecUserUpdateAt, A146SecUserUpdateAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002615 */
                     pr_default.execute(13);
                     A133SecUserId = T002615_A133SecUserId[0];
                     n133SecUserId = T002615_n133SecUserId[0];
                     AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
                     pr_default.close(13);
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
                           ResetCaption260( ) ;
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
               Load2622( ) ;
            }
            EndLevel2622( ) ;
         }
         CloseExtendedTableCursors2622( ) ;
      }

      protected void Update2622( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2622( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2622( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2622( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2622( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002616 */
                     pr_default.execute(14, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n146SecUserUpdateAt, A146SecUserUpdateAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId, n133SecUserId, A133SecUserId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2622( ) ;
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
            EndLevel2622( ) ;
         }
         CloseExtendedTableCursors2622( ) ;
      }

      protected void DeferredUpdate2622( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2622( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2622( ) ;
            AfterConfirm2622( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2622( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002617 */
                  pr_default.execute(15, new Object[] {n133SecUserId, A133SecUserId});
                  pr_default.close(15);
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
         EndLevel2622( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2622( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002618 */
            pr_default.execute(16, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T002619 */
            pr_default.execute(17, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T002620 */
            pr_default.execute(18, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXUpdated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T002621 */
            pr_default.execute(19, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXCreated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002622 */
            pr_default.execute(20, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T002623 */
            pr_default.execute(21, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T002624 */
            pr_default.execute(22, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T002625 */
            pr_default.execute(23, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T002626 */
            pr_default.execute(24, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T002627 */
            pr_default.execute(25, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T002628 */
            pr_default.execute(26, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sb Updated By Credito"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T002629 */
            pr_default.execute(27, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sdb Credito Usuario"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T002630 */
            pr_default.execute(28, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T002631 */
            pr_default.execute(29, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T002632 */
            pr_default.execute(30, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Especialidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T002633 */
            pr_default.execute(31, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T002634 */
            pr_default.execute(32, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T002635 */
            pr_default.execute(33, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T002636 */
            pr_default.execute(34, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SecUserLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T002637 */
            pr_default.execute(35, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConfiguracoesTestemunhas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T002638 */
            pr_default.execute(36, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T002639 */
            pr_default.execute(37, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T002640 */
            pr_default.execute(38, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User UID"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T002641 */
            pr_default.execute(39, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
         }
      }

      protected void EndLevel2622( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2622( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("usuario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues260( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("usuario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2622( )
      {
         /* Scan By routine */
         /* Using cursor T002642 */
         pr_default.execute(40);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = T002642_A133SecUserId[0];
            n133SecUserId = T002642_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2622( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = T002642_A133SecUserId[0];
            n133SecUserId = T002642_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         }
      }

      protected void ScanEnd2622( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm2622( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2622( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2622( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2622( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2622( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2622( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2622( )
      {
         edtSecUserName_Enabled = 0;
         AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
         edtSecUserFullName_Enabled = 0;
         AssignProp("", false, edtSecUserFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserFullName_Enabled), 5, 0), true);
         edtSecUserEmail_Enabled = 0;
         AssignProp("", false, edtSecUserEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserEmail_Enabled), 5, 0), true);
         cmbSecUserStatus.Enabled = 0;
         AssignProp("", false, cmbSecUserStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserStatus.Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtSecUserCreatedAt_Enabled = 0;
         AssignProp("", false, edtSecUserCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserCreatedAt_Enabled), 5, 0), true);
         edtSecUserUpdateAt_Enabled = 0;
         AssignProp("", false, edtSecUserUpdateAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserUpdateAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2622( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues260( )
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
         GXEncryptionTmp = "usuario"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("usuario") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Usuario");
         forbiddenHiddens.Add("SecUserId", context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserClienteId", context.localUtil.Format( (decimal)(AV11Insert_SecUserClienteId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserOwnerId", context.localUtil.Format( (decimal)(AV12Insert_SecUserOwnerId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserUserMan", context.localUtil.Format( (decimal)(AV13Insert_SecUserUserMan), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("usuario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z145SecUserCreatedAt", context.localUtil.TToC( Z145SecUserCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z146SecUserUpdateAt", context.localUtil.TToC( Z146SecUserUpdateAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z141SecUserName", Z141SecUserName);
         GxWebStd.gx_hidden_field( context, "Z143SecUserFullName", Z143SecUserFullName);
         GxWebStd.gx_hidden_field( context, "Z144SecUserEmail", Z144SecUserEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z150SecUserStatus", Z150SecUserStatus);
         GxWebStd.gx_hidden_field( context, "Z226SecUserOwnerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z226SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z147SecUserUserMan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z210SecUserClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N210SecUserClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N226SecUserOwnerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N147SecUserUserMan", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSERCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSEROWNERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSEROWNERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSERUSERMAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERUSERMAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         GXEncryptionTmp = "usuario"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserId,4,0));
         return formatLink("usuario") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Usuario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario" ;
      }

      protected void InitializeNonKey2622( )
      {
         A210SecUserClienteId = 0;
         n210SecUserClienteId = false;
         AssignAttri("", false, "A210SecUserClienteId", ((0==A210SecUserClienteId)&&IsIns( )||n210SecUserClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserClienteId), 4, 0, ".", ""))));
         A226SecUserOwnerId = 0;
         n226SecUserOwnerId = false;
         AssignAttri("", false, "A226SecUserOwnerId", ((0==A226SecUserOwnerId)&&IsIns( )||n226SecUserOwnerId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A226SecUserOwnerId), 9, 0, ".", ""))));
         A147SecUserUserMan = 0;
         n147SecUserUserMan = false;
         AssignAttri("", false, "A147SecUserUserMan", ((0==A147SecUserUserMan)&&IsIns( )||n147SecUserUserMan ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A147SecUserUserMan), 4, 0, ".", ""))));
         A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         AssignAttri("", false, "A145SecUserCreatedAt", context.localUtil.TToC( A145SecUserCreatedAt, 10, 5, 0, 3, "/", ":", " "));
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         n146SecUserUpdateAt = false;
         AssignAttri("", false, "A146SecUserUpdateAt", context.localUtil.TToC( A146SecUserUpdateAt, 10, 5, 0, 3, "/", ":", " "));
         n146SecUserUpdateAt = ((DateTime.MinValue==A146SecUserUpdateAt) ? true : false);
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
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         AssignAttri("", false, "A150SecUserStatus", A150SecUserStatus);
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         Z144SecUserEmail = "";
         Z150SecUserStatus = false;
         Z226SecUserOwnerId = 0;
         Z147SecUserUserMan = 0;
         Z210SecUserClienteId = 0;
      }

      protected void InitAll2622( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         InitializeNonKey2622( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019192972", true, true);
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
         context.AddJavascriptSource("usuario.js", "?202561019192973", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtSecUserEmail_Internalname = "SECUSEREMAIL";
         cmbSecUserStatus_Internalname = "SECUSERSTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSecUserId_Internalname = "SECUSERID";
         edtSecUserCreatedAt_Internalname = "SECUSERCREATEDAT";
         edtSecUserUpdateAt_Internalname = "SECUSERUPDATEAT";
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
         Form.Caption = "Usuario";
         edtSecUserUpdateAt_Jsonclick = "";
         edtSecUserUpdateAt_Enabled = 1;
         edtSecUserUpdateAt_Visible = 1;
         edtSecUserCreatedAt_Jsonclick = "";
         edtSecUserCreatedAt_Enabled = 1;
         edtSecUserCreatedAt_Visible = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 0;
         edtSecUserId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7SecUserId","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV11Insert_SecUserClienteId","fld":"vINSERT_SECUSERCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV12Insert_SecUserOwnerId","fld":"vINSERT_SECUSEROWNERID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13Insert_SecUserUserMan","fld":"vINSERT_SECUSERUSERMAN","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12262","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         Z144SecUserEmail = "";
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
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         AV16Pgmname = "";
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         T00267_A133SecUserId = new short[1] ;
         T00267_n133SecUserId = new bool[] {false} ;
         T00267_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00267_n145SecUserCreatedAt = new bool[] {false} ;
         T00267_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T00267_n146SecUserUpdateAt = new bool[] {false} ;
         T00267_A141SecUserName = new string[] {""} ;
         T00267_n141SecUserName = new bool[] {false} ;
         T00267_A143SecUserFullName = new string[] {""} ;
         T00267_n143SecUserFullName = new bool[] {false} ;
         T00267_A144SecUserEmail = new string[] {""} ;
         T00267_n144SecUserEmail = new bool[] {false} ;
         T00267_A150SecUserStatus = new bool[] {false} ;
         T00267_n150SecUserStatus = new bool[] {false} ;
         T00267_A226SecUserOwnerId = new int[1] ;
         T00267_n226SecUserOwnerId = new bool[] {false} ;
         T00267_A147SecUserUserMan = new short[1] ;
         T00267_n147SecUserUserMan = new bool[] {false} ;
         T00267_A210SecUserClienteId = new short[1] ;
         T00267_n210SecUserClienteId = new bool[] {false} ;
         T00264_A226SecUserOwnerId = new int[1] ;
         T00264_n226SecUserOwnerId = new bool[] {false} ;
         T00265_A147SecUserUserMan = new short[1] ;
         T00265_n147SecUserUserMan = new bool[] {false} ;
         T00266_A210SecUserClienteId = new short[1] ;
         T00266_n210SecUserClienteId = new bool[] {false} ;
         T00268_A226SecUserOwnerId = new int[1] ;
         T00268_n226SecUserOwnerId = new bool[] {false} ;
         T00269_A147SecUserUserMan = new short[1] ;
         T00269_n147SecUserUserMan = new bool[] {false} ;
         T002610_A210SecUserClienteId = new short[1] ;
         T002610_n210SecUserClienteId = new bool[] {false} ;
         T002611_A133SecUserId = new short[1] ;
         T002611_n133SecUserId = new bool[] {false} ;
         T00263_A133SecUserId = new short[1] ;
         T00263_n133SecUserId = new bool[] {false} ;
         T00263_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00263_n145SecUserCreatedAt = new bool[] {false} ;
         T00263_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T00263_n146SecUserUpdateAt = new bool[] {false} ;
         T00263_A141SecUserName = new string[] {""} ;
         T00263_n141SecUserName = new bool[] {false} ;
         T00263_A143SecUserFullName = new string[] {""} ;
         T00263_n143SecUserFullName = new bool[] {false} ;
         T00263_A144SecUserEmail = new string[] {""} ;
         T00263_n144SecUserEmail = new bool[] {false} ;
         T00263_A150SecUserStatus = new bool[] {false} ;
         T00263_n150SecUserStatus = new bool[] {false} ;
         T00263_A226SecUserOwnerId = new int[1] ;
         T00263_n226SecUserOwnerId = new bool[] {false} ;
         T00263_A147SecUserUserMan = new short[1] ;
         T00263_n147SecUserUserMan = new bool[] {false} ;
         T00263_A210SecUserClienteId = new short[1] ;
         T00263_n210SecUserClienteId = new bool[] {false} ;
         T002612_A133SecUserId = new short[1] ;
         T002612_n133SecUserId = new bool[] {false} ;
         T002613_A133SecUserId = new short[1] ;
         T002613_n133SecUserId = new bool[] {false} ;
         T00262_A133SecUserId = new short[1] ;
         T00262_n133SecUserId = new bool[] {false} ;
         T00262_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00262_n145SecUserCreatedAt = new bool[] {false} ;
         T00262_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T00262_n146SecUserUpdateAt = new bool[] {false} ;
         T00262_A141SecUserName = new string[] {""} ;
         T00262_n141SecUserName = new bool[] {false} ;
         T00262_A143SecUserFullName = new string[] {""} ;
         T00262_n143SecUserFullName = new bool[] {false} ;
         T00262_A144SecUserEmail = new string[] {""} ;
         T00262_n144SecUserEmail = new bool[] {false} ;
         T00262_A150SecUserStatus = new bool[] {false} ;
         T00262_n150SecUserStatus = new bool[] {false} ;
         T00262_A226SecUserOwnerId = new int[1] ;
         T00262_n226SecUserOwnerId = new bool[] {false} ;
         T00262_A147SecUserUserMan = new short[1] ;
         T00262_n147SecUserUserMan = new bool[] {false} ;
         T00262_A210SecUserClienteId = new short[1] ;
         T00262_n210SecUserClienteId = new bool[] {false} ;
         T002615_A133SecUserId = new short[1] ;
         T002615_n133SecUserId = new bool[] {false} ;
         T002618_A210SecUserClienteId = new short[1] ;
         T002618_n210SecUserClienteId = new bool[] {false} ;
         T002619_A147SecUserUserMan = new short[1] ;
         T002619_n147SecUserUserMan = new bool[] {false} ;
         T002620_A961ChavePIXId = new int[1] ;
         T002621_A961ChavePIXId = new int[1] ;
         T002622_A951ContaBancariaId = new int[1] ;
         T002623_A951ContaBancariaId = new int[1] ;
         T002624_A938AgenciaId = new int[1] ;
         T002625_A938AgenciaId = new int[1] ;
         T002626_A863TaxasId = new int[1] ;
         T002627_A863TaxasId = new int[1] ;
         T002628_A856CreditoId = new int[1] ;
         T002629_A856CreditoId = new int[1] ;
         T002630_A746ReembolsoFlowLogId = new int[1] ;
         T002631_A599ClienteDocumentoId = new int[1] ;
         T002632_A457EspecialidadeId = new int[1] ;
         T002633_A518ReembolsoId = new int[1] ;
         T002634_A387UserNotificationId = new int[1] ;
         T002635_A323PropostaId = new int[1] ;
         T002636_A559SecUserLogId = new int[1] ;
         T002637_A478ConfiguracoesTestemunhasId = new int[1] ;
         T002638_A381NotificationId = new int[1] ;
         T002639_A375AprovadoresId = new int[1] ;
         T002640_A164SecUserTokenID = new short[1] ;
         T002641_A133SecUserId = new short[1] ;
         T002641_n133SecUserId = new bool[] {false} ;
         T002641_A131SecRoleId = new short[1] ;
         T002642_A133SecUserId = new short[1] ;
         T002642_n133SecUserId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuario__default(),
            new Object[][] {
                new Object[] {
               T00262_A133SecUserId, T00262_A145SecUserCreatedAt, T00262_n145SecUserCreatedAt, T00262_A146SecUserUpdateAt, T00262_n146SecUserUpdateAt, T00262_A141SecUserName, T00262_n141SecUserName, T00262_A143SecUserFullName, T00262_n143SecUserFullName, T00262_A144SecUserEmail,
               T00262_n144SecUserEmail, T00262_A150SecUserStatus, T00262_n150SecUserStatus, T00262_A226SecUserOwnerId, T00262_n226SecUserOwnerId, T00262_A147SecUserUserMan, T00262_n147SecUserUserMan, T00262_A210SecUserClienteId, T00262_n210SecUserClienteId
               }
               , new Object[] {
               T00263_A133SecUserId, T00263_A145SecUserCreatedAt, T00263_n145SecUserCreatedAt, T00263_A146SecUserUpdateAt, T00263_n146SecUserUpdateAt, T00263_A141SecUserName, T00263_n141SecUserName, T00263_A143SecUserFullName, T00263_n143SecUserFullName, T00263_A144SecUserEmail,
               T00263_n144SecUserEmail, T00263_A150SecUserStatus, T00263_n150SecUserStatus, T00263_A226SecUserOwnerId, T00263_n226SecUserOwnerId, T00263_A147SecUserUserMan, T00263_n147SecUserUserMan, T00263_A210SecUserClienteId, T00263_n210SecUserClienteId
               }
               , new Object[] {
               T00264_A226SecUserOwnerId
               }
               , new Object[] {
               T00265_A147SecUserUserMan
               }
               , new Object[] {
               T00266_A210SecUserClienteId
               }
               , new Object[] {
               T00267_A133SecUserId, T00267_A145SecUserCreatedAt, T00267_n145SecUserCreatedAt, T00267_A146SecUserUpdateAt, T00267_n146SecUserUpdateAt, T00267_A141SecUserName, T00267_n141SecUserName, T00267_A143SecUserFullName, T00267_n143SecUserFullName, T00267_A144SecUserEmail,
               T00267_n144SecUserEmail, T00267_A150SecUserStatus, T00267_n150SecUserStatus, T00267_A226SecUserOwnerId, T00267_n226SecUserOwnerId, T00267_A147SecUserUserMan, T00267_n147SecUserUserMan, T00267_A210SecUserClienteId, T00267_n210SecUserClienteId
               }
               , new Object[] {
               T00268_A226SecUserOwnerId
               }
               , new Object[] {
               T00269_A147SecUserUserMan
               }
               , new Object[] {
               T002610_A210SecUserClienteId
               }
               , new Object[] {
               T002611_A133SecUserId
               }
               , new Object[] {
               T002612_A133SecUserId
               }
               , new Object[] {
               T002613_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               T002615_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002618_A210SecUserClienteId
               }
               , new Object[] {
               T002619_A147SecUserUserMan
               }
               , new Object[] {
               T002620_A961ChavePIXId
               }
               , new Object[] {
               T002621_A961ChavePIXId
               }
               , new Object[] {
               T002622_A951ContaBancariaId
               }
               , new Object[] {
               T002623_A951ContaBancariaId
               }
               , new Object[] {
               T002624_A938AgenciaId
               }
               , new Object[] {
               T002625_A938AgenciaId
               }
               , new Object[] {
               T002626_A863TaxasId
               }
               , new Object[] {
               T002627_A863TaxasId
               }
               , new Object[] {
               T002628_A856CreditoId
               }
               , new Object[] {
               T002629_A856CreditoId
               }
               , new Object[] {
               T002630_A746ReembolsoFlowLogId
               }
               , new Object[] {
               T002631_A599ClienteDocumentoId
               }
               , new Object[] {
               T002632_A457EspecialidadeId
               }
               , new Object[] {
               T002633_A518ReembolsoId
               }
               , new Object[] {
               T002634_A387UserNotificationId
               }
               , new Object[] {
               T002635_A323PropostaId
               }
               , new Object[] {
               T002636_A559SecUserLogId
               }
               , new Object[] {
               T002637_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               T002638_A381NotificationId
               }
               , new Object[] {
               T002639_A375AprovadoresId
               }
               , new Object[] {
               T002640_A164SecUserTokenID
               }
               , new Object[] {
               T002641_A133SecUserId, T002641_A131SecRoleId
               }
               , new Object[] {
               T002642_A133SecUserId
               }
            }
         );
         AV16Pgmname = "Usuario";
         Z145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         i145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
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
      private short N210SecUserClienteId ;
      private short N147SecUserUserMan ;
      private short GxWebError ;
      private short A147SecUserUserMan ;
      private short A210SecUserClienteId ;
      private short AV7SecUserId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A133SecUserId ;
      private short AV11Insert_SecUserClienteId ;
      private short AV13Insert_SecUserUserMan ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short gxajaxcallmode ;
      private int Z226SecUserOwnerId ;
      private int N226SecUserOwnerId ;
      private int A226SecUserOwnerId ;
      private int trnEnded ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtSecUserEmail_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserId_Visible ;
      private int edtSecUserCreatedAt_Visible ;
      private int edtSecUserCreatedAt_Enabled ;
      private int edtSecUserUpdateAt_Visible ;
      private int edtSecUserUpdateAt_Enabled ;
      private int AV12Insert_SecUserOwnerId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV17GXV1 ;
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
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtSecUserEmail_Internalname ;
      private string edtSecUserEmail_Jsonclick ;
      private string cmbSecUserStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserCreatedAt_Internalname ;
      private string edtSecUserCreatedAt_Jsonclick ;
      private string edtSecUserUpdateAt_Internalname ;
      private string edtSecUserUpdateAt_Jsonclick ;
      private string AV16Pgmname ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n226SecUserOwnerId ;
      private bool n147SecUserUserMan ;
      private bool n210SecUserClienteId ;
      private bool wbErr ;
      private bool A150SecUserStatus ;
      private bool n150SecUserStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n145SecUserCreatedAt ;
      private bool n146SecUserUpdateAt ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n144SecUserEmail ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n133SecUserId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i150SecUserStatus ;
      private string Z141SecUserName ;
      private string Z143SecUserFullName ;
      private string Z144SecUserEmail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSecUserStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T00267_A133SecUserId ;
      private bool[] T00267_n133SecUserId ;
      private DateTime[] T00267_A145SecUserCreatedAt ;
      private bool[] T00267_n145SecUserCreatedAt ;
      private DateTime[] T00267_A146SecUserUpdateAt ;
      private bool[] T00267_n146SecUserUpdateAt ;
      private string[] T00267_A141SecUserName ;
      private bool[] T00267_n141SecUserName ;
      private string[] T00267_A143SecUserFullName ;
      private bool[] T00267_n143SecUserFullName ;
      private string[] T00267_A144SecUserEmail ;
      private bool[] T00267_n144SecUserEmail ;
      private bool[] T00267_A150SecUserStatus ;
      private bool[] T00267_n150SecUserStatus ;
      private int[] T00267_A226SecUserOwnerId ;
      private bool[] T00267_n226SecUserOwnerId ;
      private short[] T00267_A147SecUserUserMan ;
      private bool[] T00267_n147SecUserUserMan ;
      private short[] T00267_A210SecUserClienteId ;
      private bool[] T00267_n210SecUserClienteId ;
      private int[] T00264_A226SecUserOwnerId ;
      private bool[] T00264_n226SecUserOwnerId ;
      private short[] T00265_A147SecUserUserMan ;
      private bool[] T00265_n147SecUserUserMan ;
      private short[] T00266_A210SecUserClienteId ;
      private bool[] T00266_n210SecUserClienteId ;
      private int[] T00268_A226SecUserOwnerId ;
      private bool[] T00268_n226SecUserOwnerId ;
      private short[] T00269_A147SecUserUserMan ;
      private bool[] T00269_n147SecUserUserMan ;
      private short[] T002610_A210SecUserClienteId ;
      private bool[] T002610_n210SecUserClienteId ;
      private short[] T002611_A133SecUserId ;
      private bool[] T002611_n133SecUserId ;
      private short[] T00263_A133SecUserId ;
      private bool[] T00263_n133SecUserId ;
      private DateTime[] T00263_A145SecUserCreatedAt ;
      private bool[] T00263_n145SecUserCreatedAt ;
      private DateTime[] T00263_A146SecUserUpdateAt ;
      private bool[] T00263_n146SecUserUpdateAt ;
      private string[] T00263_A141SecUserName ;
      private bool[] T00263_n141SecUserName ;
      private string[] T00263_A143SecUserFullName ;
      private bool[] T00263_n143SecUserFullName ;
      private string[] T00263_A144SecUserEmail ;
      private bool[] T00263_n144SecUserEmail ;
      private bool[] T00263_A150SecUserStatus ;
      private bool[] T00263_n150SecUserStatus ;
      private int[] T00263_A226SecUserOwnerId ;
      private bool[] T00263_n226SecUserOwnerId ;
      private short[] T00263_A147SecUserUserMan ;
      private bool[] T00263_n147SecUserUserMan ;
      private short[] T00263_A210SecUserClienteId ;
      private bool[] T00263_n210SecUserClienteId ;
      private short[] T002612_A133SecUserId ;
      private bool[] T002612_n133SecUserId ;
      private short[] T002613_A133SecUserId ;
      private bool[] T002613_n133SecUserId ;
      private short[] T00262_A133SecUserId ;
      private bool[] T00262_n133SecUserId ;
      private DateTime[] T00262_A145SecUserCreatedAt ;
      private bool[] T00262_n145SecUserCreatedAt ;
      private DateTime[] T00262_A146SecUserUpdateAt ;
      private bool[] T00262_n146SecUserUpdateAt ;
      private string[] T00262_A141SecUserName ;
      private bool[] T00262_n141SecUserName ;
      private string[] T00262_A143SecUserFullName ;
      private bool[] T00262_n143SecUserFullName ;
      private string[] T00262_A144SecUserEmail ;
      private bool[] T00262_n144SecUserEmail ;
      private bool[] T00262_A150SecUserStatus ;
      private bool[] T00262_n150SecUserStatus ;
      private int[] T00262_A226SecUserOwnerId ;
      private bool[] T00262_n226SecUserOwnerId ;
      private short[] T00262_A147SecUserUserMan ;
      private bool[] T00262_n147SecUserUserMan ;
      private short[] T00262_A210SecUserClienteId ;
      private bool[] T00262_n210SecUserClienteId ;
      private short[] T002615_A133SecUserId ;
      private bool[] T002615_n133SecUserId ;
      private short[] T002618_A210SecUserClienteId ;
      private bool[] T002618_n210SecUserClienteId ;
      private short[] T002619_A147SecUserUserMan ;
      private bool[] T002619_n147SecUserUserMan ;
      private int[] T002620_A961ChavePIXId ;
      private int[] T002621_A961ChavePIXId ;
      private int[] T002622_A951ContaBancariaId ;
      private int[] T002623_A951ContaBancariaId ;
      private int[] T002624_A938AgenciaId ;
      private int[] T002625_A938AgenciaId ;
      private int[] T002626_A863TaxasId ;
      private int[] T002627_A863TaxasId ;
      private int[] T002628_A856CreditoId ;
      private int[] T002629_A856CreditoId ;
      private int[] T002630_A746ReembolsoFlowLogId ;
      private int[] T002631_A599ClienteDocumentoId ;
      private int[] T002632_A457EspecialidadeId ;
      private int[] T002633_A518ReembolsoId ;
      private int[] T002634_A387UserNotificationId ;
      private int[] T002635_A323PropostaId ;
      private int[] T002636_A559SecUserLogId ;
      private int[] T002637_A478ConfiguracoesTestemunhasId ;
      private int[] T002638_A381NotificationId ;
      private int[] T002639_A375AprovadoresId ;
      private short[] T002640_A164SecUserTokenID ;
      private short[] T002641_A133SecUserId ;
      private bool[] T002641_n133SecUserId ;
      private short[] T002641_A131SecRoleId ;
      private short[] T002642_A133SecUserId ;
      private bool[] T002642_n133SecUserId ;
   }

   public class usuario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00262;
          prmT00262 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00263;
          prmT00263 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00264;
          prmT00264 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00265;
          prmT00265 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00266;
          prmT00266 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00267;
          prmT00267 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00268;
          prmT00268 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00269;
          prmT00269 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002610;
          prmT002610 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002611;
          prmT002611 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002612;
          prmT002612 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002613;
          prmT002613 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002614;
          prmT002614 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002615;
          prmT002615 = new Object[] {
          };
          Object[] prmT002616;
          prmT002616 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002617;
          prmT002617 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002618;
          prmT002618 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002619;
          prmT002619 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002620;
          prmT002620 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002621;
          prmT002621 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002622;
          prmT002622 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002623;
          prmT002623 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002624;
          prmT002624 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002625;
          prmT002625 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002626;
          prmT002626 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002627;
          prmT002627 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002628;
          prmT002628 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002629;
          prmT002629 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002630;
          prmT002630 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002631;
          prmT002631 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002632;
          prmT002632 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002633;
          prmT002633 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002634;
          prmT002634 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002635;
          prmT002635 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002636;
          prmT002636 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002637;
          prmT002637 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002638;
          prmT002638 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002639;
          prmT002639 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002640;
          prmT002640 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002641;
          prmT002641 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002642;
          prmT002642 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00262", "SELECT SecUserId, SecUserCreatedAt, SecUserUpdateAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId  FOR UPDATE OF SecUser NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00262,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00263", "SELECT SecUserId, SecUserCreatedAt, SecUserUpdateAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00263,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00264", "SELECT ClienteId AS SecUserOwnerId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00264,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00265", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmT00265,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00266", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00266,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00267", "SELECT TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserUpdateAt, TM1.SecUserName, TM1.SecUserFullName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM SecUser TM1 WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00267,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00268", "SELECT ClienteId AS SecUserOwnerId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00268,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00269", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmT00269,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002610", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002611", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002612", "SELECT SecUserId FROM SecUser WHERE ( SecUserId > :SecUserId) ORDER BY SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002612,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002613", "SELECT SecUserId FROM SecUser WHERE ( SecUserId < :SecUserId) ORDER BY SecUserId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002614", "SAVEPOINT gxupdate;INSERT INTO SecUser(SecUserCreatedAt, SecUserUpdateAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserOwnerId, SecUserUserMan, SecUserClienteId, SecUserPassword, SecUserTeste, SecUserTemp, SecUserClienteAcesso, SecUserAnalista) VALUES(:SecUserCreatedAt, :SecUserUpdateAt, :SecUserName, :SecUserFullName, :SecUserEmail, :SecUserStatus, :SecUserOwnerId, :SecUserUserMan, :SecUserClienteId, '', '', FALSE, FALSE, FALSE);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002614)
             ,new CursorDef("T002615", "SELECT currval('SecUserId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002616", "SAVEPOINT gxupdate;UPDATE SecUser SET SecUserCreatedAt=:SecUserCreatedAt, SecUserUpdateAt=:SecUserUpdateAt, SecUserName=:SecUserName, SecUserFullName=:SecUserFullName, SecUserEmail=:SecUserEmail, SecUserStatus=:SecUserStatus, SecUserOwnerId=:SecUserOwnerId, SecUserUserMan=:SecUserUserMan, SecUserClienteId=:SecUserClienteId  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002616)
             ,new CursorDef("T002617", "SAVEPOINT gxupdate;DELETE FROM SecUser  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002617)
             ,new CursorDef("T002618", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserClienteId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002618,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002619", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserUserMan = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002619,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002620", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002620,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002621", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002621,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002622", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002622,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002623", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002623,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002624", "SELECT AgenciaId FROM Agencia WHERE AgenciaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002624,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002625", "SELECT AgenciaId FROM Agencia WHERE AgenciaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002625,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002626", "SELECT TaxasId FROM Taxas WHERE TaxasUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002626,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002627", "SELECT TaxasId FROM Taxas WHERE TaxasCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002627,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002628", "SELECT CreditoId FROM Credito WHERE CreditoUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002628,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002629", "SELECT CreditoId FROM Credito WHERE CreditoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002629,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002630", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogUser = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002630,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002631", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002631,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002632", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002632,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002633", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002633,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002634", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002634,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002635", "SELECT PropostaId FROM Proposta WHERE PropostaCratedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002635,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002636", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002636,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002637", "SELECT ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002637,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002638", "SELECT NotificationId FROM Notification WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002638,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002639", "SELECT AprovadoresId FROM Aprovadores WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002639,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002640", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002640,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002641", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002641,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002642", "SELECT SecUserId FROM SecUser ORDER BY SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002642,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
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
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
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
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 40 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
