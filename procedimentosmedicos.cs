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
   public class procedimentosmedicos : GXDataArea
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
         Form.Meta.addItem("description", "Procedimentos Medicos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProcedimentosMedicosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public procedimentosmedicos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procedimentosmedicos( IGxContext context )
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
         chkProcedimentosMedicosAtivo = new GXCheckbox();
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
         A409ProcedimentosMedicosAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A409ProcedimentosMedicosAtivo));
         AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Procedimentos Medicos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ProcedimentosMedicos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ProcedimentosMedicos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProcedimentosMedicosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProcedimentosMedicosId_Internalname, "Medicos Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProcedimentosMedicosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtProcedimentosMedicosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProcedimentosMedicosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProcedimentosMedicosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProcedimentosMedicosNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProcedimentosMedicosNome_Internalname, "Medicos Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProcedimentosMedicosNome_Internalname, A377ProcedimentosMedicosNome, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtProcedimentosMedicosNome_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProcedimentosMedicosDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProcedimentosMedicosDescricao_Internalname, "Medicos Descricao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProcedimentosMedicosDescricao_Internalname, A378ProcedimentosMedicosDescricao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtProcedimentosMedicosDescricao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProcedimentosMedicosArea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProcedimentosMedicosArea_Internalname, "Medicos Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProcedimentosMedicosArea_Internalname, A379ProcedimentosMedicosArea, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtProcedimentosMedicosArea_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCID_Internalname, "CID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCID_Internalname, ((0==A408CID)&&IsIns( )||n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ",", ""))), ((0==A408CID)&&IsIns( )||n408CID ? "" : StringUtil.LTrim( ((edtCID_Enabled!=0) ? context.localUtil.Format( (decimal)(A408CID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A408CID), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkProcedimentosMedicosAtivo_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProcedimentosMedicosAtivo_Internalname, StringUtil.BoolToStr( A409ProcedimentosMedicosAtivo), "", "", 1, chkProcedimentosMedicosAtivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProcedimentosMedicos.htm");
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
            Z376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z376ProcedimentosMedicosId"), ",", "."), 18, MidpointRounding.ToEven));
            Z377ProcedimentosMedicosNome = cgiGet( "Z377ProcedimentosMedicosNome");
            n377ProcedimentosMedicosNome = (String.IsNullOrEmpty(StringUtil.RTrim( A377ProcedimentosMedicosNome)) ? true : false);
            Z379ProcedimentosMedicosArea = cgiGet( "Z379ProcedimentosMedicosArea");
            n379ProcedimentosMedicosArea = (String.IsNullOrEmpty(StringUtil.RTrim( A379ProcedimentosMedicosArea)) ? true : false);
            Z408CID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z408CID"), ",", "."), 18, MidpointRounding.ToEven));
            n408CID = ((0==A408CID) ? true : false);
            Z409ProcedimentosMedicosAtivo = StringUtil.StrToBool( cgiGet( "Z409ProcedimentosMedicosAtivo"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCEDIMENTOSMEDICOSID");
               AnyError = 1;
               GX_FocusControl = edtProcedimentosMedicosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A376ProcedimentosMedicosId = 0;
               n376ProcedimentosMedicosId = false;
               AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            }
            else
            {
               A376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n376ProcedimentosMedicosId = false;
               AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            }
            A377ProcedimentosMedicosNome = cgiGet( edtProcedimentosMedicosNome_Internalname);
            n377ProcedimentosMedicosNome = false;
            AssignAttri("", false, "A377ProcedimentosMedicosNome", A377ProcedimentosMedicosNome);
            n377ProcedimentosMedicosNome = (String.IsNullOrEmpty(StringUtil.RTrim( A377ProcedimentosMedicosNome)) ? true : false);
            A378ProcedimentosMedicosDescricao = cgiGet( edtProcedimentosMedicosDescricao_Internalname);
            n378ProcedimentosMedicosDescricao = false;
            AssignAttri("", false, "A378ProcedimentosMedicosDescricao", A378ProcedimentosMedicosDescricao);
            n378ProcedimentosMedicosDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A378ProcedimentosMedicosDescricao)) ? true : false);
            A379ProcedimentosMedicosArea = cgiGet( edtProcedimentosMedicosArea_Internalname);
            n379ProcedimentosMedicosArea = false;
            AssignAttri("", false, "A379ProcedimentosMedicosArea", A379ProcedimentosMedicosArea);
            n379ProcedimentosMedicosArea = (String.IsNullOrEmpty(StringUtil.RTrim( A379ProcedimentosMedicosArea)) ? true : false);
            n408CID = ((StringUtil.StrCmp(cgiGet( edtCID_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CID");
               AnyError = 1;
               GX_FocusControl = edtCID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A408CID = 0;
               n408CID = false;
               AssignAttri("", false, "A408CID", (n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ".", ""))));
            }
            else
            {
               A408CID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A408CID", (n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ".", ""))));
            }
            A409ProcedimentosMedicosAtivo = StringUtil.StrToBool( cgiGet( chkProcedimentosMedicosAtivo_Internalname));
            AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
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
               A376ProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProcedimentosMedicosId"), "."), 18, MidpointRounding.ToEven));
               n376ProcedimentosMedicosId = false;
               AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
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
               InitAll1F54( ) ;
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
         DisableAttributes1F54( ) ;
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

      protected void ResetCaption1F0( )
      {
      }

      protected void ZM1F54( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z377ProcedimentosMedicosNome = T001F3_A377ProcedimentosMedicosNome[0];
               Z379ProcedimentosMedicosArea = T001F3_A379ProcedimentosMedicosArea[0];
               Z408CID = T001F3_A408CID[0];
               Z409ProcedimentosMedicosAtivo = T001F3_A409ProcedimentosMedicosAtivo[0];
            }
            else
            {
               Z377ProcedimentosMedicosNome = A377ProcedimentosMedicosNome;
               Z379ProcedimentosMedicosArea = A379ProcedimentosMedicosArea;
               Z408CID = A408CID;
               Z409ProcedimentosMedicosAtivo = A409ProcedimentosMedicosAtivo;
            }
         }
         if ( GX_JID == -1 )
         {
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z377ProcedimentosMedicosNome = A377ProcedimentosMedicosNome;
            Z378ProcedimentosMedicosDescricao = A378ProcedimentosMedicosDescricao;
            Z379ProcedimentosMedicosArea = A379ProcedimentosMedicosArea;
            Z408CID = A408CID;
            Z409ProcedimentosMedicosAtivo = A409ProcedimentosMedicosAtivo;
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

      protected void Load1F54( )
      {
         /* Using cursor T001F4 */
         pr_default.execute(2, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound54 = 1;
            A377ProcedimentosMedicosNome = T001F4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = T001F4_n377ProcedimentosMedicosNome[0];
            AssignAttri("", false, "A377ProcedimentosMedicosNome", A377ProcedimentosMedicosNome);
            A378ProcedimentosMedicosDescricao = T001F4_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = T001F4_n378ProcedimentosMedicosDescricao[0];
            AssignAttri("", false, "A378ProcedimentosMedicosDescricao", A378ProcedimentosMedicosDescricao);
            A379ProcedimentosMedicosArea = T001F4_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = T001F4_n379ProcedimentosMedicosArea[0];
            AssignAttri("", false, "A379ProcedimentosMedicosArea", A379ProcedimentosMedicosArea);
            A408CID = T001F4_A408CID[0];
            n408CID = T001F4_n408CID[0];
            AssignAttri("", false, "A408CID", ((0==A408CID)&&IsIns( )||n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ".", ""))));
            A409ProcedimentosMedicosAtivo = T001F4_A409ProcedimentosMedicosAtivo[0];
            AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
            ZM1F54( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1F54( ) ;
      }

      protected void OnLoadActions1F54( )
      {
      }

      protected void CheckExtendedTable1F54( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1F54( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1F54( )
      {
         /* Using cursor T001F5 */
         pr_default.execute(3, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound54 = 1;
         }
         else
         {
            RcdFound54 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001F3 */
         pr_default.execute(1, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F54( 1) ;
            RcdFound54 = 1;
            A376ProcedimentosMedicosId = T001F3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001F3_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            A377ProcedimentosMedicosNome = T001F3_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = T001F3_n377ProcedimentosMedicosNome[0];
            AssignAttri("", false, "A377ProcedimentosMedicosNome", A377ProcedimentosMedicosNome);
            A378ProcedimentosMedicosDescricao = T001F3_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = T001F3_n378ProcedimentosMedicosDescricao[0];
            AssignAttri("", false, "A378ProcedimentosMedicosDescricao", A378ProcedimentosMedicosDescricao);
            A379ProcedimentosMedicosArea = T001F3_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = T001F3_n379ProcedimentosMedicosArea[0];
            AssignAttri("", false, "A379ProcedimentosMedicosArea", A379ProcedimentosMedicosArea);
            A408CID = T001F3_A408CID[0];
            n408CID = T001F3_n408CID[0];
            AssignAttri("", false, "A408CID", ((0==A408CID)&&IsIns( )||n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ".", ""))));
            A409ProcedimentosMedicosAtivo = T001F3_A409ProcedimentosMedicosAtivo[0];
            AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1F54( ) ;
            if ( AnyError == 1 )
            {
               RcdFound54 = 0;
               InitializeNonKey1F54( ) ;
            }
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound54 = 0;
            InitializeNonKey1F54( ) ;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F54( ) ;
         if ( RcdFound54 == 0 )
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
         RcdFound54 = 0;
         /* Using cursor T001F6 */
         pr_default.execute(4, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001F6_A376ProcedimentosMedicosId[0] < A376ProcedimentosMedicosId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001F6_A376ProcedimentosMedicosId[0] > A376ProcedimentosMedicosId ) ) )
            {
               A376ProcedimentosMedicosId = T001F6_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = T001F6_n376ProcedimentosMedicosId[0];
               AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
               RcdFound54 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound54 = 0;
         /* Using cursor T001F7 */
         pr_default.execute(5, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001F7_A376ProcedimentosMedicosId[0] > A376ProcedimentosMedicosId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001F7_A376ProcedimentosMedicosId[0] < A376ProcedimentosMedicosId ) ) )
            {
               A376ProcedimentosMedicosId = T001F7_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = T001F7_n376ProcedimentosMedicosId[0];
               AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
               RcdFound54 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1F54( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProcedimentosMedicosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1F54( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound54 == 1 )
            {
               if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
               {
                  A376ProcedimentosMedicosId = Z376ProcedimentosMedicosId;
                  n376ProcedimentosMedicosId = false;
                  AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
                  AnyError = 1;
                  GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1F54( ) ;
                  GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1F54( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCEDIMENTOSMEDICOSID");
                     AnyError = 1;
                     GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1F54( ) ;
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
         if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
         {
            A376ProcedimentosMedicosId = Z376ProcedimentosMedicosId;
            n376ProcedimentosMedicosId = false;
            AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCEDIMENTOSMEDICOSID");
            AnyError = 1;
            GX_FocusControl = edtProcedimentosMedicosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProcedimentosMedicosId_Internalname;
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
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
            AnyError = 1;
            GX_FocusControl = edtProcedimentosMedicosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProcedimentosMedicosNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1F54( ) ;
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProcedimentosMedicosNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1F54( ) ;
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
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProcedimentosMedicosNome_Internalname;
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
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProcedimentosMedicosNome_Internalname;
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
         ScanStart1F54( ) ;
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound54 != 0 )
            {
               ScanNext1F54( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProcedimentosMedicosNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1F54( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1F54( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001F2 */
            pr_default.execute(0, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProcedimentosMedicos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z377ProcedimentosMedicosNome, T001F2_A377ProcedimentosMedicosNome[0]) != 0 ) || ( StringUtil.StrCmp(Z379ProcedimentosMedicosArea, T001F2_A379ProcedimentosMedicosArea[0]) != 0 ) || ( Z408CID != T001F2_A408CID[0] ) || ( Z409ProcedimentosMedicosAtivo != T001F2_A409ProcedimentosMedicosAtivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z377ProcedimentosMedicosNome, T001F2_A377ProcedimentosMedicosNome[0]) != 0 )
               {
                  GXUtil.WriteLog("procedimentosmedicos:[seudo value changed for attri]"+"ProcedimentosMedicosNome");
                  GXUtil.WriteLogRaw("Old: ",Z377ProcedimentosMedicosNome);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A377ProcedimentosMedicosNome[0]);
               }
               if ( StringUtil.StrCmp(Z379ProcedimentosMedicosArea, T001F2_A379ProcedimentosMedicosArea[0]) != 0 )
               {
                  GXUtil.WriteLog("procedimentosmedicos:[seudo value changed for attri]"+"ProcedimentosMedicosArea");
                  GXUtil.WriteLogRaw("Old: ",Z379ProcedimentosMedicosArea);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A379ProcedimentosMedicosArea[0]);
               }
               if ( Z408CID != T001F2_A408CID[0] )
               {
                  GXUtil.WriteLog("procedimentosmedicos:[seudo value changed for attri]"+"CID");
                  GXUtil.WriteLogRaw("Old: ",Z408CID);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A408CID[0]);
               }
               if ( Z409ProcedimentosMedicosAtivo != T001F2_A409ProcedimentosMedicosAtivo[0] )
               {
                  GXUtil.WriteLog("procedimentosmedicos:[seudo value changed for attri]"+"ProcedimentosMedicosAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z409ProcedimentosMedicosAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A409ProcedimentosMedicosAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProcedimentosMedicos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F54( )
      {
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F54( 0) ;
            CheckOptimisticConcurrency1F54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F8 */
                     pr_default.execute(6, new Object[] {n377ProcedimentosMedicosNome, A377ProcedimentosMedicosNome, n378ProcedimentosMedicosDescricao, A378ProcedimentosMedicosDescricao, n379ProcedimentosMedicosArea, A379ProcedimentosMedicosArea, n408CID, A408CID, A409ProcedimentosMedicosAtivo});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001F9 */
                     pr_default.execute(7);
                     A376ProcedimentosMedicosId = T001F9_A376ProcedimentosMedicosId[0];
                     n376ProcedimentosMedicosId = T001F9_n376ProcedimentosMedicosId[0];
                     AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ProcedimentosMedicos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1F0( ) ;
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
               Load1F54( ) ;
            }
            EndLevel1F54( ) ;
         }
         CloseExtendedTableCursors1F54( ) ;
      }

      protected void Update1F54( )
      {
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F10 */
                     pr_default.execute(8, new Object[] {n377ProcedimentosMedicosNome, A377ProcedimentosMedicosNome, n378ProcedimentosMedicosDescricao, A378ProcedimentosMedicosDescricao, n379ProcedimentosMedicosArea, A379ProcedimentosMedicosArea, n408CID, A408CID, A409ProcedimentosMedicosAtivo, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ProcedimentosMedicos");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProcedimentosMedicos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F54( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1F0( ) ;
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
            EndLevel1F54( ) ;
         }
         CloseExtendedTableCursors1F54( ) ;
      }

      protected void DeferredUpdate1F54( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F54( ) ;
            AfterConfirm1F54( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F54( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001F11 */
                  pr_default.execute(9, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("ProcedimentosMedicos");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound54 == 0 )
                        {
                           InitAll1F54( ) ;
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
                        ResetCaption1F0( ) ;
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
         sMode54 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1F54( ) ;
         Gx_mode = sMode54;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1F54( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001F12 */
            pr_default.execute(10, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1F54( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1F0( ) ;
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

      public void ScanStart1F54( )
      {
         /* Using cursor T001F13 */
         pr_default.execute(11);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound54 = 1;
            A376ProcedimentosMedicosId = T001F13_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001F13_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1F54( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound54 = 1;
            A376ProcedimentosMedicosId = T001F13_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001F13_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
         }
      }

      protected void ScanEnd1F54( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1F54( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F54( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F54( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F54( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F54( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F54( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F54( )
      {
         edtProcedimentosMedicosId_Enabled = 0;
         AssignProp("", false, edtProcedimentosMedicosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosId_Enabled), 5, 0), true);
         edtProcedimentosMedicosNome_Enabled = 0;
         AssignProp("", false, edtProcedimentosMedicosNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosNome_Enabled), 5, 0), true);
         edtProcedimentosMedicosDescricao_Enabled = 0;
         AssignProp("", false, edtProcedimentosMedicosDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosDescricao_Enabled), 5, 0), true);
         edtProcedimentosMedicosArea_Enabled = 0;
         AssignProp("", false, edtProcedimentosMedicosArea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosArea_Enabled), 5, 0), true);
         edtCID_Enabled = 0;
         AssignProp("", false, edtCID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCID_Enabled), 5, 0), true);
         chkProcedimentosMedicosAtivo.Enabled = 0;
         AssignProp("", false, chkProcedimentosMedicosAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProcedimentosMedicosAtivo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1F54( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1F0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("procedimentosmedicos") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z376ProcedimentosMedicosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z377ProcedimentosMedicosNome", Z377ProcedimentosMedicosNome);
         GxWebStd.gx_hidden_field( context, "Z379ProcedimentosMedicosArea", Z379ProcedimentosMedicosArea);
         GxWebStd.gx_hidden_field( context, "Z408CID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z408CID), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z409ProcedimentosMedicosAtivo", Z409ProcedimentosMedicosAtivo);
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
         return formatLink("procedimentosmedicos")  ;
      }

      public override string GetPgmname( )
      {
         return "ProcedimentosMedicos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Procedimentos Medicos" ;
      }

      protected void InitializeNonKey1F54( )
      {
         A377ProcedimentosMedicosNome = "";
         n377ProcedimentosMedicosNome = false;
         AssignAttri("", false, "A377ProcedimentosMedicosNome", A377ProcedimentosMedicosNome);
         n377ProcedimentosMedicosNome = (String.IsNullOrEmpty(StringUtil.RTrim( A377ProcedimentosMedicosNome)) ? true : false);
         A378ProcedimentosMedicosDescricao = "";
         n378ProcedimentosMedicosDescricao = false;
         AssignAttri("", false, "A378ProcedimentosMedicosDescricao", A378ProcedimentosMedicosDescricao);
         n378ProcedimentosMedicosDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A378ProcedimentosMedicosDescricao)) ? true : false);
         A379ProcedimentosMedicosArea = "";
         n379ProcedimentosMedicosArea = false;
         AssignAttri("", false, "A379ProcedimentosMedicosArea", A379ProcedimentosMedicosArea);
         n379ProcedimentosMedicosArea = (String.IsNullOrEmpty(StringUtil.RTrim( A379ProcedimentosMedicosArea)) ? true : false);
         A408CID = 0;
         n408CID = false;
         AssignAttri("", false, "A408CID", ((0==A408CID)&&IsIns( )||n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ".", ""))));
         n408CID = ((0==A408CID) ? true : false);
         A409ProcedimentosMedicosAtivo = false;
         AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
         Z377ProcedimentosMedicosNome = "";
         Z379ProcedimentosMedicosArea = "";
         Z408CID = 0;
         Z409ProcedimentosMedicosAtivo = false;
      }

      protected void InitAll1F54( )
      {
         A376ProcedimentosMedicosId = 0;
         n376ProcedimentosMedicosId = false;
         AssignAttri("", false, "A376ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(A376ProcedimentosMedicosId), 9, 0));
         InitializeNonKey1F54( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019161591", true, true);
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
         context.AddJavascriptSource("procedimentosmedicos.js", "?202561019161592", false, true);
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
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID";
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME";
         edtProcedimentosMedicosDescricao_Internalname = "PROCEDIMENTOSMEDICOSDESCRICAO";
         edtProcedimentosMedicosArea_Internalname = "PROCEDIMENTOSMEDICOSAREA";
         edtCID_Internalname = "CID";
         chkProcedimentosMedicosAtivo_Internalname = "PROCEDIMENTOSMEDICOSATIVO";
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
         Form.Caption = "Procedimentos Medicos";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkProcedimentosMedicosAtivo.Enabled = 1;
         edtCID_Jsonclick = "";
         edtCID_Enabled = 1;
         edtProcedimentosMedicosArea_Enabled = 1;
         edtProcedimentosMedicosDescricao_Enabled = 1;
         edtProcedimentosMedicosNome_Enabled = 1;
         edtProcedimentosMedicosId_Jsonclick = "";
         edtProcedimentosMedicosId_Enabled = 1;
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
         chkProcedimentosMedicosAtivo.Name = "PROCEDIMENTOSMEDICOSATIVO";
         chkProcedimentosMedicosAtivo.WebTags = "";
         chkProcedimentosMedicosAtivo.Caption = "";
         AssignProp("", false, chkProcedimentosMedicosAtivo_Internalname, "TitleCaption", chkProcedimentosMedicosAtivo.Caption, true);
         chkProcedimentosMedicosAtivo.CheckedValue = "false";
         A409ProcedimentosMedicosAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A409ProcedimentosMedicosAtivo));
         AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtProcedimentosMedicosNome_Internalname;
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

      public void Valid_Procedimentosmedicosid( )
      {
         n376ProcedimentosMedicosId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A409ProcedimentosMedicosAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A409ProcedimentosMedicosAtivo));
         /*  Sending validation outputs */
         AssignAttri("", false, "A377ProcedimentosMedicosNome", A377ProcedimentosMedicosNome);
         AssignAttri("", false, "A378ProcedimentosMedicosDescricao", A378ProcedimentosMedicosDescricao);
         AssignAttri("", false, "A379ProcedimentosMedicosArea", A379ProcedimentosMedicosArea);
         AssignAttri("", false, "A408CID", ((0==A408CID)&&IsIns( )||n408CID ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A408CID), 9, 0, ".", ""))));
         AssignAttri("", false, "A409ProcedimentosMedicosAtivo", A409ProcedimentosMedicosAtivo);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z376ProcedimentosMedicosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ProcedimentosMedicosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z377ProcedimentosMedicosNome", Z377ProcedimentosMedicosNome);
         GxWebStd.gx_hidden_field( context, "Z378ProcedimentosMedicosDescricao", Z378ProcedimentosMedicosDescricao);
         GxWebStd.gx_hidden_field( context, "Z379ProcedimentosMedicosArea", Z379ProcedimentosMedicosArea);
         GxWebStd.gx_hidden_field( context, "Z408CID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z408CID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z409ProcedimentosMedicosAtivo", StringUtil.BoolToStr( Z409ProcedimentosMedicosAtivo));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A409ProcedimentosMedicosAtivo","fld":"PROCEDIMENTOSMEDICOSATIVO","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A409ProcedimentosMedicosAtivo","fld":"PROCEDIMENTOSMEDICOSATIVO","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A409ProcedimentosMedicosAtivo","fld":"PROCEDIMENTOSMEDICOSATIVO","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A409ProcedimentosMedicosAtivo","fld":"PROCEDIMENTOSMEDICOSATIVO","type":"boolean"}]}""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID","""{"handler":"Valid_Procedimentosmedicosid","iparms":[{"av":"A376ProcedimentosMedicosId","fld":"PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A409ProcedimentosMedicosAtivo","fld":"PROCEDIMENTOSMEDICOSATIVO","type":"boolean"}]""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID",""","oparms":[{"av":"A377ProcedimentosMedicosNome","fld":"PROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"A378ProcedimentosMedicosDescricao","fld":"PROCEDIMENTOSMEDICOSDESCRICAO","type":"vchar"},{"av":"A379ProcedimentosMedicosArea","fld":"PROCEDIMENTOSMEDICOSAREA","type":"svchar"},{"av":"A408CID","fld":"CID","pic":"ZZZZZZZZ9","nullAv":"n408CID","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z376ProcedimentosMedicosId","type":"int"},{"av":"Z377ProcedimentosMedicosNome","type":"svchar"},{"av":"Z378ProcedimentosMedicosDescricao","type":"vchar"},{"av":"Z379ProcedimentosMedicosArea","type":"svchar"},{"av":"Z408CID","type":"int"},{"av":"Z409ProcedimentosMedicosAtivo","type":"boolean"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A409ProcedimentosMedicosAtivo","fld":"PROCEDIMENTOSMEDICOSATIVO","type":"boolean"}]}""");
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
         Z377ProcedimentosMedicosNome = "";
         Z379ProcedimentosMedicosArea = "";
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
         A377ProcedimentosMedicosNome = "";
         A378ProcedimentosMedicosDescricao = "";
         A379ProcedimentosMedicosArea = "";
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
         Z378ProcedimentosMedicosDescricao = "";
         T001F4_A376ProcedimentosMedicosId = new int[1] ;
         T001F4_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F4_A377ProcedimentosMedicosNome = new string[] {""} ;
         T001F4_n377ProcedimentosMedicosNome = new bool[] {false} ;
         T001F4_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         T001F4_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         T001F4_A379ProcedimentosMedicosArea = new string[] {""} ;
         T001F4_n379ProcedimentosMedicosArea = new bool[] {false} ;
         T001F4_A408CID = new int[1] ;
         T001F4_n408CID = new bool[] {false} ;
         T001F4_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         T001F5_A376ProcedimentosMedicosId = new int[1] ;
         T001F5_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F3_A376ProcedimentosMedicosId = new int[1] ;
         T001F3_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F3_A377ProcedimentosMedicosNome = new string[] {""} ;
         T001F3_n377ProcedimentosMedicosNome = new bool[] {false} ;
         T001F3_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         T001F3_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         T001F3_A379ProcedimentosMedicosArea = new string[] {""} ;
         T001F3_n379ProcedimentosMedicosArea = new bool[] {false} ;
         T001F3_A408CID = new int[1] ;
         T001F3_n408CID = new bool[] {false} ;
         T001F3_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         sMode54 = "";
         T001F6_A376ProcedimentosMedicosId = new int[1] ;
         T001F6_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F7_A376ProcedimentosMedicosId = new int[1] ;
         T001F7_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F2_A376ProcedimentosMedicosId = new int[1] ;
         T001F2_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F2_A377ProcedimentosMedicosNome = new string[] {""} ;
         T001F2_n377ProcedimentosMedicosNome = new bool[] {false} ;
         T001F2_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         T001F2_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         T001F2_A379ProcedimentosMedicosArea = new string[] {""} ;
         T001F2_n379ProcedimentosMedicosArea = new bool[] {false} ;
         T001F2_A408CID = new int[1] ;
         T001F2_n408CID = new bool[] {false} ;
         T001F2_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         T001F9_A376ProcedimentosMedicosId = new int[1] ;
         T001F9_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001F12_A323PropostaId = new int[1] ;
         T001F13_A376ProcedimentosMedicosId = new int[1] ;
         T001F13_n376ProcedimentosMedicosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ377ProcedimentosMedicosNome = "";
         ZZ378ProcedimentosMedicosDescricao = "";
         ZZ379ProcedimentosMedicosArea = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procedimentosmedicos__default(),
            new Object[][] {
                new Object[] {
               T001F2_A376ProcedimentosMedicosId, T001F2_A377ProcedimentosMedicosNome, T001F2_n377ProcedimentosMedicosNome, T001F2_A378ProcedimentosMedicosDescricao, T001F2_n378ProcedimentosMedicosDescricao, T001F2_A379ProcedimentosMedicosArea, T001F2_n379ProcedimentosMedicosArea, T001F2_A408CID, T001F2_n408CID, T001F2_A409ProcedimentosMedicosAtivo
               }
               , new Object[] {
               T001F3_A376ProcedimentosMedicosId, T001F3_A377ProcedimentosMedicosNome, T001F3_n377ProcedimentosMedicosNome, T001F3_A378ProcedimentosMedicosDescricao, T001F3_n378ProcedimentosMedicosDescricao, T001F3_A379ProcedimentosMedicosArea, T001F3_n379ProcedimentosMedicosArea, T001F3_A408CID, T001F3_n408CID, T001F3_A409ProcedimentosMedicosAtivo
               }
               , new Object[] {
               T001F4_A376ProcedimentosMedicosId, T001F4_A377ProcedimentosMedicosNome, T001F4_n377ProcedimentosMedicosNome, T001F4_A378ProcedimentosMedicosDescricao, T001F4_n378ProcedimentosMedicosDescricao, T001F4_A379ProcedimentosMedicosArea, T001F4_n379ProcedimentosMedicosArea, T001F4_A408CID, T001F4_n408CID, T001F4_A409ProcedimentosMedicosAtivo
               }
               , new Object[] {
               T001F5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               T001F6_A376ProcedimentosMedicosId
               }
               , new Object[] {
               T001F7_A376ProcedimentosMedicosId
               }
               , new Object[] {
               }
               , new Object[] {
               T001F9_A376ProcedimentosMedicosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001F12_A323PropostaId
               }
               , new Object[] {
               T001F13_A376ProcedimentosMedicosId
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
      private short RcdFound54 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z376ProcedimentosMedicosId ;
      private int Z408CID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A376ProcedimentosMedicosId ;
      private int edtProcedimentosMedicosId_Enabled ;
      private int edtProcedimentosMedicosNome_Enabled ;
      private int edtProcedimentosMedicosDescricao_Enabled ;
      private int edtProcedimentosMedicosArea_Enabled ;
      private int A408CID ;
      private int edtCID_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ376ProcedimentosMedicosId ;
      private int ZZ408CID ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProcedimentosMedicosId_Internalname ;
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
      private string edtProcedimentosMedicosId_Jsonclick ;
      private string edtProcedimentosMedicosNome_Internalname ;
      private string edtProcedimentosMedicosDescricao_Internalname ;
      private string edtProcedimentosMedicosArea_Internalname ;
      private string edtCID_Internalname ;
      private string edtCID_Jsonclick ;
      private string chkProcedimentosMedicosAtivo_Internalname ;
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
      private string sMode54 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z409ProcedimentosMedicosAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A409ProcedimentosMedicosAtivo ;
      private bool n408CID ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n379ProcedimentosMedicosArea ;
      private bool n376ProcedimentosMedicosId ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool ZZ409ProcedimentosMedicosAtivo ;
      private string A378ProcedimentosMedicosDescricao ;
      private string Z378ProcedimentosMedicosDescricao ;
      private string ZZ378ProcedimentosMedicosDescricao ;
      private string Z377ProcedimentosMedicosNome ;
      private string Z379ProcedimentosMedicosArea ;
      private string A377ProcedimentosMedicosNome ;
      private string A379ProcedimentosMedicosArea ;
      private string ZZ377ProcedimentosMedicosNome ;
      private string ZZ379ProcedimentosMedicosArea ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkProcedimentosMedicosAtivo ;
      private IDataStoreProvider pr_default ;
      private int[] T001F4_A376ProcedimentosMedicosId ;
      private bool[] T001F4_n376ProcedimentosMedicosId ;
      private string[] T001F4_A377ProcedimentosMedicosNome ;
      private bool[] T001F4_n377ProcedimentosMedicosNome ;
      private string[] T001F4_A378ProcedimentosMedicosDescricao ;
      private bool[] T001F4_n378ProcedimentosMedicosDescricao ;
      private string[] T001F4_A379ProcedimentosMedicosArea ;
      private bool[] T001F4_n379ProcedimentosMedicosArea ;
      private int[] T001F4_A408CID ;
      private bool[] T001F4_n408CID ;
      private bool[] T001F4_A409ProcedimentosMedicosAtivo ;
      private int[] T001F5_A376ProcedimentosMedicosId ;
      private bool[] T001F5_n376ProcedimentosMedicosId ;
      private int[] T001F3_A376ProcedimentosMedicosId ;
      private bool[] T001F3_n376ProcedimentosMedicosId ;
      private string[] T001F3_A377ProcedimentosMedicosNome ;
      private bool[] T001F3_n377ProcedimentosMedicosNome ;
      private string[] T001F3_A378ProcedimentosMedicosDescricao ;
      private bool[] T001F3_n378ProcedimentosMedicosDescricao ;
      private string[] T001F3_A379ProcedimentosMedicosArea ;
      private bool[] T001F3_n379ProcedimentosMedicosArea ;
      private int[] T001F3_A408CID ;
      private bool[] T001F3_n408CID ;
      private bool[] T001F3_A409ProcedimentosMedicosAtivo ;
      private int[] T001F6_A376ProcedimentosMedicosId ;
      private bool[] T001F6_n376ProcedimentosMedicosId ;
      private int[] T001F7_A376ProcedimentosMedicosId ;
      private bool[] T001F7_n376ProcedimentosMedicosId ;
      private int[] T001F2_A376ProcedimentosMedicosId ;
      private bool[] T001F2_n376ProcedimentosMedicosId ;
      private string[] T001F2_A377ProcedimentosMedicosNome ;
      private bool[] T001F2_n377ProcedimentosMedicosNome ;
      private string[] T001F2_A378ProcedimentosMedicosDescricao ;
      private bool[] T001F2_n378ProcedimentosMedicosDescricao ;
      private string[] T001F2_A379ProcedimentosMedicosArea ;
      private bool[] T001F2_n379ProcedimentosMedicosArea ;
      private int[] T001F2_A408CID ;
      private bool[] T001F2_n408CID ;
      private bool[] T001F2_A409ProcedimentosMedicosAtivo ;
      private int[] T001F9_A376ProcedimentosMedicosId ;
      private bool[] T001F9_n376ProcedimentosMedicosId ;
      private int[] T001F12_A323PropostaId ;
      private int[] T001F13_A376ProcedimentosMedicosId ;
      private bool[] T001F13_n376ProcedimentosMedicosId ;
   }

   public class procedimentosmedicos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001F2;
          prmT001F2 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F3;
          prmT001F3 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F4;
          prmT001F4 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F5;
          prmT001F5 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F6;
          prmT001F6 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F7;
          prmT001F7 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F8;
          prmT001F8 = new Object[] {
          new ParDef("ProcedimentosMedicosNome",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosArea",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("CID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosAtivo",GXType.Boolean,4,0)
          };
          Object[] prmT001F9;
          prmT001F9 = new Object[] {
          };
          Object[] prmT001F10;
          prmT001F10 = new Object[] {
          new ParDef("ProcedimentosMedicosNome",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosArea",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("CID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosAtivo",GXType.Boolean,4,0) ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F11;
          prmT001F11 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F12;
          prmT001F12 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001F13;
          prmT001F13 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001F2", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosNome, ProcedimentosMedicosDescricao, ProcedimentosMedicosArea, CID, ProcedimentosMedicosAtivo FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId  FOR UPDATE OF ProcedimentosMedicos NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001F3", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosNome, ProcedimentosMedicosDescricao, ProcedimentosMedicosArea, CID, ProcedimentosMedicosAtivo FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001F4", "SELECT TM1.ProcedimentosMedicosId, TM1.ProcedimentosMedicosNome, TM1.ProcedimentosMedicosDescricao, TM1.ProcedimentosMedicosArea, TM1.CID, TM1.ProcedimentosMedicosAtivo FROM ProcedimentosMedicos TM1 WHERE TM1.ProcedimentosMedicosId = :ProcedimentosMedicosId ORDER BY TM1.ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001F5", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001F6", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ( ProcedimentosMedicosId > :ProcedimentosMedicosId) ORDER BY ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001F7", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ( ProcedimentosMedicosId < :ProcedimentosMedicosId) ORDER BY ProcedimentosMedicosId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001F8", "SAVEPOINT gxupdate;INSERT INTO ProcedimentosMedicos(ProcedimentosMedicosNome, ProcedimentosMedicosDescricao, ProcedimentosMedicosArea, CID, ProcedimentosMedicosAtivo) VALUES(:ProcedimentosMedicosNome, :ProcedimentosMedicosDescricao, :ProcedimentosMedicosArea, :CID, :ProcedimentosMedicosAtivo);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001F8)
             ,new CursorDef("T001F9", "SELECT currval('ProcedimentosMedicosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001F10", "SAVEPOINT gxupdate;UPDATE ProcedimentosMedicos SET ProcedimentosMedicosNome=:ProcedimentosMedicosNome, ProcedimentosMedicosDescricao=:ProcedimentosMedicosDescricao, ProcedimentosMedicosArea=:ProcedimentosMedicosArea, CID=:CID, ProcedimentosMedicosAtivo=:ProcedimentosMedicosAtivo  WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001F10)
             ,new CursorDef("T001F11", "SAVEPOINT gxupdate;DELETE FROM ProcedimentosMedicos  WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001F11)
             ,new CursorDef("T001F12", "SELECT PropostaId FROM Proposta WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001F13", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos ORDER BY ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F13,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
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
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
