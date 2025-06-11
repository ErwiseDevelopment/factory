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
   public class notificacaoagendadaprocessamentoitem : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A908NotificacaoAgendadaProcessamentoId = StringUtil.StrToGuid( GetPar( "NotificacaoAgendadaProcessamentoId"));
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A908NotificacaoAgendadaProcessamentoId) ;
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
         Form.Meta.addItem("description", "Items do processamento de notificações agendadas", 0) ;
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

      public notificacaoagendadaprocessamentoitem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadaprocessamentoitem( IGxContext context )
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
         cmbNotificacaoAgendadaProcessamentoItemTipo = new GXCombobox();
         cmbNotificacaoAgendadaProcessamentoItemSituacao = new GXCombobox();
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
         if ( cmbNotificacaoAgendadaProcessamentoItemTipo.ItemCount > 0 )
         {
            A919NotificacaoAgendadaProcessamentoItemTipo = cmbNotificacaoAgendadaProcessamentoItemTipo.getValidValue(A919NotificacaoAgendadaProcessamentoItemTipo);
            n919NotificacaoAgendadaProcessamentoItemTipo = false;
            AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo);
            AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname, "Values", cmbNotificacaoAgendadaProcessamentoItemTipo.ToJavascriptSource(), true);
         }
         if ( cmbNotificacaoAgendadaProcessamentoItemSituacao.ItemCount > 0 )
         {
            A920NotificacaoAgendadaProcessamentoItemSituacao = cmbNotificacaoAgendadaProcessamentoItemSituacao.getValidValue(A920NotificacaoAgendadaProcessamentoItemSituacao);
            n920NotificacaoAgendadaProcessamentoItemSituacao = false;
            AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao);
            AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname, "Values", cmbNotificacaoAgendadaProcessamentoItemSituacao.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Items do processamento de notificações agendadas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_NotificacaoAgendadaProcessamentoItem.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_NotificacaoAgendadaProcessamentoItem.htm");
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
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoId_Internalname, "Id do processamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoId_Internalname, A908NotificacaoAgendadaProcessamentoId.ToString(), A908NotificacaoAgendadaProcessamentoId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoItemId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoItemId_Internalname, "do processamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoItemId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0, ",", "")), StringUtil.LTrim( ((edtNotificacaoAgendadaProcessamentoItemId_Enabled!=0) ? context.localUtil.Format( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoItemId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoItemId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname, "da execução", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname, context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A917NotificacaoAgendadaProcessamentoItemExecucao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaProcessamentoItemExecucao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificacaoAgendadaProcessamentoItemExecucao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_bitmap( context, edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotificacaoAgendadaProcessamentoItemExecucao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_NotificacaoAgendadaProcessamentoItem.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoItemJson_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoItemJson_Internalname, "Json", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNotificacaoAgendadaProcessamentoItemJson_Internalname, A918NotificacaoAgendadaProcessamentoItemJson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtNotificacaoAgendadaProcessamentoItemJson_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname, "de processamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaProcessamentoItemTipo, cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname, StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo), 1, cmbNotificacaoAgendadaProcessamentoItemTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificacaoAgendadaProcessamentoItemTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo);
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname, "Values", (string)(cmbNotificacaoAgendadaProcessamentoItemTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname, "de processamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaProcessamentoItemSituacao, cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname, StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao), 1, cmbNotificacaoAgendadaProcessamentoItemSituacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificacaoAgendadaProcessamentoItemSituacao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao);
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname, "Values", (string)(cmbNotificacaoAgendadaProcessamentoItemSituacao.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname, "de retorno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname, A921NotificacaoAgendadaProcessamentoItemRetorno, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtNotificacaoAgendadaProcessamentoItemRetorno_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_NotificacaoAgendadaProcessamentoItem.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaProcessamentoItem.htm");
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
            Z916NotificacaoAgendadaProcessamentoItemId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z916NotificacaoAgendadaProcessamentoItemId"), ",", "."), 18, MidpointRounding.ToEven));
            Z917NotificacaoAgendadaProcessamentoItemExecucao = context.localUtil.CToT( cgiGet( "Z917NotificacaoAgendadaProcessamentoItemExecucao"), 0);
            n917NotificacaoAgendadaProcessamentoItemExecucao = ((DateTime.MinValue==A917NotificacaoAgendadaProcessamentoItemExecucao) ? true : false);
            Z919NotificacaoAgendadaProcessamentoItemTipo = cgiGet( "Z919NotificacaoAgendadaProcessamentoItemTipo");
            n919NotificacaoAgendadaProcessamentoItemTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo)) ? true : false);
            Z920NotificacaoAgendadaProcessamentoItemSituacao = cgiGet( "Z920NotificacaoAgendadaProcessamentoItemSituacao");
            n920NotificacaoAgendadaProcessamentoItemSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao)) ? true : false);
            Z921NotificacaoAgendadaProcessamentoItemRetorno = cgiGet( "Z921NotificacaoAgendadaProcessamentoItemRetorno");
            n921NotificacaoAgendadaProcessamentoItemRetorno = (String.IsNullOrEmpty(StringUtil.RTrim( A921NotificacaoAgendadaProcessamentoItemRetorno)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoItemId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoItemId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOITEMID");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A916NotificacaoAgendadaProcessamentoItemId = 0;
               AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
            }
            else
            {
               A916NotificacaoAgendadaProcessamentoItemId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaProcessamentoItemId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data e hora da execução"}), 1, "NOTIFICACAOAGENDADAPROCESSAMENTOITEMEXECUCAO");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
               n917NotificacaoAgendadaProcessamentoItemExecucao = false;
               AssignAttri("", false, "A917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A917NotificacaoAgendadaProcessamentoItemExecucao = context.localUtil.CToT( cgiGet( edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname));
               n917NotificacaoAgendadaProcessamentoItemExecucao = false;
               AssignAttri("", false, "A917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 8, 5, 0, 3, "/", ":", " "));
            }
            n917NotificacaoAgendadaProcessamentoItemExecucao = ((DateTime.MinValue==A917NotificacaoAgendadaProcessamentoItemExecucao) ? true : false);
            A918NotificacaoAgendadaProcessamentoItemJson = cgiGet( edtNotificacaoAgendadaProcessamentoItemJson_Internalname);
            n918NotificacaoAgendadaProcessamentoItemJson = false;
            AssignAttri("", false, "A918NotificacaoAgendadaProcessamentoItemJson", A918NotificacaoAgendadaProcessamentoItemJson);
            n918NotificacaoAgendadaProcessamentoItemJson = (String.IsNullOrEmpty(StringUtil.RTrim( A918NotificacaoAgendadaProcessamentoItemJson)) ? true : false);
            cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = cgiGet( cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname);
            A919NotificacaoAgendadaProcessamentoItemTipo = cgiGet( cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname);
            n919NotificacaoAgendadaProcessamentoItemTipo = false;
            AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
            n919NotificacaoAgendadaProcessamentoItemTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo)) ? true : false);
            cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = cgiGet( cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname);
            A920NotificacaoAgendadaProcessamentoItemSituacao = cgiGet( cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname);
            n920NotificacaoAgendadaProcessamentoItemSituacao = false;
            AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
            n920NotificacaoAgendadaProcessamentoItemSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao)) ? true : false);
            A921NotificacaoAgendadaProcessamentoItemRetorno = cgiGet( edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname);
            n921NotificacaoAgendadaProcessamentoItemRetorno = false;
            AssignAttri("", false, "A921NotificacaoAgendadaProcessamentoItemRetorno", A921NotificacaoAgendadaProcessamentoItemRetorno);
            n921NotificacaoAgendadaProcessamentoItemRetorno = (String.IsNullOrEmpty(StringUtil.RTrim( A921NotificacaoAgendadaProcessamentoItemRetorno)) ? true : false);
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
               A916NotificacaoAgendadaProcessamentoItemId = (int)(Math.Round(NumberUtil.Val( GetPar( "NotificacaoAgendadaProcessamentoItemId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
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
               InitAll2W100( ) ;
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
         DisableAttributes2W100( ) ;
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

      protected void ResetCaption2W0( )
      {
      }

      protected void ZM2W100( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z917NotificacaoAgendadaProcessamentoItemExecucao = T002W3_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
               Z919NotificacaoAgendadaProcessamentoItemTipo = T002W3_A919NotificacaoAgendadaProcessamentoItemTipo[0];
               Z920NotificacaoAgendadaProcessamentoItemSituacao = T002W3_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
               Z921NotificacaoAgendadaProcessamentoItemRetorno = T002W3_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            }
            else
            {
               Z917NotificacaoAgendadaProcessamentoItemExecucao = A917NotificacaoAgendadaProcessamentoItemExecucao;
               Z919NotificacaoAgendadaProcessamentoItemTipo = A919NotificacaoAgendadaProcessamentoItemTipo;
               Z920NotificacaoAgendadaProcessamentoItemSituacao = A920NotificacaoAgendadaProcessamentoItemSituacao;
               Z921NotificacaoAgendadaProcessamentoItemRetorno = A921NotificacaoAgendadaProcessamentoItemRetorno;
            }
         }
         if ( GX_JID == -4 )
         {
            Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
            Z917NotificacaoAgendadaProcessamentoItemExecucao = A917NotificacaoAgendadaProcessamentoItemExecucao;
            Z918NotificacaoAgendadaProcessamentoItemJson = A918NotificacaoAgendadaProcessamentoItemJson;
            Z919NotificacaoAgendadaProcessamentoItemTipo = A919NotificacaoAgendadaProcessamentoItemTipo;
            Z920NotificacaoAgendadaProcessamentoItemSituacao = A920NotificacaoAgendadaProcessamentoItemSituacao;
            Z921NotificacaoAgendadaProcessamentoItemRetorno = A921NotificacaoAgendadaProcessamentoItemRetorno;
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
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

      protected void Load2W100( )
      {
         /* Using cursor T002W5 */
         pr_default.execute(3, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound100 = 1;
            A917NotificacaoAgendadaProcessamentoItemExecucao = T002W5_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
            n917NotificacaoAgendadaProcessamentoItemExecucao = T002W5_n917NotificacaoAgendadaProcessamentoItemExecucao[0];
            AssignAttri("", false, "A917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 8, 5, 0, 3, "/", ":", " "));
            A918NotificacaoAgendadaProcessamentoItemJson = T002W5_A918NotificacaoAgendadaProcessamentoItemJson[0];
            n918NotificacaoAgendadaProcessamentoItemJson = T002W5_n918NotificacaoAgendadaProcessamentoItemJson[0];
            AssignAttri("", false, "A918NotificacaoAgendadaProcessamentoItemJson", A918NotificacaoAgendadaProcessamentoItemJson);
            A919NotificacaoAgendadaProcessamentoItemTipo = T002W5_A919NotificacaoAgendadaProcessamentoItemTipo[0];
            n919NotificacaoAgendadaProcessamentoItemTipo = T002W5_n919NotificacaoAgendadaProcessamentoItemTipo[0];
            AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
            A920NotificacaoAgendadaProcessamentoItemSituacao = T002W5_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
            n920NotificacaoAgendadaProcessamentoItemSituacao = T002W5_n920NotificacaoAgendadaProcessamentoItemSituacao[0];
            AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
            A921NotificacaoAgendadaProcessamentoItemRetorno = T002W5_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            n921NotificacaoAgendadaProcessamentoItemRetorno = T002W5_n921NotificacaoAgendadaProcessamentoItemRetorno[0];
            AssignAttri("", false, "A921NotificacaoAgendadaProcessamentoItemRetorno", A921NotificacaoAgendadaProcessamentoItemRetorno);
            ZM2W100( -4) ;
         }
         pr_default.close(3);
         OnLoadActions2W100( ) ;
      }

      protected void OnLoadActions2W100( )
      {
      }

      protected void CheckExtendedTable2W100( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002W4 */
         pr_default.execute(2, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A919NotificacaoAgendadaProcessamentoItemTipo, "V") == 0 ) || ( StringUtil.StrCmp(A919NotificacaoAgendadaProcessamentoItemTipo, "P") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo de processamento fora do intervalo", "OutOfRange", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOITEMTIPO");
            AnyError = 1;
            GX_FocusControl = cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "F") == 0 ) || ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "P") == 0 ) || ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "S") == 0 ) || ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "E") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao)) ) )
         {
            GX_msglist.addItem("Campo Situação do item de processamento fora do intervalo", "OutOfRange", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOITEMSITUACAO");
            AnyError = 1;
            GX_FocusControl = cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2W100( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( Guid A908NotificacaoAgendadaProcessamentoId )
      {
         /* Using cursor T002W6 */
         pr_default.execute(4, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey2W100( )
      {
         /* Using cursor T002W7 */
         pr_default.execute(5, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound100 = 1;
         }
         else
         {
            RcdFound100 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002W3 */
         pr_default.execute(1, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2W100( 4) ;
            RcdFound100 = 1;
            A916NotificacaoAgendadaProcessamentoItemId = T002W3_A916NotificacaoAgendadaProcessamentoItemId[0];
            AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
            A917NotificacaoAgendadaProcessamentoItemExecucao = T002W3_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
            n917NotificacaoAgendadaProcessamentoItemExecucao = T002W3_n917NotificacaoAgendadaProcessamentoItemExecucao[0];
            AssignAttri("", false, "A917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 8, 5, 0, 3, "/", ":", " "));
            A918NotificacaoAgendadaProcessamentoItemJson = T002W3_A918NotificacaoAgendadaProcessamentoItemJson[0];
            n918NotificacaoAgendadaProcessamentoItemJson = T002W3_n918NotificacaoAgendadaProcessamentoItemJson[0];
            AssignAttri("", false, "A918NotificacaoAgendadaProcessamentoItemJson", A918NotificacaoAgendadaProcessamentoItemJson);
            A919NotificacaoAgendadaProcessamentoItemTipo = T002W3_A919NotificacaoAgendadaProcessamentoItemTipo[0];
            n919NotificacaoAgendadaProcessamentoItemTipo = T002W3_n919NotificacaoAgendadaProcessamentoItemTipo[0];
            AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
            A920NotificacaoAgendadaProcessamentoItemSituacao = T002W3_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
            n920NotificacaoAgendadaProcessamentoItemSituacao = T002W3_n920NotificacaoAgendadaProcessamentoItemSituacao[0];
            AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
            A921NotificacaoAgendadaProcessamentoItemRetorno = T002W3_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            n921NotificacaoAgendadaProcessamentoItemRetorno = T002W3_n921NotificacaoAgendadaProcessamentoItemRetorno[0];
            AssignAttri("", false, "A921NotificacaoAgendadaProcessamentoItemRetorno", A921NotificacaoAgendadaProcessamentoItemRetorno);
            A908NotificacaoAgendadaProcessamentoId = T002W3_A908NotificacaoAgendadaProcessamentoId[0];
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2W100( ) ;
            if ( AnyError == 1 )
            {
               RcdFound100 = 0;
               InitializeNonKey2W100( ) ;
            }
            Gx_mode = sMode100;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound100 = 0;
            InitializeNonKey2W100( ) ;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode100;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2W100( ) ;
         if ( RcdFound100 == 0 )
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
         RcdFound100 = 0;
         /* Using cursor T002W8 */
         pr_default.execute(6, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T002W8_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) < 0 ) || ( T002W8_A908NotificacaoAgendadaProcessamentoId[0] == A908NotificacaoAgendadaProcessamentoId ) && ( T002W8_A916NotificacaoAgendadaProcessamentoItemId[0] < A916NotificacaoAgendadaProcessamentoItemId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T002W8_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) > 0 ) || ( T002W8_A908NotificacaoAgendadaProcessamentoId[0] == A908NotificacaoAgendadaProcessamentoId ) && ( T002W8_A916NotificacaoAgendadaProcessamentoItemId[0] > A916NotificacaoAgendadaProcessamentoItemId ) ) )
            {
               A908NotificacaoAgendadaProcessamentoId = T002W8_A908NotificacaoAgendadaProcessamentoId[0];
               AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               A916NotificacaoAgendadaProcessamentoItemId = T002W8_A916NotificacaoAgendadaProcessamentoItemId[0];
               AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
               RcdFound100 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound100 = 0;
         /* Using cursor T002W9 */
         pr_default.execute(7, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T002W9_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) > 0 ) || ( T002W9_A908NotificacaoAgendadaProcessamentoId[0] == A908NotificacaoAgendadaProcessamentoId ) && ( T002W9_A916NotificacaoAgendadaProcessamentoItemId[0] > A916NotificacaoAgendadaProcessamentoItemId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T002W9_A908NotificacaoAgendadaProcessamentoId[0], A908NotificacaoAgendadaProcessamentoId, 0) < 0 ) || ( T002W9_A908NotificacaoAgendadaProcessamentoId[0] == A908NotificacaoAgendadaProcessamentoId ) && ( T002W9_A916NotificacaoAgendadaProcessamentoItemId[0] < A916NotificacaoAgendadaProcessamentoItemId ) ) )
            {
               A908NotificacaoAgendadaProcessamentoId = T002W9_A908NotificacaoAgendadaProcessamentoId[0];
               AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
               A916NotificacaoAgendadaProcessamentoItemId = T002W9_A916NotificacaoAgendadaProcessamentoItemId[0];
               AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
               RcdFound100 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2W100( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2W100( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound100 == 1 )
            {
               if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
               {
                  A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
                  AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
                  A916NotificacaoAgendadaProcessamentoItemId = Z916NotificacaoAgendadaProcessamentoItemId;
                  AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
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
                  Update2W100( ) ;
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2W100( ) ;
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
                     Insert2W100( ) ;
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
         if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
         {
            A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            A916NotificacaoAgendadaProcessamentoItemId = Z916NotificacaoAgendadaProcessamentoItemId;
            AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
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
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2W100( ) ;
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2W100( ) ;
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
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
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
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
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
         ScanStart2W100( ) ;
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound100 != 0 )
            {
               ScanNext2W100( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2W100( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2W100( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002W2 */
            pr_default.execute(0, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z917NotificacaoAgendadaProcessamentoItemExecucao != T002W2_A917NotificacaoAgendadaProcessamentoItemExecucao[0] ) || ( StringUtil.StrCmp(Z919NotificacaoAgendadaProcessamentoItemTipo, T002W2_A919NotificacaoAgendadaProcessamentoItemTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z920NotificacaoAgendadaProcessamentoItemSituacao, T002W2_A920NotificacaoAgendadaProcessamentoItemSituacao[0]) != 0 ) || ( StringUtil.StrCmp(Z921NotificacaoAgendadaProcessamentoItemRetorno, T002W2_A921NotificacaoAgendadaProcessamentoItemRetorno[0]) != 0 ) )
            {
               if ( Z917NotificacaoAgendadaProcessamentoItemExecucao != T002W2_A917NotificacaoAgendadaProcessamentoItemExecucao[0] )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamentoitem:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoItemExecucao");
                  GXUtil.WriteLogRaw("Old: ",Z917NotificacaoAgendadaProcessamentoItemExecucao);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A917NotificacaoAgendadaProcessamentoItemExecucao[0]);
               }
               if ( StringUtil.StrCmp(Z919NotificacaoAgendadaProcessamentoItemTipo, T002W2_A919NotificacaoAgendadaProcessamentoItemTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamentoitem:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoItemTipo");
                  GXUtil.WriteLogRaw("Old: ",Z919NotificacaoAgendadaProcessamentoItemTipo);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A919NotificacaoAgendadaProcessamentoItemTipo[0]);
               }
               if ( StringUtil.StrCmp(Z920NotificacaoAgendadaProcessamentoItemSituacao, T002W2_A920NotificacaoAgendadaProcessamentoItemSituacao[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamentoitem:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoItemSituacao");
                  GXUtil.WriteLogRaw("Old: ",Z920NotificacaoAgendadaProcessamentoItemSituacao);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A920NotificacaoAgendadaProcessamentoItemSituacao[0]);
               }
               if ( StringUtil.StrCmp(Z921NotificacaoAgendadaProcessamentoItemRetorno, T002W2_A921NotificacaoAgendadaProcessamentoItemRetorno[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendadaprocessamentoitem:[seudo value changed for attri]"+"NotificacaoAgendadaProcessamentoItemRetorno");
                  GXUtil.WriteLogRaw("Old: ",Z921NotificacaoAgendadaProcessamentoItemRetorno);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A921NotificacaoAgendadaProcessamentoItemRetorno[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2W100( )
      {
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2W100( 0) ;
            CheckOptimisticConcurrency2W100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2W100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002W10 */
                     pr_default.execute(8, new Object[] {A916NotificacaoAgendadaProcessamentoItemId, n917NotificacaoAgendadaProcessamentoItemExecucao, A917NotificacaoAgendadaProcessamentoItemExecucao, n918NotificacaoAgendadaProcessamentoItemJson, A918NotificacaoAgendadaProcessamentoItemJson, n919NotificacaoAgendadaProcessamentoItemTipo, A919NotificacaoAgendadaProcessamentoItemTipo, n920NotificacaoAgendadaProcessamentoItemSituacao, A920NotificacaoAgendadaProcessamentoItemSituacao, n921NotificacaoAgendadaProcessamentoItemRetorno, A921NotificacaoAgendadaProcessamentoItemRetorno, A908NotificacaoAgendadaProcessamentoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamentoItem");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption2W0( ) ;
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
               Load2W100( ) ;
            }
            EndLevel2W100( ) ;
         }
         CloseExtendedTableCursors2W100( ) ;
      }

      protected void Update2W100( )
      {
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2W100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002W11 */
                     pr_default.execute(9, new Object[] {n917NotificacaoAgendadaProcessamentoItemExecucao, A917NotificacaoAgendadaProcessamentoItemExecucao, n918NotificacaoAgendadaProcessamentoItemJson, A918NotificacaoAgendadaProcessamentoItemJson, n919NotificacaoAgendadaProcessamentoItemTipo, A919NotificacaoAgendadaProcessamentoItemTipo, n920NotificacaoAgendadaProcessamentoItemSituacao, A920NotificacaoAgendadaProcessamentoItemSituacao, n921NotificacaoAgendadaProcessamentoItemRetorno, A921NotificacaoAgendadaProcessamentoItemRetorno, A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamentoItem");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2W100( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2W0( ) ;
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
            EndLevel2W100( ) ;
         }
         CloseExtendedTableCursors2W100( ) ;
      }

      protected void DeferredUpdate2W100( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2W100( ) ;
            AfterConfirm2W100( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2W100( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002W12 */
                  pr_default.execute(10, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamentoItem");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound100 == 0 )
                        {
                           InitAll2W100( ) ;
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
                        ResetCaption2W0( ) ;
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
         sMode100 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2W100( ) ;
         Gx_mode = sMode100;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2W100( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2W100( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2W0( ) ;
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

      public void ScanStart2W100( )
      {
         /* Using cursor T002W13 */
         pr_default.execute(11);
         RcdFound100 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound100 = 1;
            A908NotificacaoAgendadaProcessamentoId = T002W13_A908NotificacaoAgendadaProcessamentoId[0];
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            A916NotificacaoAgendadaProcessamentoItemId = T002W13_A916NotificacaoAgendadaProcessamentoItemId[0];
            AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2W100( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound100 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound100 = 1;
            A908NotificacaoAgendadaProcessamentoId = T002W13_A908NotificacaoAgendadaProcessamentoId[0];
            AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
            A916NotificacaoAgendadaProcessamentoItemId = T002W13_A916NotificacaoAgendadaProcessamentoItemId[0];
            AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
         }
      }

      protected void ScanEnd2W100( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2W100( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2W100( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2W100( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2W100( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2W100( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2W100( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2W100( )
      {
         edtNotificacaoAgendadaProcessamentoId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoId_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoItemId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoItemId_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoItemExecucao_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoItemExecucao_Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoItemJson_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoItemJson_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoItemJson_Enabled), 5, 0), true);
         cmbNotificacaoAgendadaProcessamentoItemTipo.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaProcessamentoItemTipo.Enabled), 5, 0), true);
         cmbNotificacaoAgendadaProcessamentoItemSituacao.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaProcessamentoItemSituacao.Enabled), 5, 0), true);
         edtNotificacaoAgendadaProcessamentoItemRetorno_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaProcessamentoItemRetorno_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2W100( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2W0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notificacaoagendadaprocessamentoitem") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z916NotificacaoAgendadaProcessamentoItemId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( Z917NotificacaoAgendadaProcessamentoItemExecucao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z919NotificacaoAgendadaProcessamentoItemTipo", Z919NotificacaoAgendadaProcessamentoItemTipo);
         GxWebStd.gx_hidden_field( context, "Z920NotificacaoAgendadaProcessamentoItemSituacao", Z920NotificacaoAgendadaProcessamentoItemSituacao);
         GxWebStd.gx_hidden_field( context, "Z921NotificacaoAgendadaProcessamentoItemRetorno", Z921NotificacaoAgendadaProcessamentoItemRetorno);
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
         return formatLink("notificacaoagendadaprocessamentoitem")  ;
      }

      public override string GetPgmname( )
      {
         return "NotificacaoAgendadaProcessamentoItem" ;
      }

      public override string GetPgmdesc( )
      {
         return "Items do processamento de notificações agendadas" ;
      }

      protected void InitializeNonKey2W100( )
      {
         A917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         n917NotificacaoAgendadaProcessamentoItemExecucao = false;
         AssignAttri("", false, "A917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 8, 5, 0, 3, "/", ":", " "));
         n917NotificacaoAgendadaProcessamentoItemExecucao = ((DateTime.MinValue==A917NotificacaoAgendadaProcessamentoItemExecucao) ? true : false);
         A918NotificacaoAgendadaProcessamentoItemJson = "";
         n918NotificacaoAgendadaProcessamentoItemJson = false;
         AssignAttri("", false, "A918NotificacaoAgendadaProcessamentoItemJson", A918NotificacaoAgendadaProcessamentoItemJson);
         n918NotificacaoAgendadaProcessamentoItemJson = (String.IsNullOrEmpty(StringUtil.RTrim( A918NotificacaoAgendadaProcessamentoItemJson)) ? true : false);
         A919NotificacaoAgendadaProcessamentoItemTipo = "";
         n919NotificacaoAgendadaProcessamentoItemTipo = false;
         AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
         n919NotificacaoAgendadaProcessamentoItemTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo)) ? true : false);
         A920NotificacaoAgendadaProcessamentoItemSituacao = "";
         n920NotificacaoAgendadaProcessamentoItemSituacao = false;
         AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
         n920NotificacaoAgendadaProcessamentoItemSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao)) ? true : false);
         A921NotificacaoAgendadaProcessamentoItemRetorno = "";
         n921NotificacaoAgendadaProcessamentoItemRetorno = false;
         AssignAttri("", false, "A921NotificacaoAgendadaProcessamentoItemRetorno", A921NotificacaoAgendadaProcessamentoItemRetorno);
         n921NotificacaoAgendadaProcessamentoItemRetorno = (String.IsNullOrEmpty(StringUtil.RTrim( A921NotificacaoAgendadaProcessamentoItemRetorno)) ? true : false);
         Z917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         Z919NotificacaoAgendadaProcessamentoItemTipo = "";
         Z920NotificacaoAgendadaProcessamentoItemSituacao = "";
         Z921NotificacaoAgendadaProcessamentoItemRetorno = "";
      }

      protected void InitAll2W100( )
      {
         A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         AssignAttri("", false, "A908NotificacaoAgendadaProcessamentoId", A908NotificacaoAgendadaProcessamentoId.ToString());
         A916NotificacaoAgendadaProcessamentoItemId = 0;
         AssignAttri("", false, "A916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrimStr( (decimal)(A916NotificacaoAgendadaProcessamentoItemId), 9, 0));
         InitializeNonKey2W100( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101921464", true, true);
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
         context.AddJavascriptSource("notificacaoagendadaprocessamentoitem.js", "?20256101921465", false, true);
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
         edtNotificacaoAgendadaProcessamentoItemId_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMID";
         edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMEXECUCAO";
         edtNotificacaoAgendadaProcessamentoItemJson_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMJSON";
         cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMTIPO";
         cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMSITUACAO";
         edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMRETORNO";
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
         Form.Caption = "Items do processamento de notificações agendadas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNotificacaoAgendadaProcessamentoItemRetorno_Enabled = 1;
         cmbNotificacaoAgendadaProcessamentoItemSituacao_Jsonclick = "";
         cmbNotificacaoAgendadaProcessamentoItemSituacao.Enabled = 1;
         cmbNotificacaoAgendadaProcessamentoItemTipo_Jsonclick = "";
         cmbNotificacaoAgendadaProcessamentoItemTipo.Enabled = 1;
         edtNotificacaoAgendadaProcessamentoItemJson_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoItemExecucao_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoItemExecucao_Enabled = 1;
         edtNotificacaoAgendadaProcessamentoItemId_Jsonclick = "";
         edtNotificacaoAgendadaProcessamentoItemId_Enabled = 1;
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
         cmbNotificacaoAgendadaProcessamentoItemTipo.Name = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMTIPO";
         cmbNotificacaoAgendadaProcessamentoItemTipo.WebTags = "";
         cmbNotificacaoAgendadaProcessamentoItemTipo.addItem("V", "Título vencido", 0);
         cmbNotificacaoAgendadaProcessamentoItemTipo.addItem("P", "Vencimento de título próximo", 0);
         if ( cmbNotificacaoAgendadaProcessamentoItemTipo.ItemCount > 0 )
         {
            A919NotificacaoAgendadaProcessamentoItemTipo = cmbNotificacaoAgendadaProcessamentoItemTipo.getValidValue(A919NotificacaoAgendadaProcessamentoItemTipo);
            n919NotificacaoAgendadaProcessamentoItemTipo = false;
            AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
         }
         cmbNotificacaoAgendadaProcessamentoItemSituacao.Name = "NOTIFICACAOAGENDADAPROCESSAMENTOITEMSITUACAO";
         cmbNotificacaoAgendadaProcessamentoItemSituacao.WebTags = "";
         cmbNotificacaoAgendadaProcessamentoItemSituacao.addItem("F", "Finalizado", 0);
         cmbNotificacaoAgendadaProcessamentoItemSituacao.addItem("P", "Processando", 0);
         cmbNotificacaoAgendadaProcessamentoItemSituacao.addItem("S", "Sucesso", 0);
         cmbNotificacaoAgendadaProcessamentoItemSituacao.addItem("E", "Falhou", 0);
         if ( cmbNotificacaoAgendadaProcessamentoItemSituacao.ItemCount > 0 )
         {
            A920NotificacaoAgendadaProcessamentoItemSituacao = cmbNotificacaoAgendadaProcessamentoItemSituacao.getValidValue(A920NotificacaoAgendadaProcessamentoItemSituacao);
            n920NotificacaoAgendadaProcessamentoItemSituacao = false;
            AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T002W14 */
         pr_default.execute(12, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname;
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
         /* Using cursor T002W14 */
         pr_default.execute(12, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaProcessamentoId_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Notificacaoagendadaprocessamentoitemid( )
      {
         n920NotificacaoAgendadaProcessamentoItemSituacao = false;
         A920NotificacaoAgendadaProcessamentoItemSituacao = cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue;
         n920NotificacaoAgendadaProcessamentoItemSituacao = false;
         cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = A920NotificacaoAgendadaProcessamentoItemSituacao;
         n919NotificacaoAgendadaProcessamentoItemTipo = false;
         A919NotificacaoAgendadaProcessamentoItemTipo = cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue;
         n919NotificacaoAgendadaProcessamentoItemTipo = false;
         cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = A919NotificacaoAgendadaProcessamentoItemTipo;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbNotificacaoAgendadaProcessamentoItemTipo.ItemCount > 0 )
         {
            A919NotificacaoAgendadaProcessamentoItemTipo = cmbNotificacaoAgendadaProcessamentoItemTipo.getValidValue(A919NotificacaoAgendadaProcessamentoItemTipo);
            n919NotificacaoAgendadaProcessamentoItemTipo = false;
            cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = A919NotificacaoAgendadaProcessamentoItemTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo);
         }
         if ( cmbNotificacaoAgendadaProcessamentoItemSituacao.ItemCount > 0 )
         {
            A920NotificacaoAgendadaProcessamentoItemSituacao = cmbNotificacaoAgendadaProcessamentoItemSituacao.getValidValue(A920NotificacaoAgendadaProcessamentoItemSituacao);
            n920NotificacaoAgendadaProcessamentoItemSituacao = false;
            cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = A920NotificacaoAgendadaProcessamentoItemSituacao;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( A917NotificacaoAgendadaProcessamentoItemExecucao, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A918NotificacaoAgendadaProcessamentoItemJson", A918NotificacaoAgendadaProcessamentoItemJson);
         AssignAttri("", false, "A919NotificacaoAgendadaProcessamentoItemTipo", A919NotificacaoAgendadaProcessamentoItemTipo);
         cmbNotificacaoAgendadaProcessamentoItemTipo.CurrentValue = StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo);
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname, "Values", cmbNotificacaoAgendadaProcessamentoItemTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A920NotificacaoAgendadaProcessamentoItemSituacao", A920NotificacaoAgendadaProcessamentoItemSituacao);
         cmbNotificacaoAgendadaProcessamentoItemSituacao.CurrentValue = StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao);
         AssignProp("", false, cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname, "Values", cmbNotificacaoAgendadaProcessamentoItemSituacao.ToJavascriptSource(), true);
         AssignAttri("", false, "A921NotificacaoAgendadaProcessamentoItemRetorno", A921NotificacaoAgendadaProcessamentoItemRetorno);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z908NotificacaoAgendadaProcessamentoId", Z908NotificacaoAgendadaProcessamentoId.ToString());
         GxWebStd.gx_hidden_field( context, "Z916NotificacaoAgendadaProcessamentoItemId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z916NotificacaoAgendadaProcessamentoItemId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z917NotificacaoAgendadaProcessamentoItemExecucao", context.localUtil.TToC( Z917NotificacaoAgendadaProcessamentoItemExecucao, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z918NotificacaoAgendadaProcessamentoItemJson", Z918NotificacaoAgendadaProcessamentoItemJson);
         GxWebStd.gx_hidden_field( context, "Z919NotificacaoAgendadaProcessamentoItemTipo", Z919NotificacaoAgendadaProcessamentoItemTipo);
         GxWebStd.gx_hidden_field( context, "Z920NotificacaoAgendadaProcessamentoItemSituacao", Z920NotificacaoAgendadaProcessamentoItemSituacao);
         GxWebStd.gx_hidden_field( context, "Z921NotificacaoAgendadaProcessamentoItemRetorno", Z921NotificacaoAgendadaProcessamentoItemRetorno);
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
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOID","""{"handler":"Valid_Notificacaoagendadaprocessamentoid","iparms":[{"av":"A908NotificacaoAgendadaProcessamentoId","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOID","type":"guid"}]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOITEMID","""{"handler":"Valid_Notificacaoagendadaprocessamentoitemid","iparms":[{"av":"cmbNotificacaoAgendadaProcessamentoItemSituacao"},{"av":"A920NotificacaoAgendadaProcessamentoItemSituacao","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMSITUACAO","type":"svchar"},{"av":"cmbNotificacaoAgendadaProcessamentoItemTipo"},{"av":"A919NotificacaoAgendadaProcessamentoItemTipo","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMTIPO","type":"svchar"},{"av":"A908NotificacaoAgendadaProcessamentoId","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOID","type":"guid"},{"av":"A916NotificacaoAgendadaProcessamentoItemId","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOITEMID",""","oparms":[{"av":"A917NotificacaoAgendadaProcessamentoItemExecucao","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMEXECUCAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"A918NotificacaoAgendadaProcessamentoItemJson","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMJSON","type":"vchar"},{"av":"cmbNotificacaoAgendadaProcessamentoItemTipo"},{"av":"A919NotificacaoAgendadaProcessamentoItemTipo","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMTIPO","type":"svchar"},{"av":"cmbNotificacaoAgendadaProcessamentoItemSituacao"},{"av":"A920NotificacaoAgendadaProcessamentoItemSituacao","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMSITUACAO","type":"svchar"},{"av":"A921NotificacaoAgendadaProcessamentoItemRetorno","fld":"NOTIFICACAOAGENDADAPROCESSAMENTOITEMRETORNO","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z908NotificacaoAgendadaProcessamentoId","type":"guid"},{"av":"Z916NotificacaoAgendadaProcessamentoItemId","type":"int"},{"av":"Z917NotificacaoAgendadaProcessamentoItemExecucao","type":"dtime"},{"av":"Z918NotificacaoAgendadaProcessamentoItemJson","type":"vchar"},{"av":"Z919NotificacaoAgendadaProcessamentoItemTipo","type":"svchar"},{"av":"Z920NotificacaoAgendadaProcessamentoItemSituacao","type":"svchar"},{"av":"Z921NotificacaoAgendadaProcessamentoItemRetorno","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOITEMTIPO","""{"handler":"Valid_Notificacaoagendadaprocessamentoitemtipo","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAPROCESSAMENTOITEMSITUACAO","""{"handler":"Valid_Notificacaoagendadaprocessamentoitemsituacao","iparms":[]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         Z917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         Z919NotificacaoAgendadaProcessamentoItemTipo = "";
         Z920NotificacaoAgendadaProcessamentoItemSituacao = "";
         Z921NotificacaoAgendadaProcessamentoItemRetorno = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A919NotificacaoAgendadaProcessamentoItemTipo = "";
         A920NotificacaoAgendadaProcessamentoItemSituacao = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         A918NotificacaoAgendadaProcessamentoItemJson = "";
         A921NotificacaoAgendadaProcessamentoItemRetorno = "";
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
         Z918NotificacaoAgendadaProcessamentoItemJson = "";
         T002W5_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002W5_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         T002W5_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         T002W5_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         T002W5_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         T002W5_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         T002W5_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         T002W5_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         T002W5_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         T002W5_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         T002W5_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         T002W5_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W4_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W6_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W7_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W7_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002W3_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002W3_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         T002W3_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         T002W3_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         T002W3_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         T002W3_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         T002W3_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         T002W3_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         T002W3_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         T002W3_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         T002W3_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         T002W3_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         sMode100 = "";
         T002W8_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W8_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002W9_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W9_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002W2_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         T002W2_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         T002W2_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         T002W2_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         T002W2_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         T002W2_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         T002W2_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         T002W2_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         T002W2_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         T002W2_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         T002W2_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         T002W2_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W13_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         T002W13_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002W14_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         ZZ908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         ZZ917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         ZZ918NotificacaoAgendadaProcessamentoItemJson = "";
         ZZ919NotificacaoAgendadaProcessamentoItemTipo = "";
         ZZ920NotificacaoAgendadaProcessamentoItemSituacao = "";
         ZZ921NotificacaoAgendadaProcessamentoItemRetorno = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadaprocessamentoitem__default(),
            new Object[][] {
                new Object[] {
               T002W2_A916NotificacaoAgendadaProcessamentoItemId, T002W2_A917NotificacaoAgendadaProcessamentoItemExecucao, T002W2_n917NotificacaoAgendadaProcessamentoItemExecucao, T002W2_A918NotificacaoAgendadaProcessamentoItemJson, T002W2_n918NotificacaoAgendadaProcessamentoItemJson, T002W2_A919NotificacaoAgendadaProcessamentoItemTipo, T002W2_n919NotificacaoAgendadaProcessamentoItemTipo, T002W2_A920NotificacaoAgendadaProcessamentoItemSituacao, T002W2_n920NotificacaoAgendadaProcessamentoItemSituacao, T002W2_A921NotificacaoAgendadaProcessamentoItemRetorno,
               T002W2_n921NotificacaoAgendadaProcessamentoItemRetorno, T002W2_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002W3_A916NotificacaoAgendadaProcessamentoItemId, T002W3_A917NotificacaoAgendadaProcessamentoItemExecucao, T002W3_n917NotificacaoAgendadaProcessamentoItemExecucao, T002W3_A918NotificacaoAgendadaProcessamentoItemJson, T002W3_n918NotificacaoAgendadaProcessamentoItemJson, T002W3_A919NotificacaoAgendadaProcessamentoItemTipo, T002W3_n919NotificacaoAgendadaProcessamentoItemTipo, T002W3_A920NotificacaoAgendadaProcessamentoItemSituacao, T002W3_n920NotificacaoAgendadaProcessamentoItemSituacao, T002W3_A921NotificacaoAgendadaProcessamentoItemRetorno,
               T002W3_n921NotificacaoAgendadaProcessamentoItemRetorno, T002W3_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002W4_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002W5_A916NotificacaoAgendadaProcessamentoItemId, T002W5_A917NotificacaoAgendadaProcessamentoItemExecucao, T002W5_n917NotificacaoAgendadaProcessamentoItemExecucao, T002W5_A918NotificacaoAgendadaProcessamentoItemJson, T002W5_n918NotificacaoAgendadaProcessamentoItemJson, T002W5_A919NotificacaoAgendadaProcessamentoItemTipo, T002W5_n919NotificacaoAgendadaProcessamentoItemTipo, T002W5_A920NotificacaoAgendadaProcessamentoItemSituacao, T002W5_n920NotificacaoAgendadaProcessamentoItemSituacao, T002W5_A921NotificacaoAgendadaProcessamentoItemRetorno,
               T002W5_n921NotificacaoAgendadaProcessamentoItemRetorno, T002W5_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002W6_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               T002W7_A908NotificacaoAgendadaProcessamentoId, T002W7_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               T002W8_A908NotificacaoAgendadaProcessamentoId, T002W8_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               T002W9_A908NotificacaoAgendadaProcessamentoId, T002W9_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002W13_A908NotificacaoAgendadaProcessamentoId, T002W13_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               T002W14_A908NotificacaoAgendadaProcessamentoId
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
      private short RcdFound100 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z916NotificacaoAgendadaProcessamentoItemId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtNotificacaoAgendadaProcessamentoId_Enabled ;
      private int A916NotificacaoAgendadaProcessamentoItemId ;
      private int edtNotificacaoAgendadaProcessamentoItemId_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoItemExecucao_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoItemJson_Enabled ;
      private int edtNotificacaoAgendadaProcessamentoItemRetorno_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ916NotificacaoAgendadaProcessamentoItemId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotificacaoAgendadaProcessamentoId_Internalname ;
      private string cmbNotificacaoAgendadaProcessamentoItemTipo_Internalname ;
      private string cmbNotificacaoAgendadaProcessamentoItemSituacao_Internalname ;
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
      private string edtNotificacaoAgendadaProcessamentoItemId_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoItemId_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoItemExecucao_Internalname ;
      private string edtNotificacaoAgendadaProcessamentoItemExecucao_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoItemJson_Internalname ;
      private string cmbNotificacaoAgendadaProcessamentoItemTipo_Jsonclick ;
      private string cmbNotificacaoAgendadaProcessamentoItemSituacao_Jsonclick ;
      private string edtNotificacaoAgendadaProcessamentoItemRetorno_Internalname ;
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
      private string sMode100 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z917NotificacaoAgendadaProcessamentoItemExecucao ;
      private DateTime A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private DateTime ZZ917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool n918NotificacaoAgendadaProcessamentoItemJson ;
      private string A918NotificacaoAgendadaProcessamentoItemJson ;
      private string Z918NotificacaoAgendadaProcessamentoItemJson ;
      private string ZZ918NotificacaoAgendadaProcessamentoItemJson ;
      private string Z919NotificacaoAgendadaProcessamentoItemTipo ;
      private string Z920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string Z921NotificacaoAgendadaProcessamentoItemRetorno ;
      private string A919NotificacaoAgendadaProcessamentoItemTipo ;
      private string A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private string ZZ919NotificacaoAgendadaProcessamentoItemTipo ;
      private string ZZ920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string ZZ921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid Z908NotificacaoAgendadaProcessamentoId ;
      private Guid A908NotificacaoAgendadaProcessamentoId ;
      private Guid ZZ908NotificacaoAgendadaProcessamentoId ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNotificacaoAgendadaProcessamentoItemTipo ;
      private GXCombobox cmbNotificacaoAgendadaProcessamentoItemSituacao ;
      private IDataStoreProvider pr_default ;
      private int[] T002W5_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] T002W5_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] T002W5_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] T002W5_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] T002W5_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] T002W5_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] T002W5_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] T002W5_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] T002W5_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] T002W5_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] T002W5_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] T002W5_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002W4_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002W6_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002W7_A908NotificacaoAgendadaProcessamentoId ;
      private int[] T002W7_A916NotificacaoAgendadaProcessamentoItemId ;
      private int[] T002W3_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] T002W3_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] T002W3_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] T002W3_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] T002W3_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] T002W3_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] T002W3_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] T002W3_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] T002W3_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] T002W3_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] T002W3_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] T002W3_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002W8_A908NotificacaoAgendadaProcessamentoId ;
      private int[] T002W8_A916NotificacaoAgendadaProcessamentoItemId ;
      private Guid[] T002W9_A908NotificacaoAgendadaProcessamentoId ;
      private int[] T002W9_A916NotificacaoAgendadaProcessamentoItemId ;
      private int[] T002W2_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] T002W2_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] T002W2_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] T002W2_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] T002W2_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] T002W2_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] T002W2_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] T002W2_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] T002W2_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] T002W2_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] T002W2_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] T002W2_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] T002W13_A908NotificacaoAgendadaProcessamentoId ;
      private int[] T002W13_A916NotificacaoAgendadaProcessamentoItemId ;
      private Guid[] T002W14_A908NotificacaoAgendadaProcessamentoId ;
   }

   public class notificacaoagendadaprocessamentoitem__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002W2;
          prmT002W2 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W3;
          prmT002W3 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W4;
          prmT002W4 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002W5;
          prmT002W5 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W6;
          prmT002W6 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002W7;
          prmT002W7 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W8;
          prmT002W8 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W9;
          prmT002W9 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W10;
          prmT002W10 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemExecucao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemRetorno",GXType.VarChar,400,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002W11;
          prmT002W11 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoItemExecucao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemRetorno",GXType.VarChar,400,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W12;
          prmT002W12 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmT002W13;
          prmT002W13 = new Object[] {
          };
          Object[] prmT002W14;
          prmT002W14 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("T002W2", "SELECT NotificacaoAgendadaProcessamentoItemId, NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno, NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId  FOR UPDATE OF NotificacaoAgendadaProcessamentoItem NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W3", "SELECT NotificacaoAgendadaProcessamentoItemId, NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno, NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W4", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W5", "SELECT TM1.NotificacaoAgendadaProcessamentoItemId, TM1.NotificacaoAgendadaProcessamentoItemExecucao, TM1.NotificacaoAgendadaProcessamentoItemJson, TM1.NotificacaoAgendadaProcessamentoItemTipo, TM1.NotificacaoAgendadaProcessamentoItemSituacao, TM1.NotificacaoAgendadaProcessamentoItemRetorno, TM1.NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem TM1 WHERE TM1.NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId and TM1.NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ORDER BY TM1.NotificacaoAgendadaProcessamentoId, TM1.NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W6", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W7", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W8", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem WHERE ( NotificacaoAgendadaProcessamentoId > :NotificacaoAgendadaProcessamentoId or NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId and NotificacaoAgendadaProcessamentoItemId > :NotificacaoAgendadaProcessamentoItemId) ORDER BY NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002W9", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem WHERE ( NotificacaoAgendadaProcessamentoId < :NotificacaoAgendadaProcessamentoId or NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId and NotificacaoAgendadaProcessamentoItemId < :NotificacaoAgendadaProcessamentoItemId) ORDER BY NotificacaoAgendadaProcessamentoId DESC, NotificacaoAgendadaProcessamentoItemId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002W10", "SAVEPOINT gxupdate;INSERT INTO NotificacaoAgendadaProcessamentoItem(NotificacaoAgendadaProcessamentoItemId, NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno, NotificacaoAgendadaProcessamentoId) VALUES(:NotificacaoAgendadaProcessamentoItemId, :NotificacaoAgendadaProcessamentoItemExecucao, :NotificacaoAgendadaProcessamentoItemJson, :NotificacaoAgendadaProcessamentoItemTipo, :NotificacaoAgendadaProcessamentoItemSituacao, :NotificacaoAgendadaProcessamentoItemRetorno, :NotificacaoAgendadaProcessamentoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002W10)
             ,new CursorDef("T002W11", "SAVEPOINT gxupdate;UPDATE NotificacaoAgendadaProcessamentoItem SET NotificacaoAgendadaProcessamentoItemExecucao=:NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson=:NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo=:NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao=:NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno=:NotificacaoAgendadaProcessamentoItemRetorno  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002W11)
             ,new CursorDef("T002W12", "SAVEPOINT gxupdate;DELETE FROM NotificacaoAgendadaProcessamentoItem  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002W12)
             ,new CursorDef("T002W13", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem ORDER BY NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002W14", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W14,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 11 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 12 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
