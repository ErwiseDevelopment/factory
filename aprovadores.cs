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
   public class aprovadores : GXDataArea
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
            A133SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A133SecUserId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "aprovadores")), "aprovadores") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "aprovadores")))) ;
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
                  AV7AprovadoresId = (int)(Math.Round(NumberUtil.Val( GetPar( "AprovadoresId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7AprovadoresId", StringUtil.LTrimStr( (decimal)(AV7AprovadoresId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAPROVADORESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AprovadoresId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Aprovadores", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aprovadores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovadores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_AprovadoresId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AprovadoresId = aP1_AprovadoresId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbAprovadoresStatus = new GXCombobox();
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
         if ( cmbAprovadoresStatus.ItemCount > 0 )
         {
            A380AprovadoresStatus = StringUtil.StrToBool( cmbAprovadoresStatus.getValidValue(StringUtil.BoolToStr( A380AprovadoresStatus)));
            n380AprovadoresStatus = false;
            AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAprovadoresStatus.CurrentValue = StringUtil.BoolToStr( A380AprovadoresStatus);
            AssignProp("", false, cmbAprovadoresStatus_Internalname, "Values", cmbAprovadoresStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsecuserid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksecuserid_Internalname, "Usuário", "", "", lblTextblocksecuserid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Aprovadores.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_secuserid.SetProperty("Caption", Combo_secuserid_Caption);
         ucCombo_secuserid.SetProperty("Cls", Combo_secuserid_Cls);
         ucCombo_secuserid.SetProperty("EmptyItem", Combo_secuserid_Emptyitem);
         ucCombo_secuserid.SetProperty("DropDownOptionsData", AV13SecUserId_Data);
         ucCombo_secuserid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_secuserid_Internalname, "COMBO_SECUSERIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "Usuário", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", ""))), ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserId_Visible, edtSecUserId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Aprovadores.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAprovadoresStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAprovadoresStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAprovadoresStatus, cmbAprovadoresStatus_Internalname, StringUtil.BoolToStr( A380AprovadoresStatus), 1, cmbAprovadoresStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbAprovadoresStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_Aprovadores.htm");
         cmbAprovadoresStatus.CurrentValue = StringUtil.BoolToStr( A380AprovadoresStatus);
         AssignProp("", false, cmbAprovadoresStatus_Internalname, "Values", (string)(cmbAprovadoresStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Aprovadores.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Aprovadores.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Aprovadores.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_secuserid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosecuserid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboSecUserId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCombosecuserid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboSecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(AV18ComboSecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosecuserid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosecuserid_Visible, edtavCombosecuserid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Aprovadores.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAprovadoresId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ",", "")), StringUtil.LTrim( ((edtAprovadoresId_Enabled!=0) ? context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAprovadoresId_Jsonclick, 0, "Attribute", "", "", "", "", edtAprovadoresId_Visible, edtAprovadoresId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Aprovadores.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserEmail_Internalname, A144SecUserEmail, StringUtil.RTrim( context.localUtil.Format( A144SecUserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A144SecUserEmail, "", "", "", edtSecUserEmail_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserEmail_Visible, edtSecUserEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Aprovadores.htm");
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
         E111G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vSECUSERID_DATA"), AV13SecUserId_Data);
               /* Read saved values. */
               Z375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z375AprovadoresId"), ",", "."), 18, MidpointRounding.ToEven));
               Z380AprovadoresStatus = StringUtil.StrToBool( cgiGet( "Z380AprovadoresStatus"));
               n380AprovadoresStatus = ((false==A380AprovadoresStatus) ? true : false);
               Z133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = ((0==A133SecUserId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = ((0==A133SecUserId) ? true : false);
               AV7AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vAPROVADORESID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSERID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_SecUserId", StringUtil.LTrimStr( (decimal)(AV11Insert_SecUserId), 4, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A141SecUserName = cgiGet( "SECUSERNAME");
               n141SecUserName = false;
               AV21Pgmname = cgiGet( "vPGMNAME");
               Combo_secuserid_Objectcall = cgiGet( "COMBO_SECUSERID_Objectcall");
               Combo_secuserid_Class = cgiGet( "COMBO_SECUSERID_Class");
               Combo_secuserid_Icontype = cgiGet( "COMBO_SECUSERID_Icontype");
               Combo_secuserid_Icon = cgiGet( "COMBO_SECUSERID_Icon");
               Combo_secuserid_Caption = cgiGet( "COMBO_SECUSERID_Caption");
               Combo_secuserid_Tooltip = cgiGet( "COMBO_SECUSERID_Tooltip");
               Combo_secuserid_Cls = cgiGet( "COMBO_SECUSERID_Cls");
               Combo_secuserid_Selectedvalue_set = cgiGet( "COMBO_SECUSERID_Selectedvalue_set");
               Combo_secuserid_Selectedvalue_get = cgiGet( "COMBO_SECUSERID_Selectedvalue_get");
               Combo_secuserid_Selectedtext_set = cgiGet( "COMBO_SECUSERID_Selectedtext_set");
               Combo_secuserid_Selectedtext_get = cgiGet( "COMBO_SECUSERID_Selectedtext_get");
               Combo_secuserid_Gamoauthtoken = cgiGet( "COMBO_SECUSERID_Gamoauthtoken");
               Combo_secuserid_Ddointernalname = cgiGet( "COMBO_SECUSERID_Ddointernalname");
               Combo_secuserid_Titlecontrolalign = cgiGet( "COMBO_SECUSERID_Titlecontrolalign");
               Combo_secuserid_Dropdownoptionstype = cgiGet( "COMBO_SECUSERID_Dropdownoptionstype");
               Combo_secuserid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Enabled"));
               Combo_secuserid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Visible"));
               Combo_secuserid_Titlecontrolidtoreplace = cgiGet( "COMBO_SECUSERID_Titlecontrolidtoreplace");
               Combo_secuserid_Datalisttype = cgiGet( "COMBO_SECUSERID_Datalisttype");
               Combo_secuserid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Allowmultipleselection"));
               Combo_secuserid_Datalistfixedvalues = cgiGet( "COMBO_SECUSERID_Datalistfixedvalues");
               Combo_secuserid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Isgriditem"));
               Combo_secuserid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Hasdescription"));
               Combo_secuserid_Datalistproc = cgiGet( "COMBO_SECUSERID_Datalistproc");
               Combo_secuserid_Datalistprocparametersprefix = cgiGet( "COMBO_SECUSERID_Datalistprocparametersprefix");
               Combo_secuserid_Remoteservicesparameters = cgiGet( "COMBO_SECUSERID_Remoteservicesparameters");
               Combo_secuserid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SECUSERID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_secuserid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeonlyselectedoption"));
               Combo_secuserid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeselectalloption"));
               Combo_secuserid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Emptyitem"));
               Combo_secuserid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeaddnewoption"));
               Combo_secuserid_Htmltemplate = cgiGet( "COMBO_SECUSERID_Htmltemplate");
               Combo_secuserid_Multiplevaluestype = cgiGet( "COMBO_SECUSERID_Multiplevaluestype");
               Combo_secuserid_Loadingdata = cgiGet( "COMBO_SECUSERID_Loadingdata");
               Combo_secuserid_Noresultsfound = cgiGet( "COMBO_SECUSERID_Noresultsfound");
               Combo_secuserid_Emptyitemtext = cgiGet( "COMBO_SECUSERID_Emptyitemtext");
               Combo_secuserid_Onlyselectedvalues = cgiGet( "COMBO_SECUSERID_Onlyselectedvalues");
               Combo_secuserid_Selectalltext = cgiGet( "COMBO_SECUSERID_Selectalltext");
               Combo_secuserid_Multiplevaluesseparator = cgiGet( "COMBO_SECUSERID_Multiplevaluesseparator");
               Combo_secuserid_Addnewoptiontext = cgiGet( "COMBO_SECUSERID_Addnewoptiontext");
               Combo_secuserid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SECUSERID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               n133SecUserId = ((StringUtil.StrCmp(cgiGet( edtSecUserId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A133SecUserId = 0;
                  n133SecUserId = false;
                  AssignAttri("", false, "A133SecUserId", (n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
               }
               else
               {
                  A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A133SecUserId", (n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
               }
               cmbAprovadoresStatus.CurrentValue = cgiGet( cmbAprovadoresStatus_Internalname);
               A380AprovadoresStatus = StringUtil.StrToBool( cgiGet( cmbAprovadoresStatus_Internalname));
               n380AprovadoresStatus = false;
               AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
               n380AprovadoresStatus = ((false==A380AprovadoresStatus) ? true : false);
               AV18ComboSecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombosecuserid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
               A375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n375AprovadoresId = false;
               AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
               A144SecUserEmail = cgiGet( edtSecUserEmail_Internalname);
               n144SecUserEmail = false;
               AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Aprovadores");
               A375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n375AprovadoresId = false;
               AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
               forbiddenHiddens.Add("AprovadoresId", context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserId", context.localUtil.Format( (decimal)(AV11Insert_SecUserId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A375AprovadoresId != Z375AprovadoresId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("aprovadores:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A375AprovadoresId = (int)(Math.Round(NumberUtil.Val( GetPar( "AprovadoresId"), "."), 18, MidpointRounding.ToEven));
                  n375AprovadoresId = false;
                  AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
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
                     sMode55 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode55;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound55 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1G0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "APROVADORESID");
                        AnyError = 1;
                        GX_FocusControl = edtAprovadoresId_Internalname;
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
                           E111G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121G2 ();
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
            E121G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1G55( ) ;
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
            DisableAttributes1G55( ) ;
         }
         AssignProp("", false, edtavCombosecuserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosecuserid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G55( ) ;
            }
            else
            {
               CheckExtendedTable1G55( ) ;
               CloseExtendedTableCursors1G55( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1G0( )
      {
      }

      protected void E111G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtSecUserId_Visible = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserId_Visible), 5, 0), true);
         AV18ComboSecUserId = 0;
         AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
         edtavCombosecuserid_Visible = 0;
         AssignProp("", false, edtavCombosecuserid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosecuserid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSECUSERID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            while ( AV22GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SecUserId") == 0 )
               {
                  AV11Insert_SecUserId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SecUserId", StringUtil.LTrimStr( (decimal)(AV11Insert_SecUserId), 4, 0));
                  if ( ! (0==AV11Insert_SecUserId) )
                  {
                     AV18ComboSecUserId = AV11Insert_SecUserId;
                     AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
                     Combo_secuserid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboSecUserId), 4, 0));
                     ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedValue_set", Combo_secuserid_Selectedvalue_set);
                     Combo_secuserid_Enabled = false;
                     ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_secuserid_Enabled));
                  }
               }
               AV22GXV1 = (int)(AV22GXV1+1);
               AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            }
         }
         edtAprovadoresId_Visible = 0;
         AssignProp("", false, edtAprovadoresId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Visible), 5, 0), true);
         edtSecUserEmail_Visible = 0;
         AssignProp("", false, edtSecUserEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserEmail_Visible), 5, 0), true);
      }

      protected void E121G2( )
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

      protected void S112( )
      {
         /* 'LOADCOMBOSECUSERID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV13SecUserId_Data;
         new aprovadoresloaddvcombo(context ).execute(  "SecUserId",  Gx_mode,  AV7AprovadoresId, out  AV15ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV13SecUserId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_secuserid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedValue_set", Combo_secuserid_Selectedvalue_set);
         AV18ComboSecUserId = (short)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_secuserid_Enabled = false;
            ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_secuserid_Enabled));
         }
      }

      protected void ZM1G55( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z380AprovadoresStatus = T001G3_A380AprovadoresStatus[0];
               Z133SecUserId = T001G3_A133SecUserId[0];
            }
            else
            {
               Z380AprovadoresStatus = A380AprovadoresStatus;
               Z133SecUserId = A133SecUserId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z375AprovadoresId = A375AprovadoresId;
            Z380AprovadoresStatus = A380AprovadoresStatus;
            Z133SecUserId = A133SecUserId;
            Z141SecUserName = A141SecUserName;
            Z144SecUserEmail = A144SecUserEmail;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAprovadoresId_Enabled = 0;
         AssignProp("", false, edtAprovadoresId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Enabled), 5, 0), true);
         AV21Pgmname = "Aprovadores";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtAprovadoresId_Enabled = 0;
         AssignProp("", false, edtAprovadoresId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AprovadoresId) )
         {
            A375AprovadoresId = AV7AprovadoresId;
            n375AprovadoresId = false;
            AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SecUserId) )
         {
            edtSecUserId_Enabled = 0;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         }
         else
         {
            edtSecUserId_Enabled = 1;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            cmbAprovadoresStatus.Enabled = 0;
            AssignProp("", false, cmbAprovadoresStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAprovadoresStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbAprovadoresStatus.Enabled = 1;
            AssignProp("", false, cmbAprovadoresStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAprovadoresStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbAprovadoresStatus.Enabled = 0;
            AssignProp("", false, cmbAprovadoresStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAprovadoresStatus.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SecUserId) )
         {
            A133SecUserId = AV11Insert_SecUserId;
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV18ComboSecUserId) )
            {
               A133SecUserId = 0;
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
               n133SecUserId = true;
               n133SecUserId = true;
               AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV18ComboSecUserId) )
               {
                  A133SecUserId = AV18ComboSecUserId;
                  n133SecUserId = false;
                  AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
               }
            }
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
         if ( IsIns( )  && (false==A380AprovadoresStatus) && ( Gx_BScreen == 0 ) )
         {
            A380AprovadoresStatus = true;
            n380AprovadoresStatus = false;
            AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001G4 */
            pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
            A141SecUserName = T001G4_A141SecUserName[0];
            n141SecUserName = T001G4_n141SecUserName[0];
            A144SecUserEmail = T001G4_A144SecUserEmail[0];
            n144SecUserEmail = T001G4_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            pr_default.close(2);
         }
      }

      protected void Load1G55( )
      {
         /* Using cursor T001G5 */
         pr_default.execute(3, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound55 = 1;
            A141SecUserName = T001G5_A141SecUserName[0];
            n141SecUserName = T001G5_n141SecUserName[0];
            A144SecUserEmail = T001G5_A144SecUserEmail[0];
            n144SecUserEmail = T001G5_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            A380AprovadoresStatus = T001G5_A380AprovadoresStatus[0];
            n380AprovadoresStatus = T001G5_n380AprovadoresStatus[0];
            AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
            A133SecUserId = T001G5_A133SecUserId[0];
            n133SecUserId = T001G5_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            ZM1G55( -11) ;
         }
         pr_default.close(3);
         OnLoadActions1G55( ) ;
      }

      protected void OnLoadActions1G55( )
      {
      }

      protected void CheckExtendedTable1G55( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001G6 */
         pr_default.execute(4, new Object[] {n133SecUserId, A133SecUserId, n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem("Usuário já cadastrado como aprovador", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T001G4 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Usuário já cadastrado como aprovador", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A141SecUserName = T001G4_A141SecUserName[0];
         n141SecUserName = T001G4_n141SecUserName[0];
         A144SecUserEmail = T001G4_A144SecUserEmail[0];
         n144SecUserEmail = T001G4_n144SecUserEmail[0];
         AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1G55( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( short A133SecUserId )
      {
         /* Using cursor T001G7 */
         pr_default.execute(5, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Usuário já cadastrado como aprovador", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A141SecUserName = T001G7_A141SecUserName[0];
         n141SecUserName = T001G7_n141SecUserName[0];
         A144SecUserEmail = T001G7_A144SecUserEmail[0];
         n144SecUserEmail = T001G7_n144SecUserEmail[0];
         AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A141SecUserName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A144SecUserEmail)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey1G55( )
      {
         /* Using cursor T001G8 */
         pr_default.execute(6, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound55 = 1;
         }
         else
         {
            RcdFound55 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001G3 */
         pr_default.execute(1, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G55( 11) ;
            RcdFound55 = 1;
            A375AprovadoresId = T001G3_A375AprovadoresId[0];
            n375AprovadoresId = T001G3_n375AprovadoresId[0];
            AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
            A380AprovadoresStatus = T001G3_A380AprovadoresStatus[0];
            n380AprovadoresStatus = T001G3_n380AprovadoresStatus[0];
            AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
            A133SecUserId = T001G3_A133SecUserId[0];
            n133SecUserId = T001G3_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            Z375AprovadoresId = A375AprovadoresId;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1G55( ) ;
            if ( AnyError == 1 )
            {
               RcdFound55 = 0;
               InitializeNonKey1G55( ) ;
            }
            Gx_mode = sMode55;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound55 = 0;
            InitializeNonKey1G55( ) ;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode55;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G55( ) ;
         if ( RcdFound55 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound55 = 0;
         /* Using cursor T001G9 */
         pr_default.execute(7, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001G9_A375AprovadoresId[0] < A375AprovadoresId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001G9_A375AprovadoresId[0] > A375AprovadoresId ) ) )
            {
               A375AprovadoresId = T001G9_A375AprovadoresId[0];
               n375AprovadoresId = T001G9_n375AprovadoresId[0];
               AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
               RcdFound55 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound55 = 0;
         /* Using cursor T001G10 */
         pr_default.execute(8, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001G10_A375AprovadoresId[0] > A375AprovadoresId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001G10_A375AprovadoresId[0] < A375AprovadoresId ) ) )
            {
               A375AprovadoresId = T001G10_A375AprovadoresId[0];
               n375AprovadoresId = T001G10_n375AprovadoresId[0];
               AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
               RcdFound55 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1G55( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1G55( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound55 == 1 )
            {
               if ( A375AprovadoresId != Z375AprovadoresId )
               {
                  A375AprovadoresId = Z375AprovadoresId;
                  n375AprovadoresId = false;
                  AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "APROVADORESID");
                  AnyError = 1;
                  GX_FocusControl = edtAprovadoresId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1G55( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A375AprovadoresId != Z375AprovadoresId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1G55( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "APROVADORESID");
                     AnyError = 1;
                     GX_FocusControl = edtAprovadoresId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1G55( ) ;
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
         if ( A375AprovadoresId != Z375AprovadoresId )
         {
            A375AprovadoresId = Z375AprovadoresId;
            n375AprovadoresId = false;
            AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "APROVADORESID");
            AnyError = 1;
            GX_FocusControl = edtAprovadoresId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1G55( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G2 */
            pr_default.execute(0, new Object[] {n375AprovadoresId, A375AprovadoresId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovadores"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z380AprovadoresStatus != T001G2_A380AprovadoresStatus[0] ) || ( Z133SecUserId != T001G2_A133SecUserId[0] ) )
            {
               if ( Z380AprovadoresStatus != T001G2_A380AprovadoresStatus[0] )
               {
                  GXUtil.WriteLog("aprovadores:[seudo value changed for attri]"+"AprovadoresStatus");
                  GXUtil.WriteLogRaw("Old: ",Z380AprovadoresStatus);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A380AprovadoresStatus[0]);
               }
               if ( Z133SecUserId != T001G2_A133SecUserId[0] )
               {
                  GXUtil.WriteLog("aprovadores:[seudo value changed for attri]"+"SecUserId");
                  GXUtil.WriteLogRaw("Old: ",Z133SecUserId);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A133SecUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Aprovadores"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G55( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G55( 0) ;
            CheckOptimisticConcurrency1G55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G11 */
                     pr_default.execute(9, new Object[] {n380AprovadoresStatus, A380AprovadoresStatus, n133SecUserId, A133SecUserId});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001G12 */
                     pr_default.execute(10);
                     A375AprovadoresId = T001G12_A375AprovadoresId[0];
                     n375AprovadoresId = T001G12_n375AprovadoresId[0];
                     AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovadores");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1G0( ) ;
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
               Load1G55( ) ;
            }
            EndLevel1G55( ) ;
         }
         CloseExtendedTableCursors1G55( ) ;
      }

      protected void Update1G55( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G13 */
                     pr_default.execute(11, new Object[] {n380AprovadoresStatus, A380AprovadoresStatus, n133SecUserId, A133SecUserId, n375AprovadoresId, A375AprovadoresId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovadores");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovadores"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G55( ) ;
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
            EndLevel1G55( ) ;
         }
         CloseExtendedTableCursors1G55( ) ;
      }

      protected void DeferredUpdate1G55( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G55( ) ;
            AfterConfirm1G55( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G55( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001G14 */
                  pr_default.execute(12, new Object[] {n375AprovadoresId, A375AprovadoresId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Aprovadores");
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
         sMode55 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G55( ) ;
         Gx_mode = sMode55;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G55( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001G15 */
            pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
            A141SecUserName = T001G15_A141SecUserName[0];
            n141SecUserName = T001G15_n141SecUserName[0];
            A144SecUserEmail = T001G15_A144SecUserEmail[0];
            n144SecUserEmail = T001G15_n144SecUserEmail[0];
            AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001G16 */
            pr_default.execute(14, new Object[] {n375AprovadoresId, A375AprovadoresId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel1G55( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("aprovadores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("aprovadores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1G55( )
      {
         /* Scan By routine */
         /* Using cursor T001G17 */
         pr_default.execute(15);
         RcdFound55 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound55 = 1;
            A375AprovadoresId = T001G17_A375AprovadoresId[0];
            n375AprovadoresId = T001G17_n375AprovadoresId[0];
            AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G55( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound55 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound55 = 1;
            A375AprovadoresId = T001G17_A375AprovadoresId[0];
            n375AprovadoresId = T001G17_n375AprovadoresId[0];
            AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
         }
      }

      protected void ScanEnd1G55( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1G55( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G55( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G55( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G55( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G55( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G55( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G55( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         cmbAprovadoresStatus.Enabled = 0;
         AssignProp("", false, cmbAprovadoresStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAprovadoresStatus.Enabled), 5, 0), true);
         edtavCombosecuserid_Enabled = 0;
         AssignProp("", false, edtavCombosecuserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosecuserid_Enabled), 5, 0), true);
         edtAprovadoresId_Enabled = 0;
         AssignProp("", false, edtAprovadoresId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Enabled), 5, 0), true);
         edtSecUserEmail_Enabled = 0;
         AssignProp("", false, edtSecUserEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserEmail_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1G55( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1G0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "aprovadores"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AprovadoresId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("aprovadores") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Aprovadores");
         forbiddenHiddens.Add("AprovadoresId", context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserId", context.localUtil.Format( (decimal)(AV11Insert_SecUserId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aprovadores:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z375AprovadoresId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z375AprovadoresId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z380AprovadoresStatus", Z380AprovadoresStatus);
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECUSERID_DATA", AV13SecUserId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECUSERID_DATA", AV13SecUserId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vAPROVADORESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AprovadoresId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPROVADORESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AprovadoresId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERNAME", A141SecUserName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Objectcall", StringUtil.RTrim( Combo_secuserid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Cls", StringUtil.RTrim( Combo_secuserid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Selectedvalue_set", StringUtil.RTrim( Combo_secuserid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Enabled", StringUtil.BoolToStr( Combo_secuserid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Emptyitem", StringUtil.BoolToStr( Combo_secuserid_Emptyitem));
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
         GXEncryptionTmp = "aprovadores"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AprovadoresId,9,0));
         return formatLink("aprovadores") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Aprovadores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aprovadores" ;
      }

      protected void InitializeNonKey1G55( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         n133SecUserId = ((0==A133SecUserId) ? true : false);
         A141SecUserName = "";
         n141SecUserName = false;
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         A144SecUserEmail = "";
         n144SecUserEmail = false;
         AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
         A380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
         Z380AprovadoresStatus = false;
         Z133SecUserId = 0;
      }

      protected void InitAll1G55( )
      {
         A375AprovadoresId = 0;
         n375AprovadoresId = false;
         AssignAttri("", false, "A375AprovadoresId", StringUtil.LTrimStr( (decimal)(A375AprovadoresId), 9, 0));
         InitializeNonKey1G55( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A380AprovadoresStatus = i380AprovadoresStatus;
         n380AprovadoresStatus = false;
         AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019162771", true, true);
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
         context.AddJavascriptSource("aprovadores.js", "?202561019162771", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblocksecuserid_Internalname = "TEXTBLOCKSECUSERID";
         Combo_secuserid_Internalname = "COMBO_SECUSERID";
         edtSecUserId_Internalname = "SECUSERID";
         divTablesplittedsecuserid_Internalname = "TABLESPLITTEDSECUSERID";
         cmbAprovadoresStatus_Internalname = "APROVADORESSTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosecuserid_Internalname = "vCOMBOSECUSERID";
         divSectionattribute_secuserid_Internalname = "SECTIONATTRIBUTE_SECUSERID";
         edtAprovadoresId_Internalname = "APROVADORESID";
         edtSecUserEmail_Internalname = "SECUSEREMAIL";
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
         Form.Caption = "Aprovadores";
         edtSecUserEmail_Jsonclick = "";
         edtSecUserEmail_Enabled = 0;
         edtSecUserEmail_Visible = 1;
         edtAprovadoresId_Jsonclick = "";
         edtAprovadoresId_Enabled = 0;
         edtAprovadoresId_Visible = 1;
         edtavCombosecuserid_Jsonclick = "";
         edtavCombosecuserid_Enabled = 0;
         edtavCombosecuserid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbAprovadoresStatus_Jsonclick = "";
         cmbAprovadoresStatus.Enabled = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
         edtSecUserId_Visible = 1;
         Combo_secuserid_Emptyitem = Convert.ToBoolean( 0);
         Combo_secuserid_Cls = "ExtendedCombo AttributeFL";
         Combo_secuserid_Enabled = Convert.ToBoolean( -1);
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
         cmbAprovadoresStatus.Name = "APROVADORESSTATUS";
         cmbAprovadoresStatus.WebTags = "";
         cmbAprovadoresStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbAprovadoresStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbAprovadoresStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A380AprovadoresStatus) )
            {
               A380AprovadoresStatus = true;
               n380AprovadoresStatus = false;
               AssignAttri("", false, "A380AprovadoresStatus", A380AprovadoresStatus);
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

      public void Valid_Secuserid( )
      {
         n375AprovadoresId = false;
         n141SecUserName = false;
         n144SecUserEmail = false;
         /* Using cursor T001G15 */
         pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Usuário já cadastrado como aprovador", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
            }
         }
         A141SecUserName = T001G15_A141SecUserName[0];
         n141SecUserName = T001G15_n141SecUserName[0];
         A144SecUserEmail = T001G15_A144SecUserEmail[0];
         n144SecUserEmail = T001G15_n144SecUserEmail[0];
         pr_default.close(13);
         /* Using cursor T001G18 */
         pr_default.execute(16, new Object[] {n133SecUserId, A133SecUserId, n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            GX_msglist.addItem("Usuário já cadastrado como aprovador", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         AssignAttri("", false, "A144SecUserEmail", A144SecUserEmail);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AprovadoresId","fld":"vAPROVADORESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AprovadoresId","fld":"vAPROVADORESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A375AprovadoresId","fld":"APROVADORESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_SecUserId","fld":"vINSERT_SECUSERID","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121G2","iparms":[]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"},{"av":"A375AprovadoresId","fld":"APROVADORESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A144SecUserEmail","fld":"SECUSEREMAIL","type":"svchar"}]""");
         setEventMetadata("VALID_SECUSERID",""","oparms":[{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A144SecUserEmail","fld":"SECUSEREMAIL","type":"svchar"}]}""");
         setEventMetadata("VALIDV_COMBOSECUSERID","""{"handler":"Validv_Combosecuserid","iparms":[]}""");
         setEventMetadata("VALID_APROVADORESID","""{"handler":"Valid_Aprovadoresid","iparms":[]}""");
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
         Combo_secuserid_Selectedvalue_get = "";
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
         lblTextblocksecuserid_Jsonclick = "";
         ucCombo_secuserid = new GXUserControl();
         Combo_secuserid_Caption = "";
         AV13SecUserId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A144SecUserEmail = "";
         A141SecUserName = "";
         AV21Pgmname = "";
         Combo_secuserid_Objectcall = "";
         Combo_secuserid_Class = "";
         Combo_secuserid_Icontype = "";
         Combo_secuserid_Icon = "";
         Combo_secuserid_Tooltip = "";
         Combo_secuserid_Selectedvalue_set = "";
         Combo_secuserid_Selectedtext_set = "";
         Combo_secuserid_Selectedtext_get = "";
         Combo_secuserid_Gamoauthtoken = "";
         Combo_secuserid_Ddointernalname = "";
         Combo_secuserid_Titlecontrolalign = "";
         Combo_secuserid_Dropdownoptionstype = "";
         Combo_secuserid_Titlecontrolidtoreplace = "";
         Combo_secuserid_Datalisttype = "";
         Combo_secuserid_Datalistfixedvalues = "";
         Combo_secuserid_Datalistproc = "";
         Combo_secuserid_Datalistprocparametersprefix = "";
         Combo_secuserid_Remoteservicesparameters = "";
         Combo_secuserid_Htmltemplate = "";
         Combo_secuserid_Multiplevaluestype = "";
         Combo_secuserid_Loadingdata = "";
         Combo_secuserid_Noresultsfound = "";
         Combo_secuserid_Emptyitemtext = "";
         Combo_secuserid_Onlyselectedvalues = "";
         Combo_secuserid_Selectalltext = "";
         Combo_secuserid_Multiplevaluesseparator = "";
         Combo_secuserid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode55 = "";
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
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV15ComboSelectedValue = "";
         Z141SecUserName = "";
         Z144SecUserEmail = "";
         T001G4_A141SecUserName = new string[] {""} ;
         T001G4_n141SecUserName = new bool[] {false} ;
         T001G4_A144SecUserEmail = new string[] {""} ;
         T001G4_n144SecUserEmail = new bool[] {false} ;
         T001G5_A375AprovadoresId = new int[1] ;
         T001G5_n375AprovadoresId = new bool[] {false} ;
         T001G5_A141SecUserName = new string[] {""} ;
         T001G5_n141SecUserName = new bool[] {false} ;
         T001G5_A144SecUserEmail = new string[] {""} ;
         T001G5_n144SecUserEmail = new bool[] {false} ;
         T001G5_A380AprovadoresStatus = new bool[] {false} ;
         T001G5_n380AprovadoresStatus = new bool[] {false} ;
         T001G5_A133SecUserId = new short[1] ;
         T001G5_n133SecUserId = new bool[] {false} ;
         T001G6_A133SecUserId = new short[1] ;
         T001G6_n133SecUserId = new bool[] {false} ;
         T001G7_A141SecUserName = new string[] {""} ;
         T001G7_n141SecUserName = new bool[] {false} ;
         T001G7_A144SecUserEmail = new string[] {""} ;
         T001G7_n144SecUserEmail = new bool[] {false} ;
         T001G8_A375AprovadoresId = new int[1] ;
         T001G8_n375AprovadoresId = new bool[] {false} ;
         T001G3_A375AprovadoresId = new int[1] ;
         T001G3_n375AprovadoresId = new bool[] {false} ;
         T001G3_A380AprovadoresStatus = new bool[] {false} ;
         T001G3_n380AprovadoresStatus = new bool[] {false} ;
         T001G3_A133SecUserId = new short[1] ;
         T001G3_n133SecUserId = new bool[] {false} ;
         T001G9_A375AprovadoresId = new int[1] ;
         T001G9_n375AprovadoresId = new bool[] {false} ;
         T001G10_A375AprovadoresId = new int[1] ;
         T001G10_n375AprovadoresId = new bool[] {false} ;
         T001G2_A375AprovadoresId = new int[1] ;
         T001G2_n375AprovadoresId = new bool[] {false} ;
         T001G2_A380AprovadoresStatus = new bool[] {false} ;
         T001G2_n380AprovadoresStatus = new bool[] {false} ;
         T001G2_A133SecUserId = new short[1] ;
         T001G2_n133SecUserId = new bool[] {false} ;
         T001G12_A375AprovadoresId = new int[1] ;
         T001G12_n375AprovadoresId = new bool[] {false} ;
         T001G15_A141SecUserName = new string[] {""} ;
         T001G15_n141SecUserName = new bool[] {false} ;
         T001G15_A144SecUserEmail = new string[] {""} ;
         T001G15_n144SecUserEmail = new bool[] {false} ;
         T001G16_A336AprovacaoId = new int[1] ;
         T001G17_A375AprovadoresId = new int[1] ;
         T001G17_n375AprovadoresId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001G18_A133SecUserId = new short[1] ;
         T001G18_n133SecUserId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovadores__default(),
            new Object[][] {
                new Object[] {
               T001G2_A375AprovadoresId, T001G2_A380AprovadoresStatus, T001G2_n380AprovadoresStatus, T001G2_A133SecUserId, T001G2_n133SecUserId
               }
               , new Object[] {
               T001G3_A375AprovadoresId, T001G3_A380AprovadoresStatus, T001G3_n380AprovadoresStatus, T001G3_A133SecUserId, T001G3_n133SecUserId
               }
               , new Object[] {
               T001G4_A141SecUserName, T001G4_n141SecUserName, T001G4_A144SecUserEmail, T001G4_n144SecUserEmail
               }
               , new Object[] {
               T001G5_A375AprovadoresId, T001G5_A141SecUserName, T001G5_n141SecUserName, T001G5_A144SecUserEmail, T001G5_n144SecUserEmail, T001G5_A380AprovadoresStatus, T001G5_n380AprovadoresStatus, T001G5_A133SecUserId, T001G5_n133SecUserId
               }
               , new Object[] {
               T001G6_A133SecUserId, T001G6_n133SecUserId
               }
               , new Object[] {
               T001G7_A141SecUserName, T001G7_n141SecUserName, T001G7_A144SecUserEmail, T001G7_n144SecUserEmail
               }
               , new Object[] {
               T001G8_A375AprovadoresId
               }
               , new Object[] {
               T001G9_A375AprovadoresId
               }
               , new Object[] {
               T001G10_A375AprovadoresId
               }
               , new Object[] {
               }
               , new Object[] {
               T001G12_A375AprovadoresId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G15_A141SecUserName, T001G15_n141SecUserName, T001G15_A144SecUserEmail, T001G15_n144SecUserEmail
               }
               , new Object[] {
               T001G16_A336AprovacaoId
               }
               , new Object[] {
               T001G17_A375AprovadoresId
               }
               , new Object[] {
               T001G18_A133SecUserId, T001G18_n133SecUserId
               }
            }
         );
         AV21Pgmname = "Aprovadores";
         Z380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         A380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         i380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
      }

      private short Z133SecUserId ;
      private short N133SecUserId ;
      private short GxWebError ;
      private short A133SecUserId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV18ComboSecUserId ;
      private short AV11Insert_SecUserId ;
      private short Gx_BScreen ;
      private short RcdFound55 ;
      private short gxajaxcallmode ;
      private int wcpOAV7AprovadoresId ;
      private int Z375AprovadoresId ;
      private int AV7AprovadoresId ;
      private int trnEnded ;
      private int edtSecUserId_Visible ;
      private int edtSecUserId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosecuserid_Enabled ;
      private int edtavCombosecuserid_Visible ;
      private int A375AprovadoresId ;
      private int edtAprovadoresId_Enabled ;
      private int edtAprovadoresId_Visible ;
      private int edtSecUserEmail_Visible ;
      private int edtSecUserEmail_Enabled ;
      private int Combo_secuserid_Datalistupdateminimumcharacters ;
      private int Combo_secuserid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV22GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_secuserid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecUserId_Internalname ;
      private string cmbAprovadoresStatus_Internalname ;
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
      private string divTablesplittedsecuserid_Internalname ;
      private string lblTextblocksecuserid_Internalname ;
      private string lblTextblocksecuserid_Jsonclick ;
      private string Combo_secuserid_Caption ;
      private string Combo_secuserid_Cls ;
      private string Combo_secuserid_Internalname ;
      private string TempTags ;
      private string edtSecUserId_Jsonclick ;
      private string cmbAprovadoresStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_secuserid_Internalname ;
      private string edtavCombosecuserid_Internalname ;
      private string edtavCombosecuserid_Jsonclick ;
      private string edtAprovadoresId_Internalname ;
      private string edtAprovadoresId_Jsonclick ;
      private string edtSecUserEmail_Internalname ;
      private string edtSecUserEmail_Jsonclick ;
      private string AV21Pgmname ;
      private string Combo_secuserid_Objectcall ;
      private string Combo_secuserid_Class ;
      private string Combo_secuserid_Icontype ;
      private string Combo_secuserid_Icon ;
      private string Combo_secuserid_Tooltip ;
      private string Combo_secuserid_Selectedvalue_set ;
      private string Combo_secuserid_Selectedtext_set ;
      private string Combo_secuserid_Selectedtext_get ;
      private string Combo_secuserid_Gamoauthtoken ;
      private string Combo_secuserid_Ddointernalname ;
      private string Combo_secuserid_Titlecontrolalign ;
      private string Combo_secuserid_Dropdownoptionstype ;
      private string Combo_secuserid_Titlecontrolidtoreplace ;
      private string Combo_secuserid_Datalisttype ;
      private string Combo_secuserid_Datalistfixedvalues ;
      private string Combo_secuserid_Datalistproc ;
      private string Combo_secuserid_Datalistprocparametersprefix ;
      private string Combo_secuserid_Remoteservicesparameters ;
      private string Combo_secuserid_Htmltemplate ;
      private string Combo_secuserid_Multiplevaluestype ;
      private string Combo_secuserid_Loadingdata ;
      private string Combo_secuserid_Noresultsfound ;
      private string Combo_secuserid_Emptyitemtext ;
      private string Combo_secuserid_Onlyselectedvalues ;
      private string Combo_secuserid_Selectalltext ;
      private string Combo_secuserid_Multiplevaluesseparator ;
      private string Combo_secuserid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode55 ;
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
      private bool Z380AprovadoresStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n133SecUserId ;
      private bool wbErr ;
      private bool A380AprovadoresStatus ;
      private bool n380AprovadoresStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_secuserid_Emptyitem ;
      private bool n141SecUserName ;
      private bool Combo_secuserid_Enabled ;
      private bool Combo_secuserid_Visible ;
      private bool Combo_secuserid_Allowmultipleselection ;
      private bool Combo_secuserid_Isgriditem ;
      private bool Combo_secuserid_Hasdescription ;
      private bool Combo_secuserid_Includeonlyselectedoption ;
      private bool Combo_secuserid_Includeselectalloption ;
      private bool Combo_secuserid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n375AprovadoresId ;
      private bool n144SecUserEmail ;
      private bool returnInSub ;
      private bool i380AprovadoresStatus ;
      private string A144SecUserEmail ;
      private string A141SecUserName ;
      private string AV15ComboSelectedValue ;
      private string Z141SecUserName ;
      private string Z144SecUserEmail ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_secuserid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAprovadoresStatus ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13SecUserId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private IDataStoreProvider pr_default ;
      private string[] T001G4_A141SecUserName ;
      private bool[] T001G4_n141SecUserName ;
      private string[] T001G4_A144SecUserEmail ;
      private bool[] T001G4_n144SecUserEmail ;
      private int[] T001G5_A375AprovadoresId ;
      private bool[] T001G5_n375AprovadoresId ;
      private string[] T001G5_A141SecUserName ;
      private bool[] T001G5_n141SecUserName ;
      private string[] T001G5_A144SecUserEmail ;
      private bool[] T001G5_n144SecUserEmail ;
      private bool[] T001G5_A380AprovadoresStatus ;
      private bool[] T001G5_n380AprovadoresStatus ;
      private short[] T001G5_A133SecUserId ;
      private bool[] T001G5_n133SecUserId ;
      private short[] T001G6_A133SecUserId ;
      private bool[] T001G6_n133SecUserId ;
      private string[] T001G7_A141SecUserName ;
      private bool[] T001G7_n141SecUserName ;
      private string[] T001G7_A144SecUserEmail ;
      private bool[] T001G7_n144SecUserEmail ;
      private int[] T001G8_A375AprovadoresId ;
      private bool[] T001G8_n375AprovadoresId ;
      private int[] T001G3_A375AprovadoresId ;
      private bool[] T001G3_n375AprovadoresId ;
      private bool[] T001G3_A380AprovadoresStatus ;
      private bool[] T001G3_n380AprovadoresStatus ;
      private short[] T001G3_A133SecUserId ;
      private bool[] T001G3_n133SecUserId ;
      private int[] T001G9_A375AprovadoresId ;
      private bool[] T001G9_n375AprovadoresId ;
      private int[] T001G10_A375AprovadoresId ;
      private bool[] T001G10_n375AprovadoresId ;
      private int[] T001G2_A375AprovadoresId ;
      private bool[] T001G2_n375AprovadoresId ;
      private bool[] T001G2_A380AprovadoresStatus ;
      private bool[] T001G2_n380AprovadoresStatus ;
      private short[] T001G2_A133SecUserId ;
      private bool[] T001G2_n133SecUserId ;
      private int[] T001G12_A375AprovadoresId ;
      private bool[] T001G12_n375AprovadoresId ;
      private string[] T001G15_A141SecUserName ;
      private bool[] T001G15_n141SecUserName ;
      private string[] T001G15_A144SecUserEmail ;
      private bool[] T001G15_n144SecUserEmail ;
      private int[] T001G16_A336AprovacaoId ;
      private int[] T001G17_A375AprovadoresId ;
      private bool[] T001G17_n375AprovadoresId ;
      private short[] T001G18_A133SecUserId ;
      private bool[] T001G18_n133SecUserId ;
   }

   public class aprovadores__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001G2;
          prmT001G2 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G3;
          prmT001G3 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G4;
          prmT001G4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001G5;
          prmT001G5 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G6;
          prmT001G6 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G7;
          prmT001G7 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001G8;
          prmT001G8 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G9;
          prmT001G9 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G10;
          prmT001G10 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G11;
          prmT001G11 = new Object[] {
          new ParDef("AprovadoresStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001G12;
          prmT001G12 = new Object[] {
          };
          Object[] prmT001G13;
          prmT001G13 = new Object[] {
          new ParDef("AprovadoresStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G14;
          prmT001G14 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G15;
          prmT001G15 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001G16;
          prmT001G16 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001G17;
          prmT001G17 = new Object[] {
          };
          Object[] prmT001G18;
          prmT001G18 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001G2", "SELECT AprovadoresId, AprovadoresStatus, SecUserId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId  FOR UPDATE OF Aprovadores NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G3", "SELECT AprovadoresId, AprovadoresStatus, SecUserId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G4", "SELECT SecUserName, SecUserEmail FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G5", "SELECT TM1.AprovadoresId, T2.SecUserName, T2.SecUserEmail, TM1.AprovadoresStatus, TM1.SecUserId FROM (Aprovadores TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) WHERE TM1.AprovadoresId = :AprovadoresId ORDER BY TM1.AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G6", "SELECT SecUserId FROM Aprovadores WHERE (SecUserId = :SecUserId) AND (Not ( AprovadoresId = :AprovadoresId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G7", "SELECT SecUserName, SecUserEmail FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G8", "SELECT AprovadoresId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G9", "SELECT AprovadoresId FROM Aprovadores WHERE ( AprovadoresId > :AprovadoresId) ORDER BY AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001G10", "SELECT AprovadoresId FROM Aprovadores WHERE ( AprovadoresId < :AprovadoresId) ORDER BY AprovadoresId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001G11", "SAVEPOINT gxupdate;INSERT INTO Aprovadores(AprovadoresStatus, SecUserId) VALUES(:AprovadoresStatus, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001G11)
             ,new CursorDef("T001G12", "SELECT currval('AprovadoresId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G13", "SAVEPOINT gxupdate;UPDATE Aprovadores SET AprovadoresStatus=:AprovadoresStatus, SecUserId=:SecUserId  WHERE AprovadoresId = :AprovadoresId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001G13)
             ,new CursorDef("T001G14", "SAVEPOINT gxupdate;DELETE FROM Aprovadores  WHERE AprovadoresId = :AprovadoresId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001G14)
             ,new CursorDef("T001G15", "SELECT SecUserName, SecUserEmail FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G16", "SELECT AprovacaoId FROM Aprovacao WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001G17", "SELECT AprovadoresId FROM Aprovadores ORDER BY AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001G18", "SELECT SecUserId FROM Aprovadores WHERE (SecUserId = :SecUserId) AND (Not ( AprovadoresId = :AprovadoresId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G18,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
