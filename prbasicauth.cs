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
   public class prbasicauth : GXProcedure
   {
      public prbasicauth( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prbasicauth( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ClientId ,
                           string aP1_ClientSecret ,
                           out string aP2_Basic )
      {
         this.AV8ClientId = aP0_ClientId;
         this.AV9ClientSecret = aP1_ClientSecret;
         this.AV10Basic = "" ;
         initialize();
         ExecuteImpl();
         aP2_Basic=this.AV10Basic;
      }

      public string executeUdp( string aP0_ClientId ,
                                string aP1_ClientSecret )
      {
         execute(aP0_ClientId, aP1_ClientSecret, out aP2_Basic);
         return AV10Basic ;
      }

      public void executeSubmit( string aP0_ClientId ,
                                 string aP1_ClientSecret ,
                                 out string aP2_Basic )
      {
         this.AV8ClientId = aP0_ClientId;
         this.AV9ClientSecret = aP1_ClientSecret;
         this.AV10Basic = "" ;
         SubmitImpl();
         aP2_Basic=this.AV10Basic;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11AuxText = StringUtil.Format( "%1:%2", AV8ClientId, AV9ClientSecret, "", "", "", "", "", "", "");
         AV10Basic = StringUtil.ToBase64( AV11AuxText);
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
         AV10Basic = "";
         AV11AuxText = "";
         /* GeneXus formulas. */
      }

      private string AV8ClientId ;
      private string AV9ClientSecret ;
      private string AV10Basic ;
      private string AV11AuxText ;
      private string aP2_Basic ;
   }

}
