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
   public class wwp_df_getsimpleelementofmultipledata : GXProcedure
   {
      public wwp_df_getsimpleelementofmultipledata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getsimpleelementofmultipledata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           short aP1_WWPFormVersionNumber ,
                           ref short aP2_WWPFormElementId )
      {
         this.AV9WWPFormId = aP0_WWPFormId;
         this.AV8WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV11WWPFormElementId = aP2_WWPFormElementId;
         initialize();
         ExecuteImpl();
         aP2_WWPFormElementId=this.AV11WWPFormElementId;
      }

      public short executeUdp( short aP0_WWPFormId ,
                               short aP1_WWPFormVersionNumber )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, ref aP2_WWPFormElementId);
         return AV11WWPFormElementId ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 ref short aP2_WWPFormElementId )
      {
         this.AV9WWPFormId = aP0_WWPFormId;
         this.AV8WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV11WWPFormElementId = aP2_WWPFormElementId;
         SubmitImpl();
         aP2_WWPFormElementId=this.AV11WWPFormElementId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P003C2 */
         pr_default.execute(0, new Object[] {AV9WWPFormId, AV8WWPFormVersionNumber, AV11WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A99WWPFormElementParentId = P003C2_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = P003C2_n99WWPFormElementParentId[0];
            A95WWPFormVersionNumber = P003C2_A95WWPFormVersionNumber[0];
            A94WWPFormId = P003C2_A94WWPFormId[0];
            A98WWPFormElementId = P003C2_A98WWPFormElementId[0];
            A105WWPFormElementType = P003C2_A105WWPFormElementType[0];
            AV10WWPFormElementIdAux = A98WWPFormElementId;
            if ( A105WWPFormElementType == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            else
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata(context ).execute(  AV9WWPFormId,  AV8WWPFormVersionNumber, ref  AV10WWPFormElementIdAux) ;
               if ( ! (0==AV10WWPFormElementIdAux) )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11WWPFormElementId = AV10WWPFormElementIdAux;
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
         P003C2_A99WWPFormElementParentId = new short[1] ;
         P003C2_n99WWPFormElementParentId = new bool[] {false} ;
         P003C2_A95WWPFormVersionNumber = new short[1] ;
         P003C2_A94WWPFormId = new short[1] ;
         P003C2_A98WWPFormElementId = new short[1] ;
         P003C2_A105WWPFormElementType = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata__default(),
            new Object[][] {
                new Object[] {
               P003C2_A99WWPFormElementParentId, P003C2_n99WWPFormElementParentId, P003C2_A95WWPFormVersionNumber, P003C2_A94WWPFormId, P003C2_A98WWPFormElementId, P003C2_A105WWPFormElementType
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9WWPFormId ;
      private short AV8WWPFormVersionNumber ;
      private short AV11WWPFormElementId ;
      private short A99WWPFormElementParentId ;
      private short A95WWPFormVersionNumber ;
      private short A94WWPFormId ;
      private short A98WWPFormElementId ;
      private short A105WWPFormElementType ;
      private short AV10WWPFormElementIdAux ;
      private bool n99WWPFormElementParentId ;
      private IGxDataStore dsDefault ;
      private short aP2_WWPFormElementId ;
      private IDataStoreProvider pr_default ;
      private short[] P003C2_A99WWPFormElementParentId ;
      private bool[] P003C2_n99WWPFormElementParentId ;
      private short[] P003C2_A95WWPFormVersionNumber ;
      private short[] P003C2_A94WWPFormId ;
      private short[] P003C2_A98WWPFormElementId ;
      private short[] P003C2_A105WWPFormElementType ;
   }

   public class wwp_df_getsimpleelementofmultipledata__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003C2;
          prmP003C2 = new Object[] {
          new ParDef("AV9WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV8WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV11WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003C2", "SELECT WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementId, WWPFormElementType FROM WWP_FormElement WHERE WWPFormId = :AV9WWPFormId and WWPFormVersionNumber = :AV8WWPFormVersionNumber and WWPFormElementParentId = :AV11WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementParentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
