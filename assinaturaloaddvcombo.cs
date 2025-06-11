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
   public class assinaturaloaddvcombo : GXProcedure
   {
      public assinaturaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_AssinaturaId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19AssinaturaId = aP3_AssinaturaId;
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
                                long aP3_AssinaturaId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_AssinaturaId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_AssinaturaId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19AssinaturaId = aP3_AssinaturaId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "ContratoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CONTRATOID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ArquivoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ARQUIVOID' */
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
         /* 'LOADCOMBOITEMS_CONTRATOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A228ContratoNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P008R2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A228ContratoNome = P008R2_A228ContratoNome[0];
               n228ContratoNome = P008R2_n228ContratoNome[0];
               A227ContratoId = P008R2_A227ContratoId[0];
               n227ContratoId = P008R2_n227ContratoId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A227ContratoId), 6, 0));
               AV15Combo_DataItem.gxTpr_Title = A228ContratoNome;
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
                  /* Using cursor P008R3 */
                  pr_default.execute(1, new Object[] {AV19AssinaturaId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A238AssinaturaId = P008R3_A238AssinaturaId[0];
                     A227ContratoId = P008R3_A227ContratoId[0];
                     n227ContratoId = P008R3_n227ContratoId[0];
                     A228ContratoNome = P008R3_A228ContratoNome[0];
                     n228ContratoNome = P008R3_n228ContratoNome[0];
                     A228ContratoNome = P008R3_A228ContratoNome[0];
                     n228ContratoNome = P008R3_n228ContratoNome[0];
                     AV21SelectedValue = ((0==A227ContratoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A227ContratoId), 6, 0)));
                     AV22SelectedText = A228ContratoNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27ContratoId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P008R4 */
                  pr_default.execute(2, new Object[] {AV27ContratoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A227ContratoId = P008R4_A227ContratoId[0];
                     n227ContratoId = P008R4_n227ContratoId[0];
                     A228ContratoNome = P008R4_A228ContratoNome[0];
                     n228ContratoNome = P008R4_n228ContratoNome[0];
                     AV22SelectedText = A228ContratoNome;
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
         /* 'LOADCOMBOITEMS_ARQUIVOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A255ArquivoNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P008R5 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A255ArquivoNome = P008R5_A255ArquivoNome[0];
               n255ArquivoNome = P008R5_n255ArquivoNome[0];
               A231ArquivoId = P008R5_A231ArquivoId[0];
               n231ArquivoId = P008R5_n231ArquivoId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A231ArquivoId), 8, 0));
               AV15Combo_DataItem.gxTpr_Title = A255ArquivoNome;
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
                  /* Using cursor P008R6 */
                  pr_default.execute(4, new Object[] {AV19AssinaturaId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A238AssinaturaId = P008R6_A238AssinaturaId[0];
                     A231ArquivoId = P008R6_A231ArquivoId[0];
                     n231ArquivoId = P008R6_n231ArquivoId[0];
                     A255ArquivoNome = P008R6_A255ArquivoNome[0];
                     n255ArquivoNome = P008R6_n255ArquivoNome[0];
                     A255ArquivoNome = P008R6_A255ArquivoNome[0];
                     n255ArquivoNome = P008R6_n255ArquivoNome[0];
                     AV21SelectedValue = ((0==A231ArquivoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A231ArquivoId), 8, 0)));
                     AV22SelectedText = A255ArquivoNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28ArquivoId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P008R7 */
                  pr_default.execute(5, new Object[] {AV28ArquivoId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A231ArquivoId = P008R7_A231ArquivoId[0];
                     n231ArquivoId = P008R7_n231ArquivoId[0];
                     A255ArquivoNome = P008R7_A255ArquivoNome[0];
                     n255ArquivoNome = P008R7_n255ArquivoNome[0];
                     AV22SelectedText = A255ArquivoNome;
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
         A228ContratoNome = "";
         P008R2_A228ContratoNome = new string[] {""} ;
         P008R2_n228ContratoNome = new bool[] {false} ;
         P008R2_A227ContratoId = new int[1] ;
         P008R2_n227ContratoId = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P008R3_A238AssinaturaId = new long[1] ;
         P008R3_A227ContratoId = new int[1] ;
         P008R3_n227ContratoId = new bool[] {false} ;
         P008R3_A228ContratoNome = new string[] {""} ;
         P008R3_n228ContratoNome = new bool[] {false} ;
         P008R4_A227ContratoId = new int[1] ;
         P008R4_n227ContratoId = new bool[] {false} ;
         P008R4_A228ContratoNome = new string[] {""} ;
         P008R4_n228ContratoNome = new bool[] {false} ;
         A255ArquivoNome = "";
         P008R5_A255ArquivoNome = new string[] {""} ;
         P008R5_n255ArquivoNome = new bool[] {false} ;
         P008R5_A231ArquivoId = new int[1] ;
         P008R5_n231ArquivoId = new bool[] {false} ;
         P008R6_A238AssinaturaId = new long[1] ;
         P008R6_A231ArquivoId = new int[1] ;
         P008R6_n231ArquivoId = new bool[] {false} ;
         P008R6_A255ArquivoNome = new string[] {""} ;
         P008R6_n255ArquivoNome = new bool[] {false} ;
         P008R7_A231ArquivoId = new int[1] ;
         P008R7_n231ArquivoId = new bool[] {false} ;
         P008R7_A255ArquivoNome = new string[] {""} ;
         P008R7_n255ArquivoNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P008R2_A228ContratoNome, P008R2_n228ContratoNome, P008R2_A227ContratoId
               }
               , new Object[] {
               P008R3_A238AssinaturaId, P008R3_A227ContratoId, P008R3_n227ContratoId, P008R3_A228ContratoNome, P008R3_n228ContratoNome
               }
               , new Object[] {
               P008R4_A227ContratoId, P008R4_A228ContratoNome, P008R4_n228ContratoNome
               }
               , new Object[] {
               P008R5_A255ArquivoNome, P008R5_n255ArquivoNome, P008R5_A231ArquivoId
               }
               , new Object[] {
               P008R6_A238AssinaturaId, P008R6_A231ArquivoId, P008R6_n231ArquivoId, P008R6_A255ArquivoNome, P008R6_n255ArquivoNome
               }
               , new Object[] {
               P008R7_A231ArquivoId, P008R7_A255ArquivoNome, P008R7_n255ArquivoNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A227ContratoId ;
      private int AV27ContratoId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A231ArquivoId ;
      private int AV28ArquivoId ;
      private long AV19AssinaturaId ;
      private long A238AssinaturaId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n228ContratoNome ;
      private bool n227ContratoId ;
      private bool n255ArquivoNome ;
      private bool n231ArquivoId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A228ContratoNome ;
      private string A255ArquivoNome ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P008R2_A228ContratoNome ;
      private bool[] P008R2_n228ContratoNome ;
      private int[] P008R2_A227ContratoId ;
      private bool[] P008R2_n227ContratoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private long[] P008R3_A238AssinaturaId ;
      private int[] P008R3_A227ContratoId ;
      private bool[] P008R3_n227ContratoId ;
      private string[] P008R3_A228ContratoNome ;
      private bool[] P008R3_n228ContratoNome ;
      private int[] P008R4_A227ContratoId ;
      private bool[] P008R4_n227ContratoId ;
      private string[] P008R4_A228ContratoNome ;
      private bool[] P008R4_n228ContratoNome ;
      private string[] P008R5_A255ArquivoNome ;
      private bool[] P008R5_n255ArquivoNome ;
      private int[] P008R5_A231ArquivoId ;
      private bool[] P008R5_n231ArquivoId ;
      private long[] P008R6_A238AssinaturaId ;
      private int[] P008R6_A231ArquivoId ;
      private bool[] P008R6_n231ArquivoId ;
      private string[] P008R6_A255ArquivoNome ;
      private bool[] P008R6_n255ArquivoNome ;
      private int[] P008R7_A231ArquivoId ;
      private bool[] P008R7_n231ArquivoId ;
      private string[] P008R7_A255ArquivoNome ;
      private bool[] P008R7_n255ArquivoNome ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class assinaturaloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008R2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A228ContratoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ContratoNome, ContratoId";
         sFromString = " FROM Contrato";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ContratoNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ContratoNome, ContratoId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008R5( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A255ArquivoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ArquivoNome, ArquivoId";
         sFromString = " FROM Arquivo";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ArquivoNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY ArquivoNome, ArquivoId";
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
                     return conditional_P008R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P008R5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP008R3;
          prmP008R3 = new Object[] {
          new ParDef("AV19AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmP008R4;
          prmP008R4 = new Object[] {
          new ParDef("AV27ContratoId",GXType.Int32,6,0)
          };
          Object[] prmP008R6;
          prmP008R6 = new Object[] {
          new ParDef("AV19AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmP008R7;
          prmP008R7 = new Object[] {
          new ParDef("AV28ArquivoId",GXType.Int32,8,0)
          };
          Object[] prmP008R2;
          prmP008R2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP008R5;
          prmP008R5 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008R3", "SELECT T1.AssinaturaId, T1.ContratoId, T2.ContratoNome FROM (Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) WHERE T1.AssinaturaId = :AV19AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008R4", "SELECT ContratoId, ContratoNome FROM Contrato WHERE ContratoId = :AV27ContratoId ORDER BY ContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008R5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008R6", "SELECT T1.AssinaturaId, T1.ArquivoId, T2.ArquivoNome FROM (Assinatura T1 LEFT JOIN Arquivo T2 ON T2.ArquivoId = T1.ArquivoId) WHERE T1.AssinaturaId = :AV19AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008R7", "SELECT ArquivoId, ArquivoNome FROM Arquivo WHERE ArquivoId = :AV28ArquivoId ORDER BY ArquivoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R7,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
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
