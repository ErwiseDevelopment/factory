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
   public class prtornachavepixprincipal : GXProcedure
   {
      public prtornachavepixprincipal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prtornachavepixprincipal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ContaBancariaId ,
                           int aP1_ChavePIXID ,
                           out SdtSdErro aP2_SdErro )
      {
         this.AV8ContaBancariaId = aP0_ContaBancariaId;
         this.AV11ChavePIXID = aP1_ChavePIXID;
         this.AV9SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV9SdErro;
      }

      public SdtSdErro executeUdp( int aP0_ContaBancariaId ,
                                   int aP1_ChavePIXID )
      {
         execute(aP0_ContaBancariaId, aP1_ChavePIXID, out aP2_SdErro);
         return AV9SdErro ;
      }

      public void executeSubmit( int aP0_ContaBancariaId ,
                                 int aP1_ChavePIXID ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.AV8ContaBancariaId = aP0_ContaBancariaId;
         this.AV11ChavePIXID = aP1_ChavePIXID;
         this.AV9SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV9SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00ET2 */
         pr_default.execute(0, new Object[] {AV8ContaBancariaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A965ChavePIXPrincipal = P00ET2_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = P00ET2_n965ChavePIXPrincipal[0];
            A951ContaBancariaId = P00ET2_A951ContaBancariaId[0];
            n951ContaBancariaId = P00ET2_n951ContaBancariaId[0];
            A961ChavePIXId = P00ET2_A961ChavePIXId[0];
            AV10ChavePix.Load(A961ChavePIXId);
            AV10ChavePix.gxTpr_Chavepixprincipal = false;
            AV10ChavePix.Save();
            if ( AV10ChavePix.Fail() )
            {
               AV9SdErro.gxTpr_Internalcode = 1;
               AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV10ChavePix.GetMessages().Item(1)).gxTpr_Description;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV10ChavePix = new SdtChavePIX(context);
         AV10ChavePix.Load(AV11ChavePIXID);
         AV10ChavePix.gxTpr_Chavepixprincipal = true;
         AV10ChavePix.Save();
         if ( AV10ChavePix.Fail() )
         {
            AV9SdErro.gxTpr_Internalcode = 1;
            AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV10ChavePix.GetMessages().Item(1)).gxTpr_Description;
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
         AV9SdErro = new SdtSdErro(context);
         P00ET2_A965ChavePIXPrincipal = new bool[] {false} ;
         P00ET2_n965ChavePIXPrincipal = new bool[] {false} ;
         P00ET2_A951ContaBancariaId = new int[1] ;
         P00ET2_n951ContaBancariaId = new bool[] {false} ;
         P00ET2_A961ChavePIXId = new int[1] ;
         AV10ChavePix = new SdtChavePIX(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prtornachavepixprincipal__default(),
            new Object[][] {
                new Object[] {
               P00ET2_A965ChavePIXPrincipal, P00ET2_n965ChavePIXPrincipal, P00ET2_A951ContaBancariaId, P00ET2_n951ContaBancariaId, P00ET2_A961ChavePIXId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8ContaBancariaId ;
      private int AV11ChavePIXID ;
      private int A951ContaBancariaId ;
      private int A961ChavePIXId ;
      private bool A965ChavePIXPrincipal ;
      private bool n965ChavePIXPrincipal ;
      private bool n951ContaBancariaId ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV9SdErro ;
      private IDataStoreProvider pr_default ;
      private bool[] P00ET2_A965ChavePIXPrincipal ;
      private bool[] P00ET2_n965ChavePIXPrincipal ;
      private int[] P00ET2_A951ContaBancariaId ;
      private bool[] P00ET2_n951ContaBancariaId ;
      private int[] P00ET2_A961ChavePIXId ;
      private SdtChavePIX AV10ChavePix ;
      private SdtSdErro aP2_SdErro ;
   }

   public class prtornachavepixprincipal__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00ET2;
          prmP00ET2 = new Object[] {
          new ParDef("AV8ContaBancariaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ET2", "SELECT ChavePIXPrincipal, ContaBancariaId, ChavePIXId FROM ChavePIX WHERE (ContaBancariaId = :AV8ContaBancariaId) AND (ChavePIXPrincipal) ORDER BY ContaBancariaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ET2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
