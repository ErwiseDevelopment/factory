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
   public class prenviarnotificacoesaprovadores : GXProcedure
   {
      public prenviarnotificacoesaprovadores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prenviarnotificacoesaprovadores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_NotificationTitle ,
                           string aP1_NotificationMessage ,
                           string aP2_NotificationType ,
                           string aP3_NotificationLink ,
                           short aP4_SecUserId ,
                           string aP5_HTML ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Messages )
      {
         this.AV11NotificationTitle = aP0_NotificationTitle;
         this.AV9NotificationMessage = aP1_NotificationMessage;
         this.AV10NotificationType = aP2_NotificationType;
         this.AV16NotificationLink = aP3_NotificationLink;
         this.AV14SecUserId = aP4_SecUserId;
         this.AV17HTML = aP5_HTML;
         this.AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP6_Messages=this.AV13Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_NotificationTitle ,
                                                                             string aP1_NotificationMessage ,
                                                                             string aP2_NotificationType ,
                                                                             string aP3_NotificationLink ,
                                                                             short aP4_SecUserId ,
                                                                             string aP5_HTML )
      {
         execute(aP0_NotificationTitle, aP1_NotificationMessage, aP2_NotificationType, aP3_NotificationLink, aP4_SecUserId, aP5_HTML, out aP6_Messages);
         return AV13Messages ;
      }

      public void executeSubmit( string aP0_NotificationTitle ,
                                 string aP1_NotificationMessage ,
                                 string aP2_NotificationType ,
                                 string aP3_NotificationLink ,
                                 short aP4_SecUserId ,
                                 string aP5_HTML ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Messages )
      {
         this.AV11NotificationTitle = aP0_NotificationTitle;
         this.AV9NotificationMessage = aP1_NotificationMessage;
         this.AV10NotificationType = aP2_NotificationType;
         this.AV16NotificationLink = aP3_NotificationLink;
         this.AV14SecUserId = aP4_SecUserId;
         this.AV17HTML = aP5_HTML;
         this.AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP6_Messages=this.AV13Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8BcNotification = new SdtBCNotification(context);
         AV8BcNotification.gxTpr_Notificationtitle = AV11NotificationTitle;
         AV8BcNotification.gxTpr_Notificationmessage = AV9NotificationMessage;
         AV8BcNotification.gxTpr_Notificationtype = AV10NotificationType;
         AV8BcNotification.gxTpr_Secuserid = AV14SecUserId;
         AV8BcNotification.gxTpr_Notificationlink = AV16NotificationLink;
         new insertnotification(context ).execute(  AV8BcNotification, out  AV13Messages) ;
         if ( (0==AV13Messages.Count) )
         {
            /* Using cursor P009H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A380AprovadoresStatus = P009H2_A380AprovadoresStatus[0];
               n380AprovadoresStatus = P009H2_n380AprovadoresStatus[0];
               A133SecUserId = P009H2_A133SecUserId[0];
               n133SecUserId = P009H2_n133SecUserId[0];
               A144SecUserEmail = P009H2_A144SecUserEmail[0];
               n144SecUserEmail = P009H2_n144SecUserEmail[0];
               A375AprovadoresId = P009H2_A375AprovadoresId[0];
               A144SecUserEmail = P009H2_A144SecUserEmail[0];
               n144SecUserEmail = P009H2_n144SecUserEmail[0];
               AV15UserNotification = new SdtUserNotification(context);
               AV15UserNotification.gxTpr_Notificationid = AV8BcNotification.gxTpr_Notificationid;
               AV15UserNotification.gxTpr_Usernotificationuserid = A133SecUserId;
               AV15UserNotification.gxTv_SdtUserNotification_Usernotificationreadat_SetNull();
               AV18Array_Email.Add(A144SecUserEmail, 0);
               new insertusernotification(context ).execute(  AV15UserNotification, out  AV13Messages) ;
               if ( ! (0==AV13Messages.Count) )
               {
                  context.RollbackDataStores("prenviarnotificacoesaprovadores",pr_default);
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
                  new showmessages(context ).execute( ) ;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new sendemail(context).executeSubmit(  "Nova proposta",  AV17HTML,  AV18Array_Email, out  AV19message) ;
         }
         else
         {
            context.RollbackDataStores("prenviarnotificacoesaprovadores",pr_default);
            cleanup();
            if (true) return;
            new showmessages(context ).execute( ) ;
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
         AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8BcNotification = new SdtBCNotification(context);
         P009H2_A380AprovadoresStatus = new bool[] {false} ;
         P009H2_n380AprovadoresStatus = new bool[] {false} ;
         P009H2_A133SecUserId = new short[1] ;
         P009H2_n133SecUserId = new bool[] {false} ;
         P009H2_A144SecUserEmail = new string[] {""} ;
         P009H2_n144SecUserEmail = new bool[] {false} ;
         P009H2_A375AprovadoresId = new int[1] ;
         A144SecUserEmail = "";
         AV15UserNotification = new SdtUserNotification(context);
         AV18Array_Email = new GxSimpleCollection<string>();
         AV19message = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prenviarnotificacoesaprovadores__default(),
            new Object[][] {
                new Object[] {
               P009H2_A380AprovadoresStatus, P009H2_n380AprovadoresStatus, P009H2_A133SecUserId, P009H2_n133SecUserId, P009H2_A144SecUserEmail, P009H2_n144SecUserEmail, P009H2_A375AprovadoresId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14SecUserId ;
      private short A133SecUserId ;
      private int A375AprovadoresId ;
      private bool A380AprovadoresStatus ;
      private bool n380AprovadoresStatus ;
      private bool n133SecUserId ;
      private bool n144SecUserEmail ;
      private string AV17HTML ;
      private string AV11NotificationTitle ;
      private string AV9NotificationMessage ;
      private string AV10NotificationType ;
      private string AV16NotificationLink ;
      private string A144SecUserEmail ;
      private string AV19message ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Messages ;
      private SdtBCNotification AV8BcNotification ;
      private IDataStoreProvider pr_default ;
      private bool[] P009H2_A380AprovadoresStatus ;
      private bool[] P009H2_n380AprovadoresStatus ;
      private short[] P009H2_A133SecUserId ;
      private bool[] P009H2_n133SecUserId ;
      private string[] P009H2_A144SecUserEmail ;
      private bool[] P009H2_n144SecUserEmail ;
      private int[] P009H2_A375AprovadoresId ;
      private SdtUserNotification AV15UserNotification ;
      private GxSimpleCollection<string> AV18Array_Email ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Messages ;
   }

   public class prenviarnotificacoesaprovadores__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009H2;
          prmP009H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P009H2", "SELECT T1.AprovadoresStatus, T1.SecUserId, T2.SecUserEmail, T1.AprovadoresId FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId) WHERE T1.AprovadoresStatus ORDER BY T1.AprovadoresId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
