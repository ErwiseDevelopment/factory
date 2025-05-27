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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class clienterepresentanteswwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public clienterepresentanteswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienterepresentanteswwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ClienteRepresentantesWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV117Title = "Lista de Cliente";
            GXt_char1 = AV120Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV120Companyname = GXt_char1;
            GXt_char1 = AV116Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV116Phone = GXt_char1;
            GXt_char1 = AV114Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV114Mail = GXt_char1;
            GXt_char1 = AV118Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV118Website = GXt_char1;
            GXt_char1 = AV107AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV107AddressLine1 = GXt_char1;
            GXt_char1 = AV108AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV108AddressLine2 = GXt_char1;
            GXt_char1 = AV109AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV109AddressLine3 = GXt_char1;
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDY0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) )
         {
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV119TipoClienteId) )
         {
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo Cliente Id", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV119TipoClienteId), "ZZZ9")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV77GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV71GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV77GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV71GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV15ClienteDocumento1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ClienteDocumento1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17ClienteDocumento = AV15ClienteDocumento1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterClienteDocumentoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ClienteDocumento, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV18TipoClienteDescricao1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TipoClienteDescricao1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV19FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV19FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV20TipoClienteDescricao = AV18TipoClienteDescricao1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterTipoClienteDescricaoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TipoClienteDescricao, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV21ClienteConvenioDescricao1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteConvenioDescricao1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV22FilterClienteConvenioDescricaoDescription = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV22FilterClienteConvenioDescricaoDescription = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                  }
                  AV23ClienteConvenioDescricao = AV21ClienteConvenioDescricao1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22FilterClienteConvenioDescricaoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ClienteConvenioDescricao, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV24ClienteNacionalidadeNome1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteNacionalidadeNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV25FilterClienteNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV25FilterClienteNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV26ClienteNacionalidadeNome = AV24ClienteNacionalidadeNome1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25FilterClienteNacionalidadeNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ClienteNacionalidadeNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV27ClienteProfissaoNome1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ClienteProfissaoNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV28FilterClienteProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV28FilterClienteProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV29ClienteProfissaoNome = AV27ClienteProfissaoNome1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FilterClienteProfissaoNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ClienteProfissaoNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV30MunicipioNome1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MunicipioNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV31FilterMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV31FilterMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV32MunicipioNome = AV30MunicipioNome1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31FilterMunicipioNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32MunicipioNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV33BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV71GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV33BancoCodigo1) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 2 )
                  {
                     AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                  }
                  AV35BancoCodigo = AV33BancoCodigo1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34FilterBancoCodigoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35BancoCodigo), "ZZZZZZZZ9")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV36ResponsavelNacionalidadeNome1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ResponsavelNacionalidadeNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV37FilterResponsavelNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV37FilterResponsavelNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV38ResponsavelNacionalidadeNome = AV36ResponsavelNacionalidadeNome1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterResponsavelNacionalidadeNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38ResponsavelNacionalidadeNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV39ResponsavelProfissaoNome1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV40FilterResponsavelProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV40FilterResponsavelProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV41ResponsavelProfissaoNome = AV39ResponsavelProfissaoNome1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40FilterResponsavelProfissaoNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41ResponsavelProfissaoNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV71GridStateDynamicFilter.gxTpr_Operator;
               AV42ResponsavelMunicipioNome1 = AV71GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResponsavelMunicipioNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV43FilterResponsavelMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV43FilterResponsavelMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV44ResponsavelMunicipioNome = AV42ResponsavelMunicipioNome1;
                  HDY0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43FilterResponsavelMunicipioNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44ResponsavelMunicipioNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV77GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV71GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV77GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV71GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV48ClienteDocumento2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteDocumento2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17ClienteDocumento = AV48ClienteDocumento2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterClienteDocumentoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ClienteDocumento, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV49TipoClienteDescricao2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TipoClienteDescricao2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV19FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV19FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV20TipoClienteDescricao = AV49TipoClienteDescricao2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterTipoClienteDescricaoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TipoClienteDescricao, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV50ClienteConvenioDescricao2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ClienteConvenioDescricao2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV22FilterClienteConvenioDescricaoDescription = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV22FilterClienteConvenioDescricaoDescription = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                     }
                     AV23ClienteConvenioDescricao = AV50ClienteConvenioDescricao2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22FilterClienteConvenioDescricaoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ClienteConvenioDescricao, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV51ClienteNacionalidadeNome2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ClienteNacionalidadeNome2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV25FilterClienteNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV25FilterClienteNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV26ClienteNacionalidadeNome = AV51ClienteNacionalidadeNome2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25FilterClienteNacionalidadeNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ClienteNacionalidadeNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV52ClienteProfissaoNome2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ClienteProfissaoNome2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV28FilterClienteProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV28FilterClienteProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV29ClienteProfissaoNome = AV52ClienteProfissaoNome2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FilterClienteProfissaoNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ClienteProfissaoNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV53MunicipioNome2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MunicipioNome2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV31FilterMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV31FilterMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV32MunicipioNome = AV53MunicipioNome2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31FilterMunicipioNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32MunicipioNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV54BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV71GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV54BancoCodigo2) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 2 )
                     {
                        AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                     }
                     AV35BancoCodigo = AV54BancoCodigo2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34FilterBancoCodigoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35BancoCodigo), "ZZZZZZZZ9")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV55ResponsavelNacionalidadeNome2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ResponsavelNacionalidadeNome2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV37FilterResponsavelNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV37FilterResponsavelNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV38ResponsavelNacionalidadeNome = AV55ResponsavelNacionalidadeNome2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterResponsavelNacionalidadeNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38ResponsavelNacionalidadeNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV56ResponsavelProfissaoNome2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelProfissaoNome2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV40FilterResponsavelProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV40FilterResponsavelProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV41ResponsavelProfissaoNome = AV56ResponsavelProfissaoNome2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40FilterResponsavelProfissaoNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41ResponsavelProfissaoNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV71GridStateDynamicFilter.gxTpr_Operator;
                  AV57ResponsavelMunicipioNome2 = AV71GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ResponsavelMunicipioNome2)) )
                  {
                     if ( AV47DynamicFiltersOperator2 == 0 )
                     {
                        AV43FilterResponsavelMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV47DynamicFiltersOperator2 == 1 )
                     {
                        AV43FilterResponsavelMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV44ResponsavelMunicipioNome = AV57ResponsavelMunicipioNome2;
                     HDY0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43FilterResponsavelMunicipioNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44ResponsavelMunicipioNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV77GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV58DynamicFiltersEnabled3 = true;
                  AV71GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV77GridState.gxTpr_Dynamicfilters.Item(3));
                  AV59DynamicFiltersSelector3 = AV71GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV61ClienteDocumento3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ClienteDocumento3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17ClienteDocumento = AV61ClienteDocumento3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterClienteDocumentoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ClienteDocumento, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV62TipoClienteDescricao3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TipoClienteDescricao3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV19FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV19FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV20TipoClienteDescricao = AV62TipoClienteDescricao3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterTipoClienteDescricaoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TipoClienteDescricao, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV63ClienteConvenioDescricao3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ClienteConvenioDescricao3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV22FilterClienteConvenioDescricaoDescription = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV22FilterClienteConvenioDescricaoDescription = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                        }
                        AV23ClienteConvenioDescricao = AV63ClienteConvenioDescricao3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22FilterClienteConvenioDescricaoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ClienteConvenioDescricao, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV64ClienteNacionalidadeNome3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64ClienteNacionalidadeNome3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV25FilterClienteNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV25FilterClienteNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV26ClienteNacionalidadeNome = AV64ClienteNacionalidadeNome3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25FilterClienteNacionalidadeNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ClienteNacionalidadeNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV65ClienteProfissaoNome3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ClienteProfissaoNome3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV28FilterClienteProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV28FilterClienteProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV29ClienteProfissaoNome = AV65ClienteProfissaoNome3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FilterClienteProfissaoNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ClienteProfissaoNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV66MunicipioNome3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66MunicipioNome3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV31FilterMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV31FilterMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV32MunicipioNome = AV66MunicipioNome3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31FilterMunicipioNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32MunicipioNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV67BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV71GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV67BancoCodigo3) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 2 )
                        {
                           AV34FilterBancoCodigoDescription = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                        }
                        AV35BancoCodigo = AV67BancoCodigo3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34FilterBancoCodigoDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35BancoCodigo), "ZZZZZZZZ9")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV68ResponsavelNacionalidadeNome3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ResponsavelNacionalidadeNome3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV37FilterResponsavelNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV37FilterResponsavelNacionalidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV38ResponsavelNacionalidadeNome = AV68ResponsavelNacionalidadeNome3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterResponsavelNacionalidadeNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38ResponsavelNacionalidadeNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV69ResponsavelProfissaoNome3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ResponsavelProfissaoNome3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV40FilterResponsavelProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV40FilterResponsavelProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV41ResponsavelProfissaoNome = AV69ResponsavelProfissaoNome3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40FilterResponsavelProfissaoNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41ResponsavelProfissaoNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV71GridStateDynamicFilter.gxTpr_Operator;
                     AV70ResponsavelMunicipioNome3 = AV71GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ResponsavelMunicipioNome3)) )
                     {
                        if ( AV60DynamicFiltersOperator3 == 0 )
                        {
                           AV43FilterResponsavelMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV60DynamicFiltersOperator3 == 1 )
                        {
                           AV43FilterResponsavelMunicipioNomeDescription = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV44ResponsavelMunicipioNome = AV70ResponsavelMunicipioNome3;
                        HDY0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43FilterResponsavelMunicipioNomeDescription, "")), 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44ResponsavelMunicipioNome, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFResponsavelNome_Sel)) )
         {
            AV105TempBoolean = (bool)(((StringUtil.StrCmp(AV80TFResponsavelNome_Sel, "<#Empty#>")==0)));
            AV80TFResponsavelNome_Sel = (AV105TempBoolean ? "(Vazio)" : AV80TFResponsavelNome_Sel);
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TFResponsavelNome_Sel, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV80TFResponsavelNome_Sel = (AV105TempBoolean ? "<#Empty#>" : AV80TFResponsavelNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFResponsavelNome)) )
            {
               HDY0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79TFResponsavelNome, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFResponsavelCPF_Sel)) )
         {
            AV105TempBoolean = (bool)(((StringUtil.StrCmp(AV82TFResponsavelCPF_Sel, "<#Empty#>")==0)));
            AV82TFResponsavelCPF_Sel = (AV105TempBoolean ? "(Vazio)" : AV82TFResponsavelCPF_Sel);
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("CPF", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TFResponsavelCPF_Sel, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV82TFResponsavelCPF_Sel = (AV105TempBoolean ? "<#Empty#>" : AV82TFResponsavelCPF_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFResponsavelCPF)) )
            {
               HDY0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CPF", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81TFResponsavelCPF, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFResponsavelCelular_F_Sel)) )
         {
            AV105TempBoolean = (bool)(((StringUtil.StrCmp(AV84TFResponsavelCelular_F_Sel, "<#Empty#>")==0)));
            AV84TFResponsavelCelular_F_Sel = (AV105TempBoolean ? "(Vazio)" : AV84TFResponsavelCelular_F_Sel);
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Celular", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TFResponsavelCelular_F_Sel, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV84TFResponsavelCelular_F_Sel = (AV105TempBoolean ? "<#Empty#>" : AV84TFResponsavelCelular_F_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFResponsavelCelular_F)) )
            {
               HDY0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Celular", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFResponsavelCelular_F, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86TFResponsavelEmail_Sel)) )
         {
            AV105TempBoolean = (bool)(((StringUtil.StrCmp(AV86TFResponsavelEmail_Sel, "<#Empty#>")==0)));
            AV86TFResponsavelEmail_Sel = (AV105TempBoolean ? "(Vazio)" : AV86TFResponsavelEmail_Sel);
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Email", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86TFResponsavelEmail_Sel, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV86TFResponsavelEmail_Sel = (AV105TempBoolean ? "<#Empty#>" : AV86TFResponsavelEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFResponsavelEmail)) )
            {
               HDY0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Email", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85TFResponsavelEmail, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV90TFResponsavelCargo_Sels.FromJSonString(AV87TFResponsavelCargo_SelsJson, null);
         if ( ! ( AV90TFResponsavelCargo_Sels.Count == 0 ) )
         {
            AV106i = 1;
            AV123GXV1 = 1;
            while ( AV123GXV1 <= AV90TFResponsavelCargo_Sels.Count )
            {
               AV89TFResponsavelCargo_Sel = ((string)AV90TFResponsavelCargo_Sels.Item(AV123GXV1));
               if ( AV106i == 1 )
               {
                  AV88TFResponsavelCargo_SelDscs = "";
               }
               else
               {
                  AV88TFResponsavelCargo_SelDscs += ", ";
               }
               AV102FilterTFResponsavelCargo_SelValueDescription = gxdomaindmcargo.getDescription(context,AV89TFResponsavelCargo_Sel);
               AV88TFResponsavelCargo_SelDscs += AV102FilterTFResponsavelCargo_SelValueDescription;
               AV106i = (long)(AV106i+1);
               AV123GXV1 = (int)(AV123GXV1+1);
            }
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cargo", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88TFResponsavelCargo_SelDscs, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92TFClienteDocumento_Sel)) )
         {
            AV105TempBoolean = (bool)(((StringUtil.StrCmp(AV92TFClienteDocumento_Sel, "<#Empty#>")==0)));
            AV92TFClienteDocumento_Sel = (AV105TempBoolean ? "(Vazio)" : AV92TFClienteDocumento_Sel);
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("CNPJ", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92TFClienteDocumento_Sel, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV92TFClienteDocumento_Sel = (AV105TempBoolean ? "<#Empty#>" : AV92TFClienteDocumento_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91TFClienteDocumento)) )
            {
               HDY0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CNPJ", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91TFClienteDocumento, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94TFClienteRazaoSocial_Sel)) )
         {
            AV105TempBoolean = (bool)(((StringUtil.StrCmp(AV94TFClienteRazaoSocial_Sel, "<#Empty#>")==0)));
            AV94TFClienteRazaoSocial_Sel = (AV105TempBoolean ? "(Vazio)" : AV94TFClienteRazaoSocial_Sel);
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Razão Social", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94TFClienteRazaoSocial_Sel, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV94TFClienteRazaoSocial_Sel = (AV105TempBoolean ? "<#Empty#>" : AV94TFClienteRazaoSocial_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93TFClienteRazaoSocial)) )
            {
               HDY0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Razão Social", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93TFClienteRazaoSocial, "@!")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV101TFClienteSituacao_Sels.FromJSonString(AV98TFClienteSituacao_SelsJson, null);
         if ( ! ( AV101TFClienteSituacao_Sels.Count == 0 ) )
         {
            AV106i = 1;
            AV124GXV2 = 1;
            while ( AV124GXV2 <= AV101TFClienteSituacao_Sels.Count )
            {
               AV100TFClienteSituacao_Sel = AV101TFClienteSituacao_Sels.GetString(AV124GXV2);
               if ( AV106i == 1 )
               {
                  AV99TFClienteSituacao_SelDscs = "";
               }
               else
               {
                  AV99TFClienteSituacao_SelDscs += ", ";
               }
               AV104FilterTFClienteSituacao_SelValueDescription = gxdomaindmsituacao.getDescription(context,AV100TFClienteSituacao_Sel);
               AV99TFClienteSituacao_SelDscs += AV104FilterTFClienteSituacao_SelValueDescription;
               AV106i = (long)(AV106i+1);
               AV124GXV2 = (int)(AV124GXV2+1);
            }
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Situação", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99TFClienteSituacao_SelDscs, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV97TFClienteStatus_Sel) )
         {
            if ( AV97TFClienteStatus_Sel == 1 )
            {
               AV103FilterTFClienteStatus_SelValueDescription = "Marcado";
            }
            else if ( AV97TFClienteStatus_Sel == 2 )
            {
               AV103FilterTFClienteStatus_SelValueDescription = "Desmarcado";
            }
            HDY0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103FilterTFClienteStatus_SelValueDescription, "")), 246, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HDY0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HDY0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 110, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("CPF", 114, Gx_line+10, 194, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Celular", 198, Gx_line+10, 278, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Email", 282, Gx_line+10, 362, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cargo", 366, Gx_line+10, 446, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("CNPJ", 450, Gx_line+10, 530, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Razão Social", 534, Gx_line+10, 615, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Situação", 619, Gx_line+10, 701, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 705, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV90TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV101TFClienteSituacao_Sels ,
                                              AV13DynamicFiltersSelector1 ,
                                              AV14DynamicFiltersOperator1 ,
                                              AV15ClienteDocumento1 ,
                                              AV18TipoClienteDescricao1 ,
                                              AV21ClienteConvenioDescricao1 ,
                                              AV24ClienteNacionalidadeNome1 ,
                                              AV27ClienteProfissaoNome1 ,
                                              AV30MunicipioNome1 ,
                                              AV33BancoCodigo1 ,
                                              AV36ResponsavelNacionalidadeNome1 ,
                                              AV39ResponsavelProfissaoNome1 ,
                                              AV42ResponsavelMunicipioNome1 ,
                                              AV45DynamicFiltersEnabled2 ,
                                              AV46DynamicFiltersSelector2 ,
                                              AV47DynamicFiltersOperator2 ,
                                              AV48ClienteDocumento2 ,
                                              AV49TipoClienteDescricao2 ,
                                              AV50ClienteConvenioDescricao2 ,
                                              AV51ClienteNacionalidadeNome2 ,
                                              AV52ClienteProfissaoNome2 ,
                                              AV53MunicipioNome2 ,
                                              AV54BancoCodigo2 ,
                                              AV55ResponsavelNacionalidadeNome2 ,
                                              AV56ResponsavelProfissaoNome2 ,
                                              AV57ResponsavelMunicipioNome2 ,
                                              AV58DynamicFiltersEnabled3 ,
                                              AV59DynamicFiltersSelector3 ,
                                              AV60DynamicFiltersOperator3 ,
                                              AV61ClienteDocumento3 ,
                                              AV62TipoClienteDescricao3 ,
                                              AV63ClienteConvenioDescricao3 ,
                                              AV64ClienteNacionalidadeNome3 ,
                                              AV65ClienteProfissaoNome3 ,
                                              AV66MunicipioNome3 ,
                                              AV67BancoCodigo3 ,
                                              AV68ResponsavelNacionalidadeNome3 ,
                                              AV69ResponsavelProfissaoNome3 ,
                                              AV70ResponsavelMunicipioNome3 ,
                                              AV80TFResponsavelNome_Sel ,
                                              AV79TFResponsavelNome ,
                                              AV82TFResponsavelCPF_Sel ,
                                              AV81TFResponsavelCPF ,
                                              AV86TFResponsavelEmail_Sel ,
                                              AV85TFResponsavelEmail ,
                                              AV90TFResponsavelCargo_Sels.Count ,
                                              AV92TFClienteDocumento_Sel ,
                                              AV91TFClienteDocumento ,
                                              AV94TFClienteRazaoSocial_Sel ,
                                              AV93TFClienteRazaoSocial ,
                                              AV101TFClienteSituacao_Sels.Count ,
                                              AV97TFClienteStatus_Sel ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc ,
                                              AV12FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV84TFResponsavelCelular_F_Sel ,
                                              AV83TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV15ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV15ClienteDocumento1), "%", "");
         lV15ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV15ClienteDocumento1), "%", "");
         lV18TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV18TipoClienteDescricao1), "%", "");
         lV18TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV18TipoClienteDescricao1), "%", "");
         lV21ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteConvenioDescricao1), "%", "");
         lV21ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteConvenioDescricao1), "%", "");
         lV24ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV24ClienteNacionalidadeNome1), "%", "");
         lV24ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV24ClienteNacionalidadeNome1), "%", "");
         lV27ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV27ClienteProfissaoNome1), "%", "");
         lV27ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV27ClienteProfissaoNome1), "%", "");
         lV30MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV30MunicipioNome1), "%", "");
         lV30MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV30MunicipioNome1), "%", "");
         lV36ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV36ResponsavelNacionalidadeNome1), "%", "");
         lV36ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV36ResponsavelNacionalidadeNome1), "%", "");
         lV39ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV39ResponsavelProfissaoNome1), "%", "");
         lV39ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV39ResponsavelProfissaoNome1), "%", "");
         lV42ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV42ResponsavelMunicipioNome1), "%", "");
         lV42ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV42ResponsavelMunicipioNome1), "%", "");
         lV48ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV48ClienteDocumento2), "%", "");
         lV48ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV48ClienteDocumento2), "%", "");
         lV49TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV49TipoClienteDescricao2), "%", "");
         lV49TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV49TipoClienteDescricao2), "%", "");
         lV50ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV50ClienteConvenioDescricao2), "%", "");
         lV50ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV50ClienteConvenioDescricao2), "%", "");
         lV51ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV51ClienteNacionalidadeNome2), "%", "");
         lV51ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV51ClienteNacionalidadeNome2), "%", "");
         lV52ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV52ClienteProfissaoNome2), "%", "");
         lV52ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV52ClienteProfissaoNome2), "%", "");
         lV53MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV53MunicipioNome2), "%", "");
         lV53MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV53MunicipioNome2), "%", "");
         lV55ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV55ResponsavelNacionalidadeNome2), "%", "");
         lV55ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV55ResponsavelNacionalidadeNome2), "%", "");
         lV56ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV56ResponsavelProfissaoNome2), "%", "");
         lV56ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV56ResponsavelProfissaoNome2), "%", "");
         lV57ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV57ResponsavelMunicipioNome2), "%", "");
         lV57ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV57ResponsavelMunicipioNome2), "%", "");
         lV61ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV61ClienteDocumento3), "%", "");
         lV61ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV61ClienteDocumento3), "%", "");
         lV62TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV62TipoClienteDescricao3), "%", "");
         lV62TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV62TipoClienteDescricao3), "%", "");
         lV63ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV63ClienteConvenioDescricao3), "%", "");
         lV63ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV63ClienteConvenioDescricao3), "%", "");
         lV64ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV64ClienteNacionalidadeNome3), "%", "");
         lV64ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV64ClienteNacionalidadeNome3), "%", "");
         lV65ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV65ClienteProfissaoNome3), "%", "");
         lV65ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV65ClienteProfissaoNome3), "%", "");
         lV66MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV66MunicipioNome3), "%", "");
         lV66MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV66MunicipioNome3), "%", "");
         lV68ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV68ResponsavelNacionalidadeNome3), "%", "");
         lV68ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV68ResponsavelNacionalidadeNome3), "%", "");
         lV69ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV69ResponsavelProfissaoNome3), "%", "");
         lV69ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV69ResponsavelProfissaoNome3), "%", "");
         lV70ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV70ResponsavelMunicipioNome3), "%", "");
         lV70ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV70ResponsavelMunicipioNome3), "%", "");
         lV79TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV79TFResponsavelNome), "%", "");
         lV81TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV81TFResponsavelCPF), "%", "");
         lV85TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV85TFResponsavelEmail), "%", "");
         lV91TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV91TFClienteDocumento), "%", "");
         lV93TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV93TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DY2 */
         pr_default.execute(0, new Object[] {lV15ClienteDocumento1, lV15ClienteDocumento1, lV18TipoClienteDescricao1, lV18TipoClienteDescricao1, lV21ClienteConvenioDescricao1, lV21ClienteConvenioDescricao1, lV24ClienteNacionalidadeNome1, lV24ClienteNacionalidadeNome1, lV27ClienteProfissaoNome1, lV27ClienteProfissaoNome1, lV30MunicipioNome1, lV30MunicipioNome1, AV33BancoCodigo1, AV33BancoCodigo1, AV33BancoCodigo1, lV36ResponsavelNacionalidadeNome1, lV36ResponsavelNacionalidadeNome1, lV39ResponsavelProfissaoNome1, lV39ResponsavelProfissaoNome1, lV42ResponsavelMunicipioNome1, lV42ResponsavelMunicipioNome1, lV48ClienteDocumento2, lV48ClienteDocumento2, lV49TipoClienteDescricao2, lV49TipoClienteDescricao2, lV50ClienteConvenioDescricao2, lV50ClienteConvenioDescricao2, lV51ClienteNacionalidadeNome2, lV51ClienteNacionalidadeNome2, lV52ClienteProfissaoNome2, lV52ClienteProfissaoNome2, lV53MunicipioNome2, lV53MunicipioNome2, AV54BancoCodigo2, AV54BancoCodigo2, AV54BancoCodigo2, lV55ResponsavelNacionalidadeNome2, lV55ResponsavelNacionalidadeNome2, lV56ResponsavelProfissaoNome2, lV56ResponsavelProfissaoNome2, lV57ResponsavelMunicipioNome2, lV57ResponsavelMunicipioNome2, lV61ClienteDocumento3, lV61ClienteDocumento3, lV62TipoClienteDescricao3, lV62TipoClienteDescricao3, lV63ClienteConvenioDescricao3, lV63ClienteConvenioDescricao3, lV64ClienteNacionalidadeNome3, lV64ClienteNacionalidadeNome3, lV65ClienteProfissaoNome3, lV65ClienteProfissaoNome3, lV66MunicipioNome3, lV66MunicipioNome3, AV67BancoCodigo3, AV67BancoCodigo3, AV67BancoCodigo3, lV68ResponsavelNacionalidadeNome3, lV68ResponsavelNacionalidadeNome3, lV69ResponsavelProfissaoNome3, lV69ResponsavelProfissaoNome3, lV70ResponsavelMunicipioNome3, lV70ResponsavelMunicipioNome3, lV79TFResponsavelNome, AV80TFResponsavelNome_Sel, lV81TFResponsavelCPF, AV82TFResponsavelCPF_Sel, lV85TFResponsavelEmail, AV86TFResponsavelEmail_Sel, lV91TFClienteDocumento, AV92TFClienteDocumento_Sel, lV93TFClienteRazaoSocial, AV94TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A186MunicipioCodigo = P00DY2_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DY2_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DY2_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DY2_n444ResponsavelMunicipio[0];
            A402BancoId = P00DY2_A402BancoId[0];
            n402BancoId = P00DY2_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DY2_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DY2_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DY2_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DY2_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DY2_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DY2_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DY2_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DY2_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DY2_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DY2_n489ClienteConvenio[0];
            A445ResponsavelMunicipioNome = P00DY2_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DY2_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DY2_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DY2_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DY2_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DY2_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DY2_A404BancoCodigo[0];
            n404BancoCodigo = P00DY2_n404BancoCodigo[0];
            A187MunicipioNome = P00DY2_A187MunicipioNome[0];
            n187MunicipioNome = P00DY2_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DY2_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DY2_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DY2_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DY2_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DY2_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DY2_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DY2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DY2_n193TipoClienteDescricao[0];
            A192TipoClienteId = P00DY2_A192TipoClienteId[0];
            n192TipoClienteId = P00DY2_n192TipoClienteId[0];
            A174ClienteStatus = P00DY2_A174ClienteStatus[0];
            n174ClienteStatus = P00DY2_n174ClienteStatus[0];
            A884ClienteSituacao = P00DY2_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DY2_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DY2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DY2_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00DY2_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DY2_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DY2_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DY2_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DY2_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DY2_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00DY2_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DY2_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00DY2_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DY2_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DY2_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DY2_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DY2_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DY2_n454ResponsavelDDD[0];
            A168ClienteId = P00DY2_A168ClienteId[0];
            A187MunicipioNome = P00DY2_A187MunicipioNome[0];
            n187MunicipioNome = P00DY2_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DY2_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DY2_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DY2_A404BancoCodigo[0];
            n404BancoCodigo = P00DY2_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DY2_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DY2_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DY2_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DY2_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DY2_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DY2_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DY2_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DY2_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DY2_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DY2_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DY2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DY2_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV12FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV12FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV12FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV12FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV12FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV12FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV12FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV84TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV83TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV84TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV84TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV84TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV72ResponsavelCargoDescription = gxdomaindmcargo.getDescription(context,A885ResponsavelCargo);
                        AV74ClienteSituacaoDescription = gxdomaindmsituacao.getDescription(context,A884ClienteSituacao);
                        AV73ClienteStatusDescription = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "true") == 0 )
                        {
                           AV73ClienteStatusDescription = "ATIVO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "false") == 0 )
                        {
                           AV73ClienteStatusDescription = "INATIVO";
                        }
                        /* Execute user subroutine: 'BEFOREPRINTLINE' */
                        S144 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                        HDY0( false, 36) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A436ResponsavelNome, "")), 30, Gx_line+10, 110, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A447ResponsavelCPF, "")), 114, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A577ResponsavelCelular_F, "")), 198, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A456ResponsavelEmail, "")), 282, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72ResponsavelCargoDescription, "")), 366, Gx_line+10, 446, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A169ClienteDocumento, "")), 450, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), 534, Gx_line+10, 615, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74ClienteSituacaoDescription, "")), 619, Gx_line+10, 701, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73ClienteStatusDescription, "")), 705, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+36);
                        /* Execute user subroutine: 'AFTERPRINTLINE' */
                        S161 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV75Session.Get("ClienteRepresentantesWWGridState"), "") == 0 )
         {
            AV77GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteRepresentantesWWGridState"), null, "", "");
         }
         else
         {
            AV77GridState.FromXml(AV75Session.Get("ClienteRepresentantesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV77GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV77GridState.gxTpr_Ordereddsc;
         AV126GXV3 = 1;
         while ( AV126GXV3 <= AV77GridState.gxTpr_Filtervalues.Count )
         {
            AV78GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV77GridState.gxTpr_Filtervalues.Item(AV126GXV3));
            if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TIPOCLIENTEID") == 0 )
            {
               AV119TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV78GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV79TFResponsavelNome = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV80TFResponsavelNome_Sel = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF") == 0 )
            {
               AV81TFResponsavelCPF = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF_SEL") == 0 )
            {
               AV82TFResponsavelCPF_Sel = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F") == 0 )
            {
               AV83TFResponsavelCelular_F = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F_SEL") == 0 )
            {
               AV84TFResponsavelCelular_F_Sel = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV85TFResponsavelEmail = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV86TFResponsavelEmail_Sel = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCARGO_SEL") == 0 )
            {
               AV87TFResponsavelCargo_SelsJson = AV78GridStateFilterValue.gxTpr_Value;
               AV90TFResponsavelCargo_Sels.FromJSonString(AV87TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV91TFClienteDocumento = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV92TFClienteDocumento_Sel = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV93TFClienteRazaoSocial = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV94TFClienteRazaoSocial_Sel = AV78GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV98TFClienteSituacao_SelsJson = AV78GridStateFilterValue.gxTpr_Value;
               AV101TFClienteSituacao_Sels.FromJSonString(AV98TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV78GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV97TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV78GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV126GXV3 = (int)(AV126GXV3+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void HDY0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV115PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV112DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV115PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV112DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+109, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV116Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV114Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+129);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV117Title = "";
         AV120Companyname = "";
         AV116Phone = "";
         AV114Mail = "";
         AV118Website = "";
         AV107AddressLine1 = "";
         AV108AddressLine2 = "";
         AV109AddressLine3 = "";
         AV12FilterFullText = "";
         AV77GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV71GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ClienteDocumento1 = "";
         AV16FilterClienteDocumentoDescription = "";
         AV17ClienteDocumento = "";
         AV18TipoClienteDescricao1 = "";
         AV19FilterTipoClienteDescricaoDescription = "";
         AV20TipoClienteDescricao = "";
         AV21ClienteConvenioDescricao1 = "";
         AV22FilterClienteConvenioDescricaoDescription = "";
         AV23ClienteConvenioDescricao = "";
         AV24ClienteNacionalidadeNome1 = "";
         AV25FilterClienteNacionalidadeNomeDescription = "";
         AV26ClienteNacionalidadeNome = "";
         AV27ClienteProfissaoNome1 = "";
         AV28FilterClienteProfissaoNomeDescription = "";
         AV29ClienteProfissaoNome = "";
         AV30MunicipioNome1 = "";
         AV31FilterMunicipioNomeDescription = "";
         AV32MunicipioNome = "";
         AV34FilterBancoCodigoDescription = "";
         AV36ResponsavelNacionalidadeNome1 = "";
         AV37FilterResponsavelNacionalidadeNomeDescription = "";
         AV38ResponsavelNacionalidadeNome = "";
         AV39ResponsavelProfissaoNome1 = "";
         AV40FilterResponsavelProfissaoNomeDescription = "";
         AV41ResponsavelProfissaoNome = "";
         AV42ResponsavelMunicipioNome1 = "";
         AV43FilterResponsavelMunicipioNomeDescription = "";
         AV44ResponsavelMunicipioNome = "";
         AV46DynamicFiltersSelector2 = "";
         AV48ClienteDocumento2 = "";
         AV49TipoClienteDescricao2 = "";
         AV50ClienteConvenioDescricao2 = "";
         AV51ClienteNacionalidadeNome2 = "";
         AV52ClienteProfissaoNome2 = "";
         AV53MunicipioNome2 = "";
         AV55ResponsavelNacionalidadeNome2 = "";
         AV56ResponsavelProfissaoNome2 = "";
         AV57ResponsavelMunicipioNome2 = "";
         AV59DynamicFiltersSelector3 = "";
         AV61ClienteDocumento3 = "";
         AV62TipoClienteDescricao3 = "";
         AV63ClienteConvenioDescricao3 = "";
         AV64ClienteNacionalidadeNome3 = "";
         AV65ClienteProfissaoNome3 = "";
         AV66MunicipioNome3 = "";
         AV68ResponsavelNacionalidadeNome3 = "";
         AV69ResponsavelProfissaoNome3 = "";
         AV70ResponsavelMunicipioNome3 = "";
         AV80TFResponsavelNome_Sel = "";
         AV79TFResponsavelNome = "";
         AV82TFResponsavelCPF_Sel = "";
         AV81TFResponsavelCPF = "";
         AV84TFResponsavelCelular_F_Sel = "";
         AV83TFResponsavelCelular_F = "";
         AV86TFResponsavelEmail_Sel = "";
         AV85TFResponsavelEmail = "";
         AV90TFResponsavelCargo_Sels = new GxSimpleCollection<string>();
         AV87TFResponsavelCargo_SelsJson = "";
         AV89TFResponsavelCargo_Sel = "";
         AV88TFResponsavelCargo_SelDscs = "";
         AV102FilterTFResponsavelCargo_SelValueDescription = "";
         AV92TFClienteDocumento_Sel = "";
         AV91TFClienteDocumento = "";
         AV94TFClienteRazaoSocial_Sel = "";
         AV93TFClienteRazaoSocial = "";
         AV101TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV98TFClienteSituacao_SelsJson = "";
         AV100TFClienteSituacao_Sel = "";
         AV99TFClienteSituacao_SelDscs = "";
         AV104FilterTFClienteSituacao_SelValueDescription = "";
         AV103FilterTFClienteStatus_SelValueDescription = "";
         lV12FilterFullText = "";
         lV15ClienteDocumento1 = "";
         lV18TipoClienteDescricao1 = "";
         lV21ClienteConvenioDescricao1 = "";
         lV24ClienteNacionalidadeNome1 = "";
         lV27ClienteProfissaoNome1 = "";
         lV30MunicipioNome1 = "";
         lV36ResponsavelNacionalidadeNome1 = "";
         lV39ResponsavelProfissaoNome1 = "";
         lV42ResponsavelMunicipioNome1 = "";
         lV48ClienteDocumento2 = "";
         lV49TipoClienteDescricao2 = "";
         lV50ClienteConvenioDescricao2 = "";
         lV51ClienteNacionalidadeNome2 = "";
         lV52ClienteProfissaoNome2 = "";
         lV53MunicipioNome2 = "";
         lV55ResponsavelNacionalidadeNome2 = "";
         lV56ResponsavelProfissaoNome2 = "";
         lV57ResponsavelMunicipioNome2 = "";
         lV61ClienteDocumento3 = "";
         lV62TipoClienteDescricao3 = "";
         lV63ClienteConvenioDescricao3 = "";
         lV64ClienteNacionalidadeNome3 = "";
         lV65ClienteProfissaoNome3 = "";
         lV66MunicipioNome3 = "";
         lV68ResponsavelNacionalidadeNome3 = "";
         lV69ResponsavelProfissaoNome3 = "";
         lV70ResponsavelMunicipioNome3 = "";
         lV79TFResponsavelNome = "";
         lV81TFResponsavelCPF = "";
         lV85TFResponsavelEmail = "";
         lV91TFClienteDocumento = "";
         lV93TFClienteRazaoSocial = "";
         A885ResponsavelCargo = "";
         A884ClienteSituacao = "";
         A169ClienteDocumento = "";
         A193TipoClienteDescricao = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A170ClienteRazaoSocial = "";
         A577ResponsavelCelular_F = "";
         P00DY2_A186MunicipioCodigo = new string[] {""} ;
         P00DY2_n186MunicipioCodigo = new bool[] {false} ;
         P00DY2_A444ResponsavelMunicipio = new string[] {""} ;
         P00DY2_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DY2_A402BancoId = new int[1] ;
         P00DY2_n402BancoId = new bool[] {false} ;
         P00DY2_A437ResponsavelNacionalidade = new int[1] ;
         P00DY2_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DY2_A484ClienteNacionalidade = new int[1] ;
         P00DY2_n484ClienteNacionalidade = new bool[] {false} ;
         P00DY2_A442ResponsavelProfissao = new int[1] ;
         P00DY2_n442ResponsavelProfissao = new bool[] {false} ;
         P00DY2_A487ClienteProfissao = new int[1] ;
         P00DY2_n487ClienteProfissao = new bool[] {false} ;
         P00DY2_A489ClienteConvenio = new int[1] ;
         P00DY2_n489ClienteConvenio = new bool[] {false} ;
         P00DY2_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DY2_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DY2_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DY2_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DY2_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DY2_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DY2_A404BancoCodigo = new int[1] ;
         P00DY2_n404BancoCodigo = new bool[] {false} ;
         P00DY2_A187MunicipioNome = new string[] {""} ;
         P00DY2_n187MunicipioNome = new bool[] {false} ;
         P00DY2_A488ClienteProfissaoNome = new string[] {""} ;
         P00DY2_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DY2_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DY2_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DY2_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DY2_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DY2_A193TipoClienteDescricao = new string[] {""} ;
         P00DY2_n193TipoClienteDescricao = new bool[] {false} ;
         P00DY2_A192TipoClienteId = new short[1] ;
         P00DY2_n192TipoClienteId = new bool[] {false} ;
         P00DY2_A174ClienteStatus = new bool[] {false} ;
         P00DY2_n174ClienteStatus = new bool[] {false} ;
         P00DY2_A884ClienteSituacao = new string[] {""} ;
         P00DY2_n884ClienteSituacao = new bool[] {false} ;
         P00DY2_A170ClienteRazaoSocial = new string[] {""} ;
         P00DY2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DY2_A169ClienteDocumento = new string[] {""} ;
         P00DY2_n169ClienteDocumento = new bool[] {false} ;
         P00DY2_A885ResponsavelCargo = new string[] {""} ;
         P00DY2_n885ResponsavelCargo = new bool[] {false} ;
         P00DY2_A456ResponsavelEmail = new string[] {""} ;
         P00DY2_n456ResponsavelEmail = new bool[] {false} ;
         P00DY2_A447ResponsavelCPF = new string[] {""} ;
         P00DY2_n447ResponsavelCPF = new bool[] {false} ;
         P00DY2_A436ResponsavelNome = new string[] {""} ;
         P00DY2_n436ResponsavelNome = new bool[] {false} ;
         P00DY2_A455ResponsavelNumero = new int[1] ;
         P00DY2_n455ResponsavelNumero = new bool[] {false} ;
         P00DY2_A454ResponsavelDDD = new short[1] ;
         P00DY2_n454ResponsavelDDD = new bool[] {false} ;
         P00DY2_A168ClienteId = new int[1] ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         GXt_char1 = "";
         AV72ResponsavelCargoDescription = "";
         AV74ClienteSituacaoDescription = "";
         AV73ClienteStatusDescription = "";
         AV75Session = context.GetSession();
         AV78GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV115PageInfo = "";
         AV112DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV110AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienterepresentanteswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00DY2_A186MunicipioCodigo, P00DY2_n186MunicipioCodigo, P00DY2_A444ResponsavelMunicipio, P00DY2_n444ResponsavelMunicipio, P00DY2_A402BancoId, P00DY2_n402BancoId, P00DY2_A437ResponsavelNacionalidade, P00DY2_n437ResponsavelNacionalidade, P00DY2_A484ClienteNacionalidade, P00DY2_n484ClienteNacionalidade,
               P00DY2_A442ResponsavelProfissao, P00DY2_n442ResponsavelProfissao, P00DY2_A487ClienteProfissao, P00DY2_n487ClienteProfissao, P00DY2_A489ClienteConvenio, P00DY2_n489ClienteConvenio, P00DY2_A445ResponsavelMunicipioNome, P00DY2_n445ResponsavelMunicipioNome, P00DY2_A443ResponsavelProfissaoNome, P00DY2_n443ResponsavelProfissaoNome,
               P00DY2_A438ResponsavelNacionalidadeNome, P00DY2_n438ResponsavelNacionalidadeNome, P00DY2_A404BancoCodigo, P00DY2_n404BancoCodigo, P00DY2_A187MunicipioNome, P00DY2_n187MunicipioNome, P00DY2_A488ClienteProfissaoNome, P00DY2_n488ClienteProfissaoNome, P00DY2_A485ClienteNacionalidadeNome, P00DY2_n485ClienteNacionalidadeNome,
               P00DY2_A490ClienteConvenioDescricao, P00DY2_n490ClienteConvenioDescricao, P00DY2_A193TipoClienteDescricao, P00DY2_n193TipoClienteDescricao, P00DY2_A192TipoClienteId, P00DY2_n192TipoClienteId, P00DY2_A174ClienteStatus, P00DY2_n174ClienteStatus, P00DY2_A884ClienteSituacao, P00DY2_n884ClienteSituacao,
               P00DY2_A170ClienteRazaoSocial, P00DY2_n170ClienteRazaoSocial, P00DY2_A169ClienteDocumento, P00DY2_n169ClienteDocumento, P00DY2_A885ResponsavelCargo, P00DY2_n885ResponsavelCargo, P00DY2_A456ResponsavelEmail, P00DY2_n456ResponsavelEmail, P00DY2_A447ResponsavelCPF, P00DY2_n447ResponsavelCPF,
               P00DY2_A436ResponsavelNome, P00DY2_n436ResponsavelNome, P00DY2_A455ResponsavelNumero, P00DY2_n455ResponsavelNumero, P00DY2_A454ResponsavelDDD, P00DY2_n454ResponsavelDDD, P00DY2_A168ClienteId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV119TipoClienteId ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV60DynamicFiltersOperator3 ;
      private short AV97TFClienteStatus_Sel ;
      private short AV10OrderedBy ;
      private short A192TipoClienteId ;
      private short A454ResponsavelDDD ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV33BancoCodigo1 ;
      private int AV35BancoCodigo ;
      private int AV54BancoCodigo2 ;
      private int AV67BancoCodigo3 ;
      private int AV123GXV1 ;
      private int AV124GXV2 ;
      private int AV90TFResponsavelCargo_Sels_Count ;
      private int AV101TFClienteSituacao_Sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A455ResponsavelNumero ;
      private int A168ClienteId ;
      private int AV126GXV3 ;
      private long AV106i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV100TFClienteSituacao_Sel ;
      private string A884ClienteSituacao ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV58DynamicFiltersEnabled3 ;
      private bool AV105TempBoolean ;
      private bool A174ClienteStatus ;
      private bool AV11OrderedDsc ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n193TipoClienteDescricao ;
      private bool n192TipoClienteId ;
      private bool n174ClienteStatus ;
      private bool n884ClienteSituacao ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n885ResponsavelCargo ;
      private bool n456ResponsavelEmail ;
      private bool n447ResponsavelCPF ;
      private bool n436ResponsavelNome ;
      private bool n455ResponsavelNumero ;
      private bool n454ResponsavelDDD ;
      private string AV120Companyname ;
      private string AV87TFResponsavelCargo_SelsJson ;
      private string AV98TFClienteSituacao_SelsJson ;
      private string AV117Title ;
      private string AV116Phone ;
      private string AV114Mail ;
      private string AV118Website ;
      private string AV107AddressLine1 ;
      private string AV108AddressLine2 ;
      private string AV109AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15ClienteDocumento1 ;
      private string AV16FilterClienteDocumentoDescription ;
      private string AV17ClienteDocumento ;
      private string AV18TipoClienteDescricao1 ;
      private string AV19FilterTipoClienteDescricaoDescription ;
      private string AV20TipoClienteDescricao ;
      private string AV21ClienteConvenioDescricao1 ;
      private string AV22FilterClienteConvenioDescricaoDescription ;
      private string AV23ClienteConvenioDescricao ;
      private string AV24ClienteNacionalidadeNome1 ;
      private string AV25FilterClienteNacionalidadeNomeDescription ;
      private string AV26ClienteNacionalidadeNome ;
      private string AV27ClienteProfissaoNome1 ;
      private string AV28FilterClienteProfissaoNomeDescription ;
      private string AV29ClienteProfissaoNome ;
      private string AV30MunicipioNome1 ;
      private string AV31FilterMunicipioNomeDescription ;
      private string AV32MunicipioNome ;
      private string AV34FilterBancoCodigoDescription ;
      private string AV36ResponsavelNacionalidadeNome1 ;
      private string AV37FilterResponsavelNacionalidadeNomeDescription ;
      private string AV38ResponsavelNacionalidadeNome ;
      private string AV39ResponsavelProfissaoNome1 ;
      private string AV40FilterResponsavelProfissaoNomeDescription ;
      private string AV41ResponsavelProfissaoNome ;
      private string AV42ResponsavelMunicipioNome1 ;
      private string AV43FilterResponsavelMunicipioNomeDescription ;
      private string AV44ResponsavelMunicipioNome ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV48ClienteDocumento2 ;
      private string AV49TipoClienteDescricao2 ;
      private string AV50ClienteConvenioDescricao2 ;
      private string AV51ClienteNacionalidadeNome2 ;
      private string AV52ClienteProfissaoNome2 ;
      private string AV53MunicipioNome2 ;
      private string AV55ResponsavelNacionalidadeNome2 ;
      private string AV56ResponsavelProfissaoNome2 ;
      private string AV57ResponsavelMunicipioNome2 ;
      private string AV59DynamicFiltersSelector3 ;
      private string AV61ClienteDocumento3 ;
      private string AV62TipoClienteDescricao3 ;
      private string AV63ClienteConvenioDescricao3 ;
      private string AV64ClienteNacionalidadeNome3 ;
      private string AV65ClienteProfissaoNome3 ;
      private string AV66MunicipioNome3 ;
      private string AV68ResponsavelNacionalidadeNome3 ;
      private string AV69ResponsavelProfissaoNome3 ;
      private string AV70ResponsavelMunicipioNome3 ;
      private string AV80TFResponsavelNome_Sel ;
      private string AV79TFResponsavelNome ;
      private string AV82TFResponsavelCPF_Sel ;
      private string AV81TFResponsavelCPF ;
      private string AV84TFResponsavelCelular_F_Sel ;
      private string AV83TFResponsavelCelular_F ;
      private string AV86TFResponsavelEmail_Sel ;
      private string AV85TFResponsavelEmail ;
      private string AV89TFResponsavelCargo_Sel ;
      private string AV88TFResponsavelCargo_SelDscs ;
      private string AV102FilterTFResponsavelCargo_SelValueDescription ;
      private string AV92TFClienteDocumento_Sel ;
      private string AV91TFClienteDocumento ;
      private string AV94TFClienteRazaoSocial_Sel ;
      private string AV93TFClienteRazaoSocial ;
      private string AV99TFClienteSituacao_SelDscs ;
      private string AV104FilterTFClienteSituacao_SelValueDescription ;
      private string AV103FilterTFClienteStatus_SelValueDescription ;
      private string lV12FilterFullText ;
      private string lV15ClienteDocumento1 ;
      private string lV18TipoClienteDescricao1 ;
      private string lV21ClienteConvenioDescricao1 ;
      private string lV24ClienteNacionalidadeNome1 ;
      private string lV27ClienteProfissaoNome1 ;
      private string lV30MunicipioNome1 ;
      private string lV36ResponsavelNacionalidadeNome1 ;
      private string lV39ResponsavelProfissaoNome1 ;
      private string lV42ResponsavelMunicipioNome1 ;
      private string lV48ClienteDocumento2 ;
      private string lV49TipoClienteDescricao2 ;
      private string lV50ClienteConvenioDescricao2 ;
      private string lV51ClienteNacionalidadeNome2 ;
      private string lV52ClienteProfissaoNome2 ;
      private string lV53MunicipioNome2 ;
      private string lV55ResponsavelNacionalidadeNome2 ;
      private string lV56ResponsavelProfissaoNome2 ;
      private string lV57ResponsavelMunicipioNome2 ;
      private string lV61ClienteDocumento3 ;
      private string lV62TipoClienteDescricao3 ;
      private string lV63ClienteConvenioDescricao3 ;
      private string lV64ClienteNacionalidadeNome3 ;
      private string lV65ClienteProfissaoNome3 ;
      private string lV66MunicipioNome3 ;
      private string lV68ResponsavelNacionalidadeNome3 ;
      private string lV69ResponsavelProfissaoNome3 ;
      private string lV70ResponsavelMunicipioNome3 ;
      private string lV79TFResponsavelNome ;
      private string lV81TFResponsavelCPF ;
      private string lV85TFResponsavelEmail ;
      private string lV91TFClienteDocumento ;
      private string lV93TFClienteRazaoSocial ;
      private string A885ResponsavelCargo ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A436ResponsavelNome ;
      private string A447ResponsavelCPF ;
      private string A456ResponsavelEmail ;
      private string A170ClienteRazaoSocial ;
      private string A577ResponsavelCelular_F ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV72ResponsavelCargoDescription ;
      private string AV74ClienteSituacaoDescription ;
      private string AV73ClienteStatusDescription ;
      private string AV115PageInfo ;
      private string AV112DateInfo ;
      private string AV110AppName ;
      private IGxSession AV75Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV77GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV71GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV90TFResponsavelCargo_Sels ;
      private GxSimpleCollection<string> AV101TFClienteSituacao_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DY2_A186MunicipioCodigo ;
      private bool[] P00DY2_n186MunicipioCodigo ;
      private string[] P00DY2_A444ResponsavelMunicipio ;
      private bool[] P00DY2_n444ResponsavelMunicipio ;
      private int[] P00DY2_A402BancoId ;
      private bool[] P00DY2_n402BancoId ;
      private int[] P00DY2_A437ResponsavelNacionalidade ;
      private bool[] P00DY2_n437ResponsavelNacionalidade ;
      private int[] P00DY2_A484ClienteNacionalidade ;
      private bool[] P00DY2_n484ClienteNacionalidade ;
      private int[] P00DY2_A442ResponsavelProfissao ;
      private bool[] P00DY2_n442ResponsavelProfissao ;
      private int[] P00DY2_A487ClienteProfissao ;
      private bool[] P00DY2_n487ClienteProfissao ;
      private int[] P00DY2_A489ClienteConvenio ;
      private bool[] P00DY2_n489ClienteConvenio ;
      private string[] P00DY2_A445ResponsavelMunicipioNome ;
      private bool[] P00DY2_n445ResponsavelMunicipioNome ;
      private string[] P00DY2_A443ResponsavelProfissaoNome ;
      private bool[] P00DY2_n443ResponsavelProfissaoNome ;
      private string[] P00DY2_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DY2_n438ResponsavelNacionalidadeNome ;
      private int[] P00DY2_A404BancoCodigo ;
      private bool[] P00DY2_n404BancoCodigo ;
      private string[] P00DY2_A187MunicipioNome ;
      private bool[] P00DY2_n187MunicipioNome ;
      private string[] P00DY2_A488ClienteProfissaoNome ;
      private bool[] P00DY2_n488ClienteProfissaoNome ;
      private string[] P00DY2_A485ClienteNacionalidadeNome ;
      private bool[] P00DY2_n485ClienteNacionalidadeNome ;
      private string[] P00DY2_A490ClienteConvenioDescricao ;
      private bool[] P00DY2_n490ClienteConvenioDescricao ;
      private string[] P00DY2_A193TipoClienteDescricao ;
      private bool[] P00DY2_n193TipoClienteDescricao ;
      private short[] P00DY2_A192TipoClienteId ;
      private bool[] P00DY2_n192TipoClienteId ;
      private bool[] P00DY2_A174ClienteStatus ;
      private bool[] P00DY2_n174ClienteStatus ;
      private string[] P00DY2_A884ClienteSituacao ;
      private bool[] P00DY2_n884ClienteSituacao ;
      private string[] P00DY2_A170ClienteRazaoSocial ;
      private bool[] P00DY2_n170ClienteRazaoSocial ;
      private string[] P00DY2_A169ClienteDocumento ;
      private bool[] P00DY2_n169ClienteDocumento ;
      private string[] P00DY2_A885ResponsavelCargo ;
      private bool[] P00DY2_n885ResponsavelCargo ;
      private string[] P00DY2_A456ResponsavelEmail ;
      private bool[] P00DY2_n456ResponsavelEmail ;
      private string[] P00DY2_A447ResponsavelCPF ;
      private bool[] P00DY2_n447ResponsavelCPF ;
      private string[] P00DY2_A436ResponsavelNome ;
      private bool[] P00DY2_n436ResponsavelNome ;
      private int[] P00DY2_A455ResponsavelNumero ;
      private bool[] P00DY2_n455ResponsavelNumero ;
      private short[] P00DY2_A454ResponsavelDDD ;
      private bool[] P00DY2_n454ResponsavelDDD ;
      private int[] P00DY2_A168ClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV78GridStateFilterValue ;
   }

   public class clienterepresentanteswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DY2( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV90TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV101TFClienteSituacao_Sels ,
                                             string AV13DynamicFiltersSelector1 ,
                                             short AV14DynamicFiltersOperator1 ,
                                             string AV15ClienteDocumento1 ,
                                             string AV18TipoClienteDescricao1 ,
                                             string AV21ClienteConvenioDescricao1 ,
                                             string AV24ClienteNacionalidadeNome1 ,
                                             string AV27ClienteProfissaoNome1 ,
                                             string AV30MunicipioNome1 ,
                                             int AV33BancoCodigo1 ,
                                             string AV36ResponsavelNacionalidadeNome1 ,
                                             string AV39ResponsavelProfissaoNome1 ,
                                             string AV42ResponsavelMunicipioNome1 ,
                                             bool AV45DynamicFiltersEnabled2 ,
                                             string AV46DynamicFiltersSelector2 ,
                                             short AV47DynamicFiltersOperator2 ,
                                             string AV48ClienteDocumento2 ,
                                             string AV49TipoClienteDescricao2 ,
                                             string AV50ClienteConvenioDescricao2 ,
                                             string AV51ClienteNacionalidadeNome2 ,
                                             string AV52ClienteProfissaoNome2 ,
                                             string AV53MunicipioNome2 ,
                                             int AV54BancoCodigo2 ,
                                             string AV55ResponsavelNacionalidadeNome2 ,
                                             string AV56ResponsavelProfissaoNome2 ,
                                             string AV57ResponsavelMunicipioNome2 ,
                                             bool AV58DynamicFiltersEnabled3 ,
                                             string AV59DynamicFiltersSelector3 ,
                                             short AV60DynamicFiltersOperator3 ,
                                             string AV61ClienteDocumento3 ,
                                             string AV62TipoClienteDescricao3 ,
                                             string AV63ClienteConvenioDescricao3 ,
                                             string AV64ClienteNacionalidadeNome3 ,
                                             string AV65ClienteProfissaoNome3 ,
                                             string AV66MunicipioNome3 ,
                                             int AV67BancoCodigo3 ,
                                             string AV68ResponsavelNacionalidadeNome3 ,
                                             string AV69ResponsavelProfissaoNome3 ,
                                             string AV70ResponsavelMunicipioNome3 ,
                                             string AV80TFResponsavelNome_Sel ,
                                             string AV79TFResponsavelNome ,
                                             string AV82TFResponsavelCPF_Sel ,
                                             string AV81TFResponsavelCPF ,
                                             string AV86TFResponsavelEmail_Sel ,
                                             string AV85TFResponsavelEmail ,
                                             int AV90TFResponsavelCargo_Sels_Count ,
                                             string AV92TFClienteDocumento_Sel ,
                                             string AV91TFClienteDocumento ,
                                             string AV94TFClienteRazaoSocial_Sel ,
                                             string AV93TFClienteRazaoSocial ,
                                             int AV101TFClienteSituacao_Sels_Count ,
                                             short AV97TFClienteStatus_Sel ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc ,
                                             string AV12FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV84TFResponsavelCelular_F_Sel ,
                                             string AV83TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[73];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV15ClienteDocumento1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV15ClienteDocumento1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV18TipoClienteDescricao1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV18TipoClienteDescricao1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV21ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV21ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV24ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV24ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV27ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV27ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV30MunicipioNome1)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV30MunicipioNome1)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! (0==AV33BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV33BancoCodigo1)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! (0==AV33BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV33BancoCodigo1)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV14DynamicFiltersOperator1 == 2 ) && ( ! (0==AV33BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV33BancoCodigo1)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV36ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV36ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV39ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV39ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV42ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV42ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV48ClienteDocumento2)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV48ClienteDocumento2)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV49TipoClienteDescricao2)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV49TipoClienteDescricao2)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV50ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV50ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV51ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV51ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV52ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV52ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV53MunicipioNome2)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV53MunicipioNome2)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! (0==AV54BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV54BancoCodigo2)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! (0==AV54BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV54BancoCodigo2)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV47DynamicFiltersOperator2 == 2 ) && ( ! (0==AV54BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV54BancoCodigo2)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV55ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV55ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV56ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV56ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV57ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( AV45DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV47DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV57ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV61ClienteDocumento3)");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV61ClienteDocumento3)");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV62TipoClienteDescricao3)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV62TipoClienteDescricao3)");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV63ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV63ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV64ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV64ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV65ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV65ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV66MunicipioNome3)");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV66MunicipioNome3)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! (0==AV67BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV67BancoCodigo3)");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! (0==AV67BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV67BancoCodigo3)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV60DynamicFiltersOperator3 == 2 ) && ( ! (0==AV67BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV67BancoCodigo3)");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV68ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV68ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV69ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV69ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV70ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( AV58DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV60DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV70ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV79TFResponsavelNome)");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV80TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV80TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int2[64] = 1;
         }
         if ( StringUtil.StrCmp(AV80TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV81TFResponsavelCPF)");
         }
         else
         {
            GXv_int2[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV82TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV82TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int2[66] = 1;
         }
         if ( StringUtil.StrCmp(AV82TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV85TFResponsavelEmail)");
         }
         else
         {
            GXv_int2[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV86TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV86TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int2[68] = 1;
         }
         if ( StringUtil.StrCmp(AV86TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV90TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV91TFClienteDocumento)");
         }
         else
         {
            GXv_int2[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV92TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV92TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int2[70] = 1;
         }
         if ( StringUtil.StrCmp(AV92TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV93TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int2[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV94TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV94TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int2[72] = 1;
         }
         if ( StringUtil.StrCmp(AV94TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV101TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV101TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV97TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV97TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DY2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (short)dynConstraints[70] , (bool)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (short)dynConstraints[76] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DY2;
          prmP00DY2 = new Object[] {
          new ParDef("lV15ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV15ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV18TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV18TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV21ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV21ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV24ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV24ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV27ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV27ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV30MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV30MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV33BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV33BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV33BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV36ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV36ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV39ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV39ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV42ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV42ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV48ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV48ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV49TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV49TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV50ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV50ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV51ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV51ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV52ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV52ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV53MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV53MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV54BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV54BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV54BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV55ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV55ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV56ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV56ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV57ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV57ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV61ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV61ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV62TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV62TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV63ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV63ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV64ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV64ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV65ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV65ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV66MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV66MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV67BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV67BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV67BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV68ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV68ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV69ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV69ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV70ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV70ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV79TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV80TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV81TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV82TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV85TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV86TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV91TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV92TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV93TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV94TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DY2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((short[]) buf[34])[0] = rslt.getShort(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((bool[]) buf[36])[0] = rslt.getBool(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getString(20, 1);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
       }
    }

 }

}
