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
   public class assinaturaparticipante : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A238AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
            n238AssinaturaId = false;
            AssignAttri("", false, "A238AssinaturaId", ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A238AssinaturaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A233ParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ParticipanteId"), "."), 18, MidpointRounding.ToEven));
            n233ParticipanteId = false;
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A233ParticipanteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A168ClienteId) ;
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
         Form.Meta.addItem("description", "Assinatura Participante", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public assinaturaparticipante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaparticipante( IGxContext context )
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
         cmbAssinaturaParticipanteStatus = new GXCombobox();
         cmbAssinaturaParticipanteTipo = new GXCombobox();
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
         if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
         {
            A353AssinaturaParticipanteStatus = cmbAssinaturaParticipanteStatus.getValidValue(A353AssinaturaParticipanteStatus);
            n353AssinaturaParticipanteStatus = false;
            AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaParticipanteStatus.CurrentValue = StringUtil.RTrim( A353AssinaturaParticipanteStatus);
            AssignProp("", false, cmbAssinaturaParticipanteStatus_Internalname, "Values", cmbAssinaturaParticipanteStatus.ToJavascriptSource(), true);
         }
         if ( cmbAssinaturaParticipanteTipo.ItemCount > 0 )
         {
            A247AssinaturaParticipanteTipo = cmbAssinaturaParticipanteTipo.getValidValue(A247AssinaturaParticipanteTipo);
            n247AssinaturaParticipanteTipo = false;
            AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaParticipanteTipo.CurrentValue = StringUtil.RTrim( A247AssinaturaParticipanteTipo);
            AssignProp("", false, cmbAssinaturaParticipanteTipo_Internalname, "Values", cmbAssinaturaParticipanteTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Assinatura Participante", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_AssinaturaParticipante.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AssinaturaParticipante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteId_Internalname, "Participante Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtAssinaturaParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaId_Internalname, "Assinatura Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaId_Internalname, ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", ""))), ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( ((edtAssinaturaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteId_Internalname, "Participante Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteId_Internalname, ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", ""))), ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( ((edtParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteNome_Internalname, "Participante Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteNome_Internalname, A248ParticipanteNome, StringUtil.RTrim( context.localUtil.Format( A248ParticipanteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteEmail_Internalname, "Participante Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteEmail_Internalname, A235ParticipanteEmail, StringUtil.RTrim( context.localUtil.Format( A235ParticipanteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A235ParticipanteEmail, "", "", "", edtParticipanteEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParticipanteDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParticipanteDocumento_Internalname, "Participante Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParticipanteDocumento_Internalname, A234ParticipanteDocumento, StringUtil.RTrim( context.localUtil.Format( A234ParticipanteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteDocumento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteDocumento_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAssinaturaParticipanteStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAssinaturaParticipanteStatus_Internalname, "Participante Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAssinaturaParticipanteStatus, cmbAssinaturaParticipanteStatus_Internalname, StringUtil.RTrim( A353AssinaturaParticipanteStatus), 1, cmbAssinaturaParticipanteStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbAssinaturaParticipanteStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_AssinaturaParticipante.htm");
         cmbAssinaturaParticipanteStatus.CurrentValue = StringUtil.RTrim( A353AssinaturaParticipanteStatus);
         AssignProp("", false, cmbAssinaturaParticipanteStatus_Internalname, "Values", (string)(cmbAssinaturaParticipanteStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteDataVisualizacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteDataVisualizacao_Internalname, "Data visualiazação", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAssinaturaParticipanteDataVisualizacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteDataVisualizacao_Internalname, context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A244AssinaturaParticipanteDataVisualizacao, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteDataVisualizacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteDataVisualizacao_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_bitmap( context, edtAssinaturaParticipanteDataVisualizacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAssinaturaParticipanteDataVisualizacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AssinaturaParticipante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteDataConclusao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteDataConclusao_Internalname, "Data da conclusão", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAssinaturaParticipanteDataConclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteDataConclusao_Internalname, context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A245AssinaturaParticipanteDataConclusao, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteDataConclusao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteDataConclusao_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_bitmap( context, edtAssinaturaParticipanteDataConclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAssinaturaParticipanteDataConclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AssinaturaParticipante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteKey_Internalname, "Participante Key", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteKey_Internalname, A246AssinaturaParticipanteKey.ToString(), A246AssinaturaParticipanteKey.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteKey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteKey_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAssinaturaParticipanteTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAssinaturaParticipanteTipo_Internalname, "Tipo do participante", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAssinaturaParticipanteTipo, cmbAssinaturaParticipanteTipo_Internalname, StringUtil.RTrim( A247AssinaturaParticipanteTipo), 1, cmbAssinaturaParticipanteTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbAssinaturaParticipanteTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_AssinaturaParticipante.htm");
         cmbAssinaturaParticipanteTipo.CurrentValue = StringUtil.RTrim( A247AssinaturaParticipanteTipo);
         AssignProp("", false, cmbAssinaturaParticipanteTipo_Internalname, "Values", (string)(cmbAssinaturaParticipanteTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteRemoteAddres_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteRemoteAddres_Internalname, "Remote Addres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteRemoteAddres_Internalname, A346AssinaturaParticipanteRemoteAddres, StringUtil.RTrim( context.localUtil.Format( A346AssinaturaParticipanteRemoteAddres, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteRemoteAddres_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteRemoteAddres_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteGeolocalizacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteGeolocalizacao_Internalname, "Participante Geolocalizacao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteGeolocalizacao_Internalname, A347AssinaturaParticipanteGeolocalizacao, StringUtil.RTrim( context.localUtil.Format( A347AssinaturaParticipanteGeolocalizacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteGeolocalizacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteGeolocalizacao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteDispositivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteDispositivo_Internalname, "Participante Dispositivo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteDispositivo_Internalname, A348AssinaturaParticipanteDispositivo, StringUtil.RTrim( context.localUtil.Format( A348AssinaturaParticipanteDispositivo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteDispositivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteDispositivo_Enabled, 0, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteCPF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteCPF_Internalname, "Participante CPF", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteCPF_Internalname, A350AssinaturaParticipanteCPF, StringUtil.RTrim( context.localUtil.Format( A350AssinaturaParticipanteCPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteCPF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteCPF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteEmail_Internalname, "Participante Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteEmail_Internalname, A351AssinaturaParticipanteEmail, StringUtil.RTrim( context.localUtil.Format( A351AssinaturaParticipanteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A351AssinaturaParticipanteEmail, "", "", "", edtAssinaturaParticipanteEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteNascimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteNascimento_Internalname, "Participante Nascimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAssinaturaParticipanteNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteNascimento_Internalname, context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"), context.localUtil.Format( A352AssinaturaParticipanteNascimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteNascimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteNascimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_bitmap( context, edtAssinaturaParticipanteNascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAssinaturaParticipanteNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AssinaturaParticipante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteLink_Internalname, "Participante Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAssinaturaParticipanteLink_Internalname, A354AssinaturaParticipanteLink, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", 0, 1, edtAssinaturaParticipanteLink_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_AssinaturaParticipante.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipante.htm");
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
            Z242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z242AssinaturaParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            Z353AssinaturaParticipanteStatus = cgiGet( "Z353AssinaturaParticipanteStatus");
            n353AssinaturaParticipanteStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A353AssinaturaParticipanteStatus)) ? true : false);
            Z244AssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( cgiGet( "Z244AssinaturaParticipanteDataVisualizacao"), 0);
            n244AssinaturaParticipanteDataVisualizacao = ((DateTime.MinValue==A244AssinaturaParticipanteDataVisualizacao) ? true : false);
            Z245AssinaturaParticipanteDataConclusao = context.localUtil.CToT( cgiGet( "Z245AssinaturaParticipanteDataConclusao"), 0);
            n245AssinaturaParticipanteDataConclusao = ((DateTime.MinValue==A245AssinaturaParticipanteDataConclusao) ? true : false);
            Z246AssinaturaParticipanteKey = StringUtil.StrToGuid( cgiGet( "Z246AssinaturaParticipanteKey"));
            n246AssinaturaParticipanteKey = ((Guid.Empty==A246AssinaturaParticipanteKey) ? true : false);
            Z247AssinaturaParticipanteTipo = cgiGet( "Z247AssinaturaParticipanteTipo");
            n247AssinaturaParticipanteTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A247AssinaturaParticipanteTipo)) ? true : false);
            Z346AssinaturaParticipanteRemoteAddres = cgiGet( "Z346AssinaturaParticipanteRemoteAddres");
            n346AssinaturaParticipanteRemoteAddres = (String.IsNullOrEmpty(StringUtil.RTrim( A346AssinaturaParticipanteRemoteAddres)) ? true : false);
            Z347AssinaturaParticipanteGeolocalizacao = cgiGet( "Z347AssinaturaParticipanteGeolocalizacao");
            n347AssinaturaParticipanteGeolocalizacao = (String.IsNullOrEmpty(StringUtil.RTrim( A347AssinaturaParticipanteGeolocalizacao)) ? true : false);
            Z348AssinaturaParticipanteDispositivo = cgiGet( "Z348AssinaturaParticipanteDispositivo");
            n348AssinaturaParticipanteDispositivo = (String.IsNullOrEmpty(StringUtil.RTrim( A348AssinaturaParticipanteDispositivo)) ? true : false);
            Z350AssinaturaParticipanteCPF = cgiGet( "Z350AssinaturaParticipanteCPF");
            n350AssinaturaParticipanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A350AssinaturaParticipanteCPF)) ? true : false);
            Z351AssinaturaParticipanteEmail = cgiGet( "Z351AssinaturaParticipanteEmail");
            n351AssinaturaParticipanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A351AssinaturaParticipanteEmail)) ? true : false);
            Z352AssinaturaParticipanteNascimento = context.localUtil.CToD( cgiGet( "Z352AssinaturaParticipanteNascimento"), 0);
            n352AssinaturaParticipanteNascimento = ((DateTime.MinValue==A352AssinaturaParticipanteNascimento) ? true : false);
            Z354AssinaturaParticipanteLink = cgiGet( "Z354AssinaturaParticipanteLink");
            n354AssinaturaParticipanteLink = (String.IsNullOrEmpty(StringUtil.RTrim( A354AssinaturaParticipanteLink)) ? true : false);
            Z233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z233ParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            n233ParticipanteId = ((0==A233ParticipanteId) ? true : false);
            Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n168ClienteId = ((0==A168ClienteId) ? true : false);
            Z238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z238AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
            n238AssinaturaId = ((0==A238AssinaturaId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A242AssinaturaParticipanteId = 0;
               n242AssinaturaParticipanteId = false;
               AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
            }
            else
            {
               A242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n242AssinaturaParticipanteId = false;
               AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
            }
            n238AssinaturaId = ((StringUtil.StrCmp(cgiGet( edtAssinaturaId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A238AssinaturaId = 0;
               n238AssinaturaId = false;
               AssignAttri("", false, "A238AssinaturaId", (n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            }
            else
            {
               A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A238AssinaturaId", (n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            }
            n233ParticipanteId = ((StringUtil.StrCmp(cgiGet( edtParticipanteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A233ParticipanteId = 0;
               n233ParticipanteId = false;
               AssignAttri("", false, "A233ParticipanteId", (n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            }
            else
            {
               A233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A233ParticipanteId", (n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            }
            n168ClienteId = ((StringUtil.StrCmp(cgiGet( edtClienteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A168ClienteId = 0;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            else
            {
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            A248ParticipanteNome = cgiGet( edtParticipanteNome_Internalname);
            n248ParticipanteNome = false;
            AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
            A235ParticipanteEmail = cgiGet( edtParticipanteEmail_Internalname);
            n235ParticipanteEmail = false;
            AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
            A234ParticipanteDocumento = cgiGet( edtParticipanteDocumento_Internalname);
            n234ParticipanteDocumento = false;
            AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
            cmbAssinaturaParticipanteStatus.CurrentValue = cgiGet( cmbAssinaturaParticipanteStatus_Internalname);
            A353AssinaturaParticipanteStatus = cgiGet( cmbAssinaturaParticipanteStatus_Internalname);
            n353AssinaturaParticipanteStatus = false;
            AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
            n353AssinaturaParticipanteStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A353AssinaturaParticipanteStatus)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtAssinaturaParticipanteDataVisualizacao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data visualiazação"}), 1, "ASSINATURAPARTICIPANTEDATAVISUALIZACAO");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteDataVisualizacao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
               n244AssinaturaParticipanteDataVisualizacao = false;
               AssignAttri("", false, "A244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A244AssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteDataVisualizacao_Internalname));
               n244AssinaturaParticipanteDataVisualizacao = false;
               AssignAttri("", false, "A244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
            }
            n244AssinaturaParticipanteDataVisualizacao = ((DateTime.MinValue==A244AssinaturaParticipanteDataVisualizacao) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtAssinaturaParticipanteDataConclusao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data da conclusão"}), 1, "ASSINATURAPARTICIPANTEDATACONCLUSAO");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteDataConclusao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
               n245AssinaturaParticipanteDataConclusao = false;
               AssignAttri("", false, "A245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A245AssinaturaParticipanteDataConclusao = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteDataConclusao_Internalname));
               n245AssinaturaParticipanteDataConclusao = false;
               AssignAttri("", false, "A245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
            }
            n245AssinaturaParticipanteDataConclusao = ((DateTime.MinValue==A245AssinaturaParticipanteDataConclusao) ? true : false);
            if ( StringUtil.StrCmp(cgiGet( edtAssinaturaParticipanteKey_Internalname), "") == 0 )
            {
               A246AssinaturaParticipanteKey = Guid.Empty;
               n246AssinaturaParticipanteKey = true;
               AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
            }
            else
            {
               try
               {
                  A246AssinaturaParticipanteKey = StringUtil.StrToGuid( cgiGet( edtAssinaturaParticipanteKey_Internalname));
                  n246AssinaturaParticipanteKey = false;
                  AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ASSINATURAPARTICIPANTEKEY");
                  AnyError = 1;
                  GX_FocusControl = edtAssinaturaParticipanteKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            n246AssinaturaParticipanteKey = ((Guid.Empty==A246AssinaturaParticipanteKey) ? true : false);
            cmbAssinaturaParticipanteTipo.CurrentValue = cgiGet( cmbAssinaturaParticipanteTipo_Internalname);
            A247AssinaturaParticipanteTipo = cgiGet( cmbAssinaturaParticipanteTipo_Internalname);
            n247AssinaturaParticipanteTipo = false;
            AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
            n247AssinaturaParticipanteTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A247AssinaturaParticipanteTipo)) ? true : false);
            A346AssinaturaParticipanteRemoteAddres = cgiGet( edtAssinaturaParticipanteRemoteAddres_Internalname);
            n346AssinaturaParticipanteRemoteAddres = false;
            AssignAttri("", false, "A346AssinaturaParticipanteRemoteAddres", A346AssinaturaParticipanteRemoteAddres);
            n346AssinaturaParticipanteRemoteAddres = (String.IsNullOrEmpty(StringUtil.RTrim( A346AssinaturaParticipanteRemoteAddres)) ? true : false);
            A347AssinaturaParticipanteGeolocalizacao = cgiGet( edtAssinaturaParticipanteGeolocalizacao_Internalname);
            n347AssinaturaParticipanteGeolocalizacao = false;
            AssignAttri("", false, "A347AssinaturaParticipanteGeolocalizacao", A347AssinaturaParticipanteGeolocalizacao);
            n347AssinaturaParticipanteGeolocalizacao = (String.IsNullOrEmpty(StringUtil.RTrim( A347AssinaturaParticipanteGeolocalizacao)) ? true : false);
            A348AssinaturaParticipanteDispositivo = cgiGet( edtAssinaturaParticipanteDispositivo_Internalname);
            n348AssinaturaParticipanteDispositivo = false;
            AssignAttri("", false, "A348AssinaturaParticipanteDispositivo", A348AssinaturaParticipanteDispositivo);
            n348AssinaturaParticipanteDispositivo = (String.IsNullOrEmpty(StringUtil.RTrim( A348AssinaturaParticipanteDispositivo)) ? true : false);
            A350AssinaturaParticipanteCPF = cgiGet( edtAssinaturaParticipanteCPF_Internalname);
            n350AssinaturaParticipanteCPF = false;
            AssignAttri("", false, "A350AssinaturaParticipanteCPF", A350AssinaturaParticipanteCPF);
            n350AssinaturaParticipanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A350AssinaturaParticipanteCPF)) ? true : false);
            A351AssinaturaParticipanteEmail = cgiGet( edtAssinaturaParticipanteEmail_Internalname);
            n351AssinaturaParticipanteEmail = false;
            AssignAttri("", false, "A351AssinaturaParticipanteEmail", A351AssinaturaParticipanteEmail);
            n351AssinaturaParticipanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A351AssinaturaParticipanteEmail)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtAssinaturaParticipanteNascimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Assinatura Participante Nascimento"}), 1, "ASSINATURAPARTICIPANTENASCIMENTO");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteNascimento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A352AssinaturaParticipanteNascimento = DateTime.MinValue;
               n352AssinaturaParticipanteNascimento = false;
               AssignAttri("", false, "A352AssinaturaParticipanteNascimento", context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"));
            }
            else
            {
               A352AssinaturaParticipanteNascimento = context.localUtil.CToD( cgiGet( edtAssinaturaParticipanteNascimento_Internalname), 2);
               n352AssinaturaParticipanteNascimento = false;
               AssignAttri("", false, "A352AssinaturaParticipanteNascimento", context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"));
            }
            n352AssinaturaParticipanteNascimento = ((DateTime.MinValue==A352AssinaturaParticipanteNascimento) ? true : false);
            A354AssinaturaParticipanteLink = cgiGet( edtAssinaturaParticipanteLink_Internalname);
            n354AssinaturaParticipanteLink = false;
            AssignAttri("", false, "A354AssinaturaParticipanteLink", A354AssinaturaParticipanteLink);
            n354AssinaturaParticipanteLink = (String.IsNullOrEmpty(StringUtil.RTrim( A354AssinaturaParticipanteLink)) ? true : false);
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
               A242AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteId"), "."), 18, MidpointRounding.ToEven));
               n242AssinaturaParticipanteId = false;
               AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
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
               InitAll1241( ) ;
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
         DisableAttributes1241( ) ;
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

      protected void ResetCaption120( )
      {
      }

      protected void ZM1241( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z353AssinaturaParticipanteStatus = T00123_A353AssinaturaParticipanteStatus[0];
               Z244AssinaturaParticipanteDataVisualizacao = T00123_A244AssinaturaParticipanteDataVisualizacao[0];
               Z245AssinaturaParticipanteDataConclusao = T00123_A245AssinaturaParticipanteDataConclusao[0];
               Z246AssinaturaParticipanteKey = T00123_A246AssinaturaParticipanteKey[0];
               Z247AssinaturaParticipanteTipo = T00123_A247AssinaturaParticipanteTipo[0];
               Z346AssinaturaParticipanteRemoteAddres = T00123_A346AssinaturaParticipanteRemoteAddres[0];
               Z347AssinaturaParticipanteGeolocalizacao = T00123_A347AssinaturaParticipanteGeolocalizacao[0];
               Z348AssinaturaParticipanteDispositivo = T00123_A348AssinaturaParticipanteDispositivo[0];
               Z350AssinaturaParticipanteCPF = T00123_A350AssinaturaParticipanteCPF[0];
               Z351AssinaturaParticipanteEmail = T00123_A351AssinaturaParticipanteEmail[0];
               Z352AssinaturaParticipanteNascimento = T00123_A352AssinaturaParticipanteNascimento[0];
               Z354AssinaturaParticipanteLink = T00123_A354AssinaturaParticipanteLink[0];
               Z233ParticipanteId = T00123_A233ParticipanteId[0];
               Z168ClienteId = T00123_A168ClienteId[0];
               Z238AssinaturaId = T00123_A238AssinaturaId[0];
            }
            else
            {
               Z353AssinaturaParticipanteStatus = A353AssinaturaParticipanteStatus;
               Z244AssinaturaParticipanteDataVisualizacao = A244AssinaturaParticipanteDataVisualizacao;
               Z245AssinaturaParticipanteDataConclusao = A245AssinaturaParticipanteDataConclusao;
               Z246AssinaturaParticipanteKey = A246AssinaturaParticipanteKey;
               Z247AssinaturaParticipanteTipo = A247AssinaturaParticipanteTipo;
               Z346AssinaturaParticipanteRemoteAddres = A346AssinaturaParticipanteRemoteAddres;
               Z347AssinaturaParticipanteGeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
               Z348AssinaturaParticipanteDispositivo = A348AssinaturaParticipanteDispositivo;
               Z350AssinaturaParticipanteCPF = A350AssinaturaParticipanteCPF;
               Z351AssinaturaParticipanteEmail = A351AssinaturaParticipanteEmail;
               Z352AssinaturaParticipanteNascimento = A352AssinaturaParticipanteNascimento;
               Z354AssinaturaParticipanteLink = A354AssinaturaParticipanteLink;
               Z233ParticipanteId = A233ParticipanteId;
               Z168ClienteId = A168ClienteId;
               Z238AssinaturaId = A238AssinaturaId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
            Z353AssinaturaParticipanteStatus = A353AssinaturaParticipanteStatus;
            Z244AssinaturaParticipanteDataVisualizacao = A244AssinaturaParticipanteDataVisualizacao;
            Z245AssinaturaParticipanteDataConclusao = A245AssinaturaParticipanteDataConclusao;
            Z246AssinaturaParticipanteKey = A246AssinaturaParticipanteKey;
            Z247AssinaturaParticipanteTipo = A247AssinaturaParticipanteTipo;
            Z346AssinaturaParticipanteRemoteAddres = A346AssinaturaParticipanteRemoteAddres;
            Z347AssinaturaParticipanteGeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
            Z348AssinaturaParticipanteDispositivo = A348AssinaturaParticipanteDispositivo;
            Z350AssinaturaParticipanteCPF = A350AssinaturaParticipanteCPF;
            Z351AssinaturaParticipanteEmail = A351AssinaturaParticipanteEmail;
            Z352AssinaturaParticipanteNascimento = A352AssinaturaParticipanteNascimento;
            Z354AssinaturaParticipanteLink = A354AssinaturaParticipanteLink;
            Z233ParticipanteId = A233ParticipanteId;
            Z168ClienteId = A168ClienteId;
            Z238AssinaturaId = A238AssinaturaId;
            Z248ParticipanteNome = A248ParticipanteNome;
            Z235ParticipanteEmail = A235ParticipanteEmail;
            Z234ParticipanteDocumento = A234ParticipanteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A246AssinaturaParticipanteKey) && ( Gx_BScreen == 0 ) )
         {
            A246AssinaturaParticipanteKey = Guid.NewGuid( );
            n246AssinaturaParticipanteKey = false;
            AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
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

      protected void Load1241( )
      {
         /* Using cursor T00127 */
         pr_default.execute(5, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound41 = 1;
            A248ParticipanteNome = T00127_A248ParticipanteNome[0];
            n248ParticipanteNome = T00127_n248ParticipanteNome[0];
            AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
            A235ParticipanteEmail = T00127_A235ParticipanteEmail[0];
            n235ParticipanteEmail = T00127_n235ParticipanteEmail[0];
            AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
            A234ParticipanteDocumento = T00127_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = T00127_n234ParticipanteDocumento[0];
            AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
            A353AssinaturaParticipanteStatus = T00127_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = T00127_n353AssinaturaParticipanteStatus[0];
            AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
            A244AssinaturaParticipanteDataVisualizacao = T00127_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = T00127_n244AssinaturaParticipanteDataVisualizacao[0];
            AssignAttri("", false, "A244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
            A245AssinaturaParticipanteDataConclusao = T00127_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = T00127_n245AssinaturaParticipanteDataConclusao[0];
            AssignAttri("", false, "A245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
            A246AssinaturaParticipanteKey = T00127_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = T00127_n246AssinaturaParticipanteKey[0];
            AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
            A247AssinaturaParticipanteTipo = T00127_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = T00127_n247AssinaturaParticipanteTipo[0];
            AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
            A346AssinaturaParticipanteRemoteAddres = T00127_A346AssinaturaParticipanteRemoteAddres[0];
            n346AssinaturaParticipanteRemoteAddres = T00127_n346AssinaturaParticipanteRemoteAddres[0];
            AssignAttri("", false, "A346AssinaturaParticipanteRemoteAddres", A346AssinaturaParticipanteRemoteAddres);
            A347AssinaturaParticipanteGeolocalizacao = T00127_A347AssinaturaParticipanteGeolocalizacao[0];
            n347AssinaturaParticipanteGeolocalizacao = T00127_n347AssinaturaParticipanteGeolocalizacao[0];
            AssignAttri("", false, "A347AssinaturaParticipanteGeolocalizacao", A347AssinaturaParticipanteGeolocalizacao);
            A348AssinaturaParticipanteDispositivo = T00127_A348AssinaturaParticipanteDispositivo[0];
            n348AssinaturaParticipanteDispositivo = T00127_n348AssinaturaParticipanteDispositivo[0];
            AssignAttri("", false, "A348AssinaturaParticipanteDispositivo", A348AssinaturaParticipanteDispositivo);
            A350AssinaturaParticipanteCPF = T00127_A350AssinaturaParticipanteCPF[0];
            n350AssinaturaParticipanteCPF = T00127_n350AssinaturaParticipanteCPF[0];
            AssignAttri("", false, "A350AssinaturaParticipanteCPF", A350AssinaturaParticipanteCPF);
            A351AssinaturaParticipanteEmail = T00127_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = T00127_n351AssinaturaParticipanteEmail[0];
            AssignAttri("", false, "A351AssinaturaParticipanteEmail", A351AssinaturaParticipanteEmail);
            A352AssinaturaParticipanteNascimento = T00127_A352AssinaturaParticipanteNascimento[0];
            n352AssinaturaParticipanteNascimento = T00127_n352AssinaturaParticipanteNascimento[0];
            AssignAttri("", false, "A352AssinaturaParticipanteNascimento", context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"));
            A354AssinaturaParticipanteLink = T00127_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = T00127_n354AssinaturaParticipanteLink[0];
            AssignAttri("", false, "A354AssinaturaParticipanteLink", A354AssinaturaParticipanteLink);
            A233ParticipanteId = T00127_A233ParticipanteId[0];
            n233ParticipanteId = T00127_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            A168ClienteId = T00127_A168ClienteId[0];
            n168ClienteId = T00127_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A238AssinaturaId = T00127_A238AssinaturaId[0];
            n238AssinaturaId = T00127_n238AssinaturaId[0];
            AssignAttri("", false, "A238AssinaturaId", ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            ZM1241( -8) ;
         }
         pr_default.close(5);
         OnLoadActions1241( ) ;
      }

      protected void OnLoadActions1241( )
      {
         if ( (0==A233ParticipanteId) )
         {
            A233ParticipanteId = 0;
            n233ParticipanteId = false;
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            n233ParticipanteId = true;
            n233ParticipanteId = true;
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         }
         if ( (0==A168ClienteId) )
         {
            A168ClienteId = 0;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            n168ClienteId = true;
            n168ClienteId = true;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
      }

      protected void CheckExtendedTable1241( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00126 */
         pr_default.execute(4, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A238AssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'Assinatura'.", "ForeignKeyNotFound", 1, "ASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         if ( (0==A233ParticipanteId) )
         {
            A233ParticipanteId = 0;
            n233ParticipanteId = false;
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            n233ParticipanteId = true;
            n233ParticipanteId = true;
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         }
         /* Using cursor T00124 */
         pr_default.execute(2, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A248ParticipanteNome = T00124_A248ParticipanteNome[0];
         n248ParticipanteNome = T00124_n248ParticipanteNome[0];
         AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
         A235ParticipanteEmail = T00124_A235ParticipanteEmail[0];
         n235ParticipanteEmail = T00124_n235ParticipanteEmail[0];
         AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
         A234ParticipanteDocumento = T00124_A234ParticipanteDocumento[0];
         n234ParticipanteDocumento = T00124_n234ParticipanteDocumento[0];
         AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
         pr_default.close(2);
         if ( (0==A168ClienteId) )
         {
            A168ClienteId = 0;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            n168ClienteId = true;
            n168ClienteId = true;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         /* Using cursor T00125 */
         pr_default.execute(3, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 ) || ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Assinado") == 0 ) || ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Recusado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A353AssinaturaParticipanteStatus)) ) )
         {
            GX_msglist.addItem("Campo Assinatura Participante Status fora do intervalo", "OutOfRange", 1, "ASSINATURAPARTICIPANTESTATUS");
            AnyError = 1;
            GX_FocusControl = cmbAssinaturaParticipanteStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Contratado") == 0 ) || ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Contratante") == 0 ) || ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Testemunha") == 0 ) || ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Sacado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A247AssinaturaParticipanteTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo do participante fora do intervalo", "OutOfRange", 1, "ASSINATURAPARTICIPANTETIPO");
            AnyError = 1;
            GX_FocusControl = cmbAssinaturaParticipanteTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A351AssinaturaParticipanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A351AssinaturaParticipanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Assinatura Participante Email não coincide com o padrão especificado", "OutOfRange", 1, "ASSINATURAPARTICIPANTEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1241( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( long A238AssinaturaId )
      {
         /* Using cursor T00128 */
         pr_default.execute(6, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A238AssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'Assinatura'.", "ForeignKeyNotFound", 1, "ASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_9( int A233ParticipanteId )
      {
         /* Using cursor T00129 */
         pr_default.execute(7, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A248ParticipanteNome = T00129_A248ParticipanteNome[0];
         n248ParticipanteNome = T00129_n248ParticipanteNome[0];
         AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
         A235ParticipanteEmail = T00129_A235ParticipanteEmail[0];
         n235ParticipanteEmail = T00129_n235ParticipanteEmail[0];
         AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
         A234ParticipanteDocumento = T00129_A234ParticipanteDocumento[0];
         n234ParticipanteDocumento = T00129_n234ParticipanteDocumento[0];
         AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A248ParticipanteNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A235ParticipanteEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( A234ParticipanteDocumento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_10( int A168ClienteId )
      {
         /* Using cursor T001210 */
         pr_default.execute(8, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1241( )
      {
         /* Using cursor T001211 */
         pr_default.execute(9, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00123 */
         pr_default.execute(1, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1241( 8) ;
            RcdFound41 = 1;
            A242AssinaturaParticipanteId = T00123_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T00123_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
            A353AssinaturaParticipanteStatus = T00123_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = T00123_n353AssinaturaParticipanteStatus[0];
            AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
            A244AssinaturaParticipanteDataVisualizacao = T00123_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = T00123_n244AssinaturaParticipanteDataVisualizacao[0];
            AssignAttri("", false, "A244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
            A245AssinaturaParticipanteDataConclusao = T00123_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = T00123_n245AssinaturaParticipanteDataConclusao[0];
            AssignAttri("", false, "A245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
            A246AssinaturaParticipanteKey = T00123_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = T00123_n246AssinaturaParticipanteKey[0];
            AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
            A247AssinaturaParticipanteTipo = T00123_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = T00123_n247AssinaturaParticipanteTipo[0];
            AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
            A346AssinaturaParticipanteRemoteAddres = T00123_A346AssinaturaParticipanteRemoteAddres[0];
            n346AssinaturaParticipanteRemoteAddres = T00123_n346AssinaturaParticipanteRemoteAddres[0];
            AssignAttri("", false, "A346AssinaturaParticipanteRemoteAddres", A346AssinaturaParticipanteRemoteAddres);
            A347AssinaturaParticipanteGeolocalizacao = T00123_A347AssinaturaParticipanteGeolocalizacao[0];
            n347AssinaturaParticipanteGeolocalizacao = T00123_n347AssinaturaParticipanteGeolocalizacao[0];
            AssignAttri("", false, "A347AssinaturaParticipanteGeolocalizacao", A347AssinaturaParticipanteGeolocalizacao);
            A348AssinaturaParticipanteDispositivo = T00123_A348AssinaturaParticipanteDispositivo[0];
            n348AssinaturaParticipanteDispositivo = T00123_n348AssinaturaParticipanteDispositivo[0];
            AssignAttri("", false, "A348AssinaturaParticipanteDispositivo", A348AssinaturaParticipanteDispositivo);
            A350AssinaturaParticipanteCPF = T00123_A350AssinaturaParticipanteCPF[0];
            n350AssinaturaParticipanteCPF = T00123_n350AssinaturaParticipanteCPF[0];
            AssignAttri("", false, "A350AssinaturaParticipanteCPF", A350AssinaturaParticipanteCPF);
            A351AssinaturaParticipanteEmail = T00123_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = T00123_n351AssinaturaParticipanteEmail[0];
            AssignAttri("", false, "A351AssinaturaParticipanteEmail", A351AssinaturaParticipanteEmail);
            A352AssinaturaParticipanteNascimento = T00123_A352AssinaturaParticipanteNascimento[0];
            n352AssinaturaParticipanteNascimento = T00123_n352AssinaturaParticipanteNascimento[0];
            AssignAttri("", false, "A352AssinaturaParticipanteNascimento", context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"));
            A354AssinaturaParticipanteLink = T00123_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = T00123_n354AssinaturaParticipanteLink[0];
            AssignAttri("", false, "A354AssinaturaParticipanteLink", A354AssinaturaParticipanteLink);
            A233ParticipanteId = T00123_A233ParticipanteId[0];
            n233ParticipanteId = T00123_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            A168ClienteId = T00123_A168ClienteId[0];
            n168ClienteId = T00123_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A238AssinaturaId = T00123_A238AssinaturaId[0];
            n238AssinaturaId = T00123_n238AssinaturaId[0];
            AssignAttri("", false, "A238AssinaturaId", ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1241( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1241( ) ;
            }
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1241( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1241( ) ;
         if ( RcdFound41 == 0 )
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
         RcdFound41 = 0;
         /* Using cursor T001212 */
         pr_default.execute(10, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001212_A242AssinaturaParticipanteId[0] < A242AssinaturaParticipanteId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001212_A242AssinaturaParticipanteId[0] > A242AssinaturaParticipanteId ) ) )
            {
               A242AssinaturaParticipanteId = T001212_A242AssinaturaParticipanteId[0];
               n242AssinaturaParticipanteId = T001212_n242AssinaturaParticipanteId[0];
               AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
               RcdFound41 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound41 = 0;
         /* Using cursor T001213 */
         pr_default.execute(11, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001213_A242AssinaturaParticipanteId[0] > A242AssinaturaParticipanteId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001213_A242AssinaturaParticipanteId[0] < A242AssinaturaParticipanteId ) ) )
            {
               A242AssinaturaParticipanteId = T001213_A242AssinaturaParticipanteId[0];
               n242AssinaturaParticipanteId = T001213_n242AssinaturaParticipanteId[0];
               AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
               RcdFound41 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1241( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1241( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
               {
                  A242AssinaturaParticipanteId = Z242AssinaturaParticipanteId;
                  n242AssinaturaParticipanteId = false;
                  AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
                  AnyError = 1;
                  GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1241( ) ;
                  GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1241( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ASSINATURAPARTICIPANTEID");
                     AnyError = 1;
                     GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1241( ) ;
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
         if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
         {
            A242AssinaturaParticipanteId = Z242AssinaturaParticipanteId;
            n242AssinaturaParticipanteId = false;
            AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ASSINATURAPARTICIPANTEID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAssinaturaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1241( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1241( ) ;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaId_Internalname;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaId_Internalname;
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
         ScanStart1241( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound41 != 0 )
            {
               ScanNext1241( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1241( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1241( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00122 */
            pr_default.execute(0, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z353AssinaturaParticipanteStatus, T00122_A353AssinaturaParticipanteStatus[0]) != 0 ) || ( Z244AssinaturaParticipanteDataVisualizacao != T00122_A244AssinaturaParticipanteDataVisualizacao[0] ) || ( Z245AssinaturaParticipanteDataConclusao != T00122_A245AssinaturaParticipanteDataConclusao[0] ) || ( Z246AssinaturaParticipanteKey != T00122_A246AssinaturaParticipanteKey[0] ) || ( StringUtil.StrCmp(Z247AssinaturaParticipanteTipo, T00122_A247AssinaturaParticipanteTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z346AssinaturaParticipanteRemoteAddres, T00122_A346AssinaturaParticipanteRemoteAddres[0]) != 0 ) || ( StringUtil.StrCmp(Z347AssinaturaParticipanteGeolocalizacao, T00122_A347AssinaturaParticipanteGeolocalizacao[0]) != 0 ) || ( StringUtil.StrCmp(Z348AssinaturaParticipanteDispositivo, T00122_A348AssinaturaParticipanteDispositivo[0]) != 0 ) || ( StringUtil.StrCmp(Z350AssinaturaParticipanteCPF, T00122_A350AssinaturaParticipanteCPF[0]) != 0 ) || ( StringUtil.StrCmp(Z351AssinaturaParticipanteEmail, T00122_A351AssinaturaParticipanteEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z352AssinaturaParticipanteNascimento ) != DateTimeUtil.ResetTime ( T00122_A352AssinaturaParticipanteNascimento[0] ) ) || ( StringUtil.StrCmp(Z354AssinaturaParticipanteLink, T00122_A354AssinaturaParticipanteLink[0]) != 0 ) || ( Z233ParticipanteId != T00122_A233ParticipanteId[0] ) || ( Z168ClienteId != T00122_A168ClienteId[0] ) || ( Z238AssinaturaId != T00122_A238AssinaturaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z353AssinaturaParticipanteStatus, T00122_A353AssinaturaParticipanteStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteStatus");
                  GXUtil.WriteLogRaw("Old: ",Z353AssinaturaParticipanteStatus);
                  GXUtil.WriteLogRaw("Current: ",T00122_A353AssinaturaParticipanteStatus[0]);
               }
               if ( Z244AssinaturaParticipanteDataVisualizacao != T00122_A244AssinaturaParticipanteDataVisualizacao[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteDataVisualizacao");
                  GXUtil.WriteLogRaw("Old: ",Z244AssinaturaParticipanteDataVisualizacao);
                  GXUtil.WriteLogRaw("Current: ",T00122_A244AssinaturaParticipanteDataVisualizacao[0]);
               }
               if ( Z245AssinaturaParticipanteDataConclusao != T00122_A245AssinaturaParticipanteDataConclusao[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteDataConclusao");
                  GXUtil.WriteLogRaw("Old: ",Z245AssinaturaParticipanteDataConclusao);
                  GXUtil.WriteLogRaw("Current: ",T00122_A245AssinaturaParticipanteDataConclusao[0]);
               }
               if ( Z246AssinaturaParticipanteKey != T00122_A246AssinaturaParticipanteKey[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteKey");
                  GXUtil.WriteLogRaw("Old: ",Z246AssinaturaParticipanteKey);
                  GXUtil.WriteLogRaw("Current: ",T00122_A246AssinaturaParticipanteKey[0]);
               }
               if ( StringUtil.StrCmp(Z247AssinaturaParticipanteTipo, T00122_A247AssinaturaParticipanteTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteTipo");
                  GXUtil.WriteLogRaw("Old: ",Z247AssinaturaParticipanteTipo);
                  GXUtil.WriteLogRaw("Current: ",T00122_A247AssinaturaParticipanteTipo[0]);
               }
               if ( StringUtil.StrCmp(Z346AssinaturaParticipanteRemoteAddres, T00122_A346AssinaturaParticipanteRemoteAddres[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteRemoteAddres");
                  GXUtil.WriteLogRaw("Old: ",Z346AssinaturaParticipanteRemoteAddres);
                  GXUtil.WriteLogRaw("Current: ",T00122_A346AssinaturaParticipanteRemoteAddres[0]);
               }
               if ( StringUtil.StrCmp(Z347AssinaturaParticipanteGeolocalizacao, T00122_A347AssinaturaParticipanteGeolocalizacao[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteGeolocalizacao");
                  GXUtil.WriteLogRaw("Old: ",Z347AssinaturaParticipanteGeolocalizacao);
                  GXUtil.WriteLogRaw("Current: ",T00122_A347AssinaturaParticipanteGeolocalizacao[0]);
               }
               if ( StringUtil.StrCmp(Z348AssinaturaParticipanteDispositivo, T00122_A348AssinaturaParticipanteDispositivo[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteDispositivo");
                  GXUtil.WriteLogRaw("Old: ",Z348AssinaturaParticipanteDispositivo);
                  GXUtil.WriteLogRaw("Current: ",T00122_A348AssinaturaParticipanteDispositivo[0]);
               }
               if ( StringUtil.StrCmp(Z350AssinaturaParticipanteCPF, T00122_A350AssinaturaParticipanteCPF[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteCPF");
                  GXUtil.WriteLogRaw("Old: ",Z350AssinaturaParticipanteCPF);
                  GXUtil.WriteLogRaw("Current: ",T00122_A350AssinaturaParticipanteCPF[0]);
               }
               if ( StringUtil.StrCmp(Z351AssinaturaParticipanteEmail, T00122_A351AssinaturaParticipanteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z351AssinaturaParticipanteEmail);
                  GXUtil.WriteLogRaw("Current: ",T00122_A351AssinaturaParticipanteEmail[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z352AssinaturaParticipanteNascimento ) != DateTimeUtil.ResetTime ( T00122_A352AssinaturaParticipanteNascimento[0] ) )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteNascimento");
                  GXUtil.WriteLogRaw("Old: ",Z352AssinaturaParticipanteNascimento);
                  GXUtil.WriteLogRaw("Current: ",T00122_A352AssinaturaParticipanteNascimento[0]);
               }
               if ( StringUtil.StrCmp(Z354AssinaturaParticipanteLink, T00122_A354AssinaturaParticipanteLink[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaParticipanteLink");
                  GXUtil.WriteLogRaw("Old: ",Z354AssinaturaParticipanteLink);
                  GXUtil.WriteLogRaw("Current: ",T00122_A354AssinaturaParticipanteLink[0]);
               }
               if ( Z233ParticipanteId != T00122_A233ParticipanteId[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"ParticipanteId");
                  GXUtil.WriteLogRaw("Old: ",Z233ParticipanteId);
                  GXUtil.WriteLogRaw("Current: ",T00122_A233ParticipanteId[0]);
               }
               if ( Z168ClienteId != T00122_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00122_A168ClienteId[0]);
               }
               if ( Z238AssinaturaId != T00122_A238AssinaturaId[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipante:[seudo value changed for attri]"+"AssinaturaId");
                  GXUtil.WriteLogRaw("Old: ",Z238AssinaturaId);
                  GXUtil.WriteLogRaw("Current: ",T00122_A238AssinaturaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AssinaturaParticipante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1241( )
      {
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1241( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1241( 0) ;
            CheckOptimisticConcurrency1241( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1241( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1241( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001214 */
                     pr_default.execute(12, new Object[] {n353AssinaturaParticipanteStatus, A353AssinaturaParticipanteStatus, n244AssinaturaParticipanteDataVisualizacao, A244AssinaturaParticipanteDataVisualizacao, n245AssinaturaParticipanteDataConclusao, A245AssinaturaParticipanteDataConclusao, n246AssinaturaParticipanteKey, A246AssinaturaParticipanteKey, n247AssinaturaParticipanteTipo, A247AssinaturaParticipanteTipo, n346AssinaturaParticipanteRemoteAddres, A346AssinaturaParticipanteRemoteAddres, n347AssinaturaParticipanteGeolocalizacao, A347AssinaturaParticipanteGeolocalizacao, n348AssinaturaParticipanteDispositivo, A348AssinaturaParticipanteDispositivo, n350AssinaturaParticipanteCPF, A350AssinaturaParticipanteCPF, n351AssinaturaParticipanteEmail, A351AssinaturaParticipanteEmail, n352AssinaturaParticipanteNascimento, A352AssinaturaParticipanteNascimento, n354AssinaturaParticipanteLink, A354AssinaturaParticipanteLink, n233ParticipanteId, A233ParticipanteId, n168ClienteId, A168ClienteId, n238AssinaturaId, A238AssinaturaId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001215 */
                     pr_default.execute(13);
                     A242AssinaturaParticipanteId = T001215_A242AssinaturaParticipanteId[0];
                     n242AssinaturaParticipanteId = T001215_n242AssinaturaParticipanteId[0];
                     AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipante");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption120( ) ;
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
               Load1241( ) ;
            }
            EndLevel1241( ) ;
         }
         CloseExtendedTableCursors1241( ) ;
      }

      protected void Update1241( )
      {
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1241( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1241( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1241( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1241( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001216 */
                     pr_default.execute(14, new Object[] {n353AssinaturaParticipanteStatus, A353AssinaturaParticipanteStatus, n244AssinaturaParticipanteDataVisualizacao, A244AssinaturaParticipanteDataVisualizacao, n245AssinaturaParticipanteDataConclusao, A245AssinaturaParticipanteDataConclusao, n246AssinaturaParticipanteKey, A246AssinaturaParticipanteKey, n247AssinaturaParticipanteTipo, A247AssinaturaParticipanteTipo, n346AssinaturaParticipanteRemoteAddres, A346AssinaturaParticipanteRemoteAddres, n347AssinaturaParticipanteGeolocalizacao, A347AssinaturaParticipanteGeolocalizacao, n348AssinaturaParticipanteDispositivo, A348AssinaturaParticipanteDispositivo, n350AssinaturaParticipanteCPF, A350AssinaturaParticipanteCPF, n351AssinaturaParticipanteEmail, A351AssinaturaParticipanteEmail, n352AssinaturaParticipanteNascimento, A352AssinaturaParticipanteNascimento, n354AssinaturaParticipanteLink, A354AssinaturaParticipanteLink, n233ParticipanteId, A233ParticipanteId, n168ClienteId, A168ClienteId, n238AssinaturaId, A238AssinaturaId, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipante");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1241( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption120( ) ;
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
            EndLevel1241( ) ;
         }
         CloseExtendedTableCursors1241( ) ;
      }

      protected void DeferredUpdate1241( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1241( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1241( ) ;
            AfterConfirm1241( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1241( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001217 */
                  pr_default.execute(15, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipante");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound41 == 0 )
                        {
                           InitAll1241( ) ;
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
                        ResetCaption120( ) ;
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
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1241( ) ;
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1241( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001218 */
            pr_default.execute(16, new Object[] {n233ParticipanteId, A233ParticipanteId});
            A248ParticipanteNome = T001218_A248ParticipanteNome[0];
            n248ParticipanteNome = T001218_n248ParticipanteNome[0];
            AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
            A235ParticipanteEmail = T001218_A235ParticipanteEmail[0];
            n235ParticipanteEmail = T001218_n235ParticipanteEmail[0];
            AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
            A234ParticipanteDocumento = T001218_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = T001218_n234ParticipanteDocumento[0];
            AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001219 */
            pr_default.execute(17, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipanteToken"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001220 */
            pr_default.execute(18, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipanteNotificacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel1241( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1241( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues120( ) ;
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

      public void ScanStart1241( )
      {
         /* Using cursor T001221 */
         pr_default.execute(19);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound41 = 1;
            A242AssinaturaParticipanteId = T001221_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T001221_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1241( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound41 = 1;
            A242AssinaturaParticipanteId = T001221_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T001221_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
         }
      }

      protected void ScanEnd1241( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm1241( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1241( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1241( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1241( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1241( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1241( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1241( )
      {
         edtAssinaturaParticipanteId_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteId_Enabled), 5, 0), true);
         edtAssinaturaId_Enabled = 0;
         AssignProp("", false, edtAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaId_Enabled), 5, 0), true);
         edtParticipanteId_Enabled = 0;
         AssignProp("", false, edtParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtParticipanteNome_Enabled = 0;
         AssignProp("", false, edtParticipanteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteNome_Enabled), 5, 0), true);
         edtParticipanteEmail_Enabled = 0;
         AssignProp("", false, edtParticipanteEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteEmail_Enabled), 5, 0), true);
         edtParticipanteDocumento_Enabled = 0;
         AssignProp("", false, edtParticipanteDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteDocumento_Enabled), 5, 0), true);
         cmbAssinaturaParticipanteStatus.Enabled = 0;
         AssignProp("", false, cmbAssinaturaParticipanteStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAssinaturaParticipanteStatus.Enabled), 5, 0), true);
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteDataVisualizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteDataVisualizacao_Enabled), 5, 0), true);
         edtAssinaturaParticipanteDataConclusao_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteDataConclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteDataConclusao_Enabled), 5, 0), true);
         edtAssinaturaParticipanteKey_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteKey_Enabled), 5, 0), true);
         cmbAssinaturaParticipanteTipo.Enabled = 0;
         AssignProp("", false, cmbAssinaturaParticipanteTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAssinaturaParticipanteTipo.Enabled), 5, 0), true);
         edtAssinaturaParticipanteRemoteAddres_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteRemoteAddres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteRemoteAddres_Enabled), 5, 0), true);
         edtAssinaturaParticipanteGeolocalizacao_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteGeolocalizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteGeolocalizacao_Enabled), 5, 0), true);
         edtAssinaturaParticipanteDispositivo_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteDispositivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteDispositivo_Enabled), 5, 0), true);
         edtAssinaturaParticipanteCPF_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteCPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteCPF_Enabled), 5, 0), true);
         edtAssinaturaParticipanteEmail_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteEmail_Enabled), 5, 0), true);
         edtAssinaturaParticipanteNascimento_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteNascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteNascimento_Enabled), 5, 0), true);
         edtAssinaturaParticipanteLink_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteLink_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1241( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues120( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinaturaparticipante") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z242AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z353AssinaturaParticipanteStatus", Z353AssinaturaParticipanteStatus);
         GxWebStd.gx_hidden_field( context, "Z244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( Z244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( Z245AssinaturaParticipanteDataConclusao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z246AssinaturaParticipanteKey", Z246AssinaturaParticipanteKey.ToString());
         GxWebStd.gx_hidden_field( context, "Z247AssinaturaParticipanteTipo", Z247AssinaturaParticipanteTipo);
         GxWebStd.gx_hidden_field( context, "Z346AssinaturaParticipanteRemoteAddres", Z346AssinaturaParticipanteRemoteAddres);
         GxWebStd.gx_hidden_field( context, "Z347AssinaturaParticipanteGeolocalizacao", Z347AssinaturaParticipanteGeolocalizacao);
         GxWebStd.gx_hidden_field( context, "Z348AssinaturaParticipanteDispositivo", Z348AssinaturaParticipanteDispositivo);
         GxWebStd.gx_hidden_field( context, "Z350AssinaturaParticipanteCPF", Z350AssinaturaParticipanteCPF);
         GxWebStd.gx_hidden_field( context, "Z351AssinaturaParticipanteEmail", Z351AssinaturaParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "Z352AssinaturaParticipanteNascimento", context.localUtil.DToC( Z352AssinaturaParticipanteNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z354AssinaturaParticipanteLink", Z354AssinaturaParticipanteLink);
         GxWebStd.gx_hidden_field( context, "Z233ParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z238AssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z238AssinaturaId), 10, 0, ",", "")));
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
         return formatLink("assinaturaparticipante")  ;
      }

      public override string GetPgmname( )
      {
         return "AssinaturaParticipante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinatura Participante" ;
      }

      protected void InitializeNonKey1241( )
      {
         A238AssinaturaId = 0;
         n238AssinaturaId = false;
         AssignAttri("", false, "A238AssinaturaId", ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
         n238AssinaturaId = ((0==A238AssinaturaId) ? true : false);
         A233ParticipanteId = 0;
         n233ParticipanteId = false;
         AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         n233ParticipanteId = ((0==A233ParticipanteId) ? true : false);
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A248ParticipanteNome = "";
         n248ParticipanteNome = false;
         AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
         A235ParticipanteEmail = "";
         n235ParticipanteEmail = false;
         AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
         A234ParticipanteDocumento = "";
         n234ParticipanteDocumento = false;
         AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
         A353AssinaturaParticipanteStatus = "";
         n353AssinaturaParticipanteStatus = false;
         AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
         n353AssinaturaParticipanteStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A353AssinaturaParticipanteStatus)) ? true : false);
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         n244AssinaturaParticipanteDataVisualizacao = false;
         AssignAttri("", false, "A244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
         n244AssinaturaParticipanteDataVisualizacao = ((DateTime.MinValue==A244AssinaturaParticipanteDataVisualizacao) ? true : false);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         n245AssinaturaParticipanteDataConclusao = false;
         AssignAttri("", false, "A245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
         n245AssinaturaParticipanteDataConclusao = ((DateTime.MinValue==A245AssinaturaParticipanteDataConclusao) ? true : false);
         A247AssinaturaParticipanteTipo = "";
         n247AssinaturaParticipanteTipo = false;
         AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
         n247AssinaturaParticipanteTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A247AssinaturaParticipanteTipo)) ? true : false);
         A346AssinaturaParticipanteRemoteAddres = "";
         n346AssinaturaParticipanteRemoteAddres = false;
         AssignAttri("", false, "A346AssinaturaParticipanteRemoteAddres", A346AssinaturaParticipanteRemoteAddres);
         n346AssinaturaParticipanteRemoteAddres = (String.IsNullOrEmpty(StringUtil.RTrim( A346AssinaturaParticipanteRemoteAddres)) ? true : false);
         A347AssinaturaParticipanteGeolocalizacao = "";
         n347AssinaturaParticipanteGeolocalizacao = false;
         AssignAttri("", false, "A347AssinaturaParticipanteGeolocalizacao", A347AssinaturaParticipanteGeolocalizacao);
         n347AssinaturaParticipanteGeolocalizacao = (String.IsNullOrEmpty(StringUtil.RTrim( A347AssinaturaParticipanteGeolocalizacao)) ? true : false);
         A348AssinaturaParticipanteDispositivo = "";
         n348AssinaturaParticipanteDispositivo = false;
         AssignAttri("", false, "A348AssinaturaParticipanteDispositivo", A348AssinaturaParticipanteDispositivo);
         n348AssinaturaParticipanteDispositivo = (String.IsNullOrEmpty(StringUtil.RTrim( A348AssinaturaParticipanteDispositivo)) ? true : false);
         A350AssinaturaParticipanteCPF = "";
         n350AssinaturaParticipanteCPF = false;
         AssignAttri("", false, "A350AssinaturaParticipanteCPF", A350AssinaturaParticipanteCPF);
         n350AssinaturaParticipanteCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A350AssinaturaParticipanteCPF)) ? true : false);
         A351AssinaturaParticipanteEmail = "";
         n351AssinaturaParticipanteEmail = false;
         AssignAttri("", false, "A351AssinaturaParticipanteEmail", A351AssinaturaParticipanteEmail);
         n351AssinaturaParticipanteEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A351AssinaturaParticipanteEmail)) ? true : false);
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         n352AssinaturaParticipanteNascimento = false;
         AssignAttri("", false, "A352AssinaturaParticipanteNascimento", context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"));
         n352AssinaturaParticipanteNascimento = ((DateTime.MinValue==A352AssinaturaParticipanteNascimento) ? true : false);
         A354AssinaturaParticipanteLink = "";
         n354AssinaturaParticipanteLink = false;
         AssignAttri("", false, "A354AssinaturaParticipanteLink", A354AssinaturaParticipanteLink);
         n354AssinaturaParticipanteLink = (String.IsNullOrEmpty(StringUtil.RTrim( A354AssinaturaParticipanteLink)) ? true : false);
         A246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
         Z353AssinaturaParticipanteStatus = "";
         Z244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         Z245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         Z246AssinaturaParticipanteKey = Guid.Empty;
         Z247AssinaturaParticipanteTipo = "";
         Z346AssinaturaParticipanteRemoteAddres = "";
         Z347AssinaturaParticipanteGeolocalizacao = "";
         Z348AssinaturaParticipanteDispositivo = "";
         Z350AssinaturaParticipanteCPF = "";
         Z351AssinaturaParticipanteEmail = "";
         Z352AssinaturaParticipanteNascimento = DateTime.MinValue;
         Z354AssinaturaParticipanteLink = "";
         Z233ParticipanteId = 0;
         Z168ClienteId = 0;
         Z238AssinaturaId = 0;
      }

      protected void InitAll1241( )
      {
         A242AssinaturaParticipanteId = 0;
         n242AssinaturaParticipanteId = false;
         AssignAttri("", false, "A242AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(A242AssinaturaParticipanteId), 9, 0));
         InitializeNonKey1241( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A246AssinaturaParticipanteKey = i246AssinaturaParticipanteKey;
         n246AssinaturaParticipanteKey = false;
         AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019141584", true, true);
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
         context.AddJavascriptSource("assinaturaparticipante.js", "?202561019141584", false, true);
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
         edtAssinaturaParticipanteId_Internalname = "ASSINATURAPARTICIPANTEID";
         edtAssinaturaId_Internalname = "ASSINATURAID";
         edtParticipanteId_Internalname = "PARTICIPANTEID";
         edtClienteId_Internalname = "CLIENTEID";
         edtParticipanteNome_Internalname = "PARTICIPANTENOME";
         edtParticipanteEmail_Internalname = "PARTICIPANTEEMAIL";
         edtParticipanteDocumento_Internalname = "PARTICIPANTEDOCUMENTO";
         cmbAssinaturaParticipanteStatus_Internalname = "ASSINATURAPARTICIPANTESTATUS";
         edtAssinaturaParticipanteDataVisualizacao_Internalname = "ASSINATURAPARTICIPANTEDATAVISUALIZACAO";
         edtAssinaturaParticipanteDataConclusao_Internalname = "ASSINATURAPARTICIPANTEDATACONCLUSAO";
         edtAssinaturaParticipanteKey_Internalname = "ASSINATURAPARTICIPANTEKEY";
         cmbAssinaturaParticipanteTipo_Internalname = "ASSINATURAPARTICIPANTETIPO";
         edtAssinaturaParticipanteRemoteAddres_Internalname = "ASSINATURAPARTICIPANTEREMOTEADDRES";
         edtAssinaturaParticipanteGeolocalizacao_Internalname = "ASSINATURAPARTICIPANTEGEOLOCALIZACAO";
         edtAssinaturaParticipanteDispositivo_Internalname = "ASSINATURAPARTICIPANTEDISPOSITIVO";
         edtAssinaturaParticipanteCPF_Internalname = "ASSINATURAPARTICIPANTECPF";
         edtAssinaturaParticipanteEmail_Internalname = "ASSINATURAPARTICIPANTEEMAIL";
         edtAssinaturaParticipanteNascimento_Internalname = "ASSINATURAPARTICIPANTENASCIMENTO";
         edtAssinaturaParticipanteLink_Internalname = "ASSINATURAPARTICIPANTELINK";
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
         Form.Caption = "Assinatura Participante";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAssinaturaParticipanteLink_Enabled = 1;
         edtAssinaturaParticipanteNascimento_Jsonclick = "";
         edtAssinaturaParticipanteNascimento_Enabled = 1;
         edtAssinaturaParticipanteEmail_Jsonclick = "";
         edtAssinaturaParticipanteEmail_Enabled = 1;
         edtAssinaturaParticipanteCPF_Jsonclick = "";
         edtAssinaturaParticipanteCPF_Enabled = 1;
         edtAssinaturaParticipanteDispositivo_Jsonclick = "";
         edtAssinaturaParticipanteDispositivo_Enabled = 1;
         edtAssinaturaParticipanteGeolocalizacao_Jsonclick = "";
         edtAssinaturaParticipanteGeolocalizacao_Enabled = 1;
         edtAssinaturaParticipanteRemoteAddres_Jsonclick = "";
         edtAssinaturaParticipanteRemoteAddres_Enabled = 1;
         cmbAssinaturaParticipanteTipo_Jsonclick = "";
         cmbAssinaturaParticipanteTipo.Enabled = 1;
         edtAssinaturaParticipanteKey_Jsonclick = "";
         edtAssinaturaParticipanteKey_Enabled = 1;
         edtAssinaturaParticipanteDataConclusao_Jsonclick = "";
         edtAssinaturaParticipanteDataConclusao_Enabled = 1;
         edtAssinaturaParticipanteDataVisualizacao_Jsonclick = "";
         edtAssinaturaParticipanteDataVisualizacao_Enabled = 1;
         cmbAssinaturaParticipanteStatus_Jsonclick = "";
         cmbAssinaturaParticipanteStatus.Enabled = 1;
         edtParticipanteDocumento_Jsonclick = "";
         edtParticipanteDocumento_Enabled = 0;
         edtParticipanteEmail_Jsonclick = "";
         edtParticipanteEmail_Enabled = 0;
         edtParticipanteNome_Jsonclick = "";
         edtParticipanteNome_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtParticipanteId_Jsonclick = "";
         edtParticipanteId_Enabled = 1;
         edtAssinaturaId_Jsonclick = "";
         edtAssinaturaId_Enabled = 1;
         edtAssinaturaParticipanteId_Jsonclick = "";
         edtAssinaturaParticipanteId_Enabled = 1;
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
         cmbAssinaturaParticipanteStatus.Name = "ASSINATURAPARTICIPANTESTATUS";
         cmbAssinaturaParticipanteStatus.WebTags = "";
         cmbAssinaturaParticipanteStatus.addItem("Pendente", "Pendente", 0);
         cmbAssinaturaParticipanteStatus.addItem("Assinado", "Assinado", 0);
         cmbAssinaturaParticipanteStatus.addItem("Recusado", "Recusado", 0);
         if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
         {
            A353AssinaturaParticipanteStatus = cmbAssinaturaParticipanteStatus.getValidValue(A353AssinaturaParticipanteStatus);
            n353AssinaturaParticipanteStatus = false;
            AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
         }
         cmbAssinaturaParticipanteTipo.Name = "ASSINATURAPARTICIPANTETIPO";
         cmbAssinaturaParticipanteTipo.WebTags = "";
         cmbAssinaturaParticipanteTipo.addItem("Contratado", "Contratada", 0);
         cmbAssinaturaParticipanteTipo.addItem("Contratante", "Contratante", 0);
         cmbAssinaturaParticipanteTipo.addItem("Testemunha", "Testemunha", 0);
         cmbAssinaturaParticipanteTipo.addItem("Sacado", "Sacado", 0);
         if ( cmbAssinaturaParticipanteTipo.ItemCount > 0 )
         {
            A247AssinaturaParticipanteTipo = cmbAssinaturaParticipanteTipo.getValidValue(A247AssinaturaParticipanteTipo);
            n247AssinaturaParticipanteTipo = false;
            AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAssinaturaId_Internalname;
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

      public void Valid_Assinaturaparticipanteid( )
      {
         n247AssinaturaParticipanteTipo = false;
         A247AssinaturaParticipanteTipo = cmbAssinaturaParticipanteTipo.CurrentValue;
         n247AssinaturaParticipanteTipo = false;
         cmbAssinaturaParticipanteTipo.CurrentValue = A247AssinaturaParticipanteTipo;
         n353AssinaturaParticipanteStatus = false;
         A353AssinaturaParticipanteStatus = cmbAssinaturaParticipanteStatus.CurrentValue;
         n353AssinaturaParticipanteStatus = false;
         cmbAssinaturaParticipanteStatus.CurrentValue = A353AssinaturaParticipanteStatus;
         n242AssinaturaParticipanteId = false;
         n246AssinaturaParticipanteKey = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbAssinaturaParticipanteStatus.ItemCount > 0 )
         {
            A353AssinaturaParticipanteStatus = cmbAssinaturaParticipanteStatus.getValidValue(A353AssinaturaParticipanteStatus);
            n353AssinaturaParticipanteStatus = false;
            cmbAssinaturaParticipanteStatus.CurrentValue = A353AssinaturaParticipanteStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaParticipanteStatus.CurrentValue = StringUtil.RTrim( A353AssinaturaParticipanteStatus);
         }
         if ( cmbAssinaturaParticipanteTipo.ItemCount > 0 )
         {
            A247AssinaturaParticipanteTipo = cmbAssinaturaParticipanteTipo.getValidValue(A247AssinaturaParticipanteTipo);
            n247AssinaturaParticipanteTipo = false;
            cmbAssinaturaParticipanteTipo.CurrentValue = A247AssinaturaParticipanteTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaParticipanteTipo.CurrentValue = StringUtil.RTrim( A247AssinaturaParticipanteTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A238AssinaturaId", ((0==A238AssinaturaId)&&IsIns( )||n238AssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
         AssignAttri("", false, "A353AssinaturaParticipanteStatus", A353AssinaturaParticipanteStatus);
         cmbAssinaturaParticipanteStatus.CurrentValue = StringUtil.RTrim( A353AssinaturaParticipanteStatus);
         AssignProp("", false, cmbAssinaturaParticipanteStatus_Internalname, "Values", cmbAssinaturaParticipanteStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( A244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( A245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A246AssinaturaParticipanteKey", A246AssinaturaParticipanteKey.ToString());
         AssignAttri("", false, "A247AssinaturaParticipanteTipo", A247AssinaturaParticipanteTipo);
         cmbAssinaturaParticipanteTipo.CurrentValue = StringUtil.RTrim( A247AssinaturaParticipanteTipo);
         AssignProp("", false, cmbAssinaturaParticipanteTipo_Internalname, "Values", cmbAssinaturaParticipanteTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A346AssinaturaParticipanteRemoteAddres", A346AssinaturaParticipanteRemoteAddres);
         AssignAttri("", false, "A347AssinaturaParticipanteGeolocalizacao", A347AssinaturaParticipanteGeolocalizacao);
         AssignAttri("", false, "A348AssinaturaParticipanteDispositivo", A348AssinaturaParticipanteDispositivo);
         AssignAttri("", false, "A350AssinaturaParticipanteCPF", A350AssinaturaParticipanteCPF);
         AssignAttri("", false, "A351AssinaturaParticipanteEmail", A351AssinaturaParticipanteEmail);
         AssignAttri("", false, "A352AssinaturaParticipanteNascimento", context.localUtil.Format(A352AssinaturaParticipanteNascimento, "99/99/99"));
         AssignAttri("", false, "A354AssinaturaParticipanteLink", A354AssinaturaParticipanteLink);
         AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
         AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
         AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z242AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242AssinaturaParticipanteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z238AssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z238AssinaturaId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z353AssinaturaParticipanteStatus", Z353AssinaturaParticipanteStatus);
         GxWebStd.gx_hidden_field( context, "Z244AssinaturaParticipanteDataVisualizacao", context.localUtil.TToC( Z244AssinaturaParticipanteDataVisualizacao, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z245AssinaturaParticipanteDataConclusao", context.localUtil.TToC( Z245AssinaturaParticipanteDataConclusao, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z246AssinaturaParticipanteKey", Z246AssinaturaParticipanteKey.ToString());
         GxWebStd.gx_hidden_field( context, "Z247AssinaturaParticipanteTipo", Z247AssinaturaParticipanteTipo);
         GxWebStd.gx_hidden_field( context, "Z346AssinaturaParticipanteRemoteAddres", Z346AssinaturaParticipanteRemoteAddres);
         GxWebStd.gx_hidden_field( context, "Z347AssinaturaParticipanteGeolocalizacao", Z347AssinaturaParticipanteGeolocalizacao);
         GxWebStd.gx_hidden_field( context, "Z348AssinaturaParticipanteDispositivo", Z348AssinaturaParticipanteDispositivo);
         GxWebStd.gx_hidden_field( context, "Z350AssinaturaParticipanteCPF", Z350AssinaturaParticipanteCPF);
         GxWebStd.gx_hidden_field( context, "Z351AssinaturaParticipanteEmail", Z351AssinaturaParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "Z352AssinaturaParticipanteNascimento", context.localUtil.Format(Z352AssinaturaParticipanteNascimento, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z354AssinaturaParticipanteLink", Z354AssinaturaParticipanteLink);
         GxWebStd.gx_hidden_field( context, "Z233ParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233ParticipanteId), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z248ParticipanteNome", Z248ParticipanteNome);
         GxWebStd.gx_hidden_field( context, "Z235ParticipanteEmail", Z235ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "Z234ParticipanteDocumento", Z234ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Assinaturaid( )
      {
         /* Using cursor T001222 */
         pr_default.execute(20, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A238AssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'Assinatura'.", "ForeignKeyNotFound", 1, "ASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaId_Internalname;
            }
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Participanteid( )
      {
         n248ParticipanteNome = false;
         n235ParticipanteEmail = false;
         n234ParticipanteDocumento = false;
         if ( (0==A233ParticipanteId) )
         {
            A233ParticipanteId = 0;
            n233ParticipanteId = false;
            n233ParticipanteId = true;
            n233ParticipanteId = true;
         }
         /* Using cursor T001218 */
         pr_default.execute(16, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteId_Internalname;
            }
         }
         A248ParticipanteNome = T001218_A248ParticipanteNome[0];
         n248ParticipanteNome = T001218_n248ParticipanteNome[0];
         A235ParticipanteEmail = T001218_A235ParticipanteEmail[0];
         n235ParticipanteEmail = T001218_n235ParticipanteEmail[0];
         A234ParticipanteDocumento = T001218_A234ParticipanteDocumento[0];
         n234ParticipanteDocumento = T001218_n234ParticipanteDocumento[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         AssignAttri("", false, "A248ParticipanteNome", A248ParticipanteNome);
         AssignAttri("", false, "A235ParticipanteEmail", A235ParticipanteEmail);
         AssignAttri("", false, "A234ParticipanteDocumento", A234ParticipanteDocumento);
      }

      public void Valid_Clienteid( )
      {
         if ( (0==A168ClienteId) )
         {
            A168ClienteId = 0;
            n168ClienteId = false;
            n168ClienteId = true;
            n168ClienteId = true;
         }
         /* Using cursor T001223 */
         pr_default.execute(21, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEID","""{"handler":"Valid_Assinaturaparticipanteid","iparms":[{"av":"cmbAssinaturaParticipanteTipo"},{"av":"A247AssinaturaParticipanteTipo","fld":"ASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"A353AssinaturaParticipanteStatus","fld":"ASSINATURAPARTICIPANTESTATUS","type":"svchar"},{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A246AssinaturaParticipanteKey","fld":"ASSINATURAPARTICIPANTEKEY","type":"guid"}]""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEID",""","oparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","nullAv":"n238AssinaturaId","type":"int"},{"av":"cmbAssinaturaParticipanteStatus"},{"av":"A353AssinaturaParticipanteStatus","fld":"ASSINATURAPARTICIPANTESTATUS","type":"svchar"},{"av":"A244AssinaturaParticipanteDataVisualizacao","fld":"ASSINATURAPARTICIPANTEDATAVISUALIZACAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"A245AssinaturaParticipanteDataConclusao","fld":"ASSINATURAPARTICIPANTEDATACONCLUSAO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"A246AssinaturaParticipanteKey","fld":"ASSINATURAPARTICIPANTEKEY","type":"guid"},{"av":"cmbAssinaturaParticipanteTipo"},{"av":"A247AssinaturaParticipanteTipo","fld":"ASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"A346AssinaturaParticipanteRemoteAddres","fld":"ASSINATURAPARTICIPANTEREMOTEADDRES","type":"svchar"},{"av":"A347AssinaturaParticipanteGeolocalizacao","fld":"ASSINATURAPARTICIPANTEGEOLOCALIZACAO","type":"svchar"},{"av":"A348AssinaturaParticipanteDispositivo","fld":"ASSINATURAPARTICIPANTEDISPOSITIVO","type":"svchar"},{"av":"A350AssinaturaParticipanteCPF","fld":"ASSINATURAPARTICIPANTECPF","type":"svchar"},{"av":"A351AssinaturaParticipanteEmail","fld":"ASSINATURAPARTICIPANTEEMAIL","type":"svchar"},{"av":"A352AssinaturaParticipanteNascimento","fld":"ASSINATURAPARTICIPANTENASCIMENTO","type":"date"},{"av":"A354AssinaturaParticipanteLink","fld":"ASSINATURAPARTICIPANTELINK","type":"svchar"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","nullAv":"n233ParticipanteId","type":"int"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"A235ParticipanteEmail","fld":"PARTICIPANTEEMAIL","type":"svchar"},{"av":"A234ParticipanteDocumento","fld":"PARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z242AssinaturaParticipanteId","type":"int"},{"av":"Z238AssinaturaId","type":"int"},{"av":"Z353AssinaturaParticipanteStatus","type":"svchar"},{"av":"Z244AssinaturaParticipanteDataVisualizacao","type":"dtime"},{"av":"Z245AssinaturaParticipanteDataConclusao","type":"dtime"},{"av":"Z246AssinaturaParticipanteKey","type":"guid"},{"av":"Z247AssinaturaParticipanteTipo","type":"svchar"},{"av":"Z346AssinaturaParticipanteRemoteAddres","type":"svchar"},{"av":"Z347AssinaturaParticipanteGeolocalizacao","type":"svchar"},{"av":"Z348AssinaturaParticipanteDispositivo","type":"svchar"},{"av":"Z350AssinaturaParticipanteCPF","type":"svchar"},{"av":"Z351AssinaturaParticipanteEmail","type":"svchar"},{"av":"Z352AssinaturaParticipanteNascimento","type":"date"},{"av":"Z354AssinaturaParticipanteLink","type":"svchar"},{"av":"Z233ParticipanteId","type":"int"},{"av":"Z248ParticipanteNome","type":"svchar"},{"av":"Z235ParticipanteEmail","type":"svchar"},{"av":"Z234ParticipanteDocumento","type":"svchar"},{"av":"Z168ClienteId","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_ASSINATURAID","""{"handler":"Valid_Assinaturaid","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","nullAv":"n238AssinaturaId","type":"int"}]}""");
         setEventMetadata("VALID_PARTICIPANTEID","""{"handler":"Valid_Participanteid","iparms":[{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","nullAv":"n233ParticipanteId","type":"int"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"A235ParticipanteEmail","fld":"PARTICIPANTEEMAIL","type":"svchar"},{"av":"A234ParticipanteDocumento","fld":"PARTICIPANTEDOCUMENTO","type":"svchar"}]""");
         setEventMetadata("VALID_PARTICIPANTEID",""","oparms":[{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","nullAv":"n233ParticipanteId","type":"int"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"A235ParticipanteEmail","fld":"PARTICIPANTEEMAIL","type":"svchar"},{"av":"A234ParticipanteDocumento","fld":"PARTICIPANTEDOCUMENTO","type":"svchar"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTESTATUS","""{"handler":"Valid_Assinaturaparticipantestatus","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEKEY","""{"handler":"Valid_Assinaturaparticipantekey","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTETIPO","""{"handler":"Valid_Assinaturaparticipantetipo","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEEMAIL","""{"handler":"Valid_Assinaturaparticipanteemail","iparms":[]}""");
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
         pr_default.close(16);
         pr_default.close(21);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z353AssinaturaParticipanteStatus = "";
         Z244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         Z245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         Z246AssinaturaParticipanteKey = Guid.Empty;
         Z247AssinaturaParticipanteTipo = "";
         Z346AssinaturaParticipanteRemoteAddres = "";
         Z347AssinaturaParticipanteGeolocalizacao = "";
         Z348AssinaturaParticipanteDispositivo = "";
         Z350AssinaturaParticipanteCPF = "";
         Z351AssinaturaParticipanteEmail = "";
         Z352AssinaturaParticipanteNascimento = DateTime.MinValue;
         Z354AssinaturaParticipanteLink = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A353AssinaturaParticipanteStatus = "";
         A247AssinaturaParticipanteTipo = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         A246AssinaturaParticipanteKey = Guid.Empty;
         A346AssinaturaParticipanteRemoteAddres = "";
         A347AssinaturaParticipanteGeolocalizacao = "";
         A348AssinaturaParticipanteDispositivo = "";
         A350AssinaturaParticipanteCPF = "";
         A351AssinaturaParticipanteEmail = "";
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         A354AssinaturaParticipanteLink = "";
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
         Z248ParticipanteNome = "";
         Z235ParticipanteEmail = "";
         Z234ParticipanteDocumento = "";
         T00127_A242AssinaturaParticipanteId = new int[1] ;
         T00127_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00127_A248ParticipanteNome = new string[] {""} ;
         T00127_n248ParticipanteNome = new bool[] {false} ;
         T00127_A235ParticipanteEmail = new string[] {""} ;
         T00127_n235ParticipanteEmail = new bool[] {false} ;
         T00127_A234ParticipanteDocumento = new string[] {""} ;
         T00127_n234ParticipanteDocumento = new bool[] {false} ;
         T00127_A353AssinaturaParticipanteStatus = new string[] {""} ;
         T00127_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         T00127_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         T00127_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         T00127_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         T00127_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         T00127_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         T00127_n246AssinaturaParticipanteKey = new bool[] {false} ;
         T00127_A247AssinaturaParticipanteTipo = new string[] {""} ;
         T00127_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         T00127_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         T00127_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         T00127_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         T00127_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         T00127_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         T00127_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         T00127_A350AssinaturaParticipanteCPF = new string[] {""} ;
         T00127_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         T00127_A351AssinaturaParticipanteEmail = new string[] {""} ;
         T00127_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         T00127_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         T00127_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         T00127_A354AssinaturaParticipanteLink = new string[] {""} ;
         T00127_n354AssinaturaParticipanteLink = new bool[] {false} ;
         T00127_A233ParticipanteId = new int[1] ;
         T00127_n233ParticipanteId = new bool[] {false} ;
         T00127_A168ClienteId = new int[1] ;
         T00127_n168ClienteId = new bool[] {false} ;
         T00127_A238AssinaturaId = new long[1] ;
         T00127_n238AssinaturaId = new bool[] {false} ;
         T00126_A238AssinaturaId = new long[1] ;
         T00126_n238AssinaturaId = new bool[] {false} ;
         T00124_A248ParticipanteNome = new string[] {""} ;
         T00124_n248ParticipanteNome = new bool[] {false} ;
         T00124_A235ParticipanteEmail = new string[] {""} ;
         T00124_n235ParticipanteEmail = new bool[] {false} ;
         T00124_A234ParticipanteDocumento = new string[] {""} ;
         T00124_n234ParticipanteDocumento = new bool[] {false} ;
         T00125_A168ClienteId = new int[1] ;
         T00125_n168ClienteId = new bool[] {false} ;
         T00128_A238AssinaturaId = new long[1] ;
         T00128_n238AssinaturaId = new bool[] {false} ;
         T00129_A248ParticipanteNome = new string[] {""} ;
         T00129_n248ParticipanteNome = new bool[] {false} ;
         T00129_A235ParticipanteEmail = new string[] {""} ;
         T00129_n235ParticipanteEmail = new bool[] {false} ;
         T00129_A234ParticipanteDocumento = new string[] {""} ;
         T00129_n234ParticipanteDocumento = new bool[] {false} ;
         T001210_A168ClienteId = new int[1] ;
         T001210_n168ClienteId = new bool[] {false} ;
         T001211_A242AssinaturaParticipanteId = new int[1] ;
         T001211_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00123_A242AssinaturaParticipanteId = new int[1] ;
         T00123_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00123_A353AssinaturaParticipanteStatus = new string[] {""} ;
         T00123_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         T00123_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         T00123_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         T00123_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         T00123_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         T00123_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         T00123_n246AssinaturaParticipanteKey = new bool[] {false} ;
         T00123_A247AssinaturaParticipanteTipo = new string[] {""} ;
         T00123_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         T00123_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         T00123_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         T00123_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         T00123_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         T00123_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         T00123_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         T00123_A350AssinaturaParticipanteCPF = new string[] {""} ;
         T00123_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         T00123_A351AssinaturaParticipanteEmail = new string[] {""} ;
         T00123_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         T00123_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         T00123_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         T00123_A354AssinaturaParticipanteLink = new string[] {""} ;
         T00123_n354AssinaturaParticipanteLink = new bool[] {false} ;
         T00123_A233ParticipanteId = new int[1] ;
         T00123_n233ParticipanteId = new bool[] {false} ;
         T00123_A168ClienteId = new int[1] ;
         T00123_n168ClienteId = new bool[] {false} ;
         T00123_A238AssinaturaId = new long[1] ;
         T00123_n238AssinaturaId = new bool[] {false} ;
         sMode41 = "";
         T001212_A242AssinaturaParticipanteId = new int[1] ;
         T001212_n242AssinaturaParticipanteId = new bool[] {false} ;
         T001213_A242AssinaturaParticipanteId = new int[1] ;
         T001213_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00122_A242AssinaturaParticipanteId = new int[1] ;
         T00122_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00122_A353AssinaturaParticipanteStatus = new string[] {""} ;
         T00122_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         T00122_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         T00122_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         T00122_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         T00122_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         T00122_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         T00122_n246AssinaturaParticipanteKey = new bool[] {false} ;
         T00122_A247AssinaturaParticipanteTipo = new string[] {""} ;
         T00122_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         T00122_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         T00122_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         T00122_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         T00122_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         T00122_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         T00122_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         T00122_A350AssinaturaParticipanteCPF = new string[] {""} ;
         T00122_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         T00122_A351AssinaturaParticipanteEmail = new string[] {""} ;
         T00122_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         T00122_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         T00122_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         T00122_A354AssinaturaParticipanteLink = new string[] {""} ;
         T00122_n354AssinaturaParticipanteLink = new bool[] {false} ;
         T00122_A233ParticipanteId = new int[1] ;
         T00122_n233ParticipanteId = new bool[] {false} ;
         T00122_A168ClienteId = new int[1] ;
         T00122_n168ClienteId = new bool[] {false} ;
         T00122_A238AssinaturaId = new long[1] ;
         T00122_n238AssinaturaId = new bool[] {false} ;
         T001215_A242AssinaturaParticipanteId = new int[1] ;
         T001215_n242AssinaturaParticipanteId = new bool[] {false} ;
         T001218_A248ParticipanteNome = new string[] {""} ;
         T001218_n248ParticipanteNome = new bool[] {false} ;
         T001218_A235ParticipanteEmail = new string[] {""} ;
         T001218_n235ParticipanteEmail = new bool[] {false} ;
         T001218_A234ParticipanteDocumento = new string[] {""} ;
         T001218_n234ParticipanteDocumento = new bool[] {false} ;
         T001219_A554AssinaturaParticipanteTokenId = new int[1] ;
         T001220_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         T001221_A242AssinaturaParticipanteId = new int[1] ;
         T001221_n242AssinaturaParticipanteId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i246AssinaturaParticipanteKey = Guid.Empty;
         ZZ353AssinaturaParticipanteStatus = "";
         ZZ244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         ZZ245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         ZZ246AssinaturaParticipanteKey = Guid.Empty;
         ZZ247AssinaturaParticipanteTipo = "";
         ZZ346AssinaturaParticipanteRemoteAddres = "";
         ZZ347AssinaturaParticipanteGeolocalizacao = "";
         ZZ348AssinaturaParticipanteDispositivo = "";
         ZZ350AssinaturaParticipanteCPF = "";
         ZZ351AssinaturaParticipanteEmail = "";
         ZZ352AssinaturaParticipanteNascimento = DateTime.MinValue;
         ZZ354AssinaturaParticipanteLink = "";
         ZZ248ParticipanteNome = "";
         ZZ235ParticipanteEmail = "";
         ZZ234ParticipanteDocumento = "";
         T001222_A238AssinaturaId = new long[1] ;
         T001222_n238AssinaturaId = new bool[] {false} ;
         T001223_A168ClienteId = new int[1] ;
         T001223_n168ClienteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaparticipante__default(),
            new Object[][] {
                new Object[] {
               T00122_A242AssinaturaParticipanteId, T00122_A353AssinaturaParticipanteStatus, T00122_n353AssinaturaParticipanteStatus, T00122_A244AssinaturaParticipanteDataVisualizacao, T00122_n244AssinaturaParticipanteDataVisualizacao, T00122_A245AssinaturaParticipanteDataConclusao, T00122_n245AssinaturaParticipanteDataConclusao, T00122_A246AssinaturaParticipanteKey, T00122_n246AssinaturaParticipanteKey, T00122_A247AssinaturaParticipanteTipo,
               T00122_n247AssinaturaParticipanteTipo, T00122_A346AssinaturaParticipanteRemoteAddres, T00122_n346AssinaturaParticipanteRemoteAddres, T00122_A347AssinaturaParticipanteGeolocalizacao, T00122_n347AssinaturaParticipanteGeolocalizacao, T00122_A348AssinaturaParticipanteDispositivo, T00122_n348AssinaturaParticipanteDispositivo, T00122_A350AssinaturaParticipanteCPF, T00122_n350AssinaturaParticipanteCPF, T00122_A351AssinaturaParticipanteEmail,
               T00122_n351AssinaturaParticipanteEmail, T00122_A352AssinaturaParticipanteNascimento, T00122_n352AssinaturaParticipanteNascimento, T00122_A354AssinaturaParticipanteLink, T00122_n354AssinaturaParticipanteLink, T00122_A233ParticipanteId, T00122_n233ParticipanteId, T00122_A168ClienteId, T00122_n168ClienteId, T00122_A238AssinaturaId,
               T00122_n238AssinaturaId
               }
               , new Object[] {
               T00123_A242AssinaturaParticipanteId, T00123_A353AssinaturaParticipanteStatus, T00123_n353AssinaturaParticipanteStatus, T00123_A244AssinaturaParticipanteDataVisualizacao, T00123_n244AssinaturaParticipanteDataVisualizacao, T00123_A245AssinaturaParticipanteDataConclusao, T00123_n245AssinaturaParticipanteDataConclusao, T00123_A246AssinaturaParticipanteKey, T00123_n246AssinaturaParticipanteKey, T00123_A247AssinaturaParticipanteTipo,
               T00123_n247AssinaturaParticipanteTipo, T00123_A346AssinaturaParticipanteRemoteAddres, T00123_n346AssinaturaParticipanteRemoteAddres, T00123_A347AssinaturaParticipanteGeolocalizacao, T00123_n347AssinaturaParticipanteGeolocalizacao, T00123_A348AssinaturaParticipanteDispositivo, T00123_n348AssinaturaParticipanteDispositivo, T00123_A350AssinaturaParticipanteCPF, T00123_n350AssinaturaParticipanteCPF, T00123_A351AssinaturaParticipanteEmail,
               T00123_n351AssinaturaParticipanteEmail, T00123_A352AssinaturaParticipanteNascimento, T00123_n352AssinaturaParticipanteNascimento, T00123_A354AssinaturaParticipanteLink, T00123_n354AssinaturaParticipanteLink, T00123_A233ParticipanteId, T00123_n233ParticipanteId, T00123_A168ClienteId, T00123_n168ClienteId, T00123_A238AssinaturaId,
               T00123_n238AssinaturaId
               }
               , new Object[] {
               T00124_A248ParticipanteNome, T00124_n248ParticipanteNome, T00124_A235ParticipanteEmail, T00124_n235ParticipanteEmail, T00124_A234ParticipanteDocumento, T00124_n234ParticipanteDocumento
               }
               , new Object[] {
               T00125_A168ClienteId
               }
               , new Object[] {
               T00126_A238AssinaturaId
               }
               , new Object[] {
               T00127_A242AssinaturaParticipanteId, T00127_A248ParticipanteNome, T00127_n248ParticipanteNome, T00127_A235ParticipanteEmail, T00127_n235ParticipanteEmail, T00127_A234ParticipanteDocumento, T00127_n234ParticipanteDocumento, T00127_A353AssinaturaParticipanteStatus, T00127_n353AssinaturaParticipanteStatus, T00127_A244AssinaturaParticipanteDataVisualizacao,
               T00127_n244AssinaturaParticipanteDataVisualizacao, T00127_A245AssinaturaParticipanteDataConclusao, T00127_n245AssinaturaParticipanteDataConclusao, T00127_A246AssinaturaParticipanteKey, T00127_n246AssinaturaParticipanteKey, T00127_A247AssinaturaParticipanteTipo, T00127_n247AssinaturaParticipanteTipo, T00127_A346AssinaturaParticipanteRemoteAddres, T00127_n346AssinaturaParticipanteRemoteAddres, T00127_A347AssinaturaParticipanteGeolocalizacao,
               T00127_n347AssinaturaParticipanteGeolocalizacao, T00127_A348AssinaturaParticipanteDispositivo, T00127_n348AssinaturaParticipanteDispositivo, T00127_A350AssinaturaParticipanteCPF, T00127_n350AssinaturaParticipanteCPF, T00127_A351AssinaturaParticipanteEmail, T00127_n351AssinaturaParticipanteEmail, T00127_A352AssinaturaParticipanteNascimento, T00127_n352AssinaturaParticipanteNascimento, T00127_A354AssinaturaParticipanteLink,
               T00127_n354AssinaturaParticipanteLink, T00127_A233ParticipanteId, T00127_n233ParticipanteId, T00127_A168ClienteId, T00127_n168ClienteId, T00127_A238AssinaturaId, T00127_n238AssinaturaId
               }
               , new Object[] {
               T00128_A238AssinaturaId
               }
               , new Object[] {
               T00129_A248ParticipanteNome, T00129_n248ParticipanteNome, T00129_A235ParticipanteEmail, T00129_n235ParticipanteEmail, T00129_A234ParticipanteDocumento, T00129_n234ParticipanteDocumento
               }
               , new Object[] {
               T001210_A168ClienteId
               }
               , new Object[] {
               T001211_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T001212_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T001213_A242AssinaturaParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               T001215_A242AssinaturaParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001218_A248ParticipanteNome, T001218_n248ParticipanteNome, T001218_A235ParticipanteEmail, T001218_n235ParticipanteEmail, T001218_A234ParticipanteDocumento, T001218_n234ParticipanteDocumento
               }
               , new Object[] {
               T001219_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               T001220_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               T001221_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T001222_A238AssinaturaId
               }
               , new Object[] {
               T001223_A168ClienteId
               }
            }
         );
         Z246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         A246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         i246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound41 ;
      private short gxajaxcallmode ;
      private int Z242AssinaturaParticipanteId ;
      private int Z233ParticipanteId ;
      private int Z168ClienteId ;
      private int A233ParticipanteId ;
      private int A168ClienteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A242AssinaturaParticipanteId ;
      private int edtAssinaturaParticipanteId_Enabled ;
      private int edtAssinaturaId_Enabled ;
      private int edtParticipanteId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtParticipanteNome_Enabled ;
      private int edtParticipanteEmail_Enabled ;
      private int edtParticipanteDocumento_Enabled ;
      private int edtAssinaturaParticipanteDataVisualizacao_Enabled ;
      private int edtAssinaturaParticipanteDataConclusao_Enabled ;
      private int edtAssinaturaParticipanteKey_Enabled ;
      private int edtAssinaturaParticipanteRemoteAddres_Enabled ;
      private int edtAssinaturaParticipanteGeolocalizacao_Enabled ;
      private int edtAssinaturaParticipanteDispositivo_Enabled ;
      private int edtAssinaturaParticipanteCPF_Enabled ;
      private int edtAssinaturaParticipanteEmail_Enabled ;
      private int edtAssinaturaParticipanteNascimento_Enabled ;
      private int edtAssinaturaParticipanteLink_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ242AssinaturaParticipanteId ;
      private int ZZ233ParticipanteId ;
      private int ZZ168ClienteId ;
      private long Z238AssinaturaId ;
      private long A238AssinaturaId ;
      private long ZZ238AssinaturaId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAssinaturaParticipanteId_Internalname ;
      private string cmbAssinaturaParticipanteStatus_Internalname ;
      private string cmbAssinaturaParticipanteTipo_Internalname ;
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
      private string edtAssinaturaParticipanteId_Jsonclick ;
      private string edtAssinaturaId_Internalname ;
      private string edtAssinaturaId_Jsonclick ;
      private string edtParticipanteId_Internalname ;
      private string edtParticipanteId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtParticipanteNome_Internalname ;
      private string edtParticipanteNome_Jsonclick ;
      private string edtParticipanteEmail_Internalname ;
      private string edtParticipanteEmail_Jsonclick ;
      private string edtParticipanteDocumento_Internalname ;
      private string edtParticipanteDocumento_Jsonclick ;
      private string cmbAssinaturaParticipanteStatus_Jsonclick ;
      private string edtAssinaturaParticipanteDataVisualizacao_Internalname ;
      private string edtAssinaturaParticipanteDataVisualizacao_Jsonclick ;
      private string edtAssinaturaParticipanteDataConclusao_Internalname ;
      private string edtAssinaturaParticipanteDataConclusao_Jsonclick ;
      private string edtAssinaturaParticipanteKey_Internalname ;
      private string edtAssinaturaParticipanteKey_Jsonclick ;
      private string cmbAssinaturaParticipanteTipo_Jsonclick ;
      private string edtAssinaturaParticipanteRemoteAddres_Internalname ;
      private string edtAssinaturaParticipanteRemoteAddres_Jsonclick ;
      private string edtAssinaturaParticipanteGeolocalizacao_Internalname ;
      private string edtAssinaturaParticipanteGeolocalizacao_Jsonclick ;
      private string edtAssinaturaParticipanteDispositivo_Internalname ;
      private string edtAssinaturaParticipanteDispositivo_Jsonclick ;
      private string edtAssinaturaParticipanteCPF_Internalname ;
      private string edtAssinaturaParticipanteCPF_Jsonclick ;
      private string edtAssinaturaParticipanteEmail_Internalname ;
      private string edtAssinaturaParticipanteEmail_Jsonclick ;
      private string edtAssinaturaParticipanteNascimento_Internalname ;
      private string edtAssinaturaParticipanteNascimento_Jsonclick ;
      private string edtAssinaturaParticipanteLink_Internalname ;
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
      private string sMode41 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z244AssinaturaParticipanteDataVisualizacao ;
      private DateTime Z245AssinaturaParticipanteDataConclusao ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private DateTime ZZ244AssinaturaParticipanteDataVisualizacao ;
      private DateTime ZZ245AssinaturaParticipanteDataConclusao ;
      private DateTime Z352AssinaturaParticipanteNascimento ;
      private DateTime A352AssinaturaParticipanteNascimento ;
      private DateTime ZZ352AssinaturaParticipanteNascimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n238AssinaturaId ;
      private bool n233ParticipanteId ;
      private bool n168ClienteId ;
      private bool wbErr ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n346AssinaturaParticipanteRemoteAddres ;
      private bool n347AssinaturaParticipanteGeolocalizacao ;
      private bool n348AssinaturaParticipanteDispositivo ;
      private bool n350AssinaturaParticipanteCPF ;
      private bool n351AssinaturaParticipanteEmail ;
      private bool n352AssinaturaParticipanteNascimento ;
      private bool n354AssinaturaParticipanteLink ;
      private bool n242AssinaturaParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private bool Gx_longc ;
      private string Z353AssinaturaParticipanteStatus ;
      private string Z247AssinaturaParticipanteTipo ;
      private string Z346AssinaturaParticipanteRemoteAddres ;
      private string Z347AssinaturaParticipanteGeolocalizacao ;
      private string Z348AssinaturaParticipanteDispositivo ;
      private string Z350AssinaturaParticipanteCPF ;
      private string Z351AssinaturaParticipanteEmail ;
      private string Z354AssinaturaParticipanteLink ;
      private string A353AssinaturaParticipanteStatus ;
      private string A247AssinaturaParticipanteTipo ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private string A346AssinaturaParticipanteRemoteAddres ;
      private string A347AssinaturaParticipanteGeolocalizacao ;
      private string A348AssinaturaParticipanteDispositivo ;
      private string A350AssinaturaParticipanteCPF ;
      private string A351AssinaturaParticipanteEmail ;
      private string A354AssinaturaParticipanteLink ;
      private string Z248ParticipanteNome ;
      private string Z235ParticipanteEmail ;
      private string Z234ParticipanteDocumento ;
      private string ZZ353AssinaturaParticipanteStatus ;
      private string ZZ247AssinaturaParticipanteTipo ;
      private string ZZ346AssinaturaParticipanteRemoteAddres ;
      private string ZZ347AssinaturaParticipanteGeolocalizacao ;
      private string ZZ348AssinaturaParticipanteDispositivo ;
      private string ZZ350AssinaturaParticipanteCPF ;
      private string ZZ351AssinaturaParticipanteEmail ;
      private string ZZ354AssinaturaParticipanteLink ;
      private string ZZ248ParticipanteNome ;
      private string ZZ235ParticipanteEmail ;
      private string ZZ234ParticipanteDocumento ;
      private Guid Z246AssinaturaParticipanteKey ;
      private Guid A246AssinaturaParticipanteKey ;
      private Guid i246AssinaturaParticipanteKey ;
      private Guid ZZ246AssinaturaParticipanteKey ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAssinaturaParticipanteStatus ;
      private GXCombobox cmbAssinaturaParticipanteTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T00127_A242AssinaturaParticipanteId ;
      private bool[] T00127_n242AssinaturaParticipanteId ;
      private string[] T00127_A248ParticipanteNome ;
      private bool[] T00127_n248ParticipanteNome ;
      private string[] T00127_A235ParticipanteEmail ;
      private bool[] T00127_n235ParticipanteEmail ;
      private string[] T00127_A234ParticipanteDocumento ;
      private bool[] T00127_n234ParticipanteDocumento ;
      private string[] T00127_A353AssinaturaParticipanteStatus ;
      private bool[] T00127_n353AssinaturaParticipanteStatus ;
      private DateTime[] T00127_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] T00127_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] T00127_A245AssinaturaParticipanteDataConclusao ;
      private bool[] T00127_n245AssinaturaParticipanteDataConclusao ;
      private Guid[] T00127_A246AssinaturaParticipanteKey ;
      private bool[] T00127_n246AssinaturaParticipanteKey ;
      private string[] T00127_A247AssinaturaParticipanteTipo ;
      private bool[] T00127_n247AssinaturaParticipanteTipo ;
      private string[] T00127_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] T00127_n346AssinaturaParticipanteRemoteAddres ;
      private string[] T00127_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] T00127_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] T00127_A348AssinaturaParticipanteDispositivo ;
      private bool[] T00127_n348AssinaturaParticipanteDispositivo ;
      private string[] T00127_A350AssinaturaParticipanteCPF ;
      private bool[] T00127_n350AssinaturaParticipanteCPF ;
      private string[] T00127_A351AssinaturaParticipanteEmail ;
      private bool[] T00127_n351AssinaturaParticipanteEmail ;
      private DateTime[] T00127_A352AssinaturaParticipanteNascimento ;
      private bool[] T00127_n352AssinaturaParticipanteNascimento ;
      private string[] T00127_A354AssinaturaParticipanteLink ;
      private bool[] T00127_n354AssinaturaParticipanteLink ;
      private int[] T00127_A233ParticipanteId ;
      private bool[] T00127_n233ParticipanteId ;
      private int[] T00127_A168ClienteId ;
      private bool[] T00127_n168ClienteId ;
      private long[] T00127_A238AssinaturaId ;
      private bool[] T00127_n238AssinaturaId ;
      private long[] T00126_A238AssinaturaId ;
      private bool[] T00126_n238AssinaturaId ;
      private string[] T00124_A248ParticipanteNome ;
      private bool[] T00124_n248ParticipanteNome ;
      private string[] T00124_A235ParticipanteEmail ;
      private bool[] T00124_n235ParticipanteEmail ;
      private string[] T00124_A234ParticipanteDocumento ;
      private bool[] T00124_n234ParticipanteDocumento ;
      private int[] T00125_A168ClienteId ;
      private bool[] T00125_n168ClienteId ;
      private long[] T00128_A238AssinaturaId ;
      private bool[] T00128_n238AssinaturaId ;
      private string[] T00129_A248ParticipanteNome ;
      private bool[] T00129_n248ParticipanteNome ;
      private string[] T00129_A235ParticipanteEmail ;
      private bool[] T00129_n235ParticipanteEmail ;
      private string[] T00129_A234ParticipanteDocumento ;
      private bool[] T00129_n234ParticipanteDocumento ;
      private int[] T001210_A168ClienteId ;
      private bool[] T001210_n168ClienteId ;
      private int[] T001211_A242AssinaturaParticipanteId ;
      private bool[] T001211_n242AssinaturaParticipanteId ;
      private int[] T00123_A242AssinaturaParticipanteId ;
      private bool[] T00123_n242AssinaturaParticipanteId ;
      private string[] T00123_A353AssinaturaParticipanteStatus ;
      private bool[] T00123_n353AssinaturaParticipanteStatus ;
      private DateTime[] T00123_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] T00123_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] T00123_A245AssinaturaParticipanteDataConclusao ;
      private bool[] T00123_n245AssinaturaParticipanteDataConclusao ;
      private Guid[] T00123_A246AssinaturaParticipanteKey ;
      private bool[] T00123_n246AssinaturaParticipanteKey ;
      private string[] T00123_A247AssinaturaParticipanteTipo ;
      private bool[] T00123_n247AssinaturaParticipanteTipo ;
      private string[] T00123_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] T00123_n346AssinaturaParticipanteRemoteAddres ;
      private string[] T00123_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] T00123_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] T00123_A348AssinaturaParticipanteDispositivo ;
      private bool[] T00123_n348AssinaturaParticipanteDispositivo ;
      private string[] T00123_A350AssinaturaParticipanteCPF ;
      private bool[] T00123_n350AssinaturaParticipanteCPF ;
      private string[] T00123_A351AssinaturaParticipanteEmail ;
      private bool[] T00123_n351AssinaturaParticipanteEmail ;
      private DateTime[] T00123_A352AssinaturaParticipanteNascimento ;
      private bool[] T00123_n352AssinaturaParticipanteNascimento ;
      private string[] T00123_A354AssinaturaParticipanteLink ;
      private bool[] T00123_n354AssinaturaParticipanteLink ;
      private int[] T00123_A233ParticipanteId ;
      private bool[] T00123_n233ParticipanteId ;
      private int[] T00123_A168ClienteId ;
      private bool[] T00123_n168ClienteId ;
      private long[] T00123_A238AssinaturaId ;
      private bool[] T00123_n238AssinaturaId ;
      private int[] T001212_A242AssinaturaParticipanteId ;
      private bool[] T001212_n242AssinaturaParticipanteId ;
      private int[] T001213_A242AssinaturaParticipanteId ;
      private bool[] T001213_n242AssinaturaParticipanteId ;
      private int[] T00122_A242AssinaturaParticipanteId ;
      private bool[] T00122_n242AssinaturaParticipanteId ;
      private string[] T00122_A353AssinaturaParticipanteStatus ;
      private bool[] T00122_n353AssinaturaParticipanteStatus ;
      private DateTime[] T00122_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] T00122_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] T00122_A245AssinaturaParticipanteDataConclusao ;
      private bool[] T00122_n245AssinaturaParticipanteDataConclusao ;
      private Guid[] T00122_A246AssinaturaParticipanteKey ;
      private bool[] T00122_n246AssinaturaParticipanteKey ;
      private string[] T00122_A247AssinaturaParticipanteTipo ;
      private bool[] T00122_n247AssinaturaParticipanteTipo ;
      private string[] T00122_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] T00122_n346AssinaturaParticipanteRemoteAddres ;
      private string[] T00122_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] T00122_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] T00122_A348AssinaturaParticipanteDispositivo ;
      private bool[] T00122_n348AssinaturaParticipanteDispositivo ;
      private string[] T00122_A350AssinaturaParticipanteCPF ;
      private bool[] T00122_n350AssinaturaParticipanteCPF ;
      private string[] T00122_A351AssinaturaParticipanteEmail ;
      private bool[] T00122_n351AssinaturaParticipanteEmail ;
      private DateTime[] T00122_A352AssinaturaParticipanteNascimento ;
      private bool[] T00122_n352AssinaturaParticipanteNascimento ;
      private string[] T00122_A354AssinaturaParticipanteLink ;
      private bool[] T00122_n354AssinaturaParticipanteLink ;
      private int[] T00122_A233ParticipanteId ;
      private bool[] T00122_n233ParticipanteId ;
      private int[] T00122_A168ClienteId ;
      private bool[] T00122_n168ClienteId ;
      private long[] T00122_A238AssinaturaId ;
      private bool[] T00122_n238AssinaturaId ;
      private int[] T001215_A242AssinaturaParticipanteId ;
      private bool[] T001215_n242AssinaturaParticipanteId ;
      private string[] T001218_A248ParticipanteNome ;
      private bool[] T001218_n248ParticipanteNome ;
      private string[] T001218_A235ParticipanteEmail ;
      private bool[] T001218_n235ParticipanteEmail ;
      private string[] T001218_A234ParticipanteDocumento ;
      private bool[] T001218_n234ParticipanteDocumento ;
      private int[] T001219_A554AssinaturaParticipanteTokenId ;
      private int[] T001220_A258AssinaturaParticipanteNotificacaoId ;
      private int[] T001221_A242AssinaturaParticipanteId ;
      private bool[] T001221_n242AssinaturaParticipanteId ;
      private long[] T001222_A238AssinaturaId ;
      private bool[] T001222_n238AssinaturaId ;
      private int[] T001223_A168ClienteId ;
      private bool[] T001223_n168ClienteId ;
   }

   public class assinaturaparticipante__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00122;
          prmT00122 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00123;
          prmT00123 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00124;
          prmT00124 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT00125;
          prmT00125 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00126;
          prmT00126 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT00127;
          prmT00127 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00128;
          prmT00128 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT00129;
          prmT00129 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT001210;
          prmT001210 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001211;
          prmT001211 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001212;
          prmT001212 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001213;
          prmT001213 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001214;
          prmT001214 = new Object[] {
          new ParDef("AssinaturaParticipanteStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataVisualizacao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataConclusao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteRemoteAddres",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteGeolocalizacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDispositivo",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteLink",GXType.VarChar,256,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001215;
          prmT001215 = new Object[] {
          };
          Object[] prmT001216;
          prmT001216 = new Object[] {
          new ParDef("AssinaturaParticipanteStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataVisualizacao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataConclusao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteRemoteAddres",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteGeolocalizacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDispositivo",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteLink",GXType.VarChar,256,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001217;
          prmT001217 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001218;
          prmT001218 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT001219;
          prmT001219 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001220;
          prmT001220 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001221;
          prmT001221 = new Object[] {
          };
          Object[] prmT001222;
          prmT001222 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001223;
          prmT001223 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00122", "SELECT AssinaturaParticipanteId, AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao, AssinaturaParticipanteKey, AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF, AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento, AssinaturaParticipanteLink, ParticipanteId, ClienteId, AssinaturaId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId  FOR UPDATE OF AssinaturaParticipante NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00122,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00123", "SELECT AssinaturaParticipanteId, AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao, AssinaturaParticipanteKey, AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF, AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento, AssinaturaParticipanteLink, ParticipanteId, ClienteId, AssinaturaId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00123,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00124", "SELECT ParticipanteNome, ParticipanteEmail, ParticipanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00124,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00125", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00125,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00126", "SELECT AssinaturaId FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00126,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00127", "SELECT TM1.AssinaturaParticipanteId, T2.ParticipanteNome, T2.ParticipanteEmail, T2.ParticipanteDocumento, TM1.AssinaturaParticipanteStatus, TM1.AssinaturaParticipanteDataVisualizacao, TM1.AssinaturaParticipanteDataConclusao, TM1.AssinaturaParticipanteKey, TM1.AssinaturaParticipanteTipo, TM1.AssinaturaParticipanteRemoteAddres, TM1.AssinaturaParticipanteGeolocalizacao, TM1.AssinaturaParticipanteDispositivo, TM1.AssinaturaParticipanteCPF, TM1.AssinaturaParticipanteEmail, TM1.AssinaturaParticipanteNascimento, TM1.AssinaturaParticipanteLink, TM1.ParticipanteId, TM1.ClienteId, TM1.AssinaturaId FROM (AssinaturaParticipante TM1 LEFT JOIN Participante T2 ON T2.ParticipanteId = TM1.ParticipanteId) WHERE TM1.AssinaturaParticipanteId = :AssinaturaParticipanteId ORDER BY TM1.AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00127,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00128", "SELECT AssinaturaId FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00128,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00129", "SELECT ParticipanteNome, ParticipanteEmail, ParticipanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00129,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001210", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001211", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001212", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ( AssinaturaParticipanteId > :AssinaturaParticipanteId) ORDER BY AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001213", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ( AssinaturaParticipanteId < :AssinaturaParticipanteId) ORDER BY AssinaturaParticipanteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001214", "SAVEPOINT gxupdate;INSERT INTO AssinaturaParticipante(AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao, AssinaturaParticipanteKey, AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF, AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento, AssinaturaParticipanteLink, ParticipanteId, ClienteId, AssinaturaId) VALUES(:AssinaturaParticipanteStatus, :AssinaturaParticipanteDataVisualizacao, :AssinaturaParticipanteDataConclusao, :AssinaturaParticipanteKey, :AssinaturaParticipanteTipo, :AssinaturaParticipanteRemoteAddres, :AssinaturaParticipanteGeolocalizacao, :AssinaturaParticipanteDispositivo, :AssinaturaParticipanteCPF, :AssinaturaParticipanteEmail, :AssinaturaParticipanteNascimento, :AssinaturaParticipanteLink, :ParticipanteId, :ClienteId, :AssinaturaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001214)
             ,new CursorDef("T001215", "SELECT currval('AssinaturaParticipanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001215,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001216", "SAVEPOINT gxupdate;UPDATE AssinaturaParticipante SET AssinaturaParticipanteStatus=:AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao=:AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao=:AssinaturaParticipanteDataConclusao, AssinaturaParticipanteKey=:AssinaturaParticipanteKey, AssinaturaParticipanteTipo=:AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres=:AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao=:AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo=:AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF=:AssinaturaParticipanteCPF, AssinaturaParticipanteEmail=:AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento=:AssinaturaParticipanteNascimento, AssinaturaParticipanteLink=:AssinaturaParticipanteLink, ParticipanteId=:ParticipanteId, ClienteId=:ClienteId, AssinaturaId=:AssinaturaId  WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001216)
             ,new CursorDef("T001217", "SAVEPOINT gxupdate;DELETE FROM AssinaturaParticipante  WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001217)
             ,new CursorDef("T001218", "SELECT ParticipanteNome, ParticipanteEmail, ParticipanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001219", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001220", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001220,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001221", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante ORDER BY AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001221,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001222", "SELECT AssinaturaId FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001222,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001223", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001223,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((long[]) buf[29])[0] = rslt.getLong(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((long[]) buf[29])[0] = rslt.getLong(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((long[]) buf[35])[0] = rslt.getLong(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
