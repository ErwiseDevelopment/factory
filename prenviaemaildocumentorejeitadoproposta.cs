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
   public class prenviaemaildocumentorejeitadoproposta : GXProcedure
   {
      public prenviaemaildocumentorejeitadoproposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prenviaemaildocumentorejeitadoproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_propostaid )
      {
         this.AV19propostaid = aP0_propostaid;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_propostaid )
      {
         this.AV19propostaid = aP0_propostaid;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CD2 */
         pr_default.execute(0, new Object[] {AV19propostaid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A504PropostaPacienteClienteId = P00CD2_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00CD2_n504PropostaPacienteClienteId[0];
            A323PropostaId = P00CD2_A323PropostaId[0];
            A328PropostaCratedBy = P00CD2_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00CD2_n328PropostaCratedBy[0];
            A505PropostaPacienteClienteRazaoSocial = P00CD2_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00CD2_n505PropostaPacienteClienteRazaoSocial[0];
            A505PropostaPacienteClienteRazaoSocial = P00CD2_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00CD2_n505PropostaPacienteClienteRazaoSocial[0];
            AV15PropostaCratedBy = A328PropostaCratedBy;
            AV14ClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00CD3 */
         pr_default.execute(1, new Object[] {AV15PropostaCratedBy});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A133SecUserId = P00CD3_A133SecUserId[0];
            A144SecUserEmail = P00CD3_A144SecUserEmail[0];
            n144SecUserEmail = P00CD3_n144SecUserEmail[0];
            AV16SecUserEmail = A144SecUserEmail;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         P00CD2_A504PropostaPacienteClienteId = new int[1] ;
         P00CD2_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00CD2_A323PropostaId = new int[1] ;
         P00CD2_A328PropostaCratedBy = new short[1] ;
         P00CD2_n328PropostaCratedBy = new bool[] {false} ;
         P00CD2_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00CD2_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         AV14ClienteRazaoSocial = "";
         P00CD3_A133SecUserId = new short[1] ;
         P00CD3_A144SecUserEmail = new string[] {""} ;
         P00CD3_n144SecUserEmail = new bool[] {false} ;
         A144SecUserEmail = "";
         AV16SecUserEmail = "";
         AV10HTML = "";
         GXt_char1 = "";
         AV17Array_Email = new GxSimpleCollection<string>();
         AV18Message = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prenviaemaildocumentorejeitadoproposta__default(),
            new Object[][] {
                new Object[] {
               P00CD2_A504PropostaPacienteClienteId, P00CD2_n504PropostaPacienteClienteId, P00CD2_A323PropostaId, P00CD2_A328PropostaCratedBy, P00CD2_n328PropostaCratedBy, P00CD2_A505PropostaPacienteClienteRazaoSocial, P00CD2_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               P00CD3_A133SecUserId, P00CD3_A144SecUserEmail, P00CD3_n144SecUserEmail
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A328PropostaCratedBy ;
      private short AV15PropostaCratedBy ;
      private short A133SecUserId ;
      private int AV19propostaid ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private string GXt_char1 ;
      private bool n504PropostaPacienteClienteId ;
      private bool n328PropostaCratedBy ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n144SecUserEmail ;
      private string AV10HTML ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string AV14ClienteRazaoSocial ;
      private string A144SecUserEmail ;
      private string AV16SecUserEmail ;
      private string AV18Message ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00CD2_A504PropostaPacienteClienteId ;
      private bool[] P00CD2_n504PropostaPacienteClienteId ;
      private int[] P00CD2_A323PropostaId ;
      private short[] P00CD2_A328PropostaCratedBy ;
      private bool[] P00CD2_n328PropostaCratedBy ;
      private string[] P00CD2_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00CD2_n505PropostaPacienteClienteRazaoSocial ;
      private short[] P00CD3_A133SecUserId ;
      private string[] P00CD3_A144SecUserEmail ;
      private bool[] P00CD3_n144SecUserEmail ;
      private GxSimpleCollection<string> AV17Array_Email ;
   }

   public class prenviaemaildocumentorejeitadoproposta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CD2;
          prmP00CD2 = new Object[] {
          new ParDef("AV19propostaid",GXType.Int32,9,0)
          };
          Object[] prmP00CD3;
          prmP00CD3 = new Object[] {
          new ParDef("AV15PropostaCratedBy",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CD2", "SELECT T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T1.PropostaCratedBy, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV19propostaid ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CD2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CD3", "SELECT SecUserId, SecUserEmail FROM SecUser WHERE SecUserId = :AV15PropostaCratedBy ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CD3,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
