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
   public class empresa : GXDataArea
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
            A186MunicipioCodigo = GetPar( "MunicipioCodigo");
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A186MunicipioCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A925EmpresaRepresentanteMunicipio = GetPar( "EmpresaRepresentanteMunicipio");
            n925EmpresaRepresentanteMunicipio = false;
            AssignAttri("", false, "A925EmpresaRepresentanteMunicipio", A925EmpresaRepresentanteMunicipio);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A925EmpresaRepresentanteMunicipio) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A464EmpresaBancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "EmpresaBancoId"), "."), 18, MidpointRounding.ToEven));
            n464EmpresaBancoId = false;
            AssignAttri("", false, "A464EmpresaBancoId", ((0==A464EmpresaBancoId)&&IsIns( )||n464EmpresaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A464EmpresaBancoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A464EmpresaBancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A924EmpresaRepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( GetPar( "EmpresaRepresentanteProfissao"), "."), 18, MidpointRounding.ToEven));
            n924EmpresaRepresentanteProfissao = false;
            AssignAttri("", false, "A924EmpresaRepresentanteProfissao", ((0==A924EmpresaRepresentanteProfissao)&&IsIns( )||n924EmpresaRepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A924EmpresaRepresentanteProfissao), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A924EmpresaRepresentanteProfissao) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "empresa")), "empresa") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "empresa")))) ;
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
                  AV7EmpresaId = (int)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7EmpresaId", StringUtil.LTrimStr( (decimal)(AV7EmpresaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Empresa", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public empresa( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public empresa( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_EmpresaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpresaId = aP1_EmpresaId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpresaId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A249EmpresaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtEmpresaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A249EmpresaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A249EmpresaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEmpresaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Empresa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaNomeFantasia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpresaNomeFantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpresaNomeFantasia_Internalname, A250EmpresaNomeFantasia, StringUtil.RTrim( context.localUtil.Format( A250EmpresaNomeFantasia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaNomeFantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEmpresaNomeFantasia_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empresa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpresaRazaoSocial_Internalname, "Razão social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpresaRazaoSocial_Internalname, A251EmpresaRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A251EmpresaRazaoSocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEmpresaRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empresa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaCNPJ_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpresaCNPJ_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpresaCNPJ_Internalname, A252EmpresaCNPJ, StringUtil.RTrim( context.localUtil.Format( A252EmpresaCNPJ, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaCNPJ_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEmpresaCNPJ_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empresa.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empresa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empresa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empresa.htm");
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
         E11132 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z249EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z249EmpresaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z250EmpresaNomeFantasia = cgiGet( "Z250EmpresaNomeFantasia");
               n250EmpresaNomeFantasia = (String.IsNullOrEmpty(StringUtil.RTrim( A250EmpresaNomeFantasia)) ? true : false);
               Z251EmpresaRazaoSocial = cgiGet( "Z251EmpresaRazaoSocial");
               n251EmpresaRazaoSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A251EmpresaRazaoSocial)) ? true : false);
               Z252EmpresaCNPJ = cgiGet( "Z252EmpresaCNPJ");
               n252EmpresaCNPJ = (String.IsNullOrEmpty(StringUtil.RTrim( A252EmpresaCNPJ)) ? true : false);
               Z253EmpresaSede = StringUtil.StrToBool( cgiGet( "Z253EmpresaSede"));
               n253EmpresaSede = ((false==A253EmpresaSede) ? true : false);
               Z465EmpresaAgencia = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z465EmpresaAgencia"), ",", "."), 18, MidpointRounding.ToEven));
               n465EmpresaAgencia = ((0==A465EmpresaAgencia) ? true : false);
               Z466EmpresaAgenciaDigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z466EmpresaAgenciaDigito"), ",", "."), 18, MidpointRounding.ToEven));
               n466EmpresaAgenciaDigito = ((0==A466EmpresaAgenciaDigito) ? true : false);
               Z467EmpresaConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z467EmpresaConta"), ",", "."), 18, MidpointRounding.ToEven));
               n467EmpresaConta = ((0==A467EmpresaConta) ? true : false);
               Z468EmpresaPix = cgiGet( "Z468EmpresaPix");
               n468EmpresaPix = (String.IsNullOrEmpty(StringUtil.RTrim( A468EmpresaPix)) ? true : false);
               Z469EmpresaPixTipo = cgiGet( "Z469EmpresaPixTipo");
               n469EmpresaPixTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A469EmpresaPixTipo)) ? true : false);
               Z470EmpresaEmail = cgiGet( "Z470EmpresaEmail");
               n470EmpresaEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A470EmpresaEmail)) ? true : false);
               Z610EmpresaLogradouro = cgiGet( "Z610EmpresaLogradouro");
               n610EmpresaLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A610EmpresaLogradouro)) ? true : false);
               Z611EmpresaLogradouroNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z611EmpresaLogradouroNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n611EmpresaLogradouroNumero = ((0==A611EmpresaLogradouroNumero) ? true : false);
               Z609EmpresaCEP = cgiGet( "Z609EmpresaCEP");
               n609EmpresaCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A609EmpresaCEP)) ? true : false);
               Z612EmpresaBairro = cgiGet( "Z612EmpresaBairro");
               n612EmpresaBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A612EmpresaBairro)) ? true : false);
               Z613EmpresaComplemento = cgiGet( "Z613EmpresaComplemento");
               n613EmpresaComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A613EmpresaComplemento)) ? true : false);
               Z770EmpresaRepresentanteCPF = cgiGet( "Z770EmpresaRepresentanteCPF");
               n770EmpresaRepresentanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A770EmpresaRepresentanteCPF)) ? true : false);
               Z771EmpresaRepresentanteNome = cgiGet( "Z771EmpresaRepresentanteNome");
               n771EmpresaRepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A771EmpresaRepresentanteNome)) ? true : false);
               Z772EmpresaRepresentanteEmail = cgiGet( "Z772EmpresaRepresentanteEmail");
               n772EmpresaRepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A772EmpresaRepresentanteEmail)) ? true : false);
               Z773EmpresaUtilizaRepresentanteAssinatura = StringUtil.StrToBool( cgiGet( "Z773EmpresaUtilizaRepresentanteAssinatura"));
               n773EmpresaUtilizaRepresentanteAssinatura = ((false==A773EmpresaUtilizaRepresentanteAssinatura) ? true : false);
               Z928EmpresaRepresentanteLogradouro = cgiGet( "Z928EmpresaRepresentanteLogradouro");
               n928EmpresaRepresentanteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A928EmpresaRepresentanteLogradouro)) ? true : false);
               Z929EmpresaRepresentanteNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z929EmpresaRepresentanteNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n929EmpresaRepresentanteNumero = ((0==A929EmpresaRepresentanteNumero) ? true : false);
               Z930EmpresaRepresentanteCEP = cgiGet( "Z930EmpresaRepresentanteCEP");
               n930EmpresaRepresentanteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A930EmpresaRepresentanteCEP)) ? true : false);
               Z931EmpresaRepresentanteBairro = cgiGet( "Z931EmpresaRepresentanteBairro");
               n931EmpresaRepresentanteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A931EmpresaRepresentanteBairro)) ? true : false);
               Z932EmpresaRepresentanteComplemento = cgiGet( "Z932EmpresaRepresentanteComplemento");
               n932EmpresaRepresentanteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A932EmpresaRepresentanteComplemento)) ? true : false);
               Z933EmpresaRepresentanteNacionalidade = cgiGet( "Z933EmpresaRepresentanteNacionalidade");
               n933EmpresaRepresentanteNacionalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A933EmpresaRepresentanteNacionalidade)) ? true : false);
               Z934EmpresaRepresentanteTelefone = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z934EmpresaRepresentanteTelefone"), ",", "."), 18, MidpointRounding.ToEven));
               n934EmpresaRepresentanteTelefone = ((0==A934EmpresaRepresentanteTelefone) ? true : false);
               Z935EmpresaRepresentanteTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z935EmpresaRepresentanteTelefoneDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n935EmpresaRepresentanteTelefoneDDD = ((0==A935EmpresaRepresentanteTelefoneDDD) ? true : false);
               Z186MunicipioCodigo = cgiGet( "Z186MunicipioCodigo");
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               Z925EmpresaRepresentanteMunicipio = cgiGet( "Z925EmpresaRepresentanteMunicipio");
               n925EmpresaRepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ? true : false);
               Z464EmpresaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z464EmpresaBancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n464EmpresaBancoId = ((0==A464EmpresaBancoId) ? true : false);
               Z924EmpresaRepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z924EmpresaRepresentanteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n924EmpresaRepresentanteProfissao = ((0==A924EmpresaRepresentanteProfissao) ? true : false);
               A253EmpresaSede = StringUtil.StrToBool( cgiGet( "Z253EmpresaSede"));
               n253EmpresaSede = false;
               n253EmpresaSede = ((false==A253EmpresaSede) ? true : false);
               A465EmpresaAgencia = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z465EmpresaAgencia"), ",", "."), 18, MidpointRounding.ToEven));
               n465EmpresaAgencia = false;
               n465EmpresaAgencia = ((0==A465EmpresaAgencia) ? true : false);
               A466EmpresaAgenciaDigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z466EmpresaAgenciaDigito"), ",", "."), 18, MidpointRounding.ToEven));
               n466EmpresaAgenciaDigito = false;
               n466EmpresaAgenciaDigito = ((0==A466EmpresaAgenciaDigito) ? true : false);
               A467EmpresaConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z467EmpresaConta"), ",", "."), 18, MidpointRounding.ToEven));
               n467EmpresaConta = false;
               n467EmpresaConta = ((0==A467EmpresaConta) ? true : false);
               A468EmpresaPix = cgiGet( "Z468EmpresaPix");
               n468EmpresaPix = false;
               n468EmpresaPix = (String.IsNullOrEmpty(StringUtil.RTrim( A468EmpresaPix)) ? true : false);
               A469EmpresaPixTipo = cgiGet( "Z469EmpresaPixTipo");
               n469EmpresaPixTipo = false;
               n469EmpresaPixTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A469EmpresaPixTipo)) ? true : false);
               A470EmpresaEmail = cgiGet( "Z470EmpresaEmail");
               n470EmpresaEmail = false;
               n470EmpresaEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A470EmpresaEmail)) ? true : false);
               A610EmpresaLogradouro = cgiGet( "Z610EmpresaLogradouro");
               n610EmpresaLogradouro = false;
               n610EmpresaLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A610EmpresaLogradouro)) ? true : false);
               A611EmpresaLogradouroNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z611EmpresaLogradouroNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n611EmpresaLogradouroNumero = false;
               n611EmpresaLogradouroNumero = ((0==A611EmpresaLogradouroNumero) ? true : false);
               A609EmpresaCEP = cgiGet( "Z609EmpresaCEP");
               n609EmpresaCEP = false;
               n609EmpresaCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A609EmpresaCEP)) ? true : false);
               A612EmpresaBairro = cgiGet( "Z612EmpresaBairro");
               n612EmpresaBairro = false;
               n612EmpresaBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A612EmpresaBairro)) ? true : false);
               A613EmpresaComplemento = cgiGet( "Z613EmpresaComplemento");
               n613EmpresaComplemento = false;
               n613EmpresaComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A613EmpresaComplemento)) ? true : false);
               A770EmpresaRepresentanteCPF = cgiGet( "Z770EmpresaRepresentanteCPF");
               n770EmpresaRepresentanteCPF = false;
               n770EmpresaRepresentanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A770EmpresaRepresentanteCPF)) ? true : false);
               A771EmpresaRepresentanteNome = cgiGet( "Z771EmpresaRepresentanteNome");
               n771EmpresaRepresentanteNome = false;
               n771EmpresaRepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A771EmpresaRepresentanteNome)) ? true : false);
               A772EmpresaRepresentanteEmail = cgiGet( "Z772EmpresaRepresentanteEmail");
               n772EmpresaRepresentanteEmail = false;
               n772EmpresaRepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A772EmpresaRepresentanteEmail)) ? true : false);
               A773EmpresaUtilizaRepresentanteAssinatura = StringUtil.StrToBool( cgiGet( "Z773EmpresaUtilizaRepresentanteAssinatura"));
               n773EmpresaUtilizaRepresentanteAssinatura = false;
               n773EmpresaUtilizaRepresentanteAssinatura = ((false==A773EmpresaUtilizaRepresentanteAssinatura) ? true : false);
               A928EmpresaRepresentanteLogradouro = cgiGet( "Z928EmpresaRepresentanteLogradouro");
               n928EmpresaRepresentanteLogradouro = false;
               n928EmpresaRepresentanteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A928EmpresaRepresentanteLogradouro)) ? true : false);
               A929EmpresaRepresentanteNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z929EmpresaRepresentanteNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n929EmpresaRepresentanteNumero = false;
               n929EmpresaRepresentanteNumero = ((0==A929EmpresaRepresentanteNumero) ? true : false);
               A930EmpresaRepresentanteCEP = cgiGet( "Z930EmpresaRepresentanteCEP");
               n930EmpresaRepresentanteCEP = false;
               n930EmpresaRepresentanteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A930EmpresaRepresentanteCEP)) ? true : false);
               A931EmpresaRepresentanteBairro = cgiGet( "Z931EmpresaRepresentanteBairro");
               n931EmpresaRepresentanteBairro = false;
               n931EmpresaRepresentanteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A931EmpresaRepresentanteBairro)) ? true : false);
               A932EmpresaRepresentanteComplemento = cgiGet( "Z932EmpresaRepresentanteComplemento");
               n932EmpresaRepresentanteComplemento = false;
               n932EmpresaRepresentanteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A932EmpresaRepresentanteComplemento)) ? true : false);
               A933EmpresaRepresentanteNacionalidade = cgiGet( "Z933EmpresaRepresentanteNacionalidade");
               n933EmpresaRepresentanteNacionalidade = false;
               n933EmpresaRepresentanteNacionalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A933EmpresaRepresentanteNacionalidade)) ? true : false);
               A934EmpresaRepresentanteTelefone = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z934EmpresaRepresentanteTelefone"), ",", "."), 18, MidpointRounding.ToEven));
               n934EmpresaRepresentanteTelefone = false;
               n934EmpresaRepresentanteTelefone = ((0==A934EmpresaRepresentanteTelefone) ? true : false);
               A935EmpresaRepresentanteTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z935EmpresaRepresentanteTelefoneDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n935EmpresaRepresentanteTelefoneDDD = false;
               n935EmpresaRepresentanteTelefoneDDD = ((0==A935EmpresaRepresentanteTelefoneDDD) ? true : false);
               A186MunicipioCodigo = cgiGet( "Z186MunicipioCodigo");
               n186MunicipioCodigo = false;
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               A925EmpresaRepresentanteMunicipio = cgiGet( "Z925EmpresaRepresentanteMunicipio");
               n925EmpresaRepresentanteMunicipio = false;
               n925EmpresaRepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ? true : false);
               A464EmpresaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z464EmpresaBancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n464EmpresaBancoId = false;
               n464EmpresaBancoId = ((0==A464EmpresaBancoId) ? true : false);
               A924EmpresaRepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z924EmpresaRepresentanteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n924EmpresaRepresentanteProfissao = false;
               n924EmpresaRepresentanteProfissao = ((0==A924EmpresaRepresentanteProfissao) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N464EmpresaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N464EmpresaBancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n464EmpresaBancoId = ((0==A464EmpresaBancoId) ? true : false);
               N186MunicipioCodigo = cgiGet( "N186MunicipioCodigo");
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               N925EmpresaRepresentanteMunicipio = cgiGet( "N925EmpresaRepresentanteMunicipio");
               n925EmpresaRepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ? true : false);
               N924EmpresaRepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N924EmpresaRepresentanteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n924EmpresaRepresentanteProfissao = ((0==A924EmpresaRepresentanteProfissao) ? true : false);
               AV7EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPRESAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_EmpresaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPRESABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_EmpresaBancoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EmpresaBancoId), 9, 0));
               A464EmpresaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               n464EmpresaBancoId = ((0==A464EmpresaBancoId) ? true : false);
               AV13Insert_MunicipioCodigo = cgiGet( "vINSERT_MUNICIPIOCODIGO");
               AssignAttri("", false, "AV13Insert_MunicipioCodigo", AV13Insert_MunicipioCodigo);
               A186MunicipioCodigo = cgiGet( "MUNICIPIOCODIGO");
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               AV14Insert_EmpresaRepresentanteMunicipio = cgiGet( "vINSERT_EMPRESAREPRESENTANTEMUNICIPIO");
               AssignAttri("", false, "AV14Insert_EmpresaRepresentanteMunicipio", AV14Insert_EmpresaRepresentanteMunicipio);
               A925EmpresaRepresentanteMunicipio = cgiGet( "EMPRESAREPRESENTANTEMUNICIPIO");
               n925EmpresaRepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ? true : false);
               AV15Insert_EmpresaRepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPRESAREPRESENTANTEPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15Insert_EmpresaRepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV15Insert_EmpresaRepresentanteProfissao), 9, 0));
               A924EmpresaRepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESAREPRESENTANTEPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               n924EmpresaRepresentanteProfissao = ((0==A924EmpresaRepresentanteProfissao) ? true : false);
               A253EmpresaSede = StringUtil.StrToBool( cgiGet( "EMPRESASEDE"));
               n253EmpresaSede = ((false==A253EmpresaSede) ? true : false);
               A465EmpresaAgencia = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESAAGENCIA"), ",", "."), 18, MidpointRounding.ToEven));
               n465EmpresaAgencia = ((0==A465EmpresaAgencia) ? true : false);
               A466EmpresaAgenciaDigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESAAGENCIADIGITO"), ",", "."), 18, MidpointRounding.ToEven));
               n466EmpresaAgenciaDigito = ((0==A466EmpresaAgenciaDigito) ? true : false);
               A467EmpresaConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESACONTA"), ",", "."), 18, MidpointRounding.ToEven));
               n467EmpresaConta = ((0==A467EmpresaConta) ? true : false);
               A468EmpresaPix = cgiGet( "EMPRESAPIX");
               n468EmpresaPix = (String.IsNullOrEmpty(StringUtil.RTrim( A468EmpresaPix)) ? true : false);
               A469EmpresaPixTipo = cgiGet( "EMPRESAPIXTIPO");
               n469EmpresaPixTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A469EmpresaPixTipo)) ? true : false);
               A470EmpresaEmail = cgiGet( "EMPRESAEMAIL");
               n470EmpresaEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A470EmpresaEmail)) ? true : false);
               A610EmpresaLogradouro = cgiGet( "EMPRESALOGRADOURO");
               n610EmpresaLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A610EmpresaLogradouro)) ? true : false);
               A611EmpresaLogradouroNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESALOGRADOURONUMERO"), ",", "."), 18, MidpointRounding.ToEven));
               n611EmpresaLogradouroNumero = ((0==A611EmpresaLogradouroNumero) ? true : false);
               A609EmpresaCEP = cgiGet( "EMPRESACEP");
               n609EmpresaCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A609EmpresaCEP)) ? true : false);
               A612EmpresaBairro = cgiGet( "EMPRESABAIRRO");
               n612EmpresaBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A612EmpresaBairro)) ? true : false);
               A613EmpresaComplemento = cgiGet( "EMPRESACOMPLEMENTO");
               n613EmpresaComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A613EmpresaComplemento)) ? true : false);
               A770EmpresaRepresentanteCPF = cgiGet( "EMPRESAREPRESENTANTECPF");
               n770EmpresaRepresentanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A770EmpresaRepresentanteCPF)) ? true : false);
               A771EmpresaRepresentanteNome = cgiGet( "EMPRESAREPRESENTANTENOME");
               n771EmpresaRepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A771EmpresaRepresentanteNome)) ? true : false);
               A772EmpresaRepresentanteEmail = cgiGet( "EMPRESAREPRESENTANTEEMAIL");
               n772EmpresaRepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A772EmpresaRepresentanteEmail)) ? true : false);
               A773EmpresaUtilizaRepresentanteAssinatura = StringUtil.StrToBool( cgiGet( "EMPRESAUTILIZAREPRESENTANTEASSINATURA"));
               n773EmpresaUtilizaRepresentanteAssinatura = ((false==A773EmpresaUtilizaRepresentanteAssinatura) ? true : false);
               A928EmpresaRepresentanteLogradouro = cgiGet( "EMPRESAREPRESENTANTELOGRADOURO");
               n928EmpresaRepresentanteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A928EmpresaRepresentanteLogradouro)) ? true : false);
               A929EmpresaRepresentanteNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESAREPRESENTANTENUMERO"), ",", "."), 18, MidpointRounding.ToEven));
               n929EmpresaRepresentanteNumero = ((0==A929EmpresaRepresentanteNumero) ? true : false);
               A930EmpresaRepresentanteCEP = cgiGet( "EMPRESAREPRESENTANTECEP");
               n930EmpresaRepresentanteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A930EmpresaRepresentanteCEP)) ? true : false);
               A931EmpresaRepresentanteBairro = cgiGet( "EMPRESAREPRESENTANTEBAIRRO");
               n931EmpresaRepresentanteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A931EmpresaRepresentanteBairro)) ? true : false);
               A932EmpresaRepresentanteComplemento = cgiGet( "EMPRESAREPRESENTANTECOMPLEMENTO");
               n932EmpresaRepresentanteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A932EmpresaRepresentanteComplemento)) ? true : false);
               A933EmpresaRepresentanteNacionalidade = cgiGet( "EMPRESAREPRESENTANTENACIONALIDADE");
               n933EmpresaRepresentanteNacionalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A933EmpresaRepresentanteNacionalidade)) ? true : false);
               A934EmpresaRepresentanteTelefone = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESAREPRESENTANTETELEFONE"), ",", "."), 18, MidpointRounding.ToEven));
               n934EmpresaRepresentanteTelefone = ((0==A934EmpresaRepresentanteTelefone) ? true : false);
               A935EmpresaRepresentanteTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "EMPRESAREPRESENTANTETELEFONEDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n935EmpresaRepresentanteTelefoneDDD = ((0==A935EmpresaRepresentanteTelefoneDDD) ? true : false);
               A187MunicipioNome = cgiGet( "MUNICIPIONOME");
               n187MunicipioNome = false;
               A189MunicipioUF = cgiGet( "MUNICIPIOUF");
               n189MunicipioUF = false;
               A926EmpresaRepresentanteMunicipioNome = cgiGet( "EMPRESAREPRESENTANTEMUNICIPIONOME");
               n926EmpresaRepresentanteMunicipioNome = false;
               A927EmpresaRepresentanteMunicipioUF = cgiGet( "EMPRESAREPRESENTANTEMUNICIPIOUF");
               n927EmpresaRepresentanteMunicipioUF = false;
               A403BancoNome = cgiGet( "BANCONOME");
               n403BancoNome = false;
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
               A249EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
               A250EmpresaNomeFantasia = cgiGet( edtEmpresaNomeFantasia_Internalname);
               n250EmpresaNomeFantasia = false;
               AssignAttri("", false, "A250EmpresaNomeFantasia", A250EmpresaNomeFantasia);
               n250EmpresaNomeFantasia = (String.IsNullOrEmpty(StringUtil.RTrim( A250EmpresaNomeFantasia)) ? true : false);
               A251EmpresaRazaoSocial = cgiGet( edtEmpresaRazaoSocial_Internalname);
               n251EmpresaRazaoSocial = false;
               AssignAttri("", false, "A251EmpresaRazaoSocial", A251EmpresaRazaoSocial);
               n251EmpresaRazaoSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A251EmpresaRazaoSocial)) ? true : false);
               A252EmpresaCNPJ = cgiGet( edtEmpresaCNPJ_Internalname);
               n252EmpresaCNPJ = false;
               AssignAttri("", false, "A252EmpresaCNPJ", A252EmpresaCNPJ);
               n252EmpresaCNPJ = (String.IsNullOrEmpty(StringUtil.RTrim( A252EmpresaCNPJ)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Empresa");
               A249EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
               forbiddenHiddens.Add("EmpresaId", context.localUtil.Format( (decimal)(A249EmpresaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_EmpresaBancoId", context.localUtil.Format( (decimal)(AV11Insert_EmpresaBancoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_MunicipioCodigo", StringUtil.RTrim( context.localUtil.Format( AV13Insert_MunicipioCodigo, "")));
               forbiddenHiddens.Add("Insert_EmpresaRepresentanteMunicipio", StringUtil.RTrim( context.localUtil.Format( AV14Insert_EmpresaRepresentanteMunicipio, "")));
               forbiddenHiddens.Add("Insert_EmpresaRepresentanteProfissao", context.localUtil.Format( (decimal)(AV15Insert_EmpresaRepresentanteProfissao), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("EmpresaSede", StringUtil.BoolToStr( A253EmpresaSede));
               forbiddenHiddens.Add("EmpresaAgencia", context.localUtil.Format( (decimal)(A465EmpresaAgencia), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("EmpresaAgenciaDigito", context.localUtil.Format( (decimal)(A466EmpresaAgenciaDigito), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("EmpresaConta", context.localUtil.Format( (decimal)(A467EmpresaConta), "ZZZZZZZ9"));
               forbiddenHiddens.Add("EmpresaPix", StringUtil.RTrim( context.localUtil.Format( A468EmpresaPix, "")));
               forbiddenHiddens.Add("EmpresaPixTipo", StringUtil.RTrim( context.localUtil.Format( A469EmpresaPixTipo, "")));
               forbiddenHiddens.Add("EmpresaEmail", StringUtil.RTrim( context.localUtil.Format( A470EmpresaEmail, "")));
               forbiddenHiddens.Add("EmpresaLogradouro", StringUtil.RTrim( context.localUtil.Format( A610EmpresaLogradouro, "")));
               forbiddenHiddens.Add("EmpresaLogradouroNumero", context.localUtil.Format( (decimal)(A611EmpresaLogradouroNumero), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("EmpresaCEP", StringUtil.RTrim( context.localUtil.Format( A609EmpresaCEP, "")));
               forbiddenHiddens.Add("EmpresaBairro", StringUtil.RTrim( context.localUtil.Format( A612EmpresaBairro, "")));
               forbiddenHiddens.Add("EmpresaComplemento", StringUtil.RTrim( context.localUtil.Format( A613EmpresaComplemento, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteCPF", StringUtil.RTrim( context.localUtil.Format( A770EmpresaRepresentanteCPF, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteNome", StringUtil.RTrim( context.localUtil.Format( A771EmpresaRepresentanteNome, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteEmail", StringUtil.RTrim( context.localUtil.Format( A772EmpresaRepresentanteEmail, "")));
               forbiddenHiddens.Add("EmpresaUtilizaRepresentanteAssinatura", StringUtil.BoolToStr( A773EmpresaUtilizaRepresentanteAssinatura));
               forbiddenHiddens.Add("EmpresaRepresentanteLogradouro", StringUtil.RTrim( context.localUtil.Format( A928EmpresaRepresentanteLogradouro, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteNumero", context.localUtil.Format( (decimal)(A929EmpresaRepresentanteNumero), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("EmpresaRepresentanteCEP", StringUtil.RTrim( context.localUtil.Format( A930EmpresaRepresentanteCEP, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteBairro", StringUtil.RTrim( context.localUtil.Format( A931EmpresaRepresentanteBairro, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteComplemento", StringUtil.RTrim( context.localUtil.Format( A932EmpresaRepresentanteComplemento, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteNacionalidade", StringUtil.RTrim( context.localUtil.Format( A933EmpresaRepresentanteNacionalidade, "")));
               forbiddenHiddens.Add("EmpresaRepresentanteTelefone", context.localUtil.Format( (decimal)(A934EmpresaRepresentanteTelefone), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("EmpresaRepresentanteTelefoneDDD", context.localUtil.Format( (decimal)(A935EmpresaRepresentanteTelefoneDDD), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A249EmpresaId != Z249EmpresaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("empresa:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A249EmpresaId = (int)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
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
                     sMode42 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode42;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound42 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_130( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPRESAID");
                        AnyError = 1;
                        GX_FocusControl = edtEmpresaId_Internalname;
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
                           E11132 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12132 ();
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
            E12132 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1342( ) ;
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
            DisableAttributes1342( ) ;
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1342( ) ;
            }
            else
            {
               CheckExtendedTable1342( ) ;
               CloseExtendedTableCursors1342( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption130( )
      {
      }

      protected void E11132( )
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
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmpresaBancoId") == 0 )
               {
                  AV11Insert_EmpresaBancoId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_EmpresaBancoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EmpresaBancoId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "MunicipioCodigo") == 0 )
               {
                  AV13Insert_MunicipioCodigo = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_MunicipioCodigo", AV13Insert_MunicipioCodigo);
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmpresaRepresentanteMunicipio") == 0 )
               {
                  AV14Insert_EmpresaRepresentanteMunicipio = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV14Insert_EmpresaRepresentanteMunicipio", AV14Insert_EmpresaRepresentanteMunicipio);
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmpresaRepresentanteProfissao") == 0 )
               {
                  AV15Insert_EmpresaRepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Insert_EmpresaRepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV15Insert_EmpresaRepresentanteProfissao), 9, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E12132( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("empresaww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1342( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z250EmpresaNomeFantasia = T00133_A250EmpresaNomeFantasia[0];
               Z251EmpresaRazaoSocial = T00133_A251EmpresaRazaoSocial[0];
               Z252EmpresaCNPJ = T00133_A252EmpresaCNPJ[0];
               Z253EmpresaSede = T00133_A253EmpresaSede[0];
               Z465EmpresaAgencia = T00133_A465EmpresaAgencia[0];
               Z466EmpresaAgenciaDigito = T00133_A466EmpresaAgenciaDigito[0];
               Z467EmpresaConta = T00133_A467EmpresaConta[0];
               Z468EmpresaPix = T00133_A468EmpresaPix[0];
               Z469EmpresaPixTipo = T00133_A469EmpresaPixTipo[0];
               Z470EmpresaEmail = T00133_A470EmpresaEmail[0];
               Z610EmpresaLogradouro = T00133_A610EmpresaLogradouro[0];
               Z611EmpresaLogradouroNumero = T00133_A611EmpresaLogradouroNumero[0];
               Z609EmpresaCEP = T00133_A609EmpresaCEP[0];
               Z612EmpresaBairro = T00133_A612EmpresaBairro[0];
               Z613EmpresaComplemento = T00133_A613EmpresaComplemento[0];
               Z770EmpresaRepresentanteCPF = T00133_A770EmpresaRepresentanteCPF[0];
               Z771EmpresaRepresentanteNome = T00133_A771EmpresaRepresentanteNome[0];
               Z772EmpresaRepresentanteEmail = T00133_A772EmpresaRepresentanteEmail[0];
               Z773EmpresaUtilizaRepresentanteAssinatura = T00133_A773EmpresaUtilizaRepresentanteAssinatura[0];
               Z928EmpresaRepresentanteLogradouro = T00133_A928EmpresaRepresentanteLogradouro[0];
               Z929EmpresaRepresentanteNumero = T00133_A929EmpresaRepresentanteNumero[0];
               Z930EmpresaRepresentanteCEP = T00133_A930EmpresaRepresentanteCEP[0];
               Z931EmpresaRepresentanteBairro = T00133_A931EmpresaRepresentanteBairro[0];
               Z932EmpresaRepresentanteComplemento = T00133_A932EmpresaRepresentanteComplemento[0];
               Z933EmpresaRepresentanteNacionalidade = T00133_A933EmpresaRepresentanteNacionalidade[0];
               Z934EmpresaRepresentanteTelefone = T00133_A934EmpresaRepresentanteTelefone[0];
               Z935EmpresaRepresentanteTelefoneDDD = T00133_A935EmpresaRepresentanteTelefoneDDD[0];
               Z186MunicipioCodigo = T00133_A186MunicipioCodigo[0];
               Z925EmpresaRepresentanteMunicipio = T00133_A925EmpresaRepresentanteMunicipio[0];
               Z464EmpresaBancoId = T00133_A464EmpresaBancoId[0];
               Z924EmpresaRepresentanteProfissao = T00133_A924EmpresaRepresentanteProfissao[0];
            }
            else
            {
               Z250EmpresaNomeFantasia = A250EmpresaNomeFantasia;
               Z251EmpresaRazaoSocial = A251EmpresaRazaoSocial;
               Z252EmpresaCNPJ = A252EmpresaCNPJ;
               Z253EmpresaSede = A253EmpresaSede;
               Z465EmpresaAgencia = A465EmpresaAgencia;
               Z466EmpresaAgenciaDigito = A466EmpresaAgenciaDigito;
               Z467EmpresaConta = A467EmpresaConta;
               Z468EmpresaPix = A468EmpresaPix;
               Z469EmpresaPixTipo = A469EmpresaPixTipo;
               Z470EmpresaEmail = A470EmpresaEmail;
               Z610EmpresaLogradouro = A610EmpresaLogradouro;
               Z611EmpresaLogradouroNumero = A611EmpresaLogradouroNumero;
               Z609EmpresaCEP = A609EmpresaCEP;
               Z612EmpresaBairro = A612EmpresaBairro;
               Z613EmpresaComplemento = A613EmpresaComplemento;
               Z770EmpresaRepresentanteCPF = A770EmpresaRepresentanteCPF;
               Z771EmpresaRepresentanteNome = A771EmpresaRepresentanteNome;
               Z772EmpresaRepresentanteEmail = A772EmpresaRepresentanteEmail;
               Z773EmpresaUtilizaRepresentanteAssinatura = A773EmpresaUtilizaRepresentanteAssinatura;
               Z928EmpresaRepresentanteLogradouro = A928EmpresaRepresentanteLogradouro;
               Z929EmpresaRepresentanteNumero = A929EmpresaRepresentanteNumero;
               Z930EmpresaRepresentanteCEP = A930EmpresaRepresentanteCEP;
               Z931EmpresaRepresentanteBairro = A931EmpresaRepresentanteBairro;
               Z932EmpresaRepresentanteComplemento = A932EmpresaRepresentanteComplemento;
               Z933EmpresaRepresentanteNacionalidade = A933EmpresaRepresentanteNacionalidade;
               Z934EmpresaRepresentanteTelefone = A934EmpresaRepresentanteTelefone;
               Z935EmpresaRepresentanteTelefoneDDD = A935EmpresaRepresentanteTelefoneDDD;
               Z186MunicipioCodigo = A186MunicipioCodigo;
               Z925EmpresaRepresentanteMunicipio = A925EmpresaRepresentanteMunicipio;
               Z464EmpresaBancoId = A464EmpresaBancoId;
               Z924EmpresaRepresentanteProfissao = A924EmpresaRepresentanteProfissao;
            }
         }
         if ( GX_JID == -13 )
         {
            Z249EmpresaId = A249EmpresaId;
            Z250EmpresaNomeFantasia = A250EmpresaNomeFantasia;
            Z251EmpresaRazaoSocial = A251EmpresaRazaoSocial;
            Z252EmpresaCNPJ = A252EmpresaCNPJ;
            Z253EmpresaSede = A253EmpresaSede;
            Z465EmpresaAgencia = A465EmpresaAgencia;
            Z466EmpresaAgenciaDigito = A466EmpresaAgenciaDigito;
            Z467EmpresaConta = A467EmpresaConta;
            Z468EmpresaPix = A468EmpresaPix;
            Z469EmpresaPixTipo = A469EmpresaPixTipo;
            Z470EmpresaEmail = A470EmpresaEmail;
            Z610EmpresaLogradouro = A610EmpresaLogradouro;
            Z611EmpresaLogradouroNumero = A611EmpresaLogradouroNumero;
            Z609EmpresaCEP = A609EmpresaCEP;
            Z612EmpresaBairro = A612EmpresaBairro;
            Z613EmpresaComplemento = A613EmpresaComplemento;
            Z770EmpresaRepresentanteCPF = A770EmpresaRepresentanteCPF;
            Z771EmpresaRepresentanteNome = A771EmpresaRepresentanteNome;
            Z772EmpresaRepresentanteEmail = A772EmpresaRepresentanteEmail;
            Z773EmpresaUtilizaRepresentanteAssinatura = A773EmpresaUtilizaRepresentanteAssinatura;
            Z928EmpresaRepresentanteLogradouro = A928EmpresaRepresentanteLogradouro;
            Z929EmpresaRepresentanteNumero = A929EmpresaRepresentanteNumero;
            Z930EmpresaRepresentanteCEP = A930EmpresaRepresentanteCEP;
            Z931EmpresaRepresentanteBairro = A931EmpresaRepresentanteBairro;
            Z932EmpresaRepresentanteComplemento = A932EmpresaRepresentanteComplemento;
            Z933EmpresaRepresentanteNacionalidade = A933EmpresaRepresentanteNacionalidade;
            Z934EmpresaRepresentanteTelefone = A934EmpresaRepresentanteTelefone;
            Z935EmpresaRepresentanteTelefoneDDD = A935EmpresaRepresentanteTelefoneDDD;
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z925EmpresaRepresentanteMunicipio = A925EmpresaRepresentanteMunicipio;
            Z464EmpresaBancoId = A464EmpresaBancoId;
            Z924EmpresaRepresentanteProfissao = A924EmpresaRepresentanteProfissao;
            Z187MunicipioNome = A187MunicipioNome;
            Z189MunicipioUF = A189MunicipioUF;
            Z926EmpresaRepresentanteMunicipioNome = A926EmpresaRepresentanteMunicipioNome;
            Z927EmpresaRepresentanteMunicipioUF = A927EmpresaRepresentanteMunicipioUF;
            Z403BancoNome = A403BancoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         AV16Pgmname = "Empresa";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EmpresaId) )
         {
            A249EmpresaId = AV7EmpresaId;
            AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_EmpresaRepresentanteProfissao) )
         {
            A924EmpresaRepresentanteProfissao = AV15Insert_EmpresaRepresentanteProfissao;
            n924EmpresaRepresentanteProfissao = false;
            AssignAttri("", false, "A924EmpresaRepresentanteProfissao", ((0==A924EmpresaRepresentanteProfissao)&&IsIns( )||n924EmpresaRepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A924EmpresaRepresentanteProfissao), 9, 0, ".", ""))));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_EmpresaRepresentanteMunicipio)) )
         {
            A925EmpresaRepresentanteMunicipio = AV14Insert_EmpresaRepresentanteMunicipio;
            n925EmpresaRepresentanteMunicipio = false;
            AssignAttri("", false, "A925EmpresaRepresentanteMunicipio", A925EmpresaRepresentanteMunicipio);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_MunicipioCodigo)) )
         {
            A186MunicipioCodigo = AV13Insert_MunicipioCodigo;
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EmpresaBancoId) )
         {
            A464EmpresaBancoId = AV11Insert_EmpresaBancoId;
            n464EmpresaBancoId = false;
            AssignAttri("", false, "A464EmpresaBancoId", ((0==A464EmpresaBancoId)&&IsIns( )||n464EmpresaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A464EmpresaBancoId), 9, 0, ".", ""))));
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
            /* Using cursor T00135 */
            pr_default.execute(3, new Object[] {n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio});
            A926EmpresaRepresentanteMunicipioNome = T00135_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = T00135_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = T00135_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = T00135_n927EmpresaRepresentanteMunicipioUF[0];
            pr_default.close(3);
            /* Using cursor T00134 */
            pr_default.execute(2, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            A187MunicipioNome = T00134_A187MunicipioNome[0];
            n187MunicipioNome = T00134_n187MunicipioNome[0];
            A189MunicipioUF = T00134_A189MunicipioUF[0];
            n189MunicipioUF = T00134_n189MunicipioUF[0];
            pr_default.close(2);
            /* Using cursor T00136 */
            pr_default.execute(4, new Object[] {n464EmpresaBancoId, A464EmpresaBancoId});
            A403BancoNome = T00136_A403BancoNome[0];
            n403BancoNome = T00136_n403BancoNome[0];
            pr_default.close(4);
         }
      }

      protected void Load1342( )
      {
         /* Using cursor T00138 */
         pr_default.execute(6, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound42 = 1;
            A250EmpresaNomeFantasia = T00138_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = T00138_n250EmpresaNomeFantasia[0];
            AssignAttri("", false, "A250EmpresaNomeFantasia", A250EmpresaNomeFantasia);
            A251EmpresaRazaoSocial = T00138_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = T00138_n251EmpresaRazaoSocial[0];
            AssignAttri("", false, "A251EmpresaRazaoSocial", A251EmpresaRazaoSocial);
            A252EmpresaCNPJ = T00138_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = T00138_n252EmpresaCNPJ[0];
            AssignAttri("", false, "A252EmpresaCNPJ", A252EmpresaCNPJ);
            A253EmpresaSede = T00138_A253EmpresaSede[0];
            n253EmpresaSede = T00138_n253EmpresaSede[0];
            A403BancoNome = T00138_A403BancoNome[0];
            n403BancoNome = T00138_n403BancoNome[0];
            A465EmpresaAgencia = T00138_A465EmpresaAgencia[0];
            n465EmpresaAgencia = T00138_n465EmpresaAgencia[0];
            A466EmpresaAgenciaDigito = T00138_A466EmpresaAgenciaDigito[0];
            n466EmpresaAgenciaDigito = T00138_n466EmpresaAgenciaDigito[0];
            A467EmpresaConta = T00138_A467EmpresaConta[0];
            n467EmpresaConta = T00138_n467EmpresaConta[0];
            A468EmpresaPix = T00138_A468EmpresaPix[0];
            n468EmpresaPix = T00138_n468EmpresaPix[0];
            A469EmpresaPixTipo = T00138_A469EmpresaPixTipo[0];
            n469EmpresaPixTipo = T00138_n469EmpresaPixTipo[0];
            A470EmpresaEmail = T00138_A470EmpresaEmail[0];
            n470EmpresaEmail = T00138_n470EmpresaEmail[0];
            A610EmpresaLogradouro = T00138_A610EmpresaLogradouro[0];
            n610EmpresaLogradouro = T00138_n610EmpresaLogradouro[0];
            A611EmpresaLogradouroNumero = T00138_A611EmpresaLogradouroNumero[0];
            n611EmpresaLogradouroNumero = T00138_n611EmpresaLogradouroNumero[0];
            A609EmpresaCEP = T00138_A609EmpresaCEP[0];
            n609EmpresaCEP = T00138_n609EmpresaCEP[0];
            A612EmpresaBairro = T00138_A612EmpresaBairro[0];
            n612EmpresaBairro = T00138_n612EmpresaBairro[0];
            A613EmpresaComplemento = T00138_A613EmpresaComplemento[0];
            n613EmpresaComplemento = T00138_n613EmpresaComplemento[0];
            A187MunicipioNome = T00138_A187MunicipioNome[0];
            n187MunicipioNome = T00138_n187MunicipioNome[0];
            A189MunicipioUF = T00138_A189MunicipioUF[0];
            n189MunicipioUF = T00138_n189MunicipioUF[0];
            A770EmpresaRepresentanteCPF = T00138_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = T00138_n770EmpresaRepresentanteCPF[0];
            A771EmpresaRepresentanteNome = T00138_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = T00138_n771EmpresaRepresentanteNome[0];
            A772EmpresaRepresentanteEmail = T00138_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = T00138_n772EmpresaRepresentanteEmail[0];
            A773EmpresaUtilizaRepresentanteAssinatura = T00138_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = T00138_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A928EmpresaRepresentanteLogradouro = T00138_A928EmpresaRepresentanteLogradouro[0];
            n928EmpresaRepresentanteLogradouro = T00138_n928EmpresaRepresentanteLogradouro[0];
            A929EmpresaRepresentanteNumero = T00138_A929EmpresaRepresentanteNumero[0];
            n929EmpresaRepresentanteNumero = T00138_n929EmpresaRepresentanteNumero[0];
            A930EmpresaRepresentanteCEP = T00138_A930EmpresaRepresentanteCEP[0];
            n930EmpresaRepresentanteCEP = T00138_n930EmpresaRepresentanteCEP[0];
            A931EmpresaRepresentanteBairro = T00138_A931EmpresaRepresentanteBairro[0];
            n931EmpresaRepresentanteBairro = T00138_n931EmpresaRepresentanteBairro[0];
            A932EmpresaRepresentanteComplemento = T00138_A932EmpresaRepresentanteComplemento[0];
            n932EmpresaRepresentanteComplemento = T00138_n932EmpresaRepresentanteComplemento[0];
            A926EmpresaRepresentanteMunicipioNome = T00138_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = T00138_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = T00138_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = T00138_n927EmpresaRepresentanteMunicipioUF[0];
            A933EmpresaRepresentanteNacionalidade = T00138_A933EmpresaRepresentanteNacionalidade[0];
            n933EmpresaRepresentanteNacionalidade = T00138_n933EmpresaRepresentanteNacionalidade[0];
            A934EmpresaRepresentanteTelefone = T00138_A934EmpresaRepresentanteTelefone[0];
            n934EmpresaRepresentanteTelefone = T00138_n934EmpresaRepresentanteTelefone[0];
            A935EmpresaRepresentanteTelefoneDDD = T00138_A935EmpresaRepresentanteTelefoneDDD[0];
            n935EmpresaRepresentanteTelefoneDDD = T00138_n935EmpresaRepresentanteTelefoneDDD[0];
            A186MunicipioCodigo = T00138_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T00138_n186MunicipioCodigo[0];
            A925EmpresaRepresentanteMunicipio = T00138_A925EmpresaRepresentanteMunicipio[0];
            n925EmpresaRepresentanteMunicipio = T00138_n925EmpresaRepresentanteMunicipio[0];
            A464EmpresaBancoId = T00138_A464EmpresaBancoId[0];
            n464EmpresaBancoId = T00138_n464EmpresaBancoId[0];
            A924EmpresaRepresentanteProfissao = T00138_A924EmpresaRepresentanteProfissao[0];
            n924EmpresaRepresentanteProfissao = T00138_n924EmpresaRepresentanteProfissao[0];
            ZM1342( -13) ;
         }
         pr_default.close(6);
         OnLoadActions1342( ) ;
      }

      protected void OnLoadActions1342( )
      {
      }

      protected void CheckExtendedTable1342( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00134 */
         pr_default.execute(2, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
            }
         }
         A187MunicipioNome = T00134_A187MunicipioNome[0];
         n187MunicipioNome = T00134_n187MunicipioNome[0];
         A189MunicipioUF = T00134_A189MunicipioUF[0];
         n189MunicipioUF = T00134_n189MunicipioUF[0];
         pr_default.close(2);
         /* Using cursor T00135 */
         pr_default.execute(3, new Object[] {n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Representante Municipio'.", "ForeignKeyNotFound", 1, "EMPRESAREPRESENTANTEMUNICIPIO");
               AnyError = 1;
            }
         }
         A926EmpresaRepresentanteMunicipioNome = T00135_A926EmpresaRepresentanteMunicipioNome[0];
         n926EmpresaRepresentanteMunicipioNome = T00135_n926EmpresaRepresentanteMunicipioNome[0];
         A927EmpresaRepresentanteMunicipioUF = T00135_A927EmpresaRepresentanteMunicipioUF[0];
         n927EmpresaRepresentanteMunicipioUF = T00135_n927EmpresaRepresentanteMunicipioUF[0];
         pr_default.close(3);
         /* Using cursor T00136 */
         pr_default.execute(4, new Object[] {n464EmpresaBancoId, A464EmpresaBancoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A464EmpresaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Banco'.", "ForeignKeyNotFound", 1, "EMPRESABANCOID");
               AnyError = 1;
            }
         }
         A403BancoNome = T00136_A403BancoNome[0];
         n403BancoNome = T00136_n403BancoNome[0];
         pr_default.close(4);
         /* Using cursor T00137 */
         pr_default.execute(5, new Object[] {n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A924EmpresaRepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Representante Profissao'.", "ForeignKeyNotFound", 1, "EMPRESAREPRESENTANTEPROFISSAO");
               AnyError = 1;
            }
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1342( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( string A186MunicipioCodigo )
      {
         /* Using cursor T00139 */
         pr_default.execute(7, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
            }
         }
         A187MunicipioNome = T00139_A187MunicipioNome[0];
         n187MunicipioNome = T00139_n187MunicipioNome[0];
         A189MunicipioUF = T00139_A189MunicipioUF[0];
         n189MunicipioUF = T00139_n189MunicipioUF[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A187MunicipioNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A189MunicipioUF)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_15( string A925EmpresaRepresentanteMunicipio )
      {
         /* Using cursor T001310 */
         pr_default.execute(8, new Object[] {n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Representante Municipio'.", "ForeignKeyNotFound", 1, "EMPRESAREPRESENTANTEMUNICIPIO");
               AnyError = 1;
            }
         }
         A926EmpresaRepresentanteMunicipioNome = T001310_A926EmpresaRepresentanteMunicipioNome[0];
         n926EmpresaRepresentanteMunicipioNome = T001310_n926EmpresaRepresentanteMunicipioNome[0];
         A927EmpresaRepresentanteMunicipioUF = T001310_A927EmpresaRepresentanteMunicipioUF[0];
         n927EmpresaRepresentanteMunicipioUF = T001310_n927EmpresaRepresentanteMunicipioUF[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A926EmpresaRepresentanteMunicipioNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A927EmpresaRepresentanteMunicipioUF)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_16( int A464EmpresaBancoId )
      {
         /* Using cursor T001311 */
         pr_default.execute(9, new Object[] {n464EmpresaBancoId, A464EmpresaBancoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A464EmpresaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Banco'.", "ForeignKeyNotFound", 1, "EMPRESABANCOID");
               AnyError = 1;
            }
         }
         A403BancoNome = T001311_A403BancoNome[0];
         n403BancoNome = T001311_n403BancoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A403BancoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_17( int A924EmpresaRepresentanteProfissao )
      {
         /* Using cursor T001312 */
         pr_default.execute(10, new Object[] {n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A924EmpresaRepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Representante Profissao'.", "ForeignKeyNotFound", 1, "EMPRESAREPRESENTANTEPROFISSAO");
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

      protected void GetKey1342( )
      {
         /* Using cursor T001313 */
         pr_default.execute(11, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00133 */
         pr_default.execute(1, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1342( 13) ;
            RcdFound42 = 1;
            A249EmpresaId = T00133_A249EmpresaId[0];
            AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
            A250EmpresaNomeFantasia = T00133_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = T00133_n250EmpresaNomeFantasia[0];
            AssignAttri("", false, "A250EmpresaNomeFantasia", A250EmpresaNomeFantasia);
            A251EmpresaRazaoSocial = T00133_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = T00133_n251EmpresaRazaoSocial[0];
            AssignAttri("", false, "A251EmpresaRazaoSocial", A251EmpresaRazaoSocial);
            A252EmpresaCNPJ = T00133_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = T00133_n252EmpresaCNPJ[0];
            AssignAttri("", false, "A252EmpresaCNPJ", A252EmpresaCNPJ);
            A253EmpresaSede = T00133_A253EmpresaSede[0];
            n253EmpresaSede = T00133_n253EmpresaSede[0];
            A465EmpresaAgencia = T00133_A465EmpresaAgencia[0];
            n465EmpresaAgencia = T00133_n465EmpresaAgencia[0];
            A466EmpresaAgenciaDigito = T00133_A466EmpresaAgenciaDigito[0];
            n466EmpresaAgenciaDigito = T00133_n466EmpresaAgenciaDigito[0];
            A467EmpresaConta = T00133_A467EmpresaConta[0];
            n467EmpresaConta = T00133_n467EmpresaConta[0];
            A468EmpresaPix = T00133_A468EmpresaPix[0];
            n468EmpresaPix = T00133_n468EmpresaPix[0];
            A469EmpresaPixTipo = T00133_A469EmpresaPixTipo[0];
            n469EmpresaPixTipo = T00133_n469EmpresaPixTipo[0];
            A470EmpresaEmail = T00133_A470EmpresaEmail[0];
            n470EmpresaEmail = T00133_n470EmpresaEmail[0];
            A610EmpresaLogradouro = T00133_A610EmpresaLogradouro[0];
            n610EmpresaLogradouro = T00133_n610EmpresaLogradouro[0];
            A611EmpresaLogradouroNumero = T00133_A611EmpresaLogradouroNumero[0];
            n611EmpresaLogradouroNumero = T00133_n611EmpresaLogradouroNumero[0];
            A609EmpresaCEP = T00133_A609EmpresaCEP[0];
            n609EmpresaCEP = T00133_n609EmpresaCEP[0];
            A612EmpresaBairro = T00133_A612EmpresaBairro[0];
            n612EmpresaBairro = T00133_n612EmpresaBairro[0];
            A613EmpresaComplemento = T00133_A613EmpresaComplemento[0];
            n613EmpresaComplemento = T00133_n613EmpresaComplemento[0];
            A770EmpresaRepresentanteCPF = T00133_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = T00133_n770EmpresaRepresentanteCPF[0];
            A771EmpresaRepresentanteNome = T00133_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = T00133_n771EmpresaRepresentanteNome[0];
            A772EmpresaRepresentanteEmail = T00133_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = T00133_n772EmpresaRepresentanteEmail[0];
            A773EmpresaUtilizaRepresentanteAssinatura = T00133_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = T00133_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A928EmpresaRepresentanteLogradouro = T00133_A928EmpresaRepresentanteLogradouro[0];
            n928EmpresaRepresentanteLogradouro = T00133_n928EmpresaRepresentanteLogradouro[0];
            A929EmpresaRepresentanteNumero = T00133_A929EmpresaRepresentanteNumero[0];
            n929EmpresaRepresentanteNumero = T00133_n929EmpresaRepresentanteNumero[0];
            A930EmpresaRepresentanteCEP = T00133_A930EmpresaRepresentanteCEP[0];
            n930EmpresaRepresentanteCEP = T00133_n930EmpresaRepresentanteCEP[0];
            A931EmpresaRepresentanteBairro = T00133_A931EmpresaRepresentanteBairro[0];
            n931EmpresaRepresentanteBairro = T00133_n931EmpresaRepresentanteBairro[0];
            A932EmpresaRepresentanteComplemento = T00133_A932EmpresaRepresentanteComplemento[0];
            n932EmpresaRepresentanteComplemento = T00133_n932EmpresaRepresentanteComplemento[0];
            A933EmpresaRepresentanteNacionalidade = T00133_A933EmpresaRepresentanteNacionalidade[0];
            n933EmpresaRepresentanteNacionalidade = T00133_n933EmpresaRepresentanteNacionalidade[0];
            A934EmpresaRepresentanteTelefone = T00133_A934EmpresaRepresentanteTelefone[0];
            n934EmpresaRepresentanteTelefone = T00133_n934EmpresaRepresentanteTelefone[0];
            A935EmpresaRepresentanteTelefoneDDD = T00133_A935EmpresaRepresentanteTelefoneDDD[0];
            n935EmpresaRepresentanteTelefoneDDD = T00133_n935EmpresaRepresentanteTelefoneDDD[0];
            A186MunicipioCodigo = T00133_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T00133_n186MunicipioCodigo[0];
            A925EmpresaRepresentanteMunicipio = T00133_A925EmpresaRepresentanteMunicipio[0];
            n925EmpresaRepresentanteMunicipio = T00133_n925EmpresaRepresentanteMunicipio[0];
            A464EmpresaBancoId = T00133_A464EmpresaBancoId[0];
            n464EmpresaBancoId = T00133_n464EmpresaBancoId[0];
            A924EmpresaRepresentanteProfissao = T00133_A924EmpresaRepresentanteProfissao[0];
            n924EmpresaRepresentanteProfissao = T00133_n924EmpresaRepresentanteProfissao[0];
            Z249EmpresaId = A249EmpresaId;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1342( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey1342( ) ;
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1342( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1342( ) ;
         if ( RcdFound42 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound42 = 0;
         /* Using cursor T001314 */
         pr_default.execute(12, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T001314_A249EmpresaId[0] < A249EmpresaId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T001314_A249EmpresaId[0] > A249EmpresaId ) ) )
            {
               A249EmpresaId = T001314_A249EmpresaId[0];
               AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound42 = 0;
         /* Using cursor T001315 */
         pr_default.execute(13, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T001315_A249EmpresaId[0] > A249EmpresaId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T001315_A249EmpresaId[0] < A249EmpresaId ) ) )
            {
               A249EmpresaId = T001315_A249EmpresaId[0];
               AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1342( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1342( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A249EmpresaId != Z249EmpresaId )
               {
                  A249EmpresaId = Z249EmpresaId;
                  AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPRESAID");
                  AnyError = 1;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1342( ) ;
                  GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A249EmpresaId != Z249EmpresaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1342( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPRESAID");
                     AnyError = 1;
                     GX_FocusControl = edtEmpresaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1342( ) ;
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
         if ( A249EmpresaId != Z249EmpresaId )
         {
            A249EmpresaId = Z249EmpresaId;
            AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmpresaNomeFantasia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1342( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00132 */
            pr_default.execute(0, new Object[] {A249EmpresaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empresa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z250EmpresaNomeFantasia, T00132_A250EmpresaNomeFantasia[0]) != 0 ) || ( StringUtil.StrCmp(Z251EmpresaRazaoSocial, T00132_A251EmpresaRazaoSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z252EmpresaCNPJ, T00132_A252EmpresaCNPJ[0]) != 0 ) || ( Z253EmpresaSede != T00132_A253EmpresaSede[0] ) || ( Z465EmpresaAgencia != T00132_A465EmpresaAgencia[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z466EmpresaAgenciaDigito != T00132_A466EmpresaAgenciaDigito[0] ) || ( Z467EmpresaConta != T00132_A467EmpresaConta[0] ) || ( StringUtil.StrCmp(Z468EmpresaPix, T00132_A468EmpresaPix[0]) != 0 ) || ( StringUtil.StrCmp(Z469EmpresaPixTipo, T00132_A469EmpresaPixTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z470EmpresaEmail, T00132_A470EmpresaEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z610EmpresaLogradouro, T00132_A610EmpresaLogradouro[0]) != 0 ) || ( Z611EmpresaLogradouroNumero != T00132_A611EmpresaLogradouroNumero[0] ) || ( StringUtil.StrCmp(Z609EmpresaCEP, T00132_A609EmpresaCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z612EmpresaBairro, T00132_A612EmpresaBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z613EmpresaComplemento, T00132_A613EmpresaComplemento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z770EmpresaRepresentanteCPF, T00132_A770EmpresaRepresentanteCPF[0]) != 0 ) || ( StringUtil.StrCmp(Z771EmpresaRepresentanteNome, T00132_A771EmpresaRepresentanteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z772EmpresaRepresentanteEmail, T00132_A772EmpresaRepresentanteEmail[0]) != 0 ) || ( Z773EmpresaUtilizaRepresentanteAssinatura != T00132_A773EmpresaUtilizaRepresentanteAssinatura[0] ) || ( StringUtil.StrCmp(Z928EmpresaRepresentanteLogradouro, T00132_A928EmpresaRepresentanteLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z929EmpresaRepresentanteNumero != T00132_A929EmpresaRepresentanteNumero[0] ) || ( StringUtil.StrCmp(Z930EmpresaRepresentanteCEP, T00132_A930EmpresaRepresentanteCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z931EmpresaRepresentanteBairro, T00132_A931EmpresaRepresentanteBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z932EmpresaRepresentanteComplemento, T00132_A932EmpresaRepresentanteComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z933EmpresaRepresentanteNacionalidade, T00132_A933EmpresaRepresentanteNacionalidade[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z934EmpresaRepresentanteTelefone != T00132_A934EmpresaRepresentanteTelefone[0] ) || ( Z935EmpresaRepresentanteTelefoneDDD != T00132_A935EmpresaRepresentanteTelefoneDDD[0] ) || ( StringUtil.StrCmp(Z186MunicipioCodigo, T00132_A186MunicipioCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z925EmpresaRepresentanteMunicipio, T00132_A925EmpresaRepresentanteMunicipio[0]) != 0 ) || ( Z464EmpresaBancoId != T00132_A464EmpresaBancoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z924EmpresaRepresentanteProfissao != T00132_A924EmpresaRepresentanteProfissao[0] ) )
            {
               if ( StringUtil.StrCmp(Z250EmpresaNomeFantasia, T00132_A250EmpresaNomeFantasia[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaNomeFantasia");
                  GXUtil.WriteLogRaw("Old: ",Z250EmpresaNomeFantasia);
                  GXUtil.WriteLogRaw("Current: ",T00132_A250EmpresaNomeFantasia[0]);
               }
               if ( StringUtil.StrCmp(Z251EmpresaRazaoSocial, T00132_A251EmpresaRazaoSocial[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRazaoSocial");
                  GXUtil.WriteLogRaw("Old: ",Z251EmpresaRazaoSocial);
                  GXUtil.WriteLogRaw("Current: ",T00132_A251EmpresaRazaoSocial[0]);
               }
               if ( StringUtil.StrCmp(Z252EmpresaCNPJ, T00132_A252EmpresaCNPJ[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaCNPJ");
                  GXUtil.WriteLogRaw("Old: ",Z252EmpresaCNPJ);
                  GXUtil.WriteLogRaw("Current: ",T00132_A252EmpresaCNPJ[0]);
               }
               if ( Z253EmpresaSede != T00132_A253EmpresaSede[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaSede");
                  GXUtil.WriteLogRaw("Old: ",Z253EmpresaSede);
                  GXUtil.WriteLogRaw("Current: ",T00132_A253EmpresaSede[0]);
               }
               if ( Z465EmpresaAgencia != T00132_A465EmpresaAgencia[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaAgencia");
                  GXUtil.WriteLogRaw("Old: ",Z465EmpresaAgencia);
                  GXUtil.WriteLogRaw("Current: ",T00132_A465EmpresaAgencia[0]);
               }
               if ( Z466EmpresaAgenciaDigito != T00132_A466EmpresaAgenciaDigito[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaAgenciaDigito");
                  GXUtil.WriteLogRaw("Old: ",Z466EmpresaAgenciaDigito);
                  GXUtil.WriteLogRaw("Current: ",T00132_A466EmpresaAgenciaDigito[0]);
               }
               if ( Z467EmpresaConta != T00132_A467EmpresaConta[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaConta");
                  GXUtil.WriteLogRaw("Old: ",Z467EmpresaConta);
                  GXUtil.WriteLogRaw("Current: ",T00132_A467EmpresaConta[0]);
               }
               if ( StringUtil.StrCmp(Z468EmpresaPix, T00132_A468EmpresaPix[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaPix");
                  GXUtil.WriteLogRaw("Old: ",Z468EmpresaPix);
                  GXUtil.WriteLogRaw("Current: ",T00132_A468EmpresaPix[0]);
               }
               if ( StringUtil.StrCmp(Z469EmpresaPixTipo, T00132_A469EmpresaPixTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaPixTipo");
                  GXUtil.WriteLogRaw("Old: ",Z469EmpresaPixTipo);
                  GXUtil.WriteLogRaw("Current: ",T00132_A469EmpresaPixTipo[0]);
               }
               if ( StringUtil.StrCmp(Z470EmpresaEmail, T00132_A470EmpresaEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaEmail");
                  GXUtil.WriteLogRaw("Old: ",Z470EmpresaEmail);
                  GXUtil.WriteLogRaw("Current: ",T00132_A470EmpresaEmail[0]);
               }
               if ( StringUtil.StrCmp(Z610EmpresaLogradouro, T00132_A610EmpresaLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z610EmpresaLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T00132_A610EmpresaLogradouro[0]);
               }
               if ( Z611EmpresaLogradouroNumero != T00132_A611EmpresaLogradouroNumero[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaLogradouroNumero");
                  GXUtil.WriteLogRaw("Old: ",Z611EmpresaLogradouroNumero);
                  GXUtil.WriteLogRaw("Current: ",T00132_A611EmpresaLogradouroNumero[0]);
               }
               if ( StringUtil.StrCmp(Z609EmpresaCEP, T00132_A609EmpresaCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaCEP");
                  GXUtil.WriteLogRaw("Old: ",Z609EmpresaCEP);
                  GXUtil.WriteLogRaw("Current: ",T00132_A609EmpresaCEP[0]);
               }
               if ( StringUtil.StrCmp(Z612EmpresaBairro, T00132_A612EmpresaBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaBairro");
                  GXUtil.WriteLogRaw("Old: ",Z612EmpresaBairro);
                  GXUtil.WriteLogRaw("Current: ",T00132_A612EmpresaBairro[0]);
               }
               if ( StringUtil.StrCmp(Z613EmpresaComplemento, T00132_A613EmpresaComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z613EmpresaComplemento);
                  GXUtil.WriteLogRaw("Current: ",T00132_A613EmpresaComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z770EmpresaRepresentanteCPF, T00132_A770EmpresaRepresentanteCPF[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteCPF");
                  GXUtil.WriteLogRaw("Old: ",Z770EmpresaRepresentanteCPF);
                  GXUtil.WriteLogRaw("Current: ",T00132_A770EmpresaRepresentanteCPF[0]);
               }
               if ( StringUtil.StrCmp(Z771EmpresaRepresentanteNome, T00132_A771EmpresaRepresentanteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteNome");
                  GXUtil.WriteLogRaw("Old: ",Z771EmpresaRepresentanteNome);
                  GXUtil.WriteLogRaw("Current: ",T00132_A771EmpresaRepresentanteNome[0]);
               }
               if ( StringUtil.StrCmp(Z772EmpresaRepresentanteEmail, T00132_A772EmpresaRepresentanteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z772EmpresaRepresentanteEmail);
                  GXUtil.WriteLogRaw("Current: ",T00132_A772EmpresaRepresentanteEmail[0]);
               }
               if ( Z773EmpresaUtilizaRepresentanteAssinatura != T00132_A773EmpresaUtilizaRepresentanteAssinatura[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaUtilizaRepresentanteAssinatura");
                  GXUtil.WriteLogRaw("Old: ",Z773EmpresaUtilizaRepresentanteAssinatura);
                  GXUtil.WriteLogRaw("Current: ",T00132_A773EmpresaUtilizaRepresentanteAssinatura[0]);
               }
               if ( StringUtil.StrCmp(Z928EmpresaRepresentanteLogradouro, T00132_A928EmpresaRepresentanteLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z928EmpresaRepresentanteLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T00132_A928EmpresaRepresentanteLogradouro[0]);
               }
               if ( Z929EmpresaRepresentanteNumero != T00132_A929EmpresaRepresentanteNumero[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteNumero");
                  GXUtil.WriteLogRaw("Old: ",Z929EmpresaRepresentanteNumero);
                  GXUtil.WriteLogRaw("Current: ",T00132_A929EmpresaRepresentanteNumero[0]);
               }
               if ( StringUtil.StrCmp(Z930EmpresaRepresentanteCEP, T00132_A930EmpresaRepresentanteCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteCEP");
                  GXUtil.WriteLogRaw("Old: ",Z930EmpresaRepresentanteCEP);
                  GXUtil.WriteLogRaw("Current: ",T00132_A930EmpresaRepresentanteCEP[0]);
               }
               if ( StringUtil.StrCmp(Z931EmpresaRepresentanteBairro, T00132_A931EmpresaRepresentanteBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteBairro");
                  GXUtil.WriteLogRaw("Old: ",Z931EmpresaRepresentanteBairro);
                  GXUtil.WriteLogRaw("Current: ",T00132_A931EmpresaRepresentanteBairro[0]);
               }
               if ( StringUtil.StrCmp(Z932EmpresaRepresentanteComplemento, T00132_A932EmpresaRepresentanteComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z932EmpresaRepresentanteComplemento);
                  GXUtil.WriteLogRaw("Current: ",T00132_A932EmpresaRepresentanteComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z933EmpresaRepresentanteNacionalidade, T00132_A933EmpresaRepresentanteNacionalidade[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteNacionalidade");
                  GXUtil.WriteLogRaw("Old: ",Z933EmpresaRepresentanteNacionalidade);
                  GXUtil.WriteLogRaw("Current: ",T00132_A933EmpresaRepresentanteNacionalidade[0]);
               }
               if ( Z934EmpresaRepresentanteTelefone != T00132_A934EmpresaRepresentanteTelefone[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteTelefone");
                  GXUtil.WriteLogRaw("Old: ",Z934EmpresaRepresentanteTelefone);
                  GXUtil.WriteLogRaw("Current: ",T00132_A934EmpresaRepresentanteTelefone[0]);
               }
               if ( Z935EmpresaRepresentanteTelefoneDDD != T00132_A935EmpresaRepresentanteTelefoneDDD[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteTelefoneDDD");
                  GXUtil.WriteLogRaw("Old: ",Z935EmpresaRepresentanteTelefoneDDD);
                  GXUtil.WriteLogRaw("Current: ",T00132_A935EmpresaRepresentanteTelefoneDDD[0]);
               }
               if ( StringUtil.StrCmp(Z186MunicipioCodigo, T00132_A186MunicipioCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"MunicipioCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z186MunicipioCodigo);
                  GXUtil.WriteLogRaw("Current: ",T00132_A186MunicipioCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z925EmpresaRepresentanteMunicipio, T00132_A925EmpresaRepresentanteMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z925EmpresaRepresentanteMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T00132_A925EmpresaRepresentanteMunicipio[0]);
               }
               if ( Z464EmpresaBancoId != T00132_A464EmpresaBancoId[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaBancoId");
                  GXUtil.WriteLogRaw("Old: ",Z464EmpresaBancoId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A464EmpresaBancoId[0]);
               }
               if ( Z924EmpresaRepresentanteProfissao != T00132_A924EmpresaRepresentanteProfissao[0] )
               {
                  GXUtil.WriteLog("empresa:[seudo value changed for attri]"+"EmpresaRepresentanteProfissao");
                  GXUtil.WriteLogRaw("Old: ",Z924EmpresaRepresentanteProfissao);
                  GXUtil.WriteLogRaw("Current: ",T00132_A924EmpresaRepresentanteProfissao[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Empresa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1342( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1342( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1342( 0) ;
            CheckOptimisticConcurrency1342( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1342( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1342( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001316 */
                     pr_default.execute(14, new Object[] {n250EmpresaNomeFantasia, A250EmpresaNomeFantasia, n251EmpresaRazaoSocial, A251EmpresaRazaoSocial, n252EmpresaCNPJ, A252EmpresaCNPJ, n253EmpresaSede, A253EmpresaSede, n465EmpresaAgencia, A465EmpresaAgencia, n466EmpresaAgenciaDigito, A466EmpresaAgenciaDigito, n467EmpresaConta, A467EmpresaConta, n468EmpresaPix, A468EmpresaPix, n469EmpresaPixTipo, A469EmpresaPixTipo, n470EmpresaEmail, A470EmpresaEmail, n610EmpresaLogradouro, A610EmpresaLogradouro, n611EmpresaLogradouroNumero, A611EmpresaLogradouroNumero, n609EmpresaCEP, A609EmpresaCEP, n612EmpresaBairro, A612EmpresaBairro, n613EmpresaComplemento, A613EmpresaComplemento, n770EmpresaRepresentanteCPF, A770EmpresaRepresentanteCPF, n771EmpresaRepresentanteNome, A771EmpresaRepresentanteNome, n772EmpresaRepresentanteEmail, A772EmpresaRepresentanteEmail, n773EmpresaUtilizaRepresentanteAssinatura, A773EmpresaUtilizaRepresentanteAssinatura, n928EmpresaRepresentanteLogradouro, A928EmpresaRepresentanteLogradouro, n929EmpresaRepresentanteNumero, A929EmpresaRepresentanteNumero, n930EmpresaRepresentanteCEP, A930EmpresaRepresentanteCEP, n931EmpresaRepresentanteBairro, A931EmpresaRepresentanteBairro, n932EmpresaRepresentanteComplemento, A932EmpresaRepresentanteComplemento, n933EmpresaRepresentanteNacionalidade, A933EmpresaRepresentanteNacionalidade, n934EmpresaRepresentanteTelefone, A934EmpresaRepresentanteTelefone, n935EmpresaRepresentanteTelefoneDDD, A935EmpresaRepresentanteTelefoneDDD, n186MunicipioCodigo, A186MunicipioCodigo, n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio, n464EmpresaBancoId, A464EmpresaBancoId, n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001317 */
                     pr_default.execute(15);
                     A249EmpresaId = T001317_A249EmpresaId[0];
                     AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Empresa");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption130( ) ;
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
               Load1342( ) ;
            }
            EndLevel1342( ) ;
         }
         CloseExtendedTableCursors1342( ) ;
      }

      protected void Update1342( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1342( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1342( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1342( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1342( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001318 */
                     pr_default.execute(16, new Object[] {n250EmpresaNomeFantasia, A250EmpresaNomeFantasia, n251EmpresaRazaoSocial, A251EmpresaRazaoSocial, n252EmpresaCNPJ, A252EmpresaCNPJ, n253EmpresaSede, A253EmpresaSede, n465EmpresaAgencia, A465EmpresaAgencia, n466EmpresaAgenciaDigito, A466EmpresaAgenciaDigito, n467EmpresaConta, A467EmpresaConta, n468EmpresaPix, A468EmpresaPix, n469EmpresaPixTipo, A469EmpresaPixTipo, n470EmpresaEmail, A470EmpresaEmail, n610EmpresaLogradouro, A610EmpresaLogradouro, n611EmpresaLogradouroNumero, A611EmpresaLogradouroNumero, n609EmpresaCEP, A609EmpresaCEP, n612EmpresaBairro, A612EmpresaBairro, n613EmpresaComplemento, A613EmpresaComplemento, n770EmpresaRepresentanteCPF, A770EmpresaRepresentanteCPF, n771EmpresaRepresentanteNome, A771EmpresaRepresentanteNome, n772EmpresaRepresentanteEmail, A772EmpresaRepresentanteEmail, n773EmpresaUtilizaRepresentanteAssinatura, A773EmpresaUtilizaRepresentanteAssinatura, n928EmpresaRepresentanteLogradouro, A928EmpresaRepresentanteLogradouro, n929EmpresaRepresentanteNumero, A929EmpresaRepresentanteNumero, n930EmpresaRepresentanteCEP, A930EmpresaRepresentanteCEP, n931EmpresaRepresentanteBairro, A931EmpresaRepresentanteBairro, n932EmpresaRepresentanteComplemento, A932EmpresaRepresentanteComplemento, n933EmpresaRepresentanteNacionalidade, A933EmpresaRepresentanteNacionalidade, n934EmpresaRepresentanteTelefone, A934EmpresaRepresentanteTelefone, n935EmpresaRepresentanteTelefoneDDD, A935EmpresaRepresentanteTelefoneDDD, n186MunicipioCodigo, A186MunicipioCodigo, n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio, n464EmpresaBancoId, A464EmpresaBancoId, n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao, A249EmpresaId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Empresa");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empresa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1342( ) ;
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
            EndLevel1342( ) ;
         }
         CloseExtendedTableCursors1342( ) ;
      }

      protected void DeferredUpdate1342( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1342( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1342( ) ;
            AfterConfirm1342( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1342( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001319 */
                  pr_default.execute(17, new Object[] {A249EmpresaId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("Empresa");
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1342( ) ;
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1342( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001320 */
            pr_default.execute(18, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            A187MunicipioNome = T001320_A187MunicipioNome[0];
            n187MunicipioNome = T001320_n187MunicipioNome[0];
            A189MunicipioUF = T001320_A189MunicipioUF[0];
            n189MunicipioUF = T001320_n189MunicipioUF[0];
            pr_default.close(18);
            /* Using cursor T001321 */
            pr_default.execute(19, new Object[] {n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio});
            A926EmpresaRepresentanteMunicipioNome = T001321_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = T001321_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = T001321_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = T001321_n927EmpresaRepresentanteMunicipioUF[0];
            pr_default.close(19);
            /* Using cursor T001322 */
            pr_default.execute(20, new Object[] {n464EmpresaBancoId, A464EmpresaBancoId});
            A403BancoNome = T001322_A403BancoNome[0];
            n403BancoNome = T001322_n403BancoNome[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel1342( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1342( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues130( ) ;
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

      public void ScanStart1342( )
      {
         /* Scan By routine */
         /* Using cursor T001323 */
         pr_default.execute(21);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound42 = 1;
            A249EmpresaId = T001323_A249EmpresaId[0];
            AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1342( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound42 = 1;
            A249EmpresaId = T001323_A249EmpresaId[0];
            AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
         }
      }

      protected void ScanEnd1342( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1342( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1342( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1342( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1342( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1342( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1342( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1342( )
      {
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtEmpresaNomeFantasia_Enabled = 0;
         AssignProp("", false, edtEmpresaNomeFantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNomeFantasia_Enabled), 5, 0), true);
         edtEmpresaRazaoSocial_Enabled = 0;
         AssignProp("", false, edtEmpresaRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaRazaoSocial_Enabled), 5, 0), true);
         edtEmpresaCNPJ_Enabled = 0;
         AssignProp("", false, edtEmpresaCNPJ_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaCNPJ_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1342( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues130( )
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
         GXEncryptionTmp = "empresa"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("empresa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Empresa");
         forbiddenHiddens.Add("EmpresaId", context.localUtil.Format( (decimal)(A249EmpresaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_EmpresaBancoId", context.localUtil.Format( (decimal)(AV11Insert_EmpresaBancoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_MunicipioCodigo", StringUtil.RTrim( context.localUtil.Format( AV13Insert_MunicipioCodigo, "")));
         forbiddenHiddens.Add("Insert_EmpresaRepresentanteMunicipio", StringUtil.RTrim( context.localUtil.Format( AV14Insert_EmpresaRepresentanteMunicipio, "")));
         forbiddenHiddens.Add("Insert_EmpresaRepresentanteProfissao", context.localUtil.Format( (decimal)(AV15Insert_EmpresaRepresentanteProfissao), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EmpresaSede", StringUtil.BoolToStr( A253EmpresaSede));
         forbiddenHiddens.Add("EmpresaAgencia", context.localUtil.Format( (decimal)(A465EmpresaAgencia), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("EmpresaAgenciaDigito", context.localUtil.Format( (decimal)(A466EmpresaAgenciaDigito), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("EmpresaConta", context.localUtil.Format( (decimal)(A467EmpresaConta), "ZZZZZZZ9"));
         forbiddenHiddens.Add("EmpresaPix", StringUtil.RTrim( context.localUtil.Format( A468EmpresaPix, "")));
         forbiddenHiddens.Add("EmpresaPixTipo", StringUtil.RTrim( context.localUtil.Format( A469EmpresaPixTipo, "")));
         forbiddenHiddens.Add("EmpresaEmail", StringUtil.RTrim( context.localUtil.Format( A470EmpresaEmail, "")));
         forbiddenHiddens.Add("EmpresaLogradouro", StringUtil.RTrim( context.localUtil.Format( A610EmpresaLogradouro, "")));
         forbiddenHiddens.Add("EmpresaLogradouroNumero", context.localUtil.Format( (decimal)(A611EmpresaLogradouroNumero), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("EmpresaCEP", StringUtil.RTrim( context.localUtil.Format( A609EmpresaCEP, "")));
         forbiddenHiddens.Add("EmpresaBairro", StringUtil.RTrim( context.localUtil.Format( A612EmpresaBairro, "")));
         forbiddenHiddens.Add("EmpresaComplemento", StringUtil.RTrim( context.localUtil.Format( A613EmpresaComplemento, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteCPF", StringUtil.RTrim( context.localUtil.Format( A770EmpresaRepresentanteCPF, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteNome", StringUtil.RTrim( context.localUtil.Format( A771EmpresaRepresentanteNome, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteEmail", StringUtil.RTrim( context.localUtil.Format( A772EmpresaRepresentanteEmail, "")));
         forbiddenHiddens.Add("EmpresaUtilizaRepresentanteAssinatura", StringUtil.BoolToStr( A773EmpresaUtilizaRepresentanteAssinatura));
         forbiddenHiddens.Add("EmpresaRepresentanteLogradouro", StringUtil.RTrim( context.localUtil.Format( A928EmpresaRepresentanteLogradouro, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteNumero", context.localUtil.Format( (decimal)(A929EmpresaRepresentanteNumero), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("EmpresaRepresentanteCEP", StringUtil.RTrim( context.localUtil.Format( A930EmpresaRepresentanteCEP, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteBairro", StringUtil.RTrim( context.localUtil.Format( A931EmpresaRepresentanteBairro, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteComplemento", StringUtil.RTrim( context.localUtil.Format( A932EmpresaRepresentanteComplemento, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteNacionalidade", StringUtil.RTrim( context.localUtil.Format( A933EmpresaRepresentanteNacionalidade, "")));
         forbiddenHiddens.Add("EmpresaRepresentanteTelefone", context.localUtil.Format( (decimal)(A934EmpresaRepresentanteTelefone), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("EmpresaRepresentanteTelefoneDDD", context.localUtil.Format( (decimal)(A935EmpresaRepresentanteTelefoneDDD), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("empresa:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z249EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z249EmpresaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z250EmpresaNomeFantasia", Z250EmpresaNomeFantasia);
         GxWebStd.gx_hidden_field( context, "Z251EmpresaRazaoSocial", Z251EmpresaRazaoSocial);
         GxWebStd.gx_hidden_field( context, "Z252EmpresaCNPJ", Z252EmpresaCNPJ);
         GxWebStd.gx_boolean_hidden_field( context, "Z253EmpresaSede", Z253EmpresaSede);
         GxWebStd.gx_hidden_field( context, "Z465EmpresaAgencia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465EmpresaAgencia), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z466EmpresaAgenciaDigito", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466EmpresaAgenciaDigito), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z467EmpresaConta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z467EmpresaConta), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z468EmpresaPix", Z468EmpresaPix);
         GxWebStd.gx_hidden_field( context, "Z469EmpresaPixTipo", Z469EmpresaPixTipo);
         GxWebStd.gx_hidden_field( context, "Z470EmpresaEmail", Z470EmpresaEmail);
         GxWebStd.gx_hidden_field( context, "Z610EmpresaLogradouro", Z610EmpresaLogradouro);
         GxWebStd.gx_hidden_field( context, "Z611EmpresaLogradouroNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z611EmpresaLogradouroNumero), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z609EmpresaCEP", Z609EmpresaCEP);
         GxWebStd.gx_hidden_field( context, "Z612EmpresaBairro", Z612EmpresaBairro);
         GxWebStd.gx_hidden_field( context, "Z613EmpresaComplemento", Z613EmpresaComplemento);
         GxWebStd.gx_hidden_field( context, "Z770EmpresaRepresentanteCPF", Z770EmpresaRepresentanteCPF);
         GxWebStd.gx_hidden_field( context, "Z771EmpresaRepresentanteNome", Z771EmpresaRepresentanteNome);
         GxWebStd.gx_hidden_field( context, "Z772EmpresaRepresentanteEmail", Z772EmpresaRepresentanteEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z773EmpresaUtilizaRepresentanteAssinatura", Z773EmpresaUtilizaRepresentanteAssinatura);
         GxWebStd.gx_hidden_field( context, "Z928EmpresaRepresentanteLogradouro", Z928EmpresaRepresentanteLogradouro);
         GxWebStd.gx_hidden_field( context, "Z929EmpresaRepresentanteNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z929EmpresaRepresentanteNumero), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z930EmpresaRepresentanteCEP", Z930EmpresaRepresentanteCEP);
         GxWebStd.gx_hidden_field( context, "Z931EmpresaRepresentanteBairro", Z931EmpresaRepresentanteBairro);
         GxWebStd.gx_hidden_field( context, "Z932EmpresaRepresentanteComplemento", Z932EmpresaRepresentanteComplemento);
         GxWebStd.gx_hidden_field( context, "Z933EmpresaRepresentanteNacionalidade", Z933EmpresaRepresentanteNacionalidade);
         GxWebStd.gx_hidden_field( context, "Z934EmpresaRepresentanteTelefone", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z934EmpresaRepresentanteTelefone), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z935EmpresaRepresentanteTelefoneDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z935EmpresaRepresentanteTelefoneDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z186MunicipioCodigo", Z186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "Z925EmpresaRepresentanteMunicipio", Z925EmpresaRepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "Z464EmpresaBancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z464EmpresaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z924EmpresaRepresentanteProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z924EmpresaRepresentanteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N464EmpresaBancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A464EmpresaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N186MunicipioCodigo", A186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "N925EmpresaRepresentanteMunicipio", A925EmpresaRepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "N924EmpresaRepresentanteProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(A924EmpresaRepresentanteProfissao), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmpresaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPRESABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EmpresaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A464EmpresaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_MUNICIPIOCODIGO", AV13Insert_MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "MUNICIPIOCODIGO", A186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPRESAREPRESENTANTEMUNICIPIO", AV14Insert_EmpresaRepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTEMUNICIPIO", A925EmpresaRepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPRESAREPRESENTANTEPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_EmpresaRepresentanteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTEPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A924EmpresaRepresentanteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "EMPRESASEDE", A253EmpresaSede);
         GxWebStd.gx_hidden_field( context, "EMPRESAAGENCIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A465EmpresaAgencia), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESAAGENCIADIGITO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A466EmpresaAgenciaDigito), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESACONTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A467EmpresaConta), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESAPIX", A468EmpresaPix);
         GxWebStd.gx_hidden_field( context, "EMPRESAPIXTIPO", A469EmpresaPixTipo);
         GxWebStd.gx_hidden_field( context, "EMPRESAEMAIL", A470EmpresaEmail);
         GxWebStd.gx_hidden_field( context, "EMPRESALOGRADOURO", A610EmpresaLogradouro);
         GxWebStd.gx_hidden_field( context, "EMPRESALOGRADOURONUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A611EmpresaLogradouroNumero), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESACEP", A609EmpresaCEP);
         GxWebStd.gx_hidden_field( context, "EMPRESABAIRRO", A612EmpresaBairro);
         GxWebStd.gx_hidden_field( context, "EMPRESACOMPLEMENTO", A613EmpresaComplemento);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTECPF", A770EmpresaRepresentanteCPF);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTENOME", A771EmpresaRepresentanteNome);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTEEMAIL", A772EmpresaRepresentanteEmail);
         GxWebStd.gx_boolean_hidden_field( context, "EMPRESAUTILIZAREPRESENTANTEASSINATURA", A773EmpresaUtilizaRepresentanteAssinatura);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTELOGRADOURO", A928EmpresaRepresentanteLogradouro);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTENUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A929EmpresaRepresentanteNumero), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTECEP", A930EmpresaRepresentanteCEP);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTEBAIRRO", A931EmpresaRepresentanteBairro);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTECOMPLEMENTO", A932EmpresaRepresentanteComplemento);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTENACIONALIDADE", A933EmpresaRepresentanteNacionalidade);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTETELEFONE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A934EmpresaRepresentanteTelefone), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTETELEFONEDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A935EmpresaRepresentanteTelefoneDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "MUNICIPIONOME", A187MunicipioNome);
         GxWebStd.gx_hidden_field( context, "MUNICIPIOUF", A189MunicipioUF);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTEMUNICIPIONOME", A926EmpresaRepresentanteMunicipioNome);
         GxWebStd.gx_hidden_field( context, "EMPRESAREPRESENTANTEMUNICIPIOUF", A927EmpresaRepresentanteMunicipioUF);
         GxWebStd.gx_hidden_field( context, "BANCONOME", A403BancoNome);
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
         GXEncryptionTmp = "empresa"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,9,0));
         return formatLink("empresa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Empresa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empresa" ;
      }

      protected void InitializeNonKey1342( )
      {
         A464EmpresaBancoId = 0;
         n464EmpresaBancoId = false;
         AssignAttri("", false, "A464EmpresaBancoId", ((0==A464EmpresaBancoId)&&IsIns( )||n464EmpresaBancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A464EmpresaBancoId), 9, 0, ".", ""))));
         A186MunicipioCodigo = "";
         n186MunicipioCodigo = false;
         AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         A925EmpresaRepresentanteMunicipio = "";
         n925EmpresaRepresentanteMunicipio = false;
         AssignAttri("", false, "A925EmpresaRepresentanteMunicipio", A925EmpresaRepresentanteMunicipio);
         A924EmpresaRepresentanteProfissao = 0;
         n924EmpresaRepresentanteProfissao = false;
         AssignAttri("", false, "A924EmpresaRepresentanteProfissao", ((0==A924EmpresaRepresentanteProfissao)&&IsIns( )||n924EmpresaRepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A924EmpresaRepresentanteProfissao), 9, 0, ".", ""))));
         A250EmpresaNomeFantasia = "";
         n250EmpresaNomeFantasia = false;
         AssignAttri("", false, "A250EmpresaNomeFantasia", A250EmpresaNomeFantasia);
         n250EmpresaNomeFantasia = (String.IsNullOrEmpty(StringUtil.RTrim( A250EmpresaNomeFantasia)) ? true : false);
         A251EmpresaRazaoSocial = "";
         n251EmpresaRazaoSocial = false;
         AssignAttri("", false, "A251EmpresaRazaoSocial", A251EmpresaRazaoSocial);
         n251EmpresaRazaoSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A251EmpresaRazaoSocial)) ? true : false);
         A252EmpresaCNPJ = "";
         n252EmpresaCNPJ = false;
         AssignAttri("", false, "A252EmpresaCNPJ", A252EmpresaCNPJ);
         n252EmpresaCNPJ = (String.IsNullOrEmpty(StringUtil.RTrim( A252EmpresaCNPJ)) ? true : false);
         A253EmpresaSede = false;
         n253EmpresaSede = false;
         AssignAttri("", false, "A253EmpresaSede", A253EmpresaSede);
         A403BancoNome = "";
         n403BancoNome = false;
         AssignAttri("", false, "A403BancoNome", A403BancoNome);
         A465EmpresaAgencia = 0;
         n465EmpresaAgencia = false;
         AssignAttri("", false, "A465EmpresaAgencia", ((0==A465EmpresaAgencia)&&IsIns( )||n465EmpresaAgencia ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A465EmpresaAgencia), 9, 0, ".", ""))));
         A466EmpresaAgenciaDigito = 0;
         n466EmpresaAgenciaDigito = false;
         AssignAttri("", false, "A466EmpresaAgenciaDigito", ((0==A466EmpresaAgenciaDigito)&&IsIns( )||n466EmpresaAgenciaDigito ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A466EmpresaAgenciaDigito), 9, 0, ".", ""))));
         A467EmpresaConta = 0;
         n467EmpresaConta = false;
         AssignAttri("", false, "A467EmpresaConta", ((0==A467EmpresaConta)&&IsIns( )||n467EmpresaConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A467EmpresaConta), 8, 0, ".", ""))));
         A468EmpresaPix = "";
         n468EmpresaPix = false;
         AssignAttri("", false, "A468EmpresaPix", A468EmpresaPix);
         A469EmpresaPixTipo = "";
         n469EmpresaPixTipo = false;
         AssignAttri("", false, "A469EmpresaPixTipo", A469EmpresaPixTipo);
         A470EmpresaEmail = "";
         n470EmpresaEmail = false;
         AssignAttri("", false, "A470EmpresaEmail", A470EmpresaEmail);
         A610EmpresaLogradouro = "";
         n610EmpresaLogradouro = false;
         AssignAttri("", false, "A610EmpresaLogradouro", A610EmpresaLogradouro);
         A611EmpresaLogradouroNumero = 0;
         n611EmpresaLogradouroNumero = false;
         AssignAttri("", false, "A611EmpresaLogradouroNumero", ((0==A611EmpresaLogradouroNumero)&&IsIns( )||n611EmpresaLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A611EmpresaLogradouroNumero), 10, 0, ".", ""))));
         A609EmpresaCEP = "";
         n609EmpresaCEP = false;
         AssignAttri("", false, "A609EmpresaCEP", A609EmpresaCEP);
         A612EmpresaBairro = "";
         n612EmpresaBairro = false;
         AssignAttri("", false, "A612EmpresaBairro", A612EmpresaBairro);
         A613EmpresaComplemento = "";
         n613EmpresaComplemento = false;
         AssignAttri("", false, "A613EmpresaComplemento", A613EmpresaComplemento);
         A187MunicipioNome = "";
         n187MunicipioNome = false;
         AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
         A189MunicipioUF = "";
         n189MunicipioUF = false;
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
         A770EmpresaRepresentanteCPF = "";
         n770EmpresaRepresentanteCPF = false;
         AssignAttri("", false, "A770EmpresaRepresentanteCPF", A770EmpresaRepresentanteCPF);
         A771EmpresaRepresentanteNome = "";
         n771EmpresaRepresentanteNome = false;
         AssignAttri("", false, "A771EmpresaRepresentanteNome", A771EmpresaRepresentanteNome);
         A772EmpresaRepresentanteEmail = "";
         n772EmpresaRepresentanteEmail = false;
         AssignAttri("", false, "A772EmpresaRepresentanteEmail", A772EmpresaRepresentanteEmail);
         A773EmpresaUtilizaRepresentanteAssinatura = false;
         n773EmpresaUtilizaRepresentanteAssinatura = false;
         AssignAttri("", false, "A773EmpresaUtilizaRepresentanteAssinatura", A773EmpresaUtilizaRepresentanteAssinatura);
         A928EmpresaRepresentanteLogradouro = "";
         n928EmpresaRepresentanteLogradouro = false;
         AssignAttri("", false, "A928EmpresaRepresentanteLogradouro", A928EmpresaRepresentanteLogradouro);
         A929EmpresaRepresentanteNumero = 0;
         n929EmpresaRepresentanteNumero = false;
         AssignAttri("", false, "A929EmpresaRepresentanteNumero", ((0==A929EmpresaRepresentanteNumero)&&IsIns( )||n929EmpresaRepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A929EmpresaRepresentanteNumero), 10, 0, ".", ""))));
         A930EmpresaRepresentanteCEP = "";
         n930EmpresaRepresentanteCEP = false;
         AssignAttri("", false, "A930EmpresaRepresentanteCEP", A930EmpresaRepresentanteCEP);
         A931EmpresaRepresentanteBairro = "";
         n931EmpresaRepresentanteBairro = false;
         AssignAttri("", false, "A931EmpresaRepresentanteBairro", A931EmpresaRepresentanteBairro);
         A932EmpresaRepresentanteComplemento = "";
         n932EmpresaRepresentanteComplemento = false;
         AssignAttri("", false, "A932EmpresaRepresentanteComplemento", A932EmpresaRepresentanteComplemento);
         A926EmpresaRepresentanteMunicipioNome = "";
         n926EmpresaRepresentanteMunicipioNome = false;
         AssignAttri("", false, "A926EmpresaRepresentanteMunicipioNome", A926EmpresaRepresentanteMunicipioNome);
         A927EmpresaRepresentanteMunicipioUF = "";
         n927EmpresaRepresentanteMunicipioUF = false;
         AssignAttri("", false, "A927EmpresaRepresentanteMunicipioUF", A927EmpresaRepresentanteMunicipioUF);
         A933EmpresaRepresentanteNacionalidade = "";
         n933EmpresaRepresentanteNacionalidade = false;
         AssignAttri("", false, "A933EmpresaRepresentanteNacionalidade", A933EmpresaRepresentanteNacionalidade);
         A934EmpresaRepresentanteTelefone = 0;
         n934EmpresaRepresentanteTelefone = false;
         AssignAttri("", false, "A934EmpresaRepresentanteTelefone", ((0==A934EmpresaRepresentanteTelefone)&&IsIns( )||n934EmpresaRepresentanteTelefone ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A934EmpresaRepresentanteTelefone), 9, 0, ".", ""))));
         A935EmpresaRepresentanteTelefoneDDD = 0;
         n935EmpresaRepresentanteTelefoneDDD = false;
         AssignAttri("", false, "A935EmpresaRepresentanteTelefoneDDD", ((0==A935EmpresaRepresentanteTelefoneDDD)&&IsIns( )||n935EmpresaRepresentanteTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A935EmpresaRepresentanteTelefoneDDD), 4, 0, ".", ""))));
         Z250EmpresaNomeFantasia = "";
         Z251EmpresaRazaoSocial = "";
         Z252EmpresaCNPJ = "";
         Z253EmpresaSede = false;
         Z465EmpresaAgencia = 0;
         Z466EmpresaAgenciaDigito = 0;
         Z467EmpresaConta = 0;
         Z468EmpresaPix = "";
         Z469EmpresaPixTipo = "";
         Z470EmpresaEmail = "";
         Z610EmpresaLogradouro = "";
         Z611EmpresaLogradouroNumero = 0;
         Z609EmpresaCEP = "";
         Z612EmpresaBairro = "";
         Z613EmpresaComplemento = "";
         Z770EmpresaRepresentanteCPF = "";
         Z771EmpresaRepresentanteNome = "";
         Z772EmpresaRepresentanteEmail = "";
         Z773EmpresaUtilizaRepresentanteAssinatura = false;
         Z928EmpresaRepresentanteLogradouro = "";
         Z929EmpresaRepresentanteNumero = 0;
         Z930EmpresaRepresentanteCEP = "";
         Z931EmpresaRepresentanteBairro = "";
         Z932EmpresaRepresentanteComplemento = "";
         Z933EmpresaRepresentanteNacionalidade = "";
         Z934EmpresaRepresentanteTelefone = 0;
         Z935EmpresaRepresentanteTelefoneDDD = 0;
         Z186MunicipioCodigo = "";
         Z925EmpresaRepresentanteMunicipio = "";
         Z464EmpresaBancoId = 0;
         Z924EmpresaRepresentanteProfissao = 0;
      }

      protected void InitAll1342( )
      {
         A249EmpresaId = 0;
         AssignAttri("", false, "A249EmpresaId", StringUtil.LTrimStr( (decimal)(A249EmpresaId), 9, 0));
         InitializeNonKey1342( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101914287", true, true);
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
         context.AddJavascriptSource("empresa.js", "?20256101914288", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtEmpresaId_Internalname = "EMPRESAID";
         edtEmpresaNomeFantasia_Internalname = "EMPRESANOMEFANTASIA";
         edtEmpresaRazaoSocial_Internalname = "EMPRESARAZAOSOCIAL";
         edtEmpresaCNPJ_Internalname = "EMPRESACNPJ";
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
         Form.Caption = "Empresa";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtEmpresaCNPJ_Jsonclick = "";
         edtEmpresaCNPJ_Enabled = 1;
         edtEmpresaRazaoSocial_Jsonclick = "";
         edtEmpresaRazaoSocial_Enabled = 1;
         edtEmpresaNomeFantasia_Jsonclick = "";
         edtEmpresaNomeFantasia_Enabled = 1;
         edtEmpresaId_Jsonclick = "";
         edtEmpresaId_Enabled = 0;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A249EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_EmpresaBancoId","fld":"vINSERT_EMPRESABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13Insert_MunicipioCodigo","fld":"vINSERT_MUNICIPIOCODIGO","type":"svchar"},{"av":"AV14Insert_EmpresaRepresentanteMunicipio","fld":"vINSERT_EMPRESAREPRESENTANTEMUNICIPIO","type":"svchar"},{"av":"AV15Insert_EmpresaRepresentanteProfissao","fld":"vINSERT_EMPRESAREPRESENTANTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A253EmpresaSede","fld":"EMPRESASEDE","type":"boolean"},{"av":"A465EmpresaAgencia","fld":"EMPRESAAGENCIA","pic":"ZZZZZZZZ9","nullAv":"n465EmpresaAgencia","type":"int"},{"av":"A466EmpresaAgenciaDigito","fld":"EMPRESAAGENCIADIGITO","pic":"ZZZZZZZZ9","nullAv":"n466EmpresaAgenciaDigito","type":"int"},{"av":"A467EmpresaConta","fld":"EMPRESACONTA","pic":"ZZZZZZZ9","nullAv":"n467EmpresaConta","type":"int"},{"av":"A468EmpresaPix","fld":"EMPRESAPIX","type":"svchar"},{"av":"A469EmpresaPixTipo","fld":"EMPRESAPIXTIPO","type":"svchar"},{"av":"A470EmpresaEmail","fld":"EMPRESAEMAIL","type":"svchar"},{"av":"A610EmpresaLogradouro","fld":"EMPRESALOGRADOURO","type":"svchar"},{"av":"A611EmpresaLogradouroNumero","fld":"EMPRESALOGRADOURONUMERO","pic":"ZZZZZZZZZ9","nullAv":"n611EmpresaLogradouroNumero","type":"int"},{"av":"A609EmpresaCEP","fld":"EMPRESACEP","type":"svchar"},{"av":"A612EmpresaBairro","fld":"EMPRESABAIRRO","type":"svchar"},{"av":"A613EmpresaComplemento","fld":"EMPRESACOMPLEMENTO","type":"svchar"},{"av":"A770EmpresaRepresentanteCPF","fld":"EMPRESAREPRESENTANTECPF","type":"svchar"},{"av":"A771EmpresaRepresentanteNome","fld":"EMPRESAREPRESENTANTENOME","type":"svchar"},{"av":"A772EmpresaRepresentanteEmail","fld":"EMPRESAREPRESENTANTEEMAIL","type":"svchar"},{"av":"A773EmpresaUtilizaRepresentanteAssinatura","fld":"EMPRESAUTILIZAREPRESENTANTEASSINATURA","type":"boolean"},{"av":"A928EmpresaRepresentanteLogradouro","fld":"EMPRESAREPRESENTANTELOGRADOURO","type":"svchar"},{"av":"A929EmpresaRepresentanteNumero","fld":"EMPRESAREPRESENTANTENUMERO","pic":"ZZZZZZZZZ9","nullAv":"n929EmpresaRepresentanteNumero","type":"int"},{"av":"A930EmpresaRepresentanteCEP","fld":"EMPRESAREPRESENTANTECEP","type":"svchar"},{"av":"A931EmpresaRepresentanteBairro","fld":"EMPRESAREPRESENTANTEBAIRRO","type":"svchar"},{"av":"A932EmpresaRepresentanteComplemento","fld":"EMPRESAREPRESENTANTECOMPLEMENTO","type":"svchar"},{"av":"A933EmpresaRepresentanteNacionalidade","fld":"EMPRESAREPRESENTANTENACIONALIDADE","type":"svchar"},{"av":"A934EmpresaRepresentanteTelefone","fld":"EMPRESAREPRESENTANTETELEFONE","pic":"ZZZZZZZZ9","nullAv":"n934EmpresaRepresentanteTelefone","type":"int"},{"av":"A935EmpresaRepresentanteTelefoneDDD","fld":"EMPRESAREPRESENTANTETELEFONEDDD","pic":"ZZZ9","nullAv":"n935EmpresaRepresentanteTelefoneDDD","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12132","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[]}""");
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z250EmpresaNomeFantasia = "";
         Z251EmpresaRazaoSocial = "";
         Z252EmpresaCNPJ = "";
         Z468EmpresaPix = "";
         Z469EmpresaPixTipo = "";
         Z470EmpresaEmail = "";
         Z610EmpresaLogradouro = "";
         Z609EmpresaCEP = "";
         Z612EmpresaBairro = "";
         Z613EmpresaComplemento = "";
         Z770EmpresaRepresentanteCPF = "";
         Z771EmpresaRepresentanteNome = "";
         Z772EmpresaRepresentanteEmail = "";
         Z928EmpresaRepresentanteLogradouro = "";
         Z930EmpresaRepresentanteCEP = "";
         Z931EmpresaRepresentanteBairro = "";
         Z932EmpresaRepresentanteComplemento = "";
         Z933EmpresaRepresentanteNacionalidade = "";
         Z186MunicipioCodigo = "";
         Z925EmpresaRepresentanteMunicipio = "";
         N186MunicipioCodigo = "";
         N925EmpresaRepresentanteMunicipio = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A186MunicipioCodigo = "";
         A925EmpresaRepresentanteMunicipio = "";
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
         A250EmpresaNomeFantasia = "";
         A251EmpresaRazaoSocial = "";
         A252EmpresaCNPJ = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A468EmpresaPix = "";
         A469EmpresaPixTipo = "";
         A470EmpresaEmail = "";
         A610EmpresaLogradouro = "";
         A609EmpresaCEP = "";
         A612EmpresaBairro = "";
         A613EmpresaComplemento = "";
         A770EmpresaRepresentanteCPF = "";
         A771EmpresaRepresentanteNome = "";
         A772EmpresaRepresentanteEmail = "";
         A928EmpresaRepresentanteLogradouro = "";
         A930EmpresaRepresentanteCEP = "";
         A931EmpresaRepresentanteBairro = "";
         A932EmpresaRepresentanteComplemento = "";
         A933EmpresaRepresentanteNacionalidade = "";
         AV13Insert_MunicipioCodigo = "";
         AV14Insert_EmpresaRepresentanteMunicipio = "";
         A187MunicipioNome = "";
         A189MunicipioUF = "";
         A926EmpresaRepresentanteMunicipioNome = "";
         A927EmpresaRepresentanteMunicipioUF = "";
         A403BancoNome = "";
         AV16Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode42 = "";
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
         Z187MunicipioNome = "";
         Z189MunicipioUF = "";
         Z926EmpresaRepresentanteMunicipioNome = "";
         Z927EmpresaRepresentanteMunicipioUF = "";
         Z403BancoNome = "";
         T00135_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         T00135_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         T00135_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         T00135_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         T00134_A187MunicipioNome = new string[] {""} ;
         T00134_n187MunicipioNome = new bool[] {false} ;
         T00134_A189MunicipioUF = new string[] {""} ;
         T00134_n189MunicipioUF = new bool[] {false} ;
         T00136_A403BancoNome = new string[] {""} ;
         T00136_n403BancoNome = new bool[] {false} ;
         T00138_A249EmpresaId = new int[1] ;
         T00138_A250EmpresaNomeFantasia = new string[] {""} ;
         T00138_n250EmpresaNomeFantasia = new bool[] {false} ;
         T00138_A251EmpresaRazaoSocial = new string[] {""} ;
         T00138_n251EmpresaRazaoSocial = new bool[] {false} ;
         T00138_A252EmpresaCNPJ = new string[] {""} ;
         T00138_n252EmpresaCNPJ = new bool[] {false} ;
         T00138_A253EmpresaSede = new bool[] {false} ;
         T00138_n253EmpresaSede = new bool[] {false} ;
         T00138_A403BancoNome = new string[] {""} ;
         T00138_n403BancoNome = new bool[] {false} ;
         T00138_A465EmpresaAgencia = new int[1] ;
         T00138_n465EmpresaAgencia = new bool[] {false} ;
         T00138_A466EmpresaAgenciaDigito = new int[1] ;
         T00138_n466EmpresaAgenciaDigito = new bool[] {false} ;
         T00138_A467EmpresaConta = new int[1] ;
         T00138_n467EmpresaConta = new bool[] {false} ;
         T00138_A468EmpresaPix = new string[] {""} ;
         T00138_n468EmpresaPix = new bool[] {false} ;
         T00138_A469EmpresaPixTipo = new string[] {""} ;
         T00138_n469EmpresaPixTipo = new bool[] {false} ;
         T00138_A470EmpresaEmail = new string[] {""} ;
         T00138_n470EmpresaEmail = new bool[] {false} ;
         T00138_A610EmpresaLogradouro = new string[] {""} ;
         T00138_n610EmpresaLogradouro = new bool[] {false} ;
         T00138_A611EmpresaLogradouroNumero = new long[1] ;
         T00138_n611EmpresaLogradouroNumero = new bool[] {false} ;
         T00138_A609EmpresaCEP = new string[] {""} ;
         T00138_n609EmpresaCEP = new bool[] {false} ;
         T00138_A612EmpresaBairro = new string[] {""} ;
         T00138_n612EmpresaBairro = new bool[] {false} ;
         T00138_A613EmpresaComplemento = new string[] {""} ;
         T00138_n613EmpresaComplemento = new bool[] {false} ;
         T00138_A187MunicipioNome = new string[] {""} ;
         T00138_n187MunicipioNome = new bool[] {false} ;
         T00138_A189MunicipioUF = new string[] {""} ;
         T00138_n189MunicipioUF = new bool[] {false} ;
         T00138_A770EmpresaRepresentanteCPF = new string[] {""} ;
         T00138_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         T00138_A771EmpresaRepresentanteNome = new string[] {""} ;
         T00138_n771EmpresaRepresentanteNome = new bool[] {false} ;
         T00138_A772EmpresaRepresentanteEmail = new string[] {""} ;
         T00138_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         T00138_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         T00138_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         T00138_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         T00138_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         T00138_A929EmpresaRepresentanteNumero = new long[1] ;
         T00138_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         T00138_A930EmpresaRepresentanteCEP = new string[] {""} ;
         T00138_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         T00138_A931EmpresaRepresentanteBairro = new string[] {""} ;
         T00138_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         T00138_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         T00138_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         T00138_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         T00138_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         T00138_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         T00138_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         T00138_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         T00138_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         T00138_A934EmpresaRepresentanteTelefone = new int[1] ;
         T00138_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         T00138_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         T00138_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         T00138_A186MunicipioCodigo = new string[] {""} ;
         T00138_n186MunicipioCodigo = new bool[] {false} ;
         T00138_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         T00138_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         T00138_A464EmpresaBancoId = new int[1] ;
         T00138_n464EmpresaBancoId = new bool[] {false} ;
         T00138_A924EmpresaRepresentanteProfissao = new int[1] ;
         T00138_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         T00137_A924EmpresaRepresentanteProfissao = new int[1] ;
         T00137_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         T00139_A187MunicipioNome = new string[] {""} ;
         T00139_n187MunicipioNome = new bool[] {false} ;
         T00139_A189MunicipioUF = new string[] {""} ;
         T00139_n189MunicipioUF = new bool[] {false} ;
         T001310_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         T001310_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         T001310_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         T001310_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         T001311_A403BancoNome = new string[] {""} ;
         T001311_n403BancoNome = new bool[] {false} ;
         T001312_A924EmpresaRepresentanteProfissao = new int[1] ;
         T001312_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         T001313_A249EmpresaId = new int[1] ;
         T00133_A249EmpresaId = new int[1] ;
         T00133_A250EmpresaNomeFantasia = new string[] {""} ;
         T00133_n250EmpresaNomeFantasia = new bool[] {false} ;
         T00133_A251EmpresaRazaoSocial = new string[] {""} ;
         T00133_n251EmpresaRazaoSocial = new bool[] {false} ;
         T00133_A252EmpresaCNPJ = new string[] {""} ;
         T00133_n252EmpresaCNPJ = new bool[] {false} ;
         T00133_A253EmpresaSede = new bool[] {false} ;
         T00133_n253EmpresaSede = new bool[] {false} ;
         T00133_A465EmpresaAgencia = new int[1] ;
         T00133_n465EmpresaAgencia = new bool[] {false} ;
         T00133_A466EmpresaAgenciaDigito = new int[1] ;
         T00133_n466EmpresaAgenciaDigito = new bool[] {false} ;
         T00133_A467EmpresaConta = new int[1] ;
         T00133_n467EmpresaConta = new bool[] {false} ;
         T00133_A468EmpresaPix = new string[] {""} ;
         T00133_n468EmpresaPix = new bool[] {false} ;
         T00133_A469EmpresaPixTipo = new string[] {""} ;
         T00133_n469EmpresaPixTipo = new bool[] {false} ;
         T00133_A470EmpresaEmail = new string[] {""} ;
         T00133_n470EmpresaEmail = new bool[] {false} ;
         T00133_A610EmpresaLogradouro = new string[] {""} ;
         T00133_n610EmpresaLogradouro = new bool[] {false} ;
         T00133_A611EmpresaLogradouroNumero = new long[1] ;
         T00133_n611EmpresaLogradouroNumero = new bool[] {false} ;
         T00133_A609EmpresaCEP = new string[] {""} ;
         T00133_n609EmpresaCEP = new bool[] {false} ;
         T00133_A612EmpresaBairro = new string[] {""} ;
         T00133_n612EmpresaBairro = new bool[] {false} ;
         T00133_A613EmpresaComplemento = new string[] {""} ;
         T00133_n613EmpresaComplemento = new bool[] {false} ;
         T00133_A770EmpresaRepresentanteCPF = new string[] {""} ;
         T00133_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         T00133_A771EmpresaRepresentanteNome = new string[] {""} ;
         T00133_n771EmpresaRepresentanteNome = new bool[] {false} ;
         T00133_A772EmpresaRepresentanteEmail = new string[] {""} ;
         T00133_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         T00133_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         T00133_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         T00133_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         T00133_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         T00133_A929EmpresaRepresentanteNumero = new long[1] ;
         T00133_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         T00133_A930EmpresaRepresentanteCEP = new string[] {""} ;
         T00133_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         T00133_A931EmpresaRepresentanteBairro = new string[] {""} ;
         T00133_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         T00133_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         T00133_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         T00133_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         T00133_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         T00133_A934EmpresaRepresentanteTelefone = new int[1] ;
         T00133_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         T00133_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         T00133_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         T00133_A186MunicipioCodigo = new string[] {""} ;
         T00133_n186MunicipioCodigo = new bool[] {false} ;
         T00133_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         T00133_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         T00133_A464EmpresaBancoId = new int[1] ;
         T00133_n464EmpresaBancoId = new bool[] {false} ;
         T00133_A924EmpresaRepresentanteProfissao = new int[1] ;
         T00133_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         T001314_A249EmpresaId = new int[1] ;
         T001315_A249EmpresaId = new int[1] ;
         T00132_A249EmpresaId = new int[1] ;
         T00132_A250EmpresaNomeFantasia = new string[] {""} ;
         T00132_n250EmpresaNomeFantasia = new bool[] {false} ;
         T00132_A251EmpresaRazaoSocial = new string[] {""} ;
         T00132_n251EmpresaRazaoSocial = new bool[] {false} ;
         T00132_A252EmpresaCNPJ = new string[] {""} ;
         T00132_n252EmpresaCNPJ = new bool[] {false} ;
         T00132_A253EmpresaSede = new bool[] {false} ;
         T00132_n253EmpresaSede = new bool[] {false} ;
         T00132_A465EmpresaAgencia = new int[1] ;
         T00132_n465EmpresaAgencia = new bool[] {false} ;
         T00132_A466EmpresaAgenciaDigito = new int[1] ;
         T00132_n466EmpresaAgenciaDigito = new bool[] {false} ;
         T00132_A467EmpresaConta = new int[1] ;
         T00132_n467EmpresaConta = new bool[] {false} ;
         T00132_A468EmpresaPix = new string[] {""} ;
         T00132_n468EmpresaPix = new bool[] {false} ;
         T00132_A469EmpresaPixTipo = new string[] {""} ;
         T00132_n469EmpresaPixTipo = new bool[] {false} ;
         T00132_A470EmpresaEmail = new string[] {""} ;
         T00132_n470EmpresaEmail = new bool[] {false} ;
         T00132_A610EmpresaLogradouro = new string[] {""} ;
         T00132_n610EmpresaLogradouro = new bool[] {false} ;
         T00132_A611EmpresaLogradouroNumero = new long[1] ;
         T00132_n611EmpresaLogradouroNumero = new bool[] {false} ;
         T00132_A609EmpresaCEP = new string[] {""} ;
         T00132_n609EmpresaCEP = new bool[] {false} ;
         T00132_A612EmpresaBairro = new string[] {""} ;
         T00132_n612EmpresaBairro = new bool[] {false} ;
         T00132_A613EmpresaComplemento = new string[] {""} ;
         T00132_n613EmpresaComplemento = new bool[] {false} ;
         T00132_A770EmpresaRepresentanteCPF = new string[] {""} ;
         T00132_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         T00132_A771EmpresaRepresentanteNome = new string[] {""} ;
         T00132_n771EmpresaRepresentanteNome = new bool[] {false} ;
         T00132_A772EmpresaRepresentanteEmail = new string[] {""} ;
         T00132_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         T00132_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         T00132_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         T00132_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         T00132_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         T00132_A929EmpresaRepresentanteNumero = new long[1] ;
         T00132_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         T00132_A930EmpresaRepresentanteCEP = new string[] {""} ;
         T00132_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         T00132_A931EmpresaRepresentanteBairro = new string[] {""} ;
         T00132_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         T00132_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         T00132_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         T00132_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         T00132_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         T00132_A934EmpresaRepresentanteTelefone = new int[1] ;
         T00132_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         T00132_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         T00132_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         T00132_A186MunicipioCodigo = new string[] {""} ;
         T00132_n186MunicipioCodigo = new bool[] {false} ;
         T00132_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         T00132_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         T00132_A464EmpresaBancoId = new int[1] ;
         T00132_n464EmpresaBancoId = new bool[] {false} ;
         T00132_A924EmpresaRepresentanteProfissao = new int[1] ;
         T00132_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         T001317_A249EmpresaId = new int[1] ;
         T001320_A187MunicipioNome = new string[] {""} ;
         T001320_n187MunicipioNome = new bool[] {false} ;
         T001320_A189MunicipioUF = new string[] {""} ;
         T001320_n189MunicipioUF = new bool[] {false} ;
         T001321_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         T001321_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         T001321_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         T001321_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         T001322_A403BancoNome = new string[] {""} ;
         T001322_n403BancoNome = new bool[] {false} ;
         T001323_A249EmpresaId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empresa__default(),
            new Object[][] {
                new Object[] {
               T00132_A249EmpresaId, T00132_A250EmpresaNomeFantasia, T00132_n250EmpresaNomeFantasia, T00132_A251EmpresaRazaoSocial, T00132_n251EmpresaRazaoSocial, T00132_A252EmpresaCNPJ, T00132_n252EmpresaCNPJ, T00132_A253EmpresaSede, T00132_n253EmpresaSede, T00132_A465EmpresaAgencia,
               T00132_n465EmpresaAgencia, T00132_A466EmpresaAgenciaDigito, T00132_n466EmpresaAgenciaDigito, T00132_A467EmpresaConta, T00132_n467EmpresaConta, T00132_A468EmpresaPix, T00132_n468EmpresaPix, T00132_A469EmpresaPixTipo, T00132_n469EmpresaPixTipo, T00132_A470EmpresaEmail,
               T00132_n470EmpresaEmail, T00132_A610EmpresaLogradouro, T00132_n610EmpresaLogradouro, T00132_A611EmpresaLogradouroNumero, T00132_n611EmpresaLogradouroNumero, T00132_A609EmpresaCEP, T00132_n609EmpresaCEP, T00132_A612EmpresaBairro, T00132_n612EmpresaBairro, T00132_A613EmpresaComplemento,
               T00132_n613EmpresaComplemento, T00132_A770EmpresaRepresentanteCPF, T00132_n770EmpresaRepresentanteCPF, T00132_A771EmpresaRepresentanteNome, T00132_n771EmpresaRepresentanteNome, T00132_A772EmpresaRepresentanteEmail, T00132_n772EmpresaRepresentanteEmail, T00132_A773EmpresaUtilizaRepresentanteAssinatura, T00132_n773EmpresaUtilizaRepresentanteAssinatura, T00132_A928EmpresaRepresentanteLogradouro,
               T00132_n928EmpresaRepresentanteLogradouro, T00132_A929EmpresaRepresentanteNumero, T00132_n929EmpresaRepresentanteNumero, T00132_A930EmpresaRepresentanteCEP, T00132_n930EmpresaRepresentanteCEP, T00132_A931EmpresaRepresentanteBairro, T00132_n931EmpresaRepresentanteBairro, T00132_A932EmpresaRepresentanteComplemento, T00132_n932EmpresaRepresentanteComplemento, T00132_A933EmpresaRepresentanteNacionalidade,
               T00132_n933EmpresaRepresentanteNacionalidade, T00132_A934EmpresaRepresentanteTelefone, T00132_n934EmpresaRepresentanteTelefone, T00132_A935EmpresaRepresentanteTelefoneDDD, T00132_n935EmpresaRepresentanteTelefoneDDD, T00132_A186MunicipioCodigo, T00132_n186MunicipioCodigo, T00132_A925EmpresaRepresentanteMunicipio, T00132_n925EmpresaRepresentanteMunicipio, T00132_A464EmpresaBancoId,
               T00132_n464EmpresaBancoId, T00132_A924EmpresaRepresentanteProfissao, T00132_n924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               T00133_A249EmpresaId, T00133_A250EmpresaNomeFantasia, T00133_n250EmpresaNomeFantasia, T00133_A251EmpresaRazaoSocial, T00133_n251EmpresaRazaoSocial, T00133_A252EmpresaCNPJ, T00133_n252EmpresaCNPJ, T00133_A253EmpresaSede, T00133_n253EmpresaSede, T00133_A465EmpresaAgencia,
               T00133_n465EmpresaAgencia, T00133_A466EmpresaAgenciaDigito, T00133_n466EmpresaAgenciaDigito, T00133_A467EmpresaConta, T00133_n467EmpresaConta, T00133_A468EmpresaPix, T00133_n468EmpresaPix, T00133_A469EmpresaPixTipo, T00133_n469EmpresaPixTipo, T00133_A470EmpresaEmail,
               T00133_n470EmpresaEmail, T00133_A610EmpresaLogradouro, T00133_n610EmpresaLogradouro, T00133_A611EmpresaLogradouroNumero, T00133_n611EmpresaLogradouroNumero, T00133_A609EmpresaCEP, T00133_n609EmpresaCEP, T00133_A612EmpresaBairro, T00133_n612EmpresaBairro, T00133_A613EmpresaComplemento,
               T00133_n613EmpresaComplemento, T00133_A770EmpresaRepresentanteCPF, T00133_n770EmpresaRepresentanteCPF, T00133_A771EmpresaRepresentanteNome, T00133_n771EmpresaRepresentanteNome, T00133_A772EmpresaRepresentanteEmail, T00133_n772EmpresaRepresentanteEmail, T00133_A773EmpresaUtilizaRepresentanteAssinatura, T00133_n773EmpresaUtilizaRepresentanteAssinatura, T00133_A928EmpresaRepresentanteLogradouro,
               T00133_n928EmpresaRepresentanteLogradouro, T00133_A929EmpresaRepresentanteNumero, T00133_n929EmpresaRepresentanteNumero, T00133_A930EmpresaRepresentanteCEP, T00133_n930EmpresaRepresentanteCEP, T00133_A931EmpresaRepresentanteBairro, T00133_n931EmpresaRepresentanteBairro, T00133_A932EmpresaRepresentanteComplemento, T00133_n932EmpresaRepresentanteComplemento, T00133_A933EmpresaRepresentanteNacionalidade,
               T00133_n933EmpresaRepresentanteNacionalidade, T00133_A934EmpresaRepresentanteTelefone, T00133_n934EmpresaRepresentanteTelefone, T00133_A935EmpresaRepresentanteTelefoneDDD, T00133_n935EmpresaRepresentanteTelefoneDDD, T00133_A186MunicipioCodigo, T00133_n186MunicipioCodigo, T00133_A925EmpresaRepresentanteMunicipio, T00133_n925EmpresaRepresentanteMunicipio, T00133_A464EmpresaBancoId,
               T00133_n464EmpresaBancoId, T00133_A924EmpresaRepresentanteProfissao, T00133_n924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               T00134_A187MunicipioNome, T00134_n187MunicipioNome, T00134_A189MunicipioUF, T00134_n189MunicipioUF
               }
               , new Object[] {
               T00135_A926EmpresaRepresentanteMunicipioNome, T00135_n926EmpresaRepresentanteMunicipioNome, T00135_A927EmpresaRepresentanteMunicipioUF, T00135_n927EmpresaRepresentanteMunicipioUF
               }
               , new Object[] {
               T00136_A403BancoNome, T00136_n403BancoNome
               }
               , new Object[] {
               T00137_A924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               T00138_A249EmpresaId, T00138_A250EmpresaNomeFantasia, T00138_n250EmpresaNomeFantasia, T00138_A251EmpresaRazaoSocial, T00138_n251EmpresaRazaoSocial, T00138_A252EmpresaCNPJ, T00138_n252EmpresaCNPJ, T00138_A253EmpresaSede, T00138_n253EmpresaSede, T00138_A403BancoNome,
               T00138_n403BancoNome, T00138_A465EmpresaAgencia, T00138_n465EmpresaAgencia, T00138_A466EmpresaAgenciaDigito, T00138_n466EmpresaAgenciaDigito, T00138_A467EmpresaConta, T00138_n467EmpresaConta, T00138_A468EmpresaPix, T00138_n468EmpresaPix, T00138_A469EmpresaPixTipo,
               T00138_n469EmpresaPixTipo, T00138_A470EmpresaEmail, T00138_n470EmpresaEmail, T00138_A610EmpresaLogradouro, T00138_n610EmpresaLogradouro, T00138_A611EmpresaLogradouroNumero, T00138_n611EmpresaLogradouroNumero, T00138_A609EmpresaCEP, T00138_n609EmpresaCEP, T00138_A612EmpresaBairro,
               T00138_n612EmpresaBairro, T00138_A613EmpresaComplemento, T00138_n613EmpresaComplemento, T00138_A187MunicipioNome, T00138_n187MunicipioNome, T00138_A189MunicipioUF, T00138_n189MunicipioUF, T00138_A770EmpresaRepresentanteCPF, T00138_n770EmpresaRepresentanteCPF, T00138_A771EmpresaRepresentanteNome,
               T00138_n771EmpresaRepresentanteNome, T00138_A772EmpresaRepresentanteEmail, T00138_n772EmpresaRepresentanteEmail, T00138_A773EmpresaUtilizaRepresentanteAssinatura, T00138_n773EmpresaUtilizaRepresentanteAssinatura, T00138_A928EmpresaRepresentanteLogradouro, T00138_n928EmpresaRepresentanteLogradouro, T00138_A929EmpresaRepresentanteNumero, T00138_n929EmpresaRepresentanteNumero, T00138_A930EmpresaRepresentanteCEP,
               T00138_n930EmpresaRepresentanteCEP, T00138_A931EmpresaRepresentanteBairro, T00138_n931EmpresaRepresentanteBairro, T00138_A932EmpresaRepresentanteComplemento, T00138_n932EmpresaRepresentanteComplemento, T00138_A926EmpresaRepresentanteMunicipioNome, T00138_n926EmpresaRepresentanteMunicipioNome, T00138_A927EmpresaRepresentanteMunicipioUF, T00138_n927EmpresaRepresentanteMunicipioUF, T00138_A933EmpresaRepresentanteNacionalidade,
               T00138_n933EmpresaRepresentanteNacionalidade, T00138_A934EmpresaRepresentanteTelefone, T00138_n934EmpresaRepresentanteTelefone, T00138_A935EmpresaRepresentanteTelefoneDDD, T00138_n935EmpresaRepresentanteTelefoneDDD, T00138_A186MunicipioCodigo, T00138_n186MunicipioCodigo, T00138_A925EmpresaRepresentanteMunicipio, T00138_n925EmpresaRepresentanteMunicipio, T00138_A464EmpresaBancoId,
               T00138_n464EmpresaBancoId, T00138_A924EmpresaRepresentanteProfissao, T00138_n924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               T00139_A187MunicipioNome, T00139_n187MunicipioNome, T00139_A189MunicipioUF, T00139_n189MunicipioUF
               }
               , new Object[] {
               T001310_A926EmpresaRepresentanteMunicipioNome, T001310_n926EmpresaRepresentanteMunicipioNome, T001310_A927EmpresaRepresentanteMunicipioUF, T001310_n927EmpresaRepresentanteMunicipioUF
               }
               , new Object[] {
               T001311_A403BancoNome, T001311_n403BancoNome
               }
               , new Object[] {
               T001312_A924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               T001313_A249EmpresaId
               }
               , new Object[] {
               T001314_A249EmpresaId
               }
               , new Object[] {
               T001315_A249EmpresaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001317_A249EmpresaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001320_A187MunicipioNome, T001320_n187MunicipioNome, T001320_A189MunicipioUF, T001320_n189MunicipioUF
               }
               , new Object[] {
               T001321_A926EmpresaRepresentanteMunicipioNome, T001321_n926EmpresaRepresentanteMunicipioNome, T001321_A927EmpresaRepresentanteMunicipioUF, T001321_n927EmpresaRepresentanteMunicipioUF
               }
               , new Object[] {
               T001322_A403BancoNome, T001322_n403BancoNome
               }
               , new Object[] {
               T001323_A249EmpresaId
               }
            }
         );
         AV16Pgmname = "Empresa";
      }

      private short Z935EmpresaRepresentanteTelefoneDDD ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A935EmpresaRepresentanteTelefoneDDD ;
      private short RcdFound42 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7EmpresaId ;
      private int Z249EmpresaId ;
      private int Z465EmpresaAgencia ;
      private int Z466EmpresaAgenciaDigito ;
      private int Z467EmpresaConta ;
      private int Z934EmpresaRepresentanteTelefone ;
      private int Z464EmpresaBancoId ;
      private int Z924EmpresaRepresentanteProfissao ;
      private int N464EmpresaBancoId ;
      private int N924EmpresaRepresentanteProfissao ;
      private int A464EmpresaBancoId ;
      private int A924EmpresaRepresentanteProfissao ;
      private int AV7EmpresaId ;
      private int trnEnded ;
      private int A249EmpresaId ;
      private int edtEmpresaId_Enabled ;
      private int edtEmpresaNomeFantasia_Enabled ;
      private int edtEmpresaRazaoSocial_Enabled ;
      private int edtEmpresaCNPJ_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A465EmpresaAgencia ;
      private int A466EmpresaAgenciaDigito ;
      private int A467EmpresaConta ;
      private int A934EmpresaRepresentanteTelefone ;
      private int AV11Insert_EmpresaBancoId ;
      private int AV15Insert_EmpresaRepresentanteProfissao ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV17GXV1 ;
      private int idxLst ;
      private long Z611EmpresaLogradouroNumero ;
      private long Z929EmpresaRepresentanteNumero ;
      private long A611EmpresaLogradouroNumero ;
      private long A929EmpresaRepresentanteNumero ;
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
      private string edtEmpresaNomeFantasia_Internalname ;
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
      private string edtEmpresaId_Internalname ;
      private string TempTags ;
      private string edtEmpresaId_Jsonclick ;
      private string edtEmpresaNomeFantasia_Jsonclick ;
      private string edtEmpresaRazaoSocial_Internalname ;
      private string edtEmpresaRazaoSocial_Jsonclick ;
      private string edtEmpresaCNPJ_Internalname ;
      private string edtEmpresaCNPJ_Jsonclick ;
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
      private string sMode42 ;
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
      private bool Z253EmpresaSede ;
      private bool Z773EmpresaUtilizaRepresentanteAssinatura ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n186MunicipioCodigo ;
      private bool n925EmpresaRepresentanteMunicipio ;
      private bool n464EmpresaBancoId ;
      private bool n924EmpresaRepresentanteProfissao ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n250EmpresaNomeFantasia ;
      private bool n251EmpresaRazaoSocial ;
      private bool n252EmpresaCNPJ ;
      private bool n253EmpresaSede ;
      private bool A253EmpresaSede ;
      private bool n465EmpresaAgencia ;
      private bool n466EmpresaAgenciaDigito ;
      private bool n467EmpresaConta ;
      private bool n468EmpresaPix ;
      private bool n469EmpresaPixTipo ;
      private bool n470EmpresaEmail ;
      private bool n610EmpresaLogradouro ;
      private bool n611EmpresaLogradouroNumero ;
      private bool n609EmpresaCEP ;
      private bool n612EmpresaBairro ;
      private bool n613EmpresaComplemento ;
      private bool n770EmpresaRepresentanteCPF ;
      private bool n771EmpresaRepresentanteNome ;
      private bool n772EmpresaRepresentanteEmail ;
      private bool n773EmpresaUtilizaRepresentanteAssinatura ;
      private bool A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n928EmpresaRepresentanteLogradouro ;
      private bool n929EmpresaRepresentanteNumero ;
      private bool n930EmpresaRepresentanteCEP ;
      private bool n931EmpresaRepresentanteBairro ;
      private bool n932EmpresaRepresentanteComplemento ;
      private bool n933EmpresaRepresentanteNacionalidade ;
      private bool n934EmpresaRepresentanteTelefone ;
      private bool n935EmpresaRepresentanteTelefoneDDD ;
      private bool n187MunicipioNome ;
      private bool n189MunicipioUF ;
      private bool n926EmpresaRepresentanteMunicipioNome ;
      private bool n927EmpresaRepresentanteMunicipioUF ;
      private bool n403BancoNome ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z250EmpresaNomeFantasia ;
      private string Z251EmpresaRazaoSocial ;
      private string Z252EmpresaCNPJ ;
      private string Z468EmpresaPix ;
      private string Z469EmpresaPixTipo ;
      private string Z470EmpresaEmail ;
      private string Z610EmpresaLogradouro ;
      private string Z609EmpresaCEP ;
      private string Z612EmpresaBairro ;
      private string Z613EmpresaComplemento ;
      private string Z770EmpresaRepresentanteCPF ;
      private string Z771EmpresaRepresentanteNome ;
      private string Z772EmpresaRepresentanteEmail ;
      private string Z928EmpresaRepresentanteLogradouro ;
      private string Z930EmpresaRepresentanteCEP ;
      private string Z931EmpresaRepresentanteBairro ;
      private string Z932EmpresaRepresentanteComplemento ;
      private string Z933EmpresaRepresentanteNacionalidade ;
      private string Z186MunicipioCodigo ;
      private string Z925EmpresaRepresentanteMunicipio ;
      private string N186MunicipioCodigo ;
      private string N925EmpresaRepresentanteMunicipio ;
      private string A186MunicipioCodigo ;
      private string A925EmpresaRepresentanteMunicipio ;
      private string A250EmpresaNomeFantasia ;
      private string A251EmpresaRazaoSocial ;
      private string A252EmpresaCNPJ ;
      private string A468EmpresaPix ;
      private string A469EmpresaPixTipo ;
      private string A470EmpresaEmail ;
      private string A610EmpresaLogradouro ;
      private string A609EmpresaCEP ;
      private string A612EmpresaBairro ;
      private string A613EmpresaComplemento ;
      private string A770EmpresaRepresentanteCPF ;
      private string A771EmpresaRepresentanteNome ;
      private string A772EmpresaRepresentanteEmail ;
      private string A928EmpresaRepresentanteLogradouro ;
      private string A930EmpresaRepresentanteCEP ;
      private string A931EmpresaRepresentanteBairro ;
      private string A932EmpresaRepresentanteComplemento ;
      private string A933EmpresaRepresentanteNacionalidade ;
      private string AV13Insert_MunicipioCodigo ;
      private string AV14Insert_EmpresaRepresentanteMunicipio ;
      private string A187MunicipioNome ;
      private string A189MunicipioUF ;
      private string A926EmpresaRepresentanteMunicipioNome ;
      private string A927EmpresaRepresentanteMunicipioUF ;
      private string A403BancoNome ;
      private string Z187MunicipioNome ;
      private string Z189MunicipioUF ;
      private string Z926EmpresaRepresentanteMunicipioNome ;
      private string Z927EmpresaRepresentanteMunicipioUF ;
      private string Z403BancoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00135_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] T00135_n926EmpresaRepresentanteMunicipioNome ;
      private string[] T00135_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] T00135_n927EmpresaRepresentanteMunicipioUF ;
      private string[] T00134_A187MunicipioNome ;
      private bool[] T00134_n187MunicipioNome ;
      private string[] T00134_A189MunicipioUF ;
      private bool[] T00134_n189MunicipioUF ;
      private string[] T00136_A403BancoNome ;
      private bool[] T00136_n403BancoNome ;
      private int[] T00138_A249EmpresaId ;
      private string[] T00138_A250EmpresaNomeFantasia ;
      private bool[] T00138_n250EmpresaNomeFantasia ;
      private string[] T00138_A251EmpresaRazaoSocial ;
      private bool[] T00138_n251EmpresaRazaoSocial ;
      private string[] T00138_A252EmpresaCNPJ ;
      private bool[] T00138_n252EmpresaCNPJ ;
      private bool[] T00138_A253EmpresaSede ;
      private bool[] T00138_n253EmpresaSede ;
      private string[] T00138_A403BancoNome ;
      private bool[] T00138_n403BancoNome ;
      private int[] T00138_A465EmpresaAgencia ;
      private bool[] T00138_n465EmpresaAgencia ;
      private int[] T00138_A466EmpresaAgenciaDigito ;
      private bool[] T00138_n466EmpresaAgenciaDigito ;
      private int[] T00138_A467EmpresaConta ;
      private bool[] T00138_n467EmpresaConta ;
      private string[] T00138_A468EmpresaPix ;
      private bool[] T00138_n468EmpresaPix ;
      private string[] T00138_A469EmpresaPixTipo ;
      private bool[] T00138_n469EmpresaPixTipo ;
      private string[] T00138_A470EmpresaEmail ;
      private bool[] T00138_n470EmpresaEmail ;
      private string[] T00138_A610EmpresaLogradouro ;
      private bool[] T00138_n610EmpresaLogradouro ;
      private long[] T00138_A611EmpresaLogradouroNumero ;
      private bool[] T00138_n611EmpresaLogradouroNumero ;
      private string[] T00138_A609EmpresaCEP ;
      private bool[] T00138_n609EmpresaCEP ;
      private string[] T00138_A612EmpresaBairro ;
      private bool[] T00138_n612EmpresaBairro ;
      private string[] T00138_A613EmpresaComplemento ;
      private bool[] T00138_n613EmpresaComplemento ;
      private string[] T00138_A187MunicipioNome ;
      private bool[] T00138_n187MunicipioNome ;
      private string[] T00138_A189MunicipioUF ;
      private bool[] T00138_n189MunicipioUF ;
      private string[] T00138_A770EmpresaRepresentanteCPF ;
      private bool[] T00138_n770EmpresaRepresentanteCPF ;
      private string[] T00138_A771EmpresaRepresentanteNome ;
      private bool[] T00138_n771EmpresaRepresentanteNome ;
      private string[] T00138_A772EmpresaRepresentanteEmail ;
      private bool[] T00138_n772EmpresaRepresentanteEmail ;
      private bool[] T00138_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] T00138_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] T00138_A928EmpresaRepresentanteLogradouro ;
      private bool[] T00138_n928EmpresaRepresentanteLogradouro ;
      private long[] T00138_A929EmpresaRepresentanteNumero ;
      private bool[] T00138_n929EmpresaRepresentanteNumero ;
      private string[] T00138_A930EmpresaRepresentanteCEP ;
      private bool[] T00138_n930EmpresaRepresentanteCEP ;
      private string[] T00138_A931EmpresaRepresentanteBairro ;
      private bool[] T00138_n931EmpresaRepresentanteBairro ;
      private string[] T00138_A932EmpresaRepresentanteComplemento ;
      private bool[] T00138_n932EmpresaRepresentanteComplemento ;
      private string[] T00138_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] T00138_n926EmpresaRepresentanteMunicipioNome ;
      private string[] T00138_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] T00138_n927EmpresaRepresentanteMunicipioUF ;
      private string[] T00138_A933EmpresaRepresentanteNacionalidade ;
      private bool[] T00138_n933EmpresaRepresentanteNacionalidade ;
      private int[] T00138_A934EmpresaRepresentanteTelefone ;
      private bool[] T00138_n934EmpresaRepresentanteTelefone ;
      private short[] T00138_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] T00138_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] T00138_A186MunicipioCodigo ;
      private bool[] T00138_n186MunicipioCodigo ;
      private string[] T00138_A925EmpresaRepresentanteMunicipio ;
      private bool[] T00138_n925EmpresaRepresentanteMunicipio ;
      private int[] T00138_A464EmpresaBancoId ;
      private bool[] T00138_n464EmpresaBancoId ;
      private int[] T00138_A924EmpresaRepresentanteProfissao ;
      private bool[] T00138_n924EmpresaRepresentanteProfissao ;
      private int[] T00137_A924EmpresaRepresentanteProfissao ;
      private bool[] T00137_n924EmpresaRepresentanteProfissao ;
      private string[] T00139_A187MunicipioNome ;
      private bool[] T00139_n187MunicipioNome ;
      private string[] T00139_A189MunicipioUF ;
      private bool[] T00139_n189MunicipioUF ;
      private string[] T001310_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] T001310_n926EmpresaRepresentanteMunicipioNome ;
      private string[] T001310_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] T001310_n927EmpresaRepresentanteMunicipioUF ;
      private string[] T001311_A403BancoNome ;
      private bool[] T001311_n403BancoNome ;
      private int[] T001312_A924EmpresaRepresentanteProfissao ;
      private bool[] T001312_n924EmpresaRepresentanteProfissao ;
      private int[] T001313_A249EmpresaId ;
      private int[] T00133_A249EmpresaId ;
      private string[] T00133_A250EmpresaNomeFantasia ;
      private bool[] T00133_n250EmpresaNomeFantasia ;
      private string[] T00133_A251EmpresaRazaoSocial ;
      private bool[] T00133_n251EmpresaRazaoSocial ;
      private string[] T00133_A252EmpresaCNPJ ;
      private bool[] T00133_n252EmpresaCNPJ ;
      private bool[] T00133_A253EmpresaSede ;
      private bool[] T00133_n253EmpresaSede ;
      private int[] T00133_A465EmpresaAgencia ;
      private bool[] T00133_n465EmpresaAgencia ;
      private int[] T00133_A466EmpresaAgenciaDigito ;
      private bool[] T00133_n466EmpresaAgenciaDigito ;
      private int[] T00133_A467EmpresaConta ;
      private bool[] T00133_n467EmpresaConta ;
      private string[] T00133_A468EmpresaPix ;
      private bool[] T00133_n468EmpresaPix ;
      private string[] T00133_A469EmpresaPixTipo ;
      private bool[] T00133_n469EmpresaPixTipo ;
      private string[] T00133_A470EmpresaEmail ;
      private bool[] T00133_n470EmpresaEmail ;
      private string[] T00133_A610EmpresaLogradouro ;
      private bool[] T00133_n610EmpresaLogradouro ;
      private long[] T00133_A611EmpresaLogradouroNumero ;
      private bool[] T00133_n611EmpresaLogradouroNumero ;
      private string[] T00133_A609EmpresaCEP ;
      private bool[] T00133_n609EmpresaCEP ;
      private string[] T00133_A612EmpresaBairro ;
      private bool[] T00133_n612EmpresaBairro ;
      private string[] T00133_A613EmpresaComplemento ;
      private bool[] T00133_n613EmpresaComplemento ;
      private string[] T00133_A770EmpresaRepresentanteCPF ;
      private bool[] T00133_n770EmpresaRepresentanteCPF ;
      private string[] T00133_A771EmpresaRepresentanteNome ;
      private bool[] T00133_n771EmpresaRepresentanteNome ;
      private string[] T00133_A772EmpresaRepresentanteEmail ;
      private bool[] T00133_n772EmpresaRepresentanteEmail ;
      private bool[] T00133_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] T00133_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] T00133_A928EmpresaRepresentanteLogradouro ;
      private bool[] T00133_n928EmpresaRepresentanteLogradouro ;
      private long[] T00133_A929EmpresaRepresentanteNumero ;
      private bool[] T00133_n929EmpresaRepresentanteNumero ;
      private string[] T00133_A930EmpresaRepresentanteCEP ;
      private bool[] T00133_n930EmpresaRepresentanteCEP ;
      private string[] T00133_A931EmpresaRepresentanteBairro ;
      private bool[] T00133_n931EmpresaRepresentanteBairro ;
      private string[] T00133_A932EmpresaRepresentanteComplemento ;
      private bool[] T00133_n932EmpresaRepresentanteComplemento ;
      private string[] T00133_A933EmpresaRepresentanteNacionalidade ;
      private bool[] T00133_n933EmpresaRepresentanteNacionalidade ;
      private int[] T00133_A934EmpresaRepresentanteTelefone ;
      private bool[] T00133_n934EmpresaRepresentanteTelefone ;
      private short[] T00133_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] T00133_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] T00133_A186MunicipioCodigo ;
      private bool[] T00133_n186MunicipioCodigo ;
      private string[] T00133_A925EmpresaRepresentanteMunicipio ;
      private bool[] T00133_n925EmpresaRepresentanteMunicipio ;
      private int[] T00133_A464EmpresaBancoId ;
      private bool[] T00133_n464EmpresaBancoId ;
      private int[] T00133_A924EmpresaRepresentanteProfissao ;
      private bool[] T00133_n924EmpresaRepresentanteProfissao ;
      private int[] T001314_A249EmpresaId ;
      private int[] T001315_A249EmpresaId ;
      private int[] T00132_A249EmpresaId ;
      private string[] T00132_A250EmpresaNomeFantasia ;
      private bool[] T00132_n250EmpresaNomeFantasia ;
      private string[] T00132_A251EmpresaRazaoSocial ;
      private bool[] T00132_n251EmpresaRazaoSocial ;
      private string[] T00132_A252EmpresaCNPJ ;
      private bool[] T00132_n252EmpresaCNPJ ;
      private bool[] T00132_A253EmpresaSede ;
      private bool[] T00132_n253EmpresaSede ;
      private int[] T00132_A465EmpresaAgencia ;
      private bool[] T00132_n465EmpresaAgencia ;
      private int[] T00132_A466EmpresaAgenciaDigito ;
      private bool[] T00132_n466EmpresaAgenciaDigito ;
      private int[] T00132_A467EmpresaConta ;
      private bool[] T00132_n467EmpresaConta ;
      private string[] T00132_A468EmpresaPix ;
      private bool[] T00132_n468EmpresaPix ;
      private string[] T00132_A469EmpresaPixTipo ;
      private bool[] T00132_n469EmpresaPixTipo ;
      private string[] T00132_A470EmpresaEmail ;
      private bool[] T00132_n470EmpresaEmail ;
      private string[] T00132_A610EmpresaLogradouro ;
      private bool[] T00132_n610EmpresaLogradouro ;
      private long[] T00132_A611EmpresaLogradouroNumero ;
      private bool[] T00132_n611EmpresaLogradouroNumero ;
      private string[] T00132_A609EmpresaCEP ;
      private bool[] T00132_n609EmpresaCEP ;
      private string[] T00132_A612EmpresaBairro ;
      private bool[] T00132_n612EmpresaBairro ;
      private string[] T00132_A613EmpresaComplemento ;
      private bool[] T00132_n613EmpresaComplemento ;
      private string[] T00132_A770EmpresaRepresentanteCPF ;
      private bool[] T00132_n770EmpresaRepresentanteCPF ;
      private string[] T00132_A771EmpresaRepresentanteNome ;
      private bool[] T00132_n771EmpresaRepresentanteNome ;
      private string[] T00132_A772EmpresaRepresentanteEmail ;
      private bool[] T00132_n772EmpresaRepresentanteEmail ;
      private bool[] T00132_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] T00132_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] T00132_A928EmpresaRepresentanteLogradouro ;
      private bool[] T00132_n928EmpresaRepresentanteLogradouro ;
      private long[] T00132_A929EmpresaRepresentanteNumero ;
      private bool[] T00132_n929EmpresaRepresentanteNumero ;
      private string[] T00132_A930EmpresaRepresentanteCEP ;
      private bool[] T00132_n930EmpresaRepresentanteCEP ;
      private string[] T00132_A931EmpresaRepresentanteBairro ;
      private bool[] T00132_n931EmpresaRepresentanteBairro ;
      private string[] T00132_A932EmpresaRepresentanteComplemento ;
      private bool[] T00132_n932EmpresaRepresentanteComplemento ;
      private string[] T00132_A933EmpresaRepresentanteNacionalidade ;
      private bool[] T00132_n933EmpresaRepresentanteNacionalidade ;
      private int[] T00132_A934EmpresaRepresentanteTelefone ;
      private bool[] T00132_n934EmpresaRepresentanteTelefone ;
      private short[] T00132_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] T00132_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] T00132_A186MunicipioCodigo ;
      private bool[] T00132_n186MunicipioCodigo ;
      private string[] T00132_A925EmpresaRepresentanteMunicipio ;
      private bool[] T00132_n925EmpresaRepresentanteMunicipio ;
      private int[] T00132_A464EmpresaBancoId ;
      private bool[] T00132_n464EmpresaBancoId ;
      private int[] T00132_A924EmpresaRepresentanteProfissao ;
      private bool[] T00132_n924EmpresaRepresentanteProfissao ;
      private int[] T001317_A249EmpresaId ;
      private string[] T001320_A187MunicipioNome ;
      private bool[] T001320_n187MunicipioNome ;
      private string[] T001320_A189MunicipioUF ;
      private bool[] T001320_n189MunicipioUF ;
      private string[] T001321_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] T001321_n926EmpresaRepresentanteMunicipioNome ;
      private string[] T001321_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] T001321_n927EmpresaRepresentanteMunicipioUF ;
      private string[] T001322_A403BancoNome ;
      private bool[] T001322_n403BancoNome ;
      private int[] T001323_A249EmpresaId ;
   }

   public class empresa__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00132;
          prmT00132 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT00133;
          prmT00133 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT00134;
          prmT00134 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT00135;
          prmT00135 = new Object[] {
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT00136;
          prmT00136 = new Object[] {
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00137;
          prmT00137 = new Object[] {
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00138;
          prmT00138 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT00139;
          prmT00139 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT001310;
          prmT001310 = new Object[] {
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT001311;
          prmT001311 = new Object[] {
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001312;
          prmT001312 = new Object[] {
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001313;
          prmT001313 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT001314;
          prmT001314 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT001315;
          prmT001315 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT001316;
          prmT001316 = new Object[] {
          new ParDef("EmpresaNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaCNPJ",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaSede",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaAgencia",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaAgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaConta",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("EmpresaPix",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("EmpresaPixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaUtilizaRepresentanteAssinatura",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCEP",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNacionalidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefone",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001317;
          prmT001317 = new Object[] {
          };
          Object[] prmT001318;
          prmT001318 = new Object[] {
          new ParDef("EmpresaNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaCNPJ",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaSede",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaAgencia",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaAgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaConta",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("EmpresaPix",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("EmpresaPixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaUtilizaRepresentanteAssinatura",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCEP",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNacionalidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefone",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT001319;
          prmT001319 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmT001320;
          prmT001320 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT001321;
          prmT001321 = new Object[] {
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT001322;
          prmT001322 = new Object[] {
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001323;
          prmT001323 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00132", "SELECT EmpresaId, EmpresaNomeFantasia, EmpresaRazaoSocial, EmpresaCNPJ, EmpresaSede, EmpresaAgencia, EmpresaAgenciaDigito, EmpresaConta, EmpresaPix, EmpresaPixTipo, EmpresaEmail, EmpresaLogradouro, EmpresaLogradouroNumero, EmpresaCEP, EmpresaBairro, EmpresaComplemento, EmpresaRepresentanteCPF, EmpresaRepresentanteNome, EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero, EmpresaRepresentanteCEP, EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD, MunicipioCodigo, EmpresaRepresentanteMunicipio, EmpresaBancoId, EmpresaRepresentanteProfissao FROM Empresa WHERE EmpresaId = :EmpresaId  FOR UPDATE OF Empresa NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00132,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00133", "SELECT EmpresaId, EmpresaNomeFantasia, EmpresaRazaoSocial, EmpresaCNPJ, EmpresaSede, EmpresaAgencia, EmpresaAgenciaDigito, EmpresaConta, EmpresaPix, EmpresaPixTipo, EmpresaEmail, EmpresaLogradouro, EmpresaLogradouroNumero, EmpresaCEP, EmpresaBairro, EmpresaComplemento, EmpresaRepresentanteCPF, EmpresaRepresentanteNome, EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero, EmpresaRepresentanteCEP, EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD, MunicipioCodigo, EmpresaRepresentanteMunicipio, EmpresaBancoId, EmpresaRepresentanteProfissao FROM Empresa WHERE EmpresaId = :EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00133,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00134", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00134,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00135", "SELECT MunicipioNome AS EmpresaRepresentanteMunicipioNome, MunicipioUF AS EmpresaRepresentanteMunicipioUF FROM Municipio WHERE MunicipioCodigo = :EmpresaRepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT00135,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00136", "SELECT BancoNome FROM Banco WHERE BancoId = :EmpresaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00136,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00137", "SELECT ProfissaoId AS EmpresaRepresentanteProfissao FROM Profissao WHERE ProfissaoId = :EmpresaRepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT00137,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00138", "SELECT TM1.EmpresaId, TM1.EmpresaNomeFantasia, TM1.EmpresaRazaoSocial, TM1.EmpresaCNPJ, TM1.EmpresaSede, T4.BancoNome, TM1.EmpresaAgencia, TM1.EmpresaAgenciaDigito, TM1.EmpresaConta, TM1.EmpresaPix, TM1.EmpresaPixTipo, TM1.EmpresaEmail, TM1.EmpresaLogradouro, TM1.EmpresaLogradouroNumero, TM1.EmpresaCEP, TM1.EmpresaBairro, TM1.EmpresaComplemento, T2.MunicipioNome, T2.MunicipioUF, TM1.EmpresaRepresentanteCPF, TM1.EmpresaRepresentanteNome, TM1.EmpresaRepresentanteEmail, TM1.EmpresaUtilizaRepresentanteAssinatura, TM1.EmpresaRepresentanteLogradouro, TM1.EmpresaRepresentanteNumero, TM1.EmpresaRepresentanteCEP, TM1.EmpresaRepresentanteBairro, TM1.EmpresaRepresentanteComplemento, T3.MunicipioNome AS EmpresaRepresentanteMunicipioNome, T3.MunicipioUF AS EmpresaRepresentanteMunicipioUF, TM1.EmpresaRepresentanteNacionalidade, TM1.EmpresaRepresentanteTelefone, TM1.EmpresaRepresentanteTelefoneDDD, TM1.MunicipioCodigo, TM1.EmpresaRepresentanteMunicipio AS EmpresaRepresentanteMunicipio, TM1.EmpresaBancoId AS EmpresaBancoId, TM1.EmpresaRepresentanteProfissao AS EmpresaRepresentanteProfissao FROM (((Empresa TM1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = TM1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.EmpresaRepresentanteMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = TM1.EmpresaBancoId) WHERE TM1.EmpresaId = :EmpresaId ORDER BY TM1.EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00138,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00139", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00139,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001310", "SELECT MunicipioNome AS EmpresaRepresentanteMunicipioNome, MunicipioUF AS EmpresaRepresentanteMunicipioUF FROM Municipio WHERE MunicipioCodigo = :EmpresaRepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT001310,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001311", "SELECT BancoNome FROM Banco WHERE BancoId = :EmpresaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001311,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001312", "SELECT ProfissaoId AS EmpresaRepresentanteProfissao FROM Profissao WHERE ProfissaoId = :EmpresaRepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT001312,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001313", "SELECT EmpresaId FROM Empresa WHERE EmpresaId = :EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001313,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001314", "SELECT EmpresaId FROM Empresa WHERE ( EmpresaId > :EmpresaId) ORDER BY EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001314,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001315", "SELECT EmpresaId FROM Empresa WHERE ( EmpresaId < :EmpresaId) ORDER BY EmpresaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001315,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001316", "SAVEPOINT gxupdate;INSERT INTO Empresa(EmpresaNomeFantasia, EmpresaRazaoSocial, EmpresaCNPJ, EmpresaSede, EmpresaAgencia, EmpresaAgenciaDigito, EmpresaConta, EmpresaPix, EmpresaPixTipo, EmpresaEmail, EmpresaLogradouro, EmpresaLogradouroNumero, EmpresaCEP, EmpresaBairro, EmpresaComplemento, EmpresaRepresentanteCPF, EmpresaRepresentanteNome, EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero, EmpresaRepresentanteCEP, EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD, MunicipioCodigo, EmpresaRepresentanteMunicipio, EmpresaBancoId, EmpresaRepresentanteProfissao) VALUES(:EmpresaNomeFantasia, :EmpresaRazaoSocial, :EmpresaCNPJ, :EmpresaSede, :EmpresaAgencia, :EmpresaAgenciaDigito, :EmpresaConta, :EmpresaPix, :EmpresaPixTipo, :EmpresaEmail, :EmpresaLogradouro, :EmpresaLogradouroNumero, :EmpresaCEP, :EmpresaBairro, :EmpresaComplemento, :EmpresaRepresentanteCPF, :EmpresaRepresentanteNome, :EmpresaRepresentanteEmail, :EmpresaUtilizaRepresentanteAssinatura, :EmpresaRepresentanteLogradouro, :EmpresaRepresentanteNumero, :EmpresaRepresentanteCEP, :EmpresaRepresentanteBairro, :EmpresaRepresentanteComplemento, :EmpresaRepresentanteNacionalidade, :EmpresaRepresentanteTelefone, :EmpresaRepresentanteTelefoneDDD, :MunicipioCodigo, :EmpresaRepresentanteMunicipio, :EmpresaBancoId, :EmpresaRepresentanteProfissao);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001316)
             ,new CursorDef("T001317", "SELECT currval('EmpresaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001318", "SAVEPOINT gxupdate;UPDATE Empresa SET EmpresaNomeFantasia=:EmpresaNomeFantasia, EmpresaRazaoSocial=:EmpresaRazaoSocial, EmpresaCNPJ=:EmpresaCNPJ, EmpresaSede=:EmpresaSede, EmpresaAgencia=:EmpresaAgencia, EmpresaAgenciaDigito=:EmpresaAgenciaDigito, EmpresaConta=:EmpresaConta, EmpresaPix=:EmpresaPix, EmpresaPixTipo=:EmpresaPixTipo, EmpresaEmail=:EmpresaEmail, EmpresaLogradouro=:EmpresaLogradouro, EmpresaLogradouroNumero=:EmpresaLogradouroNumero, EmpresaCEP=:EmpresaCEP, EmpresaBairro=:EmpresaBairro, EmpresaComplemento=:EmpresaComplemento, EmpresaRepresentanteCPF=:EmpresaRepresentanteCPF, EmpresaRepresentanteNome=:EmpresaRepresentanteNome, EmpresaRepresentanteEmail=:EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura=:EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro=:EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero=:EmpresaRepresentanteNumero, EmpresaRepresentanteCEP=:EmpresaRepresentanteCEP, EmpresaRepresentanteBairro=:EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento=:EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade=:EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone=:EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD=:EmpresaRepresentanteTelefoneDDD, MunicipioCodigo=:MunicipioCodigo, EmpresaRepresentanteMunicipio=:EmpresaRepresentanteMunicipio, EmpresaBancoId=:EmpresaBancoId, EmpresaRepresentanteProfissao=:EmpresaRepresentanteProfissao  WHERE EmpresaId = :EmpresaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001318)
             ,new CursorDef("T001319", "SAVEPOINT gxupdate;DELETE FROM Empresa  WHERE EmpresaId = :EmpresaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001319)
             ,new CursorDef("T001320", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001320,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001321", "SELECT MunicipioNome AS EmpresaRepresentanteMunicipioNome, MunicipioUF AS EmpresaRepresentanteMunicipioUF FROM Municipio WHERE MunicipioCodigo = :EmpresaRepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT001321,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001322", "SELECT BancoNome FROM Banco WHERE BancoId = :EmpresaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001322,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001323", "SELECT EmpresaId FROM Empresa ORDER BY EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001323,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((long[]) buf[25])[0] = rslt.getLong(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
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
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((long[]) buf[47])[0] = rslt.getLong(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((short[]) buf[63])[0] = rslt.getShort(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((int[]) buf[69])[0] = rslt.getInt(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
