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
   public class secuserlogwwgetfilterdata : GXProcedure
   {
      public secuserlogwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserlogwwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SECUSERFULLNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERFULLNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("SecUserLogWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserLogWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("SecUserLogWWGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV10TFSecUserName = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV11TFSecUserName_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV12TFSecUserFullName = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV13TFSecUserFullName_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSERLOGDATETIME") == 0 )
            {
               AV51TFSecUserLogDateTime = context.localUtil.CToT( AV28GridStateFilterValue.gxTpr_Value, 4);
               AV52TFSecUserLogDateTime_To = context.localUtil.CToT( AV28GridStateFilterValue.gxTpr_Valueto, 4);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV53SecUserLogDateTime1 = context.localUtil.CToT( AV29GridStateDynamicFilter.gxTpr_Value, 4);
               AV54SecUserLogDateTime_To1 = context.localUtil.CToT( AV29GridStateDynamicFilter.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV40SecUserName1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV55SecUserLogDateTime2 = context.localUtil.CToT( AV29GridStateDynamicFilter.gxTpr_Value, 4);
                  AV56SecUserLogDateTime_To2 = context.localUtil.CToT( AV29GridStateDynamicFilter.gxTpr_Valueto, 4);
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV45SecUserName2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV46DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV47DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 )
                  {
                     AV48DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV57SecUserLogDateTime3 = context.localUtil.CToT( AV29GridStateDynamicFilter.gxTpr_Value, 4);
                     AV58SecUserLogDateTime_To3 = context.localUtil.CToT( AV29GridStateDynamicFilter.gxTpr_Valueto, 4);
                  }
                  else if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV48DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV50SecUserName3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecUserName = AV14SearchTxt;
         AV11TFSecUserName_Sel = "";
         AV61Secuserlogwwds_1_filterfulltext = AV36FilterFullText;
         AV62Secuserlogwwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV63Secuserlogwwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV64Secuserlogwwds_4_secuserlogdatetime1 = AV53SecUserLogDateTime1;
         AV65Secuserlogwwds_5_secuserlogdatetime_to1 = AV54SecUserLogDateTime_To1;
         AV66Secuserlogwwds_6_secusername1 = AV40SecUserName1;
         AV67Secuserlogwwds_7_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV68Secuserlogwwds_8_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV69Secuserlogwwds_9_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV70Secuserlogwwds_10_secuserlogdatetime2 = AV55SecUserLogDateTime2;
         AV71Secuserlogwwds_11_secuserlogdatetime_to2 = AV56SecUserLogDateTime_To2;
         AV72Secuserlogwwds_12_secusername2 = AV45SecUserName2;
         AV73Secuserlogwwds_13_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV74Secuserlogwwds_14_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV75Secuserlogwwds_15_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV76Secuserlogwwds_16_secuserlogdatetime3 = AV57SecUserLogDateTime3;
         AV77Secuserlogwwds_17_secuserlogdatetime_to3 = AV58SecUserLogDateTime_To3;
         AV78Secuserlogwwds_18_secusername3 = AV50SecUserName3;
         AV79Secuserlogwwds_19_tfsecusername = AV10TFSecUserName;
         AV80Secuserlogwwds_20_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV81Secuserlogwwds_21_tfsecuserfullname = AV12TFSecUserFullName;
         AV82Secuserlogwwds_22_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV83Secuserlogwwds_23_tfsecuserlogdatetime = AV51TFSecUserLogDateTime;
         AV84Secuserlogwwds_24_tfsecuserlogdatetime_to = AV52TFSecUserLogDateTime_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Secuserlogwwds_1_filterfulltext ,
                                              AV62Secuserlogwwds_2_dynamicfiltersselector1 ,
                                              AV63Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                              AV64Secuserlogwwds_4_secuserlogdatetime1 ,
                                              AV65Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                              AV66Secuserlogwwds_6_secusername1 ,
                                              AV67Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                              AV68Secuserlogwwds_8_dynamicfiltersselector2 ,
                                              AV69Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                              AV70Secuserlogwwds_10_secuserlogdatetime2 ,
                                              AV71Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                              AV72Secuserlogwwds_12_secusername2 ,
                                              AV73Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                              AV74Secuserlogwwds_14_dynamicfiltersselector3 ,
                                              AV75Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                              AV76Secuserlogwwds_16_secuserlogdatetime3 ,
                                              AV77Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                              AV78Secuserlogwwds_18_secusername3 ,
                                              AV80Secuserlogwwds_20_tfsecusername_sel ,
                                              AV79Secuserlogwwds_19_tfsecusername ,
                                              AV82Secuserlogwwds_22_tfsecuserfullname_sel ,
                                              AV81Secuserlogwwds_21_tfsecuserfullname ,
                                              AV83Secuserlogwwds_23_tfsecuserlogdatetime ,
                                              AV84Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A560SecUserLogDateTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV61Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Secuserlogwwds_1_filterfulltext), "%", "");
         lV61Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Secuserlogwwds_1_filterfulltext), "%", "");
         lV66Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1), "%", "");
         lV66Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1), "%", "");
         lV72Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2), "%", "");
         lV72Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2), "%", "");
         lV78Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3), "%", "");
         lV78Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3), "%", "");
         lV79Secuserlogwwds_19_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV79Secuserlogwwds_19_tfsecusername), "%", "");
         lV81Secuserlogwwds_21_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV81Secuserlogwwds_21_tfsecuserfullname), "%", "");
         /* Using cursor P00AY2 */
         pr_default.execute(0, new Object[] {lV61Secuserlogwwds_1_filterfulltext, lV61Secuserlogwwds_1_filterfulltext, AV64Secuserlogwwds_4_secuserlogdatetime1, AV64Secuserlogwwds_4_secuserlogdatetime1, AV65Secuserlogwwds_5_secuserlogdatetime_to1, AV65Secuserlogwwds_5_secuserlogdatetime_to1, lV66Secuserlogwwds_6_secusername1, lV66Secuserlogwwds_6_secusername1, AV70Secuserlogwwds_10_secuserlogdatetime2, AV70Secuserlogwwds_10_secuserlogdatetime2, AV71Secuserlogwwds_11_secuserlogdatetime_to2, AV71Secuserlogwwds_11_secuserlogdatetime_to2, lV72Secuserlogwwds_12_secusername2, lV72Secuserlogwwds_12_secusername2, AV76Secuserlogwwds_16_secuserlogdatetime3, AV76Secuserlogwwds_16_secuserlogdatetime3, AV77Secuserlogwwds_17_secuserlogdatetime_to3, AV77Secuserlogwwds_17_secuserlogdatetime_to3, lV78Secuserlogwwds_18_secusername3, lV78Secuserlogwwds_18_secusername3, lV79Secuserlogwwds_19_tfsecusername, AV80Secuserlogwwds_20_tfsecusername_sel, lV81Secuserlogwwds_21_tfsecuserfullname, AV82Secuserlogwwds_22_tfsecuserfullname_sel, AV83Secuserlogwwds_23_tfsecuserlogdatetime, AV84Secuserlogwwds_24_tfsecuserlogdatetime_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAY2 = false;
            A133SecUserId = P00AY2_A133SecUserId[0];
            n133SecUserId = P00AY2_n133SecUserId[0];
            A560SecUserLogDateTime = P00AY2_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = P00AY2_n560SecUserLogDateTime[0];
            A143SecUserFullName = P00AY2_A143SecUserFullName[0];
            n143SecUserFullName = P00AY2_n143SecUserFullName[0];
            A141SecUserName = P00AY2_A141SecUserName[0];
            n141SecUserName = P00AY2_n141SecUserName[0];
            A559SecUserLogId = P00AY2_A559SecUserLogId[0];
            A143SecUserFullName = P00AY2_A143SecUserFullName[0];
            n143SecUserFullName = P00AY2_n143SecUserFullName[0];
            A141SecUserName = P00AY2_A141SecUserName[0];
            n141SecUserName = P00AY2_n141SecUserName[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00AY2_A133SecUserId[0] == A133SecUserId ) )
            {
               BRKAY2 = false;
               A559SecUserLogId = P00AY2_A559SecUserLogId[0];
               AV24count = (long)(AV24count+1);
               BRKAY2 = true;
               pr_default.readNext(0);
            }
            AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? "<#Empty#>" : A141SecUserName);
            AV21OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")));
            AV18InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV19Option, "<#Empty#>") != 0 ) && ( AV18InsertIndex <= AV20Options.Count ) && ( ( StringUtil.StrCmp(((string)AV22OptionsDesc.Item(AV18InsertIndex)), AV21OptionDesc) < 0 ) || ( StringUtil.StrCmp(((string)AV20Options.Item(AV18InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV18InsertIndex = (int)(AV18InsertIndex+1);
            }
            AV20Options.Add(AV19Option, AV18InsertIndex);
            AV22OptionsDesc.Add(AV21OptionDesc, AV18InsertIndex);
            AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), AV18InsertIndex);
            if ( AV20Options.Count == AV15SkipItems + 11 )
            {
               AV20Options.RemoveItem(AV20Options.Count);
               AV22OptionsDesc.RemoveItem(AV22OptionsDesc.Count);
               AV23OptionIndexes.RemoveItem(AV23OptionIndexes.Count);
            }
            if ( ! BRKAY2 )
            {
               BRKAY2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV15SkipItems > 0 )
         {
            AV20Options.RemoveItem(1);
            AV22OptionsDesc.RemoveItem(1);
            AV23OptionIndexes.RemoveItem(1);
            AV15SkipItems = (short)(AV15SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADSECUSERFULLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecUserFullName = AV14SearchTxt;
         AV13TFSecUserFullName_Sel = "";
         AV61Secuserlogwwds_1_filterfulltext = AV36FilterFullText;
         AV62Secuserlogwwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV63Secuserlogwwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV64Secuserlogwwds_4_secuserlogdatetime1 = AV53SecUserLogDateTime1;
         AV65Secuserlogwwds_5_secuserlogdatetime_to1 = AV54SecUserLogDateTime_To1;
         AV66Secuserlogwwds_6_secusername1 = AV40SecUserName1;
         AV67Secuserlogwwds_7_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV68Secuserlogwwds_8_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV69Secuserlogwwds_9_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV70Secuserlogwwds_10_secuserlogdatetime2 = AV55SecUserLogDateTime2;
         AV71Secuserlogwwds_11_secuserlogdatetime_to2 = AV56SecUserLogDateTime_To2;
         AV72Secuserlogwwds_12_secusername2 = AV45SecUserName2;
         AV73Secuserlogwwds_13_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV74Secuserlogwwds_14_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV75Secuserlogwwds_15_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV76Secuserlogwwds_16_secuserlogdatetime3 = AV57SecUserLogDateTime3;
         AV77Secuserlogwwds_17_secuserlogdatetime_to3 = AV58SecUserLogDateTime_To3;
         AV78Secuserlogwwds_18_secusername3 = AV50SecUserName3;
         AV79Secuserlogwwds_19_tfsecusername = AV10TFSecUserName;
         AV80Secuserlogwwds_20_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV81Secuserlogwwds_21_tfsecuserfullname = AV12TFSecUserFullName;
         AV82Secuserlogwwds_22_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV83Secuserlogwwds_23_tfsecuserlogdatetime = AV51TFSecUserLogDateTime;
         AV84Secuserlogwwds_24_tfsecuserlogdatetime_to = AV52TFSecUserLogDateTime_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Secuserlogwwds_1_filterfulltext ,
                                              AV62Secuserlogwwds_2_dynamicfiltersselector1 ,
                                              AV63Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                              AV64Secuserlogwwds_4_secuserlogdatetime1 ,
                                              AV65Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                              AV66Secuserlogwwds_6_secusername1 ,
                                              AV67Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                              AV68Secuserlogwwds_8_dynamicfiltersselector2 ,
                                              AV69Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                              AV70Secuserlogwwds_10_secuserlogdatetime2 ,
                                              AV71Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                              AV72Secuserlogwwds_12_secusername2 ,
                                              AV73Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                              AV74Secuserlogwwds_14_dynamicfiltersselector3 ,
                                              AV75Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                              AV76Secuserlogwwds_16_secuserlogdatetime3 ,
                                              AV77Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                              AV78Secuserlogwwds_18_secusername3 ,
                                              AV80Secuserlogwwds_20_tfsecusername_sel ,
                                              AV79Secuserlogwwds_19_tfsecusername ,
                                              AV82Secuserlogwwds_22_tfsecuserfullname_sel ,
                                              AV81Secuserlogwwds_21_tfsecuserfullname ,
                                              AV83Secuserlogwwds_23_tfsecuserlogdatetime ,
                                              AV84Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A560SecUserLogDateTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV61Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Secuserlogwwds_1_filterfulltext), "%", "");
         lV61Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Secuserlogwwds_1_filterfulltext), "%", "");
         lV66Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1), "%", "");
         lV66Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1), "%", "");
         lV72Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2), "%", "");
         lV72Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2), "%", "");
         lV78Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3), "%", "");
         lV78Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3), "%", "");
         lV79Secuserlogwwds_19_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV79Secuserlogwwds_19_tfsecusername), "%", "");
         lV81Secuserlogwwds_21_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV81Secuserlogwwds_21_tfsecuserfullname), "%", "");
         /* Using cursor P00AY3 */
         pr_default.execute(1, new Object[] {lV61Secuserlogwwds_1_filterfulltext, lV61Secuserlogwwds_1_filterfulltext, AV64Secuserlogwwds_4_secuserlogdatetime1, AV64Secuserlogwwds_4_secuserlogdatetime1, AV65Secuserlogwwds_5_secuserlogdatetime_to1, AV65Secuserlogwwds_5_secuserlogdatetime_to1, lV66Secuserlogwwds_6_secusername1, lV66Secuserlogwwds_6_secusername1, AV70Secuserlogwwds_10_secuserlogdatetime2, AV70Secuserlogwwds_10_secuserlogdatetime2, AV71Secuserlogwwds_11_secuserlogdatetime_to2, AV71Secuserlogwwds_11_secuserlogdatetime_to2, lV72Secuserlogwwds_12_secusername2, lV72Secuserlogwwds_12_secusername2, AV76Secuserlogwwds_16_secuserlogdatetime3, AV76Secuserlogwwds_16_secuserlogdatetime3, AV77Secuserlogwwds_17_secuserlogdatetime_to3, AV77Secuserlogwwds_17_secuserlogdatetime_to3, lV78Secuserlogwwds_18_secusername3, lV78Secuserlogwwds_18_secusername3, lV79Secuserlogwwds_19_tfsecusername, AV80Secuserlogwwds_20_tfsecusername_sel, lV81Secuserlogwwds_21_tfsecuserfullname, AV82Secuserlogwwds_22_tfsecuserfullname_sel, AV83Secuserlogwwds_23_tfsecuserlogdatetime, AV84Secuserlogwwds_24_tfsecuserlogdatetime_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAY4 = false;
            A133SecUserId = P00AY3_A133SecUserId[0];
            n133SecUserId = P00AY3_n133SecUserId[0];
            A143SecUserFullName = P00AY3_A143SecUserFullName[0];
            n143SecUserFullName = P00AY3_n143SecUserFullName[0];
            A560SecUserLogDateTime = P00AY3_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = P00AY3_n560SecUserLogDateTime[0];
            A141SecUserName = P00AY3_A141SecUserName[0];
            n141SecUserName = P00AY3_n141SecUserName[0];
            A559SecUserLogId = P00AY3_A559SecUserLogId[0];
            A143SecUserFullName = P00AY3_A143SecUserFullName[0];
            n143SecUserFullName = P00AY3_n143SecUserFullName[0];
            A141SecUserName = P00AY3_A141SecUserName[0];
            n141SecUserName = P00AY3_n141SecUserName[0];
            AV24count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AY3_A143SecUserFullName[0], A143SecUserFullName) == 0 ) )
            {
               BRKAY4 = false;
               A133SecUserId = P00AY3_A133SecUserId[0];
               n133SecUserId = P00AY3_n133SecUserId[0];
               A559SecUserLogId = P00AY3_A559SecUserLogId[0];
               AV24count = (long)(AV24count+1);
               BRKAY4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? "<#Empty#>" : A143SecUserFullName);
               AV21OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")));
               AV20Options.Add(AV19Option, 0);
               AV22OptionsDesc.Add(AV21OptionDesc, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRKAY4 )
            {
               BRKAY4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV10TFSecUserName = "";
         AV11TFSecUserName_Sel = "";
         AV12TFSecUserFullName = "";
         AV13TFSecUserFullName_Sel = "";
         AV51TFSecUserLogDateTime = (DateTime)(DateTime.MinValue);
         AV52TFSecUserLogDateTime_To = (DateTime)(DateTime.MinValue);
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV53SecUserLogDateTime1 = (DateTime)(DateTime.MinValue);
         AV54SecUserLogDateTime_To1 = (DateTime)(DateTime.MinValue);
         AV40SecUserName1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV55SecUserLogDateTime2 = (DateTime)(DateTime.MinValue);
         AV56SecUserLogDateTime_To2 = (DateTime)(DateTime.MinValue);
         AV45SecUserName2 = "";
         AV47DynamicFiltersSelector3 = "";
         AV57SecUserLogDateTime3 = (DateTime)(DateTime.MinValue);
         AV58SecUserLogDateTime_To3 = (DateTime)(DateTime.MinValue);
         AV50SecUserName3 = "";
         AV61Secuserlogwwds_1_filterfulltext = "";
         AV62Secuserlogwwds_2_dynamicfiltersselector1 = "";
         AV64Secuserlogwwds_4_secuserlogdatetime1 = (DateTime)(DateTime.MinValue);
         AV65Secuserlogwwds_5_secuserlogdatetime_to1 = (DateTime)(DateTime.MinValue);
         AV66Secuserlogwwds_6_secusername1 = "";
         AV68Secuserlogwwds_8_dynamicfiltersselector2 = "";
         AV70Secuserlogwwds_10_secuserlogdatetime2 = (DateTime)(DateTime.MinValue);
         AV71Secuserlogwwds_11_secuserlogdatetime_to2 = (DateTime)(DateTime.MinValue);
         AV72Secuserlogwwds_12_secusername2 = "";
         AV74Secuserlogwwds_14_dynamicfiltersselector3 = "";
         AV76Secuserlogwwds_16_secuserlogdatetime3 = (DateTime)(DateTime.MinValue);
         AV77Secuserlogwwds_17_secuserlogdatetime_to3 = (DateTime)(DateTime.MinValue);
         AV78Secuserlogwwds_18_secusername3 = "";
         AV79Secuserlogwwds_19_tfsecusername = "";
         AV80Secuserlogwwds_20_tfsecusername_sel = "";
         AV81Secuserlogwwds_21_tfsecuserfullname = "";
         AV82Secuserlogwwds_22_tfsecuserfullname_sel = "";
         AV83Secuserlogwwds_23_tfsecuserlogdatetime = (DateTime)(DateTime.MinValue);
         AV84Secuserlogwwds_24_tfsecuserlogdatetime_to = (DateTime)(DateTime.MinValue);
         lV61Secuserlogwwds_1_filterfulltext = "";
         lV66Secuserlogwwds_6_secusername1 = "";
         lV72Secuserlogwwds_12_secusername2 = "";
         lV78Secuserlogwwds_18_secusername3 = "";
         lV79Secuserlogwwds_19_tfsecusername = "";
         lV81Secuserlogwwds_21_tfsecuserfullname = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         P00AY2_A133SecUserId = new short[1] ;
         P00AY2_n133SecUserId = new bool[] {false} ;
         P00AY2_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         P00AY2_n560SecUserLogDateTime = new bool[] {false} ;
         P00AY2_A143SecUserFullName = new string[] {""} ;
         P00AY2_n143SecUserFullName = new bool[] {false} ;
         P00AY2_A141SecUserName = new string[] {""} ;
         P00AY2_n141SecUserName = new bool[] {false} ;
         P00AY2_A559SecUserLogId = new int[1] ;
         AV19Option = "";
         AV21OptionDesc = "";
         P00AY3_A133SecUserId = new short[1] ;
         P00AY3_n133SecUserId = new bool[] {false} ;
         P00AY3_A143SecUserFullName = new string[] {""} ;
         P00AY3_n143SecUserFullName = new bool[] {false} ;
         P00AY3_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         P00AY3_n560SecUserLogDateTime = new bool[] {false} ;
         P00AY3_A141SecUserName = new string[] {""} ;
         P00AY3_n141SecUserName = new bool[] {false} ;
         P00AY3_A559SecUserLogId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserlogwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AY2_A133SecUserId, P00AY2_n133SecUserId, P00AY2_A560SecUserLogDateTime, P00AY2_n560SecUserLogDateTime, P00AY2_A143SecUserFullName, P00AY2_n143SecUserFullName, P00AY2_A141SecUserName, P00AY2_n141SecUserName, P00AY2_A559SecUserLogId
               }
               , new Object[] {
               P00AY3_A133SecUserId, P00AY3_n133SecUserId, P00AY3_A143SecUserFullName, P00AY3_n143SecUserFullName, P00AY3_A560SecUserLogDateTime, P00AY3_n560SecUserLogDateTime, P00AY3_A141SecUserName, P00AY3_n141SecUserName, P00AY3_A559SecUserLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV38DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV48DynamicFiltersOperator3 ;
      private short AV63Secuserlogwwds_3_dynamicfiltersoperator1 ;
      private short AV69Secuserlogwwds_9_dynamicfiltersoperator2 ;
      private short AV75Secuserlogwwds_15_dynamicfiltersoperator3 ;
      private short A133SecUserId ;
      private int AV59GXV1 ;
      private int A559SecUserLogId ;
      private int AV18InsertIndex ;
      private long AV24count ;
      private DateTime AV51TFSecUserLogDateTime ;
      private DateTime AV52TFSecUserLogDateTime_To ;
      private DateTime AV53SecUserLogDateTime1 ;
      private DateTime AV54SecUserLogDateTime_To1 ;
      private DateTime AV55SecUserLogDateTime2 ;
      private DateTime AV56SecUserLogDateTime_To2 ;
      private DateTime AV57SecUserLogDateTime3 ;
      private DateTime AV58SecUserLogDateTime_To3 ;
      private DateTime AV64Secuserlogwwds_4_secuserlogdatetime1 ;
      private DateTime AV65Secuserlogwwds_5_secuserlogdatetime_to1 ;
      private DateTime AV70Secuserlogwwds_10_secuserlogdatetime2 ;
      private DateTime AV71Secuserlogwwds_11_secuserlogdatetime_to2 ;
      private DateTime AV76Secuserlogwwds_16_secuserlogdatetime3 ;
      private DateTime AV77Secuserlogwwds_17_secuserlogdatetime_to3 ;
      private DateTime AV83Secuserlogwwds_23_tfsecuserlogdatetime ;
      private DateTime AV84Secuserlogwwds_24_tfsecuserlogdatetime_to ;
      private DateTime A560SecUserLogDateTime ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV46DynamicFiltersEnabled3 ;
      private bool AV67Secuserlogwwds_7_dynamicfiltersenabled2 ;
      private bool AV73Secuserlogwwds_13_dynamicfiltersenabled3 ;
      private bool BRKAY2 ;
      private bool n133SecUserId ;
      private bool n560SecUserLogDateTime ;
      private bool n143SecUserFullName ;
      private bool n141SecUserName ;
      private bool BRKAY4 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV10TFSecUserName ;
      private string AV11TFSecUserName_Sel ;
      private string AV12TFSecUserFullName ;
      private string AV13TFSecUserFullName_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV40SecUserName1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV45SecUserName2 ;
      private string AV47DynamicFiltersSelector3 ;
      private string AV50SecUserName3 ;
      private string AV61Secuserlogwwds_1_filterfulltext ;
      private string AV62Secuserlogwwds_2_dynamicfiltersselector1 ;
      private string AV66Secuserlogwwds_6_secusername1 ;
      private string AV68Secuserlogwwds_8_dynamicfiltersselector2 ;
      private string AV72Secuserlogwwds_12_secusername2 ;
      private string AV74Secuserlogwwds_14_dynamicfiltersselector3 ;
      private string AV78Secuserlogwwds_18_secusername3 ;
      private string AV79Secuserlogwwds_19_tfsecusername ;
      private string AV80Secuserlogwwds_20_tfsecusername_sel ;
      private string AV81Secuserlogwwds_21_tfsecuserfullname ;
      private string AV82Secuserlogwwds_22_tfsecuserfullname_sel ;
      private string lV61Secuserlogwwds_1_filterfulltext ;
      private string lV66Secuserlogwwds_6_secusername1 ;
      private string lV72Secuserlogwwds_12_secusername2 ;
      private string lV78Secuserlogwwds_18_secusername3 ;
      private string lV79Secuserlogwwds_19_tfsecusername ;
      private string lV81Secuserlogwwds_21_tfsecuserfullname ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string AV19Option ;
      private string AV21OptionDesc ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00AY2_A133SecUserId ;
      private bool[] P00AY2_n133SecUserId ;
      private DateTime[] P00AY2_A560SecUserLogDateTime ;
      private bool[] P00AY2_n560SecUserLogDateTime ;
      private string[] P00AY2_A143SecUserFullName ;
      private bool[] P00AY2_n143SecUserFullName ;
      private string[] P00AY2_A141SecUserName ;
      private bool[] P00AY2_n141SecUserName ;
      private int[] P00AY2_A559SecUserLogId ;
      private short[] P00AY3_A133SecUserId ;
      private bool[] P00AY3_n133SecUserId ;
      private string[] P00AY3_A143SecUserFullName ;
      private bool[] P00AY3_n143SecUserFullName ;
      private DateTime[] P00AY3_A560SecUserLogDateTime ;
      private bool[] P00AY3_n560SecUserLogDateTime ;
      private string[] P00AY3_A141SecUserName ;
      private bool[] P00AY3_n141SecUserName ;
      private int[] P00AY3_A559SecUserLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secuserlogwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AY2( IGxContext context ,
                                             string AV61Secuserlogwwds_1_filterfulltext ,
                                             string AV62Secuserlogwwds_2_dynamicfiltersselector1 ,
                                             short AV63Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV64Secuserlogwwds_4_secuserlogdatetime1 ,
                                             DateTime AV65Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                             string AV66Secuserlogwwds_6_secusername1 ,
                                             bool AV67Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                             string AV68Secuserlogwwds_8_dynamicfiltersselector2 ,
                                             short AV69Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV70Secuserlogwwds_10_secuserlogdatetime2 ,
                                             DateTime AV71Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                             string AV72Secuserlogwwds_12_secusername2 ,
                                             bool AV73Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                             string AV74Secuserlogwwds_14_dynamicfiltersselector3 ,
                                             short AV75Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV76Secuserlogwwds_16_secuserlogdatetime3 ,
                                             DateTime AV77Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                             string AV78Secuserlogwwds_18_secusername3 ,
                                             string AV80Secuserlogwwds_20_tfsecusername_sel ,
                                             string AV79Secuserlogwwds_19_tfsecusername ,
                                             string AV82Secuserlogwwds_22_tfsecuserfullname_sel ,
                                             string AV81Secuserlogwwds_21_tfsecuserfullname ,
                                             DateTime AV83Secuserlogwwds_23_tfsecuserlogdatetime ,
                                             DateTime AV84Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             DateTime A560SecUserLogDateTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[26];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T1.SecUserLogDateTime, T2.SecUserFullName, T2.SecUserName, T1.SecUserLogId FROM (SecUserLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV61Secuserlogwwds_1_filterfulltext) or ( T2.SecUserFullName like '%' || :lV61Secuserlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV64Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV64Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV64Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV64Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV65Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV65Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV70Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV70Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV70Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV70Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV71Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV71Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV72Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV72Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV76Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV76Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV76Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV76Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV77Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV77Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV78Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV78Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserlogwwds_20_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserlogwwds_19_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV79Secuserlogwwds_19_tfsecusername)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserlogwwds_20_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV80Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV80Secuserlogwwds_20_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserlogwwds_22_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserlogwwds_21_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName like :lV81Secuserlogwwds_21_tfsecuserfullname)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserlogwwds_22_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV82Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName = ( :AV82Secuserlogwwds_22_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserFullName))=0))");
         }
         if ( ! (DateTime.MinValue==AV83Secuserlogwwds_23_tfsecuserlogdatetime) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV83Secuserlogwwds_23_tfsecuserlogdatetime)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Secuserlogwwds_24_tfsecuserlogdatetime_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV84Secuserlogwwds_24_tfsecuserlogdatetime_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AY3( IGxContext context ,
                                             string AV61Secuserlogwwds_1_filterfulltext ,
                                             string AV62Secuserlogwwds_2_dynamicfiltersselector1 ,
                                             short AV63Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV64Secuserlogwwds_4_secuserlogdatetime1 ,
                                             DateTime AV65Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                             string AV66Secuserlogwwds_6_secusername1 ,
                                             bool AV67Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                             string AV68Secuserlogwwds_8_dynamicfiltersselector2 ,
                                             short AV69Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV70Secuserlogwwds_10_secuserlogdatetime2 ,
                                             DateTime AV71Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                             string AV72Secuserlogwwds_12_secusername2 ,
                                             bool AV73Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                             string AV74Secuserlogwwds_14_dynamicfiltersselector3 ,
                                             short AV75Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV76Secuserlogwwds_16_secuserlogdatetime3 ,
                                             DateTime AV77Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                             string AV78Secuserlogwwds_18_secusername3 ,
                                             string AV80Secuserlogwwds_20_tfsecusername_sel ,
                                             string AV79Secuserlogwwds_19_tfsecusername ,
                                             string AV82Secuserlogwwds_22_tfsecuserfullname_sel ,
                                             string AV81Secuserlogwwds_21_tfsecuserfullname ,
                                             DateTime AV83Secuserlogwwds_23_tfsecuserlogdatetime ,
                                             DateTime AV84Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             DateTime A560SecUserLogDateTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T2.SecUserFullName, T1.SecUserLogDateTime, T2.SecUserName, T1.SecUserLogId FROM (SecUserLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV61Secuserlogwwds_1_filterfulltext) or ( T2.SecUserFullName like '%' || :lV61Secuserlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV64Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV64Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV64Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV64Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV65Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV65Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV70Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV70Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV70Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV70Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV71Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV71Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV72Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV67Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV72Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV76Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV76Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV76Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV76Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV77Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV77Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV78Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV73Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV78Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserlogwwds_20_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserlogwwds_19_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV79Secuserlogwwds_19_tfsecusername)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserlogwwds_20_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV80Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV80Secuserlogwwds_20_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserlogwwds_22_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserlogwwds_21_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName like :lV81Secuserlogwwds_21_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserlogwwds_22_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV82Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName = ( :AV82Secuserlogwwds_22_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserFullName))=0))");
         }
         if ( ! (DateTime.MinValue==AV83Secuserlogwwds_23_tfsecuserlogdatetime) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV83Secuserlogwwds_23_tfsecuserlogdatetime)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Secuserlogwwds_24_tfsecuserlogdatetime_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV84Secuserlogwwds_24_tfsecuserlogdatetime_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.SecUserFullName";
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
                     return conditional_P00AY2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] );
               case 1 :
                     return conditional_P00AY3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] );
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
          Object[] prmP00AY2;
          prmP00AY2 = new Object[] {
          new ParDef("lV61Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV64Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV65Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("AV65Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("lV66Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV70Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV70Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV71Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("AV71Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("lV72Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV76Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV76Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV77Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("AV77Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("lV78Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV78Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV79Secuserlogwwds_19_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV80Secuserlogwwds_20_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Secuserlogwwds_21_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV82Secuserlogwwds_22_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("AV83Secuserlogwwds_23_tfsecuserlogdatetime",GXType.DateTime,10,5) ,
          new ParDef("AV84Secuserlogwwds_24_tfsecuserlogdatetime_to",GXType.DateTime,10,5)
          };
          Object[] prmP00AY3;
          prmP00AY3 = new Object[] {
          new ParDef("lV61Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV64Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV65Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("AV65Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("lV66Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV70Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV70Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV71Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("AV71Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("lV72Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV76Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV76Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV77Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("AV77Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("lV78Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV78Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV79Secuserlogwwds_19_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV80Secuserlogwwds_20_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Secuserlogwwds_21_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV82Secuserlogwwds_22_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("AV83Secuserlogwwds_23_tfsecuserlogdatetime",GXType.DateTime,10,5) ,
          new ParDef("AV84Secuserlogwwds_24_tfsecuserlogdatetime_to",GXType.DateTime,10,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00AY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AY3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
