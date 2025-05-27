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
   public class layoutcontratowwexportreport : GXWebProcedure
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

      public layoutcontratowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public layoutcontratowwexportreport( IGxContext context )
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
         setOutputFileName("LayoutContratoWWExportReport");
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
            AV49Title = "Lista de  Layout de contratos";
            GXt_char1 = AV61Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV61Companyname = GXt_char1;
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
            H6G0( true, 0) ;
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
            H6G0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "LAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15LayoutContratoDescricao1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15LayoutContratoDescricao1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterLayoutContratoDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterLayoutContratoDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17LayoutContratoDescricao = AV15LayoutContratoDescricao1;
                  H6G0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterLayoutContratoDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17LayoutContratoDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "LAYOUTCONTRATODESCRICAO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21LayoutContratoDescricao2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21LayoutContratoDescricao2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterLayoutContratoDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterLayoutContratoDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17LayoutContratoDescricao = AV21LayoutContratoDescricao2;
                     H6G0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterLayoutContratoDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17LayoutContratoDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "LAYOUTCONTRATODESCRICAO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25LayoutContratoDescricao3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25LayoutContratoDescricao3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterLayoutContratoDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterLayoutContratoDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17LayoutContratoDescricao = AV25LayoutContratoDescricao3;
                        H6G0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterLayoutContratoDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17LayoutContratoDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFLayoutContratoDescricao_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFLayoutContratoDescricao_Sel, "<#Empty#>")==0)));
            AV34TFLayoutContratoDescricao_Sel = (AV38TempBoolean ? "(Vazio)" : AV34TFLayoutContratoDescricao_Sel);
            H6G0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFLayoutContratoDescricao_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFLayoutContratoDescricao_Sel = (AV38TempBoolean ? "<#Empty#>" : AV34TFLayoutContratoDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFLayoutContratoDescricao)) )
            {
               H6G0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFLayoutContratoDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV35TFLayoutContratoStatus_Sel) )
         {
            if ( AV35TFLayoutContratoStatus_Sel == 1 )
            {
               AV37FilterTFLayoutContratoStatus_SelValueDescription = "Marcado";
            }
            else if ( AV35TFLayoutContratoStatus_Sel == 2 )
            {
               AV37FilterTFLayoutContratoStatus_SelValueDescription = "Desmarcado";
            }
            H6G0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ativo", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterTFLayoutContratoStatus_SelValueDescription, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV56TFLayoutContratoTipo_Sels.FromJSonString(AV53TFLayoutContratoTipo_SelsJson, null);
         if ( ! ( AV56TFLayoutContratoTipo_Sels.Count == 0 ) )
         {
            AV58i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV56TFLayoutContratoTipo_Sels.Count )
            {
               AV55TFLayoutContratoTipo_Sel = ((string)AV56TFLayoutContratoTipo_Sels.Item(AV64GXV1));
               if ( AV58i == 1 )
               {
                  AV54TFLayoutContratoTipo_SelDscs = "";
               }
               else
               {
                  AV54TFLayoutContratoTipo_SelDscs += ", ";
               }
               AV57FilterTFLayoutContratoTipo_SelValueDescription = gxdomaintipolayout.getDescription(context,AV55TFLayoutContratoTipo_Sel);
               AV54TFLayoutContratoTipo_SelDscs += AV57FilterTFLayoutContratoTipo_SelValueDescription;
               AV58i = (long)(AV58i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
            H6G0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFLayoutContratoTipo_SelDscs, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFLayoutContratoTag_Sel)) )
         {
            AV38TempBoolean = (bool)(((StringUtil.StrCmp(AV60TFLayoutContratoTag_Sel, "<#Empty#>")==0)));
            AV60TFLayoutContratoTag_Sel = (AV38TempBoolean ? "(Vazio)" : AV60TFLayoutContratoTag_Sel);
            H6G0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tag", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFLayoutContratoTag_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV60TFLayoutContratoTag_Sel = (AV38TempBoolean ? "<#Empty#>" : AV60TFLayoutContratoTag_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFLayoutContratoTag)) )
            {
               H6G0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tag", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFLayoutContratoTag, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6G0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6G0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Descrição", 30, Gx_line+10, 216, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ativo", 220, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 410, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tag", 600, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Layoutcontratowwds_1_filterfulltext = AV12FilterFullText;
         AV67Layoutcontratowwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV68Layoutcontratowwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV69Layoutcontratowwds_4_layoutcontratodescricao1 = AV15LayoutContratoDescricao1;
         AV70Layoutcontratowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Layoutcontratowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Layoutcontratowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Layoutcontratowwds_8_layoutcontratodescricao2 = AV21LayoutContratoDescricao2;
         AV74Layoutcontratowwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV75Layoutcontratowwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV76Layoutcontratowwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV77Layoutcontratowwds_12_layoutcontratodescricao3 = AV25LayoutContratoDescricao3;
         AV78Layoutcontratowwds_13_tflayoutcontratodescricao = AV33TFLayoutContratoDescricao;
         AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV34TFLayoutContratoDescricao_Sel;
         AV80Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV35TFLayoutContratoStatus_Sel;
         AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV56TFLayoutContratoTipo_Sels;
         AV82Layoutcontratowwds_17_tflayoutcontratotag = AV59TFLayoutContratoTag;
         AV83Layoutcontratowwds_18_tflayoutcontratotag_sel = AV60TFLayoutContratoTag_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A906LayoutContratoTipo ,
                                              AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                              AV66Layoutcontratowwds_1_filterfulltext ,
                                              AV67Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                              AV68Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                              AV69Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                              AV70Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                              AV71Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                              AV72Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                              AV73Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                              AV74Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                              AV75Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                              AV76Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                              AV77Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                              AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                              AV78Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                              AV80Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                              AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels.Count ,
                                              AV83Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                              AV82Layoutcontratowwds_17_tflayoutcontratotag ,
                                              A155LayoutContratoDescricao ,
                                              A156LayoutContratoStatus ,
                                              A1000LayoutContratoTag ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext), "%", "");
         lV69Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV69Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV69Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV69Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV73Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV73Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV73Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV73Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV77Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV77Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV77Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV77Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV78Layoutcontratowwds_13_tflayoutcontratodescricao = StringUtil.Concat( StringUtil.RTrim( AV78Layoutcontratowwds_13_tflayoutcontratodescricao), "%", "");
         lV82Layoutcontratowwds_17_tflayoutcontratotag = StringUtil.Concat( StringUtil.RTrim( AV82Layoutcontratowwds_17_tflayoutcontratotag), "%", "");
         /* Using cursor P006G2 */
         pr_default.execute(0, new Object[] {lV66Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_1_filterfulltext, lV69Layoutcontratowwds_4_layoutcontratodescricao1, lV69Layoutcontratowwds_4_layoutcontratodescricao1, lV73Layoutcontratowwds_8_layoutcontratodescricao2, lV73Layoutcontratowwds_8_layoutcontratodescricao2, lV77Layoutcontratowwds_12_layoutcontratodescricao3, lV77Layoutcontratowwds_12_layoutcontratodescricao3, lV78Layoutcontratowwds_13_tflayoutcontratodescricao, AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel, lV82Layoutcontratowwds_17_tflayoutcontratotag, AV83Layoutcontratowwds_18_tflayoutcontratotag_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1000LayoutContratoTag = P006G2_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = P006G2_n1000LayoutContratoTag[0];
            A906LayoutContratoTipo = P006G2_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = P006G2_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = P006G2_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = P006G2_n156LayoutContratoStatus[0];
            A155LayoutContratoDescricao = P006G2_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = P006G2_n155LayoutContratoDescricao[0];
            A154LayoutContratoId = P006G2_A154LayoutContratoId[0];
            AV51LayoutContratoStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A156LayoutContratoStatus)), "true") == 0 )
            {
               AV51LayoutContratoStatusDescription = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A156LayoutContratoStatus)), "false") == 0 )
            {
               AV51LayoutContratoStatusDescription = "Não";
            }
            AV52LayoutContratoTipoDescription = gxdomaintipolayout.getDescription(context,A906LayoutContratoTipo);
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6G0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A155LayoutContratoDescricao, "")), 30, Gx_line+10, 216, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51LayoutContratoStatusDescription, "")), 220, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52LayoutContratoTipoDescription, "")), 410, Gx_line+10, 596, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1000LayoutContratoTag, "")), 600, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("LayoutContratoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LayoutContratoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("LayoutContratoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV33TFLayoutContratoDescricao = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO_SEL") == 0 )
            {
               AV34TFLayoutContratoDescricao_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOSTATUS_SEL") == 0 )
            {
               AV35TFLayoutContratoStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTIPO_SEL") == 0 )
            {
               AV53TFLayoutContratoTipo_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV56TFLayoutContratoTipo_Sels.FromJSonString(AV53TFLayoutContratoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG") == 0 )
            {
               AV59TFLayoutContratoTag = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG_SEL") == 0 )
            {
               AV60TFLayoutContratoTag_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV84GXV2 = (int)(AV84GXV2+1);
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

      protected void H6G0( bool bFoot ,
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
         AV61Companyname = "";
         AV48Phone = "";
         AV46Mail = "";
         AV50Website = "";
         AV39AddressLine1 = "";
         AV40AddressLine2 = "";
         AV41AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15LayoutContratoDescricao1 = "";
         AV16FilterLayoutContratoDescricaoDescription = "";
         AV17LayoutContratoDescricao = "";
         AV19DynamicFiltersSelector2 = "";
         AV21LayoutContratoDescricao2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25LayoutContratoDescricao3 = "";
         AV34TFLayoutContratoDescricao_Sel = "";
         AV33TFLayoutContratoDescricao = "";
         AV37FilterTFLayoutContratoStatus_SelValueDescription = "";
         AV56TFLayoutContratoTipo_Sels = new GxSimpleCollection<string>();
         AV53TFLayoutContratoTipo_SelsJson = "";
         AV55TFLayoutContratoTipo_Sel = "";
         AV54TFLayoutContratoTipo_SelDscs = "";
         AV57FilterTFLayoutContratoTipo_SelValueDescription = "";
         AV60TFLayoutContratoTag_Sel = "";
         AV59TFLayoutContratoTag = "";
         AV66Layoutcontratowwds_1_filterfulltext = "";
         AV67Layoutcontratowwds_2_dynamicfiltersselector1 = "";
         AV69Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         AV71Layoutcontratowwds_6_dynamicfiltersselector2 = "";
         AV73Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         AV75Layoutcontratowwds_10_dynamicfiltersselector3 = "";
         AV77Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         AV78Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel = "";
         AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels = new GxSimpleCollection<string>();
         AV82Layoutcontratowwds_17_tflayoutcontratotag = "";
         AV83Layoutcontratowwds_18_tflayoutcontratotag_sel = "";
         lV66Layoutcontratowwds_1_filterfulltext = "";
         lV69Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         lV73Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         lV77Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         lV78Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         lV82Layoutcontratowwds_17_tflayoutcontratotag = "";
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         A1000LayoutContratoTag = "";
         P006G2_A1000LayoutContratoTag = new string[] {""} ;
         P006G2_n1000LayoutContratoTag = new bool[] {false} ;
         P006G2_A906LayoutContratoTipo = new string[] {""} ;
         P006G2_n906LayoutContratoTipo = new bool[] {false} ;
         P006G2_A156LayoutContratoStatus = new bool[] {false} ;
         P006G2_n156LayoutContratoStatus = new bool[] {false} ;
         P006G2_A155LayoutContratoDescricao = new string[] {""} ;
         P006G2_n155LayoutContratoDescricao = new bool[] {false} ;
         P006G2_A154LayoutContratoId = new short[1] ;
         AV51LayoutContratoStatusDescription = "";
         AV52LayoutContratoTipoDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47PageInfo = "";
         AV44DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV42AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.layoutcontratowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006G2_A1000LayoutContratoTag, P006G2_n1000LayoutContratoTag, P006G2_A906LayoutContratoTipo, P006G2_n906LayoutContratoTipo, P006G2_A156LayoutContratoStatus, P006G2_n156LayoutContratoStatus, P006G2_A155LayoutContratoDescricao, P006G2_n155LayoutContratoDescricao, P006G2_A154LayoutContratoId
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
      private short AV35TFLayoutContratoStatus_Sel ;
      private short AV68Layoutcontratowwds_3_dynamicfiltersoperator1 ;
      private short AV72Layoutcontratowwds_7_dynamicfiltersoperator2 ;
      private short AV76Layoutcontratowwds_11_dynamicfiltersoperator3 ;
      private short AV80Layoutcontratowwds_15_tflayoutcontratostatus_sel ;
      private short AV10OrderedBy ;
      private short A154LayoutContratoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV64GXV1 ;
      private int AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ;
      private int AV84GXV2 ;
      private long AV58i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV38TempBoolean ;
      private bool AV70Layoutcontratowwds_5_dynamicfiltersenabled2 ;
      private bool AV74Layoutcontratowwds_9_dynamicfiltersenabled3 ;
      private bool A156LayoutContratoStatus ;
      private bool AV11OrderedDsc ;
      private bool n1000LayoutContratoTag ;
      private bool n906LayoutContratoTipo ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private string AV61Companyname ;
      private string AV53TFLayoutContratoTipo_SelsJson ;
      private string AV49Title ;
      private string AV48Phone ;
      private string AV46Mail ;
      private string AV50Website ;
      private string AV39AddressLine1 ;
      private string AV40AddressLine2 ;
      private string AV41AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15LayoutContratoDescricao1 ;
      private string AV16FilterLayoutContratoDescricaoDescription ;
      private string AV17LayoutContratoDescricao ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21LayoutContratoDescricao2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25LayoutContratoDescricao3 ;
      private string AV34TFLayoutContratoDescricao_Sel ;
      private string AV33TFLayoutContratoDescricao ;
      private string AV37FilterTFLayoutContratoStatus_SelValueDescription ;
      private string AV55TFLayoutContratoTipo_Sel ;
      private string AV54TFLayoutContratoTipo_SelDscs ;
      private string AV57FilterTFLayoutContratoTipo_SelValueDescription ;
      private string AV60TFLayoutContratoTag_Sel ;
      private string AV59TFLayoutContratoTag ;
      private string AV66Layoutcontratowwds_1_filterfulltext ;
      private string AV67Layoutcontratowwds_2_dynamicfiltersselector1 ;
      private string AV69Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string AV71Layoutcontratowwds_6_dynamicfiltersselector2 ;
      private string AV73Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string AV75Layoutcontratowwds_10_dynamicfiltersselector3 ;
      private string AV77Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string AV78Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel ;
      private string AV82Layoutcontratowwds_17_tflayoutcontratotag ;
      private string AV83Layoutcontratowwds_18_tflayoutcontratotag_sel ;
      private string lV66Layoutcontratowwds_1_filterfulltext ;
      private string lV69Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string lV73Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string lV77Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string lV78Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string lV82Layoutcontratowwds_17_tflayoutcontratotag ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private string A1000LayoutContratoTag ;
      private string AV51LayoutContratoStatusDescription ;
      private string AV52LayoutContratoTipoDescription ;
      private string AV47PageInfo ;
      private string AV44DateInfo ;
      private string AV42AppName ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV56TFLayoutContratoTipo_Sels ;
      private GxSimpleCollection<string> AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006G2_A1000LayoutContratoTag ;
      private bool[] P006G2_n1000LayoutContratoTag ;
      private string[] P006G2_A906LayoutContratoTipo ;
      private bool[] P006G2_n906LayoutContratoTipo ;
      private bool[] P006G2_A156LayoutContratoStatus ;
      private bool[] P006G2_n156LayoutContratoStatus ;
      private string[] P006G2_A155LayoutContratoDescricao ;
      private bool[] P006G2_n155LayoutContratoDescricao ;
      private short[] P006G2_A154LayoutContratoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class layoutcontratowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006G2( IGxContext context ,
                                             string A906LayoutContratoTipo ,
                                             GxSimpleCollection<string> AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                             string AV66Layoutcontratowwds_1_filterfulltext ,
                                             string AV67Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                             short AV68Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV69Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                             bool AV70Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                             string AV71Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                             short AV72Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                             string AV73Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                             bool AV74Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                             string AV75Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                             short AV76Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                             string AV77Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                             string AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                             string AV78Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                             short AV80Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                             int AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ,
                                             string AV83Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                             string AV82Layoutcontratowwds_17_tflayoutcontratotag ,
                                             string A155LayoutContratoDescricao ,
                                             bool A156LayoutContratoStatus ,
                                             string A1000LayoutContratoTag ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[17];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT LayoutContratoTag, LayoutContratoTipo, LayoutContratoStatus, LayoutContratoDescricao, LayoutContratoId FROM LayoutContrato";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LayoutContratoDescricao like '%' || :lV66Layoutcontratowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV66Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = TRUE) or ( 'não' like '%' || LOWER(:lV66Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = FALSE) or ( 'contrato' like '%' || LOWER(:lV66Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'C')) or ( 'mensagem' like '%' || LOWER(:lV66Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'M')) or ( 'acoplado' like '%' || LOWER(:lV66Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'A')) or ( LayoutContratoTag like '%' || :lV66Layoutcontratowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV68Layoutcontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV69Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV68Layoutcontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV69Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV70Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV72Layoutcontratowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV73Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV70Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV72Layoutcontratowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV73Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV74Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV76Layoutcontratowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV77Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV74Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV76Layoutcontratowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV77Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Layoutcontratowwds_13_tflayoutcontratodescricao)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV78Layoutcontratowwds_13_tflayoutcontratodescricao)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ! ( StringUtil.StrCmp(AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao = ( :AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao IS NULL or (char_length(trim(trailing ' ' from LayoutContratoDescricao))=0))");
         }
         if ( AV80Layoutcontratowwds_15_tflayoutcontratostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = TRUE)");
         }
         if ( AV80Layoutcontratowwds_15_tflayoutcontratostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = FALSE)");
         }
         if ( AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV81Layoutcontratowwds_16_tflayoutcontratotipo_sels, "LayoutContratoTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Layoutcontratowwds_17_tflayoutcontratotag)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag like :lV82Layoutcontratowwds_17_tflayoutcontratotag)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ! ( StringUtil.StrCmp(AV83Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag = ( :AV83Layoutcontratowwds_18_tflayoutcontratotag_sel))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV83Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoTag IS NULL or (char_length(trim(trailing ' ' from LayoutContratoTag))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoDescricao";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoDescricao DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoStatus";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoStatus DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoTipo";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoTipo DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoTag";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoTag DESC";
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
                     return conditional_P006G2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP006G2;
          prmP006G2 = new Object[] {
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV69Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV73Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV73Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV77Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV77Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV78Layoutcontratowwds_13_tflayoutcontratodescricao",GXType.VarChar,60,0) ,
          new ParDef("AV79Layoutcontratowwds_14_tflayoutcontratodescricao_sel",GXType.VarChar,60,0) ,
          new ParDef("lV82Layoutcontratowwds_17_tflayoutcontratotag",GXType.VarChar,40,0) ,
          new ParDef("AV83Layoutcontratowwds_18_tflayoutcontratotag_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
