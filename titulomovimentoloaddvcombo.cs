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
   public class titulomovimentoloaddvcombo : GXProcedure
   {
      public titulomovimentoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulomovimentoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_TituloMovimentoId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19TituloMovimentoId = aP3_TituloMovimentoId;
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
                                int aP3_TituloMovimentoId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_TituloMovimentoId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_TituloMovimentoId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19TituloMovimentoId = aP3_TituloMovimentoId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "TipoPagamentoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPOPAGAMENTOID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "TituloId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TITULOID' */
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
         /* 'LOADCOMBOITEMS_TIPOPAGAMENTOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A289TipoPagamentoNome } ,
                                                 new int[]{
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P007J2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A289TipoPagamentoNome = P007J2_A289TipoPagamentoNome[0];
               A288TipoPagamentoId = P007J2_A288TipoPagamentoId[0];
               n288TipoPagamentoId = P007J2_n288TipoPagamentoId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A288TipoPagamentoId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A289TipoPagamentoNome;
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
                  /* Using cursor P007J3 */
                  pr_default.execute(1, new Object[] {AV19TituloMovimentoId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A270TituloMovimentoId = P007J3_A270TituloMovimentoId[0];
                     A288TipoPagamentoId = P007J3_A288TipoPagamentoId[0];
                     n288TipoPagamentoId = P007J3_n288TipoPagamentoId[0];
                     A289TipoPagamentoNome = P007J3_A289TipoPagamentoNome[0];
                     A289TipoPagamentoNome = P007J3_A289TipoPagamentoNome[0];
                     AV21SelectedValue = ((0==A288TipoPagamentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A288TipoPagamentoId), 9, 0)));
                     AV22SelectedText = A289TipoPagamentoNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P007J4 */
                  pr_default.execute(2, new Object[] {AV27TipoPagamentoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A288TipoPagamentoId = P007J4_A288TipoPagamentoId[0];
                     n288TipoPagamentoId = P007J4_n288TipoPagamentoId[0];
                     A289TipoPagamentoNome = P007J4_A289TipoPagamentoNome[0];
                     AV22SelectedText = A289TipoPagamentoNome;
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
         /* 'LOADCOMBOITEMS_TITULOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A262TituloValor } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P007J5 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A262TituloValor = P007J5_A262TituloValor[0];
               n262TituloValor = P007J5_n262TituloValor[0];
               A261TituloId = P007J5_A261TituloId[0];
               n261TituloId = P007J5_n261TituloId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A261TituloId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
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
                  /* Using cursor P007J6 */
                  pr_default.execute(4, new Object[] {AV19TituloMovimentoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A270TituloMovimentoId = P007J6_A270TituloMovimentoId[0];
                     A261TituloId = P007J6_A261TituloId[0];
                     n261TituloId = P007J6_n261TituloId[0];
                     A262TituloValor = P007J6_A262TituloValor[0];
                     n262TituloValor = P007J6_n262TituloValor[0];
                     A262TituloValor = P007J6_A262TituloValor[0];
                     n262TituloValor = P007J6_n262TituloValor[0];
                     AV21SelectedValue = ((0==A261TituloId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A261TituloId), 9, 0)));
                     AV22SelectedText = ((Convert.ToDecimal(0)==A262TituloValor) ? "" : StringUtil.Trim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28TituloId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P007J7 */
                  pr_default.execute(5, new Object[] {AV28TituloId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A261TituloId = P007J7_A261TituloId[0];
                     n261TituloId = P007J7_n261TituloId[0];
                     A262TituloValor = P007J7_A262TituloValor[0];
                     n262TituloValor = P007J7_n262TituloValor[0];
                     AV22SelectedText = StringUtil.Trim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
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
         A289TipoPagamentoNome = "";
         P007J2_A289TipoPagamentoNome = new string[] {""} ;
         P007J2_A288TipoPagamentoId = new int[1] ;
         P007J2_n288TipoPagamentoId = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P007J3_A270TituloMovimentoId = new int[1] ;
         P007J3_A288TipoPagamentoId = new int[1] ;
         P007J3_n288TipoPagamentoId = new bool[] {false} ;
         P007J3_A289TipoPagamentoNome = new string[] {""} ;
         P007J4_A288TipoPagamentoId = new int[1] ;
         P007J4_n288TipoPagamentoId = new bool[] {false} ;
         P007J4_A289TipoPagamentoNome = new string[] {""} ;
         P007J5_A262TituloValor = new decimal[1] ;
         P007J5_n262TituloValor = new bool[] {false} ;
         P007J5_A261TituloId = new int[1] ;
         P007J5_n261TituloId = new bool[] {false} ;
         P007J6_A270TituloMovimentoId = new int[1] ;
         P007J6_A261TituloId = new int[1] ;
         P007J6_n261TituloId = new bool[] {false} ;
         P007J6_A262TituloValor = new decimal[1] ;
         P007J6_n262TituloValor = new bool[] {false} ;
         P007J7_A261TituloId = new int[1] ;
         P007J7_n261TituloId = new bool[] {false} ;
         P007J7_A262TituloValor = new decimal[1] ;
         P007J7_n262TituloValor = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulomovimentoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007J2_A289TipoPagamentoNome, P007J2_A288TipoPagamentoId
               }
               , new Object[] {
               P007J3_A270TituloMovimentoId, P007J3_A288TipoPagamentoId, P007J3_n288TipoPagamentoId, P007J3_A289TipoPagamentoNome
               }
               , new Object[] {
               P007J4_A288TipoPagamentoId, P007J4_A289TipoPagamentoNome
               }
               , new Object[] {
               P007J5_A262TituloValor, P007J5_n262TituloValor, P007J5_A261TituloId
               }
               , new Object[] {
               P007J6_A270TituloMovimentoId, P007J6_A261TituloId, P007J6_n261TituloId, P007J6_A262TituloValor, P007J6_n262TituloValor
               }
               , new Object[] {
               P007J7_A261TituloId, P007J7_A262TituloValor, P007J7_n262TituloValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19TituloMovimentoId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A288TipoPagamentoId ;
      private int A270TituloMovimentoId ;
      private int AV27TipoPagamentoId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A261TituloId ;
      private int AV28TituloId ;
      private decimal A262TituloValor ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n288TipoPagamentoId ;
      private bool n262TituloValor ;
      private bool n261TituloId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A289TipoPagamentoNome ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P007J2_A289TipoPagamentoNome ;
      private int[] P007J2_A288TipoPagamentoId ;
      private bool[] P007J2_n288TipoPagamentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P007J3_A270TituloMovimentoId ;
      private int[] P007J3_A288TipoPagamentoId ;
      private bool[] P007J3_n288TipoPagamentoId ;
      private string[] P007J3_A289TipoPagamentoNome ;
      private int[] P007J4_A288TipoPagamentoId ;
      private bool[] P007J4_n288TipoPagamentoId ;
      private string[] P007J4_A289TipoPagamentoNome ;
      private decimal[] P007J5_A262TituloValor ;
      private bool[] P007J5_n262TituloValor ;
      private int[] P007J5_A261TituloId ;
      private bool[] P007J5_n261TituloId ;
      private int[] P007J6_A270TituloMovimentoId ;
      private int[] P007J6_A261TituloId ;
      private bool[] P007J6_n261TituloId ;
      private decimal[] P007J6_A262TituloValor ;
      private bool[] P007J6_n262TituloValor ;
      private int[] P007J7_A261TituloId ;
      private bool[] P007J7_n261TituloId ;
      private decimal[] P007J7_A262TituloValor ;
      private bool[] P007J7_n262TituloValor ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class titulomovimentoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007J2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A289TipoPagamentoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " TipoPagamentoNome, TipoPagamentoId";
         sFromString = " FROM TipoPagamento";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY TipoPagamentoNome, TipoPagamentoId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007J5( IGxContext context ,
                                             string AV13SearchTxt ,
                                             decimal A262TituloValor )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " TituloValor, TituloId";
         sFromString = " FROM Titulo";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(SUBSTR(TO_CHAR(TituloValor,'999999999999990.99'), 2) like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY TituloValor, TituloId";
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
                     return conditional_P007J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P007J5(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] );
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
          Object[] prmP007J3;
          prmP007J3 = new Object[] {
          new ParDef("AV19TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmP007J4;
          prmP007J4 = new Object[] {
          new ParDef("AV27TipoPagamentoId",GXType.Int32,9,0)
          };
          Object[] prmP007J6;
          prmP007J6 = new Object[] {
          new ParDef("AV19TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmP007J7;
          prmP007J7 = new Object[] {
          new ParDef("AV28TituloId",GXType.Int32,9,0)
          };
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP007J5;
          prmP007J5 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007J3", "SELECT T1.TituloMovimentoId, T1.TipoPagamentoId, T2.TipoPagamentoNome FROM (TituloMovimento T1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = T1.TipoPagamentoId) WHERE T1.TituloMovimentoId = :AV19TituloMovimentoId ORDER BY T1.TituloMovimentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007J4", "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :AV27TipoPagamentoId ORDER BY TipoPagamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007J5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007J6", "SELECT T1.TituloMovimentoId, T1.TituloId, T2.TituloValor FROM (TituloMovimento T1 LEFT JOIN Titulo T2 ON T2.TituloId = T1.TituloId) WHERE T1.TituloMovimentoId = :AV19TituloMovimentoId ORDER BY T1.TituloMovimentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007J7", "SELECT TituloId, TituloValor FROM Titulo WHERE TituloId = :AV28TituloId ORDER BY TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J7,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
