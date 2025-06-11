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
   public class wpperfilusuariogetfilterdata : GXProcedure
   {
      public wpperfilusuariogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpperfilusuariogetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_SECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_SECROLEDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECROLEDESCRIPTIONOPTIONS' */
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
         if ( StringUtil.StrCmp(AV27Session.Get("WpPerfilUsuarioGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpPerfilUsuarioGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WpPerfilUsuarioGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV10TFSecUserName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV11TFSecUserName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV14TFSecRoleDescription = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV15TFSecRoleDescription_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "PARM_&SECROLEID") == 0 )
            {
               AV53SecRoleId = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "PARM_&SECROLENAME") == 0 )
            {
               AV54SecRoleName = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV39DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "SECUSERROLEACTIVE") == 0 )
            {
               AV55SecUserRoleActive1 = BooleanUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV40DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV41SecUserName1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV40DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV42SecRoleName1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "SECUSERROLEACTIVE") == 0 )
               {
                  AV56SecUserRoleActive2 = BooleanUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value);
               }
               else if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV46SecUserName2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV47SecRoleName2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "SECUSERROLEACTIVE") == 0 )
                  {
                     AV57SecUserRoleActive3 = BooleanUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value);
                  }
                  else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV51SecUserName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV52SecRoleName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecUserName = AV16SearchTxt;
         AV11TFSecUserName_Sel = "";
         AV60Wpperfilusuariods_1_secroleid = AV53SecRoleId;
         AV61Wpperfilusuariods_2_filterfulltext = AV38FilterFullText;
         AV62Wpperfilusuariods_3_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV63Wpperfilusuariods_4_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV64Wpperfilusuariods_5_secuserroleactive1 = AV55SecUserRoleActive1;
         AV65Wpperfilusuariods_6_secusername1 = AV41SecUserName1;
         AV66Wpperfilusuariods_7_secrolename1 = AV42SecRoleName1;
         AV67Wpperfilusuariods_8_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV68Wpperfilusuariods_9_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV69Wpperfilusuariods_10_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV70Wpperfilusuariods_11_secuserroleactive2 = AV56SecUserRoleActive2;
         AV71Wpperfilusuariods_12_secusername2 = AV46SecUserName2;
         AV72Wpperfilusuariods_13_secrolename2 = AV47SecRoleName2;
         AV73Wpperfilusuariods_14_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV74Wpperfilusuariods_15_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV75Wpperfilusuariods_16_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV76Wpperfilusuariods_17_secuserroleactive3 = AV57SecUserRoleActive3;
         AV77Wpperfilusuariods_18_secusername3 = AV51SecUserName3;
         AV78Wpperfilusuariods_19_secrolename3 = AV52SecRoleName3;
         AV79Wpperfilusuariods_20_tfsecusername = AV10TFSecUserName;
         AV80Wpperfilusuariods_21_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV81Wpperfilusuariods_22_tfsecroledescription = AV14TFSecRoleDescription;
         AV82Wpperfilusuariods_23_tfsecroledescription_sel = AV15TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Wpperfilusuariods_2_filterfulltext ,
                                              AV62Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                              AV64Wpperfilusuariods_5_secuserroleactive1 ,
                                              AV63Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                              AV65Wpperfilusuariods_6_secusername1 ,
                                              AV66Wpperfilusuariods_7_secrolename1 ,
                                              AV67Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                              AV68Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                              AV70Wpperfilusuariods_11_secuserroleactive2 ,
                                              AV69Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                              AV71Wpperfilusuariods_12_secusername2 ,
                                              AV72Wpperfilusuariods_13_secrolename2 ,
                                              AV73Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                              AV74Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                              AV76Wpperfilusuariods_17_secuserroleactive3 ,
                                              AV75Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                              AV77Wpperfilusuariods_18_secusername3 ,
                                              AV78Wpperfilusuariods_19_secrolename3 ,
                                              AV80Wpperfilusuariods_21_tfsecusername_sel ,
                                              AV79Wpperfilusuariods_20_tfsecusername ,
                                              AV82Wpperfilusuariods_23_tfsecroledescription_sel ,
                                              AV81Wpperfilusuariods_22_tfsecroledescription ,
                                              A141SecUserName ,
                                              A139SecRoleDescription ,
                                              A647SecUserRoleActive ,
                                              A140SecRoleName ,
                                              AV60Wpperfilusuariods_1_secroleid ,
                                              A131SecRoleId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV61Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpperfilusuariods_2_filterfulltext), "%", "");
         lV61Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpperfilusuariods_2_filterfulltext), "%", "");
         lV65Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1), "%", "");
         lV65Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1), "%", "");
         lV66Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1), "%", "");
         lV66Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1), "%", "");
         lV71Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2), "%", "");
         lV71Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2), "%", "");
         lV72Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2), "%", "");
         lV72Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2), "%", "");
         lV77Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3), "%", "");
         lV77Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3), "%", "");
         lV78Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3), "%", "");
         lV78Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3), "%", "");
         lV79Wpperfilusuariods_20_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV79Wpperfilusuariods_20_tfsecusername), "%", "");
         lV81Wpperfilusuariods_22_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV81Wpperfilusuariods_22_tfsecroledescription), "%", "");
         /* Using cursor P00C62 */
         pr_default.execute(0, new Object[] {AV60Wpperfilusuariods_1_secroleid, lV61Wpperfilusuariods_2_filterfulltext, lV61Wpperfilusuariods_2_filterfulltext, AV64Wpperfilusuariods_5_secuserroleactive1, lV65Wpperfilusuariods_6_secusername1, lV65Wpperfilusuariods_6_secusername1, lV66Wpperfilusuariods_7_secrolename1, lV66Wpperfilusuariods_7_secrolename1, AV70Wpperfilusuariods_11_secuserroleactive2, lV71Wpperfilusuariods_12_secusername2, lV71Wpperfilusuariods_12_secusername2, lV72Wpperfilusuariods_13_secrolename2, lV72Wpperfilusuariods_13_secrolename2, AV76Wpperfilusuariods_17_secuserroleactive3, lV77Wpperfilusuariods_18_secusername3, lV77Wpperfilusuariods_18_secusername3, lV78Wpperfilusuariods_19_secrolename3, lV78Wpperfilusuariods_19_secrolename3, lV79Wpperfilusuariods_20_tfsecusername, AV80Wpperfilusuariods_21_tfsecusername_sel, lV81Wpperfilusuariods_22_tfsecroledescription, AV82Wpperfilusuariods_23_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKC62 = false;
            A131SecRoleId = P00C62_A131SecRoleId[0];
            A133SecUserId = P00C62_A133SecUserId[0];
            A140SecRoleName = P00C62_A140SecRoleName[0];
            A647SecUserRoleActive = P00C62_A647SecUserRoleActive[0];
            A139SecRoleDescription = P00C62_A139SecRoleDescription[0];
            A141SecUserName = P00C62_A141SecUserName[0];
            n141SecUserName = P00C62_n141SecUserName[0];
            A140SecRoleName = P00C62_A140SecRoleName[0];
            A139SecRoleDescription = P00C62_A139SecRoleDescription[0];
            A141SecUserName = P00C62_A141SecUserName[0];
            n141SecUserName = P00C62_n141SecUserName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00C62_A131SecRoleId[0] == A131SecRoleId ) && ( P00C62_A133SecUserId[0] == A133SecUserId ) )
            {
               BRKC62 = false;
               AV26count = (long)(AV26count+1);
               BRKC62 = true;
               pr_default.readNext(0);
            }
            AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? "<#Empty#>" : A141SecUserName);
            AV23OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")));
            AV20InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV21Option, "<#Empty#>") != 0 ) && ( AV20InsertIndex <= AV22Options.Count ) && ( ( StringUtil.StrCmp(((string)AV24OptionsDesc.Item(AV20InsertIndex)), AV23OptionDesc) < 0 ) || ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV20InsertIndex = (int)(AV20InsertIndex+1);
            }
            AV22Options.Add(AV21Option, AV20InsertIndex);
            AV24OptionsDesc.Add(AV23OptionDesc, AV20InsertIndex);
            AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), AV20InsertIndex);
            if ( AV22Options.Count == AV17SkipItems + 11 )
            {
               AV22Options.RemoveItem(AV22Options.Count);
               AV24OptionsDesc.RemoveItem(AV24OptionsDesc.Count);
               AV25OptionIndexes.RemoveItem(AV25OptionIndexes.Count);
            }
            if ( ! BRKC62 )
            {
               BRKC62 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV17SkipItems > 0 )
         {
            AV22Options.RemoveItem(1);
            AV24OptionsDesc.RemoveItem(1);
            AV25OptionIndexes.RemoveItem(1);
            AV17SkipItems = (short)(AV17SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADSECROLEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFSecRoleDescription = AV16SearchTxt;
         AV15TFSecRoleDescription_Sel = "";
         AV60Wpperfilusuariods_1_secroleid = AV53SecRoleId;
         AV61Wpperfilusuariods_2_filterfulltext = AV38FilterFullText;
         AV62Wpperfilusuariods_3_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV63Wpperfilusuariods_4_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV64Wpperfilusuariods_5_secuserroleactive1 = AV55SecUserRoleActive1;
         AV65Wpperfilusuariods_6_secusername1 = AV41SecUserName1;
         AV66Wpperfilusuariods_7_secrolename1 = AV42SecRoleName1;
         AV67Wpperfilusuariods_8_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV68Wpperfilusuariods_9_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV69Wpperfilusuariods_10_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV70Wpperfilusuariods_11_secuserroleactive2 = AV56SecUserRoleActive2;
         AV71Wpperfilusuariods_12_secusername2 = AV46SecUserName2;
         AV72Wpperfilusuariods_13_secrolename2 = AV47SecRoleName2;
         AV73Wpperfilusuariods_14_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV74Wpperfilusuariods_15_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV75Wpperfilusuariods_16_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV76Wpperfilusuariods_17_secuserroleactive3 = AV57SecUserRoleActive3;
         AV77Wpperfilusuariods_18_secusername3 = AV51SecUserName3;
         AV78Wpperfilusuariods_19_secrolename3 = AV52SecRoleName3;
         AV79Wpperfilusuariods_20_tfsecusername = AV10TFSecUserName;
         AV80Wpperfilusuariods_21_tfsecusername_sel = AV11TFSecUserName_Sel;
         AV81Wpperfilusuariods_22_tfsecroledescription = AV14TFSecRoleDescription;
         AV82Wpperfilusuariods_23_tfsecroledescription_sel = AV15TFSecRoleDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Wpperfilusuariods_2_filterfulltext ,
                                              AV62Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                              AV64Wpperfilusuariods_5_secuserroleactive1 ,
                                              AV63Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                              AV65Wpperfilusuariods_6_secusername1 ,
                                              AV66Wpperfilusuariods_7_secrolename1 ,
                                              AV67Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                              AV68Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                              AV70Wpperfilusuariods_11_secuserroleactive2 ,
                                              AV69Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                              AV71Wpperfilusuariods_12_secusername2 ,
                                              AV72Wpperfilusuariods_13_secrolename2 ,
                                              AV73Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                              AV74Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                              AV76Wpperfilusuariods_17_secuserroleactive3 ,
                                              AV75Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                              AV77Wpperfilusuariods_18_secusername3 ,
                                              AV78Wpperfilusuariods_19_secrolename3 ,
                                              AV80Wpperfilusuariods_21_tfsecusername_sel ,
                                              AV79Wpperfilusuariods_20_tfsecusername ,
                                              AV82Wpperfilusuariods_23_tfsecroledescription_sel ,
                                              AV81Wpperfilusuariods_22_tfsecroledescription ,
                                              A141SecUserName ,
                                              A139SecRoleDescription ,
                                              A647SecUserRoleActive ,
                                              A140SecRoleName ,
                                              AV60Wpperfilusuariods_1_secroleid ,
                                              A131SecRoleId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV61Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpperfilusuariods_2_filterfulltext), "%", "");
         lV61Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpperfilusuariods_2_filterfulltext), "%", "");
         lV65Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1), "%", "");
         lV65Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1), "%", "");
         lV66Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1), "%", "");
         lV66Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1), "%", "");
         lV71Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2), "%", "");
         lV71Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2), "%", "");
         lV72Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2), "%", "");
         lV72Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2), "%", "");
         lV77Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3), "%", "");
         lV77Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3), "%", "");
         lV78Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3), "%", "");
         lV78Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3), "%", "");
         lV79Wpperfilusuariods_20_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV79Wpperfilusuariods_20_tfsecusername), "%", "");
         lV81Wpperfilusuariods_22_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV81Wpperfilusuariods_22_tfsecroledescription), "%", "");
         /* Using cursor P00C63 */
         pr_default.execute(1, new Object[] {AV60Wpperfilusuariods_1_secroleid, lV61Wpperfilusuariods_2_filterfulltext, lV61Wpperfilusuariods_2_filterfulltext, AV64Wpperfilusuariods_5_secuserroleactive1, lV65Wpperfilusuariods_6_secusername1, lV65Wpperfilusuariods_6_secusername1, lV66Wpperfilusuariods_7_secrolename1, lV66Wpperfilusuariods_7_secrolename1, AV70Wpperfilusuariods_11_secuserroleactive2, lV71Wpperfilusuariods_12_secusername2, lV71Wpperfilusuariods_12_secusername2, lV72Wpperfilusuariods_13_secrolename2, lV72Wpperfilusuariods_13_secrolename2, AV76Wpperfilusuariods_17_secuserroleactive3, lV77Wpperfilusuariods_18_secusername3, lV77Wpperfilusuariods_18_secusername3, lV78Wpperfilusuariods_19_secrolename3, lV78Wpperfilusuariods_19_secrolename3, lV79Wpperfilusuariods_20_tfsecusername, AV80Wpperfilusuariods_21_tfsecusername_sel, lV81Wpperfilusuariods_22_tfsecroledescription, AV82Wpperfilusuariods_23_tfsecroledescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKC64 = false;
            A133SecUserId = P00C63_A133SecUserId[0];
            A131SecRoleId = P00C63_A131SecRoleId[0];
            A139SecRoleDescription = P00C63_A139SecRoleDescription[0];
            A140SecRoleName = P00C63_A140SecRoleName[0];
            A647SecUserRoleActive = P00C63_A647SecUserRoleActive[0];
            A141SecUserName = P00C63_A141SecUserName[0];
            n141SecUserName = P00C63_n141SecUserName[0];
            A141SecUserName = P00C63_A141SecUserName[0];
            n141SecUserName = P00C63_n141SecUserName[0];
            A139SecRoleDescription = P00C63_A139SecRoleDescription[0];
            A140SecRoleName = P00C63_A140SecRoleName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00C63_A131SecRoleId[0] == A131SecRoleId ) && ( StringUtil.StrCmp(P00C63_A139SecRoleDescription[0], A139SecRoleDescription) == 0 ) )
            {
               BRKC64 = false;
               A133SecUserId = P00C63_A133SecUserId[0];
               AV26count = (long)(AV26count+1);
               BRKC64 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A139SecRoleDescription)) ? "<#Empty#>" : A139SecRoleDescription);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRKC64 )
            {
               BRKC64 = true;
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
         AV10TFSecUserName = "";
         AV11TFSecUserName_Sel = "";
         AV14TFSecRoleDescription = "";
         AV15TFSecRoleDescription_Sel = "";
         AV54SecRoleName = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39DynamicFiltersSelector1 = "";
         AV41SecUserName1 = "";
         AV42SecRoleName1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46SecUserName2 = "";
         AV47SecRoleName2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51SecUserName3 = "";
         AV52SecRoleName3 = "";
         AV61Wpperfilusuariods_2_filterfulltext = "";
         AV62Wpperfilusuariods_3_dynamicfiltersselector1 = "";
         AV65Wpperfilusuariods_6_secusername1 = "";
         AV66Wpperfilusuariods_7_secrolename1 = "";
         AV68Wpperfilusuariods_9_dynamicfiltersselector2 = "";
         AV71Wpperfilusuariods_12_secusername2 = "";
         AV72Wpperfilusuariods_13_secrolename2 = "";
         AV74Wpperfilusuariods_15_dynamicfiltersselector3 = "";
         AV77Wpperfilusuariods_18_secusername3 = "";
         AV78Wpperfilusuariods_19_secrolename3 = "";
         AV79Wpperfilusuariods_20_tfsecusername = "";
         AV80Wpperfilusuariods_21_tfsecusername_sel = "";
         AV81Wpperfilusuariods_22_tfsecroledescription = "";
         AV82Wpperfilusuariods_23_tfsecroledescription_sel = "";
         lV61Wpperfilusuariods_2_filterfulltext = "";
         lV65Wpperfilusuariods_6_secusername1 = "";
         lV66Wpperfilusuariods_7_secrolename1 = "";
         lV71Wpperfilusuariods_12_secusername2 = "";
         lV72Wpperfilusuariods_13_secrolename2 = "";
         lV77Wpperfilusuariods_18_secusername3 = "";
         lV78Wpperfilusuariods_19_secrolename3 = "";
         lV79Wpperfilusuariods_20_tfsecusername = "";
         lV81Wpperfilusuariods_22_tfsecroledescription = "";
         A141SecUserName = "";
         A139SecRoleDescription = "";
         A140SecRoleName = "";
         P00C62_A131SecRoleId = new short[1] ;
         P00C62_A133SecUserId = new short[1] ;
         P00C62_A140SecRoleName = new string[] {""} ;
         P00C62_A647SecUserRoleActive = new bool[] {false} ;
         P00C62_A139SecRoleDescription = new string[] {""} ;
         P00C62_A141SecUserName = new string[] {""} ;
         P00C62_n141SecUserName = new bool[] {false} ;
         AV21Option = "";
         AV23OptionDesc = "";
         P00C63_A133SecUserId = new short[1] ;
         P00C63_A131SecRoleId = new short[1] ;
         P00C63_A139SecRoleDescription = new string[] {""} ;
         P00C63_A140SecRoleName = new string[] {""} ;
         P00C63_A647SecUserRoleActive = new bool[] {false} ;
         P00C63_A141SecUserName = new string[] {""} ;
         P00C63_n141SecUserName = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpperfilusuariogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C62_A131SecRoleId, P00C62_A133SecUserId, P00C62_A140SecRoleName, P00C62_A647SecUserRoleActive, P00C62_A139SecRoleDescription, P00C62_A141SecUserName, P00C62_n141SecUserName
               }
               , new Object[] {
               P00C63_A133SecUserId, P00C63_A131SecRoleId, P00C63_A139SecRoleDescription, P00C63_A140SecRoleName, P00C63_A647SecUserRoleActive, P00C63_A141SecUserName, P00C63_n141SecUserName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV53SecRoleId ;
      private short AV40DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV60Wpperfilusuariods_1_secroleid ;
      private short AV63Wpperfilusuariods_4_dynamicfiltersoperator1 ;
      private short AV69Wpperfilusuariods_10_dynamicfiltersoperator2 ;
      private short AV75Wpperfilusuariods_16_dynamicfiltersoperator3 ;
      private short A131SecRoleId ;
      private short A133SecUserId ;
      private int AV58GXV1 ;
      private int AV20InsertIndex ;
      private long AV26count ;
      private bool returnInSub ;
      private bool AV55SecUserRoleActive1 ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV56SecUserRoleActive2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV57SecUserRoleActive3 ;
      private bool AV64Wpperfilusuariods_5_secuserroleactive1 ;
      private bool AV67Wpperfilusuariods_8_dynamicfiltersenabled2 ;
      private bool AV70Wpperfilusuariods_11_secuserroleactive2 ;
      private bool AV73Wpperfilusuariods_14_dynamicfiltersenabled3 ;
      private bool AV76Wpperfilusuariods_17_secuserroleactive3 ;
      private bool A647SecUserRoleActive ;
      private bool BRKC62 ;
      private bool n141SecUserName ;
      private bool BRKC64 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV10TFSecUserName ;
      private string AV11TFSecUserName_Sel ;
      private string AV14TFSecRoleDescription ;
      private string AV15TFSecRoleDescription_Sel ;
      private string AV54SecRoleName ;
      private string AV39DynamicFiltersSelector1 ;
      private string AV41SecUserName1 ;
      private string AV42SecRoleName1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV46SecUserName2 ;
      private string AV47SecRoleName2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV51SecUserName3 ;
      private string AV52SecRoleName3 ;
      private string AV61Wpperfilusuariods_2_filterfulltext ;
      private string AV62Wpperfilusuariods_3_dynamicfiltersselector1 ;
      private string AV65Wpperfilusuariods_6_secusername1 ;
      private string AV66Wpperfilusuariods_7_secrolename1 ;
      private string AV68Wpperfilusuariods_9_dynamicfiltersselector2 ;
      private string AV71Wpperfilusuariods_12_secusername2 ;
      private string AV72Wpperfilusuariods_13_secrolename2 ;
      private string AV74Wpperfilusuariods_15_dynamicfiltersselector3 ;
      private string AV77Wpperfilusuariods_18_secusername3 ;
      private string AV78Wpperfilusuariods_19_secrolename3 ;
      private string AV79Wpperfilusuariods_20_tfsecusername ;
      private string AV80Wpperfilusuariods_21_tfsecusername_sel ;
      private string AV81Wpperfilusuariods_22_tfsecroledescription ;
      private string AV82Wpperfilusuariods_23_tfsecroledescription_sel ;
      private string lV61Wpperfilusuariods_2_filterfulltext ;
      private string lV65Wpperfilusuariods_6_secusername1 ;
      private string lV66Wpperfilusuariods_7_secrolename1 ;
      private string lV71Wpperfilusuariods_12_secusername2 ;
      private string lV72Wpperfilusuariods_13_secrolename2 ;
      private string lV77Wpperfilusuariods_18_secusername3 ;
      private string lV78Wpperfilusuariods_19_secrolename3 ;
      private string lV79Wpperfilusuariods_20_tfsecusername ;
      private string lV81Wpperfilusuariods_22_tfsecroledescription ;
      private string A141SecUserName ;
      private string A139SecRoleDescription ;
      private string A140SecRoleName ;
      private string AV21Option ;
      private string AV23OptionDesc ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00C62_A131SecRoleId ;
      private short[] P00C62_A133SecUserId ;
      private string[] P00C62_A140SecRoleName ;
      private bool[] P00C62_A647SecUserRoleActive ;
      private string[] P00C62_A139SecRoleDescription ;
      private string[] P00C62_A141SecUserName ;
      private bool[] P00C62_n141SecUserName ;
      private short[] P00C63_A133SecUserId ;
      private short[] P00C63_A131SecRoleId ;
      private string[] P00C63_A139SecRoleDescription ;
      private string[] P00C63_A140SecRoleName ;
      private bool[] P00C63_A647SecUserRoleActive ;
      private string[] P00C63_A141SecUserName ;
      private bool[] P00C63_n141SecUserName ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpperfilusuariogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C62( IGxContext context ,
                                             string AV61Wpperfilusuariods_2_filterfulltext ,
                                             string AV62Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                             bool AV64Wpperfilusuariods_5_secuserroleactive1 ,
                                             short AV63Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                             string AV65Wpperfilusuariods_6_secusername1 ,
                                             string AV66Wpperfilusuariods_7_secrolename1 ,
                                             bool AV67Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                             string AV68Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                             bool AV70Wpperfilusuariods_11_secuserroleactive2 ,
                                             short AV69Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                             string AV71Wpperfilusuariods_12_secusername2 ,
                                             string AV72Wpperfilusuariods_13_secrolename2 ,
                                             bool AV73Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                             string AV74Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                             bool AV76Wpperfilusuariods_17_secuserroleactive3 ,
                                             short AV75Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                             string AV77Wpperfilusuariods_18_secusername3 ,
                                             string AV78Wpperfilusuariods_19_secrolename3 ,
                                             string AV80Wpperfilusuariods_21_tfsecusername_sel ,
                                             string AV79Wpperfilusuariods_20_tfsecusername ,
                                             string AV82Wpperfilusuariods_23_tfsecroledescription_sel ,
                                             string AV81Wpperfilusuariods_22_tfsecroledescription ,
                                             string A141SecUserName ,
                                             string A139SecRoleDescription ,
                                             bool A647SecUserRoleActive ,
                                             string A140SecRoleName ,
                                             short AV60Wpperfilusuariods_1_secroleid ,
                                             short A131SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[22];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecRoleId, T1.SecUserId, T2.SecRoleName, T1.SecUserRoleActive, T2.SecRoleDescription, T3.SecUserName FROM ((SecUserRole T1 INNER JOIN SecRole T2 ON T2.SecRoleId = T1.SecRoleId) INNER JOIN SecUser T3 ON T3.SecUserId = T1.SecUserId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV60Wpperfilusuariods_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpperfilusuariods_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.SecUserName like '%' || :lV61Wpperfilusuariods_2_filterfulltext) or ( T2.SecRoleDescription like '%' || :lV61Wpperfilusuariods_2_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV64Wpperfilusuariods_5_secuserroleactive1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV64Wpperfilusuariods_5_secuserroleactive1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV65Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV65Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV66Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like '%' || :lV66Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV70Wpperfilusuariods_11_secuserroleactive2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV70Wpperfilusuariods_11_secuserroleactive2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV71Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV71Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV72Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like '%' || :lV72Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV76Wpperfilusuariods_17_secuserroleactive3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV76Wpperfilusuariods_17_secuserroleactive3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV77Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV77Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV78Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like '%' || :lV78Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_21_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpperfilusuariods_20_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV79Wpperfilusuariods_20_tfsecusername)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_21_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV80Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV80Wpperfilusuariods_21_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpperfilusuariods_23_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpperfilusuariods_22_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription like :lV81Wpperfilusuariods_22_tfsecroledescription)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpperfilusuariods_23_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV82Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription = ( :AV82Wpperfilusuariods_23_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV82Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecRoleId, T1.SecUserId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00C63( IGxContext context ,
                                             string AV61Wpperfilusuariods_2_filterfulltext ,
                                             string AV62Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                             bool AV64Wpperfilusuariods_5_secuserroleactive1 ,
                                             short AV63Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                             string AV65Wpperfilusuariods_6_secusername1 ,
                                             string AV66Wpperfilusuariods_7_secrolename1 ,
                                             bool AV67Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                             string AV68Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                             bool AV70Wpperfilusuariods_11_secuserroleactive2 ,
                                             short AV69Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                             string AV71Wpperfilusuariods_12_secusername2 ,
                                             string AV72Wpperfilusuariods_13_secrolename2 ,
                                             bool AV73Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                             string AV74Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                             bool AV76Wpperfilusuariods_17_secuserroleactive3 ,
                                             short AV75Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                             string AV77Wpperfilusuariods_18_secusername3 ,
                                             string AV78Wpperfilusuariods_19_secrolename3 ,
                                             string AV80Wpperfilusuariods_21_tfsecusername_sel ,
                                             string AV79Wpperfilusuariods_20_tfsecusername ,
                                             string AV82Wpperfilusuariods_23_tfsecroledescription_sel ,
                                             string AV81Wpperfilusuariods_22_tfsecroledescription ,
                                             string A141SecUserName ,
                                             string A139SecRoleDescription ,
                                             bool A647SecUserRoleActive ,
                                             string A140SecRoleName ,
                                             short AV60Wpperfilusuariods_1_secroleid ,
                                             short A131SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[22];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T1.SecRoleId, T3.SecRoleDescription, T3.SecRoleName, T1.SecUserRoleActive, T2.SecUserName FROM ((SecUserRole T1 INNER JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId) INNER JOIN SecRole T3 ON T3.SecRoleId = T1.SecRoleId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV60Wpperfilusuariods_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpperfilusuariods_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV61Wpperfilusuariods_2_filterfulltext) or ( T3.SecRoleDescription like '%' || :lV61Wpperfilusuariods_2_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV64Wpperfilusuariods_5_secuserroleactive1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV64Wpperfilusuariods_5_secuserroleactive1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV65Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV65Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like :lV66Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV63Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like '%' || :lV66Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV70Wpperfilusuariods_11_secuserroleactive2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV70Wpperfilusuariods_11_secuserroleactive2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV71Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like :lV72Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV69Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like '%' || :lV72Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV76Wpperfilusuariods_17_secuserroleactive3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV76Wpperfilusuariods_17_secuserroleactive3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV77Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV77Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like :lV78Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV73Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV75Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like '%' || :lV78Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_21_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpperfilusuariods_20_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV79Wpperfilusuariods_20_tfsecusername)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_21_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV80Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV80Wpperfilusuariods_21_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpperfilusuariods_23_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpperfilusuariods_22_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleDescription like :lV81Wpperfilusuariods_22_tfsecroledescription)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpperfilusuariods_23_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV82Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleDescription = ( :AV82Wpperfilusuariods_23_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV82Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecRoleId, T3.SecRoleDescription";
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
                     return conditional_P00C62(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
               case 1 :
                     return conditional_P00C63(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] );
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
          Object[] prmP00C62;
          prmP00C62 = new Object[] {
          new ParDef("AV60Wpperfilusuariods_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV61Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Wpperfilusuariods_5_secuserroleactive1",GXType.Boolean,4,0) ,
          new ParDef("lV65Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV66Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("AV70Wpperfilusuariods_11_secuserroleactive2",GXType.Boolean,4,0) ,
          new ParDef("lV71Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV72Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("AV76Wpperfilusuariods_17_secuserroleactive3",GXType.Boolean,4,0) ,
          new ParDef("lV77Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV77Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV78Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV79Wpperfilusuariods_20_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV80Wpperfilusuariods_21_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Wpperfilusuariods_22_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV82Wpperfilusuariods_23_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          Object[] prmP00C63;
          prmP00C63 = new Object[] {
          new ParDef("AV60Wpperfilusuariods_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV61Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Wpperfilusuariods_5_secuserroleactive1",GXType.Boolean,4,0) ,
          new ParDef("lV65Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV66Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("AV70Wpperfilusuariods_11_secuserroleactive2",GXType.Boolean,4,0) ,
          new ParDef("lV71Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV72Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("AV76Wpperfilusuariods_17_secuserroleactive3",GXType.Boolean,4,0) ,
          new ParDef("lV77Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV77Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV78Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV79Wpperfilusuariods_20_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV80Wpperfilusuariods_21_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Wpperfilusuariods_22_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV82Wpperfilusuariods_23_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C63,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
