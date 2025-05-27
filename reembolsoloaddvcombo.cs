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
   public class reembolsoloaddvcombo : GXProcedure
   {
      public reembolsoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_ReembolsoId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ReembolsoId = aP3_ReembolsoId;
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
                                int aP3_ReembolsoId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ReembolsoId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_ReembolsoId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ReembolsoId = aP3_ReembolsoId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "ReembolsoPropostaId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REEMBOLSOPROPOSTAID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ReembolsoCreatedBy") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REEMBOLSOCREATEDBY' */
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
         /* 'LOADCOMBOITEMS_REEMBOLSOPROPOSTAID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00C03 */
            pr_default.execute(0, new Object[] {AV13SearchTxt, lV13SearchTxt, GXPagingFrom2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A323PropostaId = P00C03_A323PropostaId[0];
               A649PropostaMaxReembolsoId_F = P00C03_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = P00C03_n649PropostaMaxReembolsoId_F[0];
               A649PropostaMaxReembolsoId_F = P00C03_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = P00C03_n649PropostaMaxReembolsoId_F[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A323PropostaId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9"));
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
                  /* Using cursor P00C04 */
                  pr_default.execute(1, new Object[] {AV19ReembolsoId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A518ReembolsoId = P00C04_A518ReembolsoId[0];
                     A542ReembolsoPropostaId = P00C04_A542ReembolsoPropostaId[0];
                     n542ReembolsoPropostaId = P00C04_n542ReembolsoPropostaId[0];
                     AV21SelectedValue = ((0==A542ReembolsoPropostaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A542ReembolsoPropostaId), 9, 0)));
                     AV27PropostaId = A542ReembolsoPropostaId;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27PropostaId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00C06 */
               pr_default.execute(2, new Object[] {AV27PropostaId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A323PropostaId = P00C06_A323PropostaId[0];
                  A649PropostaMaxReembolsoId_F = P00C06_A649PropostaMaxReembolsoId_F[0];
                  n649PropostaMaxReembolsoId_F = P00C06_n649PropostaMaxReembolsoId_F[0];
                  A649PropostaMaxReembolsoId_F = P00C06_A649PropostaMaxReembolsoId_F[0];
                  n649PropostaMaxReembolsoId_F = P00C06_n649PropostaMaxReembolsoId_F[0];
                  AV22SelectedText = StringUtil.Trim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9"));
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
         /* 'LOADCOMBOITEMS_REEMBOLSOCREATEDBY' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A141SecUserName } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00C07 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A141SecUserName = P00C07_A141SecUserName[0];
               n141SecUserName = P00C07_n141SecUserName[0];
               A133SecUserId = P00C07_A133SecUserId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A133SecUserId), 4, 0));
               AV15Combo_DataItem.gxTpr_Title = A141SecUserName;
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
                  /* Using cursor P00C08 */
                  pr_default.execute(4, new Object[] {AV19ReembolsoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A518ReembolsoId = P00C08_A518ReembolsoId[0];
                     A544ReembolsoCreatedBy = P00C08_A544ReembolsoCreatedBy[0];
                     n544ReembolsoCreatedBy = P00C08_n544ReembolsoCreatedBy[0];
                     AV21SelectedValue = ((0==A544ReembolsoCreatedBy) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A544ReembolsoCreatedBy), 4, 0)));
                     AV28SecUserId = A544ReembolsoCreatedBy;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28SecUserId = (short)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00C09 */
               pr_default.execute(5, new Object[] {AV28SecUserId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A133SecUserId = P00C09_A133SecUserId[0];
                  A141SecUserName = P00C09_A141SecUserName[0];
                  n141SecUserName = P00C09_n141SecUserName[0];
                  AV22SelectedText = A141SecUserName;
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
         P00C03_A323PropostaId = new int[1] ;
         P00C03_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00C03_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00C04_A518ReembolsoId = new int[1] ;
         P00C04_A542ReembolsoPropostaId = new int[1] ;
         P00C04_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C06_A323PropostaId = new int[1] ;
         P00C06_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00C06_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         A141SecUserName = "";
         P00C07_A141SecUserName = new string[] {""} ;
         P00C07_n141SecUserName = new bool[] {false} ;
         P00C07_A133SecUserId = new short[1] ;
         P00C08_A518ReembolsoId = new int[1] ;
         P00C08_A544ReembolsoCreatedBy = new short[1] ;
         P00C08_n544ReembolsoCreatedBy = new bool[] {false} ;
         P00C09_A133SecUserId = new short[1] ;
         P00C09_A141SecUserName = new string[] {""} ;
         P00C09_n141SecUserName = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00C03_A323PropostaId, P00C03_A649PropostaMaxReembolsoId_F, P00C03_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00C04_A518ReembolsoId, P00C04_A542ReembolsoPropostaId, P00C04_n542ReembolsoPropostaId
               }
               , new Object[] {
               P00C06_A323PropostaId, P00C06_A649PropostaMaxReembolsoId_F, P00C06_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00C07_A141SecUserName, P00C07_n141SecUserName, P00C07_A133SecUserId
               }
               , new Object[] {
               P00C08_A518ReembolsoId, P00C08_A544ReembolsoCreatedBy, P00C08_n544ReembolsoCreatedBy
               }
               , new Object[] {
               P00C09_A133SecUserId, P00C09_A141SecUserName, P00C09_n141SecUserName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private short A133SecUserId ;
      private short A544ReembolsoCreatedBy ;
      private short AV28SecUserId ;
      private int AV19ReembolsoId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A323PropostaId ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A518ReembolsoId ;
      private int A542ReembolsoPropostaId ;
      private int AV27PropostaId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n542ReembolsoPropostaId ;
      private bool n141SecUserName ;
      private bool n544ReembolsoCreatedBy ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A141SecUserName ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] P00C03_A323PropostaId ;
      private int[] P00C03_A649PropostaMaxReembolsoId_F ;
      private bool[] P00C03_n649PropostaMaxReembolsoId_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00C04_A518ReembolsoId ;
      private int[] P00C04_A542ReembolsoPropostaId ;
      private bool[] P00C04_n542ReembolsoPropostaId ;
      private int[] P00C06_A323PropostaId ;
      private int[] P00C06_A649PropostaMaxReembolsoId_F ;
      private bool[] P00C06_n649PropostaMaxReembolsoId_F ;
      private string[] P00C07_A141SecUserName ;
      private bool[] P00C07_n141SecUserName ;
      private short[] P00C07_A133SecUserId ;
      private int[] P00C08_A518ReembolsoId ;
      private short[] P00C08_A544ReembolsoCreatedBy ;
      private bool[] P00C08_n544ReembolsoCreatedBy ;
      private short[] P00C09_A133SecUserId ;
      private string[] P00C09_A141SecUserName ;
      private bool[] P00C09_n141SecUserName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class reembolsoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C07( IGxContext context ,
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
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
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
               case 3 :
                     return conditional_P00C07(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00C03;
          prmP00C03 = new Object[] {
          new ParDef("AV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00C04;
          prmP00C04 = new Object[] {
          new ParDef("AV19ReembolsoId",GXType.Int32,9,0)
          };
          Object[] prmP00C06;
          prmP00C06 = new Object[] {
          new ParDef("AV27PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP00C08;
          prmP00C08 = new Object[] {
          new ParDef("AV19ReembolsoId",GXType.Int32,9,0)
          };
          Object[] prmP00C09;
          prmP00C09 = new Object[] {
          new ParDef("AV28SecUserId",GXType.Int16,4,0)
          };
          Object[] prmP00C07;
          prmP00C07 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C03", "SELECT T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE (char_length(trim(trailing ' ' from :AV13SearchTxt))=0) or ( SUBSTR(TO_CHAR(CAST(COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS integer),'999999999'), 2) like '%' || :lV13SearchTxt) ORDER BY PropostaMaxReembolsoId_F, PropostaId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C03,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C04", "SELECT ReembolsoId, ReembolsoPropostaId FROM Reembolso WHERE ReembolsoId = :AV19ReembolsoId ORDER BY ReembolsoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C04,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C06", "SELECT T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE T1.PropostaId = :AV27PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C06,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C07", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C07,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C08", "SELECT ReembolsoId, ReembolsoCreatedBy FROM Reembolso WHERE ReembolsoId = :AV19ReembolsoId ORDER BY ReembolsoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C08,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C09", "SELECT SecUserId, SecUserName FROM SecUser WHERE SecUserId = :AV28SecUserId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C09,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
