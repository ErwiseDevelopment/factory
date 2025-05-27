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
   public class notificacaoagendadaloaddvcombo : GXProcedure
   {
      public notificacaoagendadaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           int aP2_NotificacaoAgendadaId ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV12ComboName = aP0_ComboName;
         this.AV13TrnMode = aP1_TrnMode;
         this.AV14NotificacaoAgendadaId = aP2_NotificacaoAgendadaId;
         this.AV15SelectedValue = "" ;
         this.AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV10Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    int aP2_NotificacaoAgendadaId ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_NotificacaoAgendadaId, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV10Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 int aP2_NotificacaoAgendadaId ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV12ComboName = aP0_ComboName;
         this.AV13TrnMode = aP1_TrnMode;
         this.AV14NotificacaoAgendadaId = aP2_NotificacaoAgendadaId;
         this.AV15SelectedValue = "" ;
         this.AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV10Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV12ComboName, "NotificacaoAgendadaLayoutId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NOTIFICACAOAGENDADALAYOUTID' */
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
         /* 'LOADCOMBOITEMS_NOTIFICACAOAGENDADALAYOUTID' Routine */
         returnInSub = false;
         /* Using cursor P00EG2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A906LayoutContratoTipo = P00EG2_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = P00EG2_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = P00EG2_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = P00EG2_n156LayoutContratoStatus[0];
            A154LayoutContratoId = P00EG2_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = P00EG2_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = P00EG2_n155LayoutContratoDescricao[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV11Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV10Combo_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV13TrnMode, "INS") != 0 )
         {
            /* Using cursor P00EG3 */
            pr_default.execute(1, new Object[] {AV14NotificacaoAgendadaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A898NotificacaoAgendadaId = P00EG3_A898NotificacaoAgendadaId[0];
               A904NotificacaoAgendadaLayoutId = P00EG3_A904NotificacaoAgendadaLayoutId[0];
               n904NotificacaoAgendadaLayoutId = P00EG3_n904NotificacaoAgendadaLayoutId[0];
               AV15SelectedValue = ((0==A904NotificacaoAgendadaLayoutId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0)));
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
         AV15SelectedValue = "";
         AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00EG2_A906LayoutContratoTipo = new string[] {""} ;
         P00EG2_n906LayoutContratoTipo = new bool[] {false} ;
         P00EG2_A156LayoutContratoStatus = new bool[] {false} ;
         P00EG2_n156LayoutContratoStatus = new bool[] {false} ;
         P00EG2_A154LayoutContratoId = new short[1] ;
         P00EG2_A155LayoutContratoDescricao = new string[] {""} ;
         P00EG2_n155LayoutContratoDescricao = new bool[] {false} ;
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00EG3_A898NotificacaoAgendadaId = new int[1] ;
         P00EG3_A904NotificacaoAgendadaLayoutId = new short[1] ;
         P00EG3_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadaloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00EG2_A906LayoutContratoTipo, P00EG2_n906LayoutContratoTipo, P00EG2_A156LayoutContratoStatus, P00EG2_n156LayoutContratoStatus, P00EG2_A154LayoutContratoId, P00EG2_A155LayoutContratoDescricao, P00EG2_n155LayoutContratoDescricao
               }
               , new Object[] {
               P00EG3_A898NotificacaoAgendadaId, P00EG3_A904NotificacaoAgendadaLayoutId, P00EG3_n904NotificacaoAgendadaLayoutId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A154LayoutContratoId ;
      private short A904NotificacaoAgendadaLayoutId ;
      private int AV14NotificacaoAgendadaId ;
      private int A898NotificacaoAgendadaId ;
      private string AV13TrnMode ;
      private bool returnInSub ;
      private bool n906LayoutContratoTipo ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private bool n904NotificacaoAgendadaLayoutId ;
      private string AV12ComboName ;
      private string AV15SelectedValue ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV10Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00EG2_A906LayoutContratoTipo ;
      private bool[] P00EG2_n906LayoutContratoTipo ;
      private bool[] P00EG2_A156LayoutContratoStatus ;
      private bool[] P00EG2_n156LayoutContratoStatus ;
      private short[] P00EG2_A154LayoutContratoId ;
      private string[] P00EG2_A155LayoutContratoDescricao ;
      private bool[] P00EG2_n155LayoutContratoDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV11Combo_DataItem ;
      private int[] P00EG3_A898NotificacaoAgendadaId ;
      private short[] P00EG3_A904NotificacaoAgendadaLayoutId ;
      private bool[] P00EG3_n904NotificacaoAgendadaLayoutId ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class notificacaoagendadaloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EG2;
          prmP00EG2 = new Object[] {
          };
          Object[] prmP00EG3;
          prmP00EG3 = new Object[] {
          new ParDef("AV14NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EG2", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'M')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EG3", "SELECT NotificacaoAgendadaId, NotificacaoAgendadaLayoutId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :AV14NotificacaoAgendadaId ORDER BY NotificacaoAgendadaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
