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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secgetrolesfromloggeduser : GXProcedure
   {
      public secgetrolesfromloggeduser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgetrolesfromloggeduser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<short> aP0_SecRoleIds )
      {
         this.AV8SecRoleIds = new GxSimpleCollection<short>() ;
         initialize();
         ExecuteImpl();
         aP0_SecRoleIds=this.AV8SecRoleIds;
      }

      public GxSimpleCollection<short> executeUdp( )
      {
         execute(out aP0_SecRoleIds);
         return AV8SecRoleIds ;
      }

      public void executeSubmit( out GxSimpleCollection<short> aP0_SecRoleIds )
      {
         this.AV8SecRoleIds = new GxSimpleCollection<short>() ;
         SubmitImpl();
         aP0_SecRoleIds=this.AV8SecRoleIds;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SecRoleIdsXML = StringUtil.Trim( AV11WebSession.Get("SecGetRolesFromLoggedUser"));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9SecRoleIdsXML)) )
         {
            GXt_SdtWWPContext1 = AV12WWPContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
            AV12WWPContext = GXt_SdtWWPContext1;
            AV10SecUserId = AV12WWPContext.gxTpr_Userid;
            AV8SecRoleIds = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
            /* Using cursor P004R2 */
            pr_default.execute(0, new Object[] {AV10SecUserId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A646SecRoleActive = P004R2_A646SecRoleActive[0];
               n646SecRoleActive = P004R2_n646SecRoleActive[0];
               A133SecUserId = P004R2_A133SecUserId[0];
               A131SecRoleId = P004R2_A131SecRoleId[0];
               A646SecRoleActive = P004R2_A646SecRoleActive[0];
               n646SecRoleActive = P004R2_n646SecRoleActive[0];
               AV8SecRoleIds.Add(A131SecRoleId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV8SecRoleIds.Count > 0 )
            {
               AV9SecRoleIdsXML = AV8SecRoleIds.ToXml(false, true, "Collection", "");
               AV11WebSession.Set("SecGetRolesFromLoggedUser", AV9SecRoleIdsXML);
            }
         }
         else
         {
            AV8SecRoleIds.FromXml(AV9SecRoleIdsXML, null, "Collection", "");
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
         AV8SecRoleIds = new GxSimpleCollection<short>();
         AV9SecRoleIdsXML = "";
         AV11WebSession = context.GetSession();
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P004R2_A646SecRoleActive = new bool[] {false} ;
         P004R2_n646SecRoleActive = new bool[] {false} ;
         P004R2_A133SecUserId = new short[1] ;
         P004R2_A131SecRoleId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secgetrolesfromloggeduser__default(),
            new Object[][] {
                new Object[] {
               P004R2_A646SecRoleActive, P004R2_n646SecRoleActive, P004R2_A133SecUserId, P004R2_A131SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10SecUserId ;
      private short A133SecUserId ;
      private short A131SecRoleId ;
      private bool A646SecRoleActive ;
      private bool n646SecRoleActive ;
      private string AV9SecRoleIdsXML ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV8SecRoleIds ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private bool[] P004R2_A646SecRoleActive ;
      private bool[] P004R2_n646SecRoleActive ;
      private short[] P004R2_A133SecUserId ;
      private short[] P004R2_A131SecRoleId ;
      private GxSimpleCollection<short> aP0_SecRoleIds ;
   }

   public class secgetrolesfromloggeduser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004R2;
          prmP004R2 = new Object[] {
          new ParDef("AV10SecUserId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004R2", "SELECT T2.SecRoleActive, T1.SecUserId, T1.SecRoleId FROM (SecUserRole T1 INNER JOIN SecRole T2 ON T2.SecRoleId = T1.SecRoleId) WHERE (T1.SecUserId = :AV10SecUserId) AND (T2.SecRoleActive) ORDER BY T1.SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
