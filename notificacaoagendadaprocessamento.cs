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
   public class notificacaoagendadaprocessamento : GXDataArea
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
         Form.Meta.addItem("description", "Processo de envio de notificações agendadas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public notificacaoagendadaprocessamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadaprocessamento( IGxContext context )
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
         cmbNotificacaoAgendadaProcessamentoSituacao = new GXCombobox();
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
         if ( cmbNotificacaoAgendadaProcessamentoSituacao.ItemCount > 0 )
         {
            A914NotificacaoAgendadaProcessamentoSituacao = cmbNotificacaoAgendadaProcessamentoSituacao.getValidValue(A914NotificacaoAgendadaProcessamentoSituacao);
            n914NotificacaoAgendadaProcessamentoSituacao = false;
            AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao);
            AssignProp("", false, cmbNotificacaoAgendadaProcessamentoSituacao_Internalname, "Values", cmbNotificacaoAgendadaProcessamentoSituacao.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Processo de envio de notificações agendadas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_NotificacaoAgendadaProcessamento.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_NotificacaoAgendadaProcessamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoId_Internalname, "do processamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoId_Internalname, A908NotificacaoAgendadaProcessamentoId.ToString(), A908NotificacaoAgendadaProcessamentoId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoInicio_Internalname, "Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotificacaoAgendadaProcessamentoInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoInicio_Internalname, context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A909NotificacaoAgendadaProcessamentoInicio, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoInicio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_bitmap( context, edtNotificacaoAgendadaProcessamentoInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotificacaoAgendadaProcessamentoInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoFim_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoFim_Internalname, "Fim", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotificacaoAgendadaProcessamentoFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoFim_Internalname, context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A910NotificacaoAgendadaProcessamentoFim, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoFim_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoFim_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_bitmap( context, edtNotificacaoAgendadaProcessamentoFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotificacaoAgendadaProcessamentoFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoQtdExec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoQtdExec_Internalname, "de execuções", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoQtdExec_Internalname, ((0==A911NotificacaoAgendadaProcessamentoQtdExec)&&IsIns( )||n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ",", ""))), ((0==A911NotificacaoAgendadaProcessamentoQtdExec)&&IsIns( )||n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( ((edtNotificacaoAgendadaProcessamentoQtdExec_Enabled!=0) ? context.localUtil.Format( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoQtdExec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoQtdExec_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname, "tiveram sucesso", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname, ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso)&&IsIns( )||n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ",", ""))), ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso)&&IsIns( )||n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( ((edtNotificacaoAgendadaProcessamentoQtdSucesso_Enabled!=0) ? context.localUtil.Format( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), "ZZZ9") : context.localUtil.Format( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoQtdSucesso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoQtdSucesso_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname, "que falharam", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname, ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas)&&IsIns( )||n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ",", ""))), ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas)&&IsIns( )||n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( ((edtNotificacaoAgendadaProcessamentoQtdFalhas_Enabled!=0) ? context.localUtil.Format( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), "ZZZ9") : context.localUtil.Format( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoQtdFalhas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoQtdFalhas_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaProcessamentoSituacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaProcessamentoSituacao_Internalname, "notificações agendadas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaProcessamentoSituacao, cmbNotificacaoAgendadaProcessamentoSituacao_Internalname, StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao), 1, cmbNotificacaoAgendadaProcessamentoSituacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificacaoAgendadaProcessamentoSituacao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_NotificacaoAgendadaProcessamento.htm");
         cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao);
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoSituacao_Internalname, "Values", (string)(cmbNotificacaoAgendadaProcessamentoSituacao.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname, "do Processamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname, A915NotificacaoAgendadaProcessamentoMensagemErro, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtNotificacaoAgendadaProcessamentoMensagemErro_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_NotificacaoAgendadaProcessamento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamento.htm");
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
            Z908NotificacaoAgendadaProcessamentoId = StringUtil.StrToGuid( cgiGet( "Z908NotificacaoAgendadaProcessamentoId"));
            Z909NotificacaoAgendadaProcessamentoInicio = context.localUtil.CToT( cgiGet( "Z909NotificacaoAgendadaProcessamentoInicio"), 0);
            n909NotificacaoAgendadaProcessamentoInicio = ((DateTime.MinValue==A909NotificacaoAgendadaProcessamentoInicio) ? true : false);
            Z910NotificacaoAgendadaProcessamentoFim = context.localUtil.CToT( cgiGet( "Z910NotificacaoAgendadaProcessamentoFim"), 0);
            n910NotificacaoAgendadaProcessamentoFim = ((DateTime.MinValue==A910NotificacaoAgendadaProcessamentoFim) ? true : false);
            Z911NotificacaoAgendadaProcessamentoQtdExec = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z911NotificacaoAgendadaProcessamentoQtdExec"), ",", "."), 18, MidpointRounding.ToEven));
            n911NotificacaoAgendadaProcessamentoQtdExec = ((0==A911NotificacaoAgendadaProcessamentoQtdExec) ? true : false);
            Z912NotificacaoAgendadaProcessamentoQtdSucesso = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z912NotificacaoAgendadaProcessamentoQtdSucesso"), ",", "."), 18, MidpointRounding.ToEven));
            n912NotificacaoAgendadaProcessamentoQtdSucesso = ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso) ? true : false);
            Z913NotificacaoAgendadaProcessamentoQtdFalhas = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z913NotificacaoAgendadaProcessamentoQtdFalhas"), ",", "."), 18, MidpointRounding.ToEven));
            n913NotificacaoAgendadaProcessamentoQtdFalhas = ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas) ? true : false);
            Z914NotificacaoAgendadaProcessamentoSituacao = cgiGet( "Z914NotificacaoAgendadaProcessamentoSituacao");
            n914NotificacaoAgendadaProcessamentoSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtNotificacaoAgendadaProcessamentoId_Internalname), "") == 0 )
            {
               A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
               AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            }
            else
            {
               try
               {
                  A908NotificacaoAgendadaProcessamentoId = StringUtil.StrToGuid( cgiGet( edtNotificacaoAgendadaProcessamentoId_Internalname));
                  AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtNotificacaoAgendadaProcessamentoInicio_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Inicio"}), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOINICIO");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
               n909NotificacaoAgendadaProcessamentoInicio = false;
               AssignAttri("", false, "A909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A909NotificacaoAgendadaProcessamentoInicio = context.localUtil.CToT( cgiGet( edtNotificacaoAgendadaProcessamentoInicio_Internalname));
               n909NotificacaoAgendadaProcessamentoInicio = false;
               AssignAttri("", false, "A909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            n909NotificacaoAgendadaProcessamentoInicio = ((DateTime.MinValue==A909NotificacaoAgendadaProcessamentoInicio) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtNotificacaoAgendadaProcessamentoFim_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fim"}), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOFIM");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoFim_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
               n910NotificacaoAgendadaProcessamentoFim = false;
               AssignAttri("", false, "A910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A910NotificacaoAgendadaProcessamentoFim = context.localUtil.CToT( cgiGet( edtNotificacaoAgendadaProcessamentoFim_Internalname));
               n910NotificacaoAgendadaProcessamentoFim = false;
               AssignAttri("", false, "A910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 8, 5, 0, 3, "/", ":", " "));
            }
            n910NotificacaoAgendadaProcessamentoFim = ((DateTime.MinValue==A910NotificacaoAgendadaProcessamentoFim) ? true : false);
            n911NotificacaoAgendadaProcessamentoQtdExec = ((StringUtil.StrCmp(cgiGet( edtNotificacaoAgendadaProcessamentoQtdExec_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdExec_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdExec_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOQTDEXEC");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoQtdExec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A911NotificacaoAgendadaProcessamentoQtdExec = 0;
               n911NotificacaoAgendadaProcessamentoQtdExec = false;
               AssignAttri("", false, "A911NotificacaoAgendadaProcessamentoQtdExec", (n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", ""))));
            }
            else
            {
               A911NotificacaoAgendadaProcessamentoQtdExec = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdExec_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A911NotificacaoAgendadaProcessamentoQtdExec", (n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", ""))));
            }
            n912NotificacaoAgendadaProcessamentoQtdSucesso = ((StringUtil.StrCmp(cgiGet( edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOQTDSUCESSO");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A912NotificacaoAgendadaProcessamentoQtdSucesso = 0;
               n912NotificacaoAgendadaProcessamentoQtdSucesso = false;
               AssignAttri("", false, "A912NotificacaoAgendadaProcessamentoQtdSucesso", (n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", ""))));
            }
            else
            {
               A912NotificacaoAgendadaProcessamentoQtdSucesso = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A912NotificacaoAgendadaProcessamentoQtdSucesso", (n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", ""))));
            }
            n913NotificacaoAgendadaProcessamentoQtdFalhas = ((StringUtil.StrCmp(cgiGet( edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOQTDFALHAS");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A913NotificacaoAgendadaProcessamentoQtdFalhas = 0;
               n913NotificacaoAgendadaProcessamentoQtdFalhas = false;
               AssignAttri("", false, "A913NotificacaoAgendadaProcessamentoQtdFalhas", (n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", ""))));
            }
            else
            {
               A913NotificacaoAgendadaProcessamentoQtdFalhas = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A913NotificacaoAgendadaProcessamentoQtdFalhas", (n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", ""))));
            }
            cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = cgiGet( cmbNotificacaoAgendadaProcessamentoSituacao_Internalname);
            A914NotificacaoAgendadaProcessamentoSituacao = cgiGet( cmbNotificacaoAgendadaProcessamentoSituacao_Internalname);
            n914NotificacaoAgendadaProcessamentoSituacao = false;
            AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
            n914NotificacaoAgendadaProcessamentoSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao)) ? true : false);
            A915NotificacaoAgendadaProcessamentoMensagemErro = cgiGet( edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname);
            n915NotificacaoAgendadaProcessamentoMensagemErro = false;
            AssignAttri("", false, "A915NotificacaoAgendadaProcessamentoMensagemErro", A915NotificacaoAgendadaProcessamentoMensagemErro);
            n915NotificacaoAgendadaProcessamentoMensagemErro = (String.IsNullOrEmpty(StringUtil.RTrim( A915NotificacaoAgendadaProcessamentoMensagemErro)) ? true : false);
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
               A908NotificacaoAgendadaProcessamentoId = StringUtil.StrToGuid( GetPar( "NotificacaoAgendadaProcessamentoId"));
               AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A908NotificacaoAgendadaProcessamentoId) && ( Gx_BScreen == 0 ) )
               {
                  A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
                  AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
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
               InitAll2V99( ) ;
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
         DisableAttributes2V99( ) ;
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

      protected void ResetCaption2V0( )
      {
      }

      protected void ZM2V99( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z909NotificacaoAgendadaProcessamentoInicio = T002V3_A909NotificacaoAgendadaProcessamentoInicio[0];
               Z910NotificacaoAgendadaProcessamentoFim = T002V3_A910NotificacaoAgendadaProcessamentoFim[0];
               Z911NotificacaoAgendadaProcessamentoQtdExec = T002V3_A911NotificacaoAgendadaProcessamentoQtdExec[0];
               Z912NotificacaoAgendadaProcessamentoQtdSucesso = T002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
               Z913NotificacaoAgendadaProcessamentoQtdFalhas = T002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
               Z914NotificacaoAgendadaProcessamentoSituacao = T002V3_A914NotificacaoAgendadaProcessamentoSituacao[0];
            }
            else
            {
               Z909NotificacaoAgendadaProcessamentoInicio = A909NotificacaoAgendadaProcessamentoInicio;
               Z910NotificacaoAgendadaProcessamentoFim = A910NotificacaoAgendadaProcessamentoFim;
               Z911NotificacaoAgendadaProcessamentoQtdExec = A911NotificacaoAgendadaProcessamentoQtdExec;
               Z912NotificacaoAgendadaProcessamentoQtdSucesso = A912NotificacaoAgendadaProcessamentoQtdSucesso;
               Z913NotificacaoAgendadaProcessamentoQtdFalhas = A913NotificacaoAgendadaProcessamentoQtdFalhas;
               Z914NotificacaoAgendadaProcessamentoSituacao = A914NotificacaoAgendadaProcessamentoSituacao;
            }
         }
         if ( GX_JID == -4 )
         {
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            Z909NotificacaoAgendadaProcessamentoInicio = A909NotificacaoAgendadaProcessamentoInicio;
            Z910NotificacaoAgendadaProcessamentoFim = A910NotificacaoAgendadaProcessamentoFim;
            Z911NotificacaoAgendadaProcessamentoQtdExec = A911NotificacaoAgendadaProcessamentoQtdExec;
            Z912NotificacaoAgendadaProcessamentoQtdSucesso = A912NotificacaoAgendadaProcessamentoQtdSucesso;
            Z913NotificacaoAgendadaProcessamentoQtdFalhas = A913NotificacaoAgendadaProcessamentoQtdFalhas;
            Z914NotificacaoAgendadaProcessamentoSituacao = A914NotificacaoAgendadaProcessamentoSituacao;
            Z915NotificacaoAgendadaProcessamentoMensagemErro = A915NotificacaoAgendadaProcessamentoMensagemErro;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A908NotificacaoAgendadaProcessamentoId) && ( Gx_BScreen == 0 ) )
         {
            A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2V99( )
      {
         /* Using cursor T002V4 */
         pr_default.execute(2, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound99 = 1;
            A909NotificacaoAgendadaProcessamentoInicio = T002V4_A909NotificacaoAgendadaProcessamentoInicio[0];
            n909NotificacaoAgendadaProcessamentoInicio = T002V4_n909NotificacaoAgendadaProcessamentoInicio[0];
            AssignAttri("", false, "A909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 8, 5, 0, 3, "/", ":", " "));
            A910NotificacaoAgendadaProcessamentoFim = T002V4_A910NotificacaoAgendadaProcessamentoFim[0];
            n910NotificacaoAgendadaProcessamentoFim = T002V4_n910NotificacaoAgendadaProcessamentoFim[0];
            AssignAttri("", false, "A910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 8, 5, 0, 3, "/", ":", " "));
            A911NotificacaoAgendadaProcessamentoQtdExec = T002V4_A911NotificacaoAgendadaProcessamentoQtdExec[0];
            n911NotificacaoAgendadaProcessamentoQtdExec = T002V4_n911NotificacaoAgendadaProcessamentoQtdExec[0];
            AssignAttri("", false, "A911NotificacaoAgendadaProcessamentoQtdExec", ((0==A911NotificacaoAgendadaProcessamentoQtdExec)&&IsIns( )||n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", ""))));
            A912NotificacaoAgendadaProcessamentoQtdSucesso = T002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            n912NotificacaoAgendadaProcessamentoQtdSucesso = T002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            AssignAttri("", false, "A912NotificacaoAgendadaProcessamentoQtdSucesso", ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso)&&IsIns( )||n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", ""))));
            A913NotificacaoAgendadaProcessamentoQtdFalhas = T002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            n913NotificacaoAgendadaProcessamentoQtdFalhas = T002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            AssignAttri("", false, "A913NotificacaoAgendadaProcessamentoQtdFalhas", ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas)&&IsIns( )||n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", ""))));
            A914NotificacaoAgendadaProcessamentoSituacao = T002V4_A914NotificacaoAgendadaProcessamentoSituacao[0];
            n914NotificacaoAgendadaProcessamentoSituacao = T002V4_n914NotificacaoAgendadaProcessamentoSituacao[0];
            AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
            A915NotificacaoAgendadaProcessamentoMensagemErro = T002V4_A915NotificacaoAgendadaProcessamentoMensagemErro[0];
            n915NotificacaoAgendadaProcessamentoMensagemErro = T002V4_n915NotificacaoAgendadaProcessamentoMensagemErro[0];
            AssignAttri("", false, "A915NotificacaoAgendadaProcessamentoMensagemErro", A915NotificacaoAgendadaProcessamentoMensagemErro);
            ZM2V99( -4) ;
         }
         pr_default.close(2);
         OnLoadActions2V99( ) ;
      }

      protected void OnLoadActions2V99( )
      {
      }

      protected void CheckExtendedTable2V99( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "F") == 0 ) || ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "P") == 0 ) || ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "S") == 0 ) || ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "E") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao)) ) )
         {
            GX_msglist.addItem("Campo Situação do processamento de notificações agendadas fora do intervalo", "OutOfRange", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOSITUACAO");
            AnyError = 1;
            GX_FocusControl = cmbNotificacaoAgendadaProcessamentoSituacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2V99( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2V99( )
      {
         /* Using cursor T002V5 */
         pr_default.execute(3, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound99 = 1;
         }
         else
         {
            RcdFound99 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002V3 */
         pr_default.execute(1, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2V99( 4) ;
            RcdFound99 = 1;
            A908NotificacaoAgendadaProcessamentoId = T002V3_A908NotificacaoAgendadaProcessamentoId[0];
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            A909NotificacaoAgendadaProcessamentoInicio = T002V3_A909NotificacaoAgendadaProcessamentoInicio[0];
            n909NotificacaoAgendadaProcessamentoInicio = T002V3_n909NotificacaoAgendadaProcessamentoInicio[0];
            AssignAttri("", false, "A909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 8, 5, 0, 3, "/", ":", " "));
            A910NotificacaoAgendadaProcessamentoFim = T002V3_A910NotificacaoAgendadaProcessamentoFim[0];
            n910NotificacaoAgendadaProcessamentoFim = T002V3_n910NotificacaoAgendadaProcessamentoFim[0];
            AssignAttri("", false, "A910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 8, 5, 0, 3, "/", ":", " "));
            A911NotificacaoAgendadaProcessamentoQtdExec = T002V3_A911NotificacaoAgendadaProcessamentoQtdExec[0];
            n911NotificacaoAgendadaProcessamentoQtdExec = T002V3_n911NotificacaoAgendadaProcessamentoQtdExec[0];
            AssignAttri("", false, "A911NotificacaoAgendadaProcessamentoQtdExec", ((0==A911NotificacaoAgendadaProcessamentoQtdExec)&&IsIns( )||n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", ""))));
            A912NotificacaoAgendadaProcessamentoQtdSucesso = T002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            n912NotificacaoAgendadaProcessamentoQtdSucesso = T002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            AssignAttri("", false, "A912NotificacaoAgendadaProcessamentoQtdSucesso", ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso)&&IsIns( )||n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", ""))));
            A913NotificacaoAgendadaProcessamentoQtdFalhas = T002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            n913NotificacaoAgendadaProcessamentoQtdFalhas = T002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            AssignAttri("", false, "A913NotificacaoAgendadaProcessamentoQtdFalhas", ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas)&&IsIns( )||n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", ""))));
            A914NotificacaoAgendadaProcessamentoSituacao = T002V3_A914NotificacaoAgendadaProcessamentoSituacao[0];
            n914NotificacaoAgendadaProcessamentoSituacao = T002V3_n914NotificacaoAgendadaProcessamentoSituacao[0];
            AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
            A915NotificacaoAgendadaProcessamentoMensagemErro = T002V3_A915NotificacaoAgendadaProcessamentoMensagemErro[0];
            n915NotificacaoAgendadaProcessamentoMensagemErro = T002V3_n915NotificacaoAgendadaProcessamentoMensagemErro[0];
            AssignAttri("", false, "A915NotificacaoAgendadaProcessamentoMensagemErro", A915NotificacaoAgendadaProcessamentoMensagemErro);
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2V99( ) ;
            if ( AnyError == 1 )
            {
               RcdFound99 = 0;
               InitializeNonKey2V99( ) ;
            }
            Gx_mode = sMode99;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound99 = 0;
            InitializeNonKey2V99( ) ;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode99;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2V99( ) ;
         if ( RcdFound99 == 0 )
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
         RcdFound99 = 0;
         /* Using cursor T002V6 */
         pr_default.execute(4, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T002V6_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T002V6_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) > 0 ) ) )
            {
               A908NotificacaoAgendadaProcessamentoId = T002V6_A908NotificacaoAgendadaProcessamentoId[0];
               AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               RcdFound99 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound99 = 0;
         /* Using cursor T002V7 */
         pr_default.execute(5, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T002V7_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T002V7_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) < 0 ) ) )
            {
               A908NotificacaoAgendadaProcessamentoId = T002V7_A908NotificacaoAgendadaProcessamentoId[0];
               AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               RcdFound99 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2V99( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2V99( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound99 == 1 )
            {
               if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
               {
                  A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
                  AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2V99( ) ;
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2V99( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2V99( ) ;
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
         if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
         {
            A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2V99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2V99( ) ;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
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
         ScanStart2V99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound99 != 0 )
            {
               ScanNext2V99( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2V99( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2V99( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002V2 */
            pr_default.execute(0, new Object[] {A908NotificacaoAgendadaProcessamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z909NotificacaoAgendadaProcessamentoInicio != T002V2_A909NotificacaoAgendadaProcessamentoInicio[0] ) || ( Z910NotificacaoAgendadaProcessamentoFim != T002V2_A910NotificacaoAgendadaProcessamentoFim[0] ) || ( Z911NotificacaoAgendadaProcessamentoQtdExec != T002V2_A911NotificacaoAgendadaProcessamentoQtdExec[0] ) || ( Z912NotificacaoAgendadaProcessamentoQtdSucesso != T002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso[0] ) || ( Z913NotificacaoAgendadaProcessamentoQtdFalhas != T002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z914NotificacaoAgendadaProcessamentoSituacao, T002V2_A914NotificacaoAgendadaProcessamentoSituacao[0]) != 0 ) )
            {
               if ( Z909NotificacaoAgendadaProcessamentoInicio != T002V2_A909NotificacaoAgendadaProcessamentoInicio[0] )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamento:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoInicio");
                  GXUtil.WriteLogRaw("Old: ",Z909NotificacaoAgendadaProcessamentoInicio);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A909NotificacaoAgendadaProcessamentoInicio[0]);
               }
               if ( Z910NotificacaoAgendadaProcessamentoFim != T002V2_A910NotificacaoAgendadaProcessamentoFim[0] )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamento:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoFim");
                  GXUtil.WriteLogRaw("Old: ",Z910NotificacaoAgendadaProcessamentoFim);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A910NotificacaoAgendadaProcessamentoFim[0]);
               }
               if ( Z911NotificacaoAgendadaProcessamentoQtdExec != T002V2_A911NotificacaoAgendadaProcessamentoQtdExec[0] )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamento:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoQtdExec");
                  GXUtil.WriteLogRaw("Old: ",Z911NotificacaoAgendadaProcessamentoQtdExec);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A911NotificacaoAgendadaProcessamentoQtdExec[0]);
               }
               if ( Z912NotificacaoAgendadaProcessamentoQtdSucesso != T002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso[0] )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamento:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoQtdSucesso");
                  GXUtil.WriteLogRaw("Old: ",Z912NotificacaoAgendadaProcessamentoQtdSucesso);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso[0]);
               }
               if ( Z913NotificacaoAgendadaProcessamentoQtdFalhas != T002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas[0] )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamento:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoQtdFalhas");
                  GXUtil.WriteLogRaw("Old: ",Z913NotificacaoAgendadaProcessamentoQtdFalhas);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas[0]);
               }
               if ( StringUtil.StrCmp(Z914NotificacaoAgendadaProcessamentoSituacao, T002V2_A914NotificacaoAgendadaProcessamentoSituacao[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamento:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoSituacao");
                  GXUtil.WriteLogRaw("Old: ",Z914NotificacaoAgendadaProcessamentoSituacao);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A914NotificacaoAgendadaProcessamentoSituacao[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotificacaoAgendadaProcessamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2V99( )
      {
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2V99( 0) ;
            CheckOptimisticConcurrency2V99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2V99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2V99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002V8 */
                     pr_default.execute(6, new Object[] {A908NotificacaoAgendadaProcessamentoId, n909NotificacaoAgendadaProcessamentoInicio, A909NotificacaoAgendadaProcessamentoInicio, n910NotificacaoAgendadaProcessamentoFim, A910NotificacaoAgendadaProcessamentoFim, n911NotificacaoAgendadaProcessamentoQtdExec, A911NotificacaoAgendadaProcessamentoQtdExec, n912NotificacaoAgendadaProcessamentoQtdSucesso, A912NotificacaoAgendadaProcessamentoQtdSucesso, n913NotificacaoAgendadaProcessamentoQtdFalhas, A913NotificacaoAgendadaProcessamentoQtdFalhas, n914NotificacaoAgendadaProcessamentoSituacao, A914NotificacaoAgendadaProcessamentoSituacao, n915NotificacaoAgendadaProcessamentoMensagemErro, A915NotificacaoAgendadaProcessamentoMensagemErro});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamento");
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
                           ResetCaption2V0( ) ;
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
               Load2V99( ) ;
            }
            EndLevel2V99( ) ;
         }
         CloseExtendedTableCursors2V99( ) ;
      }

      protected void Update2V99( )
      {
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2V99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2V99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2V99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002V9 */
                     pr_default.execute(7, new Object[] {n909NotificacaoAgendadaProcessamentoInicio, A909NotificacaoAgendadaProcessamentoInicio, n910NotificacaoAgendadaProcessamentoFim, A910NotificacaoAgendadaProcessamentoFim, n911NotificacaoAgendadaProcessamentoQtdExec, A911NotificacaoAgendadaProcessamentoQtdExec, n912NotificacaoAgendadaProcessamentoQtdSucesso, A912NotificacaoAgendadaProcessamentoQtdSucesso, n913NotificacaoAgendadaProcessamentoQtdFalhas, A913NotificacaoAgendadaProcessamentoQtdFalhas, n914NotificacaoAgendadaProcessamentoSituacao, A914NotificacaoAgendadaProcessamentoSituacao, n915NotificacaoAgendadaProcessamentoMensagemErro, A915NotificacaoAgendadaProcessamentoMensagemErro, A908NotificacaoAgendadaProcessamentoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamento");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2V99( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2V0( ) ;
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
            EndLevel2V99( ) ;
         }
         CloseExtendedTableCursors2V99( ) ;
      }

      protected void DeferredUpdate2V99( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2V99( ) ;
            AfterConfirm2V99( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2V99( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002V10 */
                  pr_default.execute(8, new Object[] {A908NotificacaoAgendadaProcessamentoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound99 == 0 )
                        {
                           InitAll2V99( ) ;
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
                        ResetCaption2V0( ) ;
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
         sMode99 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2V99( ) ;
         Gx_mode = sMode99;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2V99( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002V11 */
            pr_default.execute(9, new Object[] {A908NotificacaoAgendadaProcessamentoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel2V99( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2V0( ) ;
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

      public void ScanStart2V99( )
      {
         /* Using cursor T002V12 */
         pr_default.execute(10);
         RcdFound99 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound99 = 1;
            A908NotificacaoAgendadaProcessamentoId = T002V12_A908NotificacaoAgendadaProcessamentoId[0];
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2V99( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound99 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound99 = 1;
            A908NotificacaoAgendadaProcessamentoId = T002V12_A908NotificacaoAgendadaProcessamentoId[0];
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
         }
      }

      protected void ScanEnd2V99( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2V99( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2V99( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2V99( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2V99( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2V99( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2V99( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2V99( )
      {
         edtNotificacaoAgendadaProcessamentoId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoId_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoInicio_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoInicio_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoFim_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoFim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoFim_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoQtdExec_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoQtdExec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoQtdExec_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoQtdSucesso_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoQtdSucesso_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoQtdFalhas_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoQtdFalhas_Enabled), 5, 0), true);
         cmbNotificacaoAgendadaProcessamentoSituacao.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoSituacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaProcessamentoSituacao.Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoMensagemErro_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoMensagemErro_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2V99( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2V0( )
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notificacaoagendadaprocessamento") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z908NotificacaoAgendadaProcessamentoId", Z908NotificacaoAgendadaProcessamentoId.ToString());
         GxWebStd.gx_hidden_field( context, "Z909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( Z909NotificacaoAgendadaProcessamentoInicio, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( Z910NotificacaoAgendadaProcessamentoFim, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z911NotificacaoAgendadaProcessamentoQtdExec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z912NotificacaoAgendadaProcessamentoQtdSucesso", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z913NotificacaoAgendadaProcessamentoQtdFalhas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z914NotificacaoAgendadaProcessamentoSituacao", Z914NotificacaoAgendadaProcessamentoSituacao);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         return formatLink("notificacaoagendadaprocessamento")  ;
      }

      public override string GetPgmname( )
      {
         return "NotificacaoAgendadaProcessamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Processo de envio de notificações agendadas" ;
      }

      protected void InitializeNonKey2V99( )
      {
         A909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         n909NotificacaoAgendadaProcessamentoInicio = false;
         AssignAttri("", false, "A909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 8, 5, 0, 3, "/", ":", " "));
         n909NotificacaoAgendadaProcessamentoInicio = ((DateTime.MinValue==A909NotificacaoAgendadaProcessamentoInicio) ? true : false);
         A910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         n910NotificacaoAgendadaProcessamentoFim = false;
         AssignAttri("", false, "A910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 8, 5, 0, 3, "/", ":", " "));
         n910NotificacaoAgendadaProcessamentoFim = ((DateTime.MinValue==A910NotificacaoAgendadaProcessamentoFim) ? true : false);
         A911NotificacaoAgendadaProcessamentoQtdExec = 0;
         n911NotificacaoAgendadaProcessamentoQtdExec = false;
         AssignAttri("", false, "A911NotificacaoAgendadaProcessamentoQtdExec", ((0==A911NotificacaoAgendadaProcessamentoQtdExec)&&IsIns( )||n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", ""))));
         n911NotificacaoAgendadaProcessamentoQtdExec = ((0==A911NotificacaoAgendadaProcessamentoQtdExec) ? true : false);
         A912NotificacaoAgendadaProcessamentoQtdSucesso = 0;
         n912NotificacaoAgendadaProcessamentoQtdSucesso = false;
         AssignAttri("", false, "A912NotificacaoAgendadaProcessamentoQtdSucesso", ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso)&&IsIns( )||n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", ""))));
         n912NotificacaoAgendadaProcessamentoQtdSucesso = ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso) ? true : false);
         A913NotificacaoAgendadaProcessamentoQtdFalhas = 0;
         n913NotificacaoAgendadaProcessamentoQtdFalhas = false;
         AssignAttri("", false, "A913NotificacaoAgendadaProcessamentoQtdFalhas", ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas)&&IsIns( )||n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", ""))));
         n913NotificacaoAgendadaProcessamentoQtdFalhas = ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas) ? true : false);
         A914NotificacaoAgendadaProcessamentoSituacao = "";
         n914NotificacaoAgendadaProcessamentoSituacao = false;
         AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
         n914NotificacaoAgendadaProcessamentoSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao)) ? true : false);
         A915NotificacaoAgendadaProcessamentoMensagemErro = "";
         n915NotificacaoAgendadaProcessamentoMensagemErro = false;
         AssignAttri("", false, "A915NotificacaoAgendadaProcessamentoMensagemErro", A915NotificacaoAgendadaProcessamentoMensagemErro);
         n915NotificacaoAgendadaProcessamentoMensagemErro = (String.IsNullOrEmpty(StringUtil.RTrim( A915NotificacaoAgendadaProcessamentoMensagemErro)) ? true : false);
         Z909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         Z910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         Z911NotificacaoAgendadaProcessamentoQtdExec = 0;
         Z912NotificacaoAgendadaProcessamentoQtdSucesso = 0;
         Z913NotificacaoAgendadaProcessamentoQtdFalhas = 0;
         Z914NotificacaoAgendadaProcessamentoSituacao = "";
      }

      protected void InitAll2V99( )
      {
         A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
         AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
         InitializeNonKey2V99( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019214177", true, true);
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
         context.AddJavascriptSource("notificacaoagendadaprocessamento.js", "?202561019214178", false, true);
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
         edtNotificacaoAgendadaProcessamentoId_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOID";
         edtNotificacaoAgendadaProcessamentoInicio_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOINICIO";
         edtNotificacaoAgendadaProcessamentoFim_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOFIM";
         edtNotificacaoAgendadaProcessamentoQtdExec_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOQTDEXEC";
         edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOQTDSUCESSO";
         edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOQTDFALHAS";
         cmbNotificacaoAgendadaProcessamentoSituacao_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOSITUACAO";
         edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOMENSAGEMERRO";
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
         Form.Caption = "Processo de envio de notificações agendadas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNotificacaoAgendadaProcessamentoMensagemErro_Enabled = 1;
         cmbNotificacaoAgendadaProcessamentoSituacao_Jsonclick = "";
         cmbNotificacaoAgendadaProcessamentoSituacao.Enabled = 1;
         edtNotificacaoAgendadaProcessamentoQtdFalhas_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoQtdFalhas_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoQtdSucesso_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoQtdSucesso_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoQtdExec_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoQtdExec_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoFim_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoFim_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoInicio_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoInicio_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoId_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoId_Enabled = 1;
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
         cmbNotificacaoAgendadaProcessamentoSituacao.Name = "NOTIFICACAOAGENDADAPROCESSAMENTOSITUACAO";
         cmbNotificacaoAgendadaProcessamentoSituacao.WebTags = "";
         cmbNotificacaoAgendadaProcessamentoSituacao.addItem("F", "Finalizado", 0);
         cmbNotificacaoAgendadaProcessamentoSituacao.addItem("P", "Processando", 0);
         cmbNotificacaoAgendadaProcessamentoSituacao.addItem("S", "Sucesso", 0);
         cmbNotificacaoAgendadaProcessamentoSituacao.addItem("E", "Falhou", 0);
         if ( cmbNotificacaoAgendadaProcessamentoSituacao.ItemCount > 0 )
         {
            A914NotificacaoAgendadaProcessamentoSituacao = cmbNotificacaoAgendadaProcessamentoSituacao.getValidValue(A914NotificacaoAgendadaProcessamentoSituacao);
            n914NotificacaoAgendadaProcessamentoSituacao = false;
            AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoInicio_Internalname;
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

      public void Valid_Notificacaoagendadaprocessamentoid( )
      {
         n914NotificacaoAgendadaProcessamentoSituacao = false;
         A914NotificacaoAgendadaProcessamentoSituacao = cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue;
         n914NotificacaoAgendadaProcessamentoSituacao = false;
         cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = A914NotificacaoAgendadaProcessamentoSituacao;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbNotificacaoAgendadaProcessamentoSituacao.ItemCount > 0 )
         {
            A914NotificacaoAgendadaProcessamentoSituacao = cmbNotificacaoAgendadaProcessamentoSituacao.getValidValue(A914NotificacaoAgendadaProcessamentoSituacao);
            n914NotificacaoAgendadaProcessamentoSituacao = false;
            cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = A914NotificacaoAgendadaProcessamentoSituacao;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( A909NotificacaoAgendadaProcessamentoInicio, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( A910NotificacaoAgendadaProcessamentoFim, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A911NotificacaoAgendadaProcessamentoQtdExec", ((0==A911NotificacaoAgendadaProcessamentoQtdExec)&&IsIns( )||n911NotificacaoAgendadaProcessamentoQtdExec ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", ""))));
         AssignAttri("", false, "A912NotificacaoAgendadaProcessamentoQtdSucesso", ((0==A912NotificacaoAgendadaProcessamentoQtdSucesso)&&IsIns( )||n912NotificacaoAgendadaProcessamentoQtdSucesso ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", ""))));
         AssignAttri("", false, "A913NotificacaoAgendadaProcessamentoQtdFalhas", ((0==A913NotificacaoAgendadaProcessamentoQtdFalhas)&&IsIns( )||n913NotificacaoAgendadaProcessamentoQtdFalhas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", ""))));
         AssignAttri("", false, "A914NotificacaoAgendadaProcessamentoSituacao", A914NotificacaoAgendadaProcessamentoSituacao);
         cmbNotificacaoAgendadaProcessamentoSituacao.CurrentValue = StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao);
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoSituacao_Internalname, "Values", cmbNotificacaoAgendadaProcessamentoSituacao.ToJavascriptSource(), true);
         AssignAttri("", false, "A915NotificacaoAgendadaProcessamentoMensagemErro", A915NotificacaoAgendadaProcessamentoMensagemErro);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z908NotificacaoAgendadaProcessamentoId", Z908NotificacaoAgendadaProcessamentoId.ToString());
         GxWebStd.gx_hidden_field( context, "Z909NotificacaoAgendadaProcessamentoInicio", context.localUtil.TToC( Z909NotificacaoAgendadaProcessamentoInicio, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z910NotificacaoAgendadaProcessamentoFim", context.localUtil.TToC( Z910NotificacaoAgendadaProcessamentoFim, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z911NotificacaoAgendadaProcessamentoQtdExec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z911NotificacaoAgendadaProcessamentoQtdExec), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z912NotificacaoAgendadaProcessamentoQtdSucesso", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z912NotificacaoAgendadaProcessamentoQtdSucesso), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z913NotificacaoAgendadaProcessamentoQtdFalhas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z913NotificacaoAgendadaProcessamentoQtdFalhas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z914NotificacaoAgendadaProcessamentoSituacao", Z914NotificacaoAgendadaProcessamentoSituacao);
         GxWebStd.gx_hidden_field( context, "Z915NotificacaoAgendadaProcessamentoMensagemErro", Z915NotificacaoAgendadaProcessamentoMensagemErro);
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
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOID","""{"handler":"Valid_Notificacaoagendadaprocessamentoid","iparms":[{"av":"cmbNotificacaoAgendadaProcessamentoSituacao"},{"av":"A914NotificacaoAgendadaProcessamentoSituacao","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOSITUACAO","type":"svchar"},{"av":"A908NotificacaoAgendadaProcessamentoId","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOID","type":"guid"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOID",""","oparms":[{"av":"A909NotificacaoAgendadaProcessamentoInicio","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOINICIO","pic":"99/99/99 99:99","type":"dtime"},{"av":"A910NotificacaoAgendadaProcessamentoFim","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOFIM","pic":"99/99/99 99:99","type":"dtime"},{"av":"A911NotificacaoAgendadaProcessamentoQtdExec","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOQTDEXEC","pic":"ZZZZZZZZ9","nullAv":"n911NotificacaoAgendadaProcessamentoQtdExec","type":"int"},{"av":"A912NotificacaoAgendadaProcessamentoQtdSucesso","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOQTDSUCESSO","pic":"ZZZ9","nullAv":"n912NotificacaoAgendadaProcessamentoQtdSucesso","type":"int"},{"av":"A913NotificacaoAgendadaProcessamentoQtdFalhas","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOQTDFALHAS","pic":"ZZZ9","nullAv":"n913NotificacaoAgendadaProcessamentoQtdFalhas","type":"int"},{"av":"cmbNotificacaoAgendadaProcessamentoSituacao"},{"av":"A914NotificacaoAgendadaProcessamentoSituacao","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOSITUACAO","type":"svchar"},{"av":"A915NotificacaoAgendadaProcessamentoMensagemErro","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOMENSAGEMERRO","type":"vchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z908NotificacaoAgendadaProcessamentoId","type":"guid"},{"av":"Z909NotificacaoAgendadaProcessamentoInicio","type":"dtime"},{"av":"Z910NotificacaoAgendadaProcessamentoFim","type":"dtime"},{"av":"Z911NotificacaoAgendadaProcessamentoQtdExec","type":"int"},{"av":"Z912NotificacaoAgendadaProcessamentoQtdSucesso","type":"int"},{"av":"Z913NotificacaoAgendadaProcessamentoQtdFalhas","type":"int"},{"av":"Z914NotificacaoAgendadaProcessamentoSituacao","type":"svchar"},{"av":"Z915NotificacaoAgendadaProcessamentoMensagemErro","type":"vchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOSITUACAO","""{"handler":"Valid_Notificacaoagendadaprocessamentosituacao","iparms":[]}""");
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
         Z908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         Z909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         Z910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         Z914NotificacaoAgendadaProcessamentoSituacao = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A914NotificacaoAgendadaProcessamentoSituacao = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         A909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         A910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         A915NotificacaoAgendadaProcessamentoMensagemErro = "";
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
         Z915NotificacaoAgendadaProcessamentoMensagemErro = "";
         T002V4_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V4_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         T002V4_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         T002V4_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         T002V4_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         T002V4_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         T002V4_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         T002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         T002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         T002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         T002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         T002V4_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         T002V4_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         T002V4_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         T002V4_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         T002V5_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V3_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V3_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         T002V3_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         T002V3_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         T002V3_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         T002V3_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         T002V3_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         T002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         T002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         T002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         T002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         T002V3_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         T002V3_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         T002V3_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         T002V3_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         sMode99 = "";
         T002V6_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V7_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V2_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V2_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         T002V2_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         T002V2_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         T002V2_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         T002V2_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         T002V2_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         T002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         T002V2_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         T002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         T002V2_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         T002V2_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         T002V2_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         T002V2_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         T002V2_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         T002V11_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002V11_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002V12_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         ZZ909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         ZZ910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         ZZ914NotificacaoAgendadaProcessamentoSituacao = "";
         ZZ915NotificacaoAgendadaProcessamentoMensagemErro = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadaprocessamento__default(),
            new Object[][] {
                new Object[] {
               T002V2_A908NotificacaoAgendadaProcessamentoId, T002V2_A909NotificacaoAgendadaProcessamentoInicio, T002V2_n909NotificacaoAgendadaProcessamentoInicio, T002V2_A910NotificacaoAgendadaProcessamentoFim, T002V2_n910NotificacaoAgendadaProcessamentoFim, T002V2_A911NotificacaoAgendadaProcessamentoQtdExec, T002V2_n911NotificacaoAgendadaProcessamentoQtdExec, T002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso, T002V2_n912NotificacaoAgendadaProcessamentoQtdSucesso, T002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               T002V2_n913NotificacaoAgendadaProcessamentoQtdFalhas, T002V2_A914NotificacaoAgendadaProcessamentoSituacao, T002V2_n914NotificacaoAgendadaProcessamentoSituacao, T002V2_A915NotificacaoAgendadaProcessamentoMensagemErro, T002V2_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
               , new Object[] {
               T002V3_A908NotificacaoAgendadaProcessamentoId, T002V3_A909NotificacaoAgendadaProcessamentoInicio, T002V3_n909NotificacaoAgendadaProcessamentoInicio, T002V3_A910NotificacaoAgendadaProcessamentoFim, T002V3_n910NotificacaoAgendadaProcessamentoFim, T002V3_A911NotificacaoAgendadaProcessamentoQtdExec, T002V3_n911NotificacaoAgendadaProcessamentoQtdExec, T002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso, T002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso, T002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               T002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas, T002V3_A914NotificacaoAgendadaProcessamentoSituacao, T002V3_n914NotificacaoAgendadaProcessamentoSituacao, T002V3_A915NotificacaoAgendadaProcessamentoMensagemErro, T002V3_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
               , new Object[] {
               T002V4_A908NotificacaoAgendadaProcessamentoId, T002V4_A909NotificacaoAgendadaProcessamentoInicio, T002V4_n909NotificacaoAgendadaProcessamentoInicio, T002V4_A910NotificacaoAgendadaProcessamentoFim, T002V4_n910NotificacaoAgendadaProcessamentoFim, T002V4_A911NotificacaoAgendadaProcessamentoQtdExec, T002V4_n911NotificacaoAgendadaProcessamentoQtdExec, T002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso, T002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso, T002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               T002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas, T002V4_A914NotificacaoAgendadaProcessamentoSituacao, T002V4_n914NotificacaoAgendadaProcessamentoSituacao, T002V4_A915NotificacaoAgendadaProcessamentoMensagemErro, T002V4_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
               , new Object[] {
               T002V5_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002V6_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002V7_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002V11_A908NotificacaoAgendadaProcessamentoId, T002V11_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               T002V12_A908NotificacaoAgendadaProcessamentoId
               }
            }
         );
         Z908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
         A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
      }

      private short Z912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short Z913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private short Gx_BScreen ;
      private short RcdFound99 ;
      private short gxajaxcallmode ;
      private short ZZ912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short ZZ913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private int Z911NotificacaoAgendadaProcessamentoQtdExec ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtNotificacaoAgendadaProcessamentoId_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoInicio_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoFim_Enabled ;
      private int A911NotificacaoAgendadaProcessamentoQtdExec ;
      private int edtNotificacaoAgendadaProcessamentoQtdExec_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoQtdSucesso_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoQtdFalhas_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoMensagemErro_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ911NotificacaoAgendadaProcessamentoQtdExec ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotificacaoAgendadaProcessamentoId_Internalname ;
      private string cmbNotificacaoAgendadaProcessamentoSituacao_Internalname ;
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
      private string edtNotificacaoAgendadaProcessamentoId_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoInicio_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoInicio_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoFim_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoFim_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoQtdExec_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoQtdExec_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoQtdSucesso_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoQtdSucesso_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoQtdFalhas_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoQtdFalhas_Jsonclick ;
      private string cmbNotificacaoAgendadaProcessamentoSituacao_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoMensagemErro_Internalname ;
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
      private string sMode99 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime Z910NotificacaoAgendadaProcessamentoFim ;
      private DateTime A909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime A910NotificacaoAgendadaProcessamentoFim ;
      private DateTime ZZ909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime ZZ910NotificacaoAgendadaProcessamentoFim ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n914NotificacaoAgendadaProcessamentoSituacao ;
      private bool n911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool n909NotificacaoAgendadaProcessamentoInicio ;
      private bool n910NotificacaoAgendadaProcessamentoFim ;
      private bool n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool Gx_longc ;
      private string A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private string Z915NotificacaoAgendadaProcessamentoMensagemErro ;
      private string ZZ915NotificacaoAgendadaProcessamentoMensagemErro ;
      private string Z914NotificacaoAgendadaProcessamentoSituacao ;
      private string A914NotificacaoAgendadaProcessamentoSituacao ;
      private string ZZ914NotificacaoAgendadaProcessamentoSituacao ;
      private Guid Z908NotificacaoAgendadaProcessamentoId ;
      private Guid A908NotificacaoAgendadaProcessamentoId ;
      private Guid ZZ908NotificacaoAgendadaProcessamentoId ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNotificacaoAgendadaProcessamentoSituacao ;
      private IDataStoreProvider pr_default ;
      private Guid[] T002V4_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] T002V4_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] T002V4_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] T002V4_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] T002V4_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] T002V4_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] T002V4_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] T002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] T002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] T002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] T002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] T002V4_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] T002V4_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] T002V4_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] T002V4_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private Guid[] T002V5_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002V3_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] T002V3_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] T002V3_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] T002V3_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] T002V3_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] T002V3_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] T002V3_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] T002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] T002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] T002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] T002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] T002V3_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] T002V3_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] T002V3_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] T002V3_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private Guid[] T002V6_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002V7_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002V2_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] T002V2_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] T002V2_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] T002V2_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] T002V2_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] T002V2_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] T002V2_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] T002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] T002V2_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] T002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] T002V2_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] T002V2_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] T002V2_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] T002V2_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] T002V2_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private Guid[] T002V11_A908NotificacaoAgendadaProcessamentoId ;
      private int[] T002V11_A916NotificacaoAgendadaProcessamentoItemId ;
      private Guid[] T002V12_A908NotificacaoAgendadaProcessamentoId ;
   }

   public class notificacaoagendadaprocessamento__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002V2;
          prmT002V2 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V3;
          prmT002V3 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V4;
          prmT002V4 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V5;
          prmT002V5 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V6;
          prmT002V6 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V7;
          prmT002V7 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V8;
          prmT002V8 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoInicio",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoFim",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdExec",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdSucesso",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdFalhas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoMensagemErro",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          Object[] prmT002V9;
          prmT002V9 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoInicio",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoFim",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdExec",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdSucesso",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdFalhas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoMensagemErro",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V10;
          prmT002V10 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V11;
          prmT002V11 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002V12;
          prmT002V12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002V2", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId  FOR UPDATE OF NotificacaoAgendadaProcessamento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002V2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002V3", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002V4", "SELECT TM1.NotificacaoAgendadaProcessamentoId, TM1.NotificacaoAgendadaProcessamentoInicio, TM1.NotificacaoAgendadaProcessamentoFim, TM1.NotificacaoAgendadaProcessamentoQtdExec, TM1.NotificacaoAgendadaProcessamentoQtdSucesso, TM1.NotificacaoAgendadaProcessamentoQtdFalhas, TM1.NotificacaoAgendadaProcessamentoSituacao, TM1.NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento TM1 WHERE TM1.NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ORDER BY TM1.NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002V5", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002V6", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE ( NotificacaoAgendadaProcessamentoId > :NotificacaoAgendadaProcessamentoId) ORDER BY NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002V7", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE ( NotificacaoAgendadaProcessamentoId < :NotificacaoAgendadaProcessamentoId) ORDER BY NotificacaoAgendadaProcessamentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002V8", "SAVEPOINT gxupdate;INSERT INTO NotificacaoAgendadaProcessamento(NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro) VALUES(:NotificacaoAgendadaProcessamentoId, :NotificacaoAgendadaProcessamentoInicio, :NotificacaoAgendadaProcessamentoFim, :NotificacaoAgendadaProcessamentoQtdExec, :NotificacaoAgendadaProcessamentoQtdSucesso, :NotificacaoAgendadaProcessamentoQtdFalhas, :NotificacaoAgendadaProcessamentoSituacao, :NotificacaoAgendadaProcessamentoMensagemErro);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002V8)
             ,new CursorDef("T002V9", "SAVEPOINT gxupdate;UPDATE NotificacaoAgendadaProcessamento SET NotificacaoAgendadaProcessamentoInicio=:NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim=:NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec=:NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso=:NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas=:NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao=:NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro=:NotificacaoAgendadaProcessamentoMensagemErro  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002V9)
             ,new CursorDef("T002V10", "SAVEPOINT gxupdate;DELETE FROM NotificacaoAgendadaProcessamento  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002V10)
             ,new CursorDef("T002V11", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002V12", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento ORDER BY NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V12,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
