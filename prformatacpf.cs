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
   public class prformatacpf : GXProcedure
   {
      public prformatacpf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prformatacpf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_CPF ,
                           out string aP1_CPFFOrmated )
      {
         this.AV9CPF = aP0_CPF;
         this.AV8CPFFOrmated = "" ;
         initialize();
         ExecuteImpl();
         aP1_CPFFOrmated=this.AV8CPFFOrmated;
      }

      public string executeUdp( string aP0_CPF )
      {
         execute(aP0_CPF, out aP1_CPFFOrmated);
         return AV8CPFFOrmated ;
      }

      public void executeSubmit( string aP0_CPF ,
                                 out string aP1_CPFFOrmated )
      {
         this.AV9CPF = aP0_CPF;
         this.AV8CPFFOrmated = "" ;
         SubmitImpl();
         aP1_CPFFOrmated=this.AV8CPFFOrmated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Primeiro = StringUtil.Substring( AV9CPF, 1, 3);
         AV11Segundo = StringUtil.Substring( AV9CPF, 4, 3);
         AV13Terceiro = StringUtil.Substring( AV9CPF, 7, 3);
         AV12Digito = StringUtil.Substring( AV9CPF, 10, 2);
         AV8CPFFOrmated = StringUtil.Format( "%1.%2.%3-%4", AV10Primeiro, AV11Segundo, AV13Terceiro, AV12Digito, "", "", "", "", "");
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
         AV8CPFFOrmated = "";
         AV10Primeiro = "";
         AV11Segundo = "";
         AV13Terceiro = "";
         AV12Digito = "";
         /* GeneXus formulas. */
      }

      private string AV9CPF ;
      private string AV8CPFFOrmated ;
      private string AV10Primeiro ;
      private string AV11Segundo ;
      private string AV13Terceiro ;
      private string AV12Digito ;
      private string aP1_CPFFOrmated ;
   }

}
