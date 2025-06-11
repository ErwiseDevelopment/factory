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
   public class showmessages : GXProcedure
   {
      public showmessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public showmessages( IGxContext context )
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

      public void gxep_error( ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages )
      {
         this.AV8Messages = aP0_Messages;
         initialize();
         /* Error Constructor */
         AV10GXV1 = 1;
         while ( AV10GXV1 <= AV8Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV8Messages.Item(AV10GXV1));
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV9Message.gxTpr_Description,  "error",  "",  "true",  ""));
            AV10GXV1 = (int)(AV10GXV1+1);
         }
         ExecuteImpl();
         aP0_Messages=this.AV8Messages;
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
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV10GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
   }

}
