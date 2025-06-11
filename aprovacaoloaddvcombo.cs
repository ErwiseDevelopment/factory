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
   public class aprovacaoloaddvcombo : GXProcedure
   {
      public aprovacaoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovacaoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_AprovacaoId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19AprovacaoId = aP3_AprovacaoId;
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
                                int aP3_AprovacaoId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_AprovacaoId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_AprovacaoId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19AprovacaoId = aP3_AprovacaoId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "AprovadoresId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_APROVADORESID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "PropostaId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROPOSTAID' */
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
         /* 'LOADCOMBOITEMS_APROVADORESID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            /* Using cursor P009X2 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A375AprovadoresId = P009X2_A375AprovadoresId[0];
               n375AprovadoresId = P009X2_n375AprovadoresId[0];
               A380AprovadoresStatus = P009X2_A380AprovadoresStatus[0];
               n380AprovadoresStatus = P009X2_n380AprovadoresStatus[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A375AprovadoresId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus));
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
                  /* Using cursor P009X3 */
                  pr_default.execute(1, new Object[] {AV19AprovacaoId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A336AprovacaoId = P009X3_A336AprovacaoId[0];
                     A375AprovadoresId = P009X3_A375AprovadoresId[0];
                     n375AprovadoresId = P009X3_n375AprovadoresId[0];
                     A380AprovadoresStatus = P009X3_A380AprovadoresStatus[0];
                     n380AprovadoresStatus = P009X3_n380AprovadoresStatus[0];
                     A380AprovadoresStatus = P009X3_A380AprovadoresStatus[0];
                     n380AprovadoresStatus = P009X3_n380AprovadoresStatus[0];
                     AV21SelectedValue = ((0==A375AprovadoresId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A375AprovadoresId), 9, 0)));
                     AV22SelectedText = StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27AprovadoresId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P009X4 */
                  pr_default.execute(2, new Object[] {AV27AprovadoresId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A375AprovadoresId = P009X4_A375AprovadoresId[0];
                     n375AprovadoresId = P009X4_n375AprovadoresId[0];
                     A380AprovadoresStatus = P009X4_A380AprovadoresStatus[0];
                     n380AprovadoresStatus = P009X4_n380AprovadoresStatus[0];
                     AV22SelectedText = StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus));
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
         /* 'LOADCOMBOITEMS_PROPOSTAID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P009X6 */
            pr_default.execute(3, new Object[] {AV13SearchTxt, lV13SearchTxt, GXPagingFrom5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A323PropostaId = P009X6_A323PropostaId[0];
               n323PropostaId = P009X6_n323PropostaId[0];
               A649PropostaMaxReembolsoId_F = P009X6_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = P009X6_n649PropostaMaxReembolsoId_F[0];
               A649PropostaMaxReembolsoId_F = P009X6_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = P009X6_n649PropostaMaxReembolsoId_F[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A323PropostaId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9"));
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
                  /* Using cursor P009X8 */
                  pr_default.execute(4, new Object[] {AV19AprovacaoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A336AprovacaoId = P009X8_A336AprovacaoId[0];
                     A323PropostaId = P009X8_A323PropostaId[0];
                     n323PropostaId = P009X8_n323PropostaId[0];
                     A649PropostaMaxReembolsoId_F = P009X8_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P009X8_n649PropostaMaxReembolsoId_F[0];
                     A649PropostaMaxReembolsoId_F = P009X8_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P009X8_n649PropostaMaxReembolsoId_F[0];
                     AV21SelectedValue = ((0==A323PropostaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A323PropostaId), 9, 0)));
                     AV22SelectedText = ((0==A649PropostaMaxReembolsoId_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9")));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28PropostaId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P009X10 */
                  pr_default.execute(5, new Object[] {AV28PropostaId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A323PropostaId = P009X10_A323PropostaId[0];
                     n323PropostaId = P009X10_n323PropostaId[0];
                     A649PropostaMaxReembolsoId_F = P009X10_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P009X10_n649PropostaMaxReembolsoId_F[0];
                     A649PropostaMaxReembolsoId_F = P009X10_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P009X10_n649PropostaMaxReembolsoId_F[0];
                     AV22SelectedText = StringUtil.Trim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9"));
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
         P009X2_A375AprovadoresId = new int[1] ;
         P009X2_n375AprovadoresId = new bool[] {false} ;
         P009X2_A380AprovadoresStatus = new bool[] {false} ;
         P009X2_n380AprovadoresStatus = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P009X3_A336AprovacaoId = new int[1] ;
         P009X3_A375AprovadoresId = new int[1] ;
         P009X3_n375AprovadoresId = new bool[] {false} ;
         P009X3_A380AprovadoresStatus = new bool[] {false} ;
         P009X3_n380AprovadoresStatus = new bool[] {false} ;
         P009X4_A375AprovadoresId = new int[1] ;
         P009X4_n375AprovadoresId = new bool[] {false} ;
         P009X4_A380AprovadoresStatus = new bool[] {false} ;
         P009X4_n380AprovadoresStatus = new bool[] {false} ;
         lV13SearchTxt = "";
         P009X6_A323PropostaId = new int[1] ;
         P009X6_n323PropostaId = new bool[] {false} ;
         P009X6_A649PropostaMaxReembolsoId_F = new int[1] ;
         P009X6_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P009X8_A336AprovacaoId = new int[1] ;
         P009X8_A323PropostaId = new int[1] ;
         P009X8_n323PropostaId = new bool[] {false} ;
         P009X8_A649PropostaMaxReembolsoId_F = new int[1] ;
         P009X8_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P009X10_A323PropostaId = new int[1] ;
         P009X10_n323PropostaId = new bool[] {false} ;
         P009X10_A649PropostaMaxReembolsoId_F = new int[1] ;
         P009X10_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovacaoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P009X2_A375AprovadoresId, P009X2_A380AprovadoresStatus, P009X2_n380AprovadoresStatus
               }
               , new Object[] {
               P009X3_A336AprovacaoId, P009X3_A375AprovadoresId, P009X3_n375AprovadoresId, P009X3_A380AprovadoresStatus, P009X3_n380AprovadoresStatus
               }
               , new Object[] {
               P009X4_A375AprovadoresId, P009X4_A380AprovadoresStatus, P009X4_n380AprovadoresStatus
               }
               , new Object[] {
               P009X6_A323PropostaId, P009X6_A649PropostaMaxReembolsoId_F, P009X6_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P009X8_A336AprovacaoId, P009X8_A323PropostaId, P009X8_n323PropostaId, P009X8_A649PropostaMaxReembolsoId_F, P009X8_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P009X10_A323PropostaId, P009X10_A649PropostaMaxReembolsoId_F, P009X10_n649PropostaMaxReembolsoId_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19AprovacaoId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A375AprovadoresId ;
      private int A336AprovacaoId ;
      private int AV27AprovadoresId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A323PropostaId ;
      private int A649PropostaMaxReembolsoId_F ;
      private int AV28PropostaId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n375AprovadoresId ;
      private bool A380AprovadoresStatus ;
      private bool n380AprovadoresStatus ;
      private bool n323PropostaId ;
      private bool n649PropostaMaxReembolsoId_F ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] P009X2_A375AprovadoresId ;
      private bool[] P009X2_n375AprovadoresId ;
      private bool[] P009X2_A380AprovadoresStatus ;
      private bool[] P009X2_n380AprovadoresStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P009X3_A336AprovacaoId ;
      private int[] P009X3_A375AprovadoresId ;
      private bool[] P009X3_n375AprovadoresId ;
      private bool[] P009X3_A380AprovadoresStatus ;
      private bool[] P009X3_n380AprovadoresStatus ;
      private int[] P009X4_A375AprovadoresId ;
      private bool[] P009X4_n375AprovadoresId ;
      private bool[] P009X4_A380AprovadoresStatus ;
      private bool[] P009X4_n380AprovadoresStatus ;
      private int[] P009X6_A323PropostaId ;
      private bool[] P009X6_n323PropostaId ;
      private int[] P009X6_A649PropostaMaxReembolsoId_F ;
      private bool[] P009X6_n649PropostaMaxReembolsoId_F ;
      private int[] P009X8_A336AprovacaoId ;
      private int[] P009X8_A323PropostaId ;
      private bool[] P009X8_n323PropostaId ;
      private int[] P009X8_A649PropostaMaxReembolsoId_F ;
      private bool[] P009X8_n649PropostaMaxReembolsoId_F ;
      private int[] P009X10_A323PropostaId ;
      private bool[] P009X10_n323PropostaId ;
      private int[] P009X10_A649PropostaMaxReembolsoId_F ;
      private bool[] P009X10_n649PropostaMaxReembolsoId_F ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class aprovacaoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP009X2;
          prmP009X2 = new Object[] {
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP009X3;
          prmP009X3 = new Object[] {
          new ParDef("AV19AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmP009X4;
          prmP009X4 = new Object[] {
          new ParDef("AV27AprovadoresId",GXType.Int32,9,0)
          };
          Object[] prmP009X6;
          prmP009X6 = new Object[] {
          new ParDef("AV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP009X8;
          prmP009X8 = new Object[] {
          new ParDef("AV19AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmP009X10;
          prmP009X10 = new Object[] {
          new ParDef("AV28PropostaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009X2", "SELECT AprovadoresId, AprovadoresStatus FROM Aprovadores ORDER BY AprovadoresStatus, AprovadoresId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009X3", "SELECT T1.AprovacaoId, T1.AprovadoresId, T2.AprovadoresStatus FROM (Aprovacao T1 LEFT JOIN Aprovadores T2 ON T2.AprovadoresId = T1.AprovadoresId) WHERE T1.AprovacaoId = :AV19AprovacaoId ORDER BY T1.AprovacaoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009X4", "SELECT AprovadoresId, AprovadoresStatus FROM Aprovadores WHERE AprovadoresId = :AV27AprovadoresId ORDER BY AprovadoresId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009X6", "SELECT T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE (char_length(trim(trailing ' ' from :AV13SearchTxt))=0) or ( SUBSTR(TO_CHAR(CAST(COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS integer),'999999999'), 2) like '%' || :lV13SearchTxt) ORDER BY PropostaMaxReembolsoId_F, PropostaId  OFFSET :GXPagingFrom5 LIMIT CASE WHEN :GXPagingTo5 > 0 THEN :GXPagingTo5 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009X8", "SELECT T1.AprovacaoId, T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Aprovacao T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE T1.AprovacaoId = :AV19AprovacaoId ORDER BY T1.AprovacaoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009X10", "SELECT T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE T1.PropostaId = :AV28PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X10,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
