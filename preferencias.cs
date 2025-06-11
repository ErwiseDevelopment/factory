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
   public class preferencias : GXDataArea
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
         Form.Meta.addItem("description", "Preferencias", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPreferenciasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public preferencias( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public preferencias( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Preferencias", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Preferencias.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Preferencias.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPreferenciasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPreferenciasId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPreferenciasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A296PreferenciasId), 9, 0, ",", "")), StringUtil.LTrim( ((edtPreferenciasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A296PreferenciasId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A296PreferenciasId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPreferenciasId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPreferenciasId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPreferenciasMulta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPreferenciasMulta_Internalname, "Multa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPreferenciasMulta_Internalname, ((Convert.ToDecimal(0)==A297PreferenciasMulta)&&IsIns( )||n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A297PreferenciasMulta)&&IsIns( )||n297PreferenciasMulta ? "" : StringUtil.LTrim( ((edtPreferenciasMulta_Enabled!=0) ? context.localUtil.Format( A297PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A297PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPreferenciasMulta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPreferenciasMulta_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPreferenciasJuros_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPreferenciasJuros_Internalname, "Juros", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPreferenciasJuros_Internalname, ((Convert.ToDecimal(0)==A298PreferenciasJuros)&&IsIns( )||n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A298PreferenciasJuros)&&IsIns( )||n298PreferenciasJuros ? "" : StringUtil.LTrim( ((edtPreferenciasJuros_Enabled!=0) ? context.localUtil.Format( A298PreferenciasJuros, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A298PreferenciasJuros, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPreferenciasJuros_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPreferenciasJuros_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Preferencias.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Preferencias.htm");
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
            Z296PreferenciasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z296PreferenciasId"), ",", "."), 18, MidpointRounding.ToEven));
            Z297PreferenciasMulta = context.localUtil.CToN( cgiGet( "Z297PreferenciasMulta"), ",", ".");
            n297PreferenciasMulta = ((Convert.ToDecimal(0)==A297PreferenciasMulta) ? true : false);
            Z298PreferenciasJuros = context.localUtil.CToN( cgiGet( "Z298PreferenciasJuros"), ",", ".");
            n298PreferenciasJuros = ((Convert.ToDecimal(0)==A298PreferenciasJuros) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPreferenciasId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPreferenciasId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PREFERENCIASID");
               AnyError = 1;
               GX_FocusControl = edtPreferenciasId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A296PreferenciasId = 0;
               AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
            }
            else
            {
               A296PreferenciasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPreferenciasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
            }
            n297PreferenciasMulta = ((StringUtil.StrCmp(cgiGet( edtPreferenciasMulta_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPreferenciasMulta_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPreferenciasMulta_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PREFERENCIASMULTA");
               AnyError = 1;
               GX_FocusControl = edtPreferenciasMulta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A297PreferenciasMulta = 0;
               n297PreferenciasMulta = false;
               AssignAttri("", false, "A297PreferenciasMulta", (n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 16, 4, ".", ""))));
            }
            else
            {
               A297PreferenciasMulta = context.localUtil.CToN( cgiGet( edtPreferenciasMulta_Internalname), ",", ".");
               AssignAttri("", false, "A297PreferenciasMulta", (n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 16, 4, ".", ""))));
            }
            n298PreferenciasJuros = ((StringUtil.StrCmp(cgiGet( edtPreferenciasJuros_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPreferenciasJuros_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPreferenciasJuros_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PREFERENCIASJUROS");
               AnyError = 1;
               GX_FocusControl = edtPreferenciasJuros_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A298PreferenciasJuros = 0;
               n298PreferenciasJuros = false;
               AssignAttri("", false, "A298PreferenciasJuros", (n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 16, 4, ".", ""))));
            }
            else
            {
               A298PreferenciasJuros = context.localUtil.CToN( cgiGet( edtPreferenciasJuros_Internalname), ",", ".");
               AssignAttri("", false, "A298PreferenciasJuros", (n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 16, 4, ".", ""))));
            }
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
               A296PreferenciasId = (int)(Math.Round(NumberUtil.Val( GetPar( "PreferenciasId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
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
               InitAll1847( ) ;
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
         DisableAttributes1847( ) ;
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

      protected void ResetCaption180( )
      {
      }

      protected void ZM1847( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z297PreferenciasMulta = T00183_A297PreferenciasMulta[0];
               Z298PreferenciasJuros = T00183_A298PreferenciasJuros[0];
            }
            else
            {
               Z297PreferenciasMulta = A297PreferenciasMulta;
               Z298PreferenciasJuros = A298PreferenciasJuros;
            }
         }
         if ( GX_JID == -1 )
         {
            Z296PreferenciasId = A296PreferenciasId;
            Z297PreferenciasMulta = A297PreferenciasMulta;
            Z298PreferenciasJuros = A298PreferenciasJuros;
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

      protected void Load1847( )
      {
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound47 = 1;
            A297PreferenciasMulta = T00184_A297PreferenciasMulta[0];
            n297PreferenciasMulta = T00184_n297PreferenciasMulta[0];
            AssignAttri("", false, "A297PreferenciasMulta", ((Convert.ToDecimal(0)==A297PreferenciasMulta)&&IsIns( )||n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 16, 4, ".", ""))));
            A298PreferenciasJuros = T00184_A298PreferenciasJuros[0];
            n298PreferenciasJuros = T00184_n298PreferenciasJuros[0];
            AssignAttri("", false, "A298PreferenciasJuros", ((Convert.ToDecimal(0)==A298PreferenciasJuros)&&IsIns( )||n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 16, 4, ".", ""))));
            ZM1847( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1847( ) ;
      }

      protected void OnLoadActions1847( )
      {
      }

      protected void CheckExtendedTable1847( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1847( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1847( )
      {
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1847( 1) ;
            RcdFound47 = 1;
            A296PreferenciasId = T00183_A296PreferenciasId[0];
            AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
            A297PreferenciasMulta = T00183_A297PreferenciasMulta[0];
            n297PreferenciasMulta = T00183_n297PreferenciasMulta[0];
            AssignAttri("", false, "A297PreferenciasMulta", ((Convert.ToDecimal(0)==A297PreferenciasMulta)&&IsIns( )||n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 16, 4, ".", ""))));
            A298PreferenciasJuros = T00183_A298PreferenciasJuros[0];
            n298PreferenciasJuros = T00183_n298PreferenciasJuros[0];
            AssignAttri("", false, "A298PreferenciasJuros", ((Convert.ToDecimal(0)==A298PreferenciasJuros)&&IsIns( )||n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 16, 4, ".", ""))));
            Z296PreferenciasId = A296PreferenciasId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1847( ) ;
            if ( AnyError == 1 )
            {
               RcdFound47 = 0;
               InitializeNonKey1847( ) ;
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey1847( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1847( ) ;
         if ( RcdFound47 == 0 )
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
         RcdFound47 = 0;
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00186_A296PreferenciasId[0] < A296PreferenciasId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00186_A296PreferenciasId[0] > A296PreferenciasId ) ) )
            {
               A296PreferenciasId = T00186_A296PreferenciasId[0];
               AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
               RcdFound47 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound47 = 0;
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00187_A296PreferenciasId[0] > A296PreferenciasId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00187_A296PreferenciasId[0] < A296PreferenciasId ) ) )
            {
               A296PreferenciasId = T00187_A296PreferenciasId[0];
               AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
               RcdFound47 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1847( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPreferenciasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1847( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound47 == 1 )
            {
               if ( A296PreferenciasId != Z296PreferenciasId )
               {
                  A296PreferenciasId = Z296PreferenciasId;
                  AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PREFERENCIASID");
                  AnyError = 1;
                  GX_FocusControl = edtPreferenciasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPreferenciasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1847( ) ;
                  GX_FocusControl = edtPreferenciasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A296PreferenciasId != Z296PreferenciasId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPreferenciasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1847( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PREFERENCIASID");
                     AnyError = 1;
                     GX_FocusControl = edtPreferenciasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPreferenciasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1847( ) ;
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
         if ( A296PreferenciasId != Z296PreferenciasId )
         {
            A296PreferenciasId = Z296PreferenciasId;
            AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PREFERENCIASID");
            AnyError = 1;
            GX_FocusControl = edtPreferenciasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPreferenciasId_Internalname;
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
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PREFERENCIASID");
            AnyError = 1;
            GX_FocusControl = edtPreferenciasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPreferenciasMulta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1847( ) ;
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPreferenciasMulta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1847( ) ;
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
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPreferenciasMulta_Internalname;
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
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPreferenciasMulta_Internalname;
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
         ScanStart1847( ) ;
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound47 != 0 )
            {
               ScanNext1847( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPreferenciasMulta_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1847( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1847( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A296PreferenciasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Preferencias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z297PreferenciasMulta != T00182_A297PreferenciasMulta[0] ) || ( Z298PreferenciasJuros != T00182_A298PreferenciasJuros[0] ) )
            {
               if ( Z297PreferenciasMulta != T00182_A297PreferenciasMulta[0] )
               {
                  GXUtil.WriteLog("preferencias:[seudo value changed for attri]"+"PreferenciasMulta");
                  GXUtil.WriteLogRaw("Old: ",Z297PreferenciasMulta);
                  GXUtil.WriteLogRaw("Current: ",T00182_A297PreferenciasMulta[0]);
               }
               if ( Z298PreferenciasJuros != T00182_A298PreferenciasJuros[0] )
               {
                  GXUtil.WriteLog("preferencias:[seudo value changed for attri]"+"PreferenciasJuros");
                  GXUtil.WriteLogRaw("Old: ",Z298PreferenciasJuros);
                  GXUtil.WriteLogRaw("Current: ",T00182_A298PreferenciasJuros[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Preferencias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1847( )
      {
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1847( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1847( 0) ;
            CheckOptimisticConcurrency1847( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1847( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1847( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00188 */
                     pr_default.execute(6, new Object[] {n297PreferenciasMulta, A297PreferenciasMulta, n298PreferenciasJuros, A298PreferenciasJuros});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T00189 */
                     pr_default.execute(7);
                     A296PreferenciasId = T00189_A296PreferenciasId[0];
                     AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Preferencias");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption180( ) ;
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
               Load1847( ) ;
            }
            EndLevel1847( ) ;
         }
         CloseExtendedTableCursors1847( ) ;
      }

      protected void Update1847( )
      {
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1847( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1847( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1847( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1847( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001810 */
                     pr_default.execute(8, new Object[] {n297PreferenciasMulta, A297PreferenciasMulta, n298PreferenciasJuros, A298PreferenciasJuros, A296PreferenciasId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Preferencias");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Preferencias"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1847( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption180( ) ;
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
            EndLevel1847( ) ;
         }
         CloseExtendedTableCursors1847( ) ;
      }

      protected void DeferredUpdate1847( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1847( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1847( ) ;
            AfterConfirm1847( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1847( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001811 */
                  pr_default.execute(9, new Object[] {A296PreferenciasId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Preferencias");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound47 == 0 )
                        {
                           InitAll1847( ) ;
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
                        ResetCaption180( ) ;
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1847( ) ;
         Gx_mode = sMode47;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1847( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1847( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1847( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
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

      public void ScanStart1847( )
      {
         /* Using cursor T001812 */
         pr_default.execute(10);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound47 = 1;
            A296PreferenciasId = T001812_A296PreferenciasId[0];
            AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1847( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound47 = 1;
            A296PreferenciasId = T001812_A296PreferenciasId[0];
            AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
         }
      }

      protected void ScanEnd1847( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1847( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1847( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1847( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1847( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1847( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1847( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1847( )
      {
         edtPreferenciasId_Enabled = 0;
         AssignProp("", false, edtPreferenciasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPreferenciasId_Enabled), 5, 0), true);
         edtPreferenciasMulta_Enabled = 0;
         AssignProp("", false, edtPreferenciasMulta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPreferenciasMulta_Enabled), 5, 0), true);
         edtPreferenciasJuros_Enabled = 0;
         AssignProp("", false, edtPreferenciasJuros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPreferenciasJuros_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1847( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("preferencias") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z296PreferenciasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z296PreferenciasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z297PreferenciasMulta", StringUtil.LTrim( StringUtil.NToC( Z297PreferenciasMulta, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z298PreferenciasJuros", StringUtil.LTrim( StringUtil.NToC( Z298PreferenciasJuros, 16, 4, ",", "")));
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
         return formatLink("preferencias")  ;
      }

      public override string GetPgmname( )
      {
         return "Preferencias" ;
      }

      public override string GetPgmdesc( )
      {
         return "Preferencias" ;
      }

      protected void InitializeNonKey1847( )
      {
         A297PreferenciasMulta = 0;
         n297PreferenciasMulta = false;
         AssignAttri("", false, "A297PreferenciasMulta", ((Convert.ToDecimal(0)==A297PreferenciasMulta)&&IsIns( )||n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 16, 4, ".", ""))));
         n297PreferenciasMulta = ((Convert.ToDecimal(0)==A297PreferenciasMulta) ? true : false);
         A298PreferenciasJuros = 0;
         n298PreferenciasJuros = false;
         AssignAttri("", false, "A298PreferenciasJuros", ((Convert.ToDecimal(0)==A298PreferenciasJuros)&&IsIns( )||n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 16, 4, ".", ""))));
         n298PreferenciasJuros = ((Convert.ToDecimal(0)==A298PreferenciasJuros) ? true : false);
         Z297PreferenciasMulta = 0;
         Z298PreferenciasJuros = 0;
      }

      protected void InitAll1847( )
      {
         A296PreferenciasId = 0;
         AssignAttri("", false, "A296PreferenciasId", StringUtil.LTrimStr( (decimal)(A296PreferenciasId), 9, 0));
         InitializeNonKey1847( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019143667", true, true);
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
         context.AddJavascriptSource("preferencias.js", "?202561019143668", false, true);
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
         edtPreferenciasId_Internalname = "PREFERENCIASID";
         edtPreferenciasMulta_Internalname = "PREFERENCIASMULTA";
         edtPreferenciasJuros_Internalname = "PREFERENCIASJUROS";
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
         Form.Caption = "Preferencias";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPreferenciasJuros_Jsonclick = "";
         edtPreferenciasJuros_Enabled = 1;
         edtPreferenciasMulta_Jsonclick = "";
         edtPreferenciasMulta_Enabled = 1;
         edtPreferenciasId_Jsonclick = "";
         edtPreferenciasId_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPreferenciasMulta_Internalname;
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

      public void Valid_Preferenciasid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A297PreferenciasMulta", ((Convert.ToDecimal(0)==A297PreferenciasMulta)&&IsIns( )||n297PreferenciasMulta ? "" : StringUtil.LTrim( StringUtil.NToC( A297PreferenciasMulta, 16, 4, ".", ""))));
         AssignAttri("", false, "A298PreferenciasJuros", ((Convert.ToDecimal(0)==A298PreferenciasJuros)&&IsIns( )||n298PreferenciasJuros ? "" : StringUtil.LTrim( StringUtil.NToC( A298PreferenciasJuros, 16, 4, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z296PreferenciasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z296PreferenciasId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z297PreferenciasMulta", StringUtil.LTrim( StringUtil.NToC( Z297PreferenciasMulta, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z298PreferenciasJuros", StringUtil.LTrim( StringUtil.NToC( Z298PreferenciasJuros, 16, 4, ".", "")));
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
         setEventMetadata("VALID_PREFERENCIASID","""{"handler":"Valid_Preferenciasid","iparms":[{"av":"A296PreferenciasId","fld":"PREFERENCIASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_PREFERENCIASID",""","oparms":[{"av":"A297PreferenciasMulta","fld":"PREFERENCIASMULTA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n297PreferenciasMulta","type":"decimal"},{"av":"A298PreferenciasJuros","fld":"PREFERENCIASJUROS","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n298PreferenciasJuros","type":"decimal"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z296PreferenciasId","type":"int"},{"av":"Z297PreferenciasMulta","type":"decimal"},{"av":"Z298PreferenciasJuros","type":"decimal"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
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
         T00184_A296PreferenciasId = new int[1] ;
         T00184_A297PreferenciasMulta = new decimal[1] ;
         T00184_n297PreferenciasMulta = new bool[] {false} ;
         T00184_A298PreferenciasJuros = new decimal[1] ;
         T00184_n298PreferenciasJuros = new bool[] {false} ;
         T00185_A296PreferenciasId = new int[1] ;
         T00183_A296PreferenciasId = new int[1] ;
         T00183_A297PreferenciasMulta = new decimal[1] ;
         T00183_n297PreferenciasMulta = new bool[] {false} ;
         T00183_A298PreferenciasJuros = new decimal[1] ;
         T00183_n298PreferenciasJuros = new bool[] {false} ;
         sMode47 = "";
         T00186_A296PreferenciasId = new int[1] ;
         T00187_A296PreferenciasId = new int[1] ;
         T00182_A296PreferenciasId = new int[1] ;
         T00182_A297PreferenciasMulta = new decimal[1] ;
         T00182_n297PreferenciasMulta = new bool[] {false} ;
         T00182_A298PreferenciasJuros = new decimal[1] ;
         T00182_n298PreferenciasJuros = new bool[] {false} ;
         T00189_A296PreferenciasId = new int[1] ;
         T001812_A296PreferenciasId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.preferencias__default(),
            new Object[][] {
                new Object[] {
               T00182_A296PreferenciasId, T00182_A297PreferenciasMulta, T00182_n297PreferenciasMulta, T00182_A298PreferenciasJuros, T00182_n298PreferenciasJuros
               }
               , new Object[] {
               T00183_A296PreferenciasId, T00183_A297PreferenciasMulta, T00183_n297PreferenciasMulta, T00183_A298PreferenciasJuros, T00183_n298PreferenciasJuros
               }
               , new Object[] {
               T00184_A296PreferenciasId, T00184_A297PreferenciasMulta, T00184_n297PreferenciasMulta, T00184_A298PreferenciasJuros, T00184_n298PreferenciasJuros
               }
               , new Object[] {
               T00185_A296PreferenciasId
               }
               , new Object[] {
               T00186_A296PreferenciasId
               }
               , new Object[] {
               T00187_A296PreferenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               T00189_A296PreferenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001812_A296PreferenciasId
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
      private short RcdFound47 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z296PreferenciasId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A296PreferenciasId ;
      private int edtPreferenciasId_Enabled ;
      private int edtPreferenciasMulta_Enabled ;
      private int edtPreferenciasJuros_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ296PreferenciasId ;
      private decimal Z297PreferenciasMulta ;
      private decimal Z298PreferenciasJuros ;
      private decimal A297PreferenciasMulta ;
      private decimal A298PreferenciasJuros ;
      private decimal ZZ297PreferenciasMulta ;
      private decimal ZZ298PreferenciasJuros ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPreferenciasId_Internalname ;
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
      private string edtPreferenciasId_Jsonclick ;
      private string edtPreferenciasMulta_Internalname ;
      private string edtPreferenciasMulta_Jsonclick ;
      private string edtPreferenciasJuros_Internalname ;
      private string edtPreferenciasJuros_Jsonclick ;
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
      private string sMode47 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n297PreferenciasMulta ;
      private bool n298PreferenciasJuros ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00184_A296PreferenciasId ;
      private decimal[] T00184_A297PreferenciasMulta ;
      private bool[] T00184_n297PreferenciasMulta ;
      private decimal[] T00184_A298PreferenciasJuros ;
      private bool[] T00184_n298PreferenciasJuros ;
      private int[] T00185_A296PreferenciasId ;
      private int[] T00183_A296PreferenciasId ;
      private decimal[] T00183_A297PreferenciasMulta ;
      private bool[] T00183_n297PreferenciasMulta ;
      private decimal[] T00183_A298PreferenciasJuros ;
      private bool[] T00183_n298PreferenciasJuros ;
      private int[] T00186_A296PreferenciasId ;
      private int[] T00187_A296PreferenciasId ;
      private int[] T00182_A296PreferenciasId ;
      private decimal[] T00182_A297PreferenciasMulta ;
      private bool[] T00182_n297PreferenciasMulta ;
      private decimal[] T00182_A298PreferenciasJuros ;
      private bool[] T00182_n298PreferenciasJuros ;
      private int[] T00189_A296PreferenciasId ;
      private int[] T001812_A296PreferenciasId ;
   }

   public class preferencias__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00182;
          prmT00182 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT00183;
          prmT00183 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT00184;
          prmT00184 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT00185;
          prmT00185 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT00186;
          prmT00186 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT00187;
          prmT00187 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT00188;
          prmT00188 = new Object[] {
          new ParDef("PreferenciasMulta",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PreferenciasJuros",GXType.Number,16,4){Nullable=true}
          };
          Object[] prmT00189;
          prmT00189 = new Object[] {
          };
          Object[] prmT001810;
          prmT001810 = new Object[] {
          new ParDef("PreferenciasMulta",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PreferenciasJuros",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT001811;
          prmT001811 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmT001812;
          prmT001812 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00182", "SELECT PreferenciasId, PreferenciasMulta, PreferenciasJuros FROM Preferencias WHERE PreferenciasId = :PreferenciasId  FOR UPDATE OF Preferencias NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00183", "SELECT PreferenciasId, PreferenciasMulta, PreferenciasJuros FROM Preferencias WHERE PreferenciasId = :PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00184", "SELECT TM1.PreferenciasId, TM1.PreferenciasMulta, TM1.PreferenciasJuros FROM Preferencias TM1 WHERE TM1.PreferenciasId = :PreferenciasId ORDER BY TM1.PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00185", "SELECT PreferenciasId FROM Preferencias WHERE PreferenciasId = :PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00186", "SELECT PreferenciasId FROM Preferencias WHERE ( PreferenciasId > :PreferenciasId) ORDER BY PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00187", "SELECT PreferenciasId FROM Preferencias WHERE ( PreferenciasId < :PreferenciasId) ORDER BY PreferenciasId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00188", "SAVEPOINT gxupdate;INSERT INTO Preferencias(PreferenciasMulta, PreferenciasJuros) VALUES(:PreferenciasMulta, :PreferenciasJuros);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00188)
             ,new CursorDef("T00189", "SELECT currval('PreferenciasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT00189,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001810", "SAVEPOINT gxupdate;UPDATE Preferencias SET PreferenciasMulta=:PreferenciasMulta, PreferenciasJuros=:PreferenciasJuros  WHERE PreferenciasId = :PreferenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001810)
             ,new CursorDef("T001811", "SAVEPOINT gxupdate;DELETE FROM Preferencias  WHERE PreferenciasId = :PreferenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001811)
             ,new CursorDef("T001812", "SELECT PreferenciasId FROM Preferencias ORDER BY PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001812,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
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
