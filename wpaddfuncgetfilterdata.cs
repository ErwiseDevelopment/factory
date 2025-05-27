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
   public class wpaddfuncgetfilterdata : GXProcedure
   {
      public wpaddfuncgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpaddfuncgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_SECFUNCTIONALITYMODULE") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYMODULEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("WPAddFuncGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WPAddFuncGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("WPAddFuncGridState"), null, "", "");
         }
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV14TFSecFunctionalityDescription = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV15TFSecFunctionalityDescription_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE") == 0 )
            {
               AV62TFSecFunctionalityModule = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE_SEL") == 0 )
            {
               AV63TFSecFunctionalityModule_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYACTIVE_SEL") == 0 )
            {
               AV22TFSecFunctionalityActive_Sel = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&SECROLEID") == 0 )
            {
               AV61SecRoleId = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV38GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV48SecFunctionalityDescription1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV49SecParentFunctionalityDescription1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV50DynamicFiltersEnabled2 = true;
               AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV38GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV53SecFunctionalityDescription2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV54SecParentFunctionalityDescription2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV55DynamicFiltersEnabled3 = true;
                  AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV38GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV58SecFunctionalityDescription3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV59SecParentFunctionalityDescription3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFSecFunctionalityDescription = AV23SearchTxt;
         AV15TFSecFunctionalityDescription_Sel = "";
         AV66Wpaddfuncds_1_filterfulltext = AV45FilterFullText;
         AV67Wpaddfuncds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV68Wpaddfuncds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV69Wpaddfuncds_4_secfunctionalitydescription1 = AV48SecFunctionalityDescription1;
         AV70Wpaddfuncds_5_secparentfunctionalitydescription1 = AV49SecParentFunctionalityDescription1;
         AV71Wpaddfuncds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV72Wpaddfuncds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV73Wpaddfuncds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV74Wpaddfuncds_9_secfunctionalitydescription2 = AV53SecFunctionalityDescription2;
         AV75Wpaddfuncds_10_secparentfunctionalitydescription2 = AV54SecParentFunctionalityDescription2;
         AV76Wpaddfuncds_11_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV77Wpaddfuncds_12_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV78Wpaddfuncds_13_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV79Wpaddfuncds_14_secfunctionalitydescription3 = AV58SecFunctionalityDescription3;
         AV80Wpaddfuncds_15_secparentfunctionalitydescription3 = AV59SecParentFunctionalityDescription3;
         AV81Wpaddfuncds_16_tfsecfunctionalitydescription = AV14TFSecFunctionalityDescription;
         AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV15TFSecFunctionalityDescription_Sel;
         AV83Wpaddfuncds_18_tfsecfunctionalitymodule = AV62TFSecFunctionalityModule;
         AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV63TFSecFunctionalityModule_Sel;
         AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV22TFSecFunctionalityActive_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Wpaddfuncds_1_filterfulltext ,
                                              AV67Wpaddfuncds_2_dynamicfiltersselector1 ,
                                              AV68Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                              AV69Wpaddfuncds_4_secfunctionalitydescription1 ,
                                              AV70Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                              AV71Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                              AV72Wpaddfuncds_7_dynamicfiltersselector2 ,
                                              AV73Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                              AV74Wpaddfuncds_9_secfunctionalitydescription2 ,
                                              AV75Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                              AV76Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                              AV77Wpaddfuncds_12_dynamicfiltersselector3 ,
                                              AV78Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                              AV79Wpaddfuncds_14_secfunctionalitydescription3 ,
                                              AV80Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                              AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                              AV81Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                              AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                              AV83Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                              AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                              A135SecFunctionalityDescription ,
                                              A789SecFunctionalityModule ,
                                              A138SecParentFunctionalityDescription ,
                                              A134SecFunctionalityActive ,
                                              A40000SecFunctionalityRoleAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Wpaddfuncds_1_filterfulltext), "%", "");
         lV66Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Wpaddfuncds_1_filterfulltext), "%", "");
         lV69Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV69Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV70Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV70Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV74Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV74Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV75Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV75Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV79Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV79Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV80Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV80Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV81Wpaddfuncds_16_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV81Wpaddfuncds_16_tfsecfunctionalitydescription), "%", "");
         lV83Wpaddfuncds_18_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_18_tfsecfunctionalitymodule), "%", "");
         /* Using cursor P00CN3 */
         pr_default.execute(0, new Object[] {AV61SecRoleId, lV66Wpaddfuncds_1_filterfulltext, lV66Wpaddfuncds_1_filterfulltext, lV69Wpaddfuncds_4_secfunctionalitydescription1, lV69Wpaddfuncds_4_secfunctionalitydescription1, lV70Wpaddfuncds_5_secparentfunctionalitydescription1, lV70Wpaddfuncds_5_secparentfunctionalitydescription1, lV74Wpaddfuncds_9_secfunctionalitydescription2, lV74Wpaddfuncds_9_secfunctionalitydescription2, lV75Wpaddfuncds_10_secparentfunctionalitydescription2, lV75Wpaddfuncds_10_secparentfunctionalitydescription2, lV79Wpaddfuncds_14_secfunctionalitydescription3, lV79Wpaddfuncds_14_secfunctionalitydescription3, lV80Wpaddfuncds_15_secparentfunctionalitydescription3, lV80Wpaddfuncds_15_secparentfunctionalitydescription3, lV81Wpaddfuncds_16_tfsecfunctionalitydescription, AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel, lV83Wpaddfuncds_18_tfsecfunctionalitymodule, AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCN2 = false;
            A129SecParentFunctionalityId = P00CN3_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P00CN3_n129SecParentFunctionalityId[0];
            A128SecFunctionalityId = P00CN3_A128SecFunctionalityId[0];
            A135SecFunctionalityDescription = P00CN3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00CN3_n135SecFunctionalityDescription[0];
            A134SecFunctionalityActive = P00CN3_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = P00CN3_n134SecFunctionalityActive[0];
            A138SecParentFunctionalityDescription = P00CN3_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00CN3_n138SecParentFunctionalityDescription[0];
            A789SecFunctionalityModule = P00CN3_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = P00CN3_n789SecFunctionalityModule[0];
            A40000SecFunctionalityRoleAtivo = P00CN3_A40000SecFunctionalityRoleAtivo[0];
            n40000SecFunctionalityRoleAtivo = P00CN3_n40000SecFunctionalityRoleAtivo[0];
            A138SecParentFunctionalityDescription = P00CN3_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00CN3_n138SecParentFunctionalityDescription[0];
            A40000SecFunctionalityRoleAtivo = P00CN3_A40000SecFunctionalityRoleAtivo[0];
            n40000SecFunctionalityRoleAtivo = P00CN3_n40000SecFunctionalityRoleAtivo[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CN3_A135SecFunctionalityDescription[0], A135SecFunctionalityDescription) == 0 ) )
            {
               BRKCN2 = false;
               A128SecFunctionalityId = P00CN3_A128SecFunctionalityId[0];
               AV33count = (long)(AV33count+1);
               BRKCN2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A135SecFunctionalityDescription)) ? "<#Empty#>" : A135SecFunctionalityDescription);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRKCN2 )
            {
               BRKCN2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECFUNCTIONALITYMODULEOPTIONS' Routine */
         returnInSub = false;
         AV62TFSecFunctionalityModule = AV23SearchTxt;
         AV63TFSecFunctionalityModule_Sel = "";
         AV66Wpaddfuncds_1_filterfulltext = AV45FilterFullText;
         AV67Wpaddfuncds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV68Wpaddfuncds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV69Wpaddfuncds_4_secfunctionalitydescription1 = AV48SecFunctionalityDescription1;
         AV70Wpaddfuncds_5_secparentfunctionalitydescription1 = AV49SecParentFunctionalityDescription1;
         AV71Wpaddfuncds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV72Wpaddfuncds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV73Wpaddfuncds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV74Wpaddfuncds_9_secfunctionalitydescription2 = AV53SecFunctionalityDescription2;
         AV75Wpaddfuncds_10_secparentfunctionalitydescription2 = AV54SecParentFunctionalityDescription2;
         AV76Wpaddfuncds_11_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV77Wpaddfuncds_12_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV78Wpaddfuncds_13_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV79Wpaddfuncds_14_secfunctionalitydescription3 = AV58SecFunctionalityDescription3;
         AV80Wpaddfuncds_15_secparentfunctionalitydescription3 = AV59SecParentFunctionalityDescription3;
         AV81Wpaddfuncds_16_tfsecfunctionalitydescription = AV14TFSecFunctionalityDescription;
         AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV15TFSecFunctionalityDescription_Sel;
         AV83Wpaddfuncds_18_tfsecfunctionalitymodule = AV62TFSecFunctionalityModule;
         AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV63TFSecFunctionalityModule_Sel;
         AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV22TFSecFunctionalityActive_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV66Wpaddfuncds_1_filterfulltext ,
                                              AV67Wpaddfuncds_2_dynamicfiltersselector1 ,
                                              AV68Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                              AV69Wpaddfuncds_4_secfunctionalitydescription1 ,
                                              AV70Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                              AV71Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                              AV72Wpaddfuncds_7_dynamicfiltersselector2 ,
                                              AV73Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                              AV74Wpaddfuncds_9_secfunctionalitydescription2 ,
                                              AV75Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                              AV76Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                              AV77Wpaddfuncds_12_dynamicfiltersselector3 ,
                                              AV78Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                              AV79Wpaddfuncds_14_secfunctionalitydescription3 ,
                                              AV80Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                              AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                              AV81Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                              AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                              AV83Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                              AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                              A135SecFunctionalityDescription ,
                                              A789SecFunctionalityModule ,
                                              A138SecParentFunctionalityDescription ,
                                              A134SecFunctionalityActive ,
                                              A40000SecFunctionalityRoleAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Wpaddfuncds_1_filterfulltext), "%", "");
         lV66Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Wpaddfuncds_1_filterfulltext), "%", "");
         lV69Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV69Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV70Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV70Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV74Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV74Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV75Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV75Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV79Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV79Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV80Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV80Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV81Wpaddfuncds_16_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV81Wpaddfuncds_16_tfsecfunctionalitydescription), "%", "");
         lV83Wpaddfuncds_18_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_18_tfsecfunctionalitymodule), "%", "");
         /* Using cursor P00CN5 */
         pr_default.execute(1, new Object[] {AV61SecRoleId, lV66Wpaddfuncds_1_filterfulltext, lV66Wpaddfuncds_1_filterfulltext, lV69Wpaddfuncds_4_secfunctionalitydescription1, lV69Wpaddfuncds_4_secfunctionalitydescription1, lV70Wpaddfuncds_5_secparentfunctionalitydescription1, lV70Wpaddfuncds_5_secparentfunctionalitydescription1, lV74Wpaddfuncds_9_secfunctionalitydescription2, lV74Wpaddfuncds_9_secfunctionalitydescription2, lV75Wpaddfuncds_10_secparentfunctionalitydescription2, lV75Wpaddfuncds_10_secparentfunctionalitydescription2, lV79Wpaddfuncds_14_secfunctionalitydescription3, lV79Wpaddfuncds_14_secfunctionalitydescription3, lV80Wpaddfuncds_15_secparentfunctionalitydescription3, lV80Wpaddfuncds_15_secparentfunctionalitydescription3, lV81Wpaddfuncds_16_tfsecfunctionalitydescription, AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel, lV83Wpaddfuncds_18_tfsecfunctionalitymodule, AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCN4 = false;
            A129SecParentFunctionalityId = P00CN5_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P00CN5_n129SecParentFunctionalityId[0];
            A128SecFunctionalityId = P00CN5_A128SecFunctionalityId[0];
            A789SecFunctionalityModule = P00CN5_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = P00CN5_n789SecFunctionalityModule[0];
            A134SecFunctionalityActive = P00CN5_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = P00CN5_n134SecFunctionalityActive[0];
            A138SecParentFunctionalityDescription = P00CN5_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00CN5_n138SecParentFunctionalityDescription[0];
            A135SecFunctionalityDescription = P00CN5_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00CN5_n135SecFunctionalityDescription[0];
            A40000SecFunctionalityRoleAtivo = P00CN5_A40000SecFunctionalityRoleAtivo[0];
            n40000SecFunctionalityRoleAtivo = P00CN5_n40000SecFunctionalityRoleAtivo[0];
            A138SecParentFunctionalityDescription = P00CN5_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00CN5_n138SecParentFunctionalityDescription[0];
            A40000SecFunctionalityRoleAtivo = P00CN5_A40000SecFunctionalityRoleAtivo[0];
            n40000SecFunctionalityRoleAtivo = P00CN5_n40000SecFunctionalityRoleAtivo[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CN5_A789SecFunctionalityModule[0], A789SecFunctionalityModule) == 0 ) )
            {
               BRKCN4 = false;
               A128SecFunctionalityId = P00CN5_A128SecFunctionalityId[0];
               AV33count = (long)(AV33count+1);
               BRKCN4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A789SecFunctionalityModule)) ? "<#Empty#>" : A789SecFunctionalityModule);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRKCN4 )
            {
               BRKCN4 = true;
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV14TFSecFunctionalityDescription = "";
         AV15TFSecFunctionalityDescription_Sel = "";
         AV62TFSecFunctionalityModule = "";
         AV63TFSecFunctionalityModule_Sel = "";
         AV38GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV46DynamicFiltersSelector1 = "";
         AV48SecFunctionalityDescription1 = "";
         AV49SecParentFunctionalityDescription1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV53SecFunctionalityDescription2 = "";
         AV54SecParentFunctionalityDescription2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV58SecFunctionalityDescription3 = "";
         AV59SecParentFunctionalityDescription3 = "";
         AV66Wpaddfuncds_1_filterfulltext = "";
         AV67Wpaddfuncds_2_dynamicfiltersselector1 = "";
         AV69Wpaddfuncds_4_secfunctionalitydescription1 = "";
         AV70Wpaddfuncds_5_secparentfunctionalitydescription1 = "";
         AV72Wpaddfuncds_7_dynamicfiltersselector2 = "";
         AV74Wpaddfuncds_9_secfunctionalitydescription2 = "";
         AV75Wpaddfuncds_10_secparentfunctionalitydescription2 = "";
         AV77Wpaddfuncds_12_dynamicfiltersselector3 = "";
         AV79Wpaddfuncds_14_secfunctionalitydescription3 = "";
         AV80Wpaddfuncds_15_secparentfunctionalitydescription3 = "";
         AV81Wpaddfuncds_16_tfsecfunctionalitydescription = "";
         AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel = "";
         AV83Wpaddfuncds_18_tfsecfunctionalitymodule = "";
         AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel = "";
         lV66Wpaddfuncds_1_filterfulltext = "";
         lV69Wpaddfuncds_4_secfunctionalitydescription1 = "";
         lV70Wpaddfuncds_5_secparentfunctionalitydescription1 = "";
         lV74Wpaddfuncds_9_secfunctionalitydescription2 = "";
         lV75Wpaddfuncds_10_secparentfunctionalitydescription2 = "";
         lV79Wpaddfuncds_14_secfunctionalitydescription3 = "";
         lV80Wpaddfuncds_15_secparentfunctionalitydescription3 = "";
         lV81Wpaddfuncds_16_tfsecfunctionalitydescription = "";
         lV83Wpaddfuncds_18_tfsecfunctionalitymodule = "";
         A135SecFunctionalityDescription = "";
         A789SecFunctionalityModule = "";
         A138SecParentFunctionalityDescription = "";
         P00CN3_A129SecParentFunctionalityId = new long[1] ;
         P00CN3_n129SecParentFunctionalityId = new bool[] {false} ;
         P00CN3_A128SecFunctionalityId = new long[1] ;
         P00CN3_A135SecFunctionalityDescription = new string[] {""} ;
         P00CN3_n135SecFunctionalityDescription = new bool[] {false} ;
         P00CN3_A134SecFunctionalityActive = new bool[] {false} ;
         P00CN3_n134SecFunctionalityActive = new bool[] {false} ;
         P00CN3_A138SecParentFunctionalityDescription = new string[] {""} ;
         P00CN3_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P00CN3_A789SecFunctionalityModule = new string[] {""} ;
         P00CN3_n789SecFunctionalityModule = new bool[] {false} ;
         P00CN3_A40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         P00CN3_n40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         AV28Option = "";
         P00CN5_A129SecParentFunctionalityId = new long[1] ;
         P00CN5_n129SecParentFunctionalityId = new bool[] {false} ;
         P00CN5_A128SecFunctionalityId = new long[1] ;
         P00CN5_A789SecFunctionalityModule = new string[] {""} ;
         P00CN5_n789SecFunctionalityModule = new bool[] {false} ;
         P00CN5_A134SecFunctionalityActive = new bool[] {false} ;
         P00CN5_n134SecFunctionalityActive = new bool[] {false} ;
         P00CN5_A138SecParentFunctionalityDescription = new string[] {""} ;
         P00CN5_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P00CN5_A135SecFunctionalityDescription = new string[] {""} ;
         P00CN5_n135SecFunctionalityDescription = new bool[] {false} ;
         P00CN5_A40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         P00CN5_n40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpaddfuncgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CN3_A129SecParentFunctionalityId, P00CN3_n129SecParentFunctionalityId, P00CN3_A128SecFunctionalityId, P00CN3_A135SecFunctionalityDescription, P00CN3_n135SecFunctionalityDescription, P00CN3_A134SecFunctionalityActive, P00CN3_n134SecFunctionalityActive, P00CN3_A138SecParentFunctionalityDescription, P00CN3_n138SecParentFunctionalityDescription, P00CN3_A789SecFunctionalityModule,
               P00CN3_n789SecFunctionalityModule, P00CN3_A40000SecFunctionalityRoleAtivo, P00CN3_n40000SecFunctionalityRoleAtivo
               }
               , new Object[] {
               P00CN5_A129SecParentFunctionalityId, P00CN5_n129SecParentFunctionalityId, P00CN5_A128SecFunctionalityId, P00CN5_A789SecFunctionalityModule, P00CN5_n789SecFunctionalityModule, P00CN5_A134SecFunctionalityActive, P00CN5_n134SecFunctionalityActive, P00CN5_A138SecParentFunctionalityDescription, P00CN5_n138SecParentFunctionalityDescription, P00CN5_A135SecFunctionalityDescription,
               P00CN5_n135SecFunctionalityDescription, P00CN5_A40000SecFunctionalityRoleAtivo, P00CN5_n40000SecFunctionalityRoleAtivo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV22TFSecFunctionalityActive_Sel ;
      private short AV61SecRoleId ;
      private short AV47DynamicFiltersOperator1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV68Wpaddfuncds_3_dynamicfiltersoperator1 ;
      private short AV73Wpaddfuncds_8_dynamicfiltersoperator2 ;
      private short AV78Wpaddfuncds_13_dynamicfiltersoperator3 ;
      private short AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel ;
      private int AV64GXV1 ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long AV33count ;
      private bool returnInSub ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV71Wpaddfuncds_6_dynamicfiltersenabled2 ;
      private bool AV76Wpaddfuncds_11_dynamicfiltersenabled3 ;
      private bool A134SecFunctionalityActive ;
      private bool A40000SecFunctionalityRoleAtivo ;
      private bool BRKCN2 ;
      private bool n129SecParentFunctionalityId ;
      private bool n135SecFunctionalityDescription ;
      private bool n134SecFunctionalityActive ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n789SecFunctionalityModule ;
      private bool n40000SecFunctionalityRoleAtivo ;
      private bool BRKCN4 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV14TFSecFunctionalityDescription ;
      private string AV15TFSecFunctionalityDescription_Sel ;
      private string AV62TFSecFunctionalityModule ;
      private string AV63TFSecFunctionalityModule_Sel ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV48SecFunctionalityDescription1 ;
      private string AV49SecParentFunctionalityDescription1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV53SecFunctionalityDescription2 ;
      private string AV54SecParentFunctionalityDescription2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV58SecFunctionalityDescription3 ;
      private string AV59SecParentFunctionalityDescription3 ;
      private string AV66Wpaddfuncds_1_filterfulltext ;
      private string AV67Wpaddfuncds_2_dynamicfiltersselector1 ;
      private string AV69Wpaddfuncds_4_secfunctionalitydescription1 ;
      private string AV70Wpaddfuncds_5_secparentfunctionalitydescription1 ;
      private string AV72Wpaddfuncds_7_dynamicfiltersselector2 ;
      private string AV74Wpaddfuncds_9_secfunctionalitydescription2 ;
      private string AV75Wpaddfuncds_10_secparentfunctionalitydescription2 ;
      private string AV77Wpaddfuncds_12_dynamicfiltersselector3 ;
      private string AV79Wpaddfuncds_14_secfunctionalitydescription3 ;
      private string AV80Wpaddfuncds_15_secparentfunctionalitydescription3 ;
      private string AV81Wpaddfuncds_16_tfsecfunctionalitydescription ;
      private string AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel ;
      private string AV83Wpaddfuncds_18_tfsecfunctionalitymodule ;
      private string AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel ;
      private string lV66Wpaddfuncds_1_filterfulltext ;
      private string lV69Wpaddfuncds_4_secfunctionalitydescription1 ;
      private string lV70Wpaddfuncds_5_secparentfunctionalitydescription1 ;
      private string lV74Wpaddfuncds_9_secfunctionalitydescription2 ;
      private string lV75Wpaddfuncds_10_secparentfunctionalitydescription2 ;
      private string lV79Wpaddfuncds_14_secfunctionalitydescription3 ;
      private string lV80Wpaddfuncds_15_secparentfunctionalitydescription3 ;
      private string lV81Wpaddfuncds_16_tfsecfunctionalitydescription ;
      private string lV83Wpaddfuncds_18_tfsecfunctionalitymodule ;
      private string A135SecFunctionalityDescription ;
      private string A789SecFunctionalityModule ;
      private string A138SecParentFunctionalityDescription ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV38GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private long[] P00CN3_A129SecParentFunctionalityId ;
      private bool[] P00CN3_n129SecParentFunctionalityId ;
      private long[] P00CN3_A128SecFunctionalityId ;
      private string[] P00CN3_A135SecFunctionalityDescription ;
      private bool[] P00CN3_n135SecFunctionalityDescription ;
      private bool[] P00CN3_A134SecFunctionalityActive ;
      private bool[] P00CN3_n134SecFunctionalityActive ;
      private string[] P00CN3_A138SecParentFunctionalityDescription ;
      private bool[] P00CN3_n138SecParentFunctionalityDescription ;
      private string[] P00CN3_A789SecFunctionalityModule ;
      private bool[] P00CN3_n789SecFunctionalityModule ;
      private bool[] P00CN3_A40000SecFunctionalityRoleAtivo ;
      private bool[] P00CN3_n40000SecFunctionalityRoleAtivo ;
      private long[] P00CN5_A129SecParentFunctionalityId ;
      private bool[] P00CN5_n129SecParentFunctionalityId ;
      private long[] P00CN5_A128SecFunctionalityId ;
      private string[] P00CN5_A789SecFunctionalityModule ;
      private bool[] P00CN5_n789SecFunctionalityModule ;
      private bool[] P00CN5_A134SecFunctionalityActive ;
      private bool[] P00CN5_n134SecFunctionalityActive ;
      private string[] P00CN5_A138SecParentFunctionalityDescription ;
      private bool[] P00CN5_n138SecParentFunctionalityDescription ;
      private string[] P00CN5_A135SecFunctionalityDescription ;
      private bool[] P00CN5_n135SecFunctionalityDescription ;
      private bool[] P00CN5_A40000SecFunctionalityRoleAtivo ;
      private bool[] P00CN5_n40000SecFunctionalityRoleAtivo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpaddfuncgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CN3( IGxContext context ,
                                             string AV66Wpaddfuncds_1_filterfulltext ,
                                             string AV67Wpaddfuncds_2_dynamicfiltersselector1 ,
                                             short AV68Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                             string AV69Wpaddfuncds_4_secfunctionalitydescription1 ,
                                             string AV70Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                             bool AV71Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                             string AV72Wpaddfuncds_7_dynamicfiltersselector2 ,
                                             short AV73Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                             string AV74Wpaddfuncds_9_secfunctionalitydescription2 ,
                                             string AV75Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                             bool AV76Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                             string AV77Wpaddfuncds_12_dynamicfiltersselector3 ,
                                             short AV78Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                             string AV79Wpaddfuncds_14_secfunctionalitydescription3 ,
                                             string AV80Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                             string AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                             string AV81Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                             string AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                             string AV83Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                             short AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                             string A135SecFunctionalityDescription ,
                                             string A789SecFunctionalityModule ,
                                             string A138SecParentFunctionalityDescription ,
                                             bool A134SecFunctionalityActive ,
                                             bool A40000SecFunctionalityRoleAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[19];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityId, T1.SecFunctionalityDescription, T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityModule, COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) AS SecFunctionalityRoleAtivo FROM ((SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId) LEFT JOIN (SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecRoleId = :AV61SecRoleId ) T3 ON T3.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpaddfuncds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityDescription like '%' || :lV66Wpaddfuncds_1_filterfulltext) or ( T1.SecFunctionalityModule like '%' || :lV66Wpaddfuncds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV69Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV69Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV70Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV70Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV74Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV74Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV75Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV75Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV79Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV79Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV80Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV80Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpaddfuncds_16_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV81Wpaddfuncds_16_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_18_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule like :lV83Wpaddfuncds_18_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule = ( :AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityModule))=0))");
         }
         if ( AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = TRUE)");
         }
         if ( AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityDescription";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CN5( IGxContext context ,
                                             string AV66Wpaddfuncds_1_filterfulltext ,
                                             string AV67Wpaddfuncds_2_dynamicfiltersselector1 ,
                                             short AV68Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                             string AV69Wpaddfuncds_4_secfunctionalitydescription1 ,
                                             string AV70Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                             bool AV71Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                             string AV72Wpaddfuncds_7_dynamicfiltersselector2 ,
                                             short AV73Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                             string AV74Wpaddfuncds_9_secfunctionalitydescription2 ,
                                             string AV75Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                             bool AV76Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                             string AV77Wpaddfuncds_12_dynamicfiltersselector3 ,
                                             short AV78Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                             string AV79Wpaddfuncds_14_secfunctionalitydescription3 ,
                                             string AV80Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                             string AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                             string AV81Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                             string AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                             string AV83Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                             short AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                             string A135SecFunctionalityDescription ,
                                             string A789SecFunctionalityModule ,
                                             string A138SecParentFunctionalityDescription ,
                                             bool A134SecFunctionalityActive ,
                                             bool A40000SecFunctionalityRoleAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[19];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityId, T1.SecFunctionalityModule, T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityDescription, COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) AS SecFunctionalityRoleAtivo FROM ((SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId) LEFT JOIN (SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecRoleId = :AV61SecRoleId ) T3 ON T3.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpaddfuncds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityDescription like '%' || :lV66Wpaddfuncds_1_filterfulltext) or ( T1.SecFunctionalityModule like '%' || :lV66Wpaddfuncds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV69Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV69Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV70Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV68Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV70Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV74Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV74Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV75Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV71Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV75Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV79Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV79Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV80Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV76Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV80Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpaddfuncds_16_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV81Wpaddfuncds_16_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_18_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule like :lV83Wpaddfuncds_18_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule = ( :AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityModule))=0))");
         }
         if ( AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = TRUE)");
         }
         if ( AV85Wpaddfuncds_20_tfsecfunctionalityactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityModule";
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
                     return conditional_P00CN3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (bool)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_P00CN5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (bool)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00CN3;
          prmP00CN3 = new Object[] {
          new ParDef("AV61SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV66Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV69Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV80Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV80Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV81Wpaddfuncds_16_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_18_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00CN5;
          prmP00CN5 = new Object[] {
          new ParDef("AV61SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV66Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV69Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV80Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV80Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV81Wpaddfuncds_16_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV82Wpaddfuncds_17_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_18_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV84Wpaddfuncds_19_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CN3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CN3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CN5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CN5,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
