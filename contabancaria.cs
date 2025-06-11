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
   public class contabancaria : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A951ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A951ContaBancariaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A938AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
            n938AgenciaId = false;
            AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A938AgenciaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A968AgenciaBancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaBancoId"), "."), 18, MidpointRounding.ToEven));
            n968AgenciaBancoId = false;
            AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrimStr( (decimal)(A968AgenciaBancoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A968AgenciaBancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A947ContaBancariaCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n947ContaBancariaCreatedBy = false;
            AssignAttri("", false, "A947ContaBancariaCreatedBy", ((0==A947ContaBancariaCreatedBy)&&IsIns( )||n947ContaBancariaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A947ContaBancariaCreatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A949ContaBancariaUpdatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaUpdatedBy"), "."), 18, MidpointRounding.ToEven));
            n949ContaBancariaUpdatedBy = false;
            AssignAttri("", false, "A949ContaBancariaUpdatedBy", ((0==A949ContaBancariaUpdatedBy)&&IsIns( )||n949ContaBancariaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A949ContaBancariaUpdatedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabancaria")), "contabancaria") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabancaria")))) ;
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
                  AV7ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV7ContaBancariaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaBancariaId), "ZZZZZZZZ9"), context));
                  AV26AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV26AgenciaId", StringUtil.LTrimStr( (decimal)(AV26AgenciaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26AgenciaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Conta Bancaria", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtContaBancariaNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public contabancaria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contabancaria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ContaBancariaId ,
                           int aP2_AgenciaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ContaBancariaId = aP1_ContaBancariaId;
         this.AV26AgenciaId = aP2_AgenciaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbContaBancariaStatus = new GXCombobox();
         cmbContaBancariaRegistraBoletos = new GXCombobox();
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
         if ( cmbContaBancariaStatus.ItemCount > 0 )
         {
            A956ContaBancariaStatus = StringUtil.StrToBool( cmbContaBancariaStatus.getValidValue(StringUtil.BoolToStr( A956ContaBancariaStatus)));
            n956ContaBancariaStatus = false;
            AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbContaBancariaStatus.CurrentValue = StringUtil.BoolToStr( A956ContaBancariaStatus);
            AssignProp("", false, cmbContaBancariaStatus_Internalname, "Values", cmbContaBancariaStatus.ToJavascriptSource(), true);
         }
         if ( cmbContaBancariaRegistraBoletos.ItemCount > 0 )
         {
            A973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cmbContaBancariaRegistraBoletos.getValidValue(StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)));
            n973ContaBancariaRegistraBoletos = false;
            AssignAttri("", false, "A973ContaBancariaRegistraBoletos", A973ContaBancariaRegistraBoletos);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbContaBancariaRegistraBoletos.CurrentValue = StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos);
            AssignProp("", false, cmbContaBancariaRegistraBoletos_Internalname, "Values", cmbContaBancariaRegistraBoletos.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgenciaBancoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgenciaBancoNome_Internalname, "Banco", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgenciaBancoNome_Internalname, A969AgenciaBancoNome, StringUtil.RTrim( context.localUtil.Format( A969AgenciaBancoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaBancoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaBancoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgenciaNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgenciaNumero_Internalname, "Agência", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgenciaNumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", "")), StringUtil.LTrim( ((edtAgenciaNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaNumero_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContaBancariaNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContaBancariaNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaBancariaNumero_Internalname, ((0==A952ContaBancariaNumero)&&IsIns( )||n952ContaBancariaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ",", ""))), ((0==A952ContaBancariaNumero)&&IsIns( )||n952ContaBancariaNumero ? "" : StringUtil.LTrim( ((edtContaBancariaNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A952ContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A952ContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaBancariaNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContaBancariaNumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContaBancariaDigito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContaBancariaDigito_Internalname, "Dígito", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaBancariaDigito_Internalname, ((0==A975ContaBancariaDigito)&&IsIns( )||n975ContaBancariaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ",", ""))), ((0==A975ContaBancariaDigito)&&IsIns( )||n975ContaBancariaDigito ? "" : StringUtil.LTrim( ((edtContaBancariaDigito_Enabled!=0) ? context.localUtil.Format( (decimal)(A975ContaBancariaDigito), "ZZZ9") : context.localUtil.Format( (decimal)(A975ContaBancariaDigito), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaBancariaDigito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContaBancariaDigito_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContaBancariaCarteira_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContaBancariaCarteira_Internalname, "Carteira", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaBancariaCarteira_Internalname, ((0==A953ContaBancariaCarteira)&&IsIns( )||n953ContaBancariaCarteira ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ",", ""))), ((0==A953ContaBancariaCarteira)&&IsIns( )||n953ContaBancariaCarteira ? "" : StringUtil.LTrim( ((edtContaBancariaCarteira_Enabled!=0) ? context.localUtil.Format( (decimal)(A953ContaBancariaCarteira), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A953ContaBancariaCarteira), "ZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaBancariaCarteira_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContaBancariaCarteira_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbContaBancariaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbContaBancariaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbContaBancariaStatus, cmbContaBancariaStatus_Internalname, StringUtil.BoolToStr( A956ContaBancariaStatus), 1, cmbContaBancariaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbContaBancariaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ContaBancaria.htm");
         cmbContaBancariaStatus.CurrentValue = StringUtil.BoolToStr( A956ContaBancariaStatus);
         AssignProp("", false, cmbContaBancariaStatus_Internalname, "Values", (string)(cmbContaBancariaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbContaBancariaRegistraBoletos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbContaBancariaRegistraBoletos_Internalname, "Usa para registro de boletos?", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbContaBancariaRegistraBoletos, cmbContaBancariaRegistraBoletos_Internalname, StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos), 1, cmbContaBancariaRegistraBoletos_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbContaBancariaRegistraBoletos.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ContaBancaria.htm");
         cmbContaBancariaRegistraBoletos.CurrentValue = StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos);
         AssignProp("", false, cmbContaBancariaRegistraBoletos_Internalname, "Values", (string)(cmbContaBancariaRegistraBoletos.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContaBancaria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContaBancaria.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaBancariaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtContaBancariaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaBancariaId_Jsonclick, 0, "Attribute", "", "", "", "", edtContaBancariaId_Visible, edtContaBancariaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ContaBancaria.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgenciaId_Internalname, ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", ""))), ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaId_Jsonclick, 0, "Attribute", "", "", "", "", edtAgenciaId_Visible, edtAgenciaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ContaBancaria.htm");
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
         E112Y2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z951ContaBancariaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z954ContaBancariaCreatedAt = context.localUtil.CToT( cgiGet( "Z954ContaBancariaCreatedAt"), 0);
               n954ContaBancariaCreatedAt = ((DateTime.MinValue==A954ContaBancariaCreatedAt) ? true : false);
               Z955ContaBancariaUpdatedAt = context.localUtil.CToT( cgiGet( "Z955ContaBancariaUpdatedAt"), 0);
               n955ContaBancariaUpdatedAt = ((DateTime.MinValue==A955ContaBancariaUpdatedAt) ? true : false);
               Z952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z952ContaBancariaNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n952ContaBancariaNumero = ((0==A952ContaBancariaNumero) ? true : false);
               Z975ContaBancariaDigito = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z975ContaBancariaDigito"), ",", "."), 18, MidpointRounding.ToEven));
               n975ContaBancariaDigito = ((0==A975ContaBancariaDigito) ? true : false);
               Z953ContaBancariaCarteira = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z953ContaBancariaCarteira"), ",", "."), 18, MidpointRounding.ToEven));
               n953ContaBancariaCarteira = ((0==A953ContaBancariaCarteira) ? true : false);
               Z956ContaBancariaStatus = StringUtil.StrToBool( cgiGet( "Z956ContaBancariaStatus"));
               n956ContaBancariaStatus = ((false==A956ContaBancariaStatus) ? true : false);
               Z973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cgiGet( "Z973ContaBancariaRegistraBoletos"));
               n973ContaBancariaRegistraBoletos = ((false==A973ContaBancariaRegistraBoletos) ? true : false);
               Z938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z938AgenciaId"), ",", "."), 18, MidpointRounding.ToEven));
               n938AgenciaId = ((0==A938AgenciaId) ? true : false);
               Z947ContaBancariaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z947ContaBancariaCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n947ContaBancariaCreatedBy = ((0==A947ContaBancariaCreatedBy) ? true : false);
               Z949ContaBancariaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z949ContaBancariaUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n949ContaBancariaUpdatedBy = ((0==A949ContaBancariaUpdatedBy) ? true : false);
               A954ContaBancariaCreatedAt = context.localUtil.CToT( cgiGet( "Z954ContaBancariaCreatedAt"), 0);
               n954ContaBancariaCreatedAt = false;
               n954ContaBancariaCreatedAt = ((DateTime.MinValue==A954ContaBancariaCreatedAt) ? true : false);
               A955ContaBancariaUpdatedAt = context.localUtil.CToT( cgiGet( "Z955ContaBancariaUpdatedAt"), 0);
               n955ContaBancariaUpdatedAt = false;
               n955ContaBancariaUpdatedAt = ((DateTime.MinValue==A955ContaBancariaUpdatedAt) ? true : false);
               A947ContaBancariaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z947ContaBancariaCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n947ContaBancariaCreatedBy = false;
               n947ContaBancariaCreatedBy = ((0==A947ContaBancariaCreatedBy) ? true : false);
               A949ContaBancariaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z949ContaBancariaUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n949ContaBancariaUpdatedBy = false;
               n949ContaBancariaUpdatedBy = ((0==A949ContaBancariaUpdatedBy) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N938AgenciaId"), ",", "."), 18, MidpointRounding.ToEven));
               n938AgenciaId = ((0==A938AgenciaId) ? true : false);
               N947ContaBancariaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N947ContaBancariaCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n947ContaBancariaCreatedBy = ((0==A947ContaBancariaCreatedBy) ? true : false);
               N949ContaBancariaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N949ContaBancariaUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n949ContaBancariaUpdatedBy = ((0==A949ContaBancariaUpdatedBy) ? true : false);
               A974AgenciaBancoCodigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIABANCOCODIGO"), ",", "."), 18, MidpointRounding.ToEven));
               n974AgenciaBancoCodigo = false;
               A976ContaBancariaDescricao_F = cgiGet( "CONTABANCARIADESCRICAO_F");
               AV7ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONTABANCARIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_AGENCIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_AgenciaId", StringUtil.LTrimStr( (decimal)(AV11Insert_AgenciaId), 9, 0));
               AV26AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vAGENCIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_ContaBancariaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTABANCARIACREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ContaBancariaCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ContaBancariaCreatedBy), 4, 0));
               A947ContaBancariaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIACREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n947ContaBancariaCreatedBy = ((0==A947ContaBancariaCreatedBy) ? true : false);
               AV13Insert_ContaBancariaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTABANCARIAUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ContaBancariaUpdatedBy", StringUtil.LTrimStr( (decimal)(AV13Insert_ContaBancariaUpdatedBy), 4, 0));
               A949ContaBancariaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIAUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n949ContaBancariaUpdatedBy = ((0==A949ContaBancariaUpdatedBy) ? true : false);
               A954ContaBancariaCreatedAt = context.localUtil.CToT( cgiGet( "CONTABANCARIACREATEDAT"), 0);
               n954ContaBancariaCreatedAt = ((DateTime.MinValue==A954ContaBancariaCreatedAt) ? true : false);
               A955ContaBancariaUpdatedAt = context.localUtil.CToT( cgiGet( "CONTABANCARIAUPDATEDAT"), 0);
               n955ContaBancariaUpdatedAt = ((DateTime.MinValue==A955ContaBancariaUpdatedAt) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               A948ContaBancariaCreatedByName = cgiGet( "CONTABANCARIACREATEDBYNAME");
               n948ContaBancariaCreatedByName = false;
               A950ContaBancariaUpdatedByName = cgiGet( "CONTABANCARIAUPDATEDBYNAME");
               n950ContaBancariaUpdatedByName = false;
               A970ContaBancariaCountChavePIX_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIACOUNTCHAVEPIX_F"), ",", "."), 18, MidpointRounding.ToEven));
               n970ContaBancariaCountChavePIX_F = false;
               AV28Pgmname = cgiGet( "vPGMNAME");
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
               A969AgenciaBancoNome = cgiGet( edtAgenciaBancoNome_Internalname);
               n969AgenciaBancoNome = false;
               AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
               A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n939AgenciaNumero = false;
               AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
               n952ContaBancariaNumero = ((StringUtil.StrCmp(cgiGet( edtContaBancariaNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTABANCARIANUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtContaBancariaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A952ContaBancariaNumero = 0;
                  n952ContaBancariaNumero = false;
                  AssignAttri("", false, "A952ContaBancariaNumero", (n952ContaBancariaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
               }
               else
               {
                  A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A952ContaBancariaNumero", (n952ContaBancariaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
               }
               n975ContaBancariaDigito = ((StringUtil.StrCmp(cgiGet( edtContaBancariaDigito_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContaBancariaDigito_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContaBancariaDigito_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTABANCARIADIGITO");
                  AnyError = 1;
                  GX_FocusControl = edtContaBancariaDigito_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A975ContaBancariaDigito = 0;
                  n975ContaBancariaDigito = false;
                  AssignAttri("", false, "A975ContaBancariaDigito", (n975ContaBancariaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ".", ""))));
               }
               else
               {
                  A975ContaBancariaDigito = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaDigito_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A975ContaBancariaDigito", (n975ContaBancariaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ".", ""))));
               }
               n953ContaBancariaCarteira = ((StringUtil.StrCmp(cgiGet( edtContaBancariaCarteira_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContaBancariaCarteira_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContaBancariaCarteira_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTABANCARIACARTEIRA");
                  AnyError = 1;
                  GX_FocusControl = edtContaBancariaCarteira_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A953ContaBancariaCarteira = 0;
                  n953ContaBancariaCarteira = false;
                  AssignAttri("", false, "A953ContaBancariaCarteira", (n953ContaBancariaCarteira ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
               }
               else
               {
                  A953ContaBancariaCarteira = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaCarteira_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A953ContaBancariaCarteira", (n953ContaBancariaCarteira ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
               }
               cmbContaBancariaStatus.CurrentValue = cgiGet( cmbContaBancariaStatus_Internalname);
               A956ContaBancariaStatus = StringUtil.StrToBool( cgiGet( cmbContaBancariaStatus_Internalname));
               n956ContaBancariaStatus = false;
               AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
               n956ContaBancariaStatus = ((false==A956ContaBancariaStatus) ? true : false);
               cmbContaBancariaRegistraBoletos.CurrentValue = cgiGet( cmbContaBancariaRegistraBoletos_Internalname);
               A973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cgiGet( cmbContaBancariaRegistraBoletos_Internalname));
               n973ContaBancariaRegistraBoletos = false;
               AssignAttri("", false, "A973ContaBancariaRegistraBoletos", A973ContaBancariaRegistraBoletos);
               n973ContaBancariaRegistraBoletos = ((false==A973ContaBancariaRegistraBoletos) ? true : false);
               A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = false;
               AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
               n938AgenciaId = ((StringUtil.StrCmp(cgiGet( edtAgenciaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AGENCIAID");
                  AnyError = 1;
                  GX_FocusControl = edtAgenciaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A938AgenciaId = 0;
                  n938AgenciaId = false;
                  AssignAttri("", false, "A938AgenciaId", (n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
               }
               else
               {
                  A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A938AgenciaId", (n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ContaBancaria");
               A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = false;
               AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
               forbiddenHiddens.Add("ContaBancariaId", context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_AgenciaId", context.localUtil.Format( (decimal)(AV11Insert_AgenciaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContaBancariaCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ContaBancariaCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_ContaBancariaUpdatedBy", context.localUtil.Format( (decimal)(AV13Insert_ContaBancariaUpdatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ContaBancariaCreatedAt", context.localUtil.Format( A954ContaBancariaCreatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("ContaBancariaUpdatedAt", context.localUtil.Format( A955ContaBancariaUpdatedAt, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A951ContaBancariaId != Z951ContaBancariaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabancaria:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A951ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
                  n951ContaBancariaId = false;
                  AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
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
                     sMode102 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode102;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound102 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2Y0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONTABANCARIAID");
                        AnyError = 1;
                        GX_FocusControl = edtContaBancariaId_Internalname;
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
                           E112Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122Y2 ();
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
            E122Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2Y102( ) ;
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
            DisableAttributes2Y102( ) ;
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

      protected void CONFIRM_2Y0( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Y102( ) ;
            }
            else
            {
               CheckExtendedTable2Y102( ) ;
               CloseExtendedTableCursors2Y102( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2Y0( )
      {
      }

      protected void E112Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV28Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV29GXV1 = 1;
            AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            while ( AV29GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "AgenciaId") == 0 )
               {
                  AV11Insert_AgenciaId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_AgenciaId", StringUtil.LTrimStr( (decimal)(AV11Insert_AgenciaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ContaBancariaCreatedBy") == 0 )
               {
                  AV12Insert_ContaBancariaCreatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ContaBancariaCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ContaBancariaCreatedBy), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ContaBancariaUpdatedBy") == 0 )
               {
                  AV13Insert_ContaBancariaUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ContaBancariaUpdatedBy", StringUtil.LTrimStr( (decimal)(AV13Insert_ContaBancariaUpdatedBy), 4, 0));
               }
               AV29GXV1 = (int)(AV29GXV1+1);
               AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            }
         }
         edtContaBancariaId_Visible = 0;
         AssignProp("", false, edtContaBancariaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Visible), 5, 0), true);
         edtAgenciaId_Visible = 0;
         AssignProp("", false, edtAgenciaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Visible), 5, 0), true);
      }

      protected void E122Y2( )
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

      protected void ZM2Y102( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z954ContaBancariaCreatedAt = T002Y3_A954ContaBancariaCreatedAt[0];
               Z955ContaBancariaUpdatedAt = T002Y3_A955ContaBancariaUpdatedAt[0];
               Z952ContaBancariaNumero = T002Y3_A952ContaBancariaNumero[0];
               Z975ContaBancariaDigito = T002Y3_A975ContaBancariaDigito[0];
               Z953ContaBancariaCarteira = T002Y3_A953ContaBancariaCarteira[0];
               Z956ContaBancariaStatus = T002Y3_A956ContaBancariaStatus[0];
               Z973ContaBancariaRegistraBoletos = T002Y3_A973ContaBancariaRegistraBoletos[0];
               Z938AgenciaId = T002Y3_A938AgenciaId[0];
               Z947ContaBancariaCreatedBy = T002Y3_A947ContaBancariaCreatedBy[0];
               Z949ContaBancariaUpdatedBy = T002Y3_A949ContaBancariaUpdatedBy[0];
            }
            else
            {
               Z954ContaBancariaCreatedAt = A954ContaBancariaCreatedAt;
               Z955ContaBancariaUpdatedAt = A955ContaBancariaUpdatedAt;
               Z952ContaBancariaNumero = A952ContaBancariaNumero;
               Z975ContaBancariaDigito = A975ContaBancariaDigito;
               Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
               Z956ContaBancariaStatus = A956ContaBancariaStatus;
               Z973ContaBancariaRegistraBoletos = A973ContaBancariaRegistraBoletos;
               Z938AgenciaId = A938AgenciaId;
               Z947ContaBancariaCreatedBy = A947ContaBancariaCreatedBy;
               Z949ContaBancariaUpdatedBy = A949ContaBancariaUpdatedBy;
            }
         }
         if ( GX_JID == -18 )
         {
            Z951ContaBancariaId = A951ContaBancariaId;
            Z954ContaBancariaCreatedAt = A954ContaBancariaCreatedAt;
            Z955ContaBancariaUpdatedAt = A955ContaBancariaUpdatedAt;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z975ContaBancariaDigito = A975ContaBancariaDigito;
            Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
            Z956ContaBancariaStatus = A956ContaBancariaStatus;
            Z973ContaBancariaRegistraBoletos = A973ContaBancariaRegistraBoletos;
            Z938AgenciaId = A938AgenciaId;
            Z947ContaBancariaCreatedBy = A947ContaBancariaCreatedBy;
            Z949ContaBancariaUpdatedBy = A949ContaBancariaUpdatedBy;
            Z948ContaBancariaCreatedByName = A948ContaBancariaCreatedByName;
            Z950ContaBancariaUpdatedByName = A950ContaBancariaUpdatedByName;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z974AgenciaBancoCodigo = A974AgenciaBancoCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtContaBancariaId_Enabled = 0;
         AssignProp("", false, edtContaBancariaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Enabled), 5, 0), true);
         AV28Pgmname = "ContaBancaria";
         AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtContaBancariaId_Enabled = 0;
         AssignProp("", false, edtContaBancariaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ContaBancariaId) )
         {
            A951ContaBancariaId = AV7ContaBancariaId;
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_AgenciaId) )
         {
            edtAgenciaId_Enabled = 0;
            AssignProp("", false, edtAgenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Enabled), 5, 0), true);
         }
         else
         {
            edtAgenciaId_Enabled = 1;
            AssignProp("", false, edtAgenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A954ContaBancariaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n954ContaBancariaCreatedAt = false;
            AssignAttri("", false, "A954ContaBancariaCreatedAt", context.localUtil.TToC( A954ContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A955ContaBancariaUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n955ContaBancariaUpdatedAt = false;
            AssignAttri("", false, "A955ContaBancariaUpdatedAt", context.localUtil.TToC( A955ContaBancariaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
         {
            cmbContaBancariaStatus.Enabled = 0;
            AssignProp("", false, cmbContaBancariaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaBancariaStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbContaBancariaStatus.Enabled = 1;
            AssignProp("", false, cmbContaBancariaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaBancariaStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbContaBancariaStatus.Enabled = 0;
            AssignProp("", false, cmbContaBancariaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaBancariaStatus.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ContaBancariaCreatedBy) )
         {
            A947ContaBancariaCreatedBy = AV12Insert_ContaBancariaCreatedBy;
            n947ContaBancariaCreatedBy = false;
            AssignAttri("", false, "A947ContaBancariaCreatedBy", ((0==A947ContaBancariaCreatedBy)&&IsIns( )||n947ContaBancariaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A947ContaBancariaCreatedBy = AV8WWPContext.gxTpr_Userid;
               n947ContaBancariaCreatedBy = false;
               AssignAttri("", false, "A947ContaBancariaCreatedBy", ((0==A947ContaBancariaCreatedBy)&&IsIns( )||n947ContaBancariaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ContaBancariaUpdatedBy) )
         {
            A949ContaBancariaUpdatedBy = AV13Insert_ContaBancariaUpdatedBy;
            n949ContaBancariaUpdatedBy = false;
            AssignAttri("", false, "A949ContaBancariaUpdatedBy", ((0==A949ContaBancariaUpdatedBy)&&IsIns( )||n949ContaBancariaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A949ContaBancariaUpdatedBy = AV8WWPContext.gxTpr_Userid;
               n949ContaBancariaUpdatedBy = false;
               AssignAttri("", false, "A949ContaBancariaUpdatedBy", ((0==A949ContaBancariaUpdatedBy)&&IsIns( )||n949ContaBancariaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_AgenciaId) )
         {
            A938AgenciaId = AV11Insert_AgenciaId;
            n938AgenciaId = false;
            AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A938AgenciaId = AV26AgenciaId;
               n938AgenciaId = false;
               AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
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
         if ( IsIns( )  && (false==A956ContaBancariaStatus) && ( Gx_BScreen == 0 ) )
         {
            A956ContaBancariaStatus = true;
            n956ContaBancariaStatus = false;
            AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002Y9 */
            pr_default.execute(6, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A970ContaBancariaCountChavePIX_F = T002Y9_A970ContaBancariaCountChavePIX_F[0];
               n970ContaBancariaCountChavePIX_F = T002Y9_n970ContaBancariaCountChavePIX_F[0];
            }
            else
            {
               A970ContaBancariaCountChavePIX_F = 0;
               n970ContaBancariaCountChavePIX_F = false;
               AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
            }
            pr_default.close(6);
            /* Using cursor T002Y5 */
            pr_default.execute(3, new Object[] {n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy});
            A948ContaBancariaCreatedByName = T002Y5_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = T002Y5_n948ContaBancariaCreatedByName[0];
            pr_default.close(3);
            /* Using cursor T002Y6 */
            pr_default.execute(4, new Object[] {n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
            A950ContaBancariaUpdatedByName = T002Y6_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = T002Y6_n950ContaBancariaUpdatedByName[0];
            pr_default.close(4);
            /* Using cursor T002Y4 */
            pr_default.execute(2, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = T002Y4_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002Y4_n968AgenciaBancoId[0];
            A939AgenciaNumero = T002Y4_A939AgenciaNumero[0];
            n939AgenciaNumero = T002Y4_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
            pr_default.close(2);
            /* Using cursor T002Y7 */
            pr_default.execute(5, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T002Y7_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002Y7_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A974AgenciaBancoCodigo = T002Y7_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = T002Y7_n974AgenciaBancoCodigo[0];
            pr_default.close(5);
         }
      }

      protected void Load2Y102( )
      {
         /* Using cursor T002Y11 */
         pr_default.execute(7, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound102 = 1;
            A968AgenciaBancoId = T002Y11_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002Y11_n968AgenciaBancoId[0];
            A954ContaBancariaCreatedAt = T002Y11_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = T002Y11_n954ContaBancariaCreatedAt[0];
            A955ContaBancariaUpdatedAt = T002Y11_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = T002Y11_n955ContaBancariaUpdatedAt[0];
            A939AgenciaNumero = T002Y11_A939AgenciaNumero[0];
            n939AgenciaNumero = T002Y11_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
            A969AgenciaBancoNome = T002Y11_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002Y11_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A952ContaBancariaNumero = T002Y11_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T002Y11_n952ContaBancariaNumero[0];
            AssignAttri("", false, "A952ContaBancariaNumero", ((0==A952ContaBancariaNumero)&&IsIns( )||n952ContaBancariaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
            A975ContaBancariaDigito = T002Y11_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = T002Y11_n975ContaBancariaDigito[0];
            AssignAttri("", false, "A975ContaBancariaDigito", ((0==A975ContaBancariaDigito)&&IsIns( )||n975ContaBancariaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ".", ""))));
            A953ContaBancariaCarteira = T002Y11_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = T002Y11_n953ContaBancariaCarteira[0];
            AssignAttri("", false, "A953ContaBancariaCarteira", ((0==A953ContaBancariaCarteira)&&IsIns( )||n953ContaBancariaCarteira ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
            A956ContaBancariaStatus = T002Y11_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = T002Y11_n956ContaBancariaStatus[0];
            AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
            A948ContaBancariaCreatedByName = T002Y11_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = T002Y11_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = T002Y11_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = T002Y11_n950ContaBancariaUpdatedByName[0];
            A973ContaBancariaRegistraBoletos = T002Y11_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = T002Y11_n973ContaBancariaRegistraBoletos[0];
            AssignAttri("", false, "A973ContaBancariaRegistraBoletos", A973ContaBancariaRegistraBoletos);
            A974AgenciaBancoCodigo = T002Y11_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = T002Y11_n974AgenciaBancoCodigo[0];
            A938AgenciaId = T002Y11_A938AgenciaId[0];
            n938AgenciaId = T002Y11_n938AgenciaId[0];
            AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
            A947ContaBancariaCreatedBy = T002Y11_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = T002Y11_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = T002Y11_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = T002Y11_n949ContaBancariaUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = T002Y11_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Y11_n970ContaBancariaCountChavePIX_F[0];
            ZM2Y102( -18) ;
         }
         pr_default.close(7);
         OnLoadActions2Y102( ) ;
      }

      protected void OnLoadActions2Y102( )
      {
         A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
         AssignAttri("", false, "A976ContaBancariaDescricao_F", A976ContaBancariaDescricao_F);
      }

      protected void CheckExtendedTable2Y102( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T002Y9 */
         pr_default.execute(6, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = T002Y9_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Y9_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
            AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
         }
         pr_default.close(6);
         /* Using cursor T002Y4 */
         pr_default.execute(2, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
               GX_FocusControl = edtAgenciaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A968AgenciaBancoId = T002Y4_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T002Y4_n968AgenciaBancoId[0];
         A939AgenciaNumero = T002Y4_A939AgenciaNumero[0];
         n939AgenciaNumero = T002Y4_n939AgenciaNumero[0];
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         pr_default.close(2);
         /* Using cursor T002Y7 */
         pr_default.execute(5, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002Y7_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002Y7_n969AgenciaBancoNome[0];
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A974AgenciaBancoCodigo = T002Y7_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = T002Y7_n974AgenciaBancoCodigo[0];
         pr_default.close(5);
         A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
         AssignAttri("", false, "A976ContaBancariaDescricao_F", A976ContaBancariaDescricao_F);
         /* Using cursor T002Y5 */
         pr_default.execute(3, new Object[] {n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A947ContaBancariaCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Bancaria Created By'.", "ForeignKeyNotFound", 1, "CONTABANCARIACREATEDBY");
               AnyError = 1;
            }
         }
         A948ContaBancariaCreatedByName = T002Y5_A948ContaBancariaCreatedByName[0];
         n948ContaBancariaCreatedByName = T002Y5_n948ContaBancariaCreatedByName[0];
         pr_default.close(3);
         /* Using cursor T002Y6 */
         pr_default.execute(4, new Object[] {n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A949ContaBancariaUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Bancaria Updated By'.", "ForeignKeyNotFound", 1, "CONTABANCARIAUPDATEDBY");
               AnyError = 1;
            }
         }
         A950ContaBancariaUpdatedByName = T002Y6_A950ContaBancariaUpdatedByName[0];
         n950ContaBancariaUpdatedByName = T002Y6_n950ContaBancariaUpdatedByName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2Y102( )
      {
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_23( int A951ContaBancariaId )
      {
         /* Using cursor T002Y13 */
         pr_default.execute(8, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = T002Y13_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Y13_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
            AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_19( int A938AgenciaId )
      {
         /* Using cursor T002Y14 */
         pr_default.execute(9, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
               GX_FocusControl = edtAgenciaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A968AgenciaBancoId = T002Y14_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T002Y14_n968AgenciaBancoId[0];
         A939AgenciaNumero = T002Y14_A939AgenciaNumero[0];
         n939AgenciaNumero = T002Y14_n939AgenciaNumero[0];
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_22( int A968AgenciaBancoId )
      {
         /* Using cursor T002Y15 */
         pr_default.execute(10, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002Y15_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002Y15_n969AgenciaBancoNome[0];
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A974AgenciaBancoCodigo = T002Y15_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = T002Y15_n974AgenciaBancoCodigo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A969AgenciaBancoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A974AgenciaBancoCodigo), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_20( short A947ContaBancariaCreatedBy )
      {
         /* Using cursor T002Y16 */
         pr_default.execute(11, new Object[] {n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A947ContaBancariaCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Bancaria Created By'.", "ForeignKeyNotFound", 1, "CONTABANCARIACREATEDBY");
               AnyError = 1;
            }
         }
         A948ContaBancariaCreatedByName = T002Y16_A948ContaBancariaCreatedByName[0];
         n948ContaBancariaCreatedByName = T002Y16_n948ContaBancariaCreatedByName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A948ContaBancariaCreatedByName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_21( short A949ContaBancariaUpdatedBy )
      {
         /* Using cursor T002Y17 */
         pr_default.execute(12, new Object[] {n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A949ContaBancariaUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Bancaria Updated By'.", "ForeignKeyNotFound", 1, "CONTABANCARIAUPDATEDBY");
               AnyError = 1;
            }
         }
         A950ContaBancariaUpdatedByName = T002Y17_A950ContaBancariaUpdatedByName[0];
         n950ContaBancariaUpdatedByName = T002Y17_n950ContaBancariaUpdatedByName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A950ContaBancariaUpdatedByName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey2Y102( )
      {
         /* Using cursor T002Y18 */
         pr_default.execute(13, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound102 = 1;
         }
         else
         {
            RcdFound102 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Y3 */
         pr_default.execute(1, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Y102( 18) ;
            RcdFound102 = 1;
            A951ContaBancariaId = T002Y3_A951ContaBancariaId[0];
            n951ContaBancariaId = T002Y3_n951ContaBancariaId[0];
            AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
            A954ContaBancariaCreatedAt = T002Y3_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = T002Y3_n954ContaBancariaCreatedAt[0];
            A955ContaBancariaUpdatedAt = T002Y3_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = T002Y3_n955ContaBancariaUpdatedAt[0];
            A952ContaBancariaNumero = T002Y3_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T002Y3_n952ContaBancariaNumero[0];
            AssignAttri("", false, "A952ContaBancariaNumero", ((0==A952ContaBancariaNumero)&&IsIns( )||n952ContaBancariaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
            A975ContaBancariaDigito = T002Y3_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = T002Y3_n975ContaBancariaDigito[0];
            AssignAttri("", false, "A975ContaBancariaDigito", ((0==A975ContaBancariaDigito)&&IsIns( )||n975ContaBancariaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ".", ""))));
            A953ContaBancariaCarteira = T002Y3_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = T002Y3_n953ContaBancariaCarteira[0];
            AssignAttri("", false, "A953ContaBancariaCarteira", ((0==A953ContaBancariaCarteira)&&IsIns( )||n953ContaBancariaCarteira ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
            A956ContaBancariaStatus = T002Y3_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = T002Y3_n956ContaBancariaStatus[0];
            AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
            A973ContaBancariaRegistraBoletos = T002Y3_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = T002Y3_n973ContaBancariaRegistraBoletos[0];
            AssignAttri("", false, "A973ContaBancariaRegistraBoletos", A973ContaBancariaRegistraBoletos);
            A938AgenciaId = T002Y3_A938AgenciaId[0];
            n938AgenciaId = T002Y3_n938AgenciaId[0];
            AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
            A947ContaBancariaCreatedBy = T002Y3_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = T002Y3_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = T002Y3_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = T002Y3_n949ContaBancariaUpdatedBy[0];
            Z951ContaBancariaId = A951ContaBancariaId;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2Y102( ) ;
            if ( AnyError == 1 )
            {
               RcdFound102 = 0;
               InitializeNonKey2Y102( ) ;
            }
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound102 = 0;
            InitializeNonKey2Y102( ) ;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Y102( ) ;
         if ( RcdFound102 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound102 = 0;
         /* Using cursor T002Y19 */
         pr_default.execute(14, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T002Y19_A951ContaBancariaId[0] < A951ContaBancariaId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T002Y19_A951ContaBancariaId[0] > A951ContaBancariaId ) ) )
            {
               A951ContaBancariaId = T002Y19_A951ContaBancariaId[0];
               n951ContaBancariaId = T002Y19_n951ContaBancariaId[0];
               AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
               RcdFound102 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound102 = 0;
         /* Using cursor T002Y20 */
         pr_default.execute(15, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T002Y20_A951ContaBancariaId[0] > A951ContaBancariaId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T002Y20_A951ContaBancariaId[0] < A951ContaBancariaId ) ) )
            {
               A951ContaBancariaId = T002Y20_A951ContaBancariaId[0];
               n951ContaBancariaId = T002Y20_n951ContaBancariaId[0];
               AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
               RcdFound102 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Y102( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtContaBancariaNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Y102( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound102 == 1 )
            {
               if ( A951ContaBancariaId != Z951ContaBancariaId )
               {
                  A951ContaBancariaId = Z951ContaBancariaId;
                  n951ContaBancariaId = false;
                  AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONTABANCARIAID");
                  AnyError = 1;
                  GX_FocusControl = edtContaBancariaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtContaBancariaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2Y102( ) ;
                  GX_FocusControl = edtContaBancariaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A951ContaBancariaId != Z951ContaBancariaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtContaBancariaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Y102( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONTABANCARIAID");
                     AnyError = 1;
                     GX_FocusControl = edtContaBancariaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtContaBancariaNumero_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Y102( ) ;
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
         if ( A951ContaBancariaId != Z951ContaBancariaId )
         {
            A951ContaBancariaId = Z951ContaBancariaId;
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONTABANCARIAID");
            AnyError = 1;
            GX_FocusControl = edtContaBancariaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtContaBancariaNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2Y102( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Y2 */
            pr_default.execute(0, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContaBancaria"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z954ContaBancariaCreatedAt != T002Y2_A954ContaBancariaCreatedAt[0] ) || ( Z955ContaBancariaUpdatedAt != T002Y2_A955ContaBancariaUpdatedAt[0] ) || ( Z952ContaBancariaNumero != T002Y2_A952ContaBancariaNumero[0] ) || ( Z975ContaBancariaDigito != T002Y2_A975ContaBancariaDigito[0] ) || ( Z953ContaBancariaCarteira != T002Y2_A953ContaBancariaCarteira[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z956ContaBancariaStatus != T002Y2_A956ContaBancariaStatus[0] ) || ( Z973ContaBancariaRegistraBoletos != T002Y2_A973ContaBancariaRegistraBoletos[0] ) || ( Z938AgenciaId != T002Y2_A938AgenciaId[0] ) || ( Z947ContaBancariaCreatedBy != T002Y2_A947ContaBancariaCreatedBy[0] ) || ( Z949ContaBancariaUpdatedBy != T002Y2_A949ContaBancariaUpdatedBy[0] ) )
            {
               if ( Z954ContaBancariaCreatedAt != T002Y2_A954ContaBancariaCreatedAt[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z954ContaBancariaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A954ContaBancariaCreatedAt[0]);
               }
               if ( Z955ContaBancariaUpdatedAt != T002Y2_A955ContaBancariaUpdatedAt[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z955ContaBancariaUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A955ContaBancariaUpdatedAt[0]);
               }
               if ( Z952ContaBancariaNumero != T002Y2_A952ContaBancariaNumero[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaNumero");
                  GXUtil.WriteLogRaw("Old: ",Z952ContaBancariaNumero);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A952ContaBancariaNumero[0]);
               }
               if ( Z975ContaBancariaDigito != T002Y2_A975ContaBancariaDigito[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaDigito");
                  GXUtil.WriteLogRaw("Old: ",Z975ContaBancariaDigito);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A975ContaBancariaDigito[0]);
               }
               if ( Z953ContaBancariaCarteira != T002Y2_A953ContaBancariaCarteira[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaCarteira");
                  GXUtil.WriteLogRaw("Old: ",Z953ContaBancariaCarteira);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A953ContaBancariaCarteira[0]);
               }
               if ( Z956ContaBancariaStatus != T002Y2_A956ContaBancariaStatus[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z956ContaBancariaStatus);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A956ContaBancariaStatus[0]);
               }
               if ( Z973ContaBancariaRegistraBoletos != T002Y2_A973ContaBancariaRegistraBoletos[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaRegistraBoletos");
                  GXUtil.WriteLogRaw("Old: ",Z973ContaBancariaRegistraBoletos);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A973ContaBancariaRegistraBoletos[0]);
               }
               if ( Z938AgenciaId != T002Y2_A938AgenciaId[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"AgenciaId");
                  GXUtil.WriteLogRaw("Old: ",Z938AgenciaId);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A938AgenciaId[0]);
               }
               if ( Z947ContaBancariaCreatedBy != T002Y2_A947ContaBancariaCreatedBy[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z947ContaBancariaCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A947ContaBancariaCreatedBy[0]);
               }
               if ( Z949ContaBancariaUpdatedBy != T002Y2_A949ContaBancariaUpdatedBy[0] )
               {
                  GXUtil.WriteLog("contabancaria:[seudo value changed for attri]"+"ContaBancariaUpdatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z949ContaBancariaUpdatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A949ContaBancariaUpdatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ContaBancaria"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Y102( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Y102( 0) ;
            CheckOptimisticConcurrency2Y102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Y102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Y21 */
                     pr_default.execute(16, new Object[] {n954ContaBancariaCreatedAt, A954ContaBancariaCreatedAt, n955ContaBancariaUpdatedAt, A955ContaBancariaUpdatedAt, n952ContaBancariaNumero, A952ContaBancariaNumero, n975ContaBancariaDigito, A975ContaBancariaDigito, n953ContaBancariaCarteira, A953ContaBancariaCarteira, n956ContaBancariaStatus, A956ContaBancariaStatus, n973ContaBancariaRegistraBoletos, A973ContaBancariaRegistraBoletos, n938AgenciaId, A938AgenciaId, n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy, n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
                     pr_default.close(16);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002Y22 */
                     pr_default.execute(17);
                     A951ContaBancariaId = T002Y22_A951ContaBancariaId[0];
                     n951ContaBancariaId = T002Y22_n951ContaBancariaId[0];
                     AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("ContaBancaria");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2Y0( ) ;
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
               Load2Y102( ) ;
            }
            EndLevel2Y102( ) ;
         }
         CloseExtendedTableCursors2Y102( ) ;
      }

      protected void Update2Y102( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Y102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Y23 */
                     pr_default.execute(18, new Object[] {n954ContaBancariaCreatedAt, A954ContaBancariaCreatedAt, n955ContaBancariaUpdatedAt, A955ContaBancariaUpdatedAt, n952ContaBancariaNumero, A952ContaBancariaNumero, n975ContaBancariaDigito, A975ContaBancariaDigito, n953ContaBancariaCarteira, A953ContaBancariaCarteira, n956ContaBancariaStatus, A956ContaBancariaStatus, n973ContaBancariaRegistraBoletos, A973ContaBancariaRegistraBoletos, n938AgenciaId, A938AgenciaId, n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy, n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy, n951ContaBancariaId, A951ContaBancariaId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("ContaBancaria");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContaBancaria"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Y102( ) ;
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
            EndLevel2Y102( ) ;
         }
         CloseExtendedTableCursors2Y102( ) ;
      }

      protected void DeferredUpdate2Y102( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Y102( ) ;
            AfterConfirm2Y102( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Y102( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Y24 */
                  pr_default.execute(19, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("ContaBancaria");
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
         sMode102 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Y102( ) ;
         Gx_mode = sMode102;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Y102( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002Y26 */
            pr_default.execute(20, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               A970ContaBancariaCountChavePIX_F = T002Y26_A970ContaBancariaCountChavePIX_F[0];
               n970ContaBancariaCountChavePIX_F = T002Y26_n970ContaBancariaCountChavePIX_F[0];
            }
            else
            {
               A970ContaBancariaCountChavePIX_F = 0;
               n970ContaBancariaCountChavePIX_F = false;
               AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
            }
            pr_default.close(20);
            /* Using cursor T002Y27 */
            pr_default.execute(21, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = T002Y27_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002Y27_n968AgenciaBancoId[0];
            A939AgenciaNumero = T002Y27_A939AgenciaNumero[0];
            n939AgenciaNumero = T002Y27_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
            pr_default.close(21);
            /* Using cursor T002Y28 */
            pr_default.execute(22, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T002Y28_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002Y28_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A974AgenciaBancoCodigo = T002Y28_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = T002Y28_n974AgenciaBancoCodigo[0];
            pr_default.close(22);
            A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
            AssignAttri("", false, "A976ContaBancariaDescricao_F", A976ContaBancariaDescricao_F);
            /* Using cursor T002Y29 */
            pr_default.execute(23, new Object[] {n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy});
            A948ContaBancariaCreatedByName = T002Y29_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = T002Y29_n948ContaBancariaCreatedByName[0];
            pr_default.close(23);
            /* Using cursor T002Y30 */
            pr_default.execute(24, new Object[] {n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
            A950ContaBancariaUpdatedByName = T002Y30_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = T002Y30_n950ContaBancariaUpdatedByName[0];
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002Y31 */
            pr_default.execute(25, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T002Y32 */
            pr_default.execute(26, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void EndLevel2Y102( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("contabancaria",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("contabancaria",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Y102( )
      {
         /* Scan By routine */
         /* Using cursor T002Y33 */
         pr_default.execute(27);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound102 = 1;
            A951ContaBancariaId = T002Y33_A951ContaBancariaId[0];
            n951ContaBancariaId = T002Y33_n951ContaBancariaId[0];
            AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Y102( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound102 = 1;
            A951ContaBancariaId = T002Y33_A951ContaBancariaId[0];
            n951ContaBancariaId = T002Y33_n951ContaBancariaId[0];
            AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
         }
      }

      protected void ScanEnd2Y102( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm2Y102( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Y102( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Y102( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Y102( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Y102( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Y102( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Y102( )
      {
         edtAgenciaBancoNome_Enabled = 0;
         AssignProp("", false, edtAgenciaBancoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaBancoNome_Enabled), 5, 0), true);
         edtAgenciaNumero_Enabled = 0;
         AssignProp("", false, edtAgenciaNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaNumero_Enabled), 5, 0), true);
         edtContaBancariaNumero_Enabled = 0;
         AssignProp("", false, edtContaBancariaNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaNumero_Enabled), 5, 0), true);
         edtContaBancariaDigito_Enabled = 0;
         AssignProp("", false, edtContaBancariaDigito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaDigito_Enabled), 5, 0), true);
         edtContaBancariaCarteira_Enabled = 0;
         AssignProp("", false, edtContaBancariaCarteira_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaCarteira_Enabled), 5, 0), true);
         cmbContaBancariaStatus.Enabled = 0;
         AssignProp("", false, cmbContaBancariaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaBancariaStatus.Enabled), 5, 0), true);
         cmbContaBancariaRegistraBoletos.Enabled = 0;
         AssignProp("", false, cmbContaBancariaRegistraBoletos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaBancariaRegistraBoletos.Enabled), 5, 0), true);
         edtContaBancariaId_Enabled = 0;
         AssignProp("", false, edtContaBancariaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Enabled), 5, 0), true);
         edtAgenciaId_Enabled = 0;
         AssignProp("", false, edtAgenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Y102( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Y0( )
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
         GXEncryptionTmp = "contabancaria"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ContaBancariaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV26AgenciaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("contabancaria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ContaBancaria");
         forbiddenHiddens.Add("ContaBancariaId", context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_AgenciaId", context.localUtil.Format( (decimal)(AV11Insert_AgenciaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContaBancariaCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ContaBancariaCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_ContaBancariaUpdatedBy", context.localUtil.Format( (decimal)(AV13Insert_ContaBancariaUpdatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ContaBancariaCreatedAt", context.localUtil.Format( A954ContaBancariaCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("ContaBancariaUpdatedAt", context.localUtil.Format( A955ContaBancariaUpdatedAt, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabancaria:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z951ContaBancariaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z951ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z954ContaBancariaCreatedAt", context.localUtil.TToC( Z954ContaBancariaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z955ContaBancariaUpdatedAt", context.localUtil.TToC( Z955ContaBancariaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z952ContaBancariaNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z952ContaBancariaNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z975ContaBancariaDigito", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z975ContaBancariaDigito), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z953ContaBancariaCarteira", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z953ContaBancariaCarteira), 10, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z956ContaBancariaStatus", Z956ContaBancariaStatus);
         GxWebStd.gx_boolean_hidden_field( context, "Z973ContaBancariaRegistraBoletos", Z973ContaBancariaRegistraBoletos);
         GxWebStd.gx_hidden_field( context, "Z938AgenciaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z938AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z947ContaBancariaCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z947ContaBancariaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z949ContaBancariaUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z949ContaBancariaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N938AgenciaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N947ContaBancariaCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N949ContaBancariaUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "AGENCIABANCOCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A974AgenciaBancoCodigo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIADESCRICAO_F", A976ContaBancariaDescricao_F);
         GxWebStd.gx_hidden_field( context, "vCONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_AGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTABANCARIACREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ContaBancariaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIACREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTABANCARIAUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ContaBancariaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIACREATEDAT", context.localUtil.TToC( A954ContaBancariaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAUPDATEDAT", context.localUtil.TToC( A955ContaBancariaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIACREATEDBYNAME", A948ContaBancariaCreatedByName);
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAUPDATEDBYNAME", A950ContaBancariaUpdatedByName);
         GxWebStd.gx_hidden_field( context, "CONTABANCARIACOUNTCHAVEPIX_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
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
         GXEncryptionTmp = "contabancaria"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ContaBancariaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV26AgenciaId,9,0));
         return formatLink("contabancaria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ContaBancaria" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conta Bancaria" ;
      }

      protected void InitializeNonKey2Y102( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrimStr( (decimal)(A968AgenciaBancoId), 9, 0));
         A938AgenciaId = 0;
         n938AgenciaId = false;
         AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
         n938AgenciaId = ((0==A938AgenciaId) ? true : false);
         A947ContaBancariaCreatedBy = 0;
         n947ContaBancariaCreatedBy = false;
         AssignAttri("", false, "A947ContaBancariaCreatedBy", ((0==A947ContaBancariaCreatedBy)&&IsIns( )||n947ContaBancariaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ".", ""))));
         A949ContaBancariaUpdatedBy = 0;
         n949ContaBancariaUpdatedBy = false;
         AssignAttri("", false, "A949ContaBancariaUpdatedBy", ((0==A949ContaBancariaUpdatedBy)&&IsIns( )||n949ContaBancariaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A949ContaBancariaUpdatedBy), 4, 0, ".", ""))));
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         n954ContaBancariaCreatedAt = false;
         AssignAttri("", false, "A954ContaBancariaCreatedAt", context.localUtil.TToC( A954ContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         n955ContaBancariaUpdatedAt = false;
         AssignAttri("", false, "A955ContaBancariaUpdatedAt", context.localUtil.TToC( A955ContaBancariaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A976ContaBancariaDescricao_F = "";
         AssignAttri("", false, "A976ContaBancariaDescricao_F", A976ContaBancariaDescricao_F);
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A952ContaBancariaNumero = 0;
         n952ContaBancariaNumero = false;
         AssignAttri("", false, "A952ContaBancariaNumero", ((0==A952ContaBancariaNumero)&&IsIns( )||n952ContaBancariaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", ""))));
         n952ContaBancariaNumero = ((0==A952ContaBancariaNumero) ? true : false);
         A975ContaBancariaDigito = 0;
         n975ContaBancariaDigito = false;
         AssignAttri("", false, "A975ContaBancariaDigito", ((0==A975ContaBancariaDigito)&&IsIns( )||n975ContaBancariaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A975ContaBancariaDigito), 4, 0, ".", ""))));
         n975ContaBancariaDigito = ((0==A975ContaBancariaDigito) ? true : false);
         A970ContaBancariaCountChavePIX_F = 0;
         n970ContaBancariaCountChavePIX_F = false;
         AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
         A953ContaBancariaCarteira = 0;
         n953ContaBancariaCarteira = false;
         AssignAttri("", false, "A953ContaBancariaCarteira", ((0==A953ContaBancariaCarteira)&&IsIns( )||n953ContaBancariaCarteira ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", ""))));
         n953ContaBancariaCarteira = ((0==A953ContaBancariaCarteira) ? true : false);
         A948ContaBancariaCreatedByName = "";
         n948ContaBancariaCreatedByName = false;
         AssignAttri("", false, "A948ContaBancariaCreatedByName", A948ContaBancariaCreatedByName);
         A950ContaBancariaUpdatedByName = "";
         n950ContaBancariaUpdatedByName = false;
         AssignAttri("", false, "A950ContaBancariaUpdatedByName", A950ContaBancariaUpdatedByName);
         A973ContaBancariaRegistraBoletos = false;
         n973ContaBancariaRegistraBoletos = false;
         AssignAttri("", false, "A973ContaBancariaRegistraBoletos", A973ContaBancariaRegistraBoletos);
         n973ContaBancariaRegistraBoletos = ((false==A973ContaBancariaRegistraBoletos) ? true : false);
         A974AgenciaBancoCodigo = 0;
         n974AgenciaBancoCodigo = false;
         AssignAttri("", false, "A974AgenciaBancoCodigo", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0));
         A956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
         Z954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         Z955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z952ContaBancariaNumero = 0;
         Z975ContaBancariaDigito = 0;
         Z953ContaBancariaCarteira = 0;
         Z956ContaBancariaStatus = false;
         Z973ContaBancariaRegistraBoletos = false;
         Z938AgenciaId = 0;
         Z947ContaBancariaCreatedBy = 0;
         Z949ContaBancariaUpdatedBy = 0;
      }

      protected void InitAll2Y102( )
      {
         A951ContaBancariaId = 0;
         n951ContaBancariaId = false;
         AssignAttri("", false, "A951ContaBancariaId", StringUtil.LTrimStr( (decimal)(A951ContaBancariaId), 9, 0));
         InitializeNonKey2Y102( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A954ContaBancariaCreatedAt = i954ContaBancariaCreatedAt;
         n954ContaBancariaCreatedAt = false;
         AssignAttri("", false, "A954ContaBancariaCreatedAt", context.localUtil.TToC( A954ContaBancariaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A947ContaBancariaCreatedBy = i947ContaBancariaCreatedBy;
         n947ContaBancariaCreatedBy = false;
         AssignAttri("", false, "A947ContaBancariaCreatedBy", ((0==A947ContaBancariaCreatedBy)&&IsIns( )||n947ContaBancariaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A947ContaBancariaCreatedBy), 4, 0, ".", ""))));
         A938AgenciaId = i938AgenciaId;
         n938AgenciaId = false;
         AssignAttri("", false, "A938AgenciaId", ((0==A938AgenciaId)&&IsIns( )||n938AgenciaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
         A956ContaBancariaStatus = i956ContaBancariaStatus;
         n956ContaBancariaStatus = false;
         AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019215270", true, true);
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
         context.AddJavascriptSource("contabancaria.js", "?202561019215271", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME";
         edtAgenciaNumero_Internalname = "AGENCIANUMERO";
         edtContaBancariaNumero_Internalname = "CONTABANCARIANUMERO";
         edtContaBancariaDigito_Internalname = "CONTABANCARIADIGITO";
         edtContaBancariaCarteira_Internalname = "CONTABANCARIACARTEIRA";
         cmbContaBancariaStatus_Internalname = "CONTABANCARIASTATUS";
         cmbContaBancariaRegistraBoletos_Internalname = "CONTABANCARIAREGISTRABOLETOS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtContaBancariaId_Internalname = "CONTABANCARIAID";
         edtAgenciaId_Internalname = "AGENCIAID";
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
         Form.Caption = "Conta Bancaria";
         edtAgenciaId_Jsonclick = "";
         edtAgenciaId_Enabled = 1;
         edtAgenciaId_Visible = 1;
         edtContaBancariaId_Jsonclick = "";
         edtContaBancariaId_Enabled = 0;
         edtContaBancariaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbContaBancariaRegistraBoletos_Jsonclick = "";
         cmbContaBancariaRegistraBoletos.Enabled = 1;
         cmbContaBancariaStatus_Jsonclick = "";
         cmbContaBancariaStatus.Enabled = 1;
         edtContaBancariaCarteira_Jsonclick = "";
         edtContaBancariaCarteira_Enabled = 1;
         edtContaBancariaDigito_Jsonclick = "";
         edtContaBancariaDigito_Enabled = 1;
         edtContaBancariaNumero_Jsonclick = "";
         edtContaBancariaNumero_Enabled = 1;
         edtAgenciaNumero_Jsonclick = "";
         edtAgenciaNumero_Enabled = 0;
         edtAgenciaBancoNome_Jsonclick = "";
         edtAgenciaBancoNome_Enabled = 0;
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
         cmbContaBancariaStatus.Name = "CONTABANCARIASTATUS";
         cmbContaBancariaStatus.WebTags = "";
         cmbContaBancariaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbContaBancariaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbContaBancariaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A956ContaBancariaStatus) )
            {
               A956ContaBancariaStatus = true;
               n956ContaBancariaStatus = false;
               AssignAttri("", false, "A956ContaBancariaStatus", A956ContaBancariaStatus);
            }
         }
         cmbContaBancariaRegistraBoletos.Name = "CONTABANCARIAREGISTRABOLETOS";
         cmbContaBancariaRegistraBoletos.WebTags = "";
         cmbContaBancariaRegistraBoletos.addItem(StringUtil.BoolToStr( false), "Não", 0);
         cmbContaBancariaRegistraBoletos.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         if ( cmbContaBancariaRegistraBoletos.ItemCount > 0 )
         {
            A973ContaBancariaRegistraBoletos = StringUtil.StrToBool( cmbContaBancariaRegistraBoletos.getValidValue(StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)));
            n973ContaBancariaRegistraBoletos = false;
            AssignAttri("", false, "A973ContaBancariaRegistraBoletos", A973ContaBancariaRegistraBoletos);
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

      public void Valid_Contabancariaid( )
      {
         n951ContaBancariaId = false;
         n970ContaBancariaCountChavePIX_F = false;
         /* Using cursor T002Y26 */
         pr_default.execute(20, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = T002Y26_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Y26_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0, ".", "")));
      }

      public void Valid_Agenciaid( )
      {
         n968AgenciaBancoId = false;
         n974AgenciaBancoCodigo = false;
         n969AgenciaBancoNome = false;
         n939AgenciaNumero = false;
         /* Using cursor T002Y27 */
         pr_default.execute(21, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
               GX_FocusControl = edtAgenciaId_Internalname;
            }
         }
         A968AgenciaBancoId = T002Y27_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T002Y27_n968AgenciaBancoId[0];
         A939AgenciaNumero = T002Y27_A939AgenciaNumero[0];
         n939AgenciaNumero = T002Y27_n939AgenciaNumero[0];
         pr_default.close(21);
         /* Using cursor T002Y28 */
         pr_default.execute(22, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002Y28_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002Y28_n969AgenciaBancoNome[0];
         A974AgenciaBancoCodigo = T002Y28_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = T002Y28_n974AgenciaBancoCodigo[0];
         pr_default.close(22);
         A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", "")));
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", "")));
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         AssignAttri("", false, "A974AgenciaBancoCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A974AgenciaBancoCodigo), 9, 0, ".", "")));
         AssignAttri("", false, "A976ContaBancariaDescricao_F", A976ContaBancariaDescricao_F);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV26AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV26AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_AgenciaId","fld":"vINSERT_AGENCIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_ContaBancariaCreatedBy","fld":"vINSERT_CONTABANCARIACREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV13Insert_ContaBancariaUpdatedBy","fld":"vINSERT_CONTABANCARIAUPDATEDBY","pic":"ZZZ9","type":"int"},{"av":"A954ContaBancariaCreatedAt","fld":"CONTABANCARIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A955ContaBancariaUpdatedAt","fld":"CONTABANCARIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122Y2","iparms":[]}""");
         setEventMetadata("VALID_AGENCIABANCONOME","""{"handler":"Valid_Agenciabanconome","iparms":[]}""");
         setEventMetadata("VALID_AGENCIANUMERO","""{"handler":"Valid_Agencianumero","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIANUMERO","""{"handler":"Valid_Contabancarianumero","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIADIGITO","""{"handler":"Valid_Contabancariadigito","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIAID","""{"handler":"Valid_Contabancariaid","iparms":[{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A970ContaBancariaCountChavePIX_F","fld":"CONTABANCARIACOUNTCHAVEPIX_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_CONTABANCARIAID",""","oparms":[{"av":"A970ContaBancariaCountChavePIX_F","fld":"CONTABANCARIACOUNTCHAVEPIX_F","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_AGENCIAID","""{"handler":"Valid_Agenciaid","iparms":[{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","nullAv":"n938AgenciaId","type":"int"},{"av":"A968AgenciaBancoId","fld":"AGENCIABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A974AgenciaBancoCodigo","fld":"AGENCIABANCOCODIGO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A969AgenciaBancoNome","fld":"AGENCIABANCONOME","type":"svchar"},{"av":"A939AgenciaNumero","fld":"AGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A952ContaBancariaNumero","fld":"CONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","nullAv":"n952ContaBancariaNumero","type":"int"},{"av":"A975ContaBancariaDigito","fld":"CONTABANCARIADIGITO","pic":"ZZZ9","nullAv":"n975ContaBancariaDigito","type":"int"},{"av":"A976ContaBancariaDescricao_F","fld":"CONTABANCARIADESCRICAO_F","type":"svchar"}]""");
         setEventMetadata("VALID_AGENCIAID",""","oparms":[{"av":"A968AgenciaBancoId","fld":"AGENCIABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A939AgenciaNumero","fld":"AGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A969AgenciaBancoNome","fld":"AGENCIABANCONOME","type":"svchar"},{"av":"A974AgenciaBancoCodigo","fld":"AGENCIABANCOCODIGO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A976ContaBancariaDescricao_F","fld":"CONTABANCARIADESCRICAO_F","type":"svchar"}]}""");
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
         pr_default.close(21);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(22);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         Z955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
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
         A969AgenciaBancoNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         A976ContaBancariaDescricao_F = "";
         A948ContaBancariaCreatedByName = "";
         A950ContaBancariaUpdatedByName = "";
         AV28Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode102 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z948ContaBancariaCreatedByName = "";
         Z950ContaBancariaUpdatedByName = "";
         Z969AgenciaBancoNome = "";
         T002Y9_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Y9_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Y5_A948ContaBancariaCreatedByName = new string[] {""} ;
         T002Y5_n948ContaBancariaCreatedByName = new bool[] {false} ;
         T002Y6_A950ContaBancariaUpdatedByName = new string[] {""} ;
         T002Y6_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         T002Y4_A968AgenciaBancoId = new int[1] ;
         T002Y4_n968AgenciaBancoId = new bool[] {false} ;
         T002Y4_A939AgenciaNumero = new int[1] ;
         T002Y4_n939AgenciaNumero = new bool[] {false} ;
         T002Y7_A969AgenciaBancoNome = new string[] {""} ;
         T002Y7_n969AgenciaBancoNome = new bool[] {false} ;
         T002Y7_A974AgenciaBancoCodigo = new int[1] ;
         T002Y7_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002Y11_A968AgenciaBancoId = new int[1] ;
         T002Y11_n968AgenciaBancoId = new bool[] {false} ;
         T002Y11_A951ContaBancariaId = new int[1] ;
         T002Y11_n951ContaBancariaId = new bool[] {false} ;
         T002Y11_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Y11_n954ContaBancariaCreatedAt = new bool[] {false} ;
         T002Y11_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Y11_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         T002Y11_A939AgenciaNumero = new int[1] ;
         T002Y11_n939AgenciaNumero = new bool[] {false} ;
         T002Y11_A969AgenciaBancoNome = new string[] {""} ;
         T002Y11_n969AgenciaBancoNome = new bool[] {false} ;
         T002Y11_A952ContaBancariaNumero = new long[1] ;
         T002Y11_n952ContaBancariaNumero = new bool[] {false} ;
         T002Y11_A975ContaBancariaDigito = new short[1] ;
         T002Y11_n975ContaBancariaDigito = new bool[] {false} ;
         T002Y11_A953ContaBancariaCarteira = new long[1] ;
         T002Y11_n953ContaBancariaCarteira = new bool[] {false} ;
         T002Y11_A956ContaBancariaStatus = new bool[] {false} ;
         T002Y11_n956ContaBancariaStatus = new bool[] {false} ;
         T002Y11_A948ContaBancariaCreatedByName = new string[] {""} ;
         T002Y11_n948ContaBancariaCreatedByName = new bool[] {false} ;
         T002Y11_A950ContaBancariaUpdatedByName = new string[] {""} ;
         T002Y11_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         T002Y11_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         T002Y11_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         T002Y11_A974AgenciaBancoCodigo = new int[1] ;
         T002Y11_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002Y11_A938AgenciaId = new int[1] ;
         T002Y11_n938AgenciaId = new bool[] {false} ;
         T002Y11_A947ContaBancariaCreatedBy = new short[1] ;
         T002Y11_n947ContaBancariaCreatedBy = new bool[] {false} ;
         T002Y11_A949ContaBancariaUpdatedBy = new short[1] ;
         T002Y11_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         T002Y11_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Y11_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Y13_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Y13_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Y14_A968AgenciaBancoId = new int[1] ;
         T002Y14_n968AgenciaBancoId = new bool[] {false} ;
         T002Y14_A939AgenciaNumero = new int[1] ;
         T002Y14_n939AgenciaNumero = new bool[] {false} ;
         T002Y15_A969AgenciaBancoNome = new string[] {""} ;
         T002Y15_n969AgenciaBancoNome = new bool[] {false} ;
         T002Y15_A974AgenciaBancoCodigo = new int[1] ;
         T002Y15_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002Y16_A948ContaBancariaCreatedByName = new string[] {""} ;
         T002Y16_n948ContaBancariaCreatedByName = new bool[] {false} ;
         T002Y17_A950ContaBancariaUpdatedByName = new string[] {""} ;
         T002Y17_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         T002Y18_A951ContaBancariaId = new int[1] ;
         T002Y18_n951ContaBancariaId = new bool[] {false} ;
         T002Y3_A951ContaBancariaId = new int[1] ;
         T002Y3_n951ContaBancariaId = new bool[] {false} ;
         T002Y3_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Y3_n954ContaBancariaCreatedAt = new bool[] {false} ;
         T002Y3_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Y3_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         T002Y3_A952ContaBancariaNumero = new long[1] ;
         T002Y3_n952ContaBancariaNumero = new bool[] {false} ;
         T002Y3_A975ContaBancariaDigito = new short[1] ;
         T002Y3_n975ContaBancariaDigito = new bool[] {false} ;
         T002Y3_A953ContaBancariaCarteira = new long[1] ;
         T002Y3_n953ContaBancariaCarteira = new bool[] {false} ;
         T002Y3_A956ContaBancariaStatus = new bool[] {false} ;
         T002Y3_n956ContaBancariaStatus = new bool[] {false} ;
         T002Y3_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         T002Y3_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         T002Y3_A938AgenciaId = new int[1] ;
         T002Y3_n938AgenciaId = new bool[] {false} ;
         T002Y3_A947ContaBancariaCreatedBy = new short[1] ;
         T002Y3_n947ContaBancariaCreatedBy = new bool[] {false} ;
         T002Y3_A949ContaBancariaUpdatedBy = new short[1] ;
         T002Y3_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         T002Y19_A951ContaBancariaId = new int[1] ;
         T002Y19_n951ContaBancariaId = new bool[] {false} ;
         T002Y20_A951ContaBancariaId = new int[1] ;
         T002Y20_n951ContaBancariaId = new bool[] {false} ;
         T002Y2_A951ContaBancariaId = new int[1] ;
         T002Y2_n951ContaBancariaId = new bool[] {false} ;
         T002Y2_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Y2_n954ContaBancariaCreatedAt = new bool[] {false} ;
         T002Y2_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Y2_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         T002Y2_A952ContaBancariaNumero = new long[1] ;
         T002Y2_n952ContaBancariaNumero = new bool[] {false} ;
         T002Y2_A975ContaBancariaDigito = new short[1] ;
         T002Y2_n975ContaBancariaDigito = new bool[] {false} ;
         T002Y2_A953ContaBancariaCarteira = new long[1] ;
         T002Y2_n953ContaBancariaCarteira = new bool[] {false} ;
         T002Y2_A956ContaBancariaStatus = new bool[] {false} ;
         T002Y2_n956ContaBancariaStatus = new bool[] {false} ;
         T002Y2_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         T002Y2_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         T002Y2_A938AgenciaId = new int[1] ;
         T002Y2_n938AgenciaId = new bool[] {false} ;
         T002Y2_A947ContaBancariaCreatedBy = new short[1] ;
         T002Y2_n947ContaBancariaCreatedBy = new bool[] {false} ;
         T002Y2_A949ContaBancariaUpdatedBy = new short[1] ;
         T002Y2_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         T002Y22_A951ContaBancariaId = new int[1] ;
         T002Y22_n951ContaBancariaId = new bool[] {false} ;
         T002Y26_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Y26_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Y27_A968AgenciaBancoId = new int[1] ;
         T002Y27_n968AgenciaBancoId = new bool[] {false} ;
         T002Y27_A939AgenciaNumero = new int[1] ;
         T002Y27_n939AgenciaNumero = new bool[] {false} ;
         T002Y28_A969AgenciaBancoNome = new string[] {""} ;
         T002Y28_n969AgenciaBancoNome = new bool[] {false} ;
         T002Y28_A974AgenciaBancoCodigo = new int[1] ;
         T002Y28_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002Y29_A948ContaBancariaCreatedByName = new string[] {""} ;
         T002Y29_n948ContaBancariaCreatedByName = new bool[] {false} ;
         T002Y30_A950ContaBancariaUpdatedByName = new string[] {""} ;
         T002Y30_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         T002Y31_A961ChavePIXId = new int[1] ;
         T002Y32_A261TituloId = new int[1] ;
         T002Y33_A951ContaBancariaId = new int[1] ;
         T002Y33_n951ContaBancariaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         Z976ContaBancariaDescricao_F = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabancaria__default(),
            new Object[][] {
                new Object[] {
               T002Y2_A951ContaBancariaId, T002Y2_A954ContaBancariaCreatedAt, T002Y2_n954ContaBancariaCreatedAt, T002Y2_A955ContaBancariaUpdatedAt, T002Y2_n955ContaBancariaUpdatedAt, T002Y2_A952ContaBancariaNumero, T002Y2_n952ContaBancariaNumero, T002Y2_A975ContaBancariaDigito, T002Y2_n975ContaBancariaDigito, T002Y2_A953ContaBancariaCarteira,
               T002Y2_n953ContaBancariaCarteira, T002Y2_A956ContaBancariaStatus, T002Y2_n956ContaBancariaStatus, T002Y2_A973ContaBancariaRegistraBoletos, T002Y2_n973ContaBancariaRegistraBoletos, T002Y2_A938AgenciaId, T002Y2_n938AgenciaId, T002Y2_A947ContaBancariaCreatedBy, T002Y2_n947ContaBancariaCreatedBy, T002Y2_A949ContaBancariaUpdatedBy,
               T002Y2_n949ContaBancariaUpdatedBy
               }
               , new Object[] {
               T002Y3_A951ContaBancariaId, T002Y3_A954ContaBancariaCreatedAt, T002Y3_n954ContaBancariaCreatedAt, T002Y3_A955ContaBancariaUpdatedAt, T002Y3_n955ContaBancariaUpdatedAt, T002Y3_A952ContaBancariaNumero, T002Y3_n952ContaBancariaNumero, T002Y3_A975ContaBancariaDigito, T002Y3_n975ContaBancariaDigito, T002Y3_A953ContaBancariaCarteira,
               T002Y3_n953ContaBancariaCarteira, T002Y3_A956ContaBancariaStatus, T002Y3_n956ContaBancariaStatus, T002Y3_A973ContaBancariaRegistraBoletos, T002Y3_n973ContaBancariaRegistraBoletos, T002Y3_A938AgenciaId, T002Y3_n938AgenciaId, T002Y3_A947ContaBancariaCreatedBy, T002Y3_n947ContaBancariaCreatedBy, T002Y3_A949ContaBancariaUpdatedBy,
               T002Y3_n949ContaBancariaUpdatedBy
               }
               , new Object[] {
               T002Y4_A968AgenciaBancoId, T002Y4_n968AgenciaBancoId, T002Y4_A939AgenciaNumero, T002Y4_n939AgenciaNumero
               }
               , new Object[] {
               T002Y5_A948ContaBancariaCreatedByName, T002Y5_n948ContaBancariaCreatedByName
               }
               , new Object[] {
               T002Y6_A950ContaBancariaUpdatedByName, T002Y6_n950ContaBancariaUpdatedByName
               }
               , new Object[] {
               T002Y7_A969AgenciaBancoNome, T002Y7_n969AgenciaBancoNome, T002Y7_A974AgenciaBancoCodigo, T002Y7_n974AgenciaBancoCodigo
               }
               , new Object[] {
               T002Y9_A970ContaBancariaCountChavePIX_F, T002Y9_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Y11_A968AgenciaBancoId, T002Y11_n968AgenciaBancoId, T002Y11_A951ContaBancariaId, T002Y11_A954ContaBancariaCreatedAt, T002Y11_n954ContaBancariaCreatedAt, T002Y11_A955ContaBancariaUpdatedAt, T002Y11_n955ContaBancariaUpdatedAt, T002Y11_A939AgenciaNumero, T002Y11_n939AgenciaNumero, T002Y11_A969AgenciaBancoNome,
               T002Y11_n969AgenciaBancoNome, T002Y11_A952ContaBancariaNumero, T002Y11_n952ContaBancariaNumero, T002Y11_A975ContaBancariaDigito, T002Y11_n975ContaBancariaDigito, T002Y11_A953ContaBancariaCarteira, T002Y11_n953ContaBancariaCarteira, T002Y11_A956ContaBancariaStatus, T002Y11_n956ContaBancariaStatus, T002Y11_A948ContaBancariaCreatedByName,
               T002Y11_n948ContaBancariaCreatedByName, T002Y11_A950ContaBancariaUpdatedByName, T002Y11_n950ContaBancariaUpdatedByName, T002Y11_A973ContaBancariaRegistraBoletos, T002Y11_n973ContaBancariaRegistraBoletos, T002Y11_A974AgenciaBancoCodigo, T002Y11_n974AgenciaBancoCodigo, T002Y11_A938AgenciaId, T002Y11_n938AgenciaId, T002Y11_A947ContaBancariaCreatedBy,
               T002Y11_n947ContaBancariaCreatedBy, T002Y11_A949ContaBancariaUpdatedBy, T002Y11_n949ContaBancariaUpdatedBy, T002Y11_A970ContaBancariaCountChavePIX_F, T002Y11_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Y13_A970ContaBancariaCountChavePIX_F, T002Y13_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Y14_A968AgenciaBancoId, T002Y14_n968AgenciaBancoId, T002Y14_A939AgenciaNumero, T002Y14_n939AgenciaNumero
               }
               , new Object[] {
               T002Y15_A969AgenciaBancoNome, T002Y15_n969AgenciaBancoNome, T002Y15_A974AgenciaBancoCodigo, T002Y15_n974AgenciaBancoCodigo
               }
               , new Object[] {
               T002Y16_A948ContaBancariaCreatedByName, T002Y16_n948ContaBancariaCreatedByName
               }
               , new Object[] {
               T002Y17_A950ContaBancariaUpdatedByName, T002Y17_n950ContaBancariaUpdatedByName
               }
               , new Object[] {
               T002Y18_A951ContaBancariaId
               }
               , new Object[] {
               T002Y19_A951ContaBancariaId
               }
               , new Object[] {
               T002Y20_A951ContaBancariaId
               }
               , new Object[] {
               }
               , new Object[] {
               T002Y22_A951ContaBancariaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Y26_A970ContaBancariaCountChavePIX_F, T002Y26_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Y27_A968AgenciaBancoId, T002Y27_n968AgenciaBancoId, T002Y27_A939AgenciaNumero, T002Y27_n939AgenciaNumero
               }
               , new Object[] {
               T002Y28_A969AgenciaBancoNome, T002Y28_n969AgenciaBancoNome, T002Y28_A974AgenciaBancoCodigo, T002Y28_n974AgenciaBancoCodigo
               }
               , new Object[] {
               T002Y29_A948ContaBancariaCreatedByName, T002Y29_n948ContaBancariaCreatedByName
               }
               , new Object[] {
               T002Y30_A950ContaBancariaUpdatedByName, T002Y30_n950ContaBancariaUpdatedByName
               }
               , new Object[] {
               T002Y31_A961ChavePIXId
               }
               , new Object[] {
               T002Y32_A261TituloId
               }
               , new Object[] {
               T002Y33_A951ContaBancariaId
               }
            }
         );
         AV28Pgmname = "ContaBancaria";
         Z956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         A956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         i956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
      }

      private short Z975ContaBancariaDigito ;
      private short Z947ContaBancariaCreatedBy ;
      private short Z949ContaBancariaUpdatedBy ;
      private short N947ContaBancariaCreatedBy ;
      private short N949ContaBancariaUpdatedBy ;
      private short GxWebError ;
      private short A947ContaBancariaCreatedBy ;
      private short A949ContaBancariaUpdatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A975ContaBancariaDigito ;
      private short AV12Insert_ContaBancariaCreatedBy ;
      private short AV13Insert_ContaBancariaUpdatedBy ;
      private short Gx_BScreen ;
      private short A970ContaBancariaCountChavePIX_F ;
      private short RcdFound102 ;
      private short Z970ContaBancariaCountChavePIX_F ;
      private short gxajaxcallmode ;
      private short i947ContaBancariaCreatedBy ;
      private int wcpOAV7ContaBancariaId ;
      private int wcpOAV26AgenciaId ;
      private int Z951ContaBancariaId ;
      private int Z938AgenciaId ;
      private int N938AgenciaId ;
      private int A951ContaBancariaId ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int AV7ContaBancariaId ;
      private int AV26AgenciaId ;
      private int trnEnded ;
      private int edtAgenciaBancoNome_Enabled ;
      private int A939AgenciaNumero ;
      private int edtAgenciaNumero_Enabled ;
      private int edtContaBancariaNumero_Enabled ;
      private int edtContaBancariaDigito_Enabled ;
      private int edtContaBancariaCarteira_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtContaBancariaId_Enabled ;
      private int edtContaBancariaId_Visible ;
      private int edtAgenciaId_Visible ;
      private int edtAgenciaId_Enabled ;
      private int A974AgenciaBancoCodigo ;
      private int AV11Insert_AgenciaId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV29GXV1 ;
      private int Z968AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int Z974AgenciaBancoCodigo ;
      private int i938AgenciaId ;
      private int idxLst ;
      private long Z952ContaBancariaNumero ;
      private long Z953ContaBancariaCarteira ;
      private long A952ContaBancariaNumero ;
      private long A953ContaBancariaCarteira ;
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
      private string edtContaBancariaNumero_Internalname ;
      private string cmbContaBancariaStatus_Internalname ;
      private string cmbContaBancariaRegistraBoletos_Internalname ;
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
      private string edtAgenciaBancoNome_Internalname ;
      private string TempTags ;
      private string edtAgenciaBancoNome_Jsonclick ;
      private string edtAgenciaNumero_Internalname ;
      private string edtAgenciaNumero_Jsonclick ;
      private string edtContaBancariaNumero_Jsonclick ;
      private string edtContaBancariaDigito_Internalname ;
      private string edtContaBancariaDigito_Jsonclick ;
      private string edtContaBancariaCarteira_Internalname ;
      private string edtContaBancariaCarteira_Jsonclick ;
      private string cmbContaBancariaStatus_Jsonclick ;
      private string cmbContaBancariaRegistraBoletos_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtContaBancariaId_Internalname ;
      private string edtContaBancariaId_Jsonclick ;
      private string edtAgenciaId_Internalname ;
      private string edtAgenciaId_Jsonclick ;
      private string AV28Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode102 ;
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
      private DateTime Z954ContaBancariaCreatedAt ;
      private DateTime Z955ContaBancariaUpdatedAt ;
      private DateTime A954ContaBancariaCreatedAt ;
      private DateTime A955ContaBancariaUpdatedAt ;
      private DateTime i954ContaBancariaCreatedAt ;
      private bool Z956ContaBancariaStatus ;
      private bool Z973ContaBancariaRegistraBoletos ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n951ContaBancariaId ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n947ContaBancariaCreatedBy ;
      private bool n949ContaBancariaUpdatedBy ;
      private bool wbErr ;
      private bool A956ContaBancariaStatus ;
      private bool n956ContaBancariaStatus ;
      private bool A973ContaBancariaRegistraBoletos ;
      private bool n973ContaBancariaRegistraBoletos ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n952ContaBancariaNumero ;
      private bool n975ContaBancariaDigito ;
      private bool n953ContaBancariaCarteira ;
      private bool n954ContaBancariaCreatedAt ;
      private bool n955ContaBancariaUpdatedAt ;
      private bool n974AgenciaBancoCodigo ;
      private bool n948ContaBancariaCreatedByName ;
      private bool n950ContaBancariaUpdatedByName ;
      private bool n970ContaBancariaCountChavePIX_F ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n969AgenciaBancoNome ;
      private bool n939AgenciaNumero ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i956ContaBancariaStatus ;
      private string A969AgenciaBancoNome ;
      private string A976ContaBancariaDescricao_F ;
      private string A948ContaBancariaCreatedByName ;
      private string A950ContaBancariaUpdatedByName ;
      private string Z948ContaBancariaCreatedByName ;
      private string Z950ContaBancariaUpdatedByName ;
      private string Z969AgenciaBancoNome ;
      private string Z976ContaBancariaDescricao_F ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbContaBancariaStatus ;
      private GXCombobox cmbContaBancariaRegistraBoletos ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T002Y9_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Y9_n970ContaBancariaCountChavePIX_F ;
      private string[] T002Y5_A948ContaBancariaCreatedByName ;
      private bool[] T002Y5_n948ContaBancariaCreatedByName ;
      private string[] T002Y6_A950ContaBancariaUpdatedByName ;
      private bool[] T002Y6_n950ContaBancariaUpdatedByName ;
      private int[] T002Y4_A968AgenciaBancoId ;
      private bool[] T002Y4_n968AgenciaBancoId ;
      private int[] T002Y4_A939AgenciaNumero ;
      private bool[] T002Y4_n939AgenciaNumero ;
      private string[] T002Y7_A969AgenciaBancoNome ;
      private bool[] T002Y7_n969AgenciaBancoNome ;
      private int[] T002Y7_A974AgenciaBancoCodigo ;
      private bool[] T002Y7_n974AgenciaBancoCodigo ;
      private int[] T002Y11_A968AgenciaBancoId ;
      private bool[] T002Y11_n968AgenciaBancoId ;
      private int[] T002Y11_A951ContaBancariaId ;
      private bool[] T002Y11_n951ContaBancariaId ;
      private DateTime[] T002Y11_A954ContaBancariaCreatedAt ;
      private bool[] T002Y11_n954ContaBancariaCreatedAt ;
      private DateTime[] T002Y11_A955ContaBancariaUpdatedAt ;
      private bool[] T002Y11_n955ContaBancariaUpdatedAt ;
      private int[] T002Y11_A939AgenciaNumero ;
      private bool[] T002Y11_n939AgenciaNumero ;
      private string[] T002Y11_A969AgenciaBancoNome ;
      private bool[] T002Y11_n969AgenciaBancoNome ;
      private long[] T002Y11_A952ContaBancariaNumero ;
      private bool[] T002Y11_n952ContaBancariaNumero ;
      private short[] T002Y11_A975ContaBancariaDigito ;
      private bool[] T002Y11_n975ContaBancariaDigito ;
      private long[] T002Y11_A953ContaBancariaCarteira ;
      private bool[] T002Y11_n953ContaBancariaCarteira ;
      private bool[] T002Y11_A956ContaBancariaStatus ;
      private bool[] T002Y11_n956ContaBancariaStatus ;
      private string[] T002Y11_A948ContaBancariaCreatedByName ;
      private bool[] T002Y11_n948ContaBancariaCreatedByName ;
      private string[] T002Y11_A950ContaBancariaUpdatedByName ;
      private bool[] T002Y11_n950ContaBancariaUpdatedByName ;
      private bool[] T002Y11_A973ContaBancariaRegistraBoletos ;
      private bool[] T002Y11_n973ContaBancariaRegistraBoletos ;
      private int[] T002Y11_A974AgenciaBancoCodigo ;
      private bool[] T002Y11_n974AgenciaBancoCodigo ;
      private int[] T002Y11_A938AgenciaId ;
      private bool[] T002Y11_n938AgenciaId ;
      private short[] T002Y11_A947ContaBancariaCreatedBy ;
      private bool[] T002Y11_n947ContaBancariaCreatedBy ;
      private short[] T002Y11_A949ContaBancariaUpdatedBy ;
      private bool[] T002Y11_n949ContaBancariaUpdatedBy ;
      private short[] T002Y11_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Y11_n970ContaBancariaCountChavePIX_F ;
      private short[] T002Y13_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Y13_n970ContaBancariaCountChavePIX_F ;
      private int[] T002Y14_A968AgenciaBancoId ;
      private bool[] T002Y14_n968AgenciaBancoId ;
      private int[] T002Y14_A939AgenciaNumero ;
      private bool[] T002Y14_n939AgenciaNumero ;
      private string[] T002Y15_A969AgenciaBancoNome ;
      private bool[] T002Y15_n969AgenciaBancoNome ;
      private int[] T002Y15_A974AgenciaBancoCodigo ;
      private bool[] T002Y15_n974AgenciaBancoCodigo ;
      private string[] T002Y16_A948ContaBancariaCreatedByName ;
      private bool[] T002Y16_n948ContaBancariaCreatedByName ;
      private string[] T002Y17_A950ContaBancariaUpdatedByName ;
      private bool[] T002Y17_n950ContaBancariaUpdatedByName ;
      private int[] T002Y18_A951ContaBancariaId ;
      private bool[] T002Y18_n951ContaBancariaId ;
      private int[] T002Y3_A951ContaBancariaId ;
      private bool[] T002Y3_n951ContaBancariaId ;
      private DateTime[] T002Y3_A954ContaBancariaCreatedAt ;
      private bool[] T002Y3_n954ContaBancariaCreatedAt ;
      private DateTime[] T002Y3_A955ContaBancariaUpdatedAt ;
      private bool[] T002Y3_n955ContaBancariaUpdatedAt ;
      private long[] T002Y3_A952ContaBancariaNumero ;
      private bool[] T002Y3_n952ContaBancariaNumero ;
      private short[] T002Y3_A975ContaBancariaDigito ;
      private bool[] T002Y3_n975ContaBancariaDigito ;
      private long[] T002Y3_A953ContaBancariaCarteira ;
      private bool[] T002Y3_n953ContaBancariaCarteira ;
      private bool[] T002Y3_A956ContaBancariaStatus ;
      private bool[] T002Y3_n956ContaBancariaStatus ;
      private bool[] T002Y3_A973ContaBancariaRegistraBoletos ;
      private bool[] T002Y3_n973ContaBancariaRegistraBoletos ;
      private int[] T002Y3_A938AgenciaId ;
      private bool[] T002Y3_n938AgenciaId ;
      private short[] T002Y3_A947ContaBancariaCreatedBy ;
      private bool[] T002Y3_n947ContaBancariaCreatedBy ;
      private short[] T002Y3_A949ContaBancariaUpdatedBy ;
      private bool[] T002Y3_n949ContaBancariaUpdatedBy ;
      private int[] T002Y19_A951ContaBancariaId ;
      private bool[] T002Y19_n951ContaBancariaId ;
      private int[] T002Y20_A951ContaBancariaId ;
      private bool[] T002Y20_n951ContaBancariaId ;
      private int[] T002Y2_A951ContaBancariaId ;
      private bool[] T002Y2_n951ContaBancariaId ;
      private DateTime[] T002Y2_A954ContaBancariaCreatedAt ;
      private bool[] T002Y2_n954ContaBancariaCreatedAt ;
      private DateTime[] T002Y2_A955ContaBancariaUpdatedAt ;
      private bool[] T002Y2_n955ContaBancariaUpdatedAt ;
      private long[] T002Y2_A952ContaBancariaNumero ;
      private bool[] T002Y2_n952ContaBancariaNumero ;
      private short[] T002Y2_A975ContaBancariaDigito ;
      private bool[] T002Y2_n975ContaBancariaDigito ;
      private long[] T002Y2_A953ContaBancariaCarteira ;
      private bool[] T002Y2_n953ContaBancariaCarteira ;
      private bool[] T002Y2_A956ContaBancariaStatus ;
      private bool[] T002Y2_n956ContaBancariaStatus ;
      private bool[] T002Y2_A973ContaBancariaRegistraBoletos ;
      private bool[] T002Y2_n973ContaBancariaRegistraBoletos ;
      private int[] T002Y2_A938AgenciaId ;
      private bool[] T002Y2_n938AgenciaId ;
      private short[] T002Y2_A947ContaBancariaCreatedBy ;
      private bool[] T002Y2_n947ContaBancariaCreatedBy ;
      private short[] T002Y2_A949ContaBancariaUpdatedBy ;
      private bool[] T002Y2_n949ContaBancariaUpdatedBy ;
      private int[] T002Y22_A951ContaBancariaId ;
      private bool[] T002Y22_n951ContaBancariaId ;
      private short[] T002Y26_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Y26_n970ContaBancariaCountChavePIX_F ;
      private int[] T002Y27_A968AgenciaBancoId ;
      private bool[] T002Y27_n968AgenciaBancoId ;
      private int[] T002Y27_A939AgenciaNumero ;
      private bool[] T002Y27_n939AgenciaNumero ;
      private string[] T002Y28_A969AgenciaBancoNome ;
      private bool[] T002Y28_n969AgenciaBancoNome ;
      private int[] T002Y28_A974AgenciaBancoCodigo ;
      private bool[] T002Y28_n974AgenciaBancoCodigo ;
      private string[] T002Y29_A948ContaBancariaCreatedByName ;
      private bool[] T002Y29_n948ContaBancariaCreatedByName ;
      private string[] T002Y30_A950ContaBancariaUpdatedByName ;
      private bool[] T002Y30_n950ContaBancariaUpdatedByName ;
      private int[] T002Y31_A961ChavePIXId ;
      private int[] T002Y32_A261TituloId ;
      private int[] T002Y33_A951ContaBancariaId ;
      private bool[] T002Y33_n951ContaBancariaId ;
   }

   public class contabancaria__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
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
          Object[] prmT002Y2;
          prmT002Y2 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y3;
          prmT002Y3 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y4;
          prmT002Y4 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y5;
          prmT002Y5 = new Object[] {
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y6;
          prmT002Y6 = new Object[] {
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y7;
          prmT002Y7 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y9;
          prmT002Y9 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y11;
          prmT002Y11 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y13;
          prmT002Y13 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y14;
          prmT002Y14 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y15;
          prmT002Y15 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y16;
          prmT002Y16 = new Object[] {
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y17;
          prmT002Y17 = new Object[] {
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y18;
          prmT002Y18 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y19;
          prmT002Y19 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y20;
          prmT002Y20 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y21;
          prmT002Y21 = new Object[] {
          new ParDef("ContaBancariaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContaBancariaDigito",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaCarteira",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("ContaBancariaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaRegistraBoletos",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y22;
          prmT002Y22 = new Object[] {
          };
          Object[] prmT002Y23;
          prmT002Y23 = new Object[] {
          new ParDef("ContaBancariaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContaBancariaDigito",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaCarteira",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("ContaBancariaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaRegistraBoletos",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y24;
          prmT002Y24 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y26;
          prmT002Y26 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y27;
          prmT002Y27 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y28;
          prmT002Y28 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y29;
          prmT002Y29 = new Object[] {
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y30;
          prmT002Y30 = new Object[] {
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Y31;
          prmT002Y31 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y32;
          prmT002Y32 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Y33;
          prmT002Y33 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002Y2", "SELECT ContaBancariaId, ContaBancariaCreatedAt, ContaBancariaUpdatedAt, ContaBancariaNumero, ContaBancariaDigito, ContaBancariaCarteira, ContaBancariaStatus, ContaBancariaRegistraBoletos, AgenciaId, ContaBancariaCreatedBy, ContaBancariaUpdatedBy FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId  FOR UPDATE OF ContaBancaria NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y3", "SELECT ContaBancariaId, ContaBancariaCreatedAt, ContaBancariaUpdatedAt, ContaBancariaNumero, ContaBancariaDigito, ContaBancariaCarteira, ContaBancariaStatus, ContaBancariaRegistraBoletos, AgenciaId, ContaBancariaCreatedBy, ContaBancariaUpdatedBy FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y4", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y5", "SELECT SecUserName AS ContaBancariaCreatedByName FROM SecUser WHERE SecUserId = :ContaBancariaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y6", "SELECT SecUserName AS ContaBancariaUpdatedByName FROM SecUser WHERE SecUserId = :ContaBancariaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y7", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y9", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y11", "SELECT T5.AgenciaBancoId AS AgenciaBancoId, TM1.ContaBancariaId, TM1.ContaBancariaCreatedAt, TM1.ContaBancariaUpdatedAt, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome, TM1.ContaBancariaNumero, TM1.ContaBancariaDigito, TM1.ContaBancariaCarteira, TM1.ContaBancariaStatus, T2.SecUserName AS ContaBancariaCreatedByName, T3.SecUserName AS ContaBancariaUpdatedByName, TM1.ContaBancariaRegistraBoletos, T6.BancoCodigo AS AgenciaBancoCodigo, TM1.AgenciaId, TM1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, TM1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, COALESCE( T4.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (((((ContaBancaria TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.ContaBancariaCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.ContaBancariaUpdatedBy) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX WHERE TM1.ContaBancariaId = ContaBancariaId GROUP BY ContaBancariaId ) T4 ON T4.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = TM1.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId) WHERE TM1.ContaBancariaId = :ContaBancariaId ORDER BY TM1.ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y13", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y14", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y15", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y16", "SELECT SecUserName AS ContaBancariaCreatedByName FROM SecUser WHERE SecUserId = :ContaBancariaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y17", "SELECT SecUserName AS ContaBancariaUpdatedByName FROM SecUser WHERE SecUserId = :ContaBancariaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y18", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y19", "SELECT ContaBancariaId FROM ContaBancaria WHERE ( ContaBancariaId > :ContaBancariaId) ORDER BY ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Y20", "SELECT ContaBancariaId FROM ContaBancaria WHERE ( ContaBancariaId < :ContaBancariaId) ORDER BY ContaBancariaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Y21", "SAVEPOINT gxupdate;INSERT INTO ContaBancaria(ContaBancariaCreatedAt, ContaBancariaUpdatedAt, ContaBancariaNumero, ContaBancariaDigito, ContaBancariaCarteira, ContaBancariaStatus, ContaBancariaRegistraBoletos, AgenciaId, ContaBancariaCreatedBy, ContaBancariaUpdatedBy) VALUES(:ContaBancariaCreatedAt, :ContaBancariaUpdatedAt, :ContaBancariaNumero, :ContaBancariaDigito, :ContaBancariaCarteira, :ContaBancariaStatus, :ContaBancariaRegistraBoletos, :AgenciaId, :ContaBancariaCreatedBy, :ContaBancariaUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002Y21)
             ,new CursorDef("T002Y22", "SELECT currval('ContaBancariaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y23", "SAVEPOINT gxupdate;UPDATE ContaBancaria SET ContaBancariaCreatedAt=:ContaBancariaCreatedAt, ContaBancariaUpdatedAt=:ContaBancariaUpdatedAt, ContaBancariaNumero=:ContaBancariaNumero, ContaBancariaDigito=:ContaBancariaDigito, ContaBancariaCarteira=:ContaBancariaCarteira, ContaBancariaStatus=:ContaBancariaStatus, ContaBancariaRegistraBoletos=:ContaBancariaRegistraBoletos, AgenciaId=:AgenciaId, ContaBancariaCreatedBy=:ContaBancariaCreatedBy, ContaBancariaUpdatedBy=:ContaBancariaUpdatedBy  WHERE ContaBancariaId = :ContaBancariaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002Y23)
             ,new CursorDef("T002Y24", "SAVEPOINT gxupdate;DELETE FROM ContaBancaria  WHERE ContaBancariaId = :ContaBancariaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002Y24)
             ,new CursorDef("T002Y26", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y27", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y28", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y29", "SELECT SecUserName AS ContaBancariaCreatedByName FROM SecUser WHERE SecUserId = :ContaBancariaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y30", "SELECT SecUserName AS ContaBancariaUpdatedByName FROM SecUser WHERE SecUserId = :ContaBancariaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Y31", "SELECT ChavePIXId FROM ChavePIX WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Y32", "SELECT TituloId FROM Titulo WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Y33", "SELECT ContaBancariaId FROM ContaBancaria ORDER BY ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y33,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
