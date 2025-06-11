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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_formwwexportreport : GXWebProcedure
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

      public wwp_formwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formwwexportreport( IGxContext context )
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
         setOutputFileName("WWP_FormWWExportReport");
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
            AV37Title = "Lista de WWPForm";
            GXt_char1 = AV39Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV39Companyname = GXt_char1;
            GXt_char1 = AV36Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV36Phone = GXt_char1;
            GXt_char1 = AV34Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV34Mail = GXt_char1;
            GXt_char1 = AV38Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV38Website = GXt_char1;
            GXt_char1 = AV27AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV27AddressLine1 = GXt_char1;
            GXt_char1 = AV28AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV28AddressLine2 = GXt_char1;
            GXt_char1 = AV29AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV29AddressLine3 = GXt_char1;
            /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
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
            H810( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            H810( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPFormReferenceName_Sel)) )
         {
            AV26TempBoolean = (bool)(((StringUtil.StrCmp(AV23TFWWPFormReferenceName_Sel, "<#Empty#>")==0)));
            AV23TFWWPFormReferenceName_Sel = (AV26TempBoolean ? "(Vazio)" : AV23TFWWPFormReferenceName_Sel);
            H810( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome de referencia", 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFWWPFormReferenceName_Sel, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV23TFWWPFormReferenceName_Sel = (AV26TempBoolean ? "<#Empty#>" : AV23TFWWPFormReferenceName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFWWPFormReferenceName)) )
            {
               H810( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome de referencia", 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFWWPFormReferenceName, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWWPFormTitle_Sel)) )
         {
            AV26TempBoolean = (bool)(((StringUtil.StrCmp(AV25TFWWPFormTitle_Sel, "<#Empty#>")==0)));
            AV25TFWWPFormTitle_Sel = (AV26TempBoolean ? "(Vazio)" : AV25TFWWPFormTitle_Sel);
            H810( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Qualificação", 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TFWWPFormTitle_Sel, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV25TFWWPFormTitle_Sel = (AV26TempBoolean ? "<#Empty#>" : AV25TFWWPFormTitle_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWWPFormTitle)) )
            {
               H810( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Qualificação", 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFWWPFormTitle, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H810( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         if ( AV15IsAuthorizedWWPFormTitle )
         {
            AV17WWPFormTitleTitle = "Qualificação";
         }
         H810( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome de referencia", 30, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17WWPFormTitleTitle, "")), 410, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV14FilterFullText ,
                                              AV23TFWWPFormReferenceName_Sel ,
                                              AV22TFWWPFormReferenceName ,
                                              AV25TFWWPFormTitle_Sel ,
                                              AV24TFWWPFormTitle ,
                                              AV10WWPFormType ,
                                              AV11WWPFormIsForDynamicValidations ,
                                              A96WWPFormReferenceName ,
                                              A97WWPFormTitle ,
                                              A292WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A95WWPFormVersionNumber ,
                                              A107WWPFormLatestVersionNumber ,
                                              A290WWPFormType } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV22TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV22TFWWPFormReferenceName), "%", "");
         lV24TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV24TFWWPFormTitle), "%", "");
         /* Using cursor P00813 */
         pr_default.execute(0, new Object[] {AV10WWPFormType, lV14FilterFullText, lV14FilterFullText, lV22TFWWPFormReferenceName, AV23TFWWPFormReferenceName_Sel, lV24TFWWPFormTitle, AV25TFWWPFormTitle_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A292WWPFormIsForDynamicValidations = P00813_A292WWPFormIsForDynamicValidations[0];
            A95WWPFormVersionNumber = P00813_A95WWPFormVersionNumber[0];
            A97WWPFormTitle = P00813_A97WWPFormTitle[0];
            A96WWPFormReferenceName = P00813_A96WWPFormReferenceName[0];
            A290WWPFormType = P00813_A290WWPFormType[0];
            A40000GXC1 = P00813_A40000GXC1[0];
            n40000GXC1 = P00813_n40000GXC1[0];
            A94WWPFormId = P00813_A94WWPFormId[0];
            A40000GXC1 = P00813_A40000GXC1[0];
            n40000GXC1 = P00813_n40000GXC1[0];
            GXt_int2 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int2) ;
            A107WWPFormLatestVersionNumber = GXt_int2;
            if ( A95WWPFormVersionNumber == A107WWPFormLatestVersionNumber )
            {
               if ( AV15IsAuthorizedWWPFormTitle )
               {
                  AV16WWPFormTitleData = A97WWPFormTitle;
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H810( false, 36) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A96WWPFormReferenceName, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16WWPFormTitleData, "")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), "") == 0 )
         {
            AV20GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         else
         {
            AV20GridState.FromXml(AV18Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         AV12OrderedBy = AV20GridState.gxTpr_Orderedby;
         AV13OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV21GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV22TFWWPFormReferenceName = AV21GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV23TFWWPFormReferenceName_Sel = AV21GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV24TFWWPFormTitle = AV21GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV25TFWWPFormTitle_Sel = AV21GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV10WWPFormType = (short)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV11WWPFormIsForDynamicValidations = BooleanUtil.Val( AV21GridStateFilterValue.gxTpr_Value);
            }
            AV43GXV1 = (int)(AV43GXV1+1);
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

      protected void S181( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         AV15IsAuthorizedWWPFormTitle = (bool)(((AV10WWPFormType==0)));
      }

      protected void H810( bool bFoot ,
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
                  AV35PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV32DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV37Title = "";
         AV39Companyname = "";
         AV36Phone = "";
         AV34Mail = "";
         AV38Website = "";
         AV27AddressLine1 = "";
         AV28AddressLine2 = "";
         AV29AddressLine3 = "";
         GXt_char1 = "";
         AV14FilterFullText = "";
         AV23TFWWPFormReferenceName_Sel = "";
         AV22TFWWPFormReferenceName = "";
         AV25TFWWPFormTitle_Sel = "";
         AV24TFWWPFormTitle = "";
         AV17WWPFormTitleTitle = "";
         lV14FilterFullText = "";
         lV22TFWWPFormReferenceName = "";
         lV24TFWWPFormTitle = "";
         A96WWPFormReferenceName = "";
         A97WWPFormTitle = "";
         P00813_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         P00813_A95WWPFormVersionNumber = new short[1] ;
         P00813_A97WWPFormTitle = new string[] {""} ;
         P00813_A96WWPFormReferenceName = new string[] {""} ;
         P00813_A290WWPFormType = new short[1] ;
         P00813_A40000GXC1 = new int[1] ;
         P00813_n40000GXC1 = new bool[] {false} ;
         P00813_A94WWPFormId = new short[1] ;
         AV16WWPFormTitleData = "";
         AV18Session = context.GetSession();
         AV20GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV21GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV35PageInfo = "";
         AV32DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV30AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00813_A292WWPFormIsForDynamicValidations, P00813_A95WWPFormVersionNumber, P00813_A97WWPFormTitle, P00813_A96WWPFormReferenceName, P00813_A290WWPFormType, P00813_A40000GXC1, P00813_n40000GXC1, P00813_A94WWPFormId
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
      private short AV10WWPFormType ;
      private short AV12OrderedBy ;
      private short A95WWPFormVersionNumber ;
      private short A107WWPFormLatestVersionNumber ;
      private short A290WWPFormType ;
      private short A94WWPFormId ;
      private short GXt_int2 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A40000GXC1 ;
      private int AV43GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV26TempBoolean ;
      private bool AV15IsAuthorizedWWPFormTitle ;
      private bool AV11WWPFormIsForDynamicValidations ;
      private bool A292WWPFormIsForDynamicValidations ;
      private bool AV13OrderedDsc ;
      private bool n40000GXC1 ;
      private string AV39Companyname ;
      private string AV37Title ;
      private string AV36Phone ;
      private string AV34Mail ;
      private string AV38Website ;
      private string AV27AddressLine1 ;
      private string AV28AddressLine2 ;
      private string AV29AddressLine3 ;
      private string AV14FilterFullText ;
      private string AV23TFWWPFormReferenceName_Sel ;
      private string AV22TFWWPFormReferenceName ;
      private string AV25TFWWPFormTitle_Sel ;
      private string AV24TFWWPFormTitle ;
      private string AV17WWPFormTitleTitle ;
      private string lV14FilterFullText ;
      private string lV22TFWWPFormReferenceName ;
      private string lV24TFWWPFormTitle ;
      private string A96WWPFormReferenceName ;
      private string A97WWPFormTitle ;
      private string AV16WWPFormTitleData ;
      private string AV35PageInfo ;
      private string AV32DateInfo ;
      private string AV30AppName ;
      private IGxSession AV18Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private bool[] P00813_A292WWPFormIsForDynamicValidations ;
      private short[] P00813_A95WWPFormVersionNumber ;
      private string[] P00813_A97WWPFormTitle ;
      private string[] P00813_A96WWPFormReferenceName ;
      private short[] P00813_A290WWPFormType ;
      private int[] P00813_A40000GXC1 ;
      private bool[] P00813_n40000GXC1 ;
      private short[] P00813_A94WWPFormId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV21GridStateFilterValue ;
   }

   public class wwp_formwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00813( IGxContext context ,
                                             string AV14FilterFullText ,
                                             string AV23TFWWPFormReferenceName_Sel ,
                                             string AV22TFWWPFormReferenceName ,
                                             string AV25TFWWPFormTitle_Sel ,
                                             string AV24TFWWPFormTitle ,
                                             short AV10WWPFormType ,
                                             bool AV11WWPFormIsForDynamicValidations ,
                                             string A96WWPFormReferenceName ,
                                             string A97WWPFormTitle ,
                                             bool A292WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             short A95WWPFormVersionNumber ,
                                             short A107WWPFormLatestVersionNumber ,
                                             short A290WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormTitle, T1.WWPFormReferenceName, T1.WWPFormType, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV10WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV14FilterFullText) or ( T1.WWPFormTitle like '%' || :lV14FilterFullText))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV22TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV23TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV23TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV24TFWWPFormTitle)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV25TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV25TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV25TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ( AV10WWPFormType == 1 ) && AV11WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV10WWPFormType == 1 ) && ! AV11WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormReferenceName DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormTitle DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00813(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP00813;
          prmP00813 = new Object[] {
          new ParDef("AV10WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV22TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV23TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV24TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV25TFWWPFormTitle_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00813", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00813,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
