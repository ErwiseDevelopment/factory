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
   public class prdownloadclientedocumento : GXProcedure
   {
      public prdownloadclientedocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prdownloadclientedocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteDocumentoId ,
                           out string aP1_Arquivo )
      {
         this.AV8ClienteDocumentoId = aP0_ClienteDocumentoId;
         this.AV9Arquivo = "" ;
         initialize();
         ExecuteImpl();
         aP1_Arquivo=this.AV9Arquivo;
      }

      public string executeUdp( int aP0_ClienteDocumentoId )
      {
         execute(aP0_ClienteDocumentoId, out aP1_Arquivo);
         return AV9Arquivo ;
      }

      public void executeSubmit( int aP0_ClienteDocumentoId ,
                                 out string aP1_Arquivo )
      {
         this.AV8ClienteDocumentoId = aP0_ClienteDocumentoId;
         this.AV9Arquivo = "" ;
         SubmitImpl();
         aP1_Arquivo=this.AV9Arquivo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ClienteDocumento.Load(AV8ClienteDocumentoId);
         /* Using cursor P00BU2 */
         pr_default.execute(0, new Object[] {AV8ClienteDocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A599ClienteDocumentoId = P00BU2_A599ClienteDocumentoId[0];
            A602ClienteDocumentoNome = P00BU2_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = P00BU2_n602ClienteDocumentoNome[0];
            A603ClienteDocumentoExtensao = P00BU2_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = P00BU2_n603ClienteDocumentoExtensao[0];
            A601ClienteDocumentoBlob = P00BU2_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = P00BU2_n601ClienteDocumentoBlob[0];
            new prdownloadblob(context ).execute(  A601ClienteDocumentoBlob,  A602ClienteDocumentoNome,  A603ClienteDocumentoExtensao, out  AV9Arquivo) ;
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
         AV9Arquivo = "";
         AV10ClienteDocumento = new SdtClienteDocumento(context);
         P00BU2_A599ClienteDocumentoId = new int[1] ;
         P00BU2_A602ClienteDocumentoNome = new string[] {""} ;
         P00BU2_n602ClienteDocumentoNome = new bool[] {false} ;
         P00BU2_A603ClienteDocumentoExtensao = new string[] {""} ;
         P00BU2_n603ClienteDocumentoExtensao = new bool[] {false} ;
         P00BU2_A601ClienteDocumentoBlob = new string[] {""} ;
         P00BU2_n601ClienteDocumentoBlob = new bool[] {false} ;
         A602ClienteDocumentoNome = "";
         A603ClienteDocumentoExtensao = "";
         A601ClienteDocumentoBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prdownloadclientedocumento__default(),
            new Object[][] {
                new Object[] {
               P00BU2_A599ClienteDocumentoId, P00BU2_A602ClienteDocumentoNome, P00BU2_n602ClienteDocumentoNome, P00BU2_A603ClienteDocumentoExtensao, P00BU2_n603ClienteDocumentoExtensao, P00BU2_A601ClienteDocumentoBlob, P00BU2_n601ClienteDocumentoBlob
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8ClienteDocumentoId ;
      private int A599ClienteDocumentoId ;
      private bool n602ClienteDocumentoNome ;
      private bool n603ClienteDocumentoExtensao ;
      private bool n601ClienteDocumentoBlob ;
      private string AV9Arquivo ;
      private string A602ClienteDocumentoNome ;
      private string A603ClienteDocumentoExtensao ;
      private string A601ClienteDocumentoBlob ;
      private IGxDataStore dsDefault ;
      private SdtClienteDocumento AV10ClienteDocumento ;
      private IDataStoreProvider pr_default ;
      private int[] P00BU2_A599ClienteDocumentoId ;
      private string[] P00BU2_A602ClienteDocumentoNome ;
      private bool[] P00BU2_n602ClienteDocumentoNome ;
      private string[] P00BU2_A603ClienteDocumentoExtensao ;
      private bool[] P00BU2_n603ClienteDocumentoExtensao ;
      private string[] P00BU2_A601ClienteDocumentoBlob ;
      private bool[] P00BU2_n601ClienteDocumentoBlob ;
      private string aP1_Arquivo ;
   }

   public class prdownloadclientedocumento__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BU2;
          prmP00BU2 = new Object[] {
          new ParDef("AV8ClienteDocumentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BU2", "SELECT ClienteDocumentoId, ClienteDocumentoNome, ClienteDocumentoExtensao, ClienteDocumentoBlob FROM ClienteDocumento WHERE ClienteDocumentoId = :AV8ClienteDocumentoId ORDER BY ClienteDocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, "tmp", "");
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
