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
   public class wcassinaturasgetfilterdata : GXProcedure
   {
      public wcassinaturasgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcassinaturasgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CONTRATONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTRATONOMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV27Session.Get("WcAssinaturasGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcAssinaturasGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WcAssinaturasGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV10TFContratoNome = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV11TFContratoNome_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAINICIAL") == 0 )
            {
               AV12TFContratoDataInicial = context.localUtil.CToD( AV30GridStateFilterValue.gxTpr_Value, 4);
               AV13TFContratoDataInicial_To = context.localUtil.CToD( AV30GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFASSINATURASTATUS_SEL") == 0 )
            {
               AV14TFAssinaturaStatus_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV15TFAssinaturaStatus_Sels.FromJSonString(AV14TFAssinaturaStatus_SelsJson, null);
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCONTRATONOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFContratoNome = AV16SearchTxt;
         AV11TFContratoNome_Sel = "";
         AV41Wcassinaturasds_1_tfcontratonome = AV10TFContratoNome;
         AV42Wcassinaturasds_2_tfcontratonome_sel = AV11TFContratoNome_Sel;
         AV43Wcassinaturasds_3_tfcontratodatainicial = AV12TFContratoDataInicial;
         AV44Wcassinaturasds_4_tfcontratodatainicial_to = AV13TFContratoDataInicial_To;
         AV45Wcassinaturasds_5_tfassinaturastatus_sels = AV15TFAssinaturaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A239AssinaturaStatus ,
                                              AV45Wcassinaturasds_5_tfassinaturastatus_sels ,
                                              AV42Wcassinaturasds_2_tfcontratonome_sel ,
                                              AV41Wcassinaturasds_1_tfcontratonome ,
                                              AV43Wcassinaturasds_3_tfcontratodatainicial ,
                                              AV44Wcassinaturasds_4_tfcontratodatainicial_to ,
                                              AV45Wcassinaturasds_5_tfassinaturastatus_sels.Count ,
                                              A228ContratoNome ,
                                              A362ContratoDataInicial ,
                                              AV38DataInicial } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV41Wcassinaturasds_1_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV41Wcassinaturasds_1_tfcontratonome), "%", "");
         /* Using cursor P00912 */
         pr_default.execute(0, new Object[] {AV38DataInicial, lV41Wcassinaturasds_1_tfcontratonome, AV42Wcassinaturasds_2_tfcontratonome_sel, AV43Wcassinaturasds_3_tfcontratodatainicial, AV44Wcassinaturasds_4_tfcontratodatainicial_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK912 = false;
            A227ContratoId = P00912_A227ContratoId[0];
            n227ContratoId = P00912_n227ContratoId[0];
            A239AssinaturaStatus = P00912_A239AssinaturaStatus[0];
            n239AssinaturaStatus = P00912_n239AssinaturaStatus[0];
            A362ContratoDataInicial = P00912_A362ContratoDataInicial[0];
            n362ContratoDataInicial = P00912_n362ContratoDataInicial[0];
            A228ContratoNome = P00912_A228ContratoNome[0];
            n228ContratoNome = P00912_n228ContratoNome[0];
            A238AssinaturaId = P00912_A238AssinaturaId[0];
            A362ContratoDataInicial = P00912_A362ContratoDataInicial[0];
            n362ContratoDataInicial = P00912_n362ContratoDataInicial[0];
            A228ContratoNome = P00912_A228ContratoNome[0];
            n228ContratoNome = P00912_n228ContratoNome[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00912_A227ContratoId[0] == A227ContratoId ) )
            {
               BRK912 = false;
               A238AssinaturaId = P00912_A238AssinaturaId[0];
               AV26count = (long)(AV26count+1);
               BRK912 = true;
               pr_default.readNext(0);
            }
            AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? "<#Empty#>" : A228ContratoNome);
            AV20InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV21Option, "<#Empty#>") != 0 ) && ( AV20InsertIndex <= AV22Options.Count ) && ( ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), AV21Option) < 0 ) || ( StringUtil.StrCmp(((string)AV22Options.Item(AV20InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV20InsertIndex = (int)(AV20InsertIndex+1);
            }
            AV22Options.Add(AV21Option, AV20InsertIndex);
            AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), AV20InsertIndex);
            if ( AV22Options.Count == AV17SkipItems + 11 )
            {
               AV22Options.RemoveItem(AV22Options.Count);
               AV25OptionIndexes.RemoveItem(AV25OptionIndexes.Count);
            }
            if ( ! BRK912 )
            {
               BRK912 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV17SkipItems > 0 )
         {
            AV22Options.RemoveItem(1);
            AV25OptionIndexes.RemoveItem(1);
            AV17SkipItems = (short)(AV17SkipItems-1);
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
         AV10TFContratoNome = "";
         AV11TFContratoNome_Sel = "";
         AV12TFContratoDataInicial = DateTime.MinValue;
         AV13TFContratoDataInicial_To = DateTime.MinValue;
         AV14TFAssinaturaStatus_SelsJson = "";
         AV15TFAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV41Wcassinaturasds_1_tfcontratonome = "";
         AV42Wcassinaturasds_2_tfcontratonome_sel = "";
         AV43Wcassinaturasds_3_tfcontratodatainicial = DateTime.MinValue;
         AV44Wcassinaturasds_4_tfcontratodatainicial_to = DateTime.MinValue;
         AV45Wcassinaturasds_5_tfassinaturastatus_sels = new GxSimpleCollection<string>();
         lV41Wcassinaturasds_1_tfcontratonome = "";
         A239AssinaturaStatus = "";
         A228ContratoNome = "";
         A362ContratoDataInicial = DateTime.MinValue;
         AV38DataInicial = DateTime.MinValue;
         P00912_A227ContratoId = new int[1] ;
         P00912_n227ContratoId = new bool[] {false} ;
         P00912_A239AssinaturaStatus = new string[] {""} ;
         P00912_n239AssinaturaStatus = new bool[] {false} ;
         P00912_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         P00912_n362ContratoDataInicial = new bool[] {false} ;
         P00912_A228ContratoNome = new string[] {""} ;
         P00912_n228ContratoNome = new bool[] {false} ;
         P00912_A238AssinaturaId = new long[1] ;
         AV21Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcassinaturasgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00912_A227ContratoId, P00912_n227ContratoId, P00912_A239AssinaturaStatus, P00912_n239AssinaturaStatus, P00912_A362ContratoDataInicial, P00912_n362ContratoDataInicial, P00912_A228ContratoNome, P00912_n228ContratoNome, P00912_A238AssinaturaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private int AV39GXV1 ;
      private int AV45Wcassinaturasds_5_tfassinaturastatus_sels_Count ;
      private int A227ContratoId ;
      private int AV20InsertIndex ;
      private long A238AssinaturaId ;
      private long AV26count ;
      private DateTime AV12TFContratoDataInicial ;
      private DateTime AV13TFContratoDataInicial_To ;
      private DateTime AV43Wcassinaturasds_3_tfcontratodatainicial ;
      private DateTime AV44Wcassinaturasds_4_tfcontratodatainicial_to ;
      private DateTime A362ContratoDataInicial ;
      private DateTime AV38DataInicial ;
      private bool returnInSub ;
      private bool BRK912 ;
      private bool n227ContratoId ;
      private bool n239AssinaturaStatus ;
      private bool n362ContratoDataInicial ;
      private bool n228ContratoNome ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV14TFAssinaturaStatus_SelsJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV10TFContratoNome ;
      private string AV11TFContratoNome_Sel ;
      private string AV41Wcassinaturasds_1_tfcontratonome ;
      private string AV42Wcassinaturasds_2_tfcontratonome_sel ;
      private string lV41Wcassinaturasds_1_tfcontratonome ;
      private string A239AssinaturaStatus ;
      private string A228ContratoNome ;
      private string AV21Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GxSimpleCollection<string> AV15TFAssinaturaStatus_Sels ;
      private GxSimpleCollection<string> AV45Wcassinaturasds_5_tfassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00912_A227ContratoId ;
      private bool[] P00912_n227ContratoId ;
      private string[] P00912_A239AssinaturaStatus ;
      private bool[] P00912_n239AssinaturaStatus ;
      private DateTime[] P00912_A362ContratoDataInicial ;
      private bool[] P00912_n362ContratoDataInicial ;
      private string[] P00912_A228ContratoNome ;
      private bool[] P00912_n228ContratoNome ;
      private long[] P00912_A238AssinaturaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcassinaturasgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00912( IGxContext context ,
                                             string A239AssinaturaStatus ,
                                             GxSimpleCollection<string> AV45Wcassinaturasds_5_tfassinaturastatus_sels ,
                                             string AV42Wcassinaturasds_2_tfcontratonome_sel ,
                                             string AV41Wcassinaturasds_1_tfcontratonome ,
                                             DateTime AV43Wcassinaturasds_3_tfcontratodatainicial ,
                                             DateTime AV44Wcassinaturasds_4_tfcontratodatainicial_to ,
                                             int AV45Wcassinaturasds_5_tfassinaturastatus_sels_Count ,
                                             string A228ContratoNome ,
                                             DateTime A362ContratoDataInicial ,
                                             DateTime AV38DataInicial )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.AssinaturaStatus, T2.ContratoDataInicial, T2.ContratoNome, T1.AssinaturaId FROM (Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId)";
         AddWhere(sWhereString, "(T2.ContratoDataInicial >= :AV38DataInicial)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Wcassinaturasds_2_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wcassinaturasds_1_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV41Wcassinaturasds_1_tfcontratonome)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wcassinaturasds_2_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV42Wcassinaturasds_2_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV42Wcassinaturasds_2_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV42Wcassinaturasds_2_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV43Wcassinaturasds_3_tfcontratodatainicial) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial >= :AV43Wcassinaturasds_3_tfcontratodatainicial)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV44Wcassinaturasds_4_tfcontratodatainicial_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial <= :AV44Wcassinaturasds_4_tfcontratodatainicial_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV45Wcassinaturasds_5_tfassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV45Wcassinaturasds_5_tfassinaturastatus_sels, "T1.AssinaturaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoId";
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
                     return conditional_P00912(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] );
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
          Object[] prmP00912;
          prmP00912 = new Object[] {
          new ParDef("AV38DataInicial",GXType.Date,8,0) ,
          new ParDef("lV41Wcassinaturasds_1_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV42Wcassinaturasds_2_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV43Wcassinaturasds_3_tfcontratodatainicial",GXType.Date,8,0) ,
          new ParDef("AV44Wcassinaturasds_4_tfcontratodatainicial_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00912", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00912,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
