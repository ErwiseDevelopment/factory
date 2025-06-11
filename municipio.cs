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
   public class municipio : GXDataArea
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
         Form.Meta.addItem("description", "Municipio", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMunicipioCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public municipio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipio( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Municipio", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Municipio.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Municipio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioCodigo_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioCodigo_Internalname, A186MunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( A186MunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMunicipioCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioNome_Internalname, A187MunicipioNome, StringUtil.RTrim( context.localUtil.Format( A187MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMunicipioNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioDDD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioDDD_Internalname, "DDD", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioDDD_Internalname, A188MunicipioDDD, StringUtil.RTrim( context.localUtil.Format( A188MunicipioDDD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioDDD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMunicipioDDD_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioUF_Internalname, "UF", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioUF_Internalname, A189MunicipioUF, StringUtil.RTrim( context.localUtil.Format( A189MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioUF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMunicipioUF_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Municipio.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Municipio.htm");
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
            Z186MunicipioCodigo = cgiGet( "Z186MunicipioCodigo");
            Z187MunicipioNome = cgiGet( "Z187MunicipioNome");
            n187MunicipioNome = (String.IsNullOrEmpty(StringUtil.RTrim( A187MunicipioNome)) ? true : false);
            Z188MunicipioDDD = cgiGet( "Z188MunicipioDDD");
            n188MunicipioDDD = (String.IsNullOrEmpty(StringUtil.RTrim( A188MunicipioDDD)) ? true : false);
            Z189MunicipioUF = cgiGet( "Z189MunicipioUF");
            n189MunicipioUF = (String.IsNullOrEmpty(StringUtil.RTrim( A189MunicipioUF)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A186MunicipioCodigo = cgiGet( edtMunicipioCodigo_Internalname);
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            A187MunicipioNome = StringUtil.Upper( cgiGet( edtMunicipioNome_Internalname));
            n187MunicipioNome = false;
            AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
            n187MunicipioNome = (String.IsNullOrEmpty(StringUtil.RTrim( A187MunicipioNome)) ? true : false);
            A188MunicipioDDD = cgiGet( edtMunicipioDDD_Internalname);
            n188MunicipioDDD = false;
            AssignAttri("", false, "A188MunicipioDDD", A188MunicipioDDD);
            n188MunicipioDDD = (String.IsNullOrEmpty(StringUtil.RTrim( A188MunicipioDDD)) ? true : false);
            A189MunicipioUF = StringUtil.Upper( cgiGet( edtMunicipioUF_Internalname));
            n189MunicipioUF = false;
            AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
            n189MunicipioUF = (String.IsNullOrEmpty(StringUtil.RTrim( A189MunicipioUF)) ? true : false);
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
               A186MunicipioCodigo = GetPar( "MunicipioCodigo");
               n186MunicipioCodigo = false;
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
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
               InitAll0R31( ) ;
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
         DisableAttributes0R31( ) ;
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

      protected void ResetCaption0R0( )
      {
      }

      protected void ZM0R31( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z187MunicipioNome = T000R3_A187MunicipioNome[0];
               Z188MunicipioDDD = T000R3_A188MunicipioDDD[0];
               Z189MunicipioUF = T000R3_A189MunicipioUF[0];
            }
            else
            {
               Z187MunicipioNome = A187MunicipioNome;
               Z188MunicipioDDD = A188MunicipioDDD;
               Z189MunicipioUF = A189MunicipioUF;
            }
         }
         if ( GX_JID == -1 )
         {
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z187MunicipioNome = A187MunicipioNome;
            Z188MunicipioDDD = A188MunicipioDDD;
            Z189MunicipioUF = A189MunicipioUF;
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

      protected void Load0R31( )
      {
         /* Using cursor T000R4 */
         pr_default.execute(2, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound31 = 1;
            A187MunicipioNome = T000R4_A187MunicipioNome[0];
            n187MunicipioNome = T000R4_n187MunicipioNome[0];
            AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
            A188MunicipioDDD = T000R4_A188MunicipioDDD[0];
            n188MunicipioDDD = T000R4_n188MunicipioDDD[0];
            AssignAttri("", false, "A188MunicipioDDD", A188MunicipioDDD);
            A189MunicipioUF = T000R4_A189MunicipioUF[0];
            n189MunicipioUF = T000R4_n189MunicipioUF[0];
            AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
            ZM0R31( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0R31( ) ;
      }

      protected void OnLoadActions0R31( )
      {
      }

      protected void CheckExtendedTable0R31( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0R31( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R31( )
      {
         /* Using cursor T000R5 */
         pr_default.execute(3, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000R3 */
         pr_default.execute(1, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R31( 1) ;
            RcdFound31 = 1;
            A186MunicipioCodigo = T000R3_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T000R3_n186MunicipioCodigo[0];
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            A187MunicipioNome = T000R3_A187MunicipioNome[0];
            n187MunicipioNome = T000R3_n187MunicipioNome[0];
            AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
            A188MunicipioDDD = T000R3_A188MunicipioDDD[0];
            n188MunicipioDDD = T000R3_n188MunicipioDDD[0];
            AssignAttri("", false, "A188MunicipioDDD", A188MunicipioDDD);
            A189MunicipioUF = T000R3_A189MunicipioUF[0];
            n189MunicipioUF = T000R3_n189MunicipioUF[0];
            AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
            Z186MunicipioCodigo = A186MunicipioCodigo;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0R31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0R31( ) ;
            }
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0R31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R31( ) ;
         if ( RcdFound31 == 0 )
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
         RcdFound31 = 0;
         /* Using cursor T000R6 */
         pr_default.execute(4, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000R6_A186MunicipioCodigo[0], A186MunicipioCodigo) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000R6_A186MunicipioCodigo[0], A186MunicipioCodigo) > 0 ) ) )
            {
               A186MunicipioCodigo = T000R6_A186MunicipioCodigo[0];
               n186MunicipioCodigo = T000R6_n186MunicipioCodigo[0];
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               RcdFound31 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound31 = 0;
         /* Using cursor T000R7 */
         pr_default.execute(5, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000R7_A186MunicipioCodigo[0], A186MunicipioCodigo) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000R7_A186MunicipioCodigo[0], A186MunicipioCodigo) < 0 ) ) )
            {
               A186MunicipioCodigo = T000R7_A186MunicipioCodigo[0];
               n186MunicipioCodigo = T000R7_n186MunicipioCodigo[0];
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               RcdFound31 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0R31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMunicipioCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0R31( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
               {
                  A186MunicipioCodigo = Z186MunicipioCodigo;
                  n186MunicipioCodigo = false;
                  AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MUNICIPIOCODIGO");
                  AnyError = 1;
                  GX_FocusControl = edtMunicipioCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMunicipioCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0R31( ) ;
                  GX_FocusControl = edtMunicipioCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMunicipioCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0R31( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MUNICIPIOCODIGO");
                     AnyError = 1;
                     GX_FocusControl = edtMunicipioCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMunicipioCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0R31( ) ;
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
         if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
         {
            A186MunicipioCodigo = Z186MunicipioCodigo;
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MUNICIPIOCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMunicipioCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMunicipioCodigo_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MUNICIPIOCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMunicipioCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMunicipioNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0R31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMunicipioNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R31( ) ;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMunicipioNome_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMunicipioNome_Internalname;
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
         ScanStart0R31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound31 != 0 )
            {
               ScanNext0R31( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMunicipioNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R31( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0R31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000R2 */
            pr_default.execute(0, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Municipio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z187MunicipioNome, T000R2_A187MunicipioNome[0]) != 0 ) || ( StringUtil.StrCmp(Z188MunicipioDDD, T000R2_A188MunicipioDDD[0]) != 0 ) || ( StringUtil.StrCmp(Z189MunicipioUF, T000R2_A189MunicipioUF[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z187MunicipioNome, T000R2_A187MunicipioNome[0]) != 0 )
               {
                  GXUtil.WriteLog("municipio:[seudo value changed for attri]"+"MunicipioNome");
                  GXUtil.WriteLogRaw("Old: ",Z187MunicipioNome);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A187MunicipioNome[0]);
               }
               if ( StringUtil.StrCmp(Z188MunicipioDDD, T000R2_A188MunicipioDDD[0]) != 0 )
               {
                  GXUtil.WriteLog("municipio:[seudo value changed for attri]"+"MunicipioDDD");
                  GXUtil.WriteLogRaw("Old: ",Z188MunicipioDDD);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A188MunicipioDDD[0]);
               }
               if ( StringUtil.StrCmp(Z189MunicipioUF, T000R2_A189MunicipioUF[0]) != 0 )
               {
                  GXUtil.WriteLog("municipio:[seudo value changed for attri]"+"MunicipioUF");
                  GXUtil.WriteLogRaw("Old: ",Z189MunicipioUF);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A189MunicipioUF[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Municipio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R31( )
      {
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R31( 0) ;
            CheckOptimisticConcurrency0R31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R8 */
                     pr_default.execute(6, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo, n187MunicipioNome, A187MunicipioNome, n188MunicipioDDD, A188MunicipioDDD, n189MunicipioUF, A189MunicipioUF});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Municipio");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0R0( ) ;
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
               Load0R31( ) ;
            }
            EndLevel0R31( ) ;
         }
         CloseExtendedTableCursors0R31( ) ;
      }

      protected void Update0R31( )
      {
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R9 */
                     pr_default.execute(7, new Object[] {n187MunicipioNome, A187MunicipioNome, n188MunicipioDDD, A188MunicipioDDD, n189MunicipioUF, A189MunicipioUF, n186MunicipioCodigo, A186MunicipioCodigo});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Municipio");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Municipio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R31( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0R0( ) ;
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
            EndLevel0R31( ) ;
         }
         CloseExtendedTableCursors0R31( ) ;
      }

      protected void DeferredUpdate0R31( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R31( ) ;
            AfterConfirm0R31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000R10 */
                  pr_default.execute(8, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Municipio");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound31 == 0 )
                        {
                           InitAll0R31( ) ;
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
                        ResetCaption0R0( ) ;
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0R31( ) ;
         Gx_mode = sMode31;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0R31( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000R11 */
            pr_default.execute(9, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000R12 */
            pr_default.execute(10, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"+" ("+"Sb Empresa Representante Municipio"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000R13 */
            pr_default.execute(11, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000R14 */
            pr_default.execute(12, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"+" ("+"Sd Reponsavel Municipio"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000R15 */
            pr_default.execute(13, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0R31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("municipio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("municipio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0R31( )
      {
         /* Using cursor T000R16 */
         pr_default.execute(14);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound31 = 1;
            A186MunicipioCodigo = T000R16_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T000R16_n186MunicipioCodigo[0];
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0R31( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound31 = 1;
            A186MunicipioCodigo = T000R16_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T000R16_n186MunicipioCodigo[0];
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         }
      }

      protected void ScanEnd0R31( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0R31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0R31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R31( )
      {
         edtMunicipioCodigo_Enabled = 0;
         AssignProp("", false, edtMunicipioCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioCodigo_Enabled), 5, 0), true);
         edtMunicipioNome_Enabled = 0;
         AssignProp("", false, edtMunicipioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioNome_Enabled), 5, 0), true);
         edtMunicipioDDD_Enabled = 0;
         AssignProp("", false, edtMunicipioDDD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioDDD_Enabled), 5, 0), true);
         edtMunicipioUF_Enabled = 0;
         AssignProp("", false, edtMunicipioUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioUF_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0R31( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0R0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("municipio") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z186MunicipioCodigo", Z186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "Z187MunicipioNome", Z187MunicipioNome);
         GxWebStd.gx_hidden_field( context, "Z188MunicipioDDD", Z188MunicipioDDD);
         GxWebStd.gx_hidden_field( context, "Z189MunicipioUF", Z189MunicipioUF);
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
         return formatLink("municipio")  ;
      }

      public override string GetPgmname( )
      {
         return "Municipio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Municipio" ;
      }

      protected void InitializeNonKey0R31( )
      {
         A187MunicipioNome = "";
         n187MunicipioNome = false;
         AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
         n187MunicipioNome = (String.IsNullOrEmpty(StringUtil.RTrim( A187MunicipioNome)) ? true : false);
         A188MunicipioDDD = "";
         n188MunicipioDDD = false;
         AssignAttri("", false, "A188MunicipioDDD", A188MunicipioDDD);
         n188MunicipioDDD = (String.IsNullOrEmpty(StringUtil.RTrim( A188MunicipioDDD)) ? true : false);
         A189MunicipioUF = "";
         n189MunicipioUF = false;
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
         n189MunicipioUF = (String.IsNullOrEmpty(StringUtil.RTrim( A189MunicipioUF)) ? true : false);
         Z187MunicipioNome = "";
         Z188MunicipioDDD = "";
         Z189MunicipioUF = "";
      }

      protected void InitAll0R31( )
      {
         A186MunicipioCodigo = "";
         n186MunicipioCodigo = false;
         AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         InitializeNonKey0R31( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019132838", true, true);
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
         context.AddJavascriptSource("municipio.js", "?202561019132839", false, true);
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
         edtMunicipioCodigo_Internalname = "MUNICIPIOCODIGO";
         edtMunicipioNome_Internalname = "MUNICIPIONOME";
         edtMunicipioDDD_Internalname = "MUNICIPIODDD";
         edtMunicipioUF_Internalname = "MUNICIPIOUF";
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
         Form.Caption = "Municipio";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMunicipioUF_Jsonclick = "";
         edtMunicipioUF_Enabled = 1;
         edtMunicipioDDD_Jsonclick = "";
         edtMunicipioDDD_Enabled = 1;
         edtMunicipioNome_Jsonclick = "";
         edtMunicipioNome_Enabled = 1;
         edtMunicipioCodigo_Jsonclick = "";
         edtMunicipioCodigo_Enabled = 1;
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
         GX_FocusControl = edtMunicipioNome_Internalname;
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

      public void Valid_Municipiocodigo( )
      {
         n186MunicipioCodigo = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
         AssignAttri("", false, "A188MunicipioDDD", A188MunicipioDDD);
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z186MunicipioCodigo", Z186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "Z187MunicipioNome", Z187MunicipioNome);
         GxWebStd.gx_hidden_field( context, "Z188MunicipioDDD", Z188MunicipioDDD);
         GxWebStd.gx_hidden_field( context, "Z189MunicipioUF", Z189MunicipioUF);
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
         setEventMetadata("VALID_MUNICIPIOCODIGO","""{"handler":"Valid_Municipiocodigo","iparms":[{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_MUNICIPIOCODIGO",""","oparms":[{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A188MunicipioDDD","fld":"MUNICIPIODDD","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z186MunicipioCodigo","type":"svchar"},{"av":"Z187MunicipioNome","type":"svchar"},{"av":"Z188MunicipioDDD","type":"svchar"},{"av":"Z189MunicipioUF","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         Z186MunicipioCodigo = "";
         Z187MunicipioNome = "";
         Z188MunicipioDDD = "";
         Z189MunicipioUF = "";
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
         A186MunicipioCodigo = "";
         A187MunicipioNome = "";
         A188MunicipioDDD = "";
         A189MunicipioUF = "";
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
         T000R4_A186MunicipioCodigo = new string[] {""} ;
         T000R4_n186MunicipioCodigo = new bool[] {false} ;
         T000R4_A187MunicipioNome = new string[] {""} ;
         T000R4_n187MunicipioNome = new bool[] {false} ;
         T000R4_A188MunicipioDDD = new string[] {""} ;
         T000R4_n188MunicipioDDD = new bool[] {false} ;
         T000R4_A189MunicipioUF = new string[] {""} ;
         T000R4_n189MunicipioUF = new bool[] {false} ;
         T000R5_A186MunicipioCodigo = new string[] {""} ;
         T000R5_n186MunicipioCodigo = new bool[] {false} ;
         T000R3_A186MunicipioCodigo = new string[] {""} ;
         T000R3_n186MunicipioCodigo = new bool[] {false} ;
         T000R3_A187MunicipioNome = new string[] {""} ;
         T000R3_n187MunicipioNome = new bool[] {false} ;
         T000R3_A188MunicipioDDD = new string[] {""} ;
         T000R3_n188MunicipioDDD = new bool[] {false} ;
         T000R3_A189MunicipioUF = new string[] {""} ;
         T000R3_n189MunicipioUF = new bool[] {false} ;
         sMode31 = "";
         T000R6_A186MunicipioCodigo = new string[] {""} ;
         T000R6_n186MunicipioCodigo = new bool[] {false} ;
         T000R7_A186MunicipioCodigo = new string[] {""} ;
         T000R7_n186MunicipioCodigo = new bool[] {false} ;
         T000R2_A186MunicipioCodigo = new string[] {""} ;
         T000R2_n186MunicipioCodigo = new bool[] {false} ;
         T000R2_A187MunicipioNome = new string[] {""} ;
         T000R2_n187MunicipioNome = new bool[] {false} ;
         T000R2_A188MunicipioDDD = new string[] {""} ;
         T000R2_n188MunicipioDDD = new bool[] {false} ;
         T000R2_A189MunicipioUF = new string[] {""} ;
         T000R2_n189MunicipioUF = new bool[] {false} ;
         T000R11_A978RepresentanteId = new int[1] ;
         T000R12_A249EmpresaId = new int[1] ;
         T000R13_A249EmpresaId = new int[1] ;
         T000R14_A168ClienteId = new int[1] ;
         T000R15_A168ClienteId = new int[1] ;
         T000R16_A186MunicipioCodigo = new string[] {""} ;
         T000R16_n186MunicipioCodigo = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ186MunicipioCodigo = "";
         ZZ187MunicipioNome = "";
         ZZ188MunicipioDDD = "";
         ZZ189MunicipioUF = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.municipio__default(),
            new Object[][] {
                new Object[] {
               T000R2_A186MunicipioCodigo, T000R2_A187MunicipioNome, T000R2_n187MunicipioNome, T000R2_A188MunicipioDDD, T000R2_n188MunicipioDDD, T000R2_A189MunicipioUF, T000R2_n189MunicipioUF
               }
               , new Object[] {
               T000R3_A186MunicipioCodigo, T000R3_A187MunicipioNome, T000R3_n187MunicipioNome, T000R3_A188MunicipioDDD, T000R3_n188MunicipioDDD, T000R3_A189MunicipioUF, T000R3_n189MunicipioUF
               }
               , new Object[] {
               T000R4_A186MunicipioCodigo, T000R4_A187MunicipioNome, T000R4_n187MunicipioNome, T000R4_A188MunicipioDDD, T000R4_n188MunicipioDDD, T000R4_A189MunicipioUF, T000R4_n189MunicipioUF
               }
               , new Object[] {
               T000R5_A186MunicipioCodigo
               }
               , new Object[] {
               T000R6_A186MunicipioCodigo
               }
               , new Object[] {
               T000R7_A186MunicipioCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000R11_A978RepresentanteId
               }
               , new Object[] {
               T000R12_A249EmpresaId
               }
               , new Object[] {
               T000R13_A249EmpresaId
               }
               , new Object[] {
               T000R14_A168ClienteId
               }
               , new Object[] {
               T000R15_A168ClienteId
               }
               , new Object[] {
               T000R16_A186MunicipioCodigo
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
      private short RcdFound31 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMunicipioCodigo_Enabled ;
      private int edtMunicipioNome_Enabled ;
      private int edtMunicipioDDD_Enabled ;
      private int edtMunicipioUF_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMunicipioCodigo_Internalname ;
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
      private string edtMunicipioCodigo_Jsonclick ;
      private string edtMunicipioNome_Internalname ;
      private string edtMunicipioNome_Jsonclick ;
      private string edtMunicipioDDD_Internalname ;
      private string edtMunicipioDDD_Jsonclick ;
      private string edtMunicipioUF_Internalname ;
      private string edtMunicipioUF_Jsonclick ;
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
      private string sMode31 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n187MunicipioNome ;
      private bool n188MunicipioDDD ;
      private bool n189MunicipioUF ;
      private bool n186MunicipioCodigo ;
      private string Z186MunicipioCodigo ;
      private string Z187MunicipioNome ;
      private string Z188MunicipioDDD ;
      private string Z189MunicipioUF ;
      private string A186MunicipioCodigo ;
      private string A187MunicipioNome ;
      private string A188MunicipioDDD ;
      private string A189MunicipioUF ;
      private string ZZ186MunicipioCodigo ;
      private string ZZ187MunicipioNome ;
      private string ZZ188MunicipioDDD ;
      private string ZZ189MunicipioUF ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000R4_A186MunicipioCodigo ;
      private bool[] T000R4_n186MunicipioCodigo ;
      private string[] T000R4_A187MunicipioNome ;
      private bool[] T000R4_n187MunicipioNome ;
      private string[] T000R4_A188MunicipioDDD ;
      private bool[] T000R4_n188MunicipioDDD ;
      private string[] T000R4_A189MunicipioUF ;
      private bool[] T000R4_n189MunicipioUF ;
      private string[] T000R5_A186MunicipioCodigo ;
      private bool[] T000R5_n186MunicipioCodigo ;
      private string[] T000R3_A186MunicipioCodigo ;
      private bool[] T000R3_n186MunicipioCodigo ;
      private string[] T000R3_A187MunicipioNome ;
      private bool[] T000R3_n187MunicipioNome ;
      private string[] T000R3_A188MunicipioDDD ;
      private bool[] T000R3_n188MunicipioDDD ;
      private string[] T000R3_A189MunicipioUF ;
      private bool[] T000R3_n189MunicipioUF ;
      private string[] T000R6_A186MunicipioCodigo ;
      private bool[] T000R6_n186MunicipioCodigo ;
      private string[] T000R7_A186MunicipioCodigo ;
      private bool[] T000R7_n186MunicipioCodigo ;
      private string[] T000R2_A186MunicipioCodigo ;
      private bool[] T000R2_n186MunicipioCodigo ;
      private string[] T000R2_A187MunicipioNome ;
      private bool[] T000R2_n187MunicipioNome ;
      private string[] T000R2_A188MunicipioDDD ;
      private bool[] T000R2_n188MunicipioDDD ;
      private string[] T000R2_A189MunicipioUF ;
      private bool[] T000R2_n189MunicipioUF ;
      private int[] T000R11_A978RepresentanteId ;
      private int[] T000R12_A249EmpresaId ;
      private int[] T000R13_A249EmpresaId ;
      private int[] T000R14_A168ClienteId ;
      private int[] T000R15_A168ClienteId ;
      private string[] T000R16_A186MunicipioCodigo ;
      private bool[] T000R16_n186MunicipioCodigo ;
   }

   public class municipio__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000R2;
          prmT000R2 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R3;
          prmT000R3 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R4;
          prmT000R4 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R5;
          prmT000R5 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R6;
          prmT000R6 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R7;
          prmT000R7 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R8;
          prmT000R8 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("MunicipioNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("MunicipioDDD",GXType.VarChar,3,0){Nullable=true} ,
          new ParDef("MunicipioUF",GXType.VarChar,10,0){Nullable=true}
          };
          Object[] prmT000R9;
          prmT000R9 = new Object[] {
          new ParDef("MunicipioNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("MunicipioDDD",GXType.VarChar,3,0){Nullable=true} ,
          new ParDef("MunicipioUF",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R10;
          prmT000R10 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R11;
          prmT000R11 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R12;
          prmT000R12 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R13;
          prmT000R13 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R14;
          prmT000R14 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R15;
          prmT000R15 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000R16;
          prmT000R16 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000R2", "SELECT MunicipioCodigo, MunicipioNome, MunicipioDDD, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo  FOR UPDATE OF Municipio NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000R2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R3", "SELECT MunicipioCodigo, MunicipioNome, MunicipioDDD, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R4", "SELECT TM1.MunicipioCodigo, TM1.MunicipioNome, TM1.MunicipioDDD, TM1.MunicipioUF FROM Municipio TM1 WHERE TM1.MunicipioCodigo = ( :MunicipioCodigo) ORDER BY TM1.MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R5", "SELECT MunicipioCodigo FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R6", "SELECT MunicipioCodigo FROM Municipio WHERE ( MunicipioCodigo > ( :MunicipioCodigo)) ORDER BY MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R7", "SELECT MunicipioCodigo FROM Municipio WHERE ( MunicipioCodigo < ( :MunicipioCodigo)) ORDER BY MunicipioCodigo DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R8", "SAVEPOINT gxupdate;INSERT INTO Municipio(MunicipioCodigo, MunicipioNome, MunicipioDDD, MunicipioUF) VALUES(:MunicipioCodigo, :MunicipioNome, :MunicipioDDD, :MunicipioUF);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000R8)
             ,new CursorDef("T000R9", "SAVEPOINT gxupdate;UPDATE Municipio SET MunicipioNome=:MunicipioNome, MunicipioDDD=:MunicipioDDD, MunicipioUF=:MunicipioUF  WHERE MunicipioCodigo = :MunicipioCodigo;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R9)
             ,new CursorDef("T000R10", "SAVEPOINT gxupdate;DELETE FROM Municipio  WHERE MunicipioCodigo = :MunicipioCodigo;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R10)
             ,new CursorDef("T000R11", "SELECT RepresentanteId FROM Representante WHERE RepresentanteMunicipio = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R12", "SELECT EmpresaId FROM Empresa WHERE EmpresaRepresentanteMunicipio = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R13", "SELECT EmpresaId FROM Empresa WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R14", "SELECT ClienteId FROM Cliente WHERE ResponsavelMunicipio = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R15", "SELECT ClienteId FROM Cliente WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R16", "SELECT MunicipioCodigo FROM Municipio ORDER BY MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R16,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
