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
   public class arquivo : GXDataArea
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
         Form.Meta.addItem("description", "Arquivo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtArquivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public arquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arquivo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Arquivo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Arquivo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Arquivo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtArquivoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArquivoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtArquivoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtArquivoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A231ArquivoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A231ArquivoId), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArquivoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtArquivoId_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtArquivoBlob_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArquivoBlob_Internalname, "Blob", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         edtArquivoBlob_Filename = A255ArquivoNome;
         edtArquivoBlob_Filetype = "";
         AssignProp("", false, edtArquivoBlob_Internalname, "Filetype", edtArquivoBlob_Filetype, true);
         edtArquivoBlob_Filetype = A254ArquivoExtensao;
         AssignProp("", false, edtArquivoBlob_Internalname, "Filetype", edtArquivoBlob_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A232ArquivoBlob)) )
         {
            gxblobfileaux.Source = A232ArquivoBlob;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtArquivoBlob_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtArquivoBlob_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A232ArquivoBlob = gxblobfileaux.GetURI();
               n232ArquivoBlob = false;
               AssignAttri("", false, "A232ArquivoBlob", A232ArquivoBlob);
               AssignProp("", false, edtArquivoBlob_Internalname, "URL", context.PathToRelativeUrl( A232ArquivoBlob), true);
               edtArquivoBlob_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtArquivoBlob_Internalname, "Filetype", edtArquivoBlob_Filetype, true);
            }
            AssignProp("", false, edtArquivoBlob_Internalname, "URL", context.PathToRelativeUrl( A232ArquivoBlob), true);
         }
         GxWebStd.gx_blob_field( context, edtArquivoBlob_Internalname, StringUtil.RTrim( A232ArquivoBlob), context.PathToRelativeUrl( A232ArquivoBlob), (String.IsNullOrEmpty(StringUtil.RTrim( edtArquivoBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtArquivoBlob_Filetype)) ? A232ArquivoBlob : edtArquivoBlob_Filetype)) : edtArquivoBlob_Contenttype), true, "", edtArquivoBlob_Parameters, 0, edtArquivoBlob_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtArquivoBlob_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", "", "HLP_Arquivo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Arquivo.htm");
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
            Z231ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z231ArquivoId"), ",", "."), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A254ArquivoExtensao = cgiGet( "ARQUIVOEXTENSAO");
            n254ArquivoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( A254ArquivoExtensao)) ? true : false);
            A255ArquivoNome = cgiGet( "ARQUIVONOME");
            n255ArquivoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A255ArquivoNome)) ? true : false);
            edtArquivoBlob_Filetype = cgiGet( "ARQUIVOBLOB_Filetype");
            edtArquivoBlob_Filename = cgiGet( "ARQUIVOBLOB_Filename");
            edtArquivoBlob_Filename = cgiGet( "ARQUIVOBLOB_Filename");
            edtArquivoBlob_Filetype = cgiGet( "ARQUIVOBLOB_Filetype");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARQUIVOID");
               AnyError = 1;
               GX_FocusControl = edtArquivoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A231ArquivoId = 0;
               n231ArquivoId = false;
               AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
            }
            else
            {
               A231ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n231ArquivoId = false;
               AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
            }
            A232ArquivoBlob = cgiGet( edtArquivoBlob_Internalname);
            n232ArquivoBlob = false;
            AssignAttri("", false, "A232ArquivoBlob", A232ArquivoBlob);
            n232ArquivoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A232ArquivoBlob)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A232ArquivoBlob)) )
            {
               edtArquivoBlob_Filename = (string)(CGIGetFileName(edtArquivoBlob_Internalname));
               edtArquivoBlob_Filetype = (string)(CGIGetFileType(edtArquivoBlob_Internalname));
            }
            A254ArquivoExtensao = edtArquivoBlob_Filetype;
            n254ArquivoExtensao = false;
            AssignAttri("", false, "A254ArquivoExtensao", A254ArquivoExtensao);
            A255ArquivoNome = edtArquivoBlob_Filename;
            n255ArquivoNome = false;
            AssignAttri("", false, "A255ArquivoNome", A255ArquivoNome);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A232ArquivoBlob)) )
            {
               GXCCtlgxBlob = "ARQUIVOBLOB" + "_gxBlob";
               A232ArquivoBlob = cgiGet( GXCCtlgxBlob);
               n232ArquivoBlob = false;
               n232ArquivoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A232ArquivoBlob)) ? true : false);
            }
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
               A231ArquivoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ArquivoId"), "."), 18, MidpointRounding.ToEven));
               n231ArquivoId = false;
               AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
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
               InitAll0Y37( ) ;
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
         DisableAttributes0Y37( ) ;
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

      protected void ResetCaption0Y0( )
      {
      }

      protected void ZM0Y37( short GX_JID )
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
            Z231ArquivoId = A231ArquivoId;
            Z232ArquivoBlob = A232ArquivoBlob;
            Z254ArquivoExtensao = A254ArquivoExtensao;
            Z255ArquivoNome = A255ArquivoNome;
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

      protected void Load0Y37( )
      {
         /* Using cursor T000Y4 */
         pr_default.execute(2, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound37 = 1;
            A254ArquivoExtensao = T000Y4_A254ArquivoExtensao[0];
            n254ArquivoExtensao = T000Y4_n254ArquivoExtensao[0];
            edtArquivoBlob_Filetype = A254ArquivoExtensao;
            AssignProp("", false, edtArquivoBlob_Internalname, "Filetype", edtArquivoBlob_Filetype, true);
            A255ArquivoNome = T000Y4_A255ArquivoNome[0];
            n255ArquivoNome = T000Y4_n255ArquivoNome[0];
            edtArquivoBlob_Filename = A255ArquivoNome;
            A232ArquivoBlob = T000Y4_A232ArquivoBlob[0];
            n232ArquivoBlob = T000Y4_n232ArquivoBlob[0];
            AssignAttri("", false, "A232ArquivoBlob", A232ArquivoBlob);
            AssignProp("", false, edtArquivoBlob_Internalname, "URL", context.PathToRelativeUrl( A232ArquivoBlob), true);
            ZM0Y37( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0Y37( ) ;
      }

      protected void OnLoadActions0Y37( )
      {
      }

      protected void CheckExtendedTable0Y37( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0Y37( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Y37( )
      {
         /* Using cursor T000Y5 */
         pr_default.execute(3, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Y3 */
         pr_default.execute(1, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y37( 1) ;
            RcdFound37 = 1;
            A231ArquivoId = T000Y3_A231ArquivoId[0];
            n231ArquivoId = T000Y3_n231ArquivoId[0];
            AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
            A254ArquivoExtensao = T000Y3_A254ArquivoExtensao[0];
            n254ArquivoExtensao = T000Y3_n254ArquivoExtensao[0];
            edtArquivoBlob_Filetype = A254ArquivoExtensao;
            AssignProp("", false, edtArquivoBlob_Internalname, "Filetype", edtArquivoBlob_Filetype, true);
            A255ArquivoNome = T000Y3_A255ArquivoNome[0];
            n255ArquivoNome = T000Y3_n255ArquivoNome[0];
            edtArquivoBlob_Filename = A255ArquivoNome;
            A232ArquivoBlob = T000Y3_A232ArquivoBlob[0];
            n232ArquivoBlob = T000Y3_n232ArquivoBlob[0];
            AssignAttri("", false, "A232ArquivoBlob", A232ArquivoBlob);
            AssignProp("", false, edtArquivoBlob_Internalname, "URL", context.PathToRelativeUrl( A232ArquivoBlob), true);
            Z231ArquivoId = A231ArquivoId;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Y37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0Y37( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0Y37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y37( ) ;
         if ( RcdFound37 == 0 )
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
         RcdFound37 = 0;
         /* Using cursor T000Y6 */
         pr_default.execute(4, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000Y6_A231ArquivoId[0] < A231ArquivoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000Y6_A231ArquivoId[0] > A231ArquivoId ) ) )
            {
               A231ArquivoId = T000Y6_A231ArquivoId[0];
               n231ArquivoId = T000Y6_n231ArquivoId[0];
               AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
               RcdFound37 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T000Y7 */
         pr_default.execute(5, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000Y7_A231ArquivoId[0] > A231ArquivoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000Y7_A231ArquivoId[0] < A231ArquivoId ) ) )
            {
               A231ArquivoId = T000Y7_A231ArquivoId[0];
               n231ArquivoId = T000Y7_n231ArquivoId[0];
               AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
               RcdFound37 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Y37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtArquivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Y37( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A231ArquivoId != Z231ArquivoId )
               {
                  A231ArquivoId = Z231ArquivoId;
                  n231ArquivoId = false;
                  AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ARQUIVOID");
                  AnyError = 1;
                  GX_FocusControl = edtArquivoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtArquivoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0Y37( ) ;
                  GX_FocusControl = edtArquivoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A231ArquivoId != Z231ArquivoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtArquivoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Y37( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ARQUIVOID");
                     AnyError = 1;
                     GX_FocusControl = edtArquivoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtArquivoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Y37( ) ;
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
         if ( A231ArquivoId != Z231ArquivoId )
         {
            A231ArquivoId = Z231ArquivoId;
            n231ArquivoId = false;
            AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ARQUIVOID");
            AnyError = 1;
            GX_FocusControl = edtArquivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtArquivoId_Internalname;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ARQUIVOID");
            AnyError = 1;
            GX_FocusControl = edtArquivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtArquivoBlob_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Y37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtArquivoBlob_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y37( ) ;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtArquivoBlob_Internalname;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtArquivoBlob_Internalname;
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
         ScanStart0Y37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound37 != 0 )
            {
               ScanNext0Y37( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtArquivoBlob_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y37( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Y37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y2 */
            pr_default.execute(0, new Object[] {n231ArquivoId, A231ArquivoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Arquivo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Arquivo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y37( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y37( 0) ;
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y8 */
                     A254ArquivoExtensao = edtArquivoBlob_Filetype;
                     n254ArquivoExtensao = false;
                     AssignAttri("", false, "A254ArquivoExtensao", A254ArquivoExtensao);
                     A255ArquivoNome = edtArquivoBlob_Filename;
                     n255ArquivoNome = false;
                     AssignAttri("", false, "A255ArquivoNome", A255ArquivoNome);
                     pr_default.execute(6, new Object[] {n232ArquivoBlob, A232ArquivoBlob, n254ArquivoExtensao, A254ArquivoExtensao, n255ArquivoNome, A255ArquivoNome});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000Y9 */
                     pr_default.execute(7);
                     A231ArquivoId = T000Y9_A231ArquivoId[0];
                     n231ArquivoId = T000Y9_n231ArquivoId[0];
                     AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Arquivo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0Y0( ) ;
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
               Load0Y37( ) ;
            }
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void Update0Y37( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y10 */
                     A254ArquivoExtensao = edtArquivoBlob_Filetype;
                     n254ArquivoExtensao = false;
                     AssignAttri("", false, "A254ArquivoExtensao", A254ArquivoExtensao);
                     A255ArquivoNome = edtArquivoBlob_Filename;
                     n255ArquivoNome = false;
                     AssignAttri("", false, "A255ArquivoNome", A255ArquivoNome);
                     pr_default.execute(8, new Object[] {n254ArquivoExtensao, A254ArquivoExtensao, n255ArquivoNome, A255ArquivoNome, n231ArquivoId, A231ArquivoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Arquivo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Arquivo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Y0( ) ;
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
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void DeferredUpdate0Y37( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y11 */
            pr_default.execute(9, new Object[] {n232ArquivoBlob, A232ArquivoBlob, n231ArquivoId, A231ArquivoId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("Arquivo");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y37( ) ;
            AfterConfirm0Y37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y37( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Y12 */
                  pr_default.execute(10, new Object[] {n231ArquivoId, A231ArquivoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Arquivo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound37 == 0 )
                        {
                           InitAll0Y37( ) ;
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
                        ResetCaption0Y0( ) ;
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y37( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y37( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y13 */
            pr_default.execute(11, new Object[] {n231ArquivoId, A231ArquivoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Assinatura"+" ("+"Sb Arquivo Assinado"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000Y14 */
            pr_default.execute(12, new Object[] {n231ArquivoId, A231ArquivoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Assinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0Y37( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues0Y0( ) ;
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

      public void ScanStart0Y37( )
      {
         /* Using cursor T000Y15 */
         pr_default.execute(13);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound37 = 1;
            A231ArquivoId = T000Y15_A231ArquivoId[0];
            n231ArquivoId = T000Y15_n231ArquivoId[0];
            AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y37( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound37 = 1;
            A231ArquivoId = T000Y15_A231ArquivoId[0];
            n231ArquivoId = T000Y15_n231ArquivoId[0];
            AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
         }
      }

      protected void ScanEnd0Y37( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0Y37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y37( )
      {
         edtArquivoId_Enabled = 0;
         AssignProp("", false, edtArquivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArquivoId_Enabled), 5, 0), true);
         edtArquivoBlob_Enabled = 0;
         AssignProp("", false, edtArquivoBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArquivoBlob_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Y37( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Y0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("arquivo") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z231ArquivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z231ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "ARQUIVOEXTENSAO", A254ArquivoExtensao);
         GxWebStd.gx_hidden_field( context, "ARQUIVONOME", A255ArquivoNome);
         GXCCtlgxBlob = "ARQUIVOBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A232ArquivoBlob);
         GxWebStd.gx_hidden_field( context, "ARQUIVOBLOB_Filetype", StringUtil.RTrim( edtArquivoBlob_Filetype));
         GxWebStd.gx_hidden_field( context, "ARQUIVOBLOB_Filename", StringUtil.RTrim( edtArquivoBlob_Filename));
         GxWebStd.gx_hidden_field( context, "ARQUIVOBLOB_Filename", StringUtil.RTrim( edtArquivoBlob_Filename));
         GxWebStd.gx_hidden_field( context, "ARQUIVOBLOB_Filetype", StringUtil.RTrim( edtArquivoBlob_Filetype));
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
         return formatLink("arquivo")  ;
      }

      public override string GetPgmname( )
      {
         return "Arquivo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Arquivo" ;
      }

      protected void InitializeNonKey0Y37( )
      {
         A232ArquivoBlob = "";
         n232ArquivoBlob = false;
         AssignAttri("", false, "A232ArquivoBlob", A232ArquivoBlob);
         AssignProp("", false, edtArquivoBlob_Internalname, "URL", context.PathToRelativeUrl( A232ArquivoBlob), true);
         n232ArquivoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A232ArquivoBlob)) ? true : false);
         A254ArquivoExtensao = "";
         n254ArquivoExtensao = false;
         AssignAttri("", false, "A254ArquivoExtensao", A254ArquivoExtensao);
         A255ArquivoNome = "";
         n255ArquivoNome = false;
         AssignAttri("", false, "A255ArquivoNome", A255ArquivoNome);
      }

      protected void InitAll0Y37( )
      {
         A231ArquivoId = 0;
         n231ArquivoId = false;
         AssignAttri("", false, "A231ArquivoId", StringUtil.LTrimStr( (decimal)(A231ArquivoId), 8, 0));
         InitializeNonKey0Y37( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019133917", true, true);
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
         context.AddJavascriptSource("arquivo.js", "?202561019133918", false, true);
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
         edtArquivoId_Internalname = "ARQUIVOID";
         edtArquivoBlob_Internalname = "ARQUIVOBLOB";
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
         Form.Caption = "Arquivo";
         edtArquivoBlob_Filename = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtArquivoBlob_Jsonclick = "";
         edtArquivoBlob_Parameters = "";
         edtArquivoBlob_Contenttype = "";
         edtArquivoBlob_Filetype = "";
         edtArquivoBlob_Enabled = 1;
         edtArquivoId_Jsonclick = "";
         edtArquivoId_Enabled = 1;
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
         GX_FocusControl = edtArquivoBlob_Internalname;
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

      public void Valid_Arquivoid( )
      {
         n231ArquivoId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A232ArquivoBlob", context.PathToRelativeUrl( A232ArquivoBlob));
         AssignAttri("", false, "A254ArquivoExtensao", A254ArquivoExtensao);
         AssignAttri("", false, "A255ArquivoNome", A255ArquivoNome);
         AssignProp("", false, edtArquivoBlob_Internalname, "Filetype", edtArquivoBlob_Filetype, true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z231ArquivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z231ArquivoId), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z232ArquivoBlob", context.PathToRelativeUrl( Z232ArquivoBlob));
         GxWebStd.gx_hidden_field( context, "Z254ArquivoExtensao", Z254ArquivoExtensao);
         GxWebStd.gx_hidden_field( context, "Z255ArquivoNome", Z255ArquivoNome);
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
         setEventMetadata("VALID_ARQUIVOID","""{"handler":"Valid_Arquivoid","iparms":[{"av":"A231ArquivoId","fld":"ARQUIVOID","pic":"ZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_ARQUIVOID",""","oparms":[{"av":"A232ArquivoBlob","fld":"ARQUIVOBLOB","type":"bitstr"},{"av":"A254ArquivoExtensao","fld":"ARQUIVOEXTENSAO","type":"svchar"},{"av":"A255ArquivoNome","fld":"ARQUIVONOME","type":"svchar"},{"av":"edtArquivoBlob_Filetype","ctrl":"ARQUIVOBLOB","prop":"Filetype"},{"av":"edtArquivoBlob_Filename","ctrl":"ARQUIVOBLOB","prop":"Filename"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z231ArquivoId","type":"int"},{"av":"Z232ArquivoBlob","type":"bitstr"},{"av":"Z254ArquivoExtensao","type":"svchar"},{"av":"Z255ArquivoNome","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         A255ArquivoNome = "";
         A254ArquivoExtensao = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A232ArquivoBlob = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         GXCCtlgxBlob = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z232ArquivoBlob = "";
         Z254ArquivoExtensao = "";
         Z255ArquivoNome = "";
         T000Y4_A231ArquivoId = new int[1] ;
         T000Y4_n231ArquivoId = new bool[] {false} ;
         T000Y4_A254ArquivoExtensao = new string[] {""} ;
         T000Y4_n254ArquivoExtensao = new bool[] {false} ;
         T000Y4_A255ArquivoNome = new string[] {""} ;
         T000Y4_n255ArquivoNome = new bool[] {false} ;
         T000Y4_A232ArquivoBlob = new string[] {""} ;
         T000Y4_n232ArquivoBlob = new bool[] {false} ;
         T000Y5_A231ArquivoId = new int[1] ;
         T000Y5_n231ArquivoId = new bool[] {false} ;
         T000Y3_A231ArquivoId = new int[1] ;
         T000Y3_n231ArquivoId = new bool[] {false} ;
         T000Y3_A254ArquivoExtensao = new string[] {""} ;
         T000Y3_n254ArquivoExtensao = new bool[] {false} ;
         T000Y3_A255ArquivoNome = new string[] {""} ;
         T000Y3_n255ArquivoNome = new bool[] {false} ;
         T000Y3_A232ArquivoBlob = new string[] {""} ;
         T000Y3_n232ArquivoBlob = new bool[] {false} ;
         sMode37 = "";
         T000Y6_A231ArquivoId = new int[1] ;
         T000Y6_n231ArquivoId = new bool[] {false} ;
         T000Y7_A231ArquivoId = new int[1] ;
         T000Y7_n231ArquivoId = new bool[] {false} ;
         T000Y2_A231ArquivoId = new int[1] ;
         T000Y2_n231ArquivoId = new bool[] {false} ;
         T000Y2_A254ArquivoExtensao = new string[] {""} ;
         T000Y2_n254ArquivoExtensao = new bool[] {false} ;
         T000Y2_A255ArquivoNome = new string[] {""} ;
         T000Y2_n255ArquivoNome = new bool[] {false} ;
         T000Y2_A232ArquivoBlob = new string[] {""} ;
         T000Y2_n232ArquivoBlob = new bool[] {false} ;
         T000Y9_A231ArquivoId = new int[1] ;
         T000Y9_n231ArquivoId = new bool[] {false} ;
         T000Y13_A238AssinaturaId = new long[1] ;
         T000Y14_A238AssinaturaId = new long[1] ;
         T000Y15_A231ArquivoId = new int[1] ;
         T000Y15_n231ArquivoId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ232ArquivoBlob = "";
         ZZ254ArquivoExtensao = "";
         ZZ255ArquivoNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arquivo__default(),
            new Object[][] {
                new Object[] {
               T000Y2_A231ArquivoId, T000Y2_A254ArquivoExtensao, T000Y2_n254ArquivoExtensao, T000Y2_A255ArquivoNome, T000Y2_n255ArquivoNome, T000Y2_A232ArquivoBlob, T000Y2_n232ArquivoBlob
               }
               , new Object[] {
               T000Y3_A231ArquivoId, T000Y3_A254ArquivoExtensao, T000Y3_n254ArquivoExtensao, T000Y3_A255ArquivoNome, T000Y3_n255ArquivoNome, T000Y3_A232ArquivoBlob, T000Y3_n232ArquivoBlob
               }
               , new Object[] {
               T000Y4_A231ArquivoId, T000Y4_A254ArquivoExtensao, T000Y4_n254ArquivoExtensao, T000Y4_A255ArquivoNome, T000Y4_n255ArquivoNome, T000Y4_A232ArquivoBlob, T000Y4_n232ArquivoBlob
               }
               , new Object[] {
               T000Y5_A231ArquivoId
               }
               , new Object[] {
               T000Y6_A231ArquivoId
               }
               , new Object[] {
               T000Y7_A231ArquivoId
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y9_A231ArquivoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y13_A238AssinaturaId
               }
               , new Object[] {
               T000Y14_A238AssinaturaId
               }
               , new Object[] {
               T000Y15_A231ArquivoId
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
      private short RcdFound37 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z231ArquivoId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A231ArquivoId ;
      private int edtArquivoId_Enabled ;
      private int edtArquivoBlob_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ231ArquivoId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtArquivoId_Internalname ;
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
      private string edtArquivoId_Jsonclick ;
      private string edtArquivoBlob_Internalname ;
      private string edtArquivoBlob_Filename ;
      private string edtArquivoBlob_Filetype ;
      private string edtArquivoBlob_Contenttype ;
      private string edtArquivoBlob_Parameters ;
      private string edtArquivoBlob_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string GXCCtlgxBlob ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode37 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n232ArquivoBlob ;
      private bool n254ArquivoExtensao ;
      private bool n255ArquivoNome ;
      private bool n231ArquivoId ;
      private string A255ArquivoNome ;
      private string A254ArquivoExtensao ;
      private string Z254ArquivoExtensao ;
      private string Z255ArquivoNome ;
      private string ZZ254ArquivoExtensao ;
      private string ZZ255ArquivoNome ;
      private string A232ArquivoBlob ;
      private string Z232ArquivoBlob ;
      private string ZZ232ArquivoBlob ;
      private GxFile gxblobfileaux ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000Y4_A231ArquivoId ;
      private bool[] T000Y4_n231ArquivoId ;
      private string[] T000Y4_A254ArquivoExtensao ;
      private bool[] T000Y4_n254ArquivoExtensao ;
      private string[] T000Y4_A255ArquivoNome ;
      private bool[] T000Y4_n255ArquivoNome ;
      private string[] T000Y4_A232ArquivoBlob ;
      private bool[] T000Y4_n232ArquivoBlob ;
      private int[] T000Y5_A231ArquivoId ;
      private bool[] T000Y5_n231ArquivoId ;
      private int[] T000Y3_A231ArquivoId ;
      private bool[] T000Y3_n231ArquivoId ;
      private string[] T000Y3_A254ArquivoExtensao ;
      private bool[] T000Y3_n254ArquivoExtensao ;
      private string[] T000Y3_A255ArquivoNome ;
      private bool[] T000Y3_n255ArquivoNome ;
      private string[] T000Y3_A232ArquivoBlob ;
      private bool[] T000Y3_n232ArquivoBlob ;
      private int[] T000Y6_A231ArquivoId ;
      private bool[] T000Y6_n231ArquivoId ;
      private int[] T000Y7_A231ArquivoId ;
      private bool[] T000Y7_n231ArquivoId ;
      private int[] T000Y2_A231ArquivoId ;
      private bool[] T000Y2_n231ArquivoId ;
      private string[] T000Y2_A254ArquivoExtensao ;
      private bool[] T000Y2_n254ArquivoExtensao ;
      private string[] T000Y2_A255ArquivoNome ;
      private bool[] T000Y2_n255ArquivoNome ;
      private string[] T000Y2_A232ArquivoBlob ;
      private bool[] T000Y2_n232ArquivoBlob ;
      private int[] T000Y9_A231ArquivoId ;
      private bool[] T000Y9_n231ArquivoId ;
      private long[] T000Y13_A238AssinaturaId ;
      private long[] T000Y14_A238AssinaturaId ;
      private int[] T000Y15_A231ArquivoId ;
      private bool[] T000Y15_n231ArquivoId ;
   }

   public class arquivo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000Y2;
          prmT000Y2 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y3;
          prmT000Y3 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y4;
          prmT000Y4 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y5;
          prmT000Y5 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y6;
          prmT000Y6 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y7;
          prmT000Y7 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y8;
          prmT000Y8 = new Object[] {
          new ParDef("ArquivoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ArquivoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ArquivoNome",GXType.VarChar,150,0){Nullable=true}
          };
          Object[] prmT000Y9;
          prmT000Y9 = new Object[] {
          };
          Object[] prmT000Y10;
          prmT000Y10 = new Object[] {
          new ParDef("ArquivoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ArquivoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y11;
          prmT000Y11 = new Object[] {
          new ParDef("ArquivoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y12;
          prmT000Y12 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y13;
          prmT000Y13 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y14;
          prmT000Y14 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT000Y15;
          prmT000Y15 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000Y2", "SELECT ArquivoId, ArquivoExtensao, ArquivoNome, ArquivoBlob FROM Arquivo WHERE ArquivoId = :ArquivoId  FOR UPDATE OF Arquivo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y3", "SELECT ArquivoId, ArquivoExtensao, ArquivoNome, ArquivoBlob FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y4", "SELECT TM1.ArquivoId, TM1.ArquivoExtensao, TM1.ArquivoNome, TM1.ArquivoBlob FROM Arquivo TM1 WHERE TM1.ArquivoId = :ArquivoId ORDER BY TM1.ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y5", "SELECT ArquivoId FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y6", "SELECT ArquivoId FROM Arquivo WHERE ( ArquivoId > :ArquivoId) ORDER BY ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Y7", "SELECT ArquivoId FROM Arquivo WHERE ( ArquivoId < :ArquivoId) ORDER BY ArquivoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Y8", "SAVEPOINT gxupdate;INSERT INTO Arquivo(ArquivoBlob, ArquivoExtensao, ArquivoNome) VALUES(:ArquivoBlob, :ArquivoExtensao, :ArquivoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Y8)
             ,new CursorDef("T000Y9", "SELECT currval('ArquivoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y10", "SAVEPOINT gxupdate;UPDATE Arquivo SET ArquivoExtensao=:ArquivoExtensao, ArquivoNome=:ArquivoNome  WHERE ArquivoId = :ArquivoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y10)
             ,new CursorDef("T000Y11", "SAVEPOINT gxupdate;UPDATE Arquivo SET ArquivoBlob=:ArquivoBlob  WHERE ArquivoId = :ArquivoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y11)
             ,new CursorDef("T000Y12", "SAVEPOINT gxupdate;DELETE FROM Arquivo  WHERE ArquivoId = :ArquivoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y12)
             ,new CursorDef("T000Y13", "SELECT AssinaturaId FROM Assinatura WHERE ArquivoAssinadoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Y14", "SELECT AssinaturaId FROM Assinatura WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Y15", "SELECT ArquivoId FROM Arquivo ORDER BY ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y15,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
