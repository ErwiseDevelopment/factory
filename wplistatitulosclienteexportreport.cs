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
   public class wplistatitulosclienteexportreport : GXWebProcedure
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

      public wplistatitulosclienteexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistatitulosclienteexportreport( IGxContext context )
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
         setOutputFileName("WpListaTitulosClienteExportReport");
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
            AV70Title = "Lista de Titulo";
            GXt_char1 = AV72Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV72Companyname = GXt_char1;
            GXt_char1 = AV69Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV69Phone = GXt_char1;
            GXt_char1 = AV67Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV67Mail = GXt_char1;
            GXt_char1 = AV71Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV71Website = GXt_char1;
            GXt_char1 = AV60AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV60AddressLine1 = GXt_char1;
            GXt_char1 = AV61AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV61AddressLine2 = GXt_char1;
            GXt_char1 = AV62AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV62AddressLine3 = GXt_char1;
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
            HDI0( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV17TituloValor1 = NumberUtil.Val( AV28GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV17TituloValor1) )
               {
                  if ( AV16DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV16DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV16DynamicFiltersOperator1 == 2 )
                  {
                     AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                  }
                  AV19TituloValor = AV17TituloValor1;
                  HDI0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterTituloValorDescription, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV23TituloValor2 = NumberUtil.Val( AV28GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV23TituloValor2) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 2 )
                     {
                        AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV19TituloValor = AV23TituloValor2;
                     HDI0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterTituloValorDescription, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV27TituloValor3 = NumberUtil.Val( AV28GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV27TituloValor3) )
                     {
                        if ( AV26DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV26DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV26DynamicFiltersOperator3 == 2 )
                        {
                           AV18FilterTituloValorDescription = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                        }
                        AV19TituloValor = AV27TituloValor3;
                        HDI0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterTituloValorDescription, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTituloId) && (0==AV35TFTituloId_To) ) )
         {
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Titulo", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFTituloId), "ZZZZZZZZ9")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFTituloId_To_Description = StringUtil.Format( "%1 (%2)", "Titulo", "Até", "", "", "", "", "", "", "");
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFTituloId_To_Description, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFTituloId_To), "ZZZZZZZZ9")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV36TFTituloValor) && (Convert.ToDecimal(0)==AV37TFTituloValor_To) ) )
         {
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Valor", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36TFTituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV53TFTituloValor_To_Description = StringUtil.Format( "%1 (%2)", "Valor", "Até", "", "", "", "", "", "", "");
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFTituloValor_To_Description, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37TFTituloValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV38TFTituloDesconto) && (Convert.ToDecimal(0)==AV39TFTituloDesconto_To) ) )
         {
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Desconto", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38TFTituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV54TFTituloDesconto_To_Description = StringUtil.Format( "%1 (%2)", "Desconto", "Até", "", "", "", "", "", "", "");
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFTituloDesconto_To_Description, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TFTituloDesconto_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTituloCompetencia_F_Sel)) )
         {
            AV58TempBoolean = (bool)(((StringUtil.StrCmp(AV41TFTituloCompetencia_F_Sel, "<#Empty#>")==0)));
            AV41TFTituloCompetencia_F_Sel = (AV58TempBoolean ? "(Vazio)" : AV41TFTituloCompetencia_F_Sel);
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Competência", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFTituloCompetencia_F_Sel, "")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFTituloCompetencia_F_Sel = (AV58TempBoolean ? "<#Empty#>" : AV41TFTituloCompetencia_F_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTituloCompetencia_F)) )
            {
               HDI0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Competência", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFTituloCompetencia_F, "")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV42TFTituloProrrogacao) && (DateTime.MinValue==AV43TFTituloProrrogacao_To) ) )
         {
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Vencimento", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV42TFTituloProrrogacao, "99/99/9999"), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV55TFTituloProrrogacao_To_Description = StringUtil.Format( "%1 (%2)", "Vencimento", "Até", "", "", "", "", "", "", "");
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFTituloProrrogacao_To_Description, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV43TFTituloProrrogacao_To, "99/99/9999"), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV47TFTituloTipo_Sels.FromJSonString(AV44TFTituloTipo_SelsJson, null);
         if ( ! ( AV47TFTituloTipo_Sels.Count == 0 ) )
         {
            AV59i = 1;
            AV75GXV1 = 1;
            while ( AV75GXV1 <= AV47TFTituloTipo_Sels.Count )
            {
               AV46TFTituloTipo_Sel = ((string)AV47TFTituloTipo_Sels.Item(AV75GXV1));
               if ( AV59i == 1 )
               {
                  AV45TFTituloTipo_SelDscs = "";
               }
               else
               {
                  AV45TFTituloTipo_SelDscs += ", ";
               }
               AV56FilterTFTituloTipo_SelValueDescription = gxdomaindmtitulodc.getDescription(context,AV46TFTituloTipo_Sel);
               AV45TFTituloTipo_SelDscs += AV56FilterTFTituloTipo_SelValueDescription;
               AV59i = (long)(AV59i+1);
               AV75GXV1 = (int)(AV75GXV1+1);
            }
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFTituloTipo_SelDscs, "")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV48TFTituloSaldo_F) && (Convert.ToDecimal(0)==AV49TFTituloSaldo_F_To) ) )
         {
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TFTituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV57TFTituloSaldo_F_To_Description = StringUtil.Format( "%1 (%2)", "Saldo", "Até", "", "", "", "", "", "", "");
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFTituloSaldo_F_To_Description, "")), 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TFTituloSaldo_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTituloStatus_F_Sel)) )
         {
            AV58TempBoolean = (bool)(((StringUtil.StrCmp(AV51TFTituloStatus_F_Sel, "<#Empty#>")==0)));
            AV51TFTituloStatus_F_Sel = (AV58TempBoolean ? "(Vazio)" : AV51TFTituloStatus_F_Sel);
            HDI0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Situação", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFTituloStatus_F_Sel, "")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFTituloStatus_F_Sel = (AV58TempBoolean ? "<#Empty#>" : AV51TFTituloStatus_F_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTituloStatus_F)) )
            {
               HDI0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Situação", 25, Gx_line+0, 135, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFTituloStatus_F, "")), 135, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HDI0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HDI0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Titulo", 30, Gx_line+10, 96, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Valor", 100, Gx_line+10, 166, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Desconto", 170, Gx_line+10, 236, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Competência", 240, Gx_line+10, 372, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Vencimento", 376, Gx_line+10, 442, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 446, Gx_line+10, 578, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Saldo", 582, Gx_line+10, 649, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Situação", 653, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV77Wplistatitulosclienteds_1_clienteid = AV10ClienteId;
         AV78Wplistatitulosclienteds_2_filterfulltext = AV14FilterFullText;
         AV79Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV81Wplistatitulosclienteds_5_titulovalor1 = AV17TituloValor1;
         AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV83Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV85Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV87Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV89Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV90Wplistatitulosclienteds_14_tftituloid = AV34TFTituloId;
         AV91Wplistatitulosclienteds_15_tftituloid_to = AV35TFTituloId_To;
         AV92Wplistatitulosclienteds_16_tftitulovalor = AV36TFTituloValor;
         AV93Wplistatitulosclienteds_17_tftitulovalor_to = AV37TFTituloValor_To;
         AV94Wplistatitulosclienteds_18_tftitulodesconto = AV38TFTituloDesconto;
         AV95Wplistatitulosclienteds_19_tftitulodesconto_to = AV39TFTituloDesconto_To;
         AV96Wplistatitulosclienteds_20_tftitulocompetencia_f = AV40TFTituloCompetencia_F;
         AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV41TFTituloCompetencia_F_Sel;
         AV98Wplistatitulosclienteds_22_tftituloprorrogacao = AV42TFTituloProrrogacao;
         AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV43TFTituloProrrogacao_To;
         AV100Wplistatitulosclienteds_24_tftitulotipo_sels = AV47TFTituloTipo_Sels;
         AV101Wplistatitulosclienteds_25_tftitulosaldo_f = AV48TFTituloSaldo_F;
         AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV49TFTituloSaldo_F_To;
         AV103Wplistatitulosclienteds_27_tftitulostatus_f = AV50TFTituloStatus_F;
         AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV51TFTituloStatus_F_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV100Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                              AV79Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                              AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                              AV81Wplistatitulosclienteds_5_titulovalor1 ,
                                              AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                              AV83Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                              AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                              AV85Wplistatitulosclienteds_9_titulovalor2 ,
                                              AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                              AV87Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                              AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                              AV89Wplistatitulosclienteds_13_titulovalor3 ,
                                              AV90Wplistatitulosclienteds_14_tftituloid ,
                                              AV91Wplistatitulosclienteds_15_tftituloid_to ,
                                              AV92Wplistatitulosclienteds_16_tftitulovalor ,
                                              AV93Wplistatitulosclienteds_17_tftitulovalor_to ,
                                              AV94Wplistatitulosclienteds_18_tftitulodesconto ,
                                              AV95Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                              AV98Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                              AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                              AV100Wplistatitulosclienteds_24_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A261TituloId ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV78Wplistatitulosclienteds_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                              AV96Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                              AV101Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                              AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                              AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                              AV103Wplistatitulosclienteds_27_tftitulostatus_f ,
                                              A284TituloDeleted ,
                                              A168ClienteId ,
                                              AV77Wplistatitulosclienteds_1_clienteid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV103Wplistatitulosclienteds_27_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV103Wplistatitulosclienteds_27_tftitulostatus_f), "%", "");
         /* Using cursor P00DI4 */
         pr_default.execute(0, new Object[] {AV101Wplistatitulosclienteds_25_tftitulosaldo_f, AV101Wplistatitulosclienteds_25_tftitulosaldo_f, AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV103Wplistatitulosclienteds_27_tftitulostatus_f, lV103Wplistatitulosclienteds_27_tftitulostatus_f, AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV77Wplistatitulosclienteds_1_clienteid, AV81Wplistatitulosclienteds_5_titulovalor1, AV81Wplistatitulosclienteds_5_titulovalor1, AV81Wplistatitulosclienteds_5_titulovalor1, AV85Wplistatitulosclienteds_9_titulovalor2, AV85Wplistatitulosclienteds_9_titulovalor2, AV85Wplistatitulosclienteds_9_titulovalor2, AV89Wplistatitulosclienteds_13_titulovalor3, AV89Wplistatitulosclienteds_13_titulovalor3, AV89Wplistatitulosclienteds_13_titulovalor3, AV90Wplistatitulosclienteds_14_tftituloid, AV91Wplistatitulosclienteds_15_tftituloid_to, AV92Wplistatitulosclienteds_16_tftitulovalor, AV93Wplistatitulosclienteds_17_tftitulovalor_to, AV94Wplistatitulosclienteds_18_tftitulodesconto, AV95Wplistatitulosclienteds_19_tftitulodesconto_to, AV98Wplistatitulosclienteds_22_tftituloprorrogacao, AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00DI4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00DI4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00DI4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DI4_n794NotaFiscalId[0];
            A284TituloDeleted = P00DI4_A284TituloDeleted[0];
            n284TituloDeleted = P00DI4_n284TituloDeleted[0];
            A264TituloProrrogacao = P00DI4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00DI4_n264TituloProrrogacao[0];
            A276TituloDesconto = P00DI4_A276TituloDesconto[0];
            n276TituloDesconto = P00DI4_n276TituloDesconto[0];
            A261TituloId = P00DI4_A261TituloId[0];
            n261TituloId = P00DI4_n261TituloId[0];
            A282TituloStatus_F = P00DI4_A282TituloStatus_F[0];
            A283TituloTipo = P00DI4_A283TituloTipo[0];
            n283TituloTipo = P00DI4_n283TituloTipo[0];
            A168ClienteId = P00DI4_A168ClienteId[0];
            n168ClienteId = P00DI4_n168ClienteId[0];
            A275TituloSaldo_F = P00DI4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00DI4_n275TituloSaldo_F[0];
            A262TituloValor = P00DI4_A262TituloValor[0];
            n262TituloValor = P00DI4_n262TituloValor[0];
            A286TituloCompetenciaAno = P00DI4_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00DI4_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00DI4_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00DI4_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00DI4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DI4_n794NotaFiscalId[0];
            A168ClienteId = P00DI4_A168ClienteId[0];
            n168ClienteId = P00DI4_n168ClienteId[0];
            A275TituloSaldo_F = P00DI4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00DI4_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wplistatitulosclienteds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A261TituloId), 9, 0) , StringUtil.PadR( "%" + AV78Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV78Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV78Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV78Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV78Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV78Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV78Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV78Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wplistatitulosclienteds_20_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV96Wplistatitulosclienteds_20_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV29TituloTipoDescription = gxdomaindmtitulodc.getDescription(context,A283TituloTipo);
                        /* Execute user subroutine: 'BEFOREPRINTLINE' */
                        S144 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                        HDI0( false, 36) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")), 30, Gx_line+10, 96, Gx_line+25, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 100, Gx_line+10, 166, Gx_line+25, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 170, Gx_line+10, 236, Gx_line+25, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A295TituloCompetencia_F, "")), 240, Gx_line+10, 372, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"), 376, Gx_line+10, 442, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29TituloTipoDescription, "")), 446, Gx_line+10, 578, Gx_line+25, 0+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 582, Gx_line+10, 649, Gx_line+25, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A282TituloStatus_F, "")), 653, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("WpListaTitulosClienteGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpListaTitulosClienteGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WpListaTitulosClienteGridState"), null, "", "");
         }
         AV12OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV13OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV105GXV2 = 1;
         while ( AV105GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV105GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOID") == 0 )
            {
               AV34TFTituloId = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFTituloId_To = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV36TFTituloValor = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV37TFTituloValor_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV38TFTituloDesconto = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV39TFTituloDesconto_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV40TFTituloCompetencia_F = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV41TFTituloCompetencia_F_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV42TFTituloProrrogacao = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 4);
               AV43TFTituloProrrogacao_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV44TFTituloTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV47TFTituloTipo_Sels.FromJSonString(AV44TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOSALDO_F") == 0 )
            {
               AV48TFTituloSaldo_F = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV49TFTituloSaldo_F_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F") == 0 )
            {
               AV50TFTituloStatus_F = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F_SEL") == 0 )
            {
               AV51TFTituloStatus_F_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV10ClienteId = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTERAZAOSOCIAL") == 0 )
            {
               AV11ClienteRazaoSocial = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV105GXV2 = (int)(AV105GXV2+1);
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

      protected void HDI0( bool bFoot ,
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
                  AV68PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV65DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV70Title = "";
         AV72Companyname = "";
         AV69Phone = "";
         AV67Mail = "";
         AV71Website = "";
         AV60AddressLine1 = "";
         AV61AddressLine2 = "";
         AV62AddressLine3 = "";
         GXt_char1 = "";
         AV14FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV15DynamicFiltersSelector1 = "";
         AV18FilterTituloValorDescription = "";
         AV21DynamicFiltersSelector2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV52TFTituloId_To_Description = "";
         AV53TFTituloValor_To_Description = "";
         AV54TFTituloDesconto_To_Description = "";
         AV41TFTituloCompetencia_F_Sel = "";
         AV40TFTituloCompetencia_F = "";
         AV42TFTituloProrrogacao = DateTime.MinValue;
         AV43TFTituloProrrogacao_To = DateTime.MinValue;
         AV55TFTituloProrrogacao_To_Description = "";
         AV47TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV44TFTituloTipo_SelsJson = "";
         AV46TFTituloTipo_Sel = "";
         AV45TFTituloTipo_SelDscs = "";
         AV56FilterTFTituloTipo_SelValueDescription = "";
         AV57TFTituloSaldo_F_To_Description = "";
         AV51TFTituloStatus_F_Sel = "";
         AV50TFTituloStatus_F = "";
         AV78Wplistatitulosclienteds_2_filterfulltext = "";
         AV79Wplistatitulosclienteds_3_dynamicfiltersselector1 = "";
         AV83Wplistatitulosclienteds_7_dynamicfiltersselector2 = "";
         AV87Wplistatitulosclienteds_11_dynamicfiltersselector3 = "";
         AV96Wplistatitulosclienteds_20_tftitulocompetencia_f = "";
         AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = "";
         AV98Wplistatitulosclienteds_22_tftituloprorrogacao = DateTime.MinValue;
         AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to = DateTime.MinValue;
         AV100Wplistatitulosclienteds_24_tftitulotipo_sels = new GxSimpleCollection<string>();
         AV103Wplistatitulosclienteds_27_tftitulostatus_f = "";
         AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel = "";
         lV78Wplistatitulosclienteds_2_filterfulltext = "";
         lV103Wplistatitulosclienteds_27_tftitulostatus_f = "";
         A283TituloTipo = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A282TituloStatus_F = "";
         P00DI4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00DI4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00DI4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DI4_n794NotaFiscalId = new bool[] {false} ;
         P00DI4_A284TituloDeleted = new bool[] {false} ;
         P00DI4_n284TituloDeleted = new bool[] {false} ;
         P00DI4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00DI4_n264TituloProrrogacao = new bool[] {false} ;
         P00DI4_A276TituloDesconto = new decimal[1] ;
         P00DI4_n276TituloDesconto = new bool[] {false} ;
         P00DI4_A261TituloId = new int[1] ;
         P00DI4_n261TituloId = new bool[] {false} ;
         P00DI4_A282TituloStatus_F = new string[] {""} ;
         P00DI4_A283TituloTipo = new string[] {""} ;
         P00DI4_n283TituloTipo = new bool[] {false} ;
         P00DI4_A168ClienteId = new int[1] ;
         P00DI4_n168ClienteId = new bool[] {false} ;
         P00DI4_A275TituloSaldo_F = new decimal[1] ;
         P00DI4_n275TituloSaldo_F = new bool[] {false} ;
         P00DI4_A262TituloValor = new decimal[1] ;
         P00DI4_n262TituloValor = new bool[] {false} ;
         P00DI4_A286TituloCompetenciaAno = new short[1] ;
         P00DI4_n286TituloCompetenciaAno = new bool[] {false} ;
         P00DI4_A287TituloCompetenciaMes = new short[1] ;
         P00DI4_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         AV29TituloTipoDescription = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV11ClienteRazaoSocial = "";
         AV68PageInfo = "";
         AV65DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV63AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistatitulosclienteexportreport__default(),
            new Object[][] {
                new Object[] {
               P00DI4_A890NotaFiscalParcelamentoID, P00DI4_n890NotaFiscalParcelamentoID, P00DI4_A794NotaFiscalId, P00DI4_n794NotaFiscalId, P00DI4_A284TituloDeleted, P00DI4_n284TituloDeleted, P00DI4_A264TituloProrrogacao, P00DI4_n264TituloProrrogacao, P00DI4_A276TituloDesconto, P00DI4_n276TituloDesconto,
               P00DI4_A261TituloId, P00DI4_A282TituloStatus_F, P00DI4_A283TituloTipo, P00DI4_n283TituloTipo, P00DI4_A168ClienteId, P00DI4_n168ClienteId, P00DI4_A275TituloSaldo_F, P00DI4_n275TituloSaldo_F, P00DI4_A262TituloValor, P00DI4_n262TituloValor,
               P00DI4_A286TituloCompetenciaAno, P00DI4_n286TituloCompetenciaAno, P00DI4_A287TituloCompetenciaMes, P00DI4_n287TituloCompetenciaMes
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
      private short AV16DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 ;
      private short AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 ;
      private short AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 ;
      private short AV12OrderedBy ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV34TFTituloId ;
      private int AV35TFTituloId_To ;
      private int AV75GXV1 ;
      private int AV77Wplistatitulosclienteds_1_clienteid ;
      private int AV10ClienteId ;
      private int AV90Wplistatitulosclienteds_14_tftituloid ;
      private int AV91Wplistatitulosclienteds_15_tftituloid_to ;
      private int AV100Wplistatitulosclienteds_24_tftitulotipo_sels_Count ;
      private int A261TituloId ;
      private int A168ClienteId ;
      private int AV105GXV2 ;
      private long AV59i ;
      private decimal AV17TituloValor1 ;
      private decimal AV19TituloValor ;
      private decimal AV23TituloValor2 ;
      private decimal AV27TituloValor3 ;
      private decimal AV36TFTituloValor ;
      private decimal AV37TFTituloValor_To ;
      private decimal AV38TFTituloDesconto ;
      private decimal AV39TFTituloDesconto_To ;
      private decimal AV48TFTituloSaldo_F ;
      private decimal AV49TFTituloSaldo_F_To ;
      private decimal AV81Wplistatitulosclienteds_5_titulovalor1 ;
      private decimal AV85Wplistatitulosclienteds_9_titulovalor2 ;
      private decimal AV89Wplistatitulosclienteds_13_titulovalor3 ;
      private decimal AV92Wplistatitulosclienteds_16_tftitulovalor ;
      private decimal AV93Wplistatitulosclienteds_17_tftitulovalor_to ;
      private decimal AV94Wplistatitulosclienteds_18_tftitulodesconto ;
      private decimal AV95Wplistatitulosclienteds_19_tftitulodesconto_to ;
      private decimal AV101Wplistatitulosclienteds_25_tftitulosaldo_f ;
      private decimal AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A275TituloSaldo_F ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime AV42TFTituloProrrogacao ;
      private DateTime AV43TFTituloProrrogacao_To ;
      private DateTime AV98Wplistatitulosclienteds_22_tftituloprorrogacao ;
      private DateTime AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV58TempBoolean ;
      private bool AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 ;
      private bool AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 ;
      private bool AV13OrderedDsc ;
      private bool A284TituloDeleted ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n284TituloDeleted ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n261TituloId ;
      private bool n283TituloTipo ;
      private bool n168ClienteId ;
      private bool n275TituloSaldo_F ;
      private bool n262TituloValor ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private string AV72Companyname ;
      private string AV44TFTituloTipo_SelsJson ;
      private string AV70Title ;
      private string AV69Phone ;
      private string AV67Mail ;
      private string AV71Website ;
      private string AV60AddressLine1 ;
      private string AV61AddressLine2 ;
      private string AV62AddressLine3 ;
      private string AV14FilterFullText ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV18FilterTituloValorDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV52TFTituloId_To_Description ;
      private string AV53TFTituloValor_To_Description ;
      private string AV54TFTituloDesconto_To_Description ;
      private string AV41TFTituloCompetencia_F_Sel ;
      private string AV40TFTituloCompetencia_F ;
      private string AV55TFTituloProrrogacao_To_Description ;
      private string AV46TFTituloTipo_Sel ;
      private string AV45TFTituloTipo_SelDscs ;
      private string AV56FilterTFTituloTipo_SelValueDescription ;
      private string AV57TFTituloSaldo_F_To_Description ;
      private string AV51TFTituloStatus_F_Sel ;
      private string AV50TFTituloStatus_F ;
      private string AV78Wplistatitulosclienteds_2_filterfulltext ;
      private string AV79Wplistatitulosclienteds_3_dynamicfiltersselector1 ;
      private string AV83Wplistatitulosclienteds_7_dynamicfiltersselector2 ;
      private string AV87Wplistatitulosclienteds_11_dynamicfiltersselector3 ;
      private string AV96Wplistatitulosclienteds_20_tftitulocompetencia_f ;
      private string AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ;
      private string AV103Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel ;
      private string lV78Wplistatitulosclienteds_2_filterfulltext ;
      private string lV103Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string A283TituloTipo ;
      private string A295TituloCompetencia_F ;
      private string A282TituloStatus_F ;
      private string AV29TituloTipoDescription ;
      private string AV11ClienteRazaoSocial ;
      private string AV68PageInfo ;
      private string AV65DateInfo ;
      private string AV63AppName ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV47TFTituloTipo_Sels ;
      private GxSimpleCollection<string> AV100Wplistatitulosclienteds_24_tftitulotipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DI4_A890NotaFiscalParcelamentoID ;
      private bool[] P00DI4_n890NotaFiscalParcelamentoID ;
      private Guid[] P00DI4_A794NotaFiscalId ;
      private bool[] P00DI4_n794NotaFiscalId ;
      private bool[] P00DI4_A284TituloDeleted ;
      private bool[] P00DI4_n284TituloDeleted ;
      private DateTime[] P00DI4_A264TituloProrrogacao ;
      private bool[] P00DI4_n264TituloProrrogacao ;
      private decimal[] P00DI4_A276TituloDesconto ;
      private bool[] P00DI4_n276TituloDesconto ;
      private int[] P00DI4_A261TituloId ;
      private bool[] P00DI4_n261TituloId ;
      private string[] P00DI4_A282TituloStatus_F ;
      private string[] P00DI4_A283TituloTipo ;
      private bool[] P00DI4_n283TituloTipo ;
      private int[] P00DI4_A168ClienteId ;
      private bool[] P00DI4_n168ClienteId ;
      private decimal[] P00DI4_A275TituloSaldo_F ;
      private bool[] P00DI4_n275TituloSaldo_F ;
      private decimal[] P00DI4_A262TituloValor ;
      private bool[] P00DI4_n262TituloValor ;
      private short[] P00DI4_A286TituloCompetenciaAno ;
      private bool[] P00DI4_n286TituloCompetenciaAno ;
      private short[] P00DI4_A287TituloCompetenciaMes ;
      private bool[] P00DI4_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class wplistatitulosclienteexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DI4( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV100Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                             string AV79Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                             short AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                             decimal AV81Wplistatitulosclienteds_5_titulovalor1 ,
                                             bool AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                             string AV83Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                             short AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                             decimal AV85Wplistatitulosclienteds_9_titulovalor2 ,
                                             bool AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                             string AV87Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                             short AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                             decimal AV89Wplistatitulosclienteds_13_titulovalor3 ,
                                             int AV90Wplistatitulosclienteds_14_tftituloid ,
                                             int AV91Wplistatitulosclienteds_15_tftituloid_to ,
                                             decimal AV92Wplistatitulosclienteds_16_tftitulovalor ,
                                             decimal AV93Wplistatitulosclienteds_17_tftitulovalor_to ,
                                             decimal AV94Wplistatitulosclienteds_18_tftitulodesconto ,
                                             decimal AV95Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                             DateTime AV98Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                             DateTime AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                             int AV100Wplistatitulosclienteds_24_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             int A261TituloId ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV78Wplistatitulosclienteds_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV97Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                             string AV96Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                             decimal AV101Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                             decimal AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                             string AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                             string AV103Wplistatitulosclienteds_27_tftitulostatus_f ,
                                             bool A284TituloDeleted ,
                                             int A168ClienteId ,
                                             int AV77Wplistatitulosclienteds_1_clienteid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[29];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloDeleted, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloId, CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T3.ClienteId, COALESCE( T4.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) INNER JOIN (SELECT ( COALESCE( T5.TituloValor, 0) - COALESCE( T5.TituloDesconto, 0)) - COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T5.TituloId FROM (Titulo T5 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T5.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = T5.TituloId) ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV101Wplistatitulosclienteds_25_tftitulosaldo_f = 0) or ( COALESCE( T4.TituloSaldo_F, 0) >= :AV101Wplistatitulosclienteds_25_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to = 0) or ( COALESCE( T4.TituloSaldo_F, 0) <= :AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV103Wplistatitulosclienteds_27_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV103Wplistatitulosclienteds_27_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and Not :AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(T3.ClienteId = :AV77Wplistatitulosclienteds_1_clienteid)");
         if ( ( StringUtil.StrCmp(AV79Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV81Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV81Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV81Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV81Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV80Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV81Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV81Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV85Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV85Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV85Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV85Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV82Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV84Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV85Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV85Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV89Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV89Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV89Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV89Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV86Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV88Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV89Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV89Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (0==AV90Wplistatitulosclienteds_14_tftituloid) )
         {
            AddWhere(sWhereString, "(T1.TituloId >= :AV90Wplistatitulosclienteds_14_tftituloid)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (0==AV91Wplistatitulosclienteds_15_tftituloid_to) )
         {
            AddWhere(sWhereString, "(T1.TituloId <= :AV91Wplistatitulosclienteds_15_tftituloid_to)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Wplistatitulosclienteds_16_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV92Wplistatitulosclienteds_16_tftitulovalor)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Wplistatitulosclienteds_17_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV93Wplistatitulosclienteds_17_tftitulovalor_to)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV94Wplistatitulosclienteds_18_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV94Wplistatitulosclienteds_18_tftitulodesconto)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV95Wplistatitulosclienteds_19_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV95Wplistatitulosclienteds_19_tftitulodesconto_to)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Wplistatitulosclienteds_22_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV98Wplistatitulosclienteds_22_tftituloprorrogacao)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( AV100Wplistatitulosclienteds_24_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wplistatitulosclienteds_24_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV12OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.TituloCompetenciaAno DESC, T1.TituloCompetenciaMes DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloId DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloValor";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloValor DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloDesconto";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloDesconto DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloProrrogacao";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloProrrogacao DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloTipo";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloTipo DESC";
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
                     return conditional_P00DI4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] );
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
          Object[] prmP00DI4;
          prmP00DI4 = new Object[] {
          new ParDef("AV101Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV101Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV102Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV103Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV103Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV104Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV77Wplistatitulosclienteds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("AV81Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV81Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV81Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV85Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV85Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV85Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV89Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV89Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV89Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV90Wplistatitulosclienteds_14_tftituloid",GXType.Int32,9,0) ,
          new ParDef("AV91Wplistatitulosclienteds_15_tftituloid_to",GXType.Int32,9,0) ,
          new ParDef("AV92Wplistatitulosclienteds_16_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV93Wplistatitulosclienteds_17_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV94Wplistatitulosclienteds_18_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV95Wplistatitulosclienteds_19_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV98Wplistatitulosclienteds_22_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV99Wplistatitulosclienteds_23_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DI4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DI4,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((short[]) buf[22])[0] = rslt.getShort(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
