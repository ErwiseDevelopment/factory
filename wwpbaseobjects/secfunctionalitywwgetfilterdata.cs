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
   public class secfunctionalitywwgetfilterdata : GXProcedure
   {
      public secfunctionalitywwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalitywwgetfilterdata( IGxContext context )
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
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
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
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
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
         AV43MaxItems = 10;
         AV42PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV41SkipItems = (short)(AV42PageIndex*AV43MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV38WWPContext) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
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
               AV39TFSecFunctionalityType_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV40TFSecFunctionalityType_Sels.FromJSonString(AV39TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV15TFSecParentFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV16TFSecParentFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYKEYOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecFunctionalityKey = AV17SearchTxt;
         AV11TFSecFunctionalityKey_Sel = "";
         AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV40TFSecFunctionalityType_Sels;
         AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004Q2 */
         pr_default.execute(0, new Object[] {lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4Q2 = false;
            A129SecParentFunctionalityId = P004Q2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004Q2_n129SecParentFunctionalityId[0];
            A130SecFunctionalityKey = P004Q2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004Q2_n130SecFunctionalityKey[0];
            A138SecParentFunctionalityDescription = P004Q2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004Q2_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004Q2_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004Q2_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P004Q2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004Q2_n135SecFunctionalityDescription[0];
            A128SecFunctionalityId = P004Q2_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004Q2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004Q2_n138SecParentFunctionalityDescription[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004Q2_A130SecFunctionalityKey[0], A130SecFunctionalityKey) == 0 ) )
            {
               BRK4Q2 = false;
               A128SecFunctionalityId = P004Q2_A128SecFunctionalityId[0];
               AV29count = (long)(AV29count+1);
               BRK4Q2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV41SkipItems) )
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
               AV41SkipItems = (short)(AV41SkipItems-1);
            }
            if ( ! BRK4Q2 )
            {
               BRK4Q2 = true;
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
         AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV40TFSecFunctionalityType_Sels;
         AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004Q3 */
         pr_default.execute(1, new Object[] {lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4Q4 = false;
            A129SecParentFunctionalityId = P004Q3_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004Q3_n129SecParentFunctionalityId[0];
            A135SecFunctionalityDescription = P004Q3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004Q3_n135SecFunctionalityDescription[0];
            A138SecParentFunctionalityDescription = P004Q3_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004Q3_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004Q3_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004Q3_n136SecFunctionalityType[0];
            A130SecFunctionalityKey = P004Q3_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004Q3_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P004Q3_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004Q3_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004Q3_n138SecParentFunctionalityDescription[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004Q3_A135SecFunctionalityDescription[0], A135SecFunctionalityDescription) == 0 ) )
            {
               BRK4Q4 = false;
               A128SecFunctionalityId = P004Q3_A128SecFunctionalityId[0];
               AV29count = (long)(AV29count+1);
               BRK4Q4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV41SkipItems) )
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
               AV41SkipItems = (short)(AV41SkipItems-1);
            }
            if ( ! BRK4Q4 )
            {
               BRK4Q4 = true;
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
         AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV40TFSecFunctionalityType_Sels;
         AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004Q4 */
         pr_default.execute(2, new Object[] {lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4Q6 = false;
            A129SecParentFunctionalityId = P004Q4_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004Q4_n129SecParentFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004Q4_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004Q4_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004Q4_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004Q4_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P004Q4_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004Q4_n135SecFunctionalityDescription[0];
            A130SecFunctionalityKey = P004Q4_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004Q4_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P004Q4_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004Q4_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004Q4_n138SecParentFunctionalityDescription[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004Q4_A138SecParentFunctionalityDescription[0], A138SecParentFunctionalityDescription) == 0 ) )
            {
               BRK4Q6 = false;
               A129SecParentFunctionalityId = P004Q4_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = P004Q4_n129SecParentFunctionalityId[0];
               A128SecFunctionalityId = P004Q4_A128SecFunctionalityId[0];
               AV29count = (long)(AV29count+1);
               BRK4Q6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV41SkipItems) )
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
               AV41SkipItems = (short)(AV41SkipItems-1);
            }
            if ( ! BRK4Q6 )
            {
               BRK4Q6 = true;
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
         AV38WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV10TFSecFunctionalityKey = "";
         AV11TFSecFunctionalityKey_Sel = "";
         AV12TFSecFunctionalityDescription = "";
         AV13TFSecFunctionalityDescription_Sel = "";
         AV39TFSecFunctionalityType_SelsJson = "";
         AV40TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV15TFSecParentFunctionalityDescription = "";
         AV16TFSecParentFunctionalityDescription_Sel = "";
         AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P004Q2_A129SecParentFunctionalityId = new long[1] ;
         P004Q2_n129SecParentFunctionalityId = new bool[] {false} ;
         P004Q2_A130SecFunctionalityKey = new string[] {""} ;
         P004Q2_n130SecFunctionalityKey = new bool[] {false} ;
         P004Q2_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004Q2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004Q2_A136SecFunctionalityType = new short[1] ;
         P004Q2_n136SecFunctionalityType = new bool[] {false} ;
         P004Q2_A135SecFunctionalityDescription = new string[] {""} ;
         P004Q2_n135SecFunctionalityDescription = new bool[] {false} ;
         P004Q2_A128SecFunctionalityId = new long[1] ;
         AV21Option = "";
         AV24OptionDesc = "";
         P004Q3_A129SecParentFunctionalityId = new long[1] ;
         P004Q3_n129SecParentFunctionalityId = new bool[] {false} ;
         P004Q3_A135SecFunctionalityDescription = new string[] {""} ;
         P004Q3_n135SecFunctionalityDescription = new bool[] {false} ;
         P004Q3_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004Q3_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004Q3_A136SecFunctionalityType = new short[1] ;
         P004Q3_n136SecFunctionalityType = new bool[] {false} ;
         P004Q3_A130SecFunctionalityKey = new string[] {""} ;
         P004Q3_n130SecFunctionalityKey = new bool[] {false} ;
         P004Q3_A128SecFunctionalityId = new long[1] ;
         P004Q4_A129SecParentFunctionalityId = new long[1] ;
         P004Q4_n129SecParentFunctionalityId = new bool[] {false} ;
         P004Q4_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004Q4_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004Q4_A136SecFunctionalityType = new short[1] ;
         P004Q4_n136SecFunctionalityType = new bool[] {false} ;
         P004Q4_A135SecFunctionalityDescription = new string[] {""} ;
         P004Q4_n135SecFunctionalityDescription = new bool[] {false} ;
         P004Q4_A130SecFunctionalityKey = new string[] {""} ;
         P004Q4_n130SecFunctionalityKey = new bool[] {false} ;
         P004Q4_A128SecFunctionalityId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalitywwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004Q2_A129SecParentFunctionalityId, P004Q2_n129SecParentFunctionalityId, P004Q2_A130SecFunctionalityKey, P004Q2_n130SecFunctionalityKey, P004Q2_A138SecParentFunctionalityDescription, P004Q2_n138SecParentFunctionalityDescription, P004Q2_A136SecFunctionalityType, P004Q2_n136SecFunctionalityType, P004Q2_A135SecFunctionalityDescription, P004Q2_n135SecFunctionalityDescription,
               P004Q2_A128SecFunctionalityId
               }
               , new Object[] {
               P004Q3_A129SecParentFunctionalityId, P004Q3_n129SecParentFunctionalityId, P004Q3_A135SecFunctionalityDescription, P004Q3_n135SecFunctionalityDescription, P004Q3_A138SecParentFunctionalityDescription, P004Q3_n138SecParentFunctionalityDescription, P004Q3_A136SecFunctionalityType, P004Q3_n136SecFunctionalityType, P004Q3_A130SecFunctionalityKey, P004Q3_n130SecFunctionalityKey,
               P004Q3_A128SecFunctionalityId
               }
               , new Object[] {
               P004Q4_A129SecParentFunctionalityId, P004Q4_n129SecParentFunctionalityId, P004Q4_A138SecParentFunctionalityDescription, P004Q4_n138SecParentFunctionalityDescription, P004Q4_A136SecFunctionalityType, P004Q4_n136SecFunctionalityType, P004Q4_A135SecFunctionalityDescription, P004Q4_n135SecFunctionalityDescription, P004Q4_A130SecFunctionalityKey, P004Q4_n130SecFunctionalityKey,
               P004Q4_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV43MaxItems ;
      private short AV42PageIndex ;
      private short AV41SkipItems ;
      private short A136SecFunctionalityType ;
      private int AV47GXV1 ;
      private int AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long AV29count ;
      private bool returnInSub ;
      private bool BRK4Q2 ;
      private bool n129SecParentFunctionalityId ;
      private bool n130SecFunctionalityKey ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool BRK4Q4 ;
      private bool BRK4Q6 ;
      private string AV23OptionsJson ;
      private string AV26OptionsDescJson ;
      private string AV28OptionIndexesJson ;
      private string AV39TFSecFunctionalityType_SelsJson ;
      private string AV19DDOName ;
      private string AV44SearchTxtParms ;
      private string AV18SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV45FilterFullText ;
      private string AV10TFSecFunctionalityKey ;
      private string AV11TFSecFunctionalityKey_Sel ;
      private string AV12TFSecFunctionalityDescription ;
      private string AV13TFSecFunctionalityDescription_Sel ;
      private string AV15TFSecParentFunctionalityDescription ;
      private string AV16TFSecParentFunctionalityDescription_Sel ;
      private string AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV38WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<short> AV40TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P004Q2_A129SecParentFunctionalityId ;
      private bool[] P004Q2_n129SecParentFunctionalityId ;
      private string[] P004Q2_A130SecFunctionalityKey ;
      private bool[] P004Q2_n130SecFunctionalityKey ;
      private string[] P004Q2_A138SecParentFunctionalityDescription ;
      private bool[] P004Q2_n138SecParentFunctionalityDescription ;
      private short[] P004Q2_A136SecFunctionalityType ;
      private bool[] P004Q2_n136SecFunctionalityType ;
      private string[] P004Q2_A135SecFunctionalityDescription ;
      private bool[] P004Q2_n135SecFunctionalityDescription ;
      private long[] P004Q2_A128SecFunctionalityId ;
      private long[] P004Q3_A129SecParentFunctionalityId ;
      private bool[] P004Q3_n129SecParentFunctionalityId ;
      private string[] P004Q3_A135SecFunctionalityDescription ;
      private bool[] P004Q3_n135SecFunctionalityDescription ;
      private string[] P004Q3_A138SecParentFunctionalityDescription ;
      private bool[] P004Q3_n138SecParentFunctionalityDescription ;
      private short[] P004Q3_A136SecFunctionalityType ;
      private bool[] P004Q3_n136SecFunctionalityType ;
      private string[] P004Q3_A130SecFunctionalityKey ;
      private bool[] P004Q3_n130SecFunctionalityKey ;
      private long[] P004Q3_A128SecFunctionalityId ;
      private long[] P004Q4_A129SecParentFunctionalityId ;
      private bool[] P004Q4_n129SecParentFunctionalityId ;
      private string[] P004Q4_A138SecParentFunctionalityDescription ;
      private bool[] P004Q4_n138SecParentFunctionalityDescription ;
      private short[] P004Q4_A136SecFunctionalityType ;
      private bool[] P004Q4_n136SecFunctionalityType ;
      private string[] P004Q4_A135SecFunctionalityDescription ;
      private bool[] P004Q4_n135SecFunctionalityDescription ;
      private string[] P004Q4_A130SecFunctionalityKey ;
      private bool[] P004Q4_n130SecFunctionalityKey ;
      private long[] P004Q4_A128SecFunctionalityId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secfunctionalitywwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Q2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityKey, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityKey";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004Q3( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityDescription, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityKey, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004Q4( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.SecFunctionalityDescription";
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
                     return conditional_P004Q2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P004Q3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P004Q4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP004Q2;
          prmP004Q2 = new Object[] {
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional",GXType.VarChar,100,0) ,
          new ParDef("AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional",GXType.VarChar,100,0)
          };
          Object[] prmP004Q3;
          prmP004Q3 = new Object[] {
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional",GXType.VarChar,100,0) ,
          new ParDef("AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional",GXType.VarChar,100,0)
          };
          Object[] prmP004Q4;
          prmP004Q4 = new Object[] {
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV51Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV52Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV53Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional",GXType.VarChar,100,0) ,
          new ParDef("AV56Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q4,100, GxCacheFrequency.OFF ,true,false )
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
