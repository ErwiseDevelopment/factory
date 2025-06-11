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
   public class especialidadewwexportreport : GXWebProcedure
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

      public especialidadewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public especialidadewwexportreport( IGxContext context )
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
         setOutputFileName("EspecialidadeWWExportReport");
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
            AV47Title = "Lista de Especialidade";
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
            HBP0( true, 0) ;
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
            HBP0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "ESPECIALIDADENOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15EspecialidadeNome1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15EspecialidadeNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterEspecialidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Especialidade", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterEspecialidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Especialidade", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17EspecialidadeNome = AV15EspecialidadeNome1;
                  HBP0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEspecialidadeNomeDescription, "")), 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EspecialidadeNome, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "ESPECIALIDADENOME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21EspecialidadeNome2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21EspecialidadeNome2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterEspecialidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Especialidade", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterEspecialidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Especialidade", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17EspecialidadeNome = AV21EspecialidadeNome2;
                     HBP0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEspecialidadeNomeDescription, "")), 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EspecialidadeNome, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "ESPECIALIDADENOME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25EspecialidadeNome3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EspecialidadeNome3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterEspecialidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Especialidade", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterEspecialidadeNomeDescription = StringUtil.Format( "%1 (%2)", "Especialidade", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17EspecialidadeNome = AV25EspecialidadeNome3;
                        HBP0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEspecialidadeNomeDescription, "")), 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EspecialidadeNome, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEspecialidadeNome_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFEspecialidadeNome_Sel, "<#Empty#>")==0)));
            AV33TFEspecialidadeNome_Sel = (AV36TempBoolean ? "(Vazio)" : AV33TFEspecialidadeNome_Sel);
            HBP0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Especialidade", 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFEspecialidadeNome_Sel, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFEspecialidadeNome_Sel = (AV36TempBoolean ? "<#Empty#>" : AV33TFEspecialidadeNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEspecialidadeNome)) )
            {
               HBP0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Especialidade", 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFEspecialidadeNome, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV34TFEspecialidadeStatus_Sel) )
         {
            if ( AV34TFEspecialidadeStatus_Sel == 1 )
            {
               AV35FilterTFEspecialidadeStatus_SelValueDescription = "Marcado";
            }
            else if ( AV34TFEspecialidadeStatus_Sel == 2 )
            {
               AV35FilterTFEspecialidadeStatus_SelValueDescription = "Desmarcado";
            }
            HBP0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 205, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35FilterTFEspecialidadeStatus_SelValueDescription, "")), 205, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HBP0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HBP0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Especialidade", 30, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 410, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV53Especialidadewwds_1_filterfulltext = AV12FilterFullText;
         AV54Especialidadewwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV55Especialidadewwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV56Especialidadewwds_4_especialidadenome1 = AV15EspecialidadeNome1;
         AV57Especialidadewwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV58Especialidadewwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV59Especialidadewwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV60Especialidadewwds_8_especialidadenome2 = AV21EspecialidadeNome2;
         AV61Especialidadewwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV62Especialidadewwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV63Especialidadewwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV64Especialidadewwds_12_especialidadenome3 = AV25EspecialidadeNome3;
         AV65Especialidadewwds_13_tfespecialidadenome = AV32TFEspecialidadeNome;
         AV66Especialidadewwds_14_tfespecialidadenome_sel = AV33TFEspecialidadeNome_Sel;
         AV67Especialidadewwds_15_tfespecialidadestatus_sel = AV34TFEspecialidadeStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Especialidadewwds_1_filterfulltext ,
                                              AV54Especialidadewwds_2_dynamicfiltersselector1 ,
                                              AV55Especialidadewwds_3_dynamicfiltersoperator1 ,
                                              AV56Especialidadewwds_4_especialidadenome1 ,
                                              AV57Especialidadewwds_5_dynamicfiltersenabled2 ,
                                              AV58Especialidadewwds_6_dynamicfiltersselector2 ,
                                              AV59Especialidadewwds_7_dynamicfiltersoperator2 ,
                                              AV60Especialidadewwds_8_especialidadenome2 ,
                                              AV61Especialidadewwds_9_dynamicfiltersenabled3 ,
                                              AV62Especialidadewwds_10_dynamicfiltersselector3 ,
                                              AV63Especialidadewwds_11_dynamicfiltersoperator3 ,
                                              AV64Especialidadewwds_12_especialidadenome3 ,
                                              AV66Especialidadewwds_14_tfespecialidadenome_sel ,
                                              AV65Especialidadewwds_13_tfespecialidadenome ,
                                              AV67Especialidadewwds_15_tfespecialidadestatus_sel ,
                                              A458EspecialidadeNome ,
                                              A595EspecialidadeStatus ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Especialidadewwds_1_filterfulltext), "%", "");
         lV53Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Especialidadewwds_1_filterfulltext), "%", "");
         lV53Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Especialidadewwds_1_filterfulltext), "%", "");
         lV56Especialidadewwds_4_especialidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV56Especialidadewwds_4_especialidadenome1), "%", "");
         lV56Especialidadewwds_4_especialidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV56Especialidadewwds_4_especialidadenome1), "%", "");
         lV60Especialidadewwds_8_especialidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV60Especialidadewwds_8_especialidadenome2), "%", "");
         lV60Especialidadewwds_8_especialidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV60Especialidadewwds_8_especialidadenome2), "%", "");
         lV64Especialidadewwds_12_especialidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV64Especialidadewwds_12_especialidadenome3), "%", "");
         lV64Especialidadewwds_12_especialidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV64Especialidadewwds_12_especialidadenome3), "%", "");
         lV65Especialidadewwds_13_tfespecialidadenome = StringUtil.Concat( StringUtil.RTrim( AV65Especialidadewwds_13_tfespecialidadenome), "%", "");
         /* Using cursor P00BP2 */
         pr_default.execute(0, new Object[] {lV53Especialidadewwds_1_filterfulltext, lV53Especialidadewwds_1_filterfulltext, lV53Especialidadewwds_1_filterfulltext, lV56Especialidadewwds_4_especialidadenome1, lV56Especialidadewwds_4_especialidadenome1, lV60Especialidadewwds_8_especialidadenome2, lV60Especialidadewwds_8_especialidadenome2, lV64Especialidadewwds_12_especialidadenome3, lV64Especialidadewwds_12_especialidadenome3, lV65Especialidadewwds_13_tfespecialidadenome, AV66Especialidadewwds_14_tfespecialidadenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A595EspecialidadeStatus = P00BP2_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = P00BP2_n595EspecialidadeStatus[0];
            A458EspecialidadeNome = P00BP2_A458EspecialidadeNome[0];
            n458EspecialidadeNome = P00BP2_n458EspecialidadeNome[0];
            A457EspecialidadeId = P00BP2_A457EspecialidadeId[0];
            AV27EspecialidadeStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A595EspecialidadeStatus)), "true") == 0 )
            {
               AV27EspecialidadeStatusDescription = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A595EspecialidadeStatus)), "false") == 0 )
            {
               AV27EspecialidadeStatusDescription = "Inativo";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HBP0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A458EspecialidadeNome, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EspecialidadeStatusDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("EspecialidadeWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EspecialidadeWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("EspecialidadeWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADENOME") == 0 )
            {
               AV32TFEspecialidadeNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADENOME_SEL") == 0 )
            {
               AV33TFEspecialidadeNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADESTATUS_SEL") == 0 )
            {
               AV34TFEspecialidadeStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV68GXV1 = (int)(AV68GXV1+1);
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

      protected void HBP0( bool bFoot ,
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
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15EspecialidadeNome1 = "";
         AV16FilterEspecialidadeNomeDescription = "";
         AV17EspecialidadeNome = "";
         AV19DynamicFiltersSelector2 = "";
         AV21EspecialidadeNome2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25EspecialidadeNome3 = "";
         AV33TFEspecialidadeNome_Sel = "";
         AV32TFEspecialidadeNome = "";
         AV35FilterTFEspecialidadeStatus_SelValueDescription = "";
         AV53Especialidadewwds_1_filterfulltext = "";
         AV54Especialidadewwds_2_dynamicfiltersselector1 = "";
         AV56Especialidadewwds_4_especialidadenome1 = "";
         AV58Especialidadewwds_6_dynamicfiltersselector2 = "";
         AV60Especialidadewwds_8_especialidadenome2 = "";
         AV62Especialidadewwds_10_dynamicfiltersselector3 = "";
         AV64Especialidadewwds_12_especialidadenome3 = "";
         AV65Especialidadewwds_13_tfespecialidadenome = "";
         AV66Especialidadewwds_14_tfespecialidadenome_sel = "";
         lV53Especialidadewwds_1_filterfulltext = "";
         lV56Especialidadewwds_4_especialidadenome1 = "";
         lV60Especialidadewwds_8_especialidadenome2 = "";
         lV64Especialidadewwds_12_especialidadenome3 = "";
         lV65Especialidadewwds_13_tfespecialidadenome = "";
         A458EspecialidadeNome = "";
         P00BP2_A595EspecialidadeStatus = new bool[] {false} ;
         P00BP2_n595EspecialidadeStatus = new bool[] {false} ;
         P00BP2_A458EspecialidadeNome = new string[] {""} ;
         P00BP2_n458EspecialidadeNome = new bool[] {false} ;
         P00BP2_A457EspecialidadeId = new int[1] ;
         AV27EspecialidadeStatusDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.especialidadewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00BP2_A595EspecialidadeStatus, P00BP2_n595EspecialidadeStatus, P00BP2_A458EspecialidadeNome, P00BP2_n458EspecialidadeNome, P00BP2_A457EspecialidadeId
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
      private short AV34TFEspecialidadeStatus_Sel ;
      private short AV55Especialidadewwds_3_dynamicfiltersoperator1 ;
      private short AV59Especialidadewwds_7_dynamicfiltersoperator2 ;
      private short AV63Especialidadewwds_11_dynamicfiltersoperator3 ;
      private short AV67Especialidadewwds_15_tfespecialidadestatus_sel ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A457EspecialidadeId ;
      private int AV68GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV57Especialidadewwds_5_dynamicfiltersenabled2 ;
      private bool AV61Especialidadewwds_9_dynamicfiltersenabled3 ;
      private bool A595EspecialidadeStatus ;
      private bool AV11OrderedDsc ;
      private bool n595EspecialidadeStatus ;
      private bool n458EspecialidadeNome ;
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
      private string AV15EspecialidadeNome1 ;
      private string AV16FilterEspecialidadeNomeDescription ;
      private string AV17EspecialidadeNome ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21EspecialidadeNome2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25EspecialidadeNome3 ;
      private string AV33TFEspecialidadeNome_Sel ;
      private string AV32TFEspecialidadeNome ;
      private string AV35FilterTFEspecialidadeStatus_SelValueDescription ;
      private string AV53Especialidadewwds_1_filterfulltext ;
      private string AV54Especialidadewwds_2_dynamicfiltersselector1 ;
      private string AV56Especialidadewwds_4_especialidadenome1 ;
      private string AV58Especialidadewwds_6_dynamicfiltersselector2 ;
      private string AV60Especialidadewwds_8_especialidadenome2 ;
      private string AV62Especialidadewwds_10_dynamicfiltersselector3 ;
      private string AV64Especialidadewwds_12_especialidadenome3 ;
      private string AV65Especialidadewwds_13_tfespecialidadenome ;
      private string AV66Especialidadewwds_14_tfespecialidadenome_sel ;
      private string lV53Especialidadewwds_1_filterfulltext ;
      private string lV56Especialidadewwds_4_especialidadenome1 ;
      private string lV60Especialidadewwds_8_especialidadenome2 ;
      private string lV64Especialidadewwds_12_especialidadenome3 ;
      private string lV65Especialidadewwds_13_tfespecialidadenome ;
      private string A458EspecialidadeNome ;
      private string AV27EspecialidadeStatusDescription ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P00BP2_A595EspecialidadeStatus ;
      private bool[] P00BP2_n595EspecialidadeStatus ;
      private string[] P00BP2_A458EspecialidadeNome ;
      private bool[] P00BP2_n458EspecialidadeNome ;
      private int[] P00BP2_A457EspecialidadeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class especialidadewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BP2( IGxContext context ,
                                             string AV53Especialidadewwds_1_filterfulltext ,
                                             string AV54Especialidadewwds_2_dynamicfiltersselector1 ,
                                             short AV55Especialidadewwds_3_dynamicfiltersoperator1 ,
                                             string AV56Especialidadewwds_4_especialidadenome1 ,
                                             bool AV57Especialidadewwds_5_dynamicfiltersenabled2 ,
                                             string AV58Especialidadewwds_6_dynamicfiltersselector2 ,
                                             short AV59Especialidadewwds_7_dynamicfiltersoperator2 ,
                                             string AV60Especialidadewwds_8_especialidadenome2 ,
                                             bool AV61Especialidadewwds_9_dynamicfiltersenabled3 ,
                                             string AV62Especialidadewwds_10_dynamicfiltersselector3 ,
                                             short AV63Especialidadewwds_11_dynamicfiltersoperator3 ,
                                             string AV64Especialidadewwds_12_especialidadenome3 ,
                                             string AV66Especialidadewwds_14_tfespecialidadenome_sel ,
                                             string AV65Especialidadewwds_13_tfespecialidadenome ,
                                             short AV67Especialidadewwds_15_tfespecialidadestatus_sel ,
                                             string A458EspecialidadeNome ,
                                             bool A595EspecialidadeStatus ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT EspecialidadeStatus, EspecialidadeNome, EspecialidadeId FROM Especialidade";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Especialidadewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EspecialidadeNome like '%' || :lV53Especialidadewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Especialidadewwds_1_filterfulltext) and EspecialidadeStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Especialidadewwds_1_filterfulltext) and EspecialidadeStatus = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Especialidadewwds_2_dynamicfiltersselector1, "ESPECIALIDADENOME") == 0 ) && ( AV55Especialidadewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Especialidadewwds_4_especialidadenome1)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV56Especialidadewwds_4_especialidadenome1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Especialidadewwds_2_dynamicfiltersselector1, "ESPECIALIDADENOME") == 0 ) && ( AV55Especialidadewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Especialidadewwds_4_especialidadenome1)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV56Especialidadewwds_4_especialidadenome1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV57Especialidadewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Especialidadewwds_6_dynamicfiltersselector2, "ESPECIALIDADENOME") == 0 ) && ( AV59Especialidadewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Especialidadewwds_8_especialidadenome2)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV60Especialidadewwds_8_especialidadenome2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV57Especialidadewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Especialidadewwds_6_dynamicfiltersselector2, "ESPECIALIDADENOME") == 0 ) && ( AV59Especialidadewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Especialidadewwds_8_especialidadenome2)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV60Especialidadewwds_8_especialidadenome2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Especialidadewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Especialidadewwds_10_dynamicfiltersselector3, "ESPECIALIDADENOME") == 0 ) && ( AV63Especialidadewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Especialidadewwds_12_especialidadenome3)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV64Especialidadewwds_12_especialidadenome3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV61Especialidadewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Especialidadewwds_10_dynamicfiltersselector3, "ESPECIALIDADENOME") == 0 ) && ( AV63Especialidadewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Especialidadewwds_12_especialidadenome3)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV64Especialidadewwds_12_especialidadenome3)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Especialidadewwds_14_tfespecialidadenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Especialidadewwds_13_tfespecialidadenome)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV65Especialidadewwds_13_tfespecialidadenome)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Especialidadewwds_14_tfespecialidadenome_sel)) && ! ( StringUtil.StrCmp(AV66Especialidadewwds_14_tfespecialidadenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome = ( :AV66Especialidadewwds_14_tfespecialidadenome_sel))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV66Especialidadewwds_14_tfespecialidadenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EspecialidadeNome IS NULL or (char_length(trim(trailing ' ' from EspecialidadeNome))=0))");
         }
         if ( AV67Especialidadewwds_15_tfespecialidadestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(EspecialidadeStatus = TRUE)");
         }
         if ( AV67Especialidadewwds_15_tfespecialidadestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(EspecialidadeStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY EspecialidadeNome";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EspecialidadeNome DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY EspecialidadeStatus";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EspecialidadeStatus DESC";
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
                     return conditional_P00BP2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP00BP2;
          prmP00BP2 = new Object[] {
          new ParDef("lV53Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Especialidadewwds_4_especialidadenome1",GXType.VarChar,60,0) ,
          new ParDef("lV56Especialidadewwds_4_especialidadenome1",GXType.VarChar,60,0) ,
          new ParDef("lV60Especialidadewwds_8_especialidadenome2",GXType.VarChar,60,0) ,
          new ParDef("lV60Especialidadewwds_8_especialidadenome2",GXType.VarChar,60,0) ,
          new ParDef("lV64Especialidadewwds_12_especialidadenome3",GXType.VarChar,60,0) ,
          new ParDef("lV64Especialidadewwds_12_especialidadenome3",GXType.VarChar,60,0) ,
          new ParDef("lV65Especialidadewwds_13_tfespecialidadenome",GXType.VarChar,60,0) ,
          new ParDef("AV66Especialidadewwds_14_tfespecialidadenome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BP2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
