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
   public class secisauthbyfunctionalitykey : GXProcedure
   {
      public secisauthbyfunctionalitykey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secisauthbyfunctionalitykey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecFunctionalityKey ,
                           out bool aP1_IsAuthorized )
      {
         this.AV9SecFunctionalityKey = aP0_SecFunctionalityKey;
         this.AV8IsAuthorized = false ;
         initialize();
         ExecuteImpl();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      public bool executeUdp( string aP0_SecFunctionalityKey )
      {
         execute(aP0_SecFunctionalityKey, out aP1_IsAuthorized);
         return AV8IsAuthorized ;
      }

      public void executeSubmit( string aP0_SecFunctionalityKey ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV9SecFunctionalityKey = aP0_SecFunctionalityKey;
         this.AV8IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsAuthorized = false;
         AV10GXLvl3 = 0;
         /* Using cursor P004G2 */
         pr_default.execute(0, new Object[] {AV9SecFunctionalityKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A134SecFunctionalityActive = P004G2_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = P004G2_n134SecFunctionalityActive[0];
            A130SecFunctionalityKey = P004G2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004G2_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P004G2_A128SecFunctionalityId[0];
            AV10GXLvl3 = 1;
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalityid(context ).execute(  A128SecFunctionalityId, out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl3 == 0 )
         {
            AV8IsAuthorized = false;
         }
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
         P004G2_A134SecFunctionalityActive = new bool[] {false} ;
         P004G2_n134SecFunctionalityActive = new bool[] {false} ;
         P004G2_A130SecFunctionalityKey = new string[] {""} ;
         P004G2_n130SecFunctionalityKey = new bool[] {false} ;
         P004G2_A128SecFunctionalityId = new long[1] ;
         A130SecFunctionalityKey = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey__default(),
            new Object[][] {
                new Object[] {
               P004G2_A134SecFunctionalityActive, P004G2_n134SecFunctionalityActive, P004G2_A130SecFunctionalityKey, P004G2_n130SecFunctionalityKey, P004G2_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl3 ;
      private long A128SecFunctionalityId ;
      private bool AV8IsAuthorized ;
      private bool A134SecFunctionalityActive ;
      private bool n134SecFunctionalityActive ;
      private bool n130SecFunctionalityKey ;
      private bool GXt_boolean1 ;
      private string AV9SecFunctionalityKey ;
      private string A130SecFunctionalityKey ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P004G2_A134SecFunctionalityActive ;
      private bool[] P004G2_n134SecFunctionalityActive ;
      private string[] P004G2_A130SecFunctionalityKey ;
      private bool[] P004G2_n130SecFunctionalityKey ;
      private long[] P004G2_A128SecFunctionalityId ;
      private bool aP1_IsAuthorized ;
   }

   public class secisauthbyfunctionalitykey__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004G2;
          prmP004G2 = new Object[] {
          new ParDef("AV9SecFunctionalityKey",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004G2", "SELECT SecFunctionalityActive, SecFunctionalityKey, SecFunctionalityId FROM SecFunctionality WHERE (UPPER(SecFunctionalityKey) = ( UPPER(:AV9SecFunctionalityKey))) AND (SecFunctionalityActive) ORDER BY SecFunctionalityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004G2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
