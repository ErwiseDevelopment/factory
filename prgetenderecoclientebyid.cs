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
   public class prgetenderecoclientebyid : GXProcedure
   {
      public prgetenderecoclientebyid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prgetenderecoclientebyid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           out SdtSdEnderecoCliente aP1_SdEnderecoCliente )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV8SdEnderecoCliente = new SdtSdEnderecoCliente(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdEnderecoCliente=this.AV8SdEnderecoCliente;
      }

      public SdtSdEnderecoCliente executeUdp( int aP0_ClienteId )
      {
         execute(aP0_ClienteId, out aP1_SdEnderecoCliente);
         return AV8SdEnderecoCliente ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 out SdtSdEnderecoCliente aP1_SdEnderecoCliente )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV8SdEnderecoCliente = new SdtSdEnderecoCliente(context) ;
         SubmitImpl();
         aP1_SdEnderecoCliente=this.AV8SdEnderecoCliente;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SdEnderecoCliente = new SdtSdEnderecoCliente(context);
         /* Using cursor P007X2 */
         pr_default.execute(0, new Object[] {AV9ClienteId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = P007X2_A168ClienteId[0];
            A182EnderecoCEP = P007X2_A182EnderecoCEP[0];
            n182EnderecoCEP = P007X2_n182EnderecoCEP[0];
            A183EnderecoLogradouro = P007X2_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = P007X2_n183EnderecoLogradouro[0];
            A184EnderecoBairro = P007X2_A184EnderecoBairro[0];
            n184EnderecoBairro = P007X2_n184EnderecoBairro[0];
            A185EnderecoCidade = P007X2_A185EnderecoCidade[0];
            n185EnderecoCidade = P007X2_n185EnderecoCidade[0];
            A186MunicipioCodigo = P007X2_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P007X2_n186MunicipioCodigo[0];
            A190EnderecoNumero = P007X2_A190EnderecoNumero[0];
            n190EnderecoNumero = P007X2_n190EnderecoNumero[0];
            A191EnderecoComplemento = P007X2_A191EnderecoComplemento[0];
            n191EnderecoComplemento = P007X2_n191EnderecoComplemento[0];
            AV8SdEnderecoCliente.gxTpr_Enderecocep = A182EnderecoCEP;
            AV8SdEnderecoCliente.gxTpr_Enderecologradouro = A183EnderecoLogradouro;
            AV8SdEnderecoCliente.gxTpr_Enderecobairro = A184EnderecoBairro;
            AV8SdEnderecoCliente.gxTpr_Enderecocidade = A185EnderecoCidade;
            AV8SdEnderecoCliente.gxTpr_Municipiocodigo = A186MunicipioCodigo;
            AV8SdEnderecoCliente.gxTpr_Endereconumero = A190EnderecoNumero;
            AV8SdEnderecoCliente.gxTpr_Enderecocomplemento = A191EnderecoComplemento;
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
         AV8SdEnderecoCliente = new SdtSdEnderecoCliente(context);
         P007X2_A168ClienteId = new int[1] ;
         P007X2_A182EnderecoCEP = new string[] {""} ;
         P007X2_n182EnderecoCEP = new bool[] {false} ;
         P007X2_A183EnderecoLogradouro = new string[] {""} ;
         P007X2_n183EnderecoLogradouro = new bool[] {false} ;
         P007X2_A184EnderecoBairro = new string[] {""} ;
         P007X2_n184EnderecoBairro = new bool[] {false} ;
         P007X2_A185EnderecoCidade = new string[] {""} ;
         P007X2_n185EnderecoCidade = new bool[] {false} ;
         P007X2_A186MunicipioCodigo = new string[] {""} ;
         P007X2_n186MunicipioCodigo = new bool[] {false} ;
         P007X2_A190EnderecoNumero = new string[] {""} ;
         P007X2_n190EnderecoNumero = new bool[] {false} ;
         P007X2_A191EnderecoComplemento = new string[] {""} ;
         P007X2_n191EnderecoComplemento = new bool[] {false} ;
         A182EnderecoCEP = "";
         A183EnderecoLogradouro = "";
         A184EnderecoBairro = "";
         A185EnderecoCidade = "";
         A186MunicipioCodigo = "";
         A190EnderecoNumero = "";
         A191EnderecoComplemento = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgetenderecoclientebyid__default(),
            new Object[][] {
                new Object[] {
               P007X2_A168ClienteId, P007X2_A182EnderecoCEP, P007X2_n182EnderecoCEP, P007X2_A183EnderecoLogradouro, P007X2_n183EnderecoLogradouro, P007X2_A184EnderecoBairro, P007X2_n184EnderecoBairro, P007X2_A185EnderecoCidade, P007X2_n185EnderecoCidade, P007X2_A186MunicipioCodigo,
               P007X2_n186MunicipioCodigo, P007X2_A190EnderecoNumero, P007X2_n190EnderecoNumero, P007X2_A191EnderecoComplemento, P007X2_n191EnderecoComplemento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9ClienteId ;
      private int A168ClienteId ;
      private bool n182EnderecoCEP ;
      private bool n183EnderecoLogradouro ;
      private bool n184EnderecoBairro ;
      private bool n185EnderecoCidade ;
      private bool n186MunicipioCodigo ;
      private bool n190EnderecoNumero ;
      private bool n191EnderecoComplemento ;
      private string A182EnderecoCEP ;
      private string A183EnderecoLogradouro ;
      private string A184EnderecoBairro ;
      private string A185EnderecoCidade ;
      private string A186MunicipioCodigo ;
      private string A190EnderecoNumero ;
      private string A191EnderecoComplemento ;
      private IGxDataStore dsDefault ;
      private SdtSdEnderecoCliente AV8SdEnderecoCliente ;
      private IDataStoreProvider pr_default ;
      private int[] P007X2_A168ClienteId ;
      private string[] P007X2_A182EnderecoCEP ;
      private bool[] P007X2_n182EnderecoCEP ;
      private string[] P007X2_A183EnderecoLogradouro ;
      private bool[] P007X2_n183EnderecoLogradouro ;
      private string[] P007X2_A184EnderecoBairro ;
      private bool[] P007X2_n184EnderecoBairro ;
      private string[] P007X2_A185EnderecoCidade ;
      private bool[] P007X2_n185EnderecoCidade ;
      private string[] P007X2_A186MunicipioCodigo ;
      private bool[] P007X2_n186MunicipioCodigo ;
      private string[] P007X2_A190EnderecoNumero ;
      private bool[] P007X2_n190EnderecoNumero ;
      private string[] P007X2_A191EnderecoComplemento ;
      private bool[] P007X2_n191EnderecoComplemento ;
      private SdtSdEnderecoCliente aP1_SdEnderecoCliente ;
   }

   public class prgetenderecoclientebyid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007X2;
          prmP007X2 = new Object[] {
          new ParDef("AV9ClienteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007X2", "SELECT ClienteId, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, MunicipioCodigo, EnderecoNumero, EnderecoComplemento FROM Cliente WHERE ClienteId = :AV9ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
