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
   public class getclinicataxbyclienteid : GXProcedure
   {
      public getclinicataxbyclienteid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getclinicataxbyclienteid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           out decimal aP1_contratotaxa ,
                           out short aP2_contratosla ,
                           out decimal aP3_contratojurosmora ,
                           out decimal aP4_contratoiofminimo )
      {
         this.AV8ClienteId = aP0_ClienteId;
         this.AV9contratotaxa = 0 ;
         this.AV10contratosla = 0 ;
         this.AV12contratojurosmora = 0 ;
         this.AV11contratoiofminimo = 0 ;
         initialize();
         ExecuteImpl();
         aP1_contratotaxa=this.AV9contratotaxa;
         aP2_contratosla=this.AV10contratosla;
         aP3_contratojurosmora=this.AV12contratojurosmora;
         aP4_contratoiofminimo=this.AV11contratoiofminimo;
      }

      public decimal executeUdp( int aP0_ClienteId ,
                                 out decimal aP1_contratotaxa ,
                                 out short aP2_contratosla ,
                                 out decimal aP3_contratojurosmora )
      {
         execute(aP0_ClienteId, out aP1_contratotaxa, out aP2_contratosla, out aP3_contratojurosmora, out aP4_contratoiofminimo);
         return AV11contratoiofminimo ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 out decimal aP1_contratotaxa ,
                                 out short aP2_contratosla ,
                                 out decimal aP3_contratojurosmora ,
                                 out decimal aP4_contratoiofminimo )
      {
         this.AV8ClienteId = aP0_ClienteId;
         this.AV9contratotaxa = 0 ;
         this.AV10contratosla = 0 ;
         this.AV12contratojurosmora = 0 ;
         this.AV11contratoiofminimo = 0 ;
         SubmitImpl();
         aP1_contratotaxa=this.AV9contratotaxa;
         aP2_contratosla=this.AV10contratosla;
         aP3_contratojurosmora=this.AV12contratojurosmora;
         aP4_contratoiofminimo=this.AV11contratoiofminimo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BT2 */
         pr_default.execute(0, new Object[] {AV8ClienteId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A460ContratoTaxa = P00BT2_A460ContratoTaxa[0];
            n460ContratoTaxa = P00BT2_n460ContratoTaxa[0];
            A471ContratoSituacao = P00BT2_A471ContratoSituacao[0];
            n471ContratoSituacao = P00BT2_n471ContratoSituacao[0];
            A473ContratoClienteId = P00BT2_A473ContratoClienteId[0];
            n473ContratoClienteId = P00BT2_n473ContratoClienteId[0];
            A461ContratoSLA = P00BT2_A461ContratoSLA[0];
            n461ContratoSLA = P00BT2_n461ContratoSLA[0];
            A462ContratoJurosMora = P00BT2_A462ContratoJurosMora[0];
            n462ContratoJurosMora = P00BT2_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = P00BT2_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = P00BT2_n463ContratoIOFMinimo[0];
            A227ContratoId = P00BT2_A227ContratoId[0];
            AV9contratotaxa = A460ContratoTaxa;
            AV10contratosla = A461ContratoSLA;
            AV12contratojurosmora = A462ContratoJurosMora;
            AV11contratoiofminimo = A463ContratoIOFMinimo;
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
         P00BT2_A460ContratoTaxa = new decimal[1] ;
         P00BT2_n460ContratoTaxa = new bool[] {false} ;
         P00BT2_A471ContratoSituacao = new string[] {""} ;
         P00BT2_n471ContratoSituacao = new bool[] {false} ;
         P00BT2_A473ContratoClienteId = new int[1] ;
         P00BT2_n473ContratoClienteId = new bool[] {false} ;
         P00BT2_A461ContratoSLA = new short[1] ;
         P00BT2_n461ContratoSLA = new bool[] {false} ;
         P00BT2_A462ContratoJurosMora = new decimal[1] ;
         P00BT2_n462ContratoJurosMora = new bool[] {false} ;
         P00BT2_A463ContratoIOFMinimo = new decimal[1] ;
         P00BT2_n463ContratoIOFMinimo = new bool[] {false} ;
         P00BT2_A227ContratoId = new int[1] ;
         A471ContratoSituacao = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getclinicataxbyclienteid__default(),
            new Object[][] {
                new Object[] {
               P00BT2_A460ContratoTaxa, P00BT2_n460ContratoTaxa, P00BT2_A471ContratoSituacao, P00BT2_n471ContratoSituacao, P00BT2_A473ContratoClienteId, P00BT2_n473ContratoClienteId, P00BT2_A461ContratoSLA, P00BT2_n461ContratoSLA, P00BT2_A462ContratoJurosMora, P00BT2_n462ContratoJurosMora,
               P00BT2_A463ContratoIOFMinimo, P00BT2_n463ContratoIOFMinimo, P00BT2_A227ContratoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10contratosla ;
      private short A461ContratoSLA ;
      private int AV8ClienteId ;
      private int A473ContratoClienteId ;
      private int A227ContratoId ;
      private decimal AV9contratotaxa ;
      private decimal AV12contratojurosmora ;
      private decimal AV11contratoiofminimo ;
      private decimal A460ContratoTaxa ;
      private decimal A462ContratoJurosMora ;
      private decimal A463ContratoIOFMinimo ;
      private bool n460ContratoTaxa ;
      private bool n471ContratoSituacao ;
      private bool n473ContratoClienteId ;
      private bool n461ContratoSLA ;
      private bool n462ContratoJurosMora ;
      private bool n463ContratoIOFMinimo ;
      private string A471ContratoSituacao ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00BT2_A460ContratoTaxa ;
      private bool[] P00BT2_n460ContratoTaxa ;
      private string[] P00BT2_A471ContratoSituacao ;
      private bool[] P00BT2_n471ContratoSituacao ;
      private int[] P00BT2_A473ContratoClienteId ;
      private bool[] P00BT2_n473ContratoClienteId ;
      private short[] P00BT2_A461ContratoSLA ;
      private bool[] P00BT2_n461ContratoSLA ;
      private decimal[] P00BT2_A462ContratoJurosMora ;
      private bool[] P00BT2_n462ContratoJurosMora ;
      private decimal[] P00BT2_A463ContratoIOFMinimo ;
      private bool[] P00BT2_n463ContratoIOFMinimo ;
      private int[] P00BT2_A227ContratoId ;
      private decimal aP1_contratotaxa ;
      private short aP2_contratosla ;
      private decimal aP3_contratojurosmora ;
      private decimal aP4_contratoiofminimo ;
   }

   public class getclinicataxbyclienteid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BT2;
          prmP00BT2 = new Object[] {
          new ParDef("AV8ClienteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BT2", "SELECT ContratoTaxa, ContratoSituacao, ContratoClienteId, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoId FROM Contrato WHERE (ContratoClienteId = :AV8ClienteId) AND (Not (ContratoTaxa = 0) and Not ContratoTaxa IS NULL) AND (ContratoSituacao = ( 'Assinado')) ORDER BY ContratoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT2,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
