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
   public class secuserclientewwexportreport : GXWebProcedure
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

      public secuserclientewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserclientewwexportreport( IGxContext context )
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
         setOutputFileName("SecUserClienteWWExportReport");
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
            AV49Title = "Lista de Usuário";
            GXt_char1 = AV59Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV59Companyname = GXt_char1;
            GXt_char1 = AV48Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV48Phone = GXt_char1;
            GXt_char1 = AV46Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV46Mail = GXt_char1;
            GXt_char1 = AV50Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV50Website = GXt_char1;
            GXt_char1 = AV39AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV39AddressLine1 = GXt_char1;
            GXt_char1 = AV40AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV40AddressLine2 = GXt_char1;
            GXt_char1 = AV41AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV41AddressLine3 = GXt_char1;
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
            H6N0( true, 0) ;
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
            H6N0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERFULLNAME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15SecUserFullName1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15SecUserFullName1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterSecUserFullNameDescription = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterSecUserFullNameDescription = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17SecUserFullName = AV15SecUserFullName1;
                  H6N0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecUserFullNameDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecUserFullName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV54SecUserName1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54SecUserName1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV55FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV55FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                  }
                  AV56SecUserName = AV54SecUserName1;
                  H6N0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterSecUserNameDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56SecUserName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "SECUSERFULLNAME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21SecUserFullName2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SecUserFullName2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterSecUserFullNameDescription = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterSecUserFullNameDescription = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17SecUserFullName = AV21SecUserFullName2;
                     H6N0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecUserFullNameDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecUserFullName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV57SecUserName2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57SecUserName2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV55FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV55FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                     }
                     AV56SecUserName = AV57SecUserName2;
                     H6N0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterSecUserNameDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56SecUserName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "SECUSERFULLNAME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25SecUserFullName3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecUserFullName3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterSecUserFullNameDescription = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterSecUserFullNameDescription = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17SecUserFullName = AV25SecUserFullName3;
                        H6N0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecUserFullNameDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecUserFullName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV58SecUserName3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58SecUserName3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV55FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV55FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                        }
                        AV56SecUserName = AV58SecUserName3;
                        H6N0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterSecUserNameDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56SecUserName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSecUserFullName_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFSecUserFullName_Sel, "<#Empty#>")==0)));
            AV33TFSecUserFullName_Sel = (AV38TempBoolean ? "(Vazio)" : AV33TFSecUserFullName_Sel);
            H6N0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome completo", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSecUserFullName_Sel, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFSecUserFullName_Sel = (AV38TempBoolean ? "<#Empty#>" : AV33TFSecUserFullName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSecUserFullName)) )
            {
               H6N0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome completo", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFSecUserFullName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TFSecUserName_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV53TFSecUserName_Sel, "<#Empty#>")==0)));
            AV53TFSecUserName_Sel = (AV38TempBoolean ? "(Vazio)" : AV53TFSecUserName_Sel);
            H6N0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuário", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFSecUserName_Sel, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV53TFSecUserName_Sel = (AV38TempBoolean ? "<#Empty#>" : AV53TFSecUserName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName)) )
            {
               H6N0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuário", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFSecUserName, "@!")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecUserEmail_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFSecUserEmail_Sel, "<#Empty#>")==0)));
            AV35TFSecUserEmail_Sel = (AV38TempBoolean ? "(Vazio)" : AV35TFSecUserEmail_Sel);
            H6N0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFSecUserEmail_Sel, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFSecUserEmail_Sel = (AV38TempBoolean ? "<#Empty#>" : AV35TFSecUserEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSecUserEmail)) )
            {
               H6N0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSecUserEmail, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV36TFSecUserStatus_Sel) )
         {
            if ( AV36TFSecUserStatus_Sel == 1 )
            {
               AV37FilterTFSecUserStatus_SelValueDescription = "Marcado";
            }
            else if ( AV36TFSecUserStatus_Sel == 2 )
            {
               AV37FilterTFSecUserStatus_SelValueDescription = "Desmarcado";
            }
            H6N0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterTFSecUserStatus_SelValueDescription, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6N0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6N0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome completo", 30, Gx_line+10, 216, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuário", 220, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("E-mail", 410, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 600, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV63Secuserclientewwds_1_filterfulltext = AV12FilterFullText;
         AV64Secuserclientewwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV65Secuserclientewwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV66Secuserclientewwds_4_secuserfullname1 = AV15SecUserFullName1;
         AV67Secuserclientewwds_5_secusername1 = AV54SecUserName1;
         AV68Secuserclientewwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV69Secuserclientewwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV70Secuserclientewwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV71Secuserclientewwds_9_secuserfullname2 = AV21SecUserFullName2;
         AV72Secuserclientewwds_10_secusername2 = AV57SecUserName2;
         AV73Secuserclientewwds_11_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV74Secuserclientewwds_12_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV75Secuserclientewwds_13_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV76Secuserclientewwds_14_secuserfullname3 = AV25SecUserFullName3;
         AV77Secuserclientewwds_15_secusername3 = AV58SecUserName3;
         AV78Secuserclientewwds_16_tfsecuserfullname = AV32TFSecUserFullName;
         AV79Secuserclientewwds_17_tfsecuserfullname_sel = AV33TFSecUserFullName_Sel;
         AV80Secuserclientewwds_18_tfsecusername = AV52TFSecUserName;
         AV81Secuserclientewwds_19_tfsecusername_sel = AV53TFSecUserName_Sel;
         AV82Secuserclientewwds_20_tfsecuseremail = AV34TFSecUserEmail;
         AV83Secuserclientewwds_21_tfsecuseremail_sel = AV35TFSecUserEmail_Sel;
         AV84Secuserclientewwds_22_tfsecuserstatus_sel = AV36TFSecUserStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV63Secuserclientewwds_1_filterfulltext ,
                                              AV64Secuserclientewwds_2_dynamicfiltersselector1 ,
                                              AV65Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                              AV66Secuserclientewwds_4_secuserfullname1 ,
                                              AV67Secuserclientewwds_5_secusername1 ,
                                              AV68Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                              AV69Secuserclientewwds_7_dynamicfiltersselector2 ,
                                              AV70Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                              AV71Secuserclientewwds_9_secuserfullname2 ,
                                              AV72Secuserclientewwds_10_secusername2 ,
                                              AV73Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                              AV74Secuserclientewwds_12_dynamicfiltersselector3 ,
                                              AV75Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                              AV76Secuserclientewwds_14_secuserfullname3 ,
                                              AV77Secuserclientewwds_15_secusername3 ,
                                              AV79Secuserclientewwds_17_tfsecuserfullname_sel ,
                                              AV78Secuserclientewwds_16_tfsecuserfullname ,
                                              AV81Secuserclientewwds_19_tfsecusername_sel ,
                                              AV80Secuserclientewwds_18_tfsecusername ,
                                              AV83Secuserclientewwds_21_tfsecuseremail_sel ,
                                              AV82Secuserclientewwds_20_tfsecuseremail ,
                                              AV84Secuserclientewwds_22_tfsecuserstatus_sel ,
                                              A143SecUserFullName ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc ,
                                              AV51SecUserClienteId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Secuserclientewwds_1_filterfulltext), "%", "");
         lV63Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Secuserclientewwds_1_filterfulltext), "%", "");
         lV63Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Secuserclientewwds_1_filterfulltext), "%", "");
         lV63Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Secuserclientewwds_1_filterfulltext), "%", "");
         lV63Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Secuserclientewwds_1_filterfulltext), "%", "");
         lV66Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_4_secuserfullname1), "%", "");
         lV66Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_4_secuserfullname1), "%", "");
         lV67Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV67Secuserclientewwds_5_secusername1), "%", "");
         lV67Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV67Secuserclientewwds_5_secusername1), "%", "");
         lV71Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_9_secuserfullname2), "%", "");
         lV71Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_9_secuserfullname2), "%", "");
         lV72Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV72Secuserclientewwds_10_secusername2), "%", "");
         lV72Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV72Secuserclientewwds_10_secusername2), "%", "");
         lV76Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV76Secuserclientewwds_14_secuserfullname3), "%", "");
         lV76Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV76Secuserclientewwds_14_secuserfullname3), "%", "");
         lV77Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV77Secuserclientewwds_15_secusername3), "%", "");
         lV77Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV77Secuserclientewwds_15_secusername3), "%", "");
         lV78Secuserclientewwds_16_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV78Secuserclientewwds_16_tfsecuserfullname), "%", "");
         lV80Secuserclientewwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV80Secuserclientewwds_18_tfsecusername), "%", "");
         lV82Secuserclientewwds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV82Secuserclientewwds_20_tfsecuseremail), "%", "");
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {AV51SecUserClienteId, lV63Secuserclientewwds_1_filterfulltext, lV63Secuserclientewwds_1_filterfulltext, lV63Secuserclientewwds_1_filterfulltext, lV63Secuserclientewwds_1_filterfulltext, lV63Secuserclientewwds_1_filterfulltext, lV66Secuserclientewwds_4_secuserfullname1, lV66Secuserclientewwds_4_secuserfullname1, lV67Secuserclientewwds_5_secusername1, lV67Secuserclientewwds_5_secusername1, lV71Secuserclientewwds_9_secuserfullname2, lV71Secuserclientewwds_9_secuserfullname2, lV72Secuserclientewwds_10_secusername2, lV72Secuserclientewwds_10_secusername2, lV76Secuserclientewwds_14_secuserfullname3, lV76Secuserclientewwds_14_secuserfullname3, lV77Secuserclientewwds_15_secusername3, lV77Secuserclientewwds_15_secusername3, lV78Secuserclientewwds_16_tfsecuserfullname, AV79Secuserclientewwds_17_tfsecuserfullname_sel, lV80Secuserclientewwds_18_tfsecusername, AV81Secuserclientewwds_19_tfsecusername_sel, lV82Secuserclientewwds_20_tfsecuseremail, AV83Secuserclientewwds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210SecUserClienteId = P006N2_A210SecUserClienteId[0];
            n210SecUserClienteId = P006N2_n210SecUserClienteId[0];
            A150SecUserStatus = P006N2_A150SecUserStatus[0];
            n150SecUserStatus = P006N2_n150SecUserStatus[0];
            A144SecUserEmail = P006N2_A144SecUserEmail[0];
            n144SecUserEmail = P006N2_n144SecUserEmail[0];
            A141SecUserName = P006N2_A141SecUserName[0];
            n141SecUserName = P006N2_n141SecUserName[0];
            A143SecUserFullName = P006N2_A143SecUserFullName[0];
            n143SecUserFullName = P006N2_n143SecUserFullName[0];
            A133SecUserId = P006N2_A133SecUserId[0];
            AV27SecUserStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
            {
               AV27SecUserStatusDescription = "ATIVO";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
            {
               AV27SecUserStatusDescription = "INATIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6N0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")), 30, Gx_line+10, 216, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")), 220, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A144SecUserEmail, "")), 410, Gx_line+10, 596, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27SecUserStatusDescription, "")), 600, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("SecUserClienteWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserClienteWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("SecUserClienteWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV32TFSecUserFullName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV33TFSecUserFullName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV52TFSecUserName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV53TFSecUserName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV34TFSecUserEmail = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV35TFSecUserEmail_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV36TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV85GXV1 = (int)(AV85GXV1+1);
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

      protected void H6N0( bool bFoot ,
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
                  AV47PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV44DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV49Title = "";
         AV59Companyname = "";
         AV48Phone = "";
         AV46Mail = "";
         AV50Website = "";
         AV39AddressLine1 = "";
         AV40AddressLine2 = "";
         AV41AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15SecUserFullName1 = "";
         AV16FilterSecUserFullNameDescription = "";
         AV17SecUserFullName = "";
         AV54SecUserName1 = "";
         AV55FilterSecUserNameDescription = "";
         AV56SecUserName = "";
         AV19DynamicFiltersSelector2 = "";
         AV21SecUserFullName2 = "";
         AV57SecUserName2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25SecUserFullName3 = "";
         AV58SecUserName3 = "";
         AV33TFSecUserFullName_Sel = "";
         AV32TFSecUserFullName = "";
         AV53TFSecUserName_Sel = "";
         AV52TFSecUserName = "";
         AV35TFSecUserEmail_Sel = "";
         AV34TFSecUserEmail = "";
         AV37FilterTFSecUserStatus_SelValueDescription = "";
         AV63Secuserclientewwds_1_filterfulltext = "";
         AV64Secuserclientewwds_2_dynamicfiltersselector1 = "";
         AV66Secuserclientewwds_4_secuserfullname1 = "";
         AV67Secuserclientewwds_5_secusername1 = "";
         AV69Secuserclientewwds_7_dynamicfiltersselector2 = "";
         AV71Secuserclientewwds_9_secuserfullname2 = "";
         AV72Secuserclientewwds_10_secusername2 = "";
         AV74Secuserclientewwds_12_dynamicfiltersselector3 = "";
         AV76Secuserclientewwds_14_secuserfullname3 = "";
         AV77Secuserclientewwds_15_secusername3 = "";
         AV78Secuserclientewwds_16_tfsecuserfullname = "";
         AV79Secuserclientewwds_17_tfsecuserfullname_sel = "";
         AV80Secuserclientewwds_18_tfsecusername = "";
         AV81Secuserclientewwds_19_tfsecusername_sel = "";
         AV82Secuserclientewwds_20_tfsecuseremail = "";
         AV83Secuserclientewwds_21_tfsecuseremail_sel = "";
         lV63Secuserclientewwds_1_filterfulltext = "";
         lV66Secuserclientewwds_4_secuserfullname1 = "";
         lV67Secuserclientewwds_5_secusername1 = "";
         lV71Secuserclientewwds_9_secuserfullname2 = "";
         lV72Secuserclientewwds_10_secusername2 = "";
         lV76Secuserclientewwds_14_secuserfullname3 = "";
         lV77Secuserclientewwds_15_secusername3 = "";
         lV78Secuserclientewwds_16_tfsecuserfullname = "";
         lV80Secuserclientewwds_18_tfsecusername = "";
         lV82Secuserclientewwds_20_tfsecuseremail = "";
         A143SecUserFullName = "";
         A141SecUserName = "";
         A144SecUserEmail = "";
         P006N2_A210SecUserClienteId = new short[1] ;
         P006N2_n210SecUserClienteId = new bool[] {false} ;
         P006N2_A150SecUserStatus = new bool[] {false} ;
         P006N2_n150SecUserStatus = new bool[] {false} ;
         P006N2_A144SecUserEmail = new string[] {""} ;
         P006N2_n144SecUserEmail = new bool[] {false} ;
         P006N2_A141SecUserName = new string[] {""} ;
         P006N2_n141SecUserName = new bool[] {false} ;
         P006N2_A143SecUserFullName = new string[] {""} ;
         P006N2_n143SecUserFullName = new bool[] {false} ;
         P006N2_A133SecUserId = new short[1] ;
         AV27SecUserStatusDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47PageInfo = "";
         AV44DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV42AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserclientewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006N2_A210SecUserClienteId, P006N2_n210SecUserClienteId, P006N2_A150SecUserStatus, P006N2_n150SecUserStatus, P006N2_A144SecUserEmail, P006N2_n144SecUserEmail, P006N2_A141SecUserName, P006N2_n141SecUserName, P006N2_A143SecUserFullName, P006N2_n143SecUserFullName,
               P006N2_A133SecUserId
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
      private short AV36TFSecUserStatus_Sel ;
      private short AV65Secuserclientewwds_3_dynamicfiltersoperator1 ;
      private short AV70Secuserclientewwds_8_dynamicfiltersoperator2 ;
      private short AV75Secuserclientewwds_13_dynamicfiltersoperator3 ;
      private short AV84Secuserclientewwds_22_tfsecuserstatus_sel ;
      private short AV10OrderedBy ;
      private short AV51SecUserClienteId ;
      private short A210SecUserClienteId ;
      private short A133SecUserId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV85GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV38TempBoolean ;
      private bool AV68Secuserclientewwds_6_dynamicfiltersenabled2 ;
      private bool AV73Secuserclientewwds_11_dynamicfiltersenabled3 ;
      private bool A150SecUserStatus ;
      private bool AV11OrderedDsc ;
      private bool n210SecUserClienteId ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private string AV59Companyname ;
      private string AV49Title ;
      private string AV48Phone ;
      private string AV46Mail ;
      private string AV50Website ;
      private string AV39AddressLine1 ;
      private string AV40AddressLine2 ;
      private string AV41AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15SecUserFullName1 ;
      private string AV16FilterSecUserFullNameDescription ;
      private string AV17SecUserFullName ;
      private string AV54SecUserName1 ;
      private string AV55FilterSecUserNameDescription ;
      private string AV56SecUserName ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21SecUserFullName2 ;
      private string AV57SecUserName2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25SecUserFullName3 ;
      private string AV58SecUserName3 ;
      private string AV33TFSecUserFullName_Sel ;
      private string AV32TFSecUserFullName ;
      private string AV53TFSecUserName_Sel ;
      private string AV52TFSecUserName ;
      private string AV35TFSecUserEmail_Sel ;
      private string AV34TFSecUserEmail ;
      private string AV37FilterTFSecUserStatus_SelValueDescription ;
      private string AV63Secuserclientewwds_1_filterfulltext ;
      private string AV64Secuserclientewwds_2_dynamicfiltersselector1 ;
      private string AV66Secuserclientewwds_4_secuserfullname1 ;
      private string AV67Secuserclientewwds_5_secusername1 ;
      private string AV69Secuserclientewwds_7_dynamicfiltersselector2 ;
      private string AV71Secuserclientewwds_9_secuserfullname2 ;
      private string AV72Secuserclientewwds_10_secusername2 ;
      private string AV74Secuserclientewwds_12_dynamicfiltersselector3 ;
      private string AV76Secuserclientewwds_14_secuserfullname3 ;
      private string AV77Secuserclientewwds_15_secusername3 ;
      private string AV78Secuserclientewwds_16_tfsecuserfullname ;
      private string AV79Secuserclientewwds_17_tfsecuserfullname_sel ;
      private string AV80Secuserclientewwds_18_tfsecusername ;
      private string AV81Secuserclientewwds_19_tfsecusername_sel ;
      private string AV82Secuserclientewwds_20_tfsecuseremail ;
      private string AV83Secuserclientewwds_21_tfsecuseremail_sel ;
      private string lV63Secuserclientewwds_1_filterfulltext ;
      private string lV66Secuserclientewwds_4_secuserfullname1 ;
      private string lV67Secuserclientewwds_5_secusername1 ;
      private string lV71Secuserclientewwds_9_secuserfullname2 ;
      private string lV72Secuserclientewwds_10_secusername2 ;
      private string lV76Secuserclientewwds_14_secuserfullname3 ;
      private string lV77Secuserclientewwds_15_secusername3 ;
      private string lV78Secuserclientewwds_16_tfsecuserfullname ;
      private string lV80Secuserclientewwds_18_tfsecusername ;
      private string lV82Secuserclientewwds_20_tfsecuseremail ;
      private string A143SecUserFullName ;
      private string A141SecUserName ;
      private string A144SecUserEmail ;
      private string AV27SecUserStatusDescription ;
      private string AV47PageInfo ;
      private string AV44DateInfo ;
      private string AV42AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P006N2_A210SecUserClienteId ;
      private bool[] P006N2_n210SecUserClienteId ;
      private bool[] P006N2_A150SecUserStatus ;
      private bool[] P006N2_n150SecUserStatus ;
      private string[] P006N2_A144SecUserEmail ;
      private bool[] P006N2_n144SecUserEmail ;
      private string[] P006N2_A141SecUserName ;
      private bool[] P006N2_n141SecUserName ;
      private string[] P006N2_A143SecUserFullName ;
      private bool[] P006N2_n143SecUserFullName ;
      private short[] P006N2_A133SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class secuserclientewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006N2( IGxContext context ,
                                             string AV63Secuserclientewwds_1_filterfulltext ,
                                             string AV64Secuserclientewwds_2_dynamicfiltersselector1 ,
                                             short AV65Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV66Secuserclientewwds_4_secuserfullname1 ,
                                             string AV67Secuserclientewwds_5_secusername1 ,
                                             bool AV68Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                             string AV69Secuserclientewwds_7_dynamicfiltersselector2 ,
                                             short AV70Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                             string AV71Secuserclientewwds_9_secuserfullname2 ,
                                             string AV72Secuserclientewwds_10_secusername2 ,
                                             bool AV73Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                             string AV74Secuserclientewwds_12_dynamicfiltersselector3 ,
                                             short AV75Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                             string AV76Secuserclientewwds_14_secuserfullname3 ,
                                             string AV77Secuserclientewwds_15_secusername3 ,
                                             string AV79Secuserclientewwds_17_tfsecuserfullname_sel ,
                                             string AV78Secuserclientewwds_16_tfsecuserfullname ,
                                             string AV81Secuserclientewwds_19_tfsecusername_sel ,
                                             string AV80Secuserclientewwds_18_tfsecusername ,
                                             string AV83Secuserclientewwds_21_tfsecuseremail_sel ,
                                             string AV82Secuserclientewwds_20_tfsecuseremail ,
                                             short AV84Secuserclientewwds_22_tfsecuserstatus_sel ,
                                             string A143SecUserFullName ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc ,
                                             short AV51SecUserClienteId ,
                                             short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[24];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT SecUserClienteId, SecUserStatus, SecUserEmail, SecUserName, SecUserFullName, SecUserId FROM SecUser";
         AddWhere(sWhereString, "(SecUserClienteId = :AV51SecUserClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Secuserclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserFullName like '%' || :lV63Secuserclientewwds_1_filterfulltext) or ( SecUserName like '%' || :lV63Secuserclientewwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV63Secuserclientewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV63Secuserclientewwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV63Secuserclientewwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV65Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV66Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV65Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV66Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV65Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV67Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV65Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV67Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV68Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV70Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV71Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV68Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV70Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV71Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV68Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV70Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV72Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV68Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV70Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV72Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV73Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV75Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV76Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV73Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV75Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV76Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV73Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV77Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV73Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV77Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserclientewwds_17_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Secuserclientewwds_16_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV78Secuserclientewwds_16_tfsecuserfullname)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserclientewwds_17_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV79Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV79Secuserclientewwds_17_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV79Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserclientewwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserclientewwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV80Secuserclientewwds_18_tfsecusername)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserclientewwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV81Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV81Secuserclientewwds_19_tfsecusername_sel))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV81Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Secuserclientewwds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserclientewwds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV82Secuserclientewwds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Secuserclientewwds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV83Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV83Secuserclientewwds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV83Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV84Secuserclientewwds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV84Secuserclientewwds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserFullName";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserFullName DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserName";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserName DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserEmail";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserEmail DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserStatus";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserStatus DESC";
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
                     return conditional_P006N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] );
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
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("AV51SecUserClienteId",GXType.Int16,4,0) ,
          new ParDef("lV63Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV66Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV67Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV67Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV71Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV71Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV72Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV76Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV76Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV77Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV77Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV78Secuserclientewwds_16_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV79Secuserclientewwds_17_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Secuserclientewwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV81Secuserclientewwds_19_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Secuserclientewwds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV83Secuserclientewwds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
