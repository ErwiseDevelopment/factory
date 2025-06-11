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
   public class secfunctionalitysecfunctionalityrolewcgetfilterdata : GXProcedure
   {
      public secfunctionalitysecfunctionalityrolewcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalitysecfunctionalityrolewcgetfilterdata( IGxContext context )
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
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
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
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
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
         AV36MaxItems = 10;
         AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
         AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV33WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECROLENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECROLENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECROLEDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADSECROLEDESCRIPTIONOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV27Session.Get("WWPBaseObjects.SecFunctionalitySecFunctionalityRoleWCGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalitySecFunctionalityRoleWCGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WWPBaseObjects.SecFunctionalitySecFunctionalityRoleWCGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV10TFSecRoleName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV11TFSecRoleName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV12TFSecRoleDescription = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV13TFSecRoleDescription_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "PARM_&SECFUNCTIONALITYID") == 0 )
            {
               AV32SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECROLENAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecRoleName = AV14SearchTxt;
         AV11TFSecRoleName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV38FilterFullText ,
                                              AV11TFSecRoleName_Sel ,
                                              AV10TFSecRoleName ,
                                              AV13TFSecRoleDescription_Sel ,
                                              AV12TFSecRoleDescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV32SecFunctionalityId ,
                                              A128SecFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV10TFSecRoleName = StringUtil.Concat( StringUtil.RTrim( AV10TFSecRoleName), "%", "");
         lV12TFSecRoleDescription = StringUtil.Concat( StringUtil.RTrim( AV12TFSecRoleDescription), "%", "");
         /* Using cursor P004N2 */
         pr_default.execute(0, new Object[] {AV32SecFunctionalityId, lV38FilterFullText, lV38FilterFullText, lV10TFSecRoleName, AV11TFSecRoleName_Sel, lV12TFSecRoleDescription, AV13TFSecRoleDescription_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4N2 = false;
            A131SecRoleId = P004N2_A131SecRoleId[0];
            A128SecFunctionalityId = P004N2_A128SecFunctionalityId[0];
            A140SecRoleName = P004N2_A140SecRoleName[0];
            A139SecRoleDescription = P004N2_A139SecRoleDescription[0];
            A140SecRoleName = P004N2_A140SecRoleName[0];
            A139SecRoleDescription = P004N2_A139SecRoleDescription[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004N2_A128SecFunctionalityId[0] == A128SecFunctionalityId ) && ( StringUtil.StrCmp(P004N2_A140SecRoleName[0], A140SecRoleName) == 0 ) )
            {
               BRK4N2 = false;
               A131SecRoleId = P004N2_A131SecRoleId[0];
               AV26count = (long)(AV26count+1);
               BRK4N2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV34SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A140SecRoleName)) ? "<#Empty#>" : A140SecRoleName);
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
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK4N2 )
            {
               BRK4N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECROLEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecRoleDescription = AV14SearchTxt;
         AV13TFSecRoleDescription_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV38FilterFullText ,
                                              AV11TFSecRoleName_Sel ,
                                              AV10TFSecRoleName ,
                                              AV13TFSecRoleDescription_Sel ,
                                              AV12TFSecRoleDescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV32SecFunctionalityId ,
                                              A128SecFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV10TFSecRoleName = StringUtil.Concat( StringUtil.RTrim( AV10TFSecRoleName), "%", "");
         lV12TFSecRoleDescription = StringUtil.Concat( StringUtil.RTrim( AV12TFSecRoleDescription), "%", "");
         /* Using cursor P004N3 */
         pr_default.execute(1, new Object[] {AV32SecFunctionalityId, lV38FilterFullText, lV38FilterFullText, lV10TFSecRoleName, AV11TFSecRoleName_Sel, lV12TFSecRoleDescription, AV13TFSecRoleDescription_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4N4 = false;
            A131SecRoleId = P004N3_A131SecRoleId[0];
            A128SecFunctionalityId = P004N3_A128SecFunctionalityId[0];
            A139SecRoleDescription = P004N3_A139SecRoleDescription[0];
            A140SecRoleName = P004N3_A140SecRoleName[0];
            A139SecRoleDescription = P004N3_A139SecRoleDescription[0];
            A140SecRoleName = P004N3_A140SecRoleName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P004N3_A128SecFunctionalityId[0] == A128SecFunctionalityId ) && ( StringUtil.StrCmp(P004N3_A139SecRoleDescription[0], A139SecRoleDescription) == 0 ) )
            {
               BRK4N4 = false;
               A131SecRoleId = P004N3_A131SecRoleId[0];
               AV26count = (long)(AV26count+1);
               BRK4N4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV34SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A139SecRoleDescription)) ? "<#Empty#>" : A139SecRoleDescription);
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
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK4N4 )
            {
               BRK4N4 = true;
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
         AV20OptionsJson = "";
         AV23OptionsDescJson = "";
         AV25OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV33WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV10TFSecRoleName = "";
         AV11TFSecRoleName_Sel = "";
         AV12TFSecRoleDescription = "";
         AV13TFSecRoleDescription_Sel = "";
         lV38FilterFullText = "";
         lV10TFSecRoleName = "";
         lV12TFSecRoleDescription = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         P004N2_A131SecRoleId = new short[1] ;
         P004N2_A128SecFunctionalityId = new long[1] ;
         P004N2_A140SecRoleName = new string[] {""} ;
         P004N2_A139SecRoleDescription = new string[] {""} ;
         AV18Option = "";
         P004N3_A131SecRoleId = new short[1] ;
         P004N3_A128SecFunctionalityId = new long[1] ;
         P004N3_A139SecRoleDescription = new string[] {""} ;
         P004N3_A140SecRoleName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalitysecfunctionalityrolewcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004N2_A131SecRoleId, P004N2_A128SecFunctionalityId, P004N2_A140SecRoleName, P004N2_A139SecRoleDescription
               }
               , new Object[] {
               P004N3_A131SecRoleId, P004N3_A128SecFunctionalityId, P004N3_A139SecRoleDescription, P004N3_A140SecRoleName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short A131SecRoleId ;
      private int AV40GXV1 ;
      private long AV32SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long AV26count ;
      private bool returnInSub ;
      private bool BRK4N2 ;
      private bool BRK4N4 ;
      private string AV20OptionsJson ;
      private string AV23OptionsDescJson ;
      private string AV25OptionIndexesJson ;
      private string AV16DDOName ;
      private string AV37SearchTxtParms ;
      private string AV15SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV38FilterFullText ;
      private string AV10TFSecRoleName ;
      private string AV11TFSecRoleName_Sel ;
      private string AV12TFSecRoleDescription ;
      private string AV13TFSecRoleDescription_Sel ;
      private string lV38FilterFullText ;
      private string lV10TFSecRoleName ;
      private string lV12TFSecRoleDescription ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string AV18Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV33WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P004N2_A131SecRoleId ;
      private long[] P004N2_A128SecFunctionalityId ;
      private string[] P004N2_A140SecRoleName ;
      private string[] P004N2_A139SecRoleDescription ;
      private short[] P004N3_A131SecRoleId ;
      private long[] P004N3_A128SecFunctionalityId ;
      private string[] P004N3_A139SecRoleDescription ;
      private string[] P004N3_A140SecRoleName ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secfunctionalitysecfunctionalityrolewcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004N2( IGxContext context ,
                                             string AV38FilterFullText ,
                                             string AV11TFSecRoleName_Sel ,
                                             string AV10TFSecRoleName ,
                                             string AV13TFSecRoleDescription_Sel ,
                                             string AV12TFSecRoleDescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             long AV32SecFunctionalityId ,
                                             long A128SecFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SecRoleId, T1.SecFunctionalityId, T2.SecRoleName, T2.SecRoleDescription FROM (SecFunctionalityRole T1 INNER JOIN SecRole T2 ON T2.SecRoleId = T1.SecRoleId)";
         AddWhere(sWhereString, "(T1.SecFunctionalityId = :AV32SecFunctionalityId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T2.SecRoleName like '%' || :lV38FilterFullText) or ( T2.SecRoleDescription like '%' || :lV38FilterFullText))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecRoleName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFSecRoleName)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV10TFSecRoleName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecRoleName_Sel)) && ! ( StringUtil.StrCmp(AV11TFSecRoleName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName = ( :AV11TFSecRoleName_Sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFSecRoleName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecRoleDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecRoleDescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription like :lV12TFSecRoleDescription)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecRoleDescription_Sel)) && ! ( StringUtil.StrCmp(AV13TFSecRoleDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription = ( :AV13TFSecRoleDescription_Sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFSecRoleDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityId, T2.SecRoleName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004N3( IGxContext context ,
                                             string AV38FilterFullText ,
                                             string AV11TFSecRoleName_Sel ,
                                             string AV10TFSecRoleName ,
                                             string AV13TFSecRoleDescription_Sel ,
                                             string AV12TFSecRoleDescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             long AV32SecFunctionalityId ,
                                             long A128SecFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecRoleId, T1.SecFunctionalityId, T2.SecRoleDescription, T2.SecRoleName FROM (SecFunctionalityRole T1 INNER JOIN SecRole T2 ON T2.SecRoleId = T1.SecRoleId)";
         AddWhere(sWhereString, "(T1.SecFunctionalityId = :AV32SecFunctionalityId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T2.SecRoleName like '%' || :lV38FilterFullText) or ( T2.SecRoleDescription like '%' || :lV38FilterFullText))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecRoleName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFSecRoleName)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV10TFSecRoleName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecRoleName_Sel)) && ! ( StringUtil.StrCmp(AV11TFSecRoleName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName = ( :AV11TFSecRoleName_Sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFSecRoleName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecRoleDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSecRoleDescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription like :lV12TFSecRoleDescription)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSecRoleDescription_Sel)) && ! ( StringUtil.StrCmp(AV13TFSecRoleDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription = ( :AV13TFSecRoleDescription_Sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFSecRoleDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityId, T2.SecRoleDescription";
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
                     return conditional_P004N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
               case 1 :
                     return conditional_P004N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmP004N2;
          prmP004N2 = new Object[] {
          new ParDef("AV32SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFSecRoleName",GXType.VarChar,40,0) ,
          new ParDef("AV11TFSecRoleName_Sel",GXType.VarChar,40,0) ,
          new ParDef("lV12TFSecRoleDescription",GXType.VarChar,120,0) ,
          new ParDef("AV13TFSecRoleDescription_Sel",GXType.VarChar,120,0)
          };
          Object[] prmP004N3;
          prmP004N3 = new Object[] {
          new ParDef("AV32SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFSecRoleName",GXType.VarChar,40,0) ,
          new ParDef("AV11TFSecRoleName_Sel",GXType.VarChar,40,0) ,
          new ParDef("lV12TFSecRoleDescription",GXType.VarChar,120,0) ,
          new ParDef("AV13TFSecRoleDescription_Sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004N3,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
