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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalityfilterparentwwgetfilterdata : GXProcedure
   {
      public secfunctionalityfilterparentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityfilterparentwwgetfilterdata( IGxContext context )
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
         this.AV19DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV18SearchTxtTo = aP2_SearchTxtTo;
         this.AV23OptionsJson = "" ;
         this.AV26OptionsDescJson = "" ;
         this.AV28OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV23OptionsJson;
         aP4_OptionsDescJson=this.AV26OptionsDescJson;
         aP5_OptionIndexesJson=this.AV28OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV28OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV19DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV18SearchTxtTo = aP2_SearchTxtTo;
         this.AV23OptionsJson = "" ;
         this.AV26OptionsDescJson = "" ;
         this.AV28OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV23OptionsJson;
         aP4_OptionsDescJson=this.AV26OptionsDescJson;
         aP5_OptionIndexesJson=this.AV28OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV44MaxItems = 10;
         AV43PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV45SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? "" : StringUtil.Substring( AV45SearchTxtParms, 3, -1));
         AV42SkipItems = (short)(AV43PageIndex*AV44MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV39WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECFUNCTIONALITYKEY") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYKEYOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV23OptionsJson = AV22Options.ToJSonString(false);
         AV26OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV28OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV35SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV37SecFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
               AV36SecFunctionalityDescriptionOperator = AV33GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV10TFSecFunctionalityKey = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV11TFSecFunctionalityKey_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV12TFSecFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV13TFSecFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV40TFSecFunctionalityType_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFSecFunctionalityType_Sels.FromJSonString(AV40TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV15TFSecParentFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV16TFSecParentFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&SECPARENTFUNCTIONALITYID") == 0 )
            {
               AV38SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYKEYOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecFunctionalityKey = AV17SearchTxt;
         AV11TFSecFunctionalityKey_Sel = "";
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV38SecParentFunctionalityId;
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV35SecFunctionalityType;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV37SecFunctionalityDescription;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV41TFSecFunctionalityType_Sels;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV36SecFunctionalityDescriptionOperator ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A129SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004L2 */
         pr_default.execute(0, new Object[] {AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4L2 = false;
            A129SecParentFunctionalityId = P004L2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004L2_n129SecParentFunctionalityId[0];
            A130SecFunctionalityKey = P004L2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004L2_n130SecFunctionalityKey[0];
            A138SecParentFunctionalityDescription = P004L2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004L2_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004L2_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004L2_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P004L2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004L2_n135SecFunctionalityDescription[0];
            A128SecFunctionalityId = P004L2_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004L2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004L2_n138SecParentFunctionalityDescription[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004L2_A129SecParentFunctionalityId[0] == A129SecParentFunctionalityId ) && ( StringUtil.StrCmp(P004L2_A130SecFunctionalityKey[0], A130SecFunctionalityKey) == 0 ) )
            {
               BRK4L2 = false;
               A128SecFunctionalityId = P004L2_A128SecFunctionalityId[0];
               AV29count = (long)(AV29count+1);
               BRK4L2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV42SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A130SecFunctionalityKey)) ? "<#Empty#>" : A130SecFunctionalityKey);
               AV24OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")));
               AV22Options.Add(AV21Option, 0);
               AV25OptionsDesc.Add(AV24OptionDesc, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV42SkipItems = (short)(AV42SkipItems-1);
            }
            if ( ! BRK4L2 )
            {
               BRK4L2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecFunctionalityDescription = AV17SearchTxt;
         AV13TFSecFunctionalityDescription_Sel = "";
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV38SecParentFunctionalityId;
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV35SecFunctionalityType;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV37SecFunctionalityDescription;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV41TFSecFunctionalityType_Sels;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV36SecFunctionalityDescriptionOperator ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A129SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004L3 */
         pr_default.execute(1, new Object[] {AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4L4 = false;
            A129SecParentFunctionalityId = P004L3_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004L3_n129SecParentFunctionalityId[0];
            A135SecFunctionalityDescription = P004L3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004L3_n135SecFunctionalityDescription[0];
            A138SecParentFunctionalityDescription = P004L3_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004L3_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004L3_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004L3_n136SecFunctionalityType[0];
            A130SecFunctionalityKey = P004L3_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004L3_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P004L3_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004L3_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004L3_n138SecParentFunctionalityDescription[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P004L3_A129SecParentFunctionalityId[0] == A129SecParentFunctionalityId ) && ( StringUtil.StrCmp(P004L3_A135SecFunctionalityDescription[0], A135SecFunctionalityDescription) == 0 ) )
            {
               BRK4L4 = false;
               A128SecFunctionalityId = P004L3_A128SecFunctionalityId[0];
               AV29count = (long)(AV29count+1);
               BRK4L4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV42SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A135SecFunctionalityDescription)) ? "<#Empty#>" : A135SecFunctionalityDescription);
               AV22Options.Add(AV21Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV42SkipItems = (short)(AV42SkipItems-1);
            }
            if ( ! BRK4L4 )
            {
               BRK4L4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFSecParentFunctionalityDescription = AV17SearchTxt;
         AV16TFSecParentFunctionalityDescription_Sel = "";
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV38SecParentFunctionalityId;
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV35SecFunctionalityType;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV37SecFunctionalityDescription;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV41TFSecFunctionalityType_Sels;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV36SecFunctionalityDescriptionOperator ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A129SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004L4 */
         pr_default.execute(2, new Object[] {AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4L6 = false;
            A129SecParentFunctionalityId = P004L4_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004L4_n129SecParentFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004L4_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004L4_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004L4_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004L4_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P004L4_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004L4_n135SecFunctionalityDescription[0];
            A130SecFunctionalityKey = P004L4_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004L4_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P004L4_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004L4_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004L4_n138SecParentFunctionalityDescription[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P004L4_A129SecParentFunctionalityId[0] == A129SecParentFunctionalityId ) && ( StringUtil.StrCmp(P004L4_A138SecParentFunctionalityDescription[0], A138SecParentFunctionalityDescription) == 0 ) )
            {
               BRK4L6 = false;
               A128SecFunctionalityId = P004L4_A128SecFunctionalityId[0];
               AV29count = (long)(AV29count+1);
               BRK4L6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV42SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138SecParentFunctionalityDescription)) ? "<#Empty#>" : A138SecParentFunctionalityDescription);
               AV22Options.Add(AV21Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV42SkipItems = (short)(AV42SkipItems-1);
            }
            if ( ! BRK4L6 )
            {
               BRK4L6 = true;
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
         AV23OptionsJson = "";
         AV26OptionsDescJson = "";
         AV28OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV39WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV37SecFunctionalityDescription = "";
         AV10TFSecFunctionalityKey = "";
         AV11TFSecFunctionalityKey_Sel = "";
         AV12TFSecFunctionalityDescription = "";
         AV13TFSecFunctionalityDescription_Sel = "";
         AV40TFSecFunctionalityType_SelsJson = "";
         AV41TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV15TFSecParentFunctionalityDescription = "";
         AV16TFSecParentFunctionalityDescription_Sel = "";
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = "";
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = "";
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = "";
         lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P004L2_A129SecParentFunctionalityId = new long[1] ;
         P004L2_n129SecParentFunctionalityId = new bool[] {false} ;
         P004L2_A130SecFunctionalityKey = new string[] {""} ;
         P004L2_n130SecFunctionalityKey = new bool[] {false} ;
         P004L2_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004L2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004L2_A136SecFunctionalityType = new short[1] ;
         P004L2_n136SecFunctionalityType = new bool[] {false} ;
         P004L2_A135SecFunctionalityDescription = new string[] {""} ;
         P004L2_n135SecFunctionalityDescription = new bool[] {false} ;
         P004L2_A128SecFunctionalityId = new long[1] ;
         AV21Option = "";
         AV24OptionDesc = "";
         P004L3_A129SecParentFunctionalityId = new long[1] ;
         P004L3_n129SecParentFunctionalityId = new bool[] {false} ;
         P004L3_A135SecFunctionalityDescription = new string[] {""} ;
         P004L3_n135SecFunctionalityDescription = new bool[] {false} ;
         P004L3_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004L3_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004L3_A136SecFunctionalityType = new short[1] ;
         P004L3_n136SecFunctionalityType = new bool[] {false} ;
         P004L3_A130SecFunctionalityKey = new string[] {""} ;
         P004L3_n130SecFunctionalityKey = new bool[] {false} ;
         P004L3_A128SecFunctionalityId = new long[1] ;
         P004L4_A129SecParentFunctionalityId = new long[1] ;
         P004L4_n129SecParentFunctionalityId = new bool[] {false} ;
         P004L4_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004L4_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004L4_A136SecFunctionalityType = new short[1] ;
         P004L4_n136SecFunctionalityType = new bool[] {false} ;
         P004L4_A135SecFunctionalityDescription = new string[] {""} ;
         P004L4_n135SecFunctionalityDescription = new bool[] {false} ;
         P004L4_A130SecFunctionalityKey = new string[] {""} ;
         P004L4_n130SecFunctionalityKey = new bool[] {false} ;
         P004L4_A128SecFunctionalityId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004L2_A129SecParentFunctionalityId, P004L2_n129SecParentFunctionalityId, P004L2_A130SecFunctionalityKey, P004L2_n130SecFunctionalityKey, P004L2_A138SecParentFunctionalityDescription, P004L2_n138SecParentFunctionalityDescription, P004L2_A136SecFunctionalityType, P004L2_n136SecFunctionalityType, P004L2_A135SecFunctionalityDescription, P004L2_n135SecFunctionalityDescription,
               P004L2_A128SecFunctionalityId
               }
               , new Object[] {
               P004L3_A129SecParentFunctionalityId, P004L3_n129SecParentFunctionalityId, P004L3_A135SecFunctionalityDescription, P004L3_n135SecFunctionalityDescription, P004L3_A138SecParentFunctionalityDescription, P004L3_n138SecParentFunctionalityDescription, P004L3_A136SecFunctionalityType, P004L3_n136SecFunctionalityType, P004L3_A130SecFunctionalityKey, P004L3_n130SecFunctionalityKey,
               P004L3_A128SecFunctionalityId
               }
               , new Object[] {
               P004L4_A129SecParentFunctionalityId, P004L4_n129SecParentFunctionalityId, P004L4_A138SecParentFunctionalityDescription, P004L4_n138SecParentFunctionalityDescription, P004L4_A136SecFunctionalityType, P004L4_n136SecFunctionalityType, P004L4_A135SecFunctionalityDescription, P004L4_n135SecFunctionalityDescription, P004L4_A130SecFunctionalityKey, P004L4_n130SecFunctionalityKey,
               P004L4_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV44MaxItems ;
      private short AV43PageIndex ;
      private short AV42SkipItems ;
      private short AV35SecFunctionalityType ;
      private short AV36SecFunctionalityDescriptionOperator ;
      private short AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ;
      private short A136SecFunctionalityType ;
      private int AV48GXV1 ;
      private int AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ;
      private long AV38SecParentFunctionalityId ;
      private long AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long AV29count ;
      private bool returnInSub ;
      private bool BRK4L2 ;
      private bool n129SecParentFunctionalityId ;
      private bool n130SecFunctionalityKey ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool BRK4L4 ;
      private bool BRK4L6 ;
      private string AV23OptionsJson ;
      private string AV26OptionsDescJson ;
      private string AV28OptionIndexesJson ;
      private string AV40TFSecFunctionalityType_SelsJson ;
      private string AV19DDOName ;
      private string AV45SearchTxtParms ;
      private string AV18SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV46FilterFullText ;
      private string AV37SecFunctionalityDescription ;
      private string AV10TFSecFunctionalityKey ;
      private string AV11TFSecFunctionalityKey_Sel ;
      private string AV12TFSecFunctionalityDescription ;
      private string AV13TFSecFunctionalityDescription_Sel ;
      private string AV15TFSecParentFunctionalityDescription ;
      private string AV16TFSecParentFunctionalityDescription_Sel ;
      private string AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ;
      private string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ;
      private string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ;
      private string lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string AV21Option ;
      private string AV24OptionDesc ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV39WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<short> AV41TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P004L2_A129SecParentFunctionalityId ;
      private bool[] P004L2_n129SecParentFunctionalityId ;
      private string[] P004L2_A130SecFunctionalityKey ;
      private bool[] P004L2_n130SecFunctionalityKey ;
      private string[] P004L2_A138SecParentFunctionalityDescription ;
      private bool[] P004L2_n138SecParentFunctionalityDescription ;
      private short[] P004L2_A136SecFunctionalityType ;
      private bool[] P004L2_n136SecFunctionalityType ;
      private string[] P004L2_A135SecFunctionalityDescription ;
      private bool[] P004L2_n135SecFunctionalityDescription ;
      private long[] P004L2_A128SecFunctionalityId ;
      private long[] P004L3_A129SecParentFunctionalityId ;
      private bool[] P004L3_n129SecParentFunctionalityId ;
      private string[] P004L3_A135SecFunctionalityDescription ;
      private bool[] P004L3_n135SecFunctionalityDescription ;
      private string[] P004L3_A138SecParentFunctionalityDescription ;
      private bool[] P004L3_n138SecParentFunctionalityDescription ;
      private short[] P004L3_A136SecFunctionalityType ;
      private bool[] P004L3_n136SecFunctionalityType ;
      private string[] P004L3_A130SecFunctionalityKey ;
      private bool[] P004L3_n130SecFunctionalityKey ;
      private long[] P004L3_A128SecFunctionalityId ;
      private long[] P004L4_A129SecParentFunctionalityId ;
      private bool[] P004L4_n129SecParentFunctionalityId ;
      private string[] P004L4_A138SecParentFunctionalityDescription ;
      private bool[] P004L4_n138SecParentFunctionalityDescription ;
      private short[] P004L4_A136SecFunctionalityType ;
      private bool[] P004L4_n136SecFunctionalityType ;
      private string[] P004L4_A135SecFunctionalityDescription ;
      private bool[] P004L4_n135SecFunctionalityDescription ;
      private string[] P004L4_A130SecFunctionalityKey ;
      private bool[] P004L4_n130SecFunctionalityKey ;
      private long[] P004L4_A128SecFunctionalityId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secfunctionalityfilterparentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004L2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV36SecFunctionalityDescriptionOperator ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             long AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A129SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityKey, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityKey";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004L3( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV36SecFunctionalityDescriptionOperator ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             long AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A129SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityDescription, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityKey, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004L4( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV36SecFunctionalityDescriptionOperator ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             long AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A129SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T2.SecFunctionalityDescription";
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
                     return conditional_P004L2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 1 :
                     return conditional_P004L3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 2 :
                     return conditional_P004L4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
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
          Object[] prmP004L2;
          prmP004L2 = new Object[] {
          new ParDef("AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar",GXType.VarChar,100,0) ,
          new ParDef("AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar",GXType.VarChar,100,0)
          };
          Object[] prmP004L3;
          prmP004L3 = new Object[] {
          new ParDef("AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar",GXType.VarChar,100,0) ,
          new ParDef("AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar",GXType.VarChar,100,0)
          };
          Object[] prmP004L4;
          prmP004L4 = new Object[] {
          new ParDef("AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar",GXType.VarChar,100,0) ,
          new ParDef("AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004L4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
