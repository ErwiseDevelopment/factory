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
   public class banco : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A402BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
            n402BancoId = false;
            AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A402BancoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "banco")), "banco") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "banco")))) ;
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
                  AV7BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7BancoId", StringUtil.LTrimStr( (decimal)(AV7BancoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BancoId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Banco", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBancoCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public banco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public banco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_BancoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7BancoId = aP1_BancoId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBancoCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBancoCodigo_Internalname, "Codigo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBancoCodigo_Internalname, ((0==A404BancoCodigo)&&IsIns( )||n404BancoCodigo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ",", ""))), ((0==A404BancoCodigo)&&IsIns( )||n404BancoCodigo ? "" : StringUtil.LTrim( ((edtBancoCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A404BancoCodigo), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A404BancoCodigo), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBancoCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBancoCodigo_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Banco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBancoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBancoNome_Internalname, "Banco", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBancoNome_Internalname, A403BancoNome, StringUtil.RTrim( context.localUtil.Format( A403BancoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBancoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBancoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Banco.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Banco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Banco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Banco.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBancoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtBancoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A402BancoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A402BancoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBancoId_Jsonclick, 0, "Attribute", "", "", "", "", edtBancoId_Visible, edtBancoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Banco.htm");
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
         E111K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z402BancoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z404BancoCodigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z404BancoCodigo"), ",", "."), 18, MidpointRounding.ToEven));
               n404BancoCodigo = ((0==A404BancoCodigo) ? true : false);
               Z403BancoNome = cgiGet( "Z403BancoNome");
               n403BancoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A403BancoNome)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vBANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               A946BancoCountAgencia_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "BANCOCOUNTAGENCIA_F"), ",", "."), 18, MidpointRounding.ToEven));
               n946BancoCountAgencia_F = false;
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
               n404BancoCodigo = ((StringUtil.StrCmp(cgiGet( edtBancoCodigo_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBancoCodigo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBancoCodigo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANCOCODIGO");
                  AnyError = 1;
                  GX_FocusControl = edtBancoCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A404BancoCodigo = 0;
                  n404BancoCodigo = false;
                  AssignAttri("", false, "A404BancoCodigo", (n404BancoCodigo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ".", ""))));
               }
               else
               {
                  A404BancoCodigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBancoCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A404BancoCodigo", (n404BancoCodigo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ".", ""))));
               }
               A403BancoNome = cgiGet( edtBancoNome_Internalname);
               n403BancoNome = false;
               AssignAttri("", false, "A403BancoNome", A403BancoNome);
               n403BancoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A403BancoNome)) ? true : false);
               A402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBancoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n402BancoId = false;
               AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Banco");
               A402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBancoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n402BancoId = false;
               AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
               forbiddenHiddens.Add("BancoId", context.localUtil.Format( (decimal)(A402BancoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A402BancoId != Z402BancoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("banco:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A402BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
                  n402BancoId = false;
                  AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
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
                     sMode59 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode59;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound59 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "BANCOID");
                        AnyError = 1;
                        GX_FocusControl = edtBancoId_Internalname;
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
                           E111K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121K2 ();
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
            E121K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1K59( ) ;
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
            DisableAttributes1K59( ) ;
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

      protected void CONFIRM_1K0( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1K59( ) ;
            }
            else
            {
               CheckExtendedTable1K59( ) ;
               CloseExtendedTableCursors1K59( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1K0( )
      {
      }

      protected void E111K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtBancoId_Visible = 0;
         AssignProp("", false, edtBancoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtBancoId_Visible), 5, 0), true);
      }

      protected void E121K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("bancoww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1K59( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z404BancoCodigo = T001K3_A404BancoCodigo[0];
               Z403BancoNome = T001K3_A403BancoNome[0];
            }
            else
            {
               Z404BancoCodigo = A404BancoCodigo;
               Z403BancoNome = A403BancoNome;
            }
         }
         if ( GX_JID == -3 )
         {
            Z402BancoId = A402BancoId;
            Z404BancoCodigo = A404BancoCodigo;
            Z403BancoNome = A403BancoNome;
            Z946BancoCountAgencia_F = A946BancoCountAgencia_F;
         }
      }

      protected void standaloneNotModal( )
      {
         edtBancoId_Enabled = 0;
         AssignProp("", false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
         edtBancoId_Enabled = 0;
         AssignProp("", false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7BancoId) )
         {
            A402BancoId = AV7BancoId;
            n402BancoId = false;
            AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001K5 */
            pr_default.execute(2, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A946BancoCountAgencia_F = T001K5_A946BancoCountAgencia_F[0];
               n946BancoCountAgencia_F = T001K5_n946BancoCountAgencia_F[0];
            }
            else
            {
               A946BancoCountAgencia_F = 0;
               n946BancoCountAgencia_F = false;
               AssignAttri("", false, "A946BancoCountAgencia_F", StringUtil.LTrimStr( (decimal)(A946BancoCountAgencia_F), 4, 0));
            }
            pr_default.close(2);
         }
      }

      protected void Load1K59( )
      {
         /* Using cursor T001K7 */
         pr_default.execute(3, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound59 = 1;
            A404BancoCodigo = T001K7_A404BancoCodigo[0];
            n404BancoCodigo = T001K7_n404BancoCodigo[0];
            AssignAttri("", false, "A404BancoCodigo", ((0==A404BancoCodigo)&&IsIns( )||n404BancoCodigo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ".", ""))));
            A403BancoNome = T001K7_A403BancoNome[0];
            n403BancoNome = T001K7_n403BancoNome[0];
            AssignAttri("", false, "A403BancoNome", A403BancoNome);
            A946BancoCountAgencia_F = T001K7_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = T001K7_n946BancoCountAgencia_F[0];
            ZM1K59( -3) ;
         }
         pr_default.close(3);
         OnLoadActions1K59( ) ;
      }

      protected void OnLoadActions1K59( )
      {
      }

      protected void CheckExtendedTable1K59( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001K5 */
         pr_default.execute(2, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A946BancoCountAgencia_F = T001K5_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = T001K5_n946BancoCountAgencia_F[0];
         }
         else
         {
            A946BancoCountAgencia_F = 0;
            n946BancoCountAgencia_F = false;
            AssignAttri("", false, "A946BancoCountAgencia_F", StringUtil.LTrimStr( (decimal)(A946BancoCountAgencia_F), 4, 0));
         }
         pr_default.close(2);
         /* Using cursor T001K8 */
         pr_default.execute(4, new Object[] {n404BancoCodigo, A404BancoCodigo, n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Banco Codigo"}), 1, "BANCOCODIGO");
            AnyError = 1;
            GX_FocusControl = edtBancoCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1K59( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( int A402BancoId )
      {
         /* Using cursor T001K10 */
         pr_default.execute(5, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A946BancoCountAgencia_F = T001K10_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = T001K10_n946BancoCountAgencia_F[0];
         }
         else
         {
            A946BancoCountAgencia_F = 0;
            n946BancoCountAgencia_F = false;
            AssignAttri("", false, "A946BancoCountAgencia_F", StringUtil.LTrimStr( (decimal)(A946BancoCountAgencia_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A946BancoCountAgencia_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey1K59( )
      {
         /* Using cursor T001K11 */
         pr_default.execute(6, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound59 = 1;
         }
         else
         {
            RcdFound59 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001K3 */
         pr_default.execute(1, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1K59( 3) ;
            RcdFound59 = 1;
            A402BancoId = T001K3_A402BancoId[0];
            n402BancoId = T001K3_n402BancoId[0];
            AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
            A404BancoCodigo = T001K3_A404BancoCodigo[0];
            n404BancoCodigo = T001K3_n404BancoCodigo[0];
            AssignAttri("", false, "A404BancoCodigo", ((0==A404BancoCodigo)&&IsIns( )||n404BancoCodigo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ".", ""))));
            A403BancoNome = T001K3_A403BancoNome[0];
            n403BancoNome = T001K3_n403BancoNome[0];
            AssignAttri("", false, "A403BancoNome", A403BancoNome);
            Z402BancoId = A402BancoId;
            sMode59 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1K59( ) ;
            if ( AnyError == 1 )
            {
               RcdFound59 = 0;
               InitializeNonKey1K59( ) ;
            }
            Gx_mode = sMode59;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound59 = 0;
            InitializeNonKey1K59( ) ;
            sMode59 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode59;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1K59( ) ;
         if ( RcdFound59 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound59 = 0;
         /* Using cursor T001K12 */
         pr_default.execute(7, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001K12_A402BancoId[0] < A402BancoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001K12_A402BancoId[0] > A402BancoId ) ) )
            {
               A402BancoId = T001K12_A402BancoId[0];
               n402BancoId = T001K12_n402BancoId[0];
               AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
               RcdFound59 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound59 = 0;
         /* Using cursor T001K13 */
         pr_default.execute(8, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001K13_A402BancoId[0] > A402BancoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001K13_A402BancoId[0] < A402BancoId ) ) )
            {
               A402BancoId = T001K13_A402BancoId[0];
               n402BancoId = T001K13_n402BancoId[0];
               AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
               RcdFound59 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1K59( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBancoCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1K59( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound59 == 1 )
            {
               if ( A402BancoId != Z402BancoId )
               {
                  A402BancoId = Z402BancoId;
                  n402BancoId = false;
                  AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BANCOID");
                  AnyError = 1;
                  GX_FocusControl = edtBancoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBancoCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1K59( ) ;
                  GX_FocusControl = edtBancoCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A402BancoId != Z402BancoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtBancoCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1K59( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOID");
                     AnyError = 1;
                     GX_FocusControl = edtBancoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtBancoCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1K59( ) ;
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
         if ( A402BancoId != Z402BancoId )
         {
            A402BancoId = Z402BancoId;
            n402BancoId = false;
            AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BANCOID");
            AnyError = 1;
            GX_FocusControl = edtBancoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBancoCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1K59( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001K2 */
            pr_default.execute(0, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Banco"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z404BancoCodigo != T001K2_A404BancoCodigo[0] ) || ( StringUtil.StrCmp(Z403BancoNome, T001K2_A403BancoNome[0]) != 0 ) )
            {
               if ( Z404BancoCodigo != T001K2_A404BancoCodigo[0] )
               {
                  GXUtil.WriteLog("banco:[seudo value changed for attri]"+"BancoCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z404BancoCodigo);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A404BancoCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z403BancoNome, T001K2_A403BancoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("banco:[seudo value changed for attri]"+"BancoNome");
                  GXUtil.WriteLogRaw("Old: ",Z403BancoNome);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A403BancoNome[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Banco"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K59( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K59( 0) ;
            CheckOptimisticConcurrency1K59( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K59( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K59( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K14 */
                     pr_default.execute(9, new Object[] {n404BancoCodigo, A404BancoCodigo, n403BancoNome, A403BancoNome});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001K15 */
                     pr_default.execute(10);
                     A402BancoId = T001K15_A402BancoId[0];
                     n402BancoId = T001K15_n402BancoId[0];
                     AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Banco");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1K0( ) ;
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
               Load1K59( ) ;
            }
            EndLevel1K59( ) ;
         }
         CloseExtendedTableCursors1K59( ) ;
      }

      protected void Update1K59( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K59( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K59( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K59( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K16 */
                     pr_default.execute(11, new Object[] {n404BancoCodigo, A404BancoCodigo, n403BancoNome, A403BancoNome, n402BancoId, A402BancoId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Banco");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Banco"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K59( ) ;
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
            EndLevel1K59( ) ;
         }
         CloseExtendedTableCursors1K59( ) ;
      }

      protected void DeferredUpdate1K59( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K59( ) ;
            AfterConfirm1K59( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K59( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001K17 */
                  pr_default.execute(12, new Object[] {n402BancoId, A402BancoId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Banco");
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
         sMode59 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1K59( ) ;
         Gx_mode = sMode59;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1K59( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001K19 */
            pr_default.execute(13, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A946BancoCountAgencia_F = T001K19_A946BancoCountAgencia_F[0];
               n946BancoCountAgencia_F = T001K19_n946BancoCountAgencia_F[0];
            }
            else
            {
               A946BancoCountAgencia_F = 0;
               n946BancoCountAgencia_F = false;
               AssignAttri("", false, "A946BancoCountAgencia_F", StringUtil.LTrimStr( (decimal)(A946BancoCountAgencia_F), 4, 0));
            }
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001K20 */
            pr_default.execute(14, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001K21 */
            pr_default.execute(15, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001K22 */
            pr_default.execute(16, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel1K59( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("banco",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("banco",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1K59( )
      {
         /* Scan By routine */
         /* Using cursor T001K23 */
         pr_default.execute(17);
         RcdFound59 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound59 = 1;
            A402BancoId = T001K23_A402BancoId[0];
            n402BancoId = T001K23_n402BancoId[0];
            AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1K59( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound59 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound59 = 1;
            A402BancoId = T001K23_A402BancoId[0];
            n402BancoId = T001K23_n402BancoId[0];
            AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
         }
      }

      protected void ScanEnd1K59( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1K59( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K59( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K59( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K59( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K59( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K59( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K59( )
      {
         edtBancoCodigo_Enabled = 0;
         AssignProp("", false, edtBancoCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoCodigo_Enabled), 5, 0), true);
         edtBancoNome_Enabled = 0;
         AssignProp("", false, edtBancoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoNome_Enabled), 5, 0), true);
         edtBancoId_Enabled = 0;
         AssignProp("", false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1K59( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1K0( )
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
         GXEncryptionTmp = "banco"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("banco") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Banco");
         forbiddenHiddens.Add("BancoId", context.localUtil.Format( (decimal)(A402BancoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("banco:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z402BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z402BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z404BancoCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z404BancoCodigo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z403BancoNome", Z403BancoNome);
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
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BancoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "BANCOCOUNTAGENCIA_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A946BancoCountAgencia_F), 4, 0, ",", "")));
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
         GXEncryptionTmp = "banco"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         return formatLink("banco") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Banco" ;
      }

      public override string GetPgmdesc( )
      {
         return "Banco" ;
      }

      protected void InitializeNonKey1K59( )
      {
         A404BancoCodigo = 0;
         n404BancoCodigo = false;
         AssignAttri("", false, "A404BancoCodigo", ((0==A404BancoCodigo)&&IsIns( )||n404BancoCodigo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ".", ""))));
         n404BancoCodigo = ((0==A404BancoCodigo) ? true : false);
         A403BancoNome = "";
         n403BancoNome = false;
         AssignAttri("", false, "A403BancoNome", A403BancoNome);
         n403BancoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A403BancoNome)) ? true : false);
         A946BancoCountAgencia_F = 0;
         n946BancoCountAgencia_F = false;
         AssignAttri("", false, "A946BancoCountAgencia_F", StringUtil.LTrimStr( (decimal)(A946BancoCountAgencia_F), 4, 0));
         Z404BancoCodigo = 0;
         Z403BancoNome = "";
      }

      protected void InitAll1K59( )
      {
         A402BancoId = 0;
         n402BancoId = false;
         AssignAttri("", false, "A402BancoId", StringUtil.LTrimStr( (decimal)(A402BancoId), 9, 0));
         InitializeNonKey1K59( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019164234", true, true);
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
         context.AddJavascriptSource("banco.js", "?202561019164234", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtBancoCodigo_Internalname = "BANCOCODIGO";
         edtBancoNome_Internalname = "BANCONOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtBancoId_Internalname = "BANCOID";
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
         Form.Caption = "Banco";
         edtBancoId_Jsonclick = "";
         edtBancoId_Enabled = 0;
         edtBancoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtBancoNome_Jsonclick = "";
         edtBancoNome_Enabled = 1;
         edtBancoCodigo_Jsonclick = "";
         edtBancoCodigo_Enabled = 1;
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

      public void Valid_Bancoid( )
      {
         n402BancoId = false;
         n946BancoCountAgencia_F = false;
         /* Using cursor T001K19 */
         pr_default.execute(13, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A946BancoCountAgencia_F = T001K19_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = T001K19_n946BancoCountAgencia_F[0];
         }
         else
         {
            A946BancoCountAgencia_F = 0;
            n946BancoCountAgencia_F = false;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A946BancoCountAgencia_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A946BancoCountAgencia_F), 4, 0, ".", "")));
      }

      public void Valid_Bancocodigo( )
      {
         n402BancoId = false;
         /* Using cursor T001K24 */
         pr_default.execute(18, new Object[] {n404BancoCodigo, A404BancoCodigo, n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Banco Codigo"}), 1, "BANCOCODIGO");
            AnyError = 1;
            GX_FocusControl = edtBancoCodigo_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A402BancoId","fld":"BANCOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121K2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_BANCOCODIGO","""{"handler":"Valid_Bancocodigo","iparms":[{"av":"A404BancoCodigo","fld":"BANCOCODIGO","pic":"ZZZZZZZZ9","nullAv":"n404BancoCodigo","type":"int"},{"av":"A402BancoId","fld":"BANCOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_BANCOID","""{"handler":"Valid_Bancoid","iparms":[{"av":"A402BancoId","fld":"BANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A946BancoCountAgencia_F","fld":"BANCOCOUNTAGENCIA_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_BANCOID",""","oparms":[{"av":"A946BancoCountAgencia_F","fld":"BANCOCOUNTAGENCIA_F","pic":"ZZZ9","type":"int"}]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z403BancoNome = "";
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
         A403BancoNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode59 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T001K5_A946BancoCountAgencia_F = new short[1] ;
         T001K5_n946BancoCountAgencia_F = new bool[] {false} ;
         T001K7_A402BancoId = new int[1] ;
         T001K7_n402BancoId = new bool[] {false} ;
         T001K7_A404BancoCodigo = new int[1] ;
         T001K7_n404BancoCodigo = new bool[] {false} ;
         T001K7_A403BancoNome = new string[] {""} ;
         T001K7_n403BancoNome = new bool[] {false} ;
         T001K7_A946BancoCountAgencia_F = new short[1] ;
         T001K7_n946BancoCountAgencia_F = new bool[] {false} ;
         T001K8_A404BancoCodigo = new int[1] ;
         T001K8_n404BancoCodigo = new bool[] {false} ;
         T001K10_A946BancoCountAgencia_F = new short[1] ;
         T001K10_n946BancoCountAgencia_F = new bool[] {false} ;
         T001K11_A402BancoId = new int[1] ;
         T001K11_n402BancoId = new bool[] {false} ;
         T001K3_A402BancoId = new int[1] ;
         T001K3_n402BancoId = new bool[] {false} ;
         T001K3_A404BancoCodigo = new int[1] ;
         T001K3_n404BancoCodigo = new bool[] {false} ;
         T001K3_A403BancoNome = new string[] {""} ;
         T001K3_n403BancoNome = new bool[] {false} ;
         T001K12_A402BancoId = new int[1] ;
         T001K12_n402BancoId = new bool[] {false} ;
         T001K13_A402BancoId = new int[1] ;
         T001K13_n402BancoId = new bool[] {false} ;
         T001K2_A402BancoId = new int[1] ;
         T001K2_n402BancoId = new bool[] {false} ;
         T001K2_A404BancoCodigo = new int[1] ;
         T001K2_n404BancoCodigo = new bool[] {false} ;
         T001K2_A403BancoNome = new string[] {""} ;
         T001K2_n403BancoNome = new bool[] {false} ;
         T001K15_A402BancoId = new int[1] ;
         T001K15_n402BancoId = new bool[] {false} ;
         T001K19_A946BancoCountAgencia_F = new short[1] ;
         T001K19_n946BancoCountAgencia_F = new bool[] {false} ;
         T001K20_A938AgenciaId = new int[1] ;
         T001K21_A249EmpresaId = new int[1] ;
         T001K22_A168ClienteId = new int[1] ;
         T001K23_A402BancoId = new int[1] ;
         T001K23_n402BancoId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001K24_A404BancoCodigo = new int[1] ;
         T001K24_n404BancoCodigo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.banco__default(),
            new Object[][] {
                new Object[] {
               T001K2_A402BancoId, T001K2_A404BancoCodigo, T001K2_n404BancoCodigo, T001K2_A403BancoNome, T001K2_n403BancoNome
               }
               , new Object[] {
               T001K3_A402BancoId, T001K3_A404BancoCodigo, T001K3_n404BancoCodigo, T001K3_A403BancoNome, T001K3_n403BancoNome
               }
               , new Object[] {
               T001K5_A946BancoCountAgencia_F, T001K5_n946BancoCountAgencia_F
               }
               , new Object[] {
               T001K7_A402BancoId, T001K7_A404BancoCodigo, T001K7_n404BancoCodigo, T001K7_A403BancoNome, T001K7_n403BancoNome, T001K7_A946BancoCountAgencia_F, T001K7_n946BancoCountAgencia_F
               }
               , new Object[] {
               T001K8_A404BancoCodigo, T001K8_n404BancoCodigo
               }
               , new Object[] {
               T001K10_A946BancoCountAgencia_F, T001K10_n946BancoCountAgencia_F
               }
               , new Object[] {
               T001K11_A402BancoId
               }
               , new Object[] {
               T001K12_A402BancoId
               }
               , new Object[] {
               T001K13_A402BancoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001K15_A402BancoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001K19_A946BancoCountAgencia_F, T001K19_n946BancoCountAgencia_F
               }
               , new Object[] {
               T001K20_A938AgenciaId
               }
               , new Object[] {
               T001K21_A249EmpresaId
               }
               , new Object[] {
               T001K22_A168ClienteId
               }
               , new Object[] {
               T001K23_A402BancoId
               }
               , new Object[] {
               T001K24_A404BancoCodigo, T001K24_n404BancoCodigo
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A946BancoCountAgencia_F ;
      private short RcdFound59 ;
      private short Z946BancoCountAgencia_F ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7BancoId ;
      private int Z402BancoId ;
      private int Z404BancoCodigo ;
      private int A402BancoId ;
      private int AV7BancoId ;
      private int trnEnded ;
      private int A404BancoCodigo ;
      private int edtBancoCodigo_Enabled ;
      private int edtBancoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtBancoId_Enabled ;
      private int edtBancoId_Visible ;
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
      private string edtBancoCodigo_Internalname ;
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
      private string edtBancoCodigo_Jsonclick ;
      private string edtBancoNome_Internalname ;
      private string edtBancoNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtBancoId_Internalname ;
      private string edtBancoId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode59 ;
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
      private bool n402BancoId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private bool n946BancoCountAgencia_F ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string Z403BancoNome ;
      private string A403BancoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T001K5_A946BancoCountAgencia_F ;
      private bool[] T001K5_n946BancoCountAgencia_F ;
      private int[] T001K7_A402BancoId ;
      private bool[] T001K7_n402BancoId ;
      private int[] T001K7_A404BancoCodigo ;
      private bool[] T001K7_n404BancoCodigo ;
      private string[] T001K7_A403BancoNome ;
      private bool[] T001K7_n403BancoNome ;
      private short[] T001K7_A946BancoCountAgencia_F ;
      private bool[] T001K7_n946BancoCountAgencia_F ;
      private int[] T001K8_A404BancoCodigo ;
      private bool[] T001K8_n404BancoCodigo ;
      private short[] T001K10_A946BancoCountAgencia_F ;
      private bool[] T001K10_n946BancoCountAgencia_F ;
      private int[] T001K11_A402BancoId ;
      private bool[] T001K11_n402BancoId ;
      private int[] T001K3_A402BancoId ;
      private bool[] T001K3_n402BancoId ;
      private int[] T001K3_A404BancoCodigo ;
      private bool[] T001K3_n404BancoCodigo ;
      private string[] T001K3_A403BancoNome ;
      private bool[] T001K3_n403BancoNome ;
      private int[] T001K12_A402BancoId ;
      private bool[] T001K12_n402BancoId ;
      private int[] T001K13_A402BancoId ;
      private bool[] T001K13_n402BancoId ;
      private int[] T001K2_A402BancoId ;
      private bool[] T001K2_n402BancoId ;
      private int[] T001K2_A404BancoCodigo ;
      private bool[] T001K2_n404BancoCodigo ;
      private string[] T001K2_A403BancoNome ;
      private bool[] T001K2_n403BancoNome ;
      private int[] T001K15_A402BancoId ;
      private bool[] T001K15_n402BancoId ;
      private short[] T001K19_A946BancoCountAgencia_F ;
      private bool[] T001K19_n946BancoCountAgencia_F ;
      private int[] T001K20_A938AgenciaId ;
      private int[] T001K21_A249EmpresaId ;
      private int[] T001K22_A168ClienteId ;
      private int[] T001K23_A402BancoId ;
      private bool[] T001K23_n402BancoId ;
      private int[] T001K24_A404BancoCodigo ;
      private bool[] T001K24_n404BancoCodigo ;
   }

   public class banco__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001K2;
          prmT001K2 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K3;
          prmT001K3 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K5;
          prmT001K5 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K7;
          prmT001K7 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K8;
          prmT001K8 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K10;
          prmT001K10 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K11;
          prmT001K11 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K12;
          prmT001K12 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K13;
          prmT001K13 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K14;
          prmT001K14 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoNome",GXType.VarChar,150,0){Nullable=true}
          };
          Object[] prmT001K15;
          prmT001K15 = new Object[] {
          };
          Object[] prmT001K16;
          prmT001K16 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K17;
          prmT001K17 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K19;
          prmT001K19 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K20;
          prmT001K20 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K21;
          prmT001K21 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K22;
          prmT001K22 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001K23;
          prmT001K23 = new Object[] {
          };
          Object[] prmT001K24;
          prmT001K24 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001K2", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId  FOR UPDATE OF Banco NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001K2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K3", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K5", "SELECT COALESCE( T1.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia GROUP BY AgenciaBancoId ) T1 WHERE T1.AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K7", "SELECT TM1.BancoId, TM1.BancoCodigo, TM1.BancoNome, COALESCE( T2.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (Banco TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia WHERE TM1.BancoId = AgenciaBancoId GROUP BY AgenciaBancoId ) T2 ON T2.AgenciaBancoId = TM1.BancoId) WHERE TM1.BancoId = :BancoId ORDER BY TM1.BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K8", "SELECT BancoCodigo FROM Banco WHERE (BancoCodigo = :BancoCodigo) AND (Not ( BancoId = :BancoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K10", "SELECT COALESCE( T1.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia GROUP BY AgenciaBancoId ) T1 WHERE T1.AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K11", "SELECT BancoId FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K12", "SELECT BancoId FROM Banco WHERE ( BancoId > :BancoId) ORDER BY BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001K13", "SELECT BancoId FROM Banco WHERE ( BancoId < :BancoId) ORDER BY BancoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001K14", "SAVEPOINT gxupdate;INSERT INTO Banco(BancoCodigo, BancoNome) VALUES(:BancoCodigo, :BancoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001K14)
             ,new CursorDef("T001K15", "SELECT currval('BancoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K16", "SAVEPOINT gxupdate;UPDATE Banco SET BancoCodigo=:BancoCodigo, BancoNome=:BancoNome  WHERE BancoId = :BancoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001K16)
             ,new CursorDef("T001K17", "SAVEPOINT gxupdate;DELETE FROM Banco  WHERE BancoId = :BancoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001K17)
             ,new CursorDef("T001K19", "SELECT COALESCE( T1.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia GROUP BY AgenciaBancoId ) T1 WHERE T1.AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K20", "SELECT AgenciaId FROM Agencia WHERE AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001K21", "SELECT EmpresaId FROM Empresa WHERE EmpresaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001K22", "SELECT ClienteId FROM Cliente WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001K23", "SELECT BancoId FROM Banco ORDER BY BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001K24", "SELECT BancoCodigo FROM Banco WHERE (BancoCodigo = :BancoCodigo) AND (Not ( BancoId = :BancoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K24,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
