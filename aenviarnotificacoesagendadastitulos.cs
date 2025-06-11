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
   public class aenviarnotificacoesagendadastitulos : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aenviarnotificacoesagendadastitulos().MainImpl(args); ;
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

      public aenviarnotificacoesagendadastitulos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aenviarnotificacoesagendadastitulos( IGxContext context )
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
         AV18NotificacaoAgendadaProcessamento = new SdtNotificacaoAgendadaProcessamento(context);
         AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoinicio = DateTimeUtil.ServerNow( context, pr_default);
         AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentosituacao = "P";
         AV19IdProcessamento = AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoid;
         AV18NotificacaoAgendadaProcessamento.Save();
         if ( ! AV18NotificacaoAgendadaProcessamento.Success() )
         {
            cleanup();
            if (true) return;
         }
         AV18NotificacaoAgendadaProcessamento.Load(AV19IdProcessamento);
         AV21NotificacaoAgendadaProcessamentoItemId = 1;
         AV25Agora = DateTimeUtil.ServerNow( context, pr_default);
         AV8DataAtual = DateTimeUtil.ResetTime( AV25Agora);
         /* Using cursor P00EH2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A905NotificacaoAgendadaStatus = P00EH2_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = P00EH2_n905NotificacaoAgendadaStatus[0];
            A903NotificacaoAgendadaTipo = P00EH2_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = P00EH2_n903NotificacaoAgendadaTipo[0];
            A899NotificacaoAgendadaOrigem = P00EH2_A899NotificacaoAgendadaOrigem[0];
            A904NotificacaoAgendadaLayoutId = P00EH2_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = P00EH2_n904NotificacaoAgendadaLayoutId[0];
            A898NotificacaoAgendadaId = P00EH2_A898NotificacaoAgendadaId[0];
            A901NotificacaoAgendadaDias = P00EH2_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = P00EH2_n901NotificacaoAgendadaDias[0];
            A902NotificacaoAgendadaMomentoEnvio = P00EH2_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = P00EH2_n902NotificacaoAgendadaMomentoEnvio[0];
            A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
            AV11NotificacaoAgendadaOffsetDias = A907NotificacaoAgendadaOffsetDias;
            AV12NotificacaoAgendadaLayoutId = A904NotificacaoAgendadaLayoutId;
            AV10NotificacaoAgendadaMomentoEnvio = A902NotificacaoAgendadaMomentoEnvio;
            /* Execute user subroutine: 'BUSCACONTEUDOEMAIL' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'BUSCATITULOSPARAENVIOEMAIL' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentofim = DateTimeUtil.ServerNow( context, pr_default);
         AV18NotificacaoAgendadaProcessamento.Save();
         context.CommitDataStores("enviarnotificacoesagendadastitulos",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'BUSCACONTEUDOEMAIL' Routine */
         returnInSub = false;
         /* Using cursor P00EH3 */
         pr_default.execute(1, new Object[] {AV12NotificacaoAgendadaLayoutId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A154LayoutContratoId = P00EH3_A154LayoutContratoId[0];
            A157LayoutContratoCorpo = P00EH3_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = P00EH3_n157LayoutContratoCorpo[0];
            AV13LayoutContratoCorpo = A157LayoutContratoCorpo;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'BUSCATITULOSPARAENVIOEMAIL' Routine */
         returnInSub = false;
         /* Using cursor P00EH7 */
         pr_default.execute(2, new Object[] {AV8DataAtual, AV11NotificacaoAgendadaOffsetDias});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00EH7_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00EH7_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00EH7_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EH7_n794NotaFiscalId[0];
            A264TituloProrrogacao = P00EH7_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00EH7_n264TituloProrrogacao[0];
            A168ClienteId = P00EH7_A168ClienteId[0];
            n168ClienteId = P00EH7_n168ClienteId[0];
            A456ResponsavelEmail = P00EH7_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00EH7_n456ResponsavelEmail[0];
            A172ClienteTipoPessoa = P00EH7_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P00EH7_n172ClienteTipoPessoa[0];
            A201ContatoEmail = P00EH7_A201ContatoEmail[0];
            n201ContatoEmail = P00EH7_n201ContatoEmail[0];
            A261TituloId = P00EH7_A261TituloId[0];
            n261TituloId = P00EH7_n261TituloId[0];
            A282TituloStatus_F = P00EH7_A282TituloStatus_F[0];
            n282TituloStatus_F = P00EH7_n282TituloStatus_F[0];
            A794NotaFiscalId = P00EH7_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EH7_n794NotaFiscalId[0];
            A168ClienteId = P00EH7_A168ClienteId[0];
            n168ClienteId = P00EH7_n168ClienteId[0];
            A456ResponsavelEmail = P00EH7_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00EH7_n456ResponsavelEmail[0];
            A172ClienteTipoPessoa = P00EH7_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P00EH7_n172ClienteTipoPessoa[0];
            A201ContatoEmail = P00EH7_A201ContatoEmail[0];
            n201ContatoEmail = P00EH7_n201ContatoEmail[0];
            A282TituloStatus_F = P00EH7_A282TituloStatus_F[0];
            n282TituloStatus_F = P00EH7_n282TituloStatus_F[0];
            AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas = (short)(AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas+1);
            AV20NotificacaoAgendadaProcessamentoItem = new SdtNotificacaoAgendadaProcessamentoItem(context);
            AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoid = AV19IdProcessamento;
            AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemid = AV21NotificacaoAgendadaProcessamentoItemId;
            AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemexecucao = DateTimeUtil.ServerNow( context, pr_default);
            AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemjson = StringUtil.Format( "{ \"ClienteId\":\"%1\", \"TituloId\":\"%2\"}", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0), StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0), "", "", "", "", "", "", "");
            AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemtipo = ((StringUtil.StrCmp(AV10NotificacaoAgendadaMomentoEnvio, "A")==0) ? "P" : "V");
            if ( ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) )
            {
               AV17Email = StringUtil.Trim( A456ResponsavelEmail);
            }
            else
            {
               AV17Email = StringUtil.Trim( A201ContatoEmail);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17Email)) )
            {
               AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemsituacao = "E";
               AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemretorno = "Notificação não enviada: nenhum e-mail está cadastrado para esta empresa.";
            }
            else
            {
               AV15Array_Email.Add(AV17Email, 0);
               new sendemail(context ).execute(  ((StringUtil.StrCmp(AV10NotificacaoAgendadaMomentoEnvio, "A")==0) ? "Lembrete: Vencimento de Compromissos Financeiros se Aproxima" : "Informação importante sobre pagamento"),  AV13LayoutContratoCorpo,  AV15Array_Email, out  AV16Message) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16Message)) )
               {
                  AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso = (short)(AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso+1);
                  AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemsituacao = "S";
                  AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemretorno = "Notificação enviada com sucesso.";
               }
               else
               {
                  AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas = (short)(AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas+1);
                  AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemsituacao = "E";
                  AV20NotificacaoAgendadaProcessamentoItem.gxTpr_Notificacaoagendadaprocessamentoitemretorno = StringUtil.Trim( AV16Message);
               }
            }
            AV20NotificacaoAgendadaProcessamentoItem.Save();
            if ( ! AV20NotificacaoAgendadaProcessamentoItem.Success() )
            {
               AV34GXV2 = 1;
               AV33GXV1 = AV20NotificacaoAgendadaProcessamentoItem.GetMessages();
               while ( AV34GXV2 <= AV33GXV1.Count )
               {
                  AV23Item = ((GeneXus.Utils.SdtMessages_Message)AV33GXV1.Item(AV34GXV2));
                  AV22ErrorMessage += StringUtil.Trim( AV23Item.gxTpr_Description) + StringUtil.NewLine( );
                  AV34GXV2 = (int)(AV34GXV2+1);
               }
               AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentomensagemerro = AV18NotificacaoAgendadaProcessamento.gxTpr_Notificacaoagendadaprocessamentomensagemerro+StringUtil.Format( "Ocorreu erro ao tentar salvar o processamento de envio referente ao titulo %1 do cliente %2: %3", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0), StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0), StringUtil.Trim( AV22ErrorMessage), "", "", "", "", "", "")+StringUtil.NewLine( );
            }
            else
            {
               AV21NotificacaoAgendadaProcessamentoItemId = (int)(AV21NotificacaoAgendadaProcessamentoItemId+1);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV18NotificacaoAgendadaProcessamento = new SdtNotificacaoAgendadaProcessamento(context);
         AV19IdProcessamento = Guid.Empty;
         AV25Agora = (DateTime)(DateTime.MinValue);
         AV8DataAtual = DateTime.MinValue;
         P00EH2_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         P00EH2_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         P00EH2_A903NotificacaoAgendadaTipo = new string[] {""} ;
         P00EH2_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         P00EH2_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         P00EH2_A904NotificacaoAgendadaLayoutId = new short[1] ;
         P00EH2_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         P00EH2_A898NotificacaoAgendadaId = new int[1] ;
         P00EH2_A901NotificacaoAgendadaDias = new int[1] ;
         P00EH2_n901NotificacaoAgendadaDias = new bool[] {false} ;
         P00EH2_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         P00EH2_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         A903NotificacaoAgendadaTipo = "";
         A899NotificacaoAgendadaOrigem = "";
         A902NotificacaoAgendadaMomentoEnvio = "";
         AV10NotificacaoAgendadaMomentoEnvio = "";
         P00EH3_A154LayoutContratoId = new short[1] ;
         P00EH3_A157LayoutContratoCorpo = new string[] {""} ;
         P00EH3_n157LayoutContratoCorpo = new bool[] {false} ;
         A157LayoutContratoCorpo = "";
         AV13LayoutContratoCorpo = "";
         P00EH7_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EH7_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00EH7_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EH7_n794NotaFiscalId = new bool[] {false} ;
         P00EH7_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00EH7_n264TituloProrrogacao = new bool[] {false} ;
         P00EH7_A168ClienteId = new int[1] ;
         P00EH7_n168ClienteId = new bool[] {false} ;
         P00EH7_A456ResponsavelEmail = new string[] {""} ;
         P00EH7_n456ResponsavelEmail = new bool[] {false} ;
         P00EH7_A172ClienteTipoPessoa = new string[] {""} ;
         P00EH7_n172ClienteTipoPessoa = new bool[] {false} ;
         P00EH7_A201ContatoEmail = new string[] {""} ;
         P00EH7_n201ContatoEmail = new bool[] {false} ;
         P00EH7_A261TituloId = new int[1] ;
         P00EH7_n261TituloId = new bool[] {false} ;
         P00EH7_A282TituloStatus_F = new string[] {""} ;
         P00EH7_n282TituloStatus_F = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         A264TituloProrrogacao = DateTime.MinValue;
         A456ResponsavelEmail = "";
         A172ClienteTipoPessoa = "";
         A201ContatoEmail = "";
         A282TituloStatus_F = "";
         AV20NotificacaoAgendadaProcessamentoItem = new SdtNotificacaoAgendadaProcessamentoItem(context);
         AV17Email = "";
         AV15Array_Email = new GxSimpleCollection<string>();
         AV16Message = "";
         AV33GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV23Item = new GeneXus.Utils.SdtMessages_Message(context);
         AV22ErrorMessage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aenviarnotificacoesagendadastitulos__default(),
            new Object[][] {
                new Object[] {
               P00EH2_A905NotificacaoAgendadaStatus, P00EH2_n905NotificacaoAgendadaStatus, P00EH2_A903NotificacaoAgendadaTipo, P00EH2_n903NotificacaoAgendadaTipo, P00EH2_A899NotificacaoAgendadaOrigem, P00EH2_A904NotificacaoAgendadaLayoutId, P00EH2_n904NotificacaoAgendadaLayoutId, P00EH2_A898NotificacaoAgendadaId, P00EH2_A901NotificacaoAgendadaDias, P00EH2_n901NotificacaoAgendadaDias,
               P00EH2_A902NotificacaoAgendadaMomentoEnvio, P00EH2_n902NotificacaoAgendadaMomentoEnvio
               }
               , new Object[] {
               P00EH3_A154LayoutContratoId, P00EH3_A157LayoutContratoCorpo, P00EH3_n157LayoutContratoCorpo
               }
               , new Object[] {
               P00EH7_A890NotaFiscalParcelamentoID, P00EH7_n890NotaFiscalParcelamentoID, P00EH7_A794NotaFiscalId, P00EH7_n794NotaFiscalId, P00EH7_A264TituloProrrogacao, P00EH7_n264TituloProrrogacao, P00EH7_A168ClienteId, P00EH7_n168ClienteId, P00EH7_A456ResponsavelEmail, P00EH7_n456ResponsavelEmail,
               P00EH7_A172ClienteTipoPessoa, P00EH7_n172ClienteTipoPessoa, P00EH7_A201ContatoEmail, P00EH7_n201ContatoEmail, P00EH7_A261TituloId, P00EH7_A282TituloStatus_F, P00EH7_n282TituloStatus_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A904NotificacaoAgendadaLayoutId ;
      private short AV12NotificacaoAgendadaLayoutId ;
      private short A154LayoutContratoId ;
      private int AV21NotificacaoAgendadaProcessamentoItemId ;
      private int A898NotificacaoAgendadaId ;
      private int A901NotificacaoAgendadaDias ;
      private int A907NotificacaoAgendadaOffsetDias ;
      private int AV11NotificacaoAgendadaOffsetDias ;
      private int A168ClienteId ;
      private int A261TituloId ;
      private int AV34GXV2 ;
      private DateTime AV25Agora ;
      private DateTime AV8DataAtual ;
      private DateTime A264TituloProrrogacao ;
      private bool A905NotificacaoAgendadaStatus ;
      private bool n905NotificacaoAgendadaStatus ;
      private bool n903NotificacaoAgendadaTipo ;
      private bool n904NotificacaoAgendadaLayoutId ;
      private bool n901NotificacaoAgendadaDias ;
      private bool n902NotificacaoAgendadaMomentoEnvio ;
      private bool returnInSub ;
      private bool n157LayoutContratoCorpo ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n264TituloProrrogacao ;
      private bool n168ClienteId ;
      private bool n456ResponsavelEmail ;
      private bool n172ClienteTipoPessoa ;
      private bool n201ContatoEmail ;
      private bool n261TituloId ;
      private bool n282TituloStatus_F ;
      private string A157LayoutContratoCorpo ;
      private string AV13LayoutContratoCorpo ;
      private string A903NotificacaoAgendadaTipo ;
      private string A899NotificacaoAgendadaOrigem ;
      private string A902NotificacaoAgendadaMomentoEnvio ;
      private string AV10NotificacaoAgendadaMomentoEnvio ;
      private string A456ResponsavelEmail ;
      private string A172ClienteTipoPessoa ;
      private string A201ContatoEmail ;
      private string A282TituloStatus_F ;
      private string AV17Email ;
      private string AV16Message ;
      private string AV22ErrorMessage ;
      private Guid AV19IdProcessamento ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxDataStore dsDefault ;
      private SdtNotificacaoAgendadaProcessamento AV18NotificacaoAgendadaProcessamento ;
      private IDataStoreProvider pr_default ;
      private bool[] P00EH2_A905NotificacaoAgendadaStatus ;
      private bool[] P00EH2_n905NotificacaoAgendadaStatus ;
      private string[] P00EH2_A903NotificacaoAgendadaTipo ;
      private bool[] P00EH2_n903NotificacaoAgendadaTipo ;
      private string[] P00EH2_A899NotificacaoAgendadaOrigem ;
      private short[] P00EH2_A904NotificacaoAgendadaLayoutId ;
      private bool[] P00EH2_n904NotificacaoAgendadaLayoutId ;
      private int[] P00EH2_A898NotificacaoAgendadaId ;
      private int[] P00EH2_A901NotificacaoAgendadaDias ;
      private bool[] P00EH2_n901NotificacaoAgendadaDias ;
      private string[] P00EH2_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] P00EH2_n902NotificacaoAgendadaMomentoEnvio ;
      private short[] P00EH3_A154LayoutContratoId ;
      private string[] P00EH3_A157LayoutContratoCorpo ;
      private bool[] P00EH3_n157LayoutContratoCorpo ;
      private Guid[] P00EH7_A890NotaFiscalParcelamentoID ;
      private bool[] P00EH7_n890NotaFiscalParcelamentoID ;
      private Guid[] P00EH7_A794NotaFiscalId ;
      private bool[] P00EH7_n794NotaFiscalId ;
      private DateTime[] P00EH7_A264TituloProrrogacao ;
      private bool[] P00EH7_n264TituloProrrogacao ;
      private int[] P00EH7_A168ClienteId ;
      private bool[] P00EH7_n168ClienteId ;
      private string[] P00EH7_A456ResponsavelEmail ;
      private bool[] P00EH7_n456ResponsavelEmail ;
      private string[] P00EH7_A172ClienteTipoPessoa ;
      private bool[] P00EH7_n172ClienteTipoPessoa ;
      private string[] P00EH7_A201ContatoEmail ;
      private bool[] P00EH7_n201ContatoEmail ;
      private int[] P00EH7_A261TituloId ;
      private bool[] P00EH7_n261TituloId ;
      private string[] P00EH7_A282TituloStatus_F ;
      private bool[] P00EH7_n282TituloStatus_F ;
      private SdtNotificacaoAgendadaProcessamentoItem AV20NotificacaoAgendadaProcessamentoItem ;
      private GxSimpleCollection<string> AV15Array_Email ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV33GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV23Item ;
   }

   public class aenviarnotificacoesagendadastitulos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EH2;
          prmP00EH2 = new Object[] {
          };
          Object[] prmP00EH3;
          prmP00EH3 = new Object[] {
          new ParDef("AV12NotificacaoAgendadaLayoutId",GXType.Int16,4,0)
          };
          Object[] prmP00EH7;
          prmP00EH7 = new Object[] {
          new ParDef("AV8DataAtual",GXType.Date,8,0) ,
          new ParDef("AV11NotificacaoAgendadaOffsetDias",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EH2", "SELECT NotificacaoAgendadaStatus, NotificacaoAgendadaTipo, NotificacaoAgendadaOrigem, NotificacaoAgendadaLayoutId, NotificacaoAgendadaId, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio FROM NotificacaoAgendada WHERE (NotificacaoAgendadaOrigem = ( 'R')) AND (NotificacaoAgendadaTipo = ( 'E')) AND (NotificacaoAgendadaStatus = TRUE) ORDER BY NotificacaoAgendadaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EH2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EH3", "SELECT LayoutContratoId, LayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :AV12NotificacaoAgendadaLayoutId ORDER BY LayoutContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EH3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EH7", "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloProrrogacao, T3.ClienteId, T4.ResponsavelEmail, T4.ClienteTipoPessoa, T4.ContatoEmail, T1.TituloId, COALESCE( T5.TituloStatus_F, '') AS TituloStatus_F FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN (SELECT CASE  WHEN (COALESCE( T7.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T7.TituloSaldo_F, 0) = COALESCE( T6.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T6.TituloId FROM (Titulo T6 INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T1.TituloId) WHERE (T1.TituloProrrogacao - :AV8DataAtual = :AV11NotificacaoAgendadaOffsetDias) AND (COALESCE( T5.TituloStatus_F, '') = ( 'Aberto')) ORDER BY T1.TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EH7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
