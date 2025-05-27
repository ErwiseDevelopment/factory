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
   public class wpsecrolegetfilterdata : GXProcedure
   {
      public wpsecrolegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpsecrolegetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SECROLENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECROLENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SECROLEDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECROLEDESCRIPTIONOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("WpSecRoleGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpSecRoleGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("WpSecRoleGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV11TFSecRoleName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV12TFSecRoleName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV13TFSecRoleDescription = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV14TFSecRoleDescription_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40SecRoleName1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44SecRoleName2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48SecRoleName3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECROLENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFSecRoleName = AV15SearchTxt;
         AV12TFSecRoleName_Sel = "";
         AV52Wpsecroleds_1_filterfulltext = AV37FilterFullText;
         AV53Wpsecroleds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Wpsecroleds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Wpsecroleds_4_secrolename1 = AV40SecRoleName1;
         AV56Wpsecroleds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Wpsecroleds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Wpsecroleds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Wpsecroleds_8_secrolename2 = AV44SecRoleName2;
         AV60Wpsecroleds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Wpsecroleds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Wpsecroleds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Wpsecroleds_12_secrolename3 = AV48SecRoleName3;
         AV64Wpsecroleds_13_tfsecrolename = AV11TFSecRoleName;
         AV65Wpsecroleds_14_tfsecrolename_sel = AV12TFSecRoleName_Sel;
         AV66Wpsecroleds_15_tfsecroledescription = AV13TFSecRoleDescription;
         AV67Wpsecroleds_16_tfsecroledescription_sel = AV14TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Wpsecroleds_1_filterfulltext ,
                                              AV53Wpsecroleds_2_dynamicfiltersselector1 ,
                                              AV54Wpsecroleds_3_dynamicfiltersoperator1 ,
                                              AV55Wpsecroleds_4_secrolename1 ,
                                              AV56Wpsecroleds_5_dynamicfiltersenabled2 ,
                                              AV57Wpsecroleds_6_dynamicfiltersselector2 ,
                                              AV58Wpsecroleds_7_dynamicfiltersoperator2 ,
                                              AV59Wpsecroleds_8_secrolename2 ,
                                              AV60Wpsecroleds_9_dynamicfiltersenabled3 ,
                                              AV61Wpsecroleds_10_dynamicfiltersselector3 ,
                                              AV62Wpsecroleds_11_dynamicfiltersoperator3 ,
                                              AV63Wpsecroleds_12_secrolename3 ,
                                              AV65Wpsecroleds_14_tfsecrolename_sel ,
                                              AV64Wpsecroleds_13_tfsecrolename ,
                                              AV67Wpsecroleds_16_tfsecroledescription_sel ,
                                              AV66Wpsecroleds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV52Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wpsecroleds_1_filterfulltext), "%", "");
         lV52Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wpsecroleds_1_filterfulltext), "%", "");
         lV55Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1), "%", "");
         lV55Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1), "%", "");
         lV59Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2), "%", "");
         lV59Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2), "%", "");
         lV63Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3), "%", "");
         lV63Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3), "%", "");
         lV64Wpsecroleds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV64Wpsecroleds_13_tfsecrolename), "%", "");
         lV66Wpsecroleds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV66Wpsecroleds_15_tfsecroledescription), "%", "");
         /* Using cursor P005A2 */
         pr_default.execute(0, new Object[] {lV52Wpsecroleds_1_filterfulltext, lV52Wpsecroleds_1_filterfulltext, lV55Wpsecroleds_4_secrolename1, lV55Wpsecroleds_4_secrolename1, lV59Wpsecroleds_8_secrolename2, lV59Wpsecroleds_8_secrolename2, lV63Wpsecroleds_12_secrolename3, lV63Wpsecroleds_12_secrolename3, lV64Wpsecroleds_13_tfsecrolename, AV65Wpsecroleds_14_tfsecrolename_sel, lV66Wpsecroleds_15_tfsecroledescription, AV67Wpsecroleds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5A2 = false;
            A140SecRoleName = P005A2_A140SecRoleName[0];
            A139SecRoleDescription = P005A2_A139SecRoleDescription[0];
            A131SecRoleId = P005A2_A131SecRoleId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005A2_A140SecRoleName[0], A140SecRoleName) == 0 ) )
            {
               BRK5A2 = false;
               A131SecRoleId = P005A2_A131SecRoleId[0];
               AV25count = (long)(AV25count+1);
               BRK5A2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A140SecRoleName)) ? "<#Empty#>" : A140SecRoleName);
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
            if ( ! BRK5A2 )
            {
               BRK5A2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECROLEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV13TFSecRoleDescription = AV15SearchTxt;
         AV14TFSecRoleDescription_Sel = "";
         AV52Wpsecroleds_1_filterfulltext = AV37FilterFullText;
         AV53Wpsecroleds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Wpsecroleds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Wpsecroleds_4_secrolename1 = AV40SecRoleName1;
         AV56Wpsecroleds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Wpsecroleds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Wpsecroleds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Wpsecroleds_8_secrolename2 = AV44SecRoleName2;
         AV60Wpsecroleds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Wpsecroleds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Wpsecroleds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Wpsecroleds_12_secrolename3 = AV48SecRoleName3;
         AV64Wpsecroleds_13_tfsecrolename = AV11TFSecRoleName;
         AV65Wpsecroleds_14_tfsecrolename_sel = AV12TFSecRoleName_Sel;
         AV66Wpsecroleds_15_tfsecroledescription = AV13TFSecRoleDescription;
         AV67Wpsecroleds_16_tfsecroledescription_sel = AV14TFSecRoleDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Wpsecroleds_1_filterfulltext ,
                                              AV53Wpsecroleds_2_dynamicfiltersselector1 ,
                                              AV54Wpsecroleds_3_dynamicfiltersoperator1 ,
                                              AV55Wpsecroleds_4_secrolename1 ,
                                              AV56Wpsecroleds_5_dynamicfiltersenabled2 ,
                                              AV57Wpsecroleds_6_dynamicfiltersselector2 ,
                                              AV58Wpsecroleds_7_dynamicfiltersoperator2 ,
                                              AV59Wpsecroleds_8_secrolename2 ,
                                              AV60Wpsecroleds_9_dynamicfiltersenabled3 ,
                                              AV61Wpsecroleds_10_dynamicfiltersselector3 ,
                                              AV62Wpsecroleds_11_dynamicfiltersoperator3 ,
                                              AV63Wpsecroleds_12_secrolename3 ,
                                              AV65Wpsecroleds_14_tfsecrolename_sel ,
                                              AV64Wpsecroleds_13_tfsecrolename ,
                                              AV67Wpsecroleds_16_tfsecroledescription_sel ,
                                              AV66Wpsecroleds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV52Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wpsecroleds_1_filterfulltext), "%", "");
         lV52Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wpsecroleds_1_filterfulltext), "%", "");
         lV55Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1), "%", "");
         lV55Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1), "%", "");
         lV59Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2), "%", "");
         lV59Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2), "%", "");
         lV63Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3), "%", "");
         lV63Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3), "%", "");
         lV64Wpsecroleds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV64Wpsecroleds_13_tfsecrolename), "%", "");
         lV66Wpsecroleds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV66Wpsecroleds_15_tfsecroledescription), "%", "");
         /* Using cursor P005A3 */
         pr_default.execute(1, new Object[] {lV52Wpsecroleds_1_filterfulltext, lV52Wpsecroleds_1_filterfulltext, lV55Wpsecroleds_4_secrolename1, lV55Wpsecroleds_4_secrolename1, lV59Wpsecroleds_8_secrolename2, lV59Wpsecroleds_8_secrolename2, lV63Wpsecroleds_12_secrolename3, lV63Wpsecroleds_12_secrolename3, lV64Wpsecroleds_13_tfsecrolename, AV65Wpsecroleds_14_tfsecrolename_sel, lV66Wpsecroleds_15_tfsecroledescription, AV67Wpsecroleds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5A4 = false;
            A139SecRoleDescription = P005A3_A139SecRoleDescription[0];
            A140SecRoleName = P005A3_A140SecRoleName[0];
            A131SecRoleId = P005A3_A131SecRoleId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005A3_A139SecRoleDescription[0], A139SecRoleDescription) == 0 ) )
            {
               BRK5A4 = false;
               A131SecRoleId = P005A3_A131SecRoleId[0];
               AV25count = (long)(AV25count+1);
               BRK5A4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A139SecRoleDescription)) ? "<#Empty#>" : A139SecRoleDescription);
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
            if ( ! BRK5A4 )
            {
               BRK5A4 = true;
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
         AV11TFSecRoleName = "";
         AV12TFSecRoleName_Sel = "";
         AV13TFSecRoleDescription = "";
         AV14TFSecRoleDescription_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40SecRoleName1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44SecRoleName2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48SecRoleName3 = "";
         AV52Wpsecroleds_1_filterfulltext = "";
         AV53Wpsecroleds_2_dynamicfiltersselector1 = "";
         AV55Wpsecroleds_4_secrolename1 = "";
         AV57Wpsecroleds_6_dynamicfiltersselector2 = "";
         AV59Wpsecroleds_8_secrolename2 = "";
         AV61Wpsecroleds_10_dynamicfiltersselector3 = "";
         AV63Wpsecroleds_12_secrolename3 = "";
         AV64Wpsecroleds_13_tfsecrolename = "";
         AV65Wpsecroleds_14_tfsecrolename_sel = "";
         AV66Wpsecroleds_15_tfsecroledescription = "";
         AV67Wpsecroleds_16_tfsecroledescription_sel = "";
         lV52Wpsecroleds_1_filterfulltext = "";
         lV55Wpsecroleds_4_secrolename1 = "";
         lV59Wpsecroleds_8_secrolename2 = "";
         lV63Wpsecroleds_12_secrolename3 = "";
         lV64Wpsecroleds_13_tfsecrolename = "";
         lV66Wpsecroleds_15_tfsecroledescription = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         P005A2_A140SecRoleName = new string[] {""} ;
         P005A2_A139SecRoleDescription = new string[] {""} ;
         P005A2_A131SecRoleId = new short[1] ;
         AV20Option = "";
         P005A3_A139SecRoleDescription = new string[] {""} ;
         P005A3_A140SecRoleName = new string[] {""} ;
         P005A3_A131SecRoleId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsecrolegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005A2_A140SecRoleName, P005A2_A139SecRoleDescription, P005A2_A131SecRoleId
               }
               , new Object[] {
               P005A3_A139SecRoleDescription, P005A3_A140SecRoleName, P005A3_A131SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV54Wpsecroleds_3_dynamicfiltersoperator1 ;
      private short AV58Wpsecroleds_7_dynamicfiltersoperator2 ;
      private short AV62Wpsecroleds_11_dynamicfiltersoperator3 ;
      private short A131SecRoleId ;
      private int AV50GXV1 ;
      private long AV25count ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV56Wpsecroleds_5_dynamicfiltersenabled2 ;
      private bool AV60Wpsecroleds_9_dynamicfiltersenabled3 ;
      private bool BRK5A2 ;
      private bool BRK5A4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFSecRoleName ;
      private string AV12TFSecRoleName_Sel ;
      private string AV13TFSecRoleDescription ;
      private string AV14TFSecRoleDescription_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40SecRoleName1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44SecRoleName2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48SecRoleName3 ;
      private string AV52Wpsecroleds_1_filterfulltext ;
      private string AV53Wpsecroleds_2_dynamicfiltersselector1 ;
      private string AV55Wpsecroleds_4_secrolename1 ;
      private string AV57Wpsecroleds_6_dynamicfiltersselector2 ;
      private string AV59Wpsecroleds_8_secrolename2 ;
      private string AV61Wpsecroleds_10_dynamicfiltersselector3 ;
      private string AV63Wpsecroleds_12_secrolename3 ;
      private string AV64Wpsecroleds_13_tfsecrolename ;
      private string AV65Wpsecroleds_14_tfsecrolename_sel ;
      private string AV66Wpsecroleds_15_tfsecroledescription ;
      private string AV67Wpsecroleds_16_tfsecroledescription_sel ;
      private string lV52Wpsecroleds_1_filterfulltext ;
      private string lV55Wpsecroleds_4_secrolename1 ;
      private string lV59Wpsecroleds_8_secrolename2 ;
      private string lV63Wpsecroleds_12_secrolename3 ;
      private string lV64Wpsecroleds_13_tfsecrolename ;
      private string lV66Wpsecroleds_15_tfsecroledescription ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string AV20Option ;
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
      private string[] P005A2_A140SecRoleName ;
      private string[] P005A2_A139SecRoleDescription ;
      private short[] P005A2_A131SecRoleId ;
      private string[] P005A3_A139SecRoleDescription ;
      private string[] P005A3_A140SecRoleName ;
      private short[] P005A3_A131SecRoleId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpsecrolegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005A2( IGxContext context ,
                                             string AV52Wpsecroleds_1_filterfulltext ,
                                             string AV53Wpsecroleds_2_dynamicfiltersselector1 ,
                                             short AV54Wpsecroleds_3_dynamicfiltersoperator1 ,
                                             string AV55Wpsecroleds_4_secrolename1 ,
                                             bool AV56Wpsecroleds_5_dynamicfiltersenabled2 ,
                                             string AV57Wpsecroleds_6_dynamicfiltersselector2 ,
                                             short AV58Wpsecroleds_7_dynamicfiltersoperator2 ,
                                             string AV59Wpsecroleds_8_secrolename2 ,
                                             bool AV60Wpsecroleds_9_dynamicfiltersenabled3 ,
                                             string AV61Wpsecroleds_10_dynamicfiltersselector3 ,
                                             short AV62Wpsecroleds_11_dynamicfiltersoperator3 ,
                                             string AV63Wpsecroleds_12_secrolename3 ,
                                             string AV65Wpsecroleds_14_tfsecrolename_sel ,
                                             string AV64Wpsecroleds_13_tfsecrolename ,
                                             string AV67Wpsecroleds_16_tfsecroledescription_sel ,
                                             string AV66Wpsecroleds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SecRoleName, SecRoleDescription, SecRoleId FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpsecroleds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV52Wpsecroleds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV52Wpsecroleds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV54Wpsecroleds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV55Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV54Wpsecroleds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV55Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV56Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV58Wpsecroleds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV59Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV56Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV58Wpsecroleds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV59Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV60Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV62Wpsecroleds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV63Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV60Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV62Wpsecroleds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV63Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpsecroleds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV64Wpsecroleds_13_tfsecrolename)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV65Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV65Wpsecroleds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpsecroleds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV66Wpsecroleds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV67Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV67Wpsecroleds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecRoleName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005A3( IGxContext context ,
                                             string AV52Wpsecroleds_1_filterfulltext ,
                                             string AV53Wpsecroleds_2_dynamicfiltersselector1 ,
                                             short AV54Wpsecroleds_3_dynamicfiltersoperator1 ,
                                             string AV55Wpsecroleds_4_secrolename1 ,
                                             bool AV56Wpsecroleds_5_dynamicfiltersenabled2 ,
                                             string AV57Wpsecroleds_6_dynamicfiltersselector2 ,
                                             short AV58Wpsecroleds_7_dynamicfiltersoperator2 ,
                                             string AV59Wpsecroleds_8_secrolename2 ,
                                             bool AV60Wpsecroleds_9_dynamicfiltersenabled3 ,
                                             string AV61Wpsecroleds_10_dynamicfiltersselector3 ,
                                             short AV62Wpsecroleds_11_dynamicfiltersoperator3 ,
                                             string AV63Wpsecroleds_12_secrolename3 ,
                                             string AV65Wpsecroleds_14_tfsecrolename_sel ,
                                             string AV64Wpsecroleds_13_tfsecrolename ,
                                             string AV67Wpsecroleds_16_tfsecroledescription_sel ,
                                             string AV66Wpsecroleds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecRoleDescription, SecRoleName, SecRoleId FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpsecroleds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV52Wpsecroleds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV52Wpsecroleds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV54Wpsecroleds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV55Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV54Wpsecroleds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV55Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV56Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV58Wpsecroleds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV59Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV56Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV58Wpsecroleds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV59Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV60Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV62Wpsecroleds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV63Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV60Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV62Wpsecroleds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV63Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpsecroleds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV64Wpsecroleds_13_tfsecrolename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV65Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV65Wpsecroleds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpsecroleds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV66Wpsecroleds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV67Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV67Wpsecroleds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SecRoleDescription";
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
                     return conditional_P005A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P005A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP005A2;
          prmP005A2 = new Object[] {
          new ParDef("lV52Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV55Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV59Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV59Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV63Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV63Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV64Wpsecroleds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV65Wpsecroleds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Wpsecroleds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV67Wpsecroleds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          Object[] prmP005A3;
          prmP005A3 = new Object[] {
          new ParDef("lV52Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV55Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV59Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV59Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV63Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV63Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV64Wpsecroleds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV65Wpsecroleds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Wpsecroleds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV67Wpsecroleds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
