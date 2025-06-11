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
   public class agencia : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A936AgenciaCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "AgenciaCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n936AgenciaCreatedBy = false;
            AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A936AgenciaCreatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A943AgenciaUpdatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "AgenciaUpdatedBy"), "."), 18, MidpointRounding.ToEven));
            n943AgenciaUpdatedBy = false;
            AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A943AgenciaUpdatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A968AgenciaBancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaBancoId"), "."), 18, MidpointRounding.ToEven));
            n968AgenciaBancoId = false;
            AssignAttri("", false, "A968AgenciaBancoId", ((0==A968AgenciaBancoId)&&IsIns( )||n968AgenciaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A968AgenciaBancoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "agencia")), "agencia") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "agencia")))) ;
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
                  AV7AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7AgenciaId", StringUtil.LTrimStr( (decimal)(AV7AgenciaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AgenciaId), "ZZZZZZZZ9"), context));
                  AV23BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV23BancoId", StringUtil.LTrimStr( (decimal)(AV23BancoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23BancoId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Agência", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAgenciaNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public agencia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agencia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_AgenciaId ,
                           int aP2_BancoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AgenciaId = aP1_AgenciaId;
         this.AV23BancoId = aP2_BancoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbAgenciaStatus = new GXCombobox();
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
         if ( cmbAgenciaStatus.ItemCount > 0 )
         {
            A940AgenciaStatus = StringUtil.StrToBool( cmbAgenciaStatus.getValidValue(StringUtil.BoolToStr( A940AgenciaStatus)));
            n940AgenciaStatus = false;
            AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAgenciaStatus.CurrentValue = StringUtil.BoolToStr( A940AgenciaStatus);
            AssignProp("", false, cmbAgenciaStatus_Internalname, "Values", cmbAgenciaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_single_line_edit( context, edtAgenciaBancoNome_Internalname, A969AgenciaBancoNome, StringUtil.RTrim( context.localUtil.Format( A969AgenciaBancoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaBancoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaBancoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Agencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgenciaNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgenciaNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgenciaNumero_Internalname, ((0==A939AgenciaNumero)&&IsIns( )||n939AgenciaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", ""))), ((0==A939AgenciaNumero)&&IsIns( )||n939AgenciaNumero ? "" : StringUtil.LTrim( ((edtAgenciaNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaNumero_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Agencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgenciaDigito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgenciaDigito_Internalname, "Dígito", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgenciaDigito_Internalname, ((0==A945AgenciaDigito)&&IsIns( )||n945AgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ",", ""))), ((0==A945AgenciaDigito)&&IsIns( )||n945AgenciaDigito ? "" : StringUtil.LTrim( ((edtAgenciaDigito_Enabled!=0) ? context.localUtil.Format( (decimal)(A945AgenciaDigito), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A945AgenciaDigito), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaDigito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaDigito_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Agencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAgenciaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAgenciaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAgenciaStatus, cmbAgenciaStatus_Internalname, StringUtil.BoolToStr( A940AgenciaStatus), 1, cmbAgenciaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbAgenciaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_Agencia.htm");
         cmbAgenciaStatus.CurrentValue = StringUtil.BoolToStr( A940AgenciaStatus);
         AssignProp("", false, cmbAgenciaStatus_Internalname, "Values", (string)(cmbAgenciaStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Agencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Agencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Agencia.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgenciaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtAgenciaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaId_Jsonclick, 0, "Attribute", "", "", "", "", edtAgenciaId_Visible, edtAgenciaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Agencia.htm");
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
         E112X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z938AgenciaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z941AgenciaCreatedAt = context.localUtil.CToT( cgiGet( "Z941AgenciaCreatedAt"), 0);
               n941AgenciaCreatedAt = ((DateTime.MinValue==A941AgenciaCreatedAt) ? true : false);
               Z942AgenciaUpdatedAt = context.localUtil.CToT( cgiGet( "Z942AgenciaUpdatedAt"), 0);
               n942AgenciaUpdatedAt = ((DateTime.MinValue==A942AgenciaUpdatedAt) ? true : false);
               Z939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z939AgenciaNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n939AgenciaNumero = ((0==A939AgenciaNumero) ? true : false);
               Z945AgenciaDigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z945AgenciaDigito"), ",", "."), 18, MidpointRounding.ToEven));
               n945AgenciaDigito = ((0==A945AgenciaDigito) ? true : false);
               Z940AgenciaStatus = StringUtil.StrToBool( cgiGet( "Z940AgenciaStatus"));
               n940AgenciaStatus = ((false==A940AgenciaStatus) ? true : false);
               Z936AgenciaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z936AgenciaCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n936AgenciaCreatedBy = ((0==A936AgenciaCreatedBy) ? true : false);
               Z943AgenciaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z943AgenciaUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n943AgenciaUpdatedBy = ((0==A943AgenciaUpdatedBy) ? true : false);
               Z968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z968AgenciaBancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n968AgenciaBancoId = ((0==A968AgenciaBancoId) ? true : false);
               A941AgenciaCreatedAt = context.localUtil.CToT( cgiGet( "Z941AgenciaCreatedAt"), 0);
               n941AgenciaCreatedAt = false;
               n941AgenciaCreatedAt = ((DateTime.MinValue==A941AgenciaCreatedAt) ? true : false);
               A942AgenciaUpdatedAt = context.localUtil.CToT( cgiGet( "Z942AgenciaUpdatedAt"), 0);
               n942AgenciaUpdatedAt = false;
               n942AgenciaUpdatedAt = ((DateTime.MinValue==A942AgenciaUpdatedAt) ? true : false);
               A936AgenciaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z936AgenciaCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n936AgenciaCreatedBy = false;
               n936AgenciaCreatedBy = ((0==A936AgenciaCreatedBy) ? true : false);
               A943AgenciaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z943AgenciaUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n943AgenciaUpdatedBy = false;
               n943AgenciaUpdatedBy = ((0==A943AgenciaUpdatedBy) ? true : false);
               A968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z968AgenciaBancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n968AgenciaBancoId = false;
               n968AgenciaBancoId = ((0==A968AgenciaBancoId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N968AgenciaBancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n968AgenciaBancoId = ((0==A968AgenciaBancoId) ? true : false);
               N936AgenciaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N936AgenciaCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n936AgenciaCreatedBy = ((0==A936AgenciaCreatedBy) ? true : false);
               N943AgenciaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N943AgenciaUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n943AgenciaUpdatedBy = ((0==A943AgenciaUpdatedBy) ? true : false);
               AV7AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vAGENCIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV24Insert_AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_AGENCIABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_AgenciaBancoId", StringUtil.LTrimStr( (decimal)(AV24Insert_AgenciaBancoId), 9, 0));
               AV23BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vBANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               A968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               n968AgenciaBancoId = ((0==A968AgenciaBancoId) ? true : false);
               AV11Insert_AgenciaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_AGENCIACREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_AgenciaCreatedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_AgenciaCreatedBy), 4, 0));
               A936AgenciaCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIACREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n936AgenciaCreatedBy = ((0==A936AgenciaCreatedBy) ? true : false);
               AV12Insert_AgenciaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_AGENCIAUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_AgenciaUpdatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_AgenciaUpdatedBy), 4, 0));
               A943AgenciaUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIAUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n943AgenciaUpdatedBy = ((0==A943AgenciaUpdatedBy) ? true : false);
               A941AgenciaCreatedAt = context.localUtil.CToT( cgiGet( "AGENCIACREATEDAT"), 0);
               n941AgenciaCreatedAt = ((DateTime.MinValue==A941AgenciaCreatedAt) ? true : false);
               A942AgenciaUpdatedAt = context.localUtil.CToT( cgiGet( "AGENCIAUPDATEDAT"), 0);
               n942AgenciaUpdatedAt = ((DateTime.MinValue==A942AgenciaUpdatedAt) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A937AgenciaCreatedByName = cgiGet( "AGENCIACREATEDBYNAME");
               n937AgenciaCreatedByName = false;
               A944AgenciaUpdatedByName = cgiGet( "AGENCIAUPDATEDBYNAME");
               n944AgenciaUpdatedByName = false;
               A974AgenciaBancoCodigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIABANCOCODIGO"), ",", "."), 18, MidpointRounding.ToEven));
               n974AgenciaBancoCodigo = false;
               AV26Pgmname = cgiGet( "vPGMNAME");
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
               n939AgenciaNumero = ((StringUtil.StrCmp(cgiGet( edtAgenciaNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AGENCIANUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtAgenciaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A939AgenciaNumero = 0;
                  n939AgenciaNumero = false;
                  AssignAttri("", false, "A939AgenciaNumero", (n939AgenciaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
               }
               else
               {
                  A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A939AgenciaNumero", (n939AgenciaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
               }
               n945AgenciaDigito = ((StringUtil.StrCmp(cgiGet( edtAgenciaDigito_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAgenciaDigito_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAgenciaDigito_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AGENCIADIGITO");
                  AnyError = 1;
                  GX_FocusControl = edtAgenciaDigito_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A945AgenciaDigito = 0;
                  n945AgenciaDigito = false;
                  AssignAttri("", false, "A945AgenciaDigito", (n945AgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ".", ""))));
               }
               else
               {
                  A945AgenciaDigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaDigito_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A945AgenciaDigito", (n945AgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ".", ""))));
               }
               cmbAgenciaStatus.CurrentValue = cgiGet( cmbAgenciaStatus_Internalname);
               A940AgenciaStatus = StringUtil.StrToBool( cgiGet( cmbAgenciaStatus_Internalname));
               n940AgenciaStatus = false;
               AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
               n940AgenciaStatus = ((false==A940AgenciaStatus) ? true : false);
               A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n938AgenciaId = false;
               AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Agencia");
               A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n938AgenciaId = false;
               AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
               forbiddenHiddens.Add("AgenciaId", context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_AgenciaBancoId", context.localUtil.Format( (decimal)(AV24Insert_AgenciaBancoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_AgenciaCreatedBy", context.localUtil.Format( (decimal)(AV11Insert_AgenciaCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_AgenciaUpdatedBy", context.localUtil.Format( (decimal)(AV12Insert_AgenciaUpdatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("AgenciaCreatedAt", context.localUtil.Format( A941AgenciaCreatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("AgenciaUpdatedAt", context.localUtil.Format( A942AgenciaUpdatedAt, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A938AgenciaId != Z938AgenciaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("agencia:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A938AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
                  n938AgenciaId = false;
                  AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
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
                     sMode101 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode101;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound101 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AGENCIAID");
                        AnyError = 1;
                        GX_FocusControl = edtAgenciaId_Internalname;
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
                           E112X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122X2 ();
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
            E122X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2X101( ) ;
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
            DisableAttributes2X101( ) ;
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

      protected void CONFIRM_2X0( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2X101( ) ;
            }
            else
            {
               CheckExtendedTable2X101( ) ;
               CloseExtendedTableCursors2X101( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2X0( )
      {
      }

      protected void E112X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AgenciaBancoId") == 0 )
               {
                  AV24Insert_AgenciaBancoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_AgenciaBancoId", StringUtil.LTrimStr( (decimal)(AV24Insert_AgenciaBancoId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AgenciaCreatedBy") == 0 )
               {
                  AV11Insert_AgenciaCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_AgenciaCreatedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_AgenciaCreatedBy), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AgenciaUpdatedBy") == 0 )
               {
                  AV12Insert_AgenciaUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_AgenciaUpdatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_AgenciaUpdatedBy), 4, 0));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
         edtAgenciaId_Visible = 0;
         AssignProp("", false, edtAgenciaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Visible), 5, 0), true);
      }

      protected void E122X2( )
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

      protected void ZM2X101( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z941AgenciaCreatedAt = T002X3_A941AgenciaCreatedAt[0];
               Z942AgenciaUpdatedAt = T002X3_A942AgenciaUpdatedAt[0];
               Z939AgenciaNumero = T002X3_A939AgenciaNumero[0];
               Z945AgenciaDigito = T002X3_A945AgenciaDigito[0];
               Z940AgenciaStatus = T002X3_A940AgenciaStatus[0];
               Z936AgenciaCreatedBy = T002X3_A936AgenciaCreatedBy[0];
               Z943AgenciaUpdatedBy = T002X3_A943AgenciaUpdatedBy[0];
               Z968AgenciaBancoId = T002X3_A968AgenciaBancoId[0];
            }
            else
            {
               Z941AgenciaCreatedAt = A941AgenciaCreatedAt;
               Z942AgenciaUpdatedAt = A942AgenciaUpdatedAt;
               Z939AgenciaNumero = A939AgenciaNumero;
               Z945AgenciaDigito = A945AgenciaDigito;
               Z940AgenciaStatus = A940AgenciaStatus;
               Z936AgenciaCreatedBy = A936AgenciaCreatedBy;
               Z943AgenciaUpdatedBy = A943AgenciaUpdatedBy;
               Z968AgenciaBancoId = A968AgenciaBancoId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z938AgenciaId = A938AgenciaId;
            Z941AgenciaCreatedAt = A941AgenciaCreatedAt;
            Z942AgenciaUpdatedAt = A942AgenciaUpdatedAt;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z945AgenciaDigito = A945AgenciaDigito;
            Z940AgenciaStatus = A940AgenciaStatus;
            Z936AgenciaCreatedBy = A936AgenciaCreatedBy;
            Z943AgenciaUpdatedBy = A943AgenciaUpdatedBy;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z937AgenciaCreatedByName = A937AgenciaCreatedByName;
            Z944AgenciaUpdatedByName = A944AgenciaUpdatedByName;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z974AgenciaBancoCodigo = A974AgenciaBancoCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAgenciaId_Enabled = 0;
         AssignProp("", false, edtAgenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Enabled), 5, 0), true);
         AV26Pgmname = "Agencia";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtAgenciaId_Enabled = 0;
         AssignProp("", false, edtAgenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AgenciaId) )
         {
            A938AgenciaId = AV7AgenciaId;
            n938AgenciaId = false;
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A941AgenciaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n941AgenciaCreatedAt = false;
            AssignAttri("", false, "A941AgenciaCreatedAt", context.localUtil.TToC( A941AgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A942AgenciaUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n942AgenciaUpdatedAt = false;
            AssignAttri("", false, "A942AgenciaUpdatedAt", context.localUtil.TToC( A942AgenciaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
         {
            cmbAgenciaStatus.Enabled = 0;
            AssignProp("", false, cmbAgenciaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgenciaStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbAgenciaStatus.Enabled = 1;
            AssignProp("", false, cmbAgenciaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgenciaStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbAgenciaStatus.Enabled = 0;
            AssignProp("", false, cmbAgenciaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgenciaStatus.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_AgenciaBancoId) )
         {
            A968AgenciaBancoId = AV24Insert_AgenciaBancoId;
            n968AgenciaBancoId = false;
            AssignAttri("", false, "A968AgenciaBancoId", ((0==A968AgenciaBancoId)&&IsIns( )||n968AgenciaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A968AgenciaBancoId = AV23BancoId;
               n968AgenciaBancoId = false;
               AssignAttri("", false, "A968AgenciaBancoId", ((0==A968AgenciaBancoId)&&IsIns( )||n968AgenciaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", ""))));
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
         if ( IsIns( )  && (false==A940AgenciaStatus) && ( Gx_BScreen == 0 ) )
         {
            A940AgenciaStatus = true;
            n940AgenciaStatus = false;
            AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002X6 */
            pr_default.execute(4, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T002X6_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002X6_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A974AgenciaBancoCodigo = T002X6_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = T002X6_n974AgenciaBancoCodigo[0];
            pr_default.close(4);
         }
      }

      protected void Load2X101( )
      {
         /* Using cursor T002X7 */
         pr_default.execute(5, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound101 = 1;
            A941AgenciaCreatedAt = T002X7_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = T002X7_n941AgenciaCreatedAt[0];
            A942AgenciaUpdatedAt = T002X7_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = T002X7_n942AgenciaUpdatedAt[0];
            A969AgenciaBancoNome = T002X7_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002X7_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A974AgenciaBancoCodigo = T002X7_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = T002X7_n974AgenciaBancoCodigo[0];
            A939AgenciaNumero = T002X7_A939AgenciaNumero[0];
            n939AgenciaNumero = T002X7_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", ((0==A939AgenciaNumero)&&IsIns( )||n939AgenciaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
            A945AgenciaDigito = T002X7_A945AgenciaDigito[0];
            n945AgenciaDigito = T002X7_n945AgenciaDigito[0];
            AssignAttri("", false, "A945AgenciaDigito", ((0==A945AgenciaDigito)&&IsIns( )||n945AgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ".", ""))));
            A940AgenciaStatus = T002X7_A940AgenciaStatus[0];
            n940AgenciaStatus = T002X7_n940AgenciaStatus[0];
            AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
            A937AgenciaCreatedByName = T002X7_A937AgenciaCreatedByName[0];
            n937AgenciaCreatedByName = T002X7_n937AgenciaCreatedByName[0];
            A944AgenciaUpdatedByName = T002X7_A944AgenciaUpdatedByName[0];
            n944AgenciaUpdatedByName = T002X7_n944AgenciaUpdatedByName[0];
            A936AgenciaCreatedBy = T002X7_A936AgenciaCreatedBy[0];
            n936AgenciaCreatedBy = T002X7_n936AgenciaCreatedBy[0];
            A943AgenciaUpdatedBy = T002X7_A943AgenciaUpdatedBy[0];
            n943AgenciaUpdatedBy = T002X7_n943AgenciaUpdatedBy[0];
            A968AgenciaBancoId = T002X7_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002X7_n968AgenciaBancoId[0];
            ZM2X101( -16) ;
         }
         pr_default.close(5);
         OnLoadActions2X101( ) ;
      }

      protected void OnLoadActions2X101( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_AgenciaCreatedBy) )
         {
            A936AgenciaCreatedBy = AV11Insert_AgenciaCreatedBy;
            n936AgenciaCreatedBy = false;
            AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A936AgenciaCreatedBy) )
            {
               A936AgenciaCreatedBy = 0;
               n936AgenciaCreatedBy = false;
               AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
               n936AgenciaCreatedBy = true;
               n936AgenciaCreatedBy = true;
               AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( IsIns( )  )
               {
                  A936AgenciaCreatedBy = AV8WWPContext.gxTpr_Userid;
                  n936AgenciaCreatedBy = false;
                  AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_AgenciaUpdatedBy) )
         {
            A943AgenciaUpdatedBy = AV12Insert_AgenciaUpdatedBy;
            n943AgenciaUpdatedBy = false;
            AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A943AgenciaUpdatedBy) )
            {
               A943AgenciaUpdatedBy = 0;
               n943AgenciaUpdatedBy = false;
               AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
               n943AgenciaUpdatedBy = true;
               n943AgenciaUpdatedBy = true;
               AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A943AgenciaUpdatedBy = AV8WWPContext.gxTpr_Userid;
                  n943AgenciaUpdatedBy = false;
                  AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
               }
            }
         }
      }

      protected void CheckExtendedTable2X101( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_AgenciaCreatedBy) )
         {
            A936AgenciaCreatedBy = AV11Insert_AgenciaCreatedBy;
            n936AgenciaCreatedBy = false;
            AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A936AgenciaCreatedBy) )
            {
               A936AgenciaCreatedBy = 0;
               n936AgenciaCreatedBy = false;
               AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
               n936AgenciaCreatedBy = true;
               n936AgenciaCreatedBy = true;
               AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( IsIns( )  )
               {
                  A936AgenciaCreatedBy = AV8WWPContext.gxTpr_Userid;
                  n936AgenciaCreatedBy = false;
                  AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_AgenciaUpdatedBy) )
         {
            A943AgenciaUpdatedBy = AV12Insert_AgenciaUpdatedBy;
            n943AgenciaUpdatedBy = false;
            AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A943AgenciaUpdatedBy) )
            {
               A943AgenciaUpdatedBy = 0;
               n943AgenciaUpdatedBy = false;
               AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
               n943AgenciaUpdatedBy = true;
               n943AgenciaUpdatedBy = true;
               AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A943AgenciaUpdatedBy = AV8WWPContext.gxTpr_Userid;
                  n943AgenciaUpdatedBy = false;
                  AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
               }
            }
         }
         /* Using cursor T002X4 */
         pr_default.execute(2, new Object[] {n936AgenciaCreatedBy, A936AgenciaCreatedBy});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A936AgenciaCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Created By'.", "ForeignKeyNotFound", 1, "AGENCIACREATEDBY");
               AnyError = 1;
            }
         }
         A937AgenciaCreatedByName = T002X4_A937AgenciaCreatedByName[0];
         n937AgenciaCreatedByName = T002X4_n937AgenciaCreatedByName[0];
         pr_default.close(2);
         /* Using cursor T002X5 */
         pr_default.execute(3, new Object[] {n943AgenciaUpdatedBy, A943AgenciaUpdatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A943AgenciaUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Updated By'.", "ForeignKeyNotFound", 1, "AGENCIAUPDATEDBY");
               AnyError = 1;
            }
         }
         A944AgenciaUpdatedByName = T002X5_A944AgenciaUpdatedByName[0];
         n944AgenciaUpdatedByName = T002X5_n944AgenciaUpdatedByName[0];
         pr_default.close(3);
         /* Using cursor T002X6 */
         pr_default.execute(4, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002X6_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002X6_n969AgenciaBancoNome[0];
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A974AgenciaBancoCodigo = T002X6_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = T002X6_n974AgenciaBancoCodigo[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2X101( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( short A936AgenciaCreatedBy )
      {
         /* Using cursor T002X8 */
         pr_default.execute(6, new Object[] {n936AgenciaCreatedBy, A936AgenciaCreatedBy});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A936AgenciaCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Created By'.", "ForeignKeyNotFound", 1, "AGENCIACREATEDBY");
               AnyError = 1;
            }
         }
         A937AgenciaCreatedByName = T002X8_A937AgenciaCreatedByName[0];
         n937AgenciaCreatedByName = T002X8_n937AgenciaCreatedByName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A937AgenciaCreatedByName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_18( short A943AgenciaUpdatedBy )
      {
         /* Using cursor T002X9 */
         pr_default.execute(7, new Object[] {n943AgenciaUpdatedBy, A943AgenciaUpdatedBy});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A943AgenciaUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Updated By'.", "ForeignKeyNotFound", 1, "AGENCIAUPDATEDBY");
               AnyError = 1;
            }
         }
         A944AgenciaUpdatedByName = T002X9_A944AgenciaUpdatedByName[0];
         n944AgenciaUpdatedByName = T002X9_n944AgenciaUpdatedByName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A944AgenciaUpdatedByName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_19( int A968AgenciaBancoId )
      {
         /* Using cursor T002X10 */
         pr_default.execute(8, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002X10_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002X10_n969AgenciaBancoNome[0];
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A974AgenciaBancoCodigo = T002X10_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = T002X10_n974AgenciaBancoCodigo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A969AgenciaBancoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A974AgenciaBancoCodigo), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey2X101( )
      {
         /* Using cursor T002X11 */
         pr_default.execute(9, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound101 = 1;
         }
         else
         {
            RcdFound101 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002X3 */
         pr_default.execute(1, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2X101( 16) ;
            RcdFound101 = 1;
            A938AgenciaId = T002X3_A938AgenciaId[0];
            n938AgenciaId = T002X3_n938AgenciaId[0];
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
            A941AgenciaCreatedAt = T002X3_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = T002X3_n941AgenciaCreatedAt[0];
            A942AgenciaUpdatedAt = T002X3_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = T002X3_n942AgenciaUpdatedAt[0];
            A939AgenciaNumero = T002X3_A939AgenciaNumero[0];
            n939AgenciaNumero = T002X3_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", ((0==A939AgenciaNumero)&&IsIns( )||n939AgenciaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
            A945AgenciaDigito = T002X3_A945AgenciaDigito[0];
            n945AgenciaDigito = T002X3_n945AgenciaDigito[0];
            AssignAttri("", false, "A945AgenciaDigito", ((0==A945AgenciaDigito)&&IsIns( )||n945AgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ".", ""))));
            A940AgenciaStatus = T002X3_A940AgenciaStatus[0];
            n940AgenciaStatus = T002X3_n940AgenciaStatus[0];
            AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
            A936AgenciaCreatedBy = T002X3_A936AgenciaCreatedBy[0];
            n936AgenciaCreatedBy = T002X3_n936AgenciaCreatedBy[0];
            A943AgenciaUpdatedBy = T002X3_A943AgenciaUpdatedBy[0];
            n943AgenciaUpdatedBy = T002X3_n943AgenciaUpdatedBy[0];
            A968AgenciaBancoId = T002X3_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002X3_n968AgenciaBancoId[0];
            Z938AgenciaId = A938AgenciaId;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2X101( ) ;
            if ( AnyError == 1 )
            {
               RcdFound101 = 0;
               InitializeNonKey2X101( ) ;
            }
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound101 = 0;
            InitializeNonKey2X101( ) ;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2X101( ) ;
         if ( RcdFound101 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound101 = 0;
         /* Using cursor T002X12 */
         pr_default.execute(10, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002X12_A938AgenciaId[0] < A938AgenciaId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002X12_A938AgenciaId[0] > A938AgenciaId ) ) )
            {
               A938AgenciaId = T002X12_A938AgenciaId[0];
               n938AgenciaId = T002X12_n938AgenciaId[0];
               AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
               RcdFound101 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound101 = 0;
         /* Using cursor T002X13 */
         pr_default.execute(11, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002X13_A938AgenciaId[0] > A938AgenciaId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002X13_A938AgenciaId[0] < A938AgenciaId ) ) )
            {
               A938AgenciaId = T002X13_A938AgenciaId[0];
               n938AgenciaId = T002X13_n938AgenciaId[0];
               AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
               RcdFound101 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2X101( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAgenciaNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2X101( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound101 == 1 )
            {
               if ( A938AgenciaId != Z938AgenciaId )
               {
                  A938AgenciaId = Z938AgenciaId;
                  n938AgenciaId = false;
                  AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AGENCIAID");
                  AnyError = 1;
                  GX_FocusControl = edtAgenciaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAgenciaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2X101( ) ;
                  GX_FocusControl = edtAgenciaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A938AgenciaId != Z938AgenciaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAgenciaNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2X101( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AGENCIAID");
                     AnyError = 1;
                     GX_FocusControl = edtAgenciaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAgenciaNumero_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2X101( ) ;
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
         if ( A938AgenciaId != Z938AgenciaId )
         {
            A938AgenciaId = Z938AgenciaId;
            n938AgenciaId = false;
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AGENCIAID");
            AnyError = 1;
            GX_FocusControl = edtAgenciaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAgenciaNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2X101( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002X2 */
            pr_default.execute(0, new Object[] {n938AgenciaId, A938AgenciaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Agencia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z941AgenciaCreatedAt != T002X2_A941AgenciaCreatedAt[0] ) || ( Z942AgenciaUpdatedAt != T002X2_A942AgenciaUpdatedAt[0] ) || ( Z939AgenciaNumero != T002X2_A939AgenciaNumero[0] ) || ( Z945AgenciaDigito != T002X2_A945AgenciaDigito[0] ) || ( Z940AgenciaStatus != T002X2_A940AgenciaStatus[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z936AgenciaCreatedBy != T002X2_A936AgenciaCreatedBy[0] ) || ( Z943AgenciaUpdatedBy != T002X2_A943AgenciaUpdatedBy[0] ) || ( Z968AgenciaBancoId != T002X2_A968AgenciaBancoId[0] ) )
            {
               if ( Z941AgenciaCreatedAt != T002X2_A941AgenciaCreatedAt[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z941AgenciaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A941AgenciaCreatedAt[0]);
               }
               if ( Z942AgenciaUpdatedAt != T002X2_A942AgenciaUpdatedAt[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z942AgenciaUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A942AgenciaUpdatedAt[0]);
               }
               if ( Z939AgenciaNumero != T002X2_A939AgenciaNumero[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaNumero");
                  GXUtil.WriteLogRaw("Old: ",Z939AgenciaNumero);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A939AgenciaNumero[0]);
               }
               if ( Z945AgenciaDigito != T002X2_A945AgenciaDigito[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaDigito");
                  GXUtil.WriteLogRaw("Old: ",Z945AgenciaDigito);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A945AgenciaDigito[0]);
               }
               if ( Z940AgenciaStatus != T002X2_A940AgenciaStatus[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z940AgenciaStatus);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A940AgenciaStatus[0]);
               }
               if ( Z936AgenciaCreatedBy != T002X2_A936AgenciaCreatedBy[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z936AgenciaCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A936AgenciaCreatedBy[0]);
               }
               if ( Z943AgenciaUpdatedBy != T002X2_A943AgenciaUpdatedBy[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaUpdatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z943AgenciaUpdatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A943AgenciaUpdatedBy[0]);
               }
               if ( Z968AgenciaBancoId != T002X2_A968AgenciaBancoId[0] )
               {
                  GXUtil.WriteLog("agencia:[seudo value changed for attri]"+"AgenciaBancoId");
                  GXUtil.WriteLogRaw("Old: ",Z968AgenciaBancoId);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A968AgenciaBancoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Agencia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2X101( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2X101( 0) ;
            CheckOptimisticConcurrency2X101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2X101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X14 */
                     pr_default.execute(12, new Object[] {n941AgenciaCreatedAt, A941AgenciaCreatedAt, n942AgenciaUpdatedAt, A942AgenciaUpdatedAt, n939AgenciaNumero, A939AgenciaNumero, n945AgenciaDigito, A945AgenciaDigito, n940AgenciaStatus, A940AgenciaStatus, n936AgenciaCreatedBy, A936AgenciaCreatedBy, n943AgenciaUpdatedBy, A943AgenciaUpdatedBy, n968AgenciaBancoId, A968AgenciaBancoId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002X15 */
                     pr_default.execute(13);
                     A938AgenciaId = T002X15_A938AgenciaId[0];
                     n938AgenciaId = T002X15_n938AgenciaId[0];
                     AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Agencia");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2X0( ) ;
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
               Load2X101( ) ;
            }
            EndLevel2X101( ) ;
         }
         CloseExtendedTableCursors2X101( ) ;
      }

      protected void Update2X101( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2X101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X16 */
                     pr_default.execute(14, new Object[] {n941AgenciaCreatedAt, A941AgenciaCreatedAt, n942AgenciaUpdatedAt, A942AgenciaUpdatedAt, n939AgenciaNumero, A939AgenciaNumero, n945AgenciaDigito, A945AgenciaDigito, n940AgenciaStatus, A940AgenciaStatus, n936AgenciaCreatedBy, A936AgenciaCreatedBy, n943AgenciaUpdatedBy, A943AgenciaUpdatedBy, n968AgenciaBancoId, A968AgenciaBancoId, n938AgenciaId, A938AgenciaId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Agencia");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Agencia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2X101( ) ;
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
            EndLevel2X101( ) ;
         }
         CloseExtendedTableCursors2X101( ) ;
      }

      protected void DeferredUpdate2X101( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2X101( ) ;
            AfterConfirm2X101( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2X101( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002X17 */
                  pr_default.execute(15, new Object[] {n938AgenciaId, A938AgenciaId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Agencia");
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
         sMode101 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2X101( ) ;
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2X101( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002X18 */
            pr_default.execute(16, new Object[] {n936AgenciaCreatedBy, A936AgenciaCreatedBy});
            A937AgenciaCreatedByName = T002X18_A937AgenciaCreatedByName[0];
            n937AgenciaCreatedByName = T002X18_n937AgenciaCreatedByName[0];
            pr_default.close(16);
            /* Using cursor T002X19 */
            pr_default.execute(17, new Object[] {n943AgenciaUpdatedBy, A943AgenciaUpdatedBy});
            A944AgenciaUpdatedByName = T002X19_A944AgenciaUpdatedByName[0];
            n944AgenciaUpdatedByName = T002X19_n944AgenciaUpdatedByName[0];
            pr_default.close(17);
            /* Using cursor T002X20 */
            pr_default.execute(18, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T002X20_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002X20_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A974AgenciaBancoCodigo = T002X20_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = T002X20_n974AgenciaBancoCodigo[0];
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002X21 */
            pr_default.execute(19, new Object[] {n938AgenciaId, A938AgenciaId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel2X101( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("agencia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("agencia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2X101( )
      {
         /* Scan By routine */
         /* Using cursor T002X22 */
         pr_default.execute(20);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound101 = 1;
            A938AgenciaId = T002X22_A938AgenciaId[0];
            n938AgenciaId = T002X22_n938AgenciaId[0];
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2X101( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound101 = 1;
            A938AgenciaId = T002X22_A938AgenciaId[0];
            n938AgenciaId = T002X22_n938AgenciaId[0];
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
         }
      }

      protected void ScanEnd2X101( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm2X101( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2X101( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2X101( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2X101( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2X101( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2X101( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2X101( )
      {
         edtAgenciaBancoNome_Enabled = 0;
         AssignProp("", false, edtAgenciaBancoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaBancoNome_Enabled), 5, 0), true);
         edtAgenciaNumero_Enabled = 0;
         AssignProp("", false, edtAgenciaNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaNumero_Enabled), 5, 0), true);
         edtAgenciaDigito_Enabled = 0;
         AssignProp("", false, edtAgenciaDigito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaDigito_Enabled), 5, 0), true);
         cmbAgenciaStatus.Enabled = 0;
         AssignProp("", false, cmbAgenciaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgenciaStatus.Enabled), 5, 0), true);
         edtAgenciaId_Enabled = 0;
         AssignProp("", false, edtAgenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2X101( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2X0( )
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
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV23BancoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Agencia");
         forbiddenHiddens.Add("AgenciaId", context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_AgenciaBancoId", context.localUtil.Format( (decimal)(AV24Insert_AgenciaBancoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_AgenciaCreatedBy", context.localUtil.Format( (decimal)(AV11Insert_AgenciaCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_AgenciaUpdatedBy", context.localUtil.Format( (decimal)(AV12Insert_AgenciaUpdatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("AgenciaCreatedAt", context.localUtil.Format( A941AgenciaCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("AgenciaUpdatedAt", context.localUtil.Format( A942AgenciaUpdatedAt, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("agencia:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z938AgenciaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z938AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z941AgenciaCreatedAt", context.localUtil.TToC( Z941AgenciaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z942AgenciaUpdatedAt", context.localUtil.TToC( Z942AgenciaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z939AgenciaNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z939AgenciaNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z945AgenciaDigito", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z945AgenciaDigito), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z940AgenciaStatus", Z940AgenciaStatus);
         GxWebStd.gx_hidden_field( context, "Z936AgenciaCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z936AgenciaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z943AgenciaUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z943AgenciaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z968AgenciaBancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z968AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N968AgenciaBancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N936AgenciaCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N943AgenciaUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vAGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_AGENCIABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23BancoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "AGENCIABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_AGENCIACREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_AgenciaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIACREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_AGENCIAUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_AgenciaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIAUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIACREATEDAT", context.localUtil.TToC( A941AgenciaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "AGENCIAUPDATEDAT", context.localUtil.TToC( A942AgenciaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIACREATEDBYNAME", A937AgenciaCreatedByName);
         GxWebStd.gx_hidden_field( context, "AGENCIAUPDATEDBYNAME", A944AgenciaUpdatedByName);
         GxWebStd.gx_hidden_field( context, "AGENCIABANCOCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A974AgenciaBancoCodigo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
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
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AgenciaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV23BancoId,9,0));
         return formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Agencia" ;
      }

      public override string GetPgmdesc( )
      {
         return "Agência" ;
      }

      protected void InitializeNonKey2X101( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         AssignAttri("", false, "A968AgenciaBancoId", ((0==A968AgenciaBancoId)&&IsIns( )||n968AgenciaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", ""))));
         A936AgenciaCreatedBy = 0;
         n936AgenciaCreatedBy = false;
         AssignAttri("", false, "A936AgenciaCreatedBy", ((0==A936AgenciaCreatedBy)&&IsIns( )||n936AgenciaCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A936AgenciaCreatedBy), 4, 0, ".", ""))));
         A943AgenciaUpdatedBy = 0;
         n943AgenciaUpdatedBy = false;
         AssignAttri("", false, "A943AgenciaUpdatedBy", ((0==A943AgenciaUpdatedBy)&&IsIns( )||n943AgenciaUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A943AgenciaUpdatedBy), 4, 0, ".", ""))));
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         n941AgenciaCreatedAt = false;
         AssignAttri("", false, "A941AgenciaCreatedAt", context.localUtil.TToC( A941AgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         n942AgenciaUpdatedAt = false;
         AssignAttri("", false, "A942AgenciaUpdatedAt", context.localUtil.TToC( A942AgenciaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A974AgenciaBancoCodigo = 0;
         n974AgenciaBancoCodigo = false;
         AssignAttri("", false, "A974AgenciaBancoCodigo", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0));
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         AssignAttri("", false, "A939AgenciaNumero", ((0==A939AgenciaNumero)&&IsIns( )||n939AgenciaNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
         n939AgenciaNumero = ((0==A939AgenciaNumero) ? true : false);
         A945AgenciaDigito = 0;
         n945AgenciaDigito = false;
         AssignAttri("", false, "A945AgenciaDigito", ((0==A945AgenciaDigito)&&IsIns( )||n945AgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ".", ""))));
         n945AgenciaDigito = ((0==A945AgenciaDigito) ? true : false);
         A937AgenciaCreatedByName = "";
         n937AgenciaCreatedByName = false;
         AssignAttri("", false, "A937AgenciaCreatedByName", A937AgenciaCreatedByName);
         A944AgenciaUpdatedByName = "";
         n944AgenciaUpdatedByName = false;
         AssignAttri("", false, "A944AgenciaUpdatedByName", A944AgenciaUpdatedByName);
         A940AgenciaStatus = true;
         n940AgenciaStatus = false;
         AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
         Z941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         Z942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z939AgenciaNumero = 0;
         Z945AgenciaDigito = 0;
         Z940AgenciaStatus = false;
         Z936AgenciaCreatedBy = 0;
         Z943AgenciaUpdatedBy = 0;
         Z968AgenciaBancoId = 0;
      }

      protected void InitAll2X101( )
      {
         A938AgenciaId = 0;
         n938AgenciaId = false;
         AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
         InitializeNonKey2X101( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A941AgenciaCreatedAt = i941AgenciaCreatedAt;
         n941AgenciaCreatedAt = false;
         AssignAttri("", false, "A941AgenciaCreatedAt", context.localUtil.TToC( A941AgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A968AgenciaBancoId = i968AgenciaBancoId;
         n968AgenciaBancoId = false;
         AssignAttri("", false, "A968AgenciaBancoId", ((0==A968AgenciaBancoId)&&IsIns( )||n968AgenciaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", ""))));
         A940AgenciaStatus = i940AgenciaStatus;
         n940AgenciaStatus = false;
         AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019215027", true, true);
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
         context.AddJavascriptSource("agencia.js", "?202561019215027", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME";
         edtAgenciaNumero_Internalname = "AGENCIANUMERO";
         edtAgenciaDigito_Internalname = "AGENCIADIGITO";
         cmbAgenciaStatus_Internalname = "AGENCIASTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Agência";
         edtAgenciaId_Jsonclick = "";
         edtAgenciaId_Enabled = 0;
         edtAgenciaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbAgenciaStatus_Jsonclick = "";
         cmbAgenciaStatus.Enabled = 1;
         edtAgenciaDigito_Jsonclick = "";
         edtAgenciaDigito_Enabled = 1;
         edtAgenciaNumero_Jsonclick = "";
         edtAgenciaNumero_Enabled = 1;
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
         cmbAgenciaStatus.Name = "AGENCIASTATUS";
         cmbAgenciaStatus.WebTags = "";
         cmbAgenciaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbAgenciaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbAgenciaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A940AgenciaStatus) )
            {
               A940AgenciaStatus = true;
               n940AgenciaStatus = false;
               AssignAttri("", false, "A940AgenciaStatus", A940AgenciaStatus);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV23BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AgenciaId","fld":"vAGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV23BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV24Insert_AgenciaBancoId","fld":"vINSERT_AGENCIABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_AgenciaCreatedBy","fld":"vINSERT_AGENCIACREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV12Insert_AgenciaUpdatedBy","fld":"vINSERT_AGENCIAUPDATEDBY","pic":"ZZZ9","type":"int"},{"av":"A941AgenciaCreatedAt","fld":"AGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A942AgenciaUpdatedAt","fld":"AGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122X2","iparms":[]}""");
         setEventMetadata("VALID_AGENCIAID","""{"handler":"Valid_Agenciaid","iparms":[]}""");
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
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         Z942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
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
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         A937AgenciaCreatedByName = "";
         A944AgenciaUpdatedByName = "";
         AV26Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode101 = "";
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
         Z937AgenciaCreatedByName = "";
         Z944AgenciaUpdatedByName = "";
         Z969AgenciaBancoNome = "";
         T002X6_A969AgenciaBancoNome = new string[] {""} ;
         T002X6_n969AgenciaBancoNome = new bool[] {false} ;
         T002X6_A974AgenciaBancoCodigo = new int[1] ;
         T002X6_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002X7_A938AgenciaId = new int[1] ;
         T002X7_n938AgenciaId = new bool[] {false} ;
         T002X7_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002X7_n941AgenciaCreatedAt = new bool[] {false} ;
         T002X7_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002X7_n942AgenciaUpdatedAt = new bool[] {false} ;
         T002X7_A969AgenciaBancoNome = new string[] {""} ;
         T002X7_n969AgenciaBancoNome = new bool[] {false} ;
         T002X7_A974AgenciaBancoCodigo = new int[1] ;
         T002X7_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002X7_A939AgenciaNumero = new int[1] ;
         T002X7_n939AgenciaNumero = new bool[] {false} ;
         T002X7_A945AgenciaDigito = new int[1] ;
         T002X7_n945AgenciaDigito = new bool[] {false} ;
         T002X7_A940AgenciaStatus = new bool[] {false} ;
         T002X7_n940AgenciaStatus = new bool[] {false} ;
         T002X7_A937AgenciaCreatedByName = new string[] {""} ;
         T002X7_n937AgenciaCreatedByName = new bool[] {false} ;
         T002X7_A944AgenciaUpdatedByName = new string[] {""} ;
         T002X7_n944AgenciaUpdatedByName = new bool[] {false} ;
         T002X7_A936AgenciaCreatedBy = new short[1] ;
         T002X7_n936AgenciaCreatedBy = new bool[] {false} ;
         T002X7_A943AgenciaUpdatedBy = new short[1] ;
         T002X7_n943AgenciaUpdatedBy = new bool[] {false} ;
         T002X7_A968AgenciaBancoId = new int[1] ;
         T002X7_n968AgenciaBancoId = new bool[] {false} ;
         T002X4_A937AgenciaCreatedByName = new string[] {""} ;
         T002X4_n937AgenciaCreatedByName = new bool[] {false} ;
         T002X5_A944AgenciaUpdatedByName = new string[] {""} ;
         T002X5_n944AgenciaUpdatedByName = new bool[] {false} ;
         T002X8_A937AgenciaCreatedByName = new string[] {""} ;
         T002X8_n937AgenciaCreatedByName = new bool[] {false} ;
         T002X9_A944AgenciaUpdatedByName = new string[] {""} ;
         T002X9_n944AgenciaUpdatedByName = new bool[] {false} ;
         T002X10_A969AgenciaBancoNome = new string[] {""} ;
         T002X10_n969AgenciaBancoNome = new bool[] {false} ;
         T002X10_A974AgenciaBancoCodigo = new int[1] ;
         T002X10_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002X11_A938AgenciaId = new int[1] ;
         T002X11_n938AgenciaId = new bool[] {false} ;
         T002X3_A938AgenciaId = new int[1] ;
         T002X3_n938AgenciaId = new bool[] {false} ;
         T002X3_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002X3_n941AgenciaCreatedAt = new bool[] {false} ;
         T002X3_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002X3_n942AgenciaUpdatedAt = new bool[] {false} ;
         T002X3_A939AgenciaNumero = new int[1] ;
         T002X3_n939AgenciaNumero = new bool[] {false} ;
         T002X3_A945AgenciaDigito = new int[1] ;
         T002X3_n945AgenciaDigito = new bool[] {false} ;
         T002X3_A940AgenciaStatus = new bool[] {false} ;
         T002X3_n940AgenciaStatus = new bool[] {false} ;
         T002X3_A936AgenciaCreatedBy = new short[1] ;
         T002X3_n936AgenciaCreatedBy = new bool[] {false} ;
         T002X3_A943AgenciaUpdatedBy = new short[1] ;
         T002X3_n943AgenciaUpdatedBy = new bool[] {false} ;
         T002X3_A968AgenciaBancoId = new int[1] ;
         T002X3_n968AgenciaBancoId = new bool[] {false} ;
         T002X12_A938AgenciaId = new int[1] ;
         T002X12_n938AgenciaId = new bool[] {false} ;
         T002X13_A938AgenciaId = new int[1] ;
         T002X13_n938AgenciaId = new bool[] {false} ;
         T002X2_A938AgenciaId = new int[1] ;
         T002X2_n938AgenciaId = new bool[] {false} ;
         T002X2_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002X2_n941AgenciaCreatedAt = new bool[] {false} ;
         T002X2_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002X2_n942AgenciaUpdatedAt = new bool[] {false} ;
         T002X2_A939AgenciaNumero = new int[1] ;
         T002X2_n939AgenciaNumero = new bool[] {false} ;
         T002X2_A945AgenciaDigito = new int[1] ;
         T002X2_n945AgenciaDigito = new bool[] {false} ;
         T002X2_A940AgenciaStatus = new bool[] {false} ;
         T002X2_n940AgenciaStatus = new bool[] {false} ;
         T002X2_A936AgenciaCreatedBy = new short[1] ;
         T002X2_n936AgenciaCreatedBy = new bool[] {false} ;
         T002X2_A943AgenciaUpdatedBy = new short[1] ;
         T002X2_n943AgenciaUpdatedBy = new bool[] {false} ;
         T002X2_A968AgenciaBancoId = new int[1] ;
         T002X2_n968AgenciaBancoId = new bool[] {false} ;
         T002X15_A938AgenciaId = new int[1] ;
         T002X15_n938AgenciaId = new bool[] {false} ;
         T002X18_A937AgenciaCreatedByName = new string[] {""} ;
         T002X18_n937AgenciaCreatedByName = new bool[] {false} ;
         T002X19_A944AgenciaUpdatedByName = new string[] {""} ;
         T002X19_n944AgenciaUpdatedByName = new bool[] {false} ;
         T002X20_A969AgenciaBancoNome = new string[] {""} ;
         T002X20_n969AgenciaBancoNome = new bool[] {false} ;
         T002X20_A974AgenciaBancoCodigo = new int[1] ;
         T002X20_n974AgenciaBancoCodigo = new bool[] {false} ;
         T002X21_A951ContaBancariaId = new int[1] ;
         T002X22_A938AgenciaId = new int[1] ;
         T002X22_n938AgenciaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agencia__default(),
            new Object[][] {
                new Object[] {
               T002X2_A938AgenciaId, T002X2_A941AgenciaCreatedAt, T002X2_n941AgenciaCreatedAt, T002X2_A942AgenciaUpdatedAt, T002X2_n942AgenciaUpdatedAt, T002X2_A939AgenciaNumero, T002X2_n939AgenciaNumero, T002X2_A945AgenciaDigito, T002X2_n945AgenciaDigito, T002X2_A940AgenciaStatus,
               T002X2_n940AgenciaStatus, T002X2_A936AgenciaCreatedBy, T002X2_n936AgenciaCreatedBy, T002X2_A943AgenciaUpdatedBy, T002X2_n943AgenciaUpdatedBy, T002X2_A968AgenciaBancoId, T002X2_n968AgenciaBancoId
               }
               , new Object[] {
               T002X3_A938AgenciaId, T002X3_A941AgenciaCreatedAt, T002X3_n941AgenciaCreatedAt, T002X3_A942AgenciaUpdatedAt, T002X3_n942AgenciaUpdatedAt, T002X3_A939AgenciaNumero, T002X3_n939AgenciaNumero, T002X3_A945AgenciaDigito, T002X3_n945AgenciaDigito, T002X3_A940AgenciaStatus,
               T002X3_n940AgenciaStatus, T002X3_A936AgenciaCreatedBy, T002X3_n936AgenciaCreatedBy, T002X3_A943AgenciaUpdatedBy, T002X3_n943AgenciaUpdatedBy, T002X3_A968AgenciaBancoId, T002X3_n968AgenciaBancoId
               }
               , new Object[] {
               T002X4_A937AgenciaCreatedByName, T002X4_n937AgenciaCreatedByName
               }
               , new Object[] {
               T002X5_A944AgenciaUpdatedByName, T002X5_n944AgenciaUpdatedByName
               }
               , new Object[] {
               T002X6_A969AgenciaBancoNome, T002X6_n969AgenciaBancoNome, T002X6_A974AgenciaBancoCodigo, T002X6_n974AgenciaBancoCodigo
               }
               , new Object[] {
               T002X7_A938AgenciaId, T002X7_A941AgenciaCreatedAt, T002X7_n941AgenciaCreatedAt, T002X7_A942AgenciaUpdatedAt, T002X7_n942AgenciaUpdatedAt, T002X7_A969AgenciaBancoNome, T002X7_n969AgenciaBancoNome, T002X7_A974AgenciaBancoCodigo, T002X7_n974AgenciaBancoCodigo, T002X7_A939AgenciaNumero,
               T002X7_n939AgenciaNumero, T002X7_A945AgenciaDigito, T002X7_n945AgenciaDigito, T002X7_A940AgenciaStatus, T002X7_n940AgenciaStatus, T002X7_A937AgenciaCreatedByName, T002X7_n937AgenciaCreatedByName, T002X7_A944AgenciaUpdatedByName, T002X7_n944AgenciaUpdatedByName, T002X7_A936AgenciaCreatedBy,
               T002X7_n936AgenciaCreatedBy, T002X7_A943AgenciaUpdatedBy, T002X7_n943AgenciaUpdatedBy, T002X7_A968AgenciaBancoId, T002X7_n968AgenciaBancoId
               }
               , new Object[] {
               T002X8_A937AgenciaCreatedByName, T002X8_n937AgenciaCreatedByName
               }
               , new Object[] {
               T002X9_A944AgenciaUpdatedByName, T002X9_n944AgenciaUpdatedByName
               }
               , new Object[] {
               T002X10_A969AgenciaBancoNome, T002X10_n969AgenciaBancoNome, T002X10_A974AgenciaBancoCodigo, T002X10_n974AgenciaBancoCodigo
               }
               , new Object[] {
               T002X11_A938AgenciaId
               }
               , new Object[] {
               T002X12_A938AgenciaId
               }
               , new Object[] {
               T002X13_A938AgenciaId
               }
               , new Object[] {
               }
               , new Object[] {
               T002X15_A938AgenciaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002X18_A937AgenciaCreatedByName, T002X18_n937AgenciaCreatedByName
               }
               , new Object[] {
               T002X19_A944AgenciaUpdatedByName, T002X19_n944AgenciaUpdatedByName
               }
               , new Object[] {
               T002X20_A969AgenciaBancoNome, T002X20_n969AgenciaBancoNome, T002X20_A974AgenciaBancoCodigo, T002X20_n974AgenciaBancoCodigo
               }
               , new Object[] {
               T002X21_A951ContaBancariaId
               }
               , new Object[] {
               T002X22_A938AgenciaId
               }
            }
         );
         AV26Pgmname = "Agencia";
         Z940AgenciaStatus = true;
         n940AgenciaStatus = false;
         A940AgenciaStatus = true;
         n940AgenciaStatus = false;
         i940AgenciaStatus = true;
         n940AgenciaStatus = false;
      }

      private short Z936AgenciaCreatedBy ;
      private short Z943AgenciaUpdatedBy ;
      private short N936AgenciaCreatedBy ;
      private short N943AgenciaUpdatedBy ;
      private short GxWebError ;
      private short A936AgenciaCreatedBy ;
      private short A943AgenciaUpdatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV11Insert_AgenciaCreatedBy ;
      private short AV12Insert_AgenciaUpdatedBy ;
      private short Gx_BScreen ;
      private short RcdFound101 ;
      private short gxajaxcallmode ;
      private int wcpOAV7AgenciaId ;
      private int wcpOAV23BancoId ;
      private int Z938AgenciaId ;
      private int Z939AgenciaNumero ;
      private int Z945AgenciaDigito ;
      private int Z968AgenciaBancoId ;
      private int N968AgenciaBancoId ;
      private int A968AgenciaBancoId ;
      private int AV7AgenciaId ;
      private int AV23BancoId ;
      private int trnEnded ;
      private int edtAgenciaBancoNome_Enabled ;
      private int A939AgenciaNumero ;
      private int edtAgenciaNumero_Enabled ;
      private int A945AgenciaDigito ;
      private int edtAgenciaDigito_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A938AgenciaId ;
      private int edtAgenciaId_Enabled ;
      private int edtAgenciaId_Visible ;
      private int AV24Insert_AgenciaBancoId ;
      private int A974AgenciaBancoCodigo ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV27GXV1 ;
      private int Z974AgenciaBancoCodigo ;
      private int i968AgenciaBancoId ;
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
      private string edtAgenciaNumero_Internalname ;
      private string cmbAgenciaStatus_Internalname ;
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
      private string edtAgenciaNumero_Jsonclick ;
      private string edtAgenciaDigito_Internalname ;
      private string edtAgenciaDigito_Jsonclick ;
      private string cmbAgenciaStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtAgenciaId_Internalname ;
      private string edtAgenciaId_Jsonclick ;
      private string AV26Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode101 ;
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
      private DateTime Z941AgenciaCreatedAt ;
      private DateTime Z942AgenciaUpdatedAt ;
      private DateTime A941AgenciaCreatedAt ;
      private DateTime A942AgenciaUpdatedAt ;
      private DateTime i941AgenciaCreatedAt ;
      private bool Z940AgenciaStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n936AgenciaCreatedBy ;
      private bool n943AgenciaUpdatedBy ;
      private bool n968AgenciaBancoId ;
      private bool wbErr ;
      private bool A940AgenciaStatus ;
      private bool n940AgenciaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n939AgenciaNumero ;
      private bool n945AgenciaDigito ;
      private bool n941AgenciaCreatedAt ;
      private bool n942AgenciaUpdatedAt ;
      private bool n937AgenciaCreatedByName ;
      private bool n944AgenciaUpdatedByName ;
      private bool n974AgenciaBancoCodigo ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n969AgenciaBancoNome ;
      private bool n938AgenciaId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i940AgenciaStatus ;
      private string A969AgenciaBancoNome ;
      private string A937AgenciaCreatedByName ;
      private string A944AgenciaUpdatedByName ;
      private string Z937AgenciaCreatedByName ;
      private string Z944AgenciaUpdatedByName ;
      private string Z969AgenciaBancoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAgenciaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002X6_A969AgenciaBancoNome ;
      private bool[] T002X6_n969AgenciaBancoNome ;
      private int[] T002X6_A974AgenciaBancoCodigo ;
      private bool[] T002X6_n974AgenciaBancoCodigo ;
      private int[] T002X7_A938AgenciaId ;
      private bool[] T002X7_n938AgenciaId ;
      private DateTime[] T002X7_A941AgenciaCreatedAt ;
      private bool[] T002X7_n941AgenciaCreatedAt ;
      private DateTime[] T002X7_A942AgenciaUpdatedAt ;
      private bool[] T002X7_n942AgenciaUpdatedAt ;
      private string[] T002X7_A969AgenciaBancoNome ;
      private bool[] T002X7_n969AgenciaBancoNome ;
      private int[] T002X7_A974AgenciaBancoCodigo ;
      private bool[] T002X7_n974AgenciaBancoCodigo ;
      private int[] T002X7_A939AgenciaNumero ;
      private bool[] T002X7_n939AgenciaNumero ;
      private int[] T002X7_A945AgenciaDigito ;
      private bool[] T002X7_n945AgenciaDigito ;
      private bool[] T002X7_A940AgenciaStatus ;
      private bool[] T002X7_n940AgenciaStatus ;
      private string[] T002X7_A937AgenciaCreatedByName ;
      private bool[] T002X7_n937AgenciaCreatedByName ;
      private string[] T002X7_A944AgenciaUpdatedByName ;
      private bool[] T002X7_n944AgenciaUpdatedByName ;
      private short[] T002X7_A936AgenciaCreatedBy ;
      private bool[] T002X7_n936AgenciaCreatedBy ;
      private short[] T002X7_A943AgenciaUpdatedBy ;
      private bool[] T002X7_n943AgenciaUpdatedBy ;
      private int[] T002X7_A968AgenciaBancoId ;
      private bool[] T002X7_n968AgenciaBancoId ;
      private string[] T002X4_A937AgenciaCreatedByName ;
      private bool[] T002X4_n937AgenciaCreatedByName ;
      private string[] T002X5_A944AgenciaUpdatedByName ;
      private bool[] T002X5_n944AgenciaUpdatedByName ;
      private string[] T002X8_A937AgenciaCreatedByName ;
      private bool[] T002X8_n937AgenciaCreatedByName ;
      private string[] T002X9_A944AgenciaUpdatedByName ;
      private bool[] T002X9_n944AgenciaUpdatedByName ;
      private string[] T002X10_A969AgenciaBancoNome ;
      private bool[] T002X10_n969AgenciaBancoNome ;
      private int[] T002X10_A974AgenciaBancoCodigo ;
      private bool[] T002X10_n974AgenciaBancoCodigo ;
      private int[] T002X11_A938AgenciaId ;
      private bool[] T002X11_n938AgenciaId ;
      private int[] T002X3_A938AgenciaId ;
      private bool[] T002X3_n938AgenciaId ;
      private DateTime[] T002X3_A941AgenciaCreatedAt ;
      private bool[] T002X3_n941AgenciaCreatedAt ;
      private DateTime[] T002X3_A942AgenciaUpdatedAt ;
      private bool[] T002X3_n942AgenciaUpdatedAt ;
      private int[] T002X3_A939AgenciaNumero ;
      private bool[] T002X3_n939AgenciaNumero ;
      private int[] T002X3_A945AgenciaDigito ;
      private bool[] T002X3_n945AgenciaDigito ;
      private bool[] T002X3_A940AgenciaStatus ;
      private bool[] T002X3_n940AgenciaStatus ;
      private short[] T002X3_A936AgenciaCreatedBy ;
      private bool[] T002X3_n936AgenciaCreatedBy ;
      private short[] T002X3_A943AgenciaUpdatedBy ;
      private bool[] T002X3_n943AgenciaUpdatedBy ;
      private int[] T002X3_A968AgenciaBancoId ;
      private bool[] T002X3_n968AgenciaBancoId ;
      private int[] T002X12_A938AgenciaId ;
      private bool[] T002X12_n938AgenciaId ;
      private int[] T002X13_A938AgenciaId ;
      private bool[] T002X13_n938AgenciaId ;
      private int[] T002X2_A938AgenciaId ;
      private bool[] T002X2_n938AgenciaId ;
      private DateTime[] T002X2_A941AgenciaCreatedAt ;
      private bool[] T002X2_n941AgenciaCreatedAt ;
      private DateTime[] T002X2_A942AgenciaUpdatedAt ;
      private bool[] T002X2_n942AgenciaUpdatedAt ;
      private int[] T002X2_A939AgenciaNumero ;
      private bool[] T002X2_n939AgenciaNumero ;
      private int[] T002X2_A945AgenciaDigito ;
      private bool[] T002X2_n945AgenciaDigito ;
      private bool[] T002X2_A940AgenciaStatus ;
      private bool[] T002X2_n940AgenciaStatus ;
      private short[] T002X2_A936AgenciaCreatedBy ;
      private bool[] T002X2_n936AgenciaCreatedBy ;
      private short[] T002X2_A943AgenciaUpdatedBy ;
      private bool[] T002X2_n943AgenciaUpdatedBy ;
      private int[] T002X2_A968AgenciaBancoId ;
      private bool[] T002X2_n968AgenciaBancoId ;
      private int[] T002X15_A938AgenciaId ;
      private bool[] T002X15_n938AgenciaId ;
      private string[] T002X18_A937AgenciaCreatedByName ;
      private bool[] T002X18_n937AgenciaCreatedByName ;
      private string[] T002X19_A944AgenciaUpdatedByName ;
      private bool[] T002X19_n944AgenciaUpdatedByName ;
      private string[] T002X20_A969AgenciaBancoNome ;
      private bool[] T002X20_n969AgenciaBancoNome ;
      private int[] T002X20_A974AgenciaBancoCodigo ;
      private bool[] T002X20_n974AgenciaBancoCodigo ;
      private int[] T002X21_A951ContaBancariaId ;
      private int[] T002X22_A938AgenciaId ;
      private bool[] T002X22_n938AgenciaId ;
   }

   public class agencia__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002X2;
          prmT002X2 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X3;
          prmT002X3 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X4;
          prmT002X4 = new Object[] {
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002X5;
          prmT002X5 = new Object[] {
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002X6;
          prmT002X6 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X7;
          prmT002X7 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X8;
          prmT002X8 = new Object[] {
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002X9;
          prmT002X9 = new Object[] {
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002X10;
          prmT002X10 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X11;
          prmT002X11 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X12;
          prmT002X12 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X13;
          prmT002X13 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X14;
          prmT002X14 = new Object[] {
          new ParDef("AgenciaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X15;
          prmT002X15 = new Object[] {
          };
          Object[] prmT002X16;
          prmT002X16 = new Object[] {
          new ParDef("AgenciaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X17;
          prmT002X17 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X18;
          prmT002X18 = new Object[] {
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002X19;
          prmT002X19 = new Object[] {
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002X20;
          prmT002X20 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X21;
          prmT002X21 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002X22;
          prmT002X22 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002X2", "SELECT AgenciaId, AgenciaCreatedAt, AgenciaUpdatedAt, AgenciaNumero, AgenciaDigito, AgenciaStatus, AgenciaCreatedBy, AgenciaUpdatedBy, AgenciaBancoId FROM Agencia WHERE AgenciaId = :AgenciaId  FOR UPDATE OF Agencia NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002X2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X3", "SELECT AgenciaId, AgenciaCreatedAt, AgenciaUpdatedAt, AgenciaNumero, AgenciaDigito, AgenciaStatus, AgenciaCreatedBy, AgenciaUpdatedBy, AgenciaBancoId FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X4", "SELECT SecUserName AS AgenciaCreatedByName FROM SecUser WHERE SecUserId = :AgenciaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X5", "SELECT SecUserName AS AgenciaUpdatedByName FROM SecUser WHERE SecUserId = :AgenciaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X6", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X7", "SELECT TM1.AgenciaId, TM1.AgenciaCreatedAt, TM1.AgenciaUpdatedAt, T4.BancoNome AS AgenciaBancoNome, T4.BancoCodigo AS AgenciaBancoCodigo, TM1.AgenciaNumero, TM1.AgenciaDigito, TM1.AgenciaStatus, T2.SecUserName AS AgenciaCreatedByName, T3.SecUserName AS AgenciaUpdatedByName, TM1.AgenciaCreatedBy AS AgenciaCreatedBy, TM1.AgenciaUpdatedBy AS AgenciaUpdatedBy, TM1.AgenciaBancoId AS AgenciaBancoId FROM (((Agencia TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.AgenciaCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.AgenciaUpdatedBy) LEFT JOIN Banco T4 ON T4.BancoId = TM1.AgenciaBancoId) WHERE TM1.AgenciaId = :AgenciaId ORDER BY TM1.AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X8", "SELECT SecUserName AS AgenciaCreatedByName FROM SecUser WHERE SecUserId = :AgenciaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X9", "SELECT SecUserName AS AgenciaUpdatedByName FROM SecUser WHERE SecUserId = :AgenciaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X10", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X11", "SELECT AgenciaId FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X12", "SELECT AgenciaId FROM Agencia WHERE ( AgenciaId > :AgenciaId) ORDER BY AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002X13", "SELECT AgenciaId FROM Agencia WHERE ( AgenciaId < :AgenciaId) ORDER BY AgenciaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002X14", "SAVEPOINT gxupdate;INSERT INTO Agencia(AgenciaCreatedAt, AgenciaUpdatedAt, AgenciaNumero, AgenciaDigito, AgenciaStatus, AgenciaCreatedBy, AgenciaUpdatedBy, AgenciaBancoId) VALUES(:AgenciaCreatedAt, :AgenciaUpdatedAt, :AgenciaNumero, :AgenciaDigito, :AgenciaStatus, :AgenciaCreatedBy, :AgenciaUpdatedBy, :AgenciaBancoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002X14)
             ,new CursorDef("T002X15", "SELECT currval('AgenciaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X16", "SAVEPOINT gxupdate;UPDATE Agencia SET AgenciaCreatedAt=:AgenciaCreatedAt, AgenciaUpdatedAt=:AgenciaUpdatedAt, AgenciaNumero=:AgenciaNumero, AgenciaDigito=:AgenciaDigito, AgenciaStatus=:AgenciaStatus, AgenciaCreatedBy=:AgenciaCreatedBy, AgenciaUpdatedBy=:AgenciaUpdatedBy, AgenciaBancoId=:AgenciaBancoId  WHERE AgenciaId = :AgenciaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002X16)
             ,new CursorDef("T002X17", "SAVEPOINT gxupdate;DELETE FROM Agencia  WHERE AgenciaId = :AgenciaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002X17)
             ,new CursorDef("T002X18", "SELECT SecUserName AS AgenciaCreatedByName FROM SecUser WHERE SecUserId = :AgenciaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X19", "SELECT SecUserName AS AgenciaUpdatedByName FROM SecUser WHERE SecUserId = :AgenciaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X20", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002X21", "SELECT ContaBancariaId FROM ContaBancaria WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002X22", "SELECT AgenciaId FROM Agencia ORDER BY AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X22,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
