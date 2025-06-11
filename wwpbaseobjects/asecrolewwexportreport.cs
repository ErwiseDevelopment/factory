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
namespace GeneXus.Programs.wwpbaseobjects {
   public class asecrolewwexportreport : GXWebProcedure
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

      public asecrolewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asecrolewwexportreport( IGxContext context )
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
         setOutputFileName("SecRoleWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV37WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV51Title = "Lista de Role";
            GXt_char1 = AV55Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV55Companyname = GXt_char1;
            GXt_char1 = AV50Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV50Phone = GXt_char1;
            GXt_char1 = AV48Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV48Mail = GXt_char1;
            GXt_char1 = AV52Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV52Website = GXt_char1;
            GXt_char1 = AV41AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV41AddressLine1 = GXt_char1;
            GXt_char1 = AV42AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV42AddressLine2 = GXt_char1;
            GXt_char1 = AV43AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV43AddressLine3 = GXt_char1;
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
            H4W0( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) )
         {
            H4W0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54FilterFullText, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV14SecRoleName1 = AV28GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SecRoleName1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV29FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV29FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                  }
                  AV30SecRoleName = AV14SecRoleName1;
                  H4W0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29FilterSecRoleNameDescription, "")), 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30SecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV16DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV17DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV17DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV18DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV19SecRoleName2 = AV28GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SecRoleName2)) )
                  {
                     if ( AV18DynamicFiltersOperator2 == 0 )
                     {
                        AV29FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV18DynamicFiltersOperator2 == 1 )
                     {
                        AV29FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                     }
                     AV30SecRoleName = AV19SecRoleName2;
                     H4W0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29FilterSecRoleNameDescription, "")), 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30SecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV24SecRoleName3 = AV28GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecRoleName3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV29FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV29FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                        }
                        AV30SecRoleName = AV24SecRoleName3;
                        H4W0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29FilterSecRoleNameDescription, "")), 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30SecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSecRoleName_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFSecRoleName_Sel, "<#Empty#>")==0)));
            AV34TFSecRoleName_Sel = (AV40TempBoolean ? "(Vazio)" : AV34TFSecRoleName_Sel);
            H4W0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Perfil", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSecRoleName_Sel, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFSecRoleName_Sel = (AV40TempBoolean ? "<#Empty#>" : AV34TFSecRoleName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSecRoleName)) )
            {
               H4W0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Perfil", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecRoleDescription_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFSecRoleDescription_Sel, "<#Empty#>")==0)));
            AV36TFSecRoleDescription_Sel = (AV40TempBoolean ? "(Vazio)" : AV36TFSecRoleDescription_Sel);
            H4W0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFSecRoleDescription_Sel, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFSecRoleDescription_Sel = (AV40TempBoolean ? "<#Empty#>" : AV36TFSecRoleDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecRoleDescription)) )
            {
               H4W0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFSecRoleDescription, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4W0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4W0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Perfil", 30, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 410, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV59Wwpbaseobjects_secrolewwds_1_filterfulltext = AV54FilterFullText;
         AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV61Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV62Wwpbaseobjects_secrolewwds_4_secrolename1 = AV14SecRoleName1;
         AV63Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV16DynamicFiltersEnabled2;
         AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV17DynamicFiltersSelector2;
         AV65Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV18DynamicFiltersOperator2;
         AV66Wwpbaseobjects_secrolewwds_8_secrolename2 = AV19SecRoleName2;
         AV67Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV69Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV70Wwpbaseobjects_secrolewwds_12_secrolename3 = AV24SecRoleName3;
         AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV33TFSecRoleName;
         AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV34TFSecRoleName_Sel;
         AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV35TFSecRoleDescription;
         AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV36TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV59Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                              AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                              AV61Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                              AV62Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                              AV63Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                              AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                              AV65Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                              AV66Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                              AV67Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                              AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                              AV69Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                              AV70Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                              AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                              AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                              AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                              AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV59Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV62Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV62Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV62Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV62Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV66Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV66Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV70Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV70Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV70Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV70Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV71Wwpbaseobjects_secrolewwds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename), "%", "");
         lV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription), "%", "");
         /* Using cursor P004W2 */
         pr_default.execute(0, new Object[] {lV59Wwpbaseobjects_secrolewwds_1_filterfulltext, lV59Wwpbaseobjects_secrolewwds_1_filterfulltext, lV62Wwpbaseobjects_secrolewwds_4_secrolename1, lV62Wwpbaseobjects_secrolewwds_4_secrolename1, lV66Wwpbaseobjects_secrolewwds_8_secrolename2, lV66Wwpbaseobjects_secrolewwds_8_secrolename2, lV70Wwpbaseobjects_secrolewwds_12_secrolename3, lV70Wwpbaseobjects_secrolewwds_12_secrolename3, lV71Wwpbaseobjects_secrolewwds_13_tfsecrolename, AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, lV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription, AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139SecRoleDescription = P004W2_A139SecRoleDescription[0];
            A140SecRoleName = P004W2_A140SecRoleName[0];
            A131SecRoleId = P004W2_A131SecRoleId[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4W0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A140SecRoleName, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A139SecRoleDescription, "")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV38Session.Get("WWPBaseObjects.SecRoleWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecRoleWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV38Session.Get("WWPBaseObjects.SecRoleWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV27GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV27GridState.gxTpr_Ordereddsc;
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV54FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV33TFSecRoleName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV34TFSecRoleName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV35TFSecRoleDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV36TFSecRoleDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV75GXV1 = (int)(AV75GXV1+1);
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

      protected void H4W0( bool bFoot ,
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
                  AV49PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV46DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         if (IsMain)	waitPrinterEnd();
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
         AV37WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV51Title = "";
         AV55Companyname = "";
         AV50Phone = "";
         AV48Mail = "";
         AV52Website = "";
         AV41AddressLine1 = "";
         AV42AddressLine2 = "";
         AV43AddressLine3 = "";
         GXt_char1 = "";
         AV54FilterFullText = "";
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14SecRoleName1 = "";
         AV29FilterSecRoleNameDescription = "";
         AV30SecRoleName = "";
         AV17DynamicFiltersSelector2 = "";
         AV19SecRoleName2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24SecRoleName3 = "";
         AV34TFSecRoleName_Sel = "";
         AV33TFSecRoleName = "";
         AV36TFSecRoleDescription_Sel = "";
         AV35TFSecRoleDescription = "";
         AV59Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = "";
         AV62Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = "";
         AV66Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = "";
         AV70Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = "";
         AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = "";
         lV59Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         lV62Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         lV66Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         lV70Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         lV71Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         lV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         P004W2_A139SecRoleDescription = new string[] {""} ;
         P004W2_A140SecRoleName = new string[] {""} ;
         P004W2_A131SecRoleId = new short[1] ;
         AV38Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49PageInfo = "";
         AV46DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV44AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.asecrolewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004W2_A139SecRoleDescription, P004W2_A140SecRoleName, P004W2_A131SecRoleId
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
      private short AV13DynamicFiltersOperator1 ;
      private short AV18DynamicFiltersOperator2 ;
      private short AV23DynamicFiltersOperator3 ;
      private short AV61Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ;
      private short AV65Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ;
      private short AV69Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private short A131SecRoleId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV75GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV16DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV40TempBoolean ;
      private bool AV63Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ;
      private bool AV67Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV55Companyname ;
      private string AV51Title ;
      private string AV50Phone ;
      private string AV48Mail ;
      private string AV52Website ;
      private string AV41AddressLine1 ;
      private string AV42AddressLine2 ;
      private string AV43AddressLine3 ;
      private string AV54FilterFullText ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV14SecRoleName1 ;
      private string AV29FilterSecRoleNameDescription ;
      private string AV30SecRoleName ;
      private string AV17DynamicFiltersSelector2 ;
      private string AV19SecRoleName2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV24SecRoleName3 ;
      private string AV34TFSecRoleName_Sel ;
      private string AV33TFSecRoleName ;
      private string AV36TFSecRoleDescription_Sel ;
      private string AV35TFSecRoleDescription ;
      private string AV59Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ;
      private string AV62Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ;
      private string AV66Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ;
      private string AV70Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ;
      private string AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ;
      private string lV59Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string lV62Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string lV66Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string lV70Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string lV71Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string lV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string AV49PageInfo ;
      private string AV46DateInfo ;
      private string AV44AppName ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV37WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P004W2_A139SecRoleDescription ;
      private string[] P004W2_A140SecRoleName ;
      private short[] P004W2_A131SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
   }

   public class asecrolewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004W2( IGxContext context ,
                                             string AV59Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                             string AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                             short AV61Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                             string AV62Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                             bool AV63Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                             string AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                             short AV65Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                             string AV66Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                             bool AV67Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                             string AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                             short AV69Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                             string AV70Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                             string AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                             string AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                             string AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                             string AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT SecRoleDescription, SecRoleName, SecRoleId FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secrolewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV59Wwpbaseobjects_secrolewwds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV59Wwpbaseobjects_secrolewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV61Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV62Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV61Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV62Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV63Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV65Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV66Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV63Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV65Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV66Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV67Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV69Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV70Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV67Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV69Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV70Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wwpbaseobjects_secrolewwds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV71Wwpbaseobjects_secrolewwds_13_tfsecrolename)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleName";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecRoleName DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleDescription";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecRoleDescription DESC";
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
                     return conditional_P004W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP004W2;
          prmP004W2 = new Object[] {
          new ParDef("lV59Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV62Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV66Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV66Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV70Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV70Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV71Wwpbaseobjects_secrolewwds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV72Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Wwpbaseobjects_secrolewwds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV74Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
