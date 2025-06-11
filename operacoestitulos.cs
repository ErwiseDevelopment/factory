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
   public class operacoestitulos : GXDataArea
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
            A1010OperacoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesId"), "."), 18, MidpointRounding.ToEven));
            n1010OperacoesId = false;
            AssignAttri("", false, "A1010OperacoesId", ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A1010OperacoesId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A1034SacadoId = (int)(Math.Round(NumberUtil.Val( GetPar( "SacadoId"), "."), 18, MidpointRounding.ToEven));
            n1034SacadoId = false;
            AssignAttri("", false, "A1034SacadoId", ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A1034SacadoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operacoestitulos")), "operacoestitulos") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operacoestitulos")))) ;
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
                  AV7OperacoesTitulosId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesTitulosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(AV7OperacoesTitulosId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESTITULOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7OperacoesTitulosId), "ZZZZZZZZ9"), context));
                  AV19OperacoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV19OperacoesId", StringUtil.LTrimStr( (decimal)(AV19OperacoesId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19OperacoesId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Operacoes Titulos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public operacoestitulos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoestitulos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_OperacoesTitulosId ,
                           int aP2_OperacoesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7OperacoesTitulosId = aP1_OperacoesTitulosId;
         this.AV19OperacoesId = aP2_OperacoesId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbOperacoesTitulosStatus = new GXCombobox();
         cmbOperacoesTitulosTipo = new GXCombobox();
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
         if ( cmbOperacoesTitulosStatus.ItemCount > 0 )
         {
            A1027OperacoesTitulosStatus = cmbOperacoesTitulosStatus.getValidValue(A1027OperacoesTitulosStatus);
            n1027OperacoesTitulosStatus = false;
            AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacoesTitulosStatus.CurrentValue = StringUtil.RTrim( A1027OperacoesTitulosStatus);
            AssignProp("", false, cmbOperacoesTitulosStatus_Internalname, "Values", cmbOperacoesTitulosStatus.ToJavascriptSource(), true);
         }
         if ( cmbOperacoesTitulosTipo.ItemCount > 0 )
         {
            A1020OperacoesTitulosTipo = cmbOperacoesTitulosTipo.getValidValue(A1020OperacoesTitulosTipo);
            n1020OperacoesTitulosTipo = false;
            AssignAttri("", false, "A1020OperacoesTitulosTipo", A1020OperacoesTitulosTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacoesTitulosTipo.CurrentValue = StringUtil.RTrim( A1020OperacoesTitulosTipo);
            AssignProp("", false, cmbOperacoesTitulosTipo_Internalname, "Values", cmbOperacoesTitulosTipo.ToJavascriptSource(), true);
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablerazao_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtSacadoRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSacadoRazaoSocial_Internalname, "Sacado", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSacadoRazaoSocial_Internalname, A1035SacadoRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A1035SacadoRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSacadoRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSacadoRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnselecionar_Internalname, "", "Selecionar", bttBtnselecionar_Jsonclick, 7, "Selecionar", "", StyleString, ClassString, bttBtnselecionar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e1132106_client"+"'", TempTags, "", 2, "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacoesTitulosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacoesTitulosStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacoesTitulosStatus, cmbOperacoesTitulosStatus_Internalname, StringUtil.RTrim( A1027OperacoesTitulosStatus), 1, cmbOperacoesTitulosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbOperacoesTitulosStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_OperacoesTitulos.htm");
         cmbOperacoesTitulosStatus.CurrentValue = StringUtil.RTrim( A1027OperacoesTitulosStatus);
         AssignProp("", false, cmbOperacoesTitulosStatus_Internalname, "Values", (string)(cmbOperacoesTitulosStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacoesTitulosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacoesTitulosTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacoesTitulosTipo, cmbOperacoesTitulosTipo_Internalname, StringUtil.RTrim( A1020OperacoesTitulosTipo), 1, cmbOperacoesTitulosTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbOperacoesTitulosTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_OperacoesTitulos.htm");
         cmbOperacoesTitulosTipo.CurrentValue = StringUtil.RTrim( A1020OperacoesTitulosTipo);
         AssignProp("", false, cmbOperacoesTitulosTipo_Internalname, "Values", (string)(cmbOperacoesTitulosTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTitulosNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTitulosNumero_Internalname, "Número Nota", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosNumero_Internalname, ((0==A1021OperacoesTitulosNumero)&&IsIns( )||n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ",", ""))), ((0==A1021OperacoesTitulosNumero)&&IsIns( )||n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( ((edtOperacoesTitulosNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A1021OperacoesTitulosNumero), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1021OperacoesTitulosNumero), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacoesTitulosNumero_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTitulosDataEmissao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTitulosDataEmissao_Internalname, "Emissão", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacoesTitulosDataEmissao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosDataEmissao_Internalname, context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"), context.localUtil.Format( A1022OperacoesTitulosDataEmissao, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosDataEmissao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacoesTitulosDataEmissao_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_bitmap( context, edtOperacoesTitulosDataEmissao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacoesTitulosDataEmissao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OperacoesTitulos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTitulosDataVencimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTitulosDataVencimento_Internalname, "Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacoesTitulosDataVencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosDataVencimento_Internalname, context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"), context.localUtil.Format( A1023OperacoesTitulosDataVencimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosDataVencimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacoesTitulosDataVencimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_bitmap( context, edtOperacoesTitulosDataVencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacoesTitulosDataVencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OperacoesTitulos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTitulosValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTitulosValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosValor_Internalname, ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor)&&IsIns( )||n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor)&&IsIns( )||n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( ((edtOperacoesTitulosValor_Enabled!=0) ? context.localUtil.Format( A1024OperacoesTitulosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1024OperacoesTitulosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtOperacoesTitulosValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesTitulos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacoesTitulos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSacadoId_Internalname, ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ",", ""))), ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A1034SacadoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSacadoId_Jsonclick, 0, "Attribute", "", "", "", "", edtSacadoId_Visible, edtSacadoId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_OperacoesTitulos.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1019OperacoesTitulosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtOperacoesTitulosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosId_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacoesTitulosId_Visible, edtOperacoesTitulosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_OperacoesTitulos.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesId_Internalname, ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ",", ""))), ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A1010OperacoesId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesId_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacoesId_Visible, edtOperacoesId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_OperacoesTitulos.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosTaxa_Internalname, ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa)&&IsIns( )||n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa)&&IsIns( )||n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( ((edtOperacoesTitulosTaxa_Enabled!=0) ? context.localUtil.Format( A1026OperacoesTitulosTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1026OperacoesTitulosTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosTaxa_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacoesTitulosTaxa_Visible, edtOperacoesTitulosTaxa_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_OperacoesTitulos.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTitulosLiquido_Internalname, ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido)&&IsIns( )||n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido)&&IsIns( )||n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( ((edtOperacoesTitulosLiquido_Enabled!=0) ? context.localUtil.Format( A1025OperacoesTitulosLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1025OperacoesTitulosLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTitulosLiquido_Jsonclick, 0, "Attribute", "", "", "", "", edtOperacoesTitulosLiquido_Visible, edtOperacoesTitulosLiquido_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_OperacoesTitulos.htm");
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
         E12322 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1019OperacoesTitulosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1019OperacoesTitulosId"), ",", "."), 18, MidpointRounding.ToEven));
               Z1028OperacoesTitulosCreatedAt = context.localUtil.CToT( cgiGet( "Z1028OperacoesTitulosCreatedAt"), 0);
               n1028OperacoesTitulosCreatedAt = ((DateTime.MinValue==A1028OperacoesTitulosCreatedAt) ? true : false);
               Z1029OperacoesTitulosUpdatedAt = context.localUtil.CToT( cgiGet( "Z1029OperacoesTitulosUpdatedAt"), 0);
               n1029OperacoesTitulosUpdatedAt = ((DateTime.MinValue==A1029OperacoesTitulosUpdatedAt) ? true : false);
               Z1027OperacoesTitulosStatus = cgiGet( "Z1027OperacoesTitulosStatus");
               n1027OperacoesTitulosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1027OperacoesTitulosStatus)) ? true : false);
               Z1020OperacoesTitulosTipo = cgiGet( "Z1020OperacoesTitulosTipo");
               n1020OperacoesTitulosTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1020OperacoesTitulosTipo)) ? true : false);
               Z1021OperacoesTitulosNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1021OperacoesTitulosNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n1021OperacoesTitulosNumero = ((0==A1021OperacoesTitulosNumero) ? true : false);
               Z1022OperacoesTitulosDataEmissao = context.localUtil.CToD( cgiGet( "Z1022OperacoesTitulosDataEmissao"), 0);
               n1022OperacoesTitulosDataEmissao = ((DateTime.MinValue==A1022OperacoesTitulosDataEmissao) ? true : false);
               Z1023OperacoesTitulosDataVencimento = context.localUtil.CToD( cgiGet( "Z1023OperacoesTitulosDataVencimento"), 0);
               n1023OperacoesTitulosDataVencimento = ((DateTime.MinValue==A1023OperacoesTitulosDataVencimento) ? true : false);
               Z1024OperacoesTitulosValor = context.localUtil.CToN( cgiGet( "Z1024OperacoesTitulosValor"), ",", ".");
               n1024OperacoesTitulosValor = ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor) ? true : false);
               Z1025OperacoesTitulosLiquido = context.localUtil.CToN( cgiGet( "Z1025OperacoesTitulosLiquido"), ",", ".");
               n1025OperacoesTitulosLiquido = ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido) ? true : false);
               Z1026OperacoesTitulosTaxa = context.localUtil.CToN( cgiGet( "Z1026OperacoesTitulosTaxa"), ",", ".");
               n1026OperacoesTitulosTaxa = ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa) ? true : false);
               Z1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1010OperacoesId"), ",", "."), 18, MidpointRounding.ToEven));
               n1010OperacoesId = ((0==A1010OperacoesId) ? true : false);
               Z1034SacadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1034SacadoId"), ",", "."), 18, MidpointRounding.ToEven));
               n1034SacadoId = ((0==A1034SacadoId) ? true : false);
               A1028OperacoesTitulosCreatedAt = context.localUtil.CToT( cgiGet( "Z1028OperacoesTitulosCreatedAt"), 0);
               n1028OperacoesTitulosCreatedAt = false;
               n1028OperacoesTitulosCreatedAt = ((DateTime.MinValue==A1028OperacoesTitulosCreatedAt) ? true : false);
               A1029OperacoesTitulosUpdatedAt = context.localUtil.CToT( cgiGet( "Z1029OperacoesTitulosUpdatedAt"), 0);
               n1029OperacoesTitulosUpdatedAt = false;
               n1029OperacoesTitulosUpdatedAt = ((DateTime.MinValue==A1029OperacoesTitulosUpdatedAt) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1010OperacoesId"), ",", "."), 18, MidpointRounding.ToEven));
               n1010OperacoesId = ((0==A1010OperacoesId) ? true : false);
               N1034SacadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1034SacadoId"), ",", "."), 18, MidpointRounding.ToEven));
               n1034SacadoId = ((0==A1034SacadoId) ? true : false);
               AV7OperacoesTitulosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vOPERACOESTITULOSID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_OPERACOESID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_OperacoesId", StringUtil.LTrimStr( (decimal)(AV11Insert_OperacoesId), 9, 0));
               AV20Insert_SacadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SACADOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20Insert_SacadoId", StringUtil.LTrimStr( (decimal)(AV20Insert_SacadoId), 9, 0));
               A1028OperacoesTitulosCreatedAt = context.localUtil.CToT( cgiGet( "OPERACOESTITULOSCREATEDAT"), 0);
               n1028OperacoesTitulosCreatedAt = ((DateTime.MinValue==A1028OperacoesTitulosCreatedAt) ? true : false);
               A1029OperacoesTitulosUpdatedAt = context.localUtil.CToT( cgiGet( "OPERACOESTITULOSUPDATEDAT"), 0);
               n1029OperacoesTitulosUpdatedAt = ((DateTime.MinValue==A1029OperacoesTitulosUpdatedAt) ? true : false);
               AV23Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1035SacadoRazaoSocial = StringUtil.Upper( cgiGet( edtSacadoRazaoSocial_Internalname));
               n1035SacadoRazaoSocial = false;
               AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
               cmbOperacoesTitulosStatus.CurrentValue = cgiGet( cmbOperacoesTitulosStatus_Internalname);
               A1027OperacoesTitulosStatus = cgiGet( cmbOperacoesTitulosStatus_Internalname);
               n1027OperacoesTitulosStatus = false;
               AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
               n1027OperacoesTitulosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1027OperacoesTitulosStatus)) ? true : false);
               cmbOperacoesTitulosTipo.CurrentValue = cgiGet( cmbOperacoesTitulosTipo_Internalname);
               A1020OperacoesTitulosTipo = cgiGet( cmbOperacoesTitulosTipo_Internalname);
               n1020OperacoesTitulosTipo = false;
               AssignAttri("", false, "A1020OperacoesTitulosTipo", A1020OperacoesTitulosTipo);
               n1020OperacoesTitulosTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1020OperacoesTitulosTipo)) ? true : false);
               n1021OperacoesTitulosNumero = ((StringUtil.StrCmp(cgiGet( edtOperacoesTitulosNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTITULOSNUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1021OperacoesTitulosNumero = 0;
                  n1021OperacoesTitulosNumero = false;
                  AssignAttri("", false, "A1021OperacoesTitulosNumero", (n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ".", ""))));
               }
               else
               {
                  A1021OperacoesTitulosNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesTitulosNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1021OperacoesTitulosNumero", (n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtOperacoesTitulosDataEmissao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Emissão"}), 1, "OPERACOESTITULOSDATAEMISSAO");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosDataEmissao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
                  n1022OperacoesTitulosDataEmissao = false;
                  AssignAttri("", false, "A1022OperacoesTitulosDataEmissao", context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"));
               }
               else
               {
                  A1022OperacoesTitulosDataEmissao = context.localUtil.CToD( cgiGet( edtOperacoesTitulosDataEmissao_Internalname), 2);
                  n1022OperacoesTitulosDataEmissao = false;
                  AssignAttri("", false, "A1022OperacoesTitulosDataEmissao", context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"));
               }
               n1022OperacoesTitulosDataEmissao = ((DateTime.MinValue==A1022OperacoesTitulosDataEmissao) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtOperacoesTitulosDataVencimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Vencimento"}), 1, "OPERACOESTITULOSDATAVENCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosDataVencimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
                  n1023OperacoesTitulosDataVencimento = false;
                  AssignAttri("", false, "A1023OperacoesTitulosDataVencimento", context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"));
               }
               else
               {
                  A1023OperacoesTitulosDataVencimento = context.localUtil.CToD( cgiGet( edtOperacoesTitulosDataVencimento_Internalname), 2);
                  n1023OperacoesTitulosDataVencimento = false;
                  AssignAttri("", false, "A1023OperacoesTitulosDataVencimento", context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"));
               }
               n1023OperacoesTitulosDataVencimento = ((DateTime.MinValue==A1023OperacoesTitulosDataVencimento) ? true : false);
               n1024OperacoesTitulosValor = ((StringUtil.StrCmp(cgiGet( edtOperacoesTitulosValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTITULOSVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1024OperacoesTitulosValor = 0;
                  n1024OperacoesTitulosValor = false;
                  AssignAttri("", false, "A1024OperacoesTitulosValor", (n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ".", ""))));
               }
               else
               {
                  A1024OperacoesTitulosValor = context.localUtil.CToN( cgiGet( edtOperacoesTitulosValor_Internalname), ",", ".");
                  AssignAttri("", false, "A1024OperacoesTitulosValor", (n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ".", ""))));
               }
               n1034SacadoId = ((StringUtil.StrCmp(cgiGet( edtSacadoId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSacadoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSacadoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SACADOID");
                  AnyError = 1;
                  GX_FocusControl = edtSacadoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1034SacadoId = 0;
                  n1034SacadoId = false;
                  AssignAttri("", false, "A1034SacadoId", (n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
               }
               else
               {
                  A1034SacadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSacadoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1034SacadoId", (n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
               }
               A1019OperacoesTitulosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesTitulosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
               n1010OperacoesId = ((StringUtil.StrCmp(cgiGet( edtOperacoesId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESID");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1010OperacoesId = 0;
                  n1010OperacoesId = false;
                  AssignAttri("", false, "A1010OperacoesId", (n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
               }
               else
               {
                  A1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1010OperacoesId", (n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
               }
               n1026OperacoesTitulosTaxa = ((StringUtil.StrCmp(cgiGet( edtOperacoesTitulosTaxa_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosTaxa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosTaxa_Internalname), ",", ".") > 99999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTITULOSTAXA");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosTaxa_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1026OperacoesTitulosTaxa = 0;
                  n1026OperacoesTitulosTaxa = false;
                  AssignAttri("", false, "A1026OperacoesTitulosTaxa", (n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 16, 4, ".", ""))));
               }
               else
               {
                  A1026OperacoesTitulosTaxa = context.localUtil.CToN( cgiGet( edtOperacoesTitulosTaxa_Internalname), ",", ".");
                  AssignAttri("", false, "A1026OperacoesTitulosTaxa", (n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 16, 4, ".", ""))));
               }
               n1025OperacoesTitulosLiquido = ((StringUtil.StrCmp(cgiGet( edtOperacoesTitulosLiquido_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosLiquido_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTitulosLiquido_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTITULOSLIQUIDO");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosLiquido_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1025OperacoesTitulosLiquido = 0;
                  n1025OperacoesTitulosLiquido = false;
                  AssignAttri("", false, "A1025OperacoesTitulosLiquido", (n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ".", ""))));
               }
               else
               {
                  A1025OperacoesTitulosLiquido = context.localUtil.CToN( cgiGet( edtOperacoesTitulosLiquido_Internalname), ",", ".");
                  AssignAttri("", false, "A1025OperacoesTitulosLiquido", (n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"OperacoesTitulos");
               A1019OperacoesTitulosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesTitulosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
               forbiddenHiddens.Add("OperacoesTitulosId", context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_OperacoesId", context.localUtil.Format( (decimal)(AV11Insert_OperacoesId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SacadoId", context.localUtil.Format( (decimal)(AV20Insert_SacadoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("OperacoesTitulosCreatedAt", context.localUtil.Format( A1028OperacoesTitulosCreatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("OperacoesTitulosUpdatedAt", context.localUtil.Format( A1029OperacoesTitulosUpdatedAt, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("operacoestitulos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1019OperacoesTitulosId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesTitulosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
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
                     sMode106 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode106;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound106 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_320( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "OPERACOESTITULOSID");
                        AnyError = 1;
                        GX_FocusControl = edtOperacoesTitulosId_Internalname;
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
                           E12322 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13322 ();
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
            E13322 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll32106( ) ;
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
            DisableAttributes32106( ) ;
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

      protected void CONFIRM_320( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls32106( ) ;
            }
            else
            {
               CheckExtendedTable32106( ) ;
               CloseExtendedTableCursors32106( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption320( )
      {
      }

      protected void E12322( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "OperacoesId") == 0 )
               {
                  AV11Insert_OperacoesId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_OperacoesId", StringUtil.LTrimStr( (decimal)(AV11Insert_OperacoesId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SacadoId") == 0 )
               {
                  AV20Insert_SacadoId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20Insert_SacadoId", StringUtil.LTrimStr( (decimal)(AV20Insert_SacadoId), 9, 0));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtSacadoId_Visible = 0;
         AssignProp("", false, edtSacadoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSacadoId_Visible), 5, 0), true);
         edtOperacoesTitulosId_Visible = 0;
         AssignProp("", false, edtOperacoesTitulosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosId_Visible), 5, 0), true);
         edtOperacoesId_Visible = 0;
         AssignProp("", false, edtOperacoesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacoesId_Visible), 5, 0), true);
         edtOperacoesTitulosTaxa_Visible = 0;
         AssignProp("", false, edtOperacoesTitulosTaxa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosTaxa_Visible), 5, 0), true);
         edtOperacoesTitulosLiquido_Visible = 0;
         AssignProp("", false, edtOperacoesTitulosLiquido_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosLiquido_Visible), 5, 0), true);
      }

      protected void E13322( )
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

      protected void ZM32106( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1028OperacoesTitulosCreatedAt = T00323_A1028OperacoesTitulosCreatedAt[0];
               Z1029OperacoesTitulosUpdatedAt = T00323_A1029OperacoesTitulosUpdatedAt[0];
               Z1027OperacoesTitulosStatus = T00323_A1027OperacoesTitulosStatus[0];
               Z1020OperacoesTitulosTipo = T00323_A1020OperacoesTitulosTipo[0];
               Z1021OperacoesTitulosNumero = T00323_A1021OperacoesTitulosNumero[0];
               Z1022OperacoesTitulosDataEmissao = T00323_A1022OperacoesTitulosDataEmissao[0];
               Z1023OperacoesTitulosDataVencimento = T00323_A1023OperacoesTitulosDataVencimento[0];
               Z1024OperacoesTitulosValor = T00323_A1024OperacoesTitulosValor[0];
               Z1025OperacoesTitulosLiquido = T00323_A1025OperacoesTitulosLiquido[0];
               Z1026OperacoesTitulosTaxa = T00323_A1026OperacoesTitulosTaxa[0];
               Z1010OperacoesId = T00323_A1010OperacoesId[0];
               Z1034SacadoId = T00323_A1034SacadoId[0];
            }
            else
            {
               Z1028OperacoesTitulosCreatedAt = A1028OperacoesTitulosCreatedAt;
               Z1029OperacoesTitulosUpdatedAt = A1029OperacoesTitulosUpdatedAt;
               Z1027OperacoesTitulosStatus = A1027OperacoesTitulosStatus;
               Z1020OperacoesTitulosTipo = A1020OperacoesTitulosTipo;
               Z1021OperacoesTitulosNumero = A1021OperacoesTitulosNumero;
               Z1022OperacoesTitulosDataEmissao = A1022OperacoesTitulosDataEmissao;
               Z1023OperacoesTitulosDataVencimento = A1023OperacoesTitulosDataVencimento;
               Z1024OperacoesTitulosValor = A1024OperacoesTitulosValor;
               Z1025OperacoesTitulosLiquido = A1025OperacoesTitulosLiquido;
               Z1026OperacoesTitulosTaxa = A1026OperacoesTitulosTaxa;
               Z1010OperacoesId = A1010OperacoesId;
               Z1034SacadoId = A1034SacadoId;
            }
         }
         if ( GX_JID == -23 )
         {
            Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
            Z1028OperacoesTitulosCreatedAt = A1028OperacoesTitulosCreatedAt;
            Z1029OperacoesTitulosUpdatedAt = A1029OperacoesTitulosUpdatedAt;
            Z1027OperacoesTitulosStatus = A1027OperacoesTitulosStatus;
            Z1020OperacoesTitulosTipo = A1020OperacoesTitulosTipo;
            Z1021OperacoesTitulosNumero = A1021OperacoesTitulosNumero;
            Z1022OperacoesTitulosDataEmissao = A1022OperacoesTitulosDataEmissao;
            Z1023OperacoesTitulosDataVencimento = A1023OperacoesTitulosDataVencimento;
            Z1024OperacoesTitulosValor = A1024OperacoesTitulosValor;
            Z1025OperacoesTitulosLiquido = A1025OperacoesTitulosLiquido;
            Z1026OperacoesTitulosTaxa = A1026OperacoesTitulosTaxa;
            Z1010OperacoesId = A1010OperacoesId;
            Z1034SacadoId = A1034SacadoId;
            Z1035SacadoRazaoSocial = A1035SacadoRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         edtOperacoesTitulosId_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosId_Enabled), 5, 0), true);
         AV23Pgmname = "OperacoesTitulos";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtOperacoesTitulosId_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7OperacoesTitulosId) )
         {
            A1019OperacoesTitulosId = AV7OperacoesTitulosId;
            AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_OperacoesId) )
         {
            edtOperacoesId_Enabled = 0;
            AssignProp("", false, edtOperacoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesId_Enabled), 5, 0), true);
         }
         else
         {
            edtOperacoesId_Enabled = 1;
            AssignProp("", false, edtOperacoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_SacadoId) )
         {
            edtSacadoId_Enabled = 0;
            AssignProp("", false, edtSacadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSacadoId_Enabled), 5, 0), true);
         }
         else
         {
            edtSacadoId_Enabled = 1;
            AssignProp("", false, edtSacadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSacadoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1028OperacoesTitulosCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1028OperacoesTitulosCreatedAt = false;
            AssignAttri("", false, "A1028OperacoesTitulosCreatedAt", context.localUtil.TToC( A1028OperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A1029OperacoesTitulosUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1029OperacoesTitulosUpdatedAt = false;
            AssignAttri("", false, "A1029OperacoesTitulosUpdatedAt", context.localUtil.TToC( A1029OperacoesTitulosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  )
         {
            A1027OperacoesTitulosStatus = "PENDENTE";
            n1027OperacoesTitulosStatus = false;
            AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
         }
         if ( IsIns( )  )
         {
            cmbOperacoesTitulosStatus.Enabled = 0;
            AssignProp("", false, cmbOperacoesTitulosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesTitulosStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbOperacoesTitulosStatus.Enabled = 1;
            AssignProp("", false, cmbOperacoesTitulosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesTitulosStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbOperacoesTitulosStatus.Enabled = 0;
            AssignProp("", false, cmbOperacoesTitulosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesTitulosStatus.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_SacadoId) )
         {
            A1034SacadoId = AV20Insert_SacadoId;
            n1034SacadoId = false;
            AssignAttri("", false, "A1034SacadoId", ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_OperacoesId) )
         {
            A1010OperacoesId = AV11Insert_OperacoesId;
            n1010OperacoesId = false;
            AssignAttri("", false, "A1010OperacoesId", ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
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
            /* Using cursor T00325 */
            pr_default.execute(3, new Object[] {n1034SacadoId, A1034SacadoId});
            A1035SacadoRazaoSocial = T00325_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = T00325_n1035SacadoRazaoSocial[0];
            AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
            pr_default.close(3);
         }
      }

      protected void Load32106( )
      {
         /* Using cursor T00326 */
         pr_default.execute(4, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound106 = 1;
            A1028OperacoesTitulosCreatedAt = T00326_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = T00326_n1028OperacoesTitulosCreatedAt[0];
            A1029OperacoesTitulosUpdatedAt = T00326_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = T00326_n1029OperacoesTitulosUpdatedAt[0];
            A1027OperacoesTitulosStatus = T00326_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = T00326_n1027OperacoesTitulosStatus[0];
            AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
            A1035SacadoRazaoSocial = T00326_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = T00326_n1035SacadoRazaoSocial[0];
            AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
            A1020OperacoesTitulosTipo = T00326_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = T00326_n1020OperacoesTitulosTipo[0];
            AssignAttri("", false, "A1020OperacoesTitulosTipo", A1020OperacoesTitulosTipo);
            A1021OperacoesTitulosNumero = T00326_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = T00326_n1021OperacoesTitulosNumero[0];
            AssignAttri("", false, "A1021OperacoesTitulosNumero", ((0==A1021OperacoesTitulosNumero)&&IsIns( )||n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ".", ""))));
            A1022OperacoesTitulosDataEmissao = T00326_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = T00326_n1022OperacoesTitulosDataEmissao[0];
            AssignAttri("", false, "A1022OperacoesTitulosDataEmissao", context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"));
            A1023OperacoesTitulosDataVencimento = T00326_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = T00326_n1023OperacoesTitulosDataVencimento[0];
            AssignAttri("", false, "A1023OperacoesTitulosDataVencimento", context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"));
            A1024OperacoesTitulosValor = T00326_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = T00326_n1024OperacoesTitulosValor[0];
            AssignAttri("", false, "A1024OperacoesTitulosValor", ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor)&&IsIns( )||n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ".", ""))));
            A1025OperacoesTitulosLiquido = T00326_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = T00326_n1025OperacoesTitulosLiquido[0];
            AssignAttri("", false, "A1025OperacoesTitulosLiquido", ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido)&&IsIns( )||n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ".", ""))));
            A1026OperacoesTitulosTaxa = T00326_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = T00326_n1026OperacoesTitulosTaxa[0];
            AssignAttri("", false, "A1026OperacoesTitulosTaxa", ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa)&&IsIns( )||n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 16, 4, ".", ""))));
            A1010OperacoesId = T00326_A1010OperacoesId[0];
            n1010OperacoesId = T00326_n1010OperacoesId[0];
            AssignAttri("", false, "A1010OperacoesId", ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
            A1034SacadoId = T00326_A1034SacadoId[0];
            n1034SacadoId = T00326_n1034SacadoId[0];
            AssignAttri("", false, "A1034SacadoId", ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
            ZM32106( -23) ;
         }
         pr_default.close(4);
         OnLoadActions32106( ) ;
      }

      protected void OnLoadActions32106( )
      {
      }

      protected void CheckExtendedTable32106( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00324 */
         pr_default.execute(2, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1010OperacoesId) ) )
            {
               GX_msglist.addItem("Não existe 'Operacoes'.", "ForeignKeyNotFound", 1, "OPERACOESID");
               AnyError = 1;
               GX_FocusControl = edtOperacoesId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T00325 */
         pr_default.execute(3, new Object[] {n1034SacadoId, A1034SacadoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A1034SacadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sacado'.", "ForeignKeyNotFound", 1, "SACADOID");
               AnyError = 1;
               GX_FocusControl = edtSacadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1035SacadoRazaoSocial = T00325_A1035SacadoRazaoSocial[0];
         n1035SacadoRazaoSocial = T00325_n1035SacadoRazaoSocial[0];
         AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1035SacadoRazaoSocial)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sacado Razao Social", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1020OperacoesTitulosTipo, "NOTA_FISCAL") == 0 ) || ( StringUtil.StrCmp(A1020OperacoesTitulosTipo, "RPA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1020OperacoesTitulosTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "OPERACOESTITULOSTIPO");
            AnyError = 1;
            GX_FocusControl = cmbOperacoesTitulosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A1022OperacoesTitulosDataEmissao) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Emissão", "", "", "", "", "", "", "", ""), 1, "OPERACOESTITULOSDATAEMISSAO");
            AnyError = 1;
            GX_FocusControl = edtOperacoesTitulosDataEmissao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A1023OperacoesTitulosDataVencimento) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Vencimento", "", "", "", "", "", "", "", ""), 1, "OPERACOESTITULOSDATAVENCIMENTO");
            AnyError = 1;
            GX_FocusControl = edtOperacoesTitulosDataVencimento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A1024OperacoesTitulosValor) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Valor", "", "", "", "", "", "", "", ""), 1, "OPERACOESTITULOSVALOR");
            AnyError = 1;
            GX_FocusControl = edtOperacoesTitulosValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A1024OperacoesTitulosValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "OPERACOESTITULOSVALOR");
            AnyError = 1;
            GX_FocusControl = edtOperacoesTitulosValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "ACEITO") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "RECUSADO") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "LIQUIDADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1027OperacoesTitulosStatus)) ) )
         {
            GX_msglist.addItem("Campo Status fora do intervalo", "OutOfRange", 1, "OPERACOESTITULOSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors32106( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( int A1010OperacoesId )
      {
         /* Using cursor T00327 */
         pr_default.execute(5, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A1010OperacoesId) ) )
            {
               GX_msglist.addItem("Não existe 'Operacoes'.", "ForeignKeyNotFound", 1, "OPERACOESID");
               AnyError = 1;
               GX_FocusControl = edtOperacoesId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_25( int A1034SacadoId )
      {
         /* Using cursor T00328 */
         pr_default.execute(6, new Object[] {n1034SacadoId, A1034SacadoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A1034SacadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sacado'.", "ForeignKeyNotFound", 1, "SACADOID");
               AnyError = 1;
               GX_FocusControl = edtSacadoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1035SacadoRazaoSocial = T00328_A1035SacadoRazaoSocial[0];
         n1035SacadoRazaoSocial = T00328_n1035SacadoRazaoSocial[0];
         AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1035SacadoRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey32106( )
      {
         /* Using cursor T00329 */
         pr_default.execute(7, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound106 = 1;
         }
         else
         {
            RcdFound106 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00323 */
         pr_default.execute(1, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM32106( 23) ;
            RcdFound106 = 1;
            A1019OperacoesTitulosId = T00323_A1019OperacoesTitulosId[0];
            AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
            A1028OperacoesTitulosCreatedAt = T00323_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = T00323_n1028OperacoesTitulosCreatedAt[0];
            A1029OperacoesTitulosUpdatedAt = T00323_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = T00323_n1029OperacoesTitulosUpdatedAt[0];
            A1027OperacoesTitulosStatus = T00323_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = T00323_n1027OperacoesTitulosStatus[0];
            AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
            A1020OperacoesTitulosTipo = T00323_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = T00323_n1020OperacoesTitulosTipo[0];
            AssignAttri("", false, "A1020OperacoesTitulosTipo", A1020OperacoesTitulosTipo);
            A1021OperacoesTitulosNumero = T00323_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = T00323_n1021OperacoesTitulosNumero[0];
            AssignAttri("", false, "A1021OperacoesTitulosNumero", ((0==A1021OperacoesTitulosNumero)&&IsIns( )||n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ".", ""))));
            A1022OperacoesTitulosDataEmissao = T00323_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = T00323_n1022OperacoesTitulosDataEmissao[0];
            AssignAttri("", false, "A1022OperacoesTitulosDataEmissao", context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"));
            A1023OperacoesTitulosDataVencimento = T00323_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = T00323_n1023OperacoesTitulosDataVencimento[0];
            AssignAttri("", false, "A1023OperacoesTitulosDataVencimento", context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"));
            A1024OperacoesTitulosValor = T00323_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = T00323_n1024OperacoesTitulosValor[0];
            AssignAttri("", false, "A1024OperacoesTitulosValor", ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor)&&IsIns( )||n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ".", ""))));
            A1025OperacoesTitulosLiquido = T00323_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = T00323_n1025OperacoesTitulosLiquido[0];
            AssignAttri("", false, "A1025OperacoesTitulosLiquido", ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido)&&IsIns( )||n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ".", ""))));
            A1026OperacoesTitulosTaxa = T00323_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = T00323_n1026OperacoesTitulosTaxa[0];
            AssignAttri("", false, "A1026OperacoesTitulosTaxa", ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa)&&IsIns( )||n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 16, 4, ".", ""))));
            A1010OperacoesId = T00323_A1010OperacoesId[0];
            n1010OperacoesId = T00323_n1010OperacoesId[0];
            AssignAttri("", false, "A1010OperacoesId", ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
            A1034SacadoId = T00323_A1034SacadoId[0];
            n1034SacadoId = T00323_n1034SacadoId[0];
            AssignAttri("", false, "A1034SacadoId", ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
            Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load32106( ) ;
            if ( AnyError == 1 )
            {
               RcdFound106 = 0;
               InitializeNonKey32106( ) ;
            }
            Gx_mode = sMode106;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound106 = 0;
            InitializeNonKey32106( ) ;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode106;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey32106( ) ;
         if ( RcdFound106 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound106 = 0;
         /* Using cursor T003210 */
         pr_default.execute(8, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T003210_A1019OperacoesTitulosId[0] < A1019OperacoesTitulosId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T003210_A1019OperacoesTitulosId[0] > A1019OperacoesTitulosId ) ) )
            {
               A1019OperacoesTitulosId = T003210_A1019OperacoesTitulosId[0];
               AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
               RcdFound106 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound106 = 0;
         /* Using cursor T003211 */
         pr_default.execute(9, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T003211_A1019OperacoesTitulosId[0] > A1019OperacoesTitulosId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T003211_A1019OperacoesTitulosId[0] < A1019OperacoesTitulosId ) ) )
            {
               A1019OperacoesTitulosId = T003211_A1019OperacoesTitulosId[0];
               AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
               RcdFound106 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey32106( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert32106( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound106 == 1 )
            {
               if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
               {
                  A1019OperacoesTitulosId = Z1019OperacoesTitulosId;
                  AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "OPERACOESTITULOSID");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesTitulosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update32106( ) ;
                  GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert32106( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OPERACOESTITULOSID");
                     AnyError = 1;
                     GX_FocusControl = edtOperacoesTitulosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert32106( ) ;
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
         if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
         {
            A1019OperacoesTitulosId = Z1019OperacoesTitulosId;
            AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "OPERACOESTITULOSID");
            AnyError = 1;
            GX_FocusControl = edtOperacoesTitulosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbOperacoesTitulosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency32106( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00322 */
            pr_default.execute(0, new Object[] {A1019OperacoesTitulosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OperacoesTitulos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1028OperacoesTitulosCreatedAt != T00322_A1028OperacoesTitulosCreatedAt[0] ) || ( Z1029OperacoesTitulosUpdatedAt != T00322_A1029OperacoesTitulosUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1027OperacoesTitulosStatus, T00322_A1027OperacoesTitulosStatus[0]) != 0 ) || ( StringUtil.StrCmp(Z1020OperacoesTitulosTipo, T00322_A1020OperacoesTitulosTipo[0]) != 0 ) || ( Z1021OperacoesTitulosNumero != T00322_A1021OperacoesTitulosNumero[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z1022OperacoesTitulosDataEmissao ) != DateTimeUtil.ResetTime ( T00322_A1022OperacoesTitulosDataEmissao[0] ) ) || ( DateTimeUtil.ResetTime ( Z1023OperacoesTitulosDataVencimento ) != DateTimeUtil.ResetTime ( T00322_A1023OperacoesTitulosDataVencimento[0] ) ) || ( Z1024OperacoesTitulosValor != T00322_A1024OperacoesTitulosValor[0] ) || ( Z1025OperacoesTitulosLiquido != T00322_A1025OperacoesTitulosLiquido[0] ) || ( Z1026OperacoesTitulosTaxa != T00322_A1026OperacoesTitulosTaxa[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1010OperacoesId != T00322_A1010OperacoesId[0] ) || ( Z1034SacadoId != T00322_A1034SacadoId[0] ) )
            {
               if ( Z1028OperacoesTitulosCreatedAt != T00322_A1028OperacoesTitulosCreatedAt[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1028OperacoesTitulosCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1028OperacoesTitulosCreatedAt[0]);
               }
               if ( Z1029OperacoesTitulosUpdatedAt != T00322_A1029OperacoesTitulosUpdatedAt[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1029OperacoesTitulosUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1029OperacoesTitulosUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z1027OperacoesTitulosStatus, T00322_A1027OperacoesTitulosStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z1027OperacoesTitulosStatus);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1027OperacoesTitulosStatus[0]);
               }
               if ( StringUtil.StrCmp(Z1020OperacoesTitulosTipo, T00322_A1020OperacoesTitulosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1020OperacoesTitulosTipo);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1020OperacoesTitulosTipo[0]);
               }
               if ( Z1021OperacoesTitulosNumero != T00322_A1021OperacoesTitulosNumero[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosNumero");
                  GXUtil.WriteLogRaw("Old: ",Z1021OperacoesTitulosNumero);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1021OperacoesTitulosNumero[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1022OperacoesTitulosDataEmissao ) != DateTimeUtil.ResetTime ( T00322_A1022OperacoesTitulosDataEmissao[0] ) )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosDataEmissao");
                  GXUtil.WriteLogRaw("Old: ",Z1022OperacoesTitulosDataEmissao);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1022OperacoesTitulosDataEmissao[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1023OperacoesTitulosDataVencimento ) != DateTimeUtil.ResetTime ( T00322_A1023OperacoesTitulosDataVencimento[0] ) )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosDataVencimento");
                  GXUtil.WriteLogRaw("Old: ",Z1023OperacoesTitulosDataVencimento);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1023OperacoesTitulosDataVencimento[0]);
               }
               if ( Z1024OperacoesTitulosValor != T00322_A1024OperacoesTitulosValor[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosValor");
                  GXUtil.WriteLogRaw("Old: ",Z1024OperacoesTitulosValor);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1024OperacoesTitulosValor[0]);
               }
               if ( Z1025OperacoesTitulosLiquido != T00322_A1025OperacoesTitulosLiquido[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosLiquido");
                  GXUtil.WriteLogRaw("Old: ",Z1025OperacoesTitulosLiquido);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1025OperacoesTitulosLiquido[0]);
               }
               if ( Z1026OperacoesTitulosTaxa != T00322_A1026OperacoesTitulosTaxa[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesTitulosTaxa");
                  GXUtil.WriteLogRaw("Old: ",Z1026OperacoesTitulosTaxa);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1026OperacoesTitulosTaxa[0]);
               }
               if ( Z1010OperacoesId != T00322_A1010OperacoesId[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"OperacoesId");
                  GXUtil.WriteLogRaw("Old: ",Z1010OperacoesId);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1010OperacoesId[0]);
               }
               if ( Z1034SacadoId != T00322_A1034SacadoId[0] )
               {
                  GXUtil.WriteLog("operacoestitulos:[seudo value changed for attri]"+"SacadoId");
                  GXUtil.WriteLogRaw("Old: ",Z1034SacadoId);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1034SacadoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"OperacoesTitulos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert32106( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable32106( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM32106( 0) ;
            CheckOptimisticConcurrency32106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm32106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert32106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003212 */
                     pr_default.execute(10, new Object[] {n1028OperacoesTitulosCreatedAt, A1028OperacoesTitulosCreatedAt, n1029OperacoesTitulosUpdatedAt, A1029OperacoesTitulosUpdatedAt, n1027OperacoesTitulosStatus, A1027OperacoesTitulosStatus, n1020OperacoesTitulosTipo, A1020OperacoesTitulosTipo, n1021OperacoesTitulosNumero, A1021OperacoesTitulosNumero, n1022OperacoesTitulosDataEmissao, A1022OperacoesTitulosDataEmissao, n1023OperacoesTitulosDataVencimento, A1023OperacoesTitulosDataVencimento, n1024OperacoesTitulosValor, A1024OperacoesTitulosValor, n1025OperacoesTitulosLiquido, A1025OperacoesTitulosLiquido, n1026OperacoesTitulosTaxa, A1026OperacoesTitulosTaxa, n1010OperacoesId, A1010OperacoesId, n1034SacadoId, A1034SacadoId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003213 */
                     pr_default.execute(11);
                     A1019OperacoesTitulosId = T003213_A1019OperacoesTitulosId[0];
                     AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("OperacoesTitulos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption320( ) ;
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
               Load32106( ) ;
            }
            EndLevel32106( ) ;
         }
         CloseExtendedTableCursors32106( ) ;
      }

      protected void Update32106( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable32106( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency32106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm32106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate32106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003214 */
                     pr_default.execute(12, new Object[] {n1028OperacoesTitulosCreatedAt, A1028OperacoesTitulosCreatedAt, n1029OperacoesTitulosUpdatedAt, A1029OperacoesTitulosUpdatedAt, n1027OperacoesTitulosStatus, A1027OperacoesTitulosStatus, n1020OperacoesTitulosTipo, A1020OperacoesTitulosTipo, n1021OperacoesTitulosNumero, A1021OperacoesTitulosNumero, n1022OperacoesTitulosDataEmissao, A1022OperacoesTitulosDataEmissao, n1023OperacoesTitulosDataVencimento, A1023OperacoesTitulosDataVencimento, n1024OperacoesTitulosValor, A1024OperacoesTitulosValor, n1025OperacoesTitulosLiquido, A1025OperacoesTitulosLiquido, n1026OperacoesTitulosTaxa, A1026OperacoesTitulosTaxa, n1010OperacoesId, A1010OperacoesId, n1034SacadoId, A1034SacadoId, A1019OperacoesTitulosId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("OperacoesTitulos");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OperacoesTitulos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate32106( ) ;
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
            EndLevel32106( ) ;
         }
         CloseExtendedTableCursors32106( ) ;
      }

      protected void DeferredUpdate32106( )
      {
      }

      protected void delete( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency32106( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls32106( ) ;
            AfterConfirm32106( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete32106( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003215 */
                  pr_default.execute(13, new Object[] {A1019OperacoesTitulosId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("OperacoesTitulos");
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
         sMode106 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel32106( ) ;
         Gx_mode = sMode106;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls32106( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003216 */
            pr_default.execute(14, new Object[] {n1034SacadoId, A1034SacadoId});
            A1035SacadoRazaoSocial = T003216_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = T003216_n1035SacadoRazaoSocial[0];
            AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
            pr_default.close(14);
         }
      }

      protected void EndLevel32106( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete32106( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("operacoestitulos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues320( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("operacoestitulos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart32106( )
      {
         /* Scan By routine */
         /* Using cursor T003217 */
         pr_default.execute(15);
         RcdFound106 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound106 = 1;
            A1019OperacoesTitulosId = T003217_A1019OperacoesTitulosId[0];
            AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext32106( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound106 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound106 = 1;
            A1019OperacoesTitulosId = T003217_A1019OperacoesTitulosId[0];
            AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
         }
      }

      protected void ScanEnd32106( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm32106( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert32106( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate32106( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete32106( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete32106( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate32106( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes32106( )
      {
         edtSacadoRazaoSocial_Enabled = 0;
         AssignProp("", false, edtSacadoRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSacadoRazaoSocial_Enabled), 5, 0), true);
         cmbOperacoesTitulosStatus.Enabled = 0;
         AssignProp("", false, cmbOperacoesTitulosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesTitulosStatus.Enabled), 5, 0), true);
         cmbOperacoesTitulosTipo.Enabled = 0;
         AssignProp("", false, cmbOperacoesTitulosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesTitulosTipo.Enabled), 5, 0), true);
         edtOperacoesTitulosNumero_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosNumero_Enabled), 5, 0), true);
         edtOperacoesTitulosDataEmissao_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosDataEmissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosDataEmissao_Enabled), 5, 0), true);
         edtOperacoesTitulosDataVencimento_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosDataVencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosDataVencimento_Enabled), 5, 0), true);
         edtOperacoesTitulosValor_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosValor_Enabled), 5, 0), true);
         edtSacadoId_Enabled = 0;
         AssignProp("", false, edtSacadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSacadoId_Enabled), 5, 0), true);
         edtOperacoesTitulosId_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosId_Enabled), 5, 0), true);
         edtOperacoesId_Enabled = 0;
         AssignProp("", false, edtOperacoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesId_Enabled), 5, 0), true);
         edtOperacoesTitulosTaxa_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosTaxa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosTaxa_Enabled), 5, 0), true);
         edtOperacoesTitulosLiquido_Enabled = 0;
         AssignProp("", false, edtOperacoesTitulosLiquido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTitulosLiquido_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes32106( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues320( )
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
         GXEncryptionTmp = "operacoestitulos"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7OperacoesTitulosId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV19OperacoesId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("operacoestitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"OperacoesTitulos");
         forbiddenHiddens.Add("OperacoesTitulosId", context.localUtil.Format( (decimal)(A1019OperacoesTitulosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_OperacoesId", context.localUtil.Format( (decimal)(AV11Insert_OperacoesId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SacadoId", context.localUtil.Format( (decimal)(AV20Insert_SacadoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("OperacoesTitulosCreatedAt", context.localUtil.Format( A1028OperacoesTitulosCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("OperacoesTitulosUpdatedAt", context.localUtil.Format( A1029OperacoesTitulosUpdatedAt, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("operacoestitulos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1019OperacoesTitulosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1019OperacoesTitulosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1028OperacoesTitulosCreatedAt", context.localUtil.TToC( Z1028OperacoesTitulosCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1029OperacoesTitulosUpdatedAt", context.localUtil.TToC( Z1029OperacoesTitulosUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1027OperacoesTitulosStatus", Z1027OperacoesTitulosStatus);
         GxWebStd.gx_hidden_field( context, "Z1020OperacoesTitulosTipo", Z1020OperacoesTitulosTipo);
         GxWebStd.gx_hidden_field( context, "Z1021OperacoesTitulosNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1021OperacoesTitulosNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1022OperacoesTitulosDataEmissao", context.localUtil.DToC( Z1022OperacoesTitulosDataEmissao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1023OperacoesTitulosDataVencimento", context.localUtil.DToC( Z1023OperacoesTitulosDataVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1024OperacoesTitulosValor", StringUtil.LTrim( StringUtil.NToC( Z1024OperacoesTitulosValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1025OperacoesTitulosLiquido", StringUtil.LTrim( StringUtil.NToC( Z1025OperacoesTitulosLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1026OperacoesTitulosTaxa", StringUtil.LTrim( StringUtil.NToC( Z1026OperacoesTitulosTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1010OperacoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1010OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1034SacadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1034SacadoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1010OperacoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N1034SacadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vOPERACOESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19OperacoesId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vOPERACOESTITULOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7OperacoesTitulosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESTITULOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7OperacoesTitulosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_OPERACOESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SACADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_SacadoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "OPERACOESTITULOSCREATEDAT", context.localUtil.TToC( A1028OperacoesTitulosCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "OPERACOESTITULOSUPDATEDAT", context.localUtil.TToC( A1029OperacoesTitulosUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
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
         GXEncryptionTmp = "operacoestitulos"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7OperacoesTitulosId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV19OperacoesId,9,0));
         return formatLink("operacoestitulos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "OperacoesTitulos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Operacoes Titulos" ;
      }

      protected void InitializeNonKey32106( )
      {
         A1010OperacoesId = 0;
         n1010OperacoesId = false;
         AssignAttri("", false, "A1010OperacoesId", ((0==A1010OperacoesId)&&IsIns( )||n1010OperacoesId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ".", ""))));
         n1010OperacoesId = ((0==A1010OperacoesId) ? true : false);
         A1034SacadoId = 0;
         n1034SacadoId = false;
         AssignAttri("", false, "A1034SacadoId", ((0==A1034SacadoId)&&IsIns( )||n1034SacadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1034SacadoId), 9, 0, ".", ""))));
         n1034SacadoId = ((0==A1034SacadoId) ? true : false);
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         n1028OperacoesTitulosCreatedAt = false;
         AssignAttri("", false, "A1028OperacoesTitulosCreatedAt", context.localUtil.TToC( A1028OperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         n1029OperacoesTitulosUpdatedAt = false;
         AssignAttri("", false, "A1029OperacoesTitulosUpdatedAt", context.localUtil.TToC( A1029OperacoesTitulosUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1027OperacoesTitulosStatus = "";
         n1027OperacoesTitulosStatus = false;
         AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
         n1027OperacoesTitulosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1027OperacoesTitulosStatus)) ? true : false);
         A1035SacadoRazaoSocial = "";
         n1035SacadoRazaoSocial = false;
         AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
         A1020OperacoesTitulosTipo = "";
         n1020OperacoesTitulosTipo = false;
         AssignAttri("", false, "A1020OperacoesTitulosTipo", A1020OperacoesTitulosTipo);
         n1020OperacoesTitulosTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1020OperacoesTitulosTipo)) ? true : false);
         A1021OperacoesTitulosNumero = 0;
         n1021OperacoesTitulosNumero = false;
         AssignAttri("", false, "A1021OperacoesTitulosNumero", ((0==A1021OperacoesTitulosNumero)&&IsIns( )||n1021OperacoesTitulosNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1021OperacoesTitulosNumero), 9, 0, ".", ""))));
         n1021OperacoesTitulosNumero = ((0==A1021OperacoesTitulosNumero) ? true : false);
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         n1022OperacoesTitulosDataEmissao = false;
         AssignAttri("", false, "A1022OperacoesTitulosDataEmissao", context.localUtil.Format(A1022OperacoesTitulosDataEmissao, "99/99/99"));
         n1022OperacoesTitulosDataEmissao = ((DateTime.MinValue==A1022OperacoesTitulosDataEmissao) ? true : false);
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         n1023OperacoesTitulosDataVencimento = false;
         AssignAttri("", false, "A1023OperacoesTitulosDataVencimento", context.localUtil.Format(A1023OperacoesTitulosDataVencimento, "99/99/99"));
         n1023OperacoesTitulosDataVencimento = ((DateTime.MinValue==A1023OperacoesTitulosDataVencimento) ? true : false);
         A1024OperacoesTitulosValor = 0;
         n1024OperacoesTitulosValor = false;
         AssignAttri("", false, "A1024OperacoesTitulosValor", ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor)&&IsIns( )||n1024OperacoesTitulosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A1024OperacoesTitulosValor, 18, 2, ".", ""))));
         n1024OperacoesTitulosValor = ((Convert.ToDecimal(0)==A1024OperacoesTitulosValor) ? true : false);
         A1025OperacoesTitulosLiquido = 0;
         n1025OperacoesTitulosLiquido = false;
         AssignAttri("", false, "A1025OperacoesTitulosLiquido", ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido)&&IsIns( )||n1025OperacoesTitulosLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A1025OperacoesTitulosLiquido, 18, 2, ".", ""))));
         n1025OperacoesTitulosLiquido = ((Convert.ToDecimal(0)==A1025OperacoesTitulosLiquido) ? true : false);
         A1026OperacoesTitulosTaxa = 0;
         n1026OperacoesTitulosTaxa = false;
         AssignAttri("", false, "A1026OperacoesTitulosTaxa", ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa)&&IsIns( )||n1026OperacoesTitulosTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A1026OperacoesTitulosTaxa, 16, 4, ".", ""))));
         n1026OperacoesTitulosTaxa = ((Convert.ToDecimal(0)==A1026OperacoesTitulosTaxa) ? true : false);
         Z1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1027OperacoesTitulosStatus = "";
         Z1020OperacoesTitulosTipo = "";
         Z1021OperacoesTitulosNumero = 0;
         Z1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         Z1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         Z1024OperacoesTitulosValor = 0;
         Z1025OperacoesTitulosLiquido = 0;
         Z1026OperacoesTitulosTaxa = 0;
         Z1010OperacoesId = 0;
         Z1034SacadoId = 0;
      }

      protected void InitAll32106( )
      {
         A1019OperacoesTitulosId = 0;
         AssignAttri("", false, "A1019OperacoesTitulosId", StringUtil.LTrimStr( (decimal)(A1019OperacoesTitulosId), 9, 0));
         InitializeNonKey32106( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1028OperacoesTitulosCreatedAt = i1028OperacoesTitulosCreatedAt;
         n1028OperacoesTitulosCreatedAt = false;
         AssignAttri("", false, "A1028OperacoesTitulosCreatedAt", context.localUtil.TToC( A1028OperacoesTitulosCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1027OperacoesTitulosStatus = i1027OperacoesTitulosStatus;
         n1027OperacoesTitulosStatus = false;
         AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019221710", true, true);
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
         context.AddJavascriptSource("operacoestitulos.js", "?202561019221711", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSacadoRazaoSocial_Internalname = "SACADORAZAOSOCIAL";
         bttBtnselecionar_Internalname = "BTNSELECIONAR";
         divTablerazao_Internalname = "TABLERAZAO";
         cmbOperacoesTitulosStatus_Internalname = "OPERACOESTITULOSSTATUS";
         cmbOperacoesTitulosTipo_Internalname = "OPERACOESTITULOSTIPO";
         edtOperacoesTitulosNumero_Internalname = "OPERACOESTITULOSNUMERO";
         edtOperacoesTitulosDataEmissao_Internalname = "OPERACOESTITULOSDATAEMISSAO";
         edtOperacoesTitulosDataVencimento_Internalname = "OPERACOESTITULOSDATAVENCIMENTO";
         edtOperacoesTitulosValor_Internalname = "OPERACOESTITULOSVALOR";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSacadoId_Internalname = "SACADOID";
         edtOperacoesTitulosId_Internalname = "OPERACOESTITULOSID";
         edtOperacoesId_Internalname = "OPERACOESID";
         edtOperacoesTitulosTaxa_Internalname = "OPERACOESTITULOSTAXA";
         edtOperacoesTitulosLiquido_Internalname = "OPERACOESTITULOSLIQUIDO";
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
         Form.Caption = "Operacoes Titulos";
         edtOperacoesTitulosLiquido_Jsonclick = "";
         edtOperacoesTitulosLiquido_Enabled = 1;
         edtOperacoesTitulosLiquido_Visible = 1;
         edtOperacoesTitulosTaxa_Jsonclick = "";
         edtOperacoesTitulosTaxa_Enabled = 1;
         edtOperacoesTitulosTaxa_Visible = 1;
         edtOperacoesId_Jsonclick = "";
         edtOperacoesId_Enabled = 1;
         edtOperacoesId_Visible = 1;
         edtOperacoesTitulosId_Jsonclick = "";
         edtOperacoesTitulosId_Enabled = 0;
         edtOperacoesTitulosId_Visible = 1;
         edtSacadoId_Jsonclick = "";
         edtSacadoId_Enabled = 1;
         edtSacadoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtOperacoesTitulosValor_Jsonclick = "";
         edtOperacoesTitulosValor_Enabled = 1;
         edtOperacoesTitulosDataVencimento_Jsonclick = "";
         edtOperacoesTitulosDataVencimento_Enabled = 1;
         edtOperacoesTitulosDataEmissao_Jsonclick = "";
         edtOperacoesTitulosDataEmissao_Enabled = 1;
         edtOperacoesTitulosNumero_Jsonclick = "";
         edtOperacoesTitulosNumero_Enabled = 1;
         cmbOperacoesTitulosTipo_Jsonclick = "";
         cmbOperacoesTitulosTipo.Enabled = 1;
         cmbOperacoesTitulosStatus_Jsonclick = "";
         cmbOperacoesTitulosStatus.Enabled = 1;
         bttBtnselecionar_Visible = 1;
         edtSacadoRazaoSocial_Jsonclick = "";
         edtSacadoRazaoSocial_Enabled = 0;
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
         cmbOperacoesTitulosStatus.Name = "OPERACOESTITULOSSTATUS";
         cmbOperacoesTitulosStatus.WebTags = "";
         cmbOperacoesTitulosStatus.addItem("PENDENTE", "Pendente", 0);
         cmbOperacoesTitulosStatus.addItem("ACEITO", "Aceito", 0);
         cmbOperacoesTitulosStatus.addItem("RECUSADO", "Recusado", 0);
         cmbOperacoesTitulosStatus.addItem("VENCIDO", "Vencido", 0);
         cmbOperacoesTitulosStatus.addItem("LIQUIDADO", "Liquidado", 0);
         if ( cmbOperacoesTitulosStatus.ItemCount > 0 )
         {
            A1027OperacoesTitulosStatus = cmbOperacoesTitulosStatus.getValidValue(A1027OperacoesTitulosStatus);
            n1027OperacoesTitulosStatus = false;
            AssignAttri("", false, "A1027OperacoesTitulosStatus", A1027OperacoesTitulosStatus);
         }
         cmbOperacoesTitulosTipo.Name = "OPERACOESTITULOSTIPO";
         cmbOperacoesTitulosTipo.WebTags = "";
         cmbOperacoesTitulosTipo.addItem("", "NA", 0);
         cmbOperacoesTitulosTipo.addItem("NOTA_FISCAL", "Nota Fiscal", 0);
         cmbOperacoesTitulosTipo.addItem("RPA", "RPA", 0);
         if ( cmbOperacoesTitulosTipo.ItemCount > 0 )
         {
            A1020OperacoesTitulosTipo = cmbOperacoesTitulosTipo.getValidValue(A1020OperacoesTitulosTipo);
            n1020OperacoesTitulosTipo = false;
            AssignAttri("", false, "A1020OperacoesTitulosTipo", A1020OperacoesTitulosTipo);
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

      public void Valid_Sacadoid( )
      {
         n1035SacadoRazaoSocial = false;
         /* Using cursor T003216 */
         pr_default.execute(14, new Object[] {n1034SacadoId, A1034SacadoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A1034SacadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sacado'.", "ForeignKeyNotFound", 1, "SACADOID");
               AnyError = 1;
               GX_FocusControl = edtSacadoId_Internalname;
            }
         }
         A1035SacadoRazaoSocial = T003216_A1035SacadoRazaoSocial[0];
         n1035SacadoRazaoSocial = T003216_n1035SacadoRazaoSocial[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1035SacadoRazaoSocial", A1035SacadoRazaoSocial);
      }

      public void Valid_Operacoesid( )
      {
         /* Using cursor T003218 */
         pr_default.execute(16, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A1010OperacoesId) ) )
            {
               GX_msglist.addItem("Não existe 'Operacoes'.", "ForeignKeyNotFound", 1, "OPERACOESID");
               AnyError = 1;
               GX_FocusControl = edtOperacoesId_Internalname;
            }
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7OperacoesTitulosId","fld":"vOPERACOESTITULOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV19OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7OperacoesTitulosId","fld":"vOPERACOESTITULOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1019OperacoesTitulosId","fld":"OPERACOESTITULOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_OperacoesId","fld":"vINSERT_OPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV20Insert_SacadoId","fld":"vINSERT_SACADOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A1028OperacoesTitulosCreatedAt","fld":"OPERACOESTITULOSCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A1029OperacoesTitulosUpdatedAt","fld":"OPERACOESTITULOSUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13322","iparms":[]}""");
         setEventMetadata("'DOSELECIONAR'","""{"handler":"E1132106","iparms":[{"av":"A1034SacadoId","fld":"SACADOID","pic":"ZZZZZZZZ9","nullAv":"n1034SacadoId","type":"int"},{"av":"A1035SacadoRazaoSocial","fld":"SACADORAZAOSOCIAL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("'DOSELECIONAR'",""","oparms":[{"av":"A1035SacadoRazaoSocial","fld":"SACADORAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A1034SacadoId","fld":"SACADOID","pic":"ZZZZZZZZ9","nullAv":"n1034SacadoId","type":"int"}]}""");
         setEventMetadata("VALID_SACADORAZAOSOCIAL","""{"handler":"Valid_Sacadorazaosocial","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESTITULOSSTATUS","""{"handler":"Valid_Operacoestitulosstatus","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESTITULOSTIPO","""{"handler":"Valid_Operacoestitulostipo","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESTITULOSDATAEMISSAO","""{"handler":"Valid_Operacoestitulosdataemissao","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESTITULOSDATAVENCIMENTO","""{"handler":"Valid_Operacoestitulosdatavencimento","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESTITULOSVALOR","""{"handler":"Valid_Operacoestitulosvalor","iparms":[]}""");
         setEventMetadata("VALID_SACADOID","""{"handler":"Valid_Sacadoid","iparms":[{"av":"A1034SacadoId","fld":"SACADOID","pic":"ZZZZZZZZ9","nullAv":"n1034SacadoId","type":"int"},{"av":"A1035SacadoRazaoSocial","fld":"SACADORAZAOSOCIAL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_SACADOID",""","oparms":[{"av":"A1035SacadoRazaoSocial","fld":"SACADORAZAOSOCIAL","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_OPERACOESTITULOSID","""{"handler":"Valid_Operacoestitulosid","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESID","""{"handler":"Valid_Operacoesid","iparms":[{"av":"A1010OperacoesId","fld":"OPERACOESID","pic":"ZZZZZZZZ9","nullAv":"n1010OperacoesId","type":"int"}]}""");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1027OperacoesTitulosStatus = "";
         Z1020OperacoesTitulosTipo = "";
         Z1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         Z1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1027OperacoesTitulosStatus = "";
         A1020OperacoesTitulosTipo = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A1035SacadoRazaoSocial = "";
         bttBtnselecionar_Jsonclick = "";
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         AV23Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode106 = "";
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
         Z1035SacadoRazaoSocial = "";
         T00325_A1035SacadoRazaoSocial = new string[] {""} ;
         T00325_n1035SacadoRazaoSocial = new bool[] {false} ;
         T00326_A1019OperacoesTitulosId = new int[1] ;
         T00326_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00326_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         T00326_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00326_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         T00326_A1027OperacoesTitulosStatus = new string[] {""} ;
         T00326_n1027OperacoesTitulosStatus = new bool[] {false} ;
         T00326_A1035SacadoRazaoSocial = new string[] {""} ;
         T00326_n1035SacadoRazaoSocial = new bool[] {false} ;
         T00326_A1020OperacoesTitulosTipo = new string[] {""} ;
         T00326_n1020OperacoesTitulosTipo = new bool[] {false} ;
         T00326_A1021OperacoesTitulosNumero = new int[1] ;
         T00326_n1021OperacoesTitulosNumero = new bool[] {false} ;
         T00326_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T00326_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         T00326_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         T00326_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         T00326_A1024OperacoesTitulosValor = new decimal[1] ;
         T00326_n1024OperacoesTitulosValor = new bool[] {false} ;
         T00326_A1025OperacoesTitulosLiquido = new decimal[1] ;
         T00326_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         T00326_A1026OperacoesTitulosTaxa = new decimal[1] ;
         T00326_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         T00326_A1010OperacoesId = new int[1] ;
         T00326_n1010OperacoesId = new bool[] {false} ;
         T00326_A1034SacadoId = new int[1] ;
         T00326_n1034SacadoId = new bool[] {false} ;
         T00324_A1010OperacoesId = new int[1] ;
         T00324_n1010OperacoesId = new bool[] {false} ;
         T00327_A1010OperacoesId = new int[1] ;
         T00327_n1010OperacoesId = new bool[] {false} ;
         T00328_A1035SacadoRazaoSocial = new string[] {""} ;
         T00328_n1035SacadoRazaoSocial = new bool[] {false} ;
         T00329_A1019OperacoesTitulosId = new int[1] ;
         T00323_A1019OperacoesTitulosId = new int[1] ;
         T00323_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00323_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         T00323_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00323_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         T00323_A1027OperacoesTitulosStatus = new string[] {""} ;
         T00323_n1027OperacoesTitulosStatus = new bool[] {false} ;
         T00323_A1020OperacoesTitulosTipo = new string[] {""} ;
         T00323_n1020OperacoesTitulosTipo = new bool[] {false} ;
         T00323_A1021OperacoesTitulosNumero = new int[1] ;
         T00323_n1021OperacoesTitulosNumero = new bool[] {false} ;
         T00323_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T00323_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         T00323_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         T00323_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         T00323_A1024OperacoesTitulosValor = new decimal[1] ;
         T00323_n1024OperacoesTitulosValor = new bool[] {false} ;
         T00323_A1025OperacoesTitulosLiquido = new decimal[1] ;
         T00323_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         T00323_A1026OperacoesTitulosTaxa = new decimal[1] ;
         T00323_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         T00323_A1010OperacoesId = new int[1] ;
         T00323_n1010OperacoesId = new bool[] {false} ;
         T00323_A1034SacadoId = new int[1] ;
         T00323_n1034SacadoId = new bool[] {false} ;
         T003210_A1019OperacoesTitulosId = new int[1] ;
         T003211_A1019OperacoesTitulosId = new int[1] ;
         T00322_A1019OperacoesTitulosId = new int[1] ;
         T00322_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00322_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         T00322_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00322_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         T00322_A1027OperacoesTitulosStatus = new string[] {""} ;
         T00322_n1027OperacoesTitulosStatus = new bool[] {false} ;
         T00322_A1020OperacoesTitulosTipo = new string[] {""} ;
         T00322_n1020OperacoesTitulosTipo = new bool[] {false} ;
         T00322_A1021OperacoesTitulosNumero = new int[1] ;
         T00322_n1021OperacoesTitulosNumero = new bool[] {false} ;
         T00322_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T00322_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         T00322_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         T00322_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         T00322_A1024OperacoesTitulosValor = new decimal[1] ;
         T00322_n1024OperacoesTitulosValor = new bool[] {false} ;
         T00322_A1025OperacoesTitulosLiquido = new decimal[1] ;
         T00322_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         T00322_A1026OperacoesTitulosTaxa = new decimal[1] ;
         T00322_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         T00322_A1010OperacoesId = new int[1] ;
         T00322_n1010OperacoesId = new bool[] {false} ;
         T00322_A1034SacadoId = new int[1] ;
         T00322_n1034SacadoId = new bool[] {false} ;
         T003213_A1019OperacoesTitulosId = new int[1] ;
         T003216_A1035SacadoRazaoSocial = new string[] {""} ;
         T003216_n1035SacadoRazaoSocial = new bool[] {false} ;
         T003217_A1019OperacoesTitulosId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         i1027OperacoesTitulosStatus = "";
         T003218_A1010OperacoesId = new int[1] ;
         T003218_n1010OperacoesId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoestitulos__default(),
            new Object[][] {
                new Object[] {
               T00322_A1019OperacoesTitulosId, T00322_A1028OperacoesTitulosCreatedAt, T00322_n1028OperacoesTitulosCreatedAt, T00322_A1029OperacoesTitulosUpdatedAt, T00322_n1029OperacoesTitulosUpdatedAt, T00322_A1027OperacoesTitulosStatus, T00322_n1027OperacoesTitulosStatus, T00322_A1020OperacoesTitulosTipo, T00322_n1020OperacoesTitulosTipo, T00322_A1021OperacoesTitulosNumero,
               T00322_n1021OperacoesTitulosNumero, T00322_A1022OperacoesTitulosDataEmissao, T00322_n1022OperacoesTitulosDataEmissao, T00322_A1023OperacoesTitulosDataVencimento, T00322_n1023OperacoesTitulosDataVencimento, T00322_A1024OperacoesTitulosValor, T00322_n1024OperacoesTitulosValor, T00322_A1025OperacoesTitulosLiquido, T00322_n1025OperacoesTitulosLiquido, T00322_A1026OperacoesTitulosTaxa,
               T00322_n1026OperacoesTitulosTaxa, T00322_A1010OperacoesId, T00322_n1010OperacoesId, T00322_A1034SacadoId, T00322_n1034SacadoId
               }
               , new Object[] {
               T00323_A1019OperacoesTitulosId, T00323_A1028OperacoesTitulosCreatedAt, T00323_n1028OperacoesTitulosCreatedAt, T00323_A1029OperacoesTitulosUpdatedAt, T00323_n1029OperacoesTitulosUpdatedAt, T00323_A1027OperacoesTitulosStatus, T00323_n1027OperacoesTitulosStatus, T00323_A1020OperacoesTitulosTipo, T00323_n1020OperacoesTitulosTipo, T00323_A1021OperacoesTitulosNumero,
               T00323_n1021OperacoesTitulosNumero, T00323_A1022OperacoesTitulosDataEmissao, T00323_n1022OperacoesTitulosDataEmissao, T00323_A1023OperacoesTitulosDataVencimento, T00323_n1023OperacoesTitulosDataVencimento, T00323_A1024OperacoesTitulosValor, T00323_n1024OperacoesTitulosValor, T00323_A1025OperacoesTitulosLiquido, T00323_n1025OperacoesTitulosLiquido, T00323_A1026OperacoesTitulosTaxa,
               T00323_n1026OperacoesTitulosTaxa, T00323_A1010OperacoesId, T00323_n1010OperacoesId, T00323_A1034SacadoId, T00323_n1034SacadoId
               }
               , new Object[] {
               T00324_A1010OperacoesId
               }
               , new Object[] {
               T00325_A1035SacadoRazaoSocial, T00325_n1035SacadoRazaoSocial
               }
               , new Object[] {
               T00326_A1019OperacoesTitulosId, T00326_A1028OperacoesTitulosCreatedAt, T00326_n1028OperacoesTitulosCreatedAt, T00326_A1029OperacoesTitulosUpdatedAt, T00326_n1029OperacoesTitulosUpdatedAt, T00326_A1027OperacoesTitulosStatus, T00326_n1027OperacoesTitulosStatus, T00326_A1035SacadoRazaoSocial, T00326_n1035SacadoRazaoSocial, T00326_A1020OperacoesTitulosTipo,
               T00326_n1020OperacoesTitulosTipo, T00326_A1021OperacoesTitulosNumero, T00326_n1021OperacoesTitulosNumero, T00326_A1022OperacoesTitulosDataEmissao, T00326_n1022OperacoesTitulosDataEmissao, T00326_A1023OperacoesTitulosDataVencimento, T00326_n1023OperacoesTitulosDataVencimento, T00326_A1024OperacoesTitulosValor, T00326_n1024OperacoesTitulosValor, T00326_A1025OperacoesTitulosLiquido,
               T00326_n1025OperacoesTitulosLiquido, T00326_A1026OperacoesTitulosTaxa, T00326_n1026OperacoesTitulosTaxa, T00326_A1010OperacoesId, T00326_n1010OperacoesId, T00326_A1034SacadoId, T00326_n1034SacadoId
               }
               , new Object[] {
               T00327_A1010OperacoesId
               }
               , new Object[] {
               T00328_A1035SacadoRazaoSocial, T00328_n1035SacadoRazaoSocial
               }
               , new Object[] {
               T00329_A1019OperacoesTitulosId
               }
               , new Object[] {
               T003210_A1019OperacoesTitulosId
               }
               , new Object[] {
               T003211_A1019OperacoesTitulosId
               }
               , new Object[] {
               }
               , new Object[] {
               T003213_A1019OperacoesTitulosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003216_A1035SacadoRazaoSocial, T003216_n1035SacadoRazaoSocial
               }
               , new Object[] {
               T003217_A1019OperacoesTitulosId
               }
               , new Object[] {
               T003218_A1010OperacoesId
               }
            }
         );
         AV23Pgmname = "OperacoesTitulos";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound106 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7OperacoesTitulosId ;
      private int wcpOAV19OperacoesId ;
      private int Z1019OperacoesTitulosId ;
      private int Z1021OperacoesTitulosNumero ;
      private int Z1010OperacoesId ;
      private int Z1034SacadoId ;
      private int N1010OperacoesId ;
      private int N1034SacadoId ;
      private int A1010OperacoesId ;
      private int A1034SacadoId ;
      private int AV7OperacoesTitulosId ;
      private int AV19OperacoesId ;
      private int trnEnded ;
      private int edtSacadoRazaoSocial_Enabled ;
      private int bttBtnselecionar_Visible ;
      private int A1021OperacoesTitulosNumero ;
      private int edtOperacoesTitulosNumero_Enabled ;
      private int edtOperacoesTitulosDataEmissao_Enabled ;
      private int edtOperacoesTitulosDataVencimento_Enabled ;
      private int edtOperacoesTitulosValor_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSacadoId_Visible ;
      private int edtSacadoId_Enabled ;
      private int A1019OperacoesTitulosId ;
      private int edtOperacoesTitulosId_Enabled ;
      private int edtOperacoesTitulosId_Visible ;
      private int edtOperacoesId_Visible ;
      private int edtOperacoesId_Enabled ;
      private int edtOperacoesTitulosTaxa_Enabled ;
      private int edtOperacoesTitulosTaxa_Visible ;
      private int edtOperacoesTitulosLiquido_Enabled ;
      private int edtOperacoesTitulosLiquido_Visible ;
      private int AV11Insert_OperacoesId ;
      private int AV20Insert_SacadoId ;
      private int AV24GXV1 ;
      private int idxLst ;
      private decimal Z1024OperacoesTitulosValor ;
      private decimal Z1025OperacoesTitulosLiquido ;
      private decimal Z1026OperacoesTitulosTaxa ;
      private decimal A1024OperacoesTitulosValor ;
      private decimal A1026OperacoesTitulosTaxa ;
      private decimal A1025OperacoesTitulosLiquido ;
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
      private string cmbOperacoesTitulosStatus_Internalname ;
      private string cmbOperacoesTitulosTipo_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablerazao_Internalname ;
      private string edtSacadoRazaoSocial_Internalname ;
      private string TempTags ;
      private string edtSacadoRazaoSocial_Jsonclick ;
      private string bttBtnselecionar_Internalname ;
      private string bttBtnselecionar_Jsonclick ;
      private string cmbOperacoesTitulosStatus_Jsonclick ;
      private string cmbOperacoesTitulosTipo_Jsonclick ;
      private string edtOperacoesTitulosNumero_Internalname ;
      private string edtOperacoesTitulosNumero_Jsonclick ;
      private string edtOperacoesTitulosDataEmissao_Internalname ;
      private string edtOperacoesTitulosDataEmissao_Jsonclick ;
      private string edtOperacoesTitulosDataVencimento_Internalname ;
      private string edtOperacoesTitulosDataVencimento_Jsonclick ;
      private string edtOperacoesTitulosValor_Internalname ;
      private string edtOperacoesTitulosValor_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSacadoId_Internalname ;
      private string edtSacadoId_Jsonclick ;
      private string edtOperacoesTitulosId_Internalname ;
      private string edtOperacoesTitulosId_Jsonclick ;
      private string edtOperacoesId_Internalname ;
      private string edtOperacoesId_Jsonclick ;
      private string edtOperacoesTitulosTaxa_Internalname ;
      private string edtOperacoesTitulosTaxa_Jsonclick ;
      private string edtOperacoesTitulosLiquido_Internalname ;
      private string edtOperacoesTitulosLiquido_Jsonclick ;
      private string AV23Pgmname ;
      private string hsh ;
      private string sMode106 ;
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
      private DateTime Z1028OperacoesTitulosCreatedAt ;
      private DateTime Z1029OperacoesTitulosUpdatedAt ;
      private DateTime A1028OperacoesTitulosCreatedAt ;
      private DateTime A1029OperacoesTitulosUpdatedAt ;
      private DateTime i1028OperacoesTitulosCreatedAt ;
      private DateTime Z1022OperacoesTitulosDataEmissao ;
      private DateTime Z1023OperacoesTitulosDataVencimento ;
      private DateTime A1022OperacoesTitulosDataEmissao ;
      private DateTime A1023OperacoesTitulosDataVencimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1010OperacoesId ;
      private bool n1034SacadoId ;
      private bool wbErr ;
      private bool n1027OperacoesTitulosStatus ;
      private bool n1020OperacoesTitulosTipo ;
      private bool n1021OperacoesTitulosNumero ;
      private bool n1024OperacoesTitulosValor ;
      private bool n1026OperacoesTitulosTaxa ;
      private bool n1025OperacoesTitulosLiquido ;
      private bool n1028OperacoesTitulosCreatedAt ;
      private bool n1029OperacoesTitulosUpdatedAt ;
      private bool n1022OperacoesTitulosDataEmissao ;
      private bool n1023OperacoesTitulosDataVencimento ;
      private bool n1035SacadoRazaoSocial ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z1027OperacoesTitulosStatus ;
      private string Z1020OperacoesTitulosTipo ;
      private string A1027OperacoesTitulosStatus ;
      private string A1020OperacoesTitulosTipo ;
      private string A1035SacadoRazaoSocial ;
      private string Z1035SacadoRazaoSocial ;
      private string i1027OperacoesTitulosStatus ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbOperacoesTitulosStatus ;
      private GXCombobox cmbOperacoesTitulosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00325_A1035SacadoRazaoSocial ;
      private bool[] T00325_n1035SacadoRazaoSocial ;
      private int[] T00326_A1019OperacoesTitulosId ;
      private DateTime[] T00326_A1028OperacoesTitulosCreatedAt ;
      private bool[] T00326_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] T00326_A1029OperacoesTitulosUpdatedAt ;
      private bool[] T00326_n1029OperacoesTitulosUpdatedAt ;
      private string[] T00326_A1027OperacoesTitulosStatus ;
      private bool[] T00326_n1027OperacoesTitulosStatus ;
      private string[] T00326_A1035SacadoRazaoSocial ;
      private bool[] T00326_n1035SacadoRazaoSocial ;
      private string[] T00326_A1020OperacoesTitulosTipo ;
      private bool[] T00326_n1020OperacoesTitulosTipo ;
      private int[] T00326_A1021OperacoesTitulosNumero ;
      private bool[] T00326_n1021OperacoesTitulosNumero ;
      private DateTime[] T00326_A1022OperacoesTitulosDataEmissao ;
      private bool[] T00326_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] T00326_A1023OperacoesTitulosDataVencimento ;
      private bool[] T00326_n1023OperacoesTitulosDataVencimento ;
      private decimal[] T00326_A1024OperacoesTitulosValor ;
      private bool[] T00326_n1024OperacoesTitulosValor ;
      private decimal[] T00326_A1025OperacoesTitulosLiquido ;
      private bool[] T00326_n1025OperacoesTitulosLiquido ;
      private decimal[] T00326_A1026OperacoesTitulosTaxa ;
      private bool[] T00326_n1026OperacoesTitulosTaxa ;
      private int[] T00326_A1010OperacoesId ;
      private bool[] T00326_n1010OperacoesId ;
      private int[] T00326_A1034SacadoId ;
      private bool[] T00326_n1034SacadoId ;
      private int[] T00324_A1010OperacoesId ;
      private bool[] T00324_n1010OperacoesId ;
      private int[] T00327_A1010OperacoesId ;
      private bool[] T00327_n1010OperacoesId ;
      private string[] T00328_A1035SacadoRazaoSocial ;
      private bool[] T00328_n1035SacadoRazaoSocial ;
      private int[] T00329_A1019OperacoesTitulosId ;
      private int[] T00323_A1019OperacoesTitulosId ;
      private DateTime[] T00323_A1028OperacoesTitulosCreatedAt ;
      private bool[] T00323_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] T00323_A1029OperacoesTitulosUpdatedAt ;
      private bool[] T00323_n1029OperacoesTitulosUpdatedAt ;
      private string[] T00323_A1027OperacoesTitulosStatus ;
      private bool[] T00323_n1027OperacoesTitulosStatus ;
      private string[] T00323_A1020OperacoesTitulosTipo ;
      private bool[] T00323_n1020OperacoesTitulosTipo ;
      private int[] T00323_A1021OperacoesTitulosNumero ;
      private bool[] T00323_n1021OperacoesTitulosNumero ;
      private DateTime[] T00323_A1022OperacoesTitulosDataEmissao ;
      private bool[] T00323_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] T00323_A1023OperacoesTitulosDataVencimento ;
      private bool[] T00323_n1023OperacoesTitulosDataVencimento ;
      private decimal[] T00323_A1024OperacoesTitulosValor ;
      private bool[] T00323_n1024OperacoesTitulosValor ;
      private decimal[] T00323_A1025OperacoesTitulosLiquido ;
      private bool[] T00323_n1025OperacoesTitulosLiquido ;
      private decimal[] T00323_A1026OperacoesTitulosTaxa ;
      private bool[] T00323_n1026OperacoesTitulosTaxa ;
      private int[] T00323_A1010OperacoesId ;
      private bool[] T00323_n1010OperacoesId ;
      private int[] T00323_A1034SacadoId ;
      private bool[] T00323_n1034SacadoId ;
      private int[] T003210_A1019OperacoesTitulosId ;
      private int[] T003211_A1019OperacoesTitulosId ;
      private int[] T00322_A1019OperacoesTitulosId ;
      private DateTime[] T00322_A1028OperacoesTitulosCreatedAt ;
      private bool[] T00322_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] T00322_A1029OperacoesTitulosUpdatedAt ;
      private bool[] T00322_n1029OperacoesTitulosUpdatedAt ;
      private string[] T00322_A1027OperacoesTitulosStatus ;
      private bool[] T00322_n1027OperacoesTitulosStatus ;
      private string[] T00322_A1020OperacoesTitulosTipo ;
      private bool[] T00322_n1020OperacoesTitulosTipo ;
      private int[] T00322_A1021OperacoesTitulosNumero ;
      private bool[] T00322_n1021OperacoesTitulosNumero ;
      private DateTime[] T00322_A1022OperacoesTitulosDataEmissao ;
      private bool[] T00322_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] T00322_A1023OperacoesTitulosDataVencimento ;
      private bool[] T00322_n1023OperacoesTitulosDataVencimento ;
      private decimal[] T00322_A1024OperacoesTitulosValor ;
      private bool[] T00322_n1024OperacoesTitulosValor ;
      private decimal[] T00322_A1025OperacoesTitulosLiquido ;
      private bool[] T00322_n1025OperacoesTitulosLiquido ;
      private decimal[] T00322_A1026OperacoesTitulosTaxa ;
      private bool[] T00322_n1026OperacoesTitulosTaxa ;
      private int[] T00322_A1010OperacoesId ;
      private bool[] T00322_n1010OperacoesId ;
      private int[] T00322_A1034SacadoId ;
      private bool[] T00322_n1034SacadoId ;
      private int[] T003213_A1019OperacoesTitulosId ;
      private string[] T003216_A1035SacadoRazaoSocial ;
      private bool[] T003216_n1035SacadoRazaoSocial ;
      private int[] T003217_A1019OperacoesTitulosId ;
      private int[] T003218_A1010OperacoesId ;
      private bool[] T003218_n1010OperacoesId ;
   }

   public class operacoestitulos__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00322;
          prmT00322 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT00323;
          prmT00323 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT00324;
          prmT00324 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00325;
          prmT00325 = new Object[] {
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00326;
          prmT00326 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT00327;
          prmT00327 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00328;
          prmT00328 = new Object[] {
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00329;
          prmT00329 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT003210;
          prmT003210 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT003211;
          prmT003211 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT003212;
          prmT003212 = new Object[] {
          new ParDef("OperacoesTitulosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTitulosTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTitulosNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003213;
          prmT003213 = new Object[] {
          };
          Object[] prmT003214;
          prmT003214 = new Object[] {
          new ParDef("OperacoesTitulosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTitulosTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTitulosNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT003215;
          prmT003215 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmT003216;
          prmT003216 = new Object[] {
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003217;
          prmT003217 = new Object[] {
          };
          Object[] prmT003218;
          prmT003218 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00322", "SELECT OperacoesTitulosId, OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt, OperacoesTitulosStatus, OperacoesTitulosTipo, OperacoesTitulosNumero, OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento, OperacoesTitulosValor, OperacoesTitulosLiquido, OperacoesTitulosTaxa, OperacoesId, SacadoId FROM OperacoesTitulos WHERE OperacoesTitulosId = :OperacoesTitulosId  FOR UPDATE OF OperacoesTitulos NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00322,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00323", "SELECT OperacoesTitulosId, OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt, OperacoesTitulosStatus, OperacoesTitulosTipo, OperacoesTitulosNumero, OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento, OperacoesTitulosValor, OperacoesTitulosLiquido, OperacoesTitulosTaxa, OperacoesId, SacadoId FROM OperacoesTitulos WHERE OperacoesTitulosId = :OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00323,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00324", "SELECT OperacoesId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00324,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00325", "SELECT ClienteRazaoSocial AS SacadoRazaoSocial FROM Cliente WHERE ClienteId = :SacadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00325,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00326", "SELECT TM1.OperacoesTitulosId, TM1.OperacoesTitulosCreatedAt, TM1.OperacoesTitulosUpdatedAt, TM1.OperacoesTitulosStatus, T2.ClienteRazaoSocial AS SacadoRazaoSocial, TM1.OperacoesTitulosTipo, TM1.OperacoesTitulosNumero, TM1.OperacoesTitulosDataEmissao, TM1.OperacoesTitulosDataVencimento, TM1.OperacoesTitulosValor, TM1.OperacoesTitulosLiquido, TM1.OperacoesTitulosTaxa, TM1.OperacoesId, TM1.SacadoId AS SacadoId FROM (OperacoesTitulos TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.SacadoId) WHERE TM1.OperacoesTitulosId = :OperacoesTitulosId ORDER BY TM1.OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00326,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00327", "SELECT OperacoesId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00327,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00328", "SELECT ClienteRazaoSocial AS SacadoRazaoSocial FROM Cliente WHERE ClienteId = :SacadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00328,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00329", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE OperacoesTitulosId = :OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00329,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003210", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE ( OperacoesTitulosId > :OperacoesTitulosId) ORDER BY OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003210,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003211", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE ( OperacoesTitulosId < :OperacoesTitulosId) ORDER BY OperacoesTitulosId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT003211,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003212", "SAVEPOINT gxupdate;INSERT INTO OperacoesTitulos(OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt, OperacoesTitulosStatus, OperacoesTitulosTipo, OperacoesTitulosNumero, OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento, OperacoesTitulosValor, OperacoesTitulosLiquido, OperacoesTitulosTaxa, OperacoesId, SacadoId) VALUES(:OperacoesTitulosCreatedAt, :OperacoesTitulosUpdatedAt, :OperacoesTitulosStatus, :OperacoesTitulosTipo, :OperacoesTitulosNumero, :OperacoesTitulosDataEmissao, :OperacoesTitulosDataVencimento, :OperacoesTitulosValor, :OperacoesTitulosLiquido, :OperacoesTitulosTaxa, :OperacoesId, :SacadoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003212)
             ,new CursorDef("T003213", "SELECT currval('OperacoesTitulosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003214", "SAVEPOINT gxupdate;UPDATE OperacoesTitulos SET OperacoesTitulosCreatedAt=:OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt=:OperacoesTitulosUpdatedAt, OperacoesTitulosStatus=:OperacoesTitulosStatus, OperacoesTitulosTipo=:OperacoesTitulosTipo, OperacoesTitulosNumero=:OperacoesTitulosNumero, OperacoesTitulosDataEmissao=:OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento=:OperacoesTitulosDataVencimento, OperacoesTitulosValor=:OperacoesTitulosValor, OperacoesTitulosLiquido=:OperacoesTitulosLiquido, OperacoesTitulosTaxa=:OperacoesTitulosTaxa, OperacoesId=:OperacoesId, SacadoId=:SacadoId  WHERE OperacoesTitulosId = :OperacoesTitulosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003214)
             ,new CursorDef("T003215", "SAVEPOINT gxupdate;DELETE FROM OperacoesTitulos  WHERE OperacoesTitulosId = :OperacoesTitulosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003215)
             ,new CursorDef("T003216", "SELECT ClienteRazaoSocial AS SacadoRazaoSocial FROM Cliente WHERE ClienteId = :SacadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003216,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003217", "SELECT OperacoesTitulosId FROM OperacoesTitulos ORDER BY OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003217,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003218", "SELECT OperacoesId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003218,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
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
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
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
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
