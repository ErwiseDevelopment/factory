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
   public class clientenotas : GXDataArea
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
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A168ClienteId) ;
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
         Form.Meta.addItem("description", "Cliente Notas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientenotas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientenotas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Cliente Notas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ClienteNotas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ClienteNotas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteCountNotas_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCountNotas_F_Internalname, "Count Notas_F", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteCountNotas_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A886ClienteCountNotas_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtClienteCountNotas_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A886ClienteCountNotas_F), "ZZZ9") : context.localUtil.Format( (decimal)(A886ClienteCountNotas_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCountNotas_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCountNotas_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClienteNotas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteNotas.htm");
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
            Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A169ClienteDocumento = cgiGet( "CLIENTEDOCUMENTO");
            n169ClienteDocumento = false;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A168ClienteId = 0;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            }
            else
            {
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            }
            A886ClienteCountNotas_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteCountNotas_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n886ClienteCountNotas_F = false;
            AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
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
               A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
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
               InitAll2R28( ) ;
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
         DisableAttributes2R28( ) ;
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

      protected void ResetCaption2R0( )
      {
      }

      protected void ZM2R28( short GX_JID )
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
            Z168ClienteId = A168ClienteId;
            Z886ClienteCountNotas_F = A886ClienteCountNotas_F;
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

      protected void Load2R28( )
      {
         /* Using cursor T002R7 */
         pr_default.execute(3, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
            A886ClienteCountNotas_F = T002R7_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = T002R7_n886ClienteCountNotas_F[0];
            AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
            ZM2R28( -1) ;
         }
         pr_default.close(3);
         OnLoadActions2R28( ) ;
      }

      protected void OnLoadActions2R28( )
      {
      }

      protected void CheckExtendedTable2R28( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002R5 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A886ClienteCountNotas_F = T002R5_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = T002R5_n886ClienteCountNotas_F[0];
            AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
         }
         else
         {
            A886ClienteCountNotas_F = 0;
            n886ClienteCountNotas_F = false;
            AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2R28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A168ClienteId )
      {
         /* Using cursor T002R9 */
         pr_default.execute(4, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A886ClienteCountNotas_F = T002R9_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = T002R9_n886ClienteCountNotas_F[0];
            AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
         }
         else
         {
            A886ClienteCountNotas_F = 0;
            n886ClienteCountNotas_F = false;
            AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A886ClienteCountNotas_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey2R28( )
      {
         /* Using cursor T002R10 */
         pr_default.execute(5, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002R3 */
         pr_default.execute(1, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2R28( 1) ;
            RcdFound28 = 1;
            A168ClienteId = T002R3_A168ClienteId[0];
            n168ClienteId = T002R3_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            Z168ClienteId = A168ClienteId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2R28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey2R28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey2R28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2R28( ) ;
         if ( RcdFound28 == 0 )
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
         RcdFound28 = 0;
         /* Using cursor T002R11 */
         pr_default.execute(6, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002R11_A168ClienteId[0] < A168ClienteId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002R11_A168ClienteId[0] > A168ClienteId ) ) )
            {
               A168ClienteId = T002R11_A168ClienteId[0];
               n168ClienteId = T002R11_n168ClienteId[0];
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T002R12 */
         pr_default.execute(7, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002R12_A168ClienteId[0] > A168ClienteId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002R12_A168ClienteId[0] < A168ClienteId ) ) )
            {
               A168ClienteId = T002R12_A168ClienteId[0];
               n168ClienteId = T002R12_n168ClienteId[0];
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2R28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2R28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A168ClienteId != Z168ClienteId )
               {
                  A168ClienteId = Z168ClienteId;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2R28( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A168ClienteId != Z168ClienteId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2R28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2R28( ) ;
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
         if ( A168ClienteId != Z168ClienteId )
         {
            A168ClienteId = Z168ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
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
         ScanStart2R28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd2R28( ) ;
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
         if ( RcdFound28 == 0 )
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
         if ( RcdFound28 == 0 )
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
         ScanStart2R28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound28 != 0 )
            {
               ScanNext2R28( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd2R28( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2R28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002R2 */
            pr_default.execute(0, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2R28( )
      {
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2R28( 0) ;
            CheckOptimisticConcurrency2R28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2R28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2R28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002R13 */
                     pr_default.execute(8);
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002R14 */
                     pr_default.execute(9);
                     A168ClienteId = T002R14_A168ClienteId[0];
                     n168ClienteId = T002R14_n168ClienteId[0];
                     AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2R0( ) ;
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
               Load2R28( ) ;
            }
            EndLevel2R28( ) ;
         }
         CloseExtendedTableCursors2R28( ) ;
      }

      protected void Update2R28( )
      {
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2R28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2R28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2R28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Cliente */
                     DeferredUpdate2R28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2R0( ) ;
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
            EndLevel2R28( ) ;
         }
         CloseExtendedTableCursors2R28( ) ;
      }

      protected void DeferredUpdate2R28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2R28( ) ;
            AfterConfirm2R28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2R28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002R15 */
                  pr_default.execute(10, new Object[] {n168ClienteId, A168ClienteId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Cliente");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound28 == 0 )
                        {
                           InitAll2R28( ) ;
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
                        ResetCaption2R0( ) ;
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2R28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2R28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002R17 */
            pr_default.execute(11, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A886ClienteCountNotas_F = T002R17_A886ClienteCountNotas_F[0];
               n886ClienteCountNotas_F = T002R17_n886ClienteCountNotas_F[0];
               AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
            }
            else
            {
               A886ClienteCountNotas_F = 0;
               n886ClienteCountNotas_F = false;
               AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
            }
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002R18 */
            pr_default.execute(12, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"OperacoesTitulos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T002R19 */
            pr_default.execute(13, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sd Proposta Empresa"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T002R20 */
            pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sb Proposta Clinica"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002R21 */
            pr_default.execute(15, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Responsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T002R22 */
            pr_default.execute(16, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T002R23 */
            pr_default.execute(17, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T002R24 */
            pr_default.execute(18, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T002R25 */
            pr_default.execute(19, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002R26 */
            pr_default.execute(20, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Relacionamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T002R27 */
            pr_default.execute(21, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operacoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T002R28 */
            pr_default.execute(22, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T002R29 */
            pr_default.execute(23, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T002R30 */
            pr_default.execute(24, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"+" ("+"Sb Nota Destinatario Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T002R31 */
            pr_default.execute(25, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T002R32 */
            pr_default.execute(26, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Serasa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T002R33 */
            pr_default.execute(27, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T002R34 */
            pr_default.execute(28, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"+" ("+"Sb Cliente Reponsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T002R35 */
            pr_default.execute(29, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T002R36 */
            pr_default.execute(30, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T002R37 */
            pr_default.execute(31, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"+" ("+"SBFin Cli Int"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T002R38 */
            pr_default.execute(32, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
         }
      }

      protected void EndLevel2R28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2R0( ) ;
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

      public void ScanStart2R28( )
      {
         /* Using cursor T002R39 */
         pr_default.execute(33);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = T002R39_A168ClienteId[0];
            n168ClienteId = T002R39_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2R28( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = T002R39_A168ClienteId[0];
            n168ClienteId = T002R39_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         }
      }

      protected void ScanEnd2R28( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm2R28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2R28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2R28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2R28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2R28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2R28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2R28( )
      {
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteCountNotas_F_Enabled = 0;
         AssignProp("", false, edtClienteCountNotas_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCountNotas_F_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2R28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2R0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientenotas") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CLIENTEDOCUMENTO", A169ClienteDocumento);
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
         return formatLink("clientenotas")  ;
      }

      public override string GetPgmname( )
      {
         return "ClienteNotas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente Notas" ;
      }

      protected void InitializeNonKey2R28( )
      {
         A886ClienteCountNotas_F = 0;
         n886ClienteCountNotas_F = false;
         AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrimStr( (decimal)(A886ClienteCountNotas_F), 4, 0));
      }

      protected void InitAll2R28( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         InitializeNonKey2R28( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019211651", true, true);
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
         context.AddJavascriptSource("clientenotas.js", "?202561019211651", false, true);
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
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteCountNotas_F_Internalname = "CLIENTECOUNTNOTAS_F";
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
         Form.Caption = "Cliente Notas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteCountNotas_F_Jsonclick = "";
         edtClienteCountNotas_F_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
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

      public void Valid_Clienteid( )
      {
         n168ClienteId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002R17 */
         pr_default.execute(11, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A886ClienteCountNotas_F = T002R17_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = T002R17_n886ClienteCountNotas_F[0];
         }
         else
         {
            A886ClienteCountNotas_F = 0;
            n886ClienteCountNotas_F = false;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A886ClienteCountNotas_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A886ClienteCountNotas_F), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z886ClienteCountNotas_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z886ClienteCountNotas_F), 4, 0, ".", "")));
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
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A886ClienteCountNotas_F","fld":"CLIENTECOUNTNOTAS_F","pic":"ZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z168ClienteId","type":"int"},{"av":"Z886ClienteCountNotas_F","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         pr_default.close(11);
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
         A169ClienteDocumento = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T002R7_A168ClienteId = new int[1] ;
         T002R7_n168ClienteId = new bool[] {false} ;
         T002R7_A886ClienteCountNotas_F = new short[1] ;
         T002R7_n886ClienteCountNotas_F = new bool[] {false} ;
         T002R5_A886ClienteCountNotas_F = new short[1] ;
         T002R5_n886ClienteCountNotas_F = new bool[] {false} ;
         T002R9_A886ClienteCountNotas_F = new short[1] ;
         T002R9_n886ClienteCountNotas_F = new bool[] {false} ;
         T002R10_A168ClienteId = new int[1] ;
         T002R10_n168ClienteId = new bool[] {false} ;
         T002R3_A168ClienteId = new int[1] ;
         T002R3_n168ClienteId = new bool[] {false} ;
         sMode28 = "";
         T002R11_A168ClienteId = new int[1] ;
         T002R11_n168ClienteId = new bool[] {false} ;
         T002R12_A168ClienteId = new int[1] ;
         T002R12_n168ClienteId = new bool[] {false} ;
         T002R2_A168ClienteId = new int[1] ;
         T002R2_n168ClienteId = new bool[] {false} ;
         T002R14_A168ClienteId = new int[1] ;
         T002R14_n168ClienteId = new bool[] {false} ;
         T002R17_A886ClienteCountNotas_F = new short[1] ;
         T002R17_n886ClienteCountNotas_F = new bool[] {false} ;
         T002R18_A1019OperacoesTitulosId = new int[1] ;
         T002R19_A323PropostaId = new int[1] ;
         T002R20_A323PropostaId = new int[1] ;
         T002R21_A323PropostaId = new int[1] ;
         T002R22_A323PropostaId = new int[1] ;
         T002R23_A227ContratoId = new int[1] ;
         T002R24_A261TituloId = new int[1] ;
         T002R25_A133SecUserId = new short[1] ;
         T002R26_A1032RelacionamentoId = new int[1] ;
         T002R27_A1010OperacoesId = new int[1] ;
         T002R28_A978RepresentanteId = new int[1] ;
         T002R29_A856CreditoId = new int[1] ;
         T002R30_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002R31_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002R32_A662SerasaId = new int[1] ;
         T002R33_A599ClienteDocumentoId = new int[1] ;
         T002R34_A551ClienteReponsavelId = new int[1] ;
         T002R35_A551ClienteReponsavelId = new int[1] ;
         T002R36_A242AssinaturaParticipanteId = new int[1] ;
         T002R37_A223FinanciamentoId = new int[1] ;
         T002R38_A223FinanciamentoId = new int[1] ;
         T002R39_A168ClienteId = new int[1] ;
         T002R39_n168ClienteId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientenotas__default(),
            new Object[][] {
                new Object[] {
               T002R2_A168ClienteId
               }
               , new Object[] {
               T002R3_A168ClienteId
               }
               , new Object[] {
               T002R5_A886ClienteCountNotas_F, T002R5_n886ClienteCountNotas_F
               }
               , new Object[] {
               T002R7_A168ClienteId, T002R7_A886ClienteCountNotas_F, T002R7_n886ClienteCountNotas_F
               }
               , new Object[] {
               T002R9_A886ClienteCountNotas_F, T002R9_n886ClienteCountNotas_F
               }
               , new Object[] {
               T002R10_A168ClienteId
               }
               , new Object[] {
               T002R11_A168ClienteId
               }
               , new Object[] {
               T002R12_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               T002R14_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               T002R17_A886ClienteCountNotas_F, T002R17_n886ClienteCountNotas_F
               }
               , new Object[] {
               T002R18_A1019OperacoesTitulosId
               }
               , new Object[] {
               T002R19_A323PropostaId
               }
               , new Object[] {
               T002R20_A323PropostaId
               }
               , new Object[] {
               T002R21_A323PropostaId
               }
               , new Object[] {
               T002R22_A323PropostaId
               }
               , new Object[] {
               T002R23_A227ContratoId
               }
               , new Object[] {
               T002R24_A261TituloId
               }
               , new Object[] {
               T002R25_A133SecUserId
               }
               , new Object[] {
               T002R26_A1032RelacionamentoId
               }
               , new Object[] {
               T002R27_A1010OperacoesId
               }
               , new Object[] {
               T002R28_A978RepresentanteId
               }
               , new Object[] {
               T002R29_A856CreditoId
               }
               , new Object[] {
               T002R30_A794NotaFiscalId
               }
               , new Object[] {
               T002R31_A794NotaFiscalId
               }
               , new Object[] {
               T002R32_A662SerasaId
               }
               , new Object[] {
               T002R33_A599ClienteDocumentoId
               }
               , new Object[] {
               T002R34_A551ClienteReponsavelId
               }
               , new Object[] {
               T002R35_A551ClienteReponsavelId
               }
               , new Object[] {
               T002R36_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T002R37_A223FinanciamentoId
               }
               , new Object[] {
               T002R38_A223FinanciamentoId
               }
               , new Object[] {
               T002R39_A168ClienteId
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
      private short A886ClienteCountNotas_F ;
      private short Z886ClienteCountNotas_F ;
      private short RcdFound28 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ886ClienteCountNotas_F ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtClienteId_Enabled ;
      private int edtClienteCountNotas_F_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ168ClienteId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteId_Internalname ;
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
      private string edtClienteId_Jsonclick ;
      private string edtClienteCountNotas_F_Internalname ;
      private string edtClienteCountNotas_F_Jsonclick ;
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
      private string sMode28 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n168ClienteId ;
      private bool wbErr ;
      private bool n169ClienteDocumento ;
      private bool n886ClienteCountNotas_F ;
      private string A169ClienteDocumento ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002R7_A168ClienteId ;
      private bool[] T002R7_n168ClienteId ;
      private short[] T002R7_A886ClienteCountNotas_F ;
      private bool[] T002R7_n886ClienteCountNotas_F ;
      private short[] T002R5_A886ClienteCountNotas_F ;
      private bool[] T002R5_n886ClienteCountNotas_F ;
      private short[] T002R9_A886ClienteCountNotas_F ;
      private bool[] T002R9_n886ClienteCountNotas_F ;
      private int[] T002R10_A168ClienteId ;
      private bool[] T002R10_n168ClienteId ;
      private int[] T002R3_A168ClienteId ;
      private bool[] T002R3_n168ClienteId ;
      private int[] T002R11_A168ClienteId ;
      private bool[] T002R11_n168ClienteId ;
      private int[] T002R12_A168ClienteId ;
      private bool[] T002R12_n168ClienteId ;
      private int[] T002R2_A168ClienteId ;
      private bool[] T002R2_n168ClienteId ;
      private int[] T002R14_A168ClienteId ;
      private bool[] T002R14_n168ClienteId ;
      private short[] T002R17_A886ClienteCountNotas_F ;
      private bool[] T002R17_n886ClienteCountNotas_F ;
      private int[] T002R18_A1019OperacoesTitulosId ;
      private int[] T002R19_A323PropostaId ;
      private int[] T002R20_A323PropostaId ;
      private int[] T002R21_A323PropostaId ;
      private int[] T002R22_A323PropostaId ;
      private int[] T002R23_A227ContratoId ;
      private int[] T002R24_A261TituloId ;
      private short[] T002R25_A133SecUserId ;
      private int[] T002R26_A1032RelacionamentoId ;
      private int[] T002R27_A1010OperacoesId ;
      private int[] T002R28_A978RepresentanteId ;
      private int[] T002R29_A856CreditoId ;
      private Guid[] T002R30_A794NotaFiscalId ;
      private Guid[] T002R31_A794NotaFiscalId ;
      private int[] T002R32_A662SerasaId ;
      private int[] T002R33_A599ClienteDocumentoId ;
      private int[] T002R34_A551ClienteReponsavelId ;
      private int[] T002R35_A551ClienteReponsavelId ;
      private int[] T002R36_A242AssinaturaParticipanteId ;
      private int[] T002R37_A223FinanciamentoId ;
      private int[] T002R38_A223FinanciamentoId ;
      private int[] T002R39_A168ClienteId ;
      private bool[] T002R39_n168ClienteId ;
   }

   public class clientenotas__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002R2;
          prmT002R2 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R3;
          prmT002R3 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R5;
          prmT002R5 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R7;
          prmT002R7 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R9;
          prmT002R9 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R10;
          prmT002R10 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R11;
          prmT002R11 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R12;
          prmT002R12 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R13;
          prmT002R13 = new Object[] {
          };
          Object[] prmT002R14;
          prmT002R14 = new Object[] {
          };
          Object[] prmT002R15;
          prmT002R15 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R17;
          prmT002R17 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R18;
          prmT002R18 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R19;
          prmT002R19 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R20;
          prmT002R20 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R21;
          prmT002R21 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R22;
          prmT002R22 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R23;
          prmT002R23 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R24;
          prmT002R24 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R25;
          prmT002R25 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R26;
          prmT002R26 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R27;
          prmT002R27 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R28;
          prmT002R28 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R29;
          prmT002R29 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R30;
          prmT002R30 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R31;
          prmT002R31 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R32;
          prmT002R32 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R33;
          prmT002R33 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R34;
          prmT002R34 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R35;
          prmT002R35 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R36;
          prmT002R36 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R37;
          prmT002R37 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R38;
          prmT002R38 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002R39;
          prmT002R39 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002R2", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId  FOR UPDATE OF Cliente NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002R2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R3", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R5", "SELECT COALESCE( T1.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R7", "SELECT TM1.ClienteId, COALESCE( T2.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (Cliente TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE TM1.ClienteId = ClienteId GROUP BY ClienteId ) T2 ON T2.ClienteId = TM1.ClienteId) WHERE TM1.ClienteId = :ClienteId ORDER BY TM1.ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R9", "SELECT COALESCE( T1.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R10", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R11", "SELECT ClienteId FROM Cliente WHERE ( ClienteId > :ClienteId) ORDER BY ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R12", "SELECT ClienteId FROM Cliente WHERE ( ClienteId < :ClienteId) ORDER BY ClienteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R13", "SAVEPOINT gxupdate;INSERT INTO Cliente(ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteTipoPessoa, ClienteStatus, ClienteCreatedAt, ClienteUpdatedAt, ClienteLogUser, TipoClienteId, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, MunicipioCodigo, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, BancoId, ContaAgencia, ContaNumero, ClienteRG, ResponsavelNome, ResponsavelNacionalidade, ResponsavelEstadoCivil, ResponsavelProfissao, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelMunicipio, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteDataNascimento, EspecialidadeId, ClienteConvenio, ClienteNacionalidade, ClienteProfissao, ClienteEstadoCivil, ClienteDepositoTipo, ClientePixTipo, ClientePix, ResponsavelRG, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco) VALUES('', '', '', '', FALSE, DATE '00010101', DATE '00010101', 0, 0, '', '', '', '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, '', '', 0, '', 0, '', 0, '', '', '', '', '', '', 0, '', 0, 0, '', DATE '00010101', 0, 0, 0, 0, '', '', '', '', 0, '', '', '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002R13)
             ,new CursorDef("T002R14", "SELECT currval('ClienteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R15", "SAVEPOINT gxupdate;DELETE FROM Cliente  WHERE ClienteId = :ClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002R15)
             ,new CursorDef("T002R17", "SELECT COALESCE( T1.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002R18", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE SacadoId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R19", "SELECT PropostaId FROM Proposta WHERE PropostaEmpresaClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R20", "SELECT PropostaId FROM Proposta WHERE PropostaClinicaId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R21", "SELECT PropostaId FROM Proposta WHERE PropostaResponsavelId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R22", "SELECT PropostaId FROM Proposta WHERE PropostaPacienteClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R23", "SELECT ContratoId FROM Contrato WHERE ContratoClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R24", "SELECT TituloId FROM Titulo WHERE TituloClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R25", "SELECT SecUserId FROM SecUser WHERE SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R26", "SELECT RelacionamentoId FROM Relacionamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R27", "SELECT OperacoesId FROM Operacoes WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R28", "SELECT RepresentanteId FROM Representante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R29", "SELECT CreditoId FROM Credito WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R30", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalDestinatarioClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R31", "SELECT NotaFiscalId FROM NotaFiscal WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R32", "SELECT SerasaId FROM Serasa WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R33", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R34", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ReponsavelClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R35", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R36", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R37", "SELECT FinanciamentoId FROM Financiamento WHERE IntermediadorClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R37,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R38", "SELECT FinanciamentoId FROM Financiamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R38,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002R39", "SELECT ClienteId FROM Cliente ORDER BY ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002R39,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 25 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
