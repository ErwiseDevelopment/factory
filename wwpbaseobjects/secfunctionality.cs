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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionality : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A129SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecParentFunctionalityId"), "."), 18, MidpointRounding.ToEven));
            n129SecParentFunctionalityId = false;
            AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A129SecParentFunctionalityId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secfunctionality")), "wwpbaseobjects.secfunctionality") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secfunctionality")))) ;
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
                  AV7SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SecFunctionalityId", StringUtil.LTrimStr( (decimal)(AV7SecFunctionalityId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecFunctionalityId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Functionality", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecFunctionalityDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secfunctionality( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionality( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SecFunctionalityId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SecFunctionalityId = aP1_SecFunctionalityId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbSecFunctionalityType = new GXCombobox();
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
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            n136SecFunctionalityType = false;
            AssignAttri("", false, "A136SecFunctionalityType", ((0==A136SecFunctionalityType)&&IsIns( )||n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", cmbSecFunctionalityType.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")), StringUtil.LTrim( ((edtSecFunctionalityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecFunctionalityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityKey_Internalname, "Key", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityKey_Internalname, A130SecFunctionalityKey, StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityKey_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecFunctionalityKey_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityDescription_Internalname, "Description", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityDescription_Internalname, A135SecFunctionalityDescription, StringUtil.RTrim( context.localUtil.Format( A135SecFunctionalityDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityDescription_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecFunctionalityDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSecFunctionalityType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSecFunctionalityType_Internalname, "Type", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecFunctionalityType, cmbSecFunctionalityType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0)), 1, cmbSecFunctionalityType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbSecFunctionalityType.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_WWPBaseObjects/SecFunctionality.htm");
         cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0));
         AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionality.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionality.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecParentFunctionalityId_Internalname, ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ",", ""))), ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecParentFunctionalityId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecParentFunctionalityId_Visible, edtSecParentFunctionalityId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityActive_Internalname, StringUtil.BoolToStr( A134SecFunctionalityActive), StringUtil.BoolToStr( A134SecFunctionalityActive), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityActive_Jsonclick, 0, "Attribute", "", "", "", "", edtSecFunctionalityActive_Visible, edtSecFunctionalityActive_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionality.htm");
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
         E110E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128SecFunctionalityId"), ",", "."), 18, MidpointRounding.ToEven));
               Z130SecFunctionalityKey = cgiGet( "Z130SecFunctionalityKey");
               n130SecFunctionalityKey = (String.IsNullOrEmpty(StringUtil.RTrim( A130SecFunctionalityKey)) ? true : false);
               Z135SecFunctionalityDescription = cgiGet( "Z135SecFunctionalityDescription");
               n135SecFunctionalityDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A135SecFunctionalityDescription)) ? true : false);
               Z789SecFunctionalityModule = cgiGet( "Z789SecFunctionalityModule");
               n789SecFunctionalityModule = (String.IsNullOrEmpty(StringUtil.RTrim( A789SecFunctionalityModule)) ? true : false);
               Z136SecFunctionalityType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z136SecFunctionalityType"), ",", "."), 18, MidpointRounding.ToEven));
               n136SecFunctionalityType = ((0==A136SecFunctionalityType) ? true : false);
               Z134SecFunctionalityActive = StringUtil.StrToBool( cgiGet( "Z134SecFunctionalityActive"));
               n134SecFunctionalityActive = ((false==A134SecFunctionalityActive) ? true : false);
               Z129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z129SecParentFunctionalityId"), ",", "."), 18, MidpointRounding.ToEven));
               n129SecParentFunctionalityId = ((0==A129SecParentFunctionalityId) ? true : false);
               A789SecFunctionalityModule = cgiGet( "Z789SecFunctionalityModule");
               n789SecFunctionalityModule = false;
               n789SecFunctionalityModule = (String.IsNullOrEmpty(StringUtil.RTrim( A789SecFunctionalityModule)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N129SecParentFunctionalityId"), ",", "."), 18, MidpointRounding.ToEven));
               n129SecParentFunctionalityId = ((0==A129SecParentFunctionalityId) ? true : false);
               AV7SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSECFUNCTIONALITYID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECPARENTFUNCTIONALITYID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(AV12Insert_SecParentFunctionalityId), 10, 0));
               A789SecFunctionalityModule = cgiGet( "SECFUNCTIONALITYMODULE");
               n789SecFunctionalityModule = (String.IsNullOrEmpty(StringUtil.RTrim( A789SecFunctionalityModule)) ? true : false);
               A138SecParentFunctionalityDescription = cgiGet( "SECPARENTFUNCTIONALITYDESCRIPTION");
               n138SecParentFunctionalityDescription = false;
               AV19Pgmname = cgiGet( "vPGMNAME");
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
               A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               A130SecFunctionalityKey = StringUtil.Upper( cgiGet( edtSecFunctionalityKey_Internalname));
               n130SecFunctionalityKey = false;
               AssignAttri("", false, "A130SecFunctionalityKey", A130SecFunctionalityKey);
               A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
               n135SecFunctionalityDescription = false;
               AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
               n135SecFunctionalityDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A135SecFunctionalityDescription)) ? true : false);
               cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
               A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
               n136SecFunctionalityType = false;
               AssignAttri("", false, "A136SecFunctionalityType", (n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
               n129SecParentFunctionalityId = ((StringUtil.StrCmp(cgiGet( edtSecParentFunctionalityId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECPARENTFUNCTIONALITYID");
                  AnyError = 1;
                  GX_FocusControl = edtSecParentFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A129SecParentFunctionalityId = 0;
                  n129SecParentFunctionalityId = false;
                  AssignAttri("", false, "A129SecParentFunctionalityId", (n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
               }
               else
               {
                  A129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A129SecParentFunctionalityId", (n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
               }
               A134SecFunctionalityActive = StringUtil.StrToBool( cgiGet( edtSecFunctionalityActive_Internalname));
               n134SecFunctionalityActive = false;
               AssignAttri("", false, "A134SecFunctionalityActive", A134SecFunctionalityActive);
               n134SecFunctionalityActive = ((false==A134SecFunctionalityActive) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SecFunctionality");
               A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               forbiddenHiddens.Add("SecFunctionalityId", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"));
               A130SecFunctionalityKey = cgiGet( edtSecFunctionalityKey_Internalname);
               n130SecFunctionalityKey = false;
               AssignAttri("", false, "A130SecFunctionalityKey", A130SecFunctionalityKey);
               forbiddenHiddens.Add("SecFunctionalityKey", StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")));
               A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
               n136SecFunctionalityType = false;
               AssignAttri("", false, "A136SecFunctionalityType", (n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
               forbiddenHiddens.Add("SecFunctionalityType", context.localUtil.Format( (decimal)(A136SecFunctionalityType), "Z9"));
               forbiddenHiddens.Add("Insert_SecParentFunctionalityId", context.localUtil.Format( (decimal)(AV12Insert_SecParentFunctionalityId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("SecFunctionalityModule", StringUtil.RTrim( context.localUtil.Format( A789SecFunctionalityModule, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("wwpbaseobjects\\secfunctionality:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A128SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
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
                     sMode17 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode17;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound17 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0E0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SECFUNCTIONALITYID");
                        AnyError = 1;
                        GX_FocusControl = edtSecFunctionalityId_Internalname;
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
                           E110E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120E2 ();
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
            E120E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0E17( ) ;
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
            DisableAttributes0E17( ) ;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E17( ) ;
            }
            else
            {
               CheckExtendedTable0E17( ) ;
               CloseExtendedTableCursors0E17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0E0( )
      {
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV18WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            while ( AV20GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SecParentFunctionalityId") == 0 )
               {
                  AV12Insert_SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SecParentFunctionalityId", StringUtil.LTrimStr( (decimal)(AV12Insert_SecParentFunctionalityId), 10, 0));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
         edtSecParentFunctionalityId_Visible = 0;
         AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Visible), 5, 0), true);
         edtSecFunctionalityActive_Visible = 0;
         AssignProp("", false, edtSecFunctionalityActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityActive_Visible), 5, 0), true);
      }

      protected void E120E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpbaseobjects.secfunctionalityww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0E17( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z130SecFunctionalityKey = T000E3_A130SecFunctionalityKey[0];
               Z135SecFunctionalityDescription = T000E3_A135SecFunctionalityDescription[0];
               Z789SecFunctionalityModule = T000E3_A789SecFunctionalityModule[0];
               Z136SecFunctionalityType = T000E3_A136SecFunctionalityType[0];
               Z134SecFunctionalityActive = T000E3_A134SecFunctionalityActive[0];
               Z129SecParentFunctionalityId = T000E3_A129SecParentFunctionalityId[0];
            }
            else
            {
               Z130SecFunctionalityKey = A130SecFunctionalityKey;
               Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
               Z789SecFunctionalityModule = A789SecFunctionalityModule;
               Z136SecFunctionalityType = A136SecFunctionalityType;
               Z134SecFunctionalityActive = A134SecFunctionalityActive;
               Z129SecParentFunctionalityId = A129SecParentFunctionalityId;
            }
         }
         if ( GX_JID == -10 )
         {
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z130SecFunctionalityKey = A130SecFunctionalityKey;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
            Z789SecFunctionalityModule = A789SecFunctionalityModule;
            Z136SecFunctionalityType = A136SecFunctionalityType;
            Z134SecFunctionalityActive = A134SecFunctionalityActive;
            Z129SecParentFunctionalityId = A129SecParentFunctionalityId;
            Z138SecParentFunctionalityDescription = A138SecParentFunctionalityDescription;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityKey_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityKey_Enabled), 5, 0), true);
         cmbSecFunctionalityType.Enabled = 0;
         AssignProp("", false, cmbSecFunctionalityType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecFunctionalityType.Enabled), 5, 0), true);
         AV19Pgmname = "WWPBaseObjects.SecFunctionality";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityKey_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityKey_Enabled), 5, 0), true);
         cmbSecFunctionalityType.Enabled = 0;
         AssignProp("", false, cmbSecFunctionalityType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecFunctionalityType.Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SecFunctionalityId) )
         {
            A128SecFunctionalityId = AV7SecFunctionalityId;
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecParentFunctionalityId) )
         {
            edtSecParentFunctionalityId_Enabled = 0;
            AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Enabled), 5, 0), true);
         }
         else
         {
            edtSecParentFunctionalityId_Enabled = 1;
            AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Enabled), 5, 0), true);
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
      }

      protected void Load0E17( )
      {
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
            A130SecFunctionalityKey = T000E5_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = T000E5_n130SecFunctionalityKey[0];
            AssignAttri("", false, "A130SecFunctionalityKey", A130SecFunctionalityKey);
            A135SecFunctionalityDescription = T000E5_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = T000E5_n135SecFunctionalityDescription[0];
            AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
            A789SecFunctionalityModule = T000E5_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = T000E5_n789SecFunctionalityModule[0];
            A136SecFunctionalityType = T000E5_A136SecFunctionalityType[0];
            n136SecFunctionalityType = T000E5_n136SecFunctionalityType[0];
            AssignAttri("", false, "A136SecFunctionalityType", ((0==A136SecFunctionalityType)&&IsIns( )||n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            A138SecParentFunctionalityDescription = T000E5_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = T000E5_n138SecParentFunctionalityDescription[0];
            A134SecFunctionalityActive = T000E5_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = T000E5_n134SecFunctionalityActive[0];
            AssignAttri("", false, "A134SecFunctionalityActive", A134SecFunctionalityActive);
            A129SecParentFunctionalityId = T000E5_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = T000E5_n129SecParentFunctionalityId[0];
            AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            ZM0E17( -10) ;
         }
         pr_default.close(3);
         OnLoadActions0E17( ) ;
      }

      protected void OnLoadActions0E17( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecParentFunctionalityId) )
         {
            A129SecParentFunctionalityId = AV12Insert_SecParentFunctionalityId;
            n129SecParentFunctionalityId = false;
            AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
         }
         else
         {
            if ( (0==A129SecParentFunctionalityId) )
            {
               A129SecParentFunctionalityId = 0;
               n129SecParentFunctionalityId = false;
               AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
               n129SecParentFunctionalityId = true;
               n129SecParentFunctionalityId = true;
               AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            }
         }
      }

      protected void CheckExtendedTable0E17( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecParentFunctionalityId) )
         {
            A129SecParentFunctionalityId = AV12Insert_SecParentFunctionalityId;
            n129SecParentFunctionalityId = false;
            AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
         }
         else
         {
            if ( (0==A129SecParentFunctionalityId) )
            {
               A129SecParentFunctionalityId = 0;
               n129SecParentFunctionalityId = false;
               AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
               n129SecParentFunctionalityId = true;
               n129SecParentFunctionalityId = true;
               AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            }
         }
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, A128SecFunctionalityId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Functionality Key"}), 1, "SECFUNCTIONALITYKEY");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {n129SecParentFunctionalityId, A129SecParentFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A129SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec Functionality Functionality'.", "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecParentFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A138SecParentFunctionalityDescription = T000E4_A138SecParentFunctionalityDescription[0];
         n138SecParentFunctionalityDescription = T000E4_n138SecParentFunctionalityDescription[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0E17( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( long A129SecParentFunctionalityId )
      {
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {n129SecParentFunctionalityId, A129SecParentFunctionalityId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A129SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec Functionality Functionality'.", "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecParentFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A138SecParentFunctionalityDescription = T000E7_A138SecParentFunctionalityDescription[0];
         n138SecParentFunctionalityDescription = T000E7_n138SecParentFunctionalityDescription[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A138SecParentFunctionalityDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey0E17( )
      {
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E17( 10) ;
            RcdFound17 = 1;
            A128SecFunctionalityId = T000E3_A128SecFunctionalityId[0];
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            A130SecFunctionalityKey = T000E3_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = T000E3_n130SecFunctionalityKey[0];
            AssignAttri("", false, "A130SecFunctionalityKey", A130SecFunctionalityKey);
            A135SecFunctionalityDescription = T000E3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = T000E3_n135SecFunctionalityDescription[0];
            AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
            A789SecFunctionalityModule = T000E3_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = T000E3_n789SecFunctionalityModule[0];
            A136SecFunctionalityType = T000E3_A136SecFunctionalityType[0];
            n136SecFunctionalityType = T000E3_n136SecFunctionalityType[0];
            AssignAttri("", false, "A136SecFunctionalityType", ((0==A136SecFunctionalityType)&&IsIns( )||n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            A134SecFunctionalityActive = T000E3_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = T000E3_n134SecFunctionalityActive[0];
            AssignAttri("", false, "A134SecFunctionalityActive", A134SecFunctionalityActive);
            A129SecParentFunctionalityId = T000E3_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = T000E3_n129SecParentFunctionalityId[0];
            AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            Z128SecFunctionalityId = A128SecFunctionalityId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0E17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0E17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0E17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E17( ) ;
         if ( RcdFound17 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound17 = 0;
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000E9_A128SecFunctionalityId[0] < A128SecFunctionalityId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000E9_A128SecFunctionalityId[0] > A128SecFunctionalityId ) ) )
            {
               A128SecFunctionalityId = T000E9_A128SecFunctionalityId[0];
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000E10 */
         pr_default.execute(8, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000E10_A128SecFunctionalityId[0] > A128SecFunctionalityId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000E10_A128SecFunctionalityId[0] < A128SecFunctionalityId ) ) )
            {
               A128SecFunctionalityId = T000E10_A128SecFunctionalityId[0];
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecFunctionalityDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A128SecFunctionalityId != Z128SecFunctionalityId )
               {
                  A128SecFunctionalityId = Z128SecFunctionalityId;
                  AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECFUNCTIONALITYID");
                  AnyError = 1;
                  GX_FocusControl = edtSecFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecFunctionalityDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0E17( ) ;
                  GX_FocusControl = edtSecFunctionalityDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A128SecFunctionalityId != Z128SecFunctionalityId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSecFunctionalityDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECFUNCTIONALITYID");
                     AnyError = 1;
                     GX_FocusControl = edtSecFunctionalityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSecFunctionalityDescription_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E17( ) ;
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
         if ( A128SecFunctionalityId != Z128SecFunctionalityId )
         {
            A128SecFunctionalityId = Z128SecFunctionalityId;
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecFunctionalityDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0E17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionality"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z130SecFunctionalityKey, T000E2_A130SecFunctionalityKey[0]) != 0 ) || ( StringUtil.StrCmp(Z135SecFunctionalityDescription, T000E2_A135SecFunctionalityDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z789SecFunctionalityModule, T000E2_A789SecFunctionalityModule[0]) != 0 ) || ( Z136SecFunctionalityType != T000E2_A136SecFunctionalityType[0] ) || ( Z134SecFunctionalityActive != T000E2_A134SecFunctionalityActive[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z129SecParentFunctionalityId != T000E2_A129SecParentFunctionalityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z130SecFunctionalityKey, T000E2_A130SecFunctionalityKey[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityKey");
                  GXUtil.WriteLogRaw("Old: ",Z130SecFunctionalityKey);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A130SecFunctionalityKey[0]);
               }
               if ( StringUtil.StrCmp(Z135SecFunctionalityDescription, T000E2_A135SecFunctionalityDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityDescription");
                  GXUtil.WriteLogRaw("Old: ",Z135SecFunctionalityDescription);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A135SecFunctionalityDescription[0]);
               }
               if ( StringUtil.StrCmp(Z789SecFunctionalityModule, T000E2_A789SecFunctionalityModule[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityModule");
                  GXUtil.WriteLogRaw("Old: ",Z789SecFunctionalityModule);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A789SecFunctionalityModule[0]);
               }
               if ( Z136SecFunctionalityType != T000E2_A136SecFunctionalityType[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityType");
                  GXUtil.WriteLogRaw("Old: ",Z136SecFunctionalityType);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A136SecFunctionalityType[0]);
               }
               if ( Z134SecFunctionalityActive != T000E2_A134SecFunctionalityActive[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecFunctionalityActive");
                  GXUtil.WriteLogRaw("Old: ",Z134SecFunctionalityActive);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A134SecFunctionalityActive[0]);
               }
               if ( Z129SecParentFunctionalityId != T000E2_A129SecParentFunctionalityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionality:[seudo value changed for attri]"+"SecParentFunctionalityId");
                  GXUtil.WriteLogRaw("Old: ",Z129SecParentFunctionalityId);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A129SecParentFunctionalityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecFunctionality"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E17( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E17( 0) ;
            CheckOptimisticConcurrency0E17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E11 */
                     pr_default.execute(9, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, n135SecFunctionalityDescription, A135SecFunctionalityDescription, n789SecFunctionalityModule, A789SecFunctionalityModule, n136SecFunctionalityType, A136SecFunctionalityType, n134SecFunctionalityActive, A134SecFunctionalityActive, n129SecParentFunctionalityId, A129SecParentFunctionalityId});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000E12 */
                     pr_default.execute(10);
                     A128SecFunctionalityId = T000E12_A128SecFunctionalityId[0];
                     AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
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
               Load0E17( ) ;
            }
            EndLevel0E17( ) ;
         }
         CloseExtendedTableCursors0E17( ) ;
      }

      protected void Update0E17( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E13 */
                     pr_default.execute(11, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, n135SecFunctionalityDescription, A135SecFunctionalityDescription, n789SecFunctionalityModule, A789SecFunctionalityModule, n136SecFunctionalityType, A136SecFunctionalityType, n134SecFunctionalityActive, A134SecFunctionalityActive, n129SecParentFunctionalityId, A129SecParentFunctionalityId, A128SecFunctionalityId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionality"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E17( ) ;
                     if ( AnyError == 0 )
                     {
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
            EndLevel0E17( ) ;
         }
         CloseExtendedTableCursors0E17( ) ;
      }

      protected void DeferredUpdate0E17( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E17( ) ;
            AfterConfirm0E17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E14 */
                  pr_default.execute(12, new Object[] {A128SecFunctionalityId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000E15 */
            pr_default.execute(13, new Object[] {n129SecParentFunctionalityId, A129SecParentFunctionalityId});
            A138SecParentFunctionalityDescription = T000E15_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = T000E15_n138SecParentFunctionalityDescription[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000E16 */
            pr_default.execute(14, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionality"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000E17 */
            pr_default.execute(15, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionalities"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000E18 */
            pr_default.execute(16, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionality Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel0E17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.secfunctionality",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.secfunctionality",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E17( )
      {
         /* Scan By routine */
         /* Using cursor T000E19 */
         pr_default.execute(17);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound17 = 1;
            A128SecFunctionalityId = T000E19_A128SecFunctionalityId[0];
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E17( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound17 = 1;
            A128SecFunctionalityId = T000E19_A128SecFunctionalityId[0];
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
         }
      }

      protected void ScanEnd0E17( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0E17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E17( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityKey_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityKey_Enabled), 5, 0), true);
         edtSecFunctionalityDescription_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), true);
         cmbSecFunctionalityType.Enabled = 0;
         AssignProp("", false, cmbSecFunctionalityType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecFunctionalityType.Enabled), 5, 0), true);
         edtSecParentFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecParentFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecParentFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityActive_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityActive_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecFunctionalityId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SecFunctionality");
         forbiddenHiddens.Add("SecFunctionalityId", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("SecFunctionalityKey", StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")));
         forbiddenHiddens.Add("SecFunctionalityType", context.localUtil.Format( (decimal)(A136SecFunctionalityType), "Z9"));
         forbiddenHiddens.Add("Insert_SecParentFunctionalityId", context.localUtil.Format( (decimal)(AV12Insert_SecParentFunctionalityId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("SecFunctionalityModule", StringUtil.RTrim( context.localUtil.Format( A789SecFunctionalityModule, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wwpbaseobjects\\secfunctionality:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z128SecFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128SecFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z130SecFunctionalityKey", Z130SecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, "Z135SecFunctionalityDescription", Z135SecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "Z789SecFunctionalityModule", Z789SecFunctionalityModule);
         GxWebStd.gx_hidden_field( context, "Z136SecFunctionalityType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z136SecFunctionalityType), 2, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z134SecFunctionalityActive", Z134SecFunctionalityActive);
         GxWebStd.gx_hidden_field( context, "Z129SecParentFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z129SecParentFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N129SecParentFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SecFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECPARENTFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SecParentFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYMODULE", A789SecFunctionalityModule);
         GxWebStd.gx_hidden_field( context, "SECPARENTFUNCTIONALITYDESCRIPTION", A138SecParentFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
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
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecFunctionalityId,10,0));
         return formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecFunctionality" ;
      }

      public override string GetPgmdesc( )
      {
         return "Functionality" ;
      }

      protected void InitializeNonKey0E17( )
      {
         A129SecParentFunctionalityId = 0;
         n129SecParentFunctionalityId = false;
         AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
         n129SecParentFunctionalityId = ((0==A129SecParentFunctionalityId) ? true : false);
         A130SecFunctionalityKey = "";
         n130SecFunctionalityKey = false;
         AssignAttri("", false, "A130SecFunctionalityKey", A130SecFunctionalityKey);
         n130SecFunctionalityKey = (String.IsNullOrEmpty(StringUtil.RTrim( A130SecFunctionalityKey)) ? true : false);
         A135SecFunctionalityDescription = "";
         n135SecFunctionalityDescription = false;
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
         n135SecFunctionalityDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A135SecFunctionalityDescription)) ? true : false);
         A789SecFunctionalityModule = "";
         n789SecFunctionalityModule = false;
         AssignAttri("", false, "A789SecFunctionalityModule", A789SecFunctionalityModule);
         A136SecFunctionalityType = 0;
         n136SecFunctionalityType = false;
         AssignAttri("", false, "A136SecFunctionalityType", ((0==A136SecFunctionalityType)&&IsIns( )||n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
         n136SecFunctionalityType = ((0==A136SecFunctionalityType) ? true : false);
         A138SecParentFunctionalityDescription = "";
         n138SecParentFunctionalityDescription = false;
         AssignAttri("", false, "A138SecParentFunctionalityDescription", A138SecParentFunctionalityDescription);
         A134SecFunctionalityActive = false;
         n134SecFunctionalityActive = false;
         AssignAttri("", false, "A134SecFunctionalityActive", A134SecFunctionalityActive);
         n134SecFunctionalityActive = ((false==A134SecFunctionalityActive) ? true : false);
         Z130SecFunctionalityKey = "";
         Z135SecFunctionalityDescription = "";
         Z789SecFunctionalityModule = "";
         Z136SecFunctionalityType = 0;
         Z134SecFunctionalityActive = false;
         Z129SecParentFunctionalityId = 0;
      }

      protected void InitAll0E17( )
      {
         A128SecFunctionalityId = 0;
         AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
         InitializeNonKey0E17( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019124380", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secfunctionality.js", "?202561019124381", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID";
         edtSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE";
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
         Form.Caption = "Functionality";
         edtSecFunctionalityActive_Jsonclick = "";
         edtSecFunctionalityActive_Enabled = 1;
         edtSecFunctionalityActive_Visible = 1;
         edtSecParentFunctionalityId_Jsonclick = "";
         edtSecParentFunctionalityId_Enabled = 1;
         edtSecParentFunctionalityId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbSecFunctionalityType_Jsonclick = "";
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Enabled = 1;
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityId_Jsonclick = "";
         edtSecFunctionalityId_Enabled = 0;
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

      protected void init_web_controls( )
      {
         cmbSecFunctionalityType.Name = "SECFUNCTIONALITYTYPE";
         cmbSecFunctionalityType.WebTags = "";
         cmbSecFunctionalityType.addItem("1", "Mode", 0);
         cmbSecFunctionalityType.addItem("2", "Action", 0);
         cmbSecFunctionalityType.addItem("3", "Tab", 0);
         cmbSecFunctionalityType.addItem("4", "Object", 0);
         cmbSecFunctionalityType.addItem("5", "Attribute", 0);
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            n136SecFunctionalityType = false;
            AssignAttri("", false, "A136SecFunctionalityType", ((0==A136SecFunctionalityType)&&IsIns( )||n136SecFunctionalityType ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
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

      public void Valid_Secfunctionalitykey( )
      {
         n130SecFunctionalityKey = false;
         /* Using cursor T000E20 */
         pr_default.execute(18, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, A128SecFunctionalityId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Functionality Key"}), 1, "SECFUNCTIONALITYKEY");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityKey_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Secparentfunctionalityid( )
      {
         n138SecParentFunctionalityDescription = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SecParentFunctionalityId) )
         {
            A129SecParentFunctionalityId = AV12Insert_SecParentFunctionalityId;
            n129SecParentFunctionalityId = false;
         }
         else
         {
            if ( (0==A129SecParentFunctionalityId) )
            {
               A129SecParentFunctionalityId = 0;
               n129SecParentFunctionalityId = false;
               n129SecParentFunctionalityId = true;
               n129SecParentFunctionalityId = true;
            }
         }
         /* Using cursor T000E15 */
         pr_default.execute(13, new Object[] {n129SecParentFunctionalityId, A129SecParentFunctionalityId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A129SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec Functionality Functionality'.", "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecParentFunctionalityId_Internalname;
            }
         }
         A138SecParentFunctionalityDescription = T000E15_A138SecParentFunctionalityDescription[0];
         n138SecParentFunctionalityDescription = T000E15_n138SecParentFunctionalityDescription[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A129SecParentFunctionalityId", ((0==A129SecParentFunctionalityId)&&IsIns( )||n129SecParentFunctionalityId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
         AssignAttri("", false, "A138SecParentFunctionalityDescription", A138SecParentFunctionalityDescription);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SecFunctionalityId","fld":"vSECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7SecFunctionalityId","fld":"vSECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A130SecFunctionalityKey","fld":"SECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"cmbSecFunctionalityType"},{"av":"A136SecFunctionalityType","fld":"SECFUNCTIONALITYTYPE","pic":"Z9","nullAv":"n136SecFunctionalityType","type":"int"},{"av":"AV12Insert_SecParentFunctionalityId","fld":"vINSERT_SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A789SecFunctionalityModule","fld":"SECFUNCTIONALITYMODULE","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120E2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYKEY","""{"handler":"Valid_Secfunctionalitykey","iparms":[{"av":"A130SecFunctionalityKey","fld":"SECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID","""{"handler":"Valid_Secparentfunctionalityid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_SecParentFunctionalityId","fld":"vINSERT_SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A129SecParentFunctionalityId","fld":"SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","nullAv":"n129SecParentFunctionalityId","type":"int"},{"av":"A138SecParentFunctionalityDescription","fld":"SECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"}]""");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID",""","oparms":[{"av":"A129SecParentFunctionalityId","fld":"SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","nullAv":"n129SecParentFunctionalityId","type":"int"},{"av":"A138SecParentFunctionalityDescription","fld":"SECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"}]}""");
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
         wcpOGx_mode = "";
         Z130SecFunctionalityKey = "";
         Z135SecFunctionalityDescription = "";
         Z789SecFunctionalityModule = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A789SecFunctionalityModule = "";
         A138SecParentFunctionalityDescription = "";
         AV19Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode17 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV18WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z138SecParentFunctionalityDescription = "";
         T000E5_A128SecFunctionalityId = new long[1] ;
         T000E5_A130SecFunctionalityKey = new string[] {""} ;
         T000E5_n130SecFunctionalityKey = new bool[] {false} ;
         T000E5_A135SecFunctionalityDescription = new string[] {""} ;
         T000E5_n135SecFunctionalityDescription = new bool[] {false} ;
         T000E5_A789SecFunctionalityModule = new string[] {""} ;
         T000E5_n789SecFunctionalityModule = new bool[] {false} ;
         T000E5_A136SecFunctionalityType = new short[1] ;
         T000E5_n136SecFunctionalityType = new bool[] {false} ;
         T000E5_A138SecParentFunctionalityDescription = new string[] {""} ;
         T000E5_n138SecParentFunctionalityDescription = new bool[] {false} ;
         T000E5_A134SecFunctionalityActive = new bool[] {false} ;
         T000E5_n134SecFunctionalityActive = new bool[] {false} ;
         T000E5_A129SecParentFunctionalityId = new long[1] ;
         T000E5_n129SecParentFunctionalityId = new bool[] {false} ;
         T000E6_A130SecFunctionalityKey = new string[] {""} ;
         T000E6_n130SecFunctionalityKey = new bool[] {false} ;
         T000E4_A138SecParentFunctionalityDescription = new string[] {""} ;
         T000E4_n138SecParentFunctionalityDescription = new bool[] {false} ;
         T000E7_A138SecParentFunctionalityDescription = new string[] {""} ;
         T000E7_n138SecParentFunctionalityDescription = new bool[] {false} ;
         T000E8_A128SecFunctionalityId = new long[1] ;
         T000E3_A128SecFunctionalityId = new long[1] ;
         T000E3_A130SecFunctionalityKey = new string[] {""} ;
         T000E3_n130SecFunctionalityKey = new bool[] {false} ;
         T000E3_A135SecFunctionalityDescription = new string[] {""} ;
         T000E3_n135SecFunctionalityDescription = new bool[] {false} ;
         T000E3_A789SecFunctionalityModule = new string[] {""} ;
         T000E3_n789SecFunctionalityModule = new bool[] {false} ;
         T000E3_A136SecFunctionalityType = new short[1] ;
         T000E3_n136SecFunctionalityType = new bool[] {false} ;
         T000E3_A134SecFunctionalityActive = new bool[] {false} ;
         T000E3_n134SecFunctionalityActive = new bool[] {false} ;
         T000E3_A129SecParentFunctionalityId = new long[1] ;
         T000E3_n129SecParentFunctionalityId = new bool[] {false} ;
         T000E9_A128SecFunctionalityId = new long[1] ;
         T000E10_A128SecFunctionalityId = new long[1] ;
         T000E2_A128SecFunctionalityId = new long[1] ;
         T000E2_A130SecFunctionalityKey = new string[] {""} ;
         T000E2_n130SecFunctionalityKey = new bool[] {false} ;
         T000E2_A135SecFunctionalityDescription = new string[] {""} ;
         T000E2_n135SecFunctionalityDescription = new bool[] {false} ;
         T000E2_A789SecFunctionalityModule = new string[] {""} ;
         T000E2_n789SecFunctionalityModule = new bool[] {false} ;
         T000E2_A136SecFunctionalityType = new short[1] ;
         T000E2_n136SecFunctionalityType = new bool[] {false} ;
         T000E2_A134SecFunctionalityActive = new bool[] {false} ;
         T000E2_n134SecFunctionalityActive = new bool[] {false} ;
         T000E2_A129SecParentFunctionalityId = new long[1] ;
         T000E2_n129SecParentFunctionalityId = new bool[] {false} ;
         T000E12_A128SecFunctionalityId = new long[1] ;
         T000E15_A138SecParentFunctionalityDescription = new string[] {""} ;
         T000E15_n138SecParentFunctionalityDescription = new bool[] {false} ;
         T000E16_A129SecParentFunctionalityId = new long[1] ;
         T000E16_n129SecParentFunctionalityId = new bool[] {false} ;
         T000E17_A132SecObjectName = new string[] {""} ;
         T000E17_A128SecFunctionalityId = new long[1] ;
         T000E18_A128SecFunctionalityId = new long[1] ;
         T000E18_A131SecRoleId = new short[1] ;
         T000E19_A128SecFunctionalityId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000E20_A130SecFunctionalityKey = new string[] {""} ;
         T000E20_n130SecFunctionalityKey = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionality__default(),
            new Object[][] {
                new Object[] {
               T000E2_A128SecFunctionalityId, T000E2_A130SecFunctionalityKey, T000E2_n130SecFunctionalityKey, T000E2_A135SecFunctionalityDescription, T000E2_n135SecFunctionalityDescription, T000E2_A789SecFunctionalityModule, T000E2_n789SecFunctionalityModule, T000E2_A136SecFunctionalityType, T000E2_n136SecFunctionalityType, T000E2_A134SecFunctionalityActive,
               T000E2_n134SecFunctionalityActive, T000E2_A129SecParentFunctionalityId, T000E2_n129SecParentFunctionalityId
               }
               , new Object[] {
               T000E3_A128SecFunctionalityId, T000E3_A130SecFunctionalityKey, T000E3_n130SecFunctionalityKey, T000E3_A135SecFunctionalityDescription, T000E3_n135SecFunctionalityDescription, T000E3_A789SecFunctionalityModule, T000E3_n789SecFunctionalityModule, T000E3_A136SecFunctionalityType, T000E3_n136SecFunctionalityType, T000E3_A134SecFunctionalityActive,
               T000E3_n134SecFunctionalityActive, T000E3_A129SecParentFunctionalityId, T000E3_n129SecParentFunctionalityId
               }
               , new Object[] {
               T000E4_A138SecParentFunctionalityDescription, T000E4_n138SecParentFunctionalityDescription
               }
               , new Object[] {
               T000E5_A128SecFunctionalityId, T000E5_A130SecFunctionalityKey, T000E5_n130SecFunctionalityKey, T000E5_A135SecFunctionalityDescription, T000E5_n135SecFunctionalityDescription, T000E5_A789SecFunctionalityModule, T000E5_n789SecFunctionalityModule, T000E5_A136SecFunctionalityType, T000E5_n136SecFunctionalityType, T000E5_A138SecParentFunctionalityDescription,
               T000E5_n138SecParentFunctionalityDescription, T000E5_A134SecFunctionalityActive, T000E5_n134SecFunctionalityActive, T000E5_A129SecParentFunctionalityId, T000E5_n129SecParentFunctionalityId
               }
               , new Object[] {
               T000E6_A130SecFunctionalityKey, T000E6_n130SecFunctionalityKey
               }
               , new Object[] {
               T000E7_A138SecParentFunctionalityDescription, T000E7_n138SecParentFunctionalityDescription
               }
               , new Object[] {
               T000E8_A128SecFunctionalityId
               }
               , new Object[] {
               T000E9_A128SecFunctionalityId
               }
               , new Object[] {
               T000E10_A128SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               T000E12_A128SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E15_A138SecParentFunctionalityDescription, T000E15_n138SecParentFunctionalityDescription
               }
               , new Object[] {
               T000E16_A129SecParentFunctionalityId
               }
               , new Object[] {
               T000E17_A132SecObjectName, T000E17_A128SecFunctionalityId
               }
               , new Object[] {
               T000E18_A128SecFunctionalityId, T000E18_A131SecRoleId
               }
               , new Object[] {
               T000E19_A128SecFunctionalityId
               }
               , new Object[] {
               T000E20_A130SecFunctionalityKey, T000E20_n130SecFunctionalityKey
               }
            }
         );
         AV19Pgmname = "WWPBaseObjects.SecFunctionality";
      }

      private short Z136SecFunctionalityType ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A136SecFunctionalityType ;
      private short RcdFound17 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSecParentFunctionalityId_Visible ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int edtSecFunctionalityActive_Visible ;
      private int edtSecFunctionalityActive_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private long wcpOAV7SecFunctionalityId ;
      private long Z128SecFunctionalityId ;
      private long Z129SecParentFunctionalityId ;
      private long N129SecParentFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long AV7SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long AV12Insert_SecParentFunctionalityId ;
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
      private string edtSecFunctionalityDescription_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
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
      private string edtSecFunctionalityId_Internalname ;
      private string TempTags ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Internalname ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityActive_Internalname ;
      private string edtSecFunctionalityActive_Jsonclick ;
      private string AV19Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode17 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool Z134SecFunctionalityActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n129SecParentFunctionalityId ;
      private bool wbErr ;
      private bool n136SecFunctionalityType ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A134SecFunctionalityActive ;
      private bool n130SecFunctionalityKey ;
      private bool n135SecFunctionalityDescription ;
      private bool n789SecFunctionalityModule ;
      private bool n134SecFunctionalityActive ;
      private bool n138SecParentFunctionalityDescription ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z130SecFunctionalityKey ;
      private string Z135SecFunctionalityDescription ;
      private string Z789SecFunctionalityModule ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A789SecFunctionalityModule ;
      private string A138SecParentFunctionalityDescription ;
      private string Z138SecParentFunctionalityDescription ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSecFunctionalityType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T000E5_A128SecFunctionalityId ;
      private string[] T000E5_A130SecFunctionalityKey ;
      private bool[] T000E5_n130SecFunctionalityKey ;
      private string[] T000E5_A135SecFunctionalityDescription ;
      private bool[] T000E5_n135SecFunctionalityDescription ;
      private string[] T000E5_A789SecFunctionalityModule ;
      private bool[] T000E5_n789SecFunctionalityModule ;
      private short[] T000E5_A136SecFunctionalityType ;
      private bool[] T000E5_n136SecFunctionalityType ;
      private string[] T000E5_A138SecParentFunctionalityDescription ;
      private bool[] T000E5_n138SecParentFunctionalityDescription ;
      private bool[] T000E5_A134SecFunctionalityActive ;
      private bool[] T000E5_n134SecFunctionalityActive ;
      private long[] T000E5_A129SecParentFunctionalityId ;
      private bool[] T000E5_n129SecParentFunctionalityId ;
      private string[] T000E6_A130SecFunctionalityKey ;
      private bool[] T000E6_n130SecFunctionalityKey ;
      private string[] T000E4_A138SecParentFunctionalityDescription ;
      private bool[] T000E4_n138SecParentFunctionalityDescription ;
      private string[] T000E7_A138SecParentFunctionalityDescription ;
      private bool[] T000E7_n138SecParentFunctionalityDescription ;
      private long[] T000E8_A128SecFunctionalityId ;
      private long[] T000E3_A128SecFunctionalityId ;
      private string[] T000E3_A130SecFunctionalityKey ;
      private bool[] T000E3_n130SecFunctionalityKey ;
      private string[] T000E3_A135SecFunctionalityDescription ;
      private bool[] T000E3_n135SecFunctionalityDescription ;
      private string[] T000E3_A789SecFunctionalityModule ;
      private bool[] T000E3_n789SecFunctionalityModule ;
      private short[] T000E3_A136SecFunctionalityType ;
      private bool[] T000E3_n136SecFunctionalityType ;
      private bool[] T000E3_A134SecFunctionalityActive ;
      private bool[] T000E3_n134SecFunctionalityActive ;
      private long[] T000E3_A129SecParentFunctionalityId ;
      private bool[] T000E3_n129SecParentFunctionalityId ;
      private long[] T000E9_A128SecFunctionalityId ;
      private long[] T000E10_A128SecFunctionalityId ;
      private long[] T000E2_A128SecFunctionalityId ;
      private string[] T000E2_A130SecFunctionalityKey ;
      private bool[] T000E2_n130SecFunctionalityKey ;
      private string[] T000E2_A135SecFunctionalityDescription ;
      private bool[] T000E2_n135SecFunctionalityDescription ;
      private string[] T000E2_A789SecFunctionalityModule ;
      private bool[] T000E2_n789SecFunctionalityModule ;
      private short[] T000E2_A136SecFunctionalityType ;
      private bool[] T000E2_n136SecFunctionalityType ;
      private bool[] T000E2_A134SecFunctionalityActive ;
      private bool[] T000E2_n134SecFunctionalityActive ;
      private long[] T000E2_A129SecParentFunctionalityId ;
      private bool[] T000E2_n129SecParentFunctionalityId ;
      private long[] T000E12_A128SecFunctionalityId ;
      private string[] T000E15_A138SecParentFunctionalityDescription ;
      private bool[] T000E15_n138SecParentFunctionalityDescription ;
      private long[] T000E16_A129SecParentFunctionalityId ;
      private bool[] T000E16_n129SecParentFunctionalityId ;
      private string[] T000E17_A132SecObjectName ;
      private long[] T000E17_A128SecFunctionalityId ;
      private long[] T000E18_A128SecFunctionalityId ;
      private short[] T000E18_A131SecRoleId ;
      private long[] T000E19_A128SecFunctionalityId ;
      private string[] T000E20_A130SecFunctionalityKey ;
      private bool[] T000E20_n130SecFunctionalityKey ;
   }

   public class secfunctionality__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000E2;
          prmT000E2 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E3;
          prmT000E3 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E4;
          prmT000E4 = new Object[] {
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT000E5;
          prmT000E5 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E6;
          prmT000E6 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E7;
          prmT000E7 = new Object[] {
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT000E8;
          prmT000E8 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E9;
          prmT000E9 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E10;
          prmT000E10 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E11;
          prmT000E11 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityDescription",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityModule",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityType",GXType.Int16,2,0){Nullable=true} ,
          new ParDef("SecFunctionalityActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT000E12;
          prmT000E12 = new Object[] {
          };
          Object[] prmT000E13;
          prmT000E13 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityDescription",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityModule",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityType",GXType.Int16,2,0){Nullable=true} ,
          new ParDef("SecFunctionalityActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E14;
          prmT000E14 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E15;
          prmT000E15 = new Object[] {
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT000E16;
          prmT000E16 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E17;
          prmT000E17 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E18;
          prmT000E18 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000E19;
          prmT000E19 = new Object[] {
          };
          Object[] prmT000E20;
          prmT000E20 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000E2", "SELECT SecFunctionalityId, SecFunctionalityKey, SecFunctionalityDescription, SecFunctionalityModule, SecFunctionalityType, SecFunctionalityActive, SecParentFunctionalityId FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId  FOR UPDATE OF SecFunctionality NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E3", "SELECT SecFunctionalityId, SecFunctionalityKey, SecFunctionalityDescription, SecFunctionalityModule, SecFunctionalityType, SecFunctionalityActive, SecParentFunctionalityId FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E4", "SELECT SecFunctionalityDescription AS SecParentFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E5", "SELECT TM1.SecFunctionalityId, TM1.SecFunctionalityKey, TM1.SecFunctionalityDescription, TM1.SecFunctionalityModule, TM1.SecFunctionalityType, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, TM1.SecFunctionalityActive, TM1.SecParentFunctionalityId AS SecParentFunctionalityId FROM (SecFunctionality TM1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = TM1.SecParentFunctionalityId) WHERE TM1.SecFunctionalityId = :SecFunctionalityId ORDER BY TM1.SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E6", "SELECT SecFunctionalityKey FROM SecFunctionality WHERE (SecFunctionalityKey = :SecFunctionalityKey) AND (Not ( SecFunctionalityId = :SecFunctionalityId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E7", "SELECT SecFunctionalityDescription AS SecParentFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E8", "SELECT SecFunctionalityId FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E9", "SELECT SecFunctionalityId FROM SecFunctionality WHERE ( SecFunctionalityId > :SecFunctionalityId) ORDER BY SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E10", "SELECT SecFunctionalityId FROM SecFunctionality WHERE ( SecFunctionalityId < :SecFunctionalityId) ORDER BY SecFunctionalityId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E11", "SAVEPOINT gxupdate;INSERT INTO SecFunctionality(SecFunctionalityKey, SecFunctionalityDescription, SecFunctionalityModule, SecFunctionalityType, SecFunctionalityActive, SecParentFunctionalityId) VALUES(:SecFunctionalityKey, :SecFunctionalityDescription, :SecFunctionalityModule, :SecFunctionalityType, :SecFunctionalityActive, :SecParentFunctionalityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000E11)
             ,new CursorDef("T000E12", "SELECT currval('SecFunctionalityId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E13", "SAVEPOINT gxupdate;UPDATE SecFunctionality SET SecFunctionalityKey=:SecFunctionalityKey, SecFunctionalityDescription=:SecFunctionalityDescription, SecFunctionalityModule=:SecFunctionalityModule, SecFunctionalityType=:SecFunctionalityType, SecFunctionalityActive=:SecFunctionalityActive, SecParentFunctionalityId=:SecParentFunctionalityId  WHERE SecFunctionalityId = :SecFunctionalityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E13)
             ,new CursorDef("T000E14", "SAVEPOINT gxupdate;DELETE FROM SecFunctionality  WHERE SecFunctionalityId = :SecFunctionalityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E14)
             ,new CursorDef("T000E15", "SELECT SecFunctionalityDescription AS SecParentFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E16", "SELECT SecFunctionalityId AS SecParentFunctionalityId FROM SecFunctionality WHERE SecParentFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E17", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E18", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E19", "SELECT SecFunctionalityId FROM SecFunctionality ORDER BY SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E20", "SELECT SecFunctionalityKey FROM SecFunctionality WHERE (SecFunctionalityKey = :SecFunctionalityKey) AND (Not ( SecFunctionalityId = :SecFunctionalityId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E20,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((long[]) buf[13])[0] = rslt.getLong(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 16 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
