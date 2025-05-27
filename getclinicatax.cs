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
   public class getclinicatax : GXProcedure
   {
      public getclinicatax( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getclinicatax( IGxContext context )
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
         /* Using cursor P00AI2 */
         pr_default.execute(0, new Object[] {AV8ClienteId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133SecUserId = P00AI2_A133SecUserId[0];
            A226SecUserOwnerId = P00AI2_A226SecUserOwnerId[0];
            n226SecUserOwnerId = P00AI2_n226SecUserOwnerId[0];
            A210SecUserClienteId = P00AI2_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AI2_n210SecUserClienteId[0];
            if ( (0==A226SecUserOwnerId) || P00AI2_n226SecUserOwnerId[0] )
            {
               AV13secuserownerid = A210SecUserClienteId;
            }
            else
            {
               AV13secuserownerid = A226SecUserOwnerId;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00AI3 */
         pr_default.execute(1, new Object[] {AV13secuserownerid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A460ContratoTaxa = P00AI3_A460ContratoTaxa[0];
            n460ContratoTaxa = P00AI3_n460ContratoTaxa[0];
            A471ContratoSituacao = P00AI3_A471ContratoSituacao[0];
            n471ContratoSituacao = P00AI3_n471ContratoSituacao[0];
            A473ContratoClienteId = P00AI3_A473ContratoClienteId[0];
            n473ContratoClienteId = P00AI3_n473ContratoClienteId[0];
            A461ContratoSLA = P00AI3_A461ContratoSLA[0];
            n461ContratoSLA = P00AI3_n461ContratoSLA[0];
            A462ContratoJurosMora = P00AI3_A462ContratoJurosMora[0];
            n462ContratoJurosMora = P00AI3_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = P00AI3_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = P00AI3_n463ContratoIOFMinimo[0];
            A227ContratoId = P00AI3_A227ContratoId[0];
            AV9contratotaxa = A460ContratoTaxa;
            AV10contratosla = A461ContratoSLA;
            AV12contratojurosmora = A462ContratoJurosMora;
            AV11contratoiofminimo = A463ContratoIOFMinimo;
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         P00AI2_A133SecUserId = new short[1] ;
         P00AI2_A226SecUserOwnerId = new int[1] ;
         P00AI2_n226SecUserOwnerId = new bool[] {false} ;
         P00AI2_A210SecUserClienteId = new short[1] ;
         P00AI2_n210SecUserClienteId = new bool[] {false} ;
         P00AI3_A460ContratoTaxa = new decimal[1] ;
         P00AI3_n460ContratoTaxa = new bool[] {false} ;
         P00AI3_A471ContratoSituacao = new string[] {""} ;
         P00AI3_n471ContratoSituacao = new bool[] {false} ;
         P00AI3_A473ContratoClienteId = new int[1] ;
         P00AI3_n473ContratoClienteId = new bool[] {false} ;
         P00AI3_A461ContratoSLA = new short[1] ;
         P00AI3_n461ContratoSLA = new bool[] {false} ;
         P00AI3_A462ContratoJurosMora = new decimal[1] ;
         P00AI3_n462ContratoJurosMora = new bool[] {false} ;
         P00AI3_A463ContratoIOFMinimo = new decimal[1] ;
         P00AI3_n463ContratoIOFMinimo = new bool[] {false} ;
         P00AI3_A227ContratoId = new int[1] ;
         A471ContratoSituacao = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getclinicatax__default(),
            new Object[][] {
                new Object[] {
               P00AI2_A133SecUserId, P00AI2_A226SecUserOwnerId, P00AI2_n226SecUserOwnerId, P00AI2_A210SecUserClienteId, P00AI2_n210SecUserClienteId
               }
               , new Object[] {
               P00AI3_A460ContratoTaxa, P00AI3_n460ContratoTaxa, P00AI3_A471ContratoSituacao, P00AI3_n471ContratoSituacao, P00AI3_A473ContratoClienteId, P00AI3_n473ContratoClienteId, P00AI3_A461ContratoSLA, P00AI3_n461ContratoSLA, P00AI3_A462ContratoJurosMora, P00AI3_n462ContratoJurosMora,
               P00AI3_A463ContratoIOFMinimo, P00AI3_n463ContratoIOFMinimo, P00AI3_A227ContratoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10contratosla ;
      private short A133SecUserId ;
      private short A210SecUserClienteId ;
      private short A461ContratoSLA ;
      private int AV8ClienteId ;
      private int A226SecUserOwnerId ;
      private int AV13secuserownerid ;
      private int A473ContratoClienteId ;
      private int A227ContratoId ;
      private decimal AV9contratotaxa ;
      private decimal AV12contratojurosmora ;
      private decimal AV11contratoiofminimo ;
      private decimal A460ContratoTaxa ;
      private decimal A462ContratoJurosMora ;
      private decimal A463ContratoIOFMinimo ;
      private bool n226SecUserOwnerId ;
      private bool n210SecUserClienteId ;
      private bool n460ContratoTaxa ;
      private bool n471ContratoSituacao ;
      private bool n473ContratoClienteId ;
      private bool n461ContratoSLA ;
      private bool n462ContratoJurosMora ;
      private bool n463ContratoIOFMinimo ;
      private string A471ContratoSituacao ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00AI2_A133SecUserId ;
      private int[] P00AI2_A226SecUserOwnerId ;
      private bool[] P00AI2_n226SecUserOwnerId ;
      private short[] P00AI2_A210SecUserClienteId ;
      private bool[] P00AI2_n210SecUserClienteId ;
      private decimal[] P00AI3_A460ContratoTaxa ;
      private bool[] P00AI3_n460ContratoTaxa ;
      private string[] P00AI3_A471ContratoSituacao ;
      private bool[] P00AI3_n471ContratoSituacao ;
      private int[] P00AI3_A473ContratoClienteId ;
      private bool[] P00AI3_n473ContratoClienteId ;
      private short[] P00AI3_A461ContratoSLA ;
      private bool[] P00AI3_n461ContratoSLA ;
      private decimal[] P00AI3_A462ContratoJurosMora ;
      private bool[] P00AI3_n462ContratoJurosMora ;
      private decimal[] P00AI3_A463ContratoIOFMinimo ;
      private bool[] P00AI3_n463ContratoIOFMinimo ;
      private int[] P00AI3_A227ContratoId ;
      private decimal aP1_contratotaxa ;
      private short aP2_contratosla ;
      private decimal aP3_contratojurosmora ;
      private decimal aP4_contratoiofminimo ;
   }

   public class getclinicatax__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AI2;
          prmP00AI2 = new Object[] {
          new ParDef("AV8ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00AI3;
          prmP00AI3 = new Object[] {
          new ParDef("AV13secuserownerid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AI2", "SELECT SecUserId, SecUserOwnerId, SecUserClienteId FROM SecUser WHERE SecUserId = :AV8ClienteId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AI2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AI3", "SELECT ContratoTaxa, ContratoSituacao, ContratoClienteId, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoId FROM Contrato WHERE (ContratoClienteId = :AV13secuserownerid) AND (Not (ContratoTaxa = 0) and Not ContratoTaxa IS NULL) AND (ContratoSituacao = ( 'Assinado')) ORDER BY ContratoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AI3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
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
