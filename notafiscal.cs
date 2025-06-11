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
   public class notafiscal : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A794NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A794NotaFiscalId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A794NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A794NotaFiscalId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
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
            gxLoad_15( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A889NotaFiscalDestinatarioClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "NotaFiscalDestinatarioClienteId"), "."), 18, MidpointRounding.ToEven));
            n889NotaFiscalDestinatarioClienteId = false;
            AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A889NotaFiscalDestinatarioClienteId) ;
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
         Form.Meta.addItem("description", "Nota Fiscal", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNotaFiscalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public notafiscal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscal( IGxContext context )
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
         cmbNotaFiscalUF = new GXCombobox();
         cmbNotaFiscalStatus = new GXCombobox();
         cmbNotaFiscalTipo = new GXCombobox();
         cmbNotaFiscalTipoEmissao = new GXCombobox();
         cmbNotaFiscalAmbiente = new GXCombobox();
         cmbNotaFiscalFinalidades = new GXCombobox();
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
         if ( cmbNotaFiscalUF.ItemCount > 0 )
         {
            A795NotaFiscalUF = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalUF.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n795NotaFiscalUF = false;
            AssignAttri("", false, "A795NotaFiscalUF", ((0==A795NotaFiscalUF)&&IsIns( )||n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalUF.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0));
            AssignProp("", false, cmbNotaFiscalUF_Internalname, "Values", cmbNotaFiscalUF.ToJavascriptSource(), true);
         }
         if ( cmbNotaFiscalStatus.ItemCount > 0 )
         {
            A880NotaFiscalStatus = cmbNotaFiscalStatus.getValidValue(A880NotaFiscalStatus);
            AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalStatus.CurrentValue = StringUtil.RTrim( A880NotaFiscalStatus);
            AssignProp("", false, cmbNotaFiscalStatus_Internalname, "Values", cmbNotaFiscalStatus.ToJavascriptSource(), true);
         }
         if ( cmbNotaFiscalTipo.ItemCount > 0 )
         {
            A802NotaFiscalTipo = cmbNotaFiscalTipo.getValidValue(A802NotaFiscalTipo);
            n802NotaFiscalTipo = false;
            AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalTipo.CurrentValue = StringUtil.RTrim( A802NotaFiscalTipo);
            AssignProp("", false, cmbNotaFiscalTipo_Internalname, "Values", cmbNotaFiscalTipo.ToJavascriptSource(), true);
         }
         if ( cmbNotaFiscalTipoEmissao.ItemCount > 0 )
         {
            A804NotaFiscalTipoEmissao = cmbNotaFiscalTipoEmissao.getValidValue(A804NotaFiscalTipoEmissao);
            n804NotaFiscalTipoEmissao = false;
            AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalTipoEmissao.CurrentValue = StringUtil.RTrim( A804NotaFiscalTipoEmissao);
            AssignProp("", false, cmbNotaFiscalTipoEmissao_Internalname, "Values", cmbNotaFiscalTipoEmissao.ToJavascriptSource(), true);
         }
         if ( cmbNotaFiscalAmbiente.ItemCount > 0 )
         {
            A805NotaFiscalAmbiente = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalAmbiente.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n805NotaFiscalAmbiente = false;
            AssignAttri("", false, "A805NotaFiscalAmbiente", ((0==A805NotaFiscalAmbiente)&&IsIns( )||n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalAmbiente.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0));
            AssignProp("", false, cmbNotaFiscalAmbiente_Internalname, "Values", cmbNotaFiscalAmbiente.ToJavascriptSource(), true);
         }
         if ( cmbNotaFiscalFinalidades.ItemCount > 0 )
         {
            A806NotaFiscalFinalidades = cmbNotaFiscalFinalidades.getValidValue(A806NotaFiscalFinalidades);
            n806NotaFiscalFinalidades = false;
            AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalFinalidades.CurrentValue = StringUtil.RTrim( A806NotaFiscalFinalidades);
            AssignProp("", false, cmbNotaFiscalFinalidades_Internalname, "Values", cmbNotaFiscalFinalidades.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Nota Fiscal", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_NotaFiscal.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_NotaFiscal.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalId_Internalname, "Fiscal Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalId_Internalname, A794NotaFiscalId.ToString(), A794NotaFiscalId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscal.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotaFiscalUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotaFiscalUF_Internalname, "Fiscal UF", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotaFiscalUF, cmbNotaFiscalUF_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0)), 1, cmbNotaFiscalUF_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbNotaFiscalUF.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_NotaFiscal.htm");
         cmbNotaFiscalUF.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0));
         AssignProp("", false, cmbNotaFiscalUF_Internalname, "Values", (string)(cmbNotaFiscalUF.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalValorTotal_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalValorTotal_F_Internalname, "Valor Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalValorTotal_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A874NotaFiscalValorTotal_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtNotaFiscalValorTotal_F_Enabled!=0) ? context.localUtil.Format( A874NotaFiscalValorTotal_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A874NotaFiscalValorTotal_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalValorTotal_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalValorTotal_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalValorTotalVendido_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalValorTotalVendido_F_Internalname, "Valor vendido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalValorTotalVendido_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A875NotaFiscalValorTotalVendido_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtNotaFiscalValorTotalVendido_F_Enabled!=0) ? context.localUtil.Format( A875NotaFiscalValorTotalVendido_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A875NotaFiscalValorTotalVendido_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalValorTotalVendido_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalValorTotalVendido_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalSaldo_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalSaldo_F_Internalname, "Saldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalSaldo_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A876NotaFiscalSaldo_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtNotaFiscalSaldo_F_Enabled!=0) ? context.localUtil.Format( A876NotaFiscalSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A876NotaFiscalSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalSaldo_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalSaldo_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalQuantidadeDeItens_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalQuantidadeDeItens_F_Internalname, "Qtd Itens", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalQuantidadeDeItens_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtNotaFiscalQuantidadeDeItens_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A877NotaFiscalQuantidadeDeItens_F), "ZZZ9") : context.localUtil.Format( (decimal)(A877NotaFiscalQuantidadeDeItens_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalQuantidadeDeItens_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalQuantidadeDeItens_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname, "Itens Vendidos_F", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), "ZZZ9") : context.localUtil.Format( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalQuantidadeDeItensVendidos_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalQuantidadeResumo_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalQuantidadeResumo_F_Internalname, "Quantidade Resumo_F", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalQuantidadeResumo_F_Internalname, A879NotaFiscalQuantidadeResumo_F, StringUtil.RTrim( context.localUtil.Format( A879NotaFiscalQuantidadeResumo_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalQuantidadeResumo_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalQuantidadeResumo_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalValorFormatado_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalValorFormatado_F_Internalname, "Valor formatado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalValorFormatado_F_Internalname, A881NotaFiscalValorFormatado_F, StringUtil.RTrim( context.localUtil.Format( A881NotaFiscalValorFormatado_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalValorFormatado_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalValorFormatado_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalValorVendidoFormatado_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalValorVendidoFormatado_F_Internalname, "Vendido formatado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalValorVendidoFormatado_F_Internalname, A882NotaFiscalValorVendidoFormatado_F, StringUtil.RTrim( context.localUtil.Format( A882NotaFiscalValorVendidoFormatado_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalValorVendidoFormatado_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalValorVendidoFormatado_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalSaldoFormatado_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalSaldoFormatado_F_Internalname, "Saldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalSaldoFormatado_F_Internalname, A883NotaFiscalSaldoFormatado_F, StringUtil.RTrim( context.localUtil.Format( A883NotaFiscalSaldoFormatado_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalSaldoFormatado_F_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalSaldoFormatado_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotaFiscalStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotaFiscalStatus_Internalname, "Fiscal Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotaFiscalStatus, cmbNotaFiscalStatus_Internalname, StringUtil.RTrim( A880NotaFiscalStatus), 1, cmbNotaFiscalStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotaFiscalStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "", true, 0, "HLP_NotaFiscal.htm");
         cmbNotaFiscalStatus.CurrentValue = StringUtil.RTrim( A880NotaFiscalStatus);
         AssignProp("", false, cmbNotaFiscalStatus_Internalname, "Values", (string)(cmbNotaFiscalStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalNatureza_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalNatureza_Internalname, "Fiscal Natureza", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNotaFiscalNatureza_Internalname, A796NotaFiscalNatureza, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", 0, 1, edtNotaFiscalNatureza_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalMod_Internalname, "Fiscal Mod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalMod_Internalname, A797NotaFiscalMod, StringUtil.RTrim( context.localUtil.Format( A797NotaFiscalMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalMod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalMod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalSerie_Internalname, "Fiscal Serie", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalSerie_Internalname, A798NotaFiscalSerie, StringUtil.RTrim( context.localUtil.Format( A798NotaFiscalSerie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalSerie_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalNumero_Internalname, "Fiscal Numero", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalNumero_Internalname, A799NotaFiscalNumero, StringUtil.RTrim( context.localUtil.Format( A799NotaFiscalNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalNumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalNumero_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDataEmissao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDataEmissao_Internalname, "Data Emissao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotaFiscalDataEmissao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDataEmissao_Internalname, context.localUtil.TToC( A800NotaFiscalDataEmissao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A800NotaFiscalDataEmissao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDataEmissao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDataEmissao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_bitmap( context, edtNotaFiscalDataEmissao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotaFiscalDataEmissao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_NotaFiscal.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDataSaida_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDataSaida_Internalname, "Data Saida", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotaFiscalDataSaida_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDataSaida_Internalname, context.localUtil.TToC( A801NotaFiscalDataSaida, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A801NotaFiscalDataSaida, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDataSaida_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDataSaida_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_bitmap( context, edtNotaFiscalDataSaida_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotaFiscalDataSaida_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_NotaFiscal.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotaFiscalTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotaFiscalTipo_Internalname, "Fiscal Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotaFiscalTipo, cmbNotaFiscalTipo_Internalname, StringUtil.RTrim( A802NotaFiscalTipo), 1, cmbNotaFiscalTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotaFiscalTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "", true, 0, "HLP_NotaFiscal.htm");
         cmbNotaFiscalTipo.CurrentValue = StringUtil.RTrim( A802NotaFiscalTipo);
         AssignProp("", false, cmbNotaFiscalTipo_Internalname, "Values", (string)(cmbNotaFiscalTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalMunicipio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalMunicipio_Internalname, "Fiscal Municipio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalMunicipio_Internalname, A803NotaFiscalMunicipio, StringUtil.RTrim( context.localUtil.Format( A803NotaFiscalMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalMunicipio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalMunicipio_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotaFiscalTipoEmissao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotaFiscalTipoEmissao_Internalname, "Tipo Emissao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotaFiscalTipoEmissao, cmbNotaFiscalTipoEmissao_Internalname, StringUtil.RTrim( A804NotaFiscalTipoEmissao), 1, cmbNotaFiscalTipoEmissao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotaFiscalTipoEmissao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "", true, 0, "HLP_NotaFiscal.htm");
         cmbNotaFiscalTipoEmissao.CurrentValue = StringUtil.RTrim( A804NotaFiscalTipoEmissao);
         AssignProp("", false, cmbNotaFiscalTipoEmissao_Internalname, "Values", (string)(cmbNotaFiscalTipoEmissao.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotaFiscalAmbiente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotaFiscalAmbiente_Internalname, "Fiscal Ambiente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotaFiscalAmbiente, cmbNotaFiscalAmbiente_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0)), 1, cmbNotaFiscalAmbiente_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbNotaFiscalAmbiente.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "", true, 0, "HLP_NotaFiscal.htm");
         cmbNotaFiscalAmbiente.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0));
         AssignProp("", false, cmbNotaFiscalAmbiente_Internalname, "Values", (string)(cmbNotaFiscalAmbiente.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotaFiscalFinalidades_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotaFiscalFinalidades_Internalname, "Fiscal Finalidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotaFiscalFinalidades, cmbNotaFiscalFinalidades_Internalname, StringUtil.RTrim( A806NotaFiscalFinalidades), 1, cmbNotaFiscalFinalidades_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotaFiscalFinalidades.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "", true, 0, "HLP_NotaFiscal.htm");
         cmbNotaFiscalFinalidades.CurrentValue = StringUtil.RTrim( A806NotaFiscalFinalidades);
         AssignProp("", false, cmbNotaFiscalFinalidades_Internalname, "Values", (string)(cmbNotaFiscalFinalidades.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscaEmitentelDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscaEmitentelDocumento_Internalname, "Emitentel Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscaEmitentelDocumento_Internalname, A818NotaFiscaEmitentelDocumento, StringUtil.RTrim( context.localUtil.Format( A818NotaFiscaEmitentelDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscaEmitentelDocumento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscaEmitentelDocumento_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteNome_Internalname, "Emitente Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteNome_Internalname, A808NotaFiscalEmitenteNome, StringUtil.RTrim( context.localUtil.Format( A808NotaFiscalEmitenteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteLogradouro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteLogradouro_Internalname, "Emitente Logradouro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteLogradouro_Internalname, A809NotaFiscalEmitenteLogradouro, StringUtil.RTrim( context.localUtil.Format( A809NotaFiscalEmitenteLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteLogradouro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteLogNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteLogNum_Internalname, "Log Num", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteLogNum_Internalname, A810NotaFiscalEmitenteLogNum, StringUtil.RTrim( context.localUtil.Format( A810NotaFiscalEmitenteLogNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteLogNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteLogNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteComplemento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteComplemento_Internalname, "Emitente Complemento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteComplemento_Internalname, A811NotaFiscalEmitenteComplemento, StringUtil.RTrim( context.localUtil.Format( A811NotaFiscalEmitenteComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteComplemento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteComplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteBairro_Internalname, "Emitente Bairro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteBairro_Internalname, A812NotaFiscalEmitenteBairro, StringUtil.RTrim( context.localUtil.Format( A812NotaFiscalEmitenteBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteBairro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteMunicipio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteMunicipio_Internalname, "Emitente Municipio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteMunicipio_Internalname, A813NotaFiscalEmitenteMunicipio, StringUtil.RTrim( context.localUtil.Format( A813NotaFiscalEmitenteMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteMunicipio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteMunicipio_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteUF_Internalname, "Emitente UF", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteUF_Internalname, A814NotaFiscalEmitenteUF, StringUtil.RTrim( context.localUtil.Format( A814NotaFiscalEmitenteUF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteUF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteUF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteCEP_Internalname, "Emitente CEP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteCEP_Internalname, A815NotaFiscalEmitenteCEP, StringUtil.RTrim( context.localUtil.Format( A815NotaFiscalEmitenteCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteCEP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteCEP_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitentePais_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitentePais_Internalname, "Emitente Pais", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitentePais_Internalname, A816NotaFiscalEmitentePais, StringUtil.RTrim( context.localUtil.Format( A816NotaFiscalEmitentePais, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitentePais_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitentePais_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteTelefone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteTelefone_Internalname, "Emitente Telefone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteTelefone_Internalname, A817NotaFiscalEmitenteTelefone, StringUtil.RTrim( context.localUtil.Format( A817NotaFiscalEmitenteTelefone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteTelefone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteTelefone_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalEmitenteIE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalEmitenteIE_Internalname, "Emitente IE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalEmitenteIE_Internalname, A819NotaFiscalEmitenteIE, StringUtil.RTrim( context.localUtil.Format( A819NotaFiscalEmitenteIE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalEmitenteIE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalEmitenteIE_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioClienteId_Internalname, ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ",", ""))), ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( ((edtNotaFiscalDestinatarioClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A889NotaFiscalDestinatarioClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A889NotaFiscalDestinatarioClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,214);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioDocumento_Internalname, "Destinatario Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioDocumento_Internalname, A820NotaFiscalDestinatarioDocumento, StringUtil.RTrim( context.localUtil.Format( A820NotaFiscalDestinatarioDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,219);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioDocumento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioDocumento_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioNome_Internalname, "Destinatario Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioNome_Internalname, A852NotaFiscalDestinatarioNome, StringUtil.RTrim( context.localUtil.Format( A852NotaFiscalDestinatarioNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,224);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioLogradouro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioLogradouro_Internalname, "Destinatario Logradouro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioLogradouro_Internalname, A821NotaFiscalDestinatarioLogradouro, StringUtil.RTrim( context.localUtil.Format( A821NotaFiscalDestinatarioLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,229);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioLogradouro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioLogNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioLogNum_Internalname, "Log Num", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 234,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioLogNum_Internalname, A822NotaFiscalDestinatarioLogNum, StringUtil.RTrim( context.localUtil.Format( A822NotaFiscalDestinatarioLogNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,234);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioLogNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioLogNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioComplemento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioComplemento_Internalname, "Destinatario Complemento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioComplemento_Internalname, A823NotaFiscalDestinatarioComplemento, StringUtil.RTrim( context.localUtil.Format( A823NotaFiscalDestinatarioComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,239);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioComplemento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioComplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioBairro_Internalname, "Destinatario Bairro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioBairro_Internalname, A824NotaFiscalDestinatarioBairro, StringUtil.RTrim( context.localUtil.Format( A824NotaFiscalDestinatarioBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,244);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioBairro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioMunicipio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioMunicipio_Internalname, "Destinatario Municipio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioMunicipio_Internalname, A825NotaFiscalDestinatarioMunicipio, StringUtil.RTrim( context.localUtil.Format( A825NotaFiscalDestinatarioMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,249);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioMunicipio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioMunicipio_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioUF_Internalname, "Destinatario UF", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 254,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioUF_Internalname, A826NotaFiscalDestinatarioUF, StringUtil.RTrim( context.localUtil.Format( A826NotaFiscalDestinatarioUF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,254);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioUF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioUF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioCEP_Internalname, "Destinatario CEP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 259,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioCEP_Internalname, A827NotaFiscalDestinatarioCEP, StringUtil.RTrim( context.localUtil.Format( A827NotaFiscalDestinatarioCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,259);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioCEP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioCEP_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioPais_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioPais_Internalname, "Destinatario Pais", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 264,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioPais_Internalname, A828NotaFiscalDestinatarioPais, StringUtil.RTrim( context.localUtil.Format( A828NotaFiscalDestinatarioPais, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,264);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioPais_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioPais_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalDestinatarioFone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalDestinatarioFone_Internalname, "Destinatario Fone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 269,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalDestinatarioFone_Internalname, A829NotaFiscalDestinatarioFone, StringUtil.RTrim( context.localUtil.Format( A829NotaFiscalDestinatarioFone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,269);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalDestinatarioFone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotaFiscalDestinatarioFone_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscal.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 276,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 278,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscal.htm");
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
            Z794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "Z794NotaFiscalId"));
            Z795NotaFiscalUF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z795NotaFiscalUF"), ",", "."), 18, MidpointRounding.ToEven));
            n795NotaFiscalUF = ((0==A795NotaFiscalUF) ? true : false);
            Z796NotaFiscalNatureza = cgiGet( "Z796NotaFiscalNatureza");
            n796NotaFiscalNatureza = (String.IsNullOrEmpty(StringUtil.RTrim( A796NotaFiscalNatureza)) ? true : false);
            Z797NotaFiscalMod = cgiGet( "Z797NotaFiscalMod");
            n797NotaFiscalMod = (String.IsNullOrEmpty(StringUtil.RTrim( A797NotaFiscalMod)) ? true : false);
            Z798NotaFiscalSerie = cgiGet( "Z798NotaFiscalSerie");
            n798NotaFiscalSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A798NotaFiscalSerie)) ? true : false);
            Z799NotaFiscalNumero = cgiGet( "Z799NotaFiscalNumero");
            n799NotaFiscalNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? true : false);
            Z800NotaFiscalDataEmissao = context.localUtil.CToT( cgiGet( "Z800NotaFiscalDataEmissao"), 0);
            n800NotaFiscalDataEmissao = ((DateTime.MinValue==A800NotaFiscalDataEmissao) ? true : false);
            Z801NotaFiscalDataSaida = context.localUtil.CToT( cgiGet( "Z801NotaFiscalDataSaida"), 0);
            n801NotaFiscalDataSaida = ((DateTime.MinValue==A801NotaFiscalDataSaida) ? true : false);
            Z802NotaFiscalTipo = cgiGet( "Z802NotaFiscalTipo");
            n802NotaFiscalTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A802NotaFiscalTipo)) ? true : false);
            Z803NotaFiscalMunicipio = cgiGet( "Z803NotaFiscalMunicipio");
            n803NotaFiscalMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A803NotaFiscalMunicipio)) ? true : false);
            Z804NotaFiscalTipoEmissao = cgiGet( "Z804NotaFiscalTipoEmissao");
            n804NotaFiscalTipoEmissao = (String.IsNullOrEmpty(StringUtil.RTrim( A804NotaFiscalTipoEmissao)) ? true : false);
            Z805NotaFiscalAmbiente = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z805NotaFiscalAmbiente"), ",", "."), 18, MidpointRounding.ToEven));
            n805NotaFiscalAmbiente = ((0==A805NotaFiscalAmbiente) ? true : false);
            Z806NotaFiscalFinalidades = cgiGet( "Z806NotaFiscalFinalidades");
            n806NotaFiscalFinalidades = (String.IsNullOrEmpty(StringUtil.RTrim( A806NotaFiscalFinalidades)) ? true : false);
            Z818NotaFiscaEmitentelDocumento = cgiGet( "Z818NotaFiscaEmitentelDocumento");
            n818NotaFiscaEmitentelDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A818NotaFiscaEmitentelDocumento)) ? true : false);
            Z808NotaFiscalEmitenteNome = cgiGet( "Z808NotaFiscalEmitenteNome");
            n808NotaFiscalEmitenteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A808NotaFiscalEmitenteNome)) ? true : false);
            Z809NotaFiscalEmitenteLogradouro = cgiGet( "Z809NotaFiscalEmitenteLogradouro");
            n809NotaFiscalEmitenteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A809NotaFiscalEmitenteLogradouro)) ? true : false);
            Z810NotaFiscalEmitenteLogNum = cgiGet( "Z810NotaFiscalEmitenteLogNum");
            n810NotaFiscalEmitenteLogNum = (String.IsNullOrEmpty(StringUtil.RTrim( A810NotaFiscalEmitenteLogNum)) ? true : false);
            Z811NotaFiscalEmitenteComplemento = cgiGet( "Z811NotaFiscalEmitenteComplemento");
            n811NotaFiscalEmitenteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A811NotaFiscalEmitenteComplemento)) ? true : false);
            Z812NotaFiscalEmitenteBairro = cgiGet( "Z812NotaFiscalEmitenteBairro");
            n812NotaFiscalEmitenteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A812NotaFiscalEmitenteBairro)) ? true : false);
            Z813NotaFiscalEmitenteMunicipio = cgiGet( "Z813NotaFiscalEmitenteMunicipio");
            n813NotaFiscalEmitenteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A813NotaFiscalEmitenteMunicipio)) ? true : false);
            Z814NotaFiscalEmitenteUF = cgiGet( "Z814NotaFiscalEmitenteUF");
            n814NotaFiscalEmitenteUF = (String.IsNullOrEmpty(StringUtil.RTrim( A814NotaFiscalEmitenteUF)) ? true : false);
            Z815NotaFiscalEmitenteCEP = cgiGet( "Z815NotaFiscalEmitenteCEP");
            n815NotaFiscalEmitenteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A815NotaFiscalEmitenteCEP)) ? true : false);
            Z816NotaFiscalEmitentePais = cgiGet( "Z816NotaFiscalEmitentePais");
            n816NotaFiscalEmitentePais = (String.IsNullOrEmpty(StringUtil.RTrim( A816NotaFiscalEmitentePais)) ? true : false);
            Z817NotaFiscalEmitenteTelefone = cgiGet( "Z817NotaFiscalEmitenteTelefone");
            n817NotaFiscalEmitenteTelefone = (String.IsNullOrEmpty(StringUtil.RTrim( A817NotaFiscalEmitenteTelefone)) ? true : false);
            Z819NotaFiscalEmitenteIE = cgiGet( "Z819NotaFiscalEmitenteIE");
            n819NotaFiscalEmitenteIE = (String.IsNullOrEmpty(StringUtil.RTrim( A819NotaFiscalEmitenteIE)) ? true : false);
            Z820NotaFiscalDestinatarioDocumento = cgiGet( "Z820NotaFiscalDestinatarioDocumento");
            n820NotaFiscalDestinatarioDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A820NotaFiscalDestinatarioDocumento)) ? true : false);
            Z852NotaFiscalDestinatarioNome = cgiGet( "Z852NotaFiscalDestinatarioNome");
            n852NotaFiscalDestinatarioNome = (String.IsNullOrEmpty(StringUtil.RTrim( A852NotaFiscalDestinatarioNome)) ? true : false);
            Z821NotaFiscalDestinatarioLogradouro = cgiGet( "Z821NotaFiscalDestinatarioLogradouro");
            n821NotaFiscalDestinatarioLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A821NotaFiscalDestinatarioLogradouro)) ? true : false);
            Z822NotaFiscalDestinatarioLogNum = cgiGet( "Z822NotaFiscalDestinatarioLogNum");
            n822NotaFiscalDestinatarioLogNum = (String.IsNullOrEmpty(StringUtil.RTrim( A822NotaFiscalDestinatarioLogNum)) ? true : false);
            Z823NotaFiscalDestinatarioComplemento = cgiGet( "Z823NotaFiscalDestinatarioComplemento");
            n823NotaFiscalDestinatarioComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A823NotaFiscalDestinatarioComplemento)) ? true : false);
            Z824NotaFiscalDestinatarioBairro = cgiGet( "Z824NotaFiscalDestinatarioBairro");
            n824NotaFiscalDestinatarioBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A824NotaFiscalDestinatarioBairro)) ? true : false);
            Z825NotaFiscalDestinatarioMunicipio = cgiGet( "Z825NotaFiscalDestinatarioMunicipio");
            n825NotaFiscalDestinatarioMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A825NotaFiscalDestinatarioMunicipio)) ? true : false);
            Z826NotaFiscalDestinatarioUF = cgiGet( "Z826NotaFiscalDestinatarioUF");
            n826NotaFiscalDestinatarioUF = (String.IsNullOrEmpty(StringUtil.RTrim( A826NotaFiscalDestinatarioUF)) ? true : false);
            Z827NotaFiscalDestinatarioCEP = cgiGet( "Z827NotaFiscalDestinatarioCEP");
            n827NotaFiscalDestinatarioCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A827NotaFiscalDestinatarioCEP)) ? true : false);
            Z828NotaFiscalDestinatarioPais = cgiGet( "Z828NotaFiscalDestinatarioPais");
            n828NotaFiscalDestinatarioPais = (String.IsNullOrEmpty(StringUtil.RTrim( A828NotaFiscalDestinatarioPais)) ? true : false);
            Z829NotaFiscalDestinatarioFone = cgiGet( "Z829NotaFiscalDestinatarioFone");
            n829NotaFiscalDestinatarioFone = (String.IsNullOrEmpty(StringUtil.RTrim( A829NotaFiscalDestinatarioFone)) ? true : false);
            Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n168ClienteId = ((0==A168ClienteId) ? true : false);
            Z889NotaFiscalDestinatarioClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z889NotaFiscalDestinatarioClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n889NotaFiscalDestinatarioClienteId = ((0==A889NotaFiscalDestinatarioClienteId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtNotaFiscalId_Internalname), "") == 0 )
            {
               A794NotaFiscalId = Guid.Empty;
               n794NotaFiscalId = true;
               AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            }
            else
            {
               try
               {
                  A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalId_Internalname));
                  n794NotaFiscalId = false;
                  AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NOTAFISCALID");
                  AnyError = 1;
                  GX_FocusControl = edtNotaFiscalId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
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
            cmbNotaFiscalUF.CurrentValue = cgiGet( cmbNotaFiscalUF_Internalname);
            n795NotaFiscalUF = ((StringUtil.StrCmp(cgiGet( cmbNotaFiscalUF_Internalname), "")==0) ? true : false);
            A795NotaFiscalUF = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbNotaFiscalUF_Internalname), "."), 18, MidpointRounding.ToEven));
            n795NotaFiscalUF = false;
            AssignAttri("", false, "A795NotaFiscalUF", (n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
            A874NotaFiscalValorTotal_F = context.localUtil.CToN( cgiGet( edtNotaFiscalValorTotal_F_Internalname), ",", ".");
            AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
            A875NotaFiscalValorTotalVendido_F = context.localUtil.CToN( cgiGet( edtNotaFiscalValorTotalVendido_F_Internalname), ",", ".");
            AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
            A876NotaFiscalSaldo_F = context.localUtil.CToN( cgiGet( edtNotaFiscalSaldo_F_Internalname), ",", ".");
            AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2));
            A877NotaFiscalQuantidadeDeItens_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotaFiscalQuantidadeDeItens_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
            A878NotaFiscalQuantidadeDeItensVendidos_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
            A879NotaFiscalQuantidadeResumo_F = cgiGet( edtNotaFiscalQuantidadeResumo_F_Internalname);
            AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
            A881NotaFiscalValorFormatado_F = cgiGet( edtNotaFiscalValorFormatado_F_Internalname);
            AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
            A882NotaFiscalValorVendidoFormatado_F = cgiGet( edtNotaFiscalValorVendidoFormatado_F_Internalname);
            AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
            A883NotaFiscalSaldoFormatado_F = cgiGet( edtNotaFiscalSaldoFormatado_F_Internalname);
            AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
            cmbNotaFiscalStatus.CurrentValue = cgiGet( cmbNotaFiscalStatus_Internalname);
            A880NotaFiscalStatus = cgiGet( cmbNotaFiscalStatus_Internalname);
            AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
            A796NotaFiscalNatureza = cgiGet( edtNotaFiscalNatureza_Internalname);
            n796NotaFiscalNatureza = false;
            AssignAttri("", false, "A796NotaFiscalNatureza", A796NotaFiscalNatureza);
            n796NotaFiscalNatureza = (String.IsNullOrEmpty(StringUtil.RTrim( A796NotaFiscalNatureza)) ? true : false);
            A797NotaFiscalMod = cgiGet( edtNotaFiscalMod_Internalname);
            n797NotaFiscalMod = false;
            AssignAttri("", false, "A797NotaFiscalMod", A797NotaFiscalMod);
            n797NotaFiscalMod = (String.IsNullOrEmpty(StringUtil.RTrim( A797NotaFiscalMod)) ? true : false);
            A798NotaFiscalSerie = cgiGet( edtNotaFiscalSerie_Internalname);
            n798NotaFiscalSerie = false;
            AssignAttri("", false, "A798NotaFiscalSerie", A798NotaFiscalSerie);
            n798NotaFiscalSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A798NotaFiscalSerie)) ? true : false);
            A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
            n799NotaFiscalNumero = false;
            AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
            n799NotaFiscalNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtNotaFiscalDataEmissao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Nota Fiscal Data Emissao"}), 1, "NOTAFISCALDATAEMISSAO");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalDataEmissao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
               n800NotaFiscalDataEmissao = false;
               AssignAttri("", false, "A800NotaFiscalDataEmissao", context.localUtil.TToC( A800NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A800NotaFiscalDataEmissao = context.localUtil.CToT( cgiGet( edtNotaFiscalDataEmissao_Internalname));
               n800NotaFiscalDataEmissao = false;
               AssignAttri("", false, "A800NotaFiscalDataEmissao", context.localUtil.TToC( A800NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            }
            n800NotaFiscalDataEmissao = ((DateTime.MinValue==A800NotaFiscalDataEmissao) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtNotaFiscalDataSaida_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Nota Fiscal Data Saida"}), 1, "NOTAFISCALDATASAIDA");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalDataSaida_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
               n801NotaFiscalDataSaida = false;
               AssignAttri("", false, "A801NotaFiscalDataSaida", context.localUtil.TToC( A801NotaFiscalDataSaida, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A801NotaFiscalDataSaida = context.localUtil.CToT( cgiGet( edtNotaFiscalDataSaida_Internalname));
               n801NotaFiscalDataSaida = false;
               AssignAttri("", false, "A801NotaFiscalDataSaida", context.localUtil.TToC( A801NotaFiscalDataSaida, 8, 5, 0, 3, "/", ":", " "));
            }
            n801NotaFiscalDataSaida = ((DateTime.MinValue==A801NotaFiscalDataSaida) ? true : false);
            cmbNotaFiscalTipo.CurrentValue = cgiGet( cmbNotaFiscalTipo_Internalname);
            A802NotaFiscalTipo = cgiGet( cmbNotaFiscalTipo_Internalname);
            n802NotaFiscalTipo = false;
            AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
            n802NotaFiscalTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A802NotaFiscalTipo)) ? true : false);
            A803NotaFiscalMunicipio = cgiGet( edtNotaFiscalMunicipio_Internalname);
            n803NotaFiscalMunicipio = false;
            AssignAttri("", false, "A803NotaFiscalMunicipio", A803NotaFiscalMunicipio);
            n803NotaFiscalMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A803NotaFiscalMunicipio)) ? true : false);
            cmbNotaFiscalTipoEmissao.CurrentValue = cgiGet( cmbNotaFiscalTipoEmissao_Internalname);
            A804NotaFiscalTipoEmissao = cgiGet( cmbNotaFiscalTipoEmissao_Internalname);
            n804NotaFiscalTipoEmissao = false;
            AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
            n804NotaFiscalTipoEmissao = (String.IsNullOrEmpty(StringUtil.RTrim( A804NotaFiscalTipoEmissao)) ? true : false);
            cmbNotaFiscalAmbiente.CurrentValue = cgiGet( cmbNotaFiscalAmbiente_Internalname);
            n805NotaFiscalAmbiente = ((StringUtil.StrCmp(cgiGet( cmbNotaFiscalAmbiente_Internalname), "")==0) ? true : false);
            A805NotaFiscalAmbiente = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbNotaFiscalAmbiente_Internalname), "."), 18, MidpointRounding.ToEven));
            n805NotaFiscalAmbiente = false;
            AssignAttri("", false, "A805NotaFiscalAmbiente", (n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
            cmbNotaFiscalFinalidades.CurrentValue = cgiGet( cmbNotaFiscalFinalidades_Internalname);
            A806NotaFiscalFinalidades = cgiGet( cmbNotaFiscalFinalidades_Internalname);
            n806NotaFiscalFinalidades = false;
            AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
            n806NotaFiscalFinalidades = (String.IsNullOrEmpty(StringUtil.RTrim( A806NotaFiscalFinalidades)) ? true : false);
            A818NotaFiscaEmitentelDocumento = cgiGet( edtNotaFiscaEmitentelDocumento_Internalname);
            n818NotaFiscaEmitentelDocumento = false;
            AssignAttri("", false, "A818NotaFiscaEmitentelDocumento", A818NotaFiscaEmitentelDocumento);
            n818NotaFiscaEmitentelDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A818NotaFiscaEmitentelDocumento)) ? true : false);
            A808NotaFiscalEmitenteNome = cgiGet( edtNotaFiscalEmitenteNome_Internalname);
            n808NotaFiscalEmitenteNome = false;
            AssignAttri("", false, "A808NotaFiscalEmitenteNome", A808NotaFiscalEmitenteNome);
            n808NotaFiscalEmitenteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A808NotaFiscalEmitenteNome)) ? true : false);
            A809NotaFiscalEmitenteLogradouro = cgiGet( edtNotaFiscalEmitenteLogradouro_Internalname);
            n809NotaFiscalEmitenteLogradouro = false;
            AssignAttri("", false, "A809NotaFiscalEmitenteLogradouro", A809NotaFiscalEmitenteLogradouro);
            n809NotaFiscalEmitenteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A809NotaFiscalEmitenteLogradouro)) ? true : false);
            A810NotaFiscalEmitenteLogNum = cgiGet( edtNotaFiscalEmitenteLogNum_Internalname);
            n810NotaFiscalEmitenteLogNum = false;
            AssignAttri("", false, "A810NotaFiscalEmitenteLogNum", A810NotaFiscalEmitenteLogNum);
            n810NotaFiscalEmitenteLogNum = (String.IsNullOrEmpty(StringUtil.RTrim( A810NotaFiscalEmitenteLogNum)) ? true : false);
            A811NotaFiscalEmitenteComplemento = cgiGet( edtNotaFiscalEmitenteComplemento_Internalname);
            n811NotaFiscalEmitenteComplemento = false;
            AssignAttri("", false, "A811NotaFiscalEmitenteComplemento", A811NotaFiscalEmitenteComplemento);
            n811NotaFiscalEmitenteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A811NotaFiscalEmitenteComplemento)) ? true : false);
            A812NotaFiscalEmitenteBairro = cgiGet( edtNotaFiscalEmitenteBairro_Internalname);
            n812NotaFiscalEmitenteBairro = false;
            AssignAttri("", false, "A812NotaFiscalEmitenteBairro", A812NotaFiscalEmitenteBairro);
            n812NotaFiscalEmitenteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A812NotaFiscalEmitenteBairro)) ? true : false);
            A813NotaFiscalEmitenteMunicipio = cgiGet( edtNotaFiscalEmitenteMunicipio_Internalname);
            n813NotaFiscalEmitenteMunicipio = false;
            AssignAttri("", false, "A813NotaFiscalEmitenteMunicipio", A813NotaFiscalEmitenteMunicipio);
            n813NotaFiscalEmitenteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A813NotaFiscalEmitenteMunicipio)) ? true : false);
            A814NotaFiscalEmitenteUF = cgiGet( edtNotaFiscalEmitenteUF_Internalname);
            n814NotaFiscalEmitenteUF = false;
            AssignAttri("", false, "A814NotaFiscalEmitenteUF", A814NotaFiscalEmitenteUF);
            n814NotaFiscalEmitenteUF = (String.IsNullOrEmpty(StringUtil.RTrim( A814NotaFiscalEmitenteUF)) ? true : false);
            A815NotaFiscalEmitenteCEP = cgiGet( edtNotaFiscalEmitenteCEP_Internalname);
            n815NotaFiscalEmitenteCEP = false;
            AssignAttri("", false, "A815NotaFiscalEmitenteCEP", A815NotaFiscalEmitenteCEP);
            n815NotaFiscalEmitenteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A815NotaFiscalEmitenteCEP)) ? true : false);
            A816NotaFiscalEmitentePais = cgiGet( edtNotaFiscalEmitentePais_Internalname);
            n816NotaFiscalEmitentePais = false;
            AssignAttri("", false, "A816NotaFiscalEmitentePais", A816NotaFiscalEmitentePais);
            n816NotaFiscalEmitentePais = (String.IsNullOrEmpty(StringUtil.RTrim( A816NotaFiscalEmitentePais)) ? true : false);
            A817NotaFiscalEmitenteTelefone = cgiGet( edtNotaFiscalEmitenteTelefone_Internalname);
            n817NotaFiscalEmitenteTelefone = false;
            AssignAttri("", false, "A817NotaFiscalEmitenteTelefone", A817NotaFiscalEmitenteTelefone);
            n817NotaFiscalEmitenteTelefone = (String.IsNullOrEmpty(StringUtil.RTrim( A817NotaFiscalEmitenteTelefone)) ? true : false);
            A819NotaFiscalEmitenteIE = cgiGet( edtNotaFiscalEmitenteIE_Internalname);
            n819NotaFiscalEmitenteIE = false;
            AssignAttri("", false, "A819NotaFiscalEmitenteIE", A819NotaFiscalEmitenteIE);
            n819NotaFiscalEmitenteIE = (String.IsNullOrEmpty(StringUtil.RTrim( A819NotaFiscalEmitenteIE)) ? true : false);
            n889NotaFiscalDestinatarioClienteId = ((StringUtil.StrCmp(cgiGet( edtNotaFiscalDestinatarioClienteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotaFiscalDestinatarioClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotaFiscalDestinatarioClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTAFISCALDESTINATARIOCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalDestinatarioClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A889NotaFiscalDestinatarioClienteId = 0;
               n889NotaFiscalDestinatarioClienteId = false;
               AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", (n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
            }
            else
            {
               A889NotaFiscalDestinatarioClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotaFiscalDestinatarioClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", (n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
            }
            A820NotaFiscalDestinatarioDocumento = cgiGet( edtNotaFiscalDestinatarioDocumento_Internalname);
            n820NotaFiscalDestinatarioDocumento = false;
            AssignAttri("", false, "A820NotaFiscalDestinatarioDocumento", A820NotaFiscalDestinatarioDocumento);
            n820NotaFiscalDestinatarioDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A820NotaFiscalDestinatarioDocumento)) ? true : false);
            A852NotaFiscalDestinatarioNome = cgiGet( edtNotaFiscalDestinatarioNome_Internalname);
            n852NotaFiscalDestinatarioNome = false;
            AssignAttri("", false, "A852NotaFiscalDestinatarioNome", A852NotaFiscalDestinatarioNome);
            n852NotaFiscalDestinatarioNome = (String.IsNullOrEmpty(StringUtil.RTrim( A852NotaFiscalDestinatarioNome)) ? true : false);
            A821NotaFiscalDestinatarioLogradouro = cgiGet( edtNotaFiscalDestinatarioLogradouro_Internalname);
            n821NotaFiscalDestinatarioLogradouro = false;
            AssignAttri("", false, "A821NotaFiscalDestinatarioLogradouro", A821NotaFiscalDestinatarioLogradouro);
            n821NotaFiscalDestinatarioLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A821NotaFiscalDestinatarioLogradouro)) ? true : false);
            A822NotaFiscalDestinatarioLogNum = cgiGet( edtNotaFiscalDestinatarioLogNum_Internalname);
            n822NotaFiscalDestinatarioLogNum = false;
            AssignAttri("", false, "A822NotaFiscalDestinatarioLogNum", A822NotaFiscalDestinatarioLogNum);
            n822NotaFiscalDestinatarioLogNum = (String.IsNullOrEmpty(StringUtil.RTrim( A822NotaFiscalDestinatarioLogNum)) ? true : false);
            A823NotaFiscalDestinatarioComplemento = cgiGet( edtNotaFiscalDestinatarioComplemento_Internalname);
            n823NotaFiscalDestinatarioComplemento = false;
            AssignAttri("", false, "A823NotaFiscalDestinatarioComplemento", A823NotaFiscalDestinatarioComplemento);
            n823NotaFiscalDestinatarioComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A823NotaFiscalDestinatarioComplemento)) ? true : false);
            A824NotaFiscalDestinatarioBairro = cgiGet( edtNotaFiscalDestinatarioBairro_Internalname);
            n824NotaFiscalDestinatarioBairro = false;
            AssignAttri("", false, "A824NotaFiscalDestinatarioBairro", A824NotaFiscalDestinatarioBairro);
            n824NotaFiscalDestinatarioBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A824NotaFiscalDestinatarioBairro)) ? true : false);
            A825NotaFiscalDestinatarioMunicipio = cgiGet( edtNotaFiscalDestinatarioMunicipio_Internalname);
            n825NotaFiscalDestinatarioMunicipio = false;
            AssignAttri("", false, "A825NotaFiscalDestinatarioMunicipio", A825NotaFiscalDestinatarioMunicipio);
            n825NotaFiscalDestinatarioMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A825NotaFiscalDestinatarioMunicipio)) ? true : false);
            A826NotaFiscalDestinatarioUF = cgiGet( edtNotaFiscalDestinatarioUF_Internalname);
            n826NotaFiscalDestinatarioUF = false;
            AssignAttri("", false, "A826NotaFiscalDestinatarioUF", A826NotaFiscalDestinatarioUF);
            n826NotaFiscalDestinatarioUF = (String.IsNullOrEmpty(StringUtil.RTrim( A826NotaFiscalDestinatarioUF)) ? true : false);
            A827NotaFiscalDestinatarioCEP = cgiGet( edtNotaFiscalDestinatarioCEP_Internalname);
            n827NotaFiscalDestinatarioCEP = false;
            AssignAttri("", false, "A827NotaFiscalDestinatarioCEP", A827NotaFiscalDestinatarioCEP);
            n827NotaFiscalDestinatarioCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A827NotaFiscalDestinatarioCEP)) ? true : false);
            A828NotaFiscalDestinatarioPais = cgiGet( edtNotaFiscalDestinatarioPais_Internalname);
            n828NotaFiscalDestinatarioPais = false;
            AssignAttri("", false, "A828NotaFiscalDestinatarioPais", A828NotaFiscalDestinatarioPais);
            n828NotaFiscalDestinatarioPais = (String.IsNullOrEmpty(StringUtil.RTrim( A828NotaFiscalDestinatarioPais)) ? true : false);
            A829NotaFiscalDestinatarioFone = cgiGet( edtNotaFiscalDestinatarioFone_Internalname);
            n829NotaFiscalDestinatarioFone = false;
            AssignAttri("", false, "A829NotaFiscalDestinatarioFone", A829NotaFiscalDestinatarioFone);
            n829NotaFiscalDestinatarioFone = (String.IsNullOrEmpty(StringUtil.RTrim( A829NotaFiscalDestinatarioFone)) ? true : false);
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
               A794NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
               n794NotaFiscalId = false;
               AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A794NotaFiscalId) && ( Gx_BScreen == 0 ) )
               {
                  A794NotaFiscalId = Guid.NewGuid( );
                  n794NotaFiscalId = false;
                  AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
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
               InitAll2N93( ) ;
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
         DisableAttributes2N93( ) ;
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

      protected void ResetCaption2N0( )
      {
      }

      protected void ZM2N93( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z795NotaFiscalUF = T002N3_A795NotaFiscalUF[0];
               Z796NotaFiscalNatureza = T002N3_A796NotaFiscalNatureza[0];
               Z797NotaFiscalMod = T002N3_A797NotaFiscalMod[0];
               Z798NotaFiscalSerie = T002N3_A798NotaFiscalSerie[0];
               Z799NotaFiscalNumero = T002N3_A799NotaFiscalNumero[0];
               Z800NotaFiscalDataEmissao = T002N3_A800NotaFiscalDataEmissao[0];
               Z801NotaFiscalDataSaida = T002N3_A801NotaFiscalDataSaida[0];
               Z802NotaFiscalTipo = T002N3_A802NotaFiscalTipo[0];
               Z803NotaFiscalMunicipio = T002N3_A803NotaFiscalMunicipio[0];
               Z804NotaFiscalTipoEmissao = T002N3_A804NotaFiscalTipoEmissao[0];
               Z805NotaFiscalAmbiente = T002N3_A805NotaFiscalAmbiente[0];
               Z806NotaFiscalFinalidades = T002N3_A806NotaFiscalFinalidades[0];
               Z818NotaFiscaEmitentelDocumento = T002N3_A818NotaFiscaEmitentelDocumento[0];
               Z808NotaFiscalEmitenteNome = T002N3_A808NotaFiscalEmitenteNome[0];
               Z809NotaFiscalEmitenteLogradouro = T002N3_A809NotaFiscalEmitenteLogradouro[0];
               Z810NotaFiscalEmitenteLogNum = T002N3_A810NotaFiscalEmitenteLogNum[0];
               Z811NotaFiscalEmitenteComplemento = T002N3_A811NotaFiscalEmitenteComplemento[0];
               Z812NotaFiscalEmitenteBairro = T002N3_A812NotaFiscalEmitenteBairro[0];
               Z813NotaFiscalEmitenteMunicipio = T002N3_A813NotaFiscalEmitenteMunicipio[0];
               Z814NotaFiscalEmitenteUF = T002N3_A814NotaFiscalEmitenteUF[0];
               Z815NotaFiscalEmitenteCEP = T002N3_A815NotaFiscalEmitenteCEP[0];
               Z816NotaFiscalEmitentePais = T002N3_A816NotaFiscalEmitentePais[0];
               Z817NotaFiscalEmitenteTelefone = T002N3_A817NotaFiscalEmitenteTelefone[0];
               Z819NotaFiscalEmitenteIE = T002N3_A819NotaFiscalEmitenteIE[0];
               Z820NotaFiscalDestinatarioDocumento = T002N3_A820NotaFiscalDestinatarioDocumento[0];
               Z852NotaFiscalDestinatarioNome = T002N3_A852NotaFiscalDestinatarioNome[0];
               Z821NotaFiscalDestinatarioLogradouro = T002N3_A821NotaFiscalDestinatarioLogradouro[0];
               Z822NotaFiscalDestinatarioLogNum = T002N3_A822NotaFiscalDestinatarioLogNum[0];
               Z823NotaFiscalDestinatarioComplemento = T002N3_A823NotaFiscalDestinatarioComplemento[0];
               Z824NotaFiscalDestinatarioBairro = T002N3_A824NotaFiscalDestinatarioBairro[0];
               Z825NotaFiscalDestinatarioMunicipio = T002N3_A825NotaFiscalDestinatarioMunicipio[0];
               Z826NotaFiscalDestinatarioUF = T002N3_A826NotaFiscalDestinatarioUF[0];
               Z827NotaFiscalDestinatarioCEP = T002N3_A827NotaFiscalDestinatarioCEP[0];
               Z828NotaFiscalDestinatarioPais = T002N3_A828NotaFiscalDestinatarioPais[0];
               Z829NotaFiscalDestinatarioFone = T002N3_A829NotaFiscalDestinatarioFone[0];
               Z168ClienteId = T002N3_A168ClienteId[0];
               Z889NotaFiscalDestinatarioClienteId = T002N3_A889NotaFiscalDestinatarioClienteId[0];
            }
            else
            {
               Z795NotaFiscalUF = A795NotaFiscalUF;
               Z796NotaFiscalNatureza = A796NotaFiscalNatureza;
               Z797NotaFiscalMod = A797NotaFiscalMod;
               Z798NotaFiscalSerie = A798NotaFiscalSerie;
               Z799NotaFiscalNumero = A799NotaFiscalNumero;
               Z800NotaFiscalDataEmissao = A800NotaFiscalDataEmissao;
               Z801NotaFiscalDataSaida = A801NotaFiscalDataSaida;
               Z802NotaFiscalTipo = A802NotaFiscalTipo;
               Z803NotaFiscalMunicipio = A803NotaFiscalMunicipio;
               Z804NotaFiscalTipoEmissao = A804NotaFiscalTipoEmissao;
               Z805NotaFiscalAmbiente = A805NotaFiscalAmbiente;
               Z806NotaFiscalFinalidades = A806NotaFiscalFinalidades;
               Z818NotaFiscaEmitentelDocumento = A818NotaFiscaEmitentelDocumento;
               Z808NotaFiscalEmitenteNome = A808NotaFiscalEmitenteNome;
               Z809NotaFiscalEmitenteLogradouro = A809NotaFiscalEmitenteLogradouro;
               Z810NotaFiscalEmitenteLogNum = A810NotaFiscalEmitenteLogNum;
               Z811NotaFiscalEmitenteComplemento = A811NotaFiscalEmitenteComplemento;
               Z812NotaFiscalEmitenteBairro = A812NotaFiscalEmitenteBairro;
               Z813NotaFiscalEmitenteMunicipio = A813NotaFiscalEmitenteMunicipio;
               Z814NotaFiscalEmitenteUF = A814NotaFiscalEmitenteUF;
               Z815NotaFiscalEmitenteCEP = A815NotaFiscalEmitenteCEP;
               Z816NotaFiscalEmitentePais = A816NotaFiscalEmitentePais;
               Z817NotaFiscalEmitenteTelefone = A817NotaFiscalEmitenteTelefone;
               Z819NotaFiscalEmitenteIE = A819NotaFiscalEmitenteIE;
               Z820NotaFiscalDestinatarioDocumento = A820NotaFiscalDestinatarioDocumento;
               Z852NotaFiscalDestinatarioNome = A852NotaFiscalDestinatarioNome;
               Z821NotaFiscalDestinatarioLogradouro = A821NotaFiscalDestinatarioLogradouro;
               Z822NotaFiscalDestinatarioLogNum = A822NotaFiscalDestinatarioLogNum;
               Z823NotaFiscalDestinatarioComplemento = A823NotaFiscalDestinatarioComplemento;
               Z824NotaFiscalDestinatarioBairro = A824NotaFiscalDestinatarioBairro;
               Z825NotaFiscalDestinatarioMunicipio = A825NotaFiscalDestinatarioMunicipio;
               Z826NotaFiscalDestinatarioUF = A826NotaFiscalDestinatarioUF;
               Z827NotaFiscalDestinatarioCEP = A827NotaFiscalDestinatarioCEP;
               Z828NotaFiscalDestinatarioPais = A828NotaFiscalDestinatarioPais;
               Z829NotaFiscalDestinatarioFone = A829NotaFiscalDestinatarioFone;
               Z168ClienteId = A168ClienteId;
               Z889NotaFiscalDestinatarioClienteId = A889NotaFiscalDestinatarioClienteId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z794NotaFiscalId = A794NotaFiscalId;
            Z795NotaFiscalUF = A795NotaFiscalUF;
            Z796NotaFiscalNatureza = A796NotaFiscalNatureza;
            Z797NotaFiscalMod = A797NotaFiscalMod;
            Z798NotaFiscalSerie = A798NotaFiscalSerie;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
            Z800NotaFiscalDataEmissao = A800NotaFiscalDataEmissao;
            Z801NotaFiscalDataSaida = A801NotaFiscalDataSaida;
            Z802NotaFiscalTipo = A802NotaFiscalTipo;
            Z803NotaFiscalMunicipio = A803NotaFiscalMunicipio;
            Z804NotaFiscalTipoEmissao = A804NotaFiscalTipoEmissao;
            Z805NotaFiscalAmbiente = A805NotaFiscalAmbiente;
            Z806NotaFiscalFinalidades = A806NotaFiscalFinalidades;
            Z818NotaFiscaEmitentelDocumento = A818NotaFiscaEmitentelDocumento;
            Z808NotaFiscalEmitenteNome = A808NotaFiscalEmitenteNome;
            Z809NotaFiscalEmitenteLogradouro = A809NotaFiscalEmitenteLogradouro;
            Z810NotaFiscalEmitenteLogNum = A810NotaFiscalEmitenteLogNum;
            Z811NotaFiscalEmitenteComplemento = A811NotaFiscalEmitenteComplemento;
            Z812NotaFiscalEmitenteBairro = A812NotaFiscalEmitenteBairro;
            Z813NotaFiscalEmitenteMunicipio = A813NotaFiscalEmitenteMunicipio;
            Z814NotaFiscalEmitenteUF = A814NotaFiscalEmitenteUF;
            Z815NotaFiscalEmitenteCEP = A815NotaFiscalEmitenteCEP;
            Z816NotaFiscalEmitentePais = A816NotaFiscalEmitentePais;
            Z817NotaFiscalEmitenteTelefone = A817NotaFiscalEmitenteTelefone;
            Z819NotaFiscalEmitenteIE = A819NotaFiscalEmitenteIE;
            Z820NotaFiscalDestinatarioDocumento = A820NotaFiscalDestinatarioDocumento;
            Z852NotaFiscalDestinatarioNome = A852NotaFiscalDestinatarioNome;
            Z821NotaFiscalDestinatarioLogradouro = A821NotaFiscalDestinatarioLogradouro;
            Z822NotaFiscalDestinatarioLogNum = A822NotaFiscalDestinatarioLogNum;
            Z823NotaFiscalDestinatarioComplemento = A823NotaFiscalDestinatarioComplemento;
            Z824NotaFiscalDestinatarioBairro = A824NotaFiscalDestinatarioBairro;
            Z825NotaFiscalDestinatarioMunicipio = A825NotaFiscalDestinatarioMunicipio;
            Z826NotaFiscalDestinatarioUF = A826NotaFiscalDestinatarioUF;
            Z827NotaFiscalDestinatarioCEP = A827NotaFiscalDestinatarioCEP;
            Z828NotaFiscalDestinatarioPais = A828NotaFiscalDestinatarioPais;
            Z829NotaFiscalDestinatarioFone = A829NotaFiscalDestinatarioFone;
            Z168ClienteId = A168ClienteId;
            Z889NotaFiscalDestinatarioClienteId = A889NotaFiscalDestinatarioClienteId;
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A794NotaFiscalId) && ( Gx_BScreen == 0 ) )
         {
            A794NotaFiscalId = Guid.NewGuid( );
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
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
            /* Using cursor T002N7 */
            pr_default.execute(4, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A874NotaFiscalValorTotal_F = T002N7_A874NotaFiscalValorTotal_F[0];
               AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
               A877NotaFiscalQuantidadeDeItens_F = T002N7_A877NotaFiscalQuantidadeDeItens_F[0];
               AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
            }
            else
            {
               A874NotaFiscalValorTotal_F = 0;
               AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
               A877NotaFiscalQuantidadeDeItens_F = 0;
               AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
            }
            pr_default.close(4);
            A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
            /* Using cursor T002N9 */
            pr_default.execute(5, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A875NotaFiscalValorTotalVendido_F = T002N9_A875NotaFiscalValorTotalVendido_F[0];
               AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
               A878NotaFiscalQuantidadeDeItensVendidos_F = T002N9_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
               AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
            }
            else
            {
               A875NotaFiscalValorTotalVendido_F = 0;
               AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
               A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
               AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
            }
            pr_default.close(5);
            A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
            AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2));
            A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
            A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
            A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
            AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
         }
      }

      protected void Load2N93( )
      {
         /* Using cursor T002N12 */
         pr_default.execute(6, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound93 = 1;
            A795NotaFiscalUF = T002N12_A795NotaFiscalUF[0];
            n795NotaFiscalUF = T002N12_n795NotaFiscalUF[0];
            AssignAttri("", false, "A795NotaFiscalUF", ((0==A795NotaFiscalUF)&&IsIns( )||n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
            A796NotaFiscalNatureza = T002N12_A796NotaFiscalNatureza[0];
            n796NotaFiscalNatureza = T002N12_n796NotaFiscalNatureza[0];
            AssignAttri("", false, "A796NotaFiscalNatureza", A796NotaFiscalNatureza);
            A797NotaFiscalMod = T002N12_A797NotaFiscalMod[0];
            n797NotaFiscalMod = T002N12_n797NotaFiscalMod[0];
            AssignAttri("", false, "A797NotaFiscalMod", A797NotaFiscalMod);
            A798NotaFiscalSerie = T002N12_A798NotaFiscalSerie[0];
            n798NotaFiscalSerie = T002N12_n798NotaFiscalSerie[0];
            AssignAttri("", false, "A798NotaFiscalSerie", A798NotaFiscalSerie);
            A799NotaFiscalNumero = T002N12_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T002N12_n799NotaFiscalNumero[0];
            AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
            A800NotaFiscalDataEmissao = T002N12_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = T002N12_n800NotaFiscalDataEmissao[0];
            AssignAttri("", false, "A800NotaFiscalDataEmissao", context.localUtil.TToC( A800NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            A801NotaFiscalDataSaida = T002N12_A801NotaFiscalDataSaida[0];
            n801NotaFiscalDataSaida = T002N12_n801NotaFiscalDataSaida[0];
            AssignAttri("", false, "A801NotaFiscalDataSaida", context.localUtil.TToC( A801NotaFiscalDataSaida, 8, 5, 0, 3, "/", ":", " "));
            A802NotaFiscalTipo = T002N12_A802NotaFiscalTipo[0];
            n802NotaFiscalTipo = T002N12_n802NotaFiscalTipo[0];
            AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
            A803NotaFiscalMunicipio = T002N12_A803NotaFiscalMunicipio[0];
            n803NotaFiscalMunicipio = T002N12_n803NotaFiscalMunicipio[0];
            AssignAttri("", false, "A803NotaFiscalMunicipio", A803NotaFiscalMunicipio);
            A804NotaFiscalTipoEmissao = T002N12_A804NotaFiscalTipoEmissao[0];
            n804NotaFiscalTipoEmissao = T002N12_n804NotaFiscalTipoEmissao[0];
            AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
            A805NotaFiscalAmbiente = T002N12_A805NotaFiscalAmbiente[0];
            n805NotaFiscalAmbiente = T002N12_n805NotaFiscalAmbiente[0];
            AssignAttri("", false, "A805NotaFiscalAmbiente", ((0==A805NotaFiscalAmbiente)&&IsIns( )||n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
            A806NotaFiscalFinalidades = T002N12_A806NotaFiscalFinalidades[0];
            n806NotaFiscalFinalidades = T002N12_n806NotaFiscalFinalidades[0];
            AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
            A818NotaFiscaEmitentelDocumento = T002N12_A818NotaFiscaEmitentelDocumento[0];
            n818NotaFiscaEmitentelDocumento = T002N12_n818NotaFiscaEmitentelDocumento[0];
            AssignAttri("", false, "A818NotaFiscaEmitentelDocumento", A818NotaFiscaEmitentelDocumento);
            A808NotaFiscalEmitenteNome = T002N12_A808NotaFiscalEmitenteNome[0];
            n808NotaFiscalEmitenteNome = T002N12_n808NotaFiscalEmitenteNome[0];
            AssignAttri("", false, "A808NotaFiscalEmitenteNome", A808NotaFiscalEmitenteNome);
            A809NotaFiscalEmitenteLogradouro = T002N12_A809NotaFiscalEmitenteLogradouro[0];
            n809NotaFiscalEmitenteLogradouro = T002N12_n809NotaFiscalEmitenteLogradouro[0];
            AssignAttri("", false, "A809NotaFiscalEmitenteLogradouro", A809NotaFiscalEmitenteLogradouro);
            A810NotaFiscalEmitenteLogNum = T002N12_A810NotaFiscalEmitenteLogNum[0];
            n810NotaFiscalEmitenteLogNum = T002N12_n810NotaFiscalEmitenteLogNum[0];
            AssignAttri("", false, "A810NotaFiscalEmitenteLogNum", A810NotaFiscalEmitenteLogNum);
            A811NotaFiscalEmitenteComplemento = T002N12_A811NotaFiscalEmitenteComplemento[0];
            n811NotaFiscalEmitenteComplemento = T002N12_n811NotaFiscalEmitenteComplemento[0];
            AssignAttri("", false, "A811NotaFiscalEmitenteComplemento", A811NotaFiscalEmitenteComplemento);
            A812NotaFiscalEmitenteBairro = T002N12_A812NotaFiscalEmitenteBairro[0];
            n812NotaFiscalEmitenteBairro = T002N12_n812NotaFiscalEmitenteBairro[0];
            AssignAttri("", false, "A812NotaFiscalEmitenteBairro", A812NotaFiscalEmitenteBairro);
            A813NotaFiscalEmitenteMunicipio = T002N12_A813NotaFiscalEmitenteMunicipio[0];
            n813NotaFiscalEmitenteMunicipio = T002N12_n813NotaFiscalEmitenteMunicipio[0];
            AssignAttri("", false, "A813NotaFiscalEmitenteMunicipio", A813NotaFiscalEmitenteMunicipio);
            A814NotaFiscalEmitenteUF = T002N12_A814NotaFiscalEmitenteUF[0];
            n814NotaFiscalEmitenteUF = T002N12_n814NotaFiscalEmitenteUF[0];
            AssignAttri("", false, "A814NotaFiscalEmitenteUF", A814NotaFiscalEmitenteUF);
            A815NotaFiscalEmitenteCEP = T002N12_A815NotaFiscalEmitenteCEP[0];
            n815NotaFiscalEmitenteCEP = T002N12_n815NotaFiscalEmitenteCEP[0];
            AssignAttri("", false, "A815NotaFiscalEmitenteCEP", A815NotaFiscalEmitenteCEP);
            A816NotaFiscalEmitentePais = T002N12_A816NotaFiscalEmitentePais[0];
            n816NotaFiscalEmitentePais = T002N12_n816NotaFiscalEmitentePais[0];
            AssignAttri("", false, "A816NotaFiscalEmitentePais", A816NotaFiscalEmitentePais);
            A817NotaFiscalEmitenteTelefone = T002N12_A817NotaFiscalEmitenteTelefone[0];
            n817NotaFiscalEmitenteTelefone = T002N12_n817NotaFiscalEmitenteTelefone[0];
            AssignAttri("", false, "A817NotaFiscalEmitenteTelefone", A817NotaFiscalEmitenteTelefone);
            A819NotaFiscalEmitenteIE = T002N12_A819NotaFiscalEmitenteIE[0];
            n819NotaFiscalEmitenteIE = T002N12_n819NotaFiscalEmitenteIE[0];
            AssignAttri("", false, "A819NotaFiscalEmitenteIE", A819NotaFiscalEmitenteIE);
            A820NotaFiscalDestinatarioDocumento = T002N12_A820NotaFiscalDestinatarioDocumento[0];
            n820NotaFiscalDestinatarioDocumento = T002N12_n820NotaFiscalDestinatarioDocumento[0];
            AssignAttri("", false, "A820NotaFiscalDestinatarioDocumento", A820NotaFiscalDestinatarioDocumento);
            A852NotaFiscalDestinatarioNome = T002N12_A852NotaFiscalDestinatarioNome[0];
            n852NotaFiscalDestinatarioNome = T002N12_n852NotaFiscalDestinatarioNome[0];
            AssignAttri("", false, "A852NotaFiscalDestinatarioNome", A852NotaFiscalDestinatarioNome);
            A821NotaFiscalDestinatarioLogradouro = T002N12_A821NotaFiscalDestinatarioLogradouro[0];
            n821NotaFiscalDestinatarioLogradouro = T002N12_n821NotaFiscalDestinatarioLogradouro[0];
            AssignAttri("", false, "A821NotaFiscalDestinatarioLogradouro", A821NotaFiscalDestinatarioLogradouro);
            A822NotaFiscalDestinatarioLogNum = T002N12_A822NotaFiscalDestinatarioLogNum[0];
            n822NotaFiscalDestinatarioLogNum = T002N12_n822NotaFiscalDestinatarioLogNum[0];
            AssignAttri("", false, "A822NotaFiscalDestinatarioLogNum", A822NotaFiscalDestinatarioLogNum);
            A823NotaFiscalDestinatarioComplemento = T002N12_A823NotaFiscalDestinatarioComplemento[0];
            n823NotaFiscalDestinatarioComplemento = T002N12_n823NotaFiscalDestinatarioComplemento[0];
            AssignAttri("", false, "A823NotaFiscalDestinatarioComplemento", A823NotaFiscalDestinatarioComplemento);
            A824NotaFiscalDestinatarioBairro = T002N12_A824NotaFiscalDestinatarioBairro[0];
            n824NotaFiscalDestinatarioBairro = T002N12_n824NotaFiscalDestinatarioBairro[0];
            AssignAttri("", false, "A824NotaFiscalDestinatarioBairro", A824NotaFiscalDestinatarioBairro);
            A825NotaFiscalDestinatarioMunicipio = T002N12_A825NotaFiscalDestinatarioMunicipio[0];
            n825NotaFiscalDestinatarioMunicipio = T002N12_n825NotaFiscalDestinatarioMunicipio[0];
            AssignAttri("", false, "A825NotaFiscalDestinatarioMunicipio", A825NotaFiscalDestinatarioMunicipio);
            A826NotaFiscalDestinatarioUF = T002N12_A826NotaFiscalDestinatarioUF[0];
            n826NotaFiscalDestinatarioUF = T002N12_n826NotaFiscalDestinatarioUF[0];
            AssignAttri("", false, "A826NotaFiscalDestinatarioUF", A826NotaFiscalDestinatarioUF);
            A827NotaFiscalDestinatarioCEP = T002N12_A827NotaFiscalDestinatarioCEP[0];
            n827NotaFiscalDestinatarioCEP = T002N12_n827NotaFiscalDestinatarioCEP[0];
            AssignAttri("", false, "A827NotaFiscalDestinatarioCEP", A827NotaFiscalDestinatarioCEP);
            A828NotaFiscalDestinatarioPais = T002N12_A828NotaFiscalDestinatarioPais[0];
            n828NotaFiscalDestinatarioPais = T002N12_n828NotaFiscalDestinatarioPais[0];
            AssignAttri("", false, "A828NotaFiscalDestinatarioPais", A828NotaFiscalDestinatarioPais);
            A829NotaFiscalDestinatarioFone = T002N12_A829NotaFiscalDestinatarioFone[0];
            n829NotaFiscalDestinatarioFone = T002N12_n829NotaFiscalDestinatarioFone[0];
            AssignAttri("", false, "A829NotaFiscalDestinatarioFone", A829NotaFiscalDestinatarioFone);
            A168ClienteId = T002N12_A168ClienteId[0];
            n168ClienteId = T002N12_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A889NotaFiscalDestinatarioClienteId = T002N12_A889NotaFiscalDestinatarioClienteId[0];
            n889NotaFiscalDestinatarioClienteId = T002N12_n889NotaFiscalDestinatarioClienteId[0];
            AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
            A874NotaFiscalValorTotal_F = T002N12_A874NotaFiscalValorTotal_F[0];
            AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
            A875NotaFiscalValorTotalVendido_F = T002N12_A875NotaFiscalValorTotalVendido_F[0];
            AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
            A877NotaFiscalQuantidadeDeItens_F = T002N12_A877NotaFiscalQuantidadeDeItens_F[0];
            AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
            A878NotaFiscalQuantidadeDeItensVendidos_F = T002N12_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
            ZM2N93( -14) ;
         }
         pr_default.close(6);
         OnLoadActions2N93( ) ;
      }

      protected void OnLoadActions2N93( )
      {
         A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
         A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
         AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2));
         A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
         A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
         A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
         AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
         A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
      }

      protected void CheckExtendedTable2N93( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T002N7 */
         pr_default.execute(4, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A874NotaFiscalValorTotal_F = T002N7_A874NotaFiscalValorTotal_F[0];
            AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
            A877NotaFiscalQuantidadeDeItens_F = T002N7_A877NotaFiscalQuantidadeDeItens_F[0];
            AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
         }
         else
         {
            A874NotaFiscalValorTotal_F = 0;
            AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
            A877NotaFiscalQuantidadeDeItens_F = 0;
            AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
         }
         pr_default.close(4);
         A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
         /* Using cursor T002N9 */
         pr_default.execute(5, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A875NotaFiscalValorTotalVendido_F = T002N9_A875NotaFiscalValorTotalVendido_F[0];
            AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
            A878NotaFiscalQuantidadeDeItensVendidos_F = T002N9_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
         }
         else
         {
            A875NotaFiscalValorTotalVendido_F = 0;
            AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
            A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
            AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
         }
         pr_default.close(5);
         A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
         AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2));
         A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
         A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
         A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
         AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
         A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
         /* Using cursor T002N4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( ( A795NotaFiscalUF == 11 ) || ( A795NotaFiscalUF == 12 ) || ( A795NotaFiscalUF == 13 ) || ( A795NotaFiscalUF == 14 ) || ( A795NotaFiscalUF == 15 ) || ( A795NotaFiscalUF == 16 ) || ( A795NotaFiscalUF == 17 ) || ( A795NotaFiscalUF == 21 ) || ( A795NotaFiscalUF == 22 ) || ( A795NotaFiscalUF == 23 ) || ( A795NotaFiscalUF == 24 ) || ( A795NotaFiscalUF == 25 ) || ( A795NotaFiscalUF == 26 ) || ( A795NotaFiscalUF == 27 ) || ( A795NotaFiscalUF == 28 ) || ( A795NotaFiscalUF == 29 ) || ( A795NotaFiscalUF == 31 ) || ( A795NotaFiscalUF == 32 ) || ( A795NotaFiscalUF == 33 ) || ( A795NotaFiscalUF == 35 ) || ( A795NotaFiscalUF == 41 ) || ( A795NotaFiscalUF == 42 ) || ( A795NotaFiscalUF == 43 ) || ( A795NotaFiscalUF == 50 ) || ( A795NotaFiscalUF == 51 ) || ( A795NotaFiscalUF == 52 ) || ( A795NotaFiscalUF == 53 ) || (0==A795NotaFiscalUF) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal UF fora do intervalo", "OutOfRange", 1, "NOTAFISCALUF");
            AnyError = 1;
            GX_FocusControl = cmbNotaFiscalUF_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A802NotaFiscalTipo, "0") == 0 ) || ( StringUtil.StrCmp(A802NotaFiscalTipo, "1") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A802NotaFiscalTipo)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Tipo fora do intervalo", "OutOfRange", 1, "NOTAFISCALTIPO");
            AnyError = 1;
            GX_FocusControl = cmbNotaFiscalTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A804NotaFiscalTipoEmissao, "1") == 0 ) || ( StringUtil.StrCmp(A804NotaFiscalTipoEmissao, "2") == 0 ) || ( StringUtil.StrCmp(A804NotaFiscalTipoEmissao, "9") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A804NotaFiscalTipoEmissao)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Tipo Emissao fora do intervalo", "OutOfRange", 1, "NOTAFISCALTIPOEMISSAO");
            AnyError = 1;
            GX_FocusControl = cmbNotaFiscalTipoEmissao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A805NotaFiscalAmbiente == 1 ) || ( A805NotaFiscalAmbiente == 2 ) || (0==A805NotaFiscalAmbiente) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Ambiente fora do intervalo", "OutOfRange", 1, "NOTAFISCALAMBIENTE");
            AnyError = 1;
            GX_FocusControl = cmbNotaFiscalAmbiente_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "1") == 0 ) || ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "2") == 0 ) || ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "3") == 0 ) || ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "4") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A806NotaFiscalFinalidades)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Finalidades fora do intervalo", "OutOfRange", 1, "NOTAFISCALFINALIDADES");
            AnyError = 1;
            GX_FocusControl = cmbNotaFiscalFinalidades_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002N5 */
         pr_default.execute(3, new Object[] {n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A889NotaFiscalDestinatarioClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Nota Destinatario Cliente'.", "ForeignKeyNotFound", 1, "NOTAFISCALDESTINATARIOCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalDestinatarioClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2N93( )
      {
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( Guid A794NotaFiscalId )
      {
         /* Using cursor T002N14 */
         pr_default.execute(7, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A874NotaFiscalValorTotal_F = T002N14_A874NotaFiscalValorTotal_F[0];
            AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
            A877NotaFiscalQuantidadeDeItens_F = T002N14_A877NotaFiscalQuantidadeDeItens_F[0];
            AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
         }
         else
         {
            A874NotaFiscalValorTotal_F = 0;
            AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
            A877NotaFiscalQuantidadeDeItens_F = 0;
            AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A874NotaFiscalValorTotal_F, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_18( Guid A794NotaFiscalId )
      {
         /* Using cursor T002N16 */
         pr_default.execute(8, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A875NotaFiscalValorTotalVendido_F = T002N16_A875NotaFiscalValorTotalVendido_F[0];
            AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
            A878NotaFiscalQuantidadeDeItensVendidos_F = T002N16_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
         }
         else
         {
            A875NotaFiscalValorTotalVendido_F = 0;
            AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
            A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
            AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A875NotaFiscalValorTotalVendido_F, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_15( int A168ClienteId )
      {
         /* Using cursor T002N17 */
         pr_default.execute(9, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(9) == 101) )
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
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_16( int A889NotaFiscalDestinatarioClienteId )
      {
         /* Using cursor T002N18 */
         pr_default.execute(10, new Object[] {n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A889NotaFiscalDestinatarioClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Nota Destinatario Cliente'.", "ForeignKeyNotFound", 1, "NOTAFISCALDESTINATARIOCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalDestinatarioClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey2N93( )
      {
         /* Using cursor T002N19 */
         pr_default.execute(11, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound93 = 1;
         }
         else
         {
            RcdFound93 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002N3 */
         pr_default.execute(1, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2N93( 14) ;
            RcdFound93 = 1;
            A794NotaFiscalId = T002N3_A794NotaFiscalId[0];
            n794NotaFiscalId = T002N3_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            A795NotaFiscalUF = T002N3_A795NotaFiscalUF[0];
            n795NotaFiscalUF = T002N3_n795NotaFiscalUF[0];
            AssignAttri("", false, "A795NotaFiscalUF", ((0==A795NotaFiscalUF)&&IsIns( )||n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
            A796NotaFiscalNatureza = T002N3_A796NotaFiscalNatureza[0];
            n796NotaFiscalNatureza = T002N3_n796NotaFiscalNatureza[0];
            AssignAttri("", false, "A796NotaFiscalNatureza", A796NotaFiscalNatureza);
            A797NotaFiscalMod = T002N3_A797NotaFiscalMod[0];
            n797NotaFiscalMod = T002N3_n797NotaFiscalMod[0];
            AssignAttri("", false, "A797NotaFiscalMod", A797NotaFiscalMod);
            A798NotaFiscalSerie = T002N3_A798NotaFiscalSerie[0];
            n798NotaFiscalSerie = T002N3_n798NotaFiscalSerie[0];
            AssignAttri("", false, "A798NotaFiscalSerie", A798NotaFiscalSerie);
            A799NotaFiscalNumero = T002N3_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T002N3_n799NotaFiscalNumero[0];
            AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
            A800NotaFiscalDataEmissao = T002N3_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = T002N3_n800NotaFiscalDataEmissao[0];
            AssignAttri("", false, "A800NotaFiscalDataEmissao", context.localUtil.TToC( A800NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            A801NotaFiscalDataSaida = T002N3_A801NotaFiscalDataSaida[0];
            n801NotaFiscalDataSaida = T002N3_n801NotaFiscalDataSaida[0];
            AssignAttri("", false, "A801NotaFiscalDataSaida", context.localUtil.TToC( A801NotaFiscalDataSaida, 8, 5, 0, 3, "/", ":", " "));
            A802NotaFiscalTipo = T002N3_A802NotaFiscalTipo[0];
            n802NotaFiscalTipo = T002N3_n802NotaFiscalTipo[0];
            AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
            A803NotaFiscalMunicipio = T002N3_A803NotaFiscalMunicipio[0];
            n803NotaFiscalMunicipio = T002N3_n803NotaFiscalMunicipio[0];
            AssignAttri("", false, "A803NotaFiscalMunicipio", A803NotaFiscalMunicipio);
            A804NotaFiscalTipoEmissao = T002N3_A804NotaFiscalTipoEmissao[0];
            n804NotaFiscalTipoEmissao = T002N3_n804NotaFiscalTipoEmissao[0];
            AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
            A805NotaFiscalAmbiente = T002N3_A805NotaFiscalAmbiente[0];
            n805NotaFiscalAmbiente = T002N3_n805NotaFiscalAmbiente[0];
            AssignAttri("", false, "A805NotaFiscalAmbiente", ((0==A805NotaFiscalAmbiente)&&IsIns( )||n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
            A806NotaFiscalFinalidades = T002N3_A806NotaFiscalFinalidades[0];
            n806NotaFiscalFinalidades = T002N3_n806NotaFiscalFinalidades[0];
            AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
            A818NotaFiscaEmitentelDocumento = T002N3_A818NotaFiscaEmitentelDocumento[0];
            n818NotaFiscaEmitentelDocumento = T002N3_n818NotaFiscaEmitentelDocumento[0];
            AssignAttri("", false, "A818NotaFiscaEmitentelDocumento", A818NotaFiscaEmitentelDocumento);
            A808NotaFiscalEmitenteNome = T002N3_A808NotaFiscalEmitenteNome[0];
            n808NotaFiscalEmitenteNome = T002N3_n808NotaFiscalEmitenteNome[0];
            AssignAttri("", false, "A808NotaFiscalEmitenteNome", A808NotaFiscalEmitenteNome);
            A809NotaFiscalEmitenteLogradouro = T002N3_A809NotaFiscalEmitenteLogradouro[0];
            n809NotaFiscalEmitenteLogradouro = T002N3_n809NotaFiscalEmitenteLogradouro[0];
            AssignAttri("", false, "A809NotaFiscalEmitenteLogradouro", A809NotaFiscalEmitenteLogradouro);
            A810NotaFiscalEmitenteLogNum = T002N3_A810NotaFiscalEmitenteLogNum[0];
            n810NotaFiscalEmitenteLogNum = T002N3_n810NotaFiscalEmitenteLogNum[0];
            AssignAttri("", false, "A810NotaFiscalEmitenteLogNum", A810NotaFiscalEmitenteLogNum);
            A811NotaFiscalEmitenteComplemento = T002N3_A811NotaFiscalEmitenteComplemento[0];
            n811NotaFiscalEmitenteComplemento = T002N3_n811NotaFiscalEmitenteComplemento[0];
            AssignAttri("", false, "A811NotaFiscalEmitenteComplemento", A811NotaFiscalEmitenteComplemento);
            A812NotaFiscalEmitenteBairro = T002N3_A812NotaFiscalEmitenteBairro[0];
            n812NotaFiscalEmitenteBairro = T002N3_n812NotaFiscalEmitenteBairro[0];
            AssignAttri("", false, "A812NotaFiscalEmitenteBairro", A812NotaFiscalEmitenteBairro);
            A813NotaFiscalEmitenteMunicipio = T002N3_A813NotaFiscalEmitenteMunicipio[0];
            n813NotaFiscalEmitenteMunicipio = T002N3_n813NotaFiscalEmitenteMunicipio[0];
            AssignAttri("", false, "A813NotaFiscalEmitenteMunicipio", A813NotaFiscalEmitenteMunicipio);
            A814NotaFiscalEmitenteUF = T002N3_A814NotaFiscalEmitenteUF[0];
            n814NotaFiscalEmitenteUF = T002N3_n814NotaFiscalEmitenteUF[0];
            AssignAttri("", false, "A814NotaFiscalEmitenteUF", A814NotaFiscalEmitenteUF);
            A815NotaFiscalEmitenteCEP = T002N3_A815NotaFiscalEmitenteCEP[0];
            n815NotaFiscalEmitenteCEP = T002N3_n815NotaFiscalEmitenteCEP[0];
            AssignAttri("", false, "A815NotaFiscalEmitenteCEP", A815NotaFiscalEmitenteCEP);
            A816NotaFiscalEmitentePais = T002N3_A816NotaFiscalEmitentePais[0];
            n816NotaFiscalEmitentePais = T002N3_n816NotaFiscalEmitentePais[0];
            AssignAttri("", false, "A816NotaFiscalEmitentePais", A816NotaFiscalEmitentePais);
            A817NotaFiscalEmitenteTelefone = T002N3_A817NotaFiscalEmitenteTelefone[0];
            n817NotaFiscalEmitenteTelefone = T002N3_n817NotaFiscalEmitenteTelefone[0];
            AssignAttri("", false, "A817NotaFiscalEmitenteTelefone", A817NotaFiscalEmitenteTelefone);
            A819NotaFiscalEmitenteIE = T002N3_A819NotaFiscalEmitenteIE[0];
            n819NotaFiscalEmitenteIE = T002N3_n819NotaFiscalEmitenteIE[0];
            AssignAttri("", false, "A819NotaFiscalEmitenteIE", A819NotaFiscalEmitenteIE);
            A820NotaFiscalDestinatarioDocumento = T002N3_A820NotaFiscalDestinatarioDocumento[0];
            n820NotaFiscalDestinatarioDocumento = T002N3_n820NotaFiscalDestinatarioDocumento[0];
            AssignAttri("", false, "A820NotaFiscalDestinatarioDocumento", A820NotaFiscalDestinatarioDocumento);
            A852NotaFiscalDestinatarioNome = T002N3_A852NotaFiscalDestinatarioNome[0];
            n852NotaFiscalDestinatarioNome = T002N3_n852NotaFiscalDestinatarioNome[0];
            AssignAttri("", false, "A852NotaFiscalDestinatarioNome", A852NotaFiscalDestinatarioNome);
            A821NotaFiscalDestinatarioLogradouro = T002N3_A821NotaFiscalDestinatarioLogradouro[0];
            n821NotaFiscalDestinatarioLogradouro = T002N3_n821NotaFiscalDestinatarioLogradouro[0];
            AssignAttri("", false, "A821NotaFiscalDestinatarioLogradouro", A821NotaFiscalDestinatarioLogradouro);
            A822NotaFiscalDestinatarioLogNum = T002N3_A822NotaFiscalDestinatarioLogNum[0];
            n822NotaFiscalDestinatarioLogNum = T002N3_n822NotaFiscalDestinatarioLogNum[0];
            AssignAttri("", false, "A822NotaFiscalDestinatarioLogNum", A822NotaFiscalDestinatarioLogNum);
            A823NotaFiscalDestinatarioComplemento = T002N3_A823NotaFiscalDestinatarioComplemento[0];
            n823NotaFiscalDestinatarioComplemento = T002N3_n823NotaFiscalDestinatarioComplemento[0];
            AssignAttri("", false, "A823NotaFiscalDestinatarioComplemento", A823NotaFiscalDestinatarioComplemento);
            A824NotaFiscalDestinatarioBairro = T002N3_A824NotaFiscalDestinatarioBairro[0];
            n824NotaFiscalDestinatarioBairro = T002N3_n824NotaFiscalDestinatarioBairro[0];
            AssignAttri("", false, "A824NotaFiscalDestinatarioBairro", A824NotaFiscalDestinatarioBairro);
            A825NotaFiscalDestinatarioMunicipio = T002N3_A825NotaFiscalDestinatarioMunicipio[0];
            n825NotaFiscalDestinatarioMunicipio = T002N3_n825NotaFiscalDestinatarioMunicipio[0];
            AssignAttri("", false, "A825NotaFiscalDestinatarioMunicipio", A825NotaFiscalDestinatarioMunicipio);
            A826NotaFiscalDestinatarioUF = T002N3_A826NotaFiscalDestinatarioUF[0];
            n826NotaFiscalDestinatarioUF = T002N3_n826NotaFiscalDestinatarioUF[0];
            AssignAttri("", false, "A826NotaFiscalDestinatarioUF", A826NotaFiscalDestinatarioUF);
            A827NotaFiscalDestinatarioCEP = T002N3_A827NotaFiscalDestinatarioCEP[0];
            n827NotaFiscalDestinatarioCEP = T002N3_n827NotaFiscalDestinatarioCEP[0];
            AssignAttri("", false, "A827NotaFiscalDestinatarioCEP", A827NotaFiscalDestinatarioCEP);
            A828NotaFiscalDestinatarioPais = T002N3_A828NotaFiscalDestinatarioPais[0];
            n828NotaFiscalDestinatarioPais = T002N3_n828NotaFiscalDestinatarioPais[0];
            AssignAttri("", false, "A828NotaFiscalDestinatarioPais", A828NotaFiscalDestinatarioPais);
            A829NotaFiscalDestinatarioFone = T002N3_A829NotaFiscalDestinatarioFone[0];
            n829NotaFiscalDestinatarioFone = T002N3_n829NotaFiscalDestinatarioFone[0];
            AssignAttri("", false, "A829NotaFiscalDestinatarioFone", A829NotaFiscalDestinatarioFone);
            A168ClienteId = T002N3_A168ClienteId[0];
            n168ClienteId = T002N3_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A889NotaFiscalDestinatarioClienteId = T002N3_A889NotaFiscalDestinatarioClienteId[0];
            n889NotaFiscalDestinatarioClienteId = T002N3_n889NotaFiscalDestinatarioClienteId[0];
            AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
            Z794NotaFiscalId = A794NotaFiscalId;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2N93( ) ;
            if ( AnyError == 1 )
            {
               RcdFound93 = 0;
               InitializeNonKey2N93( ) ;
            }
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound93 = 0;
            InitializeNonKey2N93( ) ;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2N93( ) ;
         if ( RcdFound93 == 0 )
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
         RcdFound93 = 0;
         /* Using cursor T002N20 */
         pr_default.execute(12, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T002N20_A794NotaFiscalId[0], A794NotaFiscalId, 0) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T002N20_A794NotaFiscalId[0], A794NotaFiscalId, 0) > 0 ) ) )
            {
               A794NotaFiscalId = T002N20_A794NotaFiscalId[0];
               n794NotaFiscalId = T002N20_n794NotaFiscalId[0];
               AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
               RcdFound93 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound93 = 0;
         /* Using cursor T002N21 */
         pr_default.execute(13, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T002N21_A794NotaFiscalId[0], A794NotaFiscalId, 0) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T002N21_A794NotaFiscalId[0], A794NotaFiscalId, 0) < 0 ) ) )
            {
               A794NotaFiscalId = T002N21_A794NotaFiscalId[0];
               n794NotaFiscalId = T002N21_n794NotaFiscalId[0];
               AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
               RcdFound93 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2N93( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotaFiscalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2N93( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound93 == 1 )
            {
               if ( A794NotaFiscalId != Z794NotaFiscalId )
               {
                  A794NotaFiscalId = Z794NotaFiscalId;
                  n794NotaFiscalId = false;
                  AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NOTAFISCALID");
                  AnyError = 1;
                  GX_FocusControl = edtNotaFiscalId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNotaFiscalId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2N93( ) ;
                  GX_FocusControl = edtNotaFiscalId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A794NotaFiscalId != Z794NotaFiscalId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtNotaFiscalId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2N93( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NOTAFISCALID");
                     AnyError = 1;
                     GX_FocusControl = edtNotaFiscalId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtNotaFiscalId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2N93( ) ;
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
         if ( A794NotaFiscalId != Z794NotaFiscalId )
         {
            A794NotaFiscalId = Z794NotaFiscalId;
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NOTAFISCALID");
            AnyError = 1;
            GX_FocusControl = edtNotaFiscalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNotaFiscalId_Internalname;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "NOTAFISCALID");
            AnyError = 1;
            GX_FocusControl = edtNotaFiscalId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2N93( ) ;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
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
         ScanStart2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound93 != 0 )
            {
               ScanNext2N93( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2N93( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2N93( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002N2 */
            pr_default.execute(0, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscal"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z795NotaFiscalUF != T002N2_A795NotaFiscalUF[0] ) || ( StringUtil.StrCmp(Z796NotaFiscalNatureza, T002N2_A796NotaFiscalNatureza[0]) != 0 ) || ( StringUtil.StrCmp(Z797NotaFiscalMod, T002N2_A797NotaFiscalMod[0]) != 0 ) || ( StringUtil.StrCmp(Z798NotaFiscalSerie, T002N2_A798NotaFiscalSerie[0]) != 0 ) || ( StringUtil.StrCmp(Z799NotaFiscalNumero, T002N2_A799NotaFiscalNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z800NotaFiscalDataEmissao != T002N2_A800NotaFiscalDataEmissao[0] ) || ( Z801NotaFiscalDataSaida != T002N2_A801NotaFiscalDataSaida[0] ) || ( StringUtil.StrCmp(Z802NotaFiscalTipo, T002N2_A802NotaFiscalTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z803NotaFiscalMunicipio, T002N2_A803NotaFiscalMunicipio[0]) != 0 ) || ( StringUtil.StrCmp(Z804NotaFiscalTipoEmissao, T002N2_A804NotaFiscalTipoEmissao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z805NotaFiscalAmbiente != T002N2_A805NotaFiscalAmbiente[0] ) || ( StringUtil.StrCmp(Z806NotaFiscalFinalidades, T002N2_A806NotaFiscalFinalidades[0]) != 0 ) || ( StringUtil.StrCmp(Z818NotaFiscaEmitentelDocumento, T002N2_A818NotaFiscaEmitentelDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z808NotaFiscalEmitenteNome, T002N2_A808NotaFiscalEmitenteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z809NotaFiscalEmitenteLogradouro, T002N2_A809NotaFiscalEmitenteLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z810NotaFiscalEmitenteLogNum, T002N2_A810NotaFiscalEmitenteLogNum[0]) != 0 ) || ( StringUtil.StrCmp(Z811NotaFiscalEmitenteComplemento, T002N2_A811NotaFiscalEmitenteComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z812NotaFiscalEmitenteBairro, T002N2_A812NotaFiscalEmitenteBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z813NotaFiscalEmitenteMunicipio, T002N2_A813NotaFiscalEmitenteMunicipio[0]) != 0 ) || ( StringUtil.StrCmp(Z814NotaFiscalEmitenteUF, T002N2_A814NotaFiscalEmitenteUF[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z815NotaFiscalEmitenteCEP, T002N2_A815NotaFiscalEmitenteCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z816NotaFiscalEmitentePais, T002N2_A816NotaFiscalEmitentePais[0]) != 0 ) || ( StringUtil.StrCmp(Z817NotaFiscalEmitenteTelefone, T002N2_A817NotaFiscalEmitenteTelefone[0]) != 0 ) || ( StringUtil.StrCmp(Z819NotaFiscalEmitenteIE, T002N2_A819NotaFiscalEmitenteIE[0]) != 0 ) || ( StringUtil.StrCmp(Z820NotaFiscalDestinatarioDocumento, T002N2_A820NotaFiscalDestinatarioDocumento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z852NotaFiscalDestinatarioNome, T002N2_A852NotaFiscalDestinatarioNome[0]) != 0 ) || ( StringUtil.StrCmp(Z821NotaFiscalDestinatarioLogradouro, T002N2_A821NotaFiscalDestinatarioLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z822NotaFiscalDestinatarioLogNum, T002N2_A822NotaFiscalDestinatarioLogNum[0]) != 0 ) || ( StringUtil.StrCmp(Z823NotaFiscalDestinatarioComplemento, T002N2_A823NotaFiscalDestinatarioComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z824NotaFiscalDestinatarioBairro, T002N2_A824NotaFiscalDestinatarioBairro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z825NotaFiscalDestinatarioMunicipio, T002N2_A825NotaFiscalDestinatarioMunicipio[0]) != 0 ) || ( StringUtil.StrCmp(Z826NotaFiscalDestinatarioUF, T002N2_A826NotaFiscalDestinatarioUF[0]) != 0 ) || ( StringUtil.StrCmp(Z827NotaFiscalDestinatarioCEP, T002N2_A827NotaFiscalDestinatarioCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z828NotaFiscalDestinatarioPais, T002N2_A828NotaFiscalDestinatarioPais[0]) != 0 ) || ( StringUtil.StrCmp(Z829NotaFiscalDestinatarioFone, T002N2_A829NotaFiscalDestinatarioFone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z168ClienteId != T002N2_A168ClienteId[0] ) || ( Z889NotaFiscalDestinatarioClienteId != T002N2_A889NotaFiscalDestinatarioClienteId[0] ) )
            {
               if ( Z795NotaFiscalUF != T002N2_A795NotaFiscalUF[0] )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalUF");
                  GXUtil.WriteLogRaw("Old: ",Z795NotaFiscalUF);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A795NotaFiscalUF[0]);
               }
               if ( StringUtil.StrCmp(Z796NotaFiscalNatureza, T002N2_A796NotaFiscalNatureza[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalNatureza");
                  GXUtil.WriteLogRaw("Old: ",Z796NotaFiscalNatureza);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A796NotaFiscalNatureza[0]);
               }
               if ( StringUtil.StrCmp(Z797NotaFiscalMod, T002N2_A797NotaFiscalMod[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalMod");
                  GXUtil.WriteLogRaw("Old: ",Z797NotaFiscalMod);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A797NotaFiscalMod[0]);
               }
               if ( StringUtil.StrCmp(Z798NotaFiscalSerie, T002N2_A798NotaFiscalSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalSerie");
                  GXUtil.WriteLogRaw("Old: ",Z798NotaFiscalSerie);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A798NotaFiscalSerie[0]);
               }
               if ( StringUtil.StrCmp(Z799NotaFiscalNumero, T002N2_A799NotaFiscalNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalNumero");
                  GXUtil.WriteLogRaw("Old: ",Z799NotaFiscalNumero);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A799NotaFiscalNumero[0]);
               }
               if ( Z800NotaFiscalDataEmissao != T002N2_A800NotaFiscalDataEmissao[0] )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDataEmissao");
                  GXUtil.WriteLogRaw("Old: ",Z800NotaFiscalDataEmissao);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A800NotaFiscalDataEmissao[0]);
               }
               if ( Z801NotaFiscalDataSaida != T002N2_A801NotaFiscalDataSaida[0] )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDataSaida");
                  GXUtil.WriteLogRaw("Old: ",Z801NotaFiscalDataSaida);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A801NotaFiscalDataSaida[0]);
               }
               if ( StringUtil.StrCmp(Z802NotaFiscalTipo, T002N2_A802NotaFiscalTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalTipo");
                  GXUtil.WriteLogRaw("Old: ",Z802NotaFiscalTipo);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A802NotaFiscalTipo[0]);
               }
               if ( StringUtil.StrCmp(Z803NotaFiscalMunicipio, T002N2_A803NotaFiscalMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z803NotaFiscalMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A803NotaFiscalMunicipio[0]);
               }
               if ( StringUtil.StrCmp(Z804NotaFiscalTipoEmissao, T002N2_A804NotaFiscalTipoEmissao[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalTipoEmissao");
                  GXUtil.WriteLogRaw("Old: ",Z804NotaFiscalTipoEmissao);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A804NotaFiscalTipoEmissao[0]);
               }
               if ( Z805NotaFiscalAmbiente != T002N2_A805NotaFiscalAmbiente[0] )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalAmbiente");
                  GXUtil.WriteLogRaw("Old: ",Z805NotaFiscalAmbiente);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A805NotaFiscalAmbiente[0]);
               }
               if ( StringUtil.StrCmp(Z806NotaFiscalFinalidades, T002N2_A806NotaFiscalFinalidades[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalFinalidades");
                  GXUtil.WriteLogRaw("Old: ",Z806NotaFiscalFinalidades);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A806NotaFiscalFinalidades[0]);
               }
               if ( StringUtil.StrCmp(Z818NotaFiscaEmitentelDocumento, T002N2_A818NotaFiscaEmitentelDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscaEmitentelDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z818NotaFiscaEmitentelDocumento);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A818NotaFiscaEmitentelDocumento[0]);
               }
               if ( StringUtil.StrCmp(Z808NotaFiscalEmitenteNome, T002N2_A808NotaFiscalEmitenteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteNome");
                  GXUtil.WriteLogRaw("Old: ",Z808NotaFiscalEmitenteNome);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A808NotaFiscalEmitenteNome[0]);
               }
               if ( StringUtil.StrCmp(Z809NotaFiscalEmitenteLogradouro, T002N2_A809NotaFiscalEmitenteLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z809NotaFiscalEmitenteLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A809NotaFiscalEmitenteLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z810NotaFiscalEmitenteLogNum, T002N2_A810NotaFiscalEmitenteLogNum[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteLogNum");
                  GXUtil.WriteLogRaw("Old: ",Z810NotaFiscalEmitenteLogNum);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A810NotaFiscalEmitenteLogNum[0]);
               }
               if ( StringUtil.StrCmp(Z811NotaFiscalEmitenteComplemento, T002N2_A811NotaFiscalEmitenteComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z811NotaFiscalEmitenteComplemento);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A811NotaFiscalEmitenteComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z812NotaFiscalEmitenteBairro, T002N2_A812NotaFiscalEmitenteBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteBairro");
                  GXUtil.WriteLogRaw("Old: ",Z812NotaFiscalEmitenteBairro);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A812NotaFiscalEmitenteBairro[0]);
               }
               if ( StringUtil.StrCmp(Z813NotaFiscalEmitenteMunicipio, T002N2_A813NotaFiscalEmitenteMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z813NotaFiscalEmitenteMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A813NotaFiscalEmitenteMunicipio[0]);
               }
               if ( StringUtil.StrCmp(Z814NotaFiscalEmitenteUF, T002N2_A814NotaFiscalEmitenteUF[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteUF");
                  GXUtil.WriteLogRaw("Old: ",Z814NotaFiscalEmitenteUF);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A814NotaFiscalEmitenteUF[0]);
               }
               if ( StringUtil.StrCmp(Z815NotaFiscalEmitenteCEP, T002N2_A815NotaFiscalEmitenteCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteCEP");
                  GXUtil.WriteLogRaw("Old: ",Z815NotaFiscalEmitenteCEP);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A815NotaFiscalEmitenteCEP[0]);
               }
               if ( StringUtil.StrCmp(Z816NotaFiscalEmitentePais, T002N2_A816NotaFiscalEmitentePais[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitentePais");
                  GXUtil.WriteLogRaw("Old: ",Z816NotaFiscalEmitentePais);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A816NotaFiscalEmitentePais[0]);
               }
               if ( StringUtil.StrCmp(Z817NotaFiscalEmitenteTelefone, T002N2_A817NotaFiscalEmitenteTelefone[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteTelefone");
                  GXUtil.WriteLogRaw("Old: ",Z817NotaFiscalEmitenteTelefone);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A817NotaFiscalEmitenteTelefone[0]);
               }
               if ( StringUtil.StrCmp(Z819NotaFiscalEmitenteIE, T002N2_A819NotaFiscalEmitenteIE[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalEmitenteIE");
                  GXUtil.WriteLogRaw("Old: ",Z819NotaFiscalEmitenteIE);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A819NotaFiscalEmitenteIE[0]);
               }
               if ( StringUtil.StrCmp(Z820NotaFiscalDestinatarioDocumento, T002N2_A820NotaFiscalDestinatarioDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z820NotaFiscalDestinatarioDocumento);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A820NotaFiscalDestinatarioDocumento[0]);
               }
               if ( StringUtil.StrCmp(Z852NotaFiscalDestinatarioNome, T002N2_A852NotaFiscalDestinatarioNome[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioNome");
                  GXUtil.WriteLogRaw("Old: ",Z852NotaFiscalDestinatarioNome);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A852NotaFiscalDestinatarioNome[0]);
               }
               if ( StringUtil.StrCmp(Z821NotaFiscalDestinatarioLogradouro, T002N2_A821NotaFiscalDestinatarioLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z821NotaFiscalDestinatarioLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A821NotaFiscalDestinatarioLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z822NotaFiscalDestinatarioLogNum, T002N2_A822NotaFiscalDestinatarioLogNum[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioLogNum");
                  GXUtil.WriteLogRaw("Old: ",Z822NotaFiscalDestinatarioLogNum);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A822NotaFiscalDestinatarioLogNum[0]);
               }
               if ( StringUtil.StrCmp(Z823NotaFiscalDestinatarioComplemento, T002N2_A823NotaFiscalDestinatarioComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z823NotaFiscalDestinatarioComplemento);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A823NotaFiscalDestinatarioComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z824NotaFiscalDestinatarioBairro, T002N2_A824NotaFiscalDestinatarioBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioBairro");
                  GXUtil.WriteLogRaw("Old: ",Z824NotaFiscalDestinatarioBairro);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A824NotaFiscalDestinatarioBairro[0]);
               }
               if ( StringUtil.StrCmp(Z825NotaFiscalDestinatarioMunicipio, T002N2_A825NotaFiscalDestinatarioMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z825NotaFiscalDestinatarioMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A825NotaFiscalDestinatarioMunicipio[0]);
               }
               if ( StringUtil.StrCmp(Z826NotaFiscalDestinatarioUF, T002N2_A826NotaFiscalDestinatarioUF[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioUF");
                  GXUtil.WriteLogRaw("Old: ",Z826NotaFiscalDestinatarioUF);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A826NotaFiscalDestinatarioUF[0]);
               }
               if ( StringUtil.StrCmp(Z827NotaFiscalDestinatarioCEP, T002N2_A827NotaFiscalDestinatarioCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioCEP");
                  GXUtil.WriteLogRaw("Old: ",Z827NotaFiscalDestinatarioCEP);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A827NotaFiscalDestinatarioCEP[0]);
               }
               if ( StringUtil.StrCmp(Z828NotaFiscalDestinatarioPais, T002N2_A828NotaFiscalDestinatarioPais[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioPais");
                  GXUtil.WriteLogRaw("Old: ",Z828NotaFiscalDestinatarioPais);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A828NotaFiscalDestinatarioPais[0]);
               }
               if ( StringUtil.StrCmp(Z829NotaFiscalDestinatarioFone, T002N2_A829NotaFiscalDestinatarioFone[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioFone");
                  GXUtil.WriteLogRaw("Old: ",Z829NotaFiscalDestinatarioFone);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A829NotaFiscalDestinatarioFone[0]);
               }
               if ( Z168ClienteId != T002N2_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A168ClienteId[0]);
               }
               if ( Z889NotaFiscalDestinatarioClienteId != T002N2_A889NotaFiscalDestinatarioClienteId[0] )
               {
                  GXUtil.WriteLog("notafiscal:[seudo value changed for attri]"+"NotaFiscalDestinatarioClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z889NotaFiscalDestinatarioClienteId);
                  GXUtil.WriteLogRaw("Current: ",T002N2_A889NotaFiscalDestinatarioClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscal"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2N93( )
      {
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2N93( 0) ;
            CheckOptimisticConcurrency2N93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2N93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2N93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002N22 */
                     pr_default.execute(14, new Object[] {n794NotaFiscalId, A794NotaFiscalId, n795NotaFiscalUF, A795NotaFiscalUF, n796NotaFiscalNatureza, A796NotaFiscalNatureza, n797NotaFiscalMod, A797NotaFiscalMod, n798NotaFiscalSerie, A798NotaFiscalSerie, n799NotaFiscalNumero, A799NotaFiscalNumero, n800NotaFiscalDataEmissao, A800NotaFiscalDataEmissao, n801NotaFiscalDataSaida, A801NotaFiscalDataSaida, n802NotaFiscalTipo, A802NotaFiscalTipo, n803NotaFiscalMunicipio, A803NotaFiscalMunicipio, n804NotaFiscalTipoEmissao, A804NotaFiscalTipoEmissao, n805NotaFiscalAmbiente, A805NotaFiscalAmbiente, n806NotaFiscalFinalidades, A806NotaFiscalFinalidades, n818NotaFiscaEmitentelDocumento, A818NotaFiscaEmitentelDocumento, n808NotaFiscalEmitenteNome, A808NotaFiscalEmitenteNome, n809NotaFiscalEmitenteLogradouro, A809NotaFiscalEmitenteLogradouro, n810NotaFiscalEmitenteLogNum, A810NotaFiscalEmitenteLogNum, n811NotaFiscalEmitenteComplemento, A811NotaFiscalEmitenteComplemento, n812NotaFiscalEmitenteBairro, A812NotaFiscalEmitenteBairro, n813NotaFiscalEmitenteMunicipio, A813NotaFiscalEmitenteMunicipio, n814NotaFiscalEmitenteUF, A814NotaFiscalEmitenteUF, n815NotaFiscalEmitenteCEP, A815NotaFiscalEmitenteCEP, n816NotaFiscalEmitentePais, A816NotaFiscalEmitentePais, n817NotaFiscalEmitenteTelefone, A817NotaFiscalEmitenteTelefone, n819NotaFiscalEmitenteIE, A819NotaFiscalEmitenteIE, n820NotaFiscalDestinatarioDocumento, A820NotaFiscalDestinatarioDocumento, n852NotaFiscalDestinatarioNome, A852NotaFiscalDestinatarioNome, n821NotaFiscalDestinatarioLogradouro, A821NotaFiscalDestinatarioLogradouro, n822NotaFiscalDestinatarioLogNum, A822NotaFiscalDestinatarioLogNum, n823NotaFiscalDestinatarioComplemento, A823NotaFiscalDestinatarioComplemento, n824NotaFiscalDestinatarioBairro, A824NotaFiscalDestinatarioBairro, n825NotaFiscalDestinatarioMunicipio, A825NotaFiscalDestinatarioMunicipio, n826NotaFiscalDestinatarioUF, A826NotaFiscalDestinatarioUF, n827NotaFiscalDestinatarioCEP, A827NotaFiscalDestinatarioCEP, n828NotaFiscalDestinatarioPais, A828NotaFiscalDestinatarioPais, n829NotaFiscalDestinatarioFone, A829NotaFiscalDestinatarioFone, n168ClienteId, A168ClienteId, n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption2N0( ) ;
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
               Load2N93( ) ;
            }
            EndLevel2N93( ) ;
         }
         CloseExtendedTableCursors2N93( ) ;
      }

      protected void Update2N93( )
      {
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2N93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2N93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2N93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002N23 */
                     pr_default.execute(15, new Object[] {n795NotaFiscalUF, A795NotaFiscalUF, n796NotaFiscalNatureza, A796NotaFiscalNatureza, n797NotaFiscalMod, A797NotaFiscalMod, n798NotaFiscalSerie, A798NotaFiscalSerie, n799NotaFiscalNumero, A799NotaFiscalNumero, n800NotaFiscalDataEmissao, A800NotaFiscalDataEmissao, n801NotaFiscalDataSaida, A801NotaFiscalDataSaida, n802NotaFiscalTipo, A802NotaFiscalTipo, n803NotaFiscalMunicipio, A803NotaFiscalMunicipio, n804NotaFiscalTipoEmissao, A804NotaFiscalTipoEmissao, n805NotaFiscalAmbiente, A805NotaFiscalAmbiente, n806NotaFiscalFinalidades, A806NotaFiscalFinalidades, n818NotaFiscaEmitentelDocumento, A818NotaFiscaEmitentelDocumento, n808NotaFiscalEmitenteNome, A808NotaFiscalEmitenteNome, n809NotaFiscalEmitenteLogradouro, A809NotaFiscalEmitenteLogradouro, n810NotaFiscalEmitenteLogNum, A810NotaFiscalEmitenteLogNum, n811NotaFiscalEmitenteComplemento, A811NotaFiscalEmitenteComplemento, n812NotaFiscalEmitenteBairro, A812NotaFiscalEmitenteBairro, n813NotaFiscalEmitenteMunicipio, A813NotaFiscalEmitenteMunicipio, n814NotaFiscalEmitenteUF, A814NotaFiscalEmitenteUF, n815NotaFiscalEmitenteCEP, A815NotaFiscalEmitenteCEP, n816NotaFiscalEmitentePais, A816NotaFiscalEmitentePais, n817NotaFiscalEmitenteTelefone, A817NotaFiscalEmitenteTelefone, n819NotaFiscalEmitenteIE, A819NotaFiscalEmitenteIE, n820NotaFiscalDestinatarioDocumento, A820NotaFiscalDestinatarioDocumento, n852NotaFiscalDestinatarioNome, A852NotaFiscalDestinatarioNome, n821NotaFiscalDestinatarioLogradouro, A821NotaFiscalDestinatarioLogradouro, n822NotaFiscalDestinatarioLogNum, A822NotaFiscalDestinatarioLogNum, n823NotaFiscalDestinatarioComplemento, A823NotaFiscalDestinatarioComplemento, n824NotaFiscalDestinatarioBairro, A824NotaFiscalDestinatarioBairro, n825NotaFiscalDestinatarioMunicipio, A825NotaFiscalDestinatarioMunicipio, n826NotaFiscalDestinatarioUF, A826NotaFiscalDestinatarioUF, n827NotaFiscalDestinatarioCEP, A827NotaFiscalDestinatarioCEP, n828NotaFiscalDestinatarioPais, A828NotaFiscalDestinatarioPais, n829NotaFiscalDestinatarioFone, A829NotaFiscalDestinatarioFone, n168ClienteId, A168ClienteId, n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId, n794NotaFiscalId, A794NotaFiscalId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscal"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2N93( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2N0( ) ;
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
            EndLevel2N93( ) ;
         }
         CloseExtendedTableCursors2N93( ) ;
      }

      protected void DeferredUpdate2N93( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2N93( ) ;
            AfterConfirm2N93( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2N93( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002N24 */
                  pr_default.execute(16, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound93 == 0 )
                        {
                           InitAll2N93( ) ;
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
                        ResetCaption2N0( ) ;
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
         sMode93 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2N93( ) ;
         Gx_mode = sMode93;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2N93( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002N26 */
            pr_default.execute(17, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A874NotaFiscalValorTotal_F = T002N26_A874NotaFiscalValorTotal_F[0];
               AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
               A877NotaFiscalQuantidadeDeItens_F = T002N26_A877NotaFiscalQuantidadeDeItens_F[0];
               AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
            }
            else
            {
               A874NotaFiscalValorTotal_F = 0;
               AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
               A877NotaFiscalQuantidadeDeItens_F = 0;
               AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
            }
            pr_default.close(17);
            A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
            /* Using cursor T002N28 */
            pr_default.execute(18, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A875NotaFiscalValorTotalVendido_F = T002N28_A875NotaFiscalValorTotalVendido_F[0];
               AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
               A878NotaFiscalQuantidadeDeItensVendidos_F = T002N28_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
               AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
            }
            else
            {
               A875NotaFiscalValorTotalVendido_F = 0;
               AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
               A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
               AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
            }
            pr_default.close(18);
            A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
            AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2));
            A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
            A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
            A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
            AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002N29 */
            pr_default.execute(19, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Nota Fiscal Parcelamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002N30 */
            pr_default.execute(20, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel2N93( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2N0( ) ;
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

      public void ScanStart2N93( )
      {
         /* Using cursor T002N31 */
         pr_default.execute(21);
         RcdFound93 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound93 = 1;
            A794NotaFiscalId = T002N31_A794NotaFiscalId[0];
            n794NotaFiscalId = T002N31_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2N93( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound93 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound93 = 1;
            A794NotaFiscalId = T002N31_A794NotaFiscalId[0];
            n794NotaFiscalId = T002N31_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         }
      }

      protected void ScanEnd2N93( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm2N93( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2N93( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2N93( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2N93( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2N93( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2N93( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2N93( )
      {
         edtNotaFiscalId_Enabled = 0;
         AssignProp("", false, edtNotaFiscalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         cmbNotaFiscalUF.Enabled = 0;
         AssignProp("", false, cmbNotaFiscalUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotaFiscalUF.Enabled), 5, 0), true);
         edtNotaFiscalValorTotal_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalValorTotal_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalValorTotal_F_Enabled), 5, 0), true);
         edtNotaFiscalValorTotalVendido_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalValorTotalVendido_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalValorTotalVendido_F_Enabled), 5, 0), true);
         edtNotaFiscalSaldo_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalSaldo_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalSaldo_F_Enabled), 5, 0), true);
         edtNotaFiscalQuantidadeDeItens_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalQuantidadeDeItens_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalQuantidadeDeItens_F_Enabled), 5, 0), true);
         edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled), 5, 0), true);
         edtNotaFiscalQuantidadeResumo_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalQuantidadeResumo_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalQuantidadeResumo_F_Enabled), 5, 0), true);
         edtNotaFiscalValorFormatado_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalValorFormatado_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalValorFormatado_F_Enabled), 5, 0), true);
         edtNotaFiscalValorVendidoFormatado_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalValorVendidoFormatado_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalValorVendidoFormatado_F_Enabled), 5, 0), true);
         edtNotaFiscalSaldoFormatado_F_Enabled = 0;
         AssignProp("", false, edtNotaFiscalSaldoFormatado_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalSaldoFormatado_F_Enabled), 5, 0), true);
         cmbNotaFiscalStatus.Enabled = 0;
         AssignProp("", false, cmbNotaFiscalStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotaFiscalStatus.Enabled), 5, 0), true);
         edtNotaFiscalNatureza_Enabled = 0;
         AssignProp("", false, edtNotaFiscalNatureza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalNatureza_Enabled), 5, 0), true);
         edtNotaFiscalMod_Enabled = 0;
         AssignProp("", false, edtNotaFiscalMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalMod_Enabled), 5, 0), true);
         edtNotaFiscalSerie_Enabled = 0;
         AssignProp("", false, edtNotaFiscalSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalSerie_Enabled), 5, 0), true);
         edtNotaFiscalNumero_Enabled = 0;
         AssignProp("", false, edtNotaFiscalNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalNumero_Enabled), 5, 0), true);
         edtNotaFiscalDataEmissao_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDataEmissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDataEmissao_Enabled), 5, 0), true);
         edtNotaFiscalDataSaida_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDataSaida_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDataSaida_Enabled), 5, 0), true);
         cmbNotaFiscalTipo.Enabled = 0;
         AssignProp("", false, cmbNotaFiscalTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotaFiscalTipo.Enabled), 5, 0), true);
         edtNotaFiscalMunicipio_Enabled = 0;
         AssignProp("", false, edtNotaFiscalMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalMunicipio_Enabled), 5, 0), true);
         cmbNotaFiscalTipoEmissao.Enabled = 0;
         AssignProp("", false, cmbNotaFiscalTipoEmissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotaFiscalTipoEmissao.Enabled), 5, 0), true);
         cmbNotaFiscalAmbiente.Enabled = 0;
         AssignProp("", false, cmbNotaFiscalAmbiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotaFiscalAmbiente.Enabled), 5, 0), true);
         cmbNotaFiscalFinalidades.Enabled = 0;
         AssignProp("", false, cmbNotaFiscalFinalidades_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotaFiscalFinalidades.Enabled), 5, 0), true);
         edtNotaFiscaEmitentelDocumento_Enabled = 0;
         AssignProp("", false, edtNotaFiscaEmitentelDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscaEmitentelDocumento_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteNome_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteNome_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteLogradouro_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteLogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteLogradouro_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteLogNum_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteLogNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteLogNum_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteComplemento_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteComplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteComplemento_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteBairro_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteBairro_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteMunicipio_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteMunicipio_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteUF_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteUF_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteCEP_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteCEP_Enabled), 5, 0), true);
         edtNotaFiscalEmitentePais_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitentePais_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitentePais_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteTelefone_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteTelefone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteTelefone_Enabled), 5, 0), true);
         edtNotaFiscalEmitenteIE_Enabled = 0;
         AssignProp("", false, edtNotaFiscalEmitenteIE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalEmitenteIE_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioClienteId_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioClienteId_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioDocumento_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioDocumento_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioNome_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioNome_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioLogradouro_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioLogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioLogradouro_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioLogNum_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioLogNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioLogNum_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioComplemento_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioComplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioComplemento_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioBairro_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioBairro_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioMunicipio_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioMunicipio_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioUF_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioUF_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioCEP_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioCEP_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioPais_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioPais_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioPais_Enabled), 5, 0), true);
         edtNotaFiscalDestinatarioFone_Enabled = 0;
         AssignProp("", false, edtNotaFiscalDestinatarioFone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalDestinatarioFone_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2N93( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2N0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notafiscal") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z794NotaFiscalId", Z794NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "Z795NotaFiscalUF", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z795NotaFiscalUF), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z796NotaFiscalNatureza", Z796NotaFiscalNatureza);
         GxWebStd.gx_hidden_field( context, "Z797NotaFiscalMod", Z797NotaFiscalMod);
         GxWebStd.gx_hidden_field( context, "Z798NotaFiscalSerie", Z798NotaFiscalSerie);
         GxWebStd.gx_hidden_field( context, "Z799NotaFiscalNumero", Z799NotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, "Z800NotaFiscalDataEmissao", context.localUtil.TToC( Z800NotaFiscalDataEmissao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z801NotaFiscalDataSaida", context.localUtil.TToC( Z801NotaFiscalDataSaida, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z802NotaFiscalTipo", Z802NotaFiscalTipo);
         GxWebStd.gx_hidden_field( context, "Z803NotaFiscalMunicipio", Z803NotaFiscalMunicipio);
         GxWebStd.gx_hidden_field( context, "Z804NotaFiscalTipoEmissao", Z804NotaFiscalTipoEmissao);
         GxWebStd.gx_hidden_field( context, "Z805NotaFiscalAmbiente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z805NotaFiscalAmbiente), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z806NotaFiscalFinalidades", Z806NotaFiscalFinalidades);
         GxWebStd.gx_hidden_field( context, "Z818NotaFiscaEmitentelDocumento", Z818NotaFiscaEmitentelDocumento);
         GxWebStd.gx_hidden_field( context, "Z808NotaFiscalEmitenteNome", Z808NotaFiscalEmitenteNome);
         GxWebStd.gx_hidden_field( context, "Z809NotaFiscalEmitenteLogradouro", Z809NotaFiscalEmitenteLogradouro);
         GxWebStd.gx_hidden_field( context, "Z810NotaFiscalEmitenteLogNum", Z810NotaFiscalEmitenteLogNum);
         GxWebStd.gx_hidden_field( context, "Z811NotaFiscalEmitenteComplemento", Z811NotaFiscalEmitenteComplemento);
         GxWebStd.gx_hidden_field( context, "Z812NotaFiscalEmitenteBairro", Z812NotaFiscalEmitenteBairro);
         GxWebStd.gx_hidden_field( context, "Z813NotaFiscalEmitenteMunicipio", Z813NotaFiscalEmitenteMunicipio);
         GxWebStd.gx_hidden_field( context, "Z814NotaFiscalEmitenteUF", Z814NotaFiscalEmitenteUF);
         GxWebStd.gx_hidden_field( context, "Z815NotaFiscalEmitenteCEP", Z815NotaFiscalEmitenteCEP);
         GxWebStd.gx_hidden_field( context, "Z816NotaFiscalEmitentePais", Z816NotaFiscalEmitentePais);
         GxWebStd.gx_hidden_field( context, "Z817NotaFiscalEmitenteTelefone", Z817NotaFiscalEmitenteTelefone);
         GxWebStd.gx_hidden_field( context, "Z819NotaFiscalEmitenteIE", Z819NotaFiscalEmitenteIE);
         GxWebStd.gx_hidden_field( context, "Z820NotaFiscalDestinatarioDocumento", Z820NotaFiscalDestinatarioDocumento);
         GxWebStd.gx_hidden_field( context, "Z852NotaFiscalDestinatarioNome", Z852NotaFiscalDestinatarioNome);
         GxWebStd.gx_hidden_field( context, "Z821NotaFiscalDestinatarioLogradouro", Z821NotaFiscalDestinatarioLogradouro);
         GxWebStd.gx_hidden_field( context, "Z822NotaFiscalDestinatarioLogNum", Z822NotaFiscalDestinatarioLogNum);
         GxWebStd.gx_hidden_field( context, "Z823NotaFiscalDestinatarioComplemento", Z823NotaFiscalDestinatarioComplemento);
         GxWebStd.gx_hidden_field( context, "Z824NotaFiscalDestinatarioBairro", Z824NotaFiscalDestinatarioBairro);
         GxWebStd.gx_hidden_field( context, "Z825NotaFiscalDestinatarioMunicipio", Z825NotaFiscalDestinatarioMunicipio);
         GxWebStd.gx_hidden_field( context, "Z826NotaFiscalDestinatarioUF", Z826NotaFiscalDestinatarioUF);
         GxWebStd.gx_hidden_field( context, "Z827NotaFiscalDestinatarioCEP", Z827NotaFiscalDestinatarioCEP);
         GxWebStd.gx_hidden_field( context, "Z828NotaFiscalDestinatarioPais", Z828NotaFiscalDestinatarioPais);
         GxWebStd.gx_hidden_field( context, "Z829NotaFiscalDestinatarioFone", Z829NotaFiscalDestinatarioFone);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z889NotaFiscalDestinatarioClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z889NotaFiscalDestinatarioClienteId), 9, 0, ",", "")));
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
         return formatLink("notafiscal")  ;
      }

      public override string GetPgmname( )
      {
         return "NotaFiscal" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nota Fiscal" ;
      }

      protected void InitializeNonKey2N93( )
      {
         A879NotaFiscalQuantidadeResumo_F = "";
         AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
         A880NotaFiscalStatus = "";
         AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
         A883NotaFiscalSaldoFormatado_F = "";
         AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
         A882NotaFiscalValorVendidoFormatado_F = "";
         AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
         A876NotaFiscalSaldo_F = 0;
         AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2));
         A881NotaFiscalValorFormatado_F = "";
         AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A795NotaFiscalUF = 0;
         n795NotaFiscalUF = false;
         AssignAttri("", false, "A795NotaFiscalUF", ((0==A795NotaFiscalUF)&&IsIns( )||n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
         n795NotaFiscalUF = ((0==A795NotaFiscalUF) ? true : false);
         A874NotaFiscalValorTotal_F = 0;
         AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2));
         A875NotaFiscalValorTotalVendido_F = 0;
         AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2));
         A877NotaFiscalQuantidadeDeItens_F = 0;
         AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0));
         A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
         AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0));
         A796NotaFiscalNatureza = "";
         n796NotaFiscalNatureza = false;
         AssignAttri("", false, "A796NotaFiscalNatureza", A796NotaFiscalNatureza);
         n796NotaFiscalNatureza = (String.IsNullOrEmpty(StringUtil.RTrim( A796NotaFiscalNatureza)) ? true : false);
         A797NotaFiscalMod = "";
         n797NotaFiscalMod = false;
         AssignAttri("", false, "A797NotaFiscalMod", A797NotaFiscalMod);
         n797NotaFiscalMod = (String.IsNullOrEmpty(StringUtil.RTrim( A797NotaFiscalMod)) ? true : false);
         A798NotaFiscalSerie = "";
         n798NotaFiscalSerie = false;
         AssignAttri("", false, "A798NotaFiscalSerie", A798NotaFiscalSerie);
         n798NotaFiscalSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A798NotaFiscalSerie)) ? true : false);
         A799NotaFiscalNumero = "";
         n799NotaFiscalNumero = false;
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
         n799NotaFiscalNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? true : false);
         A800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         n800NotaFiscalDataEmissao = false;
         AssignAttri("", false, "A800NotaFiscalDataEmissao", context.localUtil.TToC( A800NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
         n800NotaFiscalDataEmissao = ((DateTime.MinValue==A800NotaFiscalDataEmissao) ? true : false);
         A801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         n801NotaFiscalDataSaida = false;
         AssignAttri("", false, "A801NotaFiscalDataSaida", context.localUtil.TToC( A801NotaFiscalDataSaida, 8, 5, 0, 3, "/", ":", " "));
         n801NotaFiscalDataSaida = ((DateTime.MinValue==A801NotaFiscalDataSaida) ? true : false);
         A802NotaFiscalTipo = "";
         n802NotaFiscalTipo = false;
         AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
         n802NotaFiscalTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A802NotaFiscalTipo)) ? true : false);
         A803NotaFiscalMunicipio = "";
         n803NotaFiscalMunicipio = false;
         AssignAttri("", false, "A803NotaFiscalMunicipio", A803NotaFiscalMunicipio);
         n803NotaFiscalMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A803NotaFiscalMunicipio)) ? true : false);
         A804NotaFiscalTipoEmissao = "";
         n804NotaFiscalTipoEmissao = false;
         AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
         n804NotaFiscalTipoEmissao = (String.IsNullOrEmpty(StringUtil.RTrim( A804NotaFiscalTipoEmissao)) ? true : false);
         A805NotaFiscalAmbiente = 0;
         n805NotaFiscalAmbiente = false;
         AssignAttri("", false, "A805NotaFiscalAmbiente", ((0==A805NotaFiscalAmbiente)&&IsIns( )||n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
         n805NotaFiscalAmbiente = ((0==A805NotaFiscalAmbiente) ? true : false);
         A806NotaFiscalFinalidades = "";
         n806NotaFiscalFinalidades = false;
         AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
         n806NotaFiscalFinalidades = (String.IsNullOrEmpty(StringUtil.RTrim( A806NotaFiscalFinalidades)) ? true : false);
         A818NotaFiscaEmitentelDocumento = "";
         n818NotaFiscaEmitentelDocumento = false;
         AssignAttri("", false, "A818NotaFiscaEmitentelDocumento", A818NotaFiscaEmitentelDocumento);
         n818NotaFiscaEmitentelDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A818NotaFiscaEmitentelDocumento)) ? true : false);
         A808NotaFiscalEmitenteNome = "";
         n808NotaFiscalEmitenteNome = false;
         AssignAttri("", false, "A808NotaFiscalEmitenteNome", A808NotaFiscalEmitenteNome);
         n808NotaFiscalEmitenteNome = (String.IsNullOrEmpty(StringUtil.RTrim( A808NotaFiscalEmitenteNome)) ? true : false);
         A809NotaFiscalEmitenteLogradouro = "";
         n809NotaFiscalEmitenteLogradouro = false;
         AssignAttri("", false, "A809NotaFiscalEmitenteLogradouro", A809NotaFiscalEmitenteLogradouro);
         n809NotaFiscalEmitenteLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A809NotaFiscalEmitenteLogradouro)) ? true : false);
         A810NotaFiscalEmitenteLogNum = "";
         n810NotaFiscalEmitenteLogNum = false;
         AssignAttri("", false, "A810NotaFiscalEmitenteLogNum", A810NotaFiscalEmitenteLogNum);
         n810NotaFiscalEmitenteLogNum = (String.IsNullOrEmpty(StringUtil.RTrim( A810NotaFiscalEmitenteLogNum)) ? true : false);
         A811NotaFiscalEmitenteComplemento = "";
         n811NotaFiscalEmitenteComplemento = false;
         AssignAttri("", false, "A811NotaFiscalEmitenteComplemento", A811NotaFiscalEmitenteComplemento);
         n811NotaFiscalEmitenteComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A811NotaFiscalEmitenteComplemento)) ? true : false);
         A812NotaFiscalEmitenteBairro = "";
         n812NotaFiscalEmitenteBairro = false;
         AssignAttri("", false, "A812NotaFiscalEmitenteBairro", A812NotaFiscalEmitenteBairro);
         n812NotaFiscalEmitenteBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A812NotaFiscalEmitenteBairro)) ? true : false);
         A813NotaFiscalEmitenteMunicipio = "";
         n813NotaFiscalEmitenteMunicipio = false;
         AssignAttri("", false, "A813NotaFiscalEmitenteMunicipio", A813NotaFiscalEmitenteMunicipio);
         n813NotaFiscalEmitenteMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A813NotaFiscalEmitenteMunicipio)) ? true : false);
         A814NotaFiscalEmitenteUF = "";
         n814NotaFiscalEmitenteUF = false;
         AssignAttri("", false, "A814NotaFiscalEmitenteUF", A814NotaFiscalEmitenteUF);
         n814NotaFiscalEmitenteUF = (String.IsNullOrEmpty(StringUtil.RTrim( A814NotaFiscalEmitenteUF)) ? true : false);
         A815NotaFiscalEmitenteCEP = "";
         n815NotaFiscalEmitenteCEP = false;
         AssignAttri("", false, "A815NotaFiscalEmitenteCEP", A815NotaFiscalEmitenteCEP);
         n815NotaFiscalEmitenteCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A815NotaFiscalEmitenteCEP)) ? true : false);
         A816NotaFiscalEmitentePais = "";
         n816NotaFiscalEmitentePais = false;
         AssignAttri("", false, "A816NotaFiscalEmitentePais", A816NotaFiscalEmitentePais);
         n816NotaFiscalEmitentePais = (String.IsNullOrEmpty(StringUtil.RTrim( A816NotaFiscalEmitentePais)) ? true : false);
         A817NotaFiscalEmitenteTelefone = "";
         n817NotaFiscalEmitenteTelefone = false;
         AssignAttri("", false, "A817NotaFiscalEmitenteTelefone", A817NotaFiscalEmitenteTelefone);
         n817NotaFiscalEmitenteTelefone = (String.IsNullOrEmpty(StringUtil.RTrim( A817NotaFiscalEmitenteTelefone)) ? true : false);
         A819NotaFiscalEmitenteIE = "";
         n819NotaFiscalEmitenteIE = false;
         AssignAttri("", false, "A819NotaFiscalEmitenteIE", A819NotaFiscalEmitenteIE);
         n819NotaFiscalEmitenteIE = (String.IsNullOrEmpty(StringUtil.RTrim( A819NotaFiscalEmitenteIE)) ? true : false);
         A889NotaFiscalDestinatarioClienteId = 0;
         n889NotaFiscalDestinatarioClienteId = false;
         AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
         n889NotaFiscalDestinatarioClienteId = ((0==A889NotaFiscalDestinatarioClienteId) ? true : false);
         A820NotaFiscalDestinatarioDocumento = "";
         n820NotaFiscalDestinatarioDocumento = false;
         AssignAttri("", false, "A820NotaFiscalDestinatarioDocumento", A820NotaFiscalDestinatarioDocumento);
         n820NotaFiscalDestinatarioDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A820NotaFiscalDestinatarioDocumento)) ? true : false);
         A852NotaFiscalDestinatarioNome = "";
         n852NotaFiscalDestinatarioNome = false;
         AssignAttri("", false, "A852NotaFiscalDestinatarioNome", A852NotaFiscalDestinatarioNome);
         n852NotaFiscalDestinatarioNome = (String.IsNullOrEmpty(StringUtil.RTrim( A852NotaFiscalDestinatarioNome)) ? true : false);
         A821NotaFiscalDestinatarioLogradouro = "";
         n821NotaFiscalDestinatarioLogradouro = false;
         AssignAttri("", false, "A821NotaFiscalDestinatarioLogradouro", A821NotaFiscalDestinatarioLogradouro);
         n821NotaFiscalDestinatarioLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A821NotaFiscalDestinatarioLogradouro)) ? true : false);
         A822NotaFiscalDestinatarioLogNum = "";
         n822NotaFiscalDestinatarioLogNum = false;
         AssignAttri("", false, "A822NotaFiscalDestinatarioLogNum", A822NotaFiscalDestinatarioLogNum);
         n822NotaFiscalDestinatarioLogNum = (String.IsNullOrEmpty(StringUtil.RTrim( A822NotaFiscalDestinatarioLogNum)) ? true : false);
         A823NotaFiscalDestinatarioComplemento = "";
         n823NotaFiscalDestinatarioComplemento = false;
         AssignAttri("", false, "A823NotaFiscalDestinatarioComplemento", A823NotaFiscalDestinatarioComplemento);
         n823NotaFiscalDestinatarioComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A823NotaFiscalDestinatarioComplemento)) ? true : false);
         A824NotaFiscalDestinatarioBairro = "";
         n824NotaFiscalDestinatarioBairro = false;
         AssignAttri("", false, "A824NotaFiscalDestinatarioBairro", A824NotaFiscalDestinatarioBairro);
         n824NotaFiscalDestinatarioBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A824NotaFiscalDestinatarioBairro)) ? true : false);
         A825NotaFiscalDestinatarioMunicipio = "";
         n825NotaFiscalDestinatarioMunicipio = false;
         AssignAttri("", false, "A825NotaFiscalDestinatarioMunicipio", A825NotaFiscalDestinatarioMunicipio);
         n825NotaFiscalDestinatarioMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A825NotaFiscalDestinatarioMunicipio)) ? true : false);
         A826NotaFiscalDestinatarioUF = "";
         n826NotaFiscalDestinatarioUF = false;
         AssignAttri("", false, "A826NotaFiscalDestinatarioUF", A826NotaFiscalDestinatarioUF);
         n826NotaFiscalDestinatarioUF = (String.IsNullOrEmpty(StringUtil.RTrim( A826NotaFiscalDestinatarioUF)) ? true : false);
         A827NotaFiscalDestinatarioCEP = "";
         n827NotaFiscalDestinatarioCEP = false;
         AssignAttri("", false, "A827NotaFiscalDestinatarioCEP", A827NotaFiscalDestinatarioCEP);
         n827NotaFiscalDestinatarioCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A827NotaFiscalDestinatarioCEP)) ? true : false);
         A828NotaFiscalDestinatarioPais = "";
         n828NotaFiscalDestinatarioPais = false;
         AssignAttri("", false, "A828NotaFiscalDestinatarioPais", A828NotaFiscalDestinatarioPais);
         n828NotaFiscalDestinatarioPais = (String.IsNullOrEmpty(StringUtil.RTrim( A828NotaFiscalDestinatarioPais)) ? true : false);
         A829NotaFiscalDestinatarioFone = "";
         n829NotaFiscalDestinatarioFone = false;
         AssignAttri("", false, "A829NotaFiscalDestinatarioFone", A829NotaFiscalDestinatarioFone);
         n829NotaFiscalDestinatarioFone = (String.IsNullOrEmpty(StringUtil.RTrim( A829NotaFiscalDestinatarioFone)) ? true : false);
         Z795NotaFiscalUF = 0;
         Z796NotaFiscalNatureza = "";
         Z797NotaFiscalMod = "";
         Z798NotaFiscalSerie = "";
         Z799NotaFiscalNumero = "";
         Z800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         Z801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         Z802NotaFiscalTipo = "";
         Z803NotaFiscalMunicipio = "";
         Z804NotaFiscalTipoEmissao = "";
         Z805NotaFiscalAmbiente = 0;
         Z806NotaFiscalFinalidades = "";
         Z818NotaFiscaEmitentelDocumento = "";
         Z808NotaFiscalEmitenteNome = "";
         Z809NotaFiscalEmitenteLogradouro = "";
         Z810NotaFiscalEmitenteLogNum = "";
         Z811NotaFiscalEmitenteComplemento = "";
         Z812NotaFiscalEmitenteBairro = "";
         Z813NotaFiscalEmitenteMunicipio = "";
         Z814NotaFiscalEmitenteUF = "";
         Z815NotaFiscalEmitenteCEP = "";
         Z816NotaFiscalEmitentePais = "";
         Z817NotaFiscalEmitenteTelefone = "";
         Z819NotaFiscalEmitenteIE = "";
         Z820NotaFiscalDestinatarioDocumento = "";
         Z852NotaFiscalDestinatarioNome = "";
         Z821NotaFiscalDestinatarioLogradouro = "";
         Z822NotaFiscalDestinatarioLogNum = "";
         Z823NotaFiscalDestinatarioComplemento = "";
         Z824NotaFiscalDestinatarioBairro = "";
         Z825NotaFiscalDestinatarioMunicipio = "";
         Z826NotaFiscalDestinatarioUF = "";
         Z827NotaFiscalDestinatarioCEP = "";
         Z828NotaFiscalDestinatarioPais = "";
         Z829NotaFiscalDestinatarioFone = "";
         Z168ClienteId = 0;
         Z889NotaFiscalDestinatarioClienteId = 0;
      }

      protected void InitAll2N93( )
      {
         A794NotaFiscalId = Guid.NewGuid( );
         n794NotaFiscalId = false;
         AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         InitializeNonKey2N93( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101921390", true, true);
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
         context.AddJavascriptSource("notafiscal.js", "?20256101921391", false, true);
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
         edtNotaFiscalId_Internalname = "NOTAFISCALID";
         edtClienteId_Internalname = "CLIENTEID";
         cmbNotaFiscalUF_Internalname = "NOTAFISCALUF";
         edtNotaFiscalValorTotal_F_Internalname = "NOTAFISCALVALORTOTAL_F";
         edtNotaFiscalValorTotalVendido_F_Internalname = "NOTAFISCALVALORTOTALVENDIDO_F";
         edtNotaFiscalSaldo_F_Internalname = "NOTAFISCALSALDO_F";
         edtNotaFiscalQuantidadeDeItens_F_Internalname = "NOTAFISCALQUANTIDADEDEITENS_F";
         edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname = "NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F";
         edtNotaFiscalQuantidadeResumo_F_Internalname = "NOTAFISCALQUANTIDADERESUMO_F";
         edtNotaFiscalValorFormatado_F_Internalname = "NOTAFISCALVALORFORMATADO_F";
         edtNotaFiscalValorVendidoFormatado_F_Internalname = "NOTAFISCALVALORVENDIDOFORMATADO_F";
         edtNotaFiscalSaldoFormatado_F_Internalname = "NOTAFISCALSALDOFORMATADO_F";
         cmbNotaFiscalStatus_Internalname = "NOTAFISCALSTATUS";
         edtNotaFiscalNatureza_Internalname = "NOTAFISCALNATUREZA";
         edtNotaFiscalMod_Internalname = "NOTAFISCALMOD";
         edtNotaFiscalSerie_Internalname = "NOTAFISCALSERIE";
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO";
         edtNotaFiscalDataEmissao_Internalname = "NOTAFISCALDATAEMISSAO";
         edtNotaFiscalDataSaida_Internalname = "NOTAFISCALDATASAIDA";
         cmbNotaFiscalTipo_Internalname = "NOTAFISCALTIPO";
         edtNotaFiscalMunicipio_Internalname = "NOTAFISCALMUNICIPIO";
         cmbNotaFiscalTipoEmissao_Internalname = "NOTAFISCALTIPOEMISSAO";
         cmbNotaFiscalAmbiente_Internalname = "NOTAFISCALAMBIENTE";
         cmbNotaFiscalFinalidades_Internalname = "NOTAFISCALFINALIDADES";
         edtNotaFiscaEmitentelDocumento_Internalname = "NOTAFISCAEMITENTELDOCUMENTO";
         edtNotaFiscalEmitenteNome_Internalname = "NOTAFISCALEMITENTENOME";
         edtNotaFiscalEmitenteLogradouro_Internalname = "NOTAFISCALEMITENTELOGRADOURO";
         edtNotaFiscalEmitenteLogNum_Internalname = "NOTAFISCALEMITENTELOGNUM";
         edtNotaFiscalEmitenteComplemento_Internalname = "NOTAFISCALEMITENTECOMPLEMENTO";
         edtNotaFiscalEmitenteBairro_Internalname = "NOTAFISCALEMITENTEBAIRRO";
         edtNotaFiscalEmitenteMunicipio_Internalname = "NOTAFISCALEMITENTEMUNICIPIO";
         edtNotaFiscalEmitenteUF_Internalname = "NOTAFISCALEMITENTEUF";
         edtNotaFiscalEmitenteCEP_Internalname = "NOTAFISCALEMITENTECEP";
         edtNotaFiscalEmitentePais_Internalname = "NOTAFISCALEMITENTEPAIS";
         edtNotaFiscalEmitenteTelefone_Internalname = "NOTAFISCALEMITENTETELEFONE";
         edtNotaFiscalEmitenteIE_Internalname = "NOTAFISCALEMITENTEIE";
         edtNotaFiscalDestinatarioClienteId_Internalname = "NOTAFISCALDESTINATARIOCLIENTEID";
         edtNotaFiscalDestinatarioDocumento_Internalname = "NOTAFISCALDESTINATARIODOCUMENTO";
         edtNotaFiscalDestinatarioNome_Internalname = "NOTAFISCALDESTINATARIONOME";
         edtNotaFiscalDestinatarioLogradouro_Internalname = "NOTAFISCALDESTINATARIOLOGRADOURO";
         edtNotaFiscalDestinatarioLogNum_Internalname = "NOTAFISCALDESTINATARIOLOGNUM";
         edtNotaFiscalDestinatarioComplemento_Internalname = "NOTAFISCALDESTINATARIOCOMPLEMENTO";
         edtNotaFiscalDestinatarioBairro_Internalname = "NOTAFISCALDESTINATARIOBAIRRO";
         edtNotaFiscalDestinatarioMunicipio_Internalname = "NOTAFISCALDESTINATARIOMUNICIPIO";
         edtNotaFiscalDestinatarioUF_Internalname = "NOTAFISCALDESTINATARIOUF";
         edtNotaFiscalDestinatarioCEP_Internalname = "NOTAFISCALDESTINATARIOCEP";
         edtNotaFiscalDestinatarioPais_Internalname = "NOTAFISCALDESTINATARIOPAIS";
         edtNotaFiscalDestinatarioFone_Internalname = "NOTAFISCALDESTINATARIOFONE";
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
         Form.Caption = "Nota Fiscal";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNotaFiscalDestinatarioFone_Jsonclick = "";
         edtNotaFiscalDestinatarioFone_Enabled = 1;
         edtNotaFiscalDestinatarioPais_Jsonclick = "";
         edtNotaFiscalDestinatarioPais_Enabled = 1;
         edtNotaFiscalDestinatarioCEP_Jsonclick = "";
         edtNotaFiscalDestinatarioCEP_Enabled = 1;
         edtNotaFiscalDestinatarioUF_Jsonclick = "";
         edtNotaFiscalDestinatarioUF_Enabled = 1;
         edtNotaFiscalDestinatarioMunicipio_Jsonclick = "";
         edtNotaFiscalDestinatarioMunicipio_Enabled = 1;
         edtNotaFiscalDestinatarioBairro_Jsonclick = "";
         edtNotaFiscalDestinatarioBairro_Enabled = 1;
         edtNotaFiscalDestinatarioComplemento_Jsonclick = "";
         edtNotaFiscalDestinatarioComplemento_Enabled = 1;
         edtNotaFiscalDestinatarioLogNum_Jsonclick = "";
         edtNotaFiscalDestinatarioLogNum_Enabled = 1;
         edtNotaFiscalDestinatarioLogradouro_Jsonclick = "";
         edtNotaFiscalDestinatarioLogradouro_Enabled = 1;
         edtNotaFiscalDestinatarioNome_Jsonclick = "";
         edtNotaFiscalDestinatarioNome_Enabled = 1;
         edtNotaFiscalDestinatarioDocumento_Jsonclick = "";
         edtNotaFiscalDestinatarioDocumento_Enabled = 1;
         edtNotaFiscalDestinatarioClienteId_Jsonclick = "";
         edtNotaFiscalDestinatarioClienteId_Enabled = 1;
         edtNotaFiscalEmitenteIE_Jsonclick = "";
         edtNotaFiscalEmitenteIE_Enabled = 1;
         edtNotaFiscalEmitenteTelefone_Jsonclick = "";
         edtNotaFiscalEmitenteTelefone_Enabled = 1;
         edtNotaFiscalEmitentePais_Jsonclick = "";
         edtNotaFiscalEmitentePais_Enabled = 1;
         edtNotaFiscalEmitenteCEP_Jsonclick = "";
         edtNotaFiscalEmitenteCEP_Enabled = 1;
         edtNotaFiscalEmitenteUF_Jsonclick = "";
         edtNotaFiscalEmitenteUF_Enabled = 1;
         edtNotaFiscalEmitenteMunicipio_Jsonclick = "";
         edtNotaFiscalEmitenteMunicipio_Enabled = 1;
         edtNotaFiscalEmitenteBairro_Jsonclick = "";
         edtNotaFiscalEmitenteBairro_Enabled = 1;
         edtNotaFiscalEmitenteComplemento_Jsonclick = "";
         edtNotaFiscalEmitenteComplemento_Enabled = 1;
         edtNotaFiscalEmitenteLogNum_Jsonclick = "";
         edtNotaFiscalEmitenteLogNum_Enabled = 1;
         edtNotaFiscalEmitenteLogradouro_Jsonclick = "";
         edtNotaFiscalEmitenteLogradouro_Enabled = 1;
         edtNotaFiscalEmitenteNome_Jsonclick = "";
         edtNotaFiscalEmitenteNome_Enabled = 1;
         edtNotaFiscaEmitentelDocumento_Jsonclick = "";
         edtNotaFiscaEmitentelDocumento_Enabled = 1;
         cmbNotaFiscalFinalidades_Jsonclick = "";
         cmbNotaFiscalFinalidades.Enabled = 1;
         cmbNotaFiscalAmbiente_Jsonclick = "";
         cmbNotaFiscalAmbiente.Enabled = 1;
         cmbNotaFiscalTipoEmissao_Jsonclick = "";
         cmbNotaFiscalTipoEmissao.Enabled = 1;
         edtNotaFiscalMunicipio_Jsonclick = "";
         edtNotaFiscalMunicipio_Enabled = 1;
         cmbNotaFiscalTipo_Jsonclick = "";
         cmbNotaFiscalTipo.Enabled = 1;
         edtNotaFiscalDataSaida_Jsonclick = "";
         edtNotaFiscalDataSaida_Enabled = 1;
         edtNotaFiscalDataEmissao_Jsonclick = "";
         edtNotaFiscalDataEmissao_Enabled = 1;
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalNumero_Enabled = 1;
         edtNotaFiscalSerie_Jsonclick = "";
         edtNotaFiscalSerie_Enabled = 1;
         edtNotaFiscalMod_Jsonclick = "";
         edtNotaFiscalMod_Enabled = 1;
         edtNotaFiscalNatureza_Enabled = 1;
         cmbNotaFiscalStatus_Jsonclick = "";
         cmbNotaFiscalStatus.Enabled = 0;
         edtNotaFiscalSaldoFormatado_F_Jsonclick = "";
         edtNotaFiscalSaldoFormatado_F_Enabled = 0;
         edtNotaFiscalValorVendidoFormatado_F_Jsonclick = "";
         edtNotaFiscalValorVendidoFormatado_F_Enabled = 0;
         edtNotaFiscalValorFormatado_F_Jsonclick = "";
         edtNotaFiscalValorFormatado_F_Enabled = 0;
         edtNotaFiscalQuantidadeResumo_F_Jsonclick = "";
         edtNotaFiscalQuantidadeResumo_F_Enabled = 0;
         edtNotaFiscalQuantidadeDeItensVendidos_F_Jsonclick = "";
         edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled = 0;
         edtNotaFiscalQuantidadeDeItens_F_Jsonclick = "";
         edtNotaFiscalQuantidadeDeItens_F_Enabled = 0;
         edtNotaFiscalSaldo_F_Jsonclick = "";
         edtNotaFiscalSaldo_F_Enabled = 0;
         edtNotaFiscalValorTotalVendido_F_Jsonclick = "";
         edtNotaFiscalValorTotalVendido_F_Enabled = 0;
         edtNotaFiscalValorTotal_F_Jsonclick = "";
         edtNotaFiscalValorTotal_F_Enabled = 0;
         cmbNotaFiscalUF_Jsonclick = "";
         cmbNotaFiscalUF.Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtNotaFiscalId_Jsonclick = "";
         edtNotaFiscalId_Enabled = 1;
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
         cmbNotaFiscalUF.Name = "NOTAFISCALUF";
         cmbNotaFiscalUF.WebTags = "";
         cmbNotaFiscalUF.addItem("11", "Rondônia (RO)", 0);
         cmbNotaFiscalUF.addItem("12", "Acre (AC)", 0);
         cmbNotaFiscalUF.addItem("13", "Amazonas (AM)", 0);
         cmbNotaFiscalUF.addItem("14", "Roraima (RR)", 0);
         cmbNotaFiscalUF.addItem("15", "Pará (PA)", 0);
         cmbNotaFiscalUF.addItem("16", "Amapá (AP)", 0);
         cmbNotaFiscalUF.addItem("17", "Tocantins (TO)", 0);
         cmbNotaFiscalUF.addItem("21", "Maranhão (MA)", 0);
         cmbNotaFiscalUF.addItem("22", "Piauí (PI)", 0);
         cmbNotaFiscalUF.addItem("23", "Ceará (CE)", 0);
         cmbNotaFiscalUF.addItem("24", "Rio Grande do Norte (RN)", 0);
         cmbNotaFiscalUF.addItem("25", "Paraíba (PB)", 0);
         cmbNotaFiscalUF.addItem("26", "Pernambuco (PE)", 0);
         cmbNotaFiscalUF.addItem("27", "Alagoas (AL)", 0);
         cmbNotaFiscalUF.addItem("28", "Sergipe (SE)", 0);
         cmbNotaFiscalUF.addItem("29", "Bahia (BA)", 0);
         cmbNotaFiscalUF.addItem("31", "Minas Gerais (MG)", 0);
         cmbNotaFiscalUF.addItem("32", "Espírito Santo (ES)", 0);
         cmbNotaFiscalUF.addItem("33", "Rio de Janeiro (RJ)", 0);
         cmbNotaFiscalUF.addItem("35", "São Paulo (SP)", 0);
         cmbNotaFiscalUF.addItem("41", "Paraná (PR)", 0);
         cmbNotaFiscalUF.addItem("42", "Santa Catarina (SC)", 0);
         cmbNotaFiscalUF.addItem("43", "Rio Grande do Sul (RS)", 0);
         cmbNotaFiscalUF.addItem("50", "Mato Grosso do Sul (MS)", 0);
         cmbNotaFiscalUF.addItem("51", "Mato Grosso (MT)", 0);
         cmbNotaFiscalUF.addItem("52", "Goiás (GO)", 0);
         cmbNotaFiscalUF.addItem("53", "Distrito Federal (DF)", 0);
         if ( cmbNotaFiscalUF.ItemCount > 0 )
         {
            A795NotaFiscalUF = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalUF.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n795NotaFiscalUF = false;
            AssignAttri("", false, "A795NotaFiscalUF", ((0==A795NotaFiscalUF)&&IsIns( )||n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
         }
         cmbNotaFiscalStatus.Name = "NOTAFISCALSTATUS";
         cmbNotaFiscalStatus.WebTags = "";
         cmbNotaFiscalStatus.addItem("Parcial", "Parcial", 0);
         cmbNotaFiscalStatus.addItem("Completo", "Completo", 0);
         if ( cmbNotaFiscalStatus.ItemCount > 0 )
         {
            A880NotaFiscalStatus = cmbNotaFiscalStatus.getValidValue(A880NotaFiscalStatus);
            AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
         }
         cmbNotaFiscalTipo.Name = "NOTAFISCALTIPO";
         cmbNotaFiscalTipo.WebTags = "";
         cmbNotaFiscalTipo.addItem("0", "Entrada", 0);
         cmbNotaFiscalTipo.addItem("1", "Saída", 0);
         if ( cmbNotaFiscalTipo.ItemCount > 0 )
         {
            A802NotaFiscalTipo = cmbNotaFiscalTipo.getValidValue(A802NotaFiscalTipo);
            n802NotaFiscalTipo = false;
            AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
         }
         cmbNotaFiscalTipoEmissao.Name = "NOTAFISCALTIPOEMISSAO";
         cmbNotaFiscalTipoEmissao.WebTags = "";
         cmbNotaFiscalTipoEmissao.addItem("1", "Normal", 0);
         cmbNotaFiscalTipoEmissao.addItem("2", "Contingência FS", 0);
         cmbNotaFiscalTipoEmissao.addItem("9", "Contingência off-line NFC-e, etc.", 0);
         if ( cmbNotaFiscalTipoEmissao.ItemCount > 0 )
         {
            A804NotaFiscalTipoEmissao = cmbNotaFiscalTipoEmissao.getValidValue(A804NotaFiscalTipoEmissao);
            n804NotaFiscalTipoEmissao = false;
            AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
         }
         cmbNotaFiscalAmbiente.Name = "NOTAFISCALAMBIENTE";
         cmbNotaFiscalAmbiente.WebTags = "";
         cmbNotaFiscalAmbiente.addItem("1", "Produção", 0);
         cmbNotaFiscalAmbiente.addItem("2", "Homologação", 0);
         if ( cmbNotaFiscalAmbiente.ItemCount > 0 )
         {
            A805NotaFiscalAmbiente = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalAmbiente.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n805NotaFiscalAmbiente = false;
            AssignAttri("", false, "A805NotaFiscalAmbiente", ((0==A805NotaFiscalAmbiente)&&IsIns( )||n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
         }
         cmbNotaFiscalFinalidades.Name = "NOTAFISCALFINALIDADES";
         cmbNotaFiscalFinalidades.WebTags = "";
         cmbNotaFiscalFinalidades.addItem("1", "Nf-e normal", 0);
         cmbNotaFiscalFinalidades.addItem("2", "Complementar", 0);
         cmbNotaFiscalFinalidades.addItem("3", "Ajuste", 0);
         cmbNotaFiscalFinalidades.addItem("4", "Devolução", 0);
         if ( cmbNotaFiscalFinalidades.ItemCount > 0 )
         {
            A806NotaFiscalFinalidades = cmbNotaFiscalFinalidades.getValidValue(A806NotaFiscalFinalidades);
            n806NotaFiscalFinalidades = false;
            AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtClienteId_Internalname;
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

      public void Valid_Notafiscalid( )
      {
         A880NotaFiscalStatus = cmbNotaFiscalStatus.CurrentValue;
         cmbNotaFiscalStatus.CurrentValue = A880NotaFiscalStatus;
         n806NotaFiscalFinalidades = false;
         A806NotaFiscalFinalidades = cmbNotaFiscalFinalidades.CurrentValue;
         n806NotaFiscalFinalidades = false;
         cmbNotaFiscalFinalidades.CurrentValue = A806NotaFiscalFinalidades;
         A805NotaFiscalAmbiente = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalAmbiente.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n805NotaFiscalAmbiente = false;
         cmbNotaFiscalAmbiente.CurrentValue = StringUtil.LTrimStr( (decimal)(A805NotaFiscalAmbiente), 4, 0);
         n804NotaFiscalTipoEmissao = false;
         A804NotaFiscalTipoEmissao = cmbNotaFiscalTipoEmissao.CurrentValue;
         n804NotaFiscalTipoEmissao = false;
         cmbNotaFiscalTipoEmissao.CurrentValue = A804NotaFiscalTipoEmissao;
         n802NotaFiscalTipo = false;
         A802NotaFiscalTipo = cmbNotaFiscalTipo.CurrentValue;
         n802NotaFiscalTipo = false;
         cmbNotaFiscalTipo.CurrentValue = A802NotaFiscalTipo;
         A795NotaFiscalUF = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalUF.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n795NotaFiscalUF = false;
         cmbNotaFiscalUF.CurrentValue = StringUtil.LTrimStr( (decimal)(A795NotaFiscalUF), 4, 0);
         n794NotaFiscalId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002N26 */
         pr_default.execute(17, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A874NotaFiscalValorTotal_F = T002N26_A874NotaFiscalValorTotal_F[0];
            A877NotaFiscalQuantidadeDeItens_F = T002N26_A877NotaFiscalQuantidadeDeItens_F[0];
         }
         else
         {
            A874NotaFiscalValorTotal_F = 0;
            A877NotaFiscalQuantidadeDeItens_F = 0;
         }
         pr_default.close(17);
         A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
         /* Using cursor T002N28 */
         pr_default.execute(18, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A875NotaFiscalValorTotalVendido_F = T002N28_A875NotaFiscalValorTotalVendido_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = T002N28_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
         }
         else
         {
            A875NotaFiscalValorTotalVendido_F = 0;
            A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
         }
         pr_default.close(18);
         A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
         A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
         A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
         A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
         cmbNotaFiscalStatus.CurrentValue = A880NotaFiscalStatus;
         A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
         dynload_actions( ) ;
         if ( cmbNotaFiscalUF.ItemCount > 0 )
         {
            A795NotaFiscalUF = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalUF.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n795NotaFiscalUF = false;
            cmbNotaFiscalUF.CurrentValue = StringUtil.LTrimStr( (decimal)(A795NotaFiscalUF), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalUF.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0));
         }
         if ( cmbNotaFiscalTipo.ItemCount > 0 )
         {
            A802NotaFiscalTipo = cmbNotaFiscalTipo.getValidValue(A802NotaFiscalTipo);
            n802NotaFiscalTipo = false;
            cmbNotaFiscalTipo.CurrentValue = A802NotaFiscalTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalTipo.CurrentValue = StringUtil.RTrim( A802NotaFiscalTipo);
         }
         if ( cmbNotaFiscalTipoEmissao.ItemCount > 0 )
         {
            A804NotaFiscalTipoEmissao = cmbNotaFiscalTipoEmissao.getValidValue(A804NotaFiscalTipoEmissao);
            n804NotaFiscalTipoEmissao = false;
            cmbNotaFiscalTipoEmissao.CurrentValue = A804NotaFiscalTipoEmissao;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalTipoEmissao.CurrentValue = StringUtil.RTrim( A804NotaFiscalTipoEmissao);
         }
         if ( cmbNotaFiscalAmbiente.ItemCount > 0 )
         {
            A805NotaFiscalAmbiente = (short)(Math.Round(NumberUtil.Val( cmbNotaFiscalAmbiente.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n805NotaFiscalAmbiente = false;
            cmbNotaFiscalAmbiente.CurrentValue = StringUtil.LTrimStr( (decimal)(A805NotaFiscalAmbiente), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalAmbiente.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0));
         }
         if ( cmbNotaFiscalFinalidades.ItemCount > 0 )
         {
            A806NotaFiscalFinalidades = cmbNotaFiscalFinalidades.getValidValue(A806NotaFiscalFinalidades);
            n806NotaFiscalFinalidades = false;
            cmbNotaFiscalFinalidades.CurrentValue = A806NotaFiscalFinalidades;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalFinalidades.CurrentValue = StringUtil.RTrim( A806NotaFiscalFinalidades);
         }
         if ( cmbNotaFiscalStatus.ItemCount > 0 )
         {
            A880NotaFiscalStatus = cmbNotaFiscalStatus.getValidValue(A880NotaFiscalStatus);
            cmbNotaFiscalStatus.CurrentValue = A880NotaFiscalStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotaFiscalStatus.CurrentValue = StringUtil.RTrim( A880NotaFiscalStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A795NotaFiscalUF", ((0==A795NotaFiscalUF)&&IsIns( )||n795NotaFiscalUF ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A795NotaFiscalUF), 4, 0, ".", ""))));
         cmbNotaFiscalUF.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A795NotaFiscalUF), 4, 0));
         AssignProp("", false, cmbNotaFiscalUF_Internalname, "Values", cmbNotaFiscalUF.ToJavascriptSource(), true);
         AssignAttri("", false, "A796NotaFiscalNatureza", A796NotaFiscalNatureza);
         AssignAttri("", false, "A797NotaFiscalMod", A797NotaFiscalMod);
         AssignAttri("", false, "A798NotaFiscalSerie", A798NotaFiscalSerie);
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
         AssignAttri("", false, "A800NotaFiscalDataEmissao", context.localUtil.TToC( A800NotaFiscalDataEmissao, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A801NotaFiscalDataSaida", context.localUtil.TToC( A801NotaFiscalDataSaida, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A802NotaFiscalTipo", A802NotaFiscalTipo);
         cmbNotaFiscalTipo.CurrentValue = StringUtil.RTrim( A802NotaFiscalTipo);
         AssignProp("", false, cmbNotaFiscalTipo_Internalname, "Values", cmbNotaFiscalTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A803NotaFiscalMunicipio", A803NotaFiscalMunicipio);
         AssignAttri("", false, "A804NotaFiscalTipoEmissao", A804NotaFiscalTipoEmissao);
         cmbNotaFiscalTipoEmissao.CurrentValue = StringUtil.RTrim( A804NotaFiscalTipoEmissao);
         AssignProp("", false, cmbNotaFiscalTipoEmissao_Internalname, "Values", cmbNotaFiscalTipoEmissao.ToJavascriptSource(), true);
         AssignAttri("", false, "A805NotaFiscalAmbiente", ((0==A805NotaFiscalAmbiente)&&IsIns( )||n805NotaFiscalAmbiente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A805NotaFiscalAmbiente), 4, 0, ".", ""))));
         cmbNotaFiscalAmbiente.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A805NotaFiscalAmbiente), 4, 0));
         AssignProp("", false, cmbNotaFiscalAmbiente_Internalname, "Values", cmbNotaFiscalAmbiente.ToJavascriptSource(), true);
         AssignAttri("", false, "A806NotaFiscalFinalidades", A806NotaFiscalFinalidades);
         cmbNotaFiscalFinalidades.CurrentValue = StringUtil.RTrim( A806NotaFiscalFinalidades);
         AssignProp("", false, cmbNotaFiscalFinalidades_Internalname, "Values", cmbNotaFiscalFinalidades.ToJavascriptSource(), true);
         AssignAttri("", false, "A818NotaFiscaEmitentelDocumento", A818NotaFiscaEmitentelDocumento);
         AssignAttri("", false, "A808NotaFiscalEmitenteNome", A808NotaFiscalEmitenteNome);
         AssignAttri("", false, "A809NotaFiscalEmitenteLogradouro", A809NotaFiscalEmitenteLogradouro);
         AssignAttri("", false, "A810NotaFiscalEmitenteLogNum", A810NotaFiscalEmitenteLogNum);
         AssignAttri("", false, "A811NotaFiscalEmitenteComplemento", A811NotaFiscalEmitenteComplemento);
         AssignAttri("", false, "A812NotaFiscalEmitenteBairro", A812NotaFiscalEmitenteBairro);
         AssignAttri("", false, "A813NotaFiscalEmitenteMunicipio", A813NotaFiscalEmitenteMunicipio);
         AssignAttri("", false, "A814NotaFiscalEmitenteUF", A814NotaFiscalEmitenteUF);
         AssignAttri("", false, "A815NotaFiscalEmitenteCEP", A815NotaFiscalEmitenteCEP);
         AssignAttri("", false, "A816NotaFiscalEmitentePais", A816NotaFiscalEmitentePais);
         AssignAttri("", false, "A817NotaFiscalEmitenteTelefone", A817NotaFiscalEmitenteTelefone);
         AssignAttri("", false, "A819NotaFiscalEmitenteIE", A819NotaFiscalEmitenteIE);
         AssignAttri("", false, "A889NotaFiscalDestinatarioClienteId", ((0==A889NotaFiscalDestinatarioClienteId)&&IsIns( )||n889NotaFiscalDestinatarioClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A889NotaFiscalDestinatarioClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A820NotaFiscalDestinatarioDocumento", A820NotaFiscalDestinatarioDocumento);
         AssignAttri("", false, "A852NotaFiscalDestinatarioNome", A852NotaFiscalDestinatarioNome);
         AssignAttri("", false, "A821NotaFiscalDestinatarioLogradouro", A821NotaFiscalDestinatarioLogradouro);
         AssignAttri("", false, "A822NotaFiscalDestinatarioLogNum", A822NotaFiscalDestinatarioLogNum);
         AssignAttri("", false, "A823NotaFiscalDestinatarioComplemento", A823NotaFiscalDestinatarioComplemento);
         AssignAttri("", false, "A824NotaFiscalDestinatarioBairro", A824NotaFiscalDestinatarioBairro);
         AssignAttri("", false, "A825NotaFiscalDestinatarioMunicipio", A825NotaFiscalDestinatarioMunicipio);
         AssignAttri("", false, "A826NotaFiscalDestinatarioUF", A826NotaFiscalDestinatarioUF);
         AssignAttri("", false, "A827NotaFiscalDestinatarioCEP", A827NotaFiscalDestinatarioCEP);
         AssignAttri("", false, "A828NotaFiscalDestinatarioPais", A828NotaFiscalDestinatarioPais);
         AssignAttri("", false, "A829NotaFiscalDestinatarioFone", A829NotaFiscalDestinatarioFone);
         AssignAttri("", false, "A874NotaFiscalValorTotal_F", StringUtil.LTrim( StringUtil.NToC( A874NotaFiscalValorTotal_F, 18, 2, ".", "")));
         AssignAttri("", false, "A877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0, ".", "")));
         AssignAttri("", false, "A881NotaFiscalValorFormatado_F", A881NotaFiscalValorFormatado_F);
         AssignAttri("", false, "A875NotaFiscalValorTotalVendido_F", StringUtil.LTrim( StringUtil.NToC( A875NotaFiscalValorTotalVendido_F, 18, 2, ".", "")));
         AssignAttri("", false, "A878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0, ".", "")));
         AssignAttri("", false, "A876NotaFiscalSaldo_F", StringUtil.LTrim( StringUtil.NToC( A876NotaFiscalSaldo_F, 18, 2, ".", "")));
         AssignAttri("", false, "A883NotaFiscalSaldoFormatado_F", A883NotaFiscalSaldoFormatado_F);
         AssignAttri("", false, "A882NotaFiscalValorVendidoFormatado_F", A882NotaFiscalValorVendidoFormatado_F);
         AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
         cmbNotaFiscalStatus.CurrentValue = StringUtil.RTrim( A880NotaFiscalStatus);
         AssignProp("", false, cmbNotaFiscalStatus_Internalname, "Values", cmbNotaFiscalStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z794NotaFiscalId", Z794NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z795NotaFiscalUF", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z795NotaFiscalUF), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z796NotaFiscalNatureza", Z796NotaFiscalNatureza);
         GxWebStd.gx_hidden_field( context, "Z797NotaFiscalMod", Z797NotaFiscalMod);
         GxWebStd.gx_hidden_field( context, "Z798NotaFiscalSerie", Z798NotaFiscalSerie);
         GxWebStd.gx_hidden_field( context, "Z799NotaFiscalNumero", Z799NotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, "Z800NotaFiscalDataEmissao", context.localUtil.TToC( Z800NotaFiscalDataEmissao, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z801NotaFiscalDataSaida", context.localUtil.TToC( Z801NotaFiscalDataSaida, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z802NotaFiscalTipo", Z802NotaFiscalTipo);
         GxWebStd.gx_hidden_field( context, "Z803NotaFiscalMunicipio", Z803NotaFiscalMunicipio);
         GxWebStd.gx_hidden_field( context, "Z804NotaFiscalTipoEmissao", Z804NotaFiscalTipoEmissao);
         GxWebStd.gx_hidden_field( context, "Z805NotaFiscalAmbiente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z805NotaFiscalAmbiente), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z806NotaFiscalFinalidades", Z806NotaFiscalFinalidades);
         GxWebStd.gx_hidden_field( context, "Z818NotaFiscaEmitentelDocumento", Z818NotaFiscaEmitentelDocumento);
         GxWebStd.gx_hidden_field( context, "Z808NotaFiscalEmitenteNome", Z808NotaFiscalEmitenteNome);
         GxWebStd.gx_hidden_field( context, "Z809NotaFiscalEmitenteLogradouro", Z809NotaFiscalEmitenteLogradouro);
         GxWebStd.gx_hidden_field( context, "Z810NotaFiscalEmitenteLogNum", Z810NotaFiscalEmitenteLogNum);
         GxWebStd.gx_hidden_field( context, "Z811NotaFiscalEmitenteComplemento", Z811NotaFiscalEmitenteComplemento);
         GxWebStd.gx_hidden_field( context, "Z812NotaFiscalEmitenteBairro", Z812NotaFiscalEmitenteBairro);
         GxWebStd.gx_hidden_field( context, "Z813NotaFiscalEmitenteMunicipio", Z813NotaFiscalEmitenteMunicipio);
         GxWebStd.gx_hidden_field( context, "Z814NotaFiscalEmitenteUF", Z814NotaFiscalEmitenteUF);
         GxWebStd.gx_hidden_field( context, "Z815NotaFiscalEmitenteCEP", Z815NotaFiscalEmitenteCEP);
         GxWebStd.gx_hidden_field( context, "Z816NotaFiscalEmitentePais", Z816NotaFiscalEmitentePais);
         GxWebStd.gx_hidden_field( context, "Z817NotaFiscalEmitenteTelefone", Z817NotaFiscalEmitenteTelefone);
         GxWebStd.gx_hidden_field( context, "Z819NotaFiscalEmitenteIE", Z819NotaFiscalEmitenteIE);
         GxWebStd.gx_hidden_field( context, "Z889NotaFiscalDestinatarioClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z889NotaFiscalDestinatarioClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z820NotaFiscalDestinatarioDocumento", Z820NotaFiscalDestinatarioDocumento);
         GxWebStd.gx_hidden_field( context, "Z852NotaFiscalDestinatarioNome", Z852NotaFiscalDestinatarioNome);
         GxWebStd.gx_hidden_field( context, "Z821NotaFiscalDestinatarioLogradouro", Z821NotaFiscalDestinatarioLogradouro);
         GxWebStd.gx_hidden_field( context, "Z822NotaFiscalDestinatarioLogNum", Z822NotaFiscalDestinatarioLogNum);
         GxWebStd.gx_hidden_field( context, "Z823NotaFiscalDestinatarioComplemento", Z823NotaFiscalDestinatarioComplemento);
         GxWebStd.gx_hidden_field( context, "Z824NotaFiscalDestinatarioBairro", Z824NotaFiscalDestinatarioBairro);
         GxWebStd.gx_hidden_field( context, "Z825NotaFiscalDestinatarioMunicipio", Z825NotaFiscalDestinatarioMunicipio);
         GxWebStd.gx_hidden_field( context, "Z826NotaFiscalDestinatarioUF", Z826NotaFiscalDestinatarioUF);
         GxWebStd.gx_hidden_field( context, "Z827NotaFiscalDestinatarioCEP", Z827NotaFiscalDestinatarioCEP);
         GxWebStd.gx_hidden_field( context, "Z828NotaFiscalDestinatarioPais", Z828NotaFiscalDestinatarioPais);
         GxWebStd.gx_hidden_field( context, "Z829NotaFiscalDestinatarioFone", Z829NotaFiscalDestinatarioFone);
         GxWebStd.gx_hidden_field( context, "Z874NotaFiscalValorTotal_F", StringUtil.LTrim( StringUtil.NToC( Z874NotaFiscalValorTotal_F, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z877NotaFiscalQuantidadeDeItens_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z877NotaFiscalQuantidadeDeItens_F), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z881NotaFiscalValorFormatado_F", Z881NotaFiscalValorFormatado_F);
         GxWebStd.gx_hidden_field( context, "Z875NotaFiscalValorTotalVendido_F", StringUtil.LTrim( StringUtil.NToC( Z875NotaFiscalValorTotalVendido_F, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z878NotaFiscalQuantidadeDeItensVendidos_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z876NotaFiscalSaldo_F", StringUtil.LTrim( StringUtil.NToC( Z876NotaFiscalSaldo_F, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z883NotaFiscalSaldoFormatado_F", Z883NotaFiscalSaldoFormatado_F);
         GxWebStd.gx_hidden_field( context, "Z882NotaFiscalValorVendidoFormatado_F", Z882NotaFiscalValorVendidoFormatado_F);
         GxWebStd.gx_hidden_field( context, "Z880NotaFiscalStatus", Z880NotaFiscalStatus);
         GxWebStd.gx_hidden_field( context, "Z879NotaFiscalQuantidadeResumo_F", Z879NotaFiscalQuantidadeResumo_F);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T002N32 */
         pr_default.execute(22, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Notafiscaldestinatarioclienteid( )
      {
         /* Using cursor T002N33 */
         pr_default.execute(23, new Object[] {n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A889NotaFiscalDestinatarioClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Nota Destinatario Cliente'.", "ForeignKeyNotFound", 1, "NOTAFISCALDESTINATARIOCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalDestinatarioClienteId_Internalname;
            }
         }
         pr_default.close(23);
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
         setEventMetadata("VALID_NOTAFISCALID","""{"handler":"Valid_Notafiscalid","iparms":[{"av":"cmbNotaFiscalStatus"},{"av":"A880NotaFiscalStatus","fld":"NOTAFISCALSTATUS","type":"svchar"},{"av":"cmbNotaFiscalFinalidades"},{"av":"A806NotaFiscalFinalidades","fld":"NOTAFISCALFINALIDADES","type":"svchar"},{"av":"cmbNotaFiscalAmbiente"},{"av":"A805NotaFiscalAmbiente","fld":"NOTAFISCALAMBIENTE","pic":"ZZZ9","nullAv":"n805NotaFiscalAmbiente","type":"int"},{"av":"cmbNotaFiscalTipoEmissao"},{"av":"A804NotaFiscalTipoEmissao","fld":"NOTAFISCALTIPOEMISSAO","type":"svchar"},{"av":"cmbNotaFiscalTipo"},{"av":"A802NotaFiscalTipo","fld":"NOTAFISCALTIPO","type":"svchar"},{"av":"cmbNotaFiscalUF"},{"av":"A795NotaFiscalUF","fld":"NOTAFISCALUF","pic":"ZZZ9","nullAv":"n795NotaFiscalUF","type":"int"},{"av":"A794NotaFiscalId","fld":"NOTAFISCALID","type":"guid"},{"av":"A874NotaFiscalValorTotal_F","fld":"NOTAFISCALVALORTOTAL_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A875NotaFiscalValorTotalVendido_F","fld":"NOTAFISCALVALORTOTALVENDIDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A876NotaFiscalSaldo_F","fld":"NOTAFISCALSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A878NotaFiscalQuantidadeDeItensVendidos_F","fld":"NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F","pic":"ZZZ9","type":"int"},{"av":"A877NotaFiscalQuantidadeDeItens_F","fld":"NOTAFISCALQUANTIDADEDEITENS_F","pic":"ZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_NOTAFISCALID",""","oparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"cmbNotaFiscalUF"},{"av":"A795NotaFiscalUF","fld":"NOTAFISCALUF","pic":"ZZZ9","nullAv":"n795NotaFiscalUF","type":"int"},{"av":"A796NotaFiscalNatureza","fld":"NOTAFISCALNATUREZA","type":"svchar"},{"av":"A797NotaFiscalMod","fld":"NOTAFISCALMOD","type":"svchar"},{"av":"A798NotaFiscalSerie","fld":"NOTAFISCALSERIE","type":"svchar"},{"av":"A799NotaFiscalNumero","fld":"NOTAFISCALNUMERO","type":"svchar"},{"av":"A800NotaFiscalDataEmissao","fld":"NOTAFISCALDATAEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"A801NotaFiscalDataSaida","fld":"NOTAFISCALDATASAIDA","pic":"99/99/99 99:99","type":"dtime"},{"av":"cmbNotaFiscalTipo"},{"av":"A802NotaFiscalTipo","fld":"NOTAFISCALTIPO","type":"svchar"},{"av":"A803NotaFiscalMunicipio","fld":"NOTAFISCALMUNICIPIO","type":"svchar"},{"av":"cmbNotaFiscalTipoEmissao"},{"av":"A804NotaFiscalTipoEmissao","fld":"NOTAFISCALTIPOEMISSAO","type":"svchar"},{"av":"cmbNotaFiscalAmbiente"},{"av":"A805NotaFiscalAmbiente","fld":"NOTAFISCALAMBIENTE","pic":"ZZZ9","nullAv":"n805NotaFiscalAmbiente","type":"int"},{"av":"cmbNotaFiscalFinalidades"},{"av":"A806NotaFiscalFinalidades","fld":"NOTAFISCALFINALIDADES","type":"svchar"},{"av":"A818NotaFiscaEmitentelDocumento","fld":"NOTAFISCAEMITENTELDOCUMENTO","type":"svchar"},{"av":"A808NotaFiscalEmitenteNome","fld":"NOTAFISCALEMITENTENOME","type":"svchar"},{"av":"A809NotaFiscalEmitenteLogradouro","fld":"NOTAFISCALEMITENTELOGRADOURO","type":"svchar"},{"av":"A810NotaFiscalEmitenteLogNum","fld":"NOTAFISCALEMITENTELOGNUM","type":"svchar"},{"av":"A811NotaFiscalEmitenteComplemento","fld":"NOTAFISCALEMITENTECOMPLEMENTO","type":"svchar"},{"av":"A812NotaFiscalEmitenteBairro","fld":"NOTAFISCALEMITENTEBAIRRO","type":"svchar"},{"av":"A813NotaFiscalEmitenteMunicipio","fld":"NOTAFISCALEMITENTEMUNICIPIO","type":"svchar"},{"av":"A814NotaFiscalEmitenteUF","fld":"NOTAFISCALEMITENTEUF","type":"svchar"},{"av":"A815NotaFiscalEmitenteCEP","fld":"NOTAFISCALEMITENTECEP","type":"svchar"},{"av":"A816NotaFiscalEmitentePais","fld":"NOTAFISCALEMITENTEPAIS","type":"svchar"},{"av":"A817NotaFiscalEmitenteTelefone","fld":"NOTAFISCALEMITENTETELEFONE","type":"svchar"},{"av":"A819NotaFiscalEmitenteIE","fld":"NOTAFISCALEMITENTEIE","type":"svchar"},{"av":"A889NotaFiscalDestinatarioClienteId","fld":"NOTAFISCALDESTINATARIOCLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n889NotaFiscalDestinatarioClienteId","type":"int"},{"av":"A820NotaFiscalDestinatarioDocumento","fld":"NOTAFISCALDESTINATARIODOCUMENTO","type":"svchar"},{"av":"A852NotaFiscalDestinatarioNome","fld":"NOTAFISCALDESTINATARIONOME","type":"svchar"},{"av":"A821NotaFiscalDestinatarioLogradouro","fld":"NOTAFISCALDESTINATARIOLOGRADOURO","type":"svchar"},{"av":"A822NotaFiscalDestinatarioLogNum","fld":"NOTAFISCALDESTINATARIOLOGNUM","type":"svchar"},{"av":"A823NotaFiscalDestinatarioComplemento","fld":"NOTAFISCALDESTINATARIOCOMPLEMENTO","type":"svchar"},{"av":"A824NotaFiscalDestinatarioBairro","fld":"NOTAFISCALDESTINATARIOBAIRRO","type":"svchar"},{"av":"A825NotaFiscalDestinatarioMunicipio","fld":"NOTAFISCALDESTINATARIOMUNICIPIO","type":"svchar"},{"av":"A826NotaFiscalDestinatarioUF","fld":"NOTAFISCALDESTINATARIOUF","type":"svchar"},{"av":"A827NotaFiscalDestinatarioCEP","fld":"NOTAFISCALDESTINATARIOCEP","type":"svchar"},{"av":"A828NotaFiscalDestinatarioPais","fld":"NOTAFISCALDESTINATARIOPAIS","type":"svchar"},{"av":"A829NotaFiscalDestinatarioFone","fld":"NOTAFISCALDESTINATARIOFONE","type":"svchar"},{"av":"A874NotaFiscalValorTotal_F","fld":"NOTAFISCALVALORTOTAL_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A877NotaFiscalQuantidadeDeItens_F","fld":"NOTAFISCALQUANTIDADEDEITENS_F","pic":"ZZZ9","type":"int"},{"av":"A881NotaFiscalValorFormatado_F","fld":"NOTAFISCALVALORFORMATADO_F","type":"svchar"},{"av":"A875NotaFiscalValorTotalVendido_F","fld":"NOTAFISCALVALORTOTALVENDIDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A878NotaFiscalQuantidadeDeItensVendidos_F","fld":"NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F","pic":"ZZZ9","type":"int"},{"av":"A876NotaFiscalSaldo_F","fld":"NOTAFISCALSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A883NotaFiscalSaldoFormatado_F","fld":"NOTAFISCALSALDOFORMATADO_F","type":"svchar"},{"av":"A882NotaFiscalValorVendidoFormatado_F","fld":"NOTAFISCALVALORVENDIDOFORMATADO_F","type":"svchar"},{"av":"cmbNotaFiscalStatus"},{"av":"A880NotaFiscalStatus","fld":"NOTAFISCALSTATUS","type":"svchar"},{"av":"A879NotaFiscalQuantidadeResumo_F","fld":"NOTAFISCALQUANTIDADERESUMO_F","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z794NotaFiscalId","type":"guid"},{"av":"Z168ClienteId","type":"int"},{"av":"Z795NotaFiscalUF","type":"int"},{"av":"Z796NotaFiscalNatureza","type":"svchar"},{"av":"Z797NotaFiscalMod","type":"svchar"},{"av":"Z798NotaFiscalSerie","type":"svchar"},{"av":"Z799NotaFiscalNumero","type":"svchar"},{"av":"Z800NotaFiscalDataEmissao","type":"dtime"},{"av":"Z801NotaFiscalDataSaida","type":"dtime"},{"av":"Z802NotaFiscalTipo","type":"svchar"},{"av":"Z803NotaFiscalMunicipio","type":"svchar"},{"av":"Z804NotaFiscalTipoEmissao","type":"svchar"},{"av":"Z805NotaFiscalAmbiente","type":"int"},{"av":"Z806NotaFiscalFinalidades","type":"svchar"},{"av":"Z818NotaFiscaEmitentelDocumento","type":"svchar"},{"av":"Z808NotaFiscalEmitenteNome","type":"svchar"},{"av":"Z809NotaFiscalEmitenteLogradouro","type":"svchar"},{"av":"Z810NotaFiscalEmitenteLogNum","type":"svchar"},{"av":"Z811NotaFiscalEmitenteComplemento","type":"svchar"},{"av":"Z812NotaFiscalEmitenteBairro","type":"svchar"},{"av":"Z813NotaFiscalEmitenteMunicipio","type":"svchar"},{"av":"Z814NotaFiscalEmitenteUF","type":"svchar"},{"av":"Z815NotaFiscalEmitenteCEP","type":"svchar"},{"av":"Z816NotaFiscalEmitentePais","type":"svchar"},{"av":"Z817NotaFiscalEmitenteTelefone","type":"svchar"},{"av":"Z819NotaFiscalEmitenteIE","type":"svchar"},{"av":"Z889NotaFiscalDestinatarioClienteId","type":"int"},{"av":"Z820NotaFiscalDestinatarioDocumento","type":"svchar"},{"av":"Z852NotaFiscalDestinatarioNome","type":"svchar"},{"av":"Z821NotaFiscalDestinatarioLogradouro","type":"svchar"},{"av":"Z822NotaFiscalDestinatarioLogNum","type":"svchar"},{"av":"Z823NotaFiscalDestinatarioComplemento","type":"svchar"},{"av":"Z824NotaFiscalDestinatarioBairro","type":"svchar"},{"av":"Z825NotaFiscalDestinatarioMunicipio","type":"svchar"},{"av":"Z826NotaFiscalDestinatarioUF","type":"svchar"},{"av":"Z827NotaFiscalDestinatarioCEP","type":"svchar"},{"av":"Z828NotaFiscalDestinatarioPais","type":"svchar"},{"av":"Z829NotaFiscalDestinatarioFone","type":"svchar"},{"av":"Z874NotaFiscalValorTotal_F","type":"decimal"},{"av":"Z877NotaFiscalQuantidadeDeItens_F","type":"int"},{"av":"Z881NotaFiscalValorFormatado_F","type":"svchar"},{"av":"Z875NotaFiscalValorTotalVendido_F","type":"decimal"},{"av":"Z878NotaFiscalQuantidadeDeItensVendidos_F","type":"int"},{"av":"Z876NotaFiscalSaldo_F","type":"decimal"},{"av":"Z883NotaFiscalSaldoFormatado_F","type":"svchar"},{"av":"Z882NotaFiscalValorVendidoFormatado_F","type":"svchar"},{"av":"Z880NotaFiscalStatus","type":"svchar"},{"av":"Z879NotaFiscalQuantidadeResumo_F","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("VALID_NOTAFISCALUF","""{"handler":"Valid_Notafiscaluf","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALVALORTOTAL_F","""{"handler":"Valid_Notafiscalvalortotal_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALVALORTOTALVENDIDO_F","""{"handler":"Valid_Notafiscalvalortotalvendido_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALSALDO_F","""{"handler":"Valid_Notafiscalsaldo_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALQUANTIDADEDEITENS_F","""{"handler":"Valid_Notafiscalquantidadedeitens_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALQUANTIDADEDEITENSVENDIDOS_F","""{"handler":"Valid_Notafiscalquantidadedeitensvendidos_f","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALTIPO","""{"handler":"Valid_Notafiscaltipo","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALTIPOEMISSAO","""{"handler":"Valid_Notafiscaltipoemissao","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALAMBIENTE","""{"handler":"Valid_Notafiscalambiente","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALFINALIDADES","""{"handler":"Valid_Notafiscalfinalidades","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALDESTINATARIOCLIENTEID","""{"handler":"Valid_Notafiscaldestinatarioclienteid","iparms":[{"av":"A889NotaFiscalDestinatarioClienteId","fld":"NOTAFISCALDESTINATARIOCLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n889NotaFiscalDestinatarioClienteId","type":"int"}]}""");
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
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z794NotaFiscalId = Guid.Empty;
         Z796NotaFiscalNatureza = "";
         Z797NotaFiscalMod = "";
         Z798NotaFiscalSerie = "";
         Z799NotaFiscalNumero = "";
         Z800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         Z801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         Z802NotaFiscalTipo = "";
         Z803NotaFiscalMunicipio = "";
         Z804NotaFiscalTipoEmissao = "";
         Z806NotaFiscalFinalidades = "";
         Z818NotaFiscaEmitentelDocumento = "";
         Z808NotaFiscalEmitenteNome = "";
         Z809NotaFiscalEmitenteLogradouro = "";
         Z810NotaFiscalEmitenteLogNum = "";
         Z811NotaFiscalEmitenteComplemento = "";
         Z812NotaFiscalEmitenteBairro = "";
         Z813NotaFiscalEmitenteMunicipio = "";
         Z814NotaFiscalEmitenteUF = "";
         Z815NotaFiscalEmitenteCEP = "";
         Z816NotaFiscalEmitentePais = "";
         Z817NotaFiscalEmitenteTelefone = "";
         Z819NotaFiscalEmitenteIE = "";
         Z820NotaFiscalDestinatarioDocumento = "";
         Z852NotaFiscalDestinatarioNome = "";
         Z821NotaFiscalDestinatarioLogradouro = "";
         Z822NotaFiscalDestinatarioLogNum = "";
         Z823NotaFiscalDestinatarioComplemento = "";
         Z824NotaFiscalDestinatarioBairro = "";
         Z825NotaFiscalDestinatarioMunicipio = "";
         Z826NotaFiscalDestinatarioUF = "";
         Z827NotaFiscalDestinatarioCEP = "";
         Z828NotaFiscalDestinatarioPais = "";
         Z829NotaFiscalDestinatarioFone = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A794NotaFiscalId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A880NotaFiscalStatus = "";
         A802NotaFiscalTipo = "";
         A804NotaFiscalTipoEmissao = "";
         A806NotaFiscalFinalidades = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A879NotaFiscalQuantidadeResumo_F = "";
         A881NotaFiscalValorFormatado_F = "";
         A882NotaFiscalValorVendidoFormatado_F = "";
         A883NotaFiscalSaldoFormatado_F = "";
         A796NotaFiscalNatureza = "";
         A797NotaFiscalMod = "";
         A798NotaFiscalSerie = "";
         A799NotaFiscalNumero = "";
         A800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         A801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         A803NotaFiscalMunicipio = "";
         A818NotaFiscaEmitentelDocumento = "";
         A808NotaFiscalEmitenteNome = "";
         A809NotaFiscalEmitenteLogradouro = "";
         A810NotaFiscalEmitenteLogNum = "";
         A811NotaFiscalEmitenteComplemento = "";
         A812NotaFiscalEmitenteBairro = "";
         A813NotaFiscalEmitenteMunicipio = "";
         A814NotaFiscalEmitenteUF = "";
         A815NotaFiscalEmitenteCEP = "";
         A816NotaFiscalEmitentePais = "";
         A817NotaFiscalEmitenteTelefone = "";
         A819NotaFiscalEmitenteIE = "";
         A820NotaFiscalDestinatarioDocumento = "";
         A852NotaFiscalDestinatarioNome = "";
         A821NotaFiscalDestinatarioLogradouro = "";
         A822NotaFiscalDestinatarioLogNum = "";
         A823NotaFiscalDestinatarioComplemento = "";
         A824NotaFiscalDestinatarioBairro = "";
         A825NotaFiscalDestinatarioMunicipio = "";
         A826NotaFiscalDestinatarioUF = "";
         A827NotaFiscalDestinatarioCEP = "";
         A828NotaFiscalDestinatarioPais = "";
         A829NotaFiscalDestinatarioFone = "";
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
         T002N7_A874NotaFiscalValorTotal_F = new decimal[1] ;
         T002N7_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         T002N9_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         T002N9_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         T002N12_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N12_n794NotaFiscalId = new bool[] {false} ;
         T002N12_A795NotaFiscalUF = new short[1] ;
         T002N12_n795NotaFiscalUF = new bool[] {false} ;
         T002N12_A796NotaFiscalNatureza = new string[] {""} ;
         T002N12_n796NotaFiscalNatureza = new bool[] {false} ;
         T002N12_A797NotaFiscalMod = new string[] {""} ;
         T002N12_n797NotaFiscalMod = new bool[] {false} ;
         T002N12_A798NotaFiscalSerie = new string[] {""} ;
         T002N12_n798NotaFiscalSerie = new bool[] {false} ;
         T002N12_A799NotaFiscalNumero = new string[] {""} ;
         T002N12_n799NotaFiscalNumero = new bool[] {false} ;
         T002N12_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T002N12_n800NotaFiscalDataEmissao = new bool[] {false} ;
         T002N12_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         T002N12_n801NotaFiscalDataSaida = new bool[] {false} ;
         T002N12_A802NotaFiscalTipo = new string[] {""} ;
         T002N12_n802NotaFiscalTipo = new bool[] {false} ;
         T002N12_A803NotaFiscalMunicipio = new string[] {""} ;
         T002N12_n803NotaFiscalMunicipio = new bool[] {false} ;
         T002N12_A804NotaFiscalTipoEmissao = new string[] {""} ;
         T002N12_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         T002N12_A805NotaFiscalAmbiente = new short[1] ;
         T002N12_n805NotaFiscalAmbiente = new bool[] {false} ;
         T002N12_A806NotaFiscalFinalidades = new string[] {""} ;
         T002N12_n806NotaFiscalFinalidades = new bool[] {false} ;
         T002N12_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         T002N12_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         T002N12_A808NotaFiscalEmitenteNome = new string[] {""} ;
         T002N12_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         T002N12_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         T002N12_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         T002N12_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         T002N12_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         T002N12_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         T002N12_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         T002N12_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         T002N12_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         T002N12_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         T002N12_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         T002N12_A814NotaFiscalEmitenteUF = new string[] {""} ;
         T002N12_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         T002N12_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         T002N12_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         T002N12_A816NotaFiscalEmitentePais = new string[] {""} ;
         T002N12_n816NotaFiscalEmitentePais = new bool[] {false} ;
         T002N12_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         T002N12_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         T002N12_A819NotaFiscalEmitenteIE = new string[] {""} ;
         T002N12_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         T002N12_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         T002N12_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         T002N12_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         T002N12_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         T002N12_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         T002N12_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         T002N12_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         T002N12_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         T002N12_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         T002N12_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         T002N12_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         T002N12_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         T002N12_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         T002N12_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         T002N12_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         T002N12_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         T002N12_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         T002N12_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         T002N12_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         T002N12_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         T002N12_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         T002N12_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         T002N12_A168ClienteId = new int[1] ;
         T002N12_n168ClienteId = new bool[] {false} ;
         T002N12_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         T002N12_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         T002N12_A874NotaFiscalValorTotal_F = new decimal[1] ;
         T002N12_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         T002N12_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         T002N12_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         T002N4_A168ClienteId = new int[1] ;
         T002N4_n168ClienteId = new bool[] {false} ;
         T002N5_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         T002N5_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         T002N14_A874NotaFiscalValorTotal_F = new decimal[1] ;
         T002N14_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         T002N16_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         T002N16_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         T002N17_A168ClienteId = new int[1] ;
         T002N17_n168ClienteId = new bool[] {false} ;
         T002N18_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         T002N18_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         T002N19_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N19_n794NotaFiscalId = new bool[] {false} ;
         T002N3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N3_n794NotaFiscalId = new bool[] {false} ;
         T002N3_A795NotaFiscalUF = new short[1] ;
         T002N3_n795NotaFiscalUF = new bool[] {false} ;
         T002N3_A796NotaFiscalNatureza = new string[] {""} ;
         T002N3_n796NotaFiscalNatureza = new bool[] {false} ;
         T002N3_A797NotaFiscalMod = new string[] {""} ;
         T002N3_n797NotaFiscalMod = new bool[] {false} ;
         T002N3_A798NotaFiscalSerie = new string[] {""} ;
         T002N3_n798NotaFiscalSerie = new bool[] {false} ;
         T002N3_A799NotaFiscalNumero = new string[] {""} ;
         T002N3_n799NotaFiscalNumero = new bool[] {false} ;
         T002N3_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T002N3_n800NotaFiscalDataEmissao = new bool[] {false} ;
         T002N3_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         T002N3_n801NotaFiscalDataSaida = new bool[] {false} ;
         T002N3_A802NotaFiscalTipo = new string[] {""} ;
         T002N3_n802NotaFiscalTipo = new bool[] {false} ;
         T002N3_A803NotaFiscalMunicipio = new string[] {""} ;
         T002N3_n803NotaFiscalMunicipio = new bool[] {false} ;
         T002N3_A804NotaFiscalTipoEmissao = new string[] {""} ;
         T002N3_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         T002N3_A805NotaFiscalAmbiente = new short[1] ;
         T002N3_n805NotaFiscalAmbiente = new bool[] {false} ;
         T002N3_A806NotaFiscalFinalidades = new string[] {""} ;
         T002N3_n806NotaFiscalFinalidades = new bool[] {false} ;
         T002N3_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         T002N3_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         T002N3_A808NotaFiscalEmitenteNome = new string[] {""} ;
         T002N3_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         T002N3_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         T002N3_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         T002N3_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         T002N3_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         T002N3_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         T002N3_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         T002N3_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         T002N3_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         T002N3_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         T002N3_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         T002N3_A814NotaFiscalEmitenteUF = new string[] {""} ;
         T002N3_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         T002N3_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         T002N3_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         T002N3_A816NotaFiscalEmitentePais = new string[] {""} ;
         T002N3_n816NotaFiscalEmitentePais = new bool[] {false} ;
         T002N3_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         T002N3_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         T002N3_A819NotaFiscalEmitenteIE = new string[] {""} ;
         T002N3_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         T002N3_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         T002N3_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         T002N3_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         T002N3_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         T002N3_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         T002N3_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         T002N3_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         T002N3_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         T002N3_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         T002N3_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         T002N3_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         T002N3_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         T002N3_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         T002N3_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         T002N3_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         T002N3_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         T002N3_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         T002N3_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         T002N3_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         T002N3_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         T002N3_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         T002N3_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         T002N3_A168ClienteId = new int[1] ;
         T002N3_n168ClienteId = new bool[] {false} ;
         T002N3_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         T002N3_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         sMode93 = "";
         T002N20_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N20_n794NotaFiscalId = new bool[] {false} ;
         T002N21_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N21_n794NotaFiscalId = new bool[] {false} ;
         T002N2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N2_n794NotaFiscalId = new bool[] {false} ;
         T002N2_A795NotaFiscalUF = new short[1] ;
         T002N2_n795NotaFiscalUF = new bool[] {false} ;
         T002N2_A796NotaFiscalNatureza = new string[] {""} ;
         T002N2_n796NotaFiscalNatureza = new bool[] {false} ;
         T002N2_A797NotaFiscalMod = new string[] {""} ;
         T002N2_n797NotaFiscalMod = new bool[] {false} ;
         T002N2_A798NotaFiscalSerie = new string[] {""} ;
         T002N2_n798NotaFiscalSerie = new bool[] {false} ;
         T002N2_A799NotaFiscalNumero = new string[] {""} ;
         T002N2_n799NotaFiscalNumero = new bool[] {false} ;
         T002N2_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         T002N2_n800NotaFiscalDataEmissao = new bool[] {false} ;
         T002N2_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         T002N2_n801NotaFiscalDataSaida = new bool[] {false} ;
         T002N2_A802NotaFiscalTipo = new string[] {""} ;
         T002N2_n802NotaFiscalTipo = new bool[] {false} ;
         T002N2_A803NotaFiscalMunicipio = new string[] {""} ;
         T002N2_n803NotaFiscalMunicipio = new bool[] {false} ;
         T002N2_A804NotaFiscalTipoEmissao = new string[] {""} ;
         T002N2_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         T002N2_A805NotaFiscalAmbiente = new short[1] ;
         T002N2_n805NotaFiscalAmbiente = new bool[] {false} ;
         T002N2_A806NotaFiscalFinalidades = new string[] {""} ;
         T002N2_n806NotaFiscalFinalidades = new bool[] {false} ;
         T002N2_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         T002N2_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         T002N2_A808NotaFiscalEmitenteNome = new string[] {""} ;
         T002N2_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         T002N2_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         T002N2_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         T002N2_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         T002N2_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         T002N2_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         T002N2_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         T002N2_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         T002N2_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         T002N2_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         T002N2_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         T002N2_A814NotaFiscalEmitenteUF = new string[] {""} ;
         T002N2_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         T002N2_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         T002N2_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         T002N2_A816NotaFiscalEmitentePais = new string[] {""} ;
         T002N2_n816NotaFiscalEmitentePais = new bool[] {false} ;
         T002N2_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         T002N2_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         T002N2_A819NotaFiscalEmitenteIE = new string[] {""} ;
         T002N2_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         T002N2_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         T002N2_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         T002N2_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         T002N2_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         T002N2_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         T002N2_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         T002N2_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         T002N2_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         T002N2_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         T002N2_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         T002N2_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         T002N2_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         T002N2_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         T002N2_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         T002N2_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         T002N2_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         T002N2_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         T002N2_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         T002N2_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         T002N2_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         T002N2_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         T002N2_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         T002N2_A168ClienteId = new int[1] ;
         T002N2_n168ClienteId = new bool[] {false} ;
         T002N2_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         T002N2_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         T002N26_A874NotaFiscalValorTotal_F = new decimal[1] ;
         T002N26_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         T002N28_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         T002N28_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         T002N29_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002N30_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002N31_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002N31_n794NotaFiscalId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z881NotaFiscalValorFormatado_F = "";
         Z883NotaFiscalSaldoFormatado_F = "";
         Z882NotaFiscalValorVendidoFormatado_F = "";
         Z880NotaFiscalStatus = "";
         Z879NotaFiscalQuantidadeResumo_F = "";
         ZZ794NotaFiscalId = Guid.Empty;
         ZZ796NotaFiscalNatureza = "";
         ZZ797NotaFiscalMod = "";
         ZZ798NotaFiscalSerie = "";
         ZZ799NotaFiscalNumero = "";
         ZZ800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         ZZ801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         ZZ802NotaFiscalTipo = "";
         ZZ803NotaFiscalMunicipio = "";
         ZZ804NotaFiscalTipoEmissao = "";
         ZZ806NotaFiscalFinalidades = "";
         ZZ818NotaFiscaEmitentelDocumento = "";
         ZZ808NotaFiscalEmitenteNome = "";
         ZZ809NotaFiscalEmitenteLogradouro = "";
         ZZ810NotaFiscalEmitenteLogNum = "";
         ZZ811NotaFiscalEmitenteComplemento = "";
         ZZ812NotaFiscalEmitenteBairro = "";
         ZZ813NotaFiscalEmitenteMunicipio = "";
         ZZ814NotaFiscalEmitenteUF = "";
         ZZ815NotaFiscalEmitenteCEP = "";
         ZZ816NotaFiscalEmitentePais = "";
         ZZ817NotaFiscalEmitenteTelefone = "";
         ZZ819NotaFiscalEmitenteIE = "";
         ZZ820NotaFiscalDestinatarioDocumento = "";
         ZZ852NotaFiscalDestinatarioNome = "";
         ZZ821NotaFiscalDestinatarioLogradouro = "";
         ZZ822NotaFiscalDestinatarioLogNum = "";
         ZZ823NotaFiscalDestinatarioComplemento = "";
         ZZ824NotaFiscalDestinatarioBairro = "";
         ZZ825NotaFiscalDestinatarioMunicipio = "";
         ZZ826NotaFiscalDestinatarioUF = "";
         ZZ827NotaFiscalDestinatarioCEP = "";
         ZZ828NotaFiscalDestinatarioPais = "";
         ZZ829NotaFiscalDestinatarioFone = "";
         ZZ881NotaFiscalValorFormatado_F = "";
         ZZ883NotaFiscalSaldoFormatado_F = "";
         ZZ882NotaFiscalValorVendidoFormatado_F = "";
         ZZ880NotaFiscalStatus = "";
         ZZ879NotaFiscalQuantidadeResumo_F = "";
         T002N32_A168ClienteId = new int[1] ;
         T002N32_n168ClienteId = new bool[] {false} ;
         T002N33_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         T002N33_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscal__default(),
            new Object[][] {
                new Object[] {
               T002N2_A794NotaFiscalId, T002N2_A795NotaFiscalUF, T002N2_n795NotaFiscalUF, T002N2_A796NotaFiscalNatureza, T002N2_n796NotaFiscalNatureza, T002N2_A797NotaFiscalMod, T002N2_n797NotaFiscalMod, T002N2_A798NotaFiscalSerie, T002N2_n798NotaFiscalSerie, T002N2_A799NotaFiscalNumero,
               T002N2_n799NotaFiscalNumero, T002N2_A800NotaFiscalDataEmissao, T002N2_n800NotaFiscalDataEmissao, T002N2_A801NotaFiscalDataSaida, T002N2_n801NotaFiscalDataSaida, T002N2_A802NotaFiscalTipo, T002N2_n802NotaFiscalTipo, T002N2_A803NotaFiscalMunicipio, T002N2_n803NotaFiscalMunicipio, T002N2_A804NotaFiscalTipoEmissao,
               T002N2_n804NotaFiscalTipoEmissao, T002N2_A805NotaFiscalAmbiente, T002N2_n805NotaFiscalAmbiente, T002N2_A806NotaFiscalFinalidades, T002N2_n806NotaFiscalFinalidades, T002N2_A818NotaFiscaEmitentelDocumento, T002N2_n818NotaFiscaEmitentelDocumento, T002N2_A808NotaFiscalEmitenteNome, T002N2_n808NotaFiscalEmitenteNome, T002N2_A809NotaFiscalEmitenteLogradouro,
               T002N2_n809NotaFiscalEmitenteLogradouro, T002N2_A810NotaFiscalEmitenteLogNum, T002N2_n810NotaFiscalEmitenteLogNum, T002N2_A811NotaFiscalEmitenteComplemento, T002N2_n811NotaFiscalEmitenteComplemento, T002N2_A812NotaFiscalEmitenteBairro, T002N2_n812NotaFiscalEmitenteBairro, T002N2_A813NotaFiscalEmitenteMunicipio, T002N2_n813NotaFiscalEmitenteMunicipio, T002N2_A814NotaFiscalEmitenteUF,
               T002N2_n814NotaFiscalEmitenteUF, T002N2_A815NotaFiscalEmitenteCEP, T002N2_n815NotaFiscalEmitenteCEP, T002N2_A816NotaFiscalEmitentePais, T002N2_n816NotaFiscalEmitentePais, T002N2_A817NotaFiscalEmitenteTelefone, T002N2_n817NotaFiscalEmitenteTelefone, T002N2_A819NotaFiscalEmitenteIE, T002N2_n819NotaFiscalEmitenteIE, T002N2_A820NotaFiscalDestinatarioDocumento,
               T002N2_n820NotaFiscalDestinatarioDocumento, T002N2_A852NotaFiscalDestinatarioNome, T002N2_n852NotaFiscalDestinatarioNome, T002N2_A821NotaFiscalDestinatarioLogradouro, T002N2_n821NotaFiscalDestinatarioLogradouro, T002N2_A822NotaFiscalDestinatarioLogNum, T002N2_n822NotaFiscalDestinatarioLogNum, T002N2_A823NotaFiscalDestinatarioComplemento, T002N2_n823NotaFiscalDestinatarioComplemento, T002N2_A824NotaFiscalDestinatarioBairro,
               T002N2_n824NotaFiscalDestinatarioBairro, T002N2_A825NotaFiscalDestinatarioMunicipio, T002N2_n825NotaFiscalDestinatarioMunicipio, T002N2_A826NotaFiscalDestinatarioUF, T002N2_n826NotaFiscalDestinatarioUF, T002N2_A827NotaFiscalDestinatarioCEP, T002N2_n827NotaFiscalDestinatarioCEP, T002N2_A828NotaFiscalDestinatarioPais, T002N2_n828NotaFiscalDestinatarioPais, T002N2_A829NotaFiscalDestinatarioFone,
               T002N2_n829NotaFiscalDestinatarioFone, T002N2_A168ClienteId, T002N2_n168ClienteId, T002N2_A889NotaFiscalDestinatarioClienteId, T002N2_n889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               T002N3_A794NotaFiscalId, T002N3_A795NotaFiscalUF, T002N3_n795NotaFiscalUF, T002N3_A796NotaFiscalNatureza, T002N3_n796NotaFiscalNatureza, T002N3_A797NotaFiscalMod, T002N3_n797NotaFiscalMod, T002N3_A798NotaFiscalSerie, T002N3_n798NotaFiscalSerie, T002N3_A799NotaFiscalNumero,
               T002N3_n799NotaFiscalNumero, T002N3_A800NotaFiscalDataEmissao, T002N3_n800NotaFiscalDataEmissao, T002N3_A801NotaFiscalDataSaida, T002N3_n801NotaFiscalDataSaida, T002N3_A802NotaFiscalTipo, T002N3_n802NotaFiscalTipo, T002N3_A803NotaFiscalMunicipio, T002N3_n803NotaFiscalMunicipio, T002N3_A804NotaFiscalTipoEmissao,
               T002N3_n804NotaFiscalTipoEmissao, T002N3_A805NotaFiscalAmbiente, T002N3_n805NotaFiscalAmbiente, T002N3_A806NotaFiscalFinalidades, T002N3_n806NotaFiscalFinalidades, T002N3_A818NotaFiscaEmitentelDocumento, T002N3_n818NotaFiscaEmitentelDocumento, T002N3_A808NotaFiscalEmitenteNome, T002N3_n808NotaFiscalEmitenteNome, T002N3_A809NotaFiscalEmitenteLogradouro,
               T002N3_n809NotaFiscalEmitenteLogradouro, T002N3_A810NotaFiscalEmitenteLogNum, T002N3_n810NotaFiscalEmitenteLogNum, T002N3_A811NotaFiscalEmitenteComplemento, T002N3_n811NotaFiscalEmitenteComplemento, T002N3_A812NotaFiscalEmitenteBairro, T002N3_n812NotaFiscalEmitenteBairro, T002N3_A813NotaFiscalEmitenteMunicipio, T002N3_n813NotaFiscalEmitenteMunicipio, T002N3_A814NotaFiscalEmitenteUF,
               T002N3_n814NotaFiscalEmitenteUF, T002N3_A815NotaFiscalEmitenteCEP, T002N3_n815NotaFiscalEmitenteCEP, T002N3_A816NotaFiscalEmitentePais, T002N3_n816NotaFiscalEmitentePais, T002N3_A817NotaFiscalEmitenteTelefone, T002N3_n817NotaFiscalEmitenteTelefone, T002N3_A819NotaFiscalEmitenteIE, T002N3_n819NotaFiscalEmitenteIE, T002N3_A820NotaFiscalDestinatarioDocumento,
               T002N3_n820NotaFiscalDestinatarioDocumento, T002N3_A852NotaFiscalDestinatarioNome, T002N3_n852NotaFiscalDestinatarioNome, T002N3_A821NotaFiscalDestinatarioLogradouro, T002N3_n821NotaFiscalDestinatarioLogradouro, T002N3_A822NotaFiscalDestinatarioLogNum, T002N3_n822NotaFiscalDestinatarioLogNum, T002N3_A823NotaFiscalDestinatarioComplemento, T002N3_n823NotaFiscalDestinatarioComplemento, T002N3_A824NotaFiscalDestinatarioBairro,
               T002N3_n824NotaFiscalDestinatarioBairro, T002N3_A825NotaFiscalDestinatarioMunicipio, T002N3_n825NotaFiscalDestinatarioMunicipio, T002N3_A826NotaFiscalDestinatarioUF, T002N3_n826NotaFiscalDestinatarioUF, T002N3_A827NotaFiscalDestinatarioCEP, T002N3_n827NotaFiscalDestinatarioCEP, T002N3_A828NotaFiscalDestinatarioPais, T002N3_n828NotaFiscalDestinatarioPais, T002N3_A829NotaFiscalDestinatarioFone,
               T002N3_n829NotaFiscalDestinatarioFone, T002N3_A168ClienteId, T002N3_n168ClienteId, T002N3_A889NotaFiscalDestinatarioClienteId, T002N3_n889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               T002N4_A168ClienteId
               }
               , new Object[] {
               T002N5_A889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               T002N7_A874NotaFiscalValorTotal_F, T002N7_A877NotaFiscalQuantidadeDeItens_F
               }
               , new Object[] {
               T002N9_A875NotaFiscalValorTotalVendido_F, T002N9_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               T002N12_A794NotaFiscalId, T002N12_A795NotaFiscalUF, T002N12_n795NotaFiscalUF, T002N12_A796NotaFiscalNatureza, T002N12_n796NotaFiscalNatureza, T002N12_A797NotaFiscalMod, T002N12_n797NotaFiscalMod, T002N12_A798NotaFiscalSerie, T002N12_n798NotaFiscalSerie, T002N12_A799NotaFiscalNumero,
               T002N12_n799NotaFiscalNumero, T002N12_A800NotaFiscalDataEmissao, T002N12_n800NotaFiscalDataEmissao, T002N12_A801NotaFiscalDataSaida, T002N12_n801NotaFiscalDataSaida, T002N12_A802NotaFiscalTipo, T002N12_n802NotaFiscalTipo, T002N12_A803NotaFiscalMunicipio, T002N12_n803NotaFiscalMunicipio, T002N12_A804NotaFiscalTipoEmissao,
               T002N12_n804NotaFiscalTipoEmissao, T002N12_A805NotaFiscalAmbiente, T002N12_n805NotaFiscalAmbiente, T002N12_A806NotaFiscalFinalidades, T002N12_n806NotaFiscalFinalidades, T002N12_A818NotaFiscaEmitentelDocumento, T002N12_n818NotaFiscaEmitentelDocumento, T002N12_A808NotaFiscalEmitenteNome, T002N12_n808NotaFiscalEmitenteNome, T002N12_A809NotaFiscalEmitenteLogradouro,
               T002N12_n809NotaFiscalEmitenteLogradouro, T002N12_A810NotaFiscalEmitenteLogNum, T002N12_n810NotaFiscalEmitenteLogNum, T002N12_A811NotaFiscalEmitenteComplemento, T002N12_n811NotaFiscalEmitenteComplemento, T002N12_A812NotaFiscalEmitenteBairro, T002N12_n812NotaFiscalEmitenteBairro, T002N12_A813NotaFiscalEmitenteMunicipio, T002N12_n813NotaFiscalEmitenteMunicipio, T002N12_A814NotaFiscalEmitenteUF,
               T002N12_n814NotaFiscalEmitenteUF, T002N12_A815NotaFiscalEmitenteCEP, T002N12_n815NotaFiscalEmitenteCEP, T002N12_A816NotaFiscalEmitentePais, T002N12_n816NotaFiscalEmitentePais, T002N12_A817NotaFiscalEmitenteTelefone, T002N12_n817NotaFiscalEmitenteTelefone, T002N12_A819NotaFiscalEmitenteIE, T002N12_n819NotaFiscalEmitenteIE, T002N12_A820NotaFiscalDestinatarioDocumento,
               T002N12_n820NotaFiscalDestinatarioDocumento, T002N12_A852NotaFiscalDestinatarioNome, T002N12_n852NotaFiscalDestinatarioNome, T002N12_A821NotaFiscalDestinatarioLogradouro, T002N12_n821NotaFiscalDestinatarioLogradouro, T002N12_A822NotaFiscalDestinatarioLogNum, T002N12_n822NotaFiscalDestinatarioLogNum, T002N12_A823NotaFiscalDestinatarioComplemento, T002N12_n823NotaFiscalDestinatarioComplemento, T002N12_A824NotaFiscalDestinatarioBairro,
               T002N12_n824NotaFiscalDestinatarioBairro, T002N12_A825NotaFiscalDestinatarioMunicipio, T002N12_n825NotaFiscalDestinatarioMunicipio, T002N12_A826NotaFiscalDestinatarioUF, T002N12_n826NotaFiscalDestinatarioUF, T002N12_A827NotaFiscalDestinatarioCEP, T002N12_n827NotaFiscalDestinatarioCEP, T002N12_A828NotaFiscalDestinatarioPais, T002N12_n828NotaFiscalDestinatarioPais, T002N12_A829NotaFiscalDestinatarioFone,
               T002N12_n829NotaFiscalDestinatarioFone, T002N12_A168ClienteId, T002N12_n168ClienteId, T002N12_A889NotaFiscalDestinatarioClienteId, T002N12_n889NotaFiscalDestinatarioClienteId, T002N12_A874NotaFiscalValorTotal_F, T002N12_A875NotaFiscalValorTotalVendido_F, T002N12_A877NotaFiscalQuantidadeDeItens_F, T002N12_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               T002N14_A874NotaFiscalValorTotal_F, T002N14_A877NotaFiscalQuantidadeDeItens_F
               }
               , new Object[] {
               T002N16_A875NotaFiscalValorTotalVendido_F, T002N16_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               T002N17_A168ClienteId
               }
               , new Object[] {
               T002N18_A889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               T002N19_A794NotaFiscalId
               }
               , new Object[] {
               T002N20_A794NotaFiscalId
               }
               , new Object[] {
               T002N21_A794NotaFiscalId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002N26_A874NotaFiscalValorTotal_F, T002N26_A877NotaFiscalQuantidadeDeItens_F
               }
               , new Object[] {
               T002N28_A875NotaFiscalValorTotalVendido_F, T002N28_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               T002N29_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               T002N30_A830NotaFiscalItemId
               }
               , new Object[] {
               T002N31_A794NotaFiscalId
               }
               , new Object[] {
               T002N32_A168ClienteId
               }
               , new Object[] {
               T002N33_A889NotaFiscalDestinatarioClienteId
               }
            }
         );
         Z794NotaFiscalId = Guid.NewGuid( );
         n794NotaFiscalId = false;
         A794NotaFiscalId = Guid.NewGuid( );
         n794NotaFiscalId = false;
      }

      private short Z795NotaFiscalUF ;
      private short Z805NotaFiscalAmbiente ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A795NotaFiscalUF ;
      private short A805NotaFiscalAmbiente ;
      private short A877NotaFiscalQuantidadeDeItens_F ;
      private short A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private short Gx_BScreen ;
      private short Z877NotaFiscalQuantidadeDeItens_F ;
      private short Z878NotaFiscalQuantidadeDeItensVendidos_F ;
      private short RcdFound93 ;
      private short gxajaxcallmode ;
      private short ZZ795NotaFiscalUF ;
      private short ZZ805NotaFiscalAmbiente ;
      private short ZZ877NotaFiscalQuantidadeDeItens_F ;
      private short ZZ878NotaFiscalQuantidadeDeItensVendidos_F ;
      private int Z168ClienteId ;
      private int Z889NotaFiscalDestinatarioClienteId ;
      private int A168ClienteId ;
      private int A889NotaFiscalDestinatarioClienteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtNotaFiscalId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtNotaFiscalValorTotal_F_Enabled ;
      private int edtNotaFiscalValorTotalVendido_F_Enabled ;
      private int edtNotaFiscalSaldo_F_Enabled ;
      private int edtNotaFiscalQuantidadeDeItens_F_Enabled ;
      private int edtNotaFiscalQuantidadeDeItensVendidos_F_Enabled ;
      private int edtNotaFiscalQuantidadeResumo_F_Enabled ;
      private int edtNotaFiscalValorFormatado_F_Enabled ;
      private int edtNotaFiscalValorVendidoFormatado_F_Enabled ;
      private int edtNotaFiscalSaldoFormatado_F_Enabled ;
      private int edtNotaFiscalNatureza_Enabled ;
      private int edtNotaFiscalMod_Enabled ;
      private int edtNotaFiscalSerie_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int edtNotaFiscalDataEmissao_Enabled ;
      private int edtNotaFiscalDataSaida_Enabled ;
      private int edtNotaFiscalMunicipio_Enabled ;
      private int edtNotaFiscaEmitentelDocumento_Enabled ;
      private int edtNotaFiscalEmitenteNome_Enabled ;
      private int edtNotaFiscalEmitenteLogradouro_Enabled ;
      private int edtNotaFiscalEmitenteLogNum_Enabled ;
      private int edtNotaFiscalEmitenteComplemento_Enabled ;
      private int edtNotaFiscalEmitenteBairro_Enabled ;
      private int edtNotaFiscalEmitenteMunicipio_Enabled ;
      private int edtNotaFiscalEmitenteUF_Enabled ;
      private int edtNotaFiscalEmitenteCEP_Enabled ;
      private int edtNotaFiscalEmitentePais_Enabled ;
      private int edtNotaFiscalEmitenteTelefone_Enabled ;
      private int edtNotaFiscalEmitenteIE_Enabled ;
      private int edtNotaFiscalDestinatarioClienteId_Enabled ;
      private int edtNotaFiscalDestinatarioDocumento_Enabled ;
      private int edtNotaFiscalDestinatarioNome_Enabled ;
      private int edtNotaFiscalDestinatarioLogradouro_Enabled ;
      private int edtNotaFiscalDestinatarioLogNum_Enabled ;
      private int edtNotaFiscalDestinatarioComplemento_Enabled ;
      private int edtNotaFiscalDestinatarioBairro_Enabled ;
      private int edtNotaFiscalDestinatarioMunicipio_Enabled ;
      private int edtNotaFiscalDestinatarioUF_Enabled ;
      private int edtNotaFiscalDestinatarioCEP_Enabled ;
      private int edtNotaFiscalDestinatarioPais_Enabled ;
      private int edtNotaFiscalDestinatarioFone_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ168ClienteId ;
      private int ZZ889NotaFiscalDestinatarioClienteId ;
      private decimal A874NotaFiscalValorTotal_F ;
      private decimal A875NotaFiscalValorTotalVendido_F ;
      private decimal A876NotaFiscalSaldo_F ;
      private decimal Z874NotaFiscalValorTotal_F ;
      private decimal Z875NotaFiscalValorTotalVendido_F ;
      private decimal Z876NotaFiscalSaldo_F ;
      private decimal ZZ874NotaFiscalValorTotal_F ;
      private decimal ZZ875NotaFiscalValorTotalVendido_F ;
      private decimal ZZ876NotaFiscalSaldo_F ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotaFiscalId_Internalname ;
      private string cmbNotaFiscalUF_Internalname ;
      private string cmbNotaFiscalStatus_Internalname ;
      private string cmbNotaFiscalTipo_Internalname ;
      private string cmbNotaFiscalTipoEmissao_Internalname ;
      private string cmbNotaFiscalAmbiente_Internalname ;
      private string cmbNotaFiscalFinalidades_Internalname ;
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
      private string edtNotaFiscalId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string cmbNotaFiscalUF_Jsonclick ;
      private string edtNotaFiscalValorTotal_F_Internalname ;
      private string edtNotaFiscalValorTotal_F_Jsonclick ;
      private string edtNotaFiscalValorTotalVendido_F_Internalname ;
      private string edtNotaFiscalValorTotalVendido_F_Jsonclick ;
      private string edtNotaFiscalSaldo_F_Internalname ;
      private string edtNotaFiscalSaldo_F_Jsonclick ;
      private string edtNotaFiscalQuantidadeDeItens_F_Internalname ;
      private string edtNotaFiscalQuantidadeDeItens_F_Jsonclick ;
      private string edtNotaFiscalQuantidadeDeItensVendidos_F_Internalname ;
      private string edtNotaFiscalQuantidadeDeItensVendidos_F_Jsonclick ;
      private string edtNotaFiscalQuantidadeResumo_F_Internalname ;
      private string edtNotaFiscalQuantidadeResumo_F_Jsonclick ;
      private string edtNotaFiscalValorFormatado_F_Internalname ;
      private string edtNotaFiscalValorFormatado_F_Jsonclick ;
      private string edtNotaFiscalValorVendidoFormatado_F_Internalname ;
      private string edtNotaFiscalValorVendidoFormatado_F_Jsonclick ;
      private string edtNotaFiscalSaldoFormatado_F_Internalname ;
      private string edtNotaFiscalSaldoFormatado_F_Jsonclick ;
      private string cmbNotaFiscalStatus_Jsonclick ;
      private string edtNotaFiscalNatureza_Internalname ;
      private string edtNotaFiscalMod_Internalname ;
      private string edtNotaFiscalMod_Jsonclick ;
      private string edtNotaFiscalSerie_Internalname ;
      private string edtNotaFiscalSerie_Jsonclick ;
      private string edtNotaFiscalNumero_Internalname ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string edtNotaFiscalDataEmissao_Internalname ;
      private string edtNotaFiscalDataEmissao_Jsonclick ;
      private string edtNotaFiscalDataSaida_Internalname ;
      private string edtNotaFiscalDataSaida_Jsonclick ;
      private string cmbNotaFiscalTipo_Jsonclick ;
      private string edtNotaFiscalMunicipio_Internalname ;
      private string edtNotaFiscalMunicipio_Jsonclick ;
      private string cmbNotaFiscalTipoEmissao_Jsonclick ;
      private string cmbNotaFiscalAmbiente_Jsonclick ;
      private string cmbNotaFiscalFinalidades_Jsonclick ;
      private string edtNotaFiscaEmitentelDocumento_Internalname ;
      private string edtNotaFiscaEmitentelDocumento_Jsonclick ;
      private string edtNotaFiscalEmitenteNome_Internalname ;
      private string edtNotaFiscalEmitenteNome_Jsonclick ;
      private string edtNotaFiscalEmitenteLogradouro_Internalname ;
      private string edtNotaFiscalEmitenteLogradouro_Jsonclick ;
      private string edtNotaFiscalEmitenteLogNum_Internalname ;
      private string edtNotaFiscalEmitenteLogNum_Jsonclick ;
      private string edtNotaFiscalEmitenteComplemento_Internalname ;
      private string edtNotaFiscalEmitenteComplemento_Jsonclick ;
      private string edtNotaFiscalEmitenteBairro_Internalname ;
      private string edtNotaFiscalEmitenteBairro_Jsonclick ;
      private string edtNotaFiscalEmitenteMunicipio_Internalname ;
      private string edtNotaFiscalEmitenteMunicipio_Jsonclick ;
      private string edtNotaFiscalEmitenteUF_Internalname ;
      private string edtNotaFiscalEmitenteUF_Jsonclick ;
      private string edtNotaFiscalEmitenteCEP_Internalname ;
      private string edtNotaFiscalEmitenteCEP_Jsonclick ;
      private string edtNotaFiscalEmitentePais_Internalname ;
      private string edtNotaFiscalEmitentePais_Jsonclick ;
      private string edtNotaFiscalEmitenteTelefone_Internalname ;
      private string edtNotaFiscalEmitenteTelefone_Jsonclick ;
      private string edtNotaFiscalEmitenteIE_Internalname ;
      private string edtNotaFiscalEmitenteIE_Jsonclick ;
      private string edtNotaFiscalDestinatarioClienteId_Internalname ;
      private string edtNotaFiscalDestinatarioClienteId_Jsonclick ;
      private string edtNotaFiscalDestinatarioDocumento_Internalname ;
      private string edtNotaFiscalDestinatarioDocumento_Jsonclick ;
      private string edtNotaFiscalDestinatarioNome_Internalname ;
      private string edtNotaFiscalDestinatarioNome_Jsonclick ;
      private string edtNotaFiscalDestinatarioLogradouro_Internalname ;
      private string edtNotaFiscalDestinatarioLogradouro_Jsonclick ;
      private string edtNotaFiscalDestinatarioLogNum_Internalname ;
      private string edtNotaFiscalDestinatarioLogNum_Jsonclick ;
      private string edtNotaFiscalDestinatarioComplemento_Internalname ;
      private string edtNotaFiscalDestinatarioComplemento_Jsonclick ;
      private string edtNotaFiscalDestinatarioBairro_Internalname ;
      private string edtNotaFiscalDestinatarioBairro_Jsonclick ;
      private string edtNotaFiscalDestinatarioMunicipio_Internalname ;
      private string edtNotaFiscalDestinatarioMunicipio_Jsonclick ;
      private string edtNotaFiscalDestinatarioUF_Internalname ;
      private string edtNotaFiscalDestinatarioUF_Jsonclick ;
      private string edtNotaFiscalDestinatarioCEP_Internalname ;
      private string edtNotaFiscalDestinatarioCEP_Jsonclick ;
      private string edtNotaFiscalDestinatarioPais_Internalname ;
      private string edtNotaFiscalDestinatarioPais_Jsonclick ;
      private string edtNotaFiscalDestinatarioFone_Internalname ;
      private string edtNotaFiscalDestinatarioFone_Jsonclick ;
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
      private string sMode93 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z800NotaFiscalDataEmissao ;
      private DateTime Z801NotaFiscalDataSaida ;
      private DateTime A800NotaFiscalDataEmissao ;
      private DateTime A801NotaFiscalDataSaida ;
      private DateTime ZZ800NotaFiscalDataEmissao ;
      private DateTime ZZ801NotaFiscalDataSaida ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n889NotaFiscalDestinatarioClienteId ;
      private bool wbErr ;
      private bool n795NotaFiscalUF ;
      private bool n802NotaFiscalTipo ;
      private bool n804NotaFiscalTipoEmissao ;
      private bool n805NotaFiscalAmbiente ;
      private bool n806NotaFiscalFinalidades ;
      private bool n796NotaFiscalNatureza ;
      private bool n797NotaFiscalMod ;
      private bool n798NotaFiscalSerie ;
      private bool n799NotaFiscalNumero ;
      private bool n800NotaFiscalDataEmissao ;
      private bool n801NotaFiscalDataSaida ;
      private bool n803NotaFiscalMunicipio ;
      private bool n818NotaFiscaEmitentelDocumento ;
      private bool n808NotaFiscalEmitenteNome ;
      private bool n809NotaFiscalEmitenteLogradouro ;
      private bool n810NotaFiscalEmitenteLogNum ;
      private bool n811NotaFiscalEmitenteComplemento ;
      private bool n812NotaFiscalEmitenteBairro ;
      private bool n813NotaFiscalEmitenteMunicipio ;
      private bool n814NotaFiscalEmitenteUF ;
      private bool n815NotaFiscalEmitenteCEP ;
      private bool n816NotaFiscalEmitentePais ;
      private bool n817NotaFiscalEmitenteTelefone ;
      private bool n819NotaFiscalEmitenteIE ;
      private bool n820NotaFiscalDestinatarioDocumento ;
      private bool n852NotaFiscalDestinatarioNome ;
      private bool n821NotaFiscalDestinatarioLogradouro ;
      private bool n822NotaFiscalDestinatarioLogNum ;
      private bool n823NotaFiscalDestinatarioComplemento ;
      private bool n824NotaFiscalDestinatarioBairro ;
      private bool n825NotaFiscalDestinatarioMunicipio ;
      private bool n826NotaFiscalDestinatarioUF ;
      private bool n827NotaFiscalDestinatarioCEP ;
      private bool n828NotaFiscalDestinatarioPais ;
      private bool n829NotaFiscalDestinatarioFone ;
      private bool Gx_longc ;
      private string Z796NotaFiscalNatureza ;
      private string Z797NotaFiscalMod ;
      private string Z798NotaFiscalSerie ;
      private string Z799NotaFiscalNumero ;
      private string Z802NotaFiscalTipo ;
      private string Z803NotaFiscalMunicipio ;
      private string Z804NotaFiscalTipoEmissao ;
      private string Z806NotaFiscalFinalidades ;
      private string Z818NotaFiscaEmitentelDocumento ;
      private string Z808NotaFiscalEmitenteNome ;
      private string Z809NotaFiscalEmitenteLogradouro ;
      private string Z810NotaFiscalEmitenteLogNum ;
      private string Z811NotaFiscalEmitenteComplemento ;
      private string Z812NotaFiscalEmitenteBairro ;
      private string Z813NotaFiscalEmitenteMunicipio ;
      private string Z814NotaFiscalEmitenteUF ;
      private string Z815NotaFiscalEmitenteCEP ;
      private string Z816NotaFiscalEmitentePais ;
      private string Z817NotaFiscalEmitenteTelefone ;
      private string Z819NotaFiscalEmitenteIE ;
      private string Z820NotaFiscalDestinatarioDocumento ;
      private string Z852NotaFiscalDestinatarioNome ;
      private string Z821NotaFiscalDestinatarioLogradouro ;
      private string Z822NotaFiscalDestinatarioLogNum ;
      private string Z823NotaFiscalDestinatarioComplemento ;
      private string Z824NotaFiscalDestinatarioBairro ;
      private string Z825NotaFiscalDestinatarioMunicipio ;
      private string Z826NotaFiscalDestinatarioUF ;
      private string Z827NotaFiscalDestinatarioCEP ;
      private string Z828NotaFiscalDestinatarioPais ;
      private string Z829NotaFiscalDestinatarioFone ;
      private string A880NotaFiscalStatus ;
      private string A802NotaFiscalTipo ;
      private string A804NotaFiscalTipoEmissao ;
      private string A806NotaFiscalFinalidades ;
      private string A879NotaFiscalQuantidadeResumo_F ;
      private string A881NotaFiscalValorFormatado_F ;
      private string A882NotaFiscalValorVendidoFormatado_F ;
      private string A883NotaFiscalSaldoFormatado_F ;
      private string A796NotaFiscalNatureza ;
      private string A797NotaFiscalMod ;
      private string A798NotaFiscalSerie ;
      private string A799NotaFiscalNumero ;
      private string A803NotaFiscalMunicipio ;
      private string A818NotaFiscaEmitentelDocumento ;
      private string A808NotaFiscalEmitenteNome ;
      private string A809NotaFiscalEmitenteLogradouro ;
      private string A810NotaFiscalEmitenteLogNum ;
      private string A811NotaFiscalEmitenteComplemento ;
      private string A812NotaFiscalEmitenteBairro ;
      private string A813NotaFiscalEmitenteMunicipio ;
      private string A814NotaFiscalEmitenteUF ;
      private string A815NotaFiscalEmitenteCEP ;
      private string A816NotaFiscalEmitentePais ;
      private string A817NotaFiscalEmitenteTelefone ;
      private string A819NotaFiscalEmitenteIE ;
      private string A820NotaFiscalDestinatarioDocumento ;
      private string A852NotaFiscalDestinatarioNome ;
      private string A821NotaFiscalDestinatarioLogradouro ;
      private string A822NotaFiscalDestinatarioLogNum ;
      private string A823NotaFiscalDestinatarioComplemento ;
      private string A824NotaFiscalDestinatarioBairro ;
      private string A825NotaFiscalDestinatarioMunicipio ;
      private string A826NotaFiscalDestinatarioUF ;
      private string A827NotaFiscalDestinatarioCEP ;
      private string A828NotaFiscalDestinatarioPais ;
      private string A829NotaFiscalDestinatarioFone ;
      private string Z881NotaFiscalValorFormatado_F ;
      private string Z883NotaFiscalSaldoFormatado_F ;
      private string Z882NotaFiscalValorVendidoFormatado_F ;
      private string Z880NotaFiscalStatus ;
      private string Z879NotaFiscalQuantidadeResumo_F ;
      private string ZZ796NotaFiscalNatureza ;
      private string ZZ797NotaFiscalMod ;
      private string ZZ798NotaFiscalSerie ;
      private string ZZ799NotaFiscalNumero ;
      private string ZZ802NotaFiscalTipo ;
      private string ZZ803NotaFiscalMunicipio ;
      private string ZZ804NotaFiscalTipoEmissao ;
      private string ZZ806NotaFiscalFinalidades ;
      private string ZZ818NotaFiscaEmitentelDocumento ;
      private string ZZ808NotaFiscalEmitenteNome ;
      private string ZZ809NotaFiscalEmitenteLogradouro ;
      private string ZZ810NotaFiscalEmitenteLogNum ;
      private string ZZ811NotaFiscalEmitenteComplemento ;
      private string ZZ812NotaFiscalEmitenteBairro ;
      private string ZZ813NotaFiscalEmitenteMunicipio ;
      private string ZZ814NotaFiscalEmitenteUF ;
      private string ZZ815NotaFiscalEmitenteCEP ;
      private string ZZ816NotaFiscalEmitentePais ;
      private string ZZ817NotaFiscalEmitenteTelefone ;
      private string ZZ819NotaFiscalEmitenteIE ;
      private string ZZ820NotaFiscalDestinatarioDocumento ;
      private string ZZ852NotaFiscalDestinatarioNome ;
      private string ZZ821NotaFiscalDestinatarioLogradouro ;
      private string ZZ822NotaFiscalDestinatarioLogNum ;
      private string ZZ823NotaFiscalDestinatarioComplemento ;
      private string ZZ824NotaFiscalDestinatarioBairro ;
      private string ZZ825NotaFiscalDestinatarioMunicipio ;
      private string ZZ826NotaFiscalDestinatarioUF ;
      private string ZZ827NotaFiscalDestinatarioCEP ;
      private string ZZ828NotaFiscalDestinatarioPais ;
      private string ZZ829NotaFiscalDestinatarioFone ;
      private string ZZ881NotaFiscalValorFormatado_F ;
      private string ZZ883NotaFiscalSaldoFormatado_F ;
      private string ZZ882NotaFiscalValorVendidoFormatado_F ;
      private string ZZ880NotaFiscalStatus ;
      private string ZZ879NotaFiscalQuantidadeResumo_F ;
      private Guid Z794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private Guid ZZ794NotaFiscalId ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNotaFiscalUF ;
      private GXCombobox cmbNotaFiscalStatus ;
      private GXCombobox cmbNotaFiscalTipo ;
      private GXCombobox cmbNotaFiscalTipoEmissao ;
      private GXCombobox cmbNotaFiscalAmbiente ;
      private GXCombobox cmbNotaFiscalFinalidades ;
      private IDataStoreProvider pr_default ;
      private decimal[] T002N7_A874NotaFiscalValorTotal_F ;
      private short[] T002N7_A877NotaFiscalQuantidadeDeItens_F ;
      private decimal[] T002N9_A875NotaFiscalValorTotalVendido_F ;
      private short[] T002N9_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private Guid[] T002N12_A794NotaFiscalId ;
      private bool[] T002N12_n794NotaFiscalId ;
      private short[] T002N12_A795NotaFiscalUF ;
      private bool[] T002N12_n795NotaFiscalUF ;
      private string[] T002N12_A796NotaFiscalNatureza ;
      private bool[] T002N12_n796NotaFiscalNatureza ;
      private string[] T002N12_A797NotaFiscalMod ;
      private bool[] T002N12_n797NotaFiscalMod ;
      private string[] T002N12_A798NotaFiscalSerie ;
      private bool[] T002N12_n798NotaFiscalSerie ;
      private string[] T002N12_A799NotaFiscalNumero ;
      private bool[] T002N12_n799NotaFiscalNumero ;
      private DateTime[] T002N12_A800NotaFiscalDataEmissao ;
      private bool[] T002N12_n800NotaFiscalDataEmissao ;
      private DateTime[] T002N12_A801NotaFiscalDataSaida ;
      private bool[] T002N12_n801NotaFiscalDataSaida ;
      private string[] T002N12_A802NotaFiscalTipo ;
      private bool[] T002N12_n802NotaFiscalTipo ;
      private string[] T002N12_A803NotaFiscalMunicipio ;
      private bool[] T002N12_n803NotaFiscalMunicipio ;
      private string[] T002N12_A804NotaFiscalTipoEmissao ;
      private bool[] T002N12_n804NotaFiscalTipoEmissao ;
      private short[] T002N12_A805NotaFiscalAmbiente ;
      private bool[] T002N12_n805NotaFiscalAmbiente ;
      private string[] T002N12_A806NotaFiscalFinalidades ;
      private bool[] T002N12_n806NotaFiscalFinalidades ;
      private string[] T002N12_A818NotaFiscaEmitentelDocumento ;
      private bool[] T002N12_n818NotaFiscaEmitentelDocumento ;
      private string[] T002N12_A808NotaFiscalEmitenteNome ;
      private bool[] T002N12_n808NotaFiscalEmitenteNome ;
      private string[] T002N12_A809NotaFiscalEmitenteLogradouro ;
      private bool[] T002N12_n809NotaFiscalEmitenteLogradouro ;
      private string[] T002N12_A810NotaFiscalEmitenteLogNum ;
      private bool[] T002N12_n810NotaFiscalEmitenteLogNum ;
      private string[] T002N12_A811NotaFiscalEmitenteComplemento ;
      private bool[] T002N12_n811NotaFiscalEmitenteComplemento ;
      private string[] T002N12_A812NotaFiscalEmitenteBairro ;
      private bool[] T002N12_n812NotaFiscalEmitenteBairro ;
      private string[] T002N12_A813NotaFiscalEmitenteMunicipio ;
      private bool[] T002N12_n813NotaFiscalEmitenteMunicipio ;
      private string[] T002N12_A814NotaFiscalEmitenteUF ;
      private bool[] T002N12_n814NotaFiscalEmitenteUF ;
      private string[] T002N12_A815NotaFiscalEmitenteCEP ;
      private bool[] T002N12_n815NotaFiscalEmitenteCEP ;
      private string[] T002N12_A816NotaFiscalEmitentePais ;
      private bool[] T002N12_n816NotaFiscalEmitentePais ;
      private string[] T002N12_A817NotaFiscalEmitenteTelefone ;
      private bool[] T002N12_n817NotaFiscalEmitenteTelefone ;
      private string[] T002N12_A819NotaFiscalEmitenteIE ;
      private bool[] T002N12_n819NotaFiscalEmitenteIE ;
      private string[] T002N12_A820NotaFiscalDestinatarioDocumento ;
      private bool[] T002N12_n820NotaFiscalDestinatarioDocumento ;
      private string[] T002N12_A852NotaFiscalDestinatarioNome ;
      private bool[] T002N12_n852NotaFiscalDestinatarioNome ;
      private string[] T002N12_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] T002N12_n821NotaFiscalDestinatarioLogradouro ;
      private string[] T002N12_A822NotaFiscalDestinatarioLogNum ;
      private bool[] T002N12_n822NotaFiscalDestinatarioLogNum ;
      private string[] T002N12_A823NotaFiscalDestinatarioComplemento ;
      private bool[] T002N12_n823NotaFiscalDestinatarioComplemento ;
      private string[] T002N12_A824NotaFiscalDestinatarioBairro ;
      private bool[] T002N12_n824NotaFiscalDestinatarioBairro ;
      private string[] T002N12_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] T002N12_n825NotaFiscalDestinatarioMunicipio ;
      private string[] T002N12_A826NotaFiscalDestinatarioUF ;
      private bool[] T002N12_n826NotaFiscalDestinatarioUF ;
      private string[] T002N12_A827NotaFiscalDestinatarioCEP ;
      private bool[] T002N12_n827NotaFiscalDestinatarioCEP ;
      private string[] T002N12_A828NotaFiscalDestinatarioPais ;
      private bool[] T002N12_n828NotaFiscalDestinatarioPais ;
      private string[] T002N12_A829NotaFiscalDestinatarioFone ;
      private bool[] T002N12_n829NotaFiscalDestinatarioFone ;
      private int[] T002N12_A168ClienteId ;
      private bool[] T002N12_n168ClienteId ;
      private int[] T002N12_A889NotaFiscalDestinatarioClienteId ;
      private bool[] T002N12_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] T002N12_A874NotaFiscalValorTotal_F ;
      private decimal[] T002N12_A875NotaFiscalValorTotalVendido_F ;
      private short[] T002N12_A877NotaFiscalQuantidadeDeItens_F ;
      private short[] T002N12_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private int[] T002N4_A168ClienteId ;
      private bool[] T002N4_n168ClienteId ;
      private int[] T002N5_A889NotaFiscalDestinatarioClienteId ;
      private bool[] T002N5_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] T002N14_A874NotaFiscalValorTotal_F ;
      private short[] T002N14_A877NotaFiscalQuantidadeDeItens_F ;
      private decimal[] T002N16_A875NotaFiscalValorTotalVendido_F ;
      private short[] T002N16_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private int[] T002N17_A168ClienteId ;
      private bool[] T002N17_n168ClienteId ;
      private int[] T002N18_A889NotaFiscalDestinatarioClienteId ;
      private bool[] T002N18_n889NotaFiscalDestinatarioClienteId ;
      private Guid[] T002N19_A794NotaFiscalId ;
      private bool[] T002N19_n794NotaFiscalId ;
      private Guid[] T002N3_A794NotaFiscalId ;
      private bool[] T002N3_n794NotaFiscalId ;
      private short[] T002N3_A795NotaFiscalUF ;
      private bool[] T002N3_n795NotaFiscalUF ;
      private string[] T002N3_A796NotaFiscalNatureza ;
      private bool[] T002N3_n796NotaFiscalNatureza ;
      private string[] T002N3_A797NotaFiscalMod ;
      private bool[] T002N3_n797NotaFiscalMod ;
      private string[] T002N3_A798NotaFiscalSerie ;
      private bool[] T002N3_n798NotaFiscalSerie ;
      private string[] T002N3_A799NotaFiscalNumero ;
      private bool[] T002N3_n799NotaFiscalNumero ;
      private DateTime[] T002N3_A800NotaFiscalDataEmissao ;
      private bool[] T002N3_n800NotaFiscalDataEmissao ;
      private DateTime[] T002N3_A801NotaFiscalDataSaida ;
      private bool[] T002N3_n801NotaFiscalDataSaida ;
      private string[] T002N3_A802NotaFiscalTipo ;
      private bool[] T002N3_n802NotaFiscalTipo ;
      private string[] T002N3_A803NotaFiscalMunicipio ;
      private bool[] T002N3_n803NotaFiscalMunicipio ;
      private string[] T002N3_A804NotaFiscalTipoEmissao ;
      private bool[] T002N3_n804NotaFiscalTipoEmissao ;
      private short[] T002N3_A805NotaFiscalAmbiente ;
      private bool[] T002N3_n805NotaFiscalAmbiente ;
      private string[] T002N3_A806NotaFiscalFinalidades ;
      private bool[] T002N3_n806NotaFiscalFinalidades ;
      private string[] T002N3_A818NotaFiscaEmitentelDocumento ;
      private bool[] T002N3_n818NotaFiscaEmitentelDocumento ;
      private string[] T002N3_A808NotaFiscalEmitenteNome ;
      private bool[] T002N3_n808NotaFiscalEmitenteNome ;
      private string[] T002N3_A809NotaFiscalEmitenteLogradouro ;
      private bool[] T002N3_n809NotaFiscalEmitenteLogradouro ;
      private string[] T002N3_A810NotaFiscalEmitenteLogNum ;
      private bool[] T002N3_n810NotaFiscalEmitenteLogNum ;
      private string[] T002N3_A811NotaFiscalEmitenteComplemento ;
      private bool[] T002N3_n811NotaFiscalEmitenteComplemento ;
      private string[] T002N3_A812NotaFiscalEmitenteBairro ;
      private bool[] T002N3_n812NotaFiscalEmitenteBairro ;
      private string[] T002N3_A813NotaFiscalEmitenteMunicipio ;
      private bool[] T002N3_n813NotaFiscalEmitenteMunicipio ;
      private string[] T002N3_A814NotaFiscalEmitenteUF ;
      private bool[] T002N3_n814NotaFiscalEmitenteUF ;
      private string[] T002N3_A815NotaFiscalEmitenteCEP ;
      private bool[] T002N3_n815NotaFiscalEmitenteCEP ;
      private string[] T002N3_A816NotaFiscalEmitentePais ;
      private bool[] T002N3_n816NotaFiscalEmitentePais ;
      private string[] T002N3_A817NotaFiscalEmitenteTelefone ;
      private bool[] T002N3_n817NotaFiscalEmitenteTelefone ;
      private string[] T002N3_A819NotaFiscalEmitenteIE ;
      private bool[] T002N3_n819NotaFiscalEmitenteIE ;
      private string[] T002N3_A820NotaFiscalDestinatarioDocumento ;
      private bool[] T002N3_n820NotaFiscalDestinatarioDocumento ;
      private string[] T002N3_A852NotaFiscalDestinatarioNome ;
      private bool[] T002N3_n852NotaFiscalDestinatarioNome ;
      private string[] T002N3_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] T002N3_n821NotaFiscalDestinatarioLogradouro ;
      private string[] T002N3_A822NotaFiscalDestinatarioLogNum ;
      private bool[] T002N3_n822NotaFiscalDestinatarioLogNum ;
      private string[] T002N3_A823NotaFiscalDestinatarioComplemento ;
      private bool[] T002N3_n823NotaFiscalDestinatarioComplemento ;
      private string[] T002N3_A824NotaFiscalDestinatarioBairro ;
      private bool[] T002N3_n824NotaFiscalDestinatarioBairro ;
      private string[] T002N3_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] T002N3_n825NotaFiscalDestinatarioMunicipio ;
      private string[] T002N3_A826NotaFiscalDestinatarioUF ;
      private bool[] T002N3_n826NotaFiscalDestinatarioUF ;
      private string[] T002N3_A827NotaFiscalDestinatarioCEP ;
      private bool[] T002N3_n827NotaFiscalDestinatarioCEP ;
      private string[] T002N3_A828NotaFiscalDestinatarioPais ;
      private bool[] T002N3_n828NotaFiscalDestinatarioPais ;
      private string[] T002N3_A829NotaFiscalDestinatarioFone ;
      private bool[] T002N3_n829NotaFiscalDestinatarioFone ;
      private int[] T002N3_A168ClienteId ;
      private bool[] T002N3_n168ClienteId ;
      private int[] T002N3_A889NotaFiscalDestinatarioClienteId ;
      private bool[] T002N3_n889NotaFiscalDestinatarioClienteId ;
      private Guid[] T002N20_A794NotaFiscalId ;
      private bool[] T002N20_n794NotaFiscalId ;
      private Guid[] T002N21_A794NotaFiscalId ;
      private bool[] T002N21_n794NotaFiscalId ;
      private Guid[] T002N2_A794NotaFiscalId ;
      private bool[] T002N2_n794NotaFiscalId ;
      private short[] T002N2_A795NotaFiscalUF ;
      private bool[] T002N2_n795NotaFiscalUF ;
      private string[] T002N2_A796NotaFiscalNatureza ;
      private bool[] T002N2_n796NotaFiscalNatureza ;
      private string[] T002N2_A797NotaFiscalMod ;
      private bool[] T002N2_n797NotaFiscalMod ;
      private string[] T002N2_A798NotaFiscalSerie ;
      private bool[] T002N2_n798NotaFiscalSerie ;
      private string[] T002N2_A799NotaFiscalNumero ;
      private bool[] T002N2_n799NotaFiscalNumero ;
      private DateTime[] T002N2_A800NotaFiscalDataEmissao ;
      private bool[] T002N2_n800NotaFiscalDataEmissao ;
      private DateTime[] T002N2_A801NotaFiscalDataSaida ;
      private bool[] T002N2_n801NotaFiscalDataSaida ;
      private string[] T002N2_A802NotaFiscalTipo ;
      private bool[] T002N2_n802NotaFiscalTipo ;
      private string[] T002N2_A803NotaFiscalMunicipio ;
      private bool[] T002N2_n803NotaFiscalMunicipio ;
      private string[] T002N2_A804NotaFiscalTipoEmissao ;
      private bool[] T002N2_n804NotaFiscalTipoEmissao ;
      private short[] T002N2_A805NotaFiscalAmbiente ;
      private bool[] T002N2_n805NotaFiscalAmbiente ;
      private string[] T002N2_A806NotaFiscalFinalidades ;
      private bool[] T002N2_n806NotaFiscalFinalidades ;
      private string[] T002N2_A818NotaFiscaEmitentelDocumento ;
      private bool[] T002N2_n818NotaFiscaEmitentelDocumento ;
      private string[] T002N2_A808NotaFiscalEmitenteNome ;
      private bool[] T002N2_n808NotaFiscalEmitenteNome ;
      private string[] T002N2_A809NotaFiscalEmitenteLogradouro ;
      private bool[] T002N2_n809NotaFiscalEmitenteLogradouro ;
      private string[] T002N2_A810NotaFiscalEmitenteLogNum ;
      private bool[] T002N2_n810NotaFiscalEmitenteLogNum ;
      private string[] T002N2_A811NotaFiscalEmitenteComplemento ;
      private bool[] T002N2_n811NotaFiscalEmitenteComplemento ;
      private string[] T002N2_A812NotaFiscalEmitenteBairro ;
      private bool[] T002N2_n812NotaFiscalEmitenteBairro ;
      private string[] T002N2_A813NotaFiscalEmitenteMunicipio ;
      private bool[] T002N2_n813NotaFiscalEmitenteMunicipio ;
      private string[] T002N2_A814NotaFiscalEmitenteUF ;
      private bool[] T002N2_n814NotaFiscalEmitenteUF ;
      private string[] T002N2_A815NotaFiscalEmitenteCEP ;
      private bool[] T002N2_n815NotaFiscalEmitenteCEP ;
      private string[] T002N2_A816NotaFiscalEmitentePais ;
      private bool[] T002N2_n816NotaFiscalEmitentePais ;
      private string[] T002N2_A817NotaFiscalEmitenteTelefone ;
      private bool[] T002N2_n817NotaFiscalEmitenteTelefone ;
      private string[] T002N2_A819NotaFiscalEmitenteIE ;
      private bool[] T002N2_n819NotaFiscalEmitenteIE ;
      private string[] T002N2_A820NotaFiscalDestinatarioDocumento ;
      private bool[] T002N2_n820NotaFiscalDestinatarioDocumento ;
      private string[] T002N2_A852NotaFiscalDestinatarioNome ;
      private bool[] T002N2_n852NotaFiscalDestinatarioNome ;
      private string[] T002N2_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] T002N2_n821NotaFiscalDestinatarioLogradouro ;
      private string[] T002N2_A822NotaFiscalDestinatarioLogNum ;
      private bool[] T002N2_n822NotaFiscalDestinatarioLogNum ;
      private string[] T002N2_A823NotaFiscalDestinatarioComplemento ;
      private bool[] T002N2_n823NotaFiscalDestinatarioComplemento ;
      private string[] T002N2_A824NotaFiscalDestinatarioBairro ;
      private bool[] T002N2_n824NotaFiscalDestinatarioBairro ;
      private string[] T002N2_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] T002N2_n825NotaFiscalDestinatarioMunicipio ;
      private string[] T002N2_A826NotaFiscalDestinatarioUF ;
      private bool[] T002N2_n826NotaFiscalDestinatarioUF ;
      private string[] T002N2_A827NotaFiscalDestinatarioCEP ;
      private bool[] T002N2_n827NotaFiscalDestinatarioCEP ;
      private string[] T002N2_A828NotaFiscalDestinatarioPais ;
      private bool[] T002N2_n828NotaFiscalDestinatarioPais ;
      private string[] T002N2_A829NotaFiscalDestinatarioFone ;
      private bool[] T002N2_n829NotaFiscalDestinatarioFone ;
      private int[] T002N2_A168ClienteId ;
      private bool[] T002N2_n168ClienteId ;
      private int[] T002N2_A889NotaFiscalDestinatarioClienteId ;
      private bool[] T002N2_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] T002N26_A874NotaFiscalValorTotal_F ;
      private short[] T002N26_A877NotaFiscalQuantidadeDeItens_F ;
      private decimal[] T002N28_A875NotaFiscalValorTotalVendido_F ;
      private short[] T002N28_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private Guid[] T002N29_A890NotaFiscalParcelamentoID ;
      private Guid[] T002N30_A830NotaFiscalItemId ;
      private Guid[] T002N31_A794NotaFiscalId ;
      private bool[] T002N31_n794NotaFiscalId ;
      private int[] T002N32_A168ClienteId ;
      private bool[] T002N32_n168ClienteId ;
      private int[] T002N33_A889NotaFiscalDestinatarioClienteId ;
      private bool[] T002N33_n889NotaFiscalDestinatarioClienteId ;
   }

   public class notafiscal__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002N2;
          prmT002N2 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N3;
          prmT002N3 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N4;
          prmT002N4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002N5;
          prmT002N5 = new Object[] {
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002N7;
          prmT002N7 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N9;
          prmT002N9 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N12;
          prmT002N12 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          string cmdBufferT002N12;
          cmdBufferT002N12=" SELECT TM1.NotaFiscalId, TM1.NotaFiscalUF, TM1.NotaFiscalNatureza, TM1.NotaFiscalMod, TM1.NotaFiscalSerie, TM1.NotaFiscalNumero, TM1.NotaFiscalDataEmissao, TM1.NotaFiscalDataSaida, TM1.NotaFiscalTipo, TM1.NotaFiscalMunicipio, TM1.NotaFiscalTipoEmissao, TM1.NotaFiscalAmbiente, TM1.NotaFiscalFinalidades, TM1.NotaFiscaEmitentelDocumento, TM1.NotaFiscalEmitenteNome, TM1.NotaFiscalEmitenteLogradouro, TM1.NotaFiscalEmitenteLogNum, TM1.NotaFiscalEmitenteComplemento, TM1.NotaFiscalEmitenteBairro, TM1.NotaFiscalEmitenteMunicipio, TM1.NotaFiscalEmitenteUF, TM1.NotaFiscalEmitenteCEP, TM1.NotaFiscalEmitentePais, TM1.NotaFiscalEmitenteTelefone, TM1.NotaFiscalEmitenteIE, TM1.NotaFiscalDestinatarioDocumento, TM1.NotaFiscalDestinatarioNome, TM1.NotaFiscalDestinatarioLogradouro, TM1.NotaFiscalDestinatarioLogNum, TM1.NotaFiscalDestinatarioComplemento, TM1.NotaFiscalDestinatarioBairro, TM1.NotaFiscalDestinatarioMunicipio, TM1.NotaFiscalDestinatarioUF, TM1.NotaFiscalDestinatarioCEP, TM1.NotaFiscalDestinatarioPais, TM1.NotaFiscalDestinatarioFone, TM1.ClienteId, TM1.NotaFiscalDestinatarioClienteId AS NotaFiscalDestinatarioClienteId, COALESCE( T2.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T2.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T3.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM ((NotaFiscal TM1 LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE TM1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T2 ON T2.NotaFiscalId = TM1.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, "
          + " NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE (TM1.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = TM1.NotaFiscalId) WHERE TM1.NotaFiscalId = :NotaFiscalId ORDER BY TM1.NotaFiscalId" ;
          Object[] prmT002N14;
          prmT002N14 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N16;
          prmT002N16 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N17;
          prmT002N17 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002N18;
          prmT002N18 = new Object[] {
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002N19;
          prmT002N19 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N20;
          prmT002N20 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N21;
          prmT002N21 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N22;
          prmT002N22 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalUF",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalNatureza",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalMod",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalSerie",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalNumero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDataEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalDataSaida",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalTipoEmissao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalAmbiente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalFinalidades",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscaEmitentelDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitentePais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteTelefone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteIE",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioPais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioFone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT002N22;
          cmdBufferT002N22=" SAVEPOINT gxupdate;INSERT INTO NotaFiscal(NotaFiscalId, NotaFiscalUF, NotaFiscalNatureza, NotaFiscalMod, NotaFiscalSerie, NotaFiscalNumero, NotaFiscalDataEmissao, NotaFiscalDataSaida, NotaFiscalTipo, NotaFiscalMunicipio, NotaFiscalTipoEmissao, NotaFiscalAmbiente, NotaFiscalFinalidades, NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP, NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone, ClienteId, NotaFiscalDestinatarioClienteId) VALUES(:NotaFiscalId, :NotaFiscalUF, :NotaFiscalNatureza, :NotaFiscalMod, :NotaFiscalSerie, :NotaFiscalNumero, :NotaFiscalDataEmissao, :NotaFiscalDataSaida, :NotaFiscalTipo, :NotaFiscalMunicipio, :NotaFiscalTipoEmissao, :NotaFiscalAmbiente, :NotaFiscalFinalidades, :NotaFiscaEmitentelDocumento, :NotaFiscalEmitenteNome, :NotaFiscalEmitenteLogradouro, :NotaFiscalEmitenteLogNum, :NotaFiscalEmitenteComplemento, :NotaFiscalEmitenteBairro, :NotaFiscalEmitenteMunicipio, :NotaFiscalEmitenteUF, :NotaFiscalEmitenteCEP, :NotaFiscalEmitentePais, :NotaFiscalEmitenteTelefone, :NotaFiscalEmitenteIE, :NotaFiscalDestinatarioDocumento, :NotaFiscalDestinatarioNome, :NotaFiscalDestinatarioLogradouro, :NotaFiscalDestinatarioLogNum, :NotaFiscalDestinatarioComplemento, :NotaFiscalDestinatarioBairro, :NotaFiscalDestinatarioMunicipio, :NotaFiscalDestinatarioUF, "
          + " :NotaFiscalDestinatarioCEP, :NotaFiscalDestinatarioPais, :NotaFiscalDestinatarioFone, :ClienteId, :NotaFiscalDestinatarioClienteId);RELEASE SAVEPOINT gxupdate" ;
          Object[] prmT002N23;
          prmT002N23 = new Object[] {
          new ParDef("NotaFiscalUF",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalNatureza",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalMod",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalSerie",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalNumero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDataEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalDataSaida",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalTipoEmissao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalAmbiente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalFinalidades",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscaEmitentelDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitentePais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteTelefone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteIE",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioPais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioFone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          string cmdBufferT002N23;
          cmdBufferT002N23=" SAVEPOINT gxupdate;UPDATE NotaFiscal SET NotaFiscalUF=:NotaFiscalUF, NotaFiscalNatureza=:NotaFiscalNatureza, NotaFiscalMod=:NotaFiscalMod, NotaFiscalSerie=:NotaFiscalSerie, NotaFiscalNumero=:NotaFiscalNumero, NotaFiscalDataEmissao=:NotaFiscalDataEmissao, NotaFiscalDataSaida=:NotaFiscalDataSaida, NotaFiscalTipo=:NotaFiscalTipo, NotaFiscalMunicipio=:NotaFiscalMunicipio, NotaFiscalTipoEmissao=:NotaFiscalTipoEmissao, NotaFiscalAmbiente=:NotaFiscalAmbiente, NotaFiscalFinalidades=:NotaFiscalFinalidades, NotaFiscaEmitentelDocumento=:NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome=:NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro=:NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum=:NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento=:NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro=:NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio=:NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF=:NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP=:NotaFiscalEmitenteCEP, NotaFiscalEmitentePais=:NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone=:NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE=:NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento=:NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome=:NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro=:NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum=:NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento=:NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro=:NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio=:NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF=:NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP=:NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais=:NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone=:NotaFiscalDestinatarioFone, ClienteId=:ClienteId, "
          + " NotaFiscalDestinatarioClienteId=:NotaFiscalDestinatarioClienteId  WHERE NotaFiscalId = :NotaFiscalId;RELEASE SAVEPOINT gxupdate" ;
          Object[] prmT002N24;
          prmT002N24 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N26;
          prmT002N26 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N28;
          prmT002N28 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N29;
          prmT002N29 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N30;
          prmT002N30 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002N31;
          prmT002N31 = new Object[] {
          };
          Object[] prmT002N32;
          prmT002N32 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002N33;
          prmT002N33 = new Object[] {
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002N2", "SELECT NotaFiscalId, NotaFiscalUF, NotaFiscalNatureza, NotaFiscalMod, NotaFiscalSerie, NotaFiscalNumero, NotaFiscalDataEmissao, NotaFiscalDataSaida, NotaFiscalTipo, NotaFiscalMunicipio, NotaFiscalTipoEmissao, NotaFiscalAmbiente, NotaFiscalFinalidades, NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP, NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone, ClienteId, NotaFiscalDestinatarioClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId  FOR UPDATE OF NotaFiscal NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N3", "SELECT NotaFiscalId, NotaFiscalUF, NotaFiscalNatureza, NotaFiscalMod, NotaFiscalSerie, NotaFiscalNumero, NotaFiscalDataEmissao, NotaFiscalDataSaida, NotaFiscalTipo, NotaFiscalMunicipio, NotaFiscalTipoEmissao, NotaFiscalAmbiente, NotaFiscalFinalidades, NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP, NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone, ClienteId, NotaFiscalDestinatarioClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N4", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N5", "SELECT ClienteId AS NotaFiscalDestinatarioClienteId FROM Cliente WHERE ClienteId = :NotaFiscalDestinatarioClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N7", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N9", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE NotaFiscalItemVendido = ( 'VENDIDO') GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N12", cmdBufferT002N12,true, GxErrorMask.GX_NOMASK, false, this,prmT002N12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N14", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N16", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE NotaFiscalItemVendido = ( 'VENDIDO') GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N17", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N18", "SELECT ClienteId AS NotaFiscalDestinatarioClienteId FROM Cliente WHERE ClienteId = :NotaFiscalDestinatarioClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N19", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N20", "SELECT NotaFiscalId FROM NotaFiscal WHERE ( NotaFiscalId > :NotaFiscalId) ORDER BY NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002N21", "SELECT NotaFiscalId FROM NotaFiscal WHERE ( NotaFiscalId < :NotaFiscalId) ORDER BY NotaFiscalId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002N22", cmdBufferT002N22, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002N22)
             ,new CursorDef("T002N23", cmdBufferT002N23, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002N23)
             ,new CursorDef("T002N24", "SAVEPOINT gxupdate;DELETE FROM NotaFiscal  WHERE NotaFiscalId = :NotaFiscalId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002N24)
             ,new CursorDef("T002N26", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N28", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE NotaFiscalItemVendido = ( 'VENDIDO') GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N29", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002N30", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002N31", "SELECT NotaFiscalId FROM NotaFiscal ORDER BY NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N31,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N32", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002N33", "SELECT ClienteId AS NotaFiscalDestinatarioClienteId FROM Cliente WHERE ClienteId = :NotaFiscalDestinatarioClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N33,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((decimal[]) buf[75])[0] = rslt.getDecimal(39);
                ((decimal[]) buf[76])[0] = rslt.getDecimal(40);
                ((short[]) buf[77])[0] = rslt.getShort(41);
                ((short[]) buf[78])[0] = rslt.getShort(42);
                return;
             case 7 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 12 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 13 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 20 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 21 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
