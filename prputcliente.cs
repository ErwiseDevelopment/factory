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
   public class prputcliente : GXProcedure
   {
      public prputcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prputcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_ClienteId ,
                           SdtSdClientePFPJ aP1_SdClientePFPJ ,
                           out SdtSdClientePFPJ aP2_RetSdClientePFPJ )
      {
         this.AV8ClienteId = aP0_ClienteId;
         this.AV9SdClientePFPJ = aP1_SdClientePFPJ;
         this.AV10RetSdClientePFPJ = new SdtSdClientePFPJ(context) ;
         initialize();
         ExecuteImpl();
         aP2_RetSdClientePFPJ=this.AV10RetSdClientePFPJ;
      }

      public SdtSdClientePFPJ executeUdp( int aP0_ClienteId ,
                                          SdtSdClientePFPJ aP1_SdClientePFPJ )
      {
         execute(aP0_ClienteId, aP1_SdClientePFPJ, out aP2_RetSdClientePFPJ);
         return AV10RetSdClientePFPJ ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 SdtSdClientePFPJ aP1_SdClientePFPJ ,
                                 out SdtSdClientePFPJ aP2_RetSdClientePFPJ )
      {
         this.AV8ClienteId = aP0_ClienteId;
         this.AV9SdClientePFPJ = aP1_SdClientePFPJ;
         this.AV10RetSdClientePFPJ = new SdtSdClientePFPJ(context) ;
         SubmitImpl();
         aP2_RetSdClientePFPJ=this.AV10RetSdClientePFPJ;
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
         AV10RetSdClientePFPJ = new SdtSdClientePFPJ(context);
         /* GeneXus formulas. */
      }

      private int AV8ClienteId ;
      private SdtSdClientePFPJ AV9SdClientePFPJ ;
      private SdtSdClientePFPJ AV10RetSdClientePFPJ ;
      private SdtSdClientePFPJ aP2_RetSdClientePFPJ ;
   }

}
