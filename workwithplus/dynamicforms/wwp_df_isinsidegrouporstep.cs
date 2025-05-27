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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_isinsidegrouporstep : GXProcedure
   {
      public wwp_df_isinsidegrouporstep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_isinsidegrouporstep( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           short aP1_WWPFormVersionNumber ,
                           short aP2_WWPFormElementId ,
                           out bool aP3_IsInsideGroup )
      {
         this.AV10WWPFormId = aP0_WWPFormId;
         this.AV11WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV8WWPFormElementId = aP2_WWPFormElementId;
         this.AV9IsInsideGroup = false ;
         initialize();
         ExecuteImpl();
         aP3_IsInsideGroup=this.AV9IsInsideGroup;
      }

      public bool executeUdp( short aP0_WWPFormId ,
                              short aP1_WWPFormVersionNumber ,
                              short aP2_WWPFormElementId )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, aP2_WWPFormElementId, out aP3_IsInsideGroup);
         return AV9IsInsideGroup ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 short aP2_WWPFormElementId ,
                                 out bool aP3_IsInsideGroup )
      {
         this.AV10WWPFormId = aP0_WWPFormId;
         this.AV11WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV8WWPFormElementId = aP2_WWPFormElementId;
         this.AV9IsInsideGroup = false ;
         SubmitImpl();
         aP3_IsInsideGroup=this.AV9IsInsideGroup;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsInsideGroup = false;
         /* Using cursor P003U2 */
         pr_default.execute(0, new Object[] {AV10WWPFormId, AV11WWPFormVersionNumber, AV8WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A98WWPFormElementId = P003U2_A98WWPFormElementId[0];
            A95WWPFormVersionNumber = P003U2_A95WWPFormVersionNumber[0];
            A94WWPFormId = P003U2_A94WWPFormId[0];
            A105WWPFormElementType = P003U2_A105WWPFormElementType[0];
            A99WWPFormElementParentId = P003U2_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = P003U2_n99WWPFormElementParentId[0];
            if ( ( A105WWPFormElementType == 2 ) || ( A105WWPFormElementType == 5 ) )
            {
               AV9IsInsideGroup = true;
            }
            else
            {
               if ( A105WWPFormElementType == 3 )
               {
                  GXt_boolean1 = AV9IsInsideGroup;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_isinsidegrouporstep(context ).execute(  AV10WWPFormId,  AV11WWPFormVersionNumber,  A99WWPFormElementParentId, out  GXt_boolean1) ;
                  AV9IsInsideGroup = (bool)(AV9IsInsideGroup||GXt_boolean1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         P003U2_A98WWPFormElementId = new short[1] ;
         P003U2_A95WWPFormVersionNumber = new short[1] ;
         P003U2_A94WWPFormId = new short[1] ;
         P003U2_A105WWPFormElementType = new short[1] ;
         P003U2_A99WWPFormElementParentId = new short[1] ;
         P003U2_n99WWPFormElementParentId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_isinsidegrouporstep__default(),
            new Object[][] {
                new Object[] {
               P003U2_A98WWPFormElementId, P003U2_A95WWPFormVersionNumber, P003U2_A94WWPFormId, P003U2_A105WWPFormElementType, P003U2_A99WWPFormElementParentId, P003U2_n99WWPFormElementParentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPFormId ;
      private short AV11WWPFormVersionNumber ;
      private short AV8WWPFormElementId ;
      private short A98WWPFormElementId ;
      private short A95WWPFormVersionNumber ;
      private short A94WWPFormId ;
      private short A105WWPFormElementType ;
      private short A99WWPFormElementParentId ;
      private bool AV9IsInsideGroup ;
      private bool n99WWPFormElementParentId ;
      private bool GXt_boolean1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003U2_A98WWPFormElementId ;
      private short[] P003U2_A95WWPFormVersionNumber ;
      private short[] P003U2_A94WWPFormId ;
      private short[] P003U2_A105WWPFormElementType ;
      private short[] P003U2_A99WWPFormElementParentId ;
      private bool[] P003U2_n99WWPFormElementParentId ;
      private bool aP3_IsInsideGroup ;
   }

   public class wwp_df_isinsidegrouporstep__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003U2;
          prmP003U2 = new Object[] {
          new ParDef("AV10WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV11WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV8WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003U2", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :AV10WWPFormId and WWPFormVersionNumber = :AV11WWPFormVersionNumber and WWPFormElementId = :AV8WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003U2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
