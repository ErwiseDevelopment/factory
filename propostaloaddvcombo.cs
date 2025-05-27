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
   public class propostaloaddvcombo : GXProcedure
   {
      public propostaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_PropostaId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19PropostaId = aP3_PropostaId;
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
                                int aP3_PropostaId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_PropostaId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_PropostaId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19PropostaId = aP3_PropostaId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "PropostaCratedBy") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROPOSTACRATEDBY' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ProcedimentosMedicosId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROCEDIMENTOSMEDICOSID' */
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
         /* 'LOADCOMBOITEMS_PROPOSTACRATEDBY' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A141SecUserName } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P008C2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A141SecUserName = P008C2_A141SecUserName[0];
               n141SecUserName = P008C2_n141SecUserName[0];
               A133SecUserId = P008C2_A133SecUserId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A133SecUserId), 4, 0));
               AV15Combo_DataItem.gxTpr_Title = A141SecUserName;
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
                  /* Using cursor P008C3 */
                  pr_default.execute(1, new Object[] {AV19PropostaId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A323PropostaId = P008C3_A323PropostaId[0];
                     A328PropostaCratedBy = P008C3_A328PropostaCratedBy[0];
                     n328PropostaCratedBy = P008C3_n328PropostaCratedBy[0];
                     AV21SelectedValue = ((0==A328PropostaCratedBy) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A328PropostaCratedBy), 4, 0)));
                     AV27SecUserId = A328PropostaCratedBy;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27SecUserId = (short)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P008C4 */
               pr_default.execute(2, new Object[] {AV27SecUserId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A133SecUserId = P008C4_A133SecUserId[0];
                  A141SecUserName = P008C4_A141SecUserName[0];
                  n141SecUserName = P008C4_n141SecUserName[0];
                  AV22SelectedText = A141SecUserName;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROCEDIMENTOSMEDICOSID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A377ProcedimentosMedicosNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P008C5 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A377ProcedimentosMedicosNome = P008C5_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = P008C5_n377ProcedimentosMedicosNome[0];
               A376ProcedimentosMedicosId = P008C5_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = P008C5_n376ProcedimentosMedicosId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A376ProcedimentosMedicosId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A377ProcedimentosMedicosNome;
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
                  /* Using cursor P008C6 */
                  pr_default.execute(4, new Object[] {AV19PropostaId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A323PropostaId = P008C6_A323PropostaId[0];
                     A376ProcedimentosMedicosId = P008C6_A376ProcedimentosMedicosId[0];
                     n376ProcedimentosMedicosId = P008C6_n376ProcedimentosMedicosId[0];
                     A377ProcedimentosMedicosNome = P008C6_A377ProcedimentosMedicosNome[0];
                     n377ProcedimentosMedicosNome = P008C6_n377ProcedimentosMedicosNome[0];
                     A377ProcedimentosMedicosNome = P008C6_A377ProcedimentosMedicosNome[0];
                     n377ProcedimentosMedicosNome = P008C6_n377ProcedimentosMedicosNome[0];
                     AV21SelectedValue = ((0==A376ProcedimentosMedicosId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A376ProcedimentosMedicosId), 9, 0)));
                     AV22SelectedText = A377ProcedimentosMedicosNome;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV30ProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P008C7 */
                  pr_default.execute(5, new Object[] {AV30ProcedimentosMedicosId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A376ProcedimentosMedicosId = P008C7_A376ProcedimentosMedicosId[0];
                     n376ProcedimentosMedicosId = P008C7_n376ProcedimentosMedicosId[0];
                     A377ProcedimentosMedicosNome = P008C7_A377ProcedimentosMedicosNome[0];
                     n377ProcedimentosMedicosNome = P008C7_n377ProcedimentosMedicosNome[0];
                     AV22SelectedText = A377ProcedimentosMedicosNome;
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
         A141SecUserName = "";
         P008C2_A141SecUserName = new string[] {""} ;
         P008C2_n141SecUserName = new bool[] {false} ;
         P008C2_A133SecUserId = new short[1] ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P008C3_A323PropostaId = new int[1] ;
         P008C3_A328PropostaCratedBy = new short[1] ;
         P008C3_n328PropostaCratedBy = new bool[] {false} ;
         P008C4_A133SecUserId = new short[1] ;
         P008C4_A141SecUserName = new string[] {""} ;
         P008C4_n141SecUserName = new bool[] {false} ;
         A377ProcedimentosMedicosNome = "";
         P008C5_A377ProcedimentosMedicosNome = new string[] {""} ;
         P008C5_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P008C5_A376ProcedimentosMedicosId = new int[1] ;
         P008C5_n376ProcedimentosMedicosId = new bool[] {false} ;
         P008C6_A323PropostaId = new int[1] ;
         P008C6_A376ProcedimentosMedicosId = new int[1] ;
         P008C6_n376ProcedimentosMedicosId = new bool[] {false} ;
         P008C6_A377ProcedimentosMedicosNome = new string[] {""} ;
         P008C6_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P008C7_A376ProcedimentosMedicosId = new int[1] ;
         P008C7_n376ProcedimentosMedicosId = new bool[] {false} ;
         P008C7_A377ProcedimentosMedicosNome = new string[] {""} ;
         P008C7_n377ProcedimentosMedicosNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostaloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P008C2_A141SecUserName, P008C2_n141SecUserName, P008C2_A133SecUserId
               }
               , new Object[] {
               P008C3_A323PropostaId, P008C3_A328PropostaCratedBy, P008C3_n328PropostaCratedBy
               }
               , new Object[] {
               P008C4_A133SecUserId, P008C4_A141SecUserName, P008C4_n141SecUserName
               }
               , new Object[] {
               P008C5_A377ProcedimentosMedicosNome, P008C5_n377ProcedimentosMedicosNome, P008C5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               P008C6_A323PropostaId, P008C6_A376ProcedimentosMedicosId, P008C6_n376ProcedimentosMedicosId, P008C6_A377ProcedimentosMedicosNome, P008C6_n377ProcedimentosMedicosNome
               }
               , new Object[] {
               P008C7_A376ProcedimentosMedicosId, P008C7_A377ProcedimentosMedicosNome, P008C7_n377ProcedimentosMedicosNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private short A133SecUserId ;
      private short A328PropostaCratedBy ;
      private short AV27SecUserId ;
      private int AV19PropostaId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A323PropostaId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A376ProcedimentosMedicosId ;
      private int AV30ProcedimentosMedicosId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n141SecUserName ;
      private bool n328PropostaCratedBy ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n376ProcedimentosMedicosId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A141SecUserName ;
      private string A377ProcedimentosMedicosNome ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P008C2_A141SecUserName ;
      private bool[] P008C2_n141SecUserName ;
      private short[] P008C2_A133SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P008C3_A323PropostaId ;
      private short[] P008C3_A328PropostaCratedBy ;
      private bool[] P008C3_n328PropostaCratedBy ;
      private short[] P008C4_A133SecUserId ;
      private string[] P008C4_A141SecUserName ;
      private bool[] P008C4_n141SecUserName ;
      private string[] P008C5_A377ProcedimentosMedicosNome ;
      private bool[] P008C5_n377ProcedimentosMedicosNome ;
      private int[] P008C5_A376ProcedimentosMedicosId ;
      private bool[] P008C5_n376ProcedimentosMedicosId ;
      private int[] P008C6_A323PropostaId ;
      private int[] P008C6_A376ProcedimentosMedicosId ;
      private bool[] P008C6_n376ProcedimentosMedicosId ;
      private string[] P008C6_A377ProcedimentosMedicosNome ;
      private bool[] P008C6_n377ProcedimentosMedicosNome ;
      private int[] P008C7_A376ProcedimentosMedicosId ;
      private bool[] P008C7_n376ProcedimentosMedicosId ;
      private string[] P008C7_A377ProcedimentosMedicosNome ;
      private bool[] P008C7_n377ProcedimentosMedicosNome ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class propostaloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008C2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A141SecUserName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SecUserName, SecUserId";
         sFromString = " FROM SecUser";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY SecUserName, SecUserId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008C5( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A377ProcedimentosMedicosNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProcedimentosMedicosNome, ProcedimentosMedicosId";
         sFromString = " FROM ProcedimentosMedicos";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProcedimentosMedicosNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY ProcedimentosMedicosNome, ProcedimentosMedicosId";
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
                     return conditional_P008C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P008C5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP008C3;
          prmP008C3 = new Object[] {
          new ParDef("AV19PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP008C4;
          prmP008C4 = new Object[] {
          new ParDef("AV27SecUserId",GXType.Int16,4,0)
          };
          Object[] prmP008C6;
          prmP008C6 = new Object[] {
          new ParDef("AV19PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP008C7;
          prmP008C7 = new Object[] {
          new ParDef("AV30ProcedimentosMedicosId",GXType.Int32,9,0)
          };
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP008C5;
          prmP008C5 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C3", "SELECT PropostaId, PropostaCratedBy FROM Proposta WHERE PropostaId = :AV19PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C4", "SELECT SecUserId, SecUserName FROM SecUser WHERE SecUserId = :AV27SecUserId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C6", "SELECT T1.PropostaId, T1.ProcedimentosMedicosId, T2.ProcedimentosMedicosNome FROM (Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) WHERE T1.PropostaId = :AV19PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C7", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosNome FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :AV30ProcedimentosMedicosId ORDER BY ProcedimentosMedicosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C7,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
