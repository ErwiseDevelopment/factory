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
   public class prverificaresponsavel : GXProcedure
   {
      public prverificaresponsavel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prverificaresponsavel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           int aP1_ReponsavelClienteId ,
                           out bool aP2_IsCadastrado )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV8ReponsavelClienteId = aP1_ReponsavelClienteId;
         this.AV10IsCadastrado = false ;
         initialize();
         ExecuteImpl();
         aP2_IsCadastrado=this.AV10IsCadastrado;
      }

      public bool executeUdp( int aP0_ClienteId ,
                              int aP1_ReponsavelClienteId )
      {
         execute(aP0_ClienteId, aP1_ReponsavelClienteId, out aP2_IsCadastrado);
         return AV10IsCadastrado ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 int aP1_ReponsavelClienteId ,
                                 out bool aP2_IsCadastrado )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV8ReponsavelClienteId = aP1_ReponsavelClienteId;
         this.AV10IsCadastrado = false ;
         SubmitImpl();
         aP2_IsCadastrado=this.AV10IsCadastrado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsCadastrado = false;
         /* Using cursor P00AS2 */
         pr_default.execute(0, new Object[] {AV9ClienteId, AV11ResponsavelClienteId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = P00AS2_A168ClienteId[0];
            n168ClienteId = P00AS2_n168ClienteId[0];
            A552ReponsavelClienteId = P00AS2_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = P00AS2_n552ReponsavelClienteId[0];
            A551ClienteReponsavelId = P00AS2_A551ClienteReponsavelId[0];
            AV10IsCadastrado = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
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
         P00AS2_A168ClienteId = new int[1] ;
         P00AS2_n168ClienteId = new bool[] {false} ;
         P00AS2_A552ReponsavelClienteId = new int[1] ;
         P00AS2_n552ReponsavelClienteId = new bool[] {false} ;
         P00AS2_A551ClienteReponsavelId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prverificaresponsavel__default(),
            new Object[][] {
                new Object[] {
               P00AS2_A168ClienteId, P00AS2_n168ClienteId, P00AS2_A552ReponsavelClienteId, P00AS2_n552ReponsavelClienteId, P00AS2_A551ClienteReponsavelId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9ClienteId ;
      private int AV8ReponsavelClienteId ;
      private int AV11ResponsavelClienteId ;
      private int A168ClienteId ;
      private int A552ReponsavelClienteId ;
      private int A551ClienteReponsavelId ;
      private bool AV10IsCadastrado ;
      private bool n168ClienteId ;
      private bool n552ReponsavelClienteId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00AS2_A168ClienteId ;
      private bool[] P00AS2_n168ClienteId ;
      private int[] P00AS2_A552ReponsavelClienteId ;
      private bool[] P00AS2_n552ReponsavelClienteId ;
      private int[] P00AS2_A551ClienteReponsavelId ;
      private bool aP2_IsCadastrado ;
   }

   public class prverificaresponsavel__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AS2;
          prmP00AS2 = new Object[] {
          new ParDef("AV9ClienteId",GXType.Int32,9,0) ,
          new ParDef("AV11ResponsavelClienteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AS2", "SELECT ClienteId, ReponsavelClienteId, ClienteReponsavelId FROM ClienteReponsavel WHERE (ClienteId = :AV9ClienteId) AND (ReponsavelClienteId = :AV11ResponsavelClienteId) ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
