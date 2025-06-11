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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalityhaschildren : GXProcedure
   {
      public secfunctionalityhaschildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityhaschildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecFunctionalityId ,
                           out bool aP1_HasChildren )
      {
         this.AV9SecFunctionalityId = aP0_SecFunctionalityId;
         this.AV8HasChildren = false ;
         initialize();
         ExecuteImpl();
         aP1_HasChildren=this.AV8HasChildren;
      }

      public bool executeUdp( long aP0_SecFunctionalityId )
      {
         execute(aP0_SecFunctionalityId, out aP1_HasChildren);
         return AV8HasChildren ;
      }

      public void executeSubmit( long aP0_SecFunctionalityId ,
                                 out bool aP1_HasChildren )
      {
         this.AV9SecFunctionalityId = aP0_SecFunctionalityId;
         this.AV8HasChildren = false ;
         SubmitImpl();
         aP1_HasChildren=this.AV8HasChildren;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HasChildren = false;
         /* Using cursor P004M2 */
         pr_default.execute(0, new Object[] {AV9SecFunctionalityId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A129SecParentFunctionalityId = P004M2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004M2_n129SecParentFunctionalityId[0];
            A128SecFunctionalityId = P004M2_A128SecFunctionalityId[0];
            AV8HasChildren = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P004M2_A129SecParentFunctionalityId = new long[1] ;
         P004M2_n129SecParentFunctionalityId = new bool[] {false} ;
         P004M2_A128SecFunctionalityId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityhaschildren__default(),
            new Object[][] {
                new Object[] {
               P004M2_A129SecParentFunctionalityId, P004M2_n129SecParentFunctionalityId, P004M2_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9SecFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private bool AV8HasChildren ;
      private bool n129SecParentFunctionalityId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P004M2_A129SecParentFunctionalityId ;
      private bool[] P004M2_n129SecParentFunctionalityId ;
      private long[] P004M2_A128SecFunctionalityId ;
      private bool aP1_HasChildren ;
   }

   public class secfunctionalityhaschildren__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004M2;
          prmP004M2 = new Object[] {
          new ParDef("AV9SecFunctionalityId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004M2", "SELECT SecParentFunctionalityId, SecFunctionalityId FROM SecFunctionality WHERE SecParentFunctionalityId = :AV9SecFunctionalityId ORDER BY SecParentFunctionalityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004M2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
