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
   public class reembolsoetapa : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A518ReembolsoId) ;
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
         Form.Meta.addItem("description", "Reembolso Etapa", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtReembolsoEtapaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolsoetapa( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoetapa( IGxContext context )
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
         cmbReembolsoEtapaStatus = new GXCombobox();
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
         if ( cmbReembolsoEtapaStatus.ItemCount > 0 )
         {
            A545ReembolsoEtapaStatus = cmbReembolsoEtapaStatus.getValidValue(A545ReembolsoEtapaStatus);
            n545ReembolsoEtapaStatus = false;
            AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbReembolsoEtapaStatus.CurrentValue = StringUtil.RTrim( A545ReembolsoEtapaStatus);
            AssignProp("", false, cmbReembolsoEtapaStatus_Internalname, "Values", cmbReembolsoEtapaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Reembolso Etapa", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ReembolsoEtapa.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ReembolsoEtapa.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoEtapaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoEtapaId_Internalname, "Etapa Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoEtapaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoEtapaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A526ReembolsoEtapaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A526ReembolsoEtapaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoEtapaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoEtapaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoId_Internalname, "Reembolso Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoId_Internalname, ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", ""))), ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( ((edtReembolsoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoEtapaCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoEtapaCreatedAt_Internalname, "Created At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoEtapaCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoEtapaCreatedAt_Internalname, context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A534ReembolsoEtapaCreatedAt, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoEtapaCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoEtapaCreatedAt_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoEtapaCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoEtapaCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ReembolsoEtapa.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbReembolsoEtapaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbReembolsoEtapaStatus_Internalname, "Etapa Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbReembolsoEtapaStatus, cmbReembolsoEtapaStatus_Internalname, StringUtil.RTrim( A545ReembolsoEtapaStatus), 1, cmbReembolsoEtapaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbReembolsoEtapaStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ReembolsoEtapa.htm");
         cmbReembolsoEtapaStatus.CurrentValue = StringUtil.RTrim( A545ReembolsoEtapaStatus);
         AssignProp("", false, cmbReembolsoEtapaStatus_Internalname, "Values", (string)(cmbReembolsoEtapaStatus.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoEtapa.htm");
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
            Z526ReembolsoEtapaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z526ReembolsoEtapaId"), ",", "."), 18, MidpointRounding.ToEven));
            Z534ReembolsoEtapaCreatedAt = context.localUtil.CToT( cgiGet( "Z534ReembolsoEtapaCreatedAt"), 0);
            n534ReembolsoEtapaCreatedAt = ((DateTime.MinValue==A534ReembolsoEtapaCreatedAt) ? true : false);
            Z545ReembolsoEtapaStatus = cgiGet( "Z545ReembolsoEtapaStatus");
            n545ReembolsoEtapaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A545ReembolsoEtapaStatus)) ? true : false);
            Z518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z518ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoEtapaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoEtapaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOETAPAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoEtapaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A526ReembolsoEtapaId = 0;
               n526ReembolsoEtapaId = false;
               AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
            }
            else
            {
               A526ReembolsoEtapaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoEtapaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n526ReembolsoEtapaId = false;
               AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
            }
            n518ReembolsoId = ((StringUtil.StrCmp(cgiGet( edtReembolsoId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A518ReembolsoId = 0;
               n518ReembolsoId = false;
               AssignAttri("", false, "A518ReembolsoId", (n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            }
            else
            {
               A518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A518ReembolsoId", (n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtReembolsoEtapaCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Reembolso Etapa Created At"}), 1, "REEMBOLSOETAPACREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtReembolsoEtapaCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
               n534ReembolsoEtapaCreatedAt = false;
               AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               A534ReembolsoEtapaCreatedAt = context.localUtil.CToT( cgiGet( edtReembolsoEtapaCreatedAt_Internalname));
               n534ReembolsoEtapaCreatedAt = false;
               AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            }
            n534ReembolsoEtapaCreatedAt = ((DateTime.MinValue==A534ReembolsoEtapaCreatedAt) ? true : false);
            cmbReembolsoEtapaStatus.CurrentValue = cgiGet( cmbReembolsoEtapaStatus_Internalname);
            A545ReembolsoEtapaStatus = cgiGet( cmbReembolsoEtapaStatus_Internalname);
            n545ReembolsoEtapaStatus = false;
            AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
            n545ReembolsoEtapaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A545ReembolsoEtapaStatus)) ? true : false);
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
               A526ReembolsoEtapaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoEtapaId"), "."), 18, MidpointRounding.ToEven));
               n526ReembolsoEtapaId = false;
               AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
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
               InitAll1Z72( ) ;
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
         DisableAttributes1Z72( ) ;
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

      protected void ResetCaption1Z0( )
      {
      }

      protected void ZM1Z72( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z534ReembolsoEtapaCreatedAt = T001Z3_A534ReembolsoEtapaCreatedAt[0];
               Z545ReembolsoEtapaStatus = T001Z3_A545ReembolsoEtapaStatus[0];
               Z518ReembolsoId = T001Z3_A518ReembolsoId[0];
            }
            else
            {
               Z534ReembolsoEtapaCreatedAt = A534ReembolsoEtapaCreatedAt;
               Z545ReembolsoEtapaStatus = A545ReembolsoEtapaStatus;
               Z518ReembolsoId = A518ReembolsoId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            Z534ReembolsoEtapaCreatedAt = A534ReembolsoEtapaCreatedAt;
            Z545ReembolsoEtapaStatus = A545ReembolsoEtapaStatus;
            Z518ReembolsoId = A518ReembolsoId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A534ReembolsoEtapaCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n534ReembolsoEtapaCreatedAt = false;
            AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
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
      }

      protected void Load1Z72( )
      {
         /* Using cursor T001Z5 */
         pr_default.execute(3, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound72 = 1;
            A534ReembolsoEtapaCreatedAt = T001Z5_A534ReembolsoEtapaCreatedAt[0];
            n534ReembolsoEtapaCreatedAt = T001Z5_n534ReembolsoEtapaCreatedAt[0];
            AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A545ReembolsoEtapaStatus = T001Z5_A545ReembolsoEtapaStatus[0];
            n545ReembolsoEtapaStatus = T001Z5_n545ReembolsoEtapaStatus[0];
            AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
            A518ReembolsoId = T001Z5_A518ReembolsoId[0];
            n518ReembolsoId = T001Z5_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            ZM1Z72( -3) ;
         }
         pr_default.close(3);
         OnLoadActions1Z72( ) ;
      }

      protected void OnLoadActions1Z72( )
      {
      }

      protected void CheckExtendedTable1Z72( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001Z4 */
         pr_default.execute(2, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "FINALIZADO") == 0 ) || ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "REANALISE") == 0 ) || ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A545ReembolsoEtapaStatus)) ) )
         {
            GX_msglist.addItem("Campo Reembolso Etapa Status fora do intervalo", "OutOfRange", 1, "REEMBOLSOETAPASTATUS");
            AnyError = 1;
            GX_FocusControl = cmbReembolsoEtapaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1Z72( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A518ReembolsoId )
      {
         /* Using cursor T001Z6 */
         pr_default.execute(4, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
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

      protected void GetKey1Z72( )
      {
         /* Using cursor T001Z7 */
         pr_default.execute(5, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Z3 */
         pr_default.execute(1, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Z72( 3) ;
            RcdFound72 = 1;
            A526ReembolsoEtapaId = T001Z3_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = T001Z3_n526ReembolsoEtapaId[0];
            AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
            A534ReembolsoEtapaCreatedAt = T001Z3_A534ReembolsoEtapaCreatedAt[0];
            n534ReembolsoEtapaCreatedAt = T001Z3_n534ReembolsoEtapaCreatedAt[0];
            AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A545ReembolsoEtapaStatus = T001Z3_A545ReembolsoEtapaStatus[0];
            n545ReembolsoEtapaStatus = T001Z3_n545ReembolsoEtapaStatus[0];
            AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
            A518ReembolsoId = T001Z3_A518ReembolsoId[0];
            n518ReembolsoId = T001Z3_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1Z72( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1Z72( ) ;
            }
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1Z72( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Z72( ) ;
         if ( RcdFound72 == 0 )
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
         RcdFound72 = 0;
         /* Using cursor T001Z8 */
         pr_default.execute(6, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001Z8_A526ReembolsoEtapaId[0] < A526ReembolsoEtapaId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001Z8_A526ReembolsoEtapaId[0] > A526ReembolsoEtapaId ) ) )
            {
               A526ReembolsoEtapaId = T001Z8_A526ReembolsoEtapaId[0];
               n526ReembolsoEtapaId = T001Z8_n526ReembolsoEtapaId[0];
               AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
               RcdFound72 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound72 = 0;
         /* Using cursor T001Z9 */
         pr_default.execute(7, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001Z9_A526ReembolsoEtapaId[0] > A526ReembolsoEtapaId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001Z9_A526ReembolsoEtapaId[0] < A526ReembolsoEtapaId ) ) )
            {
               A526ReembolsoEtapaId = T001Z9_A526ReembolsoEtapaId[0];
               n526ReembolsoEtapaId = T001Z9_n526ReembolsoEtapaId[0];
               AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
               RcdFound72 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Z72( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtReembolsoEtapaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Z72( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
               {
                  A526ReembolsoEtapaId = Z526ReembolsoEtapaId;
                  n526ReembolsoEtapaId = false;
                  AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSOETAPAID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoEtapaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtReembolsoEtapaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1Z72( ) ;
                  GX_FocusControl = edtReembolsoEtapaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtReembolsoEtapaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Z72( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSOETAPAID");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoEtapaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtReembolsoEtapaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Z72( ) ;
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
         if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
         {
            A526ReembolsoEtapaId = Z526ReembolsoEtapaId;
            n526ReembolsoEtapaId = false;
            AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSOETAPAID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoEtapaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtReembolsoEtapaId_Internalname;
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
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REEMBOLSOETAPAID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoEtapaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Z72( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Z72( ) ;
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
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
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
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
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
         ScanStart1Z72( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound72 != 0 )
            {
               ScanNext1Z72( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Z72( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1Z72( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Z2 */
            pr_default.execute(0, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoEtapa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z534ReembolsoEtapaCreatedAt != T001Z2_A534ReembolsoEtapaCreatedAt[0] ) || ( StringUtil.StrCmp(Z545ReembolsoEtapaStatus, T001Z2_A545ReembolsoEtapaStatus[0]) != 0 ) || ( Z518ReembolsoId != T001Z2_A518ReembolsoId[0] ) )
            {
               if ( Z534ReembolsoEtapaCreatedAt != T001Z2_A534ReembolsoEtapaCreatedAt[0] )
               {
                  GXUtil.WriteLog("reembolsoetapa:[seudo value changed for attri]"+"ReembolsoEtapaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z534ReembolsoEtapaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A534ReembolsoEtapaCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z545ReembolsoEtapaStatus, T001Z2_A545ReembolsoEtapaStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsoetapa:[seudo value changed for attri]"+"ReembolsoEtapaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z545ReembolsoEtapaStatus);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A545ReembolsoEtapaStatus[0]);
               }
               if ( Z518ReembolsoId != T001Z2_A518ReembolsoId[0] )
               {
                  GXUtil.WriteLog("reembolsoetapa:[seudo value changed for attri]"+"ReembolsoId");
                  GXUtil.WriteLogRaw("Old: ",Z518ReembolsoId);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A518ReembolsoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoEtapa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Z72( )
      {
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Z72( 0) ;
            CheckOptimisticConcurrency1Z72( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z72( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Z72( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Z10 */
                     pr_default.execute(8, new Object[] {n534ReembolsoEtapaCreatedAt, A534ReembolsoEtapaCreatedAt, n545ReembolsoEtapaStatus, A545ReembolsoEtapaStatus, n518ReembolsoId, A518ReembolsoId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001Z11 */
                     pr_default.execute(9);
                     A526ReembolsoEtapaId = T001Z11_A526ReembolsoEtapaId[0];
                     n526ReembolsoEtapaId = T001Z11_n526ReembolsoEtapaId[0];
                     AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoEtapa");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1Z0( ) ;
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
               Load1Z72( ) ;
            }
            EndLevel1Z72( ) ;
         }
         CloseExtendedTableCursors1Z72( ) ;
      }

      protected void Update1Z72( )
      {
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z72( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z72( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Z72( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Z12 */
                     pr_default.execute(10, new Object[] {n534ReembolsoEtapaCreatedAt, A534ReembolsoEtapaCreatedAt, n545ReembolsoEtapaStatus, A545ReembolsoEtapaStatus, n518ReembolsoId, A518ReembolsoId, n526ReembolsoEtapaId, A526ReembolsoEtapaId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoEtapa");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoEtapa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Z72( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1Z0( ) ;
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
            EndLevel1Z72( ) ;
         }
         CloseExtendedTableCursors1Z72( ) ;
      }

      protected void DeferredUpdate1Z72( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Z72( ) ;
            AfterConfirm1Z72( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Z72( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Z13 */
                  pr_default.execute(11, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoEtapa");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound72 == 0 )
                        {
                           InitAll1Z72( ) ;
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
                        ResetCaption1Z0( ) ;
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Z72( ) ;
         Gx_mode = sMode72;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Z72( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001Z14 */
            pr_default.execute(12, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel1Z72( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1Z0( ) ;
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

      public void ScanStart1Z72( )
      {
         /* Using cursor T001Z15 */
         pr_default.execute(13);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound72 = 1;
            A526ReembolsoEtapaId = T001Z15_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = T001Z15_n526ReembolsoEtapaId[0];
            AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Z72( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound72 = 1;
            A526ReembolsoEtapaId = T001Z15_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = T001Z15_n526ReembolsoEtapaId[0];
            AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
         }
      }

      protected void ScanEnd1Z72( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1Z72( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Z72( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Z72( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Z72( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Z72( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Z72( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Z72( )
      {
         edtReembolsoEtapaId_Enabled = 0;
         AssignProp("", false, edtReembolsoEtapaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoEtapaId_Enabled), 5, 0), true);
         edtReembolsoId_Enabled = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         edtReembolsoEtapaCreatedAt_Enabled = 0;
         AssignProp("", false, edtReembolsoEtapaCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoEtapaCreatedAt_Enabled), 5, 0), true);
         cmbReembolsoEtapaStatus.Enabled = 0;
         AssignProp("", false, cmbReembolsoEtapaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbReembolsoEtapaStatus.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Z72( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Z0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsoetapa") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z526ReembolsoEtapaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z526ReembolsoEtapaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z534ReembolsoEtapaCreatedAt", context.localUtil.TToC( Z534ReembolsoEtapaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z545ReembolsoEtapaStatus", Z545ReembolsoEtapaStatus);
         GxWebStd.gx_hidden_field( context, "Z518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z518ReembolsoId), 9, 0, ",", "")));
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
         return formatLink("reembolsoetapa")  ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoEtapa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso Etapa" ;
      }

      protected void InitializeNonKey1Z72( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
         n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
         A545ReembolsoEtapaStatus = "";
         n545ReembolsoEtapaStatus = false;
         AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
         n545ReembolsoEtapaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A545ReembolsoEtapaStatus)) ? true : false);
         A534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         Z534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         Z545ReembolsoEtapaStatus = "";
         Z518ReembolsoId = 0;
      }

      protected void InitAll1Z72( )
      {
         A526ReembolsoEtapaId = 0;
         n526ReembolsoEtapaId = false;
         AssignAttri("", false, "A526ReembolsoEtapaId", StringUtil.LTrimStr( (decimal)(A526ReembolsoEtapaId), 9, 0));
         InitializeNonKey1Z72( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A534ReembolsoEtapaCreatedAt = i534ReembolsoEtapaCreatedAt;
         n534ReembolsoEtapaCreatedAt = false;
         AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101918851", true, true);
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
         context.AddJavascriptSource("reembolsoetapa.js", "?20256101918852", false, true);
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
         edtReembolsoEtapaId_Internalname = "REEMBOLSOETAPAID";
         edtReembolsoId_Internalname = "REEMBOLSOID";
         edtReembolsoEtapaCreatedAt_Internalname = "REEMBOLSOETAPACREATEDAT";
         cmbReembolsoEtapaStatus_Internalname = "REEMBOLSOETAPASTATUS";
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
         Form.Caption = "Reembolso Etapa";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbReembolsoEtapaStatus_Jsonclick = "";
         cmbReembolsoEtapaStatus.Enabled = 1;
         edtReembolsoEtapaCreatedAt_Jsonclick = "";
         edtReembolsoEtapaCreatedAt_Enabled = 1;
         edtReembolsoId_Jsonclick = "";
         edtReembolsoId_Enabled = 1;
         edtReembolsoEtapaId_Jsonclick = "";
         edtReembolsoEtapaId_Enabled = 1;
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
         cmbReembolsoEtapaStatus.Name = "REEMBOLSOETAPASTATUS";
         cmbReembolsoEtapaStatus.WebTags = "";
         cmbReembolsoEtapaStatus.addItem("", "", 0);
         cmbReembolsoEtapaStatus.addItem("EM_ANALISE", "Em análise", 0);
         cmbReembolsoEtapaStatus.addItem("FINALIZADO", "Finalizado", 0);
         cmbReembolsoEtapaStatus.addItem("REANALISE", "Reanálise", 0);
         cmbReembolsoEtapaStatus.addItem("", "Não iniciado", 0);
         if ( cmbReembolsoEtapaStatus.ItemCount > 0 )
         {
            A545ReembolsoEtapaStatus = cmbReembolsoEtapaStatus.getValidValue(A545ReembolsoEtapaStatus);
            n545ReembolsoEtapaStatus = false;
            AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtReembolsoId_Internalname;
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

      public void Valid_Reembolsoetapaid( )
      {
         n545ReembolsoEtapaStatus = false;
         A545ReembolsoEtapaStatus = cmbReembolsoEtapaStatus.CurrentValue;
         n545ReembolsoEtapaStatus = false;
         cmbReembolsoEtapaStatus.CurrentValue = A545ReembolsoEtapaStatus;
         n526ReembolsoEtapaId = false;
         n534ReembolsoEtapaCreatedAt = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbReembolsoEtapaStatus.ItemCount > 0 )
         {
            A545ReembolsoEtapaStatus = cmbReembolsoEtapaStatus.getValidValue(A545ReembolsoEtapaStatus);
            n545ReembolsoEtapaStatus = false;
            cmbReembolsoEtapaStatus.CurrentValue = A545ReembolsoEtapaStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbReembolsoEtapaStatus.CurrentValue = StringUtil.RTrim( A545ReembolsoEtapaStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
         AssignAttri("", false, "A534ReembolsoEtapaCreatedAt", context.localUtil.TToC( A534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A545ReembolsoEtapaStatus", A545ReembolsoEtapaStatus);
         cmbReembolsoEtapaStatus.CurrentValue = StringUtil.RTrim( A545ReembolsoEtapaStatus);
         AssignProp("", false, cmbReembolsoEtapaStatus_Internalname, "Values", cmbReembolsoEtapaStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z526ReembolsoEtapaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z526ReembolsoEtapaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z518ReembolsoId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z534ReembolsoEtapaCreatedAt", context.localUtil.TToC( Z534ReembolsoEtapaCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z545ReembolsoEtapaStatus", Z545ReembolsoEtapaStatus);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Reembolsoid( )
      {
         /* Using cursor T001Z16 */
         pr_default.execute(14, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
            }
         }
         pr_default.close(14);
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
         setEventMetadata("VALID_REEMBOLSOETAPAID","""{"handler":"Valid_Reembolsoetapaid","iparms":[{"av":"cmbReembolsoEtapaStatus"},{"av":"A545ReembolsoEtapaStatus","fld":"REEMBOLSOETAPASTATUS","type":"svchar"},{"av":"A526ReembolsoEtapaId","fld":"REEMBOLSOETAPAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A534ReembolsoEtapaCreatedAt","fld":"REEMBOLSOETAPACREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"}]""");
         setEventMetadata("VALID_REEMBOLSOETAPAID",""","oparms":[{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","nullAv":"n518ReembolsoId","type":"int"},{"av":"A534ReembolsoEtapaCreatedAt","fld":"REEMBOLSOETAPACREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"cmbReembolsoEtapaStatus"},{"av":"A545ReembolsoEtapaStatus","fld":"REEMBOLSOETAPASTATUS","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z526ReembolsoEtapaId","type":"int"},{"av":"Z518ReembolsoId","type":"int"},{"av":"Z534ReembolsoEtapaCreatedAt","type":"dtime"},{"av":"Z545ReembolsoEtapaStatus","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_REEMBOLSOID","""{"handler":"Valid_Reembolsoid","iparms":[{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","nullAv":"n518ReembolsoId","type":"int"}]}""");
         setEventMetadata("VALID_REEMBOLSOETAPASTATUS","""{"handler":"Valid_Reembolsoetapastatus","iparms":[]}""");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         Z545ReembolsoEtapaStatus = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A545ReembolsoEtapaStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
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
         T001Z5_A526ReembolsoEtapaId = new int[1] ;
         T001Z5_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z5_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001Z5_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         T001Z5_A545ReembolsoEtapaStatus = new string[] {""} ;
         T001Z5_n545ReembolsoEtapaStatus = new bool[] {false} ;
         T001Z5_A518ReembolsoId = new int[1] ;
         T001Z5_n518ReembolsoId = new bool[] {false} ;
         T001Z4_A518ReembolsoId = new int[1] ;
         T001Z4_n518ReembolsoId = new bool[] {false} ;
         T001Z6_A518ReembolsoId = new int[1] ;
         T001Z6_n518ReembolsoId = new bool[] {false} ;
         T001Z7_A526ReembolsoEtapaId = new int[1] ;
         T001Z7_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z3_A526ReembolsoEtapaId = new int[1] ;
         T001Z3_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z3_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001Z3_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         T001Z3_A545ReembolsoEtapaStatus = new string[] {""} ;
         T001Z3_n545ReembolsoEtapaStatus = new bool[] {false} ;
         T001Z3_A518ReembolsoId = new int[1] ;
         T001Z3_n518ReembolsoId = new bool[] {false} ;
         sMode72 = "";
         T001Z8_A526ReembolsoEtapaId = new int[1] ;
         T001Z8_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z9_A526ReembolsoEtapaId = new int[1] ;
         T001Z9_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z2_A526ReembolsoEtapaId = new int[1] ;
         T001Z2_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z2_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001Z2_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         T001Z2_A545ReembolsoEtapaStatus = new string[] {""} ;
         T001Z2_n545ReembolsoEtapaStatus = new bool[] {false} ;
         T001Z2_A518ReembolsoId = new int[1] ;
         T001Z2_n518ReembolsoId = new bool[] {false} ;
         T001Z11_A526ReembolsoEtapaId = new int[1] ;
         T001Z11_n526ReembolsoEtapaId = new bool[] {false} ;
         T001Z14_A529ReembolsoDocumentoId = new int[1] ;
         T001Z15_A526ReembolsoEtapaId = new int[1] ;
         T001Z15_n526ReembolsoEtapaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ545ReembolsoEtapaStatus = "";
         T001Z16_A518ReembolsoId = new int[1] ;
         T001Z16_n518ReembolsoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoetapa__default(),
            new Object[][] {
                new Object[] {
               T001Z2_A526ReembolsoEtapaId, T001Z2_A534ReembolsoEtapaCreatedAt, T001Z2_n534ReembolsoEtapaCreatedAt, T001Z2_A545ReembolsoEtapaStatus, T001Z2_n545ReembolsoEtapaStatus, T001Z2_A518ReembolsoId, T001Z2_n518ReembolsoId
               }
               , new Object[] {
               T001Z3_A526ReembolsoEtapaId, T001Z3_A534ReembolsoEtapaCreatedAt, T001Z3_n534ReembolsoEtapaCreatedAt, T001Z3_A545ReembolsoEtapaStatus, T001Z3_n545ReembolsoEtapaStatus, T001Z3_A518ReembolsoId, T001Z3_n518ReembolsoId
               }
               , new Object[] {
               T001Z4_A518ReembolsoId
               }
               , new Object[] {
               T001Z5_A526ReembolsoEtapaId, T001Z5_A534ReembolsoEtapaCreatedAt, T001Z5_n534ReembolsoEtapaCreatedAt, T001Z5_A545ReembolsoEtapaStatus, T001Z5_n545ReembolsoEtapaStatus, T001Z5_A518ReembolsoId, T001Z5_n518ReembolsoId
               }
               , new Object[] {
               T001Z6_A518ReembolsoId
               }
               , new Object[] {
               T001Z7_A526ReembolsoEtapaId
               }
               , new Object[] {
               T001Z8_A526ReembolsoEtapaId
               }
               , new Object[] {
               T001Z9_A526ReembolsoEtapaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001Z11_A526ReembolsoEtapaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Z14_A529ReembolsoDocumentoId
               }
               , new Object[] {
               T001Z15_A526ReembolsoEtapaId
               }
               , new Object[] {
               T001Z16_A518ReembolsoId
               }
            }
         );
         Z534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         A534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         i534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound72 ;
      private short gxajaxcallmode ;
      private int Z526ReembolsoEtapaId ;
      private int Z518ReembolsoId ;
      private int A518ReembolsoId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A526ReembolsoEtapaId ;
      private int edtReembolsoEtapaId_Enabled ;
      private int edtReembolsoId_Enabled ;
      private int edtReembolsoEtapaCreatedAt_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ526ReembolsoEtapaId ;
      private int ZZ518ReembolsoId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtReembolsoEtapaId_Internalname ;
      private string cmbReembolsoEtapaStatus_Internalname ;
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
      private string edtReembolsoEtapaId_Jsonclick ;
      private string edtReembolsoId_Internalname ;
      private string edtReembolsoId_Jsonclick ;
      private string edtReembolsoEtapaCreatedAt_Internalname ;
      private string edtReembolsoEtapaCreatedAt_Jsonclick ;
      private string cmbReembolsoEtapaStatus_Jsonclick ;
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
      private string sMode72 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z534ReembolsoEtapaCreatedAt ;
      private DateTime A534ReembolsoEtapaCreatedAt ;
      private DateTime i534ReembolsoEtapaCreatedAt ;
      private DateTime ZZ534ReembolsoEtapaCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n518ReembolsoId ;
      private bool wbErr ;
      private bool n545ReembolsoEtapaStatus ;
      private bool n534ReembolsoEtapaCreatedAt ;
      private bool n526ReembolsoEtapaId ;
      private string Z545ReembolsoEtapaStatus ;
      private string A545ReembolsoEtapaStatus ;
      private string ZZ545ReembolsoEtapaStatus ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbReembolsoEtapaStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T001Z5_A526ReembolsoEtapaId ;
      private bool[] T001Z5_n526ReembolsoEtapaId ;
      private DateTime[] T001Z5_A534ReembolsoEtapaCreatedAt ;
      private bool[] T001Z5_n534ReembolsoEtapaCreatedAt ;
      private string[] T001Z5_A545ReembolsoEtapaStatus ;
      private bool[] T001Z5_n545ReembolsoEtapaStatus ;
      private int[] T001Z5_A518ReembolsoId ;
      private bool[] T001Z5_n518ReembolsoId ;
      private int[] T001Z4_A518ReembolsoId ;
      private bool[] T001Z4_n518ReembolsoId ;
      private int[] T001Z6_A518ReembolsoId ;
      private bool[] T001Z6_n518ReembolsoId ;
      private int[] T001Z7_A526ReembolsoEtapaId ;
      private bool[] T001Z7_n526ReembolsoEtapaId ;
      private int[] T001Z3_A526ReembolsoEtapaId ;
      private bool[] T001Z3_n526ReembolsoEtapaId ;
      private DateTime[] T001Z3_A534ReembolsoEtapaCreatedAt ;
      private bool[] T001Z3_n534ReembolsoEtapaCreatedAt ;
      private string[] T001Z3_A545ReembolsoEtapaStatus ;
      private bool[] T001Z3_n545ReembolsoEtapaStatus ;
      private int[] T001Z3_A518ReembolsoId ;
      private bool[] T001Z3_n518ReembolsoId ;
      private int[] T001Z8_A526ReembolsoEtapaId ;
      private bool[] T001Z8_n526ReembolsoEtapaId ;
      private int[] T001Z9_A526ReembolsoEtapaId ;
      private bool[] T001Z9_n526ReembolsoEtapaId ;
      private int[] T001Z2_A526ReembolsoEtapaId ;
      private bool[] T001Z2_n526ReembolsoEtapaId ;
      private DateTime[] T001Z2_A534ReembolsoEtapaCreatedAt ;
      private bool[] T001Z2_n534ReembolsoEtapaCreatedAt ;
      private string[] T001Z2_A545ReembolsoEtapaStatus ;
      private bool[] T001Z2_n545ReembolsoEtapaStatus ;
      private int[] T001Z2_A518ReembolsoId ;
      private bool[] T001Z2_n518ReembolsoId ;
      private int[] T001Z11_A526ReembolsoEtapaId ;
      private bool[] T001Z11_n526ReembolsoEtapaId ;
      private int[] T001Z14_A529ReembolsoDocumentoId ;
      private int[] T001Z15_A526ReembolsoEtapaId ;
      private bool[] T001Z15_n526ReembolsoEtapaId ;
      private int[] T001Z16_A518ReembolsoId ;
      private bool[] T001Z16_n518ReembolsoId ;
   }

   public class reembolsoetapa__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001Z2;
          prmT001Z2 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z3;
          prmT001Z3 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z4;
          prmT001Z4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z5;
          prmT001Z5 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z6;
          prmT001Z6 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z7;
          prmT001Z7 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z8;
          prmT001Z8 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z9;
          prmT001Z9 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z10;
          prmT001Z10 = new Object[] {
          new ParDef("ReembolsoEtapaCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoEtapaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z11;
          prmT001Z11 = new Object[] {
          };
          Object[] prmT001Z12;
          prmT001Z12 = new Object[] {
          new ParDef("ReembolsoEtapaCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoEtapaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z13;
          prmT001Z13 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z14;
          prmT001Z14 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Z15;
          prmT001Z15 = new Object[] {
          };
          Object[] prmT001Z16;
          prmT001Z16 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001Z2", "SELECT ReembolsoEtapaId, ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus, ReembolsoId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId  FOR UPDATE OF ReembolsoEtapa NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z3", "SELECT ReembolsoEtapaId, ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus, ReembolsoId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z4", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z5", "SELECT TM1.ReembolsoEtapaId, TM1.ReembolsoEtapaCreatedAt, TM1.ReembolsoEtapaStatus, TM1.ReembolsoId FROM ReembolsoEtapa TM1 WHERE TM1.ReembolsoEtapaId = :ReembolsoEtapaId ORDER BY TM1.ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z6", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z7", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z8", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ( ReembolsoEtapaId > :ReembolsoEtapaId) ORDER BY ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Z9", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ( ReembolsoEtapaId < :ReembolsoEtapaId) ORDER BY ReembolsoEtapaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Z10", "SAVEPOINT gxupdate;INSERT INTO ReembolsoEtapa(ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus, ReembolsoId) VALUES(:ReembolsoEtapaCreatedAt, :ReembolsoEtapaStatus, :ReembolsoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Z10)
             ,new CursorDef("T001Z11", "SELECT currval('ReembolsoEtapaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z12", "SAVEPOINT gxupdate;UPDATE ReembolsoEtapa SET ReembolsoEtapaCreatedAt=:ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus=:ReembolsoEtapaStatus, ReembolsoId=:ReembolsoId  WHERE ReembolsoEtapaId = :ReembolsoEtapaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Z12)
             ,new CursorDef("T001Z13", "SAVEPOINT gxupdate;DELETE FROM ReembolsoEtapa  WHERE ReembolsoEtapaId = :ReembolsoEtapaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Z13)
             ,new CursorDef("T001Z14", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Z15", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa ORDER BY ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Z16", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z16,1, GxCacheFrequency.OFF ,true,false )
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
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
