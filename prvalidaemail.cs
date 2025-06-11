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
   public class prvalidaemail : GXProcedure
   {
      public prvalidaemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prvalidaemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Email ,
                           out bool aP1_IsValid )
      {
         this.AV8Email = aP0_Email;
         this.AV9IsValid = false ;
         initialize();
         ExecuteImpl();
         aP1_IsValid=this.AV9IsValid;
      }

      public bool executeUdp( string aP0_Email )
      {
         execute(aP0_Email, out aP1_IsValid);
         return AV9IsValid ;
      }

      public void executeSubmit( string aP0_Email ,
                                 out bool aP1_IsValid )
      {
         this.AV8Email = aP0_Email;
         this.AV9IsValid = false ;
         SubmitImpl();
         aP1_IsValid=this.AV9IsValid;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsValid = GxRegex.IsMatch(AV8Email,"^(?i)(?!\\.)[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z]{2,}$");
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
         /* GeneXus formulas. */
      }

      private bool AV9IsValid ;
      private string AV8Email ;
      private bool aP1_IsValid ;
   }

}
