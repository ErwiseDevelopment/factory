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
namespace GeneXus.Programs {
   public class validcpf : GXProcedure
   {
      public validcpf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public validcpf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prvalidcpf(context ).execute(  "FISICA",  "34136887825", out  AV8IsOk, out  AV9ErroMsg) ;
         new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  true,  AV8IsOk,  "CPF 34136887825 deveria ser válido: "+AV9ErroMsg) ;
         new prvalidcpf(context ).execute(  "FISICA",  "34136887826", out  AV8IsOk, out  AV9ErroMsg) ;
         new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  false,  AV8IsOk,  "CPF 34136887826 deveria ser inválido: "+AV9ErroMsg) ;
         new prvalidcpf(context ).execute(  "JURIDICA",  "43161294000146", out  AV8IsOk, out  AV9ErroMsg) ;
         new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  true,  AV8IsOk,  "CNPJ 43161294000146 deveria ser válido: "+AV9ErroMsg) ;
         new prvalidcpf(context ).execute(  "JURIDICA",  "43161294000147", out  AV8IsOk, out  AV9ErroMsg) ;
         new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  false,  AV8IsOk,  "CNPJ 43161294000146 deveria ser inválido: "+AV9ErroMsg) ;
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
         AV9ErroMsg = "";
         /* GeneXus formulas. */
      }

      private bool AV8IsOk ;
      private string AV9ErroMsg ;
   }

}
