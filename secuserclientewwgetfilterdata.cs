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
   public class secuserclientewwgetfilterdata : GXProcedure
   {
      public secuserclientewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserclientewwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SECUSERFULLNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERFULLNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SECUSEREMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSEREMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("SecUserClienteWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserClienteWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("SecUserClienteWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV10TFSecUserFullName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV11TFSecUserFullName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV50TFSecUserName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV51TFSecUserName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV12TFSecUserEmail = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV13TFSecUserEmail_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV14TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "SECUSERFULLNAME") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40SecUserFullName1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV52SecUserName1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "SECUSERFULLNAME") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44SecUserFullName2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV53SecUserName2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "SECUSERFULLNAME") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48SecUserFullName3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV54SecUserName3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERFULLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecUserFullName = AV15SearchTxt;
         AV11TFSecUserFullName_Sel = "";
         AV57Secuserclientewwds_1_filterfulltext = AV37FilterFullText;
         AV58Secuserclientewwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Secuserclientewwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Secuserclientewwds_4_secuserfullname1 = AV40SecUserFullName1;
         AV61Secuserclientewwds_5_secusername1 = AV52SecUserName1;
         AV62Secuserclientewwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Secuserclientewwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Secuserclientewwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Secuserclientewwds_9_secuserfullname2 = AV44SecUserFullName2;
         AV66Secuserclientewwds_10_secusername2 = AV53SecUserName2;
         AV67Secuserclientewwds_11_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV68Secuserclientewwds_12_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV69Secuserclientewwds_13_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV70Secuserclientewwds_14_secuserfullname3 = AV48SecUserFullName3;
         AV71Secuserclientewwds_15_secusername3 = AV54SecUserName3;
         AV72Secuserclientewwds_16_tfsecuserfullname = AV10TFSecUserFullName;
         AV73Secuserclientewwds_17_tfsecuserfullname_sel = AV11TFSecUserFullName_Sel;
         AV74Secuserclientewwds_18_tfsecusername = AV50TFSecUserName;
         AV75Secuserclientewwds_19_tfsecusername_sel = AV51TFSecUserName_Sel;
         AV76Secuserclientewwds_20_tfsecuseremail = AV12TFSecUserEmail;
         AV77Secuserclientewwds_21_tfsecuseremail_sel = AV13TFSecUserEmail_Sel;
         AV78Secuserclientewwds_22_tfsecuserstatus_sel = AV14TFSecUserStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Secuserclientewwds_1_filterfulltext ,
                                              AV58Secuserclientewwds_2_dynamicfiltersselector1 ,
                                              AV59Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                              AV60Secuserclientewwds_4_secuserfullname1 ,
                                              AV61Secuserclientewwds_5_secusername1 ,
                                              AV62Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                              AV63Secuserclientewwds_7_dynamicfiltersselector2 ,
                                              AV64Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                              AV65Secuserclientewwds_9_secuserfullname2 ,
                                              AV66Secuserclientewwds_10_secusername2 ,
                                              AV67Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                              AV68Secuserclientewwds_12_dynamicfiltersselector3 ,
                                              AV69Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                              AV70Secuserclientewwds_14_secuserfullname3 ,
                                              AV71Secuserclientewwds_15_secusername3 ,
                                              AV73Secuserclientewwds_17_tfsecuserfullname_sel ,
                                              AV72Secuserclientewwds_16_tfsecuserfullname ,
                                              AV75Secuserclientewwds_19_tfsecusername_sel ,
                                              AV74Secuserclientewwds_18_tfsecusername ,
                                              AV77Secuserclientewwds_21_tfsecuseremail_sel ,
                                              AV76Secuserclientewwds_20_tfsecuseremail ,
                                              AV78Secuserclientewwds_22_tfsecuserstatus_sel ,
                                              A143SecUserFullName ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A210SecUserClienteId ,
                                              AV49SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV60Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1), "%", "");
         lV60Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1), "%", "");
         lV61Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1), "%", "");
         lV61Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1), "%", "");
         lV65Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2), "%", "");
         lV65Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2), "%", "");
         lV66Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2), "%", "");
         lV66Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2), "%", "");
         lV70Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3), "%", "");
         lV70Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3), "%", "");
         lV71Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3), "%", "");
         lV71Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3), "%", "");
         lV72Secuserclientewwds_16_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV72Secuserclientewwds_16_tfsecuserfullname), "%", "");
         lV74Secuserclientewwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV74Secuserclientewwds_18_tfsecusername), "%", "");
         lV76Secuserclientewwds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV76Secuserclientewwds_20_tfsecuseremail), "%", "");
         /* Using cursor P006L2 */
         pr_default.execute(0, new Object[] {AV49SecUserClienteId, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV60Secuserclientewwds_4_secuserfullname1, lV60Secuserclientewwds_4_secuserfullname1, lV61Secuserclientewwds_5_secusername1, lV61Secuserclientewwds_5_secusername1, lV65Secuserclientewwds_9_secuserfullname2, lV65Secuserclientewwds_9_secuserfullname2, lV66Secuserclientewwds_10_secusername2, lV66Secuserclientewwds_10_secusername2, lV70Secuserclientewwds_14_secuserfullname3, lV70Secuserclientewwds_14_secuserfullname3, lV71Secuserclientewwds_15_secusername3, lV71Secuserclientewwds_15_secusername3, lV72Secuserclientewwds_16_tfsecuserfullname, AV73Secuserclientewwds_17_tfsecuserfullname_sel, lV74Secuserclientewwds_18_tfsecusername, AV75Secuserclientewwds_19_tfsecusername_sel, lV76Secuserclientewwds_20_tfsecuseremail, AV77Secuserclientewwds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6L2 = false;
            A210SecUserClienteId = P006L2_A210SecUserClienteId[0];
            n210SecUserClienteId = P006L2_n210SecUserClienteId[0];
            A143SecUserFullName = P006L2_A143SecUserFullName[0];
            n143SecUserFullName = P006L2_n143SecUserFullName[0];
            A150SecUserStatus = P006L2_A150SecUserStatus[0];
            n150SecUserStatus = P006L2_n150SecUserStatus[0];
            A144SecUserEmail = P006L2_A144SecUserEmail[0];
            n144SecUserEmail = P006L2_n144SecUserEmail[0];
            A141SecUserName = P006L2_A141SecUserName[0];
            n141SecUserName = P006L2_n141SecUserName[0];
            A133SecUserId = P006L2_A133SecUserId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006L2_A143SecUserFullName[0], A143SecUserFullName) == 0 ) )
            {
               BRK6L2 = false;
               A133SecUserId = P006L2_A133SecUserId[0];
               AV25count = (long)(AV25count+1);
               BRK6L2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? "<#Empty#>" : A143SecUserFullName);
               AV22OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")));
               AV21Options.Add(AV20Option, 0);
               AV23OptionsDesc.Add(AV22OptionDesc, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6L2 )
            {
               BRK6L2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV50TFSecUserName = AV15SearchTxt;
         AV51TFSecUserName_Sel = "";
         AV57Secuserclientewwds_1_filterfulltext = AV37FilterFullText;
         AV58Secuserclientewwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Secuserclientewwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Secuserclientewwds_4_secuserfullname1 = AV40SecUserFullName1;
         AV61Secuserclientewwds_5_secusername1 = AV52SecUserName1;
         AV62Secuserclientewwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Secuserclientewwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Secuserclientewwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Secuserclientewwds_9_secuserfullname2 = AV44SecUserFullName2;
         AV66Secuserclientewwds_10_secusername2 = AV53SecUserName2;
         AV67Secuserclientewwds_11_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV68Secuserclientewwds_12_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV69Secuserclientewwds_13_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV70Secuserclientewwds_14_secuserfullname3 = AV48SecUserFullName3;
         AV71Secuserclientewwds_15_secusername3 = AV54SecUserName3;
         AV72Secuserclientewwds_16_tfsecuserfullname = AV10TFSecUserFullName;
         AV73Secuserclientewwds_17_tfsecuserfullname_sel = AV11TFSecUserFullName_Sel;
         AV74Secuserclientewwds_18_tfsecusername = AV50TFSecUserName;
         AV75Secuserclientewwds_19_tfsecusername_sel = AV51TFSecUserName_Sel;
         AV76Secuserclientewwds_20_tfsecuseremail = AV12TFSecUserEmail;
         AV77Secuserclientewwds_21_tfsecuseremail_sel = AV13TFSecUserEmail_Sel;
         AV78Secuserclientewwds_22_tfsecuserstatus_sel = AV14TFSecUserStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Secuserclientewwds_1_filterfulltext ,
                                              AV58Secuserclientewwds_2_dynamicfiltersselector1 ,
                                              AV59Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                              AV60Secuserclientewwds_4_secuserfullname1 ,
                                              AV61Secuserclientewwds_5_secusername1 ,
                                              AV62Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                              AV63Secuserclientewwds_7_dynamicfiltersselector2 ,
                                              AV64Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                              AV65Secuserclientewwds_9_secuserfullname2 ,
                                              AV66Secuserclientewwds_10_secusername2 ,
                                              AV67Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                              AV68Secuserclientewwds_12_dynamicfiltersselector3 ,
                                              AV69Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                              AV70Secuserclientewwds_14_secuserfullname3 ,
                                              AV71Secuserclientewwds_15_secusername3 ,
                                              AV73Secuserclientewwds_17_tfsecuserfullname_sel ,
                                              AV72Secuserclientewwds_16_tfsecuserfullname ,
                                              AV75Secuserclientewwds_19_tfsecusername_sel ,
                                              AV74Secuserclientewwds_18_tfsecusername ,
                                              AV77Secuserclientewwds_21_tfsecuseremail_sel ,
                                              AV76Secuserclientewwds_20_tfsecuseremail ,
                                              AV78Secuserclientewwds_22_tfsecuserstatus_sel ,
                                              A143SecUserFullName ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A210SecUserClienteId ,
                                              AV49SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV60Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1), "%", "");
         lV60Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1), "%", "");
         lV61Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1), "%", "");
         lV61Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1), "%", "");
         lV65Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2), "%", "");
         lV65Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2), "%", "");
         lV66Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2), "%", "");
         lV66Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2), "%", "");
         lV70Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3), "%", "");
         lV70Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3), "%", "");
         lV71Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3), "%", "");
         lV71Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3), "%", "");
         lV72Secuserclientewwds_16_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV72Secuserclientewwds_16_tfsecuserfullname), "%", "");
         lV74Secuserclientewwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV74Secuserclientewwds_18_tfsecusername), "%", "");
         lV76Secuserclientewwds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV76Secuserclientewwds_20_tfsecuseremail), "%", "");
         /* Using cursor P006L3 */
         pr_default.execute(1, new Object[] {AV49SecUserClienteId, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV60Secuserclientewwds_4_secuserfullname1, lV60Secuserclientewwds_4_secuserfullname1, lV61Secuserclientewwds_5_secusername1, lV61Secuserclientewwds_5_secusername1, lV65Secuserclientewwds_9_secuserfullname2, lV65Secuserclientewwds_9_secuserfullname2, lV66Secuserclientewwds_10_secusername2, lV66Secuserclientewwds_10_secusername2, lV70Secuserclientewwds_14_secuserfullname3, lV70Secuserclientewwds_14_secuserfullname3, lV71Secuserclientewwds_15_secusername3, lV71Secuserclientewwds_15_secusername3, lV72Secuserclientewwds_16_tfsecuserfullname, AV73Secuserclientewwds_17_tfsecuserfullname_sel, lV74Secuserclientewwds_18_tfsecusername, AV75Secuserclientewwds_19_tfsecusername_sel, lV76Secuserclientewwds_20_tfsecuseremail, AV77Secuserclientewwds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6L4 = false;
            A210SecUserClienteId = P006L3_A210SecUserClienteId[0];
            n210SecUserClienteId = P006L3_n210SecUserClienteId[0];
            A141SecUserName = P006L3_A141SecUserName[0];
            n141SecUserName = P006L3_n141SecUserName[0];
            A150SecUserStatus = P006L3_A150SecUserStatus[0];
            n150SecUserStatus = P006L3_n150SecUserStatus[0];
            A144SecUserEmail = P006L3_A144SecUserEmail[0];
            n144SecUserEmail = P006L3_n144SecUserEmail[0];
            A143SecUserFullName = P006L3_A143SecUserFullName[0];
            n143SecUserFullName = P006L3_n143SecUserFullName[0];
            A133SecUserId = P006L3_A133SecUserId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006L3_A141SecUserName[0], A141SecUserName) == 0 ) )
            {
               BRK6L4 = false;
               A133SecUserId = P006L3_A133SecUserId[0];
               AV25count = (long)(AV25count+1);
               BRK6L4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? "<#Empty#>" : A141SecUserName);
               AV22OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")));
               AV21Options.Add(AV20Option, 0);
               AV23OptionsDesc.Add(AV22OptionDesc, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6L4 )
            {
               BRK6L4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSECUSEREMAILOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecUserEmail = AV15SearchTxt;
         AV13TFSecUserEmail_Sel = "";
         AV57Secuserclientewwds_1_filterfulltext = AV37FilterFullText;
         AV58Secuserclientewwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Secuserclientewwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Secuserclientewwds_4_secuserfullname1 = AV40SecUserFullName1;
         AV61Secuserclientewwds_5_secusername1 = AV52SecUserName1;
         AV62Secuserclientewwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Secuserclientewwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Secuserclientewwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Secuserclientewwds_9_secuserfullname2 = AV44SecUserFullName2;
         AV66Secuserclientewwds_10_secusername2 = AV53SecUserName2;
         AV67Secuserclientewwds_11_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV68Secuserclientewwds_12_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV69Secuserclientewwds_13_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV70Secuserclientewwds_14_secuserfullname3 = AV48SecUserFullName3;
         AV71Secuserclientewwds_15_secusername3 = AV54SecUserName3;
         AV72Secuserclientewwds_16_tfsecuserfullname = AV10TFSecUserFullName;
         AV73Secuserclientewwds_17_tfsecuserfullname_sel = AV11TFSecUserFullName_Sel;
         AV74Secuserclientewwds_18_tfsecusername = AV50TFSecUserName;
         AV75Secuserclientewwds_19_tfsecusername_sel = AV51TFSecUserName_Sel;
         AV76Secuserclientewwds_20_tfsecuseremail = AV12TFSecUserEmail;
         AV77Secuserclientewwds_21_tfsecuseremail_sel = AV13TFSecUserEmail_Sel;
         AV78Secuserclientewwds_22_tfsecuserstatus_sel = AV14TFSecUserStatus_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV57Secuserclientewwds_1_filterfulltext ,
                                              AV58Secuserclientewwds_2_dynamicfiltersselector1 ,
                                              AV59Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                              AV60Secuserclientewwds_4_secuserfullname1 ,
                                              AV61Secuserclientewwds_5_secusername1 ,
                                              AV62Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                              AV63Secuserclientewwds_7_dynamicfiltersselector2 ,
                                              AV64Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                              AV65Secuserclientewwds_9_secuserfullname2 ,
                                              AV66Secuserclientewwds_10_secusername2 ,
                                              AV67Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                              AV68Secuserclientewwds_12_dynamicfiltersselector3 ,
                                              AV69Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                              AV70Secuserclientewwds_14_secuserfullname3 ,
                                              AV71Secuserclientewwds_15_secusername3 ,
                                              AV73Secuserclientewwds_17_tfsecuserfullname_sel ,
                                              AV72Secuserclientewwds_16_tfsecuserfullname ,
                                              AV75Secuserclientewwds_19_tfsecusername_sel ,
                                              AV74Secuserclientewwds_18_tfsecusername ,
                                              AV77Secuserclientewwds_21_tfsecuseremail_sel ,
                                              AV76Secuserclientewwds_20_tfsecuseremail ,
                                              AV78Secuserclientewwds_22_tfsecuserstatus_sel ,
                                              A143SecUserFullName ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A210SecUserClienteId ,
                                              AV49SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV57Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext), "%", "");
         lV60Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1), "%", "");
         lV60Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1), "%", "");
         lV61Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1), "%", "");
         lV61Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1), "%", "");
         lV65Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2), "%", "");
         lV65Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2), "%", "");
         lV66Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2), "%", "");
         lV66Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2), "%", "");
         lV70Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3), "%", "");
         lV70Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3), "%", "");
         lV71Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3), "%", "");
         lV71Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3), "%", "");
         lV72Secuserclientewwds_16_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV72Secuserclientewwds_16_tfsecuserfullname), "%", "");
         lV74Secuserclientewwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV74Secuserclientewwds_18_tfsecusername), "%", "");
         lV76Secuserclientewwds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV76Secuserclientewwds_20_tfsecuseremail), "%", "");
         /* Using cursor P006L4 */
         pr_default.execute(2, new Object[] {AV49SecUserClienteId, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV57Secuserclientewwds_1_filterfulltext, lV60Secuserclientewwds_4_secuserfullname1, lV60Secuserclientewwds_4_secuserfullname1, lV61Secuserclientewwds_5_secusername1, lV61Secuserclientewwds_5_secusername1, lV65Secuserclientewwds_9_secuserfullname2, lV65Secuserclientewwds_9_secuserfullname2, lV66Secuserclientewwds_10_secusername2, lV66Secuserclientewwds_10_secusername2, lV70Secuserclientewwds_14_secuserfullname3, lV70Secuserclientewwds_14_secuserfullname3, lV71Secuserclientewwds_15_secusername3, lV71Secuserclientewwds_15_secusername3, lV72Secuserclientewwds_16_tfsecuserfullname, AV73Secuserclientewwds_17_tfsecuserfullname_sel, lV74Secuserclientewwds_18_tfsecusername, AV75Secuserclientewwds_19_tfsecusername_sel, lV76Secuserclientewwds_20_tfsecuseremail, AV77Secuserclientewwds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6L6 = false;
            A210SecUserClienteId = P006L4_A210SecUserClienteId[0];
            n210SecUserClienteId = P006L4_n210SecUserClienteId[0];
            A144SecUserEmail = P006L4_A144SecUserEmail[0];
            n144SecUserEmail = P006L4_n144SecUserEmail[0];
            A150SecUserStatus = P006L4_A150SecUserStatus[0];
            n150SecUserStatus = P006L4_n150SecUserStatus[0];
            A141SecUserName = P006L4_A141SecUserName[0];
            n141SecUserName = P006L4_n141SecUserName[0];
            A143SecUserFullName = P006L4_A143SecUserFullName[0];
            n143SecUserFullName = P006L4_n143SecUserFullName[0];
            A133SecUserId = P006L4_A133SecUserId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006L4_A144SecUserEmail[0], A144SecUserEmail) == 0 ) )
            {
               BRK6L6 = false;
               A133SecUserId = P006L4_A133SecUserId[0];
               AV25count = (long)(AV25count+1);
               BRK6L6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? "<#Empty#>" : A144SecUserEmail);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6L6 )
            {
               BRK6L6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV10TFSecUserFullName = "";
         AV11TFSecUserFullName_Sel = "";
         AV50TFSecUserName = "";
         AV51TFSecUserName_Sel = "";
         AV12TFSecUserEmail = "";
         AV13TFSecUserEmail_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40SecUserFullName1 = "";
         AV52SecUserName1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44SecUserFullName2 = "";
         AV53SecUserName2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48SecUserFullName3 = "";
         AV54SecUserName3 = "";
         AV57Secuserclientewwds_1_filterfulltext = "";
         AV58Secuserclientewwds_2_dynamicfiltersselector1 = "";
         AV60Secuserclientewwds_4_secuserfullname1 = "";
         AV61Secuserclientewwds_5_secusername1 = "";
         AV63Secuserclientewwds_7_dynamicfiltersselector2 = "";
         AV65Secuserclientewwds_9_secuserfullname2 = "";
         AV66Secuserclientewwds_10_secusername2 = "";
         AV68Secuserclientewwds_12_dynamicfiltersselector3 = "";
         AV70Secuserclientewwds_14_secuserfullname3 = "";
         AV71Secuserclientewwds_15_secusername3 = "";
         AV72Secuserclientewwds_16_tfsecuserfullname = "";
         AV73Secuserclientewwds_17_tfsecuserfullname_sel = "";
         AV74Secuserclientewwds_18_tfsecusername = "";
         AV75Secuserclientewwds_19_tfsecusername_sel = "";
         AV76Secuserclientewwds_20_tfsecuseremail = "";
         AV77Secuserclientewwds_21_tfsecuseremail_sel = "";
         lV57Secuserclientewwds_1_filterfulltext = "";
         lV60Secuserclientewwds_4_secuserfullname1 = "";
         lV61Secuserclientewwds_5_secusername1 = "";
         lV65Secuserclientewwds_9_secuserfullname2 = "";
         lV66Secuserclientewwds_10_secusername2 = "";
         lV70Secuserclientewwds_14_secuserfullname3 = "";
         lV71Secuserclientewwds_15_secusername3 = "";
         lV72Secuserclientewwds_16_tfsecuserfullname = "";
         lV74Secuserclientewwds_18_tfsecusername = "";
         lV76Secuserclientewwds_20_tfsecuseremail = "";
         A143SecUserFullName = "";
         A141SecUserName = "";
         A144SecUserEmail = "";
         P006L2_A210SecUserClienteId = new short[1] ;
         P006L2_n210SecUserClienteId = new bool[] {false} ;
         P006L2_A143SecUserFullName = new string[] {""} ;
         P006L2_n143SecUserFullName = new bool[] {false} ;
         P006L2_A150SecUserStatus = new bool[] {false} ;
         P006L2_n150SecUserStatus = new bool[] {false} ;
         P006L2_A144SecUserEmail = new string[] {""} ;
         P006L2_n144SecUserEmail = new bool[] {false} ;
         P006L2_A141SecUserName = new string[] {""} ;
         P006L2_n141SecUserName = new bool[] {false} ;
         P006L2_A133SecUserId = new short[1] ;
         AV20Option = "";
         AV22OptionDesc = "";
         P006L3_A210SecUserClienteId = new short[1] ;
         P006L3_n210SecUserClienteId = new bool[] {false} ;
         P006L3_A141SecUserName = new string[] {""} ;
         P006L3_n141SecUserName = new bool[] {false} ;
         P006L3_A150SecUserStatus = new bool[] {false} ;
         P006L3_n150SecUserStatus = new bool[] {false} ;
         P006L3_A144SecUserEmail = new string[] {""} ;
         P006L3_n144SecUserEmail = new bool[] {false} ;
         P006L3_A143SecUserFullName = new string[] {""} ;
         P006L3_n143SecUserFullName = new bool[] {false} ;
         P006L3_A133SecUserId = new short[1] ;
         P006L4_A210SecUserClienteId = new short[1] ;
         P006L4_n210SecUserClienteId = new bool[] {false} ;
         P006L4_A144SecUserEmail = new string[] {""} ;
         P006L4_n144SecUserEmail = new bool[] {false} ;
         P006L4_A150SecUserStatus = new bool[] {false} ;
         P006L4_n150SecUserStatus = new bool[] {false} ;
         P006L4_A141SecUserName = new string[] {""} ;
         P006L4_n141SecUserName = new bool[] {false} ;
         P006L4_A143SecUserFullName = new string[] {""} ;
         P006L4_n143SecUserFullName = new bool[] {false} ;
         P006L4_A133SecUserId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserclientewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006L2_A210SecUserClienteId, P006L2_n210SecUserClienteId, P006L2_A143SecUserFullName, P006L2_n143SecUserFullName, P006L2_A150SecUserStatus, P006L2_n150SecUserStatus, P006L2_A144SecUserEmail, P006L2_n144SecUserEmail, P006L2_A141SecUserName, P006L2_n141SecUserName,
               P006L2_A133SecUserId
               }
               , new Object[] {
               P006L3_A210SecUserClienteId, P006L3_n210SecUserClienteId, P006L3_A141SecUserName, P006L3_n141SecUserName, P006L3_A150SecUserStatus, P006L3_n150SecUserStatus, P006L3_A144SecUserEmail, P006L3_n144SecUserEmail, P006L3_A143SecUserFullName, P006L3_n143SecUserFullName,
               P006L3_A133SecUserId
               }
               , new Object[] {
               P006L4_A210SecUserClienteId, P006L4_n210SecUserClienteId, P006L4_A144SecUserEmail, P006L4_n144SecUserEmail, P006L4_A150SecUserStatus, P006L4_n150SecUserStatus, P006L4_A141SecUserName, P006L4_n141SecUserName, P006L4_A143SecUserFullName, P006L4_n143SecUserFullName,
               P006L4_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV14TFSecUserStatus_Sel ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV59Secuserclientewwds_3_dynamicfiltersoperator1 ;
      private short AV64Secuserclientewwds_8_dynamicfiltersoperator2 ;
      private short AV69Secuserclientewwds_13_dynamicfiltersoperator3 ;
      private short AV78Secuserclientewwds_22_tfsecuserstatus_sel ;
      private short A210SecUserClienteId ;
      private short AV49SecUserClienteId ;
      private short A133SecUserId ;
      private int AV55GXV1 ;
      private long AV25count ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV62Secuserclientewwds_6_dynamicfiltersenabled2 ;
      private bool AV67Secuserclientewwds_11_dynamicfiltersenabled3 ;
      private bool A150SecUserStatus ;
      private bool BRK6L2 ;
      private bool n210SecUserClienteId ;
      private bool n143SecUserFullName ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n141SecUserName ;
      private bool BRK6L4 ;
      private bool BRK6L6 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV10TFSecUserFullName ;
      private string AV11TFSecUserFullName_Sel ;
      private string AV50TFSecUserName ;
      private string AV51TFSecUserName_Sel ;
      private string AV12TFSecUserEmail ;
      private string AV13TFSecUserEmail_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40SecUserFullName1 ;
      private string AV52SecUserName1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44SecUserFullName2 ;
      private string AV53SecUserName2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48SecUserFullName3 ;
      private string AV54SecUserName3 ;
      private string AV57Secuserclientewwds_1_filterfulltext ;
      private string AV58Secuserclientewwds_2_dynamicfiltersselector1 ;
      private string AV60Secuserclientewwds_4_secuserfullname1 ;
      private string AV61Secuserclientewwds_5_secusername1 ;
      private string AV63Secuserclientewwds_7_dynamicfiltersselector2 ;
      private string AV65Secuserclientewwds_9_secuserfullname2 ;
      private string AV66Secuserclientewwds_10_secusername2 ;
      private string AV68Secuserclientewwds_12_dynamicfiltersselector3 ;
      private string AV70Secuserclientewwds_14_secuserfullname3 ;
      private string AV71Secuserclientewwds_15_secusername3 ;
      private string AV72Secuserclientewwds_16_tfsecuserfullname ;
      private string AV73Secuserclientewwds_17_tfsecuserfullname_sel ;
      private string AV74Secuserclientewwds_18_tfsecusername ;
      private string AV75Secuserclientewwds_19_tfsecusername_sel ;
      private string AV76Secuserclientewwds_20_tfsecuseremail ;
      private string AV77Secuserclientewwds_21_tfsecuseremail_sel ;
      private string lV57Secuserclientewwds_1_filterfulltext ;
      private string lV60Secuserclientewwds_4_secuserfullname1 ;
      private string lV61Secuserclientewwds_5_secusername1 ;
      private string lV65Secuserclientewwds_9_secuserfullname2 ;
      private string lV66Secuserclientewwds_10_secusername2 ;
      private string lV70Secuserclientewwds_14_secuserfullname3 ;
      private string lV71Secuserclientewwds_15_secusername3 ;
      private string lV72Secuserclientewwds_16_tfsecuserfullname ;
      private string lV74Secuserclientewwds_18_tfsecusername ;
      private string lV76Secuserclientewwds_20_tfsecuseremail ;
      private string A143SecUserFullName ;
      private string A141SecUserName ;
      private string A144SecUserEmail ;
      private string AV20Option ;
      private string AV22OptionDesc ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P006L2_A210SecUserClienteId ;
      private bool[] P006L2_n210SecUserClienteId ;
      private string[] P006L2_A143SecUserFullName ;
      private bool[] P006L2_n143SecUserFullName ;
      private bool[] P006L2_A150SecUserStatus ;
      private bool[] P006L2_n150SecUserStatus ;
      private string[] P006L2_A144SecUserEmail ;
      private bool[] P006L2_n144SecUserEmail ;
      private string[] P006L2_A141SecUserName ;
      private bool[] P006L2_n141SecUserName ;
      private short[] P006L2_A133SecUserId ;
      private short[] P006L3_A210SecUserClienteId ;
      private bool[] P006L3_n210SecUserClienteId ;
      private string[] P006L3_A141SecUserName ;
      private bool[] P006L3_n141SecUserName ;
      private bool[] P006L3_A150SecUserStatus ;
      private bool[] P006L3_n150SecUserStatus ;
      private string[] P006L3_A144SecUserEmail ;
      private bool[] P006L3_n144SecUserEmail ;
      private string[] P006L3_A143SecUserFullName ;
      private bool[] P006L3_n143SecUserFullName ;
      private short[] P006L3_A133SecUserId ;
      private short[] P006L4_A210SecUserClienteId ;
      private bool[] P006L4_n210SecUserClienteId ;
      private string[] P006L4_A144SecUserEmail ;
      private bool[] P006L4_n144SecUserEmail ;
      private bool[] P006L4_A150SecUserStatus ;
      private bool[] P006L4_n150SecUserStatus ;
      private string[] P006L4_A141SecUserName ;
      private bool[] P006L4_n141SecUserName ;
      private string[] P006L4_A143SecUserFullName ;
      private bool[] P006L4_n143SecUserFullName ;
      private short[] P006L4_A133SecUserId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secuserclientewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006L2( IGxContext context ,
                                             string AV57Secuserclientewwds_1_filterfulltext ,
                                             string AV58Secuserclientewwds_2_dynamicfiltersselector1 ,
                                             short AV59Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV60Secuserclientewwds_4_secuserfullname1 ,
                                             string AV61Secuserclientewwds_5_secusername1 ,
                                             bool AV62Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                             string AV63Secuserclientewwds_7_dynamicfiltersselector2 ,
                                             short AV64Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                             string AV65Secuserclientewwds_9_secuserfullname2 ,
                                             string AV66Secuserclientewwds_10_secusername2 ,
                                             bool AV67Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                             string AV68Secuserclientewwds_12_dynamicfiltersselector3 ,
                                             short AV69Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                             string AV70Secuserclientewwds_14_secuserfullname3 ,
                                             string AV71Secuserclientewwds_15_secusername3 ,
                                             string AV73Secuserclientewwds_17_tfsecuserfullname_sel ,
                                             string AV72Secuserclientewwds_16_tfsecuserfullname ,
                                             string AV75Secuserclientewwds_19_tfsecusername_sel ,
                                             string AV74Secuserclientewwds_18_tfsecusername ,
                                             string AV77Secuserclientewwds_21_tfsecuseremail_sel ,
                                             string AV76Secuserclientewwds_20_tfsecuseremail ,
                                             short AV78Secuserclientewwds_22_tfsecuserstatus_sel ,
                                             string A143SecUserFullName ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             short A210SecUserClienteId ,
                                             short AV49SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SecUserClienteId, SecUserFullName, SecUserStatus, SecUserEmail, SecUserName, SecUserId FROM SecUser";
         AddWhere(sWhereString, "(SecUserClienteId = :AV49SecUserClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserFullName like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( SecUserName like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Secuserclientewwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Secuserclientewwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV60Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV60Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV61Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV61Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV65Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV65Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV66Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV66Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV70Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV70Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV71Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV71Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserclientewwds_17_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserclientewwds_16_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV72Secuserclientewwds_16_tfsecuserfullname)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserclientewwds_17_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV73Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV73Secuserclientewwds_17_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Secuserclientewwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Secuserclientewwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV74Secuserclientewwds_18_tfsecusername)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Secuserclientewwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV75Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV75Secuserclientewwds_19_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Secuserclientewwds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV76Secuserclientewwds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV77Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV77Secuserclientewwds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV78Secuserclientewwds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV78Secuserclientewwds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecUserFullName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006L3( IGxContext context ,
                                             string AV57Secuserclientewwds_1_filterfulltext ,
                                             string AV58Secuserclientewwds_2_dynamicfiltersselector1 ,
                                             short AV59Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV60Secuserclientewwds_4_secuserfullname1 ,
                                             string AV61Secuserclientewwds_5_secusername1 ,
                                             bool AV62Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                             string AV63Secuserclientewwds_7_dynamicfiltersselector2 ,
                                             short AV64Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                             string AV65Secuserclientewwds_9_secuserfullname2 ,
                                             string AV66Secuserclientewwds_10_secusername2 ,
                                             bool AV67Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                             string AV68Secuserclientewwds_12_dynamicfiltersselector3 ,
                                             short AV69Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                             string AV70Secuserclientewwds_14_secuserfullname3 ,
                                             string AV71Secuserclientewwds_15_secusername3 ,
                                             string AV73Secuserclientewwds_17_tfsecuserfullname_sel ,
                                             string AV72Secuserclientewwds_16_tfsecuserfullname ,
                                             string AV75Secuserclientewwds_19_tfsecusername_sel ,
                                             string AV74Secuserclientewwds_18_tfsecusername ,
                                             string AV77Secuserclientewwds_21_tfsecuseremail_sel ,
                                             string AV76Secuserclientewwds_20_tfsecuseremail ,
                                             short AV78Secuserclientewwds_22_tfsecuserstatus_sel ,
                                             string A143SecUserFullName ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             short A210SecUserClienteId ,
                                             short AV49SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecUserClienteId, SecUserName, SecUserStatus, SecUserEmail, SecUserFullName, SecUserId FROM SecUser";
         AddWhere(sWhereString, "(SecUserClienteId = :AV49SecUserClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserFullName like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( SecUserName like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Secuserclientewwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Secuserclientewwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV60Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV60Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV61Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV61Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV65Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV65Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV66Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV66Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV70Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV70Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV71Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV71Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserclientewwds_17_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserclientewwds_16_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV72Secuserclientewwds_16_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserclientewwds_17_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV73Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV73Secuserclientewwds_17_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Secuserclientewwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Secuserclientewwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV74Secuserclientewwds_18_tfsecusername)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Secuserclientewwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV75Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV75Secuserclientewwds_19_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Secuserclientewwds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV76Secuserclientewwds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV77Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV77Secuserclientewwds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV78Secuserclientewwds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV78Secuserclientewwds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecUserName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006L4( IGxContext context ,
                                             string AV57Secuserclientewwds_1_filterfulltext ,
                                             string AV58Secuserclientewwds_2_dynamicfiltersselector1 ,
                                             short AV59Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV60Secuserclientewwds_4_secuserfullname1 ,
                                             string AV61Secuserclientewwds_5_secusername1 ,
                                             bool AV62Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                             string AV63Secuserclientewwds_7_dynamicfiltersselector2 ,
                                             short AV64Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                             string AV65Secuserclientewwds_9_secuserfullname2 ,
                                             string AV66Secuserclientewwds_10_secusername2 ,
                                             bool AV67Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                             string AV68Secuserclientewwds_12_dynamicfiltersselector3 ,
                                             short AV69Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                             string AV70Secuserclientewwds_14_secuserfullname3 ,
                                             string AV71Secuserclientewwds_15_secusername3 ,
                                             string AV73Secuserclientewwds_17_tfsecuserfullname_sel ,
                                             string AV72Secuserclientewwds_16_tfsecuserfullname ,
                                             string AV75Secuserclientewwds_19_tfsecusername_sel ,
                                             string AV74Secuserclientewwds_18_tfsecusername ,
                                             string AV77Secuserclientewwds_21_tfsecuseremail_sel ,
                                             string AV76Secuserclientewwds_20_tfsecuseremail ,
                                             short AV78Secuserclientewwds_22_tfsecuserstatus_sel ,
                                             string A143SecUserFullName ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             short A210SecUserClienteId ,
                                             short AV49SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SecUserClienteId, SecUserEmail, SecUserStatus, SecUserName, SecUserFullName, SecUserId FROM SecUser";
         AddWhere(sWhereString, "(SecUserClienteId = :AV49SecUserClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Secuserclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserFullName like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( SecUserName like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV57Secuserclientewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Secuserclientewwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Secuserclientewwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV60Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV60Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV61Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV61Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV65Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV65Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV66Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV62Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV66Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV70Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV70Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV71Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV67Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV71Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserclientewwds_17_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserclientewwds_16_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV72Secuserclientewwds_16_tfsecuserfullname)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserclientewwds_17_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV73Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV73Secuserclientewwds_17_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Secuserclientewwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Secuserclientewwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV74Secuserclientewwds_18_tfsecusername)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Secuserclientewwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV75Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV75Secuserclientewwds_19_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Secuserclientewwds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV76Secuserclientewwds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Secuserclientewwds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV77Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV77Secuserclientewwds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV78Secuserclientewwds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV78Secuserclientewwds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecUserEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
               case 1 :
                     return conditional_P006L3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
               case 2 :
                     return conditional_P006L4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006L2;
          prmP006L2 = new Object[] {
          new ParDef("AV49SecUserClienteId",GXType.Int16,4,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV60Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV61Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV65Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV65Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV66Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV70Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV70Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV71Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserclientewwds_16_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV73Secuserclientewwds_17_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV74Secuserclientewwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV75Secuserclientewwds_19_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV76Secuserclientewwds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV77Secuserclientewwds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006L3;
          prmP006L3 = new Object[] {
          new ParDef("AV49SecUserClienteId",GXType.Int16,4,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV60Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV61Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV65Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV65Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV66Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV70Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV70Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV71Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserclientewwds_16_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV73Secuserclientewwds_17_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV74Secuserclientewwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV75Secuserclientewwds_19_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV76Secuserclientewwds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV77Secuserclientewwds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006L4;
          prmP006L4 = new Object[] {
          new ParDef("AV49SecUserClienteId",GXType.Int16,4,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV60Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV61Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV65Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV65Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV66Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV70Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV70Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV71Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserclientewwds_16_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV73Secuserclientewwds_17_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV74Secuserclientewwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV75Secuserclientewwds_19_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV76Secuserclientewwds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV77Secuserclientewwds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006L2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006L4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006L4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
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
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
