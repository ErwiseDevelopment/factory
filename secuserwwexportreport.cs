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
   public class secuserwwexportreport : GXWebProcedure
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

      public secuserwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserwwexportreport( IGxContext context )
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
         setOutputFileName("SecUserWWExportReport");
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
            AV56Title = "Lista de Usuário";
            GXt_char1 = AV58Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV58Companyname = GXt_char1;
            GXt_char1 = AV55Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV55Phone = GXt_char1;
            GXt_char1 = AV53Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV53Mail = GXt_char1;
            GXt_char1 = AV57Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV57Website = GXt_char1;
            GXt_char1 = AV46AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV46AddressLine1 = GXt_char1;
            GXt_char1 = AV47AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV47AddressLine2 = GXt_char1;
            GXt_char1 = AV48AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV48AddressLine3 = GXt_char1;
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
            H820( true, 0) ;
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
            H820( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV15SecUserName1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15SecUserName1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17SecUserName = AV15SecUserName1;
                  H820( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecUserNameDescription, "")), 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecUserName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV18SecUserManName1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecUserManName1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV19FilterSecUserManNameDescription = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV19FilterSecUserManNameDescription = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Contém", "", "", "", "", "", "", "");
                  }
                  AV20SecUserManName = AV18SecUserManName1;
                  H820( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterSecUserManNameDescription, "")), 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20SecUserManName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV24SecUserName2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecUserName2)) )
                  {
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17SecUserName = AV24SecUserName2;
                     H820( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecUserNameDescription, "")), 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecUserName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV25SecUserManName2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecUserManName2)) )
                  {
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV19FilterSecUserManNameDescription = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV19FilterSecUserManNameDescription = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Contém", "", "", "", "", "", "", "");
                     }
                     AV20SecUserManName = AV25SecUserManName2;
                     H820( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterSecUserManNameDescription, "")), 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20SecUserManName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV29SecUserName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserName3)) )
                     {
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17SecUserName = AV29SecUserName3;
                        H820( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecUserNameDescription, "")), 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecUserName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30SecUserManName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecUserManName3)) )
                     {
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV19FilterSecUserManNameDescription = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV19FilterSecUserManNameDescription = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Contém", "", "", "", "", "", "", "");
                        }
                        AV20SecUserManName = AV30SecUserManName3;
                        H820( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterSecUserManNameDescription, "")), 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20SecUserManName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFSecUserName_Sel, "<#Empty#>")==0)));
            AV38TFSecUserName_Sel = (AV45TempBoolean ? "(Vazio)" : AV38TFSecUserName_Sel);
            H820( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuário", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFSecUserName_Sel, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFSecUserName_Sel = (AV45TempBoolean ? "<#Empty#>" : AV38TFSecUserName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSecUserName)) )
            {
               H820( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuário", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFSecUserName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserFullName_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFSecUserFullName_Sel, "<#Empty#>")==0)));
            AV40TFSecUserFullName_Sel = (AV45TempBoolean ? "(Vazio)" : AV40TFSecUserFullName_Sel);
            H820( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFSecUserFullName_Sel, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFSecUserFullName_Sel = (AV45TempBoolean ? "<#Empty#>" : AV40TFSecUserFullName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserFullName)) )
            {
               H820( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFSecUserFullName, "@!")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserEmail_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFSecUserEmail_Sel, "<#Empty#>")==0)));
            AV42TFSecUserEmail_Sel = (AV45TempBoolean ? "(Vazio)" : AV42TFSecUserEmail_Sel);
            H820( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFSecUserEmail_Sel, "")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFSecUserEmail_Sel = (AV45TempBoolean ? "<#Empty#>" : AV42TFSecUserEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserEmail)) )
            {
               H820( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFSecUserEmail, "")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV43TFSecUserStatus_Sel) )
         {
            if ( AV43TFSecUserStatus_Sel == 1 )
            {
               AV44FilterTFSecUserStatus_SelValueDescription = "Marcado";
            }
            else if ( AV43TFSecUserStatus_Sel == 2 )
            {
               AV44FilterTFSecUserStatus_SelValueDescription = "Desmarcado";
            }
            H820( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 247, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44FilterTFSecUserStatus_SelValueDescription, "")), 247, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H820( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H820( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Usuário", 30, Gx_line+10, 216, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome", 220, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("E-mail", 410, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 600, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12FilterFullText ,
                                              AV13DynamicFiltersSelector1 ,
                                              AV14DynamicFiltersOperator1 ,
                                              AV15SecUserName1 ,
                                              AV18SecUserManName1 ,
                                              AV21DynamicFiltersEnabled2 ,
                                              AV22DynamicFiltersSelector2 ,
                                              AV23DynamicFiltersOperator2 ,
                                              AV24SecUserName2 ,
                                              AV25SecUserManName2 ,
                                              AV26DynamicFiltersEnabled3 ,
                                              AV27DynamicFiltersSelector3 ,
                                              AV28DynamicFiltersOperator3 ,
                                              AV29SecUserName3 ,
                                              AV30SecUserManName3 ,
                                              AV38TFSecUserName_Sel ,
                                              AV37TFSecUserName ,
                                              AV40TFSecUserFullName_Sel ,
                                              AV39TFSecUserFullName ,
                                              AV42TFSecUserEmail_Sel ,
                                              AV41TFSecUserEmail ,
                                              AV43TFSecUserStatus_Sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV12FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV12FilterFullText), "%", "");
         lV12FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV12FilterFullText), "%", "");
         lV12FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV12FilterFullText), "%", "");
         lV12FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV12FilterFullText), "%", "");
         lV12FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV12FilterFullText), "%", "");
         lV15SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV15SecUserName1), "%", "");
         lV15SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV15SecUserName1), "%", "");
         lV18SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV18SecUserManName1), "%", "");
         lV18SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV18SecUserManName1), "%", "");
         lV24SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV24SecUserName2), "%", "");
         lV24SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV24SecUserName2), "%", "");
         lV25SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV25SecUserManName2), "%", "");
         lV25SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV25SecUserManName2), "%", "");
         lV29SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV29SecUserName3), "%", "");
         lV29SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV29SecUserName3), "%", "");
         lV30SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV30SecUserManName3), "%", "");
         lV30SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV30SecUserManName3), "%", "");
         lV37TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV37TFSecUserName), "%", "");
         lV39TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV39TFSecUserFullName), "%", "");
         lV41TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV41TFSecUserEmail), "%", "");
         /* Using cursor P00822 */
         pr_default.execute(0, new Object[] {lV12FilterFullText, lV12FilterFullText, lV12FilterFullText, lV12FilterFullText, lV12FilterFullText, lV15SecUserName1, lV15SecUserName1, lV18SecUserManName1, lV18SecUserManName1, lV24SecUserName2, lV24SecUserName2, lV25SecUserManName2, lV25SecUserManName2, lV29SecUserName3, lV29SecUserName3, lV30SecUserManName3, lV30SecUserManName3, lV37TFSecUserName, AV38TFSecUserName_Sel, lV39TFSecUserFullName, AV40TFSecUserFullName_Sel, lV41TFSecUserEmail, AV42TFSecUserEmail_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A147SecUserUserMan = P00822_A147SecUserUserMan[0];
            n147SecUserUserMan = P00822_n147SecUserUserMan[0];
            A148SecUserManName = P00822_A148SecUserManName[0];
            n148SecUserManName = P00822_n148SecUserManName[0];
            A150SecUserStatus = P00822_A150SecUserStatus[0];
            n150SecUserStatus = P00822_n150SecUserStatus[0];
            A144SecUserEmail = P00822_A144SecUserEmail[0];
            n144SecUserEmail = P00822_n144SecUserEmail[0];
            A143SecUserFullName = P00822_A143SecUserFullName[0];
            n143SecUserFullName = P00822_n143SecUserFullName[0];
            A141SecUserName = P00822_A141SecUserName[0];
            n141SecUserName = P00822_n141SecUserName[0];
            A133SecUserId = P00822_A133SecUserId[0];
            A148SecUserManName = P00822_A148SecUserManName[0];
            n148SecUserManName = P00822_n148SecUserManName[0];
            AV32SecUserStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
            {
               AV32SecUserStatusDescription = "ATIVO";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
            {
               AV32SecUserStatusDescription = "INATIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H820( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")), 30, Gx_line+10, 216, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")), 220, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A144SecUserEmail, "")), 410, Gx_line+10, 596, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32SecUserStatusDescription, "")), 600, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV33Session.Get("SecUserWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("SecUserWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV37TFSecUserName = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV38TFSecUserName_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV39TFSecUserFullName = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV40TFSecUserFullName_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV41TFSecUserEmail = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV42TFSecUserEmail_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV43TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV62GXV1 = (int)(AV62GXV1+1);
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

      protected void H820( bool bFoot ,
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
                  AV54PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV51DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV56Title = "";
         AV58Companyname = "";
         AV55Phone = "";
         AV53Mail = "";
         AV57Website = "";
         AV46AddressLine1 = "";
         AV47AddressLine2 = "";
         AV48AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15SecUserName1 = "";
         AV16FilterSecUserNameDescription = "";
         AV17SecUserName = "";
         AV18SecUserManName1 = "";
         AV19FilterSecUserManNameDescription = "";
         AV20SecUserManName = "";
         AV22DynamicFiltersSelector2 = "";
         AV24SecUserName2 = "";
         AV25SecUserManName2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29SecUserName3 = "";
         AV30SecUserManName3 = "";
         AV38TFSecUserName_Sel = "";
         AV37TFSecUserName = "";
         AV40TFSecUserFullName_Sel = "";
         AV39TFSecUserFullName = "";
         AV42TFSecUserEmail_Sel = "";
         AV41TFSecUserEmail = "";
         AV44FilterTFSecUserStatus_SelValueDescription = "";
         lV12FilterFullText = "";
         lV15SecUserName1 = "";
         lV18SecUserManName1 = "";
         lV24SecUserName2 = "";
         lV25SecUserManName2 = "";
         lV29SecUserName3 = "";
         lV30SecUserManName3 = "";
         lV37TFSecUserName = "";
         lV39TFSecUserFullName = "";
         lV41TFSecUserEmail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         A148SecUserManName = "";
         P00822_A147SecUserUserMan = new short[1] ;
         P00822_n147SecUserUserMan = new bool[] {false} ;
         P00822_A148SecUserManName = new string[] {""} ;
         P00822_n148SecUserManName = new bool[] {false} ;
         P00822_A150SecUserStatus = new bool[] {false} ;
         P00822_n150SecUserStatus = new bool[] {false} ;
         P00822_A144SecUserEmail = new string[] {""} ;
         P00822_n144SecUserEmail = new bool[] {false} ;
         P00822_A143SecUserFullName = new string[] {""} ;
         P00822_n143SecUserFullName = new bool[] {false} ;
         P00822_A141SecUserName = new string[] {""} ;
         P00822_n141SecUserName = new bool[] {false} ;
         P00822_A133SecUserId = new short[1] ;
         AV32SecUserStatusDescription = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54PageInfo = "";
         AV51DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV49AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00822_A147SecUserUserMan, P00822_n147SecUserUserMan, P00822_A148SecUserManName, P00822_n148SecUserManName, P00822_A150SecUserStatus, P00822_n150SecUserStatus, P00822_A144SecUserEmail, P00822_n144SecUserEmail, P00822_A143SecUserFullName, P00822_n143SecUserFullName,
               P00822_A141SecUserName, P00822_n141SecUserName, P00822_A133SecUserId
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
      private short AV23DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV43TFSecUserStatus_Sel ;
      private short AV10OrderedBy ;
      private short A147SecUserUserMan ;
      private short A133SecUserId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV62GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool A150SecUserStatus ;
      private bool AV11OrderedDsc ;
      private bool n147SecUserUserMan ;
      private bool n148SecUserManName ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool n141SecUserName ;
      private string AV58Companyname ;
      private string AV56Title ;
      private string AV55Phone ;
      private string AV53Mail ;
      private string AV57Website ;
      private string AV46AddressLine1 ;
      private string AV47AddressLine2 ;
      private string AV48AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15SecUserName1 ;
      private string AV16FilterSecUserNameDescription ;
      private string AV17SecUserName ;
      private string AV18SecUserManName1 ;
      private string AV19FilterSecUserManNameDescription ;
      private string AV20SecUserManName ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24SecUserName2 ;
      private string AV25SecUserManName2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29SecUserName3 ;
      private string AV30SecUserManName3 ;
      private string AV38TFSecUserName_Sel ;
      private string AV37TFSecUserName ;
      private string AV40TFSecUserFullName_Sel ;
      private string AV39TFSecUserFullName ;
      private string AV42TFSecUserEmail_Sel ;
      private string AV41TFSecUserEmail ;
      private string AV44FilterTFSecUserStatus_SelValueDescription ;
      private string lV12FilterFullText ;
      private string lV15SecUserName1 ;
      private string lV18SecUserManName1 ;
      private string lV24SecUserName2 ;
      private string lV25SecUserManName2 ;
      private string lV29SecUserName3 ;
      private string lV30SecUserManName3 ;
      private string lV37TFSecUserName ;
      private string lV39TFSecUserFullName ;
      private string lV41TFSecUserEmail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string A148SecUserManName ;
      private string AV32SecUserStatusDescription ;
      private string AV54PageInfo ;
      private string AV51DateInfo ;
      private string AV49AppName ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00822_A147SecUserUserMan ;
      private bool[] P00822_n147SecUserUserMan ;
      private string[] P00822_A148SecUserManName ;
      private bool[] P00822_n148SecUserManName ;
      private bool[] P00822_A150SecUserStatus ;
      private bool[] P00822_n150SecUserStatus ;
      private string[] P00822_A144SecUserEmail ;
      private bool[] P00822_n144SecUserEmail ;
      private string[] P00822_A143SecUserFullName ;
      private bool[] P00822_n143SecUserFullName ;
      private string[] P00822_A141SecUserName ;
      private bool[] P00822_n141SecUserName ;
      private short[] P00822_A133SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class secuserwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00822( IGxContext context ,
                                             string AV12FilterFullText ,
                                             string AV13DynamicFiltersSelector1 ,
                                             short AV14DynamicFiltersOperator1 ,
                                             string AV15SecUserName1 ,
                                             string AV18SecUserManName1 ,
                                             bool AV21DynamicFiltersEnabled2 ,
                                             string AV22DynamicFiltersSelector2 ,
                                             short AV23DynamicFiltersOperator2 ,
                                             string AV24SecUserName2 ,
                                             string AV25SecUserManName2 ,
                                             bool AV26DynamicFiltersEnabled3 ,
                                             string AV27DynamicFiltersSelector3 ,
                                             short AV28DynamicFiltersOperator3 ,
                                             string AV29SecUserName3 ,
                                             string AV30SecUserManName3 ,
                                             string AV38TFSecUserName_Sel ,
                                             string AV37TFSecUserName ,
                                             string AV40TFSecUserFullName_Sel ,
                                             string AV39TFSecUserFullName ,
                                             string AV42TFSecUserEmail_Sel ,
                                             string AV41TFSecUserEmail ,
                                             short AV43TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserFullName, T1.SecUserName, T1.SecUserId FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV12FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV12FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV12FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV12FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV12FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV15SecUserName1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV15SecUserName1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV14DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV18SecUserManName1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV14DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV18SecUserManName1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV21DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV23DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV24SecUserName2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV21DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV23DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV24SecUserName2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV21DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV23DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV25SecUserManName2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV21DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV23DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV25SecUserManName2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV28DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV29SecUserName3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV28DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV29SecUserName3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV28DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV30SecUserManName3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV28DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV30SecUserManName3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV37TFSecUserName)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV38TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV38TFSecUserName_Sel))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV39TFSecUserFullName)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV40TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV40TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV40TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV41TFSecUserEmail)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV42TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV42TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV42TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV43TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV43TFSecUserStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserName";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserName DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserFullName";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserFullName DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserEmail";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserEmail DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserStatus";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserStatus DESC";
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
                     return conditional_P00822(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP00822;
          prmP00822 = new Object[] {
          new ParDef("lV12FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV12FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV12FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV12FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV12FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV15SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV15SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV18SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV18SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV24SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV24SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV25SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV25SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV29SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV29SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV30SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV30SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV37TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV38TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV39TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV40TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV41TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV42TFSecUserEmail_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
