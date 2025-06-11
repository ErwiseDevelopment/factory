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
   public class prenviaemaildocumentorejeitado : GXProcedure
   {
      public prenviaemaildocumentorejeitado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prenviaemaildocumentorejeitado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ReembolsoDocumentoId )
      {
         this.AV11ReembolsoDocumentoId = aP0_ReembolsoDocumentoId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_ReembolsoDocumentoId )
      {
         this.AV11ReembolsoDocumentoId = aP0_ReembolsoDocumentoId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00C52 */
         pr_default.execute(0, new Object[] {AV11ReembolsoDocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A526ReembolsoEtapaId = P00C52_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = P00C52_n526ReembolsoEtapaId[0];
            A518ReembolsoId = P00C52_A518ReembolsoId[0];
            n518ReembolsoId = P00C52_n518ReembolsoId[0];
            A529ReembolsoDocumentoId = P00C52_A529ReembolsoDocumentoId[0];
            A542ReembolsoPropostaId = P00C52_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00C52_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C52_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C52_n558ReembolsoPropostaPacienteClienteId[0];
            A518ReembolsoId = P00C52_A518ReembolsoId[0];
            n518ReembolsoId = P00C52_n518ReembolsoId[0];
            A542ReembolsoPropostaId = P00C52_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00C52_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C52_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C52_n558ReembolsoPropostaPacienteClienteId[0];
            AV12reembolsopropostaid = A542ReembolsoPropostaId;
            AV13ReembolsoPropostaPacienteClienteId = A558ReembolsoPropostaPacienteClienteId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00C53 */
         pr_default.execute(1, new Object[] {AV13ReembolsoPropostaPacienteClienteId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A168ClienteId = P00C53_A168ClienteId[0];
            A170ClienteRazaoSocial = P00C53_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C53_n170ClienteRazaoSocial[0];
            AV14ClienteRazaoSocial = A170ClienteRazaoSocial;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P00C54 */
         pr_default.execute(2, new Object[] {AV12reembolsopropostaid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A323PropostaId = P00C54_A323PropostaId[0];
            A328PropostaCratedBy = P00C54_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00C54_n328PropostaCratedBy[0];
            AV15PropostaCratedBy = A328PropostaCratedBy;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         /* Using cursor P00C55 */
         pr_default.execute(3, new Object[] {AV15PropostaCratedBy});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A133SecUserId = P00C55_A133SecUserId[0];
            A144SecUserEmail = P00C55_A144SecUserEmail[0];
            n144SecUserEmail = P00C55_n144SecUserEmail[0];
            AV16SecUserEmail = A144SecUserEmail;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         GXt_char1 = AV10HTML;
         new premaildocumentorejeitado(context ).execute(  AV14ClienteRazaoSocial, out  GXt_char1) ;
         AV10HTML = GXt_char1;
         AV17Array_Email = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17Array_Email.Add(AV16SecUserEmail, 0);
         new sendemail(context ).execute(  "Documento reprovado",  AV10HTML,  AV17Array_Email, out  AV18Message) ;
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
         P00C52_A526ReembolsoEtapaId = new int[1] ;
         P00C52_n526ReembolsoEtapaId = new bool[] {false} ;
         P00C52_A518ReembolsoId = new int[1] ;
         P00C52_n518ReembolsoId = new bool[] {false} ;
         P00C52_A529ReembolsoDocumentoId = new int[1] ;
         P00C52_A542ReembolsoPropostaId = new int[1] ;
         P00C52_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C52_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C52_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C53_A168ClienteId = new int[1] ;
         P00C53_A170ClienteRazaoSocial = new string[] {""} ;
         P00C53_n170ClienteRazaoSocial = new bool[] {false} ;
         A170ClienteRazaoSocial = "";
         AV14ClienteRazaoSocial = "";
         P00C54_A323PropostaId = new int[1] ;
         P00C54_A328PropostaCratedBy = new short[1] ;
         P00C54_n328PropostaCratedBy = new bool[] {false} ;
         P00C55_A133SecUserId = new short[1] ;
         P00C55_A144SecUserEmail = new string[] {""} ;
         P00C55_n144SecUserEmail = new bool[] {false} ;
         A144SecUserEmail = "";
         AV16SecUserEmail = "";
         AV10HTML = "";
         GXt_char1 = "";
         AV17Array_Email = new GxSimpleCollection<string>();
         AV18Message = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prenviaemaildocumentorejeitado__default(),
            new Object[][] {
                new Object[] {
               P00C52_A526ReembolsoEtapaId, P00C52_n526ReembolsoEtapaId, P00C52_A518ReembolsoId, P00C52_n518ReembolsoId, P00C52_A529ReembolsoDocumentoId, P00C52_A542ReembolsoPropostaId, P00C52_n542ReembolsoPropostaId, P00C52_A558ReembolsoPropostaPacienteClienteId, P00C52_n558ReembolsoPropostaPacienteClienteId
               }
               , new Object[] {
               P00C53_A168ClienteId, P00C53_A170ClienteRazaoSocial, P00C53_n170ClienteRazaoSocial
               }
               , new Object[] {
               P00C54_A323PropostaId, P00C54_A328PropostaCratedBy, P00C54_n328PropostaCratedBy
               }
               , new Object[] {
               P00C55_A133SecUserId, P00C55_A144SecUserEmail, P00C55_n144SecUserEmail
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A328PropostaCratedBy ;
      private short AV15PropostaCratedBy ;
      private short A133SecUserId ;
      private int AV11ReembolsoDocumentoId ;
      private int A526ReembolsoEtapaId ;
      private int A518ReembolsoId ;
      private int A529ReembolsoDocumentoId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int AV12reembolsopropostaid ;
      private int AV13ReembolsoPropostaPacienteClienteId ;
      private int A168ClienteId ;
      private int A323PropostaId ;
      private string GXt_char1 ;
      private bool n526ReembolsoEtapaId ;
      private bool n518ReembolsoId ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n328PropostaCratedBy ;
      private bool n144SecUserEmail ;
      private string AV10HTML ;
      private string A170ClienteRazaoSocial ;
      private string AV14ClienteRazaoSocial ;
      private string A144SecUserEmail ;
      private string AV16SecUserEmail ;
      private string AV18Message ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00C52_A526ReembolsoEtapaId ;
      private bool[] P00C52_n526ReembolsoEtapaId ;
      private int[] P00C52_A518ReembolsoId ;
      private bool[] P00C52_n518ReembolsoId ;
      private int[] P00C52_A529ReembolsoDocumentoId ;
      private int[] P00C52_A542ReembolsoPropostaId ;
      private bool[] P00C52_n542ReembolsoPropostaId ;
      private int[] P00C52_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C52_n558ReembolsoPropostaPacienteClienteId ;
      private int[] P00C53_A168ClienteId ;
      private string[] P00C53_A170ClienteRazaoSocial ;
      private bool[] P00C53_n170ClienteRazaoSocial ;
      private int[] P00C54_A323PropostaId ;
      private short[] P00C54_A328PropostaCratedBy ;
      private bool[] P00C54_n328PropostaCratedBy ;
      private short[] P00C55_A133SecUserId ;
      private string[] P00C55_A144SecUserEmail ;
      private bool[] P00C55_n144SecUserEmail ;
      private GxSimpleCollection<string> AV17Array_Email ;
   }

   public class prenviaemaildocumentorejeitado__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C52;
          prmP00C52 = new Object[] {
          new ParDef("AV11ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmP00C53;
          prmP00C53 = new Object[] {
          new ParDef("AV13ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00C54;
          prmP00C54 = new Object[] {
          new ParDef("AV12reembolsopropostaid",GXType.Int32,9,0)
          };
          Object[] prmP00C55;
          prmP00C55 = new Object[] {
          new ParDef("AV15PropostaCratedBy",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C52", "SELECT T1.ReembolsoEtapaId, T2.ReembolsoId, T1.ReembolsoDocumentoId, T3.ReembolsoPropostaId AS ReembolsoPropostaId, T4.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId FROM (((ReembolsoDocumento T1 LEFT JOIN ReembolsoEtapa T2 ON T2.ReembolsoEtapaId = T1.ReembolsoEtapaId) LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T2.ReembolsoId) LEFT JOIN Proposta T4 ON T4.PropostaId = T3.ReembolsoPropostaId) WHERE T1.ReembolsoDocumentoId = :AV11ReembolsoDocumentoId ORDER BY T1.ReembolsoDocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C52,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C53", "SELECT ClienteId, ClienteRazaoSocial FROM Cliente WHERE ClienteId = :AV13ReembolsoPropostaPacienteClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C53,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C54", "SELECT PropostaId, PropostaCratedBy FROM Proposta WHERE PropostaId = :AV12reembolsopropostaid ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C54,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C55", "SELECT SecUserId, SecUserEmail FROM SecUser WHERE SecUserId = :AV15PropostaCratedBy ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C55,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
