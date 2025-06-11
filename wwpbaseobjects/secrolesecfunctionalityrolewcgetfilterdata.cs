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
   public class secrolesecfunctionalityrolewcgetfilterdata : GXProcedure
   {
      public secrolesecfunctionalityrolewcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrolesecfunctionalityrolewcgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_SECFUNCTIONALITYKEY") == 0 )
         {
            /* Execute user subroutine: 'LOADSECFUNCTIONALITYKEYOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("WWPBaseObjects.SecRoleSecFunctionalityRoleWCGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecRoleSecFunctionalityRoleWCGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WWPBaseObjects.SecRoleSecFunctionalityRoleWCGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV39SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV11TFSecFunctionalityKey = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV12TFSecFunctionalityKey_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV13TFSecFunctionalityType_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV14TFSecFunctionalityType_Sels.FromJSonString(AV13TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV15TFSecParentFunctionalityDescription = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV16TFSecParentFunctionalityDescription_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&SECROLEID") == 0 )
            {
               AV51SecRoleId = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYKEYOPTIONS' Routine */
         returnInSub = false;
         AV11TFSecFunctionalityKey = AV17SearchTxt;
         AV12TFSecFunctionalityKey_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV14TFSecFunctionalityType_Sels ,
                                              AV53FilterFullText ,
                                              AV39SecFunctionalityType ,
                                              AV12TFSecFunctionalityKey_Sel ,
                                              AV11TFSecFunctionalityKey ,
                                              AV14TFSecFunctionalityType_Sels.Count ,
                                              AV16TFSecParentFunctionalityDescription_Sel ,
                                              AV15TFSecParentFunctionalityDescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV51SecRoleId ,
                                              A131SecRoleId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV11TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV11TFSecFunctionalityKey), "%", "");
         lV15TFSecParentFunctionalityDescription = StringUtil.Concat( StringUtil.RTrim( AV15TFSecParentFunctionalityDescription), "%", "");
         /* Using cursor P00562 */
         pr_default.execute(0, new Object[] {AV51SecRoleId, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, AV39SecFunctionalityType, lV11TFSecFunctionalityKey, AV12TFSecFunctionalityKey_Sel, lV15TFSecParentFunctionalityDescription, AV16TFSecParentFunctionalityDescription_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK562 = false;
            A128SecFunctionalityId = P00562_A128SecFunctionalityId[0];
            A129SecParentFunctionalityId = P00562_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P00562_n129SecParentFunctionalityId[0];
            A131SecRoleId = P00562_A131SecRoleId[0];
            A130SecFunctionalityKey = P00562_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P00562_n130SecFunctionalityKey[0];
            A138SecParentFunctionalityDescription = P00562_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00562_n138SecParentFunctionalityDescription[0];
            A135SecFunctionalityDescription = P00562_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00562_n135SecFunctionalityDescription[0];
            A136SecFunctionalityType = P00562_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P00562_n136SecFunctionalityType[0];
            A129SecParentFunctionalityId = P00562_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P00562_n129SecParentFunctionalityId[0];
            A130SecFunctionalityKey = P00562_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P00562_n130SecFunctionalityKey[0];
            A135SecFunctionalityDescription = P00562_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00562_n135SecFunctionalityDescription[0];
            A136SecFunctionalityType = P00562_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P00562_n136SecFunctionalityType[0];
            A138SecParentFunctionalityDescription = P00562_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00562_n138SecParentFunctionalityDescription[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00562_A131SecRoleId[0] == A131SecRoleId ) && ( StringUtil.StrCmp(P00562_A130SecFunctionalityKey[0], A130SecFunctionalityKey) == 0 ) )
            {
               BRK562 = false;
               A128SecFunctionalityId = P00562_A128SecFunctionalityId[0];
               AV27count = (long)(AV27count+1);
               BRK562 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A130SecFunctionalityKey)) ? "<#Empty#>" : A130SecFunctionalityKey);
               AV24OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")));
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
            if ( ! BRK562 )
            {
               BRK562 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFSecParentFunctionalityDescription = AV17SearchTxt;
         AV16TFSecParentFunctionalityDescription_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV14TFSecFunctionalityType_Sels ,
                                              AV53FilterFullText ,
                                              AV39SecFunctionalityType ,
                                              AV12TFSecFunctionalityKey_Sel ,
                                              AV11TFSecFunctionalityKey ,
                                              AV14TFSecFunctionalityType_Sels.Count ,
                                              AV16TFSecParentFunctionalityDescription_Sel ,
                                              AV15TFSecParentFunctionalityDescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV51SecRoleId ,
                                              A131SecRoleId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV53FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV53FilterFullText), "%", "");
         lV11TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV11TFSecFunctionalityKey), "%", "");
         lV15TFSecParentFunctionalityDescription = StringUtil.Concat( StringUtil.RTrim( AV15TFSecParentFunctionalityDescription), "%", "");
         /* Using cursor P00563 */
         pr_default.execute(1, new Object[] {AV51SecRoleId, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, lV53FilterFullText, AV39SecFunctionalityType, lV11TFSecFunctionalityKey, AV12TFSecFunctionalityKey_Sel, lV15TFSecParentFunctionalityDescription, AV16TFSecParentFunctionalityDescription_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK564 = false;
            A128SecFunctionalityId = P00563_A128SecFunctionalityId[0];
            A129SecParentFunctionalityId = P00563_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P00563_n129SecParentFunctionalityId[0];
            A131SecRoleId = P00563_A131SecRoleId[0];
            A138SecParentFunctionalityDescription = P00563_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00563_n138SecParentFunctionalityDescription[0];
            A135SecFunctionalityDescription = P00563_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00563_n135SecFunctionalityDescription[0];
            A136SecFunctionalityType = P00563_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P00563_n136SecFunctionalityType[0];
            A130SecFunctionalityKey = P00563_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P00563_n130SecFunctionalityKey[0];
            A129SecParentFunctionalityId = P00563_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P00563_n129SecParentFunctionalityId[0];
            A135SecFunctionalityDescription = P00563_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P00563_n135SecFunctionalityDescription[0];
            A136SecFunctionalityType = P00563_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P00563_n136SecFunctionalityType[0];
            A130SecFunctionalityKey = P00563_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P00563_n130SecFunctionalityKey[0];
            A138SecParentFunctionalityDescription = P00563_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P00563_n138SecParentFunctionalityDescription[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00563_A131SecRoleId[0] == A131SecRoleId ) && ( StringUtil.StrCmp(P00563_A138SecParentFunctionalityDescription[0], A138SecParentFunctionalityDescription) == 0 ) )
            {
               BRK564 = false;
               A128SecFunctionalityId = P00563_A128SecFunctionalityId[0];
               A129SecParentFunctionalityId = P00563_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = P00563_n129SecParentFunctionalityId[0];
               A129SecParentFunctionalityId = P00563_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = P00563_n129SecParentFunctionalityId[0];
               AV27count = (long)(AV27count+1);
               BRK564 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138SecParentFunctionalityDescription)) ? "<#Empty#>" : A138SecParentFunctionalityDescription);
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
            if ( ! BRK564 )
            {
               BRK564 = true;
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
         AV53FilterFullText = "";
         AV11TFSecFunctionalityKey = "";
         AV12TFSecFunctionalityKey_Sel = "";
         AV13TFSecFunctionalityType_SelsJson = "";
         AV14TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV15TFSecParentFunctionalityDescription = "";
         AV16TFSecParentFunctionalityDescription_Sel = "";
         lV53FilterFullText = "";
         lV11TFSecFunctionalityKey = "";
         lV15TFSecParentFunctionalityDescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P00562_A128SecFunctionalityId = new long[1] ;
         P00562_A129SecParentFunctionalityId = new long[1] ;
         P00562_n129SecParentFunctionalityId = new bool[] {false} ;
         P00562_A131SecRoleId = new short[1] ;
         P00562_A130SecFunctionalityKey = new string[] {""} ;
         P00562_n130SecFunctionalityKey = new bool[] {false} ;
         P00562_A138SecParentFunctionalityDescription = new string[] {""} ;
         P00562_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P00562_A135SecFunctionalityDescription = new string[] {""} ;
         P00562_n135SecFunctionalityDescription = new bool[] {false} ;
         P00562_A136SecFunctionalityType = new short[1] ;
         P00562_n136SecFunctionalityType = new bool[] {false} ;
         AV22Option = "";
         AV24OptionDesc = "";
         P00563_A128SecFunctionalityId = new long[1] ;
         P00563_A129SecParentFunctionalityId = new long[1] ;
         P00563_n129SecParentFunctionalityId = new bool[] {false} ;
         P00563_A131SecRoleId = new short[1] ;
         P00563_A138SecParentFunctionalityDescription = new string[] {""} ;
         P00563_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P00563_A135SecFunctionalityDescription = new string[] {""} ;
         P00563_n135SecFunctionalityDescription = new bool[] {false} ;
         P00563_A136SecFunctionalityType = new short[1] ;
         P00563_n136SecFunctionalityType = new bool[] {false} ;
         P00563_A130SecFunctionalityKey = new string[] {""} ;
         P00563_n130SecFunctionalityKey = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolesecfunctionalityrolewcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00562_A128SecFunctionalityId, P00562_A129SecParentFunctionalityId, P00562_n129SecParentFunctionalityId, P00562_A131SecRoleId, P00562_A130SecFunctionalityKey, P00562_n130SecFunctionalityKey, P00562_A138SecParentFunctionalityDescription, P00562_n138SecParentFunctionalityDescription, P00562_A135SecFunctionalityDescription, P00562_n135SecFunctionalityDescription,
               P00562_A136SecFunctionalityType, P00562_n136SecFunctionalityType
               }
               , new Object[] {
               P00563_A128SecFunctionalityId, P00563_A129SecParentFunctionalityId, P00563_n129SecParentFunctionalityId, P00563_A131SecRoleId, P00563_A138SecParentFunctionalityDescription, P00563_n138SecParentFunctionalityDescription, P00563_A135SecFunctionalityDescription, P00563_n135SecFunctionalityDescription, P00563_A136SecFunctionalityType, P00563_n136SecFunctionalityType,
               P00563_A130SecFunctionalityKey, P00563_n130SecFunctionalityKey
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV39SecFunctionalityType ;
      private short AV51SecRoleId ;
      private short A136SecFunctionalityType ;
      private short A131SecRoleId ;
      private int AV54GXV1 ;
      private int AV14TFSecFunctionalityType_Sels_Count ;
      private long A128SecFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long AV27count ;
      private bool returnInSub ;
      private bool BRK562 ;
      private bool n129SecParentFunctionalityId ;
      private bool n130SecFunctionalityKey ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n135SecFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool BRK564 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV13TFSecFunctionalityType_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV53FilterFullText ;
      private string AV11TFSecFunctionalityKey ;
      private string AV12TFSecFunctionalityKey_Sel ;
      private string AV15TFSecParentFunctionalityDescription ;
      private string AV16TFSecParentFunctionalityDescription_Sel ;
      private string lV53FilterFullText ;
      private string lV11TFSecFunctionalityKey ;
      private string lV15TFSecParentFunctionalityDescription ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
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
      private GxSimpleCollection<short> AV14TFSecFunctionalityType_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00562_A128SecFunctionalityId ;
      private long[] P00562_A129SecParentFunctionalityId ;
      private bool[] P00562_n129SecParentFunctionalityId ;
      private short[] P00562_A131SecRoleId ;
      private string[] P00562_A130SecFunctionalityKey ;
      private bool[] P00562_n130SecFunctionalityKey ;
      private string[] P00562_A138SecParentFunctionalityDescription ;
      private bool[] P00562_n138SecParentFunctionalityDescription ;
      private string[] P00562_A135SecFunctionalityDescription ;
      private bool[] P00562_n135SecFunctionalityDescription ;
      private short[] P00562_A136SecFunctionalityType ;
      private bool[] P00562_n136SecFunctionalityType ;
      private long[] P00563_A128SecFunctionalityId ;
      private long[] P00563_A129SecParentFunctionalityId ;
      private bool[] P00563_n129SecParentFunctionalityId ;
      private short[] P00563_A131SecRoleId ;
      private string[] P00563_A138SecParentFunctionalityDescription ;
      private bool[] P00563_n138SecParentFunctionalityDescription ;
      private string[] P00563_A135SecFunctionalityDescription ;
      private bool[] P00563_n135SecFunctionalityDescription ;
      private short[] P00563_A136SecFunctionalityType ;
      private bool[] P00563_n136SecFunctionalityType ;
      private string[] P00563_A130SecFunctionalityKey ;
      private bool[] P00563_n130SecFunctionalityKey ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secrolesecfunctionalityrolewcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00562( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV14TFSecFunctionalityType_Sels ,
                                             string AV53FilterFullText ,
                                             short AV39SecFunctionalityType ,
                                             string AV12TFSecFunctionalityKey_Sel ,
                                             string AV11TFSecFunctionalityKey ,
                                             int AV14TFSecFunctionalityType_Sels_Count ,
                                             string AV16TFSecParentFunctionalityDescription_Sel ,
                                             string AV15TFSecParentFunctionalityDescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV51SecRoleId ,
                                             short A131SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecFunctionalityId, T2.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecRoleId, T2.SecFunctionalityKey, T3.SecFunctionalityDescription AS SecParentFunctionalityDescription, T2.SecFunctionalityDescription, T2.SecFunctionalityType FROM ((SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) LEFT JOIN SecFunctionality T3 ON T3.SecFunctionalityId = T2.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV51SecRoleId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityKey like '%' || :lV53FilterFullText) or ( 'mode' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV53FilterFullText) or ( T3.SecFunctionalityDescription like '%' || :lV53FilterFullText))");
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
         if ( ! (0==AV39SecFunctionalityType) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityType = :AV39SecFunctionalityType)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecFunctionalityKey)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey like :lV11TFSecFunctionalityKey)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV12TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey = ( :AV12TFSecFunctionalityKey_Sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityKey))=0))");
         }
         if ( AV14TFSecFunctionalityType_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14TFSecFunctionalityType_Sels, "T2.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSecParentFunctionalityDescription)) ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription like :lV15TFSecParentFunctionalityDescription)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ! ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription = ( :AV16TFSecParentFunctionalityDescription_Sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecRoleId, T2.SecFunctionalityKey";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00563( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV14TFSecFunctionalityType_Sels ,
                                             string AV53FilterFullText ,
                                             short AV39SecFunctionalityType ,
                                             string AV12TFSecFunctionalityKey_Sel ,
                                             string AV11TFSecFunctionalityKey ,
                                             int AV14TFSecFunctionalityType_Sels_Count ,
                                             string AV16TFSecParentFunctionalityDescription_Sel ,
                                             string AV15TFSecParentFunctionalityDescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV51SecRoleId ,
                                             short A131SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecFunctionalityId, T2.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecRoleId, T3.SecFunctionalityDescription AS SecParentFunctionalityDescription, T2.SecFunctionalityDescription, T2.SecFunctionalityType, T2.SecFunctionalityKey FROM ((SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) LEFT JOIN SecFunctionality T3 ON T3.SecFunctionalityId = T2.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV51SecRoleId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityKey like '%' || :lV53FilterFullText) or ( 'mode' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV53FilterFullText) and T2.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV53FilterFullText) or ( T3.SecFunctionalityDescription like '%' || :lV53FilterFullText))");
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
         if ( ! (0==AV39SecFunctionalityType) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityType = :AV39SecFunctionalityType)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecFunctionalityKey)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey like :lV11TFSecFunctionalityKey)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV12TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityKey = ( :AV12TFSecFunctionalityKey_Sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityKey))=0))");
         }
         if ( AV14TFSecFunctionalityType_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14TFSecFunctionalityType_Sels, "T2.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSecParentFunctionalityDescription)) ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription like :lV15TFSecParentFunctionalityDescription)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ! ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecFunctionalityDescription = ( :AV16TFSecParentFunctionalityDescription_Sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecRoleId, T3.SecFunctionalityDescription";
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
                     return conditional_P00562(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
               case 1 :
                     return conditional_P00563(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP00562;
          prmP00562 = new Object[] {
          new ParDef("AV51SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV39SecFunctionalityType",GXType.Int16,2,0) ,
          new ParDef("lV11TFSecFunctionalityKey",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSecFunctionalityKey_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSecParentFunctionalityDescription",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSecParentFunctionalityDescription_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00563;
          prmP00563 = new Object[] {
          new ParDef("AV51SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV53FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV39SecFunctionalityType",GXType.Int16,2,0) ,
          new ParDef("lV11TFSecFunctionalityKey",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSecFunctionalityKey_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSecParentFunctionalityDescription",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSecParentFunctionalityDescription_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00562", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00562,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00563", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00563,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((short[]) buf[10])[0] = rslt.getShort(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
