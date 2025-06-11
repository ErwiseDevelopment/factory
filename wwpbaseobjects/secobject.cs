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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secobject : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A128SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A128SecFunctionalityId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsecobject_functionalities") == 0 )
         {
            gxnrGridsecobject_functionalities_newrow_invoke( ) ;
            return  ;
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
         Form.Meta.addItem("description", "Sec Object", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridsecobject_functionalities_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsecobject_functionalities_newrow( ) ;
         /* End function gxnrGridsecobject_functionalities_newrow_invoke */
      }

      public secobject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secobject( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Sec Object", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecObject.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/SecObject.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecObjectName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecObjectName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecObjectName_Internalname, A132SecObjectName, StringUtil.RTrim( context.localUtil.Format( A132SecObjectName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecObjectName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecObjectName_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFunctionalitiestable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlefunctionalities_Internalname, "Functionalities", "", "", lblTitlefunctionalities_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridsecobject_functionalities( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecObject.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridsecobject_functionalities( )
      {
         /*  Grid Control  */
         StartGridControl43( ) ;
         nGXsfl_43_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount20 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_20 = 1;
               ScanStart0G20( ) ;
               while ( RcdFound20 != 0 )
               {
                  init_level_properties20( ) ;
                  getByPrimaryKey0G20( ) ;
                  AddRow0G20( ) ;
                  ScanNext0G20( ) ;
               }
               ScanEnd0G20( ) ;
               nBlankRcdCount20 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0G20( ) ;
            standaloneModal0G20( ) ;
            sMode20 = Gx_mode;
            while ( nGXsfl_43_idx < nRC_GXsfl_43 )
            {
               bGXsfl_43_Refreshing = true;
               ReadRow0G20( ) ;
               edtSecFunctionalityId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtSecFunctionalityDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               if ( ( nRcdExists_20 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0G20( ) ;
               }
               SendRow0G20( ) ;
               bGXsfl_43_Refreshing = false;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount20 = 5;
            nRcdExists_20 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0G20( ) ;
               while ( RcdFound20 != 0 )
               {
                  sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4320( ) ;
                  init_level_properties20( ) ;
                  standaloneNotModal0G20( ) ;
                  getByPrimaryKey0G20( ) ;
                  standaloneModal0G20( ) ;
                  AddRow0G20( ) ;
                  ScanNext0G20( ) ;
               }
               ScanEnd0G20( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode20 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
         SubsflControlProps_4320( ) ;
         InitAll0G20( ) ;
         init_level_properties20( ) ;
         nRcdExists_20 = 0;
         nIsMod_20 = 0;
         nRcdDeleted_20 = 0;
         nBlankRcdCount20 = (short)(nBlankRcdUsr20+nBlankRcdCount20);
         fRowAdded = 0;
         while ( nBlankRcdCount20 > 0 )
         {
            standaloneNotModal0G20( ) ;
            standaloneModal0G20( ) ;
            AddRow0G20( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtSecFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount20 = (short)(nBlankRcdCount20-1);
         }
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridsecobject_functionalitiesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsecobject_functionalities", Gridsecobject_functionalitiesContainer, subGridsecobject_functionalities_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsecobject_functionalitiesContainerData", Gridsecobject_functionalitiesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsecobject_functionalitiesContainerData"+"V", Gridsecobject_functionalitiesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsecobject_functionalitiesContainerData"+"V"+"\" value='"+Gridsecobject_functionalitiesContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z132SecObjectName = cgiGet( "Z132SecObjectName");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A132SecObjectName = cgiGet( edtSecObjectName_Internalname);
            AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A132SecObjectName = GetPar( "SecObjectName");
               AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll0G19( ) ;
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
         DisableAttributes0G19( ) ;
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

      protected void CONFIRM_0G20( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow0G20( ) ;
            if ( ( nRcdExists_20 != 0 ) || ( nIsMod_20 != 0 ) )
            {
               GetKey0G20( ) ;
               if ( ( nRcdExists_20 == 0 ) && ( nRcdDeleted_20 == 0 ) )
               {
                  if ( RcdFound20 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0G20( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0G20( ) ;
                        CloseExtendedTableCursors0G20( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtSecFunctionalityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound20 != 0 )
                  {
                     if ( nRcdDeleted_20 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0G20( ) ;
                        Load0G20( ) ;
                        BeforeValidate0G20( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0G20( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_20 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0G20( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0G20( ) ;
                              CloseExtendedTableCursors0G20( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_20 == 0 )
                     {
                        GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSecFunctionalityId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", ""))) ;
            ChangePostValue( edtSecFunctionalityDescription_Internalname, A135SecFunctionalityDescription) ;
            ChangePostValue( "ZT_"+"Z128SecFunctionalityId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128SecFunctionalityId), 10, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_20_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_20), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_20_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_20), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_20_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_20), 4, 0, ",", ""))) ;
            if ( nIsMod_20 != 0 )
            {
               ChangePostValue( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G19( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -1 )
         {
            Z132SecObjectName = A132SecObjectName;
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

      protected void Load0G19( )
      {
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound19 = 1;
            ZM0G19( -1) ;
         }
         pr_default.close(5);
         OnLoadActions0G19( ) ;
      }

      protected void OnLoadActions0G19( )
      {
      }

      protected void CheckExtendedTable0G19( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0G19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G19( )
      {
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0G19( 1) ;
            RcdFound19 = 1;
            A132SecObjectName = T000G6_A132SecObjectName[0];
            AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
            Z132SecObjectName = A132SecObjectName;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0G19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0G19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G19( ) ;
         if ( RcdFound19 == 0 )
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
         RcdFound19 = 0;
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000G9_A132SecObjectName[0], A132SecObjectName) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000G9_A132SecObjectName[0], A132SecObjectName) > 0 ) ) )
            {
               A132SecObjectName = T000G9_A132SecObjectName[0];
               AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
               RcdFound19 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000G10 */
         pr_default.execute(8, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000G10_A132SecObjectName[0], A132SecObjectName) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000G10_A132SecObjectName[0], A132SecObjectName) < 0 ) ) )
            {
               A132SecObjectName = T000G10_A132SecObjectName[0];
               AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
               RcdFound19 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
               {
                  A132SecObjectName = Z132SecObjectName;
                  AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECOBJECTNAME");
                  AnyError = 1;
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G19( ) ;
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecObjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECOBJECTNAME");
                     AnyError = 1;
                     GX_FocusControl = edtSecObjectName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecObjectName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G19( ) ;
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
         if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
         {
            A132SecObjectName = Z132SecObjectName;
            AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECOBJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecObjectName_Internalname;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECOBJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtSecObjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd0G19( ) ;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound19 != 0 )
            {
               ScanNext0G19( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd0G19( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G5 */
            pr_default.execute(3, new Object[] {A132SecObjectName});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecObject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecObject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G19( )
      {
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G19( 0) ;
            CheckOptimisticConcurrency0G19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G11 */
                     pr_default.execute(9, new Object[] {A132SecObjectName});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecObject");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel0G19( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0G0( ) ;
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
            else
            {
               Load0G19( ) ;
            }
            EndLevel0G19( ) ;
         }
         CloseExtendedTableCursors0G19( ) ;
      }

      protected void Update0G19( )
      {
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table SecObject */
                     DeferredUpdate0G19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0G19( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0G0( ) ;
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
            EndLevel0G19( ) ;
         }
         CloseExtendedTableCursors0G19( ) ;
      }

      protected void DeferredUpdate0G19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G19( ) ;
            AfterConfirm0G19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G19( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0G20( ) ;
                  while ( RcdFound20 != 0 )
                  {
                     getByPrimaryKey0G20( ) ;
                     Delete0G20( ) ;
                     ScanNext0G20( ) ;
                  }
                  ScanEnd0G20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G12 */
                     pr_default.execute(10, new Object[] {A132SecObjectName});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecObject");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound19 == 0 )
                           {
                              InitAll0G19( ) ;
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
                           ResetCaption0G0( ) ;
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
         }
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0G20( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow0G20( ) ;
            if ( ( nRcdExists_20 != 0 ) || ( nIsMod_20 != 0 ) )
            {
               standaloneNotModal0G20( ) ;
               GetKey0G20( ) ;
               if ( ( nRcdExists_20 == 0 ) && ( nRcdDeleted_20 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0G20( ) ;
               }
               else
               {
                  if ( RcdFound20 != 0 )
                  {
                     if ( ( nRcdDeleted_20 != 0 ) && ( nRcdExists_20 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0G20( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_20 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0G20( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_20 == 0 )
                     {
                        GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSecFunctionalityId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", ""))) ;
            ChangePostValue( edtSecFunctionalityDescription_Internalname, A135SecFunctionalityDescription) ;
            ChangePostValue( "ZT_"+"Z128SecFunctionalityId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128SecFunctionalityId), 10, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_20_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_20), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_20_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_20), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_20_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_20), 4, 0, ",", ""))) ;
            if ( nIsMod_20 != 0 )
            {
               ChangePostValue( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0G20( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_20 = 0;
         nIsMod_20 = 0;
         nRcdDeleted_20 = 0;
      }

      protected void ProcessLevel0G19( )
      {
         /* Save parent mode. */
         sMode19 = Gx_mode;
         ProcessNestedLevel0G20( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0G19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.secobject",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.secobject",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G19( )
      {
         /* Using cursor T000G13 */
         pr_default.execute(11);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound19 = 1;
            A132SecObjectName = T000G13_A132SecObjectName[0];
            AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G19( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound19 = 1;
            A132SecObjectName = T000G13_A132SecObjectName[0];
            AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
         }
      }

      protected void ScanEnd0G19( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0G19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G19( )
      {
         edtSecObjectName_Enabled = 0;
         AssignProp("", false, edtSecObjectName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecObjectName_Enabled), 5, 0), true);
      }

      protected void ZM0G20( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -2 )
         {
            Z132SecObjectName = A132SecObjectName;
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
         }
      }

      protected void standaloneNotModal0G20( )
      {
      }

      protected void standaloneModal0G20( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSecFunctionalityId_Enabled = 0;
            AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         }
         else
         {
            edtSecFunctionalityId_Enabled = 1;
            AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         }
      }

      protected void Load0G20( )
      {
         /* Using cursor T000G14 */
         pr_default.execute(12, new Object[] {A132SecObjectName, A128SecFunctionalityId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound20 = 1;
            A135SecFunctionalityDescription = T000G14_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = T000G14_n135SecFunctionalityDescription[0];
            ZM0G20( -2) ;
         }
         pr_default.close(12);
         OnLoadActions0G20( ) ;
      }

      protected void OnLoadActions0G20( )
      {
      }

      protected void CheckExtendedTable0G20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal0G20( ) ;
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A135SecFunctionalityDescription = T000G4_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000G4_n135SecFunctionalityDescription[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0G20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0G20( )
      {
      }

      protected void gxLoad_3( long A128SecFunctionalityId )
      {
         /* Using cursor T000G15 */
         pr_default.execute(13, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A135SecFunctionalityDescription = T000G15_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000G15_n135SecFunctionalityDescription[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A135SecFunctionalityDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void GetKey0G20( )
      {
         /* Using cursor T000G16 */
         pr_default.execute(14, new Object[] {A132SecObjectName, A128SecFunctionalityId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0G20( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A132SecObjectName, A128SecFunctionalityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G20( 2) ;
            RcdFound20 = 1;
            InitializeNonKey0G20( ) ;
            A128SecFunctionalityId = T000G3_A128SecFunctionalityId[0];
            Z132SecObjectName = A132SecObjectName;
            Z128SecFunctionalityId = A128SecFunctionalityId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0G20( ) ;
            Load0G20( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0G20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0G20( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0G20( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0G20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A132SecObjectName, A128SecFunctionalityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecObjectFunctionalities"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecObjectFunctionalities"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G20( )
      {
         BeforeValidate0G20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G20( 0) ;
            CheckOptimisticConcurrency0G20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G17 */
                     pr_default.execute(15, new Object[] {A132SecObjectName, A128SecFunctionalityId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load0G20( ) ;
            }
            EndLevel0G20( ) ;
         }
         CloseExtendedTableCursors0G20( ) ;
      }

      protected void Update0G20( )
      {
         BeforeValidate0G20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G20( ) ;
         }
         if ( ( nIsMod_20 != 0 ) || ( nIsDirty_20 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0G20( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0G20( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0G20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table SecObjectFunctionalities */
                        DeferredUpdate0G20( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0G20( ) ;
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
               EndLevel0G20( ) ;
            }
         }
         CloseExtendedTableCursors0G20( ) ;
      }

      protected void DeferredUpdate0G20( )
      {
      }

      protected void Delete0G20( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G20( ) ;
            AfterConfirm0G20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G18 */
                  pr_default.execute(16, new Object[] {A132SecObjectName, A128SecFunctionalityId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G20( )
      {
         standaloneModal0G20( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000G19 */
            pr_default.execute(17, new Object[] {A128SecFunctionalityId});
            A135SecFunctionalityDescription = T000G19_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = T000G19_n135SecFunctionalityDescription[0];
            pr_default.close(17);
         }
      }

      protected void EndLevel0G20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G20( )
      {
         /* Scan By routine */
         /* Using cursor T000G20 */
         pr_default.execute(18, new Object[] {A132SecObjectName});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound20 = 1;
            A128SecFunctionalityId = T000G20_A128SecFunctionalityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G20( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound20 = 1;
            A128SecFunctionalityId = T000G20_A128SecFunctionalityId[0];
         }
      }

      protected void ScanEnd0G20( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0G20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G20( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtSecFunctionalityDescription_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void send_integrity_lvl_hashes0G20( )
      {
      }

      protected void send_integrity_lvl_hashes0G19( )
      {
      }

      protected void SubsflControlProps_4320( )
      {
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_43_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_4320( )
      {
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_43_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_fel_idx;
      }

      protected void AddRow0G20( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4320( ) ;
         SendRow0G20( ) ;
      }

      protected void SendRow0G20( )
      {
         Gridsecobject_functionalitiesRow = GXWebRow.GetNew(context);
         if ( subGridsecobject_functionalities_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
            {
               subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Odd";
            }
         }
         else if ( subGridsecobject_functionalities_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 0;
            subGridsecobject_functionalities_Backcolor = subGridsecobject_functionalities_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
            {
               subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Uniform";
            }
         }
         else if ( subGridsecobject_functionalities_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
            {
               subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Odd";
            }
            subGridsecobject_functionalities_Backcolor = (int)(0x0);
         }
         else if ( subGridsecobject_functionalities_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsecobject_functionalities_Backstyle = 1;
            if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
            {
               subGridsecobject_functionalities_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
               {
                  subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Even";
               }
            }
            else
            {
               subGridsecobject_functionalities_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsecobject_functionalities_Class, "") != 0 )
               {
                  subGridsecobject_functionalities_Linesclass = subGridsecobject_functionalities_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridsecobject_functionalitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSecFunctionalityId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridsecobject_functionalitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A135SecFunctionalityDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSecFunctionalityDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridsecobject_functionalitiesRow);
         send_integrity_lvl_hashes0G20( ) ;
         GXCCtl = "Z128SecFunctionalityId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128SecFunctionalityId), 10, 0, ",", "")));
         GXCCtl = "nRcdDeleted_20_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_20), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_20_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_20), 4, 0, ",", "")));
         GXCCtl = "nIsMod_20_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_20), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridsecobject_functionalitiesContainer.AddRow(Gridsecobject_functionalitiesRow);
      }

      protected void ReadRow0G20( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4320( ) ;
         edtSecFunctionalityId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYID_"+sGXsfl_43_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtSecFunctionalityDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_43_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "SECFUNCTIONALITYID_" + sGXsfl_43_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            wbErr = true;
            A128SecFunctionalityId = 0;
         }
         else
         {
            A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
         n135SecFunctionalityDescription = false;
         GXCCtl = "Z128SecFunctionalityId_" + sGXsfl_43_idx;
         Z128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_20_" + sGXsfl_43_idx;
         nRcdDeleted_20 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_20_" + sGXsfl_43_idx;
         nRcdExists_20 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_20_" + sGXsfl_43_idx;
         nIsMod_20 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtSecFunctionalityId_Enabled = edtSecFunctionalityId_Enabled;
      }

      protected void ConfirmValues0G0( )
      {
         nGXsfl_43_idx = 0;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4320( ) ;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_4320( ) ;
            ChangePostValue( "Z128SecFunctionalityId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z128SecFunctionalityId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z128SecFunctionalityId_"+sGXsfl_43_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secobject") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z132SecObjectName", Z132SecObjectName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_43_idx), 8, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.secobject")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecObject" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sec Object" ;
      }

      protected void InitializeNonKey0G19( )
      {
      }

      protected void InitAll0G19( )
      {
         A132SecObjectName = "";
         AssignAttri("", false, "A132SecObjectName", A132SecObjectName);
         InitializeNonKey0G19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0G20( )
      {
         A135SecFunctionalityDescription = "";
         n135SecFunctionalityDescription = false;
      }

      protected void InitAll0G20( )
      {
         A128SecFunctionalityId = 0;
         InitializeNonKey0G20( ) ;
      }

      protected void StandaloneModalInsert0G20( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019124636", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secobject.js", "?202561019124637", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties20( )
      {
         edtSecFunctionalityId_Enabled = defedtSecFunctionalityId_Enabled;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void StartGridControl43( )
      {
         Gridsecobject_functionalitiesContainer.AddObjectProperty("GridName", "Gridsecobject_functionalities");
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Header", subGridsecobject_functionalities_Header);
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Class", "Grid");
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Backcolorstyle), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("CmpContext", "");
         Gridsecobject_functionalitiesContainer.AddObjectProperty("InMasterPage", "false");
         Gridsecobject_functionalitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", ""))));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityId_Enabled), 5, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddColumnProperties(Gridsecobject_functionalitiesColumn);
         Gridsecobject_functionalitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135SecFunctionalityDescription));
         Gridsecobject_functionalitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddColumnProperties(Gridsecobject_functionalitiesColumn);
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Selectedindex), 4, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Allowselection), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Selectioncolor), 9, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Allowhovering), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Hoveringcolor), 9, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Allowcollapsing), 1, 0, ".", "")));
         Gridsecobject_functionalitiesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecobject_functionalities_Collapsed), 1, 0, ".", "")));
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
         edtSecObjectName_Internalname = "SECOBJECTNAME";
         lblTitlefunctionalities_Internalname = "TITLEFUNCTIONALITIES";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         divFunctionalitiestable_Internalname = "FUNCTIONALITIESTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridsecobject_functionalities_Internalname = "GRIDSECOBJECT_FUNCTIONALITIES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsecobject_functionalities_Allowcollapsing = 0;
         subGridsecobject_functionalities_Allowselection = 0;
         subGridsecobject_functionalities_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Sec Object";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         subGridsecobject_functionalities_Class = "Grid";
         subGridsecobject_functionalities_Backcolorstyle = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSecObjectName_Jsonclick = "";
         edtSecObjectName_Enabled = 1;
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

      protected void gxnrGridsecobject_functionalities_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4320( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0G20( ) ;
            standaloneModal0G20( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0G20( ) ;
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_4320( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsecobject_functionalitiesContainer)) ;
         /* End function gxnrGridsecobject_functionalities_newrow */
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
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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

      public void Valid_Secobjectname( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z132SecObjectName", Z132SecObjectName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Secfunctionalityid( )
      {
         n135SecFunctionalityDescription = false;
         /* Using cursor T000G19 */
         pr_default.execute(17, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
         }
         A135SecFunctionalityDescription = T000G19_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000G19_n135SecFunctionalityDescription[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_SECOBJECTNAME","""{"handler":"Valid_Secobjectname","iparms":[{"av":"A132SecObjectName","fld":"SECOBJECTNAME","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_SECOBJECTNAME",""","oparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z132SecObjectName","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A135SecFunctionalityDescription","fld":"SECFUNCTIONALITYDESCRIPTION","type":"svchar"}]""");
         setEventMetadata("VALID_SECFUNCTIONALITYID",""","oparms":[{"av":"A135SecFunctionalityDescription","fld":"SECFUNCTIONALITYDESCRIPTION","type":"svchar"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secfunctionalitydescription","iparms":[]}""");
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
         pr_default.close(17);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z132SecObjectName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A132SecObjectName = "";
         lblTitlefunctionalities_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridsecobject_functionalitiesContainer = new GXWebGrid( context);
         sMode20 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A135SecFunctionalityDescription = "";
         T000G7_A132SecObjectName = new string[] {""} ;
         T000G8_A132SecObjectName = new string[] {""} ;
         T000G6_A132SecObjectName = new string[] {""} ;
         sMode19 = "";
         T000G9_A132SecObjectName = new string[] {""} ;
         T000G10_A132SecObjectName = new string[] {""} ;
         T000G5_A132SecObjectName = new string[] {""} ;
         T000G13_A132SecObjectName = new string[] {""} ;
         Z135SecFunctionalityDescription = "";
         T000G14_A132SecObjectName = new string[] {""} ;
         T000G14_A135SecFunctionalityDescription = new string[] {""} ;
         T000G14_n135SecFunctionalityDescription = new bool[] {false} ;
         T000G14_A128SecFunctionalityId = new long[1] ;
         T000G4_A135SecFunctionalityDescription = new string[] {""} ;
         T000G4_n135SecFunctionalityDescription = new bool[] {false} ;
         T000G15_A135SecFunctionalityDescription = new string[] {""} ;
         T000G15_n135SecFunctionalityDescription = new bool[] {false} ;
         T000G16_A132SecObjectName = new string[] {""} ;
         T000G16_A128SecFunctionalityId = new long[1] ;
         T000G3_A132SecObjectName = new string[] {""} ;
         T000G3_A128SecFunctionalityId = new long[1] ;
         T000G2_A132SecObjectName = new string[] {""} ;
         T000G2_A128SecFunctionalityId = new long[1] ;
         T000G19_A135SecFunctionalityDescription = new string[] {""} ;
         T000G19_n135SecFunctionalityDescription = new bool[] {false} ;
         T000G20_A132SecObjectName = new string[] {""} ;
         T000G20_A128SecFunctionalityId = new long[1] ;
         Gridsecobject_functionalitiesRow = new GXWebRow();
         subGridsecobject_functionalities_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridsecobject_functionalitiesColumn = new GXWebColumn();
         ZZ132SecObjectName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secobject__default(),
            new Object[][] {
                new Object[] {
               T000G2_A132SecObjectName, T000G2_A128SecFunctionalityId
               }
               , new Object[] {
               T000G3_A132SecObjectName, T000G3_A128SecFunctionalityId
               }
               , new Object[] {
               T000G4_A135SecFunctionalityDescription, T000G4_n135SecFunctionalityDescription
               }
               , new Object[] {
               T000G5_A132SecObjectName
               }
               , new Object[] {
               T000G6_A132SecObjectName
               }
               , new Object[] {
               T000G7_A132SecObjectName
               }
               , new Object[] {
               T000G8_A132SecObjectName
               }
               , new Object[] {
               T000G9_A132SecObjectName
               }
               , new Object[] {
               T000G10_A132SecObjectName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G13_A132SecObjectName
               }
               , new Object[] {
               T000G14_A132SecObjectName, T000G14_A135SecFunctionalityDescription, T000G14_n135SecFunctionalityDescription, T000G14_A128SecFunctionalityId
               }
               , new Object[] {
               T000G15_A135SecFunctionalityDescription, T000G15_n135SecFunctionalityDescription
               }
               , new Object[] {
               T000G16_A132SecObjectName, T000G16_A128SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G19_A135SecFunctionalityDescription, T000G19_n135SecFunctionalityDescription
               }
               , new Object[] {
               T000G20_A132SecObjectName, T000G20_A128SecFunctionalityId
               }
            }
         );
      }

      private short nRcdDeleted_20 ;
      private short nRcdExists_20 ;
      private short nIsMod_20 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount20 ;
      private short RcdFound20 ;
      private short nBlankRcdUsr20 ;
      private short RcdFound19 ;
      private short Gx_BScreen ;
      private short nIsDirty_20 ;
      private short subGridsecobject_functionalities_Backcolorstyle ;
      private short subGridsecobject_functionalities_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridsecobject_functionalities_Allowselection ;
      private short subGridsecobject_functionalities_Allowhovering ;
      private short subGridsecobject_functionalities_Allowcollapsing ;
      private short subGridsecobject_functionalities_Collapsed ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSecObjectName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int fRowAdded ;
      private int subGridsecobject_functionalities_Backcolor ;
      private int subGridsecobject_functionalities_Allbackcolor ;
      private int defedtSecFunctionalityId_Enabled ;
      private int idxLst ;
      private int subGridsecobject_functionalities_Selectedindex ;
      private int subGridsecobject_functionalities_Selectioncolor ;
      private int subGridsecobject_functionalities_Hoveringcolor ;
      private long Z128SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long GRIDSECOBJECT_FUNCTIONALITIES_nFirstRecordOnPage ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecObjectName_Internalname ;
      private string sGXsfl_43_idx="0001" ;
      private string Gx_mode ;
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
      private string edtSecObjectName_Jsonclick ;
      private string divFunctionalitiestable_Internalname ;
      private string lblTitlefunctionalities_Internalname ;
      private string lblTitlefunctionalities_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode20 ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string sStyleString ;
      private string subGridsecobject_functionalities_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode19 ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGridsecobject_functionalities_Class ;
      private string subGridsecobject_functionalities_Linesclass ;
      private string ROClassString ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridsecobject_functionalities_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool n135SecFunctionalityDescription ;
      private string Z132SecObjectName ;
      private string A132SecObjectName ;
      private string A135SecFunctionalityDescription ;
      private string Z135SecFunctionalityDescription ;
      private string ZZ132SecObjectName ;
      private GXWebGrid Gridsecobject_functionalitiesContainer ;
      private GXWebRow Gridsecobject_functionalitiesRow ;
      private GXWebColumn Gridsecobject_functionalitiesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000G7_A132SecObjectName ;
      private string[] T000G8_A132SecObjectName ;
      private string[] T000G6_A132SecObjectName ;
      private string[] T000G9_A132SecObjectName ;
      private string[] T000G10_A132SecObjectName ;
      private string[] T000G5_A132SecObjectName ;
      private string[] T000G13_A132SecObjectName ;
      private string[] T000G14_A132SecObjectName ;
      private string[] T000G14_A135SecFunctionalityDescription ;
      private bool[] T000G14_n135SecFunctionalityDescription ;
      private long[] T000G14_A128SecFunctionalityId ;
      private string[] T000G4_A135SecFunctionalityDescription ;
      private bool[] T000G4_n135SecFunctionalityDescription ;
      private string[] T000G15_A135SecFunctionalityDescription ;
      private bool[] T000G15_n135SecFunctionalityDescription ;
      private string[] T000G16_A132SecObjectName ;
      private long[] T000G16_A128SecFunctionalityId ;
      private string[] T000G3_A132SecObjectName ;
      private long[] T000G3_A128SecFunctionalityId ;
      private string[] T000G2_A132SecObjectName ;
      private long[] T000G2_A128SecFunctionalityId ;
      private string[] T000G19_A135SecFunctionalityDescription ;
      private bool[] T000G19_n135SecFunctionalityDescription ;
      private string[] T000G20_A132SecObjectName ;
      private long[] T000G20_A128SecFunctionalityId ;
   }

   public class secobject__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000G2;
          prmT000G2 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G3;
          prmT000G3 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G4;
          prmT000G4 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G5;
          prmT000G5 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G6;
          prmT000G6 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G7;
          prmT000G7 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G8;
          prmT000G8 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G9;
          prmT000G9 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G10;
          prmT000G10 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G11;
          prmT000G11 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G12;
          prmT000G12 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmT000G13;
          prmT000G13 = new Object[] {
          };
          Object[] prmT000G14;
          prmT000G14 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G15;
          prmT000G15 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G16;
          prmT000G16 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G17;
          prmT000G17 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G18;
          prmT000G18 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G19;
          prmT000G19 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000G20;
          prmT000G20 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000G2", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId  FOR UPDATE OF SecObjectFunctionalities NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G3", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G4", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G5", "SELECT SecObjectName FROM SecObject WHERE SecObjectName = :SecObjectName  FOR UPDATE OF SecObject NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G6", "SELECT SecObjectName FROM SecObject WHERE SecObjectName = :SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G7", "SELECT TM1.SecObjectName FROM SecObject TM1 WHERE TM1.SecObjectName = ( :SecObjectName) ORDER BY TM1.SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G8", "SELECT SecObjectName FROM SecObject WHERE SecObjectName = :SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G9", "SELECT SecObjectName FROM SecObject WHERE ( SecObjectName > ( :SecObjectName)) ORDER BY SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G10", "SELECT SecObjectName FROM SecObject WHERE ( SecObjectName < ( :SecObjectName)) ORDER BY SecObjectName DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G11", "SAVEPOINT gxupdate;INSERT INTO SecObject(SecObjectName) VALUES(:SecObjectName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000G11)
             ,new CursorDef("T000G12", "SAVEPOINT gxupdate;DELETE FROM SecObject  WHERE SecObjectName = :SecObjectName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G12)
             ,new CursorDef("T000G13", "SELECT SecObjectName FROM SecObject ORDER BY SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G14", "SELECT T1.SecObjectName, T2.SecFunctionalityDescription, T1.SecFunctionalityId FROM (SecObjectFunctionalities T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) WHERE T1.SecObjectName = ( :SecObjectName) and T1.SecFunctionalityId = :SecFunctionalityId ORDER BY T1.SecObjectName, T1.SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G15", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G16", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G17", "SAVEPOINT gxupdate;INSERT INTO SecObjectFunctionalities(SecObjectName, SecFunctionalityId) VALUES(:SecObjectName, :SecFunctionalityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000G17)
             ,new CursorDef("T000G18", "SAVEPOINT gxupdate;DELETE FROM SecObjectFunctionalities  WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G18)
             ,new CursorDef("T000G19", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G20", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = ( :SecObjectName) ORDER BY SecObjectName, SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G20,11, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
