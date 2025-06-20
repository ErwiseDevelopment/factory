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
   public class wwp_df_report : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_report")), "workwithplus.dynamicforms.wwp_df_report") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_report")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormInstanceId");
            if ( ! entryPointCalled )
            {
               AV89WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public wwp_df_report( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_report( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_WWPFormInstanceId )
      {
         this.AV89WWPFormInstanceId = aP0_WWPFormInstanceId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_WWPFormInstanceId )
      {
         this.AV89WWPFormInstanceId = aP0_WWPFormInstanceId;
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
         setOutputFileName((string)("WWP_DF_Report"));
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 11, 11909, 8395, 0, 1, 1, 0, 1, 1) )
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
            AV86WWPFormElements = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Factory21");
            AV10WWPFormInstance.Load(AV89WWPFormInstanceId);
            AV88WWPFormId = AV10WWPFormInstance.gxTpr_Wwpformid;
            AV90WWPFormVersionNumber = AV10WWPFormInstance.gxTpr_Wwpformversionnumber;
            AV93DynamicFormDescription = AV10WWPFormInstance.gxTpr_Wwpformtitle;
            AV92DynamicFormNumber = "#" + StringUtil.Trim( StringUtil.Str( (decimal)(AV10WWPFormInstance.gxTpr_Wwpforminstanceid), 6, 0));
            AV95Date = StringUtil.Trim( context.localUtil.Format( AV10WWPFormInstance.gxTpr_Wwpforminstancedate, "99/99/99"));
            AV94User = "<USER>";
            H460( false, 109) ;
            getPrinter().GxDrawRect(0, Gx_line+0, 552, Gx_line+109, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92DynamicFormNumber, "")), 30, Gx_line+30, 422, Gx_line+45, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93DynamicFormDescription, "")), 30, Gx_line+45, 422, Gx_line+79, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94User, "")), 422, Gx_line+30, 522, Gx_line+54, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Date, "")), 422, Gx_line+54, 522, Gx_line+79, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+109);
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport(context ).execute(  AV10WWPFormInstance,  0,  0,  true, ref  AV86WWPFormElements) ;
            AV13AuxNum = 1.1m;
            AV61SeparatorChar = StringUtil.Trim( context.localUtil.Format( AV13AuxNum, "9.9"));
            AV61SeparatorChar = StringUtil.Substring( AV61SeparatorChar, 2, 1);
            AV98GXV1 = 1;
            while ( AV98GXV1 <= AV86WWPFormElements.Count )
            {
               AV81WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV86WWPFormElements.Item(AV98GXV1));
               AV11WWPFormInstanceElementId = 0;
               AV38DisplayElementsPlain = true;
               if ( AV81WWPFormElement.gxTpr_Wwpformelementtype == 1 )
               {
                  AV82WWPFormElementId = AV81WWPFormElement.gxTpr_Wwpformelementid;
                  /* Execute user subroutine: 'PRINTITEM' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( AV81WWPFormElement.gxTpr_Wwpformelementtype == 2 )
               {
                  AV75WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
                  AV75WWP_DF_GroupMetadata.FromJSonString(AV81WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  AV72VisibleCondition = AV75WWP_DF_GroupMetadata.gxTpr_Visiblecondition;
                  AV85WWPFormElementParentId = AV81WWPFormElement.gxTpr_Wwpformelementparentid;
                  AV9WWPFormElementTitle = AV81WWPFormElement.gxTpr_Wwpformelementtitle;
                  /* Execute user subroutine: 'PRINTGROUP' */
                  S131 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( AV81WWPFormElement.gxTpr_Wwpformelementtype == 4 )
               {
                  AV76WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
                  AV76WWP_DF_LabelMetadata.FromJSonString(AV81WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  AV72VisibleCondition = AV76WWP_DF_LabelMetadata.gxTpr_Visiblecondition;
                  AV9WWPFormElementTitle = AV81WWPFormElement.gxTpr_Wwpformelementtitle;
                  AV77WWP_DF_LabelMetadata_Style = AV76WWP_DF_LabelMetadata.gxTpr_Style;
                  /* Execute user subroutine: 'PRINTLABEL' */
                  S123 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( AV81WWPFormElement.gxTpr_Wwpformelementtype == 5 )
               {
                  AV80WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
                  AV80WWP_DF_StepMetadata.FromJSonString(AV81WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  AV85WWPFormElementParentId = AV81WWPFormElement.gxTpr_Wwpformelementparentid;
                  AV9WWPFormElementTitle = AV81WWPFormElement.gxTpr_Wwpformelementtitle;
                  AV72VisibleCondition = AV80WWP_DF_StepMetadata.gxTpr_Visiblecondition;
                  /* Execute user subroutine: 'PRINTGROUP' */
                  S131 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( AV81WWPFormElement.gxTpr_Wwpformelementtype == 3 )
               {
                  AV78WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
                  AV78WWP_DF_MultipleMetadata.FromJSonString(AV81WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                  AV38DisplayElementsPlain = (bool)(((AV78WWP_DF_MultipleMetadata.gxTpr_Repetitionsdatatype==1)));
                  AV91PrintingPlainedGrid = (bool)(!AV38DisplayElementsPlain);
                  if ( ! AV38DisplayElementsPlain )
                  {
                     AV87WWPFormElementsMultiples = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Factory21");
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport(context ).execute(  AV10WWPFormInstance,  0,  AV81WWPFormElement.gxTpr_Wwpformelementid,  false, ref  AV87WWPFormElementsMultiples) ;
                  }
                  if ( AV38DisplayElementsPlain || ( AV87WWPFormElementsMultiples.Count > 0 ) )
                  {
                     AV83WWPFormElementIdSimpleChildren = AV81WWPFormElement.gxTpr_Wwpformelementid;
                     /* Execute user subroutine: 'PRINTMULTIPLE' */
                     S141 ();
                     if ( returnInSub )
                     {
                        cleanup();
                        if (true) return;
                     }
                  }
                  AV91PrintingPlainedGrid = false;
               }
               AV98GXV1 = (int)(AV98GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H460( true, 0) ;
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
         /* 'PRINTITEM' Routine */
         returnInSub = false;
         /* Using cursor P00462 */
         pr_default.execute(0, new Object[] {AV89WWPFormInstanceId, AV82WWPFormElementId, AV11WWPFormInstanceElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A94WWPFormId = P00462_A94WWPFormId[0];
            A95WWPFormVersionNumber = P00462_A95WWPFormVersionNumber[0];
            A103WWPFormInstanceElementId = P00462_A103WWPFormInstanceElementId[0];
            A98WWPFormElementId = P00462_A98WWPFormElementId[0];
            A102WWPFormInstanceId = P00462_A102WWPFormInstanceId[0];
            A113WWPFormInstanceElemBlobFileName = P00462_A113WWPFormInstanceElemBlobFileName[0];
            A111WWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A112WWPFormInstanceElemBlobFileType = P00462_A112WWPFormInstanceElemBlobFileType[0];
            A111WWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            A106WWPFormElementDataType = P00462_A106WWPFormElementDataType[0];
            A114WWPFormInstanceElemBoolean = P00462_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = P00462_n114WWPFormInstanceElemBoolean[0];
            A124WWPFormElementMetadata = P00462_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = P00462_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = P00462_A117WWPFormElementTitle[0];
            A109WWPFormInstanceElemChar = P00462_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = P00462_n109WWPFormInstanceElemChar[0];
            A110WWPFormInstanceElemNumeric = P00462_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = P00462_n110WWPFormInstanceElemNumeric[0];
            A108WWPFormInstanceElemDate = P00462_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = P00462_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = P00462_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = P00462_n115WWPFormInstanceElemDateTime[0];
            A111WWPFormInstanceElemBlob = P00462_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = P00462_n111WWPFormInstanceElemBlob[0];
            A94WWPFormId = P00462_A94WWPFormId[0];
            A95WWPFormVersionNumber = P00462_A95WWPFormVersionNumber[0];
            A106WWPFormElementDataType = P00462_A106WWPFormElementDataType[0];
            A124WWPFormElementMetadata = P00462_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = P00462_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = P00462_A117WWPFormElementTitle[0];
            AV45ItemPrited = false;
            AV37DataTitle = "";
            if ( A106WWPFormElementDataType == 1 )
            {
               if ( A114WWPFormInstanceElemBoolean )
               {
                  AV18BooleanTitle = context.GetImagePath( "df898157-ba08-44cb-bea4-1d1b8306ad8b", "", context.GetTheme( ));
                  AV100Booleantitle_GXI = GXDbFile.PathToUrl( context.GetImagePath( "df898157-ba08-44cb-bea4-1d1b8306ad8b", "", context.GetTheme( )), context);
               }
               else
               {
                  AV18BooleanTitle = context.GetImagePath( "f37130cd-b228-4358-83e7-09e0b766badc", "", context.GetTheme( ));
                  AV100Booleantitle_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f37130cd-b228-4358-83e7-09e0b766badc", "", context.GetTheme( )), context);
               }
               AV73WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
               AV73WWP_DF_BooleanMetadata.FromJSonString(A124WWPFormElementMetadata, null);
               AV19BooleanTitle_ControlTitle = AV73WWP_DF_BooleanMetadata.gxTpr_Checkbox.gxTpr_Controltitle;
               if ( AV91PrintingPlainedGrid || ( A125WWPFormElementCaption == 1 ) )
               {
                  AV14BooleanLabel = AV18BooleanTitle;
                  AV101Booleanlabel_GXI = AV100Booleantitle_GXI;
                  AV49Label2 = A117WWPFormElementTitle;
                  AV15BooleanLabel_ControlTitle = AV19BooleanTitle_ControlTitle;
                  H460( false, 31) ;
                  getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Label2, "")), 0, Gx_line+0, 205, Gx_line+16, 2, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV14BooleanLabel)) ? AV101Booleanlabel_GXI : AV14BooleanLabel);
                  getPrinter().GxDrawBitMap(sImgUrl, 220, Gx_line+0, 237, Gx_line+16) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15BooleanLabel_ControlTitle, "")), 247, Gx_line+0, 552, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+31);
               }
               else
               {
                  if ( A125WWPFormElementCaption == 2 )
                  {
                     AV9WWPFormElementTitle = A117WWPFormElementTitle;
                     AV77WWP_DF_LabelMetadata_Style = 0;
                     /* Execute user subroutine: 'PRINTLABEL' */
                     S123 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  AV16BooleanNoLabel = AV18BooleanTitle;
                  AV102Booleannolabel_GXI = AV100Booleantitle_GXI;
                  AV17BooleanNoLabel_ControlTitle = AV19BooleanTitle_ControlTitle;
                  H460( false, 30) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16BooleanNoLabel)) ? AV102Booleannolabel_GXI : AV16BooleanNoLabel);
                  getPrinter().GxDrawBitMap(sImgUrl, 0, Gx_line+0, 17, Gx_line+15) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17BooleanNoLabel_ControlTitle, "")), 27, Gx_line+0, 552, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               AV45ItemPrited = true;
            }
            else if ( A106WWPFormElementDataType == 2 )
            {
               AV74WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
               AV74WWP_DF_CharMetadata.FromJSonString(A124WWPFormElementMetadata, null);
               if ( AV74WWP_DF_CharMetadata.gxTpr_Controltype == 4 )
               {
                  if ( ( ( AV74WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 1 ) && AV74WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection ) || ( AV74WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 4 ) )
                  {
                     AV60SelectedOptions.FromJSonString(A109WWPFormInstanceElemChar, null);
                     AV103GXV2 = 1;
                     while ( AV103GXV2 <= AV60SelectedOptions.Count )
                     {
                        AV59SelectedOption = ((string)AV60SelectedOptions.Item(AV103GXV2));
                        if ( StringUtil.StrCmp(AV37DataTitle, "") != 0 )
                        {
                           AV37DataTitle += ", ";
                        }
                        AV37DataTitle += AV59SelectedOption;
                        AV103GXV2 = (int)(AV103GXV2+1);
                     }
                  }
                  else
                  {
                     AV37DataTitle = A109WWPFormInstanceElemChar;
                  }
               }
               else
               {
                  AV37DataTitle = A109WWPFormInstanceElemChar;
               }
            }
            else if ( A106WWPFormElementDataType == 3 )
            {
               if ( ( A110WWPFormInstanceElemNumeric > Convert.ToDecimal( 0 )) )
               {
                  AV37DataTitle = StringUtil.Trim( context.localUtil.Format( A110WWPFormInstanceElemNumeric, "ZZZ,ZZZ,ZZZ,ZZ9.99999"));
                  AV79WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
                  AV79WWP_DF_NumericMetadata.FromJSonString(A124WWPFormElementMetadata, null);
                  if ( (0==AV79WWP_DF_NumericMetadata.gxTpr_Decimals) )
                  {
                     AV37DataTitle = StringUtil.Substring( AV37DataTitle, 1, StringUtil.StringSearch( AV37DataTitle, AV61SeparatorChar, 1)-1);
                  }
                  else if ( AV79WWP_DF_NumericMetadata.gxTpr_Decimals < 5 )
                  {
                     AV37DataTitle = StringUtil.Substring( AV37DataTitle, 1, StringUtil.StringSearch( AV37DataTitle, AV61SeparatorChar, 1)+AV79WWP_DF_NumericMetadata.gxTpr_Decimals);
                  }
               }
               else
               {
                  AV37DataTitle = "0";
               }
            }
            else if ( A106WWPFormElementDataType == 4 )
            {
               if ( ! (DateTime.MinValue==A108WWPFormInstanceElemDate) )
               {
                  AV37DataTitle = context.localUtil.Format( A108WWPFormInstanceElemDate, "99/99/99");
               }
            }
            else if ( A106WWPFormElementDataType == 5 )
            {
               if ( ! (DateTime.MinValue==A115WWPFormInstanceElemDateTime) )
               {
                  AV37DataTitle = context.localUtil.Format( A115WWPFormInstanceElemDateTime, "99/99/99 99:99");
               }
            }
            else if ( ( A106WWPFormElementDataType == 7 ) || ( A106WWPFormElementDataType == 8 ) )
            {
               AV37DataTitle = A109WWPFormInstanceElemChar;
            }
            else if ( A106WWPFormElementDataType == 10 )
            {
               AV43ImageTitle = A111WWPFormInstanceElemBlob;
               AV104Imagetitle_GXI = GXDbFile.GetUriFromFile( A113WWPFormInstanceElemBlobFileName, A112WWPFormInstanceElemBlobFileType, A111WWPFormInstanceElemBlob);
               if ( AV91PrintingPlainedGrid || ( A125WWPFormElementCaption == 1 ) )
               {
                  AV41ImageLabel = AV43ImageTitle;
                  AV105Imagelabel_GXI = AV104Imagetitle_GXI;
                  AV48Label1 = A117WWPFormElementTitle;
                  H460( false, 175) ;
                  getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Label1, "")), 0, Gx_line+5, 205, Gx_line+155, 2+16, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41ImageLabel)) ? AV105Imagelabel_GXI : AV41ImageLabel);
                  getPrinter().GxDrawBitMap(sImgUrl, 220, Gx_line+5, 552, Gx_line+155) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+175);
               }
               else
               {
                  if ( A125WWPFormElementCaption == 2 )
                  {
                     AV9WWPFormElementTitle = A117WWPFormElementTitle;
                     AV77WWP_DF_LabelMetadata_Style = 0;
                     /* Execute user subroutine: 'PRINTLABEL' */
                     S123 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  AV42ImageNoLabel = AV43ImageTitle;
                  AV106Imagenolabel_GXI = AV104Imagetitle_GXI;
                  H460( false, 175) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42ImageNoLabel)) ? AV106Imagenolabel_GXI : AV42ImageNoLabel);
                  getPrinter().GxDrawBitMap(sImgUrl, 0, Gx_line+5, 552, Gx_line+155) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+175);
               }
               AV45ItemPrited = true;
            }
            if ( ! AV45ItemPrited )
            {
               if ( AV38DisplayElementsPlain )
               {
                  if ( AV91PrintingPlainedGrid || ( A125WWPFormElementCaption == 1 ) )
                  {
                     if ( AV46j == 1 )
                     {
                        H460( false, 16) ;
                        getPrinter().GxDrawLine(0, Gx_line+0, 552, Gx_line+0, 1, 211, 211, 211, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+16);
                     }
                     AV31DataLabel = AV37DataTitle;
                     AV47Label = A117WWPFormElementTitle;
                     GXt_int1 = AV56Lines;
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_report_calclines(context ).execute(  AV47Label,  "Label_left", out  GXt_int1) ;
                     AV56Lines = GXt_int1;
                     GXt_int1 = AV57Lines2;
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_report_calclines(context ).execute(  AV31DataLabel,  "Data_right", out  GXt_int1) ;
                     AV57Lines2 = GXt_int1;
                     if ( ( AV56Lines <= 1 ) && ( AV57Lines2 <= 1 ) )
                     {
                        H460( false, 41) ;
                        getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Label, "")), 0, Gx_line+5, 205, Gx_line+21, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawRect(220, Gx_line+0, 552, Gx_line+26, 1, 0, 0, 0, 1, 243, 243, 243, 1, 1, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31DataLabel, "")), 230, Gx_line+5, 552, Gx_line+21, 0+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+41);
                     }
                     else if ( ( AV56Lines <= 2 ) && ( AV57Lines2 <= 2 ) )
                     {
                        AV32DataLabel2Lines = AV31DataLabel;
                        AV50Label2Lines = AV47Label;
                        H460( false, 61) ;
                        getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Label2Lines, "")), 0, Gx_line+5, 205, Gx_line+41, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawRect(220, Gx_line+0, 552, Gx_line+46, 1, 0, 0, 0, 1, 243, 243, 243, 1, 1, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DataLabel2Lines, "")), 230, Gx_line+5, 552, Gx_line+41, 0+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+61);
                     }
                     else
                     {
                        AV33DataLabel5Lines = AV31DataLabel;
                        AV51Label5Lines = AV47Label;
                        H460( false, 105) ;
                        getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Label5Lines, "")), 0, Gx_line+5, 205, Gx_line+85, 2+16, 0, 0, 0) ;
                        getPrinter().GxDrawRect(220, Gx_line+0, 552, Gx_line+90, 1, 0, 0, 0, 1, 243, 243, 243, 1, 1, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33DataLabel5Lines, "")), 230, Gx_line+5, 552, Gx_line+85, 0+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+105);
                     }
                  }
                  else
                  {
                     if ( A125WWPFormElementCaption == 2 )
                     {
                        AV9WWPFormElementTitle = A117WWPFormElementTitle;
                        AV77WWP_DF_LabelMetadata_Style = 0;
                        /* Execute user subroutine: 'PRINTLABEL' */
                        S123 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                     AV34DataNoLabel = AV37DataTitle;
                     GXt_int1 = AV56Lines;
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_report_calclines(context ).execute(  AV34DataNoLabel,  "Data_entire_line", out  GXt_int1) ;
                     AV56Lines = GXt_int1;
                     if ( AV56Lines <= 1 )
                     {
                        H460( false, 40) ;
                        getPrinter().GxDrawRect(0, Gx_line+0, 552, Gx_line+25, 1, 0, 0, 0, 1, 243, 243, 243, 1, 1, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34DataNoLabel, "")), 10, Gx_line+5, 552, Gx_line+20, 0+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+40);
                     }
                     else if ( AV56Lines == 2 )
                     {
                        AV35DataNoLabel2Lines = AV37DataTitle;
                        H460( false, 57) ;
                        getPrinter().GxDrawRect(0, Gx_line+0, 552, Gx_line+42, 1, 0, 0, 0, 1, 243, 243, 243, 1, 1, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35DataNoLabel2Lines, "")), 10, Gx_line+5, 552, Gx_line+37, 0+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+57);
                     }
                     else
                     {
                        AV36DataNoLabel5Lines = AV37DataTitle;
                        H460( false, 105) ;
                        getPrinter().GxDrawRect(0, Gx_line+0, 552, Gx_line+90, 1, 0, 0, 0, 1, 243, 243, 243, 1, 1, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36DataNoLabel5Lines, "")), 10, Gx_line+5, 552, Gx_line+85, 0+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+105);
                     }
                  }
               }
               else
               {
                  AV20column = AV46j;
                  if ( AV20column == 1 )
                  {
                     if ( AV40i == 1 )
                     {
                        AV66Title_OneColumn = A117WWPFormElementTitle;
                        AV70Title_TwoColumns1 = AV66Title_OneColumn;
                        AV67Title_ThreeColumns1 = AV66Title_OneColumn;
                        AV62Title_FourColumns1 = AV66Title_OneColumn;
                        if ( AV12AmountOfElementsOfGrid == 1 )
                        {
                           if ( AV40i > 1 )
                           {
                              H460( false, 1) ;
                              getPrinter().GxDrawLine(0, Gx_line+0, 552, Gx_line+0, 1, 211, 211, 211, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+1);
                           }
                           H460( false, 38) ;
                           getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Title_OneColumn, "")), 0, Gx_line+10, 552, Gx_line+26, 0, 0, 0, 0) ;
                           getPrinter().GxDrawLine(0, Gx_line+32, 552, Gx_line+32, 2, 8, 160, 134, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+38);
                        }
                     }
                     AV25Data_OneColumn = AV37DataTitle;
                     AV29Data_TwoColumns1 = AV37DataTitle;
                     AV26Data_ThreeColumns1 = AV37DataTitle;
                     AV21Data_FourColumns1 = AV37DataTitle;
                     if ( AV12AmountOfElementsOfGrid == 1 )
                     {
                        if ( AV40i > 1 )
                        {
                           H460( false, 1) ;
                           getPrinter().GxDrawLine(0, Gx_line+0, 552, Gx_line+0, 1, 211, 211, 211, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+1);
                        }
                        H460( false, 31) ;
                        getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Data_OneColumn, "")), 0, Gx_line+10, 552, Gx_line+26, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+31);
                     }
                  }
                  else if ( AV20column == 2 )
                  {
                     if ( AV40i == 1 )
                     {
                        AV71Title_TwoColumns2 = A117WWPFormElementTitle;
                        AV68Title_ThreeColumns2 = AV71Title_TwoColumns2;
                        AV63Title_FourColumns2 = AV71Title_TwoColumns2;
                        if ( AV12AmountOfElementsOfGrid == 2 )
                        {
                           H460( false, 38) ;
                           getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Title_TwoColumns1, "")), 0, Gx_line+10, 276, Gx_line+26, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Title_TwoColumns2, "")), 276, Gx_line+10, 552, Gx_line+26, 0, 0, 0, 0) ;
                           getPrinter().GxDrawLine(0, Gx_line+32, 552, Gx_line+32, 2, 8, 160, 134, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+38);
                        }
                     }
                     AV30Data_TwoColumns2 = AV37DataTitle;
                     AV27Data_ThreeColumns2 = AV37DataTitle;
                     AV22Data_FourColumns2 = AV37DataTitle;
                     if ( AV12AmountOfElementsOfGrid == 2 )
                     {
                        if ( AV40i > 1 )
                        {
                           H460( false, 1) ;
                           getPrinter().GxDrawLine(0, Gx_line+0, 552, Gx_line+0, 1, 211, 211, 211, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+1);
                        }
                        H460( false, 31) ;
                        getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Data_TwoColumns1, "")), 0, Gx_line+10, 276, Gx_line+26, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Data_TwoColumns2, "")), 276, Gx_line+10, 552, Gx_line+26, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+31);
                     }
                  }
                  else if ( AV20column == 3 )
                  {
                     if ( AV40i == 1 )
                     {
                        AV69Title_ThreeColumns3 = A117WWPFormElementTitle;
                        AV64Title_FourColumns3 = AV69Title_ThreeColumns3;
                        if ( AV12AmountOfElementsOfGrid == 3 )
                        {
                           H460( false, 33) ;
                           getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Title_ThreeColumns1, "")), 0, Gx_line+10, 184, Gx_line+26, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Title_ThreeColumns2, "")), 184, Gx_line+10, 368, Gx_line+26, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Title_ThreeColumns3, "")), 368, Gx_line+10, 552, Gx_line+26, 0, 0, 0, 0) ;
                           getPrinter().GxDrawLine(0, Gx_line+32, 552, Gx_line+32, 2, 8, 160, 134, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+33);
                        }
                     }
                     AV28Data_ThreeColumns3 = AV37DataTitle;
                     AV23Data_FourColumns3 = AV37DataTitle;
                     if ( AV12AmountOfElementsOfGrid == 3 )
                     {
                        if ( AV40i > 1 )
                        {
                           H460( false, 1) ;
                           getPrinter().GxDrawLine(0, Gx_line+0, 552, Gx_line+0, 1, 211, 211, 211, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+1);
                        }
                        H460( false, 32) ;
                        getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Data_ThreeColumns1, "")), 0, Gx_line+8, 184, Gx_line+24, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Data_ThreeColumns2, "")), 184, Gx_line+8, 368, Gx_line+24, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Data_ThreeColumns3, "")), 368, Gx_line+8, 552, Gx_line+24, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+32);
                     }
                  }
                  else if ( AV20column == 4 )
                  {
                     if ( AV40i == 1 )
                     {
                        AV65Title_FourColumns4 = A117WWPFormElementTitle;
                        if ( AV12AmountOfElementsOfGrid == 4 )
                        {
                           H460( false, 34) ;
                           getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Title_FourColumns1, "")), 0, Gx_line+13, 138, Gx_line+29, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Title_FourColumns2, "")), 138, Gx_line+13, 276, Gx_line+29, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Title_FourColumns3, "")), 276, Gx_line+13, 414, Gx_line+29, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Title_FourColumns4, "")), 414, Gx_line+13, 552, Gx_line+29, 0, 0, 0, 0) ;
                           getPrinter().GxDrawLine(0, Gx_line+33, 552, Gx_line+33, 2, 8, 160, 134, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+34);
                        }
                     }
                     AV24Data_FourColumns4 = AV37DataTitle;
                     if ( AV12AmountOfElementsOfGrid == 4 )
                     {
                        if ( AV40i > 1 )
                        {
                           H460( false, 1) ;
                           getPrinter().GxDrawLine(0, Gx_line+0, 552, Gx_line+0, 1, 211, 211, 211, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+1);
                        }
                        H460( false, 31) ;
                        getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Data_FourColumns1, "")), 0, Gx_line+10, 138, Gx_line+26, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Data_FourColumns2, "")), 138, Gx_line+10, 276, Gx_line+26, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Data_FourColumns3, "")), 276, Gx_line+10, 414, Gx_line+26, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Data_FourColumns4, "")), 414, Gx_line+10, 552, Gx_line+26, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+31);
                     }
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S123( )
      {
         /* 'PRINTLABEL' Routine */
         returnInSub = false;
         if ( AV77WWP_DF_LabelMetadata_Style == 1 )
         {
            AV8LabelTitle = StringUtil.Upper( AV9WWPFormElementTitle);
            GXt_int1 = AV56Lines;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_report_calclines(context ).execute(  AV8LabelTitle,  "Title", out  GXt_int1) ;
            AV56Lines = GXt_int1;
            if ( AV56Lines <= 1 )
            {
               H460( false, 49) ;
               getPrinter().GxAttris("Verdana", 10, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8LabelTitle, "")), 0, Gx_line+15, 552, Gx_line+33, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+38, 552, Gx_line+38, 1, 105, 101, 103, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+49);
            }
            else
            {
               AV55LabelTitle2Lines = AV8LabelTitle;
               H460( false, 69) ;
               getPrinter().GxAttris("Verdana", 10, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55LabelTitle2Lines, "")), 0, Gx_line+15, 552, Gx_line+53, 0+16, 0, 0, 2) ;
               getPrinter().GxDrawLine(0, Gx_line+58, 552, Gx_line+58, 1, 105, 101, 103, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+69);
            }
         }
         else
         {
            AV52LabelText = AV9WWPFormElementTitle;
            GXt_int1 = AV56Lines;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_report_calclines(context ).execute(  AV52LabelText,  "Label_entire_line", out  GXt_int1) ;
            AV56Lines = GXt_int1;
            if ( AV56Lines <= 1 )
            {
               H460( false, 26) ;
               getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52LabelText, "")), 0, Gx_line+5, 552, Gx_line+21, 0+16, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+26);
            }
            else if ( AV56Lines == 2 )
            {
               AV53LabelText2Lines = AV52LabelText;
               H460( false, 56) ;
               getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53LabelText2Lines, "")), 0, Gx_line+5, 552, Gx_line+41, 0+16, 0, 0, 2) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+56);
            }
            else
            {
               AV54LabelText5Lines = AV52LabelText;
               H460( false, 110) ;
               getPrinter().GxAttris("Verdana", 9, true, false, false, false, 0, 105, 101, 103, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54LabelText5Lines, "")), 0, Gx_line+5, 552, Gx_line+95, 0+16, 0, 0, 2) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+110);
            }
         }
      }

      protected void S131( )
      {
         /* 'PRINTGROUP' Routine */
         returnInSub = false;
         GXt_boolean2 = AV44IsInsideGroup;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_isinsidegrouporstep(context ).execute(  AV88WWPFormId,  AV90WWPFormVersionNumber,  AV85WWPFormElementParentId, out  GXt_boolean2) ;
         AV44IsInsideGroup = GXt_boolean2;
         if ( AV44IsInsideGroup )
         {
            AV72VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
            AV77WWP_DF_LabelMetadata_Style = 1;
            /* Execute user subroutine: 'PRINTLABEL' */
            S123 ();
            if (returnInSub) return;
         }
         else
         {
            AV39GroupTitle = StringUtil.Upper( AV9WWPFormElementTitle);
            H460( false, 56) ;
            getPrinter().GxDrawRect(0, Gx_line+15, 552, Gx_line+41, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 12, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39GroupTitle, "")), 20, Gx_line+18, 552, Gx_line+38, 0+16, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+56);
         }
      }

      protected void S141( )
      {
         /* 'PRINTMULTIPLE' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata(context ).execute(  AV88WWPFormId,  AV90WWPFormVersionNumber, ref  AV83WWPFormElementIdSimpleChildren) ;
         AV58MultipleDataWWPFormInstanceElementId = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P00463 */
         pr_default.execute(1, new Object[] {AV89WWPFormInstanceId, AV83WWPFormElementIdSimpleChildren});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A98WWPFormElementId = P00463_A98WWPFormElementId[0];
            A102WWPFormInstanceId = P00463_A102WWPFormInstanceId[0];
            A103WWPFormInstanceElementId = P00463_A103WWPFormInstanceElementId[0];
            AV58MultipleDataWWPFormInstanceElementId.Add(A103WWPFormInstanceElementId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( ! AV38DisplayElementsPlain && ( AV58MultipleDataWWPFormInstanceElementId.Count > 0 ) )
         {
            AV12AmountOfElementsOfGrid = (short)(AV87WWPFormElementsMultiples.Count);
            if ( AV12AmountOfElementsOfGrid > 4 )
            {
               AV38DisplayElementsPlain = true;
            }
            else
            {
               AV108GXV3 = 1;
               while ( AV108GXV3 <= AV87WWPFormElementsMultiples.Count )
               {
                  AV84WWPFormElementMultiple = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV87WWPFormElementsMultiples.Item(AV108GXV3));
                  if ( ( AV84WWPFormElementMultiple.gxTpr_Wwpformelementdatatype == 1 ) || ( AV84WWPFormElementMultiple.gxTpr_Wwpformelementdatatype == 10 ) )
                  {
                     AV38DisplayElementsPlain = true;
                     if (true) break;
                  }
                  AV108GXV3 = (int)(AV108GXV3+1);
               }
            }
         }
         AV40i = 1;
         while ( AV40i <= AV58MultipleDataWWPFormInstanceElementId.Count )
         {
            AV46j = 1;
            AV11WWPFormInstanceElementId = (short)(AV58MultipleDataWWPFormInstanceElementId.GetNumeric(AV40i));
            if ( AV38DisplayElementsPlain )
            {
               AV87WWPFormElementsMultiples = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Factory21");
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport(context ).execute(  AV10WWPFormInstance,  AV11WWPFormInstanceElementId,  AV81WWPFormElement.gxTpr_Wwpformelementid,  true, ref  AV87WWPFormElementsMultiples) ;
            }
            AV109GXV4 = 1;
            while ( AV109GXV4 <= AV87WWPFormElementsMultiples.Count )
            {
               AV84WWPFormElementMultiple = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV87WWPFormElementsMultiples.Item(AV109GXV4));
               if ( AV84WWPFormElementMultiple.gxTpr_Wwpformelementtype == 1 )
               {
                  AV82WWPFormElementId = AV84WWPFormElementMultiple.gxTpr_Wwpformelementid;
                  /* Execute user subroutine: 'PRINTITEM' */
                  S111 ();
                  if (returnInSub) return;
               }
               else if ( AV84WWPFormElementMultiple.gxTpr_Wwpformelementtype == 2 )
               {
                  AV75WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
                  AV75WWP_DF_GroupMetadata.FromJSonString(AV84WWPFormElementMultiple.gxTpr_Wwpformelementmetadata, null);
                  AV85WWPFormElementParentId = AV84WWPFormElementMultiple.gxTpr_Wwpformelementparentid;
                  AV9WWPFormElementTitle = AV84WWPFormElementMultiple.gxTpr_Wwpformelementtitle;
                  /* Execute user subroutine: 'PRINTGROUP' */
                  S131 ();
                  if (returnInSub) return;
               }
               else if ( AV84WWPFormElementMultiple.gxTpr_Wwpformelementtype == 4 )
               {
                  AV76WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
                  AV76WWP_DF_LabelMetadata.FromJSonString(AV84WWPFormElementMultiple.gxTpr_Wwpformelementmetadata, null);
                  AV72VisibleCondition = AV76WWP_DF_LabelMetadata.gxTpr_Visiblecondition;
                  AV9WWPFormElementTitle = AV84WWPFormElementMultiple.gxTpr_Wwpformelementtitle;
                  AV77WWP_DF_LabelMetadata_Style = AV76WWP_DF_LabelMetadata.gxTpr_Style;
                  /* Execute user subroutine: 'PRINTLABEL' */
                  S123 ();
                  if (returnInSub) return;
               }
               AV46j = (short)(AV46j+1);
               AV109GXV4 = (int)(AV109GXV4+1);
            }
            AV40i = (short)(AV40i+1);
         }
      }

      protected void H460( bool bFoot ,
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
                  AV96PagesFooter = StringUtil.Format( "P�gina: %1", StringUtil.LTrimStr( (decimal)(Gx_page), 6, 0), "", "", "", "", "", "", "", "");
                  getPrinter().GxDrawLine(0, Gx_line+1, 552, Gx_line+1, 2, 8, 160, 134, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96PagesFooter, "")), 0, Gx_line+7, 552, Gx_line+22, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
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
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Verdana", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         GXDecQS = "";
         gxfirstwebparm = "";
         AV86WWPFormElements = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Factory21");
         AV10WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV93DynamicFormDescription = "";
         AV92DynamicFormNumber = "";
         AV95Date = "";
         AV94User = "";
         AV61SeparatorChar = "";
         AV81WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV75WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         AV72VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV9WWPFormElementTitle = "";
         AV76WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
         AV80WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV78WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV87WWPFormElementsMultiples = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Factory21");
         P00462_A94WWPFormId = new short[1] ;
         P00462_A95WWPFormVersionNumber = new short[1] ;
         P00462_A103WWPFormInstanceElementId = new short[1] ;
         P00462_A98WWPFormElementId = new short[1] ;
         P00462_A102WWPFormInstanceId = new int[1] ;
         P00462_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         P00462_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         P00462_A106WWPFormElementDataType = new short[1] ;
         P00462_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         P00462_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         P00462_A124WWPFormElementMetadata = new string[] {""} ;
         P00462_A125WWPFormElementCaption = new short[1] ;
         P00462_A117WWPFormElementTitle = new string[] {""} ;
         P00462_A109WWPFormInstanceElemChar = new string[] {""} ;
         P00462_n109WWPFormInstanceElemChar = new bool[] {false} ;
         P00462_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         P00462_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         P00462_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         P00462_n108WWPFormInstanceElemDate = new bool[] {false} ;
         P00462_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         P00462_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         P00462_A111WWPFormInstanceElemBlob = new string[] {""} ;
         P00462_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         A113WWPFormInstanceElemBlobFileName = "";
         A111WWPFormInstanceElemBlob = "";
         A111WWPFormInstanceElemBlob_Filename = "";
         A112WWPFormInstanceElemBlobFileType = "";
         A111WWPFormInstanceElemBlob_Filetype = "";
         A124WWPFormElementMetadata = "";
         A117WWPFormElementTitle = "";
         A109WWPFormInstanceElemChar = "";
         A108WWPFormInstanceElemDate = DateTime.MinValue;
         A115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         AV37DataTitle = "";
         AV18BooleanTitle = "";
         AV100Booleantitle_GXI = "";
         AV73WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV19BooleanTitle_ControlTitle = "";
         AV14BooleanLabel = "";
         AV101Booleanlabel_GXI = "";
         AV49Label2 = "";
         AV15BooleanLabel_ControlTitle = "";
         AV14BooleanLabel = "";
         sImgUrl = "";
         AV16BooleanNoLabel = "";
         AV102Booleannolabel_GXI = "";
         AV17BooleanNoLabel_ControlTitle = "";
         AV16BooleanNoLabel = "";
         AV74WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV60SelectedOptions = new GxSimpleCollection<string>();
         AV59SelectedOption = "";
         AV79WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV43ImageTitle = "";
         AV104Imagetitle_GXI = "";
         AV41ImageLabel = "";
         AV105Imagelabel_GXI = "";
         AV48Label1 = "";
         AV41ImageLabel = "";
         AV42ImageNoLabel = "";
         AV106Imagenolabel_GXI = "";
         AV42ImageNoLabel = "";
         AV31DataLabel = "";
         AV47Label = "";
         AV32DataLabel2Lines = "";
         AV50Label2Lines = "";
         AV33DataLabel5Lines = "";
         AV51Label5Lines = "";
         AV34DataNoLabel = "";
         AV35DataNoLabel2Lines = "";
         AV36DataNoLabel5Lines = "";
         AV66Title_OneColumn = "";
         AV70Title_TwoColumns1 = "";
         AV67Title_ThreeColumns1 = "";
         AV62Title_FourColumns1 = "";
         AV25Data_OneColumn = "";
         AV29Data_TwoColumns1 = "";
         AV26Data_ThreeColumns1 = "";
         AV21Data_FourColumns1 = "";
         AV71Title_TwoColumns2 = "";
         AV68Title_ThreeColumns2 = "";
         AV63Title_FourColumns2 = "";
         AV30Data_TwoColumns2 = "";
         AV27Data_ThreeColumns2 = "";
         AV22Data_FourColumns2 = "";
         AV69Title_ThreeColumns3 = "";
         AV64Title_FourColumns3 = "";
         AV28Data_ThreeColumns3 = "";
         AV23Data_FourColumns3 = "";
         AV65Title_FourColumns4 = "";
         AV24Data_FourColumns4 = "";
         AV8LabelTitle = "";
         AV55LabelTitle2Lines = "";
         AV52LabelText = "";
         AV53LabelText2Lines = "";
         AV54LabelText5Lines = "";
         AV39GroupTitle = "";
         AV58MultipleDataWWPFormInstanceElementId = new GxSimpleCollection<short>();
         P00463_A98WWPFormElementId = new short[1] ;
         P00463_A102WWPFormInstanceId = new int[1] ;
         P00463_A103WWPFormInstanceElementId = new short[1] ;
         AV84WWPFormElementMultiple = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV96PagesFooter = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_report__default(),
            new Object[][] {
                new Object[] {
               P00462_A94WWPFormId, P00462_A95WWPFormVersionNumber, P00462_A103WWPFormInstanceElementId, P00462_A98WWPFormElementId, P00462_A102WWPFormInstanceId, P00462_A113WWPFormInstanceElemBlobFileName, P00462_A112WWPFormInstanceElemBlobFileType, P00462_A106WWPFormElementDataType, P00462_A114WWPFormInstanceElemBoolean, P00462_n114WWPFormInstanceElemBoolean,
               P00462_A124WWPFormElementMetadata, P00462_A125WWPFormElementCaption, P00462_A117WWPFormElementTitle, P00462_A109WWPFormInstanceElemChar, P00462_n109WWPFormInstanceElemChar, P00462_A110WWPFormInstanceElemNumeric, P00462_n110WWPFormInstanceElemNumeric, P00462_A108WWPFormInstanceElemDate, P00462_n108WWPFormInstanceElemDate, P00462_A115WWPFormInstanceElemDateTime,
               P00462_n115WWPFormInstanceElemDateTime, P00462_A111WWPFormInstanceElemBlob, P00462_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               P00463_A98WWPFormElementId, P00463_A102WWPFormInstanceId, P00463_A103WWPFormInstanceElementId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV88WWPFormId ;
      private short AV90WWPFormVersionNumber ;
      private short AV11WWPFormInstanceElementId ;
      private short AV82WWPFormElementId ;
      private short AV85WWPFormElementParentId ;
      private short AV77WWP_DF_LabelMetadata_Style ;
      private short AV83WWPFormElementIdSimpleChildren ;
      private short A94WWPFormId ;
      private short A95WWPFormVersionNumber ;
      private short A103WWPFormInstanceElementId ;
      private short A98WWPFormElementId ;
      private short A106WWPFormElementDataType ;
      private short A125WWPFormElementCaption ;
      private short AV46j ;
      private short AV56Lines ;
      private short AV57Lines2 ;
      private short AV20column ;
      private short AV40i ;
      private short AV12AmountOfElementsOfGrid ;
      private short GXt_int1 ;
      private int AV89WWPFormInstanceId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV98GXV1 ;
      private int A102WWPFormInstanceId ;
      private int AV103GXV2 ;
      private int AV108GXV3 ;
      private int AV109GXV4 ;
      private decimal AV13AuxNum ;
      private decimal A110WWPFormInstanceElemNumeric ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string A111WWPFormInstanceElemBlob_Filename ;
      private string A111WWPFormInstanceElemBlob_Filetype ;
      private string sImgUrl ;
      private DateTime A115WWPFormInstanceElemDateTime ;
      private DateTime A108WWPFormInstanceElemDate ;
      private bool entryPointCalled ;
      private bool AV38DisplayElementsPlain ;
      private bool returnInSub ;
      private bool AV91PrintingPlainedGrid ;
      private bool A114WWPFormInstanceElemBoolean ;
      private bool n114WWPFormInstanceElemBoolean ;
      private bool n109WWPFormInstanceElemChar ;
      private bool n110WWPFormInstanceElemNumeric ;
      private bool n108WWPFormInstanceElemDate ;
      private bool n115WWPFormInstanceElemDateTime ;
      private bool n111WWPFormInstanceElemBlob ;
      private bool AV45ItemPrited ;
      private bool AV44IsInsideGroup ;
      private bool GXt_boolean2 ;
      private string AV9WWPFormElementTitle ;
      private string A124WWPFormElementMetadata ;
      private string A117WWPFormElementTitle ;
      private string A109WWPFormInstanceElemChar ;
      private string AV93DynamicFormDescription ;
      private string AV92DynamicFormNumber ;
      private string AV95Date ;
      private string AV94User ;
      private string AV61SeparatorChar ;
      private string A113WWPFormInstanceElemBlobFileName ;
      private string A112WWPFormInstanceElemBlobFileType ;
      private string AV37DataTitle ;
      private string AV100Booleantitle_GXI ;
      private string AV19BooleanTitle_ControlTitle ;
      private string AV101Booleanlabel_GXI ;
      private string AV49Label2 ;
      private string AV15BooleanLabel_ControlTitle ;
      private string AV102Booleannolabel_GXI ;
      private string AV17BooleanNoLabel_ControlTitle ;
      private string AV59SelectedOption ;
      private string AV104Imagetitle_GXI ;
      private string AV105Imagelabel_GXI ;
      private string AV48Label1 ;
      private string AV106Imagenolabel_GXI ;
      private string AV31DataLabel ;
      private string AV47Label ;
      private string AV32DataLabel2Lines ;
      private string AV50Label2Lines ;
      private string AV33DataLabel5Lines ;
      private string AV51Label5Lines ;
      private string AV34DataNoLabel ;
      private string AV35DataNoLabel2Lines ;
      private string AV36DataNoLabel5Lines ;
      private string AV66Title_OneColumn ;
      private string AV70Title_TwoColumns1 ;
      private string AV67Title_ThreeColumns1 ;
      private string AV62Title_FourColumns1 ;
      private string AV25Data_OneColumn ;
      private string AV29Data_TwoColumns1 ;
      private string AV26Data_ThreeColumns1 ;
      private string AV21Data_FourColumns1 ;
      private string AV71Title_TwoColumns2 ;
      private string AV68Title_ThreeColumns2 ;
      private string AV63Title_FourColumns2 ;
      private string AV30Data_TwoColumns2 ;
      private string AV27Data_ThreeColumns2 ;
      private string AV22Data_FourColumns2 ;
      private string AV69Title_ThreeColumns3 ;
      private string AV64Title_FourColumns3 ;
      private string AV28Data_ThreeColumns3 ;
      private string AV23Data_FourColumns3 ;
      private string AV65Title_FourColumns4 ;
      private string AV24Data_FourColumns4 ;
      private string AV8LabelTitle ;
      private string AV55LabelTitle2Lines ;
      private string AV52LabelText ;
      private string AV53LabelText2Lines ;
      private string AV54LabelText5Lines ;
      private string AV39GroupTitle ;
      private string AV96PagesFooter ;
      private string AV18BooleanTitle ;
      private string AV14BooleanLabel ;
      private string Booleanlabel ;
      private string AV16BooleanNoLabel ;
      private string Booleannolabel ;
      private string AV43ImageTitle ;
      private string AV41ImageLabel ;
      private string Imagelabel ;
      private string AV42ImageNoLabel ;
      private string Imagenolabel ;
      private string A111WWPFormInstanceElemBlob ;
      private IGxDataStore dsDefault ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> AV86WWPFormElements ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV10WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV81WWPFormElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV75WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV72VisibleCondition ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata AV76WWP_DF_LabelMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV80WWP_DF_StepMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV78WWP_DF_MultipleMetadata ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> AV87WWPFormElementsMultiples ;
      private IDataStoreProvider pr_default ;
      private short[] P00462_A94WWPFormId ;
      private short[] P00462_A95WWPFormVersionNumber ;
      private short[] P00462_A103WWPFormInstanceElementId ;
      private short[] P00462_A98WWPFormElementId ;
      private int[] P00462_A102WWPFormInstanceId ;
      private string[] P00462_A113WWPFormInstanceElemBlobFileName ;
      private string[] P00462_A112WWPFormInstanceElemBlobFileType ;
      private short[] P00462_A106WWPFormElementDataType ;
      private bool[] P00462_A114WWPFormInstanceElemBoolean ;
      private bool[] P00462_n114WWPFormInstanceElemBoolean ;
      private string[] P00462_A124WWPFormElementMetadata ;
      private short[] P00462_A125WWPFormElementCaption ;
      private string[] P00462_A117WWPFormElementTitle ;
      private string[] P00462_A109WWPFormInstanceElemChar ;
      private bool[] P00462_n109WWPFormInstanceElemChar ;
      private decimal[] P00462_A110WWPFormInstanceElemNumeric ;
      private bool[] P00462_n110WWPFormInstanceElemNumeric ;
      private DateTime[] P00462_A108WWPFormInstanceElemDate ;
      private bool[] P00462_n108WWPFormInstanceElemDate ;
      private DateTime[] P00462_A115WWPFormInstanceElemDateTime ;
      private bool[] P00462_n115WWPFormInstanceElemDateTime ;
      private string[] P00462_A111WWPFormInstanceElemBlob ;
      private bool[] P00462_n111WWPFormInstanceElemBlob ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV73WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV74WWP_DF_CharMetadata ;
      private GxSimpleCollection<string> AV60SelectedOptions ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV79WWP_DF_NumericMetadata ;
      private GxSimpleCollection<short> AV58MultipleDataWWPFormInstanceElementId ;
      private short[] P00463_A98WWPFormElementId ;
      private int[] P00463_A102WWPFormInstanceId ;
      private short[] P00463_A103WWPFormInstanceElementId ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV84WWPFormElementMultiple ;
   }

   public class wwp_df_report__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00462;
          prmP00462 = new Object[] {
          new ParDef("AV89WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("AV82WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("AV11WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmP00463;
          prmP00463 = new Object[] {
          new ParDef("AV89WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("AV83WWPFormElementIdSimpleChildren",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00462", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceElementId, T1.WWPFormElementId, T1.WWPFormInstanceId, T1.WWPFormInstanceElemBlobFileName, T1.WWPFormInstanceElemBlobFileType, T3.WWPFormElementDataType, T1.WWPFormInstanceElemBoolean, T3.WWPFormElementMetadata, T3.WWPFormElementCaption, T3.WWPFormElementTitle, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 INNER JOIN WWP_FormInstance T2 ON T2.WWPFormInstanceId = T1.WWPFormInstanceId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T1.WWPFormElementId) WHERE T1.WWPFormInstanceId = :AV89WWPFormInstanceId and T1.WWPFormElementId = :AV82WWPFormElementId and T1.WWPFormInstanceElementId = :AV11WWPFormInstanceElementId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00462,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00463", "SELECT WWPFormElementId, WWPFormInstanceId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :AV89WWPFormInstanceId and WWPFormElementId = :AV83WWPFormElementIdSimpleChildren ORDER BY WWPFormInstanceId, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00463,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(12);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((string[]) buf[21])[0] = rslt.getBLOBFile(17, rslt.getVarchar(7), rslt.getVarchar(6));
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
