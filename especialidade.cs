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
   public class especialidade : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A597EspecialidadeCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "EspecialidadeCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n597EspecialidadeCreatedBy = false;
            AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A597EspecialidadeCreatedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "especialidade")), "especialidade") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "especialidade")))) ;
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
                  AV7EspecialidadeId = (int)(Math.Round(NumberUtil.Val( GetPar( "EspecialidadeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7EspecialidadeId", StringUtil.LTrimStr( (decimal)(AV7EspecialidadeId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vESPECIALIDADEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspecialidadeId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Especialidade", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspecialidadeNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public especialidade( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public especialidade( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_EspecialidadeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EspecialidadeId = aP1_EspecialidadeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbEspecialidadeStatus = new GXCombobox();
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
         if ( cmbEspecialidadeStatus.ItemCount > 0 )
         {
            A595EspecialidadeStatus = StringUtil.StrToBool( cmbEspecialidadeStatus.getValidValue(StringUtil.BoolToStr( A595EspecialidadeStatus)));
            n595EspecialidadeStatus = false;
            AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEspecialidadeStatus.CurrentValue = StringUtil.BoolToStr( A595EspecialidadeStatus);
            AssignProp("", false, cmbEspecialidadeStatus_Internalname, "Values", cmbEspecialidadeStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspecialidadeNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspecialidadeNome_Internalname, "Especialidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspecialidadeNome_Internalname, A458EspecialidadeNome, StringUtil.RTrim( context.localUtil.Format( A458EspecialidadeNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspecialidadeNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEspecialidadeNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Especialidade.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbEspecialidadeStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbEspecialidadeStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEspecialidadeStatus, cmbEspecialidadeStatus_Internalname, StringUtil.BoolToStr( A595EspecialidadeStatus), 1, cmbEspecialidadeStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbEspecialidadeStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Especialidade.htm");
         cmbEspecialidadeStatus.CurrentValue = StringUtil.BoolToStr( A595EspecialidadeStatus);
         AssignProp("", false, cmbEspecialidadeStatus_Internalname, "Values", (string)(cmbEspecialidadeStatus.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Especialidade.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Especialidade.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Especialidade.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspecialidadeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ",", "")), StringUtil.LTrim( ((edtEspecialidadeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A457EspecialidadeId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A457EspecialidadeId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspecialidadeId_Jsonclick, 0, "Attribute", "", "", "", "", edtEspecialidadeId_Visible, edtEspecialidadeId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Especialidade.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEspecialidadeCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspecialidadeCreatedAt_Internalname, context.localUtil.TToC( A596EspecialidadeCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A596EspecialidadeCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspecialidadeCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtEspecialidadeCreatedAt_Visible, edtEspecialidadeCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Especialidade.htm");
         GxWebStd.gx_bitmap( context, edtEspecialidadeCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtEspecialidadeCreatedAt_Visible==0)||(edtEspecialidadeCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Especialidade.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspecialidadeCreatedBy_Internalname, ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ",", ""))), ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A597EspecialidadeCreatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspecialidadeCreatedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtEspecialidadeCreatedBy_Visible, edtEspecialidadeCreatedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Especialidade.htm");
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
         E111T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z457EspecialidadeId"), ",", "."), 18, MidpointRounding.ToEven));
               Z596EspecialidadeCreatedAt = context.localUtil.CToT( cgiGet( "Z596EspecialidadeCreatedAt"), 0);
               n596EspecialidadeCreatedAt = ((DateTime.MinValue==A596EspecialidadeCreatedAt) ? true : false);
               Z598EspecialidadeUpdatedAt = context.localUtil.CToT( cgiGet( "Z598EspecialidadeUpdatedAt"), 0);
               n598EspecialidadeUpdatedAt = ((DateTime.MinValue==A598EspecialidadeUpdatedAt) ? true : false);
               Z458EspecialidadeNome = cgiGet( "Z458EspecialidadeNome");
               n458EspecialidadeNome = (String.IsNullOrEmpty(StringUtil.RTrim( A458EspecialidadeNome)) ? true : false);
               Z595EspecialidadeStatus = StringUtil.StrToBool( cgiGet( "Z595EspecialidadeStatus"));
               n595EspecialidadeStatus = ((false==A595EspecialidadeStatus) ? true : false);
               Z597EspecialidadeCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z597EspecialidadeCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n597EspecialidadeCreatedBy = ((0==A597EspecialidadeCreatedBy) ? true : false);
               A598EspecialidadeUpdatedAt = context.localUtil.CToT( cgiGet( "Z598EspecialidadeUpdatedAt"), 0);
               n598EspecialidadeUpdatedAt = false;
               n598EspecialidadeUpdatedAt = ((DateTime.MinValue==A598EspecialidadeUpdatedAt) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N597EspecialidadeCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N597EspecialidadeCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n597EspecialidadeCreatedBy = ((0==A597EspecialidadeCreatedBy) ? true : false);
               AV7EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vESPECIALIDADEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_EspecialidadeCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESPECIALIDADECREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_EspecialidadeCreatedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_EspecialidadeCreatedBy), 4, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A598EspecialidadeUpdatedAt = context.localUtil.CToT( cgiGet( "ESPECIALIDADEUPDATEDAT"), 0);
               n598EspecialidadeUpdatedAt = ((DateTime.MinValue==A598EspecialidadeUpdatedAt) ? true : false);
               AV14Pgmname = cgiGet( "vPGMNAME");
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
               A458EspecialidadeNome = cgiGet( edtEspecialidadeNome_Internalname);
               n458EspecialidadeNome = false;
               AssignAttri("", false, "A458EspecialidadeNome", A458EspecialidadeNome);
               n458EspecialidadeNome = (String.IsNullOrEmpty(StringUtil.RTrim( A458EspecialidadeNome)) ? true : false);
               cmbEspecialidadeStatus.CurrentValue = cgiGet( cmbEspecialidadeStatus_Internalname);
               A595EspecialidadeStatus = StringUtil.StrToBool( cgiGet( cmbEspecialidadeStatus_Internalname));
               n595EspecialidadeStatus = false;
               AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
               n595EspecialidadeStatus = ((false==A595EspecialidadeStatus) ? true : false);
               A457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEspecialidadeId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n457EspecialidadeId = false;
               AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
               if ( context.localUtil.VCDateTime( cgiGet( edtEspecialidadeCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Especialidade Created At"}), 1, "ESPECIALIDADECREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtEspecialidadeCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
                  n596EspecialidadeCreatedAt = false;
                  AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A596EspecialidadeCreatedAt = context.localUtil.CToT( cgiGet( edtEspecialidadeCreatedAt_Internalname));
                  n596EspecialidadeCreatedAt = false;
                  AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n596EspecialidadeCreatedAt = ((DateTime.MinValue==A596EspecialidadeCreatedAt) ? true : false);
               n597EspecialidadeCreatedBy = ((StringUtil.StrCmp(cgiGet( edtEspecialidadeCreatedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspecialidadeCreatedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspecialidadeCreatedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESPECIALIDADECREATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtEspecialidadeCreatedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A597EspecialidadeCreatedBy = 0;
                  n597EspecialidadeCreatedBy = false;
                  AssignAttri("", false, "A597EspecialidadeCreatedBy", (n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A597EspecialidadeCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspecialidadeCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A597EspecialidadeCreatedBy", (n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Especialidade");
               A457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEspecialidadeId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n457EspecialidadeId = false;
               AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
               forbiddenHiddens.Add("EspecialidadeId", context.localUtil.Format( (decimal)(A457EspecialidadeId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_EspecialidadeCreatedBy", context.localUtil.Format( (decimal)(AV11Insert_EspecialidadeCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("EspecialidadeUpdatedAt", context.localUtil.Format( A598EspecialidadeUpdatedAt, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A457EspecialidadeId != Z457EspecialidadeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("especialidade:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A457EspecialidadeId = (int)(Math.Round(NumberUtil.Val( GetPar( "EspecialidadeId"), "."), 18, MidpointRounding.ToEven));
                  n457EspecialidadeId = false;
                  AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
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
                     sMode67 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode67;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound67 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESPECIALIDADEID");
                        AnyError = 1;
                        GX_FocusControl = edtEspecialidadeId_Internalname;
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
                           E111T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121T2 ();
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
            E121T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1T67( ) ;
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
            DisableAttributes1T67( ) ;
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T67( ) ;
            }
            else
            {
               CheckExtendedTable1T67( ) ;
               CloseExtendedTableCursors1T67( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1T0( )
      {
      }

      protected void E111T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EspecialidadeCreatedBy") == 0 )
               {
                  AV11Insert_EspecialidadeCreatedBy = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_EspecialidadeCreatedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_EspecialidadeCreatedBy), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
         edtEspecialidadeId_Visible = 0;
         AssignProp("", false, edtEspecialidadeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEspecialidadeId_Visible), 5, 0), true);
         edtEspecialidadeCreatedAt_Visible = 0;
         AssignProp("", false, edtEspecialidadeCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEspecialidadeCreatedAt_Visible), 5, 0), true);
         edtEspecialidadeCreatedBy_Visible = 0;
         AssignProp("", false, edtEspecialidadeCreatedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEspecialidadeCreatedBy_Visible), 5, 0), true);
      }

      protected void E121T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("especialidadeww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1T67( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z596EspecialidadeCreatedAt = T001T3_A596EspecialidadeCreatedAt[0];
               Z598EspecialidadeUpdatedAt = T001T3_A598EspecialidadeUpdatedAt[0];
               Z458EspecialidadeNome = T001T3_A458EspecialidadeNome[0];
               Z595EspecialidadeStatus = T001T3_A595EspecialidadeStatus[0];
               Z597EspecialidadeCreatedBy = T001T3_A597EspecialidadeCreatedBy[0];
            }
            else
            {
               Z596EspecialidadeCreatedAt = A596EspecialidadeCreatedAt;
               Z598EspecialidadeUpdatedAt = A598EspecialidadeUpdatedAt;
               Z458EspecialidadeNome = A458EspecialidadeNome;
               Z595EspecialidadeStatus = A595EspecialidadeStatus;
               Z597EspecialidadeCreatedBy = A597EspecialidadeCreatedBy;
            }
         }
         if ( GX_JID == -13 )
         {
            Z457EspecialidadeId = A457EspecialidadeId;
            Z596EspecialidadeCreatedAt = A596EspecialidadeCreatedAt;
            Z598EspecialidadeUpdatedAt = A598EspecialidadeUpdatedAt;
            Z458EspecialidadeNome = A458EspecialidadeNome;
            Z595EspecialidadeStatus = A595EspecialidadeStatus;
            Z597EspecialidadeCreatedBy = A597EspecialidadeCreatedBy;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEspecialidadeId_Enabled = 0;
         AssignProp("", false, edtEspecialidadeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeId_Enabled), 5, 0), true);
         AV14Pgmname = "Especialidade";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtEspecialidadeId_Enabled = 0;
         AssignProp("", false, edtEspecialidadeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EspecialidadeId) )
         {
            A457EspecialidadeId = AV7EspecialidadeId;
            n457EspecialidadeId = false;
            AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspecialidadeCreatedBy) )
         {
            edtEspecialidadeCreatedBy_Enabled = 0;
            AssignProp("", false, edtEspecialidadeCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeCreatedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtEspecialidadeCreatedBy_Enabled = 1;
            AssignProp("", false, edtEspecialidadeCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeCreatedBy_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A598EspecialidadeUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n598EspecialidadeUpdatedAt = false;
            AssignAttri("", false, "A598EspecialidadeUpdatedAt", context.localUtil.TToC( A598EspecialidadeUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            A598EspecialidadeUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n598EspecialidadeUpdatedAt = false;
            AssignAttri("", false, "A598EspecialidadeUpdatedAt", context.localUtil.TToC( A598EspecialidadeUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
         {
            cmbEspecialidadeStatus.Enabled = 0;
            AssignProp("", false, cmbEspecialidadeStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEspecialidadeStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbEspecialidadeStatus.Enabled = 1;
            AssignProp("", false, cmbEspecialidadeStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEspecialidadeStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbEspecialidadeStatus.Enabled = 0;
            AssignProp("", false, cmbEspecialidadeStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEspecialidadeStatus.Enabled), 5, 0), true);
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
            A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n596EspecialidadeCreatedAt = false;
            AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A596EspecialidadeCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n596EspecialidadeCreatedAt = false;
               AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
         }
         if ( IsIns( )  && (false==A595EspecialidadeStatus) && ( Gx_BScreen == 0 ) )
         {
            A595EspecialidadeStatus = true;
            n595EspecialidadeStatus = false;
            AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
         }
      }

      protected void Load1T67( )
      {
         /* Using cursor T001T5 */
         pr_default.execute(3, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound67 = 1;
            A596EspecialidadeCreatedAt = T001T5_A596EspecialidadeCreatedAt[0];
            n596EspecialidadeCreatedAt = T001T5_n596EspecialidadeCreatedAt[0];
            AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A598EspecialidadeUpdatedAt = T001T5_A598EspecialidadeUpdatedAt[0];
            n598EspecialidadeUpdatedAt = T001T5_n598EspecialidadeUpdatedAt[0];
            A458EspecialidadeNome = T001T5_A458EspecialidadeNome[0];
            n458EspecialidadeNome = T001T5_n458EspecialidadeNome[0];
            AssignAttri("", false, "A458EspecialidadeNome", A458EspecialidadeNome);
            A595EspecialidadeStatus = T001T5_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = T001T5_n595EspecialidadeStatus[0];
            AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
            A597EspecialidadeCreatedBy = T001T5_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = T001T5_n597EspecialidadeCreatedBy[0];
            AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
            ZM1T67( -13) ;
         }
         pr_default.close(3);
         OnLoadActions1T67( ) ;
      }

      protected void OnLoadActions1T67( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspecialidadeCreatedBy) )
         {
            A597EspecialidadeCreatedBy = AV11Insert_EspecialidadeCreatedBy;
            n597EspecialidadeCreatedBy = false;
            AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
               n597EspecialidadeCreatedBy = false;
               AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( (0==A597EspecialidadeCreatedBy) )
               {
                  A597EspecialidadeCreatedBy = 0;
                  n597EspecialidadeCreatedBy = false;
                  AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
                  n597EspecialidadeCreatedBy = true;
                  n597EspecialidadeCreatedBy = true;
                  AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  if ( IsIns( )  && (0==A597EspecialidadeCreatedBy) && ( Gx_BScreen == 0 ) )
                  {
                     A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
                     n597EspecialidadeCreatedBy = false;
                     AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
                  }
               }
            }
         }
      }

      protected void CheckExtendedTable1T67( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspecialidadeCreatedBy) )
         {
            A597EspecialidadeCreatedBy = AV11Insert_EspecialidadeCreatedBy;
            n597EspecialidadeCreatedBy = false;
            AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
               n597EspecialidadeCreatedBy = false;
               AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( (0==A597EspecialidadeCreatedBy) )
               {
                  A597EspecialidadeCreatedBy = 0;
                  n597EspecialidadeCreatedBy = false;
                  AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
                  n597EspecialidadeCreatedBy = true;
                  n597EspecialidadeCreatedBy = true;
                  AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  if ( IsIns( )  && (0==A597EspecialidadeCreatedBy) && ( Gx_BScreen == 0 ) )
                  {
                     A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
                     n597EspecialidadeCreatedBy = false;
                     AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
                  }
               }
            }
         }
         /* Using cursor T001T4 */
         pr_default.execute(2, new Object[] {n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A597EspecialidadeCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Especialidade Created By'.", "ForeignKeyNotFound", 1, "ESPECIALIDADECREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtEspecialidadeCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1T67( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( short A597EspecialidadeCreatedBy )
      {
         /* Using cursor T001T6 */
         pr_default.execute(4, new Object[] {n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A597EspecialidadeCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Especialidade Created By'.", "ForeignKeyNotFound", 1, "ESPECIALIDADECREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtEspecialidadeCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1T67( )
      {
         /* Using cursor T001T7 */
         pr_default.execute(5, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001T3 */
         pr_default.execute(1, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T67( 13) ;
            RcdFound67 = 1;
            A457EspecialidadeId = T001T3_A457EspecialidadeId[0];
            n457EspecialidadeId = T001T3_n457EspecialidadeId[0];
            AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
            A596EspecialidadeCreatedAt = T001T3_A596EspecialidadeCreatedAt[0];
            n596EspecialidadeCreatedAt = T001T3_n596EspecialidadeCreatedAt[0];
            AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A598EspecialidadeUpdatedAt = T001T3_A598EspecialidadeUpdatedAt[0];
            n598EspecialidadeUpdatedAt = T001T3_n598EspecialidadeUpdatedAt[0];
            A458EspecialidadeNome = T001T3_A458EspecialidadeNome[0];
            n458EspecialidadeNome = T001T3_n458EspecialidadeNome[0];
            AssignAttri("", false, "A458EspecialidadeNome", A458EspecialidadeNome);
            A595EspecialidadeStatus = T001T3_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = T001T3_n595EspecialidadeStatus[0];
            AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
            A597EspecialidadeCreatedBy = T001T3_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = T001T3_n597EspecialidadeCreatedBy[0];
            AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
            Z457EspecialidadeId = A457EspecialidadeId;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1T67( ) ;
            if ( AnyError == 1 )
            {
               RcdFound67 = 0;
               InitializeNonKey1T67( ) ;
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey1T67( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T67( ) ;
         if ( RcdFound67 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound67 = 0;
         /* Using cursor T001T8 */
         pr_default.execute(6, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001T8_A457EspecialidadeId[0] < A457EspecialidadeId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001T8_A457EspecialidadeId[0] > A457EspecialidadeId ) ) )
            {
               A457EspecialidadeId = T001T8_A457EspecialidadeId[0];
               n457EspecialidadeId = T001T8_n457EspecialidadeId[0];
               AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
               RcdFound67 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound67 = 0;
         /* Using cursor T001T9 */
         pr_default.execute(7, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001T9_A457EspecialidadeId[0] > A457EspecialidadeId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001T9_A457EspecialidadeId[0] < A457EspecialidadeId ) ) )
            {
               A457EspecialidadeId = T001T9_A457EspecialidadeId[0];
               n457EspecialidadeId = T001T9_n457EspecialidadeId[0];
               AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
               RcdFound67 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1T67( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEspecialidadeNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1T67( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound67 == 1 )
            {
               if ( A457EspecialidadeId != Z457EspecialidadeId )
               {
                  A457EspecialidadeId = Z457EspecialidadeId;
                  n457EspecialidadeId = false;
                  AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESPECIALIDADEID");
                  AnyError = 1;
                  GX_FocusControl = edtEspecialidadeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspecialidadeNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1T67( ) ;
                  GX_FocusControl = edtEspecialidadeNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A457EspecialidadeId != Z457EspecialidadeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEspecialidadeNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1T67( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESPECIALIDADEID");
                     AnyError = 1;
                     GX_FocusControl = edtEspecialidadeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEspecialidadeNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1T67( ) ;
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
         if ( A457EspecialidadeId != Z457EspecialidadeId )
         {
            A457EspecialidadeId = Z457EspecialidadeId;
            n457EspecialidadeId = false;
            AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESPECIALIDADEID");
            AnyError = 1;
            GX_FocusControl = edtEspecialidadeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspecialidadeNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1T67( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001T2 */
            pr_default.execute(0, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Especialidade"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z596EspecialidadeCreatedAt != T001T2_A596EspecialidadeCreatedAt[0] ) || ( Z598EspecialidadeUpdatedAt != T001T2_A598EspecialidadeUpdatedAt[0] ) || ( StringUtil.StrCmp(Z458EspecialidadeNome, T001T2_A458EspecialidadeNome[0]) != 0 ) || ( Z595EspecialidadeStatus != T001T2_A595EspecialidadeStatus[0] ) || ( Z597EspecialidadeCreatedBy != T001T2_A597EspecialidadeCreatedBy[0] ) )
            {
               if ( Z596EspecialidadeCreatedAt != T001T2_A596EspecialidadeCreatedAt[0] )
               {
                  GXUtil.WriteLog("especialidade:[seudo value changed for attri]"+"EspecialidadeCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z596EspecialidadeCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A596EspecialidadeCreatedAt[0]);
               }
               if ( Z598EspecialidadeUpdatedAt != T001T2_A598EspecialidadeUpdatedAt[0] )
               {
                  GXUtil.WriteLog("especialidade:[seudo value changed for attri]"+"EspecialidadeUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z598EspecialidadeUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A598EspecialidadeUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z458EspecialidadeNome, T001T2_A458EspecialidadeNome[0]) != 0 )
               {
                  GXUtil.WriteLog("especialidade:[seudo value changed for attri]"+"EspecialidadeNome");
                  GXUtil.WriteLogRaw("Old: ",Z458EspecialidadeNome);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A458EspecialidadeNome[0]);
               }
               if ( Z595EspecialidadeStatus != T001T2_A595EspecialidadeStatus[0] )
               {
                  GXUtil.WriteLog("especialidade:[seudo value changed for attri]"+"EspecialidadeStatus");
                  GXUtil.WriteLogRaw("Old: ",Z595EspecialidadeStatus);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A595EspecialidadeStatus[0]);
               }
               if ( Z597EspecialidadeCreatedBy != T001T2_A597EspecialidadeCreatedBy[0] )
               {
                  GXUtil.WriteLog("especialidade:[seudo value changed for attri]"+"EspecialidadeCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z597EspecialidadeCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A597EspecialidadeCreatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Especialidade"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T67( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T67( 0) ;
            CheckOptimisticConcurrency1T67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T10 */
                     pr_default.execute(8, new Object[] {n596EspecialidadeCreatedAt, A596EspecialidadeCreatedAt, n598EspecialidadeUpdatedAt, A598EspecialidadeUpdatedAt, n458EspecialidadeNome, A458EspecialidadeNome, n595EspecialidadeStatus, A595EspecialidadeStatus, n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001T11 */
                     pr_default.execute(9);
                     A457EspecialidadeId = T001T11_A457EspecialidadeId[0];
                     n457EspecialidadeId = T001T11_n457EspecialidadeId[0];
                     AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Especialidade");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1T0( ) ;
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
               Load1T67( ) ;
            }
            EndLevel1T67( ) ;
         }
         CloseExtendedTableCursors1T67( ) ;
      }

      protected void Update1T67( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T12 */
                     pr_default.execute(10, new Object[] {n596EspecialidadeCreatedAt, A596EspecialidadeCreatedAt, n598EspecialidadeUpdatedAt, A598EspecialidadeUpdatedAt, n458EspecialidadeNome, A458EspecialidadeNome, n595EspecialidadeStatus, A595EspecialidadeStatus, n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy, n457EspecialidadeId, A457EspecialidadeId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Especialidade");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Especialidade"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T67( ) ;
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
            EndLevel1T67( ) ;
         }
         CloseExtendedTableCursors1T67( ) ;
      }

      protected void DeferredUpdate1T67( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T67( ) ;
            AfterConfirm1T67( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T67( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001T13 */
                  pr_default.execute(11, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Especialidade");
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
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1T67( ) ;
         Gx_mode = sMode67;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1T67( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001T14 */
            pr_default.execute(12, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel1T67( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("especialidade",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("especialidade",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1T67( )
      {
         /* Scan By routine */
         /* Using cursor T001T15 */
         pr_default.execute(13);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound67 = 1;
            A457EspecialidadeId = T001T15_A457EspecialidadeId[0];
            n457EspecialidadeId = T001T15_n457EspecialidadeId[0];
            AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1T67( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound67 = 1;
            A457EspecialidadeId = T001T15_A457EspecialidadeId[0];
            n457EspecialidadeId = T001T15_n457EspecialidadeId[0];
            AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
         }
      }

      protected void ScanEnd1T67( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1T67( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T67( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T67( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T67( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T67( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T67( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T67( )
      {
         edtEspecialidadeNome_Enabled = 0;
         AssignProp("", false, edtEspecialidadeNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeNome_Enabled), 5, 0), true);
         cmbEspecialidadeStatus.Enabled = 0;
         AssignProp("", false, cmbEspecialidadeStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEspecialidadeStatus.Enabled), 5, 0), true);
         edtEspecialidadeId_Enabled = 0;
         AssignProp("", false, edtEspecialidadeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeId_Enabled), 5, 0), true);
         edtEspecialidadeCreatedAt_Enabled = 0;
         AssignProp("", false, edtEspecialidadeCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeCreatedAt_Enabled), 5, 0), true);
         edtEspecialidadeCreatedBy_Enabled = 0;
         AssignProp("", false, edtEspecialidadeCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspecialidadeCreatedBy_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1T67( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1T0( )
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
         GXEncryptionTmp = "especialidade"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EspecialidadeId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("especialidade") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Especialidade");
         forbiddenHiddens.Add("EspecialidadeId", context.localUtil.Format( (decimal)(A457EspecialidadeId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_EspecialidadeCreatedBy", context.localUtil.Format( (decimal)(AV11Insert_EspecialidadeCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EspecialidadeUpdatedAt", context.localUtil.Format( A598EspecialidadeUpdatedAt, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("especialidade:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z457EspecialidadeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z457EspecialidadeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z596EspecialidadeCreatedAt", context.localUtil.TToC( Z596EspecialidadeCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z598EspecialidadeUpdatedAt", context.localUtil.TToC( Z598EspecialidadeUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z458EspecialidadeNome", Z458EspecialidadeNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z595EspecialidadeStatus", Z595EspecialidadeStatus);
         GxWebStd.gx_hidden_field( context, "Z597EspecialidadeCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z597EspecialidadeCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N597EspecialidadeCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vESPECIALIDADEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspecialidadeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESPECIALIDADEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspecialidadeId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECIALIDADECREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EspecialidadeCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADEUPDATEDAT", context.localUtil.TToC( A598EspecialidadeUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         GXEncryptionTmp = "especialidade"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EspecialidadeId,9,0));
         return formatLink("especialidade") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Especialidade" ;
      }

      public override string GetPgmdesc( )
      {
         return "Especialidade" ;
      }

      protected void InitializeNonKey1T67( )
      {
         A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
         A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         n598EspecialidadeUpdatedAt = false;
         AssignAttri("", false, "A598EspecialidadeUpdatedAt", context.localUtil.TToC( A598EspecialidadeUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A458EspecialidadeNome = "";
         n458EspecialidadeNome = false;
         AssignAttri("", false, "A458EspecialidadeNome", A458EspecialidadeNome);
         n458EspecialidadeNome = (String.IsNullOrEmpty(StringUtil.RTrim( A458EspecialidadeNome)) ? true : false);
         A595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
         Z596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         Z598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         Z458EspecialidadeNome = "";
         Z595EspecialidadeStatus = false;
         Z597EspecialidadeCreatedBy = 0;
      }

      protected void InitAll1T67( )
      {
         A457EspecialidadeId = 0;
         n457EspecialidadeId = false;
         AssignAttri("", false, "A457EspecialidadeId", StringUtil.LTrimStr( (decimal)(A457EspecialidadeId), 9, 0));
         InitializeNonKey1T67( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A596EspecialidadeCreatedAt = i596EspecialidadeCreatedAt;
         n596EspecialidadeCreatedAt = false;
         AssignAttri("", false, "A596EspecialidadeCreatedAt", context.localUtil.TToC( A596EspecialidadeCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A595EspecialidadeStatus = i595EspecialidadeStatus;
         n595EspecialidadeStatus = false;
         AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019173349", true, true);
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
         context.AddJavascriptSource("especialidade.js", "?202561019173349", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtEspecialidadeNome_Internalname = "ESPECIALIDADENOME";
         cmbEspecialidadeStatus_Internalname = "ESPECIALIDADESTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtEspecialidadeId_Internalname = "ESPECIALIDADEID";
         edtEspecialidadeCreatedAt_Internalname = "ESPECIALIDADECREATEDAT";
         edtEspecialidadeCreatedBy_Internalname = "ESPECIALIDADECREATEDBY";
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
         Form.Caption = "Especialidade";
         edtEspecialidadeCreatedBy_Jsonclick = "";
         edtEspecialidadeCreatedBy_Enabled = 1;
         edtEspecialidadeCreatedBy_Visible = 1;
         edtEspecialidadeCreatedAt_Jsonclick = "";
         edtEspecialidadeCreatedAt_Enabled = 1;
         edtEspecialidadeCreatedAt_Visible = 1;
         edtEspecialidadeId_Jsonclick = "";
         edtEspecialidadeId_Enabled = 0;
         edtEspecialidadeId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbEspecialidadeStatus_Jsonclick = "";
         cmbEspecialidadeStatus.Enabled = 1;
         edtEspecialidadeNome_Jsonclick = "";
         edtEspecialidadeNome_Enabled = 1;
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
         cmbEspecialidadeStatus.Name = "ESPECIALIDADESTATUS";
         cmbEspecialidadeStatus.WebTags = "";
         cmbEspecialidadeStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbEspecialidadeStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbEspecialidadeStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A595EspecialidadeStatus) )
            {
               A595EspecialidadeStatus = true;
               n595EspecialidadeStatus = false;
               AssignAttri("", false, "A595EspecialidadeStatus", A595EspecialidadeStatus);
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

      public void Valid_Especialidadecreatedby( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspecialidadeCreatedBy) )
         {
            A597EspecialidadeCreatedBy = AV11Insert_EspecialidadeCreatedBy;
            n597EspecialidadeCreatedBy = false;
         }
         else
         {
            if ( IsIns( )  )
            {
               A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
               n597EspecialidadeCreatedBy = false;
            }
            else
            {
               if ( (0==A597EspecialidadeCreatedBy) )
               {
                  A597EspecialidadeCreatedBy = 0;
                  n597EspecialidadeCreatedBy = false;
                  n597EspecialidadeCreatedBy = true;
                  n597EspecialidadeCreatedBy = true;
               }
               else
               {
                  if ( IsIns( )  && (0==A597EspecialidadeCreatedBy) && ( Gx_BScreen == 0 ) )
                  {
                     A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
                     n597EspecialidadeCreatedBy = false;
                  }
               }
            }
         }
         /* Using cursor T001T16 */
         pr_default.execute(14, new Object[] {n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A597EspecialidadeCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Especialidade Created By'.", "ForeignKeyNotFound", 1, "ESPECIALIDADECREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtEspecialidadeCreatedBy_Internalname;
            }
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A597EspecialidadeCreatedBy", ((0==A597EspecialidadeCreatedBy)&&IsIns( )||n597EspecialidadeCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A597EspecialidadeCreatedBy), 4, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7EspecialidadeId","fld":"vESPECIALIDADEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7EspecialidadeId","fld":"vESPECIALIDADEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A457EspecialidadeId","fld":"ESPECIALIDADEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_EspecialidadeCreatedBy","fld":"vINSERT_ESPECIALIDADECREATEDBY","pic":"ZZZ9","type":"int"},{"av":"A598EspecialidadeUpdatedAt","fld":"ESPECIALIDADEUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121T2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_ESPECIALIDADEID","""{"handler":"Valid_Especialidadeid","iparms":[]}""");
         setEventMetadata("VALID_ESPECIALIDADECREATEDBY","""{"handler":"Valid_Especialidadecreatedby","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11Insert_EspecialidadeCreatedBy","fld":"vINSERT_ESPECIALIDADECREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV8WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"A597EspecialidadeCreatedBy","fld":"ESPECIALIDADECREATEDBY","pic":"ZZZ9","nullAv":"n597EspecialidadeCreatedBy","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"}]""");
         setEventMetadata("VALID_ESPECIALIDADECREATEDBY",""","oparms":[{"av":"A597EspecialidadeCreatedBy","fld":"ESPECIALIDADECREATEDBY","pic":"ZZZ9","nullAv":"n597EspecialidadeCreatedBy","type":"int"}]}""");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         Z598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         Z458EspecialidadeNome = "";
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
         A458EspecialidadeNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         A598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode67 = "";
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
         T001T5_A457EspecialidadeId = new int[1] ;
         T001T5_n457EspecialidadeId = new bool[] {false} ;
         T001T5_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001T5_n596EspecialidadeCreatedAt = new bool[] {false} ;
         T001T5_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T001T5_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         T001T5_A458EspecialidadeNome = new string[] {""} ;
         T001T5_n458EspecialidadeNome = new bool[] {false} ;
         T001T5_A595EspecialidadeStatus = new bool[] {false} ;
         T001T5_n595EspecialidadeStatus = new bool[] {false} ;
         T001T5_A597EspecialidadeCreatedBy = new short[1] ;
         T001T5_n597EspecialidadeCreatedBy = new bool[] {false} ;
         T001T4_A597EspecialidadeCreatedBy = new short[1] ;
         T001T4_n597EspecialidadeCreatedBy = new bool[] {false} ;
         T001T6_A597EspecialidadeCreatedBy = new short[1] ;
         T001T6_n597EspecialidadeCreatedBy = new bool[] {false} ;
         T001T7_A457EspecialidadeId = new int[1] ;
         T001T7_n457EspecialidadeId = new bool[] {false} ;
         T001T3_A457EspecialidadeId = new int[1] ;
         T001T3_n457EspecialidadeId = new bool[] {false} ;
         T001T3_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001T3_n596EspecialidadeCreatedAt = new bool[] {false} ;
         T001T3_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T001T3_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         T001T3_A458EspecialidadeNome = new string[] {""} ;
         T001T3_n458EspecialidadeNome = new bool[] {false} ;
         T001T3_A595EspecialidadeStatus = new bool[] {false} ;
         T001T3_n595EspecialidadeStatus = new bool[] {false} ;
         T001T3_A597EspecialidadeCreatedBy = new short[1] ;
         T001T3_n597EspecialidadeCreatedBy = new bool[] {false} ;
         T001T8_A457EspecialidadeId = new int[1] ;
         T001T8_n457EspecialidadeId = new bool[] {false} ;
         T001T9_A457EspecialidadeId = new int[1] ;
         T001T9_n457EspecialidadeId = new bool[] {false} ;
         T001T2_A457EspecialidadeId = new int[1] ;
         T001T2_n457EspecialidadeId = new bool[] {false} ;
         T001T2_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001T2_n596EspecialidadeCreatedAt = new bool[] {false} ;
         T001T2_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T001T2_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         T001T2_A458EspecialidadeNome = new string[] {""} ;
         T001T2_n458EspecialidadeNome = new bool[] {false} ;
         T001T2_A595EspecialidadeStatus = new bool[] {false} ;
         T001T2_n595EspecialidadeStatus = new bool[] {false} ;
         T001T2_A597EspecialidadeCreatedBy = new short[1] ;
         T001T2_n597EspecialidadeCreatedBy = new bool[] {false} ;
         T001T11_A457EspecialidadeId = new int[1] ;
         T001T11_n457EspecialidadeId = new bool[] {false} ;
         T001T14_A168ClienteId = new int[1] ;
         T001T15_A457EspecialidadeId = new int[1] ;
         T001T15_n457EspecialidadeId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         T001T16_A597EspecialidadeCreatedBy = new short[1] ;
         T001T16_n597EspecialidadeCreatedBy = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.especialidade__default(),
            new Object[][] {
                new Object[] {
               T001T2_A457EspecialidadeId, T001T2_A596EspecialidadeCreatedAt, T001T2_n596EspecialidadeCreatedAt, T001T2_A598EspecialidadeUpdatedAt, T001T2_n598EspecialidadeUpdatedAt, T001T2_A458EspecialidadeNome, T001T2_n458EspecialidadeNome, T001T2_A595EspecialidadeStatus, T001T2_n595EspecialidadeStatus, T001T2_A597EspecialidadeCreatedBy,
               T001T2_n597EspecialidadeCreatedBy
               }
               , new Object[] {
               T001T3_A457EspecialidadeId, T001T3_A596EspecialidadeCreatedAt, T001T3_n596EspecialidadeCreatedAt, T001T3_A598EspecialidadeUpdatedAt, T001T3_n598EspecialidadeUpdatedAt, T001T3_A458EspecialidadeNome, T001T3_n458EspecialidadeNome, T001T3_A595EspecialidadeStatus, T001T3_n595EspecialidadeStatus, T001T3_A597EspecialidadeCreatedBy,
               T001T3_n597EspecialidadeCreatedBy
               }
               , new Object[] {
               T001T4_A597EspecialidadeCreatedBy
               }
               , new Object[] {
               T001T5_A457EspecialidadeId, T001T5_A596EspecialidadeCreatedAt, T001T5_n596EspecialidadeCreatedAt, T001T5_A598EspecialidadeUpdatedAt, T001T5_n598EspecialidadeUpdatedAt, T001T5_A458EspecialidadeNome, T001T5_n458EspecialidadeNome, T001T5_A595EspecialidadeStatus, T001T5_n595EspecialidadeStatus, T001T5_A597EspecialidadeCreatedBy,
               T001T5_n597EspecialidadeCreatedBy
               }
               , new Object[] {
               T001T6_A597EspecialidadeCreatedBy
               }
               , new Object[] {
               T001T7_A457EspecialidadeId
               }
               , new Object[] {
               T001T8_A457EspecialidadeId
               }
               , new Object[] {
               T001T9_A457EspecialidadeId
               }
               , new Object[] {
               }
               , new Object[] {
               T001T11_A457EspecialidadeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001T14_A168ClienteId
               }
               , new Object[] {
               T001T15_A457EspecialidadeId
               }
               , new Object[] {
               T001T16_A597EspecialidadeCreatedBy
               }
            }
         );
         AV14Pgmname = "Especialidade";
         Z597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         N597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         Z596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         i596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         Z595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         A595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         i595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
      }

      private short Z597EspecialidadeCreatedBy ;
      private short N597EspecialidadeCreatedBy ;
      private short GxWebError ;
      private short A597EspecialidadeCreatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV11Insert_EspecialidadeCreatedBy ;
      private short Gx_BScreen ;
      private short RcdFound67 ;
      private short gxajaxcallmode ;
      private int wcpOAV7EspecialidadeId ;
      private int Z457EspecialidadeId ;
      private int AV7EspecialidadeId ;
      private int trnEnded ;
      private int edtEspecialidadeNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A457EspecialidadeId ;
      private int edtEspecialidadeId_Enabled ;
      private int edtEspecialidadeId_Visible ;
      private int edtEspecialidadeCreatedAt_Visible ;
      private int edtEspecialidadeCreatedAt_Enabled ;
      private int edtEspecialidadeCreatedBy_Visible ;
      private int edtEspecialidadeCreatedBy_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV15GXV1 ;
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
      private string edtEspecialidadeNome_Internalname ;
      private string cmbEspecialidadeStatus_Internalname ;
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
      private string edtEspecialidadeNome_Jsonclick ;
      private string cmbEspecialidadeStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEspecialidadeId_Internalname ;
      private string edtEspecialidadeId_Jsonclick ;
      private string edtEspecialidadeCreatedAt_Internalname ;
      private string edtEspecialidadeCreatedAt_Jsonclick ;
      private string edtEspecialidadeCreatedBy_Internalname ;
      private string edtEspecialidadeCreatedBy_Jsonclick ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode67 ;
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
      private DateTime Z596EspecialidadeCreatedAt ;
      private DateTime Z598EspecialidadeUpdatedAt ;
      private DateTime A596EspecialidadeCreatedAt ;
      private DateTime A598EspecialidadeUpdatedAt ;
      private DateTime i596EspecialidadeCreatedAt ;
      private bool Z595EspecialidadeStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n597EspecialidadeCreatedBy ;
      private bool wbErr ;
      private bool A595EspecialidadeStatus ;
      private bool n595EspecialidadeStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n596EspecialidadeCreatedAt ;
      private bool n598EspecialidadeUpdatedAt ;
      private bool n458EspecialidadeNome ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n457EspecialidadeId ;
      private bool returnInSub ;
      private bool i595EspecialidadeStatus ;
      private string Z458EspecialidadeNome ;
      private string A458EspecialidadeNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEspecialidadeStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] T001T5_A457EspecialidadeId ;
      private bool[] T001T5_n457EspecialidadeId ;
      private DateTime[] T001T5_A596EspecialidadeCreatedAt ;
      private bool[] T001T5_n596EspecialidadeCreatedAt ;
      private DateTime[] T001T5_A598EspecialidadeUpdatedAt ;
      private bool[] T001T5_n598EspecialidadeUpdatedAt ;
      private string[] T001T5_A458EspecialidadeNome ;
      private bool[] T001T5_n458EspecialidadeNome ;
      private bool[] T001T5_A595EspecialidadeStatus ;
      private bool[] T001T5_n595EspecialidadeStatus ;
      private short[] T001T5_A597EspecialidadeCreatedBy ;
      private bool[] T001T5_n597EspecialidadeCreatedBy ;
      private short[] T001T4_A597EspecialidadeCreatedBy ;
      private bool[] T001T4_n597EspecialidadeCreatedBy ;
      private short[] T001T6_A597EspecialidadeCreatedBy ;
      private bool[] T001T6_n597EspecialidadeCreatedBy ;
      private int[] T001T7_A457EspecialidadeId ;
      private bool[] T001T7_n457EspecialidadeId ;
      private int[] T001T3_A457EspecialidadeId ;
      private bool[] T001T3_n457EspecialidadeId ;
      private DateTime[] T001T3_A596EspecialidadeCreatedAt ;
      private bool[] T001T3_n596EspecialidadeCreatedAt ;
      private DateTime[] T001T3_A598EspecialidadeUpdatedAt ;
      private bool[] T001T3_n598EspecialidadeUpdatedAt ;
      private string[] T001T3_A458EspecialidadeNome ;
      private bool[] T001T3_n458EspecialidadeNome ;
      private bool[] T001T3_A595EspecialidadeStatus ;
      private bool[] T001T3_n595EspecialidadeStatus ;
      private short[] T001T3_A597EspecialidadeCreatedBy ;
      private bool[] T001T3_n597EspecialidadeCreatedBy ;
      private int[] T001T8_A457EspecialidadeId ;
      private bool[] T001T8_n457EspecialidadeId ;
      private int[] T001T9_A457EspecialidadeId ;
      private bool[] T001T9_n457EspecialidadeId ;
      private int[] T001T2_A457EspecialidadeId ;
      private bool[] T001T2_n457EspecialidadeId ;
      private DateTime[] T001T2_A596EspecialidadeCreatedAt ;
      private bool[] T001T2_n596EspecialidadeCreatedAt ;
      private DateTime[] T001T2_A598EspecialidadeUpdatedAt ;
      private bool[] T001T2_n598EspecialidadeUpdatedAt ;
      private string[] T001T2_A458EspecialidadeNome ;
      private bool[] T001T2_n458EspecialidadeNome ;
      private bool[] T001T2_A595EspecialidadeStatus ;
      private bool[] T001T2_n595EspecialidadeStatus ;
      private short[] T001T2_A597EspecialidadeCreatedBy ;
      private bool[] T001T2_n597EspecialidadeCreatedBy ;
      private int[] T001T11_A457EspecialidadeId ;
      private bool[] T001T11_n457EspecialidadeId ;
      private int[] T001T14_A168ClienteId ;
      private int[] T001T15_A457EspecialidadeId ;
      private bool[] T001T15_n457EspecialidadeId ;
      private short[] T001T16_A597EspecialidadeCreatedBy ;
      private bool[] T001T16_n597EspecialidadeCreatedBy ;
   }

   public class especialidade__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001T2;
          prmT001T2 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T3;
          prmT001T3 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T4;
          prmT001T4 = new Object[] {
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001T5;
          prmT001T5 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T6;
          prmT001T6 = new Object[] {
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001T7;
          prmT001T7 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T8;
          prmT001T8 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T9;
          prmT001T9 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T10;
          prmT001T10 = new Object[] {
          new ParDef("EspecialidadeCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EspecialidadeStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001T11;
          prmT001T11 = new Object[] {
          };
          Object[] prmT001T12;
          prmT001T12 = new Object[] {
          new ParDef("EspecialidadeCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EspecialidadeStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T13;
          prmT001T13 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T14;
          prmT001T14 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001T15;
          prmT001T15 = new Object[] {
          };
          Object[] prmT001T16;
          prmT001T16 = new Object[] {
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001T2", "SELECT EspecialidadeId, EspecialidadeCreatedAt, EspecialidadeUpdatedAt, EspecialidadeNome, EspecialidadeStatus, EspecialidadeCreatedBy FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId  FOR UPDATE OF Especialidade NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001T2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T3", "SELECT EspecialidadeId, EspecialidadeCreatedAt, EspecialidadeUpdatedAt, EspecialidadeNome, EspecialidadeStatus, EspecialidadeCreatedBy FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T4", "SELECT SecUserId AS EspecialidadeCreatedBy FROM SecUser WHERE SecUserId = :EspecialidadeCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T5", "SELECT TM1.EspecialidadeId, TM1.EspecialidadeCreatedAt, TM1.EspecialidadeUpdatedAt, TM1.EspecialidadeNome, TM1.EspecialidadeStatus, TM1.EspecialidadeCreatedBy AS EspecialidadeCreatedBy FROM Especialidade TM1 WHERE TM1.EspecialidadeId = :EspecialidadeId ORDER BY TM1.EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T6", "SELECT SecUserId AS EspecialidadeCreatedBy FROM SecUser WHERE SecUserId = :EspecialidadeCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T7", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T8", "SELECT EspecialidadeId FROM Especialidade WHERE ( EspecialidadeId > :EspecialidadeId) ORDER BY EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001T9", "SELECT EspecialidadeId FROM Especialidade WHERE ( EspecialidadeId < :EspecialidadeId) ORDER BY EspecialidadeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001T10", "SAVEPOINT gxupdate;INSERT INTO Especialidade(EspecialidadeCreatedAt, EspecialidadeUpdatedAt, EspecialidadeNome, EspecialidadeStatus, EspecialidadeCreatedBy) VALUES(:EspecialidadeCreatedAt, :EspecialidadeUpdatedAt, :EspecialidadeNome, :EspecialidadeStatus, :EspecialidadeCreatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001T10)
             ,new CursorDef("T001T11", "SELECT currval('EspecialidadeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T12", "SAVEPOINT gxupdate;UPDATE Especialidade SET EspecialidadeCreatedAt=:EspecialidadeCreatedAt, EspecialidadeUpdatedAt=:EspecialidadeUpdatedAt, EspecialidadeNome=:EspecialidadeNome, EspecialidadeStatus=:EspecialidadeStatus, EspecialidadeCreatedBy=:EspecialidadeCreatedBy  WHERE EspecialidadeId = :EspecialidadeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001T12)
             ,new CursorDef("T001T13", "SAVEPOINT gxupdate;DELETE FROM Especialidade  WHERE EspecialidadeId = :EspecialidadeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001T13)
             ,new CursorDef("T001T14", "SELECT ClienteId FROM Cliente WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001T15", "SELECT EspecialidadeId FROM Especialidade ORDER BY EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001T16", "SELECT SecUserId AS EspecialidadeCreatedBy FROM SecUser WHERE SecUserId = :EspecialidadeCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T16,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
