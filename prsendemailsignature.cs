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
   public class prsendemailsignature : GXProcedure
   {
      public prsendemailsignature( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prsendemailsignature( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId ,
                           string aP1_BaseUrl )
      {
         this.AV8AssinaturaId = aP0_AssinaturaId;
         this.AV9BaseUrl = aP1_BaseUrl;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_AssinaturaId ,
                                 string aP1_BaseUrl )
      {
         this.AV8AssinaturaId = aP0_AssinaturaId;
         this.AV9BaseUrl = aP1_BaseUrl;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008O2 */
         pr_default.execute(0, new Object[] {AV8AssinaturaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A238AssinaturaId = P008O2_A238AssinaturaId[0];
            n238AssinaturaId = P008O2_n238AssinaturaId[0];
            A242AssinaturaParticipanteId = P008O2_A242AssinaturaParticipanteId[0];
            new prenviacomunicadocontratoparticipante(context ).execute(  A242AssinaturaParticipanteId,  AV9BaseUrl) ;
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
         P008O2_A238AssinaturaId = new long[1] ;
         P008O2_n238AssinaturaId = new bool[] {false} ;
         P008O2_A242AssinaturaParticipanteId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prsendemailsignature__default(),
            new Object[][] {
                new Object[] {
               P008O2_A238AssinaturaId, P008O2_n238AssinaturaId, P008O2_A242AssinaturaParticipanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A242AssinaturaParticipanteId ;
      private long AV8AssinaturaId ;
      private long A238AssinaturaId ;
      private bool n238AssinaturaId ;
      private string AV9BaseUrl ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008O2_A238AssinaturaId ;
      private bool[] P008O2_n238AssinaturaId ;
      private int[] P008O2_A242AssinaturaParticipanteId ;
   }

   public class prsendemailsignature__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008O2;
          prmP008O2 = new Object[] {
          new ParDef("AV8AssinaturaId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008O2", "SELECT AssinaturaId, AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaId = :AV8AssinaturaId ORDER BY AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
