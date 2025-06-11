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
   public class prlogout : GXProcedure
   {
      public prlogout( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prlogout( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref bool aP0_LogOutSuccesful )
      {
         this.AV8LogOutSuccesful = aP0_LogOutSuccesful;
         initialize();
         ExecuteImpl();
         aP0_LogOutSuccesful=this.AV8LogOutSuccesful;
      }

      public bool executeUdp( )
      {
         execute(ref aP0_LogOutSuccesful);
         return AV8LogOutSuccesful ;
      }

      public void executeSubmit( ref bool aP0_LogOutSuccesful )
      {
         this.AV8LogOutSuccesful = aP0_LogOutSuccesful;
         SubmitImpl();
         aP0_LogOutSuccesful=this.AV8LogOutSuccesful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8LogOutSuccesful = false;
         AV9Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV9Context) ;
         AV8LogOutSuccesful = true;
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
         AV9Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         /* GeneXus formulas. */
      }

      private bool AV8LogOutSuccesful ;
      private bool aP0_LogOutSuccesful ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9Context ;
   }

}
