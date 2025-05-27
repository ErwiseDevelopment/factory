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
   public class secfunctionalityfilterparentwwexportreport : GXWebProcedure
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

      public secfunctionalityfilterparentwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityfilterparentwwexportreport( IGxContext context )
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
         setOutputFileName("SecFunctionalityFilterParentWWExportReport");
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
            AV47Title = "Lista de Functionality";
            GXt_char1 = AV49Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV49Companyname = GXt_char1;
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
            H6F0( true, 0) ;
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
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV15SecFunctionalityType) )
         {
            AV14FilterSecFunctionalityTypeValueDescription = gxdomainwwpsecfunctionalitytypes.getDescription(context,AV15SecFunctionalityType);
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Type", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14FilterSecFunctionalityTypeValueDescription, "")), 191, Gx_line+0, 814, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecFunctionalityDescription)) )
         {
            if ( AV17SecFunctionalityDescriptionOperator == 0 )
            {
               AV16FilterSecFunctionalityDescriptionDescription = StringUtil.Format( "%1 (%2)", "Description", "Começa com", "", "", "", "", "", "", "");
            }
            else if ( AV17SecFunctionalityDescriptionOperator == 1 )
            {
               AV16FilterSecFunctionalityDescriptionDescription = StringUtil.Format( "%1 (%2)", "Description", "Contém", "", "", "", "", "", "", "");
            }
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterSecFunctionalityDescriptionDescription, "")), 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18SecFunctionalityDescription, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSecFunctionalityKey_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV25TFSecFunctionalityKey_Sel, "<#Empty#>")==0)));
            AV25TFSecFunctionalityKey_Sel = (AV35TempBoolean ? "(Vazio)" : AV25TFSecFunctionalityKey_Sel);
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Key", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TFSecFunctionalityKey_Sel, "@!")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV25TFSecFunctionalityKey_Sel = (AV35TempBoolean ? "<#Empty#>" : AV25TFSecFunctionalityKey_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityKey)) )
            {
               H6F0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Key", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFSecFunctionalityKey, "@!")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecFunctionalityDescription_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV27TFSecFunctionalityDescription_Sel, "<#Empty#>")==0)));
            AV27TFSecFunctionalityDescription_Sel = (AV35TempBoolean ? "(Vazio)" : AV27TFSecFunctionalityDescription_Sel);
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Description", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TFSecFunctionalityDescription_Sel, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV27TFSecFunctionalityDescription_Sel = (AV35TempBoolean ? "<#Empty#>" : AV27TFSecFunctionalityDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSecFunctionalityDescription)) )
            {
               H6F0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Description", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TFSecFunctionalityDescription, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV31TFSecFunctionalityType_Sels.FromJSonString(AV28TFSecFunctionalityType_SelsJson, null);
         if ( ! ( AV31TFSecFunctionalityType_Sels.Count == 0 ) )
         {
            AV36i = 1;
            AV52GXV1 = 1;
            while ( AV52GXV1 <= AV31TFSecFunctionalityType_Sels.Count )
            {
               AV30TFSecFunctionalityType_Sel = (short)(AV31TFSecFunctionalityType_Sels.GetNumeric(AV52GXV1));
               if ( AV36i == 1 )
               {
                  AV29TFSecFunctionalityType_SelDscs = "";
               }
               else
               {
                  AV29TFSecFunctionalityType_SelDscs += ", ";
               }
               AV34FilterTFSecFunctionalityType_SelValueDescription = gxdomainwwpsecfunctionalitytypes.getDescription(context,AV30TFSecFunctionalityType_Sel);
               AV29TFSecFunctionalityType_SelDscs += AV34FilterTFSecFunctionalityType_SelValueDescription;
               AV36i = (long)(AV36i+1);
               AV52GXV1 = (int)(AV52GXV1+1);
            }
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Type", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29TFSecFunctionalityType_SelDscs, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSecParentFunctionalityDescription_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFSecParentFunctionalityDescription_Sel, "<#Empty#>")==0)));
            AV33TFSecParentFunctionalityDescription_Sel = (AV35TempBoolean ? "(Vazio)" : AV33TFSecParentFunctionalityDescription_Sel);
            H6F0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Parent Functionality", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSecParentFunctionalityDescription_Sel, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFSecParentFunctionalityDescription_Sel = (AV35TempBoolean ? "<#Empty#>" : AV33TFSecParentFunctionalityDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSecParentFunctionalityDescription)) )
            {
               H6F0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Parent Functionality", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFSecParentFunctionalityDescription, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6F0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6F0( false, 36) ;
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
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV10SecParentFunctionalityId;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV13FilterFullText;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV15SecFunctionalityType;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV18SecFunctionalityDescription;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV24TFSecFunctionalityKey;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV25TFSecFunctionalityKey_Sel;
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV26TFSecFunctionalityDescription;
         AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV27TFSecFunctionalityDescription_Sel;
         AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV31TFSecFunctionalityType_Sels;
         AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV32TFSecParentFunctionalityDescription;
         AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV33TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV17SecFunctionalityDescriptionOperator ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A129SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P006F2 */
         pr_default.execute(0, new Object[] {AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A138SecParentFunctionalityDescription = P006F2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P006F2_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P006F2_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P006F2_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P006F2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P006F2_n135SecFunctionalityDescription[0];
            A130SecFunctionalityKey = P006F2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P006F2_n130SecFunctionalityKey[0];
            A129SecParentFunctionalityId = P006F2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P006F2_n129SecParentFunctionalityId[0];
            A128SecFunctionalityId = P006F2_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P006F2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P006F2_n138SecParentFunctionalityDescription[0];
            AV19SecFunctionalityTypeDescription = gxdomainwwpsecfunctionalitytypes.getDescription(context,A136SecFunctionalityType);
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6F0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")), 30, Gx_line+10, 216, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A135SecFunctionalityDescription, "")), 220, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19SecFunctionalityTypeDescription, "")), 410, Gx_line+10, 596, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV65GXV2 = 1;
         while ( AV65GXV2 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV65GXV2));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV15SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV18SecFunctionalityDescription = AV23GridStateFilterValue.gxTpr_Value;
               AV17SecFunctionalityDescriptionOperator = AV23GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV24TFSecFunctionalityKey = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV25TFSecFunctionalityKey_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV26TFSecFunctionalityDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV27TFSecFunctionalityDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV28TFSecFunctionalityType_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV31TFSecFunctionalityType_Sels.FromJSonString(AV28TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV32TFSecParentFunctionalityDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV33TFSecParentFunctionalityDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "PARM_&SECPARENTFUNCTIONALITYID") == 0 )
            {
               AV10SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV65GXV2 = (int)(AV65GXV2+1);
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

      protected void H6F0( bool bFoot ,
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
         AV49Companyname = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         GXt_char1 = "";
         AV13FilterFullText = "";
         AV14FilterSecFunctionalityTypeValueDescription = "";
         AV18SecFunctionalityDescription = "";
         AV16FilterSecFunctionalityDescriptionDescription = "";
         AV25TFSecFunctionalityKey_Sel = "";
         AV24TFSecFunctionalityKey = "";
         AV27TFSecFunctionalityDescription_Sel = "";
         AV26TFSecFunctionalityDescription = "";
         AV31TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV28TFSecFunctionalityType_SelsJson = "";
         AV29TFSecFunctionalityType_SelDscs = "";
         AV34FilterTFSecFunctionalityType_SelValueDescription = "";
         AV33TFSecParentFunctionalityDescription_Sel = "";
         AV32TFSecParentFunctionalityDescription = "";
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = "";
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = "";
         AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = "";
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         lV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         lV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P006F2_A138SecParentFunctionalityDescription = new string[] {""} ;
         P006F2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P006F2_A136SecFunctionalityType = new short[1] ;
         P006F2_n136SecFunctionalityType = new bool[] {false} ;
         P006F2_A135SecFunctionalityDescription = new string[] {""} ;
         P006F2_n135SecFunctionalityDescription = new bool[] {false} ;
         P006F2_A130SecFunctionalityKey = new string[] {""} ;
         P006F2_n130SecFunctionalityKey = new bool[] {false} ;
         P006F2_A129SecParentFunctionalityId = new long[1] ;
         P006F2_n129SecParentFunctionalityId = new bool[] {false} ;
         P006F2_A128SecFunctionalityId = new long[1] ;
         AV19SecFunctionalityTypeDescription = "";
         AV20Session = context.GetSession();
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006F2_A138SecParentFunctionalityDescription, P006F2_n138SecParentFunctionalityDescription, P006F2_A136SecFunctionalityType, P006F2_n136SecFunctionalityType, P006F2_A135SecFunctionalityDescription, P006F2_n135SecFunctionalityDescription, P006F2_A130SecFunctionalityKey, P006F2_n130SecFunctionalityKey, P006F2_A129SecParentFunctionalityId, P006F2_n129SecParentFunctionalityId,
               P006F2_A128SecFunctionalityId
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
      private short AV15SecFunctionalityType ;
      private short AV17SecFunctionalityDescriptionOperator ;
      private short AV30TFSecFunctionalityType_Sel ;
      private short AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ;
      private short A136SecFunctionalityType ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV52GXV1 ;
      private int AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ;
      private int AV65GXV2 ;
      private long AV36i ;
      private long AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ;
      private long AV10SecParentFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV35TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool n130SecFunctionalityKey ;
      private bool n129SecParentFunctionalityId ;
      private string AV49Companyname ;
      private string AV28TFSecFunctionalityType_SelsJson ;
      private string AV47Title ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private string AV13FilterFullText ;
      private string AV14FilterSecFunctionalityTypeValueDescription ;
      private string AV18SecFunctionalityDescription ;
      private string AV16FilterSecFunctionalityDescriptionDescription ;
      private string AV25TFSecFunctionalityKey_Sel ;
      private string AV24TFSecFunctionalityKey ;
      private string AV27TFSecFunctionalityDescription_Sel ;
      private string AV26TFSecFunctionalityDescription ;
      private string AV29TFSecFunctionalityType_SelDscs ;
      private string AV34FilterTFSecFunctionalityType_SelValueDescription ;
      private string AV33TFSecParentFunctionalityDescription_Sel ;
      private string AV32TFSecParentFunctionalityDescription ;
      private string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ;
      private string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ;
      private string AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ;
      private string lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string lV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string lV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string AV19SecFunctionalityTypeDescription ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private IGxSession AV20Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<short> AV31TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006F2_A138SecParentFunctionalityDescription ;
      private bool[] P006F2_n138SecParentFunctionalityDescription ;
      private short[] P006F2_A136SecFunctionalityType ;
      private bool[] P006F2_n136SecFunctionalityType ;
      private string[] P006F2_A135SecFunctionalityDescription ;
      private bool[] P006F2_n135SecFunctionalityDescription ;
      private string[] P006F2_A130SecFunctionalityKey ;
      private bool[] P006F2_n130SecFunctionalityKey ;
      private long[] P006F2_A129SecParentFunctionalityId ;
      private bool[] P006F2_n129SecParentFunctionalityId ;
      private long[] P006F2_A128SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
   }

   public class secfunctionalityfilterparentwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006F2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV17SecFunctionalityDescriptionOperator ,
                                             string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             long AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A129SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( AV17SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( AV17SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityDescription";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityDescription DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityKey";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityType";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityType DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T2.SecFunctionalityDescription";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T2.SecFunctionalityDescription DESC";
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
                     return conditional_P006F2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
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
          Object[] prmP006F2;
          prmP006F2 = new Object[] {
          new ParDef("AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV60Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV63Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar",GXType.VarChar,100,0) ,
          new ParDef("AV64Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
