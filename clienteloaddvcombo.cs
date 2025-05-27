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
   public class clienteloaddvcombo : GXProcedure
   {
      public clienteloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienteloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_ClienteId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ClienteId = aP3_ClienteId;
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
                                int aP3_ClienteId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ClienteId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_ClienteId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ClienteId = aP3_ClienteId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "MunicipioCodigo") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MUNICIPIOCODIGO' */
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
         /* 'LOADCOMBOITEMS_MUNICIPIOCODIGO' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A187MunicipioNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P006J2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A187MunicipioNome = P006J2_A187MunicipioNome[0];
               n187MunicipioNome = P006J2_n187MunicipioNome[0];
               A186MunicipioCodigo = P006J2_A186MunicipioCodigo[0];
               n186MunicipioCodigo = P006J2_n186MunicipioCodigo[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = A186MunicipioCodigo;
               AV15Combo_DataItem.gxTpr_Title = A187MunicipioNome;
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
                  /* Using cursor P006J3 */
                  pr_default.execute(1, new Object[] {AV19ClienteId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A168ClienteId = P006J3_A168ClienteId[0];
                     A186MunicipioCodigo = P006J3_A186MunicipioCodigo[0];
                     n186MunicipioCodigo = P006J3_n186MunicipioCodigo[0];
                     A187MunicipioNome = P006J3_A187MunicipioNome[0];
                     n187MunicipioNome = P006J3_n187MunicipioNome[0];
                     A187MunicipioNome = P006J3_A187MunicipioNome[0];
                     n187MunicipioNome = P006J3_n187MunicipioNome[0];
                     AV21SelectedValue = A186MunicipioCodigo;
                     AV22SelectedText = A187MunicipioNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27MunicipioCodigo = AV13SearchTxt;
                  /* Using cursor P006J4 */
                  pr_default.execute(2, new Object[] {AV27MunicipioCodigo});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A186MunicipioCodigo = P006J4_A186MunicipioCodigo[0];
                     n186MunicipioCodigo = P006J4_n186MunicipioCodigo[0];
                     A187MunicipioNome = P006J4_A187MunicipioNome[0];
                     n187MunicipioNome = P006J4_n187MunicipioNome[0];
                     AV22SelectedText = A187MunicipioNome;
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
         A187MunicipioNome = "";
         P006J2_A187MunicipioNome = new string[] {""} ;
         P006J2_n187MunicipioNome = new bool[] {false} ;
         P006J2_A186MunicipioCodigo = new string[] {""} ;
         P006J2_n186MunicipioCodigo = new bool[] {false} ;
         A186MunicipioCodigo = "";
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006J3_A168ClienteId = new int[1] ;
         P006J3_A186MunicipioCodigo = new string[] {""} ;
         P006J3_n186MunicipioCodigo = new bool[] {false} ;
         P006J3_A187MunicipioNome = new string[] {""} ;
         P006J3_n187MunicipioNome = new bool[] {false} ;
         AV27MunicipioCodigo = "";
         P006J4_A186MunicipioCodigo = new string[] {""} ;
         P006J4_n186MunicipioCodigo = new bool[] {false} ;
         P006J4_A187MunicipioNome = new string[] {""} ;
         P006J4_n187MunicipioNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienteloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006J2_A187MunicipioNome, P006J2_n187MunicipioNome, P006J2_A186MunicipioCodigo
               }
               , new Object[] {
               P006J3_A168ClienteId, P006J3_A186MunicipioCodigo, P006J3_n186MunicipioCodigo, P006J3_A187MunicipioNome, P006J3_n187MunicipioNome
               }
               , new Object[] {
               P006J4_A186MunicipioCodigo, P006J4_A187MunicipioNome, P006J4_n187MunicipioNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19ClienteId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A168ClienteId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n187MunicipioNome ;
      private bool n186MunicipioCodigo ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A187MunicipioNome ;
      private string A186MunicipioCodigo ;
      private string AV27MunicipioCodigo ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P006J2_A187MunicipioNome ;
      private bool[] P006J2_n187MunicipioNome ;
      private string[] P006J2_A186MunicipioCodigo ;
      private bool[] P006J2_n186MunicipioCodigo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P006J3_A168ClienteId ;
      private string[] P006J3_A186MunicipioCodigo ;
      private bool[] P006J3_n186MunicipioCodigo ;
      private string[] P006J3_A187MunicipioNome ;
      private bool[] P006J3_n187MunicipioNome ;
      private string[] P006J4_A186MunicipioCodigo ;
      private bool[] P006J4_n186MunicipioCodigo ;
      private string[] P006J4_A187MunicipioNome ;
      private bool[] P006J4_n187MunicipioNome ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class clienteloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006J2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A187MunicipioNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " MunicipioNome, MunicipioCodigo";
         sFromString = " FROM Municipio";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(MunicipioNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY MunicipioNome, MunicipioCodigo";
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
                     return conditional_P006J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP006J3;
          prmP006J3 = new Object[] {
          new ParDef("AV19ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP006J4;
          prmP006J4 = new Object[] {
          new ParDef("AV27MunicipioCodigo",GXType.VarChar,40,0)
          };
          Object[] prmP006J2;
          prmP006J2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J3", "SELECT T1.ClienteId, T1.MunicipioCodigo, T2.MunicipioNome FROM (Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) WHERE T1.ClienteId = :AV19ClienteId ORDER BY T1.ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J4", "SELECT MunicipioCodigo, MunicipioNome FROM Municipio WHERE MunicipioCodigo = ( :AV27MunicipioCodigo) ORDER BY MunicipioCodigo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
