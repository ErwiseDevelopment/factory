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
   public class representante : GXDataArea
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
            A977RepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( GetPar( "RepresentanteProfissao"), "."), 18, MidpointRounding.ToEven));
            n977RepresentanteProfissao = false;
            AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A977RepresentanteProfissao) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A991RepresentanteMunicipio = GetPar( "RepresentanteMunicipio");
            n991RepresentanteMunicipio = false;
            AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A991RepresentanteMunicipio) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
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
            gxLoad_18( A168ClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "representante")), "representante") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "representante")))) ;
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
                  AV7RepresentanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "RepresentanteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7RepresentanteId", StringUtil.LTrimStr( (decimal)(AV7RepresentanteId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vREPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RepresentanteId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Representante", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRepresentanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public representante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public representante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_RepresentanteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RepresentanteId = aP1_RepresentanteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbRepresentanteEstadoCivil = new GXCombobox();
         cmbRepresentanteTipo = new GXCombobox();
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
         if ( cmbRepresentanteEstadoCivil.ItemCount > 0 )
         {
            A984RepresentanteEstadoCivil = cmbRepresentanteEstadoCivil.getValidValue(A984RepresentanteEstadoCivil);
            n984RepresentanteEstadoCivil = false;
            AssignAttri("", false, "A984RepresentanteEstadoCivil", A984RepresentanteEstadoCivil);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRepresentanteEstadoCivil.CurrentValue = StringUtil.RTrim( A984RepresentanteEstadoCivil);
            AssignProp("", false, cmbRepresentanteEstadoCivil_Internalname, "Values", cmbRepresentanteEstadoCivil.ToJavascriptSource(), true);
         }
         if ( cmbRepresentanteTipo.ItemCount > 0 )
         {
            A998RepresentanteTipo = cmbRepresentanteTipo.getValidValue(A998RepresentanteTipo);
            n998RepresentanteTipo = false;
            AssignAttri("", false, "A998RepresentanteTipo", A998RepresentanteTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRepresentanteTipo.CurrentValue = StringUtil.RTrim( A998RepresentanteTipo);
            AssignProp("", false, cmbRepresentanteTipo_Internalname, "Values", cmbRepresentanteTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A978RepresentanteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtRepresentanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteNome_Internalname, A979RepresentanteNome, StringUtil.RTrim( context.localUtil.Format( A979RepresentanteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteRG_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteRG_Internalname, "RG", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteRG_Internalname, A980RepresentanteRG, StringUtil.RTrim( context.localUtil.Format( A980RepresentanteRG, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteRG_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteRG_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteOrgaoExpedidor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteOrgaoExpedidor_Internalname, "Orgao Expedidor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteOrgaoExpedidor_Internalname, A981RepresentanteOrgaoExpedidor, StringUtil.RTrim( context.localUtil.Format( A981RepresentanteOrgaoExpedidor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteOrgaoExpedidor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteOrgaoExpedidor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteRGUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteRGUF_Internalname, "RGUF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteRGUF_Internalname, A982RepresentanteRGUF, StringUtil.RTrim( context.localUtil.Format( A982RepresentanteRGUF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteRGUF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteRGUF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteCPF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteCPF_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteCPF_Internalname, A983RepresentanteCPF, StringUtil.RTrim( context.localUtil.Format( A983RepresentanteCPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteCPF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteCPF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRepresentanteEstadoCivil_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRepresentanteEstadoCivil_Internalname, "Estado Civil", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRepresentanteEstadoCivil, cmbRepresentanteEstadoCivil_Internalname, StringUtil.RTrim( A984RepresentanteEstadoCivil), 1, cmbRepresentanteEstadoCivil_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbRepresentanteEstadoCivil.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_Representante.htm");
         cmbRepresentanteEstadoCivil.CurrentValue = StringUtil.RTrim( A984RepresentanteEstadoCivil);
         AssignProp("", false, cmbRepresentanteEstadoCivil_Internalname, "Values", (string)(cmbRepresentanteEstadoCivil.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteNacionalidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteNacionalidade_Internalname, "Nacionalidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteNacionalidade_Internalname, A985RepresentanteNacionalidade, StringUtil.RTrim( context.localUtil.Format( A985RepresentanteNacionalidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteNacionalidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteNacionalidade_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedrepresentanteprofissao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockrepresentanteprofissao_Internalname, "Profissao", "", "", lblTextblockrepresentanteprofissao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_representanteprofissao.SetProperty("Caption", Combo_representanteprofissao_Caption);
         ucCombo_representanteprofissao.SetProperty("Cls", Combo_representanteprofissao_Cls);
         ucCombo_representanteprofissao.SetProperty("DataListProc", Combo_representanteprofissao_Datalistproc);
         ucCombo_representanteprofissao.SetProperty("DataListProcParametersPrefix", Combo_representanteprofissao_Datalistprocparametersprefix);
         ucCombo_representanteprofissao.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_representanteprofissao.SetProperty("DropDownOptionsData", AV15RepresentanteProfissao_Data);
         ucCombo_representanteprofissao.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_representanteprofissao_Internalname, "COMBO_REPRESENTANTEPROFISSAOContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteProfissao_Internalname, "Representante Profissao", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteProfissao_Internalname, ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ",", ""))), ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A977RepresentanteProfissao), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteProfissao_Jsonclick, 0, "Attribute", "", "", "", "", edtRepresentanteProfissao_Visible, edtRepresentanteProfissao_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Representante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteEmail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteEmail_Internalname, A986RepresentanteEmail, StringUtil.RTrim( context.localUtil.Format( A986RepresentanteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A986RepresentanteEmail, "", "", "", edtRepresentanteEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteCEP_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteCEP_Internalname, A987RepresentanteCEP, StringUtil.RTrim( context.localUtil.Format( A987RepresentanteCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteCEP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteCEP_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteLogradouro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteLogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteLogradouro_Internalname, A988RepresentanteLogradouro, StringUtil.RTrim( context.localUtil.Format( A988RepresentanteLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteLogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteBairro_Internalname, A989RepresentanteBairro, StringUtil.RTrim( context.localUtil.Format( A989RepresentanteBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteCidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteCidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteCidade_Internalname, A990RepresentanteCidade, StringUtil.RTrim( context.localUtil.Format( A990RepresentanteCidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteCidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteCidade_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedrepresentantemunicipio_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockrepresentantemunicipio_Internalname, "Municipio", "", "", lblTextblockrepresentantemunicipio_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_representantemunicipio.SetProperty("Caption", Combo_representantemunicipio_Caption);
         ucCombo_representantemunicipio.SetProperty("Cls", Combo_representantemunicipio_Cls);
         ucCombo_representantemunicipio.SetProperty("DataListProc", Combo_representantemunicipio_Datalistproc);
         ucCombo_representantemunicipio.SetProperty("DataListProcParametersPrefix", Combo_representantemunicipio_Datalistprocparametersprefix);
         ucCombo_representantemunicipio.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_representantemunicipio.SetProperty("DropDownOptionsData", AV22RepresentanteMunicipio_Data);
         ucCombo_representantemunicipio.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_representantemunicipio_Internalname, "COMBO_REPRESENTANTEMUNICIPIOContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteMunicipio_Internalname, "Representante Municipio", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteMunicipio_Internalname, A991RepresentanteMunicipio, StringUtil.RTrim( context.localUtil.Format( A991RepresentanteMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteMunicipio_Jsonclick, 0, "Attribute", "", "", "", "", edtRepresentanteMunicipio_Visible, edtRepresentanteMunicipio_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteLogradouroNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteLogradouroNumero_Internalname, "Logradouro Numero", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteLogradouroNumero_Internalname, ((0==A992RepresentanteLogradouroNumero)&&IsIns( )||n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A992RepresentanteLogradouroNumero), 10, 0, ",", ""))), ((0==A992RepresentanteLogradouroNumero)&&IsIns( )||n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( ((edtRepresentanteLogradouroNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A992RepresentanteLogradouroNumero), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A992RepresentanteLogradouroNumero), "ZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteLogradouroNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteLogradouroNumero_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteComplemento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteComplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteComplemento_Internalname, A993RepresentanteComplemento, StringUtil.RTrim( context.localUtil.Format( A993RepresentanteComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteComplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteComplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteDDD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteDDD_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteDDD_Internalname, ((0==A994RepresentanteDDD)&&IsIns( )||n994RepresentanteDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A994RepresentanteDDD), 4, 0, ",", ""))), ((0==A994RepresentanteDDD)&&IsIns( )||n994RepresentanteDDD ? "" : StringUtil.LTrim( ((edtRepresentanteDDD_Enabled!=0) ? context.localUtil.Format( (decimal)(A994RepresentanteDDD), "ZZZ9") : context.localUtil.Format( (decimal)(A994RepresentanteDDD), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteDDD_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteDDD_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteNumero_Internalname, "Numero", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteNumero_Internalname, ((0==A995RepresentanteNumero)&&IsIns( )||n995RepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A995RepresentanteNumero), 9, 0, ",", ""))), ((0==A995RepresentanteNumero)&&IsIns( )||n995RepresentanteNumero ? "" : StringUtil.LTrim( ((edtRepresentanteNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A995RepresentanteNumero), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A995RepresentanteNumero), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteNumero_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRepresentanteMunicipioUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepresentanteMunicipioUF_Internalname, "Municipio UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepresentanteMunicipioUF_Internalname, A996RepresentanteMunicipioUF, StringUtil.RTrim( context.localUtil.Format( A996RepresentanteMunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepresentanteMunicipioUF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRepresentanteMunicipioUF_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRepresentanteTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRepresentanteTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRepresentanteTipo, cmbRepresentanteTipo_Internalname, StringUtil.RTrim( A998RepresentanteTipo), 1, cmbRepresentanteTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbRepresentanteTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "", true, 0, "HLP_Representante.htm");
         cmbRepresentanteTipo.CurrentValue = StringUtil.RTrim( A998RepresentanteTipo);
         AssignProp("", false, cmbRepresentanteTipo_Internalname, "Values", (string)(cmbRepresentanteTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedclienteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockclienteid_Internalname, "Cliente", "", "", lblTextblockclienteid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_clienteid.SetProperty("Caption", Combo_clienteid_Caption);
         ucCombo_clienteid.SetProperty("Cls", Combo_clienteid_Cls);
         ucCombo_clienteid.SetProperty("DataListProc", Combo_clienteid_Datalistproc);
         ucCombo_clienteid.SetProperty("DataListProcParametersPrefix", Combo_clienteid_Datalistprocparametersprefix);
         ucCombo_clienteid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_clienteid.SetProperty("DropDownOptionsData", AV25ClienteId_Data);
         ucCombo_clienteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clienteid_Internalname, "COMBO_CLIENTEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,145);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Representante.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_representanteprofissao_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComborepresentanteprofissao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboRepresentanteProfissao), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComborepresentanteprofissao_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboRepresentanteProfissao), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20ComboRepresentanteProfissao), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComborepresentanteprofissao_Jsonclick, 0, "Attribute", "", "", "", "", edtavComborepresentanteprofissao_Visible, edtavComborepresentanteprofissao_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_representantemunicipio_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComborepresentantemunicipio_Internalname, AV23ComboRepresentanteMunicipio, StringUtil.RTrim( context.localUtil.Format( AV23ComboRepresentanteMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComborepresentantemunicipio_Jsonclick, 0, "Attribute", "", "", "", "", edtavComborepresentantemunicipio_Visible, edtavComborepresentantemunicipio_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Representante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_clienteid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ComboClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ComboClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV26ComboClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboclienteid_Visible, edtavComboclienteid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Representante.htm");
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
         E11302 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vREPRESENTANTEPROFISSAO_DATA"), AV15RepresentanteProfissao_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vREPRESENTANTEMUNICIPIO_DATA"), AV22RepresentanteMunicipio_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCLIENTEID_DATA"), AV25ClienteId_Data);
               /* Read saved values. */
               Z978RepresentanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z978RepresentanteId"), ",", "."), 18, MidpointRounding.ToEven));
               Z979RepresentanteNome = cgiGet( "Z979RepresentanteNome");
               n979RepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A979RepresentanteNome)) ? true : false);
               Z980RepresentanteRG = cgiGet( "Z980RepresentanteRG");
               n980RepresentanteRG = (String.IsNullOrEmpty(StringUtil.RTrim( A980RepresentanteRG)) ? true : false);
               Z981RepresentanteOrgaoExpedidor = cgiGet( "Z981RepresentanteOrgaoExpedidor");
               n981RepresentanteOrgaoExpedidor = (String.IsNullOrEmpty(StringUtil.RTrim( A981RepresentanteOrgaoExpedidor)) ? true : false);
               Z982RepresentanteRGUF = cgiGet( "Z982RepresentanteRGUF");
               n982RepresentanteRGUF = (String.IsNullOrEmpty(StringUtil.RTrim( A982RepresentanteRGUF)) ? true : false);
               Z983RepresentanteCPF = cgiGet( "Z983RepresentanteCPF");
               n983RepresentanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A983RepresentanteCPF)) ? true : false);
               Z984RepresentanteEstadoCivil = cgiGet( "Z984RepresentanteEstadoCivil");
               n984RepresentanteEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A984RepresentanteEstadoCivil)) ? true : false);
               Z985RepresentanteNacionalidade = cgiGet( "Z985RepresentanteNacionalidade");
               n985RepresentanteNacionalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A985RepresentanteNacionalidade)) ? true : false);
               Z986RepresentanteEmail = cgiGet( "Z986RepresentanteEmail");
               n986RepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A986RepresentanteEmail)) ? true : false);
               Z987RepresentanteCEP = cgiGet( "Z987RepresentanteCEP");
               n987RepresentanteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A987RepresentanteCEP)) ? true : false);
               Z988RepresentanteLogradouro = cgiGet( "Z988RepresentanteLogradouro");
               n988RepresentanteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A988RepresentanteLogradouro)) ? true : false);
               Z989RepresentanteBairro = cgiGet( "Z989RepresentanteBairro");
               n989RepresentanteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A989RepresentanteBairro)) ? true : false);
               Z990RepresentanteCidade = cgiGet( "Z990RepresentanteCidade");
               n990RepresentanteCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A990RepresentanteCidade)) ? true : false);
               Z992RepresentanteLogradouroNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z992RepresentanteLogradouroNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n992RepresentanteLogradouroNumero = ((0==A992RepresentanteLogradouroNumero) ? true : false);
               Z993RepresentanteComplemento = cgiGet( "Z993RepresentanteComplemento");
               n993RepresentanteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A993RepresentanteComplemento)) ? true : false);
               Z994RepresentanteDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z994RepresentanteDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n994RepresentanteDDD = ((0==A994RepresentanteDDD) ? true : false);
               Z995RepresentanteNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z995RepresentanteNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n995RepresentanteNumero = ((0==A995RepresentanteNumero) ? true : false);
               Z998RepresentanteTipo = cgiGet( "Z998RepresentanteTipo");
               n998RepresentanteTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A998RepresentanteTipo)) ? true : false);
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               Z977RepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z977RepresentanteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n977RepresentanteProfissao = ((0==A977RepresentanteProfissao) ? true : false);
               Z991RepresentanteMunicipio = cgiGet( "Z991RepresentanteMunicipio");
               n991RepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N977RepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N977RepresentanteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n977RepresentanteProfissao = ((0==A977RepresentanteProfissao) ? true : false);
               N991RepresentanteMunicipio = cgiGet( "N991RepresentanteMunicipio");
               n991RepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ? true : false);
               N168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               AV7RepresentanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vREPRESENTANTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_RepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_REPRESENTANTEPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_RepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV11Insert_RepresentanteProfissao), 9, 0));
               AV12Insert_RepresentanteMunicipio = cgiGet( "vINSERT_REPRESENTANTEMUNICIPIO");
               AssignAttri("", false, "AV12Insert_RepresentanteMunicipio", AV12Insert_RepresentanteMunicipio);
               AV13Insert_ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV13Insert_ClienteId), 9, 0));
               A999RepresentanteProfissaoDescricao = cgiGet( "REPRESENTANTEPROFISSAODESCRICAO");
               n999RepresentanteProfissaoDescricao = false;
               A997RepresentanteMunicipioNome = cgiGet( "REPRESENTANTEMUNICIPIONOME");
               n997RepresentanteMunicipioNome = false;
               AV27Pgmname = cgiGet( "vPGMNAME");
               Combo_representanteprofissao_Objectcall = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Objectcall");
               Combo_representanteprofissao_Class = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Class");
               Combo_representanteprofissao_Icontype = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Icontype");
               Combo_representanteprofissao_Icon = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Icon");
               Combo_representanteprofissao_Caption = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Caption");
               Combo_representanteprofissao_Tooltip = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Tooltip");
               Combo_representanteprofissao_Cls = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Cls");
               Combo_representanteprofissao_Selectedvalue_set = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Selectedvalue_set");
               Combo_representanteprofissao_Selectedvalue_get = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Selectedvalue_get");
               Combo_representanteprofissao_Selectedtext_set = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Selectedtext_set");
               Combo_representanteprofissao_Selectedtext_get = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Selectedtext_get");
               Combo_representanteprofissao_Gamoauthtoken = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Gamoauthtoken");
               Combo_representanteprofissao_Ddointernalname = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Ddointernalname");
               Combo_representanteprofissao_Titlecontrolalign = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Titlecontrolalign");
               Combo_representanteprofissao_Dropdownoptionstype = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Dropdownoptionstype");
               Combo_representanteprofissao_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Enabled"));
               Combo_representanteprofissao_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Visible"));
               Combo_representanteprofissao_Titlecontrolidtoreplace = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Titlecontrolidtoreplace");
               Combo_representanteprofissao_Datalisttype = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Datalisttype");
               Combo_representanteprofissao_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Allowmultipleselection"));
               Combo_representanteprofissao_Datalistfixedvalues = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Datalistfixedvalues");
               Combo_representanteprofissao_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Isgriditem"));
               Combo_representanteprofissao_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Hasdescription"));
               Combo_representanteprofissao_Datalistproc = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Datalistproc");
               Combo_representanteprofissao_Datalistprocparametersprefix = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Datalistprocparametersprefix");
               Combo_representanteprofissao_Remoteservicesparameters = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Remoteservicesparameters");
               Combo_representanteprofissao_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_representanteprofissao_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Includeonlyselectedoption"));
               Combo_representanteprofissao_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Includeselectalloption"));
               Combo_representanteprofissao_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Emptyitem"));
               Combo_representanteprofissao_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Includeaddnewoption"));
               Combo_representanteprofissao_Htmltemplate = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Htmltemplate");
               Combo_representanteprofissao_Multiplevaluestype = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Multiplevaluestype");
               Combo_representanteprofissao_Loadingdata = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Loadingdata");
               Combo_representanteprofissao_Noresultsfound = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Noresultsfound");
               Combo_representanteprofissao_Emptyitemtext = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Emptyitemtext");
               Combo_representanteprofissao_Onlyselectedvalues = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Onlyselectedvalues");
               Combo_representanteprofissao_Selectalltext = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Selectalltext");
               Combo_representanteprofissao_Multiplevaluesseparator = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Multiplevaluesseparator");
               Combo_representanteprofissao_Addnewoptiontext = cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Addnewoptiontext");
               Combo_representanteprofissao_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REPRESENTANTEPROFISSAO_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_representantemunicipio_Objectcall = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Objectcall");
               Combo_representantemunicipio_Class = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Class");
               Combo_representantemunicipio_Icontype = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Icontype");
               Combo_representantemunicipio_Icon = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Icon");
               Combo_representantemunicipio_Caption = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Caption");
               Combo_representantemunicipio_Tooltip = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Tooltip");
               Combo_representantemunicipio_Cls = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Cls");
               Combo_representantemunicipio_Selectedvalue_set = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Selectedvalue_set");
               Combo_representantemunicipio_Selectedvalue_get = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Selectedvalue_get");
               Combo_representantemunicipio_Selectedtext_set = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Selectedtext_set");
               Combo_representantemunicipio_Selectedtext_get = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Selectedtext_get");
               Combo_representantemunicipio_Gamoauthtoken = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Gamoauthtoken");
               Combo_representantemunicipio_Ddointernalname = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Ddointernalname");
               Combo_representantemunicipio_Titlecontrolalign = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Titlecontrolalign");
               Combo_representantemunicipio_Dropdownoptionstype = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Dropdownoptionstype");
               Combo_representantemunicipio_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Enabled"));
               Combo_representantemunicipio_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Visible"));
               Combo_representantemunicipio_Titlecontrolidtoreplace = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Titlecontrolidtoreplace");
               Combo_representantemunicipio_Datalisttype = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Datalisttype");
               Combo_representantemunicipio_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Allowmultipleselection"));
               Combo_representantemunicipio_Datalistfixedvalues = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Datalistfixedvalues");
               Combo_representantemunicipio_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Isgriditem"));
               Combo_representantemunicipio_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Hasdescription"));
               Combo_representantemunicipio_Datalistproc = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Datalistproc");
               Combo_representantemunicipio_Datalistprocparametersprefix = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Datalistprocparametersprefix");
               Combo_representantemunicipio_Remoteservicesparameters = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Remoteservicesparameters");
               Combo_representantemunicipio_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_representantemunicipio_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Includeonlyselectedoption"));
               Combo_representantemunicipio_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Includeselectalloption"));
               Combo_representantemunicipio_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Emptyitem"));
               Combo_representantemunicipio_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Includeaddnewoption"));
               Combo_representantemunicipio_Htmltemplate = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Htmltemplate");
               Combo_representantemunicipio_Multiplevaluestype = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Multiplevaluestype");
               Combo_representantemunicipio_Loadingdata = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Loadingdata");
               Combo_representantemunicipio_Noresultsfound = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Noresultsfound");
               Combo_representantemunicipio_Emptyitemtext = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Emptyitemtext");
               Combo_representantemunicipio_Onlyselectedvalues = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Onlyselectedvalues");
               Combo_representantemunicipio_Selectalltext = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Selectalltext");
               Combo_representantemunicipio_Multiplevaluesseparator = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Multiplevaluesseparator");
               Combo_representantemunicipio_Addnewoptiontext = cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Addnewoptiontext");
               Combo_representantemunicipio_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REPRESENTANTEMUNICIPIO_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_clienteid_Objectcall = cgiGet( "COMBO_CLIENTEID_Objectcall");
               Combo_clienteid_Class = cgiGet( "COMBO_CLIENTEID_Class");
               Combo_clienteid_Icontype = cgiGet( "COMBO_CLIENTEID_Icontype");
               Combo_clienteid_Icon = cgiGet( "COMBO_CLIENTEID_Icon");
               Combo_clienteid_Caption = cgiGet( "COMBO_CLIENTEID_Caption");
               Combo_clienteid_Tooltip = cgiGet( "COMBO_CLIENTEID_Tooltip");
               Combo_clienteid_Cls = cgiGet( "COMBO_CLIENTEID_Cls");
               Combo_clienteid_Selectedvalue_set = cgiGet( "COMBO_CLIENTEID_Selectedvalue_set");
               Combo_clienteid_Selectedvalue_get = cgiGet( "COMBO_CLIENTEID_Selectedvalue_get");
               Combo_clienteid_Selectedtext_set = cgiGet( "COMBO_CLIENTEID_Selectedtext_set");
               Combo_clienteid_Selectedtext_get = cgiGet( "COMBO_CLIENTEID_Selectedtext_get");
               Combo_clienteid_Gamoauthtoken = cgiGet( "COMBO_CLIENTEID_Gamoauthtoken");
               Combo_clienteid_Ddointernalname = cgiGet( "COMBO_CLIENTEID_Ddointernalname");
               Combo_clienteid_Titlecontrolalign = cgiGet( "COMBO_CLIENTEID_Titlecontrolalign");
               Combo_clienteid_Dropdownoptionstype = cgiGet( "COMBO_CLIENTEID_Dropdownoptionstype");
               Combo_clienteid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Enabled"));
               Combo_clienteid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Visible"));
               Combo_clienteid_Titlecontrolidtoreplace = cgiGet( "COMBO_CLIENTEID_Titlecontrolidtoreplace");
               Combo_clienteid_Datalisttype = cgiGet( "COMBO_CLIENTEID_Datalisttype");
               Combo_clienteid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Allowmultipleselection"));
               Combo_clienteid_Datalistfixedvalues = cgiGet( "COMBO_CLIENTEID_Datalistfixedvalues");
               Combo_clienteid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Isgriditem"));
               Combo_clienteid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Hasdescription"));
               Combo_clienteid_Datalistproc = cgiGet( "COMBO_CLIENTEID_Datalistproc");
               Combo_clienteid_Datalistprocparametersprefix = cgiGet( "COMBO_CLIENTEID_Datalistprocparametersprefix");
               Combo_clienteid_Remoteservicesparameters = cgiGet( "COMBO_CLIENTEID_Remoteservicesparameters");
               Combo_clienteid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIENTEID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_clienteid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeonlyselectedoption"));
               Combo_clienteid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeselectalloption"));
               Combo_clienteid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Emptyitem"));
               Combo_clienteid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeaddnewoption"));
               Combo_clienteid_Htmltemplate = cgiGet( "COMBO_CLIENTEID_Htmltemplate");
               Combo_clienteid_Multiplevaluestype = cgiGet( "COMBO_CLIENTEID_Multiplevaluestype");
               Combo_clienteid_Loadingdata = cgiGet( "COMBO_CLIENTEID_Loadingdata");
               Combo_clienteid_Noresultsfound = cgiGet( "COMBO_CLIENTEID_Noresultsfound");
               Combo_clienteid_Emptyitemtext = cgiGet( "COMBO_CLIENTEID_Emptyitemtext");
               Combo_clienteid_Onlyselectedvalues = cgiGet( "COMBO_CLIENTEID_Onlyselectedvalues");
               Combo_clienteid_Selectalltext = cgiGet( "COMBO_CLIENTEID_Selectalltext");
               Combo_clienteid_Multiplevaluesseparator = cgiGet( "COMBO_CLIENTEID_Multiplevaluesseparator");
               Combo_clienteid_Addnewoptiontext = cgiGet( "COMBO_CLIENTEID_Addnewoptiontext");
               Combo_clienteid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIENTEID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A978RepresentanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
               A979RepresentanteNome = cgiGet( edtRepresentanteNome_Internalname);
               n979RepresentanteNome = false;
               AssignAttri("", false, "A979RepresentanteNome", A979RepresentanteNome);
               n979RepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A979RepresentanteNome)) ? true : false);
               A980RepresentanteRG = cgiGet( edtRepresentanteRG_Internalname);
               n980RepresentanteRG = false;
               AssignAttri("", false, "A980RepresentanteRG", A980RepresentanteRG);
               n980RepresentanteRG = (String.IsNullOrEmpty(StringUtil.RTrim( A980RepresentanteRG)) ? true : false);
               A981RepresentanteOrgaoExpedidor = cgiGet( edtRepresentanteOrgaoExpedidor_Internalname);
               n981RepresentanteOrgaoExpedidor = false;
               AssignAttri("", false, "A981RepresentanteOrgaoExpedidor", A981RepresentanteOrgaoExpedidor);
               n981RepresentanteOrgaoExpedidor = (String.IsNullOrEmpty(StringUtil.RTrim( A981RepresentanteOrgaoExpedidor)) ? true : false);
               A982RepresentanteRGUF = cgiGet( edtRepresentanteRGUF_Internalname);
               n982RepresentanteRGUF = false;
               AssignAttri("", false, "A982RepresentanteRGUF", A982RepresentanteRGUF);
               n982RepresentanteRGUF = (String.IsNullOrEmpty(StringUtil.RTrim( A982RepresentanteRGUF)) ? true : false);
               A983RepresentanteCPF = cgiGet( edtRepresentanteCPF_Internalname);
               n983RepresentanteCPF = false;
               AssignAttri("", false, "A983RepresentanteCPF", A983RepresentanteCPF);
               n983RepresentanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A983RepresentanteCPF)) ? true : false);
               cmbRepresentanteEstadoCivil.CurrentValue = cgiGet( cmbRepresentanteEstadoCivil_Internalname);
               A984RepresentanteEstadoCivil = cgiGet( cmbRepresentanteEstadoCivil_Internalname);
               n984RepresentanteEstadoCivil = false;
               AssignAttri("", false, "A984RepresentanteEstadoCivil", A984RepresentanteEstadoCivil);
               n984RepresentanteEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A984RepresentanteEstadoCivil)) ? true : false);
               A985RepresentanteNacionalidade = cgiGet( edtRepresentanteNacionalidade_Internalname);
               n985RepresentanteNacionalidade = false;
               AssignAttri("", false, "A985RepresentanteNacionalidade", A985RepresentanteNacionalidade);
               n985RepresentanteNacionalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A985RepresentanteNacionalidade)) ? true : false);
               n977RepresentanteProfissao = ((StringUtil.StrCmp(cgiGet( edtRepresentanteProfissao_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRepresentanteProfissao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepresentanteProfissao_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTEPROFISSAO");
                  AnyError = 1;
                  GX_FocusControl = edtRepresentanteProfissao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A977RepresentanteProfissao = 0;
                  n977RepresentanteProfissao = false;
                  AssignAttri("", false, "A977RepresentanteProfissao", (n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
               }
               else
               {
                  A977RepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteProfissao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A977RepresentanteProfissao", (n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
               }
               A986RepresentanteEmail = cgiGet( edtRepresentanteEmail_Internalname);
               n986RepresentanteEmail = false;
               AssignAttri("", false, "A986RepresentanteEmail", A986RepresentanteEmail);
               n986RepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A986RepresentanteEmail)) ? true : false);
               A987RepresentanteCEP = cgiGet( edtRepresentanteCEP_Internalname);
               n987RepresentanteCEP = false;
               AssignAttri("", false, "A987RepresentanteCEP", A987RepresentanteCEP);
               n987RepresentanteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A987RepresentanteCEP)) ? true : false);
               A988RepresentanteLogradouro = cgiGet( edtRepresentanteLogradouro_Internalname);
               n988RepresentanteLogradouro = false;
               AssignAttri("", false, "A988RepresentanteLogradouro", A988RepresentanteLogradouro);
               n988RepresentanteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A988RepresentanteLogradouro)) ? true : false);
               A989RepresentanteBairro = cgiGet( edtRepresentanteBairro_Internalname);
               n989RepresentanteBairro = false;
               AssignAttri("", false, "A989RepresentanteBairro", A989RepresentanteBairro);
               n989RepresentanteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A989RepresentanteBairro)) ? true : false);
               A990RepresentanteCidade = cgiGet( edtRepresentanteCidade_Internalname);
               n990RepresentanteCidade = false;
               AssignAttri("", false, "A990RepresentanteCidade", A990RepresentanteCidade);
               n990RepresentanteCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A990RepresentanteCidade)) ? true : false);
               A991RepresentanteMunicipio = cgiGet( edtRepresentanteMunicipio_Internalname);
               n991RepresentanteMunicipio = false;
               AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
               n991RepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ? true : false);
               n992RepresentanteLogradouroNumero = ((StringUtil.StrCmp(cgiGet( edtRepresentanteLogradouroNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRepresentanteLogradouroNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepresentanteLogradouroNumero_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTELOGRADOURONUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtRepresentanteLogradouroNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A992RepresentanteLogradouroNumero = 0;
                  n992RepresentanteLogradouroNumero = false;
                  AssignAttri("", false, "A992RepresentanteLogradouroNumero", (n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A992RepresentanteLogradouroNumero), 10, 0, ".", ""))));
               }
               else
               {
                  A992RepresentanteLogradouroNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteLogradouroNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A992RepresentanteLogradouroNumero", (n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A992RepresentanteLogradouroNumero), 10, 0, ".", ""))));
               }
               A993RepresentanteComplemento = cgiGet( edtRepresentanteComplemento_Internalname);
               n993RepresentanteComplemento = false;
               AssignAttri("", false, "A993RepresentanteComplemento", A993RepresentanteComplemento);
               n993RepresentanteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A993RepresentanteComplemento)) ? true : false);
               n994RepresentanteDDD = ((StringUtil.StrCmp(cgiGet( edtRepresentanteDDD_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRepresentanteDDD_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepresentanteDDD_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTEDDD");
                  AnyError = 1;
                  GX_FocusControl = edtRepresentanteDDD_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A994RepresentanteDDD = 0;
                  n994RepresentanteDDD = false;
                  AssignAttri("", false, "A994RepresentanteDDD", (n994RepresentanteDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A994RepresentanteDDD), 4, 0, ".", ""))));
               }
               else
               {
                  A994RepresentanteDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteDDD_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A994RepresentanteDDD", (n994RepresentanteDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A994RepresentanteDDD), 4, 0, ".", ""))));
               }
               n995RepresentanteNumero = ((StringUtil.StrCmp(cgiGet( edtRepresentanteNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRepresentanteNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepresentanteNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTENUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtRepresentanteNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A995RepresentanteNumero = 0;
                  n995RepresentanteNumero = false;
                  AssignAttri("", false, "A995RepresentanteNumero", (n995RepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A995RepresentanteNumero), 9, 0, ".", ""))));
               }
               else
               {
                  A995RepresentanteNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A995RepresentanteNumero", (n995RepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A995RepresentanteNumero), 9, 0, ".", ""))));
               }
               A996RepresentanteMunicipioUF = StringUtil.Upper( cgiGet( edtRepresentanteMunicipioUF_Internalname));
               n996RepresentanteMunicipioUF = false;
               AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
               cmbRepresentanteTipo.CurrentValue = cgiGet( cmbRepresentanteTipo_Internalname);
               A998RepresentanteTipo = cgiGet( cmbRepresentanteTipo_Internalname);
               n998RepresentanteTipo = false;
               AssignAttri("", false, "A998RepresentanteTipo", A998RepresentanteTipo);
               n998RepresentanteTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A998RepresentanteTipo)) ? true : false);
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
               AV20ComboRepresentanteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComborepresentanteprofissao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboRepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV20ComboRepresentanteProfissao), 9, 0));
               AV23ComboRepresentanteMunicipio = cgiGet( edtavComborepresentantemunicipio_Internalname);
               AssignAttri("", false, "AV23ComboRepresentanteMunicipio", AV23ComboRepresentanteMunicipio);
               AV26ComboClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26ComboClienteId", StringUtil.LTrimStr( (decimal)(AV26ComboClienteId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Representante");
               A978RepresentanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRepresentanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
               forbiddenHiddens.Add("RepresentanteId", context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_RepresentanteProfissao", context.localUtil.Format( (decimal)(AV11Insert_RepresentanteProfissao), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_RepresentanteMunicipio", StringUtil.RTrim( context.localUtil.Format( AV12Insert_RepresentanteMunicipio, "")));
               forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV13Insert_ClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A978RepresentanteId != Z978RepresentanteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("representante:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A978RepresentanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "RepresentanteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
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
                     sMode104 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode104;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound104 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_300( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "REPRESENTANTEID");
                        AnyError = 1;
                        GX_FocusControl = edtRepresentanteId_Internalname;
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
                           E11302 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12302 ();
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
            E12302 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll30104( ) ;
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
            DisableAttributes30104( ) ;
         }
         AssignProp("", false, edtavComborepresentanteprofissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborepresentanteprofissao_Enabled), 5, 0), true);
         AssignProp("", false, edtavComborepresentantemunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborepresentantemunicipio_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Enabled), 5, 0), true);
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

      protected void CONFIRM_300( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls30104( ) ;
            }
            else
            {
               CheckExtendedTable30104( ) ;
               CloseExtendedTableCursors30104( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption300( )
      {
      }

      protected void E11302( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtClienteId_Visible = 0;
         AssignProp("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteId_Visible), 5, 0), true);
         AV26ComboClienteId = 0;
         AssignAttri("", false, "AV26ComboClienteId", StringUtil.LTrimStr( (decimal)(AV26ComboClienteId), 9, 0));
         edtavComboclienteid_Visible = 0;
         AssignProp("", false, edtavComboclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Visible), 5, 0), true);
         edtRepresentanteMunicipio_Visible = 0;
         AssignProp("", false, edtRepresentanteMunicipio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRepresentanteMunicipio_Visible), 5, 0), true);
         AV23ComboRepresentanteMunicipio = "";
         AssignAttri("", false, "AV23ComboRepresentanteMunicipio", AV23ComboRepresentanteMunicipio);
         edtavComborepresentantemunicipio_Visible = 0;
         AssignProp("", false, edtavComborepresentantemunicipio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComborepresentantemunicipio_Visible), 5, 0), true);
         edtRepresentanteProfissao_Visible = 0;
         AssignProp("", false, edtRepresentanteProfissao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRepresentanteProfissao_Visible), 5, 0), true);
         AV20ComboRepresentanteProfissao = 0;
         AssignAttri("", false, "AV20ComboRepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV20ComboRepresentanteProfissao), 9, 0));
         edtavComborepresentanteprofissao_Visible = 0;
         AssignProp("", false, edtavComborepresentanteprofissao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComborepresentanteprofissao_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOREPRESENTANTEPROFISSAO' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOREPRESENTANTEMUNICIPIO' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCLIENTEID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "RepresentanteProfissao") == 0 )
               {
                  AV11Insert_RepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_RepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV11Insert_RepresentanteProfissao), 9, 0));
                  if ( ! (0==AV11Insert_RepresentanteProfissao) )
                  {
                     AV20ComboRepresentanteProfissao = AV11Insert_RepresentanteProfissao;
                     AssignAttri("", false, "AV20ComboRepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV20ComboRepresentanteProfissao), 9, 0));
                     Combo_representanteprofissao_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboRepresentanteProfissao), 9, 0));
                     ucCombo_representanteprofissao.SendProperty(context, "", false, Combo_representanteprofissao_Internalname, "SelectedValue_set", Combo_representanteprofissao_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new representanteloaddvcombo(context ).execute(  "RepresentanteProfissao",  "GET",  false,  AV7RepresentanteId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_representanteprofissao_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_representanteprofissao.SendProperty(context, "", false, Combo_representanteprofissao_Internalname, "SelectedText_set", Combo_representanteprofissao_Selectedtext_set);
                     Combo_representanteprofissao_Enabled = false;
                     ucCombo_representanteprofissao.SendProperty(context, "", false, Combo_representanteprofissao_Internalname, "Enabled", StringUtil.BoolToStr( Combo_representanteprofissao_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "RepresentanteMunicipio") == 0 )
               {
                  AV12Insert_RepresentanteMunicipio = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV12Insert_RepresentanteMunicipio", AV12Insert_RepresentanteMunicipio);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_RepresentanteMunicipio)) )
                  {
                     AV23ComboRepresentanteMunicipio = AV12Insert_RepresentanteMunicipio;
                     AssignAttri("", false, "AV23ComboRepresentanteMunicipio", AV23ComboRepresentanteMunicipio);
                     Combo_representantemunicipio_Selectedvalue_set = AV23ComboRepresentanteMunicipio;
                     ucCombo_representantemunicipio.SendProperty(context, "", false, Combo_representantemunicipio_Internalname, "SelectedValue_set", Combo_representantemunicipio_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new representanteloaddvcombo(context ).execute(  "RepresentanteMunicipio",  "GET",  false,  AV7RepresentanteId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_representantemunicipio_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_representantemunicipio.SendProperty(context, "", false, Combo_representantemunicipio_Internalname, "SelectedText_set", Combo_representantemunicipio_Selectedtext_set);
                     Combo_representantemunicipio_Enabled = false;
                     ucCombo_representantemunicipio.SendProperty(context, "", false, Combo_representantemunicipio_Internalname, "Enabled", StringUtil.BoolToStr( Combo_representantemunicipio_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV13Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV13Insert_ClienteId), 9, 0));
                  if ( ! (0==AV13Insert_ClienteId) )
                  {
                     AV26ComboClienteId = AV13Insert_ClienteId;
                     AssignAttri("", false, "AV26ComboClienteId", StringUtil.LTrimStr( (decimal)(AV26ComboClienteId), 9, 0));
                     Combo_clienteid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV26ComboClienteId), 9, 0));
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedValue_set", Combo_clienteid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new representanteloaddvcombo(context ).execute(  "ClienteId",  "GET",  false,  AV7RepresentanteId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_clienteid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedText_set", Combo_clienteid_Selectedtext_set);
                     Combo_clienteid_Enabled = false;
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
                  }
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
      }

      protected void E12302( )
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

      protected void S132( )
      {
         /* 'LOADCOMBOCLIENTEID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new representanteloaddvcombo(context ).execute(  "ClienteId",  Gx_mode,  false,  AV7RepresentanteId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_clienteid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedValue_set", Combo_clienteid_Selectedvalue_set);
         Combo_clienteid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedText_set", Combo_clienteid_Selectedtext_set);
         AV26ComboClienteId = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV26ComboClienteId", StringUtil.LTrimStr( (decimal)(AV26ComboClienteId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_clienteid_Enabled = false;
            ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOREPRESENTANTEMUNICIPIO' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new representanteloaddvcombo(context ).execute(  "RepresentanteMunicipio",  Gx_mode,  false,  AV7RepresentanteId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_representantemunicipio_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_representantemunicipio.SendProperty(context, "", false, Combo_representantemunicipio_Internalname, "SelectedValue_set", Combo_representantemunicipio_Selectedvalue_set);
         Combo_representantemunicipio_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_representantemunicipio.SendProperty(context, "", false, Combo_representantemunicipio_Internalname, "SelectedText_set", Combo_representantemunicipio_Selectedtext_set);
         AV23ComboRepresentanteMunicipio = AV17ComboSelectedValue;
         AssignAttri("", false, "AV23ComboRepresentanteMunicipio", AV23ComboRepresentanteMunicipio);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_representantemunicipio_Enabled = false;
            ucCombo_representantemunicipio.SendProperty(context, "", false, Combo_representantemunicipio_Internalname, "Enabled", StringUtil.BoolToStr( Combo_representantemunicipio_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOREPRESENTANTEPROFISSAO' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new representanteloaddvcombo(context ).execute(  "RepresentanteProfissao",  Gx_mode,  false,  AV7RepresentanteId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_representanteprofissao_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_representanteprofissao.SendProperty(context, "", false, Combo_representanteprofissao_Internalname, "SelectedValue_set", Combo_representanteprofissao_Selectedvalue_set);
         Combo_representanteprofissao_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_representanteprofissao.SendProperty(context, "", false, Combo_representanteprofissao_Internalname, "SelectedText_set", Combo_representanteprofissao_Selectedtext_set);
         AV20ComboRepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboRepresentanteProfissao", StringUtil.LTrimStr( (decimal)(AV20ComboRepresentanteProfissao), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_representanteprofissao_Enabled = false;
            ucCombo_representanteprofissao.SendProperty(context, "", false, Combo_representanteprofissao_Internalname, "Enabled", StringUtil.BoolToStr( Combo_representanteprofissao_Enabled));
         }
      }

      protected void ZM30104( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z979RepresentanteNome = T00303_A979RepresentanteNome[0];
               Z980RepresentanteRG = T00303_A980RepresentanteRG[0];
               Z981RepresentanteOrgaoExpedidor = T00303_A981RepresentanteOrgaoExpedidor[0];
               Z982RepresentanteRGUF = T00303_A982RepresentanteRGUF[0];
               Z983RepresentanteCPF = T00303_A983RepresentanteCPF[0];
               Z984RepresentanteEstadoCivil = T00303_A984RepresentanteEstadoCivil[0];
               Z985RepresentanteNacionalidade = T00303_A985RepresentanteNacionalidade[0];
               Z986RepresentanteEmail = T00303_A986RepresentanteEmail[0];
               Z987RepresentanteCEP = T00303_A987RepresentanteCEP[0];
               Z988RepresentanteLogradouro = T00303_A988RepresentanteLogradouro[0];
               Z989RepresentanteBairro = T00303_A989RepresentanteBairro[0];
               Z990RepresentanteCidade = T00303_A990RepresentanteCidade[0];
               Z992RepresentanteLogradouroNumero = T00303_A992RepresentanteLogradouroNumero[0];
               Z993RepresentanteComplemento = T00303_A993RepresentanteComplemento[0];
               Z994RepresentanteDDD = T00303_A994RepresentanteDDD[0];
               Z995RepresentanteNumero = T00303_A995RepresentanteNumero[0];
               Z998RepresentanteTipo = T00303_A998RepresentanteTipo[0];
               Z168ClienteId = T00303_A168ClienteId[0];
               Z977RepresentanteProfissao = T00303_A977RepresentanteProfissao[0];
               Z991RepresentanteMunicipio = T00303_A991RepresentanteMunicipio[0];
            }
            else
            {
               Z979RepresentanteNome = A979RepresentanteNome;
               Z980RepresentanteRG = A980RepresentanteRG;
               Z981RepresentanteOrgaoExpedidor = A981RepresentanteOrgaoExpedidor;
               Z982RepresentanteRGUF = A982RepresentanteRGUF;
               Z983RepresentanteCPF = A983RepresentanteCPF;
               Z984RepresentanteEstadoCivil = A984RepresentanteEstadoCivil;
               Z985RepresentanteNacionalidade = A985RepresentanteNacionalidade;
               Z986RepresentanteEmail = A986RepresentanteEmail;
               Z987RepresentanteCEP = A987RepresentanteCEP;
               Z988RepresentanteLogradouro = A988RepresentanteLogradouro;
               Z989RepresentanteBairro = A989RepresentanteBairro;
               Z990RepresentanteCidade = A990RepresentanteCidade;
               Z992RepresentanteLogradouroNumero = A992RepresentanteLogradouroNumero;
               Z993RepresentanteComplemento = A993RepresentanteComplemento;
               Z994RepresentanteDDD = A994RepresentanteDDD;
               Z995RepresentanteNumero = A995RepresentanteNumero;
               Z998RepresentanteTipo = A998RepresentanteTipo;
               Z168ClienteId = A168ClienteId;
               Z977RepresentanteProfissao = A977RepresentanteProfissao;
               Z991RepresentanteMunicipio = A991RepresentanteMunicipio;
            }
         }
         if ( GX_JID == -17 )
         {
            Z978RepresentanteId = A978RepresentanteId;
            Z979RepresentanteNome = A979RepresentanteNome;
            Z980RepresentanteRG = A980RepresentanteRG;
            Z981RepresentanteOrgaoExpedidor = A981RepresentanteOrgaoExpedidor;
            Z982RepresentanteRGUF = A982RepresentanteRGUF;
            Z983RepresentanteCPF = A983RepresentanteCPF;
            Z984RepresentanteEstadoCivil = A984RepresentanteEstadoCivil;
            Z985RepresentanteNacionalidade = A985RepresentanteNacionalidade;
            Z986RepresentanteEmail = A986RepresentanteEmail;
            Z987RepresentanteCEP = A987RepresentanteCEP;
            Z988RepresentanteLogradouro = A988RepresentanteLogradouro;
            Z989RepresentanteBairro = A989RepresentanteBairro;
            Z990RepresentanteCidade = A990RepresentanteCidade;
            Z992RepresentanteLogradouroNumero = A992RepresentanteLogradouroNumero;
            Z993RepresentanteComplemento = A993RepresentanteComplemento;
            Z994RepresentanteDDD = A994RepresentanteDDD;
            Z995RepresentanteNumero = A995RepresentanteNumero;
            Z998RepresentanteTipo = A998RepresentanteTipo;
            Z168ClienteId = A168ClienteId;
            Z977RepresentanteProfissao = A977RepresentanteProfissao;
            Z991RepresentanteMunicipio = A991RepresentanteMunicipio;
            Z999RepresentanteProfissaoDescricao = A999RepresentanteProfissaoDescricao;
            Z996RepresentanteMunicipioUF = A996RepresentanteMunicipioUF;
            Z997RepresentanteMunicipioNome = A997RepresentanteMunicipioNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtRepresentanteId_Enabled = 0;
         AssignProp("", false, edtRepresentanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteId_Enabled), 5, 0), true);
         AV27Pgmname = "Representante";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         edtRepresentanteId_Enabled = 0;
         AssignProp("", false, edtRepresentanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RepresentanteId) )
         {
            A978RepresentanteId = AV7RepresentanteId;
            AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_RepresentanteProfissao) )
         {
            edtRepresentanteProfissao_Enabled = 0;
            AssignProp("", false, edtRepresentanteProfissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteProfissao_Enabled), 5, 0), true);
         }
         else
         {
            edtRepresentanteProfissao_Enabled = 1;
            AssignProp("", false, edtRepresentanteProfissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteProfissao_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_RepresentanteMunicipio)) )
         {
            edtRepresentanteMunicipio_Enabled = 0;
            AssignProp("", false, edtRepresentanteMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteMunicipio_Enabled), 5, 0), true);
         }
         else
         {
            edtRepresentanteMunicipio_Enabled = 1;
            AssignProp("", false, edtRepresentanteMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteMunicipio_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_RepresentanteProfissao) )
         {
            A977RepresentanteProfissao = AV11Insert_RepresentanteProfissao;
            n977RepresentanteProfissao = false;
            AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV20ComboRepresentanteProfissao) )
            {
               A977RepresentanteProfissao = 0;
               n977RepresentanteProfissao = false;
               AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
               n977RepresentanteProfissao = true;
               n977RepresentanteProfissao = true;
               AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV20ComboRepresentanteProfissao) )
               {
                  A977RepresentanteProfissao = AV20ComboRepresentanteProfissao;
                  n977RepresentanteProfissao = false;
                  AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_RepresentanteMunicipio)) )
         {
            A991RepresentanteMunicipio = AV12Insert_RepresentanteMunicipio;
            n991RepresentanteMunicipio = false;
            AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboRepresentanteMunicipio)) )
            {
               A991RepresentanteMunicipio = "";
               n991RepresentanteMunicipio = false;
               AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
               n991RepresentanteMunicipio = true;
               n991RepresentanteMunicipio = true;
               AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboRepresentanteMunicipio)) )
               {
                  A991RepresentanteMunicipio = AV23ComboRepresentanteMunicipio;
                  n991RepresentanteMunicipio = false;
                  AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ClienteId) )
         {
            A168ClienteId = AV13Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV26ComboClienteId) )
            {
               A168ClienteId = 0;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               n168ClienteId = true;
               n168ClienteId = true;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV26ComboClienteId) )
               {
                  A168ClienteId = AV26ComboClienteId;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
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
            /* Using cursor T00305 */
            pr_default.execute(3, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
            A999RepresentanteProfissaoDescricao = T00305_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = T00305_n999RepresentanteProfissaoDescricao[0];
            pr_default.close(3);
            /* Using cursor T00306 */
            pr_default.execute(4, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
            A996RepresentanteMunicipioUF = T00306_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = T00306_n996RepresentanteMunicipioUF[0];
            AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
            A997RepresentanteMunicipioNome = T00306_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = T00306_n997RepresentanteMunicipioNome[0];
            pr_default.close(4);
         }
      }

      protected void Load30104( )
      {
         /* Using cursor T00307 */
         pr_default.execute(5, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound104 = 1;
            A979RepresentanteNome = T00307_A979RepresentanteNome[0];
            n979RepresentanteNome = T00307_n979RepresentanteNome[0];
            AssignAttri("", false, "A979RepresentanteNome", A979RepresentanteNome);
            A980RepresentanteRG = T00307_A980RepresentanteRG[0];
            n980RepresentanteRG = T00307_n980RepresentanteRG[0];
            AssignAttri("", false, "A980RepresentanteRG", A980RepresentanteRG);
            A981RepresentanteOrgaoExpedidor = T00307_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = T00307_n981RepresentanteOrgaoExpedidor[0];
            AssignAttri("", false, "A981RepresentanteOrgaoExpedidor", A981RepresentanteOrgaoExpedidor);
            A982RepresentanteRGUF = T00307_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = T00307_n982RepresentanteRGUF[0];
            AssignAttri("", false, "A982RepresentanteRGUF", A982RepresentanteRGUF);
            A983RepresentanteCPF = T00307_A983RepresentanteCPF[0];
            n983RepresentanteCPF = T00307_n983RepresentanteCPF[0];
            AssignAttri("", false, "A983RepresentanteCPF", A983RepresentanteCPF);
            A984RepresentanteEstadoCivil = T00307_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = T00307_n984RepresentanteEstadoCivil[0];
            AssignAttri("", false, "A984RepresentanteEstadoCivil", A984RepresentanteEstadoCivil);
            A985RepresentanteNacionalidade = T00307_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = T00307_n985RepresentanteNacionalidade[0];
            AssignAttri("", false, "A985RepresentanteNacionalidade", A985RepresentanteNacionalidade);
            A999RepresentanteProfissaoDescricao = T00307_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = T00307_n999RepresentanteProfissaoDescricao[0];
            A986RepresentanteEmail = T00307_A986RepresentanteEmail[0];
            n986RepresentanteEmail = T00307_n986RepresentanteEmail[0];
            AssignAttri("", false, "A986RepresentanteEmail", A986RepresentanteEmail);
            A987RepresentanteCEP = T00307_A987RepresentanteCEP[0];
            n987RepresentanteCEP = T00307_n987RepresentanteCEP[0];
            AssignAttri("", false, "A987RepresentanteCEP", A987RepresentanteCEP);
            A988RepresentanteLogradouro = T00307_A988RepresentanteLogradouro[0];
            n988RepresentanteLogradouro = T00307_n988RepresentanteLogradouro[0];
            AssignAttri("", false, "A988RepresentanteLogradouro", A988RepresentanteLogradouro);
            A989RepresentanteBairro = T00307_A989RepresentanteBairro[0];
            n989RepresentanteBairro = T00307_n989RepresentanteBairro[0];
            AssignAttri("", false, "A989RepresentanteBairro", A989RepresentanteBairro);
            A990RepresentanteCidade = T00307_A990RepresentanteCidade[0];
            n990RepresentanteCidade = T00307_n990RepresentanteCidade[0];
            AssignAttri("", false, "A990RepresentanteCidade", A990RepresentanteCidade);
            A992RepresentanteLogradouroNumero = T00307_A992RepresentanteLogradouroNumero[0];
            n992RepresentanteLogradouroNumero = T00307_n992RepresentanteLogradouroNumero[0];
            AssignAttri("", false, "A992RepresentanteLogradouroNumero", ((0==A992RepresentanteLogradouroNumero)&&IsIns( )||n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A992RepresentanteLogradouroNumero), 10, 0, ".", ""))));
            A993RepresentanteComplemento = T00307_A993RepresentanteComplemento[0];
            n993RepresentanteComplemento = T00307_n993RepresentanteComplemento[0];
            AssignAttri("", false, "A993RepresentanteComplemento", A993RepresentanteComplemento);
            A994RepresentanteDDD = T00307_A994RepresentanteDDD[0];
            n994RepresentanteDDD = T00307_n994RepresentanteDDD[0];
            AssignAttri("", false, "A994RepresentanteDDD", ((0==A994RepresentanteDDD)&&IsIns( )||n994RepresentanteDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A994RepresentanteDDD), 4, 0, ".", ""))));
            A995RepresentanteNumero = T00307_A995RepresentanteNumero[0];
            n995RepresentanteNumero = T00307_n995RepresentanteNumero[0];
            AssignAttri("", false, "A995RepresentanteNumero", ((0==A995RepresentanteNumero)&&IsIns( )||n995RepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A995RepresentanteNumero), 9, 0, ".", ""))));
            A996RepresentanteMunicipioUF = T00307_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = T00307_n996RepresentanteMunicipioUF[0];
            AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
            A997RepresentanteMunicipioNome = T00307_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = T00307_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = T00307_A998RepresentanteTipo[0];
            n998RepresentanteTipo = T00307_n998RepresentanteTipo[0];
            AssignAttri("", false, "A998RepresentanteTipo", A998RepresentanteTipo);
            A168ClienteId = T00307_A168ClienteId[0];
            n168ClienteId = T00307_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A977RepresentanteProfissao = T00307_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = T00307_n977RepresentanteProfissao[0];
            AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
            A991RepresentanteMunicipio = T00307_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = T00307_n991RepresentanteMunicipio[0];
            AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
            ZM30104( -17) ;
         }
         pr_default.close(5);
         OnLoadActions30104( ) ;
      }

      protected void OnLoadActions30104( )
      {
      }

      protected void CheckExtendedTable30104( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "SOLTEIRO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "CASADO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "DIVORCIADO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "VIUVO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "SEPARADO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "UNIAO_ESTAVEL") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A984RepresentanteEstadoCivil)) ) )
         {
            GX_msglist.addItem("Campo Representante Estado Civil fora do intervalo", "OutOfRange", 1, "REPRESENTANTEESTADOCIVIL");
            AnyError = 1;
            GX_FocusControl = cmbRepresentanteEstadoCivil_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00305 */
         pr_default.execute(3, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A977RepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representante Profissao'.", "ForeignKeyNotFound", 1, "REPRESENTANTEPROFISSAO");
               AnyError = 1;
               GX_FocusControl = edtRepresentanteProfissao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A999RepresentanteProfissaoDescricao = T00305_A999RepresentanteProfissaoDescricao[0];
         n999RepresentanteProfissaoDescricao = T00305_n999RepresentanteProfissaoDescricao[0];
         pr_default.close(3);
         if ( ! ( GxRegex.IsMatch(A986RepresentanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A986RepresentanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Representante Email não coincide com o padrão especificado", "OutOfRange", 1, "REPRESENTANTEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtRepresentanteEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00306 */
         pr_default.execute(4, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representantel Municipio'.", "ForeignKeyNotFound", 1, "REPRESENTANTEMUNICIPIO");
               AnyError = 1;
               GX_FocusControl = edtRepresentanteMunicipio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A996RepresentanteMunicipioUF = T00306_A996RepresentanteMunicipioUF[0];
         n996RepresentanteMunicipioUF = T00306_n996RepresentanteMunicipioUF[0];
         AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
         A997RepresentanteMunicipioNome = T00306_A997RepresentanteMunicipioNome[0];
         n997RepresentanteMunicipioNome = T00306_n997RepresentanteMunicipioNome[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A998RepresentanteTipo, "Representante") == 0 ) || ( StringUtil.StrCmp(A998RepresentanteTipo, "Responsavel_solidario") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A998RepresentanteTipo)) ) )
         {
            GX_msglist.addItem("Campo Representante Tipo fora do intervalo", "OutOfRange", 1, "REPRESENTANTETIPO");
            AnyError = 1;
            GX_FocusControl = cmbRepresentanteTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00304 */
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
      }

      protected void CloseExtendedTableCursors30104( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( int A977RepresentanteProfissao )
      {
         /* Using cursor T00308 */
         pr_default.execute(6, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A977RepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representante Profissao'.", "ForeignKeyNotFound", 1, "REPRESENTANTEPROFISSAO");
               AnyError = 1;
               GX_FocusControl = edtRepresentanteProfissao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A999RepresentanteProfissaoDescricao = T00308_A999RepresentanteProfissaoDescricao[0];
         n999RepresentanteProfissaoDescricao = T00308_n999RepresentanteProfissaoDescricao[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A999RepresentanteProfissaoDescricao)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_20( string A991RepresentanteMunicipio )
      {
         /* Using cursor T00309 */
         pr_default.execute(7, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representantel Municipio'.", "ForeignKeyNotFound", 1, "REPRESENTANTEMUNICIPIO");
               AnyError = 1;
               GX_FocusControl = edtRepresentanteMunicipio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A996RepresentanteMunicipioUF = T00309_A996RepresentanteMunicipioUF[0];
         n996RepresentanteMunicipioUF = T00309_n996RepresentanteMunicipioUF[0];
         AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
         A997RepresentanteMunicipioNome = T00309_A997RepresentanteMunicipioNome[0];
         n997RepresentanteMunicipioNome = T00309_n997RepresentanteMunicipioNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A996RepresentanteMunicipioUF)+"\""+","+"\""+GXUtil.EncodeJSConstant( A997RepresentanteMunicipioNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_18( int A168ClienteId )
      {
         /* Using cursor T003010 */
         pr_default.execute(8, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(8) == 101) )
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
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey30104( )
      {
         /* Using cursor T003011 */
         pr_default.execute(9, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound104 = 1;
         }
         else
         {
            RcdFound104 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00303 */
         pr_default.execute(1, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM30104( 17) ;
            RcdFound104 = 1;
            A978RepresentanteId = T00303_A978RepresentanteId[0];
            AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
            A979RepresentanteNome = T00303_A979RepresentanteNome[0];
            n979RepresentanteNome = T00303_n979RepresentanteNome[0];
            AssignAttri("", false, "A979RepresentanteNome", A979RepresentanteNome);
            A980RepresentanteRG = T00303_A980RepresentanteRG[0];
            n980RepresentanteRG = T00303_n980RepresentanteRG[0];
            AssignAttri("", false, "A980RepresentanteRG", A980RepresentanteRG);
            A981RepresentanteOrgaoExpedidor = T00303_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = T00303_n981RepresentanteOrgaoExpedidor[0];
            AssignAttri("", false, "A981RepresentanteOrgaoExpedidor", A981RepresentanteOrgaoExpedidor);
            A982RepresentanteRGUF = T00303_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = T00303_n982RepresentanteRGUF[0];
            AssignAttri("", false, "A982RepresentanteRGUF", A982RepresentanteRGUF);
            A983RepresentanteCPF = T00303_A983RepresentanteCPF[0];
            n983RepresentanteCPF = T00303_n983RepresentanteCPF[0];
            AssignAttri("", false, "A983RepresentanteCPF", A983RepresentanteCPF);
            A984RepresentanteEstadoCivil = T00303_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = T00303_n984RepresentanteEstadoCivil[0];
            AssignAttri("", false, "A984RepresentanteEstadoCivil", A984RepresentanteEstadoCivil);
            A985RepresentanteNacionalidade = T00303_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = T00303_n985RepresentanteNacionalidade[0];
            AssignAttri("", false, "A985RepresentanteNacionalidade", A985RepresentanteNacionalidade);
            A986RepresentanteEmail = T00303_A986RepresentanteEmail[0];
            n986RepresentanteEmail = T00303_n986RepresentanteEmail[0];
            AssignAttri("", false, "A986RepresentanteEmail", A986RepresentanteEmail);
            A987RepresentanteCEP = T00303_A987RepresentanteCEP[0];
            n987RepresentanteCEP = T00303_n987RepresentanteCEP[0];
            AssignAttri("", false, "A987RepresentanteCEP", A987RepresentanteCEP);
            A988RepresentanteLogradouro = T00303_A988RepresentanteLogradouro[0];
            n988RepresentanteLogradouro = T00303_n988RepresentanteLogradouro[0];
            AssignAttri("", false, "A988RepresentanteLogradouro", A988RepresentanteLogradouro);
            A989RepresentanteBairro = T00303_A989RepresentanteBairro[0];
            n989RepresentanteBairro = T00303_n989RepresentanteBairro[0];
            AssignAttri("", false, "A989RepresentanteBairro", A989RepresentanteBairro);
            A990RepresentanteCidade = T00303_A990RepresentanteCidade[0];
            n990RepresentanteCidade = T00303_n990RepresentanteCidade[0];
            AssignAttri("", false, "A990RepresentanteCidade", A990RepresentanteCidade);
            A992RepresentanteLogradouroNumero = T00303_A992RepresentanteLogradouroNumero[0];
            n992RepresentanteLogradouroNumero = T00303_n992RepresentanteLogradouroNumero[0];
            AssignAttri("", false, "A992RepresentanteLogradouroNumero", ((0==A992RepresentanteLogradouroNumero)&&IsIns( )||n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A992RepresentanteLogradouroNumero), 10, 0, ".", ""))));
            A993RepresentanteComplemento = T00303_A993RepresentanteComplemento[0];
            n993RepresentanteComplemento = T00303_n993RepresentanteComplemento[0];
            AssignAttri("", false, "A993RepresentanteComplemento", A993RepresentanteComplemento);
            A994RepresentanteDDD = T00303_A994RepresentanteDDD[0];
            n994RepresentanteDDD = T00303_n994RepresentanteDDD[0];
            AssignAttri("", false, "A994RepresentanteDDD", ((0==A994RepresentanteDDD)&&IsIns( )||n994RepresentanteDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A994RepresentanteDDD), 4, 0, ".", ""))));
            A995RepresentanteNumero = T00303_A995RepresentanteNumero[0];
            n995RepresentanteNumero = T00303_n995RepresentanteNumero[0];
            AssignAttri("", false, "A995RepresentanteNumero", ((0==A995RepresentanteNumero)&&IsIns( )||n995RepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A995RepresentanteNumero), 9, 0, ".", ""))));
            A998RepresentanteTipo = T00303_A998RepresentanteTipo[0];
            n998RepresentanteTipo = T00303_n998RepresentanteTipo[0];
            AssignAttri("", false, "A998RepresentanteTipo", A998RepresentanteTipo);
            A168ClienteId = T00303_A168ClienteId[0];
            n168ClienteId = T00303_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A977RepresentanteProfissao = T00303_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = T00303_n977RepresentanteProfissao[0];
            AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
            A991RepresentanteMunicipio = T00303_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = T00303_n991RepresentanteMunicipio[0];
            AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
            Z978RepresentanteId = A978RepresentanteId;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load30104( ) ;
            if ( AnyError == 1 )
            {
               RcdFound104 = 0;
               InitializeNonKey30104( ) ;
            }
            Gx_mode = sMode104;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound104 = 0;
            InitializeNonKey30104( ) ;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode104;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey30104( ) ;
         if ( RcdFound104 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound104 = 0;
         /* Using cursor T003012 */
         pr_default.execute(10, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T003012_A978RepresentanteId[0] < A978RepresentanteId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T003012_A978RepresentanteId[0] > A978RepresentanteId ) ) )
            {
               A978RepresentanteId = T003012_A978RepresentanteId[0];
               AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
               RcdFound104 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound104 = 0;
         /* Using cursor T003013 */
         pr_default.execute(11, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T003013_A978RepresentanteId[0] > A978RepresentanteId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T003013_A978RepresentanteId[0] < A978RepresentanteId ) ) )
            {
               A978RepresentanteId = T003013_A978RepresentanteId[0];
               AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
               RcdFound104 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey30104( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRepresentanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert30104( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound104 == 1 )
            {
               if ( A978RepresentanteId != Z978RepresentanteId )
               {
                  A978RepresentanteId = Z978RepresentanteId;
                  AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REPRESENTANTEID");
                  AnyError = 1;
                  GX_FocusControl = edtRepresentanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRepresentanteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update30104( ) ;
                  GX_FocusControl = edtRepresentanteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A978RepresentanteId != Z978RepresentanteId )
               {
                  /* Insert record */
                  GX_FocusControl = edtRepresentanteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert30104( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REPRESENTANTEID");
                     AnyError = 1;
                     GX_FocusControl = edtRepresentanteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRepresentanteNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert30104( ) ;
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
         if ( A978RepresentanteId != Z978RepresentanteId )
         {
            A978RepresentanteId = Z978RepresentanteId;
            AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REPRESENTANTEID");
            AnyError = 1;
            GX_FocusControl = edtRepresentanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRepresentanteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency30104( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00302 */
            pr_default.execute(0, new Object[] {A978RepresentanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Representante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z979RepresentanteNome, T00302_A979RepresentanteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z980RepresentanteRG, T00302_A980RepresentanteRG[0]) != 0 ) || ( StringUtil.StrCmp(Z981RepresentanteOrgaoExpedidor, T00302_A981RepresentanteOrgaoExpedidor[0]) != 0 ) || ( StringUtil.StrCmp(Z982RepresentanteRGUF, T00302_A982RepresentanteRGUF[0]) != 0 ) || ( StringUtil.StrCmp(Z983RepresentanteCPF, T00302_A983RepresentanteCPF[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z984RepresentanteEstadoCivil, T00302_A984RepresentanteEstadoCivil[0]) != 0 ) || ( StringUtil.StrCmp(Z985RepresentanteNacionalidade, T00302_A985RepresentanteNacionalidade[0]) != 0 ) || ( StringUtil.StrCmp(Z986RepresentanteEmail, T00302_A986RepresentanteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z987RepresentanteCEP, T00302_A987RepresentanteCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z988RepresentanteLogradouro, T00302_A988RepresentanteLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z989RepresentanteBairro, T00302_A989RepresentanteBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z990RepresentanteCidade, T00302_A990RepresentanteCidade[0]) != 0 ) || ( Z992RepresentanteLogradouroNumero != T00302_A992RepresentanteLogradouroNumero[0] ) || ( StringUtil.StrCmp(Z993RepresentanteComplemento, T00302_A993RepresentanteComplemento[0]) != 0 ) || ( Z994RepresentanteDDD != T00302_A994RepresentanteDDD[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z995RepresentanteNumero != T00302_A995RepresentanteNumero[0] ) || ( StringUtil.StrCmp(Z998RepresentanteTipo, T00302_A998RepresentanteTipo[0]) != 0 ) || ( Z168ClienteId != T00302_A168ClienteId[0] ) || ( Z977RepresentanteProfissao != T00302_A977RepresentanteProfissao[0] ) || ( StringUtil.StrCmp(Z991RepresentanteMunicipio, T00302_A991RepresentanteMunicipio[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z979RepresentanteNome, T00302_A979RepresentanteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteNome");
                  GXUtil.WriteLogRaw("Old: ",Z979RepresentanteNome);
                  GXUtil.WriteLogRaw("Current: ",T00302_A979RepresentanteNome[0]);
               }
               if ( StringUtil.StrCmp(Z980RepresentanteRG, T00302_A980RepresentanteRG[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteRG");
                  GXUtil.WriteLogRaw("Old: ",Z980RepresentanteRG);
                  GXUtil.WriteLogRaw("Current: ",T00302_A980RepresentanteRG[0]);
               }
               if ( StringUtil.StrCmp(Z981RepresentanteOrgaoExpedidor, T00302_A981RepresentanteOrgaoExpedidor[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteOrgaoExpedidor");
                  GXUtil.WriteLogRaw("Old: ",Z981RepresentanteOrgaoExpedidor);
                  GXUtil.WriteLogRaw("Current: ",T00302_A981RepresentanteOrgaoExpedidor[0]);
               }
               if ( StringUtil.StrCmp(Z982RepresentanteRGUF, T00302_A982RepresentanteRGUF[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteRGUF");
                  GXUtil.WriteLogRaw("Old: ",Z982RepresentanteRGUF);
                  GXUtil.WriteLogRaw("Current: ",T00302_A982RepresentanteRGUF[0]);
               }
               if ( StringUtil.StrCmp(Z983RepresentanteCPF, T00302_A983RepresentanteCPF[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteCPF");
                  GXUtil.WriteLogRaw("Old: ",Z983RepresentanteCPF);
                  GXUtil.WriteLogRaw("Current: ",T00302_A983RepresentanteCPF[0]);
               }
               if ( StringUtil.StrCmp(Z984RepresentanteEstadoCivil, T00302_A984RepresentanteEstadoCivil[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteEstadoCivil");
                  GXUtil.WriteLogRaw("Old: ",Z984RepresentanteEstadoCivil);
                  GXUtil.WriteLogRaw("Current: ",T00302_A984RepresentanteEstadoCivil[0]);
               }
               if ( StringUtil.StrCmp(Z985RepresentanteNacionalidade, T00302_A985RepresentanteNacionalidade[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteNacionalidade");
                  GXUtil.WriteLogRaw("Old: ",Z985RepresentanteNacionalidade);
                  GXUtil.WriteLogRaw("Current: ",T00302_A985RepresentanteNacionalidade[0]);
               }
               if ( StringUtil.StrCmp(Z986RepresentanteEmail, T00302_A986RepresentanteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z986RepresentanteEmail);
                  GXUtil.WriteLogRaw("Current: ",T00302_A986RepresentanteEmail[0]);
               }
               if ( StringUtil.StrCmp(Z987RepresentanteCEP, T00302_A987RepresentanteCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteCEP");
                  GXUtil.WriteLogRaw("Old: ",Z987RepresentanteCEP);
                  GXUtil.WriteLogRaw("Current: ",T00302_A987RepresentanteCEP[0]);
               }
               if ( StringUtil.StrCmp(Z988RepresentanteLogradouro, T00302_A988RepresentanteLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z988RepresentanteLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T00302_A988RepresentanteLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z989RepresentanteBairro, T00302_A989RepresentanteBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteBairro");
                  GXUtil.WriteLogRaw("Old: ",Z989RepresentanteBairro);
                  GXUtil.WriteLogRaw("Current: ",T00302_A989RepresentanteBairro[0]);
               }
               if ( StringUtil.StrCmp(Z990RepresentanteCidade, T00302_A990RepresentanteCidade[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteCidade");
                  GXUtil.WriteLogRaw("Old: ",Z990RepresentanteCidade);
                  GXUtil.WriteLogRaw("Current: ",T00302_A990RepresentanteCidade[0]);
               }
               if ( Z992RepresentanteLogradouroNumero != T00302_A992RepresentanteLogradouroNumero[0] )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteLogradouroNumero");
                  GXUtil.WriteLogRaw("Old: ",Z992RepresentanteLogradouroNumero);
                  GXUtil.WriteLogRaw("Current: ",T00302_A992RepresentanteLogradouroNumero[0]);
               }
               if ( StringUtil.StrCmp(Z993RepresentanteComplemento, T00302_A993RepresentanteComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z993RepresentanteComplemento);
                  GXUtil.WriteLogRaw("Current: ",T00302_A993RepresentanteComplemento[0]);
               }
               if ( Z994RepresentanteDDD != T00302_A994RepresentanteDDD[0] )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteDDD");
                  GXUtil.WriteLogRaw("Old: ",Z994RepresentanteDDD);
                  GXUtil.WriteLogRaw("Current: ",T00302_A994RepresentanteDDD[0]);
               }
               if ( Z995RepresentanteNumero != T00302_A995RepresentanteNumero[0] )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteNumero");
                  GXUtil.WriteLogRaw("Old: ",Z995RepresentanteNumero);
                  GXUtil.WriteLogRaw("Current: ",T00302_A995RepresentanteNumero[0]);
               }
               if ( StringUtil.StrCmp(Z998RepresentanteTipo, T00302_A998RepresentanteTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteTipo");
                  GXUtil.WriteLogRaw("Old: ",Z998RepresentanteTipo);
                  GXUtil.WriteLogRaw("Current: ",T00302_A998RepresentanteTipo[0]);
               }
               if ( Z168ClienteId != T00302_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00302_A168ClienteId[0]);
               }
               if ( Z977RepresentanteProfissao != T00302_A977RepresentanteProfissao[0] )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteProfissao");
                  GXUtil.WriteLogRaw("Old: ",Z977RepresentanteProfissao);
                  GXUtil.WriteLogRaw("Current: ",T00302_A977RepresentanteProfissao[0]);
               }
               if ( StringUtil.StrCmp(Z991RepresentanteMunicipio, T00302_A991RepresentanteMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("representante:[seudo value changed for attri]"+"RepresentanteMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z991RepresentanteMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T00302_A991RepresentanteMunicipio[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Representante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert30104( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30104( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM30104( 0) ;
            CheckOptimisticConcurrency30104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert30104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003014 */
                     pr_default.execute(12, new Object[] {n979RepresentanteNome, A979RepresentanteNome, n980RepresentanteRG, A980RepresentanteRG, n981RepresentanteOrgaoExpedidor, A981RepresentanteOrgaoExpedidor, n982RepresentanteRGUF, A982RepresentanteRGUF, n983RepresentanteCPF, A983RepresentanteCPF, n984RepresentanteEstadoCivil, A984RepresentanteEstadoCivil, n985RepresentanteNacionalidade, A985RepresentanteNacionalidade, n986RepresentanteEmail, A986RepresentanteEmail, n987RepresentanteCEP, A987RepresentanteCEP, n988RepresentanteLogradouro, A988RepresentanteLogradouro, n989RepresentanteBairro, A989RepresentanteBairro, n990RepresentanteCidade, A990RepresentanteCidade, n992RepresentanteLogradouroNumero, A992RepresentanteLogradouroNumero, n993RepresentanteComplemento, A993RepresentanteComplemento, n994RepresentanteDDD, A994RepresentanteDDD, n995RepresentanteNumero, A995RepresentanteNumero, n998RepresentanteTipo, A998RepresentanteTipo, n168ClienteId, A168ClienteId, n977RepresentanteProfissao, A977RepresentanteProfissao, n991RepresentanteMunicipio, A991RepresentanteMunicipio});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003015 */
                     pr_default.execute(13);
                     A978RepresentanteId = T003015_A978RepresentanteId[0];
                     AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Representante");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption300( ) ;
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
               Load30104( ) ;
            }
            EndLevel30104( ) ;
         }
         CloseExtendedTableCursors30104( ) ;
      }

      protected void Update30104( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30104( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate30104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003016 */
                     pr_default.execute(14, new Object[] {n979RepresentanteNome, A979RepresentanteNome, n980RepresentanteRG, A980RepresentanteRG, n981RepresentanteOrgaoExpedidor, A981RepresentanteOrgaoExpedidor, n982RepresentanteRGUF, A982RepresentanteRGUF, n983RepresentanteCPF, A983RepresentanteCPF, n984RepresentanteEstadoCivil, A984RepresentanteEstadoCivil, n985RepresentanteNacionalidade, A985RepresentanteNacionalidade, n986RepresentanteEmail, A986RepresentanteEmail, n987RepresentanteCEP, A987RepresentanteCEP, n988RepresentanteLogradouro, A988RepresentanteLogradouro, n989RepresentanteBairro, A989RepresentanteBairro, n990RepresentanteCidade, A990RepresentanteCidade, n992RepresentanteLogradouroNumero, A992RepresentanteLogradouroNumero, n993RepresentanteComplemento, A993RepresentanteComplemento, n994RepresentanteDDD, A994RepresentanteDDD, n995RepresentanteNumero, A995RepresentanteNumero, n998RepresentanteTipo, A998RepresentanteTipo, n168ClienteId, A168ClienteId, n977RepresentanteProfissao, A977RepresentanteProfissao, n991RepresentanteMunicipio, A991RepresentanteMunicipio, A978RepresentanteId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Representante");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Representante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate30104( ) ;
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
            EndLevel30104( ) ;
         }
         CloseExtendedTableCursors30104( ) ;
      }

      protected void DeferredUpdate30104( )
      {
      }

      protected void delete( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30104( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls30104( ) ;
            AfterConfirm30104( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete30104( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003017 */
                  pr_default.execute(15, new Object[] {A978RepresentanteId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Representante");
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
         sMode104 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel30104( ) ;
         Gx_mode = sMode104;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls30104( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003018 */
            pr_default.execute(16, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
            A999RepresentanteProfissaoDescricao = T003018_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = T003018_n999RepresentanteProfissaoDescricao[0];
            pr_default.close(16);
            /* Using cursor T003019 */
            pr_default.execute(17, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
            A996RepresentanteMunicipioUF = T003019_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = T003019_n996RepresentanteMunicipioUF[0];
            AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
            A997RepresentanteMunicipioNome = T003019_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = T003019_n997RepresentanteMunicipioNome[0];
            pr_default.close(17);
         }
      }

      protected void EndLevel30104( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete30104( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues300( ) ;
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

      public void ScanStart30104( )
      {
         /* Scan By routine */
         /* Using cursor T003020 */
         pr_default.execute(18);
         RcdFound104 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound104 = 1;
            A978RepresentanteId = T003020_A978RepresentanteId[0];
            AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext30104( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound104 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound104 = 1;
            A978RepresentanteId = T003020_A978RepresentanteId[0];
            AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
         }
      }

      protected void ScanEnd30104( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm30104( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert30104( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate30104( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete30104( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete30104( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate30104( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes30104( )
      {
         edtRepresentanteId_Enabled = 0;
         AssignProp("", false, edtRepresentanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteId_Enabled), 5, 0), true);
         edtRepresentanteNome_Enabled = 0;
         AssignProp("", false, edtRepresentanteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteNome_Enabled), 5, 0), true);
         edtRepresentanteRG_Enabled = 0;
         AssignProp("", false, edtRepresentanteRG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteRG_Enabled), 5, 0), true);
         edtRepresentanteOrgaoExpedidor_Enabled = 0;
         AssignProp("", false, edtRepresentanteOrgaoExpedidor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteOrgaoExpedidor_Enabled), 5, 0), true);
         edtRepresentanteRGUF_Enabled = 0;
         AssignProp("", false, edtRepresentanteRGUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteRGUF_Enabled), 5, 0), true);
         edtRepresentanteCPF_Enabled = 0;
         AssignProp("", false, edtRepresentanteCPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteCPF_Enabled), 5, 0), true);
         cmbRepresentanteEstadoCivil.Enabled = 0;
         AssignProp("", false, cmbRepresentanteEstadoCivil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRepresentanteEstadoCivil.Enabled), 5, 0), true);
         edtRepresentanteNacionalidade_Enabled = 0;
         AssignProp("", false, edtRepresentanteNacionalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteNacionalidade_Enabled), 5, 0), true);
         edtRepresentanteProfissao_Enabled = 0;
         AssignProp("", false, edtRepresentanteProfissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteProfissao_Enabled), 5, 0), true);
         edtRepresentanteEmail_Enabled = 0;
         AssignProp("", false, edtRepresentanteEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteEmail_Enabled), 5, 0), true);
         edtRepresentanteCEP_Enabled = 0;
         AssignProp("", false, edtRepresentanteCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteCEP_Enabled), 5, 0), true);
         edtRepresentanteLogradouro_Enabled = 0;
         AssignProp("", false, edtRepresentanteLogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteLogradouro_Enabled), 5, 0), true);
         edtRepresentanteBairro_Enabled = 0;
         AssignProp("", false, edtRepresentanteBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteBairro_Enabled), 5, 0), true);
         edtRepresentanteCidade_Enabled = 0;
         AssignProp("", false, edtRepresentanteCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteCidade_Enabled), 5, 0), true);
         edtRepresentanteMunicipio_Enabled = 0;
         AssignProp("", false, edtRepresentanteMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteMunicipio_Enabled), 5, 0), true);
         edtRepresentanteLogradouroNumero_Enabled = 0;
         AssignProp("", false, edtRepresentanteLogradouroNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteLogradouroNumero_Enabled), 5, 0), true);
         edtRepresentanteComplemento_Enabled = 0;
         AssignProp("", false, edtRepresentanteComplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteComplemento_Enabled), 5, 0), true);
         edtRepresentanteDDD_Enabled = 0;
         AssignProp("", false, edtRepresentanteDDD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteDDD_Enabled), 5, 0), true);
         edtRepresentanteNumero_Enabled = 0;
         AssignProp("", false, edtRepresentanteNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteNumero_Enabled), 5, 0), true);
         edtRepresentanteMunicipioUF_Enabled = 0;
         AssignProp("", false, edtRepresentanteMunicipioUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepresentanteMunicipioUF_Enabled), 5, 0), true);
         cmbRepresentanteTipo.Enabled = 0;
         AssignProp("", false, cmbRepresentanteTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRepresentanteTipo.Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtavComborepresentanteprofissao_Enabled = 0;
         AssignProp("", false, edtavComborepresentanteprofissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborepresentanteprofissao_Enabled), 5, 0), true);
         edtavComborepresentantemunicipio_Enabled = 0;
         AssignProp("", false, edtavComborepresentantemunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborepresentantemunicipio_Enabled), 5, 0), true);
         edtavComboclienteid_Enabled = 0;
         AssignProp("", false, edtavComboclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes30104( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues300( )
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
         GXEncryptionTmp = "representante"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RepresentanteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("representante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Representante");
         forbiddenHiddens.Add("RepresentanteId", context.localUtil.Format( (decimal)(A978RepresentanteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_RepresentanteProfissao", context.localUtil.Format( (decimal)(AV11Insert_RepresentanteProfissao), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_RepresentanteMunicipio", StringUtil.RTrim( context.localUtil.Format( AV12Insert_RepresentanteMunicipio, "")));
         forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV13Insert_ClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("representante:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z978RepresentanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z978RepresentanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z979RepresentanteNome", Z979RepresentanteNome);
         GxWebStd.gx_hidden_field( context, "Z980RepresentanteRG", Z980RepresentanteRG);
         GxWebStd.gx_hidden_field( context, "Z981RepresentanteOrgaoExpedidor", Z981RepresentanteOrgaoExpedidor);
         GxWebStd.gx_hidden_field( context, "Z982RepresentanteRGUF", Z982RepresentanteRGUF);
         GxWebStd.gx_hidden_field( context, "Z983RepresentanteCPF", Z983RepresentanteCPF);
         GxWebStd.gx_hidden_field( context, "Z984RepresentanteEstadoCivil", Z984RepresentanteEstadoCivil);
         GxWebStd.gx_hidden_field( context, "Z985RepresentanteNacionalidade", Z985RepresentanteNacionalidade);
         GxWebStd.gx_hidden_field( context, "Z986RepresentanteEmail", Z986RepresentanteEmail);
         GxWebStd.gx_hidden_field( context, "Z987RepresentanteCEP", Z987RepresentanteCEP);
         GxWebStd.gx_hidden_field( context, "Z988RepresentanteLogradouro", Z988RepresentanteLogradouro);
         GxWebStd.gx_hidden_field( context, "Z989RepresentanteBairro", Z989RepresentanteBairro);
         GxWebStd.gx_hidden_field( context, "Z990RepresentanteCidade", Z990RepresentanteCidade);
         GxWebStd.gx_hidden_field( context, "Z992RepresentanteLogradouroNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z992RepresentanteLogradouroNumero), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z993RepresentanteComplemento", Z993RepresentanteComplemento);
         GxWebStd.gx_hidden_field( context, "Z994RepresentanteDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z994RepresentanteDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z995RepresentanteNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z995RepresentanteNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z998RepresentanteTipo", Z998RepresentanteTipo);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z977RepresentanteProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z977RepresentanteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z991RepresentanteMunicipio", Z991RepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N977RepresentanteProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N991RepresentanteMunicipio", A991RepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "N168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREPRESENTANTEPROFISSAO_DATA", AV15RepresentanteProfissao_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREPRESENTANTEPROFISSAO_DATA", AV15RepresentanteProfissao_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREPRESENTANTEMUNICIPIO_DATA", AV22RepresentanteMunicipio_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREPRESENTANTEMUNICIPIO_DATA", AV22RepresentanteMunicipio_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTEID_DATA", AV25ClienteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTEID_DATA", AV25ClienteId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vREPRESENTANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RepresentanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RepresentanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_REPRESENTANTEPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_RepresentanteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_REPRESENTANTEMUNICIPIO", AV12Insert_RepresentanteMunicipio);
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "REPRESENTANTEPROFISSAODESCRICAO", A999RepresentanteProfissaoDescricao);
         GxWebStd.gx_hidden_field( context, "REPRESENTANTEMUNICIPIONOME", A997RepresentanteMunicipioNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Objectcall", StringUtil.RTrim( Combo_representanteprofissao_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Cls", StringUtil.RTrim( Combo_representanteprofissao_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Selectedvalue_set", StringUtil.RTrim( Combo_representanteprofissao_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Selectedtext_set", StringUtil.RTrim( Combo_representanteprofissao_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Enabled", StringUtil.BoolToStr( Combo_representanteprofissao_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Datalistproc", StringUtil.RTrim( Combo_representanteprofissao_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEPROFISSAO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_representanteprofissao_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Objectcall", StringUtil.RTrim( Combo_representantemunicipio_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Cls", StringUtil.RTrim( Combo_representantemunicipio_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Selectedvalue_set", StringUtil.RTrim( Combo_representantemunicipio_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Selectedtext_set", StringUtil.RTrim( Combo_representantemunicipio_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Enabled", StringUtil.BoolToStr( Combo_representantemunicipio_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Datalistproc", StringUtil.RTrim( Combo_representantemunicipio_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTEMUNICIPIO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_representantemunicipio_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Objectcall", StringUtil.RTrim( Combo_clienteid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Cls", StringUtil.RTrim( Combo_clienteid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Selectedvalue_set", StringUtil.RTrim( Combo_clienteid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Selectedtext_set", StringUtil.RTrim( Combo_clienteid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Datalistproc", StringUtil.RTrim( Combo_clienteid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_clienteid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "representante"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RepresentanteId,9,0));
         return formatLink("representante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Representante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Representante" ;
      }

      protected void InitializeNonKey30104( )
      {
         A977RepresentanteProfissao = 0;
         n977RepresentanteProfissao = false;
         AssignAttri("", false, "A977RepresentanteProfissao", ((0==A977RepresentanteProfissao)&&IsIns( )||n977RepresentanteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A977RepresentanteProfissao), 9, 0, ".", ""))));
         n977RepresentanteProfissao = ((0==A977RepresentanteProfissao) ? true : false);
         A991RepresentanteMunicipio = "";
         n991RepresentanteMunicipio = false;
         AssignAttri("", false, "A991RepresentanteMunicipio", A991RepresentanteMunicipio);
         n991RepresentanteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ? true : false);
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A979RepresentanteNome = "";
         n979RepresentanteNome = false;
         AssignAttri("", false, "A979RepresentanteNome", A979RepresentanteNome);
         n979RepresentanteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A979RepresentanteNome)) ? true : false);
         A980RepresentanteRG = "";
         n980RepresentanteRG = false;
         AssignAttri("", false, "A980RepresentanteRG", A980RepresentanteRG);
         n980RepresentanteRG = (String.IsNullOrEmpty(StringUtil.RTrim( A980RepresentanteRG)) ? true : false);
         A981RepresentanteOrgaoExpedidor = "";
         n981RepresentanteOrgaoExpedidor = false;
         AssignAttri("", false, "A981RepresentanteOrgaoExpedidor", A981RepresentanteOrgaoExpedidor);
         n981RepresentanteOrgaoExpedidor = (String.IsNullOrEmpty(StringUtil.RTrim( A981RepresentanteOrgaoExpedidor)) ? true : false);
         A982RepresentanteRGUF = "";
         n982RepresentanteRGUF = false;
         AssignAttri("", false, "A982RepresentanteRGUF", A982RepresentanteRGUF);
         n982RepresentanteRGUF = (String.IsNullOrEmpty(StringUtil.RTrim( A982RepresentanteRGUF)) ? true : false);
         A983RepresentanteCPF = "";
         n983RepresentanteCPF = false;
         AssignAttri("", false, "A983RepresentanteCPF", A983RepresentanteCPF);
         n983RepresentanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A983RepresentanteCPF)) ? true : false);
         A984RepresentanteEstadoCivil = "";
         n984RepresentanteEstadoCivil = false;
         AssignAttri("", false, "A984RepresentanteEstadoCivil", A984RepresentanteEstadoCivil);
         n984RepresentanteEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A984RepresentanteEstadoCivil)) ? true : false);
         A985RepresentanteNacionalidade = "";
         n985RepresentanteNacionalidade = false;
         AssignAttri("", false, "A985RepresentanteNacionalidade", A985RepresentanteNacionalidade);
         n985RepresentanteNacionalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A985RepresentanteNacionalidade)) ? true : false);
         A999RepresentanteProfissaoDescricao = "";
         n999RepresentanteProfissaoDescricao = false;
         AssignAttri("", false, "A999RepresentanteProfissaoDescricao", A999RepresentanteProfissaoDescricao);
         A986RepresentanteEmail = "";
         n986RepresentanteEmail = false;
         AssignAttri("", false, "A986RepresentanteEmail", A986RepresentanteEmail);
         n986RepresentanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A986RepresentanteEmail)) ? true : false);
         A987RepresentanteCEP = "";
         n987RepresentanteCEP = false;
         AssignAttri("", false, "A987RepresentanteCEP", A987RepresentanteCEP);
         n987RepresentanteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A987RepresentanteCEP)) ? true : false);
         A988RepresentanteLogradouro = "";
         n988RepresentanteLogradouro = false;
         AssignAttri("", false, "A988RepresentanteLogradouro", A988RepresentanteLogradouro);
         n988RepresentanteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A988RepresentanteLogradouro)) ? true : false);
         A989RepresentanteBairro = "";
         n989RepresentanteBairro = false;
         AssignAttri("", false, "A989RepresentanteBairro", A989RepresentanteBairro);
         n989RepresentanteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A989RepresentanteBairro)) ? true : false);
         A990RepresentanteCidade = "";
         n990RepresentanteCidade = false;
         AssignAttri("", false, "A990RepresentanteCidade", A990RepresentanteCidade);
         n990RepresentanteCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A990RepresentanteCidade)) ? true : false);
         A992RepresentanteLogradouroNumero = 0;
         n992RepresentanteLogradouroNumero = false;
         AssignAttri("", false, "A992RepresentanteLogradouroNumero", ((0==A992RepresentanteLogradouroNumero)&&IsIns( )||n992RepresentanteLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A992RepresentanteLogradouroNumero), 10, 0, ".", ""))));
         n992RepresentanteLogradouroNumero = ((0==A992RepresentanteLogradouroNumero) ? true : false);
         A993RepresentanteComplemento = "";
         n993RepresentanteComplemento = false;
         AssignAttri("", false, "A993RepresentanteComplemento", A993RepresentanteComplemento);
         n993RepresentanteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A993RepresentanteComplemento)) ? true : false);
         A994RepresentanteDDD = 0;
         n994RepresentanteDDD = false;
         AssignAttri("", false, "A994RepresentanteDDD", ((0==A994RepresentanteDDD)&&IsIns( )||n994RepresentanteDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A994RepresentanteDDD), 4, 0, ".", ""))));
         n994RepresentanteDDD = ((0==A994RepresentanteDDD) ? true : false);
         A995RepresentanteNumero = 0;
         n995RepresentanteNumero = false;
         AssignAttri("", false, "A995RepresentanteNumero", ((0==A995RepresentanteNumero)&&IsIns( )||n995RepresentanteNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A995RepresentanteNumero), 9, 0, ".", ""))));
         n995RepresentanteNumero = ((0==A995RepresentanteNumero) ? true : false);
         A996RepresentanteMunicipioUF = "";
         n996RepresentanteMunicipioUF = false;
         AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
         A997RepresentanteMunicipioNome = "";
         n997RepresentanteMunicipioNome = false;
         AssignAttri("", false, "A997RepresentanteMunicipioNome", A997RepresentanteMunicipioNome);
         A998RepresentanteTipo = "";
         n998RepresentanteTipo = false;
         AssignAttri("", false, "A998RepresentanteTipo", A998RepresentanteTipo);
         n998RepresentanteTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A998RepresentanteTipo)) ? true : false);
         Z979RepresentanteNome = "";
         Z980RepresentanteRG = "";
         Z981RepresentanteOrgaoExpedidor = "";
         Z982RepresentanteRGUF = "";
         Z983RepresentanteCPF = "";
         Z984RepresentanteEstadoCivil = "";
         Z985RepresentanteNacionalidade = "";
         Z986RepresentanteEmail = "";
         Z987RepresentanteCEP = "";
         Z988RepresentanteLogradouro = "";
         Z989RepresentanteBairro = "";
         Z990RepresentanteCidade = "";
         Z992RepresentanteLogradouroNumero = 0;
         Z993RepresentanteComplemento = "";
         Z994RepresentanteDDD = 0;
         Z995RepresentanteNumero = 0;
         Z998RepresentanteTipo = "";
         Z168ClienteId = 0;
         Z977RepresentanteProfissao = 0;
         Z991RepresentanteMunicipio = "";
      }

      protected void InitAll30104( )
      {
         A978RepresentanteId = 0;
         AssignAttri("", false, "A978RepresentanteId", StringUtil.LTrimStr( (decimal)(A978RepresentanteId), 9, 0));
         InitializeNonKey30104( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101922915", true, true);
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
         context.AddJavascriptSource("representante.js", "?20256101922916", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         edtRepresentanteId_Internalname = "REPRESENTANTEID";
         edtRepresentanteNome_Internalname = "REPRESENTANTENOME";
         edtRepresentanteRG_Internalname = "REPRESENTANTERG";
         edtRepresentanteOrgaoExpedidor_Internalname = "REPRESENTANTEORGAOEXPEDIDOR";
         edtRepresentanteRGUF_Internalname = "REPRESENTANTERGUF";
         edtRepresentanteCPF_Internalname = "REPRESENTANTECPF";
         cmbRepresentanteEstadoCivil_Internalname = "REPRESENTANTEESTADOCIVIL";
         edtRepresentanteNacionalidade_Internalname = "REPRESENTANTENACIONALIDADE";
         lblTextblockrepresentanteprofissao_Internalname = "TEXTBLOCKREPRESENTANTEPROFISSAO";
         Combo_representanteprofissao_Internalname = "COMBO_REPRESENTANTEPROFISSAO";
         edtRepresentanteProfissao_Internalname = "REPRESENTANTEPROFISSAO";
         divTablesplittedrepresentanteprofissao_Internalname = "TABLESPLITTEDREPRESENTANTEPROFISSAO";
         edtRepresentanteEmail_Internalname = "REPRESENTANTEEMAIL";
         edtRepresentanteCEP_Internalname = "REPRESENTANTECEP";
         edtRepresentanteLogradouro_Internalname = "REPRESENTANTELOGRADOURO";
         edtRepresentanteBairro_Internalname = "REPRESENTANTEBAIRRO";
         edtRepresentanteCidade_Internalname = "REPRESENTANTECIDADE";
         lblTextblockrepresentantemunicipio_Internalname = "TEXTBLOCKREPRESENTANTEMUNICIPIO";
         Combo_representantemunicipio_Internalname = "COMBO_REPRESENTANTEMUNICIPIO";
         edtRepresentanteMunicipio_Internalname = "REPRESENTANTEMUNICIPIO";
         divTablesplittedrepresentantemunicipio_Internalname = "TABLESPLITTEDREPRESENTANTEMUNICIPIO";
         edtRepresentanteLogradouroNumero_Internalname = "REPRESENTANTELOGRADOURONUMERO";
         edtRepresentanteComplemento_Internalname = "REPRESENTANTECOMPLEMENTO";
         edtRepresentanteDDD_Internalname = "REPRESENTANTEDDD";
         edtRepresentanteNumero_Internalname = "REPRESENTANTENUMERO";
         edtRepresentanteMunicipioUF_Internalname = "REPRESENTANTEMUNICIPIOUF";
         cmbRepresentanteTipo_Internalname = "REPRESENTANTETIPO";
         lblTextblockclienteid_Internalname = "TEXTBLOCKCLIENTEID";
         Combo_clienteid_Internalname = "COMBO_CLIENTEID";
         edtClienteId_Internalname = "CLIENTEID";
         divTablesplittedclienteid_Internalname = "TABLESPLITTEDCLIENTEID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComborepresentanteprofissao_Internalname = "vCOMBOREPRESENTANTEPROFISSAO";
         divSectionattribute_representanteprofissao_Internalname = "SECTIONATTRIBUTE_REPRESENTANTEPROFISSAO";
         edtavComborepresentantemunicipio_Internalname = "vCOMBOREPRESENTANTEMUNICIPIO";
         divSectionattribute_representantemunicipio_Internalname = "SECTIONATTRIBUTE_REPRESENTANTEMUNICIPIO";
         edtavComboclienteid_Internalname = "vCOMBOCLIENTEID";
         divSectionattribute_clienteid_Internalname = "SECTIONATTRIBUTE_CLIENTEID";
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
         Form.Caption = "Representante";
         edtavComboclienteid_Jsonclick = "";
         edtavComboclienteid_Enabled = 0;
         edtavComboclienteid_Visible = 1;
         edtavComborepresentantemunicipio_Jsonclick = "";
         edtavComborepresentantemunicipio_Enabled = 0;
         edtavComborepresentantemunicipio_Visible = 1;
         edtavComborepresentanteprofissao_Jsonclick = "";
         edtavComborepresentanteprofissao_Enabled = 0;
         edtavComborepresentanteprofissao_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtClienteId_Visible = 1;
         Combo_clienteid_Datalistprocparametersprefix = " \"ComboName\": \"ClienteId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"RepresentanteId\": 0";
         Combo_clienteid_Datalistproc = "RepresentanteLoadDVCombo";
         Combo_clienteid_Cls = "ExtendedCombo AttributeFL";
         Combo_clienteid_Caption = "";
         Combo_clienteid_Enabled = Convert.ToBoolean( -1);
         cmbRepresentanteTipo_Jsonclick = "";
         cmbRepresentanteTipo.Enabled = 1;
         edtRepresentanteMunicipioUF_Jsonclick = "";
         edtRepresentanteMunicipioUF_Enabled = 0;
         edtRepresentanteNumero_Jsonclick = "";
         edtRepresentanteNumero_Enabled = 1;
         edtRepresentanteDDD_Jsonclick = "";
         edtRepresentanteDDD_Enabled = 1;
         edtRepresentanteComplemento_Jsonclick = "";
         edtRepresentanteComplemento_Enabled = 1;
         edtRepresentanteLogradouroNumero_Jsonclick = "";
         edtRepresentanteLogradouroNumero_Enabled = 1;
         edtRepresentanteMunicipio_Jsonclick = "";
         edtRepresentanteMunicipio_Enabled = 1;
         edtRepresentanteMunicipio_Visible = 1;
         Combo_representantemunicipio_Datalistprocparametersprefix = " \"ComboName\": \"RepresentanteMunicipio\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"RepresentanteId\": 0";
         Combo_representantemunicipio_Datalistproc = "RepresentanteLoadDVCombo";
         Combo_representantemunicipio_Cls = "ExtendedCombo AttributeFL";
         Combo_representantemunicipio_Caption = "";
         Combo_representantemunicipio_Enabled = Convert.ToBoolean( -1);
         edtRepresentanteCidade_Jsonclick = "";
         edtRepresentanteCidade_Enabled = 1;
         edtRepresentanteBairro_Jsonclick = "";
         edtRepresentanteBairro_Enabled = 1;
         edtRepresentanteLogradouro_Jsonclick = "";
         edtRepresentanteLogradouro_Enabled = 1;
         edtRepresentanteCEP_Jsonclick = "";
         edtRepresentanteCEP_Enabled = 1;
         edtRepresentanteEmail_Jsonclick = "";
         edtRepresentanteEmail_Enabled = 1;
         edtRepresentanteProfissao_Jsonclick = "";
         edtRepresentanteProfissao_Enabled = 1;
         edtRepresentanteProfissao_Visible = 1;
         Combo_representanteprofissao_Datalistprocparametersprefix = " \"ComboName\": \"RepresentanteProfissao\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"RepresentanteId\": 0";
         Combo_representanteprofissao_Datalistproc = "RepresentanteLoadDVCombo";
         Combo_representanteprofissao_Cls = "ExtendedCombo AttributeFL";
         Combo_representanteprofissao_Caption = "";
         Combo_representanteprofissao_Enabled = Convert.ToBoolean( -1);
         edtRepresentanteNacionalidade_Jsonclick = "";
         edtRepresentanteNacionalidade_Enabled = 1;
         cmbRepresentanteEstadoCivil_Jsonclick = "";
         cmbRepresentanteEstadoCivil.Enabled = 1;
         edtRepresentanteCPF_Jsonclick = "";
         edtRepresentanteCPF_Enabled = 1;
         edtRepresentanteRGUF_Jsonclick = "";
         edtRepresentanteRGUF_Enabled = 1;
         edtRepresentanteOrgaoExpedidor_Jsonclick = "";
         edtRepresentanteOrgaoExpedidor_Enabled = 1;
         edtRepresentanteRG_Jsonclick = "";
         edtRepresentanteRG_Enabled = 1;
         edtRepresentanteNome_Jsonclick = "";
         edtRepresentanteNome_Enabled = 1;
         edtRepresentanteId_Jsonclick = "";
         edtRepresentanteId_Enabled = 0;
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
         cmbRepresentanteEstadoCivil.Name = "REPRESENTANTEESTADOCIVIL";
         cmbRepresentanteEstadoCivil.WebTags = "";
         cmbRepresentanteEstadoCivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("CASADO", "Casado(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("VIUVO", "Viúvo(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("SEPARADO", "Separado(a)", 0);
         cmbRepresentanteEstadoCivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
         if ( cmbRepresentanteEstadoCivil.ItemCount > 0 )
         {
            A984RepresentanteEstadoCivil = cmbRepresentanteEstadoCivil.getValidValue(A984RepresentanteEstadoCivil);
            n984RepresentanteEstadoCivil = false;
            AssignAttri("", false, "A984RepresentanteEstadoCivil", A984RepresentanteEstadoCivil);
         }
         cmbRepresentanteTipo.Name = "REPRESENTANTETIPO";
         cmbRepresentanteTipo.WebTags = "";
         cmbRepresentanteTipo.addItem("Representante", "Representante", 0);
         cmbRepresentanteTipo.addItem("Responsavel_solidario", "Responsável Solidário", 0);
         if ( cmbRepresentanteTipo.ItemCount > 0 )
         {
            A998RepresentanteTipo = cmbRepresentanteTipo.getValidValue(A998RepresentanteTipo);
            n998RepresentanteTipo = false;
            AssignAttri("", false, "A998RepresentanteTipo", A998RepresentanteTipo);
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

      public void Valid_Representanteprofissao( )
      {
         n999RepresentanteProfissaoDescricao = false;
         /* Using cursor T003018 */
         pr_default.execute(16, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A977RepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representante Profissao'.", "ForeignKeyNotFound", 1, "REPRESENTANTEPROFISSAO");
               AnyError = 1;
               GX_FocusControl = edtRepresentanteProfissao_Internalname;
            }
         }
         A999RepresentanteProfissaoDescricao = T003018_A999RepresentanteProfissaoDescricao[0];
         n999RepresentanteProfissaoDescricao = T003018_n999RepresentanteProfissaoDescricao[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A999RepresentanteProfissaoDescricao", A999RepresentanteProfissaoDescricao);
      }

      public void Valid_Representantemunicipio( )
      {
         n991RepresentanteMunicipio = false;
         n996RepresentanteMunicipioUF = false;
         n997RepresentanteMunicipioNome = false;
         /* Using cursor T003019 */
         pr_default.execute(17, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representantel Municipio'.", "ForeignKeyNotFound", 1, "REPRESENTANTEMUNICIPIO");
               AnyError = 1;
               GX_FocusControl = edtRepresentanteMunicipio_Internalname;
            }
         }
         A996RepresentanteMunicipioUF = T003019_A996RepresentanteMunicipioUF[0];
         n996RepresentanteMunicipioUF = T003019_n996RepresentanteMunicipioUF[0];
         A997RepresentanteMunicipioNome = T003019_A997RepresentanteMunicipioNome[0];
         n997RepresentanteMunicipioNome = T003019_n997RepresentanteMunicipioNome[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A996RepresentanteMunicipioUF", A996RepresentanteMunicipioUF);
         AssignAttri("", false, "A997RepresentanteMunicipioNome", A997RepresentanteMunicipioNome);
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T003021 */
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7RepresentanteId","fld":"vREPRESENTANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7RepresentanteId","fld":"vREPRESENTANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A978RepresentanteId","fld":"REPRESENTANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_RepresentanteProfissao","fld":"vINSERT_REPRESENTANTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_RepresentanteMunicipio","fld":"vINSERT_REPRESENTANTEMUNICIPIO","type":"svchar"},{"av":"AV13Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12302","iparms":[]}""");
         setEventMetadata("VALID_REPRESENTANTEID","""{"handler":"Valid_Representanteid","iparms":[]}""");
         setEventMetadata("VALID_REPRESENTANTEESTADOCIVIL","""{"handler":"Valid_Representanteestadocivil","iparms":[]}""");
         setEventMetadata("VALID_REPRESENTANTEPROFISSAO","""{"handler":"Valid_Representanteprofissao","iparms":[{"av":"A977RepresentanteProfissao","fld":"REPRESENTANTEPROFISSAO","pic":"ZZZZZZZZ9","nullAv":"n977RepresentanteProfissao","type":"int"},{"av":"A999RepresentanteProfissaoDescricao","fld":"REPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_REPRESENTANTEPROFISSAO",""","oparms":[{"av":"A999RepresentanteProfissaoDescricao","fld":"REPRESENTANTEPROFISSAODESCRICAO","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_REPRESENTANTEEMAIL","""{"handler":"Valid_Representanteemail","iparms":[]}""");
         setEventMetadata("VALID_REPRESENTANTEMUNICIPIO","""{"handler":"Valid_Representantemunicipio","iparms":[{"av":"A991RepresentanteMunicipio","fld":"REPRESENTANTEMUNICIPIO","type":"svchar"},{"av":"A996RepresentanteMunicipioUF","fld":"REPRESENTANTEMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"A997RepresentanteMunicipioNome","fld":"REPRESENTANTEMUNICIPIONOME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_REPRESENTANTEMUNICIPIO",""","oparms":[{"av":"A996RepresentanteMunicipioUF","fld":"REPRESENTANTEMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"A997RepresentanteMunicipioNome","fld":"REPRESENTANTEMUNICIPIONOME","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_REPRESENTANTETIPO","""{"handler":"Valid_Representantetipo","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("VALIDV_COMBOREPRESENTANTEPROFISSAO","""{"handler":"Validv_Comborepresentanteprofissao","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOREPRESENTANTEMUNICIPIO","""{"handler":"Validv_Comborepresentantemunicipio","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOCLIENTEID","""{"handler":"Validv_Comboclienteid","iparms":[]}""");
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
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z979RepresentanteNome = "";
         Z980RepresentanteRG = "";
         Z981RepresentanteOrgaoExpedidor = "";
         Z982RepresentanteRGUF = "";
         Z983RepresentanteCPF = "";
         Z984RepresentanteEstadoCivil = "";
         Z985RepresentanteNacionalidade = "";
         Z986RepresentanteEmail = "";
         Z987RepresentanteCEP = "";
         Z988RepresentanteLogradouro = "";
         Z989RepresentanteBairro = "";
         Z990RepresentanteCidade = "";
         Z993RepresentanteComplemento = "";
         Z998RepresentanteTipo = "";
         Z991RepresentanteMunicipio = "";
         N991RepresentanteMunicipio = "";
         Combo_clienteid_Selectedvalue_get = "";
         Combo_representantemunicipio_Selectedvalue_get = "";
         Combo_representanteprofissao_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A991RepresentanteMunicipio = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A984RepresentanteEstadoCivil = "";
         A998RepresentanteTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A979RepresentanteNome = "";
         A980RepresentanteRG = "";
         A981RepresentanteOrgaoExpedidor = "";
         A982RepresentanteRGUF = "";
         A983RepresentanteCPF = "";
         A985RepresentanteNacionalidade = "";
         lblTextblockrepresentanteprofissao_Jsonclick = "";
         ucCombo_representanteprofissao = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15RepresentanteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A986RepresentanteEmail = "";
         A987RepresentanteCEP = "";
         A988RepresentanteLogradouro = "";
         A989RepresentanteBairro = "";
         A990RepresentanteCidade = "";
         lblTextblockrepresentantemunicipio_Jsonclick = "";
         ucCombo_representantemunicipio = new GXUserControl();
         AV22RepresentanteMunicipio_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A993RepresentanteComplemento = "";
         A996RepresentanteMunicipioUF = "";
         lblTextblockclienteid_Jsonclick = "";
         ucCombo_clienteid = new GXUserControl();
         AV25ClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23ComboRepresentanteMunicipio = "";
         AV12Insert_RepresentanteMunicipio = "";
         A999RepresentanteProfissaoDescricao = "";
         A997RepresentanteMunicipioNome = "";
         AV27Pgmname = "";
         Combo_representanteprofissao_Objectcall = "";
         Combo_representanteprofissao_Class = "";
         Combo_representanteprofissao_Icontype = "";
         Combo_representanteprofissao_Icon = "";
         Combo_representanteprofissao_Tooltip = "";
         Combo_representanteprofissao_Selectedvalue_set = "";
         Combo_representanteprofissao_Selectedtext_set = "";
         Combo_representanteprofissao_Selectedtext_get = "";
         Combo_representanteprofissao_Gamoauthtoken = "";
         Combo_representanteprofissao_Ddointernalname = "";
         Combo_representanteprofissao_Titlecontrolalign = "";
         Combo_representanteprofissao_Dropdownoptionstype = "";
         Combo_representanteprofissao_Titlecontrolidtoreplace = "";
         Combo_representanteprofissao_Datalisttype = "";
         Combo_representanteprofissao_Datalistfixedvalues = "";
         Combo_representanteprofissao_Remoteservicesparameters = "";
         Combo_representanteprofissao_Htmltemplate = "";
         Combo_representanteprofissao_Multiplevaluestype = "";
         Combo_representanteprofissao_Loadingdata = "";
         Combo_representanteprofissao_Noresultsfound = "";
         Combo_representanteprofissao_Emptyitemtext = "";
         Combo_representanteprofissao_Onlyselectedvalues = "";
         Combo_representanteprofissao_Selectalltext = "";
         Combo_representanteprofissao_Multiplevaluesseparator = "";
         Combo_representanteprofissao_Addnewoptiontext = "";
         Combo_representantemunicipio_Objectcall = "";
         Combo_representantemunicipio_Class = "";
         Combo_representantemunicipio_Icontype = "";
         Combo_representantemunicipio_Icon = "";
         Combo_representantemunicipio_Tooltip = "";
         Combo_representantemunicipio_Selectedvalue_set = "";
         Combo_representantemunicipio_Selectedtext_set = "";
         Combo_representantemunicipio_Selectedtext_get = "";
         Combo_representantemunicipio_Gamoauthtoken = "";
         Combo_representantemunicipio_Ddointernalname = "";
         Combo_representantemunicipio_Titlecontrolalign = "";
         Combo_representantemunicipio_Dropdownoptionstype = "";
         Combo_representantemunicipio_Titlecontrolidtoreplace = "";
         Combo_representantemunicipio_Datalisttype = "";
         Combo_representantemunicipio_Datalistfixedvalues = "";
         Combo_representantemunicipio_Remoteservicesparameters = "";
         Combo_representantemunicipio_Htmltemplate = "";
         Combo_representantemunicipio_Multiplevaluestype = "";
         Combo_representantemunicipio_Loadingdata = "";
         Combo_representantemunicipio_Noresultsfound = "";
         Combo_representantemunicipio_Emptyitemtext = "";
         Combo_representantemunicipio_Onlyselectedvalues = "";
         Combo_representantemunicipio_Selectalltext = "";
         Combo_representantemunicipio_Multiplevaluesseparator = "";
         Combo_representantemunicipio_Addnewoptiontext = "";
         Combo_clienteid_Objectcall = "";
         Combo_clienteid_Class = "";
         Combo_clienteid_Icontype = "";
         Combo_clienteid_Icon = "";
         Combo_clienteid_Tooltip = "";
         Combo_clienteid_Selectedvalue_set = "";
         Combo_clienteid_Selectedtext_set = "";
         Combo_clienteid_Selectedtext_get = "";
         Combo_clienteid_Gamoauthtoken = "";
         Combo_clienteid_Ddointernalname = "";
         Combo_clienteid_Titlecontrolalign = "";
         Combo_clienteid_Dropdownoptionstype = "";
         Combo_clienteid_Titlecontrolidtoreplace = "";
         Combo_clienteid_Datalisttype = "";
         Combo_clienteid_Datalistfixedvalues = "";
         Combo_clienteid_Remoteservicesparameters = "";
         Combo_clienteid_Htmltemplate = "";
         Combo_clienteid_Multiplevaluestype = "";
         Combo_clienteid_Loadingdata = "";
         Combo_clienteid_Noresultsfound = "";
         Combo_clienteid_Emptyitemtext = "";
         Combo_clienteid_Onlyselectedvalues = "";
         Combo_clienteid_Selectalltext = "";
         Combo_clienteid_Multiplevaluesseparator = "";
         Combo_clienteid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode104 = "";
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
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z999RepresentanteProfissaoDescricao = "";
         Z996RepresentanteMunicipioUF = "";
         Z997RepresentanteMunicipioNome = "";
         T00305_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         T00305_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         T00306_A996RepresentanteMunicipioUF = new string[] {""} ;
         T00306_n996RepresentanteMunicipioUF = new bool[] {false} ;
         T00306_A997RepresentanteMunicipioNome = new string[] {""} ;
         T00306_n997RepresentanteMunicipioNome = new bool[] {false} ;
         T00307_A978RepresentanteId = new int[1] ;
         T00307_A979RepresentanteNome = new string[] {""} ;
         T00307_n979RepresentanteNome = new bool[] {false} ;
         T00307_A980RepresentanteRG = new string[] {""} ;
         T00307_n980RepresentanteRG = new bool[] {false} ;
         T00307_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         T00307_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         T00307_A982RepresentanteRGUF = new string[] {""} ;
         T00307_n982RepresentanteRGUF = new bool[] {false} ;
         T00307_A983RepresentanteCPF = new string[] {""} ;
         T00307_n983RepresentanteCPF = new bool[] {false} ;
         T00307_A984RepresentanteEstadoCivil = new string[] {""} ;
         T00307_n984RepresentanteEstadoCivil = new bool[] {false} ;
         T00307_A985RepresentanteNacionalidade = new string[] {""} ;
         T00307_n985RepresentanteNacionalidade = new bool[] {false} ;
         T00307_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         T00307_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         T00307_A986RepresentanteEmail = new string[] {""} ;
         T00307_n986RepresentanteEmail = new bool[] {false} ;
         T00307_A987RepresentanteCEP = new string[] {""} ;
         T00307_n987RepresentanteCEP = new bool[] {false} ;
         T00307_A988RepresentanteLogradouro = new string[] {""} ;
         T00307_n988RepresentanteLogradouro = new bool[] {false} ;
         T00307_A989RepresentanteBairro = new string[] {""} ;
         T00307_n989RepresentanteBairro = new bool[] {false} ;
         T00307_A990RepresentanteCidade = new string[] {""} ;
         T00307_n990RepresentanteCidade = new bool[] {false} ;
         T00307_A992RepresentanteLogradouroNumero = new long[1] ;
         T00307_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         T00307_A993RepresentanteComplemento = new string[] {""} ;
         T00307_n993RepresentanteComplemento = new bool[] {false} ;
         T00307_A994RepresentanteDDD = new short[1] ;
         T00307_n994RepresentanteDDD = new bool[] {false} ;
         T00307_A995RepresentanteNumero = new int[1] ;
         T00307_n995RepresentanteNumero = new bool[] {false} ;
         T00307_A996RepresentanteMunicipioUF = new string[] {""} ;
         T00307_n996RepresentanteMunicipioUF = new bool[] {false} ;
         T00307_A997RepresentanteMunicipioNome = new string[] {""} ;
         T00307_n997RepresentanteMunicipioNome = new bool[] {false} ;
         T00307_A998RepresentanteTipo = new string[] {""} ;
         T00307_n998RepresentanteTipo = new bool[] {false} ;
         T00307_A168ClienteId = new int[1] ;
         T00307_n168ClienteId = new bool[] {false} ;
         T00307_A977RepresentanteProfissao = new int[1] ;
         T00307_n977RepresentanteProfissao = new bool[] {false} ;
         T00307_A991RepresentanteMunicipio = new string[] {""} ;
         T00307_n991RepresentanteMunicipio = new bool[] {false} ;
         T00304_A168ClienteId = new int[1] ;
         T00304_n168ClienteId = new bool[] {false} ;
         T00308_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         T00308_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         T00309_A996RepresentanteMunicipioUF = new string[] {""} ;
         T00309_n996RepresentanteMunicipioUF = new bool[] {false} ;
         T00309_A997RepresentanteMunicipioNome = new string[] {""} ;
         T00309_n997RepresentanteMunicipioNome = new bool[] {false} ;
         T003010_A168ClienteId = new int[1] ;
         T003010_n168ClienteId = new bool[] {false} ;
         T003011_A978RepresentanteId = new int[1] ;
         T00303_A978RepresentanteId = new int[1] ;
         T00303_A979RepresentanteNome = new string[] {""} ;
         T00303_n979RepresentanteNome = new bool[] {false} ;
         T00303_A980RepresentanteRG = new string[] {""} ;
         T00303_n980RepresentanteRG = new bool[] {false} ;
         T00303_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         T00303_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         T00303_A982RepresentanteRGUF = new string[] {""} ;
         T00303_n982RepresentanteRGUF = new bool[] {false} ;
         T00303_A983RepresentanteCPF = new string[] {""} ;
         T00303_n983RepresentanteCPF = new bool[] {false} ;
         T00303_A984RepresentanteEstadoCivil = new string[] {""} ;
         T00303_n984RepresentanteEstadoCivil = new bool[] {false} ;
         T00303_A985RepresentanteNacionalidade = new string[] {""} ;
         T00303_n985RepresentanteNacionalidade = new bool[] {false} ;
         T00303_A986RepresentanteEmail = new string[] {""} ;
         T00303_n986RepresentanteEmail = new bool[] {false} ;
         T00303_A987RepresentanteCEP = new string[] {""} ;
         T00303_n987RepresentanteCEP = new bool[] {false} ;
         T00303_A988RepresentanteLogradouro = new string[] {""} ;
         T00303_n988RepresentanteLogradouro = new bool[] {false} ;
         T00303_A989RepresentanteBairro = new string[] {""} ;
         T00303_n989RepresentanteBairro = new bool[] {false} ;
         T00303_A990RepresentanteCidade = new string[] {""} ;
         T00303_n990RepresentanteCidade = new bool[] {false} ;
         T00303_A992RepresentanteLogradouroNumero = new long[1] ;
         T00303_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         T00303_A993RepresentanteComplemento = new string[] {""} ;
         T00303_n993RepresentanteComplemento = new bool[] {false} ;
         T00303_A994RepresentanteDDD = new short[1] ;
         T00303_n994RepresentanteDDD = new bool[] {false} ;
         T00303_A995RepresentanteNumero = new int[1] ;
         T00303_n995RepresentanteNumero = new bool[] {false} ;
         T00303_A998RepresentanteTipo = new string[] {""} ;
         T00303_n998RepresentanteTipo = new bool[] {false} ;
         T00303_A168ClienteId = new int[1] ;
         T00303_n168ClienteId = new bool[] {false} ;
         T00303_A977RepresentanteProfissao = new int[1] ;
         T00303_n977RepresentanteProfissao = new bool[] {false} ;
         T00303_A991RepresentanteMunicipio = new string[] {""} ;
         T00303_n991RepresentanteMunicipio = new bool[] {false} ;
         T003012_A978RepresentanteId = new int[1] ;
         T003013_A978RepresentanteId = new int[1] ;
         T00302_A978RepresentanteId = new int[1] ;
         T00302_A979RepresentanteNome = new string[] {""} ;
         T00302_n979RepresentanteNome = new bool[] {false} ;
         T00302_A980RepresentanteRG = new string[] {""} ;
         T00302_n980RepresentanteRG = new bool[] {false} ;
         T00302_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         T00302_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         T00302_A982RepresentanteRGUF = new string[] {""} ;
         T00302_n982RepresentanteRGUF = new bool[] {false} ;
         T00302_A983RepresentanteCPF = new string[] {""} ;
         T00302_n983RepresentanteCPF = new bool[] {false} ;
         T00302_A984RepresentanteEstadoCivil = new string[] {""} ;
         T00302_n984RepresentanteEstadoCivil = new bool[] {false} ;
         T00302_A985RepresentanteNacionalidade = new string[] {""} ;
         T00302_n985RepresentanteNacionalidade = new bool[] {false} ;
         T00302_A986RepresentanteEmail = new string[] {""} ;
         T00302_n986RepresentanteEmail = new bool[] {false} ;
         T00302_A987RepresentanteCEP = new string[] {""} ;
         T00302_n987RepresentanteCEP = new bool[] {false} ;
         T00302_A988RepresentanteLogradouro = new string[] {""} ;
         T00302_n988RepresentanteLogradouro = new bool[] {false} ;
         T00302_A989RepresentanteBairro = new string[] {""} ;
         T00302_n989RepresentanteBairro = new bool[] {false} ;
         T00302_A990RepresentanteCidade = new string[] {""} ;
         T00302_n990RepresentanteCidade = new bool[] {false} ;
         T00302_A992RepresentanteLogradouroNumero = new long[1] ;
         T00302_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         T00302_A993RepresentanteComplemento = new string[] {""} ;
         T00302_n993RepresentanteComplemento = new bool[] {false} ;
         T00302_A994RepresentanteDDD = new short[1] ;
         T00302_n994RepresentanteDDD = new bool[] {false} ;
         T00302_A995RepresentanteNumero = new int[1] ;
         T00302_n995RepresentanteNumero = new bool[] {false} ;
         T00302_A998RepresentanteTipo = new string[] {""} ;
         T00302_n998RepresentanteTipo = new bool[] {false} ;
         T00302_A168ClienteId = new int[1] ;
         T00302_n168ClienteId = new bool[] {false} ;
         T00302_A977RepresentanteProfissao = new int[1] ;
         T00302_n977RepresentanteProfissao = new bool[] {false} ;
         T00302_A991RepresentanteMunicipio = new string[] {""} ;
         T00302_n991RepresentanteMunicipio = new bool[] {false} ;
         T003015_A978RepresentanteId = new int[1] ;
         T003018_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         T003018_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         T003019_A996RepresentanteMunicipioUF = new string[] {""} ;
         T003019_n996RepresentanteMunicipioUF = new bool[] {false} ;
         T003019_A997RepresentanteMunicipioNome = new string[] {""} ;
         T003019_n997RepresentanteMunicipioNome = new bool[] {false} ;
         T003020_A978RepresentanteId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T003021_A168ClienteId = new int[1] ;
         T003021_n168ClienteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.representante__default(),
            new Object[][] {
                new Object[] {
               T00302_A978RepresentanteId, T00302_A979RepresentanteNome, T00302_n979RepresentanteNome, T00302_A980RepresentanteRG, T00302_n980RepresentanteRG, T00302_A981RepresentanteOrgaoExpedidor, T00302_n981RepresentanteOrgaoExpedidor, T00302_A982RepresentanteRGUF, T00302_n982RepresentanteRGUF, T00302_A983RepresentanteCPF,
               T00302_n983RepresentanteCPF, T00302_A984RepresentanteEstadoCivil, T00302_n984RepresentanteEstadoCivil, T00302_A985RepresentanteNacionalidade, T00302_n985RepresentanteNacionalidade, T00302_A986RepresentanteEmail, T00302_n986RepresentanteEmail, T00302_A987RepresentanteCEP, T00302_n987RepresentanteCEP, T00302_A988RepresentanteLogradouro,
               T00302_n988RepresentanteLogradouro, T00302_A989RepresentanteBairro, T00302_n989RepresentanteBairro, T00302_A990RepresentanteCidade, T00302_n990RepresentanteCidade, T00302_A992RepresentanteLogradouroNumero, T00302_n992RepresentanteLogradouroNumero, T00302_A993RepresentanteComplemento, T00302_n993RepresentanteComplemento, T00302_A994RepresentanteDDD,
               T00302_n994RepresentanteDDD, T00302_A995RepresentanteNumero, T00302_n995RepresentanteNumero, T00302_A998RepresentanteTipo, T00302_n998RepresentanteTipo, T00302_A168ClienteId, T00302_n168ClienteId, T00302_A977RepresentanteProfissao, T00302_n977RepresentanteProfissao, T00302_A991RepresentanteMunicipio,
               T00302_n991RepresentanteMunicipio
               }
               , new Object[] {
               T00303_A978RepresentanteId, T00303_A979RepresentanteNome, T00303_n979RepresentanteNome, T00303_A980RepresentanteRG, T00303_n980RepresentanteRG, T00303_A981RepresentanteOrgaoExpedidor, T00303_n981RepresentanteOrgaoExpedidor, T00303_A982RepresentanteRGUF, T00303_n982RepresentanteRGUF, T00303_A983RepresentanteCPF,
               T00303_n983RepresentanteCPF, T00303_A984RepresentanteEstadoCivil, T00303_n984RepresentanteEstadoCivil, T00303_A985RepresentanteNacionalidade, T00303_n985RepresentanteNacionalidade, T00303_A986RepresentanteEmail, T00303_n986RepresentanteEmail, T00303_A987RepresentanteCEP, T00303_n987RepresentanteCEP, T00303_A988RepresentanteLogradouro,
               T00303_n988RepresentanteLogradouro, T00303_A989RepresentanteBairro, T00303_n989RepresentanteBairro, T00303_A990RepresentanteCidade, T00303_n990RepresentanteCidade, T00303_A992RepresentanteLogradouroNumero, T00303_n992RepresentanteLogradouroNumero, T00303_A993RepresentanteComplemento, T00303_n993RepresentanteComplemento, T00303_A994RepresentanteDDD,
               T00303_n994RepresentanteDDD, T00303_A995RepresentanteNumero, T00303_n995RepresentanteNumero, T00303_A998RepresentanteTipo, T00303_n998RepresentanteTipo, T00303_A168ClienteId, T00303_n168ClienteId, T00303_A977RepresentanteProfissao, T00303_n977RepresentanteProfissao, T00303_A991RepresentanteMunicipio,
               T00303_n991RepresentanteMunicipio
               }
               , new Object[] {
               T00304_A168ClienteId
               }
               , new Object[] {
               T00305_A999RepresentanteProfissaoDescricao, T00305_n999RepresentanteProfissaoDescricao
               }
               , new Object[] {
               T00306_A996RepresentanteMunicipioUF, T00306_n996RepresentanteMunicipioUF, T00306_A997RepresentanteMunicipioNome, T00306_n997RepresentanteMunicipioNome
               }
               , new Object[] {
               T00307_A978RepresentanteId, T00307_A979RepresentanteNome, T00307_n979RepresentanteNome, T00307_A980RepresentanteRG, T00307_n980RepresentanteRG, T00307_A981RepresentanteOrgaoExpedidor, T00307_n981RepresentanteOrgaoExpedidor, T00307_A982RepresentanteRGUF, T00307_n982RepresentanteRGUF, T00307_A983RepresentanteCPF,
               T00307_n983RepresentanteCPF, T00307_A984RepresentanteEstadoCivil, T00307_n984RepresentanteEstadoCivil, T00307_A985RepresentanteNacionalidade, T00307_n985RepresentanteNacionalidade, T00307_A999RepresentanteProfissaoDescricao, T00307_n999RepresentanteProfissaoDescricao, T00307_A986RepresentanteEmail, T00307_n986RepresentanteEmail, T00307_A987RepresentanteCEP,
               T00307_n987RepresentanteCEP, T00307_A988RepresentanteLogradouro, T00307_n988RepresentanteLogradouro, T00307_A989RepresentanteBairro, T00307_n989RepresentanteBairro, T00307_A990RepresentanteCidade, T00307_n990RepresentanteCidade, T00307_A992RepresentanteLogradouroNumero, T00307_n992RepresentanteLogradouroNumero, T00307_A993RepresentanteComplemento,
               T00307_n993RepresentanteComplemento, T00307_A994RepresentanteDDD, T00307_n994RepresentanteDDD, T00307_A995RepresentanteNumero, T00307_n995RepresentanteNumero, T00307_A996RepresentanteMunicipioUF, T00307_n996RepresentanteMunicipioUF, T00307_A997RepresentanteMunicipioNome, T00307_n997RepresentanteMunicipioNome, T00307_A998RepresentanteTipo,
               T00307_n998RepresentanteTipo, T00307_A168ClienteId, T00307_n168ClienteId, T00307_A977RepresentanteProfissao, T00307_n977RepresentanteProfissao, T00307_A991RepresentanteMunicipio, T00307_n991RepresentanteMunicipio
               }
               , new Object[] {
               T00308_A999RepresentanteProfissaoDescricao, T00308_n999RepresentanteProfissaoDescricao
               }
               , new Object[] {
               T00309_A996RepresentanteMunicipioUF, T00309_n996RepresentanteMunicipioUF, T00309_A997RepresentanteMunicipioNome, T00309_n997RepresentanteMunicipioNome
               }
               , new Object[] {
               T003010_A168ClienteId
               }
               , new Object[] {
               T003011_A978RepresentanteId
               }
               , new Object[] {
               T003012_A978RepresentanteId
               }
               , new Object[] {
               T003013_A978RepresentanteId
               }
               , new Object[] {
               }
               , new Object[] {
               T003015_A978RepresentanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003018_A999RepresentanteProfissaoDescricao, T003018_n999RepresentanteProfissaoDescricao
               }
               , new Object[] {
               T003019_A996RepresentanteMunicipioUF, T003019_n996RepresentanteMunicipioUF, T003019_A997RepresentanteMunicipioNome, T003019_n997RepresentanteMunicipioNome
               }
               , new Object[] {
               T003020_A978RepresentanteId
               }
               , new Object[] {
               T003021_A168ClienteId
               }
            }
         );
         AV27Pgmname = "Representante";
      }

      private short Z994RepresentanteDDD ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A994RepresentanteDDD ;
      private short RcdFound104 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7RepresentanteId ;
      private int Z978RepresentanteId ;
      private int Z995RepresentanteNumero ;
      private int Z168ClienteId ;
      private int Z977RepresentanteProfissao ;
      private int N977RepresentanteProfissao ;
      private int N168ClienteId ;
      private int A977RepresentanteProfissao ;
      private int A168ClienteId ;
      private int AV7RepresentanteId ;
      private int trnEnded ;
      private int A978RepresentanteId ;
      private int edtRepresentanteId_Enabled ;
      private int edtRepresentanteNome_Enabled ;
      private int edtRepresentanteRG_Enabled ;
      private int edtRepresentanteOrgaoExpedidor_Enabled ;
      private int edtRepresentanteRGUF_Enabled ;
      private int edtRepresentanteCPF_Enabled ;
      private int edtRepresentanteNacionalidade_Enabled ;
      private int edtRepresentanteProfissao_Visible ;
      private int edtRepresentanteProfissao_Enabled ;
      private int edtRepresentanteEmail_Enabled ;
      private int edtRepresentanteCEP_Enabled ;
      private int edtRepresentanteLogradouro_Enabled ;
      private int edtRepresentanteBairro_Enabled ;
      private int edtRepresentanteCidade_Enabled ;
      private int edtRepresentanteMunicipio_Visible ;
      private int edtRepresentanteMunicipio_Enabled ;
      private int edtRepresentanteLogradouroNumero_Enabled ;
      private int edtRepresentanteComplemento_Enabled ;
      private int edtRepresentanteDDD_Enabled ;
      private int A995RepresentanteNumero ;
      private int edtRepresentanteNumero_Enabled ;
      private int edtRepresentanteMunicipioUF_Enabled ;
      private int edtClienteId_Visible ;
      private int edtClienteId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV20ComboRepresentanteProfissao ;
      private int edtavComborepresentanteprofissao_Enabled ;
      private int edtavComborepresentanteprofissao_Visible ;
      private int edtavComborepresentantemunicipio_Visible ;
      private int edtavComborepresentantemunicipio_Enabled ;
      private int AV26ComboClienteId ;
      private int edtavComboclienteid_Enabled ;
      private int edtavComboclienteid_Visible ;
      private int AV11Insert_RepresentanteProfissao ;
      private int AV13Insert_ClienteId ;
      private int Combo_representanteprofissao_Datalistupdateminimumcharacters ;
      private int Combo_representanteprofissao_Gxcontroltype ;
      private int Combo_representantemunicipio_Datalistupdateminimumcharacters ;
      private int Combo_representantemunicipio_Gxcontroltype ;
      private int Combo_clienteid_Datalistupdateminimumcharacters ;
      private int Combo_clienteid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV28GXV1 ;
      private int idxLst ;
      private long Z992RepresentanteLogradouroNumero ;
      private long A992RepresentanteLogradouroNumero ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_clienteid_Selectedvalue_get ;
      private string Combo_representantemunicipio_Selectedvalue_get ;
      private string Combo_representanteprofissao_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRepresentanteNome_Internalname ;
      private string cmbRepresentanteEstadoCivil_Internalname ;
      private string cmbRepresentanteTipo_Internalname ;
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
      private string edtRepresentanteId_Internalname ;
      private string TempTags ;
      private string edtRepresentanteId_Jsonclick ;
      private string edtRepresentanteNome_Jsonclick ;
      private string edtRepresentanteRG_Internalname ;
      private string edtRepresentanteRG_Jsonclick ;
      private string edtRepresentanteOrgaoExpedidor_Internalname ;
      private string edtRepresentanteOrgaoExpedidor_Jsonclick ;
      private string edtRepresentanteRGUF_Internalname ;
      private string edtRepresentanteRGUF_Jsonclick ;
      private string edtRepresentanteCPF_Internalname ;
      private string edtRepresentanteCPF_Jsonclick ;
      private string cmbRepresentanteEstadoCivil_Jsonclick ;
      private string edtRepresentanteNacionalidade_Internalname ;
      private string edtRepresentanteNacionalidade_Jsonclick ;
      private string divTablesplittedrepresentanteprofissao_Internalname ;
      private string lblTextblockrepresentanteprofissao_Internalname ;
      private string lblTextblockrepresentanteprofissao_Jsonclick ;
      private string Combo_representanteprofissao_Caption ;
      private string Combo_representanteprofissao_Cls ;
      private string Combo_representanteprofissao_Datalistproc ;
      private string Combo_representanteprofissao_Datalistprocparametersprefix ;
      private string Combo_representanteprofissao_Internalname ;
      private string edtRepresentanteProfissao_Internalname ;
      private string edtRepresentanteProfissao_Jsonclick ;
      private string edtRepresentanteEmail_Internalname ;
      private string edtRepresentanteEmail_Jsonclick ;
      private string edtRepresentanteCEP_Internalname ;
      private string edtRepresentanteCEP_Jsonclick ;
      private string edtRepresentanteLogradouro_Internalname ;
      private string edtRepresentanteLogradouro_Jsonclick ;
      private string edtRepresentanteBairro_Internalname ;
      private string edtRepresentanteBairro_Jsonclick ;
      private string edtRepresentanteCidade_Internalname ;
      private string edtRepresentanteCidade_Jsonclick ;
      private string divTablesplittedrepresentantemunicipio_Internalname ;
      private string lblTextblockrepresentantemunicipio_Internalname ;
      private string lblTextblockrepresentantemunicipio_Jsonclick ;
      private string Combo_representantemunicipio_Caption ;
      private string Combo_representantemunicipio_Cls ;
      private string Combo_representantemunicipio_Datalistproc ;
      private string Combo_representantemunicipio_Datalistprocparametersprefix ;
      private string Combo_representantemunicipio_Internalname ;
      private string edtRepresentanteMunicipio_Internalname ;
      private string edtRepresentanteMunicipio_Jsonclick ;
      private string edtRepresentanteLogradouroNumero_Internalname ;
      private string edtRepresentanteLogradouroNumero_Jsonclick ;
      private string edtRepresentanteComplemento_Internalname ;
      private string edtRepresentanteComplemento_Jsonclick ;
      private string edtRepresentanteDDD_Internalname ;
      private string edtRepresentanteDDD_Jsonclick ;
      private string edtRepresentanteNumero_Internalname ;
      private string edtRepresentanteNumero_Jsonclick ;
      private string edtRepresentanteMunicipioUF_Internalname ;
      private string edtRepresentanteMunicipioUF_Jsonclick ;
      private string cmbRepresentanteTipo_Jsonclick ;
      private string divTablesplittedclienteid_Internalname ;
      private string lblTextblockclienteid_Internalname ;
      private string lblTextblockclienteid_Jsonclick ;
      private string Combo_clienteid_Caption ;
      private string Combo_clienteid_Cls ;
      private string Combo_clienteid_Datalistproc ;
      private string Combo_clienteid_Datalistprocparametersprefix ;
      private string Combo_clienteid_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_representanteprofissao_Internalname ;
      private string edtavComborepresentanteprofissao_Internalname ;
      private string edtavComborepresentanteprofissao_Jsonclick ;
      private string divSectionattribute_representantemunicipio_Internalname ;
      private string edtavComborepresentantemunicipio_Internalname ;
      private string edtavComborepresentantemunicipio_Jsonclick ;
      private string divSectionattribute_clienteid_Internalname ;
      private string edtavComboclienteid_Internalname ;
      private string edtavComboclienteid_Jsonclick ;
      private string AV27Pgmname ;
      private string Combo_representanteprofissao_Objectcall ;
      private string Combo_representanteprofissao_Class ;
      private string Combo_representanteprofissao_Icontype ;
      private string Combo_representanteprofissao_Icon ;
      private string Combo_representanteprofissao_Tooltip ;
      private string Combo_representanteprofissao_Selectedvalue_set ;
      private string Combo_representanteprofissao_Selectedtext_set ;
      private string Combo_representanteprofissao_Selectedtext_get ;
      private string Combo_representanteprofissao_Gamoauthtoken ;
      private string Combo_representanteprofissao_Ddointernalname ;
      private string Combo_representanteprofissao_Titlecontrolalign ;
      private string Combo_representanteprofissao_Dropdownoptionstype ;
      private string Combo_representanteprofissao_Titlecontrolidtoreplace ;
      private string Combo_representanteprofissao_Datalisttype ;
      private string Combo_representanteprofissao_Datalistfixedvalues ;
      private string Combo_representanteprofissao_Remoteservicesparameters ;
      private string Combo_representanteprofissao_Htmltemplate ;
      private string Combo_representanteprofissao_Multiplevaluestype ;
      private string Combo_representanteprofissao_Loadingdata ;
      private string Combo_representanteprofissao_Noresultsfound ;
      private string Combo_representanteprofissao_Emptyitemtext ;
      private string Combo_representanteprofissao_Onlyselectedvalues ;
      private string Combo_representanteprofissao_Selectalltext ;
      private string Combo_representanteprofissao_Multiplevaluesseparator ;
      private string Combo_representanteprofissao_Addnewoptiontext ;
      private string Combo_representantemunicipio_Objectcall ;
      private string Combo_representantemunicipio_Class ;
      private string Combo_representantemunicipio_Icontype ;
      private string Combo_representantemunicipio_Icon ;
      private string Combo_representantemunicipio_Tooltip ;
      private string Combo_representantemunicipio_Selectedvalue_set ;
      private string Combo_representantemunicipio_Selectedtext_set ;
      private string Combo_representantemunicipio_Selectedtext_get ;
      private string Combo_representantemunicipio_Gamoauthtoken ;
      private string Combo_representantemunicipio_Ddointernalname ;
      private string Combo_representantemunicipio_Titlecontrolalign ;
      private string Combo_representantemunicipio_Dropdownoptionstype ;
      private string Combo_representantemunicipio_Titlecontrolidtoreplace ;
      private string Combo_representantemunicipio_Datalisttype ;
      private string Combo_representantemunicipio_Datalistfixedvalues ;
      private string Combo_representantemunicipio_Remoteservicesparameters ;
      private string Combo_representantemunicipio_Htmltemplate ;
      private string Combo_representantemunicipio_Multiplevaluestype ;
      private string Combo_representantemunicipio_Loadingdata ;
      private string Combo_representantemunicipio_Noresultsfound ;
      private string Combo_representantemunicipio_Emptyitemtext ;
      private string Combo_representantemunicipio_Onlyselectedvalues ;
      private string Combo_representantemunicipio_Selectalltext ;
      private string Combo_representantemunicipio_Multiplevaluesseparator ;
      private string Combo_representantemunicipio_Addnewoptiontext ;
      private string Combo_clienteid_Objectcall ;
      private string Combo_clienteid_Class ;
      private string Combo_clienteid_Icontype ;
      private string Combo_clienteid_Icon ;
      private string Combo_clienteid_Tooltip ;
      private string Combo_clienteid_Selectedvalue_set ;
      private string Combo_clienteid_Selectedtext_set ;
      private string Combo_clienteid_Selectedtext_get ;
      private string Combo_clienteid_Gamoauthtoken ;
      private string Combo_clienteid_Ddointernalname ;
      private string Combo_clienteid_Titlecontrolalign ;
      private string Combo_clienteid_Dropdownoptionstype ;
      private string Combo_clienteid_Titlecontrolidtoreplace ;
      private string Combo_clienteid_Datalisttype ;
      private string Combo_clienteid_Datalistfixedvalues ;
      private string Combo_clienteid_Remoteservicesparameters ;
      private string Combo_clienteid_Htmltemplate ;
      private string Combo_clienteid_Multiplevaluestype ;
      private string Combo_clienteid_Loadingdata ;
      private string Combo_clienteid_Noresultsfound ;
      private string Combo_clienteid_Emptyitemtext ;
      private string Combo_clienteid_Onlyselectedvalues ;
      private string Combo_clienteid_Selectalltext ;
      private string Combo_clienteid_Multiplevaluesseparator ;
      private string Combo_clienteid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode104 ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n977RepresentanteProfissao ;
      private bool n991RepresentanteMunicipio ;
      private bool n168ClienteId ;
      private bool wbErr ;
      private bool n984RepresentanteEstadoCivil ;
      private bool n998RepresentanteTipo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n992RepresentanteLogradouroNumero ;
      private bool n994RepresentanteDDD ;
      private bool n995RepresentanteNumero ;
      private bool n979RepresentanteNome ;
      private bool n980RepresentanteRG ;
      private bool n981RepresentanteOrgaoExpedidor ;
      private bool n982RepresentanteRGUF ;
      private bool n983RepresentanteCPF ;
      private bool n985RepresentanteNacionalidade ;
      private bool n986RepresentanteEmail ;
      private bool n987RepresentanteCEP ;
      private bool n988RepresentanteLogradouro ;
      private bool n989RepresentanteBairro ;
      private bool n990RepresentanteCidade ;
      private bool n993RepresentanteComplemento ;
      private bool n999RepresentanteProfissaoDescricao ;
      private bool n997RepresentanteMunicipioNome ;
      private bool Combo_representanteprofissao_Enabled ;
      private bool Combo_representanteprofissao_Visible ;
      private bool Combo_representanteprofissao_Allowmultipleselection ;
      private bool Combo_representanteprofissao_Isgriditem ;
      private bool Combo_representanteprofissao_Hasdescription ;
      private bool Combo_representanteprofissao_Includeonlyselectedoption ;
      private bool Combo_representanteprofissao_Includeselectalloption ;
      private bool Combo_representanteprofissao_Emptyitem ;
      private bool Combo_representanteprofissao_Includeaddnewoption ;
      private bool Combo_representantemunicipio_Enabled ;
      private bool Combo_representantemunicipio_Visible ;
      private bool Combo_representantemunicipio_Allowmultipleselection ;
      private bool Combo_representantemunicipio_Isgriditem ;
      private bool Combo_representantemunicipio_Hasdescription ;
      private bool Combo_representantemunicipio_Includeonlyselectedoption ;
      private bool Combo_representantemunicipio_Includeselectalloption ;
      private bool Combo_representantemunicipio_Emptyitem ;
      private bool Combo_representantemunicipio_Includeaddnewoption ;
      private bool Combo_clienteid_Enabled ;
      private bool Combo_clienteid_Visible ;
      private bool Combo_clienteid_Allowmultipleselection ;
      private bool Combo_clienteid_Isgriditem ;
      private bool Combo_clienteid_Hasdescription ;
      private bool Combo_clienteid_Includeonlyselectedoption ;
      private bool Combo_clienteid_Includeselectalloption ;
      private bool Combo_clienteid_Emptyitem ;
      private bool Combo_clienteid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n996RepresentanteMunicipioUF ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV19Combo_DataJson ;
      private string Z979RepresentanteNome ;
      private string Z980RepresentanteRG ;
      private string Z981RepresentanteOrgaoExpedidor ;
      private string Z982RepresentanteRGUF ;
      private string Z983RepresentanteCPF ;
      private string Z984RepresentanteEstadoCivil ;
      private string Z985RepresentanteNacionalidade ;
      private string Z986RepresentanteEmail ;
      private string Z987RepresentanteCEP ;
      private string Z988RepresentanteLogradouro ;
      private string Z989RepresentanteBairro ;
      private string Z990RepresentanteCidade ;
      private string Z993RepresentanteComplemento ;
      private string Z998RepresentanteTipo ;
      private string Z991RepresentanteMunicipio ;
      private string N991RepresentanteMunicipio ;
      private string A991RepresentanteMunicipio ;
      private string A984RepresentanteEstadoCivil ;
      private string A998RepresentanteTipo ;
      private string A979RepresentanteNome ;
      private string A980RepresentanteRG ;
      private string A981RepresentanteOrgaoExpedidor ;
      private string A982RepresentanteRGUF ;
      private string A983RepresentanteCPF ;
      private string A985RepresentanteNacionalidade ;
      private string A986RepresentanteEmail ;
      private string A987RepresentanteCEP ;
      private string A988RepresentanteLogradouro ;
      private string A989RepresentanteBairro ;
      private string A990RepresentanteCidade ;
      private string A993RepresentanteComplemento ;
      private string A996RepresentanteMunicipioUF ;
      private string AV23ComboRepresentanteMunicipio ;
      private string AV12Insert_RepresentanteMunicipio ;
      private string A999RepresentanteProfissaoDescricao ;
      private string A997RepresentanteMunicipioNome ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z999RepresentanteProfissaoDescricao ;
      private string Z996RepresentanteMunicipioUF ;
      private string Z997RepresentanteMunicipioNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_representanteprofissao ;
      private GXUserControl ucCombo_representantemunicipio ;
      private GXUserControl ucCombo_clienteid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbRepresentanteEstadoCivil ;
      private GXCombobox cmbRepresentanteTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15RepresentanteProfissao_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22RepresentanteMunicipio_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25ClienteId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00305_A999RepresentanteProfissaoDescricao ;
      private bool[] T00305_n999RepresentanteProfissaoDescricao ;
      private string[] T00306_A996RepresentanteMunicipioUF ;
      private bool[] T00306_n996RepresentanteMunicipioUF ;
      private string[] T00306_A997RepresentanteMunicipioNome ;
      private bool[] T00306_n997RepresentanteMunicipioNome ;
      private int[] T00307_A978RepresentanteId ;
      private string[] T00307_A979RepresentanteNome ;
      private bool[] T00307_n979RepresentanteNome ;
      private string[] T00307_A980RepresentanteRG ;
      private bool[] T00307_n980RepresentanteRG ;
      private string[] T00307_A981RepresentanteOrgaoExpedidor ;
      private bool[] T00307_n981RepresentanteOrgaoExpedidor ;
      private string[] T00307_A982RepresentanteRGUF ;
      private bool[] T00307_n982RepresentanteRGUF ;
      private string[] T00307_A983RepresentanteCPF ;
      private bool[] T00307_n983RepresentanteCPF ;
      private string[] T00307_A984RepresentanteEstadoCivil ;
      private bool[] T00307_n984RepresentanteEstadoCivil ;
      private string[] T00307_A985RepresentanteNacionalidade ;
      private bool[] T00307_n985RepresentanteNacionalidade ;
      private string[] T00307_A999RepresentanteProfissaoDescricao ;
      private bool[] T00307_n999RepresentanteProfissaoDescricao ;
      private string[] T00307_A986RepresentanteEmail ;
      private bool[] T00307_n986RepresentanteEmail ;
      private string[] T00307_A987RepresentanteCEP ;
      private bool[] T00307_n987RepresentanteCEP ;
      private string[] T00307_A988RepresentanteLogradouro ;
      private bool[] T00307_n988RepresentanteLogradouro ;
      private string[] T00307_A989RepresentanteBairro ;
      private bool[] T00307_n989RepresentanteBairro ;
      private string[] T00307_A990RepresentanteCidade ;
      private bool[] T00307_n990RepresentanteCidade ;
      private long[] T00307_A992RepresentanteLogradouroNumero ;
      private bool[] T00307_n992RepresentanteLogradouroNumero ;
      private string[] T00307_A993RepresentanteComplemento ;
      private bool[] T00307_n993RepresentanteComplemento ;
      private short[] T00307_A994RepresentanteDDD ;
      private bool[] T00307_n994RepresentanteDDD ;
      private int[] T00307_A995RepresentanteNumero ;
      private bool[] T00307_n995RepresentanteNumero ;
      private string[] T00307_A996RepresentanteMunicipioUF ;
      private bool[] T00307_n996RepresentanteMunicipioUF ;
      private string[] T00307_A997RepresentanteMunicipioNome ;
      private bool[] T00307_n997RepresentanteMunicipioNome ;
      private string[] T00307_A998RepresentanteTipo ;
      private bool[] T00307_n998RepresentanteTipo ;
      private int[] T00307_A168ClienteId ;
      private bool[] T00307_n168ClienteId ;
      private int[] T00307_A977RepresentanteProfissao ;
      private bool[] T00307_n977RepresentanteProfissao ;
      private string[] T00307_A991RepresentanteMunicipio ;
      private bool[] T00307_n991RepresentanteMunicipio ;
      private int[] T00304_A168ClienteId ;
      private bool[] T00304_n168ClienteId ;
      private string[] T00308_A999RepresentanteProfissaoDescricao ;
      private bool[] T00308_n999RepresentanteProfissaoDescricao ;
      private string[] T00309_A996RepresentanteMunicipioUF ;
      private bool[] T00309_n996RepresentanteMunicipioUF ;
      private string[] T00309_A997RepresentanteMunicipioNome ;
      private bool[] T00309_n997RepresentanteMunicipioNome ;
      private int[] T003010_A168ClienteId ;
      private bool[] T003010_n168ClienteId ;
      private int[] T003011_A978RepresentanteId ;
      private int[] T00303_A978RepresentanteId ;
      private string[] T00303_A979RepresentanteNome ;
      private bool[] T00303_n979RepresentanteNome ;
      private string[] T00303_A980RepresentanteRG ;
      private bool[] T00303_n980RepresentanteRG ;
      private string[] T00303_A981RepresentanteOrgaoExpedidor ;
      private bool[] T00303_n981RepresentanteOrgaoExpedidor ;
      private string[] T00303_A982RepresentanteRGUF ;
      private bool[] T00303_n982RepresentanteRGUF ;
      private string[] T00303_A983RepresentanteCPF ;
      private bool[] T00303_n983RepresentanteCPF ;
      private string[] T00303_A984RepresentanteEstadoCivil ;
      private bool[] T00303_n984RepresentanteEstadoCivil ;
      private string[] T00303_A985RepresentanteNacionalidade ;
      private bool[] T00303_n985RepresentanteNacionalidade ;
      private string[] T00303_A986RepresentanteEmail ;
      private bool[] T00303_n986RepresentanteEmail ;
      private string[] T00303_A987RepresentanteCEP ;
      private bool[] T00303_n987RepresentanteCEP ;
      private string[] T00303_A988RepresentanteLogradouro ;
      private bool[] T00303_n988RepresentanteLogradouro ;
      private string[] T00303_A989RepresentanteBairro ;
      private bool[] T00303_n989RepresentanteBairro ;
      private string[] T00303_A990RepresentanteCidade ;
      private bool[] T00303_n990RepresentanteCidade ;
      private long[] T00303_A992RepresentanteLogradouroNumero ;
      private bool[] T00303_n992RepresentanteLogradouroNumero ;
      private string[] T00303_A993RepresentanteComplemento ;
      private bool[] T00303_n993RepresentanteComplemento ;
      private short[] T00303_A994RepresentanteDDD ;
      private bool[] T00303_n994RepresentanteDDD ;
      private int[] T00303_A995RepresentanteNumero ;
      private bool[] T00303_n995RepresentanteNumero ;
      private string[] T00303_A998RepresentanteTipo ;
      private bool[] T00303_n998RepresentanteTipo ;
      private int[] T00303_A168ClienteId ;
      private bool[] T00303_n168ClienteId ;
      private int[] T00303_A977RepresentanteProfissao ;
      private bool[] T00303_n977RepresentanteProfissao ;
      private string[] T00303_A991RepresentanteMunicipio ;
      private bool[] T00303_n991RepresentanteMunicipio ;
      private int[] T003012_A978RepresentanteId ;
      private int[] T003013_A978RepresentanteId ;
      private int[] T00302_A978RepresentanteId ;
      private string[] T00302_A979RepresentanteNome ;
      private bool[] T00302_n979RepresentanteNome ;
      private string[] T00302_A980RepresentanteRG ;
      private bool[] T00302_n980RepresentanteRG ;
      private string[] T00302_A981RepresentanteOrgaoExpedidor ;
      private bool[] T00302_n981RepresentanteOrgaoExpedidor ;
      private string[] T00302_A982RepresentanteRGUF ;
      private bool[] T00302_n982RepresentanteRGUF ;
      private string[] T00302_A983RepresentanteCPF ;
      private bool[] T00302_n983RepresentanteCPF ;
      private string[] T00302_A984RepresentanteEstadoCivil ;
      private bool[] T00302_n984RepresentanteEstadoCivil ;
      private string[] T00302_A985RepresentanteNacionalidade ;
      private bool[] T00302_n985RepresentanteNacionalidade ;
      private string[] T00302_A986RepresentanteEmail ;
      private bool[] T00302_n986RepresentanteEmail ;
      private string[] T00302_A987RepresentanteCEP ;
      private bool[] T00302_n987RepresentanteCEP ;
      private string[] T00302_A988RepresentanteLogradouro ;
      private bool[] T00302_n988RepresentanteLogradouro ;
      private string[] T00302_A989RepresentanteBairro ;
      private bool[] T00302_n989RepresentanteBairro ;
      private string[] T00302_A990RepresentanteCidade ;
      private bool[] T00302_n990RepresentanteCidade ;
      private long[] T00302_A992RepresentanteLogradouroNumero ;
      private bool[] T00302_n992RepresentanteLogradouroNumero ;
      private string[] T00302_A993RepresentanteComplemento ;
      private bool[] T00302_n993RepresentanteComplemento ;
      private short[] T00302_A994RepresentanteDDD ;
      private bool[] T00302_n994RepresentanteDDD ;
      private int[] T00302_A995RepresentanteNumero ;
      private bool[] T00302_n995RepresentanteNumero ;
      private string[] T00302_A998RepresentanteTipo ;
      private bool[] T00302_n998RepresentanteTipo ;
      private int[] T00302_A168ClienteId ;
      private bool[] T00302_n168ClienteId ;
      private int[] T00302_A977RepresentanteProfissao ;
      private bool[] T00302_n977RepresentanteProfissao ;
      private string[] T00302_A991RepresentanteMunicipio ;
      private bool[] T00302_n991RepresentanteMunicipio ;
      private int[] T003015_A978RepresentanteId ;
      private string[] T003018_A999RepresentanteProfissaoDescricao ;
      private bool[] T003018_n999RepresentanteProfissaoDescricao ;
      private string[] T003019_A996RepresentanteMunicipioUF ;
      private bool[] T003019_n996RepresentanteMunicipioUF ;
      private string[] T003019_A997RepresentanteMunicipioNome ;
      private bool[] T003019_n997RepresentanteMunicipioNome ;
      private int[] T003020_A978RepresentanteId ;
      private int[] T003021_A168ClienteId ;
      private bool[] T003021_n168ClienteId ;
   }

   public class representante__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00302;
          prmT00302 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT00303;
          prmT00303 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT00304;
          prmT00304 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00305;
          prmT00305 = new Object[] {
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00306;
          prmT00306 = new Object[] {
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT00307;
          prmT00307 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT00308;
          prmT00308 = new Object[] {
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00309;
          prmT00309 = new Object[] {
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT003010;
          prmT003010 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003011;
          prmT003011 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT003012;
          prmT003012 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT003013;
          prmT003013 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT003014;
          prmT003014 = new Object[] {
          new ParDef("RepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteRG",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteOrgaoExpedidor",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteRGUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteNacionalidade",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("RepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("RepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("RepresentanteNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT003015;
          prmT003015 = new Object[] {
          };
          Object[] prmT003016;
          prmT003016 = new Object[] {
          new ParDef("RepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteRG",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteOrgaoExpedidor",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteRGUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteNacionalidade",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("RepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("RepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("RepresentanteNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT003017;
          prmT003017 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmT003018;
          prmT003018 = new Object[] {
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003019;
          prmT003019 = new Object[] {
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT003020;
          prmT003020 = new Object[] {
          };
          Object[] prmT003021;
          prmT003021 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00302", "SELECT RepresentanteId, RepresentanteNome, RepresentanteRG, RepresentanteOrgaoExpedidor, RepresentanteRGUF, RepresentanteCPF, RepresentanteEstadoCivil, RepresentanteNacionalidade, RepresentanteEmail, RepresentanteCEP, RepresentanteLogradouro, RepresentanteBairro, RepresentanteCidade, RepresentanteLogradouroNumero, RepresentanteComplemento, RepresentanteDDD, RepresentanteNumero, RepresentanteTipo, ClienteId, RepresentanteProfissao, RepresentanteMunicipio FROM Representante WHERE RepresentanteId = :RepresentanteId  FOR UPDATE OF Representante NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00302,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00303", "SELECT RepresentanteId, RepresentanteNome, RepresentanteRG, RepresentanteOrgaoExpedidor, RepresentanteRGUF, RepresentanteCPF, RepresentanteEstadoCivil, RepresentanteNacionalidade, RepresentanteEmail, RepresentanteCEP, RepresentanteLogradouro, RepresentanteBairro, RepresentanteCidade, RepresentanteLogradouroNumero, RepresentanteComplemento, RepresentanteDDD, RepresentanteNumero, RepresentanteTipo, ClienteId, RepresentanteProfissao, RepresentanteMunicipio FROM Representante WHERE RepresentanteId = :RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00303,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00304", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00304,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00305", "SELECT ProfissaoNome AS RepresentanteProfissaoDescricao FROM Profissao WHERE ProfissaoId = :RepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT00305,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00306", "SELECT MunicipioUF AS RepresentanteMunicipioUF, MunicipioNome AS RepresentanteMunicipioNome FROM Municipio WHERE MunicipioCodigo = :RepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT00306,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00307", "SELECT TM1.RepresentanteId, TM1.RepresentanteNome, TM1.RepresentanteRG, TM1.RepresentanteOrgaoExpedidor, TM1.RepresentanteRGUF, TM1.RepresentanteCPF, TM1.RepresentanteEstadoCivil, TM1.RepresentanteNacionalidade, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, TM1.RepresentanteEmail, TM1.RepresentanteCEP, TM1.RepresentanteLogradouro, TM1.RepresentanteBairro, TM1.RepresentanteCidade, TM1.RepresentanteLogradouroNumero, TM1.RepresentanteComplemento, TM1.RepresentanteDDD, TM1.RepresentanteNumero, T3.MunicipioUF AS RepresentanteMunicipioUF, T3.MunicipioNome AS RepresentanteMunicipioNome, TM1.RepresentanteTipo, TM1.ClienteId, TM1.RepresentanteProfissao AS RepresentanteProfissao, TM1.RepresentanteMunicipio AS RepresentanteMunicipio FROM ((Representante TM1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = TM1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.RepresentanteMunicipio) WHERE TM1.RepresentanteId = :RepresentanteId ORDER BY TM1.RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00307,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00308", "SELECT ProfissaoNome AS RepresentanteProfissaoDescricao FROM Profissao WHERE ProfissaoId = :RepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT00308,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00309", "SELECT MunicipioUF AS RepresentanteMunicipioUF, MunicipioNome AS RepresentanteMunicipioNome FROM Municipio WHERE MunicipioCodigo = :RepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT00309,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003010", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003010,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003011", "SELECT RepresentanteId FROM Representante WHERE RepresentanteId = :RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003011,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003012", "SELECT RepresentanteId FROM Representante WHERE ( RepresentanteId > :RepresentanteId) ORDER BY RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003012,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003013", "SELECT RepresentanteId FROM Representante WHERE ( RepresentanteId < :RepresentanteId) ORDER BY RepresentanteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT003013,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003014", "SAVEPOINT gxupdate;INSERT INTO Representante(RepresentanteNome, RepresentanteRG, RepresentanteOrgaoExpedidor, RepresentanteRGUF, RepresentanteCPF, RepresentanteEstadoCivil, RepresentanteNacionalidade, RepresentanteEmail, RepresentanteCEP, RepresentanteLogradouro, RepresentanteBairro, RepresentanteCidade, RepresentanteLogradouroNumero, RepresentanteComplemento, RepresentanteDDD, RepresentanteNumero, RepresentanteTipo, ClienteId, RepresentanteProfissao, RepresentanteMunicipio) VALUES(:RepresentanteNome, :RepresentanteRG, :RepresentanteOrgaoExpedidor, :RepresentanteRGUF, :RepresentanteCPF, :RepresentanteEstadoCivil, :RepresentanteNacionalidade, :RepresentanteEmail, :RepresentanteCEP, :RepresentanteLogradouro, :RepresentanteBairro, :RepresentanteCidade, :RepresentanteLogradouroNumero, :RepresentanteComplemento, :RepresentanteDDD, :RepresentanteNumero, :RepresentanteTipo, :ClienteId, :RepresentanteProfissao, :RepresentanteMunicipio);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003014)
             ,new CursorDef("T003015", "SELECT currval('RepresentanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003016", "SAVEPOINT gxupdate;UPDATE Representante SET RepresentanteNome=:RepresentanteNome, RepresentanteRG=:RepresentanteRG, RepresentanteOrgaoExpedidor=:RepresentanteOrgaoExpedidor, RepresentanteRGUF=:RepresentanteRGUF, RepresentanteCPF=:RepresentanteCPF, RepresentanteEstadoCivil=:RepresentanteEstadoCivil, RepresentanteNacionalidade=:RepresentanteNacionalidade, RepresentanteEmail=:RepresentanteEmail, RepresentanteCEP=:RepresentanteCEP, RepresentanteLogradouro=:RepresentanteLogradouro, RepresentanteBairro=:RepresentanteBairro, RepresentanteCidade=:RepresentanteCidade, RepresentanteLogradouroNumero=:RepresentanteLogradouroNumero, RepresentanteComplemento=:RepresentanteComplemento, RepresentanteDDD=:RepresentanteDDD, RepresentanteNumero=:RepresentanteNumero, RepresentanteTipo=:RepresentanteTipo, ClienteId=:ClienteId, RepresentanteProfissao=:RepresentanteProfissao, RepresentanteMunicipio=:RepresentanteMunicipio  WHERE RepresentanteId = :RepresentanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003016)
             ,new CursorDef("T003017", "SAVEPOINT gxupdate;DELETE FROM Representante  WHERE RepresentanteId = :RepresentanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003017)
             ,new CursorDef("T003018", "SELECT ProfissaoNome AS RepresentanteProfissaoDescricao FROM Profissao WHERE ProfissaoId = :RepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT003018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003019", "SELECT MunicipioUF AS RepresentanteMunicipioUF, MunicipioNome AS RepresentanteMunicipioNome FROM Municipio WHERE MunicipioCodigo = :RepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT003019,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003020", "SELECT RepresentanteId FROM Representante ORDER BY RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003020,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003021", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003021,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
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
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
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
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((long[]) buf[27])[0] = rslt.getLong(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
