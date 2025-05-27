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
   public class clientedocumentoloaddvcombo : GXProcedure
   {
      public clientedocumentoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientedocumentoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           int aP2_ClienteDocumentoId ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV12ComboName = aP0_ComboName;
         this.AV13TrnMode = aP1_TrnMode;
         this.AV14ClienteDocumentoId = aP2_ClienteDocumentoId;
         this.AV15SelectedValue = "" ;
         this.AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV10Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    int aP2_ClienteDocumentoId ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ClienteDocumentoId, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV10Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 int aP2_ClienteDocumentoId ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV12ComboName = aP0_ComboName;
         this.AV13TrnMode = aP1_TrnMode;
         this.AV14ClienteDocumentoId = aP2_ClienteDocumentoId;
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
         if ( StringUtil.StrCmp(AV12ComboName, "DocumentosId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DOCUMENTOSID' */
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
         /* 'LOADCOMBOITEMS_DOCUMENTOSID' Routine */
         returnInSub = false;
         /* Using cursor P00BS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A407DocumentosStatus = P00BS2_A407DocumentosStatus[0];
            n407DocumentosStatus = P00BS2_n407DocumentosStatus[0];
            A405DocumentosId = P00BS2_A405DocumentosId[0];
            n405DocumentosId = P00BS2_n405DocumentosId[0];
            A406DocumentosDescricao = P00BS2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P00BS2_n406DocumentosDescricao[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A405DocumentosId), 9, 0));
            AV11Combo_DataItem.gxTpr_Title = A406DocumentosDescricao;
            AV10Combo_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ( StringUtil.StrCmp(AV13TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV13TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P00BS3 */
            pr_default.execute(1, new Object[] {AV14ClienteDocumentoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A599ClienteDocumentoId = P00BS3_A599ClienteDocumentoId[0];
               A405DocumentosId = P00BS3_A405DocumentosId[0];
               n405DocumentosId = P00BS3_n405DocumentosId[0];
               AV15SelectedValue = ((0==A405DocumentosId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A405DocumentosId), 9, 0)));
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
         P00BS2_A407DocumentosStatus = new bool[] {false} ;
         P00BS2_n407DocumentosStatus = new bool[] {false} ;
         P00BS2_A405DocumentosId = new int[1] ;
         P00BS2_n405DocumentosId = new bool[] {false} ;
         P00BS2_A406DocumentosDescricao = new string[] {""} ;
         P00BS2_n406DocumentosDescricao = new bool[] {false} ;
         A406DocumentosDescricao = "";
         AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00BS3_A599ClienteDocumentoId = new int[1] ;
         P00BS3_A405DocumentosId = new int[1] ;
         P00BS3_n405DocumentosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientedocumentoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00BS2_A407DocumentosStatus, P00BS2_n407DocumentosStatus, P00BS2_A405DocumentosId, P00BS2_A406DocumentosDescricao, P00BS2_n406DocumentosDescricao
               }
               , new Object[] {
               P00BS3_A599ClienteDocumentoId, P00BS3_A405DocumentosId, P00BS3_n405DocumentosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV14ClienteDocumentoId ;
      private int A405DocumentosId ;
      private int A599ClienteDocumentoId ;
      private string AV13TrnMode ;
      private bool returnInSub ;
      private bool A407DocumentosStatus ;
      private bool n407DocumentosStatus ;
      private bool n405DocumentosId ;
      private bool n406DocumentosDescricao ;
      private string AV12ComboName ;
      private string AV15SelectedValue ;
      private string A406DocumentosDescricao ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV10Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private bool[] P00BS2_A407DocumentosStatus ;
      private bool[] P00BS2_n407DocumentosStatus ;
      private int[] P00BS2_A405DocumentosId ;
      private bool[] P00BS2_n405DocumentosId ;
      private string[] P00BS2_A406DocumentosDescricao ;
      private bool[] P00BS2_n406DocumentosDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV11Combo_DataItem ;
      private int[] P00BS3_A599ClienteDocumentoId ;
      private int[] P00BS3_A405DocumentosId ;
      private bool[] P00BS3_n405DocumentosId ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class clientedocumentoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BS2;
          prmP00BS2 = new Object[] {
          };
          Object[] prmP00BS3;
          prmP00BS3 = new Object[] {
          new ParDef("AV14ClienteDocumentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BS2", "SELECT DocumentosStatus, DocumentosId, DocumentosDescricao FROM Documentos WHERE DocumentosStatus ORDER BY DocumentosDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BS3", "SELECT ClienteDocumentoId, DocumentosId FROM ClienteDocumento WHERE ClienteDocumentoId = :AV14ClienteDocumentoId ORDER BY ClienteDocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
