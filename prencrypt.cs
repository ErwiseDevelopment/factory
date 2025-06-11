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
   public class prencrypt : GXProcedure
   {
      public prencrypt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prencrypt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Content ,
                           out string aP1_EncryptedContent )
      {
         this.AV8Content = aP0_Content;
         this.AV10EncryptedContent = "" ;
         initialize();
         ExecuteImpl();
         aP1_EncryptedContent=this.AV10EncryptedContent;
      }

      public string executeUdp( string aP0_Content )
      {
         execute(aP0_Content, out aP1_EncryptedContent);
         return AV10EncryptedContent ;
      }

      public void executeSubmit( string aP0_Content ,
                                 out string aP1_EncryptedContent )
      {
         this.AV8Content = aP0_Content;
         this.AV10EncryptedContent = "" ;
         SubmitImpl();
         aP1_EncryptedContent=this.AV10EncryptedContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV9Key;
         new prchave(context ).execute( out  GXt_char1) ;
         AV9Key = GXt_char1;
         AV10EncryptedContent = Encrypt64( AV8Content, AV9Key);
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
         AV10EncryptedContent = "";
         AV9Key = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV8Content ;
      private string AV10EncryptedContent ;
      private string AV9Key ;
      private string aP1_EncryptedContent ;
   }

}
