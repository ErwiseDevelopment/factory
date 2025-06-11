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
   public class tituloproposta : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel9"+"_"+"TITULOTOTALMULTAJUROSCREDITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX9ASATITULOTOTALMULTAJUROSCREDITO_F1X44( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"TITULOTOTALMULTAJUROSDEBITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASATITULOTOTALMULTAJUROSDEBITO_F1X44( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"TITULOTOTALMOVIMENTOCREDITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX11ASATITULOTOTALMOVIMENTOCREDITO_F1X44( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"TITULOTOTALMOVIMENTODEBITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX12ASATITULOTOTALMOVIMENTODEBITO_F1X44( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( GetPar( "NotaFiscalParcelamentoID"));
            n890NotaFiscalParcelamentoID = false;
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A890NotaFiscalParcelamentoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
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
            gxLoad_31( A794NotaFiscalId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
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
            gxLoad_32( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A422ContaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaId"), "."), 18, MidpointRounding.ToEven));
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A422ContaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A426CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "CategoriaTituloId"), "."), 18, MidpointRounding.ToEven));
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A426CategoriaTituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A419TituloPropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloPropostaId"), "."), 18, MidpointRounding.ToEven));
            n419TituloPropostaId = false;
            AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A419TituloPropostaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "tituloproposta")), "tituloproposta") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "tituloproposta")))) ;
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
                  AV7TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7TituloId", StringUtil.LTrimStr( (decimal)(AV7TituloId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TituloId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Titulo Proposta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tituloproposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tituloproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TituloId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TituloId = aP1_TituloId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTituloTipo = new GXCombobox();
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
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
            AssignProp("", false, cmbTituloTipo_Internalname, "Values", cmbTituloTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloId_Internalname, "Título", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")), StringUtil.LTrim( ((edtTituloId_Enabled!=0) ? context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteRazaoSocial_Internalname, "Cliente", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteRazaoSocial_Internalname, A170ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloValor_Internalname, ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( ((edtTituloValor_Enabled!=0) ? context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloDesconto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloDesconto_Internalname, "Desconto", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloDesconto_Internalname, ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( ((edtTituloDesconto_Enabled!=0) ? context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloDesconto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloDesconto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloProrrogacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloProrrogacao_Internalname, "Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloProrrogacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloProrrogacao_Internalname, context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"), context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloProrrogacao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloProrrogacao_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_bitmap( context, edtTituloProrrogacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTituloProrrogacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TituloProposta.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloCompetencia_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloCompetencia_F_Internalname, "Competência", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCompetencia_F_Internalname, A295TituloCompetencia_F, StringUtil.RTrim( context.localUtil.Format( A295TituloCompetencia_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCompetencia_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloCompetencia_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloStatus_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloStatus_F_Internalname, "Situação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloStatus_F_Internalname, A282TituloStatus_F, StringUtil.RTrim( context.localUtil.Format( A282TituloStatus_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloStatus_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloStatus_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTituloTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTituloTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTituloTipo, cmbTituloTipo_Internalname, StringUtil.RTrim( A283TituloTipo), 1, cmbTituloTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbTituloTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_TituloProposta.htm");
         cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
         AssignProp("", false, cmbTituloTipo_Internalname, "Values", (string)(cmbTituloTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloSaldo_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloSaldo_F_Internalname, "Saldo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloSaldo_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtTituloSaldo_F_Enabled!=0) ? context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloSaldo_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloSaldo_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloTotalMovimento_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloTotalMovimento_F_Internalname, "Total baixado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloTotalMovimento_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtTituloTotalMovimento_F_Enabled!=0) ? context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloTotalMovimento_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloTotalMovimento_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_TituloProposta.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloCEP_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCEP_Internalname, A265TituloCEP, StringUtil.RTrim( context.localUtil.Format( A265TituloCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCEP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloCEP_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloLogradouro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloLogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloLogradouro_Internalname, A266TituloLogradouro, StringUtil.RTrim( context.localUtil.Format( A266TituloLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloLogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloNumeroEndereco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloNumeroEndereco_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloNumeroEndereco_Internalname, A294TituloNumeroEndereco, StringUtil.RTrim( context.localUtil.Format( A294TituloNumeroEndereco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloNumeroEndereco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloNumeroEndereco_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloComplemento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloComplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloComplemento_Internalname, A267TituloComplemento, StringUtil.RTrim( context.localUtil.Format( A267TituloComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloComplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloComplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloBairro_Internalname, A268TituloBairro, StringUtil.RTrim( context.localUtil.Format( A268TituloBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMunicipio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMunicipio_Internalname, "Municipio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloMunicipio_Internalname, A269TituloMunicipio, StringUtil.RTrim( context.localUtil.Format( A269TituloMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMunicipio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMunicipio_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemovimentos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0098"+"", StringUtil.RTrim( WebComp_Wctitulomovimentoww_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0098"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWctitulomovimentoww), StringUtil.Lower( WebComp_Wctitulomovimentoww_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0098"+"");
               }
               WebComp_Wctitulomovimentoww.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWctitulomovimentoww), StringUtil.Lower( WebComp_Wctitulomovimentoww_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TituloProposta.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloDeleted_Internalname, StringUtil.BoolToStr( A284TituloDeleted), StringUtil.BoolToStr( A284TituloDeleted), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloDeleted_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloDeleted_Visible, edtTituloDeleted_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_TituloProposta.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloVencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloVencimento_Internalname, context.localUtil.Format(A263TituloVencimento, "99/99/9999"), context.localUtil.Format( A263TituloVencimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloVencimento_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloVencimento_Visible, edtTituloVencimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_bitmap( context, edtTituloVencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTituloVencimento_Visible==0)||(edtTituloVencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TituloProposta.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCompetenciaAno_Internalname, ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ",", ""))), ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( ((edtTituloCompetenciaAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9") : context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCompetenciaAno_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloCompetenciaAno_Visible, edtTituloCompetenciaAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloProposta.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCompetenciaMes_Internalname, ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ",", ""))), ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( ((edtTituloCompetenciaMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9") : context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCompetenciaMes_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloCompetenciaMes_Visible, edtTituloCompetenciaMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloProposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
               {
                  WebComp_Wctitulomovimentoww.componentstart();
               }
            }
         }
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
         E111X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z261TituloId"), ",", "."), 18, MidpointRounding.ToEven));
               Z890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "Z890NotaFiscalParcelamentoID"));
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               Z262TituloValor = context.localUtil.CToN( cgiGet( "Z262TituloValor"), ",", ".");
               n262TituloValor = ((Convert.ToDecimal(0)==A262TituloValor) ? true : false);
               Z276TituloDesconto = context.localUtil.CToN( cgiGet( "Z276TituloDesconto"), ",", ".");
               n276TituloDesconto = ((Convert.ToDecimal(0)==A276TituloDesconto) ? true : false);
               Z284TituloDeleted = StringUtil.StrToBool( cgiGet( "Z284TituloDeleted"));
               n284TituloDeleted = ((false==A284TituloDeleted) ? true : false);
               Z314TituloArchived = StringUtil.StrToBool( cgiGet( "Z314TituloArchived"));
               n314TituloArchived = ((false==A314TituloArchived) ? true : false);
               Z263TituloVencimento = context.localUtil.CToD( cgiGet( "Z263TituloVencimento"), 0);
               n263TituloVencimento = ((DateTime.MinValue==A263TituloVencimento) ? true : false);
               Z286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z286TituloCompetenciaAno"), ",", "."), 18, MidpointRounding.ToEven));
               n286TituloCompetenciaAno = ((0==A286TituloCompetenciaAno) ? true : false);
               Z287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z287TituloCompetenciaMes"), ",", "."), 18, MidpointRounding.ToEven));
               n287TituloCompetenciaMes = ((0==A287TituloCompetenciaMes) ? true : false);
               Z264TituloProrrogacao = context.localUtil.CToD( cgiGet( "Z264TituloProrrogacao"), 0);
               n264TituloProrrogacao = ((DateTime.MinValue==A264TituloProrrogacao) ? true : false);
               Z265TituloCEP = cgiGet( "Z265TituloCEP");
               n265TituloCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A265TituloCEP)) ? true : false);
               Z266TituloLogradouro = cgiGet( "Z266TituloLogradouro");
               n266TituloLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A266TituloLogradouro)) ? true : false);
               Z294TituloNumeroEndereco = cgiGet( "Z294TituloNumeroEndereco");
               n294TituloNumeroEndereco = (String.IsNullOrEmpty(StringUtil.RTrim( A294TituloNumeroEndereco)) ? true : false);
               Z267TituloComplemento = cgiGet( "Z267TituloComplemento");
               n267TituloComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A267TituloComplemento)) ? true : false);
               Z268TituloBairro = cgiGet( "Z268TituloBairro");
               n268TituloBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A268TituloBairro)) ? true : false);
               Z269TituloMunicipio = cgiGet( "Z269TituloMunicipio");
               n269TituloMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A269TituloMunicipio)) ? true : false);
               Z498TituloJurosMora = context.localUtil.CToN( cgiGet( "Z498TituloJurosMora"), ",", ".");
               n498TituloJurosMora = ((Convert.ToDecimal(0)==A498TituloJurosMora) ? true : false);
               Z283TituloTipo = cgiGet( "Z283TituloTipo");
               n283TituloTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ? true : false);
               Z500TituloCriacao = context.localUtil.CToT( cgiGet( "Z500TituloCriacao"), 0);
               n500TituloCriacao = ((DateTime.MinValue==A500TituloCriacao) ? true : false);
               Z422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = ((0==A422ContaId) ? true : false);
               Z426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               Z419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z419TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "Z890NotaFiscalParcelamentoID"));
               n890NotaFiscalParcelamentoID = false;
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               A314TituloArchived = StringUtil.StrToBool( cgiGet( "Z314TituloArchived"));
               n314TituloArchived = false;
               n314TituloArchived = ((false==A314TituloArchived) ? true : false);
               A498TituloJurosMora = context.localUtil.CToN( cgiGet( "Z498TituloJurosMora"), ",", ".");
               n498TituloJurosMora = false;
               n498TituloJurosMora = ((Convert.ToDecimal(0)==A498TituloJurosMora) ? true : false);
               A500TituloCriacao = context.localUtil.CToT( cgiGet( "Z500TituloCriacao"), 0);
               n500TituloCriacao = false;
               n500TituloCriacao = ((DateTime.MinValue==A500TituloCriacao) ? true : false);
               A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = false;
               n422ContaId = ((0==A422ContaId) ? true : false);
               A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = false;
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z419TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = false;
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = false;
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               N419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N419TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               N422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = ((0==A422ContaId) ? true : false);
               N426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               A303TituloSaldoCredito_F = context.localUtil.CToN( cgiGet( "TITULOSALDOCREDITO_F"), ",", ".");
               A302TituloSaldoDebito_F = context.localUtil.CToN( cgiGet( "TITULOSALDODEBITO_F"), ",", ".");
               A307TituloTotalMultaJurosCredito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMULTAJUROSCREDITO_F"), ",", ".");
               A306TituloTotalMultaJurosDebito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMULTAJUROSDEBITO_F"), ",", ".");
               A305TituloTotalMovimentoCredito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMOVIMENTOCREDITO_F"), ",", ".");
               A304TituloTotalMovimentoDebito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMOVIMENTODEBITO_F"), ",", ".");
               AV7TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vTITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               AV20Insert_TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TITULOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20Insert_TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV20Insert_TituloPropostaId), 9, 0));
               A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TITULOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               AV21Insert_ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21Insert_ContaId", StringUtil.LTrimStr( (decimal)(AV21Insert_ContaId), 9, 0));
               A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONTAID"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = ((0==A422ContaId) ? true : false);
               AV22Insert_CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORIATITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22Insert_CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV22Insert_CategoriaTituloId), 9, 0));
               A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIATITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A500TituloCriacao = context.localUtil.CToT( cgiGet( "TITULOCRIACAO"), 0);
               n500TituloCriacao = ((DateTime.MinValue==A500TituloCriacao) ? true : false);
               A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "NOTAFISCALPARCELAMENTOID"));
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               A314TituloArchived = StringUtil.StrToBool( cgiGet( "TITULOARCHIVED"));
               n314TituloArchived = ((false==A314TituloArchived) ? true : false);
               A498TituloJurosMora = context.localUtil.CToN( cgiGet( "TITULOJUROSMORA"), ",", ".");
               n498TituloJurosMora = ((Convert.ToDecimal(0)==A498TituloJurosMora) ? true : false);
               A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "NOTAFISCALID"));
               A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( "PROPOSTATAXAADMINISTRATIVA"), ",", ".");
               n501PropostaTaxaAdministrativa = false;
               A301TituloTotalMultaJuros_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMULTAJUROS_F"), ",", ".");
               n301TituloTotalMultaJuros_F = false;
               AV24Pgmname = cgiGet( "vPGMNAME");
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
               A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
               n170ClienteRazaoSocial = false;
               AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
               n262TituloValor = ((StringUtil.StrCmp(cgiGet( edtTituloValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A262TituloValor = 0;
                  n262TituloValor = false;
                  AssignAttri("", false, "A262TituloValor", (n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
               }
               else
               {
                  A262TituloValor = context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".");
                  AssignAttri("", false, "A262TituloValor", (n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
               }
               n276TituloDesconto = ((StringUtil.StrCmp(cgiGet( edtTituloDesconto_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULODESCONTO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloDesconto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A276TituloDesconto = 0;
                  n276TituloDesconto = false;
                  AssignAttri("", false, "A276TituloDesconto", (n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
               }
               else
               {
                  A276TituloDesconto = context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".");
                  AssignAttri("", false, "A276TituloDesconto", (n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtTituloProrrogacao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Titulo Prorrogacao"}), 1, "TITULOPRORROGACAO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloProrrogacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A264TituloProrrogacao = DateTime.MinValue;
                  n264TituloProrrogacao = false;
                  AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
               }
               else
               {
                  A264TituloProrrogacao = context.localUtil.CToD( cgiGet( edtTituloProrrogacao_Internalname), 2);
                  n264TituloProrrogacao = false;
                  AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
               }
               n264TituloProrrogacao = ((DateTime.MinValue==A264TituloProrrogacao) ? true : false);
               A295TituloCompetencia_F = cgiGet( edtTituloCompetencia_F_Internalname);
               AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
               A282TituloStatus_F = cgiGet( edtTituloStatus_F_Internalname);
               AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
               cmbTituloTipo.CurrentValue = cgiGet( cmbTituloTipo_Internalname);
               A283TituloTipo = cgiGet( cmbTituloTipo_Internalname);
               n283TituloTipo = false;
               AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
               n283TituloTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ? true : false);
               A275TituloSaldo_F = context.localUtil.CToN( cgiGet( edtTituloSaldo_F_Internalname), ",", ".");
               AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
               A273TituloTotalMovimento_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimento_F_Internalname), ",", ".");
               n273TituloTotalMovimento_F = false;
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
               A265TituloCEP = cgiGet( edtTituloCEP_Internalname);
               n265TituloCEP = false;
               AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
               n265TituloCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A265TituloCEP)) ? true : false);
               A266TituloLogradouro = cgiGet( edtTituloLogradouro_Internalname);
               n266TituloLogradouro = false;
               AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
               n266TituloLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A266TituloLogradouro)) ? true : false);
               A294TituloNumeroEndereco = cgiGet( edtTituloNumeroEndereco_Internalname);
               n294TituloNumeroEndereco = false;
               AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
               n294TituloNumeroEndereco = (String.IsNullOrEmpty(StringUtil.RTrim( A294TituloNumeroEndereco)) ? true : false);
               A267TituloComplemento = cgiGet( edtTituloComplemento_Internalname);
               n267TituloComplemento = false;
               AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
               n267TituloComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A267TituloComplemento)) ? true : false);
               A268TituloBairro = cgiGet( edtTituloBairro_Internalname);
               n268TituloBairro = false;
               AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
               n268TituloBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A268TituloBairro)) ? true : false);
               A269TituloMunicipio = cgiGet( edtTituloMunicipio_Internalname);
               n269TituloMunicipio = false;
               AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
               n269TituloMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A269TituloMunicipio)) ? true : false);
               A284TituloDeleted = StringUtil.StrToBool( cgiGet( edtTituloDeleted_Internalname));
               n284TituloDeleted = false;
               AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
               n284TituloDeleted = ((false==A284TituloDeleted) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTituloVencimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Titulo Vencimento"}), 1, "TITULOVENCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloVencimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A263TituloVencimento = DateTime.MinValue;
                  n263TituloVencimento = false;
                  AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
               }
               else
               {
                  A263TituloVencimento = context.localUtil.CToD( cgiGet( edtTituloVencimento_Internalname), 2);
                  n263TituloVencimento = false;
                  AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
               }
               n263TituloVencimento = ((DateTime.MinValue==A263TituloVencimento) ? true : false);
               n286TituloCompetenciaAno = ((StringUtil.StrCmp(cgiGet( edtTituloCompetenciaAno_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOCOMPETENCIAANO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloCompetenciaAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A286TituloCompetenciaAno = 0;
                  n286TituloCompetenciaAno = false;
                  AssignAttri("", false, "A286TituloCompetenciaAno", (n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
               }
               else
               {
                  A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A286TituloCompetenciaAno", (n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
               }
               n287TituloCompetenciaMes = ((StringUtil.StrCmp(cgiGet( edtTituloCompetenciaMes_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOCOMPETENCIAMES");
                  AnyError = 1;
                  GX_FocusControl = edtTituloCompetenciaMes_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A287TituloCompetenciaMes = 0;
                  n287TituloCompetenciaMes = false;
                  AssignAttri("", false, "A287TituloCompetenciaMes", (n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
               }
               else
               {
                  A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A287TituloCompetenciaMes", (n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TituloProposta");
               A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               forbiddenHiddens.Add("TituloId", context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
               forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TituloPropostaId", context.localUtil.Format( (decimal)(AV20Insert_TituloPropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContaId", context.localUtil.Format( (decimal)(AV21Insert_ContaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_CategoriaTituloId", context.localUtil.Format( (decimal)(AV22Insert_CategoriaTituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("TituloArchived", StringUtil.BoolToStr( A314TituloArchived));
               forbiddenHiddens.Add("TituloJurosMora", context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("TituloCriacao", context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A261TituloId != Z261TituloId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tituloproposta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
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
                     sMode44 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode44;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound44 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TITULOID");
                        AnyError = 1;
                        GX_FocusControl = edtTituloId_Internalname;
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
                           E111X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121X2 ();
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
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 98 )
                     {
                        OldWctitulomovimentoww = cgiGet( "W0098");
                        if ( ( StringUtil.Len( OldWctitulomovimentoww) == 0 ) || ( StringUtil.StrCmp(OldWctitulomovimentoww, WebComp_Wctitulomovimentoww_Component) != 0 ) )
                        {
                           WebComp_Wctitulomovimentoww = getWebComponent(GetType(), "GeneXus.Programs", OldWctitulomovimentoww, new Object[] {context} );
                           WebComp_Wctitulomovimentoww.ComponentInit();
                           WebComp_Wctitulomovimentoww.Name = "OldWctitulomovimentoww";
                           WebComp_Wctitulomovimentoww_Component = OldWctitulomovimentoww;
                        }
                        if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
                        {
                           WebComp_Wctitulomovimentoww.componentprocess("W0098", "", sEvt);
                        }
                        WebComp_Wctitulomovimentoww_Component = OldWctitulomovimentoww;
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
            E121X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1X44( ) ;
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
            DisableAttributes1X44( ) ;
         }
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

      protected void CONFIRM_1X0( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1X44( ) ;
            }
            else
            {
               CheckExtendedTable1X44( ) ;
               CloseExtendedTableCursors1X44( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1X0( )
      {
      }

      protected void E111X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TituloPropostaId") == 0 )
               {
                  AV20Insert_TituloPropostaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20Insert_TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV20Insert_TituloPropostaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContaId") == 0 )
               {
                  AV21Insert_ContaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV21Insert_ContaId", StringUtil.LTrimStr( (decimal)(AV21Insert_ContaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CategoriaTituloId") == 0 )
               {
                  AV22Insert_CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22Insert_CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV22Insert_CategoriaTituloId), 9, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtTituloDeleted_Visible = 0;
         AssignProp("", false, edtTituloDeleted_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloDeleted_Visible), 5, 0), true);
         edtTituloVencimento_Visible = 0;
         AssignProp("", false, edtTituloVencimento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloVencimento_Visible), 5, 0), true);
         edtTituloCompetenciaAno_Visible = 0;
         AssignProp("", false, edtTituloCompetenciaAno_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaAno_Visible), 5, 0), true);
         edtTituloCompetenciaMes_Visible = 0;
         AssignProp("", false, edtTituloCompetenciaMes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaMes_Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wctitulomovimentoww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wctitulomovimentoww_Component), StringUtil.Lower( "TituloMovimentoWW")) != 0 )
         {
            WebComp_Wctitulomovimentoww = getWebComponent(GetType(), "GeneXus.Programs", "titulomovimentoww", new Object[] {context} );
            WebComp_Wctitulomovimentoww.ComponentInit();
            WebComp_Wctitulomovimentoww.Name = "TituloMovimentoWW";
            WebComp_Wctitulomovimentoww_Component = "TituloMovimentoWW";
         }
         if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
         {
            WebComp_Wctitulomovimentoww.setjustcreated();
            WebComp_Wctitulomovimentoww.componentprepare(new Object[] {(string)"W0098",(string)"",(int)AV7TituloId});
            WebComp_Wctitulomovimentoww.componentbind(new Object[] {(string)""});
         }
      }

      protected void E121X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "titulopropostaww"+UrlEncode(StringUtil.LTrimStr(A419TituloPropostaId,9,0));
            CallWebObject(formatLink("titulopropostaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1X44( short GX_JID )
      {
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z890NotaFiscalParcelamentoID = T001X3_A890NotaFiscalParcelamentoID[0];
               Z262TituloValor = T001X3_A262TituloValor[0];
               Z276TituloDesconto = T001X3_A276TituloDesconto[0];
               Z284TituloDeleted = T001X3_A284TituloDeleted[0];
               Z314TituloArchived = T001X3_A314TituloArchived[0];
               Z263TituloVencimento = T001X3_A263TituloVencimento[0];
               Z286TituloCompetenciaAno = T001X3_A286TituloCompetenciaAno[0];
               Z287TituloCompetenciaMes = T001X3_A287TituloCompetenciaMes[0];
               Z264TituloProrrogacao = T001X3_A264TituloProrrogacao[0];
               Z265TituloCEP = T001X3_A265TituloCEP[0];
               Z266TituloLogradouro = T001X3_A266TituloLogradouro[0];
               Z294TituloNumeroEndereco = T001X3_A294TituloNumeroEndereco[0];
               Z267TituloComplemento = T001X3_A267TituloComplemento[0];
               Z268TituloBairro = T001X3_A268TituloBairro[0];
               Z269TituloMunicipio = T001X3_A269TituloMunicipio[0];
               Z498TituloJurosMora = T001X3_A498TituloJurosMora[0];
               Z283TituloTipo = T001X3_A283TituloTipo[0];
               Z500TituloCriacao = T001X3_A500TituloCriacao[0];
               Z422ContaId = T001X3_A422ContaId[0];
               Z426CategoriaTituloId = T001X3_A426CategoriaTituloId[0];
               Z419TituloPropostaId = T001X3_A419TituloPropostaId[0];
            }
            else
            {
               Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
               Z262TituloValor = A262TituloValor;
               Z276TituloDesconto = A276TituloDesconto;
               Z284TituloDeleted = A284TituloDeleted;
               Z314TituloArchived = A314TituloArchived;
               Z263TituloVencimento = A263TituloVencimento;
               Z286TituloCompetenciaAno = A286TituloCompetenciaAno;
               Z287TituloCompetenciaMes = A287TituloCompetenciaMes;
               Z264TituloProrrogacao = A264TituloProrrogacao;
               Z265TituloCEP = A265TituloCEP;
               Z266TituloLogradouro = A266TituloLogradouro;
               Z294TituloNumeroEndereco = A294TituloNumeroEndereco;
               Z267TituloComplemento = A267TituloComplemento;
               Z268TituloBairro = A268TituloBairro;
               Z269TituloMunicipio = A269TituloMunicipio;
               Z498TituloJurosMora = A498TituloJurosMora;
               Z283TituloTipo = A283TituloTipo;
               Z500TituloCriacao = A500TituloCriacao;
               Z422ContaId = A422ContaId;
               Z426CategoriaTituloId = A426CategoriaTituloId;
               Z419TituloPropostaId = A419TituloPropostaId;
            }
         }
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            Z168ClienteId = T001X9_A168ClienteId[0];
         }
         if ( GX_JID == -26 )
         {
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z261TituloId = A261TituloId;
            Z262TituloValor = A262TituloValor;
            Z276TituloDesconto = A276TituloDesconto;
            Z284TituloDeleted = A284TituloDeleted;
            Z314TituloArchived = A314TituloArchived;
            Z263TituloVencimento = A263TituloVencimento;
            Z286TituloCompetenciaAno = A286TituloCompetenciaAno;
            Z287TituloCompetenciaMes = A287TituloCompetenciaMes;
            Z264TituloProrrogacao = A264TituloProrrogacao;
            Z265TituloCEP = A265TituloCEP;
            Z266TituloLogradouro = A266TituloLogradouro;
            Z294TituloNumeroEndereco = A294TituloNumeroEndereco;
            Z267TituloComplemento = A267TituloComplemento;
            Z268TituloBairro = A268TituloBairro;
            Z269TituloMunicipio = A269TituloMunicipio;
            Z498TituloJurosMora = A498TituloJurosMora;
            Z283TituloTipo = A283TituloTipo;
            Z500TituloCriacao = A500TituloCriacao;
            Z422ContaId = A422ContaId;
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z419TituloPropostaId = A419TituloPropostaId;
            Z794NotaFiscalId = A794NotaFiscalId;
            Z168ClienteId = A168ClienteId;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         AV24Pgmname = "TituloProposta";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TituloId) )
         {
            A261TituloId = AV7TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
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
         if ( IsIns( )  && (false==A284TituloDeleted) && ( Gx_BScreen == 0 ) )
         {
            A284TituloDeleted = false;
            n284TituloDeleted = false;
            AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
         }
         if ( IsIns( )  && (DateTime.MinValue==A500TituloCriacao) && ( Gx_BScreen == 0 ) )
         {
            A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
            n500TituloCriacao = false;
            AssignAttri("", false, "A500TituloCriacao", context.localUtil.TToC( A500TituloCriacao, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001X12 */
            pr_default.execute(9, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               A273TituloTotalMovimento_F = T001X12_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = T001X12_n273TituloTotalMovimento_F[0];
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            else
            {
               A273TituloTotalMovimento_F = 0;
               n273TituloTotalMovimento_F = false;
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            pr_default.close(9);
            /* Using cursor T001X14 */
            pr_default.execute(10, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               A301TituloTotalMultaJuros_F = T001X14_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = T001X14_n301TituloTotalMultaJuros_F[0];
            }
            else
            {
               A301TituloTotalMultaJuros_F = 0;
               n301TituloTotalMultaJuros_F = false;
               AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
            }
            pr_default.close(10);
         }
      }

      protected void Load1X44( )
      {
         /* Using cursor T001X17 */
         pr_default.execute(11, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound44 = 1;
            A890NotaFiscalParcelamentoID = T001X17_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T001X17_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = T001X17_A794NotaFiscalId[0];
            n794NotaFiscalId = T001X17_n794NotaFiscalId[0];
            A170ClienteRazaoSocial = T001X17_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T001X17_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A262TituloValor = T001X17_A262TituloValor[0];
            n262TituloValor = T001X17_n262TituloValor[0];
            AssignAttri("", false, "A262TituloValor", ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            A276TituloDesconto = T001X17_A276TituloDesconto[0];
            n276TituloDesconto = T001X17_n276TituloDesconto[0];
            AssignAttri("", false, "A276TituloDesconto", ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
            A284TituloDeleted = T001X17_A284TituloDeleted[0];
            n284TituloDeleted = T001X17_n284TituloDeleted[0];
            AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
            A314TituloArchived = T001X17_A314TituloArchived[0];
            n314TituloArchived = T001X17_n314TituloArchived[0];
            A263TituloVencimento = T001X17_A263TituloVencimento[0];
            n263TituloVencimento = T001X17_n263TituloVencimento[0];
            AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
            A286TituloCompetenciaAno = T001X17_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = T001X17_n286TituloCompetenciaAno[0];
            AssignAttri("", false, "A286TituloCompetenciaAno", ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            A287TituloCompetenciaMes = T001X17_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = T001X17_n287TituloCompetenciaMes[0];
            AssignAttri("", false, "A287TituloCompetenciaMes", ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            A264TituloProrrogacao = T001X17_A264TituloProrrogacao[0];
            n264TituloProrrogacao = T001X17_n264TituloProrrogacao[0];
            AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
            A265TituloCEP = T001X17_A265TituloCEP[0];
            n265TituloCEP = T001X17_n265TituloCEP[0];
            AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
            A266TituloLogradouro = T001X17_A266TituloLogradouro[0];
            n266TituloLogradouro = T001X17_n266TituloLogradouro[0];
            AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
            A294TituloNumeroEndereco = T001X17_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = T001X17_n294TituloNumeroEndereco[0];
            AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
            A267TituloComplemento = T001X17_A267TituloComplemento[0];
            n267TituloComplemento = T001X17_n267TituloComplemento[0];
            AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
            A268TituloBairro = T001X17_A268TituloBairro[0];
            n268TituloBairro = T001X17_n268TituloBairro[0];
            AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
            A269TituloMunicipio = T001X17_A269TituloMunicipio[0];
            n269TituloMunicipio = T001X17_n269TituloMunicipio[0];
            AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
            A498TituloJurosMora = T001X17_A498TituloJurosMora[0];
            n498TituloJurosMora = T001X17_n498TituloJurosMora[0];
            A283TituloTipo = T001X17_A283TituloTipo[0];
            n283TituloTipo = T001X17_n283TituloTipo[0];
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A501PropostaTaxaAdministrativa = T001X17_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = T001X17_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = T001X17_A500TituloCriacao[0];
            n500TituloCriacao = T001X17_n500TituloCriacao[0];
            A422ContaId = T001X17_A422ContaId[0];
            n422ContaId = T001X17_n422ContaId[0];
            A426CategoriaTituloId = T001X17_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T001X17_n426CategoriaTituloId[0];
            A419TituloPropostaId = T001X17_A419TituloPropostaId[0];
            n419TituloPropostaId = T001X17_n419TituloPropostaId[0];
            A168ClienteId = T001X17_A168ClienteId[0];
            n168ClienteId = T001X17_n168ClienteId[0];
            A273TituloTotalMovimento_F = T001X17_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001X17_n273TituloTotalMovimento_F[0];
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            A301TituloTotalMultaJuros_F = T001X17_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001X17_n301TituloTotalMultaJuros_F[0];
            ZM1X44( -26) ;
         }
         pr_default.close(11);
         OnLoadActions1X44( ) ;
      }

      protected void OnLoadActions1X44( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_TituloPropostaId) )
         {
            A419TituloPropostaId = AV20Insert_TituloPropostaId;
            n419TituloPropostaId = false;
            AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A419TituloPropostaId) )
            {
               A419TituloPropostaId = 0;
               n419TituloPropostaId = false;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
               n419TituloPropostaId = true;
               n419TituloPropostaId = true;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_ContaId) )
         {
            A422ContaId = AV21Insert_ContaId;
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A422ContaId) )
            {
               A422ContaId = 0;
               n422ContaId = false;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
               n422ContaId = true;
               n422ContaId = true;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_CategoriaTituloId) )
         {
            A426CategoriaTituloId = AV22Insert_CategoriaTituloId;
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A426CategoriaTituloId) )
            {
               A426CategoriaTituloId = 0;
               n426CategoriaTituloId = false;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
               n426CategoriaTituloId = true;
               n426CategoriaTituloId = true;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            }
         }
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A168ClienteId = AV11Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
      }

      protected void CheckExtendedTable1X44( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_TituloPropostaId) )
         {
            A419TituloPropostaId = AV20Insert_TituloPropostaId;
            n419TituloPropostaId = false;
            AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A419TituloPropostaId) )
            {
               A419TituloPropostaId = 0;
               n419TituloPropostaId = false;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
               n419TituloPropostaId = true;
               n419TituloPropostaId = true;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_ContaId) )
         {
            A422ContaId = AV21Insert_ContaId;
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A422ContaId) )
            {
               A422ContaId = 0;
               n422ContaId = false;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
               n422ContaId = true;
               n422ContaId = true;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_CategoriaTituloId) )
         {
            A426CategoriaTituloId = AV22Insert_CategoriaTituloId;
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A426CategoriaTituloId) )
            {
               A426CategoriaTituloId = 0;
               n426CategoriaTituloId = false;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
               n426CategoriaTituloId = true;
               n426CategoriaTituloId = true;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            }
         }
         /* Using cursor T001X12 */
         pr_default.execute(9, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A273TituloTotalMovimento_F = T001X12_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001X12_n273TituloTotalMovimento_F[0];
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         pr_default.close(9);
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
         /* Using cursor T001X14 */
         pr_default.execute(10, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A301TituloTotalMultaJuros_F = T001X14_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001X14_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
            AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
         }
         pr_default.close(10);
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         if ( ( A262TituloValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "TITULOVALOR");
            AnyError = 1;
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
         if ( ! ( ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) || ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ) )
         {
            GX_msglist.addItem("Campo Titulo Tipo fora do intervalo", "OutOfRange", 1, "TITULOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbTituloTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001X6 */
         pr_default.execute(4, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A890NotaFiscalParcelamentoID) ) )
            {
               GX_msglist.addItem("Não existe 'Nota Fiscal Parcelamento'.", "ForeignKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
               AnyError = 1;
            }
         }
         A794NotaFiscalId = T001X6_A794NotaFiscalId[0];
         n794NotaFiscalId = T001X6_n794NotaFiscalId[0];
         pr_default.close(4);
         /* Using cursor T001X9 */
         pr_default.execute(7, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A168ClienteId = T001X9_A168ClienteId[0];
         n168ClienteId = T001X9_n168ClienteId[0];
         pr_default.close(7);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A168ClienteId = AV11Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         /* Using cursor T001X10 */
         pr_default.execute(8, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         A170ClienteRazaoSocial = T001X10_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T001X10_n170ClienteRazaoSocial[0];
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         pr_default.close(8);
         /* Using cursor T001X4 */
         pr_default.execute(2, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A422ContaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta'.", "ForeignKeyNotFound", 1, "CONTAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor T001X5 */
         pr_default.execute(3, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A426CategoriaTituloId) ) )
            {
               GX_msglist.addItem("Não existe 'CategoriaTitulo'.", "ForeignKeyNotFound", 1, "CATEGORIATITULOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor T001X7 */
         pr_default.execute(5, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A419TituloPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Proposta Id'.", "ForeignKeyNotFound", 1, "TITULOPROPOSTAID");
               AnyError = 1;
            }
         }
         A501PropostaTaxaAdministrativa = T001X7_A501PropostaTaxaAdministrativa[0];
         n501PropostaTaxaAdministrativa = T001X7_n501PropostaTaxaAdministrativa[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1X44( )
      {
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(8);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_33( int A261TituloId )
      {
         /* Using cursor T001X19 */
         pr_default.execute(12, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A273TituloTotalMovimento_F = T001X19_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001X19_n273TituloTotalMovimento_F[0];
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_34( int A261TituloId )
      {
         /* Using cursor T001X21 */
         pr_default.execute(13, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A301TituloTotalMultaJuros_F = T001X21_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001X21_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
            AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_29( Guid A890NotaFiscalParcelamentoID )
      {
         /* Using cursor T001X22 */
         pr_default.execute(14, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (Guid.Empty==A890NotaFiscalParcelamentoID) ) )
            {
               GX_msglist.addItem("Não existe 'Nota Fiscal Parcelamento'.", "ForeignKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
               AnyError = 1;
            }
         }
         A794NotaFiscalId = T001X22_A794NotaFiscalId[0];
         n794NotaFiscalId = T001X22_n794NotaFiscalId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A794NotaFiscalId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_31( Guid A794NotaFiscalId )
      {
         /* Using cursor T001X9 */
         pr_default.execute(7, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A168ClienteId = T001X9_A168ClienteId[0];
         n168ClienteId = T001X9_n168ClienteId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_32( int A168ClienteId )
      {
         /* Using cursor T001X23 */
         pr_default.execute(15, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         A170ClienteRazaoSocial = T001X23_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T001X23_n170ClienteRazaoSocial[0];
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A170ClienteRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_27( int A422ContaId )
      {
         /* Using cursor T001X24 */
         pr_default.execute(16, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A422ContaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta'.", "ForeignKeyNotFound", 1, "CONTAID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_28( int A426CategoriaTituloId )
      {
         /* Using cursor T001X25 */
         pr_default.execute(17, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A426CategoriaTituloId) ) )
            {
               GX_msglist.addItem("Não existe 'CategoriaTitulo'.", "ForeignKeyNotFound", 1, "CATEGORIATITULOID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_30( int A419TituloPropostaId )
      {
         /* Using cursor T001X26 */
         pr_default.execute(18, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A419TituloPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Proposta Id'.", "ForeignKeyNotFound", 1, "TITULOPROPOSTAID");
               AnyError = 1;
            }
         }
         A501PropostaTaxaAdministrativa = T001X26_A501PropostaTaxaAdministrativa[0];
         n501PropostaTaxaAdministrativa = T001X26_n501PropostaTaxaAdministrativa[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 16, 4, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey1X44( )
      {
         /* Using cursor T001X27 */
         pr_default.execute(19, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001X3 */
         pr_default.execute(1, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1X44( 26) ;
            RcdFound44 = 1;
            A890NotaFiscalParcelamentoID = T001X3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T001X3_n890NotaFiscalParcelamentoID[0];
            A261TituloId = T001X3_A261TituloId[0];
            n261TituloId = T001X3_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            A262TituloValor = T001X3_A262TituloValor[0];
            n262TituloValor = T001X3_n262TituloValor[0];
            AssignAttri("", false, "A262TituloValor", ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            A276TituloDesconto = T001X3_A276TituloDesconto[0];
            n276TituloDesconto = T001X3_n276TituloDesconto[0];
            AssignAttri("", false, "A276TituloDesconto", ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
            A284TituloDeleted = T001X3_A284TituloDeleted[0];
            n284TituloDeleted = T001X3_n284TituloDeleted[0];
            AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
            A314TituloArchived = T001X3_A314TituloArchived[0];
            n314TituloArchived = T001X3_n314TituloArchived[0];
            A263TituloVencimento = T001X3_A263TituloVencimento[0];
            n263TituloVencimento = T001X3_n263TituloVencimento[0];
            AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
            A286TituloCompetenciaAno = T001X3_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = T001X3_n286TituloCompetenciaAno[0];
            AssignAttri("", false, "A286TituloCompetenciaAno", ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            A287TituloCompetenciaMes = T001X3_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = T001X3_n287TituloCompetenciaMes[0];
            AssignAttri("", false, "A287TituloCompetenciaMes", ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            A264TituloProrrogacao = T001X3_A264TituloProrrogacao[0];
            n264TituloProrrogacao = T001X3_n264TituloProrrogacao[0];
            AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
            A265TituloCEP = T001X3_A265TituloCEP[0];
            n265TituloCEP = T001X3_n265TituloCEP[0];
            AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
            A266TituloLogradouro = T001X3_A266TituloLogradouro[0];
            n266TituloLogradouro = T001X3_n266TituloLogradouro[0];
            AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
            A294TituloNumeroEndereco = T001X3_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = T001X3_n294TituloNumeroEndereco[0];
            AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
            A267TituloComplemento = T001X3_A267TituloComplemento[0];
            n267TituloComplemento = T001X3_n267TituloComplemento[0];
            AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
            A268TituloBairro = T001X3_A268TituloBairro[0];
            n268TituloBairro = T001X3_n268TituloBairro[0];
            AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
            A269TituloMunicipio = T001X3_A269TituloMunicipio[0];
            n269TituloMunicipio = T001X3_n269TituloMunicipio[0];
            AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
            A498TituloJurosMora = T001X3_A498TituloJurosMora[0];
            n498TituloJurosMora = T001X3_n498TituloJurosMora[0];
            A283TituloTipo = T001X3_A283TituloTipo[0];
            n283TituloTipo = T001X3_n283TituloTipo[0];
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A500TituloCriacao = T001X3_A500TituloCriacao[0];
            n500TituloCriacao = T001X3_n500TituloCriacao[0];
            A422ContaId = T001X3_A422ContaId[0];
            n422ContaId = T001X3_n422ContaId[0];
            A426CategoriaTituloId = T001X3_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T001X3_n426CategoriaTituloId[0];
            A419TituloPropostaId = T001X3_A419TituloPropostaId[0];
            n419TituloPropostaId = T001X3_n419TituloPropostaId[0];
            Z261TituloId = A261TituloId;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1X44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1X44( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1X44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1X44( ) ;
         if ( RcdFound44 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound44 = 0;
         /* Using cursor T001X28 */
         pr_default.execute(20, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            while ( (pr_default.getStatus(20) != 101) && ( ( T001X28_A261TituloId[0] < A261TituloId ) ) )
            {
               pr_default.readNext(20);
            }
            if ( (pr_default.getStatus(20) != 101) && ( ( T001X28_A261TituloId[0] > A261TituloId ) ) )
            {
               A261TituloId = T001X28_A261TituloId[0];
               n261TituloId = T001X28_n261TituloId[0];
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               RcdFound44 = 1;
            }
         }
         pr_default.close(20);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T001X29 */
         pr_default.execute(21, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            while ( (pr_default.getStatus(21) != 101) && ( ( T001X29_A261TituloId[0] > A261TituloId ) ) )
            {
               pr_default.readNext(21);
            }
            if ( (pr_default.getStatus(21) != 101) && ( ( T001X29_A261TituloId[0] < A261TituloId ) ) )
            {
               A261TituloId = T001X29_A261TituloId[0];
               n261TituloId = T001X29_n261TituloId[0];
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               RcdFound44 = 1;
            }
         }
         pr_default.close(21);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1X44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1X44( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( A261TituloId != Z261TituloId )
               {
                  A261TituloId = Z261TituloId;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TITULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTituloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1X44( ) ;
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A261TituloId != Z261TituloId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1X44( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TITULOID");
                     AnyError = 1;
                     GX_FocusControl = edtTituloId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTituloValor_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1X44( ) ;
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
         if ( A261TituloId != Z261TituloId )
         {
            A261TituloId = Z261TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TITULOID");
            AnyError = 1;
            GX_FocusControl = edtTituloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1X44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001X2 */
            pr_default.execute(0, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z890NotaFiscalParcelamentoID != T001X2_A890NotaFiscalParcelamentoID[0] ) || ( Z262TituloValor != T001X2_A262TituloValor[0] ) || ( Z276TituloDesconto != T001X2_A276TituloDesconto[0] ) || ( Z284TituloDeleted != T001X2_A284TituloDeleted[0] ) || ( Z314TituloArchived != T001X2_A314TituloArchived[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z263TituloVencimento ) != DateTimeUtil.ResetTime ( T001X2_A263TituloVencimento[0] ) ) || ( Z286TituloCompetenciaAno != T001X2_A286TituloCompetenciaAno[0] ) || ( Z287TituloCompetenciaMes != T001X2_A287TituloCompetenciaMes[0] ) || ( DateTimeUtil.ResetTime ( Z264TituloProrrogacao ) != DateTimeUtil.ResetTime ( T001X2_A264TituloProrrogacao[0] ) ) || ( StringUtil.StrCmp(Z265TituloCEP, T001X2_A265TituloCEP[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z266TituloLogradouro, T001X2_A266TituloLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z294TituloNumeroEndereco, T001X2_A294TituloNumeroEndereco[0]) != 0 ) || ( StringUtil.StrCmp(Z267TituloComplemento, T001X2_A267TituloComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z268TituloBairro, T001X2_A268TituloBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z269TituloMunicipio, T001X2_A269TituloMunicipio[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z498TituloJurosMora != T001X2_A498TituloJurosMora[0] ) || ( StringUtil.StrCmp(Z283TituloTipo, T001X2_A283TituloTipo[0]) != 0 ) || ( Z500TituloCriacao != T001X2_A500TituloCriacao[0] ) || ( Z422ContaId != T001X2_A422ContaId[0] ) || ( Z426CategoriaTituloId != T001X2_A426CategoriaTituloId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z419TituloPropostaId != T001X2_A419TituloPropostaId[0] ) )
            {
               if ( Z890NotaFiscalParcelamentoID != T001X2_A890NotaFiscalParcelamentoID[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"NotaFiscalParcelamentoID");
                  GXUtil.WriteLogRaw("Old: ",Z890NotaFiscalParcelamentoID);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A890NotaFiscalParcelamentoID[0]);
               }
               if ( Z262TituloValor != T001X2_A262TituloValor[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloValor");
                  GXUtil.WriteLogRaw("Old: ",Z262TituloValor);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A262TituloValor[0]);
               }
               if ( Z276TituloDesconto != T001X2_A276TituloDesconto[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloDesconto");
                  GXUtil.WriteLogRaw("Old: ",Z276TituloDesconto);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A276TituloDesconto[0]);
               }
               if ( Z284TituloDeleted != T001X2_A284TituloDeleted[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z284TituloDeleted);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A284TituloDeleted[0]);
               }
               if ( Z314TituloArchived != T001X2_A314TituloArchived[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloArchived");
                  GXUtil.WriteLogRaw("Old: ",Z314TituloArchived);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A314TituloArchived[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z263TituloVencimento ) != DateTimeUtil.ResetTime ( T001X2_A263TituloVencimento[0] ) )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloVencimento");
                  GXUtil.WriteLogRaw("Old: ",Z263TituloVencimento);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A263TituloVencimento[0]);
               }
               if ( Z286TituloCompetenciaAno != T001X2_A286TituloCompetenciaAno[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloCompetenciaAno");
                  GXUtil.WriteLogRaw("Old: ",Z286TituloCompetenciaAno);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A286TituloCompetenciaAno[0]);
               }
               if ( Z287TituloCompetenciaMes != T001X2_A287TituloCompetenciaMes[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloCompetenciaMes");
                  GXUtil.WriteLogRaw("Old: ",Z287TituloCompetenciaMes);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A287TituloCompetenciaMes[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z264TituloProrrogacao ) != DateTimeUtil.ResetTime ( T001X2_A264TituloProrrogacao[0] ) )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloProrrogacao");
                  GXUtil.WriteLogRaw("Old: ",Z264TituloProrrogacao);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A264TituloProrrogacao[0]);
               }
               if ( StringUtil.StrCmp(Z265TituloCEP, T001X2_A265TituloCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloCEP");
                  GXUtil.WriteLogRaw("Old: ",Z265TituloCEP);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A265TituloCEP[0]);
               }
               if ( StringUtil.StrCmp(Z266TituloLogradouro, T001X2_A266TituloLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z266TituloLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A266TituloLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z294TituloNumeroEndereco, T001X2_A294TituloNumeroEndereco[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloNumeroEndereco");
                  GXUtil.WriteLogRaw("Old: ",Z294TituloNumeroEndereco);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A294TituloNumeroEndereco[0]);
               }
               if ( StringUtil.StrCmp(Z267TituloComplemento, T001X2_A267TituloComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z267TituloComplemento);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A267TituloComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z268TituloBairro, T001X2_A268TituloBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloBairro");
                  GXUtil.WriteLogRaw("Old: ",Z268TituloBairro);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A268TituloBairro[0]);
               }
               if ( StringUtil.StrCmp(Z269TituloMunicipio, T001X2_A269TituloMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z269TituloMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A269TituloMunicipio[0]);
               }
               if ( Z498TituloJurosMora != T001X2_A498TituloJurosMora[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloJurosMora");
                  GXUtil.WriteLogRaw("Old: ",Z498TituloJurosMora);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A498TituloJurosMora[0]);
               }
               if ( StringUtil.StrCmp(Z283TituloTipo, T001X2_A283TituloTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloTipo");
                  GXUtil.WriteLogRaw("Old: ",Z283TituloTipo);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A283TituloTipo[0]);
               }
               if ( Z500TituloCriacao != T001X2_A500TituloCriacao[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloCriacao");
                  GXUtil.WriteLogRaw("Old: ",Z500TituloCriacao);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A500TituloCriacao[0]);
               }
               if ( Z422ContaId != T001X2_A422ContaId[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"ContaId");
                  GXUtil.WriteLogRaw("Old: ",Z422ContaId);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A422ContaId[0]);
               }
               if ( Z426CategoriaTituloId != T001X2_A426CategoriaTituloId[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"CategoriaTituloId");
                  GXUtil.WriteLogRaw("Old: ",Z426CategoriaTituloId);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A426CategoriaTituloId[0]);
               }
               if ( Z419TituloPropostaId != T001X2_A419TituloPropostaId[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"TituloPropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z419TituloPropostaId);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A419TituloPropostaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Titulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T001X30 */
         pr_default.execute(22, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(22) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscal"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( Z168ClienteId != T001X30_A168ClienteId[0] ) )
            {
               if ( Z168ClienteId != T001X30_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("tituloproposta:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T001X30_A168ClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscal"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X44( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X44( 0) ;
            CheckOptimisticConcurrency1X44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001X31 */
                     pr_default.execute(23, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n419TituloPropostaId, A419TituloPropostaId});
                     pr_default.close(23);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001X32 */
                     pr_default.execute(24);
                     A261TituloId = T001X32_A261TituloId[0];
                     n261TituloId = T001X32_n261TituloId[0];
                     AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11X44( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1X0( ) ;
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
               Load1X44( ) ;
            }
            EndLevel1X44( ) ;
         }
         CloseExtendedTableCursors1X44( ) ;
      }

      protected void Update1X44( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1X44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001X33 */
                     pr_default.execute(25, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n419TituloPropostaId, A419TituloPropostaId, n261TituloId, A261TituloId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1X44( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11X44( ) ;
                        /* Start of After( update) rules */
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
            EndLevel1X44( ) ;
         }
         CloseExtendedTableCursors1X44( ) ;
      }

      protected void DeferredUpdate1X44( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X44( ) ;
            AfterConfirm1X44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X44( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001X34 */
                  pr_default.execute(26, new Object[] {n261TituloId, A261TituloId});
                  pr_default.close(26);
                  pr_default.SmartCacheProvider.SetUpdated("Titulo");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN11X44( ) ;
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1X44( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1X44( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001X36 */
            pr_default.execute(27, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               A273TituloTotalMovimento_F = T001X36_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = T001X36_n273TituloTotalMovimento_F[0];
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            else
            {
               A273TituloTotalMovimento_F = 0;
               n273TituloTotalMovimento_F = false;
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            pr_default.close(27);
            /* Using cursor T001X38 */
            pr_default.execute(28, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               A301TituloTotalMultaJuros_F = T001X38_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = T001X38_n301TituloTotalMultaJuros_F[0];
            }
            else
            {
               A301TituloTotalMultaJuros_F = 0;
               n301TituloTotalMultaJuros_F = false;
               AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
            }
            pr_default.close(28);
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
            A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
            AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
            A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
            A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
            A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
            A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
            A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
            A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
            /* Using cursor T001X39 */
            pr_default.execute(29, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            A794NotaFiscalId = T001X39_A794NotaFiscalId[0];
            n794NotaFiscalId = T001X39_n794NotaFiscalId[0];
            pr_default.close(29);
            /* Using cursor T001X40 */
            pr_default.execute(30, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            Z168ClienteId = T001X40_A168ClienteId[0];
            A168ClienteId = T001X40_A168ClienteId[0];
            n168ClienteId = T001X40_n168ClienteId[0];
            pr_default.close(30);
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
            {
               A168ClienteId = AV11Insert_ClienteId;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            /* Using cursor T001X41 */
            pr_default.execute(31, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = T001X41_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T001X41_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            pr_default.close(31);
            /* Using cursor T001X42 */
            pr_default.execute(32, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
            A501PropostaTaxaAdministrativa = T001X42_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = T001X42_n501PropostaTaxaAdministrativa[0];
            pr_default.close(32);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001X43 */
            pr_default.execute(33, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Boleto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T001X44 */
            pr_default.execute(34, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
         }
      }

      protected void UpdateTablesN11X44( )
      {
         /* Using cursor T001X45 */
         pr_default.execute(35, new Object[] {n168ClienteId, A168ClienteId, n794NotaFiscalId, A794NotaFiscalId});
         pr_default.close(35);
         pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
      }

      protected void EndLevel1X44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(22);
         if ( AnyError == 0 )
         {
            BeforeComplete1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("tituloproposta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("tituloproposta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1X44( )
      {
         /* Scan By routine */
         /* Using cursor T001X46 */
         pr_default.execute(36);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound44 = 1;
            A261TituloId = T001X46_A261TituloId[0];
            n261TituloId = T001X46_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1X44( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound44 = 1;
            A261TituloId = T001X46_A261TituloId[0];
            n261TituloId = T001X46_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         }
      }

      protected void ScanEnd1X44( )
      {
         pr_default.close(36);
      }

      protected void AfterConfirm1X44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X44( )
      {
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         edtClienteRazaoSocial_Enabled = 0;
         AssignProp("", false, edtClienteRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Enabled), 5, 0), true);
         edtTituloValor_Enabled = 0;
         AssignProp("", false, edtTituloValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloValor_Enabled), 5, 0), true);
         edtTituloDesconto_Enabled = 0;
         AssignProp("", false, edtTituloDesconto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloDesconto_Enabled), 5, 0), true);
         edtTituloProrrogacao_Enabled = 0;
         AssignProp("", false, edtTituloProrrogacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloProrrogacao_Enabled), 5, 0), true);
         edtTituloCompetencia_F_Enabled = 0;
         AssignProp("", false, edtTituloCompetencia_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCompetencia_F_Enabled), 5, 0), true);
         edtTituloStatus_F_Enabled = 0;
         AssignProp("", false, edtTituloStatus_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloStatus_F_Enabled), 5, 0), true);
         cmbTituloTipo.Enabled = 0;
         AssignProp("", false, cmbTituloTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTituloTipo.Enabled), 5, 0), true);
         edtTituloSaldo_F_Enabled = 0;
         AssignProp("", false, edtTituloSaldo_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloSaldo_F_Enabled), 5, 0), true);
         edtTituloTotalMovimento_F_Enabled = 0;
         AssignProp("", false, edtTituloTotalMovimento_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloTotalMovimento_F_Enabled), 5, 0), true);
         edtTituloCEP_Enabled = 0;
         AssignProp("", false, edtTituloCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCEP_Enabled), 5, 0), true);
         edtTituloLogradouro_Enabled = 0;
         AssignProp("", false, edtTituloLogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloLogradouro_Enabled), 5, 0), true);
         edtTituloNumeroEndereco_Enabled = 0;
         AssignProp("", false, edtTituloNumeroEndereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloNumeroEndereco_Enabled), 5, 0), true);
         edtTituloComplemento_Enabled = 0;
         AssignProp("", false, edtTituloComplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloComplemento_Enabled), 5, 0), true);
         edtTituloBairro_Enabled = 0;
         AssignProp("", false, edtTituloBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloBairro_Enabled), 5, 0), true);
         edtTituloMunicipio_Enabled = 0;
         AssignProp("", false, edtTituloMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMunicipio_Enabled), 5, 0), true);
         edtTituloDeleted_Enabled = 0;
         AssignProp("", false, edtTituloDeleted_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloDeleted_Enabled), 5, 0), true);
         edtTituloVencimento_Enabled = 0;
         AssignProp("", false, edtTituloVencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloVencimento_Enabled), 5, 0), true);
         edtTituloCompetenciaAno_Enabled = 0;
         AssignProp("", false, edtTituloCompetenciaAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaAno_Enabled), 5, 0), true);
         edtTituloCompetenciaMes_Enabled = 0;
         AssignProp("", false, edtTituloCompetenciaMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaMes_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1X44( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1X0( )
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
         GXEncryptionTmp = "tituloproposta"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TituloId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("tituloproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TituloProposta");
         forbiddenHiddens.Add("TituloId", context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TituloPropostaId", context.localUtil.Format( (decimal)(AV20Insert_TituloPropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContaId", context.localUtil.Format( (decimal)(AV21Insert_ContaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_CategoriaTituloId", context.localUtil.Format( (decimal)(AV22Insert_CategoriaTituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("TituloArchived", StringUtil.BoolToStr( A314TituloArchived));
         forbiddenHiddens.Add("TituloJurosMora", context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("TituloCriacao", context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tituloproposta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z261TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z261TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z890NotaFiscalParcelamentoID", Z890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "Z262TituloValor", StringUtil.LTrim( StringUtil.NToC( Z262TituloValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z276TituloDesconto", StringUtil.LTrim( StringUtil.NToC( Z276TituloDesconto, 18, 2, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z284TituloDeleted", Z284TituloDeleted);
         GxWebStd.gx_boolean_hidden_field( context, "Z314TituloArchived", Z314TituloArchived);
         GxWebStd.gx_hidden_field( context, "Z263TituloVencimento", context.localUtil.DToC( Z263TituloVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z286TituloCompetenciaAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z286TituloCompetenciaAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z287TituloCompetenciaMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z287TituloCompetenciaMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z264TituloProrrogacao", context.localUtil.DToC( Z264TituloProrrogacao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z265TituloCEP", Z265TituloCEP);
         GxWebStd.gx_hidden_field( context, "Z266TituloLogradouro", Z266TituloLogradouro);
         GxWebStd.gx_hidden_field( context, "Z294TituloNumeroEndereco", Z294TituloNumeroEndereco);
         GxWebStd.gx_hidden_field( context, "Z267TituloComplemento", Z267TituloComplemento);
         GxWebStd.gx_hidden_field( context, "Z268TituloBairro", Z268TituloBairro);
         GxWebStd.gx_hidden_field( context, "Z269TituloMunicipio", Z269TituloMunicipio);
         GxWebStd.gx_hidden_field( context, "Z498TituloJurosMora", StringUtil.LTrim( StringUtil.NToC( Z498TituloJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z283TituloTipo", Z283TituloTipo);
         GxWebStd.gx_hidden_field( context, "Z500TituloCriacao", context.localUtil.TToC( Z500TituloCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z422ContaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z426CategoriaTituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z419TituloPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z419TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N419TituloPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N422ContaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N426CategoriaTituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "TITULOSALDOCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A303TituloSaldoCredito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOSALDODEBITO_F", StringUtil.LTrim( StringUtil.NToC( A302TituloSaldoDebito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMULTAJUROSCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A307TituloTotalMultaJurosCredito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMULTAJUROSDEBITO_F", StringUtil.LTrim( StringUtil.NToC( A306TituloTotalMultaJurosDebito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMOVIMENTOCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A305TituloTotalMovimentoCredito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMOVIMENTODEBITO_F", StringUtil.LTrim( StringUtil.NToC( A304TituloTotalMovimentoDebito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TITULOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21Insert_ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOCRIACAO", context.localUtil.TToC( A500TituloCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOID", A890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "TITULOARCHIVED", A314TituloArchived);
         GxWebStd.gx_hidden_field( context, "TITULOJUROSMORA", StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALID", A794NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "PROPOSTATAXAADMINISTRATIVA", StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMULTAJUROS_F", StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
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
         if ( ! ( WebComp_Wctitulomovimentoww == null ) )
         {
            WebComp_Wctitulomovimentoww.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
               {
                  WebComp_Wctitulomovimentoww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
               {
                  WebComp_Wctitulomovimentoww.componentstart();
               }
            }
         }
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
         GXEncryptionTmp = "tituloproposta"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TituloId,9,0));
         return formatLink("tituloproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "TituloProposta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Titulo Proposta" ;
      }

      protected void InitializeNonKey1X44( )
      {
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         A890NotaFiscalParcelamentoID = Guid.Empty;
         n890NotaFiscalParcelamentoID = false;
         AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         A419TituloPropostaId = 0;
         n419TituloPropostaId = false;
         AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
         A422ContaId = 0;
         n422ContaId = false;
         AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
         A426CategoriaTituloId = 0;
         n426CategoriaTituloId = false;
         AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
         A304TituloTotalMovimentoDebito_F = 0;
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         A305TituloTotalMovimentoCredito_F = 0;
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         A306TituloTotalMultaJurosDebito_F = 0;
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         A307TituloTotalMultaJurosCredito_F = 0;
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         A295TituloCompetencia_F = "";
         AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
         A275TituloSaldo_F = 0;
         AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
         A282TituloStatus_F = "";
         AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
         A302TituloSaldoDebito_F = 0;
         AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
         A303TituloSaldoCredito_F = 0;
         AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         A262TituloValor = 0;
         n262TituloValor = false;
         AssignAttri("", false, "A262TituloValor", ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
         n262TituloValor = ((Convert.ToDecimal(0)==A262TituloValor) ? true : false);
         A276TituloDesconto = 0;
         n276TituloDesconto = false;
         AssignAttri("", false, "A276TituloDesconto", ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
         n276TituloDesconto = ((Convert.ToDecimal(0)==A276TituloDesconto) ? true : false);
         A314TituloArchived = false;
         n314TituloArchived = false;
         AssignAttri("", false, "A314TituloArchived", A314TituloArchived);
         A263TituloVencimento = DateTime.MinValue;
         n263TituloVencimento = false;
         AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
         n263TituloVencimento = ((DateTime.MinValue==A263TituloVencimento) ? true : false);
         A286TituloCompetenciaAno = 0;
         n286TituloCompetenciaAno = false;
         AssignAttri("", false, "A286TituloCompetenciaAno", ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
         n286TituloCompetenciaAno = ((0==A286TituloCompetenciaAno) ? true : false);
         A287TituloCompetenciaMes = 0;
         n287TituloCompetenciaMes = false;
         AssignAttri("", false, "A287TituloCompetenciaMes", ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
         n287TituloCompetenciaMes = ((0==A287TituloCompetenciaMes) ? true : false);
         A264TituloProrrogacao = DateTime.MinValue;
         n264TituloProrrogacao = false;
         AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
         n264TituloProrrogacao = ((DateTime.MinValue==A264TituloProrrogacao) ? true : false);
         A265TituloCEP = "";
         n265TituloCEP = false;
         AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
         n265TituloCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A265TituloCEP)) ? true : false);
         A266TituloLogradouro = "";
         n266TituloLogradouro = false;
         AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
         n266TituloLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A266TituloLogradouro)) ? true : false);
         A294TituloNumeroEndereco = "";
         n294TituloNumeroEndereco = false;
         AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
         n294TituloNumeroEndereco = (String.IsNullOrEmpty(StringUtil.RTrim( A294TituloNumeroEndereco)) ? true : false);
         A267TituloComplemento = "";
         n267TituloComplemento = false;
         AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
         n267TituloComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A267TituloComplemento)) ? true : false);
         A268TituloBairro = "";
         n268TituloBairro = false;
         AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
         n268TituloBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A268TituloBairro)) ? true : false);
         A269TituloMunicipio = "";
         n269TituloMunicipio = false;
         AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
         n269TituloMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A269TituloMunicipio)) ? true : false);
         A498TituloJurosMora = 0;
         n498TituloJurosMora = false;
         AssignAttri("", false, "A498TituloJurosMora", ((Convert.ToDecimal(0)==A498TituloJurosMora)&&IsIns( )||n498TituloJurosMora ? "" : StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 16, 4, ".", ""))));
         A283TituloTipo = "";
         n283TituloTipo = false;
         AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
         n283TituloTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ? true : false);
         A501PropostaTaxaAdministrativa = 0;
         n501PropostaTaxaAdministrativa = false;
         AssignAttri("", false, "A501PropostaTaxaAdministrativa", StringUtil.LTrimStr( A501PropostaTaxaAdministrativa, 16, 4));
         A273TituloTotalMovimento_F = 0;
         n273TituloTotalMovimento_F = false;
         AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         A301TituloTotalMultaJuros_F = 0;
         n301TituloTotalMultaJuros_F = false;
         AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         AssignAttri("", false, "A500TituloCriacao", context.localUtil.TToC( A500TituloCriacao, 8, 5, 0, 3, "/", ":", " "));
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         Z262TituloValor = 0;
         Z276TituloDesconto = 0;
         Z284TituloDeleted = false;
         Z314TituloArchived = false;
         Z263TituloVencimento = DateTime.MinValue;
         Z286TituloCompetenciaAno = 0;
         Z287TituloCompetenciaMes = 0;
         Z264TituloProrrogacao = DateTime.MinValue;
         Z265TituloCEP = "";
         Z266TituloLogradouro = "";
         Z294TituloNumeroEndereco = "";
         Z267TituloComplemento = "";
         Z268TituloBairro = "";
         Z269TituloMunicipio = "";
         Z498TituloJurosMora = 0;
         Z283TituloTipo = "";
         Z500TituloCriacao = (DateTime)(DateTime.MinValue);
         Z422ContaId = 0;
         Z426CategoriaTituloId = 0;
         Z419TituloPropostaId = 0;
         Z168ClienteId = 0;
      }

      protected void InitAll1X44( )
      {
         A261TituloId = 0;
         n261TituloId = false;
         AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         InitializeNonKey1X44( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A284TituloDeleted = i284TituloDeleted;
         n284TituloDeleted = false;
         AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
         A500TituloCriacao = i500TituloCriacao;
         n500TituloCriacao = false;
         AssignAttri("", false, "A500TituloCriacao", context.localUtil.TToC( A500TituloCriacao, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wctitulomovimentoww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
            {
               WebComp_Wctitulomovimentoww.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019182728", true, true);
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
         context.AddJavascriptSource("tituloproposta.js", "?202561019182730", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTituloId_Internalname = "TITULOID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtTituloValor_Internalname = "TITULOVALOR";
         edtTituloDesconto_Internalname = "TITULODESCONTO";
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO";
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F";
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F";
         cmbTituloTipo_Internalname = "TITULOTIPO";
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F";
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F";
         edtTituloCEP_Internalname = "TITULOCEP";
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO";
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO";
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO";
         edtTituloBairro_Internalname = "TITULOBAIRRO";
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO";
         divTableendereco_Internalname = "TABLEENDERECO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablemovimentos_Internalname = "TABLEMOVIMENTOS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTituloDeleted_Internalname = "TITULODELETED";
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO";
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO";
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES";
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
         Form.Caption = "Titulo Proposta";
         edtTituloCompetenciaMes_Jsonclick = "";
         edtTituloCompetenciaMes_Enabled = 1;
         edtTituloCompetenciaMes_Visible = 1;
         edtTituloCompetenciaAno_Jsonclick = "";
         edtTituloCompetenciaAno_Enabled = 1;
         edtTituloCompetenciaAno_Visible = 1;
         edtTituloVencimento_Jsonclick = "";
         edtTituloVencimento_Enabled = 1;
         edtTituloVencimento_Visible = 1;
         edtTituloDeleted_Jsonclick = "";
         edtTituloDeleted_Enabled = 1;
         edtTituloDeleted_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTituloMunicipio_Jsonclick = "";
         edtTituloMunicipio_Enabled = 1;
         edtTituloBairro_Jsonclick = "";
         edtTituloBairro_Enabled = 1;
         edtTituloComplemento_Jsonclick = "";
         edtTituloComplemento_Enabled = 1;
         edtTituloNumeroEndereco_Jsonclick = "";
         edtTituloNumeroEndereco_Enabled = 1;
         edtTituloLogradouro_Jsonclick = "";
         edtTituloLogradouro_Enabled = 1;
         edtTituloCEP_Jsonclick = "";
         edtTituloCEP_Enabled = 1;
         edtTituloTotalMovimento_F_Jsonclick = "";
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloSaldo_F_Jsonclick = "";
         edtTituloSaldo_F_Enabled = 0;
         cmbTituloTipo_Jsonclick = "";
         cmbTituloTipo.Enabled = 1;
         edtTituloStatus_F_Jsonclick = "";
         edtTituloStatus_F_Enabled = 0;
         edtTituloCompetencia_F_Jsonclick = "";
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloProrrogacao_Jsonclick = "";
         edtTituloProrrogacao_Enabled = 1;
         edtTituloDesconto_Jsonclick = "";
         edtTituloDesconto_Enabled = 1;
         edtTituloValor_Jsonclick = "";
         edtTituloValor_Enabled = 1;
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteRazaoSocial_Enabled = 0;
         edtTituloId_Jsonclick = "";
         edtTituloId_Enabled = 0;
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

      protected void GX9ASATITULOTOTALMULTAJUROSCREDITO_F1X44( string A283TituloTipo ,
                                                               int A261TituloId )
      {
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A307TituloTotalMultaJurosCredito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX10ASATITULOTOTALMULTAJUROSDEBITO_F1X44( string A283TituloTipo ,
                                                               int A261TituloId )
      {
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A306TituloTotalMultaJurosDebito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX11ASATITULOTOTALMOVIMENTOCREDITO_F1X44( string A283TituloTipo ,
                                                               int A261TituloId )
      {
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A305TituloTotalMovimentoCredito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX12ASATITULOTOTALMOVIMENTODEBITO_F1X44( string A283TituloTipo ,
                                                              int A261TituloId )
      {
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A304TituloTotalMovimentoDebito_F, 18, 2, ".", "")))+"\"") ;
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
         cmbTituloTipo.Name = "TITULOTIPO";
         cmbTituloTipo.WebTags = "";
         cmbTituloTipo.addItem("DEBITO", "Débito", 0);
         cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
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

      public void Valid_Tituloid( )
      {
         n261TituloId = false;
         n273TituloTotalMovimento_F = false;
         n301TituloTotalMultaJuros_F = false;
         /* Using cursor T001X36 */
         pr_default.execute(27, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A273TituloTotalMovimento_F = T001X36_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001X36_n273TituloTotalMovimento_F[0];
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
         }
         pr_default.close(27);
         /* Using cursor T001X38 */
         pr_default.execute(28, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            A301TituloTotalMultaJuros_F = T001X38_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001X38_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
         }
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", "")));
         AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A890NotaFiscalParcelamentoID","fld":"NOTAFISCALPARCELAMENTOID","type":"guid"},{"av":"AV11Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV20Insert_TituloPropostaId","fld":"vINSERT_TITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21Insert_ContaId","fld":"vINSERT_CONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV22Insert_CategoriaTituloId","fld":"vINSERT_CATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A314TituloArchived","fld":"TITULOARCHIVED","type":"boolean"},{"av":"A498TituloJurosMora","fld":"TITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n498TituloJurosMora","type":"decimal"},{"av":"A500TituloCriacao","fld":"TITULOCRIACAO","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121X2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A419TituloPropostaId","fld":"TITULOPROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n419TituloPropostaId","type":"int"}]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A273TituloTotalMovimento_F","fld":"TITULOTOTALMOVIMENTO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A301TituloTotalMultaJuros_F","fld":"TITULOTOTALMULTAJUROS_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"}]""");
         setEventMetadata("VALID_TITULOID",""","oparms":[{"av":"A273TituloTotalMovimento_F","fld":"TITULOTOTALMOVIMENTO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A301TituloTotalMultaJuros_F","fld":"TITULOTOTALMULTAJUROS_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"}]}""");
         setEventMetadata("VALID_TITULOVALOR","""{"handler":"Valid_Titulovalor","iparms":[]}""");
         setEventMetadata("VALID_TITULODESCONTO","""{"handler":"Valid_Titulodesconto","iparms":[]}""");
         setEventMetadata("VALID_TITULOTIPO","""{"handler":"Valid_Titulotipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOSALDO_F","""{"handler":"Valid_Titulosaldo_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOTOTALMOVIMENTO_F","""{"handler":"Valid_Titulototalmovimento_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAANO","""{"handler":"Valid_Titulocompetenciaano","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAMES","""{"handler":"Valid_Titulocompetenciames","iparms":[]}""");
         return  ;
      }

      protected decimal GetTituloTotalMovimentoDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001X47 */
         pr_default.execute(37, new Object[] {nA261TituloId, E261TituloId});
         if ( (pr_default.getStatus(37) != 101) )
         {
            X271TituloMovimentoValor = T001X47_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001X47_n271TituloMovimentoValor[0];
         }
         pr_default.close(37);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMovimentoCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001X48 */
         pr_default.execute(38, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(38) != 101) )
         {
            X271TituloMovimentoValor = T001X48_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001X48_n271TituloMovimentoValor[0];
         }
         pr_default.close(38);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001X49 */
         pr_default.execute(39, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            X271TituloMovimentoValor = T001X49_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001X49_n271TituloMovimentoValor[0];
         }
         pr_default.close(39);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001X50 */
         pr_default.execute(40, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(40) != 101) )
         {
            X271TituloMovimentoValor = T001X50_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001X50_n271TituloMovimentoValor[0];
         }
         pr_default.close(40);
         return X271TituloMovimentoValor ;
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
         pr_default.close(29);
         pr_default.close(32);
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(27);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         Z263TituloVencimento = DateTime.MinValue;
         Z264TituloProrrogacao = DateTime.MinValue;
         Z265TituloCEP = "";
         Z266TituloLogradouro = "";
         Z294TituloNumeroEndereco = "";
         Z267TituloComplemento = "";
         Z268TituloBairro = "";
         Z269TituloMunicipio = "";
         Z283TituloTipo = "";
         Z500TituloCriacao = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A283TituloTipo = "";
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A170ClienteRazaoSocial = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A282TituloStatus_F = "";
         A265TituloCEP = "";
         A266TituloLogradouro = "";
         A294TituloNumeroEndereco = "";
         A267TituloComplemento = "";
         A268TituloBairro = "";
         A269TituloMunicipio = "";
         WebComp_Wctitulomovimentoww_Component = "";
         OldWctitulomovimentoww = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A263TituloVencimento = DateTime.MinValue;
         A500TituloCriacao = (DateTime)(DateTime.MinValue);
         AV24Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode44 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXEncryptionTmp = "";
         Z794NotaFiscalId = Guid.Empty;
         Z170ClienteRazaoSocial = "";
         T001X12_A273TituloTotalMovimento_F = new decimal[1] ;
         T001X12_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001X14_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001X14_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001X17_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T001X17_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T001X17_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001X17_n794NotaFiscalId = new bool[] {false} ;
         T001X17_A261TituloId = new int[1] ;
         T001X17_n261TituloId = new bool[] {false} ;
         T001X17_A170ClienteRazaoSocial = new string[] {""} ;
         T001X17_n170ClienteRazaoSocial = new bool[] {false} ;
         T001X17_A262TituloValor = new decimal[1] ;
         T001X17_n262TituloValor = new bool[] {false} ;
         T001X17_A276TituloDesconto = new decimal[1] ;
         T001X17_n276TituloDesconto = new bool[] {false} ;
         T001X17_A284TituloDeleted = new bool[] {false} ;
         T001X17_n284TituloDeleted = new bool[] {false} ;
         T001X17_A314TituloArchived = new bool[] {false} ;
         T001X17_n314TituloArchived = new bool[] {false} ;
         T001X17_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         T001X17_n263TituloVencimento = new bool[] {false} ;
         T001X17_A286TituloCompetenciaAno = new short[1] ;
         T001X17_n286TituloCompetenciaAno = new bool[] {false} ;
         T001X17_A287TituloCompetenciaMes = new short[1] ;
         T001X17_n287TituloCompetenciaMes = new bool[] {false} ;
         T001X17_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         T001X17_n264TituloProrrogacao = new bool[] {false} ;
         T001X17_A265TituloCEP = new string[] {""} ;
         T001X17_n265TituloCEP = new bool[] {false} ;
         T001X17_A266TituloLogradouro = new string[] {""} ;
         T001X17_n266TituloLogradouro = new bool[] {false} ;
         T001X17_A294TituloNumeroEndereco = new string[] {""} ;
         T001X17_n294TituloNumeroEndereco = new bool[] {false} ;
         T001X17_A267TituloComplemento = new string[] {""} ;
         T001X17_n267TituloComplemento = new bool[] {false} ;
         T001X17_A268TituloBairro = new string[] {""} ;
         T001X17_n268TituloBairro = new bool[] {false} ;
         T001X17_A269TituloMunicipio = new string[] {""} ;
         T001X17_n269TituloMunicipio = new bool[] {false} ;
         T001X17_A498TituloJurosMora = new decimal[1] ;
         T001X17_n498TituloJurosMora = new bool[] {false} ;
         T001X17_A283TituloTipo = new string[] {""} ;
         T001X17_n283TituloTipo = new bool[] {false} ;
         T001X17_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001X17_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001X17_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         T001X17_n500TituloCriacao = new bool[] {false} ;
         T001X17_A422ContaId = new int[1] ;
         T001X17_n422ContaId = new bool[] {false} ;
         T001X17_A426CategoriaTituloId = new int[1] ;
         T001X17_n426CategoriaTituloId = new bool[] {false} ;
         T001X17_A419TituloPropostaId = new int[1] ;
         T001X17_n419TituloPropostaId = new bool[] {false} ;
         T001X17_A168ClienteId = new int[1] ;
         T001X17_n168ClienteId = new bool[] {false} ;
         T001X17_A273TituloTotalMovimento_F = new decimal[1] ;
         T001X17_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001X17_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001X17_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001X6_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001X6_n794NotaFiscalId = new bool[] {false} ;
         T001X9_A168ClienteId = new int[1] ;
         T001X9_n168ClienteId = new bool[] {false} ;
         T001X10_A170ClienteRazaoSocial = new string[] {""} ;
         T001X10_n170ClienteRazaoSocial = new bool[] {false} ;
         T001X4_A422ContaId = new int[1] ;
         T001X4_n422ContaId = new bool[] {false} ;
         T001X5_A426CategoriaTituloId = new int[1] ;
         T001X5_n426CategoriaTituloId = new bool[] {false} ;
         T001X7_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001X7_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001X19_A273TituloTotalMovimento_F = new decimal[1] ;
         T001X19_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001X21_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001X21_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001X22_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001X22_n794NotaFiscalId = new bool[] {false} ;
         T001X23_A170ClienteRazaoSocial = new string[] {""} ;
         T001X23_n170ClienteRazaoSocial = new bool[] {false} ;
         T001X24_A422ContaId = new int[1] ;
         T001X24_n422ContaId = new bool[] {false} ;
         T001X25_A426CategoriaTituloId = new int[1] ;
         T001X25_n426CategoriaTituloId = new bool[] {false} ;
         T001X26_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001X26_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001X27_A261TituloId = new int[1] ;
         T001X27_n261TituloId = new bool[] {false} ;
         T001X3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T001X3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T001X3_A261TituloId = new int[1] ;
         T001X3_n261TituloId = new bool[] {false} ;
         T001X3_A262TituloValor = new decimal[1] ;
         T001X3_n262TituloValor = new bool[] {false} ;
         T001X3_A276TituloDesconto = new decimal[1] ;
         T001X3_n276TituloDesconto = new bool[] {false} ;
         T001X3_A284TituloDeleted = new bool[] {false} ;
         T001X3_n284TituloDeleted = new bool[] {false} ;
         T001X3_A314TituloArchived = new bool[] {false} ;
         T001X3_n314TituloArchived = new bool[] {false} ;
         T001X3_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         T001X3_n263TituloVencimento = new bool[] {false} ;
         T001X3_A286TituloCompetenciaAno = new short[1] ;
         T001X3_n286TituloCompetenciaAno = new bool[] {false} ;
         T001X3_A287TituloCompetenciaMes = new short[1] ;
         T001X3_n287TituloCompetenciaMes = new bool[] {false} ;
         T001X3_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         T001X3_n264TituloProrrogacao = new bool[] {false} ;
         T001X3_A265TituloCEP = new string[] {""} ;
         T001X3_n265TituloCEP = new bool[] {false} ;
         T001X3_A266TituloLogradouro = new string[] {""} ;
         T001X3_n266TituloLogradouro = new bool[] {false} ;
         T001X3_A294TituloNumeroEndereco = new string[] {""} ;
         T001X3_n294TituloNumeroEndereco = new bool[] {false} ;
         T001X3_A267TituloComplemento = new string[] {""} ;
         T001X3_n267TituloComplemento = new bool[] {false} ;
         T001X3_A268TituloBairro = new string[] {""} ;
         T001X3_n268TituloBairro = new bool[] {false} ;
         T001X3_A269TituloMunicipio = new string[] {""} ;
         T001X3_n269TituloMunicipio = new bool[] {false} ;
         T001X3_A498TituloJurosMora = new decimal[1] ;
         T001X3_n498TituloJurosMora = new bool[] {false} ;
         T001X3_A283TituloTipo = new string[] {""} ;
         T001X3_n283TituloTipo = new bool[] {false} ;
         T001X3_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         T001X3_n500TituloCriacao = new bool[] {false} ;
         T001X3_A422ContaId = new int[1] ;
         T001X3_n422ContaId = new bool[] {false} ;
         T001X3_A426CategoriaTituloId = new int[1] ;
         T001X3_n426CategoriaTituloId = new bool[] {false} ;
         T001X3_A419TituloPropostaId = new int[1] ;
         T001X3_n419TituloPropostaId = new bool[] {false} ;
         T001X28_A261TituloId = new int[1] ;
         T001X28_n261TituloId = new bool[] {false} ;
         T001X29_A261TituloId = new int[1] ;
         T001X29_n261TituloId = new bool[] {false} ;
         T001X2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T001X2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T001X2_A261TituloId = new int[1] ;
         T001X2_n261TituloId = new bool[] {false} ;
         T001X2_A262TituloValor = new decimal[1] ;
         T001X2_n262TituloValor = new bool[] {false} ;
         T001X2_A276TituloDesconto = new decimal[1] ;
         T001X2_n276TituloDesconto = new bool[] {false} ;
         T001X2_A284TituloDeleted = new bool[] {false} ;
         T001X2_n284TituloDeleted = new bool[] {false} ;
         T001X2_A314TituloArchived = new bool[] {false} ;
         T001X2_n314TituloArchived = new bool[] {false} ;
         T001X2_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         T001X2_n263TituloVencimento = new bool[] {false} ;
         T001X2_A286TituloCompetenciaAno = new short[1] ;
         T001X2_n286TituloCompetenciaAno = new bool[] {false} ;
         T001X2_A287TituloCompetenciaMes = new short[1] ;
         T001X2_n287TituloCompetenciaMes = new bool[] {false} ;
         T001X2_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         T001X2_n264TituloProrrogacao = new bool[] {false} ;
         T001X2_A265TituloCEP = new string[] {""} ;
         T001X2_n265TituloCEP = new bool[] {false} ;
         T001X2_A266TituloLogradouro = new string[] {""} ;
         T001X2_n266TituloLogradouro = new bool[] {false} ;
         T001X2_A294TituloNumeroEndereco = new string[] {""} ;
         T001X2_n294TituloNumeroEndereco = new bool[] {false} ;
         T001X2_A267TituloComplemento = new string[] {""} ;
         T001X2_n267TituloComplemento = new bool[] {false} ;
         T001X2_A268TituloBairro = new string[] {""} ;
         T001X2_n268TituloBairro = new bool[] {false} ;
         T001X2_A269TituloMunicipio = new string[] {""} ;
         T001X2_n269TituloMunicipio = new bool[] {false} ;
         T001X2_A498TituloJurosMora = new decimal[1] ;
         T001X2_n498TituloJurosMora = new bool[] {false} ;
         T001X2_A283TituloTipo = new string[] {""} ;
         T001X2_n283TituloTipo = new bool[] {false} ;
         T001X2_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         T001X2_n500TituloCriacao = new bool[] {false} ;
         T001X2_A422ContaId = new int[1] ;
         T001X2_n422ContaId = new bool[] {false} ;
         T001X2_A426CategoriaTituloId = new int[1] ;
         T001X2_n426CategoriaTituloId = new bool[] {false} ;
         T001X2_A419TituloPropostaId = new int[1] ;
         T001X2_n419TituloPropostaId = new bool[] {false} ;
         T001X30_A168ClienteId = new int[1] ;
         T001X30_n168ClienteId = new bool[] {false} ;
         T001X32_A261TituloId = new int[1] ;
         T001X32_n261TituloId = new bool[] {false} ;
         T001X36_A273TituloTotalMovimento_F = new decimal[1] ;
         T001X36_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001X38_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001X38_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001X39_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001X39_n794NotaFiscalId = new bool[] {false} ;
         T001X40_A168ClienteId = new int[1] ;
         T001X40_n168ClienteId = new bool[] {false} ;
         T001X41_A170ClienteRazaoSocial = new string[] {""} ;
         T001X41_n170ClienteRazaoSocial = new bool[] {false} ;
         T001X42_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001X42_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001X43_A1077BoletosId = new int[1] ;
         T001X44_A270TituloMovimentoId = new int[1] ;
         T001X46_A261TituloId = new int[1] ;
         T001X46_n261TituloId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i500TituloCriacao = (DateTime)(DateTime.MinValue);
         T001X47_A271TituloMovimentoValor = new decimal[1] ;
         T001X47_n271TituloMovimentoValor = new bool[] {false} ;
         T001X48_A271TituloMovimentoValor = new decimal[1] ;
         T001X48_n271TituloMovimentoValor = new bool[] {false} ;
         T001X49_A271TituloMovimentoValor = new decimal[1] ;
         T001X49_n271TituloMovimentoValor = new bool[] {false} ;
         T001X50_A271TituloMovimentoValor = new decimal[1] ;
         T001X50_n271TituloMovimentoValor = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tituloproposta__default(),
            new Object[][] {
                new Object[] {
               T001X2_A890NotaFiscalParcelamentoID, T001X2_n890NotaFiscalParcelamentoID, T001X2_A261TituloId, T001X2_A262TituloValor, T001X2_n262TituloValor, T001X2_A276TituloDesconto, T001X2_n276TituloDesconto, T001X2_A284TituloDeleted, T001X2_n284TituloDeleted, T001X2_A314TituloArchived,
               T001X2_n314TituloArchived, T001X2_A263TituloVencimento, T001X2_n263TituloVencimento, T001X2_A286TituloCompetenciaAno, T001X2_n286TituloCompetenciaAno, T001X2_A287TituloCompetenciaMes, T001X2_n287TituloCompetenciaMes, T001X2_A264TituloProrrogacao, T001X2_n264TituloProrrogacao, T001X2_A265TituloCEP,
               T001X2_n265TituloCEP, T001X2_A266TituloLogradouro, T001X2_n266TituloLogradouro, T001X2_A294TituloNumeroEndereco, T001X2_n294TituloNumeroEndereco, T001X2_A267TituloComplemento, T001X2_n267TituloComplemento, T001X2_A268TituloBairro, T001X2_n268TituloBairro, T001X2_A269TituloMunicipio,
               T001X2_n269TituloMunicipio, T001X2_A498TituloJurosMora, T001X2_n498TituloJurosMora, T001X2_A283TituloTipo, T001X2_n283TituloTipo, T001X2_A500TituloCriacao, T001X2_n500TituloCriacao, T001X2_A422ContaId, T001X2_n422ContaId, T001X2_A426CategoriaTituloId,
               T001X2_n426CategoriaTituloId, T001X2_A419TituloPropostaId, T001X2_n419TituloPropostaId
               }
               , new Object[] {
               T001X3_A890NotaFiscalParcelamentoID, T001X3_n890NotaFiscalParcelamentoID, T001X3_A261TituloId, T001X3_A262TituloValor, T001X3_n262TituloValor, T001X3_A276TituloDesconto, T001X3_n276TituloDesconto, T001X3_A284TituloDeleted, T001X3_n284TituloDeleted, T001X3_A314TituloArchived,
               T001X3_n314TituloArchived, T001X3_A263TituloVencimento, T001X3_n263TituloVencimento, T001X3_A286TituloCompetenciaAno, T001X3_n286TituloCompetenciaAno, T001X3_A287TituloCompetenciaMes, T001X3_n287TituloCompetenciaMes, T001X3_A264TituloProrrogacao, T001X3_n264TituloProrrogacao, T001X3_A265TituloCEP,
               T001X3_n265TituloCEP, T001X3_A266TituloLogradouro, T001X3_n266TituloLogradouro, T001X3_A294TituloNumeroEndereco, T001X3_n294TituloNumeroEndereco, T001X3_A267TituloComplemento, T001X3_n267TituloComplemento, T001X3_A268TituloBairro, T001X3_n268TituloBairro, T001X3_A269TituloMunicipio,
               T001X3_n269TituloMunicipio, T001X3_A498TituloJurosMora, T001X3_n498TituloJurosMora, T001X3_A283TituloTipo, T001X3_n283TituloTipo, T001X3_A500TituloCriacao, T001X3_n500TituloCriacao, T001X3_A422ContaId, T001X3_n422ContaId, T001X3_A426CategoriaTituloId,
               T001X3_n426CategoriaTituloId, T001X3_A419TituloPropostaId, T001X3_n419TituloPropostaId
               }
               , new Object[] {
               T001X4_A422ContaId
               }
               , new Object[] {
               T001X5_A426CategoriaTituloId
               }
               , new Object[] {
               T001X6_A794NotaFiscalId, T001X6_n794NotaFiscalId
               }
               , new Object[] {
               T001X7_A501PropostaTaxaAdministrativa, T001X7_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               T001X8_A168ClienteId, T001X8_n168ClienteId
               }
               , new Object[] {
               T001X9_A168ClienteId, T001X9_n168ClienteId
               }
               , new Object[] {
               T001X10_A170ClienteRazaoSocial, T001X10_n170ClienteRazaoSocial
               }
               , new Object[] {
               T001X12_A273TituloTotalMovimento_F, T001X12_n273TituloTotalMovimento_F
               }
               , new Object[] {
               T001X14_A301TituloTotalMultaJuros_F, T001X14_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001X17_A890NotaFiscalParcelamentoID, T001X17_n890NotaFiscalParcelamentoID, T001X17_A794NotaFiscalId, T001X17_n794NotaFiscalId, T001X17_A261TituloId, T001X17_A170ClienteRazaoSocial, T001X17_n170ClienteRazaoSocial, T001X17_A262TituloValor, T001X17_n262TituloValor, T001X17_A276TituloDesconto,
               T001X17_n276TituloDesconto, T001X17_A284TituloDeleted, T001X17_n284TituloDeleted, T001X17_A314TituloArchived, T001X17_n314TituloArchived, T001X17_A263TituloVencimento, T001X17_n263TituloVencimento, T001X17_A286TituloCompetenciaAno, T001X17_n286TituloCompetenciaAno, T001X17_A287TituloCompetenciaMes,
               T001X17_n287TituloCompetenciaMes, T001X17_A264TituloProrrogacao, T001X17_n264TituloProrrogacao, T001X17_A265TituloCEP, T001X17_n265TituloCEP, T001X17_A266TituloLogradouro, T001X17_n266TituloLogradouro, T001X17_A294TituloNumeroEndereco, T001X17_n294TituloNumeroEndereco, T001X17_A267TituloComplemento,
               T001X17_n267TituloComplemento, T001X17_A268TituloBairro, T001X17_n268TituloBairro, T001X17_A269TituloMunicipio, T001X17_n269TituloMunicipio, T001X17_A498TituloJurosMora, T001X17_n498TituloJurosMora, T001X17_A283TituloTipo, T001X17_n283TituloTipo, T001X17_A501PropostaTaxaAdministrativa,
               T001X17_n501PropostaTaxaAdministrativa, T001X17_A500TituloCriacao, T001X17_n500TituloCriacao, T001X17_A422ContaId, T001X17_n422ContaId, T001X17_A426CategoriaTituloId, T001X17_n426CategoriaTituloId, T001X17_A419TituloPropostaId, T001X17_n419TituloPropostaId, T001X17_A168ClienteId,
               T001X17_n168ClienteId, T001X17_A273TituloTotalMovimento_F, T001X17_n273TituloTotalMovimento_F, T001X17_A301TituloTotalMultaJuros_F, T001X17_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001X19_A273TituloTotalMovimento_F, T001X19_n273TituloTotalMovimento_F
               }
               , new Object[] {
               T001X21_A301TituloTotalMultaJuros_F, T001X21_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001X22_A794NotaFiscalId, T001X22_n794NotaFiscalId
               }
               , new Object[] {
               T001X23_A170ClienteRazaoSocial, T001X23_n170ClienteRazaoSocial
               }
               , new Object[] {
               T001X24_A422ContaId
               }
               , new Object[] {
               T001X25_A426CategoriaTituloId
               }
               , new Object[] {
               T001X26_A501PropostaTaxaAdministrativa, T001X26_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               T001X27_A261TituloId
               }
               , new Object[] {
               T001X28_A261TituloId
               }
               , new Object[] {
               T001X29_A261TituloId
               }
               , new Object[] {
               T001X30_A168ClienteId, T001X30_n168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               T001X32_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001X36_A273TituloTotalMovimento_F, T001X36_n273TituloTotalMovimento_F
               }
               , new Object[] {
               T001X38_A301TituloTotalMultaJuros_F, T001X38_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001X39_A794NotaFiscalId, T001X39_n794NotaFiscalId
               }
               , new Object[] {
               T001X40_A168ClienteId, T001X40_n168ClienteId
               }
               , new Object[] {
               T001X41_A170ClienteRazaoSocial, T001X41_n170ClienteRazaoSocial
               }
               , new Object[] {
               T001X42_A501PropostaTaxaAdministrativa, T001X42_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               T001X43_A1077BoletosId
               }
               , new Object[] {
               T001X44_A270TituloMovimentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001X46_A261TituloId
               }
               , new Object[] {
               T001X47_A271TituloMovimentoValor, T001X47_n271TituloMovimentoValor
               }
               , new Object[] {
               T001X48_A271TituloMovimentoValor, T001X48_n271TituloMovimentoValor
               }
               , new Object[] {
               T001X49_A271TituloMovimentoValor, T001X49_n271TituloMovimentoValor
               }
               , new Object[] {
               T001X50_A271TituloMovimentoValor, T001X50_n271TituloMovimentoValor
               }
            }
         );
         WebComp_Wctitulomovimentoww = new GeneXus.Http.GXNullWebComponent();
         AV24Pgmname = "TituloProposta";
         Z500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         i500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         Z284TituloDeleted = false;
         n284TituloDeleted = false;
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         i284TituloDeleted = false;
         n284TituloDeleted = false;
      }

      private short Z286TituloCompetenciaAno ;
      private short Z287TituloCompetenciaMes ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private short Gx_BScreen ;
      private short RcdFound44 ;
      private short nCmpId ;
      private short gxcookieaux ;
      private short gxajaxcallmode ;
      private int wcpOAV7TituloId ;
      private int Z261TituloId ;
      private int Z422ContaId ;
      private int Z426CategoriaTituloId ;
      private int Z419TituloPropostaId ;
      private int Z168ClienteId ;
      private int N168ClienteId ;
      private int N419TituloPropostaId ;
      private int N422ContaId ;
      private int N426CategoriaTituloId ;
      private int A261TituloId ;
      private int A168ClienteId ;
      private int A422ContaId ;
      private int A426CategoriaTituloId ;
      private int A419TituloPropostaId ;
      private int AV7TituloId ;
      private int trnEnded ;
      private int edtTituloId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtTituloValor_Enabled ;
      private int edtTituloDesconto_Enabled ;
      private int edtTituloProrrogacao_Enabled ;
      private int edtTituloCompetencia_F_Enabled ;
      private int edtTituloStatus_F_Enabled ;
      private int edtTituloSaldo_F_Enabled ;
      private int edtTituloTotalMovimento_F_Enabled ;
      private int edtTituloCEP_Enabled ;
      private int edtTituloLogradouro_Enabled ;
      private int edtTituloNumeroEndereco_Enabled ;
      private int edtTituloComplemento_Enabled ;
      private int edtTituloBairro_Enabled ;
      private int edtTituloMunicipio_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtTituloDeleted_Visible ;
      private int edtTituloDeleted_Enabled ;
      private int edtTituloVencimento_Visible ;
      private int edtTituloVencimento_Enabled ;
      private int edtTituloCompetenciaAno_Enabled ;
      private int edtTituloCompetenciaAno_Visible ;
      private int edtTituloCompetenciaMes_Enabled ;
      private int edtTituloCompetenciaMes_Visible ;
      private int AV11Insert_ClienteId ;
      private int AV20Insert_TituloPropostaId ;
      private int AV21Insert_ContaId ;
      private int AV22Insert_CategoriaTituloId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV25GXV1 ;
      private int idxLst ;
      private int E261TituloId ;
      private decimal Z262TituloValor ;
      private decimal Z276TituloDesconto ;
      private decimal Z498TituloJurosMora ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A275TituloSaldo_F ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A498TituloJurosMora ;
      private decimal A303TituloSaldoCredito_F ;
      private decimal A302TituloSaldoDebito_F ;
      private decimal A307TituloTotalMultaJurosCredito_F ;
      private decimal A306TituloTotalMultaJurosDebito_F ;
      private decimal A305TituloTotalMovimentoCredito_F ;
      private decimal A304TituloTotalMovimentoDebito_F ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A301TituloTotalMultaJuros_F ;
      private decimal Z501PropostaTaxaAdministrativa ;
      private decimal Z273TituloTotalMovimento_F ;
      private decimal Z301TituloTotalMultaJuros_F ;
      private decimal X271TituloMovimentoValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTituloValor_Internalname ;
      private string cmbTituloTipo_Internalname ;
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
      private string edtTituloId_Internalname ;
      private string TempTags ;
      private string edtTituloId_Jsonclick ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtTituloValor_Jsonclick ;
      private string edtTituloDesconto_Internalname ;
      private string edtTituloDesconto_Jsonclick ;
      private string edtTituloProrrogacao_Internalname ;
      private string edtTituloProrrogacao_Jsonclick ;
      private string edtTituloCompetencia_F_Internalname ;
      private string edtTituloCompetencia_F_Jsonclick ;
      private string edtTituloStatus_F_Internalname ;
      private string edtTituloStatus_F_Jsonclick ;
      private string cmbTituloTipo_Jsonclick ;
      private string edtTituloSaldo_F_Internalname ;
      private string edtTituloSaldo_F_Jsonclick ;
      private string edtTituloTotalMovimento_F_Internalname ;
      private string edtTituloTotalMovimento_F_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtTituloCEP_Internalname ;
      private string edtTituloCEP_Jsonclick ;
      private string edtTituloLogradouro_Internalname ;
      private string edtTituloLogradouro_Jsonclick ;
      private string edtTituloNumeroEndereco_Internalname ;
      private string edtTituloNumeroEndereco_Jsonclick ;
      private string edtTituloComplemento_Internalname ;
      private string edtTituloComplemento_Jsonclick ;
      private string edtTituloBairro_Internalname ;
      private string edtTituloBairro_Jsonclick ;
      private string edtTituloMunicipio_Internalname ;
      private string edtTituloMunicipio_Jsonclick ;
      private string divTablemovimentos_Internalname ;
      private string WebComp_Wctitulomovimentoww_Component ;
      private string OldWctitulomovimentoww ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTituloDeleted_Internalname ;
      private string edtTituloDeleted_Jsonclick ;
      private string edtTituloVencimento_Internalname ;
      private string edtTituloVencimento_Jsonclick ;
      private string edtTituloCompetenciaAno_Internalname ;
      private string edtTituloCompetenciaAno_Jsonclick ;
      private string edtTituloCompetenciaMes_Internalname ;
      private string edtTituloCompetenciaMes_Jsonclick ;
      private string AV24Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode44 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z500TituloCriacao ;
      private DateTime A500TituloCriacao ;
      private DateTime i500TituloCriacao ;
      private DateTime Z263TituloVencimento ;
      private DateTime Z264TituloProrrogacao ;
      private DateTime A264TituloProrrogacao ;
      private DateTime A263TituloVencimento ;
      private bool Z284TituloDeleted ;
      private bool Z314TituloArchived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n283TituloTipo ;
      private bool n261TituloId ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n422ContaId ;
      private bool n426CategoriaTituloId ;
      private bool n419TituloPropostaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool A284TituloDeleted ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool n284TituloDeleted ;
      private bool n314TituloArchived ;
      private bool A314TituloArchived ;
      private bool n263TituloVencimento ;
      private bool n264TituloProrrogacao ;
      private bool n265TituloCEP ;
      private bool n266TituloLogradouro ;
      private bool n294TituloNumeroEndereco ;
      private bool n267TituloComplemento ;
      private bool n268TituloBairro ;
      private bool n269TituloMunicipio ;
      private bool n498TituloJurosMora ;
      private bool n500TituloCriacao ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n301TituloTotalMultaJuros_F ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n170ClienteRazaoSocial ;
      private bool n273TituloTotalMovimento_F ;
      private bool returnInSub ;
      private bool bDynCreated_Wctitulomovimentoww ;
      private bool Gx_longc ;
      private bool i284TituloDeleted ;
      private bool nA261TituloId ;
      private bool nX271TituloMovimentoValor ;
      private bool nE261TituloId ;
      private string Z265TituloCEP ;
      private string Z266TituloLogradouro ;
      private string Z294TituloNumeroEndereco ;
      private string Z267TituloComplemento ;
      private string Z268TituloBairro ;
      private string Z269TituloMunicipio ;
      private string Z283TituloTipo ;
      private string A283TituloTipo ;
      private string A170ClienteRazaoSocial ;
      private string A295TituloCompetencia_F ;
      private string A282TituloStatus_F ;
      private string A265TituloCEP ;
      private string A266TituloLogradouro ;
      private string A294TituloNumeroEndereco ;
      private string A267TituloComplemento ;
      private string A268TituloBairro ;
      private string A269TituloMunicipio ;
      private string Z170ClienteRazaoSocial ;
      private Guid Z890NotaFiscalParcelamentoID ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private Guid Z794NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private GXWebComponent WebComp_Wctitulomovimentoww ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTituloTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] T001X12_A273TituloTotalMovimento_F ;
      private bool[] T001X12_n273TituloTotalMovimento_F ;
      private decimal[] T001X14_A301TituloTotalMultaJuros_F ;
      private bool[] T001X14_n301TituloTotalMultaJuros_F ;
      private Guid[] T001X17_A890NotaFiscalParcelamentoID ;
      private bool[] T001X17_n890NotaFiscalParcelamentoID ;
      private Guid[] T001X17_A794NotaFiscalId ;
      private bool[] T001X17_n794NotaFiscalId ;
      private int[] T001X17_A261TituloId ;
      private bool[] T001X17_n261TituloId ;
      private string[] T001X17_A170ClienteRazaoSocial ;
      private bool[] T001X17_n170ClienteRazaoSocial ;
      private decimal[] T001X17_A262TituloValor ;
      private bool[] T001X17_n262TituloValor ;
      private decimal[] T001X17_A276TituloDesconto ;
      private bool[] T001X17_n276TituloDesconto ;
      private bool[] T001X17_A284TituloDeleted ;
      private bool[] T001X17_n284TituloDeleted ;
      private bool[] T001X17_A314TituloArchived ;
      private bool[] T001X17_n314TituloArchived ;
      private DateTime[] T001X17_A263TituloVencimento ;
      private bool[] T001X17_n263TituloVencimento ;
      private short[] T001X17_A286TituloCompetenciaAno ;
      private bool[] T001X17_n286TituloCompetenciaAno ;
      private short[] T001X17_A287TituloCompetenciaMes ;
      private bool[] T001X17_n287TituloCompetenciaMes ;
      private DateTime[] T001X17_A264TituloProrrogacao ;
      private bool[] T001X17_n264TituloProrrogacao ;
      private string[] T001X17_A265TituloCEP ;
      private bool[] T001X17_n265TituloCEP ;
      private string[] T001X17_A266TituloLogradouro ;
      private bool[] T001X17_n266TituloLogradouro ;
      private string[] T001X17_A294TituloNumeroEndereco ;
      private bool[] T001X17_n294TituloNumeroEndereco ;
      private string[] T001X17_A267TituloComplemento ;
      private bool[] T001X17_n267TituloComplemento ;
      private string[] T001X17_A268TituloBairro ;
      private bool[] T001X17_n268TituloBairro ;
      private string[] T001X17_A269TituloMunicipio ;
      private bool[] T001X17_n269TituloMunicipio ;
      private decimal[] T001X17_A498TituloJurosMora ;
      private bool[] T001X17_n498TituloJurosMora ;
      private string[] T001X17_A283TituloTipo ;
      private bool[] T001X17_n283TituloTipo ;
      private decimal[] T001X17_A501PropostaTaxaAdministrativa ;
      private bool[] T001X17_n501PropostaTaxaAdministrativa ;
      private DateTime[] T001X17_A500TituloCriacao ;
      private bool[] T001X17_n500TituloCriacao ;
      private int[] T001X17_A422ContaId ;
      private bool[] T001X17_n422ContaId ;
      private int[] T001X17_A426CategoriaTituloId ;
      private bool[] T001X17_n426CategoriaTituloId ;
      private int[] T001X17_A419TituloPropostaId ;
      private bool[] T001X17_n419TituloPropostaId ;
      private int[] T001X17_A168ClienteId ;
      private bool[] T001X17_n168ClienteId ;
      private decimal[] T001X17_A273TituloTotalMovimento_F ;
      private bool[] T001X17_n273TituloTotalMovimento_F ;
      private decimal[] T001X17_A301TituloTotalMultaJuros_F ;
      private bool[] T001X17_n301TituloTotalMultaJuros_F ;
      private Guid[] T001X6_A794NotaFiscalId ;
      private bool[] T001X6_n794NotaFiscalId ;
      private int[] T001X9_A168ClienteId ;
      private bool[] T001X9_n168ClienteId ;
      private string[] T001X10_A170ClienteRazaoSocial ;
      private bool[] T001X10_n170ClienteRazaoSocial ;
      private int[] T001X4_A422ContaId ;
      private bool[] T001X4_n422ContaId ;
      private int[] T001X5_A426CategoriaTituloId ;
      private bool[] T001X5_n426CategoriaTituloId ;
      private decimal[] T001X7_A501PropostaTaxaAdministrativa ;
      private bool[] T001X7_n501PropostaTaxaAdministrativa ;
      private decimal[] T001X19_A273TituloTotalMovimento_F ;
      private bool[] T001X19_n273TituloTotalMovimento_F ;
      private decimal[] T001X21_A301TituloTotalMultaJuros_F ;
      private bool[] T001X21_n301TituloTotalMultaJuros_F ;
      private Guid[] T001X22_A794NotaFiscalId ;
      private bool[] T001X22_n794NotaFiscalId ;
      private string[] T001X23_A170ClienteRazaoSocial ;
      private bool[] T001X23_n170ClienteRazaoSocial ;
      private int[] T001X24_A422ContaId ;
      private bool[] T001X24_n422ContaId ;
      private int[] T001X25_A426CategoriaTituloId ;
      private bool[] T001X25_n426CategoriaTituloId ;
      private decimal[] T001X26_A501PropostaTaxaAdministrativa ;
      private bool[] T001X26_n501PropostaTaxaAdministrativa ;
      private int[] T001X27_A261TituloId ;
      private bool[] T001X27_n261TituloId ;
      private Guid[] T001X3_A890NotaFiscalParcelamentoID ;
      private bool[] T001X3_n890NotaFiscalParcelamentoID ;
      private int[] T001X3_A261TituloId ;
      private bool[] T001X3_n261TituloId ;
      private decimal[] T001X3_A262TituloValor ;
      private bool[] T001X3_n262TituloValor ;
      private decimal[] T001X3_A276TituloDesconto ;
      private bool[] T001X3_n276TituloDesconto ;
      private bool[] T001X3_A284TituloDeleted ;
      private bool[] T001X3_n284TituloDeleted ;
      private bool[] T001X3_A314TituloArchived ;
      private bool[] T001X3_n314TituloArchived ;
      private DateTime[] T001X3_A263TituloVencimento ;
      private bool[] T001X3_n263TituloVencimento ;
      private short[] T001X3_A286TituloCompetenciaAno ;
      private bool[] T001X3_n286TituloCompetenciaAno ;
      private short[] T001X3_A287TituloCompetenciaMes ;
      private bool[] T001X3_n287TituloCompetenciaMes ;
      private DateTime[] T001X3_A264TituloProrrogacao ;
      private bool[] T001X3_n264TituloProrrogacao ;
      private string[] T001X3_A265TituloCEP ;
      private bool[] T001X3_n265TituloCEP ;
      private string[] T001X3_A266TituloLogradouro ;
      private bool[] T001X3_n266TituloLogradouro ;
      private string[] T001X3_A294TituloNumeroEndereco ;
      private bool[] T001X3_n294TituloNumeroEndereco ;
      private string[] T001X3_A267TituloComplemento ;
      private bool[] T001X3_n267TituloComplemento ;
      private string[] T001X3_A268TituloBairro ;
      private bool[] T001X3_n268TituloBairro ;
      private string[] T001X3_A269TituloMunicipio ;
      private bool[] T001X3_n269TituloMunicipio ;
      private decimal[] T001X3_A498TituloJurosMora ;
      private bool[] T001X3_n498TituloJurosMora ;
      private string[] T001X3_A283TituloTipo ;
      private bool[] T001X3_n283TituloTipo ;
      private DateTime[] T001X3_A500TituloCriacao ;
      private bool[] T001X3_n500TituloCriacao ;
      private int[] T001X3_A422ContaId ;
      private bool[] T001X3_n422ContaId ;
      private int[] T001X3_A426CategoriaTituloId ;
      private bool[] T001X3_n426CategoriaTituloId ;
      private int[] T001X3_A419TituloPropostaId ;
      private bool[] T001X3_n419TituloPropostaId ;
      private int[] T001X28_A261TituloId ;
      private bool[] T001X28_n261TituloId ;
      private int[] T001X29_A261TituloId ;
      private bool[] T001X29_n261TituloId ;
      private Guid[] T001X2_A890NotaFiscalParcelamentoID ;
      private bool[] T001X2_n890NotaFiscalParcelamentoID ;
      private int[] T001X2_A261TituloId ;
      private bool[] T001X2_n261TituloId ;
      private decimal[] T001X2_A262TituloValor ;
      private bool[] T001X2_n262TituloValor ;
      private decimal[] T001X2_A276TituloDesconto ;
      private bool[] T001X2_n276TituloDesconto ;
      private bool[] T001X2_A284TituloDeleted ;
      private bool[] T001X2_n284TituloDeleted ;
      private bool[] T001X2_A314TituloArchived ;
      private bool[] T001X2_n314TituloArchived ;
      private DateTime[] T001X2_A263TituloVencimento ;
      private bool[] T001X2_n263TituloVencimento ;
      private short[] T001X2_A286TituloCompetenciaAno ;
      private bool[] T001X2_n286TituloCompetenciaAno ;
      private short[] T001X2_A287TituloCompetenciaMes ;
      private bool[] T001X2_n287TituloCompetenciaMes ;
      private DateTime[] T001X2_A264TituloProrrogacao ;
      private bool[] T001X2_n264TituloProrrogacao ;
      private string[] T001X2_A265TituloCEP ;
      private bool[] T001X2_n265TituloCEP ;
      private string[] T001X2_A266TituloLogradouro ;
      private bool[] T001X2_n266TituloLogradouro ;
      private string[] T001X2_A294TituloNumeroEndereco ;
      private bool[] T001X2_n294TituloNumeroEndereco ;
      private string[] T001X2_A267TituloComplemento ;
      private bool[] T001X2_n267TituloComplemento ;
      private string[] T001X2_A268TituloBairro ;
      private bool[] T001X2_n268TituloBairro ;
      private string[] T001X2_A269TituloMunicipio ;
      private bool[] T001X2_n269TituloMunicipio ;
      private decimal[] T001X2_A498TituloJurosMora ;
      private bool[] T001X2_n498TituloJurosMora ;
      private string[] T001X2_A283TituloTipo ;
      private bool[] T001X2_n283TituloTipo ;
      private DateTime[] T001X2_A500TituloCriacao ;
      private bool[] T001X2_n500TituloCriacao ;
      private int[] T001X2_A422ContaId ;
      private bool[] T001X2_n422ContaId ;
      private int[] T001X2_A426CategoriaTituloId ;
      private bool[] T001X2_n426CategoriaTituloId ;
      private int[] T001X2_A419TituloPropostaId ;
      private bool[] T001X2_n419TituloPropostaId ;
      private int[] T001X30_A168ClienteId ;
      private bool[] T001X30_n168ClienteId ;
      private int[] T001X32_A261TituloId ;
      private bool[] T001X32_n261TituloId ;
      private decimal[] T001X36_A273TituloTotalMovimento_F ;
      private bool[] T001X36_n273TituloTotalMovimento_F ;
      private decimal[] T001X38_A301TituloTotalMultaJuros_F ;
      private bool[] T001X38_n301TituloTotalMultaJuros_F ;
      private Guid[] T001X39_A794NotaFiscalId ;
      private bool[] T001X39_n794NotaFiscalId ;
      private int[] T001X40_A168ClienteId ;
      private bool[] T001X40_n168ClienteId ;
      private string[] T001X41_A170ClienteRazaoSocial ;
      private bool[] T001X41_n170ClienteRazaoSocial ;
      private decimal[] T001X42_A501PropostaTaxaAdministrativa ;
      private bool[] T001X42_n501PropostaTaxaAdministrativa ;
      private int[] T001X43_A1077BoletosId ;
      private int[] T001X44_A270TituloMovimentoId ;
      private int[] T001X46_A261TituloId ;
      private bool[] T001X46_n261TituloId ;
      private decimal[] T001X47_A271TituloMovimentoValor ;
      private bool[] T001X47_n271TituloMovimentoValor ;
      private decimal[] T001X48_A271TituloMovimentoValor ;
      private bool[] T001X48_n271TituloMovimentoValor ;
      private decimal[] T001X49_A271TituloMovimentoValor ;
      private bool[] T001X49_n271TituloMovimentoValor ;
      private decimal[] T001X50_A271TituloMovimentoValor ;
      private bool[] T001X50_n271TituloMovimentoValor ;
      private int[] T001X8_A168ClienteId ;
      private bool[] T001X8_n168ClienteId ;
   }

   public class tituloproposta__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new UpdateCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001X2;
          prmT001X2 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X3;
          prmT001X3 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X4;
          prmT001X4 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X5;
          prmT001X5 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X6;
          prmT001X6 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X7;
          prmT001X7 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X8;
          prmT001X8 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X9;
          prmT001X9 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X10;
          prmT001X10 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X12;
          prmT001X12 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X14;
          prmT001X14 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X17;
          prmT001X17 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X19;
          prmT001X19 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X21;
          prmT001X21 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X22;
          prmT001X22 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X23;
          prmT001X23 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X24;
          prmT001X24 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X25;
          prmT001X25 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X26;
          prmT001X26 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X27;
          prmT001X27 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X28;
          prmT001X28 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X29;
          prmT001X29 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X30;
          prmT001X30 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X31;
          prmT001X31 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("TituloValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDeleted",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloArchived",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCompetenciaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloCompetenciaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloProrrogacao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("TituloLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloNumeroEndereco",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("TituloComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloMunicipio",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TituloTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X32;
          prmT001X32 = new Object[] {
          };
          Object[] prmT001X33;
          prmT001X33 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("TituloValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDeleted",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloArchived",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCompetenciaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloCompetenciaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloProrrogacao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("TituloLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloNumeroEndereco",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("TituloComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloMunicipio",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TituloTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X34;
          prmT001X34 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X36;
          prmT001X36 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X38;
          prmT001X38 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X39;
          prmT001X39 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X40;
          prmT001X40 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X41;
          prmT001X41 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X42;
          prmT001X42 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X43;
          prmT001X43 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X44;
          prmT001X44 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X45;
          prmT001X45 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001X46;
          prmT001X46 = new Object[] {
          };
          Object[] prmT001X47;
          prmT001X47 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X48;
          prmT001X48 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X49;
          prmT001X49 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001X50;
          prmT001X50 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001X2", "SELECT NotaFiscalParcelamentoID, TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, ContaId, CategoriaTituloId, TituloPropostaId FROM Titulo WHERE TituloId = :TituloId  FOR UPDATE OF Titulo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001X2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X3", "SELECT NotaFiscalParcelamentoID, TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, ContaId, CategoriaTituloId, TituloPropostaId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X4", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X5", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X6", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X7", "SELECT PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X8", "SELECT ClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId  FOR UPDATE OF NotaFiscal NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001X8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X9", "SELECT ClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X10", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X12", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X14", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X17", "SELECT TM1.NotaFiscalParcelamentoID, T2.NotaFiscalId, TM1.TituloId, T4.ClienteRazaoSocial, TM1.TituloValor, TM1.TituloDesconto, TM1.TituloDeleted, TM1.TituloArchived, TM1.TituloVencimento, TM1.TituloCompetenciaAno, TM1.TituloCompetenciaMes, TM1.TituloProrrogacao, TM1.TituloCEP, TM1.TituloLogradouro, TM1.TituloNumeroEndereco, TM1.TituloComplemento, TM1.TituloBairro, TM1.TituloMunicipio, TM1.TituloJurosMora, TM1.TituloTipo, T5.PropostaTaxaAdministrativa, TM1.TituloCriacao, TM1.ContaId, TM1.CategoriaTituloId, TM1.TituloPropostaId AS TituloPropostaId, T3.ClienteId, COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM ((((((Titulo TM1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = TM1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN Proposta T5 ON T5.PropostaId = TM1.TituloPropostaId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = TM1.TituloId) WHERE TM1.TituloId = :TituloId ORDER BY TM1.TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X19", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X21", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X22", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X23", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X24", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X25", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X26", "SELECT PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X27", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X28", "SELECT TituloId FROM Titulo WHERE ( TituloId > :TituloId) ORDER BY TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001X29", "SELECT TituloId FROM Titulo WHERE ( TituloId < :TituloId) ORDER BY TituloId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001X30", "SELECT ClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId  FOR UPDATE OF NotaFiscal NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001X30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X31", "SAVEPOINT gxupdate;INSERT INTO Titulo(NotaFiscalParcelamentoID, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, ContaId, CategoriaTituloId, TituloPropostaId, TituloPropostaTipo, ContaBancariaId, TituloClienteId) VALUES(:NotaFiscalParcelamentoID, :TituloValor, :TituloDesconto, :TituloDeleted, :TituloArchived, :TituloVencimento, :TituloCompetenciaAno, :TituloCompetenciaMes, :TituloProrrogacao, :TituloCEP, :TituloLogradouro, :TituloNumeroEndereco, :TituloComplemento, :TituloBairro, :TituloMunicipio, :TituloJurosMora, :TituloTipo, :TituloCriacao, :ContaId, :CategoriaTituloId, :TituloPropostaId, '', 0, 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001X31)
             ,new CursorDef("T001X32", "SELECT currval('TituloId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X33", "SAVEPOINT gxupdate;UPDATE Titulo SET NotaFiscalParcelamentoID=:NotaFiscalParcelamentoID, TituloValor=:TituloValor, TituloDesconto=:TituloDesconto, TituloDeleted=:TituloDeleted, TituloArchived=:TituloArchived, TituloVencimento=:TituloVencimento, TituloCompetenciaAno=:TituloCompetenciaAno, TituloCompetenciaMes=:TituloCompetenciaMes, TituloProrrogacao=:TituloProrrogacao, TituloCEP=:TituloCEP, TituloLogradouro=:TituloLogradouro, TituloNumeroEndereco=:TituloNumeroEndereco, TituloComplemento=:TituloComplemento, TituloBairro=:TituloBairro, TituloMunicipio=:TituloMunicipio, TituloJurosMora=:TituloJurosMora, TituloTipo=:TituloTipo, TituloCriacao=:TituloCriacao, ContaId=:ContaId, CategoriaTituloId=:CategoriaTituloId, TituloPropostaId=:TituloPropostaId  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001X33)
             ,new CursorDef("T001X34", "SAVEPOINT gxupdate;DELETE FROM Titulo  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001X34)
             ,new CursorDef("T001X36", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X38", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X38,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X39", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X39,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X40", "SELECT ClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X40,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X41", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X42", "SELECT PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X42,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X43", "SELECT BoletosId FROM Boleto WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X43,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001X44", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X44,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001X45", "SAVEPOINT gxupdate;UPDATE NotaFiscal SET ClienteId=:ClienteId  WHERE NotaFiscalId = :NotaFiscalId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001X45)
             ,new CursorDef("T001X46", "SELECT TituloId FROM Titulo ORDER BY TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X46,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X47", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X47,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X48", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X48,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X49", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X49,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001X50", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X50,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
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
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 32 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 34 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 36 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 37 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 38 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 39 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 40 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
