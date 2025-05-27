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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_hassubscriptionstodisplay : GXProcedure
   {
      public wwp_hassubscriptionstodisplay( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_hassubscriptionstodisplay( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           out bool aP2_HasSubscriptions )
      {
         this.AV11WWPEntityName = aP0_WWPEntityName;
         this.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV9HasSubscriptions = false ;
         initialize();
         ExecuteImpl();
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              short aP1_WWPNotificationAppliesTo )
      {
         execute(aP0_WWPEntityName, aP1_WWPNotificationAppliesTo, out aP2_HasSubscriptions);
         return AV9HasSubscriptions ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 short aP1_WWPNotificationAppliesTo ,
                                 out bool aP2_HasSubscriptions )
      {
         this.AV11WWPEntityName = aP0_WWPEntityName;
         this.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV9HasSubscriptions = false ;
         SubmitImpl();
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV8WWPEntityId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV11WWPEntityName, out  GXt_int1) ;
         AV8WWPEntityId = GXt_int1;
         AV9HasSubscriptions = false;
         /* Using cursor P00352 */
         pr_default.execute(0, new Object[] {AV8WWPEntityId, AV10WWPNotificationAppliesTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A68WWPNotificationDefinitionIsAuthorized = P00352_A68WWPNotificationDefinitionIsAuthorized[0];
            A20WWPEntityId = P00352_A20WWPEntityId[0];
            A30WWPNotificationDefinitionAppliesTo = P00352_A30WWPNotificationDefinitionAppliesTo[0];
            A31WWPNotificationDefinitionAllowUserSubscription = P00352_A31WWPNotificationDefinitionAllowUserSubscription[0];
            A67WWPNotificationDefinitionSecFuncionality = P00352_A67WWPNotificationDefinitionSecFuncionality[0];
            A23WWPNotificationDefinitionId = P00352_A23WWPNotificationDefinitionId[0];
            AV9HasSubscriptions = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00352_A68WWPNotificationDefinitionIsAuthorized = new bool[] {false} ;
         P00352_A20WWPEntityId = new long[1] ;
         P00352_A30WWPNotificationDefinitionAppliesTo = new short[1] ;
         P00352_A31WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         P00352_A67WWPNotificationDefinitionSecFuncionality = new string[] {""} ;
         P00352_A23WWPNotificationDefinitionId = new long[1] ;
         A67WWPNotificationDefinitionSecFuncionality = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay__default(),
            new Object[][] {
                new Object[] {
               P00352_A68WWPNotificationDefinitionIsAuthorized, P00352_A20WWPEntityId, P00352_A30WWPNotificationDefinitionAppliesTo, P00352_A31WWPNotificationDefinitionAllowUserSubscription, P00352_A67WWPNotificationDefinitionSecFuncionality, P00352_A23WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPNotificationAppliesTo ;
      private short A30WWPNotificationDefinitionAppliesTo ;
      private long AV8WWPEntityId ;
      private long GXt_int1 ;
      private long A20WWPEntityId ;
      private long A23WWPNotificationDefinitionId ;
      private bool AV9HasSubscriptions ;
      private bool A68WWPNotificationDefinitionIsAuthorized ;
      private bool A31WWPNotificationDefinitionAllowUserSubscription ;
      private string AV11WWPEntityName ;
      private string A67WWPNotificationDefinitionSecFuncionality ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P00352_A68WWPNotificationDefinitionIsAuthorized ;
      private long[] P00352_A20WWPEntityId ;
      private short[] P00352_A30WWPNotificationDefinitionAppliesTo ;
      private bool[] P00352_A31WWPNotificationDefinitionAllowUserSubscription ;
      private string[] P00352_A67WWPNotificationDefinitionSecFuncionality ;
      private long[] P00352_A23WWPNotificationDefinitionId ;
      private bool aP2_HasSubscriptions ;
   }

   public class wwp_hassubscriptionstodisplay__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00352;
          prmP00352 = new Object[] {
          new ParDef("AV8WWPEntityId",GXType.Int64,10,0) ,
          new ParDef("AV10WWPNotificationAppliesTo",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00352", "SELECT CASE  WHEN (char_length(trim(trailing ' ' from WWPNotificationDefinitionSecFuncionality))=0) THEN TRUE END AS WWPNotificationDefinitionIsAuthorized, WWPEntityId, WWPNotificationDefinitionAppliesTo, WWPNotificationDefinitionAllowUserSubscription, WWPNotificationDefinitionSecFuncionality, WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV8WWPEntityId) AND (WWPNotificationDefinitionAllowUserSubscription = TRUE) AND (WWPNotificationDefinitionAppliesTo = :AV10WWPNotificationAppliesTo) AND (CASE  WHEN (char_length(trim(trailing ' ' from WWPNotificationDefinitionSecFuncionality))=0) THEN TRUE END = TRUE) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00352,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
