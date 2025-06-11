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
   public class participante : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action9") == 0 )
         {
            A234ParticipanteDocumento = GetPar( "ParticipanteDocumento");
            n234ParticipanteDocumento = false;
            AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_9_0Z38( A234ParticipanteDocumento) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "participante")), "participante") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "participante")))) ;
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
                  AV7ParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ParticipanteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ParticipanteId", StringUtil.LTrimStr( (decimal)(AV7ParticipanteId), 8, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ParticipanteId), "ZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Participante", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParticipanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public participante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public participante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ParticipanteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ParticipanteId = aP1_ParticipanteId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteNome_Internalname, A248ParticipanteNome, StringUtil.RTrim( context.localUtil.Format( A248ParticipanteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParticipanteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Participante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteDocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteDocumento_Internalname, A234ParticipanteDocumento, StringUtil.RTrim( context.localUtil.Format( A234ParticipanteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteDocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParticipanteDocumento_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Participante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteEmail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteEmail_Internalname, A235ParticipanteEmail, StringUtil.RTrim( context.localUtil.Format( A235ParticipanteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A235ParticipanteEmail, "", "", "", edtParticipanteEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParticipanteEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Participante.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Participante.htm");
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
         GxWebStd.gx_single_line_edit( context, edtParticipanteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", "")), StringUtil.LTrim( ((edtParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", edtParticipanteId_Visible, edtParticipanteId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Participante.htm");
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
         E110Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z233ParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
               Z234ParticipanteDocumento = cgiGet( "Z234ParticipanteDocumento");
               n234ParticipanteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) ? true : false);
               Z248ParticipanteNome = cgiGet( "Z248ParticipanteNome");
               n248ParticipanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) ? true : false);
               Z235ParticipanteEmail = cgiGet( "Z235ParticipanteEmail");
               n235ParticipanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ? true : false);
               Z1001ParticipanteTipoPessoa = cgiGet( "Z1001ParticipanteTipoPessoa");
               n1001ParticipanteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A1001ParticipanteTipoPessoa)) ? true : false);
               Z1002ParticipanteRepresentanteNome = cgiGet( "Z1002ParticipanteRepresentanteNome");
               n1002ParticipanteRepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1002ParticipanteRepresentanteNome)) ? true : false);
               Z1003ParticipanteRepresentanteEmail = cgiGet( "Z1003ParticipanteRepresentanteEmail");
               n1003ParticipanteRepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A1003ParticipanteRepresentanteEmail)) ? true : false);
               Z1004ParticipanteRepresentanteDocumento = cgiGet( "Z1004ParticipanteRepresentanteDocumento");
               n1004ParticipanteRepresentanteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1004ParticipanteRepresentanteDocumento)) ? true : false);
               A1001ParticipanteTipoPessoa = cgiGet( "Z1001ParticipanteTipoPessoa");
               n1001ParticipanteTipoPessoa = false;
               n1001ParticipanteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A1001ParticipanteTipoPessoa)) ? true : false);
               A1002ParticipanteRepresentanteNome = cgiGet( "Z1002ParticipanteRepresentanteNome");
               n1002ParticipanteRepresentanteNome = false;
               n1002ParticipanteRepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1002ParticipanteRepresentanteNome)) ? true : false);
               A1003ParticipanteRepresentanteEmail = cgiGet( "Z1003ParticipanteRepresentanteEmail");
               n1003ParticipanteRepresentanteEmail = false;
               n1003ParticipanteRepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A1003ParticipanteRepresentanteEmail)) ? true : false);
               A1004ParticipanteRepresentanteDocumento = cgiGet( "Z1004ParticipanteRepresentanteDocumento");
               n1004ParticipanteRepresentanteDocumento = false;
               n1004ParticipanteRepresentanteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1004ParticipanteRepresentanteDocumento)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               A1001ParticipanteTipoPessoa = cgiGet( "PARTICIPANTETIPOPESSOA");
               n1001ParticipanteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A1001ParticipanteTipoPessoa)) ? true : false);
               A1004ParticipanteRepresentanteDocumento = cgiGet( "PARTICIPANTEREPRESENTANTEDOCUMENTO");
               n1004ParticipanteRepresentanteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1004ParticipanteRepresentanteDocumento)) ? true : false);
               A1006ParticipanteDocumento_F = cgiGet( "PARTICIPANTEDOCUMENTO_F");
               A1003ParticipanteRepresentanteEmail = cgiGet( "PARTICIPANTEREPRESENTANTEEMAIL");
               n1003ParticipanteRepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A1003ParticipanteRepresentanteEmail)) ? true : false);
               A1005ParticipanteEmail_F = cgiGet( "PARTICIPANTEEMAIL_F");
               AV7ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPARTICIPANTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11isOk = StringUtil.StrToBool( cgiGet( "vISOK"));
               AV12ErroMsg = cgiGet( "vERROMSG");
               A1002ParticipanteRepresentanteNome = cgiGet( "PARTICIPANTEREPRESENTANTENOME");
               n1002ParticipanteRepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1002ParticipanteRepresentanteNome)) ? true : false);
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
               A248ParticipanteNome = cgiGet( edtParticipanteNome_Internalname);
               n248ParticipanteNome = false;
               AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
               n248ParticipanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) ? true : false);
               A234ParticipanteDocumento = cgiGet( edtParticipanteDocumento_Internalname);
               n234ParticipanteDocumento = false;
               AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
               n234ParticipanteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) ? true : false);
               A235ParticipanteEmail = cgiGet( edtParticipanteEmail_Internalname);
               n235ParticipanteEmail = false;
               AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
               n235ParticipanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ? true : false);
               A233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n233ParticipanteId = false;
               AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Participante");
               A233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n233ParticipanteId = false;
               AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
               forbiddenHiddens.Add("ParticipanteId", context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ParticipanteTipoPessoa", StringUtil.RTrim( context.localUtil.Format( A1001ParticipanteTipoPessoa, "")));
               forbiddenHiddens.Add("ParticipanteRepresentanteNome", StringUtil.RTrim( context.localUtil.Format( A1002ParticipanteRepresentanteNome, "")));
               forbiddenHiddens.Add("ParticipanteRepresentanteEmail", StringUtil.RTrim( context.localUtil.Format( A1003ParticipanteRepresentanteEmail, "")));
               forbiddenHiddens.Add("ParticipanteRepresentanteDocumento", StringUtil.RTrim( context.localUtil.Format( A1004ParticipanteRepresentanteDocumento, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A233ParticipanteId != Z233ParticipanteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("participante:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A233ParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ParticipanteId"), "."), 18, MidpointRounding.ToEven));
                  n233ParticipanteId = false;
                  AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
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
                     sMode38 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode38;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound38 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Z0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARTICIPANTEID");
                        AnyError = 1;
                        GX_FocusControl = edtParticipanteId_Internalname;
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
                           E110Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120Z2 ();
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
            E120Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Z38( ) ;
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
            DisableAttributes0Z38( ) ;
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

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z38( ) ;
            }
            else
            {
               CheckExtendedTable0Z38( ) ;
               CloseExtendedTableCursors0Z38( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0Z0( )
      {
      }

      protected void E110Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtParticipanteId_Visible = 0;
         AssignProp("", false, edtParticipanteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParticipanteId_Visible), 5, 0), true);
      }

      protected void E120Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("participanteww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0Z38( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z234ParticipanteDocumento = T000Z3_A234ParticipanteDocumento[0];
               Z248ParticipanteNome = T000Z3_A248ParticipanteNome[0];
               Z235ParticipanteEmail = T000Z3_A235ParticipanteEmail[0];
               Z1001ParticipanteTipoPessoa = T000Z3_A1001ParticipanteTipoPessoa[0];
               Z1002ParticipanteRepresentanteNome = T000Z3_A1002ParticipanteRepresentanteNome[0];
               Z1003ParticipanteRepresentanteEmail = T000Z3_A1003ParticipanteRepresentanteEmail[0];
               Z1004ParticipanteRepresentanteDocumento = T000Z3_A1004ParticipanteRepresentanteDocumento[0];
            }
            else
            {
               Z234ParticipanteDocumento = A234ParticipanteDocumento;
               Z248ParticipanteNome = A248ParticipanteNome;
               Z235ParticipanteEmail = A235ParticipanteEmail;
               Z1001ParticipanteTipoPessoa = A1001ParticipanteTipoPessoa;
               Z1002ParticipanteRepresentanteNome = A1002ParticipanteRepresentanteNome;
               Z1003ParticipanteRepresentanteEmail = A1003ParticipanteRepresentanteEmail;
               Z1004ParticipanteRepresentanteDocumento = A1004ParticipanteRepresentanteDocumento;
            }
         }
         if ( GX_JID == -11 )
         {
            Z233ParticipanteId = A233ParticipanteId;
            Z234ParticipanteDocumento = A234ParticipanteDocumento;
            Z248ParticipanteNome = A248ParticipanteNome;
            Z235ParticipanteEmail = A235ParticipanteEmail;
            Z1001ParticipanteTipoPessoa = A1001ParticipanteTipoPessoa;
            Z1002ParticipanteRepresentanteNome = A1002ParticipanteRepresentanteNome;
            Z1003ParticipanteRepresentanteEmail = A1003ParticipanteRepresentanteEmail;
            Z1004ParticipanteRepresentanteDocumento = A1004ParticipanteRepresentanteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
         edtParticipanteId_Enabled = 0;
         AssignProp("", false, edtParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteId_Enabled), 5, 0), true);
         edtParticipanteId_Enabled = 0;
         AssignProp("", false, edtParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ParticipanteId) )
         {
            A233ParticipanteId = AV7ParticipanteId;
            n233ParticipanteId = false;
            AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
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

      protected void Load0Z38( )
      {
         /* Using cursor T000Z4 */
         pr_default.execute(2, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound38 = 1;
            A234ParticipanteDocumento = T000Z4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = T000Z4_n234ParticipanteDocumento[0];
            AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
            A248ParticipanteNome = T000Z4_A248ParticipanteNome[0];
            n248ParticipanteNome = T000Z4_n248ParticipanteNome[0];
            AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
            A235ParticipanteEmail = T000Z4_A235ParticipanteEmail[0];
            n235ParticipanteEmail = T000Z4_n235ParticipanteEmail[0];
            AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
            A1001ParticipanteTipoPessoa = T000Z4_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = T000Z4_n1001ParticipanteTipoPessoa[0];
            A1002ParticipanteRepresentanteNome = T000Z4_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = T000Z4_n1002ParticipanteRepresentanteNome[0];
            A1003ParticipanteRepresentanteEmail = T000Z4_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = T000Z4_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = T000Z4_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = T000Z4_n1004ParticipanteRepresentanteDocumento[0];
            ZM0Z38( -11) ;
         }
         pr_default.close(2);
         OnLoadActions0Z38( ) ;
      }

      protected void OnLoadActions0Z38( )
      {
         A1006ParticipanteDocumento_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1004ParticipanteRepresentanteDocumento : A234ParticipanteDocumento);
         AssignAttri("", false, "A1006ParticipanteDocumento_F", A1006ParticipanteDocumento_F);
         A1005ParticipanteEmail_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1003ParticipanteRepresentanteEmail : A235ParticipanteEmail);
         AssignAttri("", false, "A1005ParticipanteEmail_F", A1005ParticipanteEmail_F);
      }

      protected void CheckExtendedTable0Z38( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         A1006ParticipanteDocumento_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1004ParticipanteRepresentanteDocumento : A234ParticipanteDocumento);
         AssignAttri("", false, "A1006ParticipanteDocumento_F", A1006ParticipanteDocumento_F);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Participante Documento", "", "", "", "", "", "", "", ""), 1, "PARTICIPANTEDOCUMENTO");
            AnyError = 1;
            GX_FocusControl = edtParticipanteDocumento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Participante Nome", "", "", "", "", "", "", "", ""), 1, "PARTICIPANTENOME");
            AnyError = 1;
            GX_FocusControl = edtParticipanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A235ParticipanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Participante Email não coincide com o padrão especificado", "OutOfRange", 1, "PARTICIPANTEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtParticipanteEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1005ParticipanteEmail_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1003ParticipanteRepresentanteEmail : A235ParticipanteEmail);
         AssignAttri("", false, "A1005ParticipanteEmail_F", A1005ParticipanteEmail_F);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Participante Email", "", "", "", "", "", "", "", ""), 1, "PARTICIPANTEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtParticipanteEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0Z38( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Z38( )
      {
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z38( 11) ;
            RcdFound38 = 1;
            A233ParticipanteId = T000Z3_A233ParticipanteId[0];
            n233ParticipanteId = T000Z3_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
            A234ParticipanteDocumento = T000Z3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = T000Z3_n234ParticipanteDocumento[0];
            AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
            A248ParticipanteNome = T000Z3_A248ParticipanteNome[0];
            n248ParticipanteNome = T000Z3_n248ParticipanteNome[0];
            AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
            A235ParticipanteEmail = T000Z3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = T000Z3_n235ParticipanteEmail[0];
            AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
            A1001ParticipanteTipoPessoa = T000Z3_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = T000Z3_n1001ParticipanteTipoPessoa[0];
            A1002ParticipanteRepresentanteNome = T000Z3_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = T000Z3_n1002ParticipanteRepresentanteNome[0];
            A1003ParticipanteRepresentanteEmail = T000Z3_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = T000Z3_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = T000Z3_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = T000Z3_n1004ParticipanteRepresentanteDocumento[0];
            Z233ParticipanteId = A233ParticipanteId;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z38( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey0Z38( ) ;
            }
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey0Z38( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z38( ) ;
         if ( RcdFound38 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound38 = 0;
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000Z6_A233ParticipanteId[0] < A233ParticipanteId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000Z6_A233ParticipanteId[0] > A233ParticipanteId ) ) )
            {
               A233ParticipanteId = T000Z6_A233ParticipanteId[0];
               n233ParticipanteId = T000Z6_n233ParticipanteId[0];
               AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
               RcdFound38 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound38 = 0;
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000Z7_A233ParticipanteId[0] > A233ParticipanteId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000Z7_A233ParticipanteId[0] < A233ParticipanteId ) ) )
            {
               A233ParticipanteId = T000Z7_A233ParticipanteId[0];
               n233ParticipanteId = T000Z7_n233ParticipanteId[0];
               AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
               RcdFound38 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z38( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParticipanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Z38( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( A233ParticipanteId != Z233ParticipanteId )
               {
                  A233ParticipanteId = Z233ParticipanteId;
                  n233ParticipanteId = false;
                  AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARTICIPANTEID");
                  AnyError = 1;
                  GX_FocusControl = edtParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParticipanteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z38( ) ;
                  GX_FocusControl = edtParticipanteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A233ParticipanteId != Z233ParticipanteId )
               {
                  /* Insert record */
                  GX_FocusControl = edtParticipanteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Z38( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARTICIPANTEID");
                     AnyError = 1;
                     GX_FocusControl = edtParticipanteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtParticipanteNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Z38( ) ;
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
         if ( A233ParticipanteId != Z233ParticipanteId )
         {
            A233ParticipanteId = Z233ParticipanteId;
            n233ParticipanteId = false;
            AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARTICIPANTEID");
            AnyError = 1;
            GX_FocusControl = edtParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParticipanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Z38( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {n233ParticipanteId, A233ParticipanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z234ParticipanteDocumento, T000Z2_A234ParticipanteDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z248ParticipanteNome, T000Z2_A248ParticipanteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z235ParticipanteEmail, T000Z2_A235ParticipanteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z1001ParticipanteTipoPessoa, T000Z2_A1001ParticipanteTipoPessoa[0]) != 0 ) || ( StringUtil.StrCmp(Z1002ParticipanteRepresentanteNome, T000Z2_A1002ParticipanteRepresentanteNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1003ParticipanteRepresentanteEmail, T000Z2_A1003ParticipanteRepresentanteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z1004ParticipanteRepresentanteDocumento, T000Z2_A1004ParticipanteRepresentanteDocumento[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z234ParticipanteDocumento, T000Z2_A234ParticipanteDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z234ParticipanteDocumento);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A234ParticipanteDocumento[0]);
               }
               if ( StringUtil.StrCmp(Z248ParticipanteNome, T000Z2_A248ParticipanteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteNome");
                  GXUtil.WriteLogRaw("Old: ",Z248ParticipanteNome);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A248ParticipanteNome[0]);
               }
               if ( StringUtil.StrCmp(Z235ParticipanteEmail, T000Z2_A235ParticipanteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z235ParticipanteEmail);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A235ParticipanteEmail[0]);
               }
               if ( StringUtil.StrCmp(Z1001ParticipanteTipoPessoa, T000Z2_A1001ParticipanteTipoPessoa[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteTipoPessoa");
                  GXUtil.WriteLogRaw("Old: ",Z1001ParticipanteTipoPessoa);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1001ParticipanteTipoPessoa[0]);
               }
               if ( StringUtil.StrCmp(Z1002ParticipanteRepresentanteNome, T000Z2_A1002ParticipanteRepresentanteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteRepresentanteNome");
                  GXUtil.WriteLogRaw("Old: ",Z1002ParticipanteRepresentanteNome);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1002ParticipanteRepresentanteNome[0]);
               }
               if ( StringUtil.StrCmp(Z1003ParticipanteRepresentanteEmail, T000Z2_A1003ParticipanteRepresentanteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteRepresentanteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z1003ParticipanteRepresentanteEmail);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1003ParticipanteRepresentanteEmail[0]);
               }
               if ( StringUtil.StrCmp(Z1004ParticipanteRepresentanteDocumento, T000Z2_A1004ParticipanteRepresentanteDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("participante:[seudo value changed for attri]"+"ParticipanteRepresentanteDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z1004ParticipanteRepresentanteDocumento);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1004ParticipanteRepresentanteDocumento[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Participante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z38( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z38( 0) ;
            CheckOptimisticConcurrency0Z38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z8 */
                     pr_default.execute(6, new Object[] {n234ParticipanteDocumento, A234ParticipanteDocumento, n248ParticipanteNome, A248ParticipanteNome, n235ParticipanteEmail, A235ParticipanteEmail, n1001ParticipanteTipoPessoa, A1001ParticipanteTipoPessoa, n1002ParticipanteRepresentanteNome, A1002ParticipanteRepresentanteNome, n1003ParticipanteRepresentanteEmail, A1003ParticipanteRepresentanteEmail, n1004ParticipanteRepresentanteDocumento, A1004ParticipanteRepresentanteDocumento});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000Z9 */
                     pr_default.execute(7);
                     A233ParticipanteId = T000Z9_A233ParticipanteId[0];
                     n233ParticipanteId = T000Z9_n233ParticipanteId[0];
                     AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Participante");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0Z0( ) ;
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
               Load0Z38( ) ;
            }
            EndLevel0Z38( ) ;
         }
         CloseExtendedTableCursors0Z38( ) ;
      }

      protected void Update0Z38( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z10 */
                     pr_default.execute(8, new Object[] {n234ParticipanteDocumento, A234ParticipanteDocumento, n248ParticipanteNome, A248ParticipanteNome, n235ParticipanteEmail, A235ParticipanteEmail, n1001ParticipanteTipoPessoa, A1001ParticipanteTipoPessoa, n1002ParticipanteRepresentanteNome, A1002ParticipanteRepresentanteNome, n1003ParticipanteRepresentanteEmail, A1003ParticipanteRepresentanteEmail, n1004ParticipanteRepresentanteDocumento, A1004ParticipanteRepresentanteDocumento, n233ParticipanteId, A233ParticipanteId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Participante");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z38( ) ;
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
            EndLevel0Z38( ) ;
         }
         CloseExtendedTableCursors0Z38( ) ;
      }

      protected void DeferredUpdate0Z38( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z38( ) ;
            AfterConfirm0Z38( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z38( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z11 */
                  pr_default.execute(9, new Object[] {n233ParticipanteId, A233ParticipanteId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Participante");
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z38( ) ;
         Gx_mode = sMode38;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z38( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1005ParticipanteEmail_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1003ParticipanteRepresentanteEmail : A235ParticipanteEmail);
            AssignAttri("", false, "A1005ParticipanteEmail_F", A1005ParticipanteEmail_F);
            A1006ParticipanteDocumento_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1004ParticipanteRepresentanteDocumento : A234ParticipanteDocumento);
            AssignAttri("", false, "A1006ParticipanteDocumento_F", A1006ParticipanteDocumento_F);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Z12 */
            pr_default.execute(10, new Object[] {n233ParticipanteId, A233ParticipanteId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000Z13 */
            pr_default.execute(11, new Object[] {n233ParticipanteId, A233ParticipanteId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato Participante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0Z38( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("participante",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("participante",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z38( )
      {
         /* Scan By routine */
         /* Using cursor T000Z14 */
         pr_default.execute(12);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound38 = 1;
            A233ParticipanteId = T000Z14_A233ParticipanteId[0];
            n233ParticipanteId = T000Z14_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z38( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound38 = 1;
            A233ParticipanteId = T000Z14_A233ParticipanteId[0];
            n233ParticipanteId = T000Z14_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
         }
      }

      protected void ScanEnd0Z38( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0Z38( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z38( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z38( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z38( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z38( )
      {
         /* Before Complete Rules */
         new prvalidcpf(context ).execute(  "FISICA",  A234ParticipanteDocumento, out  AV11isOk, out  AV12ErroMsg) ;
         AssignAttri("", false, "AV11isOk", AV11isOk);
         AssignAttri("", false, "AV12ErroMsg", AV12ErroMsg);
         if ( ! AV11isOk )
         {
            GX_msglist.addItem(AV12ErroMsg, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeValidate0Z38( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z38( )
      {
         edtParticipanteNome_Enabled = 0;
         AssignProp("", false, edtParticipanteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteNome_Enabled), 5, 0), true);
         edtParticipanteDocumento_Enabled = 0;
         AssignProp("", false, edtParticipanteDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteDocumento_Enabled), 5, 0), true);
         edtParticipanteEmail_Enabled = 0;
         AssignProp("", false, edtParticipanteEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteEmail_Enabled), 5, 0), true);
         edtParticipanteId_Enabled = 0;
         AssignProp("", false, edtParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Z38( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Z0( )
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
         GXEncryptionTmp = "participante"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ParticipanteId,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("participante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Participante");
         forbiddenHiddens.Add("ParticipanteId", context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ParticipanteTipoPessoa", StringUtil.RTrim( context.localUtil.Format( A1001ParticipanteTipoPessoa, "")));
         forbiddenHiddens.Add("ParticipanteRepresentanteNome", StringUtil.RTrim( context.localUtil.Format( A1002ParticipanteRepresentanteNome, "")));
         forbiddenHiddens.Add("ParticipanteRepresentanteEmail", StringUtil.RTrim( context.localUtil.Format( A1003ParticipanteRepresentanteEmail, "")));
         forbiddenHiddens.Add("ParticipanteRepresentanteDocumento", StringUtil.RTrim( context.localUtil.Format( A1004ParticipanteRepresentanteDocumento, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("participante:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z233ParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z234ParticipanteDocumento", Z234ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, "Z248ParticipanteNome", Z248ParticipanteNome);
         GxWebStd.gx_hidden_field( context, "Z235ParticipanteEmail", Z235ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "Z1001ParticipanteTipoPessoa", Z1001ParticipanteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "Z1002ParticipanteRepresentanteNome", Z1002ParticipanteRepresentanteNome);
         GxWebStd.gx_hidden_field( context, "Z1003ParticipanteRepresentanteEmail", Z1003ParticipanteRepresentanteEmail);
         GxWebStd.gx_hidden_field( context, "Z1004ParticipanteRepresentanteDocumento", Z1004ParticipanteRepresentanteDocumento);
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
         GxWebStd.gx_hidden_field( context, "PARTICIPANTETIPOPESSOA", A1001ParticipanteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEREPRESENTANTEDOCUMENTO", A1004ParticipanteRepresentanteDocumento);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEDOCUMENTO_F", A1006ParticipanteDocumento_F);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEREPRESENTANTEEMAIL", A1003ParticipanteRepresentanteEmail);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEEMAIL_F", A1005ParticipanteEmail_F);
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ParticipanteId), "ZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV11isOk);
         GxWebStd.gx_hidden_field( context, "vERROMSG", AV12ErroMsg);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEREPRESENTANTENOME", A1002ParticipanteRepresentanteNome);
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
         GXEncryptionTmp = "participante"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ParticipanteId,8,0));
         return formatLink("participante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Participante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Participante" ;
      }

      protected void InitializeNonKey0Z38( )
      {
         AV11isOk = false;
         AssignAttri("", false, "AV11isOk", AV11isOk);
         AV12ErroMsg = "";
         AssignAttri("", false, "AV12ErroMsg", AV12ErroMsg);
         A1005ParticipanteEmail_F = "";
         AssignAttri("", false, "A1005ParticipanteEmail_F", A1005ParticipanteEmail_F);
         A1006ParticipanteDocumento_F = "";
         AssignAttri("", false, "A1006ParticipanteDocumento_F", A1006ParticipanteDocumento_F);
         A234ParticipanteDocumento = "";
         n234ParticipanteDocumento = false;
         AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
         n234ParticipanteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) ? true : false);
         A248ParticipanteNome = "";
         n248ParticipanteNome = false;
         AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
         n248ParticipanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) ? true : false);
         A235ParticipanteEmail = "";
         n235ParticipanteEmail = false;
         AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
         n235ParticipanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ? true : false);
         A1001ParticipanteTipoPessoa = "";
         n1001ParticipanteTipoPessoa = false;
         AssignAttri("", false, "A1001ParticipanteTipoPessoa", A1001ParticipanteTipoPessoa);
         A1002ParticipanteRepresentanteNome = "";
         n1002ParticipanteRepresentanteNome = false;
         AssignAttri("", false, "A1002ParticipanteRepresentanteNome", A1002ParticipanteRepresentanteNome);
         A1003ParticipanteRepresentanteEmail = "";
         n1003ParticipanteRepresentanteEmail = false;
         AssignAttri("", false, "A1003ParticipanteRepresentanteEmail", A1003ParticipanteRepresentanteEmail);
         A1004ParticipanteRepresentanteDocumento = "";
         n1004ParticipanteRepresentanteDocumento = false;
         AssignAttri("", false, "A1004ParticipanteRepresentanteDocumento", A1004ParticipanteRepresentanteDocumento);
         Z234ParticipanteDocumento = "";
         Z248ParticipanteNome = "";
         Z235ParticipanteEmail = "";
         Z1001ParticipanteTipoPessoa = "";
         Z1002ParticipanteRepresentanteNome = "";
         Z1003ParticipanteRepresentanteEmail = "";
         Z1004ParticipanteRepresentanteDocumento = "";
      }

      protected void InitAll0Z38( )
      {
         A233ParticipanteId = 0;
         n233ParticipanteId = false;
         AssignAttri("", false, "A233ParticipanteId", StringUtil.LTrimStr( (decimal)(A233ParticipanteId), 8, 0));
         InitializeNonKey0Z38( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019135730", true, true);
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
         context.AddJavascriptSource("participante.js", "?202561019135730", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtParticipanteNome_Internalname = "PARTICIPANTENOME";
         edtParticipanteDocumento_Internalname = "PARTICIPANTEDOCUMENTO";
         edtParticipanteEmail_Internalname = "PARTICIPANTEEMAIL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtParticipanteId_Internalname = "PARTICIPANTEID";
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
         Form.Caption = "Participante";
         edtParticipanteId_Jsonclick = "";
         edtParticipanteId_Enabled = 0;
         edtParticipanteId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtParticipanteEmail_Jsonclick = "";
         edtParticipanteEmail_Enabled = 1;
         edtParticipanteDocumento_Jsonclick = "";
         edtParticipanteDocumento_Enabled = 1;
         edtParticipanteNome_Jsonclick = "";
         edtParticipanteNome_Enabled = 1;
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

      protected void XC_9_0Z38( string A234ParticipanteDocumento )
      {
         new prvalidcpf(context ).execute(  "FISICA",  A234ParticipanteDocumento, out  AV11isOk, out  AV12ErroMsg) ;
         AssignAttri("", false, "AV11isOk", AV11isOk);
         AssignAttri("", false, "AV12ErroMsg", AV12ErroMsg);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV11isOk))+"\""+","+"\""+GXUtil.EncodeJSConstant( AV12ErroMsg)+"\"") ;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"A1001ParticipanteTipoPessoa","fld":"PARTICIPANTETIPOPESSOA","type":"svchar"},{"av":"A1002ParticipanteRepresentanteNome","fld":"PARTICIPANTEREPRESENTANTENOME","type":"svchar"},{"av":"A1003ParticipanteRepresentanteEmail","fld":"PARTICIPANTEREPRESENTANTEEMAIL","type":"svchar"},{"av":"A1004ParticipanteRepresentanteDocumento","fld":"PARTICIPANTEREPRESENTANTEDOCUMENTO","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120Z2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_PARTICIPANTENOME","""{"handler":"Valid_Participantenome","iparms":[]}""");
         setEventMetadata("VALID_PARTICIPANTEDOCUMENTO","""{"handler":"Valid_Participantedocumento","iparms":[]}""");
         setEventMetadata("VALID_PARTICIPANTEEMAIL","""{"handler":"Valid_Participanteemail","iparms":[]}""");
         setEventMetadata("VALID_PARTICIPANTEID","""{"handler":"Valid_Participanteid","iparms":[]}""");
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
         Z234ParticipanteDocumento = "";
         Z248ParticipanteNome = "";
         Z235ParticipanteEmail = "";
         Z1001ParticipanteTipoPessoa = "";
         Z1002ParticipanteRepresentanteNome = "";
         Z1003ParticipanteRepresentanteEmail = "";
         Z1004ParticipanteRepresentanteDocumento = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A234ParticipanteDocumento = "";
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
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1001ParticipanteTipoPessoa = "";
         A1002ParticipanteRepresentanteNome = "";
         A1003ParticipanteRepresentanteEmail = "";
         A1004ParticipanteRepresentanteDocumento = "";
         A1006ParticipanteDocumento_F = "";
         A1005ParticipanteEmail_F = "";
         AV12ErroMsg = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode38 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000Z4_A233ParticipanteId = new int[1] ;
         T000Z4_n233ParticipanteId = new bool[] {false} ;
         T000Z4_A234ParticipanteDocumento = new string[] {""} ;
         T000Z4_n234ParticipanteDocumento = new bool[] {false} ;
         T000Z4_A248ParticipanteNome = new string[] {""} ;
         T000Z4_n248ParticipanteNome = new bool[] {false} ;
         T000Z4_A235ParticipanteEmail = new string[] {""} ;
         T000Z4_n235ParticipanteEmail = new bool[] {false} ;
         T000Z4_A1001ParticipanteTipoPessoa = new string[] {""} ;
         T000Z4_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         T000Z4_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         T000Z4_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         T000Z4_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         T000Z4_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         T000Z4_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         T000Z4_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         T000Z5_A233ParticipanteId = new int[1] ;
         T000Z5_n233ParticipanteId = new bool[] {false} ;
         T000Z3_A233ParticipanteId = new int[1] ;
         T000Z3_n233ParticipanteId = new bool[] {false} ;
         T000Z3_A234ParticipanteDocumento = new string[] {""} ;
         T000Z3_n234ParticipanteDocumento = new bool[] {false} ;
         T000Z3_A248ParticipanteNome = new string[] {""} ;
         T000Z3_n248ParticipanteNome = new bool[] {false} ;
         T000Z3_A235ParticipanteEmail = new string[] {""} ;
         T000Z3_n235ParticipanteEmail = new bool[] {false} ;
         T000Z3_A1001ParticipanteTipoPessoa = new string[] {""} ;
         T000Z3_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         T000Z3_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         T000Z3_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         T000Z3_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         T000Z3_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         T000Z3_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         T000Z3_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         T000Z6_A233ParticipanteId = new int[1] ;
         T000Z6_n233ParticipanteId = new bool[] {false} ;
         T000Z7_A233ParticipanteId = new int[1] ;
         T000Z7_n233ParticipanteId = new bool[] {false} ;
         T000Z2_A233ParticipanteId = new int[1] ;
         T000Z2_n233ParticipanteId = new bool[] {false} ;
         T000Z2_A234ParticipanteDocumento = new string[] {""} ;
         T000Z2_n234ParticipanteDocumento = new bool[] {false} ;
         T000Z2_A248ParticipanteNome = new string[] {""} ;
         T000Z2_n248ParticipanteNome = new bool[] {false} ;
         T000Z2_A235ParticipanteEmail = new string[] {""} ;
         T000Z2_n235ParticipanteEmail = new bool[] {false} ;
         T000Z2_A1001ParticipanteTipoPessoa = new string[] {""} ;
         T000Z2_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         T000Z2_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         T000Z2_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         T000Z2_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         T000Z2_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         T000Z2_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         T000Z2_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         T000Z9_A233ParticipanteId = new int[1] ;
         T000Z9_n233ParticipanteId = new bool[] {false} ;
         T000Z12_A242AssinaturaParticipanteId = new int[1] ;
         T000Z13_A237ContratoParticipanteId = new int[1] ;
         T000Z14_A233ParticipanteId = new int[1] ;
         T000Z14_n233ParticipanteId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participante__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A233ParticipanteId, T000Z2_A234ParticipanteDocumento, T000Z2_n234ParticipanteDocumento, T000Z2_A248ParticipanteNome, T000Z2_n248ParticipanteNome, T000Z2_A235ParticipanteEmail, T000Z2_n235ParticipanteEmail, T000Z2_A1001ParticipanteTipoPessoa, T000Z2_n1001ParticipanteTipoPessoa, T000Z2_A1002ParticipanteRepresentanteNome,
               T000Z2_n1002ParticipanteRepresentanteNome, T000Z2_A1003ParticipanteRepresentanteEmail, T000Z2_n1003ParticipanteRepresentanteEmail, T000Z2_A1004ParticipanteRepresentanteDocumento, T000Z2_n1004ParticipanteRepresentanteDocumento
               }
               , new Object[] {
               T000Z3_A233ParticipanteId, T000Z3_A234ParticipanteDocumento, T000Z3_n234ParticipanteDocumento, T000Z3_A248ParticipanteNome, T000Z3_n248ParticipanteNome, T000Z3_A235ParticipanteEmail, T000Z3_n235ParticipanteEmail, T000Z3_A1001ParticipanteTipoPessoa, T000Z3_n1001ParticipanteTipoPessoa, T000Z3_A1002ParticipanteRepresentanteNome,
               T000Z3_n1002ParticipanteRepresentanteNome, T000Z3_A1003ParticipanteRepresentanteEmail, T000Z3_n1003ParticipanteRepresentanteEmail, T000Z3_A1004ParticipanteRepresentanteDocumento, T000Z3_n1004ParticipanteRepresentanteDocumento
               }
               , new Object[] {
               T000Z4_A233ParticipanteId, T000Z4_A234ParticipanteDocumento, T000Z4_n234ParticipanteDocumento, T000Z4_A248ParticipanteNome, T000Z4_n248ParticipanteNome, T000Z4_A235ParticipanteEmail, T000Z4_n235ParticipanteEmail, T000Z4_A1001ParticipanteTipoPessoa, T000Z4_n1001ParticipanteTipoPessoa, T000Z4_A1002ParticipanteRepresentanteNome,
               T000Z4_n1002ParticipanteRepresentanteNome, T000Z4_A1003ParticipanteRepresentanteEmail, T000Z4_n1003ParticipanteRepresentanteEmail, T000Z4_A1004ParticipanteRepresentanteDocumento, T000Z4_n1004ParticipanteRepresentanteDocumento
               }
               , new Object[] {
               T000Z5_A233ParticipanteId
               }
               , new Object[] {
               T000Z6_A233ParticipanteId
               }
               , new Object[] {
               T000Z7_A233ParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z9_A233ParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z12_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T000Z13_A237ContratoParticipanteId
               }
               , new Object[] {
               T000Z14_A233ParticipanteId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound38 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ParticipanteId ;
      private int Z233ParticipanteId ;
      private int AV7ParticipanteId ;
      private int trnEnded ;
      private int edtParticipanteNome_Enabled ;
      private int edtParticipanteDocumento_Enabled ;
      private int edtParticipanteEmail_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A233ParticipanteId ;
      private int edtParticipanteId_Enabled ;
      private int edtParticipanteId_Visible ;
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
      private string edtParticipanteNome_Internalname ;
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
      private string edtParticipanteNome_Jsonclick ;
      private string edtParticipanteDocumento_Internalname ;
      private string edtParticipanteDocumento_Jsonclick ;
      private string edtParticipanteEmail_Internalname ;
      private string edtParticipanteEmail_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtParticipanteId_Internalname ;
      private string edtParticipanteId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode38 ;
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
      private bool n234ParticipanteDocumento ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n1001ParticipanteTipoPessoa ;
      private bool n1002ParticipanteRepresentanteNome ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool AV11isOk ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n233ParticipanteId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z234ParticipanteDocumento ;
      private string Z248ParticipanteNome ;
      private string Z235ParticipanteEmail ;
      private string Z1001ParticipanteTipoPessoa ;
      private string Z1002ParticipanteRepresentanteNome ;
      private string Z1003ParticipanteRepresentanteEmail ;
      private string Z1004ParticipanteRepresentanteDocumento ;
      private string A234ParticipanteDocumento ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A1001ParticipanteTipoPessoa ;
      private string A1002ParticipanteRepresentanteNome ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string A1006ParticipanteDocumento_F ;
      private string A1005ParticipanteEmail_F ;
      private string AV12ErroMsg ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T000Z4_A233ParticipanteId ;
      private bool[] T000Z4_n233ParticipanteId ;
      private string[] T000Z4_A234ParticipanteDocumento ;
      private bool[] T000Z4_n234ParticipanteDocumento ;
      private string[] T000Z4_A248ParticipanteNome ;
      private bool[] T000Z4_n248ParticipanteNome ;
      private string[] T000Z4_A235ParticipanteEmail ;
      private bool[] T000Z4_n235ParticipanteEmail ;
      private string[] T000Z4_A1001ParticipanteTipoPessoa ;
      private bool[] T000Z4_n1001ParticipanteTipoPessoa ;
      private string[] T000Z4_A1002ParticipanteRepresentanteNome ;
      private bool[] T000Z4_n1002ParticipanteRepresentanteNome ;
      private string[] T000Z4_A1003ParticipanteRepresentanteEmail ;
      private bool[] T000Z4_n1003ParticipanteRepresentanteEmail ;
      private string[] T000Z4_A1004ParticipanteRepresentanteDocumento ;
      private bool[] T000Z4_n1004ParticipanteRepresentanteDocumento ;
      private int[] T000Z5_A233ParticipanteId ;
      private bool[] T000Z5_n233ParticipanteId ;
      private int[] T000Z3_A233ParticipanteId ;
      private bool[] T000Z3_n233ParticipanteId ;
      private string[] T000Z3_A234ParticipanteDocumento ;
      private bool[] T000Z3_n234ParticipanteDocumento ;
      private string[] T000Z3_A248ParticipanteNome ;
      private bool[] T000Z3_n248ParticipanteNome ;
      private string[] T000Z3_A235ParticipanteEmail ;
      private bool[] T000Z3_n235ParticipanteEmail ;
      private string[] T000Z3_A1001ParticipanteTipoPessoa ;
      private bool[] T000Z3_n1001ParticipanteTipoPessoa ;
      private string[] T000Z3_A1002ParticipanteRepresentanteNome ;
      private bool[] T000Z3_n1002ParticipanteRepresentanteNome ;
      private string[] T000Z3_A1003ParticipanteRepresentanteEmail ;
      private bool[] T000Z3_n1003ParticipanteRepresentanteEmail ;
      private string[] T000Z3_A1004ParticipanteRepresentanteDocumento ;
      private bool[] T000Z3_n1004ParticipanteRepresentanteDocumento ;
      private int[] T000Z6_A233ParticipanteId ;
      private bool[] T000Z6_n233ParticipanteId ;
      private int[] T000Z7_A233ParticipanteId ;
      private bool[] T000Z7_n233ParticipanteId ;
      private int[] T000Z2_A233ParticipanteId ;
      private bool[] T000Z2_n233ParticipanteId ;
      private string[] T000Z2_A234ParticipanteDocumento ;
      private bool[] T000Z2_n234ParticipanteDocumento ;
      private string[] T000Z2_A248ParticipanteNome ;
      private bool[] T000Z2_n248ParticipanteNome ;
      private string[] T000Z2_A235ParticipanteEmail ;
      private bool[] T000Z2_n235ParticipanteEmail ;
      private string[] T000Z2_A1001ParticipanteTipoPessoa ;
      private bool[] T000Z2_n1001ParticipanteTipoPessoa ;
      private string[] T000Z2_A1002ParticipanteRepresentanteNome ;
      private bool[] T000Z2_n1002ParticipanteRepresentanteNome ;
      private string[] T000Z2_A1003ParticipanteRepresentanteEmail ;
      private bool[] T000Z2_n1003ParticipanteRepresentanteEmail ;
      private string[] T000Z2_A1004ParticipanteRepresentanteDocumento ;
      private bool[] T000Z2_n1004ParticipanteRepresentanteDocumento ;
      private int[] T000Z9_A233ParticipanteId ;
      private bool[] T000Z9_n233ParticipanteId ;
      private int[] T000Z12_A242AssinaturaParticipanteId ;
      private int[] T000Z13_A237ContratoParticipanteId ;
      private int[] T000Z14_A233ParticipanteId ;
      private bool[] T000Z14_n233ParticipanteId ;
   }

   public class participante__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000Z2;
          prmT000Z2 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z3;
          prmT000Z3 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z4;
          prmT000Z4 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z5;
          prmT000Z5 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z6;
          prmT000Z6 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z7;
          prmT000Z7 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z8;
          prmT000Z8 = new Object[] {
          new ParDef("ParticipanteDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ParticipanteNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteDocumento",GXType.VarChar,14,0){Nullable=true}
          };
          Object[] prmT000Z9;
          prmT000Z9 = new Object[] {
          };
          Object[] prmT000Z10;
          prmT000Z10 = new Object[] {
          new ParDef("ParticipanteDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ParticipanteNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z11;
          prmT000Z11 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z12;
          prmT000Z12 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z13;
          prmT000Z13 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Z14;
          prmT000Z14 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000Z2", "SELECT ParticipanteId, ParticipanteDocumento, ParticipanteNome, ParticipanteEmail, ParticipanteTipoPessoa, ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId  FOR UPDATE OF Participante NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Z3", "SELECT ParticipanteId, ParticipanteDocumento, ParticipanteNome, ParticipanteEmail, ParticipanteTipoPessoa, ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Z4", "SELECT TM1.ParticipanteId, TM1.ParticipanteDocumento, TM1.ParticipanteNome, TM1.ParticipanteEmail, TM1.ParticipanteTipoPessoa, TM1.ParticipanteRepresentanteNome, TM1.ParticipanteRepresentanteEmail, TM1.ParticipanteRepresentanteDocumento FROM Participante TM1 WHERE TM1.ParticipanteId = :ParticipanteId ORDER BY TM1.ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Z5", "SELECT ParticipanteId FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Z6", "SELECT ParticipanteId FROM Participante WHERE ( ParticipanteId > :ParticipanteId) ORDER BY ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Z7", "SELECT ParticipanteId FROM Participante WHERE ( ParticipanteId < :ParticipanteId) ORDER BY ParticipanteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Z8", "SAVEPOINT gxupdate;INSERT INTO Participante(ParticipanteDocumento, ParticipanteNome, ParticipanteEmail, ParticipanteTipoPessoa, ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento) VALUES(:ParticipanteDocumento, :ParticipanteNome, :ParticipanteEmail, :ParticipanteTipoPessoa, :ParticipanteRepresentanteNome, :ParticipanteRepresentanteEmail, :ParticipanteRepresentanteDocumento);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z8)
             ,new CursorDef("T000Z9", "SELECT currval('ParticipanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Z10", "SAVEPOINT gxupdate;UPDATE Participante SET ParticipanteDocumento=:ParticipanteDocumento, ParticipanteNome=:ParticipanteNome, ParticipanteEmail=:ParticipanteEmail, ParticipanteTipoPessoa=:ParticipanteTipoPessoa, ParticipanteRepresentanteNome=:ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail=:ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento=:ParticipanteRepresentanteDocumento  WHERE ParticipanteId = :ParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z10)
             ,new CursorDef("T000Z11", "SAVEPOINT gxupdate;DELETE FROM Participante  WHERE ParticipanteId = :ParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z11)
             ,new CursorDef("T000Z12", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Z13", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Z14", "SELECT ParticipanteId FROM Participante ORDER BY ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z14,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
