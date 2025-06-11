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
   public class clientedocumento : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel15"+"_"+"vWWPCONTEXT") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX15ASAWWPCONTEXT2879( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A405DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A405DocumentosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A606ClienteDocumentoCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "ClienteDocumentoCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n606ClienteDocumentoCreatedBy = false;
            AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A606ClienteDocumentoCreatedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "clientedocumento")), "clientedocumento") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "clientedocumento")))) ;
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
                  AV7ClienteDocumentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteDocumentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(AV7ClienteDocumentoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteDocumentoId), "ZZZZZZZZ9"), context));
                  AV24ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24ClienteId", StringUtil.LTrimStr( (decimal)(AV24ClienteId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24ClienteId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Documento do cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientedocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientedocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ClienteDocumentoId ,
                           int aP2_ClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ClienteDocumentoId = aP1_ClienteDocumentoId;
         this.AV24ClienteId = aP2_ClienteId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplitteddocumentosid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdocumentosid_Internalname, "Tipo de documento", "", "", lblTextblockdocumentosid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_documentosid.SetProperty("Caption", Combo_documentosid_Caption);
         ucCombo_documentosid.SetProperty("Cls", Combo_documentosid_Cls);
         ucCombo_documentosid.SetProperty("EmptyItem", Combo_documentosid_Emptyitem);
         ucCombo_documentosid.SetProperty("IncludeAddNewOption", Combo_documentosid_Includeaddnewoption);
         ucCombo_documentosid.SetProperty("DropDownOptionsData", AV29DocumentosId_Data);
         ucCombo_documentosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_documentosid_Internalname, "COMBO_DOCUMENTOSIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentosId_Internalname, "Documentos Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentosId_Internalname, ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", ""))), ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentosId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentosId_Visible, edtDocumentosId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteDocumentoBlob_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteDocumentoBlob_Internalname, "Arquivo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "AttributeFL";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         edtClienteDocumentoBlob_Filetype = "tmp";
         AssignProp("", false, edtClienteDocumentoBlob_Internalname, "Filetype", edtClienteDocumentoBlob_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) )
         {
            gxblobfileaux.Source = A601ClienteDocumentoBlob;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtClienteDocumentoBlob_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtClienteDocumentoBlob_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A601ClienteDocumentoBlob = gxblobfileaux.GetURI();
               n601ClienteDocumentoBlob = false;
               AssignAttri("", false, "A601ClienteDocumentoBlob", A601ClienteDocumentoBlob);
               AssignProp("", false, edtClienteDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A601ClienteDocumentoBlob), true);
               edtClienteDocumentoBlob_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtClienteDocumentoBlob_Internalname, "Filetype", edtClienteDocumentoBlob_Filetype, true);
            }
            AssignProp("", false, edtClienteDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A601ClienteDocumentoBlob), true);
         }
         GxWebStd.gx_blob_field( context, edtClienteDocumentoBlob_Internalname, StringUtil.RTrim( A601ClienteDocumentoBlob), context.PathToRelativeUrl( A601ClienteDocumentoBlob), (String.IsNullOrEmpty(StringUtil.RTrim( edtClienteDocumentoBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtClienteDocumentoBlob_Filetype)) ? A601ClienteDocumentoBlob : edtClienteDocumentoBlob_Filetype)) : edtClienteDocumentoBlob_Contenttype), false, "", edtClienteDocumentoBlob_Parameters, 0, edtClienteDocumentoBlob_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtClienteDocumentoBlob_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", "", "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNomedoarquivo_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavNomedoarquivo_Internalname, AV25NomeDoArquivo, StringUtil.RTrim( context.localUtil.Format( AV25NomeDoArquivo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNomedoarquivo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNomedoarquivo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteDocumento.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_documentosid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombodocumentosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ComboDocumentosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombodocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30ComboDocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30ComboDocumentosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodocumentosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodocumentosid_Visible, edtavCombodocumentosid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A599ClienteDocumentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtClienteDocumentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A599ClienteDocumentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A599ClienteDocumentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteDocumentoId_Visible, edtClienteDocumentoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteDocumento.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteDocumento.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteDocumentoNome_Internalname, A602ClienteDocumentoNome, StringUtil.RTrim( context.localUtil.Format( A602ClienteDocumentoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumentoNome_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteDocumentoNome_Visible, edtClienteDocumentoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteDocumento.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteDocumentoExtensao_Internalname, A603ClienteDocumentoExtensao, StringUtil.RTrim( context.localUtil.Format( A603ClienteDocumentoExtensao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumentoExtensao_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteDocumentoExtensao_Visible, edtClienteDocumentoExtensao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteDocumento.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtClienteDocumentoCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtClienteDocumentoCreatedAt_Internalname, context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A604ClienteDocumentoCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumentoCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteDocumentoCreatedAt_Visible, edtClienteDocumentoCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteDocumento.htm");
         GxWebStd.gx_bitmap( context, edtClienteDocumentoCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtClienteDocumentoCreatedAt_Visible==0)||(edtClienteDocumentoCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ClienteDocumento.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteDocumentoCreatedBy_Internalname, ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ",", ""))), ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A606ClienteDocumentoCreatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumentoCreatedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteDocumentoCreatedBy_Visible, edtClienteDocumentoCreatedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteDocumento.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtClienteDocumentoUpdatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtClienteDocumentoUpdatedAt_Internalname, context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A605ClienteDocumentoUpdatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumentoUpdatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteDocumentoUpdatedAt_Visible, edtClienteDocumentoUpdatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteDocumento.htm");
         GxWebStd.gx_bitmap( context, edtClienteDocumentoUpdatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtClienteDocumentoUpdatedAt_Visible==0)||(edtClienteDocumentoUpdatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ClienteDocumento.htm");
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
         E11282 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDOCUMENTOSID_DATA"), AV29DocumentosId_Data);
               /* Read saved values. */
               Z599ClienteDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z599ClienteDocumentoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z604ClienteDocumentoCreatedAt = context.localUtil.CToT( cgiGet( "Z604ClienteDocumentoCreatedAt"), 0);
               n604ClienteDocumentoCreatedAt = ((DateTime.MinValue==A604ClienteDocumentoCreatedAt) ? true : false);
               Z605ClienteDocumentoUpdatedAt = context.localUtil.CToT( cgiGet( "Z605ClienteDocumentoUpdatedAt"), 0);
               n605ClienteDocumentoUpdatedAt = ((DateTime.MinValue==A605ClienteDocumentoUpdatedAt) ? true : false);
               Z603ClienteDocumentoExtensao = cgiGet( "Z603ClienteDocumentoExtensao");
               n603ClienteDocumentoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( A603ClienteDocumentoExtensao)) ? true : false);
               Z602ClienteDocumentoNome = cgiGet( "Z602ClienteDocumentoNome");
               n602ClienteDocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A602ClienteDocumentoNome)) ? true : false);
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               Z405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z405DocumentosId"), ",", "."), 18, MidpointRounding.ToEven));
               n405DocumentosId = ((0==A405DocumentosId) ? true : false);
               Z606ClienteDocumentoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z606ClienteDocumentoCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n606ClienteDocumentoCreatedBy = ((0==A606ClienteDocumentoCreatedBy) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               N405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N405DocumentosId"), ",", "."), 18, MidpointRounding.ToEven));
               n405DocumentosId = ((0==A405DocumentosId) ? true : false);
               N606ClienteDocumentoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N606ClienteDocumentoCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n606ClienteDocumentoCreatedBy = ((0==A606ClienteDocumentoCreatedBy) ? true : false);
               A607ClienteNomeDoArquivo_F = cgiGet( "CLIENTENOMEDOARQUIVO_F");
               AV7ClienteDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTEDOCUMENTOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               AV24ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV23Insert_DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DOCUMENTOSID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23Insert_DocumentosId", StringUtil.LTrimStr( (decimal)(AV23Insert_DocumentosId), 9, 0));
               AV12Insert_ClienteDocumentoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEDOCUMENTOCREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ClienteDocumentoCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ClienteDocumentoCreatedBy), 4, 0));
               ajax_req_read_hidden_sdt(cgiGet( "vWWPCONTEXT"), AV8WWPContext);
               AV28index = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINDEX"), ",", "."), 18, MidpointRounding.ToEven));
               A406DocumentosDescricao = cgiGet( "DOCUMENTOSDESCRICAO");
               n406DocumentosDescricao = false;
               AV32Pgmname = cgiGet( "vPGMNAME");
               Combo_documentosid_Objectcall = cgiGet( "COMBO_DOCUMENTOSID_Objectcall");
               Combo_documentosid_Class = cgiGet( "COMBO_DOCUMENTOSID_Class");
               Combo_documentosid_Icontype = cgiGet( "COMBO_DOCUMENTOSID_Icontype");
               Combo_documentosid_Icon = cgiGet( "COMBO_DOCUMENTOSID_Icon");
               Combo_documentosid_Caption = cgiGet( "COMBO_DOCUMENTOSID_Caption");
               Combo_documentosid_Tooltip = cgiGet( "COMBO_DOCUMENTOSID_Tooltip");
               Combo_documentosid_Cls = cgiGet( "COMBO_DOCUMENTOSID_Cls");
               Combo_documentosid_Selectedvalue_set = cgiGet( "COMBO_DOCUMENTOSID_Selectedvalue_set");
               Combo_documentosid_Selectedvalue_get = cgiGet( "COMBO_DOCUMENTOSID_Selectedvalue_get");
               Combo_documentosid_Selectedtext_set = cgiGet( "COMBO_DOCUMENTOSID_Selectedtext_set");
               Combo_documentosid_Selectedtext_get = cgiGet( "COMBO_DOCUMENTOSID_Selectedtext_get");
               Combo_documentosid_Gamoauthtoken = cgiGet( "COMBO_DOCUMENTOSID_Gamoauthtoken");
               Combo_documentosid_Ddointernalname = cgiGet( "COMBO_DOCUMENTOSID_Ddointernalname");
               Combo_documentosid_Titlecontrolalign = cgiGet( "COMBO_DOCUMENTOSID_Titlecontrolalign");
               Combo_documentosid_Dropdownoptionstype = cgiGet( "COMBO_DOCUMENTOSID_Dropdownoptionstype");
               Combo_documentosid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Enabled"));
               Combo_documentosid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Visible"));
               Combo_documentosid_Titlecontrolidtoreplace = cgiGet( "COMBO_DOCUMENTOSID_Titlecontrolidtoreplace");
               Combo_documentosid_Datalisttype = cgiGet( "COMBO_DOCUMENTOSID_Datalisttype");
               Combo_documentosid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Allowmultipleselection"));
               Combo_documentosid_Datalistfixedvalues = cgiGet( "COMBO_DOCUMENTOSID_Datalistfixedvalues");
               Combo_documentosid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Isgriditem"));
               Combo_documentosid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Hasdescription"));
               Combo_documentosid_Datalistproc = cgiGet( "COMBO_DOCUMENTOSID_Datalistproc");
               Combo_documentosid_Datalistprocparametersprefix = cgiGet( "COMBO_DOCUMENTOSID_Datalistprocparametersprefix");
               Combo_documentosid_Remoteservicesparameters = cgiGet( "COMBO_DOCUMENTOSID_Remoteservicesparameters");
               Combo_documentosid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_DOCUMENTOSID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_documentosid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Includeonlyselectedoption"));
               Combo_documentosid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Includeselectalloption"));
               Combo_documentosid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Emptyitem"));
               Combo_documentosid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCUMENTOSID_Includeaddnewoption"));
               Combo_documentosid_Htmltemplate = cgiGet( "COMBO_DOCUMENTOSID_Htmltemplate");
               Combo_documentosid_Multiplevaluestype = cgiGet( "COMBO_DOCUMENTOSID_Multiplevaluestype");
               Combo_documentosid_Loadingdata = cgiGet( "COMBO_DOCUMENTOSID_Loadingdata");
               Combo_documentosid_Noresultsfound = cgiGet( "COMBO_DOCUMENTOSID_Noresultsfound");
               Combo_documentosid_Emptyitemtext = cgiGet( "COMBO_DOCUMENTOSID_Emptyitemtext");
               Combo_documentosid_Onlyselectedvalues = cgiGet( "COMBO_DOCUMENTOSID_Onlyselectedvalues");
               Combo_documentosid_Selectalltext = cgiGet( "COMBO_DOCUMENTOSID_Selectalltext");
               Combo_documentosid_Multiplevaluesseparator = cgiGet( "COMBO_DOCUMENTOSID_Multiplevaluesseparator");
               Combo_documentosid_Addnewoptiontext = cgiGet( "COMBO_DOCUMENTOSID_Addnewoptiontext");
               Combo_documentosid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_DOCUMENTOSID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               edtClienteDocumentoBlob_Filename = cgiGet( "CLIENTEDOCUMENTOBLOB_Filename");
               edtClienteDocumentoBlob_Filetype = cgiGet( "CLIENTEDOCUMENTOBLOB_Filetype");
               /* Read variables values. */
               n405DocumentosId = ((StringUtil.StrCmp(cgiGet( edtDocumentosId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCUMENTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A405DocumentosId = 0;
                  n405DocumentosId = false;
                  AssignAttri("", false, "A405DocumentosId", (n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
               }
               else
               {
                  A405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A405DocumentosId", (n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
               }
               A601ClienteDocumentoBlob = cgiGet( edtClienteDocumentoBlob_Internalname);
               n601ClienteDocumentoBlob = false;
               AssignAttri("", false, "A601ClienteDocumentoBlob", A601ClienteDocumentoBlob);
               n601ClienteDocumentoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) ? true : false);
               AV25NomeDoArquivo = cgiGet( edtavNomedoarquivo_Internalname);
               AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
               AV30ComboDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombodocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30ComboDocumentosId", StringUtil.LTrimStr( (decimal)(AV30ComboDocumentosId), 9, 0));
               A599ClienteDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteDocumentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
               n168ClienteId = ((StringUtil.StrCmp(cgiGet( edtClienteId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A168ClienteId = 0;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
               else
               {
                  A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
               A602ClienteDocumentoNome = cgiGet( edtClienteDocumentoNome_Internalname);
               n602ClienteDocumentoNome = false;
               AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
               n602ClienteDocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A602ClienteDocumentoNome)) ? true : false);
               A603ClienteDocumentoExtensao = cgiGet( edtClienteDocumentoExtensao_Internalname);
               n603ClienteDocumentoExtensao = false;
               AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
               n603ClienteDocumentoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( A603ClienteDocumentoExtensao)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtClienteDocumentoCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Cliente Documento Created At"}), 1, "CLIENTEDOCUMENTOCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtClienteDocumentoCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
                  n604ClienteDocumentoCreatedAt = false;
                  AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A604ClienteDocumentoCreatedAt = context.localUtil.CToT( cgiGet( edtClienteDocumentoCreatedAt_Internalname));
                  n604ClienteDocumentoCreatedAt = false;
                  AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n604ClienteDocumentoCreatedAt = ((DateTime.MinValue==A604ClienteDocumentoCreatedAt) ? true : false);
               n606ClienteDocumentoCreatedBy = ((StringUtil.StrCmp(cgiGet( edtClienteDocumentoCreatedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteDocumentoCreatedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteDocumentoCreatedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEDOCUMENTOCREATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtClienteDocumentoCreatedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A606ClienteDocumentoCreatedBy = 0;
                  n606ClienteDocumentoCreatedBy = false;
                  AssignAttri("", false, "A606ClienteDocumentoCreatedBy", (n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A606ClienteDocumentoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteDocumentoCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A606ClienteDocumentoCreatedBy", (n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtClienteDocumentoUpdatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Cliente Documento Updated At"}), 1, "CLIENTEDOCUMENTOUPDATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtClienteDocumentoUpdatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
                  n605ClienteDocumentoUpdatedAt = false;
                  AssignAttri("", false, "A605ClienteDocumentoUpdatedAt", context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A605ClienteDocumentoUpdatedAt = context.localUtil.CToT( cgiGet( edtClienteDocumentoUpdatedAt_Internalname));
                  n605ClienteDocumentoUpdatedAt = false;
                  AssignAttri("", false, "A605ClienteDocumentoUpdatedAt", context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n605ClienteDocumentoUpdatedAt = ((DateTime.MinValue==A605ClienteDocumentoUpdatedAt) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) )
               {
                  edtClienteDocumentoBlob_Filename = (string)(CGIGetFileName(edtClienteDocumentoBlob_Internalname));
                  edtClienteDocumentoBlob_Filetype = (string)(CGIGetFileType(edtClienteDocumentoBlob_Internalname));
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) )
               {
                  GXCCtlgxBlob = "CLIENTEDOCUMENTOBLOB" + "_gxBlob";
                  A601ClienteDocumentoBlob = cgiGet( GXCCtlgxBlob);
                  n601ClienteDocumentoBlob = false;
                  n601ClienteDocumentoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) ? true : false);
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ClienteDocumento");
               A599ClienteDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteDocumentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
               forbiddenHiddens.Add("ClienteDocumentoId", context.localUtil.Format( (decimal)(A599ClienteDocumentoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_DocumentosId", context.localUtil.Format( (decimal)(AV23Insert_DocumentosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteDocumentoCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ClienteDocumentoCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A599ClienteDocumentoId != Z599ClienteDocumentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("clientedocumento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A599ClienteDocumentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteDocumentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
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
                     sMode79 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode79;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound79 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_280( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIENTEDOCUMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtClienteDocumentoId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_DOCUMENTOSID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_documentosid.Onoptionclicked */
                           E12282 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11282 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13282 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "CLIENTEDOCUMENTOBLOB.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E14282 ();
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
            E13282 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2879( ) ;
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
            DisableAttributes2879( ) ;
         }
         AssignProp("", false, edtavNomedoarquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomedoarquivo_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombodocumentosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentosid_Enabled), 5, 0), true);
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

      protected void CONFIRM_280( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2879( ) ;
            }
            else
            {
               CheckExtendedTable2879( ) ;
               CloseExtendedTableCursors2879( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption280( )
      {
      }

      protected void E11282( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtDocumentosId_Visible = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Visible), 5, 0), true);
         AV30ComboDocumentosId = 0;
         AssignAttri("", false, "AV30ComboDocumentosId", StringUtil.LTrimStr( (decimal)(AV30ComboDocumentosId), 9, 0));
         edtavCombodocumentosid_Visible = 0;
         AssignProp("", false, edtavCombodocumentosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodocumentosid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBODOCUMENTOSID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "DocumentosId") == 0 )
               {
                  AV23Insert_DocumentosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV23Insert_DocumentosId", StringUtil.LTrimStr( (decimal)(AV23Insert_DocumentosId), 9, 0));
                  if ( ! (0==AV23Insert_DocumentosId) )
                  {
                     AV30ComboDocumentosId = AV23Insert_DocumentosId;
                     AssignAttri("", false, "AV30ComboDocumentosId", StringUtil.LTrimStr( (decimal)(AV30ComboDocumentosId), 9, 0));
                     Combo_documentosid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV30ComboDocumentosId), 9, 0));
                     ucCombo_documentosid.SendProperty(context, "", false, Combo_documentosid_Internalname, "SelectedValue_set", Combo_documentosid_Selectedvalue_set);
                     Combo_documentosid_Enabled = false;
                     ucCombo_documentosid.SendProperty(context, "", false, Combo_documentosid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentosid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteDocumentoCreatedBy") == 0 )
               {
                  AV12Insert_ClienteDocumentoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ClienteDocumentoCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ClienteDocumentoCreatedBy), 4, 0));
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         edtClienteDocumentoId_Visible = 0;
         AssignProp("", false, edtClienteDocumentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoId_Visible), 5, 0), true);
         edtClienteId_Visible = 0;
         AssignProp("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteId_Visible), 5, 0), true);
         edtClienteDocumentoNome_Visible = 0;
         AssignProp("", false, edtClienteDocumentoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoNome_Visible), 5, 0), true);
         edtClienteDocumentoExtensao_Visible = 0;
         AssignProp("", false, edtClienteDocumentoExtensao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoExtensao_Visible), 5, 0), true);
         edtClienteDocumentoCreatedAt_Visible = 0;
         AssignProp("", false, edtClienteDocumentoCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoCreatedAt_Visible), 5, 0), true);
         edtClienteDocumentoCreatedBy_Visible = 0;
         AssignProp("", false, edtClienteDocumentoCreatedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoCreatedBy_Visible), 5, 0), true);
         edtClienteDocumentoUpdatedAt_Visible = 0;
         AssignProp("", false, edtClienteDocumentoUpdatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoUpdatedAt_Visible), 5, 0), true);
      }

      protected void E13282( )
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
            GXEncryptionTmp = "clientedocumentoww"+UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
            CallWebObject(formatLink("clientedocumentoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12282( )
      {
         /* Combo_documentosid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_documentosid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "documentos"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("documentos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_documentosid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_objcol_SdtDVB_SDTComboData_Item1 = AV29DocumentosId_Data;
            new clientedocumentoloaddvcombo(context ).execute(  "DocumentosId",  "NEW",  AV7ClienteDocumentoId, out  AV16ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
            AV29DocumentosId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
            AV16ComboSelectedValue = AV10WebSession.Get("DOCUMENTOSID");
            AV10WebSession.Remove("DOCUMENTOSID");
            Combo_documentosid_Selectedvalue_set = AV16ComboSelectedValue;
            ucCombo_documentosid.SendProperty(context, "", false, Combo_documentosid_Internalname, "SelectedValue_set", Combo_documentosid_Selectedvalue_set);
            AV30ComboDocumentosId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30ComboDocumentosId", StringUtil.LTrimStr( (decimal)(AV30ComboDocumentosId), 9, 0));
         }
         else
         {
            AV30ComboDocumentosId = (int)(Math.Round(NumberUtil.Val( Combo_documentosid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30ComboDocumentosId", StringUtil.LTrimStr( (decimal)(AV30ComboDocumentosId), 9, 0));
            GXt_objcol_SdtDVB_SDTComboData_Item1 = AV29DocumentosId_Data;
            new clientedocumentoloaddvcombo(context ).execute(  "DocumentosId",  "NEW",  AV7ClienteDocumentoId, out  AV16ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
            AV29DocumentosId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29DocumentosId_Data", AV29DocumentosId_Data);
      }

      protected void S112( )
      {
         /* 'LOADCOMBODOCUMENTOSID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV29DocumentosId_Data;
         new clientedocumentoloaddvcombo(context ).execute(  "DocumentosId",  Gx_mode,  AV7ClienteDocumentoId, out  AV16ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV29DocumentosId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_documentosid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_documentosid.SendProperty(context, "", false, Combo_documentosid_Internalname, "SelectedValue_set", Combo_documentosid_Selectedvalue_set);
         AV30ComboDocumentosId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV30ComboDocumentosId", StringUtil.LTrimStr( (decimal)(AV30ComboDocumentosId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_documentosid_Enabled = false;
            ucCombo_documentosid.SendProperty(context, "", false, Combo_documentosid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_documentosid_Enabled));
         }
      }

      protected void E14282( )
      {
         /* ClienteDocumentoBlob_Controlvaluechanged Routine */
         returnInSub = false;
         AV26Nome = edtClienteDocumentoBlob_Filename;
         AV28index = (short)(StringUtil.StringSearch( AV26Nome, ".", 1));
         AssignAttri("", false, "AV28index", StringUtil.LTrimStr( (decimal)(AV28index), 4, 0));
         AV27Ext = StringUtil.Substring( AV26Nome, AV28index+1, 3);
         AV26Nome = StringUtil.Substring( AV26Nome, 1, AV28index-1);
         AV25NomeDoArquivo = edtClienteDocumentoBlob_Filename;
         AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
         /*  Sending Event outputs  */
      }

      protected void ZM2879( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z604ClienteDocumentoCreatedAt = T00283_A604ClienteDocumentoCreatedAt[0];
               Z605ClienteDocumentoUpdatedAt = T00283_A605ClienteDocumentoUpdatedAt[0];
               Z603ClienteDocumentoExtensao = T00283_A603ClienteDocumentoExtensao[0];
               Z602ClienteDocumentoNome = T00283_A602ClienteDocumentoNome[0];
               Z168ClienteId = T00283_A168ClienteId[0];
               Z405DocumentosId = T00283_A405DocumentosId[0];
               Z606ClienteDocumentoCreatedBy = T00283_A606ClienteDocumentoCreatedBy[0];
            }
            else
            {
               Z604ClienteDocumentoCreatedAt = A604ClienteDocumentoCreatedAt;
               Z605ClienteDocumentoUpdatedAt = A605ClienteDocumentoUpdatedAt;
               Z603ClienteDocumentoExtensao = A603ClienteDocumentoExtensao;
               Z602ClienteDocumentoNome = A602ClienteDocumentoNome;
               Z168ClienteId = A168ClienteId;
               Z405DocumentosId = A405DocumentosId;
               Z606ClienteDocumentoCreatedBy = A606ClienteDocumentoCreatedBy;
            }
         }
         if ( GX_JID == -24 )
         {
            Z599ClienteDocumentoId = A599ClienteDocumentoId;
            Z604ClienteDocumentoCreatedAt = A604ClienteDocumentoCreatedAt;
            Z605ClienteDocumentoUpdatedAt = A605ClienteDocumentoUpdatedAt;
            Z603ClienteDocumentoExtensao = A603ClienteDocumentoExtensao;
            Z601ClienteDocumentoBlob = A601ClienteDocumentoBlob;
            Z602ClienteDocumentoNome = A602ClienteDocumentoNome;
            Z168ClienteId = A168ClienteId;
            Z405DocumentosId = A405DocumentosId;
            Z606ClienteDocumentoCreatedBy = A606ClienteDocumentoCreatedBy;
            Z406DocumentosDescricao = A406DocumentosDescricao;
         }
      }

      protected void standaloneNotModal( )
      {
         edtClienteDocumentoId_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoId_Enabled), 5, 0), true);
         AV32Pgmname = "ClienteDocumento";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtClienteDocumentoId_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ClienteDocumentoId) )
         {
            A599ClienteDocumentoId = AV7ClienteDocumentoId;
            AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_DocumentosId) )
         {
            edtDocumentosId_Enabled = 0;
            AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocumentosId_Enabled = 1;
            AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ClienteDocumentoCreatedBy) )
         {
            edtClienteDocumentoCreatedBy_Enabled = 0;
            AssignProp("", false, edtClienteDocumentoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoCreatedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteDocumentoCreatedBy_Enabled = 1;
            AssignProp("", false, edtClienteDocumentoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoCreatedBy_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A605ClienteDocumentoUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n605ClienteDocumentoUpdatedAt = false;
            AssignAttri("", false, "A605ClienteDocumentoUpdatedAt", context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A168ClienteId = AV11Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  && (0==A168ClienteId) && ( Gx_BScreen == 0 ) )
            {
               A168ClienteId = AV24ClienteId;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
         }
         if ( IsIns( )  )
         {
            A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n604ClienteDocumentoCreatedAt = false;
            AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A604ClienteDocumentoCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n604ClienteDocumentoCreatedAt = false;
               AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXt_SdtWWPContext2 = AV8WWPContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext2) ;
            AV8WWPContext = GXt_SdtWWPContext2;
         }
      }

      protected void Load2879( )
      {
         /* Using cursor T00287 */
         pr_default.execute(5, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound79 = 1;
            A604ClienteDocumentoCreatedAt = T00287_A604ClienteDocumentoCreatedAt[0];
            n604ClienteDocumentoCreatedAt = T00287_n604ClienteDocumentoCreatedAt[0];
            AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A605ClienteDocumentoUpdatedAt = T00287_A605ClienteDocumentoUpdatedAt[0];
            n605ClienteDocumentoUpdatedAt = T00287_n605ClienteDocumentoUpdatedAt[0];
            AssignAttri("", false, "A605ClienteDocumentoUpdatedAt", context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A603ClienteDocumentoExtensao = T00287_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = T00287_n603ClienteDocumentoExtensao[0];
            AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
            A406DocumentosDescricao = T00287_A406DocumentosDescricao[0];
            n406DocumentosDescricao = T00287_n406DocumentosDescricao[0];
            A602ClienteDocumentoNome = T00287_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = T00287_n602ClienteDocumentoNome[0];
            AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
            A168ClienteId = T00287_A168ClienteId[0];
            n168ClienteId = T00287_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A405DocumentosId = T00287_A405DocumentosId[0];
            n405DocumentosId = T00287_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            A606ClienteDocumentoCreatedBy = T00287_A606ClienteDocumentoCreatedBy[0];
            n606ClienteDocumentoCreatedBy = T00287_n606ClienteDocumentoCreatedBy[0];
            AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
            A601ClienteDocumentoBlob = T00287_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = T00287_n601ClienteDocumentoBlob[0];
            AssignAttri("", false, "A601ClienteDocumentoBlob", A601ClienteDocumentoBlob);
            AssignProp("", false, edtClienteDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A601ClienteDocumentoBlob), true);
            ZM2879( -24) ;
         }
         pr_default.close(5);
         OnLoadActions2879( ) ;
      }

      protected void OnLoadActions2879( )
      {
         GXt_SdtWWPContext2 = AV8WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext2) ;
         AV8WWPContext = GXt_SdtWWPContext2;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_DocumentosId) )
         {
            A405DocumentosId = AV23Insert_DocumentosId;
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV30ComboDocumentosId) )
            {
               A405DocumentosId = 0;
               n405DocumentosId = false;
               AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
               n405DocumentosId = true;
               n405DocumentosId = true;
               AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV30ComboDocumentosId) )
               {
                  A405DocumentosId = AV30ComboDocumentosId;
                  n405DocumentosId = false;
                  AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A405DocumentosId) )
                  {
                     A405DocumentosId = 0;
                     n405DocumentosId = false;
                     AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
                     n405DocumentosId = true;
                     n405DocumentosId = true;
                     AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ClienteDocumentoCreatedBy) )
         {
            A606ClienteDocumentoCreatedBy = AV12Insert_ClienteDocumentoCreatedBy;
            n606ClienteDocumentoCreatedBy = false;
            AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A606ClienteDocumentoCreatedBy = AV8WWPContext.gxTpr_Userid;
               n606ClienteDocumentoCreatedBy = false;
               AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( (0==A606ClienteDocumentoCreatedBy) )
               {
                  A606ClienteDocumentoCreatedBy = 0;
                  n606ClienteDocumentoCreatedBy = false;
                  AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
                  n606ClienteDocumentoCreatedBy = true;
                  n606ClienteDocumentoCreatedBy = true;
                  AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
               }
            }
         }
         AV25NomeDoArquivo = edtClienteDocumentoBlob_Filename;
         AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
         AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
         AssignAttri("", false, "AV28index", StringUtil.LTrimStr( (decimal)(AV28index), 4, 0));
         A602ClienteDocumentoNome = StringUtil.Substring( AV25NomeDoArquivo, 1, AV28index-1);
         n602ClienteDocumentoNome = false;
         AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
         A603ClienteDocumentoExtensao = edtClienteDocumentoBlob_Filetype;
         n603ClienteDocumentoExtensao = false;
         AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
         A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
         AssignAttri("", false, "A607ClienteNomeDoArquivo_F", A607ClienteNomeDoArquivo_F);
      }

      protected void CheckExtendedTable2879( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXt_SdtWWPContext2 = AV8WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext2) ;
         AV8WWPContext = GXt_SdtWWPContext2;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_DocumentosId) )
         {
            A405DocumentosId = AV23Insert_DocumentosId;
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV30ComboDocumentosId) )
            {
               A405DocumentosId = 0;
               n405DocumentosId = false;
               AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
               n405DocumentosId = true;
               n405DocumentosId = true;
               AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV30ComboDocumentosId) )
               {
                  A405DocumentosId = AV30ComboDocumentosId;
                  n405DocumentosId = false;
                  AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A405DocumentosId) )
                  {
                     A405DocumentosId = 0;
                     n405DocumentosId = false;
                     AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
                     n405DocumentosId = true;
                     n405DocumentosId = true;
                     AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ClienteDocumentoCreatedBy) )
         {
            A606ClienteDocumentoCreatedBy = AV12Insert_ClienteDocumentoCreatedBy;
            n606ClienteDocumentoCreatedBy = false;
            AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A606ClienteDocumentoCreatedBy = AV8WWPContext.gxTpr_Userid;
               n606ClienteDocumentoCreatedBy = false;
               AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( (0==A606ClienteDocumentoCreatedBy) )
               {
                  A606ClienteDocumentoCreatedBy = 0;
                  n606ClienteDocumentoCreatedBy = false;
                  AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
                  n606ClienteDocumentoCreatedBy = true;
                  n606ClienteDocumentoCreatedBy = true;
                  AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
               }
            }
         }
         /* Using cursor T00284 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T00285 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A406DocumentosDescricao = T00285_A406DocumentosDescricao[0];
         n406DocumentosDescricao = T00285_n406DocumentosDescricao[0];
         pr_default.close(3);
         if ( (0==A405DocumentosId) )
         {
            GX_msglist.addItem("Tipo de documento é obrigatório", 1, "DOCUMENTOSID");
            AnyError = 1;
            GX_FocusControl = edtDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         AV25NomeDoArquivo = edtClienteDocumentoBlob_Filename;
         AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
         AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
         AssignAttri("", false, "AV28index", StringUtil.LTrimStr( (decimal)(AV28index), 4, 0));
         A602ClienteDocumentoNome = StringUtil.Substring( AV25NomeDoArquivo, 1, AV28index-1);
         n602ClienteDocumentoNome = false;
         AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
         A603ClienteDocumentoExtensao = edtClienteDocumentoBlob_Filetype;
         n603ClienteDocumentoExtensao = false;
         AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) )
         {
            GX_msglist.addItem("Selecione um arquivo", 1, "CLIENTEDOCUMENTOBLOB");
            AnyError = 1;
            GX_FocusControl = edtClienteDocumentoBlob_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
         AssignAttri("", false, "A607ClienteNomeDoArquivo_F", A607ClienteNomeDoArquivo_F);
         /* Using cursor T00286 */
         pr_default.execute(4, new Object[] {n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A606ClienteDocumentoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Documento Created By'.", "ForeignKeyNotFound", 1, "CLIENTEDOCUMENTOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtClienteDocumentoCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2879( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_25( int A168ClienteId )
      {
         /* Using cursor T00288 */
         pr_default.execute(6, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_26( int A405DocumentosId )
      {
         /* Using cursor T00289 */
         pr_default.execute(7, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A406DocumentosDescricao = T00289_A406DocumentosDescricao[0];
         n406DocumentosDescricao = T00289_n406DocumentosDescricao[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A406DocumentosDescricao)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_27( short A606ClienteDocumentoCreatedBy )
      {
         /* Using cursor T002810 */
         pr_default.execute(8, new Object[] {n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A606ClienteDocumentoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Documento Created By'.", "ForeignKeyNotFound", 1, "CLIENTEDOCUMENTOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtClienteDocumentoCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey2879( )
      {
         /* Using cursor T002811 */
         pr_default.execute(9, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00283 */
         pr_default.execute(1, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2879( 24) ;
            RcdFound79 = 1;
            A599ClienteDocumentoId = T00283_A599ClienteDocumentoId[0];
            AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
            A604ClienteDocumentoCreatedAt = T00283_A604ClienteDocumentoCreatedAt[0];
            n604ClienteDocumentoCreatedAt = T00283_n604ClienteDocumentoCreatedAt[0];
            AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A605ClienteDocumentoUpdatedAt = T00283_A605ClienteDocumentoUpdatedAt[0];
            n605ClienteDocumentoUpdatedAt = T00283_n605ClienteDocumentoUpdatedAt[0];
            AssignAttri("", false, "A605ClienteDocumentoUpdatedAt", context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A603ClienteDocumentoExtensao = T00283_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = T00283_n603ClienteDocumentoExtensao[0];
            AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
            A602ClienteDocumentoNome = T00283_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = T00283_n602ClienteDocumentoNome[0];
            AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
            A168ClienteId = T00283_A168ClienteId[0];
            n168ClienteId = T00283_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A405DocumentosId = T00283_A405DocumentosId[0];
            n405DocumentosId = T00283_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            A606ClienteDocumentoCreatedBy = T00283_A606ClienteDocumentoCreatedBy[0];
            n606ClienteDocumentoCreatedBy = T00283_n606ClienteDocumentoCreatedBy[0];
            AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
            A601ClienteDocumentoBlob = T00283_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = T00283_n601ClienteDocumentoBlob[0];
            AssignAttri("", false, "A601ClienteDocumentoBlob", A601ClienteDocumentoBlob);
            AssignProp("", false, edtClienteDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A601ClienteDocumentoBlob), true);
            Z599ClienteDocumentoId = A599ClienteDocumentoId;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2879( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey2879( ) ;
            }
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey2879( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2879( ) ;
         if ( RcdFound79 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound79 = 0;
         /* Using cursor T002812 */
         pr_default.execute(10, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002812_A599ClienteDocumentoId[0] < A599ClienteDocumentoId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002812_A599ClienteDocumentoId[0] > A599ClienteDocumentoId ) ) )
            {
               A599ClienteDocumentoId = T002812_A599ClienteDocumentoId[0];
               AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
               RcdFound79 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound79 = 0;
         /* Using cursor T002813 */
         pr_default.execute(11, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002813_A599ClienteDocumentoId[0] > A599ClienteDocumentoId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002813_A599ClienteDocumentoId[0] < A599ClienteDocumentoId ) ) )
            {
               A599ClienteDocumentoId = T002813_A599ClienteDocumentoId[0];
               AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
               RcdFound79 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2879( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2879( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
               {
                  A599ClienteDocumentoId = Z599ClienteDocumentoId;
                  AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEDOCUMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2879( ) ;
                  GX_FocusControl = edtDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2879( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEDOCUMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteDocumentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocumentosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2879( ) ;
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
         if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
         {
            A599ClienteDocumentoId = Z599ClienteDocumentoId;
            AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEDOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtClienteDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2879( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00282 */
            pr_default.execute(0, new Object[] {A599ClienteDocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteDocumento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z604ClienteDocumentoCreatedAt != T00282_A604ClienteDocumentoCreatedAt[0] ) || ( Z605ClienteDocumentoUpdatedAt != T00282_A605ClienteDocumentoUpdatedAt[0] ) || ( StringUtil.StrCmp(Z603ClienteDocumentoExtensao, T00282_A603ClienteDocumentoExtensao[0]) != 0 ) || ( StringUtil.StrCmp(Z602ClienteDocumentoNome, T00282_A602ClienteDocumentoNome[0]) != 0 ) || ( Z168ClienteId != T00282_A168ClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z405DocumentosId != T00282_A405DocumentosId[0] ) || ( Z606ClienteDocumentoCreatedBy != T00282_A606ClienteDocumentoCreatedBy[0] ) )
            {
               if ( Z604ClienteDocumentoCreatedAt != T00282_A604ClienteDocumentoCreatedAt[0] )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"ClienteDocumentoCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z604ClienteDocumentoCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00282_A604ClienteDocumentoCreatedAt[0]);
               }
               if ( Z605ClienteDocumentoUpdatedAt != T00282_A605ClienteDocumentoUpdatedAt[0] )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"ClienteDocumentoUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z605ClienteDocumentoUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00282_A605ClienteDocumentoUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z603ClienteDocumentoExtensao, T00282_A603ClienteDocumentoExtensao[0]) != 0 )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"ClienteDocumentoExtensao");
                  GXUtil.WriteLogRaw("Old: ",Z603ClienteDocumentoExtensao);
                  GXUtil.WriteLogRaw("Current: ",T00282_A603ClienteDocumentoExtensao[0]);
               }
               if ( StringUtil.StrCmp(Z602ClienteDocumentoNome, T00282_A602ClienteDocumentoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"ClienteDocumentoNome");
                  GXUtil.WriteLogRaw("Old: ",Z602ClienteDocumentoNome);
                  GXUtil.WriteLogRaw("Current: ",T00282_A602ClienteDocumentoNome[0]);
               }
               if ( Z168ClienteId != T00282_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00282_A168ClienteId[0]);
               }
               if ( Z405DocumentosId != T00282_A405DocumentosId[0] )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"DocumentosId");
                  GXUtil.WriteLogRaw("Old: ",Z405DocumentosId);
                  GXUtil.WriteLogRaw("Current: ",T00282_A405DocumentosId[0]);
               }
               if ( Z606ClienteDocumentoCreatedBy != T00282_A606ClienteDocumentoCreatedBy[0] )
               {
                  GXUtil.WriteLog("clientedocumento:[seudo value changed for attri]"+"ClienteDocumentoCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z606ClienteDocumentoCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T00282_A606ClienteDocumentoCreatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteDocumento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2879( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2879( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2879( 0) ;
            CheckOptimisticConcurrency2879( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2879( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2879( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002814 */
                     pr_default.execute(12, new Object[] {n604ClienteDocumentoCreatedAt, A604ClienteDocumentoCreatedAt, n605ClienteDocumentoUpdatedAt, A605ClienteDocumentoUpdatedAt, n603ClienteDocumentoExtensao, A603ClienteDocumentoExtensao, n601ClienteDocumentoBlob, A601ClienteDocumentoBlob, n602ClienteDocumentoNome, A602ClienteDocumentoNome, n168ClienteId, A168ClienteId, n405DocumentosId, A405DocumentosId, n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002815 */
                     pr_default.execute(13);
                     A599ClienteDocumentoId = T002815_A599ClienteDocumentoId[0];
                     AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption280( ) ;
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
               Load2879( ) ;
            }
            EndLevel2879( ) ;
         }
         CloseExtendedTableCursors2879( ) ;
      }

      protected void Update2879( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2879( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2879( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2879( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2879( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002816 */
                     pr_default.execute(14, new Object[] {n604ClienteDocumentoCreatedAt, A604ClienteDocumentoCreatedAt, n605ClienteDocumentoUpdatedAt, A605ClienteDocumentoUpdatedAt, n603ClienteDocumentoExtensao, A603ClienteDocumentoExtensao, n602ClienteDocumentoNome, A602ClienteDocumentoNome, n168ClienteId, A168ClienteId, n405DocumentosId, A405DocumentosId, n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy, A599ClienteDocumentoId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteDocumento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2879( ) ;
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
            EndLevel2879( ) ;
         }
         CloseExtendedTableCursors2879( ) ;
      }

      protected void DeferredUpdate2879( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002817 */
            pr_default.execute(15, new Object[] {n601ClienteDocumentoBlob, A601ClienteDocumentoBlob, A599ClienteDocumentoId});
            pr_default.close(15);
            pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
         }
      }

      protected void delete( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2879( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2879( ) ;
            AfterConfirm2879( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2879( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002818 */
                  pr_default.execute(16, new Object[] {A599ClienteDocumentoId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2879( ) ;
         Gx_mode = sMode79;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2879( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_SdtWWPContext2 = AV8WWPContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext2) ;
            AV8WWPContext = GXt_SdtWWPContext2;
            /* Using cursor T002819 */
            pr_default.execute(17, new Object[] {n405DocumentosId, A405DocumentosId});
            A406DocumentosDescricao = T002819_A406DocumentosDescricao[0];
            n406DocumentosDescricao = T002819_n406DocumentosDescricao[0];
            pr_default.close(17);
            AV25NomeDoArquivo = edtClienteDocumentoBlob_Filename;
            AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
            AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
            AssignAttri("", false, "AV28index", StringUtil.LTrimStr( (decimal)(AV28index), 4, 0));
            A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
            AssignAttri("", false, "A607ClienteNomeDoArquivo_F", A607ClienteNomeDoArquivo_F);
         }
      }

      protected void EndLevel2879( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2879( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("clientedocumento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues280( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("clientedocumento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2879( )
      {
         /* Scan By routine */
         /* Using cursor T002820 */
         pr_default.execute(18);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound79 = 1;
            A599ClienteDocumentoId = T002820_A599ClienteDocumentoId[0];
            AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2879( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound79 = 1;
            A599ClienteDocumentoId = T002820_A599ClienteDocumentoId[0];
            AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
         }
      }

      protected void ScanEnd2879( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2879( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2879( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2879( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2879( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2879( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2879( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2879( )
      {
         edtDocumentosId_Enabled = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         edtClienteDocumentoBlob_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoBlob_Enabled), 5, 0), true);
         edtavNomedoarquivo_Enabled = 0;
         AssignProp("", false, edtavNomedoarquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomedoarquivo_Enabled), 5, 0), true);
         edtavCombodocumentosid_Enabled = 0;
         AssignProp("", false, edtavCombodocumentosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodocumentosid_Enabled), 5, 0), true);
         edtClienteDocumentoId_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteDocumentoNome_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoNome_Enabled), 5, 0), true);
         edtClienteDocumentoExtensao_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoExtensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoExtensao_Enabled), 5, 0), true);
         edtClienteDocumentoCreatedAt_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoCreatedAt_Enabled), 5, 0), true);
         edtClienteDocumentoCreatedBy_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoCreatedBy_Enabled), 5, 0), true);
         edtClienteDocumentoUpdatedAt_Enabled = 0;
         AssignProp("", false, edtClienteDocumentoUpdatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumentoUpdatedAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2879( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues280( )
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
         GXEncryptionTmp = "clientedocumento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClienteDocumentoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV24ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("clientedocumento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ClienteDocumento");
         forbiddenHiddens.Add("ClienteDocumentoId", context.localUtil.Format( (decimal)(A599ClienteDocumentoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_DocumentosId", context.localUtil.Format( (decimal)(AV23Insert_DocumentosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteDocumentoCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ClienteDocumentoCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clientedocumento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z599ClienteDocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z599ClienteDocumentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z604ClienteDocumentoCreatedAt", context.localUtil.TToC( Z604ClienteDocumentoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z605ClienteDocumentoUpdatedAt", context.localUtil.TToC( Z605ClienteDocumentoUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z603ClienteDocumentoExtensao", Z603ClienteDocumentoExtensao);
         GxWebStd.gx_hidden_field( context, "Z602ClienteDocumentoNome", Z602ClienteDocumentoNome);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z606ClienteDocumentoCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z606ClienteDocumentoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N606ClienteDocumentoCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCUMENTOSID_DATA", AV29DocumentosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCUMENTOSID_DATA", AV29DocumentosId_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34Documentosid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34Documentosid), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTENOMEDOARQUIVO_F", A607ClienteNomeDoArquivo_F);
         GxWebStd.gx_hidden_field( context, "vCLIENTEDOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteDocumentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEDOCUMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteDocumentoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Insert_DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEDOCUMENTOCREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ClienteDocumentoCreatedBy), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV8WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV8WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "vINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28index), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCUMENTOSDESCRICAO", A406DocumentosDescricao);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GXCCtlgxBlob = "CLIENTEDOCUMENTOBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A601ClienteDocumentoBlob);
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOSID_Objectcall", StringUtil.RTrim( Combo_documentosid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOSID_Cls", StringUtil.RTrim( Combo_documentosid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOSID_Selectedvalue_set", StringUtil.RTrim( Combo_documentosid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOSID_Enabled", StringUtil.BoolToStr( Combo_documentosid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOSID_Emptyitem", StringUtil.BoolToStr( Combo_documentosid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCUMENTOSID_Includeaddnewoption", StringUtil.BoolToStr( Combo_documentosid_Includeaddnewoption));
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
         GxWebStd.gx_hidden_field( context, "CLIENTEDOCUMENTOBLOB_Filename", StringUtil.RTrim( edtClienteDocumentoBlob_Filename));
         GxWebStd.gx_hidden_field( context, "CLIENTEDOCUMENTOBLOB_Filetype", StringUtil.RTrim( edtClienteDocumentoBlob_Filetype));
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
         GXEncryptionTmp = "clientedocumento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClienteDocumentoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV24ClienteId,9,0));
         return formatLink("clientedocumento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ClienteDocumento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documento do cliente" ;
      }

      protected void InitializeNonKey2879( )
      {
         A405DocumentosId = 0;
         n405DocumentosId = false;
         AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         n405DocumentosId = ((0==A405DocumentosId) ? true : false);
         A606ClienteDocumentoCreatedBy = 0;
         n606ClienteDocumentoCreatedBy = false;
         AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
         n606ClienteDocumentoCreatedBy = ((0==A606ClienteDocumentoCreatedBy) ? true : false);
         A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         n605ClienteDocumentoUpdatedAt = false;
         AssignAttri("", false, "A605ClienteDocumentoUpdatedAt", context.localUtil.TToC( A605ClienteDocumentoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         n605ClienteDocumentoUpdatedAt = ((DateTime.MinValue==A605ClienteDocumentoUpdatedAt) ? true : false);
         AV25NomeDoArquivo = "";
         AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
         A603ClienteDocumentoExtensao = "";
         n603ClienteDocumentoExtensao = false;
         AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
         n603ClienteDocumentoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( A603ClienteDocumentoExtensao)) ? true : false);
         A607ClienteNomeDoArquivo_F = "";
         AssignAttri("", false, "A607ClienteNomeDoArquivo_F", A607ClienteNomeDoArquivo_F);
         A406DocumentosDescricao = "";
         n406DocumentosDescricao = false;
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         A601ClienteDocumentoBlob = "";
         n601ClienteDocumentoBlob = false;
         AssignAttri("", false, "A601ClienteDocumentoBlob", A601ClienteDocumentoBlob);
         AssignProp("", false, edtClienteDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A601ClienteDocumentoBlob), true);
         n601ClienteDocumentoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) ? true : false);
         A602ClienteDocumentoNome = "";
         n602ClienteDocumentoNome = false;
         AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
         n602ClienteDocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A602ClienteDocumentoNome)) ? true : false);
         AV28index = 0;
         AssignAttri("", false, "AV28index", StringUtil.LTrimStr( (decimal)(AV28index), 4, 0));
         A168ClienteId = AV24ClienteId;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         Z604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z603ClienteDocumentoExtensao = "";
         Z602ClienteDocumentoNome = "";
         Z168ClienteId = 0;
         Z405DocumentosId = 0;
         Z606ClienteDocumentoCreatedBy = 0;
      }

      protected void InitAll2879( )
      {
         A599ClienteDocumentoId = 0;
         AssignAttri("", false, "A599ClienteDocumentoId", StringUtil.LTrimStr( (decimal)(A599ClienteDocumentoId), 9, 0));
         InitializeNonKey2879( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A168ClienteId = i168ClienteId;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         A604ClienteDocumentoCreatedAt = i604ClienteDocumentoCreatedAt;
         n604ClienteDocumentoCreatedAt = false;
         AssignAttri("", false, "A604ClienteDocumentoCreatedAt", context.localUtil.TToC( A604ClienteDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019192241", true, true);
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
         context.AddJavascriptSource("clientedocumento.js", "?202561019192242", false, true);
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
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         lblTextblockdocumentosid_Internalname = "TEXTBLOCKDOCUMENTOSID";
         Combo_documentosid_Internalname = "COMBO_DOCUMENTOSID";
         edtDocumentosId_Internalname = "DOCUMENTOSID";
         divTablesplitteddocumentosid_Internalname = "TABLESPLITTEDDOCUMENTOSID";
         edtClienteDocumentoBlob_Internalname = "CLIENTEDOCUMENTOBLOB";
         edtavNomedoarquivo_Internalname = "vNOMEDOARQUIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombodocumentosid_Internalname = "vCOMBODOCUMENTOSID";
         divSectionattribute_documentosid_Internalname = "SECTIONATTRIBUTE_DOCUMENTOSID";
         edtClienteDocumentoId_Internalname = "CLIENTEDOCUMENTOID";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteDocumentoNome_Internalname = "CLIENTEDOCUMENTONOME";
         edtClienteDocumentoExtensao_Internalname = "CLIENTEDOCUMENTOEXTENSAO";
         edtClienteDocumentoCreatedAt_Internalname = "CLIENTEDOCUMENTOCREATEDAT";
         edtClienteDocumentoCreatedBy_Internalname = "CLIENTEDOCUMENTOCREATEDBY";
         edtClienteDocumentoUpdatedAt_Internalname = "CLIENTEDOCUMENTOUPDATEDAT";
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
         Form.Caption = "Documento do cliente";
         edtClienteDocumentoBlob_Filename = "";
         edtClienteDocumentoUpdatedAt_Jsonclick = "";
         edtClienteDocumentoUpdatedAt_Enabled = 1;
         edtClienteDocumentoUpdatedAt_Visible = 1;
         edtClienteDocumentoCreatedBy_Jsonclick = "";
         edtClienteDocumentoCreatedBy_Enabled = 1;
         edtClienteDocumentoCreatedBy_Visible = 1;
         edtClienteDocumentoCreatedAt_Jsonclick = "";
         edtClienteDocumentoCreatedAt_Enabled = 1;
         edtClienteDocumentoCreatedAt_Visible = 1;
         edtClienteDocumentoExtensao_Jsonclick = "";
         edtClienteDocumentoExtensao_Enabled = 1;
         edtClienteDocumentoExtensao_Visible = 1;
         edtClienteDocumentoNome_Jsonclick = "";
         edtClienteDocumentoNome_Enabled = 1;
         edtClienteDocumentoNome_Visible = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtClienteId_Visible = 1;
         edtClienteDocumentoId_Jsonclick = "";
         edtClienteDocumentoId_Enabled = 0;
         edtClienteDocumentoId_Visible = 1;
         edtavCombodocumentosid_Jsonclick = "";
         edtavCombodocumentosid_Enabled = 0;
         edtavCombodocumentosid_Visible = 1;
         edtavNomedoarquivo_Jsonclick = "";
         edtavNomedoarquivo_Enabled = 0;
         edtClienteDocumentoBlob_Jsonclick = "";
         edtClienteDocumentoBlob_Parameters = "";
         edtClienteDocumentoBlob_Contenttype = "";
         edtClienteDocumentoBlob_Filetype = "";
         edtClienteDocumentoBlob_Enabled = 1;
         edtDocumentosId_Jsonclick = "";
         edtDocumentosId_Enabled = 1;
         edtDocumentosId_Visible = 1;
         Combo_documentosid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_documentosid_Emptyitem = Convert.ToBoolean( 0);
         Combo_documentosid_Cls = "ExtendedCombo AttributeFL";
         Combo_documentosid_Enabled = Convert.ToBoolean( -1);
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

      protected void GX15ASAWWPCONTEXT2879( )
      {
         GXt_SdtWWPContext2 = AV8WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext2) ;
         AV8WWPContext = GXt_SdtWWPContext2;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV8WWPContext.ToXml(false, true, "", "")))+"\"") ;
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

      public void Valid_Documentosid( )
      {
         n406DocumentosDescricao = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_DocumentosId) )
         {
            A405DocumentosId = AV23Insert_DocumentosId;
            n405DocumentosId = false;
         }
         else
         {
            if ( (0==AV30ComboDocumentosId) )
            {
               A405DocumentosId = 0;
               n405DocumentosId = false;
               n405DocumentosId = true;
               n405DocumentosId = true;
            }
            else
            {
               if ( ! (0==AV30ComboDocumentosId) )
               {
                  A405DocumentosId = AV30ComboDocumentosId;
                  n405DocumentosId = false;
               }
               else
               {
                  if ( (0==A405DocumentosId) )
                  {
                     A405DocumentosId = 0;
                     n405DocumentosId = false;
                     n405DocumentosId = true;
                     n405DocumentosId = true;
                  }
               }
            }
         }
         /* Using cursor T002819 */
         pr_default.execute(17, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
            }
         }
         A406DocumentosDescricao = T002819_A406DocumentosDescricao[0];
         n406DocumentosDescricao = T002819_n406DocumentosDescricao[0];
         pr_default.close(17);
         if ( (0==A405DocumentosId) )
         {
            GX_msglist.addItem("Tipo de documento é obrigatório", 1, "DOCUMENTOSID");
            AnyError = 1;
            GX_FocusControl = edtDocumentosId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
      }

      public void Valid_Clientedocumentoblob( )
      {
         n601ClienteDocumentoBlob = false;
         n602ClienteDocumentoNome = false;
         n603ClienteDocumentoExtensao = false;
         AV25NomeDoArquivo = edtClienteDocumentoBlob_Filename;
         AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
         A602ClienteDocumentoNome = StringUtil.Substring( AV25NomeDoArquivo, 1, AV28index-1);
         n602ClienteDocumentoNome = false;
         A603ClienteDocumentoExtensao = edtClienteDocumentoBlob_Filetype;
         n603ClienteDocumentoExtensao = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) )
         {
            GX_msglist.addItem("Selecione um arquivo", 1, "CLIENTEDOCUMENTOBLOB");
            AnyError = 1;
            GX_FocusControl = edtClienteDocumentoBlob_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "AV25NomeDoArquivo", AV25NomeDoArquivo);
         AssignAttri("", false, "AV28index", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28index), 4, 0, ".", "")));
         AssignAttri("", false, "A602ClienteDocumentoNome", A602ClienteDocumentoNome);
         AssignAttri("", false, "A603ClienteDocumentoExtensao", A603ClienteDocumentoExtensao);
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T002821 */
         pr_default.execute(19, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clientedocumentocreatedby( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ClienteDocumentoCreatedBy) )
         {
            A606ClienteDocumentoCreatedBy = AV12Insert_ClienteDocumentoCreatedBy;
            n606ClienteDocumentoCreatedBy = false;
         }
         else
         {
            if ( IsIns( )  )
            {
               A606ClienteDocumentoCreatedBy = AV8WWPContext.gxTpr_Userid;
               n606ClienteDocumentoCreatedBy = false;
            }
            else
            {
               if ( (0==A606ClienteDocumentoCreatedBy) )
               {
                  A606ClienteDocumentoCreatedBy = 0;
                  n606ClienteDocumentoCreatedBy = false;
                  n606ClienteDocumentoCreatedBy = true;
                  n606ClienteDocumentoCreatedBy = true;
               }
            }
         }
         /* Using cursor T002822 */
         pr_default.execute(20, new Object[] {n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A606ClienteDocumentoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Documento Created By'.", "ForeignKeyNotFound", 1, "CLIENTEDOCUMENTOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtClienteDocumentoCreatedBy_Internalname;
            }
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A606ClienteDocumentoCreatedBy", ((0==A606ClienteDocumentoCreatedBy)&&IsIns( )||n606ClienteDocumentoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A606ClienteDocumentoCreatedBy), 4, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ClienteDocumentoId","fld":"vCLIENTEDOCUMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV24ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV34Documentosid","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7ClienteDocumentoId","fld":"vCLIENTEDOCUMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV24ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A599ClienteDocumentoId","fld":"CLIENTEDOCUMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23Insert_DocumentosId","fld":"vINSERT_DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_ClienteDocumentoCreatedBy","fld":"vINSERT_CLIENTEDOCUMENTOCREATEDBY","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13282","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("COMBO_DOCUMENTOSID.ONOPTIONCLICKED","""{"handler":"E12282","iparms":[{"av":"Combo_documentosid_Selectedvalue_get","ctrl":"COMBO_DOCUMENTOSID","prop":"SelectedValue_get"},{"av":"AV34Documentosid","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7ClienteDocumentoId","fld":"vCLIENTEDOCUMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("COMBO_DOCUMENTOSID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_documentosid_Selectedvalue_set","ctrl":"COMBO_DOCUMENTOSID","prop":"SelectedValue_set"},{"av":"AV29DocumentosId_Data","fld":"vDOCUMENTOSID_DATA","type":""},{"av":"AV30ComboDocumentosId","fld":"vCOMBODOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("CLIENTEDOCUMENTOBLOB.CONTROLVALUECHANGED","""{"handler":"E14282","iparms":[{"av":"edtClienteDocumentoBlob_Filename","ctrl":"CLIENTEDOCUMENTOBLOB","prop":"Filename"}]""");
         setEventMetadata("CLIENTEDOCUMENTOBLOB.CONTROLVALUECHANGED",""","oparms":[{"av":"AV28index","fld":"vINDEX","pic":"ZZZ9","type":"int"},{"av":"AV25NomeDoArquivo","fld":"vNOMEDOARQUIVO","type":"svchar"}]}""");
         setEventMetadata("VALID_DOCUMENTOSID","""{"handler":"Valid_Documentosid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV23Insert_DocumentosId","fld":"vINSERT_DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV30ComboDocumentosId","fld":"vCOMBODOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","nullAv":"n405DocumentosId","type":"int"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"}]""");
         setEventMetadata("VALID_DOCUMENTOSID",""","oparms":[{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","nullAv":"n405DocumentosId","type":"int"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"}]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTOBLOB","""{"handler":"Valid_Clientedocumentoblob","iparms":[{"av":"A601ClienteDocumentoBlob","fld":"CLIENTEDOCUMENTOBLOB","type":"bitstr"},{"av":"AV25NomeDoArquivo","fld":"vNOMEDOARQUIVO","type":"svchar"},{"av":"AV28index","fld":"vINDEX","pic":"ZZZ9","type":"int"},{"av":"A602ClienteDocumentoNome","fld":"CLIENTEDOCUMENTONOME","type":"svchar"},{"av":"A603ClienteDocumentoExtensao","fld":"CLIENTEDOCUMENTOEXTENSAO","type":"svchar"}]""");
         setEventMetadata("VALID_CLIENTEDOCUMENTOBLOB",""","oparms":[{"av":"AV25NomeDoArquivo","fld":"vNOMEDOARQUIVO","type":"svchar"},{"av":"AV28index","fld":"vINDEX","pic":"ZZZ9","type":"int"},{"av":"A602ClienteDocumentoNome","fld":"CLIENTEDOCUMENTONOME","type":"svchar"},{"av":"A603ClienteDocumentoExtensao","fld":"CLIENTEDOCUMENTOEXTENSAO","type":"svchar"}]}""");
         setEventMetadata("VALIDV_NOMEDOARQUIVO","""{"handler":"Validv_Nomedoarquivo","iparms":[]}""");
         setEventMetadata("VALIDV_COMBODOCUMENTOSID","""{"handler":"Validv_Combodocumentosid","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTOID","""{"handler":"Valid_Clientedocumentoid","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTONOME","""{"handler":"Valid_Clientedocumentonome","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTOEXTENSAO","""{"handler":"Valid_Clientedocumentoextensao","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTOCREATEDBY","""{"handler":"Valid_Clientedocumentocreatedby","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_ClienteDocumentoCreatedBy","fld":"vINSERT_CLIENTEDOCUMENTOCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV8WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"A606ClienteDocumentoCreatedBy","fld":"CLIENTEDOCUMENTOCREATEDBY","pic":"ZZZ9","nullAv":"n606ClienteDocumentoCreatedBy","type":"int"}]""");
         setEventMetadata("VALID_CLIENTEDOCUMENTOCREATEDBY",""","oparms":[{"av":"A606ClienteDocumentoCreatedBy","fld":"CLIENTEDOCUMENTOCREATEDBY","pic":"ZZZ9","nullAv":"n606ClienteDocumentoCreatedBy","type":"int"}]}""");
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
         pr_default.close(19);
         pr_default.close(17);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z603ClienteDocumentoExtensao = "";
         Z602ClienteDocumentoNome = "";
         Combo_documentosid_Selectedvalue_get = "";
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
         lblTextblockdocumentosid_Jsonclick = "";
         ucCombo_documentosid = new GXUserControl();
         Combo_documentosid_Caption = "";
         AV29DocumentosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A601ClienteDocumentoBlob = "";
         AV25NomeDoArquivo = "";
         A602ClienteDocumentoNome = "";
         A603ClienteDocumentoExtensao = "";
         A604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         A605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         A607ClienteNomeDoArquivo_F = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         A406DocumentosDescricao = "";
         AV32Pgmname = "";
         Combo_documentosid_Objectcall = "";
         Combo_documentosid_Class = "";
         Combo_documentosid_Icontype = "";
         Combo_documentosid_Icon = "";
         Combo_documentosid_Tooltip = "";
         Combo_documentosid_Selectedvalue_set = "";
         Combo_documentosid_Selectedtext_set = "";
         Combo_documentosid_Selectedtext_get = "";
         Combo_documentosid_Gamoauthtoken = "";
         Combo_documentosid_Ddointernalname = "";
         Combo_documentosid_Titlecontrolalign = "";
         Combo_documentosid_Dropdownoptionstype = "";
         Combo_documentosid_Titlecontrolidtoreplace = "";
         Combo_documentosid_Datalisttype = "";
         Combo_documentosid_Datalistfixedvalues = "";
         Combo_documentosid_Datalistproc = "";
         Combo_documentosid_Datalistprocparametersprefix = "";
         Combo_documentosid_Remoteservicesparameters = "";
         Combo_documentosid_Htmltemplate = "";
         Combo_documentosid_Multiplevaluestype = "";
         Combo_documentosid_Loadingdata = "";
         Combo_documentosid_Noresultsfound = "";
         Combo_documentosid_Emptyitemtext = "";
         Combo_documentosid_Onlyselectedvalues = "";
         Combo_documentosid_Selectalltext = "";
         Combo_documentosid_Multiplevaluesseparator = "";
         Combo_documentosid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         GXCCtlgxBlob = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode79 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXEncryptionTmp = "";
         AV16ComboSelectedValue = "";
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV26Nome = "";
         AV27Ext = "";
         Z601ClienteDocumentoBlob = "";
         Z406DocumentosDescricao = "";
         T00287_A599ClienteDocumentoId = new int[1] ;
         T00287_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00287_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         T00287_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00287_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         T00287_A603ClienteDocumentoExtensao = new string[] {""} ;
         T00287_n603ClienteDocumentoExtensao = new bool[] {false} ;
         T00287_A406DocumentosDescricao = new string[] {""} ;
         T00287_n406DocumentosDescricao = new bool[] {false} ;
         T00287_A602ClienteDocumentoNome = new string[] {""} ;
         T00287_n602ClienteDocumentoNome = new bool[] {false} ;
         T00287_A168ClienteId = new int[1] ;
         T00287_n168ClienteId = new bool[] {false} ;
         T00287_A405DocumentosId = new int[1] ;
         T00287_n405DocumentosId = new bool[] {false} ;
         T00287_A606ClienteDocumentoCreatedBy = new short[1] ;
         T00287_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         T00287_A601ClienteDocumentoBlob = new string[] {""} ;
         T00287_n601ClienteDocumentoBlob = new bool[] {false} ;
         T00284_A168ClienteId = new int[1] ;
         T00284_n168ClienteId = new bool[] {false} ;
         T00285_A406DocumentosDescricao = new string[] {""} ;
         T00285_n406DocumentosDescricao = new bool[] {false} ;
         T00286_A606ClienteDocumentoCreatedBy = new short[1] ;
         T00286_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         T00288_A168ClienteId = new int[1] ;
         T00288_n168ClienteId = new bool[] {false} ;
         T00289_A406DocumentosDescricao = new string[] {""} ;
         T00289_n406DocumentosDescricao = new bool[] {false} ;
         T002810_A606ClienteDocumentoCreatedBy = new short[1] ;
         T002810_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         T002811_A599ClienteDocumentoId = new int[1] ;
         T00283_A599ClienteDocumentoId = new int[1] ;
         T00283_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00283_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         T00283_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00283_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         T00283_A603ClienteDocumentoExtensao = new string[] {""} ;
         T00283_n603ClienteDocumentoExtensao = new bool[] {false} ;
         T00283_A602ClienteDocumentoNome = new string[] {""} ;
         T00283_n602ClienteDocumentoNome = new bool[] {false} ;
         T00283_A168ClienteId = new int[1] ;
         T00283_n168ClienteId = new bool[] {false} ;
         T00283_A405DocumentosId = new int[1] ;
         T00283_n405DocumentosId = new bool[] {false} ;
         T00283_A606ClienteDocumentoCreatedBy = new short[1] ;
         T00283_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         T00283_A601ClienteDocumentoBlob = new string[] {""} ;
         T00283_n601ClienteDocumentoBlob = new bool[] {false} ;
         T002812_A599ClienteDocumentoId = new int[1] ;
         T002813_A599ClienteDocumentoId = new int[1] ;
         T00282_A599ClienteDocumentoId = new int[1] ;
         T00282_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00282_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         T00282_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00282_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         T00282_A603ClienteDocumentoExtensao = new string[] {""} ;
         T00282_n603ClienteDocumentoExtensao = new bool[] {false} ;
         T00282_A602ClienteDocumentoNome = new string[] {""} ;
         T00282_n602ClienteDocumentoNome = new bool[] {false} ;
         T00282_A168ClienteId = new int[1] ;
         T00282_n168ClienteId = new bool[] {false} ;
         T00282_A405DocumentosId = new int[1] ;
         T00282_n405DocumentosId = new bool[] {false} ;
         T00282_A606ClienteDocumentoCreatedBy = new short[1] ;
         T00282_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         T00282_A601ClienteDocumentoBlob = new string[] {""} ;
         T00282_n601ClienteDocumentoBlob = new bool[] {false} ;
         T002815_A599ClienteDocumentoId = new int[1] ;
         T002819_A406DocumentosDescricao = new string[] {""} ;
         T002819_n406DocumentosDescricao = new bool[] {false} ;
         T002820_A599ClienteDocumentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         GXt_SdtWWPContext2 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         ZV25NomeDoArquivo = "";
         T002821_A168ClienteId = new int[1] ;
         T002821_n168ClienteId = new bool[] {false} ;
         T002822_A606ClienteDocumentoCreatedBy = new short[1] ;
         T002822_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientedocumento__default(),
            new Object[][] {
                new Object[] {
               T00282_A599ClienteDocumentoId, T00282_A604ClienteDocumentoCreatedAt, T00282_n604ClienteDocumentoCreatedAt, T00282_A605ClienteDocumentoUpdatedAt, T00282_n605ClienteDocumentoUpdatedAt, T00282_A603ClienteDocumentoExtensao, T00282_n603ClienteDocumentoExtensao, T00282_A602ClienteDocumentoNome, T00282_n602ClienteDocumentoNome, T00282_A168ClienteId,
               T00282_n168ClienteId, T00282_A405DocumentosId, T00282_n405DocumentosId, T00282_A606ClienteDocumentoCreatedBy, T00282_n606ClienteDocumentoCreatedBy, T00282_A601ClienteDocumentoBlob, T00282_n601ClienteDocumentoBlob
               }
               , new Object[] {
               T00283_A599ClienteDocumentoId, T00283_A604ClienteDocumentoCreatedAt, T00283_n604ClienteDocumentoCreatedAt, T00283_A605ClienteDocumentoUpdatedAt, T00283_n605ClienteDocumentoUpdatedAt, T00283_A603ClienteDocumentoExtensao, T00283_n603ClienteDocumentoExtensao, T00283_A602ClienteDocumentoNome, T00283_n602ClienteDocumentoNome, T00283_A168ClienteId,
               T00283_n168ClienteId, T00283_A405DocumentosId, T00283_n405DocumentosId, T00283_A606ClienteDocumentoCreatedBy, T00283_n606ClienteDocumentoCreatedBy, T00283_A601ClienteDocumentoBlob, T00283_n601ClienteDocumentoBlob
               }
               , new Object[] {
               T00284_A168ClienteId
               }
               , new Object[] {
               T00285_A406DocumentosDescricao, T00285_n406DocumentosDescricao
               }
               , new Object[] {
               T00286_A606ClienteDocumentoCreatedBy
               }
               , new Object[] {
               T00287_A599ClienteDocumentoId, T00287_A604ClienteDocumentoCreatedAt, T00287_n604ClienteDocumentoCreatedAt, T00287_A605ClienteDocumentoUpdatedAt, T00287_n605ClienteDocumentoUpdatedAt, T00287_A603ClienteDocumentoExtensao, T00287_n603ClienteDocumentoExtensao, T00287_A406DocumentosDescricao, T00287_n406DocumentosDescricao, T00287_A602ClienteDocumentoNome,
               T00287_n602ClienteDocumentoNome, T00287_A168ClienteId, T00287_n168ClienteId, T00287_A405DocumentosId, T00287_n405DocumentosId, T00287_A606ClienteDocumentoCreatedBy, T00287_n606ClienteDocumentoCreatedBy, T00287_A601ClienteDocumentoBlob, T00287_n601ClienteDocumentoBlob
               }
               , new Object[] {
               T00288_A168ClienteId
               }
               , new Object[] {
               T00289_A406DocumentosDescricao, T00289_n406DocumentosDescricao
               }
               , new Object[] {
               T002810_A606ClienteDocumentoCreatedBy
               }
               , new Object[] {
               T002811_A599ClienteDocumentoId
               }
               , new Object[] {
               T002812_A599ClienteDocumentoId
               }
               , new Object[] {
               T002813_A599ClienteDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T002815_A599ClienteDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002819_A406DocumentosDescricao, T002819_n406DocumentosDescricao
               }
               , new Object[] {
               T002820_A599ClienteDocumentoId
               }
               , new Object[] {
               T002821_A168ClienteId
               }
               , new Object[] {
               T002822_A606ClienteDocumentoCreatedBy
               }
            }
         );
         AV32Pgmname = "ClienteDocumento";
         Z168ClienteId = 0;
         n168ClienteId = true;
         N168ClienteId = 0;
         n168ClienteId = true;
         i168ClienteId = 0;
         n168ClienteId = true;
         A168ClienteId = 0;
         n168ClienteId = true;
         Z604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         i604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
      }

      private short Z606ClienteDocumentoCreatedBy ;
      private short N606ClienteDocumentoCreatedBy ;
      private short GxWebError ;
      private short A606ClienteDocumentoCreatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short AV12Insert_ClienteDocumentoCreatedBy ;
      private short AV28index ;
      private short RcdFound79 ;
      private short gxcookieaux ;
      private short gxajaxcallmode ;
      private short ZV28index ;
      private int wcpOAV7ClienteDocumentoId ;
      private int wcpOAV24ClienteId ;
      private int Z599ClienteDocumentoId ;
      private int Z168ClienteId ;
      private int Z405DocumentosId ;
      private int N168ClienteId ;
      private int N405DocumentosId ;
      private int A168ClienteId ;
      private int A405DocumentosId ;
      private int AV7ClienteDocumentoId ;
      private int AV24ClienteId ;
      private int trnEnded ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtDocumentosId_Visible ;
      private int edtDocumentosId_Enabled ;
      private int edtClienteDocumentoBlob_Enabled ;
      private int edtavNomedoarquivo_Enabled ;
      private int AV30ComboDocumentosId ;
      private int edtavCombodocumentosid_Enabled ;
      private int edtavCombodocumentosid_Visible ;
      private int A599ClienteDocumentoId ;
      private int edtClienteDocumentoId_Enabled ;
      private int edtClienteDocumentoId_Visible ;
      private int edtClienteId_Visible ;
      private int edtClienteId_Enabled ;
      private int edtClienteDocumentoNome_Visible ;
      private int edtClienteDocumentoNome_Enabled ;
      private int edtClienteDocumentoExtensao_Visible ;
      private int edtClienteDocumentoExtensao_Enabled ;
      private int edtClienteDocumentoCreatedAt_Visible ;
      private int edtClienteDocumentoCreatedAt_Enabled ;
      private int edtClienteDocumentoCreatedBy_Visible ;
      private int edtClienteDocumentoCreatedBy_Enabled ;
      private int edtClienteDocumentoUpdatedAt_Visible ;
      private int edtClienteDocumentoUpdatedAt_Enabled ;
      private int AV11Insert_ClienteId ;
      private int AV23Insert_DocumentosId ;
      private int Combo_documentosid_Datalistupdateminimumcharacters ;
      private int Combo_documentosid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV33GXV1 ;
      private int AV34Documentosid ;
      private int i168ClienteId ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_documentosid_Selectedvalue_get ;
      private string edtClienteDocumentoBlob_Filename ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDocumentosId_Internalname ;
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
      private string divTablesplitteddocumentosid_Internalname ;
      private string lblTextblockdocumentosid_Internalname ;
      private string lblTextblockdocumentosid_Jsonclick ;
      private string Combo_documentosid_Caption ;
      private string Combo_documentosid_Cls ;
      private string Combo_documentosid_Internalname ;
      private string edtDocumentosId_Jsonclick ;
      private string edtClienteDocumentoBlob_Internalname ;
      private string edtClienteDocumentoBlob_Filetype ;
      private string edtClienteDocumentoBlob_Contenttype ;
      private string edtClienteDocumentoBlob_Parameters ;
      private string edtClienteDocumentoBlob_Jsonclick ;
      private string edtavNomedoarquivo_Internalname ;
      private string edtavNomedoarquivo_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_documentosid_Internalname ;
      private string edtavCombodocumentosid_Internalname ;
      private string edtavCombodocumentosid_Jsonclick ;
      private string edtClienteDocumentoId_Internalname ;
      private string edtClienteDocumentoId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteDocumentoNome_Internalname ;
      private string edtClienteDocumentoNome_Jsonclick ;
      private string edtClienteDocumentoExtensao_Internalname ;
      private string edtClienteDocumentoExtensao_Jsonclick ;
      private string edtClienteDocumentoCreatedAt_Internalname ;
      private string edtClienteDocumentoCreatedAt_Jsonclick ;
      private string edtClienteDocumentoCreatedBy_Internalname ;
      private string edtClienteDocumentoCreatedBy_Jsonclick ;
      private string edtClienteDocumentoUpdatedAt_Internalname ;
      private string edtClienteDocumentoUpdatedAt_Jsonclick ;
      private string AV32Pgmname ;
      private string Combo_documentosid_Objectcall ;
      private string Combo_documentosid_Class ;
      private string Combo_documentosid_Icontype ;
      private string Combo_documentosid_Icon ;
      private string Combo_documentosid_Tooltip ;
      private string Combo_documentosid_Selectedvalue_set ;
      private string Combo_documentosid_Selectedtext_set ;
      private string Combo_documentosid_Selectedtext_get ;
      private string Combo_documentosid_Gamoauthtoken ;
      private string Combo_documentosid_Ddointernalname ;
      private string Combo_documentosid_Titlecontrolalign ;
      private string Combo_documentosid_Dropdownoptionstype ;
      private string Combo_documentosid_Titlecontrolidtoreplace ;
      private string Combo_documentosid_Datalisttype ;
      private string Combo_documentosid_Datalistfixedvalues ;
      private string Combo_documentosid_Datalistproc ;
      private string Combo_documentosid_Datalistprocparametersprefix ;
      private string Combo_documentosid_Remoteservicesparameters ;
      private string Combo_documentosid_Htmltemplate ;
      private string Combo_documentosid_Multiplevaluestype ;
      private string Combo_documentosid_Loadingdata ;
      private string Combo_documentosid_Noresultsfound ;
      private string Combo_documentosid_Emptyitemtext ;
      private string Combo_documentosid_Onlyselectedvalues ;
      private string Combo_documentosid_Selectalltext ;
      private string Combo_documentosid_Multiplevaluesseparator ;
      private string Combo_documentosid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string GXCCtlgxBlob ;
      private string hsh ;
      private string sMode79 ;
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
      private DateTime Z604ClienteDocumentoCreatedAt ;
      private DateTime Z605ClienteDocumentoUpdatedAt ;
      private DateTime A604ClienteDocumentoCreatedAt ;
      private DateTime A605ClienteDocumentoUpdatedAt ;
      private DateTime i604ClienteDocumentoCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n168ClienteId ;
      private bool n405DocumentosId ;
      private bool n606ClienteDocumentoCreatedBy ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_documentosid_Emptyitem ;
      private bool Combo_documentosid_Includeaddnewoption ;
      private bool n601ClienteDocumentoBlob ;
      private bool n604ClienteDocumentoCreatedAt ;
      private bool n605ClienteDocumentoUpdatedAt ;
      private bool n603ClienteDocumentoExtensao ;
      private bool n602ClienteDocumentoNome ;
      private bool n406DocumentosDescricao ;
      private bool Combo_documentosid_Enabled ;
      private bool Combo_documentosid_Visible ;
      private bool Combo_documentosid_Allowmultipleselection ;
      private bool Combo_documentosid_Isgriditem ;
      private bool Combo_documentosid_Hasdescription ;
      private bool Combo_documentosid_Includeonlyselectedoption ;
      private bool Combo_documentosid_Includeselectalloption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z603ClienteDocumentoExtensao ;
      private string Z602ClienteDocumentoNome ;
      private string AV25NomeDoArquivo ;
      private string A602ClienteDocumentoNome ;
      private string A603ClienteDocumentoExtensao ;
      private string A607ClienteNomeDoArquivo_F ;
      private string A406DocumentosDescricao ;
      private string AV16ComboSelectedValue ;
      private string AV26Nome ;
      private string AV27Ext ;
      private string Z406DocumentosDescricao ;
      private string ZV25NomeDoArquivo ;
      private string A601ClienteDocumentoBlob ;
      private string Z601ClienteDocumentoBlob ;
      private IGxSession AV10WebSession ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_documentosid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29DocumentosId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private IDataStoreProvider pr_default ;
      private int[] T00287_A599ClienteDocumentoId ;
      private DateTime[] T00287_A604ClienteDocumentoCreatedAt ;
      private bool[] T00287_n604ClienteDocumentoCreatedAt ;
      private DateTime[] T00287_A605ClienteDocumentoUpdatedAt ;
      private bool[] T00287_n605ClienteDocumentoUpdatedAt ;
      private string[] T00287_A603ClienteDocumentoExtensao ;
      private bool[] T00287_n603ClienteDocumentoExtensao ;
      private string[] T00287_A406DocumentosDescricao ;
      private bool[] T00287_n406DocumentosDescricao ;
      private string[] T00287_A602ClienteDocumentoNome ;
      private bool[] T00287_n602ClienteDocumentoNome ;
      private int[] T00287_A168ClienteId ;
      private bool[] T00287_n168ClienteId ;
      private int[] T00287_A405DocumentosId ;
      private bool[] T00287_n405DocumentosId ;
      private short[] T00287_A606ClienteDocumentoCreatedBy ;
      private bool[] T00287_n606ClienteDocumentoCreatedBy ;
      private string[] T00287_A601ClienteDocumentoBlob ;
      private bool[] T00287_n601ClienteDocumentoBlob ;
      private int[] T00284_A168ClienteId ;
      private bool[] T00284_n168ClienteId ;
      private string[] T00285_A406DocumentosDescricao ;
      private bool[] T00285_n406DocumentosDescricao ;
      private short[] T00286_A606ClienteDocumentoCreatedBy ;
      private bool[] T00286_n606ClienteDocumentoCreatedBy ;
      private int[] T00288_A168ClienteId ;
      private bool[] T00288_n168ClienteId ;
      private string[] T00289_A406DocumentosDescricao ;
      private bool[] T00289_n406DocumentosDescricao ;
      private short[] T002810_A606ClienteDocumentoCreatedBy ;
      private bool[] T002810_n606ClienteDocumentoCreatedBy ;
      private int[] T002811_A599ClienteDocumentoId ;
      private int[] T00283_A599ClienteDocumentoId ;
      private DateTime[] T00283_A604ClienteDocumentoCreatedAt ;
      private bool[] T00283_n604ClienteDocumentoCreatedAt ;
      private DateTime[] T00283_A605ClienteDocumentoUpdatedAt ;
      private bool[] T00283_n605ClienteDocumentoUpdatedAt ;
      private string[] T00283_A603ClienteDocumentoExtensao ;
      private bool[] T00283_n603ClienteDocumentoExtensao ;
      private string[] T00283_A602ClienteDocumentoNome ;
      private bool[] T00283_n602ClienteDocumentoNome ;
      private int[] T00283_A168ClienteId ;
      private bool[] T00283_n168ClienteId ;
      private int[] T00283_A405DocumentosId ;
      private bool[] T00283_n405DocumentosId ;
      private short[] T00283_A606ClienteDocumentoCreatedBy ;
      private bool[] T00283_n606ClienteDocumentoCreatedBy ;
      private string[] T00283_A601ClienteDocumentoBlob ;
      private bool[] T00283_n601ClienteDocumentoBlob ;
      private int[] T002812_A599ClienteDocumentoId ;
      private int[] T002813_A599ClienteDocumentoId ;
      private int[] T00282_A599ClienteDocumentoId ;
      private DateTime[] T00282_A604ClienteDocumentoCreatedAt ;
      private bool[] T00282_n604ClienteDocumentoCreatedAt ;
      private DateTime[] T00282_A605ClienteDocumentoUpdatedAt ;
      private bool[] T00282_n605ClienteDocumentoUpdatedAt ;
      private string[] T00282_A603ClienteDocumentoExtensao ;
      private bool[] T00282_n603ClienteDocumentoExtensao ;
      private string[] T00282_A602ClienteDocumentoNome ;
      private bool[] T00282_n602ClienteDocumentoNome ;
      private int[] T00282_A168ClienteId ;
      private bool[] T00282_n168ClienteId ;
      private int[] T00282_A405DocumentosId ;
      private bool[] T00282_n405DocumentosId ;
      private short[] T00282_A606ClienteDocumentoCreatedBy ;
      private bool[] T00282_n606ClienteDocumentoCreatedBy ;
      private string[] T00282_A601ClienteDocumentoBlob ;
      private bool[] T00282_n601ClienteDocumentoBlob ;
      private int[] T002815_A599ClienteDocumentoId ;
      private string[] T002819_A406DocumentosDescricao ;
      private bool[] T002819_n406DocumentosDescricao ;
      private int[] T002820_A599ClienteDocumentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext2 ;
      private int[] T002821_A168ClienteId ;
      private bool[] T002821_n168ClienteId ;
      private short[] T002822_A606ClienteDocumentoCreatedBy ;
      private bool[] T002822_n606ClienteDocumentoCreatedBy ;
   }

   public class clientedocumento__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00282;
          prmT00282 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT00283;
          prmT00283 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT00284;
          prmT00284 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00285;
          prmT00285 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00286;
          prmT00286 = new Object[] {
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00287;
          prmT00287 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT00288;
          prmT00288 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00289;
          prmT00289 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002810;
          prmT002810 = new Object[] {
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002811;
          prmT002811 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002812;
          prmT002812 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002813;
          prmT002813 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002814;
          prmT002814 = new Object[] {
          new ParDef("ClienteDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoExtensao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ClienteDocumentoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002815;
          prmT002815 = new Object[] {
          };
          Object[] prmT002816;
          prmT002816 = new Object[] {
          new ParDef("ClienteDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoExtensao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteDocumentoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002817;
          prmT002817 = new Object[] {
          new ParDef("ClienteDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002818;
          prmT002818 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002819;
          prmT002819 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002820;
          prmT002820 = new Object[] {
          };
          Object[] prmT002821;
          prmT002821 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002822;
          prmT002822 = new Object[] {
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00282", "SELECT ClienteDocumentoId, ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao, ClienteDocumentoNome, ClienteId, DocumentosId, ClienteDocumentoCreatedBy, ClienteDocumentoBlob FROM ClienteDocumento WHERE ClienteDocumentoId = :ClienteDocumentoId  FOR UPDATE OF ClienteDocumento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00282,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00283", "SELECT ClienteDocumentoId, ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao, ClienteDocumentoNome, ClienteId, DocumentosId, ClienteDocumentoCreatedBy, ClienteDocumentoBlob FROM ClienteDocumento WHERE ClienteDocumentoId = :ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00283,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00284", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00284,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00285", "SELECT DocumentosDescricao FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00285,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00286", "SELECT SecUserId AS ClienteDocumentoCreatedBy FROM SecUser WHERE SecUserId = :ClienteDocumentoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT00286,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00287", "SELECT TM1.ClienteDocumentoId, TM1.ClienteDocumentoCreatedAt, TM1.ClienteDocumentoUpdatedAt, TM1.ClienteDocumentoExtensao, T2.DocumentosDescricao, TM1.ClienteDocumentoNome, TM1.ClienteId, TM1.DocumentosId, TM1.ClienteDocumentoCreatedBy AS ClienteDocumentoCreatedBy, TM1.ClienteDocumentoBlob FROM (ClienteDocumento TM1 LEFT JOIN Documentos T2 ON T2.DocumentosId = TM1.DocumentosId) WHERE TM1.ClienteDocumentoId = :ClienteDocumentoId ORDER BY TM1.ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00287,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00288", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00288,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00289", "SELECT DocumentosDescricao FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00289,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002810", "SELECT SecUserId AS ClienteDocumentoCreatedBy FROM SecUser WHERE SecUserId = :ClienteDocumentoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002810,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002811", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoId = :ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002811,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002812", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ( ClienteDocumentoId > :ClienteDocumentoId) ORDER BY ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002812,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002813", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ( ClienteDocumentoId < :ClienteDocumentoId) ORDER BY ClienteDocumentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002813,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002814", "SAVEPOINT gxupdate;INSERT INTO ClienteDocumento(ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao, ClienteDocumentoBlob, ClienteDocumentoNome, ClienteId, DocumentosId, ClienteDocumentoCreatedBy) VALUES(:ClienteDocumentoCreatedAt, :ClienteDocumentoUpdatedAt, :ClienteDocumentoExtensao, :ClienteDocumentoBlob, :ClienteDocumentoNome, :ClienteId, :DocumentosId, :ClienteDocumentoCreatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002814)
             ,new CursorDef("T002815", "SELECT currval('ClienteDocumentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002815,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002816", "SAVEPOINT gxupdate;UPDATE ClienteDocumento SET ClienteDocumentoCreatedAt=:ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt=:ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao=:ClienteDocumentoExtensao, ClienteDocumentoNome=:ClienteDocumentoNome, ClienteId=:ClienteId, DocumentosId=:DocumentosId, ClienteDocumentoCreatedBy=:ClienteDocumentoCreatedBy  WHERE ClienteDocumentoId = :ClienteDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002816)
             ,new CursorDef("T002817", "SAVEPOINT gxupdate;UPDATE ClienteDocumento SET ClienteDocumentoBlob=:ClienteDocumentoBlob  WHERE ClienteDocumentoId = :ClienteDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002817)
             ,new CursorDef("T002818", "SAVEPOINT gxupdate;DELETE FROM ClienteDocumento  WHERE ClienteDocumentoId = :ClienteDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002818)
             ,new CursorDef("T002819", "SELECT DocumentosDescricao FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002819,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002820", "SELECT ClienteDocumentoId FROM ClienteDocumento ORDER BY ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002820,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002821", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002821,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002822", "SELECT SecUserId AS ClienteDocumentoCreatedBy FROM SecUser WHERE SecUserId = :ClienteDocumentoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002822,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(9, "tmp", "");
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
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
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(9, "tmp", "");
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
