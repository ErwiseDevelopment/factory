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
   public class assinaturaparticipantenotificacao : GXDataArea
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
            A242AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteId"), "."), 18, MidpointRounding.ToEven));
            n242AssinaturaParticipanteId = false;
            AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A242AssinaturaParticipanteId) ;
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
         Form.Meta.addItem("description", "Assinatura Participante Notificacao", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public assinaturaparticipantenotificacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaparticipantenotificacao( IGxContext context )
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
         cmbAssinaturaParticipanteNotificacaoStatus = new GXCombobox();
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
         if ( cmbAssinaturaParticipanteNotificacaoStatus.ItemCount > 0 )
         {
            A260AssinaturaParticipanteNotificacaoStatus = cmbAssinaturaParticipanteNotificacaoStatus.getValidValue(A260AssinaturaParticipanteNotificacaoStatus);
            n260AssinaturaParticipanteNotificacaoStatus = false;
            AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus);
            AssignProp("", false, cmbAssinaturaParticipanteNotificacaoStatus_Internalname, "Values", cmbAssinaturaParticipanteNotificacaoStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Assinatura Participante Notificacao", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_AssinaturaParticipanteNotificacao.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AssinaturaParticipanteNotificacao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteNotificacaoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteNotificacaoId_Internalname, "Notificacao Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteNotificacaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtAssinaturaParticipanteNotificacaoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A258AssinaturaParticipanteNotificacaoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A258AssinaturaParticipanteNotificacaoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteNotificacaoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteNotificacaoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteId_Internalname, "Assinatura Participante Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteId_Internalname, ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", ""))), ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( ((edtAssinaturaParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteNotificacaoData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteNotificacaoData_Internalname, "Envio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAssinaturaParticipanteNotificacaoData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteNotificacaoData_Internalname, context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A259AssinaturaParticipanteNotificacaoData, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteNotificacaoData_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteNotificacaoData_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_bitmap( context, edtAssinaturaParticipanteNotificacaoData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAssinaturaParticipanteNotificacaoData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AssinaturaParticipanteNotificacao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAssinaturaParticipanteNotificacaoStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAssinaturaParticipanteNotificacaoStatus_Internalname, "Situação", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAssinaturaParticipanteNotificacaoStatus, cmbAssinaturaParticipanteNotificacaoStatus_Internalname, StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus), 1, cmbAssinaturaParticipanteNotificacaoStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbAssinaturaParticipanteNotificacaoStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_AssinaturaParticipanteNotificacao.htm");
         cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus);
         AssignProp("", false, cmbAssinaturaParticipanteNotificacaoStatus_Internalname, "Values", (string)(cmbAssinaturaParticipanteNotificacaoStatus.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteNotificacao.htm");
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
            Z258AssinaturaParticipanteNotificacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z258AssinaturaParticipanteNotificacaoId"), ",", "."), 18, MidpointRounding.ToEven));
            Z259AssinaturaParticipanteNotificacaoData = context.localUtil.CToT( cgiGet( "Z259AssinaturaParticipanteNotificacaoData"), 0);
            n259AssinaturaParticipanteNotificacaoData = ((DateTime.MinValue==A259AssinaturaParticipanteNotificacaoData) ? true : false);
            Z260AssinaturaParticipanteNotificacaoStatus = cgiGet( "Z260AssinaturaParticipanteNotificacaoStatus");
            n260AssinaturaParticipanteNotificacaoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus)) ? true : false);
            Z242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z242AssinaturaParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            n242AssinaturaParticipanteId = ((0==A242AssinaturaParticipanteId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteNotificacaoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteNotificacaoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTENOTIFICACAOID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A258AssinaturaParticipanteNotificacaoId = 0;
               AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
            }
            else
            {
               A258AssinaturaParticipanteNotificacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteNotificacaoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
            }
            n242AssinaturaParticipanteId = ((StringUtil.StrCmp(cgiGet( edtAssinaturaParticipanteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A242AssinaturaParticipanteId = 0;
               n242AssinaturaParticipanteId = false;
               AssignAttri("", false, "A242AssinaturaParticipanteId", (n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            }
            else
            {
               A242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A242AssinaturaParticipanteId", (n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtAssinaturaParticipanteNotificacaoData_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Envio"}), 1, "ASSINATURAPARTICIPANTENOTIFICACAODATA");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteNotificacaoData_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
               n259AssinaturaParticipanteNotificacaoData = false;
               AssignAttri("", false, "A259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A259AssinaturaParticipanteNotificacaoData = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteNotificacaoData_Internalname));
               n259AssinaturaParticipanteNotificacaoData = false;
               AssignAttri("", false, "A259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
            }
            n259AssinaturaParticipanteNotificacaoData = ((DateTime.MinValue==A259AssinaturaParticipanteNotificacaoData) ? true : false);
            cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = cgiGet( cmbAssinaturaParticipanteNotificacaoStatus_Internalname);
            A260AssinaturaParticipanteNotificacaoStatus = cgiGet( cmbAssinaturaParticipanteNotificacaoStatus_Internalname);
            n260AssinaturaParticipanteNotificacaoStatus = false;
            AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
            n260AssinaturaParticipanteNotificacaoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus)) ? true : false);
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
               A258AssinaturaParticipanteNotificacaoId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteNotificacaoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
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
               InitAll1443( ) ;
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
         DisableAttributes1443( ) ;
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

      protected void ResetCaption140( )
      {
      }

      protected void ZM1443( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z259AssinaturaParticipanteNotificacaoData = T00143_A259AssinaturaParticipanteNotificacaoData[0];
               Z260AssinaturaParticipanteNotificacaoStatus = T00143_A260AssinaturaParticipanteNotificacaoStatus[0];
               Z242AssinaturaParticipanteId = T00143_A242AssinaturaParticipanteId[0];
            }
            else
            {
               Z259AssinaturaParticipanteNotificacaoData = A259AssinaturaParticipanteNotificacaoData;
               Z260AssinaturaParticipanteNotificacaoStatus = A260AssinaturaParticipanteNotificacaoStatus;
               Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
            Z259AssinaturaParticipanteNotificacaoData = A259AssinaturaParticipanteNotificacaoData;
            Z260AssinaturaParticipanteNotificacaoStatus = A260AssinaturaParticipanteNotificacaoStatus;
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
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

      protected void Load1443( )
      {
         /* Using cursor T00145 */
         pr_default.execute(3, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound43 = 1;
            A259AssinaturaParticipanteNotificacaoData = T00145_A259AssinaturaParticipanteNotificacaoData[0];
            n259AssinaturaParticipanteNotificacaoData = T00145_n259AssinaturaParticipanteNotificacaoData[0];
            AssignAttri("", false, "A259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
            A260AssinaturaParticipanteNotificacaoStatus = T00145_A260AssinaturaParticipanteNotificacaoStatus[0];
            n260AssinaturaParticipanteNotificacaoStatus = T00145_n260AssinaturaParticipanteNotificacaoStatus[0];
            AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
            A242AssinaturaParticipanteId = T00145_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T00145_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            ZM1443( -2) ;
         }
         pr_default.close(3);
         OnLoadActions1443( ) ;
      }

      protected void OnLoadActions1443( )
      {
      }

      protected void CheckExtendedTable1443( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00144 */
         pr_default.execute(2, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A260AssinaturaParticipanteNotificacaoStatus, "Enviado") == 0 ) || ( StringUtil.StrCmp(A260AssinaturaParticipanteNotificacaoStatus, "Enviando") == 0 ) || ( StringUtil.StrCmp(A260AssinaturaParticipanteNotificacaoStatus, "Erro") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus)) ) )
         {
            GX_msglist.addItem("Campo Assinatura Participante Notificacao Status fora do intervalo", "OutOfRange", 1, "ASSINATURAPARTICIPANTENOTIFICACAOSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbAssinaturaParticipanteNotificacaoStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1443( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A242AssinaturaParticipanteId )
      {
         /* Using cursor T00146 */
         pr_default.execute(4, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey1443( )
      {
         /* Using cursor T00147 */
         pr_default.execute(5, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00143 */
         pr_default.execute(1, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1443( 2) ;
            RcdFound43 = 1;
            A258AssinaturaParticipanteNotificacaoId = T00143_A258AssinaturaParticipanteNotificacaoId[0];
            AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
            A259AssinaturaParticipanteNotificacaoData = T00143_A259AssinaturaParticipanteNotificacaoData[0];
            n259AssinaturaParticipanteNotificacaoData = T00143_n259AssinaturaParticipanteNotificacaoData[0];
            AssignAttri("", false, "A259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
            A260AssinaturaParticipanteNotificacaoStatus = T00143_A260AssinaturaParticipanteNotificacaoStatus[0];
            n260AssinaturaParticipanteNotificacaoStatus = T00143_n260AssinaturaParticipanteNotificacaoStatus[0];
            AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
            A242AssinaturaParticipanteId = T00143_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T00143_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1443( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey1443( ) ;
            }
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1443( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1443( ) ;
         if ( RcdFound43 == 0 )
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
         RcdFound43 = 0;
         /* Using cursor T00148 */
         pr_default.execute(6, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00148_A258AssinaturaParticipanteNotificacaoId[0] < A258AssinaturaParticipanteNotificacaoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00148_A258AssinaturaParticipanteNotificacaoId[0] > A258AssinaturaParticipanteNotificacaoId ) ) )
            {
               A258AssinaturaParticipanteNotificacaoId = T00148_A258AssinaturaParticipanteNotificacaoId[0];
               AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
               RcdFound43 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound43 = 0;
         /* Using cursor T00149 */
         pr_default.execute(7, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00149_A258AssinaturaParticipanteNotificacaoId[0] > A258AssinaturaParticipanteNotificacaoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00149_A258AssinaturaParticipanteNotificacaoId[0] < A258AssinaturaParticipanteNotificacaoId ) ) )
            {
               A258AssinaturaParticipanteNotificacaoId = T00149_A258AssinaturaParticipanteNotificacaoId[0];
               AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
               RcdFound43 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1443( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1443( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
               {
                  A258AssinaturaParticipanteNotificacaoId = Z258AssinaturaParticipanteNotificacaoId;
                  AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ASSINATURAPARTICIPANTENOTIFICACAOID");
                  AnyError = 1;
                  GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1443( ) ;
                  GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1443( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ASSINATURAPARTICIPANTENOTIFICACAOID");
                     AnyError = 1;
                     GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1443( ) ;
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
         if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
         {
            A258AssinaturaParticipanteNotificacaoId = Z258AssinaturaParticipanteNotificacaoId;
            AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ASSINATURAPARTICIPANTENOTIFICACAOID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ASSINATURAPARTICIPANTENOTIFICACAOID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteNotificacaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1443( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1443( ) ;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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
         ScanStart1443( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound43 != 0 )
            {
               ScanNext1443( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1443( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1443( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00142 */
            pr_default.execute(0, new Object[] {A258AssinaturaParticipanteNotificacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteNotificacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z259AssinaturaParticipanteNotificacaoData != T00142_A259AssinaturaParticipanteNotificacaoData[0] ) || ( StringUtil.StrCmp(Z260AssinaturaParticipanteNotificacaoStatus, T00142_A260AssinaturaParticipanteNotificacaoStatus[0]) != 0 ) || ( Z242AssinaturaParticipanteId != T00142_A242AssinaturaParticipanteId[0] ) )
            {
               if ( Z259AssinaturaParticipanteNotificacaoData != T00142_A259AssinaturaParticipanteNotificacaoData[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipantenotificacao:[seudo value changed for attri]"+"AssinaturaParticipanteNotificacaoData");
                  GXUtil.WriteLogRaw("Old: ",Z259AssinaturaParticipanteNotificacaoData);
                  GXUtil.WriteLogRaw("Current: ",T00142_A259AssinaturaParticipanteNotificacaoData[0]);
               }
               if ( StringUtil.StrCmp(Z260AssinaturaParticipanteNotificacaoStatus, T00142_A260AssinaturaParticipanteNotificacaoStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipantenotificacao:[seudo value changed for attri]"+"AssinaturaParticipanteNotificacaoStatus");
                  GXUtil.WriteLogRaw("Old: ",Z260AssinaturaParticipanteNotificacaoStatus);
                  GXUtil.WriteLogRaw("Current: ",T00142_A260AssinaturaParticipanteNotificacaoStatus[0]);
               }
               if ( Z242AssinaturaParticipanteId != T00142_A242AssinaturaParticipanteId[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipantenotificacao:[seudo value changed for attri]"+"AssinaturaParticipanteId");
                  GXUtil.WriteLogRaw("Old: ",Z242AssinaturaParticipanteId);
                  GXUtil.WriteLogRaw("Current: ",T00142_A242AssinaturaParticipanteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AssinaturaParticipanteNotificacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1443( )
      {
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1443( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1443( 0) ;
            CheckOptimisticConcurrency1443( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1443( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1443( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001410 */
                     pr_default.execute(8, new Object[] {n259AssinaturaParticipanteNotificacaoData, A259AssinaturaParticipanteNotificacaoData, n260AssinaturaParticipanteNotificacaoStatus, A260AssinaturaParticipanteNotificacaoStatus, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001411 */
                     pr_default.execute(9);
                     A258AssinaturaParticipanteNotificacaoId = T001411_A258AssinaturaParticipanteNotificacaoId[0];
                     AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteNotificacao");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption140( ) ;
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
               Load1443( ) ;
            }
            EndLevel1443( ) ;
         }
         CloseExtendedTableCursors1443( ) ;
      }

      protected void Update1443( )
      {
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1443( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1443( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1443( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1443( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001412 */
                     pr_default.execute(10, new Object[] {n259AssinaturaParticipanteNotificacaoData, A259AssinaturaParticipanteNotificacaoData, n260AssinaturaParticipanteNotificacaoStatus, A260AssinaturaParticipanteNotificacaoStatus, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId, A258AssinaturaParticipanteNotificacaoId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteNotificacao");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteNotificacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1443( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption140( ) ;
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
            EndLevel1443( ) ;
         }
         CloseExtendedTableCursors1443( ) ;
      }

      protected void DeferredUpdate1443( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1443( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1443( ) ;
            AfterConfirm1443( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1443( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001413 */
                  pr_default.execute(11, new Object[] {A258AssinaturaParticipanteNotificacaoId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteNotificacao");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound43 == 0 )
                        {
                           InitAll1443( ) ;
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
                        ResetCaption140( ) ;
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1443( ) ;
         Gx_mode = sMode43;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1443( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1443( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1443( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues140( ) ;
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

      public void ScanStart1443( )
      {
         /* Using cursor T001414 */
         pr_default.execute(12);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound43 = 1;
            A258AssinaturaParticipanteNotificacaoId = T001414_A258AssinaturaParticipanteNotificacaoId[0];
            AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1443( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound43 = 1;
            A258AssinaturaParticipanteNotificacaoId = T001414_A258AssinaturaParticipanteNotificacaoId[0];
            AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
         }
      }

      protected void ScanEnd1443( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1443( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1443( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1443( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1443( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1443( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1443( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1443( )
      {
         edtAssinaturaParticipanteNotificacaoId_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteNotificacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteNotificacaoId_Enabled), 5, 0), true);
         edtAssinaturaParticipanteId_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteId_Enabled), 5, 0), true);
         edtAssinaturaParticipanteNotificacaoData_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteNotificacaoData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteNotificacaoData_Enabled), 5, 0), true);
         cmbAssinaturaParticipanteNotificacaoStatus.Enabled = 0;
         AssignProp("", false, cmbAssinaturaParticipanteNotificacaoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAssinaturaParticipanteNotificacaoStatus.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1443( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues140( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinaturaparticipantenotificacao") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z258AssinaturaParticipanteNotificacaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z258AssinaturaParticipanteNotificacaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( Z259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z260AssinaturaParticipanteNotificacaoStatus", Z260AssinaturaParticipanteNotificacaoStatus);
         GxWebStd.gx_hidden_field( context, "Z242AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242AssinaturaParticipanteId), 9, 0, ",", "")));
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
         return formatLink("assinaturaparticipantenotificacao")  ;
      }

      public override string GetPgmname( )
      {
         return "AssinaturaParticipanteNotificacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinatura Participante Notificacao" ;
      }

      protected void InitializeNonKey1443( )
      {
         A242AssinaturaParticipanteId = 0;
         n242AssinaturaParticipanteId = false;
         AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
         n242AssinaturaParticipanteId = ((0==A242AssinaturaParticipanteId) ? true : false);
         A259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         n259AssinaturaParticipanteNotificacaoData = false;
         AssignAttri("", false, "A259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
         n259AssinaturaParticipanteNotificacaoData = ((DateTime.MinValue==A259AssinaturaParticipanteNotificacaoData) ? true : false);
         A260AssinaturaParticipanteNotificacaoStatus = "";
         n260AssinaturaParticipanteNotificacaoStatus = false;
         AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
         n260AssinaturaParticipanteNotificacaoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus)) ? true : false);
         Z259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         Z260AssinaturaParticipanteNotificacaoStatus = "";
         Z242AssinaturaParticipanteId = 0;
      }

      protected void InitAll1443( )
      {
         A258AssinaturaParticipanteNotificacaoId = 0;
         AssignAttri("", false, "A258AssinaturaParticipanteNotificacaoId", StringUtil.LTrimStr( (decimal)(A258AssinaturaParticipanteNotificacaoId), 9, 0));
         InitializeNonKey1443( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019142360", true, true);
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
         context.AddJavascriptSource("assinaturaparticipantenotificacao.js", "?202561019142360", false, true);
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
         edtAssinaturaParticipanteNotificacaoId_Internalname = "ASSINATURAPARTICIPANTENOTIFICACAOID";
         edtAssinaturaParticipanteId_Internalname = "ASSINATURAPARTICIPANTEID";
         edtAssinaturaParticipanteNotificacaoData_Internalname = "ASSINATURAPARTICIPANTENOTIFICACAODATA";
         cmbAssinaturaParticipanteNotificacaoStatus_Internalname = "ASSINATURAPARTICIPANTENOTIFICACAOSTATUS";
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
         Form.Caption = "Assinatura Participante Notificacao";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbAssinaturaParticipanteNotificacaoStatus_Jsonclick = "";
         cmbAssinaturaParticipanteNotificacaoStatus.Enabled = 1;
         edtAssinaturaParticipanteNotificacaoData_Jsonclick = "";
         edtAssinaturaParticipanteNotificacaoData_Enabled = 1;
         edtAssinaturaParticipanteId_Jsonclick = "";
         edtAssinaturaParticipanteId_Enabled = 1;
         edtAssinaturaParticipanteNotificacaoId_Jsonclick = "";
         edtAssinaturaParticipanteNotificacaoId_Enabled = 1;
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
         cmbAssinaturaParticipanteNotificacaoStatus.Name = "ASSINATURAPARTICIPANTENOTIFICACAOSTATUS";
         cmbAssinaturaParticipanteNotificacaoStatus.WebTags = "";
         cmbAssinaturaParticipanteNotificacaoStatus.addItem("Enviado", "Enviado", 0);
         cmbAssinaturaParticipanteNotificacaoStatus.addItem("Enviando", "Enviando", 0);
         cmbAssinaturaParticipanteNotificacaoStatus.addItem("Erro", "Erro", 0);
         if ( cmbAssinaturaParticipanteNotificacaoStatus.ItemCount > 0 )
         {
            A260AssinaturaParticipanteNotificacaoStatus = cmbAssinaturaParticipanteNotificacaoStatus.getValidValue(A260AssinaturaParticipanteNotificacaoStatus);
            n260AssinaturaParticipanteNotificacaoStatus = false;
            AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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

      public void Valid_Assinaturaparticipantenotificacaoid( )
      {
         n260AssinaturaParticipanteNotificacaoStatus = false;
         A260AssinaturaParticipanteNotificacaoStatus = cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue;
         n260AssinaturaParticipanteNotificacaoStatus = false;
         cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = A260AssinaturaParticipanteNotificacaoStatus;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbAssinaturaParticipanteNotificacaoStatus.ItemCount > 0 )
         {
            A260AssinaturaParticipanteNotificacaoStatus = cmbAssinaturaParticipanteNotificacaoStatus.getValidValue(A260AssinaturaParticipanteNotificacaoStatus);
            n260AssinaturaParticipanteNotificacaoStatus = false;
            cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = A260AssinaturaParticipanteNotificacaoStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( A259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A260AssinaturaParticipanteNotificacaoStatus", A260AssinaturaParticipanteNotificacaoStatus);
         cmbAssinaturaParticipanteNotificacaoStatus.CurrentValue = StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus);
         AssignProp("", false, cmbAssinaturaParticipanteNotificacaoStatus_Internalname, "Values", cmbAssinaturaParticipanteNotificacaoStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z258AssinaturaParticipanteNotificacaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z258AssinaturaParticipanteNotificacaoId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z242AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242AssinaturaParticipanteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z259AssinaturaParticipanteNotificacaoData", context.localUtil.TToC( Z259AssinaturaParticipanteNotificacaoData, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z260AssinaturaParticipanteNotificacaoStatus", Z260AssinaturaParticipanteNotificacaoStatus);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Assinaturaparticipanteid( )
      {
         /* Using cursor T001415 */
         pr_default.execute(13, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
            }
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTENOTIFICACAOID","""{"handler":"Valid_Assinaturaparticipantenotificacaoid","iparms":[{"av":"cmbAssinaturaParticipanteNotificacaoStatus"},{"av":"A260AssinaturaParticipanteNotificacaoStatus","fld":"ASSINATURAPARTICIPANTENOTIFICACAOSTATUS","type":"svchar"},{"av":"A258AssinaturaParticipanteNotificacaoId","fld":"ASSINATURAPARTICIPANTENOTIFICACAOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTENOTIFICACAOID",""","oparms":[{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","nullAv":"n242AssinaturaParticipanteId","type":"int"},{"av":"A259AssinaturaParticipanteNotificacaoData","fld":"ASSINATURAPARTICIPANTENOTIFICACAODATA","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"cmbAssinaturaParticipanteNotificacaoStatus"},{"av":"A260AssinaturaParticipanteNotificacaoStatus","fld":"ASSINATURAPARTICIPANTENOTIFICACAOSTATUS","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z258AssinaturaParticipanteNotificacaoId","type":"int"},{"av":"Z242AssinaturaParticipanteId","type":"int"},{"av":"Z259AssinaturaParticipanteNotificacaoData","type":"dtime"},{"av":"Z260AssinaturaParticipanteNotificacaoStatus","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEID","""{"handler":"Valid_Assinaturaparticipanteid","iparms":[{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","nullAv":"n242AssinaturaParticipanteId","type":"int"}]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTENOTIFICACAOSTATUS","""{"handler":"Valid_Assinaturaparticipantenotificacaostatus","iparms":[]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         Z260AssinaturaParticipanteNotificacaoStatus = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A260AssinaturaParticipanteNotificacaoStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
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
         T00145_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T00145_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         T00145_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         T00145_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         T00145_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         T00145_A242AssinaturaParticipanteId = new int[1] ;
         T00145_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00144_A242AssinaturaParticipanteId = new int[1] ;
         T00144_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00146_A242AssinaturaParticipanteId = new int[1] ;
         T00146_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00147_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T00143_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T00143_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         T00143_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         T00143_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         T00143_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         T00143_A242AssinaturaParticipanteId = new int[1] ;
         T00143_n242AssinaturaParticipanteId = new bool[] {false} ;
         sMode43 = "";
         T00148_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T00149_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T00142_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T00142_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         T00142_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         T00142_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         T00142_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         T00142_A242AssinaturaParticipanteId = new int[1] ;
         T00142_n242AssinaturaParticipanteId = new bool[] {false} ;
         T001411_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T001414_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         ZZ260AssinaturaParticipanteNotificacaoStatus = "";
         T001415_A242AssinaturaParticipanteId = new int[1] ;
         T001415_n242AssinaturaParticipanteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaparticipantenotificacao__default(),
            new Object[][] {
                new Object[] {
               T00142_A258AssinaturaParticipanteNotificacaoId, T00142_A259AssinaturaParticipanteNotificacaoData, T00142_n259AssinaturaParticipanteNotificacaoData, T00142_A260AssinaturaParticipanteNotificacaoStatus, T00142_n260AssinaturaParticipanteNotificacaoStatus, T00142_A242AssinaturaParticipanteId, T00142_n242AssinaturaParticipanteId
               }
               , new Object[] {
               T00143_A258AssinaturaParticipanteNotificacaoId, T00143_A259AssinaturaParticipanteNotificacaoData, T00143_n259AssinaturaParticipanteNotificacaoData, T00143_A260AssinaturaParticipanteNotificacaoStatus, T00143_n260AssinaturaParticipanteNotificacaoStatus, T00143_A242AssinaturaParticipanteId, T00143_n242AssinaturaParticipanteId
               }
               , new Object[] {
               T00144_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T00145_A258AssinaturaParticipanteNotificacaoId, T00145_A259AssinaturaParticipanteNotificacaoData, T00145_n259AssinaturaParticipanteNotificacaoData, T00145_A260AssinaturaParticipanteNotificacaoStatus, T00145_n260AssinaturaParticipanteNotificacaoStatus, T00145_A242AssinaturaParticipanteId, T00145_n242AssinaturaParticipanteId
               }
               , new Object[] {
               T00146_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T00147_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               T00148_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               T00149_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001411_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001414_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               T001415_A242AssinaturaParticipanteId
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
      private short RcdFound43 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z258AssinaturaParticipanteNotificacaoId ;
      private int Z242AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A258AssinaturaParticipanteNotificacaoId ;
      private int edtAssinaturaParticipanteNotificacaoId_Enabled ;
      private int edtAssinaturaParticipanteId_Enabled ;
      private int edtAssinaturaParticipanteNotificacaoData_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ258AssinaturaParticipanteNotificacaoId ;
      private int ZZ242AssinaturaParticipanteId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAssinaturaParticipanteNotificacaoId_Internalname ;
      private string cmbAssinaturaParticipanteNotificacaoStatus_Internalname ;
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
      private string edtAssinaturaParticipanteNotificacaoId_Jsonclick ;
      private string edtAssinaturaParticipanteId_Internalname ;
      private string edtAssinaturaParticipanteId_Jsonclick ;
      private string edtAssinaturaParticipanteNotificacaoData_Internalname ;
      private string edtAssinaturaParticipanteNotificacaoData_Jsonclick ;
      private string cmbAssinaturaParticipanteNotificacaoStatus_Jsonclick ;
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
      private string sMode43 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z259AssinaturaParticipanteNotificacaoData ;
      private DateTime A259AssinaturaParticipanteNotificacaoData ;
      private DateTime ZZ259AssinaturaParticipanteNotificacaoData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n242AssinaturaParticipanteId ;
      private bool wbErr ;
      private bool n260AssinaturaParticipanteNotificacaoStatus ;
      private bool n259AssinaturaParticipanteNotificacaoData ;
      private string Z260AssinaturaParticipanteNotificacaoStatus ;
      private string A260AssinaturaParticipanteNotificacaoStatus ;
      private string ZZ260AssinaturaParticipanteNotificacaoStatus ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAssinaturaParticipanteNotificacaoStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T00145_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] T00145_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] T00145_n259AssinaturaParticipanteNotificacaoData ;
      private string[] T00145_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] T00145_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] T00145_A242AssinaturaParticipanteId ;
      private bool[] T00145_n242AssinaturaParticipanteId ;
      private int[] T00144_A242AssinaturaParticipanteId ;
      private bool[] T00144_n242AssinaturaParticipanteId ;
      private int[] T00146_A242AssinaturaParticipanteId ;
      private bool[] T00146_n242AssinaturaParticipanteId ;
      private int[] T00147_A258AssinaturaParticipanteNotificacaoId ;
      private int[] T00143_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] T00143_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] T00143_n259AssinaturaParticipanteNotificacaoData ;
      private string[] T00143_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] T00143_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] T00143_A242AssinaturaParticipanteId ;
      private bool[] T00143_n242AssinaturaParticipanteId ;
      private int[] T00148_A258AssinaturaParticipanteNotificacaoId ;
      private int[] T00149_A258AssinaturaParticipanteNotificacaoId ;
      private int[] T00142_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] T00142_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] T00142_n259AssinaturaParticipanteNotificacaoData ;
      private string[] T00142_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] T00142_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] T00142_A242AssinaturaParticipanteId ;
      private bool[] T00142_n242AssinaturaParticipanteId ;
      private int[] T001411_A258AssinaturaParticipanteNotificacaoId ;
      private int[] T001414_A258AssinaturaParticipanteNotificacaoId ;
      private int[] T001415_A242AssinaturaParticipanteId ;
      private bool[] T001415_n242AssinaturaParticipanteId ;
   }

   public class assinaturaparticipantenotificacao__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00142;
          prmT00142 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT00143;
          prmT00143 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT00144;
          prmT00144 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00145;
          prmT00145 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT00146;
          prmT00146 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00147;
          prmT00147 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT00148;
          prmT00148 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT00149;
          prmT00149 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001410;
          prmT001410 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoData",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNotificacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001411;
          prmT001411 = new Object[] {
          };
          Object[] prmT001412;
          prmT001412 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoData",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNotificacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001413;
          prmT001413 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001414;
          prmT001414 = new Object[] {
          };
          Object[] prmT001415;
          prmT001415 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00142", "SELECT AssinaturaParticipanteNotificacaoId, AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId  FOR UPDATE OF AssinaturaParticipanteNotificacao NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00142,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00143", "SELECT AssinaturaParticipanteNotificacaoId, AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00143,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00144", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00144,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00145", "SELECT TM1.AssinaturaParticipanteNotificacaoId, TM1.AssinaturaParticipanteNotificacaoData, TM1.AssinaturaParticipanteNotificacaoStatus, TM1.AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao TM1 WHERE TM1.AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ORDER BY TM1.AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00145,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00146", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00146,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00147", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00147,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00148", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao WHERE ( AssinaturaParticipanteNotificacaoId > :AssinaturaParticipanteNotificacaoId) ORDER BY AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00148,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00149", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao WHERE ( AssinaturaParticipanteNotificacaoId < :AssinaturaParticipanteNotificacaoId) ORDER BY AssinaturaParticipanteNotificacaoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00149,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001410", "SAVEPOINT gxupdate;INSERT INTO AssinaturaParticipanteNotificacao(AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId) VALUES(:AssinaturaParticipanteNotificacaoData, :AssinaturaParticipanteNotificacaoStatus, :AssinaturaParticipanteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001410)
             ,new CursorDef("T001411", "SELECT currval('AssinaturaParticipanteNotificacaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001412", "SAVEPOINT gxupdate;UPDATE AssinaturaParticipanteNotificacao SET AssinaturaParticipanteNotificacaoData=:AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus=:AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId=:AssinaturaParticipanteId  WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001412)
             ,new CursorDef("T001413", "SAVEPOINT gxupdate;DELETE FROM AssinaturaParticipanteNotificacao  WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001413)
             ,new CursorDef("T001414", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao ORDER BY AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001414,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001415", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001415,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
