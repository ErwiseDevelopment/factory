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
   public class notafiscalitemloaddvcombo : GXProcedure
   {
      public notafiscalitemloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalitemloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_NotaFiscalItemId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19NotaFiscalItemId = aP3_NotaFiscalItemId;
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
                                Guid aP3_NotaFiscalItemId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_NotaFiscalItemId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_NotaFiscalItemId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19NotaFiscalItemId = aP3_NotaFiscalItemId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "PropostaId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROPOSTAID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "NotaFiscalId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NOTAFISCALID' */
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
         /* 'LOADCOMBOITEMS_PROPOSTAID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00DE3 */
            pr_default.execute(0, new Object[] {AV13SearchTxt, lV13SearchTxt, GXPagingFrom2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A323PropostaId = P00DE3_A323PropostaId[0];
               n323PropostaId = P00DE3_n323PropostaId[0];
               A649PropostaMaxReembolsoId_F = P00DE3_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = P00DE3_n649PropostaMaxReembolsoId_F[0];
               A649PropostaMaxReembolsoId_F = P00DE3_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = P00DE3_n649PropostaMaxReembolsoId_F[0];
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
                  /* Using cursor P00DE5 */
                  pr_default.execute(1, new Object[] {AV19NotaFiscalItemId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A830NotaFiscalItemId = P00DE5_A830NotaFiscalItemId[0];
                     A323PropostaId = P00DE5_A323PropostaId[0];
                     n323PropostaId = P00DE5_n323PropostaId[0];
                     A649PropostaMaxReembolsoId_F = P00DE5_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P00DE5_n649PropostaMaxReembolsoId_F[0];
                     A649PropostaMaxReembolsoId_F = P00DE5_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P00DE5_n649PropostaMaxReembolsoId_F[0];
                     AV21SelectedValue = ((0==A323PropostaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A323PropostaId), 9, 0)));
                     AV22SelectedText = ((0==A649PropostaMaxReembolsoId_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(A649PropostaMaxReembolsoId_F), "ZZZZZZZZ9")));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27PropostaId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00DE7 */
                  pr_default.execute(2, new Object[] {AV27PropostaId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A323PropostaId = P00DE7_A323PropostaId[0];
                     n323PropostaId = P00DE7_n323PropostaId[0];
                     A649PropostaMaxReembolsoId_F = P00DE7_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P00DE7_n649PropostaMaxReembolsoId_F[0];
                     A649PropostaMaxReembolsoId_F = P00DE7_A649PropostaMaxReembolsoId_F[0];
                     n649PropostaMaxReembolsoId_F = P00DE7_n649PropostaMaxReembolsoId_F[0];
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
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_NOTAFISCALID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            /* Using cursor P00DE8 */
            pr_default.execute(3, new Object[] {GXPagingFrom5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A794NotaFiscalId = P00DE8_A794NotaFiscalId[0];
               n794NotaFiscalId = P00DE8_n794NotaFiscalId[0];
               A795NotaFiscalUF = P00DE8_A795NotaFiscalUF[0];
               n795NotaFiscalUF = P00DE8_n795NotaFiscalUF[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( A794NotaFiscalId.ToString());
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( gxdomaindmufcod.getDescription(context,A795NotaFiscalUF));
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
                  /* Using cursor P00DE9 */
                  pr_default.execute(4, new Object[] {AV19NotaFiscalItemId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A830NotaFiscalItemId = P00DE9_A830NotaFiscalItemId[0];
                     A794NotaFiscalId = P00DE9_A794NotaFiscalId[0];
                     n794NotaFiscalId = P00DE9_n794NotaFiscalId[0];
                     A795NotaFiscalUF = P00DE9_A795NotaFiscalUF[0];
                     n795NotaFiscalUF = P00DE9_n795NotaFiscalUF[0];
                     A795NotaFiscalUF = P00DE9_A795NotaFiscalUF[0];
                     n795NotaFiscalUF = P00DE9_n795NotaFiscalUF[0];
                     AV21SelectedValue = ((Guid.Empty==A794NotaFiscalId) ? "" : StringUtil.Trim( A794NotaFiscalId.ToString()));
                     AV22SelectedText = ((0==A795NotaFiscalUF) ? "" : StringUtil.Trim( gxdomaindmufcod.getDescription(context,A795NotaFiscalUF)));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28NotaFiscalId = StringUtil.StrToGuid( AV13SearchTxt);
                  /* Using cursor P00DE10 */
                  pr_default.execute(5, new Object[] {AV28NotaFiscalId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A794NotaFiscalId = P00DE10_A794NotaFiscalId[0];
                     n794NotaFiscalId = P00DE10_n794NotaFiscalId[0];
                     A795NotaFiscalUF = P00DE10_A795NotaFiscalUF[0];
                     n795NotaFiscalUF = P00DE10_n795NotaFiscalUF[0];
                     AV22SelectedText = StringUtil.Trim( gxdomaindmufcod.getDescription(context,A795NotaFiscalUF));
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
         P00DE3_A323PropostaId = new int[1] ;
         P00DE3_n323PropostaId = new bool[] {false} ;
         P00DE3_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00DE3_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00DE5_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         P00DE5_A323PropostaId = new int[1] ;
         P00DE5_n323PropostaId = new bool[] {false} ;
         P00DE5_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00DE5_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         A830NotaFiscalItemId = Guid.Empty;
         P00DE7_A323PropostaId = new int[1] ;
         P00DE7_n323PropostaId = new bool[] {false} ;
         P00DE7_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00DE7_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P00DE8_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DE8_n794NotaFiscalId = new bool[] {false} ;
         P00DE8_A795NotaFiscalUF = new short[1] ;
         P00DE8_n795NotaFiscalUF = new bool[] {false} ;
         A794NotaFiscalId = Guid.Empty;
         P00DE9_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         P00DE9_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DE9_n794NotaFiscalId = new bool[] {false} ;
         P00DE9_A795NotaFiscalUF = new short[1] ;
         P00DE9_n795NotaFiscalUF = new bool[] {false} ;
         AV28NotaFiscalId = Guid.Empty;
         P00DE10_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DE10_n794NotaFiscalId = new bool[] {false} ;
         P00DE10_A795NotaFiscalUF = new short[1] ;
         P00DE10_n795NotaFiscalUF = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitemloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00DE3_A323PropostaId, P00DE3_A649PropostaMaxReembolsoId_F, P00DE3_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00DE5_A830NotaFiscalItemId, P00DE5_A323PropostaId, P00DE5_n323PropostaId, P00DE5_A649PropostaMaxReembolsoId_F, P00DE5_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00DE7_A323PropostaId, P00DE7_A649PropostaMaxReembolsoId_F, P00DE7_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00DE8_A794NotaFiscalId, P00DE8_A795NotaFiscalUF, P00DE8_n795NotaFiscalUF
               }
               , new Object[] {
               P00DE9_A830NotaFiscalItemId, P00DE9_A794NotaFiscalId, P00DE9_n794NotaFiscalId, P00DE9_A795NotaFiscalUF, P00DE9_n795NotaFiscalUF
               }
               , new Object[] {
               P00DE10_A794NotaFiscalId, P00DE10_A795NotaFiscalUF, P00DE10_n795NotaFiscalUF
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private short A795NotaFiscalUF ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A323PropostaId ;
      private int A649PropostaMaxReembolsoId_F ;
      private int AV27PropostaId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n323PropostaId ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n794NotaFiscalId ;
      private bool n795NotaFiscalUF ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private Guid AV19NotaFiscalItemId ;
      private Guid A830NotaFiscalItemId ;
      private Guid A794NotaFiscalId ;
      private Guid AV28NotaFiscalId ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] P00DE3_A323PropostaId ;
      private bool[] P00DE3_n323PropostaId ;
      private int[] P00DE3_A649PropostaMaxReembolsoId_F ;
      private bool[] P00DE3_n649PropostaMaxReembolsoId_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private Guid[] P00DE5_A830NotaFiscalItemId ;
      private int[] P00DE5_A323PropostaId ;
      private bool[] P00DE5_n323PropostaId ;
      private int[] P00DE5_A649PropostaMaxReembolsoId_F ;
      private bool[] P00DE5_n649PropostaMaxReembolsoId_F ;
      private int[] P00DE7_A323PropostaId ;
      private bool[] P00DE7_n323PropostaId ;
      private int[] P00DE7_A649PropostaMaxReembolsoId_F ;
      private bool[] P00DE7_n649PropostaMaxReembolsoId_F ;
      private Guid[] P00DE8_A794NotaFiscalId ;
      private bool[] P00DE8_n794NotaFiscalId ;
      private short[] P00DE8_A795NotaFiscalUF ;
      private bool[] P00DE8_n795NotaFiscalUF ;
      private Guid[] P00DE9_A830NotaFiscalItemId ;
      private Guid[] P00DE9_A794NotaFiscalId ;
      private bool[] P00DE9_n794NotaFiscalId ;
      private short[] P00DE9_A795NotaFiscalUF ;
      private bool[] P00DE9_n795NotaFiscalUF ;
      private Guid[] P00DE10_A794NotaFiscalId ;
      private bool[] P00DE10_n794NotaFiscalId ;
      private short[] P00DE10_A795NotaFiscalUF ;
      private bool[] P00DE10_n795NotaFiscalUF ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class notafiscalitemloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DE3;
          prmP00DE3 = new Object[] {
          new ParDef("AV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00DE5;
          prmP00DE5 = new Object[] {
          new ParDef("AV19NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DE7;
          prmP00DE7 = new Object[] {
          new ParDef("AV27PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP00DE8;
          prmP00DE8 = new Object[] {
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP00DE9;
          prmP00DE9 = new Object[] {
          new ParDef("AV19NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DE10;
          prmP00DE10 = new Object[] {
          new ParDef("AV28NotaFiscalId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DE3", "SELECT T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE (char_length(trim(trailing ' ' from :AV13SearchTxt))=0) or ( SUBSTR(TO_CHAR(CAST(COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS integer),'999999999'), 2) like '%' || :lV13SearchTxt) ORDER BY PropostaMaxReembolsoId_F, PropostaId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DE5", "SELECT T1.NotaFiscalItemId, T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (NotaFiscalItem T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE T1.NotaFiscalItemId = :AV19NotaFiscalItemId ORDER BY T1.NotaFiscalItemId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DE7", "SELECT T1.PropostaId, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = T1.PropostaId) WHERE T1.PropostaId = :AV27PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DE8", "SELECT NotaFiscalId, NotaFiscalUF FROM NotaFiscal ORDER BY NotaFiscalUF, NotaFiscalId  OFFSET :GXPagingFrom5 LIMIT CASE WHEN :GXPagingTo5 > 0 THEN :GXPagingTo5 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DE9", "SELECT T1.NotaFiscalItemId, T1.NotaFiscalId, T2.NotaFiscalUF FROM (NotaFiscalItem T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId) WHERE T1.NotaFiscalItemId = :AV19NotaFiscalItemId ORDER BY T1.NotaFiscalItemId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DE10", "SELECT NotaFiscalId, NotaFiscalUF FROM NotaFiscal WHERE NotaFiscalId = :AV28NotaFiscalId ORDER BY NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE10,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
