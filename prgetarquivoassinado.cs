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
   public class prgetarquivoassinado : GXProcedure
   {
      public prgetarquivoassinado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prgetarquivoassinado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId ,
                           out string aP1_ArquivoBlob )
      {
         this.AV9AssinaturaId = aP0_AssinaturaId;
         this.AV8ArquivoBlob = "" ;
         initialize();
         ExecuteImpl();
         aP1_ArquivoBlob=this.AV8ArquivoBlob;
      }

      public string executeUdp( long aP0_AssinaturaId )
      {
         execute(aP0_AssinaturaId, out aP1_ArquivoBlob);
         return AV8ArquivoBlob ;
      }

      public void executeSubmit( long aP0_AssinaturaId ,
                                 out string aP1_ArquivoBlob )
      {
         this.AV9AssinaturaId = aP0_AssinaturaId;
         this.AV8ArquivoBlob = "" ;
         SubmitImpl();
         aP1_ArquivoBlob=this.AV8ArquivoBlob;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009Z2 */
         pr_default.execute(0, new Object[] {AV9AssinaturaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A238AssinaturaId = P009Z2_A238AssinaturaId[0];
            A257AssinaturaArquivoAssinadoNome = P009Z2_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = P009Z2_n257AssinaturaArquivoAssinadoNome[0];
            A256AssinaturaArquivoAssinadoExtensao = P009Z2_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = P009Z2_n256AssinaturaArquivoAssinadoExtensao[0];
            A240AssinaturaArquivoAssinado = P009Z2_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = P009Z2_n240AssinaturaArquivoAssinado[0];
            AV8ArquivoBlob = A240AssinaturaArquivoAssinado;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV8ArquivoBlob = "";
         P009Z2_A238AssinaturaId = new long[1] ;
         P009Z2_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         P009Z2_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         P009Z2_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         P009Z2_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         P009Z2_A240AssinaturaArquivoAssinado = new string[] {""} ;
         P009Z2_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         A257AssinaturaArquivoAssinadoNome = "";
         A256AssinaturaArquivoAssinadoExtensao = "";
         A240AssinaturaArquivoAssinado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgetarquivoassinado__default(),
            new Object[][] {
                new Object[] {
               P009Z2_A238AssinaturaId, P009Z2_A257AssinaturaArquivoAssinadoNome, P009Z2_n257AssinaturaArquivoAssinadoNome, P009Z2_A256AssinaturaArquivoAssinadoExtensao, P009Z2_n256AssinaturaArquivoAssinadoExtensao, P009Z2_A240AssinaturaArquivoAssinado, P009Z2_n240AssinaturaArquivoAssinado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9AssinaturaId ;
      private long A238AssinaturaId ;
      private bool n257AssinaturaArquivoAssinadoNome ;
      private bool n256AssinaturaArquivoAssinadoExtensao ;
      private bool n240AssinaturaArquivoAssinado ;
      private string A257AssinaturaArquivoAssinadoNome ;
      private string A256AssinaturaArquivoAssinadoExtensao ;
      private string AV8ArquivoBlob ;
      private string A240AssinaturaArquivoAssinado ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009Z2_A238AssinaturaId ;
      private string[] P009Z2_A257AssinaturaArquivoAssinadoNome ;
      private bool[] P009Z2_n257AssinaturaArquivoAssinadoNome ;
      private string[] P009Z2_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] P009Z2_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] P009Z2_A240AssinaturaArquivoAssinado ;
      private bool[] P009Z2_n240AssinaturaArquivoAssinado ;
      private string aP1_ArquivoBlob ;
   }

   public class prgetarquivoassinado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009Z2;
          prmP009Z2 = new Object[] {
          new ParDef("AV9AssinaturaId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Z2", "SELECT AssinaturaId, AssinaturaArquivoAssinadoNome, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinado FROM Assinatura WHERE AssinaturaId = :AV9AssinaturaId ORDER BY AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(3), rslt.getVarchar(2));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
