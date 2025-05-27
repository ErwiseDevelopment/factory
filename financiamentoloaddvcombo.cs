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
   public class financiamentoloaddvcombo : GXProcedure
   {
      public financiamentoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamentoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_FinanciamentoId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19FinanciamentoId = aP3_FinanciamentoId;
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
                                int aP3_FinanciamentoId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_FinanciamentoId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_FinanciamentoId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19FinanciamentoId = aP3_FinanciamentoId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "ClienteId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLIENTEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "IntermediadorClienteId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_INTERMEDIADORCLIENTEID' */
            S121 ();
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
         /* 'LOADCOMBOITEMS_CLIENTEID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A169ClienteDocumento } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00772 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A169ClienteDocumento = P00772_A169ClienteDocumento[0];
               n169ClienteDocumento = P00772_n169ClienteDocumento[0];
               A168ClienteId = P00772_A168ClienteId[0];
               n168ClienteId = P00772_n168ClienteId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A169ClienteDocumento;
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
                  /* Using cursor P00773 */
                  pr_default.execute(1, new Object[] {AV19FinanciamentoId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A223FinanciamentoId = P00773_A223FinanciamentoId[0];
                     A168ClienteId = P00773_A168ClienteId[0];
                     n168ClienteId = P00773_n168ClienteId[0];
                     A169ClienteDocumento = P00773_A169ClienteDocumento[0];
                     n169ClienteDocumento = P00773_n169ClienteDocumento[0];
                     A169ClienteDocumento = P00773_A169ClienteDocumento[0];
                     n169ClienteDocumento = P00773_n169ClienteDocumento[0];
                     AV21SelectedValue = ((0==A168ClienteId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0)));
                     AV22SelectedText = A169ClienteDocumento;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27ClienteId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00774 */
                  pr_default.execute(2, new Object[] {AV27ClienteId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A168ClienteId = P00774_A168ClienteId[0];
                     n168ClienteId = P00774_n168ClienteId[0];
                     A169ClienteDocumento = P00774_A169ClienteDocumento[0];
                     n169ClienteDocumento = P00774_n169ClienteDocumento[0];
                     AV22SelectedText = A169ClienteDocumento;
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

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_INTERMEDIADORCLIENTEID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A169ClienteDocumento } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00775 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A169ClienteDocumento = P00775_A169ClienteDocumento[0];
               n169ClienteDocumento = P00775_n169ClienteDocumento[0];
               A168ClienteId = P00775_A168ClienteId[0];
               n168ClienteId = P00775_n168ClienteId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A169ClienteDocumento;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00776 */
                  pr_default.execute(4, new Object[] {AV19FinanciamentoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A223FinanciamentoId = P00776_A223FinanciamentoId[0];
                     A220IntermediadorClienteId = P00776_A220IntermediadorClienteId[0];
                     n220IntermediadorClienteId = P00776_n220IntermediadorClienteId[0];
                     AV21SelectedValue = ((0==A220IntermediadorClienteId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A220IntermediadorClienteId), 9, 0)));
                     AV27ClienteId = A220IntermediadorClienteId;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV27ClienteId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00777 */
               pr_default.execute(5, new Object[] {AV27ClienteId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A168ClienteId = P00777_A168ClienteId[0];
                  n168ClienteId = P00777_n168ClienteId[0];
                  A169ClienteDocumento = P00777_A169ClienteDocumento[0];
                  n169ClienteDocumento = P00777_n169ClienteDocumento[0];
                  AV22SelectedText = A169ClienteDocumento;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
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
         A169ClienteDocumento = "";
         P00772_A169ClienteDocumento = new string[] {""} ;
         P00772_n169ClienteDocumento = new bool[] {false} ;
         P00772_A168ClienteId = new int[1] ;
         P00772_n168ClienteId = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00773_A223FinanciamentoId = new int[1] ;
         P00773_A168ClienteId = new int[1] ;
         P00773_n168ClienteId = new bool[] {false} ;
         P00773_A169ClienteDocumento = new string[] {""} ;
         P00773_n169ClienteDocumento = new bool[] {false} ;
         P00774_A168ClienteId = new int[1] ;
         P00774_n168ClienteId = new bool[] {false} ;
         P00774_A169ClienteDocumento = new string[] {""} ;
         P00774_n169ClienteDocumento = new bool[] {false} ;
         P00775_A169ClienteDocumento = new string[] {""} ;
         P00775_n169ClienteDocumento = new bool[] {false} ;
         P00775_A168ClienteId = new int[1] ;
         P00775_n168ClienteId = new bool[] {false} ;
         P00776_A223FinanciamentoId = new int[1] ;
         P00776_A220IntermediadorClienteId = new int[1] ;
         P00776_n220IntermediadorClienteId = new bool[] {false} ;
         P00777_A168ClienteId = new int[1] ;
         P00777_n168ClienteId = new bool[] {false} ;
         P00777_A169ClienteDocumento = new string[] {""} ;
         P00777_n169ClienteDocumento = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamentoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00772_A169ClienteDocumento, P00772_n169ClienteDocumento, P00772_A168ClienteId
               }
               , new Object[] {
               P00773_A223FinanciamentoId, P00773_A168ClienteId, P00773_n168ClienteId, P00773_A169ClienteDocumento, P00773_n169ClienteDocumento
               }
               , new Object[] {
               P00774_A168ClienteId, P00774_A169ClienteDocumento, P00774_n169ClienteDocumento
               }
               , new Object[] {
               P00775_A169ClienteDocumento, P00775_n169ClienteDocumento, P00775_A168ClienteId
               }
               , new Object[] {
               P00776_A223FinanciamentoId, P00776_A220IntermediadorClienteId, P00776_n220IntermediadorClienteId
               }
               , new Object[] {
               P00777_A168ClienteId, P00777_A169ClienteDocumento, P00777_n169ClienteDocumento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19FinanciamentoId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A168ClienteId ;
      private int A223FinanciamentoId ;
      private int AV27ClienteId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A220IntermediadorClienteId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n169ClienteDocumento ;
      private bool n168ClienteId ;
      private bool n220IntermediadorClienteId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A169ClienteDocumento ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00772_A169ClienteDocumento ;
      private bool[] P00772_n169ClienteDocumento ;
      private int[] P00772_A168ClienteId ;
      private bool[] P00772_n168ClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00773_A223FinanciamentoId ;
      private int[] P00773_A168ClienteId ;
      private bool[] P00773_n168ClienteId ;
      private string[] P00773_A169ClienteDocumento ;
      private bool[] P00773_n169ClienteDocumento ;
      private int[] P00774_A168ClienteId ;
      private bool[] P00774_n168ClienteId ;
      private string[] P00774_A169ClienteDocumento ;
      private bool[] P00774_n169ClienteDocumento ;
      private string[] P00775_A169ClienteDocumento ;
      private bool[] P00775_n169ClienteDocumento ;
      private int[] P00775_A168ClienteId ;
      private bool[] P00775_n168ClienteId ;
      private int[] P00776_A223FinanciamentoId ;
      private int[] P00776_A220IntermediadorClienteId ;
      private bool[] P00776_n220IntermediadorClienteId ;
      private int[] P00777_A168ClienteId ;
      private bool[] P00777_n168ClienteId ;
      private string[] P00777_A169ClienteDocumento ;
      private bool[] P00777_n169ClienteDocumento ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class financiamentoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00772( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A169ClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ClienteDocumento, ClienteId";
         sFromString = " FROM Cliente";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ClienteDocumento";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00775( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A169ClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ClienteDocumento, ClienteId";
         sFromString = " FROM Cliente";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY ClienteDocumento";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
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
                     return conditional_P00772(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00775(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00773;
          prmP00773 = new Object[] {
          new ParDef("AV19FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmP00774;
          prmP00774 = new Object[] {
          new ParDef("AV27ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00776;
          prmP00776 = new Object[] {
          new ParDef("AV19FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmP00777;
          prmP00777 = new Object[] {
          new ParDef("AV27ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00772;
          prmP00772 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00775;
          prmP00775 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00772", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00772,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00773", "SELECT T1.FinanciamentoId, T1.ClienteId, T2.ClienteDocumento FROM (Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) WHERE T1.FinanciamentoId = :AV19FinanciamentoId ORDER BY T1.FinanciamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00773,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00774", "SELECT ClienteId, ClienteDocumento FROM Cliente WHERE ClienteId = :AV27ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00774,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00775", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00775,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00776", "SELECT FinanciamentoId, IntermediadorClienteId FROM Financiamento WHERE FinanciamentoId = :AV19FinanciamentoId ORDER BY FinanciamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00776,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00777", "SELECT ClienteId, ClienteDocumento FROM Cliente WHERE ClienteId = :AV27ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00777,1, GxCacheFrequency.OFF ,false,true )
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
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
