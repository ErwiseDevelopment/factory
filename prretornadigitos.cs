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
   public class prretornadigitos : GXProcedure
   {
      public prretornadigitos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prretornadigitos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Texto ,
                           out string aP1_ApenasDigitos )
      {
         this.AV8Texto = aP0_Texto;
         this.AV9ApenasDigitos = "" ;
         initialize();
         ExecuteImpl();
         aP1_ApenasDigitos=this.AV9ApenasDigitos;
      }

      public string executeUdp( string aP0_Texto )
      {
         execute(aP0_Texto, out aP1_ApenasDigitos);
         return AV9ApenasDigitos ;
      }

      public void executeSubmit( string aP0_Texto ,
                                 out string aP1_ApenasDigitos )
      {
         this.AV8Texto = aP0_Texto;
         this.AV9ApenasDigitos = "" ;
         SubmitImpl();
         aP1_ApenasDigitos=this.AV9ApenasDigitos;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ApenasDigitos = GxRegex.Replace(AV8Texto,"[^\\d]","");
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
         AV9ApenasDigitos = "";
         /* GeneXus formulas. */
      }

      private string AV8Texto ;
      private string AV9ApenasDigitos ;
      private string aP1_ApenasDigitos ;
   }

}
