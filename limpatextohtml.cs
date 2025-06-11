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
   public class limpatextohtml : GXProcedure
   {
      public limpatextohtml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public limpatextohtml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_HTML )
      {
         this.AV8HTML = aP0_HTML;
         initialize();
         ExecuteImpl();
         aP0_HTML=this.AV8HTML;
      }

      public string executeUdp( )
      {
         execute(ref aP0_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( ref string aP0_HTML )
      {
         this.AV8HTML = aP0_HTML;
         SubmitImpl();
         aP0_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML = StringUtil.StringReplace( AV8HTML, StringUtil.Space( 5), StringUtil.Space( 1));
         AV8HTML = StringUtil.StringReplace( AV8HTML, StringUtil.Space( 4), StringUtil.Space( 1));
         AV8HTML = StringUtil.StringReplace( AV8HTML, StringUtil.Space( 3), StringUtil.Space( 1));
         AV8HTML = StringUtil.StringReplace( AV8HTML, StringUtil.Space( 2), StringUtil.Space( 1));
         AV8HTML = StringUtil.StringReplace( AV8HTML, StringUtil.Chr( 9), "");
         AV8HTML = StringUtil.StringReplace( AV8HTML, StringUtil.Chr( 13), "");
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
         /* GeneXus formulas. */
      }

      private string AV8HTML ;
      private string aP0_HTML ;
   }

}
