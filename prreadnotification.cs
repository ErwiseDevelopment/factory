using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class prreadnotification : GXProcedure
   {
      public prreadnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prreadnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UserNotificationId )
      {
         this.AV8UserNotificationId = aP0_UserNotificationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_UserNotificationId )
      {
         this.AV8UserNotificationId = aP0_UserNotificationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9UserNotification.Load(AV8UserNotificationId);
         AV9UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV9UserNotification.Save();
         context.CommitDataStores("prreadnotification",pr_default);
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
         AV9UserNotification = new SdtUserNotification(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prreadnotification__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8UserNotificationId ;
      private IGxDataStore dsDefault ;
      private SdtUserNotification AV9UserNotification ;
      private IDataStoreProvider pr_default ;
   }

   public class prreadnotification__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
