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
   public class aprocessarfila : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprocessarfila().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      public aprocessarfila( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprocessarfila( IGxContext context )
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
         /* Using cursor P008U2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXT8U2 = 0;
            A358FilaProcessamentoStatus = P008U2_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = P008U2_n358FilaProcessamentoStatus[0];
            A356FilaProcessamentoFuncao = P008U2_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = P008U2_n356FilaProcessamentoFuncao[0];
            A357FilaProcessamentoParametros = P008U2_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = P008U2_n357FilaProcessamentoParametros[0];
            A360FilaProcessamentoAtualizacao = P008U2_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = P008U2_n360FilaProcessamentoAtualizacao[0];
            A355FilaProcessamentoId = P008U2_A355FilaProcessamentoId[0];
            if ( StringUtil.StrCmp(A356FilaProcessamentoFuncao, "ContratoAssinado") == 0 )
            {
               AV9AssinaturaId = (long)(Math.Round(NumberUtil.Val( A357FilaProcessamentoParametros, "."), 18, MidpointRounding.ToEven));
               if ( (0==AV8sdErro.gxTpr_Internalcode) )
               {
                  A358FilaProcessamentoStatus = "CONCLUIDO";
                  n358FilaProcessamentoStatus = false;
                  A360FilaProcessamentoAtualizacao = DateTimeUtil.ServerNow( context, pr_default);
                  n360FilaProcessamentoAtualizacao = false;
                  GXT8U2 = 1;
               }
               else
               {
                  GXT8U2 = 2;
               }
            }
            /* Using cursor P008U3 */
            pr_default.execute(1, new Object[] {n358FilaProcessamentoStatus, A358FilaProcessamentoStatus, n360FilaProcessamentoAtualizacao, A360FilaProcessamentoAtualizacao, A355FilaProcessamentoId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
            if ( GXT8U2 == 1 )
            {
               context.CommitDataStores("processarfila",pr_default);
            }
            if ( GXT8U2 == 2 )
            {
               context.RollbackDataStores("processarfila",pr_default);
            }
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
         P008U2_A358FilaProcessamentoStatus = new string[] {""} ;
         P008U2_n358FilaProcessamentoStatus = new bool[] {false} ;
         P008U2_A356FilaProcessamentoFuncao = new string[] {""} ;
         P008U2_n356FilaProcessamentoFuncao = new bool[] {false} ;
         P008U2_A357FilaProcessamentoParametros = new string[] {""} ;
         P008U2_n357FilaProcessamentoParametros = new bool[] {false} ;
         P008U2_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         P008U2_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         P008U2_A355FilaProcessamentoId = new int[1] ;
         A358FilaProcessamentoStatus = "";
         A356FilaProcessamentoFuncao = "";
         A357FilaProcessamentoParametros = "";
         A360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         AV8sdErro = new SdtSdErro(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprocessarfila__default(),
            new Object[][] {
                new Object[] {
               P008U2_A358FilaProcessamentoStatus, P008U2_n358FilaProcessamentoStatus, P008U2_A356FilaProcessamentoFuncao, P008U2_n356FilaProcessamentoFuncao, P008U2_A357FilaProcessamentoParametros, P008U2_n357FilaProcessamentoParametros, P008U2_A360FilaProcessamentoAtualizacao, P008U2_n360FilaProcessamentoAtualizacao, P008U2_A355FilaProcessamentoId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXT8U2 ;
      private int A355FilaProcessamentoId ;
      private long AV9AssinaturaId ;
      private DateTime A360FilaProcessamentoAtualizacao ;
      private bool n358FilaProcessamentoStatus ;
      private bool n356FilaProcessamentoFuncao ;
      private bool n357FilaProcessamentoParametros ;
      private bool n360FilaProcessamentoAtualizacao ;
      private string A357FilaProcessamentoParametros ;
      private string A358FilaProcessamentoStatus ;
      private string A356FilaProcessamentoFuncao ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008U2_A358FilaProcessamentoStatus ;
      private bool[] P008U2_n358FilaProcessamentoStatus ;
      private string[] P008U2_A356FilaProcessamentoFuncao ;
      private bool[] P008U2_n356FilaProcessamentoFuncao ;
      private string[] P008U2_A357FilaProcessamentoParametros ;
      private bool[] P008U2_n357FilaProcessamentoParametros ;
      private DateTime[] P008U2_A360FilaProcessamentoAtualizacao ;
      private bool[] P008U2_n360FilaProcessamentoAtualizacao ;
      private int[] P008U2_A355FilaProcessamentoId ;
      private SdtSdErro AV8sdErro ;
   }

   public class aprocessarfila__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008U2;
          prmP008U2 = new Object[] {
          };
          Object[] prmP008U3;
          prmP008U3 = new Object[] {
          new ParDef("FilaProcessamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("FilaProcessamentoAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008U2", "SELECT FilaProcessamentoStatus, FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoAtualizacao, FilaProcessamentoId FROM FilaProcessamento WHERE FilaProcessamentoStatus = ( 'PENDENTE') ORDER BY FilaProcessamentoId  FOR UPDATE OF FilaProcessamento",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008U3", "SAVEPOINT gxupdate;UPDATE FilaProcessamento SET FilaProcessamentoStatus=:FilaProcessamentoStatus, FilaProcessamentoAtualizacao=:FilaProcessamentoAtualizacao  WHERE FilaProcessamentoId = :FilaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008U3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
