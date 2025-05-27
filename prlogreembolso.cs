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
   public class prlogreembolso : GXProcedure
   {
      public prlogreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prlogreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ReembolsoId ,
                           int aP1_WorkflowConvenioId ,
                           short aP2_SecUserId )
      {
         this.AV11ReembolsoId = aP0_ReembolsoId;
         this.AV9WorkflowConvenioId = aP1_WorkflowConvenioId;
         this.AV10SecUserId = aP2_SecUserId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_ReembolsoId ,
                                 int aP1_WorkflowConvenioId ,
                                 short aP2_SecUserId )
      {
         this.AV11ReembolsoId = aP0_ReembolsoId;
         this.AV9WorkflowConvenioId = aP1_WorkflowConvenioId;
         this.AV10SecUserId = aP2_SecUserId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A761ReembolsoFlowLogDataFinal = P00CO2_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = P00CO2_n761ReembolsoFlowLogDataFinal[0];
            A747ReembolsoFlowLogDate = P00CO2_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = P00CO2_n747ReembolsoFlowLogDate[0];
            A746ReembolsoFlowLogId = P00CO2_A746ReembolsoFlowLogId[0];
            A761ReembolsoFlowLogDataFinal = DateTimeUtil.ServerNow( context, pr_default);
            n761ReembolsoFlowLogDataFinal = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00CO3 */
            pr_default.execute(1, new Object[] {n761ReembolsoFlowLogDataFinal, A761ReembolsoFlowLogDataFinal, A746ReembolsoFlowLogId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
            if (true) break;
            /* Using cursor P00CO4 */
            pr_default.execute(2, new Object[] {n761ReembolsoFlowLogDataFinal, A761ReembolsoFlowLogDataFinal, A746ReembolsoFlowLogId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8ReembolsoFlowLog = new SdtReembolsoFlowLog(context);
         AV8ReembolsoFlowLog.gxTpr_Logworkflowconvenioid = AV9WorkflowConvenioId;
         AV8ReembolsoFlowLog.gxTpr_Reembolsoflowlogdate = DateTimeUtil.ServerNow( context, pr_default);
         AV8ReembolsoFlowLog.gxTpr_Reembolsoflowloguser = AV10SecUserId;
         AV8ReembolsoFlowLog.gxTpr_Reembolsologid = AV11ReembolsoId;
         AV8ReembolsoFlowLog.Save();
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
         P00CO2_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         P00CO2_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         P00CO2_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CO2_n747ReembolsoFlowLogDate = new bool[] {false} ;
         P00CO2_A746ReembolsoFlowLogId = new int[1] ;
         A761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         AV8ReembolsoFlowLog = new SdtReembolsoFlowLog(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prlogreembolso__default(),
            new Object[][] {
                new Object[] {
               P00CO2_A761ReembolsoFlowLogDataFinal, P00CO2_n761ReembolsoFlowLogDataFinal, P00CO2_A747ReembolsoFlowLogDate, P00CO2_n747ReembolsoFlowLogDate, P00CO2_A746ReembolsoFlowLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10SecUserId ;
      private int AV11ReembolsoId ;
      private int AV9WorkflowConvenioId ;
      private int A746ReembolsoFlowLogId ;
      private DateTime A761ReembolsoFlowLogDataFinal ;
      private DateTime A747ReembolsoFlowLogDate ;
      private bool n761ReembolsoFlowLogDataFinal ;
      private bool n747ReembolsoFlowLogDate ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00CO2_A761ReembolsoFlowLogDataFinal ;
      private bool[] P00CO2_n761ReembolsoFlowLogDataFinal ;
      private DateTime[] P00CO2_A747ReembolsoFlowLogDate ;
      private bool[] P00CO2_n747ReembolsoFlowLogDate ;
      private int[] P00CO2_A746ReembolsoFlowLogId ;
      private SdtReembolsoFlowLog AV8ReembolsoFlowLog ;
   }

   public class prlogreembolso__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CO2;
          prmP00CO2 = new Object[] {
          };
          Object[] prmP00CO3;
          prmP00CO3 = new Object[] {
          new ParDef("ReembolsoFlowLogDataFinal",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmP00CO4;
          prmP00CO4 = new Object[] {
          new ParDef("ReembolsoFlowLogDataFinal",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CO2", "SELECT ReembolsoFlowLogDataFinal, ReembolsoFlowLogDate, ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogDataFinal IS NULL or (ReembolsoFlowLogDataFinal = DATE '00010101') ORDER BY ReembolsoFlowLogDate DESC  FOR UPDATE OF ReembolsoFlowLog",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CO2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CO3", "SAVEPOINT gxupdate;UPDATE ReembolsoFlowLog SET ReembolsoFlowLogDataFinal=:ReembolsoFlowLogDataFinal  WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CO3)
             ,new CursorDef("P00CO4", "SAVEPOINT gxupdate;UPDATE ReembolsoFlowLog SET ReembolsoFlowLogDataFinal=:ReembolsoFlowLogDataFinal  WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CO4)
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
