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
   public class wpselectusergetfilterdata : GXProcedure
   {
      public wpselectusergetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpselectusergetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_SECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_SECUSERFULLNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERFULLNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_SECUSEREMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSEREMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("WpSelectuserGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpSelectuserGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WpSelectuserGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV10TFSecUserName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV11TFSecUserName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV12TFSecUserFullName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV13TFSecUserFullName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV14TFSecUserEmail = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV15TFSecUserEmail_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV16TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&SECROLEID") == 0 )
            {
               AV54SecRoleId = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42SecUserName1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV43SecUserManName1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV47SecUserName2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV48SecUserManName2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV52SecUserName3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV53SecUserManName3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecUserName = AV17SearchTxt;
         AV11TFSecUserName_Sel = "";
         AV57Wpselectuserds_1_filterfulltext = AV39FilterFullText;
         AV58Wpselectuserds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Wpselectuserds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Wpselectuserds_4_secusername1 = AV42SecUserName1;
         AV61Wpselectuserds_5_secusermanname1 = AV43SecUserManName1;
         AV62Wpselectuserds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Wpselectuserds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Wpselectuserds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Wpselectuserds_9_secusername2 = AV47SecUserName2;
         AV66Wpselectuserds_10_secusermanname2 = AV48SecUserManName2;
         AV67Wpselectuserds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Wpselectuserds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Wpselectuserds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Wpselectuserds_14_secusername3 = AV52SecUserName3;
         AV71Wpselectuserds_15_secusermanname3 = AV53SecUserManName3;
         AV72Wpselectuserds_16_tfsecusername = AV10TFSecUserName;
         AV73Wpselectuserds_17_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV74Wpselectuserds_18_tfsecuserfullname = AV12TFSecUserFullName;
         AV75Wpselectuserds_19_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV76Wpselectuserds_20_tfsecuseremail = AV14TFSecUserEmail;
         AV77Wpselectuserds_21_tfsecuseremail_sel = AV15TFSecUserEmail_Sel;
         AV78Wpselectuserds_22_tfsecuserstatus_sel = AV16TFSecUserStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Wpselectuserds_1_filterfulltext ,
                                              AV58Wpselectuserds_2_dynamicfiltersselector1 ,
                                              AV59Wpselectuserds_3_dynamicfiltersoperator1 ,
                                              AV60Wpselectuserds_4_secusername1 ,
                                              AV61Wpselectuserds_5_secusermanname1 ,
                                              AV62Wpselectuserds_6_dynamicfiltersenabled2 ,
                                              AV63Wpselectuserds_7_dynamicfiltersselector2 ,
                                              AV64Wpselectuserds_8_dynamicfiltersoperator2 ,
                                              AV65Wpselectuserds_9_secusername2 ,
                                              AV66Wpselectuserds_10_secusermanname2 ,
                                              AV67Wpselectuserds_11_dynamicfiltersenabled3 ,
                                              AV68Wpselectuserds_12_dynamicfiltersselector3 ,
                                              AV69Wpselectuserds_13_dynamicfiltersoperator3 ,
                                              AV70Wpselectuserds_14_secusername3 ,
                                              AV71Wpselectuserds_15_secusermanname3 ,
                                              AV73Wpselectuserds_17_tfsecusername_sel ,
                                              AV72Wpselectuserds_16_tfsecusername ,
                                              AV75Wpselectuserds_19_tfsecuserfullname_sel ,
                                              AV74Wpselectuserds_18_tfsecuserfullname ,
                                              AV77Wpselectuserds_21_tfsecuseremail_sel ,
                                              AV76Wpselectuserds_20_tfsecuseremail ,
                                              AV78Wpselectuserds_22_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              A40000SecUserRoleActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV60Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Wpselectuserds_4_secusername1), "%", "");
         lV60Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Wpselectuserds_4_secusername1), "%", "");
         lV61Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1), "%", "");
         lV61Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1), "%", "");
         lV65Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Wpselectuserds_9_secusername2), "%", "");
         lV65Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Wpselectuserds_9_secusername2), "%", "");
         lV66Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2), "%", "");
         lV66Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2), "%", "");
         lV70Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_14_secusername3), "%", "");
         lV70Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_14_secusername3), "%", "");
         lV71Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3), "%", "");
         lV71Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3), "%", "");
         lV72Wpselectuserds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV72Wpselectuserds_16_tfsecusername), "%", "");
         lV74Wpselectuserds_18_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV74Wpselectuserds_18_tfsecuserfullname), "%", "");
         lV76Wpselectuserds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV76Wpselectuserds_20_tfsecuseremail), "%", "");
         /* Using cursor P00C73 */
         pr_default.execute(0, new Object[] {AV54SecRoleId, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV60Wpselectuserds_4_secusername1, lV60Wpselectuserds_4_secusername1, lV61Wpselectuserds_5_secusermanname1, lV61Wpselectuserds_5_secusermanname1, lV65Wpselectuserds_9_secusername2, lV65Wpselectuserds_9_secusername2, lV66Wpselectuserds_10_secusermanname2, lV66Wpselectuserds_10_secusermanname2, lV70Wpselectuserds_14_secusername3, lV70Wpselectuserds_14_secusername3, lV71Wpselectuserds_15_secusermanname3, lV71Wpselectuserds_15_secusermanname3, lV72Wpselectuserds_16_tfsecusername, AV73Wpselectuserds_17_tfsecusername_sel, lV74Wpselectuserds_18_tfsecuserfullname, AV75Wpselectuserds_19_tfsecuserfullname_sel, lV76Wpselectuserds_20_tfsecuseremail, AV77Wpselectuserds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKC72 = false;
            A147SecUserUserMan = P00C73_A147SecUserUserMan[0];
            n147SecUserUserMan = P00C73_n147SecUserUserMan[0];
            A133SecUserId = P00C73_A133SecUserId[0];
            A141SecUserName = P00C73_A141SecUserName[0];
            n141SecUserName = P00C73_n141SecUserName[0];
            A148SecUserManName = P00C73_A148SecUserManName[0];
            n148SecUserManName = P00C73_n148SecUserManName[0];
            A150SecUserStatus = P00C73_A150SecUserStatus[0];
            n150SecUserStatus = P00C73_n150SecUserStatus[0];
            A144SecUserEmail = P00C73_A144SecUserEmail[0];
            n144SecUserEmail = P00C73_n144SecUserEmail[0];
            A143SecUserFullName = P00C73_A143SecUserFullName[0];
            n143SecUserFullName = P00C73_n143SecUserFullName[0];
            A40000SecUserRoleActive = P00C73_A40000SecUserRoleActive[0];
            n40000SecUserRoleActive = P00C73_n40000SecUserRoleActive[0];
            A148SecUserManName = P00C73_A148SecUserManName[0];
            n148SecUserManName = P00C73_n148SecUserManName[0];
            A40000SecUserRoleActive = P00C73_A40000SecUserRoleActive[0];
            n40000SecUserRoleActive = P00C73_n40000SecUserRoleActive[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00C73_A141SecUserName[0], A141SecUserName) == 0 ) )
            {
               BRKC72 = false;
               A133SecUserId = P00C73_A133SecUserId[0];
               AV27count = (long)(AV27count+1);
               BRKC72 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? "<#Empty#>" : A141SecUserName);
               AV24OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")));
               AV23Options.Add(AV22Option, 0);
               AV25OptionsDesc.Add(AV24OptionDesc, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKC72 )
            {
               BRKC72 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECUSERFULLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecUserFullName = AV17SearchTxt;
         AV13TFSecUserFullName_Sel = "";
         AV57Wpselectuserds_1_filterfulltext = AV39FilterFullText;
         AV58Wpselectuserds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Wpselectuserds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Wpselectuserds_4_secusername1 = AV42SecUserName1;
         AV61Wpselectuserds_5_secusermanname1 = AV43SecUserManName1;
         AV62Wpselectuserds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Wpselectuserds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Wpselectuserds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Wpselectuserds_9_secusername2 = AV47SecUserName2;
         AV66Wpselectuserds_10_secusermanname2 = AV48SecUserManName2;
         AV67Wpselectuserds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Wpselectuserds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Wpselectuserds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Wpselectuserds_14_secusername3 = AV52SecUserName3;
         AV71Wpselectuserds_15_secusermanname3 = AV53SecUserManName3;
         AV72Wpselectuserds_16_tfsecusername = AV10TFSecUserName;
         AV73Wpselectuserds_17_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV74Wpselectuserds_18_tfsecuserfullname = AV12TFSecUserFullName;
         AV75Wpselectuserds_19_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV76Wpselectuserds_20_tfsecuseremail = AV14TFSecUserEmail;
         AV77Wpselectuserds_21_tfsecuseremail_sel = AV15TFSecUserEmail_Sel;
         AV78Wpselectuserds_22_tfsecuserstatus_sel = AV16TFSecUserStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Wpselectuserds_1_filterfulltext ,
                                              AV58Wpselectuserds_2_dynamicfiltersselector1 ,
                                              AV59Wpselectuserds_3_dynamicfiltersoperator1 ,
                                              AV60Wpselectuserds_4_secusername1 ,
                                              AV61Wpselectuserds_5_secusermanname1 ,
                                              AV62Wpselectuserds_6_dynamicfiltersenabled2 ,
                                              AV63Wpselectuserds_7_dynamicfiltersselector2 ,
                                              AV64Wpselectuserds_8_dynamicfiltersoperator2 ,
                                              AV65Wpselectuserds_9_secusername2 ,
                                              AV66Wpselectuserds_10_secusermanname2 ,
                                              AV67Wpselectuserds_11_dynamicfiltersenabled3 ,
                                              AV68Wpselectuserds_12_dynamicfiltersselector3 ,
                                              AV69Wpselectuserds_13_dynamicfiltersoperator3 ,
                                              AV70Wpselectuserds_14_secusername3 ,
                                              AV71Wpselectuserds_15_secusermanname3 ,
                                              AV73Wpselectuserds_17_tfsecusername_sel ,
                                              AV72Wpselectuserds_16_tfsecusername ,
                                              AV75Wpselectuserds_19_tfsecuserfullname_sel ,
                                              AV74Wpselectuserds_18_tfsecuserfullname ,
                                              AV77Wpselectuserds_21_tfsecuseremail_sel ,
                                              AV76Wpselectuserds_20_tfsecuseremail ,
                                              AV78Wpselectuserds_22_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              A40000SecUserRoleActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV60Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Wpselectuserds_4_secusername1), "%", "");
         lV60Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Wpselectuserds_4_secusername1), "%", "");
         lV61Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1), "%", "");
         lV61Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1), "%", "");
         lV65Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Wpselectuserds_9_secusername2), "%", "");
         lV65Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Wpselectuserds_9_secusername2), "%", "");
         lV66Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2), "%", "");
         lV66Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2), "%", "");
         lV70Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_14_secusername3), "%", "");
         lV70Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_14_secusername3), "%", "");
         lV71Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3), "%", "");
         lV71Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3), "%", "");
         lV72Wpselectuserds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV72Wpselectuserds_16_tfsecusername), "%", "");
         lV74Wpselectuserds_18_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV74Wpselectuserds_18_tfsecuserfullname), "%", "");
         lV76Wpselectuserds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV76Wpselectuserds_20_tfsecuseremail), "%", "");
         /* Using cursor P00C75 */
         pr_default.execute(1, new Object[] {AV54SecRoleId, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV60Wpselectuserds_4_secusername1, lV60Wpselectuserds_4_secusername1, lV61Wpselectuserds_5_secusermanname1, lV61Wpselectuserds_5_secusermanname1, lV65Wpselectuserds_9_secusername2, lV65Wpselectuserds_9_secusername2, lV66Wpselectuserds_10_secusermanname2, lV66Wpselectuserds_10_secusermanname2, lV70Wpselectuserds_14_secusername3, lV70Wpselectuserds_14_secusername3, lV71Wpselectuserds_15_secusermanname3, lV71Wpselectuserds_15_secusermanname3, lV72Wpselectuserds_16_tfsecusername, AV73Wpselectuserds_17_tfsecusername_sel, lV74Wpselectuserds_18_tfsecuserfullname, AV75Wpselectuserds_19_tfsecuserfullname_sel, lV76Wpselectuserds_20_tfsecuseremail, AV77Wpselectuserds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKC74 = false;
            A147SecUserUserMan = P00C75_A147SecUserUserMan[0];
            n147SecUserUserMan = P00C75_n147SecUserUserMan[0];
            A133SecUserId = P00C75_A133SecUserId[0];
            A143SecUserFullName = P00C75_A143SecUserFullName[0];
            n143SecUserFullName = P00C75_n143SecUserFullName[0];
            A148SecUserManName = P00C75_A148SecUserManName[0];
            n148SecUserManName = P00C75_n148SecUserManName[0];
            A150SecUserStatus = P00C75_A150SecUserStatus[0];
            n150SecUserStatus = P00C75_n150SecUserStatus[0];
            A144SecUserEmail = P00C75_A144SecUserEmail[0];
            n144SecUserEmail = P00C75_n144SecUserEmail[0];
            A141SecUserName = P00C75_A141SecUserName[0];
            n141SecUserName = P00C75_n141SecUserName[0];
            A40000SecUserRoleActive = P00C75_A40000SecUserRoleActive[0];
            n40000SecUserRoleActive = P00C75_n40000SecUserRoleActive[0];
            A148SecUserManName = P00C75_A148SecUserManName[0];
            n148SecUserManName = P00C75_n148SecUserManName[0];
            A40000SecUserRoleActive = P00C75_A40000SecUserRoleActive[0];
            n40000SecUserRoleActive = P00C75_n40000SecUserRoleActive[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00C75_A143SecUserFullName[0], A143SecUserFullName) == 0 ) )
            {
               BRKC74 = false;
               A133SecUserId = P00C75_A133SecUserId[0];
               AV27count = (long)(AV27count+1);
               BRKC74 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? "<#Empty#>" : A143SecUserFullName);
               AV24OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")));
               AV23Options.Add(AV22Option, 0);
               AV25OptionsDesc.Add(AV24OptionDesc, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKC74 )
            {
               BRKC74 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSECUSEREMAILOPTIONS' Routine */
         returnInSub = false;
         AV14TFSecUserEmail = AV17SearchTxt;
         AV15TFSecUserEmail_Sel = "";
         AV57Wpselectuserds_1_filterfulltext = AV39FilterFullText;
         AV58Wpselectuserds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Wpselectuserds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Wpselectuserds_4_secusername1 = AV42SecUserName1;
         AV61Wpselectuserds_5_secusermanname1 = AV43SecUserManName1;
         AV62Wpselectuserds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Wpselectuserds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Wpselectuserds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Wpselectuserds_9_secusername2 = AV47SecUserName2;
         AV66Wpselectuserds_10_secusermanname2 = AV48SecUserManName2;
         AV67Wpselectuserds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Wpselectuserds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Wpselectuserds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Wpselectuserds_14_secusername3 = AV52SecUserName3;
         AV71Wpselectuserds_15_secusermanname3 = AV53SecUserManName3;
         AV72Wpselectuserds_16_tfsecusername = AV10TFSecUserName;
         AV73Wpselectuserds_17_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV74Wpselectuserds_18_tfsecuserfullname = AV12TFSecUserFullName;
         AV75Wpselectuserds_19_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV76Wpselectuserds_20_tfsecuseremail = AV14TFSecUserEmail;
         AV77Wpselectuserds_21_tfsecuseremail_sel = AV15TFSecUserEmail_Sel;
         AV78Wpselectuserds_22_tfsecuserstatus_sel = AV16TFSecUserStatus_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV57Wpselectuserds_1_filterfulltext ,
                                              AV58Wpselectuserds_2_dynamicfiltersselector1 ,
                                              AV59Wpselectuserds_3_dynamicfiltersoperator1 ,
                                              AV60Wpselectuserds_4_secusername1 ,
                                              AV61Wpselectuserds_5_secusermanname1 ,
                                              AV62Wpselectuserds_6_dynamicfiltersenabled2 ,
                                              AV63Wpselectuserds_7_dynamicfiltersselector2 ,
                                              AV64Wpselectuserds_8_dynamicfiltersoperator2 ,
                                              AV65Wpselectuserds_9_secusername2 ,
                                              AV66Wpselectuserds_10_secusermanname2 ,
                                              AV67Wpselectuserds_11_dynamicfiltersenabled3 ,
                                              AV68Wpselectuserds_12_dynamicfiltersselector3 ,
                                              AV69Wpselectuserds_13_dynamicfiltersoperator3 ,
                                              AV70Wpselectuserds_14_secusername3 ,
                                              AV71Wpselectuserds_15_secusermanname3 ,
                                              AV73Wpselectuserds_17_tfsecusername_sel ,
                                              AV72Wpselectuserds_16_tfsecusername ,
                                              AV75Wpselectuserds_19_tfsecuserfullname_sel ,
                                              AV74Wpselectuserds_18_tfsecuserfullname ,
                                              AV77Wpselectuserds_21_tfsecuseremail_sel ,
                                              AV76Wpselectuserds_20_tfsecuseremail ,
                                              AV78Wpselectuserds_22_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              A40000SecUserRoleActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV57Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext), "%", "");
         lV60Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Wpselectuserds_4_secusername1), "%", "");
         lV60Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Wpselectuserds_4_secusername1), "%", "");
         lV61Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1), "%", "");
         lV61Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1), "%", "");
         lV65Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Wpselectuserds_9_secusername2), "%", "");
         lV65Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Wpselectuserds_9_secusername2), "%", "");
         lV66Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2), "%", "");
         lV66Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2), "%", "");
         lV70Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_14_secusername3), "%", "");
         lV70Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_14_secusername3), "%", "");
         lV71Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3), "%", "");
         lV71Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3), "%", "");
         lV72Wpselectuserds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV72Wpselectuserds_16_tfsecusername), "%", "");
         lV74Wpselectuserds_18_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV74Wpselectuserds_18_tfsecuserfullname), "%", "");
         lV76Wpselectuserds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV76Wpselectuserds_20_tfsecuseremail), "%", "");
         /* Using cursor P00C77 */
         pr_default.execute(2, new Object[] {AV54SecRoleId, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV57Wpselectuserds_1_filterfulltext, lV60Wpselectuserds_4_secusername1, lV60Wpselectuserds_4_secusername1, lV61Wpselectuserds_5_secusermanname1, lV61Wpselectuserds_5_secusermanname1, lV65Wpselectuserds_9_secusername2, lV65Wpselectuserds_9_secusername2, lV66Wpselectuserds_10_secusermanname2, lV66Wpselectuserds_10_secusermanname2, lV70Wpselectuserds_14_secusername3, lV70Wpselectuserds_14_secusername3, lV71Wpselectuserds_15_secusermanname3, lV71Wpselectuserds_15_secusermanname3, lV72Wpselectuserds_16_tfsecusername, AV73Wpselectuserds_17_tfsecusername_sel, lV74Wpselectuserds_18_tfsecuserfullname, AV75Wpselectuserds_19_tfsecuserfullname_sel, lV76Wpselectuserds_20_tfsecuseremail, AV77Wpselectuserds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKC76 = false;
            A147SecUserUserMan = P00C77_A147SecUserUserMan[0];
            n147SecUserUserMan = P00C77_n147SecUserUserMan[0];
            A133SecUserId = P00C77_A133SecUserId[0];
            A144SecUserEmail = P00C77_A144SecUserEmail[0];
            n144SecUserEmail = P00C77_n144SecUserEmail[0];
            A148SecUserManName = P00C77_A148SecUserManName[0];
            n148SecUserManName = P00C77_n148SecUserManName[0];
            A150SecUserStatus = P00C77_A150SecUserStatus[0];
            n150SecUserStatus = P00C77_n150SecUserStatus[0];
            A143SecUserFullName = P00C77_A143SecUserFullName[0];
            n143SecUserFullName = P00C77_n143SecUserFullName[0];
            A141SecUserName = P00C77_A141SecUserName[0];
            n141SecUserName = P00C77_n141SecUserName[0];
            A40000SecUserRoleActive = P00C77_A40000SecUserRoleActive[0];
            n40000SecUserRoleActive = P00C77_n40000SecUserRoleActive[0];
            A148SecUserManName = P00C77_A148SecUserManName[0];
            n148SecUserManName = P00C77_n148SecUserManName[0];
            A40000SecUserRoleActive = P00C77_A40000SecUserRoleActive[0];
            n40000SecUserRoleActive = P00C77_n40000SecUserRoleActive[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00C77_A144SecUserEmail[0], A144SecUserEmail) == 0 ) )
            {
               BRKC76 = false;
               A133SecUserId = P00C77_A133SecUserId[0];
               AV27count = (long)(AV27count+1);
               BRKC76 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? "<#Empty#>" : A144SecUserEmail);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKC76 )
            {
               BRKC76 = true;
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV10TFSecUserName = "";
         AV11TFSecUserName_Sel = "";
         AV12TFSecUserFullName = "";
         AV13TFSecUserFullName_Sel = "";
         AV14TFSecUserEmail = "";
         AV15TFSecUserEmail_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42SecUserName1 = "";
         AV43SecUserManName1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47SecUserName2 = "";
         AV48SecUserManName2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52SecUserName3 = "";
         AV53SecUserManName3 = "";
         AV57Wpselectuserds_1_filterfulltext = "";
         AV58Wpselectuserds_2_dynamicfiltersselector1 = "";
         AV60Wpselectuserds_4_secusername1 = "";
         AV61Wpselectuserds_5_secusermanname1 = "";
         AV63Wpselectuserds_7_dynamicfiltersselector2 = "";
         AV65Wpselectuserds_9_secusername2 = "";
         AV66Wpselectuserds_10_secusermanname2 = "";
         AV68Wpselectuserds_12_dynamicfiltersselector3 = "";
         AV70Wpselectuserds_14_secusername3 = "";
         AV71Wpselectuserds_15_secusermanname3 = "";
         AV72Wpselectuserds_16_tfsecusername = "";
         AV73Wpselectuserds_17_tfsecusername_sel = "";
         AV74Wpselectuserds_18_tfsecuserfullname = "";
         AV75Wpselectuserds_19_tfsecuserfullname_sel = "";
         AV76Wpselectuserds_20_tfsecuseremail = "";
         AV77Wpselectuserds_21_tfsecuseremail_sel = "";
         lV57Wpselectuserds_1_filterfulltext = "";
         lV60Wpselectuserds_4_secusername1 = "";
         lV61Wpselectuserds_5_secusermanname1 = "";
         lV65Wpselectuserds_9_secusername2 = "";
         lV66Wpselectuserds_10_secusermanname2 = "";
         lV70Wpselectuserds_14_secusername3 = "";
         lV71Wpselectuserds_15_secusermanname3 = "";
         lV72Wpselectuserds_16_tfsecusername = "";
         lV74Wpselectuserds_18_tfsecuserfullname = "";
         lV76Wpselectuserds_20_tfsecuseremail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         A148SecUserManName = "";
         P00C73_A147SecUserUserMan = new short[1] ;
         P00C73_n147SecUserUserMan = new bool[] {false} ;
         P00C73_A133SecUserId = new short[1] ;
         P00C73_A141SecUserName = new string[] {""} ;
         P00C73_n141SecUserName = new bool[] {false} ;
         P00C73_A148SecUserManName = new string[] {""} ;
         P00C73_n148SecUserManName = new bool[] {false} ;
         P00C73_A150SecUserStatus = new bool[] {false} ;
         P00C73_n150SecUserStatus = new bool[] {false} ;
         P00C73_A144SecUserEmail = new string[] {""} ;
         P00C73_n144SecUserEmail = new bool[] {false} ;
         P00C73_A143SecUserFullName = new string[] {""} ;
         P00C73_n143SecUserFullName = new bool[] {false} ;
         P00C73_A40000SecUserRoleActive = new bool[] {false} ;
         P00C73_n40000SecUserRoleActive = new bool[] {false} ;
         AV22Option = "";
         AV24OptionDesc = "";
         P00C75_A147SecUserUserMan = new short[1] ;
         P00C75_n147SecUserUserMan = new bool[] {false} ;
         P00C75_A133SecUserId = new short[1] ;
         P00C75_A143SecUserFullName = new string[] {""} ;
         P00C75_n143SecUserFullName = new bool[] {false} ;
         P00C75_A148SecUserManName = new string[] {""} ;
         P00C75_n148SecUserManName = new bool[] {false} ;
         P00C75_A150SecUserStatus = new bool[] {false} ;
         P00C75_n150SecUserStatus = new bool[] {false} ;
         P00C75_A144SecUserEmail = new string[] {""} ;
         P00C75_n144SecUserEmail = new bool[] {false} ;
         P00C75_A141SecUserName = new string[] {""} ;
         P00C75_n141SecUserName = new bool[] {false} ;
         P00C75_A40000SecUserRoleActive = new bool[] {false} ;
         P00C75_n40000SecUserRoleActive = new bool[] {false} ;
         P00C77_A147SecUserUserMan = new short[1] ;
         P00C77_n147SecUserUserMan = new bool[] {false} ;
         P00C77_A133SecUserId = new short[1] ;
         P00C77_A144SecUserEmail = new string[] {""} ;
         P00C77_n144SecUserEmail = new bool[] {false} ;
         P00C77_A148SecUserManName = new string[] {""} ;
         P00C77_n148SecUserManName = new bool[] {false} ;
         P00C77_A150SecUserStatus = new bool[] {false} ;
         P00C77_n150SecUserStatus = new bool[] {false} ;
         P00C77_A143SecUserFullName = new string[] {""} ;
         P00C77_n143SecUserFullName = new bool[] {false} ;
         P00C77_A141SecUserName = new string[] {""} ;
         P00C77_n141SecUserName = new bool[] {false} ;
         P00C77_A40000SecUserRoleActive = new bool[] {false} ;
         P00C77_n40000SecUserRoleActive = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpselectusergetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C73_A147SecUserUserMan, P00C73_n147SecUserUserMan, P00C73_A133SecUserId, P00C73_A141SecUserName, P00C73_n141SecUserName, P00C73_A148SecUserManName, P00C73_n148SecUserManName, P00C73_A150SecUserStatus, P00C73_n150SecUserStatus, P00C73_A144SecUserEmail,
               P00C73_n144SecUserEmail, P00C73_A143SecUserFullName, P00C73_n143SecUserFullName, P00C73_A40000SecUserRoleActive, P00C73_n40000SecUserRoleActive
               }
               , new Object[] {
               P00C75_A147SecUserUserMan, P00C75_n147SecUserUserMan, P00C75_A133SecUserId, P00C75_A143SecUserFullName, P00C75_n143SecUserFullName, P00C75_A148SecUserManName, P00C75_n148SecUserManName, P00C75_A150SecUserStatus, P00C75_n150SecUserStatus, P00C75_A144SecUserEmail,
               P00C75_n144SecUserEmail, P00C75_A141SecUserName, P00C75_n141SecUserName, P00C75_A40000SecUserRoleActive, P00C75_n40000SecUserRoleActive
               }
               , new Object[] {
               P00C77_A147SecUserUserMan, P00C77_n147SecUserUserMan, P00C77_A133SecUserId, P00C77_A144SecUserEmail, P00C77_n144SecUserEmail, P00C77_A148SecUserManName, P00C77_n148SecUserManName, P00C77_A150SecUserStatus, P00C77_n150SecUserStatus, P00C77_A143SecUserFullName,
               P00C77_n143SecUserFullName, P00C77_A141SecUserName, P00C77_n141SecUserName, P00C77_A40000SecUserRoleActive, P00C77_n40000SecUserRoleActive
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV16TFSecUserStatus_Sel ;
      private short AV54SecRoleId ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV59Wpselectuserds_3_dynamicfiltersoperator1 ;
      private short AV64Wpselectuserds_8_dynamicfiltersoperator2 ;
      private short AV69Wpselectuserds_13_dynamicfiltersoperator3 ;
      private short AV78Wpselectuserds_22_tfsecuserstatus_sel ;
      private short A147SecUserUserMan ;
      private short A133SecUserId ;
      private int AV55GXV1 ;
      private long AV27count ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV62Wpselectuserds_6_dynamicfiltersenabled2 ;
      private bool AV67Wpselectuserds_11_dynamicfiltersenabled3 ;
      private bool A150SecUserStatus ;
      private bool A40000SecUserRoleActive ;
      private bool BRKC72 ;
      private bool n147SecUserUserMan ;
      private bool n141SecUserName ;
      private bool n148SecUserManName ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool n40000SecUserRoleActive ;
      private bool BRKC74 ;
      private bool BRKC76 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV10TFSecUserName ;
      private string AV11TFSecUserName_Sel ;
      private string AV12TFSecUserFullName ;
      private string AV13TFSecUserFullName_Sel ;
      private string AV14TFSecUserEmail ;
      private string AV15TFSecUserEmail_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV42SecUserName1 ;
      private string AV43SecUserManName1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47SecUserName2 ;
      private string AV48SecUserManName2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV52SecUserName3 ;
      private string AV53SecUserManName3 ;
      private string AV57Wpselectuserds_1_filterfulltext ;
      private string AV58Wpselectuserds_2_dynamicfiltersselector1 ;
      private string AV60Wpselectuserds_4_secusername1 ;
      private string AV61Wpselectuserds_5_secusermanname1 ;
      private string AV63Wpselectuserds_7_dynamicfiltersselector2 ;
      private string AV65Wpselectuserds_9_secusername2 ;
      private string AV66Wpselectuserds_10_secusermanname2 ;
      private string AV68Wpselectuserds_12_dynamicfiltersselector3 ;
      private string AV70Wpselectuserds_14_secusername3 ;
      private string AV71Wpselectuserds_15_secusermanname3 ;
      private string AV72Wpselectuserds_16_tfsecusername ;
      private string AV73Wpselectuserds_17_tfsecusername_sel ;
      private string AV74Wpselectuserds_18_tfsecuserfullname ;
      private string AV75Wpselectuserds_19_tfsecuserfullname_sel ;
      private string AV76Wpselectuserds_20_tfsecuseremail ;
      private string AV77Wpselectuserds_21_tfsecuseremail_sel ;
      private string lV57Wpselectuserds_1_filterfulltext ;
      private string lV60Wpselectuserds_4_secusername1 ;
      private string lV61Wpselectuserds_5_secusermanname1 ;
      private string lV65Wpselectuserds_9_secusername2 ;
      private string lV66Wpselectuserds_10_secusermanname2 ;
      private string lV70Wpselectuserds_14_secusername3 ;
      private string lV71Wpselectuserds_15_secusermanname3 ;
      private string lV72Wpselectuserds_16_tfsecusername ;
      private string lV74Wpselectuserds_18_tfsecuserfullname ;
      private string lV76Wpselectuserds_20_tfsecuseremail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string A148SecUserManName ;
      private string AV22Option ;
      private string AV24OptionDesc ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00C73_A147SecUserUserMan ;
      private bool[] P00C73_n147SecUserUserMan ;
      private short[] P00C73_A133SecUserId ;
      private string[] P00C73_A141SecUserName ;
      private bool[] P00C73_n141SecUserName ;
      private string[] P00C73_A148SecUserManName ;
      private bool[] P00C73_n148SecUserManName ;
      private bool[] P00C73_A150SecUserStatus ;
      private bool[] P00C73_n150SecUserStatus ;
      private string[] P00C73_A144SecUserEmail ;
      private bool[] P00C73_n144SecUserEmail ;
      private string[] P00C73_A143SecUserFullName ;
      private bool[] P00C73_n143SecUserFullName ;
      private bool[] P00C73_A40000SecUserRoleActive ;
      private bool[] P00C73_n40000SecUserRoleActive ;
      private short[] P00C75_A147SecUserUserMan ;
      private bool[] P00C75_n147SecUserUserMan ;
      private short[] P00C75_A133SecUserId ;
      private string[] P00C75_A143SecUserFullName ;
      private bool[] P00C75_n143SecUserFullName ;
      private string[] P00C75_A148SecUserManName ;
      private bool[] P00C75_n148SecUserManName ;
      private bool[] P00C75_A150SecUserStatus ;
      private bool[] P00C75_n150SecUserStatus ;
      private string[] P00C75_A144SecUserEmail ;
      private bool[] P00C75_n144SecUserEmail ;
      private string[] P00C75_A141SecUserName ;
      private bool[] P00C75_n141SecUserName ;
      private bool[] P00C75_A40000SecUserRoleActive ;
      private bool[] P00C75_n40000SecUserRoleActive ;
      private short[] P00C77_A147SecUserUserMan ;
      private bool[] P00C77_n147SecUserUserMan ;
      private short[] P00C77_A133SecUserId ;
      private string[] P00C77_A144SecUserEmail ;
      private bool[] P00C77_n144SecUserEmail ;
      private string[] P00C77_A148SecUserManName ;
      private bool[] P00C77_n148SecUserManName ;
      private bool[] P00C77_A150SecUserStatus ;
      private bool[] P00C77_n150SecUserStatus ;
      private string[] P00C77_A143SecUserFullName ;
      private bool[] P00C77_n143SecUserFullName ;
      private string[] P00C77_A141SecUserName ;
      private bool[] P00C77_n141SecUserName ;
      private bool[] P00C77_A40000SecUserRoleActive ;
      private bool[] P00C77_n40000SecUserRoleActive ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpselectusergetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C73( IGxContext context ,
                                             string AV57Wpselectuserds_1_filterfulltext ,
                                             string AV58Wpselectuserds_2_dynamicfiltersselector1 ,
                                             short AV59Wpselectuserds_3_dynamicfiltersoperator1 ,
                                             string AV60Wpselectuserds_4_secusername1 ,
                                             string AV61Wpselectuserds_5_secusermanname1 ,
                                             bool AV62Wpselectuserds_6_dynamicfiltersenabled2 ,
                                             string AV63Wpselectuserds_7_dynamicfiltersselector2 ,
                                             short AV64Wpselectuserds_8_dynamicfiltersoperator2 ,
                                             string AV65Wpselectuserds_9_secusername2 ,
                                             string AV66Wpselectuserds_10_secusermanname2 ,
                                             bool AV67Wpselectuserds_11_dynamicfiltersenabled3 ,
                                             string AV68Wpselectuserds_12_dynamicfiltersselector3 ,
                                             short AV69Wpselectuserds_13_dynamicfiltersoperator3 ,
                                             string AV70Wpselectuserds_14_secusername3 ,
                                             string AV71Wpselectuserds_15_secusermanname3 ,
                                             string AV73Wpselectuserds_17_tfsecusername_sel ,
                                             string AV72Wpselectuserds_16_tfsecusername ,
                                             string AV75Wpselectuserds_19_tfsecuserfullname_sel ,
                                             string AV74Wpselectuserds_18_tfsecuserfullname ,
                                             string AV77Wpselectuserds_21_tfsecuseremail_sel ,
                                             string AV76Wpselectuserds_20_tfsecuseremail ,
                                             short AV78Wpselectuserds_22_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             bool A40000SecUserRoleActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T1.SecUserId, T1.SecUserName, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserFullName, COALESCE( T3.SecUserRoleActive, FALSE) AS SecUserRoleActive FROM ((SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan) LEFT JOIN (SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecRoleId = :AV54SecRoleId ) T3 ON T3.SecUserId = T1.SecUserId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecUserRoleActive, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecUserName like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( T1.SecUserFullName like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( T1.SecUserEmail like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV60Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV60Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV61Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV61Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV65Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV65Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV70Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV70Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV71Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpselectuserds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV72Wpselectuserds_16_tfsecusername)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV73Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV73Wpselectuserds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpselectuserds_19_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpselectuserds_18_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV74Wpselectuserds_18_tfsecuserfullname)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpselectuserds_19_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV75Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV75Wpselectuserds_19_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpselectuserds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpselectuserds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV76Wpselectuserds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpselectuserds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV77Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV77Wpselectuserds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV78Wpselectuserds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV78Wpselectuserds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00C75( IGxContext context ,
                                             string AV57Wpselectuserds_1_filterfulltext ,
                                             string AV58Wpselectuserds_2_dynamicfiltersselector1 ,
                                             short AV59Wpselectuserds_3_dynamicfiltersoperator1 ,
                                             string AV60Wpselectuserds_4_secusername1 ,
                                             string AV61Wpselectuserds_5_secusermanname1 ,
                                             bool AV62Wpselectuserds_6_dynamicfiltersenabled2 ,
                                             string AV63Wpselectuserds_7_dynamicfiltersselector2 ,
                                             short AV64Wpselectuserds_8_dynamicfiltersoperator2 ,
                                             string AV65Wpselectuserds_9_secusername2 ,
                                             string AV66Wpselectuserds_10_secusermanname2 ,
                                             bool AV67Wpselectuserds_11_dynamicfiltersenabled3 ,
                                             string AV68Wpselectuserds_12_dynamicfiltersselector3 ,
                                             short AV69Wpselectuserds_13_dynamicfiltersoperator3 ,
                                             string AV70Wpselectuserds_14_secusername3 ,
                                             string AV71Wpselectuserds_15_secusermanname3 ,
                                             string AV73Wpselectuserds_17_tfsecusername_sel ,
                                             string AV72Wpselectuserds_16_tfsecusername ,
                                             string AV75Wpselectuserds_19_tfsecuserfullname_sel ,
                                             string AV74Wpselectuserds_18_tfsecuserfullname ,
                                             string AV77Wpselectuserds_21_tfsecuseremail_sel ,
                                             string AV76Wpselectuserds_20_tfsecuseremail ,
                                             short AV78Wpselectuserds_22_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             bool A40000SecUserRoleActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T1.SecUserId, T1.SecUserFullName, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserName, COALESCE( T3.SecUserRoleActive, FALSE) AS SecUserRoleActive FROM ((SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan) LEFT JOIN (SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecRoleId = :AV54SecRoleId ) T3 ON T3.SecUserId = T1.SecUserId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecUserRoleActive, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecUserName like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( T1.SecUserFullName like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( T1.SecUserEmail like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV60Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV60Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV61Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV61Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV65Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV65Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV70Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV70Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV71Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpselectuserds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV72Wpselectuserds_16_tfsecusername)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV73Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV73Wpselectuserds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpselectuserds_19_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpselectuserds_18_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV74Wpselectuserds_18_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpselectuserds_19_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV75Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV75Wpselectuserds_19_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpselectuserds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpselectuserds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV76Wpselectuserds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpselectuserds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV77Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV77Wpselectuserds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV78Wpselectuserds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV78Wpselectuserds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserFullName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00C77( IGxContext context ,
                                             string AV57Wpselectuserds_1_filterfulltext ,
                                             string AV58Wpselectuserds_2_dynamicfiltersselector1 ,
                                             short AV59Wpselectuserds_3_dynamicfiltersoperator1 ,
                                             string AV60Wpselectuserds_4_secusername1 ,
                                             string AV61Wpselectuserds_5_secusermanname1 ,
                                             bool AV62Wpselectuserds_6_dynamicfiltersenabled2 ,
                                             string AV63Wpselectuserds_7_dynamicfiltersselector2 ,
                                             short AV64Wpselectuserds_8_dynamicfiltersoperator2 ,
                                             string AV65Wpselectuserds_9_secusername2 ,
                                             string AV66Wpselectuserds_10_secusermanname2 ,
                                             bool AV67Wpselectuserds_11_dynamicfiltersenabled3 ,
                                             string AV68Wpselectuserds_12_dynamicfiltersselector3 ,
                                             short AV69Wpselectuserds_13_dynamicfiltersoperator3 ,
                                             string AV70Wpselectuserds_14_secusername3 ,
                                             string AV71Wpselectuserds_15_secusermanname3 ,
                                             string AV73Wpselectuserds_17_tfsecusername_sel ,
                                             string AV72Wpselectuserds_16_tfsecusername ,
                                             string AV75Wpselectuserds_19_tfsecuserfullname_sel ,
                                             string AV74Wpselectuserds_18_tfsecuserfullname ,
                                             string AV77Wpselectuserds_21_tfsecuseremail_sel ,
                                             string AV76Wpselectuserds_20_tfsecuseremail ,
                                             short AV78Wpselectuserds_22_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             bool A40000SecUserRoleActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T1.SecUserId, T1.SecUserEmail, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserFullName, T1.SecUserName, COALESCE( T3.SecUserRoleActive, FALSE) AS SecUserRoleActive FROM ((SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan) LEFT JOIN (SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecRoleId = :AV54SecRoleId ) T3 ON T3.SecUserId = T1.SecUserId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecUserRoleActive, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecUserName like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( T1.SecUserFullName like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( T1.SecUserEmail like '%' || :lV57Wpselectuserds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV60Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV60Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV61Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV59Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV61Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV65Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV65Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV62Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV64Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV70Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV70Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV67Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV69Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV71Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpselectuserds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV72Wpselectuserds_16_tfsecusername)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV73Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV73Wpselectuserds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpselectuserds_19_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpselectuserds_18_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV74Wpselectuserds_18_tfsecuserfullname)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpselectuserds_19_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV75Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV75Wpselectuserds_19_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpselectuserds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpselectuserds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV76Wpselectuserds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpselectuserds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV77Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV77Wpselectuserds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV78Wpselectuserds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV78Wpselectuserds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserEmail";
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
                     return conditional_P00C73(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] );
               case 1 :
                     return conditional_P00C75(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] );
               case 2 :
                     return conditional_P00C77(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP00C73;
          prmP00C73 = new Object[] {
          new ParDef("AV54SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpselectuserds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV73Wpselectuserds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpselectuserds_18_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV75Wpselectuserds_19_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV76Wpselectuserds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV77Wpselectuserds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00C75;
          prmP00C75 = new Object[] {
          new ParDef("AV54SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpselectuserds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV73Wpselectuserds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpselectuserds_18_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV75Wpselectuserds_19_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV76Wpselectuserds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV77Wpselectuserds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00C77;
          prmP00C77 = new Object[] {
          new ParDef("AV54SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpselectuserds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV73Wpselectuserds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpselectuserds_18_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV75Wpselectuserds_19_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV76Wpselectuserds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV77Wpselectuserds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C73,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C75", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C75,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C77", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C77,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
