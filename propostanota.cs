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
   public class propostanota : GXDataArea
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
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A850PropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaEmpresaClienteId"), "."), 18, MidpointRounding.ToEven));
            n850PropostaEmpresaClienteId = false;
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A850PropostaEmpresaClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "propostanota")), "propostanota") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "propostanota")))) ;
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
                  AV7PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7PropostaId", StringUtil.LTrimStr( (decimal)(AV7PropostaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Proposta Nota", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPropostaProtocolo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public propostanota( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostanota( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PropostaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PropostaId = aP1_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPropostaTipoProposta = new GXCombobox();
         cmbPropostaStatus = new GXCombobox();
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
         if ( cmbPropostaTipoProposta.ItemCount > 0 )
         {
            A849PropostaTipoProposta = cmbPropostaTipoProposta.getValidValue(A849PropostaTipoProposta);
            n849PropostaTipoProposta = false;
            AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaTipoProposta.CurrentValue = StringUtil.RTrim( A849PropostaTipoProposta);
            AssignProp("", false, cmbPropostaTipoProposta_Internalname, "Values", cmbPropostaTipoProposta.ToJavascriptSource(), true);
         }
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", cmbPropostaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtPropostaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaQtdItensNota_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaQtdItensNota_F_Internalname, "Itens Nota_F", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaQtdItensNota_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaQtdItensNota_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A854PropostaQtdItensNota_F), "ZZZ9") : context.localUtil.Format( (decimal)(A854PropostaQtdItensNota_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaQtdItensNota_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaQtdItensNota_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaProtocolo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaProtocolo_Internalname, "Protocolo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaProtocolo_Internalname, A853PropostaProtocolo, StringUtil.RTrim( context.localUtil.Format( A853PropostaProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaProtocolo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaProtocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPropostaTipoProposta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPropostaTipoProposta_Internalname, "Tipo Proposta", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaTipoProposta, cmbPropostaTipoProposta_Internalname, StringUtil.RTrim( A849PropostaTipoProposta), 1, cmbPropostaTipoProposta_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaTipoProposta.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_PropostaNota.htm");
         cmbPropostaTipoProposta.CurrentValue = StringUtil.RTrim( A849PropostaTipoProposta);
         AssignProp("", false, cmbPropostaTipoProposta_Internalname, "Values", (string)(cmbPropostaTipoProposta.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaSumItensnota_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaSumItensnota_F_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaSumItensnota_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A887PropostaSumItensnota_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtPropostaSumItensnota_F_Enabled!=0) ? context.localUtil.Format( A887PropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A887PropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaSumItensnota_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaSumItensnota_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpropostaempresaclienteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpropostaempresaclienteid_Internalname, "Cliente Id", "", "", lblTextblockpropostaempresaclienteid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_propostaempresaclienteid.SetProperty("Caption", Combo_propostaempresaclienteid_Caption);
         ucCombo_propostaempresaclienteid.SetProperty("Cls", Combo_propostaempresaclienteid_Cls);
         ucCombo_propostaempresaclienteid.SetProperty("DataListProc", Combo_propostaempresaclienteid_Datalistproc);
         ucCombo_propostaempresaclienteid.SetProperty("DataListProcParametersPrefix", Combo_propostaempresaclienteid_Datalistprocparametersprefix);
         ucCombo_propostaempresaclienteid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_propostaempresaclienteid.SetProperty("DropDownOptionsData", AV13PropostaEmpresaClienteId_Data);
         ucCombo_propostaempresaclienteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_propostaempresaclienteid_Internalname, "COMBO_PROPOSTAEMPRESACLIENTEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaEmpresaClienteId_Internalname, "Proposta Empresa Cliente Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaEmpresaClienteId_Internalname, ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ",", ""))), ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A850PropostaEmpresaClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaEmpresaClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaEmpresaClienteId_Visible, edtPropostaEmpresaClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaNota.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaEmpresaRazao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaEmpresaRazao_Internalname, "Empresa Razao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaEmpresaRazao_Internalname, A888PropostaEmpresaRazao, StringUtil.RTrim( context.localUtil.Format( A888PropostaEmpresaRazao, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaEmpresaRazao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaEmpresaRazao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaCreatedAt_Internalname, "Created At", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPropostaCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPropostaCreatedAt_Internalname, context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaNota.htm");
         GxWebStd.gx_bitmap( context, edtPropostaCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPropostaCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PropostaNota.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPropostaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPropostaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaStatus, cmbPropostaStatus_Internalname, StringUtil.RTrim( A329PropostaStatus), 1, cmbPropostaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_PropostaNota.htm");
         cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
         AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaNota.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaNota.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_propostaempresaclienteid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopropostaempresaclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboPropostaEmpresaClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombopropostaempresaclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboPropostaEmpresaClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboPropostaEmpresaClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopropostaempresaclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopropostaempresaclienteid_Visible, edtavCombopropostaempresaclienteid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaNota.htm");
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
         E112S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTAEMPRESACLIENTEID_DATA"), AV13PropostaEmpresaClienteId_Data);
               /* Read saved values. */
               Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z327PropostaCreatedAt = context.localUtil.CToT( cgiGet( "Z327PropostaCreatedAt"), 0);
               n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
               Z853PropostaProtocolo = cgiGet( "Z853PropostaProtocolo");
               n853PropostaProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? true : false);
               Z849PropostaTipoProposta = cgiGet( "Z849PropostaTipoProposta");
               n849PropostaTipoProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ? true : false);
               Z329PropostaStatus = cgiGet( "Z329PropostaStatus");
               n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
               Z850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z850PropostaEmpresaClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N850PropostaEmpresaClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
               AV7PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTAEMPRESACLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_PropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaEmpresaClienteId), 9, 0));
               AV20Pgmname = cgiGet( "vPGMNAME");
               Combo_propostaempresaclienteid_Objectcall = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Objectcall");
               Combo_propostaempresaclienteid_Class = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Class");
               Combo_propostaempresaclienteid_Icontype = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Icontype");
               Combo_propostaempresaclienteid_Icon = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Icon");
               Combo_propostaempresaclienteid_Caption = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Caption");
               Combo_propostaempresaclienteid_Tooltip = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Tooltip");
               Combo_propostaempresaclienteid_Cls = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Cls");
               Combo_propostaempresaclienteid_Selectedvalue_set = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Selectedvalue_set");
               Combo_propostaempresaclienteid_Selectedvalue_get = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Selectedvalue_get");
               Combo_propostaempresaclienteid_Selectedtext_set = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Selectedtext_set");
               Combo_propostaempresaclienteid_Selectedtext_get = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Selectedtext_get");
               Combo_propostaempresaclienteid_Gamoauthtoken = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Gamoauthtoken");
               Combo_propostaempresaclienteid_Ddointernalname = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Ddointernalname");
               Combo_propostaempresaclienteid_Titlecontrolalign = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Titlecontrolalign");
               Combo_propostaempresaclienteid_Dropdownoptionstype = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Dropdownoptionstype");
               Combo_propostaempresaclienteid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Enabled"));
               Combo_propostaempresaclienteid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Visible"));
               Combo_propostaempresaclienteid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Titlecontrolidtoreplace");
               Combo_propostaempresaclienteid_Datalisttype = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Datalisttype");
               Combo_propostaempresaclienteid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Allowmultipleselection"));
               Combo_propostaempresaclienteid_Datalistfixedvalues = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Datalistfixedvalues");
               Combo_propostaempresaclienteid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Isgriditem"));
               Combo_propostaempresaclienteid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Hasdescription"));
               Combo_propostaempresaclienteid_Datalistproc = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Datalistproc");
               Combo_propostaempresaclienteid_Datalistprocparametersprefix = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Datalistprocparametersprefix");
               Combo_propostaempresaclienteid_Remoteservicesparameters = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Remoteservicesparameters");
               Combo_propostaempresaclienteid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostaempresaclienteid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Includeonlyselectedoption"));
               Combo_propostaempresaclienteid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Includeselectalloption"));
               Combo_propostaempresaclienteid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Emptyitem"));
               Combo_propostaempresaclienteid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Includeaddnewoption"));
               Combo_propostaempresaclienteid_Htmltemplate = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Htmltemplate");
               Combo_propostaempresaclienteid_Multiplevaluestype = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Multiplevaluestype");
               Combo_propostaempresaclienteid_Loadingdata = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Loadingdata");
               Combo_propostaempresaclienteid_Noresultsfound = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Noresultsfound");
               Combo_propostaempresaclienteid_Emptyitemtext = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Emptyitemtext");
               Combo_propostaempresaclienteid_Onlyselectedvalues = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Onlyselectedvalues");
               Combo_propostaempresaclienteid_Selectalltext = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Selectalltext");
               Combo_propostaempresaclienteid_Multiplevaluesseparator = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Multiplevaluesseparator");
               Combo_propostaempresaclienteid_Addnewoptiontext = cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Addnewoptiontext");
               Combo_propostaempresaclienteid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTAEMPRESACLIENTEID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               A854PropostaQtdItensNota_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaQtdItensNota_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
               A853PropostaProtocolo = cgiGet( edtPropostaProtocolo_Internalname);
               n853PropostaProtocolo = false;
               AssignAttri("", false, "A853PropostaProtocolo", A853PropostaProtocolo);
               n853PropostaProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? true : false);
               cmbPropostaTipoProposta.CurrentValue = cgiGet( cmbPropostaTipoProposta_Internalname);
               A849PropostaTipoProposta = cgiGet( cmbPropostaTipoProposta_Internalname);
               n849PropostaTipoProposta = false;
               AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
               n849PropostaTipoProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ? true : false);
               A887PropostaSumItensnota_F = context.localUtil.CToN( cgiGet( edtPropostaSumItensnota_F_Internalname), ",", ".");
               AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
               n850PropostaEmpresaClienteId = ((StringUtil.StrCmp(cgiGet( edtPropostaEmpresaClienteId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaEmpresaClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaEmpresaClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAEMPRESACLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaEmpresaClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A850PropostaEmpresaClienteId = 0;
                  n850PropostaEmpresaClienteId = false;
                  AssignAttri("", false, "A850PropostaEmpresaClienteId", (n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
               }
               else
               {
                  A850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaEmpresaClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A850PropostaEmpresaClienteId", (n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
               }
               A888PropostaEmpresaRazao = StringUtil.Upper( cgiGet( edtPropostaEmpresaRazao_Internalname));
               n888PropostaEmpresaRazao = false;
               AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
               if ( context.localUtil.VCDateTime( cgiGet( edtPropostaCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Proposta Created At"}), 1, "PROPOSTACREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
                  n327PropostaCreatedAt = false;
                  AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A327PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtPropostaCreatedAt_Internalname));
                  n327PropostaCreatedAt = false;
                  AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
               cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
               A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
               n329PropostaStatus = false;
               AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
               n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
               AV18ComboPropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombopropostaempresaclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboPropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboPropostaEmpresaClienteId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PropostaNota");
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               forbiddenHiddens.Add("PropostaId", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaEmpresaClienteId", context.localUtil.Format( (decimal)(AV11Insert_PropostaEmpresaClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A323PropostaId != Z323PropostaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("propostanota:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
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
                     sMode49 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode49;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound49 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROPOSTAID");
                        AnyError = 1;
                        GX_FocusControl = edtPropostaId_Internalname;
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
                           E112S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122S2 ();
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
            E122S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2S49( ) ;
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
            DisableAttributes2S49( ) ;
         }
         AssignProp("", false, edtavCombopropostaempresaclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostaempresaclienteid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2S0( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2S49( ) ;
            }
            else
            {
               CheckExtendedTable2S49( ) ;
               CloseExtendedTableCursors2S49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2S0( )
      {
      }

      protected void E112S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtPropostaEmpresaClienteId_Visible = 0;
         AssignProp("", false, edtPropostaEmpresaClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaEmpresaClienteId_Visible), 5, 0), true);
         AV18ComboPropostaEmpresaClienteId = 0;
         AssignAttri("", false, "AV18ComboPropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboPropostaEmpresaClienteId), 9, 0));
         edtavCombopropostaempresaclienteid_Visible = 0;
         AssignProp("", false, edtavCombopropostaempresaclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopropostaempresaclienteid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPROPOSTAEMPRESACLIENTEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV20Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV21GXV1 = 1;
            AssignAttri("", false, "AV21GXV1", StringUtil.LTrimStr( (decimal)(AV21GXV1), 8, 0));
            while ( AV21GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV21GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PropostaEmpresaClienteId") == 0 )
               {
                  AV11Insert_PropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaEmpresaClienteId), 9, 0));
                  if ( ! (0==AV11Insert_PropostaEmpresaClienteId) )
                  {
                     AV18ComboPropostaEmpresaClienteId = AV11Insert_PropostaEmpresaClienteId;
                     AssignAttri("", false, "AV18ComboPropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboPropostaEmpresaClienteId), 9, 0));
                     Combo_propostaempresaclienteid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboPropostaEmpresaClienteId), 9, 0));
                     ucCombo_propostaempresaclienteid.SendProperty(context, "", false, Combo_propostaempresaclienteid_Internalname, "SelectedValue_set", Combo_propostaempresaclienteid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new propostanotaloaddvcombo(context ).execute(  "PropostaEmpresaClienteId",  "GET",  false,  AV7PropostaId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_propostaempresaclienteid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_propostaempresaclienteid.SendProperty(context, "", false, Combo_propostaempresaclienteid_Internalname, "SelectedText_set", Combo_propostaempresaclienteid_Selectedtext_set);
                     Combo_propostaempresaclienteid_Enabled = false;
                     ucCombo_propostaempresaclienteid.SendProperty(context, "", false, Combo_propostaempresaclienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostaempresaclienteid_Enabled));
                  }
               }
               AV21GXV1 = (int)(AV21GXV1+1);
               AssignAttri("", false, "AV21GXV1", StringUtil.LTrimStr( (decimal)(AV21GXV1), 8, 0));
            }
         }
      }

      protected void E122S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("propostanotaww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROPOSTAEMPRESACLIENTEID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new propostanotaloaddvcombo(context ).execute(  "PropostaEmpresaClienteId",  Gx_mode,  false,  AV7PropostaId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_propostaempresaclienteid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_propostaempresaclienteid.SendProperty(context, "", false, Combo_propostaempresaclienteid_Internalname, "SelectedValue_set", Combo_propostaempresaclienteid_Selectedvalue_set);
         Combo_propostaempresaclienteid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_propostaempresaclienteid.SendProperty(context, "", false, Combo_propostaempresaclienteid_Internalname, "SelectedText_set", Combo_propostaempresaclienteid_Selectedtext_set);
         AV18ComboPropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18ComboPropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboPropostaEmpresaClienteId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_propostaempresaclienteid_Enabled = false;
            ucCombo_propostaempresaclienteid.SendProperty(context, "", false, Combo_propostaempresaclienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostaempresaclienteid_Enabled));
         }
      }

      protected void ZM2S49( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z327PropostaCreatedAt = T002S3_A327PropostaCreatedAt[0];
               Z853PropostaProtocolo = T002S3_A853PropostaProtocolo[0];
               Z849PropostaTipoProposta = T002S3_A849PropostaTipoProposta[0];
               Z329PropostaStatus = T002S3_A329PropostaStatus[0];
               Z850PropostaEmpresaClienteId = T002S3_A850PropostaEmpresaClienteId[0];
            }
            else
            {
               Z327PropostaCreatedAt = A327PropostaCreatedAt;
               Z853PropostaProtocolo = A853PropostaProtocolo;
               Z849PropostaTipoProposta = A849PropostaTipoProposta;
               Z329PropostaStatus = A329PropostaStatus;
               Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z323PropostaId = A323PropostaId;
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z853PropostaProtocolo = A853PropostaProtocolo;
            Z849PropostaTipoProposta = A849PropostaTipoProposta;
            Z329PropostaStatus = A329PropostaStatus;
            Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z887PropostaSumItensnota_F = A887PropostaSumItensnota_F;
            Z888PropostaEmpresaRazao = A888PropostaEmpresaRazao;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         AV20Pgmname = "PropostaNota";
         AssignAttri("", false, "AV20Pgmname", AV20Pgmname);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PropostaId) )
         {
            A323PropostaId = AV7PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaEmpresaClienteId) )
         {
            edtPropostaEmpresaClienteId_Enabled = 0;
            AssignProp("", false, edtPropostaEmpresaClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaEmpresaClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtPropostaEmpresaClienteId_Enabled = 1;
            AssignProp("", false, edtPropostaEmpresaClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaEmpresaClienteId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A327PropostaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n327PropostaCreatedAt = false;
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaEmpresaClienteId) )
         {
            A850PropostaEmpresaClienteId = AV11Insert_PropostaEmpresaClienteId;
            n850PropostaEmpresaClienteId = false;
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV18ComboPropostaEmpresaClienteId) )
            {
               A850PropostaEmpresaClienteId = 0;
               n850PropostaEmpresaClienteId = false;
               AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
               n850PropostaEmpresaClienteId = true;
               n850PropostaEmpresaClienteId = true;
               AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV18ComboPropostaEmpresaClienteId) )
               {
                  A850PropostaEmpresaClienteId = AV18ComboPropostaEmpresaClienteId;
                  n850PropostaEmpresaClienteId = false;
                  AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002S6 */
            pr_default.execute(3, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(3) != 101) )
            {
               A854PropostaQtdItensNota_F = T002S6_A854PropostaQtdItensNota_F[0];
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
               A887PropostaSumItensnota_F = T002S6_A887PropostaSumItensnota_F[0];
               AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
            }
            else
            {
               A854PropostaQtdItensNota_F = 0;
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
               A887PropostaSumItensnota_F = 0;
               AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
            }
            pr_default.close(3);
            /* Using cursor T002S4 */
            pr_default.execute(2, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
            A888PropostaEmpresaRazao = T002S4_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = T002S4_n888PropostaEmpresaRazao[0];
            AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
            pr_default.close(2);
         }
      }

      protected void Load2S49( )
      {
         /* Using cursor T002S8 */
         pr_default.execute(4, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = T002S8_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = T002S8_n327PropostaCreatedAt[0];
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A853PropostaProtocolo = T002S8_A853PropostaProtocolo[0];
            n853PropostaProtocolo = T002S8_n853PropostaProtocolo[0];
            AssignAttri("", false, "A853PropostaProtocolo", A853PropostaProtocolo);
            A849PropostaTipoProposta = T002S8_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = T002S8_n849PropostaTipoProposta[0];
            AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
            A888PropostaEmpresaRazao = T002S8_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = T002S8_n888PropostaEmpresaRazao[0];
            AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
            A329PropostaStatus = T002S8_A329PropostaStatus[0];
            n329PropostaStatus = T002S8_n329PropostaStatus[0];
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
            A850PropostaEmpresaClienteId = T002S8_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = T002S8_n850PropostaEmpresaClienteId[0];
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            A854PropostaQtdItensNota_F = T002S8_A854PropostaQtdItensNota_F[0];
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            A887PropostaSumItensnota_F = T002S8_A887PropostaSumItensnota_F[0];
            AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
            ZM2S49( -11) ;
         }
         pr_default.close(4);
         OnLoadActions2S49( ) ;
      }

      protected void OnLoadActions2S49( )
      {
      }

      protected void CheckExtendedTable2S49( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002S6 */
         pr_default.execute(3, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A854PropostaQtdItensNota_F = T002S6_A854PropostaQtdItensNota_F[0];
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            A887PropostaSumItensnota_F = T002S6_A887PropostaSumItensnota_F[0];
            AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            A887PropostaSumItensnota_F = 0;
            AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A849PropostaTipoProposta, "CLINICA") == 0 ) || ( StringUtil.StrCmp(A849PropostaTipoProposta, "COMPRA_TITULO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ) )
         {
            GX_msglist.addItem("Campo Proposta Tipo Proposta fora do intervalo", "OutOfRange", 1, "PROPOSTATIPOPROPOSTA");
            AnyError = 1;
            GX_FocusControl = cmbPropostaTipoProposta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002S4 */
         pr_default.execute(2, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtPropostaEmpresaClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A888PropostaEmpresaRazao = T002S4_A888PropostaEmpresaRazao[0];
         n888PropostaEmpresaRazao = T002S4_n888PropostaEmpresaRazao[0];
         AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Status fora do intervalo", "OutOfRange", 1, "PROPOSTASTATUS");
            AnyError = 1;
            GX_FocusControl = cmbPropostaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2S49( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A323PropostaId )
      {
         /* Using cursor T002S10 */
         pr_default.execute(5, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A854PropostaQtdItensNota_F = T002S10_A854PropostaQtdItensNota_F[0];
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            A887PropostaSumItensnota_F = T002S10_A887PropostaSumItensnota_F[0];
            AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            A887PropostaSumItensnota_F = 0;
            AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A887PropostaSumItensnota_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_12( int A850PropostaEmpresaClienteId )
      {
         /* Using cursor T002S11 */
         pr_default.execute(6, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtPropostaEmpresaClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A888PropostaEmpresaRazao = T002S11_A888PropostaEmpresaRazao[0];
         n888PropostaEmpresaRazao = T002S11_n888PropostaEmpresaRazao[0];
         AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A888PropostaEmpresaRazao)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2S49( )
      {
         /* Using cursor T002S12 */
         pr_default.execute(7, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002S3 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2S49( 11) ;
            RcdFound49 = 1;
            A323PropostaId = T002S3_A323PropostaId[0];
            n323PropostaId = T002S3_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A327PropostaCreatedAt = T002S3_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = T002S3_n327PropostaCreatedAt[0];
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A853PropostaProtocolo = T002S3_A853PropostaProtocolo[0];
            n853PropostaProtocolo = T002S3_n853PropostaProtocolo[0];
            AssignAttri("", false, "A853PropostaProtocolo", A853PropostaProtocolo);
            A849PropostaTipoProposta = T002S3_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = T002S3_n849PropostaTipoProposta[0];
            AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
            A329PropostaStatus = T002S3_A329PropostaStatus[0];
            n329PropostaStatus = T002S3_n329PropostaStatus[0];
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
            A850PropostaEmpresaClienteId = T002S3_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = T002S3_n850PropostaEmpresaClienteId[0];
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2S49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey2S49( ) ;
            }
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey2S49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2S49( ) ;
         if ( RcdFound49 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound49 = 0;
         /* Using cursor T002S13 */
         pr_default.execute(8, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002S13_A323PropostaId[0] < A323PropostaId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002S13_A323PropostaId[0] > A323PropostaId ) ) )
            {
               A323PropostaId = T002S13_A323PropostaId[0];
               n323PropostaId = T002S13_n323PropostaId[0];
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound49 = 0;
         /* Using cursor T002S14 */
         pr_default.execute(9, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002S14_A323PropostaId[0] > A323PropostaId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002S14_A323PropostaId[0] < A323PropostaId ) ) )
            {
               A323PropostaId = T002S14_A323PropostaId[0];
               n323PropostaId = T002S14_n323PropostaId[0];
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2S49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPropostaProtocolo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2S49( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound49 == 1 )
            {
               if ( A323PropostaId != Z323PropostaId )
               {
                  A323PropostaId = Z323PropostaId;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROPOSTAID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPropostaProtocolo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2S49( ) ;
                  GX_FocusControl = edtPropostaProtocolo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A323PropostaId != Z323PropostaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPropostaProtocolo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2S49( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPOSTAID");
                     AnyError = 1;
                     GX_FocusControl = edtPropostaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPropostaProtocolo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2S49( ) ;
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
         if ( A323PropostaId != Z323PropostaId )
         {
            A323PropostaId = Z323PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROPOSTAID");
            AnyError = 1;
            GX_FocusControl = edtPropostaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPropostaProtocolo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2S49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002S2 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != T002S2_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z853PropostaProtocolo, T002S2_A853PropostaProtocolo[0]) != 0 ) || ( StringUtil.StrCmp(Z849PropostaTipoProposta, T002S2_A849PropostaTipoProposta[0]) != 0 ) || ( StringUtil.StrCmp(Z329PropostaStatus, T002S2_A329PropostaStatus[0]) != 0 ) || ( Z850PropostaEmpresaClienteId != T002S2_A850PropostaEmpresaClienteId[0] ) )
            {
               if ( Z327PropostaCreatedAt != T002S2_A327PropostaCreatedAt[0] )
               {
                  GXUtil.WriteLog("propostanota:[seudo value changed for attri]"+"PropostaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z327PropostaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A327PropostaCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z853PropostaProtocolo, T002S2_A853PropostaProtocolo[0]) != 0 )
               {
                  GXUtil.WriteLog("propostanota:[seudo value changed for attri]"+"PropostaProtocolo");
                  GXUtil.WriteLogRaw("Old: ",Z853PropostaProtocolo);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A853PropostaProtocolo[0]);
               }
               if ( StringUtil.StrCmp(Z849PropostaTipoProposta, T002S2_A849PropostaTipoProposta[0]) != 0 )
               {
                  GXUtil.WriteLog("propostanota:[seudo value changed for attri]"+"PropostaTipoProposta");
                  GXUtil.WriteLogRaw("Old: ",Z849PropostaTipoProposta);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A849PropostaTipoProposta[0]);
               }
               if ( StringUtil.StrCmp(Z329PropostaStatus, T002S2_A329PropostaStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("propostanota:[seudo value changed for attri]"+"PropostaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z329PropostaStatus);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A329PropostaStatus[0]);
               }
               if ( Z850PropostaEmpresaClienteId != T002S2_A850PropostaEmpresaClienteId[0] )
               {
                  GXUtil.WriteLog("propostanota:[seudo value changed for attri]"+"PropostaEmpresaClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z850PropostaEmpresaClienteId);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A850PropostaEmpresaClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2S49( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2S49( 0) ;
            CheckOptimisticConcurrency2S49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2S49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002S15 */
                     pr_default.execute(10, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n329PropostaStatus, A329PropostaStatus, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002S16 */
                     pr_default.execute(11);
                     A323PropostaId = T002S16_A323PropostaId[0];
                     n323PropostaId = T002S16_n323PropostaId[0];
                     AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2S0( ) ;
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
               Load2S49( ) ;
            }
            EndLevel2S49( ) ;
         }
         CloseExtendedTableCursors2S49( ) ;
      }

      protected void Update2S49( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2S49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002S17 */
                     pr_default.execute(12, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n329PropostaStatus, A329PropostaStatus, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2S49( ) ;
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
            EndLevel2S49( ) ;
         }
         CloseExtendedTableCursors2S49( ) ;
      }

      protected void DeferredUpdate2S49( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2S49( ) ;
            AfterConfirm2S49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2S49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002S18 */
                  pr_default.execute(13, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Proposta");
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
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2S49( ) ;
         Gx_mode = sMode49;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2S49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002S20 */
            pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A854PropostaQtdItensNota_F = T002S20_A854PropostaQtdItensNota_F[0];
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
               A887PropostaSumItensnota_F = T002S20_A887PropostaSumItensnota_F[0];
               AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
            }
            else
            {
               A854PropostaQtdItensNota_F = 0;
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
               A887PropostaSumItensnota_F = 0;
               AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
            }
            pr_default.close(14);
            /* Using cursor T002S21 */
            pr_default.execute(15, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
            A888PropostaEmpresaRazao = T002S21_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = T002S21_n888PropostaEmpresaRazao[0];
            AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002S22 */
            pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T002S23 */
            pr_default.execute(17, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T002S24 */
            pr_default.execute(18, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T002S25 */
            pr_default.execute(19, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002S26 */
            pr_default.execute(20, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T002S27 */
            pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T002S28 */
            pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel2S49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2S0( ) ;
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

      public void ScanStart2S49( )
      {
         /* Scan By routine */
         /* Using cursor T002S29 */
         pr_default.execute(23);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = T002S29_A323PropostaId[0];
            n323PropostaId = T002S29_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2S49( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = T002S29_A323PropostaId[0];
            n323PropostaId = T002S29_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
      }

      protected void ScanEnd2S49( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm2S49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2S49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2S49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2S49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2S49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2S49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2S49( )
      {
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         edtPropostaQtdItensNota_F_Enabled = 0;
         AssignProp("", false, edtPropostaQtdItensNota_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaQtdItensNota_F_Enabled), 5, 0), true);
         edtPropostaProtocolo_Enabled = 0;
         AssignProp("", false, edtPropostaProtocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaProtocolo_Enabled), 5, 0), true);
         cmbPropostaTipoProposta.Enabled = 0;
         AssignProp("", false, cmbPropostaTipoProposta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPropostaTipoProposta.Enabled), 5, 0), true);
         edtPropostaSumItensnota_F_Enabled = 0;
         AssignProp("", false, edtPropostaSumItensnota_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaSumItensnota_F_Enabled), 5, 0), true);
         edtPropostaEmpresaClienteId_Enabled = 0;
         AssignProp("", false, edtPropostaEmpresaClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaEmpresaClienteId_Enabled), 5, 0), true);
         edtPropostaEmpresaRazao_Enabled = 0;
         AssignProp("", false, edtPropostaEmpresaRazao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaEmpresaRazao_Enabled), 5, 0), true);
         edtPropostaCreatedAt_Enabled = 0;
         AssignProp("", false, edtPropostaCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaCreatedAt_Enabled), 5, 0), true);
         cmbPropostaStatus.Enabled = 0;
         AssignProp("", false, cmbPropostaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPropostaStatus.Enabled), 5, 0), true);
         edtavCombopropostaempresaclienteid_Enabled = 0;
         AssignProp("", false, edtavCombopropostaempresaclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostaempresaclienteid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2S49( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2S0( )
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
         GXEncryptionTmp = "propostanota"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("propostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"PropostaNota");
         forbiddenHiddens.Add("PropostaId", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaEmpresaClienteId", context.localUtil.Format( (decimal)(AV11Insert_PropostaEmpresaClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("propostanota:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z327PropostaCreatedAt", context.localUtil.TToC( Z327PropostaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z853PropostaProtocolo", Z853PropostaProtocolo);
         GxWebStd.gx_hidden_field( context, "Z849PropostaTipoProposta", Z849PropostaTipoProposta);
         GxWebStd.gx_hidden_field( context, "Z329PropostaStatus", Z329PropostaStatus);
         GxWebStd.gx_hidden_field( context, "Z850PropostaEmpresaClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z850PropostaEmpresaClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N850PropostaEmpresaClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPOSTAEMPRESACLIENTEID_DATA", AV13PropostaEmpresaClienteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPOSTAEMPRESACLIENTEID_DATA", AV13PropostaEmpresaClienteId_Data);
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTAEMPRESACLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PropostaEmpresaClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Objectcall", StringUtil.RTrim( Combo_propostaempresaclienteid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Cls", StringUtil.RTrim( Combo_propostaempresaclienteid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Selectedvalue_set", StringUtil.RTrim( Combo_propostaempresaclienteid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Selectedtext_set", StringUtil.RTrim( Combo_propostaempresaclienteid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Enabled", StringUtil.BoolToStr( Combo_propostaempresaclienteid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Datalistproc", StringUtil.RTrim( Combo_propostaempresaclienteid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAEMPRESACLIENTEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_propostaempresaclienteid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "propostanota"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         return formatLink("propostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "PropostaNota" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta Nota" ;
      }

      protected void InitializeNonKey2S49( )
      {
         A850PropostaEmpresaClienteId = 0;
         n850PropostaEmpresaClienteId = false;
         AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
         n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         n327PropostaCreatedAt = false;
         AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
         A854PropostaQtdItensNota_F = 0;
         AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
         A853PropostaProtocolo = "";
         n853PropostaProtocolo = false;
         AssignAttri("", false, "A853PropostaProtocolo", A853PropostaProtocolo);
         n853PropostaProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? true : false);
         A849PropostaTipoProposta = "";
         n849PropostaTipoProposta = false;
         AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
         n849PropostaTipoProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ? true : false);
         A887PropostaSumItensnota_F = 0;
         AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrimStr( A887PropostaSumItensnota_F, 18, 2));
         A888PropostaEmpresaRazao = "";
         n888PropostaEmpresaRazao = false;
         AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
         A329PropostaStatus = "";
         n329PropostaStatus = false;
         AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
         n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         Z329PropostaStatus = "";
         Z850PropostaEmpresaClienteId = 0;
      }

      protected void InitAll2S49( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         InitializeNonKey2S49( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A327PropostaCreatedAt = i327PropostaCreatedAt;
         n327PropostaCreatedAt = false;
         AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019213950", true, true);
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
         context.AddJavascriptSource("propostanota.js", "?202561019213951", false, true);
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
         edtPropostaId_Internalname = "PROPOSTAID";
         edtPropostaQtdItensNota_F_Internalname = "PROPOSTAQTDITENSNOTA_F";
         edtPropostaProtocolo_Internalname = "PROPOSTAPROTOCOLO";
         cmbPropostaTipoProposta_Internalname = "PROPOSTATIPOPROPOSTA";
         edtPropostaSumItensnota_F_Internalname = "PROPOSTASUMITENSNOTA_F";
         lblTextblockpropostaempresaclienteid_Internalname = "TEXTBLOCKPROPOSTAEMPRESACLIENTEID";
         Combo_propostaempresaclienteid_Internalname = "COMBO_PROPOSTAEMPRESACLIENTEID";
         edtPropostaEmpresaClienteId_Internalname = "PROPOSTAEMPRESACLIENTEID";
         divTablesplittedpropostaempresaclienteid_Internalname = "TABLESPLITTEDPROPOSTAEMPRESACLIENTEID";
         edtPropostaEmpresaRazao_Internalname = "PROPOSTAEMPRESARAZAO";
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopropostaempresaclienteid_Internalname = "vCOMBOPROPOSTAEMPRESACLIENTEID";
         divSectionattribute_propostaempresaclienteid_Internalname = "SECTIONATTRIBUTE_PROPOSTAEMPRESACLIENTEID";
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
         Form.Caption = "Proposta Nota";
         edtavCombopropostaempresaclienteid_Jsonclick = "";
         edtavCombopropostaempresaclienteid_Enabled = 0;
         edtavCombopropostaempresaclienteid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus.Enabled = 1;
         edtPropostaCreatedAt_Jsonclick = "";
         edtPropostaCreatedAt_Enabled = 1;
         edtPropostaEmpresaRazao_Jsonclick = "";
         edtPropostaEmpresaRazao_Enabled = 0;
         edtPropostaEmpresaClienteId_Jsonclick = "";
         edtPropostaEmpresaClienteId_Enabled = 1;
         edtPropostaEmpresaClienteId_Visible = 1;
         Combo_propostaempresaclienteid_Datalistprocparametersprefix = " \"ComboName\": \"PropostaEmpresaClienteId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PropostaId\": 0";
         Combo_propostaempresaclienteid_Datalistproc = "PropostaNotaLoadDVCombo";
         Combo_propostaempresaclienteid_Cls = "ExtendedCombo AttributeFL";
         Combo_propostaempresaclienteid_Caption = "";
         Combo_propostaempresaclienteid_Enabled = Convert.ToBoolean( -1);
         edtPropostaSumItensnota_F_Jsonclick = "";
         edtPropostaSumItensnota_F_Enabled = 0;
         cmbPropostaTipoProposta_Jsonclick = "";
         cmbPropostaTipoProposta.Enabled = 1;
         edtPropostaProtocolo_Jsonclick = "";
         edtPropostaProtocolo_Enabled = 1;
         edtPropostaQtdItensNota_F_Jsonclick = "";
         edtPropostaQtdItensNota_F_Enabled = 0;
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 0;
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
         cmbPropostaTipoProposta.Name = "PROPOSTATIPOPROPOSTA";
         cmbPropostaTipoProposta.WebTags = "";
         cmbPropostaTipoProposta.addItem("CLINICA", "Clinica", 0);
         cmbPropostaTipoProposta.addItem("COMPRA_TITULO", "Compra de título", 0);
         if ( cmbPropostaTipoProposta.ItemCount > 0 )
         {
            A849PropostaTipoProposta = cmbPropostaTipoProposta.getValidValue(A849PropostaTipoProposta);
            n849PropostaTipoProposta = false;
            AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
         }
         cmbPropostaStatus.Name = "PROPOSTASTATUS";
         cmbPropostaStatus.WebTags = "";
         cmbPropostaStatus.addItem("PENDENTE", "Pendente aprovação", 0);
         cmbPropostaStatus.addItem("EM_ANALISE", "Em análise", 0);
         cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaStatus.addItem("REVISAO", "Revisão", 0);
         cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbPropostaStatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
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

      public void Valid_Propostaid( )
      {
         n323PropostaId = false;
         /* Using cursor T002S20 */
         pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A854PropostaQtdItensNota_F = T002S20_A854PropostaQtdItensNota_F[0];
            A887PropostaSumItensnota_F = T002S20_A887PropostaSumItensnota_F[0];
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            A887PropostaSumItensnota_F = 0;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ".", "")));
         AssignAttri("", false, "A887PropostaSumItensnota_F", StringUtil.LTrim( StringUtil.NToC( A887PropostaSumItensnota_F, 18, 2, ".", "")));
      }

      public void Valid_Propostaempresaclienteid( )
      {
         n888PropostaEmpresaRazao = false;
         /* Using cursor T002S21 */
         pr_default.execute(15, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtPropostaEmpresaClienteId_Internalname;
            }
         }
         A888PropostaEmpresaRazao = T002S21_A888PropostaEmpresaRazao[0];
         n888PropostaEmpresaRazao = T002S21_n888PropostaEmpresaRazao[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A888PropostaEmpresaRazao", A888PropostaEmpresaRazao);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_PropostaEmpresaClienteId","fld":"vINSERT_PROPOSTAEMPRESACLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122S2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A854PropostaQtdItensNota_F","fld":"PROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"A887PropostaSumItensnota_F","fld":"PROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"}]""");
         setEventMetadata("VALID_PROPOSTAID",""","oparms":[{"av":"A854PropostaQtdItensNota_F","fld":"PROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"A887PropostaSumItensnota_F","fld":"PROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"}]}""");
         setEventMetadata("VALID_PROPOSTATIPOPROPOSTA","""{"handler":"Valid_Propostatipoproposta","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAEMPRESACLIENTEID","""{"handler":"Valid_Propostaempresaclienteid","iparms":[{"av":"A850PropostaEmpresaClienteId","fld":"PROPOSTAEMPRESACLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n850PropostaEmpresaClienteId","type":"int"},{"av":"A888PropostaEmpresaRazao","fld":"PROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_PROPOSTAEMPRESACLIENTEID",""","oparms":[{"av":"A888PropostaEmpresaRazao","fld":"PROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_PROPOSTASTATUS","""{"handler":"Valid_Propostastatus","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROPOSTAEMPRESACLIENTEID","""{"handler":"Validv_Combopropostaempresaclienteid","iparms":[]}""");
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
         pr_default.close(15);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         Z329PropostaStatus = "";
         Combo_propostaempresaclienteid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A849PropostaTipoProposta = "";
         A329PropostaStatus = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A853PropostaProtocolo = "";
         lblTextblockpropostaempresaclienteid_Jsonclick = "";
         ucCombo_propostaempresaclienteid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13PropostaEmpresaClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A888PropostaEmpresaRazao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20Pgmname = "";
         Combo_propostaempresaclienteid_Objectcall = "";
         Combo_propostaempresaclienteid_Class = "";
         Combo_propostaempresaclienteid_Icontype = "";
         Combo_propostaempresaclienteid_Icon = "";
         Combo_propostaempresaclienteid_Tooltip = "";
         Combo_propostaempresaclienteid_Selectedvalue_set = "";
         Combo_propostaempresaclienteid_Selectedtext_set = "";
         Combo_propostaempresaclienteid_Selectedtext_get = "";
         Combo_propostaempresaclienteid_Gamoauthtoken = "";
         Combo_propostaempresaclienteid_Ddointernalname = "";
         Combo_propostaempresaclienteid_Titlecontrolalign = "";
         Combo_propostaempresaclienteid_Dropdownoptionstype = "";
         Combo_propostaempresaclienteid_Titlecontrolidtoreplace = "";
         Combo_propostaempresaclienteid_Datalisttype = "";
         Combo_propostaempresaclienteid_Datalistfixedvalues = "";
         Combo_propostaempresaclienteid_Remoteservicesparameters = "";
         Combo_propostaempresaclienteid_Htmltemplate = "";
         Combo_propostaempresaclienteid_Multiplevaluestype = "";
         Combo_propostaempresaclienteid_Loadingdata = "";
         Combo_propostaempresaclienteid_Noresultsfound = "";
         Combo_propostaempresaclienteid_Emptyitemtext = "";
         Combo_propostaempresaclienteid_Onlyselectedvalues = "";
         Combo_propostaempresaclienteid_Selectalltext = "";
         Combo_propostaempresaclienteid_Multiplevaluesseparator = "";
         Combo_propostaempresaclienteid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode49 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         Z888PropostaEmpresaRazao = "";
         T002S6_A854PropostaQtdItensNota_F = new short[1] ;
         T002S6_A887PropostaSumItensnota_F = new decimal[1] ;
         T002S4_A888PropostaEmpresaRazao = new string[] {""} ;
         T002S4_n888PropostaEmpresaRazao = new bool[] {false} ;
         T002S8_A323PropostaId = new int[1] ;
         T002S8_n323PropostaId = new bool[] {false} ;
         T002S8_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002S8_n327PropostaCreatedAt = new bool[] {false} ;
         T002S8_A853PropostaProtocolo = new string[] {""} ;
         T002S8_n853PropostaProtocolo = new bool[] {false} ;
         T002S8_A849PropostaTipoProposta = new string[] {""} ;
         T002S8_n849PropostaTipoProposta = new bool[] {false} ;
         T002S8_A888PropostaEmpresaRazao = new string[] {""} ;
         T002S8_n888PropostaEmpresaRazao = new bool[] {false} ;
         T002S8_A329PropostaStatus = new string[] {""} ;
         T002S8_n329PropostaStatus = new bool[] {false} ;
         T002S8_A850PropostaEmpresaClienteId = new int[1] ;
         T002S8_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T002S8_A854PropostaQtdItensNota_F = new short[1] ;
         T002S8_A887PropostaSumItensnota_F = new decimal[1] ;
         T002S10_A854PropostaQtdItensNota_F = new short[1] ;
         T002S10_A887PropostaSumItensnota_F = new decimal[1] ;
         T002S11_A888PropostaEmpresaRazao = new string[] {""} ;
         T002S11_n888PropostaEmpresaRazao = new bool[] {false} ;
         T002S12_A323PropostaId = new int[1] ;
         T002S12_n323PropostaId = new bool[] {false} ;
         T002S3_A323PropostaId = new int[1] ;
         T002S3_n323PropostaId = new bool[] {false} ;
         T002S3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002S3_n327PropostaCreatedAt = new bool[] {false} ;
         T002S3_A853PropostaProtocolo = new string[] {""} ;
         T002S3_n853PropostaProtocolo = new bool[] {false} ;
         T002S3_A849PropostaTipoProposta = new string[] {""} ;
         T002S3_n849PropostaTipoProposta = new bool[] {false} ;
         T002S3_A329PropostaStatus = new string[] {""} ;
         T002S3_n329PropostaStatus = new bool[] {false} ;
         T002S3_A850PropostaEmpresaClienteId = new int[1] ;
         T002S3_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T002S13_A323PropostaId = new int[1] ;
         T002S13_n323PropostaId = new bool[] {false} ;
         T002S14_A323PropostaId = new int[1] ;
         T002S14_n323PropostaId = new bool[] {false} ;
         T002S2_A323PropostaId = new int[1] ;
         T002S2_n323PropostaId = new bool[] {false} ;
         T002S2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002S2_n327PropostaCreatedAt = new bool[] {false} ;
         T002S2_A853PropostaProtocolo = new string[] {""} ;
         T002S2_n853PropostaProtocolo = new bool[] {false} ;
         T002S2_A849PropostaTipoProposta = new string[] {""} ;
         T002S2_n849PropostaTipoProposta = new bool[] {false} ;
         T002S2_A329PropostaStatus = new string[] {""} ;
         T002S2_n329PropostaStatus = new bool[] {false} ;
         T002S2_A850PropostaEmpresaClienteId = new int[1] ;
         T002S2_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T002S16_A323PropostaId = new int[1] ;
         T002S16_n323PropostaId = new bool[] {false} ;
         T002S20_A854PropostaQtdItensNota_F = new short[1] ;
         T002S20_A887PropostaSumItensnota_F = new decimal[1] ;
         T002S21_A888PropostaEmpresaRazao = new string[] {""} ;
         T002S21_n888PropostaEmpresaRazao = new bool[] {false} ;
         T002S22_A227ContratoId = new int[1] ;
         T002S22_n227ContratoId = new bool[] {false} ;
         T002S23_A518ReembolsoId = new int[1] ;
         T002S24_A261TituloId = new int[1] ;
         T002S25_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002S26_A572PropostaContratoAssinaturaId = new int[1] ;
         T002S27_A414PropostaDocumentosId = new int[1] ;
         T002S28_A336AprovacaoId = new int[1] ;
         T002S29_A323PropostaId = new int[1] ;
         T002S29_n323PropostaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostanota__default(),
            new Object[][] {
                new Object[] {
               T002S2_A323PropostaId, T002S2_A327PropostaCreatedAt, T002S2_n327PropostaCreatedAt, T002S2_A853PropostaProtocolo, T002S2_n853PropostaProtocolo, T002S2_A849PropostaTipoProposta, T002S2_n849PropostaTipoProposta, T002S2_A329PropostaStatus, T002S2_n329PropostaStatus, T002S2_A850PropostaEmpresaClienteId,
               T002S2_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               T002S3_A323PropostaId, T002S3_A327PropostaCreatedAt, T002S3_n327PropostaCreatedAt, T002S3_A853PropostaProtocolo, T002S3_n853PropostaProtocolo, T002S3_A849PropostaTipoProposta, T002S3_n849PropostaTipoProposta, T002S3_A329PropostaStatus, T002S3_n329PropostaStatus, T002S3_A850PropostaEmpresaClienteId,
               T002S3_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               T002S4_A888PropostaEmpresaRazao, T002S4_n888PropostaEmpresaRazao
               }
               , new Object[] {
               T002S6_A854PropostaQtdItensNota_F, T002S6_A887PropostaSumItensnota_F
               }
               , new Object[] {
               T002S8_A323PropostaId, T002S8_A327PropostaCreatedAt, T002S8_n327PropostaCreatedAt, T002S8_A853PropostaProtocolo, T002S8_n853PropostaProtocolo, T002S8_A849PropostaTipoProposta, T002S8_n849PropostaTipoProposta, T002S8_A888PropostaEmpresaRazao, T002S8_n888PropostaEmpresaRazao, T002S8_A329PropostaStatus,
               T002S8_n329PropostaStatus, T002S8_A850PropostaEmpresaClienteId, T002S8_n850PropostaEmpresaClienteId, T002S8_A854PropostaQtdItensNota_F, T002S8_A887PropostaSumItensnota_F
               }
               , new Object[] {
               T002S10_A854PropostaQtdItensNota_F, T002S10_A887PropostaSumItensnota_F
               }
               , new Object[] {
               T002S11_A888PropostaEmpresaRazao, T002S11_n888PropostaEmpresaRazao
               }
               , new Object[] {
               T002S12_A323PropostaId
               }
               , new Object[] {
               T002S13_A323PropostaId
               }
               , new Object[] {
               T002S14_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               T002S16_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002S20_A854PropostaQtdItensNota_F, T002S20_A887PropostaSumItensnota_F
               }
               , new Object[] {
               T002S21_A888PropostaEmpresaRazao, T002S21_n888PropostaEmpresaRazao
               }
               , new Object[] {
               T002S22_A227ContratoId
               }
               , new Object[] {
               T002S23_A518ReembolsoId
               }
               , new Object[] {
               T002S24_A261TituloId
               }
               , new Object[] {
               T002S25_A830NotaFiscalItemId
               }
               , new Object[] {
               T002S26_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T002S27_A414PropostaDocumentosId
               }
               , new Object[] {
               T002S28_A336AprovacaoId
               }
               , new Object[] {
               T002S29_A323PropostaId
               }
            }
         );
         AV20Pgmname = "PropostaNota";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A854PropostaQtdItensNota_F ;
      private short RcdFound49 ;
      private short Z854PropostaQtdItensNota_F ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7PropostaId ;
      private int Z323PropostaId ;
      private int Z850PropostaEmpresaClienteId ;
      private int N850PropostaEmpresaClienteId ;
      private int A323PropostaId ;
      private int A850PropostaEmpresaClienteId ;
      private int AV7PropostaId ;
      private int trnEnded ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaQtdItensNota_F_Enabled ;
      private int edtPropostaProtocolo_Enabled ;
      private int edtPropostaSumItensnota_F_Enabled ;
      private int edtPropostaEmpresaClienteId_Visible ;
      private int edtPropostaEmpresaClienteId_Enabled ;
      private int edtPropostaEmpresaRazao_Enabled ;
      private int edtPropostaCreatedAt_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV18ComboPropostaEmpresaClienteId ;
      private int edtavCombopropostaempresaclienteid_Enabled ;
      private int edtavCombopropostaempresaclienteid_Visible ;
      private int AV11Insert_PropostaEmpresaClienteId ;
      private int Combo_propostaempresaclienteid_Datalistupdateminimumcharacters ;
      private int Combo_propostaempresaclienteid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV21GXV1 ;
      private int idxLst ;
      private decimal A887PropostaSumItensnota_F ;
      private decimal Z887PropostaSumItensnota_F ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_propostaempresaclienteid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPropostaProtocolo_Internalname ;
      private string cmbPropostaTipoProposta_Internalname ;
      private string cmbPropostaStatus_Internalname ;
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
      private string edtPropostaId_Internalname ;
      private string TempTags ;
      private string edtPropostaId_Jsonclick ;
      private string edtPropostaQtdItensNota_F_Internalname ;
      private string edtPropostaQtdItensNota_F_Jsonclick ;
      private string edtPropostaProtocolo_Jsonclick ;
      private string cmbPropostaTipoProposta_Jsonclick ;
      private string edtPropostaSumItensnota_F_Internalname ;
      private string edtPropostaSumItensnota_F_Jsonclick ;
      private string divTablesplittedpropostaempresaclienteid_Internalname ;
      private string lblTextblockpropostaempresaclienteid_Internalname ;
      private string lblTextblockpropostaempresaclienteid_Jsonclick ;
      private string Combo_propostaempresaclienteid_Caption ;
      private string Combo_propostaempresaclienteid_Cls ;
      private string Combo_propostaempresaclienteid_Datalistproc ;
      private string Combo_propostaempresaclienteid_Datalistprocparametersprefix ;
      private string Combo_propostaempresaclienteid_Internalname ;
      private string edtPropostaEmpresaClienteId_Internalname ;
      private string edtPropostaEmpresaClienteId_Jsonclick ;
      private string edtPropostaEmpresaRazao_Internalname ;
      private string edtPropostaEmpresaRazao_Jsonclick ;
      private string edtPropostaCreatedAt_Internalname ;
      private string edtPropostaCreatedAt_Jsonclick ;
      private string cmbPropostaStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_propostaempresaclienteid_Internalname ;
      private string edtavCombopropostaempresaclienteid_Internalname ;
      private string edtavCombopropostaempresaclienteid_Jsonclick ;
      private string AV20Pgmname ;
      private string Combo_propostaempresaclienteid_Objectcall ;
      private string Combo_propostaempresaclienteid_Class ;
      private string Combo_propostaempresaclienteid_Icontype ;
      private string Combo_propostaempresaclienteid_Icon ;
      private string Combo_propostaempresaclienteid_Tooltip ;
      private string Combo_propostaempresaclienteid_Selectedvalue_set ;
      private string Combo_propostaempresaclienteid_Selectedtext_set ;
      private string Combo_propostaempresaclienteid_Selectedtext_get ;
      private string Combo_propostaempresaclienteid_Gamoauthtoken ;
      private string Combo_propostaempresaclienteid_Ddointernalname ;
      private string Combo_propostaempresaclienteid_Titlecontrolalign ;
      private string Combo_propostaempresaclienteid_Dropdownoptionstype ;
      private string Combo_propostaempresaclienteid_Titlecontrolidtoreplace ;
      private string Combo_propostaempresaclienteid_Datalisttype ;
      private string Combo_propostaempresaclienteid_Datalistfixedvalues ;
      private string Combo_propostaempresaclienteid_Remoteservicesparameters ;
      private string Combo_propostaempresaclienteid_Htmltemplate ;
      private string Combo_propostaempresaclienteid_Multiplevaluestype ;
      private string Combo_propostaempresaclienteid_Loadingdata ;
      private string Combo_propostaempresaclienteid_Noresultsfound ;
      private string Combo_propostaempresaclienteid_Emptyitemtext ;
      private string Combo_propostaempresaclienteid_Onlyselectedvalues ;
      private string Combo_propostaempresaclienteid_Selectalltext ;
      private string Combo_propostaempresaclienteid_Multiplevaluesseparator ;
      private string Combo_propostaempresaclienteid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode49 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z327PropostaCreatedAt ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime i327PropostaCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n850PropostaEmpresaClienteId ;
      private bool wbErr ;
      private bool n849PropostaTipoProposta ;
      private bool n329PropostaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n327PropostaCreatedAt ;
      private bool n853PropostaProtocolo ;
      private bool Combo_propostaempresaclienteid_Enabled ;
      private bool Combo_propostaempresaclienteid_Visible ;
      private bool Combo_propostaempresaclienteid_Allowmultipleselection ;
      private bool Combo_propostaempresaclienteid_Isgriditem ;
      private bool Combo_propostaempresaclienteid_Hasdescription ;
      private bool Combo_propostaempresaclienteid_Includeonlyselectedoption ;
      private bool Combo_propostaempresaclienteid_Includeselectalloption ;
      private bool Combo_propostaempresaclienteid_Emptyitem ;
      private bool Combo_propostaempresaclienteid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n888PropostaEmpresaRazao ;
      private bool returnInSub ;
      private string AV17Combo_DataJson ;
      private string Z853PropostaProtocolo ;
      private string Z849PropostaTipoProposta ;
      private string Z329PropostaStatus ;
      private string A849PropostaTipoProposta ;
      private string A329PropostaStatus ;
      private string A853PropostaProtocolo ;
      private string A888PropostaEmpresaRazao ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z888PropostaEmpresaRazao ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_propostaempresaclienteid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPropostaTipoProposta ;
      private GXCombobox cmbPropostaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13PropostaEmpresaClienteId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T002S6_A854PropostaQtdItensNota_F ;
      private decimal[] T002S6_A887PropostaSumItensnota_F ;
      private string[] T002S4_A888PropostaEmpresaRazao ;
      private bool[] T002S4_n888PropostaEmpresaRazao ;
      private int[] T002S8_A323PropostaId ;
      private bool[] T002S8_n323PropostaId ;
      private DateTime[] T002S8_A327PropostaCreatedAt ;
      private bool[] T002S8_n327PropostaCreatedAt ;
      private string[] T002S8_A853PropostaProtocolo ;
      private bool[] T002S8_n853PropostaProtocolo ;
      private string[] T002S8_A849PropostaTipoProposta ;
      private bool[] T002S8_n849PropostaTipoProposta ;
      private string[] T002S8_A888PropostaEmpresaRazao ;
      private bool[] T002S8_n888PropostaEmpresaRazao ;
      private string[] T002S8_A329PropostaStatus ;
      private bool[] T002S8_n329PropostaStatus ;
      private int[] T002S8_A850PropostaEmpresaClienteId ;
      private bool[] T002S8_n850PropostaEmpresaClienteId ;
      private short[] T002S8_A854PropostaQtdItensNota_F ;
      private decimal[] T002S8_A887PropostaSumItensnota_F ;
      private short[] T002S10_A854PropostaQtdItensNota_F ;
      private decimal[] T002S10_A887PropostaSumItensnota_F ;
      private string[] T002S11_A888PropostaEmpresaRazao ;
      private bool[] T002S11_n888PropostaEmpresaRazao ;
      private int[] T002S12_A323PropostaId ;
      private bool[] T002S12_n323PropostaId ;
      private int[] T002S3_A323PropostaId ;
      private bool[] T002S3_n323PropostaId ;
      private DateTime[] T002S3_A327PropostaCreatedAt ;
      private bool[] T002S3_n327PropostaCreatedAt ;
      private string[] T002S3_A853PropostaProtocolo ;
      private bool[] T002S3_n853PropostaProtocolo ;
      private string[] T002S3_A849PropostaTipoProposta ;
      private bool[] T002S3_n849PropostaTipoProposta ;
      private string[] T002S3_A329PropostaStatus ;
      private bool[] T002S3_n329PropostaStatus ;
      private int[] T002S3_A850PropostaEmpresaClienteId ;
      private bool[] T002S3_n850PropostaEmpresaClienteId ;
      private int[] T002S13_A323PropostaId ;
      private bool[] T002S13_n323PropostaId ;
      private int[] T002S14_A323PropostaId ;
      private bool[] T002S14_n323PropostaId ;
      private int[] T002S2_A323PropostaId ;
      private bool[] T002S2_n323PropostaId ;
      private DateTime[] T002S2_A327PropostaCreatedAt ;
      private bool[] T002S2_n327PropostaCreatedAt ;
      private string[] T002S2_A853PropostaProtocolo ;
      private bool[] T002S2_n853PropostaProtocolo ;
      private string[] T002S2_A849PropostaTipoProposta ;
      private bool[] T002S2_n849PropostaTipoProposta ;
      private string[] T002S2_A329PropostaStatus ;
      private bool[] T002S2_n329PropostaStatus ;
      private int[] T002S2_A850PropostaEmpresaClienteId ;
      private bool[] T002S2_n850PropostaEmpresaClienteId ;
      private int[] T002S16_A323PropostaId ;
      private bool[] T002S16_n323PropostaId ;
      private short[] T002S20_A854PropostaQtdItensNota_F ;
      private decimal[] T002S20_A887PropostaSumItensnota_F ;
      private string[] T002S21_A888PropostaEmpresaRazao ;
      private bool[] T002S21_n888PropostaEmpresaRazao ;
      private int[] T002S22_A227ContratoId ;
      private bool[] T002S22_n227ContratoId ;
      private int[] T002S23_A518ReembolsoId ;
      private int[] T002S24_A261TituloId ;
      private Guid[] T002S25_A830NotaFiscalItemId ;
      private int[] T002S26_A572PropostaContratoAssinaturaId ;
      private int[] T002S27_A414PropostaDocumentosId ;
      private int[] T002S28_A336AprovacaoId ;
      private int[] T002S29_A323PropostaId ;
      private bool[] T002S29_n323PropostaId ;
   }

   public class propostanota__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002S2;
          prmT002S2 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S3;
          prmT002S3 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S4;
          prmT002S4 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S6;
          prmT002S6 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S8;
          prmT002S8 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S10;
          prmT002S10 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S11;
          prmT002S11 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S12;
          prmT002S12 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S13;
          prmT002S13 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S14;
          prmT002S14 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S15;
          prmT002S15 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S16;
          prmT002S16 = new Object[] {
          };
          Object[] prmT002S17;
          prmT002S17 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S18;
          prmT002S18 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S20;
          prmT002S20 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S21;
          prmT002S21 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S22;
          prmT002S22 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S23;
          prmT002S23 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S24;
          prmT002S24 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S25;
          prmT002S25 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S26;
          prmT002S26 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S27;
          prmT002S27 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S28;
          prmT002S28 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002S29;
          prmT002S29 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002S2", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaStatus, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002S2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S3", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaStatus, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S4", "SELECT ClienteRazaoSocial AS PropostaEmpresaRazao FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S6", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T1.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S8", "SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaProtocolo, TM1.PropostaTipoProposta, T3.ClienteRazaoSocial AS PropostaEmpresaRazao, TM1.PropostaStatus, TM1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, COALESCE( T2.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T2.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM ((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem WHERE TM1.PropostaId = PropostaId GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.PropostaEmpresaClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S10", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T1.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S11", "SELECT ClienteRazaoSocial AS PropostaEmpresaRazao FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S12", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S13", "SELECT PropostaId FROM Proposta WHERE ( PropostaId > :PropostaId) ORDER BY PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S14", "SELECT PropostaId FROM Proposta WHERE ( PropostaId < :PropostaId) ORDER BY PropostaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S15", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaStatus, PropostaEmpresaClienteId, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaCratedBy, ContratoId, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ProcedimentosMedicosId, ConvenioVencimentoAno, ConvenioVencimentoMes, ConvenioCategoriaId, PropostaPacienteClienteId, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaDataCirurgia, PropostaResponsavelId, PropostaClinicaId, PropostaComentarioAnalise, PropostaValorLiquido) VALUES(:PropostaCreatedAt, :PropostaProtocolo, :PropostaTipoProposta, :PropostaStatus, :PropostaEmpresaClienteId, '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DATE '00010101', 0, 0, '', 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002S15)
             ,new CursorDef("T002S16", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S17", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaProtocolo=:PropostaProtocolo, PropostaTipoProposta=:PropostaTipoProposta, PropostaStatus=:PropostaStatus, PropostaEmpresaClienteId=:PropostaEmpresaClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002S17)
             ,new CursorDef("T002S18", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002S18)
             ,new CursorDef("T002S20", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T1.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S21", "SELECT ClienteRazaoSocial AS PropostaEmpresaRazao FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002S22", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S23", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S24", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S25", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S26", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S27", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S28", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002S29", "SELECT PropostaId FROM Proposta ORDER BY PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S29,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
       }
    }

 }

}
