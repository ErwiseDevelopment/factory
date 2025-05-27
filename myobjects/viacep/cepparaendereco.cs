using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.myobjects.viacep {
   public class cepparaendereco : GXProcedure
   {
      public cepparaendereco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cepparaendereco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PesquisaCEP ,
                           out string aP1_ModeloRetorno ,
                           out string aP2_Mensagem )
      {
         this.AV16PesquisaCEP = aP0_PesquisaCEP;
         this.AV12ModeloRetorno = "" ;
         this.AV19Mensagem = "" ;
         initialize();
         ExecuteImpl();
         aP1_ModeloRetorno=this.AV12ModeloRetorno;
         aP2_Mensagem=this.AV19Mensagem;
      }

      public string executeUdp( string aP0_PesquisaCEP ,
                                out string aP1_ModeloRetorno )
      {
         execute(aP0_PesquisaCEP, out aP1_ModeloRetorno, out aP2_Mensagem);
         return AV19Mensagem ;
      }

      public void executeSubmit( string aP0_PesquisaCEP ,
                                 out string aP1_ModeloRetorno ,
                                 out string aP2_Mensagem )
      {
         this.AV16PesquisaCEP = aP0_PesquisaCEP;
         this.AV12ModeloRetorno = "" ;
         this.AV19Mensagem = "" ;
         SubmitImpl();
         aP1_ModeloRetorno=this.AV12ModeloRetorno;
         aP2_Mensagem=this.AV19Mensagem;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14CEP = AV16PesquisaCEP;
         AV11method = "GET";
         AV15modelorequisicao = "json/";
         AV18CompletaZero = (short)(8-StringUtil.Len( AV14CEP));
         if ( AV18CompletaZero == 1 )
         {
            AV14CEP = StringUtil.Trim( AV14CEP) + "0";
         }
         else if ( AV18CompletaZero == 2 )
         {
            AV14CEP = StringUtil.Trim( AV14CEP) + "00";
         }
         else if ( AV18CompletaZero == 3 )
         {
            AV14CEP = StringUtil.Trim( AV14CEP) + "000";
         }
         else if ( AV18CompletaZero > 3 )
         {
            AV19Mensagem = StringUtil.Format( "CEP incompleto: %1. Esperado pelo menos 5 digitos e foi digitado ", AV14CEP, StringUtil.LTrimStr( (decimal)(StringUtil.Len( AV14CEP)), 9, 0), "", "", "", "", "", "", "");
            cleanup();
            if (true) return;
         }
         AV8httpclient.Host = "viacep.com.br";
         AV8httpclient.Secure = 1;
         AV8httpclient.BaseURL = "/ws/";
         AV13URL = StringUtil.Trim( AV14CEP) + "/" + StringUtil.Trim( AV15modelorequisicao);
         AV8httpclient.Execute(AV11method, AV13URL);
         AV17response.FromJSonString(AV8httpclient.ToString(), null);
         if ( AV17response.gxTpr_Erro )
         {
            AV19Mensagem = StringUtil.Format( "O CEP %1 consta na nossa base de dados como inválido, verifique e tente novamente.", AV14CEP, "", "", "", "", "", "", "", "");
         }
         else
         {
            AV12ModeloRetorno = AV8httpclient.ToString();
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
         AV12ModeloRetorno = "";
         AV19Mensagem = "";
         AV14CEP = "";
         AV11method = "";
         AV15modelorequisicao = "";
         AV8httpclient = new GxHttpClient( context);
         AV13URL = "";
         AV17response = new GeneXus.Programs.myobjects.SdtResponse(context);
         /* GeneXus formulas. */
      }

      private short AV18CompletaZero ;
      private string AV16PesquisaCEP ;
      private string AV11method ;
      private string AV12ModeloRetorno ;
      private string AV19Mensagem ;
      private string AV14CEP ;
      private string AV15modelorequisicao ;
      private string AV13URL ;
      private GxHttpClient AV8httpclient ;
      private GeneXus.Programs.myobjects.SdtResponse AV17response ;
      private string aP1_ModeloRetorno ;
      private string aP2_Mensagem ;
   }

}
