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
   public class reembolso : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action16") == 0 )
         {
            A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
            A742WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "WorkflowConvenioId"), "."), 18, MidpointRounding.ToEven));
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_16_1Y71( A518ReembolsoId, A742WorkflowConvenioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action17") == 0 )
         {
            A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
            A742WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "WorkflowConvenioId"), "."), 18, MidpointRounding.ToEven));
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_17_1Y71( A518ReembolsoId, A742WorkflowConvenioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A518ReembolsoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A518ReembolsoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A542ReembolsoPropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoPropostaId"), "."), 18, MidpointRounding.ToEven));
            n542ReembolsoPropostaId = false;
            AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A542ReembolsoPropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A558ReembolsoPropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoPropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n558ReembolsoPropostaPacienteClienteId = false;
            AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A558ReembolsoPropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A544ReembolsoCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n544ReembolsoCreatedBy = false;
            AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A544ReembolsoCreatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A742WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "WorkflowConvenioId"), "."), 18, MidpointRounding.ToEven));
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A742WorkflowConvenioId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reembolso")), "reembolso") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reembolso")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ReembolsoId", StringUtil.LTrimStr( (decimal)(AV7ReembolsoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ReembolsoId), "ZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", "Reembolso", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtReembolsoPropostaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ReembolsoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ReembolsoId = aP1_ReembolsoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbReembolsoStatusAtual_F = new GXCombobox();
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
         if ( cmbReembolsoStatusAtual_F.ItemCount > 0 )
         {
            A548ReembolsoStatusAtual_F = cmbReembolsoStatusAtual_F.getValidValue(A548ReembolsoStatusAtual_F);
            n548ReembolsoStatusAtual_F = false;
            AssignAttri("", false, "A548ReembolsoStatusAtual_F", A548ReembolsoStatusAtual_F);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbReembolsoStatusAtual_F.CurrentValue = StringUtil.RTrim( A548ReembolsoStatusAtual_F);
            AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Values", cmbReembolsoStatusAtual_F.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedreembolsopropostaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockreembolsopropostaid_Internalname, "Proposta Id", "", "", lblTextblockreembolsopropostaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_reembolsopropostaid.SetProperty("Caption", Combo_reembolsopropostaid_Caption);
         ucCombo_reembolsopropostaid.SetProperty("Cls", Combo_reembolsopropostaid_Cls);
         ucCombo_reembolsopropostaid.SetProperty("DataListProc", Combo_reembolsopropostaid_Datalistproc);
         ucCombo_reembolsopropostaid.SetProperty("DataListProcParametersPrefix", Combo_reembolsopropostaid_Datalistprocparametersprefix);
         ucCombo_reembolsopropostaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_reembolsopropostaid.SetProperty("DropDownOptionsData", AV14ReembolsoPropostaId_Data);
         ucCombo_reembolsopropostaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_reembolsopropostaid_Internalname, "COMBO_REEMBOLSOPROPOSTAIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPropostaId_Internalname, "Reembolso Proposta Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPropostaId_Internalname, ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ",", ""))), ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A542ReembolsoPropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", edtReembolsoPropostaId_Visible, edtReembolsoPropostaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname, "Razao Social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname, A550ReembolsoPropostaPacienteClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A550ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoPropostaPacienteClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPropostaPacienteClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPropostaPacienteClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoPropostaPacienteClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A558ReembolsoPropostaPacienteClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A558ReembolsoPropostaPacienteClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPropostaPacienteClienteId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoPropostaPacienteClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoProtocolo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoProtocolo_Internalname, "Protocolo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoProtocolo_Internalname, A546ReembolsoProtocolo, StringUtil.RTrim( context.localUtil.Format( A546ReembolsoProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoProtocolo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoProtocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoCreatedAt_Internalname, "Data de inicio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoCreatedAt_Internalname, context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A522ReembolsoCreatedAt, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoCreatedAt_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reembolso.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoPropostaValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPropostaValor_Internalname, "Proposta Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPropostaValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A543ReembolsoPropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtReembolsoPropostaValor_Enabled!=0) ? context.localUtil.Format( A543ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A543ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPropostaValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoPropostaValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoDataAberturaConvenio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoDataAberturaConvenio_Internalname, "Data abertura", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoDataAberturaConvenio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoDataAberturaConvenio_Internalname, context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"), context.localUtil.Format( A525ReembolsoDataAberturaConvenio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoDataAberturaConvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoDataAberturaConvenio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoDataAberturaConvenio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoDataAberturaConvenio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reembolso.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedreembolsocreatedby_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockreembolsocreatedby_Internalname, "Created By", "", "", lblTextblockreembolsocreatedby_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_reembolsocreatedby.SetProperty("Caption", Combo_reembolsocreatedby_Caption);
         ucCombo_reembolsocreatedby.SetProperty("Cls", Combo_reembolsocreatedby_Cls);
         ucCombo_reembolsocreatedby.SetProperty("DataListProc", Combo_reembolsocreatedby_Datalistproc);
         ucCombo_reembolsocreatedby.SetProperty("DataListProcParametersPrefix", Combo_reembolsocreatedby_Datalistprocparametersprefix);
         ucCombo_reembolsocreatedby.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_reembolsocreatedby.SetProperty("DropDownOptionsData", AV21ReembolsoCreatedBy_Data);
         ucCombo_reembolsocreatedby.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_reembolsocreatedby_Internalname, "COMBO_REEMBOLSOCREATEDBYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoCreatedBy_Internalname, "Reembolso Created By", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoCreatedBy_Internalname, ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ",", ""))), ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A544ReembolsoCreatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoCreatedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtReembolsoCreatedBy_Visible, edtReembolsoCreatedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoEtapaUltimo_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoEtapaUltimo_F_Internalname, "Último status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoEtapaUltimo_F_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoEtapaUltimo_F_Internalname, context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A547ReembolsoEtapaUltimo_F, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoEtapaUltimo_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoEtapaUltimo_F_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoEtapaUltimo_F_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoEtapaUltimo_F_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reembolso.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbReembolsoStatusAtual_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbReembolsoStatusAtual_F_Internalname, "Reembolso Status Atual_F", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbReembolsoStatusAtual_F, cmbReembolsoStatusAtual_F_Internalname, StringUtil.RTrim( A548ReembolsoStatusAtual_F), 1, cmbReembolsoStatusAtual_F_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbReembolsoStatusAtual_F.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_Reembolso.htm");
         cmbReembolsoStatusAtual_F.CurrentValue = StringUtil.RTrim( A548ReembolsoStatusAtual_F);
         AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Values", (string)(cmbReembolsoStatusAtual_F.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reembolso.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_reembolsopropostaid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboreembolsopropostaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboReembolsoPropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboreembolsopropostaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboReembolsoPropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboReembolsoPropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreembolsopropostaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreembolsopropostaid_Visible, edtavComboreembolsopropostaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_reembolsocreatedby_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboreembolsocreatedby_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ComboReembolsoCreatedBy), 4, 0, ",", "")), StringUtil.LTrim( ((edtavComboreembolsocreatedby_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22ComboReembolsoCreatedBy), "ZZZ9") : context.localUtil.Format( (decimal)(AV22ComboReembolsoCreatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreembolsocreatedby_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreembolsocreatedby_Visible, edtavComboreembolsocreatedby_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reembolso.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111Y2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vREEMBOLSOPROPOSTAID_DATA"), AV14ReembolsoPropostaId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vREEMBOLSOCREATEDBY_DATA"), AV21ReembolsoCreatedBy_Data);
               /* Read saved values. */
               Z518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z518ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z522ReembolsoCreatedAt = context.localUtil.CToT( cgiGet( "Z522ReembolsoCreatedAt"), 0);
               n522ReembolsoCreatedAt = ((DateTime.MinValue==A522ReembolsoCreatedAt) ? true : false);
               Z546ReembolsoProtocolo = cgiGet( "Z546ReembolsoProtocolo");
               n546ReembolsoProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A546ReembolsoProtocolo)) ? true : false);
               Z525ReembolsoDataAberturaConvenio = context.localUtil.CToD( cgiGet( "Z525ReembolsoDataAberturaConvenio"), 0);
               n525ReembolsoDataAberturaConvenio = ((DateTime.MinValue==A525ReembolsoDataAberturaConvenio) ? true : false);
               Z742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z742WorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = ((0==A742WorkflowConvenioId) ? true : false);
               Z542ReembolsoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z542ReembolsoPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n542ReembolsoPropostaId = ((0==A542ReembolsoPropostaId) ? true : false);
               Z544ReembolsoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z544ReembolsoCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n544ReembolsoCreatedBy = ((0==A544ReembolsoCreatedBy) ? true : false);
               A742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z742WorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = false;
               n742WorkflowConvenioId = ((0==A742WorkflowConvenioId) ? true : false);
               O742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O742WorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = ((0==A742WorkflowConvenioId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N542ReembolsoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N542ReembolsoPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n542ReembolsoPropostaId = ((0==A542ReembolsoPropostaId) ? true : false);
               N544ReembolsoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N544ReembolsoCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n544ReembolsoCreatedBy = ((0==A544ReembolsoCreatedBy) ? true : false);
               N742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N742WorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = ((0==A742WorkflowConvenioId) ? true : false);
               AV7ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vREEMBOLSOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ReembolsoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_REEMBOLSOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ReembolsoPropostaId", StringUtil.LTrimStr( (decimal)(AV11Insert_ReembolsoPropostaId), 9, 0));
               AV12Insert_ReembolsoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_REEMBOLSOCREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ReembolsoCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ReembolsoCreatedBy), 4, 0));
               AV24Insert_WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_WORKFLOWCONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV24Insert_WorkflowConvenioId), 9, 0));
               A742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WORKFLOWCONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = ((0==A742WorkflowConvenioId) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A645ReembolsoValorReembolsado_F = context.localUtil.CToN( cgiGet( "REEMBOLSOVALORREEMBOLSADO_F"), ",", ".");
               n645ReembolsoValorReembolsado_F = false;
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               A736WorkflowConvenioDesc = cgiGet( "WORKFLOWCONVENIODESC");
               n736WorkflowConvenioDesc = false;
               A758ReembolsoPropostaClinicaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "REEMBOLSOPROPOSTACLINICAID"), ",", "."), 18, MidpointRounding.ToEven));
               n758ReembolsoPropostaClinicaId = false;
               AV26Pgmname = cgiGet( "vPGMNAME");
               Combo_reembolsopropostaid_Objectcall = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Objectcall");
               Combo_reembolsopropostaid_Class = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Class");
               Combo_reembolsopropostaid_Icontype = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Icontype");
               Combo_reembolsopropostaid_Icon = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Icon");
               Combo_reembolsopropostaid_Caption = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Caption");
               Combo_reembolsopropostaid_Tooltip = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Tooltip");
               Combo_reembolsopropostaid_Cls = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Cls");
               Combo_reembolsopropostaid_Selectedvalue_set = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Selectedvalue_set");
               Combo_reembolsopropostaid_Selectedvalue_get = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Selectedvalue_get");
               Combo_reembolsopropostaid_Selectedtext_set = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Selectedtext_set");
               Combo_reembolsopropostaid_Selectedtext_get = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Selectedtext_get");
               Combo_reembolsopropostaid_Gamoauthtoken = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Gamoauthtoken");
               Combo_reembolsopropostaid_Ddointernalname = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Ddointernalname");
               Combo_reembolsopropostaid_Titlecontrolalign = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Titlecontrolalign");
               Combo_reembolsopropostaid_Dropdownoptionstype = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Dropdownoptionstype");
               Combo_reembolsopropostaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Enabled"));
               Combo_reembolsopropostaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Visible"));
               Combo_reembolsopropostaid_Titlecontrolidtoreplace = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Titlecontrolidtoreplace");
               Combo_reembolsopropostaid_Datalisttype = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Datalisttype");
               Combo_reembolsopropostaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Allowmultipleselection"));
               Combo_reembolsopropostaid_Datalistfixedvalues = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Datalistfixedvalues");
               Combo_reembolsopropostaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Isgriditem"));
               Combo_reembolsopropostaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Hasdescription"));
               Combo_reembolsopropostaid_Datalistproc = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Datalistproc");
               Combo_reembolsopropostaid_Datalistprocparametersprefix = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Datalistprocparametersprefix");
               Combo_reembolsopropostaid_Remoteservicesparameters = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Remoteservicesparameters");
               Combo_reembolsopropostaid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsopropostaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Includeonlyselectedoption"));
               Combo_reembolsopropostaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Includeselectalloption"));
               Combo_reembolsopropostaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Emptyitem"));
               Combo_reembolsopropostaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Includeaddnewoption"));
               Combo_reembolsopropostaid_Htmltemplate = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Htmltemplate");
               Combo_reembolsopropostaid_Multiplevaluestype = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Multiplevaluestype");
               Combo_reembolsopropostaid_Loadingdata = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Loadingdata");
               Combo_reembolsopropostaid_Noresultsfound = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Noresultsfound");
               Combo_reembolsopropostaid_Emptyitemtext = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Emptyitemtext");
               Combo_reembolsopropostaid_Onlyselectedvalues = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Onlyselectedvalues");
               Combo_reembolsopropostaid_Selectalltext = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Selectalltext");
               Combo_reembolsopropostaid_Multiplevaluesseparator = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Multiplevaluesseparator");
               Combo_reembolsopropostaid_Addnewoptiontext = cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Addnewoptiontext");
               Combo_reembolsopropostaid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOPROPOSTAID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsocreatedby_Objectcall = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Objectcall");
               Combo_reembolsocreatedby_Class = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Class");
               Combo_reembolsocreatedby_Icontype = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Icontype");
               Combo_reembolsocreatedby_Icon = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Icon");
               Combo_reembolsocreatedby_Caption = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Caption");
               Combo_reembolsocreatedby_Tooltip = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Tooltip");
               Combo_reembolsocreatedby_Cls = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Cls");
               Combo_reembolsocreatedby_Selectedvalue_set = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Selectedvalue_set");
               Combo_reembolsocreatedby_Selectedvalue_get = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Selectedvalue_get");
               Combo_reembolsocreatedby_Selectedtext_set = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Selectedtext_set");
               Combo_reembolsocreatedby_Selectedtext_get = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Selectedtext_get");
               Combo_reembolsocreatedby_Gamoauthtoken = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Gamoauthtoken");
               Combo_reembolsocreatedby_Ddointernalname = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Ddointernalname");
               Combo_reembolsocreatedby_Titlecontrolalign = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Titlecontrolalign");
               Combo_reembolsocreatedby_Dropdownoptionstype = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Dropdownoptionstype");
               Combo_reembolsocreatedby_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Enabled"));
               Combo_reembolsocreatedby_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Visible"));
               Combo_reembolsocreatedby_Titlecontrolidtoreplace = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Titlecontrolidtoreplace");
               Combo_reembolsocreatedby_Datalisttype = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Datalisttype");
               Combo_reembolsocreatedby_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Allowmultipleselection"));
               Combo_reembolsocreatedby_Datalistfixedvalues = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Datalistfixedvalues");
               Combo_reembolsocreatedby_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Isgriditem"));
               Combo_reembolsocreatedby_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Hasdescription"));
               Combo_reembolsocreatedby_Datalistproc = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Datalistproc");
               Combo_reembolsocreatedby_Datalistprocparametersprefix = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Datalistprocparametersprefix");
               Combo_reembolsocreatedby_Remoteservicesparameters = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Remoteservicesparameters");
               Combo_reembolsocreatedby_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsocreatedby_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Includeonlyselectedoption"));
               Combo_reembolsocreatedby_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Includeselectalloption"));
               Combo_reembolsocreatedby_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Emptyitem"));
               Combo_reembolsocreatedby_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Includeaddnewoption"));
               Combo_reembolsocreatedby_Htmltemplate = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Htmltemplate");
               Combo_reembolsocreatedby_Multiplevaluestype = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Multiplevaluestype");
               Combo_reembolsocreatedby_Loadingdata = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Loadingdata");
               Combo_reembolsocreatedby_Noresultsfound = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Noresultsfound");
               Combo_reembolsocreatedby_Emptyitemtext = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Emptyitemtext");
               Combo_reembolsocreatedby_Onlyselectedvalues = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Onlyselectedvalues");
               Combo_reembolsocreatedby_Selectalltext = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Selectalltext");
               Combo_reembolsocreatedby_Multiplevaluesseparator = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Multiplevaluesseparator");
               Combo_reembolsocreatedby_Addnewoptiontext = cgiGet( "COMBO_REEMBOLSOCREATEDBY_Addnewoptiontext");
               Combo_reembolsocreatedby_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOCREATEDBY_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n518ReembolsoId = false;
               AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
               n542ReembolsoPropostaId = ((StringUtil.StrCmp(cgiGet( edtReembolsoPropostaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoPropostaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoPropostaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPROPOSTAID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A542ReembolsoPropostaId = 0;
                  n542ReembolsoPropostaId = false;
                  AssignAttri("", false, "A542ReembolsoPropostaId", (n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  A542ReembolsoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A542ReembolsoPropostaId", (n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
               }
               A550ReembolsoPropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname));
               n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
               AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
               A558ReembolsoPropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoPropostaPacienteClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n558ReembolsoPropostaPacienteClienteId = false;
               AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
               A546ReembolsoProtocolo = cgiGet( edtReembolsoProtocolo_Internalname);
               n546ReembolsoProtocolo = false;
               AssignAttri("", false, "A546ReembolsoProtocolo", A546ReembolsoProtocolo);
               n546ReembolsoProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A546ReembolsoProtocolo)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtReembolsoCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data de inicio"}), 1, "REEMBOLSOCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
                  n522ReembolsoCreatedAt = false;
                  AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A522ReembolsoCreatedAt = context.localUtil.CToT( cgiGet( edtReembolsoCreatedAt_Internalname));
                  n522ReembolsoCreatedAt = false;
                  AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               n522ReembolsoCreatedAt = ((DateTime.MinValue==A522ReembolsoCreatedAt) ? true : false);
               A543ReembolsoPropostaValor = context.localUtil.CToN( cgiGet( edtReembolsoPropostaValor_Internalname), ",", ".");
               n543ReembolsoPropostaValor = false;
               AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrimStr( A543ReembolsoPropostaValor, 18, 2));
               if ( context.localUtil.VCDate( cgiGet( edtReembolsoDataAberturaConvenio_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data abertura"}), 1, "REEMBOLSODATAABERTURACONVENIO");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoDataAberturaConvenio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
                  n525ReembolsoDataAberturaConvenio = false;
                  AssignAttri("", false, "A525ReembolsoDataAberturaConvenio", context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"));
               }
               else
               {
                  A525ReembolsoDataAberturaConvenio = context.localUtil.CToD( cgiGet( edtReembolsoDataAberturaConvenio_Internalname), 2);
                  n525ReembolsoDataAberturaConvenio = false;
                  AssignAttri("", false, "A525ReembolsoDataAberturaConvenio", context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"));
               }
               n525ReembolsoDataAberturaConvenio = ((DateTime.MinValue==A525ReembolsoDataAberturaConvenio) ? true : false);
               n544ReembolsoCreatedBy = ((StringUtil.StrCmp(cgiGet( edtReembolsoCreatedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoCreatedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoCreatedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOCREATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoCreatedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A544ReembolsoCreatedBy = 0;
                  n544ReembolsoCreatedBy = false;
                  AssignAttri("", false, "A544ReembolsoCreatedBy", (n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A544ReembolsoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A544ReembolsoCreatedBy", (n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
               }
               A547ReembolsoEtapaUltimo_F = context.localUtil.CToT( cgiGet( edtReembolsoEtapaUltimo_F_Internalname));
               n547ReembolsoEtapaUltimo_F = false;
               AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
               cmbReembolsoStatusAtual_F.CurrentValue = cgiGet( cmbReembolsoStatusAtual_F_Internalname);
               A548ReembolsoStatusAtual_F = cgiGet( cmbReembolsoStatusAtual_F_Internalname);
               n548ReembolsoStatusAtual_F = false;
               AssignAttri("", false, "A548ReembolsoStatusAtual_F", A548ReembolsoStatusAtual_F);
               AV19ComboReembolsoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboreembolsopropostaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboReembolsoPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoPropostaId), 9, 0));
               AV22ComboReembolsoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboreembolsocreatedby_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22ComboReembolsoCreatedBy", StringUtil.LTrimStr( (decimal)(AV22ComboReembolsoCreatedBy), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Reembolso");
               A518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n518ReembolsoId = false;
               AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
               forbiddenHiddens.Add("ReembolsoId", context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ReembolsoPropostaId", context.localUtil.Format( (decimal)(AV11Insert_ReembolsoPropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ReembolsoCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ReembolsoCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_WorkflowConvenioId", context.localUtil.Format( (decimal)(AV24Insert_WorkflowConvenioId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A518ReembolsoId != Z518ReembolsoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("reembolso:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
                  n518ReembolsoId = false;
                  AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode71 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode71;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound71 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1Y0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "REEMBOLSOID");
                        AnyError = 1;
                        GX_FocusControl = edtReembolsoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E121Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1Y71( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1Y71( ) ;
         }
         AssignProp("", false, edtavComboreembolsopropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsopropostaid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboreembolsocreatedby_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsocreatedby_Enabled), 5, 0), true);
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

      protected void CONFIRM_1Y0( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Y71( ) ;
            }
            else
            {
               CheckExtendedTable1Y71( ) ;
               CloseExtendedTableCursors1Y71( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1Y0( )
      {
      }

      protected void E111Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtReembolsoCreatedBy_Visible = 0;
         AssignProp("", false, edtReembolsoCreatedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReembolsoCreatedBy_Visible), 5, 0), true);
         AV22ComboReembolsoCreatedBy = 0;
         AssignAttri("", false, "AV22ComboReembolsoCreatedBy", StringUtil.LTrimStr( (decimal)(AV22ComboReembolsoCreatedBy), 4, 0));
         edtavComboreembolsocreatedby_Visible = 0;
         AssignProp("", false, edtavComboreembolsocreatedby_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreembolsocreatedby_Visible), 5, 0), true);
         edtReembolsoPropostaId_Visible = 0;
         AssignProp("", false, edtReembolsoPropostaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaId_Visible), 5, 0), true);
         AV19ComboReembolsoPropostaId = 0;
         AssignAttri("", false, "AV19ComboReembolsoPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoPropostaId), 9, 0));
         edtavComboreembolsopropostaid_Visible = 0;
         AssignProp("", false, edtavComboreembolsopropostaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreembolsopropostaid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOREEMBOLSOPROPOSTAID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOREEMBOLSOCREATEDBY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ReembolsoPropostaId") == 0 )
               {
                  AV11Insert_ReembolsoPropostaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ReembolsoPropostaId", StringUtil.LTrimStr( (decimal)(AV11Insert_ReembolsoPropostaId), 9, 0));
                  if ( ! (0==AV11Insert_ReembolsoPropostaId) )
                  {
                     AV19ComboReembolsoPropostaId = AV11Insert_ReembolsoPropostaId;
                     AssignAttri("", false, "AV19ComboReembolsoPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoPropostaId), 9, 0));
                     Combo_reembolsopropostaid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboReembolsoPropostaId), 9, 0));
                     ucCombo_reembolsopropostaid.SendProperty(context, "", false, Combo_reembolsopropostaid_Internalname, "SelectedValue_set", Combo_reembolsopropostaid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new reembolsoloaddvcombo(context ).execute(  "ReembolsoPropostaId",  "GET",  false,  AV7ReembolsoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_reembolsopropostaid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_reembolsopropostaid.SendProperty(context, "", false, Combo_reembolsopropostaid_Internalname, "SelectedText_set", Combo_reembolsopropostaid_Selectedtext_set);
                     Combo_reembolsopropostaid_Enabled = false;
                     ucCombo_reembolsopropostaid.SendProperty(context, "", false, Combo_reembolsopropostaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsopropostaid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ReembolsoCreatedBy") == 0 )
               {
                  AV12Insert_ReembolsoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ReembolsoCreatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_ReembolsoCreatedBy), 4, 0));
                  if ( ! (0==AV12Insert_ReembolsoCreatedBy) )
                  {
                     AV22ComboReembolsoCreatedBy = AV12Insert_ReembolsoCreatedBy;
                     AssignAttri("", false, "AV22ComboReembolsoCreatedBy", StringUtil.LTrimStr( (decimal)(AV22ComboReembolsoCreatedBy), 4, 0));
                     Combo_reembolsocreatedby_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ComboReembolsoCreatedBy), 4, 0));
                     ucCombo_reembolsocreatedby.SendProperty(context, "", false, Combo_reembolsocreatedby_Internalname, "SelectedValue_set", Combo_reembolsocreatedby_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new reembolsoloaddvcombo(context ).execute(  "ReembolsoCreatedBy",  "GET",  false,  AV7ReembolsoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_reembolsocreatedby_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_reembolsocreatedby.SendProperty(context, "", false, Combo_reembolsocreatedby_Internalname, "SelectedText_set", Combo_reembolsocreatedby_Selectedtext_set);
                     Combo_reembolsocreatedby_Enabled = false;
                     ucCombo_reembolsocreatedby.SendProperty(context, "", false, Combo_reembolsocreatedby_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsocreatedby_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WorkflowConvenioId") == 0 )
               {
                  AV24Insert_WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV24Insert_WorkflowConvenioId), 9, 0));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
      }

      protected void E121Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("reembolsoww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOREEMBOLSOCREATEDBY' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new reembolsoloaddvcombo(context ).execute(  "ReembolsoCreatedBy",  Gx_mode,  false,  AV7ReembolsoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_reembolsocreatedby_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_reembolsocreatedby.SendProperty(context, "", false, Combo_reembolsocreatedby_Internalname, "SelectedValue_set", Combo_reembolsocreatedby_Selectedvalue_set);
         Combo_reembolsocreatedby_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_reembolsocreatedby.SendProperty(context, "", false, Combo_reembolsocreatedby_Internalname, "SelectedText_set", Combo_reembolsocreatedby_Selectedtext_set);
         AV22ComboReembolsoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV22ComboReembolsoCreatedBy", StringUtil.LTrimStr( (decimal)(AV22ComboReembolsoCreatedBy), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_reembolsocreatedby_Enabled = false;
            ucCombo_reembolsocreatedby.SendProperty(context, "", false, Combo_reembolsocreatedby_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsocreatedby_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOREEMBOLSOPROPOSTAID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new reembolsoloaddvcombo(context ).execute(  "ReembolsoPropostaId",  Gx_mode,  false,  AV7ReembolsoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_reembolsopropostaid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_reembolsopropostaid.SendProperty(context, "", false, Combo_reembolsopropostaid_Internalname, "SelectedValue_set", Combo_reembolsopropostaid_Selectedvalue_set);
         Combo_reembolsopropostaid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_reembolsopropostaid.SendProperty(context, "", false, Combo_reembolsopropostaid_Internalname, "SelectedText_set", Combo_reembolsopropostaid_Selectedtext_set);
         AV19ComboReembolsoPropostaId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboReembolsoPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoPropostaId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_reembolsopropostaid_Enabled = false;
            ucCombo_reembolsopropostaid.SendProperty(context, "", false, Combo_reembolsopropostaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsopropostaid_Enabled));
         }
      }

      protected void ZM1Y71( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z522ReembolsoCreatedAt = T001Y3_A522ReembolsoCreatedAt[0];
               Z546ReembolsoProtocolo = T001Y3_A546ReembolsoProtocolo[0];
               Z525ReembolsoDataAberturaConvenio = T001Y3_A525ReembolsoDataAberturaConvenio[0];
               Z742WorkflowConvenioId = T001Y3_A742WorkflowConvenioId[0];
               Z542ReembolsoPropostaId = T001Y3_A542ReembolsoPropostaId[0];
               Z544ReembolsoCreatedBy = T001Y3_A544ReembolsoCreatedBy[0];
            }
            else
            {
               Z522ReembolsoCreatedAt = A522ReembolsoCreatedAt;
               Z546ReembolsoProtocolo = A546ReembolsoProtocolo;
               Z525ReembolsoDataAberturaConvenio = A525ReembolsoDataAberturaConvenio;
               Z742WorkflowConvenioId = A742WorkflowConvenioId;
               Z542ReembolsoPropostaId = A542ReembolsoPropostaId;
               Z544ReembolsoCreatedBy = A544ReembolsoCreatedBy;
            }
         }
         if ( GX_JID == -18 )
         {
            Z518ReembolsoId = A518ReembolsoId;
            Z522ReembolsoCreatedAt = A522ReembolsoCreatedAt;
            Z546ReembolsoProtocolo = A546ReembolsoProtocolo;
            Z525ReembolsoDataAberturaConvenio = A525ReembolsoDataAberturaConvenio;
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            Z542ReembolsoPropostaId = A542ReembolsoPropostaId;
            Z544ReembolsoCreatedBy = A544ReembolsoCreatedBy;
            Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z543ReembolsoPropostaValor = A543ReembolsoPropostaValor;
            Z558ReembolsoPropostaPacienteClienteId = A558ReembolsoPropostaPacienteClienteId;
            Z758ReembolsoPropostaClinicaId = A758ReembolsoPropostaClinicaId;
            Z550ReembolsoPropostaPacienteClienteRazaoSocial = A550ReembolsoPropostaPacienteClienteRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         edtReembolsoId_Enabled = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         AV26Pgmname = "Reembolso";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtReembolsoId_Enabled = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ReembolsoId) )
         {
            A518ReembolsoId = AV7ReembolsoId;
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ReembolsoPropostaId) )
         {
            edtReembolsoPropostaId_Enabled = 0;
            AssignProp("", false, edtReembolsoPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaId_Enabled), 5, 0), true);
         }
         else
         {
            edtReembolsoPropostaId_Enabled = 1;
            AssignProp("", false, edtReembolsoPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoCreatedBy) )
         {
            edtReembolsoCreatedBy_Enabled = 0;
            AssignProp("", false, edtReembolsoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoCreatedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtReembolsoCreatedBy_Enabled = 1;
            AssignProp("", false, edtReembolsoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoCreatedBy_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_WorkflowConvenioId) )
         {
            A742WorkflowConvenioId = AV24Insert_WorkflowConvenioId;
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n522ReembolsoCreatedAt = false;
            AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A522ReembolsoCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n522ReembolsoCreatedAt = false;
               AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001Y12 */
            pr_default.execute(7, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A645ReembolsoValorReembolsado_F = T001Y12_A645ReembolsoValorReembolsado_F[0];
               n645ReembolsoValorReembolsado_F = T001Y12_n645ReembolsoValorReembolsado_F[0];
            }
            else
            {
               A645ReembolsoValorReembolsado_F = 0;
               n645ReembolsoValorReembolsado_F = false;
               AssignAttri("", false, "A645ReembolsoValorReembolsado_F", StringUtil.LTrimStr( A645ReembolsoValorReembolsado_F, 18, 2));
            }
            pr_default.close(7);
            /* Using cursor T001Y14 */
            pr_default.execute(8, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A547ReembolsoEtapaUltimo_F = T001Y14_A547ReembolsoEtapaUltimo_F[0];
               n547ReembolsoEtapaUltimo_F = T001Y14_n547ReembolsoEtapaUltimo_F[0];
               AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
               n547ReembolsoEtapaUltimo_F = false;
               AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
            }
            pr_default.close(8);
            /* Using cursor T001Y7 */
            pr_default.execute(3, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            A736WorkflowConvenioDesc = T001Y7_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = T001Y7_n736WorkflowConvenioDesc[0];
            pr_default.close(3);
         }
      }

      protected void Load1Y71( )
      {
         /* Using cursor T001Y17 */
         pr_default.execute(9, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound71 = 1;
            A522ReembolsoCreatedAt = T001Y17_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = T001Y17_n522ReembolsoCreatedAt[0];
            AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
            A546ReembolsoProtocolo = T001Y17_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = T001Y17_n546ReembolsoProtocolo[0];
            AssignAttri("", false, "A546ReembolsoProtocolo", A546ReembolsoProtocolo);
            A543ReembolsoPropostaValor = T001Y17_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = T001Y17_n543ReembolsoPropostaValor[0];
            AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrimStr( A543ReembolsoPropostaValor, 18, 2));
            A525ReembolsoDataAberturaConvenio = T001Y17_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = T001Y17_n525ReembolsoDataAberturaConvenio[0];
            AssignAttri("", false, "A525ReembolsoDataAberturaConvenio", context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"));
            A736WorkflowConvenioDesc = T001Y17_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = T001Y17_n736WorkflowConvenioDesc[0];
            A742WorkflowConvenioId = T001Y17_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = T001Y17_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = T001Y17_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = T001Y17_n542ReembolsoPropostaId[0];
            AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
            A544ReembolsoCreatedBy = T001Y17_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = T001Y17_n544ReembolsoCreatedBy[0];
            AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
            A558ReembolsoPropostaPacienteClienteId = T001Y17_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = T001Y17_n558ReembolsoPropostaPacienteClienteId[0];
            AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
            A758ReembolsoPropostaClinicaId = T001Y17_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = T001Y17_n758ReembolsoPropostaClinicaId[0];
            A645ReembolsoValorReembolsado_F = T001Y17_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = T001Y17_n645ReembolsoValorReembolsado_F[0];
            A547ReembolsoEtapaUltimo_F = T001Y17_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = T001Y17_n547ReembolsoEtapaUltimo_F[0];
            AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
            ZM1Y71( -18) ;
         }
         pr_default.close(9);
         OnLoadActions1Y71( ) ;
      }

      protected void OnLoadActions1Y71( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ReembolsoPropostaId) )
         {
            A542ReembolsoPropostaId = AV11Insert_ReembolsoPropostaId;
            n542ReembolsoPropostaId = false;
            AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboReembolsoPropostaId) )
            {
               A542ReembolsoPropostaId = 0;
               n542ReembolsoPropostaId = false;
               AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
               n542ReembolsoPropostaId = true;
               n542ReembolsoPropostaId = true;
               AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboReembolsoPropostaId) )
               {
                  A542ReembolsoPropostaId = AV19ComboReembolsoPropostaId;
                  n542ReembolsoPropostaId = false;
                  AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A542ReembolsoPropostaId) )
                  {
                     A542ReembolsoPropostaId = 0;
                     n542ReembolsoPropostaId = false;
                     AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
                     n542ReembolsoPropostaId = true;
                     n542ReembolsoPropostaId = true;
                     AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoCreatedBy) )
         {
            A544ReembolsoCreatedBy = AV12Insert_ReembolsoCreatedBy;
            n544ReembolsoCreatedBy = false;
            AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV22ComboReembolsoCreatedBy) )
            {
               A544ReembolsoCreatedBy = 0;
               n544ReembolsoCreatedBy = false;
               AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
               n544ReembolsoCreatedBy = true;
               n544ReembolsoCreatedBy = true;
               AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV22ComboReembolsoCreatedBy) )
               {
                  A544ReembolsoCreatedBy = AV22ComboReembolsoCreatedBy;
                  n544ReembolsoCreatedBy = false;
                  AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  if ( IsIns( )  )
                  {
                     A544ReembolsoCreatedBy = AV8WWPContext.gxTpr_Userid;
                     n544ReembolsoCreatedBy = false;
                     AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
                  }
                  else
                  {
                     if ( (0==A544ReembolsoCreatedBy) )
                     {
                        A544ReembolsoCreatedBy = 0;
                        n544ReembolsoCreatedBy = false;
                        AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
                        n544ReembolsoCreatedBy = true;
                        n544ReembolsoCreatedBy = true;
                        AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
                     }
                  }
               }
            }
         }
      }

      protected void CheckExtendedTable1Y71( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ReembolsoPropostaId) )
         {
            A542ReembolsoPropostaId = AV11Insert_ReembolsoPropostaId;
            n542ReembolsoPropostaId = false;
            AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboReembolsoPropostaId) )
            {
               A542ReembolsoPropostaId = 0;
               n542ReembolsoPropostaId = false;
               AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
               n542ReembolsoPropostaId = true;
               n542ReembolsoPropostaId = true;
               AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboReembolsoPropostaId) )
               {
                  A542ReembolsoPropostaId = AV19ComboReembolsoPropostaId;
                  n542ReembolsoPropostaId = false;
                  AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A542ReembolsoPropostaId) )
                  {
                     A542ReembolsoPropostaId = 0;
                     n542ReembolsoPropostaId = false;
                     AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
                     n542ReembolsoPropostaId = true;
                     n542ReembolsoPropostaId = true;
                     AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoCreatedBy) )
         {
            A544ReembolsoCreatedBy = AV12Insert_ReembolsoCreatedBy;
            n544ReembolsoCreatedBy = false;
            AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV22ComboReembolsoCreatedBy) )
            {
               A544ReembolsoCreatedBy = 0;
               n544ReembolsoCreatedBy = false;
               AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
               n544ReembolsoCreatedBy = true;
               n544ReembolsoCreatedBy = true;
               AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV22ComboReembolsoCreatedBy) )
               {
                  A544ReembolsoCreatedBy = AV22ComboReembolsoCreatedBy;
                  n544ReembolsoCreatedBy = false;
                  AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  if ( IsIns( )  )
                  {
                     A544ReembolsoCreatedBy = AV8WWPContext.gxTpr_Userid;
                     n544ReembolsoCreatedBy = false;
                     AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
                  }
                  else
                  {
                     if ( (0==A544ReembolsoCreatedBy) )
                     {
                        A544ReembolsoCreatedBy = 0;
                        n544ReembolsoCreatedBy = false;
                        AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
                        n544ReembolsoCreatedBy = true;
                        n544ReembolsoCreatedBy = true;
                        AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
                     }
                  }
               }
            }
         }
         /* Using cursor T001Y12 */
         pr_default.execute(7, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A645ReembolsoValorReembolsado_F = T001Y12_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = T001Y12_n645ReembolsoValorReembolsado_F[0];
         }
         else
         {
            A645ReembolsoValorReembolsado_F = 0;
            n645ReembolsoValorReembolsado_F = false;
            AssignAttri("", false, "A645ReembolsoValorReembolsado_F", StringUtil.LTrimStr( A645ReembolsoValorReembolsado_F, 18, 2));
         }
         pr_default.close(7);
         if ( ( A645ReembolsoValorReembolsado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001Y14 */
         pr_default.execute(8, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A547ReembolsoEtapaUltimo_F = T001Y14_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = T001Y14_n547ReembolsoEtapaUltimo_F[0];
            AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
            n547ReembolsoEtapaUltimo_F = false;
            AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
         }
         pr_default.close(8);
         /* Using cursor T001Y8 */
         pr_default.execute(4, new Object[] {n542ReembolsoPropostaId, A542ReembolsoPropostaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A542ReembolsoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Proposta'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A543ReembolsoPropostaValor = T001Y8_A543ReembolsoPropostaValor[0];
         n543ReembolsoPropostaValor = T001Y8_n543ReembolsoPropostaValor[0];
         AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrimStr( A543ReembolsoPropostaValor, 18, 2));
         A558ReembolsoPropostaPacienteClienteId = T001Y8_A558ReembolsoPropostaPacienteClienteId[0];
         n558ReembolsoPropostaPacienteClienteId = T001Y8_n558ReembolsoPropostaPacienteClienteId[0];
         AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
         A758ReembolsoPropostaClinicaId = T001Y8_A758ReembolsoPropostaClinicaId[0];
         n758ReembolsoPropostaClinicaId = T001Y8_n758ReembolsoPropostaClinicaId[0];
         pr_default.close(4);
         if ( ( A543ReembolsoPropostaValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001Y10 */
         pr_default.execute(6, new Object[] {n558ReembolsoPropostaPacienteClienteId, A558ReembolsoPropostaPacienteClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A558ReembolsoPropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         n550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
         pr_default.close(6);
         /* Using cursor T001Y9 */
         pr_default.execute(5, new Object[] {n544ReembolsoCreatedBy, A544ReembolsoCreatedBy});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A544ReembolsoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Usuario'.", "ForeignKeyNotFound", 1, "REEMBOLSOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtReembolsoCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T001Y7 */
         pr_default.execute(3, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A742WorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'WorkflowConvenio'.", "ForeignKeyNotFound", 1, "WORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A736WorkflowConvenioDesc = T001Y7_A736WorkflowConvenioDesc[0];
         n736WorkflowConvenioDesc = T001Y7_n736WorkflowConvenioDesc[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Y71( )
      {
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(5);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( int A518ReembolsoId )
      {
         /* Using cursor T001Y19 */
         pr_default.execute(10, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A645ReembolsoValorReembolsado_F = T001Y19_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = T001Y19_n645ReembolsoValorReembolsado_F[0];
         }
         else
         {
            A645ReembolsoValorReembolsado_F = 0;
            n645ReembolsoValorReembolsado_F = false;
            AssignAttri("", false, "A645ReembolsoValorReembolsado_F", StringUtil.LTrimStr( A645ReembolsoValorReembolsado_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A645ReembolsoValorReembolsado_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_25( int A518ReembolsoId )
      {
         /* Using cursor T001Y21 */
         pr_default.execute(11, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A547ReembolsoEtapaUltimo_F = T001Y21_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = T001Y21_n547ReembolsoEtapaUltimo_F[0];
            AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
            n547ReembolsoEtapaUltimo_F = false;
            AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 10, 8, 0, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_21( int A542ReembolsoPropostaId )
      {
         /* Using cursor T001Y22 */
         pr_default.execute(12, new Object[] {n542ReembolsoPropostaId, A542ReembolsoPropostaId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A542ReembolsoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Proposta'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A543ReembolsoPropostaValor = T001Y22_A543ReembolsoPropostaValor[0];
         n543ReembolsoPropostaValor = T001Y22_n543ReembolsoPropostaValor[0];
         AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrimStr( A543ReembolsoPropostaValor, 18, 2));
         A558ReembolsoPropostaPacienteClienteId = T001Y22_A558ReembolsoPropostaPacienteClienteId[0];
         n558ReembolsoPropostaPacienteClienteId = T001Y22_n558ReembolsoPropostaPacienteClienteId[0];
         AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
         A758ReembolsoPropostaClinicaId = T001Y22_A758ReembolsoPropostaClinicaId[0];
         n758ReembolsoPropostaClinicaId = T001Y22_n758ReembolsoPropostaClinicaId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A543ReembolsoPropostaValor, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A758ReembolsoPropostaClinicaId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_23( int A558ReembolsoPropostaPacienteClienteId )
      {
         /* Using cursor T001Y23 */
         pr_default.execute(13, new Object[] {n558ReembolsoPropostaPacienteClienteId, A558ReembolsoPropostaPacienteClienteId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A558ReembolsoPropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y23_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         n550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y23_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A550ReembolsoPropostaPacienteClienteRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_22( short A544ReembolsoCreatedBy )
      {
         /* Using cursor T001Y24 */
         pr_default.execute(14, new Object[] {n544ReembolsoCreatedBy, A544ReembolsoCreatedBy});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A544ReembolsoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Usuario'.", "ForeignKeyNotFound", 1, "REEMBOLSOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtReembolsoCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_20( int A742WorkflowConvenioId )
      {
         /* Using cursor T001Y25 */
         pr_default.execute(15, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A742WorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'WorkflowConvenio'.", "ForeignKeyNotFound", 1, "WORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A736WorkflowConvenioDesc = T001Y25_A736WorkflowConvenioDesc[0];
         n736WorkflowConvenioDesc = T001Y25_n736WorkflowConvenioDesc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A736WorkflowConvenioDesc)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey1Y71( )
      {
         /* Using cursor T001Y26 */
         pr_default.execute(16, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Y3 */
         pr_default.execute(1, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Y71( 18) ;
            RcdFound71 = 1;
            A518ReembolsoId = T001Y3_A518ReembolsoId[0];
            n518ReembolsoId = T001Y3_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
            A522ReembolsoCreatedAt = T001Y3_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = T001Y3_n522ReembolsoCreatedAt[0];
            AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A546ReembolsoProtocolo = T001Y3_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = T001Y3_n546ReembolsoProtocolo[0];
            AssignAttri("", false, "A546ReembolsoProtocolo", A546ReembolsoProtocolo);
            A525ReembolsoDataAberturaConvenio = T001Y3_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = T001Y3_n525ReembolsoDataAberturaConvenio[0];
            AssignAttri("", false, "A525ReembolsoDataAberturaConvenio", context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"));
            A742WorkflowConvenioId = T001Y3_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = T001Y3_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = T001Y3_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = T001Y3_n542ReembolsoPropostaId[0];
            AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
            A544ReembolsoCreatedBy = T001Y3_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = T001Y3_n544ReembolsoCreatedBy[0];
            AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
            O742WorkflowConvenioId = A742WorkflowConvenioId;
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
            Z518ReembolsoId = A518ReembolsoId;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1Y71( ) ;
            if ( AnyError == 1 )
            {
               RcdFound71 = 0;
               InitializeNonKey1Y71( ) ;
            }
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound71 = 0;
            InitializeNonKey1Y71( ) ;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Y71( ) ;
         if ( RcdFound71 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound71 = 0;
         /* Using cursor T001Y27 */
         pr_default.execute(17, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T001Y27_A518ReembolsoId[0] < A518ReembolsoId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T001Y27_A518ReembolsoId[0] > A518ReembolsoId ) ) )
            {
               A518ReembolsoId = T001Y27_A518ReembolsoId[0];
               n518ReembolsoId = T001Y27_n518ReembolsoId[0];
               AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
               RcdFound71 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void move_previous( )
      {
         RcdFound71 = 0;
         /* Using cursor T001Y28 */
         pr_default.execute(18, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( T001Y28_A518ReembolsoId[0] > A518ReembolsoId ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( T001Y28_A518ReembolsoId[0] < A518ReembolsoId ) ) )
            {
               A518ReembolsoId = T001Y28_A518ReembolsoId[0];
               n518ReembolsoId = T001Y28_n518ReembolsoId[0];
               AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
               RcdFound71 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Y71( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtReembolsoPropostaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Y71( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound71 == 1 )
            {
               if ( A518ReembolsoId != Z518ReembolsoId )
               {
                  A518ReembolsoId = Z518ReembolsoId;
                  n518ReembolsoId = false;
                  AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSOID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtReembolsoPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1Y71( ) ;
                  GX_FocusControl = edtReembolsoPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A518ReembolsoId != Z518ReembolsoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtReembolsoPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Y71( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSOID");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtReembolsoPropostaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Y71( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A518ReembolsoId != Z518ReembolsoId )
         {
            A518ReembolsoId = Z518ReembolsoId;
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSOID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtReembolsoPropostaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1Y71( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Y2 */
            pr_default.execute(0, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reembolso"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z522ReembolsoCreatedAt != T001Y2_A522ReembolsoCreatedAt[0] ) || ( StringUtil.StrCmp(Z546ReembolsoProtocolo, T001Y2_A546ReembolsoProtocolo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z525ReembolsoDataAberturaConvenio ) != DateTimeUtil.ResetTime ( T001Y2_A525ReembolsoDataAberturaConvenio[0] ) ) || ( Z742WorkflowConvenioId != T001Y2_A742WorkflowConvenioId[0] ) || ( Z542ReembolsoPropostaId != T001Y2_A542ReembolsoPropostaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z544ReembolsoCreatedBy != T001Y2_A544ReembolsoCreatedBy[0] ) )
            {
               if ( Z522ReembolsoCreatedAt != T001Y2_A522ReembolsoCreatedAt[0] )
               {
                  GXUtil.WriteLog("reembolso:[seudo value changed for attri]"+"ReembolsoCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z522ReembolsoCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A522ReembolsoCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z546ReembolsoProtocolo, T001Y2_A546ReembolsoProtocolo[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolso:[seudo value changed for attri]"+"ReembolsoProtocolo");
                  GXUtil.WriteLogRaw("Old: ",Z546ReembolsoProtocolo);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A546ReembolsoProtocolo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z525ReembolsoDataAberturaConvenio ) != DateTimeUtil.ResetTime ( T001Y2_A525ReembolsoDataAberturaConvenio[0] ) )
               {
                  GXUtil.WriteLog("reembolso:[seudo value changed for attri]"+"ReembolsoDataAberturaConvenio");
                  GXUtil.WriteLogRaw("Old: ",Z525ReembolsoDataAberturaConvenio);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A525ReembolsoDataAberturaConvenio[0]);
               }
               if ( Z742WorkflowConvenioId != T001Y2_A742WorkflowConvenioId[0] )
               {
                  GXUtil.WriteLog("reembolso:[seudo value changed for attri]"+"WorkflowConvenioId");
                  GXUtil.WriteLogRaw("Old: ",Z742WorkflowConvenioId);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A742WorkflowConvenioId[0]);
               }
               if ( Z542ReembolsoPropostaId != T001Y2_A542ReembolsoPropostaId[0] )
               {
                  GXUtil.WriteLog("reembolso:[seudo value changed for attri]"+"ReembolsoPropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z542ReembolsoPropostaId);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A542ReembolsoPropostaId[0]);
               }
               if ( Z544ReembolsoCreatedBy != T001Y2_A544ReembolsoCreatedBy[0] )
               {
                  GXUtil.WriteLog("reembolso:[seudo value changed for attri]"+"ReembolsoCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z544ReembolsoCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A544ReembolsoCreatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reembolso"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Y71( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Y71( 0) ;
            CheckOptimisticConcurrency1Y71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Y71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y29 */
                     pr_default.execute(19, new Object[] {n522ReembolsoCreatedAt, A522ReembolsoCreatedAt, n546ReembolsoProtocolo, A546ReembolsoProtocolo, n525ReembolsoDataAberturaConvenio, A525ReembolsoDataAberturaConvenio, n742WorkflowConvenioId, A742WorkflowConvenioId, n542ReembolsoPropostaId, A542ReembolsoPropostaId, n544ReembolsoCreatedBy, A544ReembolsoCreatedBy});
                     pr_default.close(19);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001Y30 */
                     pr_default.execute(20);
                     A518ReembolsoId = T001Y30_A518ReembolsoId[0];
                     n518ReembolsoId = T001Y30_n518ReembolsoId[0];
                     AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Reembolso");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1Y0( ) ;
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
               Load1Y71( ) ;
            }
            EndLevel1Y71( ) ;
         }
         CloseExtendedTableCursors1Y71( ) ;
      }

      protected void Update1Y71( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Y71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y31 */
                     pr_default.execute(21, new Object[] {n522ReembolsoCreatedAt, A522ReembolsoCreatedAt, n546ReembolsoProtocolo, A546ReembolsoProtocolo, n525ReembolsoDataAberturaConvenio, A525ReembolsoDataAberturaConvenio, n742WorkflowConvenioId, A742WorkflowConvenioId, n542ReembolsoPropostaId, A542ReembolsoPropostaId, n544ReembolsoCreatedBy, A544ReembolsoCreatedBy, n518ReembolsoId, A518ReembolsoId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Reembolso");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reembolso"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Y71( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( A742WorkflowConvenioId != O742WorkflowConvenioId )
                        {
                           new prlogreembolso(context ).execute(  A518ReembolsoId,  A742WorkflowConvenioId,  AV8WWPContext.gxTpr_Userid) ;
                        }
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel1Y71( ) ;
         }
         CloseExtendedTableCursors1Y71( ) ;
      }

      protected void DeferredUpdate1Y71( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Y71( ) ;
            AfterConfirm1Y71( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Y71( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Y32 */
                  pr_default.execute(22, new Object[] {n518ReembolsoId, A518ReembolsoId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("Reembolso");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode71 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Y71( ) ;
         Gx_mode = sMode71;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Y71( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001Y34 */
            pr_default.execute(23, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A645ReembolsoValorReembolsado_F = T001Y34_A645ReembolsoValorReembolsado_F[0];
               n645ReembolsoValorReembolsado_F = T001Y34_n645ReembolsoValorReembolsado_F[0];
            }
            else
            {
               A645ReembolsoValorReembolsado_F = 0;
               n645ReembolsoValorReembolsado_F = false;
               AssignAttri("", false, "A645ReembolsoValorReembolsado_F", StringUtil.LTrimStr( A645ReembolsoValorReembolsado_F, 18, 2));
            }
            pr_default.close(23);
            /* Using cursor T001Y36 */
            pr_default.execute(24, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A547ReembolsoEtapaUltimo_F = T001Y36_A547ReembolsoEtapaUltimo_F[0];
               n547ReembolsoEtapaUltimo_F = T001Y36_n547ReembolsoEtapaUltimo_F[0];
               AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
               n547ReembolsoEtapaUltimo_F = false;
               AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
            }
            pr_default.close(24);
            /* Using cursor T001Y37 */
            pr_default.execute(25, new Object[] {n542ReembolsoPropostaId, A542ReembolsoPropostaId});
            A543ReembolsoPropostaValor = T001Y37_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = T001Y37_n543ReembolsoPropostaValor[0];
            AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrimStr( A543ReembolsoPropostaValor, 18, 2));
            A558ReembolsoPropostaPacienteClienteId = T001Y37_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = T001Y37_n558ReembolsoPropostaPacienteClienteId[0];
            AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
            A758ReembolsoPropostaClinicaId = T001Y37_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = T001Y37_n758ReembolsoPropostaClinicaId[0];
            pr_default.close(25);
            /* Using cursor T001Y38 */
            pr_default.execute(26, new Object[] {n558ReembolsoPropostaPacienteClienteId, A558ReembolsoPropostaPacienteClienteId});
            A550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y38_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y38_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
            pr_default.close(26);
            /* Using cursor T001Y39 */
            pr_default.execute(27, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            A736WorkflowConvenioDesc = T001Y39_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = T001Y39_n736WorkflowConvenioDesc[0];
            pr_default.close(27);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001Y40 */
            pr_default.execute(28, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T001Y41 */
            pr_default.execute(29, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoParcelas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T001Y42 */
            pr_default.execute(30, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoAssinaturas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T001Y43 */
            pr_default.execute(31, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoEtapa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
         }
      }

      protected void EndLevel1Y71( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1Y0( ) ;
            }
            /* After transaction rules */
            if ( A742WorkflowConvenioId != O742WorkflowConvenioId )
            {
               new prlogreembolso(context ).execute(  A518ReembolsoId,  A742WorkflowConvenioId,  AV8WWPContext.gxTpr_Userid) ;
            }
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

      public void ScanStart1Y71( )
      {
         /* Scan By routine */
         /* Using cursor T001Y44 */
         pr_default.execute(32);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound71 = 1;
            A518ReembolsoId = T001Y44_A518ReembolsoId[0];
            n518ReembolsoId = T001Y44_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Y71( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound71 = 1;
            A518ReembolsoId = T001Y44_A518ReembolsoId[0];
            n518ReembolsoId = T001Y44_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
         }
      }

      protected void ScanEnd1Y71( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm1Y71( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Y71( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Y71( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Y71( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Y71( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Y71( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Y71( )
      {
         edtReembolsoId_Enabled = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         edtReembolsoPropostaId_Enabled = 0;
         AssignProp("", false, edtReembolsoPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaId_Enabled), 5, 0), true);
         edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled = 0;
         AssignProp("", false, edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled), 5, 0), true);
         edtReembolsoPropostaPacienteClienteId_Enabled = 0;
         AssignProp("", false, edtReembolsoPropostaPacienteClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaPacienteClienteId_Enabled), 5, 0), true);
         edtReembolsoProtocolo_Enabled = 0;
         AssignProp("", false, edtReembolsoProtocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoProtocolo_Enabled), 5, 0), true);
         edtReembolsoCreatedAt_Enabled = 0;
         AssignProp("", false, edtReembolsoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoCreatedAt_Enabled), 5, 0), true);
         edtReembolsoPropostaValor_Enabled = 0;
         AssignProp("", false, edtReembolsoPropostaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPropostaValor_Enabled), 5, 0), true);
         edtReembolsoDataAberturaConvenio_Enabled = 0;
         AssignProp("", false, edtReembolsoDataAberturaConvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoDataAberturaConvenio_Enabled), 5, 0), true);
         edtReembolsoCreatedBy_Enabled = 0;
         AssignProp("", false, edtReembolsoCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoCreatedBy_Enabled), 5, 0), true);
         edtReembolsoEtapaUltimo_F_Enabled = 0;
         AssignProp("", false, edtReembolsoEtapaUltimo_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoEtapaUltimo_F_Enabled), 5, 0), true);
         cmbReembolsoStatusAtual_F.Enabled = 0;
         AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbReembolsoStatusAtual_F.Enabled), 5, 0), true);
         edtavComboreembolsopropostaid_Enabled = 0;
         AssignProp("", false, edtavComboreembolsopropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsopropostaid_Enabled), 5, 0), true);
         edtavComboreembolsocreatedby_Enabled = 0;
         AssignProp("", false, edtavComboreembolsocreatedby_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsocreatedby_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Y71( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Y0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolso"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ReembolsoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("reembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Reembolso");
         forbiddenHiddens.Add("ReembolsoId", context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ReembolsoPropostaId", context.localUtil.Format( (decimal)(AV11Insert_ReembolsoPropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ReembolsoCreatedBy", context.localUtil.Format( (decimal)(AV12Insert_ReembolsoCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_WorkflowConvenioId", context.localUtil.Format( (decimal)(AV24Insert_WorkflowConvenioId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("reembolso:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z518ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z522ReembolsoCreatedAt", context.localUtil.TToC( Z522ReembolsoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z546ReembolsoProtocolo", Z546ReembolsoProtocolo);
         GxWebStd.gx_hidden_field( context, "Z525ReembolsoDataAberturaConvenio", context.localUtil.DToC( Z525ReembolsoDataAberturaConvenio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z742WorkflowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z742WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z542ReembolsoPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z542ReembolsoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z544ReembolsoCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z544ReembolsoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O742WorkflowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(O742WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N542ReembolsoPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N544ReembolsoCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N742WorkflowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREEMBOLSOPROPOSTAID_DATA", AV14ReembolsoPropostaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREEMBOLSOPROPOSTAID_DATA", AV14ReembolsoPropostaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREEMBOLSOCREATEDBY_DATA", AV21ReembolsoCreatedBy_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREEMBOLSOCREATEDBY_DATA", AV21ReembolsoCreatedBy_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV8WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV8WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_REEMBOLSOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ReembolsoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_REEMBOLSOCREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ReembolsoCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_WORKFLOWCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WORKFLOWCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "REEMBOLSOVALORREEMBOLSADO_F", StringUtil.LTrim( StringUtil.NToC( A645ReembolsoValorReembolsado_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WORKFLOWCONVENIODESC", A736WorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, "REEMBOLSOPROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A758ReembolsoPropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Objectcall", StringUtil.RTrim( Combo_reembolsopropostaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Cls", StringUtil.RTrim( Combo_reembolsopropostaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Selectedvalue_set", StringUtil.RTrim( Combo_reembolsopropostaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Selectedtext_set", StringUtil.RTrim( Combo_reembolsopropostaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Enabled", StringUtil.BoolToStr( Combo_reembolsopropostaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Datalistproc", StringUtil.RTrim( Combo_reembolsopropostaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOPROPOSTAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_reembolsopropostaid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Objectcall", StringUtil.RTrim( Combo_reembolsocreatedby_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Cls", StringUtil.RTrim( Combo_reembolsocreatedby_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Selectedvalue_set", StringUtil.RTrim( Combo_reembolsocreatedby_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Selectedtext_set", StringUtil.RTrim( Combo_reembolsocreatedby_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Enabled", StringUtil.BoolToStr( Combo_reembolsocreatedby_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Datalistproc", StringUtil.RTrim( Combo_reembolsocreatedby_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOCREATEDBY_Datalistprocparametersprefix", StringUtil.RTrim( Combo_reembolsocreatedby_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolso"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ReembolsoId,9,0));
         return formatLink("reembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Reembolso" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso" ;
      }

      protected void InitializeNonKey1Y71( )
      {
         A542ReembolsoPropostaId = 0;
         n542ReembolsoPropostaId = false;
         AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
         n542ReembolsoPropostaId = ((0==A542ReembolsoPropostaId) ? true : false);
         A544ReembolsoCreatedBy = 0;
         n544ReembolsoCreatedBy = false;
         AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
         n544ReembolsoCreatedBy = ((0==A544ReembolsoCreatedBy) ? true : false);
         A742WorkflowConvenioId = 0;
         n742WorkflowConvenioId = false;
         AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
         A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         A548ReembolsoStatusAtual_F = "";
         n548ReembolsoStatusAtual_F = false;
         AssignAttri("", false, "A548ReembolsoStatusAtual_F", A548ReembolsoStatusAtual_F);
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
         AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
         A558ReembolsoPropostaPacienteClienteId = 0;
         n558ReembolsoPropostaPacienteClienteId = false;
         AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0));
         A758ReembolsoPropostaClinicaId = 0;
         n758ReembolsoPropostaClinicaId = false;
         AssignAttri("", false, "A758ReembolsoPropostaClinicaId", StringUtil.LTrimStr( (decimal)(A758ReembolsoPropostaClinicaId), 9, 0));
         A546ReembolsoProtocolo = "";
         n546ReembolsoProtocolo = false;
         AssignAttri("", false, "A546ReembolsoProtocolo", A546ReembolsoProtocolo);
         n546ReembolsoProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A546ReembolsoProtocolo)) ? true : false);
         A645ReembolsoValorReembolsado_F = 0;
         n645ReembolsoValorReembolsado_F = false;
         AssignAttri("", false, "A645ReembolsoValorReembolsado_F", StringUtil.LTrimStr( A645ReembolsoValorReembolsado_F, 18, 2));
         A543ReembolsoPropostaValor = 0;
         n543ReembolsoPropostaValor = false;
         AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrimStr( A543ReembolsoPropostaValor, 18, 2));
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         n525ReembolsoDataAberturaConvenio = false;
         AssignAttri("", false, "A525ReembolsoDataAberturaConvenio", context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"));
         n525ReembolsoDataAberturaConvenio = ((DateTime.MinValue==A525ReembolsoDataAberturaConvenio) ? true : false);
         A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         n547ReembolsoEtapaUltimo_F = false;
         AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 8, 5, 0, 3, "/", ":", " "));
         A736WorkflowConvenioDesc = "";
         n736WorkflowConvenioDesc = false;
         AssignAttri("", false, "A736WorkflowConvenioDesc", A736WorkflowConvenioDesc);
         O742WorkflowConvenioId = A742WorkflowConvenioId;
         n742WorkflowConvenioId = false;
         AssignAttri("", false, "A742WorkflowConvenioId", ((0==A742WorkflowConvenioId)&&IsIns( )||n742WorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
         Z522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         Z546ReembolsoProtocolo = "";
         Z525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         Z742WorkflowConvenioId = 0;
         Z542ReembolsoPropostaId = 0;
         Z544ReembolsoCreatedBy = 0;
      }

      protected void InitAll1Y71( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         AssignAttri("", false, "A518ReembolsoId", StringUtil.LTrimStr( (decimal)(A518ReembolsoId), 9, 0));
         InitializeNonKey1Y71( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A522ReembolsoCreatedAt = i522ReembolsoCreatedAt;
         n522ReembolsoCreatedAt = false;
         AssignAttri("", false, "A522ReembolsoCreatedAt", context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019182913", true, true);
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
         context.AddJavascriptSource("reembolso.js", "?202561019182913", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtReembolsoId_Internalname = "REEMBOLSOID";
         lblTextblockreembolsopropostaid_Internalname = "TEXTBLOCKREEMBOLSOPROPOSTAID";
         Combo_reembolsopropostaid_Internalname = "COMBO_REEMBOLSOPROPOSTAID";
         edtReembolsoPropostaId_Internalname = "REEMBOLSOPROPOSTAID";
         divTablesplittedreembolsopropostaid_Internalname = "TABLESPLITTEDREEMBOLSOPROPOSTAID";
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtReembolsoPropostaPacienteClienteId_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTEID";
         edtReembolsoProtocolo_Internalname = "REEMBOLSOPROTOCOLO";
         edtReembolsoCreatedAt_Internalname = "REEMBOLSOCREATEDAT";
         edtReembolsoPropostaValor_Internalname = "REEMBOLSOPROPOSTAVALOR";
         edtReembolsoDataAberturaConvenio_Internalname = "REEMBOLSODATAABERTURACONVENIO";
         lblTextblockreembolsocreatedby_Internalname = "TEXTBLOCKREEMBOLSOCREATEDBY";
         Combo_reembolsocreatedby_Internalname = "COMBO_REEMBOLSOCREATEDBY";
         edtReembolsoCreatedBy_Internalname = "REEMBOLSOCREATEDBY";
         divTablesplittedreembolsocreatedby_Internalname = "TABLESPLITTEDREEMBOLSOCREATEDBY";
         edtReembolsoEtapaUltimo_F_Internalname = "REEMBOLSOETAPAULTIMO_F";
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboreembolsopropostaid_Internalname = "vCOMBOREEMBOLSOPROPOSTAID";
         divSectionattribute_reembolsopropostaid_Internalname = "SECTIONATTRIBUTE_REEMBOLSOPROPOSTAID";
         edtavComboreembolsocreatedby_Internalname = "vCOMBOREEMBOLSOCREATEDBY";
         divSectionattribute_reembolsocreatedby_Internalname = "SECTIONATTRIBUTE_REEMBOLSOCREATEDBY";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = "Reembolso";
         edtavComboreembolsocreatedby_Jsonclick = "";
         edtavComboreembolsocreatedby_Enabled = 0;
         edtavComboreembolsocreatedby_Visible = 1;
         edtavComboreembolsopropostaid_Jsonclick = "";
         edtavComboreembolsopropostaid_Enabled = 0;
         edtavComboreembolsopropostaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbReembolsoStatusAtual_F_Jsonclick = "";
         cmbReembolsoStatusAtual_F.Enabled = 0;
         edtReembolsoEtapaUltimo_F_Jsonclick = "";
         edtReembolsoEtapaUltimo_F_Enabled = 0;
         edtReembolsoCreatedBy_Jsonclick = "";
         edtReembolsoCreatedBy_Enabled = 1;
         edtReembolsoCreatedBy_Visible = 1;
         Combo_reembolsocreatedby_Datalistprocparametersprefix = " \"ComboName\": \"ReembolsoCreatedBy\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoId\": 0";
         Combo_reembolsocreatedby_Datalistproc = "ReembolsoLoadDVCombo";
         Combo_reembolsocreatedby_Cls = "ExtendedCombo AttributeFL";
         Combo_reembolsocreatedby_Caption = "";
         Combo_reembolsocreatedby_Enabled = Convert.ToBoolean( -1);
         edtReembolsoDataAberturaConvenio_Jsonclick = "";
         edtReembolsoDataAberturaConvenio_Enabled = 1;
         edtReembolsoPropostaValor_Jsonclick = "";
         edtReembolsoPropostaValor_Enabled = 0;
         edtReembolsoCreatedAt_Jsonclick = "";
         edtReembolsoCreatedAt_Enabled = 1;
         edtReembolsoProtocolo_Jsonclick = "";
         edtReembolsoProtocolo_Enabled = 1;
         edtReembolsoPropostaPacienteClienteId_Jsonclick = "";
         edtReembolsoPropostaPacienteClienteId_Enabled = 0;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtReembolsoPropostaId_Jsonclick = "";
         edtReembolsoPropostaId_Enabled = 1;
         edtReembolsoPropostaId_Visible = 1;
         Combo_reembolsopropostaid_Datalistprocparametersprefix = " \"ComboName\": \"ReembolsoPropostaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoId\": 0";
         Combo_reembolsopropostaid_Datalistproc = "ReembolsoLoadDVCombo";
         Combo_reembolsopropostaid_Cls = "ExtendedCombo AttributeFL";
         Combo_reembolsopropostaid_Caption = "";
         Combo_reembolsopropostaid_Enabled = Convert.ToBoolean( -1);
         edtReembolsoId_Jsonclick = "";
         edtReembolsoId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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

      protected void XC_16_1Y71( int A518ReembolsoId ,
                                 int A742WorkflowConvenioId )
      {
         if ( A742WorkflowConvenioId != O742WorkflowConvenioId )
         {
            new prlogreembolso(context ).execute(  A518ReembolsoId,  A742WorkflowConvenioId,  AV8WWPContext.gxTpr_Userid) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_17_1Y71( int A518ReembolsoId ,
                                 int A742WorkflowConvenioId )
      {
         if ( A742WorkflowConvenioId != O742WorkflowConvenioId )
         {
            new prlogreembolso(context ).execute(  A518ReembolsoId,  A742WorkflowConvenioId,  AV8WWPContext.gxTpr_Userid) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbReembolsoStatusAtual_F.Name = "REEMBOLSOSTATUSATUAL_F";
         cmbReembolsoStatusAtual_F.WebTags = "";
         cmbReembolsoStatusAtual_F.addItem("", "", 0);
         cmbReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em análise", 0);
         cmbReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
         cmbReembolsoStatusAtual_F.addItem("REANALISE", "Reanálise", 0);
         cmbReembolsoStatusAtual_F.addItem("", "Não iniciado", 0);
         if ( cmbReembolsoStatusAtual_F.ItemCount > 0 )
         {
            A548ReembolsoStatusAtual_F = cmbReembolsoStatusAtual_F.getValidValue(A548ReembolsoStatusAtual_F);
            n548ReembolsoStatusAtual_F = false;
            AssignAttri("", false, "A548ReembolsoStatusAtual_F", A548ReembolsoStatusAtual_F);
         }
         /* End function init_web_controls */
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

      public void Valid_Reembolsoid( )
      {
         n518ReembolsoId = false;
         n645ReembolsoValorReembolsado_F = false;
         n547ReembolsoEtapaUltimo_F = false;
         /* Using cursor T001Y34 */
         pr_default.execute(23, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A645ReembolsoValorReembolsado_F = T001Y34_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = T001Y34_n645ReembolsoValorReembolsado_F[0];
         }
         else
         {
            A645ReembolsoValorReembolsado_F = 0;
            n645ReembolsoValorReembolsado_F = false;
         }
         pr_default.close(23);
         if ( ( A645ReembolsoValorReembolsado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "REEMBOLSOID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoId_Internalname;
         }
         /* Using cursor T001Y36 */
         pr_default.execute(24, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A547ReembolsoEtapaUltimo_F = T001Y36_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = T001Y36_n547ReembolsoEtapaUltimo_F[0];
         }
         else
         {
            A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
            n547ReembolsoEtapaUltimo_F = false;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A645ReembolsoValorReembolsado_F", StringUtil.LTrim( StringUtil.NToC( A645ReembolsoValorReembolsado_F, 18, 2, ".", "")));
         AssignAttri("", false, "A547ReembolsoEtapaUltimo_F", context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 10, 8, 0, 3, "/", ":", " "));
      }

      public void Valid_Reembolsopropostaid( )
      {
         n543ReembolsoPropostaValor = false;
         n558ReembolsoPropostaPacienteClienteId = false;
         n758ReembolsoPropostaClinicaId = false;
         n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ReembolsoPropostaId) )
         {
            A542ReembolsoPropostaId = AV11Insert_ReembolsoPropostaId;
            n542ReembolsoPropostaId = false;
         }
         else
         {
            if ( (0==AV19ComboReembolsoPropostaId) )
            {
               A542ReembolsoPropostaId = 0;
               n542ReembolsoPropostaId = false;
               n542ReembolsoPropostaId = true;
               n542ReembolsoPropostaId = true;
            }
            else
            {
               if ( ! (0==AV19ComboReembolsoPropostaId) )
               {
                  A542ReembolsoPropostaId = AV19ComboReembolsoPropostaId;
                  n542ReembolsoPropostaId = false;
               }
               else
               {
                  if ( (0==A542ReembolsoPropostaId) )
                  {
                     A542ReembolsoPropostaId = 0;
                     n542ReembolsoPropostaId = false;
                     n542ReembolsoPropostaId = true;
                     n542ReembolsoPropostaId = true;
                  }
               }
            }
         }
         /* Using cursor T001Y37 */
         pr_default.execute(25, new Object[] {n542ReembolsoPropostaId, A542ReembolsoPropostaId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A542ReembolsoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Proposta'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoPropostaId_Internalname;
            }
         }
         A543ReembolsoPropostaValor = T001Y37_A543ReembolsoPropostaValor[0];
         n543ReembolsoPropostaValor = T001Y37_n543ReembolsoPropostaValor[0];
         A558ReembolsoPropostaPacienteClienteId = T001Y37_A558ReembolsoPropostaPacienteClienteId[0];
         n558ReembolsoPropostaPacienteClienteId = T001Y37_n558ReembolsoPropostaPacienteClienteId[0];
         A758ReembolsoPropostaClinicaId = T001Y37_A758ReembolsoPropostaClinicaId[0];
         n758ReembolsoPropostaClinicaId = T001Y37_n758ReembolsoPropostaClinicaId[0];
         pr_default.close(25);
         if ( ( A543ReembolsoPropostaValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "REEMBOLSOPROPOSTAID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoPropostaId_Internalname;
         }
         /* Using cursor T001Y38 */
         pr_default.execute(26, new Object[] {n558ReembolsoPropostaPacienteClienteId, A558ReembolsoPropostaPacienteClienteId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A558ReembolsoPropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y38_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         n550ReembolsoPropostaPacienteClienteRazaoSocial = T001Y38_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A542ReembolsoPropostaId", ((0==A542ReembolsoPropostaId)&&IsIns( )||n542ReembolsoPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
         AssignAttri("", false, "A543ReembolsoPropostaValor", StringUtil.LTrim( StringUtil.NToC( A543ReembolsoPropostaValor, 18, 2, ".", "")));
         AssignAttri("", false, "A558ReembolsoPropostaPacienteClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0, ".", "")));
         AssignAttri("", false, "A758ReembolsoPropostaClinicaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A758ReembolsoPropostaClinicaId), 9, 0, ".", "")));
         AssignAttri("", false, "A550ReembolsoPropostaPacienteClienteRazaoSocial", A550ReembolsoPropostaPacienteClienteRazaoSocial);
      }

      public void Valid_Reembolsocreatedby( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoCreatedBy) )
         {
            A544ReembolsoCreatedBy = AV12Insert_ReembolsoCreatedBy;
            n544ReembolsoCreatedBy = false;
         }
         else
         {
            if ( (0==AV22ComboReembolsoCreatedBy) )
            {
               A544ReembolsoCreatedBy = 0;
               n544ReembolsoCreatedBy = false;
               n544ReembolsoCreatedBy = true;
               n544ReembolsoCreatedBy = true;
            }
            else
            {
               if ( ! (0==AV22ComboReembolsoCreatedBy) )
               {
                  A544ReembolsoCreatedBy = AV22ComboReembolsoCreatedBy;
                  n544ReembolsoCreatedBy = false;
               }
               else
               {
                  if ( IsIns( )  )
                  {
                     A544ReembolsoCreatedBy = AV8WWPContext.gxTpr_Userid;
                     n544ReembolsoCreatedBy = false;
                  }
                  else
                  {
                     if ( (0==A544ReembolsoCreatedBy) )
                     {
                        A544ReembolsoCreatedBy = 0;
                        n544ReembolsoCreatedBy = false;
                        n544ReembolsoCreatedBy = true;
                        n544ReembolsoCreatedBy = true;
                     }
                  }
               }
            }
         }
         /* Using cursor T001Y45 */
         pr_default.execute(33, new Object[] {n544ReembolsoCreatedBy, A544ReembolsoCreatedBy});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( (0==A544ReembolsoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Usuario'.", "ForeignKeyNotFound", 1, "REEMBOLSOCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtReembolsoCreatedBy_Internalname;
            }
         }
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A544ReembolsoCreatedBy", ((0==A544ReembolsoCreatedBy)&&IsIns( )||n544ReembolsoCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ReembolsoPropostaId","fld":"vINSERT_REEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_ReembolsoCreatedBy","fld":"vINSERT_REEMBOLSOCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV24Insert_WorkflowConvenioId","fld":"vINSERT_WORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121Y2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_REEMBOLSOID","""{"handler":"Valid_Reembolsoid","iparms":[{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A645ReembolsoValorReembolsado_F","fld":"REEMBOLSOVALORREEMBOLSADO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A547ReembolsoEtapaUltimo_F","fld":"REEMBOLSOETAPAULTIMO_F","pic":"99/99/99 99:99","type":"dtime"}]""");
         setEventMetadata("VALID_REEMBOLSOID",""","oparms":[{"av":"A645ReembolsoValorReembolsado_F","fld":"REEMBOLSOVALORREEMBOLSADO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A547ReembolsoEtapaUltimo_F","fld":"REEMBOLSOETAPAULTIMO_F","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAID","""{"handler":"Valid_Reembolsopropostaid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11Insert_ReembolsoPropostaId","fld":"vINSERT_REEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19ComboReembolsoPropostaId","fld":"vCOMBOREEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A542ReembolsoPropostaId","fld":"REEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n542ReembolsoPropostaId","type":"int"},{"av":"A543ReembolsoPropostaValor","fld":"REEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A558ReembolsoPropostaPacienteClienteId","fld":"REEMBOLSOPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A758ReembolsoPropostaClinicaId","fld":"REEMBOLSOPROPOSTACLINICAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A550ReembolsoPropostaPacienteClienteRazaoSocial","fld":"REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAID",""","oparms":[{"av":"A542ReembolsoPropostaId","fld":"REEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n542ReembolsoPropostaId","type":"int"},{"av":"A543ReembolsoPropostaValor","fld":"REEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A558ReembolsoPropostaPacienteClienteId","fld":"REEMBOLSOPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A758ReembolsoPropostaClinicaId","fld":"REEMBOLSOPROPOSTACLINICAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A550ReembolsoPropostaPacienteClienteRazaoSocial","fld":"REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAPACIENTECLIENTEID","""{"handler":"Valid_Reembolsopropostapacienteclienteid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAVALOR","""{"handler":"Valid_Reembolsopropostavalor","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOCREATEDBY","""{"handler":"Valid_Reembolsocreatedby","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_ReembolsoCreatedBy","fld":"vINSERT_REEMBOLSOCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV22ComboReembolsoCreatedBy","fld":"vCOMBOREEMBOLSOCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV8WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"A544ReembolsoCreatedBy","fld":"REEMBOLSOCREATEDBY","pic":"ZZZ9","nullAv":"n544ReembolsoCreatedBy","type":"int"}]""");
         setEventMetadata("VALID_REEMBOLSOCREATEDBY",""","oparms":[{"av":"A544ReembolsoCreatedBy","fld":"REEMBOLSOCREATEDBY","pic":"ZZZ9","nullAv":"n544ReembolsoCreatedBy","type":"int"}]}""");
         setEventMetadata("VALIDV_COMBOREEMBOLSOPROPOSTAID","""{"handler":"Validv_Comboreembolsopropostaid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOREEMBOLSOCREATEDBY","""{"handler":"Validv_Comboreembolsocreatedby","iparms":[]}""");
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
         pr_default.close(27);
         pr_default.close(25);
         pr_default.close(33);
         pr_default.close(26);
         pr_default.close(2);
         pr_default.close(23);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         Z546ReembolsoProtocolo = "";
         Z525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         Combo_reembolsocreatedby_Selectedvalue_get = "";
         Combo_reembolsopropostaid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A548ReembolsoStatusAtual_F = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockreembolsopropostaid_Jsonclick = "";
         ucCombo_reembolsopropostaid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14ReembolsoPropostaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A546ReembolsoProtocolo = "";
         A522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         lblTextblockreembolsocreatedby_Jsonclick = "";
         ucCombo_reembolsocreatedby = new GXUserControl();
         AV21ReembolsoCreatedBy_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A736WorkflowConvenioDesc = "";
         AV26Pgmname = "";
         Combo_reembolsopropostaid_Objectcall = "";
         Combo_reembolsopropostaid_Class = "";
         Combo_reembolsopropostaid_Icontype = "";
         Combo_reembolsopropostaid_Icon = "";
         Combo_reembolsopropostaid_Tooltip = "";
         Combo_reembolsopropostaid_Selectedvalue_set = "";
         Combo_reembolsopropostaid_Selectedtext_set = "";
         Combo_reembolsopropostaid_Selectedtext_get = "";
         Combo_reembolsopropostaid_Gamoauthtoken = "";
         Combo_reembolsopropostaid_Ddointernalname = "";
         Combo_reembolsopropostaid_Titlecontrolalign = "";
         Combo_reembolsopropostaid_Dropdownoptionstype = "";
         Combo_reembolsopropostaid_Titlecontrolidtoreplace = "";
         Combo_reembolsopropostaid_Datalisttype = "";
         Combo_reembolsopropostaid_Datalistfixedvalues = "";
         Combo_reembolsopropostaid_Remoteservicesparameters = "";
         Combo_reembolsopropostaid_Htmltemplate = "";
         Combo_reembolsopropostaid_Multiplevaluestype = "";
         Combo_reembolsopropostaid_Loadingdata = "";
         Combo_reembolsopropostaid_Noresultsfound = "";
         Combo_reembolsopropostaid_Emptyitemtext = "";
         Combo_reembolsopropostaid_Onlyselectedvalues = "";
         Combo_reembolsopropostaid_Selectalltext = "";
         Combo_reembolsopropostaid_Multiplevaluesseparator = "";
         Combo_reembolsopropostaid_Addnewoptiontext = "";
         Combo_reembolsocreatedby_Objectcall = "";
         Combo_reembolsocreatedby_Class = "";
         Combo_reembolsocreatedby_Icontype = "";
         Combo_reembolsocreatedby_Icon = "";
         Combo_reembolsocreatedby_Tooltip = "";
         Combo_reembolsocreatedby_Selectedvalue_set = "";
         Combo_reembolsocreatedby_Selectedtext_set = "";
         Combo_reembolsocreatedby_Selectedtext_get = "";
         Combo_reembolsocreatedby_Gamoauthtoken = "";
         Combo_reembolsocreatedby_Ddointernalname = "";
         Combo_reembolsocreatedby_Titlecontrolalign = "";
         Combo_reembolsocreatedby_Dropdownoptionstype = "";
         Combo_reembolsocreatedby_Titlecontrolidtoreplace = "";
         Combo_reembolsocreatedby_Datalisttype = "";
         Combo_reembolsocreatedby_Datalistfixedvalues = "";
         Combo_reembolsocreatedby_Remoteservicesparameters = "";
         Combo_reembolsocreatedby_Htmltemplate = "";
         Combo_reembolsocreatedby_Multiplevaluestype = "";
         Combo_reembolsocreatedby_Loadingdata = "";
         Combo_reembolsocreatedby_Noresultsfound = "";
         Combo_reembolsocreatedby_Emptyitemtext = "";
         Combo_reembolsocreatedby_Onlyselectedvalues = "";
         Combo_reembolsocreatedby_Selectalltext = "";
         Combo_reembolsocreatedby_Multiplevaluesseparator = "";
         Combo_reembolsocreatedby_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode71 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         Z736WorkflowConvenioDesc = "";
         Z547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         Z550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         T001Y12_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         T001Y12_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         T001Y14_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         T001Y14_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         T001Y7_A736WorkflowConvenioDesc = new string[] {""} ;
         T001Y7_n736WorkflowConvenioDesc = new bool[] {false} ;
         T001Y17_A518ReembolsoId = new int[1] ;
         T001Y17_n518ReembolsoId = new bool[] {false} ;
         T001Y17_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001Y17_n522ReembolsoCreatedAt = new bool[] {false} ;
         T001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001Y17_A546ReembolsoProtocolo = new string[] {""} ;
         T001Y17_n546ReembolsoProtocolo = new bool[] {false} ;
         T001Y17_A543ReembolsoPropostaValor = new decimal[1] ;
         T001Y17_n543ReembolsoPropostaValor = new bool[] {false} ;
         T001Y17_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         T001Y17_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         T001Y17_A736WorkflowConvenioDesc = new string[] {""} ;
         T001Y17_n736WorkflowConvenioDesc = new bool[] {false} ;
         T001Y17_A742WorkflowConvenioId = new int[1] ;
         T001Y17_n742WorkflowConvenioId = new bool[] {false} ;
         T001Y17_A542ReembolsoPropostaId = new int[1] ;
         T001Y17_n542ReembolsoPropostaId = new bool[] {false} ;
         T001Y17_A544ReembolsoCreatedBy = new short[1] ;
         T001Y17_n544ReembolsoCreatedBy = new bool[] {false} ;
         T001Y17_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         T001Y17_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         T001Y17_A758ReembolsoPropostaClinicaId = new int[1] ;
         T001Y17_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         T001Y17_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         T001Y17_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         T001Y17_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         T001Y17_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         T001Y8_A543ReembolsoPropostaValor = new decimal[1] ;
         T001Y8_n543ReembolsoPropostaValor = new bool[] {false} ;
         T001Y8_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         T001Y8_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         T001Y8_A758ReembolsoPropostaClinicaId = new int[1] ;
         T001Y8_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         T001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001Y9_A544ReembolsoCreatedBy = new short[1] ;
         T001Y9_n544ReembolsoCreatedBy = new bool[] {false} ;
         T001Y19_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         T001Y19_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         T001Y21_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         T001Y21_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         T001Y22_A543ReembolsoPropostaValor = new decimal[1] ;
         T001Y22_n543ReembolsoPropostaValor = new bool[] {false} ;
         T001Y22_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         T001Y22_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         T001Y22_A758ReembolsoPropostaClinicaId = new int[1] ;
         T001Y22_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         T001Y23_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001Y23_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001Y24_A544ReembolsoCreatedBy = new short[1] ;
         T001Y24_n544ReembolsoCreatedBy = new bool[] {false} ;
         T001Y25_A736WorkflowConvenioDesc = new string[] {""} ;
         T001Y25_n736WorkflowConvenioDesc = new bool[] {false} ;
         T001Y26_A518ReembolsoId = new int[1] ;
         T001Y26_n518ReembolsoId = new bool[] {false} ;
         T001Y3_A518ReembolsoId = new int[1] ;
         T001Y3_n518ReembolsoId = new bool[] {false} ;
         T001Y3_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001Y3_n522ReembolsoCreatedAt = new bool[] {false} ;
         T001Y3_A546ReembolsoProtocolo = new string[] {""} ;
         T001Y3_n546ReembolsoProtocolo = new bool[] {false} ;
         T001Y3_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         T001Y3_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         T001Y3_A742WorkflowConvenioId = new int[1] ;
         T001Y3_n742WorkflowConvenioId = new bool[] {false} ;
         T001Y3_A542ReembolsoPropostaId = new int[1] ;
         T001Y3_n542ReembolsoPropostaId = new bool[] {false} ;
         T001Y3_A544ReembolsoCreatedBy = new short[1] ;
         T001Y3_n544ReembolsoCreatedBy = new bool[] {false} ;
         T001Y27_A518ReembolsoId = new int[1] ;
         T001Y27_n518ReembolsoId = new bool[] {false} ;
         T001Y28_A518ReembolsoId = new int[1] ;
         T001Y28_n518ReembolsoId = new bool[] {false} ;
         T001Y2_A518ReembolsoId = new int[1] ;
         T001Y2_n518ReembolsoId = new bool[] {false} ;
         T001Y2_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001Y2_n522ReembolsoCreatedAt = new bool[] {false} ;
         T001Y2_A546ReembolsoProtocolo = new string[] {""} ;
         T001Y2_n546ReembolsoProtocolo = new bool[] {false} ;
         T001Y2_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         T001Y2_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         T001Y2_A742WorkflowConvenioId = new int[1] ;
         T001Y2_n742WorkflowConvenioId = new bool[] {false} ;
         T001Y2_A542ReembolsoPropostaId = new int[1] ;
         T001Y2_n542ReembolsoPropostaId = new bool[] {false} ;
         T001Y2_A544ReembolsoCreatedBy = new short[1] ;
         T001Y2_n544ReembolsoCreatedBy = new bool[] {false} ;
         T001Y30_A518ReembolsoId = new int[1] ;
         T001Y30_n518ReembolsoId = new bool[] {false} ;
         T001Y34_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         T001Y34_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         T001Y36_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         T001Y36_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         T001Y37_A543ReembolsoPropostaValor = new decimal[1] ;
         T001Y37_n543ReembolsoPropostaValor = new bool[] {false} ;
         T001Y37_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         T001Y37_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         T001Y37_A758ReembolsoPropostaClinicaId = new int[1] ;
         T001Y37_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         T001Y38_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001Y38_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001Y39_A736WorkflowConvenioDesc = new string[] {""} ;
         T001Y39_n736WorkflowConvenioDesc = new bool[] {false} ;
         T001Y40_A746ReembolsoFlowLogId = new int[1] ;
         T001Y41_A634ReembolsoParcelasId = new int[1] ;
         T001Y42_A631ReembolsoAssinaturasId = new int[1] ;
         T001Y43_A526ReembolsoEtapaId = new int[1] ;
         T001Y44_A518ReembolsoId = new int[1] ;
         T001Y44_n518ReembolsoId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         T001Y45_A544ReembolsoCreatedBy = new short[1] ;
         T001Y45_n544ReembolsoCreatedBy = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolso__default(),
            new Object[][] {
                new Object[] {
               T001Y2_A518ReembolsoId, T001Y2_A522ReembolsoCreatedAt, T001Y2_n522ReembolsoCreatedAt, T001Y2_A546ReembolsoProtocolo, T001Y2_n546ReembolsoProtocolo, T001Y2_A525ReembolsoDataAberturaConvenio, T001Y2_n525ReembolsoDataAberturaConvenio, T001Y2_A742WorkflowConvenioId, T001Y2_n742WorkflowConvenioId, T001Y2_A542ReembolsoPropostaId,
               T001Y2_n542ReembolsoPropostaId, T001Y2_A544ReembolsoCreatedBy, T001Y2_n544ReembolsoCreatedBy
               }
               , new Object[] {
               T001Y3_A518ReembolsoId, T001Y3_A522ReembolsoCreatedAt, T001Y3_n522ReembolsoCreatedAt, T001Y3_A546ReembolsoProtocolo, T001Y3_n546ReembolsoProtocolo, T001Y3_A525ReembolsoDataAberturaConvenio, T001Y3_n525ReembolsoDataAberturaConvenio, T001Y3_A742WorkflowConvenioId, T001Y3_n742WorkflowConvenioId, T001Y3_A542ReembolsoPropostaId,
               T001Y3_n542ReembolsoPropostaId, T001Y3_A544ReembolsoCreatedBy, T001Y3_n544ReembolsoCreatedBy
               }
               , new Object[] {
               T001Y6_A548ReembolsoStatusAtual_F, T001Y6_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               T001Y7_A736WorkflowConvenioDesc, T001Y7_n736WorkflowConvenioDesc
               }
               , new Object[] {
               T001Y8_A543ReembolsoPropostaValor, T001Y8_n543ReembolsoPropostaValor, T001Y8_A558ReembolsoPropostaPacienteClienteId, T001Y8_n558ReembolsoPropostaPacienteClienteId, T001Y8_A758ReembolsoPropostaClinicaId, T001Y8_n758ReembolsoPropostaClinicaId
               }
               , new Object[] {
               T001Y9_A544ReembolsoCreatedBy
               }
               , new Object[] {
               T001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial, T001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               T001Y12_A645ReembolsoValorReembolsado_F, T001Y12_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               T001Y14_A547ReembolsoEtapaUltimo_F, T001Y14_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               T001Y17_A518ReembolsoId, T001Y17_A522ReembolsoCreatedAt, T001Y17_n522ReembolsoCreatedAt, T001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial, T001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial, T001Y17_A546ReembolsoProtocolo, T001Y17_n546ReembolsoProtocolo, T001Y17_A543ReembolsoPropostaValor, T001Y17_n543ReembolsoPropostaValor, T001Y17_A525ReembolsoDataAberturaConvenio,
               T001Y17_n525ReembolsoDataAberturaConvenio, T001Y17_A736WorkflowConvenioDesc, T001Y17_n736WorkflowConvenioDesc, T001Y17_A742WorkflowConvenioId, T001Y17_n742WorkflowConvenioId, T001Y17_A542ReembolsoPropostaId, T001Y17_n542ReembolsoPropostaId, T001Y17_A544ReembolsoCreatedBy, T001Y17_n544ReembolsoCreatedBy, T001Y17_A558ReembolsoPropostaPacienteClienteId,
               T001Y17_n558ReembolsoPropostaPacienteClienteId, T001Y17_A758ReembolsoPropostaClinicaId, T001Y17_n758ReembolsoPropostaClinicaId, T001Y17_A645ReembolsoValorReembolsado_F, T001Y17_n645ReembolsoValorReembolsado_F, T001Y17_A547ReembolsoEtapaUltimo_F, T001Y17_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               T001Y19_A645ReembolsoValorReembolsado_F, T001Y19_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               T001Y21_A547ReembolsoEtapaUltimo_F, T001Y21_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               T001Y22_A543ReembolsoPropostaValor, T001Y22_n543ReembolsoPropostaValor, T001Y22_A558ReembolsoPropostaPacienteClienteId, T001Y22_n558ReembolsoPropostaPacienteClienteId, T001Y22_A758ReembolsoPropostaClinicaId, T001Y22_n758ReembolsoPropostaClinicaId
               }
               , new Object[] {
               T001Y23_A550ReembolsoPropostaPacienteClienteRazaoSocial, T001Y23_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               T001Y24_A544ReembolsoCreatedBy
               }
               , new Object[] {
               T001Y25_A736WorkflowConvenioDesc, T001Y25_n736WorkflowConvenioDesc
               }
               , new Object[] {
               T001Y26_A518ReembolsoId
               }
               , new Object[] {
               T001Y27_A518ReembolsoId
               }
               , new Object[] {
               T001Y28_A518ReembolsoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001Y30_A518ReembolsoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Y34_A645ReembolsoValorReembolsado_F, T001Y34_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               T001Y36_A547ReembolsoEtapaUltimo_F, T001Y36_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               T001Y37_A543ReembolsoPropostaValor, T001Y37_n543ReembolsoPropostaValor, T001Y37_A558ReembolsoPropostaPacienteClienteId, T001Y37_n558ReembolsoPropostaPacienteClienteId, T001Y37_A758ReembolsoPropostaClinicaId, T001Y37_n758ReembolsoPropostaClinicaId
               }
               , new Object[] {
               T001Y38_A550ReembolsoPropostaPacienteClienteRazaoSocial, T001Y38_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               T001Y39_A736WorkflowConvenioDesc, T001Y39_n736WorkflowConvenioDesc
               }
               , new Object[] {
               T001Y40_A746ReembolsoFlowLogId
               }
               , new Object[] {
               T001Y41_A634ReembolsoParcelasId
               }
               , new Object[] {
               T001Y42_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               T001Y43_A526ReembolsoEtapaId
               }
               , new Object[] {
               T001Y44_A518ReembolsoId
               }
               , new Object[] {
               T001Y45_A544ReembolsoCreatedBy
               }
            }
         );
         AV26Pgmname = "Reembolso";
         Z522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         i522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
      }

      private short Z544ReembolsoCreatedBy ;
      private short N544ReembolsoCreatedBy ;
      private short GxWebError ;
      private short A544ReembolsoCreatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV22ComboReembolsoCreatedBy ;
      private short AV12Insert_ReembolsoCreatedBy ;
      private short Gx_BScreen ;
      private short RcdFound71 ;
      private short gxajaxcallmode ;
      private int wcpOAV7ReembolsoId ;
      private int Z518ReembolsoId ;
      private int Z742WorkflowConvenioId ;
      private int Z542ReembolsoPropostaId ;
      private int O742WorkflowConvenioId ;
      private int N542ReembolsoPropostaId ;
      private int N742WorkflowConvenioId ;
      private int A518ReembolsoId ;
      private int A742WorkflowConvenioId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int AV7ReembolsoId ;
      private int trnEnded ;
      private int edtReembolsoId_Enabled ;
      private int edtReembolsoPropostaId_Visible ;
      private int edtReembolsoPropostaId_Enabled ;
      private int edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled ;
      private int edtReembolsoPropostaPacienteClienteId_Enabled ;
      private int edtReembolsoProtocolo_Enabled ;
      private int edtReembolsoCreatedAt_Enabled ;
      private int edtReembolsoPropostaValor_Enabled ;
      private int edtReembolsoDataAberturaConvenio_Enabled ;
      private int edtReembolsoCreatedBy_Visible ;
      private int edtReembolsoCreatedBy_Enabled ;
      private int edtReembolsoEtapaUltimo_F_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboReembolsoPropostaId ;
      private int edtavComboreembolsopropostaid_Enabled ;
      private int edtavComboreembolsopropostaid_Visible ;
      private int edtavComboreembolsocreatedby_Enabled ;
      private int edtavComboreembolsocreatedby_Visible ;
      private int AV11Insert_ReembolsoPropostaId ;
      private int AV24Insert_WorkflowConvenioId ;
      private int A323PropostaId ;
      private int A758ReembolsoPropostaClinicaId ;
      private int Combo_reembolsopropostaid_Datalistupdateminimumcharacters ;
      private int Combo_reembolsopropostaid_Gxcontroltype ;
      private int Combo_reembolsocreatedby_Datalistupdateminimumcharacters ;
      private int Combo_reembolsocreatedby_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV27GXV1 ;
      private int Z558ReembolsoPropostaPacienteClienteId ;
      private int Z758ReembolsoPropostaClinicaId ;
      private int idxLst ;
      private decimal A543ReembolsoPropostaValor ;
      private decimal A645ReembolsoValorReembolsado_F ;
      private decimal Z645ReembolsoValorReembolsado_F ;
      private decimal Z543ReembolsoPropostaValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_reembolsocreatedby_Selectedvalue_get ;
      private string Combo_reembolsopropostaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtReembolsoPropostaId_Internalname ;
      private string cmbReembolsoStatusAtual_F_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtReembolsoId_Internalname ;
      private string TempTags ;
      private string edtReembolsoId_Jsonclick ;
      private string divTablesplittedreembolsopropostaid_Internalname ;
      private string lblTextblockreembolsopropostaid_Internalname ;
      private string lblTextblockreembolsopropostaid_Jsonclick ;
      private string Combo_reembolsopropostaid_Caption ;
      private string Combo_reembolsopropostaid_Cls ;
      private string Combo_reembolsopropostaid_Datalistproc ;
      private string Combo_reembolsopropostaid_Datalistprocparametersprefix ;
      private string Combo_reembolsopropostaid_Internalname ;
      private string edtReembolsoPropostaId_Jsonclick ;
      private string edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname ;
      private string edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string edtReembolsoPropostaPacienteClienteId_Internalname ;
      private string edtReembolsoPropostaPacienteClienteId_Jsonclick ;
      private string edtReembolsoProtocolo_Internalname ;
      private string edtReembolsoProtocolo_Jsonclick ;
      private string edtReembolsoCreatedAt_Internalname ;
      private string edtReembolsoCreatedAt_Jsonclick ;
      private string edtReembolsoPropostaValor_Internalname ;
      private string edtReembolsoPropostaValor_Jsonclick ;
      private string edtReembolsoDataAberturaConvenio_Internalname ;
      private string edtReembolsoDataAberturaConvenio_Jsonclick ;
      private string divTablesplittedreembolsocreatedby_Internalname ;
      private string lblTextblockreembolsocreatedby_Internalname ;
      private string lblTextblockreembolsocreatedby_Jsonclick ;
      private string Combo_reembolsocreatedby_Caption ;
      private string Combo_reembolsocreatedby_Cls ;
      private string Combo_reembolsocreatedby_Datalistproc ;
      private string Combo_reembolsocreatedby_Datalistprocparametersprefix ;
      private string Combo_reembolsocreatedby_Internalname ;
      private string edtReembolsoCreatedBy_Internalname ;
      private string edtReembolsoCreatedBy_Jsonclick ;
      private string edtReembolsoEtapaUltimo_F_Internalname ;
      private string edtReembolsoEtapaUltimo_F_Jsonclick ;
      private string cmbReembolsoStatusAtual_F_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_reembolsopropostaid_Internalname ;
      private string edtavComboreembolsopropostaid_Internalname ;
      private string edtavComboreembolsopropostaid_Jsonclick ;
      private string divSectionattribute_reembolsocreatedby_Internalname ;
      private string edtavComboreembolsocreatedby_Internalname ;
      private string edtavComboreembolsocreatedby_Jsonclick ;
      private string AV26Pgmname ;
      private string Combo_reembolsopropostaid_Objectcall ;
      private string Combo_reembolsopropostaid_Class ;
      private string Combo_reembolsopropostaid_Icontype ;
      private string Combo_reembolsopropostaid_Icon ;
      private string Combo_reembolsopropostaid_Tooltip ;
      private string Combo_reembolsopropostaid_Selectedvalue_set ;
      private string Combo_reembolsopropostaid_Selectedtext_set ;
      private string Combo_reembolsopropostaid_Selectedtext_get ;
      private string Combo_reembolsopropostaid_Gamoauthtoken ;
      private string Combo_reembolsopropostaid_Ddointernalname ;
      private string Combo_reembolsopropostaid_Titlecontrolalign ;
      private string Combo_reembolsopropostaid_Dropdownoptionstype ;
      private string Combo_reembolsopropostaid_Titlecontrolidtoreplace ;
      private string Combo_reembolsopropostaid_Datalisttype ;
      private string Combo_reembolsopropostaid_Datalistfixedvalues ;
      private string Combo_reembolsopropostaid_Remoteservicesparameters ;
      private string Combo_reembolsopropostaid_Htmltemplate ;
      private string Combo_reembolsopropostaid_Multiplevaluestype ;
      private string Combo_reembolsopropostaid_Loadingdata ;
      private string Combo_reembolsopropostaid_Noresultsfound ;
      private string Combo_reembolsopropostaid_Emptyitemtext ;
      private string Combo_reembolsopropostaid_Onlyselectedvalues ;
      private string Combo_reembolsopropostaid_Selectalltext ;
      private string Combo_reembolsopropostaid_Multiplevaluesseparator ;
      private string Combo_reembolsopropostaid_Addnewoptiontext ;
      private string Combo_reembolsocreatedby_Objectcall ;
      private string Combo_reembolsocreatedby_Class ;
      private string Combo_reembolsocreatedby_Icontype ;
      private string Combo_reembolsocreatedby_Icon ;
      private string Combo_reembolsocreatedby_Tooltip ;
      private string Combo_reembolsocreatedby_Selectedvalue_set ;
      private string Combo_reembolsocreatedby_Selectedtext_set ;
      private string Combo_reembolsocreatedby_Selectedtext_get ;
      private string Combo_reembolsocreatedby_Gamoauthtoken ;
      private string Combo_reembolsocreatedby_Ddointernalname ;
      private string Combo_reembolsocreatedby_Titlecontrolalign ;
      private string Combo_reembolsocreatedby_Dropdownoptionstype ;
      private string Combo_reembolsocreatedby_Titlecontrolidtoreplace ;
      private string Combo_reembolsocreatedby_Datalisttype ;
      private string Combo_reembolsocreatedby_Datalistfixedvalues ;
      private string Combo_reembolsocreatedby_Remoteservicesparameters ;
      private string Combo_reembolsocreatedby_Htmltemplate ;
      private string Combo_reembolsocreatedby_Multiplevaluestype ;
      private string Combo_reembolsocreatedby_Loadingdata ;
      private string Combo_reembolsocreatedby_Noresultsfound ;
      private string Combo_reembolsocreatedby_Emptyitemtext ;
      private string Combo_reembolsocreatedby_Onlyselectedvalues ;
      private string Combo_reembolsocreatedby_Selectalltext ;
      private string Combo_reembolsocreatedby_Multiplevaluesseparator ;
      private string Combo_reembolsocreatedby_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode71 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z522ReembolsoCreatedAt ;
      private DateTime A522ReembolsoCreatedAt ;
      private DateTime A547ReembolsoEtapaUltimo_F ;
      private DateTime Z547ReembolsoEtapaUltimo_F ;
      private DateTime i522ReembolsoCreatedAt ;
      private DateTime Z525ReembolsoDataAberturaConvenio ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n518ReembolsoId ;
      private bool n742WorkflowConvenioId ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n544ReembolsoCreatedBy ;
      private bool wbErr ;
      private bool n548ReembolsoStatusAtual_F ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n522ReembolsoCreatedAt ;
      private bool n546ReembolsoProtocolo ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n645ReembolsoValorReembolsado_F ;
      private bool n736WorkflowConvenioDesc ;
      private bool n758ReembolsoPropostaClinicaId ;
      private bool Combo_reembolsopropostaid_Enabled ;
      private bool Combo_reembolsopropostaid_Visible ;
      private bool Combo_reembolsopropostaid_Allowmultipleselection ;
      private bool Combo_reembolsopropostaid_Isgriditem ;
      private bool Combo_reembolsopropostaid_Hasdescription ;
      private bool Combo_reembolsopropostaid_Includeonlyselectedoption ;
      private bool Combo_reembolsopropostaid_Includeselectalloption ;
      private bool Combo_reembolsopropostaid_Emptyitem ;
      private bool Combo_reembolsopropostaid_Includeaddnewoption ;
      private bool Combo_reembolsocreatedby_Enabled ;
      private bool Combo_reembolsocreatedby_Visible ;
      private bool Combo_reembolsocreatedby_Allowmultipleselection ;
      private bool Combo_reembolsocreatedby_Isgriditem ;
      private bool Combo_reembolsocreatedby_Hasdescription ;
      private bool Combo_reembolsocreatedby_Includeonlyselectedoption ;
      private bool Combo_reembolsocreatedby_Includeselectalloption ;
      private bool Combo_reembolsocreatedby_Emptyitem ;
      private bool Combo_reembolsocreatedby_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n543ReembolsoPropostaValor ;
      private bool n547ReembolsoEtapaUltimo_F ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV18Combo_DataJson ;
      private string Z546ReembolsoProtocolo ;
      private string A548ReembolsoStatusAtual_F ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A546ReembolsoProtocolo ;
      private string A736WorkflowConvenioDesc ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z736WorkflowConvenioDesc ;
      private string Z550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_reembolsopropostaid ;
      private GXUserControl ucCombo_reembolsocreatedby ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbReembolsoStatusAtual_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14ReembolsoPropostaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21ReembolsoCreatedBy_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] T001Y12_A645ReembolsoValorReembolsado_F ;
      private bool[] T001Y12_n645ReembolsoValorReembolsado_F ;
      private DateTime[] T001Y14_A547ReembolsoEtapaUltimo_F ;
      private bool[] T001Y14_n547ReembolsoEtapaUltimo_F ;
      private string[] T001Y7_A736WorkflowConvenioDesc ;
      private bool[] T001Y7_n736WorkflowConvenioDesc ;
      private int[] T001Y17_A518ReembolsoId ;
      private bool[] T001Y17_n518ReembolsoId ;
      private DateTime[] T001Y17_A522ReembolsoCreatedAt ;
      private bool[] T001Y17_n522ReembolsoCreatedAt ;
      private string[] T001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] T001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string[] T001Y17_A546ReembolsoProtocolo ;
      private bool[] T001Y17_n546ReembolsoProtocolo ;
      private decimal[] T001Y17_A543ReembolsoPropostaValor ;
      private bool[] T001Y17_n543ReembolsoPropostaValor ;
      private DateTime[] T001Y17_A525ReembolsoDataAberturaConvenio ;
      private bool[] T001Y17_n525ReembolsoDataAberturaConvenio ;
      private string[] T001Y17_A736WorkflowConvenioDesc ;
      private bool[] T001Y17_n736WorkflowConvenioDesc ;
      private int[] T001Y17_A742WorkflowConvenioId ;
      private bool[] T001Y17_n742WorkflowConvenioId ;
      private int[] T001Y17_A542ReembolsoPropostaId ;
      private bool[] T001Y17_n542ReembolsoPropostaId ;
      private short[] T001Y17_A544ReembolsoCreatedBy ;
      private bool[] T001Y17_n544ReembolsoCreatedBy ;
      private int[] T001Y17_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] T001Y17_n558ReembolsoPropostaPacienteClienteId ;
      private int[] T001Y17_A758ReembolsoPropostaClinicaId ;
      private bool[] T001Y17_n758ReembolsoPropostaClinicaId ;
      private decimal[] T001Y17_A645ReembolsoValorReembolsado_F ;
      private bool[] T001Y17_n645ReembolsoValorReembolsado_F ;
      private DateTime[] T001Y17_A547ReembolsoEtapaUltimo_F ;
      private bool[] T001Y17_n547ReembolsoEtapaUltimo_F ;
      private decimal[] T001Y8_A543ReembolsoPropostaValor ;
      private bool[] T001Y8_n543ReembolsoPropostaValor ;
      private int[] T001Y8_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] T001Y8_n558ReembolsoPropostaPacienteClienteId ;
      private int[] T001Y8_A758ReembolsoPropostaClinicaId ;
      private bool[] T001Y8_n758ReembolsoPropostaClinicaId ;
      private string[] T001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] T001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private short[] T001Y9_A544ReembolsoCreatedBy ;
      private bool[] T001Y9_n544ReembolsoCreatedBy ;
      private decimal[] T001Y19_A645ReembolsoValorReembolsado_F ;
      private bool[] T001Y19_n645ReembolsoValorReembolsado_F ;
      private DateTime[] T001Y21_A547ReembolsoEtapaUltimo_F ;
      private bool[] T001Y21_n547ReembolsoEtapaUltimo_F ;
      private decimal[] T001Y22_A543ReembolsoPropostaValor ;
      private bool[] T001Y22_n543ReembolsoPropostaValor ;
      private int[] T001Y22_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] T001Y22_n558ReembolsoPropostaPacienteClienteId ;
      private int[] T001Y22_A758ReembolsoPropostaClinicaId ;
      private bool[] T001Y22_n758ReembolsoPropostaClinicaId ;
      private string[] T001Y23_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] T001Y23_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private short[] T001Y24_A544ReembolsoCreatedBy ;
      private bool[] T001Y24_n544ReembolsoCreatedBy ;
      private string[] T001Y25_A736WorkflowConvenioDesc ;
      private bool[] T001Y25_n736WorkflowConvenioDesc ;
      private int[] T001Y26_A518ReembolsoId ;
      private bool[] T001Y26_n518ReembolsoId ;
      private int[] T001Y3_A518ReembolsoId ;
      private bool[] T001Y3_n518ReembolsoId ;
      private DateTime[] T001Y3_A522ReembolsoCreatedAt ;
      private bool[] T001Y3_n522ReembolsoCreatedAt ;
      private string[] T001Y3_A546ReembolsoProtocolo ;
      private bool[] T001Y3_n546ReembolsoProtocolo ;
      private DateTime[] T001Y3_A525ReembolsoDataAberturaConvenio ;
      private bool[] T001Y3_n525ReembolsoDataAberturaConvenio ;
      private int[] T001Y3_A742WorkflowConvenioId ;
      private bool[] T001Y3_n742WorkflowConvenioId ;
      private int[] T001Y3_A542ReembolsoPropostaId ;
      private bool[] T001Y3_n542ReembolsoPropostaId ;
      private short[] T001Y3_A544ReembolsoCreatedBy ;
      private bool[] T001Y3_n544ReembolsoCreatedBy ;
      private int[] T001Y27_A518ReembolsoId ;
      private bool[] T001Y27_n518ReembolsoId ;
      private int[] T001Y28_A518ReembolsoId ;
      private bool[] T001Y28_n518ReembolsoId ;
      private int[] T001Y2_A518ReembolsoId ;
      private bool[] T001Y2_n518ReembolsoId ;
      private DateTime[] T001Y2_A522ReembolsoCreatedAt ;
      private bool[] T001Y2_n522ReembolsoCreatedAt ;
      private string[] T001Y2_A546ReembolsoProtocolo ;
      private bool[] T001Y2_n546ReembolsoProtocolo ;
      private DateTime[] T001Y2_A525ReembolsoDataAberturaConvenio ;
      private bool[] T001Y2_n525ReembolsoDataAberturaConvenio ;
      private int[] T001Y2_A742WorkflowConvenioId ;
      private bool[] T001Y2_n742WorkflowConvenioId ;
      private int[] T001Y2_A542ReembolsoPropostaId ;
      private bool[] T001Y2_n542ReembolsoPropostaId ;
      private short[] T001Y2_A544ReembolsoCreatedBy ;
      private bool[] T001Y2_n544ReembolsoCreatedBy ;
      private int[] T001Y30_A518ReembolsoId ;
      private bool[] T001Y30_n518ReembolsoId ;
      private decimal[] T001Y34_A645ReembolsoValorReembolsado_F ;
      private bool[] T001Y34_n645ReembolsoValorReembolsado_F ;
      private DateTime[] T001Y36_A547ReembolsoEtapaUltimo_F ;
      private bool[] T001Y36_n547ReembolsoEtapaUltimo_F ;
      private decimal[] T001Y37_A543ReembolsoPropostaValor ;
      private bool[] T001Y37_n543ReembolsoPropostaValor ;
      private int[] T001Y37_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] T001Y37_n558ReembolsoPropostaPacienteClienteId ;
      private int[] T001Y37_A758ReembolsoPropostaClinicaId ;
      private bool[] T001Y37_n758ReembolsoPropostaClinicaId ;
      private string[] T001Y38_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] T001Y38_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string[] T001Y39_A736WorkflowConvenioDesc ;
      private bool[] T001Y39_n736WorkflowConvenioDesc ;
      private int[] T001Y40_A746ReembolsoFlowLogId ;
      private int[] T001Y41_A634ReembolsoParcelasId ;
      private int[] T001Y42_A631ReembolsoAssinaturasId ;
      private int[] T001Y43_A526ReembolsoEtapaId ;
      private int[] T001Y44_A518ReembolsoId ;
      private bool[] T001Y44_n518ReembolsoId ;
      private short[] T001Y45_A544ReembolsoCreatedBy ;
      private bool[] T001Y45_n544ReembolsoCreatedBy ;
      private string[] T001Y6_A548ReembolsoStatusAtual_F ;
      private bool[] T001Y6_n548ReembolsoStatusAtual_F ;
   }

   public class reembolso__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
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
          Object[] prmT001Y2;
          prmT001Y2 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y3;
          prmT001Y3 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y6;
          prmT001Y6 = new Object[] {
          };
          Object[] prmT001Y7;
          prmT001Y7 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y8;
          prmT001Y8 = new Object[] {
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y9;
          prmT001Y9 = new Object[] {
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001Y10;
          prmT001Y10 = new Object[] {
          new ParDef("ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y12;
          prmT001Y12 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y14;
          prmT001Y14 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y17;
          prmT001Y17 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y19;
          prmT001Y19 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y21;
          prmT001Y21 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y22;
          prmT001Y22 = new Object[] {
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y23;
          prmT001Y23 = new Object[] {
          new ParDef("ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y24;
          prmT001Y24 = new Object[] {
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001Y25;
          prmT001Y25 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y26;
          prmT001Y26 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y27;
          prmT001Y27 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y28;
          prmT001Y28 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y29;
          prmT001Y29 = new Object[] {
          new ParDef("ReembolsoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoDataAberturaConvenio",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001Y30;
          prmT001Y30 = new Object[] {
          };
          Object[] prmT001Y31;
          prmT001Y31 = new Object[] {
          new ParDef("ReembolsoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoDataAberturaConvenio",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y32;
          prmT001Y32 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y34;
          prmT001Y34 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y36;
          prmT001Y36 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y37;
          prmT001Y37 = new Object[] {
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y38;
          prmT001Y38 = new Object[] {
          new ParDef("ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y39;
          prmT001Y39 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y40;
          prmT001Y40 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y41;
          prmT001Y41 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y42;
          prmT001Y42 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y43;
          prmT001Y43 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Y44;
          prmT001Y44 = new Object[] {
          };
          Object[] prmT001Y45;
          prmT001Y45 = new Object[] {
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001Y2", "SELECT ReembolsoId, ReembolsoCreatedAt, ReembolsoProtocolo, ReembolsoDataAberturaConvenio, WorkflowConvenioId, ReembolsoPropostaId, ReembolsoCreatedBy FROM Reembolso WHERE ReembolsoId = :ReembolsoId  FOR UPDATE OF Reembolso NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y3", "SELECT ReembolsoId, ReembolsoCreatedAt, ReembolsoProtocolo, ReembolsoDataAberturaConvenio, WorkflowConvenioId, ReembolsoPropostaId, ReembolsoCreatedBy FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y6", "SELECT COALESCE( T1.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId AS ReembolsoPropostaId FROM ((ReembolsoEtapa T2 LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T2.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T4 ON T4.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T4.ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y7", "SELECT WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y8", "SELECT PropostaValor AS ReembolsoPropostaValor, PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, PropostaClinicaId AS ReembolsoPropostaClinicaId FROM Proposta WHERE PropostaId = :ReembolsoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y9", "SELECT SecUserId AS ReembolsoCreatedBy FROM SecUser WHERE SecUserId = :ReembolsoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y10", "SELECT ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :ReembolsoPropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y12", "SELECT COALESCE( T1.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y14", "SELECT COALESCE( T1.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y17", "SELECT TM1.ReembolsoId, TM1.ReembolsoCreatedAt, T6.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, TM1.ReembolsoProtocolo, T5.PropostaValor AS ReembolsoPropostaValor, TM1.ReembolsoDataAberturaConvenio, T2.WorkflowConvenioDesc, TM1.WorkflowConvenioId, TM1.ReembolsoPropostaId AS ReembolsoPropostaId, TM1.ReembolsoCreatedBy AS ReembolsoCreatedBy, T5.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T5.PropostaClinicaId AS ReembolsoPropostaClinicaId, COALESCE( T3.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F, COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (((((Reembolso TM1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = TM1.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas WHERE TM1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = TM1.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE TM1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T4 ON T4.ReembolsoId = TM1.ReembolsoId) LEFT JOIN Proposta T5 ON T5.PropostaId = TM1.ReembolsoPropostaId) LEFT JOIN Cliente T6 ON T6.ClienteId = T5.PropostaPacienteClienteId) WHERE TM1.ReembolsoId = :ReembolsoId ORDER BY TM1.ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y19", "SELECT COALESCE( T1.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y21", "SELECT COALESCE( T1.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y22", "SELECT PropostaValor AS ReembolsoPropostaValor, PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, PropostaClinicaId AS ReembolsoPropostaClinicaId FROM Proposta WHERE PropostaId = :ReembolsoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y23", "SELECT ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :ReembolsoPropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y24", "SELECT SecUserId AS ReembolsoCreatedBy FROM SecUser WHERE SecUserId = :ReembolsoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y25", "SELECT WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y26", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y27", "SELECT ReembolsoId FROM Reembolso WHERE ( ReembolsoId > :ReembolsoId) ORDER BY ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Y28", "SELECT ReembolsoId FROM Reembolso WHERE ( ReembolsoId < :ReembolsoId) ORDER BY ReembolsoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Y29", "SAVEPOINT gxupdate;INSERT INTO Reembolso(ReembolsoCreatedAt, ReembolsoProtocolo, ReembolsoDataAberturaConvenio, WorkflowConvenioId, ReembolsoPropostaId, ReembolsoCreatedBy) VALUES(:ReembolsoCreatedAt, :ReembolsoProtocolo, :ReembolsoDataAberturaConvenio, :WorkflowConvenioId, :ReembolsoPropostaId, :ReembolsoCreatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Y29)
             ,new CursorDef("T001Y30", "SELECT currval('ReembolsoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y31", "SAVEPOINT gxupdate;UPDATE Reembolso SET ReembolsoCreatedAt=:ReembolsoCreatedAt, ReembolsoProtocolo=:ReembolsoProtocolo, ReembolsoDataAberturaConvenio=:ReembolsoDataAberturaConvenio, WorkflowConvenioId=:WorkflowConvenioId, ReembolsoPropostaId=:ReembolsoPropostaId, ReembolsoCreatedBy=:ReembolsoCreatedBy  WHERE ReembolsoId = :ReembolsoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Y31)
             ,new CursorDef("T001Y32", "SAVEPOINT gxupdate;DELETE FROM Reembolso  WHERE ReembolsoId = :ReembolsoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Y32)
             ,new CursorDef("T001Y34", "SELECT COALESCE( T1.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y36", "SELECT COALESCE( T1.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y37", "SELECT PropostaValor AS ReembolsoPropostaValor, PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, PropostaClinicaId AS ReembolsoPropostaClinicaId FROM Proposta WHERE PropostaId = :ReembolsoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y37,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y38", "SELECT ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :ReembolsoPropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y38,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y39", "SELECT WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y39,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y40", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoLogId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y40,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Y41", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y41,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Y42", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y42,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Y43", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y43,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Y44", "SELECT ReembolsoId FROM Reembolso ORDER BY ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y44,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Y45", "SELECT SecUserId AS ReembolsoCreatedBy FROM SecUser WHERE SecUserId = :ReembolsoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y45,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
