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
   public class serasaprotestosloaddvcombo : GXProcedure
   {
      public serasaprotestosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaprotestosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_SerasaProtestosId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19SerasaProtestosId = aP3_SerasaProtestosId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_SerasaProtestosId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_SerasaProtestosId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_SerasaProtestosId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19SerasaProtestosId = aP3_SerasaProtestosId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 10;
         AV12PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV20SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? AV20SearchTxtParms : StringUtil.Substring( AV20SearchTxtParms, 3, -1));
         AV11SkipItems = (short)(AV12PageIndex*AV10MaxItems);
         if ( StringUtil.StrCmp(AV16ComboName, "SerasaId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SERASAID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_SERASAID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A663SerasaNumeroProposta } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00CX2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A663SerasaNumeroProposta = P00CX2_A663SerasaNumeroProposta[0];
               n663SerasaNumeroProposta = P00CX2_n663SerasaNumeroProposta[0];
               A662SerasaId = P00CX2_A662SerasaId[0];
               n662SerasaId = P00CX2_n662SerasaId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A662SerasaId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A663SerasaNumeroProposta;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00CX3 */
                  pr_default.execute(1, new Object[] {AV19SerasaProtestosId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A711SerasaProtestosId = P00CX3_A711SerasaProtestosId[0];
                     A662SerasaId = P00CX3_A662SerasaId[0];
                     n662SerasaId = P00CX3_n662SerasaId[0];
                     A663SerasaNumeroProposta = P00CX3_A663SerasaNumeroProposta[0];
                     n663SerasaNumeroProposta = P00CX3_n663SerasaNumeroProposta[0];
                     A663SerasaNumeroProposta = P00CX3_A663SerasaNumeroProposta[0];
                     n663SerasaNumeroProposta = P00CX3_n663SerasaNumeroProposta[0];
                     AV21SelectedValue = ((0==A662SerasaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A662SerasaId), 9, 0)));
                     AV22SelectedText = A663SerasaNumeroProposta;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27SerasaId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00CX4 */
                  pr_default.execute(2, new Object[] {AV27SerasaId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A662SerasaId = P00CX4_A662SerasaId[0];
                     n662SerasaId = P00CX4_n662SerasaId[0];
                     A663SerasaNumeroProposta = P00CX4_A663SerasaNumeroProposta[0];
                     n663SerasaNumeroProposta = P00CX4_n663SerasaNumeroProposta[0];
                     AV22SelectedText = A663SerasaNumeroProposta;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
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
         AV21SelectedValue = "";
         AV22SelectedText = "";
         AV23Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SearchTxt = "";
         lV13SearchTxt = "";
         A663SerasaNumeroProposta = "";
         P00CX2_A663SerasaNumeroProposta = new string[] {""} ;
         P00CX2_n663SerasaNumeroProposta = new bool[] {false} ;
         P00CX2_A662SerasaId = new int[1] ;
         P00CX2_n662SerasaId = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00CX3_A711SerasaProtestosId = new int[1] ;
         P00CX3_A662SerasaId = new int[1] ;
         P00CX3_n662SerasaId = new bool[] {false} ;
         P00CX3_A663SerasaNumeroProposta = new string[] {""} ;
         P00CX3_n663SerasaNumeroProposta = new bool[] {false} ;
         P00CX4_A662SerasaId = new int[1] ;
         P00CX4_n662SerasaId = new bool[] {false} ;
         P00CX4_A663SerasaNumeroProposta = new string[] {""} ;
         P00CX4_n663SerasaNumeroProposta = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaprotestosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00CX2_A663SerasaNumeroProposta, P00CX2_n663SerasaNumeroProposta, P00CX2_A662SerasaId
               }
               , new Object[] {
               P00CX3_A711SerasaProtestosId, P00CX3_A662SerasaId, P00CX3_n662SerasaId, P00CX3_A663SerasaNumeroProposta, P00CX3_n663SerasaNumeroProposta
               }
               , new Object[] {
               P00CX4_A662SerasaId, P00CX4_A663SerasaNumeroProposta, P00CX4_n663SerasaNumeroProposta
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19SerasaProtestosId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A662SerasaId ;
      private int A711SerasaProtestosId ;
      private int AV27SerasaId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n663SerasaNumeroProposta ;
      private bool n662SerasaId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A663SerasaNumeroProposta ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00CX2_A663SerasaNumeroProposta ;
      private bool[] P00CX2_n663SerasaNumeroProposta ;
      private int[] P00CX2_A662SerasaId ;
      private bool[] P00CX2_n662SerasaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00CX3_A711SerasaProtestosId ;
      private int[] P00CX3_A662SerasaId ;
      private bool[] P00CX3_n662SerasaId ;
      private string[] P00CX3_A663SerasaNumeroProposta ;
      private bool[] P00CX3_n663SerasaNumeroProposta ;
      private int[] P00CX4_A662SerasaId ;
      private bool[] P00CX4_n662SerasaId ;
      private string[] P00CX4_A663SerasaNumeroProposta ;
      private bool[] P00CX4_n663SerasaNumeroProposta ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class serasaprotestosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CX2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A663SerasaNumeroProposta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SerasaNumeroProposta, SerasaId";
         sFromString = " FROM Serasa";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(SerasaNumeroProposta like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY SerasaNumeroProposta, SerasaId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
                     return conditional_P00CX2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00CX3;
          prmP00CX3 = new Object[] {
          new ParDef("AV19SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmP00CX4;
          prmP00CX4 = new Object[] {
          new ParDef("AV27SerasaId",GXType.Int32,9,0)
          };
          Object[] prmP00CX2;
          prmP00CX2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CX2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CX3", "SELECT T1.SerasaProtestosId, T1.SerasaId, T2.SerasaNumeroProposta FROM (SerasaProtestos T1 LEFT JOIN Serasa T2 ON T2.SerasaId = T1.SerasaId) WHERE T1.SerasaProtestosId = :AV19SerasaProtestosId ORDER BY T1.SerasaProtestosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CX3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CX4", "SELECT SerasaId, SerasaNumeroProposta FROM Serasa WHERE SerasaId = :AV27SerasaId ORDER BY SerasaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CX4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
