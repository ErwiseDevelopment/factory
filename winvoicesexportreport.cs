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
   public class winvoicesexportreport : GXWebProcedure
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

      public winvoicesexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public winvoicesexportreport( IGxContext context )
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
         setOutputFileName("WInvoicesExportReport");
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
            AV164Title = "Lista de Nota Fiscal";
            GXt_char1 = AV166Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV166Companyname = GXt_char1;
            GXt_char1 = AV163Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV163Phone = GXt_char1;
            GXt_char1 = AV161Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV161Mail = GXt_char1;
            GXt_char1 = AV165Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV165Website = GXt_char1;
            GXt_char1 = AV154AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV154AddressLine1 = GXt_char1;
            GXt_char1 = AV155AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV155AddressLine2 = GXt_char1;
            GXt_char1 = AV156AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV156AddressLine3 = GXt_char1;
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
            HDO0( true, 0) ;
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
            HDO0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
            {
               AV14NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV14NotaFiscalUF1) )
               {
                  AV17FilterNotaFiscalUF1ValueDescription = gxdomaindmufcod.getDescription(context,AV14NotaFiscalUF1);
                  AV16FilterNotaFiscalUFValueDescription = AV17FilterNotaFiscalUF1ValueDescription;
                  HDO0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fiscal UF", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterNotaFiscalUFValueDescription, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
               {
                  AV20NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV20NotaFiscalUF2) )
                  {
                     AV21FilterNotaFiscalUF2ValueDescription = gxdomaindmufcod.getDescription(context,AV20NotaFiscalUF2);
                     AV16FilterNotaFiscalUFValueDescription = AV21FilterNotaFiscalUF2ValueDescription;
                     HDO0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Fiscal UF", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterNotaFiscalUFValueDescription, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
                  {
                     AV24NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV24NotaFiscalUF3) )
                     {
                        AV25FilterNotaFiscalUF3ValueDescription = gxdomaindmufcod.getDescription(context,AV24NotaFiscalUF3);
                        AV16FilterNotaFiscalUFValueDescription = AV25FilterNotaFiscalUF3ValueDescription;
                        HDO0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Fiscal UF", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterNotaFiscalUFValueDescription, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFNotaFiscalNumero_Sel)) )
         {
            AV152TempBoolean = (bool)(((StringUtil.StrCmp(AV70TFNotaFiscalNumero_Sel, "<#Empty#>")==0)));
            AV70TFNotaFiscalNumero_Sel = (AV152TempBoolean ? "(Vazio)" : AV70TFNotaFiscalNumero_Sel);
            HDO0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Número", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFNotaFiscalNumero_Sel, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV70TFNotaFiscalNumero_Sel = (AV152TempBoolean ? "<#Empty#>" : AV70TFNotaFiscalNumero_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFNotaFiscalNumero)) )
            {
               HDO0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Número", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TFNotaFiscalNumero, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HDO0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HDO0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Fiscal Id", 30, Gx_line+10, 281, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Número", 285, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV170Winvoicesds_1_filterfulltext = AV12FilterFullText;
         AV171Winvoicesds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV172Winvoicesds_3_notafiscaluf1 = AV14NotaFiscalUF1;
         AV173Winvoicesds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV174Winvoicesds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV175Winvoicesds_6_notafiscaluf2 = AV20NotaFiscalUF2;
         AV176Winvoicesds_7_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV177Winvoicesds_8_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV178Winvoicesds_9_notafiscaluf3 = AV24NotaFiscalUF3;
         AV179Winvoicesds_10_tfnotafiscalnumero = AV69TFNotaFiscalNumero;
         AV180Winvoicesds_11_tfnotafiscalnumero_sel = AV70TFNotaFiscalNumero_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV170Winvoicesds_1_filterfulltext ,
                                              AV171Winvoicesds_2_dynamicfiltersselector1 ,
                                              AV172Winvoicesds_3_notafiscaluf1 ,
                                              AV173Winvoicesds_4_dynamicfiltersenabled2 ,
                                              AV174Winvoicesds_5_dynamicfiltersselector2 ,
                                              AV175Winvoicesds_6_notafiscaluf2 ,
                                              AV176Winvoicesds_7_dynamicfiltersenabled3 ,
                                              AV177Winvoicesds_8_dynamicfiltersselector3 ,
                                              AV178Winvoicesds_9_notafiscaluf3 ,
                                              AV180Winvoicesds_11_tfnotafiscalnumero_sel ,
                                              AV179Winvoicesds_10_tfnotafiscalnumero ,
                                              A799NotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV170Winvoicesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV170Winvoicesds_1_filterfulltext), "%", "");
         lV179Winvoicesds_10_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV179Winvoicesds_10_tfnotafiscalnumero), "%", "");
         /* Using cursor P00DO2 */
         pr_default.execute(0, new Object[] {lV170Winvoicesds_1_filterfulltext, AV172Winvoicesds_3_notafiscaluf1, AV175Winvoicesds_6_notafiscaluf2, AV178Winvoicesds_9_notafiscaluf3, lV179Winvoicesds_10_tfnotafiscalnumero, AV180Winvoicesds_11_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A795NotaFiscalUF = P00DO2_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DO2_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DO2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DO2_n799NotaFiscalNumero[0];
            A794NotaFiscalId = P00DO2_A794NotaFiscalId[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HDO0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(A794NotaFiscalId.ToString(), 30, Gx_line+10, 281, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A799NotaFiscalNumero, "")), 285, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV33Session.Get("WInvoicesGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WInvoicesGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("WInvoicesGridState"), null, "", "");
         }
         AV10OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV181GXV1 = 1;
         while ( AV181GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV181GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV69TFNotaFiscalNumero = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV70TFNotaFiscalNumero_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV181GXV1 = (int)(AV181GXV1+1);
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

      protected void HDO0( bool bFoot ,
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
                  AV162PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV159DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV162PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV159DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV157AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV164Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV163Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV161Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV165Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV154AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV155AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV156AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV164Title = "";
         AV166Companyname = "";
         AV163Phone = "";
         AV161Mail = "";
         AV165Website = "";
         AV154AddressLine1 = "";
         AV155AddressLine2 = "";
         AV156AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV17FilterNotaFiscalUF1ValueDescription = "";
         AV16FilterNotaFiscalUFValueDescription = "";
         AV19DynamicFiltersSelector2 = "";
         AV21FilterNotaFiscalUF2ValueDescription = "";
         AV23DynamicFiltersSelector3 = "";
         AV25FilterNotaFiscalUF3ValueDescription = "";
         AV70TFNotaFiscalNumero_Sel = "";
         AV69TFNotaFiscalNumero = "";
         AV170Winvoicesds_1_filterfulltext = "";
         AV171Winvoicesds_2_dynamicfiltersselector1 = "";
         AV174Winvoicesds_5_dynamicfiltersselector2 = "";
         AV177Winvoicesds_8_dynamicfiltersselector3 = "";
         AV179Winvoicesds_10_tfnotafiscalnumero = "";
         AV180Winvoicesds_11_tfnotafiscalnumero_sel = "";
         lV170Winvoicesds_1_filterfulltext = "";
         lV179Winvoicesds_10_tfnotafiscalnumero = "";
         A799NotaFiscalNumero = "";
         P00DO2_A795NotaFiscalUF = new short[1] ;
         P00DO2_n795NotaFiscalUF = new bool[] {false} ;
         P00DO2_A799NotaFiscalNumero = new string[] {""} ;
         P00DO2_n799NotaFiscalNumero = new bool[] {false} ;
         P00DO2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         A794NotaFiscalId = Guid.Empty;
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV162PageInfo = "";
         AV159DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV157AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.winvoicesexportreport__default(),
            new Object[][] {
                new Object[] {
               P00DO2_A795NotaFiscalUF, P00DO2_n795NotaFiscalUF, P00DO2_A799NotaFiscalNumero, P00DO2_n799NotaFiscalNumero, P00DO2_A794NotaFiscalId
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
      private short AV14NotaFiscalUF1 ;
      private short AV20NotaFiscalUF2 ;
      private short AV24NotaFiscalUF3 ;
      private short AV172Winvoicesds_3_notafiscaluf1 ;
      private short AV175Winvoicesds_6_notafiscaluf2 ;
      private short AV178Winvoicesds_9_notafiscaluf3 ;
      private short A795NotaFiscalUF ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV181GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV152TempBoolean ;
      private bool AV173Winvoicesds_4_dynamicfiltersenabled2 ;
      private bool AV176Winvoicesds_7_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n795NotaFiscalUF ;
      private bool n799NotaFiscalNumero ;
      private string AV166Companyname ;
      private string AV164Title ;
      private string AV163Phone ;
      private string AV161Mail ;
      private string AV165Website ;
      private string AV154AddressLine1 ;
      private string AV155AddressLine2 ;
      private string AV156AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV17FilterNotaFiscalUF1ValueDescription ;
      private string AV16FilterNotaFiscalUFValueDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21FilterNotaFiscalUF2ValueDescription ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25FilterNotaFiscalUF3ValueDescription ;
      private string AV70TFNotaFiscalNumero_Sel ;
      private string AV69TFNotaFiscalNumero ;
      private string AV170Winvoicesds_1_filterfulltext ;
      private string AV171Winvoicesds_2_dynamicfiltersselector1 ;
      private string AV174Winvoicesds_5_dynamicfiltersselector2 ;
      private string AV177Winvoicesds_8_dynamicfiltersselector3 ;
      private string AV179Winvoicesds_10_tfnotafiscalnumero ;
      private string AV180Winvoicesds_11_tfnotafiscalnumero_sel ;
      private string lV170Winvoicesds_1_filterfulltext ;
      private string lV179Winvoicesds_10_tfnotafiscalnumero ;
      private string A799NotaFiscalNumero ;
      private string AV162PageInfo ;
      private string AV159DateInfo ;
      private string AV157AppName ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00DO2_A795NotaFiscalUF ;
      private bool[] P00DO2_n795NotaFiscalUF ;
      private string[] P00DO2_A799NotaFiscalNumero ;
      private bool[] P00DO2_n799NotaFiscalNumero ;
      private Guid[] P00DO2_A794NotaFiscalId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class winvoicesexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DO2( IGxContext context ,
                                             string AV170Winvoicesds_1_filterfulltext ,
                                             string AV171Winvoicesds_2_dynamicfiltersselector1 ,
                                             short AV172Winvoicesds_3_notafiscaluf1 ,
                                             bool AV173Winvoicesds_4_dynamicfiltersenabled2 ,
                                             string AV174Winvoicesds_5_dynamicfiltersselector2 ,
                                             short AV175Winvoicesds_6_notafiscaluf2 ,
                                             bool AV176Winvoicesds_7_dynamicfiltersenabled3 ,
                                             string AV177Winvoicesds_8_dynamicfiltersselector3 ,
                                             short AV178Winvoicesds_9_notafiscaluf3 ,
                                             string AV180Winvoicesds_11_tfnotafiscalnumero_sel ,
                                             string AV179Winvoicesds_10_tfnotafiscalnumero ,
                                             string A799NotaFiscalNumero ,
                                             short A795NotaFiscalUF ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT NotaFiscalUF, NotaFiscalNumero, NotaFiscalId FROM NotaFiscal";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Winvoicesds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( NotaFiscalNumero like '%' || :lV170Winvoicesds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV171Winvoicesds_2_dynamicfiltersselector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV172Winvoicesds_3_notafiscaluf1) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV172Winvoicesds_3_notafiscaluf1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV173Winvoicesds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV174Winvoicesds_5_dynamicfiltersselector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV175Winvoicesds_6_notafiscaluf2) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV175Winvoicesds_6_notafiscaluf2)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV176Winvoicesds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV177Winvoicesds_8_dynamicfiltersselector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV178Winvoicesds_9_notafiscaluf3) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV178Winvoicesds_9_notafiscaluf3)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV180Winvoicesds_11_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV179Winvoicesds_10_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero like :lV179Winvoicesds_10_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Winvoicesds_11_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV180Winvoicesds_11_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero = ( :AV180Winvoicesds_11_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV180Winvoicesds_11_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY NotaFiscalUF";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY NotaFiscalId";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY NotaFiscalId DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY NotaFiscalNumero";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY NotaFiscalNumero DESC";
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
                     return conditional_P00DO2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP00DO2;
          prmP00DO2 = new Object[] {
          new ParDef("lV170Winvoicesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV172Winvoicesds_3_notafiscaluf1",GXType.Int16,4,0) ,
          new ParDef("AV175Winvoicesds_6_notafiscaluf2",GXType.Int16,4,0) ,
          new ParDef("AV178Winvoicesds_9_notafiscaluf3",GXType.Int16,4,0) ,
          new ParDef("lV179Winvoicesds_10_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV180Winvoicesds_11_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DO2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DO2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
