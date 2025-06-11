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
   public class participantewwexportreport : GXWebProcedure
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

      public participantewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public participantewwexportreport( IGxContext context )
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
         setOutputFileName("ParticipanteWWExportReport");
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
            AV57Title = "Lista de Participante";
            GXt_char1 = AV60Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV60Companyname = GXt_char1;
            GXt_char1 = AV56Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV56Phone = GXt_char1;
            GXt_char1 = AV54Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV54Mail = GXt_char1;
            GXt_char1 = AV58Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV58Website = GXt_char1;
            GXt_char1 = AV47AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV47AddressLine1 = GXt_char1;
            GXt_char1 = AV48AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV48AddressLine2 = GXt_char1;
            GXt_char1 = AV49AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV49AddressLine3 = GXt_char1;
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
            H7D0( true, 0) ;
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
            H7D0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
            {
               AV15ParticipanteDocumento1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ParticipanteDocumento1)) )
               {
                  AV17ParticipanteDocumento = AV15ParticipanteDocumento1;
                  H7D0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Documento", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ParticipanteDocumento, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
               {
                  AV21ParticipanteDocumento2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ParticipanteDocumento2)) )
                  {
                     AV17ParticipanteDocumento = AV21ParticipanteDocumento2;
                     H7D0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Documento", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ParticipanteDocumento, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
                  {
                     AV25ParticipanteDocumento3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ParticipanteDocumento3)) )
                     {
                        AV17ParticipanteDocumento = AV25ParticipanteDocumento3;
                        H7D0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Documento", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ParticipanteDocumento, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV32TFParticipanteId) && (0==AV33TFParticipanteId_To) ) )
         {
            H7D0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Id", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFParticipanteId), "ZZZZZZZ9")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFParticipanteId_To_Description = StringUtil.Format( "%1 (%2)", "Id", "Até", "", "", "", "", "", "", "");
            H7D0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFParticipanteId_To_Description, "")), 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFParticipanteId_To), "ZZZZZZZ9")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFParticipanteDocumento_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV59TFParticipanteDocumento_Sel, "<#Empty#>")==0)));
            AV59TFParticipanteDocumento_Sel = (AV45TempBoolean ? "(Vazio)" : AV59TFParticipanteDocumento_Sel);
            H7D0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Documento", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFParticipanteDocumento_Sel, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV59TFParticipanteDocumento_Sel = (AV45TempBoolean ? "<#Empty#>" : AV59TFParticipanteDocumento_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFParticipanteDocumento)) )
            {
               H7D0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Documento", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFParticipanteDocumento, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFParticipanteEmail_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFParticipanteEmail_Sel, "<#Empty#>")==0)));
            AV37TFParticipanteEmail_Sel = (AV45TempBoolean ? "(Vazio)" : AV37TFParticipanteEmail_Sel);
            H7D0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Email", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFParticipanteEmail_Sel, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFParticipanteEmail_Sel = (AV45TempBoolean ? "<#Empty#>" : AV37TFParticipanteEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFParticipanteEmail)) )
            {
               H7D0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Email", 25, Gx_line+0, 115, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFParticipanteEmail, "")), 115, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7D0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7D0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Id", 30, Gx_line+10, 217, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Documento", 221, Gx_line+10, 408, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Email", 412, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV64Participantewwds_1_filterfulltext = AV12FilterFullText;
         AV65Participantewwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV66Participantewwds_3_participantedocumento1 = AV15ParticipanteDocumento1;
         AV67Participantewwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV68Participantewwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV69Participantewwds_6_participantedocumento2 = AV21ParticipanteDocumento2;
         AV70Participantewwds_7_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV71Participantewwds_8_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV72Participantewwds_9_participantedocumento3 = AV25ParticipanteDocumento3;
         AV73Participantewwds_10_tfparticipanteid = AV32TFParticipanteId;
         AV74Participantewwds_11_tfparticipanteid_to = AV33TFParticipanteId_To;
         AV75Participantewwds_12_tfparticipantedocumento = AV34TFParticipanteDocumento;
         AV76Participantewwds_13_tfparticipantedocumento_sel = AV59TFParticipanteDocumento_Sel;
         AV77Participantewwds_14_tfparticipanteemail = AV36TFParticipanteEmail;
         AV78Participantewwds_15_tfparticipanteemail_sel = AV37TFParticipanteEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV64Participantewwds_1_filterfulltext ,
                                              AV65Participantewwds_2_dynamicfiltersselector1 ,
                                              AV66Participantewwds_3_participantedocumento1 ,
                                              AV67Participantewwds_4_dynamicfiltersenabled2 ,
                                              AV68Participantewwds_5_dynamicfiltersselector2 ,
                                              AV69Participantewwds_6_participantedocumento2 ,
                                              AV70Participantewwds_7_dynamicfiltersenabled3 ,
                                              AV71Participantewwds_8_dynamicfiltersselector3 ,
                                              AV72Participantewwds_9_participantedocumento3 ,
                                              AV73Participantewwds_10_tfparticipanteid ,
                                              AV74Participantewwds_11_tfparticipanteid_to ,
                                              AV76Participantewwds_13_tfparticipantedocumento_sel ,
                                              AV75Participantewwds_12_tfparticipantedocumento ,
                                              AV78Participantewwds_15_tfparticipanteemail_sel ,
                                              AV77Participantewwds_14_tfparticipanteemail ,
                                              A233ParticipanteId ,
                                              A234ParticipanteDocumento ,
                                              A235ParticipanteEmail ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV64Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Participantewwds_1_filterfulltext), "%", "");
         lV64Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Participantewwds_1_filterfulltext), "%", "");
         lV64Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Participantewwds_1_filterfulltext), "%", "");
         lV66Participantewwds_3_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Participantewwds_3_participantedocumento1), "%", "");
         lV69Participantewwds_6_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV69Participantewwds_6_participantedocumento2), "%", "");
         lV72Participantewwds_9_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV72Participantewwds_9_participantedocumento3), "%", "");
         lV75Participantewwds_12_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV75Participantewwds_12_tfparticipantedocumento), "%", "");
         lV77Participantewwds_14_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV77Participantewwds_14_tfparticipanteemail), "%", "");
         /* Using cursor P007D2 */
         pr_default.execute(0, new Object[] {lV64Participantewwds_1_filterfulltext, lV64Participantewwds_1_filterfulltext, lV64Participantewwds_1_filterfulltext, lV66Participantewwds_3_participantedocumento1, lV69Participantewwds_6_participantedocumento2, lV72Participantewwds_9_participantedocumento3, AV73Participantewwds_10_tfparticipanteid, AV74Participantewwds_11_tfparticipanteid_to, lV75Participantewwds_12_tfparticipantedocumento, AV76Participantewwds_13_tfparticipantedocumento_sel, lV77Participantewwds_14_tfparticipanteemail, AV78Participantewwds_15_tfparticipanteemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A233ParticipanteId = P007D2_A233ParticipanteId[0];
            A235ParticipanteEmail = P007D2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007D2_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = P007D2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P007D2_n234ParticipanteDocumento[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7D0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A233ParticipanteId), "ZZZZZZZ9")), 30, Gx_line+10, 217, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A234ParticipanteDocumento, "")), 221, Gx_line+10, 408, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A235ParticipanteEmail, "")), 412, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("ParticipanteWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParticipanteWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("ParticipanteWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV79GXV1 = 1;
         while ( AV79GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV79GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEID") == 0 )
            {
               AV32TFParticipanteId = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV33TFParticipanteId_To = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV34TFParticipanteDocumento = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV59TFParticipanteDocumento_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV36TFParticipanteEmail = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV37TFParticipanteEmail_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV79GXV1 = (int)(AV79GXV1+1);
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

      protected void H7D0( bool bFoot ,
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
                  AV55PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV57Title = "";
         AV60Companyname = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ParticipanteDocumento1 = "";
         AV17ParticipanteDocumento = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ParticipanteDocumento2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ParticipanteDocumento3 = "";
         AV42TFParticipanteId_To_Description = "";
         AV59TFParticipanteDocumento_Sel = "";
         AV34TFParticipanteDocumento = "";
         AV37TFParticipanteEmail_Sel = "";
         AV36TFParticipanteEmail = "";
         AV64Participantewwds_1_filterfulltext = "";
         AV65Participantewwds_2_dynamicfiltersselector1 = "";
         AV66Participantewwds_3_participantedocumento1 = "";
         AV68Participantewwds_5_dynamicfiltersselector2 = "";
         AV69Participantewwds_6_participantedocumento2 = "";
         AV71Participantewwds_8_dynamicfiltersselector3 = "";
         AV72Participantewwds_9_participantedocumento3 = "";
         AV75Participantewwds_12_tfparticipantedocumento = "";
         AV76Participantewwds_13_tfparticipantedocumento_sel = "";
         AV77Participantewwds_14_tfparticipanteemail = "";
         AV78Participantewwds_15_tfparticipanteemail_sel = "";
         lV64Participantewwds_1_filterfulltext = "";
         lV66Participantewwds_3_participantedocumento1 = "";
         lV69Participantewwds_6_participantedocumento2 = "";
         lV72Participantewwds_9_participantedocumento3 = "";
         lV75Participantewwds_12_tfparticipantedocumento = "";
         lV77Participantewwds_14_tfparticipanteemail = "";
         A234ParticipanteDocumento = "";
         A235ParticipanteEmail = "";
         P007D2_A233ParticipanteId = new int[1] ;
         P007D2_A235ParticipanteEmail = new string[] {""} ;
         P007D2_n235ParticipanteEmail = new bool[] {false} ;
         P007D2_A234ParticipanteDocumento = new string[] {""} ;
         P007D2_n234ParticipanteDocumento = new bool[] {false} ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participantewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007D2_A233ParticipanteId, P007D2_A235ParticipanteEmail, P007D2_n235ParticipanteEmail, P007D2_A234ParticipanteDocumento, P007D2_n234ParticipanteDocumento
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
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV32TFParticipanteId ;
      private int AV33TFParticipanteId_To ;
      private int AV73Participantewwds_10_tfparticipanteid ;
      private int AV74Participantewwds_11_tfparticipanteid_to ;
      private int A233ParticipanteId ;
      private int AV79GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool AV67Participantewwds_4_dynamicfiltersenabled2 ;
      private bool AV70Participantewwds_7_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private string AV60Companyname ;
      private string AV57Title ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15ParticipanteDocumento1 ;
      private string AV17ParticipanteDocumento ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21ParticipanteDocumento2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25ParticipanteDocumento3 ;
      private string AV42TFParticipanteId_To_Description ;
      private string AV59TFParticipanteDocumento_Sel ;
      private string AV34TFParticipanteDocumento ;
      private string AV37TFParticipanteEmail_Sel ;
      private string AV36TFParticipanteEmail ;
      private string AV64Participantewwds_1_filterfulltext ;
      private string AV65Participantewwds_2_dynamicfiltersselector1 ;
      private string AV66Participantewwds_3_participantedocumento1 ;
      private string AV68Participantewwds_5_dynamicfiltersselector2 ;
      private string AV69Participantewwds_6_participantedocumento2 ;
      private string AV71Participantewwds_8_dynamicfiltersselector3 ;
      private string AV72Participantewwds_9_participantedocumento3 ;
      private string AV75Participantewwds_12_tfparticipantedocumento ;
      private string AV76Participantewwds_13_tfparticipantedocumento_sel ;
      private string AV77Participantewwds_14_tfparticipanteemail ;
      private string AV78Participantewwds_15_tfparticipanteemail_sel ;
      private string lV64Participantewwds_1_filterfulltext ;
      private string lV66Participantewwds_3_participantedocumento1 ;
      private string lV69Participantewwds_6_participantedocumento2 ;
      private string lV72Participantewwds_9_participantedocumento3 ;
      private string lV75Participantewwds_12_tfparticipantedocumento ;
      private string lV77Participantewwds_14_tfparticipanteemail ;
      private string A234ParticipanteDocumento ;
      private string A235ParticipanteEmail ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P007D2_A233ParticipanteId ;
      private string[] P007D2_A235ParticipanteEmail ;
      private bool[] P007D2_n235ParticipanteEmail ;
      private string[] P007D2_A234ParticipanteDocumento ;
      private bool[] P007D2_n234ParticipanteDocumento ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class participantewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007D2( IGxContext context ,
                                             string AV64Participantewwds_1_filterfulltext ,
                                             string AV65Participantewwds_2_dynamicfiltersselector1 ,
                                             string AV66Participantewwds_3_participantedocumento1 ,
                                             bool AV67Participantewwds_4_dynamicfiltersenabled2 ,
                                             string AV68Participantewwds_5_dynamicfiltersselector2 ,
                                             string AV69Participantewwds_6_participantedocumento2 ,
                                             bool AV70Participantewwds_7_dynamicfiltersenabled3 ,
                                             string AV71Participantewwds_8_dynamicfiltersselector3 ,
                                             string AV72Participantewwds_9_participantedocumento3 ,
                                             int AV73Participantewwds_10_tfparticipanteid ,
                                             int AV74Participantewwds_11_tfparticipanteid_to ,
                                             string AV76Participantewwds_13_tfparticipantedocumento_sel ,
                                             string AV75Participantewwds_12_tfparticipantedocumento ,
                                             string AV78Participantewwds_15_tfparticipanteemail_sel ,
                                             string AV77Participantewwds_14_tfparticipanteemail ,
                                             int A233ParticipanteId ,
                                             string A234ParticipanteDocumento ,
                                             string A235ParticipanteEmail ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT ParticipanteId, ParticipanteEmail, ParticipanteDocumento FROM Participante";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Participantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ParticipanteId,'99999999'), 2) like '%' || :lV64Participantewwds_1_filterfulltext) or ( ParticipanteDocumento like '%' || :lV64Participantewwds_1_filterfulltext) or ( ParticipanteEmail like '%' || :lV64Participantewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Participantewwds_2_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Participantewwds_3_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV66Participantewwds_3_participantedocumento1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV67Participantewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Participantewwds_5_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Participantewwds_6_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV69Participantewwds_6_participantedocumento2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV70Participantewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Participantewwds_8_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Participantewwds_9_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV72Participantewwds_9_participantedocumento3)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV73Participantewwds_10_tfparticipanteid) )
         {
            AddWhere(sWhereString, "(ParticipanteId >= :AV73Participantewwds_10_tfparticipanteid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV74Participantewwds_11_tfparticipanteid_to) )
         {
            AddWhere(sWhereString, "(ParticipanteId <= :AV74Participantewwds_11_tfparticipanteid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Participantewwds_13_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Participantewwds_12_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV75Participantewwds_12_tfparticipantedocumento)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Participantewwds_13_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV76Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento = ( :AV76Participantewwds_13_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Participantewwds_15_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Participantewwds_14_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail like :lV77Participantewwds_14_tfparticipanteemail)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Participantewwds_15_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV78Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail = ( :AV78Participantewwds_15_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from ParticipanteEmail))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY ParticipanteDocumento";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParticipanteDocumento DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY ParticipanteId";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParticipanteId DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY ParticipanteEmail";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParticipanteEmail DESC";
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
                     return conditional_P007D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP007D2;
          prmP007D2 = new Object[] {
          new ParDef("lV64Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Participantewwds_3_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV69Participantewwds_6_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV72Participantewwds_9_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("AV73Participantewwds_10_tfparticipanteid",GXType.Int32,8,0) ,
          new ParDef("AV74Participantewwds_11_tfparticipanteid_to",GXType.Int32,8,0) ,
          new ParDef("lV75Participantewwds_12_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV76Participantewwds_13_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV77Participantewwds_14_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Participantewwds_15_tfparticipanteemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
