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
   public class aprovadoreswwgetfilterdata : GXProcedure
   {
      public aprovadoreswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovadoreswwgetfilterdata( IGxContext context )
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
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SECUSEREMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSEREMAILOPTIONS' */
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
         if ( StringUtil.StrCmp(AV25Session.Get("AprovadoresWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AprovadoresWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("AprovadoresWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV55GXV1));
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
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV12TFSecUserEmail = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV13TFSecUserEmail_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFAPROVADORESSTATUS_SEL") == 0 )
            {
               AV51TFAprovadoresStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "APROVADORESSTATUS") == 0 )
            {
               AV52AprovadoresStatus1 = BooleanUtil.Val( AV29GridStateDynamicFilter.gxTpr_Value);
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
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "APROVADORESSTATUS") == 0 )
               {
                  AV53AprovadoresStatus2 = BooleanUtil.Val( AV29GridStateDynamicFilter.gxTpr_Value);
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
                  if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "APROVADORESSTATUS") == 0 )
                  {
                     AV54AprovadoresStatus3 = BooleanUtil.Val( AV29GridStateDynamicFilter.gxTpr_Value);
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
         AV57Aprovadoreswwds_1_filterfulltext = AV36FilterFullText;
         AV58Aprovadoreswwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV59Aprovadoreswwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV60Aprovadoreswwds_4_aprovadoresstatus1 = AV52AprovadoresStatus1;
         AV61Aprovadoreswwds_5_secusername1 = AV40SecUserName1;
         AV62Aprovadoreswwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Aprovadoreswwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Aprovadoreswwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Aprovadoreswwds_9_aprovadoresstatus2 = AV53AprovadoresStatus2;
         AV66Aprovadoreswwds_10_secusername2 = AV45SecUserName2;
         AV67Aprovadoreswwds_11_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV68Aprovadoreswwds_12_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV69Aprovadoreswwds_13_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV70Aprovadoreswwds_14_aprovadoresstatus3 = AV54AprovadoresStatus3;
         AV71Aprovadoreswwds_15_secusername3 = AV50SecUserName3;
         AV72Aprovadoreswwds_16_tfsecusername = AV10TFSecUserName;
         AV73Aprovadoreswwds_17_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV74Aprovadoreswwds_18_tfsecuseremail = AV12TFSecUserEmail;
         AV75Aprovadoreswwds_19_tfsecuseremail_sel = AV13TFSecUserEmail_Sel;
         AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV51TFAprovadoresStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Aprovadoreswwds_1_filterfulltext ,
                                              AV58Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                              AV60Aprovadoreswwds_4_aprovadoresstatus1 ,
                                              AV59Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                              AV61Aprovadoreswwds_5_secusername1 ,
                                              AV62Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                              AV63Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                              AV65Aprovadoreswwds_9_aprovadoresstatus2 ,
                                              AV64Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                              AV66Aprovadoreswwds_10_secusername2 ,
                                              AV67Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                              AV68Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                              AV70Aprovadoreswwds_14_aprovadoresstatus3 ,
                                              AV69Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                              AV71Aprovadoreswwds_15_secusername3 ,
                                              AV73Aprovadoreswwds_17_tfsecusername_sel ,
                                              AV72Aprovadoreswwds_16_tfsecusername ,
                                              AV75Aprovadoreswwds_19_tfsecuseremail_sel ,
                                              AV74Aprovadoreswwds_18_tfsecuseremail ,
                                              AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A380AprovadoresStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV61Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1), "%", "");
         lV61Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1), "%", "");
         lV66Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2), "%", "");
         lV66Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2), "%", "");
         lV71Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3), "%", "");
         lV71Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3), "%", "");
         lV72Aprovadoreswwds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV72Aprovadoreswwds_16_tfsecusername), "%", "");
         lV74Aprovadoreswwds_18_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV74Aprovadoreswwds_18_tfsecuseremail), "%", "");
         /* Using cursor P009D2 */
         pr_default.execute(0, new Object[] {lV57Aprovadoreswwds_1_filterfulltext, lV57Aprovadoreswwds_1_filterfulltext, lV57Aprovadoreswwds_1_filterfulltext, lV57Aprovadoreswwds_1_filterfulltext, AV60Aprovadoreswwds_4_aprovadoresstatus1, lV61Aprovadoreswwds_5_secusername1, lV61Aprovadoreswwds_5_secusername1, AV65Aprovadoreswwds_9_aprovadoresstatus2, lV66Aprovadoreswwds_10_secusername2, lV66Aprovadoreswwds_10_secusername2, AV70Aprovadoreswwds_14_aprovadoresstatus3, lV71Aprovadoreswwds_15_secusername3, lV71Aprovadoreswwds_15_secusername3, lV72Aprovadoreswwds_16_tfsecusername, AV73Aprovadoreswwds_17_tfsecusername_sel, lV74Aprovadoreswwds_18_tfsecuseremail, AV75Aprovadoreswwds_19_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9D2 = false;
            A133SecUserId = P009D2_A133SecUserId[0];
            n133SecUserId = P009D2_n133SecUserId[0];
            A380AprovadoresStatus = P009D2_A380AprovadoresStatus[0];
            n380AprovadoresStatus = P009D2_n380AprovadoresStatus[0];
            A144SecUserEmail = P009D2_A144SecUserEmail[0];
            n144SecUserEmail = P009D2_n144SecUserEmail[0];
            A141SecUserName = P009D2_A141SecUserName[0];
            n141SecUserName = P009D2_n141SecUserName[0];
            A375AprovadoresId = P009D2_A375AprovadoresId[0];
            A144SecUserEmail = P009D2_A144SecUserEmail[0];
            n144SecUserEmail = P009D2_n144SecUserEmail[0];
            A141SecUserName = P009D2_A141SecUserName[0];
            n141SecUserName = P009D2_n141SecUserName[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P009D2_A133SecUserId[0] == A133SecUserId ) )
            {
               BRK9D2 = false;
               A375AprovadoresId = P009D2_A375AprovadoresId[0];
               AV24count = (long)(AV24count+1);
               BRK9D2 = true;
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
            if ( ! BRK9D2 )
            {
               BRK9D2 = true;
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
         /* 'LOADSECUSEREMAILOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecUserEmail = AV14SearchTxt;
         AV13TFSecUserEmail_Sel = "";
         AV57Aprovadoreswwds_1_filterfulltext = AV36FilterFullText;
         AV58Aprovadoreswwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV59Aprovadoreswwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV60Aprovadoreswwds_4_aprovadoresstatus1 = AV52AprovadoresStatus1;
         AV61Aprovadoreswwds_5_secusername1 = AV40SecUserName1;
         AV62Aprovadoreswwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Aprovadoreswwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Aprovadoreswwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Aprovadoreswwds_9_aprovadoresstatus2 = AV53AprovadoresStatus2;
         AV66Aprovadoreswwds_10_secusername2 = AV45SecUserName2;
         AV67Aprovadoreswwds_11_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV68Aprovadoreswwds_12_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV69Aprovadoreswwds_13_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV70Aprovadoreswwds_14_aprovadoresstatus3 = AV54AprovadoresStatus3;
         AV71Aprovadoreswwds_15_secusername3 = AV50SecUserName3;
         AV72Aprovadoreswwds_16_tfsecusername = AV10TFSecUserName;
         AV73Aprovadoreswwds_17_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV74Aprovadoreswwds_18_tfsecuseremail = AV12TFSecUserEmail;
         AV75Aprovadoreswwds_19_tfsecuseremail_sel = AV13TFSecUserEmail_Sel;
         AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV51TFAprovadoresStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Aprovadoreswwds_1_filterfulltext ,
                                              AV58Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                              AV60Aprovadoreswwds_4_aprovadoresstatus1 ,
                                              AV59Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                              AV61Aprovadoreswwds_5_secusername1 ,
                                              AV62Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                              AV63Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                              AV65Aprovadoreswwds_9_aprovadoresstatus2 ,
                                              AV64Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                              AV66Aprovadoreswwds_10_secusername2 ,
                                              AV67Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                              AV68Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                              AV70Aprovadoreswwds_14_aprovadoresstatus3 ,
                                              AV69Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                              AV71Aprovadoreswwds_15_secusername3 ,
                                              AV73Aprovadoreswwds_17_tfsecusername_sel ,
                                              AV72Aprovadoreswwds_16_tfsecusername ,
                                              AV75Aprovadoreswwds_19_tfsecuseremail_sel ,
                                              AV74Aprovadoreswwds_18_tfsecuseremail ,
                                              AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A380AprovadoresStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV57Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext), "%", "");
         lV61Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1), "%", "");
         lV61Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1), "%", "");
         lV66Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2), "%", "");
         lV66Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2), "%", "");
         lV71Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3), "%", "");
         lV71Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3), "%", "");
         lV72Aprovadoreswwds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV72Aprovadoreswwds_16_tfsecusername), "%", "");
         lV74Aprovadoreswwds_18_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV74Aprovadoreswwds_18_tfsecuseremail), "%", "");
         /* Using cursor P009D3 */
         pr_default.execute(1, new Object[] {lV57Aprovadoreswwds_1_filterfulltext, lV57Aprovadoreswwds_1_filterfulltext, lV57Aprovadoreswwds_1_filterfulltext, lV57Aprovadoreswwds_1_filterfulltext, AV60Aprovadoreswwds_4_aprovadoresstatus1, lV61Aprovadoreswwds_5_secusername1, lV61Aprovadoreswwds_5_secusername1, AV65Aprovadoreswwds_9_aprovadoresstatus2, lV66Aprovadoreswwds_10_secusername2, lV66Aprovadoreswwds_10_secusername2, AV70Aprovadoreswwds_14_aprovadoresstatus3, lV71Aprovadoreswwds_15_secusername3, lV71Aprovadoreswwds_15_secusername3, lV72Aprovadoreswwds_16_tfsecusername, AV73Aprovadoreswwds_17_tfsecusername_sel, lV74Aprovadoreswwds_18_tfsecuseremail, AV75Aprovadoreswwds_19_tfsecuseremail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9D4 = false;
            A133SecUserId = P009D3_A133SecUserId[0];
            n133SecUserId = P009D3_n133SecUserId[0];
            A144SecUserEmail = P009D3_A144SecUserEmail[0];
            n144SecUserEmail = P009D3_n144SecUserEmail[0];
            A380AprovadoresStatus = P009D3_A380AprovadoresStatus[0];
            n380AprovadoresStatus = P009D3_n380AprovadoresStatus[0];
            A141SecUserName = P009D3_A141SecUserName[0];
            n141SecUserName = P009D3_n141SecUserName[0];
            A375AprovadoresId = P009D3_A375AprovadoresId[0];
            A144SecUserEmail = P009D3_A144SecUserEmail[0];
            n144SecUserEmail = P009D3_n144SecUserEmail[0];
            A141SecUserName = P009D3_A141SecUserName[0];
            n141SecUserName = P009D3_n141SecUserName[0];
            AV24count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P009D3_A144SecUserEmail[0], A144SecUserEmail) == 0 ) )
            {
               BRK9D4 = false;
               A133SecUserId = P009D3_A133SecUserId[0];
               n133SecUserId = P009D3_n133SecUserId[0];
               A375AprovadoresId = P009D3_A375AprovadoresId[0];
               AV24count = (long)(AV24count+1);
               BRK9D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? "<#Empty#>" : A144SecUserEmail);
               AV20Options.Add(AV19Option, 0);
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
            if ( ! BRK9D4 )
            {
               BRK9D4 = true;
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
         AV12TFSecUserEmail = "";
         AV13TFSecUserEmail_Sel = "";
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV40SecUserName1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV45SecUserName2 = "";
         AV47DynamicFiltersSelector3 = "";
         AV50SecUserName3 = "";
         AV57Aprovadoreswwds_1_filterfulltext = "";
         AV58Aprovadoreswwds_2_dynamicfiltersselector1 = "";
         AV61Aprovadoreswwds_5_secusername1 = "";
         AV63Aprovadoreswwds_7_dynamicfiltersselector2 = "";
         AV66Aprovadoreswwds_10_secusername2 = "";
         AV68Aprovadoreswwds_12_dynamicfiltersselector3 = "";
         AV71Aprovadoreswwds_15_secusername3 = "";
         AV72Aprovadoreswwds_16_tfsecusername = "";
         AV73Aprovadoreswwds_17_tfsecusername_sel = "";
         AV74Aprovadoreswwds_18_tfsecuseremail = "";
         AV75Aprovadoreswwds_19_tfsecuseremail_sel = "";
         lV57Aprovadoreswwds_1_filterfulltext = "";
         lV61Aprovadoreswwds_5_secusername1 = "";
         lV66Aprovadoreswwds_10_secusername2 = "";
         lV71Aprovadoreswwds_15_secusername3 = "";
         lV72Aprovadoreswwds_16_tfsecusername = "";
         lV74Aprovadoreswwds_18_tfsecuseremail = "";
         A141SecUserName = "";
         A144SecUserEmail = "";
         P009D2_A133SecUserId = new short[1] ;
         P009D2_n133SecUserId = new bool[] {false} ;
         P009D2_A380AprovadoresStatus = new bool[] {false} ;
         P009D2_n380AprovadoresStatus = new bool[] {false} ;
         P009D2_A144SecUserEmail = new string[] {""} ;
         P009D2_n144SecUserEmail = new bool[] {false} ;
         P009D2_A141SecUserName = new string[] {""} ;
         P009D2_n141SecUserName = new bool[] {false} ;
         P009D2_A375AprovadoresId = new int[1] ;
         AV19Option = "";
         AV21OptionDesc = "";
         P009D3_A133SecUserId = new short[1] ;
         P009D3_n133SecUserId = new bool[] {false} ;
         P009D3_A144SecUserEmail = new string[] {""} ;
         P009D3_n144SecUserEmail = new bool[] {false} ;
         P009D3_A380AprovadoresStatus = new bool[] {false} ;
         P009D3_n380AprovadoresStatus = new bool[] {false} ;
         P009D3_A141SecUserName = new string[] {""} ;
         P009D3_n141SecUserName = new bool[] {false} ;
         P009D3_A375AprovadoresId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovadoreswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009D2_A133SecUserId, P009D2_n133SecUserId, P009D2_A380AprovadoresStatus, P009D2_n380AprovadoresStatus, P009D2_A144SecUserEmail, P009D2_n144SecUserEmail, P009D2_A141SecUserName, P009D2_n141SecUserName, P009D2_A375AprovadoresId
               }
               , new Object[] {
               P009D3_A133SecUserId, P009D3_n133SecUserId, P009D3_A144SecUserEmail, P009D3_n144SecUserEmail, P009D3_A380AprovadoresStatus, P009D3_n380AprovadoresStatus, P009D3_A141SecUserName, P009D3_n141SecUserName, P009D3_A375AprovadoresId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV51TFAprovadoresStatus_Sel ;
      private short AV38DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV48DynamicFiltersOperator3 ;
      private short AV59Aprovadoreswwds_3_dynamicfiltersoperator1 ;
      private short AV64Aprovadoreswwds_8_dynamicfiltersoperator2 ;
      private short AV69Aprovadoreswwds_13_dynamicfiltersoperator3 ;
      private short AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel ;
      private short A133SecUserId ;
      private int AV55GXV1 ;
      private int A375AprovadoresId ;
      private int AV18InsertIndex ;
      private long AV24count ;
      private bool returnInSub ;
      private bool AV52AprovadoresStatus1 ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV53AprovadoresStatus2 ;
      private bool AV46DynamicFiltersEnabled3 ;
      private bool AV54AprovadoresStatus3 ;
      private bool AV60Aprovadoreswwds_4_aprovadoresstatus1 ;
      private bool AV62Aprovadoreswwds_6_dynamicfiltersenabled2 ;
      private bool AV65Aprovadoreswwds_9_aprovadoresstatus2 ;
      private bool AV67Aprovadoreswwds_11_dynamicfiltersenabled3 ;
      private bool AV70Aprovadoreswwds_14_aprovadoresstatus3 ;
      private bool A380AprovadoresStatus ;
      private bool BRK9D2 ;
      private bool n133SecUserId ;
      private bool n380AprovadoresStatus ;
      private bool n144SecUserEmail ;
      private bool n141SecUserName ;
      private bool BRK9D4 ;
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
      private string AV12TFSecUserEmail ;
      private string AV13TFSecUserEmail_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV40SecUserName1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV45SecUserName2 ;
      private string AV47DynamicFiltersSelector3 ;
      private string AV50SecUserName3 ;
      private string AV57Aprovadoreswwds_1_filterfulltext ;
      private string AV58Aprovadoreswwds_2_dynamicfiltersselector1 ;
      private string AV61Aprovadoreswwds_5_secusername1 ;
      private string AV63Aprovadoreswwds_7_dynamicfiltersselector2 ;
      private string AV66Aprovadoreswwds_10_secusername2 ;
      private string AV68Aprovadoreswwds_12_dynamicfiltersselector3 ;
      private string AV71Aprovadoreswwds_15_secusername3 ;
      private string AV72Aprovadoreswwds_16_tfsecusername ;
      private string AV73Aprovadoreswwds_17_tfsecusername_sel ;
      private string AV74Aprovadoreswwds_18_tfsecuseremail ;
      private string AV75Aprovadoreswwds_19_tfsecuseremail_sel ;
      private string lV57Aprovadoreswwds_1_filterfulltext ;
      private string lV61Aprovadoreswwds_5_secusername1 ;
      private string lV66Aprovadoreswwds_10_secusername2 ;
      private string lV71Aprovadoreswwds_15_secusername3 ;
      private string lV72Aprovadoreswwds_16_tfsecusername ;
      private string lV74Aprovadoreswwds_18_tfsecuseremail ;
      private string A141SecUserName ;
      private string A144SecUserEmail ;
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
      private short[] P009D2_A133SecUserId ;
      private bool[] P009D2_n133SecUserId ;
      private bool[] P009D2_A380AprovadoresStatus ;
      private bool[] P009D2_n380AprovadoresStatus ;
      private string[] P009D2_A144SecUserEmail ;
      private bool[] P009D2_n144SecUserEmail ;
      private string[] P009D2_A141SecUserName ;
      private bool[] P009D2_n141SecUserName ;
      private int[] P009D2_A375AprovadoresId ;
      private short[] P009D3_A133SecUserId ;
      private bool[] P009D3_n133SecUserId ;
      private string[] P009D3_A144SecUserEmail ;
      private bool[] P009D3_n144SecUserEmail ;
      private bool[] P009D3_A380AprovadoresStatus ;
      private bool[] P009D3_n380AprovadoresStatus ;
      private string[] P009D3_A141SecUserName ;
      private bool[] P009D3_n141SecUserName ;
      private int[] P009D3_A375AprovadoresId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class aprovadoreswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009D2( IGxContext context ,
                                             string AV57Aprovadoreswwds_1_filterfulltext ,
                                             string AV58Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                             bool AV60Aprovadoreswwds_4_aprovadoresstatus1 ,
                                             short AV59Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                             string AV61Aprovadoreswwds_5_secusername1 ,
                                             bool AV62Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                             string AV63Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                             bool AV65Aprovadoreswwds_9_aprovadoresstatus2 ,
                                             short AV64Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                             string AV66Aprovadoreswwds_10_secusername2 ,
                                             bool AV67Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                             string AV68Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                             bool AV70Aprovadoreswwds_14_aprovadoresstatus3 ,
                                             short AV69Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                             string AV71Aprovadoreswwds_15_secusername3 ,
                                             string AV73Aprovadoreswwds_17_tfsecusername_sel ,
                                             string AV72Aprovadoreswwds_16_tfsecusername ,
                                             string AV75Aprovadoreswwds_19_tfsecuseremail_sel ,
                                             string AV74Aprovadoreswwds_18_tfsecuseremail ,
                                             short AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A380AprovadoresStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T1.AprovadoresStatus, T2.SecUserEmail, T2.SecUserName, T1.AprovadoresId FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV57Aprovadoreswwds_1_filterfulltext) or ( T2.SecUserEmail like '%' || :lV57Aprovadoreswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Aprovadoreswwds_2_dynamicfiltersselector1, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV60Aprovadoreswwds_4_aprovadoresstatus1) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV60Aprovadoreswwds_4_aprovadoresstatus1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Aprovadoreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV61Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Aprovadoreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV61Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV62Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Aprovadoreswwds_7_dynamicfiltersselector2, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV65Aprovadoreswwds_9_aprovadoresstatus2) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV65Aprovadoreswwds_9_aprovadoresstatus2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV62Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Aprovadoreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV62Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Aprovadoreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV67Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Aprovadoreswwds_12_dynamicfiltersselector3, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV70Aprovadoreswwds_14_aprovadoresstatus3) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV70Aprovadoreswwds_14_aprovadoresstatus3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV67Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Aprovadoreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV67Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Aprovadoreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV71Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Aprovadoreswwds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Aprovadoreswwds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV72Aprovadoreswwds_16_tfsecusername)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Aprovadoreswwds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV73Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV73Aprovadoreswwds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Aprovadoreswwds_19_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Aprovadoreswwds_18_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail like :lV74Aprovadoreswwds_18_tfsecuseremail)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Aprovadoreswwds_19_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV75Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail = ( :AV75Aprovadoreswwds_19_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV75Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T2.SecUserEmail))=0))");
         }
         if ( AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = TRUE)");
         }
         if ( AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009D3( IGxContext context ,
                                             string AV57Aprovadoreswwds_1_filterfulltext ,
                                             string AV58Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                             bool AV60Aprovadoreswwds_4_aprovadoresstatus1 ,
                                             short AV59Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                             string AV61Aprovadoreswwds_5_secusername1 ,
                                             bool AV62Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                             string AV63Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                             bool AV65Aprovadoreswwds_9_aprovadoresstatus2 ,
                                             short AV64Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                             string AV66Aprovadoreswwds_10_secusername2 ,
                                             bool AV67Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                             string AV68Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                             bool AV70Aprovadoreswwds_14_aprovadoresstatus3 ,
                                             short AV69Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                             string AV71Aprovadoreswwds_15_secusername3 ,
                                             string AV73Aprovadoreswwds_17_tfsecusername_sel ,
                                             string AV72Aprovadoreswwds_16_tfsecusername ,
                                             string AV75Aprovadoreswwds_19_tfsecuseremail_sel ,
                                             string AV74Aprovadoreswwds_18_tfsecuseremail ,
                                             short AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A380AprovadoresStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T2.SecUserEmail, T1.AprovadoresStatus, T2.SecUserName, T1.AprovadoresId FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Aprovadoreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV57Aprovadoreswwds_1_filterfulltext) or ( T2.SecUserEmail like '%' || :lV57Aprovadoreswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Aprovadoreswwds_2_dynamicfiltersselector1, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV60Aprovadoreswwds_4_aprovadoresstatus1) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV60Aprovadoreswwds_4_aprovadoresstatus1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Aprovadoreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV61Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Aprovadoreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV61Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Aprovadoreswwds_7_dynamicfiltersselector2, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV65Aprovadoreswwds_9_aprovadoresstatus2) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV65Aprovadoreswwds_9_aprovadoresstatus2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV62Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Aprovadoreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV62Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Aprovadoreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Aprovadoreswwds_12_dynamicfiltersselector3, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV70Aprovadoreswwds_14_aprovadoresstatus3) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV70Aprovadoreswwds_14_aprovadoresstatus3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Aprovadoreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Aprovadoreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV71Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Aprovadoreswwds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Aprovadoreswwds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV72Aprovadoreswwds_16_tfsecusername)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Aprovadoreswwds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV73Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV73Aprovadoreswwds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Aprovadoreswwds_19_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Aprovadoreswwds_18_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail like :lV74Aprovadoreswwds_18_tfsecuseremail)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Aprovadoreswwds_19_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV75Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail = ( :AV75Aprovadoreswwds_19_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV75Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T2.SecUserEmail))=0))");
         }
         if ( AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = TRUE)");
         }
         if ( AV76Aprovadoreswwds_20_tfaprovadoresstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.SecUserEmail";
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
                     return conditional_P009D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
               case 1 :
                     return conditional_P009D3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP009D2;
          prmP009D2 = new Object[] {
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV60Aprovadoreswwds_4_aprovadoresstatus1",GXType.Boolean,4,0) ,
          new ParDef("lV61Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV65Aprovadoreswwds_9_aprovadoresstatus2",GXType.Boolean,4,0) ,
          new ParDef("lV66Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV70Aprovadoreswwds_14_aprovadoresstatus3",GXType.Boolean,4,0) ,
          new ParDef("lV71Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV72Aprovadoreswwds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV73Aprovadoreswwds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV74Aprovadoreswwds_18_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV75Aprovadoreswwds_19_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP009D3;
          prmP009D3 = new Object[] {
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV60Aprovadoreswwds_4_aprovadoresstatus1",GXType.Boolean,4,0) ,
          new ParDef("lV61Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV65Aprovadoreswwds_9_aprovadoresstatus2",GXType.Boolean,4,0) ,
          new ParDef("lV66Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV70Aprovadoreswwds_14_aprovadoresstatus3",GXType.Boolean,4,0) ,
          new ParDef("lV71Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV72Aprovadoreswwds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV73Aprovadoreswwds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV74Aprovadoreswwds_18_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV75Aprovadoreswwds_19_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009D3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
