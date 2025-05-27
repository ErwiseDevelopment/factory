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
   public class wwp_getusersfromrole : GXProcedure
   {
      public wwp_getusersfromrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getusersfromrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPSubscriptionRoleId ,
                           out GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection )
      {
         this.AV10WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV11WWPUserExtendedIdCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP1_WWPUserExtendedIdCollection=this.AV11WWPUserExtendedIdCollection;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_WWPSubscriptionRoleId )
      {
         execute(aP0_WWPSubscriptionRoleId, out aP1_WWPUserExtendedIdCollection);
         return AV11WWPUserExtendedIdCollection ;
      }

      public void executeSubmit( string aP0_WWPSubscriptionRoleId ,
                                 out GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection )
      {
         this.AV10WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV11WWPUserExtendedIdCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_WWPUserExtendedIdCollection=this.AV11WWPUserExtendedIdCollection;
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
         AV11WWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
      }

      private string AV10WWPSubscriptionRoleId ;
      private GxSimpleCollection<string> AV11WWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection ;
   }

}
