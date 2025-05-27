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
   public class financiamentowwexportreport : GXWebProcedure
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

      public financiamentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamentowwexportreport( IGxContext context )
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
         setOutputFileName("FinanciamentoWWExportReport");
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
            AV63Title = "Lista de Financiamento";
            GXt_char1 = AV65Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV65Companyname = GXt_char1;
            GXt_char1 = AV62Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV62Phone = GXt_char1;
            GXt_char1 = AV60Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV60Mail = GXt_char1;
            GXt_char1 = AV64Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV64Website = GXt_char1;
            GXt_char1 = AV53AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV53AddressLine1 = GXt_char1;
            GXt_char1 = AV54AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV54AddressLine2 = GXt_char1;
            GXt_char1 = AV55AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV55AddressLine3 = GXt_char1;
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
            H760( true, 0) ;
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
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV15FinanciamentoValor1 = NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV15FinanciamentoValor1) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 2 )
                  {
                     AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                  }
                  AV17FinanciamentoValor = AV15FinanciamentoValor1;
                  H760( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterFinanciamentoValorDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV18ClienteDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ClienteDocumento1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV19FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV19FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV20ClienteDocumento = AV18ClienteDocumento1;
                  H760( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterClienteDocumentoDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV21IntermediadorClienteDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21IntermediadorClienteDocumento1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV22FilterIntermediadorClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV22FilterIntermediadorClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV23IntermediadorClienteDocumento = AV21IntermediadorClienteDocumento1;
                  H760( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22FilterIntermediadorClienteDocumentoDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23IntermediadorClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV27FinanciamentoValor2 = NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV27FinanciamentoValor2) )
                  {
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV17FinanciamentoValor = AV27FinanciamentoValor2;
                     H760( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterFinanciamentoValorDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV28ClienteDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ClienteDocumento2)) )
                  {
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV19FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV19FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV20ClienteDocumento = AV28ClienteDocumento2;
                     H760( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterClienteDocumentoDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV29IntermediadorClienteDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29IntermediadorClienteDocumento2)) )
                  {
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV22FilterIntermediadorClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV22FilterIntermediadorClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV23IntermediadorClienteDocumento = AV29IntermediadorClienteDocumento2;
                     H760( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22FilterIntermediadorClienteDocumentoDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23IntermediadorClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV30DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(3));
                  AV31DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV33FinanciamentoValor3 = NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV33FinanciamentoValor3) )
                     {
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 2 )
                        {
                           AV16FilterFinanciamentoValorDescription = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                        }
                        AV17FinanciamentoValor = AV33FinanciamentoValor3;
                        H760( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterFinanciamentoValorDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV34ClienteDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteDocumento3)) )
                     {
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV19FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV19FilterClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV20ClienteDocumento = AV34ClienteDocumento3;
                        H760( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterClienteDocumentoDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV35IntermediadorClienteDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35IntermediadorClienteDocumento3)) )
                     {
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV22FilterIntermediadorClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV22FilterIntermediadorClienteDocumentoDescription = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV23IntermediadorClienteDocumento = AV35IntermediadorClienteDocumento3;
                        H760( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22FilterIntermediadorClienteDocumentoDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23IntermediadorClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFClienteRazaoSocial_Sel, "<#Empty#>")==0)));
            AV42TFClienteRazaoSocial_Sel = (AV52TempBoolean ? "(Vazio)" : AV42TFClienteRazaoSocial_Sel);
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cliente", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFClienteRazaoSocial_Sel, "@!")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFClienteRazaoSocial_Sel = (AV52TempBoolean ? "<#Empty#>" : AV42TFClienteRazaoSocial_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteRazaoSocial)) )
            {
               H760( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFClienteRazaoSocial, "@!")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteDocumento_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV44TFClienteDocumento_Sel, "<#Empty#>")==0)));
            AV44TFClienteDocumento_Sel = (AV52TempBoolean ? "(Vazio)" : AV44TFClienteDocumento_Sel);
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cliente CPF", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFClienteDocumento_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV44TFClienteDocumento_Sel = (AV52TempBoolean ? "<#Empty#>" : AV44TFClienteDocumento_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteDocumento)) )
            {
               H760( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente CPF", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFFinanciamentoValor) && (Convert.ToDecimal(0)==AV46TFFinanciamentoValor_To) ) )
         {
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Valor", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TFFinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFFinanciamentoValor_To_Description = StringUtil.Format( "%1 (%2)", "Valor", "Até", "", "", "", "", "", "", "");
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFFinanciamentoValor_To_Description, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TFFinanciamentoValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIntermediadorClienteRazaoSocial_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFIntermediadorClienteRazaoSocial_Sel, "<#Empty#>")==0)));
            AV48TFIntermediadorClienteRazaoSocial_Sel = (AV52TempBoolean ? "(Vazio)" : AV48TFIntermediadorClienteRazaoSocial_Sel);
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Intermediador", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFIntermediadorClienteRazaoSocial_Sel, "@!")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFIntermediadorClienteRazaoSocial_Sel = (AV52TempBoolean ? "<#Empty#>" : AV48TFIntermediadorClienteRazaoSocial_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFIntermediadorClienteRazaoSocial)) )
            {
               H760( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Intermediador", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFIntermediadorClienteRazaoSocial, "@!")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIntermediadorClienteDocumento_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV50TFIntermediadorClienteDocumento_Sel, "<#Empty#>")==0)));
            AV50TFIntermediadorClienteDocumento_Sel = (AV52TempBoolean ? "(Vazio)" : AV50TFIntermediadorClienteDocumento_Sel);
            H760( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Intermediador CPF", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFIntermediadorClienteDocumento_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFIntermediadorClienteDocumento_Sel = (AV52TempBoolean ? "<#Empty#>" : AV50TFIntermediadorClienteDocumento_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIntermediadorClienteDocumento)) )
            {
               H760( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Intermediador CPF", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFIntermediadorClienteDocumento, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H760( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H760( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Cliente", 30, Gx_line+10, 194, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cliente CPF", 198, Gx_line+10, 362, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Valor", 366, Gx_line+10, 448, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Intermediador", 452, Gx_line+10, 617, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Intermediador CPF", 621, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV69Financiamentowwds_1_filterfulltext = AV12FilterFullText;
         AV70Financiamentowwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV71Financiamentowwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV72Financiamentowwds_4_financiamentovalor1 = AV15FinanciamentoValor1;
         AV73Financiamentowwds_5_clientedocumento1 = AV18ClienteDocumento1;
         AV74Financiamentowwds_6_intermediadorclientedocumento1 = AV21IntermediadorClienteDocumento1;
         AV75Financiamentowwds_7_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV76Financiamentowwds_8_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV77Financiamentowwds_9_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV78Financiamentowwds_10_financiamentovalor2 = AV27FinanciamentoValor2;
         AV79Financiamentowwds_11_clientedocumento2 = AV28ClienteDocumento2;
         AV80Financiamentowwds_12_intermediadorclientedocumento2 = AV29IntermediadorClienteDocumento2;
         AV81Financiamentowwds_13_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV82Financiamentowwds_14_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV83Financiamentowwds_15_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV84Financiamentowwds_16_financiamentovalor3 = AV33FinanciamentoValor3;
         AV85Financiamentowwds_17_clientedocumento3 = AV34ClienteDocumento3;
         AV86Financiamentowwds_18_intermediadorclientedocumento3 = AV35IntermediadorClienteDocumento3;
         AV87Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV88Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV89Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV90Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV91Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV92Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV93Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV95Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV69Financiamentowwds_1_filterfulltext ,
                                              AV70Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV71Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV72Financiamentowwds_4_financiamentovalor1 ,
                                              AV73Financiamentowwds_5_clientedocumento1 ,
                                              AV74Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV75Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV76Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV77Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV78Financiamentowwds_10_financiamentovalor2 ,
                                              AV79Financiamentowwds_11_clientedocumento2 ,
                                              AV80Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV81Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV82Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV83Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV84Financiamentowwds_16_financiamentovalor3 ,
                                              AV85Financiamentowwds_17_clientedocumento3 ,
                                              AV86Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV88Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV87Financiamentowwds_19_tfclienterazaosocial ,
                                              AV90Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV89Financiamentowwds_21_tfclientedocumento ,
                                              AV91Financiamentowwds_23_tffinanciamentovalor ,
                                              AV92Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV93Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV95Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_1_filterfulltext), "%", "");
         lV69Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_1_filterfulltext), "%", "");
         lV69Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_1_filterfulltext), "%", "");
         lV69Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_1_filterfulltext), "%", "");
         lV69Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_1_filterfulltext), "%", "");
         lV73Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_5_clientedocumento1), "%", "");
         lV73Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_5_clientedocumento1), "%", "");
         lV74Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV74Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV74Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV74Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV79Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_11_clientedocumento2), "%", "");
         lV79Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_11_clientedocumento2), "%", "");
         lV80Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV80Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV80Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV80Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV85Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV85Financiamentowwds_17_clientedocumento3), "%", "");
         lV85Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV85Financiamentowwds_17_clientedocumento3), "%", "");
         lV86Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV86Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV86Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV86Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV87Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV87Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV89Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV89Financiamentowwds_21_tfclientedocumento), "%", "");
         lV93Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV93Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV95Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV95Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor P00762 */
         pr_default.execute(0, new Object[] {lV69Financiamentowwds_1_filterfulltext, lV69Financiamentowwds_1_filterfulltext, lV69Financiamentowwds_1_filterfulltext, lV69Financiamentowwds_1_filterfulltext, lV69Financiamentowwds_1_filterfulltext, AV72Financiamentowwds_4_financiamentovalor1, AV72Financiamentowwds_4_financiamentovalor1, AV72Financiamentowwds_4_financiamentovalor1, lV73Financiamentowwds_5_clientedocumento1, lV73Financiamentowwds_5_clientedocumento1, lV74Financiamentowwds_6_intermediadorclientedocumento1, lV74Financiamentowwds_6_intermediadorclientedocumento1, AV78Financiamentowwds_10_financiamentovalor2, AV78Financiamentowwds_10_financiamentovalor2, AV78Financiamentowwds_10_financiamentovalor2, lV79Financiamentowwds_11_clientedocumento2, lV79Financiamentowwds_11_clientedocumento2, lV80Financiamentowwds_12_intermediadorclientedocumento2, lV80Financiamentowwds_12_intermediadorclientedocumento2, AV84Financiamentowwds_16_financiamentovalor3, AV84Financiamentowwds_16_financiamentovalor3, AV84Financiamentowwds_16_financiamentovalor3, lV85Financiamentowwds_17_clientedocumento3, lV85Financiamentowwds_17_clientedocumento3, lV86Financiamentowwds_18_intermediadorclientedocumento3, lV86Financiamentowwds_18_intermediadorclientedocumento3, lV87Financiamentowwds_19_tfclienterazaosocial, AV88Financiamentowwds_20_tfclienterazaosocial_sel, lV89Financiamentowwds_21_tfclientedocumento, AV90Financiamentowwds_22_tfclientedocumento_sel, AV91Financiamentowwds_23_tffinanciamentovalor, AV92Financiamentowwds_24_tffinanciamentovalor_to, lV93Financiamentowwds_25_tfintermediadorclienterazaosocial, AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV95Financiamentowwds_27_tfintermediadorclientedocumento, AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = P00762_A168ClienteId[0];
            n168ClienteId = P00762_n168ClienteId[0];
            A220IntermediadorClienteId = P00762_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = P00762_n220IntermediadorClienteId[0];
            A224FinanciamentoValor = P00762_A224FinanciamentoValor[0];
            n224FinanciamentoValor = P00762_n224FinanciamentoValor[0];
            A222IntermediadorClienteDocumento = P00762_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00762_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00762_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00762_n221IntermediadorClienteRazaoSocial[0];
            A169ClienteDocumento = P00762_A169ClienteDocumento[0];
            n169ClienteDocumento = P00762_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00762_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00762_n170ClienteRazaoSocial[0];
            A223FinanciamentoId = P00762_A223FinanciamentoId[0];
            A169ClienteDocumento = P00762_A169ClienteDocumento[0];
            n169ClienteDocumento = P00762_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00762_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00762_n170ClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = P00762_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00762_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00762_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00762_n221IntermediadorClienteRazaoSocial[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H760( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), 30, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A169ClienteDocumento, "")), 198, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A224FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 366, Gx_line+10, 448, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A221IntermediadorClienteRazaoSocial, "@!")), 452, Gx_line+10, 617, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A222IntermediadorClienteDocumento, "")), 621, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("FinanciamentoWWGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "FinanciamentoWWGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("FinanciamentoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV39GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV39GridState.gxTpr_Ordereddsc;
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV41TFClienteRazaoSocial = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV42TFClienteRazaoSocial_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV43TFClienteDocumento = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV44TFClienteDocumento_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFFINANCIAMENTOVALOR") == 0 )
            {
               AV45TFFinanciamentoValor = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV46TFFinanciamentoValor_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL") == 0 )
            {
               AV47TFIntermediadorClienteRazaoSocial = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV48TFIntermediadorClienteRazaoSocial_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV49TFIntermediadorClienteDocumento = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV50TFIntermediadorClienteDocumento_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            AV97GXV1 = (int)(AV97GXV1+1);
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

      protected void H760( bool bFoot ,
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
                  AV61PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV58DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV63Title = "";
         AV65Companyname = "";
         AV62Phone = "";
         AV60Mail = "";
         AV64Website = "";
         AV53AddressLine1 = "";
         AV54AddressLine2 = "";
         AV55AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV16FilterFinanciamentoValorDescription = "";
         AV18ClienteDocumento1 = "";
         AV19FilterClienteDocumentoDescription = "";
         AV20ClienteDocumento = "";
         AV21IntermediadorClienteDocumento1 = "";
         AV22FilterIntermediadorClienteDocumentoDescription = "";
         AV23IntermediadorClienteDocumento = "";
         AV25DynamicFiltersSelector2 = "";
         AV28ClienteDocumento2 = "";
         AV29IntermediadorClienteDocumento2 = "";
         AV31DynamicFiltersSelector3 = "";
         AV34ClienteDocumento3 = "";
         AV35IntermediadorClienteDocumento3 = "";
         AV42TFClienteRazaoSocial_Sel = "";
         AV41TFClienteRazaoSocial = "";
         AV44TFClienteDocumento_Sel = "";
         AV43TFClienteDocumento = "";
         AV51TFFinanciamentoValor_To_Description = "";
         AV48TFIntermediadorClienteRazaoSocial_Sel = "";
         AV47TFIntermediadorClienteRazaoSocial = "";
         AV50TFIntermediadorClienteDocumento_Sel = "";
         AV49TFIntermediadorClienteDocumento = "";
         AV69Financiamentowwds_1_filterfulltext = "";
         AV70Financiamentowwds_2_dynamicfiltersselector1 = "";
         AV73Financiamentowwds_5_clientedocumento1 = "";
         AV74Financiamentowwds_6_intermediadorclientedocumento1 = "";
         AV76Financiamentowwds_8_dynamicfiltersselector2 = "";
         AV79Financiamentowwds_11_clientedocumento2 = "";
         AV80Financiamentowwds_12_intermediadorclientedocumento2 = "";
         AV82Financiamentowwds_14_dynamicfiltersselector3 = "";
         AV85Financiamentowwds_17_clientedocumento3 = "";
         AV86Financiamentowwds_18_intermediadorclientedocumento3 = "";
         AV87Financiamentowwds_19_tfclienterazaosocial = "";
         AV88Financiamentowwds_20_tfclienterazaosocial_sel = "";
         AV89Financiamentowwds_21_tfclientedocumento = "";
         AV90Financiamentowwds_22_tfclientedocumento_sel = "";
         AV93Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = "";
         AV95Financiamentowwds_27_tfintermediadorclientedocumento = "";
         AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel = "";
         lV69Financiamentowwds_1_filterfulltext = "";
         lV73Financiamentowwds_5_clientedocumento1 = "";
         lV74Financiamentowwds_6_intermediadorclientedocumento1 = "";
         lV79Financiamentowwds_11_clientedocumento2 = "";
         lV80Financiamentowwds_12_intermediadorclientedocumento2 = "";
         lV85Financiamentowwds_17_clientedocumento3 = "";
         lV86Financiamentowwds_18_intermediadorclientedocumento3 = "";
         lV87Financiamentowwds_19_tfclienterazaosocial = "";
         lV89Financiamentowwds_21_tfclientedocumento = "";
         lV93Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         lV95Financiamentowwds_27_tfintermediadorclientedocumento = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A221IntermediadorClienteRazaoSocial = "";
         A222IntermediadorClienteDocumento = "";
         P00762_A168ClienteId = new int[1] ;
         P00762_n168ClienteId = new bool[] {false} ;
         P00762_A220IntermediadorClienteId = new int[1] ;
         P00762_n220IntermediadorClienteId = new bool[] {false} ;
         P00762_A224FinanciamentoValor = new decimal[1] ;
         P00762_n224FinanciamentoValor = new bool[] {false} ;
         P00762_A222IntermediadorClienteDocumento = new string[] {""} ;
         P00762_n222IntermediadorClienteDocumento = new bool[] {false} ;
         P00762_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         P00762_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         P00762_A169ClienteDocumento = new string[] {""} ;
         P00762_n169ClienteDocumento = new bool[] {false} ;
         P00762_A170ClienteRazaoSocial = new string[] {""} ;
         P00762_n170ClienteRazaoSocial = new bool[] {false} ;
         P00762_A223FinanciamentoId = new int[1] ;
         AV37Session = context.GetSession();
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV61PageInfo = "";
         AV58DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV56AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00762_A168ClienteId, P00762_n168ClienteId, P00762_A220IntermediadorClienteId, P00762_n220IntermediadorClienteId, P00762_A224FinanciamentoValor, P00762_n224FinanciamentoValor, P00762_A222IntermediadorClienteDocumento, P00762_n222IntermediadorClienteDocumento, P00762_A221IntermediadorClienteRazaoSocial, P00762_n221IntermediadorClienteRazaoSocial,
               P00762_A169ClienteDocumento, P00762_n169ClienteDocumento, P00762_A170ClienteRazaoSocial, P00762_n170ClienteRazaoSocial, P00762_A223FinanciamentoId
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
      private short AV14DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short AV71Financiamentowwds_3_dynamicfiltersoperator1 ;
      private short AV77Financiamentowwds_9_dynamicfiltersoperator2 ;
      private short AV83Financiamentowwds_15_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A168ClienteId ;
      private int A220IntermediadorClienteId ;
      private int A223FinanciamentoId ;
      private int AV97GXV1 ;
      private decimal AV15FinanciamentoValor1 ;
      private decimal AV17FinanciamentoValor ;
      private decimal AV27FinanciamentoValor2 ;
      private decimal AV33FinanciamentoValor3 ;
      private decimal AV45TFFinanciamentoValor ;
      private decimal AV46TFFinanciamentoValor_To ;
      private decimal AV72Financiamentowwds_4_financiamentovalor1 ;
      private decimal AV78Financiamentowwds_10_financiamentovalor2 ;
      private decimal AV84Financiamentowwds_16_financiamentovalor3 ;
      private decimal AV91Financiamentowwds_23_tffinanciamentovalor ;
      private decimal AV92Financiamentowwds_24_tffinanciamentovalor_to ;
      private decimal A224FinanciamentoValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV52TempBoolean ;
      private bool AV75Financiamentowwds_7_dynamicfiltersenabled2 ;
      private bool AV81Financiamentowwds_13_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n168ClienteId ;
      private bool n220IntermediadorClienteId ;
      private bool n224FinanciamentoValor ;
      private bool n222IntermediadorClienteDocumento ;
      private bool n221IntermediadorClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private string AV65Companyname ;
      private string AV63Title ;
      private string AV62Phone ;
      private string AV60Mail ;
      private string AV64Website ;
      private string AV53AddressLine1 ;
      private string AV54AddressLine2 ;
      private string AV55AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterFinanciamentoValorDescription ;
      private string AV18ClienteDocumento1 ;
      private string AV19FilterClienteDocumentoDescription ;
      private string AV20ClienteDocumento ;
      private string AV21IntermediadorClienteDocumento1 ;
      private string AV22FilterIntermediadorClienteDocumentoDescription ;
      private string AV23IntermediadorClienteDocumento ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV28ClienteDocumento2 ;
      private string AV29IntermediadorClienteDocumento2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV34ClienteDocumento3 ;
      private string AV35IntermediadorClienteDocumento3 ;
      private string AV42TFClienteRazaoSocial_Sel ;
      private string AV41TFClienteRazaoSocial ;
      private string AV44TFClienteDocumento_Sel ;
      private string AV43TFClienteDocumento ;
      private string AV51TFFinanciamentoValor_To_Description ;
      private string AV48TFIntermediadorClienteRazaoSocial_Sel ;
      private string AV47TFIntermediadorClienteRazaoSocial ;
      private string AV50TFIntermediadorClienteDocumento_Sel ;
      private string AV49TFIntermediadorClienteDocumento ;
      private string AV69Financiamentowwds_1_filterfulltext ;
      private string AV70Financiamentowwds_2_dynamicfiltersselector1 ;
      private string AV73Financiamentowwds_5_clientedocumento1 ;
      private string AV74Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string AV76Financiamentowwds_8_dynamicfiltersselector2 ;
      private string AV79Financiamentowwds_11_clientedocumento2 ;
      private string AV80Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string AV82Financiamentowwds_14_dynamicfiltersselector3 ;
      private string AV85Financiamentowwds_17_clientedocumento3 ;
      private string AV86Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string AV87Financiamentowwds_19_tfclienterazaosocial ;
      private string AV88Financiamentowwds_20_tfclienterazaosocial_sel ;
      private string AV89Financiamentowwds_21_tfclientedocumento ;
      private string AV90Financiamentowwds_22_tfclientedocumento_sel ;
      private string AV93Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ;
      private string AV95Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel ;
      private string lV69Financiamentowwds_1_filterfulltext ;
      private string lV73Financiamentowwds_5_clientedocumento1 ;
      private string lV74Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string lV79Financiamentowwds_11_clientedocumento2 ;
      private string lV80Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string lV85Financiamentowwds_17_clientedocumento3 ;
      private string lV86Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string lV87Financiamentowwds_19_tfclienterazaosocial ;
      private string lV89Financiamentowwds_21_tfclientedocumento ;
      private string lV93Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string lV95Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A221IntermediadorClienteRazaoSocial ;
      private string A222IntermediadorClienteDocumento ;
      private string AV61PageInfo ;
      private string AV58DateInfo ;
      private string AV56AppName ;
      private IGxSession AV37Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00762_A168ClienteId ;
      private bool[] P00762_n168ClienteId ;
      private int[] P00762_A220IntermediadorClienteId ;
      private bool[] P00762_n220IntermediadorClienteId ;
      private decimal[] P00762_A224FinanciamentoValor ;
      private bool[] P00762_n224FinanciamentoValor ;
      private string[] P00762_A222IntermediadorClienteDocumento ;
      private bool[] P00762_n222IntermediadorClienteDocumento ;
      private string[] P00762_A221IntermediadorClienteRazaoSocial ;
      private bool[] P00762_n221IntermediadorClienteRazaoSocial ;
      private string[] P00762_A169ClienteDocumento ;
      private bool[] P00762_n169ClienteDocumento ;
      private string[] P00762_A170ClienteRazaoSocial ;
      private bool[] P00762_n170ClienteRazaoSocial ;
      private int[] P00762_A223FinanciamentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
   }

   public class financiamentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00762( IGxContext context ,
                                             string AV69Financiamentowwds_1_filterfulltext ,
                                             string AV70Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV71Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV72Financiamentowwds_4_financiamentovalor1 ,
                                             string AV73Financiamentowwds_5_clientedocumento1 ,
                                             string AV74Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV75Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV76Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV77Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV78Financiamentowwds_10_financiamentovalor2 ,
                                             string AV79Financiamentowwds_11_clientedocumento2 ,
                                             string AV80Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV81Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV82Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV83Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV84Financiamentowwds_16_financiamentovalor3 ,
                                             string AV85Financiamentowwds_17_clientedocumento3 ,
                                             string AV86Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV88Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV87Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV90Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV89Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV91Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV92Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV93Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV95Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[36];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.IntermediadorClienteId AS IntermediadorClienteId, T1.FinanciamentoValor, T3.ClienteDocumento AS IntermediadorClienteDocumento, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T2.ClienteDocumento, T2.ClienteRazaoSocial, T1.FinanciamentoId FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.IntermediadorClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV69Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV69Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV69Financiamentowwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV69Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV69Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV72Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV72Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV72Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV72Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV72Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV72Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV73Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV73Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV74Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV71Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV74Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV78Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV78Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV78Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV78Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV78Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV78Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV79Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV79Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV80Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV75Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV77Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV80Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV84Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV84Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV84Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV85Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV85Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV86Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( AV81Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV83Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV86Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV87Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV88Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV88Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV89Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV90Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV90Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV91Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV91Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV92Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV93Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV95Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.FinanciamentoValor";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.FinanciamentoValor DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ClienteRazaoSocial";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ClienteRazaoSocial DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ClienteDocumento";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ClienteDocumento DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteDocumento";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteDocumento DESC";
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
                     return conditional_P00762(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmP00762;
          prmP00762 = new Object[] {
          new ParDef("lV69Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV72Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV72Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV72Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV73Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV74Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV74Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV78Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV79Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV80Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV80Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV84Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV84Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV84Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV85Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV85Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV86Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV86Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV87Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV88Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV89Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV90Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV91Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV92Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV93Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV94Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV95Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV96Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00762", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00762,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
