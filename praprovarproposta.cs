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
   public class praprovarproposta : GXProcedure
   {
      public praprovarproposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public praprovarproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           string aP1_Comentario ,
                           out SdtSdErro aP2_SdErro )
      {
         this.AV17PropostaId = aP0_PropostaId;
         this.AV11Comentario = aP1_Comentario;
         this.AV18SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV18SdErro;
      }

      public SdtSdErro executeUdp( int aP0_PropostaId ,
                                   string aP1_Comentario )
      {
         execute(aP0_PropostaId, aP1_Comentario, out aP2_SdErro);
         return AV18SdErro ;
      }

      public void executeSubmit( int aP0_PropostaId ,
                                 string aP1_Comentario ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.AV17PropostaId = aP0_PropostaId;
         this.AV11Comentario = aP1_Comentario;
         this.AV18SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV18SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18SdErro = new SdtSdErro(context);
         GXt_SdtWWPContext1 = AV19WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV19WWPContext = GXt_SdtWWPContext1;
         AV9Aprovacao = new SdtAprovacao(context);
         AV9Aprovacao.gxTpr_Aprovadoresid = AV19WWPContext.gxTpr_Aprovadorid;
         AV9Aprovacao.gxTpr_Propostaid = AV17PropostaId;
         AV9Aprovacao.gxTpr_Aprovacaoem = DateTimeUtil.ServerNow( context, pr_default);
         AV9Aprovacao.gxTpr_Aprovacaodecisao = AV11Comentario;
         AV9Aprovacao.gxTpr_Aprovacaostatus = "APROVADO";
         AV9Aprovacao.Save();
         if ( AV9Aprovacao.Success() )
         {
            context.CommitDataStores("praprovarproposta",pr_default);
         }
         else
         {
            context.RollbackDataStores("praprovarproposta",pr_default);
            AV18SdErro.gxTpr_Status = 401;
            AV18SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV9Aprovacao.GetMessages().Item(1)).gxTpr_Description;
            cleanup();
            if (true) return;
         }
         /* Using cursor P009T3 */
         pr_default.execute(0, new Object[] {AV17PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A323PropostaId = P009T3_A323PropostaId[0];
            n323PropostaId = P009T3_n323PropostaId[0];
            A504PropostaPacienteClienteId = P009T3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P009T3_n504PropostaPacienteClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P009T3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009T3_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = P009T3_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P009T3_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = P009T3_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = P009T3_n541PropostaPacienteContatoEmail[0];
            A341PropostaAprovacoes_F = P009T3_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009T3_n341PropostaAprovacoes_F[0];
            A330PropostaQuantidadeAprovadores = P009T3_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = P009T3_n330PropostaQuantidadeAprovadores[0];
            A341PropostaAprovacoes_F = P009T3_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009T3_n341PropostaAprovacoes_F[0];
            A505PropostaPacienteClienteRazaoSocial = P009T3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009T3_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = P009T3_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P009T3_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = P009T3_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = P009T3_n541PropostaPacienteContatoEmail[0];
            A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
            AV16PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            AV10ClienteId = A504PropostaPacienteClienteId;
            AV26ClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AV27ClienteDocumento = A540PropostaPacienteClienteDocumento;
            AV28ContatoEmail = A541PropostaPacienteContatoEmail;
            AV31NomeCLienteRazaoSocial = StringUtil.StringReplace( AV26ClienteRazaoSocial, " ", "_");
            AV30ContratoNome = StringUtil.Format( "PP_%1_%2", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0), AV31NomeCLienteRazaoSocial, "", "", "", "", "", "", "");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV34IsAchou = false;
         /* Using cursor P009T4 */
         pr_default.execute(1, new Object[] {AV10ClienteId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A168ClienteId = P009T4_A168ClienteId[0];
            n168ClienteId = P009T4_n168ClienteId[0];
            A552ReponsavelClienteId = P009T4_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = P009T4_n552ReponsavelClienteId[0];
            A551ClienteReponsavelId = P009T4_A551ClienteReponsavelId[0];
            AV34IsAchou = true;
            AV10ClienteId = A552ReponsavelClienteId;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV34IsAchou )
         {
            /* Using cursor P009T5 */
            pr_default.execute(2, new Object[] {AV10ClienteId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A168ClienteId = P009T5_A168ClienteId[0];
               n168ClienteId = P009T5_n168ClienteId[0];
               A170ClienteRazaoSocial = P009T5_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = P009T5_n170ClienteRazaoSocial[0];
               A169ClienteDocumento = P009T5_A169ClienteDocumento[0];
               n169ClienteDocumento = P009T5_n169ClienteDocumento[0];
               A201ContatoEmail = P009T5_A201ContatoEmail[0];
               n201ContatoEmail = P009T5_n201ContatoEmail[0];
               AV26ClienteRazaoSocial = A170ClienteRazaoSocial;
               AV27ClienteDocumento = A169ClienteDocumento;
               AV28ContatoEmail = A201ContatoEmail;
               AV31NomeCLienteRazaoSocial = StringUtil.StringReplace( AV26ClienteRazaoSocial, " ", "_");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
         if ( (0==AV16PropostaAprovacoesRestantes_F) )
         {
            AV33Proposta.Load(AV17PropostaId);
            AV33Proposta.gxTpr_Propostastatus = "AGUARDANDO_ASSINATURA";
            AV33Proposta.Save();
            if ( AV33Proposta.Success() )
            {
               context.CommitDataStores("praprovarproposta",pr_default);
            }
         }
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
         AV18SdErro = new SdtSdErro(context);
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9Aprovacao = new SdtAprovacao(context);
         P009T3_A323PropostaId = new int[1] ;
         P009T3_n323PropostaId = new bool[] {false} ;
         P009T3_A504PropostaPacienteClienteId = new int[1] ;
         P009T3_n504PropostaPacienteClienteId = new bool[] {false} ;
         P009T3_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P009T3_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P009T3_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P009T3_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P009T3_A541PropostaPacienteContatoEmail = new string[] {""} ;
         P009T3_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         P009T3_A341PropostaAprovacoes_F = new short[1] ;
         P009T3_n341PropostaAprovacoes_F = new bool[] {false} ;
         P009T3_A330PropostaQuantidadeAprovadores = new short[1] ;
         P009T3_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A541PropostaPacienteContatoEmail = "";
         AV26ClienteRazaoSocial = "";
         AV27ClienteDocumento = "";
         AV28ContatoEmail = "";
         AV31NomeCLienteRazaoSocial = "";
         AV30ContratoNome = "";
         P009T4_A168ClienteId = new int[1] ;
         P009T4_n168ClienteId = new bool[] {false} ;
         P009T4_A552ReponsavelClienteId = new int[1] ;
         P009T4_n552ReponsavelClienteId = new bool[] {false} ;
         P009T4_A551ClienteReponsavelId = new int[1] ;
         P009T5_A168ClienteId = new int[1] ;
         P009T5_n168ClienteId = new bool[] {false} ;
         P009T5_A170ClienteRazaoSocial = new string[] {""} ;
         P009T5_n170ClienteRazaoSocial = new bool[] {false} ;
         P009T5_A169ClienteDocumento = new string[] {""} ;
         P009T5_n169ClienteDocumento = new bool[] {false} ;
         P009T5_A201ContatoEmail = new string[] {""} ;
         P009T5_n201ContatoEmail = new bool[] {false} ;
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A201ContatoEmail = "";
         AV33Proposta = new SdtProposta(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.praprovarproposta__default(),
            new Object[][] {
                new Object[] {
               P009T3_A323PropostaId, P009T3_A504PropostaPacienteClienteId, P009T3_n504PropostaPacienteClienteId, P009T3_A505PropostaPacienteClienteRazaoSocial, P009T3_n505PropostaPacienteClienteRazaoSocial, P009T3_A540PropostaPacienteClienteDocumento, P009T3_n540PropostaPacienteClienteDocumento, P009T3_A541PropostaPacienteContatoEmail, P009T3_n541PropostaPacienteContatoEmail, P009T3_A341PropostaAprovacoes_F,
               P009T3_n341PropostaAprovacoes_F, P009T3_A330PropostaQuantidadeAprovadores, P009T3_n330PropostaQuantidadeAprovadores
               }
               , new Object[] {
               P009T4_A168ClienteId, P009T4_n168ClienteId, P009T4_A552ReponsavelClienteId, P009T4_n552ReponsavelClienteId, P009T4_A551ClienteReponsavelId
               }
               , new Object[] {
               P009T5_A168ClienteId, P009T5_A170ClienteRazaoSocial, P009T5_n170ClienteRazaoSocial, P009T5_A169ClienteDocumento, P009T5_n169ClienteDocumento, P009T5_A201ContatoEmail, P009T5_n201ContatoEmail
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A341PropostaAprovacoes_F ;
      private short A330PropostaQuantidadeAprovadores ;
      private short A343PropostaAprovacoesRestantes_F ;
      private short AV16PropostaAprovacoesRestantes_F ;
      private int AV17PropostaId ;
      private int A323PropostaId ;
      private int A504PropostaPacienteClienteId ;
      private int AV10ClienteId ;
      private int A168ClienteId ;
      private int A552ReponsavelClienteId ;
      private int A551ClienteReponsavelId ;
      private bool n323PropostaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n341PropostaAprovacoes_F ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool AV34IsAchou ;
      private bool n168ClienteId ;
      private bool n552ReponsavelClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n201ContatoEmail ;
      private string AV11Comentario ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A541PropostaPacienteContatoEmail ;
      private string AV26ClienteRazaoSocial ;
      private string AV27ClienteDocumento ;
      private string AV28ContatoEmail ;
      private string AV31NomeCLienteRazaoSocial ;
      private string AV30ContratoNome ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A201ContatoEmail ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV18SdErro ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtAprovacao AV9Aprovacao ;
      private IDataStoreProvider pr_default ;
      private int[] P009T3_A323PropostaId ;
      private bool[] P009T3_n323PropostaId ;
      private int[] P009T3_A504PropostaPacienteClienteId ;
      private bool[] P009T3_n504PropostaPacienteClienteId ;
      private string[] P009T3_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P009T3_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P009T3_A540PropostaPacienteClienteDocumento ;
      private bool[] P009T3_n540PropostaPacienteClienteDocumento ;
      private string[] P009T3_A541PropostaPacienteContatoEmail ;
      private bool[] P009T3_n541PropostaPacienteContatoEmail ;
      private short[] P009T3_A341PropostaAprovacoes_F ;
      private bool[] P009T3_n341PropostaAprovacoes_F ;
      private short[] P009T3_A330PropostaQuantidadeAprovadores ;
      private bool[] P009T3_n330PropostaQuantidadeAprovadores ;
      private int[] P009T4_A168ClienteId ;
      private bool[] P009T4_n168ClienteId ;
      private int[] P009T4_A552ReponsavelClienteId ;
      private bool[] P009T4_n552ReponsavelClienteId ;
      private int[] P009T4_A551ClienteReponsavelId ;
      private int[] P009T5_A168ClienteId ;
      private bool[] P009T5_n168ClienteId ;
      private string[] P009T5_A170ClienteRazaoSocial ;
      private bool[] P009T5_n170ClienteRazaoSocial ;
      private string[] P009T5_A169ClienteDocumento ;
      private bool[] P009T5_n169ClienteDocumento ;
      private string[] P009T5_A201ContatoEmail ;
      private bool[] P009T5_n201ContatoEmail ;
      private SdtProposta AV33Proposta ;
      private SdtSdErro aP2_SdErro ;
   }

   public class praprovarproposta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009T3;
          prmP009T3 = new Object[] {
          new ParDef("AV17PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP009T4;
          prmP009T4 = new Object[] {
          new ParDef("AV10ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP009T5;
          prmP009T5 = new Object[] {
          new ParDef("AV10ClienteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009T3", "SELECT T1.PropostaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T3.ClienteDocumento AS PropostaPacienteClienteDocumento, T3.ContatoEmail AS PropostaPacienteContatoEmail, COALESCE( T2.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, T1.PropostaQuantidadeAprovadores FROM ((Proposta T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T2 ON T2.PropostaId = T1.PropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV17PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009T4", "SELECT ClienteId, ReponsavelClienteId, ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteId = :AV10ClienteId ORDER BY ClienteReponsavelId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009T5", "SELECT ClienteId, ClienteRazaoSocial, ClienteDocumento, ContatoEmail FROM Cliente WHERE ClienteId = :AV10ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T5,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
