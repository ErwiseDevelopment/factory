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
   public class prexisterepresentantecadastrado : GXProcedure
   {
      public prexisterepresentantecadastrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prexisterepresentantecadastrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClienteDocumento ,
                           out bool aP1_IsExists )
      {
         this.AV8ClienteDocumento = aP0_ClienteDocumento;
         this.AV10IsExists = false ;
         initialize();
         ExecuteImpl();
         aP1_IsExists=this.AV10IsExists;
      }

      public bool executeUdp( string aP0_ClienteDocumento )
      {
         execute(aP0_ClienteDocumento, out aP1_IsExists);
         return AV10IsExists ;
      }

      public void executeSubmit( string aP0_ClienteDocumento ,
                                 out bool aP1_IsExists )
      {
         this.AV8ClienteDocumento = aP0_ClienteDocumento;
         this.AV10IsExists = false ;
         SubmitImpl();
         aP1_IsExists=this.AV10IsExists;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsExists = false;
         /* Using cursor P00DV2 */
         pr_default.execute(0, new Object[] {AV8ClienteDocumento});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A169ClienteDocumento = P00DV2_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DV2_n169ClienteDocumento[0];
            A168ClienteId = P00DV2_A168ClienteId[0];
            AV10IsExists = true;
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
         P00DV2_A169ClienteDocumento = new string[] {""} ;
         P00DV2_n169ClienteDocumento = new bool[] {false} ;
         P00DV2_A168ClienteId = new int[1] ;
         A169ClienteDocumento = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prexisterepresentantecadastrado__default(),
            new Object[][] {
                new Object[] {
               P00DV2_A169ClienteDocumento, P00DV2_n169ClienteDocumento, P00DV2_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A168ClienteId ;
      private bool AV10IsExists ;
      private bool n169ClienteDocumento ;
      private string AV8ClienteDocumento ;
      private string A169ClienteDocumento ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DV2_A169ClienteDocumento ;
      private bool[] P00DV2_n169ClienteDocumento ;
      private int[] P00DV2_A168ClienteId ;
      private bool aP1_IsExists ;
   }

   public class prexisterepresentantecadastrado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DV2;
          prmP00DV2 = new Object[] {
          new ParDef("AV8ClienteDocumento",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DV2", "SELECT ClienteDocumento, ClienteId FROM Cliente WHERE ClienteDocumento = ( :AV8ClienteDocumento) ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DV2,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
