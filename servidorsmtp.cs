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
   public class servidorsmtp : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "servidorsmtp")), "servidorsmtp") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "servidorsmtp")))) ;
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
                  AV7ServidorSMTPId = (short)(Math.Round(NumberUtil.Val( GetPar( "ServidorSMTPId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ServidorSMTPId", StringUtil.LTrimStr( (decimal)(AV7ServidorSMTPId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERVIDORSMTPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ServidorSMTPId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Servidor SMTP", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtServidorSMTPServer_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public servidorsmtp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public servidorsmtp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ServidorSMTPId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ServidorSMTPId = aP1_ServidorSMTPId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServidorSMTPServer_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServidorSMTPServer_Internalname, "Server", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServidorSMTPServer_Internalname, A159ServidorSMTPServer, StringUtil.RTrim( context.localUtil.Format( A159ServidorSMTPServer, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServidorSMTPServer_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServidorSMTPServer_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ServidorSMTP.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServidorSMTPPorta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServidorSMTPPorta_Internalname, "Porta", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServidorSMTPPorta_Internalname, A160ServidorSMTPPorta, StringUtil.RTrim( context.localUtil.Format( A160ServidorSMTPPorta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServidorSMTPPorta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServidorSMTPPorta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ServidorSMTP.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServidorSMTPEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServidorSMTPEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServidorSMTPEmail_Internalname, A161ServidorSMTPEmail, StringUtil.RTrim( context.localUtil.Format( A161ServidorSMTPEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A161ServidorSMTPEmail, "", "", "", edtServidorSMTPEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServidorSMTPEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ServidorSMTP.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServidorSMTPUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServidorSMTPUsuario_Internalname, "Usuário", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServidorSMTPUsuario_Internalname, A163ServidorSMTPUsuario, StringUtil.RTrim( context.localUtil.Format( A163ServidorSMTPUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServidorSMTPUsuario_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServidorSMTPUsuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ServidorSMTP.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServidorSMTPPass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtServidorSMTPPass_Internalname, "Senha", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServidorSMTPPass_Internalname, A162ServidorSMTPPass, StringUtil.RTrim( context.localUtil.Format( A162ServidorSMTPPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServidorSMTPPass_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServidorSMTPPass_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_ServidorSMTP.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ServidorSMTP.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ServidorSMTP.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ServidorSMTP.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtServidorSMTPId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ServidorSMTPId), 4, 0, ",", "")), StringUtil.LTrim( ((edtServidorSMTPId_Enabled!=0) ? context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9") : context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServidorSMTPId_Jsonclick, 0, "Attribute", "", "", "", "", edtServidorSMTPId_Visible, edtServidorSMTPId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ServidorSMTP.htm");
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
         E110M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z158ServidorSMTPId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z158ServidorSMTPId"), ",", "."), 18, MidpointRounding.ToEven));
               Z159ServidorSMTPServer = cgiGet( "Z159ServidorSMTPServer");
               n159ServidorSMTPServer = (String.IsNullOrEmpty(StringUtil.RTrim( A159ServidorSMTPServer)) ? true : false);
               Z160ServidorSMTPPorta = cgiGet( "Z160ServidorSMTPPorta");
               n160ServidorSMTPPorta = (String.IsNullOrEmpty(StringUtil.RTrim( A160ServidorSMTPPorta)) ? true : false);
               Z161ServidorSMTPEmail = cgiGet( "Z161ServidorSMTPEmail");
               n161ServidorSMTPEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A161ServidorSMTPEmail)) ? true : false);
               Z162ServidorSMTPPass = cgiGet( "Z162ServidorSMTPPass");
               n162ServidorSMTPPass = (String.IsNullOrEmpty(StringUtil.RTrim( A162ServidorSMTPPass)) ? true : false);
               Z163ServidorSMTPUsuario = cgiGet( "Z163ServidorSMTPUsuario");
               n163ServidorSMTPUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A163ServidorSMTPUsuario)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ServidorSMTPId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSERVIDORSMTPID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A159ServidorSMTPServer = cgiGet( edtServidorSMTPServer_Internalname);
               n159ServidorSMTPServer = false;
               AssignAttri("", false, "A159ServidorSMTPServer", A159ServidorSMTPServer);
               n159ServidorSMTPServer = (String.IsNullOrEmpty(StringUtil.RTrim( A159ServidorSMTPServer)) ? true : false);
               A160ServidorSMTPPorta = cgiGet( edtServidorSMTPPorta_Internalname);
               n160ServidorSMTPPorta = false;
               AssignAttri("", false, "A160ServidorSMTPPorta", A160ServidorSMTPPorta);
               n160ServidorSMTPPorta = (String.IsNullOrEmpty(StringUtil.RTrim( A160ServidorSMTPPorta)) ? true : false);
               A161ServidorSMTPEmail = cgiGet( edtServidorSMTPEmail_Internalname);
               n161ServidorSMTPEmail = false;
               AssignAttri("", false, "A161ServidorSMTPEmail", A161ServidorSMTPEmail);
               n161ServidorSMTPEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A161ServidorSMTPEmail)) ? true : false);
               A163ServidorSMTPUsuario = cgiGet( edtServidorSMTPUsuario_Internalname);
               n163ServidorSMTPUsuario = false;
               AssignAttri("", false, "A163ServidorSMTPUsuario", A163ServidorSMTPUsuario);
               n163ServidorSMTPUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A163ServidorSMTPUsuario)) ? true : false);
               A162ServidorSMTPPass = cgiGet( edtServidorSMTPPass_Internalname);
               n162ServidorSMTPPass = false;
               AssignAttri("", false, "A162ServidorSMTPPass", A162ServidorSMTPPass);
               n162ServidorSMTPPass = (String.IsNullOrEmpty(StringUtil.RTrim( A162ServidorSMTPPass)) ? true : false);
               A158ServidorSMTPId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtServidorSMTPId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ServidorSMTP");
               A158ServidorSMTPId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtServidorSMTPId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
               forbiddenHiddens.Add("ServidorSMTPId", context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A158ServidorSMTPId != Z158ServidorSMTPId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("servidorsmtp:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A158ServidorSMTPId = (short)(Math.Round(NumberUtil.Val( GetPar( "ServidorSMTPId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
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
                     sMode26 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode26;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound26 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERVIDORSMTPID");
                        AnyError = 1;
                        GX_FocusControl = edtServidorSMTPId_Internalname;
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
                           E110M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120M2 ();
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
            E120M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0M26( ) ;
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
            DisableAttributes0M26( ) ;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M26( ) ;
            }
            else
            {
               CheckExtendedTable0M26( ) ;
               CloseExtendedTableCursors0M26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0M0( )
      {
      }

      protected void E110M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtServidorSMTPId_Visible = 0;
         AssignProp("", false, edtServidorSMTPId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtServidorSMTPId_Visible), 5, 0), true);
      }

      protected void E120M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0M26( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z159ServidorSMTPServer = T000M3_A159ServidorSMTPServer[0];
               Z160ServidorSMTPPorta = T000M3_A160ServidorSMTPPorta[0];
               Z161ServidorSMTPEmail = T000M3_A161ServidorSMTPEmail[0];
               Z162ServidorSMTPPass = T000M3_A162ServidorSMTPPass[0];
               Z163ServidorSMTPUsuario = T000M3_A163ServidorSMTPUsuario[0];
            }
            else
            {
               Z159ServidorSMTPServer = A159ServidorSMTPServer;
               Z160ServidorSMTPPorta = A160ServidorSMTPPorta;
               Z161ServidorSMTPEmail = A161ServidorSMTPEmail;
               Z162ServidorSMTPPass = A162ServidorSMTPPass;
               Z163ServidorSMTPUsuario = A163ServidorSMTPUsuario;
            }
         }
         if ( GX_JID == -4 )
         {
            Z158ServidorSMTPId = A158ServidorSMTPId;
            Z159ServidorSMTPServer = A159ServidorSMTPServer;
            Z160ServidorSMTPPorta = A160ServidorSMTPPorta;
            Z161ServidorSMTPEmail = A161ServidorSMTPEmail;
            Z162ServidorSMTPPass = A162ServidorSMTPPass;
            Z163ServidorSMTPUsuario = A163ServidorSMTPUsuario;
         }
      }

      protected void standaloneNotModal( )
      {
         edtServidorSMTPId_Enabled = 0;
         AssignProp("", false, edtServidorSMTPId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPId_Enabled), 5, 0), true);
         edtServidorSMTPId_Enabled = 0;
         AssignProp("", false, edtServidorSMTPId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ServidorSMTPId) )
         {
            A158ServidorSMTPId = AV7ServidorSMTPId;
            AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
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

      protected void Load0M26( )
      {
         /* Using cursor T000M4 */
         pr_default.execute(2, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A159ServidorSMTPServer = T000M4_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = T000M4_n159ServidorSMTPServer[0];
            AssignAttri("", false, "A159ServidorSMTPServer", A159ServidorSMTPServer);
            A160ServidorSMTPPorta = T000M4_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = T000M4_n160ServidorSMTPPorta[0];
            AssignAttri("", false, "A160ServidorSMTPPorta", A160ServidorSMTPPorta);
            A161ServidorSMTPEmail = T000M4_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = T000M4_n161ServidorSMTPEmail[0];
            AssignAttri("", false, "A161ServidorSMTPEmail", A161ServidorSMTPEmail);
            A162ServidorSMTPPass = T000M4_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = T000M4_n162ServidorSMTPPass[0];
            AssignAttri("", false, "A162ServidorSMTPPass", A162ServidorSMTPPass);
            A163ServidorSMTPUsuario = T000M4_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = T000M4_n163ServidorSMTPUsuario[0];
            AssignAttri("", false, "A163ServidorSMTPUsuario", A163ServidorSMTPUsuario);
            ZM0M26( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0M26( ) ;
      }

      protected void OnLoadActions0M26( )
      {
      }

      protected void CheckExtendedTable0M26( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A161ServidorSMTPEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A161ServidorSMTPEmail)) ) )
         {
            GX_msglist.addItem("O valor de Servidor SMTPEmail não coincide com o padrão especificado", "OutOfRange", 1, "SERVIDORSMTPEMAIL");
            AnyError = 1;
            GX_FocusControl = edtServidorSMTPEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0M26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M26( )
      {
         /* Using cursor T000M5 */
         pr_default.execute(3, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M26( 4) ;
            RcdFound26 = 1;
            A158ServidorSMTPId = T000M3_A158ServidorSMTPId[0];
            AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
            A159ServidorSMTPServer = T000M3_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = T000M3_n159ServidorSMTPServer[0];
            AssignAttri("", false, "A159ServidorSMTPServer", A159ServidorSMTPServer);
            A160ServidorSMTPPorta = T000M3_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = T000M3_n160ServidorSMTPPorta[0];
            AssignAttri("", false, "A160ServidorSMTPPorta", A160ServidorSMTPPorta);
            A161ServidorSMTPEmail = T000M3_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = T000M3_n161ServidorSMTPEmail[0];
            AssignAttri("", false, "A161ServidorSMTPEmail", A161ServidorSMTPEmail);
            A162ServidorSMTPPass = T000M3_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = T000M3_n162ServidorSMTPPass[0];
            AssignAttri("", false, "A162ServidorSMTPPass", A162ServidorSMTPPass);
            A163ServidorSMTPUsuario = T000M3_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = T000M3_n163ServidorSMTPUsuario[0];
            AssignAttri("", false, "A163ServidorSMTPUsuario", A163ServidorSMTPUsuario);
            Z158ServidorSMTPId = A158ServidorSMTPId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0M26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0M26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0M26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M26( ) ;
         if ( RcdFound26 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound26 = 0;
         /* Using cursor T000M6 */
         pr_default.execute(4, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000M6_A158ServidorSMTPId[0] < A158ServidorSMTPId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000M6_A158ServidorSMTPId[0] > A158ServidorSMTPId ) ) )
            {
               A158ServidorSMTPId = T000M6_A158ServidorSMTPId[0];
               AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000M7 */
         pr_default.execute(5, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A158ServidorSMTPId[0] > A158ServidorSMTPId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A158ServidorSMTPId[0] < A158ServidorSMTPId ) ) )
            {
               A158ServidorSMTPId = T000M7_A158ServidorSMTPId[0];
               AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtServidorSMTPServer_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0M26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A158ServidorSMTPId != Z158ServidorSMTPId )
               {
                  A158ServidorSMTPId = Z158ServidorSMTPId;
                  AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERVIDORSMTPID");
                  AnyError = 1;
                  GX_FocusControl = edtServidorSMTPId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtServidorSMTPServer_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0M26( ) ;
                  GX_FocusControl = edtServidorSMTPServer_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A158ServidorSMTPId != Z158ServidorSMTPId )
               {
                  /* Insert record */
                  GX_FocusControl = edtServidorSMTPServer_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0M26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERVIDORSMTPID");
                     AnyError = 1;
                     GX_FocusControl = edtServidorSMTPId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtServidorSMTPServer_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0M26( ) ;
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
         if ( A158ServidorSMTPId != Z158ServidorSMTPId )
         {
            A158ServidorSMTPId = Z158ServidorSMTPId;
            AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERVIDORSMTPID");
            AnyError = 1;
            GX_FocusControl = edtServidorSMTPId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtServidorSMTPServer_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0M26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A158ServidorSMTPId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ServidorSMTP"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z159ServidorSMTPServer, T000M2_A159ServidorSMTPServer[0]) != 0 ) || ( StringUtil.StrCmp(Z160ServidorSMTPPorta, T000M2_A160ServidorSMTPPorta[0]) != 0 ) || ( StringUtil.StrCmp(Z161ServidorSMTPEmail, T000M2_A161ServidorSMTPEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z162ServidorSMTPPass, T000M2_A162ServidorSMTPPass[0]) != 0 ) || ( StringUtil.StrCmp(Z163ServidorSMTPUsuario, T000M2_A163ServidorSMTPUsuario[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z159ServidorSMTPServer, T000M2_A159ServidorSMTPServer[0]) != 0 )
               {
                  GXUtil.WriteLog("servidorsmtp:[seudo value changed for attri]"+"ServidorSMTPServer");
                  GXUtil.WriteLogRaw("Old: ",Z159ServidorSMTPServer);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A159ServidorSMTPServer[0]);
               }
               if ( StringUtil.StrCmp(Z160ServidorSMTPPorta, T000M2_A160ServidorSMTPPorta[0]) != 0 )
               {
                  GXUtil.WriteLog("servidorsmtp:[seudo value changed for attri]"+"ServidorSMTPPorta");
                  GXUtil.WriteLogRaw("Old: ",Z160ServidorSMTPPorta);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A160ServidorSMTPPorta[0]);
               }
               if ( StringUtil.StrCmp(Z161ServidorSMTPEmail, T000M2_A161ServidorSMTPEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("servidorsmtp:[seudo value changed for attri]"+"ServidorSMTPEmail");
                  GXUtil.WriteLogRaw("Old: ",Z161ServidorSMTPEmail);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A161ServidorSMTPEmail[0]);
               }
               if ( StringUtil.StrCmp(Z162ServidorSMTPPass, T000M2_A162ServidorSMTPPass[0]) != 0 )
               {
                  GXUtil.WriteLog("servidorsmtp:[seudo value changed for attri]"+"ServidorSMTPPass");
                  GXUtil.WriteLogRaw("Old: ",Z162ServidorSMTPPass);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A162ServidorSMTPPass[0]);
               }
               if ( StringUtil.StrCmp(Z163ServidorSMTPUsuario, T000M2_A163ServidorSMTPUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("servidorsmtp:[seudo value changed for attri]"+"ServidorSMTPUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z163ServidorSMTPUsuario);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A163ServidorSMTPUsuario[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ServidorSMTP"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M26( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M26( 0) ;
            CheckOptimisticConcurrency0M26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M8 */
                     pr_default.execute(6, new Object[] {n159ServidorSMTPServer, A159ServidorSMTPServer, n160ServidorSMTPPorta, A160ServidorSMTPPorta, n161ServidorSMTPEmail, A161ServidorSMTPEmail, n162ServidorSMTPPass, A162ServidorSMTPPass, n163ServidorSMTPUsuario, A163ServidorSMTPUsuario});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000M9 */
                     pr_default.execute(7);
                     A158ServidorSMTPId = T000M9_A158ServidorSMTPId[0];
                     AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ServidorSMTP");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0M0( ) ;
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
               Load0M26( ) ;
            }
            EndLevel0M26( ) ;
         }
         CloseExtendedTableCursors0M26( ) ;
      }

      protected void Update0M26( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M10 */
                     pr_default.execute(8, new Object[] {n159ServidorSMTPServer, A159ServidorSMTPServer, n160ServidorSMTPPorta, A160ServidorSMTPPorta, n161ServidorSMTPEmail, A161ServidorSMTPEmail, n162ServidorSMTPPass, A162ServidorSMTPPass, n163ServidorSMTPUsuario, A163ServidorSMTPUsuario, A158ServidorSMTPId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ServidorSMTP");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ServidorSMTP"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M26( ) ;
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
            EndLevel0M26( ) ;
         }
         CloseExtendedTableCursors0M26( ) ;
      }

      protected void DeferredUpdate0M26( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M26( ) ;
            AfterConfirm0M26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M11 */
                  pr_default.execute(9, new Object[] {A158ServidorSMTPId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("ServidorSMTP");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0M26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("servidorsmtp",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("servidorsmtp",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M26( )
      {
         /* Scan By routine */
         /* Using cursor T000M12 */
         pr_default.execute(10);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound26 = 1;
            A158ServidorSMTPId = T000M12_A158ServidorSMTPId[0];
            AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M26( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound26 = 1;
            A158ServidorSMTPId = T000M12_A158ServidorSMTPId[0];
            AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
         }
      }

      protected void ScanEnd0M26( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0M26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M26( )
      {
         edtServidorSMTPServer_Enabled = 0;
         AssignProp("", false, edtServidorSMTPServer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPServer_Enabled), 5, 0), true);
         edtServidorSMTPPorta_Enabled = 0;
         AssignProp("", false, edtServidorSMTPPorta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPPorta_Enabled), 5, 0), true);
         edtServidorSMTPEmail_Enabled = 0;
         AssignProp("", false, edtServidorSMTPEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPEmail_Enabled), 5, 0), true);
         edtServidorSMTPUsuario_Enabled = 0;
         AssignProp("", false, edtServidorSMTPUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPUsuario_Enabled), 5, 0), true);
         edtServidorSMTPPass_Enabled = 0;
         AssignProp("", false, edtServidorSMTPPass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPPass_Enabled), 5, 0), true);
         edtServidorSMTPId_Enabled = 0;
         AssignProp("", false, edtServidorSMTPId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServidorSMTPId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0M26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0M0( )
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
         GXEncryptionTmp = "servidorsmtp"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ServidorSMTPId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("servidorsmtp") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ServidorSMTP");
         forbiddenHiddens.Add("ServidorSMTPId", context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("servidorsmtp:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z158ServidorSMTPId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z158ServidorSMTPId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z159ServidorSMTPServer", Z159ServidorSMTPServer);
         GxWebStd.gx_hidden_field( context, "Z160ServidorSMTPPorta", Z160ServidorSMTPPorta);
         GxWebStd.gx_hidden_field( context, "Z161ServidorSMTPEmail", Z161ServidorSMTPEmail);
         GxWebStd.gx_hidden_field( context, "Z162ServidorSMTPPass", Z162ServidorSMTPPass);
         GxWebStd.gx_hidden_field( context, "Z163ServidorSMTPUsuario", Z163ServidorSMTPUsuario);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vSERVIDORSMTPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ServidorSMTPId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERVIDORSMTPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ServidorSMTPId), "ZZZ9"), context));
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
         GXEncryptionTmp = "servidorsmtp"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ServidorSMTPId,4,0));
         return formatLink("servidorsmtp") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ServidorSMTP" ;
      }

      public override string GetPgmdesc( )
      {
         return "Servidor SMTP" ;
      }

      protected void InitializeNonKey0M26( )
      {
         A159ServidorSMTPServer = "";
         n159ServidorSMTPServer = false;
         AssignAttri("", false, "A159ServidorSMTPServer", A159ServidorSMTPServer);
         n159ServidorSMTPServer = (String.IsNullOrEmpty(StringUtil.RTrim( A159ServidorSMTPServer)) ? true : false);
         A160ServidorSMTPPorta = "";
         n160ServidorSMTPPorta = false;
         AssignAttri("", false, "A160ServidorSMTPPorta", A160ServidorSMTPPorta);
         n160ServidorSMTPPorta = (String.IsNullOrEmpty(StringUtil.RTrim( A160ServidorSMTPPorta)) ? true : false);
         A161ServidorSMTPEmail = "";
         n161ServidorSMTPEmail = false;
         AssignAttri("", false, "A161ServidorSMTPEmail", A161ServidorSMTPEmail);
         n161ServidorSMTPEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A161ServidorSMTPEmail)) ? true : false);
         A162ServidorSMTPPass = "";
         n162ServidorSMTPPass = false;
         AssignAttri("", false, "A162ServidorSMTPPass", A162ServidorSMTPPass);
         n162ServidorSMTPPass = (String.IsNullOrEmpty(StringUtil.RTrim( A162ServidorSMTPPass)) ? true : false);
         A163ServidorSMTPUsuario = "";
         n163ServidorSMTPUsuario = false;
         AssignAttri("", false, "A163ServidorSMTPUsuario", A163ServidorSMTPUsuario);
         n163ServidorSMTPUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A163ServidorSMTPUsuario)) ? true : false);
         Z159ServidorSMTPServer = "";
         Z160ServidorSMTPPorta = "";
         Z161ServidorSMTPEmail = "";
         Z162ServidorSMTPPass = "";
         Z163ServidorSMTPUsuario = "";
      }

      protected void InitAll0M26( )
      {
         A158ServidorSMTPId = 0;
         AssignAttri("", false, "A158ServidorSMTPId", StringUtil.LTrimStr( (decimal)(A158ServidorSMTPId), 4, 0));
         InitializeNonKey0M26( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101913192", true, true);
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
         context.AddJavascriptSource("servidorsmtp.js", "?20256101913193", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtServidorSMTPServer_Internalname = "SERVIDORSMTPSERVER";
         edtServidorSMTPPorta_Internalname = "SERVIDORSMTPPORTA";
         edtServidorSMTPEmail_Internalname = "SERVIDORSMTPEMAIL";
         edtServidorSMTPUsuario_Internalname = "SERVIDORSMTPUSUARIO";
         edtServidorSMTPPass_Internalname = "SERVIDORSMTPPASS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtServidorSMTPId_Internalname = "SERVIDORSMTPID";
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
         Form.Caption = "Servidor SMTP";
         edtServidorSMTPId_Jsonclick = "";
         edtServidorSMTPId_Enabled = 0;
         edtServidorSMTPId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtServidorSMTPPass_Jsonclick = "";
         edtServidorSMTPPass_Enabled = 1;
         edtServidorSMTPUsuario_Jsonclick = "";
         edtServidorSMTPUsuario_Enabled = 1;
         edtServidorSMTPEmail_Jsonclick = "";
         edtServidorSMTPEmail_Enabled = 1;
         edtServidorSMTPPorta_Jsonclick = "";
         edtServidorSMTPPorta_Enabled = 1;
         edtServidorSMTPServer_Jsonclick = "";
         edtServidorSMTPServer_Enabled = 1;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ServidorSMTPId","fld":"vSERVIDORSMTPID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ServidorSMTPId","fld":"vSERVIDORSMTPID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A158ServidorSMTPId","fld":"SERVIDORSMTPID","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120M2","iparms":[]}""");
         setEventMetadata("VALID_SERVIDORSMTPEMAIL","""{"handler":"Valid_Servidorsmtpemail","iparms":[]}""");
         setEventMetadata("VALID_SERVIDORSMTPID","""{"handler":"Valid_Servidorsmtpid","iparms":[]}""");
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
         Z159ServidorSMTPServer = "";
         Z160ServidorSMTPPorta = "";
         Z161ServidorSMTPEmail = "";
         Z162ServidorSMTPPass = "";
         Z163ServidorSMTPUsuario = "";
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
         A159ServidorSMTPServer = "";
         A160ServidorSMTPPorta = "";
         A161ServidorSMTPEmail = "";
         A163ServidorSMTPUsuario = "";
         A162ServidorSMTPPass = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode26 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000M4_A158ServidorSMTPId = new short[1] ;
         T000M4_A159ServidorSMTPServer = new string[] {""} ;
         T000M4_n159ServidorSMTPServer = new bool[] {false} ;
         T000M4_A160ServidorSMTPPorta = new string[] {""} ;
         T000M4_n160ServidorSMTPPorta = new bool[] {false} ;
         T000M4_A161ServidorSMTPEmail = new string[] {""} ;
         T000M4_n161ServidorSMTPEmail = new bool[] {false} ;
         T000M4_A162ServidorSMTPPass = new string[] {""} ;
         T000M4_n162ServidorSMTPPass = new bool[] {false} ;
         T000M4_A163ServidorSMTPUsuario = new string[] {""} ;
         T000M4_n163ServidorSMTPUsuario = new bool[] {false} ;
         T000M5_A158ServidorSMTPId = new short[1] ;
         T000M3_A158ServidorSMTPId = new short[1] ;
         T000M3_A159ServidorSMTPServer = new string[] {""} ;
         T000M3_n159ServidorSMTPServer = new bool[] {false} ;
         T000M3_A160ServidorSMTPPorta = new string[] {""} ;
         T000M3_n160ServidorSMTPPorta = new bool[] {false} ;
         T000M3_A161ServidorSMTPEmail = new string[] {""} ;
         T000M3_n161ServidorSMTPEmail = new bool[] {false} ;
         T000M3_A162ServidorSMTPPass = new string[] {""} ;
         T000M3_n162ServidorSMTPPass = new bool[] {false} ;
         T000M3_A163ServidorSMTPUsuario = new string[] {""} ;
         T000M3_n163ServidorSMTPUsuario = new bool[] {false} ;
         T000M6_A158ServidorSMTPId = new short[1] ;
         T000M7_A158ServidorSMTPId = new short[1] ;
         T000M2_A158ServidorSMTPId = new short[1] ;
         T000M2_A159ServidorSMTPServer = new string[] {""} ;
         T000M2_n159ServidorSMTPServer = new bool[] {false} ;
         T000M2_A160ServidorSMTPPorta = new string[] {""} ;
         T000M2_n160ServidorSMTPPorta = new bool[] {false} ;
         T000M2_A161ServidorSMTPEmail = new string[] {""} ;
         T000M2_n161ServidorSMTPEmail = new bool[] {false} ;
         T000M2_A162ServidorSMTPPass = new string[] {""} ;
         T000M2_n162ServidorSMTPPass = new bool[] {false} ;
         T000M2_A163ServidorSMTPUsuario = new string[] {""} ;
         T000M2_n163ServidorSMTPUsuario = new bool[] {false} ;
         T000M9_A158ServidorSMTPId = new short[1] ;
         T000M12_A158ServidorSMTPId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.servidorsmtp__default(),
            new Object[][] {
                new Object[] {
               T000M2_A158ServidorSMTPId, T000M2_A159ServidorSMTPServer, T000M2_n159ServidorSMTPServer, T000M2_A160ServidorSMTPPorta, T000M2_n160ServidorSMTPPorta, T000M2_A161ServidorSMTPEmail, T000M2_n161ServidorSMTPEmail, T000M2_A162ServidorSMTPPass, T000M2_n162ServidorSMTPPass, T000M2_A163ServidorSMTPUsuario,
               T000M2_n163ServidorSMTPUsuario
               }
               , new Object[] {
               T000M3_A158ServidorSMTPId, T000M3_A159ServidorSMTPServer, T000M3_n159ServidorSMTPServer, T000M3_A160ServidorSMTPPorta, T000M3_n160ServidorSMTPPorta, T000M3_A161ServidorSMTPEmail, T000M3_n161ServidorSMTPEmail, T000M3_A162ServidorSMTPPass, T000M3_n162ServidorSMTPPass, T000M3_A163ServidorSMTPUsuario,
               T000M3_n163ServidorSMTPUsuario
               }
               , new Object[] {
               T000M4_A158ServidorSMTPId, T000M4_A159ServidorSMTPServer, T000M4_n159ServidorSMTPServer, T000M4_A160ServidorSMTPPorta, T000M4_n160ServidorSMTPPorta, T000M4_A161ServidorSMTPEmail, T000M4_n161ServidorSMTPEmail, T000M4_A162ServidorSMTPPass, T000M4_n162ServidorSMTPPass, T000M4_A163ServidorSMTPUsuario,
               T000M4_n163ServidorSMTPUsuario
               }
               , new Object[] {
               T000M5_A158ServidorSMTPId
               }
               , new Object[] {
               T000M6_A158ServidorSMTPId
               }
               , new Object[] {
               T000M7_A158ServidorSMTPId
               }
               , new Object[] {
               }
               , new Object[] {
               T000M9_A158ServidorSMTPId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M12_A158ServidorSMTPId
               }
            }
         );
      }

      private short wcpOAV7ServidorSMTPId ;
      private short Z158ServidorSMTPId ;
      private short GxWebError ;
      private short AV7ServidorSMTPId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A158ServidorSMTPId ;
      private short RcdFound26 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtServidorSMTPServer_Enabled ;
      private int edtServidorSMTPPorta_Enabled ;
      private int edtServidorSMTPEmail_Enabled ;
      private int edtServidorSMTPUsuario_Enabled ;
      private int edtServidorSMTPPass_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtServidorSMTPId_Enabled ;
      private int edtServidorSMTPId_Visible ;
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
      private string edtServidorSMTPServer_Internalname ;
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
      private string edtServidorSMTPServer_Jsonclick ;
      private string edtServidorSMTPPorta_Internalname ;
      private string edtServidorSMTPPorta_Jsonclick ;
      private string edtServidorSMTPEmail_Internalname ;
      private string edtServidorSMTPEmail_Jsonclick ;
      private string edtServidorSMTPUsuario_Internalname ;
      private string edtServidorSMTPUsuario_Jsonclick ;
      private string edtServidorSMTPPass_Internalname ;
      private string edtServidorSMTPPass_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtServidorSMTPId_Internalname ;
      private string edtServidorSMTPId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode26 ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n159ServidorSMTPServer ;
      private bool n160ServidorSMTPPorta ;
      private bool n161ServidorSMTPEmail ;
      private bool n162ServidorSMTPPass ;
      private bool n163ServidorSMTPUsuario ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string Z159ServidorSMTPServer ;
      private string Z160ServidorSMTPPorta ;
      private string Z161ServidorSMTPEmail ;
      private string Z162ServidorSMTPPass ;
      private string Z163ServidorSMTPUsuario ;
      private string A159ServidorSMTPServer ;
      private string A160ServidorSMTPPorta ;
      private string A161ServidorSMTPEmail ;
      private string A163ServidorSMTPUsuario ;
      private string A162ServidorSMTPPass ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000M4_A158ServidorSMTPId ;
      private string[] T000M4_A159ServidorSMTPServer ;
      private bool[] T000M4_n159ServidorSMTPServer ;
      private string[] T000M4_A160ServidorSMTPPorta ;
      private bool[] T000M4_n160ServidorSMTPPorta ;
      private string[] T000M4_A161ServidorSMTPEmail ;
      private bool[] T000M4_n161ServidorSMTPEmail ;
      private string[] T000M4_A162ServidorSMTPPass ;
      private bool[] T000M4_n162ServidorSMTPPass ;
      private string[] T000M4_A163ServidorSMTPUsuario ;
      private bool[] T000M4_n163ServidorSMTPUsuario ;
      private short[] T000M5_A158ServidorSMTPId ;
      private short[] T000M3_A158ServidorSMTPId ;
      private string[] T000M3_A159ServidorSMTPServer ;
      private bool[] T000M3_n159ServidorSMTPServer ;
      private string[] T000M3_A160ServidorSMTPPorta ;
      private bool[] T000M3_n160ServidorSMTPPorta ;
      private string[] T000M3_A161ServidorSMTPEmail ;
      private bool[] T000M3_n161ServidorSMTPEmail ;
      private string[] T000M3_A162ServidorSMTPPass ;
      private bool[] T000M3_n162ServidorSMTPPass ;
      private string[] T000M3_A163ServidorSMTPUsuario ;
      private bool[] T000M3_n163ServidorSMTPUsuario ;
      private short[] T000M6_A158ServidorSMTPId ;
      private short[] T000M7_A158ServidorSMTPId ;
      private short[] T000M2_A158ServidorSMTPId ;
      private string[] T000M2_A159ServidorSMTPServer ;
      private bool[] T000M2_n159ServidorSMTPServer ;
      private string[] T000M2_A160ServidorSMTPPorta ;
      private bool[] T000M2_n160ServidorSMTPPorta ;
      private string[] T000M2_A161ServidorSMTPEmail ;
      private bool[] T000M2_n161ServidorSMTPEmail ;
      private string[] T000M2_A162ServidorSMTPPass ;
      private bool[] T000M2_n162ServidorSMTPPass ;
      private string[] T000M2_A163ServidorSMTPUsuario ;
      private bool[] T000M2_n163ServidorSMTPUsuario ;
      private short[] T000M9_A158ServidorSMTPId ;
      private short[] T000M12_A158ServidorSMTPId ;
   }

   public class servidorsmtp__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000M2;
          prmT000M2 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M3;
          prmT000M3 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M4;
          prmT000M4 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M5;
          prmT000M5 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M6;
          prmT000M6 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M7;
          prmT000M7 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M8;
          prmT000M8 = new Object[] {
          new ParDef("ServidorSMTPServer",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPPorta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ServidorSMTPPass",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ServidorSMTPUsuario",GXType.VarChar,90,0){Nullable=true}
          };
          Object[] prmT000M9;
          prmT000M9 = new Object[] {
          };
          Object[] prmT000M10;
          prmT000M10 = new Object[] {
          new ParDef("ServidorSMTPServer",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPPorta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ServidorSMTPPass",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ServidorSMTPUsuario",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M11;
          prmT000M11 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmT000M12;
          prmT000M12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000M2", "SELECT ServidorSMTPId, ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario FROM ServidorSMTP WHERE ServidorSMTPId = :ServidorSMTPId  FOR UPDATE OF ServidorSMTP NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000M3", "SELECT ServidorSMTPId, ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario FROM ServidorSMTP WHERE ServidorSMTPId = :ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000M4", "SELECT TM1.ServidorSMTPId, TM1.ServidorSMTPServer, TM1.ServidorSMTPPorta, TM1.ServidorSMTPEmail, TM1.ServidorSMTPPass, TM1.ServidorSMTPUsuario FROM ServidorSMTP TM1 WHERE TM1.ServidorSMTPId = :ServidorSMTPId ORDER BY TM1.ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000M5", "SELECT ServidorSMTPId FROM ServidorSMTP WHERE ServidorSMTPId = :ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000M6", "SELECT ServidorSMTPId FROM ServidorSMTP WHERE ( ServidorSMTPId > :ServidorSMTPId) ORDER BY ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000M7", "SELECT ServidorSMTPId FROM ServidorSMTP WHERE ( ServidorSMTPId < :ServidorSMTPId) ORDER BY ServidorSMTPId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000M8", "SAVEPOINT gxupdate;INSERT INTO ServidorSMTP(ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario) VALUES(:ServidorSMTPServer, :ServidorSMTPPorta, :ServidorSMTPEmail, :ServidorSMTPPass, :ServidorSMTPUsuario);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000M8)
             ,new CursorDef("T000M9", "SELECT currval('ServidorSMTPId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000M10", "SAVEPOINT gxupdate;UPDATE ServidorSMTP SET ServidorSMTPServer=:ServidorSMTPServer, ServidorSMTPPorta=:ServidorSMTPPorta, ServidorSMTPEmail=:ServidorSMTPEmail, ServidorSMTPPass=:ServidorSMTPPass, ServidorSMTPUsuario=:ServidorSMTPUsuario  WHERE ServidorSMTPId = :ServidorSMTPId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000M10)
             ,new CursorDef("T000M11", "SAVEPOINT gxupdate;DELETE FROM ServidorSMTP  WHERE ServidorSMTPId = :ServidorSMTPId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000M11)
             ,new CursorDef("T000M12", "SELECT ServidorSMTPId FROM ServidorSMTP ORDER BY ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
