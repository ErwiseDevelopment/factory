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
   public class boleto : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A1069CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( GetPar( "CarteiraDeCobrancaId"), "."), 18, MidpointRounding.ToEven));
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A1069CarteiraDeCobrancaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A261TituloId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "boleto")), "boleto") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "boleto")))) ;
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
                  AV7BoletosId = (int)(Math.Round(NumberUtil.Val( GetPar( "BoletosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7BoletosId", StringUtil.LTrimStr( (decimal)(AV7BoletosId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vBOLETOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BoletosId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Boleto", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public boleto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boleto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_BoletosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7BoletosId = aP1_BoletosId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbBoletosStatus = new GXCombobox();
         cmbBoletosSacadoTipoDocumento = new GXCombobox();
         cmbCarteiraDeCobrancaStatus = new GXCombobox();
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
         if ( cmbBoletosStatus.ItemCount > 0 )
         {
            A1083BoletosStatus = cmbBoletosStatus.getValidValue(A1083BoletosStatus);
            n1083BoletosStatus = false;
            AssignAttri("", false, "A1083BoletosStatus", A1083BoletosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosStatus.CurrentValue = StringUtil.RTrim( A1083BoletosStatus);
            AssignProp("", false, cmbBoletosStatus_Internalname, "Values", cmbBoletosStatus.ToJavascriptSource(), true);
         }
         if ( cmbBoletosSacadoTipoDocumento.ItemCount > 0 )
         {
            A1096BoletosSacadoTipoDocumento = cmbBoletosSacadoTipoDocumento.getValidValue(A1096BoletosSacadoTipoDocumento);
            n1096BoletosSacadoTipoDocumento = false;
            AssignAttri("", false, "A1096BoletosSacadoTipoDocumento", A1096BoletosSacadoTipoDocumento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosSacadoTipoDocumento.CurrentValue = StringUtil.RTrim( A1096BoletosSacadoTipoDocumento);
            AssignProp("", false, cmbBoletosSacadoTipoDocumento_Internalname, "Values", cmbBoletosSacadoTipoDocumento.ToJavascriptSource(), true);
         }
         if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
         {
            A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.getValidValue(StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
            n1074CarteiraDeCobrancaStatus = false;
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
            AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Values", cmbCarteiraDeCobrancaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtBoletosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcarteiradecobrancaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcarteiradecobrancaid_Internalname, "Carteira De Cobranca", "", "", lblTextblockcarteiradecobrancaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_carteiradecobrancaid.SetProperty("Caption", Combo_carteiradecobrancaid_Caption);
         ucCombo_carteiradecobrancaid.SetProperty("Cls", Combo_carteiradecobrancaid_Cls);
         ucCombo_carteiradecobrancaid.SetProperty("DataListProc", Combo_carteiradecobrancaid_Datalistproc);
         ucCombo_carteiradecobrancaid.SetProperty("DataListProcParametersPrefix", Combo_carteiradecobrancaid_Datalistprocparametersprefix);
         ucCombo_carteiradecobrancaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_carteiradecobrancaid.SetProperty("DropDownOptionsData", AV14CarteiraDeCobrancaId_Data);
         ucCombo_carteiradecobrancaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_carteiradecobrancaid_Internalname, "COMBO_CARTEIRADECOBRANCAIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaId_Internalname, "Carteira De Cobranca Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaId_Internalname, ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ",", ""))), ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaId_Jsonclick, 0, "Attribute", "", "", "", "", edtCarteiraDeCobrancaId_Visible, edtCarteiraDeCobrancaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtituloid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktituloid_Internalname, "Titulo", "", "", lblTextblocktituloid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tituloid.SetProperty("Caption", Combo_tituloid_Caption);
         ucCombo_tituloid.SetProperty("Cls", Combo_tituloid_Cls);
         ucCombo_tituloid.SetProperty("DataListProc", Combo_tituloid_Datalistproc);
         ucCombo_tituloid.SetProperty("DataListProcParametersPrefix", Combo_tituloid_Datalistprocparametersprefix);
         ucCombo_tituloid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_tituloid.SetProperty("DropDownOptionsData", AV20TituloId_Data);
         ucCombo_tituloid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tituloid_Internalname, "COMBO_TITULOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloId_Internalname, "Titulo Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloId_Internalname, ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", ""))), ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloId_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloId_Visible, edtTituloId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosNossoNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosNossoNumero_Internalname, "Nosso Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosNossoNumero_Internalname, A1078BoletosNossoNumero, StringUtil.RTrim( context.localUtil.Format( A1078BoletosNossoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosNossoNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosNossoNumero_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosSeuNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosSeuNumero_Internalname, "Seu Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosSeuNumero_Internalname, A1079BoletosSeuNumero, StringUtil.RTrim( context.localUtil.Format( A1079BoletosSeuNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosSeuNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosSeuNumero_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosNumero_Internalname, A1080BoletosNumero, StringUtil.RTrim( context.localUtil.Format( A1080BoletosNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosNumero_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLinhaDigitavel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLinhaDigitavel_Internalname, "Linha Digitável", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosLinhaDigitavel_Internalname, A1081BoletosLinhaDigitavel, StringUtil.RTrim( context.localUtil.Format( A1081BoletosLinhaDigitavel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosLinhaDigitavel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosLinhaDigitavel_Enabled, 0, "text", "", 54, "chr", 1, "row", 54, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosCodigoDeBarras_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosCodigoDeBarras_Internalname, "De Barras", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosCodigoDeBarras_Internalname, A1082BoletosCodigoDeBarras, StringUtil.RTrim( context.localUtil.Format( A1082BoletosCodigoDeBarras, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosCodigoDeBarras_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosCodigoDeBarras_Enabled, 0, "text", "", 44, "chr", 1, "row", 44, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbBoletosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbBoletosStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbBoletosStatus, cmbBoletosStatus_Internalname, StringUtil.RTrim( A1083BoletosStatus), 1, cmbBoletosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbBoletosStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_Boleto.htm");
         cmbBoletosStatus.CurrentValue = StringUtil.RTrim( A1083BoletosStatus);
         AssignProp("", false, cmbBoletosStatus_Internalname, "Values", (string)(cmbBoletosStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosDataEmissao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosDataEmissao_Internalname, "Emissão", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosDataEmissao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosDataEmissao_Internalname, context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"), context.localUtil.Format( A1084BoletosDataEmissao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosDataEmissao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosDataEmissao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosDataEmissao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosDataEmissao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosDataVencimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosDataVencimento_Internalname, "Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosDataVencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosDataVencimento_Internalname, context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"), context.localUtil.Format( A1085BoletosDataVencimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosDataVencimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosDataVencimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosDataVencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosDataVencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosDataRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosDataRegistro_Internalname, "Data de Registro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosDataRegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosDataRegistro_Internalname, context.localUtil.TToC( A1086BoletosDataRegistro, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1086BoletosDataRegistro, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosDataRegistro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosDataRegistro_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosDataRegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosDataRegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosDataPagamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosDataPagamento_Internalname, "Data do Pagamento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosDataPagamento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosDataPagamento_Internalname, context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"), context.localUtil.Format( A1087BoletosDataPagamento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosDataPagamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosDataPagamento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosDataPagamento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosDataPagamento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosDataBaixa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosDataBaixa_Internalname, "Data da Baixa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosDataBaixa_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosDataBaixa_Internalname, context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"), context.localUtil.Format( A1088BoletosDataBaixa, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosDataBaixa_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosDataBaixa_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosDataBaixa_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosDataBaixa_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosValorNominal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosValorNominal_Internalname, "Valor Nominal", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosValorNominal_Internalname, ((Convert.ToDecimal(0)==A1089BoletosValorNominal)&&IsIns( )||n1089BoletosValorNominal ? "" : StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1089BoletosValorNominal)&&IsIns( )||n1089BoletosValorNominal ? "" : StringUtil.LTrim( ((edtBoletosValorNominal_Enabled!=0) ? context.localUtil.Format( A1089BoletosValorNominal, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1089BoletosValorNominal, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosValorNominal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosValorNominal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosValorPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosValorPago_Internalname, "Valor Pago", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosValorPago_Internalname, ((Convert.ToDecimal(0)==A1090BoletosValorPago)&&IsIns( )||n1090BoletosValorPago ? "" : StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1090BoletosValorPago)&&IsIns( )||n1090BoletosValorPago ? "" : StringUtil.LTrim( ((edtBoletosValorPago_Enabled!=0) ? context.localUtil.Format( A1090BoletosValorPago, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1090BoletosValorPago, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosValorPago_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosValorPago_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosValorDesconto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosValorDesconto_Internalname, "Desconto", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosValorDesconto_Internalname, ((Convert.ToDecimal(0)==A1091BoletosValorDesconto)&&IsIns( )||n1091BoletosValorDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1091BoletosValorDesconto)&&IsIns( )||n1091BoletosValorDesconto ? "" : StringUtil.LTrim( ((edtBoletosValorDesconto_Enabled!=0) ? context.localUtil.Format( A1091BoletosValorDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1091BoletosValorDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosValorDesconto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosValorDesconto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosValorJuros_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosValorJuros_Internalname, "Juros", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosValorJuros_Internalname, ((Convert.ToDecimal(0)==A1092BoletosValorJuros)&&IsIns( )||n1092BoletosValorJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1092BoletosValorJuros)&&IsIns( )||n1092BoletosValorJuros ? "" : StringUtil.LTrim( ((edtBoletosValorJuros_Enabled!=0) ? context.localUtil.Format( A1092BoletosValorJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1092BoletosValorJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosValorJuros_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosValorJuros_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosValorMulta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosValorMulta_Internalname, "Multa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosValorMulta_Internalname, ((Convert.ToDecimal(0)==A1093BoletosValorMulta)&&IsIns( )||n1093BoletosValorMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1093BoletosValorMulta)&&IsIns( )||n1093BoletosValorMulta ? "" : StringUtil.LTrim( ((edtBoletosValorMulta_Enabled!=0) ? context.localUtil.Format( A1093BoletosValorMulta, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1093BoletosValorMulta, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosValorMulta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosValorMulta_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosSacadoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosSacadoNome_Internalname, "Nome do Sacado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosSacadoNome_Internalname, A1094BoletosSacadoNome, StringUtil.RTrim( context.localUtil.Format( A1094BoletosSacadoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosSacadoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosSacadoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosSacadoDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosSacadoDocumento_Internalname, "Documento do Sacado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosSacadoDocumento_Internalname, A1095BoletosSacadoDocumento, StringUtil.RTrim( context.localUtil.Format( A1095BoletosSacadoDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosSacadoDocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosSacadoDocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbBoletosSacadoTipoDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbBoletosSacadoTipoDocumento_Internalname, "Tipo Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbBoletosSacadoTipoDocumento, cmbBoletosSacadoTipoDocumento_Internalname, StringUtil.RTrim( A1096BoletosSacadoTipoDocumento), 1, cmbBoletosSacadoTipoDocumento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbBoletosSacadoTipoDocumento.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "", true, 0, "HLP_Boleto.htm");
         cmbBoletosSacadoTipoDocumento.CurrentValue = StringUtil.RTrim( A1096BoletosSacadoTipoDocumento);
         AssignProp("", false, cmbBoletosSacadoTipoDocumento_Internalname, "Values", (string)(cmbBoletosSacadoTipoDocumento.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosMensagemDeErro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosMensagemDeErro_Internalname, "Erro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtBoletosMensagemDeErro_Internalname, A1097BoletosMensagemDeErro, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", 0, 1, edtBoletosMensagemDeErro_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosTentativasDeRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosTentativasDeRegistro_Internalname, "Tentativas de Registro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosTentativasDeRegistro_Internalname, ((0==A1098BoletosTentativasDeRegistro)&&IsIns( )||n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098BoletosTentativasDeRegistro), 8, 0, ",", ""))), ((0==A1098BoletosTentativasDeRegistro)&&IsIns( )||n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( ((edtBoletosTentativasDeRegistro_Enabled!=0) ? context.localUtil.Format( (decimal)(A1098BoletosTentativasDeRegistro), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A1098BoletosTentativasDeRegistro), "ZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosTentativasDeRegistro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosTentativasDeRegistro_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosCreatedAt_Internalname, "Created At", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosCreatedAt_Internalname, context.localUtil.TToC( A1099BoletosCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1099BoletosCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosUpdatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosUpdatedAt_Internalname, "Updated At", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosUpdatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosUpdatedAt_Internalname, context.localUtil.TToC( A1100BoletosUpdatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1100BoletosUpdatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosUpdatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBoletosUpdatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_bitmap( context, edtBoletosUpdatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosUpdatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaNome_Internalname, "Carteira De Cobranca Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaNome_Internalname, A1071CarteiraDeCobrancaNome, StringUtil.RTrim( context.localUtil.Format( A1071CarteiraDeCobrancaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaConvenio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaConvenio_Internalname, "Carteira De Cobranca Convenio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaConvenio_Internalname, A1073CarteiraDeCobrancaConvenio, StringUtil.RTrim( context.localUtil.Format( A1073CarteiraDeCobrancaConvenio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaConvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaConvenio_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCarteiraDeCobrancaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCarteiraDeCobrancaStatus_Internalname, "Carteira De Cobranca Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCarteiraDeCobrancaStatus, cmbCarteiraDeCobrancaStatus_Internalname, StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus), 1, cmbCarteiraDeCobrancaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbCarteiraDeCobrancaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "", true, 0, "HLP_Boleto.htm");
         cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Values", (string)(cmbCarteiraDeCobrancaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaValorTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaValorTotal_Internalname, "Valor Total", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaValorTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1111CarteiraDeCobrancaValorTotal, 18, 2, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaValorTotal_Enabled!=0) ? context.localUtil.Format( A1111CarteiraDeCobrancaValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1111CarteiraDeCobrancaValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaValorTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaValorTotal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaValorRecebido_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaValorRecebido_Internalname, "Valor Recebido", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaValorRecebido_Internalname, StringUtil.LTrim( StringUtil.NToC( A1112CarteiraDeCobrancaValorRecebido, 18, 2, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaValorRecebido_Enabled!=0) ? context.localUtil.Format( A1112CarteiraDeCobrancaValorRecebido, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1112CarteiraDeCobrancaValorRecebido, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaValorRecebido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaValorRecebido_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaTotalBoletos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaTotalBoletos_Internalname, "Total Boletos", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaTotalBoletos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaTotalBoletos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaTotalBoletos_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaTotalBoletos_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname, "Boletos Registrados", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaTotalBoletosRegistrados_Enabled!=0) ? context.localUtil.Format( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaTotalBoletosRegistrados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaTotalBoletosRegistrados_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname, "Boletos Expirados", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaTotalBoletosExpirados_Enabled!=0) ? context.localUtil.Format( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,199);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaTotalBoletosExpirados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaTotalBoletosExpirados_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname, "Boletos Cancelados", "col-sm-3 AttributeFLLabel", 1, true, "");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ",", "")), StringUtil.LTrim( ((edtCarteiraDeCobrancaTotalBoletosCancelados_Enabled!=0) ? context.localUtil.Format( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarteiraDeCobrancaTotalBoletosCancelados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCarteiraDeCobrancaTotalBoletosCancelados_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 213,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Boleto.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_carteiradecobrancaid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 218,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombocarteiradecobrancaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboCarteiraDeCobrancaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombocarteiradecobrancaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboCarteiraDeCobrancaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboCarteiraDeCobrancaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,218);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocarteiradecobrancaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocarteiradecobrancaid_Visible, edtavCombocarteiradecobrancaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_tituloid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombotituloid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboTituloId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombotituloid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboTituloId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboTituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,220);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotituloid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotituloid_Visible, edtavCombotituloid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Boleto.htm");
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
         E11372 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCARTEIRADECOBRANCAID_DATA"), AV14CarteiraDeCobrancaId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vTITULOID_DATA"), AV20TituloId_Data);
               /* Read saved values. */
               Z1077BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1077BoletosId"), ",", "."), 18, MidpointRounding.ToEven));
               Z1099BoletosCreatedAt = context.localUtil.CToT( cgiGet( "Z1099BoletosCreatedAt"), 0);
               n1099BoletosCreatedAt = ((DateTime.MinValue==A1099BoletosCreatedAt) ? true : false);
               Z1100BoletosUpdatedAt = context.localUtil.CToT( cgiGet( "Z1100BoletosUpdatedAt"), 0);
               n1100BoletosUpdatedAt = ((DateTime.MinValue==A1100BoletosUpdatedAt) ? true : false);
               Z1078BoletosNossoNumero = cgiGet( "Z1078BoletosNossoNumero");
               n1078BoletosNossoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1078BoletosNossoNumero)) ? true : false);
               Z1079BoletosSeuNumero = cgiGet( "Z1079BoletosSeuNumero");
               n1079BoletosSeuNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1079BoletosSeuNumero)) ? true : false);
               Z1080BoletosNumero = cgiGet( "Z1080BoletosNumero");
               n1080BoletosNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1080BoletosNumero)) ? true : false);
               Z1081BoletosLinhaDigitavel = cgiGet( "Z1081BoletosLinhaDigitavel");
               n1081BoletosLinhaDigitavel = (String.IsNullOrEmpty(StringUtil.RTrim( A1081BoletosLinhaDigitavel)) ? true : false);
               Z1082BoletosCodigoDeBarras = cgiGet( "Z1082BoletosCodigoDeBarras");
               n1082BoletosCodigoDeBarras = (String.IsNullOrEmpty(StringUtil.RTrim( A1082BoletosCodigoDeBarras)) ? true : false);
               Z1083BoletosStatus = cgiGet( "Z1083BoletosStatus");
               n1083BoletosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1083BoletosStatus)) ? true : false);
               Z1084BoletosDataEmissao = context.localUtil.CToD( cgiGet( "Z1084BoletosDataEmissao"), 0);
               n1084BoletosDataEmissao = ((DateTime.MinValue==A1084BoletosDataEmissao) ? true : false);
               Z1085BoletosDataVencimento = context.localUtil.CToD( cgiGet( "Z1085BoletosDataVencimento"), 0);
               n1085BoletosDataVencimento = ((DateTime.MinValue==A1085BoletosDataVencimento) ? true : false);
               Z1086BoletosDataRegistro = context.localUtil.CToT( cgiGet( "Z1086BoletosDataRegistro"), 0);
               n1086BoletosDataRegistro = ((DateTime.MinValue==A1086BoletosDataRegistro) ? true : false);
               Z1087BoletosDataPagamento = context.localUtil.CToD( cgiGet( "Z1087BoletosDataPagamento"), 0);
               n1087BoletosDataPagamento = ((DateTime.MinValue==A1087BoletosDataPagamento) ? true : false);
               Z1088BoletosDataBaixa = context.localUtil.CToD( cgiGet( "Z1088BoletosDataBaixa"), 0);
               n1088BoletosDataBaixa = ((DateTime.MinValue==A1088BoletosDataBaixa) ? true : false);
               Z1089BoletosValorNominal = context.localUtil.CToN( cgiGet( "Z1089BoletosValorNominal"), ",", ".");
               n1089BoletosValorNominal = ((Convert.ToDecimal(0)==A1089BoletosValorNominal) ? true : false);
               Z1090BoletosValorPago = context.localUtil.CToN( cgiGet( "Z1090BoletosValorPago"), ",", ".");
               n1090BoletosValorPago = ((Convert.ToDecimal(0)==A1090BoletosValorPago) ? true : false);
               Z1091BoletosValorDesconto = context.localUtil.CToN( cgiGet( "Z1091BoletosValorDesconto"), ",", ".");
               n1091BoletosValorDesconto = ((Convert.ToDecimal(0)==A1091BoletosValorDesconto) ? true : false);
               Z1092BoletosValorJuros = context.localUtil.CToN( cgiGet( "Z1092BoletosValorJuros"), ",", ".");
               n1092BoletosValorJuros = ((Convert.ToDecimal(0)==A1092BoletosValorJuros) ? true : false);
               Z1093BoletosValorMulta = context.localUtil.CToN( cgiGet( "Z1093BoletosValorMulta"), ",", ".");
               n1093BoletosValorMulta = ((Convert.ToDecimal(0)==A1093BoletosValorMulta) ? true : false);
               Z1094BoletosSacadoNome = cgiGet( "Z1094BoletosSacadoNome");
               n1094BoletosSacadoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1094BoletosSacadoNome)) ? true : false);
               Z1095BoletosSacadoDocumento = cgiGet( "Z1095BoletosSacadoDocumento");
               n1095BoletosSacadoDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1095BoletosSacadoDocumento)) ? true : false);
               Z1096BoletosSacadoTipoDocumento = cgiGet( "Z1096BoletosSacadoTipoDocumento");
               n1096BoletosSacadoTipoDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1096BoletosSacadoTipoDocumento)) ? true : false);
               Z1098BoletosTentativasDeRegistro = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1098BoletosTentativasDeRegistro"), ",", "."), 18, MidpointRounding.ToEven));
               n1098BoletosTentativasDeRegistro = ((0==A1098BoletosTentativasDeRegistro) ? true : false);
               Z1117BoletosResgitroId = StringUtil.StrToGuid( cgiGet( "Z1117BoletosResgitroId"));
               n1117BoletosResgitroId = ((Guid.Empty==A1117BoletosResgitroId) ? true : false);
               Z1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1069CarteiraDeCobrancaId"), ",", "."), 18, MidpointRounding.ToEven));
               n1069CarteiraDeCobrancaId = ((0==A1069CarteiraDeCobrancaId) ? true : false);
               Z261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z261TituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = ((0==A261TituloId) ? true : false);
               A1117BoletosResgitroId = StringUtil.StrToGuid( cgiGet( "Z1117BoletosResgitroId"));
               n1117BoletosResgitroId = false;
               n1117BoletosResgitroId = ((Guid.Empty==A1117BoletosResgitroId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1069CarteiraDeCobrancaId"), ",", "."), 18, MidpointRounding.ToEven));
               n1069CarteiraDeCobrancaId = ((0==A1069CarteiraDeCobrancaId) ? true : false);
               N261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N261TituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = ((0==A261TituloId) ? true : false);
               AV7BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vBOLETOSID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CARTEIRADECOBRANCAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV11Insert_CarteiraDeCobrancaId), 9, 0));
               AV12Insert_TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_TituloId", StringUtil.LTrimStr( (decimal)(AV12Insert_TituloId), 9, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A1117BoletosResgitroId = StringUtil.StrToGuid( cgiGet( "BOLETOSRESGITROID"));
               n1117BoletosResgitroId = ((Guid.Empty==A1117BoletosResgitroId) ? true : false);
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_carteiradecobrancaid_Objectcall = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Objectcall");
               Combo_carteiradecobrancaid_Class = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Class");
               Combo_carteiradecobrancaid_Icontype = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Icontype");
               Combo_carteiradecobrancaid_Icon = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Icon");
               Combo_carteiradecobrancaid_Caption = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Caption");
               Combo_carteiradecobrancaid_Tooltip = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Tooltip");
               Combo_carteiradecobrancaid_Cls = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Cls");
               Combo_carteiradecobrancaid_Selectedvalue_set = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Selectedvalue_set");
               Combo_carteiradecobrancaid_Selectedvalue_get = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Selectedvalue_get");
               Combo_carteiradecobrancaid_Selectedtext_set = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Selectedtext_set");
               Combo_carteiradecobrancaid_Selectedtext_get = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Selectedtext_get");
               Combo_carteiradecobrancaid_Gamoauthtoken = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Gamoauthtoken");
               Combo_carteiradecobrancaid_Ddointernalname = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Ddointernalname");
               Combo_carteiradecobrancaid_Titlecontrolalign = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Titlecontrolalign");
               Combo_carteiradecobrancaid_Dropdownoptionstype = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Dropdownoptionstype");
               Combo_carteiradecobrancaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Enabled"));
               Combo_carteiradecobrancaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Visible"));
               Combo_carteiradecobrancaid_Titlecontrolidtoreplace = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Titlecontrolidtoreplace");
               Combo_carteiradecobrancaid_Datalisttype = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Datalisttype");
               Combo_carteiradecobrancaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Allowmultipleselection"));
               Combo_carteiradecobrancaid_Datalistfixedvalues = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Datalistfixedvalues");
               Combo_carteiradecobrancaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Isgriditem"));
               Combo_carteiradecobrancaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Hasdescription"));
               Combo_carteiradecobrancaid_Datalistproc = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Datalistproc");
               Combo_carteiradecobrancaid_Datalistprocparametersprefix = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Datalistprocparametersprefix");
               Combo_carteiradecobrancaid_Remoteservicesparameters = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Remoteservicesparameters");
               Combo_carteiradecobrancaid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_carteiradecobrancaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Includeonlyselectedoption"));
               Combo_carteiradecobrancaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Includeselectalloption"));
               Combo_carteiradecobrancaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Emptyitem"));
               Combo_carteiradecobrancaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Includeaddnewoption"));
               Combo_carteiradecobrancaid_Htmltemplate = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Htmltemplate");
               Combo_carteiradecobrancaid_Multiplevaluestype = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Multiplevaluestype");
               Combo_carteiradecobrancaid_Loadingdata = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Loadingdata");
               Combo_carteiradecobrancaid_Noresultsfound = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Noresultsfound");
               Combo_carteiradecobrancaid_Emptyitemtext = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Emptyitemtext");
               Combo_carteiradecobrancaid_Onlyselectedvalues = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Onlyselectedvalues");
               Combo_carteiradecobrancaid_Selectalltext = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Selectalltext");
               Combo_carteiradecobrancaid_Multiplevaluesseparator = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Multiplevaluesseparator");
               Combo_carteiradecobrancaid_Addnewoptiontext = cgiGet( "COMBO_CARTEIRADECOBRANCAID_Addnewoptiontext");
               Combo_carteiradecobrancaid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CARTEIRADECOBRANCAID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_tituloid_Objectcall = cgiGet( "COMBO_TITULOID_Objectcall");
               Combo_tituloid_Class = cgiGet( "COMBO_TITULOID_Class");
               Combo_tituloid_Icontype = cgiGet( "COMBO_TITULOID_Icontype");
               Combo_tituloid_Icon = cgiGet( "COMBO_TITULOID_Icon");
               Combo_tituloid_Caption = cgiGet( "COMBO_TITULOID_Caption");
               Combo_tituloid_Tooltip = cgiGet( "COMBO_TITULOID_Tooltip");
               Combo_tituloid_Cls = cgiGet( "COMBO_TITULOID_Cls");
               Combo_tituloid_Selectedvalue_set = cgiGet( "COMBO_TITULOID_Selectedvalue_set");
               Combo_tituloid_Selectedvalue_get = cgiGet( "COMBO_TITULOID_Selectedvalue_get");
               Combo_tituloid_Selectedtext_set = cgiGet( "COMBO_TITULOID_Selectedtext_set");
               Combo_tituloid_Selectedtext_get = cgiGet( "COMBO_TITULOID_Selectedtext_get");
               Combo_tituloid_Gamoauthtoken = cgiGet( "COMBO_TITULOID_Gamoauthtoken");
               Combo_tituloid_Ddointernalname = cgiGet( "COMBO_TITULOID_Ddointernalname");
               Combo_tituloid_Titlecontrolalign = cgiGet( "COMBO_TITULOID_Titlecontrolalign");
               Combo_tituloid_Dropdownoptionstype = cgiGet( "COMBO_TITULOID_Dropdownoptionstype");
               Combo_tituloid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Enabled"));
               Combo_tituloid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Visible"));
               Combo_tituloid_Titlecontrolidtoreplace = cgiGet( "COMBO_TITULOID_Titlecontrolidtoreplace");
               Combo_tituloid_Datalisttype = cgiGet( "COMBO_TITULOID_Datalisttype");
               Combo_tituloid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Allowmultipleselection"));
               Combo_tituloid_Datalistfixedvalues = cgiGet( "COMBO_TITULOID_Datalistfixedvalues");
               Combo_tituloid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Isgriditem"));
               Combo_tituloid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Hasdescription"));
               Combo_tituloid_Datalistproc = cgiGet( "COMBO_TITULOID_Datalistproc");
               Combo_tituloid_Datalistprocparametersprefix = cgiGet( "COMBO_TITULOID_Datalistprocparametersprefix");
               Combo_tituloid_Remoteservicesparameters = cgiGet( "COMBO_TITULOID_Remoteservicesparameters");
               Combo_tituloid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TITULOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_tituloid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Includeonlyselectedoption"));
               Combo_tituloid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Includeselectalloption"));
               Combo_tituloid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Emptyitem"));
               Combo_tituloid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Includeaddnewoption"));
               Combo_tituloid_Htmltemplate = cgiGet( "COMBO_TITULOID_Htmltemplate");
               Combo_tituloid_Multiplevaluestype = cgiGet( "COMBO_TITULOID_Multiplevaluestype");
               Combo_tituloid_Loadingdata = cgiGet( "COMBO_TITULOID_Loadingdata");
               Combo_tituloid_Noresultsfound = cgiGet( "COMBO_TITULOID_Noresultsfound");
               Combo_tituloid_Emptyitemtext = cgiGet( "COMBO_TITULOID_Emptyitemtext");
               Combo_tituloid_Onlyselectedvalues = cgiGet( "COMBO_TITULOID_Onlyselectedvalues");
               Combo_tituloid_Selectalltext = cgiGet( "COMBO_TITULOID_Selectalltext");
               Combo_tituloid_Multiplevaluesseparator = cgiGet( "COMBO_TITULOID_Multiplevaluesseparator");
               Combo_tituloid_Addnewoptiontext = cgiGet( "COMBO_TITULOID_Addnewoptiontext");
               Combo_tituloid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TITULOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A1077BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1077BoletosId = false;
               AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
               n1069CarteiraDeCobrancaId = ((StringUtil.StrCmp(cgiGet( edtCarteiraDeCobrancaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CARTEIRADECOBRANCAID");
                  AnyError = 1;
                  GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1069CarteiraDeCobrancaId = 0;
                  n1069CarteiraDeCobrancaId = false;
                  AssignAttri("", false, "A1069CarteiraDeCobrancaId", (n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
               }
               else
               {
                  A1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1069CarteiraDeCobrancaId", (n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
               }
               n261TituloId = ((StringUtil.StrCmp(cgiGet( edtTituloId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTituloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A261TituloId = 0;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", (n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               }
               else
               {
                  A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A261TituloId", (n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               }
               A1078BoletosNossoNumero = cgiGet( edtBoletosNossoNumero_Internalname);
               n1078BoletosNossoNumero = false;
               AssignAttri("", false, "A1078BoletosNossoNumero", A1078BoletosNossoNumero);
               n1078BoletosNossoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1078BoletosNossoNumero)) ? true : false);
               A1079BoletosSeuNumero = cgiGet( edtBoletosSeuNumero_Internalname);
               n1079BoletosSeuNumero = false;
               AssignAttri("", false, "A1079BoletosSeuNumero", A1079BoletosSeuNumero);
               n1079BoletosSeuNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1079BoletosSeuNumero)) ? true : false);
               A1080BoletosNumero = cgiGet( edtBoletosNumero_Internalname);
               n1080BoletosNumero = false;
               AssignAttri("", false, "A1080BoletosNumero", A1080BoletosNumero);
               n1080BoletosNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1080BoletosNumero)) ? true : false);
               A1081BoletosLinhaDigitavel = cgiGet( edtBoletosLinhaDigitavel_Internalname);
               n1081BoletosLinhaDigitavel = false;
               AssignAttri("", false, "A1081BoletosLinhaDigitavel", A1081BoletosLinhaDigitavel);
               n1081BoletosLinhaDigitavel = (String.IsNullOrEmpty(StringUtil.RTrim( A1081BoletosLinhaDigitavel)) ? true : false);
               A1082BoletosCodigoDeBarras = cgiGet( edtBoletosCodigoDeBarras_Internalname);
               n1082BoletosCodigoDeBarras = false;
               AssignAttri("", false, "A1082BoletosCodigoDeBarras", A1082BoletosCodigoDeBarras);
               n1082BoletosCodigoDeBarras = (String.IsNullOrEmpty(StringUtil.RTrim( A1082BoletosCodigoDeBarras)) ? true : false);
               cmbBoletosStatus.CurrentValue = cgiGet( cmbBoletosStatus_Internalname);
               A1083BoletosStatus = cgiGet( cmbBoletosStatus_Internalname);
               n1083BoletosStatus = false;
               AssignAttri("", false, "A1083BoletosStatus", A1083BoletosStatus);
               n1083BoletosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1083BoletosStatus)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtBoletosDataEmissao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Boletos Data Emissao"}), 1, "BOLETOSDATAEMISSAO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosDataEmissao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1084BoletosDataEmissao = DateTime.MinValue;
                  n1084BoletosDataEmissao = false;
                  AssignAttri("", false, "A1084BoletosDataEmissao", context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"));
               }
               else
               {
                  A1084BoletosDataEmissao = context.localUtil.CToD( cgiGet( edtBoletosDataEmissao_Internalname), 2);
                  n1084BoletosDataEmissao = false;
                  AssignAttri("", false, "A1084BoletosDataEmissao", context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"));
               }
               n1084BoletosDataEmissao = ((DateTime.MinValue==A1084BoletosDataEmissao) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtBoletosDataVencimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Boletos Data Vencimento"}), 1, "BOLETOSDATAVENCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosDataVencimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1085BoletosDataVencimento = DateTime.MinValue;
                  n1085BoletosDataVencimento = false;
                  AssignAttri("", false, "A1085BoletosDataVencimento", context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"));
               }
               else
               {
                  A1085BoletosDataVencimento = context.localUtil.CToD( cgiGet( edtBoletosDataVencimento_Internalname), 2);
                  n1085BoletosDataVencimento = false;
                  AssignAttri("", false, "A1085BoletosDataVencimento", context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"));
               }
               n1085BoletosDataVencimento = ((DateTime.MinValue==A1085BoletosDataVencimento) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtBoletosDataRegistro_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Boletos Data Registro"}), 1, "BOLETOSDATAREGISTRO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosDataRegistro_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
                  n1086BoletosDataRegistro = false;
                  AssignAttri("", false, "A1086BoletosDataRegistro", context.localUtil.TToC( A1086BoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1086BoletosDataRegistro = context.localUtil.CToT( cgiGet( edtBoletosDataRegistro_Internalname));
                  n1086BoletosDataRegistro = false;
                  AssignAttri("", false, "A1086BoletosDataRegistro", context.localUtil.TToC( A1086BoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
               }
               n1086BoletosDataRegistro = ((DateTime.MinValue==A1086BoletosDataRegistro) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtBoletosDataPagamento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Boletos Data Pagamento"}), 1, "BOLETOSDATAPAGAMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosDataPagamento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1087BoletosDataPagamento = DateTime.MinValue;
                  n1087BoletosDataPagamento = false;
                  AssignAttri("", false, "A1087BoletosDataPagamento", context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"));
               }
               else
               {
                  A1087BoletosDataPagamento = context.localUtil.CToD( cgiGet( edtBoletosDataPagamento_Internalname), 2);
                  n1087BoletosDataPagamento = false;
                  AssignAttri("", false, "A1087BoletosDataPagamento", context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"));
               }
               n1087BoletosDataPagamento = ((DateTime.MinValue==A1087BoletosDataPagamento) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtBoletosDataBaixa_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Boletos Data Baixa"}), 1, "BOLETOSDATABAIXA");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosDataBaixa_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1088BoletosDataBaixa = DateTime.MinValue;
                  n1088BoletosDataBaixa = false;
                  AssignAttri("", false, "A1088BoletosDataBaixa", context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"));
               }
               else
               {
                  A1088BoletosDataBaixa = context.localUtil.CToD( cgiGet( edtBoletosDataBaixa_Internalname), 2);
                  n1088BoletosDataBaixa = false;
                  AssignAttri("", false, "A1088BoletosDataBaixa", context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"));
               }
               n1088BoletosDataBaixa = ((DateTime.MinValue==A1088BoletosDataBaixa) ? true : false);
               n1089BoletosValorNominal = ((StringUtil.StrCmp(cgiGet( edtBoletosValorNominal_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosValorNominal_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosValorNominal_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSVALORNOMINAL");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosValorNominal_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1089BoletosValorNominal = 0;
                  n1089BoletosValorNominal = false;
                  AssignAttri("", false, "A1089BoletosValorNominal", (n1089BoletosValorNominal ? "" : StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ".", ""))));
               }
               else
               {
                  A1089BoletosValorNominal = context.localUtil.CToN( cgiGet( edtBoletosValorNominal_Internalname), ",", ".");
                  AssignAttri("", false, "A1089BoletosValorNominal", (n1089BoletosValorNominal ? "" : StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ".", ""))));
               }
               n1090BoletosValorPago = ((StringUtil.StrCmp(cgiGet( edtBoletosValorPago_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosValorPago_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosValorPago_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSVALORPAGO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosValorPago_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1090BoletosValorPago = 0;
                  n1090BoletosValorPago = false;
                  AssignAttri("", false, "A1090BoletosValorPago", (n1090BoletosValorPago ? "" : StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ".", ""))));
               }
               else
               {
                  A1090BoletosValorPago = context.localUtil.CToN( cgiGet( edtBoletosValorPago_Internalname), ",", ".");
                  AssignAttri("", false, "A1090BoletosValorPago", (n1090BoletosValorPago ? "" : StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ".", ""))));
               }
               n1091BoletosValorDesconto = ((StringUtil.StrCmp(cgiGet( edtBoletosValorDesconto_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosValorDesconto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosValorDesconto_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSVALORDESCONTO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosValorDesconto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1091BoletosValorDesconto = 0;
                  n1091BoletosValorDesconto = false;
                  AssignAttri("", false, "A1091BoletosValorDesconto", (n1091BoletosValorDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ".", ""))));
               }
               else
               {
                  A1091BoletosValorDesconto = context.localUtil.CToN( cgiGet( edtBoletosValorDesconto_Internalname), ",", ".");
                  AssignAttri("", false, "A1091BoletosValorDesconto", (n1091BoletosValorDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ".", ""))));
               }
               n1092BoletosValorJuros = ((StringUtil.StrCmp(cgiGet( edtBoletosValorJuros_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosValorJuros_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosValorJuros_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSVALORJUROS");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosValorJuros_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1092BoletosValorJuros = 0;
                  n1092BoletosValorJuros = false;
                  AssignAttri("", false, "A1092BoletosValorJuros", (n1092BoletosValorJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ".", ""))));
               }
               else
               {
                  A1092BoletosValorJuros = context.localUtil.CToN( cgiGet( edtBoletosValorJuros_Internalname), ",", ".");
                  AssignAttri("", false, "A1092BoletosValorJuros", (n1092BoletosValorJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ".", ""))));
               }
               n1093BoletosValorMulta = ((StringUtil.StrCmp(cgiGet( edtBoletosValorMulta_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosValorMulta_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosValorMulta_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSVALORMULTA");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosValorMulta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1093BoletosValorMulta = 0;
                  n1093BoletosValorMulta = false;
                  AssignAttri("", false, "A1093BoletosValorMulta", (n1093BoletosValorMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ".", ""))));
               }
               else
               {
                  A1093BoletosValorMulta = context.localUtil.CToN( cgiGet( edtBoletosValorMulta_Internalname), ",", ".");
                  AssignAttri("", false, "A1093BoletosValorMulta", (n1093BoletosValorMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ".", ""))));
               }
               A1094BoletosSacadoNome = cgiGet( edtBoletosSacadoNome_Internalname);
               n1094BoletosSacadoNome = false;
               AssignAttri("", false, "A1094BoletosSacadoNome", A1094BoletosSacadoNome);
               n1094BoletosSacadoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1094BoletosSacadoNome)) ? true : false);
               A1095BoletosSacadoDocumento = cgiGet( edtBoletosSacadoDocumento_Internalname);
               n1095BoletosSacadoDocumento = false;
               AssignAttri("", false, "A1095BoletosSacadoDocumento", A1095BoletosSacadoDocumento);
               n1095BoletosSacadoDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1095BoletosSacadoDocumento)) ? true : false);
               cmbBoletosSacadoTipoDocumento.CurrentValue = cgiGet( cmbBoletosSacadoTipoDocumento_Internalname);
               A1096BoletosSacadoTipoDocumento = cgiGet( cmbBoletosSacadoTipoDocumento_Internalname);
               n1096BoletosSacadoTipoDocumento = false;
               AssignAttri("", false, "A1096BoletosSacadoTipoDocumento", A1096BoletosSacadoTipoDocumento);
               n1096BoletosSacadoTipoDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1096BoletosSacadoTipoDocumento)) ? true : false);
               A1097BoletosMensagemDeErro = cgiGet( edtBoletosMensagemDeErro_Internalname);
               n1097BoletosMensagemDeErro = false;
               AssignAttri("", false, "A1097BoletosMensagemDeErro", A1097BoletosMensagemDeErro);
               n1097BoletosMensagemDeErro = (String.IsNullOrEmpty(StringUtil.RTrim( A1097BoletosMensagemDeErro)) ? true : false);
               n1098BoletosTentativasDeRegistro = ((StringUtil.StrCmp(cgiGet( edtBoletosTentativasDeRegistro_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosTentativasDeRegistro_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosTentativasDeRegistro_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSTENTATIVASDEREGISTRO");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosTentativasDeRegistro_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1098BoletosTentativasDeRegistro = 0;
                  n1098BoletosTentativasDeRegistro = false;
                  AssignAttri("", false, "A1098BoletosTentativasDeRegistro", (n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098BoletosTentativasDeRegistro), 8, 0, ".", ""))));
               }
               else
               {
                  A1098BoletosTentativasDeRegistro = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosTentativasDeRegistro_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1098BoletosTentativasDeRegistro", (n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098BoletosTentativasDeRegistro), 8, 0, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtBoletosCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Boletos Created At"}), 1, "BOLETOSCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
                  n1099BoletosCreatedAt = false;
                  AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1099BoletosCreatedAt = context.localUtil.CToT( cgiGet( edtBoletosCreatedAt_Internalname));
                  n1099BoletosCreatedAt = false;
                  AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n1099BoletosCreatedAt = ((DateTime.MinValue==A1099BoletosCreatedAt) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtBoletosUpdatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Boletos Updated At"}), 1, "BOLETOSUPDATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosUpdatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
                  n1100BoletosUpdatedAt = false;
                  AssignAttri("", false, "A1100BoletosUpdatedAt", context.localUtil.TToC( A1100BoletosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1100BoletosUpdatedAt = context.localUtil.CToT( cgiGet( edtBoletosUpdatedAt_Internalname));
                  n1100BoletosUpdatedAt = false;
                  AssignAttri("", false, "A1100BoletosUpdatedAt", context.localUtil.TToC( A1100BoletosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n1100BoletosUpdatedAt = ((DateTime.MinValue==A1100BoletosUpdatedAt) ? true : false);
               A1071CarteiraDeCobrancaNome = cgiGet( edtCarteiraDeCobrancaNome_Internalname);
               n1071CarteiraDeCobrancaNome = false;
               AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
               A1073CarteiraDeCobrancaConvenio = cgiGet( edtCarteiraDeCobrancaConvenio_Internalname);
               n1073CarteiraDeCobrancaConvenio = false;
               AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
               cmbCarteiraDeCobrancaStatus.CurrentValue = cgiGet( cmbCarteiraDeCobrancaStatus_Internalname);
               A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cgiGet( cmbCarteiraDeCobrancaStatus_Internalname));
               n1074CarteiraDeCobrancaStatus = false;
               AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
               A1111CarteiraDeCobrancaValorTotal = context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaValorTotal_Internalname), ",", ".");
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1112CarteiraDeCobrancaValorRecebido = context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaValorRecebido_Internalname), ",", ".");
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaTotalBoletos_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
               A1115CarteiraDeCobrancaTotalBoletosExpirados = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
               A1116CarteiraDeCobrancaTotalBoletosCancelados = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
               AV19ComboCarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocarteiradecobrancaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboCarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV19ComboCarteiraDeCobrancaId), 9, 0));
               AV21ComboTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombotituloid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Boleto");
               A1077BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1077BoletosId = false;
               AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
               forbiddenHiddens.Add("BoletosId", context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_CarteiraDeCobrancaId", context.localUtil.Format( (decimal)(AV11Insert_CarteiraDeCobrancaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TituloId", context.localUtil.Format( (decimal)(AV12Insert_TituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("BoletosResgitroId", A1117BoletosResgitroId.ToString());
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1077BoletosId != Z1077BoletosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("boleto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1077BoletosId = (int)(Math.Round(NumberUtil.Val( GetPar( "BoletosId"), "."), 18, MidpointRounding.ToEven));
                  n1077BoletosId = false;
                  AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
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
                     sMode111 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode111;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound111 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_370( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "BOLETOSID");
                        AnyError = 1;
                        GX_FocusControl = edtBoletosId_Internalname;
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
                           E11372 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12372 ();
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
            E12372 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll37111( ) ;
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
            DisableAttributes37111( ) ;
         }
         AssignProp("", false, edtavCombocarteiradecobrancaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocarteiradecobrancaid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombotituloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotituloid_Enabled), 5, 0), true);
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

      protected void CONFIRM_370( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls37111( ) ;
            }
            else
            {
               CheckExtendedTable37111( ) ;
               CloseExtendedTableCursors37111( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption370( )
      {
      }

      protected void E11372( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtTituloId_Visible = 0;
         AssignProp("", false, edtTituloId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloId_Visible), 5, 0), true);
         AV21ComboTituloId = 0;
         AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
         edtavCombotituloid_Visible = 0;
         AssignProp("", false, edtavCombotituloid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotituloid_Visible), 5, 0), true);
         edtCarteiraDeCobrancaId_Visible = 0;
         AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Visible), 5, 0), true);
         AV19ComboCarteiraDeCobrancaId = 0;
         AssignAttri("", false, "AV19ComboCarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV19ComboCarteiraDeCobrancaId), 9, 0));
         edtavCombocarteiradecobrancaid_Visible = 0;
         AssignProp("", false, edtavCombocarteiradecobrancaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocarteiradecobrancaid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCARTEIRADECOBRANCAID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOTITULOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CarteiraDeCobrancaId") == 0 )
               {
                  AV11Insert_CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV11Insert_CarteiraDeCobrancaId), 9, 0));
                  if ( ! (0==AV11Insert_CarteiraDeCobrancaId) )
                  {
                     AV19ComboCarteiraDeCobrancaId = AV11Insert_CarteiraDeCobrancaId;
                     AssignAttri("", false, "AV19ComboCarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV19ComboCarteiraDeCobrancaId), 9, 0));
                     Combo_carteiradecobrancaid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboCarteiraDeCobrancaId), 9, 0));
                     ucCombo_carteiradecobrancaid.SendProperty(context, "", false, Combo_carteiradecobrancaid_Internalname, "SelectedValue_set", Combo_carteiradecobrancaid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new boletoloaddvcombo(context ).execute(  "CarteiraDeCobrancaId",  "GET",  false,  AV7BoletosId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_carteiradecobrancaid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_carteiradecobrancaid.SendProperty(context, "", false, Combo_carteiradecobrancaid_Internalname, "SelectedText_set", Combo_carteiradecobrancaid_Selectedtext_set);
                     Combo_carteiradecobrancaid_Enabled = false;
                     ucCombo_carteiradecobrancaid.SendProperty(context, "", false, Combo_carteiradecobrancaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_carteiradecobrancaid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TituloId") == 0 )
               {
                  AV12Insert_TituloId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_TituloId", StringUtil.LTrimStr( (decimal)(AV12Insert_TituloId), 9, 0));
                  if ( ! (0==AV12Insert_TituloId) )
                  {
                     AV21ComboTituloId = AV12Insert_TituloId;
                     AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
                     Combo_tituloid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboTituloId), 9, 0));
                     ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedValue_set", Combo_tituloid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new boletoloaddvcombo(context ).execute(  "TituloId",  "GET",  false,  AV7BoletosId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_tituloid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedText_set", Combo_tituloid_Selectedtext_set);
                     Combo_tituloid_Enabled = false;
                     ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tituloid_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E12372( )
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
            GXEncryptionTmp = "boletoww"+UrlEncode(StringUtil.LTrimStr(A1069CarteiraDeCobrancaId,9,0));
            CallWebObject(formatLink("boletoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOTITULOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new boletoloaddvcombo(context ).execute(  "TituloId",  Gx_mode,  false,  AV7BoletosId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_tituloid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedValue_set", Combo_tituloid_Selectedvalue_set);
         Combo_tituloid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedText_set", Combo_tituloid_Selectedtext_set);
         AV21ComboTituloId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tituloid_Enabled = false;
            ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tituloid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCARTEIRADECOBRANCAID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new boletoloaddvcombo(context ).execute(  "CarteiraDeCobrancaId",  Gx_mode,  false,  AV7BoletosId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_carteiradecobrancaid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_carteiradecobrancaid.SendProperty(context, "", false, Combo_carteiradecobrancaid_Internalname, "SelectedValue_set", Combo_carteiradecobrancaid_Selectedvalue_set);
         Combo_carteiradecobrancaid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_carteiradecobrancaid.SendProperty(context, "", false, Combo_carteiradecobrancaid_Internalname, "SelectedText_set", Combo_carteiradecobrancaid_Selectedtext_set);
         AV19ComboCarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboCarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV19ComboCarteiraDeCobrancaId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_carteiradecobrancaid_Enabled = false;
            ucCombo_carteiradecobrancaid.SendProperty(context, "", false, Combo_carteiradecobrancaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_carteiradecobrancaid_Enabled));
         }
      }

      protected void ZM37111( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1099BoletosCreatedAt = T00373_A1099BoletosCreatedAt[0];
               Z1100BoletosUpdatedAt = T00373_A1100BoletosUpdatedAt[0];
               Z1078BoletosNossoNumero = T00373_A1078BoletosNossoNumero[0];
               Z1079BoletosSeuNumero = T00373_A1079BoletosSeuNumero[0];
               Z1080BoletosNumero = T00373_A1080BoletosNumero[0];
               Z1081BoletosLinhaDigitavel = T00373_A1081BoletosLinhaDigitavel[0];
               Z1082BoletosCodigoDeBarras = T00373_A1082BoletosCodigoDeBarras[0];
               Z1083BoletosStatus = T00373_A1083BoletosStatus[0];
               Z1084BoletosDataEmissao = T00373_A1084BoletosDataEmissao[0];
               Z1085BoletosDataVencimento = T00373_A1085BoletosDataVencimento[0];
               Z1086BoletosDataRegistro = T00373_A1086BoletosDataRegistro[0];
               Z1087BoletosDataPagamento = T00373_A1087BoletosDataPagamento[0];
               Z1088BoletosDataBaixa = T00373_A1088BoletosDataBaixa[0];
               Z1089BoletosValorNominal = T00373_A1089BoletosValorNominal[0];
               Z1090BoletosValorPago = T00373_A1090BoletosValorPago[0];
               Z1091BoletosValorDesconto = T00373_A1091BoletosValorDesconto[0];
               Z1092BoletosValorJuros = T00373_A1092BoletosValorJuros[0];
               Z1093BoletosValorMulta = T00373_A1093BoletosValorMulta[0];
               Z1094BoletosSacadoNome = T00373_A1094BoletosSacadoNome[0];
               Z1095BoletosSacadoDocumento = T00373_A1095BoletosSacadoDocumento[0];
               Z1096BoletosSacadoTipoDocumento = T00373_A1096BoletosSacadoTipoDocumento[0];
               Z1098BoletosTentativasDeRegistro = T00373_A1098BoletosTentativasDeRegistro[0];
               Z1117BoletosResgitroId = T00373_A1117BoletosResgitroId[0];
               Z1069CarteiraDeCobrancaId = T00373_A1069CarteiraDeCobrancaId[0];
               Z261TituloId = T00373_A261TituloId[0];
            }
            else
            {
               Z1099BoletosCreatedAt = A1099BoletosCreatedAt;
               Z1100BoletosUpdatedAt = A1100BoletosUpdatedAt;
               Z1078BoletosNossoNumero = A1078BoletosNossoNumero;
               Z1079BoletosSeuNumero = A1079BoletosSeuNumero;
               Z1080BoletosNumero = A1080BoletosNumero;
               Z1081BoletosLinhaDigitavel = A1081BoletosLinhaDigitavel;
               Z1082BoletosCodigoDeBarras = A1082BoletosCodigoDeBarras;
               Z1083BoletosStatus = A1083BoletosStatus;
               Z1084BoletosDataEmissao = A1084BoletosDataEmissao;
               Z1085BoletosDataVencimento = A1085BoletosDataVencimento;
               Z1086BoletosDataRegistro = A1086BoletosDataRegistro;
               Z1087BoletosDataPagamento = A1087BoletosDataPagamento;
               Z1088BoletosDataBaixa = A1088BoletosDataBaixa;
               Z1089BoletosValorNominal = A1089BoletosValorNominal;
               Z1090BoletosValorPago = A1090BoletosValorPago;
               Z1091BoletosValorDesconto = A1091BoletosValorDesconto;
               Z1092BoletosValorJuros = A1092BoletosValorJuros;
               Z1093BoletosValorMulta = A1093BoletosValorMulta;
               Z1094BoletosSacadoNome = A1094BoletosSacadoNome;
               Z1095BoletosSacadoDocumento = A1095BoletosSacadoDocumento;
               Z1096BoletosSacadoTipoDocumento = A1096BoletosSacadoTipoDocumento;
               Z1098BoletosTentativasDeRegistro = A1098BoletosTentativasDeRegistro;
               Z1117BoletosResgitroId = A1117BoletosResgitroId;
               Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
               Z261TituloId = A261TituloId;
            }
         }
         if ( GX_JID == -23 )
         {
            Z1077BoletosId = A1077BoletosId;
            Z1099BoletosCreatedAt = A1099BoletosCreatedAt;
            Z1100BoletosUpdatedAt = A1100BoletosUpdatedAt;
            Z1078BoletosNossoNumero = A1078BoletosNossoNumero;
            Z1079BoletosSeuNumero = A1079BoletosSeuNumero;
            Z1080BoletosNumero = A1080BoletosNumero;
            Z1081BoletosLinhaDigitavel = A1081BoletosLinhaDigitavel;
            Z1082BoletosCodigoDeBarras = A1082BoletosCodigoDeBarras;
            Z1083BoletosStatus = A1083BoletosStatus;
            Z1084BoletosDataEmissao = A1084BoletosDataEmissao;
            Z1085BoletosDataVencimento = A1085BoletosDataVencimento;
            Z1086BoletosDataRegistro = A1086BoletosDataRegistro;
            Z1087BoletosDataPagamento = A1087BoletosDataPagamento;
            Z1088BoletosDataBaixa = A1088BoletosDataBaixa;
            Z1089BoletosValorNominal = A1089BoletosValorNominal;
            Z1090BoletosValorPago = A1090BoletosValorPago;
            Z1091BoletosValorDesconto = A1091BoletosValorDesconto;
            Z1092BoletosValorJuros = A1092BoletosValorJuros;
            Z1093BoletosValorMulta = A1093BoletosValorMulta;
            Z1094BoletosSacadoNome = A1094BoletosSacadoNome;
            Z1095BoletosSacadoDocumento = A1095BoletosSacadoDocumento;
            Z1096BoletosSacadoTipoDocumento = A1096BoletosSacadoTipoDocumento;
            Z1097BoletosMensagemDeErro = A1097BoletosMensagemDeErro;
            Z1098BoletosTentativasDeRegistro = A1098BoletosTentativasDeRegistro;
            Z1117BoletosResgitroId = A1117BoletosResgitroId;
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            Z261TituloId = A261TituloId;
            Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
            Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
            Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
      }

      protected void standaloneNotModal( )
      {
         edtBoletosId_Enabled = 0;
         AssignProp("", false, edtBoletosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV22Pgmname = "Boleto";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         edtBoletosId_Enabled = 0;
         AssignProp("", false, edtBoletosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7BoletosId) )
         {
            A1077BoletosId = AV7BoletosId;
            n1077BoletosId = false;
            AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CarteiraDeCobrancaId) )
         {
            edtCarteiraDeCobrancaId_Enabled = 0;
            AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Enabled), 5, 0), true);
         }
         else
         {
            edtCarteiraDeCobrancaId_Enabled = 1;
            AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TituloId) )
         {
            edtTituloId_Enabled = 0;
            AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         }
         else
         {
            edtTituloId_Enabled = 1;
            AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1099BoletosCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1099BoletosCreatedAt = false;
            AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A1100BoletosUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1100BoletosUpdatedAt = false;
            AssignAttri("", false, "A1100BoletosUpdatedAt", context.localUtil.TToC( A1100BoletosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CarteiraDeCobrancaId) )
         {
            A1069CarteiraDeCobrancaId = AV11Insert_CarteiraDeCobrancaId;
            n1069CarteiraDeCobrancaId = false;
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboCarteiraDeCobrancaId) )
            {
               A1069CarteiraDeCobrancaId = 0;
               n1069CarteiraDeCobrancaId = false;
               AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
               n1069CarteiraDeCobrancaId = true;
               n1069CarteiraDeCobrancaId = true;
               AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboCarteiraDeCobrancaId) )
               {
                  A1069CarteiraDeCobrancaId = AV19ComboCarteiraDeCobrancaId;
                  n1069CarteiraDeCobrancaId = false;
                  AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TituloId) )
         {
            A261TituloId = AV12Insert_TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboTituloId) )
            {
               A261TituloId = 0;
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               n261TituloId = true;
               n261TituloId = true;
               AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboTituloId) )
               {
                  A261TituloId = AV21ComboTituloId;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
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
         if ( IsIns( )  && (Guid.Empty==A1117BoletosResgitroId) && ( Gx_BScreen == 0 ) )
         {
            A1117BoletosResgitroId = Guid.NewGuid( );
            n1117BoletosResgitroId = false;
            AssignAttri("", false, "A1117BoletosResgitroId", A1117BoletosResgitroId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00374 */
            pr_default.execute(2, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            A1071CarteiraDeCobrancaNome = T00374_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = T00374_n1071CarteiraDeCobrancaNome[0];
            AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
            A1073CarteiraDeCobrancaConvenio = T00374_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = T00374_n1073CarteiraDeCobrancaConvenio[0];
            AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
            A1074CarteiraDeCobrancaStatus = T00374_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = T00374_n1074CarteiraDeCobrancaStatus[0];
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
            pr_default.close(2);
            /* Using cursor T00377 */
            pr_default.execute(4, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A1112CarteiraDeCobrancaValorRecebido = T00377_A1112CarteiraDeCobrancaValorRecebido[0];
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1111CarteiraDeCobrancaValorTotal = T00377_A1111CarteiraDeCobrancaValorTotal[0];
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = T00377_A1113CarteiraDeCobrancaTotalBoletos[0];
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            else
            {
               A1112CarteiraDeCobrancaValorRecebido = 0;
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1111CarteiraDeCobrancaValorTotal = 0;
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = 0;
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            pr_default.close(4);
            /* Using cursor T00379 */
            pr_default.execute(5, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = T00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = T00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            else
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            pr_default.close(5);
            /* Using cursor T003711 */
            pr_default.execute(6, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = T003711_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               n1115CarteiraDeCobrancaTotalBoletosExpirados = T003711_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            else
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            pr_default.close(6);
            /* Using cursor T003713 */
            pr_default.execute(7, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = T003713_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               n1116CarteiraDeCobrancaTotalBoletosCancelados = T003713_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            else
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            pr_default.close(7);
         }
      }

      protected void Load37111( )
      {
         /* Using cursor T003718 */
         pr_default.execute(8, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound111 = 1;
            A1099BoletosCreatedAt = T003718_A1099BoletosCreatedAt[0];
            n1099BoletosCreatedAt = T003718_n1099BoletosCreatedAt[0];
            AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1100BoletosUpdatedAt = T003718_A1100BoletosUpdatedAt[0];
            n1100BoletosUpdatedAt = T003718_n1100BoletosUpdatedAt[0];
            AssignAttri("", false, "A1100BoletosUpdatedAt", context.localUtil.TToC( A1100BoletosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1078BoletosNossoNumero = T003718_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = T003718_n1078BoletosNossoNumero[0];
            AssignAttri("", false, "A1078BoletosNossoNumero", A1078BoletosNossoNumero);
            A1079BoletosSeuNumero = T003718_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = T003718_n1079BoletosSeuNumero[0];
            AssignAttri("", false, "A1079BoletosSeuNumero", A1079BoletosSeuNumero);
            A1080BoletosNumero = T003718_A1080BoletosNumero[0];
            n1080BoletosNumero = T003718_n1080BoletosNumero[0];
            AssignAttri("", false, "A1080BoletosNumero", A1080BoletosNumero);
            A1081BoletosLinhaDigitavel = T003718_A1081BoletosLinhaDigitavel[0];
            n1081BoletosLinhaDigitavel = T003718_n1081BoletosLinhaDigitavel[0];
            AssignAttri("", false, "A1081BoletosLinhaDigitavel", A1081BoletosLinhaDigitavel);
            A1082BoletosCodigoDeBarras = T003718_A1082BoletosCodigoDeBarras[0];
            n1082BoletosCodigoDeBarras = T003718_n1082BoletosCodigoDeBarras[0];
            AssignAttri("", false, "A1082BoletosCodigoDeBarras", A1082BoletosCodigoDeBarras);
            A1083BoletosStatus = T003718_A1083BoletosStatus[0];
            n1083BoletosStatus = T003718_n1083BoletosStatus[0];
            AssignAttri("", false, "A1083BoletosStatus", A1083BoletosStatus);
            A1084BoletosDataEmissao = T003718_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = T003718_n1084BoletosDataEmissao[0];
            AssignAttri("", false, "A1084BoletosDataEmissao", context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"));
            A1085BoletosDataVencimento = T003718_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = T003718_n1085BoletosDataVencimento[0];
            AssignAttri("", false, "A1085BoletosDataVencimento", context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"));
            A1086BoletosDataRegistro = T003718_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = T003718_n1086BoletosDataRegistro[0];
            AssignAttri("", false, "A1086BoletosDataRegistro", context.localUtil.TToC( A1086BoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
            A1087BoletosDataPagamento = T003718_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = T003718_n1087BoletosDataPagamento[0];
            AssignAttri("", false, "A1087BoletosDataPagamento", context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"));
            A1088BoletosDataBaixa = T003718_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = T003718_n1088BoletosDataBaixa[0];
            AssignAttri("", false, "A1088BoletosDataBaixa", context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"));
            A1089BoletosValorNominal = T003718_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = T003718_n1089BoletosValorNominal[0];
            AssignAttri("", false, "A1089BoletosValorNominal", ((Convert.ToDecimal(0)==A1089BoletosValorNominal)&&IsIns( )||n1089BoletosValorNominal ? "" : StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ".", ""))));
            A1090BoletosValorPago = T003718_A1090BoletosValorPago[0];
            n1090BoletosValorPago = T003718_n1090BoletosValorPago[0];
            AssignAttri("", false, "A1090BoletosValorPago", ((Convert.ToDecimal(0)==A1090BoletosValorPago)&&IsIns( )||n1090BoletosValorPago ? "" : StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ".", ""))));
            A1091BoletosValorDesconto = T003718_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = T003718_n1091BoletosValorDesconto[0];
            AssignAttri("", false, "A1091BoletosValorDesconto", ((Convert.ToDecimal(0)==A1091BoletosValorDesconto)&&IsIns( )||n1091BoletosValorDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ".", ""))));
            A1092BoletosValorJuros = T003718_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = T003718_n1092BoletosValorJuros[0];
            AssignAttri("", false, "A1092BoletosValorJuros", ((Convert.ToDecimal(0)==A1092BoletosValorJuros)&&IsIns( )||n1092BoletosValorJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ".", ""))));
            A1093BoletosValorMulta = T003718_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = T003718_n1093BoletosValorMulta[0];
            AssignAttri("", false, "A1093BoletosValorMulta", ((Convert.ToDecimal(0)==A1093BoletosValorMulta)&&IsIns( )||n1093BoletosValorMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ".", ""))));
            A1094BoletosSacadoNome = T003718_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = T003718_n1094BoletosSacadoNome[0];
            AssignAttri("", false, "A1094BoletosSacadoNome", A1094BoletosSacadoNome);
            A1095BoletosSacadoDocumento = T003718_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = T003718_n1095BoletosSacadoDocumento[0];
            AssignAttri("", false, "A1095BoletosSacadoDocumento", A1095BoletosSacadoDocumento);
            A1096BoletosSacadoTipoDocumento = T003718_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = T003718_n1096BoletosSacadoTipoDocumento[0];
            AssignAttri("", false, "A1096BoletosSacadoTipoDocumento", A1096BoletosSacadoTipoDocumento);
            A1097BoletosMensagemDeErro = T003718_A1097BoletosMensagemDeErro[0];
            n1097BoletosMensagemDeErro = T003718_n1097BoletosMensagemDeErro[0];
            AssignAttri("", false, "A1097BoletosMensagemDeErro", A1097BoletosMensagemDeErro);
            A1098BoletosTentativasDeRegistro = T003718_A1098BoletosTentativasDeRegistro[0];
            n1098BoletosTentativasDeRegistro = T003718_n1098BoletosTentativasDeRegistro[0];
            AssignAttri("", false, "A1098BoletosTentativasDeRegistro", ((0==A1098BoletosTentativasDeRegistro)&&IsIns( )||n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098BoletosTentativasDeRegistro), 8, 0, ".", ""))));
            A1117BoletosResgitroId = T003718_A1117BoletosResgitroId[0];
            n1117BoletosResgitroId = T003718_n1117BoletosResgitroId[0];
            A1071CarteiraDeCobrancaNome = T003718_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = T003718_n1071CarteiraDeCobrancaNome[0];
            AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
            A1073CarteiraDeCobrancaConvenio = T003718_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = T003718_n1073CarteiraDeCobrancaConvenio[0];
            AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
            A1074CarteiraDeCobrancaStatus = T003718_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = T003718_n1074CarteiraDeCobrancaStatus[0];
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
            A1069CarteiraDeCobrancaId = T003718_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = T003718_n1069CarteiraDeCobrancaId[0];
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            A261TituloId = T003718_A261TituloId[0];
            n261TituloId = T003718_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            A1112CarteiraDeCobrancaValorRecebido = T003718_A1112CarteiraDeCobrancaValorRecebido[0];
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1111CarteiraDeCobrancaValorTotal = T003718_A1111CarteiraDeCobrancaValorTotal[0];
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = T003718_A1113CarteiraDeCobrancaTotalBoletos[0];
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003718_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003718_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003718_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003718_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            ZM37111( -23) ;
         }
         pr_default.close(8);
         OnLoadActions37111( ) ;
      }

      protected void OnLoadActions37111( )
      {
      }

      protected void CheckExtendedTable37111( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00374 */
         pr_default.execute(2, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1069CarteiraDeCobrancaId) ) )
            {
               GX_msglist.addItem("Não existe 'CarteiraDeCobranca'.", "ForeignKeyNotFound", 1, "CARTEIRADECOBRANCAID");
               AnyError = 1;
               GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1071CarteiraDeCobrancaNome = T00374_A1071CarteiraDeCobrancaNome[0];
         n1071CarteiraDeCobrancaNome = T00374_n1071CarteiraDeCobrancaNome[0];
         AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
         A1073CarteiraDeCobrancaConvenio = T00374_A1073CarteiraDeCobrancaConvenio[0];
         n1073CarteiraDeCobrancaConvenio = T00374_n1073CarteiraDeCobrancaConvenio[0];
         AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
         A1074CarteiraDeCobrancaStatus = T00374_A1074CarteiraDeCobrancaStatus[0];
         n1074CarteiraDeCobrancaStatus = T00374_n1074CarteiraDeCobrancaStatus[0];
         AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         pr_default.close(2);
         /* Using cursor T00377 */
         pr_default.execute(4, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A1112CarteiraDeCobrancaValorRecebido = T00377_A1112CarteiraDeCobrancaValorRecebido[0];
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1111CarteiraDeCobrancaValorTotal = T00377_A1111CarteiraDeCobrancaValorTotal[0];
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = T00377_A1113CarteiraDeCobrancaTotalBoletos[0];
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         }
         else
         {
            A1112CarteiraDeCobrancaValorRecebido = 0;
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1111CarteiraDeCobrancaValorTotal = 0;
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = 0;
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         }
         pr_default.close(4);
         if ( ( A1112CarteiraDeCobrancaValorRecebido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1111CarteiraDeCobrancaValorTotal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T00379 */
         pr_default.execute(5, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         }
         pr_default.close(5);
         /* Using cursor T003711 */
         pr_default.execute(6, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003711_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003711_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         }
         pr_default.close(6);
         /* Using cursor T003713 */
         pr_default.execute(7, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003713_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003713_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         }
         pr_default.close(7);
         /* Using cursor T00375 */
         pr_default.execute(3, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
               GX_FocusControl = edtTituloId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A1083BoletosStatus, "RASCUNHO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "REGISTRADO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "LIQUIDADO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "BAIXADO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1083BoletosStatus)) ) )
         {
            GX_msglist.addItem("Campo Boletos Status fora do intervalo", "OutOfRange", 1, "BOLETOSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbBoletosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A1089BoletosValorNominal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "BOLETOSVALORNOMINAL");
            AnyError = 1;
            GX_FocusControl = edtBoletosValorNominal_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A1090BoletosValorPago < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "BOLETOSVALORPAGO");
            AnyError = 1;
            GX_FocusControl = edtBoletosValorPago_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A1091BoletosValorDesconto < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "BOLETOSVALORDESCONTO");
            AnyError = 1;
            GX_FocusControl = edtBoletosValorDesconto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A1092BoletosValorJuros < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "BOLETOSVALORJUROS");
            AnyError = 1;
            GX_FocusControl = edtBoletosValorJuros_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A1093BoletosValorMulta < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "BOLETOSVALORMULTA");
            AnyError = 1;
            GX_FocusControl = edtBoletosValorMulta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A1096BoletosSacadoTipoDocumento, "CPF") == 0 ) || ( StringUtil.StrCmp(A1096BoletosSacadoTipoDocumento, "CNPJ") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1096BoletosSacadoTipoDocumento)) ) )
         {
            GX_msglist.addItem("Campo Boletos Sacado Tipo Documento fora do intervalo", "OutOfRange", 1, "BOLETOSSACADOTIPODOCUMENTO");
            AnyError = 1;
            GX_FocusControl = cmbBoletosSacadoTipoDocumento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors37111( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003719 */
         pr_default.execute(9, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A1069CarteiraDeCobrancaId) ) )
            {
               GX_msglist.addItem("Não existe 'CarteiraDeCobranca'.", "ForeignKeyNotFound", 1, "CARTEIRADECOBRANCAID");
               AnyError = 1;
               GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1071CarteiraDeCobrancaNome = T003719_A1071CarteiraDeCobrancaNome[0];
         n1071CarteiraDeCobrancaNome = T003719_n1071CarteiraDeCobrancaNome[0];
         AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
         A1073CarteiraDeCobrancaConvenio = T003719_A1073CarteiraDeCobrancaConvenio[0];
         n1073CarteiraDeCobrancaConvenio = T003719_n1073CarteiraDeCobrancaConvenio[0];
         AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
         A1074CarteiraDeCobrancaStatus = T003719_A1074CarteiraDeCobrancaStatus[0];
         n1074CarteiraDeCobrancaStatus = T003719_n1074CarteiraDeCobrancaStatus[0];
         AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1071CarteiraDeCobrancaNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A1073CarteiraDeCobrancaConvenio)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_26( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003721 */
         pr_default.execute(10, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A1112CarteiraDeCobrancaValorRecebido = T003721_A1112CarteiraDeCobrancaValorRecebido[0];
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1111CarteiraDeCobrancaValorTotal = T003721_A1111CarteiraDeCobrancaValorTotal[0];
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = T003721_A1113CarteiraDeCobrancaTotalBoletos[0];
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         }
         else
         {
            A1112CarteiraDeCobrancaValorRecebido = 0;
            AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
            A1111CarteiraDeCobrancaValorTotal = 0;
            AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
            A1113CarteiraDeCobrancaTotalBoletos = 0;
            AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1112CarteiraDeCobrancaValorRecebido, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1111CarteiraDeCobrancaValorTotal, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_27( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003723 */
         pr_default.execute(11, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003723_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003723_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
            AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_28( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003725 */
         pr_default.execute(12, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003725_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003725_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
            AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_29( int A1069CarteiraDeCobrancaId )
      {
         /* Using cursor T003727 */
         pr_default.execute(13, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003727_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003727_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
            AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_25( int A261TituloId )
      {
         /* Using cursor T003728 */
         pr_default.execute(14, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
               GX_FocusControl = edtTituloId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey37111( )
      {
         /* Using cursor T003729 */
         pr_default.execute(15, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound111 = 1;
         }
         else
         {
            RcdFound111 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00373 */
         pr_default.execute(1, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM37111( 23) ;
            RcdFound111 = 1;
            A1077BoletosId = T00373_A1077BoletosId[0];
            n1077BoletosId = T00373_n1077BoletosId[0];
            AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
            A1099BoletosCreatedAt = T00373_A1099BoletosCreatedAt[0];
            n1099BoletosCreatedAt = T00373_n1099BoletosCreatedAt[0];
            AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1100BoletosUpdatedAt = T00373_A1100BoletosUpdatedAt[0];
            n1100BoletosUpdatedAt = T00373_n1100BoletosUpdatedAt[0];
            AssignAttri("", false, "A1100BoletosUpdatedAt", context.localUtil.TToC( A1100BoletosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1078BoletosNossoNumero = T00373_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = T00373_n1078BoletosNossoNumero[0];
            AssignAttri("", false, "A1078BoletosNossoNumero", A1078BoletosNossoNumero);
            A1079BoletosSeuNumero = T00373_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = T00373_n1079BoletosSeuNumero[0];
            AssignAttri("", false, "A1079BoletosSeuNumero", A1079BoletosSeuNumero);
            A1080BoletosNumero = T00373_A1080BoletosNumero[0];
            n1080BoletosNumero = T00373_n1080BoletosNumero[0];
            AssignAttri("", false, "A1080BoletosNumero", A1080BoletosNumero);
            A1081BoletosLinhaDigitavel = T00373_A1081BoletosLinhaDigitavel[0];
            n1081BoletosLinhaDigitavel = T00373_n1081BoletosLinhaDigitavel[0];
            AssignAttri("", false, "A1081BoletosLinhaDigitavel", A1081BoletosLinhaDigitavel);
            A1082BoletosCodigoDeBarras = T00373_A1082BoletosCodigoDeBarras[0];
            n1082BoletosCodigoDeBarras = T00373_n1082BoletosCodigoDeBarras[0];
            AssignAttri("", false, "A1082BoletosCodigoDeBarras", A1082BoletosCodigoDeBarras);
            A1083BoletosStatus = T00373_A1083BoletosStatus[0];
            n1083BoletosStatus = T00373_n1083BoletosStatus[0];
            AssignAttri("", false, "A1083BoletosStatus", A1083BoletosStatus);
            A1084BoletosDataEmissao = T00373_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = T00373_n1084BoletosDataEmissao[0];
            AssignAttri("", false, "A1084BoletosDataEmissao", context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"));
            A1085BoletosDataVencimento = T00373_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = T00373_n1085BoletosDataVencimento[0];
            AssignAttri("", false, "A1085BoletosDataVencimento", context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"));
            A1086BoletosDataRegistro = T00373_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = T00373_n1086BoletosDataRegistro[0];
            AssignAttri("", false, "A1086BoletosDataRegistro", context.localUtil.TToC( A1086BoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
            A1087BoletosDataPagamento = T00373_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = T00373_n1087BoletosDataPagamento[0];
            AssignAttri("", false, "A1087BoletosDataPagamento", context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"));
            A1088BoletosDataBaixa = T00373_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = T00373_n1088BoletosDataBaixa[0];
            AssignAttri("", false, "A1088BoletosDataBaixa", context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"));
            A1089BoletosValorNominal = T00373_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = T00373_n1089BoletosValorNominal[0];
            AssignAttri("", false, "A1089BoletosValorNominal", ((Convert.ToDecimal(0)==A1089BoletosValorNominal)&&IsIns( )||n1089BoletosValorNominal ? "" : StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ".", ""))));
            A1090BoletosValorPago = T00373_A1090BoletosValorPago[0];
            n1090BoletosValorPago = T00373_n1090BoletosValorPago[0];
            AssignAttri("", false, "A1090BoletosValorPago", ((Convert.ToDecimal(0)==A1090BoletosValorPago)&&IsIns( )||n1090BoletosValorPago ? "" : StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ".", ""))));
            A1091BoletosValorDesconto = T00373_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = T00373_n1091BoletosValorDesconto[0];
            AssignAttri("", false, "A1091BoletosValorDesconto", ((Convert.ToDecimal(0)==A1091BoletosValorDesconto)&&IsIns( )||n1091BoletosValorDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ".", ""))));
            A1092BoletosValorJuros = T00373_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = T00373_n1092BoletosValorJuros[0];
            AssignAttri("", false, "A1092BoletosValorJuros", ((Convert.ToDecimal(0)==A1092BoletosValorJuros)&&IsIns( )||n1092BoletosValorJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ".", ""))));
            A1093BoletosValorMulta = T00373_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = T00373_n1093BoletosValorMulta[0];
            AssignAttri("", false, "A1093BoletosValorMulta", ((Convert.ToDecimal(0)==A1093BoletosValorMulta)&&IsIns( )||n1093BoletosValorMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ".", ""))));
            A1094BoletosSacadoNome = T00373_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = T00373_n1094BoletosSacadoNome[0];
            AssignAttri("", false, "A1094BoletosSacadoNome", A1094BoletosSacadoNome);
            A1095BoletosSacadoDocumento = T00373_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = T00373_n1095BoletosSacadoDocumento[0];
            AssignAttri("", false, "A1095BoletosSacadoDocumento", A1095BoletosSacadoDocumento);
            A1096BoletosSacadoTipoDocumento = T00373_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = T00373_n1096BoletosSacadoTipoDocumento[0];
            AssignAttri("", false, "A1096BoletosSacadoTipoDocumento", A1096BoletosSacadoTipoDocumento);
            A1097BoletosMensagemDeErro = T00373_A1097BoletosMensagemDeErro[0];
            n1097BoletosMensagemDeErro = T00373_n1097BoletosMensagemDeErro[0];
            AssignAttri("", false, "A1097BoletosMensagemDeErro", A1097BoletosMensagemDeErro);
            A1098BoletosTentativasDeRegistro = T00373_A1098BoletosTentativasDeRegistro[0];
            n1098BoletosTentativasDeRegistro = T00373_n1098BoletosTentativasDeRegistro[0];
            AssignAttri("", false, "A1098BoletosTentativasDeRegistro", ((0==A1098BoletosTentativasDeRegistro)&&IsIns( )||n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098BoletosTentativasDeRegistro), 8, 0, ".", ""))));
            A1117BoletosResgitroId = T00373_A1117BoletosResgitroId[0];
            n1117BoletosResgitroId = T00373_n1117BoletosResgitroId[0];
            A1069CarteiraDeCobrancaId = T00373_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = T00373_n1069CarteiraDeCobrancaId[0];
            AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            A261TituloId = T00373_A261TituloId[0];
            n261TituloId = T00373_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            Z1077BoletosId = A1077BoletosId;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load37111( ) ;
            if ( AnyError == 1 )
            {
               RcdFound111 = 0;
               InitializeNonKey37111( ) ;
            }
            Gx_mode = sMode111;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound111 = 0;
            InitializeNonKey37111( ) ;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode111;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey37111( ) ;
         if ( RcdFound111 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound111 = 0;
         /* Using cursor T003730 */
         pr_default.execute(16, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T003730_A1077BoletosId[0] < A1077BoletosId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T003730_A1077BoletosId[0] > A1077BoletosId ) ) )
            {
               A1077BoletosId = T003730_A1077BoletosId[0];
               n1077BoletosId = T003730_n1077BoletosId[0];
               AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
               RcdFound111 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound111 = 0;
         /* Using cursor T003731 */
         pr_default.execute(17, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T003731_A1077BoletosId[0] > A1077BoletosId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T003731_A1077BoletosId[0] < A1077BoletosId ) ) )
            {
               A1077BoletosId = T003731_A1077BoletosId[0];
               n1077BoletosId = T003731_n1077BoletosId[0];
               AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
               RcdFound111 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey37111( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert37111( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound111 == 1 )
            {
               if ( A1077BoletosId != Z1077BoletosId )
               {
                  A1077BoletosId = Z1077BoletosId;
                  n1077BoletosId = false;
                  AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BOLETOSID");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update37111( ) ;
                  GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1077BoletosId != Z1077BoletosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert37111( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BOLETOSID");
                     AnyError = 1;
                     GX_FocusControl = edtBoletosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert37111( ) ;
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
         if ( A1077BoletosId != Z1077BoletosId )
         {
            A1077BoletosId = Z1077BoletosId;
            n1077BoletosId = false;
            AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BOLETOSID");
            AnyError = 1;
            GX_FocusControl = edtBoletosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency37111( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00372 */
            pr_default.execute(0, new Object[] {n1077BoletosId, A1077BoletosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Boleto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1099BoletosCreatedAt != T00372_A1099BoletosCreatedAt[0] ) || ( Z1100BoletosUpdatedAt != T00372_A1100BoletosUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1078BoletosNossoNumero, T00372_A1078BoletosNossoNumero[0]) != 0 ) || ( StringUtil.StrCmp(Z1079BoletosSeuNumero, T00372_A1079BoletosSeuNumero[0]) != 0 ) || ( StringUtil.StrCmp(Z1080BoletosNumero, T00372_A1080BoletosNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1081BoletosLinhaDigitavel, T00372_A1081BoletosLinhaDigitavel[0]) != 0 ) || ( StringUtil.StrCmp(Z1082BoletosCodigoDeBarras, T00372_A1082BoletosCodigoDeBarras[0]) != 0 ) || ( StringUtil.StrCmp(Z1083BoletosStatus, T00372_A1083BoletosStatus[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1084BoletosDataEmissao ) != DateTimeUtil.ResetTime ( T00372_A1084BoletosDataEmissao[0] ) ) || ( DateTimeUtil.ResetTime ( Z1085BoletosDataVencimento ) != DateTimeUtil.ResetTime ( T00372_A1085BoletosDataVencimento[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1086BoletosDataRegistro != T00372_A1086BoletosDataRegistro[0] ) || ( DateTimeUtil.ResetTime ( Z1087BoletosDataPagamento ) != DateTimeUtil.ResetTime ( T00372_A1087BoletosDataPagamento[0] ) ) || ( DateTimeUtil.ResetTime ( Z1088BoletosDataBaixa ) != DateTimeUtil.ResetTime ( T00372_A1088BoletosDataBaixa[0] ) ) || ( Z1089BoletosValorNominal != T00372_A1089BoletosValorNominal[0] ) || ( Z1090BoletosValorPago != T00372_A1090BoletosValorPago[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1091BoletosValorDesconto != T00372_A1091BoletosValorDesconto[0] ) || ( Z1092BoletosValorJuros != T00372_A1092BoletosValorJuros[0] ) || ( Z1093BoletosValorMulta != T00372_A1093BoletosValorMulta[0] ) || ( StringUtil.StrCmp(Z1094BoletosSacadoNome, T00372_A1094BoletosSacadoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z1095BoletosSacadoDocumento, T00372_A1095BoletosSacadoDocumento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1096BoletosSacadoTipoDocumento, T00372_A1096BoletosSacadoTipoDocumento[0]) != 0 ) || ( Z1098BoletosTentativasDeRegistro != T00372_A1098BoletosTentativasDeRegistro[0] ) || ( Z1117BoletosResgitroId != T00372_A1117BoletosResgitroId[0] ) || ( Z1069CarteiraDeCobrancaId != T00372_A1069CarteiraDeCobrancaId[0] ) || ( Z261TituloId != T00372_A261TituloId[0] ) )
            {
               if ( Z1099BoletosCreatedAt != T00372_A1099BoletosCreatedAt[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1099BoletosCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1099BoletosCreatedAt[0]);
               }
               if ( Z1100BoletosUpdatedAt != T00372_A1100BoletosUpdatedAt[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1100BoletosUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1100BoletosUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z1078BoletosNossoNumero, T00372_A1078BoletosNossoNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosNossoNumero");
                  GXUtil.WriteLogRaw("Old: ",Z1078BoletosNossoNumero);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1078BoletosNossoNumero[0]);
               }
               if ( StringUtil.StrCmp(Z1079BoletosSeuNumero, T00372_A1079BoletosSeuNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosSeuNumero");
                  GXUtil.WriteLogRaw("Old: ",Z1079BoletosSeuNumero);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1079BoletosSeuNumero[0]);
               }
               if ( StringUtil.StrCmp(Z1080BoletosNumero, T00372_A1080BoletosNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosNumero");
                  GXUtil.WriteLogRaw("Old: ",Z1080BoletosNumero);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1080BoletosNumero[0]);
               }
               if ( StringUtil.StrCmp(Z1081BoletosLinhaDigitavel, T00372_A1081BoletosLinhaDigitavel[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosLinhaDigitavel");
                  GXUtil.WriteLogRaw("Old: ",Z1081BoletosLinhaDigitavel);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1081BoletosLinhaDigitavel[0]);
               }
               if ( StringUtil.StrCmp(Z1082BoletosCodigoDeBarras, T00372_A1082BoletosCodigoDeBarras[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosCodigoDeBarras");
                  GXUtil.WriteLogRaw("Old: ",Z1082BoletosCodigoDeBarras);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1082BoletosCodigoDeBarras[0]);
               }
               if ( StringUtil.StrCmp(Z1083BoletosStatus, T00372_A1083BoletosStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z1083BoletosStatus);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1083BoletosStatus[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1084BoletosDataEmissao ) != DateTimeUtil.ResetTime ( T00372_A1084BoletosDataEmissao[0] ) )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosDataEmissao");
                  GXUtil.WriteLogRaw("Old: ",Z1084BoletosDataEmissao);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1084BoletosDataEmissao[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1085BoletosDataVencimento ) != DateTimeUtil.ResetTime ( T00372_A1085BoletosDataVencimento[0] ) )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosDataVencimento");
                  GXUtil.WriteLogRaw("Old: ",Z1085BoletosDataVencimento);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1085BoletosDataVencimento[0]);
               }
               if ( Z1086BoletosDataRegistro != T00372_A1086BoletosDataRegistro[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosDataRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z1086BoletosDataRegistro);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1086BoletosDataRegistro[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1087BoletosDataPagamento ) != DateTimeUtil.ResetTime ( T00372_A1087BoletosDataPagamento[0] ) )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosDataPagamento");
                  GXUtil.WriteLogRaw("Old: ",Z1087BoletosDataPagamento);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1087BoletosDataPagamento[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1088BoletosDataBaixa ) != DateTimeUtil.ResetTime ( T00372_A1088BoletosDataBaixa[0] ) )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosDataBaixa");
                  GXUtil.WriteLogRaw("Old: ",Z1088BoletosDataBaixa);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1088BoletosDataBaixa[0]);
               }
               if ( Z1089BoletosValorNominal != T00372_A1089BoletosValorNominal[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosValorNominal");
                  GXUtil.WriteLogRaw("Old: ",Z1089BoletosValorNominal);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1089BoletosValorNominal[0]);
               }
               if ( Z1090BoletosValorPago != T00372_A1090BoletosValorPago[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosValorPago");
                  GXUtil.WriteLogRaw("Old: ",Z1090BoletosValorPago);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1090BoletosValorPago[0]);
               }
               if ( Z1091BoletosValorDesconto != T00372_A1091BoletosValorDesconto[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosValorDesconto");
                  GXUtil.WriteLogRaw("Old: ",Z1091BoletosValorDesconto);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1091BoletosValorDesconto[0]);
               }
               if ( Z1092BoletosValorJuros != T00372_A1092BoletosValorJuros[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosValorJuros");
                  GXUtil.WriteLogRaw("Old: ",Z1092BoletosValorJuros);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1092BoletosValorJuros[0]);
               }
               if ( Z1093BoletosValorMulta != T00372_A1093BoletosValorMulta[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosValorMulta");
                  GXUtil.WriteLogRaw("Old: ",Z1093BoletosValorMulta);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1093BoletosValorMulta[0]);
               }
               if ( StringUtil.StrCmp(Z1094BoletosSacadoNome, T00372_A1094BoletosSacadoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosSacadoNome");
                  GXUtil.WriteLogRaw("Old: ",Z1094BoletosSacadoNome);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1094BoletosSacadoNome[0]);
               }
               if ( StringUtil.StrCmp(Z1095BoletosSacadoDocumento, T00372_A1095BoletosSacadoDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosSacadoDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z1095BoletosSacadoDocumento);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1095BoletosSacadoDocumento[0]);
               }
               if ( StringUtil.StrCmp(Z1096BoletosSacadoTipoDocumento, T00372_A1096BoletosSacadoTipoDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosSacadoTipoDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z1096BoletosSacadoTipoDocumento);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1096BoletosSacadoTipoDocumento[0]);
               }
               if ( Z1098BoletosTentativasDeRegistro != T00372_A1098BoletosTentativasDeRegistro[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosTentativasDeRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z1098BoletosTentativasDeRegistro);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1098BoletosTentativasDeRegistro[0]);
               }
               if ( Z1117BoletosResgitroId != T00372_A1117BoletosResgitroId[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"BoletosResgitroId");
                  GXUtil.WriteLogRaw("Old: ",Z1117BoletosResgitroId);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1117BoletosResgitroId[0]);
               }
               if ( Z1069CarteiraDeCobrancaId != T00372_A1069CarteiraDeCobrancaId[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"CarteiraDeCobrancaId");
                  GXUtil.WriteLogRaw("Old: ",Z1069CarteiraDeCobrancaId);
                  GXUtil.WriteLogRaw("Current: ",T00372_A1069CarteiraDeCobrancaId[0]);
               }
               if ( Z261TituloId != T00372_A261TituloId[0] )
               {
                  GXUtil.WriteLog("boleto:[seudo value changed for attri]"+"TituloId");
                  GXUtil.WriteLogRaw("Old: ",Z261TituloId);
                  GXUtil.WriteLogRaw("Current: ",T00372_A261TituloId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Boleto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert37111( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable37111( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM37111( 0) ;
            CheckOptimisticConcurrency37111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm37111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert37111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003732 */
                     pr_default.execute(18, new Object[] {n1099BoletosCreatedAt, A1099BoletosCreatedAt, n1100BoletosUpdatedAt, A1100BoletosUpdatedAt, n1078BoletosNossoNumero, A1078BoletosNossoNumero, n1079BoletosSeuNumero, A1079BoletosSeuNumero, n1080BoletosNumero, A1080BoletosNumero, n1081BoletosLinhaDigitavel, A1081BoletosLinhaDigitavel, n1082BoletosCodigoDeBarras, A1082BoletosCodigoDeBarras, n1083BoletosStatus, A1083BoletosStatus, n1084BoletosDataEmissao, A1084BoletosDataEmissao, n1085BoletosDataVencimento, A1085BoletosDataVencimento, n1086BoletosDataRegistro, A1086BoletosDataRegistro, n1087BoletosDataPagamento, A1087BoletosDataPagamento, n1088BoletosDataBaixa, A1088BoletosDataBaixa, n1089BoletosValorNominal, A1089BoletosValorNominal, n1090BoletosValorPago, A1090BoletosValorPago, n1091BoletosValorDesconto, A1091BoletosValorDesconto, n1092BoletosValorJuros, A1092BoletosValorJuros, n1093BoletosValorMulta, A1093BoletosValorMulta, n1094BoletosSacadoNome, A1094BoletosSacadoNome, n1095BoletosSacadoDocumento, A1095BoletosSacadoDocumento, n1096BoletosSacadoTipoDocumento, A1096BoletosSacadoTipoDocumento, n1097BoletosMensagemDeErro, A1097BoletosMensagemDeErro, n1098BoletosTentativasDeRegistro, A1098BoletosTentativasDeRegistro, n1117BoletosResgitroId, A1117BoletosResgitroId, n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId, n261TituloId, A261TituloId});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003733 */
                     pr_default.execute(19);
                     A1077BoletosId = T003733_A1077BoletosId[0];
                     n1077BoletosId = T003733_n1077BoletosId[0];
                     AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Boleto");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption370( ) ;
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
               Load37111( ) ;
            }
            EndLevel37111( ) ;
         }
         CloseExtendedTableCursors37111( ) ;
      }

      protected void Update37111( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable37111( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency37111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm37111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate37111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003734 */
                     pr_default.execute(20, new Object[] {n1099BoletosCreatedAt, A1099BoletosCreatedAt, n1100BoletosUpdatedAt, A1100BoletosUpdatedAt, n1078BoletosNossoNumero, A1078BoletosNossoNumero, n1079BoletosSeuNumero, A1079BoletosSeuNumero, n1080BoletosNumero, A1080BoletosNumero, n1081BoletosLinhaDigitavel, A1081BoletosLinhaDigitavel, n1082BoletosCodigoDeBarras, A1082BoletosCodigoDeBarras, n1083BoletosStatus, A1083BoletosStatus, n1084BoletosDataEmissao, A1084BoletosDataEmissao, n1085BoletosDataVencimento, A1085BoletosDataVencimento, n1086BoletosDataRegistro, A1086BoletosDataRegistro, n1087BoletosDataPagamento, A1087BoletosDataPagamento, n1088BoletosDataBaixa, A1088BoletosDataBaixa, n1089BoletosValorNominal, A1089BoletosValorNominal, n1090BoletosValorPago, A1090BoletosValorPago, n1091BoletosValorDesconto, A1091BoletosValorDesconto, n1092BoletosValorJuros, A1092BoletosValorJuros, n1093BoletosValorMulta, A1093BoletosValorMulta, n1094BoletosSacadoNome, A1094BoletosSacadoNome, n1095BoletosSacadoDocumento, A1095BoletosSacadoDocumento, n1096BoletosSacadoTipoDocumento, A1096BoletosSacadoTipoDocumento, n1097BoletosMensagemDeErro, A1097BoletosMensagemDeErro, n1098BoletosTentativasDeRegistro, A1098BoletosTentativasDeRegistro, n1117BoletosResgitroId, A1117BoletosResgitroId, n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId, n261TituloId, A261TituloId, n1077BoletosId, A1077BoletosId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Boleto");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Boleto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate37111( ) ;
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
            EndLevel37111( ) ;
         }
         CloseExtendedTableCursors37111( ) ;
      }

      protected void DeferredUpdate37111( )
      {
      }

      protected void delete( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency37111( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls37111( ) ;
            AfterConfirm37111( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete37111( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003735 */
                  pr_default.execute(21, new Object[] {n1077BoletosId, A1077BoletosId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("Boleto");
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
         sMode111 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel37111( ) ;
         Gx_mode = sMode111;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls37111( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003736 */
            pr_default.execute(22, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            A1071CarteiraDeCobrancaNome = T003736_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = T003736_n1071CarteiraDeCobrancaNome[0];
            AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
            A1073CarteiraDeCobrancaConvenio = T003736_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = T003736_n1073CarteiraDeCobrancaConvenio[0];
            AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
            A1074CarteiraDeCobrancaStatus = T003736_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = T003736_n1074CarteiraDeCobrancaStatus[0];
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
            pr_default.close(22);
            /* Using cursor T003738 */
            pr_default.execute(23, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A1112CarteiraDeCobrancaValorRecebido = T003738_A1112CarteiraDeCobrancaValorRecebido[0];
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1111CarteiraDeCobrancaValorTotal = T003738_A1111CarteiraDeCobrancaValorTotal[0];
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = T003738_A1113CarteiraDeCobrancaTotalBoletos[0];
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            else
            {
               A1112CarteiraDeCobrancaValorRecebido = 0;
               AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
               A1111CarteiraDeCobrancaValorTotal = 0;
               AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
               A1113CarteiraDeCobrancaTotalBoletos = 0;
               AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            pr_default.close(23);
            /* Using cursor T003740 */
            pr_default.execute(24, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003740_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003740_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            else
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
               AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            pr_default.close(24);
            /* Using cursor T003742 */
            pr_default.execute(25, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = T003742_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               n1115CarteiraDeCobrancaTotalBoletosExpirados = T003742_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            else
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
               AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            pr_default.close(25);
            /* Using cursor T003744 */
            pr_default.execute(26, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = T003744_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               n1116CarteiraDeCobrancaTotalBoletosCancelados = T003744_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            else
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
               AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            pr_default.close(26);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003745 */
            pr_default.execute(27, new Object[] {n1077BoletosId, A1077BoletosId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"BoletosLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
         }
      }

      protected void EndLevel37111( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete37111( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues370( ) ;
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

      public void ScanStart37111( )
      {
         /* Scan By routine */
         /* Using cursor T003746 */
         pr_default.execute(28);
         RcdFound111 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound111 = 1;
            A1077BoletosId = T003746_A1077BoletosId[0];
            n1077BoletosId = T003746_n1077BoletosId[0];
            AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext37111( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound111 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound111 = 1;
            A1077BoletosId = T003746_A1077BoletosId[0];
            n1077BoletosId = T003746_n1077BoletosId[0];
            AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
         }
      }

      protected void ScanEnd37111( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm37111( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert37111( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate37111( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete37111( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete37111( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate37111( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes37111( )
      {
         edtBoletosId_Enabled = 0;
         AssignProp("", false, edtBoletosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosId_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaId_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaId_Enabled), 5, 0), true);
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         edtBoletosNossoNumero_Enabled = 0;
         AssignProp("", false, edtBoletosNossoNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosNossoNumero_Enabled), 5, 0), true);
         edtBoletosSeuNumero_Enabled = 0;
         AssignProp("", false, edtBoletosSeuNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosSeuNumero_Enabled), 5, 0), true);
         edtBoletosNumero_Enabled = 0;
         AssignProp("", false, edtBoletosNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosNumero_Enabled), 5, 0), true);
         edtBoletosLinhaDigitavel_Enabled = 0;
         AssignProp("", false, edtBoletosLinhaDigitavel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLinhaDigitavel_Enabled), 5, 0), true);
         edtBoletosCodigoDeBarras_Enabled = 0;
         AssignProp("", false, edtBoletosCodigoDeBarras_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosCodigoDeBarras_Enabled), 5, 0), true);
         cmbBoletosStatus.Enabled = 0;
         AssignProp("", false, cmbBoletosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbBoletosStatus.Enabled), 5, 0), true);
         edtBoletosDataEmissao_Enabled = 0;
         AssignProp("", false, edtBoletosDataEmissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosDataEmissao_Enabled), 5, 0), true);
         edtBoletosDataVencimento_Enabled = 0;
         AssignProp("", false, edtBoletosDataVencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosDataVencimento_Enabled), 5, 0), true);
         edtBoletosDataRegistro_Enabled = 0;
         AssignProp("", false, edtBoletosDataRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosDataRegistro_Enabled), 5, 0), true);
         edtBoletosDataPagamento_Enabled = 0;
         AssignProp("", false, edtBoletosDataPagamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosDataPagamento_Enabled), 5, 0), true);
         edtBoletosDataBaixa_Enabled = 0;
         AssignProp("", false, edtBoletosDataBaixa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosDataBaixa_Enabled), 5, 0), true);
         edtBoletosValorNominal_Enabled = 0;
         AssignProp("", false, edtBoletosValorNominal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosValorNominal_Enabled), 5, 0), true);
         edtBoletosValorPago_Enabled = 0;
         AssignProp("", false, edtBoletosValorPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosValorPago_Enabled), 5, 0), true);
         edtBoletosValorDesconto_Enabled = 0;
         AssignProp("", false, edtBoletosValorDesconto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosValorDesconto_Enabled), 5, 0), true);
         edtBoletosValorJuros_Enabled = 0;
         AssignProp("", false, edtBoletosValorJuros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosValorJuros_Enabled), 5, 0), true);
         edtBoletosValorMulta_Enabled = 0;
         AssignProp("", false, edtBoletosValorMulta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosValorMulta_Enabled), 5, 0), true);
         edtBoletosSacadoNome_Enabled = 0;
         AssignProp("", false, edtBoletosSacadoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosSacadoNome_Enabled), 5, 0), true);
         edtBoletosSacadoDocumento_Enabled = 0;
         AssignProp("", false, edtBoletosSacadoDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosSacadoDocumento_Enabled), 5, 0), true);
         cmbBoletosSacadoTipoDocumento.Enabled = 0;
         AssignProp("", false, cmbBoletosSacadoTipoDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbBoletosSacadoTipoDocumento.Enabled), 5, 0), true);
         edtBoletosMensagemDeErro_Enabled = 0;
         AssignProp("", false, edtBoletosMensagemDeErro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosMensagemDeErro_Enabled), 5, 0), true);
         edtBoletosTentativasDeRegistro_Enabled = 0;
         AssignProp("", false, edtBoletosTentativasDeRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosTentativasDeRegistro_Enabled), 5, 0), true);
         edtBoletosCreatedAt_Enabled = 0;
         AssignProp("", false, edtBoletosCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosCreatedAt_Enabled), 5, 0), true);
         edtBoletosUpdatedAt_Enabled = 0;
         AssignProp("", false, edtBoletosUpdatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosUpdatedAt_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaNome_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaNome_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaConvenio_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaConvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaConvenio_Enabled), 5, 0), true);
         cmbCarteiraDeCobrancaStatus.Enabled = 0;
         AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCarteiraDeCobrancaStatus.Enabled), 5, 0), true);
         edtCarteiraDeCobrancaValorTotal_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaValorTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaValorTotal_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaValorRecebido_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaValorRecebido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaValorRecebido_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaTotalBoletos_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaTotalBoletos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaTotalBoletos_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaTotalBoletosRegistrados_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaTotalBoletosRegistrados_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaTotalBoletosExpirados_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaTotalBoletosExpirados_Enabled), 5, 0), true);
         edtCarteiraDeCobrancaTotalBoletosCancelados_Enabled = 0;
         AssignProp("", false, edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarteiraDeCobrancaTotalBoletosCancelados_Enabled), 5, 0), true);
         edtavCombocarteiradecobrancaid_Enabled = 0;
         AssignProp("", false, edtavCombocarteiradecobrancaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocarteiradecobrancaid_Enabled), 5, 0), true);
         edtavCombotituloid_Enabled = 0;
         AssignProp("", false, edtavCombotituloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotituloid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes37111( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues370( )
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
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BoletosId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Boleto");
         forbiddenHiddens.Add("BoletosId", context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_CarteiraDeCobrancaId", context.localUtil.Format( (decimal)(AV11Insert_CarteiraDeCobrancaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TituloId", context.localUtil.Format( (decimal)(AV12Insert_TituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("BoletosResgitroId", A1117BoletosResgitroId.ToString());
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("boleto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1077BoletosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1077BoletosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1099BoletosCreatedAt", context.localUtil.TToC( Z1099BoletosCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1100BoletosUpdatedAt", context.localUtil.TToC( Z1100BoletosUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1078BoletosNossoNumero", Z1078BoletosNossoNumero);
         GxWebStd.gx_hidden_field( context, "Z1079BoletosSeuNumero", Z1079BoletosSeuNumero);
         GxWebStd.gx_hidden_field( context, "Z1080BoletosNumero", Z1080BoletosNumero);
         GxWebStd.gx_hidden_field( context, "Z1081BoletosLinhaDigitavel", Z1081BoletosLinhaDigitavel);
         GxWebStd.gx_hidden_field( context, "Z1082BoletosCodigoDeBarras", Z1082BoletosCodigoDeBarras);
         GxWebStd.gx_hidden_field( context, "Z1083BoletosStatus", Z1083BoletosStatus);
         GxWebStd.gx_hidden_field( context, "Z1084BoletosDataEmissao", context.localUtil.DToC( Z1084BoletosDataEmissao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1085BoletosDataVencimento", context.localUtil.DToC( Z1085BoletosDataVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1086BoletosDataRegistro", context.localUtil.TToC( Z1086BoletosDataRegistro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1087BoletosDataPagamento", context.localUtil.DToC( Z1087BoletosDataPagamento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1088BoletosDataBaixa", context.localUtil.DToC( Z1088BoletosDataBaixa, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1089BoletosValorNominal", StringUtil.LTrim( StringUtil.NToC( Z1089BoletosValorNominal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1090BoletosValorPago", StringUtil.LTrim( StringUtil.NToC( Z1090BoletosValorPago, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1091BoletosValorDesconto", StringUtil.LTrim( StringUtil.NToC( Z1091BoletosValorDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1092BoletosValorJuros", StringUtil.LTrim( StringUtil.NToC( Z1092BoletosValorJuros, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1093BoletosValorMulta", StringUtil.LTrim( StringUtil.NToC( Z1093BoletosValorMulta, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1094BoletosSacadoNome", Z1094BoletosSacadoNome);
         GxWebStd.gx_hidden_field( context, "Z1095BoletosSacadoDocumento", Z1095BoletosSacadoDocumento);
         GxWebStd.gx_hidden_field( context, "Z1096BoletosSacadoTipoDocumento", Z1096BoletosSacadoTipoDocumento);
         GxWebStd.gx_hidden_field( context, "Z1098BoletosTentativasDeRegistro", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1098BoletosTentativasDeRegistro), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1117BoletosResgitroId", Z1117BoletosResgitroId.ToString());
         GxWebStd.gx_hidden_field( context, "Z1069CarteiraDeCobrancaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1069CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z261TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z261TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1069CarteiraDeCobrancaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N261TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCARTEIRADECOBRANCAID_DATA", AV14CarteiraDeCobrancaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCARTEIRADECOBRANCAID_DATA", AV14CarteiraDeCobrancaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTITULOID_DATA", AV20TituloId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTITULOID_DATA", AV20TituloId_Data);
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
         GxWebStd.gx_hidden_field( context, "vBOLETOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BoletosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBOLETOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BoletosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "BOLETOSRESGITROID", A1117BoletosResgitroId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Objectcall", StringUtil.RTrim( Combo_carteiradecobrancaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Cls", StringUtil.RTrim( Combo_carteiradecobrancaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Selectedvalue_set", StringUtil.RTrim( Combo_carteiradecobrancaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Selectedtext_set", StringUtil.RTrim( Combo_carteiradecobrancaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Enabled", StringUtil.BoolToStr( Combo_carteiradecobrancaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Datalistproc", StringUtil.RTrim( Combo_carteiradecobrancaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CARTEIRADECOBRANCAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_carteiradecobrancaid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Objectcall", StringUtil.RTrim( Combo_tituloid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Cls", StringUtil.RTrim( Combo_tituloid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Selectedvalue_set", StringUtil.RTrim( Combo_tituloid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Selectedtext_set", StringUtil.RTrim( Combo_tituloid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Enabled", StringUtil.BoolToStr( Combo_tituloid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Datalistproc", StringUtil.RTrim( Combo_tituloid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tituloid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "boleto"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BoletosId,9,0));
         return formatLink("boleto") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Boleto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Boleto" ;
      }

      protected void InitializeNonKey37111( )
      {
         A1069CarteiraDeCobrancaId = 0;
         n1069CarteiraDeCobrancaId = false;
         AssignAttri("", false, "A1069CarteiraDeCobrancaId", ((0==A1069CarteiraDeCobrancaId)&&IsIns( )||n1069CarteiraDeCobrancaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
         n1069CarteiraDeCobrancaId = ((0==A1069CarteiraDeCobrancaId) ? true : false);
         A261TituloId = 0;
         n261TituloId = false;
         AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
         n261TituloId = ((0==A261TituloId) ? true : false);
         A1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         n1099BoletosCreatedAt = false;
         AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n1099BoletosCreatedAt = ((DateTime.MinValue==A1099BoletosCreatedAt) ? true : false);
         A1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         n1100BoletosUpdatedAt = false;
         AssignAttri("", false, "A1100BoletosUpdatedAt", context.localUtil.TToC( A1100BoletosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         n1100BoletosUpdatedAt = ((DateTime.MinValue==A1100BoletosUpdatedAt) ? true : false);
         A1112CarteiraDeCobrancaValorRecebido = 0;
         AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( A1112CarteiraDeCobrancaValorRecebido, 18, 2));
         A1111CarteiraDeCobrancaValorTotal = 0;
         AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( A1111CarteiraDeCobrancaValorTotal, 18, 2));
         A1113CarteiraDeCobrancaTotalBoletos = 0;
         AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0));
         A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         A1078BoletosNossoNumero = "";
         n1078BoletosNossoNumero = false;
         AssignAttri("", false, "A1078BoletosNossoNumero", A1078BoletosNossoNumero);
         n1078BoletosNossoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1078BoletosNossoNumero)) ? true : false);
         A1079BoletosSeuNumero = "";
         n1079BoletosSeuNumero = false;
         AssignAttri("", false, "A1079BoletosSeuNumero", A1079BoletosSeuNumero);
         n1079BoletosSeuNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1079BoletosSeuNumero)) ? true : false);
         A1080BoletosNumero = "";
         n1080BoletosNumero = false;
         AssignAttri("", false, "A1080BoletosNumero", A1080BoletosNumero);
         n1080BoletosNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A1080BoletosNumero)) ? true : false);
         A1081BoletosLinhaDigitavel = "";
         n1081BoletosLinhaDigitavel = false;
         AssignAttri("", false, "A1081BoletosLinhaDigitavel", A1081BoletosLinhaDigitavel);
         n1081BoletosLinhaDigitavel = (String.IsNullOrEmpty(StringUtil.RTrim( A1081BoletosLinhaDigitavel)) ? true : false);
         A1082BoletosCodigoDeBarras = "";
         n1082BoletosCodigoDeBarras = false;
         AssignAttri("", false, "A1082BoletosCodigoDeBarras", A1082BoletosCodigoDeBarras);
         n1082BoletosCodigoDeBarras = (String.IsNullOrEmpty(StringUtil.RTrim( A1082BoletosCodigoDeBarras)) ? true : false);
         A1083BoletosStatus = "";
         n1083BoletosStatus = false;
         AssignAttri("", false, "A1083BoletosStatus", A1083BoletosStatus);
         n1083BoletosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1083BoletosStatus)) ? true : false);
         A1084BoletosDataEmissao = DateTime.MinValue;
         n1084BoletosDataEmissao = false;
         AssignAttri("", false, "A1084BoletosDataEmissao", context.localUtil.Format(A1084BoletosDataEmissao, "99/99/99"));
         n1084BoletosDataEmissao = ((DateTime.MinValue==A1084BoletosDataEmissao) ? true : false);
         A1085BoletosDataVencimento = DateTime.MinValue;
         n1085BoletosDataVencimento = false;
         AssignAttri("", false, "A1085BoletosDataVencimento", context.localUtil.Format(A1085BoletosDataVencimento, "99/99/99"));
         n1085BoletosDataVencimento = ((DateTime.MinValue==A1085BoletosDataVencimento) ? true : false);
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         n1086BoletosDataRegistro = false;
         AssignAttri("", false, "A1086BoletosDataRegistro", context.localUtil.TToC( A1086BoletosDataRegistro, 8, 5, 0, 3, "/", ":", " "));
         n1086BoletosDataRegistro = ((DateTime.MinValue==A1086BoletosDataRegistro) ? true : false);
         A1087BoletosDataPagamento = DateTime.MinValue;
         n1087BoletosDataPagamento = false;
         AssignAttri("", false, "A1087BoletosDataPagamento", context.localUtil.Format(A1087BoletosDataPagamento, "99/99/99"));
         n1087BoletosDataPagamento = ((DateTime.MinValue==A1087BoletosDataPagamento) ? true : false);
         A1088BoletosDataBaixa = DateTime.MinValue;
         n1088BoletosDataBaixa = false;
         AssignAttri("", false, "A1088BoletosDataBaixa", context.localUtil.Format(A1088BoletosDataBaixa, "99/99/99"));
         n1088BoletosDataBaixa = ((DateTime.MinValue==A1088BoletosDataBaixa) ? true : false);
         A1089BoletosValorNominal = 0;
         n1089BoletosValorNominal = false;
         AssignAttri("", false, "A1089BoletosValorNominal", ((Convert.ToDecimal(0)==A1089BoletosValorNominal)&&IsIns( )||n1089BoletosValorNominal ? "" : StringUtil.LTrim( StringUtil.NToC( A1089BoletosValorNominal, 18, 2, ".", ""))));
         n1089BoletosValorNominal = ((Convert.ToDecimal(0)==A1089BoletosValorNominal) ? true : false);
         A1090BoletosValorPago = 0;
         n1090BoletosValorPago = false;
         AssignAttri("", false, "A1090BoletosValorPago", ((Convert.ToDecimal(0)==A1090BoletosValorPago)&&IsIns( )||n1090BoletosValorPago ? "" : StringUtil.LTrim( StringUtil.NToC( A1090BoletosValorPago, 18, 2, ".", ""))));
         n1090BoletosValorPago = ((Convert.ToDecimal(0)==A1090BoletosValorPago) ? true : false);
         A1091BoletosValorDesconto = 0;
         n1091BoletosValorDesconto = false;
         AssignAttri("", false, "A1091BoletosValorDesconto", ((Convert.ToDecimal(0)==A1091BoletosValorDesconto)&&IsIns( )||n1091BoletosValorDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A1091BoletosValorDesconto, 18, 2, ".", ""))));
         n1091BoletosValorDesconto = ((Convert.ToDecimal(0)==A1091BoletosValorDesconto) ? true : false);
         A1092BoletosValorJuros = 0;
         n1092BoletosValorJuros = false;
         AssignAttri("", false, "A1092BoletosValorJuros", ((Convert.ToDecimal(0)==A1092BoletosValorJuros)&&IsIns( )||n1092BoletosValorJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A1092BoletosValorJuros, 18, 2, ".", ""))));
         n1092BoletosValorJuros = ((Convert.ToDecimal(0)==A1092BoletosValorJuros) ? true : false);
         A1093BoletosValorMulta = 0;
         n1093BoletosValorMulta = false;
         AssignAttri("", false, "A1093BoletosValorMulta", ((Convert.ToDecimal(0)==A1093BoletosValorMulta)&&IsIns( )||n1093BoletosValorMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A1093BoletosValorMulta, 18, 2, ".", ""))));
         n1093BoletosValorMulta = ((Convert.ToDecimal(0)==A1093BoletosValorMulta) ? true : false);
         A1094BoletosSacadoNome = "";
         n1094BoletosSacadoNome = false;
         AssignAttri("", false, "A1094BoletosSacadoNome", A1094BoletosSacadoNome);
         n1094BoletosSacadoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A1094BoletosSacadoNome)) ? true : false);
         A1095BoletosSacadoDocumento = "";
         n1095BoletosSacadoDocumento = false;
         AssignAttri("", false, "A1095BoletosSacadoDocumento", A1095BoletosSacadoDocumento);
         n1095BoletosSacadoDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1095BoletosSacadoDocumento)) ? true : false);
         A1096BoletosSacadoTipoDocumento = "";
         n1096BoletosSacadoTipoDocumento = false;
         AssignAttri("", false, "A1096BoletosSacadoTipoDocumento", A1096BoletosSacadoTipoDocumento);
         n1096BoletosSacadoTipoDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A1096BoletosSacadoTipoDocumento)) ? true : false);
         A1097BoletosMensagemDeErro = "";
         n1097BoletosMensagemDeErro = false;
         AssignAttri("", false, "A1097BoletosMensagemDeErro", A1097BoletosMensagemDeErro);
         n1097BoletosMensagemDeErro = (String.IsNullOrEmpty(StringUtil.RTrim( A1097BoletosMensagemDeErro)) ? true : false);
         A1098BoletosTentativasDeRegistro = 0;
         n1098BoletosTentativasDeRegistro = false;
         AssignAttri("", false, "A1098BoletosTentativasDeRegistro", ((0==A1098BoletosTentativasDeRegistro)&&IsIns( )||n1098BoletosTentativasDeRegistro ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098BoletosTentativasDeRegistro), 8, 0, ".", ""))));
         n1098BoletosTentativasDeRegistro = ((0==A1098BoletosTentativasDeRegistro) ? true : false);
         A1071CarteiraDeCobrancaNome = "";
         n1071CarteiraDeCobrancaNome = false;
         AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
         A1073CarteiraDeCobrancaConvenio = "";
         n1073CarteiraDeCobrancaConvenio = false;
         AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
         A1074CarteiraDeCobrancaStatus = false;
         n1074CarteiraDeCobrancaStatus = false;
         AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         A1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         AssignAttri("", false, "A1117BoletosResgitroId", A1117BoletosResgitroId.ToString());
         Z1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1078BoletosNossoNumero = "";
         Z1079BoletosSeuNumero = "";
         Z1080BoletosNumero = "";
         Z1081BoletosLinhaDigitavel = "";
         Z1082BoletosCodigoDeBarras = "";
         Z1083BoletosStatus = "";
         Z1084BoletosDataEmissao = DateTime.MinValue;
         Z1085BoletosDataVencimento = DateTime.MinValue;
         Z1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         Z1087BoletosDataPagamento = DateTime.MinValue;
         Z1088BoletosDataBaixa = DateTime.MinValue;
         Z1089BoletosValorNominal = 0;
         Z1090BoletosValorPago = 0;
         Z1091BoletosValorDesconto = 0;
         Z1092BoletosValorJuros = 0;
         Z1093BoletosValorMulta = 0;
         Z1094BoletosSacadoNome = "";
         Z1095BoletosSacadoDocumento = "";
         Z1096BoletosSacadoTipoDocumento = "";
         Z1098BoletosTentativasDeRegistro = 0;
         Z1117BoletosResgitroId = Guid.Empty;
         Z1069CarteiraDeCobrancaId = 0;
         Z261TituloId = 0;
      }

      protected void InitAll37111( )
      {
         A1077BoletosId = 0;
         n1077BoletosId = false;
         AssignAttri("", false, "A1077BoletosId", StringUtil.LTrimStr( (decimal)(A1077BoletosId), 9, 0));
         InitializeNonKey37111( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1099BoletosCreatedAt = i1099BoletosCreatedAt;
         n1099BoletosCreatedAt = false;
         AssignAttri("", false, "A1099BoletosCreatedAt", context.localUtil.TToC( A1099BoletosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1117BoletosResgitroId = i1117BoletosResgitroId;
         n1117BoletosResgitroId = false;
         AssignAttri("", false, "A1117BoletosResgitroId", A1117BoletosResgitroId.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101922479", true, true);
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
         context.AddJavascriptSource("boleto.js", "?202561019224710", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtBoletosId_Internalname = "BOLETOSID";
         lblTextblockcarteiradecobrancaid_Internalname = "TEXTBLOCKCARTEIRADECOBRANCAID";
         Combo_carteiradecobrancaid_Internalname = "COMBO_CARTEIRADECOBRANCAID";
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID";
         divTablesplittedcarteiradecobrancaid_Internalname = "TABLESPLITTEDCARTEIRADECOBRANCAID";
         lblTextblocktituloid_Internalname = "TEXTBLOCKTITULOID";
         Combo_tituloid_Internalname = "COMBO_TITULOID";
         edtTituloId_Internalname = "TITULOID";
         divTablesplittedtituloid_Internalname = "TABLESPLITTEDTITULOID";
         edtBoletosNossoNumero_Internalname = "BOLETOSNOSSONUMERO";
         edtBoletosSeuNumero_Internalname = "BOLETOSSEUNUMERO";
         edtBoletosNumero_Internalname = "BOLETOSNUMERO";
         edtBoletosLinhaDigitavel_Internalname = "BOLETOSLINHADIGITAVEL";
         edtBoletosCodigoDeBarras_Internalname = "BOLETOSCODIGODEBARRAS";
         cmbBoletosStatus_Internalname = "BOLETOSSTATUS";
         edtBoletosDataEmissao_Internalname = "BOLETOSDATAEMISSAO";
         edtBoletosDataVencimento_Internalname = "BOLETOSDATAVENCIMENTO";
         edtBoletosDataRegistro_Internalname = "BOLETOSDATAREGISTRO";
         edtBoletosDataPagamento_Internalname = "BOLETOSDATAPAGAMENTO";
         edtBoletosDataBaixa_Internalname = "BOLETOSDATABAIXA";
         edtBoletosValorNominal_Internalname = "BOLETOSVALORNOMINAL";
         edtBoletosValorPago_Internalname = "BOLETOSVALORPAGO";
         edtBoletosValorDesconto_Internalname = "BOLETOSVALORDESCONTO";
         edtBoletosValorJuros_Internalname = "BOLETOSVALORJUROS";
         edtBoletosValorMulta_Internalname = "BOLETOSVALORMULTA";
         edtBoletosSacadoNome_Internalname = "BOLETOSSACADONOME";
         edtBoletosSacadoDocumento_Internalname = "BOLETOSSACADODOCUMENTO";
         cmbBoletosSacadoTipoDocumento_Internalname = "BOLETOSSACADOTIPODOCUMENTO";
         edtBoletosMensagemDeErro_Internalname = "BOLETOSMENSAGEMDEERRO";
         edtBoletosTentativasDeRegistro_Internalname = "BOLETOSTENTATIVASDEREGISTRO";
         edtBoletosCreatedAt_Internalname = "BOLETOSCREATEDAT";
         edtBoletosUpdatedAt_Internalname = "BOLETOSUPDATEDAT";
         edtCarteiraDeCobrancaNome_Internalname = "CARTEIRADECOBRANCANOME";
         edtCarteiraDeCobrancaConvenio_Internalname = "CARTEIRADECOBRANCACONVENIO";
         cmbCarteiraDeCobrancaStatus_Internalname = "CARTEIRADECOBRANCASTATUS";
         edtCarteiraDeCobrancaValorTotal_Internalname = "CARTEIRADECOBRANCAVALORTOTAL";
         edtCarteiraDeCobrancaValorRecebido_Internalname = "CARTEIRADECOBRANCAVALORRECEBIDO";
         edtCarteiraDeCobrancaTotalBoletos_Internalname = "CARTEIRADECOBRANCATOTALBOLETOS";
         edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname = "CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS";
         edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname = "CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS";
         edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname = "CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocarteiradecobrancaid_Internalname = "vCOMBOCARTEIRADECOBRANCAID";
         divSectionattribute_carteiradecobrancaid_Internalname = "SECTIONATTRIBUTE_CARTEIRADECOBRANCAID";
         edtavCombotituloid_Internalname = "vCOMBOTITULOID";
         divSectionattribute_tituloid_Internalname = "SECTIONATTRIBUTE_TITULOID";
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
         Form.Caption = "Boleto";
         edtavCombotituloid_Jsonclick = "";
         edtavCombotituloid_Enabled = 0;
         edtavCombotituloid_Visible = 1;
         edtavCombocarteiradecobrancaid_Jsonclick = "";
         edtavCombocarteiradecobrancaid_Enabled = 0;
         edtavCombocarteiradecobrancaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCarteiraDeCobrancaTotalBoletosCancelados_Jsonclick = "";
         edtCarteiraDeCobrancaTotalBoletosCancelados_Enabled = 0;
         edtCarteiraDeCobrancaTotalBoletosExpirados_Jsonclick = "";
         edtCarteiraDeCobrancaTotalBoletosExpirados_Enabled = 0;
         edtCarteiraDeCobrancaTotalBoletosRegistrados_Jsonclick = "";
         edtCarteiraDeCobrancaTotalBoletosRegistrados_Enabled = 0;
         edtCarteiraDeCobrancaTotalBoletos_Jsonclick = "";
         edtCarteiraDeCobrancaTotalBoletos_Enabled = 0;
         edtCarteiraDeCobrancaValorRecebido_Jsonclick = "";
         edtCarteiraDeCobrancaValorRecebido_Enabled = 0;
         edtCarteiraDeCobrancaValorTotal_Jsonclick = "";
         edtCarteiraDeCobrancaValorTotal_Enabled = 0;
         cmbCarteiraDeCobrancaStatus_Jsonclick = "";
         cmbCarteiraDeCobrancaStatus.Enabled = 0;
         edtCarteiraDeCobrancaConvenio_Jsonclick = "";
         edtCarteiraDeCobrancaConvenio_Enabled = 0;
         edtCarteiraDeCobrancaNome_Jsonclick = "";
         edtCarteiraDeCobrancaNome_Enabled = 0;
         edtBoletosUpdatedAt_Jsonclick = "";
         edtBoletosUpdatedAt_Enabled = 1;
         edtBoletosCreatedAt_Jsonclick = "";
         edtBoletosCreatedAt_Enabled = 1;
         edtBoletosTentativasDeRegistro_Jsonclick = "";
         edtBoletosTentativasDeRegistro_Enabled = 1;
         edtBoletosMensagemDeErro_Enabled = 1;
         cmbBoletosSacadoTipoDocumento_Jsonclick = "";
         cmbBoletosSacadoTipoDocumento.Enabled = 1;
         edtBoletosSacadoDocumento_Jsonclick = "";
         edtBoletosSacadoDocumento_Enabled = 1;
         edtBoletosSacadoNome_Jsonclick = "";
         edtBoletosSacadoNome_Enabled = 1;
         edtBoletosValorMulta_Jsonclick = "";
         edtBoletosValorMulta_Enabled = 1;
         edtBoletosValorJuros_Jsonclick = "";
         edtBoletosValorJuros_Enabled = 1;
         edtBoletosValorDesconto_Jsonclick = "";
         edtBoletosValorDesconto_Enabled = 1;
         edtBoletosValorPago_Jsonclick = "";
         edtBoletosValorPago_Enabled = 1;
         edtBoletosValorNominal_Jsonclick = "";
         edtBoletosValorNominal_Enabled = 1;
         edtBoletosDataBaixa_Jsonclick = "";
         edtBoletosDataBaixa_Enabled = 1;
         edtBoletosDataPagamento_Jsonclick = "";
         edtBoletosDataPagamento_Enabled = 1;
         edtBoletosDataRegistro_Jsonclick = "";
         edtBoletosDataRegistro_Enabled = 1;
         edtBoletosDataVencimento_Jsonclick = "";
         edtBoletosDataVencimento_Enabled = 1;
         edtBoletosDataEmissao_Jsonclick = "";
         edtBoletosDataEmissao_Enabled = 1;
         cmbBoletosStatus_Jsonclick = "";
         cmbBoletosStatus.Enabled = 1;
         edtBoletosCodigoDeBarras_Jsonclick = "";
         edtBoletosCodigoDeBarras_Enabled = 1;
         edtBoletosLinhaDigitavel_Jsonclick = "";
         edtBoletosLinhaDigitavel_Enabled = 1;
         edtBoletosNumero_Jsonclick = "";
         edtBoletosNumero_Enabled = 1;
         edtBoletosSeuNumero_Jsonclick = "";
         edtBoletosSeuNumero_Enabled = 1;
         edtBoletosNossoNumero_Jsonclick = "";
         edtBoletosNossoNumero_Enabled = 1;
         edtTituloId_Jsonclick = "";
         edtTituloId_Enabled = 1;
         edtTituloId_Visible = 1;
         Combo_tituloid_Datalistprocparametersprefix = " \"ComboName\": \"TituloId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BoletosId\": 0";
         Combo_tituloid_Datalistproc = "BoletoLoadDVCombo";
         Combo_tituloid_Cls = "ExtendedCombo AttributeFL";
         Combo_tituloid_Caption = "";
         Combo_tituloid_Enabled = Convert.ToBoolean( -1);
         edtCarteiraDeCobrancaId_Jsonclick = "";
         edtCarteiraDeCobrancaId_Enabled = 1;
         edtCarteiraDeCobrancaId_Visible = 1;
         Combo_carteiradecobrancaid_Datalistprocparametersprefix = " \"ComboName\": \"CarteiraDeCobrancaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BoletosId\": 0";
         Combo_carteiradecobrancaid_Datalistproc = "BoletoLoadDVCombo";
         Combo_carteiradecobrancaid_Cls = "ExtendedCombo AttributeFL";
         Combo_carteiradecobrancaid_Caption = "";
         Combo_carteiradecobrancaid_Enabled = Convert.ToBoolean( -1);
         edtBoletosId_Jsonclick = "";
         edtBoletosId_Enabled = 0;
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
         cmbBoletosStatus.Name = "BOLETOSSTATUS";
         cmbBoletosStatus.WebTags = "";
         cmbBoletosStatus.addItem("RASCUNHO", "Rascunho", 0);
         cmbBoletosStatus.addItem("REGISTRADO", "Registrado", 0);
         cmbBoletosStatus.addItem("LIQUIDADO", "Liquidado", 0);
         cmbBoletosStatus.addItem("BAIXADO", "Baixado", 0);
         cmbBoletosStatus.addItem("VENCIDO", "Vencido", 0);
         cmbBoletosStatus.addItem("ERRO", "Erro", 0);
         if ( cmbBoletosStatus.ItemCount > 0 )
         {
            A1083BoletosStatus = cmbBoletosStatus.getValidValue(A1083BoletosStatus);
            n1083BoletosStatus = false;
            AssignAttri("", false, "A1083BoletosStatus", A1083BoletosStatus);
         }
         cmbBoletosSacadoTipoDocumento.Name = "BOLETOSSACADOTIPODOCUMENTO";
         cmbBoletosSacadoTipoDocumento.WebTags = "";
         cmbBoletosSacadoTipoDocumento.addItem("CPF", "CPF", 0);
         cmbBoletosSacadoTipoDocumento.addItem("CNPJ", "CNPJ", 0);
         if ( cmbBoletosSacadoTipoDocumento.ItemCount > 0 )
         {
            A1096BoletosSacadoTipoDocumento = cmbBoletosSacadoTipoDocumento.getValidValue(A1096BoletosSacadoTipoDocumento);
            n1096BoletosSacadoTipoDocumento = false;
            AssignAttri("", false, "A1096BoletosSacadoTipoDocumento", A1096BoletosSacadoTipoDocumento);
         }
         cmbCarteiraDeCobrancaStatus.Name = "CARTEIRADECOBRANCASTATUS";
         cmbCarteiraDeCobrancaStatus.WebTags = "";
         cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
         {
            A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.getValidValue(StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
            n1074CarteiraDeCobrancaStatus = false;
            AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
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

      public void Valid_Carteiradecobrancaid( )
      {
         n1071CarteiraDeCobrancaNome = false;
         n1073CarteiraDeCobrancaConvenio = false;
         n1074CarteiraDeCobrancaStatus = false;
         A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.CurrentValue);
         n1074CarteiraDeCobrancaStatus = false;
         cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         /* Using cursor T003736 */
         pr_default.execute(22, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A1069CarteiraDeCobrancaId) ) )
            {
               GX_msglist.addItem("Não existe 'CarteiraDeCobranca'.", "ForeignKeyNotFound", 1, "CARTEIRADECOBRANCAID");
               AnyError = 1;
               GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
            }
         }
         A1071CarteiraDeCobrancaNome = T003736_A1071CarteiraDeCobrancaNome[0];
         n1071CarteiraDeCobrancaNome = T003736_n1071CarteiraDeCobrancaNome[0];
         A1073CarteiraDeCobrancaConvenio = T003736_A1073CarteiraDeCobrancaConvenio[0];
         n1073CarteiraDeCobrancaConvenio = T003736_n1073CarteiraDeCobrancaConvenio[0];
         A1074CarteiraDeCobrancaStatus = T003736_A1074CarteiraDeCobrancaStatus[0];
         n1074CarteiraDeCobrancaStatus = T003736_n1074CarteiraDeCobrancaStatus[0];
         cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         pr_default.close(22);
         /* Using cursor T003738 */
         pr_default.execute(23, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A1112CarteiraDeCobrancaValorRecebido = T003738_A1112CarteiraDeCobrancaValorRecebido[0];
            A1111CarteiraDeCobrancaValorTotal = T003738_A1111CarteiraDeCobrancaValorTotal[0];
            A1113CarteiraDeCobrancaTotalBoletos = T003738_A1113CarteiraDeCobrancaTotalBoletos[0];
         }
         else
         {
            A1112CarteiraDeCobrancaValorRecebido = 0;
            A1111CarteiraDeCobrancaValorTotal = 0;
            A1113CarteiraDeCobrancaTotalBoletos = 0;
         }
         pr_default.close(23);
         if ( ( A1112CarteiraDeCobrancaValorRecebido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CARTEIRADECOBRANCAID");
            AnyError = 1;
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
         }
         if ( ( A1111CarteiraDeCobrancaValorTotal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CARTEIRADECOBRANCAID");
            AnyError = 1;
            GX_FocusControl = edtCarteiraDeCobrancaId_Internalname;
         }
         /* Using cursor T003740 */
         pr_default.execute(24, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = T003740_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = T003740_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         }
         pr_default.close(24);
         /* Using cursor T003742 */
         pr_default.execute(25, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = T003742_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = T003742_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         }
         pr_default.close(25);
         /* Using cursor T003744 */
         pr_default.execute(26, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = T003744_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = T003744_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         }
         pr_default.close(26);
         dynload_actions( ) ;
         if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
         {
            A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.getValidValue(StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
            n1074CarteiraDeCobrancaStatus = false;
            cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1071CarteiraDeCobrancaNome", A1071CarteiraDeCobrancaNome);
         AssignAttri("", false, "A1073CarteiraDeCobrancaConvenio", A1073CarteiraDeCobrancaConvenio);
         AssignAttri("", false, "A1074CarteiraDeCobrancaStatus", A1074CarteiraDeCobrancaStatus);
         cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
         AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Values", cmbCarteiraDeCobrancaStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A1112CarteiraDeCobrancaValorRecebido", StringUtil.LTrim( StringUtil.NToC( A1112CarteiraDeCobrancaValorRecebido, 18, 2, ".", "")));
         AssignAttri("", false, "A1111CarteiraDeCobrancaValorTotal", StringUtil.LTrim( StringUtil.NToC( A1111CarteiraDeCobrancaValorTotal, 18, 2, ".", "")));
         AssignAttri("", false, "A1113CarteiraDeCobrancaTotalBoletos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1113CarteiraDeCobrancaTotalBoletos), 8, 0, ".", "")));
         AssignAttri("", false, "A1114CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1114CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ".", "")));
         AssignAttri("", false, "A1115CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1115CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ".", "")));
         AssignAttri("", false, "A1116CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1116CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ".", "")));
      }

      public void Valid_Tituloid( )
      {
         /* Using cursor T003747 */
         pr_default.execute(29, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
               GX_FocusControl = edtTituloId_Internalname;
            }
         }
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7BoletosId","fld":"vBOLETOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7BoletosId","fld":"vBOLETOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1077BoletosId","fld":"BOLETOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_CarteiraDeCobrancaId","fld":"vINSERT_CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_TituloId","fld":"vINSERT_TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A1117BoletosResgitroId","fld":"BOLETOSRESGITROID","type":"guid"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12372","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A1069CarteiraDeCobrancaId","fld":"CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","nullAv":"n1069CarteiraDeCobrancaId","type":"int"}]}""");
         setEventMetadata("VALID_BOLETOSID","""{"handler":"Valid_Boletosid","iparms":[]}""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAID","""{"handler":"Valid_Carteiradecobrancaid","iparms":[{"av":"A1069CarteiraDeCobrancaId","fld":"CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","nullAv":"n1069CarteiraDeCobrancaId","type":"int"},{"av":"A1112CarteiraDeCobrancaValorRecebido","fld":"CARTEIRADECOBRANCAVALORRECEBIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1111CarteiraDeCobrancaValorTotal","fld":"CARTEIRADECOBRANCAVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1071CarteiraDeCobrancaNome","fld":"CARTEIRADECOBRANCANOME","type":"svchar"},{"av":"A1073CarteiraDeCobrancaConvenio","fld":"CARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"cmbCarteiraDeCobrancaStatus"},{"av":"A1074CarteiraDeCobrancaStatus","fld":"CARTEIRADECOBRANCASTATUS","type":"boolean"},{"av":"A1113CarteiraDeCobrancaTotalBoletos","fld":"CARTEIRADECOBRANCATOTALBOLETOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1114CarteiraDeCobrancaTotalBoletosRegistrados","fld":"CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1115CarteiraDeCobrancaTotalBoletosExpirados","fld":"CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1116CarteiraDeCobrancaTotalBoletosCancelados","fld":"CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS","pic":"ZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAID",""","oparms":[{"av":"A1071CarteiraDeCobrancaNome","fld":"CARTEIRADECOBRANCANOME","type":"svchar"},{"av":"A1073CarteiraDeCobrancaConvenio","fld":"CARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"cmbCarteiraDeCobrancaStatus"},{"av":"A1074CarteiraDeCobrancaStatus","fld":"CARTEIRADECOBRANCASTATUS","type":"boolean"},{"av":"A1112CarteiraDeCobrancaValorRecebido","fld":"CARTEIRADECOBRANCAVALORRECEBIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1111CarteiraDeCobrancaValorTotal","fld":"CARTEIRADECOBRANCAVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1113CarteiraDeCobrancaTotalBoletos","fld":"CARTEIRADECOBRANCATOTALBOLETOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1114CarteiraDeCobrancaTotalBoletosRegistrados","fld":"CARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1115CarteiraDeCobrancaTotalBoletosExpirados","fld":"CARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"A1116CarteiraDeCobrancaTotalBoletosCancelados","fld":"CARTEIRADECOBRANCATOTALBOLETOSCANCELADOS","pic":"ZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","nullAv":"n261TituloId","type":"int"}]}""");
         setEventMetadata("VALID_BOLETOSSTATUS","""{"handler":"Valid_Boletosstatus","iparms":[]}""");
         setEventMetadata("VALID_BOLETOSVALORNOMINAL","""{"handler":"Valid_Boletosvalornominal","iparms":[]}""");
         setEventMetadata("VALID_BOLETOSVALORPAGO","""{"handler":"Valid_Boletosvalorpago","iparms":[]}""");
         setEventMetadata("VALID_BOLETOSVALORDESCONTO","""{"handler":"Valid_Boletosvalordesconto","iparms":[]}""");
         setEventMetadata("VALID_BOLETOSVALORJUROS","""{"handler":"Valid_Boletosvalorjuros","iparms":[]}""");
         setEventMetadata("VALID_BOLETOSVALORMULTA","""{"handler":"Valid_Boletosvalormulta","iparms":[]}""");
         setEventMetadata("VALID_BOLETOSSACADOTIPODOCUMENTO","""{"handler":"Valid_Boletossacadotipodocumento","iparms":[]}""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAVALORTOTAL","""{"handler":"Valid_Carteiradecobrancavalortotal","iparms":[]}""");
         setEventMetadata("VALID_CARTEIRADECOBRANCAVALORRECEBIDO","""{"handler":"Valid_Carteiradecobrancavalorrecebido","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOCARTEIRADECOBRANCAID","""{"handler":"Validv_Combocarteiradecobrancaid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOTITULOID","""{"handler":"Validv_Combotituloid","iparms":[]}""");
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
         pr_default.close(22);
         pr_default.close(29);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1078BoletosNossoNumero = "";
         Z1079BoletosSeuNumero = "";
         Z1080BoletosNumero = "";
         Z1081BoletosLinhaDigitavel = "";
         Z1082BoletosCodigoDeBarras = "";
         Z1083BoletosStatus = "";
         Z1084BoletosDataEmissao = DateTime.MinValue;
         Z1085BoletosDataVencimento = DateTime.MinValue;
         Z1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         Z1087BoletosDataPagamento = DateTime.MinValue;
         Z1088BoletosDataBaixa = DateTime.MinValue;
         Z1094BoletosSacadoNome = "";
         Z1095BoletosSacadoDocumento = "";
         Z1096BoletosSacadoTipoDocumento = "";
         Z1117BoletosResgitroId = Guid.Empty;
         Combo_tituloid_Selectedvalue_get = "";
         Combo_carteiradecobrancaid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1083BoletosStatus = "";
         A1096BoletosSacadoTipoDocumento = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockcarteiradecobrancaid_Jsonclick = "";
         ucCombo_carteiradecobrancaid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14CarteiraDeCobrancaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocktituloid_Jsonclick = "";
         ucCombo_tituloid = new GXUserControl();
         AV20TituloId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1078BoletosNossoNumero = "";
         A1079BoletosSeuNumero = "";
         A1080BoletosNumero = "";
         A1081BoletosLinhaDigitavel = "";
         A1082BoletosCodigoDeBarras = "";
         A1084BoletosDataEmissao = DateTime.MinValue;
         A1085BoletosDataVencimento = DateTime.MinValue;
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         A1087BoletosDataPagamento = DateTime.MinValue;
         A1088BoletosDataBaixa = DateTime.MinValue;
         A1094BoletosSacadoNome = "";
         A1095BoletosSacadoDocumento = "";
         A1097BoletosMensagemDeErro = "";
         A1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         A1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         A1071CarteiraDeCobrancaNome = "";
         A1073CarteiraDeCobrancaConvenio = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1117BoletosResgitroId = Guid.Empty;
         AV22Pgmname = "";
         Combo_carteiradecobrancaid_Objectcall = "";
         Combo_carteiradecobrancaid_Class = "";
         Combo_carteiradecobrancaid_Icontype = "";
         Combo_carteiradecobrancaid_Icon = "";
         Combo_carteiradecobrancaid_Tooltip = "";
         Combo_carteiradecobrancaid_Selectedvalue_set = "";
         Combo_carteiradecobrancaid_Selectedtext_set = "";
         Combo_carteiradecobrancaid_Selectedtext_get = "";
         Combo_carteiradecobrancaid_Gamoauthtoken = "";
         Combo_carteiradecobrancaid_Ddointernalname = "";
         Combo_carteiradecobrancaid_Titlecontrolalign = "";
         Combo_carteiradecobrancaid_Dropdownoptionstype = "";
         Combo_carteiradecobrancaid_Titlecontrolidtoreplace = "";
         Combo_carteiradecobrancaid_Datalisttype = "";
         Combo_carteiradecobrancaid_Datalistfixedvalues = "";
         Combo_carteiradecobrancaid_Remoteservicesparameters = "";
         Combo_carteiradecobrancaid_Htmltemplate = "";
         Combo_carteiradecobrancaid_Multiplevaluestype = "";
         Combo_carteiradecobrancaid_Loadingdata = "";
         Combo_carteiradecobrancaid_Noresultsfound = "";
         Combo_carteiradecobrancaid_Emptyitemtext = "";
         Combo_carteiradecobrancaid_Onlyselectedvalues = "";
         Combo_carteiradecobrancaid_Selectalltext = "";
         Combo_carteiradecobrancaid_Multiplevaluesseparator = "";
         Combo_carteiradecobrancaid_Addnewoptiontext = "";
         Combo_tituloid_Objectcall = "";
         Combo_tituloid_Class = "";
         Combo_tituloid_Icontype = "";
         Combo_tituloid_Icon = "";
         Combo_tituloid_Tooltip = "";
         Combo_tituloid_Selectedvalue_set = "";
         Combo_tituloid_Selectedtext_set = "";
         Combo_tituloid_Selectedtext_get = "";
         Combo_tituloid_Gamoauthtoken = "";
         Combo_tituloid_Ddointernalname = "";
         Combo_tituloid_Titlecontrolalign = "";
         Combo_tituloid_Dropdownoptionstype = "";
         Combo_tituloid_Titlecontrolidtoreplace = "";
         Combo_tituloid_Datalisttype = "";
         Combo_tituloid_Datalistfixedvalues = "";
         Combo_tituloid_Remoteservicesparameters = "";
         Combo_tituloid_Htmltemplate = "";
         Combo_tituloid_Multiplevaluestype = "";
         Combo_tituloid_Loadingdata = "";
         Combo_tituloid_Noresultsfound = "";
         Combo_tituloid_Emptyitemtext = "";
         Combo_tituloid_Onlyselectedvalues = "";
         Combo_tituloid_Selectalltext = "";
         Combo_tituloid_Multiplevaluesseparator = "";
         Combo_tituloid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode111 = "";
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
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXEncryptionTmp = "";
         GXt_char2 = "";
         Z1097BoletosMensagemDeErro = "";
         Z1071CarteiraDeCobrancaNome = "";
         Z1073CarteiraDeCobrancaConvenio = "";
         T00374_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T00374_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T00374_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T00374_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T00374_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T00374_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T00377_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T00377_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T00377_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003711_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003711_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003713_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003713_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003718_A1077BoletosId = new int[1] ;
         T003718_n1077BoletosId = new bool[] {false} ;
         T003718_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T003718_n1099BoletosCreatedAt = new bool[] {false} ;
         T003718_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T003718_n1100BoletosUpdatedAt = new bool[] {false} ;
         T003718_A1078BoletosNossoNumero = new string[] {""} ;
         T003718_n1078BoletosNossoNumero = new bool[] {false} ;
         T003718_A1079BoletosSeuNumero = new string[] {""} ;
         T003718_n1079BoletosSeuNumero = new bool[] {false} ;
         T003718_A1080BoletosNumero = new string[] {""} ;
         T003718_n1080BoletosNumero = new bool[] {false} ;
         T003718_A1081BoletosLinhaDigitavel = new string[] {""} ;
         T003718_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         T003718_A1082BoletosCodigoDeBarras = new string[] {""} ;
         T003718_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         T003718_A1083BoletosStatus = new string[] {""} ;
         T003718_n1083BoletosStatus = new bool[] {false} ;
         T003718_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T003718_n1084BoletosDataEmissao = new bool[] {false} ;
         T003718_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         T003718_n1085BoletosDataVencimento = new bool[] {false} ;
         T003718_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         T003718_n1086BoletosDataRegistro = new bool[] {false} ;
         T003718_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         T003718_n1087BoletosDataPagamento = new bool[] {false} ;
         T003718_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         T003718_n1088BoletosDataBaixa = new bool[] {false} ;
         T003718_A1089BoletosValorNominal = new decimal[1] ;
         T003718_n1089BoletosValorNominal = new bool[] {false} ;
         T003718_A1090BoletosValorPago = new decimal[1] ;
         T003718_n1090BoletosValorPago = new bool[] {false} ;
         T003718_A1091BoletosValorDesconto = new decimal[1] ;
         T003718_n1091BoletosValorDesconto = new bool[] {false} ;
         T003718_A1092BoletosValorJuros = new decimal[1] ;
         T003718_n1092BoletosValorJuros = new bool[] {false} ;
         T003718_A1093BoletosValorMulta = new decimal[1] ;
         T003718_n1093BoletosValorMulta = new bool[] {false} ;
         T003718_A1094BoletosSacadoNome = new string[] {""} ;
         T003718_n1094BoletosSacadoNome = new bool[] {false} ;
         T003718_A1095BoletosSacadoDocumento = new string[] {""} ;
         T003718_n1095BoletosSacadoDocumento = new bool[] {false} ;
         T003718_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         T003718_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         T003718_A1097BoletosMensagemDeErro = new string[] {""} ;
         T003718_n1097BoletosMensagemDeErro = new bool[] {false} ;
         T003718_A1098BoletosTentativasDeRegistro = new int[1] ;
         T003718_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         T003718_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         T003718_n1117BoletosResgitroId = new bool[] {false} ;
         T003718_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T003718_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T003718_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T003718_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T003718_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003718_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003718_A1069CarteiraDeCobrancaId = new int[1] ;
         T003718_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T003718_A261TituloId = new int[1] ;
         T003718_n261TituloId = new bool[] {false} ;
         T003718_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T003718_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T003718_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003718_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003718_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003718_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003718_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T00375_A261TituloId = new int[1] ;
         T00375_n261TituloId = new bool[] {false} ;
         T003719_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T003719_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T003719_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T003719_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T003719_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003719_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003721_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T003721_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T003721_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T003723_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T003723_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003725_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003725_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003727_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003727_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003728_A261TituloId = new int[1] ;
         T003728_n261TituloId = new bool[] {false} ;
         T003729_A1077BoletosId = new int[1] ;
         T003729_n1077BoletosId = new bool[] {false} ;
         T00373_A1077BoletosId = new int[1] ;
         T00373_n1077BoletosId = new bool[] {false} ;
         T00373_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00373_n1099BoletosCreatedAt = new bool[] {false} ;
         T00373_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00373_n1100BoletosUpdatedAt = new bool[] {false} ;
         T00373_A1078BoletosNossoNumero = new string[] {""} ;
         T00373_n1078BoletosNossoNumero = new bool[] {false} ;
         T00373_A1079BoletosSeuNumero = new string[] {""} ;
         T00373_n1079BoletosSeuNumero = new bool[] {false} ;
         T00373_A1080BoletosNumero = new string[] {""} ;
         T00373_n1080BoletosNumero = new bool[] {false} ;
         T00373_A1081BoletosLinhaDigitavel = new string[] {""} ;
         T00373_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         T00373_A1082BoletosCodigoDeBarras = new string[] {""} ;
         T00373_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         T00373_A1083BoletosStatus = new string[] {""} ;
         T00373_n1083BoletosStatus = new bool[] {false} ;
         T00373_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T00373_n1084BoletosDataEmissao = new bool[] {false} ;
         T00373_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         T00373_n1085BoletosDataVencimento = new bool[] {false} ;
         T00373_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         T00373_n1086BoletosDataRegistro = new bool[] {false} ;
         T00373_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         T00373_n1087BoletosDataPagamento = new bool[] {false} ;
         T00373_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         T00373_n1088BoletosDataBaixa = new bool[] {false} ;
         T00373_A1089BoletosValorNominal = new decimal[1] ;
         T00373_n1089BoletosValorNominal = new bool[] {false} ;
         T00373_A1090BoletosValorPago = new decimal[1] ;
         T00373_n1090BoletosValorPago = new bool[] {false} ;
         T00373_A1091BoletosValorDesconto = new decimal[1] ;
         T00373_n1091BoletosValorDesconto = new bool[] {false} ;
         T00373_A1092BoletosValorJuros = new decimal[1] ;
         T00373_n1092BoletosValorJuros = new bool[] {false} ;
         T00373_A1093BoletosValorMulta = new decimal[1] ;
         T00373_n1093BoletosValorMulta = new bool[] {false} ;
         T00373_A1094BoletosSacadoNome = new string[] {""} ;
         T00373_n1094BoletosSacadoNome = new bool[] {false} ;
         T00373_A1095BoletosSacadoDocumento = new string[] {""} ;
         T00373_n1095BoletosSacadoDocumento = new bool[] {false} ;
         T00373_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         T00373_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         T00373_A1097BoletosMensagemDeErro = new string[] {""} ;
         T00373_n1097BoletosMensagemDeErro = new bool[] {false} ;
         T00373_A1098BoletosTentativasDeRegistro = new int[1] ;
         T00373_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         T00373_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         T00373_n1117BoletosResgitroId = new bool[] {false} ;
         T00373_A1069CarteiraDeCobrancaId = new int[1] ;
         T00373_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T00373_A261TituloId = new int[1] ;
         T00373_n261TituloId = new bool[] {false} ;
         T003730_A1077BoletosId = new int[1] ;
         T003730_n1077BoletosId = new bool[] {false} ;
         T003731_A1077BoletosId = new int[1] ;
         T003731_n1077BoletosId = new bool[] {false} ;
         T00372_A1077BoletosId = new int[1] ;
         T00372_n1077BoletosId = new bool[] {false} ;
         T00372_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00372_n1099BoletosCreatedAt = new bool[] {false} ;
         T00372_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00372_n1100BoletosUpdatedAt = new bool[] {false} ;
         T00372_A1078BoletosNossoNumero = new string[] {""} ;
         T00372_n1078BoletosNossoNumero = new bool[] {false} ;
         T00372_A1079BoletosSeuNumero = new string[] {""} ;
         T00372_n1079BoletosSeuNumero = new bool[] {false} ;
         T00372_A1080BoletosNumero = new string[] {""} ;
         T00372_n1080BoletosNumero = new bool[] {false} ;
         T00372_A1081BoletosLinhaDigitavel = new string[] {""} ;
         T00372_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         T00372_A1082BoletosCodigoDeBarras = new string[] {""} ;
         T00372_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         T00372_A1083BoletosStatus = new string[] {""} ;
         T00372_n1083BoletosStatus = new bool[] {false} ;
         T00372_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T00372_n1084BoletosDataEmissao = new bool[] {false} ;
         T00372_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         T00372_n1085BoletosDataVencimento = new bool[] {false} ;
         T00372_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         T00372_n1086BoletosDataRegistro = new bool[] {false} ;
         T00372_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         T00372_n1087BoletosDataPagamento = new bool[] {false} ;
         T00372_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         T00372_n1088BoletosDataBaixa = new bool[] {false} ;
         T00372_A1089BoletosValorNominal = new decimal[1] ;
         T00372_n1089BoletosValorNominal = new bool[] {false} ;
         T00372_A1090BoletosValorPago = new decimal[1] ;
         T00372_n1090BoletosValorPago = new bool[] {false} ;
         T00372_A1091BoletosValorDesconto = new decimal[1] ;
         T00372_n1091BoletosValorDesconto = new bool[] {false} ;
         T00372_A1092BoletosValorJuros = new decimal[1] ;
         T00372_n1092BoletosValorJuros = new bool[] {false} ;
         T00372_A1093BoletosValorMulta = new decimal[1] ;
         T00372_n1093BoletosValorMulta = new bool[] {false} ;
         T00372_A1094BoletosSacadoNome = new string[] {""} ;
         T00372_n1094BoletosSacadoNome = new bool[] {false} ;
         T00372_A1095BoletosSacadoDocumento = new string[] {""} ;
         T00372_n1095BoletosSacadoDocumento = new bool[] {false} ;
         T00372_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         T00372_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         T00372_A1097BoletosMensagemDeErro = new string[] {""} ;
         T00372_n1097BoletosMensagemDeErro = new bool[] {false} ;
         T00372_A1098BoletosTentativasDeRegistro = new int[1] ;
         T00372_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         T00372_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         T00372_n1117BoletosResgitroId = new bool[] {false} ;
         T00372_A1069CarteiraDeCobrancaId = new int[1] ;
         T00372_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         T00372_A261TituloId = new int[1] ;
         T00372_n261TituloId = new bool[] {false} ;
         T003733_A1077BoletosId = new int[1] ;
         T003733_n1077BoletosId = new bool[] {false} ;
         T003736_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         T003736_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         T003736_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         T003736_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         T003736_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003736_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         T003738_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         T003738_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         T003738_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         T003740_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         T003740_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         T003742_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         T003742_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         T003744_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         T003744_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         T003745_A1101BoletosLogId = new int[1] ;
         T003746_A1077BoletosId = new int[1] ;
         T003746_n1077BoletosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         i1117BoletosResgitroId = Guid.Empty;
         T003747_A261TituloId = new int[1] ;
         T003747_n261TituloId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boleto__default(),
            new Object[][] {
                new Object[] {
               T00372_A1077BoletosId, T00372_A1099BoletosCreatedAt, T00372_n1099BoletosCreatedAt, T00372_A1100BoletosUpdatedAt, T00372_n1100BoletosUpdatedAt, T00372_A1078BoletosNossoNumero, T00372_n1078BoletosNossoNumero, T00372_A1079BoletosSeuNumero, T00372_n1079BoletosSeuNumero, T00372_A1080BoletosNumero,
               T00372_n1080BoletosNumero, T00372_A1081BoletosLinhaDigitavel, T00372_n1081BoletosLinhaDigitavel, T00372_A1082BoletosCodigoDeBarras, T00372_n1082BoletosCodigoDeBarras, T00372_A1083BoletosStatus, T00372_n1083BoletosStatus, T00372_A1084BoletosDataEmissao, T00372_n1084BoletosDataEmissao, T00372_A1085BoletosDataVencimento,
               T00372_n1085BoletosDataVencimento, T00372_A1086BoletosDataRegistro, T00372_n1086BoletosDataRegistro, T00372_A1087BoletosDataPagamento, T00372_n1087BoletosDataPagamento, T00372_A1088BoletosDataBaixa, T00372_n1088BoletosDataBaixa, T00372_A1089BoletosValorNominal, T00372_n1089BoletosValorNominal, T00372_A1090BoletosValorPago,
               T00372_n1090BoletosValorPago, T00372_A1091BoletosValorDesconto, T00372_n1091BoletosValorDesconto, T00372_A1092BoletosValorJuros, T00372_n1092BoletosValorJuros, T00372_A1093BoletosValorMulta, T00372_n1093BoletosValorMulta, T00372_A1094BoletosSacadoNome, T00372_n1094BoletosSacadoNome, T00372_A1095BoletosSacadoDocumento,
               T00372_n1095BoletosSacadoDocumento, T00372_A1096BoletosSacadoTipoDocumento, T00372_n1096BoletosSacadoTipoDocumento, T00372_A1097BoletosMensagemDeErro, T00372_n1097BoletosMensagemDeErro, T00372_A1098BoletosTentativasDeRegistro, T00372_n1098BoletosTentativasDeRegistro, T00372_A1117BoletosResgitroId, T00372_n1117BoletosResgitroId, T00372_A1069CarteiraDeCobrancaId,
               T00372_n1069CarteiraDeCobrancaId, T00372_A261TituloId, T00372_n261TituloId
               }
               , new Object[] {
               T00373_A1077BoletosId, T00373_A1099BoletosCreatedAt, T00373_n1099BoletosCreatedAt, T00373_A1100BoletosUpdatedAt, T00373_n1100BoletosUpdatedAt, T00373_A1078BoletosNossoNumero, T00373_n1078BoletosNossoNumero, T00373_A1079BoletosSeuNumero, T00373_n1079BoletosSeuNumero, T00373_A1080BoletosNumero,
               T00373_n1080BoletosNumero, T00373_A1081BoletosLinhaDigitavel, T00373_n1081BoletosLinhaDigitavel, T00373_A1082BoletosCodigoDeBarras, T00373_n1082BoletosCodigoDeBarras, T00373_A1083BoletosStatus, T00373_n1083BoletosStatus, T00373_A1084BoletosDataEmissao, T00373_n1084BoletosDataEmissao, T00373_A1085BoletosDataVencimento,
               T00373_n1085BoletosDataVencimento, T00373_A1086BoletosDataRegistro, T00373_n1086BoletosDataRegistro, T00373_A1087BoletosDataPagamento, T00373_n1087BoletosDataPagamento, T00373_A1088BoletosDataBaixa, T00373_n1088BoletosDataBaixa, T00373_A1089BoletosValorNominal, T00373_n1089BoletosValorNominal, T00373_A1090BoletosValorPago,
               T00373_n1090BoletosValorPago, T00373_A1091BoletosValorDesconto, T00373_n1091BoletosValorDesconto, T00373_A1092BoletosValorJuros, T00373_n1092BoletosValorJuros, T00373_A1093BoletosValorMulta, T00373_n1093BoletosValorMulta, T00373_A1094BoletosSacadoNome, T00373_n1094BoletosSacadoNome, T00373_A1095BoletosSacadoDocumento,
               T00373_n1095BoletosSacadoDocumento, T00373_A1096BoletosSacadoTipoDocumento, T00373_n1096BoletosSacadoTipoDocumento, T00373_A1097BoletosMensagemDeErro, T00373_n1097BoletosMensagemDeErro, T00373_A1098BoletosTentativasDeRegistro, T00373_n1098BoletosTentativasDeRegistro, T00373_A1117BoletosResgitroId, T00373_n1117BoletosResgitroId, T00373_A1069CarteiraDeCobrancaId,
               T00373_n1069CarteiraDeCobrancaId, T00373_A261TituloId, T00373_n261TituloId
               }
               , new Object[] {
               T00374_A1071CarteiraDeCobrancaNome, T00374_n1071CarteiraDeCobrancaNome, T00374_A1073CarteiraDeCobrancaConvenio, T00374_n1073CarteiraDeCobrancaConvenio, T00374_A1074CarteiraDeCobrancaStatus, T00374_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               T00375_A261TituloId
               }
               , new Object[] {
               T00377_A1112CarteiraDeCobrancaValorRecebido, T00377_A1111CarteiraDeCobrancaValorTotal, T00377_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               T00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               T003711_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003711_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               T003713_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003713_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003718_A1077BoletosId, T003718_A1099BoletosCreatedAt, T003718_n1099BoletosCreatedAt, T003718_A1100BoletosUpdatedAt, T003718_n1100BoletosUpdatedAt, T003718_A1078BoletosNossoNumero, T003718_n1078BoletosNossoNumero, T003718_A1079BoletosSeuNumero, T003718_n1079BoletosSeuNumero, T003718_A1080BoletosNumero,
               T003718_n1080BoletosNumero, T003718_A1081BoletosLinhaDigitavel, T003718_n1081BoletosLinhaDigitavel, T003718_A1082BoletosCodigoDeBarras, T003718_n1082BoletosCodigoDeBarras, T003718_A1083BoletosStatus, T003718_n1083BoletosStatus, T003718_A1084BoletosDataEmissao, T003718_n1084BoletosDataEmissao, T003718_A1085BoletosDataVencimento,
               T003718_n1085BoletosDataVencimento, T003718_A1086BoletosDataRegistro, T003718_n1086BoletosDataRegistro, T003718_A1087BoletosDataPagamento, T003718_n1087BoletosDataPagamento, T003718_A1088BoletosDataBaixa, T003718_n1088BoletosDataBaixa, T003718_A1089BoletosValorNominal, T003718_n1089BoletosValorNominal, T003718_A1090BoletosValorPago,
               T003718_n1090BoletosValorPago, T003718_A1091BoletosValorDesconto, T003718_n1091BoletosValorDesconto, T003718_A1092BoletosValorJuros, T003718_n1092BoletosValorJuros, T003718_A1093BoletosValorMulta, T003718_n1093BoletosValorMulta, T003718_A1094BoletosSacadoNome, T003718_n1094BoletosSacadoNome, T003718_A1095BoletosSacadoDocumento,
               T003718_n1095BoletosSacadoDocumento, T003718_A1096BoletosSacadoTipoDocumento, T003718_n1096BoletosSacadoTipoDocumento, T003718_A1097BoletosMensagemDeErro, T003718_n1097BoletosMensagemDeErro, T003718_A1098BoletosTentativasDeRegistro, T003718_n1098BoletosTentativasDeRegistro, T003718_A1117BoletosResgitroId, T003718_n1117BoletosResgitroId, T003718_A1071CarteiraDeCobrancaNome,
               T003718_n1071CarteiraDeCobrancaNome, T003718_A1073CarteiraDeCobrancaConvenio, T003718_n1073CarteiraDeCobrancaConvenio, T003718_A1074CarteiraDeCobrancaStatus, T003718_n1074CarteiraDeCobrancaStatus, T003718_A1069CarteiraDeCobrancaId, T003718_n1069CarteiraDeCobrancaId, T003718_A261TituloId, T003718_n261TituloId, T003718_A1112CarteiraDeCobrancaValorRecebido,
               T003718_A1111CarteiraDeCobrancaValorTotal, T003718_A1113CarteiraDeCobrancaTotalBoletos, T003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados, T003718_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003718_n1115CarteiraDeCobrancaTotalBoletosExpirados, T003718_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003718_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003719_A1071CarteiraDeCobrancaNome, T003719_n1071CarteiraDeCobrancaNome, T003719_A1073CarteiraDeCobrancaConvenio, T003719_n1073CarteiraDeCobrancaConvenio, T003719_A1074CarteiraDeCobrancaStatus, T003719_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               T003721_A1112CarteiraDeCobrancaValorRecebido, T003721_A1111CarteiraDeCobrancaValorTotal, T003721_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               T003723_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T003723_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               T003725_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003725_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               T003727_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003727_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003728_A261TituloId
               }
               , new Object[] {
               T003729_A1077BoletosId
               }
               , new Object[] {
               T003730_A1077BoletosId
               }
               , new Object[] {
               T003731_A1077BoletosId
               }
               , new Object[] {
               }
               , new Object[] {
               T003733_A1077BoletosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003736_A1071CarteiraDeCobrancaNome, T003736_n1071CarteiraDeCobrancaNome, T003736_A1073CarteiraDeCobrancaConvenio, T003736_n1073CarteiraDeCobrancaConvenio, T003736_A1074CarteiraDeCobrancaStatus, T003736_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               T003738_A1112CarteiraDeCobrancaValorRecebido, T003738_A1111CarteiraDeCobrancaValorTotal, T003738_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               T003740_A1114CarteiraDeCobrancaTotalBoletosRegistrados, T003740_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               T003742_A1115CarteiraDeCobrancaTotalBoletosExpirados, T003742_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               T003744_A1116CarteiraDeCobrancaTotalBoletosCancelados, T003744_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               T003745_A1101BoletosLogId
               }
               , new Object[] {
               T003746_A1077BoletosId
               }
               , new Object[] {
               T003747_A261TituloId
               }
            }
         );
         Z1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         A1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         i1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         AV22Pgmname = "Boleto";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound111 ;
      private short gxcookieaux ;
      private short gxajaxcallmode ;
      private int wcpOAV7BoletosId ;
      private int Z1077BoletosId ;
      private int Z1098BoletosTentativasDeRegistro ;
      private int Z1069CarteiraDeCobrancaId ;
      private int Z261TituloId ;
      private int N1069CarteiraDeCobrancaId ;
      private int N261TituloId ;
      private int A1069CarteiraDeCobrancaId ;
      private int A261TituloId ;
      private int AV7BoletosId ;
      private int trnEnded ;
      private int A1077BoletosId ;
      private int edtBoletosId_Enabled ;
      private int edtCarteiraDeCobrancaId_Visible ;
      private int edtCarteiraDeCobrancaId_Enabled ;
      private int edtTituloId_Visible ;
      private int edtTituloId_Enabled ;
      private int edtBoletosNossoNumero_Enabled ;
      private int edtBoletosSeuNumero_Enabled ;
      private int edtBoletosNumero_Enabled ;
      private int edtBoletosLinhaDigitavel_Enabled ;
      private int edtBoletosCodigoDeBarras_Enabled ;
      private int edtBoletosDataEmissao_Enabled ;
      private int edtBoletosDataVencimento_Enabled ;
      private int edtBoletosDataRegistro_Enabled ;
      private int edtBoletosDataPagamento_Enabled ;
      private int edtBoletosDataBaixa_Enabled ;
      private int edtBoletosValorNominal_Enabled ;
      private int edtBoletosValorPago_Enabled ;
      private int edtBoletosValorDesconto_Enabled ;
      private int edtBoletosValorJuros_Enabled ;
      private int edtBoletosValorMulta_Enabled ;
      private int edtBoletosSacadoNome_Enabled ;
      private int edtBoletosSacadoDocumento_Enabled ;
      private int edtBoletosMensagemDeErro_Enabled ;
      private int A1098BoletosTentativasDeRegistro ;
      private int edtBoletosTentativasDeRegistro_Enabled ;
      private int edtBoletosCreatedAt_Enabled ;
      private int edtBoletosUpdatedAt_Enabled ;
      private int edtCarteiraDeCobrancaNome_Enabled ;
      private int edtCarteiraDeCobrancaConvenio_Enabled ;
      private int edtCarteiraDeCobrancaValorTotal_Enabled ;
      private int edtCarteiraDeCobrancaValorRecebido_Enabled ;
      private int A1113CarteiraDeCobrancaTotalBoletos ;
      private int edtCarteiraDeCobrancaTotalBoletos_Enabled ;
      private int A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int edtCarteiraDeCobrancaTotalBoletosRegistrados_Enabled ;
      private int A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int edtCarteiraDeCobrancaTotalBoletosExpirados_Enabled ;
      private int A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int edtCarteiraDeCobrancaTotalBoletosCancelados_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboCarteiraDeCobrancaId ;
      private int edtavCombocarteiradecobrancaid_Enabled ;
      private int edtavCombocarteiradecobrancaid_Visible ;
      private int AV21ComboTituloId ;
      private int edtavCombotituloid_Enabled ;
      private int edtavCombotituloid_Visible ;
      private int AV11Insert_CarteiraDeCobrancaId ;
      private int AV12Insert_TituloId ;
      private int Combo_carteiradecobrancaid_Datalistupdateminimumcharacters ;
      private int Combo_carteiradecobrancaid_Gxcontroltype ;
      private int Combo_tituloid_Datalistupdateminimumcharacters ;
      private int Combo_tituloid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int Z1113CarteiraDeCobrancaTotalBoletos ;
      private int Z1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int Z1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int Z1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int idxLst ;
      private decimal Z1089BoletosValorNominal ;
      private decimal Z1090BoletosValorPago ;
      private decimal Z1091BoletosValorDesconto ;
      private decimal Z1092BoletosValorJuros ;
      private decimal Z1093BoletosValorMulta ;
      private decimal A1089BoletosValorNominal ;
      private decimal A1090BoletosValorPago ;
      private decimal A1091BoletosValorDesconto ;
      private decimal A1092BoletosValorJuros ;
      private decimal A1093BoletosValorMulta ;
      private decimal A1111CarteiraDeCobrancaValorTotal ;
      private decimal A1112CarteiraDeCobrancaValorRecebido ;
      private decimal Z1112CarteiraDeCobrancaValorRecebido ;
      private decimal Z1111CarteiraDeCobrancaValorTotal ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_tituloid_Selectedvalue_get ;
      private string Combo_carteiradecobrancaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCarteiraDeCobrancaId_Internalname ;
      private string cmbBoletosStatus_Internalname ;
      private string cmbBoletosSacadoTipoDocumento_Internalname ;
      private string cmbCarteiraDeCobrancaStatus_Internalname ;
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
      private string edtBoletosId_Internalname ;
      private string TempTags ;
      private string edtBoletosId_Jsonclick ;
      private string divTablesplittedcarteiradecobrancaid_Internalname ;
      private string lblTextblockcarteiradecobrancaid_Internalname ;
      private string lblTextblockcarteiradecobrancaid_Jsonclick ;
      private string Combo_carteiradecobrancaid_Caption ;
      private string Combo_carteiradecobrancaid_Cls ;
      private string Combo_carteiradecobrancaid_Datalistproc ;
      private string Combo_carteiradecobrancaid_Datalistprocparametersprefix ;
      private string Combo_carteiradecobrancaid_Internalname ;
      private string edtCarteiraDeCobrancaId_Jsonclick ;
      private string divTablesplittedtituloid_Internalname ;
      private string lblTextblocktituloid_Internalname ;
      private string lblTextblocktituloid_Jsonclick ;
      private string Combo_tituloid_Caption ;
      private string Combo_tituloid_Cls ;
      private string Combo_tituloid_Datalistproc ;
      private string Combo_tituloid_Datalistprocparametersprefix ;
      private string Combo_tituloid_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtTituloId_Jsonclick ;
      private string edtBoletosNossoNumero_Internalname ;
      private string edtBoletosNossoNumero_Jsonclick ;
      private string edtBoletosSeuNumero_Internalname ;
      private string edtBoletosSeuNumero_Jsonclick ;
      private string edtBoletosNumero_Internalname ;
      private string edtBoletosNumero_Jsonclick ;
      private string edtBoletosLinhaDigitavel_Internalname ;
      private string edtBoletosLinhaDigitavel_Jsonclick ;
      private string edtBoletosCodigoDeBarras_Internalname ;
      private string edtBoletosCodigoDeBarras_Jsonclick ;
      private string cmbBoletosStatus_Jsonclick ;
      private string edtBoletosDataEmissao_Internalname ;
      private string edtBoletosDataEmissao_Jsonclick ;
      private string edtBoletosDataVencimento_Internalname ;
      private string edtBoletosDataVencimento_Jsonclick ;
      private string edtBoletosDataRegistro_Internalname ;
      private string edtBoletosDataRegistro_Jsonclick ;
      private string edtBoletosDataPagamento_Internalname ;
      private string edtBoletosDataPagamento_Jsonclick ;
      private string edtBoletosDataBaixa_Internalname ;
      private string edtBoletosDataBaixa_Jsonclick ;
      private string edtBoletosValorNominal_Internalname ;
      private string edtBoletosValorNominal_Jsonclick ;
      private string edtBoletosValorPago_Internalname ;
      private string edtBoletosValorPago_Jsonclick ;
      private string edtBoletosValorDesconto_Internalname ;
      private string edtBoletosValorDesconto_Jsonclick ;
      private string edtBoletosValorJuros_Internalname ;
      private string edtBoletosValorJuros_Jsonclick ;
      private string edtBoletosValorMulta_Internalname ;
      private string edtBoletosValorMulta_Jsonclick ;
      private string edtBoletosSacadoNome_Internalname ;
      private string edtBoletosSacadoNome_Jsonclick ;
      private string edtBoletosSacadoDocumento_Internalname ;
      private string edtBoletosSacadoDocumento_Jsonclick ;
      private string cmbBoletosSacadoTipoDocumento_Jsonclick ;
      private string edtBoletosMensagemDeErro_Internalname ;
      private string edtBoletosTentativasDeRegistro_Internalname ;
      private string edtBoletosTentativasDeRegistro_Jsonclick ;
      private string edtBoletosCreatedAt_Internalname ;
      private string edtBoletosCreatedAt_Jsonclick ;
      private string edtBoletosUpdatedAt_Internalname ;
      private string edtBoletosUpdatedAt_Jsonclick ;
      private string edtCarteiraDeCobrancaNome_Internalname ;
      private string edtCarteiraDeCobrancaNome_Jsonclick ;
      private string edtCarteiraDeCobrancaConvenio_Internalname ;
      private string edtCarteiraDeCobrancaConvenio_Jsonclick ;
      private string cmbCarteiraDeCobrancaStatus_Jsonclick ;
      private string edtCarteiraDeCobrancaValorTotal_Internalname ;
      private string edtCarteiraDeCobrancaValorTotal_Jsonclick ;
      private string edtCarteiraDeCobrancaValorRecebido_Internalname ;
      private string edtCarteiraDeCobrancaValorRecebido_Jsonclick ;
      private string edtCarteiraDeCobrancaTotalBoletos_Internalname ;
      private string edtCarteiraDeCobrancaTotalBoletos_Jsonclick ;
      private string edtCarteiraDeCobrancaTotalBoletosRegistrados_Internalname ;
      private string edtCarteiraDeCobrancaTotalBoletosRegistrados_Jsonclick ;
      private string edtCarteiraDeCobrancaTotalBoletosExpirados_Internalname ;
      private string edtCarteiraDeCobrancaTotalBoletosExpirados_Jsonclick ;
      private string edtCarteiraDeCobrancaTotalBoletosCancelados_Internalname ;
      private string edtCarteiraDeCobrancaTotalBoletosCancelados_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_carteiradecobrancaid_Internalname ;
      private string edtavCombocarteiradecobrancaid_Internalname ;
      private string edtavCombocarteiradecobrancaid_Jsonclick ;
      private string divSectionattribute_tituloid_Internalname ;
      private string edtavCombotituloid_Internalname ;
      private string edtavCombotituloid_Jsonclick ;
      private string AV22Pgmname ;
      private string Combo_carteiradecobrancaid_Objectcall ;
      private string Combo_carteiradecobrancaid_Class ;
      private string Combo_carteiradecobrancaid_Icontype ;
      private string Combo_carteiradecobrancaid_Icon ;
      private string Combo_carteiradecobrancaid_Tooltip ;
      private string Combo_carteiradecobrancaid_Selectedvalue_set ;
      private string Combo_carteiradecobrancaid_Selectedtext_set ;
      private string Combo_carteiradecobrancaid_Selectedtext_get ;
      private string Combo_carteiradecobrancaid_Gamoauthtoken ;
      private string Combo_carteiradecobrancaid_Ddointernalname ;
      private string Combo_carteiradecobrancaid_Titlecontrolalign ;
      private string Combo_carteiradecobrancaid_Dropdownoptionstype ;
      private string Combo_carteiradecobrancaid_Titlecontrolidtoreplace ;
      private string Combo_carteiradecobrancaid_Datalisttype ;
      private string Combo_carteiradecobrancaid_Datalistfixedvalues ;
      private string Combo_carteiradecobrancaid_Remoteservicesparameters ;
      private string Combo_carteiradecobrancaid_Htmltemplate ;
      private string Combo_carteiradecobrancaid_Multiplevaluestype ;
      private string Combo_carteiradecobrancaid_Loadingdata ;
      private string Combo_carteiradecobrancaid_Noresultsfound ;
      private string Combo_carteiradecobrancaid_Emptyitemtext ;
      private string Combo_carteiradecobrancaid_Onlyselectedvalues ;
      private string Combo_carteiradecobrancaid_Selectalltext ;
      private string Combo_carteiradecobrancaid_Multiplevaluesseparator ;
      private string Combo_carteiradecobrancaid_Addnewoptiontext ;
      private string Combo_tituloid_Objectcall ;
      private string Combo_tituloid_Class ;
      private string Combo_tituloid_Icontype ;
      private string Combo_tituloid_Icon ;
      private string Combo_tituloid_Tooltip ;
      private string Combo_tituloid_Selectedvalue_set ;
      private string Combo_tituloid_Selectedtext_set ;
      private string Combo_tituloid_Selectedtext_get ;
      private string Combo_tituloid_Gamoauthtoken ;
      private string Combo_tituloid_Ddointernalname ;
      private string Combo_tituloid_Titlecontrolalign ;
      private string Combo_tituloid_Dropdownoptionstype ;
      private string Combo_tituloid_Titlecontrolidtoreplace ;
      private string Combo_tituloid_Datalisttype ;
      private string Combo_tituloid_Datalistfixedvalues ;
      private string Combo_tituloid_Remoteservicesparameters ;
      private string Combo_tituloid_Htmltemplate ;
      private string Combo_tituloid_Multiplevaluestype ;
      private string Combo_tituloid_Loadingdata ;
      private string Combo_tituloid_Noresultsfound ;
      private string Combo_tituloid_Emptyitemtext ;
      private string Combo_tituloid_Onlyselectedvalues ;
      private string Combo_tituloid_Selectalltext ;
      private string Combo_tituloid_Multiplevaluesseparator ;
      private string Combo_tituloid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode111 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z1099BoletosCreatedAt ;
      private DateTime Z1100BoletosUpdatedAt ;
      private DateTime Z1086BoletosDataRegistro ;
      private DateTime A1086BoletosDataRegistro ;
      private DateTime A1099BoletosCreatedAt ;
      private DateTime A1100BoletosUpdatedAt ;
      private DateTime i1099BoletosCreatedAt ;
      private DateTime Z1084BoletosDataEmissao ;
      private DateTime Z1085BoletosDataVencimento ;
      private DateTime Z1087BoletosDataPagamento ;
      private DateTime Z1088BoletosDataBaixa ;
      private DateTime A1084BoletosDataEmissao ;
      private DateTime A1085BoletosDataVencimento ;
      private DateTime A1087BoletosDataPagamento ;
      private DateTime A1088BoletosDataBaixa ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1069CarteiraDeCobrancaId ;
      private bool n261TituloId ;
      private bool wbErr ;
      private bool n1083BoletosStatus ;
      private bool n1096BoletosSacadoTipoDocumento ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n1089BoletosValorNominal ;
      private bool n1090BoletosValorPago ;
      private bool n1091BoletosValorDesconto ;
      private bool n1092BoletosValorJuros ;
      private bool n1093BoletosValorMulta ;
      private bool n1098BoletosTentativasDeRegistro ;
      private bool n1099BoletosCreatedAt ;
      private bool n1100BoletosUpdatedAt ;
      private bool n1078BoletosNossoNumero ;
      private bool n1079BoletosSeuNumero ;
      private bool n1080BoletosNumero ;
      private bool n1081BoletosLinhaDigitavel ;
      private bool n1082BoletosCodigoDeBarras ;
      private bool n1084BoletosDataEmissao ;
      private bool n1085BoletosDataVencimento ;
      private bool n1086BoletosDataRegistro ;
      private bool n1087BoletosDataPagamento ;
      private bool n1088BoletosDataBaixa ;
      private bool n1094BoletosSacadoNome ;
      private bool n1095BoletosSacadoDocumento ;
      private bool n1117BoletosResgitroId ;
      private bool Combo_carteiradecobrancaid_Enabled ;
      private bool Combo_carteiradecobrancaid_Visible ;
      private bool Combo_carteiradecobrancaid_Allowmultipleselection ;
      private bool Combo_carteiradecobrancaid_Isgriditem ;
      private bool Combo_carteiradecobrancaid_Hasdescription ;
      private bool Combo_carteiradecobrancaid_Includeonlyselectedoption ;
      private bool Combo_carteiradecobrancaid_Includeselectalloption ;
      private bool Combo_carteiradecobrancaid_Emptyitem ;
      private bool Combo_carteiradecobrancaid_Includeaddnewoption ;
      private bool Combo_tituloid_Enabled ;
      private bool Combo_tituloid_Visible ;
      private bool Combo_tituloid_Allowmultipleselection ;
      private bool Combo_tituloid_Isgriditem ;
      private bool Combo_tituloid_Hasdescription ;
      private bool Combo_tituloid_Includeonlyselectedoption ;
      private bool Combo_tituloid_Includeselectalloption ;
      private bool Combo_tituloid_Emptyitem ;
      private bool Combo_tituloid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n1077BoletosId ;
      private bool n1097BoletosMensagemDeErro ;
      private bool n1071CarteiraDeCobrancaNome ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool returnInSub ;
      private bool Z1074CarteiraDeCobrancaStatus ;
      private bool Gx_longc ;
      private string A1097BoletosMensagemDeErro ;
      private string AV18Combo_DataJson ;
      private string Z1097BoletosMensagemDeErro ;
      private string Z1078BoletosNossoNumero ;
      private string Z1079BoletosSeuNumero ;
      private string Z1080BoletosNumero ;
      private string Z1081BoletosLinhaDigitavel ;
      private string Z1082BoletosCodigoDeBarras ;
      private string Z1083BoletosStatus ;
      private string Z1094BoletosSacadoNome ;
      private string Z1095BoletosSacadoDocumento ;
      private string Z1096BoletosSacadoTipoDocumento ;
      private string A1083BoletosStatus ;
      private string A1096BoletosSacadoTipoDocumento ;
      private string A1078BoletosNossoNumero ;
      private string A1079BoletosSeuNumero ;
      private string A1080BoletosNumero ;
      private string A1081BoletosLinhaDigitavel ;
      private string A1082BoletosCodigoDeBarras ;
      private string A1094BoletosSacadoNome ;
      private string A1095BoletosSacadoDocumento ;
      private string A1071CarteiraDeCobrancaNome ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z1071CarteiraDeCobrancaNome ;
      private string Z1073CarteiraDeCobrancaConvenio ;
      private Guid Z1117BoletosResgitroId ;
      private Guid A1117BoletosResgitroId ;
      private Guid i1117BoletosResgitroId ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_carteiradecobrancaid ;
      private GXUserControl ucCombo_tituloid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbBoletosStatus ;
      private GXCombobox cmbBoletosSacadoTipoDocumento ;
      private GXCombobox cmbCarteiraDeCobrancaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14CarteiraDeCobrancaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20TituloId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00374_A1071CarteiraDeCobrancaNome ;
      private bool[] T00374_n1071CarteiraDeCobrancaNome ;
      private string[] T00374_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T00374_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T00374_A1074CarteiraDeCobrancaStatus ;
      private bool[] T00374_n1074CarteiraDeCobrancaStatus ;
      private decimal[] T00377_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] T00377_A1111CarteiraDeCobrancaValorTotal ;
      private int[] T00377_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003711_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003711_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003713_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003713_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T003718_A1077BoletosId ;
      private bool[] T003718_n1077BoletosId ;
      private DateTime[] T003718_A1099BoletosCreatedAt ;
      private bool[] T003718_n1099BoletosCreatedAt ;
      private DateTime[] T003718_A1100BoletosUpdatedAt ;
      private bool[] T003718_n1100BoletosUpdatedAt ;
      private string[] T003718_A1078BoletosNossoNumero ;
      private bool[] T003718_n1078BoletosNossoNumero ;
      private string[] T003718_A1079BoletosSeuNumero ;
      private bool[] T003718_n1079BoletosSeuNumero ;
      private string[] T003718_A1080BoletosNumero ;
      private bool[] T003718_n1080BoletosNumero ;
      private string[] T003718_A1081BoletosLinhaDigitavel ;
      private bool[] T003718_n1081BoletosLinhaDigitavel ;
      private string[] T003718_A1082BoletosCodigoDeBarras ;
      private bool[] T003718_n1082BoletosCodigoDeBarras ;
      private string[] T003718_A1083BoletosStatus ;
      private bool[] T003718_n1083BoletosStatus ;
      private DateTime[] T003718_A1084BoletosDataEmissao ;
      private bool[] T003718_n1084BoletosDataEmissao ;
      private DateTime[] T003718_A1085BoletosDataVencimento ;
      private bool[] T003718_n1085BoletosDataVencimento ;
      private DateTime[] T003718_A1086BoletosDataRegistro ;
      private bool[] T003718_n1086BoletosDataRegistro ;
      private DateTime[] T003718_A1087BoletosDataPagamento ;
      private bool[] T003718_n1087BoletosDataPagamento ;
      private DateTime[] T003718_A1088BoletosDataBaixa ;
      private bool[] T003718_n1088BoletosDataBaixa ;
      private decimal[] T003718_A1089BoletosValorNominal ;
      private bool[] T003718_n1089BoletosValorNominal ;
      private decimal[] T003718_A1090BoletosValorPago ;
      private bool[] T003718_n1090BoletosValorPago ;
      private decimal[] T003718_A1091BoletosValorDesconto ;
      private bool[] T003718_n1091BoletosValorDesconto ;
      private decimal[] T003718_A1092BoletosValorJuros ;
      private bool[] T003718_n1092BoletosValorJuros ;
      private decimal[] T003718_A1093BoletosValorMulta ;
      private bool[] T003718_n1093BoletosValorMulta ;
      private string[] T003718_A1094BoletosSacadoNome ;
      private bool[] T003718_n1094BoletosSacadoNome ;
      private string[] T003718_A1095BoletosSacadoDocumento ;
      private bool[] T003718_n1095BoletosSacadoDocumento ;
      private string[] T003718_A1096BoletosSacadoTipoDocumento ;
      private bool[] T003718_n1096BoletosSacadoTipoDocumento ;
      private string[] T003718_A1097BoletosMensagemDeErro ;
      private bool[] T003718_n1097BoletosMensagemDeErro ;
      private int[] T003718_A1098BoletosTentativasDeRegistro ;
      private bool[] T003718_n1098BoletosTentativasDeRegistro ;
      private Guid[] T003718_A1117BoletosResgitroId ;
      private bool[] T003718_n1117BoletosResgitroId ;
      private string[] T003718_A1071CarteiraDeCobrancaNome ;
      private bool[] T003718_n1071CarteiraDeCobrancaNome ;
      private string[] T003718_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T003718_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T003718_A1074CarteiraDeCobrancaStatus ;
      private bool[] T003718_n1074CarteiraDeCobrancaStatus ;
      private int[] T003718_A1069CarteiraDeCobrancaId ;
      private bool[] T003718_n1069CarteiraDeCobrancaId ;
      private int[] T003718_A261TituloId ;
      private bool[] T003718_n261TituloId ;
      private decimal[] T003718_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] T003718_A1111CarteiraDeCobrancaValorTotal ;
      private int[] T003718_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003718_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003718_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003718_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003718_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T00375_A261TituloId ;
      private bool[] T00375_n261TituloId ;
      private string[] T003719_A1071CarteiraDeCobrancaNome ;
      private bool[] T003719_n1071CarteiraDeCobrancaNome ;
      private string[] T003719_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T003719_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T003719_A1074CarteiraDeCobrancaStatus ;
      private bool[] T003719_n1074CarteiraDeCobrancaStatus ;
      private decimal[] T003721_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] T003721_A1111CarteiraDeCobrancaValorTotal ;
      private int[] T003721_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T003723_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T003723_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003725_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003725_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003727_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003727_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T003728_A261TituloId ;
      private bool[] T003728_n261TituloId ;
      private int[] T003729_A1077BoletosId ;
      private bool[] T003729_n1077BoletosId ;
      private int[] T00373_A1077BoletosId ;
      private bool[] T00373_n1077BoletosId ;
      private DateTime[] T00373_A1099BoletosCreatedAt ;
      private bool[] T00373_n1099BoletosCreatedAt ;
      private DateTime[] T00373_A1100BoletosUpdatedAt ;
      private bool[] T00373_n1100BoletosUpdatedAt ;
      private string[] T00373_A1078BoletosNossoNumero ;
      private bool[] T00373_n1078BoletosNossoNumero ;
      private string[] T00373_A1079BoletosSeuNumero ;
      private bool[] T00373_n1079BoletosSeuNumero ;
      private string[] T00373_A1080BoletosNumero ;
      private bool[] T00373_n1080BoletosNumero ;
      private string[] T00373_A1081BoletosLinhaDigitavel ;
      private bool[] T00373_n1081BoletosLinhaDigitavel ;
      private string[] T00373_A1082BoletosCodigoDeBarras ;
      private bool[] T00373_n1082BoletosCodigoDeBarras ;
      private string[] T00373_A1083BoletosStatus ;
      private bool[] T00373_n1083BoletosStatus ;
      private DateTime[] T00373_A1084BoletosDataEmissao ;
      private bool[] T00373_n1084BoletosDataEmissao ;
      private DateTime[] T00373_A1085BoletosDataVencimento ;
      private bool[] T00373_n1085BoletosDataVencimento ;
      private DateTime[] T00373_A1086BoletosDataRegistro ;
      private bool[] T00373_n1086BoletosDataRegistro ;
      private DateTime[] T00373_A1087BoletosDataPagamento ;
      private bool[] T00373_n1087BoletosDataPagamento ;
      private DateTime[] T00373_A1088BoletosDataBaixa ;
      private bool[] T00373_n1088BoletosDataBaixa ;
      private decimal[] T00373_A1089BoletosValorNominal ;
      private bool[] T00373_n1089BoletosValorNominal ;
      private decimal[] T00373_A1090BoletosValorPago ;
      private bool[] T00373_n1090BoletosValorPago ;
      private decimal[] T00373_A1091BoletosValorDesconto ;
      private bool[] T00373_n1091BoletosValorDesconto ;
      private decimal[] T00373_A1092BoletosValorJuros ;
      private bool[] T00373_n1092BoletosValorJuros ;
      private decimal[] T00373_A1093BoletosValorMulta ;
      private bool[] T00373_n1093BoletosValorMulta ;
      private string[] T00373_A1094BoletosSacadoNome ;
      private bool[] T00373_n1094BoletosSacadoNome ;
      private string[] T00373_A1095BoletosSacadoDocumento ;
      private bool[] T00373_n1095BoletosSacadoDocumento ;
      private string[] T00373_A1096BoletosSacadoTipoDocumento ;
      private bool[] T00373_n1096BoletosSacadoTipoDocumento ;
      private string[] T00373_A1097BoletosMensagemDeErro ;
      private bool[] T00373_n1097BoletosMensagemDeErro ;
      private int[] T00373_A1098BoletosTentativasDeRegistro ;
      private bool[] T00373_n1098BoletosTentativasDeRegistro ;
      private Guid[] T00373_A1117BoletosResgitroId ;
      private bool[] T00373_n1117BoletosResgitroId ;
      private int[] T00373_A1069CarteiraDeCobrancaId ;
      private bool[] T00373_n1069CarteiraDeCobrancaId ;
      private int[] T00373_A261TituloId ;
      private bool[] T00373_n261TituloId ;
      private int[] T003730_A1077BoletosId ;
      private bool[] T003730_n1077BoletosId ;
      private int[] T003731_A1077BoletosId ;
      private bool[] T003731_n1077BoletosId ;
      private int[] T00372_A1077BoletosId ;
      private bool[] T00372_n1077BoletosId ;
      private DateTime[] T00372_A1099BoletosCreatedAt ;
      private bool[] T00372_n1099BoletosCreatedAt ;
      private DateTime[] T00372_A1100BoletosUpdatedAt ;
      private bool[] T00372_n1100BoletosUpdatedAt ;
      private string[] T00372_A1078BoletosNossoNumero ;
      private bool[] T00372_n1078BoletosNossoNumero ;
      private string[] T00372_A1079BoletosSeuNumero ;
      private bool[] T00372_n1079BoletosSeuNumero ;
      private string[] T00372_A1080BoletosNumero ;
      private bool[] T00372_n1080BoletosNumero ;
      private string[] T00372_A1081BoletosLinhaDigitavel ;
      private bool[] T00372_n1081BoletosLinhaDigitavel ;
      private string[] T00372_A1082BoletosCodigoDeBarras ;
      private bool[] T00372_n1082BoletosCodigoDeBarras ;
      private string[] T00372_A1083BoletosStatus ;
      private bool[] T00372_n1083BoletosStatus ;
      private DateTime[] T00372_A1084BoletosDataEmissao ;
      private bool[] T00372_n1084BoletosDataEmissao ;
      private DateTime[] T00372_A1085BoletosDataVencimento ;
      private bool[] T00372_n1085BoletosDataVencimento ;
      private DateTime[] T00372_A1086BoletosDataRegistro ;
      private bool[] T00372_n1086BoletosDataRegistro ;
      private DateTime[] T00372_A1087BoletosDataPagamento ;
      private bool[] T00372_n1087BoletosDataPagamento ;
      private DateTime[] T00372_A1088BoletosDataBaixa ;
      private bool[] T00372_n1088BoletosDataBaixa ;
      private decimal[] T00372_A1089BoletosValorNominal ;
      private bool[] T00372_n1089BoletosValorNominal ;
      private decimal[] T00372_A1090BoletosValorPago ;
      private bool[] T00372_n1090BoletosValorPago ;
      private decimal[] T00372_A1091BoletosValorDesconto ;
      private bool[] T00372_n1091BoletosValorDesconto ;
      private decimal[] T00372_A1092BoletosValorJuros ;
      private bool[] T00372_n1092BoletosValorJuros ;
      private decimal[] T00372_A1093BoletosValorMulta ;
      private bool[] T00372_n1093BoletosValorMulta ;
      private string[] T00372_A1094BoletosSacadoNome ;
      private bool[] T00372_n1094BoletosSacadoNome ;
      private string[] T00372_A1095BoletosSacadoDocumento ;
      private bool[] T00372_n1095BoletosSacadoDocumento ;
      private string[] T00372_A1096BoletosSacadoTipoDocumento ;
      private bool[] T00372_n1096BoletosSacadoTipoDocumento ;
      private string[] T00372_A1097BoletosMensagemDeErro ;
      private bool[] T00372_n1097BoletosMensagemDeErro ;
      private int[] T00372_A1098BoletosTentativasDeRegistro ;
      private bool[] T00372_n1098BoletosTentativasDeRegistro ;
      private Guid[] T00372_A1117BoletosResgitroId ;
      private bool[] T00372_n1117BoletosResgitroId ;
      private int[] T00372_A1069CarteiraDeCobrancaId ;
      private bool[] T00372_n1069CarteiraDeCobrancaId ;
      private int[] T00372_A261TituloId ;
      private bool[] T00372_n261TituloId ;
      private int[] T003733_A1077BoletosId ;
      private bool[] T003733_n1077BoletosId ;
      private string[] T003736_A1071CarteiraDeCobrancaNome ;
      private bool[] T003736_n1071CarteiraDeCobrancaNome ;
      private string[] T003736_A1073CarteiraDeCobrancaConvenio ;
      private bool[] T003736_n1073CarteiraDeCobrancaConvenio ;
      private bool[] T003736_A1074CarteiraDeCobrancaStatus ;
      private bool[] T003736_n1074CarteiraDeCobrancaStatus ;
      private decimal[] T003738_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] T003738_A1111CarteiraDeCobrancaValorTotal ;
      private int[] T003738_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] T003740_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] T003740_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] T003742_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] T003742_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] T003744_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] T003744_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] T003745_A1101BoletosLogId ;
      private int[] T003746_A1077BoletosId ;
      private bool[] T003746_n1077BoletosId ;
      private int[] T003747_A261TituloId ;
      private bool[] T003747_n261TituloId ;
   }

   public class boleto__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00372;
          prmT00372 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00373;
          prmT00373 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00374;
          prmT00374 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00375;
          prmT00375 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00377;
          prmT00377 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00379;
          prmT00379 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003711;
          prmT003711 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003713;
          prmT003713 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003718;
          prmT003718 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT003718;
          cmdBufferT003718=" SELECT TM1.BoletosId, TM1.BoletosCreatedAt, TM1.BoletosUpdatedAt, TM1.BoletosNossoNumero, TM1.BoletosSeuNumero, TM1.BoletosNumero, TM1.BoletosLinhaDigitavel, TM1.BoletosCodigoDeBarras, TM1.BoletosStatus, TM1.BoletosDataEmissao, TM1.BoletosDataVencimento, TM1.BoletosDataRegistro, TM1.BoletosDataPagamento, TM1.BoletosDataBaixa, TM1.BoletosValorNominal, TM1.BoletosValorPago, TM1.BoletosValorDesconto, TM1.BoletosValorJuros, TM1.BoletosValorMulta, TM1.BoletosSacadoNome, TM1.BoletosSacadoDocumento, TM1.BoletosSacadoTipoDocumento, TM1.BoletosMensagemDeErro, TM1.BoletosTentativasDeRegistro, TM1.BoletosResgitroId, T2.CarteiraDeCobrancaNome, T2.CarteiraDeCobrancaConvenio, T2.CarteiraDeCobrancaStatus, TM1.CarteiraDeCobrancaId, TM1.TituloId, COALESCE( T3.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T3.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T3.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos, COALESCE( T4.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados, COALESCE( T5.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados, COALESCE( T6.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (((((Boleto TM1 LEFT JOIN CarteiraDeCobranca T2 ON T2.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT SUM(TM1.BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, TM1.CarteiraDeCobrancaId, SUM(TM1.BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto TM1 WHERE TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId GROUP BY TM1.CarteiraDeCobrancaId ) T3 ON T3.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, "
          + " TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'REGISTRADO')) GROUP BY TM1.CarteiraDeCobrancaId ) T4 ON T4.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'VENCIDO')) GROUP BY TM1.CarteiraDeCobrancaId ) T5 ON T5.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'BAIXADO')) GROUP BY TM1.CarteiraDeCobrancaId ) T6 ON T6.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) WHERE TM1.BoletosId = :BoletosId ORDER BY TM1.BoletosId" ;
          Object[] prmT003719;
          prmT003719 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003721;
          prmT003721 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003723;
          prmT003723 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003725;
          prmT003725 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003727;
          prmT003727 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003728;
          prmT003728 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003729;
          prmT003729 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003730;
          prmT003730 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003731;
          prmT003731 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003732;
          prmT003732 = new Object[] {
          new ParDef("BoletosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosNossoNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosSeuNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosLinhaDigitavel",GXType.VarChar,54,0){Nullable=true} ,
          new ParDef("BoletosCodigoDeBarras",GXType.VarChar,44,0){Nullable=true} ,
          new ParDef("BoletosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataRegistro",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosDataPagamento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataBaixa",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosValorNominal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorPago",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorJuros",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorMulta",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosSacadoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosSacadoDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("BoletosSacadoTipoDocumento",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosMensagemDeErro",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosTentativasDeRegistro",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("BoletosResgitroId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003733;
          prmT003733 = new Object[] {
          };
          Object[] prmT003734;
          prmT003734 = new Object[] {
          new ParDef("BoletosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosNossoNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosSeuNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosLinhaDigitavel",GXType.VarChar,54,0){Nullable=true} ,
          new ParDef("BoletosCodigoDeBarras",GXType.VarChar,44,0){Nullable=true} ,
          new ParDef("BoletosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataRegistro",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosDataPagamento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataBaixa",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosValorNominal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorPago",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorJuros",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorMulta",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosSacadoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosSacadoDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("BoletosSacadoTipoDocumento",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosMensagemDeErro",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosTentativasDeRegistro",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("BoletosResgitroId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003735;
          prmT003735 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003736;
          prmT003736 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003738;
          prmT003738 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003740;
          prmT003740 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003742;
          prmT003742 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003744;
          prmT003744 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003745;
          prmT003745 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003746;
          prmT003746 = new Object[] {
          };
          Object[] prmT003747;
          prmT003747 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00372", "SELECT BoletosId, BoletosCreatedAt, BoletosUpdatedAt, BoletosNossoNumero, BoletosSeuNumero, BoletosNumero, BoletosLinhaDigitavel, BoletosCodigoDeBarras, BoletosStatus, BoletosDataEmissao, BoletosDataVencimento, BoletosDataRegistro, BoletosDataPagamento, BoletosDataBaixa, BoletosValorNominal, BoletosValorPago, BoletosValorDesconto, BoletosValorJuros, BoletosValorMulta, BoletosSacadoNome, BoletosSacadoDocumento, BoletosSacadoTipoDocumento, BoletosMensagemDeErro, BoletosTentativasDeRegistro, BoletosResgitroId, CarteiraDeCobrancaId, TituloId FROM Boleto WHERE BoletosId = :BoletosId  FOR UPDATE OF Boleto NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00372,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00373", "SELECT BoletosId, BoletosCreatedAt, BoletosUpdatedAt, BoletosNossoNumero, BoletosSeuNumero, BoletosNumero, BoletosLinhaDigitavel, BoletosCodigoDeBarras, BoletosStatus, BoletosDataEmissao, BoletosDataVencimento, BoletosDataRegistro, BoletosDataPagamento, BoletosDataBaixa, BoletosValorNominal, BoletosValorPago, BoletosValorDesconto, BoletosValorJuros, BoletosValorMulta, BoletosSacadoNome, BoletosSacadoDocumento, BoletosSacadoTipoDocumento, BoletosMensagemDeErro, BoletosTentativasDeRegistro, BoletosResgitroId, CarteiraDeCobrancaId, TituloId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00373,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00374", "SELECT CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00374,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00375", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00375,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00377", "SELECT COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, CarteiraDeCobrancaId, SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00377,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00379", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00379,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003711", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003711,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003713", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003718", cmdBufferT003718,true, GxErrorMask.GX_NOMASK, false, this,prmT003718,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003719", "SELECT CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003719,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003721", "SELECT COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, CarteiraDeCobrancaId, SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003721,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003723", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003723,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003725", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003725,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003727", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003727,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003728", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003728,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003729", "SELECT BoletosId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003729,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003730", "SELECT BoletosId FROM Boleto WHERE ( BoletosId > :BoletosId) ORDER BY BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003730,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003731", "SELECT BoletosId FROM Boleto WHERE ( BoletosId < :BoletosId) ORDER BY BoletosId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT003731,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003732", "SAVEPOINT gxupdate;INSERT INTO Boleto(BoletosCreatedAt, BoletosUpdatedAt, BoletosNossoNumero, BoletosSeuNumero, BoletosNumero, BoletosLinhaDigitavel, BoletosCodigoDeBarras, BoletosStatus, BoletosDataEmissao, BoletosDataVencimento, BoletosDataRegistro, BoletosDataPagamento, BoletosDataBaixa, BoletosValorNominal, BoletosValorPago, BoletosValorDesconto, BoletosValorJuros, BoletosValorMulta, BoletosSacadoNome, BoletosSacadoDocumento, BoletosSacadoTipoDocumento, BoletosMensagemDeErro, BoletosTentativasDeRegistro, BoletosResgitroId, CarteiraDeCobrancaId, TituloId) VALUES(:BoletosCreatedAt, :BoletosUpdatedAt, :BoletosNossoNumero, :BoletosSeuNumero, :BoletosNumero, :BoletosLinhaDigitavel, :BoletosCodigoDeBarras, :BoletosStatus, :BoletosDataEmissao, :BoletosDataVencimento, :BoletosDataRegistro, :BoletosDataPagamento, :BoletosDataBaixa, :BoletosValorNominal, :BoletosValorPago, :BoletosValorDesconto, :BoletosValorJuros, :BoletosValorMulta, :BoletosSacadoNome, :BoletosSacadoDocumento, :BoletosSacadoTipoDocumento, :BoletosMensagemDeErro, :BoletosTentativasDeRegistro, :BoletosResgitroId, :CarteiraDeCobrancaId, :TituloId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003732)
             ,new CursorDef("T003733", "SELECT currval('BoletosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003733,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003734", "SAVEPOINT gxupdate;UPDATE Boleto SET BoletosCreatedAt=:BoletosCreatedAt, BoletosUpdatedAt=:BoletosUpdatedAt, BoletosNossoNumero=:BoletosNossoNumero, BoletosSeuNumero=:BoletosSeuNumero, BoletosNumero=:BoletosNumero, BoletosLinhaDigitavel=:BoletosLinhaDigitavel, BoletosCodigoDeBarras=:BoletosCodigoDeBarras, BoletosStatus=:BoletosStatus, BoletosDataEmissao=:BoletosDataEmissao, BoletosDataVencimento=:BoletosDataVencimento, BoletosDataRegistro=:BoletosDataRegistro, BoletosDataPagamento=:BoletosDataPagamento, BoletosDataBaixa=:BoletosDataBaixa, BoletosValorNominal=:BoletosValorNominal, BoletosValorPago=:BoletosValorPago, BoletosValorDesconto=:BoletosValorDesconto, BoletosValorJuros=:BoletosValorJuros, BoletosValorMulta=:BoletosValorMulta, BoletosSacadoNome=:BoletosSacadoNome, BoletosSacadoDocumento=:BoletosSacadoDocumento, BoletosSacadoTipoDocumento=:BoletosSacadoTipoDocumento, BoletosMensagemDeErro=:BoletosMensagemDeErro, BoletosTentativasDeRegistro=:BoletosTentativasDeRegistro, BoletosResgitroId=:BoletosResgitroId, CarteiraDeCobrancaId=:CarteiraDeCobrancaId, TituloId=:TituloId  WHERE BoletosId = :BoletosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003734)
             ,new CursorDef("T003735", "SAVEPOINT gxupdate;DELETE FROM Boleto  WHERE BoletosId = :BoletosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003735)
             ,new CursorDef("T003736", "SELECT CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003736,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003738", "SELECT COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, CarteiraDeCobrancaId, SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003738,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003740", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003740,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003742", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003742,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003744", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003744,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003745", "SELECT BoletosLogId FROM BoletosLog WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003745,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003746", "SELECT BoletosId FROM Boleto ORDER BY BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003746,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003747", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003747,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getLongVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((Guid[]) buf[47])[0] = rslt.getGuid(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
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
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getLongVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((Guid[]) buf[47])[0] = rslt.getGuid(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
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
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getLongVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((Guid[]) buf[47])[0] = rslt.getGuid(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((bool[]) buf[53])[0] = rslt.getBool(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((int[]) buf[55])[0] = rslt.getInt(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[60])[0] = rslt.getDecimal(32);
                ((int[]) buf[61])[0] = rslt.getInt(33);
                ((int[]) buf[62])[0] = rslt.getInt(34);
                ((bool[]) buf[63])[0] = rslt.wasNull(34);
                ((int[]) buf[64])[0] = rslt.getInt(35);
                ((bool[]) buf[65])[0] = rslt.wasNull(35);
                ((int[]) buf[66])[0] = rslt.getInt(36);
                ((bool[]) buf[67])[0] = rslt.wasNull(36);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 23 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
    }

 }

}
