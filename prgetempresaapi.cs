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
   public class prgetempresaapi : GXProcedure
   {
      public prgetempresaapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prgetempresaapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_CNPJ ,
                           out SdtSdEmpresas aP1_SdEmpresas )
      {
         this.AV20CNPJ = aP0_CNPJ;
         this.AV21SdEmpresas = new SdtSdEmpresas(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdEmpresas=this.AV21SdEmpresas;
      }

      public SdtSdEmpresas executeUdp( string aP0_CNPJ )
      {
         execute(aP0_CNPJ, out aP1_SdEmpresas);
         return AV21SdEmpresas ;
      }

      public void executeSubmit( string aP0_CNPJ ,
                                 out SdtSdEmpresas aP1_SdEmpresas )
      {
         this.AV20CNPJ = aP0_CNPJ;
         this.AV21SdEmpresas = new SdtSdEmpresas(context) ;
         SubmitImpl();
         aP1_SdEmpresas=this.AV21SdEmpresas;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14method = "GET";
         AV15modelorequisicao = "json/";
         AV10httpclient.AddHeader("Authorization", "fee32a53-a2c3-41b1-93bd-b507cc19a46b-a4433666-06bd-4e77-9752-8590a812dea9");
         AV19URL = "https://api.cnpja.com/office/" + StringUtil.Trim( AV20CNPJ);
         AV10httpclient.Execute(AV14method, AV19URL);
         AV21SdEmpresas.FromJSonString(AV10httpclient.ToString(), null);
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
         AV21SdEmpresas = new SdtSdEmpresas(context);
         AV14method = "";
         AV15modelorequisicao = "";
         AV10httpclient = new GxHttpClient( context);
         AV19URL = "";
         /* GeneXus formulas. */
      }

      private string AV14method ;
      private string AV20CNPJ ;
      private string AV15modelorequisicao ;
      private string AV19URL ;
      private GxHttpClient AV10httpclient ;
      private SdtSdEmpresas AV21SdEmpresas ;
      private SdtSdEmpresas aP1_SdEmpresas ;
   }

}
