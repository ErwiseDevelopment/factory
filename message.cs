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
   public class message : GXProcedure
   {
      public message( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public message( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_sucesso( ref string aP0_Mensagem )
      {
         this.AV8Mensagem = aP0_Mensagem;
         initialize();
         /* Sucesso Constructor */
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV8Mensagem,  "success",  "",  "true",  ""));
         ExecuteImpl();
         aP0_Mensagem=this.AV8Mensagem;
         cleanup();
      }

      public void gxep_erro( ref string aP0_Mensagem )
      {
         this.AV8Mensagem = aP0_Mensagem;
         initialize();
         /* Erro Constructor */
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV8Mensagem,  "error",  "",  "true",  ""));
         ExecuteImpl();
         aP0_Mensagem=this.AV8Mensagem;
         cleanup();
      }

      public void gxep_regular( ref string aP0_Mensagem )
      {
         this.AV8Mensagem = aP0_Mensagem;
         initialize();
         /* Regular Constructor */
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV8Mensagem,  "notice",  "",  "true",  ""));
         ExecuteImpl();
         aP0_Mensagem=this.AV8Mensagem;
         cleanup();
      }

      public void gxep_info( ref string aP0_Mensagem )
      {
         this.AV8Mensagem = aP0_Mensagem;
         initialize();
         /* Info Constructor */
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV8Mensagem,  "info",  "",  "true",  ""));
         ExecuteImpl();
         aP0_Mensagem=this.AV8Mensagem;
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

      private string AV8Mensagem ;
      private string aP0_Mensagem ;
   }

}
