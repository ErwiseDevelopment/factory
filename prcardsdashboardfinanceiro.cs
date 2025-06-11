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
   public class prcardsdashboardfinanceiro : GXProcedure
   {
      public prcardsdashboardfinanceiro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcardsdashboardfinanceiro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_Competencia ,
                           bool aP1_Visible ,
                           out GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> aP2_SdDashboardFinanceiroCards )
      {
         this.AV9Competencia = aP0_Competencia;
         this.AV16Visible = aP1_Visible;
         this.AV12SdDashboardFinanceiroCards = new GXBaseCollection<SdtSdDashboardFinanceiroCards_Item>( context, "Item", "Factory21") ;
         initialize();
         ExecuteImpl();
         aP2_SdDashboardFinanceiroCards=this.AV12SdDashboardFinanceiroCards;
      }

      public GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> executeUdp( int aP0_Competencia ,
                                                                              bool aP1_Visible )
      {
         execute(aP0_Competencia, aP1_Visible, out aP2_SdDashboardFinanceiroCards);
         return AV12SdDashboardFinanceiroCards ;
      }

      public void executeSubmit( int aP0_Competencia ,
                                 bool aP1_Visible ,
                                 out GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> aP2_SdDashboardFinanceiroCards )
      {
         this.AV9Competencia = aP0_Competencia;
         this.AV16Visible = aP1_Visible;
         this.AV12SdDashboardFinanceiroCards = new GXBaseCollection<SdtSdDashboardFinanceiroCards_Item>( context, "Item", "Factory21") ;
         SubmitImpl();
         aP2_SdDashboardFinanceiroCards=this.AV12SdDashboardFinanceiroCards;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14TituloCompetenciaAno = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( StringUtil.Str( (decimal)(AV9Competencia), 6, 0), 1, 4), "."), 18, MidpointRounding.ToEven));
         AV15TituloCompetenciaMes = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( StringUtil.Str( (decimal)(AV9Competencia), 6, 0), 5, 2), "."), 18, MidpointRounding.ToEven));
         AV11InicioTituloMovimentoDataCredito = DateTimeUtil.ResetTime(context.localUtil.YMDHMSToT( AV14TituloCompetenciaAno, AV15TituloCompetenciaMes, 1, 0, 0, 0));
         AV10FimTituloMovimentoDataCredito = DateTimeUtil.DateEndOfMonth( AV11InicioTituloMovimentoDataCredito);
         AV10FimTituloMovimentoDataCredito = DateTimeUtil.ResetTime(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV10FimTituloMovimentoDataCredito)), (short)(DateTimeUtil.Month( AV10FimTituloMovimentoDataCredito)), (short)(DateTimeUtil.Day( AV10FimTituloMovimentoDataCredito)), 23, 59, 59));
         AV12SdDashboardFinanceiroCards = new GXBaseCollection<SdtSdDashboardFinanceiroCards_Item>( context, "Item", "Factory21");
         AV8AuxValor = 0;
         /* Using cursor P00893 */
         pr_default.execute(0, new Object[] {AV14TituloCompetenciaAno, AV15TituloCompetenciaMes});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A287TituloCompetenciaMes = P00893_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00893_n287TituloCompetenciaMes[0];
            A286TituloCompetenciaAno = P00893_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00893_n286TituloCompetenciaAno[0];
            A283TituloTipo = P00893_A283TituloTipo[0];
            n283TituloTipo = P00893_n283TituloTipo[0];
            A261TituloId = P00893_A261TituloId[0];
            n261TituloId = P00893_n261TituloId[0];
            A273TituloTotalMovimento_F = P00893_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = P00893_n273TituloTotalMovimento_F[0];
            A276TituloDesconto = P00893_A276TituloDesconto[0];
            n276TituloDesconto = P00893_n276TituloDesconto[0];
            A262TituloValor = P00893_A262TituloValor[0];
            n262TituloValor = P00893_n262TituloValor[0];
            A273TituloTotalMovimento_F = P00893_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = P00893_n273TituloTotalMovimento_F[0];
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            AV8AuxValor = (decimal)(AV8AuxValor+A275TituloSaldo_F);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13SdDashboardFinanceiroCardsItem = new SdtSdDashboardFinanceiroCards_Item(context);
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Valor = "R$"+context.localUtil.Format( AV8AuxValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Title = "A receber";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Visible = AV16Visible;
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Icon = "fa-solid fa-arrow-up";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Class = "PanelCardIcon_Success";
         AV12SdDashboardFinanceiroCards.Add(AV13SdDashboardFinanceiroCardsItem, 0);
         AV8AuxValor = 0;
         /* Using cursor P00895 */
         pr_default.execute(1, new Object[] {AV14TituloCompetenciaAno, AV15TituloCompetenciaMes});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A287TituloCompetenciaMes = P00895_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00895_n287TituloCompetenciaMes[0];
            A286TituloCompetenciaAno = P00895_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00895_n286TituloCompetenciaAno[0];
            A283TituloTipo = P00895_A283TituloTipo[0];
            n283TituloTipo = P00895_n283TituloTipo[0];
            A261TituloId = P00895_A261TituloId[0];
            n261TituloId = P00895_n261TituloId[0];
            A273TituloTotalMovimento_F = P00895_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = P00895_n273TituloTotalMovimento_F[0];
            A276TituloDesconto = P00895_A276TituloDesconto[0];
            n276TituloDesconto = P00895_n276TituloDesconto[0];
            A262TituloValor = P00895_A262TituloValor[0];
            n262TituloValor = P00895_n262TituloValor[0];
            A273TituloTotalMovimento_F = P00895_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = P00895_n273TituloTotalMovimento_F[0];
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            AV8AuxValor = (decimal)(AV8AuxValor+A275TituloSaldo_F);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV13SdDashboardFinanceiroCardsItem = new SdtSdDashboardFinanceiroCards_Item(context);
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Valor = "R$"+context.localUtil.Format( AV8AuxValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Title = "A pagar";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Visible = AV16Visible;
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Icon = "fa-solid fa-arrow-down";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Class = "PanelCardIcon_Danger";
         AV12SdDashboardFinanceiroCards.Add(AV13SdDashboardFinanceiroCardsItem, 0);
         /* Optimized group. */
         /* Using cursor P00896 */
         pr_default.execute(2, new Object[] {AV11InicioTituloMovimentoDataCredito, AV10FimTituloMovimentoDataCredito});
         c271TituloMovimentoValor = P00896_A271TituloMovimentoValor[0];
         n271TituloMovimentoValor = P00896_n271TituloMovimentoValor[0];
         pr_default.close(2);
         AV8AuxValor = (decimal)(AV8AuxValor+c271TituloMovimentoValor);
         /* End optimized group. */
         AV13SdDashboardFinanceiroCardsItem = new SdtSdDashboardFinanceiroCards_Item(context);
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Valor = "R$"+context.localUtil.Format( AV8AuxValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Title = "Entrada";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Visible = AV16Visible;
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Icon = "fa-solid fa-hand-holding-dollar";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Class = "PanelCardIcon_Success";
         AV12SdDashboardFinanceiroCards.Add(AV13SdDashboardFinanceiroCardsItem, 0);
         AV8AuxValor = 0;
         /* Optimized group. */
         /* Using cursor P00897 */
         pr_default.execute(3, new Object[] {AV11InicioTituloMovimentoDataCredito, AV10FimTituloMovimentoDataCredito});
         c271TituloMovimentoValor = P00897_A271TituloMovimentoValor[0];
         n271TituloMovimentoValor = P00897_n271TituloMovimentoValor[0];
         pr_default.close(3);
         AV8AuxValor = (decimal)(AV8AuxValor+c271TituloMovimentoValor);
         /* End optimized group. */
         AV13SdDashboardFinanceiroCardsItem = new SdtSdDashboardFinanceiroCards_Item(context);
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Valor = "R$"+context.localUtil.Format( AV8AuxValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Title = "Juros/Multa";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Visible = AV16Visible;
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Icon = "fa-solid fa-percent";
         AV13SdDashboardFinanceiroCardsItem.gxTpr_Class = "PanelCardIcon_Info";
         AV12SdDashboardFinanceiroCards.Add(AV13SdDashboardFinanceiroCardsItem, 0);
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
         AV12SdDashboardFinanceiroCards = new GXBaseCollection<SdtSdDashboardFinanceiroCards_Item>( context, "Item", "Factory21");
         AV11InicioTituloMovimentoDataCredito = DateTime.MinValue;
         AV10FimTituloMovimentoDataCredito = DateTime.MinValue;
         P00893_A287TituloCompetenciaMes = new short[1] ;
         P00893_n287TituloCompetenciaMes = new bool[] {false} ;
         P00893_A286TituloCompetenciaAno = new short[1] ;
         P00893_n286TituloCompetenciaAno = new bool[] {false} ;
         P00893_A283TituloTipo = new string[] {""} ;
         P00893_n283TituloTipo = new bool[] {false} ;
         P00893_A261TituloId = new int[1] ;
         P00893_n261TituloId = new bool[] {false} ;
         P00893_A273TituloTotalMovimento_F = new decimal[1] ;
         P00893_n273TituloTotalMovimento_F = new bool[] {false} ;
         P00893_A276TituloDesconto = new decimal[1] ;
         P00893_n276TituloDesconto = new bool[] {false} ;
         P00893_A262TituloValor = new decimal[1] ;
         P00893_n262TituloValor = new bool[] {false} ;
         A283TituloTipo = "";
         AV13SdDashboardFinanceiroCardsItem = new SdtSdDashboardFinanceiroCards_Item(context);
         P00895_A287TituloCompetenciaMes = new short[1] ;
         P00895_n287TituloCompetenciaMes = new bool[] {false} ;
         P00895_A286TituloCompetenciaAno = new short[1] ;
         P00895_n286TituloCompetenciaAno = new bool[] {false} ;
         P00895_A283TituloTipo = new string[] {""} ;
         P00895_n283TituloTipo = new bool[] {false} ;
         P00895_A261TituloId = new int[1] ;
         P00895_n261TituloId = new bool[] {false} ;
         P00895_A273TituloTotalMovimento_F = new decimal[1] ;
         P00895_n273TituloTotalMovimento_F = new bool[] {false} ;
         P00895_A276TituloDesconto = new decimal[1] ;
         P00895_n276TituloDesconto = new bool[] {false} ;
         P00895_A262TituloValor = new decimal[1] ;
         P00895_n262TituloValor = new bool[] {false} ;
         P00896_A271TituloMovimentoValor = new decimal[1] ;
         P00896_n271TituloMovimentoValor = new bool[] {false} ;
         P00897_A271TituloMovimentoValor = new decimal[1] ;
         P00897_n271TituloMovimentoValor = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcardsdashboardfinanceiro__default(),
            new Object[][] {
                new Object[] {
               P00893_A287TituloCompetenciaMes, P00893_n287TituloCompetenciaMes, P00893_A286TituloCompetenciaAno, P00893_n286TituloCompetenciaAno, P00893_A283TituloTipo, P00893_n283TituloTipo, P00893_A261TituloId, P00893_A273TituloTotalMovimento_F, P00893_n273TituloTotalMovimento_F, P00893_A276TituloDesconto,
               P00893_n276TituloDesconto, P00893_A262TituloValor, P00893_n262TituloValor
               }
               , new Object[] {
               P00895_A287TituloCompetenciaMes, P00895_n287TituloCompetenciaMes, P00895_A286TituloCompetenciaAno, P00895_n286TituloCompetenciaAno, P00895_A283TituloTipo, P00895_n283TituloTipo, P00895_A261TituloId, P00895_A273TituloTotalMovimento_F, P00895_n273TituloTotalMovimento_F, P00895_A276TituloDesconto,
               P00895_n276TituloDesconto, P00895_A262TituloValor, P00895_n262TituloValor
               }
               , new Object[] {
               P00896_A271TituloMovimentoValor, P00896_n271TituloMovimentoValor
               }
               , new Object[] {
               P00897_A271TituloMovimentoValor, P00897_n271TituloMovimentoValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14TituloCompetenciaAno ;
      private short AV15TituloCompetenciaMes ;
      private short A287TituloCompetenciaMes ;
      private short A286TituloCompetenciaAno ;
      private int AV9Competencia ;
      private int A261TituloId ;
      private decimal AV8AuxValor ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A276TituloDesconto ;
      private decimal A262TituloValor ;
      private decimal A275TituloSaldo_F ;
      private decimal c271TituloMovimentoValor ;
      private DateTime AV11InicioTituloMovimentoDataCredito ;
      private DateTime AV10FimTituloMovimentoDataCredito ;
      private bool AV16Visible ;
      private bool n287TituloCompetenciaMes ;
      private bool n286TituloCompetenciaAno ;
      private bool n283TituloTipo ;
      private bool n261TituloId ;
      private bool n273TituloTotalMovimento_F ;
      private bool n276TituloDesconto ;
      private bool n262TituloValor ;
      private bool n271TituloMovimentoValor ;
      private string A283TituloTipo ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> AV12SdDashboardFinanceiroCards ;
      private IDataStoreProvider pr_default ;
      private short[] P00893_A287TituloCompetenciaMes ;
      private bool[] P00893_n287TituloCompetenciaMes ;
      private short[] P00893_A286TituloCompetenciaAno ;
      private bool[] P00893_n286TituloCompetenciaAno ;
      private string[] P00893_A283TituloTipo ;
      private bool[] P00893_n283TituloTipo ;
      private int[] P00893_A261TituloId ;
      private bool[] P00893_n261TituloId ;
      private decimal[] P00893_A273TituloTotalMovimento_F ;
      private bool[] P00893_n273TituloTotalMovimento_F ;
      private decimal[] P00893_A276TituloDesconto ;
      private bool[] P00893_n276TituloDesconto ;
      private decimal[] P00893_A262TituloValor ;
      private bool[] P00893_n262TituloValor ;
      private SdtSdDashboardFinanceiroCards_Item AV13SdDashboardFinanceiroCardsItem ;
      private short[] P00895_A287TituloCompetenciaMes ;
      private bool[] P00895_n287TituloCompetenciaMes ;
      private short[] P00895_A286TituloCompetenciaAno ;
      private bool[] P00895_n286TituloCompetenciaAno ;
      private string[] P00895_A283TituloTipo ;
      private bool[] P00895_n283TituloTipo ;
      private int[] P00895_A261TituloId ;
      private bool[] P00895_n261TituloId ;
      private decimal[] P00895_A273TituloTotalMovimento_F ;
      private bool[] P00895_n273TituloTotalMovimento_F ;
      private decimal[] P00895_A276TituloDesconto ;
      private bool[] P00895_n276TituloDesconto ;
      private decimal[] P00895_A262TituloValor ;
      private bool[] P00895_n262TituloValor ;
      private decimal[] P00896_A271TituloMovimentoValor ;
      private bool[] P00896_n271TituloMovimentoValor ;
      private decimal[] P00897_A271TituloMovimentoValor ;
      private bool[] P00897_n271TituloMovimentoValor ;
      private GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> aP2_SdDashboardFinanceiroCards ;
   }

   public class prcardsdashboardfinanceiro__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00893;
          prmP00893 = new Object[] {
          new ParDef("AV14TituloCompetenciaAno",GXType.Int16,4,0) ,
          new ParDef("AV15TituloCompetenciaMes",GXType.Int16,4,0)
          };
          Object[] prmP00895;
          prmP00895 = new Object[] {
          new ParDef("AV14TituloCompetenciaAno",GXType.Int16,4,0) ,
          new ParDef("AV15TituloCompetenciaMes",GXType.Int16,4,0)
          };
          Object[] prmP00896;
          prmP00896 = new Object[] {
          new ParDef("AV11InicioTituloMovimentoDataCredito",GXType.Date,8,0) ,
          new ParDef("AV10FimTituloMovimentoDataCredito",GXType.Date,8,0)
          };
          Object[] prmP00897;
          prmP00897 = new Object[] {
          new ParDef("AV11InicioTituloMovimentoDataCredito",GXType.Date,8,0) ,
          new ParDef("AV10FimTituloMovimentoDataCredito",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00893", "SELECT T1.TituloCompetenciaMes, T1.TituloCompetenciaAno, T1.TituloTipo, T1.TituloId, COALESCE( T2.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor FROM (Titulo T1 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T2 ON T2.TituloId = T1.TituloId) WHERE (T1.TituloTipo = ( 'CREDITO')) AND (T1.TituloCompetenciaAno = :AV14TituloCompetenciaAno) AND (T1.TituloCompetenciaMes = :AV15TituloCompetenciaMes) ORDER BY T1.TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00893,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00895", "SELECT T1.TituloCompetenciaMes, T1.TituloCompetenciaAno, T1.TituloTipo, T1.TituloId, COALESCE( T2.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor FROM (Titulo T1 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T2 ON T2.TituloId = T1.TituloId) WHERE (T1.TituloTipo = ( 'DEBITO')) AND (T1.TituloCompetenciaAno = :AV14TituloCompetenciaAno) AND (T1.TituloCompetenciaMes = :AV15TituloCompetenciaMes) ORDER BY T1.TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00895,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00896", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (TituloMovimentoDataCredito >= :AV11InicioTituloMovimentoDataCredito) AND (TituloMovimentoDataCredito <= :AV10FimTituloMovimentoDataCredito) AND (TituloMovimentoSoma) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00896,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00897", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (TituloMovimentoDataCredito >= :AV11InicioTituloMovimentoDataCredito) AND (TituloMovimentoDataCredito <= :AV10FimTituloMovimentoDataCredito) AND (Not TituloMovimentoSoma) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00897,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
