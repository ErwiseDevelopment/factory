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
   public class tipoclientewwexportreport : GXWebProcedure
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

      public tipoclientewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipoclientewwexportreport( IGxContext context )
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
         setOutputFileName("TipoClienteWWExportReport");
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
            AV51Title = "Lista de Tipo Cliente";
            GXt_char1 = AV56Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV56Companyname = GXt_char1;
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
            H6H0( true, 0) ;
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
            H6H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TipoClienteDescricao1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TipoClienteDescricao1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17TipoClienteDescricao = AV15TipoClienteDescricao1;
                  H6H0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipoClienteDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipoClienteDescricao, "@!")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TipoClienteDescricao2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipoClienteDescricao2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17TipoClienteDescricao = AV21TipoClienteDescricao2;
                     H6H0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipoClienteDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipoClienteDescricao, "@!")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TipoClienteDescricao3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipoClienteDescricao3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTipoClienteDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17TipoClienteDescricao = AV25TipoClienteDescricao3;
                        H6H0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipoClienteDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipoClienteDescricao, "@!")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipoClienteDescricao_Sel)) )
         {
            AV39TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFTipoClienteDescricao_Sel, "<#Empty#>")==0)));
            AV33TFTipoClienteDescricao_Sel = (AV39TempBoolean ? "(Vazio)" : AV33TFTipoClienteDescricao_Sel);
            H6H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTipoClienteDescricao_Sel, "@!")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFTipoClienteDescricao_Sel = (AV39TempBoolean ? "<#Empty#>" : AV33TFTipoClienteDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFTipoClienteDescricao)) )
            {
               H6H0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFTipoClienteDescricao, "@!")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV37TFTipoClienteTipoPessoa_Sels.FromJSonString(AV34TFTipoClienteTipoPessoa_SelsJson, null);
         if ( ! ( AV37TFTipoClienteTipoPessoa_Sels.Count == 0 ) )
         {
            AV40i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV37TFTipoClienteTipoPessoa_Sels.Count )
            {
               AV36TFTipoClienteTipoPessoa_Sel = ((string)AV37TFTipoClienteTipoPessoa_Sels.Item(AV59GXV1));
               if ( AV40i == 1 )
               {
                  AV35TFTipoClienteTipoPessoa_SelDscs = "";
               }
               else
               {
                  AV35TFTipoClienteTipoPessoa_SelDscs += ", ";
               }
               AV38FilterTFTipoClienteTipoPessoa_SelValueDescription = gxdomaindmtipopessoa.getDescription(context,AV36TFTipoClienteTipoPessoa_Sel);
               AV35TFTipoClienteTipoPessoa_SelDscs += AV38FilterTFTipoClienteTipoPessoa_SelValueDescription;
               AV40i = (long)(AV40i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
            H6H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo Pessoa", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTipoClienteTipoPessoa_SelDscs, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV54TFTipoClientePortal_Sel) )
         {
            if ( AV54TFTipoClientePortal_Sel == 1 )
            {
               AV55FilterTFTipoClientePortal_SelValueDescription = "Marcado";
            }
            else if ( AV54TFTipoClientePortal_Sel == 2 )
            {
               AV55FilterTFTipoClientePortal_SelValueDescription = "Desmarcado";
            }
            H6H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Acesso ao portal clinica", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FilterTFTipoClientePortal_SelValueDescription, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6H0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6H0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Descrição", 30, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo Pessoa", 283, Gx_line+10, 533, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Acesso ao portal clinica", 537, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV61Tipoclientewwds_1_filterfulltext = AV12FilterFullText;
         AV62Tipoclientewwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV63Tipoclientewwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV64Tipoclientewwds_4_tipoclientedescricao1 = AV15TipoClienteDescricao1;
         AV65Tipoclientewwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Tipoclientewwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Tipoclientewwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV68Tipoclientewwds_8_tipoclientedescricao2 = AV21TipoClienteDescricao2;
         AV69Tipoclientewwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Tipoclientewwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Tipoclientewwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Tipoclientewwds_12_tipoclientedescricao3 = AV25TipoClienteDescricao3;
         AV73Tipoclientewwds_13_tftipoclientedescricao = AV32TFTipoClienteDescricao;
         AV74Tipoclientewwds_14_tftipoclientedescricao_sel = AV33TFTipoClienteDescricao_Sel;
         AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV37TFTipoClienteTipoPessoa_Sels;
         AV76Tipoclientewwds_16_tftipoclienteportal_sel = AV54TFTipoClientePortal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A194TipoClienteTipoPessoa ,
                                              AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                              AV61Tipoclientewwds_1_filterfulltext ,
                                              AV62Tipoclientewwds_2_dynamicfiltersselector1 ,
                                              AV63Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                              AV64Tipoclientewwds_4_tipoclientedescricao1 ,
                                              AV65Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                              AV66Tipoclientewwds_6_dynamicfiltersselector2 ,
                                              AV67Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                              AV68Tipoclientewwds_8_tipoclientedescricao2 ,
                                              AV69Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                              AV70Tipoclientewwds_10_dynamicfiltersselector3 ,
                                              AV71Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                              AV72Tipoclientewwds_12_tipoclientedescricao3 ,
                                              AV74Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                              AV73Tipoclientewwds_13_tftipoclientedescricao ,
                                              AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels.Count ,
                                              AV76Tipoclientewwds_16_tftipoclienteportal_sel ,
                                              A193TipoClienteDescricao ,
                                              A207TipoClientePortal ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tipoclientewwds_1_filterfulltext), "%", "");
         lV61Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tipoclientewwds_1_filterfulltext), "%", "");
         lV61Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tipoclientewwds_1_filterfulltext), "%", "");
         lV61Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tipoclientewwds_1_filterfulltext), "%", "");
         lV61Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Tipoclientewwds_1_filterfulltext), "%", "");
         lV64Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV64Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV64Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV64Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV68Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV68Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV72Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV72Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV72Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV72Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV73Tipoclientewwds_13_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV73Tipoclientewwds_13_tftipoclientedescricao), "%", "");
         /* Using cursor P006H2 */
         pr_default.execute(0, new Object[] {lV61Tipoclientewwds_1_filterfulltext, lV61Tipoclientewwds_1_filterfulltext, lV61Tipoclientewwds_1_filterfulltext, lV61Tipoclientewwds_1_filterfulltext, lV61Tipoclientewwds_1_filterfulltext, lV64Tipoclientewwds_4_tipoclientedescricao1, lV64Tipoclientewwds_4_tipoclientedescricao1, lV68Tipoclientewwds_8_tipoclientedescricao2, lV68Tipoclientewwds_8_tipoclientedescricao2, lV72Tipoclientewwds_12_tipoclientedescricao3, lV72Tipoclientewwds_12_tipoclientedescricao3, lV73Tipoclientewwds_13_tftipoclientedescricao, AV74Tipoclientewwds_14_tftipoclientedescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A207TipoClientePortal = P006H2_A207TipoClientePortal[0];
            n207TipoClientePortal = P006H2_n207TipoClientePortal[0];
            A194TipoClienteTipoPessoa = P006H2_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = P006H2_n194TipoClienteTipoPessoa[0];
            A193TipoClienteDescricao = P006H2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P006H2_n193TipoClienteDescricao[0];
            A192TipoClienteId = P006H2_A192TipoClienteId[0];
            AV27TipoClienteTipoPessoaDescription = gxdomaindmtipopessoa.getDescription(context,A194TipoClienteTipoPessoa);
            AV53TipoClientePortalDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A207TipoClientePortal)), "true") == 0 )
            {
               AV53TipoClientePortalDescription = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A207TipoClientePortal)), "false") == 0 )
            {
               AV53TipoClientePortalDescription = "Não";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6H0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")), 30, Gx_line+10, 279, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TipoClienteTipoPessoaDescription, "")), 283, Gx_line+10, 533, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TipoClientePortalDescription, "")), 537, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("TipoClienteWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoClienteWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("TipoClienteWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV77GXV2 = 1;
         while ( AV77GXV2 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV77GXV2));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV32TFTipoClienteDescricao = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV33TFTipoClienteDescricao_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV34TFTipoClienteTipoPessoa_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV37TFTipoClienteTipoPessoa_Sels.FromJSonString(AV34TFTipoClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEPORTAL_SEL") == 0 )
            {
               AV54TFTipoClientePortal_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV77GXV2 = (int)(AV77GXV2+1);
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

      protected void H6H0( bool bFoot ,
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
         AV51Title = "";
         AV56Companyname = "";
         AV50Phone = "";
         AV48Mail = "";
         AV52Website = "";
         AV41AddressLine1 = "";
         AV42AddressLine2 = "";
         AV43AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15TipoClienteDescricao1 = "";
         AV16FilterTipoClienteDescricaoDescription = "";
         AV17TipoClienteDescricao = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipoClienteDescricao2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipoClienteDescricao3 = "";
         AV33TFTipoClienteDescricao_Sel = "";
         AV32TFTipoClienteDescricao = "";
         AV37TFTipoClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV34TFTipoClienteTipoPessoa_SelsJson = "";
         AV36TFTipoClienteTipoPessoa_Sel = "";
         AV35TFTipoClienteTipoPessoa_SelDscs = "";
         AV38FilterTFTipoClienteTipoPessoa_SelValueDescription = "";
         AV55FilterTFTipoClientePortal_SelValueDescription = "";
         AV61Tipoclientewwds_1_filterfulltext = "";
         AV62Tipoclientewwds_2_dynamicfiltersselector1 = "";
         AV64Tipoclientewwds_4_tipoclientedescricao1 = "";
         AV66Tipoclientewwds_6_dynamicfiltersselector2 = "";
         AV68Tipoclientewwds_8_tipoclientedescricao2 = "";
         AV70Tipoclientewwds_10_dynamicfiltersselector3 = "";
         AV72Tipoclientewwds_12_tipoclientedescricao3 = "";
         AV73Tipoclientewwds_13_tftipoclientedescricao = "";
         AV74Tipoclientewwds_14_tftipoclientedescricao_sel = "";
         AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV61Tipoclientewwds_1_filterfulltext = "";
         lV64Tipoclientewwds_4_tipoclientedescricao1 = "";
         lV68Tipoclientewwds_8_tipoclientedescricao2 = "";
         lV72Tipoclientewwds_12_tipoclientedescricao3 = "";
         lV73Tipoclientewwds_13_tftipoclientedescricao = "";
         A194TipoClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         P006H2_A207TipoClientePortal = new bool[] {false} ;
         P006H2_n207TipoClientePortal = new bool[] {false} ;
         P006H2_A194TipoClienteTipoPessoa = new string[] {""} ;
         P006H2_n194TipoClienteTipoPessoa = new bool[] {false} ;
         P006H2_A193TipoClienteDescricao = new string[] {""} ;
         P006H2_n193TipoClienteDescricao = new bool[] {false} ;
         P006H2_A192TipoClienteId = new short[1] ;
         AV27TipoClienteTipoPessoaDescription = "";
         AV53TipoClientePortalDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49PageInfo = "";
         AV46DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV44AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoclientewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006H2_A207TipoClientePortal, P006H2_n207TipoClientePortal, P006H2_A194TipoClienteTipoPessoa, P006H2_n194TipoClienteTipoPessoa, P006H2_A193TipoClienteDescricao, P006H2_n193TipoClienteDescricao, P006H2_A192TipoClienteId
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
      private short AV54TFTipoClientePortal_Sel ;
      private short AV63Tipoclientewwds_3_dynamicfiltersoperator1 ;
      private short AV67Tipoclientewwds_7_dynamicfiltersoperator2 ;
      private short AV71Tipoclientewwds_11_dynamicfiltersoperator3 ;
      private short AV76Tipoclientewwds_16_tftipoclienteportal_sel ;
      private short AV10OrderedBy ;
      private short A192TipoClienteId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV59GXV1 ;
      private int AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ;
      private int AV77GXV2 ;
      private long AV40i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV39TempBoolean ;
      private bool AV65Tipoclientewwds_5_dynamicfiltersenabled2 ;
      private bool AV69Tipoclientewwds_9_dynamicfiltersenabled3 ;
      private bool A207TipoClientePortal ;
      private bool AV11OrderedDsc ;
      private bool n207TipoClientePortal ;
      private bool n194TipoClienteTipoPessoa ;
      private bool n193TipoClienteDescricao ;
      private string AV56Companyname ;
      private string AV34TFTipoClienteTipoPessoa_SelsJson ;
      private string AV51Title ;
      private string AV50Phone ;
      private string AV48Mail ;
      private string AV52Website ;
      private string AV41AddressLine1 ;
      private string AV42AddressLine2 ;
      private string AV43AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15TipoClienteDescricao1 ;
      private string AV16FilterTipoClienteDescricaoDescription ;
      private string AV17TipoClienteDescricao ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21TipoClienteDescricao2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25TipoClienteDescricao3 ;
      private string AV33TFTipoClienteDescricao_Sel ;
      private string AV32TFTipoClienteDescricao ;
      private string AV36TFTipoClienteTipoPessoa_Sel ;
      private string AV35TFTipoClienteTipoPessoa_SelDscs ;
      private string AV38FilterTFTipoClienteTipoPessoa_SelValueDescription ;
      private string AV55FilterTFTipoClientePortal_SelValueDescription ;
      private string AV61Tipoclientewwds_1_filterfulltext ;
      private string AV62Tipoclientewwds_2_dynamicfiltersselector1 ;
      private string AV64Tipoclientewwds_4_tipoclientedescricao1 ;
      private string AV66Tipoclientewwds_6_dynamicfiltersselector2 ;
      private string AV68Tipoclientewwds_8_tipoclientedescricao2 ;
      private string AV70Tipoclientewwds_10_dynamicfiltersselector3 ;
      private string AV72Tipoclientewwds_12_tipoclientedescricao3 ;
      private string AV73Tipoclientewwds_13_tftipoclientedescricao ;
      private string AV74Tipoclientewwds_14_tftipoclientedescricao_sel ;
      private string lV61Tipoclientewwds_1_filterfulltext ;
      private string lV64Tipoclientewwds_4_tipoclientedescricao1 ;
      private string lV68Tipoclientewwds_8_tipoclientedescricao2 ;
      private string lV72Tipoclientewwds_12_tipoclientedescricao3 ;
      private string lV73Tipoclientewwds_13_tftipoclientedescricao ;
      private string A194TipoClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string AV27TipoClienteTipoPessoaDescription ;
      private string AV53TipoClientePortalDescription ;
      private string AV49PageInfo ;
      private string AV46DateInfo ;
      private string AV44AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV37TFTipoClienteTipoPessoa_Sels ;
      private GxSimpleCollection<string> AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] P006H2_A207TipoClientePortal ;
      private bool[] P006H2_n207TipoClientePortal ;
      private string[] P006H2_A194TipoClienteTipoPessoa ;
      private bool[] P006H2_n194TipoClienteTipoPessoa ;
      private string[] P006H2_A193TipoClienteDescricao ;
      private bool[] P006H2_n193TipoClienteDescricao ;
      private short[] P006H2_A192TipoClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class tipoclientewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006H2( IGxContext context ,
                                             string A194TipoClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                             string AV61Tipoclientewwds_1_filterfulltext ,
                                             string AV62Tipoclientewwds_2_dynamicfiltersselector1 ,
                                             short AV63Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV64Tipoclientewwds_4_tipoclientedescricao1 ,
                                             bool AV65Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                             string AV66Tipoclientewwds_6_dynamicfiltersselector2 ,
                                             short AV67Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                             string AV68Tipoclientewwds_8_tipoclientedescricao2 ,
                                             bool AV69Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                             string AV70Tipoclientewwds_10_dynamicfiltersselector3 ,
                                             short AV71Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                             string AV72Tipoclientewwds_12_tipoclientedescricao3 ,
                                             string AV74Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                             string AV73Tipoclientewwds_13_tftipoclientedescricao ,
                                             int AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ,
                                             short AV76Tipoclientewwds_16_tftipoclienteportal_sel ,
                                             string A193TipoClienteDescricao ,
                                             bool A207TipoClientePortal ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT TipoClientePortal, TipoClienteTipoPessoa, TipoClienteDescricao, TipoClienteId FROM TipoCliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tipoclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TipoClienteDescricao like '%' || :lV61Tipoclientewwds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV61Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV61Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'JURIDICA')) or ( 'sim' like '%' || LOWER(:lV61Tipoclientewwds_1_filterfulltext) and TipoClientePortal = TRUE) or ( 'não' like '%' || LOWER(:lV61Tipoclientewwds_1_filterfulltext) and TipoClientePortal = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV63Tipoclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV64Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV63Tipoclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV64Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV65Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV67Tipoclientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV68Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV65Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV67Tipoclientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV68Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV69Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV71Tipoclientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV72Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV69Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV71Tipoclientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV72Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Tipoclientewwds_14_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Tipoclientewwds_13_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV73Tipoclientewwds_13_tftipoclientedescricao)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Tipoclientewwds_14_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV74Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao = ( :AV74Tipoclientewwds_14_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV74Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from TipoClienteDescricao))=0))");
         }
         if ( AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV75Tipoclientewwds_15_tftipoclientetipopessoa_sels, "TipoClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV76Tipoclientewwds_16_tftipoclienteportal_sel == 1 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = TRUE)");
         }
         if ( AV76Tipoclientewwds_16_tftipoclienteportal_sel == 2 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoClienteDescricao";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoClienteDescricao DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoClienteTipoPessoa";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoClienteTipoPessoa DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoClientePortal";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoClientePortal DESC";
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
                     return conditional_P006H2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP006H2;
          prmP006H2 = new Object[] {
          new ParDef("lV61Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV64Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV68Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV72Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV72Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV73Tipoclientewwds_13_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV74Tipoclientewwds_14_tftipoclientedescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
