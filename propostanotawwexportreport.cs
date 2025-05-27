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
   public class propostanotawwexportreport : GXWebProcedure
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

      public propostanotawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostanotawwexportreport( IGxContext context )
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
         setOutputFileName("PropostaNotaWWExportReport");
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
            AV68Title = "Lista de Proposta Nota";
            GXt_char1 = AV70Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV70Companyname = GXt_char1;
            GXt_char1 = AV67Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV67Phone = GXt_char1;
            GXt_char1 = AV65Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV65Mail = GXt_char1;
            GXt_char1 = AV69Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV69Website = GXt_char1;
            GXt_char1 = AV58AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV58AddressLine1 = GXt_char1;
            GXt_char1 = AV59AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV59AddressLine2 = GXt_char1;
            GXt_char1 = AV60AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV60AddressLine3 = GXt_char1;
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
            HE70( true, 0) ;
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
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "PROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15PropostaQtdItensNota_F1 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV15PropostaQtdItensNota_F1) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 2 )
                  {
                     AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", ">", "", "", "", "", "", "", "");
                  }
                  AV17PropostaQtdItensNota_F = AV15PropostaQtdItensNota_F1;
                  HE70( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPropostaQtdItensNota_FDescription, "")), 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17PropostaQtdItensNota_F), "ZZZ9")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "PROPOSTAQTDITENSNOTA_F") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21PropostaQtdItensNota_F2 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV21PropostaQtdItensNota_F2) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 2 )
                     {
                        AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", ">", "", "", "", "", "", "", "");
                     }
                     AV17PropostaQtdItensNota_F = AV21PropostaQtdItensNota_F2;
                     HE70( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPropostaQtdItensNota_FDescription, "")), 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17PropostaQtdItensNota_F), "ZZZ9")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "PROPOSTAQTDITENSNOTA_F") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25PropostaQtdItensNota_F3 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV25PropostaQtdItensNota_F3) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 2 )
                        {
                           AV16FilterPropostaQtdItensNota_FDescription = StringUtil.Format( "%1 (%2)", "Itens Nota_F", ">", "", "", "", "", "", "", "");
                        }
                        AV17PropostaQtdItensNota_F = AV25PropostaQtdItensNota_F3;
                        HE70( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPropostaQtdItensNota_FDescription, "")), 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17PropostaQtdItensNota_F), "ZZZ9")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPropostaProtocolo_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFPropostaProtocolo_Sel, "<#Empty#>")==0)));
            AV34TFPropostaProtocolo_Sel = (AV56TempBoolean ? "(Vazio)" : AV34TFPropostaProtocolo_Sel);
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Protocolo", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFPropostaProtocolo_Sel, "")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFPropostaProtocolo_Sel = (AV56TempBoolean ? "<#Empty#>" : AV34TFPropostaProtocolo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPropostaProtocolo)) )
            {
               HE70( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Protocolo", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFPropostaProtocolo, "")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaEmpresaRazao_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFPropostaEmpresaRazao_Sel, "<#Empty#>")==0)));
            AV36TFPropostaEmpresaRazao_Sel = (AV56TempBoolean ? "(Vazio)" : AV36TFPropostaEmpresaRazao_Sel);
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cliente", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFPropostaEmpresaRazao_Sel, "@!")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFPropostaEmpresaRazao_Sel = (AV56TempBoolean ? "<#Empty#>" : AV36TFPropostaEmpresaRazao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaEmpresaRazao)) )
            {
               HE70( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFPropostaEmpresaRazao, "@!")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV37TFPropostaQtdItensNota_F) && (0==AV38TFPropostaQtdItensNota_F_To) ) )
         {
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Quantidade", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFPropostaQtdItensNota_F), "ZZZ9")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFPropostaQtdItensNota_F_To_Description = StringUtil.Format( "%1 (%2)", "Quantidade", "Até", "", "", "", "", "", "", "");
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFPropostaQtdItensNota_F_To_Description, "")), 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFPropostaQtdItensNota_F_To), "ZZZ9")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV42TFPropostaTipoProposta_Sels.FromJSonString(AV39TFPropostaTipoProposta_SelsJson, null);
         if ( ! ( AV42TFPropostaTipoProposta_Sels.Count == 0 ) )
         {
            AV57i = 1;
            AV73GXV1 = 1;
            while ( AV73GXV1 <= AV42TFPropostaTipoProposta_Sels.Count )
            {
               AV41TFPropostaTipoProposta_Sel = ((string)AV42TFPropostaTipoProposta_Sels.Item(AV73GXV1));
               if ( AV57i == 1 )
               {
                  AV40TFPropostaTipoProposta_SelDscs = "";
               }
               else
               {
                  AV40TFPropostaTipoProposta_SelDscs += ", ";
               }
               AV52FilterTFPropostaTipoProposta_SelValueDescription = gxdomaindmtipoproposta.getDescription(context,AV41TFPropostaTipoProposta_Sel);
               AV40TFPropostaTipoProposta_SelDscs += AV52FilterTFPropostaTipoProposta_SelValueDescription;
               AV57i = (long)(AV57i+1);
               AV73GXV1 = (int)(AV73GXV1+1);
            }
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo Proposta", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFPropostaTipoProposta_SelDscs, "")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV43TFPropostaSumItensnota_F) && (Convert.ToDecimal(0)==AV44TFPropostaSumItensnota_F_To) ) )
         {
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TFPropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV53TFPropostaSumItensnota_F_To_Description = StringUtil.Format( "%1 (%2)", "Total", "Até", "", "", "", "", "", "", "");
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFPropostaSumItensnota_F_To_Description, "")), 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TFPropostaSumItensnota_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV45TFPropostaCreatedAt) && (DateTime.MinValue==AV46TFPropostaCreatedAt_To) ) )
         {
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data Criação", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV45TFPropostaCreatedAt, "99/99/99 99:99"), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV54TFPropostaCreatedAt_To_Description = StringUtil.Format( "%1 (%2)", "Data Criação", "Até", "", "", "", "", "", "", "");
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFPropostaCreatedAt_To_Description, "")), 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV46TFPropostaCreatedAt_To, "99/99/99 99:99"), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV50TFPropostaStatus_Sels.FromJSonString(AV47TFPropostaStatus_SelsJson, null);
         if ( ! ( AV50TFPropostaStatus_Sels.Count == 0 ) )
         {
            AV57i = 1;
            AV74GXV2 = 1;
            while ( AV74GXV2 <= AV50TFPropostaStatus_Sels.Count )
            {
               AV49TFPropostaStatus_Sel = ((string)AV50TFPropostaStatus_Sels.Item(AV74GXV2));
               if ( AV57i == 1 )
               {
                  AV48TFPropostaStatus_SelDscs = "";
               }
               else
               {
                  AV48TFPropostaStatus_SelDscs += ", ";
               }
               AV55FilterTFPropostaStatus_SelValueDescription = gxdomaindmstatusproposta.getDescription(context,AV49TFPropostaStatus_Sel);
               AV48TFPropostaStatus_SelDscs += AV55FilterTFPropostaStatus_SelValueDescription;
               AV57i = (long)(AV57i+1);
               AV74GXV2 = (int)(AV74GXV2+1);
            }
            HE70( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 145, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFPropostaStatus_SelDscs, "")), 145, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HE70( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HE70( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Protocolo", 30, Gx_line+10, 162, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cliente", 166, Gx_line+10, 298, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Quantidade", 302, Gx_line+10, 369, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo Proposta", 373, Gx_line+10, 507, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Total", 511, Gx_line+10, 578, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Data Criação", 582, Gx_line+10, 649, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 653, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV76Propostanotawwds_1_filterfulltext = AV12FilterFullText;
         AV77Propostanotawwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV78Propostanotawwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV79Propostanotawwds_4_propostaqtditensnota_f1 = AV15PropostaQtdItensNota_F1;
         AV80Propostanotawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV81Propostanotawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV82Propostanotawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV83Propostanotawwds_8_propostaqtditensnota_f2 = AV21PropostaQtdItensNota_F2;
         AV84Propostanotawwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV85Propostanotawwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV86Propostanotawwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV87Propostanotawwds_12_propostaqtditensnota_f3 = AV25PropostaQtdItensNota_F3;
         AV88Propostanotawwds_13_tfpropostaprotocolo = AV33TFPropostaProtocolo;
         AV89Propostanotawwds_14_tfpropostaprotocolo_sel = AV34TFPropostaProtocolo_Sel;
         AV90Propostanotawwds_15_tfpropostaempresarazao = AV35TFPropostaEmpresaRazao;
         AV91Propostanotawwds_16_tfpropostaempresarazao_sel = AV36TFPropostaEmpresaRazao_Sel;
         AV92Propostanotawwds_17_tfpropostaqtditensnota_f = AV37TFPropostaQtdItensNota_F;
         AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV38TFPropostaQtdItensNota_F_To;
         AV94Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV95Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV96Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV97Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV98Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV99Propostanotawwds_24_tfpropostastatus_sels = AV50TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A849PropostaTipoProposta ,
                                              AV94Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                              A329PropostaStatus ,
                                              AV99Propostanotawwds_24_tfpropostastatus_sels ,
                                              AV89Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                              AV88Propostanotawwds_13_tfpropostaprotocolo ,
                                              AV91Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                              AV90Propostanotawwds_15_tfpropostaempresarazao ,
                                              AV94Propostanotawwds_19_tfpropostatipoproposta_sels.Count ,
                                              AV95Propostanotawwds_20_tfpropostasumitensnota_f ,
                                              AV96Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                              AV97Propostanotawwds_22_tfpropostacreatedat ,
                                              AV98Propostanotawwds_23_tfpropostacreatedat_to ,
                                              AV99Propostanotawwds_24_tfpropostastatus_sels.Count ,
                                              A853PropostaProtocolo ,
                                              A888PropostaEmpresaRazao ,
                                              A887PropostaSumItensnota_F ,
                                              A327PropostaCreatedAt ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc ,
                                              AV76Propostanotawwds_1_filterfulltext ,
                                              A854PropostaQtdItensNota_F ,
                                              AV77Propostanotawwds_2_dynamicfiltersselector1 ,
                                              AV78Propostanotawwds_3_dynamicfiltersoperator1 ,
                                              AV79Propostanotawwds_4_propostaqtditensnota_f1 ,
                                              AV80Propostanotawwds_5_dynamicfiltersenabled2 ,
                                              AV81Propostanotawwds_6_dynamicfiltersselector2 ,
                                              AV82Propostanotawwds_7_dynamicfiltersoperator2 ,
                                              AV83Propostanotawwds_8_propostaqtditensnota_f2 ,
                                              AV84Propostanotawwds_9_dynamicfiltersenabled3 ,
                                              AV85Propostanotawwds_10_dynamicfiltersselector3 ,
                                              AV86Propostanotawwds_11_dynamicfiltersoperator3 ,
                                              AV87Propostanotawwds_12_propostaqtditensnota_f3 ,
                                              AV92Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                              AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV76Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV76Propostanotawwds_1_filterfulltext), "%", "");
         lV88Propostanotawwds_13_tfpropostaprotocolo = StringUtil.Concat( StringUtil.RTrim( AV88Propostanotawwds_13_tfpropostaprotocolo), "%", "");
         lV90Propostanotawwds_15_tfpropostaempresarazao = StringUtil.Concat( StringUtil.RTrim( AV90Propostanotawwds_15_tfpropostaempresarazao), "%", "");
         /* Using cursor P00E73 */
         pr_default.execute(0, new Object[] {AV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, lV76Propostanotawwds_1_filterfulltext, AV77Propostanotawwds_2_dynamicfiltersselector1, AV78Propostanotawwds_3_dynamicfiltersoperator1, AV79Propostanotawwds_4_propostaqtditensnota_f1, AV79Propostanotawwds_4_propostaqtditensnota_f1, AV77Propostanotawwds_2_dynamicfiltersselector1, AV78Propostanotawwds_3_dynamicfiltersoperator1, AV79Propostanotawwds_4_propostaqtditensnota_f1, AV79Propostanotawwds_4_propostaqtditensnota_f1, AV77Propostanotawwds_2_dynamicfiltersselector1, AV78Propostanotawwds_3_dynamicfiltersoperator1, AV79Propostanotawwds_4_propostaqtditensnota_f1, AV79Propostanotawwds_4_propostaqtditensnota_f1, AV80Propostanotawwds_5_dynamicfiltersenabled2, AV81Propostanotawwds_6_dynamicfiltersselector2, AV82Propostanotawwds_7_dynamicfiltersoperator2, AV83Propostanotawwds_8_propostaqtditensnota_f2, AV83Propostanotawwds_8_propostaqtditensnota_f2, AV80Propostanotawwds_5_dynamicfiltersenabled2, AV81Propostanotawwds_6_dynamicfiltersselector2, AV82Propostanotawwds_7_dynamicfiltersoperator2, AV83Propostanotawwds_8_propostaqtditensnota_f2, AV83Propostanotawwds_8_propostaqtditensnota_f2, AV80Propostanotawwds_5_dynamicfiltersenabled2, AV81Propostanotawwds_6_dynamicfiltersselector2, AV82Propostanotawwds_7_dynamicfiltersoperator2, AV83Propostanotawwds_8_propostaqtditensnota_f2, AV83Propostanotawwds_8_propostaqtditensnota_f2, AV84Propostanotawwds_9_dynamicfiltersenabled3, AV85Propostanotawwds_10_dynamicfiltersselector3, AV86Propostanotawwds_11_dynamicfiltersoperator3, AV87Propostanotawwds_12_propostaqtditensnota_f3, AV87Propostanotawwds_12_propostaqtditensnota_f3, AV84Propostanotawwds_9_dynamicfiltersenabled3, AV85Propostanotawwds_10_dynamicfiltersselector3, AV86Propostanotawwds_11_dynamicfiltersoperator3, AV87Propostanotawwds_12_propostaqtditensnota_f3, AV87Propostanotawwds_12_propostaqtditensnota_f3, AV84Propostanotawwds_9_dynamicfiltersenabled3, AV85Propostanotawwds_10_dynamicfiltersselector3, AV86Propostanotawwds_11_dynamicfiltersoperator3, AV87Propostanotawwds_12_propostaqtditensnota_f3, AV87Propostanotawwds_12_propostaqtditensnota_f3, AV92Propostanotawwds_17_tfpropostaqtditensnota_f, AV92Propostanotawwds_17_tfpropostaqtditensnota_f, AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to, AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to, lV88Propostanotawwds_13_tfpropostaprotocolo, AV89Propostanotawwds_14_tfpropostaprotocolo_sel, lV90Propostanotawwds_15_tfpropostaempresarazao, AV91Propostanotawwds_16_tfpropostaempresarazao_sel, AV95Propostanotawwds_20_tfpropostasumitensnota_f, AV96Propostanotawwds_21_tfpropostasumitensnota_f_to, AV97Propostanotawwds_22_tfpropostacreatedat, AV98Propostanotawwds_23_tfpropostacreatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A850PropostaEmpresaClienteId = P00E73_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = P00E73_n850PropostaEmpresaClienteId[0];
            A323PropostaId = P00E73_A323PropostaId[0];
            n323PropostaId = P00E73_n323PropostaId[0];
            A327PropostaCreatedAt = P00E73_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = P00E73_n327PropostaCreatedAt[0];
            A329PropostaStatus = P00E73_A329PropostaStatus[0];
            n329PropostaStatus = P00E73_n329PropostaStatus[0];
            A849PropostaTipoProposta = P00E73_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = P00E73_n849PropostaTipoProposta[0];
            A888PropostaEmpresaRazao = P00E73_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E73_n888PropostaEmpresaRazao[0];
            A853PropostaProtocolo = P00E73_A853PropostaProtocolo[0];
            n853PropostaProtocolo = P00E73_n853PropostaProtocolo[0];
            A887PropostaSumItensnota_F = P00E73_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E73_A854PropostaQtdItensNota_F[0];
            A888PropostaEmpresaRazao = P00E73_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E73_n888PropostaEmpresaRazao[0];
            A887PropostaSumItensnota_F = P00E73_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E73_A854PropostaQtdItensNota_F[0];
            AV27PropostaTipoPropostaDescription = gxdomaindmtipoproposta.getDescription(context,A849PropostaTipoProposta);
            AV28PropostaStatusDescription = gxdomaindmstatusproposta.getDescription(context,A329PropostaStatus);
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HE70( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A853PropostaProtocolo, "")), 30, Gx_line+10, 162, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A888PropostaEmpresaRazao, "@!")), 166, Gx_line+10, 298, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A854PropostaQtdItensNota_F), "ZZZ9")), 302, Gx_line+10, 369, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27PropostaTipoPropostaDescription, "")), 373, Gx_line+10, 507, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A887PropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")), 511, Gx_line+10, 578, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"), 582, Gx_line+10, 649, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28PropostaStatusDescription, "")), 653, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("PropostaNotaWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaNotaWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("PropostaNotaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV100GXV3 = 1;
         while ( AV100GXV3 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV100GXV3));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO") == 0 )
            {
               AV33TFPropostaProtocolo = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO_SEL") == 0 )
            {
               AV34TFPropostaProtocolo_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO") == 0 )
            {
               AV35TFPropostaEmpresaRazao = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO_SEL") == 0 )
            {
               AV36TFPropostaEmpresaRazao_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV37TFPropostaQtdItensNota_F = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFPropostaQtdItensNota_F_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTATIPOPROPOSTA_SEL") == 0 )
            {
               AV39TFPropostaTipoProposta_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV42TFPropostaTipoProposta_Sels.FromJSonString(AV39TFPropostaTipoProposta_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTASUMITENSNOTA_F") == 0 )
            {
               AV43TFPropostaSumItensnota_F = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV44TFPropostaSumItensnota_F_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTACREATEDAT") == 0 )
            {
               AV45TFPropostaCreatedAt = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV46TFPropostaCreatedAt_To = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV47TFPropostaStatus_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV50TFPropostaStatus_Sels.FromJSonString(AV47TFPropostaStatus_SelsJson, null);
            }
            AV100GXV3 = (int)(AV100GXV3+1);
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

      protected void HE70( bool bFoot ,
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
                  AV66PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV63DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV68Title = "";
         AV70Companyname = "";
         AV67Phone = "";
         AV65Mail = "";
         AV69Website = "";
         AV58AddressLine1 = "";
         AV59AddressLine2 = "";
         AV60AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV16FilterPropostaQtdItensNota_FDescription = "";
         AV19DynamicFiltersSelector2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV34TFPropostaProtocolo_Sel = "";
         AV33TFPropostaProtocolo = "";
         AV36TFPropostaEmpresaRazao_Sel = "";
         AV35TFPropostaEmpresaRazao = "";
         AV51TFPropostaQtdItensNota_F_To_Description = "";
         AV42TFPropostaTipoProposta_Sels = new GxSimpleCollection<string>();
         AV39TFPropostaTipoProposta_SelsJson = "";
         AV41TFPropostaTipoProposta_Sel = "";
         AV40TFPropostaTipoProposta_SelDscs = "";
         AV52FilterTFPropostaTipoProposta_SelValueDescription = "";
         AV53TFPropostaSumItensnota_F_To_Description = "";
         AV45TFPropostaCreatedAt = (DateTime)(DateTime.MinValue);
         AV46TFPropostaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV54TFPropostaCreatedAt_To_Description = "";
         AV50TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV47TFPropostaStatus_SelsJson = "";
         AV49TFPropostaStatus_Sel = "";
         AV48TFPropostaStatus_SelDscs = "";
         AV55FilterTFPropostaStatus_SelValueDescription = "";
         AV76Propostanotawwds_1_filterfulltext = "";
         AV77Propostanotawwds_2_dynamicfiltersselector1 = "";
         AV81Propostanotawwds_6_dynamicfiltersselector2 = "";
         AV85Propostanotawwds_10_dynamicfiltersselector3 = "";
         AV88Propostanotawwds_13_tfpropostaprotocolo = "";
         AV89Propostanotawwds_14_tfpropostaprotocolo_sel = "";
         AV90Propostanotawwds_15_tfpropostaempresarazao = "";
         AV91Propostanotawwds_16_tfpropostaempresarazao_sel = "";
         AV94Propostanotawwds_19_tfpropostatipoproposta_sels = new GxSimpleCollection<string>();
         AV97Propostanotawwds_22_tfpropostacreatedat = (DateTime)(DateTime.MinValue);
         AV98Propostanotawwds_23_tfpropostacreatedat_to = (DateTime)(DateTime.MinValue);
         AV99Propostanotawwds_24_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV76Propostanotawwds_1_filterfulltext = "";
         lV88Propostanotawwds_13_tfpropostaprotocolo = "";
         lV90Propostanotawwds_15_tfpropostaempresarazao = "";
         A849PropostaTipoProposta = "";
         A329PropostaStatus = "";
         A853PropostaProtocolo = "";
         A888PropostaEmpresaRazao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         P00E73_A850PropostaEmpresaClienteId = new int[1] ;
         P00E73_n850PropostaEmpresaClienteId = new bool[] {false} ;
         P00E73_A323PropostaId = new int[1] ;
         P00E73_n323PropostaId = new bool[] {false} ;
         P00E73_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E73_n327PropostaCreatedAt = new bool[] {false} ;
         P00E73_A329PropostaStatus = new string[] {""} ;
         P00E73_n329PropostaStatus = new bool[] {false} ;
         P00E73_A849PropostaTipoProposta = new string[] {""} ;
         P00E73_n849PropostaTipoProposta = new bool[] {false} ;
         P00E73_A888PropostaEmpresaRazao = new string[] {""} ;
         P00E73_n888PropostaEmpresaRazao = new bool[] {false} ;
         P00E73_A853PropostaProtocolo = new string[] {""} ;
         P00E73_n853PropostaProtocolo = new bool[] {false} ;
         P00E73_A887PropostaSumItensnota_F = new decimal[1] ;
         P00E73_A854PropostaQtdItensNota_F = new short[1] ;
         AV27PropostaTipoPropostaDescription = "";
         AV28PropostaStatusDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV66PageInfo = "";
         AV63DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV61AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostanotawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00E73_A850PropostaEmpresaClienteId, P00E73_n850PropostaEmpresaClienteId, P00E73_A323PropostaId, P00E73_A327PropostaCreatedAt, P00E73_n327PropostaCreatedAt, P00E73_A329PropostaStatus, P00E73_n329PropostaStatus, P00E73_A849PropostaTipoProposta, P00E73_n849PropostaTipoProposta, P00E73_A888PropostaEmpresaRazao,
               P00E73_n888PropostaEmpresaRazao, P00E73_A853PropostaProtocolo, P00E73_n853PropostaProtocolo, P00E73_A887PropostaSumItensnota_F, P00E73_A854PropostaQtdItensNota_F
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
      private short AV15PropostaQtdItensNota_F1 ;
      private short AV17PropostaQtdItensNota_F ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV21PropostaQtdItensNota_F2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV25PropostaQtdItensNota_F3 ;
      private short AV37TFPropostaQtdItensNota_F ;
      private short AV38TFPropostaQtdItensNota_F_To ;
      private short AV78Propostanotawwds_3_dynamicfiltersoperator1 ;
      private short AV79Propostanotawwds_4_propostaqtditensnota_f1 ;
      private short AV82Propostanotawwds_7_dynamicfiltersoperator2 ;
      private short AV83Propostanotawwds_8_propostaqtditensnota_f2 ;
      private short AV86Propostanotawwds_11_dynamicfiltersoperator3 ;
      private short AV87Propostanotawwds_12_propostaqtditensnota_f3 ;
      private short AV92Propostanotawwds_17_tfpropostaqtditensnota_f ;
      private short AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to ;
      private short AV10OrderedBy ;
      private short A854PropostaQtdItensNota_F ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV73GXV1 ;
      private int AV74GXV2 ;
      private int AV94Propostanotawwds_19_tfpropostatipoproposta_sels_Count ;
      private int AV99Propostanotawwds_24_tfpropostastatus_sels_Count ;
      private int A850PropostaEmpresaClienteId ;
      private int A323PropostaId ;
      private int AV100GXV3 ;
      private long AV57i ;
      private decimal AV43TFPropostaSumItensnota_F ;
      private decimal AV44TFPropostaSumItensnota_F_To ;
      private decimal AV95Propostanotawwds_20_tfpropostasumitensnota_f ;
      private decimal AV96Propostanotawwds_21_tfpropostasumitensnota_f_to ;
      private decimal A887PropostaSumItensnota_F ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime AV45TFPropostaCreatedAt ;
      private DateTime AV46TFPropostaCreatedAt_To ;
      private DateTime AV97Propostanotawwds_22_tfpropostacreatedat ;
      private DateTime AV98Propostanotawwds_23_tfpropostacreatedat_to ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV56TempBoolean ;
      private bool AV80Propostanotawwds_5_dynamicfiltersenabled2 ;
      private bool AV84Propostanotawwds_9_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n323PropostaId ;
      private bool n327PropostaCreatedAt ;
      private bool n329PropostaStatus ;
      private bool n849PropostaTipoProposta ;
      private bool n888PropostaEmpresaRazao ;
      private bool n853PropostaProtocolo ;
      private string AV70Companyname ;
      private string AV39TFPropostaTipoProposta_SelsJson ;
      private string AV47TFPropostaStatus_SelsJson ;
      private string AV68Title ;
      private string AV67Phone ;
      private string AV65Mail ;
      private string AV69Website ;
      private string AV58AddressLine1 ;
      private string AV59AddressLine2 ;
      private string AV60AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterPropostaQtdItensNota_FDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV34TFPropostaProtocolo_Sel ;
      private string AV33TFPropostaProtocolo ;
      private string AV36TFPropostaEmpresaRazao_Sel ;
      private string AV35TFPropostaEmpresaRazao ;
      private string AV51TFPropostaQtdItensNota_F_To_Description ;
      private string AV41TFPropostaTipoProposta_Sel ;
      private string AV40TFPropostaTipoProposta_SelDscs ;
      private string AV52FilterTFPropostaTipoProposta_SelValueDescription ;
      private string AV53TFPropostaSumItensnota_F_To_Description ;
      private string AV54TFPropostaCreatedAt_To_Description ;
      private string AV49TFPropostaStatus_Sel ;
      private string AV48TFPropostaStatus_SelDscs ;
      private string AV55FilterTFPropostaStatus_SelValueDescription ;
      private string AV76Propostanotawwds_1_filterfulltext ;
      private string AV77Propostanotawwds_2_dynamicfiltersselector1 ;
      private string AV81Propostanotawwds_6_dynamicfiltersselector2 ;
      private string AV85Propostanotawwds_10_dynamicfiltersselector3 ;
      private string AV88Propostanotawwds_13_tfpropostaprotocolo ;
      private string AV89Propostanotawwds_14_tfpropostaprotocolo_sel ;
      private string AV90Propostanotawwds_15_tfpropostaempresarazao ;
      private string AV91Propostanotawwds_16_tfpropostaempresarazao_sel ;
      private string lV76Propostanotawwds_1_filterfulltext ;
      private string lV88Propostanotawwds_13_tfpropostaprotocolo ;
      private string lV90Propostanotawwds_15_tfpropostaempresarazao ;
      private string A849PropostaTipoProposta ;
      private string A329PropostaStatus ;
      private string A853PropostaProtocolo ;
      private string A888PropostaEmpresaRazao ;
      private string AV27PropostaTipoPropostaDescription ;
      private string AV28PropostaStatusDescription ;
      private string AV66PageInfo ;
      private string AV63DateInfo ;
      private string AV61AppName ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV42TFPropostaTipoProposta_Sels ;
      private GxSimpleCollection<string> AV50TFPropostaStatus_Sels ;
      private GxSimpleCollection<string> AV94Propostanotawwds_19_tfpropostatipoproposta_sels ;
      private GxSimpleCollection<string> AV99Propostanotawwds_24_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00E73_A850PropostaEmpresaClienteId ;
      private bool[] P00E73_n850PropostaEmpresaClienteId ;
      private int[] P00E73_A323PropostaId ;
      private bool[] P00E73_n323PropostaId ;
      private DateTime[] P00E73_A327PropostaCreatedAt ;
      private bool[] P00E73_n327PropostaCreatedAt ;
      private string[] P00E73_A329PropostaStatus ;
      private bool[] P00E73_n329PropostaStatus ;
      private string[] P00E73_A849PropostaTipoProposta ;
      private bool[] P00E73_n849PropostaTipoProposta ;
      private string[] P00E73_A888PropostaEmpresaRazao ;
      private bool[] P00E73_n888PropostaEmpresaRazao ;
      private string[] P00E73_A853PropostaProtocolo ;
      private bool[] P00E73_n853PropostaProtocolo ;
      private decimal[] P00E73_A887PropostaSumItensnota_F ;
      private short[] P00E73_A854PropostaQtdItensNota_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class propostanotawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E73( IGxContext context ,
                                             string A849PropostaTipoProposta ,
                                             GxSimpleCollection<string> AV94Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV99Propostanotawwds_24_tfpropostastatus_sels ,
                                             string AV89Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                             string AV88Propostanotawwds_13_tfpropostaprotocolo ,
                                             string AV91Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                             string AV90Propostanotawwds_15_tfpropostaempresarazao ,
                                             int AV94Propostanotawwds_19_tfpropostatipoproposta_sels_Count ,
                                             decimal AV95Propostanotawwds_20_tfpropostasumitensnota_f ,
                                             decimal AV96Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                             DateTime AV97Propostanotawwds_22_tfpropostacreatedat ,
                                             DateTime AV98Propostanotawwds_23_tfpropostacreatedat_to ,
                                             int AV99Propostanotawwds_24_tfpropostastatus_sels_Count ,
                                             string A853PropostaProtocolo ,
                                             string A888PropostaEmpresaRazao ,
                                             decimal A887PropostaSumItensnota_F ,
                                             DateTime A327PropostaCreatedAt ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc ,
                                             string AV76Propostanotawwds_1_filterfulltext ,
                                             short A854PropostaQtdItensNota_F ,
                                             string AV77Propostanotawwds_2_dynamicfiltersselector1 ,
                                             short AV78Propostanotawwds_3_dynamicfiltersoperator1 ,
                                             short AV79Propostanotawwds_4_propostaqtditensnota_f1 ,
                                             bool AV80Propostanotawwds_5_dynamicfiltersenabled2 ,
                                             string AV81Propostanotawwds_6_dynamicfiltersselector2 ,
                                             short AV82Propostanotawwds_7_dynamicfiltersoperator2 ,
                                             short AV83Propostanotawwds_8_propostaqtditensnota_f2 ,
                                             bool AV84Propostanotawwds_9_dynamicfiltersenabled3 ,
                                             string AV85Propostanotawwds_10_dynamicfiltersselector3 ,
                                             short AV86Propostanotawwds_11_dynamicfiltersoperator3 ,
                                             short AV87Propostanotawwds_12_propostaqtditensnota_f3 ,
                                             short AV92Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                             short AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[69];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T1.PropostaId, T1.PropostaCreatedAt, T1.PropostaStatus, T1.PropostaTipoProposta, T2.ClienteRazaoSocial AS PropostaEmpresaRazao, T1.PropostaProtocolo, COALESCE( T3.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM ((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaEmpresaClienteId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId, COUNT(*) AS PropostaQtdItensNota_F FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV76Propostanotawwds_1_filterfulltext))=0) or ( ( T1.PropostaProtocolo like '%' || :lV76Propostanotawwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV76Propostanotawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaQtdItensNota_F, 0),'9999'), 2) like '%' || :lV76Propostanotawwds_1_filterfulltext) or ( 'clinica' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'CLINICA')) or ( 'compra de título' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'COMPRA_TITULO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaSumItensnota_F, 0),'999999999999990.99'), 2) like '%' || :lV76Propostanotawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV76Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada'))))");
         AddWhere(sWhereString, "(Not ( :AV77Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV78Propostanotawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV79Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV79Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV77Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV78Propostanotawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV79Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV79Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV77Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV78Propostanotawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV79Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV79Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV80Propostanotawwds_5_dynamicfiltersenabled2 and :AV81Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV82Propostanotawwds_7_dynamicfiltersoperator2 = 0 and ( Not (:AV83Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV83Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV80Propostanotawwds_5_dynamicfiltersenabled2 and :AV81Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV82Propostanotawwds_7_dynamicfiltersoperator2 = 1 and ( Not (:AV83Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV83Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV80Propostanotawwds_5_dynamicfiltersenabled2 and :AV81Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV82Propostanotawwds_7_dynamicfiltersoperator2 = 2 and ( Not (:AV83Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV83Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV84Propostanotawwds_9_dynamicfiltersenabled3 and :AV85Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV86Propostanotawwds_11_dynamicfiltersoperator3 = 0 and ( Not (:AV87Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV87Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV84Propostanotawwds_9_dynamicfiltersenabled3 and :AV85Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV86Propostanotawwds_11_dynamicfiltersoperator3 = 1 and ( Not (:AV87Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV87Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV84Propostanotawwds_9_dynamicfiltersenabled3 and :AV85Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV86Propostanotawwds_11_dynamicfiltersoperator3 = 2 and ( Not (:AV87Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV87Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "((:AV92Propostanotawwds_17_tfpropostaqtditensnota_f = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) >= :AV92Propostanotawwds_17_tfpropostaqtditensnota_f))");
         AddWhere(sWhereString, "((:AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) <= :AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to))");
         AddWhere(sWhereString, "(COALESCE( T3.PropostaQtdItensNota_F, 0) > 0)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Propostanotawwds_14_tfpropostaprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Propostanotawwds_13_tfpropostaprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo like :lV88Propostanotawwds_13_tfpropostaprotocolo)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Propostanotawwds_14_tfpropostaprotocolo_sel)) && ! ( StringUtil.StrCmp(AV89Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo = ( :AV89Propostanotawwds_14_tfpropostaprotocolo_sel))");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( StringUtil.StrCmp(AV89Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.PropostaProtocolo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostanotawwds_16_tfpropostaempresarazao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostanotawwds_15_tfpropostaempresarazao)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV90Propostanotawwds_15_tfpropostaempresarazao)");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostanotawwds_16_tfpropostaempresarazao_sel)) && ! ( StringUtil.StrCmp(AV91Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV91Propostanotawwds_16_tfpropostaempresarazao_sel))");
         }
         else
         {
            GXv_int2[64] = 1;
         }
         if ( StringUtil.StrCmp(AV91Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV94Propostanotawwds_19_tfpropostatipoproposta_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV94Propostanotawwds_19_tfpropostatipoproposta_sels, "T1.PropostaTipoProposta IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV95Propostanotawwds_20_tfpropostasumitensnota_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) >= :AV95Propostanotawwds_20_tfpropostasumitensnota_f)");
         }
         else
         {
            GXv_int2[65] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV96Propostanotawwds_21_tfpropostasumitensnota_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) <= :AV96Propostanotawwds_21_tfpropostasumitensnota_f_to)");
         }
         else
         {
            GXv_int2[66] = 1;
         }
         if ( ! (DateTime.MinValue==AV97Propostanotawwds_22_tfpropostacreatedat) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt >= :AV97Propostanotawwds_22_tfpropostacreatedat)");
         }
         else
         {
            GXv_int2[67] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Propostanotawwds_23_tfpropostacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt <= :AV98Propostanotawwds_23_tfpropostacreatedat_to)");
         }
         else
         {
            GXv_int2[68] = 1;
         }
         if ( AV99Propostanotawwds_24_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV99Propostanotawwds_24_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaProtocolo";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaProtocolo DESC";
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
            scmdbuf += " ORDER BY T1.PropostaTipoProposta";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaTipoProposta DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC";
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
                     return conditional_P00E73(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] );
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
          Object[] prmP00E73;
          prmP00E73 = new Object[] {
          new ParDef("AV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV77Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV78Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV79Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV79Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV78Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV79Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV79Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV78Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV79Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV79Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV80Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV81Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV82Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV83Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV83Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV80Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV81Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV82Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV83Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV83Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV80Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV81Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV82Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV83Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV83Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV84Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV85Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV86Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV87Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV87Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV84Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV85Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV86Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV87Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV87Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV84Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV85Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV86Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV87Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV87Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV92Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV92Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("AV93Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("lV88Propostanotawwds_13_tfpropostaprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV89Propostanotawwds_14_tfpropostaprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("lV90Propostanotawwds_15_tfpropostaempresarazao",GXType.VarChar,150,0) ,
          new ParDef("AV91Propostanotawwds_16_tfpropostaempresarazao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV95Propostanotawwds_20_tfpropostasumitensnota_f",GXType.Number,18,2) ,
          new ParDef("AV96Propostanotawwds_21_tfpropostasumitensnota_f_to",GXType.Number,18,2) ,
          new ParDef("AV97Propostanotawwds_22_tfpropostacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV98Propostanotawwds_23_tfpropostacreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00E73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E73,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((short[]) buf[14])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
