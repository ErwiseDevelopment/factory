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
   public class aenderecoparacep : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new myobjects.viacep.aenderecoparacep().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_UF = new string(' ',0)  ;
         string aP1_inLocalidade = new string(' ',0)  ;
         string aP2_inLogradouro = new string(' ',0)  ;
         string aP3_ModeloRetorno = new string(' ',0)  ;
         string aP4_Mensagem = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_UF=((string)(args[0]));
         }
         else
         {
            aP0_UF="";
         }
         if ( 1 < args.Length )
         {
            aP1_inLocalidade=((string)(args[1]));
         }
         else
         {
            aP1_inLocalidade="";
         }
         if ( 2 < args.Length )
         {
            aP2_inLogradouro=((string)(args[2]));
         }
         else
         {
            aP2_inLogradouro="";
         }
         if ( 3 < args.Length )
         {
            aP3_ModeloRetorno=((string)(args[3]));
         }
         else
         {
            aP3_ModeloRetorno="";
         }
         if ( 4 < args.Length )
         {
            aP4_Mensagem=((string)(args[4]));
         }
         else
         {
            aP4_Mensagem="";
         }
         execute(aP0_UF, aP1_inLocalidade, aP2_inLogradouro, out aP3_ModeloRetorno, out aP4_Mensagem);
         return GX.GXRuntime.ExitCode ;
      }

      public aenderecoparacep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aenderecoparacep( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UF ,
                           string aP1_inLocalidade ,
                           string aP2_inLogradouro ,
                           out string aP3_ModeloRetorno ,
                           out string aP4_Mensagem )
      {
         this.AV17UF = aP0_UF;
         this.AV9inLocalidade = aP1_inLocalidade;
         this.AV10inLogradouro = aP2_inLogradouro;
         this.AV16ModeloRetorno = "" ;
         this.AV13Mensagem = "" ;
         initialize();
         ExecuteImpl();
         aP3_ModeloRetorno=this.AV16ModeloRetorno;
         aP4_Mensagem=this.AV13Mensagem;
      }

      public string executeUdp( string aP0_UF ,
                                string aP1_inLocalidade ,
                                string aP2_inLogradouro ,
                                out string aP3_ModeloRetorno )
      {
         execute(aP0_UF, aP1_inLocalidade, aP2_inLogradouro, out aP3_ModeloRetorno, out aP4_Mensagem);
         return AV13Mensagem ;
      }

      public void executeSubmit( string aP0_UF ,
                                 string aP1_inLocalidade ,
                                 string aP2_inLogradouro ,
                                 out string aP3_ModeloRetorno ,
                                 out string aP4_Mensagem )
      {
         this.AV17UF = aP0_UF;
         this.AV9inLocalidade = aP1_inLocalidade;
         this.AV10inLogradouro = aP2_inLogradouro;
         this.AV16ModeloRetorno = "" ;
         this.AV13Mensagem = "" ;
         SubmitImpl();
         aP3_ModeloRetorno=this.AV16ModeloRetorno;
         aP4_Mensagem=this.AV13Mensagem;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'REPLACE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV14method = "GET";
         AV15modelorequisicao = "json/";
         AV8httpclient.Host = "viacep.com.br";
         AV8httpclient.Secure = 0;
         AV8httpclient.BaseURL = "/ws/";
         AV18URL = AV17UF + "/" + StringUtil.Trim( AV11Localidade) + "/" + StringUtil.Trim( AV12Logradouro) + "/" + AV15modelorequisicao;
         AV8httpclient.Execute(AV14method, AV18URL);
         AV16ModeloRetorno = AV8httpclient.ToString();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ModeloRetorno)) )
         {
            AV13Mensagem = StringUtil.Format( "A %1 consta na nossa base de dados como válido, verifique e tente novamente.", AV12Logradouro, AV11Localidade, AV17UF, "", "", "", "", "", "");
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'REPLACE' Routine */
         returnInSub = false;
         AV11Localidade = StringUtil.StringReplace( AV9inLocalidade, "á", "a");
         AV11Localidade = StringUtil.StringReplace( AV11Localidade, "ã", "a");
         AV11Localidade = StringUtil.StringReplace( AV11Localidade, "é", "e");
         AV11Localidade = StringUtil.StringReplace( AV11Localidade, "í", "i");
         AV11Localidade = StringUtil.StringReplace( AV11Localidade, "ó", "o");
         AV11Localidade = StringUtil.StringReplace( AV11Localidade, "õ", "o");
         AV11Localidade = StringUtil.StringReplace( AV11Localidade, "ú", "u");
         AV12Logradouro = StringUtil.StringReplace( AV10inLogradouro, "á", "a");
         AV12Logradouro = StringUtil.StringReplace( AV12Logradouro, "ã", "a");
         AV12Logradouro = StringUtil.StringReplace( AV12Logradouro, "é", "e");
         AV12Logradouro = StringUtil.StringReplace( AV12Logradouro, "í", "i");
         AV12Logradouro = StringUtil.StringReplace( AV12Logradouro, "ó", "o");
         AV12Logradouro = StringUtil.StringReplace( AV12Logradouro, "õ", "o");
         AV12Logradouro = StringUtil.StringReplace( AV12Logradouro, "ú", "u");
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
         AV16ModeloRetorno = "";
         AV13Mensagem = "";
         AV14method = "";
         AV15modelorequisicao = "";
         AV8httpclient = new GxHttpClient( context);
         AV18URL = "";
         AV11Localidade = "";
         AV12Logradouro = "";
         /* GeneXus formulas. */
      }

      private string AV17UF ;
      private string AV14method ;
      private bool returnInSub ;
      private string AV16ModeloRetorno ;
      private string AV9inLocalidade ;
      private string AV10inLogradouro ;
      private string AV13Mensagem ;
      private string AV15modelorequisicao ;
      private string AV18URL ;
      private string AV11Localidade ;
      private string AV12Logradouro ;
      private GxHttpClient AV8httpclient ;
      private string aP3_ModeloRetorno ;
      private string aP4_Mensagem ;
   }

}
