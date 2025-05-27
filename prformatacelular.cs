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
   public class prformatacelular : GXProcedure
   {
      public prformatacelular( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prformatacelular( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_InCelular ,
                           out string aP1_OutCelular )
      {
         this.AV13InCelular = aP0_InCelular;
         this.AV14OutCelular = "" ;
         initialize();
         ExecuteImpl();
         aP1_OutCelular=this.AV14OutCelular;
      }

      public string executeUdp( string aP0_InCelular )
      {
         execute(aP0_InCelular, out aP1_OutCelular);
         return AV14OutCelular ;
      }

      public void executeSubmit( string aP0_InCelular ,
                                 out string aP1_OutCelular )
      {
         this.AV13InCelular = aP0_InCelular;
         this.AV14OutCelular = "" ;
         SubmitImpl();
         aP1_OutCelular=this.AV14OutCelular;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ApenasDigitos = GxRegex.Replace(AV13InCelular,"[^\\d]","");
         if ( StringUtil.Len( AV9ApenasDigitos) == 1 )
         {
            AV14OutCelular = StringUtil.Format( "(%1", AV9ApenasDigitos, "", "", "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 2 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)", AV9ApenasDigitos, "", "", "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 3 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 1), "", "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 4 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 2), "", "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 5 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 3), "", "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 6 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 4), "", "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 7 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2-%3", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 4), StringUtil.Substring( AV9ApenasDigitos, 7, 1), "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 8 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2-%3", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 4), StringUtil.Substring( AV9ApenasDigitos, 7, 2), "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 9 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2-%3", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 4), StringUtil.Substring( AV9ApenasDigitos, 7, 3), "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 10 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2-%3", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 4), StringUtil.Substring( AV9ApenasDigitos, 7, 4), "", "", "", "", "", "");
         }
         if ( StringUtil.Len( AV9ApenasDigitos) == 11 )
         {
            AV14OutCelular = StringUtil.Format( "(%1)%2-%3", StringUtil.Substring( AV9ApenasDigitos, 1, 2), StringUtil.Substring( AV9ApenasDigitos, 3, 5), StringUtil.Substring( AV9ApenasDigitos, 8, 4), "", "", "", "", "", "");
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
         AV14OutCelular = "";
         AV9ApenasDigitos = "";
         /* GeneXus formulas. */
      }

      private string AV13InCelular ;
      private string AV14OutCelular ;
      private string AV9ApenasDigitos ;
      private string aP1_OutCelular ;
   }

}
