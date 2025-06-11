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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prsendsignatureaux : GXProcedure
   {
      public prsendsignatureaux( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prsendsignatureaux( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ArquivoBlob ,
                           string aP1_ContratoNome ,
                           GXBaseCollection<SdtSdParticipantes> aP2_Array_SdParticipantes ,
                           int aP3_PropostaId ,
                           string aP4_PropostaContratoAssinaturaTipo ,
                           out SdtSdErro aP5_SdErro ,
                           out int aP6_PropostaContratoAssinaturaId )
      {
         this.AV8ArquivoBlob = aP0_ArquivoBlob;
         this.AV9ContratoNome = aP1_ContratoNome;
         this.AV17Array_SdParticipantes = aP2_Array_SdParticipantes;
         this.AV20PropostaId = aP3_PropostaId;
         this.AV22PropostaContratoAssinaturaTipo = aP4_PropostaContratoAssinaturaTipo;
         this.AV10SdErro = new SdtSdErro(context) ;
         this.AV24PropostaContratoAssinaturaId = 0 ;
         initialize();
         ExecuteImpl();
         aP5_SdErro=this.AV10SdErro;
         aP6_PropostaContratoAssinaturaId=this.AV24PropostaContratoAssinaturaId;
      }

      public int executeUdp( string aP0_ArquivoBlob ,
                             string aP1_ContratoNome ,
                             GXBaseCollection<SdtSdParticipantes> aP2_Array_SdParticipantes ,
                             int aP3_PropostaId ,
                             string aP4_PropostaContratoAssinaturaTipo ,
                             out SdtSdErro aP5_SdErro )
      {
         execute(aP0_ArquivoBlob, aP1_ContratoNome, aP2_Array_SdParticipantes, aP3_PropostaId, aP4_PropostaContratoAssinaturaTipo, out aP5_SdErro, out aP6_PropostaContratoAssinaturaId);
         return AV24PropostaContratoAssinaturaId ;
      }

      public void executeSubmit( string aP0_ArquivoBlob ,
                                 string aP1_ContratoNome ,
                                 GXBaseCollection<SdtSdParticipantes> aP2_Array_SdParticipantes ,
                                 int aP3_PropostaId ,
                                 string aP4_PropostaContratoAssinaturaTipo ,
                                 out SdtSdErro aP5_SdErro ,
                                 out int aP6_PropostaContratoAssinaturaId )
      {
         this.AV8ArquivoBlob = aP0_ArquivoBlob;
         this.AV9ContratoNome = aP1_ContratoNome;
         this.AV17Array_SdParticipantes = aP2_Array_SdParticipantes;
         this.AV20PropostaId = aP3_PropostaId;
         this.AV22PropostaContratoAssinaturaTipo = aP4_PropostaContratoAssinaturaTipo;
         this.AV10SdErro = new SdtSdErro(context) ;
         this.AV24PropostaContratoAssinaturaId = 0 ;
         SubmitImpl();
         aP5_SdErro=this.AV10SdErro;
         aP6_PropostaContratoAssinaturaId=this.AV24PropostaContratoAssinaturaId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prnewarquivo(context ).execute(  AV8ArquivoBlob,  AV9ContratoNome, out  AV14ArquivoId, out  AV10SdErro) ;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         new prnewcontrato(context ).execute(  AV9ContratoNome, out  AV15ContratoId,  0, out  AV10SdErro) ;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         new prnewassinatura(context ).execute(  AV15ContratoId,  AV14ArquivoId, out  AV16AssinaturaId, out  AV10SdErro) ;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         new prnewassinaturaparticipantes(context ).execute(  AV16AssinaturaId,  AV17Array_SdParticipantes, out  AV10SdErro) ;
         AV21PropostaContratoAssinatura = new SdtPropostaContratoAssinatura(context);
         AV21PropostaContratoAssinatura.gxTpr_Propostaassinatura = AV16AssinaturaId;
         AV21PropostaContratoAssinatura.gxTpr_Propostacontrato = AV15ContratoId;
         AV21PropostaContratoAssinatura.gxTpr_Propostaid = AV20PropostaId;
         AV21PropostaContratoAssinatura.gxTpr_Propostacontratoassinaturatipo = AV22PropostaContratoAssinaturaTipo;
         AV21PropostaContratoAssinatura.Save();
         AV24PropostaContratoAssinaturaId = AV21PropostaContratoAssinatura.gxTpr_Propostacontratoassinaturaid;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         else
         {
            context.CommitDataStores("prsendsignatureaux",pr_default);
         }
         AV19BaseUrl = AV18HTTPREQUEST.BaseURL;
         new prsendemailsignature(context).executeSubmit(  AV16AssinaturaId,  AV19BaseUrl) ;
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
         AV10SdErro = new SdtSdErro(context);
         AV21PropostaContratoAssinatura = new SdtPropostaContratoAssinatura(context);
         AV19BaseUrl = "";
         AV18HTTPREQUEST = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prsendsignatureaux__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV20PropostaId ;
      private int AV24PropostaContratoAssinaturaId ;
      private int AV14ArquivoId ;
      private int AV15ContratoId ;
      private long AV16AssinaturaId ;
      private string AV9ContratoNome ;
      private string AV22PropostaContratoAssinaturaTipo ;
      private string AV19BaseUrl ;
      private string AV8ArquivoBlob ;
      private GxHttpRequest AV18HTTPREQUEST ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdParticipantes> AV17Array_SdParticipantes ;
      private SdtSdErro AV10SdErro ;
      private SdtPropostaContratoAssinatura AV21PropostaContratoAssinatura ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro aP5_SdErro ;
      private int aP6_PropostaContratoAssinaturaId ;
   }

   public class prsendsignatureaux__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
