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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_changenotificationstatus : GXProcedure
   {
      public wwp_changenotificationstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_changenotificationstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
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

      public void gxep_setnotificationreadunreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         /* SetNotificationReadUnreadById Constructor */
         /* Using cursor P00312 */
         pr_default.execute(0, new Object[] {AV8WWPNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A22WWPNotificationId = P00312_A22WWPNotificationId[0];
            A82WWPNotificationIsRead = P00312_A82WWPNotificationIsRead[0];
            if ( A82WWPNotificationIsRead )
            {
               A82WWPNotificationIsRead = false;
            }
            else
            {
               A82WWPNotificationIsRead = true;
            }
            /* Using cursor P00313 */
            pr_default.execute(1, new Object[] {A82WWPNotificationIsRead, A22WWPNotificationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         ExecuteImpl();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         cleanup();
      }

      public void gxep_setnotificationreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         /* SetNotificationReadById Constructor */
         /* Optimized UPDATE. */
         /* Using cursor P00314 */
         pr_default.execute(2, new Object[] {AV8WWPNotificationId});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         ExecuteImpl();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         cleanup();
      }

      public void gxep_setallnotificationsofloggeduserread( )
      {
         initialize();
         /* SetAllNotificationsOfLoggedUserRead Constructor */
         AV12Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized UPDATE. */
         /* Using cursor P00315 */
         pr_default.execute(3, new Object[] {AV12Udparg1});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
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
         P00312_A22WWPNotificationId = new long[1] ;
         P00312_A82WWPNotificationIsRead = new bool[] {false} ;
         AV12Udparg1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus__default(),
            new Object[][] {
                new Object[] {
               P00312_A22WWPNotificationId, P00312_A82WWPNotificationIsRead
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPNotificationId ;
      private long A22WWPNotificationId ;
      private string AV12Udparg1 ;
      private bool A82WWPNotificationIsRead ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPNotificationId ;
      private IDataStoreProvider pr_default ;
      private long[] P00312_A22WWPNotificationId ;
      private bool[] P00312_A82WWPNotificationIsRead ;
   }

   public class wwp_changenotificationstatus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00312;
          prmP00312 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP00313;
          prmP00313 = new Object[] {
          new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
          new ParDef("WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP00314;
          prmP00314 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP00315;
          prmP00315 = new Object[] {
          new ParDef("AV12Udparg1",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00312", "SELECT WWPNotificationId, WWPNotificationIsRead FROM WWP_Notification WHERE WWPNotificationId = :AV8WWPNotificationId ORDER BY WWPNotificationId  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00312,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00313", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationIsRead=:WWPNotificationIsRead  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00313)
             ,new CursorDef("P00314", "UPDATE WWP_Notification SET WWPNotificationIsRead=TRUE  WHERE WWPNotificationId = :AV8WWPNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00314)
             ,new CursorDef("P00315", "UPDATE WWP_Notification SET WWPNotificationIsRead=TRUE  WHERE WWPUserExtendedId = ( :AV12Udparg1)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00315)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
       }
    }

 }

}
