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
   public class wpfuncionalidadesgetfilterdata : GXProcedure
   {
      public wpfuncionalidadesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfuncionalidadesgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_SECFUNCTIONALITYMODULE") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYMODULEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' */
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
         if ( StringUtil.StrCmp(AV34Session.Get("WpFuncionalidadesGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpFuncionalidadesGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("WpFuncionalidadesGridState"), null, "", "");
         }
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE") == 0 )
            {
               AV63TFSecFunctionalityModule = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE_SEL") == 0 )
            {
               AV64TFSecFunctionalityModule_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV14TFSecFunctionalityDescription = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV15TFSecFunctionalityDescription_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&SECROLEID") == 0 )
            {
               AV62SecRoleId = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV38GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECFUNCTIONALITYROLEATIVO") == 0 )
            {
               AV65SecFunctionalityRoleAtivo1 = BooleanUtil.Val( AV38GridStateDynamicFilter.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV48SecFunctionalityDescription1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV50DynamicFiltersEnabled2 = true;
               AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV38GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECFUNCTIONALITYROLEATIVO") == 0 )
               {
                  AV66SecFunctionalityRoleAtivo2 = BooleanUtil.Val( AV38GridStateDynamicFilter.gxTpr_Value);
               }
               else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV53SecFunctionalityDescription2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV55DynamicFiltersEnabled3 = true;
                  AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV38GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECFUNCTIONALITYROLEATIVO") == 0 )
                  {
                     AV67SecFunctionalityRoleAtivo3 = BooleanUtil.Val( AV38GridStateDynamicFilter.gxTpr_Value);
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV58SecFunctionalityDescription3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYMODULEOPTIONS' Routine */
         returnInSub = false;
         AV63TFSecFunctionalityModule = AV23SearchTxt;
         AV64TFSecFunctionalityModule_Sel = "";
         AV70Wpfuncionalidadesds_1_secroleid = AV62SecRoleId;
         AV71Wpfuncionalidadesds_2_filterfulltext = AV45FilterFullText;
         AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV65SecFunctionalityRoleAtivo1;
         AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV48SecFunctionalityDescription1;
         AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV66SecFunctionalityRoleAtivo2;
         AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV53SecFunctionalityDescription2;
         AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV67SecFunctionalityRoleAtivo3;
         AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV58SecFunctionalityDescription3;
         AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV63TFSecFunctionalityModule;
         AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV64TFSecFunctionalityModule_Sel;
         AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV14TFSecFunctionalityDescription;
         AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV15TFSecFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV71Wpfuncionalidadesds_2_filterfulltext ,
                                              AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                              AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                              AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                              AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                              AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                              AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                              AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                              AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                              AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                              AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                              AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                              AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                              AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                              AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                              AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                              AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                              AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                              AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                              A789SecFunctionalityModule ,
                                              A135SecFunctionalityDescription ,
                                              A735SecFunctionalityRoleAtivo ,
                                              AV70Wpfuncionalidadesds_1_secroleid ,
                                              A131SecRoleId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV71Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wpfuncionalidadesds_2_filterfulltext), "%", "");
         lV71Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wpfuncionalidadesds_2_filterfulltext), "%", "");
         lV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
         lV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
         lV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
         lV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
         lV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
         lV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
         lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule), "%", "");
         lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription), "%", "");
         /* Using cursor P00CM2 */
         pr_default.execute(0, new Object[] {AV70Wpfuncionalidadesds_1_secroleid, lV71Wpfuncionalidadesds_2_filterfulltext, lV71Wpfuncionalidadesds_2_filterfulltext, AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1, lV75Wpfuncionalidadesds_6_secfunctionalitydescription1, lV75Wpfuncionalidadesds_6_secfunctionalitydescription1, AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2, lV80Wpfuncionalidadesds_11_secfunctionalitydescription2, lV80Wpfuncionalidadesds_11_secfunctionalitydescription2, AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3, lV85Wpfuncionalidadesds_16_secfunctionalitydescription3, lV85Wpfuncionalidadesds_16_secfunctionalitydescription3, lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule, AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription, AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCM2 = false;
            A128SecFunctionalityId = P00CM2_A128SecFunctionalityId[0];
            A131SecRoleId = P00CM2_A131SecRoleId[0];
            A789SecFunctionalityModule = P00CM2_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = P00CM2_n789SecFunctionalityModule[0];
            A735SecFunctionalityRoleAtivo = P00CM2_A735SecFunctionalityRoleAtivo[0];
            A135SecFunctionalityDescription = P00CM2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00CM2_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = P00CM2_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = P00CM2_n789SecFunctionalityModule[0];
            A135SecFunctionalityDescription = P00CM2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00CM2_n135SecFunctionalityDescription[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00CM2_A131SecRoleId[0] == A131SecRoleId ) && ( StringUtil.StrCmp(P00CM2_A789SecFunctionalityModule[0], A789SecFunctionalityModule) == 0 ) )
            {
               BRKCM2 = false;
               A128SecFunctionalityId = P00CM2_A128SecFunctionalityId[0];
               AV33count = (long)(AV33count+1);
               BRKCM2 = true;
               pr_default.readNext(0);
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
            if ( ! BRKCM2 )
            {
               BRKCM2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFSecFunctionalityDescription = AV23SearchTxt;
         AV15TFSecFunctionalityDescription_Sel = "";
         AV70Wpfuncionalidadesds_1_secroleid = AV62SecRoleId;
         AV71Wpfuncionalidadesds_2_filterfulltext = AV45FilterFullText;
         AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV65SecFunctionalityRoleAtivo1;
         AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV48SecFunctionalityDescription1;
         AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV66SecFunctionalityRoleAtivo2;
         AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV53SecFunctionalityDescription2;
         AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV67SecFunctionalityRoleAtivo3;
         AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV58SecFunctionalityDescription3;
         AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV63TFSecFunctionalityModule;
         AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV64TFSecFunctionalityModule_Sel;
         AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV14TFSecFunctionalityDescription;
         AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV15TFSecFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV71Wpfuncionalidadesds_2_filterfulltext ,
                                              AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                              AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                              AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                              AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                              AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                              AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                              AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                              AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                              AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                              AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                              AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                              AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                              AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                              AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                              AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                              AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                              AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                              AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                              A789SecFunctionalityModule ,
                                              A135SecFunctionalityDescription ,
                                              A735SecFunctionalityRoleAtivo ,
                                              AV70Wpfuncionalidadesds_1_secroleid ,
                                              A131SecRoleId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV71Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wpfuncionalidadesds_2_filterfulltext), "%", "");
         lV71Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wpfuncionalidadesds_2_filterfulltext), "%", "");
         lV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
         lV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
         lV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
         lV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
         lV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
         lV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
         lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule), "%", "");
         lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription), "%", "");
         /* Using cursor P00CM3 */
         pr_default.execute(1, new Object[] {AV70Wpfuncionalidadesds_1_secroleid, lV71Wpfuncionalidadesds_2_filterfulltext, lV71Wpfuncionalidadesds_2_filterfulltext, AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1, lV75Wpfuncionalidadesds_6_secfunctionalitydescription1, lV75Wpfuncionalidadesds_6_secfunctionalitydescription1, AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2, lV80Wpfuncionalidadesds_11_secfunctionalitydescription2, lV80Wpfuncionalidadesds_11_secfunctionalitydescription2, AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3, lV85Wpfuncionalidadesds_16_secfunctionalitydescription3, lV85Wpfuncionalidadesds_16_secfunctionalitydescription3, lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule, AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription, AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCM4 = false;
            A131SecRoleId = P00CM3_A131SecRoleId[0];
            A128SecFunctionalityId = P00CM3_A128SecFunctionalityId[0];
            A735SecFunctionalityRoleAtivo = P00CM3_A735SecFunctionalityRoleAtivo[0];
            A135SecFunctionalityDescription = P00CM3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00CM3_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = P00CM3_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = P00CM3_n789SecFunctionalityModule[0];
            A135SecFunctionalityDescription = P00CM3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00CM3_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = P00CM3_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = P00CM3_n789SecFunctionalityModule[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00CM3_A131SecRoleId[0] == A131SecRoleId ) && ( P00CM3_A128SecFunctionalityId[0] == A128SecFunctionalityId ) )
            {
               BRKCM4 = false;
               AV33count = (long)(AV33count+1);
               BRKCM4 = true;
               pr_default.readNext(1);
            }
            AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A135SecFunctionalityDescription)) ? "<#Empty#>" : A135SecFunctionalityDescription);
            AV27InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV28Option, "<#Empty#>") != 0 ) && ( AV27InsertIndex <= AV29Options.Count ) && ( ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), AV28Option) < 0 ) || ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV29Options.Add(AV28Option, AV27InsertIndex);
            AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), AV27InsertIndex);
            if ( AV29Options.Count == AV24SkipItems + 11 )
            {
               AV29Options.RemoveItem(AV29Options.Count);
               AV32OptionIndexes.RemoveItem(AV32OptionIndexes.Count);
            }
            if ( ! BRKCM4 )
            {
               BRKCM4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV24SkipItems > 0 )
         {
            AV29Options.RemoveItem(1);
            AV32OptionIndexes.RemoveItem(1);
            AV24SkipItems = (short)(AV24SkipItems-1);
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
         AV63TFSecFunctionalityModule = "";
         AV64TFSecFunctionalityModule_Sel = "";
         AV14TFSecFunctionalityDescription = "";
         AV15TFSecFunctionalityDescription_Sel = "";
         AV38GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV46DynamicFiltersSelector1 = "";
         AV48SecFunctionalityDescription1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV53SecFunctionalityDescription2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV58SecFunctionalityDescription3 = "";
         AV71Wpfuncionalidadesds_2_filterfulltext = "";
         AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 = "";
         AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = "";
         AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 = "";
         AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = "";
         AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 = "";
         AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = "";
         AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule = "";
         AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = "";
         AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription = "";
         AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = "";
         lV71Wpfuncionalidadesds_2_filterfulltext = "";
         lV75Wpfuncionalidadesds_6_secfunctionalitydescription1 = "";
         lV80Wpfuncionalidadesds_11_secfunctionalitydescription2 = "";
         lV85Wpfuncionalidadesds_16_secfunctionalitydescription3 = "";
         lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule = "";
         lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription = "";
         A789SecFunctionalityModule = "";
         A135SecFunctionalityDescription = "";
         P00CM2_A128SecFunctionalityId = new long[1] ;
         P00CM2_A131SecRoleId = new short[1] ;
         P00CM2_A789SecFunctionalityModule = new string[] {""} ;
         P00CM2_n789SecFunctionalityModule = new bool[] {false} ;
         P00CM2_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         P00CM2_A135SecFunctionalityDescription = new string[] {""} ;
         P00CM2_n135SecFunctionalityDescription = new bool[] {false} ;
         AV28Option = "";
         P00CM3_A131SecRoleId = new short[1] ;
         P00CM3_A128SecFunctionalityId = new long[1] ;
         P00CM3_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         P00CM3_A135SecFunctionalityDescription = new string[] {""} ;
         P00CM3_n135SecFunctionalityDescription = new bool[] {false} ;
         P00CM3_A789SecFunctionalityModule = new string[] {""} ;
         P00CM3_n789SecFunctionalityModule = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfuncionalidadesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CM2_A128SecFunctionalityId, P00CM2_A131SecRoleId, P00CM2_A789SecFunctionalityModule, P00CM2_n789SecFunctionalityModule, P00CM2_A735SecFunctionalityRoleAtivo, P00CM2_A135SecFunctionalityDescription, P00CM2_n135SecFunctionalityDescription
               }
               , new Object[] {
               P00CM3_A131SecRoleId, P00CM3_A128SecFunctionalityId, P00CM3_A735SecFunctionalityRoleAtivo, P00CM3_A135SecFunctionalityDescription, P00CM3_n135SecFunctionalityDescription, P00CM3_A789SecFunctionalityModule, P00CM3_n789SecFunctionalityModule
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV62SecRoleId ;
      private short AV47DynamicFiltersOperator1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV70Wpfuncionalidadesds_1_secroleid ;
      private short AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 ;
      private short AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 ;
      private short AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 ;
      private short A131SecRoleId ;
      private int AV68GXV1 ;
      private int AV27InsertIndex ;
      private long A128SecFunctionalityId ;
      private long AV33count ;
      private bool returnInSub ;
      private bool AV65SecFunctionalityRoleAtivo1 ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV66SecFunctionalityRoleAtivo2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV67SecFunctionalityRoleAtivo3 ;
      private bool AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 ;
      private bool AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 ;
      private bool AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 ;
      private bool AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 ;
      private bool AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 ;
      private bool A735SecFunctionalityRoleAtivo ;
      private bool BRKCM2 ;
      private bool n789SecFunctionalityModule ;
      private bool n135SecFunctionalityDescription ;
      private bool BRKCM4 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV63TFSecFunctionalityModule ;
      private string AV64TFSecFunctionalityModule_Sel ;
      private string AV14TFSecFunctionalityDescription ;
      private string AV15TFSecFunctionalityDescription_Sel ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV48SecFunctionalityDescription1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV53SecFunctionalityDescription2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV58SecFunctionalityDescription3 ;
      private string AV71Wpfuncionalidadesds_2_filterfulltext ;
      private string AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 ;
      private string AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 ;
      private string AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 ;
      private string AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 ;
      private string AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 ;
      private string AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 ;
      private string AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule ;
      private string AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ;
      private string AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription ;
      private string AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ;
      private string lV71Wpfuncionalidadesds_2_filterfulltext ;
      private string lV75Wpfuncionalidadesds_6_secfunctionalitydescription1 ;
      private string lV80Wpfuncionalidadesds_11_secfunctionalitydescription2 ;
      private string lV85Wpfuncionalidadesds_16_secfunctionalitydescription3 ;
      private string lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule ;
      private string lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription ;
      private string A789SecFunctionalityModule ;
      private string A135SecFunctionalityDescription ;
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
      private long[] P00CM2_A128SecFunctionalityId ;
      private short[] P00CM2_A131SecRoleId ;
      private string[] P00CM2_A789SecFunctionalityModule ;
      private bool[] P00CM2_n789SecFunctionalityModule ;
      private bool[] P00CM2_A735SecFunctionalityRoleAtivo ;
      private string[] P00CM2_A135SecFunctionalityDescription ;
      private bool[] P00CM2_n135SecFunctionalityDescription ;
      private short[] P00CM3_A131SecRoleId ;
      private long[] P00CM3_A128SecFunctionalityId ;
      private bool[] P00CM3_A735SecFunctionalityRoleAtivo ;
      private string[] P00CM3_A135SecFunctionalityDescription ;
      private bool[] P00CM3_n135SecFunctionalityDescription ;
      private string[] P00CM3_A789SecFunctionalityModule ;
      private bool[] P00CM3_n789SecFunctionalityModule ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpfuncionalidadesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CM2( IGxContext context ,
                                             string AV71Wpfuncionalidadesds_2_filterfulltext ,
                                             string AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                             bool AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                             short AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                             string AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                             bool AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                             string AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                             bool AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                             short AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                             string AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                             bool AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                             string AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                             bool AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                             short AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                             string AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                             string AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                             string AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                             string AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                             string AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                             string A789SecFunctionalityModule ,
                                             string A135SecFunctionalityDescription ,
                                             bool A735SecFunctionalityRoleAtivo ,
                                             short AV70Wpfuncionalidadesds_1_secroleid ,
                                             short A131SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecFunctionalityId, T1.SecRoleId, T2.SecFunctionalityModule, T1.SecFunctionalityRoleAtivo, T2.SecFunctionalityDescription FROM (SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV70Wpfuncionalidadesds_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfuncionalidadesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityModule like '%' || :lV71Wpfuncionalidadesds_2_filterfulltext) or ( T2.SecFunctionalityDescription like '%' || :lV71Wpfuncionalidadesds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV75Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV75Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV80Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV80Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV85Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV85Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule like :lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule = ( :AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityModule))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecRoleId, T2.SecFunctionalityModule";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CM3( IGxContext context ,
                                             string AV71Wpfuncionalidadesds_2_filterfulltext ,
                                             string AV72Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                             bool AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                             short AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                             string AV75Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                             bool AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                             string AV77Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                             bool AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                             short AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                             string AV80Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                             bool AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                             string AV82Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                             bool AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                             short AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                             string AV85Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                             string AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                             string AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                             string AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                             string AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                             string A789SecFunctionalityModule ,
                                             string A135SecFunctionalityDescription ,
                                             bool A735SecFunctionalityRoleAtivo ,
                                             short AV70Wpfuncionalidadesds_1_secroleid ,
                                             short A131SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecRoleId, T1.SecFunctionalityId, T1.SecFunctionalityRoleAtivo, T2.SecFunctionalityDescription, T2.SecFunctionalityModule FROM (SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV70Wpfuncionalidadesds_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfuncionalidadesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityModule like '%' || :lV71Wpfuncionalidadesds_2_filterfulltext) or ( T2.SecFunctionalityDescription like '%' || :lV71Wpfuncionalidadesds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV75Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV73Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV75Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV80Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV76Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV78Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV80Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV85Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV81Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV83Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV85Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule like :lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule = ( :AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityModule))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecRoleId, T1.SecFunctionalityId";
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
                     return conditional_P00CM2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] );
               case 1 :
                     return conditional_P00CM3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] );
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
          Object[] prmP00CM2;
          prmP00CM2 = new Object[] {
          new ParDef("AV70Wpfuncionalidadesds_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV71Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1",GXType.Boolean,4,0) ,
          new ParDef("lV75Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2",GXType.Boolean,4,0) ,
          new ParDef("lV80Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV80Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3",GXType.Boolean,4,0) ,
          new ParDef("lV85Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV85Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00CM3;
          prmP00CM3 = new Object[] {
          new ParDef("AV70Wpfuncionalidadesds_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV71Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV74Wpfuncionalidadesds_5_secfunctionalityroleativo1",GXType.Boolean,4,0) ,
          new ParDef("lV75Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("AV79Wpfuncionalidadesds_10_secfunctionalityroleativo2",GXType.Boolean,4,0) ,
          new ParDef("lV80Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV80Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("AV84Wpfuncionalidadesds_15_secfunctionalityroleativo3",GXType.Boolean,4,0) ,
          new ParDef("lV85Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV85Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV86Wpfuncionalidadesds_17_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV87Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wpfuncionalidadesds_19_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV89Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CM3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CM3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
