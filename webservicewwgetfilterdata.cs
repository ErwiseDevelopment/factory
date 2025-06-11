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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class webservicewwgetfilterdata : GXProcedure
   {
      public webservicewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webservicewwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_WEBSERVICEENDPOINTDECRYPTED") == 0 )
         {
            /* Execute user subroutine: 'LOADWEBSERVICEENDPOINTDECRYPTEDOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_WEBSERVICEAUTHTIPODECRYPTED") == 0 )
         {
            /* Execute user subroutine: 'LOADWEBSERVICEAUTHTIPODECRYPTEDOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("WebServiceWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WebServiceWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WebServiceWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWEBSERVICETIPODMWS_SEL") == 0 )
            {
               AV10TFWebServiceTipoDmWS_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV11TFWebServiceTipoDmWS_Sels.FromJSonString(AV10TFWebServiceTipoDmWS_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEENDPOINTDECRYPTED") == 0 )
            {
               AV12TFWebServiceEndPointDecrypted = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEENDPOINTDECRYPTED_SEL") == 0 )
            {
               AV13TFWebServiceEndPointDecrypted_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEAUTHTIPODECRYPTED") == 0 )
            {
               AV14TFWebServiceAuthTipoDecrypted = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEAUTHTIPODECRYPTED_SEL") == 0 )
            {
               AV15TFWebServiceAuthTipoDecrypted_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV39DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "WEBSERVICETIPODMWS") == 0 )
            {
               AV40WebServiceTipoDmWS1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "WEBSERVICETIPODMWS") == 0 )
               {
                  AV43WebServiceTipoDmWS2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV44DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV45DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "WEBSERVICETIPODMWS") == 0 )
                  {
                     AV46WebServiceTipoDmWS3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADWEBSERVICEENDPOINTDECRYPTEDOPTIONS' Routine */
         returnInSub = false;
         AV12TFWebServiceEndPointDecrypted = AV16SearchTxt;
         AV13TFWebServiceEndPointDecrypted_Sel = "";
         AV49Webservicewwds_1_filterfulltext = AV38FilterFullText;
         AV50Webservicewwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV51Webservicewwds_3_webservicetipodmws1 = AV40WebServiceTipoDmWS1;
         AV52Webservicewwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV53Webservicewwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV54Webservicewwds_6_webservicetipodmws2 = AV43WebServiceTipoDmWS2;
         AV55Webservicewwds_7_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV56Webservicewwds_8_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV57Webservicewwds_9_webservicetipodmws3 = AV46WebServiceTipoDmWS3;
         AV58Webservicewwds_10_tfwebservicetipodmws_sels = AV11TFWebServiceTipoDmWS_Sels;
         AV59Webservicewwds_11_tfwebserviceendpointdecrypted = AV12TFWebServiceEndPointDecrypted;
         AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV13TFWebServiceEndPointDecrypted_Sel;
         AV61Webservicewwds_13_tfwebserviceauthtipodecrypted = AV14TFWebServiceAuthTipoDecrypted;
         AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV15TFWebServiceAuthTipoDecrypted_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A657WebServiceTipoDmWS ,
                                              AV58Webservicewwds_10_tfwebservicetipodmws_sels ,
                                              AV50Webservicewwds_2_dynamicfiltersselector1 ,
                                              AV51Webservicewwds_3_webservicetipodmws1 ,
                                              AV52Webservicewwds_4_dynamicfiltersenabled2 ,
                                              AV53Webservicewwds_5_dynamicfiltersselector2 ,
                                              AV54Webservicewwds_6_webservicetipodmws2 ,
                                              AV55Webservicewwds_7_dynamicfiltersenabled3 ,
                                              AV56Webservicewwds_8_dynamicfiltersselector3 ,
                                              AV57Webservicewwds_9_webservicetipodmws3 ,
                                              AV58Webservicewwds_10_tfwebservicetipodmws_sels.Count ,
                                              AV49Webservicewwds_1_filterfulltext ,
                                              A1061WebServiceEndPointDecrypted ,
                                              A1062WebServiceAuthTipoDecrypted ,
                                              AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                              AV59Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                              AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                              AV61Webservicewwds_13_tfwebserviceauthtipodecrypted } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00FC2 */
         pr_default.execute(0, new Object[] {AV51Webservicewwds_3_webservicetipodmws1, AV54Webservicewwds_6_webservicetipodmws2, AV57Webservicewwds_9_webservicetipodmws3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A657WebServiceTipoDmWS = P00FC2_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = P00FC2_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = P00FC2_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = P00FC2_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = P00FC2_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = P00FC2_n659WebServiceAuthTipo[0];
            A656WebServiceId = P00FC2_A656WebServiceId[0];
            GXt_char1 = A1062WebServiceAuthTipoDecrypted;
            new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
            A1062WebServiceAuthTipoDecrypted = GXt_char1;
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Webservicewwds_13_tfwebserviceauthtipodecrypted)) ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( AV61Webservicewwds_13_tfwebserviceauthtipodecrypted , 2097152 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ! ( StringUtil.StrCmp(AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1062WebServiceAuthTipoDecrypted, AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1062WebServiceAuthTipoDecrypted)) ) )
                  {
                     GXt_char1 = A1061WebServiceEndPointDecrypted;
                     new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
                     A1061WebServiceEndPointDecrypted = GXt_char1;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Webservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( "serasa_auth" , StringUtil.PadR( "%" + StringUtil.Lower( AV49Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) ) || ( StringUtil.Like( "serasa_proposta_pf" , StringUtil.PadR( "%" + StringUtil.Lower( AV49Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) ) || ( StringUtil.Like( "santander" , StringUtil.PadR( "%" + StringUtil.Lower( AV49Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Santander") == 0 ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( "%" + AV49Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( "%" + AV49Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
                     {
                        if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Webservicewwds_11_tfwebserviceendpointdecrypted)) ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( AV59Webservicewwds_11_tfwebserviceendpointdecrypted , 2097152 , "%"),  ' ' ) ) )
                        {
                           if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ! ( StringUtil.StrCmp(AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1061WebServiceEndPointDecrypted, AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel) == 0 ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1061WebServiceEndPointDecrypted)) ) )
                              {
                                 AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1061WebServiceEndPointDecrypted)) ? "<#Empty#>" : A1061WebServiceEndPointDecrypted);
                                 AV20InsertIndex = 1;
                                 while ( ( StringUtil.StrCmp(AV21Option, "<#Empty#>") != 0 ) && ( AV20InsertIndex <= AV22Options.Count ) && ( ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), AV21Option) < 0 ) || ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), "<#Empty#>") == 0 ) ) )
                                 {
                                    AV20InsertIndex = (int)(AV20InsertIndex+1);
                                 }
                                 if ( ( AV20InsertIndex <= AV22Options.Count ) && ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), AV21Option) == 0 ) )
                                 {
                                    AV26count = (long)(Math.Round(NumberUtil.Val( ((string)AV25OptionIndexes.Item(AV20InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                    AV26count = (long)(AV26count+1);
                                    AV25OptionIndexes.RemoveItem(AV20InsertIndex);
                                    AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), AV20InsertIndex);
                                 }
                                 else
                                 {
                                    AV22Options.Add(AV21Option, AV20InsertIndex);
                                    AV25OptionIndexes.Add("1", AV20InsertIndex);
                                 }
                                 if ( AV22Options.Count == AV17SkipItems + 11 )
                                 {
                                    AV22Options.RemoveItem(AV22Options.Count);
                                    AV25OptionIndexes.RemoveItem(AV25OptionIndexes.Count);
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         while ( AV17SkipItems > 0 )
         {
            AV22Options.RemoveItem(1);
            AV25OptionIndexes.RemoveItem(1);
            AV17SkipItems = (short)(AV17SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADWEBSERVICEAUTHTIPODECRYPTEDOPTIONS' Routine */
         returnInSub = false;
         AV14TFWebServiceAuthTipoDecrypted = AV16SearchTxt;
         AV15TFWebServiceAuthTipoDecrypted_Sel = "";
         AV49Webservicewwds_1_filterfulltext = AV38FilterFullText;
         AV50Webservicewwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV51Webservicewwds_3_webservicetipodmws1 = AV40WebServiceTipoDmWS1;
         AV52Webservicewwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV53Webservicewwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV54Webservicewwds_6_webservicetipodmws2 = AV43WebServiceTipoDmWS2;
         AV55Webservicewwds_7_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV56Webservicewwds_8_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV57Webservicewwds_9_webservicetipodmws3 = AV46WebServiceTipoDmWS3;
         AV58Webservicewwds_10_tfwebservicetipodmws_sels = AV11TFWebServiceTipoDmWS_Sels;
         AV59Webservicewwds_11_tfwebserviceendpointdecrypted = AV12TFWebServiceEndPointDecrypted;
         AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV13TFWebServiceEndPointDecrypted_Sel;
         AV61Webservicewwds_13_tfwebserviceauthtipodecrypted = AV14TFWebServiceAuthTipoDecrypted;
         AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV15TFWebServiceAuthTipoDecrypted_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A657WebServiceTipoDmWS ,
                                              AV58Webservicewwds_10_tfwebservicetipodmws_sels ,
                                              AV50Webservicewwds_2_dynamicfiltersselector1 ,
                                              AV51Webservicewwds_3_webservicetipodmws1 ,
                                              AV52Webservicewwds_4_dynamicfiltersenabled2 ,
                                              AV53Webservicewwds_5_dynamicfiltersselector2 ,
                                              AV54Webservicewwds_6_webservicetipodmws2 ,
                                              AV55Webservicewwds_7_dynamicfiltersenabled3 ,
                                              AV56Webservicewwds_8_dynamicfiltersselector3 ,
                                              AV57Webservicewwds_9_webservicetipodmws3 ,
                                              AV58Webservicewwds_10_tfwebservicetipodmws_sels.Count ,
                                              AV49Webservicewwds_1_filterfulltext ,
                                              A1061WebServiceEndPointDecrypted ,
                                              A1062WebServiceAuthTipoDecrypted ,
                                              AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                              AV59Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                              AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                              AV61Webservicewwds_13_tfwebserviceauthtipodecrypted } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00FC3 */
         pr_default.execute(1, new Object[] {AV51Webservicewwds_3_webservicetipodmws1, AV54Webservicewwds_6_webservicetipodmws2, AV57Webservicewwds_9_webservicetipodmws3});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A657WebServiceTipoDmWS = P00FC3_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = P00FC3_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = P00FC3_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = P00FC3_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = P00FC3_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = P00FC3_n659WebServiceAuthTipo[0];
            A656WebServiceId = P00FC3_A656WebServiceId[0];
            GXt_char1 = A1062WebServiceAuthTipoDecrypted;
            new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
            A1062WebServiceAuthTipoDecrypted = GXt_char1;
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Webservicewwds_13_tfwebserviceauthtipodecrypted)) ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( AV61Webservicewwds_13_tfwebserviceauthtipodecrypted , 2097152 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ! ( StringUtil.StrCmp(AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1062WebServiceAuthTipoDecrypted, AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1062WebServiceAuthTipoDecrypted)) ) )
                  {
                     GXt_char1 = A1061WebServiceEndPointDecrypted;
                     new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
                     A1061WebServiceEndPointDecrypted = GXt_char1;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Webservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( "serasa_auth" , StringUtil.PadR( "%" + StringUtil.Lower( AV49Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) ) || ( StringUtil.Like( "serasa_proposta_pf" , StringUtil.PadR( "%" + StringUtil.Lower( AV49Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) ) || ( StringUtil.Like( "santander" , StringUtil.PadR( "%" + StringUtil.Lower( AV49Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Santander") == 0 ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( "%" + AV49Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( "%" + AV49Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
                     {
                        if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Webservicewwds_11_tfwebserviceendpointdecrypted)) ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( AV59Webservicewwds_11_tfwebserviceendpointdecrypted , 2097152 , "%"),  ' ' ) ) )
                        {
                           if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ! ( StringUtil.StrCmp(AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1061WebServiceEndPointDecrypted, AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel) == 0 ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1061WebServiceEndPointDecrypted)) ) )
                              {
                                 AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1062WebServiceAuthTipoDecrypted)) ? "<#Empty#>" : A1062WebServiceAuthTipoDecrypted);
                                 AV20InsertIndex = 1;
                                 while ( ( StringUtil.StrCmp(AV21Option, "<#Empty#>") != 0 ) && ( AV20InsertIndex <= AV22Options.Count ) && ( ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), AV21Option) < 0 ) || ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), "<#Empty#>") == 0 ) ) )
                                 {
                                    AV20InsertIndex = (int)(AV20InsertIndex+1);
                                 }
                                 if ( ( AV20InsertIndex <= AV22Options.Count ) && ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), AV21Option) == 0 ) )
                                 {
                                    AV26count = (long)(Math.Round(NumberUtil.Val( ((string)AV25OptionIndexes.Item(AV20InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                    AV26count = (long)(AV26count+1);
                                    AV25OptionIndexes.RemoveItem(AV20InsertIndex);
                                    AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), AV20InsertIndex);
                                 }
                                 else
                                 {
                                    AV22Options.Add(AV21Option, AV20InsertIndex);
                                    AV25OptionIndexes.Add("1", AV20InsertIndex);
                                 }
                                 if ( AV22Options.Count == AV17SkipItems + 11 )
                                 {
                                    AV22Options.RemoveItem(AV22Options.Count);
                                    AV25OptionIndexes.RemoveItem(AV25OptionIndexes.Count);
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV17SkipItems > 0 )
         {
            AV22Options.RemoveItem(1);
            AV25OptionIndexes.RemoveItem(1);
            AV17SkipItems = (short)(AV17SkipItems-1);
         }
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV10TFWebServiceTipoDmWS_SelsJson = "";
         AV11TFWebServiceTipoDmWS_Sels = new GxSimpleCollection<string>();
         AV12TFWebServiceEndPointDecrypted = "";
         AV13TFWebServiceEndPointDecrypted_Sel = "";
         AV14TFWebServiceAuthTipoDecrypted = "";
         AV15TFWebServiceAuthTipoDecrypted_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39DynamicFiltersSelector1 = "";
         AV40WebServiceTipoDmWS1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV43WebServiceTipoDmWS2 = "";
         AV45DynamicFiltersSelector3 = "";
         AV46WebServiceTipoDmWS3 = "";
         AV49Webservicewwds_1_filterfulltext = "";
         AV50Webservicewwds_2_dynamicfiltersselector1 = "";
         AV51Webservicewwds_3_webservicetipodmws1 = "";
         AV53Webservicewwds_5_dynamicfiltersselector2 = "";
         AV54Webservicewwds_6_webservicetipodmws2 = "";
         AV56Webservicewwds_8_dynamicfiltersselector3 = "";
         AV57Webservicewwds_9_webservicetipodmws3 = "";
         AV58Webservicewwds_10_tfwebservicetipodmws_sels = new GxSimpleCollection<string>();
         AV59Webservicewwds_11_tfwebserviceendpointdecrypted = "";
         AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel = "";
         AV61Webservicewwds_13_tfwebserviceauthtipodecrypted = "";
         AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = "";
         A657WebServiceTipoDmWS = "";
         A1061WebServiceEndPointDecrypted = "";
         A1062WebServiceAuthTipoDecrypted = "";
         P00FC2_A657WebServiceTipoDmWS = new string[] {""} ;
         P00FC2_n657WebServiceTipoDmWS = new bool[] {false} ;
         P00FC2_A658WebServiceEndPoint = new string[] {""} ;
         P00FC2_n658WebServiceEndPoint = new bool[] {false} ;
         P00FC2_A659WebServiceAuthTipo = new string[] {""} ;
         P00FC2_n659WebServiceAuthTipo = new bool[] {false} ;
         P00FC2_A656WebServiceId = new int[1] ;
         A658WebServiceEndPoint = "";
         A659WebServiceAuthTipo = "";
         AV21Option = "";
         P00FC3_A657WebServiceTipoDmWS = new string[] {""} ;
         P00FC3_n657WebServiceTipoDmWS = new bool[] {false} ;
         P00FC3_A658WebServiceEndPoint = new string[] {""} ;
         P00FC3_n658WebServiceEndPoint = new bool[] {false} ;
         P00FC3_A659WebServiceAuthTipo = new string[] {""} ;
         P00FC3_n659WebServiceAuthTipo = new bool[] {false} ;
         P00FC3_A656WebServiceId = new int[1] ;
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webservicewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00FC2_A657WebServiceTipoDmWS, P00FC2_n657WebServiceTipoDmWS, P00FC2_A658WebServiceEndPoint, P00FC2_n658WebServiceEndPoint, P00FC2_A659WebServiceAuthTipo, P00FC2_n659WebServiceAuthTipo, P00FC2_A656WebServiceId
               }
               , new Object[] {
               P00FC3_A657WebServiceTipoDmWS, P00FC3_n657WebServiceTipoDmWS, P00FC3_A658WebServiceEndPoint, P00FC3_n658WebServiceEndPoint, P00FC3_A659WebServiceAuthTipo, P00FC3_n659WebServiceAuthTipo, P00FC3_A656WebServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private int AV47GXV1 ;
      private int AV58Webservicewwds_10_tfwebservicetipodmws_sels_Count ;
      private int A656WebServiceId ;
      private int AV20InsertIndex ;
      private long AV26count ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool AV52Webservicewwds_4_dynamicfiltersenabled2 ;
      private bool AV55Webservicewwds_7_dynamicfiltersenabled3 ;
      private bool n657WebServiceTipoDmWS ;
      private bool n658WebServiceEndPoint ;
      private bool n659WebServiceAuthTipo ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV10TFWebServiceTipoDmWS_SelsJson ;
      private string A1061WebServiceEndPointDecrypted ;
      private string A1062WebServiceAuthTipoDecrypted ;
      private string A658WebServiceEndPoint ;
      private string A659WebServiceAuthTipo ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV12TFWebServiceEndPointDecrypted ;
      private string AV13TFWebServiceEndPointDecrypted_Sel ;
      private string AV14TFWebServiceAuthTipoDecrypted ;
      private string AV15TFWebServiceAuthTipoDecrypted_Sel ;
      private string AV39DynamicFiltersSelector1 ;
      private string AV40WebServiceTipoDmWS1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV43WebServiceTipoDmWS2 ;
      private string AV45DynamicFiltersSelector3 ;
      private string AV46WebServiceTipoDmWS3 ;
      private string AV49Webservicewwds_1_filterfulltext ;
      private string AV50Webservicewwds_2_dynamicfiltersselector1 ;
      private string AV51Webservicewwds_3_webservicetipodmws1 ;
      private string AV53Webservicewwds_5_dynamicfiltersselector2 ;
      private string AV54Webservicewwds_6_webservicetipodmws2 ;
      private string AV56Webservicewwds_8_dynamicfiltersselector3 ;
      private string AV57Webservicewwds_9_webservicetipodmws3 ;
      private string AV59Webservicewwds_11_tfwebserviceendpointdecrypted ;
      private string AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel ;
      private string AV61Webservicewwds_13_tfwebserviceauthtipodecrypted ;
      private string AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ;
      private string A657WebServiceTipoDmWS ;
      private string AV21Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GxSimpleCollection<string> AV11TFWebServiceTipoDmWS_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV58Webservicewwds_10_tfwebservicetipodmws_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00FC2_A657WebServiceTipoDmWS ;
      private bool[] P00FC2_n657WebServiceTipoDmWS ;
      private string[] P00FC2_A658WebServiceEndPoint ;
      private bool[] P00FC2_n658WebServiceEndPoint ;
      private string[] P00FC2_A659WebServiceAuthTipo ;
      private bool[] P00FC2_n659WebServiceAuthTipo ;
      private int[] P00FC2_A656WebServiceId ;
      private string[] P00FC3_A657WebServiceTipoDmWS ;
      private bool[] P00FC3_n657WebServiceTipoDmWS ;
      private string[] P00FC3_A658WebServiceEndPoint ;
      private bool[] P00FC3_n658WebServiceEndPoint ;
      private string[] P00FC3_A659WebServiceAuthTipo ;
      private bool[] P00FC3_n659WebServiceAuthTipo ;
      private int[] P00FC3_A656WebServiceId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class webservicewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FC2( IGxContext context ,
                                             string A657WebServiceTipoDmWS ,
                                             GxSimpleCollection<string> AV58Webservicewwds_10_tfwebservicetipodmws_sels ,
                                             string AV50Webservicewwds_2_dynamicfiltersselector1 ,
                                             string AV51Webservicewwds_3_webservicetipodmws1 ,
                                             bool AV52Webservicewwds_4_dynamicfiltersenabled2 ,
                                             string AV53Webservicewwds_5_dynamicfiltersselector2 ,
                                             string AV54Webservicewwds_6_webservicetipodmws2 ,
                                             bool AV55Webservicewwds_7_dynamicfiltersenabled3 ,
                                             string AV56Webservicewwds_8_dynamicfiltersselector3 ,
                                             string AV57Webservicewwds_9_webservicetipodmws3 ,
                                             int AV58Webservicewwds_10_tfwebservicetipodmws_sels_Count ,
                                             string AV49Webservicewwds_1_filterfulltext ,
                                             string A1061WebServiceEndPointDecrypted ,
                                             string A1062WebServiceAuthTipoDecrypted ,
                                             string AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                             string AV59Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                             string AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                             string AV61Webservicewwds_13_tfwebserviceauthtipodecrypted )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceId FROM WebService";
         if ( ( StringUtil.StrCmp(AV50Webservicewwds_2_dynamicfiltersselector1, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Webservicewwds_3_webservicetipodmws1)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV51Webservicewwds_3_webservicetipodmws1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV52Webservicewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Webservicewwds_5_dynamicfiltersselector2, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Webservicewwds_6_webservicetipodmws2)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV54Webservicewwds_6_webservicetipodmws2))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV55Webservicewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Webservicewwds_8_dynamicfiltersselector3, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Webservicewwds_9_webservicetipodmws3)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV57Webservicewwds_9_webservicetipodmws3))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV58Webservicewwds_10_tfwebservicetipodmws_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58Webservicewwds_10_tfwebservicetipodmws_sels, "WebServiceTipoDmWS IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WebServiceId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00FC3( IGxContext context ,
                                             string A657WebServiceTipoDmWS ,
                                             GxSimpleCollection<string> AV58Webservicewwds_10_tfwebservicetipodmws_sels ,
                                             string AV50Webservicewwds_2_dynamicfiltersselector1 ,
                                             string AV51Webservicewwds_3_webservicetipodmws1 ,
                                             bool AV52Webservicewwds_4_dynamicfiltersenabled2 ,
                                             string AV53Webservicewwds_5_dynamicfiltersselector2 ,
                                             string AV54Webservicewwds_6_webservicetipodmws2 ,
                                             bool AV55Webservicewwds_7_dynamicfiltersenabled3 ,
                                             string AV56Webservicewwds_8_dynamicfiltersselector3 ,
                                             string AV57Webservicewwds_9_webservicetipodmws3 ,
                                             int AV58Webservicewwds_10_tfwebservicetipodmws_sels_Count ,
                                             string AV49Webservicewwds_1_filterfulltext ,
                                             string A1061WebServiceEndPointDecrypted ,
                                             string A1062WebServiceAuthTipoDecrypted ,
                                             string AV60Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                             string AV59Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                             string AV62Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                             string AV61Webservicewwds_13_tfwebserviceauthtipodecrypted )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceId FROM WebService";
         if ( ( StringUtil.StrCmp(AV50Webservicewwds_2_dynamicfiltersselector1, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Webservicewwds_3_webservicetipodmws1)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV51Webservicewwds_3_webservicetipodmws1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV52Webservicewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Webservicewwds_5_dynamicfiltersselector2, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Webservicewwds_6_webservicetipodmws2)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV54Webservicewwds_6_webservicetipodmws2))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV55Webservicewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Webservicewwds_8_dynamicfiltersselector3, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Webservicewwds_9_webservicetipodmws3)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV57Webservicewwds_9_webservicetipodmws3))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV58Webservicewwds_10_tfwebservicetipodmws_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58Webservicewwds_10_tfwebservicetipodmws_sels, "WebServiceTipoDmWS IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WebServiceId";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00FC2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P00FC3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00FC2;
          prmP00FC2 = new Object[] {
          new ParDef("AV51Webservicewwds_3_webservicetipodmws1",GXType.VarChar,40,0) ,
          new ParDef("AV54Webservicewwds_6_webservicetipodmws2",GXType.VarChar,40,0) ,
          new ParDef("AV57Webservicewwds_9_webservicetipodmws3",GXType.VarChar,40,0)
          };
          Object[] prmP00FC3;
          prmP00FC3 = new Object[] {
          new ParDef("AV51Webservicewwds_3_webservicetipodmws1",GXType.VarChar,40,0) ,
          new ParDef("AV54Webservicewwds_6_webservicetipodmws2",GXType.VarChar,40,0) ,
          new ParDef("AV57Webservicewwds_9_webservicetipodmws3",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
