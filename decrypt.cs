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
   public class decrypt : GXProcedure
   {
      public decrypt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public decrypt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Content ,
                           out string aP1_OutContent )
      {
         this.AV9Content = aP0_Content;
         this.AV10OutContent = "" ;
         initialize();
         ExecuteImpl();
         aP1_OutContent=this.AV10OutContent;
      }

      public string executeUdp( string aP0_Content )
      {
         execute(aP0_Content, out aP1_OutContent);
         return AV10OutContent ;
      }

      public void executeSubmit( string aP0_Content ,
                                 out string aP1_OutContent )
      {
         this.AV9Content = aP0_Content;
         this.AV10OutContent = "" ;
         SubmitImpl();
         aP1_OutContent=this.AV10OutContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV12Chave;
         new prchave(context ).execute( out  GXt_char1) ;
         AV12Chave = GXt_char1;
         AV10OutContent = Decrypt64( AV9Content, AV12Chave);
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
         AV10OutContent = "";
         AV12Chave = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV9Content ;
      private string AV10OutContent ;
      private string AV12Chave ;
      private string aP1_OutContent ;
   }

}
