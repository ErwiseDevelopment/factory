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
   public class clientetaxas : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "clientetaxas")), "clientetaxas") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "clientetaxas")))) ;
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
                  AV7ClienteTaxasId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteTaxasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ClienteTaxasId", StringUtil.LTrimStr( (decimal)(AV7ClienteTaxasId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteTaxasId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Taxas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientetaxas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientetaxas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ClienteTaxasId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ClienteTaxasId = aP1_ClienteTaxasId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbClienteTaxasTipo = new GXCombobox();
         cmbClienteTaxasTipoTarifa = new GXCombobox();
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
         if ( cmbClienteTaxasTipo.ItemCount > 0 )
         {
            A1009ClienteTaxasTipo = cmbClienteTaxasTipo.getValidValue(A1009ClienteTaxasTipo);
            n1009ClienteTaxasTipo = false;
            AssignAttri("", false, "A1009ClienteTaxasTipo", A1009ClienteTaxasTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClienteTaxasTipo.CurrentValue = StringUtil.RTrim( A1009ClienteTaxasTipo);
            AssignProp("", false, cmbClienteTaxasTipo_Internalname, "Values", cmbClienteTaxasTipo.ToJavascriptSource(), true);
         }
         if ( cmbClienteTaxasTipoTarifa.ItemCount > 0 )
         {
            A1043ClienteTaxasTipoTarifa = cmbClienteTaxasTipoTarifa.getValidValue(A1043ClienteTaxasTipoTarifa);
            n1043ClienteTaxasTipoTarifa = false;
            AssignAttri("", false, "A1043ClienteTaxasTipoTarifa", A1043ClienteTaxasTipoTarifa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClienteTaxasTipoTarifa.CurrentValue = StringUtil.RTrim( A1043ClienteTaxasTipoTarifa);
            AssignProp("", false, cmbClienteTaxasTipoTarifa_Internalname, "Values", cmbClienteTaxasTipoTarifa.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClienteTaxasTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbClienteTaxasTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbClienteTaxasTipo, cmbClienteTaxasTipo_Internalname, StringUtil.RTrim( A1009ClienteTaxasTipo), 1, cmbClienteTaxasTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbClienteTaxasTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_ClienteTaxas.htm");
         cmbClienteTaxasTipo.CurrentValue = StringUtil.RTrim( A1009ClienteTaxasTipo);
         AssignProp("", false, cmbClienteTaxasTipo_Internalname, "Values", (string)(cmbClienteTaxasTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteTaxasEfetiva_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTaxasEfetiva_Internalname, "Taxa Efetiva", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTaxasEfetiva_Internalname, ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva)&&IsIns( )||n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva)&&IsIns( )||n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( ((edtClienteTaxasEfetiva_Enabled!=0) ? context.localUtil.Format( A1040ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1040ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTaxasEfetiva_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteTaxasEfetiva_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_ClienteTaxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteTaxasMora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTaxasMora_Internalname, "Juros Mora", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTaxasMora_Internalname, ((Convert.ToDecimal(0)==A1041ClienteTaxasMora)&&IsIns( )||n1041ClienteTaxasMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1041ClienteTaxasMora)&&IsIns( )||n1041ClienteTaxasMora ? "" : StringUtil.LTrim( ((edtClienteTaxasMora_Enabled!=0) ? context.localUtil.Format( A1041ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1041ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTaxasMora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteTaxasMora_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_ClienteTaxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteTaxasFator_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTaxasFator_Internalname, "Fator", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTaxasFator_Internalname, ((Convert.ToDecimal(0)==A1042ClienteTaxasFator)&&IsIns( )||n1042ClienteTaxasFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1042ClienteTaxasFator)&&IsIns( )||n1042ClienteTaxasFator ? "" : StringUtil.LTrim( ((edtClienteTaxasFator_Enabled!=0) ? context.localUtil.Format( A1042ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1042ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTaxasFator_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteTaxasFator_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_ClienteTaxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClienteTaxasTipoTarifa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbClienteTaxasTipoTarifa_Internalname, "Tipo da Tarifa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbClienteTaxasTipoTarifa, cmbClienteTaxasTipoTarifa_Internalname, StringUtil.RTrim( A1043ClienteTaxasTipoTarifa), 1, cmbClienteTaxasTipoTarifa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbClienteTaxasTipoTarifa.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_ClienteTaxas.htm");
         cmbClienteTaxasTipoTarifa.CurrentValue = StringUtil.RTrim( A1043ClienteTaxasTipoTarifa);
         AssignProp("", false, cmbClienteTaxasTipoTarifa_Internalname, "Values", (string)(cmbClienteTaxasTipoTarifa.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteTaxasTarifa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTaxasTarifa_Internalname, "Tarifa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTaxasTarifa_Internalname, ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa)&&IsIns( )||n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa)&&IsIns( )||n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( ((edtClienteTaxasTarifa_Enabled!=0) ? context.localUtil.Format( A1044ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A1044ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTaxasTarifa_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteTaxasTarifa_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteTaxas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteTaxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteTaxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteTaxas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTaxasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1008ClienteTaxasId), 9, 0, ",", "")), StringUtil.LTrim( ((edtClienteTaxasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTaxasId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteTaxasId_Visible, edtClienteTaxasId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteTaxas.htm");
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
         E11342 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1008ClienteTaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1008ClienteTaxasId"), ",", "."), 18, MidpointRounding.ToEven));
               Z1045ClienteTaxasCreatedAt = context.localUtil.CToT( cgiGet( "Z1045ClienteTaxasCreatedAt"), 0);
               n1045ClienteTaxasCreatedAt = ((DateTime.MinValue==A1045ClienteTaxasCreatedAt) ? true : false);
               Z1046ClienteTaxasUpdatedAt = context.localUtil.CToT( cgiGet( "Z1046ClienteTaxasUpdatedAt"), 0);
               n1046ClienteTaxasUpdatedAt = ((DateTime.MinValue==A1046ClienteTaxasUpdatedAt) ? true : false);
               Z1009ClienteTaxasTipo = cgiGet( "Z1009ClienteTaxasTipo");
               n1009ClienteTaxasTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1009ClienteTaxasTipo)) ? true : false);
               Z1040ClienteTaxasEfetiva = context.localUtil.CToN( cgiGet( "Z1040ClienteTaxasEfetiva"), ",", ".");
               n1040ClienteTaxasEfetiva = ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva) ? true : false);
               Z1041ClienteTaxasMora = context.localUtil.CToN( cgiGet( "Z1041ClienteTaxasMora"), ",", ".");
               n1041ClienteTaxasMora = ((Convert.ToDecimal(0)==A1041ClienteTaxasMora) ? true : false);
               Z1042ClienteTaxasFator = context.localUtil.CToN( cgiGet( "Z1042ClienteTaxasFator"), ",", ".");
               n1042ClienteTaxasFator = ((Convert.ToDecimal(0)==A1042ClienteTaxasFator) ? true : false);
               Z1043ClienteTaxasTipoTarifa = cgiGet( "Z1043ClienteTaxasTipoTarifa");
               n1043ClienteTaxasTipoTarifa = (String.IsNullOrEmpty(StringUtil.RTrim( A1043ClienteTaxasTipoTarifa)) ? true : false);
               Z1044ClienteTaxasTarifa = context.localUtil.CToN( cgiGet( "Z1044ClienteTaxasTarifa"), ",", ".");
               n1044ClienteTaxasTarifa = ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa) ? true : false);
               A1045ClienteTaxasCreatedAt = context.localUtil.CToT( cgiGet( "Z1045ClienteTaxasCreatedAt"), 0);
               n1045ClienteTaxasCreatedAt = false;
               n1045ClienteTaxasCreatedAt = ((DateTime.MinValue==A1045ClienteTaxasCreatedAt) ? true : false);
               A1046ClienteTaxasUpdatedAt = context.localUtil.CToT( cgiGet( "Z1046ClienteTaxasUpdatedAt"), 0);
               n1046ClienteTaxasUpdatedAt = false;
               n1046ClienteTaxasUpdatedAt = ((DateTime.MinValue==A1046ClienteTaxasUpdatedAt) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ClienteTaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTETAXASID"), ",", "."), 18, MidpointRounding.ToEven));
               A1045ClienteTaxasCreatedAt = context.localUtil.CToT( cgiGet( "CLIENTETAXASCREATEDAT"), 0);
               n1045ClienteTaxasCreatedAt = ((DateTime.MinValue==A1045ClienteTaxasCreatedAt) ? true : false);
               A1046ClienteTaxasUpdatedAt = context.localUtil.CToT( cgiGet( "CLIENTETAXASUPDATEDAT"), 0);
               n1046ClienteTaxasUpdatedAt = ((DateTime.MinValue==A1046ClienteTaxasUpdatedAt) ? true : false);
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
               cmbClienteTaxasTipo.CurrentValue = cgiGet( cmbClienteTaxasTipo_Internalname);
               A1009ClienteTaxasTipo = cgiGet( cmbClienteTaxasTipo_Internalname);
               n1009ClienteTaxasTipo = false;
               AssignAttri("", false, "A1009ClienteTaxasTipo", A1009ClienteTaxasTipo);
               n1009ClienteTaxasTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1009ClienteTaxasTipo)) ? true : false);
               n1040ClienteTaxasEfetiva = ((StringUtil.StrCmp(cgiGet( edtClienteTaxasEfetiva_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasEfetiva_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasEfetiva_Internalname), ",", ".") > 99999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTETAXASEFETIVA");
                  AnyError = 1;
                  GX_FocusControl = edtClienteTaxasEfetiva_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1040ClienteTaxasEfetiva = 0;
                  n1040ClienteTaxasEfetiva = false;
                  AssignAttri("", false, "A1040ClienteTaxasEfetiva", (n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 16, 4, ".", ""))));
               }
               else
               {
                  A1040ClienteTaxasEfetiva = context.localUtil.CToN( cgiGet( edtClienteTaxasEfetiva_Internalname), ",", ".");
                  AssignAttri("", false, "A1040ClienteTaxasEfetiva", (n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 16, 4, ".", ""))));
               }
               n1041ClienteTaxasMora = ((StringUtil.StrCmp(cgiGet( edtClienteTaxasMora_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasMora_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasMora_Internalname), ",", ".") > 99999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTETAXASMORA");
                  AnyError = 1;
                  GX_FocusControl = edtClienteTaxasMora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1041ClienteTaxasMora = 0;
                  n1041ClienteTaxasMora = false;
                  AssignAttri("", false, "A1041ClienteTaxasMora", (n1041ClienteTaxasMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 16, 4, ".", ""))));
               }
               else
               {
                  A1041ClienteTaxasMora = context.localUtil.CToN( cgiGet( edtClienteTaxasMora_Internalname), ",", ".");
                  AssignAttri("", false, "A1041ClienteTaxasMora", (n1041ClienteTaxasMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 16, 4, ".", ""))));
               }
               n1042ClienteTaxasFator = ((StringUtil.StrCmp(cgiGet( edtClienteTaxasFator_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasFator_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasFator_Internalname), ",", ".") > 99999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTETAXASFATOR");
                  AnyError = 1;
                  GX_FocusControl = edtClienteTaxasFator_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1042ClienteTaxasFator = 0;
                  n1042ClienteTaxasFator = false;
                  AssignAttri("", false, "A1042ClienteTaxasFator", (n1042ClienteTaxasFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 16, 4, ".", ""))));
               }
               else
               {
                  A1042ClienteTaxasFator = context.localUtil.CToN( cgiGet( edtClienteTaxasFator_Internalname), ",", ".");
                  AssignAttri("", false, "A1042ClienteTaxasFator", (n1042ClienteTaxasFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 16, 4, ".", ""))));
               }
               cmbClienteTaxasTipoTarifa.CurrentValue = cgiGet( cmbClienteTaxasTipoTarifa_Internalname);
               A1043ClienteTaxasTipoTarifa = cgiGet( cmbClienteTaxasTipoTarifa_Internalname);
               n1043ClienteTaxasTipoTarifa = false;
               AssignAttri("", false, "A1043ClienteTaxasTipoTarifa", A1043ClienteTaxasTipoTarifa);
               n1043ClienteTaxasTipoTarifa = (String.IsNullOrEmpty(StringUtil.RTrim( A1043ClienteTaxasTipoTarifa)) ? true : false);
               n1044ClienteTaxasTarifa = ((StringUtil.StrCmp(cgiGet( edtClienteTaxasTarifa_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasTarifa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteTaxasTarifa_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTETAXASTARIFA");
                  AnyError = 1;
                  GX_FocusControl = edtClienteTaxasTarifa_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1044ClienteTaxasTarifa = 0;
                  n1044ClienteTaxasTarifa = false;
                  AssignAttri("", false, "A1044ClienteTaxasTarifa", (n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ".", ""))));
               }
               else
               {
                  A1044ClienteTaxasTarifa = context.localUtil.CToN( cgiGet( edtClienteTaxasTarifa_Internalname), ",", ".");
                  AssignAttri("", false, "A1044ClienteTaxasTarifa", (n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ".", ""))));
               }
               A1008ClienteTaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteTaxasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ClienteTaxas");
               A1008ClienteTaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteTaxasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
               forbiddenHiddens.Add("ClienteTaxasId", context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ClienteTaxasCreatedAt", context.localUtil.Format( A1045ClienteTaxasCreatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("ClienteTaxasUpdatedAt", context.localUtil.Format( A1046ClienteTaxasUpdatedAt, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1008ClienteTaxasId != Z1008ClienteTaxasId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("clientetaxas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1008ClienteTaxasId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteTaxasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
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
                     sMode108 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode108;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound108 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_340( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIENTETAXASID");
                        AnyError = 1;
                        GX_FocusControl = edtClienteTaxasId_Internalname;
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
                           E11342 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12342 ();
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
            E12342 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll34108( ) ;
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
            DisableAttributes34108( ) ;
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

      protected void CONFIRM_340( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls34108( ) ;
            }
            else
            {
               CheckExtendedTable34108( ) ;
               CloseExtendedTableCursors34108( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption340( )
      {
      }

      protected void E11342( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtClienteTaxasId_Visible = 0;
         AssignProp("", false, edtClienteTaxasId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteTaxasId_Visible), 5, 0), true);
      }

      protected void E12342( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("clientetaxasww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM34108( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1045ClienteTaxasCreatedAt = T00343_A1045ClienteTaxasCreatedAt[0];
               Z1046ClienteTaxasUpdatedAt = T00343_A1046ClienteTaxasUpdatedAt[0];
               Z1009ClienteTaxasTipo = T00343_A1009ClienteTaxasTipo[0];
               Z1040ClienteTaxasEfetiva = T00343_A1040ClienteTaxasEfetiva[0];
               Z1041ClienteTaxasMora = T00343_A1041ClienteTaxasMora[0];
               Z1042ClienteTaxasFator = T00343_A1042ClienteTaxasFator[0];
               Z1043ClienteTaxasTipoTarifa = T00343_A1043ClienteTaxasTipoTarifa[0];
               Z1044ClienteTaxasTarifa = T00343_A1044ClienteTaxasTarifa[0];
            }
            else
            {
               Z1045ClienteTaxasCreatedAt = A1045ClienteTaxasCreatedAt;
               Z1046ClienteTaxasUpdatedAt = A1046ClienteTaxasUpdatedAt;
               Z1009ClienteTaxasTipo = A1009ClienteTaxasTipo;
               Z1040ClienteTaxasEfetiva = A1040ClienteTaxasEfetiva;
               Z1041ClienteTaxasMora = A1041ClienteTaxasMora;
               Z1042ClienteTaxasFator = A1042ClienteTaxasFator;
               Z1043ClienteTaxasTipoTarifa = A1043ClienteTaxasTipoTarifa;
               Z1044ClienteTaxasTarifa = A1044ClienteTaxasTarifa;
            }
         }
         if ( GX_JID == -6 )
         {
            Z1008ClienteTaxasId = A1008ClienteTaxasId;
            Z1045ClienteTaxasCreatedAt = A1045ClienteTaxasCreatedAt;
            Z1046ClienteTaxasUpdatedAt = A1046ClienteTaxasUpdatedAt;
            Z1009ClienteTaxasTipo = A1009ClienteTaxasTipo;
            Z1040ClienteTaxasEfetiva = A1040ClienteTaxasEfetiva;
            Z1041ClienteTaxasMora = A1041ClienteTaxasMora;
            Z1042ClienteTaxasFator = A1042ClienteTaxasFator;
            Z1043ClienteTaxasTipoTarifa = A1043ClienteTaxasTipoTarifa;
            Z1044ClienteTaxasTarifa = A1044ClienteTaxasTarifa;
         }
      }

      protected void standaloneNotModal( )
      {
         edtClienteTaxasId_Enabled = 0;
         AssignProp("", false, edtClienteTaxasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasId_Enabled), 5, 0), true);
         edtClienteTaxasId_Enabled = 0;
         AssignProp("", false, edtClienteTaxasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ClienteTaxasId) )
         {
            A1008ClienteTaxasId = AV7ClienteTaxasId;
            AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1045ClienteTaxasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1045ClienteTaxasCreatedAt = false;
            AssignAttri("", false, "A1045ClienteTaxasCreatedAt", context.localUtil.TToC( A1045ClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A1046ClienteTaxasUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1046ClienteTaxasUpdatedAt = false;
            AssignAttri("", false, "A1046ClienteTaxasUpdatedAt", context.localUtil.TToC( A1046ClienteTaxasUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
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

      protected void Load34108( )
      {
         /* Using cursor T00344 */
         pr_default.execute(2, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound108 = 1;
            A1045ClienteTaxasCreatedAt = T00344_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = T00344_n1045ClienteTaxasCreatedAt[0];
            A1046ClienteTaxasUpdatedAt = T00344_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = T00344_n1046ClienteTaxasUpdatedAt[0];
            A1009ClienteTaxasTipo = T00344_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = T00344_n1009ClienteTaxasTipo[0];
            AssignAttri("", false, "A1009ClienteTaxasTipo", A1009ClienteTaxasTipo);
            A1040ClienteTaxasEfetiva = T00344_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = T00344_n1040ClienteTaxasEfetiva[0];
            AssignAttri("", false, "A1040ClienteTaxasEfetiva", ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva)&&IsIns( )||n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 16, 4, ".", ""))));
            A1041ClienteTaxasMora = T00344_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = T00344_n1041ClienteTaxasMora[0];
            AssignAttri("", false, "A1041ClienteTaxasMora", ((Convert.ToDecimal(0)==A1041ClienteTaxasMora)&&IsIns( )||n1041ClienteTaxasMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 16, 4, ".", ""))));
            A1042ClienteTaxasFator = T00344_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = T00344_n1042ClienteTaxasFator[0];
            AssignAttri("", false, "A1042ClienteTaxasFator", ((Convert.ToDecimal(0)==A1042ClienteTaxasFator)&&IsIns( )||n1042ClienteTaxasFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 16, 4, ".", ""))));
            A1043ClienteTaxasTipoTarifa = T00344_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = T00344_n1043ClienteTaxasTipoTarifa[0];
            AssignAttri("", false, "A1043ClienteTaxasTipoTarifa", A1043ClienteTaxasTipoTarifa);
            A1044ClienteTaxasTarifa = T00344_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = T00344_n1044ClienteTaxasTarifa[0];
            AssignAttri("", false, "A1044ClienteTaxasTarifa", ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa)&&IsIns( )||n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ".", ""))));
            ZM34108( -6) ;
         }
         pr_default.close(2);
         OnLoadActions34108( ) ;
      }

      protected void OnLoadActions34108( )
      {
      }

      protected void CheckExtendedTable34108( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00345 */
         pr_default.execute(3, new Object[] {n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, A1008ClienteTaxasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente Taxas Tipo"}), 1, "CLIENTETAXASTIPO");
            AnyError = 1;
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "SEM_RISCO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "BAIXO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "ALTO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "PREMIUM") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1009ClienteTaxasTipo)) ) )
         {
            GX_msglist.addItem("Campo Cliente Taxas Tipo fora do intervalo", "OutOfRange", 1, "CLIENTETAXASTIPO");
            AnyError = 1;
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors34108( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey34108( )
      {
         /* Using cursor T00346 */
         pr_default.execute(4, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound108 = 1;
         }
         else
         {
            RcdFound108 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00343 */
         pr_default.execute(1, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM34108( 6) ;
            RcdFound108 = 1;
            A1008ClienteTaxasId = T00343_A1008ClienteTaxasId[0];
            AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
            A1045ClienteTaxasCreatedAt = T00343_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = T00343_n1045ClienteTaxasCreatedAt[0];
            A1046ClienteTaxasUpdatedAt = T00343_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = T00343_n1046ClienteTaxasUpdatedAt[0];
            A1009ClienteTaxasTipo = T00343_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = T00343_n1009ClienteTaxasTipo[0];
            AssignAttri("", false, "A1009ClienteTaxasTipo", A1009ClienteTaxasTipo);
            A1040ClienteTaxasEfetiva = T00343_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = T00343_n1040ClienteTaxasEfetiva[0];
            AssignAttri("", false, "A1040ClienteTaxasEfetiva", ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva)&&IsIns( )||n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 16, 4, ".", ""))));
            A1041ClienteTaxasMora = T00343_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = T00343_n1041ClienteTaxasMora[0];
            AssignAttri("", false, "A1041ClienteTaxasMora", ((Convert.ToDecimal(0)==A1041ClienteTaxasMora)&&IsIns( )||n1041ClienteTaxasMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 16, 4, ".", ""))));
            A1042ClienteTaxasFator = T00343_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = T00343_n1042ClienteTaxasFator[0];
            AssignAttri("", false, "A1042ClienteTaxasFator", ((Convert.ToDecimal(0)==A1042ClienteTaxasFator)&&IsIns( )||n1042ClienteTaxasFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 16, 4, ".", ""))));
            A1043ClienteTaxasTipoTarifa = T00343_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = T00343_n1043ClienteTaxasTipoTarifa[0];
            AssignAttri("", false, "A1043ClienteTaxasTipoTarifa", A1043ClienteTaxasTipoTarifa);
            A1044ClienteTaxasTarifa = T00343_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = T00343_n1044ClienteTaxasTarifa[0];
            AssignAttri("", false, "A1044ClienteTaxasTarifa", ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa)&&IsIns( )||n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ".", ""))));
            Z1008ClienteTaxasId = A1008ClienteTaxasId;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load34108( ) ;
            if ( AnyError == 1 )
            {
               RcdFound108 = 0;
               InitializeNonKey34108( ) ;
            }
            Gx_mode = sMode108;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound108 = 0;
            InitializeNonKey34108( ) ;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode108;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey34108( ) ;
         if ( RcdFound108 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound108 = 0;
         /* Using cursor T00347 */
         pr_default.execute(5, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00347_A1008ClienteTaxasId[0] < A1008ClienteTaxasId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00347_A1008ClienteTaxasId[0] > A1008ClienteTaxasId ) ) )
            {
               A1008ClienteTaxasId = T00347_A1008ClienteTaxasId[0];
               AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
               RcdFound108 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound108 = 0;
         /* Using cursor T00348 */
         pr_default.execute(6, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00348_A1008ClienteTaxasId[0] > A1008ClienteTaxasId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00348_A1008ClienteTaxasId[0] < A1008ClienteTaxasId ) ) )
            {
               A1008ClienteTaxasId = T00348_A1008ClienteTaxasId[0];
               AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
               RcdFound108 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey34108( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert34108( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound108 == 1 )
            {
               if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
               {
                  A1008ClienteTaxasId = Z1008ClienteTaxasId;
                  AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTETAXASID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteTaxasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbClienteTaxasTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update34108( ) ;
                  GX_FocusControl = cmbClienteTaxasTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbClienteTaxasTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert34108( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTETAXASID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteTaxasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbClienteTaxasTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert34108( ) ;
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
         if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
         {
            A1008ClienteTaxasId = Z1008ClienteTaxasId;
            AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTETAXASID");
            AnyError = 1;
            GX_FocusControl = edtClienteTaxasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency34108( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00342 */
            pr_default.execute(0, new Object[] {A1008ClienteTaxasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteTaxas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1045ClienteTaxasCreatedAt != T00342_A1045ClienteTaxasCreatedAt[0] ) || ( Z1046ClienteTaxasUpdatedAt != T00342_A1046ClienteTaxasUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1009ClienteTaxasTipo, T00342_A1009ClienteTaxasTipo[0]) != 0 ) || ( Z1040ClienteTaxasEfetiva != T00342_A1040ClienteTaxasEfetiva[0] ) || ( Z1041ClienteTaxasMora != T00342_A1041ClienteTaxasMora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1042ClienteTaxasFator != T00342_A1042ClienteTaxasFator[0] ) || ( StringUtil.StrCmp(Z1043ClienteTaxasTipoTarifa, T00342_A1043ClienteTaxasTipoTarifa[0]) != 0 ) || ( Z1044ClienteTaxasTarifa != T00342_A1044ClienteTaxasTarifa[0] ) )
            {
               if ( Z1045ClienteTaxasCreatedAt != T00342_A1045ClienteTaxasCreatedAt[0] )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1045ClienteTaxasCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1045ClienteTaxasCreatedAt[0]);
               }
               if ( Z1046ClienteTaxasUpdatedAt != T00342_A1046ClienteTaxasUpdatedAt[0] )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1046ClienteTaxasUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1046ClienteTaxasUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z1009ClienteTaxasTipo, T00342_A1009ClienteTaxasTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1009ClienteTaxasTipo);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1009ClienteTaxasTipo[0]);
               }
               if ( Z1040ClienteTaxasEfetiva != T00342_A1040ClienteTaxasEfetiva[0] )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasEfetiva");
                  GXUtil.WriteLogRaw("Old: ",Z1040ClienteTaxasEfetiva);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1040ClienteTaxasEfetiva[0]);
               }
               if ( Z1041ClienteTaxasMora != T00342_A1041ClienteTaxasMora[0] )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasMora");
                  GXUtil.WriteLogRaw("Old: ",Z1041ClienteTaxasMora);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1041ClienteTaxasMora[0]);
               }
               if ( Z1042ClienteTaxasFator != T00342_A1042ClienteTaxasFator[0] )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasFator");
                  GXUtil.WriteLogRaw("Old: ",Z1042ClienteTaxasFator);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1042ClienteTaxasFator[0]);
               }
               if ( StringUtil.StrCmp(Z1043ClienteTaxasTipoTarifa, T00342_A1043ClienteTaxasTipoTarifa[0]) != 0 )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasTipoTarifa");
                  GXUtil.WriteLogRaw("Old: ",Z1043ClienteTaxasTipoTarifa);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1043ClienteTaxasTipoTarifa[0]);
               }
               if ( Z1044ClienteTaxasTarifa != T00342_A1044ClienteTaxasTarifa[0] )
               {
                  GXUtil.WriteLog("clientetaxas:[seudo value changed for attri]"+"ClienteTaxasTarifa");
                  GXUtil.WriteLogRaw("Old: ",Z1044ClienteTaxasTarifa);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1044ClienteTaxasTarifa[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteTaxas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert34108( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable34108( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM34108( 0) ;
            CheckOptimisticConcurrency34108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm34108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert34108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00349 */
                     pr_default.execute(7, new Object[] {n1045ClienteTaxasCreatedAt, A1045ClienteTaxasCreatedAt, n1046ClienteTaxasUpdatedAt, A1046ClienteTaxasUpdatedAt, n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, n1040ClienteTaxasEfetiva, A1040ClienteTaxasEfetiva, n1041ClienteTaxasMora, A1041ClienteTaxasMora, n1042ClienteTaxasFator, A1042ClienteTaxasFator, n1043ClienteTaxasTipoTarifa, A1043ClienteTaxasTipoTarifa, n1044ClienteTaxasTarifa, A1044ClienteTaxasTarifa});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003410 */
                     pr_default.execute(8);
                     A1008ClienteTaxasId = T003410_A1008ClienteTaxasId[0];
                     AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteTaxas");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption340( ) ;
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
               Load34108( ) ;
            }
            EndLevel34108( ) ;
         }
         CloseExtendedTableCursors34108( ) ;
      }

      protected void Update34108( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable34108( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency34108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm34108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate34108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003411 */
                     pr_default.execute(9, new Object[] {n1045ClienteTaxasCreatedAt, A1045ClienteTaxasCreatedAt, n1046ClienteTaxasUpdatedAt, A1046ClienteTaxasUpdatedAt, n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, n1040ClienteTaxasEfetiva, A1040ClienteTaxasEfetiva, n1041ClienteTaxasMora, A1041ClienteTaxasMora, n1042ClienteTaxasFator, A1042ClienteTaxasFator, n1043ClienteTaxasTipoTarifa, A1043ClienteTaxasTipoTarifa, n1044ClienteTaxasTarifa, A1044ClienteTaxasTarifa, A1008ClienteTaxasId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteTaxas");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteTaxas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate34108( ) ;
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
            EndLevel34108( ) ;
         }
         CloseExtendedTableCursors34108( ) ;
      }

      protected void DeferredUpdate34108( )
      {
      }

      protected void delete( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency34108( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls34108( ) ;
            AfterConfirm34108( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete34108( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003412 */
                  pr_default.execute(10, new Object[] {A1008ClienteTaxasId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("ClienteTaxas");
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
         sMode108 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel34108( ) ;
         Gx_mode = sMode108;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls34108( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel34108( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete34108( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("clientetaxas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues340( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("clientetaxas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart34108( )
      {
         /* Scan By routine */
         /* Using cursor T003413 */
         pr_default.execute(11);
         RcdFound108 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound108 = 1;
            A1008ClienteTaxasId = T003413_A1008ClienteTaxasId[0];
            AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext34108( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound108 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound108 = 1;
            A1008ClienteTaxasId = T003413_A1008ClienteTaxasId[0];
            AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
         }
      }

      protected void ScanEnd34108( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm34108( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert34108( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate34108( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete34108( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete34108( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate34108( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes34108( )
      {
         cmbClienteTaxasTipo.Enabled = 0;
         AssignProp("", false, cmbClienteTaxasTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClienteTaxasTipo.Enabled), 5, 0), true);
         edtClienteTaxasEfetiva_Enabled = 0;
         AssignProp("", false, edtClienteTaxasEfetiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasEfetiva_Enabled), 5, 0), true);
         edtClienteTaxasMora_Enabled = 0;
         AssignProp("", false, edtClienteTaxasMora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasMora_Enabled), 5, 0), true);
         edtClienteTaxasFator_Enabled = 0;
         AssignProp("", false, edtClienteTaxasFator_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasFator_Enabled), 5, 0), true);
         cmbClienteTaxasTipoTarifa.Enabled = 0;
         AssignProp("", false, cmbClienteTaxasTipoTarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClienteTaxasTipoTarifa.Enabled), 5, 0), true);
         edtClienteTaxasTarifa_Enabled = 0;
         AssignProp("", false, edtClienteTaxasTarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasTarifa_Enabled), 5, 0), true);
         edtClienteTaxasId_Enabled = 0;
         AssignProp("", false, edtClienteTaxasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTaxasId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes34108( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues340( )
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
         GXEncryptionTmp = "clientetaxas"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClienteTaxasId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("clientetaxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ClienteTaxas");
         forbiddenHiddens.Add("ClienteTaxasId", context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ClienteTaxasCreatedAt", context.localUtil.Format( A1045ClienteTaxasCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("ClienteTaxasUpdatedAt", context.localUtil.Format( A1046ClienteTaxasUpdatedAt, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clientetaxas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1008ClienteTaxasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1008ClienteTaxasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1045ClienteTaxasCreatedAt", context.localUtil.TToC( Z1045ClienteTaxasCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1046ClienteTaxasUpdatedAt", context.localUtil.TToC( Z1046ClienteTaxasUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1009ClienteTaxasTipo", Z1009ClienteTaxasTipo);
         GxWebStd.gx_hidden_field( context, "Z1040ClienteTaxasEfetiva", StringUtil.LTrim( StringUtil.NToC( Z1040ClienteTaxasEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1041ClienteTaxasMora", StringUtil.LTrim( StringUtil.NToC( Z1041ClienteTaxasMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1042ClienteTaxasFator", StringUtil.LTrim( StringUtil.NToC( Z1042ClienteTaxasFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1043ClienteTaxasTipoTarifa", Z1043ClienteTaxasTipoTarifa);
         GxWebStd.gx_hidden_field( context, "Z1044ClienteTaxasTarifa", StringUtil.LTrim( StringUtil.NToC( Z1044ClienteTaxasTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vCLIENTETAXASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteTaxasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETAXASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteTaxasId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTETAXASCREATEDAT", context.localUtil.TToC( A1045ClienteTaxasCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIENTETAXASUPDATEDAT", context.localUtil.TToC( A1046ClienteTaxasUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
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
         GXEncryptionTmp = "clientetaxas"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClienteTaxasId,9,0));
         return formatLink("clientetaxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ClienteTaxas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Taxas" ;
      }

      protected void InitializeNonKey34108( )
      {
         A1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         n1045ClienteTaxasCreatedAt = false;
         AssignAttri("", false, "A1045ClienteTaxasCreatedAt", context.localUtil.TToC( A1045ClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         n1046ClienteTaxasUpdatedAt = false;
         AssignAttri("", false, "A1046ClienteTaxasUpdatedAt", context.localUtil.TToC( A1046ClienteTaxasUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1009ClienteTaxasTipo = "";
         n1009ClienteTaxasTipo = false;
         AssignAttri("", false, "A1009ClienteTaxasTipo", A1009ClienteTaxasTipo);
         n1009ClienteTaxasTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1009ClienteTaxasTipo)) ? true : false);
         A1040ClienteTaxasEfetiva = 0;
         n1040ClienteTaxasEfetiva = false;
         AssignAttri("", false, "A1040ClienteTaxasEfetiva", ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva)&&IsIns( )||n1040ClienteTaxasEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 16, 4, ".", ""))));
         n1040ClienteTaxasEfetiva = ((Convert.ToDecimal(0)==A1040ClienteTaxasEfetiva) ? true : false);
         A1041ClienteTaxasMora = 0;
         n1041ClienteTaxasMora = false;
         AssignAttri("", false, "A1041ClienteTaxasMora", ((Convert.ToDecimal(0)==A1041ClienteTaxasMora)&&IsIns( )||n1041ClienteTaxasMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 16, 4, ".", ""))));
         n1041ClienteTaxasMora = ((Convert.ToDecimal(0)==A1041ClienteTaxasMora) ? true : false);
         A1042ClienteTaxasFator = 0;
         n1042ClienteTaxasFator = false;
         AssignAttri("", false, "A1042ClienteTaxasFator", ((Convert.ToDecimal(0)==A1042ClienteTaxasFator)&&IsIns( )||n1042ClienteTaxasFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 16, 4, ".", ""))));
         n1042ClienteTaxasFator = ((Convert.ToDecimal(0)==A1042ClienteTaxasFator) ? true : false);
         A1043ClienteTaxasTipoTarifa = "";
         n1043ClienteTaxasTipoTarifa = false;
         AssignAttri("", false, "A1043ClienteTaxasTipoTarifa", A1043ClienteTaxasTipoTarifa);
         n1043ClienteTaxasTipoTarifa = (String.IsNullOrEmpty(StringUtil.RTrim( A1043ClienteTaxasTipoTarifa)) ? true : false);
         A1044ClienteTaxasTarifa = 0;
         n1044ClienteTaxasTarifa = false;
         AssignAttri("", false, "A1044ClienteTaxasTarifa", ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa)&&IsIns( )||n1044ClienteTaxasTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ".", ""))));
         n1044ClienteTaxasTarifa = ((Convert.ToDecimal(0)==A1044ClienteTaxasTarifa) ? true : false);
         Z1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1009ClienteTaxasTipo = "";
         Z1040ClienteTaxasEfetiva = 0;
         Z1041ClienteTaxasMora = 0;
         Z1042ClienteTaxasFator = 0;
         Z1043ClienteTaxasTipoTarifa = "";
         Z1044ClienteTaxasTarifa = 0;
      }

      protected void InitAll34108( )
      {
         A1008ClienteTaxasId = 0;
         AssignAttri("", false, "A1008ClienteTaxasId", StringUtil.LTrimStr( (decimal)(A1008ClienteTaxasId), 9, 0));
         InitializeNonKey34108( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1045ClienteTaxasCreatedAt = i1045ClienteTaxasCreatedAt;
         n1045ClienteTaxasCreatedAt = false;
         AssignAttri("", false, "A1045ClienteTaxasCreatedAt", context.localUtil.TToC( A1045ClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019221030", true, true);
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
         context.AddJavascriptSource("clientetaxas.js", "?202561019221030", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbClienteTaxasTipo_Internalname = "CLIENTETAXASTIPO";
         edtClienteTaxasEfetiva_Internalname = "CLIENTETAXASEFETIVA";
         edtClienteTaxasMora_Internalname = "CLIENTETAXASMORA";
         edtClienteTaxasFator_Internalname = "CLIENTETAXASFATOR";
         cmbClienteTaxasTipoTarifa_Internalname = "CLIENTETAXASTIPOTARIFA";
         edtClienteTaxasTarifa_Internalname = "CLIENTETAXASTARIFA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtClienteTaxasId_Internalname = "CLIENTETAXASID";
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
         Form.Caption = "Taxas";
         edtClienteTaxasId_Jsonclick = "";
         edtClienteTaxasId_Enabled = 0;
         edtClienteTaxasId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtClienteTaxasTarifa_Jsonclick = "";
         edtClienteTaxasTarifa_Enabled = 1;
         cmbClienteTaxasTipoTarifa_Jsonclick = "";
         cmbClienteTaxasTipoTarifa.Enabled = 1;
         edtClienteTaxasFator_Jsonclick = "";
         edtClienteTaxasFator_Enabled = 1;
         edtClienteTaxasMora_Jsonclick = "";
         edtClienteTaxasMora_Enabled = 1;
         edtClienteTaxasEfetiva_Jsonclick = "";
         edtClienteTaxasEfetiva_Enabled = 1;
         cmbClienteTaxasTipo_Jsonclick = "";
         cmbClienteTaxasTipo.Enabled = 1;
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
         cmbClienteTaxasTipo.Name = "CLIENTETAXASTIPO";
         cmbClienteTaxasTipo.WebTags = "";
         cmbClienteTaxasTipo.addItem("SEM_RISCO", "Normal", 0);
         cmbClienteTaxasTipo.addItem("BAIXO", "Risco Baixo", 0);
         cmbClienteTaxasTipo.addItem("ALTO", "Risco Alto", 0);
         cmbClienteTaxasTipo.addItem("PREMIUM", "Cliente Premium", 0);
         if ( cmbClienteTaxasTipo.ItemCount > 0 )
         {
            A1009ClienteTaxasTipo = cmbClienteTaxasTipo.getValidValue(A1009ClienteTaxasTipo);
            n1009ClienteTaxasTipo = false;
            AssignAttri("", false, "A1009ClienteTaxasTipo", A1009ClienteTaxasTipo);
         }
         cmbClienteTaxasTipoTarifa.Name = "CLIENTETAXASTIPOTARIFA";
         cmbClienteTaxasTipoTarifa.WebTags = "";
         cmbClienteTaxasTipoTarifa.addItem("P", "Percentual", 0);
         cmbClienteTaxasTipoTarifa.addItem("V", "Valor", 0);
         if ( cmbClienteTaxasTipoTarifa.ItemCount > 0 )
         {
            A1043ClienteTaxasTipoTarifa = cmbClienteTaxasTipoTarifa.getValidValue(A1043ClienteTaxasTipoTarifa);
            n1043ClienteTaxasTipoTarifa = false;
            AssignAttri("", false, "A1043ClienteTaxasTipoTarifa", A1043ClienteTaxasTipoTarifa);
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

      public void Valid_Clientetaxastipo( )
      {
         n1009ClienteTaxasTipo = false;
         A1009ClienteTaxasTipo = cmbClienteTaxasTipo.CurrentValue;
         n1009ClienteTaxasTipo = false;
         /* Using cursor T003414 */
         pr_default.execute(12, new Object[] {n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, A1008ClienteTaxasId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente Taxas Tipo"}), 1, "CLIENTETAXASTIPO");
            AnyError = 1;
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
         }
         pr_default.close(12);
         if ( ! ( ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "SEM_RISCO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "BAIXO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "ALTO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "PREMIUM") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1009ClienteTaxasTipo)) ) )
         {
            GX_msglist.addItem("Campo Cliente Taxas Tipo fora do intervalo", "OutOfRange", 1, "CLIENTETAXASTIPO");
            AnyError = 1;
            GX_FocusControl = cmbClienteTaxasTipo_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ClienteTaxasId","fld":"vCLIENTETAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ClienteTaxasId","fld":"vCLIENTETAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1008ClienteTaxasId","fld":"CLIENTETAXASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A1045ClienteTaxasCreatedAt","fld":"CLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A1046ClienteTaxasUpdatedAt","fld":"CLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12342","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_CLIENTETAXASTIPO","""{"handler":"Valid_Clientetaxastipo","iparms":[{"av":"cmbClienteTaxasTipo"},{"av":"A1009ClienteTaxasTipo","fld":"CLIENTETAXASTIPO","type":"svchar"},{"av":"A1008ClienteTaxasId","fld":"CLIENTETAXASID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_CLIENTETAXASID","""{"handler":"Valid_Clientetaxasid","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1009ClienteTaxasTipo = "";
         Z1043ClienteTaxasTipoTarifa = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1009ClienteTaxasTipo = "";
         A1043ClienteTaxasTipoTarifa = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode108 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00344_A1008ClienteTaxasId = new int[1] ;
         T00344_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00344_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         T00344_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00344_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         T00344_A1009ClienteTaxasTipo = new string[] {""} ;
         T00344_n1009ClienteTaxasTipo = new bool[] {false} ;
         T00344_A1040ClienteTaxasEfetiva = new decimal[1] ;
         T00344_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         T00344_A1041ClienteTaxasMora = new decimal[1] ;
         T00344_n1041ClienteTaxasMora = new bool[] {false} ;
         T00344_A1042ClienteTaxasFator = new decimal[1] ;
         T00344_n1042ClienteTaxasFator = new bool[] {false} ;
         T00344_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         T00344_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         T00344_A1044ClienteTaxasTarifa = new decimal[1] ;
         T00344_n1044ClienteTaxasTarifa = new bool[] {false} ;
         T00345_A1009ClienteTaxasTipo = new string[] {""} ;
         T00345_n1009ClienteTaxasTipo = new bool[] {false} ;
         T00346_A1008ClienteTaxasId = new int[1] ;
         T00343_A1008ClienteTaxasId = new int[1] ;
         T00343_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00343_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         T00343_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00343_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         T00343_A1009ClienteTaxasTipo = new string[] {""} ;
         T00343_n1009ClienteTaxasTipo = new bool[] {false} ;
         T00343_A1040ClienteTaxasEfetiva = new decimal[1] ;
         T00343_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         T00343_A1041ClienteTaxasMora = new decimal[1] ;
         T00343_n1041ClienteTaxasMora = new bool[] {false} ;
         T00343_A1042ClienteTaxasFator = new decimal[1] ;
         T00343_n1042ClienteTaxasFator = new bool[] {false} ;
         T00343_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         T00343_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         T00343_A1044ClienteTaxasTarifa = new decimal[1] ;
         T00343_n1044ClienteTaxasTarifa = new bool[] {false} ;
         T00347_A1008ClienteTaxasId = new int[1] ;
         T00348_A1008ClienteTaxasId = new int[1] ;
         T00342_A1008ClienteTaxasId = new int[1] ;
         T00342_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00342_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         T00342_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00342_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         T00342_A1009ClienteTaxasTipo = new string[] {""} ;
         T00342_n1009ClienteTaxasTipo = new bool[] {false} ;
         T00342_A1040ClienteTaxasEfetiva = new decimal[1] ;
         T00342_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         T00342_A1041ClienteTaxasMora = new decimal[1] ;
         T00342_n1041ClienteTaxasMora = new bool[] {false} ;
         T00342_A1042ClienteTaxasFator = new decimal[1] ;
         T00342_n1042ClienteTaxasFator = new bool[] {false} ;
         T00342_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         T00342_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         T00342_A1044ClienteTaxasTarifa = new decimal[1] ;
         T00342_n1044ClienteTaxasTarifa = new bool[] {false} ;
         T003410_A1008ClienteTaxasId = new int[1] ;
         T003413_A1008ClienteTaxasId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         T003414_A1009ClienteTaxasTipo = new string[] {""} ;
         T003414_n1009ClienteTaxasTipo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientetaxas__default(),
            new Object[][] {
                new Object[] {
               T00342_A1008ClienteTaxasId, T00342_A1045ClienteTaxasCreatedAt, T00342_n1045ClienteTaxasCreatedAt, T00342_A1046ClienteTaxasUpdatedAt, T00342_n1046ClienteTaxasUpdatedAt, T00342_A1009ClienteTaxasTipo, T00342_n1009ClienteTaxasTipo, T00342_A1040ClienteTaxasEfetiva, T00342_n1040ClienteTaxasEfetiva, T00342_A1041ClienteTaxasMora,
               T00342_n1041ClienteTaxasMora, T00342_A1042ClienteTaxasFator, T00342_n1042ClienteTaxasFator, T00342_A1043ClienteTaxasTipoTarifa, T00342_n1043ClienteTaxasTipoTarifa, T00342_A1044ClienteTaxasTarifa, T00342_n1044ClienteTaxasTarifa
               }
               , new Object[] {
               T00343_A1008ClienteTaxasId, T00343_A1045ClienteTaxasCreatedAt, T00343_n1045ClienteTaxasCreatedAt, T00343_A1046ClienteTaxasUpdatedAt, T00343_n1046ClienteTaxasUpdatedAt, T00343_A1009ClienteTaxasTipo, T00343_n1009ClienteTaxasTipo, T00343_A1040ClienteTaxasEfetiva, T00343_n1040ClienteTaxasEfetiva, T00343_A1041ClienteTaxasMora,
               T00343_n1041ClienteTaxasMora, T00343_A1042ClienteTaxasFator, T00343_n1042ClienteTaxasFator, T00343_A1043ClienteTaxasTipoTarifa, T00343_n1043ClienteTaxasTipoTarifa, T00343_A1044ClienteTaxasTarifa, T00343_n1044ClienteTaxasTarifa
               }
               , new Object[] {
               T00344_A1008ClienteTaxasId, T00344_A1045ClienteTaxasCreatedAt, T00344_n1045ClienteTaxasCreatedAt, T00344_A1046ClienteTaxasUpdatedAt, T00344_n1046ClienteTaxasUpdatedAt, T00344_A1009ClienteTaxasTipo, T00344_n1009ClienteTaxasTipo, T00344_A1040ClienteTaxasEfetiva, T00344_n1040ClienteTaxasEfetiva, T00344_A1041ClienteTaxasMora,
               T00344_n1041ClienteTaxasMora, T00344_A1042ClienteTaxasFator, T00344_n1042ClienteTaxasFator, T00344_A1043ClienteTaxasTipoTarifa, T00344_n1043ClienteTaxasTipoTarifa, T00344_A1044ClienteTaxasTarifa, T00344_n1044ClienteTaxasTarifa
               }
               , new Object[] {
               T00345_A1009ClienteTaxasTipo, T00345_n1009ClienteTaxasTipo
               }
               , new Object[] {
               T00346_A1008ClienteTaxasId
               }
               , new Object[] {
               T00347_A1008ClienteTaxasId
               }
               , new Object[] {
               T00348_A1008ClienteTaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               T003410_A1008ClienteTaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003413_A1008ClienteTaxasId
               }
               , new Object[] {
               T003414_A1009ClienteTaxasTipo, T003414_n1009ClienteTaxasTipo
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound108 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ClienteTaxasId ;
      private int Z1008ClienteTaxasId ;
      private int AV7ClienteTaxasId ;
      private int trnEnded ;
      private int edtClienteTaxasEfetiva_Enabled ;
      private int edtClienteTaxasMora_Enabled ;
      private int edtClienteTaxasFator_Enabled ;
      private int edtClienteTaxasTarifa_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A1008ClienteTaxasId ;
      private int edtClienteTaxasId_Enabled ;
      private int edtClienteTaxasId_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private decimal Z1040ClienteTaxasEfetiva ;
      private decimal Z1041ClienteTaxasMora ;
      private decimal Z1042ClienteTaxasFator ;
      private decimal Z1044ClienteTaxasTarifa ;
      private decimal A1040ClienteTaxasEfetiva ;
      private decimal A1041ClienteTaxasMora ;
      private decimal A1042ClienteTaxasFator ;
      private decimal A1044ClienteTaxasTarifa ;
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
      private string cmbClienteTaxasTipo_Internalname ;
      private string cmbClienteTaxasTipoTarifa_Internalname ;
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
      private string cmbClienteTaxasTipo_Jsonclick ;
      private string edtClienteTaxasEfetiva_Internalname ;
      private string edtClienteTaxasEfetiva_Jsonclick ;
      private string edtClienteTaxasMora_Internalname ;
      private string edtClienteTaxasMora_Jsonclick ;
      private string edtClienteTaxasFator_Internalname ;
      private string edtClienteTaxasFator_Jsonclick ;
      private string cmbClienteTaxasTipoTarifa_Jsonclick ;
      private string edtClienteTaxasTarifa_Internalname ;
      private string edtClienteTaxasTarifa_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtClienteTaxasId_Internalname ;
      private string edtClienteTaxasId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode108 ;
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
      private DateTime Z1045ClienteTaxasCreatedAt ;
      private DateTime Z1046ClienteTaxasUpdatedAt ;
      private DateTime A1045ClienteTaxasCreatedAt ;
      private DateTime A1046ClienteTaxasUpdatedAt ;
      private DateTime i1045ClienteTaxasCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1009ClienteTaxasTipo ;
      private bool n1043ClienteTaxasTipoTarifa ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n1040ClienteTaxasEfetiva ;
      private bool n1041ClienteTaxasMora ;
      private bool n1042ClienteTaxasFator ;
      private bool n1044ClienteTaxasTarifa ;
      private bool n1045ClienteTaxasCreatedAt ;
      private bool n1046ClienteTaxasUpdatedAt ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z1009ClienteTaxasTipo ;
      private string Z1043ClienteTaxasTipoTarifa ;
      private string A1009ClienteTaxasTipo ;
      private string A1043ClienteTaxasTipoTarifa ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbClienteTaxasTipo ;
      private GXCombobox cmbClienteTaxasTipoTarifa ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T00344_A1008ClienteTaxasId ;
      private DateTime[] T00344_A1045ClienteTaxasCreatedAt ;
      private bool[] T00344_n1045ClienteTaxasCreatedAt ;
      private DateTime[] T00344_A1046ClienteTaxasUpdatedAt ;
      private bool[] T00344_n1046ClienteTaxasUpdatedAt ;
      private string[] T00344_A1009ClienteTaxasTipo ;
      private bool[] T00344_n1009ClienteTaxasTipo ;
      private decimal[] T00344_A1040ClienteTaxasEfetiva ;
      private bool[] T00344_n1040ClienteTaxasEfetiva ;
      private decimal[] T00344_A1041ClienteTaxasMora ;
      private bool[] T00344_n1041ClienteTaxasMora ;
      private decimal[] T00344_A1042ClienteTaxasFator ;
      private bool[] T00344_n1042ClienteTaxasFator ;
      private string[] T00344_A1043ClienteTaxasTipoTarifa ;
      private bool[] T00344_n1043ClienteTaxasTipoTarifa ;
      private decimal[] T00344_A1044ClienteTaxasTarifa ;
      private bool[] T00344_n1044ClienteTaxasTarifa ;
      private string[] T00345_A1009ClienteTaxasTipo ;
      private bool[] T00345_n1009ClienteTaxasTipo ;
      private int[] T00346_A1008ClienteTaxasId ;
      private int[] T00343_A1008ClienteTaxasId ;
      private DateTime[] T00343_A1045ClienteTaxasCreatedAt ;
      private bool[] T00343_n1045ClienteTaxasCreatedAt ;
      private DateTime[] T00343_A1046ClienteTaxasUpdatedAt ;
      private bool[] T00343_n1046ClienteTaxasUpdatedAt ;
      private string[] T00343_A1009ClienteTaxasTipo ;
      private bool[] T00343_n1009ClienteTaxasTipo ;
      private decimal[] T00343_A1040ClienteTaxasEfetiva ;
      private bool[] T00343_n1040ClienteTaxasEfetiva ;
      private decimal[] T00343_A1041ClienteTaxasMora ;
      private bool[] T00343_n1041ClienteTaxasMora ;
      private decimal[] T00343_A1042ClienteTaxasFator ;
      private bool[] T00343_n1042ClienteTaxasFator ;
      private string[] T00343_A1043ClienteTaxasTipoTarifa ;
      private bool[] T00343_n1043ClienteTaxasTipoTarifa ;
      private decimal[] T00343_A1044ClienteTaxasTarifa ;
      private bool[] T00343_n1044ClienteTaxasTarifa ;
      private int[] T00347_A1008ClienteTaxasId ;
      private int[] T00348_A1008ClienteTaxasId ;
      private int[] T00342_A1008ClienteTaxasId ;
      private DateTime[] T00342_A1045ClienteTaxasCreatedAt ;
      private bool[] T00342_n1045ClienteTaxasCreatedAt ;
      private DateTime[] T00342_A1046ClienteTaxasUpdatedAt ;
      private bool[] T00342_n1046ClienteTaxasUpdatedAt ;
      private string[] T00342_A1009ClienteTaxasTipo ;
      private bool[] T00342_n1009ClienteTaxasTipo ;
      private decimal[] T00342_A1040ClienteTaxasEfetiva ;
      private bool[] T00342_n1040ClienteTaxasEfetiva ;
      private decimal[] T00342_A1041ClienteTaxasMora ;
      private bool[] T00342_n1041ClienteTaxasMora ;
      private decimal[] T00342_A1042ClienteTaxasFator ;
      private bool[] T00342_n1042ClienteTaxasFator ;
      private string[] T00342_A1043ClienteTaxasTipoTarifa ;
      private bool[] T00342_n1043ClienteTaxasTipoTarifa ;
      private decimal[] T00342_A1044ClienteTaxasTarifa ;
      private bool[] T00342_n1044ClienteTaxasTarifa ;
      private int[] T003410_A1008ClienteTaxasId ;
      private int[] T003413_A1008ClienteTaxasId ;
      private string[] T003414_A1009ClienteTaxasTipo ;
      private bool[] T003414_n1009ClienteTaxasTipo ;
   }

   public class clientetaxas__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00342;
          prmT00342 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00343;
          prmT00343 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00344;
          prmT00344 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00345;
          prmT00345 = new Object[] {
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00346;
          prmT00346 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00347;
          prmT00347 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00348;
          prmT00348 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT00349;
          prmT00349 = new Object[] {
          new ParDef("ClienteTaxasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasTarifa",GXType.Number,15,2){Nullable=true}
          };
          Object[] prmT003410;
          prmT003410 = new Object[] {
          };
          Object[] prmT003411;
          prmT003411 = new Object[] {
          new ParDef("ClienteTaxasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT003412;
          prmT003412 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmT003413;
          prmT003413 = new Object[] {
          };
          Object[] prmT003414;
          prmT003414 = new Object[] {
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00342", "SELECT ClienteTaxasId, ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa FROM ClienteTaxas WHERE ClienteTaxasId = :ClienteTaxasId  FOR UPDATE OF ClienteTaxas NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00342,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00343", "SELECT ClienteTaxasId, ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa FROM ClienteTaxas WHERE ClienteTaxasId = :ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00343,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00344", "SELECT TM1.ClienteTaxasId, TM1.ClienteTaxasCreatedAt, TM1.ClienteTaxasUpdatedAt, TM1.ClienteTaxasTipo, TM1.ClienteTaxasEfetiva, TM1.ClienteTaxasMora, TM1.ClienteTaxasFator, TM1.ClienteTaxasTipoTarifa, TM1.ClienteTaxasTarifa FROM ClienteTaxas TM1 WHERE TM1.ClienteTaxasId = :ClienteTaxasId ORDER BY TM1.ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00344,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00345", "SELECT ClienteTaxasTipo FROM ClienteTaxas WHERE (ClienteTaxasTipo = :ClienteTaxasTipo) AND (Not ( ClienteTaxasId = :ClienteTaxasId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00345,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00346", "SELECT ClienteTaxasId FROM ClienteTaxas WHERE ClienteTaxasId = :ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00346,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00347", "SELECT ClienteTaxasId FROM ClienteTaxas WHERE ( ClienteTaxasId > :ClienteTaxasId) ORDER BY ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00347,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00348", "SELECT ClienteTaxasId FROM ClienteTaxas WHERE ( ClienteTaxasId < :ClienteTaxasId) ORDER BY ClienteTaxasId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00348,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00349", "SAVEPOINT gxupdate;INSERT INTO ClienteTaxas(ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa) VALUES(:ClienteTaxasCreatedAt, :ClienteTaxasUpdatedAt, :ClienteTaxasTipo, :ClienteTaxasEfetiva, :ClienteTaxasMora, :ClienteTaxasFator, :ClienteTaxasTipoTarifa, :ClienteTaxasTarifa);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00349)
             ,new CursorDef("T003410", "SELECT currval('ClienteTaxasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003411", "SAVEPOINT gxupdate;UPDATE ClienteTaxas SET ClienteTaxasCreatedAt=:ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt=:ClienteTaxasUpdatedAt, ClienteTaxasTipo=:ClienteTaxasTipo, ClienteTaxasEfetiva=:ClienteTaxasEfetiva, ClienteTaxasMora=:ClienteTaxasMora, ClienteTaxasFator=:ClienteTaxasFator, ClienteTaxasTipoTarifa=:ClienteTaxasTipoTarifa, ClienteTaxasTarifa=:ClienteTaxasTarifa  WHERE ClienteTaxasId = :ClienteTaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003411)
             ,new CursorDef("T003412", "SAVEPOINT gxupdate;DELETE FROM ClienteTaxas  WHERE ClienteTaxasId = :ClienteTaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003412)
             ,new CursorDef("T003413", "SELECT ClienteTaxasId FROM ClienteTaxas ORDER BY ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003413,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003414", "SELECT ClienteTaxasTipo FROM ClienteTaxas WHERE (ClienteTaxasTipo = :ClienteTaxasTipo) AND (Not ( ClienteTaxasId = :ClienteTaxasId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT003414,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
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
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
