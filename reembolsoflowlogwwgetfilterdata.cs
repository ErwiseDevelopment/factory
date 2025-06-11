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
   public class reembolsoflowlogwwgetfilterdata : GXProcedure
   {
      public reembolsoflowlogwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoflowlogwwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_LOGWORKFLOWCONVENIODESC") == 0 )
         {
            /* Execute user subroutine: 'LOADLOGWORKFLOWCONVENIODESCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("ReembolsoFlowLogWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ReembolsoFlowLogWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("ReembolsoFlowLogWWGridState"), null, "", "");
         }
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV37GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC") == 0 )
            {
               AV10TFLogWorkflowConvenioDesc = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV11TFLogWorkflowConvenioDesc_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOFLOWLOGDATE") == 0 )
            {
               AV12TFReembolsoFlowLogDate = context.localUtil.CToT( AV28GridStateFilterValue.gxTpr_Value, 4);
               AV13TFReembolsoFlowLogDate_To = context.localUtil.CToT( AV28GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PARM_&REEMBOLSOLOGID") == 0 )
            {
               AV36ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLOGWORKFLOWCONVENIODESCOPTIONS' Routine */
         returnInSub = false;
         AV10TFLogWorkflowConvenioDesc = AV14SearchTxt;
         AV11TFLogWorkflowConvenioDesc_Sel = "";
         AV39Reembolsoflowlogwwds_1_reembolsologid = AV36ReembolsoLogId;
         AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV10TFLogWorkflowConvenioDesc;
         AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV11TFLogWorkflowConvenioDesc_Sel;
         AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV12TFReembolsoFlowLogDate;
         AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV13TFReembolsoFlowLogDate_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ,
                                              AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ,
                                              AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ,
                                              AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ,
                                              A752LogWorkflowConvenioDesc ,
                                              A747ReembolsoFlowLogDate ,
                                              AV39Reembolsoflowlogwwds_1_reembolsologid ,
                                              A748ReembolsoLogId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc), "%", "");
         /* Using cursor P00CT2 */
         pr_default.execute(0, new Object[] {AV39Reembolsoflowlogwwds_1_reembolsologid, lV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc, AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate, AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCT2 = false;
            A748ReembolsoLogId = P00CT2_A748ReembolsoLogId[0];
            n748ReembolsoLogId = P00CT2_n748ReembolsoLogId[0];
            A750LogWorkflowConvenioId = P00CT2_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = P00CT2_n750LogWorkflowConvenioId[0];
            A747ReembolsoFlowLogDate = P00CT2_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = P00CT2_n747ReembolsoFlowLogDate[0];
            A752LogWorkflowConvenioDesc = P00CT2_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CT2_n752LogWorkflowConvenioDesc[0];
            A746ReembolsoFlowLogId = P00CT2_A746ReembolsoFlowLogId[0];
            A752LogWorkflowConvenioDesc = P00CT2_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CT2_n752LogWorkflowConvenioDesc[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00CT2_A748ReembolsoLogId[0] == A748ReembolsoLogId ) && ( P00CT2_A750LogWorkflowConvenioId[0] == A750LogWorkflowConvenioId ) )
            {
               BRKCT2 = false;
               A746ReembolsoFlowLogId = P00CT2_A746ReembolsoFlowLogId[0];
               AV24count = (long)(AV24count+1);
               BRKCT2 = true;
               pr_default.readNext(0);
            }
            AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A752LogWorkflowConvenioDesc)) ? "<#Empty#>" : A752LogWorkflowConvenioDesc);
            AV18InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV19Option, "<#Empty#>") != 0 ) && ( AV18InsertIndex <= AV20Options.Count ) && ( ( StringUtil.StrCmp(((string)AV20Options.Item(AV18InsertIndex)), AV19Option) < 0 ) || ( StringUtil.StrCmp(((string)AV20Options.Item(AV18InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV18InsertIndex = (int)(AV18InsertIndex+1);
            }
            AV20Options.Add(AV19Option, AV18InsertIndex);
            AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), AV18InsertIndex);
            if ( AV20Options.Count == AV15SkipItems + 11 )
            {
               AV20Options.RemoveItem(AV20Options.Count);
               AV23OptionIndexes.RemoveItem(AV23OptionIndexes.Count);
            }
            if ( ! BRKCT2 )
            {
               BRKCT2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV15SkipItems > 0 )
         {
            AV20Options.RemoveItem(1);
            AV23OptionIndexes.RemoveItem(1);
            AV15SkipItems = (short)(AV15SkipItems-1);
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFLogWorkflowConvenioDesc = "";
         AV11TFLogWorkflowConvenioDesc_Sel = "";
         AV12TFReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         AV13TFReembolsoFlowLogDate_To = (DateTime)(DateTime.MinValue);
         AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = "";
         AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = "";
         AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = (DateTime)(DateTime.MinValue);
         AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = (DateTime)(DateTime.MinValue);
         lV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = "";
         A752LogWorkflowConvenioDesc = "";
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         P00CT2_A748ReembolsoLogId = new int[1] ;
         P00CT2_n748ReembolsoLogId = new bool[] {false} ;
         P00CT2_A750LogWorkflowConvenioId = new int[1] ;
         P00CT2_n750LogWorkflowConvenioId = new bool[] {false} ;
         P00CT2_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CT2_n747ReembolsoFlowLogDate = new bool[] {false} ;
         P00CT2_A752LogWorkflowConvenioDesc = new string[] {""} ;
         P00CT2_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         P00CT2_A746ReembolsoFlowLogId = new int[1] ;
         AV19Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoflowlogwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CT2_A748ReembolsoLogId, P00CT2_n748ReembolsoLogId, P00CT2_A750LogWorkflowConvenioId, P00CT2_n750LogWorkflowConvenioId, P00CT2_A747ReembolsoFlowLogDate, P00CT2_n747ReembolsoFlowLogDate, P00CT2_A752LogWorkflowConvenioDesc, P00CT2_n752LogWorkflowConvenioDesc, P00CT2_A746ReembolsoFlowLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV37GXV1 ;
      private int AV36ReembolsoLogId ;
      private int AV39Reembolsoflowlogwwds_1_reembolsologid ;
      private int A748ReembolsoLogId ;
      private int A750LogWorkflowConvenioId ;
      private int A746ReembolsoFlowLogId ;
      private int AV18InsertIndex ;
      private long AV24count ;
      private DateTime AV12TFReembolsoFlowLogDate ;
      private DateTime AV13TFReembolsoFlowLogDate_To ;
      private DateTime AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ;
      private DateTime AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ;
      private DateTime A747ReembolsoFlowLogDate ;
      private bool returnInSub ;
      private bool BRKCT2 ;
      private bool n748ReembolsoLogId ;
      private bool n750LogWorkflowConvenioId ;
      private bool n747ReembolsoFlowLogDate ;
      private bool n752LogWorkflowConvenioDesc ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV10TFLogWorkflowConvenioDesc ;
      private string AV11TFLogWorkflowConvenioDesc_Sel ;
      private string AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ;
      private string AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ;
      private string lV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ;
      private string A752LogWorkflowConvenioDesc ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00CT2_A748ReembolsoLogId ;
      private bool[] P00CT2_n748ReembolsoLogId ;
      private int[] P00CT2_A750LogWorkflowConvenioId ;
      private bool[] P00CT2_n750LogWorkflowConvenioId ;
      private DateTime[] P00CT2_A747ReembolsoFlowLogDate ;
      private bool[] P00CT2_n747ReembolsoFlowLogDate ;
      private string[] P00CT2_A752LogWorkflowConvenioDesc ;
      private bool[] P00CT2_n752LogWorkflowConvenioDesc ;
      private int[] P00CT2_A746ReembolsoFlowLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class reembolsoflowlogwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CT2( IGxContext context ,
                                             string AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ,
                                             string AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ,
                                             DateTime AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ,
                                             DateTime AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ,
                                             string A752LogWorkflowConvenioDesc ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             int AV39Reembolsoflowlogwwds_1_reembolsologid ,
                                             int A748ReembolsoLogId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ReembolsoLogId, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T1.ReembolsoFlowLogDate, T2.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T1.ReembolsoFlowLogId FROM (ReembolsoFlowLog T1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         AddWhere(sWhereString, "(T1.ReembolsoLogId = :AV39Reembolsoflowlogwwds_1_reembolsologid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ReembolsoLogId, T1.LogWorkflowConvenioId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CT2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CT2;
          prmP00CT2 = new Object[] {
          new ParDef("AV39Reembolsoflowlogwwds_1_reembolsologid",GXType.Int32,9,0) ,
          new ParDef("lV40Reembolsoflowlogwwds_2_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV41Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV42Reembolsoflowlogwwds_4_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV43Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00CT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
