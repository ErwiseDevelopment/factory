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
   public class wpsecroleexportreport : GXWebProcedure
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

      public wpsecroleexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpsecroleexportreport( IGxContext context )
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
         setOutputFileName("WpSecRoleExportReport");
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
            AV47Title = "Lista de Role";
            GXt_char1 = AV50Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV50Companyname = GXt_char1;
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
            H580( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H580( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16SecRoleName1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SecRoleName1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18SecRoleName = AV16SecRoleName1;
                  H580( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterSecRoleNameDescription, "")), 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18SecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22SecRoleName2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecRoleName2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18SecRoleName = AV22SecRoleName2;
                     H580( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterSecRoleNameDescription, "")), 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18SecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26SecRoleName3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SecRoleName3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterSecRoleNameDescription = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18SecRoleName = AV26SecRoleName3;
                        H580( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterSecRoleNameDescription, "")), 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18SecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSecRoleName_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFSecRoleName_Sel, "<#Empty#>")==0)));
            AV33TFSecRoleName_Sel = (AV36TempBoolean ? "(Vazio)" : AV33TFSecRoleName_Sel);
            H580( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Perfil", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSecRoleName_Sel, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFSecRoleName_Sel = (AV36TempBoolean ? "<#Empty#>" : AV33TFSecRoleName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSecRoleName)) )
            {
               H580( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Perfil", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFSecRoleName, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecRoleDescription_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFSecRoleDescription_Sel, "<#Empty#>")==0)));
            AV35TFSecRoleDescription_Sel = (AV36TempBoolean ? "(Vazio)" : AV35TFSecRoleDescription_Sel);
            H580( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFSecRoleDescription_Sel, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFSecRoleDescription_Sel = (AV36TempBoolean ? "<#Empty#>" : AV35TFSecRoleDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSecRoleDescription)) )
            {
               H580( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 155, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSecRoleDescription, "")), 155, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H580( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H580( false, 36) ;
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
         AV54Wpsecroleds_1_filterfulltext = AV13FilterFullText;
         AV55Wpsecroleds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV56Wpsecroleds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV57Wpsecroleds_4_secrolename1 = AV16SecRoleName1;
         AV58Wpsecroleds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV59Wpsecroleds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV60Wpsecroleds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV61Wpsecroleds_8_secrolename2 = AV22SecRoleName2;
         AV62Wpsecroleds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV63Wpsecroleds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV64Wpsecroleds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV65Wpsecroleds_12_secrolename3 = AV26SecRoleName3;
         AV66Wpsecroleds_13_tfsecrolename = AV32TFSecRoleName;
         AV67Wpsecroleds_14_tfsecrolename_sel = AV33TFSecRoleName_Sel;
         AV68Wpsecroleds_15_tfsecroledescription = AV34TFSecRoleDescription;
         AV69Wpsecroleds_16_tfsecroledescription_sel = AV35TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Wpsecroleds_1_filterfulltext ,
                                              AV55Wpsecroleds_2_dynamicfiltersselector1 ,
                                              AV56Wpsecroleds_3_dynamicfiltersoperator1 ,
                                              AV57Wpsecroleds_4_secrolename1 ,
                                              AV58Wpsecroleds_5_dynamicfiltersenabled2 ,
                                              AV59Wpsecroleds_6_dynamicfiltersselector2 ,
                                              AV60Wpsecroleds_7_dynamicfiltersoperator2 ,
                                              AV61Wpsecroleds_8_secrolename2 ,
                                              AV62Wpsecroleds_9_dynamicfiltersenabled3 ,
                                              AV63Wpsecroleds_10_dynamicfiltersselector3 ,
                                              AV64Wpsecroleds_11_dynamicfiltersoperator3 ,
                                              AV65Wpsecroleds_12_secrolename3 ,
                                              AV67Wpsecroleds_14_tfsecrolename_sel ,
                                              AV66Wpsecroleds_13_tfsecrolename ,
                                              AV69Wpsecroleds_16_tfsecroledescription_sel ,
                                              AV68Wpsecroleds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpsecroleds_1_filterfulltext), "%", "");
         lV54Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpsecroleds_1_filterfulltext), "%", "");
         lV57Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1), "%", "");
         lV57Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1), "%", "");
         lV61Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2), "%", "");
         lV61Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2), "%", "");
         lV65Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3), "%", "");
         lV65Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3), "%", "");
         lV66Wpsecroleds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV66Wpsecroleds_13_tfsecrolename), "%", "");
         lV68Wpsecroleds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV68Wpsecroleds_15_tfsecroledescription), "%", "");
         /* Using cursor P00582 */
         pr_default.execute(0, new Object[] {lV54Wpsecroleds_1_filterfulltext, lV54Wpsecroleds_1_filterfulltext, lV57Wpsecroleds_4_secrolename1, lV57Wpsecroleds_4_secrolename1, lV61Wpsecroleds_8_secrolename2, lV61Wpsecroleds_8_secrolename2, lV65Wpsecroleds_12_secrolename3, lV65Wpsecroleds_12_secrolename3, lV66Wpsecroleds_13_tfsecrolename, AV67Wpsecroleds_14_tfsecrolename_sel, lV68Wpsecroleds_15_tfsecroledescription, AV69Wpsecroleds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139SecRoleDescription = P00582_A139SecRoleDescription[0];
            A140SecRoleName = P00582_A140SecRoleName[0];
            A131SecRoleId = P00582_A131SecRoleId[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H580( false, 36) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("WpSecRoleGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpSecRoleGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WpSecRoleGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV32TFSecRoleName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV33TFSecRoleName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV34TFSecRoleDescription = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV35TFSecRoleDescription_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV70GXV1 = (int)(AV70GXV1+1);
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

      protected void H580( bool bFoot ,
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
         AV50Companyname = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         GXt_char1 = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16SecRoleName1 = "";
         AV17FilterSecRoleNameDescription = "";
         AV18SecRoleName = "";
         AV20DynamicFiltersSelector2 = "";
         AV22SecRoleName2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26SecRoleName3 = "";
         AV33TFSecRoleName_Sel = "";
         AV32TFSecRoleName = "";
         AV35TFSecRoleDescription_Sel = "";
         AV34TFSecRoleDescription = "";
         AV54Wpsecroleds_1_filterfulltext = "";
         AV55Wpsecroleds_2_dynamicfiltersselector1 = "";
         AV57Wpsecroleds_4_secrolename1 = "";
         AV59Wpsecroleds_6_dynamicfiltersselector2 = "";
         AV61Wpsecroleds_8_secrolename2 = "";
         AV63Wpsecroleds_10_dynamicfiltersselector3 = "";
         AV65Wpsecroleds_12_secrolename3 = "";
         AV66Wpsecroleds_13_tfsecrolename = "";
         AV67Wpsecroleds_14_tfsecrolename_sel = "";
         AV68Wpsecroleds_15_tfsecroledescription = "";
         AV69Wpsecroleds_16_tfsecroledescription_sel = "";
         lV54Wpsecroleds_1_filterfulltext = "";
         lV57Wpsecroleds_4_secrolename1 = "";
         lV61Wpsecroleds_8_secrolename2 = "";
         lV65Wpsecroleds_12_secrolename3 = "";
         lV66Wpsecroleds_13_tfsecrolename = "";
         lV68Wpsecroleds_15_tfsecroledescription = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         P00582_A139SecRoleDescription = new string[] {""} ;
         P00582_A140SecRoleName = new string[] {""} ;
         P00582_A131SecRoleId = new short[1] ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsecroleexportreport__default(),
            new Object[][] {
                new Object[] {
               P00582_A139SecRoleDescription, P00582_A140SecRoleName, P00582_A131SecRoleId
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
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV56Wpsecroleds_3_dynamicfiltersoperator1 ;
      private short AV60Wpsecroleds_7_dynamicfiltersoperator2 ;
      private short AV64Wpsecroleds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private short A131SecRoleId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV70GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV58Wpsecroleds_5_dynamicfiltersenabled2 ;
      private bool AV62Wpsecroleds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV50Companyname ;
      private string AV47Title ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16SecRoleName1 ;
      private string AV17FilterSecRoleNameDescription ;
      private string AV18SecRoleName ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22SecRoleName2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26SecRoleName3 ;
      private string AV33TFSecRoleName_Sel ;
      private string AV32TFSecRoleName ;
      private string AV35TFSecRoleDescription_Sel ;
      private string AV34TFSecRoleDescription ;
      private string AV54Wpsecroleds_1_filterfulltext ;
      private string AV55Wpsecroleds_2_dynamicfiltersselector1 ;
      private string AV57Wpsecroleds_4_secrolename1 ;
      private string AV59Wpsecroleds_6_dynamicfiltersselector2 ;
      private string AV61Wpsecroleds_8_secrolename2 ;
      private string AV63Wpsecroleds_10_dynamicfiltersselector3 ;
      private string AV65Wpsecroleds_12_secrolename3 ;
      private string AV66Wpsecroleds_13_tfsecrolename ;
      private string AV67Wpsecroleds_14_tfsecrolename_sel ;
      private string AV68Wpsecroleds_15_tfsecroledescription ;
      private string AV69Wpsecroleds_16_tfsecroledescription_sel ;
      private string lV54Wpsecroleds_1_filterfulltext ;
      private string lV57Wpsecroleds_4_secrolename1 ;
      private string lV61Wpsecroleds_8_secrolename2 ;
      private string lV65Wpsecroleds_12_secrolename3 ;
      private string lV66Wpsecroleds_13_tfsecrolename ;
      private string lV68Wpsecroleds_15_tfsecroledescription ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00582_A139SecRoleDescription ;
      private string[] P00582_A140SecRoleName ;
      private short[] P00582_A131SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class wpsecroleexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00582( IGxContext context ,
                                             string AV54Wpsecroleds_1_filterfulltext ,
                                             string AV55Wpsecroleds_2_dynamicfiltersselector1 ,
                                             short AV56Wpsecroleds_3_dynamicfiltersoperator1 ,
                                             string AV57Wpsecroleds_4_secrolename1 ,
                                             bool AV58Wpsecroleds_5_dynamicfiltersenabled2 ,
                                             string AV59Wpsecroleds_6_dynamicfiltersselector2 ,
                                             short AV60Wpsecroleds_7_dynamicfiltersoperator2 ,
                                             string AV61Wpsecroleds_8_secrolename2 ,
                                             bool AV62Wpsecroleds_9_dynamicfiltersenabled3 ,
                                             string AV63Wpsecroleds_10_dynamicfiltersselector3 ,
                                             short AV64Wpsecroleds_11_dynamicfiltersoperator3 ,
                                             string AV65Wpsecroleds_12_secrolename3 ,
                                             string AV67Wpsecroleds_14_tfsecrolename_sel ,
                                             string AV66Wpsecroleds_13_tfsecrolename ,
                                             string AV69Wpsecroleds_16_tfsecroledescription_sel ,
                                             string AV68Wpsecroleds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT SecRoleDescription, SecRoleName, SecRoleId FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpsecroleds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV54Wpsecroleds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV54Wpsecroleds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wpsecroleds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV57Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wpsecroleds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV57Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV58Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wpsecroleds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV61Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV58Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wpsecroleds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV61Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV62Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wpsecroleds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV65Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV62Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wpsecroleds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV65Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpsecroleds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV66Wpsecroleds_13_tfsecrolename)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV67Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV67Wpsecroleds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpsecroleds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpsecroleds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV68Wpsecroleds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpsecroleds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV69Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV69Wpsecroleds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleName";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecRoleName DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleDescription";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
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
                     return conditional_P00582(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00582;
          prmP00582 = new Object[] {
          new ParDef("lV54Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV57Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV61Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV61Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV65Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV65Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV66Wpsecroleds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV67Wpsecroleds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Wpsecroleds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV69Wpsecroleds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00582", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00582,100, GxCacheFrequency.OFF ,true,false )
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
