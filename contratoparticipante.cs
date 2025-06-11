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
   public class contratoparticipante : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A227ContratoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
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
            gxLoad_3( A233ParticipanteId) ;
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
         Form.Meta.addItem("description", "Contrato Participante", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtContratoParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public contratoparticipante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contratoparticipante( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Contrato Participante", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ContratoParticipante.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ContratoParticipante.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContratoParticipanteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoParticipanteId_Internalname, "Participante Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoParticipanteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237ContratoParticipanteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtContratoParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A237ContratoParticipanteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A237ContratoParticipanteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtContratoParticipanteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContratoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoId_Internalname, "Contrato Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoId_Internalname, ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", ""))), ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( ((edtContratoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtContratoId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContratoParticipante.htm");
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
         GxWebStd.gx_single_line_edit( context, edtParticipanteId_Internalname, ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", ""))), ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( ((edtParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParticipanteId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ContratoParticipante.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoParticipante.htm");
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
            Z237ContratoParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z237ContratoParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            Z227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
            n227ContratoId = ((0==A227ContratoId) ? true : false);
            Z233ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z233ParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            n233ParticipanteId = ((0==A233ParticipanteId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtContratoParticipanteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContratoParticipanteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTRATOPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtContratoParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A237ContratoParticipanteId = 0;
               AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
            }
            else
            {
               A237ContratoParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
            }
            n227ContratoId = ((StringUtil.StrCmp(cgiGet( edtContratoId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
            else
            {
               A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
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
               A237ContratoParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoParticipanteId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
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
               InitAll1039( ) ;
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
         DisableAttributes1039( ) ;
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

      protected void ResetCaption100( )
      {
      }

      protected void ZM1039( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z227ContratoId = T00103_A227ContratoId[0];
               Z233ParticipanteId = T00103_A233ParticipanteId[0];
            }
            else
            {
               Z227ContratoId = A227ContratoId;
               Z233ParticipanteId = A233ParticipanteId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z237ContratoParticipanteId = A237ContratoParticipanteId;
            Z227ContratoId = A227ContratoId;
            Z233ParticipanteId = A233ParticipanteId;
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

      protected void Load1039( )
      {
         /* Using cursor T00106 */
         pr_default.execute(4, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound39 = 1;
            A227ContratoId = T00106_A227ContratoId[0];
            n227ContratoId = T00106_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            A233ParticipanteId = T00106_A233ParticipanteId[0];
            n233ParticipanteId = T00106_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            ZM1039( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1039( ) ;
      }

      protected void OnLoadActions1039( )
      {
      }

      protected void CheckExtendedTable1039( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00104 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T00105 */
         pr_default.execute(3, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1039( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A227ContratoId )
      {
         /* Using cursor T00107 */
         pr_default.execute(5, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A233ParticipanteId )
      {
         /* Using cursor T00108 */
         pr_default.execute(6, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtParticipanteId_Internalname;
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

      protected void GetKey1039( )
      {
         /* Using cursor T00109 */
         pr_default.execute(7, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00103 */
         pr_default.execute(1, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1039( 1) ;
            RcdFound39 = 1;
            A237ContratoParticipanteId = T00103_A237ContratoParticipanteId[0];
            AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
            A227ContratoId = T00103_A227ContratoId[0];
            n227ContratoId = T00103_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            A233ParticipanteId = T00103_A233ParticipanteId[0];
            n233ParticipanteId = T00103_n233ParticipanteId[0];
            AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
            Z237ContratoParticipanteId = A237ContratoParticipanteId;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1039( ) ;
            if ( AnyError == 1 )
            {
               RcdFound39 = 0;
               InitializeNonKey1039( ) ;
            }
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey1039( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1039( ) ;
         if ( RcdFound39 == 0 )
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
         RcdFound39 = 0;
         /* Using cursor T001010 */
         pr_default.execute(8, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001010_A237ContratoParticipanteId[0] < A237ContratoParticipanteId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001010_A237ContratoParticipanteId[0] > A237ContratoParticipanteId ) ) )
            {
               A237ContratoParticipanteId = T001010_A237ContratoParticipanteId[0];
               AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
               RcdFound39 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound39 = 0;
         /* Using cursor T001011 */
         pr_default.execute(9, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001011_A237ContratoParticipanteId[0] > A237ContratoParticipanteId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001011_A237ContratoParticipanteId[0] < A237ContratoParticipanteId ) ) )
            {
               A237ContratoParticipanteId = T001011_A237ContratoParticipanteId[0];
               AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
               RcdFound39 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1039( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtContratoParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1039( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound39 == 1 )
            {
               if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
               {
                  A237ContratoParticipanteId = Z237ContratoParticipanteId;
                  AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONTRATOPARTICIPANTEID");
                  AnyError = 1;
                  GX_FocusControl = edtContratoParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtContratoParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1039( ) ;
                  GX_FocusControl = edtContratoParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtContratoParticipanteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1039( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONTRATOPARTICIPANTEID");
                     AnyError = 1;
                     GX_FocusControl = edtContratoParticipanteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtContratoParticipanteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1039( ) ;
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
         if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
         {
            A237ContratoParticipanteId = Z237ContratoParticipanteId;
            AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONTRATOPARTICIPANTEID");
            AnyError = 1;
            GX_FocusControl = edtContratoParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtContratoParticipanteId_Internalname;
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
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CONTRATOPARTICIPANTEID");
            AnyError = 1;
            GX_FocusControl = edtContratoParticipanteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtContratoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1039( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContratoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1039( ) ;
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
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContratoId_Internalname;
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
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContratoId_Internalname;
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
         ScanStart1039( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound39 != 0 )
            {
               ScanNext1039( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtContratoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1039( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1039( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00102 */
            pr_default.execute(0, new Object[] {A237ContratoParticipanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContratoParticipante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z227ContratoId != T00102_A227ContratoId[0] ) || ( Z233ParticipanteId != T00102_A233ParticipanteId[0] ) )
            {
               if ( Z227ContratoId != T00102_A227ContratoId[0] )
               {
                  GXUtil.WriteLog("contratoparticipante:[seudo value changed for attri]"+"ContratoId");
                  GXUtil.WriteLogRaw("Old: ",Z227ContratoId);
                  GXUtil.WriteLogRaw("Current: ",T00102_A227ContratoId[0]);
               }
               if ( Z233ParticipanteId != T00102_A233ParticipanteId[0] )
               {
                  GXUtil.WriteLog("contratoparticipante:[seudo value changed for attri]"+"ParticipanteId");
                  GXUtil.WriteLogRaw("Old: ",Z233ParticipanteId);
                  GXUtil.WriteLogRaw("Current: ",T00102_A233ParticipanteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ContratoParticipante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1039( )
      {
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1039( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1039( 0) ;
            CheckOptimisticConcurrency1039( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1039( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1039( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001012 */
                     pr_default.execute(10, new Object[] {n227ContratoId, A227ContratoId, n233ParticipanteId, A233ParticipanteId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001013 */
                     pr_default.execute(11);
                     A237ContratoParticipanteId = T001013_A237ContratoParticipanteId[0];
                     AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ContratoParticipante");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption100( ) ;
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
               Load1039( ) ;
            }
            EndLevel1039( ) ;
         }
         CloseExtendedTableCursors1039( ) ;
      }

      protected void Update1039( )
      {
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1039( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1039( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1039( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1039( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001014 */
                     pr_default.execute(12, new Object[] {n227ContratoId, A227ContratoId, n233ParticipanteId, A233ParticipanteId, A237ContratoParticipanteId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ContratoParticipante");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContratoParticipante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1039( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption100( ) ;
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
            EndLevel1039( ) ;
         }
         CloseExtendedTableCursors1039( ) ;
      }

      protected void DeferredUpdate1039( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1039( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1039( ) ;
            AfterConfirm1039( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1039( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001015 */
                  pr_default.execute(13, new Object[] {A237ContratoParticipanteId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("ContratoParticipante");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound39 == 0 )
                        {
                           InitAll1039( ) ;
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
                        ResetCaption100( ) ;
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
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1039( ) ;
         Gx_mode = sMode39;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1039( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1039( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1039( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues100( ) ;
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

      public void ScanStart1039( )
      {
         /* Using cursor T001016 */
         pr_default.execute(14);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound39 = 1;
            A237ContratoParticipanteId = T001016_A237ContratoParticipanteId[0];
            AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1039( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound39 = 1;
            A237ContratoParticipanteId = T001016_A237ContratoParticipanteId[0];
            AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
         }
      }

      protected void ScanEnd1039( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1039( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1039( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1039( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1039( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1039( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1039( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1039( )
      {
         edtContratoParticipanteId_Enabled = 0;
         AssignProp("", false, edtContratoParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoParticipanteId_Enabled), 5, 0), true);
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         edtParticipanteId_Enabled = 0;
         AssignProp("", false, edtParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParticipanteId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1039( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues100( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contratoparticipante") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z237ContratoParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237ContratoParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z233ParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233ParticipanteId), 8, 0, ",", "")));
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
         return formatLink("contratoparticipante")  ;
      }

      public override string GetPgmname( )
      {
         return "ContratoParticipante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contrato Participante" ;
      }

      protected void InitializeNonKey1039( )
      {
         A227ContratoId = 0;
         n227ContratoId = false;
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         n227ContratoId = ((0==A227ContratoId) ? true : false);
         A233ParticipanteId = 0;
         n233ParticipanteId = false;
         AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         n233ParticipanteId = ((0==A233ParticipanteId) ? true : false);
         Z227ContratoId = 0;
         Z233ParticipanteId = 0;
      }

      protected void InitAll1039( )
      {
         A237ContratoParticipanteId = 0;
         AssignAttri("", false, "A237ContratoParticipanteId", StringUtil.LTrimStr( (decimal)(A237ContratoParticipanteId), 9, 0));
         InitializeNonKey1039( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019135693", true, true);
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
         context.AddJavascriptSource("contratoparticipante.js", "?202561019135693", false, true);
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
         edtContratoParticipanteId_Internalname = "CONTRATOPARTICIPANTEID";
         edtContratoId_Internalname = "CONTRATOID";
         edtParticipanteId_Internalname = "PARTICIPANTEID";
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
         Form.Caption = "Contrato Participante";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParticipanteId_Jsonclick = "";
         edtParticipanteId_Enabled = 1;
         edtContratoId_Jsonclick = "";
         edtContratoId_Enabled = 1;
         edtContratoParticipanteId_Jsonclick = "";
         edtContratoParticipanteId_Enabled = 1;
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
         GX_FocusControl = edtContratoId_Internalname;
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

      public void Valid_Contratoparticipanteid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         AssignAttri("", false, "A233ParticipanteId", ((0==A233ParticipanteId)&&IsIns( )||n233ParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z237ContratoParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237ContratoParticipanteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z233ParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233ParticipanteId), 8, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Contratoid( )
      {
         /* Using cursor T001017 */
         pr_default.execute(15, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
            }
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Participanteid( )
      {
         /* Using cursor T001018 */
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
         pr_default.close(16);
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
         setEventMetadata("VALID_CONTRATOPARTICIPANTEID","""{"handler":"Valid_Contratoparticipanteid","iparms":[{"av":"A237ContratoParticipanteId","fld":"CONTRATOPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_CONTRATOPARTICIPANTEID",""","oparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","nullAv":"n233ParticipanteId","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z237ContratoParticipanteId","type":"int"},{"av":"Z227ContratoId","type":"int"},{"av":"Z233ParticipanteId","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"}]}""");
         setEventMetadata("VALID_PARTICIPANTEID","""{"handler":"Valid_Participanteid","iparms":[{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","nullAv":"n233ParticipanteId","type":"int"}]}""");
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
         pr_default.close(15);
         pr_default.close(16);
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
         T00106_A237ContratoParticipanteId = new int[1] ;
         T00106_A227ContratoId = new int[1] ;
         T00106_n227ContratoId = new bool[] {false} ;
         T00106_A233ParticipanteId = new int[1] ;
         T00106_n233ParticipanteId = new bool[] {false} ;
         T00104_A227ContratoId = new int[1] ;
         T00104_n227ContratoId = new bool[] {false} ;
         T00105_A233ParticipanteId = new int[1] ;
         T00105_n233ParticipanteId = new bool[] {false} ;
         T00107_A227ContratoId = new int[1] ;
         T00107_n227ContratoId = new bool[] {false} ;
         T00108_A233ParticipanteId = new int[1] ;
         T00108_n233ParticipanteId = new bool[] {false} ;
         T00109_A237ContratoParticipanteId = new int[1] ;
         T00103_A237ContratoParticipanteId = new int[1] ;
         T00103_A227ContratoId = new int[1] ;
         T00103_n227ContratoId = new bool[] {false} ;
         T00103_A233ParticipanteId = new int[1] ;
         T00103_n233ParticipanteId = new bool[] {false} ;
         sMode39 = "";
         T001010_A237ContratoParticipanteId = new int[1] ;
         T001011_A237ContratoParticipanteId = new int[1] ;
         T00102_A237ContratoParticipanteId = new int[1] ;
         T00102_A227ContratoId = new int[1] ;
         T00102_n227ContratoId = new bool[] {false} ;
         T00102_A233ParticipanteId = new int[1] ;
         T00102_n233ParticipanteId = new bool[] {false} ;
         T001013_A237ContratoParticipanteId = new int[1] ;
         T001016_A237ContratoParticipanteId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001017_A227ContratoId = new int[1] ;
         T001017_n227ContratoId = new bool[] {false} ;
         T001018_A233ParticipanteId = new int[1] ;
         T001018_n233ParticipanteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contratoparticipante__default(),
            new Object[][] {
                new Object[] {
               T00102_A237ContratoParticipanteId, T00102_A227ContratoId, T00102_n227ContratoId, T00102_A233ParticipanteId, T00102_n233ParticipanteId
               }
               , new Object[] {
               T00103_A237ContratoParticipanteId, T00103_A227ContratoId, T00103_n227ContratoId, T00103_A233ParticipanteId, T00103_n233ParticipanteId
               }
               , new Object[] {
               T00104_A227ContratoId
               }
               , new Object[] {
               T00105_A233ParticipanteId
               }
               , new Object[] {
               T00106_A237ContratoParticipanteId, T00106_A227ContratoId, T00106_n227ContratoId, T00106_A233ParticipanteId, T00106_n233ParticipanteId
               }
               , new Object[] {
               T00107_A227ContratoId
               }
               , new Object[] {
               T00108_A233ParticipanteId
               }
               , new Object[] {
               T00109_A237ContratoParticipanteId
               }
               , new Object[] {
               T001010_A237ContratoParticipanteId
               }
               , new Object[] {
               T001011_A237ContratoParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               T001013_A237ContratoParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001016_A237ContratoParticipanteId
               }
               , new Object[] {
               T001017_A227ContratoId
               }
               , new Object[] {
               T001018_A233ParticipanteId
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
      private short RcdFound39 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z237ContratoParticipanteId ;
      private int Z227ContratoId ;
      private int Z233ParticipanteId ;
      private int A227ContratoId ;
      private int A233ParticipanteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A237ContratoParticipanteId ;
      private int edtContratoParticipanteId_Enabled ;
      private int edtContratoId_Enabled ;
      private int edtParticipanteId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ237ContratoParticipanteId ;
      private int ZZ227ContratoId ;
      private int ZZ233ParticipanteId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtContratoParticipanteId_Internalname ;
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
      private string edtContratoParticipanteId_Jsonclick ;
      private string edtContratoId_Internalname ;
      private string edtContratoId_Jsonclick ;
      private string edtParticipanteId_Internalname ;
      private string edtParticipanteId_Jsonclick ;
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
      private string sMode39 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n227ContratoId ;
      private bool n233ParticipanteId ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00106_A237ContratoParticipanteId ;
      private int[] T00106_A227ContratoId ;
      private bool[] T00106_n227ContratoId ;
      private int[] T00106_A233ParticipanteId ;
      private bool[] T00106_n233ParticipanteId ;
      private int[] T00104_A227ContratoId ;
      private bool[] T00104_n227ContratoId ;
      private int[] T00105_A233ParticipanteId ;
      private bool[] T00105_n233ParticipanteId ;
      private int[] T00107_A227ContratoId ;
      private bool[] T00107_n227ContratoId ;
      private int[] T00108_A233ParticipanteId ;
      private bool[] T00108_n233ParticipanteId ;
      private int[] T00109_A237ContratoParticipanteId ;
      private int[] T00103_A237ContratoParticipanteId ;
      private int[] T00103_A227ContratoId ;
      private bool[] T00103_n227ContratoId ;
      private int[] T00103_A233ParticipanteId ;
      private bool[] T00103_n233ParticipanteId ;
      private int[] T001010_A237ContratoParticipanteId ;
      private int[] T001011_A237ContratoParticipanteId ;
      private int[] T00102_A237ContratoParticipanteId ;
      private int[] T00102_A227ContratoId ;
      private bool[] T00102_n227ContratoId ;
      private int[] T00102_A233ParticipanteId ;
      private bool[] T00102_n233ParticipanteId ;
      private int[] T001013_A237ContratoParticipanteId ;
      private int[] T001016_A237ContratoParticipanteId ;
      private int[] T001017_A227ContratoId ;
      private bool[] T001017_n227ContratoId ;
      private int[] T001018_A233ParticipanteId ;
      private bool[] T001018_n233ParticipanteId ;
   }

   public class contratoparticipante__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00102;
          prmT00102 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT00103;
          prmT00103 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT00104;
          prmT00104 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00105;
          prmT00105 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT00106;
          prmT00106 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT00107;
          prmT00107 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00108;
          prmT00108 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT00109;
          prmT00109 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT001010;
          prmT001010 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT001011;
          prmT001011 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT001012;
          prmT001012 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT001013;
          prmT001013 = new Object[] {
          };
          Object[] prmT001014;
          prmT001014 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT001015;
          prmT001015 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmT001016;
          prmT001016 = new Object[] {
          };
          Object[] prmT001017;
          prmT001017 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001018;
          prmT001018 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00102", "SELECT ContratoParticipanteId, ContratoId, ParticipanteId FROM ContratoParticipante WHERE ContratoParticipanteId = :ContratoParticipanteId  FOR UPDATE OF ContratoParticipante NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00102,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00103", "SELECT ContratoParticipanteId, ContratoId, ParticipanteId FROM ContratoParticipante WHERE ContratoParticipanteId = :ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00103,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00104", "SELECT ContratoId FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00104,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00105", "SELECT ParticipanteId FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00105,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00106", "SELECT TM1.ContratoParticipanteId, TM1.ContratoId, TM1.ParticipanteId FROM ContratoParticipante TM1 WHERE TM1.ContratoParticipanteId = :ContratoParticipanteId ORDER BY TM1.ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00106,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00107", "SELECT ContratoId FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00107,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00108", "SELECT ParticipanteId FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00108,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00109", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ContratoParticipanteId = :ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00109,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001010", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ( ContratoParticipanteId > :ContratoParticipanteId) ORDER BY ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001010,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001011", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ( ContratoParticipanteId < :ContratoParticipanteId) ORDER BY ContratoParticipanteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001011,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001012", "SAVEPOINT gxupdate;INSERT INTO ContratoParticipante(ContratoId, ParticipanteId) VALUES(:ContratoId, :ParticipanteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001012)
             ,new CursorDef("T001013", "SELECT currval('ContratoParticipanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001014", "SAVEPOINT gxupdate;UPDATE ContratoParticipante SET ContratoId=:ContratoId, ParticipanteId=:ParticipanteId  WHERE ContratoParticipanteId = :ContratoParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001014)
             ,new CursorDef("T001015", "SAVEPOINT gxupdate;DELETE FROM ContratoParticipante  WHERE ContratoParticipanteId = :ContratoParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001015)
             ,new CursorDef("T001016", "SELECT ContratoParticipanteId FROM ContratoParticipante ORDER BY ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001016,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001017", "SELECT ContratoId FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001018", "SELECT ParticipanteId FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001018,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
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
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
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
       }
    }

 }

}
