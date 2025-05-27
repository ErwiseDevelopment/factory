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
   public class webservice : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         Form.Meta.addItem("description", "Web Service", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWebServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public webservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbWebServiceTipoDmWS = new GXCombobox();
         cmbWebServiceAuthTipo = new GXCombobox();
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
         if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
         {
            A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = false;
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
            AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Values", cmbWebServiceTipoDmWS.ToJavascriptSource(), true);
         }
         if ( cmbWebServiceAuthTipo.ItemCount > 0 )
         {
            A659WebServiceAuthTipo = cmbWebServiceAuthTipo.getValidValue(A659WebServiceAuthTipo);
            n659WebServiceAuthTipo = false;
            AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWebServiceAuthTipo.CurrentValue = StringUtil.RTrim( A659WebServiceAuthTipo);
            AssignProp("", false, cmbWebServiceAuthTipo_Internalname, "Values", cmbWebServiceAuthTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Web Service", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWebServiceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWebServiceId_Internalname, "Service Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWebServiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A656WebServiceId), 9, 0, ",", "")), StringUtil.LTrim( ((edtWebServiceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWebServiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWebServiceId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWebServiceTipoDmWS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWebServiceTipoDmWS_Internalname, "Dm WS", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWebServiceTipoDmWS, cmbWebServiceTipoDmWS_Internalname, StringUtil.RTrim( A657WebServiceTipoDmWS), 1, cmbWebServiceTipoDmWS_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbWebServiceTipoDmWS.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WebService.htm");
         cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
         AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Values", (string)(cmbWebServiceTipoDmWS.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWebServiceEndPoint_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWebServiceEndPoint_Internalname, "End Point", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWebServiceEndPoint_Internalname, A658WebServiceEndPoint, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWebServiceEndPoint_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWebServiceAuthTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWebServiceAuthTipo_Internalname, "Auth Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWebServiceAuthTipo, cmbWebServiceAuthTipo_Internalname, StringUtil.RTrim( A659WebServiceAuthTipo), 1, cmbWebServiceAuthTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbWebServiceAuthTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WebService.htm");
         cmbWebServiceAuthTipo.CurrentValue = StringUtil.RTrim( A659WebServiceAuthTipo);
         AssignProp("", false, cmbWebServiceAuthTipo_Internalname, "Values", (string)(cmbWebServiceAuthTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWebServiceUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWebServiceUsuario_Internalname, "Service Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWebServiceUsuario_Internalname, A660WebServiceUsuario, StringUtil.RTrim( context.localUtil.Format( A660WebServiceUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWebServiceUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWebServiceUsuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWebServiceSenha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWebServiceSenha_Internalname, "Service Senha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWebServiceSenha_Internalname, A661WebServiceSenha, StringUtil.RTrim( context.localUtil.Format( A661WebServiceSenha, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWebServiceSenha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWebServiceSenha_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WebService.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z656WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z656WebServiceId"), ",", "."), 18, MidpointRounding.ToEven));
            Z657WebServiceTipoDmWS = cgiGet( "Z657WebServiceTipoDmWS");
            n657WebServiceTipoDmWS = (String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ? true : false);
            Z658WebServiceEndPoint = cgiGet( "Z658WebServiceEndPoint");
            n658WebServiceEndPoint = (String.IsNullOrEmpty(StringUtil.RTrim( A658WebServiceEndPoint)) ? true : false);
            Z659WebServiceAuthTipo = cgiGet( "Z659WebServiceAuthTipo");
            n659WebServiceAuthTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A659WebServiceAuthTipo)) ? true : false);
            Z660WebServiceUsuario = cgiGet( "Z660WebServiceUsuario");
            n660WebServiceUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A660WebServiceUsuario)) ? true : false);
            Z661WebServiceSenha = cgiGet( "Z661WebServiceSenha");
            n661WebServiceSenha = (String.IsNullOrEmpty(StringUtil.RTrim( A661WebServiceSenha)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWebServiceId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWebServiceId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WEBSERVICEID");
               AnyError = 1;
               GX_FocusControl = edtWebServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A656WebServiceId = 0;
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
            }
            else
            {
               A656WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWebServiceId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
            }
            cmbWebServiceTipoDmWS.CurrentValue = cgiGet( cmbWebServiceTipoDmWS_Internalname);
            A657WebServiceTipoDmWS = cgiGet( cmbWebServiceTipoDmWS_Internalname);
            n657WebServiceTipoDmWS = false;
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = (String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ? true : false);
            A658WebServiceEndPoint = cgiGet( edtWebServiceEndPoint_Internalname);
            n658WebServiceEndPoint = false;
            AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
            n658WebServiceEndPoint = (String.IsNullOrEmpty(StringUtil.RTrim( A658WebServiceEndPoint)) ? true : false);
            cmbWebServiceAuthTipo.CurrentValue = cgiGet( cmbWebServiceAuthTipo_Internalname);
            A659WebServiceAuthTipo = cgiGet( cmbWebServiceAuthTipo_Internalname);
            n659WebServiceAuthTipo = false;
            AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
            n659WebServiceAuthTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A659WebServiceAuthTipo)) ? true : false);
            A660WebServiceUsuario = cgiGet( edtWebServiceUsuario_Internalname);
            n660WebServiceUsuario = false;
            AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
            n660WebServiceUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A660WebServiceUsuario)) ? true : false);
            A661WebServiceSenha = cgiGet( edtWebServiceSenha_Internalname);
            n661WebServiceSenha = false;
            AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
            n661WebServiceSenha = (String.IsNullOrEmpty(StringUtil.RTrim( A661WebServiceSenha)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A656WebServiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WebServiceId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2D83( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes2D83( ) ;
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

      protected void ResetCaption2D0( )
      {
      }

      protected void ZM2D83( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z657WebServiceTipoDmWS = T002D3_A657WebServiceTipoDmWS[0];
               Z658WebServiceEndPoint = T002D3_A658WebServiceEndPoint[0];
               Z659WebServiceAuthTipo = T002D3_A659WebServiceAuthTipo[0];
               Z660WebServiceUsuario = T002D3_A660WebServiceUsuario[0];
               Z661WebServiceSenha = T002D3_A661WebServiceSenha[0];
            }
            else
            {
               Z657WebServiceTipoDmWS = A657WebServiceTipoDmWS;
               Z658WebServiceEndPoint = A658WebServiceEndPoint;
               Z659WebServiceAuthTipo = A659WebServiceAuthTipo;
               Z660WebServiceUsuario = A660WebServiceUsuario;
               Z661WebServiceSenha = A661WebServiceSenha;
            }
         }
         if ( GX_JID == -3 )
         {
            Z656WebServiceId = A656WebServiceId;
            Z657WebServiceTipoDmWS = A657WebServiceTipoDmWS;
            Z658WebServiceEndPoint = A658WebServiceEndPoint;
            Z659WebServiceAuthTipo = A659WebServiceAuthTipo;
            Z660WebServiceUsuario = A660WebServiceUsuario;
            Z661WebServiceSenha = A661WebServiceSenha;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load2D83( )
      {
         /* Using cursor T002D4 */
         pr_default.execute(2, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound83 = 1;
            A657WebServiceTipoDmWS = T002D4_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = T002D4_n657WebServiceTipoDmWS[0];
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
            A658WebServiceEndPoint = T002D4_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = T002D4_n658WebServiceEndPoint[0];
            AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
            A659WebServiceAuthTipo = T002D4_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = T002D4_n659WebServiceAuthTipo[0];
            AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
            A660WebServiceUsuario = T002D4_A660WebServiceUsuario[0];
            n660WebServiceUsuario = T002D4_n660WebServiceUsuario[0];
            AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
            A661WebServiceSenha = T002D4_A661WebServiceSenha[0];
            n661WebServiceSenha = T002D4_n661WebServiceSenha[0];
            AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
            ZM2D83( -3) ;
         }
         pr_default.close(2);
         OnLoadActions2D83( ) ;
      }

      protected void OnLoadActions2D83( )
      {
      }

      protected void CheckExtendedTable2D83( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) || ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ) )
         {
            GX_msglist.addItem("Campo Web Service Tipo Dm WS fora do intervalo", "OutOfRange", 1, "WEBSERVICETIPODMWS");
            AnyError = 1;
            GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A659WebServiceAuthTipo, "Basic") == 0 ) || ( StringUtil.StrCmp(A659WebServiceAuthTipo, "Baerer") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A659WebServiceAuthTipo)) ) )
         {
            GX_msglist.addItem("Campo Web Service Auth Tipo fora do intervalo", "OutOfRange", 1, "WEBSERVICEAUTHTIPO");
            AnyError = 1;
            GX_FocusControl = cmbWebServiceAuthTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2D83( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2D83( )
      {
         /* Using cursor T002D5 */
         pr_default.execute(3, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002D3 */
         pr_default.execute(1, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2D83( 3) ;
            RcdFound83 = 1;
            A656WebServiceId = T002D3_A656WebServiceId[0];
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
            A657WebServiceTipoDmWS = T002D3_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = T002D3_n657WebServiceTipoDmWS[0];
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
            A658WebServiceEndPoint = T002D3_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = T002D3_n658WebServiceEndPoint[0];
            AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
            A659WebServiceAuthTipo = T002D3_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = T002D3_n659WebServiceAuthTipo[0];
            AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
            A660WebServiceUsuario = T002D3_A660WebServiceUsuario[0];
            n660WebServiceUsuario = T002D3_n660WebServiceUsuario[0];
            AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
            A661WebServiceSenha = T002D3_A661WebServiceSenha[0];
            n661WebServiceSenha = T002D3_n661WebServiceSenha[0];
            AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
            Z656WebServiceId = A656WebServiceId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2D83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey2D83( ) ;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey2D83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2D83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound83 = 0;
         /* Using cursor T002D6 */
         pr_default.execute(4, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002D6_A656WebServiceId[0] < A656WebServiceId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002D6_A656WebServiceId[0] > A656WebServiceId ) ) )
            {
               A656WebServiceId = T002D6_A656WebServiceId[0];
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound83 = 0;
         /* Using cursor T002D7 */
         pr_default.execute(5, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002D7_A656WebServiceId[0] > A656WebServiceId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002D7_A656WebServiceId[0] < A656WebServiceId ) ) )
            {
               A656WebServiceId = T002D7_A656WebServiceId[0];
               AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2D83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWebServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2D83( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( A656WebServiceId != Z656WebServiceId )
               {
                  A656WebServiceId = Z656WebServiceId;
                  AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WEBSERVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtWebServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWebServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2D83( ) ;
                  GX_FocusControl = edtWebServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A656WebServiceId != Z656WebServiceId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWebServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2D83( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WEBSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtWebServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWebServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2D83( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A656WebServiceId != Z656WebServiceId )
         {
            A656WebServiceId = Z656WebServiceId;
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WEBSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtWebServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWebServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WEBSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtWebServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2D83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2D83( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2D83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound83 != 0 )
            {
               ScanNext2D83( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2D83( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2D83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002D2 */
            pr_default.execute(0, new Object[] {A656WebServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WebService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z657WebServiceTipoDmWS, T002D2_A657WebServiceTipoDmWS[0]) != 0 ) || ( StringUtil.StrCmp(Z658WebServiceEndPoint, T002D2_A658WebServiceEndPoint[0]) != 0 ) || ( StringUtil.StrCmp(Z659WebServiceAuthTipo, T002D2_A659WebServiceAuthTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z660WebServiceUsuario, T002D2_A660WebServiceUsuario[0]) != 0 ) || ( StringUtil.StrCmp(Z661WebServiceSenha, T002D2_A661WebServiceSenha[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z657WebServiceTipoDmWS, T002D2_A657WebServiceTipoDmWS[0]) != 0 )
               {
                  GXUtil.WriteLog("webservice:[seudo value changed for attri]"+"WebServiceTipoDmWS");
                  GXUtil.WriteLogRaw("Old: ",Z657WebServiceTipoDmWS);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A657WebServiceTipoDmWS[0]);
               }
               if ( StringUtil.StrCmp(Z658WebServiceEndPoint, T002D2_A658WebServiceEndPoint[0]) != 0 )
               {
                  GXUtil.WriteLog("webservice:[seudo value changed for attri]"+"WebServiceEndPoint");
                  GXUtil.WriteLogRaw("Old: ",Z658WebServiceEndPoint);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A658WebServiceEndPoint[0]);
               }
               if ( StringUtil.StrCmp(Z659WebServiceAuthTipo, T002D2_A659WebServiceAuthTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("webservice:[seudo value changed for attri]"+"WebServiceAuthTipo");
                  GXUtil.WriteLogRaw("Old: ",Z659WebServiceAuthTipo);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A659WebServiceAuthTipo[0]);
               }
               if ( StringUtil.StrCmp(Z660WebServiceUsuario, T002D2_A660WebServiceUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("webservice:[seudo value changed for attri]"+"WebServiceUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z660WebServiceUsuario);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A660WebServiceUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z661WebServiceSenha, T002D2_A661WebServiceSenha[0]) != 0 )
               {
                  GXUtil.WriteLog("webservice:[seudo value changed for attri]"+"WebServiceSenha");
                  GXUtil.WriteLogRaw("Old: ",Z661WebServiceSenha);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A661WebServiceSenha[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WebService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2D83( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2D83( 0) ;
            CheckOptimisticConcurrency2D83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2D83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D8 */
                     pr_default.execute(6, new Object[] {n657WebServiceTipoDmWS, A657WebServiceTipoDmWS, n658WebServiceEndPoint, A658WebServiceEndPoint, n659WebServiceAuthTipo, A659WebServiceAuthTipo, n660WebServiceUsuario, A660WebServiceUsuario, n661WebServiceSenha, A661WebServiceSenha});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002D9 */
                     pr_default.execute(7);
                     A656WebServiceId = T002D9_A656WebServiceId[0];
                     AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WebService");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2D0( ) ;
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
               Load2D83( ) ;
            }
            EndLevel2D83( ) ;
         }
         CloseExtendedTableCursors2D83( ) ;
      }

      protected void Update2D83( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2D83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D10 */
                     pr_default.execute(8, new Object[] {n657WebServiceTipoDmWS, A657WebServiceTipoDmWS, n658WebServiceEndPoint, A658WebServiceEndPoint, n659WebServiceAuthTipo, A659WebServiceAuthTipo, n660WebServiceUsuario, A660WebServiceUsuario, n661WebServiceSenha, A661WebServiceSenha, A656WebServiceId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WebService");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WebService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2D83( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2D0( ) ;
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
            EndLevel2D83( ) ;
         }
         CloseExtendedTableCursors2D83( ) ;
      }

      protected void DeferredUpdate2D83( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2D83( ) ;
            AfterConfirm2D83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2D83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002D11 */
                  pr_default.execute(9, new Object[] {A656WebServiceId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WebService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound83 == 0 )
                        {
                           InitAll2D83( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption2D0( ) ;
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2D83( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2D83( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2D83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2D0( ) ;
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

      public void ScanStart2D83( )
      {
         /* Using cursor T002D12 */
         pr_default.execute(10);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound83 = 1;
            A656WebServiceId = T002D12_A656WebServiceId[0];
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2D83( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound83 = 1;
            A656WebServiceId = T002D12_A656WebServiceId[0];
            AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         }
      }

      protected void ScanEnd2D83( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2D83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2D83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2D83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2D83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2D83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2D83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2D83( )
      {
         edtWebServiceId_Enabled = 0;
         AssignProp("", false, edtWebServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceId_Enabled), 5, 0), true);
         cmbWebServiceTipoDmWS.Enabled = 0;
         AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWebServiceTipoDmWS.Enabled), 5, 0), true);
         edtWebServiceEndPoint_Enabled = 0;
         AssignProp("", false, edtWebServiceEndPoint_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceEndPoint_Enabled), 5, 0), true);
         cmbWebServiceAuthTipo.Enabled = 0;
         AssignProp("", false, cmbWebServiceAuthTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWebServiceAuthTipo.Enabled), 5, 0), true);
         edtWebServiceUsuario_Enabled = 0;
         AssignProp("", false, edtWebServiceUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceUsuario_Enabled), 5, 0), true);
         edtWebServiceSenha_Enabled = 0;
         AssignProp("", false, edtWebServiceSenha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWebServiceSenha_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2D83( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2D0( )
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webservice") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z656WebServiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z656WebServiceId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z657WebServiceTipoDmWS", Z657WebServiceTipoDmWS);
         GxWebStd.gx_hidden_field( context, "Z658WebServiceEndPoint", Z658WebServiceEndPoint);
         GxWebStd.gx_hidden_field( context, "Z659WebServiceAuthTipo", Z659WebServiceAuthTipo);
         GxWebStd.gx_hidden_field( context, "Z660WebServiceUsuario", Z660WebServiceUsuario);
         GxWebStd.gx_hidden_field( context, "Z661WebServiceSenha", Z661WebServiceSenha);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         return formatLink("webservice")  ;
      }

      public override string GetPgmname( )
      {
         return "WebService" ;
      }

      public override string GetPgmdesc( )
      {
         return "Web Service" ;
      }

      protected void InitializeNonKey2D83( )
      {
         A657WebServiceTipoDmWS = "";
         n657WebServiceTipoDmWS = false;
         AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         n657WebServiceTipoDmWS = (String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ? true : false);
         A658WebServiceEndPoint = "";
         n658WebServiceEndPoint = false;
         AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
         n658WebServiceEndPoint = (String.IsNullOrEmpty(StringUtil.RTrim( A658WebServiceEndPoint)) ? true : false);
         A659WebServiceAuthTipo = "";
         n659WebServiceAuthTipo = false;
         AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
         n659WebServiceAuthTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A659WebServiceAuthTipo)) ? true : false);
         A660WebServiceUsuario = "";
         n660WebServiceUsuario = false;
         AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
         n660WebServiceUsuario = (String.IsNullOrEmpty(StringUtil.RTrim( A660WebServiceUsuario)) ? true : false);
         A661WebServiceSenha = "";
         n661WebServiceSenha = false;
         AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
         n661WebServiceSenha = (String.IsNullOrEmpty(StringUtil.RTrim( A661WebServiceSenha)) ? true : false);
         Z657WebServiceTipoDmWS = "";
         Z658WebServiceEndPoint = "";
         Z659WebServiceAuthTipo = "";
         Z660WebServiceUsuario = "";
         Z661WebServiceSenha = "";
      }

      protected void InitAll2D83( )
      {
         A656WebServiceId = 0;
         AssignAttri("", false, "A656WebServiceId", StringUtil.LTrimStr( (decimal)(A656WebServiceId), 9, 0));
         InitializeNonKey2D83( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202551918495670", true, true);
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
         context.AddJavascriptSource("webservice.js", "?202551918495671", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtWebServiceId_Internalname = "WEBSERVICEID";
         cmbWebServiceTipoDmWS_Internalname = "WEBSERVICETIPODMWS";
         edtWebServiceEndPoint_Internalname = "WEBSERVICEENDPOINT";
         cmbWebServiceAuthTipo_Internalname = "WEBSERVICEAUTHTIPO";
         edtWebServiceUsuario_Internalname = "WEBSERVICEUSUARIO";
         edtWebServiceSenha_Internalname = "WEBSERVICESENHA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = "Web Service";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWebServiceSenha_Jsonclick = "";
         edtWebServiceSenha_Enabled = 1;
         edtWebServiceUsuario_Jsonclick = "";
         edtWebServiceUsuario_Enabled = 1;
         cmbWebServiceAuthTipo_Jsonclick = "";
         cmbWebServiceAuthTipo.Enabled = 1;
         edtWebServiceEndPoint_Enabled = 1;
         cmbWebServiceTipoDmWS_Jsonclick = "";
         cmbWebServiceTipoDmWS.Enabled = 1;
         edtWebServiceId_Jsonclick = "";
         edtWebServiceId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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
         cmbWebServiceTipoDmWS.Name = "WEBSERVICETIPODMWS";
         cmbWebServiceTipoDmWS.WebTags = "";
         cmbWebServiceTipoDmWS.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
         cmbWebServiceTipoDmWS.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
         if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
         {
            A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = false;
            AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         }
         cmbWebServiceAuthTipo.Name = "WEBSERVICEAUTHTIPO";
         cmbWebServiceAuthTipo.WebTags = "";
         cmbWebServiceAuthTipo.addItem("Basic", "Basic", 0);
         cmbWebServiceAuthTipo.addItem("Baerer", "Baerer", 0);
         if ( cmbWebServiceAuthTipo.ItemCount > 0 )
         {
            A659WebServiceAuthTipo = cmbWebServiceAuthTipo.getValidValue(A659WebServiceAuthTipo);
            n659WebServiceAuthTipo = false;
            AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = cmbWebServiceTipoDmWS_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Webserviceid( )
      {
         n659WebServiceAuthTipo = false;
         A659WebServiceAuthTipo = cmbWebServiceAuthTipo.CurrentValue;
         n659WebServiceAuthTipo = false;
         cmbWebServiceAuthTipo.CurrentValue = A659WebServiceAuthTipo;
         n657WebServiceTipoDmWS = false;
         A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.CurrentValue;
         n657WebServiceTipoDmWS = false;
         cmbWebServiceTipoDmWS.CurrentValue = A657WebServiceTipoDmWS;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
         {
            A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = false;
            cmbWebServiceTipoDmWS.CurrentValue = A657WebServiceTipoDmWS;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
         }
         if ( cmbWebServiceAuthTipo.ItemCount > 0 )
         {
            A659WebServiceAuthTipo = cmbWebServiceAuthTipo.getValidValue(A659WebServiceAuthTipo);
            n659WebServiceAuthTipo = false;
            cmbWebServiceAuthTipo.CurrentValue = A659WebServiceAuthTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWebServiceAuthTipo.CurrentValue = StringUtil.RTrim( A659WebServiceAuthTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A657WebServiceTipoDmWS", A657WebServiceTipoDmWS);
         cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
         AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Values", cmbWebServiceTipoDmWS.ToJavascriptSource(), true);
         AssignAttri("", false, "A658WebServiceEndPoint", A658WebServiceEndPoint);
         AssignAttri("", false, "A659WebServiceAuthTipo", A659WebServiceAuthTipo);
         cmbWebServiceAuthTipo.CurrentValue = StringUtil.RTrim( A659WebServiceAuthTipo);
         AssignProp("", false, cmbWebServiceAuthTipo_Internalname, "Values", cmbWebServiceAuthTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A660WebServiceUsuario", A660WebServiceUsuario);
         AssignAttri("", false, "A661WebServiceSenha", A661WebServiceSenha);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z656WebServiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z656WebServiceId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z657WebServiceTipoDmWS", Z657WebServiceTipoDmWS);
         GxWebStd.gx_hidden_field( context, "Z658WebServiceEndPoint", Z658WebServiceEndPoint);
         GxWebStd.gx_hidden_field( context, "Z659WebServiceAuthTipo", Z659WebServiceAuthTipo);
         GxWebStd.gx_hidden_field( context, "Z660WebServiceUsuario", Z660WebServiceUsuario);
         GxWebStd.gx_hidden_field( context, "Z661WebServiceSenha", Z661WebServiceSenha);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_WEBSERVICEID","""{"handler":"Valid_Webserviceid","iparms":[{"av":"cmbWebServiceAuthTipo"},{"av":"A659WebServiceAuthTipo","fld":"WEBSERVICEAUTHTIPO","type":"svchar"},{"av":"cmbWebServiceTipoDmWS"},{"av":"A657WebServiceTipoDmWS","fld":"WEBSERVICETIPODMWS","type":"svchar"},{"av":"A656WebServiceId","fld":"WEBSERVICEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_WEBSERVICEID",""","oparms":[{"av":"cmbWebServiceTipoDmWS"},{"av":"A657WebServiceTipoDmWS","fld":"WEBSERVICETIPODMWS","type":"svchar"},{"av":"A658WebServiceEndPoint","fld":"WEBSERVICEENDPOINT","type":"svchar"},{"av":"cmbWebServiceAuthTipo"},{"av":"A659WebServiceAuthTipo","fld":"WEBSERVICEAUTHTIPO","type":"svchar"},{"av":"A660WebServiceUsuario","fld":"WEBSERVICEUSUARIO","type":"svchar"},{"av":"A661WebServiceSenha","fld":"WEBSERVICESENHA","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z656WebServiceId","type":"int"},{"av":"Z657WebServiceTipoDmWS","type":"svchar"},{"av":"Z658WebServiceEndPoint","type":"svchar"},{"av":"Z659WebServiceAuthTipo","type":"svchar"},{"av":"Z660WebServiceUsuario","type":"svchar"},{"av":"Z661WebServiceSenha","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_WEBSERVICETIPODMWS","""{"handler":"Valid_Webservicetipodmws","iparms":[]}""");
         setEventMetadata("VALID_WEBSERVICEAUTHTIPO","""{"handler":"Valid_Webserviceauthtipo","iparms":[]}""");
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
         Z657WebServiceTipoDmWS = "";
         Z658WebServiceEndPoint = "";
         Z659WebServiceAuthTipo = "";
         Z660WebServiceUsuario = "";
         Z661WebServiceSenha = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A657WebServiceTipoDmWS = "";
         A659WebServiceAuthTipo = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A658WebServiceEndPoint = "";
         A660WebServiceUsuario = "";
         A661WebServiceSenha = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T002D4_A656WebServiceId = new int[1] ;
         T002D4_A657WebServiceTipoDmWS = new string[] {""} ;
         T002D4_n657WebServiceTipoDmWS = new bool[] {false} ;
         T002D4_A658WebServiceEndPoint = new string[] {""} ;
         T002D4_n658WebServiceEndPoint = new bool[] {false} ;
         T002D4_A659WebServiceAuthTipo = new string[] {""} ;
         T002D4_n659WebServiceAuthTipo = new bool[] {false} ;
         T002D4_A660WebServiceUsuario = new string[] {""} ;
         T002D4_n660WebServiceUsuario = new bool[] {false} ;
         T002D4_A661WebServiceSenha = new string[] {""} ;
         T002D4_n661WebServiceSenha = new bool[] {false} ;
         T002D5_A656WebServiceId = new int[1] ;
         T002D3_A656WebServiceId = new int[1] ;
         T002D3_A657WebServiceTipoDmWS = new string[] {""} ;
         T002D3_n657WebServiceTipoDmWS = new bool[] {false} ;
         T002D3_A658WebServiceEndPoint = new string[] {""} ;
         T002D3_n658WebServiceEndPoint = new bool[] {false} ;
         T002D3_A659WebServiceAuthTipo = new string[] {""} ;
         T002D3_n659WebServiceAuthTipo = new bool[] {false} ;
         T002D3_A660WebServiceUsuario = new string[] {""} ;
         T002D3_n660WebServiceUsuario = new bool[] {false} ;
         T002D3_A661WebServiceSenha = new string[] {""} ;
         T002D3_n661WebServiceSenha = new bool[] {false} ;
         sMode83 = "";
         T002D6_A656WebServiceId = new int[1] ;
         T002D7_A656WebServiceId = new int[1] ;
         T002D2_A656WebServiceId = new int[1] ;
         T002D2_A657WebServiceTipoDmWS = new string[] {""} ;
         T002D2_n657WebServiceTipoDmWS = new bool[] {false} ;
         T002D2_A658WebServiceEndPoint = new string[] {""} ;
         T002D2_n658WebServiceEndPoint = new bool[] {false} ;
         T002D2_A659WebServiceAuthTipo = new string[] {""} ;
         T002D2_n659WebServiceAuthTipo = new bool[] {false} ;
         T002D2_A660WebServiceUsuario = new string[] {""} ;
         T002D2_n660WebServiceUsuario = new bool[] {false} ;
         T002D2_A661WebServiceSenha = new string[] {""} ;
         T002D2_n661WebServiceSenha = new bool[] {false} ;
         T002D9_A656WebServiceId = new int[1] ;
         T002D12_A656WebServiceId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ657WebServiceTipoDmWS = "";
         ZZ658WebServiceEndPoint = "";
         ZZ659WebServiceAuthTipo = "";
         ZZ660WebServiceUsuario = "";
         ZZ661WebServiceSenha = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webservice__default(),
            new Object[][] {
                new Object[] {
               T002D2_A656WebServiceId, T002D2_A657WebServiceTipoDmWS, T002D2_n657WebServiceTipoDmWS, T002D2_A658WebServiceEndPoint, T002D2_n658WebServiceEndPoint, T002D2_A659WebServiceAuthTipo, T002D2_n659WebServiceAuthTipo, T002D2_A660WebServiceUsuario, T002D2_n660WebServiceUsuario, T002D2_A661WebServiceSenha,
               T002D2_n661WebServiceSenha
               }
               , new Object[] {
               T002D3_A656WebServiceId, T002D3_A657WebServiceTipoDmWS, T002D3_n657WebServiceTipoDmWS, T002D3_A658WebServiceEndPoint, T002D3_n658WebServiceEndPoint, T002D3_A659WebServiceAuthTipo, T002D3_n659WebServiceAuthTipo, T002D3_A660WebServiceUsuario, T002D3_n660WebServiceUsuario, T002D3_A661WebServiceSenha,
               T002D3_n661WebServiceSenha
               }
               , new Object[] {
               T002D4_A656WebServiceId, T002D4_A657WebServiceTipoDmWS, T002D4_n657WebServiceTipoDmWS, T002D4_A658WebServiceEndPoint, T002D4_n658WebServiceEndPoint, T002D4_A659WebServiceAuthTipo, T002D4_n659WebServiceAuthTipo, T002D4_A660WebServiceUsuario, T002D4_n660WebServiceUsuario, T002D4_A661WebServiceSenha,
               T002D4_n661WebServiceSenha
               }
               , new Object[] {
               T002D5_A656WebServiceId
               }
               , new Object[] {
               T002D6_A656WebServiceId
               }
               , new Object[] {
               T002D7_A656WebServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               T002D9_A656WebServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002D12_A656WebServiceId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound83 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z656WebServiceId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A656WebServiceId ;
      private int edtWebServiceId_Enabled ;
      private int edtWebServiceEndPoint_Enabled ;
      private int edtWebServiceUsuario_Enabled ;
      private int edtWebServiceSenha_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ656WebServiceId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWebServiceId_Internalname ;
      private string cmbWebServiceTipoDmWS_Internalname ;
      private string cmbWebServiceAuthTipo_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtWebServiceId_Jsonclick ;
      private string cmbWebServiceTipoDmWS_Jsonclick ;
      private string edtWebServiceEndPoint_Internalname ;
      private string cmbWebServiceAuthTipo_Jsonclick ;
      private string edtWebServiceUsuario_Internalname ;
      private string edtWebServiceUsuario_Jsonclick ;
      private string edtWebServiceSenha_Internalname ;
      private string edtWebServiceSenha_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode83 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n657WebServiceTipoDmWS ;
      private bool n659WebServiceAuthTipo ;
      private bool n658WebServiceEndPoint ;
      private bool n660WebServiceUsuario ;
      private bool n661WebServiceSenha ;
      private string Z657WebServiceTipoDmWS ;
      private string Z658WebServiceEndPoint ;
      private string Z659WebServiceAuthTipo ;
      private string Z660WebServiceUsuario ;
      private string Z661WebServiceSenha ;
      private string A657WebServiceTipoDmWS ;
      private string A659WebServiceAuthTipo ;
      private string A658WebServiceEndPoint ;
      private string A660WebServiceUsuario ;
      private string A661WebServiceSenha ;
      private string ZZ657WebServiceTipoDmWS ;
      private string ZZ658WebServiceEndPoint ;
      private string ZZ659WebServiceAuthTipo ;
      private string ZZ660WebServiceUsuario ;
      private string ZZ661WebServiceSenha ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWebServiceTipoDmWS ;
      private GXCombobox cmbWebServiceAuthTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T002D4_A656WebServiceId ;
      private string[] T002D4_A657WebServiceTipoDmWS ;
      private bool[] T002D4_n657WebServiceTipoDmWS ;
      private string[] T002D4_A658WebServiceEndPoint ;
      private bool[] T002D4_n658WebServiceEndPoint ;
      private string[] T002D4_A659WebServiceAuthTipo ;
      private bool[] T002D4_n659WebServiceAuthTipo ;
      private string[] T002D4_A660WebServiceUsuario ;
      private bool[] T002D4_n660WebServiceUsuario ;
      private string[] T002D4_A661WebServiceSenha ;
      private bool[] T002D4_n661WebServiceSenha ;
      private int[] T002D5_A656WebServiceId ;
      private int[] T002D3_A656WebServiceId ;
      private string[] T002D3_A657WebServiceTipoDmWS ;
      private bool[] T002D3_n657WebServiceTipoDmWS ;
      private string[] T002D3_A658WebServiceEndPoint ;
      private bool[] T002D3_n658WebServiceEndPoint ;
      private string[] T002D3_A659WebServiceAuthTipo ;
      private bool[] T002D3_n659WebServiceAuthTipo ;
      private string[] T002D3_A660WebServiceUsuario ;
      private bool[] T002D3_n660WebServiceUsuario ;
      private string[] T002D3_A661WebServiceSenha ;
      private bool[] T002D3_n661WebServiceSenha ;
      private int[] T002D6_A656WebServiceId ;
      private int[] T002D7_A656WebServiceId ;
      private int[] T002D2_A656WebServiceId ;
      private string[] T002D2_A657WebServiceTipoDmWS ;
      private bool[] T002D2_n657WebServiceTipoDmWS ;
      private string[] T002D2_A658WebServiceEndPoint ;
      private bool[] T002D2_n658WebServiceEndPoint ;
      private string[] T002D2_A659WebServiceAuthTipo ;
      private bool[] T002D2_n659WebServiceAuthTipo ;
      private string[] T002D2_A660WebServiceUsuario ;
      private bool[] T002D2_n660WebServiceUsuario ;
      private string[] T002D2_A661WebServiceSenha ;
      private bool[] T002D2_n661WebServiceSenha ;
      private int[] T002D9_A656WebServiceId ;
      private int[] T002D12_A656WebServiceId ;
   }

   public class webservice__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002D2;
          prmT002D2 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D3;
          prmT002D3 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D4;
          prmT002D4 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D5;
          prmT002D5 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D6;
          prmT002D6 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D7;
          prmT002D7 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D8;
          prmT002D8 = new Object[] {
          new ParDef("WebServiceTipoDmWS",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceEndPoint",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("WebServiceAuthTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceUsuario",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("WebServiceSenha",GXType.VarChar,100,0){Nullable=true}
          };
          Object[] prmT002D9;
          prmT002D9 = new Object[] {
          };
          Object[] prmT002D10;
          prmT002D10 = new Object[] {
          new ParDef("WebServiceTipoDmWS",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceEndPoint",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("WebServiceAuthTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceUsuario",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("WebServiceSenha",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D11;
          prmT002D11 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmT002D12;
          prmT002D12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002D2", "SELECT WebServiceId, WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha FROM WebService WHERE WebServiceId = :WebServiceId  FOR UPDATE OF WebService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D3", "SELECT WebServiceId, WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha FROM WebService WHERE WebServiceId = :WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D4", "SELECT TM1.WebServiceId, TM1.WebServiceTipoDmWS, TM1.WebServiceEndPoint, TM1.WebServiceAuthTipo, TM1.WebServiceUsuario, TM1.WebServiceSenha FROM WebService TM1 WHERE TM1.WebServiceId = :WebServiceId ORDER BY TM1.WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D5", "SELECT WebServiceId FROM WebService WHERE WebServiceId = :WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D6", "SELECT WebServiceId FROM WebService WHERE ( WebServiceId > :WebServiceId) ORDER BY WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002D7", "SELECT WebServiceId FROM WebService WHERE ( WebServiceId < :WebServiceId) ORDER BY WebServiceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002D8", "SAVEPOINT gxupdate;INSERT INTO WebService(WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha) VALUES(:WebServiceTipoDmWS, :WebServiceEndPoint, :WebServiceAuthTipo, :WebServiceUsuario, :WebServiceSenha);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002D8)
             ,new CursorDef("T002D9", "SELECT currval('WebServiceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002D10", "SAVEPOINT gxupdate;UPDATE WebService SET WebServiceTipoDmWS=:WebServiceTipoDmWS, WebServiceEndPoint=:WebServiceEndPoint, WebServiceAuthTipo=:WebServiceAuthTipo, WebServiceUsuario=:WebServiceUsuario, WebServiceSenha=:WebServiceSenha  WHERE WebServiceId = :WebServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002D10)
             ,new CursorDef("T002D11", "SAVEPOINT gxupdate;DELETE FROM WebService  WHERE WebServiceId = :WebServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002D11)
             ,new CursorDef("T002D12", "SELECT WebServiceId FROM WebService ORDER BY WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D12,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 2 :
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
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
