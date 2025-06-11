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
   public class prmessage : GXProcedure
   {
      public prmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSdErro aP0_SdErro )
      {
         this.AV8SdErro = aP0_SdErro;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( SdtSdErro aP0_SdErro )
      {
         this.AV8SdErro = aP0_SdErro;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_erro( SdtSdErro aP0_SdErro )
      {
         this.AV8SdErro = aP0_SdErro;
         initialize();
         /* erro Constructor */
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Erro!",  StringUtil.Str( (decimal)(AV8SdErro.gxTpr_Status), 4, 0)+" - "+AV8SdErro.gxTpr_Msg,  "error",  "",  "true",  ""));
         ExecuteImpl();
         cleanup();
      }

      public void gxep_sucesso( string aP0_Message )
      {
         this.AV9Message = aP0_Message;
         initialize();
         /* sucesso Constructor */
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Sucesso!",  AV9Message,  "success",  "",  "true",  ""));
         ExecuteImpl();
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

      private string AV9Message ;
      private SdtSdErro AV8SdErro ;
   }

}
