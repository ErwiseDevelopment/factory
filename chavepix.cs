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
   public class chavepix : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A951ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A951ContaBancariaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A938AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
            n938AgenciaId = false;
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A938AgenciaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
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
            gxLoad_25( A968AgenciaBancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A951ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A951ContaBancariaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A957ChavePIXCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "ChavePIXCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n957ChavePIXCreatedBy = false;
            AssignAttri("", false, "A957ChavePIXCreatedBy", ((0==A957ChavePIXCreatedBy)&&IsIns( )||n957ChavePIXCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A957ChavePIXCreatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A959ChavePIXUpdatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "ChavePIXUpdatedBy"), "."), 18, MidpointRounding.ToEven));
            n959ChavePIXUpdatedBy = false;
            AssignAttri("", false, "A959ChavePIXUpdatedBy", ((0==A959ChavePIXUpdatedBy)&&IsIns( )||n959ChavePIXUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A959ChavePIXUpdatedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "chavepix")), "chavepix") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "chavepix")))) ;
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
                  AV7ChavePIXId = (int)(Math.Round(NumberUtil.Val( GetPar( "ChavePIXId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ChavePIXId", StringUtil.LTrimStr( (decimal)(AV7ChavePIXId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCHAVEPIXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ChavePIXId), "ZZZZZZZZ9"), context));
                  AV15ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV15ContaBancariaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15ContaBancariaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Chave PIX", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbChavePIXTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public chavepix( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public chavepix( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ChavePIXId ,
                           int aP2_ContaBancariaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ChavePIXId = aP1_ChavePIXId;
         this.AV15ContaBancariaId = aP2_ContaBancariaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbChavePIXTipo = new GXCombobox();
         cmbChavePIXStatus = new GXCombobox();
         cmbChavePIXPrincipal = new GXCombobox();
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
         if ( cmbChavePIXTipo.ItemCount > 0 )
         {
            A962ChavePIXTipo = cmbChavePIXTipo.getValidValue(A962ChavePIXTipo);
            n962ChavePIXTipo = false;
            AssignAttri("", false, "A962ChavePIXTipo", A962ChavePIXTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChavePIXTipo.CurrentValue = StringUtil.RTrim( A962ChavePIXTipo);
            AssignProp("", false, cmbChavePIXTipo_Internalname, "Values", cmbChavePIXTipo.ToJavascriptSource(), true);
         }
         if ( cmbChavePIXStatus.ItemCount > 0 )
         {
            A964ChavePIXStatus = StringUtil.StrToBool( cmbChavePIXStatus.getValidValue(StringUtil.BoolToStr( A964ChavePIXStatus)));
            n964ChavePIXStatus = false;
            AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChavePIXStatus.CurrentValue = StringUtil.BoolToStr( A964ChavePIXStatus);
            AssignProp("", false, cmbChavePIXStatus_Internalname, "Values", cmbChavePIXStatus.ToJavascriptSource(), true);
         }
         if ( cmbChavePIXPrincipal.ItemCount > 0 )
         {
            A965ChavePIXPrincipal = StringUtil.StrToBool( cmbChavePIXPrincipal.getValidValue(StringUtil.BoolToStr( A965ChavePIXPrincipal)));
            n965ChavePIXPrincipal = false;
            AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
            AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Values", cmbChavePIXPrincipal.ToJavascriptSource(), true);
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
         GxWebStd.gx_single_line_edit( context, edtAgenciaBancoNome_Internalname, A969AgenciaBancoNome, StringUtil.RTrim( context.localUtil.Format( A969AgenciaBancoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaBancoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaBancoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIX.htm");
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
         GxWebStd.gx_single_line_edit( context, edtAgenciaNumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", "")), StringUtil.LTrim( ((edtAgenciaNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgenciaNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAgenciaNumero_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ChavePIX.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContaBancariaNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContaBancariaNumero_Internalname, "Conta", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaBancariaNumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ",", "")), StringUtil.LTrim( ((edtContaBancariaNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A952ContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A952ContaBancariaNumero), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaBancariaNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContaBancariaNumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ChavePIX.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbChavePIXTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbChavePIXTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChavePIXTipo, cmbChavePIXTipo_Internalname, StringUtil.RTrim( A962ChavePIXTipo), 1, cmbChavePIXTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbChavePIXTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_ChavePIX.htm");
         cmbChavePIXTipo.CurrentValue = StringUtil.RTrim( A962ChavePIXTipo);
         AssignProp("", false, cmbChavePIXTipo_Internalname, "Values", (string)(cmbChavePIXTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtChavePIXConteudo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChavePIXConteudo_Internalname, "Chave", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChavePIXConteudo_Internalname, A963ChavePIXConteudo, StringUtil.RTrim( context.localUtil.Format( A963ChavePIXConteudo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChavePIXConteudo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtChavePIXConteudo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ChavePIX.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbChavePIXStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbChavePIXStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChavePIXStatus, cmbChavePIXStatus_Internalname, StringUtil.BoolToStr( A964ChavePIXStatus), 1, cmbChavePIXStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbChavePIXStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_ChavePIX.htm");
         cmbChavePIXStatus.CurrentValue = StringUtil.BoolToStr( A964ChavePIXStatus);
         AssignProp("", false, cmbChavePIXStatus_Internalname, "Values", (string)(cmbChavePIXStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbChavePIXPrincipal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbChavePIXPrincipal_Internalname, "Principal", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChavePIXPrincipal, cmbChavePIXPrincipal_Internalname, StringUtil.BoolToStr( A965ChavePIXPrincipal), 1, cmbChavePIXPrincipal_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbChavePIXPrincipal.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ChavePIX.htm");
         cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
         AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Values", (string)(cmbChavePIXPrincipal.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChavePIX.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChavePIX.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChavePIX.htm");
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
         GxWebStd.gx_single_line_edit( context, edtChavePIXId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A961ChavePIXId), 9, 0, ",", "")), StringUtil.LTrim( ((edtChavePIXId_Enabled!=0) ? context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChavePIXId_Jsonclick, 0, "Attribute", "", "", "", "", edtChavePIXId_Visible, edtChavePIXId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ChavePIX.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaBancariaId_Internalname, ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", ""))), ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A951ContaBancariaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaBancariaId_Jsonclick, 0, "Attribute", "", "", "", "", edtContaBancariaId_Visible, edtContaBancariaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ChavePIX.htm");
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
         E112Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z961ChavePIXId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z961ChavePIXId"), ",", "."), 18, MidpointRounding.ToEven));
               Z966ChavePIXCreatedAt = context.localUtil.CToT( cgiGet( "Z966ChavePIXCreatedAt"), 0);
               n966ChavePIXCreatedAt = ((DateTime.MinValue==A966ChavePIXCreatedAt) ? true : false);
               Z967ChavePIXUpdatedAt = context.localUtil.CToT( cgiGet( "Z967ChavePIXUpdatedAt"), 0);
               n967ChavePIXUpdatedAt = ((DateTime.MinValue==A967ChavePIXUpdatedAt) ? true : false);
               Z965ChavePIXPrincipal = StringUtil.StrToBool( cgiGet( "Z965ChavePIXPrincipal"));
               n965ChavePIXPrincipal = ((false==A965ChavePIXPrincipal) ? true : false);
               Z962ChavePIXTipo = cgiGet( "Z962ChavePIXTipo");
               n962ChavePIXTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A962ChavePIXTipo)) ? true : false);
               Z963ChavePIXConteudo = cgiGet( "Z963ChavePIXConteudo");
               n963ChavePIXConteudo = (String.IsNullOrEmpty(StringUtil.RTrim( A963ChavePIXConteudo)) ? true : false);
               Z964ChavePIXStatus = StringUtil.StrToBool( cgiGet( "Z964ChavePIXStatus"));
               n964ChavePIXStatus = ((false==A964ChavePIXStatus) ? true : false);
               Z951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z951ContaBancariaId"), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
               Z957ChavePIXCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z957ChavePIXCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n957ChavePIXCreatedBy = ((0==A957ChavePIXCreatedBy) ? true : false);
               Z959ChavePIXUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z959ChavePIXUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n959ChavePIXUpdatedBy = ((0==A959ChavePIXUpdatedBy) ? true : false);
               A966ChavePIXCreatedAt = context.localUtil.CToT( cgiGet( "Z966ChavePIXCreatedAt"), 0);
               n966ChavePIXCreatedAt = false;
               n966ChavePIXCreatedAt = ((DateTime.MinValue==A966ChavePIXCreatedAt) ? true : false);
               A967ChavePIXUpdatedAt = context.localUtil.CToT( cgiGet( "Z967ChavePIXUpdatedAt"), 0);
               n967ChavePIXUpdatedAt = false;
               n967ChavePIXUpdatedAt = ((DateTime.MinValue==A967ChavePIXUpdatedAt) ? true : false);
               A957ChavePIXCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z957ChavePIXCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n957ChavePIXCreatedBy = false;
               n957ChavePIXCreatedBy = ((0==A957ChavePIXCreatedBy) ? true : false);
               A959ChavePIXUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z959ChavePIXUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n959ChavePIXUpdatedBy = false;
               n959ChavePIXUpdatedBy = ((0==A959ChavePIXUpdatedBy) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N951ContaBancariaId"), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
               N957ChavePIXCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N957ChavePIXCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n957ChavePIXCreatedBy = ((0==A957ChavePIXCreatedBy) ? true : false);
               N959ChavePIXUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N959ChavePIXUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n959ChavePIXUpdatedBy = ((0==A959ChavePIXUpdatedBy) ? true : false);
               AV7ChavePIXId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCHAVEPIXID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTABANCARIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV11Insert_ContaBancariaId), 9, 0));
               AV15ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONTABANCARIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_ChavePIXCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CHAVEPIXCREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ChavePIXCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ChavePIXCreatedBy), 4, 0));
               A957ChavePIXCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CHAVEPIXCREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n957ChavePIXCreatedBy = ((0==A957ChavePIXCreatedBy) ? true : false);
               AV13Insert_ChavePIXUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CHAVEPIXUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ChavePIXUpdatedBy", StringUtil.LTrimStr( (decimal)(AV13Insert_ChavePIXUpdatedBy), 4, 0));
               A959ChavePIXUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CHAVEPIXUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               n959ChavePIXUpdatedBy = ((0==A959ChavePIXUpdatedBy) ? true : false);
               A966ChavePIXCreatedAt = context.localUtil.CToT( cgiGet( "CHAVEPIXCREATEDAT"), 0);
               n966ChavePIXCreatedAt = ((DateTime.MinValue==A966ChavePIXCreatedAt) ? true : false);
               A967ChavePIXUpdatedAt = context.localUtil.CToT( cgiGet( "CHAVEPIXUPDATEDAT"), 0);
               n967ChavePIXUpdatedAt = ((DateTime.MinValue==A967ChavePIXUpdatedAt) ? true : false);
               A970ContaBancariaCountChavePIX_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIACOUNTCHAVEPIX_F"), ",", "."), 18, MidpointRounding.ToEven));
               n970ContaBancariaCountChavePIX_F = false;
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIAID"), ",", "."), 18, MidpointRounding.ToEven));
               A958ChavePIXCreatedByName = cgiGet( "CHAVEPIXCREATEDBYNAME");
               n958ChavePIXCreatedByName = false;
               A960ChavePIXUpdatedByName = cgiGet( "CHAVEPIXUPDATEDBYNAME");
               n960ChavePIXUpdatedByName = false;
               A968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV17Pgmname = cgiGet( "vPGMNAME");
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
               A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n952ContaBancariaNumero = false;
               AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
               cmbChavePIXTipo.CurrentValue = cgiGet( cmbChavePIXTipo_Internalname);
               A962ChavePIXTipo = cgiGet( cmbChavePIXTipo_Internalname);
               n962ChavePIXTipo = false;
               AssignAttri("", false, "A962ChavePIXTipo", A962ChavePIXTipo);
               n962ChavePIXTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A962ChavePIXTipo)) ? true : false);
               A963ChavePIXConteudo = cgiGet( edtChavePIXConteudo_Internalname);
               n963ChavePIXConteudo = false;
               AssignAttri("", false, "A963ChavePIXConteudo", A963ChavePIXConteudo);
               n963ChavePIXConteudo = (String.IsNullOrEmpty(StringUtil.RTrim( A963ChavePIXConteudo)) ? true : false);
               cmbChavePIXStatus.CurrentValue = cgiGet( cmbChavePIXStatus_Internalname);
               A964ChavePIXStatus = StringUtil.StrToBool( cgiGet( cmbChavePIXStatus_Internalname));
               n964ChavePIXStatus = false;
               AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
               n964ChavePIXStatus = ((false==A964ChavePIXStatus) ? true : false);
               cmbChavePIXPrincipal.CurrentValue = cgiGet( cmbChavePIXPrincipal_Internalname);
               A965ChavePIXPrincipal = StringUtil.StrToBool( cgiGet( cmbChavePIXPrincipal_Internalname));
               n965ChavePIXPrincipal = false;
               AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
               A961ChavePIXId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtChavePIXId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
               n951ContaBancariaId = ((StringUtil.StrCmp(cgiGet( edtContaBancariaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTABANCARIAID");
                  AnyError = 1;
                  GX_FocusControl = edtContaBancariaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A951ContaBancariaId = 0;
                  n951ContaBancariaId = false;
                  AssignAttri("", false, "A951ContaBancariaId", (n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
               }
               else
               {
                  A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaBancariaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A951ContaBancariaId", (n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ChavePIX");
               A961ChavePIXId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtChavePIXId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
               forbiddenHiddens.Add("ChavePIXId", context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContaBancariaId", context.localUtil.Format( (decimal)(AV11Insert_ContaBancariaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ChavePIXCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ChavePIXCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_ChavePIXUpdatedBy", context.localUtil.Format( (decimal)(AV13Insert_ChavePIXUpdatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ChavePIXCreatedAt", context.localUtil.Format( A966ChavePIXCreatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("ChavePIXUpdatedAt", context.localUtil.Format( A967ChavePIXUpdatedAt, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A961ChavePIXId != Z961ChavePIXId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("chavepix:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A961ChavePIXId = (int)(Math.Round(NumberUtil.Val( GetPar( "ChavePIXId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
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
                     sMode103 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode103;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound103 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2Z0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CHAVEPIXID");
                        AnyError = 1;
                        GX_FocusControl = edtChavePIXId_Internalname;
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
                           E112Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122Z2 ();
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
            E122Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2Z103( ) ;
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
            DisableAttributes2Z103( ) ;
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

      protected void CONFIRM_2Z0( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Z103( ) ;
            }
            else
            {
               CheckExtendedTable2Z103( ) ;
               CloseExtendedTableCursors2Z103( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2Z0( )
      {
      }

      protected void E112Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ContaBancariaId") == 0 )
               {
                  AV11Insert_ContaBancariaId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV11Insert_ContaBancariaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ChavePIXCreatedBy") == 0 )
               {
                  AV12Insert_ChavePIXCreatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ChavePIXCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ChavePIXCreatedBy), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ChavePIXUpdatedBy") == 0 )
               {
                  AV13Insert_ChavePIXUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ChavePIXUpdatedBy", StringUtil.LTrimStr( (decimal)(AV13Insert_ChavePIXUpdatedBy), 4, 0));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
         edtChavePIXId_Visible = 0;
         AssignProp("", false, edtChavePIXId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtChavePIXId_Visible), 5, 0), true);
         edtContaBancariaId_Visible = 0;
         AssignProp("", false, edtContaBancariaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Visible), 5, 0), true);
      }

      protected void E122Z2( )
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

      protected void ZM2Z103( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z966ChavePIXCreatedAt = T002Z3_A966ChavePIXCreatedAt[0];
               Z967ChavePIXUpdatedAt = T002Z3_A967ChavePIXUpdatedAt[0];
               Z965ChavePIXPrincipal = T002Z3_A965ChavePIXPrincipal[0];
               Z962ChavePIXTipo = T002Z3_A962ChavePIXTipo[0];
               Z963ChavePIXConteudo = T002Z3_A963ChavePIXConteudo[0];
               Z964ChavePIXStatus = T002Z3_A964ChavePIXStatus[0];
               Z951ContaBancariaId = T002Z3_A951ContaBancariaId[0];
               Z957ChavePIXCreatedBy = T002Z3_A957ChavePIXCreatedBy[0];
               Z959ChavePIXUpdatedBy = T002Z3_A959ChavePIXUpdatedBy[0];
            }
            else
            {
               Z966ChavePIXCreatedAt = A966ChavePIXCreatedAt;
               Z967ChavePIXUpdatedAt = A967ChavePIXUpdatedAt;
               Z965ChavePIXPrincipal = A965ChavePIXPrincipal;
               Z962ChavePIXTipo = A962ChavePIXTipo;
               Z963ChavePIXConteudo = A963ChavePIXConteudo;
               Z964ChavePIXStatus = A964ChavePIXStatus;
               Z951ContaBancariaId = A951ContaBancariaId;
               Z957ChavePIXCreatedBy = A957ChavePIXCreatedBy;
               Z959ChavePIXUpdatedBy = A959ChavePIXUpdatedBy;
            }
         }
         if ( GX_JID == -20 )
         {
            Z961ChavePIXId = A961ChavePIXId;
            Z966ChavePIXCreatedAt = A966ChavePIXCreatedAt;
            Z967ChavePIXUpdatedAt = A967ChavePIXUpdatedAt;
            Z965ChavePIXPrincipal = A965ChavePIXPrincipal;
            Z962ChavePIXTipo = A962ChavePIXTipo;
            Z963ChavePIXConteudo = A963ChavePIXConteudo;
            Z964ChavePIXStatus = A964ChavePIXStatus;
            Z951ContaBancariaId = A951ContaBancariaId;
            Z957ChavePIXCreatedBy = A957ChavePIXCreatedBy;
            Z959ChavePIXUpdatedBy = A959ChavePIXUpdatedBy;
            Z958ChavePIXCreatedByName = A958ChavePIXCreatedByName;
            Z960ChavePIXUpdatedByName = A960ChavePIXUpdatedByName;
            Z938AgenciaId = A938AgenciaId;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
      }

      protected void standaloneNotModal( )
      {
         edtChavePIXId_Enabled = 0;
         AssignProp("", false, edtChavePIXId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChavePIXId_Enabled), 5, 0), true);
         cmbChavePIXPrincipal.Enabled = 0;
         AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXPrincipal.Enabled), 5, 0), true);
         AV17Pgmname = "ChavePIX";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtChavePIXId_Enabled = 0;
         AssignProp("", false, edtChavePIXId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChavePIXId_Enabled), 5, 0), true);
         cmbChavePIXPrincipal.Enabled = 0;
         AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXPrincipal.Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ChavePIXId) )
         {
            A961ChavePIXId = AV7ChavePIXId;
            AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ContaBancariaId) )
         {
            edtContaBancariaId_Enabled = 0;
            AssignProp("", false, edtContaBancariaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Enabled), 5, 0), true);
         }
         else
         {
            edtContaBancariaId_Enabled = 1;
            AssignProp("", false, edtContaBancariaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A966ChavePIXCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n966ChavePIXCreatedAt = false;
            AssignAttri("", false, "A966ChavePIXCreatedAt", context.localUtil.TToC( A966ChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A967ChavePIXUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n967ChavePIXUpdatedAt = false;
            AssignAttri("", false, "A967ChavePIXUpdatedAt", context.localUtil.TToC( A967ChavePIXUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
         {
            cmbChavePIXStatus.Enabled = 0;
            AssignProp("", false, cmbChavePIXStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbChavePIXStatus.Enabled = 1;
            AssignProp("", false, cmbChavePIXStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbChavePIXStatus.Enabled = 0;
            AssignProp("", false, cmbChavePIXStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXStatus.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ChavePIXCreatedBy) )
         {
            A957ChavePIXCreatedBy = AV12Insert_ChavePIXCreatedBy;
            n957ChavePIXCreatedBy = false;
            AssignAttri("", false, "A957ChavePIXCreatedBy", ((0==A957ChavePIXCreatedBy)&&IsIns( )||n957ChavePIXCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A957ChavePIXCreatedBy = AV8WWPContext.gxTpr_Userid;
               n957ChavePIXCreatedBy = false;
               AssignAttri("", false, "A957ChavePIXCreatedBy", ((0==A957ChavePIXCreatedBy)&&IsIns( )||n957ChavePIXCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ChavePIXUpdatedBy) )
         {
            A959ChavePIXUpdatedBy = AV13Insert_ChavePIXUpdatedBy;
            n959ChavePIXUpdatedBy = false;
            AssignAttri("", false, "A959ChavePIXUpdatedBy", ((0==A959ChavePIXUpdatedBy)&&IsIns( )||n959ChavePIXUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A959ChavePIXUpdatedBy = AV8WWPContext.gxTpr_Userid;
               n959ChavePIXUpdatedBy = false;
               AssignAttri("", false, "A959ChavePIXUpdatedBy", ((0==A959ChavePIXUpdatedBy)&&IsIns( )||n959ChavePIXUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ContaBancariaId) )
         {
            A951ContaBancariaId = AV11Insert_ContaBancariaId;
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
         }
         else
         {
            A951ContaBancariaId = AV15ContaBancariaId;
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
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
         if ( IsIns( )  && (false==A964ChavePIXStatus) && ( Gx_BScreen == 0 ) )
         {
            A964ChavePIXStatus = true;
            n964ChavePIXStatus = false;
            AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002Z5 */
            pr_default.execute(3, new Object[] {n957ChavePIXCreatedBy, A957ChavePIXCreatedBy});
            A958ChavePIXCreatedByName = T002Z5_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = T002Z5_n958ChavePIXCreatedByName[0];
            pr_default.close(3);
            /* Using cursor T002Z6 */
            pr_default.execute(4, new Object[] {n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
            A960ChavePIXUpdatedByName = T002Z6_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = T002Z6_n960ChavePIXUpdatedByName[0];
            pr_default.close(4);
            /* Using cursor T002Z4 */
            pr_default.execute(2, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            A938AgenciaId = T002Z4_A938AgenciaId[0];
            n938AgenciaId = T002Z4_n938AgenciaId[0];
            A952ContaBancariaNumero = T002Z4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T002Z4_n952ContaBancariaNumero[0];
            AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
            pr_default.close(2);
            /* Using cursor T002Z7 */
            pr_default.execute(5, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = T002Z7_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002Z7_n968AgenciaBancoId[0];
            A939AgenciaNumero = T002Z7_A939AgenciaNumero[0];
            n939AgenciaNumero = T002Z7_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
            pr_default.close(5);
            /* Using cursor T002Z8 */
            pr_default.execute(6, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T002Z8_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002Z8_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            pr_default.close(6);
            /* Using cursor T002Z10 */
            pr_default.execute(7, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A970ContaBancariaCountChavePIX_F = T002Z10_A970ContaBancariaCountChavePIX_F[0];
               n970ContaBancariaCountChavePIX_F = T002Z10_n970ContaBancariaCountChavePIX_F[0];
            }
            else
            {
               A970ContaBancariaCountChavePIX_F = 0;
               n970ContaBancariaCountChavePIX_F = false;
               AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
            }
            pr_default.close(7);
         }
      }

      protected void Load2Z103( )
      {
         /* Using cursor T002Z12 */
         pr_default.execute(8, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound103 = 1;
            A938AgenciaId = T002Z12_A938AgenciaId[0];
            n938AgenciaId = T002Z12_n938AgenciaId[0];
            A968AgenciaBancoId = T002Z12_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002Z12_n968AgenciaBancoId[0];
            A966ChavePIXCreatedAt = T002Z12_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = T002Z12_n966ChavePIXCreatedAt[0];
            A967ChavePIXUpdatedAt = T002Z12_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = T002Z12_n967ChavePIXUpdatedAt[0];
            A965ChavePIXPrincipal = T002Z12_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = T002Z12_n965ChavePIXPrincipal[0];
            AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
            A962ChavePIXTipo = T002Z12_A962ChavePIXTipo[0];
            n962ChavePIXTipo = T002Z12_n962ChavePIXTipo[0];
            AssignAttri("", false, "A962ChavePIXTipo", A962ChavePIXTipo);
            A963ChavePIXConteudo = T002Z12_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = T002Z12_n963ChavePIXConteudo[0];
            AssignAttri("", false, "A963ChavePIXConteudo", A963ChavePIXConteudo);
            A964ChavePIXStatus = T002Z12_A964ChavePIXStatus[0];
            n964ChavePIXStatus = T002Z12_n964ChavePIXStatus[0];
            AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
            A952ContaBancariaNumero = T002Z12_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T002Z12_n952ContaBancariaNumero[0];
            AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
            A939AgenciaNumero = T002Z12_A939AgenciaNumero[0];
            n939AgenciaNumero = T002Z12_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
            A969AgenciaBancoNome = T002Z12_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002Z12_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            A958ChavePIXCreatedByName = T002Z12_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = T002Z12_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = T002Z12_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = T002Z12_n960ChavePIXUpdatedByName[0];
            A951ContaBancariaId = T002Z12_A951ContaBancariaId[0];
            n951ContaBancariaId = T002Z12_n951ContaBancariaId[0];
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            A957ChavePIXCreatedBy = T002Z12_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = T002Z12_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = T002Z12_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = T002Z12_n959ChavePIXUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = T002Z12_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Z12_n970ContaBancariaCountChavePIX_F[0];
            ZM2Z103( -20) ;
         }
         pr_default.close(8);
         OnLoadActions2Z103( ) ;
      }

      protected void OnLoadActions2Z103( )
      {
         if ( ( A970ContaBancariaCountChavePIX_F == 0 ) && IsIns( )  )
         {
            A965ChavePIXPrincipal = true;
            n965ChavePIXPrincipal = false;
            AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
         }
         else
         {
            if ( ( A970ContaBancariaCountChavePIX_F == 0 ) && IsIns( )  )
            {
               A965ChavePIXPrincipal = false;
               n965ChavePIXPrincipal = false;
               AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
            }
            else
            {
               if ( ! A964ChavePIXStatus && IsUpd( )  )
               {
                  A965ChavePIXPrincipal = false;
                  n965ChavePIXPrincipal = false;
                  AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
               }
            }
         }
      }

      protected void CheckExtendedTable2Z103( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A962ChavePIXTipo, "CPF") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "CNPJ") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "Telefone") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "Email") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "ChaveAleatoria") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A962ChavePIXTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "CHAVEPIXTIPO");
            AnyError = 1;
            GX_FocusControl = cmbChavePIXTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002Z4 */
         pr_default.execute(2, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
               GX_FocusControl = edtContaBancariaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A938AgenciaId = T002Z4_A938AgenciaId[0];
         n938AgenciaId = T002Z4_n938AgenciaId[0];
         A952ContaBancariaNumero = T002Z4_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = T002Z4_n952ContaBancariaNumero[0];
         AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
         pr_default.close(2);
         /* Using cursor T002Z7 */
         pr_default.execute(5, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = T002Z7_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T002Z7_n968AgenciaBancoId[0];
         A939AgenciaNumero = T002Z7_A939AgenciaNumero[0];
         n939AgenciaNumero = T002Z7_n939AgenciaNumero[0];
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         pr_default.close(5);
         /* Using cursor T002Z8 */
         pr_default.execute(6, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002Z8_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002Z8_n969AgenciaBancoNome[0];
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         pr_default.close(6);
         /* Using cursor T002Z10 */
         pr_default.execute(7, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = T002Z10_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Z10_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
            AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
         }
         pr_default.close(7);
         if ( ( A970ContaBancariaCountChavePIX_F == 0 ) && IsIns( )  )
         {
            A965ChavePIXPrincipal = true;
            n965ChavePIXPrincipal = false;
            AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
         }
         else
         {
            if ( ( A970ContaBancariaCountChavePIX_F == 0 ) && IsIns( )  )
            {
               A965ChavePIXPrincipal = false;
               n965ChavePIXPrincipal = false;
               AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
            }
            else
            {
               if ( ! A964ChavePIXStatus && IsUpd( )  )
               {
                  A965ChavePIXPrincipal = false;
                  n965ChavePIXPrincipal = false;
                  AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
               }
            }
         }
         /* Using cursor T002Z5 */
         pr_default.execute(3, new Object[] {n957ChavePIXCreatedBy, A957ChavePIXCreatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A957ChavePIXCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Chave PIXCreated By'.", "ForeignKeyNotFound", 1, "CHAVEPIXCREATEDBY");
               AnyError = 1;
            }
         }
         A958ChavePIXCreatedByName = T002Z5_A958ChavePIXCreatedByName[0];
         n958ChavePIXCreatedByName = T002Z5_n958ChavePIXCreatedByName[0];
         pr_default.close(3);
         /* Using cursor T002Z6 */
         pr_default.execute(4, new Object[] {n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A959ChavePIXUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Chave PIXUpdated By'.", "ForeignKeyNotFound", 1, "CHAVEPIXUPDATEDBY");
               AnyError = 1;
            }
         }
         A960ChavePIXUpdatedByName = T002Z6_A960ChavePIXUpdatedByName[0];
         n960ChavePIXUpdatedByName = T002Z6_n960ChavePIXUpdatedByName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2Z103( )
      {
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( int A951ContaBancariaId )
      {
         /* Using cursor T002Z13 */
         pr_default.execute(9, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
               GX_FocusControl = edtContaBancariaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A938AgenciaId = T002Z13_A938AgenciaId[0];
         n938AgenciaId = T002Z13_n938AgenciaId[0];
         A952ContaBancariaNumero = T002Z13_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = T002Z13_n952ContaBancariaNumero[0];
         AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_24( int A938AgenciaId )
      {
         /* Using cursor T002Z14 */
         pr_default.execute(10, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = T002Z14_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T002Z14_n968AgenciaBancoId[0];
         A939AgenciaNumero = T002Z14_A939AgenciaNumero[0];
         n939AgenciaNumero = T002Z14_n939AgenciaNumero[0];
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_25( int A968AgenciaBancoId )
      {
         /* Using cursor T002Z15 */
         pr_default.execute(11, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002Z15_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002Z15_n969AgenciaBancoNome[0];
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A969AgenciaBancoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_26( int A951ContaBancariaId )
      {
         /* Using cursor T002Z17 */
         pr_default.execute(12, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = T002Z17_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Z17_n970ContaBancariaCountChavePIX_F[0];
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
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_22( short A957ChavePIXCreatedBy )
      {
         /* Using cursor T002Z18 */
         pr_default.execute(13, new Object[] {n957ChavePIXCreatedBy, A957ChavePIXCreatedBy});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A957ChavePIXCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Chave PIXCreated By'.", "ForeignKeyNotFound", 1, "CHAVEPIXCREATEDBY");
               AnyError = 1;
            }
         }
         A958ChavePIXCreatedByName = T002Z18_A958ChavePIXCreatedByName[0];
         n958ChavePIXCreatedByName = T002Z18_n958ChavePIXCreatedByName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A958ChavePIXCreatedByName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_23( short A959ChavePIXUpdatedBy )
      {
         /* Using cursor T002Z19 */
         pr_default.execute(14, new Object[] {n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A959ChavePIXUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Chave PIXUpdated By'.", "ForeignKeyNotFound", 1, "CHAVEPIXUPDATEDBY");
               AnyError = 1;
            }
         }
         A960ChavePIXUpdatedByName = T002Z19_A960ChavePIXUpdatedByName[0];
         n960ChavePIXUpdatedByName = T002Z19_n960ChavePIXUpdatedByName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A960ChavePIXUpdatedByName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey2Z103( )
      {
         /* Using cursor T002Z20 */
         pr_default.execute(15, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound103 = 1;
         }
         else
         {
            RcdFound103 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Z3 */
         pr_default.execute(1, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Z103( 20) ;
            RcdFound103 = 1;
            A961ChavePIXId = T002Z3_A961ChavePIXId[0];
            AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
            A966ChavePIXCreatedAt = T002Z3_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = T002Z3_n966ChavePIXCreatedAt[0];
            A967ChavePIXUpdatedAt = T002Z3_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = T002Z3_n967ChavePIXUpdatedAt[0];
            A965ChavePIXPrincipal = T002Z3_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = T002Z3_n965ChavePIXPrincipal[0];
            AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
            A962ChavePIXTipo = T002Z3_A962ChavePIXTipo[0];
            n962ChavePIXTipo = T002Z3_n962ChavePIXTipo[0];
            AssignAttri("", false, "A962ChavePIXTipo", A962ChavePIXTipo);
            A963ChavePIXConteudo = T002Z3_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = T002Z3_n963ChavePIXConteudo[0];
            AssignAttri("", false, "A963ChavePIXConteudo", A963ChavePIXConteudo);
            A964ChavePIXStatus = T002Z3_A964ChavePIXStatus[0];
            n964ChavePIXStatus = T002Z3_n964ChavePIXStatus[0];
            AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
            A951ContaBancariaId = T002Z3_A951ContaBancariaId[0];
            n951ContaBancariaId = T002Z3_n951ContaBancariaId[0];
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            A957ChavePIXCreatedBy = T002Z3_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = T002Z3_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = T002Z3_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = T002Z3_n959ChavePIXUpdatedBy[0];
            Z961ChavePIXId = A961ChavePIXId;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2Z103( ) ;
            if ( AnyError == 1 )
            {
               RcdFound103 = 0;
               InitializeNonKey2Z103( ) ;
            }
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound103 = 0;
            InitializeNonKey2Z103( ) ;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Z103( ) ;
         if ( RcdFound103 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound103 = 0;
         /* Using cursor T002Z21 */
         pr_default.execute(16, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T002Z21_A961ChavePIXId[0] < A961ChavePIXId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T002Z21_A961ChavePIXId[0] > A961ChavePIXId ) ) )
            {
               A961ChavePIXId = T002Z21_A961ChavePIXId[0];
               AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
               RcdFound103 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound103 = 0;
         /* Using cursor T002Z22 */
         pr_default.execute(17, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T002Z22_A961ChavePIXId[0] > A961ChavePIXId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T002Z22_A961ChavePIXId[0] < A961ChavePIXId ) ) )
            {
               A961ChavePIXId = T002Z22_A961ChavePIXId[0];
               AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
               RcdFound103 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Z103( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbChavePIXTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Z103( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound103 == 1 )
            {
               if ( A961ChavePIXId != Z961ChavePIXId )
               {
                  A961ChavePIXId = Z961ChavePIXId;
                  AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CHAVEPIXID");
                  AnyError = 1;
                  GX_FocusControl = edtChavePIXId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbChavePIXTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2Z103( ) ;
                  GX_FocusControl = cmbChavePIXTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A961ChavePIXId != Z961ChavePIXId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbChavePIXTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Z103( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHAVEPIXID");
                     AnyError = 1;
                     GX_FocusControl = edtChavePIXId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbChavePIXTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Z103( ) ;
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
         if ( A961ChavePIXId != Z961ChavePIXId )
         {
            A961ChavePIXId = Z961ChavePIXId;
            AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CHAVEPIXID");
            AnyError = 1;
            GX_FocusControl = edtChavePIXId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbChavePIXTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2Z103( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Z2 */
            pr_default.execute(0, new Object[] {A961ChavePIXId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ChavePIX"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z966ChavePIXCreatedAt != T002Z2_A966ChavePIXCreatedAt[0] ) || ( Z967ChavePIXUpdatedAt != T002Z2_A967ChavePIXUpdatedAt[0] ) || ( Z965ChavePIXPrincipal != T002Z2_A965ChavePIXPrincipal[0] ) || ( StringUtil.StrCmp(Z962ChavePIXTipo, T002Z2_A962ChavePIXTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z963ChavePIXConteudo, T002Z2_A963ChavePIXConteudo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z964ChavePIXStatus != T002Z2_A964ChavePIXStatus[0] ) || ( Z951ContaBancariaId != T002Z2_A951ContaBancariaId[0] ) || ( Z957ChavePIXCreatedBy != T002Z2_A957ChavePIXCreatedBy[0] ) || ( Z959ChavePIXUpdatedBy != T002Z2_A959ChavePIXUpdatedBy[0] ) )
            {
               if ( Z966ChavePIXCreatedAt != T002Z2_A966ChavePIXCreatedAt[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z966ChavePIXCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A966ChavePIXCreatedAt[0]);
               }
               if ( Z967ChavePIXUpdatedAt != T002Z2_A967ChavePIXUpdatedAt[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z967ChavePIXUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A967ChavePIXUpdatedAt[0]);
               }
               if ( Z965ChavePIXPrincipal != T002Z2_A965ChavePIXPrincipal[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXPrincipal");
                  GXUtil.WriteLogRaw("Old: ",Z965ChavePIXPrincipal);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A965ChavePIXPrincipal[0]);
               }
               if ( StringUtil.StrCmp(Z962ChavePIXTipo, T002Z2_A962ChavePIXTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXTipo");
                  GXUtil.WriteLogRaw("Old: ",Z962ChavePIXTipo);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A962ChavePIXTipo[0]);
               }
               if ( StringUtil.StrCmp(Z963ChavePIXConteudo, T002Z2_A963ChavePIXConteudo[0]) != 0 )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXConteudo");
                  GXUtil.WriteLogRaw("Old: ",Z963ChavePIXConteudo);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A963ChavePIXConteudo[0]);
               }
               if ( Z964ChavePIXStatus != T002Z2_A964ChavePIXStatus[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXStatus");
                  GXUtil.WriteLogRaw("Old: ",Z964ChavePIXStatus);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A964ChavePIXStatus[0]);
               }
               if ( Z951ContaBancariaId != T002Z2_A951ContaBancariaId[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ContaBancariaId");
                  GXUtil.WriteLogRaw("Old: ",Z951ContaBancariaId);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A951ContaBancariaId[0]);
               }
               if ( Z957ChavePIXCreatedBy != T002Z2_A957ChavePIXCreatedBy[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z957ChavePIXCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A957ChavePIXCreatedBy[0]);
               }
               if ( Z959ChavePIXUpdatedBy != T002Z2_A959ChavePIXUpdatedBy[0] )
               {
                  GXUtil.WriteLog("chavepix:[seudo value changed for attri]"+"ChavePIXUpdatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z959ChavePIXUpdatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A959ChavePIXUpdatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ChavePIX"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Z103( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Z103( 0) ;
            CheckOptimisticConcurrency2Z103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Z103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Z103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Z23 */
                     pr_default.execute(18, new Object[] {n966ChavePIXCreatedAt, A966ChavePIXCreatedAt, n967ChavePIXUpdatedAt, A967ChavePIXUpdatedAt, n965ChavePIXPrincipal, A965ChavePIXPrincipal, n962ChavePIXTipo, A962ChavePIXTipo, n963ChavePIXConteudo, A963ChavePIXConteudo, n964ChavePIXStatus, A964ChavePIXStatus, n951ContaBancariaId, A951ContaBancariaId, n957ChavePIXCreatedBy, A957ChavePIXCreatedBy, n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002Z24 */
                     pr_default.execute(19);
                     A961ChavePIXId = T002Z24_A961ChavePIXId[0];
                     AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("ChavePIX");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2Z0( ) ;
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
               Load2Z103( ) ;
            }
            EndLevel2Z103( ) ;
         }
         CloseExtendedTableCursors2Z103( ) ;
      }

      protected void Update2Z103( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Z103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Z103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Z103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Z25 */
                     pr_default.execute(20, new Object[] {n966ChavePIXCreatedAt, A966ChavePIXCreatedAt, n967ChavePIXUpdatedAt, A967ChavePIXUpdatedAt, n965ChavePIXPrincipal, A965ChavePIXPrincipal, n962ChavePIXTipo, A962ChavePIXTipo, n963ChavePIXConteudo, A963ChavePIXConteudo, n964ChavePIXStatus, A964ChavePIXStatus, n951ContaBancariaId, A951ContaBancariaId, n957ChavePIXCreatedBy, A957ChavePIXCreatedBy, n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy, A961ChavePIXId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("ChavePIX");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ChavePIX"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Z103( ) ;
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
            EndLevel2Z103( ) ;
         }
         CloseExtendedTableCursors2Z103( ) ;
      }

      protected void DeferredUpdate2Z103( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Z103( ) ;
            AfterConfirm2Z103( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Z103( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Z26 */
                  pr_default.execute(21, new Object[] {A961ChavePIXId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("ChavePIX");
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
         sMode103 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Z103( ) ;
         Gx_mode = sMode103;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Z103( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002Z27 */
            pr_default.execute(22, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            A938AgenciaId = T002Z27_A938AgenciaId[0];
            n938AgenciaId = T002Z27_n938AgenciaId[0];
            A952ContaBancariaNumero = T002Z27_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T002Z27_n952ContaBancariaNumero[0];
            AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
            pr_default.close(22);
            /* Using cursor T002Z28 */
            pr_default.execute(23, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = T002Z28_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T002Z28_n968AgenciaBancoId[0];
            A939AgenciaNumero = T002Z28_A939AgenciaNumero[0];
            n939AgenciaNumero = T002Z28_n939AgenciaNumero[0];
            AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
            pr_default.close(23);
            /* Using cursor T002Z29 */
            pr_default.execute(24, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T002Z29_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T002Z29_n969AgenciaBancoNome[0];
            AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
            pr_default.close(24);
            /* Using cursor T002Z31 */
            pr_default.execute(25, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               A970ContaBancariaCountChavePIX_F = T002Z31_A970ContaBancariaCountChavePIX_F[0];
               n970ContaBancariaCountChavePIX_F = T002Z31_n970ContaBancariaCountChavePIX_F[0];
            }
            else
            {
               A970ContaBancariaCountChavePIX_F = 0;
               n970ContaBancariaCountChavePIX_F = false;
               AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
            }
            pr_default.close(25);
            /* Using cursor T002Z32 */
            pr_default.execute(26, new Object[] {n957ChavePIXCreatedBy, A957ChavePIXCreatedBy});
            A958ChavePIXCreatedByName = T002Z32_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = T002Z32_n958ChavePIXCreatedByName[0];
            pr_default.close(26);
            /* Using cursor T002Z33 */
            pr_default.execute(27, new Object[] {n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
            A960ChavePIXUpdatedByName = T002Z33_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = T002Z33_n960ChavePIXUpdatedByName[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel2Z103( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("chavepix",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("chavepix",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Z103( )
      {
         /* Scan By routine */
         /* Using cursor T002Z34 */
         pr_default.execute(28);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound103 = 1;
            A961ChavePIXId = T002Z34_A961ChavePIXId[0];
            AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Z103( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound103 = 1;
            A961ChavePIXId = T002Z34_A961ChavePIXId[0];
            AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
         }
      }

      protected void ScanEnd2Z103( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm2Z103( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Z103( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Z103( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Z103( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Z103( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Z103( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Z103( )
      {
         edtAgenciaBancoNome_Enabled = 0;
         AssignProp("", false, edtAgenciaBancoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaBancoNome_Enabled), 5, 0), true);
         edtAgenciaNumero_Enabled = 0;
         AssignProp("", false, edtAgenciaNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgenciaNumero_Enabled), 5, 0), true);
         edtContaBancariaNumero_Enabled = 0;
         AssignProp("", false, edtContaBancariaNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaNumero_Enabled), 5, 0), true);
         cmbChavePIXTipo.Enabled = 0;
         AssignProp("", false, cmbChavePIXTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXTipo.Enabled), 5, 0), true);
         edtChavePIXConteudo_Enabled = 0;
         AssignProp("", false, edtChavePIXConteudo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChavePIXConteudo_Enabled), 5, 0), true);
         cmbChavePIXStatus.Enabled = 0;
         AssignProp("", false, cmbChavePIXStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXStatus.Enabled), 5, 0), true);
         cmbChavePIXPrincipal.Enabled = 0;
         AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChavePIXPrincipal.Enabled), 5, 0), true);
         edtChavePIXId_Enabled = 0;
         AssignProp("", false, edtChavePIXId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChavePIXId_Enabled), 5, 0), true);
         edtContaBancariaId_Enabled = 0;
         AssignProp("", false, edtContaBancariaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaBancariaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Z103( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Z0( )
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
         GXEncryptionTmp = "chavepix"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ChavePIXId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15ContaBancariaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("chavepix") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ChavePIX");
         forbiddenHiddens.Add("ChavePIXId", context.localUtil.Format( (decimal)(A961ChavePIXId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContaBancariaId", context.localUtil.Format( (decimal)(AV11Insert_ContaBancariaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ChavePIXCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ChavePIXCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_ChavePIXUpdatedBy", context.localUtil.Format( (decimal)(AV13Insert_ChavePIXUpdatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ChavePIXCreatedAt", context.localUtil.Format( A966ChavePIXCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("ChavePIXUpdatedAt", context.localUtil.Format( A967ChavePIXUpdatedAt, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("chavepix:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z961ChavePIXId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z961ChavePIXId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z966ChavePIXCreatedAt", context.localUtil.TToC( Z966ChavePIXCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z967ChavePIXUpdatedAt", context.localUtil.TToC( Z967ChavePIXUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z965ChavePIXPrincipal", Z965ChavePIXPrincipal);
         GxWebStd.gx_hidden_field( context, "Z962ChavePIXTipo", Z962ChavePIXTipo);
         GxWebStd.gx_hidden_field( context, "Z963ChavePIXConteudo", Z963ChavePIXConteudo);
         GxWebStd.gx_boolean_hidden_field( context, "Z964ChavePIXStatus", Z964ChavePIXStatus);
         GxWebStd.gx_hidden_field( context, "Z951ContaBancariaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z951ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z957ChavePIXCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z957ChavePIXCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z959ChavePIXUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z959ChavePIXUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N951ContaBancariaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N957ChavePIXCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N959ChavePIXUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCHAVEPIXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ChavePIXId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCHAVEPIXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ChavePIXId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTABANCARIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15ContaBancariaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CHAVEPIXCREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ChavePIXCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CHAVEPIXCREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CHAVEPIXUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ChavePIXUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CHAVEPIXUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CHAVEPIXCREATEDAT", context.localUtil.TToC( A966ChavePIXCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CHAVEPIXUPDATEDAT", context.localUtil.TToC( A967ChavePIXUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIACOUNTCHAVEPIX_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CHAVEPIXCREATEDBYNAME", A958ChavePIXCreatedByName);
         GxWebStd.gx_hidden_field( context, "CHAVEPIXUPDATEDBYNAME", A960ChavePIXUpdatedByName);
         GxWebStd.gx_hidden_field( context, "AGENCIABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
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
         GXEncryptionTmp = "chavepix"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ChavePIXId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15ContaBancariaId,9,0));
         return formatLink("chavepix") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ChavePIX" ;
      }

      public override string GetPgmdesc( )
      {
         return "Chave PIX" ;
      }

      protected void InitializeNonKey2Z103( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrimStr( (decimal)(A968AgenciaBancoId), 9, 0));
         A938AgenciaId = 0;
         n938AgenciaId = false;
         AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
         A951ContaBancariaId = 0;
         n951ContaBancariaId = false;
         AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
         n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
         A957ChavePIXCreatedBy = 0;
         n957ChavePIXCreatedBy = false;
         AssignAttri("", false, "A957ChavePIXCreatedBy", ((0==A957ChavePIXCreatedBy)&&IsIns( )||n957ChavePIXCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ".", ""))));
         A959ChavePIXUpdatedBy = 0;
         n959ChavePIXUpdatedBy = false;
         AssignAttri("", false, "A959ChavePIXUpdatedBy", ((0==A959ChavePIXUpdatedBy)&&IsIns( )||n959ChavePIXUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A959ChavePIXUpdatedBy), 4, 0, ".", ""))));
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         n966ChavePIXCreatedAt = false;
         AssignAttri("", false, "A966ChavePIXCreatedAt", context.localUtil.TToC( A966ChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         n967ChavePIXUpdatedAt = false;
         AssignAttri("", false, "A967ChavePIXUpdatedAt", context.localUtil.TToC( A967ChavePIXUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A965ChavePIXPrincipal = false;
         n965ChavePIXPrincipal = false;
         AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
         n965ChavePIXPrincipal = ((false==A965ChavePIXPrincipal) ? true : false);
         A970ContaBancariaCountChavePIX_F = 0;
         n970ContaBancariaCountChavePIX_F = false;
         AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrimStr( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0));
         A962ChavePIXTipo = "";
         n962ChavePIXTipo = false;
         AssignAttri("", false, "A962ChavePIXTipo", A962ChavePIXTipo);
         n962ChavePIXTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A962ChavePIXTipo)) ? true : false);
         A963ChavePIXConteudo = "";
         n963ChavePIXConteudo = false;
         AssignAttri("", false, "A963ChavePIXConteudo", A963ChavePIXConteudo);
         n963ChavePIXConteudo = (String.IsNullOrEmpty(StringUtil.RTrim( A963ChavePIXConteudo)) ? true : false);
         A952ContaBancariaNumero = 0;
         n952ContaBancariaNumero = false;
         AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A958ChavePIXCreatedByName = "";
         n958ChavePIXCreatedByName = false;
         AssignAttri("", false, "A958ChavePIXCreatedByName", A958ChavePIXCreatedByName);
         A960ChavePIXUpdatedByName = "";
         n960ChavePIXUpdatedByName = false;
         AssignAttri("", false, "A960ChavePIXUpdatedByName", A960ChavePIXUpdatedByName);
         A964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
         Z966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         Z967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         Z965ChavePIXPrincipal = false;
         Z962ChavePIXTipo = "";
         Z963ChavePIXConteudo = "";
         Z964ChavePIXStatus = false;
         Z951ContaBancariaId = 0;
         Z957ChavePIXCreatedBy = 0;
         Z959ChavePIXUpdatedBy = 0;
      }

      protected void InitAll2Z103( )
      {
         A961ChavePIXId = 0;
         AssignAttri("", false, "A961ChavePIXId", StringUtil.LTrimStr( (decimal)(A961ChavePIXId), 9, 0));
         InitializeNonKey2Z103( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A966ChavePIXCreatedAt = i966ChavePIXCreatedAt;
         n966ChavePIXCreatedAt = false;
         AssignAttri("", false, "A966ChavePIXCreatedAt", context.localUtil.TToC( A966ChavePIXCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A957ChavePIXCreatedBy = i957ChavePIXCreatedBy;
         n957ChavePIXCreatedBy = false;
         AssignAttri("", false, "A957ChavePIXCreatedBy", ((0==A957ChavePIXCreatedBy)&&IsIns( )||n957ChavePIXCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A957ChavePIXCreatedBy), 4, 0, ".", ""))));
         A964ChavePIXStatus = i964ChavePIXStatus;
         n964ChavePIXStatus = false;
         AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019215863", true, true);
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
         context.AddJavascriptSource("chavepix.js", "?202561019215864", false, true);
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
         cmbChavePIXTipo_Internalname = "CHAVEPIXTIPO";
         edtChavePIXConteudo_Internalname = "CHAVEPIXCONTEUDO";
         cmbChavePIXStatus_Internalname = "CHAVEPIXSTATUS";
         cmbChavePIXPrincipal_Internalname = "CHAVEPIXPRINCIPAL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtChavePIXId_Internalname = "CHAVEPIXID";
         edtContaBancariaId_Internalname = "CONTABANCARIAID";
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
         Form.Caption = "Chave PIX";
         edtContaBancariaId_Jsonclick = "";
         edtContaBancariaId_Enabled = 1;
         edtContaBancariaId_Visible = 1;
         edtChavePIXId_Jsonclick = "";
         edtChavePIXId_Enabled = 0;
         edtChavePIXId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbChavePIXPrincipal_Jsonclick = "";
         cmbChavePIXPrincipal.Enabled = 0;
         cmbChavePIXStatus_Jsonclick = "";
         cmbChavePIXStatus.Enabled = 1;
         edtChavePIXConteudo_Jsonclick = "";
         edtChavePIXConteudo_Enabled = 1;
         cmbChavePIXTipo_Jsonclick = "";
         cmbChavePIXTipo.Enabled = 1;
         edtContaBancariaNumero_Jsonclick = "";
         edtContaBancariaNumero_Enabled = 0;
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
         cmbChavePIXTipo.Name = "CHAVEPIXTIPO";
         cmbChavePIXTipo.WebTags = "";
         cmbChavePIXTipo.addItem("CPF", "CPF", 0);
         cmbChavePIXTipo.addItem("CNPJ", "CNPJ", 0);
         cmbChavePIXTipo.addItem("Telefone", "Telefone", 0);
         cmbChavePIXTipo.addItem("Email", "E-mail", 0);
         cmbChavePIXTipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbChavePIXTipo.ItemCount > 0 )
         {
            A962ChavePIXTipo = cmbChavePIXTipo.getValidValue(A962ChavePIXTipo);
            n962ChavePIXTipo = false;
            AssignAttri("", false, "A962ChavePIXTipo", A962ChavePIXTipo);
         }
         cmbChavePIXStatus.Name = "CHAVEPIXSTATUS";
         cmbChavePIXStatus.WebTags = "";
         cmbChavePIXStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbChavePIXStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbChavePIXStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A964ChavePIXStatus) )
            {
               A964ChavePIXStatus = true;
               n964ChavePIXStatus = false;
               AssignAttri("", false, "A964ChavePIXStatus", A964ChavePIXStatus);
            }
         }
         cmbChavePIXPrincipal.Name = "CHAVEPIXPRINCIPAL";
         cmbChavePIXPrincipal.WebTags = "";
         cmbChavePIXPrincipal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbChavePIXPrincipal.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbChavePIXPrincipal.ItemCount > 0 )
         {
            A965ChavePIXPrincipal = StringUtil.StrToBool( cmbChavePIXPrincipal.getValidValue(StringUtil.BoolToStr( A965ChavePIXPrincipal)));
            n965ChavePIXPrincipal = false;
            AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
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
         n938AgenciaId = false;
         n968AgenciaBancoId = false;
         n970ContaBancariaCountChavePIX_F = false;
         n964ChavePIXStatus = false;
         A964ChavePIXStatus = StringUtil.StrToBool( cmbChavePIXStatus.CurrentValue);
         n964ChavePIXStatus = false;
         n952ContaBancariaNumero = false;
         n939AgenciaNumero = false;
         n969AgenciaBancoNome = false;
         n965ChavePIXPrincipal = false;
         A965ChavePIXPrincipal = StringUtil.StrToBool( cmbChavePIXPrincipal.CurrentValue);
         n965ChavePIXPrincipal = false;
         cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
         /* Using cursor T002Z27 */
         pr_default.execute(22, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
               GX_FocusControl = edtContaBancariaId_Internalname;
            }
         }
         A938AgenciaId = T002Z27_A938AgenciaId[0];
         n938AgenciaId = T002Z27_n938AgenciaId[0];
         A952ContaBancariaNumero = T002Z27_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = T002Z27_n952ContaBancariaNumero[0];
         pr_default.close(22);
         /* Using cursor T002Z28 */
         pr_default.execute(23, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = T002Z28_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T002Z28_n968AgenciaBancoId[0];
         A939AgenciaNumero = T002Z28_A939AgenciaNumero[0];
         n939AgenciaNumero = T002Z28_n939AgenciaNumero[0];
         pr_default.close(23);
         /* Using cursor T002Z29 */
         pr_default.execute(24, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T002Z29_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T002Z29_n969AgenciaBancoNome[0];
         pr_default.close(24);
         /* Using cursor T002Z31 */
         pr_default.execute(25, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = T002Z31_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = T002Z31_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
         }
         pr_default.close(25);
         if ( ( A970ContaBancariaCountChavePIX_F == 0 ) && IsIns( )  )
         {
            A965ChavePIXPrincipal = true;
            n965ChavePIXPrincipal = false;
            cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
         }
         else
         {
            if ( ( A970ContaBancariaCountChavePIX_F == 0 ) && IsIns( )  )
            {
               A965ChavePIXPrincipal = false;
               n965ChavePIXPrincipal = false;
               cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
            }
            else
            {
               if ( ! A964ChavePIXStatus && IsUpd( )  )
               {
                  A965ChavePIXPrincipal = false;
                  n965ChavePIXPrincipal = false;
                  cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
               }
            }
         }
         dynload_actions( ) ;
         if ( cmbChavePIXPrincipal.ItemCount > 0 )
         {
            A965ChavePIXPrincipal = StringUtil.StrToBool( cmbChavePIXPrincipal.getValidValue(StringUtil.BoolToStr( A965ChavePIXPrincipal)));
            n965ChavePIXPrincipal = false;
            cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A938AgenciaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", "")));
         AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", "")));
         AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", "")));
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", "")));
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         AssignAttri("", false, "A970ContaBancariaCountChavePIX_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A970ContaBancariaCountChavePIX_F), 4, 0, ".", "")));
         AssignAttri("", false, "A965ChavePIXPrincipal", A965ChavePIXPrincipal);
         cmbChavePIXPrincipal.CurrentValue = StringUtil.BoolToStr( A965ChavePIXPrincipal);
         AssignProp("", false, cmbChavePIXPrincipal_Internalname, "Values", cmbChavePIXPrincipal.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ChavePIXId","fld":"vCHAVEPIXID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV15ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ChavePIXId","fld":"vCHAVEPIXID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV15ContaBancariaId","fld":"vCONTABANCARIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A961ChavePIXId","fld":"CHAVEPIXID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ContaBancariaId","fld":"vINSERT_CONTABANCARIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_ChavePIXCreatedBy","fld":"vINSERT_CHAVEPIXCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV13Insert_ChavePIXUpdatedBy","fld":"vINSERT_CHAVEPIXUPDATEDBY","pic":"ZZZ9","type":"int"},{"av":"A966ChavePIXCreatedAt","fld":"CHAVEPIXCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A967ChavePIXUpdatedAt","fld":"CHAVEPIXUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122Z2","iparms":[]}""");
         setEventMetadata("VALID_CHAVEPIXTIPO","""{"handler":"Valid_Chavepixtipo","iparms":[]}""");
         setEventMetadata("VALID_CHAVEPIXSTATUS","""{"handler":"Valid_Chavepixstatus","iparms":[]}""");
         setEventMetadata("VALID_CHAVEPIXID","""{"handler":"Valid_Chavepixid","iparms":[]}""");
         setEventMetadata("VALID_CONTABANCARIAID","""{"handler":"Valid_Contabancariaid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"A951ContaBancariaId","fld":"CONTABANCARIAID","pic":"ZZZZZZZZ9","nullAv":"n951ContaBancariaId","type":"int"},{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A968AgenciaBancoId","fld":"AGENCIABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A970ContaBancariaCountChavePIX_F","fld":"CONTABANCARIACOUNTCHAVEPIX_F","pic":"ZZZ9","type":"int"},{"av":"cmbChavePIXStatus"},{"av":"A964ChavePIXStatus","fld":"CHAVEPIXSTATUS","type":"boolean"},{"av":"A952ContaBancariaNumero","fld":"CONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A939AgenciaNumero","fld":"AGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A969AgenciaBancoNome","fld":"AGENCIABANCONOME","type":"svchar"},{"av":"cmbChavePIXPrincipal"},{"av":"A965ChavePIXPrincipal","fld":"CHAVEPIXPRINCIPAL","type":"boolean"}]""");
         setEventMetadata("VALID_CONTABANCARIAID",""","oparms":[{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A952ContaBancariaNumero","fld":"CONTABANCARIANUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A968AgenciaBancoId","fld":"AGENCIABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A939AgenciaNumero","fld":"AGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A969AgenciaBancoNome","fld":"AGENCIABANCONOME","type":"svchar"},{"av":"A970ContaBancariaCountChavePIX_F","fld":"CONTABANCARIACOUNTCHAVEPIX_F","pic":"ZZZ9","type":"int"},{"av":"cmbChavePIXPrincipal"},{"av":"A965ChavePIXPrincipal","fld":"CHAVEPIXPRINCIPAL","type":"boolean"}]}""");
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
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         Z967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         Z962ChavePIXTipo = "";
         Z963ChavePIXConteudo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A962ChavePIXTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A969AgenciaBancoNome = "";
         A963ChavePIXConteudo = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         A958ChavePIXCreatedByName = "";
         A960ChavePIXUpdatedByName = "";
         AV17Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode103 = "";
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
         Z958ChavePIXCreatedByName = "";
         Z960ChavePIXUpdatedByName = "";
         Z969AgenciaBancoNome = "";
         T002Z5_A958ChavePIXCreatedByName = new string[] {""} ;
         T002Z5_n958ChavePIXCreatedByName = new bool[] {false} ;
         T002Z6_A960ChavePIXUpdatedByName = new string[] {""} ;
         T002Z6_n960ChavePIXUpdatedByName = new bool[] {false} ;
         T002Z4_A938AgenciaId = new int[1] ;
         T002Z4_n938AgenciaId = new bool[] {false} ;
         T002Z4_A952ContaBancariaNumero = new long[1] ;
         T002Z4_n952ContaBancariaNumero = new bool[] {false} ;
         T002Z7_A968AgenciaBancoId = new int[1] ;
         T002Z7_n968AgenciaBancoId = new bool[] {false} ;
         T002Z7_A939AgenciaNumero = new int[1] ;
         T002Z7_n939AgenciaNumero = new bool[] {false} ;
         T002Z8_A969AgenciaBancoNome = new string[] {""} ;
         T002Z8_n969AgenciaBancoNome = new bool[] {false} ;
         T002Z10_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Z10_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Z12_A938AgenciaId = new int[1] ;
         T002Z12_n938AgenciaId = new bool[] {false} ;
         T002Z12_A968AgenciaBancoId = new int[1] ;
         T002Z12_n968AgenciaBancoId = new bool[] {false} ;
         T002Z12_A961ChavePIXId = new int[1] ;
         T002Z12_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Z12_n966ChavePIXCreatedAt = new bool[] {false} ;
         T002Z12_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Z12_n967ChavePIXUpdatedAt = new bool[] {false} ;
         T002Z12_A965ChavePIXPrincipal = new bool[] {false} ;
         T002Z12_n965ChavePIXPrincipal = new bool[] {false} ;
         T002Z12_A962ChavePIXTipo = new string[] {""} ;
         T002Z12_n962ChavePIXTipo = new bool[] {false} ;
         T002Z12_A963ChavePIXConteudo = new string[] {""} ;
         T002Z12_n963ChavePIXConteudo = new bool[] {false} ;
         T002Z12_A964ChavePIXStatus = new bool[] {false} ;
         T002Z12_n964ChavePIXStatus = new bool[] {false} ;
         T002Z12_A952ContaBancariaNumero = new long[1] ;
         T002Z12_n952ContaBancariaNumero = new bool[] {false} ;
         T002Z12_A939AgenciaNumero = new int[1] ;
         T002Z12_n939AgenciaNumero = new bool[] {false} ;
         T002Z12_A969AgenciaBancoNome = new string[] {""} ;
         T002Z12_n969AgenciaBancoNome = new bool[] {false} ;
         T002Z12_A958ChavePIXCreatedByName = new string[] {""} ;
         T002Z12_n958ChavePIXCreatedByName = new bool[] {false} ;
         T002Z12_A960ChavePIXUpdatedByName = new string[] {""} ;
         T002Z12_n960ChavePIXUpdatedByName = new bool[] {false} ;
         T002Z12_A951ContaBancariaId = new int[1] ;
         T002Z12_n951ContaBancariaId = new bool[] {false} ;
         T002Z12_A957ChavePIXCreatedBy = new short[1] ;
         T002Z12_n957ChavePIXCreatedBy = new bool[] {false} ;
         T002Z12_A959ChavePIXUpdatedBy = new short[1] ;
         T002Z12_n959ChavePIXUpdatedBy = new bool[] {false} ;
         T002Z12_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Z12_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Z13_A938AgenciaId = new int[1] ;
         T002Z13_n938AgenciaId = new bool[] {false} ;
         T002Z13_A952ContaBancariaNumero = new long[1] ;
         T002Z13_n952ContaBancariaNumero = new bool[] {false} ;
         T002Z14_A968AgenciaBancoId = new int[1] ;
         T002Z14_n968AgenciaBancoId = new bool[] {false} ;
         T002Z14_A939AgenciaNumero = new int[1] ;
         T002Z14_n939AgenciaNumero = new bool[] {false} ;
         T002Z15_A969AgenciaBancoNome = new string[] {""} ;
         T002Z15_n969AgenciaBancoNome = new bool[] {false} ;
         T002Z17_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Z17_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Z18_A958ChavePIXCreatedByName = new string[] {""} ;
         T002Z18_n958ChavePIXCreatedByName = new bool[] {false} ;
         T002Z19_A960ChavePIXUpdatedByName = new string[] {""} ;
         T002Z19_n960ChavePIXUpdatedByName = new bool[] {false} ;
         T002Z20_A961ChavePIXId = new int[1] ;
         T002Z3_A961ChavePIXId = new int[1] ;
         T002Z3_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Z3_n966ChavePIXCreatedAt = new bool[] {false} ;
         T002Z3_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Z3_n967ChavePIXUpdatedAt = new bool[] {false} ;
         T002Z3_A965ChavePIXPrincipal = new bool[] {false} ;
         T002Z3_n965ChavePIXPrincipal = new bool[] {false} ;
         T002Z3_A962ChavePIXTipo = new string[] {""} ;
         T002Z3_n962ChavePIXTipo = new bool[] {false} ;
         T002Z3_A963ChavePIXConteudo = new string[] {""} ;
         T002Z3_n963ChavePIXConteudo = new bool[] {false} ;
         T002Z3_A964ChavePIXStatus = new bool[] {false} ;
         T002Z3_n964ChavePIXStatus = new bool[] {false} ;
         T002Z3_A951ContaBancariaId = new int[1] ;
         T002Z3_n951ContaBancariaId = new bool[] {false} ;
         T002Z3_A957ChavePIXCreatedBy = new short[1] ;
         T002Z3_n957ChavePIXCreatedBy = new bool[] {false} ;
         T002Z3_A959ChavePIXUpdatedBy = new short[1] ;
         T002Z3_n959ChavePIXUpdatedBy = new bool[] {false} ;
         T002Z21_A961ChavePIXId = new int[1] ;
         T002Z22_A961ChavePIXId = new int[1] ;
         T002Z2_A961ChavePIXId = new int[1] ;
         T002Z2_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Z2_n966ChavePIXCreatedAt = new bool[] {false} ;
         T002Z2_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Z2_n967ChavePIXUpdatedAt = new bool[] {false} ;
         T002Z2_A965ChavePIXPrincipal = new bool[] {false} ;
         T002Z2_n965ChavePIXPrincipal = new bool[] {false} ;
         T002Z2_A962ChavePIXTipo = new string[] {""} ;
         T002Z2_n962ChavePIXTipo = new bool[] {false} ;
         T002Z2_A963ChavePIXConteudo = new string[] {""} ;
         T002Z2_n963ChavePIXConteudo = new bool[] {false} ;
         T002Z2_A964ChavePIXStatus = new bool[] {false} ;
         T002Z2_n964ChavePIXStatus = new bool[] {false} ;
         T002Z2_A951ContaBancariaId = new int[1] ;
         T002Z2_n951ContaBancariaId = new bool[] {false} ;
         T002Z2_A957ChavePIXCreatedBy = new short[1] ;
         T002Z2_n957ChavePIXCreatedBy = new bool[] {false} ;
         T002Z2_A959ChavePIXUpdatedBy = new short[1] ;
         T002Z2_n959ChavePIXUpdatedBy = new bool[] {false} ;
         T002Z24_A961ChavePIXId = new int[1] ;
         T002Z27_A938AgenciaId = new int[1] ;
         T002Z27_n938AgenciaId = new bool[] {false} ;
         T002Z27_A952ContaBancariaNumero = new long[1] ;
         T002Z27_n952ContaBancariaNumero = new bool[] {false} ;
         T002Z28_A968AgenciaBancoId = new int[1] ;
         T002Z28_n968AgenciaBancoId = new bool[] {false} ;
         T002Z28_A939AgenciaNumero = new int[1] ;
         T002Z28_n939AgenciaNumero = new bool[] {false} ;
         T002Z29_A969AgenciaBancoNome = new string[] {""} ;
         T002Z29_n969AgenciaBancoNome = new bool[] {false} ;
         T002Z31_A970ContaBancariaCountChavePIX_F = new short[1] ;
         T002Z31_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         T002Z32_A958ChavePIXCreatedByName = new string[] {""} ;
         T002Z32_n958ChavePIXCreatedByName = new bool[] {false} ;
         T002Z33_A960ChavePIXUpdatedByName = new string[] {""} ;
         T002Z33_n960ChavePIXUpdatedByName = new bool[] {false} ;
         T002Z34_A961ChavePIXId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.chavepix__default(),
            new Object[][] {
                new Object[] {
               T002Z2_A961ChavePIXId, T002Z2_A966ChavePIXCreatedAt, T002Z2_n966ChavePIXCreatedAt, T002Z2_A967ChavePIXUpdatedAt, T002Z2_n967ChavePIXUpdatedAt, T002Z2_A965ChavePIXPrincipal, T002Z2_n965ChavePIXPrincipal, T002Z2_A962ChavePIXTipo, T002Z2_n962ChavePIXTipo, T002Z2_A963ChavePIXConteudo,
               T002Z2_n963ChavePIXConteudo, T002Z2_A964ChavePIXStatus, T002Z2_n964ChavePIXStatus, T002Z2_A951ContaBancariaId, T002Z2_n951ContaBancariaId, T002Z2_A957ChavePIXCreatedBy, T002Z2_n957ChavePIXCreatedBy, T002Z2_A959ChavePIXUpdatedBy, T002Z2_n959ChavePIXUpdatedBy
               }
               , new Object[] {
               T002Z3_A961ChavePIXId, T002Z3_A966ChavePIXCreatedAt, T002Z3_n966ChavePIXCreatedAt, T002Z3_A967ChavePIXUpdatedAt, T002Z3_n967ChavePIXUpdatedAt, T002Z3_A965ChavePIXPrincipal, T002Z3_n965ChavePIXPrincipal, T002Z3_A962ChavePIXTipo, T002Z3_n962ChavePIXTipo, T002Z3_A963ChavePIXConteudo,
               T002Z3_n963ChavePIXConteudo, T002Z3_A964ChavePIXStatus, T002Z3_n964ChavePIXStatus, T002Z3_A951ContaBancariaId, T002Z3_n951ContaBancariaId, T002Z3_A957ChavePIXCreatedBy, T002Z3_n957ChavePIXCreatedBy, T002Z3_A959ChavePIXUpdatedBy, T002Z3_n959ChavePIXUpdatedBy
               }
               , new Object[] {
               T002Z4_A938AgenciaId, T002Z4_n938AgenciaId, T002Z4_A952ContaBancariaNumero, T002Z4_n952ContaBancariaNumero
               }
               , new Object[] {
               T002Z5_A958ChavePIXCreatedByName, T002Z5_n958ChavePIXCreatedByName
               }
               , new Object[] {
               T002Z6_A960ChavePIXUpdatedByName, T002Z6_n960ChavePIXUpdatedByName
               }
               , new Object[] {
               T002Z7_A968AgenciaBancoId, T002Z7_n968AgenciaBancoId, T002Z7_A939AgenciaNumero, T002Z7_n939AgenciaNumero
               }
               , new Object[] {
               T002Z8_A969AgenciaBancoNome, T002Z8_n969AgenciaBancoNome
               }
               , new Object[] {
               T002Z10_A970ContaBancariaCountChavePIX_F, T002Z10_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Z12_A938AgenciaId, T002Z12_n938AgenciaId, T002Z12_A968AgenciaBancoId, T002Z12_n968AgenciaBancoId, T002Z12_A961ChavePIXId, T002Z12_A966ChavePIXCreatedAt, T002Z12_n966ChavePIXCreatedAt, T002Z12_A967ChavePIXUpdatedAt, T002Z12_n967ChavePIXUpdatedAt, T002Z12_A965ChavePIXPrincipal,
               T002Z12_n965ChavePIXPrincipal, T002Z12_A962ChavePIXTipo, T002Z12_n962ChavePIXTipo, T002Z12_A963ChavePIXConteudo, T002Z12_n963ChavePIXConteudo, T002Z12_A964ChavePIXStatus, T002Z12_n964ChavePIXStatus, T002Z12_A952ContaBancariaNumero, T002Z12_n952ContaBancariaNumero, T002Z12_A939AgenciaNumero,
               T002Z12_n939AgenciaNumero, T002Z12_A969AgenciaBancoNome, T002Z12_n969AgenciaBancoNome, T002Z12_A958ChavePIXCreatedByName, T002Z12_n958ChavePIXCreatedByName, T002Z12_A960ChavePIXUpdatedByName, T002Z12_n960ChavePIXUpdatedByName, T002Z12_A951ContaBancariaId, T002Z12_n951ContaBancariaId, T002Z12_A957ChavePIXCreatedBy,
               T002Z12_n957ChavePIXCreatedBy, T002Z12_A959ChavePIXUpdatedBy, T002Z12_n959ChavePIXUpdatedBy, T002Z12_A970ContaBancariaCountChavePIX_F, T002Z12_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Z13_A938AgenciaId, T002Z13_n938AgenciaId, T002Z13_A952ContaBancariaNumero, T002Z13_n952ContaBancariaNumero
               }
               , new Object[] {
               T002Z14_A968AgenciaBancoId, T002Z14_n968AgenciaBancoId, T002Z14_A939AgenciaNumero, T002Z14_n939AgenciaNumero
               }
               , new Object[] {
               T002Z15_A969AgenciaBancoNome, T002Z15_n969AgenciaBancoNome
               }
               , new Object[] {
               T002Z17_A970ContaBancariaCountChavePIX_F, T002Z17_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Z18_A958ChavePIXCreatedByName, T002Z18_n958ChavePIXCreatedByName
               }
               , new Object[] {
               T002Z19_A960ChavePIXUpdatedByName, T002Z19_n960ChavePIXUpdatedByName
               }
               , new Object[] {
               T002Z20_A961ChavePIXId
               }
               , new Object[] {
               T002Z21_A961ChavePIXId
               }
               , new Object[] {
               T002Z22_A961ChavePIXId
               }
               , new Object[] {
               }
               , new Object[] {
               T002Z24_A961ChavePIXId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Z27_A938AgenciaId, T002Z27_n938AgenciaId, T002Z27_A952ContaBancariaNumero, T002Z27_n952ContaBancariaNumero
               }
               , new Object[] {
               T002Z28_A968AgenciaBancoId, T002Z28_n968AgenciaBancoId, T002Z28_A939AgenciaNumero, T002Z28_n939AgenciaNumero
               }
               , new Object[] {
               T002Z29_A969AgenciaBancoNome, T002Z29_n969AgenciaBancoNome
               }
               , new Object[] {
               T002Z31_A970ContaBancariaCountChavePIX_F, T002Z31_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               T002Z32_A958ChavePIXCreatedByName, T002Z32_n958ChavePIXCreatedByName
               }
               , new Object[] {
               T002Z33_A960ChavePIXUpdatedByName, T002Z33_n960ChavePIXUpdatedByName
               }
               , new Object[] {
               T002Z34_A961ChavePIXId
               }
            }
         );
         AV17Pgmname = "ChavePIX";
         Z964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         A964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         i964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
      }

      private short Z957ChavePIXCreatedBy ;
      private short Z959ChavePIXUpdatedBy ;
      private short N957ChavePIXCreatedBy ;
      private short N959ChavePIXUpdatedBy ;
      private short GxWebError ;
      private short A957ChavePIXCreatedBy ;
      private short A959ChavePIXUpdatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV12Insert_ChavePIXCreatedBy ;
      private short AV13Insert_ChavePIXUpdatedBy ;
      private short A970ContaBancariaCountChavePIX_F ;
      private short Gx_BScreen ;
      private short RcdFound103 ;
      private short Z970ContaBancariaCountChavePIX_F ;
      private short gxajaxcallmode ;
      private short i957ChavePIXCreatedBy ;
      private int wcpOAV7ChavePIXId ;
      private int wcpOAV15ContaBancariaId ;
      private int Z961ChavePIXId ;
      private int Z951ContaBancariaId ;
      private int N951ContaBancariaId ;
      private int A951ContaBancariaId ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int AV7ChavePIXId ;
      private int AV15ContaBancariaId ;
      private int trnEnded ;
      private int edtAgenciaBancoNome_Enabled ;
      private int A939AgenciaNumero ;
      private int edtAgenciaNumero_Enabled ;
      private int edtContaBancariaNumero_Enabled ;
      private int edtChavePIXConteudo_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A961ChavePIXId ;
      private int edtChavePIXId_Enabled ;
      private int edtChavePIXId_Visible ;
      private int edtContaBancariaId_Visible ;
      private int edtContaBancariaId_Enabled ;
      private int AV11Insert_ContaBancariaId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV18GXV1 ;
      private int Z938AgenciaId ;
      private int Z968AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int idxLst ;
      private long A952ContaBancariaNumero ;
      private long Z952ContaBancariaNumero ;
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
      private string cmbChavePIXTipo_Internalname ;
      private string cmbChavePIXStatus_Internalname ;
      private string cmbChavePIXPrincipal_Internalname ;
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
      private string edtContaBancariaNumero_Internalname ;
      private string edtContaBancariaNumero_Jsonclick ;
      private string cmbChavePIXTipo_Jsonclick ;
      private string edtChavePIXConteudo_Internalname ;
      private string edtChavePIXConteudo_Jsonclick ;
      private string cmbChavePIXStatus_Jsonclick ;
      private string cmbChavePIXPrincipal_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtChavePIXId_Internalname ;
      private string edtChavePIXId_Jsonclick ;
      private string edtContaBancariaId_Internalname ;
      private string edtContaBancariaId_Jsonclick ;
      private string AV17Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode103 ;
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
      private DateTime Z966ChavePIXCreatedAt ;
      private DateTime Z967ChavePIXUpdatedAt ;
      private DateTime A966ChavePIXCreatedAt ;
      private DateTime A967ChavePIXUpdatedAt ;
      private DateTime i966ChavePIXCreatedAt ;
      private bool Z965ChavePIXPrincipal ;
      private bool Z964ChavePIXStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n951ContaBancariaId ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n957ChavePIXCreatedBy ;
      private bool n959ChavePIXUpdatedBy ;
      private bool wbErr ;
      private bool n962ChavePIXTipo ;
      private bool A964ChavePIXStatus ;
      private bool n964ChavePIXStatus ;
      private bool A965ChavePIXPrincipal ;
      private bool n965ChavePIXPrincipal ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n966ChavePIXCreatedAt ;
      private bool n967ChavePIXUpdatedAt ;
      private bool n963ChavePIXConteudo ;
      private bool n970ContaBancariaCountChavePIX_F ;
      private bool n958ChavePIXCreatedByName ;
      private bool n960ChavePIXUpdatedByName ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n969AgenciaBancoNome ;
      private bool n939AgenciaNumero ;
      private bool n952ContaBancariaNumero ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i964ChavePIXStatus ;
      private string Z962ChavePIXTipo ;
      private string Z963ChavePIXConteudo ;
      private string A962ChavePIXTipo ;
      private string A969AgenciaBancoNome ;
      private string A963ChavePIXConteudo ;
      private string A958ChavePIXCreatedByName ;
      private string A960ChavePIXUpdatedByName ;
      private string Z958ChavePIXCreatedByName ;
      private string Z960ChavePIXUpdatedByName ;
      private string Z969AgenciaBancoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbChavePIXTipo ;
      private GXCombobox cmbChavePIXStatus ;
      private GXCombobox cmbChavePIXPrincipal ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002Z5_A958ChavePIXCreatedByName ;
      private bool[] T002Z5_n958ChavePIXCreatedByName ;
      private string[] T002Z6_A960ChavePIXUpdatedByName ;
      private bool[] T002Z6_n960ChavePIXUpdatedByName ;
      private int[] T002Z4_A938AgenciaId ;
      private bool[] T002Z4_n938AgenciaId ;
      private long[] T002Z4_A952ContaBancariaNumero ;
      private bool[] T002Z4_n952ContaBancariaNumero ;
      private int[] T002Z7_A968AgenciaBancoId ;
      private bool[] T002Z7_n968AgenciaBancoId ;
      private int[] T002Z7_A939AgenciaNumero ;
      private bool[] T002Z7_n939AgenciaNumero ;
      private string[] T002Z8_A969AgenciaBancoNome ;
      private bool[] T002Z8_n969AgenciaBancoNome ;
      private short[] T002Z10_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Z10_n970ContaBancariaCountChavePIX_F ;
      private int[] T002Z12_A938AgenciaId ;
      private bool[] T002Z12_n938AgenciaId ;
      private int[] T002Z12_A968AgenciaBancoId ;
      private bool[] T002Z12_n968AgenciaBancoId ;
      private int[] T002Z12_A961ChavePIXId ;
      private DateTime[] T002Z12_A966ChavePIXCreatedAt ;
      private bool[] T002Z12_n966ChavePIXCreatedAt ;
      private DateTime[] T002Z12_A967ChavePIXUpdatedAt ;
      private bool[] T002Z12_n967ChavePIXUpdatedAt ;
      private bool[] T002Z12_A965ChavePIXPrincipal ;
      private bool[] T002Z12_n965ChavePIXPrincipal ;
      private string[] T002Z12_A962ChavePIXTipo ;
      private bool[] T002Z12_n962ChavePIXTipo ;
      private string[] T002Z12_A963ChavePIXConteudo ;
      private bool[] T002Z12_n963ChavePIXConteudo ;
      private bool[] T002Z12_A964ChavePIXStatus ;
      private bool[] T002Z12_n964ChavePIXStatus ;
      private long[] T002Z12_A952ContaBancariaNumero ;
      private bool[] T002Z12_n952ContaBancariaNumero ;
      private int[] T002Z12_A939AgenciaNumero ;
      private bool[] T002Z12_n939AgenciaNumero ;
      private string[] T002Z12_A969AgenciaBancoNome ;
      private bool[] T002Z12_n969AgenciaBancoNome ;
      private string[] T002Z12_A958ChavePIXCreatedByName ;
      private bool[] T002Z12_n958ChavePIXCreatedByName ;
      private string[] T002Z12_A960ChavePIXUpdatedByName ;
      private bool[] T002Z12_n960ChavePIXUpdatedByName ;
      private int[] T002Z12_A951ContaBancariaId ;
      private bool[] T002Z12_n951ContaBancariaId ;
      private short[] T002Z12_A957ChavePIXCreatedBy ;
      private bool[] T002Z12_n957ChavePIXCreatedBy ;
      private short[] T002Z12_A959ChavePIXUpdatedBy ;
      private bool[] T002Z12_n959ChavePIXUpdatedBy ;
      private short[] T002Z12_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Z12_n970ContaBancariaCountChavePIX_F ;
      private int[] T002Z13_A938AgenciaId ;
      private bool[] T002Z13_n938AgenciaId ;
      private long[] T002Z13_A952ContaBancariaNumero ;
      private bool[] T002Z13_n952ContaBancariaNumero ;
      private int[] T002Z14_A968AgenciaBancoId ;
      private bool[] T002Z14_n968AgenciaBancoId ;
      private int[] T002Z14_A939AgenciaNumero ;
      private bool[] T002Z14_n939AgenciaNumero ;
      private string[] T002Z15_A969AgenciaBancoNome ;
      private bool[] T002Z15_n969AgenciaBancoNome ;
      private short[] T002Z17_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Z17_n970ContaBancariaCountChavePIX_F ;
      private string[] T002Z18_A958ChavePIXCreatedByName ;
      private bool[] T002Z18_n958ChavePIXCreatedByName ;
      private string[] T002Z19_A960ChavePIXUpdatedByName ;
      private bool[] T002Z19_n960ChavePIXUpdatedByName ;
      private int[] T002Z20_A961ChavePIXId ;
      private int[] T002Z3_A961ChavePIXId ;
      private DateTime[] T002Z3_A966ChavePIXCreatedAt ;
      private bool[] T002Z3_n966ChavePIXCreatedAt ;
      private DateTime[] T002Z3_A967ChavePIXUpdatedAt ;
      private bool[] T002Z3_n967ChavePIXUpdatedAt ;
      private bool[] T002Z3_A965ChavePIXPrincipal ;
      private bool[] T002Z3_n965ChavePIXPrincipal ;
      private string[] T002Z3_A962ChavePIXTipo ;
      private bool[] T002Z3_n962ChavePIXTipo ;
      private string[] T002Z3_A963ChavePIXConteudo ;
      private bool[] T002Z3_n963ChavePIXConteudo ;
      private bool[] T002Z3_A964ChavePIXStatus ;
      private bool[] T002Z3_n964ChavePIXStatus ;
      private int[] T002Z3_A951ContaBancariaId ;
      private bool[] T002Z3_n951ContaBancariaId ;
      private short[] T002Z3_A957ChavePIXCreatedBy ;
      private bool[] T002Z3_n957ChavePIXCreatedBy ;
      private short[] T002Z3_A959ChavePIXUpdatedBy ;
      private bool[] T002Z3_n959ChavePIXUpdatedBy ;
      private int[] T002Z21_A961ChavePIXId ;
      private int[] T002Z22_A961ChavePIXId ;
      private int[] T002Z2_A961ChavePIXId ;
      private DateTime[] T002Z2_A966ChavePIXCreatedAt ;
      private bool[] T002Z2_n966ChavePIXCreatedAt ;
      private DateTime[] T002Z2_A967ChavePIXUpdatedAt ;
      private bool[] T002Z2_n967ChavePIXUpdatedAt ;
      private bool[] T002Z2_A965ChavePIXPrincipal ;
      private bool[] T002Z2_n965ChavePIXPrincipal ;
      private string[] T002Z2_A962ChavePIXTipo ;
      private bool[] T002Z2_n962ChavePIXTipo ;
      private string[] T002Z2_A963ChavePIXConteudo ;
      private bool[] T002Z2_n963ChavePIXConteudo ;
      private bool[] T002Z2_A964ChavePIXStatus ;
      private bool[] T002Z2_n964ChavePIXStatus ;
      private int[] T002Z2_A951ContaBancariaId ;
      private bool[] T002Z2_n951ContaBancariaId ;
      private short[] T002Z2_A957ChavePIXCreatedBy ;
      private bool[] T002Z2_n957ChavePIXCreatedBy ;
      private short[] T002Z2_A959ChavePIXUpdatedBy ;
      private bool[] T002Z2_n959ChavePIXUpdatedBy ;
      private int[] T002Z24_A961ChavePIXId ;
      private int[] T002Z27_A938AgenciaId ;
      private bool[] T002Z27_n938AgenciaId ;
      private long[] T002Z27_A952ContaBancariaNumero ;
      private bool[] T002Z27_n952ContaBancariaNumero ;
      private int[] T002Z28_A968AgenciaBancoId ;
      private bool[] T002Z28_n968AgenciaBancoId ;
      private int[] T002Z28_A939AgenciaNumero ;
      private bool[] T002Z28_n939AgenciaNumero ;
      private string[] T002Z29_A969AgenciaBancoNome ;
      private bool[] T002Z29_n969AgenciaBancoNome ;
      private short[] T002Z31_A970ContaBancariaCountChavePIX_F ;
      private bool[] T002Z31_n970ContaBancariaCountChavePIX_F ;
      private string[] T002Z32_A958ChavePIXCreatedByName ;
      private bool[] T002Z32_n958ChavePIXCreatedByName ;
      private string[] T002Z33_A960ChavePIXUpdatedByName ;
      private bool[] T002Z33_n960ChavePIXUpdatedByName ;
      private int[] T002Z34_A961ChavePIXId ;
   }

   public class chavepix__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002Z2;
          prmT002Z2 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z3;
          prmT002Z3 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z4;
          prmT002Z4 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z5;
          prmT002Z5 = new Object[] {
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z6;
          prmT002Z6 = new Object[] {
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z7;
          prmT002Z7 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z8;
          prmT002Z8 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z10;
          prmT002Z10 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z12;
          prmT002Z12 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z13;
          prmT002Z13 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z14;
          prmT002Z14 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z15;
          prmT002Z15 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z17;
          prmT002Z17 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z18;
          prmT002Z18 = new Object[] {
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z19;
          prmT002Z19 = new Object[] {
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z20;
          prmT002Z20 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z21;
          prmT002Z21 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z22;
          prmT002Z22 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z23;
          prmT002Z23 = new Object[] {
          new ParDef("ChavePIXCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXPrincipal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ChavePIXTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ChavePIXConteudo",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ChavePIXStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z24;
          prmT002Z24 = new Object[] {
          };
          Object[] prmT002Z25;
          prmT002Z25 = new Object[] {
          new ParDef("ChavePIXCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXPrincipal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ChavePIXTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ChavePIXConteudo",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ChavePIXStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z26;
          prmT002Z26 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmT002Z27;
          prmT002Z27 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z28;
          prmT002Z28 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z29;
          prmT002Z29 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z31;
          prmT002Z31 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002Z32;
          prmT002Z32 = new Object[] {
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z33;
          prmT002Z33 = new Object[] {
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Z34;
          prmT002Z34 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002Z2", "SELECT ChavePIXId, ChavePIXCreatedAt, ChavePIXUpdatedAt, ChavePIXPrincipal, ChavePIXTipo, ChavePIXConteudo, ChavePIXStatus, ContaBancariaId, ChavePIXCreatedBy, ChavePIXUpdatedBy FROM ChavePIX WHERE ChavePIXId = :ChavePIXId  FOR UPDATE OF ChavePIX NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z3", "SELECT ChavePIXId, ChavePIXCreatedAt, ChavePIXUpdatedAt, ChavePIXPrincipal, ChavePIXTipo, ChavePIXConteudo, ChavePIXStatus, ContaBancariaId, ChavePIXCreatedBy, ChavePIXUpdatedBy FROM ChavePIX WHERE ChavePIXId = :ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z4", "SELECT AgenciaId, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z5", "SELECT SecUserName AS ChavePIXCreatedByName FROM SecUser WHERE SecUserId = :ChavePIXCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z6", "SELECT SecUserName AS ChavePIXUpdatedByName FROM SecUser WHERE SecUserId = :ChavePIXUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z7", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z8", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z10", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z12", "SELECT T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, TM1.ChavePIXId, TM1.ChavePIXCreatedAt, TM1.ChavePIXUpdatedAt, TM1.ChavePIXPrincipal, TM1.ChavePIXTipo, TM1.ChavePIXConteudo, TM1.ChavePIXStatus, T4.ContaBancariaNumero, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome, T2.SecUserName AS ChavePIXCreatedByName, T3.SecUserName AS ChavePIXUpdatedByName, TM1.ContaBancariaId, TM1.ChavePIXCreatedBy AS ChavePIXCreatedBy, TM1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, COALESCE( T7.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM ((((((ChavePIX TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.ChavePIXCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.ChavePIXUpdatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, TM1.ContaBancariaId FROM ChavePIX TM1 WHERE TM1.ContaBancariaId = TM1.ContaBancariaId GROUP BY TM1.ContaBancariaId ) T7 ON T7.ContaBancariaId = TM1.ContaBancariaId) WHERE TM1.ChavePIXId = :ChavePIXId ORDER BY TM1.ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z13", "SELECT AgenciaId, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z14", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z15", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z17", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z18", "SELECT SecUserName AS ChavePIXCreatedByName FROM SecUser WHERE SecUserId = :ChavePIXCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z19", "SELECT SecUserName AS ChavePIXUpdatedByName FROM SecUser WHERE SecUserId = :ChavePIXUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z20", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXId = :ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z21", "SELECT ChavePIXId FROM ChavePIX WHERE ( ChavePIXId > :ChavePIXId) ORDER BY ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Z22", "SELECT ChavePIXId FROM ChavePIX WHERE ( ChavePIXId < :ChavePIXId) ORDER BY ChavePIXId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Z23", "SAVEPOINT gxupdate;INSERT INTO ChavePIX(ChavePIXCreatedAt, ChavePIXUpdatedAt, ChavePIXPrincipal, ChavePIXTipo, ChavePIXConteudo, ChavePIXStatus, ContaBancariaId, ChavePIXCreatedBy, ChavePIXUpdatedBy) VALUES(:ChavePIXCreatedAt, :ChavePIXUpdatedAt, :ChavePIXPrincipal, :ChavePIXTipo, :ChavePIXConteudo, :ChavePIXStatus, :ContaBancariaId, :ChavePIXCreatedBy, :ChavePIXUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002Z23)
             ,new CursorDef("T002Z24", "SELECT currval('ChavePIXId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z25", "SAVEPOINT gxupdate;UPDATE ChavePIX SET ChavePIXCreatedAt=:ChavePIXCreatedAt, ChavePIXUpdatedAt=:ChavePIXUpdatedAt, ChavePIXPrincipal=:ChavePIXPrincipal, ChavePIXTipo=:ChavePIXTipo, ChavePIXConteudo=:ChavePIXConteudo, ChavePIXStatus=:ChavePIXStatus, ContaBancariaId=:ContaBancariaId, ChavePIXCreatedBy=:ChavePIXCreatedBy, ChavePIXUpdatedBy=:ChavePIXUpdatedBy  WHERE ChavePIXId = :ChavePIXId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002Z25)
             ,new CursorDef("T002Z26", "SAVEPOINT gxupdate;DELETE FROM ChavePIX  WHERE ChavePIXId = :ChavePIXId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002Z26)
             ,new CursorDef("T002Z27", "SELECT AgenciaId, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z28", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z29", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z31", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z32", "SELECT SecUserName AS ChavePIXCreatedByName FROM SecUser WHERE SecUserId = :ChavePIXCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z33", "SELECT SecUserName AS ChavePIXUpdatedByName FROM SecUser WHERE SecUserId = :ChavePIXUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Z34", "SELECT ChavePIXId FROM ChavePIX ORDER BY ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z34,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((long[]) buf[17])[0] = rslt.getLong(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
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
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
