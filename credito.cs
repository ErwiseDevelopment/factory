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
   public class credito : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
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
            gxLoad_19( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A861CreditoCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "CreditoCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n861CreditoCreatedBy = false;
            AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A861CreditoCreatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A862CreditoUpdatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "CreditoUpdatedBy"), "."), 18, MidpointRounding.ToEven));
            n862CreditoUpdatedBy = false;
            AssignAttri("", false, "A862CreditoUpdatedBy", ((0==A862CreditoUpdatedBy)&&IsIns( )||n862CreditoUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A862CreditoUpdatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A862CreditoUpdatedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "credito")), "credito") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "credito")))) ;
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
                  AV7CreditoId = (int)(Math.Round(NumberUtil.Val( GetPar( "CreditoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CreditoId", StringUtil.LTrimStr( (decimal)(AV7CreditoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCREDITOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CreditoId), "ZZZZZZZZ9"), context));
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "Insert_ClienteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Credito", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCreditoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public credito( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public credito( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CreditoId ,
                           int aP2_Insert_ClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CreditoId = aP1_CreditoId;
         this.AV11Insert_ClienteId = aP2_Insert_ClienteId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCreditoValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCreditoValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCreditoValor_Internalname, ((Convert.ToDecimal(0)==A857CreditoValor)&&IsIns( )||n857CreditoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A857CreditoValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A857CreditoValor)&&IsIns( )||n857CreditoValor ? "" : StringUtil.LTrim( ((edtCreditoValor_Enabled!=0) ? context.localUtil.Format( A857CreditoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A857CreditoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCreditoValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCreditoValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Credito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCreditoVigencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCreditoVigencia_Internalname, "Vigência", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCreditoVigencia_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCreditoVigencia_Internalname, context.localUtil.Format(A858CreditoVigencia, "99/99/9999"), context.localUtil.Format( A858CreditoVigencia, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCreditoVigencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCreditoVigencia_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Credito.htm");
         GxWebStd.gx_bitmap( context, edtCreditoVigencia_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCreditoVigencia_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Credito.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Credito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Credito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Credito.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCreditoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A856CreditoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtCreditoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A856CreditoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A856CreditoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCreditoId_Jsonclick, 0, "Attribute", "", "", "", "", edtCreditoId_Visible, edtCreditoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Credito.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Credito.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCreditoCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCreditoCreatedAt_Internalname, context.localUtil.TToC( A859CreditoCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A859CreditoCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCreditoCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtCreditoCreatedAt_Visible, edtCreditoCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Credito.htm");
         GxWebStd.gx_bitmap( context, edtCreditoCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCreditoCreatedAt_Visible==0)||(edtCreditoCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Credito.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCreditoUpdatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCreditoUpdatedAt_Internalname, context.localUtil.TToC( A860CreditoUpdatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A860CreditoUpdatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCreditoUpdatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtCreditoUpdatedAt_Visible, edtCreditoUpdatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Credito.htm");
         GxWebStd.gx_bitmap( context, edtCreditoUpdatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCreditoUpdatedAt_Visible==0)||(edtCreditoUpdatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Credito.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCreditoCreatedBy_Internalname, ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ",", ""))), ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A861CreditoCreatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCreditoCreatedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtCreditoCreatedBy_Visible, edtCreditoCreatedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Credito.htm");
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
         E112P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z856CreditoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z856CreditoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z859CreditoCreatedAt = context.localUtil.CToT( cgiGet( "Z859CreditoCreatedAt"), 0);
               n859CreditoCreatedAt = ((DateTime.MinValue==A859CreditoCreatedAt) ? true : false);
               Z860CreditoUpdatedAt = context.localUtil.CToT( cgiGet( "Z860CreditoUpdatedAt"), 0);
               n860CreditoUpdatedAt = ((DateTime.MinValue==A860CreditoUpdatedAt) ? true : false);
               Z857CreditoValor = context.localUtil.CToN( cgiGet( "Z857CreditoValor"), ",", ".");
               n857CreditoValor = ((Convert.ToDecimal(0)==A857CreditoValor) ? true : false);
               Z858CreditoVigencia = context.localUtil.CToD( cgiGet( "Z858CreditoVigencia"), 0);
               n858CreditoVigencia = ((DateTime.MinValue==A858CreditoVigencia) ? true : false);
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               Z861CreditoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z861CreditoCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n861CreditoCreatedBy = ((0==A861CreditoCreatedBy) ? true : false);
               Z862CreditoUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z862CreditoUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n862CreditoUpdatedBy = ((0==A862CreditoUpdatedBy) ? true : false);
               A862CreditoUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z862CreditoUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n862CreditoUpdatedBy = false;
               n862CreditoUpdatedBy = ((0==A862CreditoUpdatedBy) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N861CreditoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N861CreditoCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n861CreditoCreatedBy = ((0==A861CreditoCreatedBy) ? true : false);
               N862CreditoUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N862CreditoUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n862CreditoUpdatedBy = ((0==A862CreditoUpdatedBy) ? true : false);
               AV7CreditoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCREDITOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"), context));
               AV12Insert_CreditoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CREDITOCREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_CreditoCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_CreditoCreatedBy), 4, 0));
               AV24Insert_CreditoUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CREDITOUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_CreditoUpdatedBy", StringUtil.LTrimStr( (decimal)(AV24Insert_CreditoUpdatedBy), 4, 0));
               A862CreditoUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CREDITOUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n862CreditoUpdatedBy = ((0==A862CreditoUpdatedBy) ? true : false);
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
               n857CreditoValor = ((StringUtil.StrCmp(cgiGet( edtCreditoValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCreditoValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCreditoValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CREDITOVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtCreditoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A857CreditoValor = 0;
                  n857CreditoValor = false;
                  AssignAttri("", false, "A857CreditoValor", (n857CreditoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A857CreditoValor, 18, 2, ".", ""))));
               }
               else
               {
                  A857CreditoValor = context.localUtil.CToN( cgiGet( edtCreditoValor_Internalname), ",", ".");
                  AssignAttri("", false, "A857CreditoValor", (n857CreditoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A857CreditoValor, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtCreditoVigencia_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Credito Vigencia"}), 1, "CREDITOVIGENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtCreditoVigencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A858CreditoVigencia = DateTime.MinValue;
                  n858CreditoVigencia = false;
                  AssignAttri("", false, "A858CreditoVigencia", context.localUtil.Format(A858CreditoVigencia, "99/99/9999"));
               }
               else
               {
                  A858CreditoVigencia = context.localUtil.CToD( cgiGet( edtCreditoVigencia_Internalname), 2);
                  n858CreditoVigencia = false;
                  AssignAttri("", false, "A858CreditoVigencia", context.localUtil.Format(A858CreditoVigencia, "99/99/9999"));
               }
               n858CreditoVigencia = ((DateTime.MinValue==A858CreditoVigencia) ? true : false);
               A856CreditoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCreditoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
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
               if ( context.localUtil.VCDateTime( cgiGet( edtCreditoCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Credito Created At"}), 1, "CREDITOCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtCreditoCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
                  n859CreditoCreatedAt = false;
                  AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A859CreditoCreatedAt = context.localUtil.CToT( cgiGet( edtCreditoCreatedAt_Internalname));
                  n859CreditoCreatedAt = false;
                  AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n859CreditoCreatedAt = ((DateTime.MinValue==A859CreditoCreatedAt) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtCreditoUpdatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Credito Updated At"}), 1, "CREDITOUPDATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtCreditoUpdatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
                  n860CreditoUpdatedAt = false;
                  AssignAttri("", false, "A860CreditoUpdatedAt", context.localUtil.TToC( A860CreditoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A860CreditoUpdatedAt = context.localUtil.CToT( cgiGet( edtCreditoUpdatedAt_Internalname));
                  n860CreditoUpdatedAt = false;
                  AssignAttri("", false, "A860CreditoUpdatedAt", context.localUtil.TToC( A860CreditoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n860CreditoUpdatedAt = ((DateTime.MinValue==A860CreditoUpdatedAt) ? true : false);
               n861CreditoCreatedBy = ((StringUtil.StrCmp(cgiGet( edtCreditoCreatedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCreditoCreatedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCreditoCreatedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CREDITOCREATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtCreditoCreatedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A861CreditoCreatedBy = 0;
                  n861CreditoCreatedBy = false;
                  AssignAttri("", false, "A861CreditoCreatedBy", (n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A861CreditoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCreditoCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A861CreditoCreatedBy", (n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Credito");
               A856CreditoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCreditoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
               forbiddenHiddens.Add("CreditoId", context.localUtil.Format( (decimal)(A856CreditoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_CreditoCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_CreditoCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_CreditoUpdatedBy", context.localUtil.Format( (decimal)(AV24Insert_CreditoUpdatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A856CreditoId != Z856CreditoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("credito:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A856CreditoId = (int)(Math.Round(NumberUtil.Val( GetPar( "CreditoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
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
                     sMode95 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode95;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound95 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CREDITOID");
                        AnyError = 1;
                        GX_FocusControl = edtCreditoId_Internalname;
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
                           E112P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122P2 ();
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
            E122P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2P95( ) ;
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
            DisableAttributes2P95( ) ;
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

      protected void CONFIRM_2P0( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2P95( ) ;
            }
            else
            {
               CheckExtendedTable2P95( ) ;
               CloseExtendedTableCursors2P95( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2P0( )
      {
      }

      protected void E112P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"), context));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CreditoCreatedBy") == 0 )
               {
                  AV12Insert_CreditoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_CreditoCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_CreditoCreatedBy), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CreditoUpdatedBy") == 0 )
               {
                  AV24Insert_CreditoUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_CreditoUpdatedBy", StringUtil.LTrimStr( (decimal)(AV24Insert_CreditoUpdatedBy), 4, 0));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtCreditoId_Visible = 0;
         AssignProp("", false, edtCreditoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCreditoId_Visible), 5, 0), true);
         edtClienteId_Visible = 0;
         AssignProp("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteId_Visible), 5, 0), true);
         edtCreditoCreatedAt_Visible = 0;
         AssignProp("", false, edtCreditoCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCreditoCreatedAt_Visible), 5, 0), true);
         edtCreditoUpdatedAt_Visible = 0;
         AssignProp("", false, edtCreditoUpdatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCreditoUpdatedAt_Visible), 5, 0), true);
         edtCreditoCreatedBy_Visible = 0;
         AssignProp("", false, edtCreditoCreatedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCreditoCreatedBy_Visible), 5, 0), true);
      }

      protected void E122P2( )
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

      protected void ZM2P95( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z859CreditoCreatedAt = T002P3_A859CreditoCreatedAt[0];
               Z860CreditoUpdatedAt = T002P3_A860CreditoUpdatedAt[0];
               Z857CreditoValor = T002P3_A857CreditoValor[0];
               Z858CreditoVigencia = T002P3_A858CreditoVigencia[0];
               Z168ClienteId = T002P3_A168ClienteId[0];
               Z861CreditoCreatedBy = T002P3_A861CreditoCreatedBy[0];
               Z862CreditoUpdatedBy = T002P3_A862CreditoUpdatedBy[0];
            }
            else
            {
               Z859CreditoCreatedAt = A859CreditoCreatedAt;
               Z860CreditoUpdatedAt = A860CreditoUpdatedAt;
               Z857CreditoValor = A857CreditoValor;
               Z858CreditoVigencia = A858CreditoVigencia;
               Z168ClienteId = A168ClienteId;
               Z861CreditoCreatedBy = A861CreditoCreatedBy;
               Z862CreditoUpdatedBy = A862CreditoUpdatedBy;
            }
         }
         if ( GX_JID == -18 )
         {
            Z856CreditoId = A856CreditoId;
            Z859CreditoCreatedAt = A859CreditoCreatedAt;
            Z860CreditoUpdatedAt = A860CreditoUpdatedAt;
            Z857CreditoValor = A857CreditoValor;
            Z858CreditoVigencia = A858CreditoVigencia;
            Z168ClienteId = A168ClienteId;
            Z861CreditoCreatedBy = A861CreditoCreatedBy;
            Z862CreditoUpdatedBy = A862CreditoUpdatedBy;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCreditoId_Enabled = 0;
         AssignProp("", false, edtCreditoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoId_Enabled), 5, 0), true);
         AV25Pgmname = "Credito";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         edtCreditoId_Enabled = 0;
         AssignProp("", false, edtCreditoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CreditoId) )
         {
            A856CreditoId = AV7CreditoId;
            AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CreditoCreatedBy) )
         {
            edtCreditoCreatedBy_Enabled = 0;
            AssignProp("", false, edtCreditoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoCreatedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtCreditoCreatedBy_Enabled = 1;
            AssignProp("", false, edtCreditoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoCreatedBy_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A859CreditoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n859CreditoCreatedAt = false;
            AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A860CreditoUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n860CreditoUpdatedAt = false;
            AssignAttri("", false, "A860CreditoUpdatedAt", context.localUtil.TToC( A860CreditoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CreditoCreatedBy) )
         {
            A861CreditoCreatedBy = AV12Insert_CreditoCreatedBy;
            n861CreditoCreatedBy = false;
            AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A861CreditoCreatedBy = AV8WWPContext.gxTpr_Userid;
               n861CreditoCreatedBy = false;
               AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_CreditoUpdatedBy) )
         {
            A862CreditoUpdatedBy = AV24Insert_CreditoUpdatedBy;
            n862CreditoUpdatedBy = false;
            AssignAttri("", false, "A862CreditoUpdatedBy", ((0==A862CreditoUpdatedBy)&&IsIns( )||n862CreditoUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A862CreditoUpdatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A862CreditoUpdatedBy = AV8WWPContext.gxTpr_Userid;
               n862CreditoUpdatedBy = false;
               AssignAttri("", false, "A862CreditoUpdatedBy", ((0==A862CreditoUpdatedBy)&&IsIns( )||n862CreditoUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A862CreditoUpdatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A168ClienteId = AV11Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
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
      }

      protected void Load2P95( )
      {
         /* Using cursor T002P7 */
         pr_default.execute(5, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound95 = 1;
            A859CreditoCreatedAt = T002P7_A859CreditoCreatedAt[0];
            n859CreditoCreatedAt = T002P7_n859CreditoCreatedAt[0];
            AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A860CreditoUpdatedAt = T002P7_A860CreditoUpdatedAt[0];
            n860CreditoUpdatedAt = T002P7_n860CreditoUpdatedAt[0];
            AssignAttri("", false, "A860CreditoUpdatedAt", context.localUtil.TToC( A860CreditoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A857CreditoValor = T002P7_A857CreditoValor[0];
            n857CreditoValor = T002P7_n857CreditoValor[0];
            AssignAttri("", false, "A857CreditoValor", ((Convert.ToDecimal(0)==A857CreditoValor)&&IsIns( )||n857CreditoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A857CreditoValor, 18, 2, ".", ""))));
            A858CreditoVigencia = T002P7_A858CreditoVigencia[0];
            n858CreditoVigencia = T002P7_n858CreditoVigencia[0];
            AssignAttri("", false, "A858CreditoVigencia", context.localUtil.Format(A858CreditoVigencia, "99/99/9999"));
            A168ClienteId = T002P7_A168ClienteId[0];
            n168ClienteId = T002P7_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A861CreditoCreatedBy = T002P7_A861CreditoCreatedBy[0];
            n861CreditoCreatedBy = T002P7_n861CreditoCreatedBy[0];
            AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
            A862CreditoUpdatedBy = T002P7_A862CreditoUpdatedBy[0];
            n862CreditoUpdatedBy = T002P7_n862CreditoUpdatedBy[0];
            ZM2P95( -18) ;
         }
         pr_default.close(5);
         OnLoadActions2P95( ) ;
      }

      protected void OnLoadActions2P95( )
      {
      }

      protected void CheckExtendedTable2P95( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002P4 */
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
         if ( (Convert.ToDecimal(0)==A857CreditoValor) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Credito Valor", "", "", "", "", "", "", "", ""), 1, "CREDITOVALOR");
            AnyError = 1;
            GX_FocusControl = edtCreditoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A857CreditoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CREDITOVALOR");
            AnyError = 1;
            GX_FocusControl = edtCreditoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A858CreditoVigencia) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Credito Vigencia", "", "", "", "", "", "", "", ""), 1, "CREDITOVIGENCIA");
            AnyError = 1;
            GX_FocusControl = edtCreditoVigencia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002P5 */
         pr_default.execute(3, new Object[] {n861CreditoCreatedBy, A861CreditoCreatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A861CreditoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sdb Credito Usuario'.", "ForeignKeyNotFound", 1, "CREDITOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtCreditoCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T002P6 */
         pr_default.execute(4, new Object[] {n862CreditoUpdatedBy, A862CreditoUpdatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A862CreditoUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Updated By Credito'.", "ForeignKeyNotFound", 1, "CREDITOUPDATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2P95( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( int A168ClienteId )
      {
         /* Using cursor T002P8 */
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

      protected void gxLoad_20( short A861CreditoCreatedBy )
      {
         /* Using cursor T002P9 */
         pr_default.execute(7, new Object[] {n861CreditoCreatedBy, A861CreditoCreatedBy});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A861CreditoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sdb Credito Usuario'.", "ForeignKeyNotFound", 1, "CREDITOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtCreditoCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_21( short A862CreditoUpdatedBy )
      {
         /* Using cursor T002P10 */
         pr_default.execute(8, new Object[] {n862CreditoUpdatedBy, A862CreditoUpdatedBy});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A862CreditoUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Updated By Credito'.", "ForeignKeyNotFound", 1, "CREDITOUPDATEDBY");
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

      protected void GetKey2P95( )
      {
         /* Using cursor T002P11 */
         pr_default.execute(9, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002P3 */
         pr_default.execute(1, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2P95( 18) ;
            RcdFound95 = 1;
            A856CreditoId = T002P3_A856CreditoId[0];
            AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
            A859CreditoCreatedAt = T002P3_A859CreditoCreatedAt[0];
            n859CreditoCreatedAt = T002P3_n859CreditoCreatedAt[0];
            AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A860CreditoUpdatedAt = T002P3_A860CreditoUpdatedAt[0];
            n860CreditoUpdatedAt = T002P3_n860CreditoUpdatedAt[0];
            AssignAttri("", false, "A860CreditoUpdatedAt", context.localUtil.TToC( A860CreditoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A857CreditoValor = T002P3_A857CreditoValor[0];
            n857CreditoValor = T002P3_n857CreditoValor[0];
            AssignAttri("", false, "A857CreditoValor", ((Convert.ToDecimal(0)==A857CreditoValor)&&IsIns( )||n857CreditoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A857CreditoValor, 18, 2, ".", ""))));
            A858CreditoVigencia = T002P3_A858CreditoVigencia[0];
            n858CreditoVigencia = T002P3_n858CreditoVigencia[0];
            AssignAttri("", false, "A858CreditoVigencia", context.localUtil.Format(A858CreditoVigencia, "99/99/9999"));
            A168ClienteId = T002P3_A168ClienteId[0];
            n168ClienteId = T002P3_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A861CreditoCreatedBy = T002P3_A861CreditoCreatedBy[0];
            n861CreditoCreatedBy = T002P3_n861CreditoCreatedBy[0];
            AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
            A862CreditoUpdatedBy = T002P3_A862CreditoUpdatedBy[0];
            n862CreditoUpdatedBy = T002P3_n862CreditoUpdatedBy[0];
            Z856CreditoId = A856CreditoId;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2P95( ) ;
            if ( AnyError == 1 )
            {
               RcdFound95 = 0;
               InitializeNonKey2P95( ) ;
            }
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey2P95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2P95( ) ;
         if ( RcdFound95 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound95 = 0;
         /* Using cursor T002P12 */
         pr_default.execute(10, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002P12_A856CreditoId[0] < A856CreditoId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002P12_A856CreditoId[0] > A856CreditoId ) ) )
            {
               A856CreditoId = T002P12_A856CreditoId[0];
               AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
               RcdFound95 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound95 = 0;
         /* Using cursor T002P13 */
         pr_default.execute(11, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002P13_A856CreditoId[0] > A856CreditoId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002P13_A856CreditoId[0] < A856CreditoId ) ) )
            {
               A856CreditoId = T002P13_A856CreditoId[0];
               AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
               RcdFound95 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2P95( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCreditoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2P95( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound95 == 1 )
            {
               if ( A856CreditoId != Z856CreditoId )
               {
                  A856CreditoId = Z856CreditoId;
                  AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CREDITOID");
                  AnyError = 1;
                  GX_FocusControl = edtCreditoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCreditoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2P95( ) ;
                  GX_FocusControl = edtCreditoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A856CreditoId != Z856CreditoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCreditoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2P95( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CREDITOID");
                     AnyError = 1;
                     GX_FocusControl = edtCreditoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCreditoValor_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2P95( ) ;
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
         if ( A856CreditoId != Z856CreditoId )
         {
            A856CreditoId = Z856CreditoId;
            AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CREDITOID");
            AnyError = 1;
            GX_FocusControl = edtCreditoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCreditoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2P95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002P2 */
            pr_default.execute(0, new Object[] {A856CreditoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Credito"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z859CreditoCreatedAt != T002P2_A859CreditoCreatedAt[0] ) || ( Z860CreditoUpdatedAt != T002P2_A860CreditoUpdatedAt[0] ) || ( Z857CreditoValor != T002P2_A857CreditoValor[0] ) || ( DateTimeUtil.ResetTime ( Z858CreditoVigencia ) != DateTimeUtil.ResetTime ( T002P2_A858CreditoVigencia[0] ) ) || ( Z168ClienteId != T002P2_A168ClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z861CreditoCreatedBy != T002P2_A861CreditoCreatedBy[0] ) || ( Z862CreditoUpdatedBy != T002P2_A862CreditoUpdatedBy[0] ) )
            {
               if ( Z859CreditoCreatedAt != T002P2_A859CreditoCreatedAt[0] )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"CreditoCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z859CreditoCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A859CreditoCreatedAt[0]);
               }
               if ( Z860CreditoUpdatedAt != T002P2_A860CreditoUpdatedAt[0] )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"CreditoUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z860CreditoUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A860CreditoUpdatedAt[0]);
               }
               if ( Z857CreditoValor != T002P2_A857CreditoValor[0] )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"CreditoValor");
                  GXUtil.WriteLogRaw("Old: ",Z857CreditoValor);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A857CreditoValor[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z858CreditoVigencia ) != DateTimeUtil.ResetTime ( T002P2_A858CreditoVigencia[0] ) )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"CreditoVigencia");
                  GXUtil.WriteLogRaw("Old: ",Z858CreditoVigencia);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A858CreditoVigencia[0]);
               }
               if ( Z168ClienteId != T002P2_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A168ClienteId[0]);
               }
               if ( Z861CreditoCreatedBy != T002P2_A861CreditoCreatedBy[0] )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"CreditoCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z861CreditoCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A861CreditoCreatedBy[0]);
               }
               if ( Z862CreditoUpdatedBy != T002P2_A862CreditoUpdatedBy[0] )
               {
                  GXUtil.WriteLog("credito:[seudo value changed for attri]"+"CreditoUpdatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z862CreditoUpdatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A862CreditoUpdatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Credito"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2P95( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2P95( 0) ;
            CheckOptimisticConcurrency2P95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2P95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002P14 */
                     pr_default.execute(12, new Object[] {n859CreditoCreatedAt, A859CreditoCreatedAt, n860CreditoUpdatedAt, A860CreditoUpdatedAt, n857CreditoValor, A857CreditoValor, n858CreditoVigencia, A858CreditoVigencia, n168ClienteId, A168ClienteId, n861CreditoCreatedBy, A861CreditoCreatedBy, n862CreditoUpdatedBy, A862CreditoUpdatedBy});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002P15 */
                     pr_default.execute(13);
                     A856CreditoId = T002P15_A856CreditoId[0];
                     AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Credito");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2P0( ) ;
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
               Load2P95( ) ;
            }
            EndLevel2P95( ) ;
         }
         CloseExtendedTableCursors2P95( ) ;
      }

      protected void Update2P95( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2P95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002P16 */
                     pr_default.execute(14, new Object[] {n859CreditoCreatedAt, A859CreditoCreatedAt, n860CreditoUpdatedAt, A860CreditoUpdatedAt, n857CreditoValor, A857CreditoValor, n858CreditoVigencia, A858CreditoVigencia, n168ClienteId, A168ClienteId, n861CreditoCreatedBy, A861CreditoCreatedBy, n862CreditoUpdatedBy, A862CreditoUpdatedBy, A856CreditoId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Credito");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Credito"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2P95( ) ;
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
            EndLevel2P95( ) ;
         }
         CloseExtendedTableCursors2P95( ) ;
      }

      protected void DeferredUpdate2P95( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2P95( ) ;
            AfterConfirm2P95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2P95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002P17 */
                  pr_default.execute(15, new Object[] {A856CreditoId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Credito");
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
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2P95( ) ;
         Gx_mode = sMode95;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2P95( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2P95( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("credito",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("credito",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2P95( )
      {
         /* Scan By routine */
         /* Using cursor T002P18 */
         pr_default.execute(16);
         RcdFound95 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound95 = 1;
            A856CreditoId = T002P18_A856CreditoId[0];
            AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2P95( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound95 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound95 = 1;
            A856CreditoId = T002P18_A856CreditoId[0];
            AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
         }
      }

      protected void ScanEnd2P95( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm2P95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2P95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2P95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2P95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2P95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2P95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2P95( )
      {
         edtCreditoValor_Enabled = 0;
         AssignProp("", false, edtCreditoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoValor_Enabled), 5, 0), true);
         edtCreditoVigencia_Enabled = 0;
         AssignProp("", false, edtCreditoVigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoVigencia_Enabled), 5, 0), true);
         edtCreditoId_Enabled = 0;
         AssignProp("", false, edtCreditoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtCreditoCreatedAt_Enabled = 0;
         AssignProp("", false, edtCreditoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoCreatedAt_Enabled), 5, 0), true);
         edtCreditoUpdatedAt_Enabled = 0;
         AssignProp("", false, edtCreditoUpdatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoUpdatedAt_Enabled), 5, 0), true);
         edtCreditoCreatedBy_Enabled = 0;
         AssignProp("", false, edtCreditoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCreditoCreatedBy_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2P95( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2P0( )
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
         GXEncryptionTmp = "credito"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CreditoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11Insert_ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("credito") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Credito");
         forbiddenHiddens.Add("CreditoId", context.localUtil.Format( (decimal)(A856CreditoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_CreditoCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_CreditoCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_CreditoUpdatedBy", context.localUtil.Format( (decimal)(AV24Insert_CreditoUpdatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("credito:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z856CreditoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z856CreditoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z859CreditoCreatedAt", context.localUtil.TToC( Z859CreditoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z860CreditoUpdatedAt", context.localUtil.TToC( Z860CreditoUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z857CreditoValor", StringUtil.LTrim( StringUtil.NToC( Z857CreditoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z858CreditoVigencia", context.localUtil.DToC( Z858CreditoVigencia, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z861CreditoCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z861CreditoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z862CreditoUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z862CreditoUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N861CreditoCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N862CreditoUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A862CreditoUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCREDITOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CreditoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCREDITOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CreditoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINSERT_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CREDITOCREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CreditoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CREDITOUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_CreditoUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CREDITOUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A862CreditoUpdatedBy), 4, 0, ",", "")));
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
         GXEncryptionTmp = "credito"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CreditoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11Insert_ClienteId,9,0));
         return formatLink("credito") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Credito" ;
      }

      public override string GetPgmdesc( )
      {
         return "Credito" ;
      }

      protected void InitializeNonKey2P95( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A861CreditoCreatedBy = 0;
         n861CreditoCreatedBy = false;
         AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
         n861CreditoCreatedBy = ((0==A861CreditoCreatedBy) ? true : false);
         A862CreditoUpdatedBy = 0;
         n862CreditoUpdatedBy = false;
         AssignAttri("", false, "A862CreditoUpdatedBy", ((0==A862CreditoUpdatedBy)&&IsIns( )||n862CreditoUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A862CreditoUpdatedBy), 4, 0, ".", ""))));
         A859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         n859CreditoCreatedAt = false;
         AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n859CreditoCreatedAt = ((DateTime.MinValue==A859CreditoCreatedAt) ? true : false);
         A860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         n860CreditoUpdatedAt = false;
         AssignAttri("", false, "A860CreditoUpdatedAt", context.localUtil.TToC( A860CreditoUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         n860CreditoUpdatedAt = ((DateTime.MinValue==A860CreditoUpdatedAt) ? true : false);
         A857CreditoValor = 0;
         n857CreditoValor = false;
         AssignAttri("", false, "A857CreditoValor", ((Convert.ToDecimal(0)==A857CreditoValor)&&IsIns( )||n857CreditoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A857CreditoValor, 18, 2, ".", ""))));
         n857CreditoValor = ((Convert.ToDecimal(0)==A857CreditoValor) ? true : false);
         A858CreditoVigencia = DateTime.MinValue;
         n858CreditoVigencia = false;
         AssignAttri("", false, "A858CreditoVigencia", context.localUtil.Format(A858CreditoVigencia, "99/99/9999"));
         n858CreditoVigencia = ((DateTime.MinValue==A858CreditoVigencia) ? true : false);
         Z859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         Z860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z857CreditoValor = 0;
         Z858CreditoVigencia = DateTime.MinValue;
         Z168ClienteId = 0;
         Z861CreditoCreatedBy = 0;
         Z862CreditoUpdatedBy = 0;
      }

      protected void InitAll2P95( )
      {
         A856CreditoId = 0;
         AssignAttri("", false, "A856CreditoId", StringUtil.LTrimStr( (decimal)(A856CreditoId), 9, 0));
         InitializeNonKey2P95( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A859CreditoCreatedAt = i859CreditoCreatedAt;
         n859CreditoCreatedAt = false;
         AssignAttri("", false, "A859CreditoCreatedAt", context.localUtil.TToC( A859CreditoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A861CreditoCreatedBy = i861CreditoCreatedBy;
         n861CreditoCreatedBy = false;
         AssignAttri("", false, "A861CreditoCreatedBy", ((0==A861CreditoCreatedBy)&&IsIns( )||n861CreditoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A861CreditoCreatedBy), 4, 0, ".", ""))));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019211523", true, true);
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
         context.AddJavascriptSource("credito.js", "?202561019211523", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCreditoValor_Internalname = "CREDITOVALOR";
         edtCreditoVigencia_Internalname = "CREDITOVIGENCIA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCreditoId_Internalname = "CREDITOID";
         edtClienteId_Internalname = "CLIENTEID";
         edtCreditoCreatedAt_Internalname = "CREDITOCREATEDAT";
         edtCreditoUpdatedAt_Internalname = "CREDITOUPDATEDAT";
         edtCreditoCreatedBy_Internalname = "CREDITOCREATEDBY";
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
         Form.Caption = "Credito";
         edtCreditoCreatedBy_Jsonclick = "";
         edtCreditoCreatedBy_Enabled = 1;
         edtCreditoCreatedBy_Visible = 1;
         edtCreditoUpdatedAt_Jsonclick = "";
         edtCreditoUpdatedAt_Enabled = 1;
         edtCreditoUpdatedAt_Visible = 1;
         edtCreditoCreatedAt_Jsonclick = "";
         edtCreditoCreatedAt_Enabled = 1;
         edtCreditoCreatedAt_Visible = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtClienteId_Visible = 1;
         edtCreditoId_Jsonclick = "";
         edtCreditoId_Enabled = 0;
         edtCreditoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCreditoVigencia_Jsonclick = "";
         edtCreditoVigencia_Enabled = 1;
         edtCreditoValor_Jsonclick = "";
         edtCreditoValor_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "";
         Dvpanel_tableattributes_Cls = "PanelNoHeader";
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

      public void Valid_Clienteid( )
      {
         /* Using cursor T002P19 */
         pr_default.execute(17, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Creditocreatedby( )
      {
         /* Using cursor T002P20 */
         pr_default.execute(18, new Object[] {n861CreditoCreatedBy, A861CreditoCreatedBy});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A861CreditoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sdb Credito Usuario'.", "ForeignKeyNotFound", 1, "CREDITOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtCreditoCreatedBy_Internalname;
            }
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7CreditoId","fld":"vCREDITOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV11Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7CreditoId","fld":"vCREDITOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV11Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A856CreditoId","fld":"CREDITOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_CreditoCreatedBy","fld":"vINSERT_CREDITOCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV24Insert_CreditoUpdatedBy","fld":"vINSERT_CREDITOUPDATEDBY","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122P2","iparms":[]}""");
         setEventMetadata("VALID_CREDITOVALOR","""{"handler":"Valid_Creditovalor","iparms":[]}""");
         setEventMetadata("VALID_CREDITOVIGENCIA","""{"handler":"Valid_Creditovigencia","iparms":[]}""");
         setEventMetadata("VALID_CREDITOID","""{"handler":"Valid_Creditoid","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("VALID_CREDITOCREATEDBY","""{"handler":"Valid_Creditocreatedby","iparms":[{"av":"A861CreditoCreatedBy","fld":"CREDITOCREATEDBY","pic":"ZZZ9","nullAv":"n861CreditoCreatedBy","type":"int"}]}""");
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
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         Z860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z858CreditoVigencia = DateTime.MinValue;
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
         A858CreditoVigencia = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         A860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         AV25Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode95 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         T002P7_A856CreditoId = new int[1] ;
         T002P7_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002P7_n859CreditoCreatedAt = new bool[] {false} ;
         T002P7_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002P7_n860CreditoUpdatedAt = new bool[] {false} ;
         T002P7_A857CreditoValor = new decimal[1] ;
         T002P7_n857CreditoValor = new bool[] {false} ;
         T002P7_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         T002P7_n858CreditoVigencia = new bool[] {false} ;
         T002P7_A168ClienteId = new int[1] ;
         T002P7_n168ClienteId = new bool[] {false} ;
         T002P7_A861CreditoCreatedBy = new short[1] ;
         T002P7_n861CreditoCreatedBy = new bool[] {false} ;
         T002P7_A862CreditoUpdatedBy = new short[1] ;
         T002P7_n862CreditoUpdatedBy = new bool[] {false} ;
         T002P4_A168ClienteId = new int[1] ;
         T002P4_n168ClienteId = new bool[] {false} ;
         T002P5_A861CreditoCreatedBy = new short[1] ;
         T002P5_n861CreditoCreatedBy = new bool[] {false} ;
         T002P6_A862CreditoUpdatedBy = new short[1] ;
         T002P6_n862CreditoUpdatedBy = new bool[] {false} ;
         T002P8_A168ClienteId = new int[1] ;
         T002P8_n168ClienteId = new bool[] {false} ;
         T002P9_A861CreditoCreatedBy = new short[1] ;
         T002P9_n861CreditoCreatedBy = new bool[] {false} ;
         T002P10_A862CreditoUpdatedBy = new short[1] ;
         T002P10_n862CreditoUpdatedBy = new bool[] {false} ;
         T002P11_A856CreditoId = new int[1] ;
         T002P3_A856CreditoId = new int[1] ;
         T002P3_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002P3_n859CreditoCreatedAt = new bool[] {false} ;
         T002P3_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002P3_n860CreditoUpdatedAt = new bool[] {false} ;
         T002P3_A857CreditoValor = new decimal[1] ;
         T002P3_n857CreditoValor = new bool[] {false} ;
         T002P3_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         T002P3_n858CreditoVigencia = new bool[] {false} ;
         T002P3_A168ClienteId = new int[1] ;
         T002P3_n168ClienteId = new bool[] {false} ;
         T002P3_A861CreditoCreatedBy = new short[1] ;
         T002P3_n861CreditoCreatedBy = new bool[] {false} ;
         T002P3_A862CreditoUpdatedBy = new short[1] ;
         T002P3_n862CreditoUpdatedBy = new bool[] {false} ;
         T002P12_A856CreditoId = new int[1] ;
         T002P13_A856CreditoId = new int[1] ;
         T002P2_A856CreditoId = new int[1] ;
         T002P2_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002P2_n859CreditoCreatedAt = new bool[] {false} ;
         T002P2_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002P2_n860CreditoUpdatedAt = new bool[] {false} ;
         T002P2_A857CreditoValor = new decimal[1] ;
         T002P2_n857CreditoValor = new bool[] {false} ;
         T002P2_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         T002P2_n858CreditoVigencia = new bool[] {false} ;
         T002P2_A168ClienteId = new int[1] ;
         T002P2_n168ClienteId = new bool[] {false} ;
         T002P2_A861CreditoCreatedBy = new short[1] ;
         T002P2_n861CreditoCreatedBy = new bool[] {false} ;
         T002P2_A862CreditoUpdatedBy = new short[1] ;
         T002P2_n862CreditoUpdatedBy = new bool[] {false} ;
         T002P15_A856CreditoId = new int[1] ;
         T002P18_A856CreditoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         T002P19_A168ClienteId = new int[1] ;
         T002P19_n168ClienteId = new bool[] {false} ;
         T002P20_A861CreditoCreatedBy = new short[1] ;
         T002P20_n861CreditoCreatedBy = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.credito__default(),
            new Object[][] {
                new Object[] {
               T002P2_A856CreditoId, T002P2_A859CreditoCreatedAt, T002P2_n859CreditoCreatedAt, T002P2_A860CreditoUpdatedAt, T002P2_n860CreditoUpdatedAt, T002P2_A857CreditoValor, T002P2_n857CreditoValor, T002P2_A858CreditoVigencia, T002P2_n858CreditoVigencia, T002P2_A168ClienteId,
               T002P2_n168ClienteId, T002P2_A861CreditoCreatedBy, T002P2_n861CreditoCreatedBy, T002P2_A862CreditoUpdatedBy, T002P2_n862CreditoUpdatedBy
               }
               , new Object[] {
               T002P3_A856CreditoId, T002P3_A859CreditoCreatedAt, T002P3_n859CreditoCreatedAt, T002P3_A860CreditoUpdatedAt, T002P3_n860CreditoUpdatedAt, T002P3_A857CreditoValor, T002P3_n857CreditoValor, T002P3_A858CreditoVigencia, T002P3_n858CreditoVigencia, T002P3_A168ClienteId,
               T002P3_n168ClienteId, T002P3_A861CreditoCreatedBy, T002P3_n861CreditoCreatedBy, T002P3_A862CreditoUpdatedBy, T002P3_n862CreditoUpdatedBy
               }
               , new Object[] {
               T002P4_A168ClienteId
               }
               , new Object[] {
               T002P5_A861CreditoCreatedBy
               }
               , new Object[] {
               T002P6_A862CreditoUpdatedBy
               }
               , new Object[] {
               T002P7_A856CreditoId, T002P7_A859CreditoCreatedAt, T002P7_n859CreditoCreatedAt, T002P7_A860CreditoUpdatedAt, T002P7_n860CreditoUpdatedAt, T002P7_A857CreditoValor, T002P7_n857CreditoValor, T002P7_A858CreditoVigencia, T002P7_n858CreditoVigencia, T002P7_A168ClienteId,
               T002P7_n168ClienteId, T002P7_A861CreditoCreatedBy, T002P7_n861CreditoCreatedBy, T002P7_A862CreditoUpdatedBy, T002P7_n862CreditoUpdatedBy
               }
               , new Object[] {
               T002P8_A168ClienteId
               }
               , new Object[] {
               T002P9_A861CreditoCreatedBy
               }
               , new Object[] {
               T002P10_A862CreditoUpdatedBy
               }
               , new Object[] {
               T002P11_A856CreditoId
               }
               , new Object[] {
               T002P12_A856CreditoId
               }
               , new Object[] {
               T002P13_A856CreditoId
               }
               , new Object[] {
               }
               , new Object[] {
               T002P15_A856CreditoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002P18_A856CreditoId
               }
               , new Object[] {
               T002P19_A168ClienteId
               }
               , new Object[] {
               T002P20_A861CreditoCreatedBy
               }
            }
         );
         AV25Pgmname = "Credito";
      }

      private short Z861CreditoCreatedBy ;
      private short Z862CreditoUpdatedBy ;
      private short N861CreditoCreatedBy ;
      private short N862CreditoUpdatedBy ;
      private short GxWebError ;
      private short A861CreditoCreatedBy ;
      private short A862CreditoUpdatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV12Insert_CreditoCreatedBy ;
      private short AV24Insert_CreditoUpdatedBy ;
      private short RcdFound95 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short i861CreditoCreatedBy ;
      private int wcpOAV7CreditoId ;
      private int wcpOAV11Insert_ClienteId ;
      private int Z856CreditoId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int AV7CreditoId ;
      private int AV11Insert_ClienteId ;
      private int trnEnded ;
      private int edtCreditoValor_Enabled ;
      private int edtCreditoVigencia_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A856CreditoId ;
      private int edtCreditoId_Enabled ;
      private int edtCreditoId_Visible ;
      private int edtClienteId_Visible ;
      private int edtClienteId_Enabled ;
      private int edtCreditoCreatedAt_Visible ;
      private int edtCreditoCreatedAt_Enabled ;
      private int edtCreditoUpdatedAt_Visible ;
      private int edtCreditoUpdatedAt_Enabled ;
      private int edtCreditoCreatedBy_Visible ;
      private int edtCreditoCreatedBy_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private decimal Z857CreditoValor ;
      private decimal A857CreditoValor ;
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
      private string edtCreditoValor_Internalname ;
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
      private string edtCreditoValor_Jsonclick ;
      private string edtCreditoVigencia_Internalname ;
      private string edtCreditoVigencia_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCreditoId_Internalname ;
      private string edtCreditoId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtCreditoCreatedAt_Internalname ;
      private string edtCreditoCreatedAt_Jsonclick ;
      private string edtCreditoUpdatedAt_Internalname ;
      private string edtCreditoUpdatedAt_Jsonclick ;
      private string edtCreditoCreatedBy_Internalname ;
      private string edtCreditoCreatedBy_Jsonclick ;
      private string AV25Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode95 ;
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
      private DateTime Z859CreditoCreatedAt ;
      private DateTime Z860CreditoUpdatedAt ;
      private DateTime A859CreditoCreatedAt ;
      private DateTime A860CreditoUpdatedAt ;
      private DateTime i859CreditoCreatedAt ;
      private DateTime Z858CreditoVigencia ;
      private DateTime A858CreditoVigencia ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n168ClienteId ;
      private bool n861CreditoCreatedBy ;
      private bool n862CreditoUpdatedBy ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n857CreditoValor ;
      private bool n859CreditoCreatedAt ;
      private bool n860CreditoUpdatedAt ;
      private bool n858CreditoVigencia ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] T002P7_A856CreditoId ;
      private DateTime[] T002P7_A859CreditoCreatedAt ;
      private bool[] T002P7_n859CreditoCreatedAt ;
      private DateTime[] T002P7_A860CreditoUpdatedAt ;
      private bool[] T002P7_n860CreditoUpdatedAt ;
      private decimal[] T002P7_A857CreditoValor ;
      private bool[] T002P7_n857CreditoValor ;
      private DateTime[] T002P7_A858CreditoVigencia ;
      private bool[] T002P7_n858CreditoVigencia ;
      private int[] T002P7_A168ClienteId ;
      private bool[] T002P7_n168ClienteId ;
      private short[] T002P7_A861CreditoCreatedBy ;
      private bool[] T002P7_n861CreditoCreatedBy ;
      private short[] T002P7_A862CreditoUpdatedBy ;
      private bool[] T002P7_n862CreditoUpdatedBy ;
      private int[] T002P4_A168ClienteId ;
      private bool[] T002P4_n168ClienteId ;
      private short[] T002P5_A861CreditoCreatedBy ;
      private bool[] T002P5_n861CreditoCreatedBy ;
      private short[] T002P6_A862CreditoUpdatedBy ;
      private bool[] T002P6_n862CreditoUpdatedBy ;
      private int[] T002P8_A168ClienteId ;
      private bool[] T002P8_n168ClienteId ;
      private short[] T002P9_A861CreditoCreatedBy ;
      private bool[] T002P9_n861CreditoCreatedBy ;
      private short[] T002P10_A862CreditoUpdatedBy ;
      private bool[] T002P10_n862CreditoUpdatedBy ;
      private int[] T002P11_A856CreditoId ;
      private int[] T002P3_A856CreditoId ;
      private DateTime[] T002P3_A859CreditoCreatedAt ;
      private bool[] T002P3_n859CreditoCreatedAt ;
      private DateTime[] T002P3_A860CreditoUpdatedAt ;
      private bool[] T002P3_n860CreditoUpdatedAt ;
      private decimal[] T002P3_A857CreditoValor ;
      private bool[] T002P3_n857CreditoValor ;
      private DateTime[] T002P3_A858CreditoVigencia ;
      private bool[] T002P3_n858CreditoVigencia ;
      private int[] T002P3_A168ClienteId ;
      private bool[] T002P3_n168ClienteId ;
      private short[] T002P3_A861CreditoCreatedBy ;
      private bool[] T002P3_n861CreditoCreatedBy ;
      private short[] T002P3_A862CreditoUpdatedBy ;
      private bool[] T002P3_n862CreditoUpdatedBy ;
      private int[] T002P12_A856CreditoId ;
      private int[] T002P13_A856CreditoId ;
      private int[] T002P2_A856CreditoId ;
      private DateTime[] T002P2_A859CreditoCreatedAt ;
      private bool[] T002P2_n859CreditoCreatedAt ;
      private DateTime[] T002P2_A860CreditoUpdatedAt ;
      private bool[] T002P2_n860CreditoUpdatedAt ;
      private decimal[] T002P2_A857CreditoValor ;
      private bool[] T002P2_n857CreditoValor ;
      private DateTime[] T002P2_A858CreditoVigencia ;
      private bool[] T002P2_n858CreditoVigencia ;
      private int[] T002P2_A168ClienteId ;
      private bool[] T002P2_n168ClienteId ;
      private short[] T002P2_A861CreditoCreatedBy ;
      private bool[] T002P2_n861CreditoCreatedBy ;
      private short[] T002P2_A862CreditoUpdatedBy ;
      private bool[] T002P2_n862CreditoUpdatedBy ;
      private int[] T002P15_A856CreditoId ;
      private int[] T002P18_A856CreditoId ;
      private int[] T002P19_A168ClienteId ;
      private bool[] T002P19_n168ClienteId ;
      private short[] T002P20_A861CreditoCreatedBy ;
      private bool[] T002P20_n861CreditoCreatedBy ;
   }

   public class credito__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002P2;
          prmT002P2 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P3;
          prmT002P3 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P4;
          prmT002P4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002P5;
          prmT002P5 = new Object[] {
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002P6;
          prmT002P6 = new Object[] {
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002P7;
          prmT002P7 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P8;
          prmT002P8 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002P9;
          prmT002P9 = new Object[] {
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002P10;
          prmT002P10 = new Object[] {
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002P11;
          prmT002P11 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P12;
          prmT002P12 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P13;
          prmT002P13 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P14;
          prmT002P14 = new Object[] {
          new ParDef("CreditoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("CreditoVigencia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002P15;
          prmT002P15 = new Object[] {
          };
          Object[] prmT002P16;
          prmT002P16 = new Object[] {
          new ParDef("CreditoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("CreditoVigencia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P17;
          prmT002P17 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmT002P18;
          prmT002P18 = new Object[] {
          };
          Object[] prmT002P19;
          prmT002P19 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002P20;
          prmT002P20 = new Object[] {
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002P2", "SELECT CreditoId, CreditoCreatedAt, CreditoUpdatedAt, CreditoValor, CreditoVigencia, ClienteId, CreditoCreatedBy, CreditoUpdatedBy FROM Credito WHERE CreditoId = :CreditoId  FOR UPDATE OF Credito NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002P2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P3", "SELECT CreditoId, CreditoCreatedAt, CreditoUpdatedAt, CreditoValor, CreditoVigencia, ClienteId, CreditoCreatedBy, CreditoUpdatedBy FROM Credito WHERE CreditoId = :CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P4", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P5", "SELECT SecUserId AS CreditoCreatedBy FROM SecUser WHERE SecUserId = :CreditoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P6", "SELECT SecUserId AS CreditoUpdatedBy FROM SecUser WHERE SecUserId = :CreditoUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P7", "SELECT TM1.CreditoId, TM1.CreditoCreatedAt, TM1.CreditoUpdatedAt, TM1.CreditoValor, TM1.CreditoVigencia, TM1.ClienteId, TM1.CreditoCreatedBy AS CreditoCreatedBy, TM1.CreditoUpdatedBy AS CreditoUpdatedBy FROM Credito TM1 WHERE TM1.CreditoId = :CreditoId ORDER BY TM1.CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P8", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P9", "SELECT SecUserId AS CreditoCreatedBy FROM SecUser WHERE SecUserId = :CreditoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P10", "SELECT SecUserId AS CreditoUpdatedBy FROM SecUser WHERE SecUserId = :CreditoUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P11", "SELECT CreditoId FROM Credito WHERE CreditoId = :CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P12", "SELECT CreditoId FROM Credito WHERE ( CreditoId > :CreditoId) ORDER BY CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002P13", "SELECT CreditoId FROM Credito WHERE ( CreditoId < :CreditoId) ORDER BY CreditoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002P14", "SAVEPOINT gxupdate;INSERT INTO Credito(CreditoCreatedAt, CreditoUpdatedAt, CreditoValor, CreditoVigencia, ClienteId, CreditoCreatedBy, CreditoUpdatedBy) VALUES(:CreditoCreatedAt, :CreditoUpdatedAt, :CreditoValor, :CreditoVigencia, :ClienteId, :CreditoCreatedBy, :CreditoUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002P14)
             ,new CursorDef("T002P15", "SELECT currval('CreditoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P16", "SAVEPOINT gxupdate;UPDATE Credito SET CreditoCreatedAt=:CreditoCreatedAt, CreditoUpdatedAt=:CreditoUpdatedAt, CreditoValor=:CreditoValor, CreditoVigencia=:CreditoVigencia, ClienteId=:ClienteId, CreditoCreatedBy=:CreditoCreatedBy, CreditoUpdatedBy=:CreditoUpdatedBy  WHERE CreditoId = :CreditoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002P16)
             ,new CursorDef("T002P17", "SAVEPOINT gxupdate;DELETE FROM Credito  WHERE CreditoId = :CreditoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002P17)
             ,new CursorDef("T002P18", "SELECT CreditoId FROM Credito ORDER BY CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P18,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P19", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002P20", "SELECT SecUserId AS CreditoCreatedBy FROM SecUser WHERE SecUserId = :CreditoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P20,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
