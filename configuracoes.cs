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
   public class configuracoes : GXDataArea
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
            A398ConfiguracoesLayoutProposta = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfiguracoesLayoutProposta"), "."), 18, MidpointRounding.ToEven));
            n398ConfiguracoesLayoutProposta = false;
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A398ConfiguracoesLayoutProposta) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A564ConfigLayoutPromissoriaClinicaEmprestimo = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigLayoutPromissoriaClinicaEmprestimo"), "."), 18, MidpointRounding.ToEven));
            n564ConfigLayoutPromissoriaClinicaEmprestimo = false;
            AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A564ConfigLayoutPromissoriaClinicaEmprestimo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A565ConfigLayoutPromissoriaClinicaTaxa = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigLayoutPromissoriaClinicaTaxa"), "."), 18, MidpointRounding.ToEven));
            n565ConfigLayoutPromissoriaClinicaTaxa = false;
            AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A565ConfigLayoutPromissoriaClinicaTaxa) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A566ConfigLayoutPromissoriaPaciente = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigLayoutPromissoriaPaciente"), "."), 18, MidpointRounding.ToEven));
            n566ConfigLayoutPromissoriaPaciente = false;
            AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A566ConfigLayoutPromissoriaPaciente) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A922ConfigLayoutContratoCompraTitulo = (short)(Math.Round(NumberUtil.Val( GetPar( "ConfigLayoutContratoCompraTitulo"), "."), 18, MidpointRounding.ToEven));
            n922ConfigLayoutContratoCompraTitulo = false;
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A922ConfigLayoutContratoCompraTitulo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A654ConfiguracoesCategoriaTitulo = (int)(Math.Round(NumberUtil.Val( GetPar( "ConfiguracoesCategoriaTitulo"), "."), 18, MidpointRounding.ToEven));
            n654ConfiguracoesCategoriaTitulo = false;
            AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A654ConfiguracoesCategoriaTitulo) ;
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
         Form.Meta.addItem("description", "Configuracoes", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConfiguracoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public configuracoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracoes( IGxContext context )
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
         cmbConfiguracoesSerasaAnotacoesCompletas = new GXCombobox();
         cmbConfiguracoesSerasaConsultaDetalhada = new GXCombobox();
         cmbConfiguracoesSerasaParticipacaoSocietaria = new GXCombobox();
         cmbConfiguracoesSerasaRendaEstimada = new GXCombobox();
         cmbConfiguracoesSerasaHistoricoPagamento = new GXCombobox();
         cmbConfiguracoesCompraTituloTarifaTipo = new GXCombobox();
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
         if ( cmbConfiguracoesSerasaAnotacoesCompletas.ItemCount > 0 )
         {
            A765ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cmbConfiguracoesSerasaAnotacoesCompletas.getValidValue(StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas)));
            n765ConfiguracoesSerasaAnotacoesCompletas = false;
            AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas);
            AssignProp("", false, cmbConfiguracoesSerasaAnotacoesCompletas_Internalname, "Values", cmbConfiguracoesSerasaAnotacoesCompletas.ToJavascriptSource(), true);
         }
         if ( cmbConfiguracoesSerasaConsultaDetalhada.ItemCount > 0 )
         {
            A766ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cmbConfiguracoesSerasaConsultaDetalhada.getValidValue(StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada)));
            n766ConfiguracoesSerasaConsultaDetalhada = false;
            AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada);
            AssignProp("", false, cmbConfiguracoesSerasaConsultaDetalhada_Internalname, "Values", cmbConfiguracoesSerasaConsultaDetalhada.ToJavascriptSource(), true);
         }
         if ( cmbConfiguracoesSerasaParticipacaoSocietaria.ItemCount > 0 )
         {
            A767ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbConfiguracoesSerasaParticipacaoSocietaria.getValidValue(StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria)));
            n767ConfiguracoesSerasaParticipacaoSocietaria = false;
            AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria);
            AssignProp("", false, cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname, "Values", cmbConfiguracoesSerasaParticipacaoSocietaria.ToJavascriptSource(), true);
         }
         if ( cmbConfiguracoesSerasaRendaEstimada.ItemCount > 0 )
         {
            A768ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cmbConfiguracoesSerasaRendaEstimada.getValidValue(StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada)));
            n768ConfiguracoesSerasaRendaEstimada = false;
            AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada);
            AssignProp("", false, cmbConfiguracoesSerasaRendaEstimada_Internalname, "Values", cmbConfiguracoesSerasaRendaEstimada.ToJavascriptSource(), true);
         }
         if ( cmbConfiguracoesSerasaHistoricoPagamento.ItemCount > 0 )
         {
            A769ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cmbConfiguracoesSerasaHistoricoPagamento.getValidValue(StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento)));
            n769ConfiguracoesSerasaHistoricoPagamento = false;
            AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento);
            AssignProp("", false, cmbConfiguracoesSerasaHistoricoPagamento_Internalname, "Values", cmbConfiguracoesSerasaHistoricoPagamento.ToJavascriptSource(), true);
         }
         if ( cmbConfiguracoesCompraTituloTarifaTipo.ItemCount > 0 )
         {
            A1037ConfiguracoesCompraTituloTarifaTipo = cmbConfiguracoesCompraTituloTarifaTipo.getValidValue(A1037ConfiguracoesCompraTituloTarifaTipo);
            n1037ConfiguracoesCompraTituloTarifaTipo = false;
            AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo);
            AssignProp("", false, cmbConfiguracoesCompraTituloTarifaTipo_Internalname, "Values", cmbConfiguracoesCompraTituloTarifaTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Configuracoes", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Configuracoes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Configuracoes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A299ConfiguracoesId), 9, 0, ",", "")), StringUtil.LTrim( ((edtConfiguracoesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A299ConfiguracoesId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A299ConfiguracoesId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemLogin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemLogin_Internalname, "Imagem Login", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         edtConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
         edtConfiguracoesImagemLogin_Filetype = "";
         AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Filetype", edtConfiguracoesImagemLogin_Filetype, true);
         edtConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
         AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Filetype", edtConfiguracoesImagemLogin_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A300ConfiguracoesImagemLogin)) )
         {
            gxblobfileaux.Source = A300ConfiguracoesImagemLogin;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtConfiguracoesImagemLogin_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtConfiguracoesImagemLogin_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A300ConfiguracoesImagemLogin = gxblobfileaux.GetURI();
               n300ConfiguracoesImagemLogin = false;
               AssignAttri("", false, "A300ConfiguracoesImagemLogin", A300ConfiguracoesImagemLogin);
               AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "URL", context.PathToRelativeUrl( A300ConfiguracoesImagemLogin), true);
               edtConfiguracoesImagemLogin_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Filetype", edtConfiguracoesImagemLogin_Filetype, true);
            }
            AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "URL", context.PathToRelativeUrl( A300ConfiguracoesImagemLogin), true);
         }
         GxWebStd.gx_blob_field( context, edtConfiguracoesImagemLogin_Internalname, StringUtil.RTrim( A300ConfiguracoesImagemLogin), context.PathToRelativeUrl( A300ConfiguracoesImagemLogin), (String.IsNullOrEmpty(StringUtil.RTrim( edtConfiguracoesImagemLogin_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtConfiguracoesImagemLogin_Filetype)) ? A300ConfiguracoesImagemLogin : edtConfiguracoesImagemLogin_Filetype)) : edtConfiguracoesImagemLogin_Contenttype), true, "", edtConfiguracoesImagemLogin_Parameters, 0, edtConfiguracoesImagemLogin_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtConfiguracoesImagemLogin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemLoginNomeInteiro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemLoginNomeInteiro_Internalname, "Nome Inteiro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemLoginNomeInteiro_Internalname, A315ConfiguracoesImagemLoginNomeInteiro, StringUtil.RTrim( context.localUtil.Format( A315ConfiguracoesImagemLoginNomeInteiro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemLoginNomeInteiro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemLoginNomeInteiro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemLoginTamanho_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemLoginTamanho_Internalname, "Login Tamanho", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemLoginTamanho_Internalname, ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho)&&IsIns( )||n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho)&&IsIns( )||n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( ((edtConfiguracoesImagemLoginTamanho_Enabled!=0) ? context.localUtil.Format( A316ConfiguracoesImagemLoginTamanho, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A316ConfiguracoesImagemLoginTamanho, "ZZZZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemLoginTamanho_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemLoginTamanho_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemLoginBackground_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemLoginBackground_Internalname, "Login Background", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemLoginBackground_Internalname, A317ConfiguracoesImagemLoginBackground, StringUtil.RTrim( context.localUtil.Format( A317ConfiguracoesImagemLoginBackground, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemLoginBackground_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemLoginBackground_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemHeader_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemHeader_Internalname, "Imagem Header", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         edtConfiguracoesImagemHeader_Filetype = "tmp";
         AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "Filetype", edtConfiguracoesImagemHeader_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A318ConfiguracoesImagemHeader)) )
         {
            gxblobfileaux.Source = A318ConfiguracoesImagemHeader;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtConfiguracoesImagemHeader_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtConfiguracoesImagemHeader_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A318ConfiguracoesImagemHeader = gxblobfileaux.GetURI();
               n318ConfiguracoesImagemHeader = false;
               AssignAttri("", false, "A318ConfiguracoesImagemHeader", A318ConfiguracoesImagemHeader);
               AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "URL", context.PathToRelativeUrl( A318ConfiguracoesImagemHeader), true);
               edtConfiguracoesImagemHeader_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "Filetype", edtConfiguracoesImagemHeader_Filetype, true);
            }
            AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "URL", context.PathToRelativeUrl( A318ConfiguracoesImagemHeader), true);
         }
         GxWebStd.gx_blob_field( context, edtConfiguracoesImagemHeader_Internalname, StringUtil.RTrim( A318ConfiguracoesImagemHeader), context.PathToRelativeUrl( A318ConfiguracoesImagemHeader), (String.IsNullOrEmpty(StringUtil.RTrim( edtConfiguracoesImagemHeader_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtConfiguracoesImagemHeader_Filetype)) ? A318ConfiguracoesImagemHeader : edtConfiguracoesImagemHeader_Filetype)) : edtConfiguracoesImagemHeader_Contenttype), false, "", edtConfiguracoesImagemHeader_Parameters, 0, edtConfiguracoesImagemHeader_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtConfiguracoesImagemHeader_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemHeaderNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemHeaderNome_Internalname, "Header Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemHeaderNome_Internalname, A319ConfiguracoesImagemHeaderNome, StringUtil.RTrim( context.localUtil.Format( A319ConfiguracoesImagemHeaderNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemHeaderNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemHeaderNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemHeaderExtencao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemHeaderExtencao_Internalname, "Header Extencao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemHeaderExtencao_Internalname, A320ConfiguracoesImagemHeaderExtencao, StringUtil.RTrim( context.localUtil.Format( A320ConfiguracoesImagemHeaderExtencao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemHeaderExtencao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemHeaderExtencao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemHeaderNomeInteiro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemHeaderNomeInteiro_Internalname, "Nome Inteiro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemHeaderNomeInteiro_Internalname, A321ConfiguracoesImagemHeaderNomeInteiro, StringUtil.RTrim( context.localUtil.Format( A321ConfiguracoesImagemHeaderNomeInteiro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemHeaderNomeInteiro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemHeaderNomeInteiro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesImagemHeaderTamanho_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesImagemHeaderTamanho_Internalname, "Header Tamanho", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesImagemHeaderTamanho_Internalname, ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho)&&IsIns( )||n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho)&&IsIns( )||n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( ((edtConfiguracoesImagemHeaderTamanho_Enabled!=0) ? context.localUtil.Format( A322ConfiguracoesImagemHeaderTamanho, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A322ConfiguracoesImagemHeaderTamanho, "ZZZZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesImagemHeaderTamanho_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesImagemHeaderTamanho_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesLayoutProposta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesLayoutProposta_Internalname, "Layout Proposta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesLayoutProposta_Internalname, ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ",", ""))), ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( ((edtConfiguracoesLayoutProposta_Enabled!=0) ? context.localUtil.Format( (decimal)(A398ConfiguracoesLayoutProposta), "ZZZ9") : context.localUtil.Format( (decimal)(A398ConfiguracoesLayoutProposta), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesLayoutProposta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesLayoutProposta_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Configuracoeslayoutcontratocorpo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Configuracoeslayoutcontratocorpo_Internalname, "Contrato Corpo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucConfiguracoeslayoutcontratocorpo.SetProperty("Attribute", ConfiguracoesLayoutContratoCorpo);
         ucConfiguracoeslayoutcontratocorpo.SetProperty("CaptionClass", Configuracoeslayoutcontratocorpo_Captionclass);
         ucConfiguracoeslayoutcontratocorpo.SetProperty("CaptionStyle", Configuracoeslayoutcontratocorpo_Captionstyle);
         ucConfiguracoeslayoutcontratocorpo.SetProperty("CaptionPosition", Configuracoeslayoutcontratocorpo_Captionposition);
         ucConfiguracoeslayoutcontratocorpo.Render(context, "fckeditor", Configuracoeslayoutcontratocorpo_Internalname, "CONFIGURACOESLAYOUTCONTRATOCORPOContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname, "Clinica Emprestimo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname, ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ",", ""))), ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( ((edtConfigLayoutPromissoriaClinicaEmprestimo_Enabled!=0) ? context.localUtil.Format( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), "ZZZ9") : context.localUtil.Format( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigLayoutPromissoriaClinicaEmprestimo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfigLayoutPromissoriaClinicaEmprestimo_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Configlayoutcorpopromissoriaclinicaemprestimo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Configlayoutcorpopromissoriaclinicaemprestimo_Internalname, "Clinica Emprestimo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucConfiglayoutcorpopromissoriaclinicaemprestimo.SetProperty("Attribute", ConfigLayoutCorpoPromissoriaClinicaEmprestimo);
         ucConfiglayoutcorpopromissoriaclinicaemprestimo.SetProperty("CaptionClass", Configlayoutcorpopromissoriaclinicaemprestimo_Captionclass);
         ucConfiglayoutcorpopromissoriaclinicaemprestimo.SetProperty("CaptionStyle", Configlayoutcorpopromissoriaclinicaemprestimo_Captionstyle);
         ucConfiglayoutcorpopromissoriaclinicaemprestimo.SetProperty("CaptionPosition", Configlayoutcorpopromissoriaclinicaemprestimo_Captionposition);
         ucConfiglayoutcorpopromissoriaclinicaemprestimo.Render(context, "fckeditor", Configlayoutcorpopromissoriaclinicaemprestimo_Internalname, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMOContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigLayoutPromissoriaClinicaTaxa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigLayoutPromissoriaClinicaTaxa_Internalname, "Clinica Taxa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigLayoutPromissoriaClinicaTaxa_Internalname, ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ",", ""))), ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( ((edtConfigLayoutPromissoriaClinicaTaxa_Enabled!=0) ? context.localUtil.Format( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), "ZZZ9") : context.localUtil.Format( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigLayoutPromissoriaClinicaTaxa_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfigLayoutPromissoriaClinicaTaxa_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Configlayoutcorpopromissoriaclinicataxa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Configlayoutcorpopromissoriaclinicataxa_Internalname, "Clinica Taxa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucConfiglayoutcorpopromissoriaclinicataxa.SetProperty("Attribute", ConfigLayoutCorpoPromissoriaClinicaTaxa);
         ucConfiglayoutcorpopromissoriaclinicataxa.SetProperty("CaptionClass", Configlayoutcorpopromissoriaclinicataxa_Captionclass);
         ucConfiglayoutcorpopromissoriaclinicataxa.SetProperty("CaptionStyle", Configlayoutcorpopromissoriaclinicataxa_Captionstyle);
         ucConfiglayoutcorpopromissoriaclinicataxa.SetProperty("CaptionPosition", Configlayoutcorpopromissoriaclinicataxa_Captionposition);
         ucConfiglayoutcorpopromissoriaclinicataxa.Render(context, "fckeditor", Configlayoutcorpopromissoriaclinicataxa_Internalname, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXAContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigLayoutPromissoriaPaciente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigLayoutPromissoriaPaciente_Internalname, "Promissoria Paciente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigLayoutPromissoriaPaciente_Internalname, ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ",", ""))), ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( ((edtConfigLayoutPromissoriaPaciente_Enabled!=0) ? context.localUtil.Format( (decimal)(A566ConfigLayoutPromissoriaPaciente), "ZZZ9") : context.localUtil.Format( (decimal)(A566ConfigLayoutPromissoriaPaciente), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigLayoutPromissoriaPaciente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfigLayoutPromissoriaPaciente_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfigLayoutContratoCompraTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfigLayoutContratoCompraTitulo_Internalname, "Compra Titulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfigLayoutContratoCompraTitulo_Internalname, ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ",", ""))), ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( ((edtConfigLayoutContratoCompraTitulo_Enabled!=0) ? context.localUtil.Format( (decimal)(A922ConfigLayoutContratoCompraTitulo), "ZZZ9") : context.localUtil.Format( (decimal)(A922ConfigLayoutContratoCompraTitulo), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfigLayoutContratoCompraTitulo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfigLayoutContratoCompraTitulo_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Configlayoutcorpopromissoriapaciente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Configlayoutcorpopromissoriapaciente_Internalname, "Promissoria Paciente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucConfiglayoutcorpopromissoriapaciente.SetProperty("Attribute", ConfigLayoutCorpoPromissoriaPaciente);
         ucConfiglayoutcorpopromissoriapaciente.SetProperty("CaptionClass", Configlayoutcorpopromissoriapaciente_Captionclass);
         ucConfiglayoutcorpopromissoriapaciente.SetProperty("CaptionStyle", Configlayoutcorpopromissoriapaciente_Captionstyle);
         ucConfiglayoutcorpopromissoriapaciente.SetProperty("CaptionPosition", Configlayoutcorpopromissoriapaciente_Captionposition);
         ucConfiglayoutcorpopromissoriapaciente.Render(context, "fckeditor", Configlayoutcorpopromissoriapaciente_Internalname, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesArquivoPFX_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesArquivoPFX_Internalname, "Arquivo PFX", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         edtConfiguracoesArquivoPFX_Filetype = "tmp";
         AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "Filetype", edtConfiguracoesArquivoPFX_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A562ConfiguracoesArquivoPFX)) )
         {
            gxblobfileaux.Source = A562ConfiguracoesArquivoPFX;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtConfiguracoesArquivoPFX_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtConfiguracoesArquivoPFX_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A562ConfiguracoesArquivoPFX = gxblobfileaux.GetURI();
               n562ConfiguracoesArquivoPFX = false;
               AssignAttri("", false, "A562ConfiguracoesArquivoPFX", A562ConfiguracoesArquivoPFX);
               AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "URL", context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX), true);
               edtConfiguracoesArquivoPFX_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "Filetype", edtConfiguracoesArquivoPFX_Filetype, true);
            }
            AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "URL", context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX), true);
         }
         GxWebStd.gx_blob_field( context, edtConfiguracoesArquivoPFX_Internalname, StringUtil.RTrim( A562ConfiguracoesArquivoPFX), context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX), (String.IsNullOrEmpty(StringUtil.RTrim( edtConfiguracoesArquivoPFX_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtConfiguracoesArquivoPFX_Filetype)) ? A562ConfiguracoesArquivoPFX : edtConfiguracoesArquivoPFX_Filetype)) : edtConfiguracoesArquivoPFX_Contenttype), false, "", edtConfiguracoesArquivoPFX_Parameters, 0, edtConfiguracoesArquivoPFX_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtConfiguracoesArquivoPFX_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "", "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracaoSenhaPFX_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracaoSenhaPFX_Internalname, "Senha PFX", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracaoSenhaPFX_Internalname, A563ConfiguracaoSenhaPFX, StringUtil.RTrim( context.localUtil.Format( A563ConfiguracaoSenhaPFX, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracaoSenhaPFX_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracaoSenhaPFX_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesCategoriaTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesCategoriaTitulo_Internalname, "Categoria Titulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesCategoriaTitulo_Internalname, ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ",", ""))), ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( ((edtConfiguracoesCategoriaTitulo_Enabled!=0) ? context.localUtil.Format( (decimal)(A654ConfiguracoesCategoriaTitulo), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A654ConfiguracoesCategoriaTitulo), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesCategoriaTitulo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesCategoriaTitulo_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfiguracoesSerasaAnotacoesCompletas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfiguracoesSerasaAnotacoesCompletas_Internalname, "Anotações completas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfiguracoesSerasaAnotacoesCompletas, cmbConfiguracoesSerasaAnotacoesCompletas_Internalname, StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas), 1, cmbConfiguracoesSerasaAnotacoesCompletas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConfiguracoesSerasaAnotacoesCompletas.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "", true, 0, "HLP_Configuracoes.htm");
         cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas);
         AssignProp("", false, cmbConfiguracoesSerasaAnotacoesCompletas_Internalname, "Values", (string)(cmbConfiguracoesSerasaAnotacoesCompletas.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfiguracoesSerasaConsultaDetalhada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfiguracoesSerasaConsultaDetalhada_Internalname, "Consulta detalhada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfiguracoesSerasaConsultaDetalhada, cmbConfiguracoesSerasaConsultaDetalhada_Internalname, StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada), 1, cmbConfiguracoesSerasaConsultaDetalhada_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConfiguracoesSerasaConsultaDetalhada.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "", true, 0, "HLP_Configuracoes.htm");
         cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada);
         AssignProp("", false, cmbConfiguracoesSerasaConsultaDetalhada_Internalname, "Values", (string)(cmbConfiguracoesSerasaConsultaDetalhada.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname, "Participação societária", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfiguracoesSerasaParticipacaoSocietaria, cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname, StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria), 1, cmbConfiguracoesSerasaParticipacaoSocietaria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConfiguracoesSerasaParticipacaoSocietaria.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "", true, 0, "HLP_Configuracoes.htm");
         cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria);
         AssignProp("", false, cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname, "Values", (string)(cmbConfiguracoesSerasaParticipacaoSocietaria.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfiguracoesSerasaRendaEstimada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfiguracoesSerasaRendaEstimada_Internalname, "Renda estimada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfiguracoesSerasaRendaEstimada, cmbConfiguracoesSerasaRendaEstimada_Internalname, StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada), 1, cmbConfiguracoesSerasaRendaEstimada_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConfiguracoesSerasaRendaEstimada.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "", true, 0, "HLP_Configuracoes.htm");
         cmbConfiguracoesSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada);
         AssignProp("", false, cmbConfiguracoesSerasaRendaEstimada_Internalname, "Values", (string)(cmbConfiguracoesSerasaRendaEstimada.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfiguracoesSerasaHistoricoPagamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfiguracoesSerasaHistoricoPagamento_Internalname, "Histórico pagamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfiguracoesSerasaHistoricoPagamento, cmbConfiguracoesSerasaHistoricoPagamento_Internalname, StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento), 1, cmbConfiguracoesSerasaHistoricoPagamento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConfiguracoesSerasaHistoricoPagamento.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "", true, 0, "HLP_Configuracoes.htm");
         cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento);
         AssignProp("", false, cmbConfiguracoesSerasaHistoricoPagamento_Internalname, "Values", (string)(cmbConfiguracoesSerasaHistoricoPagamento.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesCompraTituloTaxaEfetiva_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesCompraTituloTaxaEfetiva_Internalname, "efetiva", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesCompraTituloTaxaEfetiva_Internalname, ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva)&&IsIns( )||n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva)&&IsIns( )||n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( ((edtConfiguracoesCompraTituloTaxaEfetiva_Enabled!=0) ? context.localUtil.Format( A1013ConfiguracoesCompraTituloTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1013ConfiguracoesCompraTituloTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesCompraTituloTaxaEfetiva_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesCompraTituloTaxaEfetiva_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesCompraTituloTaxaMora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesCompraTituloTaxaMora_Internalname, "mora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesCompraTituloTaxaMora_Internalname, ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora)&&IsIns( )||n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora)&&IsIns( )||n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( ((edtConfiguracoesCompraTituloTaxaMora_Enabled!=0) ? context.localUtil.Format( A1014ConfiguracoesCompraTituloTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1014ConfiguracoesCompraTituloTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesCompraTituloTaxaMora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesCompraTituloTaxaMora_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesCompraTituloFator_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesCompraTituloFator_Internalname, "Fator", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesCompraTituloFator_Internalname, ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator)&&IsIns( )||n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator)&&IsIns( )||n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( ((edtConfiguracoesCompraTituloFator_Enabled!=0) ? context.localUtil.Format( A1036ConfiguracoesCompraTituloFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1036ConfiguracoesCompraTituloFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesCompraTituloFator_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesCompraTituloFator_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConfiguracoesCompraTituloTarifaTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConfiguracoesCompraTituloTarifaTipo_Internalname, "da tarifa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConfiguracoesCompraTituloTarifaTipo, cmbConfiguracoesCompraTituloTarifaTipo_Internalname, StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo), 1, cmbConfiguracoesCompraTituloTarifaTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbConfiguracoesCompraTituloTarifaTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "", true, 0, "HLP_Configuracoes.htm");
         cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo);
         AssignProp("", false, cmbConfiguracoesCompraTituloTarifaTipo_Internalname, "Values", (string)(cmbConfiguracoesCompraTituloTarifaTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConfiguracoesCompraTituloTarifa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConfiguracoesCompraTituloTarifa_Internalname, "Tarifa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConfiguracoesCompraTituloTarifa_Internalname, ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa)&&IsIns( )||n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa)&&IsIns( )||n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( ((edtConfiguracoesCompraTituloTarifa_Enabled!=0) ? context.localUtil.Format( A1038ConfiguracoesCompraTituloTarifa, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A1038ConfiguracoesCompraTituloTarifa, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConfiguracoesCompraTituloTarifa_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConfiguracoesCompraTituloTarifa_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Configuracoes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracoes.htm");
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
            Z299ConfiguracoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z299ConfiguracoesId"), ",", "."), 18, MidpointRounding.ToEven));
            Z315ConfiguracoesImagemLoginNomeInteiro = cgiGet( "Z315ConfiguracoesImagemLoginNomeInteiro");
            n315ConfiguracoesImagemLoginNomeInteiro = (String.IsNullOrEmpty(StringUtil.RTrim( A315ConfiguracoesImagemLoginNomeInteiro)) ? true : false);
            Z316ConfiguracoesImagemLoginTamanho = context.localUtil.CToN( cgiGet( "Z316ConfiguracoesImagemLoginTamanho"), ",", ".");
            n316ConfiguracoesImagemLoginTamanho = ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho) ? true : false);
            Z317ConfiguracoesImagemLoginBackground = cgiGet( "Z317ConfiguracoesImagemLoginBackground");
            n317ConfiguracoesImagemLoginBackground = (String.IsNullOrEmpty(StringUtil.RTrim( A317ConfiguracoesImagemLoginBackground)) ? true : false);
            Z319ConfiguracoesImagemHeaderNome = cgiGet( "Z319ConfiguracoesImagemHeaderNome");
            n319ConfiguracoesImagemHeaderNome = (String.IsNullOrEmpty(StringUtil.RTrim( A319ConfiguracoesImagemHeaderNome)) ? true : false);
            Z320ConfiguracoesImagemHeaderExtencao = cgiGet( "Z320ConfiguracoesImagemHeaderExtencao");
            n320ConfiguracoesImagemHeaderExtencao = (String.IsNullOrEmpty(StringUtil.RTrim( A320ConfiguracoesImagemHeaderExtencao)) ? true : false);
            Z321ConfiguracoesImagemHeaderNomeInteiro = cgiGet( "Z321ConfiguracoesImagemHeaderNomeInteiro");
            n321ConfiguracoesImagemHeaderNomeInteiro = (String.IsNullOrEmpty(StringUtil.RTrim( A321ConfiguracoesImagemHeaderNomeInteiro)) ? true : false);
            Z322ConfiguracoesImagemHeaderTamanho = context.localUtil.CToN( cgiGet( "Z322ConfiguracoesImagemHeaderTamanho"), ",", ".");
            n322ConfiguracoesImagemHeaderTamanho = ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho) ? true : false);
            Z563ConfiguracaoSenhaPFX = cgiGet( "Z563ConfiguracaoSenhaPFX");
            n563ConfiguracaoSenhaPFX = (String.IsNullOrEmpty(StringUtil.RTrim( A563ConfiguracaoSenhaPFX)) ? true : false);
            Z765ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cgiGet( "Z765ConfiguracoesSerasaAnotacoesCompletas"));
            n765ConfiguracoesSerasaAnotacoesCompletas = ((false==A765ConfiguracoesSerasaAnotacoesCompletas) ? true : false);
            Z766ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cgiGet( "Z766ConfiguracoesSerasaConsultaDetalhada"));
            n766ConfiguracoesSerasaConsultaDetalhada = ((false==A766ConfiguracoesSerasaConsultaDetalhada) ? true : false);
            Z767ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cgiGet( "Z767ConfiguracoesSerasaParticipacaoSocietaria"));
            n767ConfiguracoesSerasaParticipacaoSocietaria = ((false==A767ConfiguracoesSerasaParticipacaoSocietaria) ? true : false);
            Z768ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cgiGet( "Z768ConfiguracoesSerasaRendaEstimada"));
            n768ConfiguracoesSerasaRendaEstimada = ((false==A768ConfiguracoesSerasaRendaEstimada) ? true : false);
            Z769ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cgiGet( "Z769ConfiguracoesSerasaHistoricoPagamento"));
            n769ConfiguracoesSerasaHistoricoPagamento = ((false==A769ConfiguracoesSerasaHistoricoPagamento) ? true : false);
            Z1013ConfiguracoesCompraTituloTaxaEfetiva = context.localUtil.CToN( cgiGet( "Z1013ConfiguracoesCompraTituloTaxaEfetiva"), ",", ".");
            n1013ConfiguracoesCompraTituloTaxaEfetiva = ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva) ? true : false);
            Z1014ConfiguracoesCompraTituloTaxaMora = context.localUtil.CToN( cgiGet( "Z1014ConfiguracoesCompraTituloTaxaMora"), ",", ".");
            n1014ConfiguracoesCompraTituloTaxaMora = ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora) ? true : false);
            Z1036ConfiguracoesCompraTituloFator = context.localUtil.CToN( cgiGet( "Z1036ConfiguracoesCompraTituloFator"), ",", ".");
            n1036ConfiguracoesCompraTituloFator = ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator) ? true : false);
            Z1037ConfiguracoesCompraTituloTarifaTipo = cgiGet( "Z1037ConfiguracoesCompraTituloTarifaTipo");
            n1037ConfiguracoesCompraTituloTarifaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo)) ? true : false);
            Z1038ConfiguracoesCompraTituloTarifa = context.localUtil.CToN( cgiGet( "Z1038ConfiguracoesCompraTituloTarifa"), ",", ".");
            n1038ConfiguracoesCompraTituloTarifa = ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa) ? true : false);
            Z398ConfiguracoesLayoutProposta = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z398ConfiguracoesLayoutProposta"), ",", "."), 18, MidpointRounding.ToEven));
            n398ConfiguracoesLayoutProposta = ((0==A398ConfiguracoesLayoutProposta) ? true : false);
            Z564ConfigLayoutPromissoriaClinicaEmprestimo = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z564ConfigLayoutPromissoriaClinicaEmprestimo"), ",", "."), 18, MidpointRounding.ToEven));
            n564ConfigLayoutPromissoriaClinicaEmprestimo = ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo) ? true : false);
            Z565ConfigLayoutPromissoriaClinicaTaxa = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z565ConfigLayoutPromissoriaClinicaTaxa"), ",", "."), 18, MidpointRounding.ToEven));
            n565ConfigLayoutPromissoriaClinicaTaxa = ((0==A565ConfigLayoutPromissoriaClinicaTaxa) ? true : false);
            Z566ConfigLayoutPromissoriaPaciente = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z566ConfigLayoutPromissoriaPaciente"), ",", "."), 18, MidpointRounding.ToEven));
            n566ConfigLayoutPromissoriaPaciente = ((0==A566ConfigLayoutPromissoriaPaciente) ? true : false);
            Z922ConfigLayoutContratoCompraTitulo = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z922ConfigLayoutContratoCompraTitulo"), ",", "."), 18, MidpointRounding.ToEven));
            n922ConfigLayoutContratoCompraTitulo = ((0==A922ConfigLayoutContratoCompraTitulo) ? true : false);
            Z654ConfiguracoesCategoriaTitulo = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z654ConfiguracoesCategoriaTitulo"), ",", "."), 18, MidpointRounding.ToEven));
            n654ConfiguracoesCategoriaTitulo = ((0==A654ConfiguracoesCategoriaTitulo) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A312ConfiguracoesImagemLoginExtencao = cgiGet( "CONFIGURACOESIMAGEMLOGINEXTENCAO");
            n312ConfiguracoesImagemLoginExtencao = (String.IsNullOrEmpty(StringUtil.RTrim( A312ConfiguracoesImagemLoginExtencao)) ? true : false);
            A313ConfiguracoesImagemLoginNome = cgiGet( "CONFIGURACOESIMAGEMLOGINNOME");
            n313ConfiguracoesImagemLoginNome = (String.IsNullOrEmpty(StringUtil.RTrim( A313ConfiguracoesImagemLoginNome)) ? true : false);
            A418ConfiguracoesLayoutContratoCorpo = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO");
            n418ConfiguracoesLayoutContratoCorpo = false;
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO");
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = false;
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA");
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = false;
            A569ConfigLayoutCorpoPromissoriaPaciente = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE");
            n569ConfigLayoutCorpoPromissoriaPaciente = false;
            Configuracoeslayoutcontratocorpo_Objectcall = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Objectcall");
            Configuracoeslayoutcontratocorpo_Class = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Class");
            Configuracoeslayoutcontratocorpo_Enabled = StringUtil.StrToBool( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Enabled"));
            Configuracoeslayoutcontratocorpo_Width = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Width");
            Configuracoeslayoutcontratocorpo_Height = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Height");
            Configuracoeslayoutcontratocorpo_Skin = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Skin");
            Configuracoeslayoutcontratocorpo_Toolbar = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Toolbar");
            Configuracoeslayoutcontratocorpo_Customtoolbar = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Customtoolbar");
            Configuracoeslayoutcontratocorpo_Customconfiguration = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Customconfiguration");
            Configuracoeslayoutcontratocorpo_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Toolbarcancollapse"));
            Configuracoeslayoutcontratocorpo_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Toolbarexpanded"));
            Configuracoeslayoutcontratocorpo_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Color"), ",", "."), 18, MidpointRounding.ToEven));
            Configuracoeslayoutcontratocorpo_Buttonpressedid = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Buttonpressedid");
            Configuracoeslayoutcontratocorpo_Captionvalue = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionvalue");
            Configuracoeslayoutcontratocorpo_Captionclass = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionclass");
            Configuracoeslayoutcontratocorpo_Captionstyle = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionstyle");
            Configuracoeslayoutcontratocorpo_Captionposition = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionposition");
            Configuracoeslayoutcontratocorpo_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Isabstractlayoutcontrol"));
            Configuracoeslayoutcontratocorpo_Coltitle = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Coltitle");
            Configuracoeslayoutcontratocorpo_Coltitlefont = cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Coltitlefont");
            Configuracoeslayoutcontratocorpo_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
            Configuracoeslayoutcontratocorpo_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Usercontroliscolumn"));
            Configuracoeslayoutcontratocorpo_Visible = StringUtil.StrToBool( cgiGet( "CONFIGURACOESLAYOUTCONTRATOCORPO_Visible"));
            Configlayoutcorpopromissoriaclinicaemprestimo_Objectcall = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Objectcall");
            Configlayoutcorpopromissoriaclinicaemprestimo_Class = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Class");
            Configlayoutcorpopromissoriaclinicaemprestimo_Enabled = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Enabled"));
            Configlayoutcorpopromissoriaclinicaemprestimo_Width = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Width");
            Configlayoutcorpopromissoriaclinicaemprestimo_Height = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Height");
            Configlayoutcorpopromissoriaclinicaemprestimo_Skin = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Skin");
            Configlayoutcorpopromissoriaclinicaemprestimo_Toolbar = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Toolbar");
            Configlayoutcorpopromissoriaclinicaemprestimo_Customtoolbar = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Customtoolbar");
            Configlayoutcorpopromissoriaclinicaemprestimo_Customconfiguration = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Customconfiguration");
            Configlayoutcorpopromissoriaclinicaemprestimo_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Toolbarcancollapse"));
            Configlayoutcorpopromissoriaclinicaemprestimo_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Toolbarexpanded"));
            Configlayoutcorpopromissoriaclinicaemprestimo_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Color"), ",", "."), 18, MidpointRounding.ToEven));
            Configlayoutcorpopromissoriaclinicaemprestimo_Buttonpressedid = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Buttonpressedid");
            Configlayoutcorpopromissoriaclinicaemprestimo_Captionvalue = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionvalue");
            Configlayoutcorpopromissoriaclinicaemprestimo_Captionclass = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionclass");
            Configlayoutcorpopromissoriaclinicaemprestimo_Captionstyle = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionstyle");
            Configlayoutcorpopromissoriaclinicaemprestimo_Captionposition = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionposition");
            Configlayoutcorpopromissoriaclinicaemprestimo_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Isabstractlayoutcontrol"));
            Configlayoutcorpopromissoriaclinicaemprestimo_Coltitle = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Coltitle");
            Configlayoutcorpopromissoriaclinicaemprestimo_Coltitlefont = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Coltitlefont");
            Configlayoutcorpopromissoriaclinicaemprestimo_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
            Configlayoutcorpopromissoriaclinicaemprestimo_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Usercontroliscolumn"));
            Configlayoutcorpopromissoriaclinicaemprestimo_Visible = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Visible"));
            Configlayoutcorpopromissoriaclinicataxa_Objectcall = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Objectcall");
            Configlayoutcorpopromissoriaclinicataxa_Class = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Class");
            Configlayoutcorpopromissoriaclinicataxa_Enabled = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Enabled"));
            Configlayoutcorpopromissoriaclinicataxa_Width = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Width");
            Configlayoutcorpopromissoriaclinicataxa_Height = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Height");
            Configlayoutcorpopromissoriaclinicataxa_Skin = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Skin");
            Configlayoutcorpopromissoriaclinicataxa_Toolbar = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Toolbar");
            Configlayoutcorpopromissoriaclinicataxa_Customtoolbar = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Customtoolbar");
            Configlayoutcorpopromissoriaclinicataxa_Customconfiguration = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Customconfiguration");
            Configlayoutcorpopromissoriaclinicataxa_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Toolbarcancollapse"));
            Configlayoutcorpopromissoriaclinicataxa_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Toolbarexpanded"));
            Configlayoutcorpopromissoriaclinicataxa_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Color"), ",", "."), 18, MidpointRounding.ToEven));
            Configlayoutcorpopromissoriaclinicataxa_Buttonpressedid = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Buttonpressedid");
            Configlayoutcorpopromissoriaclinicataxa_Captionvalue = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionvalue");
            Configlayoutcorpopromissoriaclinicataxa_Captionclass = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionclass");
            Configlayoutcorpopromissoriaclinicataxa_Captionstyle = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionstyle");
            Configlayoutcorpopromissoriaclinicataxa_Captionposition = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionposition");
            Configlayoutcorpopromissoriaclinicataxa_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Isabstractlayoutcontrol"));
            Configlayoutcorpopromissoriaclinicataxa_Coltitle = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Coltitle");
            Configlayoutcorpopromissoriaclinicataxa_Coltitlefont = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Coltitlefont");
            Configlayoutcorpopromissoriaclinicataxa_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
            Configlayoutcorpopromissoriaclinicataxa_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Usercontroliscolumn"));
            Configlayoutcorpopromissoriaclinicataxa_Visible = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Visible"));
            Configlayoutcorpopromissoriapaciente_Objectcall = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Objectcall");
            Configlayoutcorpopromissoriapaciente_Class = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Class");
            Configlayoutcorpopromissoriapaciente_Enabled = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Enabled"));
            Configlayoutcorpopromissoriapaciente_Width = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Width");
            Configlayoutcorpopromissoriapaciente_Height = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Height");
            Configlayoutcorpopromissoriapaciente_Skin = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Skin");
            Configlayoutcorpopromissoriapaciente_Toolbar = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Toolbar");
            Configlayoutcorpopromissoriapaciente_Customtoolbar = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Customtoolbar");
            Configlayoutcorpopromissoriapaciente_Customconfiguration = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Customconfiguration");
            Configlayoutcorpopromissoriapaciente_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Toolbarcancollapse"));
            Configlayoutcorpopromissoriapaciente_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Toolbarexpanded"));
            Configlayoutcorpopromissoriapaciente_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Color"), ",", "."), 18, MidpointRounding.ToEven));
            Configlayoutcorpopromissoriapaciente_Buttonpressedid = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Buttonpressedid");
            Configlayoutcorpopromissoriapaciente_Captionvalue = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionvalue");
            Configlayoutcorpopromissoriapaciente_Captionclass = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionclass");
            Configlayoutcorpopromissoriapaciente_Captionstyle = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionstyle");
            Configlayoutcorpopromissoriapaciente_Captionposition = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionposition");
            Configlayoutcorpopromissoriapaciente_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Isabstractlayoutcontrol"));
            Configlayoutcorpopromissoriapaciente_Coltitle = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Coltitle");
            Configlayoutcorpopromissoriapaciente_Coltitlefont = cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Coltitlefont");
            Configlayoutcorpopromissoriapaciente_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
            Configlayoutcorpopromissoriapaciente_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Usercontroliscolumn"));
            Configlayoutcorpopromissoriapaciente_Visible = StringUtil.StrToBool( cgiGet( "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Visible"));
            edtConfiguracoesImagemLogin_Filetype = cgiGet( "CONFIGURACOESIMAGEMLOGIN_Filetype");
            edtConfiguracoesImagemLogin_Filename = cgiGet( "CONFIGURACOESIMAGEMLOGIN_Filename");
            edtConfiguracoesImagemLogin_Filename = cgiGet( "CONFIGURACOESIMAGEMLOGIN_Filename");
            edtConfiguracoesImagemHeader_Filename = cgiGet( "CONFIGURACOESIMAGEMHEADER_Filename");
            edtConfiguracoesArquivoPFX_Filename = cgiGet( "CONFIGURACOESARQUIVOPFX_Filename");
            edtConfiguracoesImagemLogin_Filetype = cgiGet( "CONFIGURACOESIMAGEMLOGIN_Filetype");
            edtConfiguracoesImagemHeader_Filetype = cgiGet( "CONFIGURACOESIMAGEMHEADER_Filetype");
            edtConfiguracoesArquivoPFX_Filetype = cgiGet( "CONFIGURACOESARQUIVOPFX_Filetype");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESID");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A299ConfiguracoesId = 0;
               AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
            }
            else
            {
               A299ConfiguracoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConfiguracoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
            }
            A300ConfiguracoesImagemLogin = cgiGet( edtConfiguracoesImagemLogin_Internalname);
            n300ConfiguracoesImagemLogin = false;
            AssignAttri("", false, "A300ConfiguracoesImagemLogin", A300ConfiguracoesImagemLogin);
            n300ConfiguracoesImagemLogin = (String.IsNullOrEmpty(StringUtil.RTrim( A300ConfiguracoesImagemLogin)) ? true : false);
            A315ConfiguracoesImagemLoginNomeInteiro = cgiGet( edtConfiguracoesImagemLoginNomeInteiro_Internalname);
            n315ConfiguracoesImagemLoginNomeInteiro = false;
            AssignAttri("", false, "A315ConfiguracoesImagemLoginNomeInteiro", A315ConfiguracoesImagemLoginNomeInteiro);
            n315ConfiguracoesImagemLoginNomeInteiro = (String.IsNullOrEmpty(StringUtil.RTrim( A315ConfiguracoesImagemLoginNomeInteiro)) ? true : false);
            n316ConfiguracoesImagemLoginTamanho = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesImagemLoginTamanho_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesImagemLoginTamanho_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesImagemLoginTamanho_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESIMAGEMLOGINTAMANHO");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesImagemLoginTamanho_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A316ConfiguracoesImagemLoginTamanho = 0;
               n316ConfiguracoesImagemLoginTamanho = false;
               AssignAttri("", false, "A316ConfiguracoesImagemLoginTamanho", (n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ".", ""))));
            }
            else
            {
               A316ConfiguracoesImagemLoginTamanho = context.localUtil.CToN( cgiGet( edtConfiguracoesImagemLoginTamanho_Internalname), ",", ".");
               AssignAttri("", false, "A316ConfiguracoesImagemLoginTamanho", (n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ".", ""))));
            }
            A317ConfiguracoesImagemLoginBackground = cgiGet( edtConfiguracoesImagemLoginBackground_Internalname);
            n317ConfiguracoesImagemLoginBackground = false;
            AssignAttri("", false, "A317ConfiguracoesImagemLoginBackground", A317ConfiguracoesImagemLoginBackground);
            n317ConfiguracoesImagemLoginBackground = (String.IsNullOrEmpty(StringUtil.RTrim( A317ConfiguracoesImagemLoginBackground)) ? true : false);
            A318ConfiguracoesImagemHeader = cgiGet( edtConfiguracoesImagemHeader_Internalname);
            n318ConfiguracoesImagemHeader = false;
            AssignAttri("", false, "A318ConfiguracoesImagemHeader", A318ConfiguracoesImagemHeader);
            n318ConfiguracoesImagemHeader = (String.IsNullOrEmpty(StringUtil.RTrim( A318ConfiguracoesImagemHeader)) ? true : false);
            A319ConfiguracoesImagemHeaderNome = cgiGet( edtConfiguracoesImagemHeaderNome_Internalname);
            n319ConfiguracoesImagemHeaderNome = false;
            AssignAttri("", false, "A319ConfiguracoesImagemHeaderNome", A319ConfiguracoesImagemHeaderNome);
            n319ConfiguracoesImagemHeaderNome = (String.IsNullOrEmpty(StringUtil.RTrim( A319ConfiguracoesImagemHeaderNome)) ? true : false);
            A320ConfiguracoesImagemHeaderExtencao = cgiGet( edtConfiguracoesImagemHeaderExtencao_Internalname);
            n320ConfiguracoesImagemHeaderExtencao = false;
            AssignAttri("", false, "A320ConfiguracoesImagemHeaderExtencao", A320ConfiguracoesImagemHeaderExtencao);
            n320ConfiguracoesImagemHeaderExtencao = (String.IsNullOrEmpty(StringUtil.RTrim( A320ConfiguracoesImagemHeaderExtencao)) ? true : false);
            A321ConfiguracoesImagemHeaderNomeInteiro = cgiGet( edtConfiguracoesImagemHeaderNomeInteiro_Internalname);
            n321ConfiguracoesImagemHeaderNomeInteiro = false;
            AssignAttri("", false, "A321ConfiguracoesImagemHeaderNomeInteiro", A321ConfiguracoesImagemHeaderNomeInteiro);
            n321ConfiguracoesImagemHeaderNomeInteiro = (String.IsNullOrEmpty(StringUtil.RTrim( A321ConfiguracoesImagemHeaderNomeInteiro)) ? true : false);
            n322ConfiguracoesImagemHeaderTamanho = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesImagemHeaderTamanho_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesImagemHeaderTamanho_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesImagemHeaderTamanho_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESIMAGEMHEADERTAMANHO");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesImagemHeaderTamanho_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A322ConfiguracoesImagemHeaderTamanho = 0;
               n322ConfiguracoesImagemHeaderTamanho = false;
               AssignAttri("", false, "A322ConfiguracoesImagemHeaderTamanho", (n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", ""))));
            }
            else
            {
               A322ConfiguracoesImagemHeaderTamanho = context.localUtil.CToN( cgiGet( edtConfiguracoesImagemHeaderTamanho_Internalname), ",", ".");
               AssignAttri("", false, "A322ConfiguracoesImagemHeaderTamanho", (n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", ""))));
            }
            n398ConfiguracoesLayoutProposta = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesLayoutProposta_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesLayoutProposta_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesLayoutProposta_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESLAYOUTPROPOSTA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesLayoutProposta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A398ConfiguracoesLayoutProposta = 0;
               n398ConfiguracoesLayoutProposta = false;
               AssignAttri("", false, "A398ConfiguracoesLayoutProposta", (n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            }
            else
            {
               A398ConfiguracoesLayoutProposta = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfiguracoesLayoutProposta_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A398ConfiguracoesLayoutProposta", (n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            }
            n564ConfigLayoutPromissoriaClinicaEmprestimo = ((StringUtil.StrCmp(cgiGet( edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A564ConfigLayoutPromissoriaClinicaEmprestimo = 0;
               n564ConfigLayoutPromissoriaClinicaEmprestimo = false;
               AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", (n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
            }
            else
            {
               A564ConfigLayoutPromissoriaClinicaEmprestimo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", (n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
            }
            n565ConfigLayoutPromissoriaClinicaTaxa = ((StringUtil.StrCmp(cgiGet( edtConfigLayoutPromissoriaClinicaTaxa_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaClinicaTaxa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaClinicaTaxa_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGLAYOUTPROMISSORIACLINICATAXA");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaTaxa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A565ConfigLayoutPromissoriaClinicaTaxa = 0;
               n565ConfigLayoutPromissoriaClinicaTaxa = false;
               AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", (n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
            }
            else
            {
               A565ConfigLayoutPromissoriaClinicaTaxa = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaClinicaTaxa_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", (n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
            }
            n566ConfigLayoutPromissoriaPaciente = ((StringUtil.StrCmp(cgiGet( edtConfigLayoutPromissoriaPaciente_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaPaciente_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaPaciente_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGLAYOUTPROMISSORIAPACIENTE");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaPaciente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A566ConfigLayoutPromissoriaPaciente = 0;
               n566ConfigLayoutPromissoriaPaciente = false;
               AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", (n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
            }
            else
            {
               A566ConfigLayoutPromissoriaPaciente = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigLayoutPromissoriaPaciente_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", (n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
            }
            n922ConfigLayoutContratoCompraTitulo = ((StringUtil.StrCmp(cgiGet( edtConfigLayoutContratoCompraTitulo_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutContratoCompraTitulo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfigLayoutContratoCompraTitulo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGLAYOUTCONTRATOCOMPRATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutContratoCompraTitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A922ConfigLayoutContratoCompraTitulo = 0;
               n922ConfigLayoutContratoCompraTitulo = false;
               AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", (n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            }
            else
            {
               A922ConfigLayoutContratoCompraTitulo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigLayoutContratoCompraTitulo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", (n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            }
            A562ConfiguracoesArquivoPFX = cgiGet( edtConfiguracoesArquivoPFX_Internalname);
            n562ConfiguracoesArquivoPFX = false;
            AssignAttri("", false, "A562ConfiguracoesArquivoPFX", A562ConfiguracoesArquivoPFX);
            n562ConfiguracoesArquivoPFX = (String.IsNullOrEmpty(StringUtil.RTrim( A562ConfiguracoesArquivoPFX)) ? true : false);
            A563ConfiguracaoSenhaPFX = cgiGet( edtConfiguracaoSenhaPFX_Internalname);
            n563ConfiguracaoSenhaPFX = false;
            AssignAttri("", false, "A563ConfiguracaoSenhaPFX", A563ConfiguracaoSenhaPFX);
            n563ConfiguracaoSenhaPFX = (String.IsNullOrEmpty(StringUtil.RTrim( A563ConfiguracaoSenhaPFX)) ? true : false);
            n654ConfiguracoesCategoriaTitulo = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesCategoriaTitulo_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCategoriaTitulo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCategoriaTitulo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESCATEGORIATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCategoriaTitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A654ConfiguracoesCategoriaTitulo = 0;
               n654ConfiguracoesCategoriaTitulo = false;
               AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", (n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
            }
            else
            {
               A654ConfiguracoesCategoriaTitulo = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConfiguracoesCategoriaTitulo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", (n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
            }
            cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = cgiGet( cmbConfiguracoesSerasaAnotacoesCompletas_Internalname);
            A765ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cgiGet( cmbConfiguracoesSerasaAnotacoesCompletas_Internalname));
            n765ConfiguracoesSerasaAnotacoesCompletas = false;
            AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
            n765ConfiguracoesSerasaAnotacoesCompletas = ((false==A765ConfiguracoesSerasaAnotacoesCompletas) ? true : false);
            cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = cgiGet( cmbConfiguracoesSerasaConsultaDetalhada_Internalname);
            A766ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cgiGet( cmbConfiguracoesSerasaConsultaDetalhada_Internalname));
            n766ConfiguracoesSerasaConsultaDetalhada = false;
            AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
            n766ConfiguracoesSerasaConsultaDetalhada = ((false==A766ConfiguracoesSerasaConsultaDetalhada) ? true : false);
            cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = cgiGet( cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname);
            A767ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cgiGet( cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname));
            n767ConfiguracoesSerasaParticipacaoSocietaria = false;
            AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
            n767ConfiguracoesSerasaParticipacaoSocietaria = ((false==A767ConfiguracoesSerasaParticipacaoSocietaria) ? true : false);
            cmbConfiguracoesSerasaRendaEstimada.CurrentValue = cgiGet( cmbConfiguracoesSerasaRendaEstimada_Internalname);
            A768ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cgiGet( cmbConfiguracoesSerasaRendaEstimada_Internalname));
            n768ConfiguracoesSerasaRendaEstimada = false;
            AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
            n768ConfiguracoesSerasaRendaEstimada = ((false==A768ConfiguracoesSerasaRendaEstimada) ? true : false);
            cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = cgiGet( cmbConfiguracoesSerasaHistoricoPagamento_Internalname);
            A769ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cgiGet( cmbConfiguracoesSerasaHistoricoPagamento_Internalname));
            n769ConfiguracoesSerasaHistoricoPagamento = false;
            AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
            n769ConfiguracoesSerasaHistoricoPagamento = ((false==A769ConfiguracoesSerasaHistoricoPagamento) ? true : false);
            n1013ConfiguracoesCompraTituloTaxaEfetiva = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesCompraTituloTaxaEfetiva_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTaxaEfetiva_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTaxaEfetiva_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESCOMPRATITULOTAXAEFETIVA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCompraTituloTaxaEfetiva_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1013ConfiguracoesCompraTituloTaxaEfetiva = 0;
               n1013ConfiguracoesCompraTituloTaxaEfetiva = false;
               AssignAttri("", false, "A1013ConfiguracoesCompraTituloTaxaEfetiva", (n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", ""))));
            }
            else
            {
               A1013ConfiguracoesCompraTituloTaxaEfetiva = context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTaxaEfetiva_Internalname), ",", ".");
               AssignAttri("", false, "A1013ConfiguracoesCompraTituloTaxaEfetiva", (n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", ""))));
            }
            n1014ConfiguracoesCompraTituloTaxaMora = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesCompraTituloTaxaMora_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTaxaMora_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTaxaMora_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESCOMPRATITULOTAXAMORA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCompraTituloTaxaMora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1014ConfiguracoesCompraTituloTaxaMora = 0;
               n1014ConfiguracoesCompraTituloTaxaMora = false;
               AssignAttri("", false, "A1014ConfiguracoesCompraTituloTaxaMora", (n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", ""))));
            }
            else
            {
               A1014ConfiguracoesCompraTituloTaxaMora = context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTaxaMora_Internalname), ",", ".");
               AssignAttri("", false, "A1014ConfiguracoesCompraTituloTaxaMora", (n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", ""))));
            }
            n1036ConfiguracoesCompraTituloFator = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesCompraTituloFator_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloFator_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloFator_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESCOMPRATITULOFATOR");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCompraTituloFator_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1036ConfiguracoesCompraTituloFator = 0;
               n1036ConfiguracoesCompraTituloFator = false;
               AssignAttri("", false, "A1036ConfiguracoesCompraTituloFator", (n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 16, 4, ".", ""))));
            }
            else
            {
               A1036ConfiguracoesCompraTituloFator = context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloFator_Internalname), ",", ".");
               AssignAttri("", false, "A1036ConfiguracoesCompraTituloFator", (n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 16, 4, ".", ""))));
            }
            cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = cgiGet( cmbConfiguracoesCompraTituloTarifaTipo_Internalname);
            A1037ConfiguracoesCompraTituloTarifaTipo = cgiGet( cmbConfiguracoesCompraTituloTarifaTipo_Internalname);
            n1037ConfiguracoesCompraTituloTarifaTipo = false;
            AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
            n1037ConfiguracoesCompraTituloTarifaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo)) ? true : false);
            n1038ConfiguracoesCompraTituloTarifa = ((StringUtil.StrCmp(cgiGet( edtConfiguracoesCompraTituloTarifa_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTarifa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTarifa_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONFIGURACOESCOMPRATITULOTARIFA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCompraTituloTarifa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1038ConfiguracoesCompraTituloTarifa = 0;
               n1038ConfiguracoesCompraTituloTarifa = false;
               AssignAttri("", false, "A1038ConfiguracoesCompraTituloTarifa", (n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", ""))));
            }
            else
            {
               A1038ConfiguracoesCompraTituloTarifa = context.localUtil.CToN( cgiGet( edtConfiguracoesCompraTituloTarifa_Internalname), ",", ".");
               AssignAttri("", false, "A1038ConfiguracoesCompraTituloTarifa", (n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", ""))));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A300ConfiguracoesImagemLogin)) )
            {
               edtConfiguracoesImagemLogin_Filename = (string)(CGIGetFileName(edtConfiguracoesImagemLogin_Internalname));
               edtConfiguracoesImagemLogin_Filetype = (string)(CGIGetFileType(edtConfiguracoesImagemLogin_Internalname));
            }
            A312ConfiguracoesImagemLoginExtencao = edtConfiguracoesImagemLogin_Filetype;
            n312ConfiguracoesImagemLoginExtencao = false;
            AssignAttri("", false, "A312ConfiguracoesImagemLoginExtencao", A312ConfiguracoesImagemLoginExtencao);
            A313ConfiguracoesImagemLoginNome = edtConfiguracoesImagemLogin_Filename;
            n313ConfiguracoesImagemLoginNome = false;
            AssignAttri("", false, "A313ConfiguracoesImagemLoginNome", A313ConfiguracoesImagemLoginNome);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A300ConfiguracoesImagemLogin)) )
            {
               GXCCtlgxBlob = "CONFIGURACOESIMAGEMLOGIN" + "_gxBlob";
               A300ConfiguracoesImagemLogin = cgiGet( GXCCtlgxBlob);
               n300ConfiguracoesImagemLogin = false;
               n300ConfiguracoesImagemLogin = (String.IsNullOrEmpty(StringUtil.RTrim( A300ConfiguracoesImagemLogin)) ? true : false);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A318ConfiguracoesImagemHeader)) )
            {
               edtConfiguracoesImagemHeader_Filename = (string)(CGIGetFileName(edtConfiguracoesImagemHeader_Internalname));
               edtConfiguracoesImagemHeader_Filetype = (string)(CGIGetFileType(edtConfiguracoesImagemHeader_Internalname));
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A318ConfiguracoesImagemHeader)) )
            {
               GXCCtlgxBlob = "CONFIGURACOESIMAGEMHEADER" + "_gxBlob";
               A318ConfiguracoesImagemHeader = cgiGet( GXCCtlgxBlob);
               n318ConfiguracoesImagemHeader = false;
               n318ConfiguracoesImagemHeader = (String.IsNullOrEmpty(StringUtil.RTrim( A318ConfiguracoesImagemHeader)) ? true : false);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A562ConfiguracoesArquivoPFX)) )
            {
               edtConfiguracoesArquivoPFX_Filename = (string)(CGIGetFileName(edtConfiguracoesArquivoPFX_Internalname));
               edtConfiguracoesArquivoPFX_Filetype = (string)(CGIGetFileType(edtConfiguracoesArquivoPFX_Internalname));
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A562ConfiguracoesArquivoPFX)) )
            {
               GXCCtlgxBlob = "CONFIGURACOESARQUIVOPFX" + "_gxBlob";
               A562ConfiguracoesArquivoPFX = cgiGet( GXCCtlgxBlob);
               n562ConfiguracoesArquivoPFX = false;
               n562ConfiguracoesArquivoPFX = (String.IsNullOrEmpty(StringUtil.RTrim( A562ConfiguracoesArquivoPFX)) ? true : false);
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
               A299ConfiguracoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConfiguracoesId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
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
               InitAll1948( ) ;
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
         DisableAttributes1948( ) ;
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

      protected void ResetCaption190( )
      {
      }

      protected void ZM1948( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z315ConfiguracoesImagemLoginNomeInteiro = T00193_A315ConfiguracoesImagemLoginNomeInteiro[0];
               Z316ConfiguracoesImagemLoginTamanho = T00193_A316ConfiguracoesImagemLoginTamanho[0];
               Z317ConfiguracoesImagemLoginBackground = T00193_A317ConfiguracoesImagemLoginBackground[0];
               Z319ConfiguracoesImagemHeaderNome = T00193_A319ConfiguracoesImagemHeaderNome[0];
               Z320ConfiguracoesImagemHeaderExtencao = T00193_A320ConfiguracoesImagemHeaderExtencao[0];
               Z321ConfiguracoesImagemHeaderNomeInteiro = T00193_A321ConfiguracoesImagemHeaderNomeInteiro[0];
               Z322ConfiguracoesImagemHeaderTamanho = T00193_A322ConfiguracoesImagemHeaderTamanho[0];
               Z563ConfiguracaoSenhaPFX = T00193_A563ConfiguracaoSenhaPFX[0];
               Z765ConfiguracoesSerasaAnotacoesCompletas = T00193_A765ConfiguracoesSerasaAnotacoesCompletas[0];
               Z766ConfiguracoesSerasaConsultaDetalhada = T00193_A766ConfiguracoesSerasaConsultaDetalhada[0];
               Z767ConfiguracoesSerasaParticipacaoSocietaria = T00193_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
               Z768ConfiguracoesSerasaRendaEstimada = T00193_A768ConfiguracoesSerasaRendaEstimada[0];
               Z769ConfiguracoesSerasaHistoricoPagamento = T00193_A769ConfiguracoesSerasaHistoricoPagamento[0];
               Z1013ConfiguracoesCompraTituloTaxaEfetiva = T00193_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
               Z1014ConfiguracoesCompraTituloTaxaMora = T00193_A1014ConfiguracoesCompraTituloTaxaMora[0];
               Z1036ConfiguracoesCompraTituloFator = T00193_A1036ConfiguracoesCompraTituloFator[0];
               Z1037ConfiguracoesCompraTituloTarifaTipo = T00193_A1037ConfiguracoesCompraTituloTarifaTipo[0];
               Z1038ConfiguracoesCompraTituloTarifa = T00193_A1038ConfiguracoesCompraTituloTarifa[0];
               Z398ConfiguracoesLayoutProposta = T00193_A398ConfiguracoesLayoutProposta[0];
               Z564ConfigLayoutPromissoriaClinicaEmprestimo = T00193_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
               Z565ConfigLayoutPromissoriaClinicaTaxa = T00193_A565ConfigLayoutPromissoriaClinicaTaxa[0];
               Z566ConfigLayoutPromissoriaPaciente = T00193_A566ConfigLayoutPromissoriaPaciente[0];
               Z922ConfigLayoutContratoCompraTitulo = T00193_A922ConfigLayoutContratoCompraTitulo[0];
               Z654ConfiguracoesCategoriaTitulo = T00193_A654ConfiguracoesCategoriaTitulo[0];
            }
            else
            {
               Z315ConfiguracoesImagemLoginNomeInteiro = A315ConfiguracoesImagemLoginNomeInteiro;
               Z316ConfiguracoesImagemLoginTamanho = A316ConfiguracoesImagemLoginTamanho;
               Z317ConfiguracoesImagemLoginBackground = A317ConfiguracoesImagemLoginBackground;
               Z319ConfiguracoesImagemHeaderNome = A319ConfiguracoesImagemHeaderNome;
               Z320ConfiguracoesImagemHeaderExtencao = A320ConfiguracoesImagemHeaderExtencao;
               Z321ConfiguracoesImagemHeaderNomeInteiro = A321ConfiguracoesImagemHeaderNomeInteiro;
               Z322ConfiguracoesImagemHeaderTamanho = A322ConfiguracoesImagemHeaderTamanho;
               Z563ConfiguracaoSenhaPFX = A563ConfiguracaoSenhaPFX;
               Z765ConfiguracoesSerasaAnotacoesCompletas = A765ConfiguracoesSerasaAnotacoesCompletas;
               Z766ConfiguracoesSerasaConsultaDetalhada = A766ConfiguracoesSerasaConsultaDetalhada;
               Z767ConfiguracoesSerasaParticipacaoSocietaria = A767ConfiguracoesSerasaParticipacaoSocietaria;
               Z768ConfiguracoesSerasaRendaEstimada = A768ConfiguracoesSerasaRendaEstimada;
               Z769ConfiguracoesSerasaHistoricoPagamento = A769ConfiguracoesSerasaHistoricoPagamento;
               Z1013ConfiguracoesCompraTituloTaxaEfetiva = A1013ConfiguracoesCompraTituloTaxaEfetiva;
               Z1014ConfiguracoesCompraTituloTaxaMora = A1014ConfiguracoesCompraTituloTaxaMora;
               Z1036ConfiguracoesCompraTituloFator = A1036ConfiguracoesCompraTituloFator;
               Z1037ConfiguracoesCompraTituloTarifaTipo = A1037ConfiguracoesCompraTituloTarifaTipo;
               Z1038ConfiguracoesCompraTituloTarifa = A1038ConfiguracoesCompraTituloTarifa;
               Z398ConfiguracoesLayoutProposta = A398ConfiguracoesLayoutProposta;
               Z564ConfigLayoutPromissoriaClinicaEmprestimo = A564ConfigLayoutPromissoriaClinicaEmprestimo;
               Z565ConfigLayoutPromissoriaClinicaTaxa = A565ConfigLayoutPromissoriaClinicaTaxa;
               Z566ConfigLayoutPromissoriaPaciente = A566ConfigLayoutPromissoriaPaciente;
               Z922ConfigLayoutContratoCompraTitulo = A922ConfigLayoutContratoCompraTitulo;
               Z654ConfiguracoesCategoriaTitulo = A654ConfiguracoesCategoriaTitulo;
            }
         }
         if ( GX_JID == -3 )
         {
            Z299ConfiguracoesId = A299ConfiguracoesId;
            Z300ConfiguracoesImagemLogin = A300ConfiguracoesImagemLogin;
            Z315ConfiguracoesImagemLoginNomeInteiro = A315ConfiguracoesImagemLoginNomeInteiro;
            Z316ConfiguracoesImagemLoginTamanho = A316ConfiguracoesImagemLoginTamanho;
            Z317ConfiguracoesImagemLoginBackground = A317ConfiguracoesImagemLoginBackground;
            Z318ConfiguracoesImagemHeader = A318ConfiguracoesImagemHeader;
            Z319ConfiguracoesImagemHeaderNome = A319ConfiguracoesImagemHeaderNome;
            Z320ConfiguracoesImagemHeaderExtencao = A320ConfiguracoesImagemHeaderExtencao;
            Z321ConfiguracoesImagemHeaderNomeInteiro = A321ConfiguracoesImagemHeaderNomeInteiro;
            Z322ConfiguracoesImagemHeaderTamanho = A322ConfiguracoesImagemHeaderTamanho;
            Z562ConfiguracoesArquivoPFX = A562ConfiguracoesArquivoPFX;
            Z563ConfiguracaoSenhaPFX = A563ConfiguracaoSenhaPFX;
            Z765ConfiguracoesSerasaAnotacoesCompletas = A765ConfiguracoesSerasaAnotacoesCompletas;
            Z766ConfiguracoesSerasaConsultaDetalhada = A766ConfiguracoesSerasaConsultaDetalhada;
            Z767ConfiguracoesSerasaParticipacaoSocietaria = A767ConfiguracoesSerasaParticipacaoSocietaria;
            Z768ConfiguracoesSerasaRendaEstimada = A768ConfiguracoesSerasaRendaEstimada;
            Z769ConfiguracoesSerasaHistoricoPagamento = A769ConfiguracoesSerasaHistoricoPagamento;
            Z1013ConfiguracoesCompraTituloTaxaEfetiva = A1013ConfiguracoesCompraTituloTaxaEfetiva;
            Z1014ConfiguracoesCompraTituloTaxaMora = A1014ConfiguracoesCompraTituloTaxaMora;
            Z1036ConfiguracoesCompraTituloFator = A1036ConfiguracoesCompraTituloFator;
            Z1037ConfiguracoesCompraTituloTarifaTipo = A1037ConfiguracoesCompraTituloTarifaTipo;
            Z1038ConfiguracoesCompraTituloTarifa = A1038ConfiguracoesCompraTituloTarifa;
            Z312ConfiguracoesImagemLoginExtencao = A312ConfiguracoesImagemLoginExtencao;
            Z313ConfiguracoesImagemLoginNome = A313ConfiguracoesImagemLoginNome;
            Z398ConfiguracoesLayoutProposta = A398ConfiguracoesLayoutProposta;
            Z564ConfigLayoutPromissoriaClinicaEmprestimo = A564ConfigLayoutPromissoriaClinicaEmprestimo;
            Z565ConfigLayoutPromissoriaClinicaTaxa = A565ConfigLayoutPromissoriaClinicaTaxa;
            Z566ConfigLayoutPromissoriaPaciente = A566ConfigLayoutPromissoriaPaciente;
            Z922ConfigLayoutContratoCompraTitulo = A922ConfigLayoutContratoCompraTitulo;
            Z654ConfiguracoesCategoriaTitulo = A654ConfiguracoesCategoriaTitulo;
            Z418ConfiguracoesLayoutContratoCorpo = A418ConfiguracoesLayoutContratoCorpo;
            Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo;
            Z568ConfigLayoutCorpoPromissoriaClinicaTaxa = A568ConfigLayoutCorpoPromissoriaClinicaTaxa;
            Z569ConfigLayoutCorpoPromissoriaPaciente = A569ConfigLayoutCorpoPromissoriaPaciente;
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

      protected void Load1948( )
      {
         /* Using cursor T001910 */
         pr_default.execute(8, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound48 = 1;
            A315ConfiguracoesImagemLoginNomeInteiro = T001910_A315ConfiguracoesImagemLoginNomeInteiro[0];
            n315ConfiguracoesImagemLoginNomeInteiro = T001910_n315ConfiguracoesImagemLoginNomeInteiro[0];
            AssignAttri("", false, "A315ConfiguracoesImagemLoginNomeInteiro", A315ConfiguracoesImagemLoginNomeInteiro);
            A316ConfiguracoesImagemLoginTamanho = T001910_A316ConfiguracoesImagemLoginTamanho[0];
            n316ConfiguracoesImagemLoginTamanho = T001910_n316ConfiguracoesImagemLoginTamanho[0];
            AssignAttri("", false, "A316ConfiguracoesImagemLoginTamanho", ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho)&&IsIns( )||n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ".", ""))));
            A317ConfiguracoesImagemLoginBackground = T001910_A317ConfiguracoesImagemLoginBackground[0];
            n317ConfiguracoesImagemLoginBackground = T001910_n317ConfiguracoesImagemLoginBackground[0];
            AssignAttri("", false, "A317ConfiguracoesImagemLoginBackground", A317ConfiguracoesImagemLoginBackground);
            A319ConfiguracoesImagemHeaderNome = T001910_A319ConfiguracoesImagemHeaderNome[0];
            n319ConfiguracoesImagemHeaderNome = T001910_n319ConfiguracoesImagemHeaderNome[0];
            AssignAttri("", false, "A319ConfiguracoesImagemHeaderNome", A319ConfiguracoesImagemHeaderNome);
            A320ConfiguracoesImagemHeaderExtencao = T001910_A320ConfiguracoesImagemHeaderExtencao[0];
            n320ConfiguracoesImagemHeaderExtencao = T001910_n320ConfiguracoesImagemHeaderExtencao[0];
            AssignAttri("", false, "A320ConfiguracoesImagemHeaderExtencao", A320ConfiguracoesImagemHeaderExtencao);
            A321ConfiguracoesImagemHeaderNomeInteiro = T001910_A321ConfiguracoesImagemHeaderNomeInteiro[0];
            n321ConfiguracoesImagemHeaderNomeInteiro = T001910_n321ConfiguracoesImagemHeaderNomeInteiro[0];
            AssignAttri("", false, "A321ConfiguracoesImagemHeaderNomeInteiro", A321ConfiguracoesImagemHeaderNomeInteiro);
            A322ConfiguracoesImagemHeaderTamanho = T001910_A322ConfiguracoesImagemHeaderTamanho[0];
            n322ConfiguracoesImagemHeaderTamanho = T001910_n322ConfiguracoesImagemHeaderTamanho[0];
            AssignAttri("", false, "A322ConfiguracoesImagemHeaderTamanho", ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho)&&IsIns( )||n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", ""))));
            A418ConfiguracoesLayoutContratoCorpo = T001910_A418ConfiguracoesLayoutContratoCorpo[0];
            n418ConfiguracoesLayoutContratoCorpo = T001910_n418ConfiguracoesLayoutContratoCorpo[0];
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            A569ConfigLayoutCorpoPromissoriaPaciente = T001910_A569ConfigLayoutCorpoPromissoriaPaciente[0];
            n569ConfigLayoutCorpoPromissoriaPaciente = T001910_n569ConfigLayoutCorpoPromissoriaPaciente[0];
            A563ConfiguracaoSenhaPFX = T001910_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = T001910_n563ConfiguracaoSenhaPFX[0];
            AssignAttri("", false, "A563ConfiguracaoSenhaPFX", A563ConfiguracaoSenhaPFX);
            A765ConfiguracoesSerasaAnotacoesCompletas = T001910_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = T001910_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
            A766ConfiguracoesSerasaConsultaDetalhada = T001910_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = T001910_n766ConfiguracoesSerasaConsultaDetalhada[0];
            AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
            A767ConfiguracoesSerasaParticipacaoSocietaria = T001910_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = T001910_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
            A768ConfiguracoesSerasaRendaEstimada = T001910_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = T001910_n768ConfiguracoesSerasaRendaEstimada[0];
            AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
            A769ConfiguracoesSerasaHistoricoPagamento = T001910_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = T001910_n769ConfiguracoesSerasaHistoricoPagamento[0];
            AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
            A1013ConfiguracoesCompraTituloTaxaEfetiva = T001910_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            n1013ConfiguracoesCompraTituloTaxaEfetiva = T001910_n1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            AssignAttri("", false, "A1013ConfiguracoesCompraTituloTaxaEfetiva", ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva)&&IsIns( )||n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", ""))));
            A1014ConfiguracoesCompraTituloTaxaMora = T001910_A1014ConfiguracoesCompraTituloTaxaMora[0];
            n1014ConfiguracoesCompraTituloTaxaMora = T001910_n1014ConfiguracoesCompraTituloTaxaMora[0];
            AssignAttri("", false, "A1014ConfiguracoesCompraTituloTaxaMora", ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora)&&IsIns( )||n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", ""))));
            A1036ConfiguracoesCompraTituloFator = T001910_A1036ConfiguracoesCompraTituloFator[0];
            n1036ConfiguracoesCompraTituloFator = T001910_n1036ConfiguracoesCompraTituloFator[0];
            AssignAttri("", false, "A1036ConfiguracoesCompraTituloFator", ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator)&&IsIns( )||n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 16, 4, ".", ""))));
            A1037ConfiguracoesCompraTituloTarifaTipo = T001910_A1037ConfiguracoesCompraTituloTarifaTipo[0];
            n1037ConfiguracoesCompraTituloTarifaTipo = T001910_n1037ConfiguracoesCompraTituloTarifaTipo[0];
            AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
            A1038ConfiguracoesCompraTituloTarifa = T001910_A1038ConfiguracoesCompraTituloTarifa[0];
            n1038ConfiguracoesCompraTituloTarifa = T001910_n1038ConfiguracoesCompraTituloTarifa[0];
            AssignAttri("", false, "A1038ConfiguracoesCompraTituloTarifa", ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa)&&IsIns( )||n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", ""))));
            A312ConfiguracoesImagemLoginExtencao = T001910_A312ConfiguracoesImagemLoginExtencao[0];
            n312ConfiguracoesImagemLoginExtencao = T001910_n312ConfiguracoesImagemLoginExtencao[0];
            edtConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
            AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Filetype", edtConfiguracoesImagemLogin_Filetype, true);
            A313ConfiguracoesImagemLoginNome = T001910_A313ConfiguracoesImagemLoginNome[0];
            n313ConfiguracoesImagemLoginNome = T001910_n313ConfiguracoesImagemLoginNome[0];
            edtConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
            A398ConfiguracoesLayoutProposta = T001910_A398ConfiguracoesLayoutProposta[0];
            n398ConfiguracoesLayoutProposta = T001910_n398ConfiguracoesLayoutProposta[0];
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            A564ConfigLayoutPromissoriaClinicaEmprestimo = T001910_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            n564ConfigLayoutPromissoriaClinicaEmprestimo = T001910_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
            A565ConfigLayoutPromissoriaClinicaTaxa = T001910_A565ConfigLayoutPromissoriaClinicaTaxa[0];
            n565ConfigLayoutPromissoriaClinicaTaxa = T001910_n565ConfigLayoutPromissoriaClinicaTaxa[0];
            AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
            A566ConfigLayoutPromissoriaPaciente = T001910_A566ConfigLayoutPromissoriaPaciente[0];
            n566ConfigLayoutPromissoriaPaciente = T001910_n566ConfigLayoutPromissoriaPaciente[0];
            AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
            A922ConfigLayoutContratoCompraTitulo = T001910_A922ConfigLayoutContratoCompraTitulo[0];
            n922ConfigLayoutContratoCompraTitulo = T001910_n922ConfigLayoutContratoCompraTitulo[0];
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            A654ConfiguracoesCategoriaTitulo = T001910_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = T001910_n654ConfiguracoesCategoriaTitulo[0];
            AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
            A300ConfiguracoesImagemLogin = T001910_A300ConfiguracoesImagemLogin[0];
            n300ConfiguracoesImagemLogin = T001910_n300ConfiguracoesImagemLogin[0];
            AssignAttri("", false, "A300ConfiguracoesImagemLogin", A300ConfiguracoesImagemLogin);
            AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "URL", context.PathToRelativeUrl( A300ConfiguracoesImagemLogin), true);
            A318ConfiguracoesImagemHeader = T001910_A318ConfiguracoesImagemHeader[0];
            n318ConfiguracoesImagemHeader = T001910_n318ConfiguracoesImagemHeader[0];
            AssignAttri("", false, "A318ConfiguracoesImagemHeader", A318ConfiguracoesImagemHeader);
            AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "URL", context.PathToRelativeUrl( A318ConfiguracoesImagemHeader), true);
            A562ConfiguracoesArquivoPFX = T001910_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = T001910_n562ConfiguracoesArquivoPFX[0];
            AssignAttri("", false, "A562ConfiguracoesArquivoPFX", A562ConfiguracoesArquivoPFX);
            AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "URL", context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX), true);
            ZM1948( -3) ;
         }
         pr_default.close(8);
         OnLoadActions1948( ) ;
      }

      protected void OnLoadActions1948( )
      {
         if ( (0==A398ConfiguracoesLayoutProposta) )
         {
            A398ConfiguracoesLayoutProposta = 0;
            n398ConfiguracoesLayoutProposta = false;
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            n398ConfiguracoesLayoutProposta = true;
            n398ConfiguracoesLayoutProposta = true;
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
         }
         if ( (0==A922ConfigLayoutContratoCompraTitulo) )
         {
            A922ConfigLayoutContratoCompraTitulo = 0;
            n922ConfigLayoutContratoCompraTitulo = false;
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            n922ConfigLayoutContratoCompraTitulo = true;
            n922ConfigLayoutContratoCompraTitulo = true;
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
         }
      }

      protected void CheckExtendedTable1948( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( (0==A398ConfiguracoesLayoutProposta) )
         {
            A398ConfiguracoesLayoutProposta = 0;
            n398ConfiguracoesLayoutProposta = false;
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            n398ConfiguracoesLayoutProposta = true;
            n398ConfiguracoesLayoutProposta = true;
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
         }
         /* Using cursor T00194 */
         pr_default.execute(2, new Object[] {n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A398ConfiguracoesLayoutProposta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Proposta Config'.", "ForeignKeyNotFound", 1, "CONFIGURACOESLAYOUTPROPOSTA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesLayoutProposta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A418ConfiguracoesLayoutContratoCorpo = T00194_A418ConfiguracoesLayoutContratoCorpo[0];
         n418ConfiguracoesLayoutContratoCorpo = T00194_n418ConfiguracoesLayoutContratoCorpo[0];
         pr_default.close(2);
         /* Using cursor T00195 */
         pr_default.execute(3, new Object[] {n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A564ConfigLayoutPromissoriaClinicaEmprestimo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Emprestimo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         pr_default.close(3);
         /* Using cursor T00196 */
         pr_default.execute(4, new Object[] {n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A565ConfigLayoutPromissoriaClinicaTaxa) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Taxa'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICATAXA");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaTaxa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = T00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = T00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         pr_default.close(4);
         /* Using cursor T00197 */
         pr_default.execute(5, new Object[] {n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A566ConfigLayoutPromissoriaPaciente) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Paciente'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIAPACIENTE");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaPaciente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A569ConfigLayoutCorpoPromissoriaPaciente = T00197_A569ConfigLayoutCorpoPromissoriaPaciente[0];
         n569ConfigLayoutCorpoPromissoriaPaciente = T00197_n569ConfigLayoutCorpoPromissoriaPaciente[0];
         pr_default.close(5);
         if ( (0==A922ConfigLayoutContratoCompraTitulo) )
         {
            A922ConfigLayoutContratoCompraTitulo = 0;
            n922ConfigLayoutContratoCompraTitulo = false;
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            n922ConfigLayoutContratoCompraTitulo = true;
            n922ConfigLayoutContratoCompraTitulo = true;
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
         }
         /* Using cursor T00198 */
         pr_default.execute(6, new Object[] {n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A922ConfigLayoutContratoCompraTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Config Layout Contrato Compra Titulo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTCONTRATOCOMPRATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutContratoCompraTitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T00199 */
         pr_default.execute(7, new Object[] {n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A654ConfiguracoesCategoriaTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Categoria Titulo Confg'.", "ForeignKeyNotFound", 1, "CONFIGURACOESCATEGORIATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCategoriaTitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors1948( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( short A398ConfiguracoesLayoutProposta )
      {
         /* Using cursor T001911 */
         pr_default.execute(9, new Object[] {n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A398ConfiguracoesLayoutProposta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Proposta Config'.", "ForeignKeyNotFound", 1, "CONFIGURACOESLAYOUTPROPOSTA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesLayoutProposta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A418ConfiguracoesLayoutContratoCorpo = T001911_A418ConfiguracoesLayoutContratoCorpo[0];
         n418ConfiguracoesLayoutContratoCorpo = T001911_n418ConfiguracoesLayoutContratoCorpo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A418ConfiguracoesLayoutContratoCorpo)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_5( short A564ConfigLayoutPromissoriaClinicaEmprestimo )
      {
         /* Using cursor T001912 */
         pr_default.execute(10, new Object[] {n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A564ConfigLayoutPromissoriaClinicaEmprestimo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Emprestimo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001912_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001912_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_6( short A565ConfigLayoutPromissoriaClinicaTaxa )
      {
         /* Using cursor T001913 */
         pr_default.execute(11, new Object[] {n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A565ConfigLayoutPromissoriaClinicaTaxa) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Taxa'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICATAXA");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaTaxa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001913_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001913_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A568ConfigLayoutCorpoPromissoriaClinicaTaxa)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_7( short A566ConfigLayoutPromissoriaPaciente )
      {
         /* Using cursor T001914 */
         pr_default.execute(12, new Object[] {n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A566ConfigLayoutPromissoriaPaciente) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Paciente'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIAPACIENTE");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaPaciente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A569ConfigLayoutCorpoPromissoriaPaciente = T001914_A569ConfigLayoutCorpoPromissoriaPaciente[0];
         n569ConfigLayoutCorpoPromissoriaPaciente = T001914_n569ConfigLayoutCorpoPromissoriaPaciente[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A569ConfigLayoutCorpoPromissoriaPaciente)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_8( short A922ConfigLayoutContratoCompraTitulo )
      {
         /* Using cursor T001915 */
         pr_default.execute(13, new Object[] {n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A922ConfigLayoutContratoCompraTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Config Layout Contrato Compra Titulo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTCONTRATOCOMPRATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutContratoCompraTitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_9( int A654ConfiguracoesCategoriaTitulo )
      {
         /* Using cursor T001916 */
         pr_default.execute(14, new Object[] {n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A654ConfiguracoesCategoriaTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Categoria Titulo Confg'.", "ForeignKeyNotFound", 1, "CONFIGURACOESCATEGORIATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCategoriaTitulo_Internalname;
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

      protected void GetKey1948( )
      {
         /* Using cursor T001917 */
         pr_default.execute(15, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00193 */
         pr_default.execute(1, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1948( 3) ;
            RcdFound48 = 1;
            A299ConfiguracoesId = T00193_A299ConfiguracoesId[0];
            AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
            A315ConfiguracoesImagemLoginNomeInteiro = T00193_A315ConfiguracoesImagemLoginNomeInteiro[0];
            n315ConfiguracoesImagemLoginNomeInteiro = T00193_n315ConfiguracoesImagemLoginNomeInteiro[0];
            AssignAttri("", false, "A315ConfiguracoesImagemLoginNomeInteiro", A315ConfiguracoesImagemLoginNomeInteiro);
            A316ConfiguracoesImagemLoginTamanho = T00193_A316ConfiguracoesImagemLoginTamanho[0];
            n316ConfiguracoesImagemLoginTamanho = T00193_n316ConfiguracoesImagemLoginTamanho[0];
            AssignAttri("", false, "A316ConfiguracoesImagemLoginTamanho", ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho)&&IsIns( )||n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ".", ""))));
            A317ConfiguracoesImagemLoginBackground = T00193_A317ConfiguracoesImagemLoginBackground[0];
            n317ConfiguracoesImagemLoginBackground = T00193_n317ConfiguracoesImagemLoginBackground[0];
            AssignAttri("", false, "A317ConfiguracoesImagemLoginBackground", A317ConfiguracoesImagemLoginBackground);
            A319ConfiguracoesImagemHeaderNome = T00193_A319ConfiguracoesImagemHeaderNome[0];
            n319ConfiguracoesImagemHeaderNome = T00193_n319ConfiguracoesImagemHeaderNome[0];
            AssignAttri("", false, "A319ConfiguracoesImagemHeaderNome", A319ConfiguracoesImagemHeaderNome);
            A320ConfiguracoesImagemHeaderExtencao = T00193_A320ConfiguracoesImagemHeaderExtencao[0];
            n320ConfiguracoesImagemHeaderExtencao = T00193_n320ConfiguracoesImagemHeaderExtencao[0];
            AssignAttri("", false, "A320ConfiguracoesImagemHeaderExtencao", A320ConfiguracoesImagemHeaderExtencao);
            A321ConfiguracoesImagemHeaderNomeInteiro = T00193_A321ConfiguracoesImagemHeaderNomeInteiro[0];
            n321ConfiguracoesImagemHeaderNomeInteiro = T00193_n321ConfiguracoesImagemHeaderNomeInteiro[0];
            AssignAttri("", false, "A321ConfiguracoesImagemHeaderNomeInteiro", A321ConfiguracoesImagemHeaderNomeInteiro);
            A322ConfiguracoesImagemHeaderTamanho = T00193_A322ConfiguracoesImagemHeaderTamanho[0];
            n322ConfiguracoesImagemHeaderTamanho = T00193_n322ConfiguracoesImagemHeaderTamanho[0];
            AssignAttri("", false, "A322ConfiguracoesImagemHeaderTamanho", ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho)&&IsIns( )||n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", ""))));
            A563ConfiguracaoSenhaPFX = T00193_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = T00193_n563ConfiguracaoSenhaPFX[0];
            AssignAttri("", false, "A563ConfiguracaoSenhaPFX", A563ConfiguracaoSenhaPFX);
            A765ConfiguracoesSerasaAnotacoesCompletas = T00193_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = T00193_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
            A766ConfiguracoesSerasaConsultaDetalhada = T00193_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = T00193_n766ConfiguracoesSerasaConsultaDetalhada[0];
            AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
            A767ConfiguracoesSerasaParticipacaoSocietaria = T00193_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = T00193_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
            A768ConfiguracoesSerasaRendaEstimada = T00193_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = T00193_n768ConfiguracoesSerasaRendaEstimada[0];
            AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
            A769ConfiguracoesSerasaHistoricoPagamento = T00193_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = T00193_n769ConfiguracoesSerasaHistoricoPagamento[0];
            AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
            A1013ConfiguracoesCompraTituloTaxaEfetiva = T00193_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            n1013ConfiguracoesCompraTituloTaxaEfetiva = T00193_n1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            AssignAttri("", false, "A1013ConfiguracoesCompraTituloTaxaEfetiva", ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva)&&IsIns( )||n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", ""))));
            A1014ConfiguracoesCompraTituloTaxaMora = T00193_A1014ConfiguracoesCompraTituloTaxaMora[0];
            n1014ConfiguracoesCompraTituloTaxaMora = T00193_n1014ConfiguracoesCompraTituloTaxaMora[0];
            AssignAttri("", false, "A1014ConfiguracoesCompraTituloTaxaMora", ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora)&&IsIns( )||n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", ""))));
            A1036ConfiguracoesCompraTituloFator = T00193_A1036ConfiguracoesCompraTituloFator[0];
            n1036ConfiguracoesCompraTituloFator = T00193_n1036ConfiguracoesCompraTituloFator[0];
            AssignAttri("", false, "A1036ConfiguracoesCompraTituloFator", ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator)&&IsIns( )||n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 16, 4, ".", ""))));
            A1037ConfiguracoesCompraTituloTarifaTipo = T00193_A1037ConfiguracoesCompraTituloTarifaTipo[0];
            n1037ConfiguracoesCompraTituloTarifaTipo = T00193_n1037ConfiguracoesCompraTituloTarifaTipo[0];
            AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
            A1038ConfiguracoesCompraTituloTarifa = T00193_A1038ConfiguracoesCompraTituloTarifa[0];
            n1038ConfiguracoesCompraTituloTarifa = T00193_n1038ConfiguracoesCompraTituloTarifa[0];
            AssignAttri("", false, "A1038ConfiguracoesCompraTituloTarifa", ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa)&&IsIns( )||n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", ""))));
            A312ConfiguracoesImagemLoginExtencao = T00193_A312ConfiguracoesImagemLoginExtencao[0];
            n312ConfiguracoesImagemLoginExtencao = T00193_n312ConfiguracoesImagemLoginExtencao[0];
            edtConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
            AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Filetype", edtConfiguracoesImagemLogin_Filetype, true);
            A313ConfiguracoesImagemLoginNome = T00193_A313ConfiguracoesImagemLoginNome[0];
            n313ConfiguracoesImagemLoginNome = T00193_n313ConfiguracoesImagemLoginNome[0];
            edtConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
            A398ConfiguracoesLayoutProposta = T00193_A398ConfiguracoesLayoutProposta[0];
            n398ConfiguracoesLayoutProposta = T00193_n398ConfiguracoesLayoutProposta[0];
            AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
            A564ConfigLayoutPromissoriaClinicaEmprestimo = T00193_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            n564ConfigLayoutPromissoriaClinicaEmprestimo = T00193_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
            A565ConfigLayoutPromissoriaClinicaTaxa = T00193_A565ConfigLayoutPromissoriaClinicaTaxa[0];
            n565ConfigLayoutPromissoriaClinicaTaxa = T00193_n565ConfigLayoutPromissoriaClinicaTaxa[0];
            AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
            A566ConfigLayoutPromissoriaPaciente = T00193_A566ConfigLayoutPromissoriaPaciente[0];
            n566ConfigLayoutPromissoriaPaciente = T00193_n566ConfigLayoutPromissoriaPaciente[0];
            AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
            A922ConfigLayoutContratoCompraTitulo = T00193_A922ConfigLayoutContratoCompraTitulo[0];
            n922ConfigLayoutContratoCompraTitulo = T00193_n922ConfigLayoutContratoCompraTitulo[0];
            AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
            A654ConfiguracoesCategoriaTitulo = T00193_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = T00193_n654ConfiguracoesCategoriaTitulo[0];
            AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
            A300ConfiguracoesImagemLogin = T00193_A300ConfiguracoesImagemLogin[0];
            n300ConfiguracoesImagemLogin = T00193_n300ConfiguracoesImagemLogin[0];
            AssignAttri("", false, "A300ConfiguracoesImagemLogin", A300ConfiguracoesImagemLogin);
            AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "URL", context.PathToRelativeUrl( A300ConfiguracoesImagemLogin), true);
            A318ConfiguracoesImagemHeader = T00193_A318ConfiguracoesImagemHeader[0];
            n318ConfiguracoesImagemHeader = T00193_n318ConfiguracoesImagemHeader[0];
            AssignAttri("", false, "A318ConfiguracoesImagemHeader", A318ConfiguracoesImagemHeader);
            AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "URL", context.PathToRelativeUrl( A318ConfiguracoesImagemHeader), true);
            A562ConfiguracoesArquivoPFX = T00193_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = T00193_n562ConfiguracoesArquivoPFX[0];
            AssignAttri("", false, "A562ConfiguracoesArquivoPFX", A562ConfiguracoesArquivoPFX);
            AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "URL", context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX), true);
            Z299ConfiguracoesId = A299ConfiguracoesId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1948( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey1948( ) ;
            }
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey1948( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1948( ) ;
         if ( RcdFound48 == 0 )
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
         RcdFound48 = 0;
         /* Using cursor T001918 */
         pr_default.execute(16, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T001918_A299ConfiguracoesId[0] < A299ConfiguracoesId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T001918_A299ConfiguracoesId[0] > A299ConfiguracoesId ) ) )
            {
               A299ConfiguracoesId = T001918_A299ConfiguracoesId[0];
               AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
               RcdFound48 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound48 = 0;
         /* Using cursor T001919 */
         pr_default.execute(17, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T001919_A299ConfiguracoesId[0] > A299ConfiguracoesId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T001919_A299ConfiguracoesId[0] < A299ConfiguracoesId ) ) )
            {
               A299ConfiguracoesId = T001919_A299ConfiguracoesId[0];
               AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
               RcdFound48 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1948( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConfiguracoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1948( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( A299ConfiguracoesId != Z299ConfiguracoesId )
               {
                  A299ConfiguracoesId = Z299ConfiguracoesId;
                  AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONFIGURACOESID");
                  AnyError = 1;
                  GX_FocusControl = edtConfiguracoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConfiguracoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1948( ) ;
                  GX_FocusControl = edtConfiguracoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A299ConfiguracoesId != Z299ConfiguracoesId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtConfiguracoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1948( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONFIGURACOESID");
                     AnyError = 1;
                     GX_FocusControl = edtConfiguracoesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtConfiguracoesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1948( ) ;
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
         if ( A299ConfiguracoesId != Z299ConfiguracoesId )
         {
            A299ConfiguracoesId = Z299ConfiguracoesId;
            AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONFIGURACOESID");
            AnyError = 1;
            GX_FocusControl = edtConfiguracoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConfiguracoesId_Internalname;
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
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CONFIGURACOESID");
            AnyError = 1;
            GX_FocusControl = edtConfiguracoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtConfiguracoesImagemLogin_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1948( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfiguracoesImagemLogin_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1948( ) ;
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
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfiguracoesImagemLogin_Internalname;
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
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfiguracoesImagemLogin_Internalname;
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
         ScanStart1948( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound48 != 0 )
            {
               ScanNext1948( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConfiguracoesImagemLogin_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1948( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1948( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00192 */
            pr_default.execute(0, new Object[] {A299ConfiguracoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Configuracoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z315ConfiguracoesImagemLoginNomeInteiro, T00192_A315ConfiguracoesImagemLoginNomeInteiro[0]) != 0 ) || ( Z316ConfiguracoesImagemLoginTamanho != T00192_A316ConfiguracoesImagemLoginTamanho[0] ) || ( StringUtil.StrCmp(Z317ConfiguracoesImagemLoginBackground, T00192_A317ConfiguracoesImagemLoginBackground[0]) != 0 ) || ( StringUtil.StrCmp(Z319ConfiguracoesImagemHeaderNome, T00192_A319ConfiguracoesImagemHeaderNome[0]) != 0 ) || ( StringUtil.StrCmp(Z320ConfiguracoesImagemHeaderExtencao, T00192_A320ConfiguracoesImagemHeaderExtencao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z321ConfiguracoesImagemHeaderNomeInteiro, T00192_A321ConfiguracoesImagemHeaderNomeInteiro[0]) != 0 ) || ( Z322ConfiguracoesImagemHeaderTamanho != T00192_A322ConfiguracoesImagemHeaderTamanho[0] ) || ( StringUtil.StrCmp(Z563ConfiguracaoSenhaPFX, T00192_A563ConfiguracaoSenhaPFX[0]) != 0 ) || ( Z765ConfiguracoesSerasaAnotacoesCompletas != T00192_A765ConfiguracoesSerasaAnotacoesCompletas[0] ) || ( Z766ConfiguracoesSerasaConsultaDetalhada != T00192_A766ConfiguracoesSerasaConsultaDetalhada[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z767ConfiguracoesSerasaParticipacaoSocietaria != T00192_A767ConfiguracoesSerasaParticipacaoSocietaria[0] ) || ( Z768ConfiguracoesSerasaRendaEstimada != T00192_A768ConfiguracoesSerasaRendaEstimada[0] ) || ( Z769ConfiguracoesSerasaHistoricoPagamento != T00192_A769ConfiguracoesSerasaHistoricoPagamento[0] ) || ( Z1013ConfiguracoesCompraTituloTaxaEfetiva != T00192_A1013ConfiguracoesCompraTituloTaxaEfetiva[0] ) || ( Z1014ConfiguracoesCompraTituloTaxaMora != T00192_A1014ConfiguracoesCompraTituloTaxaMora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1036ConfiguracoesCompraTituloFator != T00192_A1036ConfiguracoesCompraTituloFator[0] ) || ( StringUtil.StrCmp(Z1037ConfiguracoesCompraTituloTarifaTipo, T00192_A1037ConfiguracoesCompraTituloTarifaTipo[0]) != 0 ) || ( Z1038ConfiguracoesCompraTituloTarifa != T00192_A1038ConfiguracoesCompraTituloTarifa[0] ) || ( Z398ConfiguracoesLayoutProposta != T00192_A398ConfiguracoesLayoutProposta[0] ) || ( Z564ConfigLayoutPromissoriaClinicaEmprestimo != T00192_A564ConfigLayoutPromissoriaClinicaEmprestimo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z565ConfigLayoutPromissoriaClinicaTaxa != T00192_A565ConfigLayoutPromissoriaClinicaTaxa[0] ) || ( Z566ConfigLayoutPromissoriaPaciente != T00192_A566ConfigLayoutPromissoriaPaciente[0] ) || ( Z922ConfigLayoutContratoCompraTitulo != T00192_A922ConfigLayoutContratoCompraTitulo[0] ) || ( Z654ConfiguracoesCategoriaTitulo != T00192_A654ConfiguracoesCategoriaTitulo[0] ) )
            {
               if ( StringUtil.StrCmp(Z315ConfiguracoesImagemLoginNomeInteiro, T00192_A315ConfiguracoesImagemLoginNomeInteiro[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemLoginNomeInteiro");
                  GXUtil.WriteLogRaw("Old: ",Z315ConfiguracoesImagemLoginNomeInteiro);
                  GXUtil.WriteLogRaw("Current: ",T00192_A315ConfiguracoesImagemLoginNomeInteiro[0]);
               }
               if ( Z316ConfiguracoesImagemLoginTamanho != T00192_A316ConfiguracoesImagemLoginTamanho[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemLoginTamanho");
                  GXUtil.WriteLogRaw("Old: ",Z316ConfiguracoesImagemLoginTamanho);
                  GXUtil.WriteLogRaw("Current: ",T00192_A316ConfiguracoesImagemLoginTamanho[0]);
               }
               if ( StringUtil.StrCmp(Z317ConfiguracoesImagemLoginBackground, T00192_A317ConfiguracoesImagemLoginBackground[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemLoginBackground");
                  GXUtil.WriteLogRaw("Old: ",Z317ConfiguracoesImagemLoginBackground);
                  GXUtil.WriteLogRaw("Current: ",T00192_A317ConfiguracoesImagemLoginBackground[0]);
               }
               if ( StringUtil.StrCmp(Z319ConfiguracoesImagemHeaderNome, T00192_A319ConfiguracoesImagemHeaderNome[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemHeaderNome");
                  GXUtil.WriteLogRaw("Old: ",Z319ConfiguracoesImagemHeaderNome);
                  GXUtil.WriteLogRaw("Current: ",T00192_A319ConfiguracoesImagemHeaderNome[0]);
               }
               if ( StringUtil.StrCmp(Z320ConfiguracoesImagemHeaderExtencao, T00192_A320ConfiguracoesImagemHeaderExtencao[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemHeaderExtencao");
                  GXUtil.WriteLogRaw("Old: ",Z320ConfiguracoesImagemHeaderExtencao);
                  GXUtil.WriteLogRaw("Current: ",T00192_A320ConfiguracoesImagemHeaderExtencao[0]);
               }
               if ( StringUtil.StrCmp(Z321ConfiguracoesImagemHeaderNomeInteiro, T00192_A321ConfiguracoesImagemHeaderNomeInteiro[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemHeaderNomeInteiro");
                  GXUtil.WriteLogRaw("Old: ",Z321ConfiguracoesImagemHeaderNomeInteiro);
                  GXUtil.WriteLogRaw("Current: ",T00192_A321ConfiguracoesImagemHeaderNomeInteiro[0]);
               }
               if ( Z322ConfiguracoesImagemHeaderTamanho != T00192_A322ConfiguracoesImagemHeaderTamanho[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesImagemHeaderTamanho");
                  GXUtil.WriteLogRaw("Old: ",Z322ConfiguracoesImagemHeaderTamanho);
                  GXUtil.WriteLogRaw("Current: ",T00192_A322ConfiguracoesImagemHeaderTamanho[0]);
               }
               if ( StringUtil.StrCmp(Z563ConfiguracaoSenhaPFX, T00192_A563ConfiguracaoSenhaPFX[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracaoSenhaPFX");
                  GXUtil.WriteLogRaw("Old: ",Z563ConfiguracaoSenhaPFX);
                  GXUtil.WriteLogRaw("Current: ",T00192_A563ConfiguracaoSenhaPFX[0]);
               }
               if ( Z765ConfiguracoesSerasaAnotacoesCompletas != T00192_A765ConfiguracoesSerasaAnotacoesCompletas[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesSerasaAnotacoesCompletas");
                  GXUtil.WriteLogRaw("Old: ",Z765ConfiguracoesSerasaAnotacoesCompletas);
                  GXUtil.WriteLogRaw("Current: ",T00192_A765ConfiguracoesSerasaAnotacoesCompletas[0]);
               }
               if ( Z766ConfiguracoesSerasaConsultaDetalhada != T00192_A766ConfiguracoesSerasaConsultaDetalhada[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesSerasaConsultaDetalhada");
                  GXUtil.WriteLogRaw("Old: ",Z766ConfiguracoesSerasaConsultaDetalhada);
                  GXUtil.WriteLogRaw("Current: ",T00192_A766ConfiguracoesSerasaConsultaDetalhada[0]);
               }
               if ( Z767ConfiguracoesSerasaParticipacaoSocietaria != T00192_A767ConfiguracoesSerasaParticipacaoSocietaria[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesSerasaParticipacaoSocietaria");
                  GXUtil.WriteLogRaw("Old: ",Z767ConfiguracoesSerasaParticipacaoSocietaria);
                  GXUtil.WriteLogRaw("Current: ",T00192_A767ConfiguracoesSerasaParticipacaoSocietaria[0]);
               }
               if ( Z768ConfiguracoesSerasaRendaEstimada != T00192_A768ConfiguracoesSerasaRendaEstimada[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesSerasaRendaEstimada");
                  GXUtil.WriteLogRaw("Old: ",Z768ConfiguracoesSerasaRendaEstimada);
                  GXUtil.WriteLogRaw("Current: ",T00192_A768ConfiguracoesSerasaRendaEstimada[0]);
               }
               if ( Z769ConfiguracoesSerasaHistoricoPagamento != T00192_A769ConfiguracoesSerasaHistoricoPagamento[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesSerasaHistoricoPagamento");
                  GXUtil.WriteLogRaw("Old: ",Z769ConfiguracoesSerasaHistoricoPagamento);
                  GXUtil.WriteLogRaw("Current: ",T00192_A769ConfiguracoesSerasaHistoricoPagamento[0]);
               }
               if ( Z1013ConfiguracoesCompraTituloTaxaEfetiva != T00192_A1013ConfiguracoesCompraTituloTaxaEfetiva[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesCompraTituloTaxaEfetiva");
                  GXUtil.WriteLogRaw("Old: ",Z1013ConfiguracoesCompraTituloTaxaEfetiva);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1013ConfiguracoesCompraTituloTaxaEfetiva[0]);
               }
               if ( Z1014ConfiguracoesCompraTituloTaxaMora != T00192_A1014ConfiguracoesCompraTituloTaxaMora[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesCompraTituloTaxaMora");
                  GXUtil.WriteLogRaw("Old: ",Z1014ConfiguracoesCompraTituloTaxaMora);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1014ConfiguracoesCompraTituloTaxaMora[0]);
               }
               if ( Z1036ConfiguracoesCompraTituloFator != T00192_A1036ConfiguracoesCompraTituloFator[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesCompraTituloFator");
                  GXUtil.WriteLogRaw("Old: ",Z1036ConfiguracoesCompraTituloFator);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1036ConfiguracoesCompraTituloFator[0]);
               }
               if ( StringUtil.StrCmp(Z1037ConfiguracoesCompraTituloTarifaTipo, T00192_A1037ConfiguracoesCompraTituloTarifaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesCompraTituloTarifaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1037ConfiguracoesCompraTituloTarifaTipo);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1037ConfiguracoesCompraTituloTarifaTipo[0]);
               }
               if ( Z1038ConfiguracoesCompraTituloTarifa != T00192_A1038ConfiguracoesCompraTituloTarifa[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesCompraTituloTarifa");
                  GXUtil.WriteLogRaw("Old: ",Z1038ConfiguracoesCompraTituloTarifa);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1038ConfiguracoesCompraTituloTarifa[0]);
               }
               if ( Z398ConfiguracoesLayoutProposta != T00192_A398ConfiguracoesLayoutProposta[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesLayoutProposta");
                  GXUtil.WriteLogRaw("Old: ",Z398ConfiguracoesLayoutProposta);
                  GXUtil.WriteLogRaw("Current: ",T00192_A398ConfiguracoesLayoutProposta[0]);
               }
               if ( Z564ConfigLayoutPromissoriaClinicaEmprestimo != T00192_A564ConfigLayoutPromissoriaClinicaEmprestimo[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfigLayoutPromissoriaClinicaEmprestimo");
                  GXUtil.WriteLogRaw("Old: ",Z564ConfigLayoutPromissoriaClinicaEmprestimo);
                  GXUtil.WriteLogRaw("Current: ",T00192_A564ConfigLayoutPromissoriaClinicaEmprestimo[0]);
               }
               if ( Z565ConfigLayoutPromissoriaClinicaTaxa != T00192_A565ConfigLayoutPromissoriaClinicaTaxa[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfigLayoutPromissoriaClinicaTaxa");
                  GXUtil.WriteLogRaw("Old: ",Z565ConfigLayoutPromissoriaClinicaTaxa);
                  GXUtil.WriteLogRaw("Current: ",T00192_A565ConfigLayoutPromissoriaClinicaTaxa[0]);
               }
               if ( Z566ConfigLayoutPromissoriaPaciente != T00192_A566ConfigLayoutPromissoriaPaciente[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfigLayoutPromissoriaPaciente");
                  GXUtil.WriteLogRaw("Old: ",Z566ConfigLayoutPromissoriaPaciente);
                  GXUtil.WriteLogRaw("Current: ",T00192_A566ConfigLayoutPromissoriaPaciente[0]);
               }
               if ( Z922ConfigLayoutContratoCompraTitulo != T00192_A922ConfigLayoutContratoCompraTitulo[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfigLayoutContratoCompraTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z922ConfigLayoutContratoCompraTitulo);
                  GXUtil.WriteLogRaw("Current: ",T00192_A922ConfigLayoutContratoCompraTitulo[0]);
               }
               if ( Z654ConfiguracoesCategoriaTitulo != T00192_A654ConfiguracoesCategoriaTitulo[0] )
               {
                  GXUtil.WriteLog("configuracoes:[seudo value changed for attri]"+"ConfiguracoesCategoriaTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z654ConfiguracoesCategoriaTitulo);
                  GXUtil.WriteLogRaw("Current: ",T00192_A654ConfiguracoesCategoriaTitulo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Configuracoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1948( )
      {
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1948( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1948( 0) ;
            CheckOptimisticConcurrency1948( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1948( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1948( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001920 */
                     A312ConfiguracoesImagemLoginExtencao = edtConfiguracoesImagemLogin_Filetype;
                     n312ConfiguracoesImagemLoginExtencao = false;
                     AssignAttri("", false, "A312ConfiguracoesImagemLoginExtencao", A312ConfiguracoesImagemLoginExtencao);
                     A313ConfiguracoesImagemLoginNome = edtConfiguracoesImagemLogin_Filename;
                     n313ConfiguracoesImagemLoginNome = false;
                     AssignAttri("", false, "A313ConfiguracoesImagemLoginNome", A313ConfiguracoesImagemLoginNome);
                     pr_default.execute(18, new Object[] {n300ConfiguracoesImagemLogin, A300ConfiguracoesImagemLogin, n315ConfiguracoesImagemLoginNomeInteiro, A315ConfiguracoesImagemLoginNomeInteiro, n316ConfiguracoesImagemLoginTamanho, A316ConfiguracoesImagemLoginTamanho, n317ConfiguracoesImagemLoginBackground, A317ConfiguracoesImagemLoginBackground, n318ConfiguracoesImagemHeader, A318ConfiguracoesImagemHeader, n319ConfiguracoesImagemHeaderNome, A319ConfiguracoesImagemHeaderNome, n320ConfiguracoesImagemHeaderExtencao, A320ConfiguracoesImagemHeaderExtencao, n321ConfiguracoesImagemHeaderNomeInteiro, A321ConfiguracoesImagemHeaderNomeInteiro, n322ConfiguracoesImagemHeaderTamanho, A322ConfiguracoesImagemHeaderTamanho, n562ConfiguracoesArquivoPFX, A562ConfiguracoesArquivoPFX, n563ConfiguracaoSenhaPFX, A563ConfiguracaoSenhaPFX, n765ConfiguracoesSerasaAnotacoesCompletas, A765ConfiguracoesSerasaAnotacoesCompletas, n766ConfiguracoesSerasaConsultaDetalhada, A766ConfiguracoesSerasaConsultaDetalhada, n767ConfiguracoesSerasaParticipacaoSocietaria, A767ConfiguracoesSerasaParticipacaoSocietaria, n768ConfiguracoesSerasaRendaEstimada, A768ConfiguracoesSerasaRendaEstimada, n769ConfiguracoesSerasaHistoricoPagamento, A769ConfiguracoesSerasaHistoricoPagamento, n1013ConfiguracoesCompraTituloTaxaEfetiva, A1013ConfiguracoesCompraTituloTaxaEfetiva, n1014ConfiguracoesCompraTituloTaxaMora, A1014ConfiguracoesCompraTituloTaxaMora, n1036ConfiguracoesCompraTituloFator, A1036ConfiguracoesCompraTituloFator, n1037ConfiguracoesCompraTituloTarifaTipo, A1037ConfiguracoesCompraTituloTarifaTipo, n1038ConfiguracoesCompraTituloTarifa, A1038ConfiguracoesCompraTituloTarifa, n312ConfiguracoesImagemLoginExtencao, A312ConfiguracoesImagemLoginExtencao, n313ConfiguracoesImagemLoginNome, A313ConfiguracoesImagemLoginNome, n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta, n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo, n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa, n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente, n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo, n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001921 */
                     pr_default.execute(19);
                     A299ConfiguracoesId = T001921_A299ConfiguracoesId[0];
                     AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption190( ) ;
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
               Load1948( ) ;
            }
            EndLevel1948( ) ;
         }
         CloseExtendedTableCursors1948( ) ;
      }

      protected void Update1948( )
      {
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1948( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1948( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1948( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1948( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001922 */
                     A312ConfiguracoesImagemLoginExtencao = edtConfiguracoesImagemLogin_Filetype;
                     n312ConfiguracoesImagemLoginExtencao = false;
                     AssignAttri("", false, "A312ConfiguracoesImagemLoginExtencao", A312ConfiguracoesImagemLoginExtencao);
                     A313ConfiguracoesImagemLoginNome = edtConfiguracoesImagemLogin_Filename;
                     n313ConfiguracoesImagemLoginNome = false;
                     AssignAttri("", false, "A313ConfiguracoesImagemLoginNome", A313ConfiguracoesImagemLoginNome);
                     pr_default.execute(20, new Object[] {n315ConfiguracoesImagemLoginNomeInteiro, A315ConfiguracoesImagemLoginNomeInteiro, n316ConfiguracoesImagemLoginTamanho, A316ConfiguracoesImagemLoginTamanho, n317ConfiguracoesImagemLoginBackground, A317ConfiguracoesImagemLoginBackground, n319ConfiguracoesImagemHeaderNome, A319ConfiguracoesImagemHeaderNome, n320ConfiguracoesImagemHeaderExtencao, A320ConfiguracoesImagemHeaderExtencao, n321ConfiguracoesImagemHeaderNomeInteiro, A321ConfiguracoesImagemHeaderNomeInteiro, n322ConfiguracoesImagemHeaderTamanho, A322ConfiguracoesImagemHeaderTamanho, n563ConfiguracaoSenhaPFX, A563ConfiguracaoSenhaPFX, n765ConfiguracoesSerasaAnotacoesCompletas, A765ConfiguracoesSerasaAnotacoesCompletas, n766ConfiguracoesSerasaConsultaDetalhada, A766ConfiguracoesSerasaConsultaDetalhada, n767ConfiguracoesSerasaParticipacaoSocietaria, A767ConfiguracoesSerasaParticipacaoSocietaria, n768ConfiguracoesSerasaRendaEstimada, A768ConfiguracoesSerasaRendaEstimada, n769ConfiguracoesSerasaHistoricoPagamento, A769ConfiguracoesSerasaHistoricoPagamento, n1013ConfiguracoesCompraTituloTaxaEfetiva, A1013ConfiguracoesCompraTituloTaxaEfetiva, n1014ConfiguracoesCompraTituloTaxaMora, A1014ConfiguracoesCompraTituloTaxaMora, n1036ConfiguracoesCompraTituloFator, A1036ConfiguracoesCompraTituloFator, n1037ConfiguracoesCompraTituloTarifaTipo, A1037ConfiguracoesCompraTituloTarifaTipo, n1038ConfiguracoesCompraTituloTarifa, A1038ConfiguracoesCompraTituloTarifa, n312ConfiguracoesImagemLoginExtencao, A312ConfiguracoesImagemLoginExtencao, n313ConfiguracoesImagemLoginNome, A313ConfiguracoesImagemLoginNome, n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta, n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo, n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa, n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente, n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo, n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo, A299ConfiguracoesId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Configuracoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1948( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption190( ) ;
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
            EndLevel1948( ) ;
         }
         CloseExtendedTableCursors1948( ) ;
      }

      protected void DeferredUpdate1948( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001923 */
            pr_default.execute(21, new Object[] {n300ConfiguracoesImagemLogin, A300ConfiguracoesImagemLogin, A299ConfiguracoesId});
            pr_default.close(21);
            pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001924 */
            pr_default.execute(22, new Object[] {n318ConfiguracoesImagemHeader, A318ConfiguracoesImagemHeader, A299ConfiguracoesId});
            pr_default.close(22);
            pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001925 */
            pr_default.execute(23, new Object[] {n562ConfiguracoesArquivoPFX, A562ConfiguracoesArquivoPFX, A299ConfiguracoesId});
            pr_default.close(23);
            pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1948( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1948( ) ;
            AfterConfirm1948( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1948( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001926 */
                  pr_default.execute(24, new Object[] {A299ConfiguracoesId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound48 == 0 )
                        {
                           InitAll1948( ) ;
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
                        ResetCaption190( ) ;
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1948( ) ;
         Gx_mode = sMode48;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1948( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001927 */
            pr_default.execute(25, new Object[] {n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta});
            A418ConfiguracoesLayoutContratoCorpo = T001927_A418ConfiguracoesLayoutContratoCorpo[0];
            n418ConfiguracoesLayoutContratoCorpo = T001927_n418ConfiguracoesLayoutContratoCorpo[0];
            pr_default.close(25);
            /* Using cursor T001928 */
            pr_default.execute(26, new Object[] {n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo});
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001928_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001928_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            pr_default.close(26);
            /* Using cursor T001929 */
            pr_default.execute(27, new Object[] {n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa});
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001929_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001929_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            pr_default.close(27);
            /* Using cursor T001930 */
            pr_default.execute(28, new Object[] {n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente});
            A569ConfigLayoutCorpoPromissoriaPaciente = T001930_A569ConfigLayoutCorpoPromissoriaPaciente[0];
            n569ConfigLayoutCorpoPromissoriaPaciente = T001930_n569ConfigLayoutCorpoPromissoriaPaciente[0];
            pr_default.close(28);
         }
      }

      protected void EndLevel1948( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1948( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues190( ) ;
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

      public void ScanStart1948( )
      {
         /* Using cursor T001931 */
         pr_default.execute(29);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound48 = 1;
            A299ConfiguracoesId = T001931_A299ConfiguracoesId[0];
            AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1948( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound48 = 1;
            A299ConfiguracoesId = T001931_A299ConfiguracoesId[0];
            AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
         }
      }

      protected void ScanEnd1948( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm1948( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1948( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1948( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1948( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1948( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1948( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1948( )
      {
         edtConfiguracoesId_Enabled = 0;
         AssignProp("", false, edtConfiguracoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesId_Enabled), 5, 0), true);
         edtConfiguracoesImagemLogin_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemLogin_Enabled), 5, 0), true);
         edtConfiguracoesImagemLoginNomeInteiro_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemLoginNomeInteiro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemLoginNomeInteiro_Enabled), 5, 0), true);
         edtConfiguracoesImagemLoginTamanho_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemLoginTamanho_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemLoginTamanho_Enabled), 5, 0), true);
         edtConfiguracoesImagemLoginBackground_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemLoginBackground_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemLoginBackground_Enabled), 5, 0), true);
         edtConfiguracoesImagemHeader_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemHeader_Enabled), 5, 0), true);
         edtConfiguracoesImagemHeaderNome_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemHeaderNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemHeaderNome_Enabled), 5, 0), true);
         edtConfiguracoesImagemHeaderExtencao_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemHeaderExtencao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemHeaderExtencao_Enabled), 5, 0), true);
         edtConfiguracoesImagemHeaderNomeInteiro_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemHeaderNomeInteiro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemHeaderNomeInteiro_Enabled), 5, 0), true);
         edtConfiguracoesImagemHeaderTamanho_Enabled = 0;
         AssignProp("", false, edtConfiguracoesImagemHeaderTamanho_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesImagemHeaderTamanho_Enabled), 5, 0), true);
         edtConfiguracoesLayoutProposta_Enabled = 0;
         AssignProp("", false, edtConfiguracoesLayoutProposta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesLayoutProposta_Enabled), 5, 0), true);
         edtConfigLayoutPromissoriaClinicaEmprestimo_Enabled = 0;
         AssignProp("", false, edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigLayoutPromissoriaClinicaEmprestimo_Enabled), 5, 0), true);
         edtConfigLayoutPromissoriaClinicaTaxa_Enabled = 0;
         AssignProp("", false, edtConfigLayoutPromissoriaClinicaTaxa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigLayoutPromissoriaClinicaTaxa_Enabled), 5, 0), true);
         edtConfigLayoutPromissoriaPaciente_Enabled = 0;
         AssignProp("", false, edtConfigLayoutPromissoriaPaciente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigLayoutPromissoriaPaciente_Enabled), 5, 0), true);
         edtConfigLayoutContratoCompraTitulo_Enabled = 0;
         AssignProp("", false, edtConfigLayoutContratoCompraTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfigLayoutContratoCompraTitulo_Enabled), 5, 0), true);
         edtConfiguracoesArquivoPFX_Enabled = 0;
         AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesArquivoPFX_Enabled), 5, 0), true);
         edtConfiguracaoSenhaPFX_Enabled = 0;
         AssignProp("", false, edtConfiguracaoSenhaPFX_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracaoSenhaPFX_Enabled), 5, 0), true);
         edtConfiguracoesCategoriaTitulo_Enabled = 0;
         AssignProp("", false, edtConfiguracoesCategoriaTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesCategoriaTitulo_Enabled), 5, 0), true);
         cmbConfiguracoesSerasaAnotacoesCompletas.Enabled = 0;
         AssignProp("", false, cmbConfiguracoesSerasaAnotacoesCompletas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfiguracoesSerasaAnotacoesCompletas.Enabled), 5, 0), true);
         cmbConfiguracoesSerasaConsultaDetalhada.Enabled = 0;
         AssignProp("", false, cmbConfiguracoesSerasaConsultaDetalhada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfiguracoesSerasaConsultaDetalhada.Enabled), 5, 0), true);
         cmbConfiguracoesSerasaParticipacaoSocietaria.Enabled = 0;
         AssignProp("", false, cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfiguracoesSerasaParticipacaoSocietaria.Enabled), 5, 0), true);
         cmbConfiguracoesSerasaRendaEstimada.Enabled = 0;
         AssignProp("", false, cmbConfiguracoesSerasaRendaEstimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfiguracoesSerasaRendaEstimada.Enabled), 5, 0), true);
         cmbConfiguracoesSerasaHistoricoPagamento.Enabled = 0;
         AssignProp("", false, cmbConfiguracoesSerasaHistoricoPagamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfiguracoesSerasaHistoricoPagamento.Enabled), 5, 0), true);
         edtConfiguracoesCompraTituloTaxaEfetiva_Enabled = 0;
         AssignProp("", false, edtConfiguracoesCompraTituloTaxaEfetiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesCompraTituloTaxaEfetiva_Enabled), 5, 0), true);
         edtConfiguracoesCompraTituloTaxaMora_Enabled = 0;
         AssignProp("", false, edtConfiguracoesCompraTituloTaxaMora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesCompraTituloTaxaMora_Enabled), 5, 0), true);
         edtConfiguracoesCompraTituloFator_Enabled = 0;
         AssignProp("", false, edtConfiguracoesCompraTituloFator_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesCompraTituloFator_Enabled), 5, 0), true);
         cmbConfiguracoesCompraTituloTarifaTipo.Enabled = 0;
         AssignProp("", false, cmbConfiguracoesCompraTituloTarifaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConfiguracoesCompraTituloTarifaTipo.Enabled), 5, 0), true);
         edtConfiguracoesCompraTituloTarifa_Enabled = 0;
         AssignProp("", false, edtConfiguracoesCompraTituloTarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConfiguracoesCompraTituloTarifa_Enabled), 5, 0), true);
         Configuracoeslayoutcontratocorpo_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Configuracoeslayoutcontratocorpo_Internalname, "Enabled", StringUtil.BoolToStr( Configuracoeslayoutcontratocorpo_Enabled), true);
         Configlayoutcorpopromissoriaclinicaemprestimo_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Configlayoutcorpopromissoriaclinicaemprestimo_Internalname, "Enabled", StringUtil.BoolToStr( Configlayoutcorpopromissoriaclinicaemprestimo_Enabled), true);
         Configlayoutcorpopromissoriaclinicataxa_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Configlayoutcorpopromissoriaclinicataxa_Internalname, "Enabled", StringUtil.BoolToStr( Configlayoutcorpopromissoriaclinicataxa_Enabled), true);
         Configlayoutcorpopromissoriapaciente_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Configlayoutcorpopromissoriapaciente_Internalname, "Enabled", StringUtil.BoolToStr( Configlayoutcorpopromissoriapaciente_Enabled), true);
      }

      protected void send_integrity_lvl_hashes1948( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues190( )
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracoes") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z299ConfiguracoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299ConfiguracoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z315ConfiguracoesImagemLoginNomeInteiro", Z315ConfiguracoesImagemLoginNomeInteiro);
         GxWebStd.gx_hidden_field( context, "Z316ConfiguracoesImagemLoginTamanho", StringUtil.LTrim( StringUtil.NToC( Z316ConfiguracoesImagemLoginTamanho, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z317ConfiguracoesImagemLoginBackground", Z317ConfiguracoesImagemLoginBackground);
         GxWebStd.gx_hidden_field( context, "Z319ConfiguracoesImagemHeaderNome", Z319ConfiguracoesImagemHeaderNome);
         GxWebStd.gx_hidden_field( context, "Z320ConfiguracoesImagemHeaderExtencao", Z320ConfiguracoesImagemHeaderExtencao);
         GxWebStd.gx_hidden_field( context, "Z321ConfiguracoesImagemHeaderNomeInteiro", Z321ConfiguracoesImagemHeaderNomeInteiro);
         GxWebStd.gx_hidden_field( context, "Z322ConfiguracoesImagemHeaderTamanho", StringUtil.LTrim( StringUtil.NToC( Z322ConfiguracoesImagemHeaderTamanho, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z563ConfiguracaoSenhaPFX", Z563ConfiguracaoSenhaPFX);
         GxWebStd.gx_boolean_hidden_field( context, "Z765ConfiguracoesSerasaAnotacoesCompletas", Z765ConfiguracoesSerasaAnotacoesCompletas);
         GxWebStd.gx_boolean_hidden_field( context, "Z766ConfiguracoesSerasaConsultaDetalhada", Z766ConfiguracoesSerasaConsultaDetalhada);
         GxWebStd.gx_boolean_hidden_field( context, "Z767ConfiguracoesSerasaParticipacaoSocietaria", Z767ConfiguracoesSerasaParticipacaoSocietaria);
         GxWebStd.gx_boolean_hidden_field( context, "Z768ConfiguracoesSerasaRendaEstimada", Z768ConfiguracoesSerasaRendaEstimada);
         GxWebStd.gx_boolean_hidden_field( context, "Z769ConfiguracoesSerasaHistoricoPagamento", Z769ConfiguracoesSerasaHistoricoPagamento);
         GxWebStd.gx_hidden_field( context, "Z1013ConfiguracoesCompraTituloTaxaEfetiva", StringUtil.LTrim( StringUtil.NToC( Z1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1014ConfiguracoesCompraTituloTaxaMora", StringUtil.LTrim( StringUtil.NToC( Z1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1036ConfiguracoesCompraTituloFator", StringUtil.LTrim( StringUtil.NToC( Z1036ConfiguracoesCompraTituloFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1037ConfiguracoesCompraTituloTarifaTipo", Z1037ConfiguracoesCompraTituloTarifaTipo);
         GxWebStd.gx_hidden_field( context, "Z1038ConfiguracoesCompraTituloTarifa", StringUtil.LTrim( StringUtil.NToC( Z1038ConfiguracoesCompraTituloTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z398ConfiguracoesLayoutProposta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z398ConfiguracoesLayoutProposta), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z564ConfigLayoutPromissoriaClinicaEmprestimo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z565ConfigLayoutPromissoriaClinicaTaxa", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z566ConfigLayoutPromissoriaPaciente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z566ConfigLayoutPromissoriaPaciente), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z922ConfigLayoutContratoCompraTitulo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z922ConfigLayoutContratoCompraTitulo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z654ConfiguracoesCategoriaTitulo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z654ConfiguracoesCategoriaTitulo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMLOGINEXTENCAO", A312ConfiguracoesImagemLoginExtencao);
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMLOGINNOME", A313ConfiguracoesImagemLoginNome);
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESLAYOUTCONTRATOCORPO", A418ConfiguracoesLayoutContratoCorpo);
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO", A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo);
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA", A568ConfigLayoutCorpoPromissoriaClinicaTaxa);
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE", A569ConfigLayoutCorpoPromissoriaPaciente);
         GXCCtlgxBlob = "CONFIGURACOESIMAGEMLOGIN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A300ConfiguracoesImagemLogin);
         GXCCtlgxBlob = "CONFIGURACOESIMAGEMHEADER" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A318ConfiguracoesImagemHeader);
         GXCCtlgxBlob = "CONFIGURACOESARQUIVOPFX" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A562ConfiguracoesArquivoPFX);
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESLAYOUTCONTRATOCORPO_Objectcall", StringUtil.RTrim( Configuracoeslayoutcontratocorpo_Objectcall));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESLAYOUTCONTRATOCORPO_Enabled", StringUtil.BoolToStr( Configuracoeslayoutcontratocorpo_Enabled));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionclass", StringUtil.RTrim( Configuracoeslayoutcontratocorpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionstyle", StringUtil.RTrim( Configuracoeslayoutcontratocorpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESLAYOUTCONTRATOCORPO_Captionposition", StringUtil.RTrim( Configuracoeslayoutcontratocorpo_Captionposition));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Objectcall", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicaemprestimo_Objectcall));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Enabled", StringUtil.BoolToStr( Configlayoutcorpopromissoriaclinicaemprestimo_Enabled));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionclass", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicaemprestimo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionstyle", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicaemprestimo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO_Captionposition", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicaemprestimo_Captionposition));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Objectcall", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicataxa_Objectcall));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Enabled", StringUtil.BoolToStr( Configlayoutcorpopromissoriaclinicataxa_Enabled));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionclass", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicataxa_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionstyle", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicataxa_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA_Captionposition", StringUtil.RTrim( Configlayoutcorpopromissoriaclinicataxa_Captionposition));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Objectcall", StringUtil.RTrim( Configlayoutcorpopromissoriapaciente_Objectcall));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Enabled", StringUtil.BoolToStr( Configlayoutcorpopromissoriapaciente_Enabled));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionclass", StringUtil.RTrim( Configlayoutcorpopromissoriapaciente_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionstyle", StringUtil.RTrim( Configlayoutcorpopromissoriapaciente_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE_Captionposition", StringUtil.RTrim( Configlayoutcorpopromissoriapaciente_Captionposition));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMLOGIN_Filetype", StringUtil.RTrim( edtConfiguracoesImagemLogin_Filetype));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMLOGIN_Filename", StringUtil.RTrim( edtConfiguracoesImagemLogin_Filename));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMLOGIN_Filename", StringUtil.RTrim( edtConfiguracoesImagemLogin_Filename));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMHEADER_Filename", StringUtil.RTrim( edtConfiguracoesImagemHeader_Filename));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESARQUIVOPFX_Filename", StringUtil.RTrim( edtConfiguracoesArquivoPFX_Filename));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMLOGIN_Filetype", StringUtil.RTrim( edtConfiguracoesImagemLogin_Filetype));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESIMAGEMHEADER_Filetype", StringUtil.RTrim( edtConfiguracoesImagemHeader_Filetype));
         GxWebStd.gx_hidden_field( context, "CONFIGURACOESARQUIVOPFX_Filetype", StringUtil.RTrim( edtConfiguracoesArquivoPFX_Filetype));
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
         return formatLink("configuracoes")  ;
      }

      public override string GetPgmname( )
      {
         return "Configuracoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Configuracoes" ;
      }

      protected void InitializeNonKey1948( )
      {
         A300ConfiguracoesImagemLogin = "";
         n300ConfiguracoesImagemLogin = false;
         AssignAttri("", false, "A300ConfiguracoesImagemLogin", A300ConfiguracoesImagemLogin);
         AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "URL", context.PathToRelativeUrl( A300ConfiguracoesImagemLogin), true);
         n300ConfiguracoesImagemLogin = (String.IsNullOrEmpty(StringUtil.RTrim( A300ConfiguracoesImagemLogin)) ? true : false);
         A315ConfiguracoesImagemLoginNomeInteiro = "";
         n315ConfiguracoesImagemLoginNomeInteiro = false;
         AssignAttri("", false, "A315ConfiguracoesImagemLoginNomeInteiro", A315ConfiguracoesImagemLoginNomeInteiro);
         n315ConfiguracoesImagemLoginNomeInteiro = (String.IsNullOrEmpty(StringUtil.RTrim( A315ConfiguracoesImagemLoginNomeInteiro)) ? true : false);
         A316ConfiguracoesImagemLoginTamanho = 0;
         n316ConfiguracoesImagemLoginTamanho = false;
         AssignAttri("", false, "A316ConfiguracoesImagemLoginTamanho", ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho)&&IsIns( )||n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ".", ""))));
         n316ConfiguracoesImagemLoginTamanho = ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho) ? true : false);
         A317ConfiguracoesImagemLoginBackground = "";
         n317ConfiguracoesImagemLoginBackground = false;
         AssignAttri("", false, "A317ConfiguracoesImagemLoginBackground", A317ConfiguracoesImagemLoginBackground);
         n317ConfiguracoesImagemLoginBackground = (String.IsNullOrEmpty(StringUtil.RTrim( A317ConfiguracoesImagemLoginBackground)) ? true : false);
         A318ConfiguracoesImagemHeader = "";
         n318ConfiguracoesImagemHeader = false;
         AssignAttri("", false, "A318ConfiguracoesImagemHeader", A318ConfiguracoesImagemHeader);
         AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "URL", context.PathToRelativeUrl( A318ConfiguracoesImagemHeader), true);
         n318ConfiguracoesImagemHeader = (String.IsNullOrEmpty(StringUtil.RTrim( A318ConfiguracoesImagemHeader)) ? true : false);
         A319ConfiguracoesImagemHeaderNome = "";
         n319ConfiguracoesImagemHeaderNome = false;
         AssignAttri("", false, "A319ConfiguracoesImagemHeaderNome", A319ConfiguracoesImagemHeaderNome);
         n319ConfiguracoesImagemHeaderNome = (String.IsNullOrEmpty(StringUtil.RTrim( A319ConfiguracoesImagemHeaderNome)) ? true : false);
         A320ConfiguracoesImagemHeaderExtencao = "";
         n320ConfiguracoesImagemHeaderExtencao = false;
         AssignAttri("", false, "A320ConfiguracoesImagemHeaderExtencao", A320ConfiguracoesImagemHeaderExtencao);
         n320ConfiguracoesImagemHeaderExtencao = (String.IsNullOrEmpty(StringUtil.RTrim( A320ConfiguracoesImagemHeaderExtencao)) ? true : false);
         A321ConfiguracoesImagemHeaderNomeInteiro = "";
         n321ConfiguracoesImagemHeaderNomeInteiro = false;
         AssignAttri("", false, "A321ConfiguracoesImagemHeaderNomeInteiro", A321ConfiguracoesImagemHeaderNomeInteiro);
         n321ConfiguracoesImagemHeaderNomeInteiro = (String.IsNullOrEmpty(StringUtil.RTrim( A321ConfiguracoesImagemHeaderNomeInteiro)) ? true : false);
         A322ConfiguracoesImagemHeaderTamanho = 0;
         n322ConfiguracoesImagemHeaderTamanho = false;
         AssignAttri("", false, "A322ConfiguracoesImagemHeaderTamanho", ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho)&&IsIns( )||n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", ""))));
         n322ConfiguracoesImagemHeaderTamanho = ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho) ? true : false);
         A398ConfiguracoesLayoutProposta = 0;
         n398ConfiguracoesLayoutProposta = false;
         AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
         n398ConfiguracoesLayoutProposta = ((0==A398ConfiguracoesLayoutProposta) ? true : false);
         A418ConfiguracoesLayoutContratoCorpo = "";
         n418ConfiguracoesLayoutContratoCorpo = false;
         AssignAttri("", false, "A418ConfiguracoesLayoutContratoCorpo", A418ConfiguracoesLayoutContratoCorpo);
         A564ConfigLayoutPromissoriaClinicaEmprestimo = 0;
         n564ConfigLayoutPromissoriaClinicaEmprestimo = false;
         AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
         n564ConfigLayoutPromissoriaClinicaEmprestimo = ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo) ? true : false);
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = false;
         AssignAttri("", false, "A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo", A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo);
         A565ConfigLayoutPromissoriaClinicaTaxa = 0;
         n565ConfigLayoutPromissoriaClinicaTaxa = false;
         AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
         n565ConfigLayoutPromissoriaClinicaTaxa = ((0==A565ConfigLayoutPromissoriaClinicaTaxa) ? true : false);
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = false;
         AssignAttri("", false, "A568ConfigLayoutCorpoPromissoriaClinicaTaxa", A568ConfigLayoutCorpoPromissoriaClinicaTaxa);
         A566ConfigLayoutPromissoriaPaciente = 0;
         n566ConfigLayoutPromissoriaPaciente = false;
         AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
         n566ConfigLayoutPromissoriaPaciente = ((0==A566ConfigLayoutPromissoriaPaciente) ? true : false);
         A922ConfigLayoutContratoCompraTitulo = 0;
         n922ConfigLayoutContratoCompraTitulo = false;
         AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
         n922ConfigLayoutContratoCompraTitulo = ((0==A922ConfigLayoutContratoCompraTitulo) ? true : false);
         A569ConfigLayoutCorpoPromissoriaPaciente = "";
         n569ConfigLayoutCorpoPromissoriaPaciente = false;
         AssignAttri("", false, "A569ConfigLayoutCorpoPromissoriaPaciente", A569ConfigLayoutCorpoPromissoriaPaciente);
         A562ConfiguracoesArquivoPFX = "";
         n562ConfiguracoesArquivoPFX = false;
         AssignAttri("", false, "A562ConfiguracoesArquivoPFX", A562ConfiguracoesArquivoPFX);
         AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "URL", context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX), true);
         n562ConfiguracoesArquivoPFX = (String.IsNullOrEmpty(StringUtil.RTrim( A562ConfiguracoesArquivoPFX)) ? true : false);
         A563ConfiguracaoSenhaPFX = "";
         n563ConfiguracaoSenhaPFX = false;
         AssignAttri("", false, "A563ConfiguracaoSenhaPFX", A563ConfiguracaoSenhaPFX);
         n563ConfiguracaoSenhaPFX = (String.IsNullOrEmpty(StringUtil.RTrim( A563ConfiguracaoSenhaPFX)) ? true : false);
         A654ConfiguracoesCategoriaTitulo = 0;
         n654ConfiguracoesCategoriaTitulo = false;
         AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
         n654ConfiguracoesCategoriaTitulo = ((0==A654ConfiguracoesCategoriaTitulo) ? true : false);
         A765ConfiguracoesSerasaAnotacoesCompletas = false;
         n765ConfiguracoesSerasaAnotacoesCompletas = false;
         AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
         n765ConfiguracoesSerasaAnotacoesCompletas = ((false==A765ConfiguracoesSerasaAnotacoesCompletas) ? true : false);
         A766ConfiguracoesSerasaConsultaDetalhada = false;
         n766ConfiguracoesSerasaConsultaDetalhada = false;
         AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
         n766ConfiguracoesSerasaConsultaDetalhada = ((false==A766ConfiguracoesSerasaConsultaDetalhada) ? true : false);
         A767ConfiguracoesSerasaParticipacaoSocietaria = false;
         n767ConfiguracoesSerasaParticipacaoSocietaria = false;
         AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
         n767ConfiguracoesSerasaParticipacaoSocietaria = ((false==A767ConfiguracoesSerasaParticipacaoSocietaria) ? true : false);
         A768ConfiguracoesSerasaRendaEstimada = false;
         n768ConfiguracoesSerasaRendaEstimada = false;
         AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
         n768ConfiguracoesSerasaRendaEstimada = ((false==A768ConfiguracoesSerasaRendaEstimada) ? true : false);
         A769ConfiguracoesSerasaHistoricoPagamento = false;
         n769ConfiguracoesSerasaHistoricoPagamento = false;
         AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
         n769ConfiguracoesSerasaHistoricoPagamento = ((false==A769ConfiguracoesSerasaHistoricoPagamento) ? true : false);
         A1013ConfiguracoesCompraTituloTaxaEfetiva = 0;
         n1013ConfiguracoesCompraTituloTaxaEfetiva = false;
         AssignAttri("", false, "A1013ConfiguracoesCompraTituloTaxaEfetiva", ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva)&&IsIns( )||n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", ""))));
         n1013ConfiguracoesCompraTituloTaxaEfetiva = ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva) ? true : false);
         A1014ConfiguracoesCompraTituloTaxaMora = 0;
         n1014ConfiguracoesCompraTituloTaxaMora = false;
         AssignAttri("", false, "A1014ConfiguracoesCompraTituloTaxaMora", ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora)&&IsIns( )||n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", ""))));
         n1014ConfiguracoesCompraTituloTaxaMora = ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora) ? true : false);
         A1036ConfiguracoesCompraTituloFator = 0;
         n1036ConfiguracoesCompraTituloFator = false;
         AssignAttri("", false, "A1036ConfiguracoesCompraTituloFator", ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator)&&IsIns( )||n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 16, 4, ".", ""))));
         n1036ConfiguracoesCompraTituloFator = ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator) ? true : false);
         A1037ConfiguracoesCompraTituloTarifaTipo = "";
         n1037ConfiguracoesCompraTituloTarifaTipo = false;
         AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
         n1037ConfiguracoesCompraTituloTarifaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo)) ? true : false);
         A1038ConfiguracoesCompraTituloTarifa = 0;
         n1038ConfiguracoesCompraTituloTarifa = false;
         AssignAttri("", false, "A1038ConfiguracoesCompraTituloTarifa", ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa)&&IsIns( )||n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", ""))));
         n1038ConfiguracoesCompraTituloTarifa = ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa) ? true : false);
         A312ConfiguracoesImagemLoginExtencao = "";
         n312ConfiguracoesImagemLoginExtencao = false;
         AssignAttri("", false, "A312ConfiguracoesImagemLoginExtencao", A312ConfiguracoesImagemLoginExtencao);
         A313ConfiguracoesImagemLoginNome = "";
         n313ConfiguracoesImagemLoginNome = false;
         AssignAttri("", false, "A313ConfiguracoesImagemLoginNome", A313ConfiguracoesImagemLoginNome);
         Z315ConfiguracoesImagemLoginNomeInteiro = "";
         Z316ConfiguracoesImagemLoginTamanho = 0;
         Z317ConfiguracoesImagemLoginBackground = "";
         Z319ConfiguracoesImagemHeaderNome = "";
         Z320ConfiguracoesImagemHeaderExtencao = "";
         Z321ConfiguracoesImagemHeaderNomeInteiro = "";
         Z322ConfiguracoesImagemHeaderTamanho = 0;
         Z563ConfiguracaoSenhaPFX = "";
         Z765ConfiguracoesSerasaAnotacoesCompletas = false;
         Z766ConfiguracoesSerasaConsultaDetalhada = false;
         Z767ConfiguracoesSerasaParticipacaoSocietaria = false;
         Z768ConfiguracoesSerasaRendaEstimada = false;
         Z769ConfiguracoesSerasaHistoricoPagamento = false;
         Z1013ConfiguracoesCompraTituloTaxaEfetiva = 0;
         Z1014ConfiguracoesCompraTituloTaxaMora = 0;
         Z1036ConfiguracoesCompraTituloFator = 0;
         Z1037ConfiguracoesCompraTituloTarifaTipo = "";
         Z1038ConfiguracoesCompraTituloTarifa = 0;
         Z398ConfiguracoesLayoutProposta = 0;
         Z564ConfigLayoutPromissoriaClinicaEmprestimo = 0;
         Z565ConfigLayoutPromissoriaClinicaTaxa = 0;
         Z566ConfigLayoutPromissoriaPaciente = 0;
         Z922ConfigLayoutContratoCompraTitulo = 0;
         Z654ConfiguracoesCategoriaTitulo = 0;
      }

      protected void InitAll1948( )
      {
         A299ConfiguracoesId = 0;
         AssignAttri("", false, "A299ConfiguracoesId", StringUtil.LTrimStr( (decimal)(A299ConfiguracoesId), 9, 0));
         InitializeNonKey1948( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019151858", true, true);
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
         context.AddJavascriptSource("configuracoes.js", "?202561019151859", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         edtConfiguracoesId_Internalname = "CONFIGURACOESID";
         edtConfiguracoesImagemLogin_Internalname = "CONFIGURACOESIMAGEMLOGIN";
         edtConfiguracoesImagemLoginNomeInteiro_Internalname = "CONFIGURACOESIMAGEMLOGINNOMEINTEIRO";
         edtConfiguracoesImagemLoginTamanho_Internalname = "CONFIGURACOESIMAGEMLOGINTAMANHO";
         edtConfiguracoesImagemLoginBackground_Internalname = "CONFIGURACOESIMAGEMLOGINBACKGROUND";
         edtConfiguracoesImagemHeader_Internalname = "CONFIGURACOESIMAGEMHEADER";
         edtConfiguracoesImagemHeaderNome_Internalname = "CONFIGURACOESIMAGEMHEADERNOME";
         edtConfiguracoesImagemHeaderExtencao_Internalname = "CONFIGURACOESIMAGEMHEADEREXTENCAO";
         edtConfiguracoesImagemHeaderNomeInteiro_Internalname = "CONFIGURACOESIMAGEMHEADERNOMEINTEIRO";
         edtConfiguracoesImagemHeaderTamanho_Internalname = "CONFIGURACOESIMAGEMHEADERTAMANHO";
         edtConfiguracoesLayoutProposta_Internalname = "CONFIGURACOESLAYOUTPROPOSTA";
         Configuracoeslayoutcontratocorpo_Internalname = "CONFIGURACOESLAYOUTCONTRATOCORPO";
         edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname = "CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO";
         Configlayoutcorpopromissoriaclinicaemprestimo_Internalname = "CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO";
         edtConfigLayoutPromissoriaClinicaTaxa_Internalname = "CONFIGLAYOUTPROMISSORIACLINICATAXA";
         Configlayoutcorpopromissoriaclinicataxa_Internalname = "CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA";
         edtConfigLayoutPromissoriaPaciente_Internalname = "CONFIGLAYOUTPROMISSORIAPACIENTE";
         edtConfigLayoutContratoCompraTitulo_Internalname = "CONFIGLAYOUTCONTRATOCOMPRATITULO";
         Configlayoutcorpopromissoriapaciente_Internalname = "CONFIGLAYOUTCORPOPROMISSORIAPACIENTE";
         edtConfiguracoesArquivoPFX_Internalname = "CONFIGURACOESARQUIVOPFX";
         edtConfiguracaoSenhaPFX_Internalname = "CONFIGURACAOSENHAPFX";
         edtConfiguracoesCategoriaTitulo_Internalname = "CONFIGURACOESCATEGORIATITULO";
         cmbConfiguracoesSerasaAnotacoesCompletas_Internalname = "CONFIGURACOESSERASAANOTACOESCOMPLETAS";
         cmbConfiguracoesSerasaConsultaDetalhada_Internalname = "CONFIGURACOESSERASACONSULTADETALHADA";
         cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname = "CONFIGURACOESSERASAPARTICIPACAOSOCIETARIA";
         cmbConfiguracoesSerasaRendaEstimada_Internalname = "CONFIGURACOESSERASARENDAESTIMADA";
         cmbConfiguracoesSerasaHistoricoPagamento_Internalname = "CONFIGURACOESSERASAHISTORICOPAGAMENTO";
         edtConfiguracoesCompraTituloTaxaEfetiva_Internalname = "CONFIGURACOESCOMPRATITULOTAXAEFETIVA";
         edtConfiguracoesCompraTituloTaxaMora_Internalname = "CONFIGURACOESCOMPRATITULOTAXAMORA";
         edtConfiguracoesCompraTituloFator_Internalname = "CONFIGURACOESCOMPRATITULOFATOR";
         cmbConfiguracoesCompraTituloTarifaTipo_Internalname = "CONFIGURACOESCOMPRATITULOTARIFATIPO";
         edtConfiguracoesCompraTituloTarifa_Internalname = "CONFIGURACOESCOMPRATITULOTARIFA";
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
         edtConfiguracoesArquivoPFX_Filename = "";
         edtConfiguracoesImagemHeader_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Configuracoes";
         edtConfiguracoesImagemLogin_Filename = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtConfiguracoesCompraTituloTarifa_Jsonclick = "";
         edtConfiguracoesCompraTituloTarifa_Enabled = 1;
         cmbConfiguracoesCompraTituloTarifaTipo_Jsonclick = "";
         cmbConfiguracoesCompraTituloTarifaTipo.Enabled = 1;
         edtConfiguracoesCompraTituloFator_Jsonclick = "";
         edtConfiguracoesCompraTituloFator_Enabled = 1;
         edtConfiguracoesCompraTituloTaxaMora_Jsonclick = "";
         edtConfiguracoesCompraTituloTaxaMora_Enabled = 1;
         edtConfiguracoesCompraTituloTaxaEfetiva_Jsonclick = "";
         edtConfiguracoesCompraTituloTaxaEfetiva_Enabled = 1;
         cmbConfiguracoesSerasaHistoricoPagamento_Jsonclick = "";
         cmbConfiguracoesSerasaHistoricoPagamento.Enabled = 1;
         cmbConfiguracoesSerasaRendaEstimada_Jsonclick = "";
         cmbConfiguracoesSerasaRendaEstimada.Enabled = 1;
         cmbConfiguracoesSerasaParticipacaoSocietaria_Jsonclick = "";
         cmbConfiguracoesSerasaParticipacaoSocietaria.Enabled = 1;
         cmbConfiguracoesSerasaConsultaDetalhada_Jsonclick = "";
         cmbConfiguracoesSerasaConsultaDetalhada.Enabled = 1;
         cmbConfiguracoesSerasaAnotacoesCompletas_Jsonclick = "";
         cmbConfiguracoesSerasaAnotacoesCompletas.Enabled = 1;
         edtConfiguracoesCategoriaTitulo_Jsonclick = "";
         edtConfiguracoesCategoriaTitulo_Enabled = 1;
         edtConfiguracaoSenhaPFX_Jsonclick = "";
         edtConfiguracaoSenhaPFX_Enabled = 1;
         edtConfiguracoesArquivoPFX_Jsonclick = "";
         edtConfiguracoesArquivoPFX_Parameters = "";
         edtConfiguracoesArquivoPFX_Contenttype = "";
         edtConfiguracoesArquivoPFX_Filetype = "";
         edtConfiguracoesArquivoPFX_Enabled = 1;
         Configlayoutcorpopromissoriapaciente_Captionposition = "Left";
         Configlayoutcorpopromissoriapaciente_Captionstyle = "";
         Configlayoutcorpopromissoriapaciente_Captionclass = "col-sm-3 AttributeLabel";
         Configlayoutcorpopromissoriapaciente_Enabled = Convert.ToBoolean( 0);
         edtConfigLayoutContratoCompraTitulo_Jsonclick = "";
         edtConfigLayoutContratoCompraTitulo_Enabled = 1;
         edtConfigLayoutPromissoriaPaciente_Jsonclick = "";
         edtConfigLayoutPromissoriaPaciente_Enabled = 1;
         Configlayoutcorpopromissoriaclinicataxa_Captionposition = "Left";
         Configlayoutcorpopromissoriaclinicataxa_Captionstyle = "";
         Configlayoutcorpopromissoriaclinicataxa_Captionclass = "col-sm-3 AttributeLabel";
         Configlayoutcorpopromissoriaclinicataxa_Enabled = Convert.ToBoolean( 0);
         edtConfigLayoutPromissoriaClinicaTaxa_Jsonclick = "";
         edtConfigLayoutPromissoriaClinicaTaxa_Enabled = 1;
         Configlayoutcorpopromissoriaclinicaemprestimo_Captionposition = "Left";
         Configlayoutcorpopromissoriaclinicaemprestimo_Captionstyle = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Captionclass = "col-sm-3 AttributeLabel";
         Configlayoutcorpopromissoriaclinicaemprestimo_Enabled = Convert.ToBoolean( 0);
         edtConfigLayoutPromissoriaClinicaEmprestimo_Jsonclick = "";
         edtConfigLayoutPromissoriaClinicaEmprestimo_Enabled = 1;
         Configuracoeslayoutcontratocorpo_Captionposition = "Left";
         Configuracoeslayoutcontratocorpo_Captionstyle = "";
         Configuracoeslayoutcontratocorpo_Captionclass = "col-sm-3 AttributeLabel";
         Configuracoeslayoutcontratocorpo_Enabled = Convert.ToBoolean( 0);
         edtConfiguracoesLayoutProposta_Jsonclick = "";
         edtConfiguracoesLayoutProposta_Enabled = 1;
         edtConfiguracoesImagemHeaderTamanho_Jsonclick = "";
         edtConfiguracoesImagemHeaderTamanho_Enabled = 1;
         edtConfiguracoesImagemHeaderNomeInteiro_Jsonclick = "";
         edtConfiguracoesImagemHeaderNomeInteiro_Enabled = 1;
         edtConfiguracoesImagemHeaderExtencao_Jsonclick = "";
         edtConfiguracoesImagemHeaderExtencao_Enabled = 1;
         edtConfiguracoesImagemHeaderNome_Jsonclick = "";
         edtConfiguracoesImagemHeaderNome_Enabled = 1;
         edtConfiguracoesImagemHeader_Jsonclick = "";
         edtConfiguracoesImagemHeader_Parameters = "";
         edtConfiguracoesImagemHeader_Contenttype = "";
         edtConfiguracoesImagemHeader_Filetype = "";
         edtConfiguracoesImagemHeader_Enabled = 1;
         edtConfiguracoesImagemLoginBackground_Jsonclick = "";
         edtConfiguracoesImagemLoginBackground_Enabled = 1;
         edtConfiguracoesImagemLoginTamanho_Jsonclick = "";
         edtConfiguracoesImagemLoginTamanho_Enabled = 1;
         edtConfiguracoesImagemLoginNomeInteiro_Jsonclick = "";
         edtConfiguracoesImagemLoginNomeInteiro_Enabled = 1;
         edtConfiguracoesImagemLogin_Jsonclick = "";
         edtConfiguracoesImagemLogin_Parameters = "";
         edtConfiguracoesImagemLogin_Contenttype = "";
         edtConfiguracoesImagemLogin_Filetype = "";
         edtConfiguracoesImagemLogin_Enabled = 1;
         edtConfiguracoesId_Jsonclick = "";
         edtConfiguracoesId_Enabled = 1;
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
         cmbConfiguracoesSerasaAnotacoesCompletas.Name = "CONFIGURACOESSERASAANOTACOESCOMPLETAS";
         cmbConfiguracoesSerasaAnotacoesCompletas.WebTags = "";
         cmbConfiguracoesSerasaAnotacoesCompletas.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbConfiguracoesSerasaAnotacoesCompletas.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbConfiguracoesSerasaAnotacoesCompletas.ItemCount > 0 )
         {
            A765ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cmbConfiguracoesSerasaAnotacoesCompletas.getValidValue(StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas)));
            n765ConfiguracoesSerasaAnotacoesCompletas = false;
            AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
         }
         cmbConfiguracoesSerasaConsultaDetalhada.Name = "CONFIGURACOESSERASACONSULTADETALHADA";
         cmbConfiguracoesSerasaConsultaDetalhada.WebTags = "";
         cmbConfiguracoesSerasaConsultaDetalhada.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbConfiguracoesSerasaConsultaDetalhada.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbConfiguracoesSerasaConsultaDetalhada.ItemCount > 0 )
         {
            A766ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cmbConfiguracoesSerasaConsultaDetalhada.getValidValue(StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada)));
            n766ConfiguracoesSerasaConsultaDetalhada = false;
            AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
         }
         cmbConfiguracoesSerasaParticipacaoSocietaria.Name = "CONFIGURACOESSERASAPARTICIPACAOSOCIETARIA";
         cmbConfiguracoesSerasaParticipacaoSocietaria.WebTags = "";
         cmbConfiguracoesSerasaParticipacaoSocietaria.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbConfiguracoesSerasaParticipacaoSocietaria.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbConfiguracoesSerasaParticipacaoSocietaria.ItemCount > 0 )
         {
            A767ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbConfiguracoesSerasaParticipacaoSocietaria.getValidValue(StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria)));
            n767ConfiguracoesSerasaParticipacaoSocietaria = false;
            AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
         }
         cmbConfiguracoesSerasaRendaEstimada.Name = "CONFIGURACOESSERASARENDAESTIMADA";
         cmbConfiguracoesSerasaRendaEstimada.WebTags = "";
         cmbConfiguracoesSerasaRendaEstimada.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbConfiguracoesSerasaRendaEstimada.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbConfiguracoesSerasaRendaEstimada.ItemCount > 0 )
         {
            A768ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cmbConfiguracoesSerasaRendaEstimada.getValidValue(StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada)));
            n768ConfiguracoesSerasaRendaEstimada = false;
            AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
         }
         cmbConfiguracoesSerasaHistoricoPagamento.Name = "CONFIGURACOESSERASAHISTORICOPAGAMENTO";
         cmbConfiguracoesSerasaHistoricoPagamento.WebTags = "";
         cmbConfiguracoesSerasaHistoricoPagamento.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbConfiguracoesSerasaHistoricoPagamento.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbConfiguracoesSerasaHistoricoPagamento.ItemCount > 0 )
         {
            A769ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cmbConfiguracoesSerasaHistoricoPagamento.getValidValue(StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento)));
            n769ConfiguracoesSerasaHistoricoPagamento = false;
            AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
         }
         cmbConfiguracoesCompraTituloTarifaTipo.Name = "CONFIGURACOESCOMPRATITULOTARIFATIPO";
         cmbConfiguracoesCompraTituloTarifaTipo.WebTags = "";
         cmbConfiguracoesCompraTituloTarifaTipo.addItem("Valor", "Valor", 0);
         cmbConfiguracoesCompraTituloTarifaTipo.addItem("Percentual", "Percentual", 0);
         if ( cmbConfiguracoesCompraTituloTarifaTipo.ItemCount > 0 )
         {
            A1037ConfiguracoesCompraTituloTarifaTipo = cmbConfiguracoesCompraTituloTarifaTipo.getValidValue(A1037ConfiguracoesCompraTituloTarifaTipo);
            n1037ConfiguracoesCompraTituloTarifaTipo = false;
            AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtConfiguracoesImagemLogin_Internalname;
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

      public void Valid_Configuracoesid( )
      {
         n1037ConfiguracoesCompraTituloTarifaTipo = false;
         A1037ConfiguracoesCompraTituloTarifaTipo = cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue;
         n1037ConfiguracoesCompraTituloTarifaTipo = false;
         cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = A1037ConfiguracoesCompraTituloTarifaTipo;
         n769ConfiguracoesSerasaHistoricoPagamento = false;
         A769ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue);
         n769ConfiguracoesSerasaHistoricoPagamento = false;
         cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento);
         n768ConfiguracoesSerasaRendaEstimada = false;
         A768ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cmbConfiguracoesSerasaRendaEstimada.CurrentValue);
         n768ConfiguracoesSerasaRendaEstimada = false;
         cmbConfiguracoesSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada);
         n767ConfiguracoesSerasaParticipacaoSocietaria = false;
         A767ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue);
         n767ConfiguracoesSerasaParticipacaoSocietaria = false;
         cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria);
         n766ConfiguracoesSerasaConsultaDetalhada = false;
         A766ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue);
         n766ConfiguracoesSerasaConsultaDetalhada = false;
         cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada);
         n765ConfiguracoesSerasaAnotacoesCompletas = false;
         A765ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue);
         n765ConfiguracoesSerasaAnotacoesCompletas = false;
         cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbConfiguracoesSerasaAnotacoesCompletas.ItemCount > 0 )
         {
            A765ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cmbConfiguracoesSerasaAnotacoesCompletas.getValidValue(StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas)));
            n765ConfiguracoesSerasaAnotacoesCompletas = false;
            cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas);
         }
         if ( cmbConfiguracoesSerasaConsultaDetalhada.ItemCount > 0 )
         {
            A766ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cmbConfiguracoesSerasaConsultaDetalhada.getValidValue(StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada)));
            n766ConfiguracoesSerasaConsultaDetalhada = false;
            cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada);
         }
         if ( cmbConfiguracoesSerasaParticipacaoSocietaria.ItemCount > 0 )
         {
            A767ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbConfiguracoesSerasaParticipacaoSocietaria.getValidValue(StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria)));
            n767ConfiguracoesSerasaParticipacaoSocietaria = false;
            cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria);
         }
         if ( cmbConfiguracoesSerasaRendaEstimada.ItemCount > 0 )
         {
            A768ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cmbConfiguracoesSerasaRendaEstimada.getValidValue(StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada)));
            n768ConfiguracoesSerasaRendaEstimada = false;
            cmbConfiguracoesSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada);
         }
         if ( cmbConfiguracoesSerasaHistoricoPagamento.ItemCount > 0 )
         {
            A769ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cmbConfiguracoesSerasaHistoricoPagamento.getValidValue(StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento)));
            n769ConfiguracoesSerasaHistoricoPagamento = false;
            cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento);
         }
         if ( cmbConfiguracoesCompraTituloTarifaTipo.ItemCount > 0 )
         {
            A1037ConfiguracoesCompraTituloTarifaTipo = cmbConfiguracoesCompraTituloTarifaTipo.getValidValue(A1037ConfiguracoesCompraTituloTarifaTipo);
            n1037ConfiguracoesCompraTituloTarifaTipo = false;
            cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = A1037ConfiguracoesCompraTituloTarifaTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A300ConfiguracoesImagemLogin", context.PathToRelativeUrl( A300ConfiguracoesImagemLogin));
         AssignAttri("", false, "A315ConfiguracoesImagemLoginNomeInteiro", A315ConfiguracoesImagemLoginNomeInteiro);
         AssignAttri("", false, "A316ConfiguracoesImagemLoginTamanho", ((Convert.ToDecimal(0)==A316ConfiguracoesImagemLoginTamanho)&&IsIns( )||n316ConfiguracoesImagemLoginTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A316ConfiguracoesImagemLoginTamanho, 18, 2, ".", ""))));
         AssignAttri("", false, "A317ConfiguracoesImagemLoginBackground", A317ConfiguracoesImagemLoginBackground);
         AssignAttri("", false, "A318ConfiguracoesImagemHeader", context.PathToRelativeUrl( A318ConfiguracoesImagemHeader));
         AssignAttri("", false, "A319ConfiguracoesImagemHeaderNome", A319ConfiguracoesImagemHeaderNome);
         AssignAttri("", false, "A320ConfiguracoesImagemHeaderExtencao", A320ConfiguracoesImagemHeaderExtencao);
         AssignAttri("", false, "A321ConfiguracoesImagemHeaderNomeInteiro", A321ConfiguracoesImagemHeaderNomeInteiro);
         AssignAttri("", false, "A322ConfiguracoesImagemHeaderTamanho", ((Convert.ToDecimal(0)==A322ConfiguracoesImagemHeaderTamanho)&&IsIns( )||n322ConfiguracoesImagemHeaderTamanho ? "" : StringUtil.LTrim( StringUtil.NToC( A322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", ""))));
         AssignAttri("", false, "A564ConfigLayoutPromissoriaClinicaEmprestimo", ((0==A564ConfigLayoutPromissoriaClinicaEmprestimo)&&IsIns( )||n564ConfigLayoutPromissoriaClinicaEmprestimo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", ""))));
         AssignAttri("", false, "A565ConfigLayoutPromissoriaClinicaTaxa", ((0==A565ConfigLayoutPromissoriaClinicaTaxa)&&IsIns( )||n565ConfigLayoutPromissoriaClinicaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", ""))));
         AssignAttri("", false, "A566ConfigLayoutPromissoriaPaciente", ((0==A566ConfigLayoutPromissoriaPaciente)&&IsIns( )||n566ConfigLayoutPromissoriaPaciente ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A566ConfigLayoutPromissoriaPaciente), 4, 0, ".", ""))));
         AssignAttri("", false, "A562ConfiguracoesArquivoPFX", context.PathToRelativeUrl( A562ConfiguracoesArquivoPFX));
         AssignAttri("", false, "A563ConfiguracaoSenhaPFX", A563ConfiguracaoSenhaPFX);
         AssignAttri("", false, "A654ConfiguracoesCategoriaTitulo", ((0==A654ConfiguracoesCategoriaTitulo)&&IsIns( )||n654ConfiguracoesCategoriaTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A654ConfiguracoesCategoriaTitulo), 9, 0, ".", ""))));
         AssignAttri("", false, "A765ConfiguracoesSerasaAnotacoesCompletas", A765ConfiguracoesSerasaAnotacoesCompletas);
         cmbConfiguracoesSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A765ConfiguracoesSerasaAnotacoesCompletas);
         AssignProp("", false, cmbConfiguracoesSerasaAnotacoesCompletas_Internalname, "Values", cmbConfiguracoesSerasaAnotacoesCompletas.ToJavascriptSource(), true);
         AssignAttri("", false, "A766ConfiguracoesSerasaConsultaDetalhada", A766ConfiguracoesSerasaConsultaDetalhada);
         cmbConfiguracoesSerasaConsultaDetalhada.CurrentValue = StringUtil.BoolToStr( A766ConfiguracoesSerasaConsultaDetalhada);
         AssignProp("", false, cmbConfiguracoesSerasaConsultaDetalhada_Internalname, "Values", cmbConfiguracoesSerasaConsultaDetalhada.ToJavascriptSource(), true);
         AssignAttri("", false, "A767ConfiguracoesSerasaParticipacaoSocietaria", A767ConfiguracoesSerasaParticipacaoSocietaria);
         cmbConfiguracoesSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A767ConfiguracoesSerasaParticipacaoSocietaria);
         AssignProp("", false, cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname, "Values", cmbConfiguracoesSerasaParticipacaoSocietaria.ToJavascriptSource(), true);
         AssignAttri("", false, "A768ConfiguracoesSerasaRendaEstimada", A768ConfiguracoesSerasaRendaEstimada);
         cmbConfiguracoesSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A768ConfiguracoesSerasaRendaEstimada);
         AssignProp("", false, cmbConfiguracoesSerasaRendaEstimada_Internalname, "Values", cmbConfiguracoesSerasaRendaEstimada.ToJavascriptSource(), true);
         AssignAttri("", false, "A769ConfiguracoesSerasaHistoricoPagamento", A769ConfiguracoesSerasaHistoricoPagamento);
         cmbConfiguracoesSerasaHistoricoPagamento.CurrentValue = StringUtil.BoolToStr( A769ConfiguracoesSerasaHistoricoPagamento);
         AssignProp("", false, cmbConfiguracoesSerasaHistoricoPagamento_Internalname, "Values", cmbConfiguracoesSerasaHistoricoPagamento.ToJavascriptSource(), true);
         AssignAttri("", false, "A1013ConfiguracoesCompraTituloTaxaEfetiva", ((Convert.ToDecimal(0)==A1013ConfiguracoesCompraTituloTaxaEfetiva)&&IsIns( )||n1013ConfiguracoesCompraTituloTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", ""))));
         AssignAttri("", false, "A1014ConfiguracoesCompraTituloTaxaMora", ((Convert.ToDecimal(0)==A1014ConfiguracoesCompraTituloTaxaMora)&&IsIns( )||n1014ConfiguracoesCompraTituloTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", ""))));
         AssignAttri("", false, "A1036ConfiguracoesCompraTituloFator", ((Convert.ToDecimal(0)==A1036ConfiguracoesCompraTituloFator)&&IsIns( )||n1036ConfiguracoesCompraTituloFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1036ConfiguracoesCompraTituloFator, 16, 4, ".", ""))));
         AssignAttri("", false, "A1037ConfiguracoesCompraTituloTarifaTipo", A1037ConfiguracoesCompraTituloTarifaTipo);
         cmbConfiguracoesCompraTituloTarifaTipo.CurrentValue = StringUtil.RTrim( A1037ConfiguracoesCompraTituloTarifaTipo);
         AssignProp("", false, cmbConfiguracoesCompraTituloTarifaTipo_Internalname, "Values", cmbConfiguracoesCompraTituloTarifaTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A1038ConfiguracoesCompraTituloTarifa", ((Convert.ToDecimal(0)==A1038ConfiguracoesCompraTituloTarifa)&&IsIns( )||n1038ConfiguracoesCompraTituloTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", ""))));
         AssignAttri("", false, "A312ConfiguracoesImagemLoginExtencao", A312ConfiguracoesImagemLoginExtencao);
         AssignAttri("", false, "A313ConfiguracoesImagemLoginNome", A313ConfiguracoesImagemLoginNome);
         AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
         AssignAttri("", false, "A418ConfiguracoesLayoutContratoCorpo", A418ConfiguracoesLayoutContratoCorpo);
         AssignAttri("", false, "A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo", A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo);
         AssignAttri("", false, "A568ConfigLayoutCorpoPromissoriaClinicaTaxa", A568ConfigLayoutCorpoPromissoriaClinicaTaxa);
         AssignAttri("", false, "A569ConfigLayoutCorpoPromissoriaPaciente", A569ConfigLayoutCorpoPromissoriaPaciente);
         AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
         AssignProp("", false, edtConfiguracoesImagemLogin_Internalname, "Filetype", edtConfiguracoesImagemLogin_Filetype, true);
         AssignProp("", false, edtConfiguracoesImagemHeader_Internalname, "Filetype", edtConfiguracoesImagemHeader_Filetype, true);
         AssignProp("", false, edtConfiguracoesArquivoPFX_Internalname, "Filetype", edtConfiguracoesArquivoPFX_Filetype, true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z299ConfiguracoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299ConfiguracoesId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z300ConfiguracoesImagemLogin", context.PathToRelativeUrl( Z300ConfiguracoesImagemLogin));
         GxWebStd.gx_hidden_field( context, "Z315ConfiguracoesImagemLoginNomeInteiro", Z315ConfiguracoesImagemLoginNomeInteiro);
         GxWebStd.gx_hidden_field( context, "Z316ConfiguracoesImagemLoginTamanho", StringUtil.LTrim( StringUtil.NToC( Z316ConfiguracoesImagemLoginTamanho, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z317ConfiguracoesImagemLoginBackground", Z317ConfiguracoesImagemLoginBackground);
         GxWebStd.gx_hidden_field( context, "Z318ConfiguracoesImagemHeader", context.PathToRelativeUrl( Z318ConfiguracoesImagemHeader));
         GxWebStd.gx_hidden_field( context, "Z319ConfiguracoesImagemHeaderNome", Z319ConfiguracoesImagemHeaderNome);
         GxWebStd.gx_hidden_field( context, "Z320ConfiguracoesImagemHeaderExtencao", Z320ConfiguracoesImagemHeaderExtencao);
         GxWebStd.gx_hidden_field( context, "Z321ConfiguracoesImagemHeaderNomeInteiro", Z321ConfiguracoesImagemHeaderNomeInteiro);
         GxWebStd.gx_hidden_field( context, "Z322ConfiguracoesImagemHeaderTamanho", StringUtil.LTrim( StringUtil.NToC( Z322ConfiguracoesImagemHeaderTamanho, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z564ConfigLayoutPromissoriaClinicaEmprestimo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z564ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z565ConfigLayoutPromissoriaClinicaTaxa", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z565ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z566ConfigLayoutPromissoriaPaciente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z566ConfigLayoutPromissoriaPaciente), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z562ConfiguracoesArquivoPFX", context.PathToRelativeUrl( Z562ConfiguracoesArquivoPFX));
         GxWebStd.gx_hidden_field( context, "Z563ConfiguracaoSenhaPFX", Z563ConfiguracaoSenhaPFX);
         GxWebStd.gx_hidden_field( context, "Z654ConfiguracoesCategoriaTitulo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z654ConfiguracoesCategoriaTitulo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z765ConfiguracoesSerasaAnotacoesCompletas", StringUtil.BoolToStr( Z765ConfiguracoesSerasaAnotacoesCompletas));
         GxWebStd.gx_hidden_field( context, "Z766ConfiguracoesSerasaConsultaDetalhada", StringUtil.BoolToStr( Z766ConfiguracoesSerasaConsultaDetalhada));
         GxWebStd.gx_hidden_field( context, "Z767ConfiguracoesSerasaParticipacaoSocietaria", StringUtil.BoolToStr( Z767ConfiguracoesSerasaParticipacaoSocietaria));
         GxWebStd.gx_hidden_field( context, "Z768ConfiguracoesSerasaRendaEstimada", StringUtil.BoolToStr( Z768ConfiguracoesSerasaRendaEstimada));
         GxWebStd.gx_hidden_field( context, "Z769ConfiguracoesSerasaHistoricoPagamento", StringUtil.BoolToStr( Z769ConfiguracoesSerasaHistoricoPagamento));
         GxWebStd.gx_hidden_field( context, "Z1013ConfiguracoesCompraTituloTaxaEfetiva", StringUtil.LTrim( StringUtil.NToC( Z1013ConfiguracoesCompraTituloTaxaEfetiva, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1014ConfiguracoesCompraTituloTaxaMora", StringUtil.LTrim( StringUtil.NToC( Z1014ConfiguracoesCompraTituloTaxaMora, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1036ConfiguracoesCompraTituloFator", StringUtil.LTrim( StringUtil.NToC( Z1036ConfiguracoesCompraTituloFator, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1037ConfiguracoesCompraTituloTarifaTipo", Z1037ConfiguracoesCompraTituloTarifaTipo);
         GxWebStd.gx_hidden_field( context, "Z1038ConfiguracoesCompraTituloTarifa", StringUtil.LTrim( StringUtil.NToC( Z1038ConfiguracoesCompraTituloTarifa, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z312ConfiguracoesImagemLoginExtencao", Z312ConfiguracoesImagemLoginExtencao);
         GxWebStd.gx_hidden_field( context, "Z313ConfiguracoesImagemLoginNome", Z313ConfiguracoesImagemLoginNome);
         GxWebStd.gx_hidden_field( context, "Z398ConfiguracoesLayoutProposta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z398ConfiguracoesLayoutProposta), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z418ConfiguracoesLayoutContratoCorpo", Z418ConfiguracoesLayoutContratoCorpo);
         GxWebStd.gx_hidden_field( context, "Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo", Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo);
         GxWebStd.gx_hidden_field( context, "Z568ConfigLayoutCorpoPromissoriaClinicaTaxa", Z568ConfigLayoutCorpoPromissoriaClinicaTaxa);
         GxWebStd.gx_hidden_field( context, "Z569ConfigLayoutCorpoPromissoriaPaciente", Z569ConfigLayoutCorpoPromissoriaPaciente);
         GxWebStd.gx_hidden_field( context, "Z922ConfigLayoutContratoCompraTitulo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z922ConfigLayoutContratoCompraTitulo), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Configuracoeslayoutproposta( )
      {
         n418ConfiguracoesLayoutContratoCorpo = false;
         if ( (0==A398ConfiguracoesLayoutProposta) )
         {
            A398ConfiguracoesLayoutProposta = 0;
            n398ConfiguracoesLayoutProposta = false;
            n398ConfiguracoesLayoutProposta = true;
            n398ConfiguracoesLayoutProposta = true;
         }
         /* Using cursor T001927 */
         pr_default.execute(25, new Object[] {n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A398ConfiguracoesLayoutProposta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Proposta Config'.", "ForeignKeyNotFound", 1, "CONFIGURACOESLAYOUTPROPOSTA");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesLayoutProposta_Internalname;
            }
         }
         A418ConfiguracoesLayoutContratoCorpo = T001927_A418ConfiguracoesLayoutContratoCorpo[0];
         n418ConfiguracoesLayoutContratoCorpo = T001927_n418ConfiguracoesLayoutContratoCorpo[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A398ConfiguracoesLayoutProposta", ((0==A398ConfiguracoesLayoutProposta)&&IsIns( )||n398ConfiguracoesLayoutProposta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A398ConfiguracoesLayoutProposta), 4, 0, ".", ""))));
         AssignAttri("", false, "A418ConfiguracoesLayoutContratoCorpo", A418ConfiguracoesLayoutContratoCorpo);
      }

      public void Valid_Configlayoutpromissoriaclinicaemprestimo( )
      {
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = false;
         /* Using cursor T001928 */
         pr_default.execute(26, new Object[] {n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A564ConfigLayoutPromissoriaClinicaEmprestimo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Emprestimo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname;
            }
         }
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001928_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = T001928_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo", A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo);
      }

      public void Valid_Configlayoutpromissoriaclinicataxa( )
      {
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = false;
         /* Using cursor T001929 */
         pr_default.execute(27, new Object[] {n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A565ConfigLayoutPromissoriaClinicaTaxa) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Taxa'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICATAXA");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaClinicaTaxa_Internalname;
            }
         }
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001929_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = T001929_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A568ConfigLayoutCorpoPromissoriaClinicaTaxa", A568ConfigLayoutCorpoPromissoriaClinicaTaxa);
      }

      public void Valid_Configlayoutpromissoriapaciente( )
      {
         n569ConfigLayoutCorpoPromissoriaPaciente = false;
         /* Using cursor T001930 */
         pr_default.execute(28, new Object[] {n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A566ConfigLayoutPromissoriaPaciente) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Paciente'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIAPACIENTE");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutPromissoriaPaciente_Internalname;
            }
         }
         A569ConfigLayoutCorpoPromissoriaPaciente = T001930_A569ConfigLayoutCorpoPromissoriaPaciente[0];
         n569ConfigLayoutCorpoPromissoriaPaciente = T001930_n569ConfigLayoutCorpoPromissoriaPaciente[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A569ConfigLayoutCorpoPromissoriaPaciente", A569ConfigLayoutCorpoPromissoriaPaciente);
      }

      public void Valid_Configlayoutcontratocompratitulo( )
      {
         if ( (0==A922ConfigLayoutContratoCompraTitulo) )
         {
            A922ConfigLayoutContratoCompraTitulo = 0;
            n922ConfigLayoutContratoCompraTitulo = false;
            n922ConfigLayoutContratoCompraTitulo = true;
            n922ConfigLayoutContratoCompraTitulo = true;
         }
         /* Using cursor T001932 */
         pr_default.execute(30, new Object[] {n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( (0==A922ConfigLayoutContratoCompraTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Config Layout Contrato Compra Titulo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTCONTRATOCOMPRATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfigLayoutContratoCompraTitulo_Internalname;
            }
         }
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A922ConfigLayoutContratoCompraTitulo", ((0==A922ConfigLayoutContratoCompraTitulo)&&IsIns( )||n922ConfigLayoutContratoCompraTitulo ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A922ConfigLayoutContratoCompraTitulo), 4, 0, ".", ""))));
      }

      public void Valid_Configuracoescategoriatitulo( )
      {
         /* Using cursor T001933 */
         pr_default.execute(31, new Object[] {n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( (0==A654ConfiguracoesCategoriaTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Categoria Titulo Confg'.", "ForeignKeyNotFound", 1, "CONFIGURACOESCATEGORIATITULO");
               AnyError = 1;
               GX_FocusControl = edtConfiguracoesCategoriaTitulo_Internalname;
            }
         }
         pr_default.close(31);
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
         setEventMetadata("VALID_CONFIGURACOESID","""{"handler":"Valid_Configuracoesid","iparms":[{"av":"cmbConfiguracoesCompraTituloTarifaTipo"},{"av":"A1037ConfiguracoesCompraTituloTarifaTipo","fld":"CONFIGURACOESCOMPRATITULOTARIFATIPO","type":"svchar"},{"av":"cmbConfiguracoesSerasaHistoricoPagamento"},{"av":"A769ConfiguracoesSerasaHistoricoPagamento","fld":"CONFIGURACOESSERASAHISTORICOPAGAMENTO","type":"boolean"},{"av":"cmbConfiguracoesSerasaRendaEstimada"},{"av":"A768ConfiguracoesSerasaRendaEstimada","fld":"CONFIGURACOESSERASARENDAESTIMADA","type":"boolean"},{"av":"cmbConfiguracoesSerasaParticipacaoSocietaria"},{"av":"A767ConfiguracoesSerasaParticipacaoSocietaria","fld":"CONFIGURACOESSERASAPARTICIPACAOSOCIETARIA","type":"boolean"},{"av":"cmbConfiguracoesSerasaConsultaDetalhada"},{"av":"A766ConfiguracoesSerasaConsultaDetalhada","fld":"CONFIGURACOESSERASACONSULTADETALHADA","type":"boolean"},{"av":"cmbConfiguracoesSerasaAnotacoesCompletas"},{"av":"A765ConfiguracoesSerasaAnotacoesCompletas","fld":"CONFIGURACOESSERASAANOTACOESCOMPLETAS","type":"boolean"},{"av":"A299ConfiguracoesId","fld":"CONFIGURACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_CONFIGURACOESID",""","oparms":[{"av":"A300ConfiguracoesImagemLogin","fld":"CONFIGURACOESIMAGEMLOGIN","type":"bitstr"},{"av":"A315ConfiguracoesImagemLoginNomeInteiro","fld":"CONFIGURACOESIMAGEMLOGINNOMEINTEIRO","type":"svchar"},{"av":"A316ConfiguracoesImagemLoginTamanho","fld":"CONFIGURACOESIMAGEMLOGINTAMANHO","pic":"ZZZZZZZZZZZZZZ9.99","nullAv":"n316ConfiguracoesImagemLoginTamanho","type":"decimal"},{"av":"A317ConfiguracoesImagemLoginBackground","fld":"CONFIGURACOESIMAGEMLOGINBACKGROUND","type":"svchar"},{"av":"A318ConfiguracoesImagemHeader","fld":"CONFIGURACOESIMAGEMHEADER","type":"bitstr"},{"av":"A319ConfiguracoesImagemHeaderNome","fld":"CONFIGURACOESIMAGEMHEADERNOME","type":"svchar"},{"av":"A320ConfiguracoesImagemHeaderExtencao","fld":"CONFIGURACOESIMAGEMHEADEREXTENCAO","type":"svchar"},{"av":"A321ConfiguracoesImagemHeaderNomeInteiro","fld":"CONFIGURACOESIMAGEMHEADERNOMEINTEIRO","type":"svchar"},{"av":"A322ConfiguracoesImagemHeaderTamanho","fld":"CONFIGURACOESIMAGEMHEADERTAMANHO","pic":"ZZZZZZZZZZZZZZ9.99","nullAv":"n322ConfiguracoesImagemHeaderTamanho","type":"decimal"},{"av":"A564ConfigLayoutPromissoriaClinicaEmprestimo","fld":"CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO","pic":"ZZZ9","nullAv":"n564ConfigLayoutPromissoriaClinicaEmprestimo","type":"int"},{"av":"A565ConfigLayoutPromissoriaClinicaTaxa","fld":"CONFIGLAYOUTPROMISSORIACLINICATAXA","pic":"ZZZ9","nullAv":"n565ConfigLayoutPromissoriaClinicaTaxa","type":"int"},{"av":"A566ConfigLayoutPromissoriaPaciente","fld":"CONFIGLAYOUTPROMISSORIAPACIENTE","pic":"ZZZ9","nullAv":"n566ConfigLayoutPromissoriaPaciente","type":"int"},{"av":"A562ConfiguracoesArquivoPFX","fld":"CONFIGURACOESARQUIVOPFX","type":"bitstr"},{"av":"A563ConfiguracaoSenhaPFX","fld":"CONFIGURACAOSENHAPFX","type":"svchar"},{"av":"A654ConfiguracoesCategoriaTitulo","fld":"CONFIGURACOESCATEGORIATITULO","pic":"ZZZZZZZZ9","nullAv":"n654ConfiguracoesCategoriaTitulo","type":"int"},{"av":"cmbConfiguracoesSerasaAnotacoesCompletas"},{"av":"A765ConfiguracoesSerasaAnotacoesCompletas","fld":"CONFIGURACOESSERASAANOTACOESCOMPLETAS","type":"boolean"},{"av":"cmbConfiguracoesSerasaConsultaDetalhada"},{"av":"A766ConfiguracoesSerasaConsultaDetalhada","fld":"CONFIGURACOESSERASACONSULTADETALHADA","type":"boolean"},{"av":"cmbConfiguracoesSerasaParticipacaoSocietaria"},{"av":"A767ConfiguracoesSerasaParticipacaoSocietaria","fld":"CONFIGURACOESSERASAPARTICIPACAOSOCIETARIA","type":"boolean"},{"av":"cmbConfiguracoesSerasaRendaEstimada"},{"av":"A768ConfiguracoesSerasaRendaEstimada","fld":"CONFIGURACOESSERASARENDAESTIMADA","type":"boolean"},{"av":"cmbConfiguracoesSerasaHistoricoPagamento"},{"av":"A769ConfiguracoesSerasaHistoricoPagamento","fld":"CONFIGURACOESSERASAHISTORICOPAGAMENTO","type":"boolean"},{"av":"A1013ConfiguracoesCompraTituloTaxaEfetiva","fld":"CONFIGURACOESCOMPRATITULOTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n1013ConfiguracoesCompraTituloTaxaEfetiva","type":"decimal"},{"av":"A1014ConfiguracoesCompraTituloTaxaMora","fld":"CONFIGURACOESCOMPRATITULOTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n1014ConfiguracoesCompraTituloTaxaMora","type":"decimal"},{"av":"A1036ConfiguracoesCompraTituloFator","fld":"CONFIGURACOESCOMPRATITULOFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n1036ConfiguracoesCompraTituloFator","type":"decimal"},{"av":"cmbConfiguracoesCompraTituloTarifaTipo"},{"av":"A1037ConfiguracoesCompraTituloTarifaTipo","fld":"CONFIGURACOESCOMPRATITULOTARIFATIPO","type":"svchar"},{"av":"A1038ConfiguracoesCompraTituloTarifa","fld":"CONFIGURACOESCOMPRATITULOTARIFA","pic":"ZZZZZZZZZZZ9.99","nullAv":"n1038ConfiguracoesCompraTituloTarifa","type":"decimal"},{"av":"A312ConfiguracoesImagemLoginExtencao","fld":"CONFIGURACOESIMAGEMLOGINEXTENCAO","type":"svchar"},{"av":"A313ConfiguracoesImagemLoginNome","fld":"CONFIGURACOESIMAGEMLOGINNOME","type":"svchar"},{"av":"A398ConfiguracoesLayoutProposta","fld":"CONFIGURACOESLAYOUTPROPOSTA","pic":"ZZZ9","nullAv":"n398ConfiguracoesLayoutProposta","type":"int"},{"av":"A418ConfiguracoesLayoutContratoCorpo","fld":"CONFIGURACOESLAYOUTCONTRATOCORPO","type":"vchar"},{"av":"A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo","fld":"CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO","type":"vchar"},{"av":"A568ConfigLayoutCorpoPromissoriaClinicaTaxa","fld":"CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA","type":"vchar"},{"av":"A569ConfigLayoutCorpoPromissoriaPaciente","fld":"CONFIGLAYOUTCORPOPROMISSORIAPACIENTE","type":"vchar"},{"av":"A922ConfigLayoutContratoCompraTitulo","fld":"CONFIGLAYOUTCONTRATOCOMPRATITULO","pic":"ZZZ9","nullAv":"n922ConfigLayoutContratoCompraTitulo","type":"int"},{"av":"edtConfiguracoesImagemLogin_Filetype","ctrl":"CONFIGURACOESIMAGEMLOGIN","prop":"Filetype"},{"av":"edtConfiguracoesImagemLogin_Filename","ctrl":"CONFIGURACOESIMAGEMLOGIN","prop":"Filename"},{"av":"edtConfiguracoesImagemHeader_Filetype","ctrl":"CONFIGURACOESIMAGEMHEADER","prop":"Filetype"},{"av":"edtConfiguracoesImagemHeader_Filename","ctrl":"CONFIGURACOESIMAGEMHEADER","prop":"Filename"},{"av":"edtConfiguracoesArquivoPFX_Filetype","ctrl":"CONFIGURACOESARQUIVOPFX","prop":"Filetype"},{"av":"edtConfiguracoesArquivoPFX_Filename","ctrl":"CONFIGURACOESARQUIVOPFX","prop":"Filename"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z299ConfiguracoesId","type":"int"},{"av":"Z300ConfiguracoesImagemLogin","type":"bitstr"},{"av":"Z315ConfiguracoesImagemLoginNomeInteiro","type":"svchar"},{"av":"Z316ConfiguracoesImagemLoginTamanho","type":"decimal"},{"av":"Z317ConfiguracoesImagemLoginBackground","type":"svchar"},{"av":"Z318ConfiguracoesImagemHeader","type":"bitstr"},{"av":"Z319ConfiguracoesImagemHeaderNome","type":"svchar"},{"av":"Z320ConfiguracoesImagemHeaderExtencao","type":"svchar"},{"av":"Z321ConfiguracoesImagemHeaderNomeInteiro","type":"svchar"},{"av":"Z322ConfiguracoesImagemHeaderTamanho","type":"decimal"},{"av":"Z564ConfigLayoutPromissoriaClinicaEmprestimo","type":"int"},{"av":"Z565ConfigLayoutPromissoriaClinicaTaxa","type":"int"},{"av":"Z566ConfigLayoutPromissoriaPaciente","type":"int"},{"av":"Z562ConfiguracoesArquivoPFX","type":"bitstr"},{"av":"Z563ConfiguracaoSenhaPFX","type":"svchar"},{"av":"Z654ConfiguracoesCategoriaTitulo","type":"int"},{"av":"Z765ConfiguracoesSerasaAnotacoesCompletas","type":"boolean"},{"av":"Z766ConfiguracoesSerasaConsultaDetalhada","type":"boolean"},{"av":"Z767ConfiguracoesSerasaParticipacaoSocietaria","type":"boolean"},{"av":"Z768ConfiguracoesSerasaRendaEstimada","type":"boolean"},{"av":"Z769ConfiguracoesSerasaHistoricoPagamento","type":"boolean"},{"av":"Z1013ConfiguracoesCompraTituloTaxaEfetiva","type":"decimal"},{"av":"Z1014ConfiguracoesCompraTituloTaxaMora","type":"decimal"},{"av":"Z1036ConfiguracoesCompraTituloFator","type":"decimal"},{"av":"Z1037ConfiguracoesCompraTituloTarifaTipo","type":"svchar"},{"av":"Z1038ConfiguracoesCompraTituloTarifa","type":"decimal"},{"av":"Z312ConfiguracoesImagemLoginExtencao","type":"svchar"},{"av":"Z313ConfiguracoesImagemLoginNome","type":"svchar"},{"av":"Z398ConfiguracoesLayoutProposta","type":"int"},{"av":"Z418ConfiguracoesLayoutContratoCorpo","type":"vchar"},{"av":"Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo","type":"vchar"},{"av":"Z568ConfigLayoutCorpoPromissoriaClinicaTaxa","type":"vchar"},{"av":"Z569ConfigLayoutCorpoPromissoriaPaciente","type":"vchar"},{"av":"Z922ConfigLayoutContratoCompraTitulo","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_CONFIGURACOESLAYOUTPROPOSTA","""{"handler":"Valid_Configuracoeslayoutproposta","iparms":[{"av":"A398ConfiguracoesLayoutProposta","fld":"CONFIGURACOESLAYOUTPROPOSTA","pic":"ZZZ9","nullAv":"n398ConfiguracoesLayoutProposta","type":"int"},{"av":"A418ConfiguracoesLayoutContratoCorpo","fld":"CONFIGURACOESLAYOUTCONTRATOCORPO","type":"vchar"}]""");
         setEventMetadata("VALID_CONFIGURACOESLAYOUTPROPOSTA",""","oparms":[{"av":"A398ConfiguracoesLayoutProposta","fld":"CONFIGURACOESLAYOUTPROPOSTA","pic":"ZZZ9","nullAv":"n398ConfiguracoesLayoutProposta","type":"int"},{"av":"A418ConfiguracoesLayoutContratoCorpo","fld":"CONFIGURACOESLAYOUTCONTRATOCORPO","type":"vchar"}]}""");
         setEventMetadata("VALID_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO","""{"handler":"Valid_Configlayoutpromissoriaclinicaemprestimo","iparms":[{"av":"A564ConfigLayoutPromissoriaClinicaEmprestimo","fld":"CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO","pic":"ZZZ9","nullAv":"n564ConfigLayoutPromissoriaClinicaEmprestimo","type":"int"},{"av":"A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo","fld":"CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO","type":"vchar"}]""");
         setEventMetadata("VALID_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO",""","oparms":[{"av":"A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo","fld":"CONFIGLAYOUTCORPOPROMISSORIACLINICAEMPRESTIMO","type":"vchar"}]}""");
         setEventMetadata("VALID_CONFIGLAYOUTPROMISSORIACLINICATAXA","""{"handler":"Valid_Configlayoutpromissoriaclinicataxa","iparms":[{"av":"A565ConfigLayoutPromissoriaClinicaTaxa","fld":"CONFIGLAYOUTPROMISSORIACLINICATAXA","pic":"ZZZ9","nullAv":"n565ConfigLayoutPromissoriaClinicaTaxa","type":"int"},{"av":"A568ConfigLayoutCorpoPromissoriaClinicaTaxa","fld":"CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA","type":"vchar"}]""");
         setEventMetadata("VALID_CONFIGLAYOUTPROMISSORIACLINICATAXA",""","oparms":[{"av":"A568ConfigLayoutCorpoPromissoriaClinicaTaxa","fld":"CONFIGLAYOUTCORPOPROMISSORIACLINICATAXA","type":"vchar"}]}""");
         setEventMetadata("VALID_CONFIGLAYOUTPROMISSORIAPACIENTE","""{"handler":"Valid_Configlayoutpromissoriapaciente","iparms":[{"av":"A566ConfigLayoutPromissoriaPaciente","fld":"CONFIGLAYOUTPROMISSORIAPACIENTE","pic":"ZZZ9","nullAv":"n566ConfigLayoutPromissoriaPaciente","type":"int"},{"av":"A569ConfigLayoutCorpoPromissoriaPaciente","fld":"CONFIGLAYOUTCORPOPROMISSORIAPACIENTE","type":"vchar"}]""");
         setEventMetadata("VALID_CONFIGLAYOUTPROMISSORIAPACIENTE",""","oparms":[{"av":"A569ConfigLayoutCorpoPromissoriaPaciente","fld":"CONFIGLAYOUTCORPOPROMISSORIAPACIENTE","type":"vchar"}]}""");
         setEventMetadata("VALID_CONFIGLAYOUTCONTRATOCOMPRATITULO","""{"handler":"Valid_Configlayoutcontratocompratitulo","iparms":[{"av":"A922ConfigLayoutContratoCompraTitulo","fld":"CONFIGLAYOUTCONTRATOCOMPRATITULO","pic":"ZZZ9","nullAv":"n922ConfigLayoutContratoCompraTitulo","type":"int"}]""");
         setEventMetadata("VALID_CONFIGLAYOUTCONTRATOCOMPRATITULO",""","oparms":[{"av":"A922ConfigLayoutContratoCompraTitulo","fld":"CONFIGLAYOUTCONTRATOCOMPRATITULO","pic":"ZZZ9","nullAv":"n922ConfigLayoutContratoCompraTitulo","type":"int"}]}""");
         setEventMetadata("VALID_CONFIGURACOESCATEGORIATITULO","""{"handler":"Valid_Configuracoescategoriatitulo","iparms":[{"av":"A654ConfiguracoesCategoriaTitulo","fld":"CONFIGURACOESCATEGORIATITULO","pic":"ZZZZZZZZ9","nullAv":"n654ConfiguracoesCategoriaTitulo","type":"int"}]}""");
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
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(28);
         pr_default.close(30);
         pr_default.close(31);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z315ConfiguracoesImagemLoginNomeInteiro = "";
         Z317ConfiguracoesImagemLoginBackground = "";
         Z319ConfiguracoesImagemHeaderNome = "";
         Z320ConfiguracoesImagemHeaderExtencao = "";
         Z321ConfiguracoesImagemHeaderNomeInteiro = "";
         Z563ConfiguracaoSenhaPFX = "";
         Z1037ConfiguracoesCompraTituloTarifaTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1037ConfiguracoesCompraTituloTarifaTipo = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A313ConfiguracoesImagemLoginNome = "";
         A312ConfiguracoesImagemLoginExtencao = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A300ConfiguracoesImagemLogin = "";
         A315ConfiguracoesImagemLoginNomeInteiro = "";
         A317ConfiguracoesImagemLoginBackground = "";
         A318ConfiguracoesImagemHeader = "";
         A319ConfiguracoesImagemHeaderNome = "";
         A320ConfiguracoesImagemHeaderExtencao = "";
         A321ConfiguracoesImagemHeaderNomeInteiro = "";
         ucConfiguracoeslayoutcontratocorpo = new GXUserControl();
         ConfiguracoesLayoutContratoCorpo = "";
         ucConfiglayoutcorpopromissoriaclinicaemprestimo = new GXUserControl();
         ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         ucConfiglayoutcorpopromissoriaclinicataxa = new GXUserControl();
         ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         ucConfiglayoutcorpopromissoriapaciente = new GXUserControl();
         ConfigLayoutCorpoPromissoriaPaciente = "";
         A562ConfiguracoesArquivoPFX = "";
         A563ConfiguracaoSenhaPFX = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         A418ConfiguracoesLayoutContratoCorpo = "";
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         A569ConfigLayoutCorpoPromissoriaPaciente = "";
         Configuracoeslayoutcontratocorpo_Objectcall = "";
         Configuracoeslayoutcontratocorpo_Class = "";
         Configuracoeslayoutcontratocorpo_Width = "";
         Configuracoeslayoutcontratocorpo_Height = "";
         Configuracoeslayoutcontratocorpo_Skin = "";
         Configuracoeslayoutcontratocorpo_Toolbar = "";
         Configuracoeslayoutcontratocorpo_Customtoolbar = "";
         Configuracoeslayoutcontratocorpo_Customconfiguration = "";
         Configuracoeslayoutcontratocorpo_Buttonpressedid = "";
         Configuracoeslayoutcontratocorpo_Captionvalue = "";
         Configuracoeslayoutcontratocorpo_Coltitle = "";
         Configuracoeslayoutcontratocorpo_Coltitlefont = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Objectcall = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Class = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Width = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Height = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Skin = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Toolbar = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Customtoolbar = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Customconfiguration = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Buttonpressedid = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Captionvalue = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Coltitle = "";
         Configlayoutcorpopromissoriaclinicaemprestimo_Coltitlefont = "";
         Configlayoutcorpopromissoriaclinicataxa_Objectcall = "";
         Configlayoutcorpopromissoriaclinicataxa_Class = "";
         Configlayoutcorpopromissoriaclinicataxa_Width = "";
         Configlayoutcorpopromissoriaclinicataxa_Height = "";
         Configlayoutcorpopromissoriaclinicataxa_Skin = "";
         Configlayoutcorpopromissoriaclinicataxa_Toolbar = "";
         Configlayoutcorpopromissoriaclinicataxa_Customtoolbar = "";
         Configlayoutcorpopromissoriaclinicataxa_Customconfiguration = "";
         Configlayoutcorpopromissoriaclinicataxa_Buttonpressedid = "";
         Configlayoutcorpopromissoriaclinicataxa_Captionvalue = "";
         Configlayoutcorpopromissoriaclinicataxa_Coltitle = "";
         Configlayoutcorpopromissoriaclinicataxa_Coltitlefont = "";
         Configlayoutcorpopromissoriapaciente_Objectcall = "";
         Configlayoutcorpopromissoriapaciente_Class = "";
         Configlayoutcorpopromissoriapaciente_Width = "";
         Configlayoutcorpopromissoriapaciente_Height = "";
         Configlayoutcorpopromissoriapaciente_Skin = "";
         Configlayoutcorpopromissoriapaciente_Toolbar = "";
         Configlayoutcorpopromissoriapaciente_Customtoolbar = "";
         Configlayoutcorpopromissoriapaciente_Customconfiguration = "";
         Configlayoutcorpopromissoriapaciente_Buttonpressedid = "";
         Configlayoutcorpopromissoriapaciente_Captionvalue = "";
         Configlayoutcorpopromissoriapaciente_Coltitle = "";
         Configlayoutcorpopromissoriapaciente_Coltitlefont = "";
         GXCCtlgxBlob = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z300ConfiguracoesImagemLogin = "";
         Z318ConfiguracoesImagemHeader = "";
         Z562ConfiguracoesArquivoPFX = "";
         Z312ConfiguracoesImagemLoginExtencao = "";
         Z313ConfiguracoesImagemLoginNome = "";
         Z418ConfiguracoesLayoutContratoCorpo = "";
         Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         Z568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         Z569ConfigLayoutCorpoPromissoriaPaciente = "";
         T001910_A299ConfiguracoesId = new int[1] ;
         T001910_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         T001910_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         T001910_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         T001910_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         T001910_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         T001910_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         T001910_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         T001910_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         T001910_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         T001910_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         T001910_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         T001910_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         T001910_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         T001910_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         T001910_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         T001910_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         T001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         T001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         T001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         T001910_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         T001910_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         T001910_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         T001910_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         T001910_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         T001910_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         T001910_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         T001910_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         T001910_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         T001910_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         T001910_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         T001910_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         T001910_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         T001910_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         T001910_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         T001910_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         T001910_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         T001910_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         T001910_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         T001910_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         T001910_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         T001910_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         T001910_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         T001910_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         T001910_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         T001910_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         T001910_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         T001910_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         T001910_A398ConfiguracoesLayoutProposta = new short[1] ;
         T001910_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         T001910_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         T001910_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T001910_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         T001910_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         T001910_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         T001910_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         T001910_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         T001910_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         T001910_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         T001910_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         T001910_A300ConfiguracoesImagemLogin = new string[] {""} ;
         T001910_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         T001910_A318ConfiguracoesImagemHeader = new string[] {""} ;
         T001910_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         T001910_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         T001910_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         T00194_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         T00194_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         T00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         T00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         T00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         T00197_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         T00197_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         T00198_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         T00198_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         T00199_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         T00199_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         T001911_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         T001911_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         T001912_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         T001912_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T001913_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         T001913_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         T001914_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         T001914_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         T001915_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         T001915_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         T001916_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         T001916_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         T001917_A299ConfiguracoesId = new int[1] ;
         T00193_A299ConfiguracoesId = new int[1] ;
         T00193_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         T00193_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         T00193_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         T00193_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         T00193_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         T00193_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         T00193_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         T00193_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         T00193_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         T00193_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         T00193_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         T00193_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         T00193_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         T00193_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         T00193_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         T00193_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         T00193_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         T00193_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         T00193_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         T00193_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         T00193_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         T00193_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         T00193_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         T00193_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         T00193_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         T00193_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         T00193_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         T00193_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         T00193_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         T00193_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         T00193_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         T00193_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         T00193_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         T00193_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         T00193_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         T00193_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         T00193_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         T00193_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         T00193_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         T00193_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         T00193_A398ConfiguracoesLayoutProposta = new short[1] ;
         T00193_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         T00193_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         T00193_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T00193_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         T00193_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         T00193_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         T00193_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         T00193_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         T00193_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         T00193_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         T00193_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         T00193_A300ConfiguracoesImagemLogin = new string[] {""} ;
         T00193_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         T00193_A318ConfiguracoesImagemHeader = new string[] {""} ;
         T00193_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         T00193_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         T00193_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         sMode48 = "";
         T001918_A299ConfiguracoesId = new int[1] ;
         T001919_A299ConfiguracoesId = new int[1] ;
         T00192_A299ConfiguracoesId = new int[1] ;
         T00192_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         T00192_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         T00192_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         T00192_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         T00192_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         T00192_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         T00192_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         T00192_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         T00192_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         T00192_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         T00192_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         T00192_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         T00192_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         T00192_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         T00192_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         T00192_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         T00192_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         T00192_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         T00192_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         T00192_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         T00192_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         T00192_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         T00192_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         T00192_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         T00192_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         T00192_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         T00192_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         T00192_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         T00192_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         T00192_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         T00192_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         T00192_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         T00192_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         T00192_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         T00192_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         T00192_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         T00192_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         T00192_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         T00192_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         T00192_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         T00192_A398ConfiguracoesLayoutProposta = new short[1] ;
         T00192_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         T00192_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         T00192_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T00192_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         T00192_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         T00192_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         T00192_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         T00192_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         T00192_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         T00192_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         T00192_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         T00192_A300ConfiguracoesImagemLogin = new string[] {""} ;
         T00192_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         T00192_A318ConfiguracoesImagemHeader = new string[] {""} ;
         T00192_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         T00192_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         T00192_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         T001921_A299ConfiguracoesId = new int[1] ;
         T001927_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         T001927_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         T001928_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         T001928_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         T001929_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         T001929_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         T001930_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         T001930_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         T001931_A299ConfiguracoesId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ300ConfiguracoesImagemLogin = "";
         ZZ315ConfiguracoesImagemLoginNomeInteiro = "";
         ZZ317ConfiguracoesImagemLoginBackground = "";
         ZZ318ConfiguracoesImagemHeader = "";
         ZZ319ConfiguracoesImagemHeaderNome = "";
         ZZ320ConfiguracoesImagemHeaderExtencao = "";
         ZZ321ConfiguracoesImagemHeaderNomeInteiro = "";
         ZZ562ConfiguracoesArquivoPFX = "";
         ZZ563ConfiguracaoSenhaPFX = "";
         ZZ1037ConfiguracoesCompraTituloTarifaTipo = "";
         ZZ312ConfiguracoesImagemLoginExtencao = "";
         ZZ313ConfiguracoesImagemLoginNome = "";
         ZZ418ConfiguracoesLayoutContratoCorpo = "";
         ZZ567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         ZZ568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         ZZ569ConfigLayoutCorpoPromissoriaPaciente = "";
         T001932_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         T001932_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         T001933_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         T001933_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracoes__default(),
            new Object[][] {
                new Object[] {
               T00192_A299ConfiguracoesId, T00192_A315ConfiguracoesImagemLoginNomeInteiro, T00192_n315ConfiguracoesImagemLoginNomeInteiro, T00192_A316ConfiguracoesImagemLoginTamanho, T00192_n316ConfiguracoesImagemLoginTamanho, T00192_A317ConfiguracoesImagemLoginBackground, T00192_n317ConfiguracoesImagemLoginBackground, T00192_A319ConfiguracoesImagemHeaderNome, T00192_n319ConfiguracoesImagemHeaderNome, T00192_A320ConfiguracoesImagemHeaderExtencao,
               T00192_n320ConfiguracoesImagemHeaderExtencao, T00192_A321ConfiguracoesImagemHeaderNomeInteiro, T00192_n321ConfiguracoesImagemHeaderNomeInteiro, T00192_A322ConfiguracoesImagemHeaderTamanho, T00192_n322ConfiguracoesImagemHeaderTamanho, T00192_A563ConfiguracaoSenhaPFX, T00192_n563ConfiguracaoSenhaPFX, T00192_A765ConfiguracoesSerasaAnotacoesCompletas, T00192_n765ConfiguracoesSerasaAnotacoesCompletas, T00192_A766ConfiguracoesSerasaConsultaDetalhada,
               T00192_n766ConfiguracoesSerasaConsultaDetalhada, T00192_A767ConfiguracoesSerasaParticipacaoSocietaria, T00192_n767ConfiguracoesSerasaParticipacaoSocietaria, T00192_A768ConfiguracoesSerasaRendaEstimada, T00192_n768ConfiguracoesSerasaRendaEstimada, T00192_A769ConfiguracoesSerasaHistoricoPagamento, T00192_n769ConfiguracoesSerasaHistoricoPagamento, T00192_A1013ConfiguracoesCompraTituloTaxaEfetiva, T00192_n1013ConfiguracoesCompraTituloTaxaEfetiva, T00192_A1014ConfiguracoesCompraTituloTaxaMora,
               T00192_n1014ConfiguracoesCompraTituloTaxaMora, T00192_A1036ConfiguracoesCompraTituloFator, T00192_n1036ConfiguracoesCompraTituloFator, T00192_A1037ConfiguracoesCompraTituloTarifaTipo, T00192_n1037ConfiguracoesCompraTituloTarifaTipo, T00192_A1038ConfiguracoesCompraTituloTarifa, T00192_n1038ConfiguracoesCompraTituloTarifa, T00192_A312ConfiguracoesImagemLoginExtencao, T00192_n312ConfiguracoesImagemLoginExtencao, T00192_A313ConfiguracoesImagemLoginNome,
               T00192_n313ConfiguracoesImagemLoginNome, T00192_A398ConfiguracoesLayoutProposta, T00192_n398ConfiguracoesLayoutProposta, T00192_A564ConfigLayoutPromissoriaClinicaEmprestimo, T00192_n564ConfigLayoutPromissoriaClinicaEmprestimo, T00192_A565ConfigLayoutPromissoriaClinicaTaxa, T00192_n565ConfigLayoutPromissoriaClinicaTaxa, T00192_A566ConfigLayoutPromissoriaPaciente, T00192_n566ConfigLayoutPromissoriaPaciente, T00192_A922ConfigLayoutContratoCompraTitulo,
               T00192_n922ConfigLayoutContratoCompraTitulo, T00192_A654ConfiguracoesCategoriaTitulo, T00192_n654ConfiguracoesCategoriaTitulo, T00192_A300ConfiguracoesImagemLogin, T00192_n300ConfiguracoesImagemLogin, T00192_A318ConfiguracoesImagemHeader, T00192_n318ConfiguracoesImagemHeader, T00192_A562ConfiguracoesArquivoPFX, T00192_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               T00193_A299ConfiguracoesId, T00193_A315ConfiguracoesImagemLoginNomeInteiro, T00193_n315ConfiguracoesImagemLoginNomeInteiro, T00193_A316ConfiguracoesImagemLoginTamanho, T00193_n316ConfiguracoesImagemLoginTamanho, T00193_A317ConfiguracoesImagemLoginBackground, T00193_n317ConfiguracoesImagemLoginBackground, T00193_A319ConfiguracoesImagemHeaderNome, T00193_n319ConfiguracoesImagemHeaderNome, T00193_A320ConfiguracoesImagemHeaderExtencao,
               T00193_n320ConfiguracoesImagemHeaderExtencao, T00193_A321ConfiguracoesImagemHeaderNomeInteiro, T00193_n321ConfiguracoesImagemHeaderNomeInteiro, T00193_A322ConfiguracoesImagemHeaderTamanho, T00193_n322ConfiguracoesImagemHeaderTamanho, T00193_A563ConfiguracaoSenhaPFX, T00193_n563ConfiguracaoSenhaPFX, T00193_A765ConfiguracoesSerasaAnotacoesCompletas, T00193_n765ConfiguracoesSerasaAnotacoesCompletas, T00193_A766ConfiguracoesSerasaConsultaDetalhada,
               T00193_n766ConfiguracoesSerasaConsultaDetalhada, T00193_A767ConfiguracoesSerasaParticipacaoSocietaria, T00193_n767ConfiguracoesSerasaParticipacaoSocietaria, T00193_A768ConfiguracoesSerasaRendaEstimada, T00193_n768ConfiguracoesSerasaRendaEstimada, T00193_A769ConfiguracoesSerasaHistoricoPagamento, T00193_n769ConfiguracoesSerasaHistoricoPagamento, T00193_A1013ConfiguracoesCompraTituloTaxaEfetiva, T00193_n1013ConfiguracoesCompraTituloTaxaEfetiva, T00193_A1014ConfiguracoesCompraTituloTaxaMora,
               T00193_n1014ConfiguracoesCompraTituloTaxaMora, T00193_A1036ConfiguracoesCompraTituloFator, T00193_n1036ConfiguracoesCompraTituloFator, T00193_A1037ConfiguracoesCompraTituloTarifaTipo, T00193_n1037ConfiguracoesCompraTituloTarifaTipo, T00193_A1038ConfiguracoesCompraTituloTarifa, T00193_n1038ConfiguracoesCompraTituloTarifa, T00193_A312ConfiguracoesImagemLoginExtencao, T00193_n312ConfiguracoesImagemLoginExtencao, T00193_A313ConfiguracoesImagemLoginNome,
               T00193_n313ConfiguracoesImagemLoginNome, T00193_A398ConfiguracoesLayoutProposta, T00193_n398ConfiguracoesLayoutProposta, T00193_A564ConfigLayoutPromissoriaClinicaEmprestimo, T00193_n564ConfigLayoutPromissoriaClinicaEmprestimo, T00193_A565ConfigLayoutPromissoriaClinicaTaxa, T00193_n565ConfigLayoutPromissoriaClinicaTaxa, T00193_A566ConfigLayoutPromissoriaPaciente, T00193_n566ConfigLayoutPromissoriaPaciente, T00193_A922ConfigLayoutContratoCompraTitulo,
               T00193_n922ConfigLayoutContratoCompraTitulo, T00193_A654ConfiguracoesCategoriaTitulo, T00193_n654ConfiguracoesCategoriaTitulo, T00193_A300ConfiguracoesImagemLogin, T00193_n300ConfiguracoesImagemLogin, T00193_A318ConfiguracoesImagemHeader, T00193_n318ConfiguracoesImagemHeader, T00193_A562ConfiguracoesArquivoPFX, T00193_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               T00194_A418ConfiguracoesLayoutContratoCorpo, T00194_n418ConfiguracoesLayoutContratoCorpo
               }
               , new Object[] {
               T00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo
               }
               , new Object[] {
               T00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, T00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               T00197_A569ConfigLayoutCorpoPromissoriaPaciente, T00197_n569ConfigLayoutCorpoPromissoriaPaciente
               }
               , new Object[] {
               T00198_A922ConfigLayoutContratoCompraTitulo
               }
               , new Object[] {
               T00199_A654ConfiguracoesCategoriaTitulo
               }
               , new Object[] {
               T001910_A299ConfiguracoesId, T001910_A315ConfiguracoesImagemLoginNomeInteiro, T001910_n315ConfiguracoesImagemLoginNomeInteiro, T001910_A316ConfiguracoesImagemLoginTamanho, T001910_n316ConfiguracoesImagemLoginTamanho, T001910_A317ConfiguracoesImagemLoginBackground, T001910_n317ConfiguracoesImagemLoginBackground, T001910_A319ConfiguracoesImagemHeaderNome, T001910_n319ConfiguracoesImagemHeaderNome, T001910_A320ConfiguracoesImagemHeaderExtencao,
               T001910_n320ConfiguracoesImagemHeaderExtencao, T001910_A321ConfiguracoesImagemHeaderNomeInteiro, T001910_n321ConfiguracoesImagemHeaderNomeInteiro, T001910_A322ConfiguracoesImagemHeaderTamanho, T001910_n322ConfiguracoesImagemHeaderTamanho, T001910_A418ConfiguracoesLayoutContratoCorpo, T001910_n418ConfiguracoesLayoutContratoCorpo, T001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa,
               T001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa, T001910_A569ConfigLayoutCorpoPromissoriaPaciente, T001910_n569ConfigLayoutCorpoPromissoriaPaciente, T001910_A563ConfiguracaoSenhaPFX, T001910_n563ConfiguracaoSenhaPFX, T001910_A765ConfiguracoesSerasaAnotacoesCompletas, T001910_n765ConfiguracoesSerasaAnotacoesCompletas, T001910_A766ConfiguracoesSerasaConsultaDetalhada, T001910_n766ConfiguracoesSerasaConsultaDetalhada, T001910_A767ConfiguracoesSerasaParticipacaoSocietaria,
               T001910_n767ConfiguracoesSerasaParticipacaoSocietaria, T001910_A768ConfiguracoesSerasaRendaEstimada, T001910_n768ConfiguracoesSerasaRendaEstimada, T001910_A769ConfiguracoesSerasaHistoricoPagamento, T001910_n769ConfiguracoesSerasaHistoricoPagamento, T001910_A1013ConfiguracoesCompraTituloTaxaEfetiva, T001910_n1013ConfiguracoesCompraTituloTaxaEfetiva, T001910_A1014ConfiguracoesCompraTituloTaxaMora, T001910_n1014ConfiguracoesCompraTituloTaxaMora, T001910_A1036ConfiguracoesCompraTituloFator,
               T001910_n1036ConfiguracoesCompraTituloFator, T001910_A1037ConfiguracoesCompraTituloTarifaTipo, T001910_n1037ConfiguracoesCompraTituloTarifaTipo, T001910_A1038ConfiguracoesCompraTituloTarifa, T001910_n1038ConfiguracoesCompraTituloTarifa, T001910_A312ConfiguracoesImagemLoginExtencao, T001910_n312ConfiguracoesImagemLoginExtencao, T001910_A313ConfiguracoesImagemLoginNome, T001910_n313ConfiguracoesImagemLoginNome, T001910_A398ConfiguracoesLayoutProposta,
               T001910_n398ConfiguracoesLayoutProposta, T001910_A564ConfigLayoutPromissoriaClinicaEmprestimo, T001910_n564ConfigLayoutPromissoriaClinicaEmprestimo, T001910_A565ConfigLayoutPromissoriaClinicaTaxa, T001910_n565ConfigLayoutPromissoriaClinicaTaxa, T001910_A566ConfigLayoutPromissoriaPaciente, T001910_n566ConfigLayoutPromissoriaPaciente, T001910_A922ConfigLayoutContratoCompraTitulo, T001910_n922ConfigLayoutContratoCompraTitulo, T001910_A654ConfiguracoesCategoriaTitulo,
               T001910_n654ConfiguracoesCategoriaTitulo, T001910_A300ConfiguracoesImagemLogin, T001910_n300ConfiguracoesImagemLogin, T001910_A318ConfiguracoesImagemHeader, T001910_n318ConfiguracoesImagemHeader, T001910_A562ConfiguracoesArquivoPFX, T001910_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               T001911_A418ConfiguracoesLayoutContratoCorpo, T001911_n418ConfiguracoesLayoutContratoCorpo
               }
               , new Object[] {
               T001912_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T001912_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo
               }
               , new Object[] {
               T001913_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, T001913_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               T001914_A569ConfigLayoutCorpoPromissoriaPaciente, T001914_n569ConfigLayoutCorpoPromissoriaPaciente
               }
               , new Object[] {
               T001915_A922ConfigLayoutContratoCompraTitulo
               }
               , new Object[] {
               T001916_A654ConfiguracoesCategoriaTitulo
               }
               , new Object[] {
               T001917_A299ConfiguracoesId
               }
               , new Object[] {
               T001918_A299ConfiguracoesId
               }
               , new Object[] {
               T001919_A299ConfiguracoesId
               }
               , new Object[] {
               }
               , new Object[] {
               T001921_A299ConfiguracoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001927_A418ConfiguracoesLayoutContratoCorpo, T001927_n418ConfiguracoesLayoutContratoCorpo
               }
               , new Object[] {
               T001928_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T001928_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo
               }
               , new Object[] {
               T001929_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, T001929_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               T001930_A569ConfigLayoutCorpoPromissoriaPaciente, T001930_n569ConfigLayoutCorpoPromissoriaPaciente
               }
               , new Object[] {
               T001931_A299ConfiguracoesId
               }
               , new Object[] {
               T001932_A922ConfigLayoutContratoCompraTitulo
               }
               , new Object[] {
               T001933_A654ConfiguracoesCategoriaTitulo
               }
            }
         );
      }

      private short Z398ConfiguracoesLayoutProposta ;
      private short Z564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short Z565ConfigLayoutPromissoriaClinicaTaxa ;
      private short Z566ConfigLayoutPromissoriaPaciente ;
      private short Z922ConfigLayoutContratoCompraTitulo ;
      private short GxWebError ;
      private short A398ConfiguracoesLayoutProposta ;
      private short A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short A565ConfigLayoutPromissoriaClinicaTaxa ;
      private short A566ConfigLayoutPromissoriaPaciente ;
      private short A922ConfigLayoutContratoCompraTitulo ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound48 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short ZZ565ConfigLayoutPromissoriaClinicaTaxa ;
      private short ZZ566ConfigLayoutPromissoriaPaciente ;
      private short ZZ398ConfiguracoesLayoutProposta ;
      private short ZZ922ConfigLayoutContratoCompraTitulo ;
      private int Z299ConfiguracoesId ;
      private int Z654ConfiguracoesCategoriaTitulo ;
      private int A654ConfiguracoesCategoriaTitulo ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A299ConfiguracoesId ;
      private int edtConfiguracoesId_Enabled ;
      private int edtConfiguracoesImagemLogin_Enabled ;
      private int edtConfiguracoesImagemLoginNomeInteiro_Enabled ;
      private int edtConfiguracoesImagemLoginTamanho_Enabled ;
      private int edtConfiguracoesImagemLoginBackground_Enabled ;
      private int edtConfiguracoesImagemHeader_Enabled ;
      private int edtConfiguracoesImagemHeaderNome_Enabled ;
      private int edtConfiguracoesImagemHeaderExtencao_Enabled ;
      private int edtConfiguracoesImagemHeaderNomeInteiro_Enabled ;
      private int edtConfiguracoesImagemHeaderTamanho_Enabled ;
      private int edtConfiguracoesLayoutProposta_Enabled ;
      private int edtConfigLayoutPromissoriaClinicaEmprestimo_Enabled ;
      private int edtConfigLayoutPromissoriaClinicaTaxa_Enabled ;
      private int edtConfigLayoutPromissoriaPaciente_Enabled ;
      private int edtConfigLayoutContratoCompraTitulo_Enabled ;
      private int edtConfiguracoesArquivoPFX_Enabled ;
      private int edtConfiguracaoSenhaPFX_Enabled ;
      private int edtConfiguracoesCategoriaTitulo_Enabled ;
      private int edtConfiguracoesCompraTituloTaxaEfetiva_Enabled ;
      private int edtConfiguracoesCompraTituloTaxaMora_Enabled ;
      private int edtConfiguracoesCompraTituloFator_Enabled ;
      private int edtConfiguracoesCompraTituloTarifa_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Configuracoeslayoutcontratocorpo_Color ;
      private int Configuracoeslayoutcontratocorpo_Coltitlecolor ;
      private int Configlayoutcorpopromissoriaclinicaemprestimo_Color ;
      private int Configlayoutcorpopromissoriaclinicaemprestimo_Coltitlecolor ;
      private int Configlayoutcorpopromissoriaclinicataxa_Color ;
      private int Configlayoutcorpopromissoriaclinicataxa_Coltitlecolor ;
      private int Configlayoutcorpopromissoriapaciente_Color ;
      private int Configlayoutcorpopromissoriapaciente_Coltitlecolor ;
      private int idxLst ;
      private int ZZ299ConfiguracoesId ;
      private int ZZ654ConfiguracoesCategoriaTitulo ;
      private decimal Z316ConfiguracoesImagemLoginTamanho ;
      private decimal Z322ConfiguracoesImagemHeaderTamanho ;
      private decimal Z1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal Z1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal Z1036ConfiguracoesCompraTituloFator ;
      private decimal Z1038ConfiguracoesCompraTituloTarifa ;
      private decimal A316ConfiguracoesImagemLoginTamanho ;
      private decimal A322ConfiguracoesImagemHeaderTamanho ;
      private decimal A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal A1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal A1036ConfiguracoesCompraTituloFator ;
      private decimal A1038ConfiguracoesCompraTituloTarifa ;
      private decimal ZZ316ConfiguracoesImagemLoginTamanho ;
      private decimal ZZ322ConfiguracoesImagemHeaderTamanho ;
      private decimal ZZ1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal ZZ1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal ZZ1036ConfiguracoesCompraTituloFator ;
      private decimal ZZ1038ConfiguracoesCompraTituloTarifa ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConfiguracoesId_Internalname ;
      private string cmbConfiguracoesSerasaAnotacoesCompletas_Internalname ;
      private string cmbConfiguracoesSerasaConsultaDetalhada_Internalname ;
      private string cmbConfiguracoesSerasaParticipacaoSocietaria_Internalname ;
      private string cmbConfiguracoesSerasaRendaEstimada_Internalname ;
      private string cmbConfiguracoesSerasaHistoricoPagamento_Internalname ;
      private string cmbConfiguracoesCompraTituloTarifaTipo_Internalname ;
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
      private string edtConfiguracoesId_Jsonclick ;
      private string edtConfiguracoesImagemLogin_Internalname ;
      private string edtConfiguracoesImagemLogin_Filename ;
      private string edtConfiguracoesImagemLogin_Filetype ;
      private string edtConfiguracoesImagemLogin_Contenttype ;
      private string edtConfiguracoesImagemLogin_Parameters ;
      private string edtConfiguracoesImagemLogin_Jsonclick ;
      private string edtConfiguracoesImagemLoginNomeInteiro_Internalname ;
      private string edtConfiguracoesImagemLoginNomeInteiro_Jsonclick ;
      private string edtConfiguracoesImagemLoginTamanho_Internalname ;
      private string edtConfiguracoesImagemLoginTamanho_Jsonclick ;
      private string edtConfiguracoesImagemLoginBackground_Internalname ;
      private string edtConfiguracoesImagemLoginBackground_Jsonclick ;
      private string edtConfiguracoesImagemHeader_Internalname ;
      private string edtConfiguracoesImagemHeader_Filetype ;
      private string edtConfiguracoesImagemHeader_Contenttype ;
      private string edtConfiguracoesImagemHeader_Parameters ;
      private string edtConfiguracoesImagemHeader_Jsonclick ;
      private string edtConfiguracoesImagemHeaderNome_Internalname ;
      private string edtConfiguracoesImagemHeaderNome_Jsonclick ;
      private string edtConfiguracoesImagemHeaderExtencao_Internalname ;
      private string edtConfiguracoesImagemHeaderExtencao_Jsonclick ;
      private string edtConfiguracoesImagemHeaderNomeInteiro_Internalname ;
      private string edtConfiguracoesImagemHeaderNomeInteiro_Jsonclick ;
      private string edtConfiguracoesImagemHeaderTamanho_Internalname ;
      private string edtConfiguracoesImagemHeaderTamanho_Jsonclick ;
      private string edtConfiguracoesLayoutProposta_Internalname ;
      private string edtConfiguracoesLayoutProposta_Jsonclick ;
      private string Configuracoeslayoutcontratocorpo_Internalname ;
      private string Configuracoeslayoutcontratocorpo_Captionclass ;
      private string Configuracoeslayoutcontratocorpo_Captionstyle ;
      private string Configuracoeslayoutcontratocorpo_Captionposition ;
      private string edtConfigLayoutPromissoriaClinicaEmprestimo_Internalname ;
      private string edtConfigLayoutPromissoriaClinicaEmprestimo_Jsonclick ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Internalname ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Captionclass ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Captionstyle ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Captionposition ;
      private string edtConfigLayoutPromissoriaClinicaTaxa_Internalname ;
      private string edtConfigLayoutPromissoriaClinicaTaxa_Jsonclick ;
      private string Configlayoutcorpopromissoriaclinicataxa_Internalname ;
      private string Configlayoutcorpopromissoriaclinicataxa_Captionclass ;
      private string Configlayoutcorpopromissoriaclinicataxa_Captionstyle ;
      private string Configlayoutcorpopromissoriaclinicataxa_Captionposition ;
      private string edtConfigLayoutPromissoriaPaciente_Internalname ;
      private string edtConfigLayoutPromissoriaPaciente_Jsonclick ;
      private string edtConfigLayoutContratoCompraTitulo_Internalname ;
      private string edtConfigLayoutContratoCompraTitulo_Jsonclick ;
      private string Configlayoutcorpopromissoriapaciente_Internalname ;
      private string Configlayoutcorpopromissoriapaciente_Captionclass ;
      private string Configlayoutcorpopromissoriapaciente_Captionstyle ;
      private string Configlayoutcorpopromissoriapaciente_Captionposition ;
      private string edtConfiguracoesArquivoPFX_Internalname ;
      private string edtConfiguracoesArquivoPFX_Filetype ;
      private string edtConfiguracoesArquivoPFX_Contenttype ;
      private string edtConfiguracoesArquivoPFX_Parameters ;
      private string edtConfiguracoesArquivoPFX_Jsonclick ;
      private string edtConfiguracaoSenhaPFX_Internalname ;
      private string edtConfiguracaoSenhaPFX_Jsonclick ;
      private string edtConfiguracoesCategoriaTitulo_Internalname ;
      private string edtConfiguracoesCategoriaTitulo_Jsonclick ;
      private string cmbConfiguracoesSerasaAnotacoesCompletas_Jsonclick ;
      private string cmbConfiguracoesSerasaConsultaDetalhada_Jsonclick ;
      private string cmbConfiguracoesSerasaParticipacaoSocietaria_Jsonclick ;
      private string cmbConfiguracoesSerasaRendaEstimada_Jsonclick ;
      private string cmbConfiguracoesSerasaHistoricoPagamento_Jsonclick ;
      private string edtConfiguracoesCompraTituloTaxaEfetiva_Internalname ;
      private string edtConfiguracoesCompraTituloTaxaEfetiva_Jsonclick ;
      private string edtConfiguracoesCompraTituloTaxaMora_Internalname ;
      private string edtConfiguracoesCompraTituloTaxaMora_Jsonclick ;
      private string edtConfiguracoesCompraTituloFator_Internalname ;
      private string edtConfiguracoesCompraTituloFator_Jsonclick ;
      private string cmbConfiguracoesCompraTituloTarifaTipo_Jsonclick ;
      private string edtConfiguracoesCompraTituloTarifa_Internalname ;
      private string edtConfiguracoesCompraTituloTarifa_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string Configuracoeslayoutcontratocorpo_Objectcall ;
      private string Configuracoeslayoutcontratocorpo_Class ;
      private string Configuracoeslayoutcontratocorpo_Width ;
      private string Configuracoeslayoutcontratocorpo_Height ;
      private string Configuracoeslayoutcontratocorpo_Skin ;
      private string Configuracoeslayoutcontratocorpo_Toolbar ;
      private string Configuracoeslayoutcontratocorpo_Customtoolbar ;
      private string Configuracoeslayoutcontratocorpo_Customconfiguration ;
      private string Configuracoeslayoutcontratocorpo_Buttonpressedid ;
      private string Configuracoeslayoutcontratocorpo_Captionvalue ;
      private string Configuracoeslayoutcontratocorpo_Coltitle ;
      private string Configuracoeslayoutcontratocorpo_Coltitlefont ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Objectcall ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Class ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Width ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Height ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Skin ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Toolbar ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Customtoolbar ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Customconfiguration ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Buttonpressedid ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Captionvalue ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Coltitle ;
      private string Configlayoutcorpopromissoriaclinicaemprestimo_Coltitlefont ;
      private string Configlayoutcorpopromissoriaclinicataxa_Objectcall ;
      private string Configlayoutcorpopromissoriaclinicataxa_Class ;
      private string Configlayoutcorpopromissoriaclinicataxa_Width ;
      private string Configlayoutcorpopromissoriaclinicataxa_Height ;
      private string Configlayoutcorpopromissoriaclinicataxa_Skin ;
      private string Configlayoutcorpopromissoriaclinicataxa_Toolbar ;
      private string Configlayoutcorpopromissoriaclinicataxa_Customtoolbar ;
      private string Configlayoutcorpopromissoriaclinicataxa_Customconfiguration ;
      private string Configlayoutcorpopromissoriaclinicataxa_Buttonpressedid ;
      private string Configlayoutcorpopromissoriaclinicataxa_Captionvalue ;
      private string Configlayoutcorpopromissoriaclinicataxa_Coltitle ;
      private string Configlayoutcorpopromissoriaclinicataxa_Coltitlefont ;
      private string Configlayoutcorpopromissoriapaciente_Objectcall ;
      private string Configlayoutcorpopromissoriapaciente_Class ;
      private string Configlayoutcorpopromissoriapaciente_Width ;
      private string Configlayoutcorpopromissoriapaciente_Height ;
      private string Configlayoutcorpopromissoriapaciente_Skin ;
      private string Configlayoutcorpopromissoriapaciente_Toolbar ;
      private string Configlayoutcorpopromissoriapaciente_Customtoolbar ;
      private string Configlayoutcorpopromissoriapaciente_Customconfiguration ;
      private string Configlayoutcorpopromissoriapaciente_Buttonpressedid ;
      private string Configlayoutcorpopromissoriapaciente_Captionvalue ;
      private string Configlayoutcorpopromissoriapaciente_Coltitle ;
      private string Configlayoutcorpopromissoriapaciente_Coltitlefont ;
      private string edtConfiguracoesImagemHeader_Filename ;
      private string edtConfiguracoesArquivoPFX_Filename ;
      private string GXCCtlgxBlob ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode48 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool Z766ConfiguracoesSerasaConsultaDetalhada ;
      private bool Z767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool Z768ConfiguracoesSerasaRendaEstimada ;
      private bool Z769ConfiguracoesSerasaHistoricoPagamento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n398ConfiguracoesLayoutProposta ;
      private bool n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool n565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool n566ConfigLayoutPromissoriaPaciente ;
      private bool n922ConfigLayoutContratoCompraTitulo ;
      private bool n654ConfiguracoesCategoriaTitulo ;
      private bool wbErr ;
      private bool A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool A768ConfiguracoesSerasaRendaEstimada ;
      private bool n768ConfiguracoesSerasaRendaEstimada ;
      private bool A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool n769ConfiguracoesSerasaHistoricoPagamento ;
      private bool n1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool n300ConfiguracoesImagemLogin ;
      private bool n316ConfiguracoesImagemLoginTamanho ;
      private bool n318ConfiguracoesImagemHeader ;
      private bool n322ConfiguracoesImagemHeaderTamanho ;
      private bool n562ConfiguracoesArquivoPFX ;
      private bool n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool n1014ConfiguracoesCompraTituloTaxaMora ;
      private bool n1036ConfiguracoesCompraTituloFator ;
      private bool n1038ConfiguracoesCompraTituloTarifa ;
      private bool n315ConfiguracoesImagemLoginNomeInteiro ;
      private bool n317ConfiguracoesImagemLoginBackground ;
      private bool n319ConfiguracoesImagemHeaderNome ;
      private bool n320ConfiguracoesImagemHeaderExtencao ;
      private bool n321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool n563ConfiguracaoSenhaPFX ;
      private bool n312ConfiguracoesImagemLoginExtencao ;
      private bool n313ConfiguracoesImagemLoginNome ;
      private bool n418ConfiguracoesLayoutContratoCorpo ;
      private bool n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool n569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool Configuracoeslayoutcontratocorpo_Enabled ;
      private bool Configuracoeslayoutcontratocorpo_Toolbarcancollapse ;
      private bool Configuracoeslayoutcontratocorpo_Toolbarexpanded ;
      private bool Configuracoeslayoutcontratocorpo_Isabstractlayoutcontrol ;
      private bool Configuracoeslayoutcontratocorpo_Usercontroliscolumn ;
      private bool Configuracoeslayoutcontratocorpo_Visible ;
      private bool Configlayoutcorpopromissoriaclinicaemprestimo_Enabled ;
      private bool Configlayoutcorpopromissoriaclinicaemprestimo_Toolbarcancollapse ;
      private bool Configlayoutcorpopromissoriaclinicaemprestimo_Toolbarexpanded ;
      private bool Configlayoutcorpopromissoriaclinicaemprestimo_Isabstractlayoutcontrol ;
      private bool Configlayoutcorpopromissoriaclinicaemprestimo_Usercontroliscolumn ;
      private bool Configlayoutcorpopromissoriaclinicaemprestimo_Visible ;
      private bool Configlayoutcorpopromissoriaclinicataxa_Enabled ;
      private bool Configlayoutcorpopromissoriaclinicataxa_Toolbarcancollapse ;
      private bool Configlayoutcorpopromissoriaclinicataxa_Toolbarexpanded ;
      private bool Configlayoutcorpopromissoriaclinicataxa_Isabstractlayoutcontrol ;
      private bool Configlayoutcorpopromissoriaclinicataxa_Usercontroliscolumn ;
      private bool Configlayoutcorpopromissoriaclinicataxa_Visible ;
      private bool Configlayoutcorpopromissoriapaciente_Enabled ;
      private bool Configlayoutcorpopromissoriapaciente_Toolbarcancollapse ;
      private bool Configlayoutcorpopromissoriapaciente_Toolbarexpanded ;
      private bool Configlayoutcorpopromissoriapaciente_Isabstractlayoutcontrol ;
      private bool Configlayoutcorpopromissoriapaciente_Usercontroliscolumn ;
      private bool Configlayoutcorpopromissoriapaciente_Visible ;
      private bool Gx_longc ;
      private bool ZZ765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool ZZ766ConfiguracoesSerasaConsultaDetalhada ;
      private bool ZZ767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool ZZ768ConfiguracoesSerasaRendaEstimada ;
      private bool ZZ769ConfiguracoesSerasaHistoricoPagamento ;
      private string ConfiguracoesLayoutContratoCorpo ;
      private string ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string ConfigLayoutCorpoPromissoriaPaciente ;
      private string A418ConfiguracoesLayoutContratoCorpo ;
      private string A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string A569ConfigLayoutCorpoPromissoriaPaciente ;
      private string Z418ConfiguracoesLayoutContratoCorpo ;
      private string Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string Z568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string Z569ConfigLayoutCorpoPromissoriaPaciente ;
      private string ZZ418ConfiguracoesLayoutContratoCorpo ;
      private string ZZ567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string ZZ568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string ZZ569ConfigLayoutCorpoPromissoriaPaciente ;
      private string Z315ConfiguracoesImagemLoginNomeInteiro ;
      private string Z317ConfiguracoesImagemLoginBackground ;
      private string Z319ConfiguracoesImagemHeaderNome ;
      private string Z320ConfiguracoesImagemHeaderExtencao ;
      private string Z321ConfiguracoesImagemHeaderNomeInteiro ;
      private string Z563ConfiguracaoSenhaPFX ;
      private string Z1037ConfiguracoesCompraTituloTarifaTipo ;
      private string A1037ConfiguracoesCompraTituloTarifaTipo ;
      private string A313ConfiguracoesImagemLoginNome ;
      private string A312ConfiguracoesImagemLoginExtencao ;
      private string A315ConfiguracoesImagemLoginNomeInteiro ;
      private string A317ConfiguracoesImagemLoginBackground ;
      private string A319ConfiguracoesImagemHeaderNome ;
      private string A320ConfiguracoesImagemHeaderExtencao ;
      private string A321ConfiguracoesImagemHeaderNomeInteiro ;
      private string A563ConfiguracaoSenhaPFX ;
      private string Z312ConfiguracoesImagemLoginExtencao ;
      private string Z313ConfiguracoesImagemLoginNome ;
      private string ZZ315ConfiguracoesImagemLoginNomeInteiro ;
      private string ZZ317ConfiguracoesImagemLoginBackground ;
      private string ZZ319ConfiguracoesImagemHeaderNome ;
      private string ZZ320ConfiguracoesImagemHeaderExtencao ;
      private string ZZ321ConfiguracoesImagemHeaderNomeInteiro ;
      private string ZZ563ConfiguracaoSenhaPFX ;
      private string ZZ1037ConfiguracoesCompraTituloTarifaTipo ;
      private string ZZ312ConfiguracoesImagemLoginExtencao ;
      private string ZZ313ConfiguracoesImagemLoginNome ;
      private string A300ConfiguracoesImagemLogin ;
      private string A318ConfiguracoesImagemHeader ;
      private string A562ConfiguracoesArquivoPFX ;
      private string Z300ConfiguracoesImagemLogin ;
      private string Z318ConfiguracoesImagemHeader ;
      private string Z562ConfiguracoesArquivoPFX ;
      private string ZZ300ConfiguracoesImagemLogin ;
      private string ZZ318ConfiguracoesImagemHeader ;
      private string ZZ562ConfiguracoesArquivoPFX ;
      private GxFile gxblobfileaux ;
      private GXUserControl ucConfiguracoeslayoutcontratocorpo ;
      private GXUserControl ucConfiglayoutcorpopromissoriaclinicaemprestimo ;
      private GXUserControl ucConfiglayoutcorpopromissoriaclinicataxa ;
      private GXUserControl ucConfiglayoutcorpopromissoriapaciente ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConfiguracoesSerasaAnotacoesCompletas ;
      private GXCombobox cmbConfiguracoesSerasaConsultaDetalhada ;
      private GXCombobox cmbConfiguracoesSerasaParticipacaoSocietaria ;
      private GXCombobox cmbConfiguracoesSerasaRendaEstimada ;
      private GXCombobox cmbConfiguracoesSerasaHistoricoPagamento ;
      private GXCombobox cmbConfiguracoesCompraTituloTarifaTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T001910_A299ConfiguracoesId ;
      private string[] T001910_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] T001910_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] T001910_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] T001910_n316ConfiguracoesImagemLoginTamanho ;
      private string[] T001910_A317ConfiguracoesImagemLoginBackground ;
      private bool[] T001910_n317ConfiguracoesImagemLoginBackground ;
      private string[] T001910_A319ConfiguracoesImagemHeaderNome ;
      private bool[] T001910_n319ConfiguracoesImagemHeaderNome ;
      private string[] T001910_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] T001910_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] T001910_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] T001910_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] T001910_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] T001910_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] T001910_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] T001910_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] T001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] T001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] T001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] T001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] T001910_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] T001910_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private string[] T001910_A563ConfiguracaoSenhaPFX ;
      private bool[] T001910_n563ConfiguracaoSenhaPFX ;
      private bool[] T001910_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] T001910_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] T001910_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] T001910_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] T001910_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] T001910_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] T001910_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] T001910_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] T001910_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] T001910_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] T001910_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] T001910_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] T001910_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] T001910_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] T001910_A1036ConfiguracoesCompraTituloFator ;
      private bool[] T001910_n1036ConfiguracoesCompraTituloFator ;
      private string[] T001910_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] T001910_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] T001910_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] T001910_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] T001910_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] T001910_n312ConfiguracoesImagemLoginExtencao ;
      private string[] T001910_A313ConfiguracoesImagemLoginNome ;
      private bool[] T001910_n313ConfiguracoesImagemLoginNome ;
      private short[] T001910_A398ConfiguracoesLayoutProposta ;
      private bool[] T001910_n398ConfiguracoesLayoutProposta ;
      private short[] T001910_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] T001910_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] T001910_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] T001910_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] T001910_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] T001910_n566ConfigLayoutPromissoriaPaciente ;
      private short[] T001910_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] T001910_n922ConfigLayoutContratoCompraTitulo ;
      private int[] T001910_A654ConfiguracoesCategoriaTitulo ;
      private bool[] T001910_n654ConfiguracoesCategoriaTitulo ;
      private string[] T001910_A300ConfiguracoesImagemLogin ;
      private bool[] T001910_n300ConfiguracoesImagemLogin ;
      private string[] T001910_A318ConfiguracoesImagemHeader ;
      private bool[] T001910_n318ConfiguracoesImagemHeader ;
      private string[] T001910_A562ConfiguracoesArquivoPFX ;
      private bool[] T001910_n562ConfiguracoesArquivoPFX ;
      private string[] T00194_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] T00194_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] T00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] T00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] T00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] T00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] T00197_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] T00197_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private short[] T00198_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] T00198_n922ConfigLayoutContratoCompraTitulo ;
      private int[] T00199_A654ConfiguracoesCategoriaTitulo ;
      private bool[] T00199_n654ConfiguracoesCategoriaTitulo ;
      private string[] T001911_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] T001911_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] T001912_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] T001912_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] T001913_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] T001913_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] T001914_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] T001914_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private short[] T001915_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] T001915_n922ConfigLayoutContratoCompraTitulo ;
      private int[] T001916_A654ConfiguracoesCategoriaTitulo ;
      private bool[] T001916_n654ConfiguracoesCategoriaTitulo ;
      private int[] T001917_A299ConfiguracoesId ;
      private int[] T00193_A299ConfiguracoesId ;
      private string[] T00193_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] T00193_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] T00193_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] T00193_n316ConfiguracoesImagemLoginTamanho ;
      private string[] T00193_A317ConfiguracoesImagemLoginBackground ;
      private bool[] T00193_n317ConfiguracoesImagemLoginBackground ;
      private string[] T00193_A319ConfiguracoesImagemHeaderNome ;
      private bool[] T00193_n319ConfiguracoesImagemHeaderNome ;
      private string[] T00193_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] T00193_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] T00193_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] T00193_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] T00193_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] T00193_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] T00193_A563ConfiguracaoSenhaPFX ;
      private bool[] T00193_n563ConfiguracaoSenhaPFX ;
      private bool[] T00193_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] T00193_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] T00193_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] T00193_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] T00193_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] T00193_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] T00193_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] T00193_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] T00193_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] T00193_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] T00193_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] T00193_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] T00193_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] T00193_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] T00193_A1036ConfiguracoesCompraTituloFator ;
      private bool[] T00193_n1036ConfiguracoesCompraTituloFator ;
      private string[] T00193_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] T00193_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] T00193_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] T00193_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] T00193_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] T00193_n312ConfiguracoesImagemLoginExtencao ;
      private string[] T00193_A313ConfiguracoesImagemLoginNome ;
      private bool[] T00193_n313ConfiguracoesImagemLoginNome ;
      private short[] T00193_A398ConfiguracoesLayoutProposta ;
      private bool[] T00193_n398ConfiguracoesLayoutProposta ;
      private short[] T00193_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] T00193_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] T00193_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] T00193_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] T00193_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] T00193_n566ConfigLayoutPromissoriaPaciente ;
      private short[] T00193_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] T00193_n922ConfigLayoutContratoCompraTitulo ;
      private int[] T00193_A654ConfiguracoesCategoriaTitulo ;
      private bool[] T00193_n654ConfiguracoesCategoriaTitulo ;
      private string[] T00193_A300ConfiguracoesImagemLogin ;
      private bool[] T00193_n300ConfiguracoesImagemLogin ;
      private string[] T00193_A318ConfiguracoesImagemHeader ;
      private bool[] T00193_n318ConfiguracoesImagemHeader ;
      private string[] T00193_A562ConfiguracoesArquivoPFX ;
      private bool[] T00193_n562ConfiguracoesArquivoPFX ;
      private int[] T001918_A299ConfiguracoesId ;
      private int[] T001919_A299ConfiguracoesId ;
      private int[] T00192_A299ConfiguracoesId ;
      private string[] T00192_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] T00192_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] T00192_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] T00192_n316ConfiguracoesImagemLoginTamanho ;
      private string[] T00192_A317ConfiguracoesImagemLoginBackground ;
      private bool[] T00192_n317ConfiguracoesImagemLoginBackground ;
      private string[] T00192_A319ConfiguracoesImagemHeaderNome ;
      private bool[] T00192_n319ConfiguracoesImagemHeaderNome ;
      private string[] T00192_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] T00192_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] T00192_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] T00192_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] T00192_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] T00192_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] T00192_A563ConfiguracaoSenhaPFX ;
      private bool[] T00192_n563ConfiguracaoSenhaPFX ;
      private bool[] T00192_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] T00192_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] T00192_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] T00192_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] T00192_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] T00192_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] T00192_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] T00192_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] T00192_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] T00192_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] T00192_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] T00192_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] T00192_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] T00192_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] T00192_A1036ConfiguracoesCompraTituloFator ;
      private bool[] T00192_n1036ConfiguracoesCompraTituloFator ;
      private string[] T00192_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] T00192_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] T00192_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] T00192_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] T00192_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] T00192_n312ConfiguracoesImagemLoginExtencao ;
      private string[] T00192_A313ConfiguracoesImagemLoginNome ;
      private bool[] T00192_n313ConfiguracoesImagemLoginNome ;
      private short[] T00192_A398ConfiguracoesLayoutProposta ;
      private bool[] T00192_n398ConfiguracoesLayoutProposta ;
      private short[] T00192_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] T00192_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] T00192_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] T00192_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] T00192_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] T00192_n566ConfigLayoutPromissoriaPaciente ;
      private short[] T00192_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] T00192_n922ConfigLayoutContratoCompraTitulo ;
      private int[] T00192_A654ConfiguracoesCategoriaTitulo ;
      private bool[] T00192_n654ConfiguracoesCategoriaTitulo ;
      private string[] T00192_A300ConfiguracoesImagemLogin ;
      private bool[] T00192_n300ConfiguracoesImagemLogin ;
      private string[] T00192_A318ConfiguracoesImagemHeader ;
      private bool[] T00192_n318ConfiguracoesImagemHeader ;
      private string[] T00192_A562ConfiguracoesArquivoPFX ;
      private bool[] T00192_n562ConfiguracoesArquivoPFX ;
      private int[] T001921_A299ConfiguracoesId ;
      private string[] T001927_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] T001927_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] T001928_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] T001928_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] T001929_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] T001929_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] T001930_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] T001930_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private int[] T001931_A299ConfiguracoesId ;
      private short[] T001932_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] T001932_n922ConfigLayoutContratoCompraTitulo ;
      private int[] T001933_A654ConfiguracoesCategoriaTitulo ;
      private bool[] T001933_n654ConfiguracoesCategoriaTitulo ;
   }

   public class configuracoes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00192;
          prmT00192 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT00193;
          prmT00193 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT00194;
          prmT00194 = new Object[] {
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00195;
          prmT00195 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00196;
          prmT00196 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00197;
          prmT00197 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00198;
          prmT00198 = new Object[] {
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00199;
          prmT00199 = new Object[] {
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001910;
          prmT001910 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          string cmdBufferT001910;
          cmdBufferT001910=" SELECT TM1.ConfiguracoesId, TM1.ConfiguracoesImagemLoginNomeInteiro, TM1.ConfiguracoesImagemLoginTamanho, TM1.ConfiguracoesImagemLoginBackground, TM1.ConfiguracoesImagemHeaderNome, TM1.ConfiguracoesImagemHeaderExtencao, TM1.ConfiguracoesImagemHeaderNomeInteiro, TM1.ConfiguracoesImagemHeaderTamanho, T2.LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo, T3.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T4.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa, T5.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente, TM1.ConfiguracaoSenhaPFX, TM1.ConfiguracoesSerasaAnotacoesCompletas, TM1.ConfiguracoesSerasaConsultaDetalhada, TM1.ConfiguracoesSerasaParticipacaoSocietaria, TM1.ConfiguracoesSerasaRendaEstimada, TM1.ConfiguracoesSerasaHistoricoPagamento, TM1.ConfiguracoesCompraTituloTaxaEfetiva, TM1.ConfiguracoesCompraTituloTaxaMora, TM1.ConfiguracoesCompraTituloFator, TM1.ConfiguracoesCompraTituloTarifaTipo, TM1.ConfiguracoesCompraTituloTarifa, TM1.ConfiguracoesImagemLoginExtencao, TM1.ConfiguracoesImagemLoginNome, TM1.ConfiguracoesLayoutProposta AS ConfiguracoesLayoutProposta, TM1.ConfigLayoutPromissoriaClinicaEmprestimo AS ConfigLayoutPromissoriaClinicaEmprestimo, TM1.ConfigLayoutPromissoriaClinicaTaxa AS ConfigLayoutPromissoriaClinicaTaxa, TM1.ConfigLayoutPromissoriaPaciente AS ConfigLayoutPromissoriaPaciente, TM1.ConfigLayoutContratoCompraTitulo AS ConfigLayoutContratoCompraTitulo, TM1.ConfiguracoesCategoriaTitulo AS ConfiguracoesCategoriaTitulo, TM1.ConfiguracoesImagemLogin, TM1.ConfiguracoesImagemHeader, TM1.ConfiguracoesArquivoPFX FROM ((((Configuracoes TM1 LEFT JOIN LayoutContrato T2 ON T2.LayoutContratoId = TM1.ConfiguracoesLayoutProposta) LEFT JOIN LayoutContrato T3 ON T3.LayoutContratoId = TM1.ConfigLayoutPromissoriaClinicaEmprestimo) "
          + " LEFT JOIN LayoutContrato T4 ON T4.LayoutContratoId = TM1.ConfigLayoutPromissoriaClinicaTaxa) LEFT JOIN LayoutContrato T5 ON T5.LayoutContratoId = TM1.ConfigLayoutPromissoriaPaciente) WHERE TM1.ConfiguracoesId = :ConfiguracoesId ORDER BY TM1.ConfiguracoesId" ;
          Object[] prmT001911;
          prmT001911 = new Object[] {
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001912;
          prmT001912 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001913;
          prmT001913 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001914;
          prmT001914 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001915;
          prmT001915 = new Object[] {
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001916;
          prmT001916 = new Object[] {
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001917;
          prmT001917 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001918;
          prmT001918 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001919;
          prmT001919 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001920;
          prmT001920 = new Object[] {
          new ParDef("ConfiguracoesImagemLogin",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesImagemLoginNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginBackground",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeader",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesImagemHeaderNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracoesArquivoPFX",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracaoSenhaPFX",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaConsultaDetalhada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaHistoricoPagamento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT001920;
          cmdBufferT001920=" SAVEPOINT gxupdate;INSERT INTO Configuracoes(ConfiguracoesImagemLogin, ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeader, ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho, ConfiguracoesArquivoPFX, ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo) VALUES(:ConfiguracoesImagemLogin, :ConfiguracoesImagemLoginNomeInteiro, :ConfiguracoesImagemLoginTamanho, :ConfiguracoesImagemLoginBackground, :ConfiguracoesImagemHeader, :ConfiguracoesImagemHeaderNome, :ConfiguracoesImagemHeaderExtencao, :ConfiguracoesImagemHeaderNomeInteiro, :ConfiguracoesImagemHeaderTamanho, :ConfiguracoesArquivoPFX, :ConfiguracaoSenhaPFX, :ConfiguracoesSerasaAnotacoesCompletas, :ConfiguracoesSerasaConsultaDetalhada, :ConfiguracoesSerasaParticipacaoSocietaria, :ConfiguracoesSerasaRendaEstimada, :ConfiguracoesSerasaHistoricoPagamento, :ConfiguracoesCompraTituloTaxaEfetiva, :ConfiguracoesCompraTituloTaxaMora, :ConfiguracoesCompraTituloFator, :ConfiguracoesCompraTituloTarifaTipo, :ConfiguracoesCompraTituloTarifa, :ConfiguracoesImagemLoginExtencao, :ConfiguracoesImagemLoginNome, "
          + " :ConfiguracoesLayoutProposta, :ConfigLayoutPromissoriaClinicaEmprestimo, :ConfigLayoutPromissoriaClinicaTaxa, :ConfigLayoutPromissoriaPaciente, :ConfigLayoutContratoCompraTitulo, :ConfiguracoesCategoriaTitulo);RELEASE SAVEPOINT gxupdate" ;
          Object[] prmT001921;
          prmT001921 = new Object[] {
          };
          Object[] prmT001922;
          prmT001922 = new Object[] {
          new ParDef("ConfiguracoesImagemLoginNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginBackground",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracaoSenhaPFX",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaConsultaDetalhada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaHistoricoPagamento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          string cmdBufferT001922;
          cmdBufferT001922=" SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesImagemLoginNomeInteiro=:ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho=:ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground=:ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeaderNome=:ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao=:ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro=:ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho=:ConfiguracoesImagemHeaderTamanho, ConfiguracaoSenhaPFX=:ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas=:ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada=:ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria=:ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada=:ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento=:ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva=:ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora=:ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator=:ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo=:ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa=:ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao=:ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome=:ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta=:ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo=:ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa=:ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente=:ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo=:ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo=:ConfiguracoesCategoriaTitulo "
          + "  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate" ;
          Object[] prmT001923;
          prmT001923 = new Object[] {
          new ParDef("ConfiguracoesImagemLogin",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001924;
          prmT001924 = new Object[] {
          new ParDef("ConfiguracoesImagemHeader",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001925;
          prmT001925 = new Object[] {
          new ParDef("ConfiguracoesArquivoPFX",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001926;
          prmT001926 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmT001927;
          prmT001927 = new Object[] {
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001928;
          prmT001928 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001929;
          prmT001929 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001930;
          prmT001930 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001931;
          prmT001931 = new Object[] {
          };
          Object[] prmT001932;
          prmT001932 = new Object[] {
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001933;
          prmT001933 = new Object[] {
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00192", "SELECT ConfiguracoesId, ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho, ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo, ConfiguracoesImagemLogin, ConfiguracoesImagemHeader, ConfiguracoesArquivoPFX FROM Configuracoes WHERE ConfiguracoesId = :ConfiguracoesId  FOR UPDATE OF Configuracoes NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00192,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00193", "SELECT ConfiguracoesId, ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho, ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo, ConfiguracoesImagemLogin, ConfiguracoesImagemHeader, ConfiguracoesArquivoPFX FROM Configuracoes WHERE ConfiguracoesId = :ConfiguracoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00193,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00194", "SELECT LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :ConfiguracoesLayoutProposta ",true, GxErrorMask.GX_NOMASK, false, this,prmT00194,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00195", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaEmprestimo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00195,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00196", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaTaxa ",true, GxErrorMask.GX_NOMASK, false, this,prmT00196,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00197", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaPaciente ",true, GxErrorMask.GX_NOMASK, false, this,prmT00197,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00198", "SELECT LayoutContratoId AS ConfigLayoutContratoCompraTitulo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutContratoCompraTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00198,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00199", "SELECT CategoriaTituloId AS ConfiguracoesCategoriaTitulo FROM CategoriaTitulo WHERE CategoriaTituloId = :ConfiguracoesCategoriaTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00199,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001910", cmdBufferT001910,true, GxErrorMask.GX_NOMASK, false, this,prmT001910,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001911", "SELECT LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :ConfiguracoesLayoutProposta ",true, GxErrorMask.GX_NOMASK, false, this,prmT001911,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001912", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaEmprestimo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001912,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001913", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaTaxa ",true, GxErrorMask.GX_NOMASK, false, this,prmT001913,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001914", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaPaciente ",true, GxErrorMask.GX_NOMASK, false, this,prmT001914,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001915", "SELECT LayoutContratoId AS ConfigLayoutContratoCompraTitulo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutContratoCompraTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001915,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001916", "SELECT CategoriaTituloId AS ConfiguracoesCategoriaTitulo FROM CategoriaTitulo WHERE CategoriaTituloId = :ConfiguracoesCategoriaTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001916,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001917", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfiguracoesId = :ConfiguracoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001917,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001918", "SELECT ConfiguracoesId FROM Configuracoes WHERE ( ConfiguracoesId > :ConfiguracoesId) ORDER BY ConfiguracoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001918,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001919", "SELECT ConfiguracoesId FROM Configuracoes WHERE ( ConfiguracoesId < :ConfiguracoesId) ORDER BY ConfiguracoesId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001919,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001920", cmdBufferT001920, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001920)
             ,new CursorDef("T001921", "SELECT currval('ConfiguracoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001921,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001922", cmdBufferT001922, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001922)
             ,new CursorDef("T001923", "SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesImagemLogin=:ConfiguracoesImagemLogin  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001923)
             ,new CursorDef("T001924", "SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesImagemHeader=:ConfiguracoesImagemHeader  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001924)
             ,new CursorDef("T001925", "SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesArquivoPFX=:ConfiguracoesArquivoPFX  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001925)
             ,new CursorDef("T001926", "SAVEPOINT gxupdate;DELETE FROM Configuracoes  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001926)
             ,new CursorDef("T001927", "SELECT LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :ConfiguracoesLayoutProposta ",true, GxErrorMask.GX_NOMASK, false, this,prmT001927,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001928", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaEmprestimo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001928,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001929", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaTaxa ",true, GxErrorMask.GX_NOMASK, false, this,prmT001929,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001930", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaPaciente ",true, GxErrorMask.GX_NOMASK, false, this,prmT001930,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001931", "SELECT ConfiguracoesId FROM Configuracoes ORDER BY ConfiguracoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001931,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001932", "SELECT LayoutContratoId AS ConfigLayoutContratoCompraTitulo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutContratoCompraTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001932,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001933", "SELECT CategoriaTituloId AS ConfiguracoesCategoriaTitulo FROM CategoriaTitulo WHERE CategoriaTituloId = :ConfiguracoesCategoriaTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001933,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((short[]) buf[43])[0] = rslt.getShort(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getBLOBFile(28, rslt.getVarchar(20), rslt.getVarchar(21));
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getBLOBFile(29, "tmp", "");
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getBLOBFile(30, "tmp", "");
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((short[]) buf[43])[0] = rslt.getShort(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getBLOBFile(28, rslt.getVarchar(20), rslt.getVarchar(21));
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getBLOBFile(29, "tmp", "");
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getBLOBFile(30, "tmp", "");
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((bool[]) buf[27])[0] = rslt.getBool(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((bool[]) buf[29])[0] = rslt.getBool(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((short[]) buf[55])[0] = rslt.getShort(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((short[]) buf[57])[0] = rslt.getShort(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getBLOBFile(32, rslt.getVarchar(24), rslt.getVarchar(25));
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getBLOBFile(33, "tmp", "");
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getBLOBFile(34, "tmp", "");
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
