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
   public class prcensuratoken : GXProcedure
   {
      public prcensuratoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcensuratoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Token ,
                           out string aP1_CensuredToken )
      {
         this.AV8Token = aP0_Token;
         this.AV9CensuredToken = "" ;
         initialize();
         ExecuteImpl();
         aP1_CensuredToken=this.AV9CensuredToken;
      }

      public string executeUdp( string aP0_Token )
      {
         execute(aP0_Token, out aP1_CensuredToken);
         return AV9CensuredToken ;
      }

      public void executeSubmit( string aP0_Token ,
                                 out string aP1_CensuredToken )
      {
         this.AV8Token = aP0_Token;
         this.AV9CensuredToken = "" ;
         SubmitImpl();
         aP1_CensuredToken=this.AV9CensuredToken;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10tamanhoTexto = (short)(StringUtil.Len( AV8Token));
         AV12tamanhoCensura = (short)(AV10tamanhoTexto*0.3m);
         AV13inicioCensura = (short)((AV10tamanhoTexto-AV12tamanhoCensura)/ (decimal)(2));
         AV14fimCensura = (short)(AV13inicioCensura+AV12tamanhoCensura-1);
         AV15parteCensurada = StringUtil.PadL( AV15parteCensurada, AV12tamanhoCensura, "*");
         AV9CensuredToken = StringUtil.Substring( AV8Token, 1, AV13inicioCensura) + AV15parteCensurada + StringUtil.Substring( AV8Token, AV14fimCensura+1, AV10tamanhoTexto-AV14fimCensura);
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
         AV9CensuredToken = "";
         AV15parteCensurada = "";
         /* GeneXus formulas. */
      }

      private short AV10tamanhoTexto ;
      private short AV12tamanhoCensura ;
      private short AV13inicioCensura ;
      private short AV14fimCensura ;
      private string AV8Token ;
      private string AV9CensuredToken ;
      private string AV15parteCensurada ;
      private string aP1_CensuredToken ;
   }

}
