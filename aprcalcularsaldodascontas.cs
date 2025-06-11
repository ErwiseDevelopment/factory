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
   public class aprcalcularsaldodascontas : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprcalcularsaldodascontas().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          int aP0_ContaId ;
         if ( 0 < args.Length )
         {
            aP0_ContaId=((int)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_ContaId=0;
         }
         execute(aP0_ContaId);
         return GX.GXRuntime.ExitCode ;
      }

      public aprcalcularsaldodascontas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprcalcularsaldodascontas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ContaId )
      {
         this.AV8ContaId = aP0_ContaId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_ContaId )
      {
         this.AV8ContaId = aP0_ContaId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8ContaId ,
                                              A422ContaId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00A52 */
         pr_default.execute(0, new Object[] {AV8ContaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422ContaId = P00A52_A422ContaId[0];
            n422ContaId = P00A52_n422ContaId[0];
            A423ContaSaldoAtual = P00A52_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = P00A52_n423ContaSaldoAtual[0];
            AV9SaldoValor = 0;
            /* Using cursor P00A53 */
            pr_default.execute(1, new Object[] {n422ContaId, A422ContaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A261TituloId = P00A53_A261TituloId[0];
               n261TituloId = P00A53_n261TituloId[0];
               A432TituloMovimentoOpe = P00A53_A432TituloMovimentoOpe[0];
               n432TituloMovimentoOpe = P00A53_n432TituloMovimentoOpe[0];
               A271TituloMovimentoValor = P00A53_A271TituloMovimentoValor[0];
               n271TituloMovimentoValor = P00A53_n271TituloMovimentoValor[0];
               A270TituloMovimentoId = P00A53_A270TituloMovimentoId[0];
               if ( StringUtil.StrCmp(A432TituloMovimentoOpe, "Entrada") == 0 )
               {
                  AV9SaldoValor = (decimal)(AV9SaldoValor+A271TituloMovimentoValor);
               }
               if ( StringUtil.StrCmp(A432TituloMovimentoOpe, "Saida") == 0 )
               {
                  AV9SaldoValor = (decimal)(AV9SaldoValor-A271TituloMovimentoValor);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            A423ContaSaldoAtual = AV9SaldoValor;
            n423ContaSaldoAtual = false;
            /* Using cursor P00A54 */
            pr_default.execute(2, new Object[] {n423ContaSaldoAtual, A423ContaSaldoAtual, n422ContaId, A422ContaId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Conta");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("prcalcularsaldodascontas",pr_default);
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
         P00A52_A422ContaId = new int[1] ;
         P00A52_n422ContaId = new bool[] {false} ;
         P00A52_A423ContaSaldoAtual = new decimal[1] ;
         P00A52_n423ContaSaldoAtual = new bool[] {false} ;
         P00A53_A261TituloId = new int[1] ;
         P00A53_n261TituloId = new bool[] {false} ;
         P00A53_A422ContaId = new int[1] ;
         P00A53_n422ContaId = new bool[] {false} ;
         P00A53_A432TituloMovimentoOpe = new string[] {""} ;
         P00A53_n432TituloMovimentoOpe = new bool[] {false} ;
         P00A53_A271TituloMovimentoValor = new decimal[1] ;
         P00A53_n271TituloMovimentoValor = new bool[] {false} ;
         P00A53_A270TituloMovimentoId = new int[1] ;
         A432TituloMovimentoOpe = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcalcularsaldodascontas__default(),
            new Object[][] {
                new Object[] {
               P00A52_A422ContaId, P00A52_A423ContaSaldoAtual, P00A52_n423ContaSaldoAtual
               }
               , new Object[] {
               P00A53_A261TituloId, P00A53_n261TituloId, P00A53_A422ContaId, P00A53_n422ContaId, P00A53_A432TituloMovimentoOpe, P00A53_n432TituloMovimentoOpe, P00A53_A271TituloMovimentoValor, P00A53_n271TituloMovimentoValor, P00A53_A270TituloMovimentoId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8ContaId ;
      private int A422ContaId ;
      private int A261TituloId ;
      private int A270TituloMovimentoId ;
      private decimal A423ContaSaldoAtual ;
      private decimal AV9SaldoValor ;
      private decimal A271TituloMovimentoValor ;
      private bool n422ContaId ;
      private bool n423ContaSaldoAtual ;
      private bool n261TituloId ;
      private bool n432TituloMovimentoOpe ;
      private bool n271TituloMovimentoValor ;
      private string A432TituloMovimentoOpe ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00A52_A422ContaId ;
      private bool[] P00A52_n422ContaId ;
      private decimal[] P00A52_A423ContaSaldoAtual ;
      private bool[] P00A52_n423ContaSaldoAtual ;
      private int[] P00A53_A261TituloId ;
      private bool[] P00A53_n261TituloId ;
      private int[] P00A53_A422ContaId ;
      private bool[] P00A53_n422ContaId ;
      private string[] P00A53_A432TituloMovimentoOpe ;
      private bool[] P00A53_n432TituloMovimentoOpe ;
      private decimal[] P00A53_A271TituloMovimentoValor ;
      private bool[] P00A53_n271TituloMovimentoValor ;
      private int[] P00A53_A270TituloMovimentoId ;
   }

   public class aprcalcularsaldodascontas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A52( IGxContext context ,
                                             int AV8ContaId ,
                                             int A422ContaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ContaId, ContaSaldoAtual FROM Conta";
         if ( ! (0==AV8ContaId) )
         {
            AddWhere(sWhereString, "(ContaId = :AV8ContaId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ContaId";
         scmdbuf += " FOR UPDATE OF Conta";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00A52(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A53;
          prmP00A53 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmP00A54;
          prmP00A54 = new Object[] {
          new ParDef("ContaSaldoAtual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmP00A52;
          prmP00A52 = new Object[] {
          new ParDef("AV8ContaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A52", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A52,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A53", "SELECT T1.TituloId, T2.ContaId, T1.TituloMovimentoOpe, T1.TituloMovimentoValor, T1.TituloMovimentoId FROM (TituloMovimento T1 LEFT JOIN Titulo T2 ON T2.TituloId = T1.TituloId) WHERE T2.ContaId = :ContaId ORDER BY T1.TituloMovimentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A53,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00A54", "SAVEPOINT gxupdate;UPDATE Conta SET ContaSaldoAtual=:ContaSaldoAtual  WHERE ContaId = :ContaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A54)
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
