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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class assinaturaparticipante_bc : GxSilentTrn, IGxSilentTrn
   {
      public assinaturaparticipante_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaparticipante_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1241( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1241( ) ;
         standaloneModal( ) ;
         AddRow1241( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_120( )
      {
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1241( ) ;
            }
            else
            {
               CheckExtendedTable1241( ) ;
               if ( AnyError == 0 )
               {
                  ZM1241( 9) ;
                  ZM1241( 10) ;
                  ZM1241( 11) ;
               }
               CloseExtendedTableCursors1241( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1241( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z246AssinaturaParticipanteKey = A246AssinaturaParticipanteKey;
            Z353AssinaturaParticipanteStatus = A353AssinaturaParticipanteStatus;
            Z244AssinaturaParticipanteDataVisualizacao = A244AssinaturaParticipanteDataVisualizacao;
            Z245AssinaturaParticipanteDataConclusao = A245AssinaturaParticipanteDataConclusao;
            Z247AssinaturaParticipanteTipo = A247AssinaturaParticipanteTipo;
            Z346AssinaturaParticipanteRemoteAddres = A346AssinaturaParticipanteRemoteAddres;
            Z347AssinaturaParticipanteGeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
            Z348AssinaturaParticipanteDispositivo = A348AssinaturaParticipanteDispositivo;
            Z350AssinaturaParticipanteCPF = A350AssinaturaParticipanteCPF;
            Z351AssinaturaParticipanteEmail = A351AssinaturaParticipanteEmail;
            Z352AssinaturaParticipanteNascimento = A352AssinaturaParticipanteNascimento;
            Z354AssinaturaParticipanteLink = A354AssinaturaParticipanteLink;
            Z233ParticipanteId = A233ParticipanteId;
            Z168ClienteId = A168ClienteId;
            Z238AssinaturaId = A238AssinaturaId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z248ParticipanteNome = A248ParticipanteNome;
            Z235ParticipanteEmail = A235ParticipanteEmail;
            Z234ParticipanteDocumento = A234ParticipanteDocumento;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
            Z246AssinaturaParticipanteKey = A246AssinaturaParticipanteKey;
            Z353AssinaturaParticipanteStatus = A353AssinaturaParticipanteStatus;
            Z244AssinaturaParticipanteDataVisualizacao = A244AssinaturaParticipanteDataVisualizacao;
            Z245AssinaturaParticipanteDataConclusao = A245AssinaturaParticipanteDataConclusao;
            Z247AssinaturaParticipanteTipo = A247AssinaturaParticipanteTipo;
            Z346AssinaturaParticipanteRemoteAddres = A346AssinaturaParticipanteRemoteAddres;
            Z347AssinaturaParticipanteGeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
            Z348AssinaturaParticipanteDispositivo = A348AssinaturaParticipanteDispositivo;
            Z350AssinaturaParticipanteCPF = A350AssinaturaParticipanteCPF;
            Z351AssinaturaParticipanteEmail = A351AssinaturaParticipanteEmail;
            Z352AssinaturaParticipanteNascimento = A352AssinaturaParticipanteNascimento;
            Z354AssinaturaParticipanteLink = A354AssinaturaParticipanteLink;
            Z233ParticipanteId = A233ParticipanteId;
            Z168ClienteId = A168ClienteId;
            Z238AssinaturaId = A238AssinaturaId;
            Z248ParticipanteNome = A248ParticipanteNome;
            Z235ParticipanteEmail = A235ParticipanteEmail;
            Z234ParticipanteDocumento = A234ParticipanteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A246AssinaturaParticipanteKey) )
         {
            A246AssinaturaParticipanteKey = Guid.NewGuid( );
            n246AssinaturaParticipanteKey = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1241( )
      {
         /* Using cursor BC00127 */
         pr_default.execute(5, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound41 = 1;
            A246AssinaturaParticipanteKey = BC00127_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = BC00127_n246AssinaturaParticipanteKey[0];
            A248ParticipanteNome = BC00127_A248ParticipanteNome[0];
            n248ParticipanteNome = BC00127_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC00127_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC00127_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = BC00127_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC00127_n234ParticipanteDocumento[0];
            A353AssinaturaParticipanteStatus = BC00127_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = BC00127_n353AssinaturaParticipanteStatus[0];
            A244AssinaturaParticipanteDataVisualizacao = BC00127_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = BC00127_n244AssinaturaParticipanteDataVisualizacao[0];
            A245AssinaturaParticipanteDataConclusao = BC00127_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = BC00127_n245AssinaturaParticipanteDataConclusao[0];
            A247AssinaturaParticipanteTipo = BC00127_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = BC00127_n247AssinaturaParticipanteTipo[0];
            A346AssinaturaParticipanteRemoteAddres = BC00127_A346AssinaturaParticipanteRemoteAddres[0];
            n346AssinaturaParticipanteRemoteAddres = BC00127_n346AssinaturaParticipanteRemoteAddres[0];
            A347AssinaturaParticipanteGeolocalizacao = BC00127_A347AssinaturaParticipanteGeolocalizacao[0];
            n347AssinaturaParticipanteGeolocalizacao = BC00127_n347AssinaturaParticipanteGeolocalizacao[0];
            A348AssinaturaParticipanteDispositivo = BC00127_A348AssinaturaParticipanteDispositivo[0];
            n348AssinaturaParticipanteDispositivo = BC00127_n348AssinaturaParticipanteDispositivo[0];
            A350AssinaturaParticipanteCPF = BC00127_A350AssinaturaParticipanteCPF[0];
            n350AssinaturaParticipanteCPF = BC00127_n350AssinaturaParticipanteCPF[0];
            A351AssinaturaParticipanteEmail = BC00127_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = BC00127_n351AssinaturaParticipanteEmail[0];
            A352AssinaturaParticipanteNascimento = BC00127_A352AssinaturaParticipanteNascimento[0];
            n352AssinaturaParticipanteNascimento = BC00127_n352AssinaturaParticipanteNascimento[0];
            A354AssinaturaParticipanteLink = BC00127_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = BC00127_n354AssinaturaParticipanteLink[0];
            A233ParticipanteId = BC00127_A233ParticipanteId[0];
            n233ParticipanteId = BC00127_n233ParticipanteId[0];
            A168ClienteId = BC00127_A168ClienteId[0];
            n168ClienteId = BC00127_n168ClienteId[0];
            A238AssinaturaId = BC00127_A238AssinaturaId[0];
            n238AssinaturaId = BC00127_n238AssinaturaId[0];
            ZM1241( -8) ;
         }
         pr_default.close(5);
         OnLoadActions1241( ) ;
      }

      protected void OnLoadActions1241( )
      {
         if ( (0==A233ParticipanteId) )
         {
            A233ParticipanteId = 0;
            n233ParticipanteId = false;
            n233ParticipanteId = true;
            n233ParticipanteId = true;
         }
         if ( (0==A168ClienteId) )
         {
            A168ClienteId = 0;
            n168ClienteId = false;
            n168ClienteId = true;
            n168ClienteId = true;
         }
      }

      protected void CheckExtendedTable1241( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00126 */
         pr_default.execute(4, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A238AssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'Assinatura'.", "ForeignKeyNotFound", 1, "ASSINATURAID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         if ( (0==A233ParticipanteId) )
         {
            A233ParticipanteId = 0;
            n233ParticipanteId = false;
            n233ParticipanteId = true;
            n233ParticipanteId = true;
         }
         /* Using cursor BC00124 */
         pr_default.execute(2, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
            }
         }
         A248ParticipanteNome = BC00124_A248ParticipanteNome[0];
         n248ParticipanteNome = BC00124_n248ParticipanteNome[0];
         A235ParticipanteEmail = BC00124_A235ParticipanteEmail[0];
         n235ParticipanteEmail = BC00124_n235ParticipanteEmail[0];
         A234ParticipanteDocumento = BC00124_A234ParticipanteDocumento[0];
         n234ParticipanteDocumento = BC00124_n234ParticipanteDocumento[0];
         pr_default.close(2);
         if ( (0==A168ClienteId) )
         {
            A168ClienteId = 0;
            n168ClienteId = false;
            n168ClienteId = true;
            n168ClienteId = true;
         }
         /* Using cursor BC00125 */
         pr_default.execute(3, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 ) || ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Assinado") == 0 ) || ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Recusado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A353AssinaturaParticipanteStatus)) ) )
         {
            GX_msglist.addItem("Campo Assinatura Participante Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Contratado") == 0 ) || ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Contratante") == 0 ) || ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Testemunha") == 0 ) || ( StringUtil.StrCmp(A247AssinaturaParticipanteTipo, "Sacado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A247AssinaturaParticipanteTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo do participante fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A351AssinaturaParticipanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A351AssinaturaParticipanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Assinatura Participante Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1241( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1241( )
      {
         /* Using cursor BC00128 */
         pr_default.execute(6, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00123 */
         pr_default.execute(1, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1241( 8) ;
            RcdFound41 = 1;
            A242AssinaturaParticipanteId = BC00123_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC00123_n242AssinaturaParticipanteId[0];
            A246AssinaturaParticipanteKey = BC00123_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = BC00123_n246AssinaturaParticipanteKey[0];
            A353AssinaturaParticipanteStatus = BC00123_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = BC00123_n353AssinaturaParticipanteStatus[0];
            A244AssinaturaParticipanteDataVisualizacao = BC00123_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = BC00123_n244AssinaturaParticipanteDataVisualizacao[0];
            A245AssinaturaParticipanteDataConclusao = BC00123_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = BC00123_n245AssinaturaParticipanteDataConclusao[0];
            A247AssinaturaParticipanteTipo = BC00123_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = BC00123_n247AssinaturaParticipanteTipo[0];
            A346AssinaturaParticipanteRemoteAddres = BC00123_A346AssinaturaParticipanteRemoteAddres[0];
            n346AssinaturaParticipanteRemoteAddres = BC00123_n346AssinaturaParticipanteRemoteAddres[0];
            A347AssinaturaParticipanteGeolocalizacao = BC00123_A347AssinaturaParticipanteGeolocalizacao[0];
            n347AssinaturaParticipanteGeolocalizacao = BC00123_n347AssinaturaParticipanteGeolocalizacao[0];
            A348AssinaturaParticipanteDispositivo = BC00123_A348AssinaturaParticipanteDispositivo[0];
            n348AssinaturaParticipanteDispositivo = BC00123_n348AssinaturaParticipanteDispositivo[0];
            A350AssinaturaParticipanteCPF = BC00123_A350AssinaturaParticipanteCPF[0];
            n350AssinaturaParticipanteCPF = BC00123_n350AssinaturaParticipanteCPF[0];
            A351AssinaturaParticipanteEmail = BC00123_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = BC00123_n351AssinaturaParticipanteEmail[0];
            A352AssinaturaParticipanteNascimento = BC00123_A352AssinaturaParticipanteNascimento[0];
            n352AssinaturaParticipanteNascimento = BC00123_n352AssinaturaParticipanteNascimento[0];
            A354AssinaturaParticipanteLink = BC00123_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = BC00123_n354AssinaturaParticipanteLink[0];
            A233ParticipanteId = BC00123_A233ParticipanteId[0];
            n233ParticipanteId = BC00123_n233ParticipanteId[0];
            A168ClienteId = BC00123_A168ClienteId[0];
            n168ClienteId = BC00123_n168ClienteId[0];
            A238AssinaturaId = BC00123_A238AssinaturaId[0];
            n238AssinaturaId = BC00123_n238AssinaturaId[0];
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1241( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1241( ) ;
            }
            Gx_mode = sMode41;
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1241( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode41;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1241( ) ;
         if ( RcdFound41 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_120( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1241( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00122 */
            pr_default.execute(0, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z246AssinaturaParticipanteKey != BC00122_A246AssinaturaParticipanteKey[0] ) || ( StringUtil.StrCmp(Z353AssinaturaParticipanteStatus, BC00122_A353AssinaturaParticipanteStatus[0]) != 0 ) || ( Z244AssinaturaParticipanteDataVisualizacao != BC00122_A244AssinaturaParticipanteDataVisualizacao[0] ) || ( Z245AssinaturaParticipanteDataConclusao != BC00122_A245AssinaturaParticipanteDataConclusao[0] ) || ( StringUtil.StrCmp(Z247AssinaturaParticipanteTipo, BC00122_A247AssinaturaParticipanteTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z346AssinaturaParticipanteRemoteAddres, BC00122_A346AssinaturaParticipanteRemoteAddres[0]) != 0 ) || ( StringUtil.StrCmp(Z347AssinaturaParticipanteGeolocalizacao, BC00122_A347AssinaturaParticipanteGeolocalizacao[0]) != 0 ) || ( StringUtil.StrCmp(Z348AssinaturaParticipanteDispositivo, BC00122_A348AssinaturaParticipanteDispositivo[0]) != 0 ) || ( StringUtil.StrCmp(Z350AssinaturaParticipanteCPF, BC00122_A350AssinaturaParticipanteCPF[0]) != 0 ) || ( StringUtil.StrCmp(Z351AssinaturaParticipanteEmail, BC00122_A351AssinaturaParticipanteEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z352AssinaturaParticipanteNascimento ) != DateTimeUtil.ResetTime ( BC00122_A352AssinaturaParticipanteNascimento[0] ) ) || ( StringUtil.StrCmp(Z354AssinaturaParticipanteLink, BC00122_A354AssinaturaParticipanteLink[0]) != 0 ) || ( Z233ParticipanteId != BC00122_A233ParticipanteId[0] ) || ( Z168ClienteId != BC00122_A168ClienteId[0] ) || ( Z238AssinaturaId != BC00122_A238AssinaturaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AssinaturaParticipante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1241( )
      {
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1241( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1241( 0) ;
            CheckOptimisticConcurrency1241( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1241( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1241( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00129 */
                     pr_default.execute(7, new Object[] {n246AssinaturaParticipanteKey, A246AssinaturaParticipanteKey, n353AssinaturaParticipanteStatus, A353AssinaturaParticipanteStatus, n244AssinaturaParticipanteDataVisualizacao, A244AssinaturaParticipanteDataVisualizacao, n245AssinaturaParticipanteDataConclusao, A245AssinaturaParticipanteDataConclusao, n247AssinaturaParticipanteTipo, A247AssinaturaParticipanteTipo, n346AssinaturaParticipanteRemoteAddres, A346AssinaturaParticipanteRemoteAddres, n347AssinaturaParticipanteGeolocalizacao, A347AssinaturaParticipanteGeolocalizacao, n348AssinaturaParticipanteDispositivo, A348AssinaturaParticipanteDispositivo, n350AssinaturaParticipanteCPF, A350AssinaturaParticipanteCPF, n351AssinaturaParticipanteEmail, A351AssinaturaParticipanteEmail, n352AssinaturaParticipanteNascimento, A352AssinaturaParticipanteNascimento, n354AssinaturaParticipanteLink, A354AssinaturaParticipanteLink, n233ParticipanteId, A233ParticipanteId, n168ClienteId, A168ClienteId, n238AssinaturaId, A238AssinaturaId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001210 */
                     pr_default.execute(8);
                     A242AssinaturaParticipanteId = BC001210_A242AssinaturaParticipanteId[0];
                     n242AssinaturaParticipanteId = BC001210_n242AssinaturaParticipanteId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipante");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1241( ) ;
            }
            EndLevel1241( ) ;
         }
         CloseExtendedTableCursors1241( ) ;
      }

      protected void Update1241( )
      {
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1241( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1241( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1241( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1241( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001211 */
                     pr_default.execute(9, new Object[] {n246AssinaturaParticipanteKey, A246AssinaturaParticipanteKey, n353AssinaturaParticipanteStatus, A353AssinaturaParticipanteStatus, n244AssinaturaParticipanteDataVisualizacao, A244AssinaturaParticipanteDataVisualizacao, n245AssinaturaParticipanteDataConclusao, A245AssinaturaParticipanteDataConclusao, n247AssinaturaParticipanteTipo, A247AssinaturaParticipanteTipo, n346AssinaturaParticipanteRemoteAddres, A346AssinaturaParticipanteRemoteAddres, n347AssinaturaParticipanteGeolocalizacao, A347AssinaturaParticipanteGeolocalizacao, n348AssinaturaParticipanteDispositivo, A348AssinaturaParticipanteDispositivo, n350AssinaturaParticipanteCPF, A350AssinaturaParticipanteCPF, n351AssinaturaParticipanteEmail, A351AssinaturaParticipanteEmail, n352AssinaturaParticipanteNascimento, A352AssinaturaParticipanteNascimento, n354AssinaturaParticipanteLink, A354AssinaturaParticipanteLink, n233ParticipanteId, A233ParticipanteId, n168ClienteId, A168ClienteId, n238AssinaturaId, A238AssinaturaId, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipante");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1241( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1241( ) ;
         }
         CloseExtendedTableCursors1241( ) ;
      }

      protected void DeferredUpdate1241( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1241( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1241( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1241( ) ;
            AfterConfirm1241( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1241( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001212 */
                  pr_default.execute(10, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipante");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1241( ) ;
         Gx_mode = sMode41;
      }

      protected void OnDeleteControls1241( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001213 */
            pr_default.execute(11, new Object[] {n233ParticipanteId, A233ParticipanteId});
            A248ParticipanteNome = BC001213_A248ParticipanteNome[0];
            n248ParticipanteNome = BC001213_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC001213_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC001213_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = BC001213_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC001213_n234ParticipanteDocumento[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001214 */
            pr_default.execute(12, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipanteToken"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC001215 */
            pr_default.execute(13, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipanteNotificacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel1241( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1241( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1241( )
      {
         /* Using cursor BC001216 */
         pr_default.execute(14, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         RcdFound41 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound41 = 1;
            A242AssinaturaParticipanteId = BC001216_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC001216_n242AssinaturaParticipanteId[0];
            A246AssinaturaParticipanteKey = BC001216_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = BC001216_n246AssinaturaParticipanteKey[0];
            A248ParticipanteNome = BC001216_A248ParticipanteNome[0];
            n248ParticipanteNome = BC001216_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC001216_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC001216_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = BC001216_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC001216_n234ParticipanteDocumento[0];
            A353AssinaturaParticipanteStatus = BC001216_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = BC001216_n353AssinaturaParticipanteStatus[0];
            A244AssinaturaParticipanteDataVisualizacao = BC001216_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = BC001216_n244AssinaturaParticipanteDataVisualizacao[0];
            A245AssinaturaParticipanteDataConclusao = BC001216_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = BC001216_n245AssinaturaParticipanteDataConclusao[0];
            A247AssinaturaParticipanteTipo = BC001216_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = BC001216_n247AssinaturaParticipanteTipo[0];
            A346AssinaturaParticipanteRemoteAddres = BC001216_A346AssinaturaParticipanteRemoteAddres[0];
            n346AssinaturaParticipanteRemoteAddres = BC001216_n346AssinaturaParticipanteRemoteAddres[0];
            A347AssinaturaParticipanteGeolocalizacao = BC001216_A347AssinaturaParticipanteGeolocalizacao[0];
            n347AssinaturaParticipanteGeolocalizacao = BC001216_n347AssinaturaParticipanteGeolocalizacao[0];
            A348AssinaturaParticipanteDispositivo = BC001216_A348AssinaturaParticipanteDispositivo[0];
            n348AssinaturaParticipanteDispositivo = BC001216_n348AssinaturaParticipanteDispositivo[0];
            A350AssinaturaParticipanteCPF = BC001216_A350AssinaturaParticipanteCPF[0];
            n350AssinaturaParticipanteCPF = BC001216_n350AssinaturaParticipanteCPF[0];
            A351AssinaturaParticipanteEmail = BC001216_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = BC001216_n351AssinaturaParticipanteEmail[0];
            A352AssinaturaParticipanteNascimento = BC001216_A352AssinaturaParticipanteNascimento[0];
            n352AssinaturaParticipanteNascimento = BC001216_n352AssinaturaParticipanteNascimento[0];
            A354AssinaturaParticipanteLink = BC001216_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = BC001216_n354AssinaturaParticipanteLink[0];
            A233ParticipanteId = BC001216_A233ParticipanteId[0];
            n233ParticipanteId = BC001216_n233ParticipanteId[0];
            A168ClienteId = BC001216_A168ClienteId[0];
            n168ClienteId = BC001216_n168ClienteId[0];
            A238AssinaturaId = BC001216_A238AssinaturaId[0];
            n238AssinaturaId = BC001216_n238AssinaturaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1241( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound41 = 0;
         ScanKeyLoad1241( ) ;
      }

      protected void ScanKeyLoad1241( )
      {
         sMode41 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound41 = 1;
            A242AssinaturaParticipanteId = BC001216_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC001216_n242AssinaturaParticipanteId[0];
            A246AssinaturaParticipanteKey = BC001216_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = BC001216_n246AssinaturaParticipanteKey[0];
            A248ParticipanteNome = BC001216_A248ParticipanteNome[0];
            n248ParticipanteNome = BC001216_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC001216_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC001216_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = BC001216_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC001216_n234ParticipanteDocumento[0];
            A353AssinaturaParticipanteStatus = BC001216_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = BC001216_n353AssinaturaParticipanteStatus[0];
            A244AssinaturaParticipanteDataVisualizacao = BC001216_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = BC001216_n244AssinaturaParticipanteDataVisualizacao[0];
            A245AssinaturaParticipanteDataConclusao = BC001216_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = BC001216_n245AssinaturaParticipanteDataConclusao[0];
            A247AssinaturaParticipanteTipo = BC001216_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = BC001216_n247AssinaturaParticipanteTipo[0];
            A346AssinaturaParticipanteRemoteAddres = BC001216_A346AssinaturaParticipanteRemoteAddres[0];
            n346AssinaturaParticipanteRemoteAddres = BC001216_n346AssinaturaParticipanteRemoteAddres[0];
            A347AssinaturaParticipanteGeolocalizacao = BC001216_A347AssinaturaParticipanteGeolocalizacao[0];
            n347AssinaturaParticipanteGeolocalizacao = BC001216_n347AssinaturaParticipanteGeolocalizacao[0];
            A348AssinaturaParticipanteDispositivo = BC001216_A348AssinaturaParticipanteDispositivo[0];
            n348AssinaturaParticipanteDispositivo = BC001216_n348AssinaturaParticipanteDispositivo[0];
            A350AssinaturaParticipanteCPF = BC001216_A350AssinaturaParticipanteCPF[0];
            n350AssinaturaParticipanteCPF = BC001216_n350AssinaturaParticipanteCPF[0];
            A351AssinaturaParticipanteEmail = BC001216_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = BC001216_n351AssinaturaParticipanteEmail[0];
            A352AssinaturaParticipanteNascimento = BC001216_A352AssinaturaParticipanteNascimento[0];
            n352AssinaturaParticipanteNascimento = BC001216_n352AssinaturaParticipanteNascimento[0];
            A354AssinaturaParticipanteLink = BC001216_A354AssinaturaParticipanteLink[0];
            n354AssinaturaParticipanteLink = BC001216_n354AssinaturaParticipanteLink[0];
            A233ParticipanteId = BC001216_A233ParticipanteId[0];
            n233ParticipanteId = BC001216_n233ParticipanteId[0];
            A168ClienteId = BC001216_A168ClienteId[0];
            n168ClienteId = BC001216_n168ClienteId[0];
            A238AssinaturaId = BC001216_A238AssinaturaId[0];
            n238AssinaturaId = BC001216_n238AssinaturaId[0];
         }
         Gx_mode = sMode41;
      }

      protected void ScanKeyEnd1241( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1241( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1241( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1241( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1241( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1241( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1241( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1241( )
      {
      }

      protected void send_integrity_lvl_hashes1241( )
      {
      }

      protected void AddRow1241( )
      {
         VarsToRow41( bcAssinaturaParticipante) ;
      }

      protected void ReadRow1241( )
      {
         RowToVars41( bcAssinaturaParticipante, 1) ;
      }

      protected void InitializeNonKey1241( )
      {
         A238AssinaturaId = 0;
         n238AssinaturaId = false;
         A233ParticipanteId = 0;
         n233ParticipanteId = false;
         A168ClienteId = 0;
         n168ClienteId = false;
         A248ParticipanteNome = "";
         n248ParticipanteNome = false;
         A235ParticipanteEmail = "";
         n235ParticipanteEmail = false;
         A234ParticipanteDocumento = "";
         n234ParticipanteDocumento = false;
         A353AssinaturaParticipanteStatus = "";
         n353AssinaturaParticipanteStatus = false;
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         n244AssinaturaParticipanteDataVisualizacao = false;
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         n245AssinaturaParticipanteDataConclusao = false;
         A247AssinaturaParticipanteTipo = "";
         n247AssinaturaParticipanteTipo = false;
         A346AssinaturaParticipanteRemoteAddres = "";
         n346AssinaturaParticipanteRemoteAddres = false;
         A347AssinaturaParticipanteGeolocalizacao = "";
         n347AssinaturaParticipanteGeolocalizacao = false;
         A348AssinaturaParticipanteDispositivo = "";
         n348AssinaturaParticipanteDispositivo = false;
         A350AssinaturaParticipanteCPF = "";
         n350AssinaturaParticipanteCPF = false;
         A351AssinaturaParticipanteEmail = "";
         n351AssinaturaParticipanteEmail = false;
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         n352AssinaturaParticipanteNascimento = false;
         A354AssinaturaParticipanteLink = "";
         n354AssinaturaParticipanteLink = false;
         A246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         Z246AssinaturaParticipanteKey = Guid.Empty;
         Z353AssinaturaParticipanteStatus = "";
         Z244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         Z245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         Z247AssinaturaParticipanteTipo = "";
         Z346AssinaturaParticipanteRemoteAddres = "";
         Z347AssinaturaParticipanteGeolocalizacao = "";
         Z348AssinaturaParticipanteDispositivo = "";
         Z350AssinaturaParticipanteCPF = "";
         Z351AssinaturaParticipanteEmail = "";
         Z352AssinaturaParticipanteNascimento = DateTime.MinValue;
         Z354AssinaturaParticipanteLink = "";
         Z233ParticipanteId = 0;
         Z168ClienteId = 0;
         Z238AssinaturaId = 0;
      }

      protected void InitAll1241( )
      {
         A242AssinaturaParticipanteId = 0;
         n242AssinaturaParticipanteId = false;
         InitializeNonKey1241( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A246AssinaturaParticipanteKey = i246AssinaturaParticipanteKey;
         n246AssinaturaParticipanteKey = false;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow41( SdtAssinaturaParticipante obj41 )
      {
         obj41.gxTpr_Mode = Gx_mode;
         obj41.gxTpr_Assinaturaid = A238AssinaturaId;
         obj41.gxTpr_Participanteid = A233ParticipanteId;
         obj41.gxTpr_Clienteid = A168ClienteId;
         obj41.gxTpr_Participantenome = A248ParticipanteNome;
         obj41.gxTpr_Participanteemail = A235ParticipanteEmail;
         obj41.gxTpr_Participantedocumento = A234ParticipanteDocumento;
         obj41.gxTpr_Assinaturaparticipantestatus = A353AssinaturaParticipanteStatus;
         obj41.gxTpr_Assinaturaparticipantedatavisualizacao = A244AssinaturaParticipanteDataVisualizacao;
         obj41.gxTpr_Assinaturaparticipantedataconclusao = A245AssinaturaParticipanteDataConclusao;
         obj41.gxTpr_Assinaturaparticipantetipo = A247AssinaturaParticipanteTipo;
         obj41.gxTpr_Assinaturaparticipanteremoteaddres = A346AssinaturaParticipanteRemoteAddres;
         obj41.gxTpr_Assinaturaparticipantegeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
         obj41.gxTpr_Assinaturaparticipantedispositivo = A348AssinaturaParticipanteDispositivo;
         obj41.gxTpr_Assinaturaparticipantecpf = A350AssinaturaParticipanteCPF;
         obj41.gxTpr_Assinaturaparticipanteemail = A351AssinaturaParticipanteEmail;
         obj41.gxTpr_Assinaturaparticipantenascimento = A352AssinaturaParticipanteNascimento;
         obj41.gxTpr_Assinaturaparticipantelink = A354AssinaturaParticipanteLink;
         obj41.gxTpr_Assinaturaparticipantekey = A246AssinaturaParticipanteKey;
         obj41.gxTpr_Assinaturaparticipanteid = A242AssinaturaParticipanteId;
         obj41.gxTpr_Assinaturaparticipanteid_Z = Z242AssinaturaParticipanteId;
         obj41.gxTpr_Assinaturaid_Z = Z238AssinaturaId;
         obj41.gxTpr_Participanteid_Z = Z233ParticipanteId;
         obj41.gxTpr_Clienteid_Z = Z168ClienteId;
         obj41.gxTpr_Participantenome_Z = Z248ParticipanteNome;
         obj41.gxTpr_Participanteemail_Z = Z235ParticipanteEmail;
         obj41.gxTpr_Participantedocumento_Z = Z234ParticipanteDocumento;
         obj41.gxTpr_Assinaturaparticipantestatus_Z = Z353AssinaturaParticipanteStatus;
         obj41.gxTpr_Assinaturaparticipantedatavisualizacao_Z = Z244AssinaturaParticipanteDataVisualizacao;
         obj41.gxTpr_Assinaturaparticipantedataconclusao_Z = Z245AssinaturaParticipanteDataConclusao;
         obj41.gxTpr_Assinaturaparticipantekey_Z = Z246AssinaturaParticipanteKey;
         obj41.gxTpr_Assinaturaparticipantetipo_Z = Z247AssinaturaParticipanteTipo;
         obj41.gxTpr_Assinaturaparticipanteremoteaddres_Z = Z346AssinaturaParticipanteRemoteAddres;
         obj41.gxTpr_Assinaturaparticipantegeolocalizacao_Z = Z347AssinaturaParticipanteGeolocalizacao;
         obj41.gxTpr_Assinaturaparticipantedispositivo_Z = Z348AssinaturaParticipanteDispositivo;
         obj41.gxTpr_Assinaturaparticipantecpf_Z = Z350AssinaturaParticipanteCPF;
         obj41.gxTpr_Assinaturaparticipanteemail_Z = Z351AssinaturaParticipanteEmail;
         obj41.gxTpr_Assinaturaparticipantenascimento_Z = Z352AssinaturaParticipanteNascimento;
         obj41.gxTpr_Assinaturaparticipantelink_Z = Z354AssinaturaParticipanteLink;
         obj41.gxTpr_Assinaturaparticipanteid_N = (short)(Convert.ToInt16(n242AssinaturaParticipanteId));
         obj41.gxTpr_Assinaturaid_N = (short)(Convert.ToInt16(n238AssinaturaId));
         obj41.gxTpr_Participanteid_N = (short)(Convert.ToInt16(n233ParticipanteId));
         obj41.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj41.gxTpr_Participantenome_N = (short)(Convert.ToInt16(n248ParticipanteNome));
         obj41.gxTpr_Participanteemail_N = (short)(Convert.ToInt16(n235ParticipanteEmail));
         obj41.gxTpr_Participantedocumento_N = (short)(Convert.ToInt16(n234ParticipanteDocumento));
         obj41.gxTpr_Assinaturaparticipantestatus_N = (short)(Convert.ToInt16(n353AssinaturaParticipanteStatus));
         obj41.gxTpr_Assinaturaparticipantedatavisualizacao_N = (short)(Convert.ToInt16(n244AssinaturaParticipanteDataVisualizacao));
         obj41.gxTpr_Assinaturaparticipantedataconclusao_N = (short)(Convert.ToInt16(n245AssinaturaParticipanteDataConclusao));
         obj41.gxTpr_Assinaturaparticipantekey_N = (short)(Convert.ToInt16(n246AssinaturaParticipanteKey));
         obj41.gxTpr_Assinaturaparticipantetipo_N = (short)(Convert.ToInt16(n247AssinaturaParticipanteTipo));
         obj41.gxTpr_Assinaturaparticipanteremoteaddres_N = (short)(Convert.ToInt16(n346AssinaturaParticipanteRemoteAddres));
         obj41.gxTpr_Assinaturaparticipantegeolocalizacao_N = (short)(Convert.ToInt16(n347AssinaturaParticipanteGeolocalizacao));
         obj41.gxTpr_Assinaturaparticipantedispositivo_N = (short)(Convert.ToInt16(n348AssinaturaParticipanteDispositivo));
         obj41.gxTpr_Assinaturaparticipantecpf_N = (short)(Convert.ToInt16(n350AssinaturaParticipanteCPF));
         obj41.gxTpr_Assinaturaparticipanteemail_N = (short)(Convert.ToInt16(n351AssinaturaParticipanteEmail));
         obj41.gxTpr_Assinaturaparticipantenascimento_N = (short)(Convert.ToInt16(n352AssinaturaParticipanteNascimento));
         obj41.gxTpr_Assinaturaparticipantelink_N = (short)(Convert.ToInt16(n354AssinaturaParticipanteLink));
         obj41.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow41( SdtAssinaturaParticipante obj41 )
      {
         obj41.gxTpr_Assinaturaparticipanteid = A242AssinaturaParticipanteId;
         return  ;
      }

      public void RowToVars41( SdtAssinaturaParticipante obj41 ,
                               int forceLoad )
      {
         Gx_mode = obj41.gxTpr_Mode;
         A238AssinaturaId = obj41.gxTpr_Assinaturaid;
         n238AssinaturaId = false;
         A233ParticipanteId = obj41.gxTpr_Participanteid;
         n233ParticipanteId = false;
         A168ClienteId = obj41.gxTpr_Clienteid;
         n168ClienteId = false;
         A248ParticipanteNome = obj41.gxTpr_Participantenome;
         n248ParticipanteNome = false;
         A235ParticipanteEmail = obj41.gxTpr_Participanteemail;
         n235ParticipanteEmail = false;
         A234ParticipanteDocumento = obj41.gxTpr_Participantedocumento;
         n234ParticipanteDocumento = false;
         A353AssinaturaParticipanteStatus = obj41.gxTpr_Assinaturaparticipantestatus;
         n353AssinaturaParticipanteStatus = false;
         A244AssinaturaParticipanteDataVisualizacao = obj41.gxTpr_Assinaturaparticipantedatavisualizacao;
         n244AssinaturaParticipanteDataVisualizacao = false;
         A245AssinaturaParticipanteDataConclusao = obj41.gxTpr_Assinaturaparticipantedataconclusao;
         n245AssinaturaParticipanteDataConclusao = false;
         A247AssinaturaParticipanteTipo = obj41.gxTpr_Assinaturaparticipantetipo;
         n247AssinaturaParticipanteTipo = false;
         A346AssinaturaParticipanteRemoteAddres = obj41.gxTpr_Assinaturaparticipanteremoteaddres;
         n346AssinaturaParticipanteRemoteAddres = false;
         A347AssinaturaParticipanteGeolocalizacao = obj41.gxTpr_Assinaturaparticipantegeolocalizacao;
         n347AssinaturaParticipanteGeolocalizacao = false;
         A348AssinaturaParticipanteDispositivo = obj41.gxTpr_Assinaturaparticipantedispositivo;
         n348AssinaturaParticipanteDispositivo = false;
         A350AssinaturaParticipanteCPF = obj41.gxTpr_Assinaturaparticipantecpf;
         n350AssinaturaParticipanteCPF = false;
         A351AssinaturaParticipanteEmail = obj41.gxTpr_Assinaturaparticipanteemail;
         n351AssinaturaParticipanteEmail = false;
         A352AssinaturaParticipanteNascimento = obj41.gxTpr_Assinaturaparticipantenascimento;
         n352AssinaturaParticipanteNascimento = false;
         A354AssinaturaParticipanteLink = obj41.gxTpr_Assinaturaparticipantelink;
         n354AssinaturaParticipanteLink = false;
         A246AssinaturaParticipanteKey = obj41.gxTpr_Assinaturaparticipantekey;
         n246AssinaturaParticipanteKey = false;
         A242AssinaturaParticipanteId = obj41.gxTpr_Assinaturaparticipanteid;
         n242AssinaturaParticipanteId = false;
         Z242AssinaturaParticipanteId = obj41.gxTpr_Assinaturaparticipanteid_Z;
         Z238AssinaturaId = obj41.gxTpr_Assinaturaid_Z;
         Z233ParticipanteId = obj41.gxTpr_Participanteid_Z;
         Z168ClienteId = obj41.gxTpr_Clienteid_Z;
         Z248ParticipanteNome = obj41.gxTpr_Participantenome_Z;
         Z235ParticipanteEmail = obj41.gxTpr_Participanteemail_Z;
         Z234ParticipanteDocumento = obj41.gxTpr_Participantedocumento_Z;
         Z353AssinaturaParticipanteStatus = obj41.gxTpr_Assinaturaparticipantestatus_Z;
         Z244AssinaturaParticipanteDataVisualizacao = obj41.gxTpr_Assinaturaparticipantedatavisualizacao_Z;
         Z245AssinaturaParticipanteDataConclusao = obj41.gxTpr_Assinaturaparticipantedataconclusao_Z;
         Z246AssinaturaParticipanteKey = obj41.gxTpr_Assinaturaparticipantekey_Z;
         Z247AssinaturaParticipanteTipo = obj41.gxTpr_Assinaturaparticipantetipo_Z;
         Z346AssinaturaParticipanteRemoteAddres = obj41.gxTpr_Assinaturaparticipanteremoteaddres_Z;
         Z347AssinaturaParticipanteGeolocalizacao = obj41.gxTpr_Assinaturaparticipantegeolocalizacao_Z;
         Z348AssinaturaParticipanteDispositivo = obj41.gxTpr_Assinaturaparticipantedispositivo_Z;
         Z350AssinaturaParticipanteCPF = obj41.gxTpr_Assinaturaparticipantecpf_Z;
         Z351AssinaturaParticipanteEmail = obj41.gxTpr_Assinaturaparticipanteemail_Z;
         Z352AssinaturaParticipanteNascimento = obj41.gxTpr_Assinaturaparticipantenascimento_Z;
         Z354AssinaturaParticipanteLink = obj41.gxTpr_Assinaturaparticipantelink_Z;
         n242AssinaturaParticipanteId = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipanteid_N));
         n238AssinaturaId = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaid_N));
         n233ParticipanteId = (bool)(Convert.ToBoolean(obj41.gxTpr_Participanteid_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj41.gxTpr_Clienteid_N));
         n248ParticipanteNome = (bool)(Convert.ToBoolean(obj41.gxTpr_Participantenome_N));
         n235ParticipanteEmail = (bool)(Convert.ToBoolean(obj41.gxTpr_Participanteemail_N));
         n234ParticipanteDocumento = (bool)(Convert.ToBoolean(obj41.gxTpr_Participantedocumento_N));
         n353AssinaturaParticipanteStatus = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantestatus_N));
         n244AssinaturaParticipanteDataVisualizacao = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantedatavisualizacao_N));
         n245AssinaturaParticipanteDataConclusao = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantedataconclusao_N));
         n246AssinaturaParticipanteKey = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantekey_N));
         n247AssinaturaParticipanteTipo = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantetipo_N));
         n346AssinaturaParticipanteRemoteAddres = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipanteremoteaddres_N));
         n347AssinaturaParticipanteGeolocalizacao = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantegeolocalizacao_N));
         n348AssinaturaParticipanteDispositivo = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantedispositivo_N));
         n350AssinaturaParticipanteCPF = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantecpf_N));
         n351AssinaturaParticipanteEmail = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipanteemail_N));
         n352AssinaturaParticipanteNascimento = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantenascimento_N));
         n354AssinaturaParticipanteLink = (bool)(Convert.ToBoolean(obj41.gxTpr_Assinaturaparticipantelink_N));
         Gx_mode = obj41.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A242AssinaturaParticipanteId = (int)getParm(obj,0);
         n242AssinaturaParticipanteId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1241( ) ;
         ScanKeyStart1241( ) ;
         if ( RcdFound41 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
         ZM1241( -8) ;
         OnLoadActions1241( ) ;
         AddRow1241( ) ;
         ScanKeyEnd1241( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars41( bcAssinaturaParticipante, 0) ;
         ScanKeyStart1241( ) ;
         if ( RcdFound41 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
         ZM1241( -8) ;
         OnLoadActions1241( ) ;
         AddRow1241( ) ;
         ScanKeyEnd1241( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1241( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1241( ) ;
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
               {
                  A242AssinaturaParticipanteId = Z242AssinaturaParticipanteId;
                  n242AssinaturaParticipanteId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1241( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1241( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1241( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars41( bcAssinaturaParticipante, 1) ;
         SaveImpl( ) ;
         VarsToRow41( bcAssinaturaParticipante) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars41( bcAssinaturaParticipante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1241( ) ;
         AfterTrn( ) ;
         VarsToRow41( bcAssinaturaParticipante) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow41( bcAssinaturaParticipante) ;
         }
         else
         {
            SdtAssinaturaParticipante auxBC = new SdtAssinaturaParticipante(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A242AssinaturaParticipanteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAssinaturaParticipante);
               auxBC.Save();
               bcAssinaturaParticipante.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars41( bcAssinaturaParticipante, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars41( bcAssinaturaParticipante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1241( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow41( bcAssinaturaParticipante) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow41( bcAssinaturaParticipante) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars41( bcAssinaturaParticipante, 0) ;
         GetKey1241( ) ;
         if ( RcdFound41 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
            {
               A242AssinaturaParticipanteId = Z242AssinaturaParticipanteId;
               n242AssinaturaParticipanteId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A242AssinaturaParticipanteId != Z242AssinaturaParticipanteId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("assinaturaparticipante_bc",pr_default);
         VarsToRow41( bcAssinaturaParticipante) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcAssinaturaParticipante.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAssinaturaParticipante.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAssinaturaParticipante )
         {
            bcAssinaturaParticipante = (SdtAssinaturaParticipante)(sdt);
            if ( StringUtil.StrCmp(bcAssinaturaParticipante.gxTpr_Mode, "") == 0 )
            {
               bcAssinaturaParticipante.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow41( bcAssinaturaParticipante) ;
            }
            else
            {
               RowToVars41( bcAssinaturaParticipante, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAssinaturaParticipante.gxTpr_Mode, "") == 0 )
            {
               bcAssinaturaParticipante.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars41( bcAssinaturaParticipante, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAssinaturaParticipante AssinaturaParticipante_BC
      {
         get {
            return bcAssinaturaParticipante ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z246AssinaturaParticipanteKey = Guid.Empty;
         A246AssinaturaParticipanteKey = Guid.Empty;
         Z353AssinaturaParticipanteStatus = "";
         A353AssinaturaParticipanteStatus = "";
         Z244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         Z245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         Z247AssinaturaParticipanteTipo = "";
         A247AssinaturaParticipanteTipo = "";
         Z346AssinaturaParticipanteRemoteAddres = "";
         A346AssinaturaParticipanteRemoteAddres = "";
         Z347AssinaturaParticipanteGeolocalizacao = "";
         A347AssinaturaParticipanteGeolocalizacao = "";
         Z348AssinaturaParticipanteDispositivo = "";
         A348AssinaturaParticipanteDispositivo = "";
         Z350AssinaturaParticipanteCPF = "";
         A350AssinaturaParticipanteCPF = "";
         Z351AssinaturaParticipanteEmail = "";
         A351AssinaturaParticipanteEmail = "";
         Z352AssinaturaParticipanteNascimento = DateTime.MinValue;
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         Z354AssinaturaParticipanteLink = "";
         A354AssinaturaParticipanteLink = "";
         Z248ParticipanteNome = "";
         A248ParticipanteNome = "";
         Z235ParticipanteEmail = "";
         A235ParticipanteEmail = "";
         Z234ParticipanteDocumento = "";
         A234ParticipanteDocumento = "";
         BC00127_A242AssinaturaParticipanteId = new int[1] ;
         BC00127_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00127_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         BC00127_n246AssinaturaParticipanteKey = new bool[] {false} ;
         BC00127_A248ParticipanteNome = new string[] {""} ;
         BC00127_n248ParticipanteNome = new bool[] {false} ;
         BC00127_A235ParticipanteEmail = new string[] {""} ;
         BC00127_n235ParticipanteEmail = new bool[] {false} ;
         BC00127_A234ParticipanteDocumento = new string[] {""} ;
         BC00127_n234ParticipanteDocumento = new bool[] {false} ;
         BC00127_A353AssinaturaParticipanteStatus = new string[] {""} ;
         BC00127_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         BC00127_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         BC00127_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         BC00127_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         BC00127_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         BC00127_A247AssinaturaParticipanteTipo = new string[] {""} ;
         BC00127_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         BC00127_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         BC00127_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         BC00127_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         BC00127_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         BC00127_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         BC00127_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         BC00127_A350AssinaturaParticipanteCPF = new string[] {""} ;
         BC00127_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         BC00127_A351AssinaturaParticipanteEmail = new string[] {""} ;
         BC00127_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         BC00127_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         BC00127_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         BC00127_A354AssinaturaParticipanteLink = new string[] {""} ;
         BC00127_n354AssinaturaParticipanteLink = new bool[] {false} ;
         BC00127_A233ParticipanteId = new int[1] ;
         BC00127_n233ParticipanteId = new bool[] {false} ;
         BC00127_A168ClienteId = new int[1] ;
         BC00127_n168ClienteId = new bool[] {false} ;
         BC00127_A238AssinaturaId = new long[1] ;
         BC00127_n238AssinaturaId = new bool[] {false} ;
         BC00126_A238AssinaturaId = new long[1] ;
         BC00126_n238AssinaturaId = new bool[] {false} ;
         BC00124_A248ParticipanteNome = new string[] {""} ;
         BC00124_n248ParticipanteNome = new bool[] {false} ;
         BC00124_A235ParticipanteEmail = new string[] {""} ;
         BC00124_n235ParticipanteEmail = new bool[] {false} ;
         BC00124_A234ParticipanteDocumento = new string[] {""} ;
         BC00124_n234ParticipanteDocumento = new bool[] {false} ;
         BC00125_A168ClienteId = new int[1] ;
         BC00125_n168ClienteId = new bool[] {false} ;
         BC00128_A242AssinaturaParticipanteId = new int[1] ;
         BC00128_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00123_A242AssinaturaParticipanteId = new int[1] ;
         BC00123_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00123_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         BC00123_n246AssinaturaParticipanteKey = new bool[] {false} ;
         BC00123_A353AssinaturaParticipanteStatus = new string[] {""} ;
         BC00123_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         BC00123_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         BC00123_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         BC00123_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         BC00123_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         BC00123_A247AssinaturaParticipanteTipo = new string[] {""} ;
         BC00123_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         BC00123_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         BC00123_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         BC00123_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         BC00123_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         BC00123_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         BC00123_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         BC00123_A350AssinaturaParticipanteCPF = new string[] {""} ;
         BC00123_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         BC00123_A351AssinaturaParticipanteEmail = new string[] {""} ;
         BC00123_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         BC00123_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         BC00123_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         BC00123_A354AssinaturaParticipanteLink = new string[] {""} ;
         BC00123_n354AssinaturaParticipanteLink = new bool[] {false} ;
         BC00123_A233ParticipanteId = new int[1] ;
         BC00123_n233ParticipanteId = new bool[] {false} ;
         BC00123_A168ClienteId = new int[1] ;
         BC00123_n168ClienteId = new bool[] {false} ;
         BC00123_A238AssinaturaId = new long[1] ;
         BC00123_n238AssinaturaId = new bool[] {false} ;
         sMode41 = "";
         BC00122_A242AssinaturaParticipanteId = new int[1] ;
         BC00122_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00122_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         BC00122_n246AssinaturaParticipanteKey = new bool[] {false} ;
         BC00122_A353AssinaturaParticipanteStatus = new string[] {""} ;
         BC00122_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         BC00122_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         BC00122_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         BC00122_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         BC00122_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         BC00122_A247AssinaturaParticipanteTipo = new string[] {""} ;
         BC00122_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         BC00122_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         BC00122_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         BC00122_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         BC00122_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         BC00122_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         BC00122_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         BC00122_A350AssinaturaParticipanteCPF = new string[] {""} ;
         BC00122_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         BC00122_A351AssinaturaParticipanteEmail = new string[] {""} ;
         BC00122_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         BC00122_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         BC00122_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         BC00122_A354AssinaturaParticipanteLink = new string[] {""} ;
         BC00122_n354AssinaturaParticipanteLink = new bool[] {false} ;
         BC00122_A233ParticipanteId = new int[1] ;
         BC00122_n233ParticipanteId = new bool[] {false} ;
         BC00122_A168ClienteId = new int[1] ;
         BC00122_n168ClienteId = new bool[] {false} ;
         BC00122_A238AssinaturaId = new long[1] ;
         BC00122_n238AssinaturaId = new bool[] {false} ;
         BC001210_A242AssinaturaParticipanteId = new int[1] ;
         BC001210_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC001213_A248ParticipanteNome = new string[] {""} ;
         BC001213_n248ParticipanteNome = new bool[] {false} ;
         BC001213_A235ParticipanteEmail = new string[] {""} ;
         BC001213_n235ParticipanteEmail = new bool[] {false} ;
         BC001213_A234ParticipanteDocumento = new string[] {""} ;
         BC001213_n234ParticipanteDocumento = new bool[] {false} ;
         BC001214_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC001215_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC001216_A242AssinaturaParticipanteId = new int[1] ;
         BC001216_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC001216_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         BC001216_n246AssinaturaParticipanteKey = new bool[] {false} ;
         BC001216_A248ParticipanteNome = new string[] {""} ;
         BC001216_n248ParticipanteNome = new bool[] {false} ;
         BC001216_A235ParticipanteEmail = new string[] {""} ;
         BC001216_n235ParticipanteEmail = new bool[] {false} ;
         BC001216_A234ParticipanteDocumento = new string[] {""} ;
         BC001216_n234ParticipanteDocumento = new bool[] {false} ;
         BC001216_A353AssinaturaParticipanteStatus = new string[] {""} ;
         BC001216_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         BC001216_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001216_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         BC001216_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         BC001216_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         BC001216_A247AssinaturaParticipanteTipo = new string[] {""} ;
         BC001216_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         BC001216_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         BC001216_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         BC001216_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         BC001216_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         BC001216_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         BC001216_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         BC001216_A350AssinaturaParticipanteCPF = new string[] {""} ;
         BC001216_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         BC001216_A351AssinaturaParticipanteEmail = new string[] {""} ;
         BC001216_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         BC001216_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         BC001216_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         BC001216_A354AssinaturaParticipanteLink = new string[] {""} ;
         BC001216_n354AssinaturaParticipanteLink = new bool[] {false} ;
         BC001216_A233ParticipanteId = new int[1] ;
         BC001216_n233ParticipanteId = new bool[] {false} ;
         BC001216_A168ClienteId = new int[1] ;
         BC001216_n168ClienteId = new bool[] {false} ;
         BC001216_A238AssinaturaId = new long[1] ;
         BC001216_n238AssinaturaId = new bool[] {false} ;
         i246AssinaturaParticipanteKey = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaparticipante_bc__default(),
            new Object[][] {
                new Object[] {
               BC00122_A242AssinaturaParticipanteId, BC00122_A246AssinaturaParticipanteKey, BC00122_n246AssinaturaParticipanteKey, BC00122_A353AssinaturaParticipanteStatus, BC00122_n353AssinaturaParticipanteStatus, BC00122_A244AssinaturaParticipanteDataVisualizacao, BC00122_n244AssinaturaParticipanteDataVisualizacao, BC00122_A245AssinaturaParticipanteDataConclusao, BC00122_n245AssinaturaParticipanteDataConclusao, BC00122_A247AssinaturaParticipanteTipo,
               BC00122_n247AssinaturaParticipanteTipo, BC00122_A346AssinaturaParticipanteRemoteAddres, BC00122_n346AssinaturaParticipanteRemoteAddres, BC00122_A347AssinaturaParticipanteGeolocalizacao, BC00122_n347AssinaturaParticipanteGeolocalizacao, BC00122_A348AssinaturaParticipanteDispositivo, BC00122_n348AssinaturaParticipanteDispositivo, BC00122_A350AssinaturaParticipanteCPF, BC00122_n350AssinaturaParticipanteCPF, BC00122_A351AssinaturaParticipanteEmail,
               BC00122_n351AssinaturaParticipanteEmail, BC00122_A352AssinaturaParticipanteNascimento, BC00122_n352AssinaturaParticipanteNascimento, BC00122_A354AssinaturaParticipanteLink, BC00122_n354AssinaturaParticipanteLink, BC00122_A233ParticipanteId, BC00122_n233ParticipanteId, BC00122_A168ClienteId, BC00122_n168ClienteId, BC00122_A238AssinaturaId,
               BC00122_n238AssinaturaId
               }
               , new Object[] {
               BC00123_A242AssinaturaParticipanteId, BC00123_A246AssinaturaParticipanteKey, BC00123_n246AssinaturaParticipanteKey, BC00123_A353AssinaturaParticipanteStatus, BC00123_n353AssinaturaParticipanteStatus, BC00123_A244AssinaturaParticipanteDataVisualizacao, BC00123_n244AssinaturaParticipanteDataVisualizacao, BC00123_A245AssinaturaParticipanteDataConclusao, BC00123_n245AssinaturaParticipanteDataConclusao, BC00123_A247AssinaturaParticipanteTipo,
               BC00123_n247AssinaturaParticipanteTipo, BC00123_A346AssinaturaParticipanteRemoteAddres, BC00123_n346AssinaturaParticipanteRemoteAddres, BC00123_A347AssinaturaParticipanteGeolocalizacao, BC00123_n347AssinaturaParticipanteGeolocalizacao, BC00123_A348AssinaturaParticipanteDispositivo, BC00123_n348AssinaturaParticipanteDispositivo, BC00123_A350AssinaturaParticipanteCPF, BC00123_n350AssinaturaParticipanteCPF, BC00123_A351AssinaturaParticipanteEmail,
               BC00123_n351AssinaturaParticipanteEmail, BC00123_A352AssinaturaParticipanteNascimento, BC00123_n352AssinaturaParticipanteNascimento, BC00123_A354AssinaturaParticipanteLink, BC00123_n354AssinaturaParticipanteLink, BC00123_A233ParticipanteId, BC00123_n233ParticipanteId, BC00123_A168ClienteId, BC00123_n168ClienteId, BC00123_A238AssinaturaId,
               BC00123_n238AssinaturaId
               }
               , new Object[] {
               BC00124_A248ParticipanteNome, BC00124_n248ParticipanteNome, BC00124_A235ParticipanteEmail, BC00124_n235ParticipanteEmail, BC00124_A234ParticipanteDocumento, BC00124_n234ParticipanteDocumento
               }
               , new Object[] {
               BC00125_A168ClienteId
               }
               , new Object[] {
               BC00126_A238AssinaturaId
               }
               , new Object[] {
               BC00127_A242AssinaturaParticipanteId, BC00127_A246AssinaturaParticipanteKey, BC00127_n246AssinaturaParticipanteKey, BC00127_A248ParticipanteNome, BC00127_n248ParticipanteNome, BC00127_A235ParticipanteEmail, BC00127_n235ParticipanteEmail, BC00127_A234ParticipanteDocumento, BC00127_n234ParticipanteDocumento, BC00127_A353AssinaturaParticipanteStatus,
               BC00127_n353AssinaturaParticipanteStatus, BC00127_A244AssinaturaParticipanteDataVisualizacao, BC00127_n244AssinaturaParticipanteDataVisualizacao, BC00127_A245AssinaturaParticipanteDataConclusao, BC00127_n245AssinaturaParticipanteDataConclusao, BC00127_A247AssinaturaParticipanteTipo, BC00127_n247AssinaturaParticipanteTipo, BC00127_A346AssinaturaParticipanteRemoteAddres, BC00127_n346AssinaturaParticipanteRemoteAddres, BC00127_A347AssinaturaParticipanteGeolocalizacao,
               BC00127_n347AssinaturaParticipanteGeolocalizacao, BC00127_A348AssinaturaParticipanteDispositivo, BC00127_n348AssinaturaParticipanteDispositivo, BC00127_A350AssinaturaParticipanteCPF, BC00127_n350AssinaturaParticipanteCPF, BC00127_A351AssinaturaParticipanteEmail, BC00127_n351AssinaturaParticipanteEmail, BC00127_A352AssinaturaParticipanteNascimento, BC00127_n352AssinaturaParticipanteNascimento, BC00127_A354AssinaturaParticipanteLink,
               BC00127_n354AssinaturaParticipanteLink, BC00127_A233ParticipanteId, BC00127_n233ParticipanteId, BC00127_A168ClienteId, BC00127_n168ClienteId, BC00127_A238AssinaturaId, BC00127_n238AssinaturaId
               }
               , new Object[] {
               BC00128_A242AssinaturaParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001210_A242AssinaturaParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001213_A248ParticipanteNome, BC001213_n248ParticipanteNome, BC001213_A235ParticipanteEmail, BC001213_n235ParticipanteEmail, BC001213_A234ParticipanteDocumento, BC001213_n234ParticipanteDocumento
               }
               , new Object[] {
               BC001214_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               BC001215_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               BC001216_A242AssinaturaParticipanteId, BC001216_A246AssinaturaParticipanteKey, BC001216_n246AssinaturaParticipanteKey, BC001216_A248ParticipanteNome, BC001216_n248ParticipanteNome, BC001216_A235ParticipanteEmail, BC001216_n235ParticipanteEmail, BC001216_A234ParticipanteDocumento, BC001216_n234ParticipanteDocumento, BC001216_A353AssinaturaParticipanteStatus,
               BC001216_n353AssinaturaParticipanteStatus, BC001216_A244AssinaturaParticipanteDataVisualizacao, BC001216_n244AssinaturaParticipanteDataVisualizacao, BC001216_A245AssinaturaParticipanteDataConclusao, BC001216_n245AssinaturaParticipanteDataConclusao, BC001216_A247AssinaturaParticipanteTipo, BC001216_n247AssinaturaParticipanteTipo, BC001216_A346AssinaturaParticipanteRemoteAddres, BC001216_n346AssinaturaParticipanteRemoteAddres, BC001216_A347AssinaturaParticipanteGeolocalizacao,
               BC001216_n347AssinaturaParticipanteGeolocalizacao, BC001216_A348AssinaturaParticipanteDispositivo, BC001216_n348AssinaturaParticipanteDispositivo, BC001216_A350AssinaturaParticipanteCPF, BC001216_n350AssinaturaParticipanteCPF, BC001216_A351AssinaturaParticipanteEmail, BC001216_n351AssinaturaParticipanteEmail, BC001216_A352AssinaturaParticipanteNascimento, BC001216_n352AssinaturaParticipanteNascimento, BC001216_A354AssinaturaParticipanteLink,
               BC001216_n354AssinaturaParticipanteLink, BC001216_A233ParticipanteId, BC001216_n233ParticipanteId, BC001216_A168ClienteId, BC001216_n168ClienteId, BC001216_A238AssinaturaId, BC001216_n238AssinaturaId
               }
            }
         );
         Z246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         A246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         i246AssinaturaParticipanteKey = Guid.NewGuid( );
         n246AssinaturaParticipanteKey = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound41 ;
      private int trnEnded ;
      private int Z242AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int Z233ParticipanteId ;
      private int A233ParticipanteId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private long Z238AssinaturaId ;
      private long A238AssinaturaId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode41 ;
      private DateTime Z244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime Z245AssinaturaParticipanteDataConclusao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private DateTime Z352AssinaturaParticipanteNascimento ;
      private DateTime A352AssinaturaParticipanteNascimento ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n242AssinaturaParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool n346AssinaturaParticipanteRemoteAddres ;
      private bool n347AssinaturaParticipanteGeolocalizacao ;
      private bool n348AssinaturaParticipanteDispositivo ;
      private bool n350AssinaturaParticipanteCPF ;
      private bool n351AssinaturaParticipanteEmail ;
      private bool n352AssinaturaParticipanteNascimento ;
      private bool n354AssinaturaParticipanteLink ;
      private bool n233ParticipanteId ;
      private bool n168ClienteId ;
      private bool n238AssinaturaId ;
      private bool Gx_longc ;
      private string Z353AssinaturaParticipanteStatus ;
      private string A353AssinaturaParticipanteStatus ;
      private string Z247AssinaturaParticipanteTipo ;
      private string A247AssinaturaParticipanteTipo ;
      private string Z346AssinaturaParticipanteRemoteAddres ;
      private string A346AssinaturaParticipanteRemoteAddres ;
      private string Z347AssinaturaParticipanteGeolocalizacao ;
      private string A347AssinaturaParticipanteGeolocalizacao ;
      private string Z348AssinaturaParticipanteDispositivo ;
      private string A348AssinaturaParticipanteDispositivo ;
      private string Z350AssinaturaParticipanteCPF ;
      private string A350AssinaturaParticipanteCPF ;
      private string Z351AssinaturaParticipanteEmail ;
      private string A351AssinaturaParticipanteEmail ;
      private string Z354AssinaturaParticipanteLink ;
      private string A354AssinaturaParticipanteLink ;
      private string Z248ParticipanteNome ;
      private string A248ParticipanteNome ;
      private string Z235ParticipanteEmail ;
      private string A235ParticipanteEmail ;
      private string Z234ParticipanteDocumento ;
      private string A234ParticipanteDocumento ;
      private Guid Z246AssinaturaParticipanteKey ;
      private Guid A246AssinaturaParticipanteKey ;
      private Guid i246AssinaturaParticipanteKey ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00127_A242AssinaturaParticipanteId ;
      private bool[] BC00127_n242AssinaturaParticipanteId ;
      private Guid[] BC00127_A246AssinaturaParticipanteKey ;
      private bool[] BC00127_n246AssinaturaParticipanteKey ;
      private string[] BC00127_A248ParticipanteNome ;
      private bool[] BC00127_n248ParticipanteNome ;
      private string[] BC00127_A235ParticipanteEmail ;
      private bool[] BC00127_n235ParticipanteEmail ;
      private string[] BC00127_A234ParticipanteDocumento ;
      private bool[] BC00127_n234ParticipanteDocumento ;
      private string[] BC00127_A353AssinaturaParticipanteStatus ;
      private bool[] BC00127_n353AssinaturaParticipanteStatus ;
      private DateTime[] BC00127_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] BC00127_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] BC00127_A245AssinaturaParticipanteDataConclusao ;
      private bool[] BC00127_n245AssinaturaParticipanteDataConclusao ;
      private string[] BC00127_A247AssinaturaParticipanteTipo ;
      private bool[] BC00127_n247AssinaturaParticipanteTipo ;
      private string[] BC00127_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] BC00127_n346AssinaturaParticipanteRemoteAddres ;
      private string[] BC00127_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] BC00127_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] BC00127_A348AssinaturaParticipanteDispositivo ;
      private bool[] BC00127_n348AssinaturaParticipanteDispositivo ;
      private string[] BC00127_A350AssinaturaParticipanteCPF ;
      private bool[] BC00127_n350AssinaturaParticipanteCPF ;
      private string[] BC00127_A351AssinaturaParticipanteEmail ;
      private bool[] BC00127_n351AssinaturaParticipanteEmail ;
      private DateTime[] BC00127_A352AssinaturaParticipanteNascimento ;
      private bool[] BC00127_n352AssinaturaParticipanteNascimento ;
      private string[] BC00127_A354AssinaturaParticipanteLink ;
      private bool[] BC00127_n354AssinaturaParticipanteLink ;
      private int[] BC00127_A233ParticipanteId ;
      private bool[] BC00127_n233ParticipanteId ;
      private int[] BC00127_A168ClienteId ;
      private bool[] BC00127_n168ClienteId ;
      private long[] BC00127_A238AssinaturaId ;
      private bool[] BC00127_n238AssinaturaId ;
      private long[] BC00126_A238AssinaturaId ;
      private bool[] BC00126_n238AssinaturaId ;
      private string[] BC00124_A248ParticipanteNome ;
      private bool[] BC00124_n248ParticipanteNome ;
      private string[] BC00124_A235ParticipanteEmail ;
      private bool[] BC00124_n235ParticipanteEmail ;
      private string[] BC00124_A234ParticipanteDocumento ;
      private bool[] BC00124_n234ParticipanteDocumento ;
      private int[] BC00125_A168ClienteId ;
      private bool[] BC00125_n168ClienteId ;
      private int[] BC00128_A242AssinaturaParticipanteId ;
      private bool[] BC00128_n242AssinaturaParticipanteId ;
      private int[] BC00123_A242AssinaturaParticipanteId ;
      private bool[] BC00123_n242AssinaturaParticipanteId ;
      private Guid[] BC00123_A246AssinaturaParticipanteKey ;
      private bool[] BC00123_n246AssinaturaParticipanteKey ;
      private string[] BC00123_A353AssinaturaParticipanteStatus ;
      private bool[] BC00123_n353AssinaturaParticipanteStatus ;
      private DateTime[] BC00123_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] BC00123_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] BC00123_A245AssinaturaParticipanteDataConclusao ;
      private bool[] BC00123_n245AssinaturaParticipanteDataConclusao ;
      private string[] BC00123_A247AssinaturaParticipanteTipo ;
      private bool[] BC00123_n247AssinaturaParticipanteTipo ;
      private string[] BC00123_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] BC00123_n346AssinaturaParticipanteRemoteAddres ;
      private string[] BC00123_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] BC00123_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] BC00123_A348AssinaturaParticipanteDispositivo ;
      private bool[] BC00123_n348AssinaturaParticipanteDispositivo ;
      private string[] BC00123_A350AssinaturaParticipanteCPF ;
      private bool[] BC00123_n350AssinaturaParticipanteCPF ;
      private string[] BC00123_A351AssinaturaParticipanteEmail ;
      private bool[] BC00123_n351AssinaturaParticipanteEmail ;
      private DateTime[] BC00123_A352AssinaturaParticipanteNascimento ;
      private bool[] BC00123_n352AssinaturaParticipanteNascimento ;
      private string[] BC00123_A354AssinaturaParticipanteLink ;
      private bool[] BC00123_n354AssinaturaParticipanteLink ;
      private int[] BC00123_A233ParticipanteId ;
      private bool[] BC00123_n233ParticipanteId ;
      private int[] BC00123_A168ClienteId ;
      private bool[] BC00123_n168ClienteId ;
      private long[] BC00123_A238AssinaturaId ;
      private bool[] BC00123_n238AssinaturaId ;
      private int[] BC00122_A242AssinaturaParticipanteId ;
      private bool[] BC00122_n242AssinaturaParticipanteId ;
      private Guid[] BC00122_A246AssinaturaParticipanteKey ;
      private bool[] BC00122_n246AssinaturaParticipanteKey ;
      private string[] BC00122_A353AssinaturaParticipanteStatus ;
      private bool[] BC00122_n353AssinaturaParticipanteStatus ;
      private DateTime[] BC00122_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] BC00122_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] BC00122_A245AssinaturaParticipanteDataConclusao ;
      private bool[] BC00122_n245AssinaturaParticipanteDataConclusao ;
      private string[] BC00122_A247AssinaturaParticipanteTipo ;
      private bool[] BC00122_n247AssinaturaParticipanteTipo ;
      private string[] BC00122_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] BC00122_n346AssinaturaParticipanteRemoteAddres ;
      private string[] BC00122_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] BC00122_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] BC00122_A348AssinaturaParticipanteDispositivo ;
      private bool[] BC00122_n348AssinaturaParticipanteDispositivo ;
      private string[] BC00122_A350AssinaturaParticipanteCPF ;
      private bool[] BC00122_n350AssinaturaParticipanteCPF ;
      private string[] BC00122_A351AssinaturaParticipanteEmail ;
      private bool[] BC00122_n351AssinaturaParticipanteEmail ;
      private DateTime[] BC00122_A352AssinaturaParticipanteNascimento ;
      private bool[] BC00122_n352AssinaturaParticipanteNascimento ;
      private string[] BC00122_A354AssinaturaParticipanteLink ;
      private bool[] BC00122_n354AssinaturaParticipanteLink ;
      private int[] BC00122_A233ParticipanteId ;
      private bool[] BC00122_n233ParticipanteId ;
      private int[] BC00122_A168ClienteId ;
      private bool[] BC00122_n168ClienteId ;
      private long[] BC00122_A238AssinaturaId ;
      private bool[] BC00122_n238AssinaturaId ;
      private int[] BC001210_A242AssinaturaParticipanteId ;
      private bool[] BC001210_n242AssinaturaParticipanteId ;
      private string[] BC001213_A248ParticipanteNome ;
      private bool[] BC001213_n248ParticipanteNome ;
      private string[] BC001213_A235ParticipanteEmail ;
      private bool[] BC001213_n235ParticipanteEmail ;
      private string[] BC001213_A234ParticipanteDocumento ;
      private bool[] BC001213_n234ParticipanteDocumento ;
      private int[] BC001214_A554AssinaturaParticipanteTokenId ;
      private int[] BC001215_A258AssinaturaParticipanteNotificacaoId ;
      private int[] BC001216_A242AssinaturaParticipanteId ;
      private bool[] BC001216_n242AssinaturaParticipanteId ;
      private Guid[] BC001216_A246AssinaturaParticipanteKey ;
      private bool[] BC001216_n246AssinaturaParticipanteKey ;
      private string[] BC001216_A248ParticipanteNome ;
      private bool[] BC001216_n248ParticipanteNome ;
      private string[] BC001216_A235ParticipanteEmail ;
      private bool[] BC001216_n235ParticipanteEmail ;
      private string[] BC001216_A234ParticipanteDocumento ;
      private bool[] BC001216_n234ParticipanteDocumento ;
      private string[] BC001216_A353AssinaturaParticipanteStatus ;
      private bool[] BC001216_n353AssinaturaParticipanteStatus ;
      private DateTime[] BC001216_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] BC001216_n244AssinaturaParticipanteDataVisualizacao ;
      private DateTime[] BC001216_A245AssinaturaParticipanteDataConclusao ;
      private bool[] BC001216_n245AssinaturaParticipanteDataConclusao ;
      private string[] BC001216_A247AssinaturaParticipanteTipo ;
      private bool[] BC001216_n247AssinaturaParticipanteTipo ;
      private string[] BC001216_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] BC001216_n346AssinaturaParticipanteRemoteAddres ;
      private string[] BC001216_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] BC001216_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] BC001216_A348AssinaturaParticipanteDispositivo ;
      private bool[] BC001216_n348AssinaturaParticipanteDispositivo ;
      private string[] BC001216_A350AssinaturaParticipanteCPF ;
      private bool[] BC001216_n350AssinaturaParticipanteCPF ;
      private string[] BC001216_A351AssinaturaParticipanteEmail ;
      private bool[] BC001216_n351AssinaturaParticipanteEmail ;
      private DateTime[] BC001216_A352AssinaturaParticipanteNascimento ;
      private bool[] BC001216_n352AssinaturaParticipanteNascimento ;
      private string[] BC001216_A354AssinaturaParticipanteLink ;
      private bool[] BC001216_n354AssinaturaParticipanteLink ;
      private int[] BC001216_A233ParticipanteId ;
      private bool[] BC001216_n233ParticipanteId ;
      private int[] BC001216_A168ClienteId ;
      private bool[] BC001216_n168ClienteId ;
      private long[] BC001216_A238AssinaturaId ;
      private bool[] BC001216_n238AssinaturaId ;
      private SdtAssinaturaParticipante bcAssinaturaParticipante ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinaturaparticipante_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00122;
          prmBC00122 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00123;
          prmBC00123 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00124;
          prmBC00124 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC00125;
          prmBC00125 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00126;
          prmBC00126 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC00127;
          prmBC00127 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00128;
          prmBC00128 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00129;
          prmBC00129 = new Object[] {
          new ParDef("AssinaturaParticipanteKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataVisualizacao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataConclusao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteRemoteAddres",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteGeolocalizacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDispositivo",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteLink",GXType.VarChar,256,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001210;
          prmBC001210 = new Object[] {
          };
          Object[] prmBC001211;
          prmBC001211 = new Object[] {
          new ParDef("AssinaturaParticipanteKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataVisualizacao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDataConclusao",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteRemoteAddres",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteGeolocalizacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteDispositivo",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteLink",GXType.VarChar,256,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001212;
          prmBC001212 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001213;
          prmBC001213 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC001214;
          prmBC001214 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001215;
          prmBC001215 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001216;
          prmBC001216 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00122", "SELECT AssinaturaParticipanteId, AssinaturaParticipanteKey, AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao, AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF, AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento, AssinaturaParticipanteLink, ParticipanteId, ClienteId, AssinaturaId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId  FOR UPDATE OF AssinaturaParticipante",true, GxErrorMask.GX_NOMASK, false, this,prmBC00122,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00123", "SELECT AssinaturaParticipanteId, AssinaturaParticipanteKey, AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao, AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF, AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento, AssinaturaParticipanteLink, ParticipanteId, ClienteId, AssinaturaId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00123,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00124", "SELECT ParticipanteNome, ParticipanteEmail, ParticipanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00124,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00125", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00125,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00126", "SELECT AssinaturaId FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00126,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00127", "SELECT TM1.AssinaturaParticipanteId, TM1.AssinaturaParticipanteKey, T2.ParticipanteNome, T2.ParticipanteEmail, T2.ParticipanteDocumento, TM1.AssinaturaParticipanteStatus, TM1.AssinaturaParticipanteDataVisualizacao, TM1.AssinaturaParticipanteDataConclusao, TM1.AssinaturaParticipanteTipo, TM1.AssinaturaParticipanteRemoteAddres, TM1.AssinaturaParticipanteGeolocalizacao, TM1.AssinaturaParticipanteDispositivo, TM1.AssinaturaParticipanteCPF, TM1.AssinaturaParticipanteEmail, TM1.AssinaturaParticipanteNascimento, TM1.AssinaturaParticipanteLink, TM1.ParticipanteId, TM1.ClienteId, TM1.AssinaturaId FROM (AssinaturaParticipante TM1 LEFT JOIN Participante T2 ON T2.ParticipanteId = TM1.ParticipanteId) WHERE TM1.AssinaturaParticipanteId = :AssinaturaParticipanteId ORDER BY TM1.AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00127,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00128", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00128,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00129", "SAVEPOINT gxupdate;INSERT INTO AssinaturaParticipante(AssinaturaParticipanteKey, AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao, AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF, AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento, AssinaturaParticipanteLink, ParticipanteId, ClienteId, AssinaturaId) VALUES(:AssinaturaParticipanteKey, :AssinaturaParticipanteStatus, :AssinaturaParticipanteDataVisualizacao, :AssinaturaParticipanteDataConclusao, :AssinaturaParticipanteTipo, :AssinaturaParticipanteRemoteAddres, :AssinaturaParticipanteGeolocalizacao, :AssinaturaParticipanteDispositivo, :AssinaturaParticipanteCPF, :AssinaturaParticipanteEmail, :AssinaturaParticipanteNascimento, :AssinaturaParticipanteLink, :ParticipanteId, :ClienteId, :AssinaturaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00129)
             ,new CursorDef("BC001210", "SELECT currval('AssinaturaParticipanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001211", "SAVEPOINT gxupdate;UPDATE AssinaturaParticipante SET AssinaturaParticipanteKey=:AssinaturaParticipanteKey, AssinaturaParticipanteStatus=:AssinaturaParticipanteStatus, AssinaturaParticipanteDataVisualizacao=:AssinaturaParticipanteDataVisualizacao, AssinaturaParticipanteDataConclusao=:AssinaturaParticipanteDataConclusao, AssinaturaParticipanteTipo=:AssinaturaParticipanteTipo, AssinaturaParticipanteRemoteAddres=:AssinaturaParticipanteRemoteAddres, AssinaturaParticipanteGeolocalizacao=:AssinaturaParticipanteGeolocalizacao, AssinaturaParticipanteDispositivo=:AssinaturaParticipanteDispositivo, AssinaturaParticipanteCPF=:AssinaturaParticipanteCPF, AssinaturaParticipanteEmail=:AssinaturaParticipanteEmail, AssinaturaParticipanteNascimento=:AssinaturaParticipanteNascimento, AssinaturaParticipanteLink=:AssinaturaParticipanteLink, ParticipanteId=:ParticipanteId, ClienteId=:ClienteId, AssinaturaId=:AssinaturaId  WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001211)
             ,new CursorDef("BC001212", "SAVEPOINT gxupdate;DELETE FROM AssinaturaParticipante  WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001212)
             ,new CursorDef("BC001213", "SELECT ParticipanteNome, ParticipanteEmail, ParticipanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001214", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001215", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001216", "SELECT TM1.AssinaturaParticipanteId, TM1.AssinaturaParticipanteKey, T2.ParticipanteNome, T2.ParticipanteEmail, T2.ParticipanteDocumento, TM1.AssinaturaParticipanteStatus, TM1.AssinaturaParticipanteDataVisualizacao, TM1.AssinaturaParticipanteDataConclusao, TM1.AssinaturaParticipanteTipo, TM1.AssinaturaParticipanteRemoteAddres, TM1.AssinaturaParticipanteGeolocalizacao, TM1.AssinaturaParticipanteDispositivo, TM1.AssinaturaParticipanteCPF, TM1.AssinaturaParticipanteEmail, TM1.AssinaturaParticipanteNascimento, TM1.AssinaturaParticipanteLink, TM1.ParticipanteId, TM1.ClienteId, TM1.AssinaturaId FROM (AssinaturaParticipante TM1 LEFT JOIN Participante T2 ON T2.ParticipanteId = TM1.ParticipanteId) WHERE TM1.AssinaturaParticipanteId = :AssinaturaParticipanteId ORDER BY TM1.AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001216,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((long[]) buf[29])[0] = rslt.getLong(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((long[]) buf[29])[0] = rslt.getLong(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((long[]) buf[35])[0] = rslt.getLong(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((long[]) buf[35])[0] = rslt.getLong(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
       }
    }

 }

}
