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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameterwwexportreport : GXWebProcedure
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

      public wwp_parameterwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameterwwexportreport( IGxContext context )
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
         setOutputFileName("WWP_ParameterWWExportReport");
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
            AV36Title = "Lista de WWP_Parameter_Transaction_Description";
            GXt_char1 = AV38Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV38Companyname = GXt_char1;
            GXt_char1 = AV35Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV35Phone = GXt_char1;
            GXt_char1 = AV33Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV33Mail = GXt_char1;
            GXt_char1 = AV37Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV37Website = GXt_char1;
            GXt_char1 = AV26AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV26AddressLine1 = GXt_char1;
            GXt_char1 = AV27AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV27AddressLine2 = GXt_char1;
            GXt_char1 = AV28AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV28AddressLine3 = GXt_char1;
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
            H7Z0( true, 0) ;
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
            H7Z0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFWWPParameterKey_Sel)) )
         {
            AV25TempBoolean = (bool)(((StringUtil.StrCmp(AV18TFWWPParameterKey_Sel, "<#Empty#>")==0)));
            AV18TFWWPParameterKey_Sel = (AV25TempBoolean ? "(Vazio)" : AV18TFWWPParameterKey_Sel);
            H7Z0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Chave", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFWWPParameterKey_Sel, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV18TFWWPParameterKey_Sel = (AV25TempBoolean ? "<#Empty#>" : AV18TFWWPParameterKey_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFWWPParameterKey)) )
            {
               H7Z0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Chave", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TFWWPParameterKey, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFWWPParameterCategory_Sel)) )
         {
            AV25TempBoolean = (bool)(((StringUtil.StrCmp(AV20TFWWPParameterCategory_Sel, "<#Empty#>")==0)));
            AV20TFWWPParameterCategory_Sel = (AV25TempBoolean ? "(Vazio)" : AV20TFWWPParameterCategory_Sel);
            H7Z0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Categoria", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFWWPParameterCategory_Sel, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV20TFWWPParameterCategory_Sel = (AV25TempBoolean ? "<#Empty#>" : AV20TFWWPParameterCategory_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFWWPParameterCategory)) )
            {
               H7Z0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Categoria", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFWWPParameterCategory, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFWWPParameterDescription_Sel)) )
         {
            AV25TempBoolean = (bool)(((StringUtil.StrCmp(AV22TFWWPParameterDescription_Sel, "<#Empty#>")==0)));
            AV22TFWWPParameterDescription_Sel = (AV25TempBoolean ? "(Vazio)" : AV22TFWWPParameterDescription_Sel);
            H7Z0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFWWPParameterDescription_Sel, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV22TFWWPParameterDescription_Sel = (AV25TempBoolean ? "<#Empty#>" : AV22TFWWPParameterDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFWWPParameterDescription)) )
            {
               H7Z0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFWWPParameterDescription, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWWPParameterValueTrimmed_Sel)) )
         {
            AV25TempBoolean = (bool)(((StringUtil.StrCmp(AV24TFWWPParameterValueTrimmed_Sel, "<#Empty#>")==0)));
            AV24TFWWPParameterValueTrimmed_Sel = (AV25TempBoolean ? "(Vazio)" : AV24TFWWPParameterValueTrimmed_Sel);
            H7Z0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Valor", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFWWPParameterValueTrimmed_Sel, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV24TFWWPParameterValueTrimmed_Sel = (AV25TempBoolean ? "<#Empty#>" : AV24TFWWPParameterValueTrimmed_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPParameterValueTrimmed)) )
            {
               H7Z0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Valor", 25, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFWWPParameterValueTrimmed, "")), 354, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7Z0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7Z0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Chave", 30, Gx_line+10, 216, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Categoria", 220, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 410, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Valor", 600, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV42Workwithplus_wwp_parameterwwds_1_filterfulltext = AV12FilterFullText;
         AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV17TFWWPParameterKey;
         AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV18TFWWPParameterKey_Sel;
         AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV19TFWWPParameterCategory;
         AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV20TFWWPParameterCategory_Sel;
         AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV21TFWWPParameterDescription;
         AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV22TFWWPParameterDescription_Sel;
         AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV23TFWWPParameterValueTrimmed;
         AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV24TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV42Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV42Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV42Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV42Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor P007Z2 */
         pr_default.execute(0, new Object[] {lV42Workwithplus_wwp_parameterwwds_1_filterfulltext, lV42Workwithplus_wwp_parameterwwds_1_filterfulltext, lV42Workwithplus_wwp_parameterwwds_1_filterfulltext, lV42Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4WWPParameterDescription = P007Z2_A4WWPParameterDescription[0];
            A3WWPParameterCategory = P007Z2_A3WWPParameterCategory[0];
            A1WWPParameterKey = P007Z2_A1WWPParameterKey[0];
            A2WWPParameterValue = P007Z2_A2WWPParameterValue[0];
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7Z0( false, 66) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1WWPParameterKey, "")), 30, Gx_line+10, 216, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A3WWPParameterCategory, "")), 220, Gx_line+10, 406, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4WWPParameterDescription, "")), 410, Gx_line+10, 596, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A6WWPParameterValueTrimmed, "")), 600, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+66);
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
         if ( StringUtil.StrCmp(AV13Session.Get("WorkWithPlus.WWP_ParameterWWGridState"), "") == 0 )
         {
            AV15GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.WWP_ParameterWWGridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV13Session.Get("WorkWithPlus.WWP_ParameterWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV15GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY") == 0 )
            {
               AV17TFWWPParameterKey = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY_SEL") == 0 )
            {
               AV18TFWWPParameterKey_Sel = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY") == 0 )
            {
               AV19TFWWPParameterCategory = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY_SEL") == 0 )
            {
               AV20TFWWPParameterCategory_Sel = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION") == 0 )
            {
               AV21TFWWPParameterDescription = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION_SEL") == 0 )
            {
               AV22TFWWPParameterDescription_Sel = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED") == 0 )
            {
               AV23TFWWPParameterValueTrimmed = AV16GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED_SEL") == 0 )
            {
               AV24TFWWPParameterValueTrimmed_Sel = AV16GridStateFilterValue.gxTpr_Value;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
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

      protected void H7Z0( bool bFoot ,
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
                  AV34PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV31DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV36Title = "";
         AV38Companyname = "";
         AV35Phone = "";
         AV33Mail = "";
         AV37Website = "";
         AV26AddressLine1 = "";
         AV27AddressLine2 = "";
         AV28AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV18TFWWPParameterKey_Sel = "";
         AV17TFWWPParameterKey = "";
         AV20TFWWPParameterCategory_Sel = "";
         AV19TFWWPParameterCategory = "";
         AV22TFWWPParameterDescription_Sel = "";
         AV21TFWWPParameterDescription = "";
         AV24TFWWPParameterValueTrimmed_Sel = "";
         AV23TFWWPParameterValueTrimmed = "";
         AV42Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = "";
         AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = "";
         AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = "";
         AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = "";
         lV42Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         lV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         lV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         lV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         lV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         A1WWPParameterKey = "";
         A3WWPParameterCategory = "";
         A4WWPParameterDescription = "";
         A2WWPParameterValue = "";
         P007Z2_A4WWPParameterDescription = new string[] {""} ;
         P007Z2_A3WWPParameterCategory = new string[] {""} ;
         P007Z2_A1WWPParameterKey = new string[] {""} ;
         P007Z2_A2WWPParameterValue = new string[] {""} ;
         A6WWPParameterValueTrimmed = "";
         AV13Session = context.GetSession();
         AV15GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV16GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34PageInfo = "";
         AV31DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV29AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameterwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007Z2_A4WWPParameterDescription, P007Z2_A3WWPParameterCategory, P007Z2_A1WWPParameterKey, P007Z2_A2WWPParameterValue
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
      private int AV51GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV25TempBoolean ;
      private bool AV11OrderedDsc ;
      private string AV38Companyname ;
      private string A2WWPParameterValue ;
      private string AV36Title ;
      private string AV35Phone ;
      private string AV33Mail ;
      private string AV37Website ;
      private string AV26AddressLine1 ;
      private string AV27AddressLine2 ;
      private string AV28AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV18TFWWPParameterKey_Sel ;
      private string AV17TFWWPParameterKey ;
      private string AV20TFWWPParameterCategory_Sel ;
      private string AV19TFWWPParameterCategory ;
      private string AV22TFWWPParameterDescription_Sel ;
      private string AV21TFWWPParameterDescription ;
      private string AV24TFWWPParameterValueTrimmed_Sel ;
      private string AV23TFWWPParameterValueTrimmed ;
      private string AV42Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ;
      private string AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ;
      private string AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ;
      private string AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ;
      private string lV42Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string lV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string lV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string lV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string lV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string A1WWPParameterKey ;
      private string A3WWPParameterCategory ;
      private string A4WWPParameterDescription ;
      private string A6WWPParameterValueTrimmed ;
      private string AV34PageInfo ;
      private string AV31DateInfo ;
      private string AV29AppName ;
      private IGxSession AV13Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P007Z2_A4WWPParameterDescription ;
      private string[] P007Z2_A3WWPParameterCategory ;
      private string[] P007Z2_A1WWPParameterKey ;
      private string[] P007Z2_A2WWPParameterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV15GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
   }

   public class wwp_parameterwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Z2( IGxContext context ,
                                             string AV42Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV42Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV42Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV42Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV42Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WWPParameterKey";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WWPParameterKey DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WWPParameterCategory";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WWPParameterCategory DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WWPParameterDescription";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WWPParameterDescription DESC";
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
                     return conditional_P007Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP007Z2;
          prmP007Z2 = new Object[] {
          new ParDef("lV42Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV44Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV45Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV46Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV47Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV48Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV49Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV50Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
