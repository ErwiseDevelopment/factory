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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class secusersecuserroleassociation : GXDataArea
   {
      public secusersecuserroleassociation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secusersecuserroleassociation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecUserId )
      {
         this.AV8SecUserId = aP0_SecUserId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         lstavNotassociatedrecords = new GXListbox();
         lstavAssociatedrecords = new GXListbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SecUserId");
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
               gxfirstwebparm = GetFirstPar( "SecUserId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SecUserId");
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA2K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2K2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secusersecuserroleassociation"+UrlEncode(StringUtil.LTrimStr(AV8SecUserId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("secusersecuserroleassociation") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecUserId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vADDEDKEYLIST", AV21AddedKeyList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vADDEDKEYLIST", AV21AddedKeyList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vADDEDDSCLIST", AV23AddedDscList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vADDEDDSCLIST", AV23AddedDscList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTADDEDKEYLIST", AV22NotAddedKeyList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTADDEDKEYLIST", AV22NotAddedKeyList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTADDEDDSCLIST", AV24NotAddedDscList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTADDEDDSCLIST", AV24NotAddedDscList);
         }
         GxWebStd.gx_hidden_field( context, "vADDEDKEYLISTXML", AV17AddedKeyListXml);
         GxWebStd.gx_hidden_field( context, "vADDEDDSCLISTXML", AV19AddedDscListXml);
         GxWebStd.gx_hidden_field( context, "vNOTADDEDKEYLISTXML", AV18NotAddedKeyListXml);
         GxWebStd.gx_hidden_field( context, "vNOTADDEDDSCLISTXML", AV20NotAddedDscListXml);
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECUSERROLE", AV12SecUserRole);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECUSERROLE", AV12SecUserRole);
         }
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SecRoleId), 4, 0, ",", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2K2( ) ;
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
         GXEncryptionTmp = "secusersecuserroleassociation"+UrlEncode(StringUtil.LTrimStr(AV8SecUserId,4,0));
         return formatLink("secusersecuserroleassociation") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SecUserSecUserRoleAssociation" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sec User Sec User Role Association" ;
      }

      protected void WB2K0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablefullcontent_Internalname, 1, 0, "px", 0, "px", "TableAssociation", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotassociated_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 AssociationTitleCell", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotassociatedrecordstitle_Internalname, "Registros N�o Associados", "", "", lblNotassociatedrecordstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AssociationTitle", 0, "", 1, 1, 0, 0, "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, lstavNotassociatedrecords_Internalname, "Not Associated Records", "col-sm-3 AssociationListAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            /* ListBox */
            GxWebStd.gx_listbox_ctrl1( context, lstavNotassociatedrecords, lstavNotassociatedrecords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0)), 2, lstavNotassociatedrecords_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, lstavNotassociatedrecords.Enabled, 0, 0, 4, "em", 0, "row", "", "AssociationListAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_SecUserSecUserRoleAssociation.htm");
            lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
            AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", (string)(lstavNotassociatedrecords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellTableAssociationButtons", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableassociationbuttons_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "AssociationImage" + " " + ((StringUtil.StrCmp(imgImageassociateall_gximage, "")==0) ? "GX_Image_AssociationItemsRight_Class" : "GX_Image_"+imgImageassociateall_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "6591e2a3-49b6-43b7-b8e3-a292564a32a4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageassociateall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImageassociateall_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ASSOCIATE ALL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "AssociationImage" + " " + ((StringUtil.StrCmp(imgImageassociateselected_gximage, "")==0) ? "GX_Image_AssociationRight_Class" : "GX_Image_"+imgImageassociateselected_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "56a5f17b-0bc3-48b5-b303-afa6e0585b6d", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageassociateselected_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImageassociateselected_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ASSOCIATE SELECTED\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "AssociationImage" + " " + ((StringUtil.StrCmp(imgImagedisassociateselected_gximage, "")==0) ? "GX_Image_AssociationLeft_Class" : "GX_Image_"+imgImagedisassociateselected_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "a3800d0c-bf04-4575-bc01-11fe5d7b3525", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImagedisassociateselected_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImagedisassociateselected_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DISASSOCIATE SELECTED\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "AssociationImage" + " " + ((StringUtil.StrCmp(imgImagedisassociateall_gximage, "")==0) ? "GX_Image_AssociationItemsLeft_Class" : "GX_Image_"+imgImagedisassociateall_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c619e28f-4b32-4ff9-baaf-b3063fe4f782", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImagedisassociateall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImagedisassociateall_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DISASSOCIATE ALL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableassociated_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 AssociationTitleCell", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAssociatedrecordstitle_Internalname, "Registros Associados", "", "", lblAssociatedrecordstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AssociationTitle", 0, "", 1, 1, 0, 0, "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, lstavAssociatedrecords_Internalname, "Associated Records", "col-sm-3 AssociationListAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            /* ListBox */
            GxWebStd.gx_listbox_ctrl1( context, lstavAssociatedrecords, lstavAssociatedrecords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0)), 2, lstavAssociatedrecords_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, lstavAssociatedrecords.Enabled, 0, 0, 4, "em", 0, "row", "", "AssociationListAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_SecUserSecUserRoleAssociation.htm");
            lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
            AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", (string)(lstavAssociatedrecords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirm_Internalname, "", "Confirmar", bttBtnconfirm_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserSecUserRoleAssociation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2K2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "Sec User Sec User Role Association", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2K0( ) ;
      }

      protected void WS2K2( )
      {
         START2K2( ) ;
         EVT2K2( ) ;
      }

      protected void EVT2K2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E112K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E122K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E132K2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DISASSOCIATE SELECTED'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Disassociate Selected' */
                              E142K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ASSOCIATE SELECTED'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Associate selected' */
                              E152K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ASSOCIATE ALL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Associate All' */
                              E162K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DISASSOCIATE ALL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Disassociate All' */
                              E172K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E182K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E192K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E202K2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E182K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E192K2 ();
                              dynload_actions( ) ;
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
      }

      protected void WE2K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA2K2( )
      {
         if ( nDonePA == 0 )
         {
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "secusersecuserroleassociation")), "secusersecuserroleassociation") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "secusersecuserroleassociation")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "SecUserId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8SecUserId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV8SecUserId", StringUtil.LTrimStr( (decimal)(AV8SecUserId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecUserId), "ZZZ9"), context));
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = lstavNotassociatedrecords_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( lstavNotassociatedrecords.ItemCount > 0 )
         {
            AV25NotAssociatedRecords = (short)(Math.Round(NumberUtil.Val( lstavNotassociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25NotAssociatedRecords), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
            AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
         }
         if ( lstavAssociatedrecords.ItemCount > 0 )
         {
            AV26AssociatedRecords = (short)(Math.Round(NumberUtil.Val( lstavAssociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV26AssociatedRecords), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
            AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122K2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E202K2 ();
            WB2K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2K2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            lstavNotassociatedrecords.CurrentValue = cgiGet( lstavNotassociatedrecords_Internalname);
            AV25NotAssociatedRecords = (short)(Math.Round(NumberUtil.Val( cgiGet( lstavNotassociatedrecords_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25NotAssociatedRecords), 4, 0));
            lstavAssociatedrecords.CurrentValue = cgiGet( lstavAssociatedrecords_Internalname);
            AV26AssociatedRecords = (short)(Math.Round(NumberUtil.Val( cgiGet( lstavAssociatedrecords_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV26AssociatedRecords), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E112K2 ();
         if (returnInSub) return;
      }

      protected void E112K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV30WWPContext) ;
         if ( StringUtil.StrCmp(AV10HTTPRequest.Method, "GET") == 0 )
         {
            AV31GXLvl8 = 0;
            /* Using cursor H002K2 */
            pr_default.execute(0, new Object[] {AV8SecUserId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A133SecUserId = H002K2_A133SecUserId[0];
               AV31GXLvl8 = 1;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV31GXLvl8 == 0 )
            {
               GX_msglist.addItem("Registro n�o encontrado");
            }
            /* Using cursor H002K3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A131SecRoleId = H002K3_A131SecRoleId[0];
               A140SecRoleName = H002K3_A140SecRoleName[0];
               A139SecRoleDescription = H002K3_A139SecRoleDescription[0];
               AV11Exist = false;
               /* Using cursor H002K4 */
               pr_default.execute(2, new Object[] {AV8SecUserId, A131SecRoleId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A133SecUserId = H002K4_A133SecUserId[0];
                  AV11Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               AV14Description = A139SecRoleDescription + " (" + A140SecRoleName + ")";
               if ( AV11Exist )
               {
                  AV27InsertIndex = 1;
                  while ( ( AV27InsertIndex <= AV23AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV23AddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
                  {
                     AV27InsertIndex = (int)(AV27InsertIndex+1);
                  }
                  AV21AddedKeyList.Add(A131SecRoleId, AV27InsertIndex);
                  AV23AddedDscList.Add(AV14Description, AV27InsertIndex);
               }
               else
               {
                  AV27InsertIndex = 1;
                  while ( ( AV27InsertIndex <= AV24NotAddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV24NotAddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
                  {
                     AV27InsertIndex = (int)(AV27InsertIndex+1);
                  }
                  AV22NotAddedKeyList.Add(A131SecRoleId, AV27InsertIndex);
                  AV24NotAddedDscList.Add(AV14Description, AV27InsertIndex);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Using cursor H002K5 */
         pr_default.execute(3, new Object[] {AV8SecUserId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A133SecUserId = H002K5_A133SecUserId[0];
            A141SecUserName = H002K5_A141SecUserName[0];
            n141SecUserName = H002K5_n141SecUserName[0];
            Form.Caption = StringUtil.Format( "Associate Roles to User :: %1", A141SecUserName, "", "", "", "", "", "", "", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void E122K2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E132K2 ();
         if (returnInSub) return;
      }

      protected void E132K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV13Success = true;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV21AddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV21AddedKeyList.GetNumeric(AV35GXV1));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            if ( AV13Success )
            {
               AV11Exist = false;
               /* Using cursor H002K6 */
               pr_default.execute(4, new Object[] {AV8SecUserId, AV9SecRoleId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A131SecRoleId = H002K6_A131SecRoleId[0];
                  A133SecUserId = H002K6_A133SecUserId[0];
                  AV11Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
               if ( ! AV11Exist )
               {
                  AV12SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
                  AV12SecUserRole.gxTpr_Secuserid = AV8SecUserId;
                  AV12SecUserRole.gxTpr_Secroleid = AV9SecRoleId;
                  AV12SecUserRole.Save();
                  if ( ! AV12SecUserRole.Success() )
                  {
                     AV13Success = false;
                  }
               }
            }
            AV15i = (int)(AV15i+1);
            AV35GXV1 = (int)(AV35GXV1+1);
         }
         AV15i = 1;
         AV37GXV2 = 1;
         while ( AV37GXV2 <= AV22NotAddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV22NotAddedKeyList.GetNumeric(AV37GXV2));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            if ( AV13Success )
            {
               AV11Exist = false;
               /* Using cursor H002K7 */
               pr_default.execute(5, new Object[] {AV8SecUserId, AV9SecRoleId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A131SecRoleId = H002K7_A131SecRoleId[0];
                  A133SecUserId = H002K7_A133SecUserId[0];
                  AV11Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
               if ( AV11Exist )
               {
                  AV12SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
                  AV12SecUserRole.Load(AV8SecUserId, AV9SecRoleId);
                  if ( AV12SecUserRole.Success() )
                  {
                     AV12SecUserRole.Delete();
                  }
                  if ( ! AV12SecUserRole.Success() )
                  {
                     AV13Success = false;
                  }
               }
            }
            AV15i = (int)(AV15i+1);
            AV37GXV2 = (int)(AV37GXV2+1);
         }
         if ( AV13Success )
         {
            context.CommitDataStores("secusersecuserroleassociation",pr_default);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12SecUserRole", AV12SecUserRole);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
      }

      protected void E142K2( )
      {
         /* 'Disassociate Selected' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISASSOCIATESELECTED' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E152K2( )
      {
         /* 'Associate selected' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATESELECTED' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E162K2( )
      {
         /* 'Associate All' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATEALL' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E172K2( )
      {
         /* 'Disassociate All' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATEALL' */
         S172 ();
         if (returnInSub) return;
         AV22NotAddedKeyList = (GxSimpleCollection<short>)(AV21AddedKeyList.Clone());
         AV24NotAddedDscList = (GxSimpleCollection<string>)(AV23AddedDscList.Clone());
         AV23AddedDscList.Clear();
         AV21AddedKeyList.Clear();
         /* Execute user subroutine: 'SAVELISTS' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E182K2( )
      {
         /* Associatedrecords_Dblclick Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISASSOCIATESELECTED' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E192K2( )
      {
         /* Notassociatedrecords_Dblclick Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATESELECTED' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24NotAddedDscList", AV24NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0));
         AssignProp("", false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0));
         AssignProp("", false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'UPDATEASSOCIATIONVARIABLES' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         lstavAssociatedrecords.removeAllItems();
         lstavNotassociatedrecords.removeAllItems();
         AV15i = 1;
         AV39GXV3 = 1;
         while ( AV39GXV3 <= AV21AddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV21AddedKeyList.GetNumeric(AV39GXV3));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            AV14Description = ((string)AV23AddedDscList.Item(AV15i));
            lstavAssociatedrecords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV9SecRoleId), 4, 0)), StringUtil.Trim( AV14Description), 0);
            AV15i = (int)(AV15i+1);
            AV39GXV3 = (int)(AV39GXV3+1);
         }
         AV15i = 1;
         AV40GXV4 = 1;
         while ( AV40GXV4 <= AV22NotAddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV22NotAddedKeyList.GetNumeric(AV40GXV4));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            AV14Description = ((string)AV24NotAddedDscList.Item(AV15i));
            lstavNotassociatedrecords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV9SecRoleId), 4, 0)), StringUtil.Trim( AV14Description), 0);
            AV15i = (int)(AV15i+1);
            AV40GXV4 = (int)(AV40GXV4+1);
         }
      }

      protected void S142( )
      {
         /* 'SHOW ERROR MESSAGES' Routine */
         returnInSub = false;
         AV42GXV6 = 1;
         AV41GXV5 = AV12SecUserRole.GetMessages();
         while ( AV42GXV6 <= AV41GXV5.Count )
         {
            AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV41GXV5.Item(AV42GXV6));
            if ( AV16Message.gxTpr_Type == 1 )
            {
               GX_msglist.addItem(AV16Message.gxTpr_Description);
            }
            AV42GXV6 = (int)(AV42GXV6+1);
         }
      }

      protected void S132( )
      {
         /* 'LOADLISTS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17AddedKeyListXml)) )
         {
            AV23AddedDscList.FromXml(AV19AddedDscListXml, null, "Collection", "");
            AV21AddedKeyList.FromXml(AV17AddedKeyListXml, null, "Collection", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18NotAddedKeyListXml)) )
         {
            AV22NotAddedKeyList.FromXml(AV18NotAddedKeyListXml, null, "Collection", "");
            AV24NotAddedDscList.FromXml(AV20NotAddedDscListXml, null, "Collection", "");
         }
      }

      protected void S112( )
      {
         /* 'SAVELISTS' Routine */
         returnInSub = false;
         if ( AV21AddedKeyList.Count > 0 )
         {
            AV17AddedKeyListXml = AV21AddedKeyList.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV17AddedKeyListXml", AV17AddedKeyListXml);
            AV19AddedDscListXml = AV23AddedDscList.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV19AddedDscListXml", AV19AddedDscListXml);
         }
         else
         {
            AV17AddedKeyListXml = "";
            AssignAttri("", false, "AV17AddedKeyListXml", AV17AddedKeyListXml);
            AV19AddedDscListXml = "";
            AssignAttri("", false, "AV19AddedDscListXml", AV19AddedDscListXml);
         }
         if ( AV22NotAddedKeyList.Count > 0 )
         {
            AV18NotAddedKeyListXml = AV22NotAddedKeyList.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV18NotAddedKeyListXml", AV18NotAddedKeyListXml);
            AV20NotAddedDscListXml = AV24NotAddedDscList.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV20NotAddedDscListXml", AV20NotAddedDscListXml);
         }
         else
         {
            AV18NotAddedKeyListXml = "";
            AssignAttri("", false, "AV18NotAddedKeyListXml", AV18NotAddedKeyListXml);
            AV20NotAddedDscListXml = "";
            AssignAttri("", false, "AV20NotAddedDscListXml", AV20NotAddedDscListXml);
         }
      }

      protected void S172( )
      {
         /* 'ASSOCIATEALL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV27InsertIndex = 1;
         AV43GXV7 = 1;
         while ( AV43GXV7 <= AV22NotAddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV22NotAddedKeyList.GetNumeric(AV43GXV7));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            AV14Description = ((string)AV24NotAddedDscList.Item(AV15i));
            while ( ( AV27InsertIndex <= AV23AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV23AddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV21AddedKeyList.Add(AV9SecRoleId, AV27InsertIndex);
            AV23AddedDscList.Add(AV14Description, AV27InsertIndex);
            AV15i = (int)(AV15i+1);
            AV43GXV7 = (int)(AV43GXV7+1);
         }
         AV22NotAddedKeyList.Clear();
         AV24NotAddedDscList.Clear();
         /* Execute user subroutine: 'SAVELISTS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'ASSOCIATESELECTED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV44GXV8 = 1;
         while ( AV44GXV8 <= AV22NotAddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV22NotAddedKeyList.GetNumeric(AV44GXV8));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            if ( AV9SecRoleId == AV25NotAssociatedRecords )
            {
               if (true) break;
            }
            AV15i = (int)(AV15i+1);
            AV44GXV8 = (int)(AV44GXV8+1);
         }
         if ( AV15i <= AV22NotAddedKeyList.Count )
         {
            AV14Description = ((string)AV24NotAddedDscList.Item(AV15i));
            AV27InsertIndex = 1;
            while ( ( AV27InsertIndex <= AV23AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV23AddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV21AddedKeyList.Add(AV25NotAssociatedRecords, AV27InsertIndex);
            AV23AddedDscList.Add(AV14Description, AV27InsertIndex);
            AV22NotAddedKeyList.RemoveItem(AV15i);
            AV24NotAddedDscList.RemoveItem(AV15i);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'DISASSOCIATESELECTED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV45GXV9 = 1;
         while ( AV45GXV9 <= AV21AddedKeyList.Count )
         {
            AV9SecRoleId = (short)(AV21AddedKeyList.GetNumeric(AV45GXV9));
            AssignAttri("", false, "AV9SecRoleId", StringUtil.LTrimStr( (decimal)(AV9SecRoleId), 4, 0));
            if ( AV9SecRoleId == AV26AssociatedRecords )
            {
               if (true) break;
            }
            AV15i = (int)(AV15i+1);
            AV45GXV9 = (int)(AV45GXV9+1);
         }
         if ( AV15i <= AV21AddedKeyList.Count )
         {
            AV14Description = ((string)AV23AddedDscList.Item(AV15i));
            AV27InsertIndex = 1;
            while ( ( AV27InsertIndex <= AV24NotAddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV24NotAddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV22NotAddedKeyList.Add(AV26AssociatedRecords, AV27InsertIndex);
            AV24NotAddedDscList.Add(AV14Description, AV27InsertIndex);
            AV21AddedKeyList.RemoveItem(AV15i);
            AV23AddedDscList.RemoveItem(AV15i);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E202K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8SecUserId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV8SecUserId", StringUtil.LTrimStr( (decimal)(AV8SecUserId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecUserId), "ZZZ9"), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA2K2( ) ;
         WS2K2( ) ;
         WE2K2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019233788", true, true);
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
         context.AddJavascriptSource("secusersecuserroleassociation.js", "?202561019233788", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         lstavNotassociatedrecords.Name = "vNOTASSOCIATEDRECORDS";
         lstavNotassociatedrecords.WebTags = "";
         if ( lstavNotassociatedrecords.ItemCount > 0 )
         {
            AV25NotAssociatedRecords = (short)(Math.Round(NumberUtil.Val( lstavNotassociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25NotAssociatedRecords), 4, 0));
         }
         lstavAssociatedrecords.Name = "vASSOCIATEDRECORDS";
         lstavAssociatedrecords.WebTags = "";
         if ( lstavAssociatedrecords.ItemCount > 0 )
         {
            AV26AssociatedRecords = (short)(Math.Round(NumberUtil.Val( lstavAssociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26AssociatedRecords), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV26AssociatedRecords), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblNotassociatedrecordstitle_Internalname = "NOTASSOCIATEDRECORDSTITLE";
         lstavNotassociatedrecords_Internalname = "vNOTASSOCIATEDRECORDS";
         divTablenotassociated_Internalname = "TABLENOTASSOCIATED";
         imgImageassociateall_Internalname = "IMAGEASSOCIATEALL";
         imgImageassociateselected_Internalname = "IMAGEASSOCIATESELECTED";
         imgImagedisassociateselected_Internalname = "IMAGEDISASSOCIATESELECTED";
         imgImagedisassociateall_Internalname = "IMAGEDISASSOCIATEALL";
         divUnnamedtableassociationbuttons_Internalname = "UNNAMEDTABLEASSOCIATIONBUTTONS";
         lblAssociatedrecordstitle_Internalname = "ASSOCIATEDRECORDSTITLE";
         lstavAssociatedrecords_Internalname = "vASSOCIATEDRECORDS";
         divTableassociated_Internalname = "TABLEASSOCIATED";
         divTablefullcontent_Internalname = "TABLEFULLCONTENT";
         bttBtnconfirm_Internalname = "BTNCONFIRM";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
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
         lstavAssociatedrecords_Jsonclick = "";
         lstavAssociatedrecords.Enabled = 1;
         lstavNotassociatedrecords_Jsonclick = "";
         lstavNotassociatedrecords.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Sec User Sec User Role Association";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"AV8SecUserId","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""}]}""");
         setEventMetadata("ENTER","""{"handler":"E132K2","iparms":[{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV8SecUserId","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"AV12SecUserRole","fld":"vSECUSERROLE","type":""},{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV12SecUserRole","fld":"vSECUSERROLE","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""}]}""");
         setEventMetadata("'DISASSOCIATE SELECTED'","""{"handler":"E142K2","iparms":[{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]""");
         setEventMetadata("'DISASSOCIATE SELECTED'",""","oparms":[{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'ASSOCIATE SELECTED'","""{"handler":"E152K2","iparms":[{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]""");
         setEventMetadata("'ASSOCIATE SELECTED'",""","oparms":[{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'ASSOCIATE ALL'","""{"handler":"E162K2","iparms":[{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]""");
         setEventMetadata("'ASSOCIATE ALL'",""","oparms":[{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]}""");
         setEventMetadata("'DISASSOCIATE ALL'","""{"handler":"E172K2","iparms":[{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]""");
         setEventMetadata("'DISASSOCIATE ALL'",""","oparms":[{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("VASSOCIATEDRECORDS.DBLCLICK","""{"handler":"E182K2","iparms":[{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]""");
         setEventMetadata("VASSOCIATEDRECORDS.DBLCLICK",""","oparms":[{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("VNOTASSOCIATEDRECORDS.DBLCLICK","""{"handler":"E192K2","iparms":[{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"}]""");
         setEventMetadata("VNOTASSOCIATEDRECORDS.DBLCLICK",""","oparms":[{"av":"AV9SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV21AddedKeyList","fld":"vADDEDKEYLIST","type":""},{"av":"AV23AddedDscList","fld":"vADDEDDSCLIST","type":""},{"av":"AV22NotAddedKeyList","fld":"vNOTADDEDKEYLIST","type":""},{"av":"AV24NotAddedDscList","fld":"vNOTADDEDDSCLIST","type":""},{"av":"AV17AddedKeyListXml","fld":"vADDEDKEYLISTXML","type":"vchar"},{"av":"AV19AddedDscListXml","fld":"vADDEDDSCLISTXML","type":"vchar"},{"av":"AV18NotAddedKeyListXml","fld":"vNOTADDEDKEYLISTXML","type":"vchar"},{"av":"AV20NotAddedDscListXml","fld":"vNOTADDEDDSCLISTXML","type":"vchar"},{"av":"lstavAssociatedrecords"},{"av":"AV26AssociatedRecords","fld":"vASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"},{"av":"lstavNotassociatedrecords"},{"av":"AV25NotAssociatedRecords","fld":"vNOTASSOCIATEDRECORDS","pic":"ZZZ9","type":"int"}]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV21AddedKeyList = new GxSimpleCollection<short>();
         AV23AddedDscList = new GxSimpleCollection<string>();
         AV22NotAddedKeyList = new GxSimpleCollection<short>();
         AV24NotAddedDscList = new GxSimpleCollection<string>();
         AV17AddedKeyListXml = "";
         AV19AddedDscListXml = "";
         AV18NotAddedKeyListXml = "";
         AV20NotAddedDscListXml = "";
         AV12SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblNotassociatedrecordstitle_Jsonclick = "";
         TempTags = "";
         imgImageassociateall_gximage = "";
         sImgUrl = "";
         imgImageassociateall_Jsonclick = "";
         imgImageassociateselected_gximage = "";
         imgImageassociateselected_Jsonclick = "";
         imgImagedisassociateselected_gximage = "";
         imgImagedisassociateselected_Jsonclick = "";
         imgImagedisassociateall_gximage = "";
         imgImagedisassociateall_Jsonclick = "";
         lblAssociatedrecordstitle_Jsonclick = "";
         bttBtnconfirm_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV30WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         H002K2_A133SecUserId = new short[1] ;
         H002K3_A131SecRoleId = new short[1] ;
         H002K3_A140SecRoleName = new string[] {""} ;
         H002K3_A139SecRoleDescription = new string[] {""} ;
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         H002K4_A131SecRoleId = new short[1] ;
         H002K4_A133SecUserId = new short[1] ;
         AV14Description = "";
         H002K5_A133SecUserId = new short[1] ;
         H002K5_A141SecUserName = new string[] {""} ;
         H002K5_n141SecUserName = new bool[] {false} ;
         A141SecUserName = "";
         H002K6_A131SecRoleId = new short[1] ;
         H002K6_A133SecUserId = new short[1] ;
         H002K7_A131SecRoleId = new short[1] ;
         H002K7_A133SecUserId = new short[1] ;
         AV41GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secusersecuserroleassociation__default(),
            new Object[][] {
                new Object[] {
               H002K2_A133SecUserId
               }
               , new Object[] {
               H002K3_A131SecRoleId, H002K3_A140SecRoleName, H002K3_A139SecRoleDescription
               }
               , new Object[] {
               H002K4_A131SecRoleId, H002K4_A133SecUserId
               }
               , new Object[] {
               H002K5_A133SecUserId, H002K5_A141SecUserName, H002K5_n141SecUserName
               }
               , new Object[] {
               H002K6_A131SecRoleId, H002K6_A133SecUserId
               }
               , new Object[] {
               H002K7_A131SecRoleId, H002K7_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8SecUserId ;
      private short wcpOAV8SecUserId ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A133SecUserId ;
      private short A131SecRoleId ;
      private short AV9SecRoleId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV25NotAssociatedRecords ;
      private short AV26AssociatedRecords ;
      private short nDonePA ;
      private short AV31GXLvl8 ;
      private short nGXWrapped ;
      private int AV27InsertIndex ;
      private int AV15i ;
      private int AV35GXV1 ;
      private int AV37GXV2 ;
      private int AV39GXV3 ;
      private int AV40GXV4 ;
      private int AV42GXV6 ;
      private int AV43GXV7 ;
      private int AV44GXV8 ;
      private int AV45GXV9 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablefullcontent_Internalname ;
      private string divTablenotassociated_Internalname ;
      private string lblNotassociatedrecordstitle_Internalname ;
      private string lblNotassociatedrecordstitle_Jsonclick ;
      private string lstavNotassociatedrecords_Internalname ;
      private string TempTags ;
      private string lstavNotassociatedrecords_Jsonclick ;
      private string divUnnamedtableassociationbuttons_Internalname ;
      private string imgImageassociateall_gximage ;
      private string sImgUrl ;
      private string imgImageassociateall_Internalname ;
      private string imgImageassociateall_Jsonclick ;
      private string imgImageassociateselected_gximage ;
      private string imgImageassociateselected_Internalname ;
      private string imgImageassociateselected_Jsonclick ;
      private string imgImagedisassociateselected_gximage ;
      private string imgImagedisassociateselected_Internalname ;
      private string imgImagedisassociateselected_Jsonclick ;
      private string imgImagedisassociateall_gximage ;
      private string imgImagedisassociateall_Internalname ;
      private string imgImagedisassociateall_Jsonclick ;
      private string divTableassociated_Internalname ;
      private string lblAssociatedrecordstitle_Internalname ;
      private string lblAssociatedrecordstitle_Jsonclick ;
      private string lstavAssociatedrecords_Internalname ;
      private string lstavAssociatedrecords_Jsonclick ;
      private string bttBtnconfirm_Internalname ;
      private string bttBtnconfirm_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11Exist ;
      private bool n141SecUserName ;
      private bool AV13Success ;
      private string AV17AddedKeyListXml ;
      private string AV19AddedDscListXml ;
      private string AV18NotAddedKeyListXml ;
      private string AV20NotAddedDscListXml ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string AV14Description ;
      private string A141SecUserName ;
      private GxHttpRequest AV10HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXListbox lstavNotassociatedrecords ;
      private GXListbox lstavAssociatedrecords ;
      private GxSimpleCollection<short> AV21AddedKeyList ;
      private GxSimpleCollection<string> AV23AddedDscList ;
      private GxSimpleCollection<short> AV22NotAddedKeyList ;
      private GxSimpleCollection<string> AV24NotAddedDscList ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole AV12SecUserRole ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV30WWPContext ;
      private IDataStoreProvider pr_default ;
      private short[] H002K2_A133SecUserId ;
      private short[] H002K3_A131SecRoleId ;
      private string[] H002K3_A140SecRoleName ;
      private string[] H002K3_A139SecRoleDescription ;
      private short[] H002K4_A131SecRoleId ;
      private short[] H002K4_A133SecUserId ;
      private short[] H002K5_A133SecUserId ;
      private string[] H002K5_A141SecUserName ;
      private bool[] H002K5_n141SecUserName ;
      private short[] H002K6_A131SecRoleId ;
      private short[] H002K6_A133SecUserId ;
      private short[] H002K7_A131SecRoleId ;
      private short[] H002K7_A133SecUserId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV41GXV5 ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secusersecuserroleassociation__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002K2;
          prmH002K2 = new Object[] {
          new ParDef("AV8SecUserId",GXType.Int16,4,0)
          };
          Object[] prmH002K3;
          prmH002K3 = new Object[] {
          };
          Object[] prmH002K4;
          prmH002K4 = new Object[] {
          new ParDef("AV8SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmH002K5;
          prmH002K5 = new Object[] {
          new ParDef("AV8SecUserId",GXType.Int16,4,0)
          };
          Object[] prmH002K6;
          prmH002K6 = new Object[] {
          new ParDef("AV8SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmH002K7;
          prmH002K7 = new Object[] {
          new ParDef("AV8SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002K2", "SELECT SecUserId FROM SecUser WHERE SecUserId = :AV8SecUserId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002K3", "SELECT SecRoleId, SecRoleName, SecRoleDescription FROM SecRole ORDER BY SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002K4", "SELECT SecRoleId, SecUserId FROM SecUserRole WHERE SecUserId = :AV8SecUserId and SecRoleId = :SecRoleId ORDER BY SecUserId, SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002K5", "SELECT SecUserId, SecUserName FROM SecUser WHERE SecUserId = :AV8SecUserId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002K6", "SELECT SecRoleId, SecUserId FROM SecUserRole WHERE SecUserId = :AV8SecUserId and SecRoleId = :AV9SecRoleId ORDER BY SecUserId, SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002K7", "SELECT SecRoleId, SecUserId FROM SecUserRole WHERE SecUserId = :AV8SecUserId and SecRoleId = :AV9SecRoleId ORDER BY SecUserId, SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K7,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
