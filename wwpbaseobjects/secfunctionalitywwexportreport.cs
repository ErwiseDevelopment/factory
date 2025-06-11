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
   public class secfunctionalitywwexportreport : GXWebProcedure
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

      public secfunctionalitywwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalitywwexportreport( IGxContext context )
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
         setOutputFileName("SecFunctionalityWWExportReport");
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
            AV41Title = "Lista de Functionality";
            GXt_char1 = AV43Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV43Companyname = GXt_char1;
            GXt_char1 = AV40Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV40Phone = GXt_char1;
            GXt_char1 = AV38Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV38Mail = GXt_char1;
            GXt_char1 = AV42Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV42Website = GXt_char1;
            GXt_char1 = AV31AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV31AddressLine1 = GXt_char1;
            GXt_char1 = AV32AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV32AddressLine2 = GXt_char1;
            GXt_char1 = AV33AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV33AddressLine3 = GXt_char1;
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
            H6E0( true, 0) ;
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
            H6E0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSecFunctionalityKey_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFSecFunctionalityKey_Sel, "<#Empty#>")==0)));
            AV19TFSecFunctionalityKey_Sel = (AV29TempBoolean ? "(Vazio)" : AV19TFSecFunctionalityKey_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Key", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFSecFunctionalityKey_Sel, "@!")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFSecFunctionalityKey_Sel = (AV29TempBoolean ? "<#Empty#>" : AV19TFSecFunctionalityKey_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSecFunctionalityKey)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Key", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFSecFunctionalityKey, "@!")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSecFunctionalityDescription_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFSecFunctionalityDescription_Sel, "<#Empty#>")==0)));
            AV21TFSecFunctionalityDescription_Sel = (AV29TempBoolean ? "(Vazio)" : AV21TFSecFunctionalityDescription_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Description", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFSecFunctionalityDescription_Sel, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFSecFunctionalityDescription_Sel = (AV29TempBoolean ? "<#Empty#>" : AV21TFSecFunctionalityDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSecFunctionalityDescription)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Description", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFSecFunctionalityDescription, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV25TFSecFunctionalityType_Sels.FromJSonString(AV22TFSecFunctionalityType_SelsJson, null);
         if ( ! ( AV25TFSecFunctionalityType_Sels.Count == 0 ) )
         {
            AV30i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV25TFSecFunctionalityType_Sels.Count )
            {
               AV24TFSecFunctionalityType_Sel = (short)(AV25TFSecFunctionalityType_Sels.GetNumeric(AV46GXV1));
               if ( AV30i == 1 )
               {
                  AV23TFSecFunctionalityType_SelDscs = "";
               }
               else
               {
                  AV23TFSecFunctionalityType_SelDscs += ", ";
               }
               AV28FilterTFSecFunctionalityType_SelValueDescription = gxdomainwwpsecfunctionalitytypes.getDescription(context,AV24TFSecFunctionalityType_Sel);
               AV23TFSecFunctionalityType_SelDscs += AV28FilterTFSecFunctionalityType_SelValueDescription;
               AV30i = (long)(AV30i+1);
               AV46GXV1 = (int)(AV46GXV1+1);
            }
            H6E0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Type", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFSecFunctionalityType_SelDscs, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV27TFSecParentFunctionalityDescription_Sel, "<#Empty#>")==0)));
            AV27TFSecParentFunctionalityDescription_Sel = (AV29TempBoolean ? "(Vazio)" : AV27TFSecParentFunctionalityDescription_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Parent Functionality", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TFSecParentFunctionalityDescription_Sel, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV27TFSecParentFunctionalityDescription_Sel = (AV29TempBoolean ? "<#Empty#>" : AV27TFSecParentFunctionalityDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSecParentFunctionalityDescription)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Parent Functionality", 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TFSecParentFunctionalityDescription, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6E0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6E0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Key", 30, Gx_line+10, 216, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Description", 220, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Type", 410, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Parent Functionality", 600, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV12FilterFullText;
         AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV18TFSecFunctionalityKey;
         AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV19TFSecFunctionalityKey_Sel;
         AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV20TFSecFunctionalityDescription;
         AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV21TFSecFunctionalityDescription_Sel;
         AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV25TFSecFunctionalityType_Sels;
         AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV26TFSecParentFunctionalityDescription;
         AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV27TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P006E2 */
         pr_default.execute(0, new Object[] {lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A129SecParentFunctionalityId = P006E2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P006E2_n129SecParentFunctionalityId[0];
            A138SecParentFunctionalityDescription = P006E2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P006E2_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P006E2_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P006E2_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P006E2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P006E2_n135SecFunctionalityDescription[0];
            A130SecFunctionalityKey = P006E2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P006E2_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P006E2_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P006E2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P006E2_n138SecParentFunctionalityDescription[0];
            AV13SecFunctionalityTypeDescription = gxdomainwwpsecfunctionalitytypes.getDescription(context,A136SecFunctionalityType);
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6E0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")), 30, Gx_line+10, 216, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A135SecFunctionalityDescription, "")), 220, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13SecFunctionalityTypeDescription, "")), 410, Gx_line+10, 596, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A138SecParentFunctionalityDescription, "")), 600, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV56GXV2 = 1;
         while ( AV56GXV2 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV56GXV2));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV18TFSecFunctionalityKey = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV19TFSecFunctionalityKey_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV20TFSecFunctionalityDescription = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV21TFSecFunctionalityDescription_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV22TFSecFunctionalityType_SelsJson = AV17GridStateFilterValue.gxTpr_Value;
               AV25TFSecFunctionalityType_Sels.FromJSonString(AV22TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV26TFSecParentFunctionalityDescription = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV27TFSecParentFunctionalityDescription_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV2 = (int)(AV56GXV2+1);
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

      protected void H6E0( bool bFoot ,
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
                  AV39PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV36DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV41Title = "";
         AV43Companyname = "";
         AV40Phone = "";
         AV38Mail = "";
         AV42Website = "";
         AV31AddressLine1 = "";
         AV32AddressLine2 = "";
         AV33AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV19TFSecFunctionalityKey_Sel = "";
         AV18TFSecFunctionalityKey = "";
         AV21TFSecFunctionalityDescription_Sel = "";
         AV20TFSecFunctionalityDescription = "";
         AV25TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV22TFSecFunctionalityType_SelsJson = "";
         AV23TFSecFunctionalityType_SelDscs = "";
         AV28FilterTFSecFunctionalityType_SelValueDescription = "";
         AV27TFSecParentFunctionalityDescription_Sel = "";
         AV26TFSecParentFunctionalityDescription = "";
         AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P006E2_A129SecParentFunctionalityId = new long[1] ;
         P006E2_n129SecParentFunctionalityId = new bool[] {false} ;
         P006E2_A138SecParentFunctionalityDescription = new string[] {""} ;
         P006E2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P006E2_A136SecFunctionalityType = new short[1] ;
         P006E2_n136SecFunctionalityType = new bool[] {false} ;
         P006E2_A135SecFunctionalityDescription = new string[] {""} ;
         P006E2_n135SecFunctionalityDescription = new bool[] {false} ;
         P006E2_A130SecFunctionalityKey = new string[] {""} ;
         P006E2_n130SecFunctionalityKey = new bool[] {false} ;
         P006E2_A128SecFunctionalityId = new long[1] ;
         AV13SecFunctionalityTypeDescription = "";
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39PageInfo = "";
         AV36DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV34AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalitywwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006E2_A129SecParentFunctionalityId, P006E2_n129SecParentFunctionalityId, P006E2_A138SecParentFunctionalityDescription, P006E2_n138SecParentFunctionalityDescription, P006E2_A136SecFunctionalityType, P006E2_n136SecFunctionalityType, P006E2_A135SecFunctionalityDescription, P006E2_n135SecFunctionalityDescription, P006E2_A130SecFunctionalityKey, P006E2_n130SecFunctionalityKey,
               P006E2_A128SecFunctionalityId
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
      private short AV24TFSecFunctionalityType_Sel ;
      private short A136SecFunctionalityType ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV46GXV1 ;
      private int AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private int AV56GXV2 ;
      private long AV30i ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV29TempBoolean ;
      private bool AV11OrderedDsc ;
      private bool n129SecParentFunctionalityId ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool n130SecFunctionalityKey ;
      private string AV43Companyname ;
      private string AV22TFSecFunctionalityType_SelsJson ;
      private string AV41Title ;
      private string AV40Phone ;
      private string AV38Mail ;
      private string AV42Website ;
      private string AV31AddressLine1 ;
      private string AV32AddressLine2 ;
      private string AV33AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV19TFSecFunctionalityKey_Sel ;
      private string AV18TFSecFunctionalityKey ;
      private string AV21TFSecFunctionalityDescription_Sel ;
      private string AV20TFSecFunctionalityDescription ;
      private string AV23TFSecFunctionalityType_SelDscs ;
      private string AV28FilterTFSecFunctionalityType_SelValueDescription ;
      private string AV27TFSecParentFunctionalityDescription_Sel ;
      private string AV26TFSecParentFunctionalityDescription ;
      private string AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string AV13SecFunctionalityTypeDescription ;
      private string AV39PageInfo ;
      private string AV36DateInfo ;
      private string AV34AppName ;
      private IGxSession AV14Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<short> AV25TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P006E2_A129SecParentFunctionalityId ;
      private bool[] P006E2_n129SecParentFunctionalityId ;
      private string[] P006E2_A138SecParentFunctionalityDescription ;
      private bool[] P006E2_n138SecParentFunctionalityDescription ;
      private short[] P006E2_A136SecFunctionalityType ;
      private bool[] P006E2_n136SecFunctionalityType ;
      private string[] P006E2_A135SecFunctionalityDescription ;
      private bool[] P006E2_n135SecFunctionalityDescription ;
      private string[] P006E2_A130SecFunctionalityKey ;
      private bool[] P006E2_n130SecFunctionalityKey ;
      private long[] P006E2_A128SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class secfunctionalitywwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006E2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
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
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityDescription";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityDescription DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityKey";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityType";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityType DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.SecFunctionalityDescription";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecFunctionalityDescription DESC";
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
                     return conditional_P006E2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP006E2;
          prmP006E2 = new Object[] {
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional",GXType.VarChar,100,0) ,
          new ParDef("AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
