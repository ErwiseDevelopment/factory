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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getloggeduserroles : GXProcedure
   {
      public wwp_getloggeduserroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getloggeduserroles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection )
      {
         this.AV8WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP0_WWPSubscriptionRoleIdCollection=this.AV8WWPSubscriptionRoleIdCollection;
      }

      public GxSimpleCollection<string> executeUdp( )
      {
         execute(out aP0_WWPSubscriptionRoleIdCollection);
         return AV8WWPSubscriptionRoleIdCollection ;
      }

      public void executeSubmit( out GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection )
      {
         this.AV8WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP0_WWPSubscriptionRoleIdCollection=this.AV8WWPSubscriptionRoleIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         AV8WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
      }

      private GxSimpleCollection<string> AV8WWPSubscriptionRoleIdCollection ;
      private GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection ;
   }

}
