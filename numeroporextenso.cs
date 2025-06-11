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
   public class numeroporextenso : GXProcedure
   {
      public numeroporextenso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public numeroporextenso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( decimal aP0_Numero ,
                           out string aP1_Extenso )
      {
         this.AV8Numero = aP0_Numero;
         this.AV9Extenso = "" ;
         initialize();
         ExecuteImpl();
         aP1_Extenso=this.AV9Extenso;
      }

      public string executeUdp( decimal aP0_Numero )
      {
         execute(aP0_Numero, out aP1_Extenso);
         return AV9Extenso ;
      }

      public void executeSubmit( decimal aP0_Numero ,
                                 out string aP1_Extenso )
      {
         this.AV8Numero = aP0_Numero;
         this.AV9Extenso = "" ;
         SubmitImpl();
         aP1_Extenso=this.AV9Extenso;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ( AV8Numero == Convert.ToDecimal( 0 )) )
         {
            AV9Extenso = "";
         }
         else if ( ( AV8Numero == Convert.ToDecimal( 1000000 )) )
         {
            AV9Extenso = "um milhão de reais";
         }
         else
         {
            AV9Extenso = AV34NumberToWordsConverter.numbertomoneywords(AV8Numero);
         }
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
         AV9Extenso = "";
         AV34NumberToWordsConverter = new SdtNumberToWordsConverter(context);
         /* GeneXus formulas. */
      }

      private decimal AV8Numero ;
      private string AV9Extenso ;
      private SdtNumberToWordsConverter AV34NumberToWordsConverter ;
      private string aP1_Extenso ;
   }

}
