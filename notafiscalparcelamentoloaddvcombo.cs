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
   public class notafiscalparcelamentoloaddvcombo : GXProcedure
   {
      public notafiscalparcelamentoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalparcelamentoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_NotaFiscalParcelamentoID ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19NotaFiscalParcelamentoID = aP3_NotaFiscalParcelamentoID;
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
                                Guid aP3_NotaFiscalParcelamentoID ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_NotaFiscalParcelamentoID, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_NotaFiscalParcelamentoID ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19NotaFiscalParcelamentoID = aP3_NotaFiscalParcelamentoID;
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
         if ( StringUtil.StrCmp(AV16ComboName, "NotaFiscalId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NOTAFISCALID' */
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
         /* 'LOADCOMBOITEMS_NOTAFISCALID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            /* Using cursor P00ED2 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A794NotaFiscalId = P00ED2_A794NotaFiscalId[0];
               n794NotaFiscalId = P00ED2_n794NotaFiscalId[0];
               A795NotaFiscalUF = P00ED2_A795NotaFiscalUF[0];
               n795NotaFiscalUF = P00ED2_n795NotaFiscalUF[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( A794NotaFiscalId.ToString());
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( gxdomaindmufcod.getDescription(context,A795NotaFiscalUF));
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
                  /* Using cursor P00ED3 */
                  pr_default.execute(1, new Object[] {AV19NotaFiscalParcelamentoID});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A890NotaFiscalParcelamentoID = P00ED3_A890NotaFiscalParcelamentoID[0];
                     A794NotaFiscalId = P00ED3_A794NotaFiscalId[0];
                     n794NotaFiscalId = P00ED3_n794NotaFiscalId[0];
                     A795NotaFiscalUF = P00ED3_A795NotaFiscalUF[0];
                     n795NotaFiscalUF = P00ED3_n795NotaFiscalUF[0];
                     A795NotaFiscalUF = P00ED3_A795NotaFiscalUF[0];
                     n795NotaFiscalUF = P00ED3_n795NotaFiscalUF[0];
                     AV21SelectedValue = ((Guid.Empty==A794NotaFiscalId) ? "" : StringUtil.Trim( A794NotaFiscalId.ToString()));
                     AV22SelectedText = ((0==A795NotaFiscalUF) ? "" : StringUtil.Trim( gxdomaindmufcod.getDescription(context,A795NotaFiscalUF)));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27NotaFiscalId = StringUtil.StrToGuid( AV13SearchTxt);
                  /* Using cursor P00ED4 */
                  pr_default.execute(2, new Object[] {AV27NotaFiscalId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A794NotaFiscalId = P00ED4_A794NotaFiscalId[0];
                     n794NotaFiscalId = P00ED4_n794NotaFiscalId[0];
                     A795NotaFiscalUF = P00ED4_A795NotaFiscalUF[0];
                     n795NotaFiscalUF = P00ED4_n795NotaFiscalUF[0];
                     AV22SelectedText = StringUtil.Trim( gxdomaindmufcod.getDescription(context,A795NotaFiscalUF));
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
         P00ED2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00ED2_n794NotaFiscalId = new bool[] {false} ;
         P00ED2_A795NotaFiscalUF = new short[1] ;
         P00ED2_n795NotaFiscalUF = new bool[] {false} ;
         A794NotaFiscalId = Guid.Empty;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00ED3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00ED3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00ED3_n794NotaFiscalId = new bool[] {false} ;
         P00ED3_A795NotaFiscalUF = new short[1] ;
         P00ED3_n795NotaFiscalUF = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         AV27NotaFiscalId = Guid.Empty;
         P00ED4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00ED4_n794NotaFiscalId = new bool[] {false} ;
         P00ED4_A795NotaFiscalUF = new short[1] ;
         P00ED4_n795NotaFiscalUF = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalparcelamentoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00ED2_A794NotaFiscalId, P00ED2_A795NotaFiscalUF, P00ED2_n795NotaFiscalUF
               }
               , new Object[] {
               P00ED3_A890NotaFiscalParcelamentoID, P00ED3_A794NotaFiscalId, P00ED3_n794NotaFiscalId, P00ED3_A795NotaFiscalUF, P00ED3_n795NotaFiscalUF
               }
               , new Object[] {
               P00ED4_A794NotaFiscalId, P00ED4_A795NotaFiscalUF, P00ED4_n795NotaFiscalUF
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
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n794NotaFiscalId ;
      private bool n795NotaFiscalUF ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private Guid AV19NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid AV27NotaFiscalId ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00ED2_A794NotaFiscalId ;
      private bool[] P00ED2_n794NotaFiscalId ;
      private short[] P00ED2_A795NotaFiscalUF ;
      private bool[] P00ED2_n795NotaFiscalUF ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private Guid[] P00ED3_A890NotaFiscalParcelamentoID ;
      private Guid[] P00ED3_A794NotaFiscalId ;
      private bool[] P00ED3_n794NotaFiscalId ;
      private short[] P00ED3_A795NotaFiscalUF ;
      private bool[] P00ED3_n795NotaFiscalUF ;
      private Guid[] P00ED4_A794NotaFiscalId ;
      private bool[] P00ED4_n794NotaFiscalId ;
      private short[] P00ED4_A795NotaFiscalUF ;
      private bool[] P00ED4_n795NotaFiscalUF ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class notafiscalparcelamentoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00ED2;
          prmP00ED2 = new Object[] {
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00ED3;
          prmP00ED3 = new Object[] {
          new ParDef("AV19NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00ED4;
          prmP00ED4 = new Object[] {
          new ParDef("AV27NotaFiscalId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ED2", "SELECT NotaFiscalId, NotaFiscalUF FROM NotaFiscal ORDER BY NotaFiscalUF, NotaFiscalId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00ED3", "SELECT T1.NotaFiscalParcelamentoID, T1.NotaFiscalId, T2.NotaFiscalUF FROM (NotaFiscalParcelamento T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId) WHERE T1.NotaFiscalParcelamentoID = :AV19NotaFiscalParcelamentoID ORDER BY T1.NotaFiscalParcelamentoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00ED4", "SELECT NotaFiscalId, NotaFiscalUF FROM NotaFiscal WHERE NotaFiscalId = :AV27NotaFiscalId ORDER BY NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED4,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
