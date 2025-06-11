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
   public class dpbanco : GXProcedure
   {
      public dpbanco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpbanco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSdBanco_Banco> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSdBanco_Banco>( context, "Banco", "Factory21") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSdBanco_Banco> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSdBanco_Banco> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSdBanco_Banco>( context, "Banco", "Factory21") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 1;
         Gxm1sdbanco.gxTpr_Banconome = "Banco do Brasil";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 104;
         Gxm1sdbanco.gxTpr_Banconome = "Caixa Econômica Federal";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 237;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Bradesco";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 341;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Itaú Unibanco";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 33;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Santander Brasil";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 422;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Safra";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 208;
         Gxm1sdbanco.gxTpr_Banconome = "Banco BTG Pactual";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 655;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Votorantim";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 77;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Inter";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 260;
         Gxm1sdbanco.gxTpr_Banconome = "Nubank";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 212;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Original";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 623;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Pan";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 707;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Daycoval";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 389;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Mercantil do Brasil";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 41;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Banrisul";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 4;
         Gxm1sdbanco.gxTpr_Banconome = "Banco do Nordeste";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 3;
         Gxm1sdbanco.gxTpr_Banconome = "Banco da Amazônia";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 746;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Modal";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 246;
         Gxm1sdbanco.gxTpr_Banconome = "Banco ABC Brasil";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 318;
         Gxm1sdbanco.gxTpr_Banconome = "Banco BMG";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 224;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Fibra";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 336;
         Gxm1sdbanco.gxTpr_Banconome = "Banco C6 Bank";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 735;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Neon";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 637;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Sofisa";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 218;
         Gxm1sdbanco.gxTpr_Banconome = "Banco BS2";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 121;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Agibank";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 82;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Topázio";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 477;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Citibank";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 748;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Sicredi";
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         Gxm2rootcol.Add(Gxm1sdbanco, 0);
         Gxm1sdbanco.gxTpr_Bancocodigo = 756;
         Gxm1sdbanco.gxTpr_Banconome = "Banco Cooperativo do Brasil (Bancoob)";
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
         Gxm1sdbanco = new SdtSdBanco_Banco(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtSdBanco_Banco> Gxm2rootcol ;
      private SdtSdBanco_Banco Gxm1sdbanco ;
      private GXBaseCollection<SdtSdBanco_Banco> aP0_Gxm2rootcol ;
   }

}
