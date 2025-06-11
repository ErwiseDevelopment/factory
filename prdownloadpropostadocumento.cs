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
   public class prdownloadpropostadocumento : GXProcedure
   {
      public prdownloadpropostadocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prdownloadpropostadocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaDocumentosId ,
                           out string aP1_Arquivo )
      {
         this.AV8PropostaDocumentosId = aP0_PropostaDocumentosId;
         this.AV9Arquivo = "" ;
         initialize();
         ExecuteImpl();
         aP1_Arquivo=this.AV9Arquivo;
      }

      public string executeUdp( int aP0_PropostaDocumentosId )
      {
         execute(aP0_PropostaDocumentosId, out aP1_Arquivo);
         return AV9Arquivo ;
      }

      public void executeSubmit( int aP0_PropostaDocumentosId ,
                                 out string aP1_Arquivo )
      {
         this.AV8PropostaDocumentosId = aP0_PropostaDocumentosId;
         this.AV9Arquivo = "" ;
         SubmitImpl();
         aP1_Arquivo=this.AV9Arquivo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009W2 */
         pr_default.execute(0, new Object[] {AV8PropostaDocumentosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A414PropostaDocumentosId = P009W2_A414PropostaDocumentosId[0];
            A416PropostaDocumentosAnexoName = P009W2_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = P009W2_n416PropostaDocumentosAnexoName[0];
            A417PropostaDocumentosAnexoFileType = P009W2_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = P009W2_n417PropostaDocumentosAnexoFileType[0];
            A415PropostaDocumentosAnexo = P009W2_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = P009W2_n415PropostaDocumentosAnexo[0];
            new prdownloadblob(context ).execute(  A415PropostaDocumentosAnexo,  A416PropostaDocumentosAnexoName,  A417PropostaDocumentosAnexoFileType, out  AV9Arquivo) ;
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
         P009W2_A414PropostaDocumentosId = new int[1] ;
         P009W2_A416PropostaDocumentosAnexoName = new string[] {""} ;
         P009W2_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         P009W2_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         P009W2_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         P009W2_A415PropostaDocumentosAnexo = new string[] {""} ;
         P009W2_n415PropostaDocumentosAnexo = new bool[] {false} ;
         A416PropostaDocumentosAnexoName = "";
         A417PropostaDocumentosAnexoFileType = "";
         A415PropostaDocumentosAnexo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prdownloadpropostadocumento__default(),
            new Object[][] {
                new Object[] {
               P009W2_A414PropostaDocumentosId, P009W2_A416PropostaDocumentosAnexoName, P009W2_n416PropostaDocumentosAnexoName, P009W2_A417PropostaDocumentosAnexoFileType, P009W2_n417PropostaDocumentosAnexoFileType, P009W2_A415PropostaDocumentosAnexo, P009W2_n415PropostaDocumentosAnexo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8PropostaDocumentosId ;
      private int A414PropostaDocumentosId ;
      private bool n416PropostaDocumentosAnexoName ;
      private bool n417PropostaDocumentosAnexoFileType ;
      private bool n415PropostaDocumentosAnexo ;
      private string AV9Arquivo ;
      private string A416PropostaDocumentosAnexoName ;
      private string A417PropostaDocumentosAnexoFileType ;
      private string A415PropostaDocumentosAnexo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P009W2_A414PropostaDocumentosId ;
      private string[] P009W2_A416PropostaDocumentosAnexoName ;
      private bool[] P009W2_n416PropostaDocumentosAnexoName ;
      private string[] P009W2_A417PropostaDocumentosAnexoFileType ;
      private bool[] P009W2_n417PropostaDocumentosAnexoFileType ;
      private string[] P009W2_A415PropostaDocumentosAnexo ;
      private bool[] P009W2_n415PropostaDocumentosAnexo ;
      private string aP1_Arquivo ;
   }

   public class prdownloadpropostadocumento__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009W2;
          prmP009W2 = new Object[] {
          new ParDef("AV8PropostaDocumentosId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009W2", "SELECT PropostaDocumentosId, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosAnexo FROM PropostaDocumentos WHERE PropostaDocumentosId = :AV8PropostaDocumentosId ORDER BY PropostaDocumentosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009W2,1, GxCacheFrequency.OFF ,true,true )
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
