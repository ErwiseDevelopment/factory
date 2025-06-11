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
   public class prenviacomunicadocontratoparticipante : GXProcedure
   {
      public prenviacomunicadocontratoparticipante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prenviacomunicadocontratoparticipante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_AssinaturaParticipanteId ,
                           string aP1_BaseUrl )
      {
         this.AV8AssinaturaParticipanteId = aP0_AssinaturaParticipanteId;
         this.AV27BaseUrl = aP1_BaseUrl;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_AssinaturaParticipanteId ,
                                 string aP1_BaseUrl )
      {
         this.AV8AssinaturaParticipanteId = aP0_AssinaturaParticipanteId;
         this.AV27BaseUrl = aP1_BaseUrl;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9AssinaturaParticipanteNotificacao = new SdtAssinaturaParticipanteNotificacao(context);
         AV9AssinaturaParticipanteNotificacao.gxTpr_Assinaturaparticipanteid = AV8AssinaturaParticipanteId;
         AV9AssinaturaParticipanteNotificacao.gxTpr_Assinaturaparticipantenotificacaodata = DateTimeUtil.ServerNow( context, pr_default);
         AV9AssinaturaParticipanteNotificacao.gxTpr_Assinaturaparticipantenotificacaostatus = "Enviando";
         AV9AssinaturaParticipanteNotificacao.Save();
         if ( AV9AssinaturaParticipanteNotificacao.Success() )
         {
            context.CommitDataStores("prenviacomunicadocontratoparticipante",pr_default);
         }
         else
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P007I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A253EmpresaSede = P007I2_A253EmpresaSede[0];
            n253EmpresaSede = P007I2_n253EmpresaSede[0];
            A251EmpresaRazaoSocial = P007I2_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = P007I2_n251EmpresaRazaoSocial[0];
            A249EmpresaId = P007I2_A249EmpresaId[0];
            AV23EmpresaRazaoSocial = A251EmpresaRazaoSocial;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P007I3 */
         pr_default.execute(1, new Object[] {AV8AssinaturaParticipanteId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A227ContratoId = P007I3_A227ContratoId[0];
            n227ContratoId = P007I3_n227ContratoId[0];
            A242AssinaturaParticipanteId = P007I3_A242AssinaturaParticipanteId[0];
            A238AssinaturaId = P007I3_A238AssinaturaId[0];
            n238AssinaturaId = P007I3_n238AssinaturaId[0];
            A233ParticipanteId = P007I3_A233ParticipanteId[0];
            n233ParticipanteId = P007I3_n233ParticipanteId[0];
            A248ParticipanteNome = P007I3_A248ParticipanteNome[0];
            n248ParticipanteNome = P007I3_n248ParticipanteNome[0];
            A228ContratoNome = P007I3_A228ContratoNome[0];
            n228ContratoNome = P007I3_n228ContratoNome[0];
            A235ParticipanteEmail = P007I3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007I3_n235ParticipanteEmail[0];
            A354AssinaturaParticipanteLink = P007I3_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = P007I3_n354AssinaturaParticipanteLink[0];
            A227ContratoId = P007I3_A227ContratoId[0];
            n227ContratoId = P007I3_n227ContratoId[0];
            A228ContratoNome = P007I3_A228ContratoNome[0];
            n228ContratoNome = P007I3_n228ContratoNome[0];
            A248ParticipanteNome = P007I3_A248ParticipanteNome[0];
            n248ParticipanteNome = P007I3_n248ParticipanteNome[0];
            A235ParticipanteEmail = P007I3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007I3_n235ParticipanteEmail[0];
            AV19AssinaturaId = A238AssinaturaId;
            AV20ParticipanteId = A233ParticipanteId;
            AV21ParticipanteNome = A248ParticipanteNome;
            AV22ContratoNome = A228ContratoNome;
            AV24ParticipanteEmail = A235ParticipanteEmail;
            AV29AssinaturaParticipanteLink = A354AssinaturaParticipanteLink;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV17Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         /* Using cursor P007I4 */
         pr_default.execute(2, new Object[] {AV19AssinaturaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A238AssinaturaId = P007I4_A238AssinaturaId[0];
            n238AssinaturaId = P007I4_n238AssinaturaId[0];
            A233ParticipanteId = P007I4_A233ParticipanteId[0];
            n233ParticipanteId = P007I4_n233ParticipanteId[0];
            A248ParticipanteNome = P007I4_A248ParticipanteNome[0];
            n248ParticipanteNome = P007I4_n248ParticipanteNome[0];
            A234ParticipanteDocumento = P007I4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P007I4_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P007I4_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007I4_n235ParticipanteEmail[0];
            A247AssinaturaParticipanteTipo = P007I4_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = P007I4_n247AssinaturaParticipanteTipo[0];
            A242AssinaturaParticipanteId = P007I4_A242AssinaturaParticipanteId[0];
            A248ParticipanteNome = P007I4_A248ParticipanteNome[0];
            n248ParticipanteNome = P007I4_n248ParticipanteNome[0];
            A234ParticipanteDocumento = P007I4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P007I4_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P007I4_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007I4_n235ParticipanteEmail[0];
            AV18SdParticipantes = new SdtSdParticipantes(context);
            AV18SdParticipantes.gxTpr_Participanteid = A233ParticipanteId;
            AV18SdParticipantes.gxTpr_Participantenome = A248ParticipanteNome;
            AV18SdParticipantes.gxTpr_Participantedocumento = A234ParticipanteDocumento;
            AV18SdParticipantes.gxTpr_Participanteemail = A235ParticipanteEmail;
            AV18SdParticipantes.gxTpr_Assinaturaparticipantetipo = A247AssinaturaParticipanteTipo;
            AV17Array_SdParticipantes.Add(AV18SdParticipantes, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         GXt_char1 = AV15HTML;
         new emailassinatura(context ).execute(  AV17Array_SdParticipantes,  AV20ParticipanteId,  AV21ParticipanteNome,  AV22ContratoNome,  AV23EmpresaRazaoSocial,  AV29AssinaturaParticipanteLink, out  GXt_char1) ;
         AV15HTML = GXt_char1;
         AV13Email = AV24ParticipanteEmail;
         AV14Array_Email.Add(AV13Email, 0);
         new sendemail(context ).execute(  "Contrato para assinatura",  AV15HTML,  AV14Array_Email, out  AV26message) ;
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
         AV9AssinaturaParticipanteNotificacao = new SdtAssinaturaParticipanteNotificacao(context);
         P007I2_A253EmpresaSede = new bool[] {false} ;
         P007I2_n253EmpresaSede = new bool[] {false} ;
         P007I2_A251EmpresaRazaoSocial = new string[] {""} ;
         P007I2_n251EmpresaRazaoSocial = new bool[] {false} ;
         P007I2_A249EmpresaId = new int[1] ;
         A251EmpresaRazaoSocial = "";
         AV23EmpresaRazaoSocial = "";
         P007I3_A227ContratoId = new int[1] ;
         P007I3_n227ContratoId = new bool[] {false} ;
         P007I3_A242AssinaturaParticipanteId = new int[1] ;
         P007I3_A238AssinaturaId = new long[1] ;
         P007I3_n238AssinaturaId = new bool[] {false} ;
         P007I3_A233ParticipanteId = new int[1] ;
         P007I3_n233ParticipanteId = new bool[] {false} ;
         P007I3_A248ParticipanteNome = new string[] {""} ;
         P007I3_n248ParticipanteNome = new bool[] {false} ;
         P007I3_A228ContratoNome = new string[] {""} ;
         P007I3_n228ContratoNome = new bool[] {false} ;
         P007I3_A235ParticipanteEmail = new string[] {""} ;
         P007I3_n235ParticipanteEmail = new bool[] {false} ;
         P007I3_A354AssinaturaParticipanteLink = new string[] {""} ;
         P007I3_n354AssinaturaParticipanteLink = new bool[] {false} ;
         A248ParticipanteNome = "";
         A228ContratoNome = "";
         A235ParticipanteEmail = "";
         A354AssinaturaParticipanteLink = "";
         AV21ParticipanteNome = "";
         AV22ContratoNome = "";
         AV24ParticipanteEmail = "";
         AV29AssinaturaParticipanteLink = "";
         AV17Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         P007I4_A238AssinaturaId = new long[1] ;
         P007I4_n238AssinaturaId = new bool[] {false} ;
         P007I4_A233ParticipanteId = new int[1] ;
         P007I4_n233ParticipanteId = new bool[] {false} ;
         P007I4_A248ParticipanteNome = new string[] {""} ;
         P007I4_n248ParticipanteNome = new bool[] {false} ;
         P007I4_A234ParticipanteDocumento = new string[] {""} ;
         P007I4_n234ParticipanteDocumento = new bool[] {false} ;
         P007I4_A235ParticipanteEmail = new string[] {""} ;
         P007I4_n235ParticipanteEmail = new bool[] {false} ;
         P007I4_A247AssinaturaParticipanteTipo = new string[] {""} ;
         P007I4_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         P007I4_A242AssinaturaParticipanteId = new int[1] ;
         A234ParticipanteDocumento = "";
         A247AssinaturaParticipanteTipo = "";
         AV18SdParticipantes = new SdtSdParticipantes(context);
         AV15HTML = "";
         GXt_char1 = "";
         AV13Email = "";
         AV14Array_Email = new GxSimpleCollection<string>();
         AV26message = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prenviacomunicadocontratoparticipante__default(),
            new Object[][] {
                new Object[] {
               P007I2_A253EmpresaSede, P007I2_n253EmpresaSede, P007I2_A251EmpresaRazaoSocial, P007I2_n251EmpresaRazaoSocial, P007I2_A249EmpresaId
               }
               , new Object[] {
               P007I3_A227ContratoId, P007I3_n227ContratoId, P007I3_A242AssinaturaParticipanteId, P007I3_A238AssinaturaId, P007I3_n238AssinaturaId, P007I3_A233ParticipanteId, P007I3_n233ParticipanteId, P007I3_A248ParticipanteNome, P007I3_n248ParticipanteNome, P007I3_A228ContratoNome,
               P007I3_n228ContratoNome, P007I3_A235ParticipanteEmail, P007I3_n235ParticipanteEmail, P007I3_A354AssinaturaParticipanteLink, P007I3_n354AssinaturaParticipanteLink
               }
               , new Object[] {
               P007I4_A238AssinaturaId, P007I4_n238AssinaturaId, P007I4_A233ParticipanteId, P007I4_n233ParticipanteId, P007I4_A248ParticipanteNome, P007I4_n248ParticipanteNome, P007I4_A234ParticipanteDocumento, P007I4_n234ParticipanteDocumento, P007I4_A235ParticipanteEmail, P007I4_n235ParticipanteEmail,
               P007I4_A247AssinaturaParticipanteTipo, P007I4_n247AssinaturaParticipanteTipo, P007I4_A242AssinaturaParticipanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8AssinaturaParticipanteId ;
      private int A249EmpresaId ;
      private int A227ContratoId ;
      private int A242AssinaturaParticipanteId ;
      private int A233ParticipanteId ;
      private int AV20ParticipanteId ;
      private long A238AssinaturaId ;
      private long AV19AssinaturaId ;
      private string GXt_char1 ;
      private bool A253EmpresaSede ;
      private bool n253EmpresaSede ;
      private bool n251EmpresaRazaoSocial ;
      private bool n227ContratoId ;
      private bool n238AssinaturaId ;
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n228ContratoNome ;
      private bool n235ParticipanteEmail ;
      private bool n354AssinaturaParticipanteLink ;
      private bool n234ParticipanteDocumento ;
      private bool n247AssinaturaParticipanteTipo ;
      private string AV15HTML ;
      private string AV27BaseUrl ;
      private string A251EmpresaRazaoSocial ;
      private string AV23EmpresaRazaoSocial ;
      private string A248ParticipanteNome ;
      private string A228ContratoNome ;
      private string A235ParticipanteEmail ;
      private string A354AssinaturaParticipanteLink ;
      private string AV21ParticipanteNome ;
      private string AV22ContratoNome ;
      private string AV24ParticipanteEmail ;
      private string AV29AssinaturaParticipanteLink ;
      private string A234ParticipanteDocumento ;
      private string A247AssinaturaParticipanteTipo ;
      private string AV13Email ;
      private string AV26message ;
      private IGxDataStore dsDefault ;
      private SdtAssinaturaParticipanteNotificacao AV9AssinaturaParticipanteNotificacao ;
      private IDataStoreProvider pr_default ;
      private bool[] P007I2_A253EmpresaSede ;
      private bool[] P007I2_n253EmpresaSede ;
      private string[] P007I2_A251EmpresaRazaoSocial ;
      private bool[] P007I2_n251EmpresaRazaoSocial ;
      private int[] P007I2_A249EmpresaId ;
      private int[] P007I3_A227ContratoId ;
      private bool[] P007I3_n227ContratoId ;
      private int[] P007I3_A242AssinaturaParticipanteId ;
      private long[] P007I3_A238AssinaturaId ;
      private bool[] P007I3_n238AssinaturaId ;
      private int[] P007I3_A233ParticipanteId ;
      private bool[] P007I3_n233ParticipanteId ;
      private string[] P007I3_A248ParticipanteNome ;
      private bool[] P007I3_n248ParticipanteNome ;
      private string[] P007I3_A228ContratoNome ;
      private bool[] P007I3_n228ContratoNome ;
      private string[] P007I3_A235ParticipanteEmail ;
      private bool[] P007I3_n235ParticipanteEmail ;
      private string[] P007I3_A354AssinaturaParticipanteLink ;
      private bool[] P007I3_n354AssinaturaParticipanteLink ;
      private GXBaseCollection<SdtSdParticipantes> AV17Array_SdParticipantes ;
      private long[] P007I4_A238AssinaturaId ;
      private bool[] P007I4_n238AssinaturaId ;
      private int[] P007I4_A233ParticipanteId ;
      private bool[] P007I4_n233ParticipanteId ;
      private string[] P007I4_A248ParticipanteNome ;
      private bool[] P007I4_n248ParticipanteNome ;
      private string[] P007I4_A234ParticipanteDocumento ;
      private bool[] P007I4_n234ParticipanteDocumento ;
      private string[] P007I4_A235ParticipanteEmail ;
      private bool[] P007I4_n235ParticipanteEmail ;
      private string[] P007I4_A247AssinaturaParticipanteTipo ;
      private bool[] P007I4_n247AssinaturaParticipanteTipo ;
      private int[] P007I4_A242AssinaturaParticipanteId ;
      private SdtSdParticipantes AV18SdParticipantes ;
      private GxSimpleCollection<string> AV14Array_Email ;
   }

   public class prenviacomunicadocontratoparticipante__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007I2;
          prmP007I2 = new Object[] {
          };
          Object[] prmP007I3;
          prmP007I3 = new Object[] {
          new ParDef("AV8AssinaturaParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmP007I4;
          prmP007I4 = new Object[] {
          new ParDef("AV19AssinaturaId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007I2", "SELECT EmpresaSede, EmpresaRazaoSocial, EmpresaId FROM Empresa WHERE EmpresaSede ORDER BY EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007I3", "SELECT T2.ContratoId, T1.AssinaturaParticipanteId, T1.AssinaturaId, T1.ParticipanteId, T4.ParticipanteNome, T3.ContratoNome, T4.ParticipanteEmail, T1.AssinaturaParticipanteLink FROM (((AssinaturaParticipante T1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = T1.AssinaturaId) LEFT JOIN Contrato T3 ON T3.ContratoId = T2.ContratoId) LEFT JOIN Participante T4 ON T4.ParticipanteId = T1.ParticipanteId) WHERE T1.AssinaturaParticipanteId = :AV8AssinaturaParticipanteId ORDER BY T1.AssinaturaParticipanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007I4", "SELECT T1.AssinaturaId, T1.ParticipanteId, T2.ParticipanteNome, T2.ParticipanteDocumento, T2.ParticipanteEmail, T1.AssinaturaParticipanteTipo, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE T1.AssinaturaId = :AV19AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
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
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
