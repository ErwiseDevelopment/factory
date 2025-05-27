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
   public class usuariowwgetfilterdata : GXProcedure
   {
      public usuariowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuariowwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(AV28Session.Get("UsuarioWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "UsuarioWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("UsuarioWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV51GXV1));
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
            AV51GXV1 = (int)(AV51GXV1+1);
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
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV46SecUserName2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV50SecUserName3 = AV32GridStateDynamicFilter.gxTpr_Value;
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
         AV53Usuariowwds_1_filterfulltext = AV39FilterFullText;
         AV54Usuariowwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Usuariowwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Usuariowwds_4_secusername1 = AV42SecUserName1;
         AV57Usuariowwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Usuariowwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Usuariowwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Usuariowwds_8_secusername2 = AV46SecUserName2;
         AV61Usuariowwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Usuariowwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Usuariowwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Usuariowwds_12_secusername3 = AV50SecUserName3;
         AV65Usuariowwds_13_tfsecusername = AV10TFSecUserName;
         AV66Usuariowwds_14_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV67Usuariowwds_15_tfsecuserfullname = AV12TFSecUserFullName;
         AV68Usuariowwds_16_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV69Usuariowwds_17_tfsecuseremail = AV14TFSecUserEmail;
         AV70Usuariowwds_18_tfsecuseremail_sel = AV15TFSecUserEmail_Sel;
         AV71Usuariowwds_19_tfsecuserstatus_sel = AV16TFSecUserStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Usuariowwds_1_filterfulltext ,
                                              AV54Usuariowwds_2_dynamicfiltersselector1 ,
                                              AV55Usuariowwds_3_dynamicfiltersoperator1 ,
                                              AV56Usuariowwds_4_secusername1 ,
                                              AV57Usuariowwds_5_dynamicfiltersenabled2 ,
                                              AV58Usuariowwds_6_dynamicfiltersselector2 ,
                                              AV59Usuariowwds_7_dynamicfiltersoperator2 ,
                                              AV60Usuariowwds_8_secusername2 ,
                                              AV61Usuariowwds_9_dynamicfiltersenabled3 ,
                                              AV62Usuariowwds_10_dynamicfiltersselector3 ,
                                              AV63Usuariowwds_11_dynamicfiltersoperator3 ,
                                              AV64Usuariowwds_12_secusername3 ,
                                              AV66Usuariowwds_14_tfsecusername_sel ,
                                              AV65Usuariowwds_13_tfsecusername ,
                                              AV68Usuariowwds_16_tfsecuserfullname_sel ,
                                              AV67Usuariowwds_15_tfsecuserfullname ,
                                              AV70Usuariowwds_18_tfsecuseremail_sel ,
                                              AV69Usuariowwds_17_tfsecuseremail ,
                                              AV71Usuariowwds_19_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV56Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Usuariowwds_4_secusername1), "%", "");
         lV56Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Usuariowwds_4_secusername1), "%", "");
         lV60Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV60Usuariowwds_8_secusername2), "%", "");
         lV60Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV60Usuariowwds_8_secusername2), "%", "");
         lV64Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV64Usuariowwds_12_secusername3), "%", "");
         lV64Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV64Usuariowwds_12_secusername3), "%", "");
         lV65Usuariowwds_13_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV65Usuariowwds_13_tfsecusername), "%", "");
         lV67Usuariowwds_15_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV67Usuariowwds_15_tfsecuserfullname), "%", "");
         lV69Usuariowwds_17_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV69Usuariowwds_17_tfsecuseremail), "%", "");
         /* Using cursor P00AX2 */
         pr_default.execute(0, new Object[] {lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV56Usuariowwds_4_secusername1, lV56Usuariowwds_4_secusername1, lV60Usuariowwds_8_secusername2, lV60Usuariowwds_8_secusername2, lV64Usuariowwds_12_secusername3, lV64Usuariowwds_12_secusername3, lV65Usuariowwds_13_tfsecusername, AV66Usuariowwds_14_tfsecusername_sel, lV67Usuariowwds_15_tfsecuserfullname, AV68Usuariowwds_16_tfsecuserfullname_sel, lV69Usuariowwds_17_tfsecuseremail, AV70Usuariowwds_18_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAX2 = false;
            A141SecUserName = P00AX2_A141SecUserName[0];
            n141SecUserName = P00AX2_n141SecUserName[0];
            A150SecUserStatus = P00AX2_A150SecUserStatus[0];
            n150SecUserStatus = P00AX2_n150SecUserStatus[0];
            A144SecUserEmail = P00AX2_A144SecUserEmail[0];
            n144SecUserEmail = P00AX2_n144SecUserEmail[0];
            A143SecUserFullName = P00AX2_A143SecUserFullName[0];
            n143SecUserFullName = P00AX2_n143SecUserFullName[0];
            A133SecUserId = P00AX2_A133SecUserId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AX2_A141SecUserName[0], A141SecUserName) == 0 ) )
            {
               BRKAX2 = false;
               A133SecUserId = P00AX2_A133SecUserId[0];
               AV27count = (long)(AV27count+1);
               BRKAX2 = true;
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
            if ( ! BRKAX2 )
            {
               BRKAX2 = true;
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
         AV53Usuariowwds_1_filterfulltext = AV39FilterFullText;
         AV54Usuariowwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Usuariowwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Usuariowwds_4_secusername1 = AV42SecUserName1;
         AV57Usuariowwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Usuariowwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Usuariowwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Usuariowwds_8_secusername2 = AV46SecUserName2;
         AV61Usuariowwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Usuariowwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Usuariowwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Usuariowwds_12_secusername3 = AV50SecUserName3;
         AV65Usuariowwds_13_tfsecusername = AV10TFSecUserName;
         AV66Usuariowwds_14_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV67Usuariowwds_15_tfsecuserfullname = AV12TFSecUserFullName;
         AV68Usuariowwds_16_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV69Usuariowwds_17_tfsecuseremail = AV14TFSecUserEmail;
         AV70Usuariowwds_18_tfsecuseremail_sel = AV15TFSecUserEmail_Sel;
         AV71Usuariowwds_19_tfsecuserstatus_sel = AV16TFSecUserStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Usuariowwds_1_filterfulltext ,
                                              AV54Usuariowwds_2_dynamicfiltersselector1 ,
                                              AV55Usuariowwds_3_dynamicfiltersoperator1 ,
                                              AV56Usuariowwds_4_secusername1 ,
                                              AV57Usuariowwds_5_dynamicfiltersenabled2 ,
                                              AV58Usuariowwds_6_dynamicfiltersselector2 ,
                                              AV59Usuariowwds_7_dynamicfiltersoperator2 ,
                                              AV60Usuariowwds_8_secusername2 ,
                                              AV61Usuariowwds_9_dynamicfiltersenabled3 ,
                                              AV62Usuariowwds_10_dynamicfiltersselector3 ,
                                              AV63Usuariowwds_11_dynamicfiltersoperator3 ,
                                              AV64Usuariowwds_12_secusername3 ,
                                              AV66Usuariowwds_14_tfsecusername_sel ,
                                              AV65Usuariowwds_13_tfsecusername ,
                                              AV68Usuariowwds_16_tfsecuserfullname_sel ,
                                              AV67Usuariowwds_15_tfsecuserfullname ,
                                              AV70Usuariowwds_18_tfsecuseremail_sel ,
                                              AV69Usuariowwds_17_tfsecuseremail ,
                                              AV71Usuariowwds_19_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV56Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Usuariowwds_4_secusername1), "%", "");
         lV56Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Usuariowwds_4_secusername1), "%", "");
         lV60Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV60Usuariowwds_8_secusername2), "%", "");
         lV60Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV60Usuariowwds_8_secusername2), "%", "");
         lV64Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV64Usuariowwds_12_secusername3), "%", "");
         lV64Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV64Usuariowwds_12_secusername3), "%", "");
         lV65Usuariowwds_13_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV65Usuariowwds_13_tfsecusername), "%", "");
         lV67Usuariowwds_15_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV67Usuariowwds_15_tfsecuserfullname), "%", "");
         lV69Usuariowwds_17_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV69Usuariowwds_17_tfsecuseremail), "%", "");
         /* Using cursor P00AX3 */
         pr_default.execute(1, new Object[] {lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV56Usuariowwds_4_secusername1, lV56Usuariowwds_4_secusername1, lV60Usuariowwds_8_secusername2, lV60Usuariowwds_8_secusername2, lV64Usuariowwds_12_secusername3, lV64Usuariowwds_12_secusername3, lV65Usuariowwds_13_tfsecusername, AV66Usuariowwds_14_tfsecusername_sel, lV67Usuariowwds_15_tfsecuserfullname, AV68Usuariowwds_16_tfsecuserfullname_sel, lV69Usuariowwds_17_tfsecuseremail, AV70Usuariowwds_18_tfsecuseremail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAX4 = false;
            A143SecUserFullName = P00AX3_A143SecUserFullName[0];
            n143SecUserFullName = P00AX3_n143SecUserFullName[0];
            A150SecUserStatus = P00AX3_A150SecUserStatus[0];
            n150SecUserStatus = P00AX3_n150SecUserStatus[0];
            A144SecUserEmail = P00AX3_A144SecUserEmail[0];
            n144SecUserEmail = P00AX3_n144SecUserEmail[0];
            A141SecUserName = P00AX3_A141SecUserName[0];
            n141SecUserName = P00AX3_n141SecUserName[0];
            A133SecUserId = P00AX3_A133SecUserId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AX3_A143SecUserFullName[0], A143SecUserFullName) == 0 ) )
            {
               BRKAX4 = false;
               A133SecUserId = P00AX3_A133SecUserId[0];
               AV27count = (long)(AV27count+1);
               BRKAX4 = true;
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
            if ( ! BRKAX4 )
            {
               BRKAX4 = true;
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
         AV53Usuariowwds_1_filterfulltext = AV39FilterFullText;
         AV54Usuariowwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Usuariowwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Usuariowwds_4_secusername1 = AV42SecUserName1;
         AV57Usuariowwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Usuariowwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Usuariowwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Usuariowwds_8_secusername2 = AV46SecUserName2;
         AV61Usuariowwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Usuariowwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Usuariowwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Usuariowwds_12_secusername3 = AV50SecUserName3;
         AV65Usuariowwds_13_tfsecusername = AV10TFSecUserName;
         AV66Usuariowwds_14_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV67Usuariowwds_15_tfsecuserfullname = AV12TFSecUserFullName;
         AV68Usuariowwds_16_tfsecuserfullname_sel = AV13TFSecUserFullName_Sel;
         AV69Usuariowwds_17_tfsecuseremail = AV14TFSecUserEmail;
         AV70Usuariowwds_18_tfsecuseremail_sel = AV15TFSecUserEmail_Sel;
         AV71Usuariowwds_19_tfsecuserstatus_sel = AV16TFSecUserStatus_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV53Usuariowwds_1_filterfulltext ,
                                              AV54Usuariowwds_2_dynamicfiltersselector1 ,
                                              AV55Usuariowwds_3_dynamicfiltersoperator1 ,
                                              AV56Usuariowwds_4_secusername1 ,
                                              AV57Usuariowwds_5_dynamicfiltersenabled2 ,
                                              AV58Usuariowwds_6_dynamicfiltersselector2 ,
                                              AV59Usuariowwds_7_dynamicfiltersoperator2 ,
                                              AV60Usuariowwds_8_secusername2 ,
                                              AV61Usuariowwds_9_dynamicfiltersenabled3 ,
                                              AV62Usuariowwds_10_dynamicfiltersselector3 ,
                                              AV63Usuariowwds_11_dynamicfiltersoperator3 ,
                                              AV64Usuariowwds_12_secusername3 ,
                                              AV66Usuariowwds_14_tfsecusername_sel ,
                                              AV65Usuariowwds_13_tfsecusername ,
                                              AV68Usuariowwds_16_tfsecuserfullname_sel ,
                                              AV67Usuariowwds_15_tfsecuserfullname ,
                                              AV70Usuariowwds_18_tfsecuseremail_sel ,
                                              AV69Usuariowwds_17_tfsecuseremail ,
                                              AV71Usuariowwds_19_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV53Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext), "%", "");
         lV56Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Usuariowwds_4_secusername1), "%", "");
         lV56Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Usuariowwds_4_secusername1), "%", "");
         lV60Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV60Usuariowwds_8_secusername2), "%", "");
         lV60Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV60Usuariowwds_8_secusername2), "%", "");
         lV64Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV64Usuariowwds_12_secusername3), "%", "");
         lV64Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV64Usuariowwds_12_secusername3), "%", "");
         lV65Usuariowwds_13_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV65Usuariowwds_13_tfsecusername), "%", "");
         lV67Usuariowwds_15_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV67Usuariowwds_15_tfsecuserfullname), "%", "");
         lV69Usuariowwds_17_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV69Usuariowwds_17_tfsecuseremail), "%", "");
         /* Using cursor P00AX4 */
         pr_default.execute(2, new Object[] {lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV53Usuariowwds_1_filterfulltext, lV56Usuariowwds_4_secusername1, lV56Usuariowwds_4_secusername1, lV60Usuariowwds_8_secusername2, lV60Usuariowwds_8_secusername2, lV64Usuariowwds_12_secusername3, lV64Usuariowwds_12_secusername3, lV65Usuariowwds_13_tfsecusername, AV66Usuariowwds_14_tfsecusername_sel, lV67Usuariowwds_15_tfsecuserfullname, AV68Usuariowwds_16_tfsecuserfullname_sel, lV69Usuariowwds_17_tfsecuseremail, AV70Usuariowwds_18_tfsecuseremail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAX6 = false;
            A144SecUserEmail = P00AX4_A144SecUserEmail[0];
            n144SecUserEmail = P00AX4_n144SecUserEmail[0];
            A150SecUserStatus = P00AX4_A150SecUserStatus[0];
            n150SecUserStatus = P00AX4_n150SecUserStatus[0];
            A143SecUserFullName = P00AX4_A143SecUserFullName[0];
            n143SecUserFullName = P00AX4_n143SecUserFullName[0];
            A141SecUserName = P00AX4_A141SecUserName[0];
            n141SecUserName = P00AX4_n141SecUserName[0];
            A133SecUserId = P00AX4_A133SecUserId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AX4_A144SecUserEmail[0], A144SecUserEmail) == 0 ) )
            {
               BRKAX6 = false;
               A133SecUserId = P00AX4_A133SecUserId[0];
               AV27count = (long)(AV27count+1);
               BRKAX6 = true;
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
            if ( ! BRKAX6 )
            {
               BRKAX6 = true;
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
         AV44DynamicFiltersSelector2 = "";
         AV46SecUserName2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50SecUserName3 = "";
         AV53Usuariowwds_1_filterfulltext = "";
         AV54Usuariowwds_2_dynamicfiltersselector1 = "";
         AV56Usuariowwds_4_secusername1 = "";
         AV58Usuariowwds_6_dynamicfiltersselector2 = "";
         AV60Usuariowwds_8_secusername2 = "";
         AV62Usuariowwds_10_dynamicfiltersselector3 = "";
         AV64Usuariowwds_12_secusername3 = "";
         AV65Usuariowwds_13_tfsecusername = "";
         AV66Usuariowwds_14_tfsecusername_sel = "";
         AV67Usuariowwds_15_tfsecuserfullname = "";
         AV68Usuariowwds_16_tfsecuserfullname_sel = "";
         AV69Usuariowwds_17_tfsecuseremail = "";
         AV70Usuariowwds_18_tfsecuseremail_sel = "";
         lV53Usuariowwds_1_filterfulltext = "";
         lV56Usuariowwds_4_secusername1 = "";
         lV60Usuariowwds_8_secusername2 = "";
         lV64Usuariowwds_12_secusername3 = "";
         lV65Usuariowwds_13_tfsecusername = "";
         lV67Usuariowwds_15_tfsecuserfullname = "";
         lV69Usuariowwds_17_tfsecuseremail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         P00AX2_A141SecUserName = new string[] {""} ;
         P00AX2_n141SecUserName = new bool[] {false} ;
         P00AX2_A150SecUserStatus = new bool[] {false} ;
         P00AX2_n150SecUserStatus = new bool[] {false} ;
         P00AX2_A144SecUserEmail = new string[] {""} ;
         P00AX2_n144SecUserEmail = new bool[] {false} ;
         P00AX2_A143SecUserFullName = new string[] {""} ;
         P00AX2_n143SecUserFullName = new bool[] {false} ;
         P00AX2_A133SecUserId = new short[1] ;
         AV22Option = "";
         AV24OptionDesc = "";
         P00AX3_A143SecUserFullName = new string[] {""} ;
         P00AX3_n143SecUserFullName = new bool[] {false} ;
         P00AX3_A150SecUserStatus = new bool[] {false} ;
         P00AX3_n150SecUserStatus = new bool[] {false} ;
         P00AX3_A144SecUserEmail = new string[] {""} ;
         P00AX3_n144SecUserEmail = new bool[] {false} ;
         P00AX3_A141SecUserName = new string[] {""} ;
         P00AX3_n141SecUserName = new bool[] {false} ;
         P00AX3_A133SecUserId = new short[1] ;
         P00AX4_A144SecUserEmail = new string[] {""} ;
         P00AX4_n144SecUserEmail = new bool[] {false} ;
         P00AX4_A150SecUserStatus = new bool[] {false} ;
         P00AX4_n150SecUserStatus = new bool[] {false} ;
         P00AX4_A143SecUserFullName = new string[] {""} ;
         P00AX4_n143SecUserFullName = new bool[] {false} ;
         P00AX4_A141SecUserName = new string[] {""} ;
         P00AX4_n141SecUserName = new bool[] {false} ;
         P00AX4_A133SecUserId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AX2_A141SecUserName, P00AX2_n141SecUserName, P00AX2_A150SecUserStatus, P00AX2_n150SecUserStatus, P00AX2_A144SecUserEmail, P00AX2_n144SecUserEmail, P00AX2_A143SecUserFullName, P00AX2_n143SecUserFullName, P00AX2_A133SecUserId
               }
               , new Object[] {
               P00AX3_A143SecUserFullName, P00AX3_n143SecUserFullName, P00AX3_A150SecUserStatus, P00AX3_n150SecUserStatus, P00AX3_A144SecUserEmail, P00AX3_n144SecUserEmail, P00AX3_A141SecUserName, P00AX3_n141SecUserName, P00AX3_A133SecUserId
               }
               , new Object[] {
               P00AX4_A144SecUserEmail, P00AX4_n144SecUserEmail, P00AX4_A150SecUserStatus, P00AX4_n150SecUserStatus, P00AX4_A143SecUserFullName, P00AX4_n143SecUserFullName, P00AX4_A141SecUserName, P00AX4_n141SecUserName, P00AX4_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV16TFSecUserStatus_Sel ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV55Usuariowwds_3_dynamicfiltersoperator1 ;
      private short AV59Usuariowwds_7_dynamicfiltersoperator2 ;
      private short AV63Usuariowwds_11_dynamicfiltersoperator3 ;
      private short AV71Usuariowwds_19_tfsecuserstatus_sel ;
      private short A133SecUserId ;
      private int AV51GXV1 ;
      private long AV27count ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV57Usuariowwds_5_dynamicfiltersenabled2 ;
      private bool AV61Usuariowwds_9_dynamicfiltersenabled3 ;
      private bool A150SecUserStatus ;
      private bool BRKAX2 ;
      private bool n141SecUserName ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool BRKAX4 ;
      private bool BRKAX6 ;
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
      private string AV44DynamicFiltersSelector2 ;
      private string AV46SecUserName2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV50SecUserName3 ;
      private string AV53Usuariowwds_1_filterfulltext ;
      private string AV54Usuariowwds_2_dynamicfiltersselector1 ;
      private string AV56Usuariowwds_4_secusername1 ;
      private string AV58Usuariowwds_6_dynamicfiltersselector2 ;
      private string AV60Usuariowwds_8_secusername2 ;
      private string AV62Usuariowwds_10_dynamicfiltersselector3 ;
      private string AV64Usuariowwds_12_secusername3 ;
      private string AV65Usuariowwds_13_tfsecusername ;
      private string AV66Usuariowwds_14_tfsecusername_sel ;
      private string AV67Usuariowwds_15_tfsecuserfullname ;
      private string AV68Usuariowwds_16_tfsecuserfullname_sel ;
      private string AV69Usuariowwds_17_tfsecuseremail ;
      private string AV70Usuariowwds_18_tfsecuseremail_sel ;
      private string lV53Usuariowwds_1_filterfulltext ;
      private string lV56Usuariowwds_4_secusername1 ;
      private string lV60Usuariowwds_8_secusername2 ;
      private string lV64Usuariowwds_12_secusername3 ;
      private string lV65Usuariowwds_13_tfsecusername ;
      private string lV67Usuariowwds_15_tfsecuserfullname ;
      private string lV69Usuariowwds_17_tfsecuseremail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
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
      private string[] P00AX2_A141SecUserName ;
      private bool[] P00AX2_n141SecUserName ;
      private bool[] P00AX2_A150SecUserStatus ;
      private bool[] P00AX2_n150SecUserStatus ;
      private string[] P00AX2_A144SecUserEmail ;
      private bool[] P00AX2_n144SecUserEmail ;
      private string[] P00AX2_A143SecUserFullName ;
      private bool[] P00AX2_n143SecUserFullName ;
      private short[] P00AX2_A133SecUserId ;
      private string[] P00AX3_A143SecUserFullName ;
      private bool[] P00AX3_n143SecUserFullName ;
      private bool[] P00AX3_A150SecUserStatus ;
      private bool[] P00AX3_n150SecUserStatus ;
      private string[] P00AX3_A144SecUserEmail ;
      private bool[] P00AX3_n144SecUserEmail ;
      private string[] P00AX3_A141SecUserName ;
      private bool[] P00AX3_n141SecUserName ;
      private short[] P00AX3_A133SecUserId ;
      private string[] P00AX4_A144SecUserEmail ;
      private bool[] P00AX4_n144SecUserEmail ;
      private bool[] P00AX4_A150SecUserStatus ;
      private bool[] P00AX4_n150SecUserStatus ;
      private string[] P00AX4_A143SecUserFullName ;
      private bool[] P00AX4_n143SecUserFullName ;
      private string[] P00AX4_A141SecUserName ;
      private bool[] P00AX4_n141SecUserName ;
      private short[] P00AX4_A133SecUserId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class usuariowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AX2( IGxContext context ,
                                             string AV53Usuariowwds_1_filterfulltext ,
                                             string AV54Usuariowwds_2_dynamicfiltersselector1 ,
                                             short AV55Usuariowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Usuariowwds_4_secusername1 ,
                                             bool AV57Usuariowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Usuariowwds_6_dynamicfiltersselector2 ,
                                             short AV59Usuariowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Usuariowwds_8_secusername2 ,
                                             bool AV61Usuariowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Usuariowwds_10_dynamicfiltersselector3 ,
                                             short AV63Usuariowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Usuariowwds_12_secusername3 ,
                                             string AV66Usuariowwds_14_tfsecusername_sel ,
                                             string AV65Usuariowwds_13_tfsecusername ,
                                             string AV68Usuariowwds_16_tfsecuserfullname_sel ,
                                             string AV67Usuariowwds_15_tfsecuserfullname ,
                                             string AV70Usuariowwds_18_tfsecuseremail_sel ,
                                             string AV69Usuariowwds_17_tfsecuseremail ,
                                             short AV71Usuariowwds_19_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SecUserName, SecUserStatus, SecUserEmail, SecUserFullName, SecUserId FROM SecUser";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserName like '%' || :lV53Usuariowwds_1_filterfulltext) or ( SecUserFullName like '%' || :lV53Usuariowwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV53Usuariowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Usuariowwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Usuariowwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Usuariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV56Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Usuariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV56Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV57Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV59Usuariowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV60Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV57Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV59Usuariowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV60Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV61Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV63Usuariowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV64Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV61Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV63Usuariowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV64Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuariowwds_14_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuariowwds_13_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV65Usuariowwds_13_tfsecusername)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuariowwds_14_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV66Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV66Usuariowwds_14_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuariowwds_16_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Usuariowwds_15_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV67Usuariowwds_15_tfsecuserfullname)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuariowwds_16_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV68Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV68Usuariowwds_16_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuariowwds_18_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuariowwds_17_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV69Usuariowwds_17_tfsecuseremail)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuariowwds_18_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV70Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV70Usuariowwds_18_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV71Usuariowwds_19_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV71Usuariowwds_19_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecUserName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AX3( IGxContext context ,
                                             string AV53Usuariowwds_1_filterfulltext ,
                                             string AV54Usuariowwds_2_dynamicfiltersselector1 ,
                                             short AV55Usuariowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Usuariowwds_4_secusername1 ,
                                             bool AV57Usuariowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Usuariowwds_6_dynamicfiltersselector2 ,
                                             short AV59Usuariowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Usuariowwds_8_secusername2 ,
                                             bool AV61Usuariowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Usuariowwds_10_dynamicfiltersselector3 ,
                                             short AV63Usuariowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Usuariowwds_12_secusername3 ,
                                             string AV66Usuariowwds_14_tfsecusername_sel ,
                                             string AV65Usuariowwds_13_tfsecusername ,
                                             string AV68Usuariowwds_16_tfsecuserfullname_sel ,
                                             string AV67Usuariowwds_15_tfsecuserfullname ,
                                             string AV70Usuariowwds_18_tfsecuseremail_sel ,
                                             string AV69Usuariowwds_17_tfsecuseremail ,
                                             short AV71Usuariowwds_19_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecUserFullName, SecUserStatus, SecUserEmail, SecUserName, SecUserId FROM SecUser";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserName like '%' || :lV53Usuariowwds_1_filterfulltext) or ( SecUserFullName like '%' || :lV53Usuariowwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV53Usuariowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Usuariowwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Usuariowwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Usuariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV56Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Usuariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV56Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV57Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV59Usuariowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV60Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV57Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV59Usuariowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV60Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV61Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV63Usuariowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV64Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV61Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV63Usuariowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV64Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuariowwds_14_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuariowwds_13_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV65Usuariowwds_13_tfsecusername)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuariowwds_14_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV66Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV66Usuariowwds_14_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuariowwds_16_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Usuariowwds_15_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV67Usuariowwds_15_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuariowwds_16_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV68Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV68Usuariowwds_16_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuariowwds_18_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuariowwds_17_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV69Usuariowwds_17_tfsecuseremail)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuariowwds_18_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV70Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV70Usuariowwds_18_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV71Usuariowwds_19_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV71Usuariowwds_19_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecUserFullName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AX4( IGxContext context ,
                                             string AV53Usuariowwds_1_filterfulltext ,
                                             string AV54Usuariowwds_2_dynamicfiltersselector1 ,
                                             short AV55Usuariowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Usuariowwds_4_secusername1 ,
                                             bool AV57Usuariowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Usuariowwds_6_dynamicfiltersselector2 ,
                                             short AV59Usuariowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Usuariowwds_8_secusername2 ,
                                             bool AV61Usuariowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Usuariowwds_10_dynamicfiltersselector3 ,
                                             short AV63Usuariowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Usuariowwds_12_secusername3 ,
                                             string AV66Usuariowwds_14_tfsecusername_sel ,
                                             string AV65Usuariowwds_13_tfsecusername ,
                                             string AV68Usuariowwds_16_tfsecuserfullname_sel ,
                                             string AV67Usuariowwds_15_tfsecuserfullname ,
                                             string AV70Usuariowwds_18_tfsecuseremail_sel ,
                                             string AV69Usuariowwds_17_tfsecuseremail ,
                                             short AV71Usuariowwds_19_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SecUserEmail, SecUserStatus, SecUserFullName, SecUserName, SecUserId FROM SecUser";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Usuariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserName like '%' || :lV53Usuariowwds_1_filterfulltext) or ( SecUserFullName like '%' || :lV53Usuariowwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV53Usuariowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Usuariowwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Usuariowwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Usuariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV56Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Usuariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV56Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV57Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV59Usuariowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV60Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV57Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV59Usuariowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV60Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV61Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV63Usuariowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV64Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV61Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV63Usuariowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV64Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuariowwds_14_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuariowwds_13_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV65Usuariowwds_13_tfsecusername)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuariowwds_14_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV66Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV66Usuariowwds_14_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuariowwds_16_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Usuariowwds_15_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV67Usuariowwds_15_tfsecuserfullname)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuariowwds_16_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV68Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV68Usuariowwds_16_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuariowwds_18_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuariowwds_17_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV69Usuariowwds_17_tfsecuseremail)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuariowwds_18_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV70Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV70Usuariowwds_18_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV71Usuariowwds_19_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV71Usuariowwds_19_tfsecuserstatus_sel == 2 )
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
                     return conditional_P00AX2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
               case 1 :
                     return conditional_P00AX3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
               case 2 :
                     return conditional_P00AX4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP00AX2;
          prmP00AX2 = new Object[] {
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV56Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV60Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV64Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV64Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV65Usuariowwds_13_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV66Usuariowwds_14_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Usuariowwds_15_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV68Usuariowwds_16_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Usuariowwds_17_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV70Usuariowwds_18_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00AX3;
          prmP00AX3 = new Object[] {
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV56Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV60Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV64Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV64Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV65Usuariowwds_13_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV66Usuariowwds_14_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Usuariowwds_15_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV68Usuariowwds_16_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Usuariowwds_17_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV70Usuariowwds_18_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00AX4;
          prmP00AX4 = new Object[] {
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV56Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV60Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV64Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV64Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV65Usuariowwds_13_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV66Usuariowwds_14_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Usuariowwds_15_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV68Usuariowwds_16_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Usuariowwds_17_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV70Usuariowwds_18_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AX3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AX4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
