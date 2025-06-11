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
   public class contrato : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A227ContratoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
            A473ContratoClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoClienteId"), "."), 18, MidpointRounding.ToEven));
            n473ContratoClienteId = false;
            AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A227ContratoId, A473ContratoClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A473ContratoClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoClienteId"), "."), 18, MidpointRounding.ToEven));
            n473ContratoClienteId = false;
            AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A473ContratoClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A923ContratoPropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoPropostaId"), "."), 18, MidpointRounding.ToEven));
            n923ContratoPropostaId = false;
            AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A923ContratoPropostaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contrato")), "contrato") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contrato")))) ;
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
                  AV7ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ContratoId", StringUtil.LTrimStr( (decimal)(AV7ContratoId), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContratoId), "ZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Contrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtContratoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public contrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ContratoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ContratoId = aP1_ContratoId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContratoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")), StringUtil.LTrim( ((edtContratoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContratoId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Contrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContratoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoNome_Internalname, "Contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoNome_Internalname, A228ContratoNome, StringUtil.RTrim( context.localUtil.Format( A228ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContratoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Contrato.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E110X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z228ContratoNome = cgiGet( "Z228ContratoNome");
               n228ContratoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? true : false);
               Z361ContratoComVigencia = StringUtil.StrToBool( cgiGet( "Z361ContratoComVigencia"));
               n361ContratoComVigencia = ((false==A361ContratoComVigencia) ? true : false);
               Z362ContratoDataInicial = context.localUtil.CToD( cgiGet( "Z362ContratoDataInicial"), 0);
               n362ContratoDataInicial = ((DateTime.MinValue==A362ContratoDataInicial) ? true : false);
               Z363ContratoDataFinal = context.localUtil.CToD( cgiGet( "Z363ContratoDataFinal"), 0);
               n363ContratoDataFinal = ((DateTime.MinValue==A363ContratoDataFinal) ? true : false);
               Z460ContratoTaxa = context.localUtil.CToN( cgiGet( "Z460ContratoTaxa"), ",", ".");
               n460ContratoTaxa = ((Convert.ToDecimal(0)==A460ContratoTaxa) ? true : false);
               Z461ContratoSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z461ContratoSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n461ContratoSLA = ((0==A461ContratoSLA) ? true : false);
               Z462ContratoJurosMora = context.localUtil.CToN( cgiGet( "Z462ContratoJurosMora"), ",", ".");
               n462ContratoJurosMora = ((Convert.ToDecimal(0)==A462ContratoJurosMora) ? true : false);
               Z463ContratoIOFMinimo = context.localUtil.CToN( cgiGet( "Z463ContratoIOFMinimo"), ",", ".");
               n463ContratoIOFMinimo = ((Convert.ToDecimal(0)==A463ContratoIOFMinimo) ? true : false);
               Z471ContratoSituacao = cgiGet( "Z471ContratoSituacao");
               n471ContratoSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A471ContratoSituacao)) ? true : false);
               Z473ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z473ContratoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n473ContratoClienteId = ((0==A473ContratoClienteId) ? true : false);
               Z923ContratoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z923ContratoPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n923ContratoPropostaId = ((0==A923ContratoPropostaId) ? true : false);
               A361ContratoComVigencia = StringUtil.StrToBool( cgiGet( "Z361ContratoComVigencia"));
               n361ContratoComVigencia = false;
               n361ContratoComVigencia = ((false==A361ContratoComVigencia) ? true : false);
               A362ContratoDataInicial = context.localUtil.CToD( cgiGet( "Z362ContratoDataInicial"), 0);
               n362ContratoDataInicial = false;
               n362ContratoDataInicial = ((DateTime.MinValue==A362ContratoDataInicial) ? true : false);
               A363ContratoDataFinal = context.localUtil.CToD( cgiGet( "Z363ContratoDataFinal"), 0);
               n363ContratoDataFinal = false;
               n363ContratoDataFinal = ((DateTime.MinValue==A363ContratoDataFinal) ? true : false);
               A460ContratoTaxa = context.localUtil.CToN( cgiGet( "Z460ContratoTaxa"), ",", ".");
               n460ContratoTaxa = false;
               n460ContratoTaxa = ((Convert.ToDecimal(0)==A460ContratoTaxa) ? true : false);
               A461ContratoSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z461ContratoSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n461ContratoSLA = false;
               n461ContratoSLA = ((0==A461ContratoSLA) ? true : false);
               A462ContratoJurosMora = context.localUtil.CToN( cgiGet( "Z462ContratoJurosMora"), ",", ".");
               n462ContratoJurosMora = false;
               n462ContratoJurosMora = ((Convert.ToDecimal(0)==A462ContratoJurosMora) ? true : false);
               A463ContratoIOFMinimo = context.localUtil.CToN( cgiGet( "Z463ContratoIOFMinimo"), ",", ".");
               n463ContratoIOFMinimo = false;
               n463ContratoIOFMinimo = ((Convert.ToDecimal(0)==A463ContratoIOFMinimo) ? true : false);
               A471ContratoSituacao = cgiGet( "Z471ContratoSituacao");
               n471ContratoSituacao = false;
               n471ContratoSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A471ContratoSituacao)) ? true : false);
               A473ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z473ContratoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n473ContratoClienteId = false;
               n473ContratoClienteId = ((0==A473ContratoClienteId) ? true : false);
               A923ContratoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z923ContratoPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n923ContratoPropostaId = false;
               n923ContratoPropostaId = ((0==A923ContratoPropostaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N473ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N473ContratoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n473ContratoClienteId = ((0==A473ContratoClienteId) ? true : false);
               N923ContratoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N923ContratoPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n923ContratoPropostaId = ((0==A923ContratoPropostaId) ? true : false);
               AV7ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONTRATOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV14Insert_ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTRATOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_ContratoClienteId", StringUtil.LTrimStr( (decimal)(AV14Insert_ContratoClienteId), 9, 0));
               A473ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONTRATOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n473ContratoClienteId = ((0==A473ContratoClienteId) ? true : false);
               AV15Insert_ContratoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTRATOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15Insert_ContratoPropostaId", StringUtil.LTrimStr( (decimal)(AV15Insert_ContratoPropostaId), 9, 0));
               A923ContratoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONTRATOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               n923ContratoPropostaId = ((0==A923ContratoPropostaId) ? true : false);
               A339ContratoCorpo = cgiGet( "CONTRATOCORPO");
               n339ContratoCorpo = false;
               n339ContratoCorpo = (String.IsNullOrEmpty(StringUtil.RTrim( A339ContratoCorpo)) ? true : false);
               A361ContratoComVigencia = StringUtil.StrToBool( cgiGet( "CONTRATOCOMVIGENCIA"));
               n361ContratoComVigencia = ((false==A361ContratoComVigencia) ? true : false);
               A362ContratoDataInicial = context.localUtil.CToD( cgiGet( "CONTRATODATAINICIAL"), 0);
               n362ContratoDataInicial = ((DateTime.MinValue==A362ContratoDataInicial) ? true : false);
               A363ContratoDataFinal = context.localUtil.CToD( cgiGet( "CONTRATODATAFINAL"), 0);
               n363ContratoDataFinal = ((DateTime.MinValue==A363ContratoDataFinal) ? true : false);
               A460ContratoTaxa = context.localUtil.CToN( cgiGet( "CONTRATOTAXA"), ",", ".");
               n460ContratoTaxa = ((Convert.ToDecimal(0)==A460ContratoTaxa) ? true : false);
               A461ContratoSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONTRATOSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n461ContratoSLA = ((0==A461ContratoSLA) ? true : false);
               A462ContratoJurosMora = context.localUtil.CToN( cgiGet( "CONTRATOJUROSMORA"), ",", ".");
               n462ContratoJurosMora = ((Convert.ToDecimal(0)==A462ContratoJurosMora) ? true : false);
               A463ContratoIOFMinimo = context.localUtil.CToN( cgiGet( "CONTRATOIOFMINIMO"), ",", ".");
               n463ContratoIOFMinimo = ((Convert.ToDecimal(0)==A463ContratoIOFMinimo) ? true : false);
               A471ContratoSituacao = cgiGet( "CONTRATOSITUACAO");
               n471ContratoSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A471ContratoSituacao)) ? true : false);
               A472ContratoBlob = cgiGet( "CONTRATOBLOB");
               n472ContratoBlob = false;
               n472ContratoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A472ContratoBlob)) ? true : false);
               A474ContratoClienteNome = cgiGet( "CONTRATOCLIENTENOME");
               n474ContratoClienteNome = false;
               A475ContratoClienteDocumento = cgiGet( "CONTRATOCLIENTEDOCUMENTO");
               n475ContratoClienteDocumento = false;
               A476ContratoClienteRepresentanteNome = cgiGet( "CONTRATOCLIENTEREPRESENTANTENOME");
               n476ContratoClienteRepresentanteNome = false;
               A477ContratoClienteRepresentanteCPF = cgiGet( "CONTRATOCLIENTEREPRESENTANTECPF");
               n477ContratoClienteRepresentanteCPF = false;
               A561ContratoClienteTipoPessoa = cgiGet( "CONTRATOCLIENTETIPOPESSOA");
               n561ContratoClienteTipoPessoa = false;
               A614ContratoClienteEnderecoCEP = cgiGet( "CONTRATOCLIENTEENDERECOCEP");
               n614ContratoClienteEnderecoCEP = false;
               A615ContratoClienteEnderecoLograodouro = cgiGet( "CONTRATOCLIENTEENDERECOLOGRAODOURO");
               n615ContratoClienteEnderecoLograodouro = false;
               A616ContratoClienteEnderecoNumero = cgiGet( "CONTRATOCLIENTEENDERECONUMERO");
               n616ContratoClienteEnderecoNumero = false;
               A617ContratoClienteEnderecoComplemento = cgiGet( "CONTRATOCLIENTEENDERECOCOMPLEMENTO");
               n617ContratoClienteEnderecoComplemento = false;
               A618ContratoClienteEnderecoBairro = cgiGet( "CONTRATOCLIENTEENDERECOBAIRRO");
               n618ContratoClienteEnderecoBairro = false;
               A619ContratoClienteMunicipioCodigo = cgiGet( "CONTRATOCLIENTEMUNICIPIOCODIGO");
               n619ContratoClienteMunicipioCodigo = false;
               A483AssinaturaUltId_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ASSINATURAULTID_F"), ",", "."), 18, MidpointRounding.ToEven));
               n483AssinaturaUltId_F = false;
               A1007ContratoCountAssinantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONTRATOCOUNTASSINANTES_F"), ",", "."), 18, MidpointRounding.ToEven));
               n1007ContratoCountAssinantes_F = false;
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
               A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
               A228ContratoNome = cgiGet( edtContratoNome_Internalname);
               n228ContratoNome = false;
               AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
               n228ContratoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Contrato");
               A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
               forbiddenHiddens.Add("ContratoId", context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContratoClienteId", context.localUtil.Format( (decimal)(AV14Insert_ContratoClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContratoPropostaId", context.localUtil.Format( (decimal)(AV15Insert_ContratoPropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ContratoComVigencia", StringUtil.BoolToStr( A361ContratoComVigencia));
               forbiddenHiddens.Add("ContratoDataInicial", context.localUtil.Format(A362ContratoDataInicial, "99/99/99"));
               forbiddenHiddens.Add("ContratoDataFinal", context.localUtil.Format(A363ContratoDataFinal, "99/99/99"));
               forbiddenHiddens.Add("ContratoTaxa", context.localUtil.Format( A460ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("ContratoSLA", context.localUtil.Format( (decimal)(A461ContratoSLA), "ZZZ9"));
               forbiddenHiddens.Add("ContratoJurosMora", context.localUtil.Format( A462ContratoJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("ContratoIOFMinimo", context.localUtil.Format( A463ContratoIOFMinimo, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("ContratoSituacao", StringUtil.RTrim( context.localUtil.Format( A471ContratoSituacao, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A227ContratoId != Z227ContratoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contrato:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
                  n227ContratoId = false;
                  AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
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
                     sMode36 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode36;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound36 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONTRATOID");
                        AnyError = 1;
                        GX_FocusControl = edtContratoId_Internalname;
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
                           E110X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120X2 ();
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
            E120X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0X36( ) ;
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
            DisableAttributes0X36( ) ;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X36( ) ;
            }
            else
            {
               CheckExtendedTable0X36( ) ;
               CloseExtendedTableCursors0X36( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0X0( )
      {
      }

      protected void E110X2( )
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
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContratoClienteId") == 0 )
               {
                  AV14Insert_ContratoClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_ContratoClienteId", StringUtil.LTrimStr( (decimal)(AV14Insert_ContratoClienteId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContratoPropostaId") == 0 )
               {
                  AV15Insert_ContratoPropostaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Insert_ContratoPropostaId", StringUtil.LTrimStr( (decimal)(AV15Insert_ContratoPropostaId), 9, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E120X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "contratoww"+UrlEncode(StringUtil.LTrimStr(A473ContratoClienteId,9,0));
            CallWebObject(formatLink("contratoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0X36( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z228ContratoNome = T000X3_A228ContratoNome[0];
               Z361ContratoComVigencia = T000X3_A361ContratoComVigencia[0];
               Z362ContratoDataInicial = T000X3_A362ContratoDataInicial[0];
               Z363ContratoDataFinal = T000X3_A363ContratoDataFinal[0];
               Z460ContratoTaxa = T000X3_A460ContratoTaxa[0];
               Z461ContratoSLA = T000X3_A461ContratoSLA[0];
               Z462ContratoJurosMora = T000X3_A462ContratoJurosMora[0];
               Z463ContratoIOFMinimo = T000X3_A463ContratoIOFMinimo[0];
               Z471ContratoSituacao = T000X3_A471ContratoSituacao[0];
               Z473ContratoClienteId = T000X3_A473ContratoClienteId[0];
               Z923ContratoPropostaId = T000X3_A923ContratoPropostaId[0];
            }
            else
            {
               Z228ContratoNome = A228ContratoNome;
               Z361ContratoComVigencia = A361ContratoComVigencia;
               Z362ContratoDataInicial = A362ContratoDataInicial;
               Z363ContratoDataFinal = A363ContratoDataFinal;
               Z460ContratoTaxa = A460ContratoTaxa;
               Z461ContratoSLA = A461ContratoSLA;
               Z462ContratoJurosMora = A462ContratoJurosMora;
               Z463ContratoIOFMinimo = A463ContratoIOFMinimo;
               Z471ContratoSituacao = A471ContratoSituacao;
               Z473ContratoClienteId = A473ContratoClienteId;
               Z923ContratoPropostaId = A923ContratoPropostaId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z227ContratoId = A227ContratoId;
            Z228ContratoNome = A228ContratoNome;
            Z339ContratoCorpo = A339ContratoCorpo;
            Z361ContratoComVigencia = A361ContratoComVigencia;
            Z362ContratoDataInicial = A362ContratoDataInicial;
            Z363ContratoDataFinal = A363ContratoDataFinal;
            Z460ContratoTaxa = A460ContratoTaxa;
            Z461ContratoSLA = A461ContratoSLA;
            Z462ContratoJurosMora = A462ContratoJurosMora;
            Z463ContratoIOFMinimo = A463ContratoIOFMinimo;
            Z471ContratoSituacao = A471ContratoSituacao;
            Z472ContratoBlob = A472ContratoBlob;
            Z473ContratoClienteId = A473ContratoClienteId;
            Z923ContratoPropostaId = A923ContratoPropostaId;
            Z474ContratoClienteNome = A474ContratoClienteNome;
            Z475ContratoClienteDocumento = A475ContratoClienteDocumento;
            Z476ContratoClienteRepresentanteNome = A476ContratoClienteRepresentanteNome;
            Z477ContratoClienteRepresentanteCPF = A477ContratoClienteRepresentanteCPF;
            Z561ContratoClienteTipoPessoa = A561ContratoClienteTipoPessoa;
            Z614ContratoClienteEnderecoCEP = A614ContratoClienteEnderecoCEP;
            Z615ContratoClienteEnderecoLograodouro = A615ContratoClienteEnderecoLograodouro;
            Z616ContratoClienteEnderecoNumero = A616ContratoClienteEnderecoNumero;
            Z617ContratoClienteEnderecoComplemento = A617ContratoClienteEnderecoComplemento;
            Z618ContratoClienteEnderecoBairro = A618ContratoClienteEnderecoBairro;
            Z619ContratoClienteMunicipioCodigo = A619ContratoClienteMunicipioCodigo;
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
      }

      protected void standaloneNotModal( )
      {
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         AV16Pgmname = "Contrato";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ContratoId) )
         {
            A227ContratoId = AV7ContratoId;
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
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
            /* Using cursor T000X7 */
            pr_default.execute(4, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A483AssinaturaUltId_F = T000X7_A483AssinaturaUltId_F[0];
               n483AssinaturaUltId_F = T000X7_n483AssinaturaUltId_F[0];
            }
            else
            {
               A483AssinaturaUltId_F = 0;
               n483AssinaturaUltId_F = false;
               AssignAttri("", false, "A483AssinaturaUltId_F", StringUtil.LTrimStr( (decimal)(A483AssinaturaUltId_F), 4, 0));
            }
            pr_default.close(4);
         }
      }

      protected void Load0X36( )
      {
         /* Using cursor T000X12 */
         pr_default.execute(6, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound36 = 1;
            A228ContratoNome = T000X12_A228ContratoNome[0];
            n228ContratoNome = T000X12_n228ContratoNome[0];
            AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
            A339ContratoCorpo = T000X12_A339ContratoCorpo[0];
            n339ContratoCorpo = T000X12_n339ContratoCorpo[0];
            A361ContratoComVigencia = T000X12_A361ContratoComVigencia[0];
            n361ContratoComVigencia = T000X12_n361ContratoComVigencia[0];
            A362ContratoDataInicial = T000X12_A362ContratoDataInicial[0];
            n362ContratoDataInicial = T000X12_n362ContratoDataInicial[0];
            A363ContratoDataFinal = T000X12_A363ContratoDataFinal[0];
            n363ContratoDataFinal = T000X12_n363ContratoDataFinal[0];
            A474ContratoClienteNome = T000X12_A474ContratoClienteNome[0];
            n474ContratoClienteNome = T000X12_n474ContratoClienteNome[0];
            A475ContratoClienteDocumento = T000X12_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = T000X12_n475ContratoClienteDocumento[0];
            A476ContratoClienteRepresentanteNome = T000X12_A476ContratoClienteRepresentanteNome[0];
            n476ContratoClienteRepresentanteNome = T000X12_n476ContratoClienteRepresentanteNome[0];
            A477ContratoClienteRepresentanteCPF = T000X12_A477ContratoClienteRepresentanteCPF[0];
            n477ContratoClienteRepresentanteCPF = T000X12_n477ContratoClienteRepresentanteCPF[0];
            A561ContratoClienteTipoPessoa = T000X12_A561ContratoClienteTipoPessoa[0];
            n561ContratoClienteTipoPessoa = T000X12_n561ContratoClienteTipoPessoa[0];
            A460ContratoTaxa = T000X12_A460ContratoTaxa[0];
            n460ContratoTaxa = T000X12_n460ContratoTaxa[0];
            A461ContratoSLA = T000X12_A461ContratoSLA[0];
            n461ContratoSLA = T000X12_n461ContratoSLA[0];
            A462ContratoJurosMora = T000X12_A462ContratoJurosMora[0];
            n462ContratoJurosMora = T000X12_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = T000X12_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = T000X12_n463ContratoIOFMinimo[0];
            A471ContratoSituacao = T000X12_A471ContratoSituacao[0];
            n471ContratoSituacao = T000X12_n471ContratoSituacao[0];
            A614ContratoClienteEnderecoCEP = T000X12_A614ContratoClienteEnderecoCEP[0];
            n614ContratoClienteEnderecoCEP = T000X12_n614ContratoClienteEnderecoCEP[0];
            A615ContratoClienteEnderecoLograodouro = T000X12_A615ContratoClienteEnderecoLograodouro[0];
            n615ContratoClienteEnderecoLograodouro = T000X12_n615ContratoClienteEnderecoLograodouro[0];
            A616ContratoClienteEnderecoNumero = T000X12_A616ContratoClienteEnderecoNumero[0];
            n616ContratoClienteEnderecoNumero = T000X12_n616ContratoClienteEnderecoNumero[0];
            A617ContratoClienteEnderecoComplemento = T000X12_A617ContratoClienteEnderecoComplemento[0];
            n617ContratoClienteEnderecoComplemento = T000X12_n617ContratoClienteEnderecoComplemento[0];
            A618ContratoClienteEnderecoBairro = T000X12_A618ContratoClienteEnderecoBairro[0];
            n618ContratoClienteEnderecoBairro = T000X12_n618ContratoClienteEnderecoBairro[0];
            A473ContratoClienteId = T000X12_A473ContratoClienteId[0];
            n473ContratoClienteId = T000X12_n473ContratoClienteId[0];
            A923ContratoPropostaId = T000X12_A923ContratoPropostaId[0];
            n923ContratoPropostaId = T000X12_n923ContratoPropostaId[0];
            A619ContratoClienteMunicipioCodigo = T000X12_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = T000X12_n619ContratoClienteMunicipioCodigo[0];
            A483AssinaturaUltId_F = T000X12_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = T000X12_n483AssinaturaUltId_F[0];
            A1007ContratoCountAssinantes_F = T000X12_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = T000X12_n1007ContratoCountAssinantes_F[0];
            A472ContratoBlob = T000X12_A472ContratoBlob[0];
            n472ContratoBlob = T000X12_n472ContratoBlob[0];
            ZM0X36( -9) ;
         }
         pr_default.close(6);
         OnLoadActions0X36( ) ;
      }

      protected void OnLoadActions0X36( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_ContratoClienteId) )
         {
            A473ContratoClienteId = AV14Insert_ContratoClienteId;
            n473ContratoClienteId = false;
            AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A473ContratoClienteId) )
            {
               A473ContratoClienteId = 0;
               n473ContratoClienteId = false;
               AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
               n473ContratoClienteId = true;
               n473ContratoClienteId = true;
               AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ContratoPropostaId) )
         {
            A923ContratoPropostaId = AV15Insert_ContratoPropostaId;
            n923ContratoPropostaId = false;
            AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A923ContratoPropostaId) )
            {
               A923ContratoPropostaId = 0;
               n923ContratoPropostaId = false;
               AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
               n923ContratoPropostaId = true;
               n923ContratoPropostaId = true;
               AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
            }
         }
      }

      protected void CheckExtendedTable0X36( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_ContratoClienteId) )
         {
            A473ContratoClienteId = AV14Insert_ContratoClienteId;
            n473ContratoClienteId = false;
            AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A473ContratoClienteId) )
            {
               A473ContratoClienteId = 0;
               n473ContratoClienteId = false;
               AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
               n473ContratoClienteId = true;
               n473ContratoClienteId = true;
               AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ContratoPropostaId) )
         {
            A923ContratoPropostaId = AV15Insert_ContratoPropostaId;
            n923ContratoPropostaId = false;
            AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A923ContratoPropostaId) )
            {
               A923ContratoPropostaId = 0;
               n923ContratoPropostaId = false;
               AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
               n923ContratoPropostaId = true;
               n923ContratoPropostaId = true;
               AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
            }
         }
         /* Using cursor T000X7 */
         pr_default.execute(4, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A483AssinaturaUltId_F = T000X7_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = T000X7_n483AssinaturaUltId_F[0];
         }
         else
         {
            A483AssinaturaUltId_F = 0;
            n483AssinaturaUltId_F = false;
            AssignAttri("", false, "A483AssinaturaUltId_F", StringUtil.LTrimStr( (decimal)(A483AssinaturaUltId_F), 4, 0));
         }
         pr_default.close(4);
         /* Using cursor T000X9 */
         pr_default.execute(5, new Object[] {n227ContratoId, A227ContratoId, n473ContratoClienteId, A473ContratoClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1007ContratoCountAssinantes_F = T000X9_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = T000X9_n1007ContratoCountAssinantes_F[0];
         }
         else
         {
            A1007ContratoCountAssinantes_F = 0;
            n1007ContratoCountAssinantes_F = false;
            AssignAttri("", false, "A1007ContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(A1007ContratoCountAssinantes_F), 4, 0));
         }
         pr_default.close(5);
         /* Using cursor T000X4 */
         pr_default.execute(2, new Object[] {n473ContratoClienteId, A473ContratoClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A473ContratoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Contrato Cliente'.", "ForeignKeyNotFound", 1, "CONTRATOCLIENTEID");
               AnyError = 1;
            }
         }
         A474ContratoClienteNome = T000X4_A474ContratoClienteNome[0];
         n474ContratoClienteNome = T000X4_n474ContratoClienteNome[0];
         A475ContratoClienteDocumento = T000X4_A475ContratoClienteDocumento[0];
         n475ContratoClienteDocumento = T000X4_n475ContratoClienteDocumento[0];
         A476ContratoClienteRepresentanteNome = T000X4_A476ContratoClienteRepresentanteNome[0];
         n476ContratoClienteRepresentanteNome = T000X4_n476ContratoClienteRepresentanteNome[0];
         A477ContratoClienteRepresentanteCPF = T000X4_A477ContratoClienteRepresentanteCPF[0];
         n477ContratoClienteRepresentanteCPF = T000X4_n477ContratoClienteRepresentanteCPF[0];
         A561ContratoClienteTipoPessoa = T000X4_A561ContratoClienteTipoPessoa[0];
         n561ContratoClienteTipoPessoa = T000X4_n561ContratoClienteTipoPessoa[0];
         A614ContratoClienteEnderecoCEP = T000X4_A614ContratoClienteEnderecoCEP[0];
         n614ContratoClienteEnderecoCEP = T000X4_n614ContratoClienteEnderecoCEP[0];
         A615ContratoClienteEnderecoLograodouro = T000X4_A615ContratoClienteEnderecoLograodouro[0];
         n615ContratoClienteEnderecoLograodouro = T000X4_n615ContratoClienteEnderecoLograodouro[0];
         A616ContratoClienteEnderecoNumero = T000X4_A616ContratoClienteEnderecoNumero[0];
         n616ContratoClienteEnderecoNumero = T000X4_n616ContratoClienteEnderecoNumero[0];
         A617ContratoClienteEnderecoComplemento = T000X4_A617ContratoClienteEnderecoComplemento[0];
         n617ContratoClienteEnderecoComplemento = T000X4_n617ContratoClienteEnderecoComplemento[0];
         A618ContratoClienteEnderecoBairro = T000X4_A618ContratoClienteEnderecoBairro[0];
         n618ContratoClienteEnderecoBairro = T000X4_n618ContratoClienteEnderecoBairro[0];
         A619ContratoClienteMunicipioCodigo = T000X4_A619ContratoClienteMunicipioCodigo[0];
         n619ContratoClienteMunicipioCodigo = T000X4_n619ContratoClienteMunicipioCodigo[0];
         pr_default.close(2);
         /* Using cursor T000X5 */
         pr_default.execute(3, new Object[] {n923ContratoPropostaId, A923ContratoPropostaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A923ContratoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Contrato Proposta Id'.", "ForeignKeyNotFound", 1, "CONTRATOPROPOSTAID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0X36( )
      {
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A227ContratoId )
      {
         /* Using cursor T000X14 */
         pr_default.execute(7, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A483AssinaturaUltId_F = T000X14_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = T000X14_n483AssinaturaUltId_F[0];
         }
         else
         {
            A483AssinaturaUltId_F = 0;
            n483AssinaturaUltId_F = false;
            AssignAttri("", false, "A483AssinaturaUltId_F", StringUtil.LTrimStr( (decimal)(A483AssinaturaUltId_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A483AssinaturaUltId_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_13( int A227ContratoId ,
                                int A473ContratoClienteId )
      {
         /* Using cursor T000X16 */
         pr_default.execute(8, new Object[] {n227ContratoId, A227ContratoId, n473ContratoClienteId, A473ContratoClienteId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A1007ContratoCountAssinantes_F = T000X16_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = T000X16_n1007ContratoCountAssinantes_F[0];
         }
         else
         {
            A1007ContratoCountAssinantes_F = 0;
            n1007ContratoCountAssinantes_F = false;
            AssignAttri("", false, "A1007ContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(A1007ContratoCountAssinantes_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1007ContratoCountAssinantes_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_10( int A473ContratoClienteId )
      {
         /* Using cursor T000X17 */
         pr_default.execute(9, new Object[] {n473ContratoClienteId, A473ContratoClienteId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A473ContratoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Contrato Cliente'.", "ForeignKeyNotFound", 1, "CONTRATOCLIENTEID");
               AnyError = 1;
            }
         }
         A474ContratoClienteNome = T000X17_A474ContratoClienteNome[0];
         n474ContratoClienteNome = T000X17_n474ContratoClienteNome[0];
         A475ContratoClienteDocumento = T000X17_A475ContratoClienteDocumento[0];
         n475ContratoClienteDocumento = T000X17_n475ContratoClienteDocumento[0];
         A476ContratoClienteRepresentanteNome = T000X17_A476ContratoClienteRepresentanteNome[0];
         n476ContratoClienteRepresentanteNome = T000X17_n476ContratoClienteRepresentanteNome[0];
         A477ContratoClienteRepresentanteCPF = T000X17_A477ContratoClienteRepresentanteCPF[0];
         n477ContratoClienteRepresentanteCPF = T000X17_n477ContratoClienteRepresentanteCPF[0];
         A561ContratoClienteTipoPessoa = T000X17_A561ContratoClienteTipoPessoa[0];
         n561ContratoClienteTipoPessoa = T000X17_n561ContratoClienteTipoPessoa[0];
         A614ContratoClienteEnderecoCEP = T000X17_A614ContratoClienteEnderecoCEP[0];
         n614ContratoClienteEnderecoCEP = T000X17_n614ContratoClienteEnderecoCEP[0];
         A615ContratoClienteEnderecoLograodouro = T000X17_A615ContratoClienteEnderecoLograodouro[0];
         n615ContratoClienteEnderecoLograodouro = T000X17_n615ContratoClienteEnderecoLograodouro[0];
         A616ContratoClienteEnderecoNumero = T000X17_A616ContratoClienteEnderecoNumero[0];
         n616ContratoClienteEnderecoNumero = T000X17_n616ContratoClienteEnderecoNumero[0];
         A617ContratoClienteEnderecoComplemento = T000X17_A617ContratoClienteEnderecoComplemento[0];
         n617ContratoClienteEnderecoComplemento = T000X17_n617ContratoClienteEnderecoComplemento[0];
         A618ContratoClienteEnderecoBairro = T000X17_A618ContratoClienteEnderecoBairro[0];
         n618ContratoClienteEnderecoBairro = T000X17_n618ContratoClienteEnderecoBairro[0];
         A619ContratoClienteMunicipioCodigo = T000X17_A619ContratoClienteMunicipioCodigo[0];
         n619ContratoClienteMunicipioCodigo = T000X17_n619ContratoClienteMunicipioCodigo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A474ContratoClienteNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A475ContratoClienteDocumento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A476ContratoClienteRepresentanteNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A477ContratoClienteRepresentanteCPF)+"\""+","+"\""+GXUtil.EncodeJSConstant( A561ContratoClienteTipoPessoa)+"\""+","+"\""+GXUtil.EncodeJSConstant( A614ContratoClienteEnderecoCEP)+"\""+","+"\""+GXUtil.EncodeJSConstant( A615ContratoClienteEnderecoLograodouro)+"\""+","+"\""+GXUtil.EncodeJSConstant( A616ContratoClienteEnderecoNumero)+"\""+","+"\""+GXUtil.EncodeJSConstant( A617ContratoClienteEnderecoComplemento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A618ContratoClienteEnderecoBairro)+"\""+","+"\""+GXUtil.EncodeJSConstant( A619ContratoClienteMunicipioCodigo)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_11( int A923ContratoPropostaId )
      {
         /* Using cursor T000X18 */
         pr_default.execute(10, new Object[] {n923ContratoPropostaId, A923ContratoPropostaId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A923ContratoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Contrato Proposta Id'.", "ForeignKeyNotFound", 1, "CONTRATOPROPOSTAID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0X36( )
      {
         /* Using cursor T000X19 */
         pr_default.execute(11, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000X3 */
         pr_default.execute(1, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X36( 9) ;
            RcdFound36 = 1;
            A227ContratoId = T000X3_A227ContratoId[0];
            n227ContratoId = T000X3_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
            A228ContratoNome = T000X3_A228ContratoNome[0];
            n228ContratoNome = T000X3_n228ContratoNome[0];
            AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
            A339ContratoCorpo = T000X3_A339ContratoCorpo[0];
            n339ContratoCorpo = T000X3_n339ContratoCorpo[0];
            A361ContratoComVigencia = T000X3_A361ContratoComVigencia[0];
            n361ContratoComVigencia = T000X3_n361ContratoComVigencia[0];
            A362ContratoDataInicial = T000X3_A362ContratoDataInicial[0];
            n362ContratoDataInicial = T000X3_n362ContratoDataInicial[0];
            A363ContratoDataFinal = T000X3_A363ContratoDataFinal[0];
            n363ContratoDataFinal = T000X3_n363ContratoDataFinal[0];
            A460ContratoTaxa = T000X3_A460ContratoTaxa[0];
            n460ContratoTaxa = T000X3_n460ContratoTaxa[0];
            A461ContratoSLA = T000X3_A461ContratoSLA[0];
            n461ContratoSLA = T000X3_n461ContratoSLA[0];
            A462ContratoJurosMora = T000X3_A462ContratoJurosMora[0];
            n462ContratoJurosMora = T000X3_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = T000X3_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = T000X3_n463ContratoIOFMinimo[0];
            A471ContratoSituacao = T000X3_A471ContratoSituacao[0];
            n471ContratoSituacao = T000X3_n471ContratoSituacao[0];
            A473ContratoClienteId = T000X3_A473ContratoClienteId[0];
            n473ContratoClienteId = T000X3_n473ContratoClienteId[0];
            A923ContratoPropostaId = T000X3_A923ContratoPropostaId[0];
            n923ContratoPropostaId = T000X3_n923ContratoPropostaId[0];
            A472ContratoBlob = T000X3_A472ContratoBlob[0];
            n472ContratoBlob = T000X3_n472ContratoBlob[0];
            Z227ContratoId = A227ContratoId;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0X36( ) ;
            if ( AnyError == 1 )
            {
               RcdFound36 = 0;
               InitializeNonKey0X36( ) ;
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0X36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X36( ) ;
         if ( RcdFound36 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound36 = 0;
         /* Using cursor T000X20 */
         pr_default.execute(12, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000X20_A227ContratoId[0] < A227ContratoId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000X20_A227ContratoId[0] > A227ContratoId ) ) )
            {
               A227ContratoId = T000X20_A227ContratoId[0];
               n227ContratoId = T000X20_n227ContratoId[0];
               AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
               RcdFound36 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound36 = 0;
         /* Using cursor T000X21 */
         pr_default.execute(13, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000X21_A227ContratoId[0] > A227ContratoId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000X21_A227ContratoId[0] < A227ContratoId ) ) )
            {
               A227ContratoId = T000X21_A227ContratoId[0];
               n227ContratoId = T000X21_n227ContratoId[0];
               AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
               RcdFound36 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0X36( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtContratoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0X36( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound36 == 1 )
            {
               if ( A227ContratoId != Z227ContratoId )
               {
                  A227ContratoId = Z227ContratoId;
                  n227ContratoId = false;
                  AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONTRATOID");
                  AnyError = 1;
                  GX_FocusControl = edtContratoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtContratoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0X36( ) ;
                  GX_FocusControl = edtContratoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A227ContratoId != Z227ContratoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtContratoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0X36( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONTRATOID");
                     AnyError = 1;
                     GX_FocusControl = edtContratoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtContratoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0X36( ) ;
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
         if ( A227ContratoId != Z227ContratoId )
         {
            A227ContratoId = Z227ContratoId;
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONTRATOID");
            AnyError = 1;
            GX_FocusControl = edtContratoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtContratoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0X36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X2 */
            pr_default.execute(0, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Contrato"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z228ContratoNome, T000X2_A228ContratoNome[0]) != 0 ) || ( Z361ContratoComVigencia != T000X2_A361ContratoComVigencia[0] ) || ( DateTimeUtil.ResetTime ( Z362ContratoDataInicial ) != DateTimeUtil.ResetTime ( T000X2_A362ContratoDataInicial[0] ) ) || ( DateTimeUtil.ResetTime ( Z363ContratoDataFinal ) != DateTimeUtil.ResetTime ( T000X2_A363ContratoDataFinal[0] ) ) || ( Z460ContratoTaxa != T000X2_A460ContratoTaxa[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z461ContratoSLA != T000X2_A461ContratoSLA[0] ) || ( Z462ContratoJurosMora != T000X2_A462ContratoJurosMora[0] ) || ( Z463ContratoIOFMinimo != T000X2_A463ContratoIOFMinimo[0] ) || ( StringUtil.StrCmp(Z471ContratoSituacao, T000X2_A471ContratoSituacao[0]) != 0 ) || ( Z473ContratoClienteId != T000X2_A473ContratoClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z923ContratoPropostaId != T000X2_A923ContratoPropostaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z228ContratoNome, T000X2_A228ContratoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoNome");
                  GXUtil.WriteLogRaw("Old: ",Z228ContratoNome);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A228ContratoNome[0]);
               }
               if ( Z361ContratoComVigencia != T000X2_A361ContratoComVigencia[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoComVigencia");
                  GXUtil.WriteLogRaw("Old: ",Z361ContratoComVigencia);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A361ContratoComVigencia[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z362ContratoDataInicial ) != DateTimeUtil.ResetTime ( T000X2_A362ContratoDataInicial[0] ) )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoDataInicial");
                  GXUtil.WriteLogRaw("Old: ",Z362ContratoDataInicial);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A362ContratoDataInicial[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z363ContratoDataFinal ) != DateTimeUtil.ResetTime ( T000X2_A363ContratoDataFinal[0] ) )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoDataFinal");
                  GXUtil.WriteLogRaw("Old: ",Z363ContratoDataFinal);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A363ContratoDataFinal[0]);
               }
               if ( Z460ContratoTaxa != T000X2_A460ContratoTaxa[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoTaxa");
                  GXUtil.WriteLogRaw("Old: ",Z460ContratoTaxa);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A460ContratoTaxa[0]);
               }
               if ( Z461ContratoSLA != T000X2_A461ContratoSLA[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoSLA");
                  GXUtil.WriteLogRaw("Old: ",Z461ContratoSLA);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A461ContratoSLA[0]);
               }
               if ( Z462ContratoJurosMora != T000X2_A462ContratoJurosMora[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoJurosMora");
                  GXUtil.WriteLogRaw("Old: ",Z462ContratoJurosMora);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A462ContratoJurosMora[0]);
               }
               if ( Z463ContratoIOFMinimo != T000X2_A463ContratoIOFMinimo[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoIOFMinimo");
                  GXUtil.WriteLogRaw("Old: ",Z463ContratoIOFMinimo);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A463ContratoIOFMinimo[0]);
               }
               if ( StringUtil.StrCmp(Z471ContratoSituacao, T000X2_A471ContratoSituacao[0]) != 0 )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoSituacao");
                  GXUtil.WriteLogRaw("Old: ",Z471ContratoSituacao);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A471ContratoSituacao[0]);
               }
               if ( Z473ContratoClienteId != T000X2_A473ContratoClienteId[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z473ContratoClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A473ContratoClienteId[0]);
               }
               if ( Z923ContratoPropostaId != T000X2_A923ContratoPropostaId[0] )
               {
                  GXUtil.WriteLog("contrato:[seudo value changed for attri]"+"ContratoPropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z923ContratoPropostaId);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A923ContratoPropostaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Contrato"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X36( 0) ;
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X22 */
                     pr_default.execute(14, new Object[] {n228ContratoNome, A228ContratoNome, n339ContratoCorpo, A339ContratoCorpo, n361ContratoComVigencia, A361ContratoComVigencia, n362ContratoDataInicial, A362ContratoDataInicial, n363ContratoDataFinal, A363ContratoDataFinal, n460ContratoTaxa, A460ContratoTaxa, n461ContratoSLA, A461ContratoSLA, n462ContratoJurosMora, A462ContratoJurosMora, n463ContratoIOFMinimo, A463ContratoIOFMinimo, n471ContratoSituacao, A471ContratoSituacao, n472ContratoBlob, A472ContratoBlob, n473ContratoClienteId, A473ContratoClienteId, n923ContratoPropostaId, A923ContratoPropostaId});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000X23 */
                     pr_default.execute(15);
                     A227ContratoId = T000X23_A227ContratoId[0];
                     n227ContratoId = T000X23_n227ContratoId[0];
                     AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Contrato");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0X0( ) ;
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
               Load0X36( ) ;
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void Update0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X24 */
                     pr_default.execute(16, new Object[] {n228ContratoNome, A228ContratoNome, n339ContratoCorpo, A339ContratoCorpo, n361ContratoComVigencia, A361ContratoComVigencia, n362ContratoDataInicial, A362ContratoDataInicial, n363ContratoDataFinal, A363ContratoDataFinal, n460ContratoTaxa, A460ContratoTaxa, n461ContratoSLA, A461ContratoSLA, n462ContratoJurosMora, A462ContratoJurosMora, n463ContratoIOFMinimo, A463ContratoIOFMinimo, n471ContratoSituacao, A471ContratoSituacao, n473ContratoClienteId, A473ContratoClienteId, n923ContratoPropostaId, A923ContratoPropostaId, n227ContratoId, A227ContratoId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Contrato");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Contrato"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X36( ) ;
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
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void DeferredUpdate0X36( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000X25 */
            pr_default.execute(17, new Object[] {n472ContratoBlob, A472ContratoBlob, n227ContratoId, A227ContratoId});
            pr_default.close(17);
            pr_default.SmartCacheProvider.SetUpdated("Contrato");
         }
      }

      protected void delete( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X36( ) ;
            AfterConfirm0X36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000X26 */
                  pr_default.execute(18, new Object[] {n227ContratoId, A227ContratoId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("Contrato");
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
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X36( ) ;
         Gx_mode = sMode36;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X36( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000X28 */
            pr_default.execute(19, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A483AssinaturaUltId_F = T000X28_A483AssinaturaUltId_F[0];
               n483AssinaturaUltId_F = T000X28_n483AssinaturaUltId_F[0];
            }
            else
            {
               A483AssinaturaUltId_F = 0;
               n483AssinaturaUltId_F = false;
               AssignAttri("", false, "A483AssinaturaUltId_F", StringUtil.LTrimStr( (decimal)(A483AssinaturaUltId_F), 4, 0));
            }
            pr_default.close(19);
            /* Using cursor T000X29 */
            pr_default.execute(20, new Object[] {n473ContratoClienteId, A473ContratoClienteId});
            A474ContratoClienteNome = T000X29_A474ContratoClienteNome[0];
            n474ContratoClienteNome = T000X29_n474ContratoClienteNome[0];
            A475ContratoClienteDocumento = T000X29_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = T000X29_n475ContratoClienteDocumento[0];
            A476ContratoClienteRepresentanteNome = T000X29_A476ContratoClienteRepresentanteNome[0];
            n476ContratoClienteRepresentanteNome = T000X29_n476ContratoClienteRepresentanteNome[0];
            A477ContratoClienteRepresentanteCPF = T000X29_A477ContratoClienteRepresentanteCPF[0];
            n477ContratoClienteRepresentanteCPF = T000X29_n477ContratoClienteRepresentanteCPF[0];
            A561ContratoClienteTipoPessoa = T000X29_A561ContratoClienteTipoPessoa[0];
            n561ContratoClienteTipoPessoa = T000X29_n561ContratoClienteTipoPessoa[0];
            A614ContratoClienteEnderecoCEP = T000X29_A614ContratoClienteEnderecoCEP[0];
            n614ContratoClienteEnderecoCEP = T000X29_n614ContratoClienteEnderecoCEP[0];
            A615ContratoClienteEnderecoLograodouro = T000X29_A615ContratoClienteEnderecoLograodouro[0];
            n615ContratoClienteEnderecoLograodouro = T000X29_n615ContratoClienteEnderecoLograodouro[0];
            A616ContratoClienteEnderecoNumero = T000X29_A616ContratoClienteEnderecoNumero[0];
            n616ContratoClienteEnderecoNumero = T000X29_n616ContratoClienteEnderecoNumero[0];
            A617ContratoClienteEnderecoComplemento = T000X29_A617ContratoClienteEnderecoComplemento[0];
            n617ContratoClienteEnderecoComplemento = T000X29_n617ContratoClienteEnderecoComplemento[0];
            A618ContratoClienteEnderecoBairro = T000X29_A618ContratoClienteEnderecoBairro[0];
            n618ContratoClienteEnderecoBairro = T000X29_n618ContratoClienteEnderecoBairro[0];
            A619ContratoClienteMunicipioCodigo = T000X29_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = T000X29_n619ContratoClienteMunicipioCodigo[0];
            pr_default.close(20);
            /* Using cursor T000X31 */
            pr_default.execute(21, new Object[] {n227ContratoId, A227ContratoId, n473ContratoClienteId, A473ContratoClienteId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               A1007ContratoCountAssinantes_F = T000X31_A1007ContratoCountAssinantes_F[0];
               n1007ContratoCountAssinantes_F = T000X31_n1007ContratoCountAssinantes_F[0];
            }
            else
            {
               A1007ContratoCountAssinantes_F = 0;
               n1007ContratoCountAssinantes_F = false;
               AssignAttri("", false, "A1007ContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(A1007ContratoCountAssinantes_F), 4, 0));
            }
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000X32 */
            pr_default.execute(22, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000X33 */
            pr_default.execute(23, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operacoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000X34 */
            pr_default.execute(24, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000X35 */
            pr_default.execute(25, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Assinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000X36 */
            pr_default.execute(26, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato Participante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void EndLevel0X36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues0X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0X36( )
      {
         /* Scan By routine */
         /* Using cursor T000X37 */
         pr_default.execute(27);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound36 = 1;
            A227ContratoId = T000X37_A227ContratoId[0];
            n227ContratoId = T000X37_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X36( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound36 = 1;
            A227ContratoId = T000X37_A227ContratoId[0];
            n227ContratoId = T000X37_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
         }
      }

      protected void ScanEnd0X36( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm0X36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X36( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X36( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X36( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X36( )
      {
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         edtContratoNome_Enabled = 0;
         AssignProp("", false, edtContratoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0X36( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0X0( )
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
         GXEncryptionTmp = "contrato"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ContratoId,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("contrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Contrato");
         forbiddenHiddens.Add("ContratoId", context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContratoClienteId", context.localUtil.Format( (decimal)(AV14Insert_ContratoClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContratoPropostaId", context.localUtil.Format( (decimal)(AV15Insert_ContratoPropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ContratoComVigencia", StringUtil.BoolToStr( A361ContratoComVigencia));
         forbiddenHiddens.Add("ContratoDataInicial", context.localUtil.Format(A362ContratoDataInicial, "99/99/99"));
         forbiddenHiddens.Add("ContratoDataFinal", context.localUtil.Format(A363ContratoDataFinal, "99/99/99"));
         forbiddenHiddens.Add("ContratoTaxa", context.localUtil.Format( A460ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("ContratoSLA", context.localUtil.Format( (decimal)(A461ContratoSLA), "ZZZ9"));
         forbiddenHiddens.Add("ContratoJurosMora", context.localUtil.Format( A462ContratoJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("ContratoIOFMinimo", context.localUtil.Format( A463ContratoIOFMinimo, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("ContratoSituacao", StringUtil.RTrim( context.localUtil.Format( A471ContratoSituacao, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contrato:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z228ContratoNome", Z228ContratoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z361ContratoComVigencia", Z361ContratoComVigencia);
         GxWebStd.gx_hidden_field( context, "Z362ContratoDataInicial", context.localUtil.DToC( Z362ContratoDataInicial, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z363ContratoDataFinal", context.localUtil.DToC( Z363ContratoDataFinal, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z460ContratoTaxa", StringUtil.LTrim( StringUtil.NToC( Z460ContratoTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z461ContratoSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z461ContratoSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z462ContratoJurosMora", StringUtil.LTrim( StringUtil.NToC( Z462ContratoJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z463ContratoIOFMinimo", StringUtil.LTrim( StringUtil.NToC( Z463ContratoIOFMinimo, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z471ContratoSituacao", Z471ContratoSituacao);
         GxWebStd.gx_hidden_field( context, "Z473ContratoClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z473ContratoClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z923ContratoPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z923ContratoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N473ContratoClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N923ContratoPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTRATOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_ContratoClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTRATOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_ContratoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO", A339ContratoCorpo);
         GxWebStd.gx_boolean_hidden_field( context, "CONTRATOCOMVIGENCIA", A361ContratoComVigencia);
         GxWebStd.gx_hidden_field( context, "CONTRATODATAINICIAL", context.localUtil.DToC( A362ContratoDataInicial, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CONTRATODATAFINAL", context.localUtil.DToC( A363ContratoDataFinal, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CONTRATOTAXA", StringUtil.LTrim( StringUtil.NToC( A460ContratoTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A461ContratoSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOJUROSMORA", StringUtil.LTrim( StringUtil.NToC( A462ContratoJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOIOFMINIMO", StringUtil.LTrim( StringUtil.NToC( A463ContratoIOFMinimo, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOSITUACAO", A471ContratoSituacao);
         GxWebStd.gx_hidden_field( context, "CONTRATOBLOB", A472ContratoBlob);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTENOME", A474ContratoClienteNome);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEDOCUMENTO", A475ContratoClienteDocumento);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEREPRESENTANTENOME", A476ContratoClienteRepresentanteNome);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEREPRESENTANTECPF", A477ContratoClienteRepresentanteCPF);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTETIPOPESSOA", A561ContratoClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEENDERECOCEP", A614ContratoClienteEnderecoCEP);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEENDERECOLOGRAODOURO", A615ContratoClienteEnderecoLograodouro);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEENDERECONUMERO", A616ContratoClienteEnderecoNumero);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEENDERECOCOMPLEMENTO", A617ContratoClienteEnderecoComplemento);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEENDERECOBAIRRO", A618ContratoClienteEnderecoBairro);
         GxWebStd.gx_hidden_field( context, "CONTRATOCLIENTEMUNICIPIOCODIGO", A619ContratoClienteMunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "ASSINATURAULTID_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A483AssinaturaUltId_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOCOUNTASSINANTES_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1007ContratoCountAssinantes_F), 4, 0, ",", "")));
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
         GXEncryptionTmp = "contrato"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ContratoId,6,0));
         return formatLink("contrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contrato" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contrato" ;
      }

      protected void InitializeNonKey0X36( )
      {
         A473ContratoClienteId = 0;
         n473ContratoClienteId = false;
         AssignAttri("", false, "A473ContratoClienteId", ((0==A473ContratoClienteId)&&IsIns( )||n473ContratoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ".", ""))));
         A923ContratoPropostaId = 0;
         n923ContratoPropostaId = false;
         AssignAttri("", false, "A923ContratoPropostaId", ((0==A923ContratoPropostaId)&&IsIns( )||n923ContratoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A923ContratoPropostaId), 9, 0, ".", ""))));
         A228ContratoNome = "";
         n228ContratoNome = false;
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         n228ContratoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? true : false);
         A339ContratoCorpo = "";
         n339ContratoCorpo = false;
         AssignAttri("", false, "A339ContratoCorpo", A339ContratoCorpo);
         A361ContratoComVigencia = false;
         n361ContratoComVigencia = false;
         AssignAttri("", false, "A361ContratoComVigencia", A361ContratoComVigencia);
         A362ContratoDataInicial = DateTime.MinValue;
         n362ContratoDataInicial = false;
         AssignAttri("", false, "A362ContratoDataInicial", context.localUtil.Format(A362ContratoDataInicial, "99/99/99"));
         A363ContratoDataFinal = DateTime.MinValue;
         n363ContratoDataFinal = false;
         AssignAttri("", false, "A363ContratoDataFinal", context.localUtil.Format(A363ContratoDataFinal, "99/99/99"));
         A474ContratoClienteNome = "";
         n474ContratoClienteNome = false;
         AssignAttri("", false, "A474ContratoClienteNome", A474ContratoClienteNome);
         A475ContratoClienteDocumento = "";
         n475ContratoClienteDocumento = false;
         AssignAttri("", false, "A475ContratoClienteDocumento", A475ContratoClienteDocumento);
         A476ContratoClienteRepresentanteNome = "";
         n476ContratoClienteRepresentanteNome = false;
         AssignAttri("", false, "A476ContratoClienteRepresentanteNome", A476ContratoClienteRepresentanteNome);
         A477ContratoClienteRepresentanteCPF = "";
         n477ContratoClienteRepresentanteCPF = false;
         AssignAttri("", false, "A477ContratoClienteRepresentanteCPF", A477ContratoClienteRepresentanteCPF);
         A561ContratoClienteTipoPessoa = "";
         n561ContratoClienteTipoPessoa = false;
         AssignAttri("", false, "A561ContratoClienteTipoPessoa", A561ContratoClienteTipoPessoa);
         A460ContratoTaxa = 0;
         n460ContratoTaxa = false;
         AssignAttri("", false, "A460ContratoTaxa", ((Convert.ToDecimal(0)==A460ContratoTaxa)&&IsIns( )||n460ContratoTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A460ContratoTaxa, 16, 4, ".", ""))));
         A461ContratoSLA = 0;
         n461ContratoSLA = false;
         AssignAttri("", false, "A461ContratoSLA", ((0==A461ContratoSLA)&&IsIns( )||n461ContratoSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A461ContratoSLA), 4, 0, ".", ""))));
         A462ContratoJurosMora = 0;
         n462ContratoJurosMora = false;
         AssignAttri("", false, "A462ContratoJurosMora", ((Convert.ToDecimal(0)==A462ContratoJurosMora)&&IsIns( )||n462ContratoJurosMora ? "" : StringUtil.LTrim( StringUtil.NToC( A462ContratoJurosMora, 16, 4, ".", ""))));
         A463ContratoIOFMinimo = 0;
         n463ContratoIOFMinimo = false;
         AssignAttri("", false, "A463ContratoIOFMinimo", ((Convert.ToDecimal(0)==A463ContratoIOFMinimo)&&IsIns( )||n463ContratoIOFMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A463ContratoIOFMinimo, 16, 4, ".", ""))));
         A471ContratoSituacao = "";
         n471ContratoSituacao = false;
         AssignAttri("", false, "A471ContratoSituacao", A471ContratoSituacao);
         A472ContratoBlob = "";
         n472ContratoBlob = false;
         AssignAttri("", false, "A472ContratoBlob", A472ContratoBlob);
         A483AssinaturaUltId_F = 0;
         n483AssinaturaUltId_F = false;
         AssignAttri("", false, "A483AssinaturaUltId_F", StringUtil.LTrimStr( (decimal)(A483AssinaturaUltId_F), 4, 0));
         A614ContratoClienteEnderecoCEP = "";
         n614ContratoClienteEnderecoCEP = false;
         AssignAttri("", false, "A614ContratoClienteEnderecoCEP", A614ContratoClienteEnderecoCEP);
         A615ContratoClienteEnderecoLograodouro = "";
         n615ContratoClienteEnderecoLograodouro = false;
         AssignAttri("", false, "A615ContratoClienteEnderecoLograodouro", A615ContratoClienteEnderecoLograodouro);
         A616ContratoClienteEnderecoNumero = "";
         n616ContratoClienteEnderecoNumero = false;
         AssignAttri("", false, "A616ContratoClienteEnderecoNumero", A616ContratoClienteEnderecoNumero);
         A617ContratoClienteEnderecoComplemento = "";
         n617ContratoClienteEnderecoComplemento = false;
         AssignAttri("", false, "A617ContratoClienteEnderecoComplemento", A617ContratoClienteEnderecoComplemento);
         A618ContratoClienteEnderecoBairro = "";
         n618ContratoClienteEnderecoBairro = false;
         AssignAttri("", false, "A618ContratoClienteEnderecoBairro", A618ContratoClienteEnderecoBairro);
         A619ContratoClienteMunicipioCodigo = "";
         n619ContratoClienteMunicipioCodigo = false;
         AssignAttri("", false, "A619ContratoClienteMunicipioCodigo", A619ContratoClienteMunicipioCodigo);
         A1007ContratoCountAssinantes_F = 0;
         n1007ContratoCountAssinantes_F = false;
         AssignAttri("", false, "A1007ContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(A1007ContratoCountAssinantes_F), 4, 0));
         Z228ContratoNome = "";
         Z361ContratoComVigencia = false;
         Z362ContratoDataInicial = DateTime.MinValue;
         Z363ContratoDataFinal = DateTime.MinValue;
         Z460ContratoTaxa = 0;
         Z461ContratoSLA = 0;
         Z462ContratoJurosMora = 0;
         Z463ContratoIOFMinimo = 0;
         Z471ContratoSituacao = "";
         Z473ContratoClienteId = 0;
         Z923ContratoPropostaId = 0;
      }

      protected void InitAll0X36( )
      {
         A227ContratoId = 0;
         n227ContratoId = false;
         AssignAttri("", false, "A227ContratoId", StringUtil.LTrimStr( (decimal)(A227ContratoId), 6, 0));
         InitializeNonKey0X36( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019135392", true, true);
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
         context.AddJavascriptSource("contrato.js", "?202561019135393", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtContratoId_Internalname = "CONTRATOID";
         edtContratoNome_Internalname = "CONTRATONOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Contrato";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtContratoNome_Jsonclick = "";
         edtContratoNome_Enabled = 1;
         edtContratoId_Jsonclick = "";
         edtContratoId_Enabled = 0;
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

      public void Valid_Contratoid( )
      {
         n227ContratoId = false;
         n483AssinaturaUltId_F = false;
         /* Using cursor T000X28 */
         pr_default.execute(19, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A483AssinaturaUltId_F = T000X28_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = T000X28_n483AssinaturaUltId_F[0];
         }
         else
         {
            A483AssinaturaUltId_F = 0;
            n483AssinaturaUltId_F = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A483AssinaturaUltId_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A483AssinaturaUltId_F), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"AV14Insert_ContratoClienteId","fld":"vINSERT_CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15Insert_ContratoPropostaId","fld":"vINSERT_CONTRATOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A361ContratoComVigencia","fld":"CONTRATOCOMVIGENCIA","type":"boolean"},{"av":"A362ContratoDataInicial","fld":"CONTRATODATAINICIAL","type":"date"},{"av":"A363ContratoDataFinal","fld":"CONTRATODATAFINAL","type":"date"},{"av":"A460ContratoTaxa","fld":"CONTRATOTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n460ContratoTaxa","type":"decimal"},{"av":"A461ContratoSLA","fld":"CONTRATOSLA","pic":"ZZZ9","nullAv":"n461ContratoSLA","type":"int"},{"av":"A462ContratoJurosMora","fld":"CONTRATOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n462ContratoJurosMora","type":"decimal"},{"av":"A463ContratoIOFMinimo","fld":"CONTRATOIOFMINIMO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n463ContratoIOFMinimo","type":"decimal"},{"av":"A471ContratoSituacao","fld":"CONTRATOSITUACAO","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120X2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n473ContratoClienteId","type":"int"}]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"A483AssinaturaUltId_F","fld":"ASSINATURAULTID_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_CONTRATOID",""","oparms":[{"av":"A483AssinaturaUltId_F","fld":"ASSINATURAULTID_F","pic":"ZZZ9","type":"int"}]}""");
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
         pr_default.close(20);
         pr_default.close(19);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z228ContratoNome = "";
         Z362ContratoDataInicial = DateTime.MinValue;
         Z363ContratoDataFinal = DateTime.MinValue;
         Z471ContratoSituacao = "";
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
         A228ContratoNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A362ContratoDataInicial = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         A471ContratoSituacao = "";
         A339ContratoCorpo = "";
         A472ContratoBlob = "";
         A474ContratoClienteNome = "";
         A475ContratoClienteDocumento = "";
         A476ContratoClienteRepresentanteNome = "";
         A477ContratoClienteRepresentanteCPF = "";
         A561ContratoClienteTipoPessoa = "";
         A614ContratoClienteEnderecoCEP = "";
         A615ContratoClienteEnderecoLograodouro = "";
         A616ContratoClienteEnderecoNumero = "";
         A617ContratoClienteEnderecoComplemento = "";
         A618ContratoClienteEnderecoBairro = "";
         A619ContratoClienteMunicipioCodigo = "";
         AV16Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode36 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXEncryptionTmp = "";
         Z339ContratoCorpo = "";
         Z472ContratoBlob = "";
         Z474ContratoClienteNome = "";
         Z475ContratoClienteDocumento = "";
         Z476ContratoClienteRepresentanteNome = "";
         Z477ContratoClienteRepresentanteCPF = "";
         Z561ContratoClienteTipoPessoa = "";
         Z614ContratoClienteEnderecoCEP = "";
         Z615ContratoClienteEnderecoLograodouro = "";
         Z616ContratoClienteEnderecoNumero = "";
         Z617ContratoClienteEnderecoComplemento = "";
         Z618ContratoClienteEnderecoBairro = "";
         Z619ContratoClienteMunicipioCodigo = "";
         T000X7_A483AssinaturaUltId_F = new short[1] ;
         T000X7_n483AssinaturaUltId_F = new bool[] {false} ;
         T000X12_A227ContratoId = new int[1] ;
         T000X12_n227ContratoId = new bool[] {false} ;
         T000X12_A228ContratoNome = new string[] {""} ;
         T000X12_n228ContratoNome = new bool[] {false} ;
         T000X12_A339ContratoCorpo = new string[] {""} ;
         T000X12_n339ContratoCorpo = new bool[] {false} ;
         T000X12_A361ContratoComVigencia = new bool[] {false} ;
         T000X12_n361ContratoComVigencia = new bool[] {false} ;
         T000X12_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T000X12_n362ContratoDataInicial = new bool[] {false} ;
         T000X12_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T000X12_n363ContratoDataFinal = new bool[] {false} ;
         T000X12_A474ContratoClienteNome = new string[] {""} ;
         T000X12_n474ContratoClienteNome = new bool[] {false} ;
         T000X12_A475ContratoClienteDocumento = new string[] {""} ;
         T000X12_n475ContratoClienteDocumento = new bool[] {false} ;
         T000X12_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         T000X12_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         T000X12_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         T000X12_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         T000X12_A561ContratoClienteTipoPessoa = new string[] {""} ;
         T000X12_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         T000X12_A460ContratoTaxa = new decimal[1] ;
         T000X12_n460ContratoTaxa = new bool[] {false} ;
         T000X12_A461ContratoSLA = new short[1] ;
         T000X12_n461ContratoSLA = new bool[] {false} ;
         T000X12_A462ContratoJurosMora = new decimal[1] ;
         T000X12_n462ContratoJurosMora = new bool[] {false} ;
         T000X12_A463ContratoIOFMinimo = new decimal[1] ;
         T000X12_n463ContratoIOFMinimo = new bool[] {false} ;
         T000X12_A471ContratoSituacao = new string[] {""} ;
         T000X12_n471ContratoSituacao = new bool[] {false} ;
         T000X12_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         T000X12_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         T000X12_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         T000X12_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         T000X12_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         T000X12_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         T000X12_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         T000X12_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         T000X12_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         T000X12_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         T000X12_A473ContratoClienteId = new int[1] ;
         T000X12_n473ContratoClienteId = new bool[] {false} ;
         T000X12_A923ContratoPropostaId = new int[1] ;
         T000X12_n923ContratoPropostaId = new bool[] {false} ;
         T000X12_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         T000X12_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         T000X12_A483AssinaturaUltId_F = new short[1] ;
         T000X12_n483AssinaturaUltId_F = new bool[] {false} ;
         T000X12_A1007ContratoCountAssinantes_F = new short[1] ;
         T000X12_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         T000X12_A472ContratoBlob = new string[] {""} ;
         T000X12_n472ContratoBlob = new bool[] {false} ;
         T000X9_A1007ContratoCountAssinantes_F = new short[1] ;
         T000X9_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         T000X4_A474ContratoClienteNome = new string[] {""} ;
         T000X4_n474ContratoClienteNome = new bool[] {false} ;
         T000X4_A475ContratoClienteDocumento = new string[] {""} ;
         T000X4_n475ContratoClienteDocumento = new bool[] {false} ;
         T000X4_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         T000X4_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         T000X4_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         T000X4_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         T000X4_A561ContratoClienteTipoPessoa = new string[] {""} ;
         T000X4_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         T000X4_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         T000X4_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         T000X4_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         T000X4_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         T000X4_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         T000X4_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         T000X4_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         T000X4_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         T000X4_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         T000X4_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         T000X4_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         T000X4_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         T000X5_A923ContratoPropostaId = new int[1] ;
         T000X5_n923ContratoPropostaId = new bool[] {false} ;
         T000X14_A483AssinaturaUltId_F = new short[1] ;
         T000X14_n483AssinaturaUltId_F = new bool[] {false} ;
         T000X16_A1007ContratoCountAssinantes_F = new short[1] ;
         T000X16_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         T000X17_A474ContratoClienteNome = new string[] {""} ;
         T000X17_n474ContratoClienteNome = new bool[] {false} ;
         T000X17_A475ContratoClienteDocumento = new string[] {""} ;
         T000X17_n475ContratoClienteDocumento = new bool[] {false} ;
         T000X17_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         T000X17_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         T000X17_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         T000X17_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         T000X17_A561ContratoClienteTipoPessoa = new string[] {""} ;
         T000X17_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         T000X17_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         T000X17_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         T000X17_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         T000X17_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         T000X17_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         T000X17_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         T000X17_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         T000X17_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         T000X17_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         T000X17_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         T000X17_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         T000X17_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         T000X18_A923ContratoPropostaId = new int[1] ;
         T000X18_n923ContratoPropostaId = new bool[] {false} ;
         T000X19_A227ContratoId = new int[1] ;
         T000X19_n227ContratoId = new bool[] {false} ;
         T000X3_A227ContratoId = new int[1] ;
         T000X3_n227ContratoId = new bool[] {false} ;
         T000X3_A228ContratoNome = new string[] {""} ;
         T000X3_n228ContratoNome = new bool[] {false} ;
         T000X3_A339ContratoCorpo = new string[] {""} ;
         T000X3_n339ContratoCorpo = new bool[] {false} ;
         T000X3_A361ContratoComVigencia = new bool[] {false} ;
         T000X3_n361ContratoComVigencia = new bool[] {false} ;
         T000X3_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T000X3_n362ContratoDataInicial = new bool[] {false} ;
         T000X3_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T000X3_n363ContratoDataFinal = new bool[] {false} ;
         T000X3_A460ContratoTaxa = new decimal[1] ;
         T000X3_n460ContratoTaxa = new bool[] {false} ;
         T000X3_A461ContratoSLA = new short[1] ;
         T000X3_n461ContratoSLA = new bool[] {false} ;
         T000X3_A462ContratoJurosMora = new decimal[1] ;
         T000X3_n462ContratoJurosMora = new bool[] {false} ;
         T000X3_A463ContratoIOFMinimo = new decimal[1] ;
         T000X3_n463ContratoIOFMinimo = new bool[] {false} ;
         T000X3_A471ContratoSituacao = new string[] {""} ;
         T000X3_n471ContratoSituacao = new bool[] {false} ;
         T000X3_A473ContratoClienteId = new int[1] ;
         T000X3_n473ContratoClienteId = new bool[] {false} ;
         T000X3_A923ContratoPropostaId = new int[1] ;
         T000X3_n923ContratoPropostaId = new bool[] {false} ;
         T000X3_A472ContratoBlob = new string[] {""} ;
         T000X3_n472ContratoBlob = new bool[] {false} ;
         T000X20_A227ContratoId = new int[1] ;
         T000X20_n227ContratoId = new bool[] {false} ;
         T000X21_A227ContratoId = new int[1] ;
         T000X21_n227ContratoId = new bool[] {false} ;
         T000X2_A227ContratoId = new int[1] ;
         T000X2_n227ContratoId = new bool[] {false} ;
         T000X2_A228ContratoNome = new string[] {""} ;
         T000X2_n228ContratoNome = new bool[] {false} ;
         T000X2_A339ContratoCorpo = new string[] {""} ;
         T000X2_n339ContratoCorpo = new bool[] {false} ;
         T000X2_A361ContratoComVigencia = new bool[] {false} ;
         T000X2_n361ContratoComVigencia = new bool[] {false} ;
         T000X2_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T000X2_n362ContratoDataInicial = new bool[] {false} ;
         T000X2_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T000X2_n363ContratoDataFinal = new bool[] {false} ;
         T000X2_A460ContratoTaxa = new decimal[1] ;
         T000X2_n460ContratoTaxa = new bool[] {false} ;
         T000X2_A461ContratoSLA = new short[1] ;
         T000X2_n461ContratoSLA = new bool[] {false} ;
         T000X2_A462ContratoJurosMora = new decimal[1] ;
         T000X2_n462ContratoJurosMora = new bool[] {false} ;
         T000X2_A463ContratoIOFMinimo = new decimal[1] ;
         T000X2_n463ContratoIOFMinimo = new bool[] {false} ;
         T000X2_A471ContratoSituacao = new string[] {""} ;
         T000X2_n471ContratoSituacao = new bool[] {false} ;
         T000X2_A473ContratoClienteId = new int[1] ;
         T000X2_n473ContratoClienteId = new bool[] {false} ;
         T000X2_A923ContratoPropostaId = new int[1] ;
         T000X2_n923ContratoPropostaId = new bool[] {false} ;
         T000X2_A472ContratoBlob = new string[] {""} ;
         T000X2_n472ContratoBlob = new bool[] {false} ;
         T000X23_A227ContratoId = new int[1] ;
         T000X23_n227ContratoId = new bool[] {false} ;
         T000X28_A483AssinaturaUltId_F = new short[1] ;
         T000X28_n483AssinaturaUltId_F = new bool[] {false} ;
         T000X29_A474ContratoClienteNome = new string[] {""} ;
         T000X29_n474ContratoClienteNome = new bool[] {false} ;
         T000X29_A475ContratoClienteDocumento = new string[] {""} ;
         T000X29_n475ContratoClienteDocumento = new bool[] {false} ;
         T000X29_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         T000X29_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         T000X29_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         T000X29_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         T000X29_A561ContratoClienteTipoPessoa = new string[] {""} ;
         T000X29_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         T000X29_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         T000X29_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         T000X29_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         T000X29_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         T000X29_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         T000X29_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         T000X29_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         T000X29_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         T000X29_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         T000X29_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         T000X29_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         T000X29_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         T000X31_A1007ContratoCountAssinantes_F = new short[1] ;
         T000X31_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         T000X32_A572PropostaContratoAssinaturaId = new int[1] ;
         T000X33_A1010OperacoesId = new int[1] ;
         T000X34_A323PropostaId = new int[1] ;
         T000X35_A238AssinaturaId = new long[1] ;
         T000X35_n238AssinaturaId = new bool[] {false} ;
         T000X36_A237ContratoParticipanteId = new int[1] ;
         T000X37_A227ContratoId = new int[1] ;
         T000X37_n227ContratoId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contrato__default(),
            new Object[][] {
                new Object[] {
               T000X2_A227ContratoId, T000X2_A228ContratoNome, T000X2_n228ContratoNome, T000X2_A339ContratoCorpo, T000X2_n339ContratoCorpo, T000X2_A361ContratoComVigencia, T000X2_n361ContratoComVigencia, T000X2_A362ContratoDataInicial, T000X2_n362ContratoDataInicial, T000X2_A363ContratoDataFinal,
               T000X2_n363ContratoDataFinal, T000X2_A460ContratoTaxa, T000X2_n460ContratoTaxa, T000X2_A461ContratoSLA, T000X2_n461ContratoSLA, T000X2_A462ContratoJurosMora, T000X2_n462ContratoJurosMora, T000X2_A463ContratoIOFMinimo, T000X2_n463ContratoIOFMinimo, T000X2_A471ContratoSituacao,
               T000X2_n471ContratoSituacao, T000X2_A473ContratoClienteId, T000X2_n473ContratoClienteId, T000X2_A923ContratoPropostaId, T000X2_n923ContratoPropostaId, T000X2_A472ContratoBlob, T000X2_n472ContratoBlob
               }
               , new Object[] {
               T000X3_A227ContratoId, T000X3_A228ContratoNome, T000X3_n228ContratoNome, T000X3_A339ContratoCorpo, T000X3_n339ContratoCorpo, T000X3_A361ContratoComVigencia, T000X3_n361ContratoComVigencia, T000X3_A362ContratoDataInicial, T000X3_n362ContratoDataInicial, T000X3_A363ContratoDataFinal,
               T000X3_n363ContratoDataFinal, T000X3_A460ContratoTaxa, T000X3_n460ContratoTaxa, T000X3_A461ContratoSLA, T000X3_n461ContratoSLA, T000X3_A462ContratoJurosMora, T000X3_n462ContratoJurosMora, T000X3_A463ContratoIOFMinimo, T000X3_n463ContratoIOFMinimo, T000X3_A471ContratoSituacao,
               T000X3_n471ContratoSituacao, T000X3_A473ContratoClienteId, T000X3_n473ContratoClienteId, T000X3_A923ContratoPropostaId, T000X3_n923ContratoPropostaId, T000X3_A472ContratoBlob, T000X3_n472ContratoBlob
               }
               , new Object[] {
               T000X4_A474ContratoClienteNome, T000X4_n474ContratoClienteNome, T000X4_A475ContratoClienteDocumento, T000X4_n475ContratoClienteDocumento, T000X4_A476ContratoClienteRepresentanteNome, T000X4_n476ContratoClienteRepresentanteNome, T000X4_A477ContratoClienteRepresentanteCPF, T000X4_n477ContratoClienteRepresentanteCPF, T000X4_A561ContratoClienteTipoPessoa, T000X4_n561ContratoClienteTipoPessoa,
               T000X4_A614ContratoClienteEnderecoCEP, T000X4_n614ContratoClienteEnderecoCEP, T000X4_A615ContratoClienteEnderecoLograodouro, T000X4_n615ContratoClienteEnderecoLograodouro, T000X4_A616ContratoClienteEnderecoNumero, T000X4_n616ContratoClienteEnderecoNumero, T000X4_A617ContratoClienteEnderecoComplemento, T000X4_n617ContratoClienteEnderecoComplemento, T000X4_A618ContratoClienteEnderecoBairro, T000X4_n618ContratoClienteEnderecoBairro,
               T000X4_A619ContratoClienteMunicipioCodigo, T000X4_n619ContratoClienteMunicipioCodigo
               }
               , new Object[] {
               T000X5_A923ContratoPropostaId
               }
               , new Object[] {
               T000X7_A483AssinaturaUltId_F, T000X7_n483AssinaturaUltId_F
               }
               , new Object[] {
               T000X9_A1007ContratoCountAssinantes_F, T000X9_n1007ContratoCountAssinantes_F
               }
               , new Object[] {
               T000X12_A227ContratoId, T000X12_A228ContratoNome, T000X12_n228ContratoNome, T000X12_A339ContratoCorpo, T000X12_n339ContratoCorpo, T000X12_A361ContratoComVigencia, T000X12_n361ContratoComVigencia, T000X12_A362ContratoDataInicial, T000X12_n362ContratoDataInicial, T000X12_A363ContratoDataFinal,
               T000X12_n363ContratoDataFinal, T000X12_A474ContratoClienteNome, T000X12_n474ContratoClienteNome, T000X12_A475ContratoClienteDocumento, T000X12_n475ContratoClienteDocumento, T000X12_A476ContratoClienteRepresentanteNome, T000X12_n476ContratoClienteRepresentanteNome, T000X12_A477ContratoClienteRepresentanteCPF, T000X12_n477ContratoClienteRepresentanteCPF, T000X12_A561ContratoClienteTipoPessoa,
               T000X12_n561ContratoClienteTipoPessoa, T000X12_A460ContratoTaxa, T000X12_n460ContratoTaxa, T000X12_A461ContratoSLA, T000X12_n461ContratoSLA, T000X12_A462ContratoJurosMora, T000X12_n462ContratoJurosMora, T000X12_A463ContratoIOFMinimo, T000X12_n463ContratoIOFMinimo, T000X12_A471ContratoSituacao,
               T000X12_n471ContratoSituacao, T000X12_A614ContratoClienteEnderecoCEP, T000X12_n614ContratoClienteEnderecoCEP, T000X12_A615ContratoClienteEnderecoLograodouro, T000X12_n615ContratoClienteEnderecoLograodouro, T000X12_A616ContratoClienteEnderecoNumero, T000X12_n616ContratoClienteEnderecoNumero, T000X12_A617ContratoClienteEnderecoComplemento, T000X12_n617ContratoClienteEnderecoComplemento, T000X12_A618ContratoClienteEnderecoBairro,
               T000X12_n618ContratoClienteEnderecoBairro, T000X12_A473ContratoClienteId, T000X12_n473ContratoClienteId, T000X12_A923ContratoPropostaId, T000X12_n923ContratoPropostaId, T000X12_A619ContratoClienteMunicipioCodigo, T000X12_n619ContratoClienteMunicipioCodigo, T000X12_A483AssinaturaUltId_F, T000X12_n483AssinaturaUltId_F, T000X12_A1007ContratoCountAssinantes_F,
               T000X12_n1007ContratoCountAssinantes_F, T000X12_A472ContratoBlob, T000X12_n472ContratoBlob
               }
               , new Object[] {
               T000X14_A483AssinaturaUltId_F, T000X14_n483AssinaturaUltId_F
               }
               , new Object[] {
               T000X16_A1007ContratoCountAssinantes_F, T000X16_n1007ContratoCountAssinantes_F
               }
               , new Object[] {
               T000X17_A474ContratoClienteNome, T000X17_n474ContratoClienteNome, T000X17_A475ContratoClienteDocumento, T000X17_n475ContratoClienteDocumento, T000X17_A476ContratoClienteRepresentanteNome, T000X17_n476ContratoClienteRepresentanteNome, T000X17_A477ContratoClienteRepresentanteCPF, T000X17_n477ContratoClienteRepresentanteCPF, T000X17_A561ContratoClienteTipoPessoa, T000X17_n561ContratoClienteTipoPessoa,
               T000X17_A614ContratoClienteEnderecoCEP, T000X17_n614ContratoClienteEnderecoCEP, T000X17_A615ContratoClienteEnderecoLograodouro, T000X17_n615ContratoClienteEnderecoLograodouro, T000X17_A616ContratoClienteEnderecoNumero, T000X17_n616ContratoClienteEnderecoNumero, T000X17_A617ContratoClienteEnderecoComplemento, T000X17_n617ContratoClienteEnderecoComplemento, T000X17_A618ContratoClienteEnderecoBairro, T000X17_n618ContratoClienteEnderecoBairro,
               T000X17_A619ContratoClienteMunicipioCodigo, T000X17_n619ContratoClienteMunicipioCodigo
               }
               , new Object[] {
               T000X18_A923ContratoPropostaId
               }
               , new Object[] {
               T000X19_A227ContratoId
               }
               , new Object[] {
               T000X20_A227ContratoId
               }
               , new Object[] {
               T000X21_A227ContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               T000X23_A227ContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X28_A483AssinaturaUltId_F, T000X28_n483AssinaturaUltId_F
               }
               , new Object[] {
               T000X29_A474ContratoClienteNome, T000X29_n474ContratoClienteNome, T000X29_A475ContratoClienteDocumento, T000X29_n475ContratoClienteDocumento, T000X29_A476ContratoClienteRepresentanteNome, T000X29_n476ContratoClienteRepresentanteNome, T000X29_A477ContratoClienteRepresentanteCPF, T000X29_n477ContratoClienteRepresentanteCPF, T000X29_A561ContratoClienteTipoPessoa, T000X29_n561ContratoClienteTipoPessoa,
               T000X29_A614ContratoClienteEnderecoCEP, T000X29_n614ContratoClienteEnderecoCEP, T000X29_A615ContratoClienteEnderecoLograodouro, T000X29_n615ContratoClienteEnderecoLograodouro, T000X29_A616ContratoClienteEnderecoNumero, T000X29_n616ContratoClienteEnderecoNumero, T000X29_A617ContratoClienteEnderecoComplemento, T000X29_n617ContratoClienteEnderecoComplemento, T000X29_A618ContratoClienteEnderecoBairro, T000X29_n618ContratoClienteEnderecoBairro,
               T000X29_A619ContratoClienteMunicipioCodigo, T000X29_n619ContratoClienteMunicipioCodigo
               }
               , new Object[] {
               T000X31_A1007ContratoCountAssinantes_F, T000X31_n1007ContratoCountAssinantes_F
               }
               , new Object[] {
               T000X32_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T000X33_A1010OperacoesId
               }
               , new Object[] {
               T000X34_A323PropostaId
               }
               , new Object[] {
               T000X35_A238AssinaturaId
               }
               , new Object[] {
               T000X36_A237ContratoParticipanteId
               }
               , new Object[] {
               T000X37_A227ContratoId
               }
            }
         );
         AV16Pgmname = "Contrato";
      }

      private short Z461ContratoSLA ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A461ContratoSLA ;
      private short A483AssinaturaUltId_F ;
      private short A1007ContratoCountAssinantes_F ;
      private short RcdFound36 ;
      private short gxcookieaux ;
      private short Z483AssinaturaUltId_F ;
      private short Z1007ContratoCountAssinantes_F ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ContratoId ;
      private int Z227ContratoId ;
      private int Z473ContratoClienteId ;
      private int Z923ContratoPropostaId ;
      private int N473ContratoClienteId ;
      private int N923ContratoPropostaId ;
      private int A227ContratoId ;
      private int A473ContratoClienteId ;
      private int A923ContratoPropostaId ;
      private int AV7ContratoId ;
      private int trnEnded ;
      private int edtContratoId_Enabled ;
      private int edtContratoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV14Insert_ContratoClienteId ;
      private int AV15Insert_ContratoPropostaId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV17GXV1 ;
      private int idxLst ;
      private decimal Z460ContratoTaxa ;
      private decimal Z462ContratoJurosMora ;
      private decimal Z463ContratoIOFMinimo ;
      private decimal A460ContratoTaxa ;
      private decimal A462ContratoJurosMora ;
      private decimal A463ContratoIOFMinimo ;
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
      private string edtContratoNome_Internalname ;
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
      private string edtContratoId_Internalname ;
      private string TempTags ;
      private string edtContratoId_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode36 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z362ContratoDataInicial ;
      private DateTime Z363ContratoDataFinal ;
      private DateTime A362ContratoDataInicial ;
      private DateTime A363ContratoDataFinal ;
      private bool Z361ContratoComVigencia ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n227ContratoId ;
      private bool n473ContratoClienteId ;
      private bool n923ContratoPropostaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n228ContratoNome ;
      private bool n361ContratoComVigencia ;
      private bool A361ContratoComVigencia ;
      private bool n362ContratoDataInicial ;
      private bool n363ContratoDataFinal ;
      private bool n460ContratoTaxa ;
      private bool n461ContratoSLA ;
      private bool n462ContratoJurosMora ;
      private bool n463ContratoIOFMinimo ;
      private bool n471ContratoSituacao ;
      private bool n339ContratoCorpo ;
      private bool n472ContratoBlob ;
      private bool n474ContratoClienteNome ;
      private bool n475ContratoClienteDocumento ;
      private bool n476ContratoClienteRepresentanteNome ;
      private bool n477ContratoClienteRepresentanteCPF ;
      private bool n561ContratoClienteTipoPessoa ;
      private bool n614ContratoClienteEnderecoCEP ;
      private bool n615ContratoClienteEnderecoLograodouro ;
      private bool n616ContratoClienteEnderecoNumero ;
      private bool n617ContratoClienteEnderecoComplemento ;
      private bool n618ContratoClienteEnderecoBairro ;
      private bool n619ContratoClienteMunicipioCodigo ;
      private bool n483AssinaturaUltId_F ;
      private bool n1007ContratoCountAssinantes_F ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A339ContratoCorpo ;
      private string Z339ContratoCorpo ;
      private string Z228ContratoNome ;
      private string Z471ContratoSituacao ;
      private string A228ContratoNome ;
      private string A471ContratoSituacao ;
      private string A474ContratoClienteNome ;
      private string A475ContratoClienteDocumento ;
      private string A476ContratoClienteRepresentanteNome ;
      private string A477ContratoClienteRepresentanteCPF ;
      private string A561ContratoClienteTipoPessoa ;
      private string A614ContratoClienteEnderecoCEP ;
      private string A615ContratoClienteEnderecoLograodouro ;
      private string A616ContratoClienteEnderecoNumero ;
      private string A617ContratoClienteEnderecoComplemento ;
      private string A618ContratoClienteEnderecoBairro ;
      private string A619ContratoClienteMunicipioCodigo ;
      private string Z474ContratoClienteNome ;
      private string Z475ContratoClienteDocumento ;
      private string Z476ContratoClienteRepresentanteNome ;
      private string Z477ContratoClienteRepresentanteCPF ;
      private string Z561ContratoClienteTipoPessoa ;
      private string Z614ContratoClienteEnderecoCEP ;
      private string Z615ContratoClienteEnderecoLograodouro ;
      private string Z616ContratoClienteEnderecoNumero ;
      private string Z617ContratoClienteEnderecoComplemento ;
      private string Z618ContratoClienteEnderecoBairro ;
      private string Z619ContratoClienteMunicipioCodigo ;
      private string A472ContratoBlob ;
      private string Z472ContratoBlob ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T000X7_A483AssinaturaUltId_F ;
      private bool[] T000X7_n483AssinaturaUltId_F ;
      private int[] T000X12_A227ContratoId ;
      private bool[] T000X12_n227ContratoId ;
      private string[] T000X12_A228ContratoNome ;
      private bool[] T000X12_n228ContratoNome ;
      private string[] T000X12_A339ContratoCorpo ;
      private bool[] T000X12_n339ContratoCorpo ;
      private bool[] T000X12_A361ContratoComVigencia ;
      private bool[] T000X12_n361ContratoComVigencia ;
      private DateTime[] T000X12_A362ContratoDataInicial ;
      private bool[] T000X12_n362ContratoDataInicial ;
      private DateTime[] T000X12_A363ContratoDataFinal ;
      private bool[] T000X12_n363ContratoDataFinal ;
      private string[] T000X12_A474ContratoClienteNome ;
      private bool[] T000X12_n474ContratoClienteNome ;
      private string[] T000X12_A475ContratoClienteDocumento ;
      private bool[] T000X12_n475ContratoClienteDocumento ;
      private string[] T000X12_A476ContratoClienteRepresentanteNome ;
      private bool[] T000X12_n476ContratoClienteRepresentanteNome ;
      private string[] T000X12_A477ContratoClienteRepresentanteCPF ;
      private bool[] T000X12_n477ContratoClienteRepresentanteCPF ;
      private string[] T000X12_A561ContratoClienteTipoPessoa ;
      private bool[] T000X12_n561ContratoClienteTipoPessoa ;
      private decimal[] T000X12_A460ContratoTaxa ;
      private bool[] T000X12_n460ContratoTaxa ;
      private short[] T000X12_A461ContratoSLA ;
      private bool[] T000X12_n461ContratoSLA ;
      private decimal[] T000X12_A462ContratoJurosMora ;
      private bool[] T000X12_n462ContratoJurosMora ;
      private decimal[] T000X12_A463ContratoIOFMinimo ;
      private bool[] T000X12_n463ContratoIOFMinimo ;
      private string[] T000X12_A471ContratoSituacao ;
      private bool[] T000X12_n471ContratoSituacao ;
      private string[] T000X12_A614ContratoClienteEnderecoCEP ;
      private bool[] T000X12_n614ContratoClienteEnderecoCEP ;
      private string[] T000X12_A615ContratoClienteEnderecoLograodouro ;
      private bool[] T000X12_n615ContratoClienteEnderecoLograodouro ;
      private string[] T000X12_A616ContratoClienteEnderecoNumero ;
      private bool[] T000X12_n616ContratoClienteEnderecoNumero ;
      private string[] T000X12_A617ContratoClienteEnderecoComplemento ;
      private bool[] T000X12_n617ContratoClienteEnderecoComplemento ;
      private string[] T000X12_A618ContratoClienteEnderecoBairro ;
      private bool[] T000X12_n618ContratoClienteEnderecoBairro ;
      private int[] T000X12_A473ContratoClienteId ;
      private bool[] T000X12_n473ContratoClienteId ;
      private int[] T000X12_A923ContratoPropostaId ;
      private bool[] T000X12_n923ContratoPropostaId ;
      private string[] T000X12_A619ContratoClienteMunicipioCodigo ;
      private bool[] T000X12_n619ContratoClienteMunicipioCodigo ;
      private short[] T000X12_A483AssinaturaUltId_F ;
      private bool[] T000X12_n483AssinaturaUltId_F ;
      private short[] T000X12_A1007ContratoCountAssinantes_F ;
      private bool[] T000X12_n1007ContratoCountAssinantes_F ;
      private string[] T000X12_A472ContratoBlob ;
      private bool[] T000X12_n472ContratoBlob ;
      private short[] T000X9_A1007ContratoCountAssinantes_F ;
      private bool[] T000X9_n1007ContratoCountAssinantes_F ;
      private string[] T000X4_A474ContratoClienteNome ;
      private bool[] T000X4_n474ContratoClienteNome ;
      private string[] T000X4_A475ContratoClienteDocumento ;
      private bool[] T000X4_n475ContratoClienteDocumento ;
      private string[] T000X4_A476ContratoClienteRepresentanteNome ;
      private bool[] T000X4_n476ContratoClienteRepresentanteNome ;
      private string[] T000X4_A477ContratoClienteRepresentanteCPF ;
      private bool[] T000X4_n477ContratoClienteRepresentanteCPF ;
      private string[] T000X4_A561ContratoClienteTipoPessoa ;
      private bool[] T000X4_n561ContratoClienteTipoPessoa ;
      private string[] T000X4_A614ContratoClienteEnderecoCEP ;
      private bool[] T000X4_n614ContratoClienteEnderecoCEP ;
      private string[] T000X4_A615ContratoClienteEnderecoLograodouro ;
      private bool[] T000X4_n615ContratoClienteEnderecoLograodouro ;
      private string[] T000X4_A616ContratoClienteEnderecoNumero ;
      private bool[] T000X4_n616ContratoClienteEnderecoNumero ;
      private string[] T000X4_A617ContratoClienteEnderecoComplemento ;
      private bool[] T000X4_n617ContratoClienteEnderecoComplemento ;
      private string[] T000X4_A618ContratoClienteEnderecoBairro ;
      private bool[] T000X4_n618ContratoClienteEnderecoBairro ;
      private string[] T000X4_A619ContratoClienteMunicipioCodigo ;
      private bool[] T000X4_n619ContratoClienteMunicipioCodigo ;
      private int[] T000X5_A923ContratoPropostaId ;
      private bool[] T000X5_n923ContratoPropostaId ;
      private short[] T000X14_A483AssinaturaUltId_F ;
      private bool[] T000X14_n483AssinaturaUltId_F ;
      private short[] T000X16_A1007ContratoCountAssinantes_F ;
      private bool[] T000X16_n1007ContratoCountAssinantes_F ;
      private string[] T000X17_A474ContratoClienteNome ;
      private bool[] T000X17_n474ContratoClienteNome ;
      private string[] T000X17_A475ContratoClienteDocumento ;
      private bool[] T000X17_n475ContratoClienteDocumento ;
      private string[] T000X17_A476ContratoClienteRepresentanteNome ;
      private bool[] T000X17_n476ContratoClienteRepresentanteNome ;
      private string[] T000X17_A477ContratoClienteRepresentanteCPF ;
      private bool[] T000X17_n477ContratoClienteRepresentanteCPF ;
      private string[] T000X17_A561ContratoClienteTipoPessoa ;
      private bool[] T000X17_n561ContratoClienteTipoPessoa ;
      private string[] T000X17_A614ContratoClienteEnderecoCEP ;
      private bool[] T000X17_n614ContratoClienteEnderecoCEP ;
      private string[] T000X17_A615ContratoClienteEnderecoLograodouro ;
      private bool[] T000X17_n615ContratoClienteEnderecoLograodouro ;
      private string[] T000X17_A616ContratoClienteEnderecoNumero ;
      private bool[] T000X17_n616ContratoClienteEnderecoNumero ;
      private string[] T000X17_A617ContratoClienteEnderecoComplemento ;
      private bool[] T000X17_n617ContratoClienteEnderecoComplemento ;
      private string[] T000X17_A618ContratoClienteEnderecoBairro ;
      private bool[] T000X17_n618ContratoClienteEnderecoBairro ;
      private string[] T000X17_A619ContratoClienteMunicipioCodigo ;
      private bool[] T000X17_n619ContratoClienteMunicipioCodigo ;
      private int[] T000X18_A923ContratoPropostaId ;
      private bool[] T000X18_n923ContratoPropostaId ;
      private int[] T000X19_A227ContratoId ;
      private bool[] T000X19_n227ContratoId ;
      private int[] T000X3_A227ContratoId ;
      private bool[] T000X3_n227ContratoId ;
      private string[] T000X3_A228ContratoNome ;
      private bool[] T000X3_n228ContratoNome ;
      private string[] T000X3_A339ContratoCorpo ;
      private bool[] T000X3_n339ContratoCorpo ;
      private bool[] T000X3_A361ContratoComVigencia ;
      private bool[] T000X3_n361ContratoComVigencia ;
      private DateTime[] T000X3_A362ContratoDataInicial ;
      private bool[] T000X3_n362ContratoDataInicial ;
      private DateTime[] T000X3_A363ContratoDataFinal ;
      private bool[] T000X3_n363ContratoDataFinal ;
      private decimal[] T000X3_A460ContratoTaxa ;
      private bool[] T000X3_n460ContratoTaxa ;
      private short[] T000X3_A461ContratoSLA ;
      private bool[] T000X3_n461ContratoSLA ;
      private decimal[] T000X3_A462ContratoJurosMora ;
      private bool[] T000X3_n462ContratoJurosMora ;
      private decimal[] T000X3_A463ContratoIOFMinimo ;
      private bool[] T000X3_n463ContratoIOFMinimo ;
      private string[] T000X3_A471ContratoSituacao ;
      private bool[] T000X3_n471ContratoSituacao ;
      private int[] T000X3_A473ContratoClienteId ;
      private bool[] T000X3_n473ContratoClienteId ;
      private int[] T000X3_A923ContratoPropostaId ;
      private bool[] T000X3_n923ContratoPropostaId ;
      private string[] T000X3_A472ContratoBlob ;
      private bool[] T000X3_n472ContratoBlob ;
      private int[] T000X20_A227ContratoId ;
      private bool[] T000X20_n227ContratoId ;
      private int[] T000X21_A227ContratoId ;
      private bool[] T000X21_n227ContratoId ;
      private int[] T000X2_A227ContratoId ;
      private bool[] T000X2_n227ContratoId ;
      private string[] T000X2_A228ContratoNome ;
      private bool[] T000X2_n228ContratoNome ;
      private string[] T000X2_A339ContratoCorpo ;
      private bool[] T000X2_n339ContratoCorpo ;
      private bool[] T000X2_A361ContratoComVigencia ;
      private bool[] T000X2_n361ContratoComVigencia ;
      private DateTime[] T000X2_A362ContratoDataInicial ;
      private bool[] T000X2_n362ContratoDataInicial ;
      private DateTime[] T000X2_A363ContratoDataFinal ;
      private bool[] T000X2_n363ContratoDataFinal ;
      private decimal[] T000X2_A460ContratoTaxa ;
      private bool[] T000X2_n460ContratoTaxa ;
      private short[] T000X2_A461ContratoSLA ;
      private bool[] T000X2_n461ContratoSLA ;
      private decimal[] T000X2_A462ContratoJurosMora ;
      private bool[] T000X2_n462ContratoJurosMora ;
      private decimal[] T000X2_A463ContratoIOFMinimo ;
      private bool[] T000X2_n463ContratoIOFMinimo ;
      private string[] T000X2_A471ContratoSituacao ;
      private bool[] T000X2_n471ContratoSituacao ;
      private int[] T000X2_A473ContratoClienteId ;
      private bool[] T000X2_n473ContratoClienteId ;
      private int[] T000X2_A923ContratoPropostaId ;
      private bool[] T000X2_n923ContratoPropostaId ;
      private string[] T000X2_A472ContratoBlob ;
      private bool[] T000X2_n472ContratoBlob ;
      private int[] T000X23_A227ContratoId ;
      private bool[] T000X23_n227ContratoId ;
      private short[] T000X28_A483AssinaturaUltId_F ;
      private bool[] T000X28_n483AssinaturaUltId_F ;
      private string[] T000X29_A474ContratoClienteNome ;
      private bool[] T000X29_n474ContratoClienteNome ;
      private string[] T000X29_A475ContratoClienteDocumento ;
      private bool[] T000X29_n475ContratoClienteDocumento ;
      private string[] T000X29_A476ContratoClienteRepresentanteNome ;
      private bool[] T000X29_n476ContratoClienteRepresentanteNome ;
      private string[] T000X29_A477ContratoClienteRepresentanteCPF ;
      private bool[] T000X29_n477ContratoClienteRepresentanteCPF ;
      private string[] T000X29_A561ContratoClienteTipoPessoa ;
      private bool[] T000X29_n561ContratoClienteTipoPessoa ;
      private string[] T000X29_A614ContratoClienteEnderecoCEP ;
      private bool[] T000X29_n614ContratoClienteEnderecoCEP ;
      private string[] T000X29_A615ContratoClienteEnderecoLograodouro ;
      private bool[] T000X29_n615ContratoClienteEnderecoLograodouro ;
      private string[] T000X29_A616ContratoClienteEnderecoNumero ;
      private bool[] T000X29_n616ContratoClienteEnderecoNumero ;
      private string[] T000X29_A617ContratoClienteEnderecoComplemento ;
      private bool[] T000X29_n617ContratoClienteEnderecoComplemento ;
      private string[] T000X29_A618ContratoClienteEnderecoBairro ;
      private bool[] T000X29_n618ContratoClienteEnderecoBairro ;
      private string[] T000X29_A619ContratoClienteMunicipioCodigo ;
      private bool[] T000X29_n619ContratoClienteMunicipioCodigo ;
      private short[] T000X31_A1007ContratoCountAssinantes_F ;
      private bool[] T000X31_n1007ContratoCountAssinantes_F ;
      private int[] T000X32_A572PropostaContratoAssinaturaId ;
      private int[] T000X33_A1010OperacoesId ;
      private int[] T000X34_A323PropostaId ;
      private long[] T000X35_A238AssinaturaId ;
      private bool[] T000X35_n238AssinaturaId ;
      private int[] T000X36_A237ContratoParticipanteId ;
      private int[] T000X37_A227ContratoId ;
      private bool[] T000X37_n227ContratoId ;
   }

   public class contrato__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000X2;
          prmT000X2 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X3;
          prmT000X3 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X4;
          prmT000X4 = new Object[] {
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X5;
          prmT000X5 = new Object[] {
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X7;
          prmT000X7 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X9;
          prmT000X9 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X12;
          prmT000X12 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X14;
          prmT000X14 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X16;
          prmT000X16 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X17;
          prmT000X17 = new Object[] {
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X18;
          prmT000X18 = new Object[] {
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X19;
          prmT000X19 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X20;
          prmT000X20 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X21;
          prmT000X21 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X22;
          prmT000X22 = new Object[] {
          new ParDef("ContratoNome",GXType.VarChar,125,0){Nullable=true} ,
          new ParDef("ContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ContratoComVigencia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContratoDataInicial",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoDataFinal",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoIOFMinimo",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSituacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContratoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X23;
          prmT000X23 = new Object[] {
          };
          Object[] prmT000X24;
          prmT000X24 = new Object[] {
          new ParDef("ContratoNome",GXType.VarChar,125,0){Nullable=true} ,
          new ParDef("ContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ContratoComVigencia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContratoDataInicial",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoDataFinal",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoIOFMinimo",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSituacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X25;
          prmT000X25 = new Object[] {
          new ParDef("ContratoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X26;
          prmT000X26 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X28;
          prmT000X28 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X29;
          prmT000X29 = new Object[] {
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X31;
          prmT000X31 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000X32;
          prmT000X32 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X33;
          prmT000X33 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X34;
          prmT000X34 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X35;
          prmT000X35 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X36;
          prmT000X36 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000X37;
          prmT000X37 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000X2", "SELECT ContratoId, ContratoNome, ContratoCorpo, ContratoComVigencia, ContratoDataInicial, ContratoDataFinal, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoSituacao, ContratoClienteId, ContratoPropostaId, ContratoBlob FROM Contrato WHERE ContratoId = :ContratoId  FOR UPDATE OF Contrato NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000X2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X3", "SELECT ContratoId, ContratoNome, ContratoCorpo, ContratoComVigencia, ContratoDataInicial, ContratoDataFinal, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoSituacao, ContratoClienteId, ContratoPropostaId, ContratoBlob FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X4", "SELECT ClienteRazaoSocial AS ContratoClienteNome, ClienteDocumento AS ContratoClienteDocumento, ResponsavelNome AS ContratoClienteRepresentanteNome, ResponsavelCPF AS ContratoClienteRepresentanteCPF, ClienteTipoPessoa AS ContratoClienteTipoPessoa, EnderecoCEP AS ContratoClienteEnderecoCEP, EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, EnderecoNumero AS ContratoClienteEnderecoNumero, EnderecoComplemento AS ContratoClienteEnderecoComplemento, EnderecoBairro AS ContratoClienteEnderecoBairro, MunicipioCodigo AS ContratoClienteMunicipioCodigo FROM Cliente WHERE ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X5", "SELECT PropostaId AS ContratoPropostaId FROM Proposta WHERE PropostaId = :ContratoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X7", "SELECT COALESCE( T1.AssinaturaUltId_F, 0) AS AssinaturaUltId_F FROM (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura GROUP BY ContratoId ) T1 WHERE T1.ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X9", "SELECT COALESCE( T1.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM (SELECT COUNT(*) AS ContratoCountAssinantes_F, T3.ContratoId, T2.ClienteId FROM (AssinaturaParticipante T2 LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.AssinaturaId) GROUP BY T3.ContratoId, T2.ClienteId ) T1 WHERE T1.ContratoId = :ContratoId AND T1.ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X12", "SELECT TM1.ContratoId, TM1.ContratoNome, TM1.ContratoCorpo, TM1.ContratoComVigencia, TM1.ContratoDataInicial, TM1.ContratoDataFinal, T2.ClienteRazaoSocial AS ContratoClienteNome, T2.ClienteDocumento AS ContratoClienteDocumento, T2.ResponsavelNome AS ContratoClienteRepresentanteNome, T2.ResponsavelCPF AS ContratoClienteRepresentanteCPF, T2.ClienteTipoPessoa AS ContratoClienteTipoPessoa, TM1.ContratoTaxa, TM1.ContratoSLA, TM1.ContratoJurosMora, TM1.ContratoIOFMinimo, TM1.ContratoSituacao, T2.EnderecoCEP AS ContratoClienteEnderecoCEP, T2.EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, T2.EnderecoNumero AS ContratoClienteEnderecoNumero, T2.EnderecoComplemento AS ContratoClienteEnderecoComplemento, T2.EnderecoBairro AS ContratoClienteEnderecoBairro, TM1.ContratoClienteId AS ContratoClienteId, TM1.ContratoPropostaId AS ContratoPropostaId, T2.MunicipioCodigo AS ContratoClienteMunicipioCodigo, COALESCE( T3.AssinaturaUltId_F, 0) AS AssinaturaUltId_F, COALESCE( T4.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F, TM1.ContratoBlob FROM (((Contrato TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ContratoClienteId) LEFT JOIN LATERAL (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura WHERE TM1.ContratoId = ContratoId GROUP BY ContratoId ) T3 ON T3.ContratoId = TM1.ContratoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T6.ContratoId, T5.ClienteId FROM (AssinaturaParticipante T5 LEFT JOIN Assinatura T6 ON T6.AssinaturaId = T5.AssinaturaId) WHERE TM1.ContratoId = T6.ContratoId and TM1.ContratoClienteId = T5.ClienteId GROUP BY T6.ContratoId, T5.ClienteId ) T4 ON T4.ContratoId = TM1.ContratoId AND T4.ClienteId = TM1.ContratoClienteId) WHERE TM1.ContratoId = :ContratoId ORDER BY TM1.ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X14", "SELECT COALESCE( T1.AssinaturaUltId_F, 0) AS AssinaturaUltId_F FROM (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura GROUP BY ContratoId ) T1 WHERE T1.ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X16", "SELECT COALESCE( T1.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM (SELECT COUNT(*) AS ContratoCountAssinantes_F, T3.ContratoId, T2.ClienteId FROM (AssinaturaParticipante T2 LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.AssinaturaId) GROUP BY T3.ContratoId, T2.ClienteId ) T1 WHERE T1.ContratoId = :ContratoId AND T1.ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X17", "SELECT ClienteRazaoSocial AS ContratoClienteNome, ClienteDocumento AS ContratoClienteDocumento, ResponsavelNome AS ContratoClienteRepresentanteNome, ResponsavelCPF AS ContratoClienteRepresentanteCPF, ClienteTipoPessoa AS ContratoClienteTipoPessoa, EnderecoCEP AS ContratoClienteEnderecoCEP, EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, EnderecoNumero AS ContratoClienteEnderecoNumero, EnderecoComplemento AS ContratoClienteEnderecoComplemento, EnderecoBairro AS ContratoClienteEnderecoBairro, MunicipioCodigo AS ContratoClienteMunicipioCodigo FROM Cliente WHERE ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X18", "SELECT PropostaId AS ContratoPropostaId FROM Proposta WHERE PropostaId = :ContratoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X19", "SELECT ContratoId FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X20", "SELECT ContratoId FROM Contrato WHERE ( ContratoId > :ContratoId) ORDER BY ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X21", "SELECT ContratoId FROM Contrato WHERE ( ContratoId < :ContratoId) ORDER BY ContratoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X22", "SAVEPOINT gxupdate;INSERT INTO Contrato(ContratoNome, ContratoCorpo, ContratoComVigencia, ContratoDataInicial, ContratoDataFinal, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoSituacao, ContratoBlob, ContratoClienteId, ContratoPropostaId) VALUES(:ContratoNome, :ContratoCorpo, :ContratoComVigencia, :ContratoDataInicial, :ContratoDataFinal, :ContratoTaxa, :ContratoSLA, :ContratoJurosMora, :ContratoIOFMinimo, :ContratoSituacao, :ContratoBlob, :ContratoClienteId, :ContratoPropostaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X22)
             ,new CursorDef("T000X23", "SELECT currval('ContratoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X24", "SAVEPOINT gxupdate;UPDATE Contrato SET ContratoNome=:ContratoNome, ContratoCorpo=:ContratoCorpo, ContratoComVigencia=:ContratoComVigencia, ContratoDataInicial=:ContratoDataInicial, ContratoDataFinal=:ContratoDataFinal, ContratoTaxa=:ContratoTaxa, ContratoSLA=:ContratoSLA, ContratoJurosMora=:ContratoJurosMora, ContratoIOFMinimo=:ContratoIOFMinimo, ContratoSituacao=:ContratoSituacao, ContratoClienteId=:ContratoClienteId, ContratoPropostaId=:ContratoPropostaId  WHERE ContratoId = :ContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X24)
             ,new CursorDef("T000X25", "SAVEPOINT gxupdate;UPDATE Contrato SET ContratoBlob=:ContratoBlob  WHERE ContratoId = :ContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X25)
             ,new CursorDef("T000X26", "SAVEPOINT gxupdate;DELETE FROM Contrato  WHERE ContratoId = :ContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X26)
             ,new CursorDef("T000X28", "SELECT COALESCE( T1.AssinaturaUltId_F, 0) AS AssinaturaUltId_F FROM (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura GROUP BY ContratoId ) T1 WHERE T1.ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X29", "SELECT ClienteRazaoSocial AS ContratoClienteNome, ClienteDocumento AS ContratoClienteDocumento, ResponsavelNome AS ContratoClienteRepresentanteNome, ResponsavelCPF AS ContratoClienteRepresentanteCPF, ClienteTipoPessoa AS ContratoClienteTipoPessoa, EnderecoCEP AS ContratoClienteEnderecoCEP, EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, EnderecoNumero AS ContratoClienteEnderecoNumero, EnderecoComplemento AS ContratoClienteEnderecoComplemento, EnderecoBairro AS ContratoClienteEnderecoBairro, MunicipioCodigo AS ContratoClienteMunicipioCodigo FROM Cliente WHERE ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X31", "SELECT COALESCE( T1.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM (SELECT COUNT(*) AS ContratoCountAssinantes_F, T3.ContratoId, T2.ClienteId FROM (AssinaturaParticipante T2 LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.AssinaturaId) GROUP BY T3.ContratoId, T2.ClienteId ) T1 WHERE T1.ContratoId = :ContratoId AND T1.ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000X32", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaContrato = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X33", "SELECT OperacoesId FROM Operacoes WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X34", "SELECT PropostaId FROM Proposta WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X35", "SELECT AssinaturaId FROM Assinatura WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X36", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000X37", "SELECT ContratoId FROM Contrato ORDER BY ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X37,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getBLOBFile(14, "tmp", "");
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getBLOBFile(14, "tmp", "");
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getBLOBFile(27, "tmp", "");
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
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
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
