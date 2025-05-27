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
   public class profissaowwexportreport : GXWebProcedure
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

      public profissaowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profissaowwexportreport( IGxContext context )
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
         setOutputFileName("ProfissaoWWExportReport");
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
            AV47Title = "Lista de Profissao";
            GXt_char1 = AV49Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV49Companyname = GXt_char1;
            GXt_char1 = AV46Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV46Phone = GXt_char1;
            GXt_char1 = AV44Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV44Mail = GXt_char1;
            GXt_char1 = AV48Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV48Website = GXt_char1;
            GXt_char1 = AV37AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV37AddressLine1 = GXt_char1;
            GXt_char1 = AV38AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV38AddressLine2 = GXt_char1;
            GXt_char1 = AV39AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV39AddressLine3 = GXt_char1;
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
            HA80( true, 0) ;
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
            HA80( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "PROFISSAONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15ProfissaoNome1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ProfissaoNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17ProfissaoNome = AV15ProfissaoNome1;
                  HA80( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterProfissaoNomeDescription, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ProfissaoNome, "@!")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "PROFISSAONOME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21ProfissaoNome2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ProfissaoNome2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17ProfissaoNome = AV21ProfissaoNome2;
                     HA80( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterProfissaoNomeDescription, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ProfissaoNome, "@!")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "PROFISSAONOME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25ProfissaoNome3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ProfissaoNome3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterProfissaoNomeDescription = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17ProfissaoNome = AV25ProfissaoNome3;
                        HA80( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterProfissaoNomeDescription, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ProfissaoNome, "@!")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFProfissaoId) && (0==AV32TFProfissaoId_To) ) )
         {
            HA80( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Id", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFProfissaoId), "ZZZZZZZZ9")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFProfissaoId_To_Description = StringUtil.Format( "%1 (%2)", "Id", "Até", "", "", "", "", "", "", "");
            HA80( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFProfissaoId_To_Description, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFProfissaoId_To), "ZZZZZZZZ9")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFProfissaoNome_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFProfissaoNome_Sel, "<#Empty#>")==0)));
            AV34TFProfissaoNome_Sel = (AV36TempBoolean ? "(Vazio)" : AV34TFProfissaoNome_Sel);
            HA80( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFProfissaoNome_Sel, "@!")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFProfissaoNome_Sel = (AV36TempBoolean ? "<#Empty#>" : AV34TFProfissaoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFProfissaoNome)) )
            {
               HA80( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFProfissaoNome, "@!")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HA80( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HA80( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Id", 30, Gx_line+10, 281, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome", 285, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV53Profissaowwds_1_filterfulltext = AV12FilterFullText;
         AV54Profissaowwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV55Profissaowwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV56Profissaowwds_4_profissaonome1 = AV15ProfissaoNome1;
         AV57Profissaowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV58Profissaowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV59Profissaowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV60Profissaowwds_8_profissaonome2 = AV21ProfissaoNome2;
         AV61Profissaowwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV62Profissaowwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV63Profissaowwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV64Profissaowwds_12_profissaonome3 = AV25ProfissaoNome3;
         AV65Profissaowwds_13_tfprofissaoid = AV31TFProfissaoId;
         AV66Profissaowwds_14_tfprofissaoid_to = AV32TFProfissaoId_To;
         AV67Profissaowwds_15_tfprofissaonome = AV33TFProfissaoNome;
         AV68Profissaowwds_16_tfprofissaonome_sel = AV34TFProfissaoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Profissaowwds_1_filterfulltext ,
                                              AV54Profissaowwds_2_dynamicfiltersselector1 ,
                                              AV55Profissaowwds_3_dynamicfiltersoperator1 ,
                                              AV56Profissaowwds_4_profissaonome1 ,
                                              AV57Profissaowwds_5_dynamicfiltersenabled2 ,
                                              AV58Profissaowwds_6_dynamicfiltersselector2 ,
                                              AV59Profissaowwds_7_dynamicfiltersoperator2 ,
                                              AV60Profissaowwds_8_profissaonome2 ,
                                              AV61Profissaowwds_9_dynamicfiltersenabled3 ,
                                              AV62Profissaowwds_10_dynamicfiltersselector3 ,
                                              AV63Profissaowwds_11_dynamicfiltersoperator3 ,
                                              AV64Profissaowwds_12_profissaonome3 ,
                                              AV65Profissaowwds_13_tfprofissaoid ,
                                              AV66Profissaowwds_14_tfprofissaoid_to ,
                                              AV68Profissaowwds_16_tfprofissaonome_sel ,
                                              AV67Profissaowwds_15_tfprofissaonome ,
                                              A440ProfissaoId ,
                                              A441ProfissaoNome ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Profissaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Profissaowwds_1_filterfulltext), "%", "");
         lV53Profissaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Profissaowwds_1_filterfulltext), "%", "");
         lV56Profissaowwds_4_profissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV56Profissaowwds_4_profissaonome1), "%", "");
         lV56Profissaowwds_4_profissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV56Profissaowwds_4_profissaonome1), "%", "");
         lV60Profissaowwds_8_profissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV60Profissaowwds_8_profissaonome2), "%", "");
         lV60Profissaowwds_8_profissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV60Profissaowwds_8_profissaonome2), "%", "");
         lV64Profissaowwds_12_profissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV64Profissaowwds_12_profissaonome3), "%", "");
         lV64Profissaowwds_12_profissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV64Profissaowwds_12_profissaonome3), "%", "");
         lV67Profissaowwds_15_tfprofissaonome = StringUtil.Concat( StringUtil.RTrim( AV67Profissaowwds_15_tfprofissaonome), "%", "");
         /* Using cursor P00A82 */
         pr_default.execute(0, new Object[] {lV53Profissaowwds_1_filterfulltext, lV53Profissaowwds_1_filterfulltext, lV56Profissaowwds_4_profissaonome1, lV56Profissaowwds_4_profissaonome1, lV60Profissaowwds_8_profissaonome2, lV60Profissaowwds_8_profissaonome2, lV64Profissaowwds_12_profissaonome3, lV64Profissaowwds_12_profissaonome3, AV65Profissaowwds_13_tfprofissaoid, AV66Profissaowwds_14_tfprofissaoid_to, lV67Profissaowwds_15_tfprofissaonome, AV68Profissaowwds_16_tfprofissaonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A440ProfissaoId = P00A82_A440ProfissaoId[0];
            A441ProfissaoNome = P00A82_A441ProfissaoNome[0];
            n441ProfissaoNome = P00A82_n441ProfissaoNome[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HA80( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A440ProfissaoId), "ZZZZZZZZ9")), 30, Gx_line+10, 281, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A441ProfissaoNome, "@!")), 285, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("ProfissaoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfissaoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("ProfissaoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROFISSAOID") == 0 )
            {
               AV31TFProfissaoId = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV32TFProfissaoId_To = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROFISSAONOME") == 0 )
            {
               AV33TFProfissaoNome = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROFISSAONOME_SEL") == 0 )
            {
               AV34TFProfissaoNome_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV69GXV1 = (int)(AV69GXV1+1);
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

      protected void HA80( bool bFoot ,
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
                  AV45PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV42DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV47Title = "";
         AV49Companyname = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ProfissaoNome1 = "";
         AV16FilterProfissaoNomeDescription = "";
         AV17ProfissaoNome = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ProfissaoNome2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ProfissaoNome3 = "";
         AV35TFProfissaoId_To_Description = "";
         AV34TFProfissaoNome_Sel = "";
         AV33TFProfissaoNome = "";
         AV53Profissaowwds_1_filterfulltext = "";
         AV54Profissaowwds_2_dynamicfiltersselector1 = "";
         AV56Profissaowwds_4_profissaonome1 = "";
         AV58Profissaowwds_6_dynamicfiltersselector2 = "";
         AV60Profissaowwds_8_profissaonome2 = "";
         AV62Profissaowwds_10_dynamicfiltersselector3 = "";
         AV64Profissaowwds_12_profissaonome3 = "";
         AV67Profissaowwds_15_tfprofissaonome = "";
         AV68Profissaowwds_16_tfprofissaonome_sel = "";
         lV53Profissaowwds_1_filterfulltext = "";
         lV56Profissaowwds_4_profissaonome1 = "";
         lV60Profissaowwds_8_profissaonome2 = "";
         lV64Profissaowwds_12_profissaonome3 = "";
         lV67Profissaowwds_15_tfprofissaonome = "";
         A441ProfissaoNome = "";
         P00A82_A440ProfissaoId = new int[1] ;
         P00A82_A441ProfissaoNome = new string[] {""} ;
         P00A82_n441ProfissaoNome = new bool[] {false} ;
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profissaowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00A82_A440ProfissaoId, P00A82_A441ProfissaoNome, P00A82_n441ProfissaoNome
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
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV55Profissaowwds_3_dynamicfiltersoperator1 ;
      private short AV59Profissaowwds_7_dynamicfiltersoperator2 ;
      private short AV63Profissaowwds_11_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFProfissaoId ;
      private int AV32TFProfissaoId_To ;
      private int AV65Profissaowwds_13_tfprofissaoid ;
      private int AV66Profissaowwds_14_tfprofissaoid_to ;
      private int A440ProfissaoId ;
      private int AV69GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV57Profissaowwds_5_dynamicfiltersenabled2 ;
      private bool AV61Profissaowwds_9_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n441ProfissaoNome ;
      private string AV49Companyname ;
      private string AV47Title ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15ProfissaoNome1 ;
      private string AV16FilterProfissaoNomeDescription ;
      private string AV17ProfissaoNome ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21ProfissaoNome2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25ProfissaoNome3 ;
      private string AV35TFProfissaoId_To_Description ;
      private string AV34TFProfissaoNome_Sel ;
      private string AV33TFProfissaoNome ;
      private string AV53Profissaowwds_1_filterfulltext ;
      private string AV54Profissaowwds_2_dynamicfiltersselector1 ;
      private string AV56Profissaowwds_4_profissaonome1 ;
      private string AV58Profissaowwds_6_dynamicfiltersselector2 ;
      private string AV60Profissaowwds_8_profissaonome2 ;
      private string AV62Profissaowwds_10_dynamicfiltersselector3 ;
      private string AV64Profissaowwds_12_profissaonome3 ;
      private string AV67Profissaowwds_15_tfprofissaonome ;
      private string AV68Profissaowwds_16_tfprofissaonome_sel ;
      private string lV53Profissaowwds_1_filterfulltext ;
      private string lV56Profissaowwds_4_profissaonome1 ;
      private string lV60Profissaowwds_8_profissaonome2 ;
      private string lV64Profissaowwds_12_profissaonome3 ;
      private string lV67Profissaowwds_15_tfprofissaonome ;
      private string A441ProfissaoNome ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00A82_A440ProfissaoId ;
      private string[] P00A82_A441ProfissaoNome ;
      private bool[] P00A82_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class profissaowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A82( IGxContext context ,
                                             string AV53Profissaowwds_1_filterfulltext ,
                                             string AV54Profissaowwds_2_dynamicfiltersselector1 ,
                                             short AV55Profissaowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Profissaowwds_4_profissaonome1 ,
                                             bool AV57Profissaowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Profissaowwds_6_dynamicfiltersselector2 ,
                                             short AV59Profissaowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Profissaowwds_8_profissaonome2 ,
                                             bool AV61Profissaowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Profissaowwds_10_dynamicfiltersselector3 ,
                                             short AV63Profissaowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Profissaowwds_12_profissaonome3 ,
                                             int AV65Profissaowwds_13_tfprofissaoid ,
                                             int AV66Profissaowwds_14_tfprofissaoid_to ,
                                             string AV68Profissaowwds_16_tfprofissaonome_sel ,
                                             string AV67Profissaowwds_15_tfprofissaonome ,
                                             int A440ProfissaoId ,
                                             string A441ProfissaoNome ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT ProfissaoId, ProfissaoNome FROM Profissao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Profissaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ProfissaoId,'999999999'), 2) like '%' || :lV53Profissaowwds_1_filterfulltext) or ( ProfissaoNome like '%' || :lV53Profissaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Profissaowwds_2_dynamicfiltersselector1, "PROFISSAONOME") == 0 ) && ( AV55Profissaowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Profissaowwds_4_profissaonome1)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV56Profissaowwds_4_profissaonome1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Profissaowwds_2_dynamicfiltersselector1, "PROFISSAONOME") == 0 ) && ( AV55Profissaowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Profissaowwds_4_profissaonome1)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV56Profissaowwds_4_profissaonome1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV57Profissaowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Profissaowwds_6_dynamicfiltersselector2, "PROFISSAONOME") == 0 ) && ( AV59Profissaowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Profissaowwds_8_profissaonome2)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV60Profissaowwds_8_profissaonome2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV57Profissaowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Profissaowwds_6_dynamicfiltersselector2, "PROFISSAONOME") == 0 ) && ( AV59Profissaowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Profissaowwds_8_profissaonome2)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV60Profissaowwds_8_profissaonome2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV61Profissaowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Profissaowwds_10_dynamicfiltersselector3, "PROFISSAONOME") == 0 ) && ( AV63Profissaowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profissaowwds_12_profissaonome3)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV64Profissaowwds_12_profissaonome3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Profissaowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Profissaowwds_10_dynamicfiltersselector3, "PROFISSAONOME") == 0 ) && ( AV63Profissaowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profissaowwds_12_profissaonome3)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV64Profissaowwds_12_profissaonome3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV65Profissaowwds_13_tfprofissaoid) )
         {
            AddWhere(sWhereString, "(ProfissaoId >= :AV65Profissaowwds_13_tfprofissaoid)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV66Profissaowwds_14_tfprofissaoid_to) )
         {
            AddWhere(sWhereString, "(ProfissaoId <= :AV66Profissaowwds_14_tfprofissaoid_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Profissaowwds_16_tfprofissaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Profissaowwds_15_tfprofissaonome)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV67Profissaowwds_15_tfprofissaonome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profissaowwds_16_tfprofissaonome_sel)) && ! ( StringUtil.StrCmp(AV68Profissaowwds_16_tfprofissaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome = ( :AV68Profissaowwds_16_tfprofissaonome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Profissaowwds_16_tfprofissaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from ProfissaoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY ProfissaoNome";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ProfissaoNome DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY ProfissaoId";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ProfissaoId DESC";
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
                     return conditional_P00A82(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00A82;
          prmP00A82 = new Object[] {
          new ParDef("lV53Profissaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Profissaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Profissaowwds_4_profissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV56Profissaowwds_4_profissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV60Profissaowwds_8_profissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV60Profissaowwds_8_profissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV64Profissaowwds_12_profissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV64Profissaowwds_12_profissaonome3",GXType.VarChar,90,0) ,
          new ParDef("AV65Profissaowwds_13_tfprofissaoid",GXType.Int32,9,0) ,
          new ParDef("AV66Profissaowwds_14_tfprofissaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV67Profissaowwds_15_tfprofissaonome",GXType.VarChar,90,0) ,
          new ParDef("AV68Profissaowwds_16_tfprofissaonome_sel",GXType.VarChar,90,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A82,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
