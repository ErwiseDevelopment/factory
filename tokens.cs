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
   public class tokens : GXDataArea
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
         Form.Meta.addItem("description", "Tokens", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTokensId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tokens( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tokens( IGxContext context )
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
         cmbTokensType = new GXCombobox();
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
         if ( cmbTokensType.ItemCount > 0 )
         {
            A1053TokensType = cmbTokensType.getValidValue(A1053TokensType);
            n1053TokensType = false;
            AssignAttri("", false, "A1053TokensType", A1053TokensType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTokensType.CurrentValue = StringUtil.RTrim( A1053TokensType);
            AssignProp("", false, cmbTokensType_Internalname, "Values", cmbTokensType.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tokens", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Tokens.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Tokens.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokensId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTokensId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1050TokensId), 9, 0, ",", "")), StringUtil.LTrim( ((edtTokensId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1050TokensId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1050TokensId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokensId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokensId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokensContent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokensContent_Internalname, "Content", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTokensContent_Internalname, A1051TokensContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtTokensContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokensExpire_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokensExpire_Internalname, "seconds", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTokensExpire_Internalname, ((0==A1052TokensExpire)&&IsIns( )||n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ",", ""))), ((0==A1052TokensExpire)&&IsIns( )||n1052TokensExpire ? "" : StringUtil.LTrim( ((edtTokensExpire_Enabled!=0) ? context.localUtil.Format( (decimal)(A1052TokensExpire), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A1052TokensExpire), "ZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokensExpire_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokensExpire_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTokensType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTokensType_Internalname, "token", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTokensType, cmbTokensType_Internalname, StringUtil.RTrim( A1053TokensType), 1, cmbTokensType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbTokensType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Tokens.htm");
         cmbTokensType.CurrentValue = StringUtil.RTrim( A1053TokensType);
         AssignProp("", false, cmbTokensType_Internalname, "Values", (string)(cmbTokensType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokensDateTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokensDateTime_Internalname, "created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTokensDateTime_Internalname, ((0==A1058TokensDateTime)&&IsIns( )||n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ",", ""))), ((0==A1058TokensDateTime)&&IsIns( )||n1058TokensDateTime ? "" : StringUtil.LTrim( ((edtTokensDateTime_Enabled!=0) ? context.localUtil.Format( (decimal)(A1058TokensDateTime), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1058TokensDateTime), "ZZZZZZZZZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTokensDateTime_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTokensDateTime_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTokensSalt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTokensSalt_Internalname, "Salt", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTokensSalt_Internalname, A1057TokensSalt, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtTokensSalt_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Tokens.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tokens.htm");
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
            Z1050TokensId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1050TokensId"), ",", "."), 18, MidpointRounding.ToEven));
            Z1052TokensExpire = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1052TokensExpire"), ",", "."), 18, MidpointRounding.ToEven));
            n1052TokensExpire = ((0==A1052TokensExpire) ? true : false);
            Z1053TokensType = cgiGet( "Z1053TokensType");
            n1053TokensType = (String.IsNullOrEmpty(StringUtil.RTrim( A1053TokensType)) ? true : false);
            Z1058TokensDateTime = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1058TokensDateTime"), ",", "."), 18, MidpointRounding.ToEven));
            n1058TokensDateTime = ((0==A1058TokensDateTime) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTokensId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTokensId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOKENSID");
               AnyError = 1;
               GX_FocusControl = edtTokensId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1050TokensId = 0;
               AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
            }
            else
            {
               A1050TokensId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTokensId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
            }
            A1051TokensContent = cgiGet( edtTokensContent_Internalname);
            n1051TokensContent = false;
            AssignAttri("", false, "A1051TokensContent", A1051TokensContent);
            n1051TokensContent = (String.IsNullOrEmpty(StringUtil.RTrim( A1051TokensContent)) ? true : false);
            n1052TokensExpire = ((StringUtil.StrCmp(cgiGet( edtTokensExpire_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTokensExpire_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTokensExpire_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOKENSEXPIRE");
               AnyError = 1;
               GX_FocusControl = edtTokensExpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1052TokensExpire = 0;
               n1052TokensExpire = false;
               AssignAttri("", false, "A1052TokensExpire", (n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ".", ""))));
            }
            else
            {
               A1052TokensExpire = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTokensExpire_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1052TokensExpire", (n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ".", ""))));
            }
            cmbTokensType.CurrentValue = cgiGet( cmbTokensType_Internalname);
            A1053TokensType = cgiGet( cmbTokensType_Internalname);
            n1053TokensType = false;
            AssignAttri("", false, "A1053TokensType", A1053TokensType);
            n1053TokensType = (String.IsNullOrEmpty(StringUtil.RTrim( A1053TokensType)) ? true : false);
            n1058TokensDateTime = ((StringUtil.StrCmp(cgiGet( edtTokensDateTime_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTokensDateTime_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTokensDateTime_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOKENSDATETIME");
               AnyError = 1;
               GX_FocusControl = edtTokensDateTime_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1058TokensDateTime = 0;
               n1058TokensDateTime = false;
               AssignAttri("", false, "A1058TokensDateTime", (n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ".", ""))));
            }
            else
            {
               A1058TokensDateTime = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTokensDateTime_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1058TokensDateTime", (n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ".", ""))));
            }
            A1057TokensSalt = cgiGet( edtTokensSalt_Internalname);
            n1057TokensSalt = false;
            AssignAttri("", false, "A1057TokensSalt", A1057TokensSalt);
            n1057TokensSalt = (String.IsNullOrEmpty(StringUtil.RTrim( A1057TokensSalt)) ? true : false);
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
               A1050TokensId = (int)(Math.Round(NumberUtil.Val( GetPar( "TokensId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
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
               InitAll35109( ) ;
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
         DisableAttributes35109( ) ;
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

      protected void ResetCaption350( )
      {
      }

      protected void ZM35109( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1052TokensExpire = T00353_A1052TokensExpire[0];
               Z1053TokensType = T00353_A1053TokensType[0];
               Z1058TokensDateTime = T00353_A1058TokensDateTime[0];
            }
            else
            {
               Z1052TokensExpire = A1052TokensExpire;
               Z1053TokensType = A1053TokensType;
               Z1058TokensDateTime = A1058TokensDateTime;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1050TokensId = A1050TokensId;
            Z1051TokensContent = A1051TokensContent;
            Z1052TokensExpire = A1052TokensExpire;
            Z1053TokensType = A1053TokensType;
            Z1058TokensDateTime = A1058TokensDateTime;
            Z1057TokensSalt = A1057TokensSalt;
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

      protected void Load35109( )
      {
         /* Using cursor T00354 */
         pr_default.execute(2, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound109 = 1;
            A1051TokensContent = T00354_A1051TokensContent[0];
            n1051TokensContent = T00354_n1051TokensContent[0];
            AssignAttri("", false, "A1051TokensContent", A1051TokensContent);
            A1052TokensExpire = T00354_A1052TokensExpire[0];
            n1052TokensExpire = T00354_n1052TokensExpire[0];
            AssignAttri("", false, "A1052TokensExpire", ((0==A1052TokensExpire)&&IsIns( )||n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ".", ""))));
            A1053TokensType = T00354_A1053TokensType[0];
            n1053TokensType = T00354_n1053TokensType[0];
            AssignAttri("", false, "A1053TokensType", A1053TokensType);
            A1058TokensDateTime = T00354_A1058TokensDateTime[0];
            n1058TokensDateTime = T00354_n1058TokensDateTime[0];
            AssignAttri("", false, "A1058TokensDateTime", ((0==A1058TokensDateTime)&&IsIns( )||n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ".", ""))));
            A1057TokensSalt = T00354_A1057TokensSalt[0];
            n1057TokensSalt = T00354_n1057TokensSalt[0];
            AssignAttri("", false, "A1057TokensSalt", A1057TokensSalt);
            ZM35109( -2) ;
         }
         pr_default.close(2);
         OnLoadActions35109( ) ;
      }

      protected void OnLoadActions35109( )
      {
      }

      protected void CheckExtendedTable35109( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A1053TokensType, "9cf42625-e388-45f6-aae5-e7c2b7ddcffc") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1053TokensType)) ) )
         {
            GX_msglist.addItem("Campo Type token fora do intervalo", "OutOfRange", 1, "TOKENSTYPE");
            AnyError = 1;
            GX_FocusControl = cmbTokensType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors35109( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey35109( )
      {
         /* Using cursor T00355 */
         pr_default.execute(3, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound109 = 1;
         }
         else
         {
            RcdFound109 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00353 */
         pr_default.execute(1, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM35109( 2) ;
            RcdFound109 = 1;
            A1050TokensId = T00353_A1050TokensId[0];
            AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
            A1051TokensContent = T00353_A1051TokensContent[0];
            n1051TokensContent = T00353_n1051TokensContent[0];
            AssignAttri("", false, "A1051TokensContent", A1051TokensContent);
            A1052TokensExpire = T00353_A1052TokensExpire[0];
            n1052TokensExpire = T00353_n1052TokensExpire[0];
            AssignAttri("", false, "A1052TokensExpire", ((0==A1052TokensExpire)&&IsIns( )||n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ".", ""))));
            A1053TokensType = T00353_A1053TokensType[0];
            n1053TokensType = T00353_n1053TokensType[0];
            AssignAttri("", false, "A1053TokensType", A1053TokensType);
            A1058TokensDateTime = T00353_A1058TokensDateTime[0];
            n1058TokensDateTime = T00353_n1058TokensDateTime[0];
            AssignAttri("", false, "A1058TokensDateTime", ((0==A1058TokensDateTime)&&IsIns( )||n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ".", ""))));
            A1057TokensSalt = T00353_A1057TokensSalt[0];
            n1057TokensSalt = T00353_n1057TokensSalt[0];
            AssignAttri("", false, "A1057TokensSalt", A1057TokensSalt);
            Z1050TokensId = A1050TokensId;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load35109( ) ;
            if ( AnyError == 1 )
            {
               RcdFound109 = 0;
               InitializeNonKey35109( ) ;
            }
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound109 = 0;
            InitializeNonKey35109( ) ;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey35109( ) ;
         if ( RcdFound109 == 0 )
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
         RcdFound109 = 0;
         /* Using cursor T00356 */
         pr_default.execute(4, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00356_A1050TokensId[0] < A1050TokensId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00356_A1050TokensId[0] > A1050TokensId ) ) )
            {
               A1050TokensId = T00356_A1050TokensId[0];
               AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
               RcdFound109 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound109 = 0;
         /* Using cursor T00357 */
         pr_default.execute(5, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00357_A1050TokensId[0] > A1050TokensId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00357_A1050TokensId[0] < A1050TokensId ) ) )
            {
               A1050TokensId = T00357_A1050TokensId[0];
               AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
               RcdFound109 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey35109( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTokensId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert35109( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound109 == 1 )
            {
               if ( A1050TokensId != Z1050TokensId )
               {
                  A1050TokensId = Z1050TokensId;
                  AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOKENSID");
                  AnyError = 1;
                  GX_FocusControl = edtTokensId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTokensId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update35109( ) ;
                  GX_FocusControl = edtTokensId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1050TokensId != Z1050TokensId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTokensId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert35109( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOKENSID");
                     AnyError = 1;
                     GX_FocusControl = edtTokensId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTokensId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert35109( ) ;
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
         if ( A1050TokensId != Z1050TokensId )
         {
            A1050TokensId = Z1050TokensId;
            AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOKENSID");
            AnyError = 1;
            GX_FocusControl = edtTokensId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTokensId_Internalname;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TOKENSID");
            AnyError = 1;
            GX_FocusControl = edtTokensId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTokensContent_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart35109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokensContent_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd35109( ) ;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokensContent_Internalname;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokensContent_Internalname;
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
         ScanStart35109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound109 != 0 )
            {
               ScanNext35109( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTokensContent_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd35109( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency35109( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00352 */
            pr_default.execute(0, new Object[] {A1050TokensId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tokens"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1052TokensExpire != T00352_A1052TokensExpire[0] ) || ( StringUtil.StrCmp(Z1053TokensType, T00352_A1053TokensType[0]) != 0 ) || ( Z1058TokensDateTime != T00352_A1058TokensDateTime[0] ) )
            {
               if ( Z1052TokensExpire != T00352_A1052TokensExpire[0] )
               {
                  GXUtil.WriteLog("tokens:[seudo value changed for attri]"+"TokensExpire");
                  GXUtil.WriteLogRaw("Old: ",Z1052TokensExpire);
                  GXUtil.WriteLogRaw("Current: ",T00352_A1052TokensExpire[0]);
               }
               if ( StringUtil.StrCmp(Z1053TokensType, T00352_A1053TokensType[0]) != 0 )
               {
                  GXUtil.WriteLog("tokens:[seudo value changed for attri]"+"TokensType");
                  GXUtil.WriteLogRaw("Old: ",Z1053TokensType);
                  GXUtil.WriteLogRaw("Current: ",T00352_A1053TokensType[0]);
               }
               if ( Z1058TokensDateTime != T00352_A1058TokensDateTime[0] )
               {
                  GXUtil.WriteLog("tokens:[seudo value changed for attri]"+"TokensDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z1058TokensDateTime);
                  GXUtil.WriteLogRaw("Current: ",T00352_A1058TokensDateTime[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tokens"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert35109( )
      {
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable35109( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM35109( 0) ;
            CheckOptimisticConcurrency35109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm35109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert35109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00358 */
                     pr_default.execute(6, new Object[] {n1051TokensContent, A1051TokensContent, n1052TokensExpire, A1052TokensExpire, n1053TokensType, A1053TokensType, n1058TokensDateTime, A1058TokensDateTime, n1057TokensSalt, A1057TokensSalt});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T00359 */
                     pr_default.execute(7);
                     A1050TokensId = T00359_A1050TokensId[0];
                     AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Tokens");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption350( ) ;
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
               Load35109( ) ;
            }
            EndLevel35109( ) ;
         }
         CloseExtendedTableCursors35109( ) ;
      }

      protected void Update35109( )
      {
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable35109( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency35109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm35109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate35109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003510 */
                     pr_default.execute(8, new Object[] {n1051TokensContent, A1051TokensContent, n1052TokensExpire, A1052TokensExpire, n1053TokensType, A1053TokensType, n1058TokensDateTime, A1058TokensDateTime, n1057TokensSalt, A1057TokensSalt, A1050TokensId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Tokens");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tokens"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate35109( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption350( ) ;
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
            EndLevel35109( ) ;
         }
         CloseExtendedTableCursors35109( ) ;
      }

      protected void DeferredUpdate35109( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency35109( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls35109( ) ;
            AfterConfirm35109( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete35109( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003511 */
                  pr_default.execute(9, new Object[] {A1050TokensId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Tokens");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound109 == 0 )
                        {
                           InitAll35109( ) ;
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
                        ResetCaption350( ) ;
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
         sMode109 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel35109( ) ;
         Gx_mode = sMode109;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls35109( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel35109( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete35109( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues350( ) ;
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

      public void ScanStart35109( )
      {
         /* Using cursor T003512 */
         pr_default.execute(10);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound109 = 1;
            A1050TokensId = T003512_A1050TokensId[0];
            AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext35109( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound109 = 1;
            A1050TokensId = T003512_A1050TokensId[0];
            AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
         }
      }

      protected void ScanEnd35109( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm35109( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert35109( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate35109( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete35109( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete35109( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate35109( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes35109( )
      {
         edtTokensId_Enabled = 0;
         AssignProp("", false, edtTokensId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokensId_Enabled), 5, 0), true);
         edtTokensContent_Enabled = 0;
         AssignProp("", false, edtTokensContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokensContent_Enabled), 5, 0), true);
         edtTokensExpire_Enabled = 0;
         AssignProp("", false, edtTokensExpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokensExpire_Enabled), 5, 0), true);
         cmbTokensType.Enabled = 0;
         AssignProp("", false, cmbTokensType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTokensType.Enabled), 5, 0), true);
         edtTokensDateTime_Enabled = 0;
         AssignProp("", false, edtTokensDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokensDateTime_Enabled), 5, 0), true);
         edtTokensSalt_Enabled = 0;
         AssignProp("", false, edtTokensSalt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTokensSalt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes35109( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues350( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tokens") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1050TokensId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1050TokensId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1052TokensExpire", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1052TokensExpire), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1053TokensType", Z1053TokensType);
         GxWebStd.gx_hidden_field( context, "Z1058TokensDateTime", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1058TokensDateTime), 18, 0, ",", "")));
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
         return formatLink("tokens")  ;
      }

      public override string GetPgmname( )
      {
         return "Tokens" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tokens" ;
      }

      protected void InitializeNonKey35109( )
      {
         A1051TokensContent = "";
         n1051TokensContent = false;
         AssignAttri("", false, "A1051TokensContent", A1051TokensContent);
         n1051TokensContent = (String.IsNullOrEmpty(StringUtil.RTrim( A1051TokensContent)) ? true : false);
         A1052TokensExpire = 0;
         n1052TokensExpire = false;
         AssignAttri("", false, "A1052TokensExpire", ((0==A1052TokensExpire)&&IsIns( )||n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ".", ""))));
         n1052TokensExpire = ((0==A1052TokensExpire) ? true : false);
         A1053TokensType = "";
         n1053TokensType = false;
         AssignAttri("", false, "A1053TokensType", A1053TokensType);
         n1053TokensType = (String.IsNullOrEmpty(StringUtil.RTrim( A1053TokensType)) ? true : false);
         A1058TokensDateTime = 0;
         n1058TokensDateTime = false;
         AssignAttri("", false, "A1058TokensDateTime", ((0==A1058TokensDateTime)&&IsIns( )||n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ".", ""))));
         n1058TokensDateTime = ((0==A1058TokensDateTime) ? true : false);
         A1057TokensSalt = "";
         n1057TokensSalt = false;
         AssignAttri("", false, "A1057TokensSalt", A1057TokensSalt);
         n1057TokensSalt = (String.IsNullOrEmpty(StringUtil.RTrim( A1057TokensSalt)) ? true : false);
         Z1052TokensExpire = 0;
         Z1053TokensType = "";
         Z1058TokensDateTime = 0;
      }

      protected void InitAll35109( )
      {
         A1050TokensId = 0;
         AssignAttri("", false, "A1050TokensId", StringUtil.LTrimStr( (decimal)(A1050TokensId), 9, 0));
         InitializeNonKey35109( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019221244", true, true);
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
         context.AddJavascriptSource("tokens.js", "?202561019221245", false, true);
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
         edtTokensId_Internalname = "TOKENSID";
         edtTokensContent_Internalname = "TOKENSCONTENT";
         edtTokensExpire_Internalname = "TOKENSEXPIRE";
         cmbTokensType_Internalname = "TOKENSTYPE";
         edtTokensDateTime_Internalname = "TOKENSDATETIME";
         edtTokensSalt_Internalname = "TOKENSSALT";
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
         Form.Caption = "Tokens";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTokensSalt_Enabled = 1;
         edtTokensDateTime_Jsonclick = "";
         edtTokensDateTime_Enabled = 1;
         cmbTokensType_Jsonclick = "";
         cmbTokensType.Enabled = 1;
         edtTokensExpire_Jsonclick = "";
         edtTokensExpire_Enabled = 1;
         edtTokensContent_Enabled = 1;
         edtTokensId_Jsonclick = "";
         edtTokensId_Enabled = 1;
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
         cmbTokensType.Name = "TOKENSTYPE";
         cmbTokensType.WebTags = "";
         cmbTokensType.addItem("9cf42625-e388-45f6-aae5-e7c2b7ddcffc", "Santander", 0);
         if ( cmbTokensType.ItemCount > 0 )
         {
            A1053TokensType = cmbTokensType.getValidValue(A1053TokensType);
            n1053TokensType = false;
            AssignAttri("", false, "A1053TokensType", A1053TokensType);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTokensContent_Internalname;
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

      public void Valid_Tokensid( )
      {
         n1053TokensType = false;
         A1053TokensType = cmbTokensType.CurrentValue;
         n1053TokensType = false;
         cmbTokensType.CurrentValue = A1053TokensType;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTokensType.ItemCount > 0 )
         {
            A1053TokensType = cmbTokensType.getValidValue(A1053TokensType);
            n1053TokensType = false;
            cmbTokensType.CurrentValue = A1053TokensType;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTokensType.CurrentValue = StringUtil.RTrim( A1053TokensType);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1051TokensContent", A1051TokensContent);
         AssignAttri("", false, "A1052TokensExpire", ((0==A1052TokensExpire)&&IsIns( )||n1052TokensExpire ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1052TokensExpire), 8, 0, ".", ""))));
         AssignAttri("", false, "A1053TokensType", A1053TokensType);
         cmbTokensType.CurrentValue = StringUtil.RTrim( A1053TokensType);
         AssignProp("", false, cmbTokensType_Internalname, "Values", cmbTokensType.ToJavascriptSource(), true);
         AssignAttri("", false, "A1058TokensDateTime", ((0==A1058TokensDateTime)&&IsIns( )||n1058TokensDateTime ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1058TokensDateTime), 18, 0, ".", ""))));
         AssignAttri("", false, "A1057TokensSalt", A1057TokensSalt);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1050TokensId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1050TokensId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1051TokensContent", Z1051TokensContent);
         GxWebStd.gx_hidden_field( context, "Z1052TokensExpire", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1052TokensExpire), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1053TokensType", Z1053TokensType);
         GxWebStd.gx_hidden_field( context, "Z1058TokensDateTime", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1058TokensDateTime), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1057TokensSalt", Z1057TokensSalt);
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
         setEventMetadata("VALID_TOKENSID","""{"handler":"Valid_Tokensid","iparms":[{"av":"cmbTokensType"},{"av":"A1053TokensType","fld":"TOKENSTYPE","type":"svchar"},{"av":"A1050TokensId","fld":"TOKENSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_TOKENSID",""","oparms":[{"av":"A1051TokensContent","fld":"TOKENSCONTENT","type":"vchar"},{"av":"A1052TokensExpire","fld":"TOKENSEXPIRE","pic":"ZZZZZZZ9","nullAv":"n1052TokensExpire","type":"int"},{"av":"cmbTokensType"},{"av":"A1053TokensType","fld":"TOKENSTYPE","type":"svchar"},{"av":"A1058TokensDateTime","fld":"TOKENSDATETIME","pic":"ZZZZZZZZZZZZZZZZZ9","nullAv":"n1058TokensDateTime","type":"int"},{"av":"A1057TokensSalt","fld":"TOKENSSALT","type":"vchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z1050TokensId","type":"int"},{"av":"Z1051TokensContent","type":"vchar"},{"av":"Z1052TokensExpire","type":"int"},{"av":"Z1053TokensType","type":"svchar"},{"av":"Z1058TokensDateTime","type":"int"},{"av":"Z1057TokensSalt","type":"vchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_TOKENSTYPE","""{"handler":"Valid_Tokenstype","iparms":[]}""");
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
         Z1053TokensType = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1053TokensType = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A1051TokensContent = "";
         A1057TokensSalt = "";
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
         Z1051TokensContent = "";
         Z1057TokensSalt = "";
         T00354_A1050TokensId = new int[1] ;
         T00354_A1051TokensContent = new string[] {""} ;
         T00354_n1051TokensContent = new bool[] {false} ;
         T00354_A1052TokensExpire = new int[1] ;
         T00354_n1052TokensExpire = new bool[] {false} ;
         T00354_A1053TokensType = new string[] {""} ;
         T00354_n1053TokensType = new bool[] {false} ;
         T00354_A1058TokensDateTime = new long[1] ;
         T00354_n1058TokensDateTime = new bool[] {false} ;
         T00354_A1057TokensSalt = new string[] {""} ;
         T00354_n1057TokensSalt = new bool[] {false} ;
         T00355_A1050TokensId = new int[1] ;
         T00353_A1050TokensId = new int[1] ;
         T00353_A1051TokensContent = new string[] {""} ;
         T00353_n1051TokensContent = new bool[] {false} ;
         T00353_A1052TokensExpire = new int[1] ;
         T00353_n1052TokensExpire = new bool[] {false} ;
         T00353_A1053TokensType = new string[] {""} ;
         T00353_n1053TokensType = new bool[] {false} ;
         T00353_A1058TokensDateTime = new long[1] ;
         T00353_n1058TokensDateTime = new bool[] {false} ;
         T00353_A1057TokensSalt = new string[] {""} ;
         T00353_n1057TokensSalt = new bool[] {false} ;
         sMode109 = "";
         T00356_A1050TokensId = new int[1] ;
         T00357_A1050TokensId = new int[1] ;
         T00352_A1050TokensId = new int[1] ;
         T00352_A1051TokensContent = new string[] {""} ;
         T00352_n1051TokensContent = new bool[] {false} ;
         T00352_A1052TokensExpire = new int[1] ;
         T00352_n1052TokensExpire = new bool[] {false} ;
         T00352_A1053TokensType = new string[] {""} ;
         T00352_n1053TokensType = new bool[] {false} ;
         T00352_A1058TokensDateTime = new long[1] ;
         T00352_n1058TokensDateTime = new bool[] {false} ;
         T00352_A1057TokensSalt = new string[] {""} ;
         T00352_n1057TokensSalt = new bool[] {false} ;
         T00359_A1050TokensId = new int[1] ;
         T003512_A1050TokensId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1051TokensContent = "";
         ZZ1053TokensType = "";
         ZZ1057TokensSalt = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tokens__default(),
            new Object[][] {
                new Object[] {
               T00352_A1050TokensId, T00352_A1051TokensContent, T00352_n1051TokensContent, T00352_A1052TokensExpire, T00352_n1052TokensExpire, T00352_A1053TokensType, T00352_n1053TokensType, T00352_A1058TokensDateTime, T00352_n1058TokensDateTime, T00352_A1057TokensSalt,
               T00352_n1057TokensSalt
               }
               , new Object[] {
               T00353_A1050TokensId, T00353_A1051TokensContent, T00353_n1051TokensContent, T00353_A1052TokensExpire, T00353_n1052TokensExpire, T00353_A1053TokensType, T00353_n1053TokensType, T00353_A1058TokensDateTime, T00353_n1058TokensDateTime, T00353_A1057TokensSalt,
               T00353_n1057TokensSalt
               }
               , new Object[] {
               T00354_A1050TokensId, T00354_A1051TokensContent, T00354_n1051TokensContent, T00354_A1052TokensExpire, T00354_n1052TokensExpire, T00354_A1053TokensType, T00354_n1053TokensType, T00354_A1058TokensDateTime, T00354_n1058TokensDateTime, T00354_A1057TokensSalt,
               T00354_n1057TokensSalt
               }
               , new Object[] {
               T00355_A1050TokensId
               }
               , new Object[] {
               T00356_A1050TokensId
               }
               , new Object[] {
               T00357_A1050TokensId
               }
               , new Object[] {
               }
               , new Object[] {
               T00359_A1050TokensId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003512_A1050TokensId
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
      private short RcdFound109 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1050TokensId ;
      private int Z1052TokensExpire ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A1050TokensId ;
      private int edtTokensId_Enabled ;
      private int edtTokensContent_Enabled ;
      private int A1052TokensExpire ;
      private int edtTokensExpire_Enabled ;
      private int edtTokensDateTime_Enabled ;
      private int edtTokensSalt_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ1050TokensId ;
      private int ZZ1052TokensExpire ;
      private long Z1058TokensDateTime ;
      private long A1058TokensDateTime ;
      private long ZZ1058TokensDateTime ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTokensId_Internalname ;
      private string cmbTokensType_Internalname ;
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
      private string edtTokensId_Jsonclick ;
      private string edtTokensContent_Internalname ;
      private string edtTokensExpire_Internalname ;
      private string edtTokensExpire_Jsonclick ;
      private string cmbTokensType_Jsonclick ;
      private string edtTokensDateTime_Internalname ;
      private string edtTokensDateTime_Jsonclick ;
      private string edtTokensSalt_Internalname ;
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
      private string sMode109 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1053TokensType ;
      private bool n1052TokensExpire ;
      private bool n1058TokensDateTime ;
      private bool n1051TokensContent ;
      private bool n1057TokensSalt ;
      private string A1051TokensContent ;
      private string A1057TokensSalt ;
      private string Z1051TokensContent ;
      private string Z1057TokensSalt ;
      private string ZZ1051TokensContent ;
      private string ZZ1057TokensSalt ;
      private string Z1053TokensType ;
      private string A1053TokensType ;
      private string ZZ1053TokensType ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTokensType ;
      private IDataStoreProvider pr_default ;
      private int[] T00354_A1050TokensId ;
      private string[] T00354_A1051TokensContent ;
      private bool[] T00354_n1051TokensContent ;
      private int[] T00354_A1052TokensExpire ;
      private bool[] T00354_n1052TokensExpire ;
      private string[] T00354_A1053TokensType ;
      private bool[] T00354_n1053TokensType ;
      private long[] T00354_A1058TokensDateTime ;
      private bool[] T00354_n1058TokensDateTime ;
      private string[] T00354_A1057TokensSalt ;
      private bool[] T00354_n1057TokensSalt ;
      private int[] T00355_A1050TokensId ;
      private int[] T00353_A1050TokensId ;
      private string[] T00353_A1051TokensContent ;
      private bool[] T00353_n1051TokensContent ;
      private int[] T00353_A1052TokensExpire ;
      private bool[] T00353_n1052TokensExpire ;
      private string[] T00353_A1053TokensType ;
      private bool[] T00353_n1053TokensType ;
      private long[] T00353_A1058TokensDateTime ;
      private bool[] T00353_n1058TokensDateTime ;
      private string[] T00353_A1057TokensSalt ;
      private bool[] T00353_n1057TokensSalt ;
      private int[] T00356_A1050TokensId ;
      private int[] T00357_A1050TokensId ;
      private int[] T00352_A1050TokensId ;
      private string[] T00352_A1051TokensContent ;
      private bool[] T00352_n1051TokensContent ;
      private int[] T00352_A1052TokensExpire ;
      private bool[] T00352_n1052TokensExpire ;
      private string[] T00352_A1053TokensType ;
      private bool[] T00352_n1053TokensType ;
      private long[] T00352_A1058TokensDateTime ;
      private bool[] T00352_n1058TokensDateTime ;
      private string[] T00352_A1057TokensSalt ;
      private bool[] T00352_n1057TokensSalt ;
      private int[] T00359_A1050TokensId ;
      private int[] T003512_A1050TokensId ;
   }

   public class tokens__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00352;
          prmT00352 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT00353;
          prmT00353 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT00354;
          prmT00354 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT00355;
          prmT00355 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT00356;
          prmT00356 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT00357;
          prmT00357 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT00358;
          prmT00358 = new Object[] {
          new ParDef("TokensContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("TokensExpire",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("TokensType",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TokensDateTime",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("TokensSalt",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          Object[] prmT00359;
          prmT00359 = new Object[] {
          };
          Object[] prmT003510;
          prmT003510 = new Object[] {
          new ParDef("TokensContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("TokensExpire",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("TokensType",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TokensDateTime",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("TokensSalt",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT003511;
          prmT003511 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmT003512;
          prmT003512 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00352", "SELECT TokensId, TokensContent, TokensExpire, TokensType, TokensDateTime, TokensSalt FROM Tokens WHERE TokensId = :TokensId  FOR UPDATE OF Tokens NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00352,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00353", "SELECT TokensId, TokensContent, TokensExpire, TokensType, TokensDateTime, TokensSalt FROM Tokens WHERE TokensId = :TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00353,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00354", "SELECT TM1.TokensId, TM1.TokensContent, TM1.TokensExpire, TM1.TokensType, TM1.TokensDateTime, TM1.TokensSalt FROM Tokens TM1 WHERE TM1.TokensId = :TokensId ORDER BY TM1.TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00354,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00355", "SELECT TokensId FROM Tokens WHERE TokensId = :TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00355,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00356", "SELECT TokensId FROM Tokens WHERE ( TokensId > :TokensId) ORDER BY TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00356,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00357", "SELECT TokensId FROM Tokens WHERE ( TokensId < :TokensId) ORDER BY TokensId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00357,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00358", "SAVEPOINT gxupdate;INSERT INTO Tokens(TokensContent, TokensExpire, TokensType, TokensDateTime, TokensSalt) VALUES(:TokensContent, :TokensExpire, :TokensType, :TokensDateTime, :TokensSalt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00358)
             ,new CursorDef("T00359", "SELECT currval('TokensId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT00359,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003510", "SAVEPOINT gxupdate;UPDATE Tokens SET TokensContent=:TokensContent, TokensExpire=:TokensExpire, TokensType=:TokensType, TokensDateTime=:TokensDateTime, TokensSalt=:TokensSalt  WHERE TokensId = :TokensId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003510)
             ,new CursorDef("T003511", "SAVEPOINT gxupdate;DELETE FROM Tokens  WHERE TokensId = :TokensId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003511)
             ,new CursorDef("T003512", "SELECT TokensId FROM Tokens ORDER BY TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003512,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
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
