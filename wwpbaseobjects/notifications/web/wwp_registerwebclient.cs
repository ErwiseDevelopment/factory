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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_registerwebclient : GXProcedure
   {
      public wwp_registerwebclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_registerwebclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClientId ,
                           short aP1_BrowserId ,
                           string aP2_BrowserVersion ,
                           string aP3_UserGUID )
      {
         this.AV10ClientId = aP0_ClientId;
         this.AV8BrowserId = aP1_BrowserId;
         this.AV9BrowserVersion = aP2_BrowserVersion;
         this.AV12UserGUID = aP3_UserGUID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 short aP1_BrowserId ,
                                 string aP2_BrowserVersion ,
                                 string aP3_UserGUID )
      {
         this.AV10ClientId = aP0_ClientId;
         this.AV8BrowserId = aP1_BrowserId;
         this.AV9BrowserVersion = aP2_BrowserVersion;
         this.AV12UserGUID = aP3_UserGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Begin Web Client Registration") ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12UserGUID)) )
         {
            GXt_char1 = AV12UserGUID;
            new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
            AV12UserGUID = GXt_char1;
         }
         if ( ! new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended(context).executeUdp(  AV12UserGUID) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  StringUtil.Format( "Creating User Extended %1...", AV12UserGUID, "", "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  AV12UserGUID,  "") ;
         }
         AV14GXLvl9 = 0;
         /* Using cursor P002Q2 */
         pr_default.execute(0, new Object[] {AV10ClientId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A48WWPWebClientId = P002Q2_A48WWPWebClientId[0];
            A49WWPWebClientBrowserId = P002Q2_A49WWPWebClientBrowserId[0];
            A50WWPWebClientBrowserVersion = P002Q2_A50WWPWebClientBrowserVersion[0];
            A52WWPWebClientLastRegistered = P002Q2_A52WWPWebClientLastRegistered[0];
            A7WWPUserExtendedId = P002Q2_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = P002Q2_n7WWPUserExtendedId[0];
            AV14GXLvl9 = 1;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Updating Web Client") ;
            A49WWPWebClientBrowserId = AV8BrowserId;
            A50WWPWebClientBrowserVersion = AV9BrowserVersion;
            A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A7WWPUserExtendedId = AV12UserGUID;
            n7WWPUserExtendedId = false;
            /* Using cursor P002Q3 */
            pr_default.execute(1, new Object[] {A49WWPWebClientBrowserId, A50WWPWebClientBrowserVersion, A52WWPWebClientLastRegistered, n7WWPUserExtendedId, A7WWPUserExtendedId, A48WWPWebClientId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl9 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Creating Web Client") ;
            /*
               INSERT RECORD ON TABLE WWP_WebClient

            */
            A48WWPWebClientId = AV10ClientId;
            A49WWPWebClientBrowserId = AV8BrowserId;
            A50WWPWebClientBrowserVersion = AV9BrowserVersion;
            A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A7WWPUserExtendedId = AV12UserGUID;
            n7WWPUserExtendedId = false;
            /* Using cursor P002Q4 */
            pr_default.execute(2, new Object[] {A48WWPWebClientId, A49WWPWebClientBrowserId, A50WWPWebClientBrowserVersion, A51WWPWebClientFirstRegistered, A52WWPWebClientLastRegistered, n7WWPUserExtendedId, A7WWPUserExtendedId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Completed Web Client Registration") ;
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
         AV13Pgmname = "";
         GXt_char1 = "";
         P002Q2_A48WWPWebClientId = new string[] {""} ;
         P002Q2_A49WWPWebClientBrowserId = new short[1] ;
         P002Q2_A50WWPWebClientBrowserVersion = new string[] {""} ;
         P002Q2_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         P002Q2_A7WWPUserExtendedId = new string[] {""} ;
         P002Q2_n7WWPUserExtendedId = new bool[] {false} ;
         A48WWPWebClientId = "";
         A50WWPWebClientBrowserVersion = "";
         A52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A7WWPUserExtendedId = "";
         A51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient__default(),
            new Object[][] {
                new Object[] {
               P002Q2_A48WWPWebClientId, P002Q2_A49WWPWebClientBrowserId, P002Q2_A50WWPWebClientBrowserVersion, P002Q2_A52WWPWebClientLastRegistered, P002Q2_A7WWPUserExtendedId, P002Q2_n7WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         AV13Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
         /* GeneXus formulas. */
         AV13Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
      }

      private short AV8BrowserId ;
      private short AV14GXLvl9 ;
      private short A49WWPWebClientBrowserId ;
      private int GX_INS7 ;
      private string AV10ClientId ;
      private string AV12UserGUID ;
      private string AV13Pgmname ;
      private string GXt_char1 ;
      private string A48WWPWebClientId ;
      private string A7WWPUserExtendedId ;
      private string Gx_emsg ;
      private DateTime A52WWPWebClientLastRegistered ;
      private DateTime A51WWPWebClientFirstRegistered ;
      private bool n7WWPUserExtendedId ;
      private string AV9BrowserVersion ;
      private string A50WWPWebClientBrowserVersion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002Q2_A48WWPWebClientId ;
      private short[] P002Q2_A49WWPWebClientBrowserId ;
      private string[] P002Q2_A50WWPWebClientBrowserVersion ;
      private DateTime[] P002Q2_A52WWPWebClientLastRegistered ;
      private string[] P002Q2_A7WWPUserExtendedId ;
      private bool[] P002Q2_n7WWPUserExtendedId ;
   }

   public class wwp_registerwebclient__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002Q2;
          prmP002Q2 = new Object[] {
          new ParDef("AV10ClientId",GXType.Char,100,0)
          };
          Object[] prmP002Q3;
          prmP002Q3 = new Object[] {
          new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
          new ParDef("WWPWebClientId",GXType.Char,100,0)
          };
          Object[] prmP002Q4;
          prmP002Q4 = new Object[] {
          new ParDef("WWPWebClientId",GXType.Char,100,0) ,
          new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P002Q2", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = ( :AV10ClientId) ORDER BY WWPWebClientId  FOR UPDATE OF WWP_WebClient",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002Q3", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002Q3)
             ,new CursorDef("P002Q4", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP002Q4)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
