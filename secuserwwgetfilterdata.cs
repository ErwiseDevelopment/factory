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
   public class secuserwwgetfilterdata : GXProcedure
   {
      public secuserwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserwwgetfilterdata( IGxContext context )
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
         this.AV16DDOName = aP0_DDOName;
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
         this.AV15SearchTxtTo = aP2_SearchTxtTo;
         this.AV20OptionsJson = "" ;
         this.AV23OptionsDescJson = "" ;
         this.AV25OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV25OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV16DDOName = aP0_DDOName;
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
         this.AV15SearchTxtTo = aP2_SearchTxtTo;
         this.AV20OptionsJson = "" ;
         this.AV23OptionsDescJson = "" ;
         this.AV25OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV46MaxItems = 10;
         AV45PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV47SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? "" : StringUtil.Substring( AV47SearchTxtParms, 3, -1));
         AV44SkipItems = (short)(AV45PageIndex*AV46MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV43WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECUSERFULLNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERFULLNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECUSEREMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSEREMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV20OptionsJson = AV19Options.ToJSonString(false);
         AV23OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV25OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("SecUserWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("SecUserWWGridState"), null, "", "");
         }
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV52FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV12TFSecUserName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV13TFSecUserName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV48TFSecUserFullName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV49TFSecUserFullName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV50TFSecUserEmail = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV51TFSecUserEmail_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV53TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV32DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV33DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV34SecUserName1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
            {
               AV33DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV65SecUserManName1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV35DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV36DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV37DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV38SecUserName2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
               {
                  AV37DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV66SecUserManName2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV39DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV40DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV41DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV42SecUserName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
                  {
                     AV41DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV67SecUserManName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecUserName = AV14SearchTxt;
         AV13TFSecUserName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52FilterFullText ,
                                              AV32DynamicFiltersSelector1 ,
                                              AV33DynamicFiltersOperator1 ,
                                              AV34SecUserName1 ,
                                              AV65SecUserManName1 ,
                                              AV35DynamicFiltersEnabled2 ,
                                              AV36DynamicFiltersSelector2 ,
                                              AV37DynamicFiltersOperator2 ,
                                              AV38SecUserName2 ,
                                              AV66SecUserManName2 ,
                                              AV39DynamicFiltersEnabled3 ,
                                              AV40DynamicFiltersSelector3 ,
                                              AV41DynamicFiltersOperator3 ,
                                              AV42SecUserName3 ,
                                              AV67SecUserManName3 ,
                                              AV13TFSecUserName_Sel ,
                                              AV12TFSecUserName ,
                                              AV49TFSecUserFullName_Sel ,
                                              AV48TFSecUserFullName ,
                                              AV51TFSecUserEmail_Sel ,
                                              AV50TFSecUserEmail ,
                                              AV53TFSecUserStatus_Sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV34SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV34SecUserName1), "%", "");
         lV34SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV34SecUserName1), "%", "");
         lV65SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV65SecUserManName1), "%", "");
         lV65SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV65SecUserManName1), "%", "");
         lV38SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV38SecUserName2), "%", "");
         lV38SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV38SecUserName2), "%", "");
         lV66SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV66SecUserManName2), "%", "");
         lV66SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV66SecUserManName2), "%", "");
         lV42SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV42SecUserName3), "%", "");
         lV42SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV42SecUserName3), "%", "");
         lV67SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV67SecUserManName3), "%", "");
         lV67SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV67SecUserManName3), "%", "");
         lV12TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV12TFSecUserName), "%", "");
         lV48TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV48TFSecUserFullName), "%", "");
         lV50TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV50TFSecUserEmail), "%", "");
         /* Using cursor P00512 */
         pr_default.execute(0, new Object[] {lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV34SecUserName1, lV34SecUserName1, lV65SecUserManName1, lV65SecUserManName1, lV38SecUserName2, lV38SecUserName2, lV66SecUserManName2, lV66SecUserManName2, lV42SecUserName3, lV42SecUserName3, lV67SecUserManName3, lV67SecUserManName3, lV12TFSecUserName, AV13TFSecUserName_Sel, lV48TFSecUserFullName, AV49TFSecUserFullName_Sel, lV50TFSecUserEmail, AV51TFSecUserEmail_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK512 = false;
            A147SecUserUserMan = P00512_A147SecUserUserMan[0];
            n147SecUserUserMan = P00512_n147SecUserUserMan[0];
            A141SecUserName = P00512_A141SecUserName[0];
            n141SecUserName = P00512_n141SecUserName[0];
            A148SecUserManName = P00512_A148SecUserManName[0];
            n148SecUserManName = P00512_n148SecUserManName[0];
            A150SecUserStatus = P00512_A150SecUserStatus[0];
            n150SecUserStatus = P00512_n150SecUserStatus[0];
            A144SecUserEmail = P00512_A144SecUserEmail[0];
            n144SecUserEmail = P00512_n144SecUserEmail[0];
            A143SecUserFullName = P00512_A143SecUserFullName[0];
            n143SecUserFullName = P00512_n143SecUserFullName[0];
            A133SecUserId = P00512_A133SecUserId[0];
            A148SecUserManName = P00512_A148SecUserManName[0];
            n148SecUserManName = P00512_n148SecUserManName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00512_A141SecUserName[0], A141SecUserName) == 0 ) )
            {
               BRK512 = false;
               A133SecUserId = P00512_A133SecUserId[0];
               AV26count = (long)(AV26count+1);
               BRK512 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV44SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? "<#Empty#>" : A141SecUserName);
               AV21OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")));
               AV19Options.Add(AV18Option, 0);
               AV22OptionsDesc.Add(AV21OptionDesc, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK512 )
            {
               BRK512 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECUSERFULLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV48TFSecUserFullName = AV14SearchTxt;
         AV49TFSecUserFullName_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52FilterFullText ,
                                              AV32DynamicFiltersSelector1 ,
                                              AV33DynamicFiltersOperator1 ,
                                              AV34SecUserName1 ,
                                              AV65SecUserManName1 ,
                                              AV35DynamicFiltersEnabled2 ,
                                              AV36DynamicFiltersSelector2 ,
                                              AV37DynamicFiltersOperator2 ,
                                              AV38SecUserName2 ,
                                              AV66SecUserManName2 ,
                                              AV39DynamicFiltersEnabled3 ,
                                              AV40DynamicFiltersSelector3 ,
                                              AV41DynamicFiltersOperator3 ,
                                              AV42SecUserName3 ,
                                              AV67SecUserManName3 ,
                                              AV13TFSecUserName_Sel ,
                                              AV12TFSecUserName ,
                                              AV49TFSecUserFullName_Sel ,
                                              AV48TFSecUserFullName ,
                                              AV51TFSecUserEmail_Sel ,
                                              AV50TFSecUserEmail ,
                                              AV53TFSecUserStatus_Sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV34SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV34SecUserName1), "%", "");
         lV34SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV34SecUserName1), "%", "");
         lV65SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV65SecUserManName1), "%", "");
         lV65SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV65SecUserManName1), "%", "");
         lV38SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV38SecUserName2), "%", "");
         lV38SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV38SecUserName2), "%", "");
         lV66SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV66SecUserManName2), "%", "");
         lV66SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV66SecUserManName2), "%", "");
         lV42SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV42SecUserName3), "%", "");
         lV42SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV42SecUserName3), "%", "");
         lV67SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV67SecUserManName3), "%", "");
         lV67SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV67SecUserManName3), "%", "");
         lV12TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV12TFSecUserName), "%", "");
         lV48TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV48TFSecUserFullName), "%", "");
         lV50TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV50TFSecUserEmail), "%", "");
         /* Using cursor P00513 */
         pr_default.execute(1, new Object[] {lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV34SecUserName1, lV34SecUserName1, lV65SecUserManName1, lV65SecUserManName1, lV38SecUserName2, lV38SecUserName2, lV66SecUserManName2, lV66SecUserManName2, lV42SecUserName3, lV42SecUserName3, lV67SecUserManName3, lV67SecUserManName3, lV12TFSecUserName, AV13TFSecUserName_Sel, lV48TFSecUserFullName, AV49TFSecUserFullName_Sel, lV50TFSecUserEmail, AV51TFSecUserEmail_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK514 = false;
            A147SecUserUserMan = P00513_A147SecUserUserMan[0];
            n147SecUserUserMan = P00513_n147SecUserUserMan[0];
            A143SecUserFullName = P00513_A143SecUserFullName[0];
            n143SecUserFullName = P00513_n143SecUserFullName[0];
            A148SecUserManName = P00513_A148SecUserManName[0];
            n148SecUserManName = P00513_n148SecUserManName[0];
            A150SecUserStatus = P00513_A150SecUserStatus[0];
            n150SecUserStatus = P00513_n150SecUserStatus[0];
            A144SecUserEmail = P00513_A144SecUserEmail[0];
            n144SecUserEmail = P00513_n144SecUserEmail[0];
            A141SecUserName = P00513_A141SecUserName[0];
            n141SecUserName = P00513_n141SecUserName[0];
            A133SecUserId = P00513_A133SecUserId[0];
            A148SecUserManName = P00513_A148SecUserManName[0];
            n148SecUserManName = P00513_n148SecUserManName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00513_A143SecUserFullName[0], A143SecUserFullName) == 0 ) )
            {
               BRK514 = false;
               A133SecUserId = P00513_A133SecUserId[0];
               AV26count = (long)(AV26count+1);
               BRK514 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV44SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) ? "<#Empty#>" : A143SecUserFullName);
               AV21OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")));
               AV19Options.Add(AV18Option, 0);
               AV22OptionsDesc.Add(AV21OptionDesc, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK514 )
            {
               BRK514 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSECUSEREMAILOPTIONS' Routine */
         returnInSub = false;
         AV50TFSecUserEmail = AV14SearchTxt;
         AV51TFSecUserEmail_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV52FilterFullText ,
                                              AV32DynamicFiltersSelector1 ,
                                              AV33DynamicFiltersOperator1 ,
                                              AV34SecUserName1 ,
                                              AV65SecUserManName1 ,
                                              AV35DynamicFiltersEnabled2 ,
                                              AV36DynamicFiltersSelector2 ,
                                              AV37DynamicFiltersOperator2 ,
                                              AV38SecUserName2 ,
                                              AV66SecUserManName2 ,
                                              AV39DynamicFiltersEnabled3 ,
                                              AV40DynamicFiltersSelector3 ,
                                              AV41DynamicFiltersOperator3 ,
                                              AV42SecUserName3 ,
                                              AV67SecUserManName3 ,
                                              AV13TFSecUserName_Sel ,
                                              AV12TFSecUserName ,
                                              AV49TFSecUserFullName_Sel ,
                                              AV48TFSecUserFullName ,
                                              AV51TFSecUserEmail_Sel ,
                                              AV50TFSecUserEmail ,
                                              AV53TFSecUserStatus_Sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV52FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV52FilterFullText), "%", "");
         lV34SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV34SecUserName1), "%", "");
         lV34SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV34SecUserName1), "%", "");
         lV65SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV65SecUserManName1), "%", "");
         lV65SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV65SecUserManName1), "%", "");
         lV38SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV38SecUserName2), "%", "");
         lV38SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV38SecUserName2), "%", "");
         lV66SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV66SecUserManName2), "%", "");
         lV66SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV66SecUserManName2), "%", "");
         lV42SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV42SecUserName3), "%", "");
         lV42SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV42SecUserName3), "%", "");
         lV67SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV67SecUserManName3), "%", "");
         lV67SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV67SecUserManName3), "%", "");
         lV12TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV12TFSecUserName), "%", "");
         lV48TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV48TFSecUserFullName), "%", "");
         lV50TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV50TFSecUserEmail), "%", "");
         /* Using cursor P00514 */
         pr_default.execute(2, new Object[] {lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV52FilterFullText, lV34SecUserName1, lV34SecUserName1, lV65SecUserManName1, lV65SecUserManName1, lV38SecUserName2, lV38SecUserName2, lV66SecUserManName2, lV66SecUserManName2, lV42SecUserName3, lV42SecUserName3, lV67SecUserManName3, lV67SecUserManName3, lV12TFSecUserName, AV13TFSecUserName_Sel, lV48TFSecUserFullName, AV49TFSecUserFullName_Sel, lV50TFSecUserEmail, AV51TFSecUserEmail_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK516 = false;
            A147SecUserUserMan = P00514_A147SecUserUserMan[0];
            n147SecUserUserMan = P00514_n147SecUserUserMan[0];
            A144SecUserEmail = P00514_A144SecUserEmail[0];
            n144SecUserEmail = P00514_n144SecUserEmail[0];
            A148SecUserManName = P00514_A148SecUserManName[0];
            n148SecUserManName = P00514_n148SecUserManName[0];
            A150SecUserStatus = P00514_A150SecUserStatus[0];
            n150SecUserStatus = P00514_n150SecUserStatus[0];
            A143SecUserFullName = P00514_A143SecUserFullName[0];
            n143SecUserFullName = P00514_n143SecUserFullName[0];
            A141SecUserName = P00514_A141SecUserName[0];
            n141SecUserName = P00514_n141SecUserName[0];
            A133SecUserId = P00514_A133SecUserId[0];
            A148SecUserManName = P00514_A148SecUserManName[0];
            n148SecUserManName = P00514_n148SecUserManName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00514_A144SecUserEmail[0], A144SecUserEmail) == 0 ) )
            {
               BRK516 = false;
               A133SecUserId = P00514_A133SecUserId[0];
               AV26count = (long)(AV26count+1);
               BRK516 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV44SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ? "<#Empty#>" : A144SecUserEmail);
               AV19Options.Add(AV18Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK516 )
            {
               BRK516 = true;
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
         AV20OptionsJson = "";
         AV23OptionsDescJson = "";
         AV25OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV43WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52FilterFullText = "";
         AV12TFSecUserName = "";
         AV13TFSecUserName_Sel = "";
         AV48TFSecUserFullName = "";
         AV49TFSecUserFullName_Sel = "";
         AV50TFSecUserEmail = "";
         AV51TFSecUserEmail_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV32DynamicFiltersSelector1 = "";
         AV34SecUserName1 = "";
         AV65SecUserManName1 = "";
         AV36DynamicFiltersSelector2 = "";
         AV38SecUserName2 = "";
         AV66SecUserManName2 = "";
         AV40DynamicFiltersSelector3 = "";
         AV42SecUserName3 = "";
         AV67SecUserManName3 = "";
         lV52FilterFullText = "";
         lV34SecUserName1 = "";
         lV65SecUserManName1 = "";
         lV38SecUserName2 = "";
         lV66SecUserManName2 = "";
         lV42SecUserName3 = "";
         lV67SecUserManName3 = "";
         lV12TFSecUserName = "";
         lV48TFSecUserFullName = "";
         lV50TFSecUserEmail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         A148SecUserManName = "";
         P00512_A147SecUserUserMan = new short[1] ;
         P00512_n147SecUserUserMan = new bool[] {false} ;
         P00512_A141SecUserName = new string[] {""} ;
         P00512_n141SecUserName = new bool[] {false} ;
         P00512_A148SecUserManName = new string[] {""} ;
         P00512_n148SecUserManName = new bool[] {false} ;
         P00512_A150SecUserStatus = new bool[] {false} ;
         P00512_n150SecUserStatus = new bool[] {false} ;
         P00512_A144SecUserEmail = new string[] {""} ;
         P00512_n144SecUserEmail = new bool[] {false} ;
         P00512_A143SecUserFullName = new string[] {""} ;
         P00512_n143SecUserFullName = new bool[] {false} ;
         P00512_A133SecUserId = new short[1] ;
         AV18Option = "";
         AV21OptionDesc = "";
         P00513_A147SecUserUserMan = new short[1] ;
         P00513_n147SecUserUserMan = new bool[] {false} ;
         P00513_A143SecUserFullName = new string[] {""} ;
         P00513_n143SecUserFullName = new bool[] {false} ;
         P00513_A148SecUserManName = new string[] {""} ;
         P00513_n148SecUserManName = new bool[] {false} ;
         P00513_A150SecUserStatus = new bool[] {false} ;
         P00513_n150SecUserStatus = new bool[] {false} ;
         P00513_A144SecUserEmail = new string[] {""} ;
         P00513_n144SecUserEmail = new bool[] {false} ;
         P00513_A141SecUserName = new string[] {""} ;
         P00513_n141SecUserName = new bool[] {false} ;
         P00513_A133SecUserId = new short[1] ;
         P00514_A147SecUserUserMan = new short[1] ;
         P00514_n147SecUserUserMan = new bool[] {false} ;
         P00514_A144SecUserEmail = new string[] {""} ;
         P00514_n144SecUserEmail = new bool[] {false} ;
         P00514_A148SecUserManName = new string[] {""} ;
         P00514_n148SecUserManName = new bool[] {false} ;
         P00514_A150SecUserStatus = new bool[] {false} ;
         P00514_n150SecUserStatus = new bool[] {false} ;
         P00514_A143SecUserFullName = new string[] {""} ;
         P00514_n143SecUserFullName = new bool[] {false} ;
         P00514_A141SecUserName = new string[] {""} ;
         P00514_n141SecUserName = new bool[] {false} ;
         P00514_A133SecUserId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00512_A147SecUserUserMan, P00512_n147SecUserUserMan, P00512_A141SecUserName, P00512_n141SecUserName, P00512_A148SecUserManName, P00512_n148SecUserManName, P00512_A150SecUserStatus, P00512_n150SecUserStatus, P00512_A144SecUserEmail, P00512_n144SecUserEmail,
               P00512_A143SecUserFullName, P00512_n143SecUserFullName, P00512_A133SecUserId
               }
               , new Object[] {
               P00513_A147SecUserUserMan, P00513_n147SecUserUserMan, P00513_A143SecUserFullName, P00513_n143SecUserFullName, P00513_A148SecUserManName, P00513_n148SecUserManName, P00513_A150SecUserStatus, P00513_n150SecUserStatus, P00513_A144SecUserEmail, P00513_n144SecUserEmail,
               P00513_A141SecUserName, P00513_n141SecUserName, P00513_A133SecUserId
               }
               , new Object[] {
               P00514_A147SecUserUserMan, P00514_n147SecUserUserMan, P00514_A144SecUserEmail, P00514_n144SecUserEmail, P00514_A148SecUserManName, P00514_n148SecUserManName, P00514_A150SecUserStatus, P00514_n150SecUserStatus, P00514_A143SecUserFullName, P00514_n143SecUserFullName,
               P00514_A141SecUserName, P00514_n141SecUserName, P00514_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV46MaxItems ;
      private short AV45PageIndex ;
      private short AV44SkipItems ;
      private short AV53TFSecUserStatus_Sel ;
      private short AV33DynamicFiltersOperator1 ;
      private short AV37DynamicFiltersOperator2 ;
      private short AV41DynamicFiltersOperator3 ;
      private short A147SecUserUserMan ;
      private short A133SecUserId ;
      private int AV68GXV1 ;
      private long AV26count ;
      private bool returnInSub ;
      private bool AV35DynamicFiltersEnabled2 ;
      private bool AV39DynamicFiltersEnabled3 ;
      private bool A150SecUserStatus ;
      private bool BRK512 ;
      private bool n147SecUserUserMan ;
      private bool n141SecUserName ;
      private bool n148SecUserManName ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool BRK514 ;
      private bool BRK516 ;
      private string AV20OptionsJson ;
      private string AV23OptionsDescJson ;
      private string AV25OptionIndexesJson ;
      private string AV16DDOName ;
      private string AV47SearchTxtParms ;
      private string AV15SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV52FilterFullText ;
      private string AV12TFSecUserName ;
      private string AV13TFSecUserName_Sel ;
      private string AV48TFSecUserFullName ;
      private string AV49TFSecUserFullName_Sel ;
      private string AV50TFSecUserEmail ;
      private string AV51TFSecUserEmail_Sel ;
      private string AV32DynamicFiltersSelector1 ;
      private string AV34SecUserName1 ;
      private string AV65SecUserManName1 ;
      private string AV36DynamicFiltersSelector2 ;
      private string AV38SecUserName2 ;
      private string AV66SecUserManName2 ;
      private string AV40DynamicFiltersSelector3 ;
      private string AV42SecUserName3 ;
      private string AV67SecUserManName3 ;
      private string lV52FilterFullText ;
      private string lV34SecUserName1 ;
      private string lV65SecUserManName1 ;
      private string lV38SecUserName2 ;
      private string lV66SecUserManName2 ;
      private string lV42SecUserName3 ;
      private string lV67SecUserManName3 ;
      private string lV12TFSecUserName ;
      private string lV48TFSecUserFullName ;
      private string lV50TFSecUserEmail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string A148SecUserManName ;
      private string AV18Option ;
      private string AV21OptionDesc ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV43WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00512_A147SecUserUserMan ;
      private bool[] P00512_n147SecUserUserMan ;
      private string[] P00512_A141SecUserName ;
      private bool[] P00512_n141SecUserName ;
      private string[] P00512_A148SecUserManName ;
      private bool[] P00512_n148SecUserManName ;
      private bool[] P00512_A150SecUserStatus ;
      private bool[] P00512_n150SecUserStatus ;
      private string[] P00512_A144SecUserEmail ;
      private bool[] P00512_n144SecUserEmail ;
      private string[] P00512_A143SecUserFullName ;
      private bool[] P00512_n143SecUserFullName ;
      private short[] P00512_A133SecUserId ;
      private short[] P00513_A147SecUserUserMan ;
      private bool[] P00513_n147SecUserUserMan ;
      private string[] P00513_A143SecUserFullName ;
      private bool[] P00513_n143SecUserFullName ;
      private string[] P00513_A148SecUserManName ;
      private bool[] P00513_n148SecUserManName ;
      private bool[] P00513_A150SecUserStatus ;
      private bool[] P00513_n150SecUserStatus ;
      private string[] P00513_A144SecUserEmail ;
      private bool[] P00513_n144SecUserEmail ;
      private string[] P00513_A141SecUserName ;
      private bool[] P00513_n141SecUserName ;
      private short[] P00513_A133SecUserId ;
      private short[] P00514_A147SecUserUserMan ;
      private bool[] P00514_n147SecUserUserMan ;
      private string[] P00514_A144SecUserEmail ;
      private bool[] P00514_n144SecUserEmail ;
      private string[] P00514_A148SecUserManName ;
      private bool[] P00514_n148SecUserManName ;
      private bool[] P00514_A150SecUserStatus ;
      private bool[] P00514_n150SecUserStatus ;
      private string[] P00514_A143SecUserFullName ;
      private bool[] P00514_n143SecUserFullName ;
      private string[] P00514_A141SecUserName ;
      private bool[] P00514_n141SecUserName ;
      private short[] P00514_A133SecUserId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secuserwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00512( IGxContext context ,
                                             string AV52FilterFullText ,
                                             string AV32DynamicFiltersSelector1 ,
                                             short AV33DynamicFiltersOperator1 ,
                                             string AV34SecUserName1 ,
                                             string AV65SecUserManName1 ,
                                             bool AV35DynamicFiltersEnabled2 ,
                                             string AV36DynamicFiltersSelector2 ,
                                             short AV37DynamicFiltersOperator2 ,
                                             string AV38SecUserName2 ,
                                             string AV66SecUserManName2 ,
                                             bool AV39DynamicFiltersEnabled3 ,
                                             string AV40DynamicFiltersSelector3 ,
                                             short AV41DynamicFiltersOperator3 ,
                                             string AV42SecUserName3 ,
                                             string AV67SecUserManName3 ,
                                             string AV13TFSecUserName_Sel ,
                                             string AV12TFSecUserName ,
                                             string AV49TFSecUserFullName_Sel ,
                                             string AV48TFSecUserFullName ,
                                             string AV51TFSecUserEmail_Sel ,
                                             string AV50TFSecUserEmail ,
                                             short AV53TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[23];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T1.SecUserName, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserFullName, T1.SecUserId FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV52FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV52FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV52FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV52FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV34SecUserName1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV34SecUserName1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV65SecUserManName1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV65SecUserManName1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV38SecUserName2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV38SecUserName2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66SecUserManName2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66SecUserManName2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV42SecUserName3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV42SecUserName3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67SecUserManName3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67SecUserManName3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV12TFSecUserName)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV13TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV13TFSecUserName_Sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV48TFSecUserFullName)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV49TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV49TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV49TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV50TFSecUserEmail)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV51TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV51TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV51TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV53TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV53TFSecUserStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00513( IGxContext context ,
                                             string AV52FilterFullText ,
                                             string AV32DynamicFiltersSelector1 ,
                                             short AV33DynamicFiltersOperator1 ,
                                             string AV34SecUserName1 ,
                                             string AV65SecUserManName1 ,
                                             bool AV35DynamicFiltersEnabled2 ,
                                             string AV36DynamicFiltersSelector2 ,
                                             short AV37DynamicFiltersOperator2 ,
                                             string AV38SecUserName2 ,
                                             string AV66SecUserManName2 ,
                                             bool AV39DynamicFiltersEnabled3 ,
                                             string AV40DynamicFiltersSelector3 ,
                                             short AV41DynamicFiltersOperator3 ,
                                             string AV42SecUserName3 ,
                                             string AV67SecUserManName3 ,
                                             string AV13TFSecUserName_Sel ,
                                             string AV12TFSecUserName ,
                                             string AV49TFSecUserFullName_Sel ,
                                             string AV48TFSecUserFullName ,
                                             string AV51TFSecUserEmail_Sel ,
                                             string AV50TFSecUserEmail ,
                                             short AV53TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T1.SecUserFullName, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserName, T1.SecUserId FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV52FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV52FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV52FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV52FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV34SecUserName1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV34SecUserName1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV65SecUserManName1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV65SecUserManName1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV38SecUserName2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV38SecUserName2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66SecUserManName2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66SecUserManName2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV42SecUserName3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV42SecUserName3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67SecUserManName3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67SecUserManName3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV12TFSecUserName)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV13TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV13TFSecUserName_Sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV48TFSecUserFullName)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV49TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV49TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV49TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV50TFSecUserEmail)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV51TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV51TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV51TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV53TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV53TFSecUserStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecUserFullName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00514( IGxContext context ,
                                             string AV52FilterFullText ,
                                             string AV32DynamicFiltersSelector1 ,
                                             short AV33DynamicFiltersOperator1 ,
                                             string AV34SecUserName1 ,
                                             string AV65SecUserManName1 ,
                                             bool AV35DynamicFiltersEnabled2 ,
                                             string AV36DynamicFiltersSelector2 ,
                                             short AV37DynamicFiltersOperator2 ,
                                             string AV38SecUserName2 ,
                                             string AV66SecUserManName2 ,
                                             bool AV39DynamicFiltersEnabled3 ,
                                             string AV40DynamicFiltersSelector3 ,
                                             short AV41DynamicFiltersOperator3 ,
                                             string AV42SecUserName3 ,
                                             string AV67SecUserManName3 ,
                                             string AV13TFSecUserName_Sel ,
                                             string AV12TFSecUserName ,
                                             string AV49TFSecUserFullName_Sel ,
                                             string AV48TFSecUserFullName ,
                                             string AV51TFSecUserEmail_Sel ,
                                             string AV50TFSecUserEmail ,
                                             short AV53TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T1.SecUserEmail, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserFullName, T1.SecUserName, T1.SecUserId FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV52FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV52FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV52FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV52FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV34SecUserName1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV34SecUserName1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV65SecUserManName1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV33DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV65SecUserManName1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV38SecUserName2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV38SecUserName2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV66SecUserManName2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV35DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV37DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV66SecUserManName2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV42SecUserName3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV42SecUserName3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67SecUserManName3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV39DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV41DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67SecUserManName3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV12TFSecUserName)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV13TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV13TFSecUserName_Sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV48TFSecUserFullName)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV49TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV49TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV49TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV50TFSecUserEmail)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV51TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV51TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV51TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV53TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV53TFSecUserStatus_Sel == 2 )
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
                     return conditional_P00512(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P00513(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P00514(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00512;
          prmP00512 = new Object[] {
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV34SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV34SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV65SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV65SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV38SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV38SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV66SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV66SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV42SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV42SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV67SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV67SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV12TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV13TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV48TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV49TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV50TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV51TFSecUserEmail_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00513;
          prmP00513 = new Object[] {
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV34SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV34SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV65SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV65SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV38SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV38SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV66SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV66SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV42SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV42SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV67SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV67SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV12TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV13TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV48TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV49TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV50TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV51TFSecUserEmail_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00514;
          prmP00514 = new Object[] {
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV52FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV34SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV34SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV65SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV65SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV38SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV38SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV66SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV66SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV42SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV42SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV67SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV67SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV12TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV13TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV48TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV49TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV50TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV51TFSecUserEmail_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00512", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00512,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00513", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00513,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00514", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00514,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
