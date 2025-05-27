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
   public class aprovadoresloaddvcombo : GXProcedure
   {
      public aprovadoresloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovadoresloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           int aP2_AprovadoresId ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV19AprovadoresId = aP2_AprovadoresId;
         this.AV21SelectedValue = "" ;
         this.AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV21SelectedValue;
         aP4_Combo_Data=this.AV14Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    int aP2_AprovadoresId ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_AprovadoresId, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV14Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 int aP2_AprovadoresId ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV19AprovadoresId = aP2_AprovadoresId;
         this.AV21SelectedValue = "" ;
         this.AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV21SelectedValue;
         aP4_Combo_Data=this.AV14Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV16ComboName, "SecUserId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SECUSERID' */
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
         /* 'LOADCOMBOITEMS_SECUSERID' Routine */
         returnInSub = false;
         /* Using cursor P00992 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A150SecUserStatus = P00992_A150SecUserStatus[0];
            n150SecUserStatus = P00992_n150SecUserStatus[0];
            A133SecUserId = P00992_A133SecUserId[0];
            n133SecUserId = P00992_n133SecUserId[0];
            A141SecUserName = P00992_A141SecUserName[0];
            n141SecUserName = P00992_n141SecUserName[0];
            AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A133SecUserId), 4, 0));
            AV15Combo_DataItem.gxTpr_Title = A141SecUserName;
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
         {
            /* Using cursor P00993 */
            pr_default.execute(1, new Object[] {AV19AprovadoresId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A375AprovadoresId = P00993_A375AprovadoresId[0];
               A133SecUserId = P00993_A133SecUserId[0];
               n133SecUserId = P00993_n133SecUserId[0];
               AV21SelectedValue = ((0==A133SecUserId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A133SecUserId), 4, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
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
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00992_A150SecUserStatus = new bool[] {false} ;
         P00992_n150SecUserStatus = new bool[] {false} ;
         P00992_A133SecUserId = new short[1] ;
         P00992_n133SecUserId = new bool[] {false} ;
         P00992_A141SecUserName = new string[] {""} ;
         P00992_n141SecUserName = new bool[] {false} ;
         A141SecUserName = "";
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00993_A375AprovadoresId = new int[1] ;
         P00993_A133SecUserId = new short[1] ;
         P00993_n133SecUserId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovadoresloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00992_A150SecUserStatus, P00992_n150SecUserStatus, P00992_A133SecUserId, P00992_A141SecUserName, P00992_n141SecUserName
               }
               , new Object[] {
               P00993_A375AprovadoresId, P00993_A133SecUserId, P00993_n133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A133SecUserId ;
      private int AV19AprovadoresId ;
      private int A375AprovadoresId ;
      private string AV17TrnMode ;
      private bool returnInSub ;
      private bool A150SecUserStatus ;
      private bool n150SecUserStatus ;
      private bool n133SecUserId ;
      private bool n141SecUserName ;
      private string AV16ComboName ;
      private string AV21SelectedValue ;
      private string A141SecUserName ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private bool[] P00992_A150SecUserStatus ;
      private bool[] P00992_n150SecUserStatus ;
      private short[] P00992_A133SecUserId ;
      private bool[] P00992_n133SecUserId ;
      private string[] P00992_A141SecUserName ;
      private bool[] P00992_n141SecUserName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private int[] P00993_A375AprovadoresId ;
      private short[] P00993_A133SecUserId ;
      private bool[] P00993_n133SecUserId ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class aprovadoresloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00992;
          prmP00992 = new Object[] {
          };
          Object[] prmP00993;
          prmP00993 = new Object[] {
          new ParDef("AV19AprovadoresId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00992", "SELECT SecUserStatus, SecUserId, SecUserName FROM SecUser WHERE SecUserStatus = TRUE ORDER BY SecUserName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00992,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00993", "SELECT AprovadoresId, SecUserId FROM Aprovadores WHERE AprovadoresId = :AV19AprovadoresId ORDER BY AprovadoresId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00993,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
